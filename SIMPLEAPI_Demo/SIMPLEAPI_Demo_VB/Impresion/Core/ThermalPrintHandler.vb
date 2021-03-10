Imports SIMPLEAPI_Demo_VB.PrinterRow

Public Class ThermalPrintHandler
    Private _document As PrintableDocument
    Public Property NombreImpresora As String
    Public Const DateFormat As String = "dd/MM/yyyy"
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
            .Text = _document.RazonSocial '.MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold?(FontSyle.Bold: FontStyle.Regular)), 
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
            .Text = RUTHelper.Format(_document.Rut)'.MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold, FontStyle.Regular),
            }


        End If


#End Region

    End Function
End Class
