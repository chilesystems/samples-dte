using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMPLEAPI_Demo
{
    public partial class MuestraTimbre : Form
    {
        public MuestraTimbre()
        {
            InitializeComponent();
        }

        private void botonCargarDTE_Click(object sender, EventArgs e)
        {
            string outMessage = "";
            openFileDialog1.ShowDialog();
            string pathFile = openFileDialog1.FileName;
            string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));

            //var envioBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString<ChileSystems.DTE.Engine.Envio.EnvioBoleta>(xml);
            //pictureBoxTimbre.Image = envioBoleta.SetDTE.DTEs[0].Documento.TimbrePDF417(out outMessage);
            var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);            
            pictureBoxTimbre.BackgroundImage = dte.Documento.TimbrePDF417(out outMessage);

            //dte.Exportaciones.TimbrePDF417(out outMessage);

            
        }

        private void MuestraTimbre_Load(object sender, EventArgs e)
        {

        }

        private void botonValidar_Click(object sender, EventArgs e)
        {
            string outMessage = "";
            //openFileDialog1.Title = "Seleccione XML de timbre";
            //openFileDialog1.ShowDialog();
            //string pathFile = openFileDialog1.FileName;
            //string xmlTimbreAux = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
            //var dteAux = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xmlTimbreAux);
            //string xmlTimbre = dteAux.Documento.TED.DatosBasicos.ToString();
            //string xmlTimbre = File.ReadAllText("C:\\Users\\Gonzalo\\Desktop\\sisfredo\\TmpTimbreCert_89.xml", Encoding.GetEncoding("ISO-8859-1"));

            openFileDialog1.Title = "Seleccione XML de CAF";
            openFileDialog1.ShowDialog();
            string pathFileCaf = openFileDialog1.FileName;
            string xmlCAF = File.ReadAllText(pathFileCaf, Encoding.GetEncoding("ISO-8859-1"));

            openFileDialog1.Title = "Seleccione XML de EnvioBoleta";
            openFileDialog1.ShowDialog();
            string pathFileEnvioBoleta = openFileDialog1.FileName;
            string xmlEnvioBoleta = File.ReadAllText(pathFileEnvioBoleta, Encoding.GetEncoding("ISO-8859-1"));

            var envioBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString<ChileSystems.DTE.Engine.Envio.EnvioBoleta>(xmlEnvioBoleta);
            string firmadelDD = envioBoleta.SetDTE.DTEs[0].Documento.TED.FirmaDigital.Firma;


            string privateKey = ChileSystems.DTE.Engine.CAFHandler.CAFHandler.GetPrivateKey(pathFileCaf);


            string firmaResultante = SIMPLE_API.Security.Timbre.Timbre.Timbrar(envioBoleta.SetDTE.DTEs[0].Documento.TED.DatosBasicos.ToString(), privateKey);

            MessageBox.Show((firmaResultante == firmadelDD).ToString());
        }
    }
}
