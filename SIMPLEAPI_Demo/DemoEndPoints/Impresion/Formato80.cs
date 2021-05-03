using DemoEndPoints.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DemoEndPoints.Impresion
{
    public partial class Formato80 : Form
    {
        string url = ConfigurationManager.AppSettings["url"];
        string apikey = ConfigurationManager.AppSettings["apikey"];
        public int tipo;
        OpenFileDialog dialogB;
        public Formato80()
        {
            InitializeComponent();
        }

        private void btn_archivo_Click(object sender, EventArgs e)
        {
            dialogB = new OpenFileDialog();
            dialogB.Filter = "XML Files (*.xml)|*.xml";
            dialogB.ShowDialog();
            txt_archivo.Text = dialogB.FileName;
        }

        private  async void btn_enviar_Click(object sender, EventArgs e)
        {
            if (dialogB == null)
            {
                MessageBox.Show("Seleccione la boleta para continuar");
            }
            else
            {
                try
                {
                    if (tipo == 1)
                    {
                        url = url + ConfigurationManager.AppSettings["Boleta80mmPdf"];
                    }
                    else if (tipo == 2)
                    {
                        url = url + ConfigurationManager.AppSettings["Boleta80mmBase64"];
                    }
                    formato80mm f = new formato80mm();
                    f.NumeroResolucion = int.Parse(txt_numResolucion.Text);
                    f.UnidadSII = txt_unidadSii.Text;
                    f.FechaResolucion = dp_fechaResolucion.Value.ToString("yyyy-MM-dd");
                    f.Ejecutivo = txt_ejecutivo.Text;
                    f.Hora = dp_fechaResolucion.Value.ToString("HH:mm");

                    var json = new JavaScriptSerializer().Serialize(f);
                    var fs = File.OpenRead(dialogB.FileName);
                    var streamContent = new StreamContent(fs);

                    HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    var archivoByte = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
                    archivoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    archivoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "fileEnvio",
                        FileName = dialogB.SafeFileName
                    };
                    HttpContent jsonString = new StringContent(json);
                    form.Add(jsonString, "input");
                    form.Add(archivoByte);

                    var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(pass));
                    HttpResponseMessage response = await client.GetAsync(url /*,form*/);
                    response.EnsureSuccessStatusCode();
                    client.Dispose();
                    string sd = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(sd);
                     url = ConfigurationManager.AppSettings["url"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex);
                    url = ConfigurationManager.AppSettings["url"];
                }
            }
        }

        private void Formato80_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            txt_numResolucion.Text = "0";
            txt_unidadSii.Text = "IQUIQUE";
            dp_fechaResolucion.Value = new DateTime(2021, 02, 16,13,20,0);
            txt_ejecutivo.Text = "Gonzalo Bustamante";
        }
    }
}
