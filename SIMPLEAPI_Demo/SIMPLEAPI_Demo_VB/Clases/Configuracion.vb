
Imports System.Web.Script.Serialization
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Class Configuracion

        Dim ser As JavaScriptSerializer = New JavaScriptSerializer()

        Public Property Empresa As Contribuyente
        Public Property Certificado As CertificadoDigital
        Public Property APIKey As String
        Public Property ProductosSimulacion As List(Of ProductoSimulacion)

        Public Sub GenerarArchivo()
            File.WriteAllText("configuracion.json", ser.Serialize(Me), Encoding.GetEncoding("ISO-8859-1"))
        End Sub

        Public Function VerificarCarpetasIniciales() As Boolean
            Return Directory.Exists("out\temp") AndAlso Directory.Exists("out\caf") AndAlso Directory.Exists("XML")
        End Function

        Public Function LeerArchivo() As Boolean
            Try
                Dim conf = ser.Deserialize(Of Configuracion)(File.ReadAllText("configuracion.json", Encoding.GetEncoding("ISO-8859-1")))
                Me.Empresa = conf.Empresa
                Me.Certificado = conf.Certificado
                Me.APIKey = conf.APIKey
                Me.ProductosSimulacion = conf.ProductosSimulacion
                Return True
            Catch
                InicializarArchivo()
            End Try

            Return False
        End Function

        Public Sub InicializarArchivo()
            Dim empresa As Contribuyente = New Contribuyente() With {
                .RazonSocial = "RAZÓN SOCIAL",
                .Giro = "GIRO GLOSA DESCRIPTIVA",
                .Direccion = "DIRECCION 787",
                .Comuna = "COMUNA",
                .FechaResolucion = New DateTime(2016, 4, 28),
                .NumeroResolucion = 0,
                .RutEmpresa = "77777777-7",
                .CodigosActividades = New List(Of ActividadEconomica)() From {
                    New ActividadEconomica() With {
                        .Codigo = 463020
                    },
                    New ActividadEconomica() With {
                        .Codigo = 472109
                    },
                    New ActividadEconomica() With {
                        .Codigo = 472200
                    }
                }
            }
            empresa = empresa
            Certificado = New CertificadoDigital() With {
                .Nombre = "NOMBRE CERTIFICADO DIGITAL",
                .Rut = "55555555-5"
            }
            APIKey = "API-KEY"
            ProductosSimulacion = New List(Of ProductoSimulacion)() From {
                New ProductoSimulacion() With {
                    .Nombre = "SERVICIO DE FACTURACION ELECT"
                },
                New ProductoSimulacion() With {
                    .Nombre = "ASESORIA COMPUTACIONAL"
                },
                New ProductoSimulacion() With {
                    .Nombre = "CAPACITACION AL PERSONAL"
                },
                New ProductoSimulacion() With {
                    .Nombre = "IMPLEMENTACION DE ERP"
                },
                New ProductoSimulacion() With {
                    .Nombre = "SERVICIO DE LIMPIEZA"
                },
                New ProductoSimulacion() With {
                    .Nombre = "SERVICIO DE ASESORIA INFORMATICA"
                },
                New ProductoSimulacion() With {
                    .Nombre = "DESARROLLO DE SITIOS WEB"
                },
                New ProductoSimulacion() With {
                    .Nombre = "QA DE DESARROLLOS EXTERNOS"
                },
                New ProductoSimulacion() With {
                    .Nombre = "LIMPIEZA DE COMPUTADORES"
                },
                New ProductoSimulacion() With {
                    .Nombre = "AUTOMATIZACION DE DATOS"
                },
                New ProductoSimulacion() With {
                    .Nombre = "DESARROLLO DE ETL"
                }
            }
        GenerarArchivo()


    End Sub
    End Class

Public Class ProductoSimulacion
    Public Property Nombre As String
End Class
