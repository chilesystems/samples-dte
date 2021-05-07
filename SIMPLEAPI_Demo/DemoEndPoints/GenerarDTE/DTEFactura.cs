using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.GenerarDTE
{
    public class DTEFactura
    {
        public Receptor receptor { get; set; }
        public Emisor emisor { get; set; }
        public List<Detalles> detalles { get; set; }
        public List<Referencias> referencias { get; set; }
        public Encabezado encabezado { get; set; }
        public Totales totales { get; set; }

        public OtrosDTE otrosDTE { get; set; }
        public CertificadoDigital certificadoDigital { get; set; }
        public List<DescuentosRecargos> DescuentosRecargos { get; set; }

        public DTEFactura()
        {
            this.detalles = new List<Detalles>();
            this.referencias = new List<Referencias>();
            this.DescuentosRecargos = new List<DescuentosRecargos>();
        }
    }

    public class DTEEntrada
    {
        public Receptor receptor { get; set; }
        public Emisor emisor { get; set; }
        public List<DetallesEntrada> detalles { get; set; }
        public List<ReferenciasEntrada> referencias { get; set; }
        public Encabezado encabezado { get; set; }
        public Totales totales { get; set; }

        public OtrosDTE otrosDTE { get; set; }
        public CertificadoDigital certificadoDigital { get; set; }
        public List<DescuentosRecargos> DescuentosRecargos { get; set; }

        public DTEEntrada()
        {
            this.detalles = new List<DetallesEntrada>();
            this.referencias = new List<ReferenciasEntrada>();
            //this.DescuentosRecargos = new List<DescuentosRecargos>();
        }
    }
}
