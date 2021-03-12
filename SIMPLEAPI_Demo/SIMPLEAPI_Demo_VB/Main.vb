Imports System.IO
Imports System.Text
Imports ChileSystems.DTE.Engine.Enum
Imports Fluent.Infrastructure.FluentModel
Imports SIMPLE_API.Enum

Public Class Main

    Dim handler As Handler = New Handler()
    Dim configuracion As Configuracion = New Configuracion()



#Region "Emision de Documentos"

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

        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Multiselect = True
        Dim result = openFileDialog1.ShowDialog()

        If result = DialogResult.OK Then
            Dim pathFiles As String() = openFileDialog1.FileNames
            Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)()
            Dim xmlDtes As List(Of String) = New List(Of String)()

            For Each pathFile As String In pathFiles
                Dim xml As String = File.ReadAllText(pathFile)
                Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)

                '/*Generar envio para el SII
                '   Un envío puede contener 1 o varios DTE. No es necesario que sean del mismo tipo,
                '   es decir, en un envío pueden ir facturas electrónicas afectas, notas de crédito, guias de despacho,
                '   etc.
                '    */
                dtes.Add(dte)
                xmlDtes.Add(xml)
            Next

            Dim EnvioSII = handler.GenerarEnvioDTEToSII(dtes, xmlDtes)
            '/*Generar envio para el cliente
            '    En esencia es lo mismo que para el SII */
            '    //var EnvioCliente = GenerarEnvioCliente(dte, xml);
            '    /*Puede ser el EnvioSII o EnvioCliente, pues es el mismo tipo de objeto*/

            Dim filePath = EnvioSII.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey)
            handler.Validate(filePath, SIMPLE_API.Security.Firma.Firma.TipoXML.Envio, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE)
            MessageBox.Show("Envío generado exitosamente en " & filePath)
        End If


    End Sub


    Private Sub botonEnviarSii_Click(sender As Object, e As EventArgs) Handles botonEnviarSii.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Multiselect = True
        Dim result = openFileDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            Dim pathFile As String = openFileDialog1.FileName
            Dim msj As String = ""
            Dim trackID As Long = handler.EnviarEnvioDTEToSII(pathFile, IIf(radioProduccion.Checked, Ambiente.AmbienteEnum.Produccion, Ambiente.AmbienteEnum.Certificacion), msj)
            If (Not String.IsNullOrEmpty(msj)) Then
                MsgBox("Ocurrio un Error: " + msj)
            Else
                MsgBox("Sobre enviado correctamente. TrackID: " + trackID.ToString())
            End If
        End If
    End Sub
#End Region

