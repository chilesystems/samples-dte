using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Clases
{
    public class Configuracion
    {
        public Contribuyente Empresa { get; set; }
        public CertificadoDigital Certificado { get; set; }
        public string APIKey { get; set; }
        public List<ProductoSimulacion> ProductosSimulacion{ get; set; }

        public void GenerarArchivo()
        {
            File.WriteAllText("configuracion.json", JsonConvert.SerializeObject(this), Encoding.GetEncoding("ISO-8859-1"));
        }

        public bool VerificarCarpetasIniciales()
        {
            return Directory.Exists("out\\temp") && Directory.Exists("out\\caf") && Directory.Exists("XML"); 
        }

        public bool LeerArchivo()
        {
            try
            {
                var conf = JsonConvert.DeserializeObject<Configuracion>(File.ReadAllText("configuracion.json", Encoding.GetEncoding("ISO-8859-1")));
                this.Empresa = conf.Empresa;
                this.Certificado = conf.Certificado;
                this.APIKey = conf.APIKey;
                this.ProductosSimulacion = conf.ProductosSimulacion;
                return true;
            }
            catch
            {
                InicializarArchivo();
            }
            return false;
        }

        public void InicializarArchivo()
        {
            Contribuyente empresa = new Contribuyente()
            {
                RazonSocial = "RAZÓN SOCIAL",
                Giro = "GIRO GLOSA DESCRIPTIVA",
                Direccion = "DIRECCION 787",
                Comuna = "COMUNA",
                FechaResolucion = new DateTime(2016, 4, 28),
                NumeroResolucion = 0,
                RutEmpresa = "77777777-7",
                CodigosActividades = new List<ActividadEconomica>()
                {
                    new ActividadEconomica() { Codigo =  463020},
                    new ActividadEconomica() { Codigo =  472109},
                    new ActividadEconomica() { Codigo =  472200}
                }
            };

            Empresa = empresa;
            Certificado = new CertificadoDigital()
            {
                Nombre = "NOMBRE CERTIFICADO DIGITAL",
                Rut = "55555555-5"
            };
            APIKey = "API-KEY";
            ProductosSimulacion = new List<ProductoSimulacion>() 
            { 
                new ProductoSimulacion() { Nombre = "SERVICIO DE FACTURACION ELECT" },
                new ProductoSimulacion() { Nombre = "ASESORIA COMPUTACIONAL"},
                new ProductoSimulacion() { Nombre = "CAPACITACION AL PERSONAL"},
                new ProductoSimulacion() { Nombre = "IMPLEMENTACION DE ERP"},
                new ProductoSimulacion() { Nombre = "SERVICIO DE LIMPIEZA"},
                new ProductoSimulacion() { Nombre = "SERVICIO DE ASESORIA INFORMATICA"},
                new ProductoSimulacion() { Nombre = "DESARROLLO DE SITIOS WEB"},
                new ProductoSimulacion() { Nombre = "QA DE DESARROLLOS EXTERNOS"},
                new ProductoSimulacion() { Nombre = "LIMPIEZA DE COMPUTADORES"},
                new ProductoSimulacion() { Nombre = "AUTOMATIZACION DE DATOS"},
                new ProductoSimulacion() { Nombre = "DESARROLLO DE ETL" }
            };
            GenerarArchivo();
        }
    }

    public class ProductoSimulacion
    {
        public string Nombre { get; set; }
    }



}
