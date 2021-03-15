Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MuestraImpresa


    Dim binding As Boolean = False
    Dim document As PrintableDocument = New PrintableDocument()


    Private Sub btnSelectXml_Click(sender As Object, e As EventArgs) Handles btnSelectXml.Click
        Dim opd As New OpenFileDialog


        opd.Filter = "Archivos XML (*.xml)|*.xml"
        opd.Multiselect = False
        opd.ShowDialog()
        If (String.IsNullOrEmpty(opd.FileName)) Then

            Return
        End If
        If (Not File.Exists(opd.FileName)) Then
            Return
        End If

        txtXmlFilePath.Text = opd.FileName



    End Sub
    Private Sub BindDetalles()
        If binding Then Return
        Dim boolAux As Boolean
        Dim intAux As Integer

        For Each row As DataGridViewRow In gridDetalles.Rows

            If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(1).Value IsNot Nothing AndAlso
                row.Cells(3).Value IsNot Nothing AndAlso row.Cells(4).Value IsNot Nothing AndAlso
                row.Cells(5).Value IsNot Nothing Then
                If Boolean.TryParse(row.Cells(0).Value.ToString(), boolAux) AndAlso
                Integer.TryParse(row.Cells(1).Value.ToString(), System.Globalization.NumberStyles.Number, Nothing, intAux) AndAlso
                Not String.IsNullOrEmpty(row.Cells(3).Value.ToString()) AndAlso
                Integer.TryParse(row.Cells(4).Value.ToString(), System.Globalization.NumberStyles.Number, Nothing, intAux) AndAlso
                Integer.TryParse(row.Cells(5).Value.ToString(), System.Globalization.NumberStyles.Number, Nothing, intAux) Then
                    document.Detalles.Add(New PrintableDocumentDetail() With {
                .IsExento = Convert.ToBoolean(row.Cells(0).Value),
                .Cantidad = Convert.ToInt32(row.Cells(1).Value),
                .UnidadMedida = If(row.Cells(2).Value Is Nothing, "", row.Cells(2).Value.ToString()),
                .Descripcion = row.Cells(3).Value.ToString(),
                .Precio = Convert.ToInt32(row.Cells(4).Value),
                .Total = Convert.ToInt32(row.Cells(5).Value)
            })
                End If
            End If
        Next

        'If document.Detalles.Count = 0 Then
        '    document.Detalles = Nothing
        'End If
    End Sub
    Private Sub BindAdicionales()
        If (binding) Then
            Return
        End If

        Dim aux As Integer

    End Sub
    Private Sub BindDescuentosRecargos()
        If (binding) Then
            Return
        End If



    End Sub
    Private Sub BindData()
        binding = True
        txtRutEmisor.Text = document.Rut
        txtRazonSocialEmisor.Text = document.RazonSocial
        txtGiroEmisor.Text = document.Giro
        txtDireccionCasaMatrizEmisor.Text = document.DireccionCasaMatriz
        txtDireccionSucursalesEmisor.Text = If(document.Sucursales IsNot Nothing, String.Join(", ", document.Sucursales), "")
        txtTelefonoEmisor.Text = document.Teléfono


        txtRutReceptor.Text = document.RutCliente
        txtRazonSocialReceptor.Text = document.RazonSocialCliente


        comboTipoDocumento.Text = document.NombreDocumento
        txtFolio.Value = document.Folio
        dateFechaEmision.Value = document.FechaEmision
        checkIsDTE.Checked = document.IsDTE
        checkShowUM.Checked = document.ShowUnidadMedida
        txtOficinaSII.Text = document.OficinaSII


        gridDescuentosRecargos.Rows.Clear()


        txtIva.Value = document.IVA
        txtNeto.Value = document.Neto
        txtTotal.Value = document.Total
        txtExento.Value = document.TotalExento


        gridAdicionales.Rows.Clear()


        gridDetalles.Rows.Clear()

        If (Not IsNothing(document.Detalles)) Then

            For Each detalle In document.Detalles

                gridDetalles.Rows.Add(detalle.IsExento, detalle.Cantidad, detalle.UnidadMedida, detalle.Descripcion, detalle.Precio, detalle.Total)


            Next

            txtNumeroResolucion.Value = document.NumeroResolucion
            dateFechaResolucion.Value = document.FechaResolucion.ToString() = IIf(DateTime.Now.ToString, DateTime.Now, document.FechaResolucion)
            txtWebVerificacion.Text = document.WebVerificación
        End If

        binding = False
    End Sub

    Private Sub btnCargarXml_Click(sender As Object, e As EventArgs) Handles btnCargarXml.Click


        Try
            Dim pathFile As String = txtXmlFilePath.Text
            Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            document = PrintableDocument.FromDTE(dte)
            Dim x As String = Nothing
            document.TimbreImage = dte.Documento.TimbrePDF417(x)
            pictureBoxTimbre.BackgroundImage = document.TimbreImage


            BindData()

        Catch ex As Exception
            MsgBox("Ha ocurrido un error al cargar el archivo. Error: " + ex.Message, vbYes)
        End Try
    End Sub

    Private Sub comboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTipoDocumento.SelectedIndexChanged
        document.NombreDocumento = comboTipoDocumento.Text
    End Sub

    Private Sub gridDetalles_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gridDetalles.RowsAdded
        BindDetalles()
    End Sub

    Private Sub gridDetalles_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridDetalles.CellEndEdit
        BindDetalles()
    End Sub

    Private Sub gridDetalles_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gridDetalles.RowsRemoved
        BindDetalles()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim handler As ThermalPrintHandler = New ThermalPrintHandler(document)
        document.WebVerificación = txtWebVerificacion.Text
        document.FechaResolucion = dateFechaResolucion.Value
        handler.NombreImpresora = IIf(radioPrinter.Checked, comboPrinters.Text, "DEBUG")
        handler.Print(radioPrinter.Checked)

    End Sub

    Private Sub MuestraImpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtXmlFilePath.Text = "C:\"

        comboTipoDocumento.ValueMember = "Key"
        comboTipoDocumento.DisplayMember = "Value"
        For Each pair In DTETypeNames.Names.AsEnumerable()
            comboTipoDocumento.Items.Add(pair)

        Next
        Dim printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        For Each printt In printers
            comboPrinters.Items.Add(printt)
            radioPrinter_CheckedChanged(Nothing, Nothing)
        Next


    End Sub

    Private Sub radioPrinter_CheckedChanged(sender As Object, e As EventArgs) Handles radioPrinter.CheckedChanged
        comboPrinters.Enabled = radioPrinter.Checked
    End Sub

    Private Sub comboPrinters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPrinters.SelectedIndexChanged

    End Sub

    Private Sub checkIsDTE_CheckedChanged(sender As Object, e As EventArgs) Handles checkIsDTE.CheckedChanged
        Dim check As CheckBox = sender

        If (IsNothing(check)) Then
            Return
        End If

        Select Case check.Name
            Case "checkIsDTE"
                document.IsDTE = check.Checked
            Case "checkShowUM"
                document.ShowUnidadMedida = check.Checked
        End Select


    End Sub

    Private Sub dateFechaResolucion_ValueChanged(sender As Object, e As EventArgs) Handles dateFechaResolucion.ValueChanged
        Dim datef = TryCast(sender, DateTimePicker)
        If datef Is Nothing Then Return

        Select Case dateF.Name
            Case "dateFechaEmision"
                document.FechaEmision = datef.Value
            Case "dateFechaResolucion"
                document.FechaResolucion = datef.Value
        End Select
    End Sub

    Private Sub gridAdicionales_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gridAdicionales.RowsAdded
        BindAdicionales()
    End Sub

    Private Sub gridAdicionales_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gridAdicionales.RowsRemoved
        BindAdicionales()
    End Sub

    Private Sub gridDescuentosRecargos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gridDescuentosRecargos.RowsAdded
        BindDescuentosRecargos()
    End Sub

    Private Sub gridDescuentosRecargos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gridDescuentosRecargos.RowsRemoved
        BindDescuentosRecargos()
    End Sub

    Private Sub gridDescuentosRecargos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridDescuentosRecargos.CellEndEdit
        BindDescuentosRecargos()
    End Sub

    Private Sub gridAdicionales_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridAdicionales.CellEndEdit
        BindAdicionales()
    End Sub
End Class