using SIMPLEAPI_Demo.Impresion.Core.Classes;
using SIMPLEAPI_Demo.Impresion.Core.Helpers;
using System;
using System.Drawing;
using System.Linq;

namespace SIMPLEAPI_Demo.Impresion.Core
{
    public class ThermalPrintHandler
    {
        private PrintableDocument _document;

        public string NombreImpresora { get; set; }
        // Formatos //
        public const string DateFormat = "dd/MM/yyyy"; // Por completitud, pongo los formatos aquí en caso de que los haga configurables eventualmente
        public const string NumberFormat = "N0";

        public ThermalPrintHandler(PrintableDocument document) => this._document = document;

        public PrinterWork CreatePrinterWork()
        {
            PrinterWork work = new PrinterWork()
            {
                IsTestWork = false
            };
            PrinterRow row;
            PrinterColumn col;

            int aux1, aux2, aux3;

            #region Razon Social
            if (!string.IsNullOrEmpty(_document.RazonSocial))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 10,
                    IsBold = true
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = _document.RazonSocial
                };
                row.AddColumn(col);

                work.AddRow(row);
            }
            #endregion

            #region Rut
            if (!string.IsNullOrEmpty(_document.Rut))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = RUTHelper.Format(_document.Rut)
                };
                row.AddColumn(col);

                work.AddRow(row);
            }
            #endregion

            #region Giro
            if (!string.IsNullOrEmpty(_document.Giro))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = _document.Giro
                };
                row.AddColumn(col);

                work.AddRow(row);
            }
            #endregion

            #region Casa Matriz      
            if (!string.IsNullOrEmpty(_document.DireccionCasaMatriz))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.4, 0)); // ~40%
                aux3 = aux1 - aux2;

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Casa matriz:"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.DireccionCasaMatriz
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Teléfono    
            if (!string.IsNullOrEmpty(_document.Teléfono))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.4, 0)); // ~40%
                aux3 = aux1 - aux2;

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Teléfono:"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.Teléfono
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Sucursales
            if (_document.Sucursales != null)
            {
                if (_document.Sucursales.Count != 0)
                {
                    foreach (var suc in _document.Sucursales)
                    {
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = false
                        };

                        aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                        aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.33, 0)); // ~33%
                        aux3 = aux1 - aux2; //100% - ~33%

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = aux2,
                            Text = "Sucursal:"
                        };
                        row.AddColumn(col);

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Right,
                            MaxChars = aux3,
                            Text = suc
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                    }
                }
            }
            #endregion

            #region Separador
            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                Color = Color.Black,
                FontSize = 8,
                IsBold = false
            };

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                Text = "--------------------------------------------------------------------"
            };
            row.AddColumn(col);

            work.AddRow(row);
            #endregion

            #region NombreDocumento Y Folio    

            if (!string.IsNullOrEmpty(_document.NombreDocumento))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 10,
                    IsBold = true
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.6, 0)); // ~60%
                aux3 = aux1 - aux2; //100% - ~60%

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = _document.NombreDocumento
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.Folio.ToString()
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            if (_document.IsDTE)
            {
                #region Oficina SII
                if (!string.IsNullOrEmpty(_document.OficinaSII))
                {
                    row = new PrinterRow()
                    {
                        TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                        Color = Color.Black,
                        FontSize = 8,
                        IsBold = false
                    };

                    col = new PrinterTextColumn()
                    {
                        Align = PrinterColumn.Aligns.Left,
                        MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                        Text = _document.OficinaSII
                    };
                    row.AddColumn(col);

                    work.AddRow(row);
                }
                #endregion
            }

            #region Fecha emisión   
            if (_document.FechaEmision != default(DateTime))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.4, 0)); // ~40%
                aux3 = aux1 - aux2; //100% - ~40%

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Fecha Emisión"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.FechaEmision.ToString(DateFormat)
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Separador
            if (!string.IsNullOrEmpty(_document.RutCliente) && _document.RutCliente != "0-0" && _document.RutCliente.Replace(".", "").Replace("-", "") != "666666666")
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = "--------------------------------------------------------------------"
                };
                row.AddColumn(col);

                work.AddRow(row);
            }
            #endregion

            #region Rut Cliente
            if (!string.IsNullOrEmpty(_document.RutCliente) && _document.RutCliente != "0-0" && _document.RutCliente.Replace(".", "").Replace("-", "") != "666666666")
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.4, 0)); // ~40%
                aux3 = aux1 - aux2;

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Rut   :"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.RutCliente
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Nombre cliente
            if (!string.IsNullOrEmpty(_document.RazonSocialCliente))
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.4, 0)); // ~40%
                aux3 = aux1 - aux2;

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Nombre:"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.RazonSocialCliente
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Separador
            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                Color = Color.Black,
                FontSize = 8,
                IsBold = false
            };

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                Text = "--------------------------------------------------------------------"
            };
            row.AddColumn(col);

            work.AddRow(row);
            #endregion

            #region Referencias

            if (_document.Referencias != null)
                if (_document.Referencias.Count != 0)
                {
                    row = new PrinterRow()
                    {
                        TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                        Color = Color.Black,
                        FontSize = 8,
                        IsBold = true
                    };

                    col = new PrinterTextColumn()
                    {
                        Align = PrinterColumn.Aligns.Left,
                        MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                        Text = "Referencias"
                    };
                    row.AddColumn(col);

                    work.AddRow(row);

                    foreach (var referencia in _document.Referencias)
                    {
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = false
                        };

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                            Text = referencia
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                    }

                    #region Separador
                    row = new PrinterRow()
                    {
                        TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                        Color = Color.Black,
                        FontSize = 8,
                        IsBold = false
                    };

                    col = new PrinterTextColumn()
                    {
                        Align = PrinterColumn.Aligns.Left,
                        MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                        Text = "---------------------------------------------------------------------"
                    };
                    row.AddColumn(col);

                    work.AddRow(row);
                    #endregion
                }

            #endregion

            #region Header de los detalles           
            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                Color = Color.Black,
                FontSize = 8,
                IsBold = false
            };

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = 5,
                Text = "Cant."
            };
            row.AddColumn(col);

            if (_document.ShowUnidadMedida)
            {
                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = 3,
                    Text = "UM"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = 18,
                    Text = "Descripcion"
                };
                row.AddColumn(col);
            }
            else
            {
                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = 21,
                    Text = "Descripcion"
                };
                row.AddColumn(col);
            }

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Right,
                MaxChars = 10,
                Text = "Precio"
            };
            row.AddColumn(col);

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Right,
                MaxChars = 9,
                Text = "Total"
            };
            row.AddColumn(col);

            work.AddRow(row);
            #endregion

            #region Separador
            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                Color = Color.Black,
                FontSize = 8,
                IsBold = false
            };

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                Text = "--------------------------------------------------------------------"
            };
            row.AddColumn(col);

            work.AddRow(row);
            #endregion

            #region Detalles           

            if (_document.Detalles != null)
                if (_document.Detalles.Count != 0)
                    foreach (var detalle in _document.Detalles)
                    {
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = false
                        };

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = 4, // 4 carácteres de font regular 8 (cantidad)
                            Text = detalle.Cantidad.ToString(NumberFormat)
                        };
                        row.AddColumn(col);

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = 1, // 1 carácteres de font regular 8 (separador)
                            Text = " "
                        };
                        row.AddColumn(col);

                        if (_document.ShowUnidadMedida)
                        {
                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Left,
                                MaxChars = 2, // 2 carácteres de font regular 8 (unidad medida.)
                                Text = detalle.UnidadMedida.Truncate(2)
                            };
                            row.AddColumn(col);
                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Left,
                                MaxChars = 1, // 1 carácteres de font regular 8 (separador)
                                Text = " "
                            };
                            row.AddColumn(col);
                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Left,
                                MaxChars = 17, // 20 carácteres de font regular 8 (nombre art.)
                                Text = detalle.Descripcion.Truncate(17)
                            };
                            row.AddColumn(col);
                        }
                        else
                        {
                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Left,
                                MaxChars = 20, // 20 carácteres de font regular 8 (nombre art.)
                                Text = detalle.Descripcion
                            };
                            row.AddColumn(col);
                        }

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = 1, // 1 carácteres de font regular 8 (separador)
                            Text = " "
                        };
                        row.AddColumn(col);

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Right,
                            MaxChars = 9, // 9 carácteres de font regular 8 (precio)
                            Text = detalle.Precio.ToString(NumberFormat)
                        };
                        row.AddColumn(col);

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = 1, // 1 carácteres de font regular 8 (separador)
                            Text = " "
                        };
                        row.AddColumn(col);

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Right,
                            MaxChars = 9, // 9 carácteres de font regular 8 (total)
                            Text = detalle.Total.ToString(NumberFormat)
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                    }
            #endregion

            #region Separador
            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                Color = Color.Black,
                FontSize = 8,
                IsBold = false
            };

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                Text = "---------------------------------------------------------------------"
            };
            row.AddColumn(col);

            work.AddRow(row);
            #endregion

            #region Total Exento
            if (_document.TotalExento != 0)
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
                aux3 = aux1 - aux2; // 100% - ~50%

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Total exento"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.TotalExento.ToString(NumberFormat)
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Descuento
            if (_document.DescuentosRecargos != null)
                if (_document.DescuentosRecargos.Count != 0)
                {
                    if (_document.DescuentosRecargos.Where(x => x.Item1 == 'D').Count() != 0)
                    {
                        #region Titulo
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = true
                        };

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                            Text = "Descuentos"
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                        #endregion

                        #region Descuentos
                        foreach (var descrec in _document.DescuentosRecargos.Where(x => x.Item1 == 'D'))
                        {
                            row = new PrinterRow()
                            {
                                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                                Color = Color.Black,
                                FontSize = 8,
                                IsBold = false
                            };

                            aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
                            aux3 = aux1 - aux2; // 100% - ~50%

                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Left,
                                MaxChars = aux2,
                                Text = string.IsNullOrEmpty(descrec.Item2) ? "Descuento" : descrec.Item2.Truncate(10), //"Total"
                            };
                            row.AddColumn(col);

                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Right,
                                MaxChars = aux3,
                                Text = descrec.Item3
                            };
                            row.AddColumn(col);
                            work.AddRow(row);
                        }
                        #endregion

                        #region Separador
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = false
                        };

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                            Text = "---------------------------------------------------------------------"
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                        #endregion
                    }
                    if (_document.DescuentosRecargos.Where(x => x.Item1 == 'R').Count() != 0)
                    {
                        #region Titulo
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = true
                        };

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                            Text = "Recargos"
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                        #endregion

                        #region Descuentos
                        foreach (var descrec in _document.DescuentosRecargos.Where(x => x.Item1 == 'R'))
                        {
                            row = new PrinterRow()
                            {
                                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                                Color = Color.Black,
                                FontSize = 8,
                                IsBold = false
                            };

                            aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
                            aux3 = aux1 - aux2; // 100% - ~50%

                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Left,
                                MaxChars = aux2,
                                Text = string.IsNullOrEmpty(descrec.Item2) ? "Recargo" : descrec.Item2.Truncate(10), //"Total"
                            };
                            row.AddColumn(col);

                            col = new PrinterTextColumn()
                            {
                                Align = PrinterColumn.Aligns.Right,
                                MaxChars = aux3,
                                Text = descrec.Item3
                            };
                            row.AddColumn(col);
                            work.AddRow(row);
                        }
                        #endregion

                        #region Separador
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = false
                        };

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                            Text = "---------------------------------------------------------------------"
                        };
                        row.AddColumn(col);

                        work.AddRow(row);
                        #endregion
                    }
                }
            #endregion

            #region Adicionales
            if (_document.Adicionales != null)
                if (_document.Adicionales.Count != 0)
                    foreach ((string, int) a in _document.Adicionales)
                    {
                        row = new PrinterRow()
                        {
                            TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                            Color = Color.Black,
                            FontSize = 8,
                            IsBold = false
                        };

                        aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                        aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
                        aux3 = aux1 - aux2; // 100% - ~50%

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Left,
                            MaxChars = aux2,
                            Text = a.Item1
                        };
                        row.AddColumn(col);

                        col = new PrinterTextColumn()
                        {
                            Align = PrinterColumn.Aligns.Right,
                            MaxChars = aux3,
                            Text = a.Item2.ToString(NumberFormat)
                        };
                        row.AddColumn(col);
                        work.AddRow(row);
                    }
            #endregion

            #region Neto
            if (_document.Neto != 0)
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
                aux3 = aux1 - aux2; // 100% - ~50%

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "Neto"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.Neto.ToString(NumberFormat)
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region IVA
            if (_document.IVA != 0)
            {
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
                aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
                aux3 = aux1 - aux2; // 100% - ~50%

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = aux2,
                    Text = "IVA (19%)"
                };
                row.AddColumn(col);

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Right,
                    MaxChars = aux3,
                    Text = _document.IVA.ToString(NumberFormat)
                };
                row.AddColumn(col);
                work.AddRow(row);
            }
            #endregion

            #region Total
            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                Color = Color.Black,
                FontSize = 8,
                IsBold = false
            };

            aux1 = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular);
            aux2 = Convert.ToInt32(Math.Round(FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular) * 0.5, 0)); // ~50%
            aux3 = aux1 - aux2; // 100% - ~50%

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = aux2,
                Text = "Total"
            };
            row.AddColumn(col);

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Right,
                MaxChars = aux3,
                Text = _document.Total.ToString(NumberFormat)
            };
            row.AddColumn(col);
            work.AddRow(row);
            #endregion

            if (_document.IsDTE)
            {
                #region Separador
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Left,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = "                                                                     "
                };
                row.AddColumn(col);

                work.AddRow(row);
                #endregion

                #region Timbre
                /*
                 No debería pasar nunca, pero bueh, la weá se cae si pasa xd
                 */
                if (_document.TimbreImage != null)
                {
                    row = new PrinterRow()
                    {
                        TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                        Color = Color.Black,
                        FontSize = 8,
                        IsBold = false
                    };

                    col = new PrinterImageColumn()
                    {
                        Align = PrinterColumn.Aligns.Left,
                        MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                        Image = _document.TimbreImage
                    };
                    row.AddColumn(col);

                    work.AddRow(row);
                }
                #endregion

                #region Texto: 'Timbre Electrónico S.I.I
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = true
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Center,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = "TIMBRE ELECTRÓNICO S.I.I."
                };
                row.AddColumn(col);

                work.AddRow(row);
                #endregion

                #region Texto: 'Res. xx de xx/xx/xxx'
                row = new PrinterRow()
                {
                    TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                    Color = Color.Black,
                    FontSize = 8,
                    IsBold = false
                };

                col = new PrinterTextColumn()
                {
                    Align = PrinterColumn.Aligns.Center,
                    MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                    Text = $"Res. { _document.NumeroResolucion } de { _document.FechaResolucion.ToString(DateFormat) }"
                };
                row.AddColumn(col);

                work.AddRow(row);
                #endregion

                #region Texto: 'Verifique su boleta en xxx'
                if (!string.IsNullOrEmpty(_document.WebVerificación))
                {
                    row = new PrinterRow()
                    {
                        TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Wrap,
                        Color = Color.Black,
                        FontSize = 8,
                        IsBold = true
                    };

                    col = new PrinterTextColumn()
                    {
                        Align = PrinterColumn.Aligns.Center,
                        MaxChars = FontInfo.GetMaxChars(row.FontSize, row.IsBold ? FontStyle.Bold : FontStyle.Regular),
                        Text = _document.WebVerificación
                    };
                    row.AddColumn(col);

                    work.AddRow(row);
                }
                #endregion
            }

            return work;
        }

        public void Print(bool directPrint)
        {
            try
            {
                PrinterWork pw = CreatePrinterWork(); //Aquí debes modificar para cambiar el formato
                PrinterService service = new PrinterService(pw);
                service.Print(_document.NombreDocumento + " " + _document.Folio, NombreImpresora, !directPrint);
            }
            catch
            {

            }
        }

        public PrinterWork CreateNewWork()
        {
            PrinterWork work = new PrinterWork()
            {
                IsTestWork = true
            };
            PrinterRow row;
            PrinterColumn col;

            row = new PrinterRow()
            {
                TextOverflowResolveMethod = PrinterRow.TextOverflowResolveMethods.Truncate,
                Color = Color.Black,
                FontSize = 12,
                IsBold = true
            };

            col = new PrinterTextColumn()
            {
                Align = PrinterColumn.Aligns.Left,
                MaxChars = 100,
                Text = "<<-------------------------------->>"
            };
            row.AddColumn(col);
            work.AddRow(row);

            return work;
        }
    }
}
