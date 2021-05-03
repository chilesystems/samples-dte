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
    public partial class EnvioDte : Form
    {
        public int tipo;
        string url = ConfigurationManager.AppSettings["url"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        OpenFileDialog dialogC;
        OpenFileDialog dialogD;
        public EnvioDte()
        {
            InitializeComponent();
        }

        private void EnvioDte_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btn_cargarCertificado_Click(object sender, EventArgs e)
        {
            dialogC = new OpenFileDialog();
            dialogC.Filter = "PFX Files(*.pfx)|*.pfx";
            dialogC.ShowDialog();
            txt_certificado.Text = dialogC.FileName;
        }

        private void btn_cargarDte_Click(object sender, EventArgs e)
        {
            dialogD = new OpenFileDialog();
            dialogD.Filter = "XML Files(*.xml)|*.xml";
            dialogD.ShowDialog();
            txt_dte.Text = dialogD.FileName;
        }

        private async void btn_enviarDte_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialogC == null)
                {
                    MessageBox.Show("Selecciona un certificado para continuar");
                }
                else if (dialogD == null)
                {
                    MessageBox.Show("Selecciona un Dte para continuar");
                }
                else
                {

                    if (tipo==1)
                    {
                        url = url + ConfigurationManager.AppSettings["GenerarEnvioDte"];
                    }
                    else if (tipo == 2)
                    {
                        url = url + ConfigurationManager.AppSettings["GenerarEnvioBoleta"];
                    }
                    else if (tipo == 3)
                    {
                        url = url + ConfigurationManager.AppSettings["EnviarEnvioDte"];
                    }
                    else if (tipo == 4)
                    {
                        url = url + ConfigurationManager.AppSettings["EnviarEnvioBoleta"];
                    }
                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.rut = txt_rutCertificado.Text;
                    certificado.password = txt_passCertificado.Text;

                    Enviar enviarDte = new Enviar();
                    enviarDte.CertificadoDigital = certificado;
                    enviarDte.RutEmisor = txt_rutEmisor.Text;
                    enviarDte.RutReceptor = txt_rutReceptor.Text;
                    enviarDte.NumeroResolucion = int.Parse(txt_numResolucion.Text);
                    enviarDte.FechaResolucion = dp_fechaResolucion.Value.ToString("yyyy-MM-dd");
                    if (chbx_produccionSi.Checked)
                    {
                        enviarDte.Produccion = true;

                    }
                    else
                    {
                        enviarDte.Produccion = false;
                    }

                    var json = new JavaScriptSerializer().Serialize(enviarDte);
                    var fsC = File.OpenRead(dialogC.FileName);
                    var fsD = File.OpenRead(dialogD.FileName);
                    var streamContentC = new StreamContent(fsC);
                    var streamContentD = new StreamContent(fsD);

                    HttpClient client = new HttpClient();
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    var certificadoByte = new ByteArrayContent(await streamContentC.ReadAsByteArrayAsync());
                    certificadoByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    certificadoByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogC.SafeFileName
                    };
                    var dteByte = new ByteArrayContent(await streamContentD.ReadAsByteArrayAsync());
                    dteByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    dteByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogD.SafeFileName
                    };
                    HttpContent jsonString = new StringContent(json);
                    form.Add(jsonString, "input");
                    form.Add(certificadoByte);
                    form.Add(dteByte);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
                url = ConfigurationManager.AppSettings["url"];
            }
        }
        public void cargar()
        {
            if (tipo==1)
            {
                txt_rutEmisor.Text = "76269769-6";
                txt_rutReceptor.Text = "60803000-K";
                txt_numResolucion.Text = "0";
                chbx_produccionNo.Checked = true;
                dp_fechaResolucion.Value = new DateTime(2020, 12, 17);

                txt_rutCertificado.Text = "17096073-4";
                txt_passCertificado.Text = "Pollito702";

                lbl_tipo.Text = "Selecciona un DTE ";
            }
            else if (tipo == 2)
            {
                txt_rutEmisor.Text = "77021118-2";
                txt_rutReceptor.Text = "6666666-6";
                txt_numResolucion.Text = "0";
                chbx_produccionNo.Checked = true;
                dp_fechaResolucion.Value = new DateTime(2021, 01, 12);

                txt_rutCertificado.Text = "17096073-4";
                txt_passCertificado.Text = "Pollito702";

                lbl_tipo.Text = "Selecciona un DTE boleta";
            }
            else if (tipo == 3)
            {
                txt_rutEmisor.Text = "76269769-6";
                txt_rutReceptor.Text = "60803000-K";
                txt_numResolucion.Text = "0";
                chbx_produccionNo.Checked = true;
                dp_fechaResolucion.Value = new DateTime(2020, 12, 17);

                txt_rutCertificado.Text = "17096073-4";
                txt_passCertificado.Text = "Pollito702";

                lbl_tipo.Text = "Selecciona un envio DTE ";
            }
            else if (tipo == 4)
            {
                txt_rutEmisor.Text = "76269769-6";
                txt_rutReceptor.Text = "60803000-K";
                txt_numResolucion.Text = "0";
                chbx_produccionNo.Checked = true;
                dp_fechaResolucion.Value = new DateTime(2020, 12, 17);

                txt_rutCertificado.Text = "17096073-4";
                txt_passCertificado.Text = "Pollito702";

                lbl_tipo.Text = "Selecciona un envio DTE boleta ";
            }

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
