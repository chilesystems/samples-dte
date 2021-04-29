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
using System.Windows.Forms;

namespace DemoEndPoints.GenerarDTE
{
    public partial class GenerarDteJson : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarDteJson"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        OpenFileDialog dialogJson;
        OpenFileDialog dialogCert;
        OpenFileDialog dialogCaf;
        public GenerarDteJson()
        {
            InitializeComponent();
        }

        private void btn_json_Click(object sender, EventArgs e)
        {
            dialogJson = new OpenFileDialog();
            dialogJson.ShowDialog();
            txt_json.Text = dialogJson.FileName;
        }

        private void btn_certificado_Click(object sender, EventArgs e)
        {
            dialogCert = new OpenFileDialog();
            dialogCert.ShowDialog();
            txt_certificado.Text = dialogCert.FileName;
        }

        private void btn_caf_Click(object sender, EventArgs e)
        {
            dialogCaf = new OpenFileDialog();
            dialogCaf.ShowDialog();
            txt_caf.Text = dialogCaf.FileName;
        }

        private async void btn_generar_Click(object sender, EventArgs e)
        {
            if (dialogJson==null)
            {
                MessageBox.Show("Selecciona un archivo json");
            }
            if (dialogCert == null)
            {
                MessageBox.Show("Selecciona un certificado digital");
            }
            if (dialogCaf == null)
            {
                MessageBox.Show("Selecciona un archivo caf");
            }
            else if (dialogJson != null && dialogCaf != null && dialogCert != null)
            {
                try
                {
                    var fsJson = File.OpenRead(dialogJson.FileName);
                    var fsCert = File.OpenRead(dialogCert.FileName);
                    var fsCaf = File.OpenRead(dialogCaf.FileName);
                    var streamContentJ = new StreamContent(fsCert);
                    var streamContentC = new StreamContent(fsCert);
                    var streamContentR = new StreamContent(fsCaf);

                    HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    var certificadoByte = new ByteArrayContent(await streamContentC.ReadAsByteArrayAsync());
                    certificadoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    certificadoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogCert.FileName
                    };
                    var cafByte = new ByteArrayContent(await streamContentR.ReadAsByteArrayAsync());
                    cafByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    cafByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogCaf.FileName
                    };
                    var jsonByte = new ByteArrayContent(await streamContentR.ReadAsByteArrayAsync());
                    jsonByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    jsonByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogJson.FileName
                    };
                    //HttpContent jsonString = new StringContent(json);
                    form.Add(jsonByte);
                    form.Add(certificadoByte);
                    form.Add(cafByte);
                    /*
                    var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(pass));*/
                    HttpResponseMessage response = await client.PostAsync(url, form);
                    response.EnsureSuccessStatusCode();
                    client.Dispose();
                    string sd = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(sd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error ]: " + ex);
                }
            }
        }
    }
}
