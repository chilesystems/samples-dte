Imports System.Runtime.CompilerServices

Module StringHelper
    <Extension()>
    Public Function Truncate(ByVal value As String, ByVal maxLength As Integer) As String
        If String.IsNullOrEmpty(value) Then Return value
        If value.Length > maxLength Then Console.WriteLine(String.Format("Truncate performed: {0} to {1}", value, value.Substring(0, maxLength)))
        Return If(value.Length <= maxLength, value, value.Substring(0, maxLength))
    End Function
    <Extension()>
    Public Function CenterTo(ByVal value As String, ByVal lenght As Integer) As String
        value = value.Trim()
        If String.IsNullOrEmpty(value) Then Return value
        If value.Length > lenght Then Return value
        Return value.PadLeft(value.Length + ((lenght - value.Length) / 2), " "c)
    End Function
End Module
