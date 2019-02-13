using ChileSystems.DTE.WS.EstadoDTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo
{
    public class Handler
    {
        public int Folio;
        double neto = 0, netoExento = 0, iva = 0, total = 0;

        public string casoPruebas;
        public string idDte;
        public string rutEmpresa = "11111111-1";
        public string rutCertificado = "1111111-1";
        public string nombreCertificado = "Carlos Cerda Zuniga";

        public string serialKEY = "7022-A610-6371-7031-9513"; //Valida hasta el 11 de febrero de 2020

        public ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica;

        public bool usaReferencia = false;

        #region Generar Documento

        public ChileSystems.DTE.Engine.Documento.DTE GenerateDTE()
        {
            // DOCUMENTO
            var dte = new ChileSystems.DTE.Engine.Documento.DTE();
            //
            // DOCUMENTO - ENCABEZADO - CAMPO OBLIGATORIO
            //Id = puede ser compuesto según tus propios requerimientos pero debe ser único         
            dte.Documento.Id = idDte;

            // DOCUMENTO - ENCABEZADO - IDENTIFICADOR DEL DOCUMENTO - CAMPOS OBLIGATORIOS
            //TipoDTE = Se indica el tipo de documento. Este SDK soporta:
            dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipoDTE;
            dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now;
            dte.Documento.Encabezado.IdentificacionDTE.Folio = Folio;
            //Para boletas electrónicas
            if(tipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
                dte.Documento.Encabezado.IdentificacionDTE.IndicadorServicio = ChileSystems.DTE.Engine.Enum.IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios;


            //DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            dte.Documento.Encabezado.Emisor.Rut = rutEmpresa;
            dte.Documento.Encabezado.Emisor.RazonSocialBoleta = "TRANSPORTE DISTRIBUCION Y COMERCIALIZACION DE PRODUCTOS D&V LIMITADA";
            dte.Documento.Encabezado.Emisor.GiroBoleta = "VENTA AL POR MAYOR DE CONFITES";

            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(512250);
            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(519000);

            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Documento.Encabezado.Receptor.Rut = "66666666-6";
            dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente";
            dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente";

            return dte;
        }

        public void GenerateDetails(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            //DOCUMENTO - DETALLES
            dte.Documento.Detalles = new List<ChileSystems.DTE.Engine.Documento.Detalle>();
            var detalle = new ChileSystems.DTE.Engine.Documento.Detalle();
            detalle.NumeroLinea = 1;
            /*IndicadorExento = Sólo aplica si el producto es exento de IVA*/
            //detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;

            detalle.Nombre = "SERVICIO DE FACTURACION ELECT";
            detalle.Cantidad = 12;
            detalle.Precio = 170;
            /*Monto del item*/
            /*Recordar que debe restarse el descuento del detalle y sumarse el recargo*/
            detalle.MontoItem = 2040;
            dte.Documento.Detalles.Add(detalle);

            detalle = new ChileSystems.DTE.Engine.Documento.Detalle();
            detalle.NumeroLinea = 2;
            //detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;
            detalle.Nombre = "DESARROLLO DE ETL";
            detalle.Cantidad = 20;
            detalle.Precio = 1050;
            detalle.MontoItem = 21000;
            dte.Documento.Detalles.Add(detalle);

            //DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS

            GenerateTotals(dte);
        }

        public void GenerateDetails(ChileSystems.DTE.Engine.Documento.DTE dte, List<ItemBoleta> detalles)
        {
            //DOCUMENTO - DETALLES
            dte.Documento.Detalles = new List<ChileSystems.DTE.Engine.Documento.Detalle>();

            int contador = 1;
            foreach (var det in detalles)
            {
                var detalle = new ChileSystems.DTE.Engine.Documento.Detalle();
                detalle.NumeroLinea = contador;
                /*IndicadorExento = Sólo aplica si el producto es exento de IVA*/
                detalle.IndicadorExento = det.Afecto ? ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet : ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;

                detalle.Nombre = det.Nombre;
                detalle.Cantidad = (double)det.Cantidad;
                detalle.Precio = det.Precio;
                if (!string.IsNullOrEmpty(det.UnidadMedida))
                {
                    detalle.UnidadMedida = det.UnidadMedida;
                }
                /*Monto del item*/
                /*Recordar que debe restarse el descuento del detalle y sumarse el recargo*/
                detalle.MontoItem = det.Total;
                dte.Documento.Detalles.Add(detalle);
                contador++;
            }
            GenerateTotals(dte);
        }

        private void GenerateTotals(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            calculosTotales(dte);

            //DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
            dte.Documento.Encabezado.Totales.MontoNeto = (int)Math.Round(neto, 0);
            dte.Documento.Encabezado.Totales.MontoExento = (int)Math.Round(netoExento, 0);
            if (neto != 0)
            {
                /*Las boletas no llevan TasaIVA*/
                //dte.Documento.Encabezado.Totales.TasaIVA = Convert.ToDouble(19);
                dte.Documento.Encabezado.Totales.IVA = (int)Math.Round(iva, 0); ;
            }
            dte.Documento.Encabezado.Totales.MontoTotal = (int)Math.Round(total, 0);
        }

        public void Referencias(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            dte.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
            var c = 1;
            /*Si estás en modo certificación, necesitas agregar esta referencia*/
            //REFERENCIA A SET DE PRUEBAS
            dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet,
                FechaDocumentoReferencia = DateTime.Now,
                FolioReferencia = idDte,
                IndicadorGlobal = 0,
                Numero = c,
                RazonReferencia = casoPruebas,
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.SetPruebas
            });

            /*Ejemplo de referencia a una orden de compra*/
            if (usaReferencia)
            {
                //c++;
                dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
                {
                    CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                    FechaDocumentoReferencia = DateTime.Now,
                    //Folio de Referencia = Debe ir el folio de la factura o documento que estás refenciando
                    FolioReferencia = "39",
                    IndicadorGlobal = 0,
                    Numero = c,
                    RazonReferencia = "FACTURA EXENTA ELECTRÓNICA N° 39 del " + dte.Documento.Encabezado.IdentificacionDTE.FechaEmisionString + " - CORRIGE MONTOS",
                    TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaExentaElectronica
                });
            }
        }

        public void ReferenciasBoleta(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            dte.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
            var c = 1;
            /*Si estás en modo certificación, necesitas agregar esta referencia*/
            // REFERENCIA A SET DE PRUEBAS
            dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
            {
                CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.NotSet,
                Numero = c,
                RazonReferencia = casoPruebas,

            });
        }

        public string TimbrarYFirmarXMLDTE(ChileSystems.DTE.Engine.Documento.DTE dte, string pathResult, string pathCaf)
        {
            /*En primer lugar, el documento debe timbrarse con el CAF que descargas desde el SII, es simular
             * cuando antes debías ir con las facturas en papel para que te las timbraran */
            string messageOut = string.Empty;
            dte.Documento.Timbrar(
                EnsureExists
                ((int)dte.Documento.Encabezado.IdentificacionDTE.TipoDTE,
                dte.Documento.Encabezado.IdentificacionDTE.Folio,
                pathCaf), pathResult, serialKEY, out messageOut);
            /*Finalmente, el documento timbrado debe firmarse con el certificado digital*/
            /*Se debe entregar en el argumento del método Firmar, el "FriendlyName" o Nombre descriptivo del certificado*/
            /*Retorna el filePath donde estará el archivo XML timbrado y firmado, listo para ser enviado al SII*/
            return dte.Firmar(nombreCertificado, serialKEY, out messageOut, "out\\temp\\");
        }

        //public bool ValidateEnvio(string filePath, ChileSystems.DTE.Security.Firma.Firma.TipoXML tipo)
        //{
        //    string messageResult = string.Empty;
        //    if (ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(filePath, out messageResult, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE))
        //        if (ChileSystems.DTE.Security.Firma.Firma.VerificarFirma(filePath, tipo))
        //            return true;
        //        else
        //            throw new Exception("NO SE HA PODIDO VERIFICAR LA FIRMA DEL ENVÍO");
        //    throw new Exception(messageResult);
        //}

        public bool Validate(string filePath, SIMPLE_SDK.Security.Firma.Firma.TipoXML tipo, string schema)
        {
            string messageResult = string.Empty;
            if (ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(filePath, out messageResult, schema))
                if (SIMPLE_SDK.Security.Firma.Firma.VerificarFirma(filePath, tipo, out string messageOutFirma))
                    return true;
                else
                    throw new Exception("NO SE HA PODIDO VERIFICAR LA FIRMA DEL ENVÍO");
            throw new Exception(messageResult);
        }

        private string EnsureExists(int tipoDTE, int folio, string pathCaf)
        {
            var cafFile = string.Empty;
            foreach (var file in System.IO.Directory.GetFiles(pathCaf))
                if (ParseName((new FileInfo(file)).Name, tipoDTE, folio))
                    cafFile = file;
            if (string.IsNullOrEmpty(cafFile))
                throw new Exception("NO HAY UN CÓDIGO DE AUTORIZACIÓN DE FOLIOS (CAF) ASIGNADO PARA ESTE TIPO DE DOCUMENTO (" + tipoDTE + ") QUE INCLUYA EL FOLIO REQUERIDO (" + folio + ").");
            return cafFile;
        }

        private static bool ParseName(string name, int tipoDTE, int folio)
        {
            try
            {
                var values = name.Substring(0, name.IndexOf('.')).Split('_');
                int tipo = Convert.ToInt32(values[0]);
                int desde = Convert.ToInt32(values[1]);
                int hasta = Convert.ToInt32(values[2]);
                return tipoDTE == tipo && desde <= folio && folio <= hasta;
            }
            catch { return false; }
        }

        #endregion

        #region Envio

        public ChileSystems.DTE.Engine.Envio.EnvioDTE GenerarEnvioDTEToSII(List<ChileSystems.DTE.Engine.Documento.DTE> dtes, List<string> xmlDtes)
        {
            var EnvioSII = new ChileSystems.DTE.Engine.Envio.EnvioDTE();
            EnvioSII.SetDTE = new ChileSystems.DTE.Engine.Envio.SetDTE();
            EnvioSII.SetDTE.Id = "FENV010";
            /*Es necesario agregar en el envío, los objetos DTE como sus respectivos XML en strings*/
            foreach (var a in dtes)
                EnvioSII.SetDTE.DTEs.Add(a);
            foreach (var a in xmlDtes)
            {
                EnvioSII.SetDTE.dteXmls.Add(a);
                EnvioSII.SetDTE.signedXmls.Add(a);
            }


            EnvioSII.SetDTE.Caratula = new ChileSystems.DTE.Engine.Envio.Caratula();
            EnvioSII.SetDTE.Caratula.FechaEnvio = DateTime.Now;
            /*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/
            EnvioSII.SetDTE.Caratula.FechaResolucion = new DateTime(2013, 5, 30);
            EnvioSII.SetDTE.Caratula.NumeroResolucion = 0;

            EnvioSII.SetDTE.Caratula.RutEmisor = rutEmpresa;
            EnvioSII.SetDTE.Caratula.RutEnvia = rutCertificado;
            EnvioSII.SetDTE.Caratula.RutReceptor = "60803000-K"; //Este es el RUT del SII
            EnvioSII.SetDTE.Caratula.SubTotalesDTE = new List<ChileSystems.DTE.Engine.Envio.SubTotalesDTE>();

            /*En la carátula del envío, se debe indicar cuantos documentos de cada tipo se están enviando*/
            var tipos = EnvioSII.SetDTE.DTEs.GroupBy(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE);
            foreach (var a in tipos)
            {
                EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(new ChileSystems.DTE.Engine.Envio.SubTotalesDTE()
                {
                    Cantidad = a.Count(),
                    TipoDTE = a.ElementAt(0).Documento.Encabezado.IdentificacionDTE.TipoDTE
                });
            }

            return EnvioSII;
        }

        public ChileSystems.DTE.Engine.Envio.EnvioDTE GenerarEnvioCliente(ChileSystems.DTE.Engine.Documento.DTE dte, string dteXML)
        {
            var EnvioCustomer = new ChileSystems.DTE.Engine.Envio.EnvioDTE();
            EnvioCustomer.SetDTE = new ChileSystems.DTE.Engine.Envio.SetDTE();
            EnvioCustomer.SetDTE.DTEs.Add(dte);
            EnvioCustomer.SetDTE.dteXmls.Add(dteXML);
            EnvioCustomer.SetDTE.Caratula = new ChileSystems.DTE.Engine.Envio.Caratula();
            EnvioCustomer.SetDTE.Caratula.FechaEnvio = DateTime.Now;
            /*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/
            EnvioCustomer.SetDTE.Caratula.FechaResolucion = DateTime.Now;
            EnvioCustomer.SetDTE.Caratula.NumeroResolucion = 80;

            EnvioCustomer.SetDTE.Caratula.RutEmisor = rutEmpresa;
            EnvioCustomer.SetDTE.Caratula.RutEnvia = rutCertificado;
            EnvioCustomer.SetDTE.Caratula.RutReceptor = dte.Documento.Encabezado.Receptor.Rut;
            /*Generalmente al cliente se le envía una sola factura, sin embargo si no es el caso, 
             se pueden agregar varias tal cual como está el método GenerarEnvioDTEToSII()*/
            EnvioCustomer.SetDTE.Caratula.SubTotalesDTE = new List<ChileSystems.DTE.Engine.Envio.SubTotalesDTE>()
            {
                new ChileSystems.DTE.Engine.Envio.SubTotalesDTE()
                {
                    Cantidad = 1,
                    TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE
                }
            };

            return EnvioCustomer;
        }

        public int EnviarEnvioDTEToSII(string filePathEnvio, string serialKey, bool produccion)
        {
            string messageResult = string.Empty;
            int trackID = -1;
            int i;
            try
            {
                for (i = 1; i <= 5; i++)
                {
                    string rutEmisorNumero = rutEmpresa.Substring(0, rutEmpresa.Length - 2);
                    string rutEmisorDigito = rutEmpresa.Substring(rutEmpresa.Length - 1);
                    string rutEmpresaNumero = rutEmpresa.Substring(0, rutEmpresa.Length - 2);
                    string rutEmpresaDigito = rutEmpresa.Substring(rutEmpresa.Length - 1);
                    var responseEnvio = ChileSystems.DTE.WS.EnvioDTE.EnvioDTE.Enviar(rutEmisorNumero, rutEmisorDigito, rutEmpresaNumero, rutEmpresaDigito, filePathEnvio, filePathEnvio, nombreCertificado, produccion, serialKey, out messageResult, ".\\out\\tkn.dat");

                    if (responseEnvio != null && string.IsNullOrEmpty(messageResult))
                    {
                        trackID = responseEnvio.TrackId;

                        /*Aquí pueden obtener todos los datos de la respuesta, tal como:
                         * Estado
                         * Fecha
                         * Archivo
                         * Glosa
                         * XML
                         * Entre otros*/
                        return trackID;
                    }
                }

                if (i == 5)
                    throw new Exception("SE HA ALCANZADO EL MÁXIMO NÚMERO DE INTENTOS: " + messageResult);
            }
            catch (Exception ex)
            {
                messageResult = ex.Message;
                return 0;
            }
            return 0;
        }

        private void calculosTotales(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            try
            {
                foreach (var det in dte.Documento.Detalles)
                {
                    double div = 1.19;
                    var NetoUnitario = (det.Precio / div);
                    var Neto = (NetoUnitario * det.Cantidad);
                    double iva_aux = Neto * 0.19;
                    var IVA = Convert.ToInt32(Math.Round(iva_aux, 0));
                    var Total = (int)Math.Round(Neto + iva_aux, 0);
                    if (Total != det.MontoItem)
                    {
                        throw new Exception("Los totales no cuadran");
                    }
                    if (!(det.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento))
                    {
                        neto += Neto;
                    }
                    else
                    {
                        netoExento += det.Precio;
                    }
                }

                neto = Math.Round(neto, 0);
                iva = Math.Round(neto * 0.19, 0);
                total = netoExento + neto + iva;

                int nuevoNeto = (int)Math.Round(neto, 0);
                int nuevoExento = (int)Math.Round(netoExento, 0);
                int nuevoIVA = (int)Math.Round(iva, 0);
                int nuevoTotal = (int)Math.Round(total, 0);
            }
            catch { /*MessageBox.Show("Error. Hay una línea que debe ser borrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);*/ }
        }

        #endregion


        #region Boletas Electrónicas

        public ChileSystems.DTE.Engine.Envio.EnvioBoleta GenerarEnvioBoletaDTEToSII(List<ChileSystems.DTE.Engine.Documento.DTE> dtes, List<string> xmlDtes)
        {
            var EnvioSII = new ChileSystems.DTE.Engine.Envio.EnvioBoleta();
            EnvioSII.SetDTE = new ChileSystems.DTE.Engine.Envio.SetDTE();
            EnvioSII.SetDTE.Id = "FENV010";
            /*Es necesario agregar en el envío, los objetos DTE como sus respectivos XML en strings*/
            foreach (var a in dtes)
                EnvioSII.SetDTE.DTEs.Add(a);
            foreach (var a in xmlDtes)
            {
                EnvioSII.SetDTE.dteXmls.Add(a);
                EnvioSII.SetDTE.signedXmls.Add(a);
            }

            EnvioSII.SetDTE.Caratula = new ChileSystems.DTE.Engine.Envio.Caratula();
            EnvioSII.SetDTE.Caratula.FechaEnvio = DateTime.Now;
            /*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/
            EnvioSII.SetDTE.Caratula.FechaResolucion = new DateTime(2013, 5, 30);
            EnvioSII.SetDTE.Caratula.NumeroResolucion = 0;

            EnvioSII.SetDTE.Caratula.RutEmisor = rutEmpresa;
            EnvioSII.SetDTE.Caratula.RutEnvia = rutCertificado;
            EnvioSII.SetDTE.Caratula.RutReceptor = "60803000-K"; //Este es el RUT del SII
            EnvioSII.SetDTE.Caratula.SubTotalesDTE = new List<ChileSystems.DTE.Engine.Envio.SubTotalesDTE>();

            /*En la carátula del envío, se debe indicar cuantos documentos de cada tipo se están enviando*/
            var tipos = EnvioSII.SetDTE.DTEs.GroupBy(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE);
            foreach (var a in tipos)
            {
                EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(new ChileSystems.DTE.Engine.Envio.SubTotalesDTE()
                {
                    Cantidad = a.Count(),
                    TipoDTE = a.ElementAt(0).Documento.Encabezado.IdentificacionDTE.TipoDTE
                });
            }
            return EnvioSII;
        }

        public ChileSystems.DTE.Engine.RCOF.ConsumoFolios GenerarRCOF(List<ChileSystems.DTE.Engine.Documento.DTE> dtes)
        {
            var rcof = new ChileSystems.DTE.Engine.RCOF.ConsumoFolios();
            //preparo los datos segun los DTE seleccionados
            DateTime fechaInicio = dtes.Min(x => x.Documento.Encabezado.IdentificacionDTE.FechaEmision);
            DateTime fechaFinal = dtes.Max(x => x.Documento.Encabezado.IdentificacionDTE.FechaEmision);

            rcof.DocumentoConsumoFolios.Caratula.FechaFinal = fechaInicio;
            rcof.DocumentoConsumoFolios.Caratula.FechaInicio = fechaFinal;
            rcof.DocumentoConsumoFolios.Caratula.FechaResolucion = DateTime.Now;
            rcof.DocumentoConsumoFolios.Caratula.NroResol = 50;
            rcof.DocumentoConsumoFolios.Caratula.RutEmisor = rutEmpresa;
            rcof.DocumentoConsumoFolios.Caratula.RutEnvia = rutCertificado;
            rcof.DocumentoConsumoFolios.Caratula.SecEnvio = "1";
            rcof.DocumentoConsumoFolios.Caratula.FechaEnvio = DateTime.Now;
            List<ChileSystems.DTE.Engine.RCOF.Resumen> resumenes = new List<ChileSystems.DTE.Engine.RCOF.Resumen>();

            /*datos de boletas electrónicas afectas*/
            int totalNeto = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoNeto);
            int totalExento = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoExento);
            int totalIva = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.IVA);
            int totalTotal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoTotal);
            int rangoInicial = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Min(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            int rangoFinal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Max(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            resumenes.Add(new ChileSystems.DTE.Engine.RCOF.Resumen
            {
                FoliosAnulados = "0",
                FoliosEmitidos = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Count().ToString(),
                FoliosUtilizados = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Count().ToString(),
                MntExento = totalExento,
                MntIva = totalIva,
                MntNeto = totalNeto,
                MntTotal = totalTotal,
                TasaIVA = 19,
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica,
                RangoUtilizados = new ChileSystems.DTE.Engine.RCOF.RangoUtilizados() { Inicial = rangoInicial, Final = rangoFinal },
                RangoAnulados = new ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Inicial = 0, Final = 0 }
            });

            /*datos de notas de credito electronicas*/
            /*datos de boletas electrónicas afectas*/
            totalNeto = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoNeto);
            totalExento = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoExento);
            totalIva = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.IVA);
            totalTotal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoTotal);
            rangoInicial = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Min(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            rangoFinal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Max(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            resumenes.Add(new ChileSystems.DTE.Engine.RCOF.Resumen
            {
                FoliosAnulados = "0",
                FoliosEmitidos = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Count().ToString(),
                FoliosUtilizados = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Count().ToString(),
                MntExento = totalExento,
                MntIva = totalIva,
                MntNeto = totalNeto,
                MntTotal = totalTotal,
                TasaIVA = 19,
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica,
                RangoUtilizados = new ChileSystems.DTE.Engine.RCOF.RangoUtilizados() { Inicial = rangoInicial, Final = rangoFinal },
                RangoAnulados = new ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Inicial = 0, Final = 0 }
            });

            rcof.DocumentoConsumoFolios.Resumen = resumenes;
            return rcof;
        }

        public ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.LibroBoletas GenerateLibroBoletas(List<ChileSystems.DTE.Engine.Documento.DTE> dtes)
        {
            var libro = new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.LibroBoletas();

            libro.EnvioLibro = new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.EnvioLibro();

            /*Datos para confeccion de caratula*/
            string periodoTributario = "2018-05";
            DateTime fechaResolucion = new DateTime(2016, 4, 28);
            int nResolucion = 0;
            /*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/
            /*El tipo de libro debe ser "Especial" cuando se trata del set de pruebas*/
            /*El folio de notificacion lo entrega el SII al momento de solicitar el libro, para el set de pruebas no es necesario agregarlo*/
            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Caratula
            {
                RutEmisor = rutEmpresa,
                RutEnvia = rutCertificado,
                PeriodoTributario = periodoTributario,
                FechaResolucion = fechaResolucion,
                NumeroResolucion = nResolucion,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total
            };

            libro.EnvioLibro.ResumenPeriodo = new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.ResumenPeriodo();
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = new List<ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalPeriodo>();

            /*Se agregar un Total Periodo por cada tipo de documento. Boletas electrónicas exentas y afectas*/
            /*Boletas electronicas*/
            int totalNeto = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoNeto);
            int totalIVA = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.IVA);
            int totalExento = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoExento);
            int totalTotal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoTotal);

            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.BoletaElectronica,
                CantidadDocumentosAnulados = 0,
                TotalesServicio = new List<ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalServicio>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalServicio()
                    {
                        CantidadDocumentos = dtes.Count(x=>x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica),
                        TasaIVA = 19,
                        TotalIVA = totalIVA,
                        TotalNeto = totalNeto,
                        TotalExento = totalExento,
                        TotalTotal = totalTotal,
                        TipoServicio = (int)ChileSystems.DTE.Engine.Enum.IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios
                    }
                }
            });

            /*Se agregan los dtes del libro*/
            libro.EnvioLibro.Detalles = new List<ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Detalle>();
            foreach (var dte in dtes)
                libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Detalle()
                {
                    TipoDocumento = (ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro)dte.Documento.Encabezado.IdentificacionDTE.TipoDTE,
                    FolioDocumento = dte.Documento.Encabezado.IdentificacionDTE.Folio,
                    FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision,
                    MontoExento = dte.Documento.Encabezado.Totales.MontoExento,
                    MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
                    RutCliente = dte.Documento.Encabezado.Receptor.Rut
                });

            return libro;
        }
        #endregion

        #region IECV

        public ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta GenerateIECV()
        {
            var libro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta();
            libro.EnvioLibro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro();
            libro.EnvioLibro.Id = "ID_LIBRO1";

            /*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
             * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula()
            {
                RutEmisor = rutEmpresa,
                RutEnvia = rutCertificado,
                PeriodoTributario = "2018-08",
                FechaResolucion = DateTime.Now,
                NumeroResolucion = 0,
                TipoOperacion = ChileSystems.DTE.Engine.Enum.TipoOperacionLibro.TipoOperacionLibroEnum.Venta,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total
            };

            libro.EnvioLibro.ResumenPeriodo = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo();
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo>();

            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TotalIVARetenidoTotal = 0,
                TotalIVAUsoComun = 0,
                TotalCreditoIVAUsoComun = 0, //RESUMEN.ivaUSOCOMUN * 0.6
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                CantidadDocumentos = 1,
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = 0,
                TotalMontoNeto = 0,
                TotalMontoIva = 0,
                CantidadOperacionesIVaRecuperable = 0,
                CantidadOperacionesConIvaUsoComun = 0,
                CantidadOperacionesExentas = 0,
                TotalIVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable>() {
                        new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable() {
                            CantidadOperacionesIVANoRecuperable = 0,
                            CodigoIVANoRecuperable = ChileSystems.DTE.Engine.Enum.CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.NotSet,
                            TotalMontoIVANoRecuperable = 0
                        }
                    },
                TotalMonto = 0
                /*Sólo si aplican*/
                //Impuestos = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosPeriodo>(),
                //TotalIVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable>(),
            });


            libro.EnvioLibro.Detalles = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle>();

            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                NumeroDocumento = 1,
                IndicadorAnulado = ChileSystems.DTE.Engine.Enum.IndicadorAnulado.IndicadorAnuladoEnum.NotSet,
                TasaImpuestoOperacion = 0.19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "11111111-1",
                RazonSocial = "RAZON SOCIAL",
                MontoExento = 0,
                MontoNeto = 0,
                MontoIva = 0,
                IVAUsoComun = 0,
                MontoTotal = 0,
                //Impuestos = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle>(),
                //IVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle>(),
                IVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle>() { new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle() { CodigoIVANoRecuperable = ChileSystems.DTE.Engine.Enum.CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.NotSet, TotalMontoIVANoRecuperable = 0 } },

                IVARetenidoTotal = 0,
                TipoDocumentoReferencia = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotSet,
                FolioDocumentoReferencia = 0
            });

            return libro;
        }

        #endregion  



        #region Utilidades
        public string EnviarAceptacionReclamo(int tipoDocumento, int folio, string accion, string rutProveedor, int dvProveedor, bool produccion)
        {
            string messageResult = string.Empty;
            int trackID = -1;
            int i;
            try
            {
                for (i = 1; i <= 5; i++)
                {
                    var responseEnvio = ChileSystems.DTE.WS.AceptacionReclamo.AceptacionReclamoWS.NotificarAceptacionReclamo
                        (rutProveedor, dvProveedor.ToString(), tipoDocumento, folio, accion, nombreCertificado, produccion, ".\\out\\tkn.dat", serialKEY);

                    if (responseEnvio != null && string.IsNullOrEmpty(messageResult))
                    {
                        return responseEnvio;
                    }
                }

                if (i == 5)
                    throw new Exception("SE HA ALCANZADO EL MÁXIMO NÚMERO DE INTENTOS: " + messageResult);
            }
            catch (Exception ex)
            {
                messageResult = ex.Message;
                return "Error: " + messageResult;
            }
            return "Error";
        }

        public EstadoDTEResult ConsultarEstadoDTE(bool produccion)
        {
            /*Datos del emisor del documento, el rut de la empresa emisora y rut del receptor*/
            /*En el caso de que el RUT termine en k, esta debe ser en mayúscula*/
            int rutTrabajador = 17096073;
            string rutTrabajadorDigito = "4";
            int rutEmpresa = 17096073;
            string rutEmpresaDigito = "4";
            int rutReceptor = 17096073;
            string rutReceptorDigito = "4";

            int tipoDte = 33;
            int folio = 5000;
            DateTime fechaEmision = DateTime.Now;
            int total = 15000;

            string error = string.Empty;

            var responseEstadoDTE = EstadoDTE.GetEstado
                (rutTrabajador, rutTrabajadorDigito, rutEmpresa, rutEmpresaDigito, rutReceptor, rutReceptorDigito,
                tipoDte, folio, fechaEmision, total, nombreCertificado, produccion, ".\\out\\tkn.dat", serialKEY, out error);

            return responseEstadoDTE;
        }

        #endregion  
    }
}
