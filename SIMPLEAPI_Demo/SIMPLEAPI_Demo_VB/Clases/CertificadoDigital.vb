Public Class CertificadoDigital
    Public Property Nombre As String
    Public Property Rut As String

    Public ReadOnly Property RutCuerpo As Integer
        Get
            Return Integer.Parse(Rut.Substring(0, Rut.Length - 2))
        End Get
    End Property

    Public ReadOnly Property DV As String
        Get
            Return Rut.Substring(Rut.Length - 1, 1)
        End Get
    End Property

End Class
