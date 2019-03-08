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
            openFileDialog1.ShowDialog();
            string pathFile = openFileDialog1.FileName;
            string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));
            var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);

            string outMessage = "";
            pictureBoxTimbre.Image = dte.Documento.TimbrePDF417(out outMessage);
        }
    }
}
