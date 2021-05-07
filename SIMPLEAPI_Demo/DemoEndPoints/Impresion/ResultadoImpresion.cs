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

namespace DemoEndPoints.Impresion
{
    public partial class ResultadoImpresion : Form
    {
        public string json;
        public string resultado;
        public int tipo;
        public HttpResponseMessage response;
        public ResultadoImpresion()
        {
            InitializeComponent();
        }

        private async void btn_guardar_Click(object sender, EventArgs e)
        {
            if (tipo==1 || tipo ==4)
            {
                byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                var nombreArchivo = "archivo" + DateTime.Now.Millisecond.ToString() + ".pdf";

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.FileName = nombreArchivo;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    var ruta = save.FileName;
                    System.IO.FileStream stream =
                    new FileStream(ruta, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    MessageBox.Show("PDF Guardado con Exito");
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = ruta;
                    proceso.Start();
                }
            }
            else if (tipo == 2 || tipo == 3)
            {
                byte[] bytes = Convert.FromBase64String(resultado);
                var nombreArchivo = "archivo" + DateTime.Now.Millisecond.ToString() + ".pdf";

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.FileName = nombreArchivo;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    var ruta = save.FileName;
                    System.IO.FileStream stream =
                    new FileStream(ruta, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                    MessageBox.Show("PDF Guardado con Exito");
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = ruta;
                    proceso.Start();
                }
            }
            
        }

        private void ResultadoImpresion_Load(object sender, EventArgs e)
        {
            txt_json.Text = json;
            txt_resultado.Text = resultado;
        }
    }
}
