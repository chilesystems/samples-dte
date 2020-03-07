using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMPLEAPI_Demo
{
    public partial class MuestraImpresa : Form
    {
        public MuestraImpresa()
        {
            InitializeComponent();
        }

        private void botonCargarDTE_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string pathFile = openFileDialog1.FileName;
                string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));

                //var envioBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString<ChileSystems.DTE.Engine.Envio.EnvioBoleta>(xml);
                //pictureBoxTimbre.Image = envioBoleta.SetDTE.DTEs[0].Documento.TimbrePDF417(out outMessage);
                var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);
                //pictureBoxTimbre.BackgroundImage = dte.Documento.TimbrePDF417(out outMessage);
                cargaDataSet(dte);
            }
            
        }

        private void cargaDataSet(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            Reports.dataFacturaElectronica ds = new Reports.dataFacturaElectronica();
            Reports.dataFacturaElectronica.ENCABEZADORow encabezado = ds.ENCABEZADO.NewENCABEZADORow();
            encabezado.FECHA_EMISION = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision;
            encabezado.FOLIO = dte.Documento.Encabezado.IdentificacionDTE.Folio;
            encabezado.RUT_EMISOR = dte.Documento.Encabezado.Emisor.Rut;
            encabezado.TIPO = Handler.TipoDTEString(dte.Documento.Encabezado.IdentificacionDTE.TipoDTE);
            encabezado.UNIDAD_SII = "IQUIQUE";
                encabezado.CODIGO_BARRA = Handler.imageToByteArray(dte.Documento.TimbrePDF417(out string mensajeSalida));
                if (encabezado.CODIGO_BARRA == null) throw new Exception("No hay timbre");

            encabezado.CONDICION = "CONDICION DE PAGO";
            string refe = string.Empty;
            foreach (var referencia in dte.Documento.Referencias)
            {
                refe += referencia.RazonReferencia + "<br>";
            }
            encabezado.REFERENCIA_TEXTO = refe;

            ds.ENCABEZADO.AddENCABEZADORow(encabezado);

            Reports.dataFacturaElectronica.EMISORRow emisor = ds.EMISOR.NewEMISORRow();
            emisor.DIRECCION_MATRIZ = dte.Documento.Encabezado.Emisor.DireccionOrigen;
            emisor.GIRO = dte.Documento.Encabezado.Emisor.Giro;
            emisor.RAZON_SOCIAL = dte.Documento.Encabezado.Emisor.RazonSocial;
            ds.EMISOR.AddEMISORRow(emisor);

            Reports.dataFacturaElectronica.RECEPTORRow receptor = ds.RECEPTOR.NewRECEPTORRow();
            var recep = dte.Documento.Encabezado.Receptor;
            receptor.COMUNA = recep.Comuna;
            receptor.DIRECCION = recep.Direccion;
            receptor.GIRO = recep.Giro;
            receptor.RAZON_SOCIAL = recep.RazonSocial;
            receptor.RUT = recep.Rut;
            receptor.CONTACTO = recep.Contacto;
            ds.RECEPTOR.AddRECEPTORRow(receptor);

            Reports.dataFacturaElectronica.TOTALESRow totales = ds.TOTALES.NewTOTALESRow();
        
            var impuestos = dte.Documento.Encabezado.Totales.ImpuestosRetenciones;
            
            try { totales.IABA_10 = impuestos.Where(x => x.TasaImpuesto == 10).Sum(x => x.MontoImpuesto); }
            catch { totales.IABA_10 = 0; }
            try { totales.IABA_18 = impuestos.Where(x => x.TasaImpuesto == 18).Sum(x => x.MontoImpuesto); }
            catch { totales.IABA_18 = 0; }
            try { totales._IABA_20_5 = impuestos.Where(x => x.TasaImpuesto == 20.5).Sum(x => x.MontoImpuesto); }
            catch { totales._IABA_20_5 = 0; }
            try { totales._IABA_31_5 = impuestos.Where(x => x.TasaImpuesto == 31.5).Sum(x => x.MontoImpuesto); }
            catch { totales._IABA_31_5 = 0; }
            try { totales.IABA_12 = impuestos.Where(x => x.TasaImpuesto == 12).Sum(x => x.MontoImpuesto); }
            catch { }

            totales.ILA = dte.Documento.Encabezado.Totales.ImpuestosRetenciones.Sum(x => x.MontoImpuesto);
            totales.IVA = dte.Documento.Encabezado.Totales.IVA;
            totales.NETO = dte.Documento.Encabezado.Totales.MontoNeto;
            totales.TOTAL = dte.Documento.Encabezado.Totales.MontoTotal;
            totales.DESCUENTO = dte.Documento.DescuentosRecargos.Where(x => x.TipoMovimiento == ChileSystems.DTE.Engine.Enum.TipoMovimiento.TipoMovimientoEnum.Descuento).Sum(y => y.Valor) + "%";
            totales.EXENTO = dte.Documento.Encabezado.Totales.MontoExento;

            ds.TOTALES.AddTOTALESRow(totales);

            foreach (var a in dte.Documento.Detalles)
            {
                Reports.dataFacturaElectronica.DETALLESRow det = ds.DETALLES.NewDETALLESRow();
                det.CANTIDAD = (decimal)a.Cantidad;
                det._DESC_ = (decimal)a.Descuento;
                det.DESCRIPCION = a.Nombre;
                det.DESCUENTO_STRING = a.DescuentoPorcentaje.ToString() + "%";
                det.UNIDAD = a.UnidadMedida.ToString();

                det.NETOUNITARIO = a.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento ? 0 : (decimal)a.Precio;
                //en don omar aparecen en 0 este campo (TOTAL_NETO). con algunos clientes
                det.EXENTO = a.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento ? (decimal)a.Precio : 0;
                det.TOTAL = a.MontoItem;
                ds.DETALLES.Rows.Add(det);
            }

            try
            {
                if (radioCedible.Checked)
                {
                    crystalReportViewer1.ReportSource = FacturaElectronicaPlantillaCedible1;
                    FacturaElectronicaPlantillaCedible1.SetDataSource(ds);
                }
                else
                {
                    crystalReportViewer1.ReportSource = FacturaElectronicaPlantilla1;
                    FacturaElectronicaPlantilla1.SetDataSource(ds);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void MuestraImpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