#Region "Simulacion"

    Private Sub botonSimulacion_Click(sender As Object, e As EventArgs) Handles botonSimulacion.Click

        Dim rnd As Random = New Random()
        Dim messageOut As String = String.Empty
        Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)()
        Dim xmlDtes As List(Of String) = New List(Of String)()

        For i As Integer = 31 To 50
            Dim dteAux = handler.GenerateRandomDTE(i, ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica)
            Dim filePath As String = handler.TimbrarYFirmarXMLDTE(dteAux, "out\temp\", "out\caf\", messageOut)
            Dim xml As String = File.ReadAllText(filePath, Encoding.GetEncoding("ISO-8859-1"))
            dtes.Add(dteAux)
            xmlDtes.Add(xml)
        Next

        Dim dteAux2 = handler.GenerateRandomDTE(33, ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica)
        Dim filePath2 = handler.TimbrarYFirmarXMLDTE(dteAux2, "out\temp\", "out\caf\", messageOut)
        Dim xml2 = File.ReadAllText(filePath2, Encoding.GetEncoding("ISO-8859-1"))
        dtes.Add(dteAux2)
        xmlDtes.Add(xml2)
        Dim dteAux3 = handler.GenerateRandomDTE(23, ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica)
        Dim filePath3 = handler.TimbrarYFirmarXMLDTE(dteAux3, "out\temp\", "out\caf\", messageOut)
        Dim xml3 = File.ReadAllText(filePath3, Encoding.GetEncoding("ISO-8859-1"))
        dtes.Add(dteAux3)
        xmlDtes.Add(xml3)
        Dim dteAux4 = handler.GenerateRandomDTE(19, ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaCompraElectronica)
        Dim filePath4 = handler.TimbrarYFirmarXMLDTE(dteAux4, "out\temp\", "out\caf\", messageOut)
        Dim xml4 = File.ReadAllText(filePath4, Encoding.GetEncoding("ISO-8859-1"))
        dtes.Add(dteAux4)
        xmlDtes.Add(xml4)
        Dim EnvioSII = handler.GenerarEnvioDTEToSII(dtes, xmlDtes)
        Dim filePathEnvio As String = EnvioSII.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey)
        MessageBox.Show("Envío generado exitosamente en " & filePathEnvio)
    End Sub


    'Private Sub botonEnviarSimulacionSII_Click(sender As Object, e As EventArgs) Handles botonEnviarSimulacionSII.Click

    '    Dim openFileDialog1 As New OpenFileDialog
    '    openFileDialog1.Multiselect = False
    '    Dim result = openFileDialog1.ShowDialog()

    '    If (result = DialogResult.OK) Then
    '        Dim pathFile As String = openFileDialog1.FileName
    '        Dim msj As String = ""
    '        handler.EnviarEnvioDTEToSII(pathFile, IIf(radioProduccion.Checked, Ambiente.AmbienteEnum.Produccion, Ambiente.AmbienteEnum.Certificacion), msj)
    '        If (Not String.IsNullOrEmpty(msj)) Then
    '            MsgBox("Ocurrio un Error: " + msj)

    '        End If
    '    End If
    'End Sub

#End Region

#Region "Boletas Electronicas"

    Private Sub botonGenerarBoleta_Click(sender As Object, e As EventArgs) Handles botonGenerarBoleta.Click

        GenerarBoletaElectronica.Show()

    End Sub

    Private Sub botonGenerarRCOF_Click(sender As Object, e As EventArgs) Handles botonGenerarRCOF.Click

        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Multiselect = True
        Dim result = openFileDialog1.ShowDialog()

        If result = DialogResult.OK Then
            Dim pathFiles As String() = openFileDialog1.FileNames
            Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)()

            For Each pathFile As String In pathFiles
                Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
                Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
                dtes.Add(dte)
            Next

            Dim rcof = handler.GenerarRCOF(dtes)
            rcof.DocumentoConsumoFolios.Id = "RCOF_" & DateTime.Now.Ticks.ToString()
            Dim xmlString As String = String.Empty
            Dim filePathArchivo = rcof.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey, xmlString)
            MessageBox.Show("RCOF Generado correctamente en " & filePathArchivo)
        End If
    End Sub

    Private Sub botonAnularDocumento_Click(sender As Object, e As EventArgs) Handles botonAnularDocumento.Click

        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.Multiselect = False
        openFileDialog1.ShowDialog()
        Dim result = openFileDialog1.ShowDialog()
        Dim messageOut As String = Nothing

        If result = DialogResult.OK Then
            Dim pathFile As String = openFileDialog1.FileName
            Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dteBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            Dim dteNC = handler.GenerateDTE(TipoDTE.DTEType.NotaCreditoElectronica, 8)
            dteNC.Documento.Detalles = dteBoleta.Documento.Detalles
            dteNC.Documento.Encabezado.Totales = dteBoleta.Documento.Encabezado.Totales
            dteNC.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
            dteNC.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
                .CodigoReferencia = ChileSystems.DTE.Engine.[Enum].TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
                .FechaDocumentoReferencia = DateTime.Now,
                .FolioReferencia = dteBoleta.Documento.Encabezado.IdentificacionDTE.Folio.ToString(),
                .IndicadorGlobal = 0,
                .Numero = 1,
                .RazonReferencia = "ANULA BOLETA ELECTRÓNICA",
                .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.BoletaElectronica
            })
            Dim path = handler.TimbrarYFirmarXMLDTE(dteNC, "out\temp\", "out\caf\", messageOut)
            handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
            MessageBox.Show("Nota de crédito generada exitosamente en " & path)
        End If
    End Sub

    Private Sub botonRebajaDocumento_Click(sender As Object, e As EventArgs) Handles botonRebajaDocumento.Click
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.Multiselect = False
        Dim result = openFileDialog1.ShowDialog()
        Dim messageOut As String = Nothing

        If result = DialogResult.OK Then
            Dim pathFile As String = openFileDialog1.FileName
            Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dteBoleta = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            Dim dteNC = handler.GenerateDTE(TipoDTE.DTEType.NotaCreditoElectronica, 11)
            dteNC.Documento.Detalles = dteBoleta.Documento.Detalles
            dteNC.Documento.Encabezado.Totales = dteBoleta.Documento.Encabezado.Totales
            dteNC.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
            dteNC.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
                .CodigoReferencia = ChileSystems.DTE.Engine.[Enum].TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                .FechaDocumentoReferencia = DateTime.Now,
                .FolioReferencia = dteBoleta.Documento.Encabezado.IdentificacionDTE.Folio.ToString(),
                .IndicadorGlobal = 0,
                .Numero = 1,
                .RazonReferencia = "CORRIGE BOLETA ELECTRÓNICA",
                .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.BoletaElectronica
            })
            Dim porc_descuento As Double = 0.4
            Dim neto = dteNC.Documento.Encabezado.Totales.MontoNeto - (dteNC.Documento.Encabezado.Totales.MontoNeto * porc_descuento)
            Dim netoInt As Integer = CInt(Math.Round(neto, 0))
            Dim iva As Integer = CInt(Math.Round(neto * 0.19, 0))
            Dim total As Integer = netoInt + iva
            dteNC.Documento.Encabezado.Totales.MontoNeto = netoInt
            dteNC.Documento.Encabezado.Totales.IVA = iva
            dteNC.Documento.Encabezado.Totales.MontoTotal = total
            dteNC.Documento.DescuentosRecargos = New List(Of ChileSystems.DTE.Engine.Documento.DescuentosRecargos)()
            dteNC.Documento.DescuentosRecargos.Add(New ChileSystems.DTE.Engine.Documento.DescuentosRecargos() With {
                .Descripcion = "DESCUENTO COMERCIAL",
                .Numero = 1,
                .TipoMovimiento = ChileSystems.DTE.Engine.[Enum].TipoMovimiento.TipoMovimientoEnum.Descuento,
                .TipoValor = ChileSystems.DTE.Engine.[Enum].ExpresionDinero.ExpresionDineroEnum.Porcentaje,
                .Valor = porc_descuento * 100
            })
            Dim path = handler.TimbrarYFirmarXMLDTE(dteNC, "out\temp\", "out\caf\", messageOut)
            handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
            MessageBox.Show("Nota de crédito generada exitosamente en " & path)
        End If
    End Sub

    Private Sub botonGenerarEnvioBoleta_Click(sender As Object, e As EventArgs) Handles botonGenerarEnvioBoleta.Click
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.Multiselect = True
        Dim result = openFileDialog1.ShowDialog()

        If result = DialogResult.OK Then
            Dim pathFiles As String() = openFileDialog1.FileNames
            Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)()
            Dim xmlDtes As List(Of String) = New List(Of String)()

            For Each pathFile As String In pathFiles
                Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
                Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
                dtes.Add(dte)
                xmlDtes.Add(xml)
            Next

            Dim EnvioSII = handler.GenerarEnvioBoletaDTEToSII(dtes, xmlDtes)
            Dim filePath = EnvioSII.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey)

            Try
                handler.Validate(filePath, SIMPLE_API.Security.Firma.Firma.TipoXML.EnvioBoleta, ChileSystems.DTE.Engine.XML.Schemas.EnvioBoleta)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            MessageBox.Show("Envío generado exitosamente en " & filePath)
        End If
    End Sub

#End Region

