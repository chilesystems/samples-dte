using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class ActividadesEconomicas
    {
        public ActividadesEconomicas(int Codigo)
        {
            this.codigo = Codigo;
        }
        public ActividadesEconomicas()
        {
            
        }
        public int codigo { get; set; }
    }
    
}
