Imports System.Text

Public Class printerWork
    Public Property IsTestWork As Boolean
    Public Property Rows As List(Of PrinterRow)

    Public Sub New()
        Rows = New List(Of PrinterRow)()
    End Sub

    Public Sub AddRow(ByVal row As PrinterRow)
        Rows.Add(row)
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As StringBuilder = New StringBuilder()

        For Each row In Rows
            String.Join("||", row.Columns.[Select](Function(x) If(TypeOf x Is PrinterTextColumn, (TryCast(x, PrinterTextColumn)).Text, If(TypeOf x Is PrinterImageColumn, "{ Image }", x.[GetType]().Name))))
        Next

        Return sb.ToString()
    End Function

    Public Function ToLines() As List(Of String)
        Dim Lines = New List(Of String)()

        For Each row In Rows
            Lines.AddRange(row.ToLines())
        Next
        '//var linesStrng = string.Join(Environment.NewLine, Lines);
        Return Lines
    End Function
End Class
