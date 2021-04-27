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
        public JsonEnvio()
        {
            InitializeComponent();
        }

        private async void JsonEnvio_Load(object sender, EventArgs e)
        {
            string res = await jsonEnvio();
            txt_jsonEnvio.Text = res;
        }
        public  async Task<string> jsonEnvio()
        {
            string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonEnvio"];
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
    }
}
