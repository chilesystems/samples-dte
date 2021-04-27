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

namespace DemoEndPoints.GenerarJson
{
    public partial class JsonEntrada : Form
    {
        public JsonEntrada()
        {
            InitializeComponent();
        }

        private async void JsonEntrada_Load(object sender, EventArgs e)
        {
            string res = await jsonEntrada();
            txt_jsonEntrada.Text = res;
        }
        public async Task<string> jsonEntrada()
        {
            string url = ConfigurationManager.AppSettings["url"] + ConfigurationManager.AppSettings["JsonEntrada"];
            Helper h = new Helper();
            return await h.Json(url);
        }

    }
}
