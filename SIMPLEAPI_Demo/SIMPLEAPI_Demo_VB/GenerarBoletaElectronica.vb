Imports ChileSystems.DTE.Engine.Enum

Public Class GenerarBoletaElectronica

    Dim handler As New Handler
    Dim items As List(Of ItemBoleta) = New List(Of ItemBoleta)()



    Private Sub GenerarBoletaElectronica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridResultados.AutoGenerateColumns = False
        handler.configuracion = New Configuracion()
        handler.configuracion.LeerArchivo()
    End Sub

    Private Sub botonAgregarLinea_Click(sender As Object, e As EventArgs) Handles botonAgregarLinea.Click
        Dim item As ItemBoleta = New ItemBoleta()
        item.Nombre = textNombre.Text
        item.Cantidad = numericCantidad.Value
        item.Afecto = checkAfecto.Checked
        item.Precio = CInt(numericPrecio.Value)
        item.UnidadMedida = If(checkUnidad.Checked, "Kg.", String.Empty)

        items.Add(item)
        gridResultados.DataSource = Nothing
        gridResultados.DataSource = items
        textNombre.Text = ""
        numericCantidad.Value = 1
        checkAfecto.Checked = True
    End Sub

    Private Sub gridResultados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridResultados.CellClick
        If e.RowIndex <> -1 Then

            If e.ColumnIndex = 6 Then
                Dim item = TryCast(gridResultados.Rows(e.RowIndex).DataBoundItem, ItemBoleta)
                items.Remove(item)
                gridResultados.DataSource = Nothing
                gridResultados.DataSource = items
            End If
        End If
    End Sub

    Private Sub botonGenerar_Click(sender As Object, e As EventArgs) Handles botonGenerar.Click
        Dim dte = handler.GenerateDTE(ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica, CInt(numericFolio.Value))
        handler.GenerateDetails(dte, items)
        Dim casoPrueba As String = "CASO-" & numericCasoPrueba.Value.ToString("N0")
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.BoletaElectronica, Nothing, 0, casoPrueba)
        Dim messageOut As String = Nothing
        Dim path = handler.TimbrarYFirmarXMLDTE(dte, "out\temp\", "out\caf\", messageOut)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
        MessageBox.Show("Documento generado exitosamente")
    End Sub
End Class