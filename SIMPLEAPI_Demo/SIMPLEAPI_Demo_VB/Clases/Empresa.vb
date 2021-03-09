Public Class Contribuyente
    Public Property RutEmpresa As String
    Public Property RazonSocial As String
    Public Property Giro As String
    Public Property Direccion As String
    Public Property Comuna As String
    Public Property CodigosActividades As List(Of ActividadEconomica)
    Public Property FechaResolucion As DateTime
    Public Property NumeroResolucion As Integer

    Public ReadOnly Property RutCuerpo As Integer
        Get
            Return Integer.Parse(RutEmpresa.Substring(0, RutEmpresa.Length - 2))
        End Get
    End Property

    Public ReadOnly Property DV As String
        Get
            Return RutEmpresa.Substring(RutEmpresa.Length - 1, 1)
        End Get
    End Property
End Class

Public Class ActividadEconomica
    Public Property Codigo As Integer
End Class
