using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class controlPanelForm : Form
    {
        Reactor testReactor = new Reactor(0,0,0);
        private DataTable dataTable;
        public controlPanelForm()
        {
            InitializeComponent();
            InitializeDataAndChart();
            SetupTimer();
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
            var refillForm = new RefillWaterForm();
            refillForm.ShowDialog();
        }
        private void coolingBtn_Click(object sender, EventArgs e)
        {
            var coolingForm = new CoolingForm();
            coolingForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVLoad();
        }

        public void DGVLoad()
        {
            string url = "https://mephi.opentoshi.net/api/v1/reactor/data?team_id=e27df733";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            string neww = res.StatusCode.ToString();
            string response = sr.ReadToEnd();
            reactorResponse reactor = JsonConvert.DeserializeObject<reactorResponse>(response);
            double temperature = reactor.data.reactor_state.temperature;
            double water_level = reactor.data.reactor_state.water_level;
            double radiation = reactor.data.reactor_state.radiation;

            DataTable table = new DataTable();
            table.Columns.Add("Параметр", typeof(string));
            table.Columns.Add("Значение", typeof(string));

            table.Rows.Add("Температура", Math.Round(temperature, 2));
            table.Rows.Add("Уровень воды", Math.Round(water_level, 2));
            table.Rows.Add("Радиация", Math.Round(radiation, 2));

            paramTableDGV.DataSource = table;
        }
        private void SetupTimer()
        {
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LoadDataFromJson();
        }
        private void InitializeDataAndChart()
        {
            dataTable = new DataTable();

            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("Temperature", typeof(double));
            dataTable.Columns.Add("WaterLevel", typeof(double));
            dataTable.Columns.Add("Radiation", typeof(int));

            paramTableDGV.DataSource = dataTable;
            paramTableDGV.AllowUserToAddRows = false;
            paramTableDGV.ReadOnly = true;

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Время";
            chart1.ChartAreas[0].AxisY.Title = "Значения";

            var seriesTemp = chart1.Series.Add("Температура");
            seriesTemp.ChartType = SeriesChartType.Line;
            seriesTemp.Color = Color.Red;
            seriesTemp.BorderWidth = 2;
            seriesTemp.XValueMember = "Time";
            seriesTemp.YValueMembers = "Temperature";

            var seriesWater = chart1.Series.Add("Уровень воды");
            seriesWater.ChartType = SeriesChartType.Line;
            seriesWater.Color = Color.Blue;
            seriesWater.BorderWidth = 2;
            seriesWater.XValueMember = "Time";
            seriesWater.YValueMembers = "WaterLevel";

            var seriesRad = chart1.Series.Add("Радиация");
            seriesRad.ChartType = SeriesChartType.Line;
            seriesRad.Color = Color.Green;
            seriesRad.BorderWidth = 2;
            seriesRad.XValueMember = "Time";
            seriesRad.YValueMembers = "Radiation";

            var seriesNorm = chart1.Series.Add("НОРМА!");
            seriesNorm.ChartType = SeriesChartType.Line;
            seriesNorm.Color = Color.DarkRed;
            seriesNorm.BorderWidth = 2;
            seriesNorm.XValueMember = "Time";
            seriesNorm.YValueMembers = "Norm";

            var legend = chart1.Legends.Add("MainLegend");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 9);
        }

        private void LoadDataFromJson()
        {
            try
            {
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                DGVLoad();
                UpdateChartFromGrid();
            }
            catch (Exception ex)
            {
                updateTimer.Stop();
                MessageBox.Show("Ошибка чтения данных: " + ex.Message);
            }
        }
        private void UpdateChartFromGrid()
        {
            chart1.Series["Температура"].Points.Clear();
            chart1.Series["Уровень воды"].Points.Clear();
            chart1.Series["Радиация"].Points.Clear();
            chart1.Series["НОРМА!"].Points.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                string time = row["Time"].ToString();
                double temp = Convert.ToDouble(row["Temperature"]);
                double water = Convert.ToDouble(row["WaterLevel"]);
                int radiation = Convert.ToInt32(row["Radiation"]);
                int Norm = 290;

                chart1.Series["Температура"].Points.AddXY(time, temp);
                chart1.Series["Уровень воды"].Points.AddXY(time, water);
                chart1.Series["Радиация"].Points.AddXY(time, radiation);
                chart1.Series["НОРМА!"].Points.AddXY(time, Norm);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }
    }

}
