using ChileSystems.DTE.Engine.Enum;
using SIMPLEAPI_Demo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMPLEAPI_Demo
{
    public partial class GenerarBoletaElectronica : Form
    {
        Handler handler = new Handler();
        List<ItemBoleta> items;

        public GenerarBoletaElectronica()
        {
            InitializeComponent();
            items = new List<ItemBoleta>();
        }

        private void GenerarBoletaElectronica_Load(object sender, EventArgs e)
        {
            gridResultados.AutoGenerateColumns = false;
            handler.configuracion = new Configuracion();
            handler.configuracion.LeerArchivo();
        }

        private void botonAgregarLinea_Click(object sender, EventArgs e)
        {
            ItemBoleta item = new ItemBoleta();
            item.Nombre = textNombre.Text;
            item.Cantidad = numericCantidad.Value;
            item.Afecto = checkAfecto.Checked;
            item.Precio = (int)numericPrecio.Value;
            item.UnidadMedida = checkUnidad.Checked ? "Kg." : string.Empty;
            items.Add(item);
            gridResultados.DataSource = null;
            gridResultados.DataSource = items;

            textNombre.Text = "";
            numericCantidad.Value = 1;
            checkAfecto.Checked = true;
        }

        private void gridResultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 6)
                {
                    var item = gridResultados.Rows[e.RowIndex].DataBoundItem as ItemBoleta;
                    items.Remove(item);
                    gridResultados.DataSource = null;
                    gridResultados.DataSource = items;
                }
            }
        }

        private void botonGenerar_Click(object sender, EventArgs e)
        {
            var dte = handler.GenerateDTE(ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.BoletaElectronica, (int)numericFolio.Value);
            handler.GenerateDetails(dte, items);
            string casoPrueba = "CASO-" + numericCasoPrueba.Value.ToString("N0");
            handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.BoletaElectronica, null, 0, casoPrueba);
            var path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\");
            handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE);
            MessageBox.Show("Documento generado exitosamente");
        }
    }
}
