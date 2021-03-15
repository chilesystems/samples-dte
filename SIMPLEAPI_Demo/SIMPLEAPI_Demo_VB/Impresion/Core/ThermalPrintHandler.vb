Imports SIMPLEAPI_Demo_VB.PrinterRow

Public Class ThermalPrintHandler
    Private _document As PrintableDocument
    Public Property NombreImpresora As String
    '// Formatos //
    Public Const DateFormat As String = "dd/MM/yyyy" '// Por completitud, pongo los formatos aquí en caso de que los haga configurables eventualmente

    Public Const NumberFormat As String = "N0"

    Public Sub New(ByVal document As PrintableDocument)
        Me._document = document

    End Sub

    Public Function CreatePrinterWork() As printerWork

        Dim work As printerWork = New printerWork() With {
       .IsTestWork = False
        }
        Dim row As PrinterRow
        Dim col As PrinterColumn

        Dim aux1, aux2, aux3 As Integer

#Region "Razón social"

        If (Not String.IsNullOrEmpty(_document.RazonSocial)) Then

            row = New PrinterRow() With {
              .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
              .Color = Color.Black,
              .FontSize = 10,
              .IsBold = True
            }

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
            .Text = _document.RazonSocial
            }

            row.AddColumn(col)
            work.AddRow(row)

        End If

#End Region

#Region "Rut"

        If (Not String.IsNullOrEmpty(_document.Rut)) Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .Text = RUTHelper.Format(_document.Rut),
            .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            }
            row.AddColumn(col)
            work.AddRow(row)

        End If


#End Region


#Region "Giro"

        If (Not String.IsNullOrEmpty(_document.Giro)) Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
            .Text = _document.Giro
            }

            row.AddColumn(col)
            work.AddRow(row)

        End If


#End Region

#Region "Casa Matriz"


        If (Not String.IsNullOrEmpty(_document.DireccionCasaMatriz)) Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            aux1 = FontInfo.GetMaxChars(row.FontSize, If(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, If(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.4, 0))
            '~40%
            aux3 = aux1 - aux2



            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Casa matriz"
            }

            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.DireccionCasaMatriz
            }
            row.AddColumn(col)
            work.AddRow(row)
        End If


#End Region



#Region "Telefono"

        If (Not String.IsNullOrEmpty(_document.Teléfono)) Then
            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }
            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))

            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.4, 0))
            '~40%
            aux3 = aux1 - aux2

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Teléfono"
            }

            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.Teléfono
            }
            row.AddColumn(col)
            work.AddRow(row)



        End If

#End Region


#Region "Sucursales"

        If (IsNothing(_document.Sucursales) = False) Then
            If (_document.Sucursales.Count <> 0) Then
                For Each suc In _document.Sucursales

                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = False
                    }

                    aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
                    aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.33, 0))
                    '33%
                    aux3 = aux1 - aux2 '100% - ~33%

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Left,
                    .MaxChars = aux2,
                    .Text = "Sucursal"
                    }
                    row.AddColumn(col)
                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Right,
                    .MaxChars = aux3,
                    .Text = suc
                    }

                    row.AddColumn(col)
                    work.AddRow(row)




                Next
            End If


        End If

#End Region

#Region "Separador"

        row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
        .Color = Color.Black,
        .FontSize = 8,
        .IsBold = False
        }

        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "--------------------------------------------------------------------"
        }
        row.AddColumn(col)
        work.AddRow(row)

#End Region


#Region "NombreDocumento Y Folio"

        If (Not String.IsNullOrEmpty(_document.NombreDocumento)) Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
            .Color = Color.Black,
            .FontSize = 10,
            .IsBold = True
            }

            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.6, 0))
            '~60%
            aux3 = aux1 - aux2 '100% - ~60%

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = _document.NombreDocumento
            }

            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.Folio.ToString()
            }

            row.AddColumn(col)
            work.AddRow(row)


        End If

#End Region

        If (_document.IsDTE) Then

#Region "Oficina SII"

            If (Not String.IsNullOrEmpty(_document.OficinaSII)) Then

                row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = False
                }
                col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Left,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = _document.OficinaSII
                }
                row.AddColumn(col)
                work.AddRow(row)

            End If


#End Region

        End If


#Region "Fecha emisión"

        If (_document.FechaEmision <> DateTime.Today) Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.4, 0))
            '~40%
            aux3 = aux1 - aux2 '100% - ~40%

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Fecha Emisión"
            }
            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.FechaEmision.ToString(DateFormat)
            }
            row.AddColumn(col)
            work.AddRow(row)


        End If

#End Region

