using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEndPoints
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_pdf417Dte_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings["url"]+ConfigurationManager.AppSettings["Pdf417Dte"];
              
        }
    }
}
