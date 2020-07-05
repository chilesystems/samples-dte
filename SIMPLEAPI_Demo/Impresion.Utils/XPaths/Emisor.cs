using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.XmlUtils.XPaths
{
    public class Emisor
    {
        public static string RazonSocial = "DTE/Documento/Encabezado/Emisor/RznSoc";
        public static string Rut = "DTE/Documento/Encabezado/Emisor/RUTEmisor";
        public static string Giro = "DTE/Documento/Encabezado/Emisor/GiroEmis";
        public static string DireccionCasaMatriz = "DTE/Documento/Encabezado/Emisor/DirOrigen";
        //public static string Sucursales = null; // No viene en el DTE
        //public static string Teléfono = null; // No viene en el DTE
    }
}
