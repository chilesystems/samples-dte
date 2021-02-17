using ChileSystems.DTE.Engine.Documento;
using SIMPLEAPI_Demo.Impresion.Core.Helpers;
using SIMPLEAPI_Demo.Impresion.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Impresion.Core
{
    public class PrintableDocument
    {
        // Datos Emisor //
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public string Giro { get; set; }
        public string DireccionCasaMatriz { get; set; }
        public List<string> Sucursales { get; set; }
        public string Teléfono { get; set; }


        // Datos Receptor //
        public string RutCliente { get; set; }
        public string RazonSocialCliente { get; set; }


        // Datos Documento //
        public string NombreDocumento { get; set; }
        public long Folio { get; set; }
        public string OficinaSII { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool IsDTE { get; set; }
        public bool ShowUnidadMedida { get; set; }
        public List<string> Referencias { get; set; }


        // Detalles ///
        public List<PrintableDocumentDetail> Detalles { get; set; }


        // Total //
        /// <summary>
        /// D ó R | NOMBRE DESCUENTO | $0.000%
        /// </summary>
        public List<(char, string, string)> DescuentosRecargos { get; set; }
        /// <summary>
        /// NOMBRE IMPUESTO | VALOR
        /// </summary>
        public List<(string, int)> Adicionales { get; set; }
        public int Neto { get; set; }
        public int IVA { get; set; }
        public int Total { get; set; }
        public int TotalExento { get; set; }


        // SII //
        public Image TimbreImage { get; set; }
        public int NumeroResolucion { get; set; }
        public DateTime FechaResolucion { get; set; }
        public string WebVerificación { get; set; }

        public static PrintableDocument FromDTE(DTE dte)
        {
            var doc = new PrintableDocument();
            try
            {
                //var xml = new XmlHandler(filePath);

                doc = new PrintableDocument();
                doc.RazonSocial = string.IsNullOrEmpty(dte.Documento.Encabezado.Emisor.RazonSocial) ? dte.Documento.Encabezado.Emisor.RazonSocialBoleta : dte.Documento.Encabezado.Emisor.RazonSocial;
                doc.Rut = dte.Documento.Encabezado.Emisor.Rut;
                doc.Giro = string.IsNullOrEmpty(dte.Documento.Encabezado.Emisor.Giro) ? dte.Documento.Encabezado.Emisor.GiroBoleta : dte.Documento.Encabezado.Emisor.Giro;
                doc.DireccionCasaMatriz = dte.Documento.Encabezado.Emisor.DireccionOrigen;
                doc.Sucursales = null;
                doc.Teléfono = null;

                // Datos Receptor //
                doc.RutCliente = dte.Documento.Encabezado.Receptor.Rut;
                doc.RazonSocialCliente = dte.Documento.Encabezado.Receptor.RazonSocial;

                // Datos Documento //
                doc.NombreDocumento = DTETypeNames.Names[(int)dte.Documento.Encabezado.IdentificacionDTE.TipoDTE];
                doc.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio;
                doc.OficinaSII = null;
                doc.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision;

                doc.IsDTE = doc.NombreDocumento.ToUpper().Contains("ELECTR");
                doc.ShowUnidadMedida = false;

                // Detalles ///
                doc.Detalles = new List<PrintableDocumentDetail>();
                foreach (var detalle in dte.Documento.Detalles)
                {
                    doc.Detalles.Add(
                           new PrintableDocumentDetail()
                           {
                               Cantidad = detalle.Cantidad,
                               Descripcion = string.IsNullOrEmpty(detalle.Nombre) ? detalle.Descripcion : detalle.Nombre,
                               IsExento = detalle.IndicadorExento == ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento,
                               Precio = detalle.Precio,
                               Total = detalle.MontoItem,
                               UnidadMedida = detalle.UnidadMedida
                           });
                }

                string value;
                doc.DescuentosRecargos = new List<(char, string, string)>();
                foreach (var item in dte.Documento.DescuentosRecargos)
                {
                    if (item.TipoValor == ChileSystems.DTE.Engine.Enum.ExpresionDinero.ExpresionDineroEnum.Porcentaje)
                        value = item.Valor.ToString("N2") + "%";
                    else
                        value = item.Valor.ToString("N0") + "Pesos";

                    doc.DescuentosRecargos.Add((
                          (char)item.TipoMovimiento,
                          item.Descripcion,
                          value));
                }

                doc.Adicionales = new List<(string, int)>();
                foreach (var item in dte.Documento.Encabezado.Totales.ImpuestosRetenciones)
                {
                    doc.Adicionales.Add((item.TipoImpuesto.ToString(), item.MontoImpuesto));
                }

                StringBuilder sb;
                int intAux;
                string stringAux;
                DateTime dateAux;

                doc.Referencias = new List<string>();
                foreach (var item in dte.Documento.Referencias)
                {
                    sb = new StringBuilder();
                    // TIPO DE REFERENCIA (ANULA, CORRIGE MONTOS, CORRIGE DATOS)
                    stringAux = item.CodigoReferencia.ToString();
                    if (!string.IsNullOrEmpty(stringAux))
                        if (int.TryParse(stringAux, out intAux))
                            if (CodigoReferenciaName.Names.ContainsKey(intAux))
                                stringAux = CodigoReferenciaName.Names[intAux];

                    sb.Append(stringAux + ": ");

                    // TIPO DE DOCUMENTO DE REFERENCIA
                    stringAux = item.TipoDocumento.ToString();
                    if (!string.IsNullOrEmpty(stringAux))
                        if (int.TryParse(stringAux, out intAux))
                            if (DTETypeNames.Names.ContainsKey(intAux))
                                stringAux = DTETypeNames.Names[intAux];

                    sb.Append(stringAux + " ");

                    // FOLIO DE REFERENCIA
                    stringAux = item.FolioReferencia;
                    if (!string.IsNullOrEmpty(stringAux) && stringAux != "0")
                        sb.Append(stringAux);

                    // FECHA DE REFERENCIA    
                    stringAux = item.FechaDocumentoReferenciaString;
                    if (!string.IsNullOrEmpty(stringAux))
                        if (DateTime.TryParseExact(stringAux, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateAux))
                            stringAux = "DE " + dateAux.ToShortDateString();

                    sb.Append(stringAux);

                    // RAZON DE REFERENCIA
                    stringAux = item.RazonReferencia;
                    if (!string.IsNullOrEmpty(stringAux))
                        sb.Append(" - RAZÓN: " + stringAux);

                    doc.Referencias.Add(" - " + sb.ToString().Trim());
                }


                doc.Neto = dte.Documento.Encabezado.Totales.MontoNeto;
                doc.TotalExento = dte.Documento.Encabezado.Totales.MontoExento;
                doc.IVA = dte.Documento.Encabezado.Totales.IVA;
                doc.Total = dte.Documento.Encabezado.Totales.MontoTotal;
            }
            catch { }
            return doc;
        }
    }
}
