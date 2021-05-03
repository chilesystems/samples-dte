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

namespace DemoEndPoints.RCOF
{
    public partial class GenerarRCOFInvalido : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarRcof"];
        string apikey = ConfigurationManager.AppSettings["apikey"];
        string index="";
        public int tipo;
        OpenFileDialog dialog;
        List<ResumenInvalido> resumenes = new List<ResumenInvalido>();
        List<Rangos> anulados=new List<Rangos>();
        List<Rangos> utilizados=new List<Rangos>();
        public GenerarRCOFInvalido()
        {
            InitializeComponent();
        }

        private void btn_agregarUtilizados_Click(object sender, EventArgs e)
        {
            
            Rangos utilizado = new Rangos();
            utilizado.Inicial = int.Parse(txt_utilizadosInicial.Text);
            utilizado.Final = int.Parse(txt_utilizadosFinal.Text);
            utilizados.Add(utilizado);
            grid_utilizados.DataSource = null;
            grid_utilizados.DataSource = utilizados;

            txt_utilizadosInicial.Text = "0";
            txt_utilizadosFinal.Text = "0";
        }

        private void btn_agregarAnulados_Click(object sender, EventArgs e)
        {
            
            Rangos anulado = new Rangos();
            anulado.Inicial = int.Parse(txt_anuladosInicial.Text);
            anulado.Final = int.Parse(txt_anuladosFinal.Text);
            anulados.Add(anulado);
            grid_anulados.DataSource = null;
            grid_anulados.DataSource = anulados;

            txt_anuladosFinal.Text = "0";
            txt_anuladosInicial.Text = "0";
        }

        private void GenerarRCOFInvalido_Load(object sender, EventArgs e)
        {
            lbl_rangoAF.Visible = false;
            lbl_rangoAI.Visible = false;
            lbl_rangoUF.Visible = false;
            lbl_rangoUI.Visible = false;
            txt_anuladosInicial.Visible = false;
            txt_utilizadosInicial.Visible = false;
            txt_anuladosFinal.Visible = false;
            txt_utilizadosFinal.Visible = false;
            btn_agregarAnulados.Visible = false;
            btn_agregarUtilizados.Visible = false;
            btn_agregarDetalles.Visible = false;
            btn_eliminarResumen.Visible = false;
            cargar();
            grid_resumen.ReadOnly = true;
        }
        public void cargar()
        {
            if (tipo==1)
            {
                txt_rutEmisor.Text = "13152240-1";
                txt_rutEnvia.Text = "13152240-1";
                txt_numResol.Text = "0";
                txt_numSecEnvio.Text = "2";
                dp_fechaResol.Value = new DateTime(2020,12,11);
                dp_fechaInicio.Value = new DateTime(2020, 12, 11);
                dp_fechaFinal.Value = new DateTime(2020, 12, 11);
                dp_tmstFirma.Value = new DateTime(2020, 12, 11,15,17,22);
                List<Rangos>uti = new List<Rangos>();
                List<Rangos> anul=new List<Rangos>();


                /*
                ResumenInvalido resumen1 = new ResumenInvalido();
                resumen1.TipoDocumento = 39;
                resumen1.MntNeto = 43832;
                resumen1.MntIva = 8328;
                resumen1.TasaIVA = 19;
                resumen1.MntExento = 2000;
                resumen1.MntTotal = 54160;
                resumen1.FoliosEmitidos = 5;
                resumen1.FoliosAnulados = 0;
                resumen1.FoliosUtilizados = 5;
                resumen1.RangoUtilizados = uti;
                resumen1.RangoAnulados = anul;
                */

                uti.Add(new Rangos(6, 10));
                anul.Add(new Rangos(11, 12));
                resumenes.Add(new ResumenInvalido(39,43832, 8328, 19, 2000, 54160,5,0,5,uti,anul));

                resumenes.Add(new ResumenInvalido(41, 43832, 8328, 19, 2000, 54160, 5, 0, 5, uti, anul));

                resumenes.Add(new ResumenInvalido(61, 43832, 8328, 19, 2000, 54160, 5, 0, 5, uti, anul));
                
                resumenes.Add(new ResumenInvalido(39, 43832, 8328, 19, 2000, 54160, 5, 0, 5, uti, anul));



                grid_anulados.DataSource = anul;
                grid_utilizados.DataSource = uti;
                grid_resumen.DataSource = resumenes;
                grid_resumen.ClearSelection();

                txt_rutCertificado.Text = "17096073-4";
                txt_passCertificado.Text = "Pollito702";
                
            }
            else if(tipo == 2)
            {
                txt_rutEmisor.Text = "13152240-1";
                txt_rutEnvia.Text = "13152240-1";
                txt_numResol.Text = "0";
                txt_numSecEnvio.Text = "2";
                dp_fechaResol.Value = new DateTime(2020, 12, 11);
                dp_fechaInicio.Value = new DateTime(2020, 12, 11);
                dp_fechaFinal.Value = new DateTime(2020, 12, 11);
                dp_tmstFirma.Value = new DateTime(2020, 12, 11, 15, 17, 22);
                List<Rangos> uti = new List<Rangos>();
                List<Rangos> anul = new List<Rangos>();


                /*
                ResumenInvalido resumen1 = new ResumenInvalido();
                resumen1.TipoDocumento = 39;
                resumen1.MntNeto = 43832;
                resumen1.MntIva = 8328;
                resumen1.TasaIVA = 19;
                resumen1.MntExento = 2000;
                resumen1.MntTotal = 54160;
                resumen1.FoliosEmitidos = 5;
                resumen1.FoliosAnulados = 0;
                resumen1.FoliosUtilizados = 5;
                resumen1.RangoUtilizados = uti;
                resumen1.RangoAnulados = anul;
                */

                uti.Add(new Rangos(6, 10));
                anul.Add(new Rangos(11, 12));
                resumenes.Add(new ResumenInvalido(39, 43832, 8328, 19, 2000, 54160, 5, 0, 5, uti, anul));

                resumenes.Add(new ResumenInvalido(41, 43832, 8328, 19, 2000, 54160, 5, 0, 5, uti, anul));

                resumenes.Add(new ResumenInvalido(33, 43832, 8328, 19, 2000, 54160, 5, 0, 5, uti, anul));




                grid_anulados.DataSource = anul;
                grid_utilizados.DataSource = uti;
                grid_resumen.DataSource = resumenes;
                grid_resumen.ClearSelection();

                txt_rutCertificado.Text = "17096073-4";
                txt_passCertificado.Text = "Pollito702";

            }


        }