#Region "Utilitarios"

    Private Sub botonAceptacion_Click(sender As Object, e As EventArgs) Handles botonAceptacion.Click
        '/*
        '        * ACD: Acepta Contenido del Documento
        '        * RCD: Reclamo al Contenido del Documento
        '        * ERM: Otorga Recibo de Mercaderías o Servicios
        '        * RFP: Reclamo por Falta Parcial de Mercaderías
        '        * RFT: Reclamo por Falta Total de Mercaderías
        '        */

        Dim tipoDocumento As Integer = 33
        Dim folio As Integer = 17158136
        Dim accion As String = "ACD"
        Dim rutProveedor As String = "88888888"
        Dim dvProveedor As Integer = 8
        Dim respuesta = handler.EnviarAceptacionReclamo(tipoDocumento, folio, accion, rutProveedor, dvProveedor, If(radioCertificacion.Checked, AmbienteEnum.Certificacion, AmbienteEnum.Produccion))
        MessageBox.Show(respuesta)
    End Sub

    Private Sub botonConsultarEstadoDTE_Click(sender As Object, e As EventArgs) Handles botonConsultarEstadoDTE.Click

        ConsultaEstadoDTE.Show()

    End Sub
#End Region

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim conf As Configuracion = New Configuracion()
        Dim pregunta As String


        If (conf.VerificarCarpetasIniciales = False) Then
            pregunta = MsgBox("Se deben agregar las carpetas iniciales out\\temp, out\\caf y XML", vbYes)

        End If

        conf.LeerArchivo()

        handler.configuracion = conf




    End Sub

    Private Sub botonValidador_Click(sender As Object, e As EventArgs) Handles botonValidador.Click

        Validador.Show()

    End Sub

    Private Sub botonSetPruebas_Click(sender As Object, e As EventArgs) Handles botonSetPruebas.Click
        Dim pathFiles As List(Of String) = New List(Of String)()
        Dim folios As List(Of Integer) = New List(Of Integer)()
        Dim messageOut As String = String.Empty
        Dim nAtencion As String = "1092644"

        For i As Integer = 51 To 53 '4 facturas
            folios.Add(i)
        Next

        For i As Integer = 14 To 16 '3 notas de credito
            folios.Add(i)
        Next

        folios.Add(6) '1 nota de debito


#Region "DTEs"

        '/******************************/
        Dim casoPruebas As String = "CASO " + nAtencion + "-1"
        Dim dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(0))
        Dim detalles As New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 139,
        .Nombre = "Cajón AFECTO",
        .Precio = 1838,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 59,
        .Nombre = "Relleno AFECTO",
        .Precio = 3021,
        .Afecto = True
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(0), casoPruebas)
        Dim msj As String = ""
        Dim path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
        '/******************************/



        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-2"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(1))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 422,
        .Nombre = "Panuelo AFECTO",
        .Precio = 3334,
        .Descuento = 6,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 354,
        .Nombre = "Item 2 AFECTO",
        .Precio = 2393,
        .Descuento = 12,
        .Afecto = True
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(1), casoPruebas)
        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/

        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-3"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(2))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 32,
        .Nombre = "Pintura B&W AFECTO",
        .Precio = 3820,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 180,
        .Nombre = "Item 2 AFECTO",
        .Precio = 3261,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 1,
        .Nombre = "Item 3 SERVICIO AFECTO",
        .Precio = 34914,
        .Afecto = False
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(2), casoPruebas)
        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/


        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-4"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(3))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 200,
        .Nombre = "ITEM 1 AFECTO",
        .Precio = 3186,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 85,
        .Nombre = "Item 2 AFECTO",
        .Precio = 3473,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 2,
        .Nombre = "Item 3 SERVICIO EXENTO",
        .Precio = 6791,
        .Afecto = False
        })
        dte.Documento.DescuentosRecargos = New List(Of ChileSystems.DTE.Engine.Documento.DescuentosRecargos)
        dte.Documento.DescuentosRecargos.Add(New ChileSystems.DTE.Engine.Documento.DescuentosRecargos() With {
        .Descripcion = "DESCUENTO COMERCIAL",
        .Numero = 1,
        .TipoMovimiento = TipoMovimiento.TipoMovimientoEnum.Descuento,
        .TipoValor = ExpresionDinero.ExpresionDineroEnum.Porcentaje,
        .Valor = 12
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(3), casoPruebas)
        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/


        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-5"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(4))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
        .Nombre = "CORRIGE GIRO DEL RECEPTOR",
        .Afecto = True
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(4), casoPruebas)
        dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
        .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.CorrigeTextoDocumentoReferencia,
        .FechaDocumentoReferencia = DateTime.Now,
        .FolioReferencia = folios(0).ToString(),
        .IndicadorGlobal = 0,
        .Numero = 2,
        .RazonReferencia = "CORRIGE GIRO DEL RECEPTOR",
        .TipoDocumento = TipoDTE.TipoReferencia.FacturaElectronica
        })

        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/


        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-6"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(5))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
         .Cantidad = 155,
        .Nombre = "Pañuelo AFECTO",
        .Precio = 3334,
        .Descuento = 6,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
         .Cantidad = 240,
        .Nombre = "ITEM 2 AFECTO",
        .Precio = 2393,
        .Descuento = 12,
        .Afecto = True
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(5), casoPruebas)
        dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
        .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
        .FechaDocumentoReferencia = DateTime.Now,
        .FolioReferencia = folios(1).ToString(),
        .IndicadorGlobal = 0,
        .Numero = 2,
        .RazonReferencia = "DEVOLUCIÓN DE MERCADERÍAS",
        .TipoDocumento = TipoDTE.TipoReferencia.FacturaElectronica
        })

        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/


        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-7"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(6))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
         .Cantidad = 32,
        .Nombre = "Pintura B&W AFECTO",
        .Precio = 3820,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
         .Cantidad = 180,
        .Nombre = "ITEM 2 AFECTO",
        .Precio = 3261,
        .Afecto = True
        })
        detalles.Add(New ItemBoleta() With {
         .Cantidad = 1,
        .Nombre = "ITEM 3 SERVICIO AFECTO",
        .Precio = 34914,
        .Afecto = True
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(6), casoPruebas)
        dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
        .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
        .FechaDocumentoReferencia = DateTime.Now,
        .FolioReferencia = folios(2).ToString(),
        .IndicadorGlobal = 0,
        .Numero = 2,
        .RazonReferencia = "ANULA FACTURA",
        .TipoDocumento = TipoDTE.TipoReferencia.FacturaElectronica
        })

        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/

        '/******************************/
        casoPruebas = "CASO " + nAtencion + "-8"
        dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(7))
        detalles = New List(Of ItemBoleta)
        detalles.Add(New ItemBoleta() With {
        .Nombre = "CORRIGE GIRO DEL RECEPTOR",
        .Afecto = True
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(7), casoPruebas)
        dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
        .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
        .FechaDocumentoReferencia = DateTime.Now,
        .FolioReferencia = folios(4).ToString(),
        .IndicadorGlobal = 0,
        .Numero = 2,
        .RazonReferencia = "ANULA NOTA DE CREDITO",
        .TipoDocumento = TipoDTE.TipoReferencia.NotaCreditoElectronica
        })

        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)


        '/******************************/


