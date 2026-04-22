using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    public partial class controlPanelForm : Form
    {
        public controlPanelForm()
        {
           
            InitializeComponent();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            HttpClient HC = new HttpClient();
            ReactorRepository.GetAsync(HC);
            var infoForm = new infoForm();
            infoForm.ShowDialog();
        }
    }
}
