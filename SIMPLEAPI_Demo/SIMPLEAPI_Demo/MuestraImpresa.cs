using SIMPLEAPI_Demo.Properties;
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
using ThermalPrinting.Core;
using ThermalPrinting.Core.Helpers;

namespace SIMPLEAPI_Demo
{
    public partial class MuestraImpresa : Form
    {
        bool binding = false;
        PrintableDocument document = new PrintableDocument();

        public MuestraImpresa()
        {
            InitializeComponent();
        }


        private void BindData()
        {
            binding = true;

            txtRutEmisor.Text = document.Rut;
            txtRazonSocialEmisor.Text = document.RazonSocial;
            txtGiroEmisor.Text = document.Giro;
            txtDireccionCasaMatrizEmisor.Text = document.DireccionCasaMatriz;
            txtDireccionSucursalesEmisor.Text = document.Sucursales != null ? string.Join(", ", document.Sucursales) : "";
            txtTelefonoEmisor.Text = document.Teléfono;

            txtRutReceptor.Text = document.RutCliente;
            txtRazonSocialReceptor.Text = document.RazonSocialCliente;

            comboTipoDocumento.Text = document.NombreDocumento;
            txtFolio.Value = document.Folio;
            dateFechaEmision.Value = document.FechaEmision;
            checkIsDTE.Checked = document.IsDTE;
            checkShowUM.Checked = document.ShowUnidadMedida;
            txtOficinaSII.Text = document.OficinaSII;

            gridDescuentosRecargos.Rows.Clear();
            if (document.DescuentosRecargos != null)
                foreach (var descrec in document.DescuentosRecargos)
                    gridDescuentosRecargos.Rows.Add(descrec.Item1, descrec.Item2, descrec.Item3);

            txtIva.Value = document.IVA;
            txtNeto.Value = document.Neto;
            txtTotal.Value = document.Total;
            txtExento.Value = document.TotalExento;

            gridAdicionales.Rows.Clear();
            if (document.Adicionales != null)
                foreach (var adicional in document.Adicionales)
                    gridAdicionales.Rows.Add(adicional.Item1, adicional.Item2);

            gridDetalles.Rows.Clear();
            if (document.Detalles != null)
                foreach (var detalle in document.Detalles)
                    gridDetalles.Rows.Add(detalle.IsExento, detalle.Cantidad, detalle.UnidadMedida, detalle.Descripcion, detalle.Precio, detalle.Total);

            txtNumeroResolucion.Value = document.NumeroResolucion;
            dateFechaResolucion.Value = document.FechaResolucion == default(DateTime) ? DateTime.Now : document.FechaResolucion;
            txtWebVerificacion.Text = document.WebVerificación;

            binding = false;
        }

        private void MuestraImpresa_Load(object sender, EventArgs e)
        {
            txtXmlFilePath.Text = Settings.Default.xmlFilePath;

            comboTipoDocumento.ValueMember = "Key";
            comboTipoDocumento.DisplayMember = "Value";
            foreach (var pair in DTETypeNames.Names.AsEnumerable())
                comboTipoDocumento.Items.Add(pair);

            var printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
            foreach (var print in printers)
                comboPrinters.Items.Add(print);
            radioPrinter_CheckedChanged(null, null);
        }

        private void radioPrinter_CheckedChanged(object sender, EventArgs e)
        {
            comboPrinters.Enabled = radioPrinter.Checked;
        }

        private void btnSelectXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Archivos XML (*.xml)|*.xml",
                Multiselect = false,
            };
            dialog.ShowDialog();
            if (string.IsNullOrEmpty(dialog.FileName))
                return;
            if (!File.Exists(dialog.FileName))
                return;

            txtXmlFilePath.Text = dialog.FileName;

            Settings.Default.xmlFilePath = dialog.FileName;
            Settings.Default.Save();
        }

        private void btnCargarXml_Click(object sender, EventArgs e)
        {
            try
            {
                string pathFile = txtXmlFilePath.Text;
                string xml = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"));

                var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);

                document = PrintableDocument.FromDTE(dte);
                pictureBoxTimbre.BackgroundImage = document.TimbreImage = dte.Documento.TimbrePDF417(out string outMessage);
                BindData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar el archivo.\n\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ThermalPrintHandler handler = new ThermalPrintHandler(document);

            document.WebVerificación = txtWebVerificacion.Text;
            document.NumeroResolucion = (int)txtNumeroResolucion.Value;
            document.FechaResolucion = dateFechaResolucion.Value;
            handler.NombreImpresora = radioPrinter.Checked ? comboPrinters.Text : "DEBUG";

            handler.Print(radioPrinter.Checked);
        }
    }
}
