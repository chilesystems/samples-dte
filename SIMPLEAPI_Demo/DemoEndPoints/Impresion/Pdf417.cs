using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Drawing;
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
using System.Xml;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace DemoEndPoints.Impresion
{
    public partial class Pdf417 : Form
    {
        string url = ConfigurationManager.AppSettings["urlLocal"];
        string apikey = ConfigurationManager.AppSettings["apikey"];
        public int tipo;
        OpenFileDialog dialog;
        public Pdf417()
        {
            InitializeComponent();
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Filter = "XML Files (*.xml)|*.xml";
            dialog.ShowDialog();
            txt_archivo.Text = dialog.FileName;
        }

        private async void btn_enviar_Click(object sender, EventArgs e)
        {
            if (dialog == null)
            {
                MessageBox.Show("Seleccione el archivo necesario para continuar");
            }
            else
            {
                try
                {
                    if (tipo == 1)
                    {
                        url = url + ConfigurationManager.AppSettings["Pdf417Dte"];
                    }
                    else if (tipo == 2)
                    {
                        url = url + ConfigurationManager.AppSettings["Pdf417Envio"];
                    }

                    //var json = new JavaScriptSerializer().Serialize(dte);
                    var fs = File.OpenRead(dialog.FileName);
                    var streamContent = new StreamContent(fs);

                    HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    var archivoByte = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
                    archivoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    archivoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "fileEnvio",
                        FileName = dialog.SafeFileName
                    };
                    
                    
                    form.Add(archivoByte);
                    /*
                    var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(pass));*/
                    HttpResponseMessage response = await client.PostAsync(url, form);
                    response.EnsureSuccessStatusCode();
                    client.Dispose();
                    string sd = await response.Content.ReadAsStringAsync();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(sd);
                    
                    sd= doc.DocumentElement.FirstChild.InnerText;
                    
                    var ruta = @"C:\Users\McL\source\repos\samples-dte\SIMPLEAPI_Demo\DemoEndPoints\" + DateTime.Now.Ticks.ToString() + ".jpg";

                    byte[] bytes = Convert.FromBase64String(sd);
                    System.IO.FileStream stream =
                    new FileStream(ruta, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    img.ImageLocation = ruta;
                    MessageBox.Show("Exito");
                    url = ConfigurationManager.AppSettings["urlLocal"];
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error : "+ex);
                    url = ConfigurationManager.AppSettings["urlLocal"];
                }
            }
            


        }

        private void Pdf417_Load(object sender, EventArgs e)
        {
            if (tipo==2)
            {
                lbl_archivo.Text = "Selecciona el envio :";
            }
        }
    }
}
