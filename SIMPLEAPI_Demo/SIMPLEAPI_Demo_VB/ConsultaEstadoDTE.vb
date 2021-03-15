Imports ChileSystems.DTE.Engine.Enum
Imports SIMPLE_API.Enum.Ambiente

Public Class ConsultaEstadoDTE

    Dim handler As Handler = New Handler()


    Private Sub ConsultaEstadoDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each tipo In [Enum].GetValues(GetType(TipoDTE.DTEType))
            comboTipoDTE.Items.Add(tipo)
        Next

        handler.configuracion.LeerArchivo()
        textRUTEmpresa.Text = handler.configuracion.Empresa.RutCuerpo.ToString()
        textDVEmpresa.Text = handler.configuracion.Empresa.DV
        textRUTEnvio.Text = handler.configuracion.Certificado.RutCuerpo.ToString()
        textDVEnvio.Text = handler.configuracion.Certificado.DV
        comboTipoDTE.SelectedIndex = 0
    End Sub

    Private Sub botonConsultar_Click(sender As Object, e As EventArgs) Handles botonConsultar.Click
        Dim rutReceptor As Integer = Integer.Parse(textRUTReceptor.Text)
        Dim dvReceptor As String = textDVReceptor.Text
        Dim folio As Integer = Integer.Parse(textFolio.Text)
        Dim total As Integer = Integer.Parse(textTotal.Text)
        Dim tipoDTE As TipoDTE.DTEType = Nothing
        [Enum].TryParse(comboTipoDTE.SelectedItem.ToString(), tipoDTE)

        Try
            Dim responseEstadoDTE = handler.ConsultarEstadoDTE(If(radioProduccion.Checked, AmbienteEnum.Produccion, AmbienteEnum.Certificacion), rutReceptor, dvReceptor, tipoDTE, folio, dateFechaEmision.Value.Date, total, checkIsBoletaCertificacion.Checked)
            textRespuesta.Text = responseEstadoDTE.ResponseXml
        Catch ex As Exception
            MessageBox.Show($"Ha ocurrido un error: {ex}")
        End Try
    End Sub

    Private Sub comboTipoDTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTipoDTE.SelectedIndexChanged
        Dim tipoDTE As TipoDTE.DTEType = Nothing
        [Enum].TryParse(comboTipoDTE.SelectedItem.ToString(), tipoDTE)
        checkIsBoletaCertificacion.Enabled = tipoDTE = tipoDTE.BoletaElectronica OrElse tipoDTE = tipoDTE.BoletaElectronicaExenta
    End Sub
End Class