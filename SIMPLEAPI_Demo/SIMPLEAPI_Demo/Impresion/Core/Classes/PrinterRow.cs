using SIMPLEAPI_Demo.Impresion.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Impresion.Core.Classes
{
    public class PrinterRow
    {
        public enum TextOverflowResolveMethods
        {
            Truncate = 0,
            Wrap = 1
        }

        public TextOverflowResolveMethods TextOverflowResolveMethod { get; set; }

        public Color Color { get; set; }
        public int FontSize { get; set; }
        public bool IsBold { get; set; }

        public List<PrinterColumn> Columns { get; private set; }

        public PrinterRow()
        {
            Columns = new List<PrinterColumn>();
        }

        public void AddColumn(PrinterColumn col)
        {
            Columns.Add(col);
        }

        public void ValidateColumnsWidth(bool testing = false)
        {
            if (testing)
                return;

            var total_chars = Columns.Sum(x => x.MaxChars);
            var max_chars_font = FontInfo.GetMaxChars(FontSize, IsBold ? FontStyle.Bold : FontStyle.Regular);
            if (total_chars > max_chars_font)
                throw new Exception("Max chars for font currently in use must not be over " + max_chars_font);
        }

        public List<string> ToLines()
        {
            List<string> Lines = new List<string>();
            var text = "";
            var aux = "";
            int i, j;

            for (int colIndex = 0; colIndex < Columns.Count; colIndex++)
            {
                var column = Columns[colIndex];

                if (column is PrinterTextColumn)
                {
                    var col = column as PrinterTextColumn;

                    text = col.Text ?? "";
                    switch (col.Align)
                    {
                        case PrinterColumn.Aligns.Center:
                            text = text.CenterTo(col.MaxChars);
                            break;
                        case PrinterColumn.Aligns.Left:
                            break;
                        case PrinterColumn.Aligns.Right:
                            text = text.PadLeft(col.MaxChars, ' ');
                            break;
                    }

                    if (TextOverflowResolveMethod == TextOverflowResolveMethods.Truncate)
                        text = text.Truncate(col.MaxChars);

                    for (i = 0, j = 0; i < text.Length; i += col.MaxChars, j++)
                    {
                        if (Lines.Count == j)
                            Lines.Add("");

                        // Iniciar nueva línea respetando el espacio de las columnas anteriores
                        if (i != 0 && Lines.Count - 1 == j && colIndex > 0)
                            Lines[j] += "".PadLeft(Columns.Take(colIndex - 1).Sum(x => x.MaxChars) + 1, ' ');

                        // Extraer porción del texto que cabe en una línea
                        aux = text.Substring(i, i + col.MaxChars > text.Length ? text.Length - i : col.MaxChars).PadRight(col.MaxChars, ' ');

                        // La línea no puede iniciar con un espacio, por lo tanto, se corren hasta el final.
                        if (aux.Length != aux.TrimStart().Length)
                            aux = aux.TrimStart() + "".PadLeft(aux.Length - aux.TrimStart().Length, ' ');

                        // respetar alineación de la columna en nueva línea
                        switch (col.Align)
                        {
                            case PrinterColumn.Aligns.Center:
                                aux = aux.CenterTo(col.MaxChars);
                                break;
                            case PrinterColumn.Aligns.Left:
                                break;
                            case PrinterColumn.Aligns.Right:
                                aux = aux.Trim().PadLeft(col.MaxChars, ' ');
                                break;
                        }

                        Lines[j] += aux;
                    }
                    if (j < Lines.Count)
                        for (i = j; i < Lines.Count; i++)
                            Lines[i] += "".PadRight(col.MaxChars, ' ');
                }
                else if (column is PrinterImageColumn)
                {
                    var col = column as PrinterImageColumn;
                    Lines.Add($"<img>{ col.Image }</img>");
                }
                else
                    throw new Exception("col type not supported");
            }
            return Lines;
        }
    }
}
