Imports Fluent.Infrastructure.FluentModel

Public Class Main

    Dim handler As Handler = New Handler()


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim conf As Configuracion = New Configuracion()
        Dim pregunta As String


        If (conf.VerificarCarpetasIniciales = False) Then
            pregunta = MsgBox("Se deben agregar las carpetas iniciales out\\temp, out\\caf y XML", vbYes)

        End If

        conf.LeerArchivo()

        handler.configuracion = conf




    End Sub

    Private Sub botonIngresarTimbraje_Click(sender As Object, e As EventArgs) Handles botonIngresarTimbraje.Click

        IngresarTimbraje.Show()

    End Sub

    Private Sub botonGenerarDocumento_Click(sender As Object, e As EventArgs) Handles botonGenerarDocumento.Click
        Dim dte = handler.GenerateDTE(ChileSystems.DTE.Engine.Enum.TipoDTE.DTEType.FacturaElectronica, 202)
        handler.GenerateDetails(dte)
        Dim msj As String = ""
        Dim path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        If (Not String.IsNullOrEmpty(msj)) Then
            msj = MsgBox("Ocurrió un error: " + msj)
        Else
            handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
            msj = MsgBox("Documento generado exitosamente en " + path)
        End If
    End Sub

    Private Sub botonGenerarEnvio_Click(sender As Object, e As EventArgs) Handles botonGenerarEnvio.Click

    End Sub

    Private Sub botonConfiguracion_Click(sender As Object, e As EventArgs) Handles botonConfiguracion.Click

        ConfiguracionSistema.Show()
        handler.configuracion.LeerArchivo()



    End Sub

    Private Sub botonMuestraImpresa_Click(sender As Object, e As EventArgs) Handles botonMuestraImpresa.Click

        MuestraImpresa.Show()


    End Sub

    Private Sub botonConsultarEstadoDTE_Click(sender As Object, e As EventArgs) Handles botonConsultarEstadoDTE.Click

        ConsultaEstadoDTE.Show()

    End Sub

    Private Sub botonConsultarEstadoEnvio_Click(sender As Object, e As EventArgs) Handles botonConsultarEstadoEnvio.Click

        ConsultaEstadoEnvioDTE.Show()
    End Sub

    Private Sub botonTimbre_Click(sender As Object, e As EventArgs) Handles botonTimbre.Click

        MuestraTimbre.Show()

    End Sub

    Private Sub botonValidador_Click(sender As Object, e As EventArgs) Handles botonValidador.Click

        Validador.Show()

    End Sub

    Private Sub botonGenerarBoleta_Click(sender As Object, e As EventArgs) Handles botonGenerarBoleta.Click

        GenerarBoletaElectronica.Show()

    End Sub

End Class