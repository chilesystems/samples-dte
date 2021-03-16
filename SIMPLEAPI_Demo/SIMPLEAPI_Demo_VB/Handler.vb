
Imports System.IO
Imports System.Runtime.InteropServices
Imports ChileSystems
Imports ChileSystems.DTE.Engine.Documento
Imports ChileSystems.DTE.Engine.Enum
Imports ChileSystems.DTE.Engine.Envio
Imports ChileSystems.DTE.Engine.RespuestaEnvio
Imports ChileSystems.DTE.WS.EnvioDTE
Imports ChileSystems.DTE.WS.EstadoDTE
Imports ChileSystems.DTE.WS.EstadoEnvio
Imports SIMPLE_API.Enum.Ambiente
Imports SIMPLE_API.Security.Firma

Public Class Handler

    Public configuracion As Configuracion


    Public Sub New()
        Me.configuracion = New Configuracion()

    End Sub

#Region "Generar Documento"

    Public Function GenerateDTE(ByVal tipoDTE As TipoDTE.DTEType, ByVal folio As Integer, ByVal Optional idDTE As String = "") As DTE

        'Documento
        Dim dte As DTE = New DTE()

        'DOCUMENTO - ENCABEZADO - CAMPO OBLIGATORIO
        'Id = puede ser compuesto según tus propios requerimientos pero debe ser único           
        dte.Documento.Id = If(String.IsNullOrEmpty(idDTE), "DTE_" & DateTime.Now.Ticks.ToString(), idDTE)

        ' DOCUMENTO - ENCABEZADO - IDENTIFICADOR DEL DOCUMENTO - CAMPOS OBLIGATORIOS

        dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipoDTE
        dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now
        dte.Documento.Encabezado.IdentificacionDTE.Folio = folio

        'DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS          

        dte.Documento.Encabezado.Emisor.Rut = configuracion.Empresa.RutEmpresa
        dte.Documento.Encabezado.Emisor.DireccionOrigen = configuracion.Empresa.Direccion
        dte.Documento.Encabezado.Emisor.ComunaOrigen = configuracion.Empresa.Comuna


        'Para boletas electrónicas

        If tipoDTE = tipoDTE.BoletaElectronica OrElse tipoDTE = tipoDTE.BoletaElectronicaExenta Then
            dte.Documento.Encabezado.IdentificacionDTE.IndicadorServicio = IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios
            dte.Documento.Encabezado.Emisor.RazonSocialBoleta = configuracion.Empresa.RazonSocial
            dte.Documento.Encabezado.Emisor.GiroBoleta = configuracion.Empresa.Giro
        Else
            dte.Documento.Encabezado.Emisor.ActividadEconomica = configuracion.Empresa.CodigosActividades.[Select](Function(x) x.Codigo).ToList()
            dte.Documento.Encabezado.Emisor.RazonSocial = configuracion.Empresa.RazonSocial
            dte.Documento.Encabezado.Emisor.Giro = configuracion.Empresa.Giro
        End If

        If tipoDTE = tipoDTE.GuiaDespachoElectronica Then
            dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado = TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta
            dte.Documento.Encabezado.IdentificacionDTE.TipoDespacho = TipoDespacho.TipoDespachoEnum.EmisorACliente
        End If


        'DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS

        dte.Documento.Encabezado.Receptor.Rut = "66666666-6"
        dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente"
        dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente"
        dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente"

        If tipoDTE <> tipoDTE.BoletaElectronica AndAlso tipoDTE <> tipoDTE.BoletaElectronicaExenta Then
            dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente"
            dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente"
        End If

        dte.Documento.Referencias = New List(Of Referencia)()
        Return dte
    End Function


    Public Function GenerateDTEExportacionBase(ByVal tipoDTE As TipoDTE.DTEType, ByVal folio As Integer, ByVal Optional idDTE As String = "") As DTE

        'DOCUMENTO
        Dim dte = New ChileSystems.DTE.Engine.Documento.DTE()
        dte.Exportaciones = New SIMPLE_API.Documento.Exportaciones()
        dte.Exportaciones.Id = If(String.IsNullOrEmpty(idDTE), "DTE_" & DateTime.Now.Ticks.ToString(), idDTE)
        dte.Exportaciones.Encabezado.IdentificacionDTE.TipoDTE = tipoDTE
        dte.Exportaciones.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now
        dte.Exportaciones.Encabezado.IdentificacionDTE.Folio = folio
        dte.Exportaciones.Encabezado.Emisor.Rut = configuracion.Empresa.RutEmpresa
        dte.Exportaciones.Encabezado.Emisor.RazonSocial = configuracion.Empresa.RazonSocial
        dte.Exportaciones.Encabezado.Emisor.Giro = configuracion.Empresa.Giro
        dte.Exportaciones.Encabezado.Emisor.DireccionOrigen = configuracion.Empresa.Direccion
        dte.Exportaciones.Encabezado.Emisor.ComunaOrigen = configuracion.Empresa.Comuna
        dte.Exportaciones.Encabezado.Emisor.ActividadEconomica = configuracion.Empresa.CodigosActividades.[Select](Function(x) x.Codigo).ToList()

        'Documento -Encabezado - Receptor - CAMPOS OBLIGATORIOS

        dte.Exportaciones.Encabezado.Receptor.Rut = "55555555-5"
        dte.Exportaciones.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente"
        dte.Exportaciones.Encabezado.Receptor.Direccion = "Dirección de cliente"
        dte.Exportaciones.Encabezado.Receptor.Comuna = "Comuna de cliente"
        dte.Exportaciones.Encabezado.Receptor.Ciudad = "Ciudad de cliente"
        dte.Exportaciones.Encabezado.Receptor.Giro = "Giro de cliente"
        dte.Exportaciones.Encabezado.Transporte = New Transporte()
        dte.Exportaciones.Encabezado.Transporte.Aduana = New Aduana()
        dte.Exportaciones.Referencias = New List(Of Referencia)()
        Return dte

    End Function

    Public Sub CalculateTotalesExportacion(ByVal dte As DTE, ByVal Optional adicional As Double = 0)
        Dim total As Integer = CInt(Math.Round(dte.Exportaciones.Detalles.Sum(Function(x) x.MontoItem) + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro + adicional, 0))

        'int total = (int)Math.Round((decimal)dte.Exportaciones.Detalles.Sum(x => x.MontoItem), 0);


        dte.Exportaciones.Encabezado.Totales.MontoExento = total
        dte.Exportaciones.Encabezado.Totales.MontoTotal = total

        Try
            Dim totalOtraMoneda As Integer = CInt(Math.Round((dte.Exportaciones.Detalles.Sum(Function(x) x.MontoItem) + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoFlete + dte.Exportaciones.Encabezado.Transporte.Aduana.MontoSeguro + adicional) * dte.Exportaciones.Encabezado.OtraMoneda.TipoCambio, 0))

            'int totalOtraMoneda = (int)Math.Round(dte.Exportaciones.Detalles.Sum(x => x.MontoItem) * dte.Exportaciones.Encabezado.OtraMoneda.TipoCambio, 0);

            dte.Exportaciones.Encabezado.OtraMoneda.MontoExento = totalOtraMoneda
            dte.Exportaciones.Encabezado.OtraMoneda.MontoTotal = totalOtraMoneda
        Catch
        End Try
    End Sub


    Public Sub GenerateDetails(ByVal dte As DTE)
        'DOCUMENTO - DETALLES
        dte.Documento.Detalles = New List(Of Detalle)()
        Dim detalle As Detalle = New Detalle()
        detalle.NumeroLinea = 1



        'IndicadorExento = Sólo aplica si el producto es exento de IVA*/
        'detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;

        detalle.Nombre = "SERVICIO DE FACTURACION ELECT"
        detalle.Cantidad = 12
        detalle.Precio = 170

        'Monto del item
        'Recordar que debe restarse el descuento del detalle y sumarse el recargo
        detalle.MontoItem = 2040
        dte.Documento.Detalles.Add(detalle)

        detalle = New Detalle()
        detalle.NumeroLinea = 2

        'detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;

        detalle.Nombre = "DESARROLLO DE ETL"
        detalle.Cantidad = 20
        detalle.Precio = 1050
        detalle.MontoItem = 21000
        dte.Documento.Detalles.Add(detalle)

        'DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
        calculosTotales(dte)
    End Sub


    Public Sub GenerateDetailsExportacion(ByVal dte As DTE)
        dte.Exportaciones.Detalles = New List(Of DetalleExportacion)()
        Dim detalle = New DetalleExportacion()
        detalle.NumeroLinea = 1
        detalle.IndicadorExento = IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento
        detalle.Nombre = "CHATARRA DE ALUMINIO"
        detalle.Cantidad = 148
        detalle.UnidadMedida = "U"
        detalle.Precio = 105
        detalle.MontoItem = 148 * 105
        dte.Exportaciones.Detalles.Add(detalle)
        CalculateTotalesExportacion(dte)
    End Sub


    Public Sub GenerateDetails(ByVal dte As DTE, ByVal detalles As List(Of ItemBoleta))
        'DOCUMENTO - DETALLES
        dte.Documento.Detalles = New List(Of Detalle)()
        Dim contador As Integer = 1

        For Each det In detalles
            Dim detalle = New Detalle()
            detalle.NumeroLinea = contador

            'IndicadorExento = Sólo aplica si el producto es exento de IVA
            detalle.IndicadorExento = If(det.Afecto, IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet, ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento)
            detalle.Nombre = det.Nombre
            detalle.Cantidad = CDbl(det.Cantidad)
            detalle.Precio = det.Precio

            If Not String.IsNullOrEmpty(det.UnidadMedida) Then
                detalle.UnidadMedida = det.UnidadMedida
            End If

            'Monto del item
            'Recordar que debe restarse el descuento del detalle y sumarse el recargo

            If det.Descuento <> 0 Then
                detalle.Descuento = CInt(Math.Round(det.Total * (det.Descuento / 100), 0))
                'detalle.DescuentoPorcentaje = det.Descuento;
            End If

            detalle.MontoItem = det.Total - detalle.Descuento

            If det.TipoImpuesto <> TipoImpuesto.TipoImpuestoEnum.NotSet Then
                detalle.CodigoImpuestoAdicional = New List(Of TipoImpuesto.TipoImpuestoEnum)()
                detalle.CodigoImpuestoAdicional.Add(det.TipoImpuesto)
            End If

            dte.Documento.Detalles.Add(detalle)
            contador += 1
        Next

        calculosTotales(dte)
    End Sub

    Private Sub calculosTotales(ByVal dte As DTE)
        Try
            'DOCUMENTO - ENCABEZADO - TOTALES - CAMPOS OBLIGATORIOS
            If dte.Documento.Encabezado.IdentificacionDTE.TipoDTE <> TipoDTE.DTEType.BoletaElectronica Then
                dte.Documento.Encabezado.Totales.TasaIVA = Convert.ToDouble(19)
                Dim neto = dte.Documento.Detalles.Where(Function(x) x.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet).Sum(Function(x) x.MontoItem)
                Dim exento = dte.Documento.Detalles.Where(Function(x) x.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento).Sum(Function(x) x.MontoItem)
                Dim descuentos = dte.Documento.DescuentosRecargos?.Where(Function(x) x.TipoMovimiento = ChileSystems.DTE.Engine.[Enum].TipoMovimiento.TipoMovimientoEnum.Descuento AndAlso x.TipoValor = ChileSystems.DTE.Engine.[Enum].ExpresionDinero.ExpresionDineroEnum.Porcentaje).Sum(Function(x) x.Valor)

                If descuentos.HasValue AndAlso descuentos.Value > 0 Then
                    Dim montoDescuentoAfecto = CInt(Math.Round(neto * (descuentos.Value / 100), 0, MidpointRounding.AwayFromZero))
                    neto -= montoDescuentoAfecto
                End If

                Dim iva = CInt(Math.Round(neto * 0.19, 0))
                Dim retenido As Integer = 0

                If dte.Documento.Detalles.Any(Function(x) x.CodigoImpuestoAdicional IsNot Nothing) Then
                    retenido = CInt(Math.Round(dte.Documento.Detalles.Where(Function(x) x.CodigoImpuestoAdicional.First() = ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal).Sum(Function(x) x.MontoItem) * 0.19, 0))

                    If retenido <> 0 Then
                        dte.Documento.Encabezado.Totales.ImpuestosRetenciones = New List(Of ImpuestosRetenciones)()
                        dte.Documento.Encabezado.Totales.ImpuestosRetenciones.Add(New ImpuestosRetenciones() With {
                            .MontoImpuesto = retenido,
                            .TasaImpuesto = 19,
                            .TipoImpuesto = TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
                        })
                    End If
                End If

                dte.Documento.Encabezado.Totales.MontoNeto = neto
                dte.Documento.Encabezado.Totales.MontoExento = exento
                dte.Documento.Encabezado.Totales.IVA = iva
                dte.Documento.Encabezado.Totales.MontoTotal = neto + exento + iva - retenido
            Else
                Dim totalBrutoAfecto = dte.Documento.Detalles.Where(Function(x) x.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet).Sum(Function(x) x.MontoItem)
                Dim totalExento = dte.Documento.Detalles.Where(Function(x) x.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento).Sum(Function(x) x.MontoItem)

                'En las boletas, sólo es necesario informar el monto total
                Dim neto = totalBrutoAfecto / 1.19
                Dim iva = CInt(Math.Round(neto * 0.19, 0, MidpointRounding.AwayFromZero))
                dte.Documento.Encabezado.Totales.IVA = iva
                dte.Documento.Encabezado.Totales.MontoNeto = CInt(Math.Round(neto, 0, MidpointRounding.AwayFromZero))
                dte.Documento.Encabezado.Totales.MontoTotal = dte.Documento.Encabezado.Totales.MontoNeto + totalExento + iva
            End If

        Catch
        End Try
    End Sub

    '''/// <summary>
    '''    /// Permite agregar referencias a un DTE
    '''    /// </summary>
    '''    /// <param name="dte">Objeto DTE que tendrá una nueva Referencia</param>
    '''    /// <param name="operacionReferencia">Corresponde a Anulación, Corrige Montos, Corrige Texto o SET de pruebas</param>
    '''    /// <param name="tipoDocumentoReferencia">Tipo de documento que se desea referenciar, como notas de crédito, ordenes de compra, entre otros.</param>
    '''    /// <param name="fechaDocReferencia">Fecha del documento de referencia. NO de cuándo se genera la referencia.</param>
    '''    /// <param name="folioReferencia">Folio del documento de referencia.</param>
    '''    /// <param name="casoPrueba">N° de caso de prueba</param>
    Public Sub Referencias(ByVal dte As DTE, ByVal operacionReferencia As TipoReferencia.TipoReferenciaEnum, ByVal tipoDocumentoReferencia As TipoDTE.TipoReferencia, ByVal fechaDocReferencia As DateTime?, ByVal Optional folioReferencia As Integer? = 0, ByVal Optional casoPrueba As String = "")

        If operacionReferencia = TipoReferencia.TipoReferenciaEnum.SetPruebas Then 'REFERENCIA A SET DE PRUEBAS

            If tipoDocumentoReferencia = TipoDTE.TipoReferencia.BoletaElectronica OrElse tipoDocumentoReferencia = TipoDTE.TipoReferencia.BoletaExentaElectronica Then
                dte.Documento.Referencias.Add(New Referencia() With {
                    .CodigoReferencia = TipoReferencia.TipoReferenciaEnum.SetPruebas,
                    .Numero = dte.Documento.Referencias.Count + 1,
                    .RazonReferencia = casoPrueba
                })
            Else
                dte.Documento.Referencias.Add(New Referencia() With {
                    .FechaDocumentoReferencia = fechaDocReferencia.Value,
                    .FolioReferencia = folioReferencia.ToString(),
                    .Numero = dte.Documento.Referencias.Count + 1,
                    .RazonReferencia = casoPrueba,
                    .TipoDocumento = TipoDTE.TipoReferencia.SetPruebas
                })
            End If
        Else
            dte.Documento.Referencias.Add(New Referencia() With {
                .CodigoReferencia = operacionReferencia,
                .FechaDocumentoReferencia = fechaDocReferencia.Value,
                .FolioReferencia = folioReferencia.ToString(),
                .Numero = dte.Documento.Referencias.Count + 1,
                .RazonReferencia = If(operacionReferencia = TipoReferencia.TipoReferenciaEnum.AnulaDocumentoReferencia, "ANULA", "CORRIGE" & " DOCUMENTO N° " & folioReferencia.ToString()),
                .TipoDocumento = tipoDocumentoReferencia
            })
        End If
    End Sub

    Public Function TimbrarYFirmarXMLDTE(ByVal dte As DTE, ByVal pathResult As String, ByVal pathCaf As String, ByRef messageOut As String) As String
        messageOut = String.Empty

        'En primer lugar, el documento debe timbrarse con el CAF que descargas desde el SII, es simular
        'cuando antes debías ir con las facturas en papel para que te las timbraran */

        dte.Documento.Timbrar(EnsureExists(CInt(dte.Documento.Encabezado.IdentificacionDTE.TipoDTE), dte.Documento.Encabezado.IdentificacionDTE.Folio, pathCaf), messageOut)


        'El documento timbrado se guarda en la variable pathResult*/

        'Finalmente, el documento timbrado debe firmarse con el certificado digital*/
        'Se debe entregar en el argumento del método Firmar, el "FriendlyName" o Nombre descriptivo del certificado*/
        'Retorna el filePath donde estará el archivo XML timbrado y firmado, listo para ser enviado al SII*/

        Return dte.Firmar(configuracion.Certificado.Nombre, configuracion.APIKey, messageOut, "out\temp\", "")
    End Function

    Public Function TimbrarYFirmarXMLDTEExportacion(ByVal dte As DTE, ByVal pathResult As String, ByVal pathCaf As String) As String

        'En primer lugar, el documento debe timbrarse con el CAF que descargas desde el SII, es simular
        'cuando antes debías ir con las facturas en papel para que te las timbraran */

        Dim messageOut As String = String.Empty
        dte.Exportaciones.Timbrar(EnsureExists(CInt(dte.Exportaciones.Encabezado.IdentificacionDTE.TipoDTE), dte.Exportaciones.Encabezado.IdentificacionDTE.Folio, pathCaf), messageOut)


        'El documento timbrado se guarda en la variable pathResult*/

        'Finalmente, el documento timbrado debe firmarse con el certificado digital*/
        'Se debe entregar en el argumento del método Firmar, el "FriendlyName" o Nombre descriptivo del certificado*/
        'Retorna el filePath donde estará el archivo XML timbrado y firmado, listo para ser enviado al SII*/

        Return dte.FirmarExportacion(configuracion.Certificado.Nombre, configuracion.APIKey, messageOut, "out\temp\")
    End Function

    '//public bool ValidateEnvio(string filePath, ChileSystems.DTE.Security.Firma.Firma.TipoXML tipo)
    '    //{
    '    //    string messageResult = string.Empty;
    '    //    if (ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(filePath, out messageResult, ChileSystems.DTE.Engine.XML.Schemas.EnvioDTE))
    '    //        if (ChileSystems.DTE.Security.Firma.Firma.VerificarFirma(filePath, tipo))
    '    //            return true;
    '    //        else
    '    //            throw New Exception("NO SE HA PODIDO VERIFICAR LA FIRMA DEL ENVÍO");
    '    //    throw New Exception(messageResult);
    '    //}



    Public Function Validate(ByVal filePath As String, ByVal tipo As Firma.TipoXML, ByVal schema As String) As Boolean
        Dim messageResult As String = String.Empty
        Dim messageOutFirma As String = Nothing

        If ChileSystems.DTE.Engine.XML.XmlHandler.ValidateWithSchema(filePath, messageResult, schema) Then

            If SIMPLE_API.Security.Firma.Firma.VerificarFirma(filePath, tipo, messageOutFirma) Then
                Return True
            Else
                MessageBox.Show("Error al validar firma electrónica: " & messageResult & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        End If

        MessageBox.Show("Error: " + messageResult + ". Verifique que contiene la carpeta XML con los XSD para validación", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Return False
    End Function

    Private Function EnsureExists(ByVal tipoDTE As Integer, ByVal folio As Integer, ByVal pathCaf As String) As String
        Dim cafFile = String.Empty

        For Each file In System.IO.Directory.GetFiles(pathCaf)
            If ParseName((New FileInfo(file)).Name, tipoDTE, folio) Then cafFile = file
        Next

        If String.IsNullOrEmpty(cafFile) Then Throw New Exception("NO HAY UN CÓDIGO DE AUTORIZACIÓN DE FOLIOS (CAF) ASIGNADO PARA ESTE TIPO DE DOCUMENTO (" & tipoDTE & ") QUE INCLUYA EL FOLIO REQUERIDO (" & folio & ").")
        Return cafFile
    End Function

    Private Shared Function ParseName(ByVal name As String, ByVal tipoDTE As Integer, ByVal folio As Integer) As Boolean
        Try
            Dim values = name.Substring(0, name.IndexOf("."c)).Split("_"c)
            Dim tipo As Integer = Convert.ToInt32(values(0))
            Dim desde As Integer = Convert.ToInt32(values(1))
            Dim hasta As Integer = Convert.ToInt32(values(2))
            Return tipoDTE = tipo AndAlso desde <= folio AndAlso folio <= hasta
        Catch
            Return False
        End Try
    End Function
#End Region

#Region "Envio"

    Public Function GenerarEnvioDTEToSII(ByVal dtes As List(Of DTE), ByVal xmlDtes As List(Of String)) As ChileSystems.DTE.Engine.Envio.EnvioDTE
        Dim EnvioSII = New ChileSystems.DTE.Engine.Envio.EnvioDTE()
        EnvioSII.SetDTE = New ChileSystems.DTE.Engine.Envio.SetDTE()
        EnvioSII.SetDTE.Id = "FENV010"
        'Es necesario agregar en el envío, los objetos DTE como sus respectivos XML en strings*/

        For Each a In dtes
            EnvioSII.SetDTE.DTEs.Add(a)
        Next

        For Each a In xmlDtes
            EnvioSII.SetDTE.dteXmls.Add(a)
            EnvioSII.SetDTE.signedXmls.Add(a)
        Next

        EnvioSII.SetDTE.Caratula = New ChileSystems.DTE.Engine.Envio.Caratula()
        EnvioSII.SetDTE.Caratula.FechaEnvio = DateTime.Now


        '/*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/

        EnvioSII.SetDTE.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion
        EnvioSII.SetDTE.Caratula.NumeroResolucion = configuracion.Empresa.NumeroResolucion

        EnvioSII.SetDTE.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa
        EnvioSII.SetDTE.Caratula.RutEnvia = configuracion.Certificado.Rut
        EnvioSII.SetDTE.Caratula.RutReceptor = "60803000-K" 'Este es el RUT del SII
        EnvioSII.SetDTE.Caratula.SubTotalesDTE = New List(Of ChileSystems.DTE.Engine.Envio.SubTotalesDTE)()

        'En la carátula del envío, se debe indicar cuantos documentos de cada tipo se están enviando*/

        If EnvioSII.SetDTE.DTEs.Any(Function(x) Not String.IsNullOrEmpty(x.Documento.Id)) Then
            Dim tipos = EnvioSII.SetDTE.DTEs.GroupBy(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE)

            For Each a In tipos
                EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(New ChileSystems.DTE.Engine.Envio.SubTotalesDTE() With {
                    .Cantidad = a.Count,
                    .TipoDTE = a.ElementAt(0).Documento.Encabezado.IdentificacionDTE.TipoDTE
                })
            Next
        ElseIf EnvioSII.SetDTE.DTEs.Any(Function(x) Not String.IsNullOrEmpty(x.Exportaciones.Id)) Then
            Dim tipos = EnvioSII.SetDTE.DTEs.GroupBy(Function(x) x.Exportaciones.Encabezado.IdentificacionDTE.TipoDTE)

            For Each a In tipos
                EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(New ChileSystems.DTE.Engine.Envio.SubTotalesDTE() With {
                    .Cantidad = a.Count,
                    .TipoDTE = a.ElementAt(0).Exportaciones.Encabezado.IdentificacionDTE.TipoDTE
                })
            Next
        End If

        Return EnvioSII
    End Function

    Public Function GenerarEnvioCliente(ByVal dte As DTE, ByVal dteXML As String) As ChileSystems.DTE.Engine.Envio.EnvioDTE
        Dim EnvioCustomer = New ChileSystems.DTE.Engine.Envio.EnvioDTE()
        EnvioCustomer.SetDTE = New ChileSystems.DTE.Engine.Envio.SetDTE()
        EnvioCustomer.SetDTE.DTEs.Add(dte)
        EnvioCustomer.SetDTE.dteXmls.Add(dteXML)
        EnvioCustomer.SetDTE.Caratula = New ChileSystems.DTE.Engine.Envio.Caratula()
        EnvioCustomer.SetDTE.Caratula.FechaEnvio = DateTime.Now

        '/*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/

        EnvioCustomer.SetDTE.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion
        EnvioCustomer.SetDTE.Caratula.NumeroResolucion = configuracion.Empresa.NumeroResolucion
        EnvioCustomer.SetDTE.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa
        EnvioCustomer.SetDTE.Caratula.RutEnvia = configuracion.Certificado.Rut
        EnvioCustomer.SetDTE.Caratula.RutReceptor = dte.Documento.Encabezado.Receptor.Rut

        'Generalmente al cliente se le envía una sola factura, sin embargo si no es el caso, 
        'se pueden agregar varias tal cual como está el método GenerarEnvioDTEToSII()*/

        EnvioCustomer.SetDTE.Caratula.SubTotalesDTE = New List(Of ChileSystems.DTE.Engine.Envio.SubTotalesDTE)() From {
            New ChileSystems.DTE.Engine.Envio.SubTotalesDTE() With {
                .Cantidad = 1,
                .TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE
            }
        }
        Return EnvioCustomer
    End Function

    Public Function EnviarEnvioDTEToSII(ByVal filePathEnvio As String, ByVal ambiente As AmbienteEnum, <Out> ByRef messageResult As String, ByVal Optional nuevaBoleta As Boolean = False) As Long
        messageResult = String.Empty
        Dim trackID As Long = -1
        Dim i As Integer

        Try

            For i = 1 To 5
                Dim responseEnvio As EnvioDTEResult = New EnvioDTEResult()

                If nuevaBoleta Then
                    responseEnvio = ChileSystems.DTE.WS.EnvioBoleta.EnvioBoleta.Enviar(configuracion.Certificado.Rut, configuracion.Empresa.RutEmpresa, filePathEnvio, configuracion.Certificado.Nombre, ambiente, configuracion.APIKey, messageResult, ".\out\tkn.dat")
                Else
                    responseEnvio = ChileSystems.DTE.WS.EnvioDTE.EnvioDTE.Enviar(configuracion.Certificado.Rut, configuracion.Empresa.RutEmpresa, filePathEnvio, configuracion.Certificado.Nombre, ambiente, configuracion.APIKey, messageResult, ".\out\tkn.dat", "", True)
                End If

                If String.IsNullOrEmpty(messageResult) Then

                    If responseEnvio IsNot Nothing AndAlso responseEnvio.TrackId > 0 Then
                        trackID = responseEnvio.TrackId

                        '/*Aquí pueden obtener todos los datos de la respuesta, tal como
                        '     * Estado
                        '     * Fecha
                        '     * Archivo
                        '     * Glosa
                        '     * XML
                        '     * Entre otros*/
                        Return trackID
                    Else
                        messageResult = responseEnvio.ResponseXml
                    End If
                End If
            Next

            If i = 5 Then Throw New Exception("SE HA ALCANZADO EL MÁXIMO NÚMERO DE INTENTOS: " & messageResult)
        Catch ex As Exception
            messageResult = ex.Message
            Return 0
        End Try

        Return 0
    End Function
#End Region

#Region "Boletas Eletrónicas"


    Public Function GenerarEnvioBoletaDTEToSII(ByVal dtes As List(Of DTE), ByVal xmlDtes As List(Of String)) As EnvioBoleta
        Dim EnvioSII = New ChileSystems.DTE.Engine.Envio.EnvioBoleta()
        EnvioSII.SetDTE = New ChileSystems.DTE.Engine.Envio.SetDTE()
        EnvioSII.SetDTE.Id = "FENV010"

        'Es necesario agregar en el envío, los objetos DTE como sus respectivos XML en strings*/

        For Each a In dtes
            EnvioSII.SetDTE.DTEs.Add(a)
        Next

        For Each a In xmlDtes
            EnvioSII.SetDTE.dteXmls.Add(a)
            EnvioSII.SetDTE.signedXmls.Add(a)
        Next

        EnvioSII.SetDTE.Caratula = New ChileSystems.DTE.Engine.Envio.Caratula()
        EnvioSII.SetDTE.Caratula.FechaEnvio = DateTime.Now

        'Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/

        EnvioSII.SetDTE.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion
        EnvioSII.SetDTE.Caratula.NumeroResolucion = configuracion.Empresa.NumeroResolucion
        EnvioSII.SetDTE.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa
        EnvioSII.SetDTE.Caratula.RutEnvia = configuracion.Certificado.Rut
        EnvioSII.SetDTE.Caratula.RutReceptor = "60803000-K" 'Este es el RUT del SII
        EnvioSII.SetDTE.Caratula.SubTotalesDTE = New List(Of ChileSystems.DTE.Engine.Envio.SubTotalesDTE)()

        'En la carátula del envío, se debe indicar cuantos documentos de cada tipo se están enviando*/

        Dim tipos = EnvioSII.SetDTE.DTEs.GroupBy(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE)

        For Each a In tipos
            EnvioSII.SetDTE.Caratula.SubTotalesDTE.Add(New ChileSystems.DTE.Engine.Envio.SubTotalesDTE() With {
                .Cantidad = a.Count,
                .TipoDTE = a.ElementAt(0).Documento.Encabezado.IdentificacionDTE.TipoDTE
            })
        Next

        Return EnvioSII
    End Function

    Public Function GenerarRCOF(ByVal dtes As List(Of DTE)) As ChileSystems.DTE.Engine.RCOF.ConsumoFolios
        Dim rcof = New ChileSystems.DTE.Engine.RCOF.ConsumoFolios()

        'preparo los datos segun los DTE seleccionados

        Dim fechaInicio As DateTime = dtes.Min(Function(x) x.Documento.Encabezado.IdentificacionDTE.FechaEmision)
        Dim fechaFinal As DateTime = dtes.Max(Function(x) x.Documento.Encabezado.IdentificacionDTE.FechaEmision)
        rcof.DocumentoConsumoFolios.Caratula.FechaFinal = fechaInicio
        rcof.DocumentoConsumoFolios.Caratula.FechaInicio = fechaFinal
        rcof.DocumentoConsumoFolios.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion
        rcof.DocumentoConsumoFolios.Caratula.NroResol = configuracion.Empresa.NumeroResolucion
        rcof.DocumentoConsumoFolios.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa
        rcof.DocumentoConsumoFolios.Caratula.RutEnvia = configuracion.Certificado.Rut
        rcof.DocumentoConsumoFolios.Caratula.SecEnvio = "1"
        rcof.DocumentoConsumoFolios.Caratula.FechaEnvio = DateTime.Now
        Dim resumenes As List(Of ChileSystems.DTE.Engine.RCOF.Resumen) = New List(Of ChileSystems.DTE.Engine.RCOF.Resumen)()

        '/*datos de boletas electrónicas afectas*/
        ' Estos datos se deben calcular, debido a que no se informa IVA en boletas electrónicas 

        Dim totalBrutoAfecto As Integer = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Sum(Function(x) x.Documento.Detalles.Where(Function(y) y.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NotSet).Sum(Function(y) y.MontoItem))
        Dim totalExento As Integer = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Sum(Function(x) x.Documento.Detalles.Where(Function(y) y.IndicadorExento = ChileSystems.DTE.Engine.[Enum].IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento).Sum(Function(y) y.MontoItem))
        Dim totalNeto As Integer = CInt(Math.Round(totalBrutoAfecto / 1.19, 0, MidpointRounding.AwayFromZero))
        Dim totalIVA As Integer = CInt(Math.Round(totalNeto * 0.19, 0, MidpointRounding.AwayFromZero))
        Dim totalTotal As Integer = totalExento + totalNeto + totalIVA
        'Se calculan todos los rangos según el array de DTEs*/

        Dim resultRangos = New List(Of ChileSystems.DTE.Engine.RCOF.RangoUtilizados)()
        Dim lst As List(Of Integer) = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = TipoDTE.DTEType.BoletaElectronica).[Select](Function(x) x.Documento.Encabezado.IdentificacionDTE.Folio).ToList()
        Dim minBoundaries = lst.Where(Function(i) Not lst.Contains(i - 1)).OrderBy(Function(x) x).ToList()
        Dim maxBoundaries = lst.Where(Function(i) Not lst.Contains(i + 1)).OrderBy(Function(x) x).ToList()

        For i As Integer = 0 To maxBoundaries.Count - 1
            resultRangos.Add(New ChileSystems.DTE.Engine.RCOF.RangoUtilizados() With {
                .Inicial = minBoundaries(i),
                .Final = maxBoundaries(i)
            })
        Next

        resumenes.Add(New ChileSystems.DTE.Engine.RCOF.Resumen With {
            .FoliosAnulados = 0,
            .FoliosEmitidos = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Count,
            .FoliosUtilizados = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Count,
            .MntExento = totalExento,
            .MntIva = totalIVA,
            .MntNeto = totalNeto,
            .MntTotal = totalTotal,
            .TasaIVA = 19,
            .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica,
            .RangoUtilizados = resultRangos
        })
        'Dentro de resumenes .Add
        'RangoAnulados = New List<ChileSystems.DTE.Engine.RCOF.RangoAnulados>() { New ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Final = 0, Inicial = 0 } }




        '/*datos de notas de credito electronicas*/
        '    /*datos de boletas electrónicas afectas*/
        If dtes.Any(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = TipoDTE.DTEType.NotaCreditoElectronica) Then
            totalNeto = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoNeto)
            totalExento = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoExento)
            totalIVA = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.IVA)
            totalTotal = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoTotal)
            resultRangos = New List(Of ChileSystems.DTE.Engine.RCOF.RangoUtilizados)()
            lst = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = TipoDTE.DTEType.NotaCreditoElectronica).[Select](Function(x) x.Documento.Encabezado.IdentificacionDTE.Folio).ToList()
            minBoundaries = lst.Where(Function(i) Not lst.Contains(i - 1)).OrderBy(Function(x) x).ToList()
            maxBoundaries = lst.Where(Function(i) Not lst.Contains(i + 1)).OrderBy(Function(x) x).ToList()

            For i As Integer = 0 To maxBoundaries.Count - 1
                resultRangos.Add(New ChileSystems.DTE.Engine.RCOF.RangoUtilizados() With {
                    .Inicial = minBoundaries(i),
                    .Final = maxBoundaries(i)
                })
            Next

            resumenes.Add(New ChileSystems.DTE.Engine.RCOF.Resumen With {
                .FoliosAnulados = 0,
                .FoliosEmitidos = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Count,
                .FoliosUtilizados = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Count,
                .MntExento = totalExento,
                .MntIva = totalIVA,
                .MntNeto = totalNeto,
                .MntTotal = totalTotal,
                .TasaIVA = 19,
                .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica,
                .RangoUtilizados = resultRangos
            })
            'Dentro de resumenes.Add
            'RangoAnulados = New List < ChileSystems.DTE.Engine.RCOF.RangoAnulados > () { New ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Final = 0, Inicial = 0 } }

        End If

        rcof.DocumentoConsumoFolios.Resumen = resumenes
        Return rcof
    End Function

    Public Function GenerarRCOFVacio(ByVal fecha As DateTime) As ChileSystems.DTE.Engine.RCOF.ConsumoFolios
        Dim rcof = New ChileSystems.DTE.Engine.RCOF.ConsumoFolios()
        Dim fechaInicio As DateTime = fecha
        Dim fechaFinal As DateTime = fecha
        rcof.DocumentoConsumoFolios.Caratula.FechaFinal = fechaInicio
        rcof.DocumentoConsumoFolios.Caratula.FechaInicio = fechaFinal
        rcof.DocumentoConsumoFolios.Caratula.FechaResolucion = configuracion.Empresa.FechaResolucion
        rcof.DocumentoConsumoFolios.Caratula.NroResol = configuracion.Empresa.NumeroResolucion
        rcof.DocumentoConsumoFolios.Caratula.RutEmisor = configuracion.Empresa.RutEmpresa
        rcof.DocumentoConsumoFolios.Caratula.RutEnvia = configuracion.Certificado.Rut
        rcof.DocumentoConsumoFolios.Caratula.SecEnvio = "1"
        rcof.DocumentoConsumoFolios.Caratula.FechaEnvio = DateTime.Now
        Dim resumenes As List(Of ChileSystems.DTE.Engine.RCOF.Resumen) = New List(Of ChileSystems.DTE.Engine.RCOF.Resumen)()

        'datos de boletas electrónicas afectas
        resumenes.Add(New ChileSystems.DTE.Engine.RCOF.Resumen With {
            .FoliosAnulados = 0,
            .FoliosEmitidos = 0,
            .FoliosUtilizados = 0,
            .MntExento = 0,
            .MntIva = 0,
            .MntNeto = 0,
            .MntTotal = 0,
            .TasaIVA = 19,
            .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica
        })
        'Dentro de resumenes.Add
        '//RangoUtilizados = resultRangos
        '       //RangoAnulados = New List<ChileSystems.DTE.Engine.RCOF.RangoAnulados>() { New ChileSystems.DTE.Engine.RCOF.RangoAnulados() { Final = 0, Inicial = 0 } }

        rcof.DocumentoConsumoFolios.Resumen = resumenes
        Return rcof
    End Function

    Public Function GenerateLibroBoletas(ByVal dtes As List(Of DTE)) As ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.LibroBoletas
        Dim libro = New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.LibroBoletas()
        libro.EnvioLibro = New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.EnvioLibro()

        '/*Datos para confeccion de caratula*/

        Dim periodoTributario As String = "2018-05"

        ' /*Fecha de Resolución y Número de Resolución se averiguan en el sitio del SII según ambiente de producción o certificación*/
        ' /*El tipo de libro debe ser "Especial" cuando se trata del set de pruebas*/
        '  /*El folio de notificacion lo entrega el SII al momento de solicitar el libro, para el set de pruebas no es necesario agregarlo*/

        libro.EnvioLibro.Caratula = New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Caratula With {
            .RutEmisor = configuracion.Empresa.RutEmpresa,
            .RutEnvia = configuracion.Certificado.Rut,
            .PeriodoTributario = periodoTributario,
            .FechaResolucion = configuracion.Empresa.FechaResolucion,
            .NumeroResolucion = configuracion.Empresa.NumeroResolucion,
            .TipoLibro = ChileSystems.DTE.Engine.[Enum].TipoLibro.TipoLibroEnum.Especial,
            .TipoEnvio = ChileSystems.DTE.Engine.[Enum].TipoEnvioLibro.TipoEnvioLibroEnum.Total
        }
        libro.EnvioLibro.ResumenPeriodo = New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.ResumenPeriodo()
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalPeriodo)()


        '/*Se agregan un Total Periodo por cada tipo de documento. Boletas electrónicas exentas y afectas*/
        '/*Boletas electronicas*/
        '
        Dim totalNeto As Integer = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoNeto)
        Dim totalIVA As Integer = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.IVA)
        Dim totalExento As Integer = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoExento)
        Dim totalTotal As Integer = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.BoletaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoTotal)
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalPeriodo() With {
                .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.BoletaElectronica,
                .CantidadDocumentosAnulados = 0,
                .TotalesServicio = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalServicio)() From {
                    New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.TotalServicio() With {
                        .CantidadDocumentos = dtes.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = TipoDTE.DTEType.BoletaElectronica).Count,
                        .TasaIVA = 19,
                       .TotalIVA = totalIVA,
                        .TotalNeto = totalNeto,
                        .TotalExento = totalExento,
                         .TipoServicio = CInt(ChileSystems.DTE.Engine.[Enum].IndicadorServicio.IndicadorServicioEnum.BoletaVentasYServicios)
                    }
                }
            })

        '/*Se agregan los dtes del libro*/
        libro.EnvioLibro.Detalles = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Detalle)()

        For Each dte In dtes
            libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LBoletas.Detalle() With {
                .TipoDocumento = CType(dte.Documento.Encabezado.IdentificacionDTE.TipoDTE, ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro),
               .FolioDocumento = dte.Documento.Encabezado.IdentificacionDTE.Folio,
                       .FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision,
            .MontoExento = dte.Documento.Encabezado.Totales.MontoExento,
                .MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
                .RutCliente = dte.Documento.Encabezado.Receptor.Rut
            })
        Next

        Return libro
    End Function

#End Region

#Region "IECV"

    Public Function GenerateLibroVentas(ByVal envioAux As ChileSystems.DTE.Engine.Envio.EnvioDTE) As ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta
        Dim libro = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta()
        libro.EnvioLibro = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro()
        libro.EnvioLibro.Id = "ID_LIBRO1_1"

        '    '/*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
        '    '     * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

        libro.EnvioLibro.Caratula = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula() With {
            .RutEmisor = configuracion.Empresa.RutEmpresa,
            .RutEnvia = configuracion.Certificado.Rut,
            .PeriodoTributario = $"{DateTime.Now.Year}-{(If(DateTime.Now.Month >= 10, DateTime.Now.Month.ToString(), "0" & DateTime.Now.Month))}",
            .FechaResolucion = configuracion.Empresa.FechaResolucion,
           .NumeroResolucion = configuracion.Empresa.NumeroResolucion,
            .TipoOperacion = ChileSystems.DTE.Engine.[Enum].TipoOperacionLibro.TipoOperacionLibroEnum.Venta,
           .TipoLibro = ChileSystems.DTE.Engine.[Enum].TipoLibro.TipoLibroEnum.Especial,
            .TipoEnvio = ChileSystems.DTE.Engine.[Enum].TipoEnvioLibro.TipoEnvioLibroEnum.Total,
            .FolioNotificacion = 100
        }
        '    'Dentro de libro.EnvioLibro.Caratula
        '    'Para cuando es SET de pruebas, siempre es 1,,


        libro.EnvioLibro.Caratula.TipoOperacion = ChileSystems.DTE.Engine.[Enum].TipoOperacionLibro.TipoOperacionLibroEnum.Venta
        libro.EnvioLibro.Caratula.TipoLibro = ChileSystems.DTE.Engine.[Enum].TipoLibro.TipoLibroEnum.Especial
        libro.EnvioLibro.Caratula.TipoEnvio = ChileSystems.DTE.Engine.[Enum].TipoEnvioLibro.TipoEnvioLibroEnum.Total
        libro.EnvioLibro.ResumenPeriodo = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo()
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo)()



        '    '**************TOTALES PARA LAS FACTURAS******************
        Dim cantidadDocumentosFacturas As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica).Count
        Dim totalExento As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoExento)
        Dim totalNeto As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoNeto)
        Dim totalIVA As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.IVA)
        Dim totalTotal As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoTotal)
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With {
            .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.FacturaElectronica,
            .CantidadDocumentos = cantidadDocumentosFacturas,
            .CantidadDocumentosAnulados = 0,
            .TotalMontoExento = totalExento,
            .TotalMontoNeto = totalNeto,
            .TotalMontoIva = totalIVA,
            .TotalMonto = totalTotal
        })
        '    '***********************************

        '    '***************TOTALES PARA LAS NC*****************
        Dim cantidadDocumentosNC As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Count
        Dim totalExentoNC As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoExento)
        Dim totalNetoNC As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoNeto)
        Dim totalIVANC As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.IVA)
        Dim totalTotalNC As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoTotal)
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With {
            .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.NotaCreditoElectronica,
            .CantidadDocumentos = cantidadDocumentosNC,
            .CantidadDocumentosAnulados = 0,
            .TotalMontoExento = totalExentoNC,
            .TotalMontoNeto = totalNetoNC,
            .TotalMontoIva = totalIVANC,
            .TotalMonto = totalTotalNC
        })
        '    '***********************************

        '    '********************TOTALES PARA ND***************
        Dim cantidadDocumentosND As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica).Count
        Dim totalExentoND As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoExento)
        Dim totalNetoND As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoNeto)
        Dim totalIVAND As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.IVA)
        Dim totalTotalND As Integer = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica).Sum(Function(x) x.Documento.Encabezado.Totales.MontoTotal)
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With {
            .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.NotaDebitoElectronica,
            .CantidadDocumentos = cantidadDocumentosND,
            .CantidadDocumentosAnulados = 0,
            .TotalMontoExento = totalExentoND,
           .TotalMontoNeto = totalNetoND,
            .TotalMontoIva = totalIVAND,
            .TotalMonto = totalTotalND
        })
        '    '***********************************
        libro.EnvioLibro.Detalles = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle)()

        For Each dteAux In envioAux.SetDTE.DTEs
            Dim tipoDocumento As ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotSet

            If dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica Then
                tipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica
            ElseIf dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica Then
                tipoDocumento = TipoDTE.DTEType.NotaCreditoElectronica
            ElseIf dteAux.Documento.Encabezado.IdentificacionDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica Then
                tipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica
            End If

            libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
                .TipoDocumento = tipoDocumento,
                .NumeroDocumento = dteAux.Documento.Encabezado.IdentificacionDTE.Folio,
                .IndicadorAnulado = ChileSystems.DTE.Engine.[Enum].IndicadorAnulado.IndicadorAnuladoEnum.NotSet,
                .TasaImpuestoOperacion = 0.19,
                .FechaDocumento = dteAux.Documento.Encabezado.IdentificacionDTE.FechaEmision,
                .RutDocumento = dteAux.Documento.Encabezado.Receptor.Rut,
                .RazonSocial = dteAux.Documento.Encabezado.Receptor.RazonSocial,
               .MontoExento = dteAux.Documento.Encabezado.Totales.MontoExento,
                .MontoNeto = dteAux.Documento.Encabezado.Totales.MontoNeto,
            .MontoIva = dteAux.Documento.Encabezado.Totales.IVA,
                .MontoTotal = dteAux.Documento.Encabezado.Totales.MontoTotal
            })
        Next

        Return libro
    End Function

    Public Function GenerateLibroCompras() As ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta
        Dim libro = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroCompraVenta()
        libro.EnvioLibro = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro()
        libro.EnvioLibro.Id = "ID_LIBRO2"

        '/*Si el libro tiene código de autorización para rectificación, se debe ingresar en la carátula
        '     * del EnvioLibro. Esto es: libro.EnvioLibro.Caratula.CodigoAutorizacionRectificacionLibro*/

        libro.EnvioLibro.Caratula = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula() With {
        .RutEmisor = configuracion.Empresa.RutEmpresa,
        .RutEnvia = configuracion.Certificado.Rut,
        .PeriodoTributario = $"{DateTime.Now.Year}-{(If(DateTime.Now.Month >= 10, DateTime.Now.Month.ToString(), "0" & DateTime.Now.Month))}",
        .FechaResolucion = configuracion.Empresa.FechaResolucion,
          .NumeroResolucion = configuracion.Empresa.NumeroResolucion,
          .TipoOperacion = ChileSystems.DTE.Engine.[Enum].TipoOperacionLibro.TipoOperacionLibroEnum.Compra,
         .TipoLibro = ChileSystems.DTE.Engine.[Enum].TipoLibro.TipoLibroEnum.Especial,
         .TipoEnvio = ChileSystems.DTE.Engine.[Enum].TipoEnvioLibro.TipoEnvioLibroEnum.Total,
         .FolioNotificacion = 100
    }
        'Dentro de libro.envioLibro.Caratula
        '//Para cuando es SET de pruebas, siempre es 1
        '        //CodigoAutorizacionRectificacionLibro = "1NLKZLFX4S"


        libro.EnvioLibro.Detalles = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle)()
        Dim neto As Integer = 60906
        Dim exento As Integer = 0
        Dim iva As Integer = CInt(Math.Round(neto * 0.19, 0))
        Dim total As Integer = neto + iva + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
         .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.Factura,
         .NumeroDocumento = 234,
         .TasaImpuestoOperacion = 19,
         .FechaDocumento = DateTime.Now,
         .RutDocumento = "17096073-4",
         .RazonSocial = "Razón Social",
         .MontoExento = 0,
         .MontoNeto = neto,
         .MontoIva = iva,
        .MontoTotal = total
    })
        neto = 12568
        exento = 11061
        iva = CInt(Math.Round(neto * 0.19, 0))
        total = neto + iva + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica,
        .NumeroDocumento = 32,
        .TasaImpuestoOperacion = 19,
        .FechaDocumento = DateTime.Now,
        .RutDocumento = "17096073-4",
        .RazonSocial = "Razón Social",
        .MontoExento = exento,
        .MontoNeto = neto,
        .MontoIva = iva,
        .MontoTotal = total,
        .IVANoRecuperable = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle)()
        })
        neto = 30263
        exento = 0
        iva = CInt(Math.Round(neto * 0.19, 0))
        total = neto + iva + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.Factura,
        .NumeroDocumento = 781,
        .TasaImpuestoOperacion = 19,
        .FechaDocumento = DateTime.Now,
        .RutDocumento = "17096073-4",
        .RazonSocial = "Razón Social",
        .MontoExento = exento,
        .MontoNeto = neto,
        .IVAUsoComun = iva,
        .MontoTotal = total,
        .TipoImpuesto = ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoResumido.Iva
    })

        'dentro de libro.EnvioLibro.Detalles
        'MontoIva = 5681,
        'Neto * 0.19


        neto = 2978
        exento = 0
        iva = CInt(Math.Round(neto * 0.19, 0))
        total = neto + iva + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCredito,
        .NumeroDocumento = 451,
        .TasaImpuestoOperacion = 19,
        .FechaDocumento = DateTime.Now,
        .RutDocumento = "17096073-4",
        .RazonSocial = "Razón Social",
        .MontoExento = exento,
        .MontoNeto = neto,
        .MontoIva = iva,
        .MontoTotal = total,
        .TipoDocumentoReferencia = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.FacturaManual,
        .FolioDocumentoReferencia = 234
    })

        neto = 12640
        exento = 0
        iva = CInt(Math.Round(neto * 0.19, 0))
        total = neto + iva + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
    .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica,
    .NumeroDocumento = 67,
    .TasaImpuestoOperacion = 19,
    .FechaDocumento = DateTime.Now,
    .RutDocumento = "17096073-4",
    .RazonSocial = "Razón Social",
    .MontoExento = exento,
    .MontoNeto = neto,
    .MontoTotal = total,
    .IVANoRecuperable = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle)() From {
        New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperableDetalle() With {
            .CodigoIVANoRecuperable = ChileSystems.DTE.Engine.[Enum].CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.EntregaGratuita,
            .TotalMontoIVANoRecuperable = iva
        }
    }
})
        neto = 10885
        exento = 0
        iva = CInt(Math.Round(neto * 0.19, 0))
        total = neto + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaCompraElectronica,
        .NumeroDocumento = 9,
        .TasaImpuestoOperacion = 19,
        .FechaDocumento = DateTime.Now,
        .RutDocumento = "17096073-4",
        .RazonSocial = "Razón Social",
        .MontoExento = exento,
        .MontoNeto = neto,
        .MontoIva = iva,
        .MontoTotal = total,
        .IVARetenidoTotal = iva,
        .Impuestos = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle)() From {
        New ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosDetalle() With {
            .CodigoImpuesto = ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal,
            .TotalMontoImpuesto = iva,
            .TasaImpuesto = 19
        }
    }
})
        neto = 10152
        exento = 0
        iva = CInt(Math.Round(neto * 0.19, 0))
        total = neto + iva + exento

        libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCredito,
        .NumeroDocumento = 211,
        .TasaImpuestoOperacion = 19,
        .FechaDocumento = DateTime.Now,
        .RutDocumento = "17096073-4",
        .RazonSocial = "Razón Social",
        .MontoExento = exento,
        .MontoNeto = neto,
        .MontoIva = iva,
        .MontoTotal = total,
        .TipoDocumentoReferencia = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.FacturaElectronica,
        .FolioDocumentoReferencia = 32
})
        libro.EnvioLibro.ResumenPeriodo = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo()
        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo)()

        Dim manuales = libro.EnvioLibro.Detalles.Where(Function(x) x.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.Factura)

        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With
            {
                .TipoDocumento = ChileSystems.DTE.Engine.Enum.TipoDTE.TipoDocumentoLibro.FacturaManual,
                .CantidadDocumentos = manuales.Count,
                .CantidadDocumentosAnulados = 0,
                .TotalMontoExento = manuales.Sum(Function(x) x.MontoExento),
                .TotalMontoNeto = manuales.Sum(Function(x) x.MontoNeto),
                .TotalMontoIva = manuales.Sum(Function(x) x.MontoIva),
                .TotalIVAUsoComun = manuales.Sum(Function(x) x.IVAUsoComun),
                .TotalMonto = manuales.Sum(Function(x) x.MontoTotal),
               .FactorProporcionalidadIVA = 0.6,
               .TotalCreditoIVAUsoComun = CInt(Math.Round(manuales.Sum(Function(x) x.IVAUsoComun) * 0.6, 0, MidpointRounding.AwayFromZero)),
                .CantidadOperacionesConIvaUsoComun = 1
            })

        Dim electronicas = libro.EnvioLibro.Detalles.Where(Function(x) x.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica)

        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.FacturaElectronica,
        .CantidadDocumentos = electronicas.Count,
        .CantidadDocumentosAnulados = 0,
        .TotalMontoExento = electronicas.Sum(Function(x) x.MontoExento),
        .TotalMontoNeto = electronicas.Sum(Function(x) x.MontoNeto),
        .TotalMontoIva = electronicas.Sum(Function(x) x.MontoIva),
        .TotalIVAUsoComun = electronicas.Sum(Function(x) x.IVAUsoComun),
        .TotalMonto = electronicas.Sum(Function(x) x.MontoTotal),
        .TotalIVANoRecuperable = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable)() From {
        New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalIVANoRecuperable() With {
            .CantidadOperacionesIVANoRecuperable = 1,
            .CodigoIVANoRecuperable = ChileSystems.DTE.Engine.[Enum].CodigoIVANoRecuperable.CodigoIVANoRecuperableEnum.EntregaGratuita,
            .TotalMontoIVANoRecuperable = electronicas.Sum(Function(x) x.IVANoRecuperable.Sum(Function(y) y.TotalMontoIVANoRecuperable))
        }
    }
})

        Dim nc = libro.EnvioLibro.Detalles.Where(Function(x) x.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCredito)

        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.NotaCredito,
        .CantidadDocumentos = nc.Count,
        .CantidadDocumentosAnulados = 0,
        .TotalMontoExento = nc.Sum(Function(x) x.MontoExento),
        .TotalMontoNeto = nc.Sum(Function(x) x.MontoNeto),
        .TotalMontoIva = nc.Sum(Function(x) x.MontoIva),
        .TotalMonto = nc.Sum(Function(x) x.MontoTotal)
})
        Dim fce = libro.EnvioLibro.Detalles.Where(Function(x) x.TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaCompraElectronica)

        libro.EnvioLibro.ResumenPeriodo.TotalesPeriodo.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalPeriodo() With {
        .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoDocumentoLibro.FacturaCompraElectronica,
        .CantidadDocumentos = fce.Count,
        .CantidadDocumentosAnulados = 0,
        .TotalMontoExento = fce.Sum(Function(x) x.MontoExento),
        .TotalMontoNeto = fce.Sum(Function(x) x.MontoNeto),
        .TotalMontoIva = fce.Sum(Function(x) x.MontoIva),
        .TotalMonto = fce.Sum(Function(x) x.MontoTotal),
        .TotalIVARetenidoTotal = fce.Sum(Function(x) x.IVARetenidoTotal),
        .Impuestos = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosPeriodo)() From {
        New ChileSystems.DTE.Engine.InformacionElectronica.LCV.ImpuestosPeriodo() With {
            .CodigoImpuesto = ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal,
            .TotalMontoImpuesto = fce.Sum(Function(x) x.IVARetenidoTotal)
        }
    }
})
        '/**************************************************/
        Return libro
    End Function
#End Region

#Region "Guias de Despacho"


    Public Function GenerateLibroGuias(ByVal envioAux As ChileSystems.DTE.Engine.Envio.EnvioDTE) As ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroGuia

        Dim libro = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.LibroGuia()
        libro.EnvioLibro = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.EnvioLibro()
        libro.EnvioLibro.Id = "ID_LIBRO_GUIAS_"

        libro.EnvioLibro.Caratula = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Caratula() With {
    .RutEmisor = configuracion.Empresa.RutEmpresa,
    .RutEnvia = configuracion.Certificado.Rut,
    .PeriodoTributario = DateTime.Now.Year & "-0" + DateTime.Now.Month,
    .FechaResolucion = configuracion.Empresa.FechaResolucion,
    .NumeroResolucion = configuracion.Empresa.NumeroResolucion,
    .TipoLibro = ChileSystems.DTE.Engine.[Enum].TipoLibro.TipoLibroEnum.Especial,
    .TipoEnvio = ChileSystems.DTE.Engine.[Enum].TipoEnvioLibro.TipoEnvioLibroEnum.Total,
    .FolioNotificacion = 100
}

        libro.EnvioLibro.ResumenPeriodo = New ChileSystems.DTE.Engine.InformacionElectronica.LCV.ResumenPeriodo() With
            {
                .TotalesGuiasDeVentas = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta).Count,
                .MontoTotalVentasGuia = envioAux.SetDTE.DTEs.Where(Function(x) x.Documento.Encabezado.IdentificacionDTE.TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.OperacionConstituyeVenta).Sum(Function(x) x.Documento.Encabezado.Totales.MontoTotal),
                .TotalesGuiasAnuladas = 0,'//Dato opcional. No hay un indicador en el DTE para establecer que está anulado. Se debe entregar según datos del propio desarrollador,
                .TotalesFoliosAnulados = 0,' //Dato opcional. No hay un indicador en el DTE para establecer que su folio está anulado. Se debe entregar según datos del propio desarrollador,               
                .Traslados = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalTraslado)() From '//El traslado es opcional. Se repite hasta 6 veces, según los códigos de NO venta (2, 3, 4, 5, 6, 7).
                {
                    New ChileSystems.DTE.Engine.InformacionElectronica.LCV.TotalTraslado() With
                    {
                        .TipoTraslado = ChileSystems.DTE.Engine.Enum.TipoTraslado.TipoTrasladoEnum.TrasladosInternos,
                        .CantidadGuia = 1,
                        .MontoGuia = 0
                    }
                }
            }
        libro.EnvioLibro.Detalles = New List(Of ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle)()

        For Each dte In envioAux.SetDTE.DTEs
            libro.EnvioLibro.Detalles.Add(New ChileSystems.DTE.Engine.InformacionElectronica.LCV.Detalle() With {
            .MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
            .Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio,
            .TipoOperacion = dte.Documento.Encabezado.IdentificacionDTE.TipoTraslado,
            .IndicadorAnulado = ChileSystems.DTE.Engine.[Enum].IndicadorAnulado.IndicadorAnuladoEnum.NotSet
        })
            '//Para indicar que la guía está anulada se debe utilizar este atributo. Por defecto se omitirá
        Next

        Return libro
    End Function
#End Region

#Region "Utilidades"

    Public Function GenerateRandomDTE(ByVal folio As Integer, ByVal tipo As TipoDTE.DTEType) As DTE
        '// DOCUMENTO
        Dim r As Random = New Random()
        Dim dte = New ChileSystems.DTE.Engine.Documento.DTE()
        dte.Documento.Id = "TEST_2" & folio.ToString() & "_" & tipo
        dte.Documento.Encabezado.IdentificacionDTE.TipoDTE = tipo
        dte.Documento.Encabezado.IdentificacionDTE.FechaEmision = DateTime.Now
        dte.Documento.Encabezado.IdentificacionDTE.Folio = folio

        '//DOCUMENTO - ENCABEZADO - EMISOR - CAMPOS OBLIGATORIOS 
        dte.Documento.Encabezado.Emisor.Rut = configuracion.Empresa.RutEmpresa
        dte.Documento.Encabezado.Emisor.RazonSocial = configuracion.Empresa.RazonSocial
        dte.Documento.Encabezado.Emisor.Giro = configuracion.Empresa.Giro
        dte.Documento.Encabezado.Emisor.DireccionOrigen = configuracion.Empresa.Direccion
        dte.Documento.Encabezado.Emisor.ComunaOrigen = configuracion.Empresa.Comuna
        dte.Documento.Encabezado.Emisor.ActividadEconomica = configuracion.Empresa.CodigosActividades.[Select](Function(x) x.Codigo).ToList()

        '//DOCUMENTO - ENCABEZADO - RECEPTOR - CAMPOS OBLIGATORIOS
        dte.Documento.Encabezado.Receptor.Rut = "66666666-6"
        dte.Documento.Encabezado.Receptor.RazonSocial = "Razon Social de Cliente"
        dte.Documento.Encabezado.Receptor.Direccion = "Dirección de cliente"
        dte.Documento.Encabezado.Receptor.Comuna = "Comuna de cliente"
        dte.Documento.Encabezado.Receptor.Ciudad = "Ciudad de cliente"
        dte.Documento.Encabezado.Receptor.Giro = "Giro de cliente"
        dte.Documento.Detalles = New List(Of ChileSystems.DTE.Engine.Documento.Detalle)()

        If tipo = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica Then
            dte.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
            dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
                .CodigoReferencia = ChileSystems.DTE.Engine.[Enum].TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                .FechaDocumentoReferencia = DateTime.Now,
                .FolioReferencia = "40",
                .IndicadorGlobal = 0,
                .Numero = 1,
                .RazonReferencia = "CORRIGE MONTOS",
                .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.FacturaElectronica
            })
            dte.Documento.Detalles.Add(New ChileSystems.DTE.Engine.Documento.Detalle() With {
                .NumeroLinea = 1,
                .Nombre = "DEVOLUCION",
                .Cantidad = 1,
                .Precio = 100,
                .MontoItem = 100
            })
        ElseIf tipo = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica Then
            dte.Documento.Referencias = New List(Of ChileSystems.DTE.Engine.Documento.Referencia)()
            dte.Documento.Referencias.Add(New ChileSystems.DTE.Engine.Documento.Referencia() With {
                .CodigoReferencia = ChileSystems.DTE.Engine.[Enum].TipoReferencia.TipoReferenciaEnum.CorrigeMontos,
                .FechaDocumentoReferencia = DateTime.Now,
                .FolioReferencia = "41",
                .IndicadorGlobal = 0,
                .Numero = 1,
                .RazonReferencia = "RECARGO DE INTERESES",
                .TipoDocumento = ChileSystems.DTE.Engine.[Enum].TipoDTE.TipoReferencia.FacturaElectronica
            })
            dte.Documento.Detalles.Add(New ChileSystems.DTE.Engine.Documento.Detalle() With {
                .NumeroLinea = 1,
                .Nombre = "RECARGO",
                .Cantidad = 1,
                .Precio = 100,
                .MontoItem = 100
            })
        ElseIf tipo = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaCompraElectronica Then
            dte.Documento.Detalles.Add(New ChileSystems.DTE.Engine.Documento.Detalle() With {
                .NumeroLinea = 1,
                .Nombre = "TECLADOS INALAMBRICOS",
                .Cantidad = 1,
                .Precio = 100,
                .MontoItem = 100,
                .CodigoImpuestoAdicional = New List(Of ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum)() From {
                    ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum.IVARetenidoTotal
                }
            })
        Else
            '//DOCUMENTO - DETALLES
            Dim max_detalles As Integer = r.[Next](1, 5)
            Dim detallesRandom As List(Of String) = configuracion.ProductosSimulacion.[Select](Function(x) x.Nombre).ToList()

            For i As Integer = 1 To max_detalles
                Dim detalle = New ChileSystems.DTE.Engine.Documento.Detalle()
                detalle.NumeroLinea = i
                '//detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento;
                'c#
                detalle.Nombre = detallesRandom(r.[Next](0, detallesRandom.Count - 1))
                detalle.Cantidad = r.[Next](1, 5)
                detalle.Precio = r.[Next](1, 150000)
                detalle.MontoItem = CInt(detalle.Cantidad) * CInt(detalle.Precio)
                dte.Documento.Detalles.Add(detalle)
            Next
        End If

        calculosTotales(dte)
        Return dte
    End Function

    Public Function EnviarAceptacionReclamo(ByVal tipoDocumento As Integer, ByVal folio As Integer, ByVal accion As String, ByVal rutProveedor As String, ByVal dvProveedor As Integer, ByVal ambiente As AmbienteEnum) As String
        Dim messageResult As String = String.Empty
        Dim trackID As Integer = -1
        Dim i As Integer

        Try

            For i = 1 To 5
                Dim responseEnvio = ChileSystems.DTE.WS.AceptacionReclamo.AceptacionReclamoWS.NotificarAceptacionReclamo(rutProveedor, dvProveedor.ToString(), tipoDocumento, folio, accion, configuracion.Certificado.Nombre, ambiente, ".\out\tkn.dat", configuracion.APIKey)

                If responseEnvio IsNot Nothing AndAlso String.IsNullOrEmpty(messageResult) Then
                    Return responseEnvio
                End If
            Next

            If i = 5 Then Throw New Exception("SE HA ALCANZADO EL MÁXIMO NÚMERO DE INTENTOS: " & messageResult)
        Catch ex As Exception
            messageResult = ex.Message
            Return "Error: " & messageResult
        End Try

        Return "Error"
    End Function

    Public Function ConsultarEstadoDTE(ByVal ambiente As AmbienteEnum, ByVal receptorRUT As Integer, ByVal receptorDV As String, ByVal tipo As TipoDTE.DTEType, ByVal folio As Integer, ByVal fechaEmision As DateTime, ByVal total As Integer, ByVal isBoletaCertificacion As Boolean) As EstadoDTEResult
        Dim rutTrabajador As Integer = configuracion.Certificado.RutCuerpo
        Dim rutTrabajadorDigito As String = configuracion.Certificado.DV
        Dim rutEmpresa As Integer = configuracion.Empresa.RutCuerpo
        Dim rutEmpresaDigito As String = configuracion.Empresa.DV
        Dim rutReceptor As Integer = receptorRUT
        Dim rutReceptorDigito As String = receptorDV
        Dim tipoDte As Integer = CInt(tipo)
        Dim [error] As String = String.Empty
        Dim responseEstadoDTE As EstadoDTEResult

        If Not isBoletaCertificacion AndAlso (tipoDte = tipo.BoletaElectronica OrElse tipoDte = tipo.BoletaElectronicaExenta) Then
            responseEstadoDTE = EstadoDTE.GetEstadoBoleta(rutEmpresa, rutEmpresaDigito, rutReceptor, rutReceptorDigito, tipoDte, folio, fechaEmision, total, configuracion.Certificado.Nombre, ambiente, ".\out\tkn.dat", configuracion.APIKey, [error])
        Else
            responseEstadoDTE = EstadoDTE.GetEstado(rutTrabajador, rutTrabajadorDigito, rutEmpresa, rutEmpresaDigito, rutReceptor, rutReceptorDigito, tipoDte, folio, fechaEmision, total, configuracion.Certificado.Nombre, ambiente, ".\out\tkn.dat", configuracion.APIKey, [error])
        End If

        If Not String.IsNullOrEmpty([error]) Then
            Throw New Exception([error])
        End If

        Return responseEstadoDTE
    End Function

    Public Function ConsultarEstadoEnvio(ByVal ambiente As AmbienteEnum, ByVal trackId As Long) As EstadoEnvioResult
        '//string signature = SIMPLE_API.Security.Firma.Firma.GetFirmaFromString(xmlEnvio);
        'c#
        Dim rutEmpresa As Integer = configuracion.Empresa.RutCuerpo
        Dim rutEmpresaDigito As String = configuracion.Empresa.DV
        Dim [error] As String = ""
        Dim responseEstadoEnvio As EstadoEnvioResult = EstadoEnvio.GetEstado(rutEmpresa, rutEmpresaDigito, trackId, configuracion.Certificado.Nombre, ambiente, configuracion.APIKey, [error], ".\out\tkn.dat")
        If Not String.IsNullOrEmpty([error]) Then Throw New Exception([error])
        Return responseEstadoEnvio
    End Function

    Public Function ConsultarEstadoEnvioBoleta(ByVal ambiente As AmbienteEnum, ByVal trackId As Long) As EstadoEnvioBoletaResult
        '//string signature = SIMPLE_API.Security.Firma.Firma.GetFirmaFromString(xmlEnvio);
        'c#
        Dim rutEmpresa As Integer = configuracion.Empresa.RutCuerpo
        Dim rutEmpresaDigito As String = configuracion.Empresa.DV
        Dim [error] As String = ""
        Dim responseEstadoEnvio = EstadoEnvio.GetEstadoEnvioBoleta(rutEmpresa, rutEmpresaDigito, trackId, configuracion.Certificado.Nombre, ambiente, configuracion.APIKey, [error], ".\out\tkn.dat")
        If Not String.IsNullOrEmpty([error]) Then Throw New Exception([error])
        Return responseEstadoEnvio
    End Function

    Public Function GenerarRespuestaEnvio(ByVal dtes As List(Of DTE), ByVal estadoDTE As String) As String
        Dim response As RespuestaDTE = New RespuestaDTE()
        response.Resultado = New Resultado()
        Dim result = response.Resultado
        result.Id = "R_ENVIO1"
        result.Caratula = New ChileSystems.DTE.Engine.RespuestaEnvio.Caratula()
        result.Caratula.Fecha = DateTime.Now
        result.Caratula.IdRespuesta = 1
        result.Caratula.MailContacto = "mailcontacto@mail.com"
        result.Caratula.NombreContacto = "Contacto"
        result.Caratula.RutResponde = configuracion.Empresa.RutEmpresa
        result.Caratula.NumeroDetalles = 1
        result.Caratula.RutRecibe = "88888888-8"
        result.RecepcionEnvio = New List(Of RecepcionEnvio)()
        Dim recepcionEnvio = New RecepcionEnvio()
        recepcionEnvio.CodigoEnvio = 4545
        '//recepcionEnvio.Digest = SIMPLE_SDK.Security.Firma.Firma.GetDigestValueFromFile(dte.DTEfilepath);
        'c#
        recepcionEnvio.EnvioDTEId = "SetDoc"
        recepcionEnvio.FechaRecepcion = DateTime.Now
        recepcionEnvio.NumeroDTE = 2
        recepcionEnvio.RutEmisor = result.Caratula.RutRecibe
        recepcionEnvio.RutReceptor = result.Caratula.RutResponde
        recepcionEnvio.EstadoRecepcionEnvio = ChileSystems.DTE.Engine.[Enum].EstadoEnvioEmpresa.EstadoEnvioEmpresaEnum.OK
        recepcionEnvio.GlosaEstadoRecepcionEnvio = "ENVIO OK"
        recepcionEnvio.NombreArchivoEnvio = "ENVIO_DTE_1072427"
        recepcionEnvio.RecepcionDTE = New List(Of RecepcionDTE)()

        '//foreach (var dte in dtes)
        '    //{
        '    //    var recepcionDTE = New RecepcionDTE();
        '    //    recepcionDTE.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision;
        '    //    recepcionDTE.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio;
        '    //    recepcionDTE.MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal;
        '    //    recepcionDTE.RutEmisor = dte.Documento.Encabezado.Emisor.Rut;
        '    //    recepcionDTE.RutReceptor = dte.Documento.Encabezado.Receptor.Rut;
        '    //    recepcionDTE.TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE;
        '    //    recepcionDTE.EstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.EstadoRecepcionDTEEnum.Ok;
        '    //    recepcionDTE.GlosaEstadoRecepcionDTE = ChileSystems.DTE.Engine.Enum.EstadoRecepcionDTE.Glosa(recepcionDTE.EstadoRecepcionDTE);
        '    //    recepcionEnvio.RecepcionDTE.Add(recepcionDTE);
        '    //}
        'c#
        Dim recepcionDTE = New RecepcionDTE()
        Dim dte = dtes(0)
        recepcionDTE.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision
        recepcionDTE.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio
        recepcionDTE.MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal
        recepcionDTE.RutEmisor = dte.Documento.Encabezado.Emisor.Rut
        recepcionDTE.RutReceptor = dte.Documento.Encabezado.Receptor.Rut
        recepcionDTE.TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE
        recepcionDTE.EstadoRecepcionDTE = ChileSystems.DTE.Engine.[Enum].EstadoRecepcionDTE.EstadoRecepcionDTEEnum.Ok
        recepcionDTE.GlosaEstadoRecepcionDTE = ChileSystems.DTE.Engine.[Enum].EstadoRecepcionDTE.Glosa(recepcionDTE.EstadoRecepcionDTE)
        recepcionEnvio.RecepcionDTE.Add(recepcionDTE)
        Dim dte2 = dtes(1)
        recepcionDTE = New RecepcionDTE()
        recepcionDTE.FechaEmision = dte2.Documento.Encabezado.IdentificacionDTE.FechaEmision
        recepcionDTE.Folio = dte2.Documento.Encabezado.IdentificacionDTE.Folio
        recepcionDTE.MontoTotal = dte2.Documento.Encabezado.Totales.MontoTotal
        recepcionDTE.RutEmisor = dte2.Documento.Encabezado.Emisor.Rut
        recepcionDTE.RutReceptor = dte2.Documento.Encabezado.Receptor.Rut
        recepcionDTE.TipoDTE = dte2.Documento.Encabezado.IdentificacionDTE.TipoDTE
        recepcionDTE.EstadoRecepcionDTE = ChileSystems.DTE.Engine.[Enum].EstadoRecepcionDTE.EstadoRecepcionDTEEnum.ErrorRutReceptor
        recepcionDTE.GlosaEstadoRecepcionDTE = ChileSystems.DTE.Engine.[Enum].EstadoRecepcionDTE.Glosa(recepcionDTE.EstadoRecepcionDTE)
        recepcionEnvio.RecepcionDTE.Add(recepcionDTE)
        result.RecepcionEnvio.Add(recepcionEnvio)
        Dim filepath = response.Firmar(configuracion.Certificado.Nombre)
        Return filepath
    End Function

    Public Function ResponderIntercambio(ByVal estado As Integer, ByVal dte As DTE, ByVal motivo As String) As String
        Try
            Dim response As RespuestaDTE = New RespuestaDTE()
            response.Resultado = New Resultado()
            Dim result = response.Resultado
            result.Id = "R_001"
            result.Caratula = New ChileSystems.DTE.Engine.RespuestaEnvio.Caratula()
            result.Caratula.Fecha = DateTime.Now
            result.Caratula.IdRespuesta = 1
            result.Caratula.MailContacto = "test@test.cl"
            result.Caratula.NombreContacto = "Nombre Contacto"
            result.Caratula.RutResponde = configuracion.Empresa.RutEmpresa
            result.Caratula.NumeroDetalles = 1
            result.Caratula.RutRecibe = "88888888-8"
            result.ResultadoDTE = New List(Of ResultadoDTE)()
            Dim resultadoDTE = New ResultadoDTE()
            resultadoDTE.CodigoEnvio = 1
            resultadoDTE.CodigoRechazoODiscrepancia = -1
            resultadoDTE.EstadoDTE = CType(estado, ChileSystems.DTE.Engine.[Enum].EstadoResultadoDTE.EstadoResultadoDTEEnum)
            resultadoDTE.GlosaEstadoDTE = If(String.IsNullOrEmpty(motivo), resultadoDTE.EstadoDTE.ToString(), motivo)
            resultadoDTE.RutEmisor = "88888888-8"
            resultadoDTE.RutReceptor = configuracion.Empresa.RutEmpresa
            resultadoDTE.TipoDTE = ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica
            resultadoDTE.Folio = 52576
            resultadoDTE.FechaEmision = New DateTime(2019, 2, 19)
            resultadoDTE.MontoTotal = 18635
            result.ResultadoDTE.Add(resultadoDTE)
            Dim resultFilePath As String = response.Firmar(configuracion.Certificado.Nombre)
            Return resultFilePath
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ResponderDTE(ByVal estado As Integer, ByVal dte As DTE, ByVal motivo As String) As String
        Try
            Dim response As RespuestaDTE = New RespuestaDTE()
            response.Resultado = New ChileSystems.DTE.Engine.RespuestaEnvio.Resultado()
            Dim result = response.Resultado
            result.Id = "APROBACION_COMERCIAL_"
            result.Caratula = New ChileSystems.DTE.Engine.RespuestaEnvio.Caratula()
            result.Caratula.Fecha = DateTime.Now
            result.Caratula.IdRespuesta = 1
            result.Caratula.MailContacto = "test@test.cl"
            result.Caratula.NombreContacto = "Nombre Contacto"
            result.Caratula.RutResponde = configuracion.Empresa.RutEmpresa
            result.Caratula.NumeroDetalles = 1
            result.Caratula.RutRecibe = "88888888-8"
            result.ResultadoDTE = New List(Of ResultadoDTE)()
            Dim resultadoDTE = New ResultadoDTE()
            resultadoDTE.CodigoEnvio = 1
            resultadoDTE.CodigoRechazoODiscrepancia = -1
            resultadoDTE.EstadoDTE = CType(estado, ChileSystems.DTE.Engine.[Enum].EstadoResultadoDTE.EstadoResultadoDTEEnum)
            resultadoDTE.GlosaEstadoDTE = If(String.IsNullOrEmpty(motivo), resultadoDTE.EstadoDTE.ToString(), motivo)
            resultadoDTE.RutEmisor = "88888888-8"
            resultadoDTE.RutReceptor = configuracion.Empresa.RutEmpresa
            resultadoDTE.TipoDTE = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE
            resultadoDTE.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio
            resultadoDTE.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision
            resultadoDTE.MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal
            result.ResultadoDTE.Add(resultadoDTE)
            Dim resultFilePath As String = response.Firmar(configuracion.Certificado.Nombre)
            Return resultFilePath
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function AcuseReciboMercaderias(ByVal dte As DTE) As String
        Try
            Dim envio As ChileSystems.DTE.Engine.ReciboMercaderia.EnvioRecibos = New ChileSystems.DTE.Engine.ReciboMercaderia.EnvioRecibos()
            envio.SetRecibos = New ChileSystems.DTE.Engine.ReciboMercaderia.SetRecibos() With {
                .Id = "EARM00",
                .Caratula = New ChileSystems.DTE.Engine.ReciboMercaderia.Caratula() With {
                    .RutRecibe = "88888888-8",
                    .RutResponde = configuracion.Empresa.RutEmpresa,
                    .NombreContacto = "Nombre Contacto"
                }
            }
            envio.SetRecibos.Recibos = New List(Of ChileSystems.DTE.Engine.ReciboMercaderia.Recibo)() From {
                New ChileSystems.DTE.Engine.ReciboMercaderia.Recibo() With {
                    .DocumentoRecibo = New ChileSystems.DTE.Engine.ReciboMercaderia.DocumentoRecibo() With {
                        .Id = "R01",
                        .RutEmisor = "88888888-8",
                        .RutReceptor = configuracion.Empresa.RutEmpresa,
                        .FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision,
                        .Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio,
                        .MontoTotal = dte.Documento.Encabezado.Totales.MontoTotal,
                        .TipoDocumento = dte.Documento.Encabezado.IdentificacionDTE.TipoDTE,
                        .Recinto = "Recinto",
                        .RutFirma = configuracion.Certificado.Rut
                    }
                }
            }
            Dim id As Integer = -1
            Dim recibo = envio.SetRecibos.Recibos.First()
            envio.SetRecibos.Id = "EARM" & id
            recibo.DocumentoRecibo.Id = "RM" & id
            envio.SetRecibos.signedXmls.Add(recibo.Firmar(configuracion.Certificado.Nombre))
            Dim filePath As String = envio.Firmar(configuracion.Certificado.Nombre)
            Return filePath
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function ObtenerCertificados() As String
        Dim certificadosMaquina = ChileSystems.DTE.Engine.Utilidades.ObtenerCertificadosMaquinas()
        Dim certificadosUsuario = ChileSystems.DTE.Engine.Utilidades.ObtenerCertificadosUsuario()
        Dim result As String = "Máquina:" & vbLf

        For Each a In certificadosMaquina
            result += a & vbLf
        Next

        result += "Usuario:" & vbLf

        For Each a In certificadosUsuario
            result += a & vbLf
        Next

        Return result
    End Function

    Public Shared Function imageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
        Dim ms As MemoryStream = New MemoryStream()
        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Return ms.ToArray()
    End Function

    Public Shared Function TipoDTEString(ByVal tipo As TipoDTE.DTEType) As String
        Select Case tipo
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaCompraElectronica
                Return "FACTURA DE COMPRA ELECTRÓNICA"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronica
                Return "FACTURA ELECTRÓNICA"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.FacturaElectronicaExenta
                Return "FACTURA ELECTRÓNICA EXENTA"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.GuiaDespachoElectronica
                Return "GUIA DE DESPACHO ELECTRÓNICA"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCreditoElectronica
                Return "NOTA DE CRÉDITO ELECTRÓNICA"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaDebitoElectronica
                Return "NOTA DE DÉBITO ELECTRÓNICA"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.Factura
                Return "FACTURA MANUAL"
            Case ChileSystems.DTE.Engine.[Enum].TipoDTE.DTEType.NotaCredito
                Return "NOTA DE CRÉDITO MANUAL"
        End Select

        Return "Not Set"
    End Function
#End Region


End Class
