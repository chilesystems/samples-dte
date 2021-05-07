using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class Detalles
    {
        public Detalles(string Nombre,int Cantidad,int Precio, int Total, Boolean IsExento, int Descuento)
        {
            this.nombre = Nombre;
            this.cantidad = Cantidad;
            this.precio = Precio;
            this.total = Total;
            this.isExento = IsExento;
            this.descuento = Descuento;
        }
        public Detalles()
        {
            
        }

        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int total { get; set; }
        public Boolean isExento { get; set; }
        public int descuento { get; set; }

    }
    public class DetallesGuia
    {
        public DetallesGuia(string Nombre, int Cantidad, int Precio, int Total)
        {
            this.nombre = Nombre;
            this.cantidad = Cantidad;
            this.precio = Precio;
            this.total = Total;
        }
        public DetallesGuia()
        {

        }

        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int total { get; set; }

    }

    public class DetallesEntrada
    {
        
        public DetallesEntrada()
        {

        }

        public DetallesEntrada(string nombre, int cantidad, int precio, int total, bool isExento, int descuento, int unidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
            this.precio = precio;
            this.total = total;
            this.isExento = isExento;
            this.descuento = descuento;
            this.unidad = unidad;
        }

        public string nombre { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int total { get; set; }
        public Boolean isExento { get; set; }
        public int descuento { get; set; }
        public Nullable<int> unidad { get; set; }

    }
}
