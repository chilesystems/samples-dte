Public Class ItemBoleta
    Public Property Nombre As String
    Public Property Cantidad As Decimal
    Public Property Precio As Integer

    Public ReadOnly Property Total As Integer
        Get
            Return CInt(Math.Round(Cantidad * Precio, 0))
        End Get
    End Property

    Public Property Afecto As Boolean
    Public Property UnidadMedida As String
    Public Property Descuento As Double
    Public _tipoImpuesto As Integer

    Public Property TipoImpuesto As ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum
        Get
            Return If(_tipoImpuesto <> 0, CType(_tipoImpuesto, ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum), ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum.NotSet)
        End Get
        Set(ByVal value As ChileSystems.DTE.Engine.[Enum].TipoImpuesto.TipoImpuestoEnum)
            _tipoImpuesto = CInt(value)
        End Set
    End Property
End Class