#Region "Separador"

        If (Not String.IsNullOrEmpty(_document.RutCliente) AndAlso _document.RutCliente <> "0-0" AndAlso _document.RutCliente.Replace(".", "").Replace("-", "") <> "666666666") Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Left,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = "--------------------------------------------------------------------"
            }
            row.AddColumn(col)
            work.AddRow(row)

        End If

#End Region


#Region "Rut Cliente"

        If (Not String.IsNullOrEmpty(_document.RutCliente) And _document.RutCliente <> "0-0" And _document.RutCliente.Replace(".", "").Replace("-", "") <> "666666666") Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.4, 0))
            '~40%
            aux3 = aux1 - aux2

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Rut   :"
            }
            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.RutCliente
            }
            row.AddColumn(col)
            work.AddRow(row)

        End If

#End Region


#Region "Nombre cliente"

        If (Not String.IsNullOrEmpty(_document.RazonSocialCliente)) Then

            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.4, 0))
            '~40%
            aux3 = aux1 - aux2

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Nombre:"
            }
            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.RazonSocialCliente
            }
            row.AddColumn(col)
            work.AddRow(row)

        End If

#End Region


#Region "Separador"

        row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
        }

        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "--------------------------------------------------------------------"
        }

        row.AddColumn(col)
        work.AddRow(row)

#End Region

#Region "Referencias"

        If (IsNothing(_document.Referencias) = False) Then
            If (_document.Referencias.Count <> 0) Then

                row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = True
                }

                col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Left,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = "Referencias"
                }
                row.AddColumn(col)
                work.AddRow(row)

                For Each referencia In _document.Referencias

                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = False
                    }

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Left,
                    .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                    .Text = referencia
                    }
                    row.AddColumn(col)
                    work.AddRow(row)

                Next

#Region "Separador"

                row = New PrinterRow() With {
                  .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                  .Color = Color.Black,
                  .FontSize = 8,
                  .IsBold = False
                }
                col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Left,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = "---------------------------------------------------------------------"
                }
                row.AddColumn(col)
                work.AddRow(row)


#End Region

            End If

        End If

#End Region


#Region "Header de los Detalles"

        row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
        .Color = Color.Black,
        .FontSize = 8,
        .IsBold = False
        }
        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = 5,
        .Text = "Cant."
        }

        row.AddColumn(col)

        If (_document.ShowUnidadMedida) Then
            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = 3,
            .Text = "UM"
            }
            row.AddColumn(col)


            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = 18,
            .Text = "Descripcion"
            }
            row.AddColumn(col)

        Else

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = 21,
            .Text = "Descripcion"
            }
            row.AddColumn(col)

        End If


        col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = 10,
            .Text = "Precio"
        }
        row.AddColumn(col)

        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Right,
        .MaxChars = 9,
        .Text = "Total"
        }
        row.AddColumn(col)
        work.AddRow(row)


#End Region

#Region "Separador"

        row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
        .Color = Color.Black,
        .FontSize = 8,
        .IsBold = False
        }

        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "--------------------------------------------------------------------"
        }
        row.AddColumn(col)
        work.AddRow(row)

#End Region


#Region "Detalles"


        If (IsNothing(_document.Detalles) = False) Then
            If (_document.Detalles.Count <> 0) Then
                For Each detalle In _document.Detalles

                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = False
                    }

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Left,
                    .MaxChars = 4,'4 carácteres de font regular 8 (cantidad)
                    .Text = detalle.Cantidad.ToString(NumberFormat)
                    }
                    row.AddColumn(col)

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Left,
                    .MaxChars = 1,'1 carácteres de font regular 8 (separador)
                    .Text = " "
                    }
                    row.AddColumn(col)

                    If (_document.ShowUnidadMedida) Then
                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = 2,'2 carácteres de font regular 8 (unidad medida.)
                        .Text = detalle.UnidadMedida.Truncate(2)
                        }
                        row.AddColumn(col)
                        col = New PrinterTextColumn() With {
                        .Align = PrinterTextColumn.Aligns.Left,
                        .MaxChars = 1,'1 carácteres de font regular 8 (separador)
                        .Text = " "
                        }
                        row.AddColumn(col)
                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = 17,'20 carácteres de font regular 8 (nombre art.)
                        .Text = detalle.Descripcion.Truncate(17)
                        }
                        row.AddColumn(col)

                    Else

                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = 20,'20 carácteres de font regular 8 (nombre art.)
                        .Text = detalle.Descripcion
                        }

                    End If

                    col = New PrinterTextColumn() With {
                     .Align = PrinterColumn.Aligns.Left,
                     .MaxChars = 1,'1 carácteres de font regular 8 (separador)
                     .Text = " "
                    }
                    row.AddColumn(col)

                    col = New PrinterTextColumn() With {
                     .Align = PrinterColumn.Aligns.Right,
                     .MaxChars = 9,' 9 carácteres de font regular 8 (precio)
                     .Text = detalle.Precio.ToString(NumberFormat)
                    }
                    row.AddColumn(col)

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Left,
                    .MaxChars = 1,' 1 carácteres de font regular 8 (separador)
                    .Text = " "
                    }
                    row.AddColumn(col)

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Right,
                    .MaxChars = 9,
                    .Text = detalle.Total.ToString(NumberFormat)
                    }
                    row.AddColumn(col)
                    work.AddRow(row)

                Next

            End If
        End If
