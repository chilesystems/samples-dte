using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.XmlUtils.XPaths
{
    public class Adicional
    {
        public static string Adicionales = "DTE/Documento/Encabezado/Totales/ImptoReten";
        public static string TipoAdicional = "DTE/Documento/Encabezado/Totales/ImptoReten[{0}]/TipoImp";
        public static string ValorAdicional = "DTE/Documento/Encabezado/Totales/ImptoReten[{0}]/MontoImp";
    }
}
