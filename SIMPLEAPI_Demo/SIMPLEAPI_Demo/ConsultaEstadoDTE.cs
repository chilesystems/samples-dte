//using ChileSystems.DTE.Engine.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using static SIMPLE_API.Enum.Ambiente;*/

namespace SIMPLEAPI_Demo
{
    public partial class ConsultaEstadoDTE : Form
    {
        Handler handler = new Handler();
        public ConsultaEstadoDTE()
        {
            InitializeComponent();
        }

        private async void botonConsultar_Click(object sender, EventArgs e)
        {
            int rutReceptor = int.Parse(textRUTReceptor.Text);
            string dvReceptor = textDVReceptor.Text;
            int folio = int.Parse(textFolio.Text);
            int total = int.Parse(textTotal.Text);
            Enum.TryParse(comboTipoDTE.SelectedItem.ToString(), out SimpleAPI.Enum.TipoDTE.DTEType tipoDTE);
            if (checkIsBoletaCertificacion.Checked || !(tipoDTE == SimpleAPI.Enum.TipoDTE.DTEType.BoletaElectronica || tipoDTE == SimpleAPI.Enum.TipoDTE.DTEType.BoletaElectronicaExenta))
            {
                var responseEstadoDTE = await handler.ConsultarEstadoDTEAsync(radioProduccion.Checked ? SimpleAPI.Enum.Ambiente.AmbienteEnum.Produccion : SimpleAPI.Enum.Ambiente.AmbienteEnum.Certificacion, $"{textRUTReceptor.Text}-{textDVReceptor.Text}", tipoDTE, folio, dateFechaEmision.Value.Date, total);
                textRespuesta.Text = responseEstadoDTE.ResponseXml;
            }
            else
            {
                var responseEstadoDTE = await handler.ConsultarEstadoBoletaAsync(radioProduccion.Checked ? SimpleAPI.Enum.Ambiente.AmbienteEnum.Produccion : SimpleAPI.Enum.Ambiente.AmbienteEnum.Certificacion, $"{textRUTReceptor.Text}-{textDVReceptor.Text}", tipoDTE, folio, dateFechaEmision.Value.Date, total);
                textRespuesta.Text = JsonConvert.SerializeObject(responseEstadoDTE, Formatting.Indented);
            }
        }

        private void ConsultaEstadoDTE_Load(object sender, EventArgs e)
        {
            foreach (var tipo in Enum.GetValues(typeof(SimpleAPI.Enum.TipoDTE.DTEType)))
            {
                comboTipoDTE.Items.Add(tipo);
            }
            handler.configuracion.LeerArchivo();
            textRUTEmpresa.Text = handler.configuracion.Empresa.RutCuerpo.ToString();
            textDVEmpresa.Text = handler.configuracion.Empresa.DV;
            textRUTEnvio.Text = handler.configuracion.Certificado.RutCuerpo.ToString();
            textDVEnvio.Text = handler.configuracion.Certificado.DV;

            comboTipoDTE.SelectedIndex = 0;
        }

        private void comboTipoDTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(comboTipoDTE.SelectedItem.ToString(), out SimpleAPI.Enum.TipoDTE.DTEType tipoDTE);
            checkIsBoletaCertificacion.Enabled = tipoDTE == SimpleAPI.Enum.TipoDTE.DTEType.BoletaElectronica || tipoDTE == SimpleAPI.Enum.TipoDTE.DTEType.BoletaElectronicaExenta;
        }
    }
}
