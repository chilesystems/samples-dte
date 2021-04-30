using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.GenerarDTE
{
    public class DTEBoleta
    {
        public Receptor receptor { get; set; }
        public EmisorBoleta emisor { get; set; }
        public List<Detalles> detalles { get; set; }
        public Encabezado encabezado { get; set; }
        public TotalesBoleta totales { get; set; }

        public OtrosDTEBoleta otrosDTE { get; set; }
        public CertificadoDigital certificadoDigital { get; set; }
    }
}