#End Region



#Region "Envio de Documentos"

        Dim dtes As List(Of ChileSystems.DTE.Engine.Documento.DTE) = New List(Of ChileSystems.DTE.Engine.Documento.DTE)()
        Dim xmlDtes As List(Of String) = New List(Of String)()

        For Each pathFile As String In pathFiles
            Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dteAux = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            dtes.Add(dteAux)
            xmlDtes.Add(xml)
        Next

        Dim EnvioSII = handler.GenerarEnvioDTEToSII(dtes, xmlDtes)
        path = EnvioSII.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.Envio, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE)
        MessageBox.Show("Envío generado exitosamente en " & path)

#End Region


#Region "Libro de VENTAS"

        Dim libroVentas = handler.GenerateLibroVentas(EnvioSII)
        path = libroVentas.Firmar(configuracion.Certificado.Nombre, "out\temp\", configuracion.APIKey)
        MessageBox.Show("Libro ventas guardado en " & path)

#End Region

#Region "Libro de COMPRAS"

        Dim libroCompras = handler.GenerateLibroCompras()
        path = libroCompras.Firmar(configuracion.Certificado.Nombre, "out\temp\", configuracion.APIKey)
        MessageBox.Show("Libro compras guardado en " & path)

#End Region

        '//MessageBox.Show("Documento generado exitosamente en " + path);
    End Sub

    Private Sub botonConfiguracion_Click(sender As Object, e As EventArgs) Handles botonConfiguracion.Click

        ConfiguracionSistema.Show()
        handler.configuracion.LeerArchivo()



    End Sub

    Private Sub botonMuestraImpresa_Click(sender As Object, e As EventArgs) Handles botonMuestraImpresa.Click

        MuestraImpresa.Show()


    End Sub



    Private Sub botonConsultarEstadoEnvio_Click(sender As Object, e As EventArgs) Handles botonConsultarEstadoEnvio.Click

        ConsultaEstadoEnvioDTE.Show()
    End Sub

    Private Sub botonTimbre_Click(sender As Object, e As EventArgs) Handles botonTimbre.Click

        MuestraTimbre.Show()

    End Sub

    Private Sub botonFacturaCompra_Click(sender As Object, e As EventArgs) Handles botonFacturaCompra.Click
        Dim pathFiles As New List(Of String)
        Dim folios As New List(Of Integer)
        Dim nAtencion As String = "1092644"
        Dim messageOut As String = String.Empty
        folios.Add(18)
        folios.Add(32)
        folios.Add(22)
        nAtencion = "1092647"
        Dim casoPruebas As String = "CASO " & nAtencion & "-1"
        Dim dte = handler.GenerateDTE(TipoDTE.DTEType.FacturaElectronica, folios(0))
        Dim detalles = New List(Of ItemBoleta)()
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 521,
        .Nombre = "Producto 1",
        .Precio = 4301,
        .Afecto = True,
        .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 27,
        .Nombre = "Producto 2",
        .Precio = 2279,
        .Afecto = True,
        .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(0), casoPruebas)
        Dim msj As String = ""
        Dim path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)

        '/******************************/

        '/******************************/

        dte = handler.GenerateDTE(TipoDTE.DTEType.NotaCreditoElectronica, folios(1))
        detalles = New List(Of ItemBoleta)()
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 174,
        .Nombre = "Producto 1",
        .Precio = 4301,
        .Afecto = True,
        .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 9,
        .Nombre = "Producto 2",
        .Precio = 2279,
        .Afecto = True,
        .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(1), casoPruebas)
        dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
        .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
        .FechaDocumentoReferencia = DateTime.Now,
        .FolioReferencia = folios(0).ToString(),
        .IndicadorGlobal = 0,
        .Numero = 2,
        .RazonReferencia = "DEVOLUCIÓN DE MERCADERÍA ITEMS 1 y 2",
        .TipoDocumento = TipoDTE.TipoReferencia.FacturaCompraElectronica
        })
        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)

        '/******************************/

        '/******************************/

        dte = handler.GenerateDTE(TipoDTE.DTEType.NotaCreditoElectronica, folios(2))
        detalles = New List(Of ItemBoleta)()
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 174,
        .Nombre = "Producto 1",
        .Precio = 4301,
        .Afecto = True,
        .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
        })
        detalles.Add(New ItemBoleta() With {
        .Cantidad = 9,
        .Nombre = "Producto 2",
        .Precio = 2279,
        .Afecto = True,
        .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
        })
        handler.GenerateDetails(dte, detalles)
        handler.Referencias(dte, TipoReferencia.TipoReferenciaEnum.SetPruebas, TipoDTE.TipoReferencia.NotSet, DateTime.Now, folios(2), casoPruebas)
        dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
        .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia,
        .FechaDocumentoReferencia = DateTime.Now,
        .FolioReferencia = folios(1).ToString(),
        .IndicadorGlobal = 0,
        .Numero = 2,
        .RazonReferencia = "ANULA NOTA DE CREDITO",
        .TipoDocumento = TipoDTE.TipoReferencia.NotaCreditoElectronica
        })
        msj = ""
        path = handler.TimbrarYFirmarXMLDTE(dte, "out\\temp\\", "out\\caf\\", msj)
        pathFiles.Add(path)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)

        '/******************************/

        Dim dtes = New List(Of ChileSystems.DTE.Engine.Documento.DTE)()
        Dim xmlDtes = New List(Of String)()

        For Each pathFile As String In pathFiles
            Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim dteAux = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            dtes.Add(dteAux)
            xmlDtes.Add(xml)
        Next

        Dim EnvioSII = handler.GenerarEnvioDTEToSII(dtes, xmlDtes)
        path = EnvioSII.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey)
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.Envio, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE)
        MessageBox.Show("Envío generado exitosamente en " & path)

    End Sub

    Private Sub botonIntercambio_Click(sender As Object, e As EventArgs) Handles botonIntercambio.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.Multiselect = False
        openFileDialog1.ShowDialog()
        Dim pathFile As String = openFileDialog1.FileName
        Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
        Dim envio = ChileSystems.DTE.Engine.XML.XmlHandler.TryDeserializeFromString(Of ChileSystems.DTE.Engine.Envio.EnvioDTE)(xml)
        Dim filePath = handler.GenerarRespuestaEnvio(envio.SetDTE.DTEs, "ACD")
        MessageBox.Show("Respuesta de Intercambio " & filePath)
        filePath = handler.AcuseReciboMercaderias(envio.SetDTE.DTEs(0))
        MessageBox.Show("Acuse recibo " & filePath)
        filePath = handler.ResponderDTE(0, envio.SetDTE.DTEs(0), "PRUEBA")
        MessageBox.Show("Aprobación comercial " & filePath)
    End Sub

    Private Sub botonCesion_Click(sender As Object, e As EventArgs) Handles botonCesion.Click
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.Multiselect = False
        Dim message As String = Nothing

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim pathFile As String = openFileDialog1.FileName
            Dim xml As String = File.ReadAllText(pathFile, Encoding.GetEncoding("ISO-8859-1"))
            Dim AEC = New SIMPLE_API.Cesion.AEC()
            Dim dteCedido = New SIMPLE_API.Cesion.DTECedido(xml)
            Dim xmlDteCedido = dteCedido.Firmar(configuracion.Certificado.Nombre, message)
            Dim dte = ChileSystems.DTE.Engine.XML.XmlHandler.DeserializeFromString(Of ChileSystems.DTE.Engine.Documento.DTE)(xml)
            Dim cesion = New SIMPLE_API.Cesion.Cesion(dte, 1)
            Dim cesionario = New SIMPLE_API.Cesion.Cesionario() With {
                .Direccion = "Dirección Cesionario",
                .eMail = "Email Cesionario",
                .RazonSocial = "Factoring LTDA",
                .RUT = "11111111-1"
            }
            Dim cedente = New SIMPLE_API.Cesion.Cedente() With {
                .RUT = dte.Documento.Encabezado.Emisor.Rut,
                .RazonSocial = dte.Documento.Encabezado.Emisor.RazonSocial,
                .Direccion = dte.Documento.Encabezado.Emisor.DireccionOrigen & ", " + dte.Documento.Encabezado.Emisor.ComunaOrigen,
                .eMail = dte.Documento.Encabezado.Emisor.CorreoElectronico,
                .RUTsAutorizados = New List(Of SIMPLE_API.Cesion.RUTAutorizado)() From {
                    New SIMPLE_API.Cesion.RUTAutorizado() With {
                        .Nombre = "Nombre Autorizado",
                        .RUT = "RUT Autorizado"
                    }
                }
            }
            Dim declaracionJurada As String = String.Format("Se declara bajo juramento que {0}, RUT {1} ha puesto a disposición del 
                    cesionario {2}, RUT {3}, el o los documentos donde constan los recibos 
                    de las mercaderías entregadas o servicios prestados, entregados por parte 
                    del deudor de la factura {4}, RUT {5}, de acuerdo a lo establecido en la 
                    Ley N° 19.983", cedente.RazonSocial, cedente.RUT, cesionario.RazonSocial, cesionario.RUT, dte.Documento.Encabezado.Receptor.RazonSocial, dte.Documento.Encabezado.Receptor.Rut)
            cedente.DeclaracionJurada = declaracionJurada
            cesion.DocumentoCesion.Cedente = cedente
            cesion.DocumentoCesion.Cesionario = cesionario
            Dim cesionXML = cesion.Firmar(configuracion.Certificado.Nombre, message)
            AEC.DocumentoAEC.Caratula = New SIMPLE_API.Cesion.Caratula() With {
                .MailContacto = cedente.eMail,
                .NombreContacto = cedente.RUTsAutorizados(0).Nombre,
                .RutCedente = cedente.RUT,
                .RutCesionario = cesionario.RUT,
                .TmstFirmaEnvio = DateTime.Now
            }
            AEC.signedXMLCedido = File.ReadAllText(xmlDteCedido, Encoding.GetEncoding("ISO-8859-1"))
            AEC.signedXMLCesion.Add(File.ReadAllText(cesionXML, Encoding.GetEncoding("ISO-8859-1")))
            AEC.DocumentoAEC.ID = "ID_TEST"
            Dim filePathAEC = AEC.Firmar(configuracion.Certificado.Nombre, message)
            File.Delete(xmlDteCedido)
            File.Delete(cesionXML)
            MessageBox.Show("AEC generado exitosamente en " & filePathAEC)
        End If
    End Sub

    Private Sub botonSetExportacion_Click(sender As Object, e As EventArgs) Handles botonSetExportacion.Click

        Dim n_atencion = "1221632"
        Dim folioFactura As Integer = 51
        Dim folioNC As Integer = 51
        Dim folioND As Integer = 51

#Region "SET EXPORTACION 1"

        Dim dte = handler.GenerateDTEExportacionBase(TipoDTE.DTEType.FacturaExportacionElectronica, folioFactura)
        dte.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion = SIMPLE_API.[Enum].CodigosAduana.FormaPagoExportacionEnum.ACRED
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoModalidadVenta = SIMPLE_API.[Enum].CodigosAduana.ModalidadVenta.A_FIRME
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoClausulaVenta = SIMPLE_API.[Enum].CodigosAduana.ClausulaCompraVenta.FOB
        dte.Exportaciones.Encabezado.Transporte.Aduana.TotalClausulaVenta = 285.88
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoViaTransporte = SIMPLE_API.[Enum].CodigosAduana.ViasdeTransporte.AEREO
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPuertoEmbarque = SIMPLE_API.[Enum].CodigosAduana.Puertos.ARICA
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPuertoDesembarque = SIMPLE_API.[Enum].CodigosAduana.Puertos.BUENOS_AIRES
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoUnidadMedidaTara = SIMPLE_API.[Enum].CodigosAduana.UnidadMedida.U
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoUnidadPesoBruto = SIMPLE_API.[Enum].CodigosAduana.UnidadMedida.U
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoUnidadPesoNeto = SIMPLE_API.[Enum].CodigosAduana.UnidadMedida.U
        dte.Exportaciones.Encabezado.Transporte.Aduana.CantidadBultos = 15
        dte.Exportaciones.Encabezado.Transporte.Aduana.TipoBultos = New List(Of ChileSystems.DTE.Engine.Documento.TipoBulto)()
        dte.Exportaciones.Encabezado.Transporte.Aduana.TipoBultos.Add(New ChileSystems.DTE.Engine.Documento.TipoBulto() With {
            .CantidadBultos = 15,
            .CodigoTipoBulto = SIMPLE_API.[Enum].CodigosAduana.TipoBultoEnum.CONTENEDOR_REFRIGERADO,
            .IdContainer = "erer787df",
            .Sello = "SelloTest"
        })
        dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete = 13.62
        dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro = 0.65
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPaisDestino = SIMPLE_API.[Enum].CodigosAduana.Paises.ARGENTINA
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPaisReceptor = SIMPLE_API.[Enum].CodigosAduana.Paises.ARGENTINA
        dte.Exportaciones.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.DetalleExportacion)()
        Dim detalle = New ChileSystems.DTE.Engine.Documento.DetalleExportacion()
        detalle.NumeroLinea = 1
        detalle.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
        detalle.Nombre = "CHATARRA DE ALUMINIO"
        detalle.Cantidad = 148
        detalle.UnidadMedida = "U"
        detalle.Precio = 105
        detalle.MontoItem = 148 * 105
        dte.Exportaciones.Detalles.Add(detalle)
        dte.Exportaciones.DescuentosRecargos = New List(Of ChileSystems.DTE.Engine.Documento.DescuentosRecargos)()
        Dim descuentoFlete = New ChileSystems.DTE.Engine.Documento.DescuentosRecargos()
        descuentoFlete.Numero = 1
        descuentoFlete.TipoMovimiento = ChileSystems.DTE.Engine.[Enum].TipoMovimiento.TipoMovimientoEnum.Recargo
        descuentoFlete.Descripcion = "Recargo flete"
        descuentoFlete.TipoValor = ChileSystems.DTE.Engine.[Enum].ExpresionDinero.ExpresionDineroEnum.Pesos
        descuentoFlete.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorExento.IndicadorExentoEnum.Exento
        descuentoFlete.Valor = dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete
        dte.Exportaciones.DescuentosRecargos.Add(descuentoFlete)
        Dim descuentoSeguro = New ChileSystems.DTE.Engine.Documento.DescuentosRecargos()
        descuentoSeguro.Numero = 2
        descuentoSeguro.TipoMovimiento = ChileSystems.DTE.Engine.[Enum].TipoMovimiento.TipoMovimientoEnum.Recargo
        descuentoSeguro.Descripcion = "Recargo seguro"
        descuentoSeguro.TipoValor = ChileSystems.DTE.Engine.[Enum].ExpresionDinero.ExpresionDineroEnum.Pesos
        descuentoSeguro.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorExento.IndicadorExentoEnum.Exento
        descuentoSeguro.Valor = dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro
        dte.Exportaciones.DescuentosRecargos.Add(descuentoSeguro)
        dte.Exportaciones.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
        Dim referenciaSetPruebas = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaSetPruebas.Numero = 1
        referenciaSetPruebas.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.SetPruebas
        referenciaSetPruebas.FolioReferencia = dte.Exportaciones.Encabezado.IdentificacionDTE.Folio.ToString()
        referenciaSetPruebas.FechaDocumentoReferencia = DateTime.Now
        referenciaSetPruebas.RazonReferencia = "CASO " & n_atencion & "-1"
        dte.Exportaciones.Referencias.Add(referenciaSetPruebas)
        Dim referenciaManifiesto = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaManifiesto.Numero = 2
        referenciaManifiesto.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.MIC
        referenciaManifiesto.FolioReferencia = "asdasd47df"
        referenciaManifiesto.FechaDocumentoReferencia = DateTime.Now
        referenciaManifiesto.RazonReferencia = "MANIFIESTO INTERNACIONAL"
        dte.Exportaciones.Referencias.Add(referenciaManifiesto)
        dte.Exportaciones.Encabezado.Totales.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.DOLAR_ESTADOUNIDENSE
        dte.Exportaciones.Encabezado.OtraMoneda.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.PESO_CHILENO
        dte.Exportaciones.Encabezado.OtraMoneda.TipoCambio = 681.07
        handler.CalculateTotalesExportacion(dte)
        Dim path = handler.TimbrarYFirmarXMLDTEExportacion(dte, "out\temp\", "out\caf\")
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
        MessageBox.Show("Documento generado exitosamente en " & path)

#End Region

#Region "NOTA CREDITO EXPORTACION"

        Dim dteNC = handler.GenerateDTEExportacionBase(TipoDTE.DTEType.NotaCreditoExportacionElectronica, folioNC)
        dteNC.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion = dte.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion
        dteNC.Exportaciones.Encabezado.Transporte.Aduana = dte.Exportaciones.Encabezado.Transporte.Aduana
        dteNC.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete = 0
        dteNC.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro = 0
        dteNC.Exportaciones.Encabezado.Transporte.Aduana.CantidadBultos = 0

        dteNC.Exportaciones.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.DetalleExportacion)
        Dim detalleNC = New ChileSystems.DTE.Engine.Documento.DetalleExportacion
        detalleNC.NumeroLinea = 1
        detalleNC.IndicadorExento = IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
        detalleNC.Nombre = detalle.Nombre
        detalleNC.Cantidad = 49
        detalleNC.UnidadMedida = detalle.UnidadMedida
        detalleNC.Precio = detalle.Precio
        detalleNC.MontoItem = CInt(Math.Round(detalleNC.Cantidad * detalleNC.Precio, 0))
        dteNC.Exportaciones.Detalles.Add(detalleNC)

        dteNC.Exportaciones.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
        referenciaSetPruebas = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaSetPruebas.Numero = 1
        referenciaSetPruebas.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.SetPruebas
        referenciaSetPruebas.FolioReferencia = dteNC.Exportaciones.Encabezado.IdentificacionDTE.Folio.ToString()
        referenciaSetPruebas.FechaDocumentoReferencia = DateTime.Now
        referenciaSetPruebas.RazonReferencia = "CASO " & n_atencion & "-2"
        dteNC.Exportaciones.Referencias.Add(referenciaSetPruebas)

        Dim referenciaNC = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaNC.Numero = 2
        referenciaNC.CodigoReferencia = ChileSystems.DTE.Engine.[Enum].TipoReferencia.TipoReferenciaEnum.CorrigeMontos
        referenciaNC.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.FacturaExportacionElectronica
        referenciaNC.FolioReferencia = dte.Exportaciones.Encabezado.IdentificacionDTE.Folio.ToString()
        referenciaNC.FechaDocumentoReferencia = DateTime.Now
        referenciaNC.RazonReferencia = "ANULACION DE FACTURA DE EXPORTACIÓN"


        dteNC.Exportaciones.Referencias.Add(referenciaNC)
        dteNC.Exportaciones.Encabezado.Totales.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.DOLAR_ESTADOUNIDENSE
        dteNC.Exportaciones.Encabezado.OtraMoneda.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.PESO_CHILENO
        dteNC.Exportaciones.Encabezado.OtraMoneda.TipoCambio = 681.07
        handler.CalculateTotalesExportacion(dteNC)
        Dim pathNC = handler.TimbrarYFirmarXMLDTEExportacion(dteNC, "out\temp\", "out\caf\")
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
        MessageBox.Show("NC generada exitosamente en " & pathNC)

#End Region

#Region "NOTA DEBITO EXPORTACION"

        Dim dteND = handler.GenerateDTEExportacionBase(TipoDTE.DTEType.NotaDebitoExportacionElectronica, folioND)
        dteND.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion = dteNC.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion
        dteND.Exportaciones.Encabezado.Transporte.Aduana = dteNC.Exportaciones.Encabezado.Transporte.Aduana
        dteND.Exportaciones.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.DetalleExportacion)()
        Dim detalleND = detalleNC
        dteND.Exportaciones.Detalles.Add(detalleND)
        dteND.Exportaciones.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
        referenciaSetPruebas = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaSetPruebas.Numero = 1
        referenciaSetPruebas.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.SetPruebas
        referenciaSetPruebas.FolioReferencia = dteNC.Exportaciones.Encabezado.IdentificacionDTE.Folio.ToString()
        referenciaSetPruebas.FechaDocumentoReferencia = DateTime.Now
        referenciaSetPruebas.RazonReferencia = "CASO " & n_atencion & "-3"
        dteND.Exportaciones.Referencias.Add(referenciaSetPruebas)
        Dim referenciaND = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaND.Numero = 2
        referenciaND.CodigoReferencia = ChileSystems.DTE.Engine.[Enum].TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia
        referenciaND.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.NotaCreditoExportacionElectronica
        referenciaND.FolioReferencia = dteNC.Exportaciones.Encabezado.IdentificacionDTE.Folio.ToString()
        referenciaND.FechaDocumentoReferencia = DateTime.Now
        referenciaNC.RazonReferencia = "ANULACION NOTA DE CREDITO DE EXPORTACION"
        dteND.Exportaciones.Referencias.Add(referenciaND)
        dteND.Exportaciones.Encabezado.Totales.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.DOLAR_ESTADOUNIDENSE
        dteND.Exportaciones.Encabezado.OtraMoneda.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.PESO_CHILENO
        dteND.Exportaciones.Encabezado.OtraMoneda.TipoCambio = 681.07
        handler.CalculateTotalesExportacion(dteND)
        Dim pathND = handler.TimbrarYFirmarXMLDTEExportacion(dteND, "out\temp\", "out\caf\")
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
        MessageBox.Show("NC generada exitosamente en " & pathND)

#End Region

    End Sub

    Private Sub botonSetExportacion2_Click(sender As Object, e As EventArgs) Handles botonSetExportacion2.Click
        Dim n_atencion = "1221633"
        Dim folioFactura As Integer = 58

#Region "SET EXPORTACION 1"

#Region "FACTURA EXPORTACION 1"
        Dim dte = handler.GenerateDTEExportacionBase(TipoDTE.DTEType.FacturaExportacionElectronica, folioFactura)
        dte.Exportaciones.Encabezado.IdentificacionDTE.IndicadorServicio = ChileSystems.DTE.Engine.[Enum].IndicadorServicio.IndicadorServicioEnum.FacturaServicios2
        dte.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion = SIMPLE_API.[Enum].CodigosAduana.FormaPagoExportacionEnum.ACRED
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoClausulaVenta = SIMPLE_API.[Enum].CodigosAduana.ClausulaCompraVenta.FOB
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoViaTransporte = SIMPLE_API.[Enum].CodigosAduana.ViasdeTransporte.AEREO
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPuertoEmbarque = SIMPLE_API.[Enum].CodigosAduana.Puertos.ARICA
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPuertoDesembarque = SIMPLE_API.[Enum].CodigosAduana.Puertos.BUENOS_AIRES
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPaisDestino = SIMPLE_API.[Enum].CodigosAduana.Paises.ARGENTINA
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPaisReceptor = SIMPLE_API.[Enum].CodigosAduana.Paises.ARGENTINA

        dte.Exportaciones.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.DetalleExportacion)()
        Dim detalle = New ChileSystems.DTE.Engine.Documento.DetalleExportacion()
        detalle.NumeroLinea = 1
        detalle.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
        detalle.Nombre = "ASESORIAS Y PROYECTOS PROFESIONALES"
        detalle.Cantidad = 1
        detalle.Precio = 19
        detalle.Recargo = 2
        detalle.RecargoPorcentaje = 10
        detalle.MontoItem = 19 + 2 '26*1 + 10% 
        dte.Exportaciones.Detalles.Add(detalle)

        dte.Exportaciones.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
        Dim referenciaSetPruebas = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaSetPruebas.Numero = 1
        referenciaSetPruebas.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.SetPruebas
        referenciaSetPruebas.FolioReferencia = dte.Exportaciones.Encabezado.IdentificacionDTE.Folio.ToString()
        referenciaSetPruebas.FechaDocumentoReferencia = DateTime.Now
        referenciaSetPruebas.RazonReferencia = "CASO " & n_atencion & "-1"
        dte.Exportaciones.Referencias.Add(referenciaSetPruebas)
        Dim referenciaManifiesto = New ChileSystems.DTE.Engine.Documento.Referencia()
        referenciaManifiesto.Numero = 2
        referenciaManifiesto.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.ResolucionSNA
        referenciaManifiesto.FolioReferencia = "erere4f7d54"
        referenciaManifiesto.FechaDocumentoReferencia = DateTime.Now
        referenciaManifiesto.RazonReferencia = "RESOLUCION SNA"
        dte.Exportaciones.Referencias.Add(referenciaManifiesto)
        dte.Exportaciones.Encabezado.Totales.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.DOLAR_ESTADOUNIDENSE
        dte.Exportaciones.Encabezado.OtraMoneda.TipoMoneda = SIMPLE_API.[Enum].CodigosAduana.Moneda.PESO_CHILENO
        dte.Exportaciones.Encabezado.OtraMoneda.TipoCambio = 700

        handler.CalculateTotalesExportacion(dte)
        Dim path = handler.TimbrarYFirmarXMLDTEExportacion(dte, "out\temp\", "out\caf\")
        handler.Validate(path, SIMPLE_API.Security.Firma.Firma.TipoXML.DTE, ChileSystems.DTE.Engine.XML.Schemas.DTE)
        MessageBox.Show("Documento generado exitosamente en " & path)
#End Region
        folioFactura += 1
#Region "FACTURA EXPORTACION 2"
        dte = handler.GenerateDTEExportacionBase(TipoDTE.DTEType.FacturaExportacionElectronica, folioFactura)
        dte.Exportaciones.Encabezado.IdentificacionDTE.FormaPagoExportacion = SIMPLE_API.[Enum].CodigosAduana.FormaPagoExportacionEnum.ACRED
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoModalidadVenta = SIMPLE_API.[Enum].CodigosAduana.ModalidadVenta.A_FIRME
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoClausulaVenta = SIMPLE_API.[Enum].CodigosAduana.ClausulaCompraVenta.FOB
        dte.Exportaciones.Encabezado.Transporte.Aduana.TotalClausulaVenta = 1138.3
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoViaTransporte = SIMPLE_API.[Enum].CodigosAduana.ViasdeTransporte.AEREO
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPuertoEmbarque = SIMPLE_API.[Enum].CodigosAduana.Puertos.ARICA
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPuertoDesembarque = SIMPLE_API.[Enum].CodigosAduana.Puertos.BUENOS_AIRES
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoUnidadMedidaTara = SIMPLE_API.[Enum].CodigosAduana.UnidadMedida.U
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoUnidadPesoBruto = SIMPLE_API.[Enum].CodigosAduana.UnidadMedida.U
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoUnidadPesoNeto = SIMPLE_API.[Enum].CodigosAduana.UnidadMedida.KN
        dte.Exportaciones.Encabezado.Transporte.Aduana.CantidadBultos = 29
        dte.Exportaciones.Encabezado.Transporte.Aduana.TipoBultos = New List(Of ChileSystems.DTE.Engine.Documento.TipoBulto)()
        dte.Exportaciones.Encabezado.Transporte.Aduana.TipoBultos.Add(New ChileSystems.DTE.Engine.Documento.TipoBulto() With {
        .CantidadBultos = 29,
        .CodigoTipoBulto = SIMPLE_API.[Enum].CodigosAduana.TipoBultoEnum.CONTENEDOR_REFRIGERADO,
        .Marcas = "MARCA CHANCHO",
        .IdContainer = "erer787df1",
        .Sello = "SelloTest2"
    })
        dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete = 215.95
        dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro = 40.97
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPaisDestino = SIMPLE_API.[Enum].CodigosAduana.Paises.ARGENTINA
        dte.Exportaciones.Encabezado.Transporte.Aduana.CodigoPaisReceptor = SIMPLE_API.[Enum].CodigosAduana.Paises.ARGENTINA

        dte.Exportaciones.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.DetalleExportacion)()
        detalle = New ChileSystems.DTE.Engine.Documento.DetalleExportacion()
        detalle.NumeroLinea = 1
        detalle.IndicadorExento = IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
        detalle.Nombre = "CAJAS CIRUELAS TIERNIZADAS SIN CAROZO CALIBRE 60/70"
        detalle.Cantidad = 290
        detalle.UnidadMedida = "KN"
        detalle.Precio = 119
        detalle.DescuentoPorcentaje = 5
        Dim descuentoReal = detalle.Cantidad * detalle.Precio * 0.05
        detalle.Descuento = CInt(Math.Round(descuentoReal, 0, MidpointRounding.AwayFromZero))
        detalle.MontoItem = CInt(Math.Round((detalle.Cantidad * detalle.Precio) - descuentoReal, 0, MidpointRounding.AwayFromZero))
        dte.Exportaciones.Detalles.Add(detalle)

        detalle = New ChileSystems.DTE.Engine.Documento.DetalleExportacion
        detalle.NumeroLinea = 2
        detalle.IndicadorExento = IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
        detalle.Nombre = "CAJAS DE PASAS DE UVA FLAME MORENA SIN SEMILLA MEDIANAS"
        detalle.Cantidad = 169
        detalle.UnidadMedida = "KN"

#End Region
        folioFactura += 1
#Region "FACTURA EXPORTACION 3"



#End Region

#End Region
    End Sub
End Class