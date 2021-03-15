

Imports System.Drawing

Imports System.Drawing.Printing

Public Class PrinterService
    Private Property Fonts As List(Of Font)
    Private Property BrushesPallete As List(Of SolidBrush)
    Private Property Work As printerWork

    Enum WrapResolve
        Truncate = 0
        Wrap = 1
    End Enum

    Public Sub New(ByVal work As printerWork)
        Me.Work = work
        BrushesPallete = New List(Of SolidBrush)()
        Fonts = New List(Of Font)()
    End Sub

    '''<summary>
    '''Printer previously generated PrinterWork
    ''' </summary>
    '''<param name="documentName">Nombre del documento a imprimir.</param>
    '''<param name="printerName"></param>
    '''<param name="debugMode"></param>

    Public Sub Print(ByVal documentName As String, ByVal printerName As String, ByVal Optional debugMode As Boolean = False)
        If String.IsNullOrEmpty(documentName) Then Throw New ArgumentException("El parámetro 'documentName' no puede ser 'null' o estar vacío", documentName)
        If String.IsNullOrEmpty(printerName) Then Throw New ArgumentException("El parámetro 'printerName' no puede ser 'null' o estar vacío", printerName)
        If Work Is Nothing Then Throw New ArgumentException("No se puede imprimir si la propiedad 'Work' es null", printerName)
        If Work.Rows.Count = 0 Then Return
        Dim pdoc As PrintDocument = New PrintDocument()
        pdoc.DocumentName = documentName
        If Not debugMode Then pdoc.PrintController = New StandardPrintController()
        pdoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 100, 200)
        pdoc.DefaultPageSettings.PaperSize.Height = Work.Rows.Count * 24
        pdoc.DefaultPageSettings.PaperSize.Width = 300
        AddHandler pdoc.PrintPage, New PrintPageEventHandler(AddressOf PrintEvent)

        If Not debugMode Then
            Dim ps As PrinterSettings = New PrinterSettings()
            ps.PrinterName = printerName
            pdoc.PrinterSettings = ps
            pdoc.Print()
        Else
            Dim printPrvDlg As PrintPreviewDialog = New PrintPreviewDialog()
            printPrvDlg.Document = pdoc
            printPrvDlg.Width = 1200
            printPrvDlg.Height = 800
            printPrvDlg.ShowDialog()
        End If
    End Sub
    Private Sub PrintEvent(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim graphics As Graphics = e.Graphics
        Dim brush As SolidBrush
        Dim font As Font
        Dim currentY As Integer = 0

        For Each row In Work.Rows
            brush = GetBrush(row.Color)
            font = GetFont(row.FontSize, row.IsBold)
            row.ValidateColumnsWidth(Work.IsTestWork)

            For Each line In row.ToLines()

                If line.StartsWith("<img>") AndAlso line.EndsWith("</img>") Then
                    Dim col = TryCast(row.Columns.First(), PrinterImageColumn)
                    graphics.DrawImage(col.Image, 0, currentY, 290, 120)
                    currentY += 120
                    Exit For
                Else
                    graphics.DrawString(line, font, brush, 0, currentY)
                    currentY += CInt(font.GetHeight())
                End If
            Next
        Next
    End Sub

#Region "Helpers"
    Private Function GetFont(ByVal size As Single, ByVal isBold As Boolean) As Font
        Dim font = Fonts.FirstOrDefault(Function(x) x.Size = size AndAlso (If(isBold, x.Style = FontStyle.Bold, x.Style = FontStyle.Regular)))

        If font Is Nothing Then
            font = New Font(FontInfo.FontName, size, (If(isBold, FontStyle.Bold, FontStyle.Regular)))
            Fonts.Add(font)
        End If

        Return font
    End Function

    Private Function GetBrush(ByVal color As Color) As SolidBrush
        Dim brush = BrushesPallete.FirstOrDefault(Function(x) x.Color = color)

        If brush Is Nothing Then
            brush = New SolidBrush(color)
            BrushesPallete.Add(New SolidBrush(color))
        End If

        Return brush
    End Function
#End Region
End Class
