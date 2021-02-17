using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPLEAPI_Demo.Impresion.Core.Classes
{
    public class PrinterWork
    {
        public bool IsTestWork { get; set; }

        public List<PrinterRow> Rows { get; private set; }

        public PrinterWork()
        {
            Rows = new List<PrinterRow>();
        }

        public void AddRow(PrinterRow row)
        {
            Rows.Add(row);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var row in Rows)
                string.Join("||",
                    row
                    .Columns
                    .Select(x =>
                        x is PrinterTextColumn ? (x as PrinterTextColumn).Text :
                        x is PrinterImageColumn ? "{ Image }" :
                        x.GetType().Name
                    ));

            return sb.ToString();
        }

        public List<string> ToLines()
        {
            var Lines = new List<string>();
            foreach (var row in Rows)
                Lines.AddRange(row.ToLines());

            //var linesStrng = string.Join(Environment.NewLine, Lines);

            return Lines;
        }
    }
}
