using DemoEndPoints.Clases;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DemoEndPoints.GenerarJson
{
    public partial class JsonPdf : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonPdf"];

        public JsonPdf()
        {
            InitializeComponent();
        }

        private  void JsonPdf_Load(object sender, EventArgs e)
        {
           
        }

        private  void btn_generar_Click(object sender, EventArgs e)
        {
            formato80mm f = new formato80mm();
            f.NumeroResolucion = int.Parse(txt_numResolucion.Text);
            f.UnidadSII = txt_unidadSii.Text;
            f.FechaResolucion = dp_fechaResolucion.Value.ToString("yyyy-MM-dd");
            f.Ejecutivo = txt_ejecutivo.Text;
            if (DateTime.Now.Second<10)
            {
                f.Hora = DateTime.Now.Hour.ToString() + ":0" + DateTime.Now.Minute.ToString();
            }
            else
            {
                f.Hora = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            }
            

            var json = new JavaScriptSerializer().Serialize(f);
            txt_jsonPdf.Text = json;
        }

        private async void cargar()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            
            formato80mm json = new JavaScriptSerializer().Deserialize<formato80mm>(response);

            txt_jsonPdf.Text = response;
            txt_ejecutivo.Text = json.Ejecutivo;
            txt_numResolucion.Text = json.NumeroResolucion.ToString();
            txt_unidadSii.Text = json.UnidadSII;
            json.FechaResolucion = null;
            if (json.FechaResolucion == null)
            {
                dp_fechaResolucion.Visible=false;
            }
            else
            {
                dp_fechaResolucion.Value = DateTime.Parse(json.FechaResolucion);
            }
            


        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_jsonPdf.Text = "";
            txt_ejecutivo.Text = "";
            txt_numResolucion.Text = "0";
            txt_unidadSii.Text = "";
            dp_fechaResolucion.Value = DateTime.Now;
            if (!dp_fechaResolucion.Visible)
            {
                dp_fechaResolucion.Visible = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_jsonPdf_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
