using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CoolingForm : Form
    {
        public CoolingForm()
        {
            InitializeComponent();
        }

        private void coolingBtn_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(textBox1.Text);
            string url = $"https://mephi.opentoshi.net/api/v1/reactor/activate-cooling?team_id=e27df733&duration={amount}";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        }
    }
}
