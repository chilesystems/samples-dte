using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEndPoints.GenerarJson
{
    public partial class JsonPdf : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonPdf"];

        public JsonPdf()
        {
            InitializeComponent();
        }

        private async void JsonPdf_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            txt_jsonPdf.Text = response;
        }
    }
}
