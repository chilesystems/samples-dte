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
        Receptor receptor { get; set; }
        EmisorBoleta emisor { get; set; }
        List<Detalles> detalles { get; set; }
        public Encabezado encabezado { get; set; }
        public TotalesBoleta totales { get; set; }

        public OtrosDTEBoleta otrosDTE { get; set; }
        public CertificadoDigital certificadoDigital { get; set; }
    }
}
