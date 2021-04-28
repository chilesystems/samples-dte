using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class DescuentosRecargos
    {
        public DescuentosRecargos(string descripcion,int tipomov,int tipoVal,int valor)
        {
            this.Descripcion = descripcion;
            this.TipoMovimiento = tipomov;
            this.TipoValor = tipoVal;
            this.Valor = valor;
        }

        public DescuentosRecargos()
        {
           
        }

        public string Descripcion { get; set; }
        public int TipoMovimiento { get; set; }
        public int TipoValor { get; set; }
        public int Valor { get; set; }
    }
}
