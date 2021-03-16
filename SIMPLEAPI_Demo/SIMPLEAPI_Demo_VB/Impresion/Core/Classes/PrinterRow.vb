


Public Class PrinterRow
    Public Enum TextOverflowResolveMethods
        Truncate = 0
        Wrap = 1
    End Enum

    Public Property TextOverflowResolveMethod As TextOverflowResolveMethods
    Public Property Color As Color
    Public Property FontSize As Integer
    Public Property IsBold As Boolean
    Public Property Columns As List(Of PrinterColumn)

    Public Sub New()
        Columns = New List(Of PrinterColumn)()
    End Sub

    Public Sub AddColumn(ByVal col As PrinterColumn)
        Columns.Add(col)
    End Sub

    Public Sub ValidateColumnsWidth(ByVal Optional testing As Boolean = False)
        If testing Then Return
        Dim total_chars = Columns.Sum(Function(x) x.MaxChars)
        Dim max_chars_font = FontInfo.GetMaxChars(FontSize, If(IsBold, FontStyle.Bold, FontStyle.Regular))
        If total_chars > max_chars_font Then Throw New Exception("Max chars for font currently in use must not be over " & max_chars_font)
    End Sub

    Public Function ToLines() As List(Of String)
        Dim Lines As List(Of String) = New List(Of String)()
        Dim text = ""
        Dim aux = ""
        Dim i, j As Integer

        For colIndex As Integer = 0 To Columns.Count - 1
            Dim column = Columns(colIndex)

            If TypeOf column Is PrinterTextColumn Then
                Dim col = TryCast(column, PrinterTextColumn)
                text = If(col.Text, "")

                Select Case col.Align
                    Case PrinterColumn.Aligns.Center
                        text = text.CenterTo(col.MaxChars)
                    Case PrinterColumn.Aligns.Left
                    Case PrinterColumn.Aligns.Right
                        text = text.PadLeft(col.MaxChars, " "c)
                End Select

                If TextOverflowResolveMethod = TextOverflowResolveMethods.Truncate Then text = text.Truncate(col.MaxChars)
                i = 0
                j = 0

                While i < text.Length
                    If Lines.Count = j Then Lines.Add("")
                    ' // Iniciar nueva línea respetando el espacio de las columnas anteriores
                    If i <> 0 AndAlso Lines.Count - 1 = j AndAlso colIndex > 0 Then Lines(j) += "".PadLeft(Columns.Take(colIndex - 1).Sum(Function(x) x.MaxChars) + 1, " "c)
                    '// Extraer porción del texto que cabe en una línea

                    aux = text.Substring(i, If(i + col.MaxChars > text.Length, text.Length - i, col.MaxChars)).PadRight(col.MaxChars, " "c)

                    '// La línea no puede iniciar con un espacio, por lo tanto, se corren hasta el final.

                    If aux.Length <> aux.TrimStart().Length Then aux = aux.TrimStart() & "".PadLeft(aux.Length - aux.TrimStart().Length, " "c)


                    '// respetar alineación de la columna en nueva línea

                    Select Case col.Align
                        Case PrinterColumn.Aligns.Center
                            aux = aux.CenterTo(col.MaxChars)
                        Case PrinterColumn.Aligns.Left
                        Case PrinterColumn.Aligns.Right
                            aux = aux.Trim().PadLeft(col.MaxChars, " "c)
                    End Select

                    Lines(j) += aux
                    i += col.MaxChars
                    j += 1
                End While

                If j < Lines.Count Then

                    For i = j To Lines.Count - 1
                        Lines(i) += "".PadRight(col.MaxChars, " "c)
                    Next
                End If
            ElseIf TypeOf column Is PrinterImageColumn Then
                Dim col = TryCast(column, PrinterImageColumn)
                Lines.Add($"<img>{col.Image}</img>")
            Else
                Throw New Exception("col type not supported")
            End If
        Next

        Return Lines
    End Function
End Class

