using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class Rangos
    {
        public Rangos(int inicial, int final)
        {
            Inicial = inicial;
            Final = final;
        }
        public Rangos()
        {
            
        }
        public int Inicial { get; set; }
        public int Final { get; set; }
    }
}