        private void btn_agregarDetalles_Click(object sender, EventArgs e)
        {
            List<Rangos>anulados1 = new List<Rangos>();
            List<Rangos>utilizados1 = new List<Rangos>();
            utilizados1 = utilizados;
            anulados1 = anulados;
            ResumenInvalido resumen = new ResumenInvalido();
            resumen.TipoDocumento = int.Parse(txt_tipoDoc.Text);
            resumen.MntNeto = int.Parse(txt_mntNeto.Text);
            resumen.MntIva = int.Parse(txt_mntIva.Text);
            resumen.TasaIVA = int.Parse(txt_tasaIva.Text);
            resumen.MntExento = int.Parse(txt_mntExento.Text);
            resumen.MntTotal = int.Parse(txt_mntTotal.Text);
            resumen.FoliosEmitidos = int.Parse(txt_foliosEmitidos.Text);
            resumen.FoliosAnulados = int.Parse(txt_foliosAnulados.Text);
            resumen.FoliosUtilizados = int.Parse(txt_foliosUtilizados.Text);
            resumen.RangoAnulados = anulados1;
            resumen.RangoUtilizados = utilizados1;

            resumenes.Add(resumen);
            grid_resumen.DataSource = null;
            grid_resumen.DataSource = resumenes;
            

            txt_tipoDoc.Text = "0";
            txt_mntNeto.Text = "0";
            txt_foliosUtilizados.Text = "0";
            txt_foliosEmitidos.Text = "0";
            txt_foliosAnulados.Text = "0";
            txt_tipoDoc.Text = "0";
            txt_mntExento.Text = "0";
            txt_mntIva.Text = "0";
            txt_tasaIva.Text = "0";
            txt_mntTotal.Text = "0";
            txt_anuladosFinal.Text = "0";
            txt_anuladosInicial.Text = "0";
            txt_utilizadosInicial.Text = "0";
            txt_utilizadosFinal.Text = "0";

            grid_anulados.DataSource = null;
            grid_utilizados.DataSource = null;
            grid_resumen.ClearSelection();
            utilizados.Clear();
            anulados.Clear();
        }

