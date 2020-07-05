using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.XmlUtils.XPaths
{
    public class Referencia
    {
        public static string Referencias = "DTE/Documento/Referencia";
        public static string CodigoReferencia = "DTE/Documento/Referencia[{0}]/CodRef";
        public static string NumeroTipoDocumentoReferencia = "DTE/Documento/Referencia[{0}]/TpoDocRef";
        public static string FolioReferencia = "DTE/Documento/Referencia[{0}]/FolioRef";
        public static string FechaReferencia = "DTE/Documento/Referencia[{0}]/FchRef";
        public static string RazonReferencia = "DTE/Documento/Referencia[{0}]/RazonRef";
    }
}
