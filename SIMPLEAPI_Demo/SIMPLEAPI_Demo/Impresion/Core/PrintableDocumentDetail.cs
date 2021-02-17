using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Impresion.Core
{
    public class PrintableDocumentDetail
    {
        public bool IsExento { get; set; }
        public double Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Total { get; set; }
    }
}
