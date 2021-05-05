using DemoEndPoints.Clases;
using DemoEndPoints.GenerarDTE;
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
    public partial class ConsultarEstadoEnvio : Form
    {
        string url = ConfigurationManager.AppSettings["urlLocal"]+ ConfigurationManager.AppSettings["ConsultarEstadoEnvio"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        OpenFileDialog dialogC;
        public ConsultarEstadoEnvio()
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

        private async void btn_consultar_Click(object sender, EventArgs e)
        {
            if (dialogC==null)
            {
                MessageBox.Show("Selecciona un certificado digital para continuar");
            }
            else if(dialogC!=null)
            {
                try
                {
                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.rut = txt_rutCertificado.Text;
                    certificado.password = txt_passCertificado.Text;

                    ConsultaDte consulta = new ConsultaDte();
                    consulta.CertificadoDigital = certificado;
                    consulta.RutEmpresa = int.Parse(txt_rutEmpresa.Text);
                    consulta.RutEmpresaDigito = txt_dvEmpresa.Text;
                    consulta.TrackId = int.Parse(txt_trackId.Text);
                    if (chbx_produccionSi.Checked)
                    {
                        consulta.Produccion = true;
                    }
                    else
                    {
                        consulta.Produccion = false;
                    }
                    if (chbx_boletaRestSi.Checked)
                    {
                        consulta.ServidorBoletaREST = true;
                    }
                    else
                    {
                        consulta.ServidorBoletaREST = false;
                    }
                    var json = new JavaScriptSerializer().Serialize(consulta);
                    var fsC = File.OpenRead(dialogC.FileName);
                    var streamContentC = new StreamContent(fsC);

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
                   
                    HttpContent jsonString = new StringContent(json);
                    form.Add(jsonString, "input");
                    form.Add(certificadoByte);

                    var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(pass));
                    HttpResponseMessage response = await client.PostAsync(url,form);
                    response.EnsureSuccessStatusCode();
                    client.Dispose();
                    string sd = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(sd);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex);
                }
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

        private void chbx_boletaRestSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_boletaRestSi.Checked)
            {
                chbx_boletaRestNo.Checked = false;
            }
        }

        private void chbx_boletaRestNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_boletaRestNo.Checked)
            {
                chbx_boletaRestSi.Checked = false;
            }
        }

        private void ConsultarEstadoEnvio_Load(object sender, EventArgs e)
        {
            cargar();
        }
        public void cargar()
        {
            txt_rutEmpresa.Text = "17096073";
            txt_dvEmpresa.Text = "4";
            txt_trackId.Text = "107204338";
            chbx_boletaRestNo.Checked = true;
            chbx_produccionNo.Checked = true;

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";
        }
    }
}
