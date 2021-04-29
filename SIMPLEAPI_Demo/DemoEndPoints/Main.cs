using DemoEndPoints.GenerarDTE;
using DemoEndPoints.Impresion;
using DemoEndPoints.RCOF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEndPoints
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        

        private async void btn_jsonEnvio_Click(object sender, EventArgs e)
        {
            Form jsonEnv = new GenerarJson.JsonEnvio();
            jsonEnv.Show();
        }

        private void btn_jsonEntrada_Click(object sender, EventArgs e)
        {
            Form jsonEnt = new GenerarJson.JsonEntrada();
            jsonEnt.Show();
        }

        private void btn_jsonPdf_Click(object sender, EventArgs e)
        {
            Form jsonPdf = new GenerarJson.JsonPdf();
            jsonPdf.Show();
        }

        private void btn_rcofValido_Click(object sender, EventArgs e)
        {
            Form generarRcof = new GenerarRcof();
            generarRcof.Show();
        }

        private void btn_enviarRcof_Click(object sender, EventArgs e)
        {
            Form enviarRcof = new EnviarRcof();
            enviarRcof.Show();
        }

        private void btn_dteFactura_Click(object sender, EventArgs e)
        {
            Form generarDteFactura = new GenerarDte();
            generarDteFactura.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btn_dteJson_Click(object sender, EventArgs e)
        {
            Form generarDteJson = new GenerarDteJson();
            generarDteJson.Show();
        }

        private void btn_dteGenerarEnvio_Click(object sender, EventArgs e)
        {
            EnvioDte generarEnvioDte = new EnvioDte();
            generarEnvioDte.tipo = 1;
            generarEnvioDte.Show();
        }

        private void btn_dteEnvioBoleta_Click(object sender, EventArgs e)
        {
            EnvioDte generarEnvioDte = new EnvioDte();
            generarEnvioDte.tipo = 2;
            generarEnvioDte.Show();
        }

        private void btn_envioDte_Click(object sender, EventArgs e)
        {
            EnvioDte generarEnvioDte = new EnvioDte();
            generarEnvioDte.tipo = 3;
            generarEnvioDte.Show();
        }

        private void btn_EnvioBoleta_Click(object sender, EventArgs e)
        {
            EnvioDte generarEnvioDte = new EnvioDte();
            generarEnvioDte.tipo = 4;
            generarEnvioDte.Show();
        }

        private void btn_consultarEnvio_Click(object sender, EventArgs e)
        {
            Form consulta = new ConsultarEstadoEnvio();
            consulta.Show();
        }

        private void btn_rcofInvalido4R_Click(object sender, EventArgs e)
        {
            GenerarRCOFInvalido rcofInvalido = new GenerarRCOFInvalido();
            rcofInvalido.tipo = 1;
            rcofInvalido.Show();
        }

        private void btn_rcofInvalidoTI_Click(object sender, EventArgs e)
        {
            GenerarRCOFInvalido rcofInvalido = new GenerarRCOFInvalido();
            rcofInvalido.tipo = 2;
            rcofInvalido.Show();
        }

        private void btn_pdf417Dte_Click(object sender, EventArgs e)
        {
            Pdf417 pdf417 = new Pdf417();
            pdf417.tipo = 1;
            pdf417.Show();
        }
        private void btn_pdf417Envio_Click(object sender, EventArgs e)
        {
            Pdf417 pdf417 = new Pdf417();
            pdf417.tipo = 2;
            pdf417.Show();
        }

        private void btn_boletaCartaPdf_Click(object sender, EventArgs e)
        {
            Carta carta = new Carta();
            carta.tipo = 1;
            carta.Show();
        }

        private void btn_boletaCartaBase64_Click(object sender, EventArgs e)
        {
            Carta carta = new Carta();
            carta.tipo = 2;
            carta.Show();
        }

        private void btn_facturaCarta64_Click(object sender, EventArgs e)
        {
            Carta carta = new Carta();
            carta.tipo = 3;
            carta.Show();
        }

        private void btn_facturaCartaPdf_Click(object sender, EventArgs e)
        {
            Carta carta = new Carta();
            carta.tipo = 4;
            carta.Show();
        }

        private void btn_boleta80mmPdf_Click(object sender, EventArgs e)
        {
            Formato80 f80 = new Formato80();
            f80.tipo = 1;
            f80.Show();
        }

        private void btn_boleta80mmBase64_Click(object sender, EventArgs e)
        {
            Formato80 f80 = new Formato80();
            f80.tipo = 2;
            f80.Show();
        }
    }
}
