using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo
{
    public class ItemBoleta
    {
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public int Precio { get; set; }
        public int Total { get { return (int)Math.Round(Cantidad * Precio, 0); } }
        public bool Afecto { get; set; }
        public string UnidadMedida { get; set; }
        public double Descuento { get; set; }
        public int _tipoImpuesto;
        public ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum TipoImpuesto
        {
            get { return _tipoImpuesto != 0 ? (ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum)_tipoImpuesto : ChileSystems.DTE.Engine.Enum.TipoImpuesto.TipoImpuestoEnum.NotSet; }
            set { _tipoImpuesto = (int)value; }
        }
    }
}
