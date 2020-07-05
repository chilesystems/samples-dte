using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.XmlUtils.XPaths
{
    public class Detalle
    {
        public static string Detalles = "DTE/Documento/Detalle";
        public static string Cantidad = "DTE/Documento/Detalle[{0}]/QtyItem";
        public static string NombreDetalle = "DTE/Documento/Detalle[{0}]/NmbItem";
        public static string PrecioUnitario = "DTE/Documento/Detalle[{0}]/PrcItem";
        public static string TotalDetalle = "DTE/Documento/Detalle[{0}]/MontoItem";
        public static string UnidadMedida = "DTE/Documento/Detalle[{0}]/UnmdItem";
        public static string IndicadorExencion = "DTE/Documento/Detalle[{0}]/IndExe";
    }
}
