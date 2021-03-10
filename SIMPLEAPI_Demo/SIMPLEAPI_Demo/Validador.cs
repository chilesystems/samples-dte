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
    public partial class Validador : Form
    {
        public Validador()
        {
            InitializeComponent();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                try
                {
                    string xml = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding("ISO-8859-1"));


                    
                    string tipoSchema = string.Empty;
                    SIMPLE_API.Security.Firma.Firma.TipoXML tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.NotSet;
                    string tipo = comboTipo.SelectedItem.ToString();
                    if (tipo == "DTE")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.DTE;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.DTE;

                        var dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString<ChileSystems.DTE.Engine.Documento.DTE>(xml);
                        textDocumento.Text = "FOLIO: " + dte.Documento.Encabezado.IdentificacionDTE.Folio + ". EMISOR: " + dte.Documento.Encabezado.Emisor.RazonSocial;

                    }
                    else if (tipo == "SOBREENVIO")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.Envio;

                        var envio = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString<ChileSystems.DTE.Engine.Envio.EnvioDTE>(xml);
                       // textDocumento.Text = "DOCUMENTOS: " + String.Join(",", envio.SetDTE.DTEs);

                    }
                    else if (tipo == "ENVIOBOLETA")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.EnvioBoleta;
                    }
                    else if (tipo == "IECV")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.LCV_LIBRO;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.LCV;
                    }
                    else if (tipo == "CONSUMOFOLIOS")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.ConsumoFolios;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.RCOF;
                    }
                    else if (tipo == "LIBROBOLETA")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.LibroBoletas;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.LibroBoletas;
                    }
                    else if (tipo == "AEC")
                    {
                        tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.AEC;
                        tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.AEC;
                    }
                    string messageResultSchema = string.Empty;
                    string messageResultFirma = string.Empty;
                    if (ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(openFileDialog1.FileName, out messageResultSchema, tipoSchema))
                    {
                        if (SIMPLE_API.Security.Firma.Firma.VerificarFirma(openFileDialog1.FileName, tipoFirma, out messageResultFirma))
                        {
                            textResultado.Text = "SCHEMA CORRECTO." + Environment.NewLine + " FIRMA CORRECTA.";
                        }
                        else
                            textResultado.Text = "NO SE PUDO VERIFICAR LA FIRMA: " + messageResultFirma;
                    }
                    else
                    {
                        textResultado.Text = "NO SE PUDO VERIFICAR EL SCHEMA: \n" + messageResultSchema;
                    }
                }
                catch (Exception ex)
                {
                    textResultado.Text = "ERROR: " + ex.ToString();
                }
                
            }
        }

        private void Validador_Load(object sender, EventArgs e)
        {
            comboTipo.SelectedIndex = 0;  
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
