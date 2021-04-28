using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class Detalles
    {
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int total { get; set; }
        public Boolean isExento { get; set; }
        public int descuento { get; set; }

    }
}
