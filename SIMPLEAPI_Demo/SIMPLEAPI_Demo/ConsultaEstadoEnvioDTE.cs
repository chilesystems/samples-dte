using System;
using ChileSystems.DTE.Engine.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SIMPLE_API.Enum.Ambiente;
using Newtonsoft.Json;

namespace SIMPLEAPI_Demo
{
    public partial class ConsultaEstadoEnvioDTE : Form
    {
        Handler handler = new Handler();
        public ConsultaEstadoEnvioDTE()
        {
            InitializeComponent();
        }

        private void ConsultaEstadoAvanzadoDTE_Load(object sender, EventArgs e)
        {
            handler.configuracion.LeerArchivo();
            textRUTEmpresa.Text = handler.configuracion.Empresa.RutCuerpo.ToString();
            textDVEmpresa.Text = handler.configuracion.Empresa.DV;
        }

        private void botonConsultar_Click(object sender, EventArgs e)
        {
            long trackId = long.Parse(textTrackID.Text);
            try
            {
                if (radioEnvioDTE.Checked)
                {
                    var responseEstadoDTE = handler.ConsultarEstadoEnvio(radioProduccion.Checked ? AmbienteEnum.Produccion : AmbienteEnum.Certificacion, trackId);
                    textRespuesta.Text = responseEstadoDTE.ResponseXml;
                }
                else
                {
                    var responseEstadoDTE = handler.ConsultarEstadoEnvioBoleta(radioProduccion.Checked ? AmbienteEnum.Produccion : AmbienteEnum.Certificacion, trackId);
                    textRespuesta.Text = JsonConvert.SerializeObject(responseEstadoDTE, Formatting.Indented);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:" + ex);
            }
        }
    }
}
