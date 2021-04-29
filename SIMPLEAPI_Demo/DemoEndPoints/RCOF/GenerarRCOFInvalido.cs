using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEndPoints.RCOF
{
    public partial class GenerarRCOFInvalido : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarRcof"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        public int tipo;
        OpenFileDialog dialog;
        List<ResumenInvalido> resumenes = new List<ResumenInvalido>();
        List<Rangos> anulados = new List<Rangos>();
        List<Rangos> utilizados = new List<Rangos>();
        public GenerarRCOFInvalido()
        {
            InitializeComponent();
        }

        private void btn_agregarUtilizados_Click(object sender, EventArgs e)
        {
            Rangos utilizado = new Rangos();
            utilizado.Inicial = int.Parse(txt_utilizadosInicial.Text);
            utilizado.Final = int.Parse(txt_utilizadosFinal.Text);
            utilizados.Add(utilizado);
            grid_utilizados.DataSource = null;
            grid_utilizados.DataSource = utilizados;

            txt_utilizadosInicial.Text = "0";
            txt_utilizadosFinal.Text = "0";
        }

        private void btn_agregarAnulados_Click(object sender, EventArgs e)
        {
            Rangos anulado = new Rangos();
            anulado.Inicial = int.Parse(txt_anuladosInicial.Text);
            anulado.Final = int.Parse(txt_anuladosFinal.Text);
            anulados.Add(anulado);
            grid_anulados.DataSource = null;
            grid_anulados.DataSource = anulados;

            txt_anuladosFinal.Text = "0";
            txt_anuladosInicial.Text = "0";
        }

        private void GenerarRCOFInvalido_Load(object sender, EventArgs e)
        {
            llenar();
        }
        public void llenar()
        {
            if (tipo==1)
            {
                txt_rutEmisor.Text = "17938236-9";
                txt_rutEnvia.Text = "17938236-9";
                txt_numResol.Text = "99";
                txt_numSecEnvio.Text = "6";

                List<Rangos> listaUt1 = new List<Rangos>();
                List<Rangos> listaAnu1 = new List<Rangos>();
                listaUt1.Add(new Rangos(6,10));
                listaAnu1.Add(new Rangos(11,12));
                resumenes.Add(new ResumenInvalido(39, 43832, 8328, 19, 2000, 54160, 5, 0, 5, listaUt1,listaAnu1));



                
                grid_anulados.DataSource = anulados;
                grid_utilizados.DataSource = utilizados;
                grid_resumen.DataSource = resumenes;
            }
            

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";
        }

        private void btn_agregarDetalles_Click(object sender, EventArgs e)
        {
            ResumenInvalido resumen = new ResumenInvalido();
            resumen.TipoDocumento = int.Parse(txt_tipoDoc.Text);
            resumen.MntNeto = int.Parse(txt_mntNeto.Text);
            resumen.MntIva = int.Parse(txt_mntIva.Text);
            resumen.TasaIVA = int.Parse(txt_tasaIva.Text);
            resumen.MntExento = int.Parse(txt_mntExento.Text);
            resumen.MntTotal = int.Parse(txt_mntTotal.Text);
            resumen.FoliosEmitidos = int.Parse(txt_foliosEmitidos.Text);
            resumen.FoliosAnulados = int.Parse(txt_foliosAnulados.Text);
            resumen.FoliosUtilizados = int.Parse(txt_foliosUtilizados.Text);

            Rangos utilizado = new Rangos();
            utilizado.Inicial = int.Parse(txt_utilizadosInicial.Text);
            utilizado.Final = int.Parse(txt_utilizadosFinal.Text);
            utilizados.Add(utilizado);

            Rangos anulado = new Rangos();
            anulado.Inicial = int.Parse(txt_anuladosInicial.Text);
            anulado.Final = int.Parse(txt_anuladosFinal.Text);
            anulados.Add(anulado);

            resumen.RangoAnulados = anulados;
            resumen.RangoUtilizados = utilizados;

            resumenes.Add(resumen);
            grid_resumen.DataSource = null;
            grid_resumen.DataSource = resumenes;
            

            txt_tipoDoc.Text = "0";
            txt_mntNeto.Text = "0";
            txt_foliosUtilizados.Text = "0";
            txt_foliosEmitidos.Text = "0";
            txt_foliosAnulados.Text = "0";
            txt_tipoDoc.Text = "0";
            txt_mntIva.Text = "0";
            txt_tasaIva.Text = "0";
            txt_mntTotal.Text = "0";
            txt_anuladosFinal.Text = "0";
            txt_anuladosInicial.Text = "0";
            txt_utilizadosInicial.Text = "0";
            txt_utilizadosFinal.Text = "0";
        }
    }
}
