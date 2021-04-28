using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.RCOF
{
    public class Enviar
    {
        public CertificadoDigital CertificadoDigital { get; set; }
        public string RutEmisor { get; set; }
        public string RutReceptor { get; set; }
        public int NumeroResolucion { get; set; }
        public string FechaResolucion { get; set; }

        public Boolean Produccion { get; set; }
    }
}
