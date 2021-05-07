using DemoEndPoints.RCOF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DemoEndPoints.GenerarJson
{
    public partial class JsonEnvio : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonEnvio"];

        public JsonEnvio()
        {
            InitializeComponent();
        }

        private async void JsonEnvio_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            Enviar json = new JavaScriptSerializer().Deserialize<Enviar>(response);
            txt_jsonEnvio.Text = response;
            lbl_rutCert.Text = json.CertificadoDigital.rut;
            lbl_passCert.Text = json.CertificadoDigital.password;
            lbl_numResol.Text = json.NumeroResolucion.ToString();
            lbl_rutRecep.Text = json.RutReceptor;
            lbl_rutEmisor.Text = json.RutEmisor;
            lbl_fecha.Text = json.FechaResolucion;
            if (json.Produccion)
            {
                lbl_Produccion.Text = "Si";
            }
            else
            {
                lbl_Produccion.Text = "No";
            }
            
        }
        
    }
}
