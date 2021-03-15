Imports System.IO
Imports System.Text

Public Class Validador
    Private Sub Validador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTipo.SelectedIndex = 0
    End Sub

    Private Sub botonBuscar_Click(sender As Object, e As EventArgs) Handles botonBuscar.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.ShowDialog()

        If File.Exists(openFileDialog1.FileName) Then

            Try
                Dim xml As String = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding("ISO-8859-1"))
                Dim tipoSchema As String = String.Empty
                Dim tipoFirma As SIMPLE_API.Security.Firma.Firma.TipoXML = SIMPLE_API.Security.Firma.Firma.TipoXML.NotSet
                Dim tipo As String = comboTipo.SelectedItem.ToString()

                If tipo = "DTE" Then
                    tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.DTE
                    tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.DTE
                    Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
                    textDocumento.Text = "FOLIO: " & dte.Documento.Encabezado.IdentificacionDTE.Folio & ". EMISOR: " + dte.Documento.Encabezado.Emisor.RazonSocial
                ElseIf tipo = "SOBREENVIO" Then
                    tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE
                    tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.Envio
                    Dim envio = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString(Of ChileSystems.DTE.Engine.Envio.EnvioDTE)(xml)
                ElseIf tipo = "ENVIOBOLETA" Then
                    tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta
                    tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.EnvioBoleta
                ElseIf tipo = "IECV" Then
                    tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.LCV_LIBRO
                    tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.LCV
                ElseIf tipo = "CONSUMOFOLIOS" Then
                    tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.ConsumoFolios
                    tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.RCOF
                ElseIf tipo = "LIBROBOLETA" Then
                    tipoSchema = ChileSystems.DTE.Engine.XML.Schemas.LibroBoletas
                    tipoFirma = SIMPLE_API.Security.Firma.Firma.TipoXML.LibroBoletas
                End If

                Dim messageResultSchema As String = String.Empty
                Dim messageResultFirma As String = String.Empty

                If ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(openFileDialog1.FileName, messageResultSchema, tipoSchema) Then

                    If SIMPLE_API.Security.Firma.Firma.VerificarFirma(openFileDialog1.FileName, tipoFirma, messageResultFirma) Then
                        textResultado.Text = "SCHEMA CORRECTO." & Environment.NewLine & " FIRMA CORRECTA."
                    Else
                        textResultado.Text = "NO SE PUDO VERIFICAR LA FIRMA: " & messageResultFirma
                    End If
                Else
                    textResultado.Text = "NO SE PUDO VERIFICAR EL SCHEMA: " & vbLf & messageResultSchema
                End If

            Catch ex As Exception
                textResultado.Text = "ERROR: " & ex.ToString()
            End Try
        End If
    End Sub
End Class