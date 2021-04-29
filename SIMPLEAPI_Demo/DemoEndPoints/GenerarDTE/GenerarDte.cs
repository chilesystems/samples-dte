﻿using DemoEndPoints.Clases;
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
    public partial class GenerarDte : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["GenerarDte"];
        string apikey = ConfigurationManager.AppSettings["apikey"];

        OpenFileDialog dialogCert;
        OpenFileDialog dialogCaf;
        List<Referencias> referencias = new List<Referencias>();
        List<Detalles> detalles=new List<Detalles>();
        List<ActividadesEconomicas>actividades=new List<ActividadesEconomicas>();
        List<DescuentosRecargos> descuentos =new List<DescuentosRecargos>();

        public GenerarDte()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void GenerarDte_Load(object sender, EventArgs e)
        {
            cargar();
            
        }

        public void cargar()
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
            txt_direccionEmisor.Text = "Dirección";
            txt_telefonoEmisor.Text = "962212767";

            actividades.Add(new ActividadesEconomicas(474100));
            actividades.Add(new ActividadesEconomicas(465100));
            actividades.Add(new ActividadesEconomicas(582000));
            actividades.Add(new ActividadesEconomicas(620900));
            grid_actividades.DataSource = actividades;

            detalles.Add(new Detalles("Producto 1", 334, 4891, 1633594,false,0));
            detalles.Add(new Detalles("Producto 2", 141, 5801, 817941, false, 0));
            detalles.Add(new Detalles("Servicio exento", 2, 6817, 13634, true, 0));
            grid_detalles.DataSource = detalles;

            referencias.Add(new Referencias("2020-12-17T22:33:55.9048726+00:00",39,1, "Referencia de prueba"));
            grid_referencias.DataSource = referencias;

            txt_folioEncabezado.Text = "1";
            txt_tipoDteEncabezado.Text = "33";
            dp_fechaEmisionEncabezado.Value = new DateTime(2020,12,17);

            txt_netoTotales.Text = "2010259";
            txt_ivaTotales.Text = "381949";
            txt_totalTotales.Text = "2405842";
            txt_exentoTotales.Text = "13634";

            txt_indicarServOtros.Text = "0";
            txt_tipoTrasladoOtros.Text = "0";
            txt_tipoDespachoOtros.Text = "0";

            txt_rutCertificado.Text = "17096073-4";
            txt_passCertificado.Text = "Pollito702";

            descuentos.Add(new DescuentosRecargos("Descuento Comercial",1,1,18));
            grid_descuentos.DataSource = descuentos;
        }

        private void btn_agregarReferencia_Click(object sender, EventArgs e)
        {
            Referencias item = new Referencias();
            item.fecha = dp_fechaReferencias.Value.ToString();
            item.tipoDocReferencia = int.Parse(txt_tipoDocReferencia.Text);
            item.folioReferencia = int.Parse(txt_folioReferencia.Text);
            item.glosa = txt_glosaReferencia.Text;
            referencias.Add(item);
            grid_referencias.DataSource = null;
            grid_referencias.DataSource = referencias;
            txt_tipoDocReferencia.Text = "0";
            txt_folioReferencia.Text = "0";
            txt_glosaReferencia.Text = "";
            dp_fechaReferencias.Value = DateTime.Now;
        }

        private void btn_agregarActEco_Click(object sender, EventArgs e)
        {
            
            if (actividades.Count>=4)
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
            chbx_exentoSi.Checked=true;
            chbx_exentoNo.Checked = false;
        }

        private void chbx_exentoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_exentoSi.Checked)
            {
                chbx_exentoNo.Checked = false;
            }
        }

        private void chbx_exentoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_exentoNo.Checked)
            {
                chbx_exentoSi.Checked = false;
            }
        }

        private void grid_actividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                var acti = grid_actividades.Rows[e.RowIndex].DataBoundItem as ActividadesEconomicas;
                actividades.Remove(acti);
                grid_actividades.DataSource = null;
                grid_actividades.DataSource = actividades;
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DescuentosRecargos item = new DescuentosRecargos();
            item.Descripcion = txt_descDescuentos.Text;
            item.TipoMovimiento = int.Parse(txt_tipoMovDescuentos.Text);
            item.TipoValor = int.Parse(txt_tipoValorDescuentos.Text);
            item.Valor = int.Parse(txt_valorDescuentos.Text);
            descuentos.Add(item);
            grid_descuentos.DataSource = null;
            grid_descuentos.DataSource = descuentos;
            txt_descDescuentos.Text = "";
            txt_tipoMovDescuentos.Text = "0";
            txt_tipoValorDescuentos.Text = "0";
            txt_valorDescuentos.Text = "0";
        }

        private async void btn_generarDTE_Click(object sender, EventArgs e)
        {
            try
            {

                if (dialogCert==null)
                {
                    MessageBox.Show("Seleccione un certificado digital para continuar");
                }
                else if (dialogCaf == null)
                {
                    MessageBox.Show("Seleccione un certificado digital para continuar");
                }
                else if(dialogCert!=null && dialogCaf!=null)
                {

                    Receptor receptor = new Receptor();
                    receptor.rut = txt_rutReceptor.Text;
                    receptor.razonSocial = txt_razonSocialReceptor.Text;
                    receptor.comuna = txt_comunaReceptor.Text;
                    receptor.giro = txt_giroReceptor.Text;
                    receptor.direccion = txt_direccionReceptor.Text;
                    receptor.ciudad = txt_ciudadReceptor.Text;

                    Emisor emisor = new Emisor();
                    emisor.rut = txt_rutEmisor.Text;
                    emisor.razonSocial = txt_razonSocialEmisor.Text;
                    List<int> activiInt = new List<int>();
                    foreach ( var act in actividades)
                    {
                        activiInt.Add(act.codigo);
                    }
                    emisor.actividadesEconomicas = activiInt;
                    emisor.comuna = txt_comunaEmisor.Text;
                    emisor.giro = txt_giroEmisor.Text;
                    emisor.direccion = txt_direccionEmisor.Text;
                    emisor.telefono = int.Parse(txt_telefonoEmisor.Text);

                    Encabezado encabezado = new Encabezado();
                    encabezado.folio = int.Parse(txt_folioEncabezado.Text);
                    encabezado.tipoDTE = int.Parse(txt_tipoDteEncabezado.Text);
                    encabezado.fechaEmision = dp_fechaEmisionEncabezado.Value.ToString("yyyy-MM-dd"); ;

                    Totales totales = new Totales();
                    totales.neto = int.Parse(txt_netoTotales.Text);
                    totales.iva = int.Parse(txt_ivaTotales.Text);
                    totales.total = int.Parse(txt_totalTotales.Text);
                    totales.exento = int.Parse(txt_exentoTotales.Text);


                    OtrosDTE otros = new OtrosDTE();
                    otros.indicadorServicio = int.Parse(txt_indicarServOtros.Text);
                    otros.tipoTraslado = int.Parse(txt_tipoTrasladoOtros.Text);
                    otros.tipoDespacho = int.Parse(txt_tipoDespachoOtros.Text);

                    CertificadoDigital certificado = new CertificadoDigital();
                    certificado.password = txt_passCertificado.Text;
                    certificado.rut = txt_rutCertificado.Text;

                    DTEFactura dte = new DTEFactura();
                    dte.receptor = receptor;
                    dte.emisor = emisor;
                    dte.detalles = detalles;
                    dte.referencias = referencias;
                    dte.encabezado = encabezado;
                    dte.totales = totales;
                    dte.otrosDTE = otros;
                    dte.certificadoDigital = certificado;
                    dte.DescuentosRecargos = descuentos;

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
                        FileName = dialogCert.FileName
                    };
                    var cafByte = new ByteArrayContent(await streamContentR.ReadAsByteArrayAsync());
                    cafByte.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    cafByte.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "files",
                        FileName = dialogCaf.FileName
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
                MessageBox.Show("Error : "+ex);
            }
        }

        private void btn_caf_Click(object sender, EventArgs e)
        {
            dialogCaf = new OpenFileDialog();
            dialogCaf.Filter = "XML Files(*.xml)|*.xml";
            dialogCaf.ShowDialog();
            txt_caf.Text = dialogCaf.FileName;
           
        }

        private void btn_cargarCertificado_Click(object sender, EventArgs e)
        {
            dialogCert = new OpenFileDialog();
            dialogCert.Filter = "PFX Files(*.pfx)|*.pfx";
            dialogCert.ShowDialog();
            txt_certificado.Text = dialogCert.FileName;
        }
    }
}
