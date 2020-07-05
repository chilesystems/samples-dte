using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermalPrinting.Core.Classes
{
    public abstract class PrinterColumn
    {
        public enum Aligns
        {
            Center,
            Right,
            Left
        }
        public Aligns Align { get; set; }

        public int MaxChars { get; set; }
    }
}
