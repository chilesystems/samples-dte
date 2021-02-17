using SIMPLEAPI_Demo.Impresion.Core;
using SIMPLEAPI_Demo.Impresion.Core.Helpers;
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
            //if (document.DescuentosRecargos != null)
            //    foreach (var descrec in document.DescuentosRecargos)
            //        gridDescuentosRecargos.Rows.Add(descrec.Item1, descrec.Item2, descrec.Item3);

            txtIva.Value = document.IVA;
            txtNeto.Value = document.Neto;
            txtTotal.Value = document.Total;
            txtExento.Value = document.TotalExento;

            gridAdicionales.Rows.Clear();
            //if (document.Adicionales != null)
            //    foreach (var adicional in document.Adicionales)
            //        gridAdicionales.Rows.Add(adicional.Item1, adicional.Item2);

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
            document.FechaResolucion = dateFechaResolucion.Value;
            handler.NombreImpresora = radioPrinter.Checked ? comboPrinters.Text : "DEBUG";

            handler.Print(radioPrinter.Checked);
        }

        private void comboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            document.NombreDocumento = comboTipoDocumento.Text;
        }


        private void Number_ValueChanged(object sender, EventArgs e)
        {
            var txt = sender as NumericUpDown;

            if (txt == null)
                return;

            switch (txt.Name)
            {
                case "txtFolio":
                    document.Folio = Convert.ToInt32(txt.Value);
                    break;
                case "txtIva":
                    document.IVA = Convert.ToInt32(txt.Value);
                    break;
                case "txtNeto":
                    document.Neto = Convert.ToInt32(txt.Value);
                    break;
                case "txtTotal":
                    document.Total = Convert.ToInt32(txt.Value);
                    break;
                case "txtExento":
                    document.TotalExento = Convert.ToInt32(txt.Value);
                    break;
                case "txtNumeroResolucion":
                    document.NumeroResolucion = Convert.ToInt32(txt.Value);
                    break;
                default:
                    break;
            }
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;

            if (check == null)
                return;

            switch (check.Name)
            {
                case "checkIsDTE":
                    document.IsDTE = check.Checked;
                    break;
                case "checkShowUM":
                    document.ShowUnidadMedida = check.Checked;
                    break;
            }
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            var date = sender as DateTimePicker;

            if (date == null)
                return;

            switch (date.Name)
            {
                case "dateFechaEmision":
                    document.FechaEmision = date.Value;
                    break;
                case "dateFechaResolucion":
                    document.FechaResolucion = date.Value;
                    break;
            }
        }

        private void gridAdicionales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindAdicionales();
        }
        private void gridAdicionales_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BindAdicionales();
        }
        private void gridAdicionales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BindAdicionales();
        }
        private void BindAdicionales()
        {
            if (binding)
                return;

            int aux;
            //document.Adicionales = new List<(string, int)>();
            //foreach (DataGridViewRow row in gridAdicionales.Rows)
            //{
            //    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
            //        if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
            //            if (int.TryParse(row.Cells[1].Value.ToString(), System.Globalization.NumberStyles.Number, null, out aux))
            //                document.Adicionales.Add((row.Cells[0].Value.ToString(), aux));
            //}

            //if (document.Adicionales.Count == 0)
            //    document.Adicionales = null;
        }

        private void gridDescuentosRecargos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindDescuentosRecargos();
        }
        private void gridDescuentosRecargos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BindDescuentosRecargos();
        }
        private void gridDescuentosRecargos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BindDescuentosRecargos();
        }
        private void BindDescuentosRecargos()
        {
            if (binding)
                return;

            //foreach (DataGridViewRow row in gridAdicionales.Rows)
            //{
            //    if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
            //        if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()) &&
            //            !string.IsNullOrEmpty(row.Cells[1].Value.ToString()) &&
            //            !string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
            //            document.DescuentosRecargos.Add((row.Cells[0].Value.ToString().First(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()));
            //}

            //if (document.DescuentosRecargos.Count == 0)
            //    document.DescuentosRecargos = null;
        }

        private void gridDetalles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BindDetalles();
        }
        private void gridDetalles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BindDetalles();
        }
        private void gridDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BindDetalles();
        }
        private void BindDetalles()
        {
            if (binding)
                return;

            bool boolAux;
            int intAux;

            foreach (DataGridViewRow row in gridDetalles.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[1].Value != null &&
                    //row.Cells[2].Value != null &&
                    row.Cells[3].Value != null &&
                    row.Cells[4].Value != null &&
                    row.Cells[5].Value != null)
                    if (bool.TryParse(row.Cells[0].Value.ToString(), out boolAux) &&
                        int.TryParse(row.Cells[1].Value.ToString(), System.Globalization.NumberStyles.Number, null, out intAux) &&
                        //!string.IsNullOrEmpty(row.Cells[2].Value.ToString()) &&
                        !string.IsNullOrEmpty(row.Cells[3].Value.ToString()) &&
                        int.TryParse(row.Cells[4].Value.ToString(), System.Globalization.NumberStyles.Number, null, out intAux) &&
                        int.TryParse(row.Cells[5].Value.ToString(), System.Globalization.NumberStyles.Number, null, out intAux))
                        document.Detalles.Add(new PrintableDocumentDetail()
                        {
                            IsExento = Convert.ToBoolean(row.Cells[0].Value),
                            Cantidad = Convert.ToInt32(row.Cells[1].Value),
                            UnidadMedida = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString(),
                            Descripcion = row.Cells[3].Value.ToString(),
                            Precio = Convert.ToInt32(row.Cells[4].Value),
                            Total = Convert.ToInt32(row.Cells[5].Value),
                        });
            }

            if (document.Detalles.Count == 0)
                document.Detalles = null;
        }
    }

}
