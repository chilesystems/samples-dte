using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Impresion.Core.Helpers
{
    public static class DTETypeNames
    {
        public static Dictionary<int, string> Names =
            new Dictionary<int, string>()
            {
                { 30, "Factura" },
                { 32, "Factura de ventas y servicios no afectos o exentos de IVA" },
                {33, "Factura electrónica" },
                {34, "Factura no afecta o exenta electrónica" },
                {35, "Boleta" },
                {38, "Boleta exenta" },
                {39, "Boleta electrónica" },
                {40, "Liquidación factura" },
                {41, "Boleta exenta electrónica" },
                {43, "Liquidación factura electrónica" },
                {45, "Factura de compra" },
                {46, "Factura de compra electrónica" },
                {48, "Pago electrónico" },
                {50, "Guía de despacho" },
                {52, "Guía de despacho electrónica" },
                {55, "Nota de débito" },
                {56, "Nota de débito electrónica" },
                {60, "Nota de crédito" },
                {61, "Nota de crédito electrónica" },
                {103, "Liquidación" },
                {110, "Factura de exportación electrónica" },
                {111, "Nota de débito de exportación electrónica" },
                {112, "Nota de crédito de exportación electrónica" },
            };
    }
}
