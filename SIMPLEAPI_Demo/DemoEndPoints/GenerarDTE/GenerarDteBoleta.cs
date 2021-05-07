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

namespace DemoEndPoints.GenerarDTE
{
    public partial class GenerarDteBoleta : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarDte"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        string indexD = "";
        OpenFileDialog dialogCert;
        OpenFileDialog dialogCaf;
        List<Detalles> detalles = new List<Detalles>();
        Boolean detSeleccionado;
        string detIndexSeleccionada;
        public GenerarDteBoleta()
        {
            InitializeComponent();
        }

        private void btn_cargarCertificado_Click(object sender, EventArgs e)
        {
            dialogCert = new OpenFileDialog();
            dialogCert.Filter = "PFX Files(*.pfx)|*.pfx";
            dialogCert.ShowDialog();
            txt_certificado.Text = dialogCert.FileName;
        }

        private void btn_caf_Click(object sender, EventArgs e)
        {
            dialogCaf = new OpenFileDialog();
            dialogCaf.Filter = "XML Files(*.xml)|*.xml";
            dialogCaf.ShowDialog();
            txt_caf.Text = dialogCaf.FileName;
        }

        private void btn_agregarDetalles_Click(object sender, EventArgs e)
        {
            Detalles item = new Detalles();
            item.nombre = txt_nombreDetalles.Text;
            item.cantidad = int.Parse(txt_cantidadDetalles.Text);
            item.precio = int.Parse(txt_precioDetalles.Text);
            item.total = int.Parse(txt_totalDetalles.Text);
            item.descuento = int.Parse(txt_descuentoDetalles.Text);
            if (chbx_exentoSi.Checked)
            {
                item.isExento = true;
            }
            else
            {
                item.isExento = false;
            }
            detalles.Add(item);
            grid_detalles.DataSource = null;
            grid_detalles.DataSource = detalles;
            txt_nombreDetalles.Text = "";
            txt_cantidadDetalles.Text = "0";
            txt_precioDetalles.Text = "0";
            txt_totalDetalles.Text = "0";
            txt_descuentoDetalles.Text = "0";
            chbx_exentoSi.Checked = true;
            chbx_exentoNo.Checked = false;

            grid_detalles.ClearSelection();
        }

