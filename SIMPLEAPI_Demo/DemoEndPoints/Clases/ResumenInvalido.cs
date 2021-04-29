using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class ResumenInvalido
    {
        public ResumenInvalido(int tipoDocumento, int mntNeto, int mntIva, int tasaIVA, int mntExento, int mntTotal, int foliosEmitidos, int foliosAnulados, int foliosUtilizados, List<Rangos> rangoUtilizados, List<Rangos> rangoAnulados)
        {
            TipoDocumento = tipoDocumento;
            MntNeto = mntNeto;
            MntIva = mntIva;
            TasaIVA = tasaIVA;
            MntExento = mntExento;
            MntTotal = mntTotal;
            FoliosEmitidos = foliosEmitidos;
            FoliosAnulados = foliosAnulados;
            FoliosUtilizados = foliosUtilizados;
            RangoUtilizados = new List<Rangos>();
            RangoAnulados = new List<Rangos>();
        }
        public ResumenInvalido()
        {

        }

        public int TipoDocumento { get; set; }
        public int MntNeto { get; set; }
        public int MntIva { get; set; }
        public int TasaIVA { get; set; }
        public int MntExento { get; set; }
        public int MntTotal { get; set; }
        public int FoliosEmitidos { get; set; }
        public int FoliosAnulados { get; set; }
        public int FoliosUtilizados { get; set; }

        public List<Rangos> RangoUtilizados { get; set; }

        public List<Rangos> RangoAnulados { get; set; }
    }
}
