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
    public partial class Main : Form
    {
        Handler handler = new Handler();

        public Main()
        {
            InitializeComponent();
        }

        #region Emision de Documentos

        private void botonIngresarTimbraje_Click(object sender, EventArgs e)
        {
            IngresarTimbraje formulario = new IngresarTimbraje();
            formulario.ShowDialog();
        }

        private void botonGenerarDocumento_Click(object sender, EventArgs e)
        {
            //El folio es obligatorio
            handler.Folio = 101;
            //El Id debe ser alfanumerico. Remitirse a letras y números
            handler.idDte = "TESTPRUEBA1";
            var dte = handler.GenerateDTE();
            handler.GenerateDetails(dte);

            handler.usaReferencia = false;
            handler.Referencias(dte);

            var path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");

            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            MessageBox.Show("Documento generado exitosamente en " + path);
        }

        private void botonGenerarEnvio_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            string[] pathFiles = openFileDialog1.FileNames;
            List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
            List<string> xmlDtes = new List<string>();
            foreach (string pathFile in pathFiles)
            {
                string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
                var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);

                /*Generar envio para el SII
                Un envío puede contener 1 o varios DTE. No es necesario que sean del mismo tipo,
                es decir, en un envío pueden ir facturas electrónicas afectas, notas de crédito, guias de despacho,
                etc.             
                 */
                dtes.Add(dte);
                xmlDtes.Add(xml);
            }
            var EnvioSII = handler.GenerarEnvioDTEToSII(dtes, xmlDtes);

            /*Generar envio para el cliente
            En esencia es lo mismo que para el SII */
            //var EnvioCliente = GenerarEnvioCliente(dte, xml);

            /*Puede ser el EnvioSII o EnvioCliente, pues es el mismo tipo de objeto*/
            var filePath = EnvioSII.Firmar(handler.nombreCertificado, handler.serialKEY, true);
            handler.Validate(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.Envio, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE);
            MessageBox.Show("Envío generado exitosamente en " + filePath);
        }

        private void botonEnviarSii_Click(object sender, EventArgs e)
        {
            /*Procedemos a enviar el 'Envío' al SII, que no es otra cosa que simular un upload vía browser*/
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            string pathFile = openFileDialog1.FileName;
            int trackId = handler.EnviarEnvioDTEToSII(pathFile, handler.serialKEY, radioProduccion.Checked);
            MessageBox.Show("Sobre enviado correctamente. TrackID: " + trackId.ToString());
        }

        #endregion

        #region Simulacion

        private void botonSimulacion_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
            List<string> xmlDtes = new List<string>();
            /*Cada valor de i se asigna como folio. Debes tener ojo con no enviar documentos con folios ya utilizados y enviados.*/
            for (int i = 101; i <= 110; i++)
            {
                var dteAux = GenerateRandomDTE(i, ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica);
                string filePath = handler.TimbrarYFirmarXMLDTE(dteAux, "out\\temp\\", "out\\caf\\");
                string xml = File.ReadAllText(filePath, Encoding.GetEncoding("ISO-8859-1"));
                dtes.Add(dteAux);
                xmlDtes.Add(xml);
            }
            var EnvioSII = handler.GenerarEnvioDTEToSII(dtes, xmlDtes);
            string filePathEnvio = EnvioSII.Firmar(handler.nombreCertificado, handler.serialKEY);
            MessageBox.Show("Envío generado exitosamente en " + filePathEnvio);
        }

        public ChileSystems.DTE.Engine.Documento.DTE GenerateRandomDTE(int folio, ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipo)
        {
            // DOCUMENTO
            Random r = new Random();
            var dte = new ChileSystems.DTE.Engine.Documento.DTE();
            dte.Documento.Id = "TEST" + folio.ToString();
            dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipo;
            dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now;
            dte.Documento.Encabezado.IdentificacionDTE.Folio = folio;
            dte.Documento.Encabezado.IdentificacionDTE.TipoDespacho = ChileSystems.DTE.Engine.Enum.TipoDespacho.TipoDespachoEnum.EmisorACliente;
            dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta;

            //DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            dte.Documento.Encabezado.Emisor.Rut = handler.rutEmpresa;
            dte.Documento.Encabezado.Emisor.RazonSocial = "TRANSPORTE DISTRIBUCION Y COMERCIALIZACION DE PRODUCTOS D&V LIMITADA";
            dte.Documento.Encabezado.Emisor.Giro = "VENTA AL POR MAYOR DE CONFITES";

            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(512250);
            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(519000);

            //DOCUMENTO - ENCABEZADO - EMISOR - SUCURSAL ORIGEN
            dte.Documento.Encabezado.Emisor.CodigoSucursal = 0;
            dte.Documento.Encabezado.Emisor.DireccionOrigen = "TOESCA 2023";
            dte.Documento.Encabezado.Emisor.ComunaOrigen = "SANTIAGO";
            dte.Documento.Encabezado.Emisor.CiudadOrigen = "SANTIAGO";

            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Documento.Encabezado.Receptor.Rut = "66666666-6";
            dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente";
            dte.Documento.Encabezado.Receptor.Direccion = "Direccion de cliente";
            dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad";

            //DOCUMENTO - DETALLES
            dte.Documento.Detalles = new List<ChileSystems.DTE.Engine.Documento.Detalle>();
            int max_detalles = r.Next(1, 5);
            List<string> detallesRandom = new List<string>();
            detallesRandom.Add("SERVICIO DE FACTURACION ELECT");
            detallesRandom.Add("ASESORIA COMPUTACIONAL");
            detallesRandom.Add("CAPACITACION AL PERSONAL");
            detallesRandom.Add("IMPLEMENTACION DE ERP");
            detallesRandom.Add("SERVICIO DE LIMPIEZA");
            detallesRandom.Add("SERVICIO DE ASESORIA INFORMATICA");
            detallesRandom.Add("DESARROLLO DE SITIOS WEB");
            detallesRandom.Add("QA DE DESARROLLOS EXTERNOS");
            detallesRandom.Add("LIMPIEZA DE COMPUTADORES");
            detallesRandom.Add("AUTOMATIZACION DE DATOS");
            detallesRandom.Add("DESARROLLO DE ETL");

            for (int i = 1; i <= max_detalles; i++)
            {
                var detalle = new ChileSystems.DTE.Engine.Documento.Detalle();
                detalle.NumeroLinea = i;
                detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;
                detalle.Nombre = detallesRandom[r.Next(0, detallesRandom.Count - 1)];
                detalle.Cantidad = r.Next(1, 5);
                detalle.Precio = r.Next(1, 150000);
                detalle.MontoItem = (int)detalle.Cantidad * (int)detalle.Precio;
                dte.Documento.Detalles.Add(detalle);
            }

            //DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
            //dte.Documento.Encabezado.Totales.MontoNeto = 0;
            dte.Documento.Encabezado.Totales.MontoExento = dte.Documento.Detalles.Sum(x => x.MontoItem);
            //dte.Documento.Encabezado.Totales.TasaIVA = Convert.ToDouble(19);
            //dte.Documento.Encabezado.Totales.IVA = 0;
            dte.Documento.Encabezado.Totales.MontoTotal = dte.Documento.Detalles.Sum(x => x.MontoItem);

            return dte;
        }

        private void botonEnviarSimulacionSII_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            string pathFile = openFileDialog1.FileName;
            handler.EnviarEnvioDTEToSII(pathFile, "SERIALKEY", radioProduccion.Checked);
        }

        #endregion

        #region Boletas Electronicas

        private void botonGenerarBoleta_Click(object sender, EventArgs e)
        {
            GenerarBoletaElectronica formulario = new GenerarBoletaElectronica();
            formulario.ShowDialog();
        }

        private void botonGenerarRCOF_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            string[] pathFiles = openFileDialog1.FileNames;
            List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
            foreach (string pathFile in pathFiles)
            {
                string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
                var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);
                dtes.Add(dte);
            }
            var rcof = handler.GenerarRCOF(dtes);
            rcof.DocumentoConsumoFolios.Id = "RCOF_" + DateTime.Now.Ticks.ToString();
            /*Firmar retorna además a través de un out, el XML formado*/
            string xmlString = string.Empty;
            var filePathArchivo = rcof.Firmar(handler.nombreCertificado, handler.serialKEY, out xmlString);
            MessageBox.Show("RCOF Generado correctamente en " + filePathArchivo);
        }

        private void botonLibroBoletas_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            string[] pathFiles = openFileDialog1.FileNames;
            List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
            foreach (string pathFile in pathFiles)
            {
                string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
                var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);
                dtes.Add(dte);
            }
            var libro = handler.GenerateLibroBoletas(dtes);
            libro.EnvioLibro.Caratula.FolioNotificacion = 1;
            libro.EnvioLibro.Id = "L_BOLETAS_" + DateTime.Now.Ticks.ToString();
            var filePathArchivo = libro.Firmar(handler.nombreCertificado, handler.serialKEY);
            MessageBox.Show("Libro boletas Generado correctamente en " + filePathArchivo);
        }

        private void botonAnularDocumento_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            string pathFile = openFileDialog1.FileName;
            string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
            var dteBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);

            handler.tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica;
            handler.Folio = 9;
            handler.idDte = "NC_BOLELEC_3";

            var dteNC = handler.GenerateDTE();
            /*En el caso de las anulaciones, los detalles y totales son los mismos que el documento de origen*/
            dteNC.Documento.Detalles = dteBoleta.Documento.Detalles;
            dteNC.Documento.Encabezado.Totales = dteBoleta.Documento.Encabezado.Totales;
            dteNC.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
            dteNC.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
                FechaDocumentoReferencia = DateTime.Now,
                //Folio de Referencia = Debe ir el folio del documento que estás referenciando
                FolioReferencia = dteBoleta.Documento.Encabezado.IdentificacionDTE.Folio.ToString(),
                IndicadorGlobal = 0,
                Numero = 1,
                RazonReferencia = "ANULA BOLETA ELECTRÓNICA",
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.BoletaElectronica
            });

            var path = handler.TimbrarYFirmarXMLDTE(dteNC, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);

            MessageBox.Show("Nota de crédito generada exitosamente en " + path);
        }

        private void botonRebajaDocumento_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            string pathFile = openFileDialog1.FileName;
            string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
            var dteBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);

            handler.tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica;
            handler.Folio = 11;
            handler.idDte = "NC_BOLELEC_6";
            var dteNC = handler.GenerateDTE();
            /*En el caso de las anulaciones, los detalles y totales son los mismos que el documento de origen*/
            dteNC.Documento.Detalles = dteBoleta.Documento.Detalles;
            dteNC.Documento.Encabezado.Totales = dteBoleta.Documento.Encabezado.Totales;
            dteNC.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
            dteNC.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                FechaDocumentoReferencia = DateTime.Now,
                //Folio de Referencia = Debe ir el folio del documento que estás refenciando
                FolioReferencia = dteBoleta.Documento.Encabezado.IdentificacionDTE.Folio.ToString(),
                IndicadorGlobal = 0,
                Numero = 1,
                RazonReferencia = "CORRIGE BOLETA ELECTRÓNICA",
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.BoletaElectronica
            });

            /*Calculo para el caso de una rebaja de un 40%*/
            double porc_descuento = 0.4;
            var neto = dteNC.Documento.Encabezado.Totales.MontoNeto - (dteNC.Documento.Encabezado.Totales.MontoNeto * porc_descuento);
            int netoInt = (int)Math.Round(neto, 0);
            int iva = (int)Math.Round(neto * 0.19, 0);
            int total = netoInt + iva;
            dteNC.Documento.Encabezado.Totales.MontoNeto = netoInt;
            dteNC.Documento.Encabezado.Totales.IVA = iva;
            dteNC.Documento.Encabezado.Totales.MontoTotal = total;

            dteNC.Documento.DescuentosRecargos = new List<ChileSystems.DTE.Engine.Documento.DescuentosRecargos>();
            dteNC.Documento.DescuentosRecargos.Add(new ChileSystems.DTE.Engine.Documento.DescuentosRecargos()
            {
                Descripcion = "DESCUENTO COMERCIAL",
                Numero = 1,
                TipoMovimiento = ChileSystems.DTE.Engine.Enum.TipoMovimiento.TipoMovimientoEnum.Descuento,
                TipoValor = ChileSystems.DTE.Engine.Enum.ExpresionDinero.ExpresionDineroEnum.Porcentaje,
                Valor = porc_descuento * 100,
            });

            var path = handler.TimbrarYFirmarXMLDTE(dteNC, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);

            MessageBox.Show("Nota de crédito generada exitosamente en " + path);
        }

        private void botonGenerarEnvioBoleta_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();
            string[] pathFiles = openFileDialog1.FileNames;
            List<ChileSystems.DTE.Engine.Documento.DTE> dtes = new List<ChileSystems.DTE.Engine.Documento.DTE>();
            List<string> xmlDtes = new List<string>();
            foreach (string pathFile in pathFiles)
            {
                string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
                var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);
                dtes.Add(dte);
                xmlDtes.Add(xml);
            }
            var EnvioSII = handler.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes);
            var filePath = EnvioSII.Firmar(handler.nombreCertificado, handler.serialKEY, true);
            try
            {
                handler.Validate(filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Envío generado exitosamente en " + filePath);
        }
        #endregion

        #region Utilitarios

        private void botonAceptacion_Click(object sender, EventArgs e)
        {
            /*
                 * ACD: Acepta Contenido del Documento
                 * RCD: Reclamo al Contenido del Documento
                 * ERM: Otorga Recibo de Mercaderías o Servicios
                 * RFP: Reclamo por Falta Parcial de Mercaderías
                 * RFT: Reclamo por Falta Total de Mercaderías
                 */
            int tipoDocumento = 33;
            int folio = 17158136;
            string accion = "ACD";
            string rutProveedor = "81094100";
            int dvProveedor = 6;
            var respuesta = handler.EnviarAceptacionReclamo(tipoDocumento, folio, accion, rutProveedor, dvProveedor, true);
            MessageBox.Show(respuesta);
        }

        private void botonMuestraImpresa_Click(object sender, EventArgs e)
        {
            MuestraTimbre formulario = new MuestraTimbre();
            formulario.ShowDialog();
        }
        private void botonConsultarEstadoDTE_Click(object sender, EventArgs e)
        {
            var responseEstadoDTE = handler.ConsultarEstadoDTE(radioProduccion.Checked);
            if (responseEstadoDTE != null)
            {
                MessageBox.Show(responseEstadoDTE.ResponseXml);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void botonIECV_Click(object sender, EventArgs e)
        {
            var libro = handler.GenerateIECV();
            var path = libro.Firmar(handler.nombreCertificado, "out\\temp\\", handler.serialKEY);
            MessageBox.Show("Documento generado exitosamente en " + path);
        }

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void botonValidador_Click(object sender, EventArgs e)
        {
            Validador formulario = new Validador();
            formulario.ShowDialog();
        }

        private void botonSetPruebas_Click(object sender, EventArgs e)
        {
            handler.usaReferencia = false;

            #region DTEs
            /******************************/
            handler.Folio = 25;
            handler.idDte = "A_25";
            handler.casoPruebas = "1057727-1";
            var dte = handler.GenerateDTE();
            var detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 131,
                Nombre = "Cajón AFECTO",
                Precio = 1372,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 56,
                Nombre = "Relleno AFECTO",
                Precio = 2232,
                Afecto = true
            });
            handler.GenerateDetails(dte, detalles);            
            handler.Referencias(dte);
            var path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/

            /********************************/
            handler.Folio = 26;
            handler.idDte = "A_26";
            handler.casoPruebas = "1057727-2";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 326,
                Nombre = "Pañuelo AFECTO",
                Precio = 2616,
                Descuento = 5,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 256,
                Nombre = "ITEM 2 AFECTO",
                Precio = 1678,
                Descuento = 8,
                Afecto = true
            });
            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/

            /********************************/
            handler.Folio = 27;
            handler.idDte = "A_27";
            handler.casoPruebas = "1057727-3";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 27,
                Nombre = "Pintura B&W AFECTO",
                Precio = 2879,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 164,
                Nombre = "ITEM 2 AFECTO",
                Precio = 3099,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 1,
                Nombre = "ITEM 3 SERVICIO EXENTO",
                Precio = 34807,
                Afecto = false
            });
            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/

            /********************************/
            handler.Folio = 28;
            handler.idDte = "A_28";
            handler.casoPruebas = "1057727-4";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 139,
                Nombre = "ITEM 1 AFECTO",
                Precio = 2414,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 59,
                Nombre = "ITEM 2 AFECTO",
                Precio = 2419,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 2,
                Nombre = "ITEM 3 SERVICIO EXENTO",
                Precio = 6779,
                Afecto = false
            });

            dte.Documento.DescuentosRecargos = new List<ChileSystems.DTE.Engine.Documento.DescuentosRecargos>();
            dte.Documento.DescuentosRecargos.Add(new ChileSystems.DTE.Engine.Documento.DescuentosRecargos()
            {
                Descripcion = "DESCUENTO COMERCIAL",
                Numero = 1,
                TipoMovimiento = ChileSystems.DTE.Engine.Enum.TipoMovimiento.TipoMovimientoEnum.Descuento,
                TipoValor = ChileSystems.DTE.Engine.Enum.ExpresionDinero.ExpresionDineroEnum.Porcentaje,
                Valor = 9,
            });

            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/

            /********************************/
            handler.tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica;
            handler.Folio = 4;
            handler.idDte = "N_4";
            handler.casoPruebas = "1057727-5";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Nombre = "CORRIGE GIRO DEL RECEPTOR"
            });
            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeTextoDocumentoReferencia,
                FechaDocumentoReferencia = DateTime.Now,
                FolioReferencia = "25",
                IndicadorGlobal = 0,
                Numero = 2,
                RazonReferencia = "CORRIGE GIRO DEL RECEPTOR",
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
            });
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/

            /********************************/
            handler.tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica;
            handler.Folio = 5;
            handler.idDte = "N_5";
            handler.casoPruebas = "1057727-6";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 120,
                Nombre = "Pañuelo AFECTO",
                Precio = 2616,
                Descuento = 5,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 173,
                Nombre = "ITEM 2 AFECTO",
                Precio = 1678,
                Descuento = 8,
                Afecto = true
            });
            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                FechaDocumentoReferencia = DateTime.Now,
                FolioReferencia = "26",
                IndicadorGlobal = 0,
                Numero = 2,
                RazonReferencia = "DEVOLUCIÓN DE MERCADERÍAS",
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
            });
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/

            /********************************/
            handler.tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica;
            handler.Folio = 6;
            handler.idDte = "N_6";
            handler.casoPruebas = "1057727-7";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 27,
                Nombre = "Pintura B&W AFECTO",
                Precio = 2879,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 164,
                Nombre = "ITEM 2 AFECTO",
                Precio = 3099,
                Afecto = true
            });
            detalles.Add(new ItemBoleta()
            {
                Cantidad = 1,
                Nombre = "ITEM 3 SERVICIO EXENTO",
                Precio = 34807,
                Afecto = false
            });

            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
                FechaDocumentoReferencia = DateTime.Now,
                FolioReferencia = "27",
                IndicadorGlobal = 0,
                Numero = 2,
                RazonReferencia = "ANULA FACTURA",
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
            });
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/


            /********************************/
            handler.tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica;
            handler.Folio = 2;
            handler.idDte = "D_2";
            handler.casoPruebas = "1057727-8";
            dte = handler.GenerateDTE();
            detalles = new List<ItemBoleta>();
            detalles.Add(new ItemBoleta()
            {
                Nombre = "CORRIGE GIRO DEL RECEPTOR"
            });
            handler.GenerateDetails(dte, detalles);
            handler.Referencias(dte);
            dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
                FechaDocumentoReferencia = DateTime.Now,
                FolioReferencia = "4",
                IndicadorGlobal = 0,
                Numero = 2,
                RazonReferencia = "ANULA NOTA DE CREDITO",
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.NotaCreditoElectronica
            });
            path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_SDK.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            /********************************/
            #endregion

            #region Libro de VENTAS



            #endregion

            MessageBox.Show("Documento generado exitosamente en " + path);
        }
    }
}