#End Region


#Region "Separador"

        row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
        .Color = Color.Black,
        .FontSize = 8,
        .IsBold = False
        }

        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "--------------------------------------------------------------------"
        }
        row.AddColumn(col)
        work.AddRow(row)

#End Region

#Region "Total Exento"

        If (_document.TotalExento <> 0) Then
            row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = False
            }
            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
            '~50%
            aux3 = aux1 - aux2 '100% - ~50%

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Total exento"
            }
            row.AddColumn(col)

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.TotalExento.ToString(NumberFormat)
            }
            row.AddColumn(col)
            work.AddRow(row)


        End If


#End Region


#Region "Descuento"

        If (IsNothing(_document.DescuentosRecargos) = False) Then
            If (_document.DescuentosRecargos.Count <> 0) Then

                If (_document.DescuentosRecargos.Where(Function(x) x.Item1 = "D").Count() <> 0) Then
#Region "Titulo"

                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = True
                    }

                    col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                        .Text = "Descuentos"
                    }
                    row.AddColumn(col)
                    work.AddRow(row)
#End Region

#Region "Descuentos"

                    For Each descrec In _document.DescuentosRecargos.Where(Function(x) x.Item1 = "D")

                        row = New PrinterRow() With {
                        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                        .Color = Color.Black,
                        .FontSize = 8,
                        .IsBold = False
                        }

                        aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
                        aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
                        '~50%
                        aux3 = aux1 - aux2 '100% - ~50%

                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = aux2,
                        .Text = IIf(String.IsNullOrEmpty(descrec.Item2), "Descuento", descrec.Item2.Truncate(10))'total
                        }
                        row.AddColumn(col)

                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Right,
                        .MaxChars = aux3,
                        .Text = descrec.Item3
                        }
                        row.AddColumn(col)
                        work.AddRow(row)
                    Next
#End Region
#Region "Separador"

                    row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
        .Color = Color.Black,
        .FontSize = 8,
        .IsBold = False
        }

                    col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "--------------------------------------------------------------------"
        }
                    row.AddColumn(col)
                    work.AddRow(row)

#End Region


                End If

                If (_document.DescuentosRecargos.Where(Function(x) x.Item1 = "R").Count() <> 0) Then
#Region "Titulo"

                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = True
                    }

                    col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                        .Text = "Recargos"
                    }
                    row.AddColumn(col)
                    work.AddRow(row)
#End Region

#Region "Descuentos"

                    For Each descrec In _document.DescuentosRecargos.Where(Function(x) x.Item1 = "R")

                        row = New PrinterRow() With {
                        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                        .Color = Color.Black,
                        .FontSize = 8,
                        .IsBold = False
                        }

                        aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
                        aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
                        '~50%
                        aux3 = aux1 - aux2 '100% - ~50%

                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = aux2,
                        .Text = IIf(String.IsNullOrEmpty(descrec.Item2), "Recargo", descrec.Item2.Truncate(10))'total
                        }
                        row.AddColumn(col)

                        col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Right,
                        .MaxChars = aux3,
                        .Text = descrec.Item3
                        }
                        row.AddColumn(col)
                        work.AddRow(row)
                    Next
#End Region

#Region "Separador"

                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = False
        }

                    col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "--------------------------------------------------------------------"
        }
                    row.AddColumn(col)
                    work.AddRow(row)

#End Region
                End If

            End If

        End If
#End Region


#Region "Adicionales"

        If (IsNothing(_document.Adicionales) = False) Then
            If (_document.Adicionales.Count() <> 0) Then
                For Each a As Tuple(Of String, Integer) In _document.Adicionales
                    row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = False
                    }
                    aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
                    aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
                    '~50%
                    aux3 = aux1 - aux2  '100% - ~50%

                    col = New PrinterTextColumn() With {
                        .Align = PrinterColumn.Aligns.Left,
                        .MaxChars = aux2,
                        .Text = a.Item1
                    }
                    row.AddColumn(col)

                    col = New PrinterTextColumn() With {
                    .Align = PrinterColumn.Aligns.Right,
                    .MaxChars = aux3,
                    .Text = a.Item2.ToString(NumberFormat)
                    }
                    row.AddColumn(col)
                    work.AddRow(row)

                Next
            End If
        End If
