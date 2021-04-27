using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class Resumen
    {
        public int TipoDocumento { get; set; }
        public int MntNeto { get; set; }
        public int MntIva { get; set; }
        public int TasaIVA { get; set; }
        public int MntExento { get; set; }
        public int MntTotal { get; set; }
        public int FoliosEmitidos { get; set; }
        public int FoliosAnulados { get; set; }
        public int FoliosUtilizados { get; set; }
    }
}
