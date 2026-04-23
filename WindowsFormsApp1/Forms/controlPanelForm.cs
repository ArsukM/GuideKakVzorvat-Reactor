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
using WindowsFormsApp1.WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class controlPanelForm : Form
    {
        Reactor testReactor = new Reactor(0,0,0);
        public controlPanelForm()
        {
            InitializeComponent();
        }

        private async void controlPanelForm_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            try
            {

                var HC = new HttpClient();
                await ReactorRepository.GetReactorAsync(HC, testReactor);
                //ReactorRepository.JsonToDGV(testReactor);
            }
            catch
            {
                table = CreateFallbackTable();
            }

            paramTableDGV.DataSource = table;
            paramTableDGV.AutoResizeColumns();
            paramTableDGV.ReadOnly = true;
            paramTableDGV.AllowUserToAddRows = false;
        }

        private DataTable CreateFallbackTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Параметр", typeof(string));
            table.Columns.Add("Значение", typeof(string));

            table.Rows.Add("Температура", "ауауау");
            table.Rows.Add("Уровень воды", "ауауау");
            table.Rows.Add("Радиация", "ауауау");

            return table;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            var infoForm = new infoForm();
            infoForm.ShowDialog();
        }

        private void waterBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
