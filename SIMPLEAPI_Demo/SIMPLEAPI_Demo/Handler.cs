using ChileSystems.DTE.Engine.RespuestaEnvio;
using ChileSystems.DTE.WS.EstadoDTE;
using SIMPLEAPI_Demo.Clases;
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

        public string casoPruebas;
        public string idDte;

        public ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica;

        public Configuracion configuracion;

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
            dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipoDTE;
            dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now;
            dte.Documento.Encabezado.IdentificacionDTE.Folio = Folio;

            //DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            dte.Documento.Encabezado.Emisor.Rut = configuracion.Empresa.RutEmpresa;
            dte.Documento.Encabezado.Emisor.DireccionOrigen = configuracion.Empresa.Direccion;
            dte.Documento.Encabezado.Emisor.ComunaOrigen = configuracion.Empresa.Comuna;
            dte.Documento.Encabezado.Emisor.ActividadEconomica = configuracion.Empresa.CodigosActividades.Select(x => x.Codigo).ToList();

            //Para boletas electrónicas
            if (tipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
            {
                dte.Documento.Encabezado.IdentificacionDTE.IndicadorServicio = ChileSystems.DTE.Engine.Enum.IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios;
                dte.Documento.Encabezado.Emisor.RazonSocialBoleta = configuracion.Empresa.RazonSocial;
                dte.Documento.Encabezado.Emisor.GiroBoleta = configuracion.Empresa.Giro;
            }
            else
            {
                dte.Documento.Encabezado.Emisor.RazonSocial = configuracion.Empresa.RazonSocial; 
                dte.Documento.Encabezado.Emisor.Giro = configuracion.Empresa.Giro;
            }

            if (tipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica)
            {
                dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta;
                dte.Documento.Encabezado.IdentificacionDTE.TipoDespacho = ChileSystems.DTE.Engine.Enum.TipoDespacho.TipoDespachoEnum.EmisorACliente;
            }
            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Documento.Encabezado.Receptor.Rut = "66666666-6";
            dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente";
            dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente";
            dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente";

            return dte;
        }

        public ChileSystems.DTE.Engine.Documento.DTE GenerateDTEExportacionBase()
        {
            // DOCUMENTO
            var dte = new ChileSystems.DTE.Engine.Documento.DTE();
            dte.Exportaciones = new SIMPLE_API.Documento.Exportaciones();
            dte.Exportaciones.Id = idDte;

            dte.Exportaciones.Encabezado.IdentificacionDTE.TipoDTE = tipoDTE;
            dte.Exportaciones.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now;
            dte.Exportaciones.Encabezado.IdentificacionDTE.Folio = Folio;
            
            dte.Exportaciones.Encabezado.Emisor.Rut = configuracion.Empresa.RutEmpresa;
            dte.Exportaciones.Encabezado.Emisor.RazonSocial = configuracion.Empresa.RazonSocial;
            dte.Exportaciones.Encabezado.Emisor.Giro = configuracion.Empresa.Giro;
            dte.Exportaciones.Encabezado.Emisor.DireccionOrigen = configuracion.Empresa.Direccion;
            dte.Exportaciones.Encabezado.Emisor.ComunaOrigen = configuracion.Empresa.Comuna;
            dte.Exportaciones.Encabezado.Emisor.ActividadEconomica = configuracion.Empresa.CodigosActividades.Select(x => x.Codigo).ToList();

            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Exportaciones.Encabezado.Receptor.Rut = "55555555-5";
            dte.Exportaciones.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Exportaciones.Encabezado.Receptor.Direccion = "Dirección de cliente";
            dte.Exportaciones.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Exportaciones.Encabezado.Receptor.Ciudad = "Ciudad de cliente";
            dte.Exportaciones.Encabezado.Receptor.Giro = "Giro de cliente";

            dte.Exportaciones.Encabezado.Transporte = new ChileSystems.DTE.Engine.Documento.Transporte();
            dte.Exportaciones.Encabezado.Transporte.Aduana = new ChileSystems.DTE.Engine.Documento.Aduana();           

         

            return dte;
        }

        public void CalculateTotalesExportacion(ChileSystems.DTE.Engine.Documento.DTE dte, double adicional = 0)
        {
            int total = (int)Math.Round(dte.Exportaciones.Detalles.Sum(x => x.MontoItem) + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro + adicional, 0);
            //int total = (int)Math.Round((decimal)dte.Exportaciones.Detalles.Sum(x => x.MontoItem), 0);

            dte.Exportaciones.Encabezado.Totales.MontoExento = total;
            dte.Exportaciones.Encabezado.Totales.MontoTotal = total;

            try {
                int totalOtraMoneda = (int)Math.Round((dte.Exportaciones.Detalles.Sum(x => x.MontoItem) + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro + adicional) * dte.Exportaciones.Encabezado.OtraMoneda.TipoCambio, 0);
                //int totalOtraMoneda = (int)Math.Round(dte.Exportaciones.Detalles.Sum(x => x.MontoItem) * dte.Exportaciones.Encabezado.OtraMoneda.TipoCambio, 0);
                dte.Exportaciones.Encabezado.OtraMoneda.MontoExento = totalOtraMoneda;
                dte.Exportaciones.Encabezado.OtraMoneda.MontoTotal = totalOtraMoneda;
            }
            catch { }
           
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

        public void GenerateDetailsExportacion(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            dte.Exportaciones.Detalles = new List<ChileSystems.DTE.Engine.Documento.DetalleExportacion>();
            var detalle = new ChileSystems.DTE.Engine.Documento.DetalleExportacion();
            detalle.NumeroLinea = 1;
            detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;
            detalle.Nombre = "CHATARRA DE ALUMINIO";
            detalle.Cantidad = 148;
            detalle.UnidadMedida = "U";
            detalle.Precio = 105;
            detalle.MontoItem = 148 * 105;
            dte.Exportaciones.Detalles.Add(detalle);

            CalculateTotalesExportacion(dte);
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

                if (det.TipoImpuesto != ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.NotSet)
                {
                    detalle.CodigoImpuestoAdicional = new List<ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum>();
                    detalle.CodigoImpuestoAdicional.Add(det.TipoImpuesto);
                }
                
                dte.Documento.Detalles.Add(detalle);
                contador++;
            }
            calculosTotales(dte);
        }

        private void calculosTotales(ChileSystems.DTE.Engine.Documento.DTE dte)
        {
            try
            {
                //DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
                if (dte.Documento.Encabezado.IdentificacionDTE.TipoDTE != ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
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
                    }
                    var iva = (int)Math.Round(neto * 0.19, 0);
                    int retenido = 0;

                    if (dte.Documento.Detalles.Any(x => x.CodigoImpuestoAdicional !=null))
                    {
                        retenido = (int)Math.Round(
                            dte.Documento.Detalles
                            .Where(x=>x.CodigoImpuestoAdicional.First() == ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal)
                            .Sum(x => x.MontoItem) * 0.19, 0);

                        if (retenido != 0)
                        {
                            dte.Documento.Encabezado.Totales.ImpuestosRetenciones = new List<ChileSystems.DTE.Engine.Documento.ImpuestosRetenciones>();
                            dte.Documento.Encabezado.Totales.ImpuestosRetenciones.Add(new ChileSystems.DTE.Engine.Documento.ImpuestosRetenciones()
                            {
                                MontoImpuesto = retenido,
                                TasaImpuesto = 19,
                                TipoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
                            });
                        }                       
                    }

                    dte.Documento.Encabezado.Totales.MontoNeto = neto;
                    dte.Documento.Encabezado.Totales.MontoExento = exento;
                    dte.Documento.Encabezado.Totales.IVA = iva;
                    dte.Documento.Encabezado.Totales.MontoTotal = neto + exento + iva - retenido;
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
                    var iva = (int)Math.Round(neto * 0.19, 0, MidpointRounding.AwayFromZero);
                    dte.Documento.Encabezado.Totales.MontoTotal = neto + totalExento + iva;
                }
            }

            catch { }
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
            c++;
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
                configuracion.APIKey, 
                out messageOut);

            /*El documento timbrado se guarda en la variable pathResult*/

            /*Finalmente, el documento timbrado debe firmarse con el certificado digital*/
            /*Se debe entregar en el argumento del método Firmar, el "FriendlyName" o Nombre descriptivo del certificado*/
            /*Retorna el filePath donde estará el archivo XML timbrado y firmado, listo para ser enviado al SII*/
            return dte.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey, out messageOut, "out\\temp\\", "");
        }

        public string TimbrarYFirmarXMLDTEExportacion(ChileSystems.DTE.Engine.Documento.DTE dte, string pathResult, string pathCaf)
        {
            
            /*En primer lugar, el documento debe timbrarse con el CAF que descargas desde el SII, es simular
             * cuando antes debías ir con las facturas en papel para que te las timbraran */
            string messageOut = string.Empty;
            dte.Exportaciones.Timbrar(
                EnsureExists((int)dte.Exportaciones.Encabezado.IdentificacionDTE.TipoDTE, dte.Exportaciones.Encabezado.IdentificacionDTE.Folio, pathCaf),
                configuracion.APIKey,
                out messageOut);

            /*El documento timbrado se guarda en la variable pathResult*/

            /*Finalmente, el documento timbrado debe firmarse con el certificado digital*/
            /*Se debe entregar en el argumento del método Firmar, el "FriendlyName" o Nombre descriptivo del certificado*/
            /*Retorna el filePath donde estará el archivo XML timbrado y firmado, listo para ser enviado al SII*/
            return dte.FirmarExportacion(configuracion.Certificado.Nombre, configuracion.APIKey, out messageOut, "out\\temp\\");
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

        public bool Validate(string filePath, SIMPLE_API.Security.Firma.Firma.TipoXML tipo, string schema)
        {
            string messageResult = string.Empty;
            if (ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(filePath, out messageResult, schema))
                if (SIMPLE_API.Security.Firma.Firma.VerificarFirma(filePath, tipo, out string messageOutFirma))
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
            EnvioSII.SetDTE.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion;
            EnvioSII.SetDTE.Caratula.NumeroResolucion = configuracion.Empresa.NumeroResolucion;

            EnvioSII.SetDTE.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa;
            EnvioSII.SetDTE.Caratula.RutEnvia = configuracion.Certificado.Rut;
            EnvioSII.SetDTE.Caratula.RutReceptor = "60803000-K"; //Este es el RUT del SII
            EnvioSII.SetDTE.Caratula.SubTotalesDTE = new List<ChileSystems.DTE.Engine.Envio.SubTotalesDTE>();

            /*En la carátula del envío, se debe indicar cuantos documentos de cada tipo se están enviando*/
            
            if (EnvioSII.SetDTE.DTEs.Any(x=> !string.IsNullOrEmpty(x.Documento.Id)))
            {
                var tipos = EnvioSII.SetDTE.DTEs.GroupBy(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE);
                foreach (var a in tipos)
                {
                    EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(new ChileSystems.DTE.Engine.Envio.SubTotalesDTE()
                    {
                        Cantidad = a.Count(),
                        TipoDTE = a.ElementAt(0).Documento.Encabezado.IdentificacionDTE.TipoDTE
                    });
                }
            }
            else if (EnvioSII.SetDTE.DTEs.Any(x => !string.IsNullOrEmpty(x.Exportaciones.Id)))
            {
                var tipos = EnvioSII.SetDTE.DTEs.GroupBy(x => x.Exportaciones.Encabezado.IdentificacionDTE.TipoDTE);
                foreach (var a in tipos)
                {
                    EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(new ChileSystems.DTE.Engine.Envio.SubTotalesDTE()
                    {
                        Cantidad = a.Count(),
                        TipoDTE = a.ElementAt(0).Exportaciones.Encabezado.IdentificacionDTE.TipoDTE
                    });
                }
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
            EnvioCustomer.SetDTE.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion;
            EnvioCustomer.SetDTE.Caratula.NumeroResolucion = configuracion.Empresa.NumeroResolucion;

            EnvioCustomer.SetDTE.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa;
            EnvioCustomer.SetDTE.Caratula.RutEnvia = configuracion.Certificado.Rut;
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

        public long EnviarEnvioDTEToSII(string filePathEnvio, bool produccion)
        {
            string messageResult = string.Empty;
            long trackID = -1;
            int i;
            try
            {
                for (i = 1; i <= 5; i++)
                {
                    string rutEmisorNumero = configuracion.Empresa.RutEmpresa.Substring(0, configuracion.Empresa.RutEmpresa.Length - 2);
                    string rutEmisorDigito = configuracion.Empresa.RutEmpresa.Substring(configuracion.Empresa.RutEmpresa.Length - 1);
                    string rutEmpresaNumero = configuracion.Empresa.RutEmpresa.Substring(0, configuracion.Empresa.RutEmpresa.Length - 2);
                    string rutEmpresaDigito = configuracion.Empresa.RutEmpresa.Substring(configuracion.Empresa.RutEmpresa.Length - 1);
                    var responseEnvio = ChileSystems.DTE.WS.EnvioDTE.EnvioDTE.Enviar(rutEmisorNumero, rutEmisorDigito, rutEmpresaNumero, rutEmpresaDigito, filePathEnvio, filePathEnvio, configuracion.Certificado.Nombre, produccion, configuracion.APIKey, out messageResult, ".\\out\\tkn.dat");

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
            EnvioSII.SetDTE.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion;
            EnvioSII.SetDTE.Caratula.NumeroResolucion = configuracion.Empresa.NumeroResolucion;

            EnvioSII.SetDTE.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa;
            EnvioSII.SetDTE.Caratula.RutEnvia = configuracion.Certificado.Rut;
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
            rcof.DocumentoConsumoFolios.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion;
            rcof.DocumentoConsumoFolios.Caratula.NroResol = configuracion.Empresa.NumeroResolucion;
            rcof.DocumentoConsumoFolios.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa;
            rcof.DocumentoConsumoFolios.Caratula.RutEnvia = configuracion.Certificado.Rut;
            rcof.DocumentoConsumoFolios.Caratula.SecEnvio = "1";
            rcof.DocumentoConsumoFolios.Caratula.FechaEnvio = DateTime.Now;
            List<ChileSystems.DTE.Engine.RCOF.Resumen> resumenes = new List<ChileSystems.DTE.Engine.RCOF.Resumen>();

            /*datos de boletas electrónicas afectas*/
            /* Estos datos se deben calcular, debido a que no se informa IVA en boletas electrónicas 
             */
            int totalBrutoAfecto = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
                        .Sum(x => x.Documento.Detalles
                        .Where(y => y.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet)
                        .Sum(y => y.MontoItem));

            int totalExento = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica)
                    .Sum(x => x.Documento.Detalles
                    .Where(y => y.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento)
                    .Sum(y => y.MontoItem));

            int totalNeto = (int)Math.Round(totalBrutoAfecto / 1.19, 0, MidpointRounding.AwayFromZero);
            int totalIVA = (int)Math.Round(totalNeto * 0.19, 0, MidpointRounding.AwayFromZero);
            int totalTotal = totalExento + totalNeto + totalIVA;

            int rangoInicial = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Min(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            int rangoFinal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Max(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            resumenes.Add(new ChileSystems.DTE.Engine.RCOF.Resumen
            {
                FoliosAnulados = 0,
                FoliosEmitidos = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Count(),
                FoliosUtilizados = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica).Count(),
                MntExento = totalExento,
                MntIva = totalIVA,
                MntNeto = totalNeto,
                MntTotal = totalTotal,
                TasaIVA = 19,
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica,
                RangoUtilizados = new List<ChileSystems.DTE.Engine.RCOF.RangoUtilizados>() { new ChileSystems.DTE.Engine.RCOF.RangoUtilizados() { Inicial = rangoInicial, Final = rangoFinal } }
                //RangoAnulados = new List<ChileSystems.DTE.Engine.RCOF.RangoAnulados>() { new ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Final = 0, Inicial = 0 } }
            });

            /*datos de notas de credito electronicas*/
            /*datos de boletas electrónicas afectas*/
            totalNeto = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoNeto);
            totalExento = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoExento);
            totalIVA = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.IVA);
            totalTotal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Sum(x => x.Documento.Encabezado.Totales.MontoTotal);
            rangoInicial = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Min(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            rangoFinal = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Max(x => x.Documento.Encabezado.IdentificacionDTE.Folio);
            resumenes.Add(new ChileSystems.DTE.Engine.RCOF.Resumen
            {
                FoliosAnulados = 0,
                FoliosEmitidos = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Count(),
                FoliosUtilizados = dtes.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica).Count(),
                MntExento = totalExento,
                MntIva = totalIVA,
                MntNeto = totalNeto,
                MntTotal = totalTotal,
                TasaIVA = 19,
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica,
                RangoUtilizados = new List<ChileSystems.DTE.Engine.RCOF.RangoUtilizados>() { new ChileSystems.DTE.Engine.RCOF.RangoUtilizados() { Inicial = rangoInicial, Final = rangoFinal } }
                //RangoAnulados =new List<ChileSystems.DTE.Engine.RCOF.RangoAnulados>() { new ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Final = 0, Inicial = 0 } }
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
            /*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/
            /*El tipo de libro debe ser "Especial" cuando se trata del set de pruebas*/
            /*El folio de notificacion lo entrega el SII al momento de solicitar el libro, para el set de pruebas no es necesario agregarlo*/
            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Caratula
            {
                RutEmisor = configuracion.Empresa.RutEmpresa,
                RutEnvia = configuracion.Certificado.Rut,
                PeriodoTributario = periodoTributario,
                FechaResolucion = configuracion.Empresa.FechaResolucion,
                NumeroResolucion = configuracion.Empresa.NumeroResolucion,
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
            libro.EnvioLibro.Id = "ID_LIBRO1_1";

            /*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
             * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula()
            {
                RutEmisor = configuracion.Empresa.RutEmpresa,
                RutEnvia = configuracion.Certificado.Rut,
                PeriodoTributario = DateTime.Now.Year + "-0" + DateTime.Now.Month,
                FechaResolucion = configuracion.Empresa.FechaResolucion,
                NumeroResolucion = configuracion.Empresa.NumeroResolucion,
                TipoOperacion = ChileSystems.DTE.Engine.Enum.TipoOperacionLibro.TipoOperacionLibroEnum.Venta,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total,
                FolioNotificacion = 100,
                //Para cuando es SET de pruebas, siempre es 1,,                
               
            };

            libro.EnvioLibro.Caratula.TipoOperacion = ChileSystems.DTE.Engine.Enum.TipoOperacionLibro.TipoOperacionLibroEnum.Venta;
            libro.EnvioLibro.Caratula.TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial;
            libro.EnvioLibro.Caratula.TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total;

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
                ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotSet;

                if (dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica)
                    tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica;

                else if (dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
                    tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica;

                else if (dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
                    tipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica;

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
            libro.EnvioLibro.Id = "ID_LIBRO2";

            /*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
             * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula()
            {
                RutEmisor = configuracion.Empresa.RutEmpresa,
                RutEnvia = configuracion.Certificado.Rut,
                PeriodoTributario = DateTime.Now.Year + "-0" + DateTime.Now.Month,
                FechaResolucion = configuracion.Empresa.FechaResolucion,
                NumeroResolucion = configuracion.Empresa.NumeroResolucion,
                TipoOperacion = ChileSystems.DTE.Engine.Enum.TipoOperacionLibro.TipoOperacionLibroEnum.Compra,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total,
                FolioNotificacion = 100, //Para cuando es SET de pruebas, siempre es 1
                //CodigoAutorizacionRectificacionLibro = "1NLKZLFX4S"

            };

            libro.EnvioLibro.Detalles = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle>();

            int neto = 60906;
            int exento = 0;
            int iva = (int)Math.Round(neto * 0.19, 0);           
            int total = neto + iva + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.Factura,
                NumeroDocumento = 234,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = 0,
                MontoNeto = neto,
                MontoIva = iva,
                MontoTotal = total
            });
            neto = 12658;
            exento = 11061;
            iva = (int)Math.Round(neto * 0.19, 0);
            total = neto + iva + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica,
                NumeroDocumento = 32,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = exento,
                MontoNeto = neto,
                MontoIva = iva,
                MontoTotal = total,
                IVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle>()
                {
                }
            });
            neto = 30263;
            exento = 0;
            iva = (int)Math.Round(neto * 0.19, 0);
            total = neto + iva + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento =  ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.Factura,
                NumeroDocumento = 781,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = exento,
                MontoNeto = neto,
                //MontoIva = 5681,
                IVAUsoComun = iva, //Neto * 0.19 
                MontoTotal = total,
                TipoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoResumido.Iva

            });

            neto = 2978;
            exento = 0;
            iva = (int)Math.Round(neto * 0.19, 0);
            total = neto + iva + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCredito,
                NumeroDocumento = 451,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = exento,
                MontoNeto = neto,
                MontoIva = iva,
                MontoTotal = total,
                TipoDocumentoReferencia = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual,
                FolioDocumentoReferencia = 234
            });

            neto = 12640;
            exento = 0;
            iva = (int)Math.Round(neto * 0.19, 0);
            total = neto + iva + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica,
                NumeroDocumento = 67,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = exento,
                MontoNeto = neto,
                MontoTotal = total,
                IVANoRecuperable = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle()
                    {
                        CodigoIVANoRecuperable = ChileSystems.DTE.Engine.Enum.CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.EntregaGratuita,
                        TotalMontoIVANoRecuperable = iva
                    }
                }
            });

            neto = 10885;
            exento = 0;
            iva = (int)Math.Round(neto * 0.19, 0);
            total = neto + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento =  ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaCompraElectronica,
                NumeroDocumento = 9,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = exento,
                MontoNeto = neto,
                MontoIva = iva,
                MontoTotal = total,
                IVARetenidoTotal = iva,
                Impuestos = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle()
                    {
                        CodigoImpuesto = ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal,
                        TotalMontoImpuesto = iva,
                        TasaImpuesto = 19
                    }
                }
            });

            neto = 10152;
            exento = 0;
            iva = (int)Math.Round(neto * 0.19, 0);
            total = neto + iva + exento;
            libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
            {
                TipoDocumento =  ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCredito,
                NumeroDocumento = 211,
                TasaImpuestoOperacion = 19,
                FechaDocumento = DateTime.Now,
                RutDocumento = "17096073-4",
                RazonSocial = "Razón Social",
                MontoExento = exento,
                MontoNeto = neto,
                MontoIva = iva,
                MontoTotal = total,
                TipoDocumentoReferencia = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaElectronica,
                FolioDocumentoReferencia = 32
            });




            libro.EnvioLibro.ResumenPeriodo = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo();
            libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo>();

            var manuales = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.Factura);
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

            var electronicas = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica);
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

            var nc = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCredito);
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

            var fce = libro.EnvioLibro.Detalles.Where(x => x.TipoDocumento == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaCompraElectronica);
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

        #region Guias de despacho

        public ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroGuia GenerateLibroGuias(ChileSystems.DTE.Engine.Envio.EnvioDTE envioAux)
        {
            var libro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroGuia();
            libro.EnvioLibro = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro();
            libro.EnvioLibro.Id = "ID_LIBRO_GUIAS_";


            libro.EnvioLibro.Caratula = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula()
            {
                RutEmisor = configuracion.Empresa.RutEmpresa,
                RutEnvia = configuracion.Certificado.Rut,
                PeriodoTributario = DateTime.Now.Year + "-0" + DateTime.Now.Month,
                FechaResolucion = configuracion.Empresa.FechaResolucion,
                NumeroResolucion = configuracion.Empresa.NumeroResolucion,
                TipoLibro = ChileSystems.DTE.Engine.Enum.TipoLibro.TipoLibroEnum.Especial,
                TipoEnvio = ChileSystems.DTE.Engine.Enum.TipoEnvioLibro.TipoEnvioLibroEnum.Total,
                FolioNotificacion = 100
            };


            libro.EnvioLibro.ResumenPeriodo = new ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo()
            {
                TotalesGuiasDeVentas = envioAux.SetDTE.DTEs.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoTraslado == ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta).Count(),
                MontoTotalVentasGuia = envioAux.SetDTE.DTEs.Where(x => x.Documento.Encabezado.IdentificacionDTE.TipoTraslado == ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta).Sum(x => x.Documento.Encabezado.Totales.MontoTotal),
                TotalesGuiasAnuladas = 0, //Dato opcional. No hay un indicador en el DTE para establecer que está anulado. Se debe entregar según datos del propio desarrollador,
                TotalesFoliosAnulados = 0, //Dato opcional. No hay un indicador en el DTE para establecer que su folio está anulado. Se debe entregar según datos del propio desarrollador,               

                //El traslado es opcional. Se repite hasta 6 veces, según los códigos de NO venta (2, 3, 4, 5, 6, 7).
                Traslados = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalTraslado>()
                {
                    new ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalTraslado()
                    {
                        TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.TrasladosInternos,
                        CantidadGuia = 1,
                        MontoGuia = 0
                    }
                }
            };

            libro.EnvioLibro.Detalles = new List<ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle>();
            foreach (var dte in envioAux.SetDTE.DTEs)
            {
                libro.EnvioLibro.Detalles.Add(new ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle()
                {
                    MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
                    Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio,
                    TipoOperacion = dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado,
                    //Para indicar que la guía está anulada se debe utilizar este atributo. Por defecto se omitirá
                    IndicadorAnulado = ChileSystems.DTE.Engine.Enum.IndicadorAnulado.IndicadorAnuladoEnum.NotSet
                });
            }

            return libro;
        }


        #endregion


        #region Utilidades

        public ChileSystems.DTE.Engine.Documento.DTE GenerateRandomDTE(int folio, ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipo)
        {
            // DOCUMENTO
            Random r = new Random();
            var dte = new ChileSystems.DTE.Engine.Documento.DTE();
            dte.Documento.Id = "TEST_2" + folio.ToString() + "_" + tipo;
            dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipo;
            dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now;
            dte.Documento.Encabezado.IdentificacionDTE.Folio = folio;

            //DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          
            dte.Documento.Encabezado.Emisor.Rut = configuracion.Empresa.RutEmpresa;
            dte.Documento.Encabezado.Emisor.RazonSocial = configuracion.Empresa.RazonSocial;
            dte.Documento.Encabezado.Emisor.Giro = configuracion.Empresa.Giro;
            dte.Documento.Encabezado.Emisor.DireccionOrigen = configuracion.Empresa.Direccion;
            dte.Documento.Encabezado.Emisor.ComunaOrigen = configuracion.Empresa.Comuna;


            dte.Documento.Encabezado.Emisor.ActividadEconomica = configuracion.Empresa.CodigosActividades.Select(x => x.Codigo).ToList();

            //DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

            dte.Documento.Encabezado.Receptor.Rut = "66666666-6";
            dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente";
            dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente";
            dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente";
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente";
            dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente";

            dte.Documento.Detalles = new List<ChileSystems.DTE.Engine.Documento.Detalle>();

            if (tipo == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica)
            {
                dte.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
                dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
                {
                    CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                    FechaDocumentoReferencia = DateTime.Now,
                    FolioReferencia = "40",
                    IndicadorGlobal = 0,
                    Numero = 1,
                    RazonReferencia = "CORRIGE MONTOS",
                    TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
                });
                dte.Documento.Detalles.Add(new ChileSystems.DTE.Engine.Documento.Detalle()
                {
                    NumeroLinea = 1,
                    Nombre = "DEVOLUCION",
                    Cantidad = 1,
                    Precio = 100,
                    MontoItem = 100
                });
            }
            else if (tipo == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica)
            {
                dte.Documento.Referencias = new List<ChileSystems.DTE.Engine.Documento.Referencia>();
                dte.Documento.Referencias.Add(new ChileSystems.DTE.Engine.Documento.Referencia()
                {
                    CodigoReferencia = ChileSystems.DTE.Engine.Enum.TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                    FechaDocumentoReferencia = DateTime.Now,
                    FolioReferencia = "41",
                    IndicadorGlobal = 0,
                    Numero = 1,
                    RazonReferencia = "RECARGO DE INTERESES",
                    TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoReferencia.FacturaElectronica
                });
                dte.Documento.Detalles.Add(new ChileSystems.DTE.Engine.Documento.Detalle()
                {
                    NumeroLinea = 1,
                    Nombre = "RECARGO",
                    Cantidad = 1,
                    Precio = 100,
                    MontoItem = 100
                });
            }
            else if (tipo == ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaCompraElectronica)
            {
                dte.Documento.Detalles.Add(new ChileSystems.DTE.Engine.Documento.Detalle()
                {
                    NumeroLinea = 1,
                    Nombre = "TECLADOS INALAMBRICOS",
                    Cantidad = 1,
                    Precio = 100,
                    MontoItem = 100,
                    CodigoImpuestoAdicional = new List<ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum>()
                    {
                        ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
                    }
                });
            }
            else
            {
                //DOCUMENTO - DETALLES

                int max_detalles = r.Next(1, 5);
                List<string> detallesRandom = configuracion.ProductosSimulacion.Select(x => x.Nombre).ToList();

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
                        (rutProveedor, dvProveedor.ToString(), tipoDocumento, folio, accion, configuracion.Certificado.Nombre, produccion, ".\\out\\tkn.dat", configuracion.APIKey);

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
                tipoDte, folio, fechaEmision, total, configuracion.Certificado.Nombre, produccion, ".\\out\\tkn.dat", configuracion.APIKey, out error);

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
            result.Caratula.RutResponde = configuracion.Empresa.RutEmpresa;

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

            var filepath = response.Firmar(configuracion.Certificado.Nombre);

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
                result.Caratula.RutResponde = configuracion.Empresa.RutEmpresa;

                result.Caratula.NumeroDetalles = 1;
                result.Caratula.RutRecibe = "88888888-8";

                result.ResultadoDTE = new List<ResultadoDTE>();
                var resultadoDTE = new ResultadoDTE();

                resultadoDTE.CodigoEnvio = 1;

                resultadoDTE.CodigoRechazoODiscrepancia = -1;//(int)estado;
                resultadoDTE.EstadoDTE = (ChileSystems.DTE.Engine.Enum.EstadoResultadoDTE.EstadoResultadoDTEEnum)estado;
                resultadoDTE.GlosaEstadoDTE = string.IsNullOrEmpty(motivo) ? resultadoDTE.EstadoDTE.ToString() : motivo;

                resultadoDTE.RutEmisor = "88888888-8";
                resultadoDTE.RutReceptor = configuracion.Empresa.RutEmpresa;
                resultadoDTE.TipoDTE = ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica;
                resultadoDTE.Folio = 52576;
                resultadoDTE.FechaEmision = new DateTime(2019, 2, 19);
                resultadoDTE.MontoTotal = 18635;

                result.ResultadoDTE.Add(resultadoDTE);

                string resultFilePath = response.Firmar(configuracion.Certificado.Nombre);
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
                response.Resultado = new ChileSystems.DTE.Engine.RespuestaEnvio.Resultado();

                var result = response.Resultado;

                result.Id = "APROBACION_COMERCIAL_";
                result.Caratula = new ChileSystems.DTE.Engine.RespuestaEnvio.Caratula();
                result.Caratula.Fecha = DateTime.Now;
                result.Caratula.IdRespuesta = 1;
                result.Caratula.MailContacto = "test@test.cl";
                result.Caratula.NombreContacto = "Nombre Contacto";
                result.Caratula.RutResponde = configuracion.Empresa.RutEmpresa;

                result.Caratula.NumeroDetalles = 1;
                result.Caratula.RutRecibe = "88888888-8";

                result.ResultadoDTE = new List<ResultadoDTE>();
                var resultadoDTE = new ResultadoDTE();

                resultadoDTE.CodigoEnvio = 1;

                resultadoDTE.CodigoRechazoODiscrepancia = -1;//(int)estado;
                resultadoDTE.EstadoDTE = (ChileSystems.DTE.Engine.Enum.EstadoResultadoDTE.EstadoResultadoDTEEnum)estado;
                resultadoDTE.GlosaEstadoDTE = string.IsNullOrEmpty(motivo) ? resultadoDTE.EstadoDTE.ToString() : motivo;

                resultadoDTE.RutEmisor = "88888888-8";
                resultadoDTE.RutReceptor = configuracion.Empresa.RutEmpresa;
                resultadoDTE.TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE;
                resultadoDTE.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio;
                resultadoDTE.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision;
                resultadoDTE.MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal;

                result.ResultadoDTE.Add(resultadoDTE);

                string resultFilePath = response.Firmar(configuracion.Certificado.Nombre);
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
                        RutResponde = configuracion.Empresa.RutEmpresa,
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
                            RutReceptor = configuracion.Empresa.RutEmpresa,
                            FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision,
                            Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio,
                            MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
                            TipoDocumento = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE,
                            Recinto = "Recinto",
                            RutFirma = configuracion.Certificado.Rut
                         }
                    }
                };

                int id = -1;
                var recibo = envio.SetRecibos.Recibos.First();
                envio.SetRecibos.Id = "EARM" + id;
                recibo.DocumentoRecibo.Id = "RM" + id;

                envio.SetRecibos.signedXmls.Add(recibo.Firmar(configuracion.Certificado.Nombre));
                string filePath = envio.Firmar(configuracion.Certificado.Nombre);
                return filePath;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ObtenerCertificados()
        {
            var certificadosMaquina = ChileSystems.DTE.Engine.Utilidades.ObtenerCertificadosMaquinas();
            var certificadosUsuario = ChileSystems.DTE.Engine.Utilidades.ObtenerCertificadosUsuario();
            string result = "Máquina:\n";
            foreach (var a in certificadosMaquina)
                result += a + "\n";
            result += "Usuario:\n";
            foreach (var a in certificadosUsuario)
                result += a + "\n";
            return result;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static string TipoDTEString(ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType tipo)
        {
            switch (tipo)
            {
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaCompraElectronica: return "FACTURA DE COMPRA ELECTRÓNICA";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica: return "FACTURA ELECTRÓNICA";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronicaExenta: return "FACTURA ELECTRÓNICA EXENTA";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.GuiaDespachoElectronica: return "GUIA DE DESPACHO ELECTRÓNICA";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCreditoElectronica: return "NOTA DE CRÉDITO ELECTRÓNICA";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaDebitoElectronica: return "NOTA DE DÉBITO ELECTRÓNICA";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.Factura: return "FACTURA MANUAL";
                case ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.NotaCredito: return "NOTA DE CRÉDITO MANUAL";
            }
            return "Not Set";
        }
        #endregion  

    }
}