        private void btn_cargarCertificado_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            dialog.Filter = "PFX Files(*.pfx)|*.pfx";
            dialog.ShowDialog();
            txt_certificado.Text = dialog.FileName;
        }

        private void grid_resumen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        Boolean seleccionado=false;
        private void grid_resumen_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            index = grid_resumen.Rows[e.RowIndex].Index.ToString();
            
                if (seleccionado)
                {
                    
                    grid_anulados.DataSource = null;
                    grid_utilizados.DataSource = null;
                    seleccionado = false;
                    grid_resumen.Rows[e.RowIndex].Selected = false;
                }
                else
                {
                    for (int i = 0; i < resumenes.Count; i++)
                    {
                        if (resumenes[i] == resumenes[int.Parse(index)])
                        {
                            grid_anulados.DataSource = resumenes[int.Parse(index)].RangoAnulados;
                            grid_utilizados.DataSource = resumenes[int.Parse(index)].RangoUtilizados;
                            
                        }
                    }
                    seleccionado = true;
                    grid_resumen.Rows[e.RowIndex].Selected = true;
                }
                
            index = "";


        }

        private void btn_eliminarResumen_Click(object sender, EventArgs e)
        {
            if (index.ToString()!="")
            {
                DialogResult r = MessageBox.Show("¿Estas seguro de eliminar este ítem?", "Eliminar Item", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    for (int i = 0; i < resumenes.Count; i++)
                    {
                        if (resumenes[i] == resumenes[int.Parse(index)])
                        {
                            resumenes.Remove(resumenes[int.Parse(index)]);
                            if (resumenes.Count == 0)
                            {
                                grid_resumen.DataSource = null;
                            }
                            grid_resumen.DataSource = null;
                            grid_resumen.DataSource = resumenes;
                            grid_resumen.ClearSelection();
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un item de la lista de resumenes para eliminar");
            }
            
        }

        

        private async void btn_generar_Click(object sender, EventArgs e)
        {
            if (dialog == null)
            {
                MessageBox.Show("Selecciona un certificado");
            }
            else if (dialog != null)
            {
                try
                {
                    CaratulaInvalida caratula = new CaratulaInvalida();
                    caratula.RutEmisor = txt_rutEmisor.Text;
                    caratula.RutEnvia = txt_rutEnvia.Text;
                    caratula.FchResol = dp_fechaResol.Value.ToString("yyyy-MM-dd");
                    caratula.NroResol = int.Parse(txt_numResol.Text);
                    caratula.FchInicio = dp_fechaInicio.Value.ToString("yyyy-MM-dd");
                    caratula.FchFinal = dp_fechaFinal.Value.ToString("yyyy-MM-dd");
                    caratula.SecEnvio = int.Parse(txt_numSecEnvio.Text);
                    caratula.TmstFirmaEnv = dp_fechaFinal.Value.ToString();

                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.rut = txt_rutCertificado.Text;
                    certificado.password = txt_passCertificado.Text;

                    ResumenInvalido resumen = new ResumenInvalido();
                    resumen.TipoDocumento = int.Parse(txt_tipoDoc.Text);
                    resumen.MntNeto = int.Parse(txt_mntNeto.Text);
                    resumen.MntIva = int.Parse(txt_mntIva.Text);
                    resumen.TasaIVA = int.Parse(txt_tasaIva.Text);
                    resumen.MntExento = int.Parse(txt_mntExento.Text);
                    resumen.MntTotal = int.Parse(txt_mntTotal.Text);
                    resumen.FoliosEmitidos = int.Parse(txt_foliosEmitidos.Text);
                    resumen.FoliosAnulados = int.Parse(txt_foliosAnulados.Text);
                    resumen.FoliosUtilizados = int.Parse(txt_foliosUtilizados.Text);
                    resumen.RangoAnulados = anulados;
                    resumen.RangoUtilizados = utilizados;
                    RCOFInvalido rcof = new RCOFInvalido();
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
    }
}
