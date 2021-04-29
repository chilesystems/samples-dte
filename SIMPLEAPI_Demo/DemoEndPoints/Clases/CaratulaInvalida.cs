using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class CaratulaInvalida
    {
        public string RutEmisor { get; set; }
        public string RutEnvia { get; set; }
        public string FchResol { get; set; }
        public int NroResol { get; set; }
        public string FchInicio { get; set; }
        public string FchFinal { get; set; }
        public int SecEnvio { get; set; }
        public string TmstFirmaEnv { get; set; }
    }
}
