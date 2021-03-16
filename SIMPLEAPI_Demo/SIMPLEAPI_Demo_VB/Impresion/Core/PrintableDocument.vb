Imports System.Text
Imports ChileSystems.DTE.Engine.Documento

Public Class PrintableDocument


    '// Datos Emisor //
    Public Property RazonSocial As String
    Public Property Rut As String
    Public Property Giro As String
    Public Property DireccionCasaMatriz As String
    Public Property Sucursales As List(Of String)
    Public Property Teléfono As String


    '// Datos Receptor //
    Public Property RutCliente As String
    Public Property RazonSocialCliente As String


    '// Datos Documento //
    Public Property NombreDocumento As String
    Public Property Folio As Long
    Public Property OficinaSII As String
    Public Property FechaEmision As DateTime
    Public Property IsDTE As Boolean
    Public Property ShowUnidadMedida As Boolean
    Public Property Referencias As List(Of String)

    '// Detalles ///
    Public Property Detalles As List(Of PrintableDocumentDetail)


    '// Total //
    '    /// <summary>
    '    /// D ó R | NOMBRE DESCUENTO | $0.000%
    '    /// </summary>
    Public DescuentosRecargos As New List(Of Tuple(Of Char, String, String))

    '/// <summary>
    '    /// NOMBRE IMPUESTO | VALOR
    '    /// </summary>
    Public Adicionales As New List(Of Tuple(Of String, Integer))


    Public Property Neto As Integer
    Public Property IVA As Integer
    Public Property Total As Integer
    Public Property TotalExento As Integer


    '// SII //
    Public Property TimbreImage As Image
    Public Property NumeroResolucion As Integer
    Public Property FechaResolucion As DateTime
    Public Property WebVerificación As String


    Public Shared Function FromDTE(ByVal dte As DTE) As PrintableDocument

        Dim doc = New PrintableDocument()
        Try

            '//var xml = new XmlHandler(filePath);
            doc = New PrintableDocument()
            doc.RazonSocial = IIf(String.IsNullOrEmpty(dte.Documento.Encabezado.Emisor.RazonSocial), dte.Documento.Encabezado.Emisor.RazonSocialBoleta, dte.Documento.Encabezado.Emisor.RazonSocial)
            doc.Rut = dte.Documento.Encabezado.Emisor.Rut
            doc.Giro = IIf(String.IsNullOrEmpty(dte.Documento.Encabezado.Emisor.Giro), dte.Documento.Encabezado.Emisor.GiroBoleta, dte.Documento.Encabezado.Emisor.Giro)
            doc.DireccionCasaMatriz = dte.Documento.Encabezado.Emisor.DireccionOrigen
            doc.Sucursales = Nothing
            doc.Teléfono = Nothing


            '// Datos Receptor //
            doc.RutCliente = dte.Documento.Encabezado.Receptor.Rut
            doc.RazonSocialCliente = dte.Documento.Encabezado.Receptor.RazonSocial

            '// Datos Documento //
            doc.NombreDocumento = DTETypeNames.Names(CInt(dte.Documento.Encabezado.IdentificacionDTE.TipoDTE))
            doc.Folio = dte.Documento.Encabezado.IdentificacionDTE.Folio
            doc.OficinaSII = Nothing
            doc.FechaEmision = dte.Documento.Encabezado.IdentificacionDTE.FechaEmision

            doc.IsDTE = doc.NombreDocumento.ToUpper().Contains("ELECTR")
            doc.ShowUnidadMedida = False


            'Detalles
            doc.Detalles = New List(Of PrintableDocumentDetail)()
            For Each detalle In dte.Documento.Detalles

                doc.Detalles.Add(New PrintableDocumentDetail() With
                {
                    .Cantidad = detalle.Cantidad,
                    .Descripcion = IIf(String.IsNullOrEmpty(detalle.Nombre), detalle.Descripcion, detalle.Nombre),
                    .IsExento = detalle.IndicadorExento = ChileSystems.DTE.Engine.Enum.IndicadorFacturacionExencion.IndicadorFacturacionExencionEnum.NoAfectoOExento,
                    .Precio = detalle.Precio,
                    .Total = detalle.MontoItem,
                    .UnidadMedida = detalle.UnidadMedida
                })


            Next

            Dim value As String
            doc.DescuentosRecargos = New List(Of Tuple(Of Char, String, String))


            For Each item In dte.Documento.DescuentosRecargos

                If (item.TipoValor = ChileSystems.DTE.Engine.Enum.ExpresionDinero.ExpresionDineroEnum.Porcentaje) Then
                    value = item.Valor.ToString("N2") + "%"
                Else
                    value = item.Valor.ToString("N0") + "Pesos"
                End If
                Dim c As Char = Char.Parse(item.TipoMovimiento)
                doc.DescuentosRecargos.Add(Tuple.Create(Of Char, String, String)(c, item.Descripcion, value))
            Next

            doc.Adicionales = New List(Of Tuple(Of String, Integer))
            For Each item In dte.Documento.Encabezado.Totales.ImpuestosRetenciones

                doc.Adicionales.Add(Tuple.Create(Of String, Integer)(item.TipoImpuesto.ToString, item.MontoImpuesto))

            Next

            Dim sb As StringBuilder
            Dim intAux As Integer
            Dim stringAux As String
            Dim dateAux As DateTime


            doc.Referencias = New List(Of String)()




            For Each item In dte.Documento.Referencias

                sb = New StringBuilder()
                '// TIPO DE REFERENCIA (ANULA, CORRIGE MONTOS, CORRIGE DATOS)
                stringAux = item.CodigoReferencia.ToString()
                If (Not String.IsNullOrEmpty(stringAux)) Then

                    If (Integer.TryParse(stringAux, intAux)) Then
                        If (CodigoReferenciaName.Names.ContainsKey(intAux)) Then
                            stringAux = CodigoReferenciaName.Names(intAux)

                        End If

                    End If

                End If

                sb.Append(stringAux + ": ")

                'TIPO DE DOCUMENTO DE REFERENCIA
                stringAux = item.TipoDocumento.ToString()
                If (Not String.IsNullOrEmpty(stringAux)) Then

                    If (Integer.TryParse(stringAux, intAux)) Then
                        If (DTETypeNames.Names.ContainsKey(intAux)) Then
                            stringAux = CodigoReferenciaName.Names(intAux)

                        End If

                    End If

                End If

                sb.Append(stringAux + " ")

                'Folio de Referencia
                stringAux = item.TipoDocumento.ToString()
                If (Not String.IsNullOrEmpty(stringAux) AndAlso stringAux <> "0") Then
                    sb.Append(stringAux)
                End If
                'Fecha de referencia
                stringAux = item.FolioReferencia
                If (Not String.IsNullOrEmpty(stringAux)) Then
                    If (DateTime.TryParseExact(stringAux, "yyyy-MM-dd", Nothing, System.Globalization.DateTimeStyles.None, dateAux)) Then
                        stringAux = "DE " + dateAux.ToShortDateString()
                    End If
                End If
                sb.Append(stringAux)

                'Razon de Referencia
                stringAux = item.RazonReferencia
                If (Not String.IsNullOrEmpty(stringAux)) Then
                    sb.Append(" - RAZÓN: " + stringAux)
                End If
                doc.Referencias.Add(" - " + sb.ToString().Trim())
            Next
            doc.Neto = dte.Documento.Encabezado.Totales.MontoNeto
            doc.TotalExento = dte.Documento.Encabezado.Totales.MontoExento
            doc.IVA = dte.Documento.Encabezado.Totales.IVA
            doc.Total = dte.Documento.Encabezado.Totales.MontoTotal
        Catch ex As Exception

        End Try
        Return doc
    End Function


End Class
