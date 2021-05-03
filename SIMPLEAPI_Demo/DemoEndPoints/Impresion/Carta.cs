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
    public partial class Carta : Form
    {
        string url = ConfigurationManager.AppSettings["url"];
        string apikey = ConfigurationManager.AppSettings["apikey"];
        public int tipo;
        OpenFileDialog dialogD;
        OpenFileDialog dialogL;
        public Carta()
        {
            InitializeComponent();
        }

        private void btn_archivo_Click(object sender, EventArgs e)
        {
            dialogD = new OpenFileDialog();
            dialogD.Filter = "XML Files (*.xml)|*.xml";
            dialogD.ShowDialog();
            txt_archivo.Text = dialogD.FileName;
        }

        private void btn_logo_Click(object sender, EventArgs e)
        {
            dialogL = new OpenFileDialog();
            dialogL.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
            dialogL.ShowDialog();
            txt_logo.Text = dialogL.FileName;
        }

        private async void btn_enviar_Click(object sender, EventArgs e)
        {
            if (dialogD == null)
            {
                MessageBox.Show("Seleccione el archivo necesario para continuar");
            }
            else if(dialogL==null)
            {
                MessageBox.Show("Seleccione el logo necesario para continuar");
            }
            else if(dialogD != null && dialogL != null)
            {
                try
                {
                    if (tipo == 1)
                    {
                        url = url + ConfigurationManager.AppSettings["BoletaCartaPdf"];
                    }
                    else if (tipo == 2)
                    {
                        url = url + ConfigurationManager.AppSettings["BoletaCartaBase64"];
                    }
                    else if (tipo == 3)
                    {
                        url = url + ConfigurationManager.AppSettings["FacturaCartaBase64"];
                    }
                    else if (tipo == 4)
                    {
                        url = url + ConfigurationManager.AppSettings["FacturaCartaPdf"];
                    }

                    CartaDte carta = new CartaDte();
                    carta.NumeroResolucion = int.Parse(txt_numResolucion.Text);
                    carta.UnidadSII = txt_unidadSii.Text;
                    carta.FechaResolucion = dp_fechaResolucion.Value.ToString("yyyy-MM-dd");

                    var json = new JavaScriptSerializer().Serialize(carta);
                    var fsD = File.OpenRead(dialogD.FileName);
                    var streamContentD = new StreamContent(fsD);

                    var fsL = File.OpenRead(dialogD.FileName);
                    var streamContentL = new StreamContent(fsL);

                    HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    var archivoByte = new ByteArrayContent(await streamContentD.ReadAsByteArrayAsync());
                    archivoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    archivoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "fileEnvio",
                        FileName = dialogD.SafeFileName
                    };
                    var logoByte = new ByteArrayContent(await streamContentL.ReadAsByteArrayAsync());
                    archivoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    archivoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "logo",
                        FileName = dialogL.SafeFileName
                    };

                    HttpContent jsonString = new StringContent(json);
                    form.Add(jsonString, "input");
                    form.Add(archivoByte);
                    form.Add(logoByte);
                    
                    var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(pass));
                    HttpResponseMessage response = await client.PostAsync(url, form);
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

        private void Carta_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            if (tipo==1 || tipo==2)
            {
                txt_numResolucion.Text = "90";
                txt_unidadSii.Text = "IQUIQUE";
                dp_fechaResolucion.Value = new DateTime(2021,02,16);
            }
            else if (tipo == 3 || tipo == 4)
            {
                txt_numResolucion.Text = "80";
                txt_unidadSii.Text = "ALTO HOSPICIO";
                dp_fechaResolucion.Value = new DateTime(2021,02,16);
            }
            
        }
    }
}
