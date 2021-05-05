using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DemoEndPoints.RCOF
{
    public partial class Resultado : Form
    {
        public string json;
        public string xml;
        public HttpResponseMessage response;
        public Resultado()
        {
            InitializeComponent();
        }

        private async void btn_guardar_Click(object sender, EventArgs e)
        {
            byte[] bytes = await response.Content.ReadAsByteArrayAsync();
            var nombreArchivo = "XmlRcof" + DateTime.Now.Millisecond.ToString() + ".xml";
            
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "XML Files (*.xml)|*.xml";
            save.FileName = nombreArchivo;
            if (save.ShowDialog()==DialogResult.OK)
            {
                var ruta = save.FileName;
                System.IO.FileStream stream =
                new FileStream(ruta, FileMode.CreateNew);
                System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                MessageBox.Show("XML Guardado con Exito");
                Process proceso = new Process();
                proceso.StartInfo.FileName = ruta;
                proceso.Start();
            }
            
           
        }

        private void Resultado_Load(object sender, EventArgs e)
        {
            if (json!="")
            {
                txt_json.Text = json;
            }
            if (xml!="")
            {
                txt_xml.Text = xml;
            }
            
        }
        
    }
}
