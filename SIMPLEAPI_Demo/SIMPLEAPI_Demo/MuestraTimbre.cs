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

            /* El método TimbrePDF417 recibe como argumento una ruta para la generación de archivos temporales
             * Si no se entrega argumento, asume out\temp
             * Si se entrega un argumento vacío, asume la ruta del directorio actual donde vive la app
             * Si se entrega un string, toma esa ruta. 
             * Cabe señalar que los archivos temporales generados son elimiados automáticamente.
             */

            pictureBoxTimbre.Image = dte.Documento.TimbrePDF417();
        }
    }
}
