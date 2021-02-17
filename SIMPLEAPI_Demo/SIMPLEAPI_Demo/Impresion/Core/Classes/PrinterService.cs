using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace SIMPLEAPI_Demo.Impresion.Core.Classes
{
    public class PrinterService
    {
        List<Font> Fonts { get; set; }
        List<SolidBrush> BrushesPallete { get; set; }
        PrinterWork Work { get; set; }

        enum WrapResolve
        {
            Truncate = 0,
            Wrap = 1
        }

        public PrinterService(PrinterWork work)
        {
            this.Work = work;
            BrushesPallete = new List<SolidBrush>();
            Fonts = new List<Font>();
        }

        /// <summary>
        /// Printer previously generated PrinterWork
        /// </summary>
        /// <param name="documentName">Nombre del documento a imprimir.</param>
        /// <param name="printerName"></param>
        /// <param name="debugMode"></param>
        public void Print(string documentName, string printerName, bool debugMode = false)
        {
            if (string.IsNullOrEmpty(documentName))
                throw new ArgumentException("El parámetro 'documentName' no puede ser 'null' o estar vacío", documentName);

            if (string.IsNullOrEmpty(printerName))
                throw new ArgumentException("El parámetro 'printerName' no puede ser 'null' o estar vacío", printerName);

            if (Work == null)
                throw new ArgumentException("No se puede imprimir si la propiedad 'Work' es null", printerName);

            if (Work.Rows.Count == 0)
                return;

            PrintDocument pdoc = new PrintDocument();
            pdoc.DocumentName = documentName;
            if (!debugMode)
                pdoc.PrintController = new StandardPrintController(); // hides status dialog popup

            pdoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 100, 200);
            pdoc.DefaultPageSettings.PaperSize.Height = Work.Rows.Count * 24; // Aprox
            pdoc.DefaultPageSettings.PaperSize.Width = 300;
            pdoc.PrintPage += new PrintPageEventHandler(PrintEvent);

            if (!debugMode)
            {
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = printerName;
                pdoc.PrinterSettings = ps;
                pdoc.Print();
            }
            else
            {
                PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                printPrvDlg.Document = pdoc;
                printPrvDlg.Width = 1200;
                printPrvDlg.Height = 800;
                printPrvDlg.ShowDialog();
            }
        }
        private void PrintEvent(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            SolidBrush brush;
            Font font;

            int currentY = 0;

            foreach (var row in Work.Rows)
            {
                brush = GetBrush(row.Color);
                font = GetFont(row.FontSize, row.IsBold);

                // Kind of excesive but will throw an exception if sums of width percentages of all row colums is not 1
                row.ValidateColumnsWidth(Work.IsTestWork);

                foreach (var line in row.ToLines())
                {
                    if (line.StartsWith("<img>") && line.EndsWith("</img>"))
                    {
                        var col = row.Columns.First() as PrinterImageColumn;

                        graphics.DrawImage(col.Image, 0, currentY, 290, 120);
                        currentY += 120;
                        break;
                    }
                    else
                    {
                        graphics.DrawString(line, font, brush, 0, currentY);
                        currentY += (int)font.GetHeight();
                    }
                }
            }
        }

        #region Helpers

        private Font GetFont(float size, bool isBold)
        {
            var font = Fonts.FirstOrDefault(x => x.Size == size && (isBold ? x.Style == FontStyle.Bold : x.Style == FontStyle.Regular));
            if (font == null)
            {
                font = new Font(FontInfo.FontName, size, (isBold ? FontStyle.Bold : FontStyle.Regular));
                Fonts.Add(font);
            }
            return font;
        }

        private SolidBrush GetBrush(Color color)
        {
            var brush = BrushesPallete.FirstOrDefault(x => x.Color == color);
            if (brush == null)
            {
                brush = new SolidBrush(color);
                BrushesPallete.Add(new SolidBrush(color));
            }
            return brush;
        }

        #endregion
    }
}
