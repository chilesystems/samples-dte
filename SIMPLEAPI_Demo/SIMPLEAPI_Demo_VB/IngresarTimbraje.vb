Imports System.IO
Imports ChileSystems.DTE.Engine.Documento
Imports ChileSystems.DTE.Engine.XML

Public Class IngresarTimbraje

    Dim aut As Autorizacion

    Private Sub IngresarTimbraje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub botonBuscar_Click(sender As Object, e As EventArgs) Handles botonBuscar.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.ShowDialog()

        If File.Exists(openFileDialog1.FileName) Then
            txtFilePath.Text = openFileDialog1.FileName
            aut = XmlHandler.DeserializeRaw(Of Autorizacion)(openFileDialog1.FileName)
            aut.CAF.IdCAF = 1
            textFecha.Text = aut.CAF.Datos.FechaAutorizacion.ToShortDateString()
            textRango.Text = aut.CAF.Datos.RangoAutorizado.Desde.ToString() & " - " + aut.CAF.Datos.RangoAutorizado.Hasta.ToString()
            Dim tipo As String = String.Empty

            Select Case aut.CAF.Datos.TipoDTE
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaCompraElectronica
                    tipo = "FACTURA DE COMPRA ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica
                    tipo = "FACTURA ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronicaExenta
                    tipo = "FACTURA ELECTRÓNICA EXENTA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.GuiaDespachoElectronica
                    tipo = "GUIA DE DESPACHO ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica
                    tipo = "NOTA DE CRÉDITO ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica
                    tipo = "NOTA DE DÉBITO ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica
                    tipo = "BOLETA ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronicaExenta
                    tipo = "BOLETA ELECTRÓNICA EXENTA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaExportacionElectronica
                    tipo = "FACTURA DE EXPORTACIÓN ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoExportacionElectronica
                    tipo = "NOTA DE CRÉDITO DE EXPORTACIÓN ELECTRÓNICA"
                Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoExportacionElectronica
                    tipo = "NOTA DE DÉBITO DE EXPORTACIÓN ELECTRÓNICA"
            End Select

            textTipoCAF.Text = tipo
            'xml = File.ReadAllBytes(openFileDialog1.FileName);
        End If


    End Sub

    Private Sub botonGuardar_Click(sender As Object, e As EventArgs) Handles botonGuardar.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.FileName = txtFilePath.Text
        Dim filePath As String = "out\\caf\\" + String.Format("{0}_{1}_{2}.dat", CInt(aut.CAF.Datos.TipoDTE), aut.CAF.Datos.RangoAutorizado.Desde.ToString(), aut.CAF.Datos.RangoAutorizado.Hasta.ToString())
        Dim fs As FileStream = New FileStream(filePath, FileMode.Create, FileAccess.Write)
        Using (fs)
            Dim xml = File.ReadAllBytes(openFileDialog1.FileName)
            fs.Write(xml, 0, xml.Length())
            fs.Flush()
            fs.Close()

        End Using

        MessageBox.Show("CAF Guardado correctamente")
    End Sub
End Class