        private async void btn_generarDTE_Click(object sender, EventArgs e)
        {
            try
            {

                if (dialogCert == null || dialogCert.FileName=="")
                {
                    MessageBox.Show("Seleccione un certificado digital para continuar");
                }
                else if (dialogCaf == null || dialogCaf.FileName == "")
                {
                    MessageBox.Show("Seleccione un archivo caf para continuar");
                }
                else if (dialogCert != null && dialogCaf != null)
                {

                    Receptor receptor = new Receptor();
                    receptor.rut = txt_rutReceptor.Text;
                    receptor.razonSocial = txt_razonSocialReceptor.Text;
                    receptor.comuna = txt_comunaReceptor.Text;
                    receptor.giro = txt_giroReceptor.Text;
                    receptor.direccion = txt_direccionReceptor.Text;
                    receptor.ciudad = txt_ciudadReceptor.Text;

                    EmisorBoleta emisor = new EmisorBoleta();
                    emisor.rut = txt_rutEmisor.Text;
                    emisor.razonSocial = txt_razonSocialEmisor.Text;
                    emisor.comuna = txt_comunaEmisor.Text;
                    emisor.giro = txt_giroEmisor.Text;
                    emisor.direccion = txt_direccionEmisor.Text;
                    emisor.telefono = int.Parse(txt_telefonoEmisor.Text);

                    Encabezado encabezado = new Encabezado();
                    encabezado.folio = int.Parse(txt_folioEncabezado.Text);
                    encabezado.tipoDTE = int.Parse(txt_tipoDteEncabezado.Text);
                    encabezado.fechaEmision = dp_fechaEmisionEncabezado.Value.ToString("yyyy-MM-dd"); ;

                    TotalesBoleta totales = new TotalesBoleta();
                    totales.neto = int.Parse(txt_netoTotales.Text);
                    totales.iva = int.Parse(txt_ivaTotales.Text);
                    totales.total = int.Parse(txt_totalTotales.Text);


                    OtrosDTEBoleta otros = new OtrosDTEBoleta();
                    otros.indicadorServicio = int.Parse(txt_indicarServOtros.Text);

                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.password = txt_passCertificado.Text;
                    certificado.rut = txt_rutCertificado.Text;

                    DTEBoleta dte = new DTEBoleta();
                    dte.receptor = receptor;
                    dte.emisor = emisor;
                    dte.detalles = detalles;
                    dte.encabezado = encabezado;
                    dte.totales = totales;
                    dte.otrosDTE = otros;
                    dte.certificadoDigital = certificado;

                    var json = new JavaScriptSerializer().Serialize(dte);
                    var fsCert = File.OpenRead(dialogCert.FileName);
                    var fsCaf = File.OpenRead(dialogCaf.FileName);
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
                        FileName = dialogCert.SafeFileName
                    };
                    var cafByte = new ByteArrayContent(await streamContentR.ReadAsByteArrayAsync());
                    cafByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    cafByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogCaf.SafeFileName
                    };
                    HttpContent jsonString = new StringContent(json);
                    form.Add(jsonString, "input");
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
                    Resultado resultado = new Resultado();
                    resultado.json = json;
                    resultado.xml = sd;
                    resultado.response = response;
                    resultado.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void chbx_exentoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_exentoNo.Checked)
            {
                chbx_exentoSi.Checked = false;
            }
        }

        private void chbx_exentoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_exentoSi.Checked)
            {
                chbx_exentoNo.Checked = false;
            }
        }

        private void GenerarDteBoleta_Load(object sender, EventArgs e)
        {
            cargar();
            grid_detalles.ClearSelection();
            grid_detalles.ReadOnly = true;
        }
        private void cargar()
        {
            txt_rutReceptor.Text = "66666666-6";
            txt_razonSocialReceptor.Text = "Receptor";
            txt_comunaReceptor.Text = "Comuna";
            txt_giroReceptor.Text = "Giro";
            txt_direccionReceptor.Text = "Direccion";
            txt_ciudadReceptor.Text = "Ciudad";

            txt_rutEmisor.Text = "76269769-6";
            txt_razonSocialEmisor.Text = "Razón Social";
            txt_comunaEmisor.Text = "Comuna";
            txt_giroEmisor.Text = "Giro";
            txt_direccionEmisor.Text = "Direccion Emisor";
            txt_telefonoEmisor.Text = "62212767";

            detalles.Add(new Detalles("Venta Simple", 1, 500, 500, false, 0));
            grid_detalles.DataSource = detalles;

            txt_folioEncabezado.Text = "25";
            txt_tipoDteEncabezado.Text = "39";
            dp_fechaEmisionEncabezado.Value = new DateTime(2021, 01, 12);

            txt_netoTotales.Text = "420";
            txt_ivaTotales.Text = "80";
            txt_totalTotales.Text = "500";

            txt_indicarServOtros.Text = "3";

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";
        }

        private void btn_eliminarD_Click(object sender, EventArgs e)
        {
            if (indexD.ToString() != "")
            {
                DialogResult r = MessageBox.Show("¿Estas seguro de eliminar este ítem?", "Eliminar Item", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    for (int i = 0; i < detalles.Count; i++)
                    {
                        if (detalles[i] == detalles[int.Parse(indexD)])
                        {
                            detalles.Remove(detalles[int.Parse(indexD)]);
                            if (detalles.Count == 0)
                            {
                                grid_detalles.DataSource = null;
                            }
                            grid_detalles.DataSource = null;
                            grid_detalles.DataSource = detalles;
                            grid_detalles.ClearSelection();
                            indexD = "";
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un item de la lista de detalles para eliminar");
            }
        }

        private void grid_detalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!detSeleccionado)
                {
                    indexD = grid_detalles.Rows[e.RowIndex].Index.ToString();
                    grid_detalles.Rows[e.RowIndex].Selected = true;
                    detSeleccionado = true;
                    detIndexSeleccionada = indexD;
                }
                else if (detSeleccionado && detIndexSeleccionada != grid_detalles.Rows[e.RowIndex].Index.ToString())
                {
                    indexD = grid_detalles.Rows[e.RowIndex].Index.ToString();
                    grid_detalles.Rows[e.RowIndex].Selected = true;
                    detSeleccionado = true;
                    detIndexSeleccionada = indexD;
                }
                else if (detSeleccionado && detIndexSeleccionada == grid_detalles.Rows[e.RowIndex].Index.ToString())
                {
                    indexD = "";
                    grid_detalles.Rows[e.RowIndex].Selected = false;
                    detSeleccionado = false;
                    detIndexSeleccionada = "";
                }
                else
                {
                    indexD = "";
                    grid_detalles.Rows[e.RowIndex].Selected = false;
                    detSeleccionado = false;
                    detIndexSeleccionada = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecciona un item");
            }
        }

        
        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        
    }
}
