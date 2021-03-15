Imports Newtonsoft.Json
Imports SIMPLE_API.Enum.Ambiente

Public Class ConsultaEstadoEnvioDTE

    Dim handler As Handler = New Handler()

    Private Sub ConsultaEstadoEnvioDTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        handler.configuracion.LeerArchivo()
        textRUTEmpresa.Text = handler.configuracion.Empresa.RutCuerpo.ToString()
        textDVEmpresa.Text = handler.configuracion.Empresa.DV
    End Sub

    Private Sub botonConsultar_Click(sender As Object, e As EventArgs) Handles botonConsultar.Click
        Dim trackId As Long = Long.Parse(textTrackID.Text)

        Try

            If radioEnvioDTE.Checked Then
                Dim responseEstadoDTE = handler.ConsultarEstadoEnvio(If(radioProduccion.Checked, AmbienteEnum.Produccion, AmbienteEnum.Certificacion), trackId)
                textRespuesta.Text = responseEstadoDTE.ResponseXml
            Else
                Dim responseEstadoDTE = handler.ConsultarEstadoEnvioBoleta(If(radioProduccion.Checked, AmbienteEnum.Produccion, AmbienteEnum.Certificacion), trackId)
                textRespuesta.Text = JsonConvert.SerializeObject(responseEstadoDTE, Formatting.Indented)
            End If

        Catch ex As Exception
            MessageBox.Show($"Ha ocurrido un error: {ex}")
        End Try
    End Sub
End Class