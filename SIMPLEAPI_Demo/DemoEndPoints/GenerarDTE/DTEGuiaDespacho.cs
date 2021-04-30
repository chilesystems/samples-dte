using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.GenerarDTE
{
    public class DTEGuiaDespacho
    {
        public Receptor receptor { get; set; }
        public EmisorGuia emisor { get; set; }
        public List<DetallesGuia> detalles { get; set; }
        public Encabezado encabezado { get; set; }
        public TotalesBoleta totales { get; set; }

        public OtrosDTEGuia otrosDTE { get; set; }
        public CertificadoDigital certificadoDigital { get; set; }

        public DTEGuiaDespacho()
        {
            this.detalles = new List<DetallesGuia>();
        }
    }
}
