Public Class FontInfo
    Public Const FontName As String = "Consolas"
    '// if changed, change max chars per font size table in method GetMaxChars(font)
    Public Shared Function GetMaxChars(ByVal fontSize As Integer, ByVal fontStyle As FontStyle, ByVal Optional testing As Boolean = False) As Integer
        Return GetMaxChars(New Font(FontName, fontSize, fontStyle), testing)
    End Function

    Public Shared Function GetMaxChars(ByVal font As Font, ByVal Optional testing As Boolean = False) As Integer
        If testing Then Return 100
        If font.FontFamily.Name <> FontName Then Throw New Exception("Font not supported")
        Dim fontSize As Integer = CInt(font.Size)

        If font.Style = FontStyle.Bold Then

            If fontSize = 7 Then
                Return 52
            ElseIf fontSize = 8 Then
                Return 45
            ElseIf fontSize = 10 Then
                Return 36
            ElseIf fontSize = 12 Then
                Return 15
            Else
                Throw New Exception("fontSize not permitted")
            End If
        ElseIf font.Style = FontStyle.Italic Then

            If fontSize = 7 Then
                Return 52
            ElseIf fontSize = 8 Then
                Return 45
            ElseIf fontSize = 10 Then
                Return 36
            ElseIf fontSize = 12 Then
                Return 15
            Else
                Throw New Exception("fontSize not permitted")
            End If
        Else

            If fontSize = 7 Then
                Return 52
            ElseIf fontSize = 8 Then
                Return 45
            ElseIf fontSize = 10 Then
                Return 36
            ElseIf fontSize = 12 Then
                Return 15
            Else
                Throw New Exception("fontSize not permitted")
            End If
        End If
    End Function
End Class
