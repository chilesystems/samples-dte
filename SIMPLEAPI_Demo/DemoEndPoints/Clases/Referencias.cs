using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEndPoints.Clases
{
    public class Referencias
    {
        public Referencias(string Fecha,int TipoDoc,int Folio,string Glosa)
        {
            this.fecha = Fecha;
            this.tipoDocReferencia=TipoDoc;
            this.folioReferencia = Folio;
            this.glosa = Glosa;
        }
        public Referencias()
        {
            
        }
        public string fecha { get; set; }
        public int tipoDocReferencia { get; set; }
        public int folioReferencia { get; set; }
        public string glosa { get; set; }
    }
}
