using ChileSystems.DTE.Engine.RespuestaEnvio;
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
        //double neto = 0, netoExento = 0, iva = 0, total = 0;

        public string casoPruebas;
        public string idDte;
        public string rutEmpresa = "79628730-6";
        public string rutCertificado = "5750735-7";
        public string nombreCertificado = "ROELOF";
        public DateTime fechaEmision = new DateTime(2019, 2, 19);

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
            dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = fechaEmision;
            dte.Documento.Encabezado.IdentificacionDTE.Folio = Folio;
            //Para boletas electrónicas
            if(tipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
                dte.Documento.Encabezado.IdentificacionDTE.IndicadorServicio = ChileSystems.DTE.Engine.Enum.IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios;


            //DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            dte.Documento.Encabezado.Emisor.Rut = rutEmpresa;
            dte.Documento.Encabezado.Emisor.RazonSocial = "GONZALO BUSTAMANTE";
            dte.Documento.Encabezado.Emisor.Giro = "GIRO GIRO";
            dte.Documento.Encabezado.Emisor.DireccionOrigen = "DOMICILIO 787";
            dte.Documento.Encabezado.Emisor.ComunaOrigen = "ALTO HOSPICIO";
            //dte.Documento.Encabezado.Emisor.RazonSocialBoleta = "TRANSPORTE DISTRIBUCION Y COMERCIALIZACION DE PRODUCTOS D&V LIMITADA";
            //dte.Documento.Encabezado.Emisor.GiroBoleta = "VENTA AL POR MAYOR DE CONFITES";

            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(319010);
            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(521900);

            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Documento.Encabezado.Receptor.Rut = "66666666-6";
            dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente";
            dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente";
            dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente";

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
            calculosTotales(dte);
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
                if (det.Descuento != 0)
                {
                    detalle.Descuento = (int)Math.Round(det.Total * (det.Descuento / 100), 0); 
                    //detalle.DescuentoPorcentaje = det.Descuento;
                }

                detalle.MontoItem = det.Total - detalle.Descuento;
                dte.Documento.Detalles.Add(detalle);
                contador++;
            }
            calculosTotales(dte);
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
                FolioReferencia = Folio.ToString(),
                IndicadorGlobal = 0,
                Numero = c,
                RazonReferencia = casoPruebas,
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.SetPruebas
            });

            /*Ejemplo de referencia a una factura exenta*/
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
                EnsureExists((int)dte.Documento.Encabezado.IdentificacionDTE.TipoDTE, dte.Documento.Encabezado.IdentificacionDTE.Folio, pathCaf), 
                pathResult, 
                serialKEY, 
                out messageOut);

            /*El documento timbrado se guarda en la variable pathResult*/

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
            EnvioSII.SetDTE.Caratula.FechaResolucion = new DateTime(2018, 7, 13);
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

                    if (responseEnvio != null || string.IsNullOrEmpty(messageResult))
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
                //DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
                if (tipoDTE != ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
                {
                    dte.Documento.Encabezado.Totales.TasaIVA = Convert.ToDouble(19);
                    var neto = dte.Documento.Detalles
                        .Where(x => x.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet)
                        .Sum(x => x.MontoItem);

                    var exento = dte.Documento.Detalles
                        .Where(x => x.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento)
                        .Sum(x => x.MontoItem);

                    var descuentos = dte.Documento.DescuentosRecargos?
                        .Where(x => x.TipoMovimiento == ChileSystems.DTE.Engine.Enum.TipoMovimiento.TipoMovimientoEnum.Descuento
                        && x.TipoValor == ChileSystems.DTE.Engine.Enum.ExpresionDinero.ExpresionDineroEnum.Porcentaje)
                        .Sum(x => x.Valor);

                    if (descuentos.HasValue && descuentos.Value > 0)
                    {
                        var montoDescuentoAfecto = (int)Math.Round(neto * (descuentos.Value / 100), 0, MidpointRounding.AwayFromZero);
                        neto -= montoDescuentoAfecto;

                        //var montoDescuentoExento = exento * (descuentos / 100);
                        //exento -= (int)Math.Round(montoDescuentoExento.Value, 0);
                    }
                    var iva = (int)Math.Round(neto * 0.19, 0);

                    dte.Documento.Encabezado.Totales.MontoNeto = neto;
                    dte.Documento.Encabezado.Totales.MontoExento = exento;
                    dte.Documento.Encabezado.Totales.IVA = iva;
                    dte.Documento.Encabezado.Totales.MontoTotal = neto + exento + iva;
                }
                else
                {
                    var totalBrutoAfecto = dte.Documento.Detalles
                        .Where(x => x.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet)
                        .Sum(x => x.MontoItem);

                    var totalExento = dte.Documento.Detalles
                        .Where(x => x.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento)
                        .Sum(x => x.MontoItem);

                    /*En las boletas, sólo es necesario informar el monto total*/
                    var neto = (int)Math.Round(totalBrutoAfecto / 1.19, 0, MidpointRounding.AwayFromZero);
                    var iva = (int)Math.Round(dte.Documento.Encabezado.Totales.MontoNeto * 0.19, 0, MidpointRounding.AwayFromZero);
                    dte.Documento.Encabezado.Totales.MontoTotal = neto + totalExento + iva;
                }
            }
                    
            catch {  }
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

        public ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta GenerateLibroVentas(ChileSystems.DTE.Engine.Envio.EnvioDTE envioAux)
        {
            var libro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta();
            libro.EnvioLibro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro();
            libro.EnvioLibro.Id = "ID_LIBRO7";

            /*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
             * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula()
            {
                RutEmisor = rutEmpresa,
                RutEnvia = rutCertificado,
                PeriodoTributario = fechaEmision.Year + "-0" + fechaEmision.Month,
                FechaResolucion = new DateTime(2018, 7, 13),
                NumeroResolucion = 0,
                TipoOperacion = ChileSystems.DTE.Engine.Enum.TipoOperacionLibro.TipoOperacionLibroEnum.Venta,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total,
                FolioNotificacion = 200,
                //Para cuando es SET de pruebas, siempre es 1,,                
               
            };

            libro.EnvioLibro.ResumenPeriodo = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo();
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo>();

            /**************TOTALES PARA LAS FACTURAS******************/
            int cantidadDocumentosFacturas = envioAux.SetDTE.DTEs.
                Count(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica);

            int totalExento = envioAux.SetDTE.DTEs.
                Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica)
                .Sum(x => x.Documento.Encabezado.Totales.MontoExento);

            int totalNeto = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.MontoNeto);

            int totalIVA = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.IVA);

            int totalTotal = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.MontoTotal);

            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                CantidadDocumentos = cantidadDocumentosFacturas,
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = totalExento,
                TotalMontoNeto = totalNeto,
                TotalMontoIva = totalIVA,
                TotalMonto = totalTotal
            });
            /**************************************************/

            /***************TOTALES PARA LAS NC*****************/
            int cantidadDocumentosNC = envioAux.SetDTE.DTEs.
                Count(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica);

            int totalExentoNC = envioAux.SetDTE.DTEs.
                Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
                .Sum(x => x.Documento.Encabezado.Totales.MontoExento);

            int totalNetoNC = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.MontoNeto);

            int totalIVANC = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.IVA);

            int totalTotalNC = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.MontoTotal);

            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaCreditoElectronica,
                CantidadDocumentos = cantidadDocumentosNC,
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = totalExentoNC,
                TotalMontoNeto = totalNetoNC,
                TotalMontoIva = totalIVANC,
                TotalMonto = totalTotalNC
            });
            /**************************************************/

            /********************TOTALES PARA ND***************/
            int cantidadDocumentosND = envioAux.SetDTE.DTEs.
                Count(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica);

            int totalExentoND = envioAux.SetDTE.DTEs.
                Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
                .Sum(x => x.Documento.Encabezado.Totales.MontoExento);

            int totalNetoND = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.MontoNeto);

            int totalIVAND = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.IVA);

            int totalTotalND = envioAux.SetDTE.DTEs.
               Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
               .Sum(x => x.Documento.Encabezado.Totales.MontoTotal);

            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaDebitoElectronica,
                CantidadDocumentos = cantidadDocumentosND,
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = totalExentoND,
                TotalMontoNeto = totalNetoND,
                TotalMontoIva = totalIVAND,
                TotalMonto = totalTotalND
            });
            /**************************************************/
            libro.EnvioLibro.Detalles = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle>();
            foreach (var dteAux in envioAux.SetDTE.DTEs)
            {
                ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotSet;

                if (dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica)
                    tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica;

                else if (dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
                    tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaCreditoElectronica;

                else if (dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
                    tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaDebitoElectronica;

                libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
                {
                    TipoDocumento = tipoDocumento,
                    NumeroDocumento = dteAux.Documento.Encabezado.IdentificacionDTE.Folio,
                    IndicadorAnulado = ChileSystems.DTE.Engine.Enum.IndicadorAnulado.IndicadorAnuladoEnum.NotSet,
                    TasaImpuestoOperacion = 0.19,
                    FechaDocumento = dteAux.Documento.Encabezado.IdentificacionDTE.FechaEmision,
                    RutDocumento = dteAux.Documento.Encabezado.Receptor.Rut,
                    RazonSocial = dteAux.Documento.Encabezado.Receptor.RazonSocial,
                    MontoExento = dteAux.Documento.Encabezado.Totales.MontoExento,
                    MontoNeto = dteAux.Documento.Encabezado.Totales.MontoNeto,
                    MontoIva = dteAux.Documento.Encabezado.Totales.IVA,
                    MontoTotal = dteAux.Documento.Encabezado.Totales.MontoTotal
                });
            }

            return libro;
        }

        public ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta GenerateLibroCompras()
        {
            var libro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta();
            libro.EnvioLibro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro();
            libro.EnvioLibro.Id = "ID_LIBRO6";

            /*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
             * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula()
            {
                RutEmisor = rutEmpresa,
                RutEnvia = rutCertificado,
                PeriodoTributario = fechaEmision.Year + "-0" + fechaEmision.Month,
                FechaResolucion = new DateTime(2018, 7, 13),
                NumeroResolucion = 0,
                TipoOperacion = ChileSystems.DTE.Engine.Enum.TipoOperacionLibro.TipoOperacionLibroEnum.Compra,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total,
                FolioNotificacion = 200, //Para cuando es SET de pruebas, siempre es 1
                //CodigoAutorizacionRectificacionLibro = "1NLKZLFX4S"

            };

            libro.EnvioLibro.Detalles = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle>();

            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual,
                NumeroDocumento = 234,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = 64134,
                MontoIva = 12185,
                MontoTotal = 76319
            });
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                NumeroDocumento = 32,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 11242,
                MontoNeto = 13157,
                MontoIva = 2500,
                MontoTotal = 26899,
                IVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle>()
                {
                }
            });
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual,
                NumeroDocumento = 781,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = 30302,
                //MontoIva = 5681,
                IVAUsoComun = 5757, //Neto * 0.19 
                MontoTotal = 36059,
                TipoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoResumido.Iva

            });
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaCredito,
                NumeroDocumento = 451,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = 2999,
                MontoIva = 570,
                MontoTotal = 3569,
                TipoDocumentoReferencia = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual,
                FolioDocumentoReferencia = 234
            });
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                NumeroDocumento = 67,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = 12853,
                MontoTotal = 15295,
                IVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle()
                    {
                        CodigoIVANoRecuperable = ChileSystems.DTE.Engine.Enum.CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.EntregaGratuita,
                        TotalMontoIVANoRecuperable = 2442
                    }
                }
            });
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaCompraElectronica,
                NumeroDocumento = 9,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = 10992,
                MontoIva = 2088,
                MontoTotal = 10992,
                IVARetenidoTotal = 2088,
                Impuestos = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle()
                    {
                        CodigoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal,
                        TotalMontoImpuesto = 2088,
                        TasaImpuesto = 19
                    }
                }
            });
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaCredito,
                NumeroDocumento = 211,
                TasaImpuestoOperacion = 19,
                FechaDocumento = fechaEmision,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = 10615,
                MontoIva = 2017,
                MontoTotal = 12632,
                TipoDocumentoReferencia = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                FolioDocumentoReferencia = 32
            });




            libro.EnvioLibro.ResumenPeriodo = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo();
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo>();

            var manuales = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual);
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual,
                CantidadDocumentos = manuales.Count(),
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = manuales.Sum(x=>x.MontoExento),
                TotalMontoNeto = manuales.Sum(x => x.MontoNeto),
                TotalMontoIva = manuales.Sum(x => x.MontoIva),
                TotalIVAUsoComun = manuales.Sum(x => x.IVAUsoComun),
                TotalMonto = manuales.Sum(x => x.MontoTotal),
                FactorProporcionalidadIVA = 0.6,
                TotalCreditoIVAUsoComun = (int)Math.Round(manuales.Sum(x => x.IVAUsoComun) * 0.6, 0, MidpointRounding.AwayFromZero),
                CantidadOperacionesConIvaUsoComun = 1
            });

            var electronicas = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica);
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                CantidadDocumentos = electronicas.Count(),
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = electronicas.Sum(x=>x.MontoExento),
                TotalMontoNeto = electronicas.Sum(x => x.MontoNeto),
                TotalMontoIva = electronicas.Sum(x => x.MontoIva),
                TotalIVAUsoComun = electronicas.Sum(x => x.IVAUsoComun),
                TotalMonto = electronicas.Sum(x => x.MontoTotal),
                TotalIVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable()
                    {
                        CantidadOperacionesIVANoRecuperable = 1,
                        CodigoIVANoRecuperable = ChileSystems.DTE.Engine.Enum.CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.EntregaGratuita,
                        TotalMontoIVANoRecuperable = electronicas.Sum(x=>x.IVANoRecuperable.Sum(y=>y.TotalMontoIVANoRecuperable))
                    }
                }
            });

            var nc = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaCredito);
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.NotaCredito,
                CantidadDocumentos = nc.Count(),
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = nc.Sum(x => x.MontoExento),
                TotalMontoNeto = nc.Sum(x => x.MontoNeto),
                TotalMontoIva = nc.Sum(x => x.MontoIva),
                TotalMonto = nc.Sum(x => x.MontoTotal),
            });

            var fce = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaCompraElectronica);
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaCompraElectronica,
                CantidadDocumentos = fce.Count(),
                CantidadDocumentosAnulados = 0,
                TotalMontoExento = fce.Sum(x => x.MontoExento),
                TotalMontoNeto = fce.Sum(x => x.MontoNeto),
                TotalMontoIva = fce.Sum(x => x.MontoIva),
                TotalMonto = fce.Sum(x => x.MontoTotal),
                TotalIVARetenidoTotal = fce.Sum(x => x.IVARetenidoTotal),
                Impuestos = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosPeriodo>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosPeriodo()
                    {
                        CodigoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal,
                        TotalMontoImpuesto = fce.Sum(x=>x.IVARetenidoTotal)
                    }
                }
            });
            /**************************************************/

            /**************************************************/
           
            return libro;
        }

        #endregion  



        #region Utilidades

        public ChileSystems.DTE.Engine.Documento.DTE GenerateRandomDTE(int folio, ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipo)
        {
            // DOCUMENTO
            Random r = new Random();
            var dte = new ChileSystems.DTE.Engine.Documento.DTE();
            dte.Documento.Id = "TEST" + folio.ToString();
            dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipo;
            dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now;
            dte.Documento.Encabezado.IdentificacionDTE.Folio = folio;

            //DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            dte.Documento.Encabezado.Emisor.Rut = rutEmpresa;
            dte.Documento.Encabezado.Emisor.RazonSocial = "MERA VENNIK LIMITADA";
            dte.Documento.Encabezado.Emisor.Giro = "VENTA AL POR MENOR DE OTROS PRODUCTOS EN PEQUENOS ALMACENES NO ESPECIA";
            dte.Documento.Encabezado.Emisor.DireccionOrigen = "COLON 1148";
            dte.Documento.Encabezado.Emisor.ComunaOrigen = "TALCAHUANO";

            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(319010);
            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(521900);

            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Documento.Encabezado.Receptor.Rut = "66666666-6";
            dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente";
            dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente";
            dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente";

            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(512250);
            dte.Documento.Encabezado.Emisor.ActividadEconomica.Add(519000);

            if (tipo == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
            {
                dte.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
                dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
                {
                    CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
                    FechaDocumentoReferencia = DateTime.Now,
                    FolioReferencia = "213",
                    IndicadorGlobal = 0,
                    Numero = 1,
                    RazonReferencia = "ANULA FACTURA",
                    TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
                });
            }
            else if (tipo == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
            {
                dte.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
                dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
                {
                    CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                    FechaDocumentoReferencia = DateTime.Now,
                    FolioReferencia = "214",
                    IndicadorGlobal = 0,
                    Numero = 1,
                    RazonReferencia = "CORRIGE MONTOS",
                    TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
                });
            }

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
                //detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;
                detalle.Nombre = detallesRandom[r.Next(0, detallesRandom.Count - 1)];
                detalle.Cantidad = r.Next(1, 5);
                detalle.Precio = r.Next(1, 150000);
                detalle.MontoItem = (int)detalle.Cantidad * (int)detalle.Precio;
                dte.Documento.Detalles.Add(detalle);
            }
            calculosTotales(dte);
            return dte;
        }

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



        public string GenerarRespuestaEnvio(List<ChileSystems.DTE.Engine.Documento.DTE> dtes, string estadoDTE)
        {
            RespuestaDTE response = new RespuestaDTE();
            response.Resultado = new Resultado();
            var result = response.Resultado;

            result.Id = "R_ENVIO1";
            result.Caratula = new ChileSystems.DTE.Engine.RespuestaEnvio.Caratula();
            result.Caratula.Fecha = DateTime.Now;
            result.Caratula.IdRespuesta = 1;
            result.Caratula.MailContacto = "mailcontacto@mail.com";
            result.Caratula.NombreContacto = "Contacto";
            result.Caratula.RutResponde = rutEmpresa;

            result.Caratula.NumeroDetalles = 1;
            result.Caratula.RutRecibe = "88888888-8";

            result.RecepcionEnvio = new List<RecepcionEnvio>();
            var recepcionEnvio = new RecepcionEnvio();

            recepcionEnvio.CodigoEnvio = 4545;
            //recepcionEnvio.Digest = SIMPLE_SDK.Security.Firma.Firma.GetDigestValueFromFile(dte.DTEfilepath);
            recepcionEnvio.EnvioDTEId = "SetDoc";
            recepcionEnvio.FechaRecepcion = DateTime.Now;
            recepcionEnvio.NumeroDTE = 2;
            recepcionEnvio.RutEmisor = result.Caratula.RutRecibe;
            recepcionEnvio.RutReceptor = result.Caratula.RutResponde;
            recepcionEnvio.EstadoRecepcionEnvio = ChileSystems.DTE.Engine.Enum.EstadoEnvioEmpresa.EstadoEnvioEmpresaEnum.OK;
            recepcionEnvio.GlosaEstadoRecepcionEnvio = "ENVIO OK";
            recepcionEnvio.NombreArchivoEnvio = "ENVIO_DTE_1072427";
            recepcionEnvio.RecepcionDTE = new List<RecepcionDTE>();

            //foreach (var dte in dtes)
            //{
            //    var recepcionDTE = new RecepcionDTE();
            //    recepcionDTE.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision;
            //    recepcionDTE.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio;
            //    recepcionDTE.MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal;
            //    recepcionDTE.RutEmisor = dte.Documento.Encabezado.Emisor.Rut;
            //    recepcionDTE.RutReceptor = dte.Documento.Encabezado.Receptor.Rut;
            //    recepcionDTE.TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE;
            //    recepcionDTE.EstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.EstadoRecepcionDTEEnum.Ok;
            //    recepcionDTE.GlosaEstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.Glosa(recepcionDTE.EstadoRecepcionDTE);
            //    recepcionEnvio.RecepcionDTE.Add(recepcionDTE);
            //}

            var recepcionDTE = new RecepcionDTE();
            var dte = dtes[0];
            recepcionDTE.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision;
            recepcionDTE.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio;
            recepcionDTE.MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal;
            recepcionDTE.RutEmisor = dte.Documento.Encabezado.Emisor.Rut;
            recepcionDTE.RutReceptor = dte.Documento.Encabezado.Receptor.Rut;
            recepcionDTE.TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE;
            recepcionDTE.EstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.EstadoRecepcionDTEEnum.Ok;
            recepcionDTE.GlosaEstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.Glosa(recepcionDTE.EstadoRecepcionDTE);
            recepcionEnvio.RecepcionDTE.Add(recepcionDTE);

            var dte2 = dtes[1];
            recepcionDTE = new RecepcionDTE();
            recepcionDTE.FechaEmision = dte2.Documento.Encabezado.IdentificacionDTE.FechaEmision;
            recepcionDTE.Folio = dte2.Documento.Encabezado.IdentificacionDTE.Folio;
            recepcionDTE.MontoTotal = dte2.Documento.Encabezado.Totales.MontoTotal;
            recepcionDTE.RutEmisor = dte2.Documento.Encabezado.Emisor.Rut;
            recepcionDTE.RutReceptor = dte2.Documento.Encabezado.Receptor.Rut;
            recepcionDTE.TipoDTE = dte2.Documento.Encabezado.IdentificacionDTE.TipoDTE;
            recepcionDTE.EstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.EstadoRecepcionDTEEnum.ErrorRutReceptor;
            recepcionDTE.GlosaEstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.Glosa(recepcionDTE.EstadoRecepcionDTE);
            recepcionEnvio.RecepcionDTE.Add(recepcionDTE);


            result.RecepcionEnvio.Add(recepcionEnvio);

            var filepath = response.Firmar(nombreCertificado);

            return filepath;
        }


        public string ResponderIntercambio(int estado, ChileSystems.DTE.Engine.Documento.DTE dte, string motivo)
        {
            try
            {
                RespuestaDTE response = new RespuestaDTE();
                response.Resultado = new Resultado();

                var result = response.Resultado;

                result.Id = "R_001";
                result.Caratula = new ChileSystems.DTE.Engine.RespuestaEnvio.Caratula();
                result.Caratula.Fecha = DateTime.Now;
                result.Caratula.IdRespuesta = 1;
                result.Caratula.MailContacto = "test@test.cl";
                result.Caratula.NombreContacto = "Nombre Contacto";
                result.Caratula.RutResponde = rutEmpresa;

                result.Caratula.NumeroDetalles = 1;
                result.Caratula.RutRecibe = "88888888-8";

                result.ResultadoDTE = new List<ResultadoDTE>();
                var resultadoDTE = new ResultadoDTE();

                resultadoDTE.CodigoEnvio = 1;

                resultadoDTE.CodigoRechazoODiscrepancia = -1;//(int)estado;
                resultadoDTE.EstadoDTE = (ChileSystems.DTE.Engine.Enum.EstadoResultadoDTE.EstadoResultadoDTEEnum)estado;
                resultadoDTE.GlosaEstadoDTE = string.IsNullOrEmpty(motivo) ? resultadoDTE.EstadoDTE.ToString() : motivo;

                resultadoDTE.RutEmisor = "88888888-8";
                resultadoDTE.RutReceptor = rutEmpresa;
                resultadoDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica;
                resultadoDTE.Folio = 52576;
                resultadoDTE.FechaEmision = new DateTime(2019, 2, 19);
                resultadoDTE.MontoTotal = 18635;

                result.ResultadoDTE.Add(resultadoDTE);

                string resultFilePath = response.Firmar(nombreCertificado);
                return resultFilePath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ResponderDTE(int estado, ChileSystems.DTE.Engine.Documento.DTE dte, string motivo)
        {
            try
            {
                RespuestaDTE response = new RespuestaDTE();
                response.Resultado = new Resultado();

                var result = response.Resultado;

                result.Id = "R_001";
                result.Caratula = new ChileSystems.DTE.Engine.RespuestaEnvio.Caratula();
                result.Caratula.Fecha = DateTime.Now;
                result.Caratula.IdRespuesta = 1;
                result.Caratula.MailContacto = "test@test.cl";
                result.Caratula.NombreContacto = "Nombre Contacto";
                result.Caratula.RutResponde = rutEmpresa;

                result.Caratula.NumeroDetalles = 1;
                result.Caratula.RutRecibe = "88888888-8";

                result.ResultadoDTE = new List<ResultadoDTE>();
                var resultadoDTE = new ResultadoDTE();

                resultadoDTE.CodigoEnvio = 1;

                resultadoDTE.CodigoRechazoODiscrepancia = -1;//(int)estado;
                resultadoDTE.EstadoDTE = (ChileSystems.DTE.Engine.Enum.EstadoResultadoDTE.EstadoResultadoDTEEnum)estado;
                resultadoDTE.GlosaEstadoDTE = string.IsNullOrEmpty(motivo) ? resultadoDTE.EstadoDTE.ToString() : motivo;

                resultadoDTE.RutEmisor = "88888888-8"; 
                resultadoDTE.RutReceptor = rutEmpresa;
                resultadoDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica;
                resultadoDTE.Folio = 52455;
                resultadoDTE.FechaEmision = new DateTime(2019, 2, 19);
                resultadoDTE.MontoTotal = 11842;

                result.ResultadoDTE.Add(resultadoDTE);

                string resultFilePath = response.Firmar(nombreCertificado);
                return resultFilePath;
            }
            catch (Exception ex)
            {                
                return ex.Message;
            }
        }

        public string AcuseReciboMercaderias(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            try
            {
                ChileSystems.DTE.Engine.ReciboMercaderia.EnvioRecibos envio = new ChileSystems.DTE.Engine.ReciboMercaderia.EnvioRecibos();
                envio.SetRecibos = new ChileSystems.DTE.Engine.ReciboMercaderia.SetRecibos()
                {
                    Id = "EARM00",
                    Caratula = new ChileSystems.DTE.Engine.ReciboMercaderia.Caratula()
                    {
                        RutRecibe = "88888888-8",
                        RutResponde = rutEmpresa,
                        NombreContacto = "Nombre Contacto"
                    }
                };

                envio.SetRecibos.Recibos = new List<ChileSystems.DTE.Engine.ReciboMercaderia.Recibo>()
                {
                    new ChileSystems.DTE.Engine.ReciboMercaderia.Recibo()
                    {
                         DocumentoRecibo = new ChileSystems.DTE.Engine.ReciboMercaderia.DocumentoRecibo()
                         {
                            Id = "R01",
                            RutEmisor = "88888888-8",
                            RutReceptor = rutEmpresa,
                            FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision,
                            Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio,
                            MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
                            TipoDocumento = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE,
                            Recinto = "Recinto",
                            RutFirma = rutCertificado
                         }
                    }
                };

                int id = -1;
                var recibo = envio.SetRecibos.Recibos.First();
                envio.SetRecibos.Id = "EARM" + id;
                recibo.DocumentoRecibo.Id = "RM" + id;

                envio.SetRecibos.signedXmls.Add(recibo.Firmar(nombreCertificado));
                string filePath = envio.Firmar(nombreCertificado);
                return filePath;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion  

    }
}
