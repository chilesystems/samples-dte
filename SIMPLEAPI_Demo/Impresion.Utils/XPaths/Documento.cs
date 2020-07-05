using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.XmlUtils.XPaths
{
    public class Documento
    {
        public static string NumeroTipoDocumento = "DTE/Documento/Encabezado/IdDoc/TipoDTE";
        public static string Folio = "DTE/Documento/Encabezado/IdDoc/Folio";
        public static string OficinaSII = null; // No viene en el DTE
        public static string FechaEmision = "DTE/Documento/Encabezado/IdDoc/FchEmis";

        public static string DescripcionDescuento = "DTE/Documento/DscRcgGlobal/GlosaDR";
        public static string ValorDescuento = "DTE/Documento/DscRcgGlobal/GlosaDR";

        public static string Neto = "DTE/Documento/Encabezado/Totales/MntNeto";
        public static string IVA = "DTE/Documento/Encabezado/Totales/IVA";
        public static string Total = "DTE/Documento/Encabezado/Totales/MntTotal";
        public static string TotalExento = "DTE/Documento/Encabezado/Totales/MntExe";
    }
}
