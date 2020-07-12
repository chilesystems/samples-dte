using ChileSystems.DTE.Engine.Documento;
using ChileSystems.DTE.Engine.XML;
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
    public partial class IngresarTimbraje : Form
    {
        Autorizacion aut;

        public IngresarTimbraje()
        {
            InitializeComponent();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                txtFilePath.Text = openFileDialog1.FileName;
                aut = XmlHandler.DeserializeRaw<Autorizacion>(openFileDialog1.FileName);
                aut.CAF.IdCAF = 1;
                textFecha.Text = aut.CAF.Datos.FechaAutorizacion.ToShortDateString();
                textRango.Text = aut.CAF.Datos.RangoAutorizado.Desde.ToString() + " - " + aut.CAF.Datos.RangoAutorizado.Hasta.ToString();
                string tipo = string.Empty;
                switch (aut.CAF.Datos.TipoDTE)
                {
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaCompraElectronica:
                        tipo = "FACTURA DE COMPRA ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica:
                        tipo = "FACTURA ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronicaExenta:
                        tipo = "FACTURA ELECTRÓNICA EXENTA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica:
                        tipo = "GUIA DE DESPACHO ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica:
                        tipo = "NOTA DE CRÉDITO ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica:
                        tipo = "NOTA DE DÉBITO ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica:
                        tipo = "BOLETA ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronicaExenta:
                        tipo = "BOLETA ELECTRÓNICA EXENTA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaExportacionElectronica:
                        tipo = "FACTURA DE EXPORTACIÓN ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoExportacionElectronica:
                        tipo = "NOTA DE CRÉDITO DE EXPORTACIÓN ELECTRÓNICA";
                        break;
                    case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoExportacionElectronica:
                        tipo = "NOTA DE DÉBITO DE EXPORTACIÓN ELECTRÓNICA";
                        break;
                }
                textTipoCAF.Text = tipo;
                // xml = File.ReadAllBytes(openFileDialog1.FileName);

            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            string filePath = "out\\caf\\" + string.Format("{0}_{1}_{2}.dat", (int)aut.CAF.Datos.TipoDTE, aut.CAF.Datos.RangoAutorizado.Desde.ToString(), aut.CAF.Datos.RangoAutorizado.Hasta.ToString());
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                var xml = File.ReadAllBytes(openFileDialog1.FileName);
                fs.Write(xml, 0, xml.Length);
                fs.Flush();
                fs.Close();
            }
            MessageBox.Show("CAF Guardado correctamente");
        }
    }
}
