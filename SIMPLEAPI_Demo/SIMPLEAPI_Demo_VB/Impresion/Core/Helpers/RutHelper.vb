Module RUTHelper
    Function Format(ByVal rut As String) As String
        Dim cont As Integer = 0
        Dim formato As String

        If rut.Length = 0 Then
            Return ""
        Else
            rut = rut.Replace(".", "")
            rut = rut.Replace("-", "")
            formato = "-" & rut.Substring(rut.Length - 1)

            For i As Integer = rut.Length - 2 To 0 Step -1

                formato = rut.Substring(i, 1) & formato
                cont += 1

                If cont = 3 AndAlso i <> 0 Then
                    formato = "." & formato
                    cont = 0
                End If
            Next

            Return formato
        End If
    End Function
End Module
