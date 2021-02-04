using SIMPLEAPI_Demo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMPLEAPI_Demo
{
    public partial class ConfiguracionSistema : Form
    {
        Configuracion configuracion = new Configuracion();

        public ConfiguracionSistema()
        {
            InitializeComponent();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            gridResultados.AutoGenerateColumns = gridProductos.AutoGenerateColumns = false;             

            try
            {
                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certCollection = store.Certificates;
                foreach (X509Certificate2 c in certCollection)
                {
                    comboCertificados.Items.Add(c.FriendlyName);
                }
            }
            catch { }


            try
            {
                configuracion.LeerArchivo();

                textRutEmpresa.Text = configuracion.Empresa.RutEmpresa;
                textGiro.Text = configuracion.Empresa.Giro;
                textRazonSocial.Text = configuracion.Empresa.RazonSocial;
                textComuna.Text = configuracion.Empresa.Comuna;
                textDireccionEmpresa.Text = configuracion.Empresa.Direccion;
                textRutCertificado.Text = configuracion.Certificado.Rut;
                comboCertificados.SelectedItem = configuracion.Certificado.Nombre;
                numericNResolucion.Value = configuracion.Empresa.NumeroResolucion;
                dateFechaResolucion.Value = configuracion.Empresa.FechaResolucion;
                textAPIKey.Text = configuracion.APIKey;

                gridResultados.DataSource = null;
                gridResultados.DataSource = configuracion.Empresa.CodigosActividades;

                gridProductos.DataSource = null;
                gridProductos.DataSource = configuracion.ProductosSimulacion;
            }
            catch { }
        }

        private void botonGuardarActividad_Click(object sender, EventArgs e)
        {
            if (configuracion.Empresa.CodigosActividades.Count > 3)
            {
                MessageBox.Show("Sólo se permite un máximo de 4 actividades económicas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            configuracion.Empresa.CodigosActividades.Add(new ActividadEconomica() { Codigo = int.Parse(textNumeroActividad.Text) });

            gridResultados.DataSource = null;
            gridResultados.DataSource = configuracion.Empresa.CodigosActividades;
            textNumeroActividad.Text = "";
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            configuracion.Empresa.RutEmpresa = textRutEmpresa.Text;
            configuracion.Empresa.Giro = textGiro.Text;
            configuracion.Empresa.RazonSocial = textRazonSocial.Text;
            configuracion.Empresa.Comuna = textComuna.Text;
            configuracion.Empresa.Direccion = textDireccionEmpresa.Text;
            configuracion.Empresa.NumeroResolucion = (int)numericNResolucion.Value;
            configuracion.Empresa.FechaResolucion = dateFechaResolucion.Value.Date;
            configuracion.APIKey = textAPIKey.Text;

            configuracion.Certificado.Rut = textRutCertificado.Text;
            configuracion.Certificado.Nombre = comboCertificados.SelectedItem.ToString();

            configuracion.GenerarArchivo();

            MessageBox.Show("Configuración guardada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                var Codigo = gridResultados.Rows[e.RowIndex].DataBoundItem as ActividadEconomica;
                configuracion.Empresa.CodigosActividades.Remove(Codigo);
                gridResultados.DataSource = null;
                gridResultados.DataSource = configuracion.Empresa.CodigosActividades;
            }
        }

        private void botonAgregarProducto_Click(object sender, EventArgs e)
        {
            configuracion.ProductosSimulacion.Add(new ProductoSimulacion() { Nombre = textNombreProducto.Text });

            gridProductos.DataSource = null;
            gridProductos.DataSource = configuracion.ProductosSimulacion;
            textNombreProducto.Text = "";
        }

        private void gridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                var producto = gridProductos.Rows[e.RowIndex].DataBoundItem as ProductoSimulacion;
                configuracion.ProductosSimulacion.Remove(producto);
                gridProductos.DataSource = null;
                gridProductos.DataSource = configuracion.ProductosSimulacion;
            }
        }
    }
}
