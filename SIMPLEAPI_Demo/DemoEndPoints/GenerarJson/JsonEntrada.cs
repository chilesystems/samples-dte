using DemoEndPoints.Clases;
using DemoEndPoints.GenerarDTE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DemoEndPoints.GenerarJson
{
    public partial class JsonEntrada : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonEntrada"];
        List<Referencias> referencias = new List<Referencias>();
        List<Detalles> detalles = new List<Detalles>();
        List<ActividadesEconomicas> actividades = new List<ActividadesEconomicas>();
        List<DescuentosRecargos> descuentos = new List<DescuentosRecargos>();
        public JsonEntrada()
        {
            InitializeComponent();
        }

        private async void JsonEntrada_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            txt_jsonEntrada.Text = response;
            /*DTEEntrada json = new JavaScriptSerializer().Deserialize<DTEEntrada>(response);
            formEntrada.Visible = false;
            lbl_rutRecep.Text = json.receptor.rut;
            lbl_lbl_ciudadRecep.Text = json.receptor.ciudad;
            lbl_razonRecep.Text = json.receptor.razonSocial;
            lbl_giroRecep.Text = json.receptor.giro;
            lbl_comunaRecep.Text = json.receptor.comuna;
            lbl_direccionRecep.Text = json.receptor.direccion;

            lbl_rutCert.Text = json.certificadoDigital.rut;
            lbl_passCert.Text = json.certificadoDigital.password;

            lbl_netoTotal.Text = json.totales.neto.ToString();
            lbl_ivaTotal.Text = json.totales.iva.ToString();
            lbl_totalTotal.Text = json.totales.total.ToString();
            lbl_exentoTotal.Text = json.totales.exento.ToString();

            lbl_rutEmisor.Text = json.emisor.rut;
            lbl_razonEmisor.Text = json.emisor.razonSocial;
            lbl_comunaEmisor.Text = json.emisor.comuna;
            lbl_giroEmisor.Text = json.emisor.giro;
            lbl_direccionEmisor.Text = json.emisor.direccion;
            lbl_telefonoEmisor.Text = json.emisor.telefono.ToString();

            lbl_indicadorOtros.Text = json.otrosDTE.indicadorServicio.ToString();
            lbl_tipoTrasladoOtros.Text = json.otrosDTE.tipoTraslado.ToString();
            lbl_tipoDespOtros.Text = json.otrosDTE.tipoDespacho.ToString();

            lbl_folioEncab.Text = json.encabezado.folio.ToString();
            lbl_tipoDteEncab.Text = json.encabezado.tipoDTE.ToString();
            lbl_fechaEncab.Text = json.encabezado.fechaEmision;
            
            grid_actividades.DataSource = json.emisor.actividadesEconomicas;

            grid_detalles.DataSource = json.detalles;

            grid_referencias.DataSource = json.referencias;

            //grid_descuentos.DataSource = json.DescuentosRecargos;*/
        }
        
    }
}
