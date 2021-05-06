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

namespace DemoEndPoints.GenerarDTE
{
    public partial class GenerarDTEGuiaD : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarDte"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        string indexA = "";
        string indexD = "";
        OpenFileDialog dialogCert;
        OpenFileDialog dialogCaf;
        List<DetallesGuia> detalles = new List<DetallesGuia>();
        List<ActividadesEconomicas> actividades = new List<ActividadesEconomicas>();
        Boolean actSeleccionada;
        string AactIndexSeleccionada;
        Boolean detSeleccionado;
        string detIndexSeleccionada;
        public GenerarDTEGuiaD()
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

        private void btn_agregarActEco_Click(object sender, EventArgs e)
        {
            if (actividades.Count >= 4)
            {
                MessageBox.Show("No se pueden agregar más de 4 actividades");
            }
            else
            {
                ActividadesEconomicas item = new ActividadesEconomicas();
                item.codigo = int.Parse(txt_actividadEcoEmisor.Text);
                actividades.Add(item);
                grid_actividades.DataSource = null;
                grid_actividades.DataSource = actividades;
                txt_actividadEcoEmisor.Text = "0";
            }
            grid_actividades.ClearSelection();
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
            DetallesGuia item = new DetallesGuia();
            item.nombre = txt_nombreDetalles.Text;
            item.cantidad = int.Parse(txt_cantidadDetalles.Text);
            item.precio = int.Parse(txt_precioDetalles.Text);
            item.total = int.Parse(txt_totalDetalles.Text);
            detalles.Add(item);
            grid_detalles.DataSource = null;
            grid_detalles.DataSource = detalles;
            txt_nombreDetalles.Text = "";
            txt_cantidadDetalles.Text = "0";
            txt_precioDetalles.Text = "0";
            txt_totalDetalles.Text = "0";
            grid_detalles.ClearSelection();
        }

