using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class OtrosDTE
    {
        public int indicadorServicio { get; set; }
        public int tipoTraslado { get; set; }
        public int tipoDespacho { get; set; }
    }
    public class OtrosDTEBoleta
    {
        public int indicadorServicio { get; set; }
    }

    public class OtrosDTEGuia
    {
        
        public int tipoTraslado { get; set; }
        public int tipoDespacho { get; set; }
    }
}
