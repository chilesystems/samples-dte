Imports System.Security.Cryptography.X509Certificates

Public Class ConfiguracionSistema

    Dim conf As Configuracion = New Configuracion()

    Private Sub ConfiguracionSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        gridResultados.AutoGenerateColumns = gridProductos.AutoGenerateColumns = False


        Try
            Dim store As X509Store = New X509Store(StoreLocation.CurrentUser)
            store.Open(OpenFlags.[ReadOnly])
            Dim certCollection As X509Certificate2Collection = store.Certificates

            For Each c As X509Certificate2 In certCollection
                comboCertificados.Items.Add(c.FriendlyName)
            Next

        Catch
        End Try

        Try

            conf.LeerArchivo()

            textRutEmpresa.Text = conf.Empresa.RutEmpresa
            textGiro.Text = conf.Empresa.Giro
            textRazonSocial.Text = conf.Empresa.RazonSocial
            textComuna.Text = conf.Empresa.Comuna
            textDireccionEmpresa.Text = conf.Empresa.Direccion
            textRutCertificado.Text = conf.Certificado.Rut
            comboCertificados.SelectedItem = conf.Certificado.Nombre
            numericNResolucion.Value = conf.Empresa.NumeroResolucion
            dateFechaResolucion.Value = conf.Empresa.FechaResolucion
            textAPIKey.Text = conf.APIKey
            gridResultados.DataSource = Nothing
            gridResultados.DataSource = conf.Empresa.CodigosActividades
            gridProductos.DataSource = Nothing
            gridProductos.DataSource = conf.ProductosSimulacion
        Catch
        End Try


    End Sub

    Private Sub botonGuardar_Click(sender As Object, e As EventArgs) Handles botonGuardar.Click
        conf.Empresa.RutEmpresa = textRutEmpresa.Text
        conf.Empresa.Giro = textGiro.Text
        conf.Empresa.RazonSocial = textRazonSocial.Text
        conf.Empresa.Comuna = textComuna.Text
        conf.Empresa.Direccion = textDireccionEmpresa.Text
        conf.Empresa.NumeroResolucion = CInt(numericNResolucion.Value)
        conf.Empresa.FechaResolucion = dateFechaResolucion.Value.Date
        conf.APIKey = textAPIKey.Text

        conf.Certificado.Rut = textRutCertificado.Text
        conf.Certificado.Nombre = comboCertificados.SelectedItem.ToString()

        conf.GenerarArchivo()
        MessageBox.Show("Configuración guardada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub gridProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridProductos.CellContentClick
        If e.RowIndex <> -1 AndAlso e.ColumnIndex = 1 Then
            Dim Codigo = TryCast(gridResultados.Rows(e.RowIndex).DataBoundItem, ActividadEconomica)
            conf.Empresa.CodigosActividades.Remove(Codigo)
            gridResultados.DataSource = Nothing
            gridResultados.DataSource = conf.Empresa.CodigosActividades
        End If
    End Sub

    Private Sub comboCertificados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCertificados.SelectedIndexChanged

    End Sub
End Class