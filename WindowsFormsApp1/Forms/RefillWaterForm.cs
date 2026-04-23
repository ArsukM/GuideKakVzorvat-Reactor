using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RefillWaterForm : Form
    {
        public RefillWaterForm()
        {
            InitializeComponent();
        }

        private void refillBtn_Click(object sender, EventArgs e)
        {
            int amount = 1;
            try
            {
                amount = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Укажи % заливаемой воды");
            }
            string url = $"https://mephi.opentoshi.net/api/v1/reactor/refill-water?team_id=e27df733&amount={amount}";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";

            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                string response = sr.ReadToEnd();
                Console.WriteLine(response);
            };

        }
    }
}