        private async void btn_generarDTE_Click(object sender, EventArgs e)
        {
            try
            {

                if (dialogCert == null || dialogCert.FileName == "")
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

                    EmisorGuia emisor = new EmisorGuia();
                    emisor.rut = txt_rutEmisor.Text;
                    emisor.razonSocial = txt_razonSocialEmisor.Text;
                    List<int> activiInt = new List<int>();
                    foreach (var act in actividades)
                    {
                        activiInt.Add(act.codigo);
                    }
                    emisor.actividadesEconomicas = activiInt;
                    emisor.comuna = txt_comunaEmisor.Text;
                    emisor.giro = txt_giroEmisor.Text;
                    emisor.direccion = txt_direccionEmisor.Text;

                    Encabezado encabezado = new Encabezado();
                    encabezado.folio = int.Parse(txt_folioEncabezado.Text);
                    encabezado.tipoDTE = int.Parse(txt_tipoDteEncabezado.Text);
                    encabezado.fechaEmision = dp_fechaEmisionEncabezado.Value.ToString("yyyy-MM-dd"); ;

                    TotalesBoleta totales = new TotalesBoleta();
                    totales.neto = int.Parse(txt_netoTotales.Text);
                    totales.iva = int.Parse(txt_ivaTotales.Text);
                    totales.total = int.Parse(txt_totalTotales.Text);


                    OtrosDTEGuia otros = new OtrosDTEGuia();
                    otros.tipoTraslado = int.Parse(txt_tipoTrasladoOtros.Text);
                    otros.tipoDespacho = int.Parse(txt_tipoDespachoOtros.Text);

                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.password = txt_passCertificado.Text;
                    certificado.rut = txt_rutCertificado.Text;

                    DTEGuiaDespacho dte = new DTEGuiaDespacho();
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
                    MessageBox.Show(sd);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void GenerarDTEGuiaD_Load(object sender, EventArgs e)
        {
            cargar();
            grid_detalles.ClearSelection();
            grid_actividades.ClearSelection();

            grid_actividades.ReadOnly = true;
            grid_detalles.ReadOnly = true;
        }

        private void cargar()
        {
            txt_rutReceptor.Text = "11111111-1";
            txt_razonSocialReceptor.Text = "Razon Social";
            txt_comunaReceptor.Text = "Comuna";
            txt_giroReceptor.Text = "Giro";
            txt_direccionReceptor.Text = "Direccion";
            txt_ciudadReceptor.Text = "Ciudad";

            txt_rutEmisor.Text = "76269769-6";
            txt_razonSocialEmisor.Text = "Razón Social";
            txt_comunaEmisor.Text = "Comuna";
            txt_giroEmisor.Text = "Giro";
            txt_direccionEmisor.Text = "Dirección";

            actividades.Add(new ActividadesEconomicas(474100));
            actividades.Add(new ActividadesEconomicas(465100));
            grid_actividades.DataSource = actividades;

            detalles.Add(new DetallesGuia("Producto 1", 401, 8115, 3254115));
            detalles.Add(new DetallesGuia("Producto 2", 779, 1764, 1374156));
            grid_detalles.DataSource = detalles;

            

            txt_folioEncabezado.Text = "1";
            txt_tipoDteEncabezado.Text = "52";
            dp_fechaEmisionEncabezado.Value = new DateTime(2020, 12, 17);

            txt_netoTotales.Text = "4628271";
            txt_ivaTotales.Text = "879371";
            txt_totalTotales.Text = "5507642";
            

            
            txt_tipoTrasladoOtros.Text = "1";
            txt_tipoDespachoOtros.Text = "2";

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";
        }

        private void grid_actividades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!actSeleccionada)
                {
                    indexA = grid_actividades.Rows[e.RowIndex].Index.ToString();
                    grid_actividades.Rows[e.RowIndex].Selected = true;
                    actSeleccionada = true;
                    AactIndexSeleccionada = indexA;
                }
                else if (actSeleccionada && AactIndexSeleccionada != grid_actividades.Rows[e.RowIndex].Index.ToString())
                {
                    indexA = grid_actividades.Rows[e.RowIndex].Index.ToString();
                    grid_actividades.Rows[e.RowIndex].Selected = true;
                    actSeleccionada = true;
                    AactIndexSeleccionada = indexA;
                }
                else if (actSeleccionada && AactIndexSeleccionada == grid_actividades.Rows[e.RowIndex].Index.ToString())
                {
                    indexA = "";
                    grid_actividades.Rows[e.RowIndex].Selected = false;
                    actSeleccionada = false;
                    AactIndexSeleccionada = "";
                }
                else
                {
                    indexA = "";
                    grid_actividades.Rows[e.RowIndex].Selected = false;
                    actSeleccionada = false;
                    AactIndexSeleccionada = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecciona un item");
            }
        }

        private void btn_eliminarAE_Click(object sender, EventArgs e)
        {
            if (indexA.ToString() != "")
            {
                DialogResult r = MessageBox.Show("¿Estas seguro de eliminar este ítem?", "Eliminar Item", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    for (int i = 0; i < actividades.Count; i++)
                    {
                        if (actividades[i] == actividades[int.Parse(indexA)])
                        {
                            actividades.Remove(actividades[int.Parse(indexA)]);
                            if (actividades.Count == 0)
                            {
                                grid_actividades.DataSource = null;
                            }
                            grid_actividades.DataSource = null;
                            grid_actividades.DataSource = actividades;
                            grid_actividades.ClearSelection();
                            indexA = "";
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un item de la lista de actividades económicas para eliminar");
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

        private void btn_caf_Click_1(object sender, EventArgs e)
        {
            dialogCaf = new OpenFileDialog();
            dialogCaf.Filter = "XML Files(*.xml)|*.xml";
            dialogCaf.ShowDialog();
            txt_caf.Text = dialogCaf.FileName;
        }
        private void soloNumeros(object sender, KeyPressEventArgs e)
        {

        }
    }
}
