using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEndPoints.GenerarJson
{
    public partial class JsonEnvio : Form
    {
        string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonEnvio"];

        public JsonEnvio()
        {
            InitializeComponent();
        }

        private async void JsonEnvio_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            txt_jsonEnvio.Text = response;
        }
        
    }
}
