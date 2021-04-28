using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class Emisor
    {
        public string rut { get; set; }
        public string razonSocial { get; set; }
        public List<int> actividadesEconomicas { get; set; }
        public string comuna { get; set; }
        public string giro { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }

        public Emisor()
        {
            this.actividadesEconomicas = new List<int>();
        }
    }
}
