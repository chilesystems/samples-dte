using DemoEndPoints.Clases;
using DemoEndPoints.RCOF;
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

namespace DemoEndPoints
{
    public partial class EnviarRcof : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["EnviarRcof"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        OpenFileDialog dialogC;
        OpenFileDialog dialogR;
        public EnviarRcof()
        {
            InitializeComponent();
        }

        private void btn_cargarCertificado_Click(object sender, EventArgs e)
        {
            dialogC = new OpenFileDialog();
            dialogC.Filter = "PFX Files(*.pfx)|*.pfx";
            dialogC.ShowDialog();
            txt_certificado.Text = dialogC.FileName;
        }

        private void btn_cargarRcof_Click(object sender, EventArgs e)
        {
            dialogR = new OpenFileDialog();
            dialogR.Filter = "XML Files(*.xml)|*.xml";
            dialogR.ShowDialog();
            txt_rcof.Text = dialogR.FileName;
        }

        private async void btn_enviarRcof_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialogC == null)
                {
                    MessageBox.Show("Selecciona un certificado para continuar");
                }
                else if (dialogR == null)
                {
                    MessageBox.Show("Selecciona un RCOF para continuar");
                }
                else
                {
                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.rut = txt_rutCertificado.Text;
                    certificado.password = txt_passCertificado.Text;

                    Enviar enviarRcof = new Enviar();
                    enviarRcof.CertificadoDigital = certificado;
                    enviarRcof.RutEmisor = txt_rutEmisor.Text;
                    enviarRcof.RutReceptor = txt_rutReceptor.Text;
                    enviarRcof.NumeroResolucion = int.Parse(txt_numResolucion.Text);
                    enviarRcof.FechaResolucion = dp_fechaResolucion.Value.ToString("yyyy-MM-dd");
                    if (chbx_produccionSi.Checked)
                    {
                        enviarRcof.Produccion = true;

                    }
                    else
                    {
                        enviarRcof.Produccion = false;
                    }

                    var json = new JavaScriptSerializer().Serialize(enviarRcof);
                    var fsC = File.OpenRead(dialogC.FileName);
                    var fsR = File.OpenRead(dialogR.FileName);
                    var streamContentC = new StreamContent(fsC);
                    var streamContentR = new StreamContent(fsR);

                    HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    var certificadoByte = new ByteArrayContent(await streamContentC.ReadAsByteArrayAsync());
                    certificadoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    certificadoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogC.FileName
                    };
                    var rcofByte = new ByteArrayContent(await streamContentR.ReadAsByteArrayAsync());
                    rcofByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    rcofByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogR.FileName
                    };
                    HttpContent jsonString = new StringContent(json);
                    form.Add(jsonString, "input");
                    form.Add(certificadoByte);
                    form.Add(rcofByte);

                    var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(pass));
                    HttpResponseMessage response = await client.PostAsync(url, form);
                    response.EnsureSuccessStatusCode();
                    client.Dispose();
                    string sd = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(sd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : "+ex);
            }
            

           
        }

        public void cargar()
        {
            txt_rutEmisor.Text = "17938236-9";
            txt_rutReceptor.Text = "60803000-K";
            txt_numResolucion.Text = "99";

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";
        }
        private void EnviarRcof_Load(object sender, EventArgs e)
        {

            cargar();
        }

        private void chbx_produccionSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_produccionSi.Checked)
            {
                chbx_produccionNo.Checked = false;
            }
        }

        private void chbx_produccionNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_produccionNo.Checked)
            {
                chbx_produccionSi.Checked = false;
            }
        }
    }
}
