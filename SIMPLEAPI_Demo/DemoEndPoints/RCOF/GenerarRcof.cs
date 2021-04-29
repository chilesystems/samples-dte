using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoEndPoints.RCOF;
using DemoEndPoints.Clases;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.IO;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;

namespace DemoEndPoints
{
    public partial class GenerarRcof : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarRcof"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        public int tipo;
        OpenFileDialog dialog;
        List<Resumen> resumenes=new List<Resumen>();
        public GenerarRcof()
        {
            InitializeComponent();
        }

        private void GenerarRcof_Load(object sender, EventArgs e)
        {
            llenar();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        public void llenar()
        {
            txt_rutEmisor.Text = "17938236-9";
            txt_rutEnvia.Text = "17938236-9";
            txt_numResol.Text = "99";
            txt_numSecEnvio.Text = "6";

            resumenes.Add(new Resumen(39,0,0,19,0,0,0,0,0));
            grid_resumen.DataSource = resumenes;

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";
        }
        private async void btn_generar_Click(object sender, EventArgs e)
        {
            if(dialog==null){
                MessageBox.Show("Selecciona un certificado");
            }
            else if(dialog!=null)
            {
                try
                {
                    Caratula caratula = new Caratula();
                    caratula.RutEmisor = txt_rutEmisor.Text;
                    caratula.RutEnvia = txt_rutEnvia.Text;
                    caratula.FchResol = dp_fechaResol.Value.ToString("yyyy-MM-dd");
                    caratula.NroResol = int.Parse(txt_numResol.Text);
                    caratula.FchInicio = dp_fechaInicio.Value.ToString("yyyy-MM-dd");
                    caratula.FchFinal = dp_fechaFinal.Value.ToString("yyyy-MM-dd");
                    caratula.SecEnvio = int.Parse(txt_numSecEnvio.Text);

                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.rut = txt_rutCertificado.Text;
                    certificado.password = txt_passCertificado.Text;

                    Resumen resumen = new Resumen();
                    resumen.TipoDocumento = int.Parse(txt_tipoDoc.Text);
                    resumen.MntNeto = int.Parse(txt_mntNeto.Text);
                    resumen.MntIva = int.Parse(txt_mntIva.Text);
                    resumen.TasaIVA = int.Parse(txt_tasaIva.Text);
                    resumen.MntExento = int.Parse(txt_mntExento.Text);
                    resumen.MntTotal = int.Parse(txt_mntTotal.Text);
                    resumen.FoliosEmitidos = int.Parse(txt_foliosEmitidos.Text);
                    resumen.FoliosAnulados = int.Parse(txt_foliosAnulados.Text);
                    resumen.FoliosUtilizados = int.Parse(txt_foliosUtilizados.Text);
                    RCOF.RCOF rcof = new RCOF.RCOF();
                    rcof.Caratula = caratula;
                    rcof.Resumen = resumenes;
                    rcof.CertificadoDigital = certificado;

                    var json = new JavaScriptSerializer().Serialize(rcof);
                    var fs = File.OpenRead(dialog.FileName);
                    var streamContent = new StreamContent(fs);
                    //byte[] cert = File.ReadAllBytes(dialog.FileName); 
                    
                        HttpClient client = new HttpClient();
                        MultipartFormDataContent form = new MultipartFormDataContent();
                        var passByte = new ByteArrayContent(
                            await streamContent.ReadAsByteArrayAsync());
                        passByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        passByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "files",
                            FileName = dialog.FileName
                        };
                        HttpContent jsonString = new StringContent(json);
                        form.Add(jsonString, "input");
                        form.Add(passByte);

                        var pass = Encoding.GetEncoding("ISO-8859-1").GetBytes("api:2318-J320-6378-2229-4600");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(pass));
                        HttpResponseMessage response = await client.PostAsync(url, form);
                        response.EnsureSuccessStatusCode();
                        client.Dispose();
                        string sd = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(sd);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            
            
        }

        private void btn_cargarCertificado_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Filter = "PFX Files(*.pfx)|*.pfx";
            dialog.ShowDialog();
            txt_certificado.Text = dialog.FileName;
        }

        private void btn_agregarDetalles_Click(object sender, EventArgs e)
        {
            Resumen resumen = new Resumen();
            resumen.TipoDocumento = int.Parse(txt_tipoDoc.Text);
            resumen.MntNeto = int.Parse(txt_mntNeto.Text);
            resumen.MntIva = int.Parse(txt_mntIva.Text);
            resumen.TasaIVA = int.Parse(txt_tasaIva.Text);
            resumen.MntExento = int.Parse(txt_mntExento.Text);
            resumen.MntTotal = int.Parse(txt_mntTotal.Text);
            resumen.FoliosEmitidos = int.Parse(txt_foliosEmitidos.Text);
            resumen.FoliosAnulados = int.Parse(txt_foliosAnulados.Text);
            resumen.FoliosUtilizados = int.Parse(txt_foliosUtilizados.Text);
            resumenes.Add(resumen);
            grid_resumen.DataSource = null;
            grid_resumen.DataSource = resumenes;

            txt_tipoDoc.Text = "0";
            txt_mntNeto.Text = "0";
            txt_foliosUtilizados.Text = "0";
            txt_foliosEmitidos.Text = "0";
            txt_foliosAnulados.Text = "0";
            txt_tipoDoc.Text = "0";
            txt_mntIva.Text = "0";
            txt_tasaIva.Text = "0";
            txt_mntTotal.Text = "0";


        }
    }
}
