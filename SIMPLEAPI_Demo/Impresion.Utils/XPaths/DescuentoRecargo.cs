using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.XmlUtils.XPaths
{
    public class DescuentoRecargo
    {
        public static string DescuentosRecargos = "DTE/Documento/DscRcgGlobal";
        public static string Tipo = "DTE/Documento/DscRcgGlobal[{0}]/TpoMov";
        public static string Glosa = "DTE/Documento/DscRcgGlobal[{0}]/GlosaDR";
        public static string TipoValor = "DTE/Documento/DscRcgGlobal[{0}]/TpoValor";
        public static string Valor = "DTE/Documento/DscRcgGlobal[{0}]/ValorDR";
    }
}