#End Region

#Region "Neto"

        If (_document.Neto <> 0) Then
            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }

            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
            '~50%
            aux3 = aux1 - aux2 '100% - ~50%

            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Left,
            .MaxChars = aux2,
            .Text = "Neto"
            }
            row.AddColumn(col)
            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.Neto.ToString(NumberFormat)
            }

            row.AddColumn(col)
            work.AddRow(row)
        End If

#End Region

#Region "IVA"

        If (_document.IVA <> 0) Then
            row = New PrinterRow() With {
            .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
            .Color = Color.Black,
            .FontSize = 8,
            .IsBold = False
            }
            aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
            '~50%
            aux3 = aux1 - aux2 '100% - ~50%

            col = New PrinterTextColumn() With {
              .Align = PrinterColumn.Aligns.Left,
              .MaxChars = aux2,
              .Text = "IVA (19%)"
            }
            row.AddColumn(col)
            col = New PrinterTextColumn() With {
            .Align = PrinterColumn.Aligns.Right,
            .MaxChars = aux3,
            .Text = _document.IVA.ToString(NumberFormat)
            }
            row.AddColumn(col)
            work.AddRow(row)


        End If

#End Region

#Region "Total"

        row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
        .Color = Color.Black,
        .FontSize = 8,
        .IsBold = False
        }

        aux1 = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular))
        aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)) * 0.5, 0))
        '~50%
        aux3 = aux1 - aux2 '100% - ~50%
        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = aux2,
        .Text = "Total"
        }
        row.AddColumn(col)

        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Right,
        .MaxChars = aux3,
        .Text = _document.Total.ToString(NumberFormat)
        }
        row.AddColumn(col)
        work.AddRow(row)

#End Region

        If (_document.IsDTE) Then

#Region "Separador"

            row = New PrinterRow() With {
                    .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    .Color = Color.Black,
                    .FontSize = 8,
                    .IsBold = False
        }

            col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
        .Text = "                                                                    "
        }
            row.AddColumn(col)
            work.AddRow(row)

#End Region


#Region "Timbre"
            'No debería pasar nunca, pero bueh, la weá se cae si pasa xd
            If (IsNothing(_document.TimbreImage) = False) Then

                row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = False
                }

                col = New PrinterImageColumn() With {
                .Align = PrinterColumn.Aligns.Left,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Image = _document.TimbreImage
                }
                row.AddColumn(col)
                work.AddRow(row)


            End If


#End Region

#Region "Texto : Timbre Electronico"


            row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = False
                }

            col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Center,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = "TIMBRE ELECTRÓNICO S.I.I."
                }
            row.AddColumn(col)
            work.AddRow(row)


#End Region

#Region "Texto: 'Res. xx de xx/xx/xxx'"


            row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = False
                }

            col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Center,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = $"Res.  {_document.NumeroResolucion} de {_document.FechaResolucion.ToString(DateFormat)}"
                }
            row.AddColumn(col)
            work.AddRow(row)


#End Region


#Region "Texto : 'Verifique su boleta en xxx'"

            If (Not String.IsNullOrEmpty(_document.WebVerificación)) Then
                row = New PrinterRow() With {
                .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                .Color = Color.Black,
                .FontSize = 8,
                .IsBold = True
                }

                col = New PrinterTextColumn() With {
                .Align = PrinterColumn.Aligns.Center,
                .MaxChars = FontInfo.GetMaxChars(row.FontSize, IIf(row.IsBold, FontStyle.Bold, FontStyle.Regular)),
                .Text = _document.WebVerificación
                }
                row.AddColumn(col)
                work.AddRow(row)


            End If


#End Region


        End If
        Return work
    End Function


    Public Sub Print(ByVal directPrint As Boolean)
        Try
            Dim pw As printerWork = CreatePrinterWork() '//Aquí debes modificar para cambiar el formato

            Dim service As PrinterService = New PrinterService(pw)
            service.Print(_document.NombreDocumento + " " + _document.Folio, NombreImpresora, Not directPrint)
        Catch
        End Try
    End Sub

    Public Function CreateNewWork() As printerWork
        Dim work As printerWork = New printerWork() With {
        .IsTestWork = True
    }
        Dim row As PrinterRow
        Dim col As PrinterColumn
        row = New PrinterRow() With {
        .TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
        .Color = Color.Black,
        .FontSize = 12,
        .IsBold = True
    }
        col = New PrinterTextColumn() With {
        .Align = PrinterColumn.Aligns.Left,
        .MaxChars = 100,
        .Text = "<<-------------------------------->>"
    }
        row.AddColumn(col)
        work.AddRow(row)
        Return work
    End Function

End Class
