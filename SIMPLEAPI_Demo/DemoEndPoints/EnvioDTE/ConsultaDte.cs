using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.GenerarDTE
{
    public class ConsultaDte
    {
        public CertificadoDigital CertificadoDigital { get; set; }
        public int RutEmpresa { get; set; }
        public string RutEmpresaDigito { get; set; }
        public int TrackId { get; set; }
        public Boolean Produccion { get; set; }
        public Boolean ServidorBoletaREST { get; set; }

    }
}
