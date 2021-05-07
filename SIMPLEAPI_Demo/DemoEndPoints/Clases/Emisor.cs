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

        public Emisor(string rut, string razonSocial, List<int> actividadesEconomicas, string comuna, string giro, string direccion, int telefono)
        {
            this.rut = rut;
            this.razonSocial = razonSocial;
            this.actividadesEconomicas = actividadesEconomicas;
            this.comuna = comuna;
            this.giro = giro;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
    public class EmisorBoleta
    {
        public string rut { get; set; }
        public string razonSocial { get; set; }
        public string comuna { get; set; }
        public string giro { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
    }

    public class EmisorGuia
    {
        public string rut { get; set; }
        public string razonSocial { get; set; }
        public List<int> actividadesEconomicas { get; set; }
        public string comuna { get; set; }
        public string giro { get; set; }
        public string direccion { get; set; }

        public EmisorGuia()
        {
            this.actividadesEconomicas = new List<int>();
        }

        public EmisorGuia(string rut, string razonSocial, List<int> actividadesEconomicas, string comuna, string giro, string direccion)
        {
            this.rut = rut;
            this.razonSocial = razonSocial;
            this.actividadesEconomicas = actividadesEconomicas;
            this.comuna = comuna;
            this.giro = giro;
            this.direccion = direccion;
        }
    }
    public class EmisorEntrada
    {
        public string rut { get; set; }
        public string razonSocial { get; set; }
        public List<int> actividadesEconomicas { get; set; }
        public string comuna { get; set; }
        public string giro { get; set; }
        public string direccion { get; set; }
        public Nullable<int> telefono { get; set; }

        public EmisorEntrada()
        {
            this.actividadesEconomicas = new List<int>();
        }

        public EmisorEntrada(string rut, string razonSocial, List<int> actividadesEconomicas, string comuna, string giro, string direccion, int telefono)
        {
            this.rut = rut;
            this.razonSocial = razonSocial;
            this.actividadesEconomicas = actividadesEconomicas;
            this.comuna = comuna;
            this.giro = giro;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}
