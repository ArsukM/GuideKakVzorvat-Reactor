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
using System.Security.Policy;
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

            chart1.Series["Температура"].Points.Clear();
            chart1.Series["Норма"].Points.Clear();

            chart2.Series["Уровень воды"].Points.Clear();
            chart2.Series["Норма"].Points.Clear();

            chart3.Series["Радиация"].Points.Clear();
            chart3.Series["Норма"].Points.Clear();
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
            historyRichTB.Text = response;
            reactorResponse reactor = JsonConvert.DeserializeObject<reactorResponse>(response);
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            double temperature = reactor.data.reactor_state.temperature;
            double water_level = reactor.data.reactor_state.water_level;
            double radiation = reactor.data.reactor_state.radiation;

            DataTable table = new DataTable();
            table.Columns.Add("Параметр", typeof(string));
            table.Columns.Add("Значение", typeof(string));

            table.Rows.Add("Время", currentTime);
            table.Rows.Add("Температура", Math.Round(temperature, 2));
            table.Rows.Add("Уровень воды", Math.Round(water_level, 2));
            table.Rows.Add("Радиация", Math.Round(radiation, 2));

            paramTableDGV.DataSource = table;
            UpdateCharts(currentTime, temperature, water_level, radiation);

            if (temperature >= 1200)
            {
                paramTableDGV.Rows[1].DefaultCellStyle.BackColor = Color.Red;
                if (temperature >= 1280)
                {
                    try
                    {
                        string url1 = $"https://mephi.opentoshi.net/api/v1/reactor/emergency-shutdown?team_id=e27df733";
                        HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create(url1);
                        req1.Method = "POST";

                        using (HttpWebResponse response1 = (HttpWebResponse)req1.GetResponse())
                        using (StreamReader sr1 = new StreamReader(response1.GetResponseStream()))
                        {
                            string res1 = sr1.ReadToEnd();
                            Console.WriteLine(res1);
                        };
                            MessageBox.Show("Произошла аварийная остановка реактора");
                    }
                    catch
                    {

                    } ;
                }
            }
            else
                paramTableDGV.Rows[1].DefaultCellStyle.BackColor = DefaultBackColor;

            if (water_level == 0)
                paramTableDGV.Rows[2].DefaultCellStyle.BackColor = Color.Red;
            else
                paramTableDGV.Rows[2].DefaultCellStyle.BackColor = DefaultBackColor;

            if (radiation >= 150)
                paramTableDGV.Rows[3].DefaultCellStyle.BackColor = Color.Red;
            else
                paramTableDGV.Rows[3].DefaultCellStyle.BackColor = DefaultBackColor;



        }
        private void UpdateCharts(string time, double temp, double water, double rad)
        {
            chart1.Series["Температура"].Points.AddY(temp);
            chart2.Series["Уровень воды"].Points.AddY(water);
            chart3.Series["Радиация"].Points.AddY(rad);

            if (chart1.Series["Температура"].Points.Count > 50)
            {
                chart1.Series["Температура"].Points.RemoveAt(0);
                chart2.Series["Уровень воды"].Points.RemoveAt(0);
                chart3.Series["Радиация"].Points.RemoveAt(0);
            }
        }
        private void SetupTimer()
        {
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
            DGVLoad();

        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LoadDataFromJson();
        }
        private void InitializeDataAndChart()
        {
            dataTable = new DataTable();

            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("Температура", typeof(double));
            dataTable.Columns.Add("Уровень воды", typeof(double));
            dataTable.Columns.Add("Радиация", typeof(int));

            paramTableDGV.DataSource = dataTable;
            paramTableDGV.AllowUserToAddRows = false;
            paramTableDGV.ReadOnly = true;

            chart1.ChartAreas[0].AxisY.Maximum = 1350;
            chart2.ChartAreas[0].AxisY.Maximum = 100;
            chart3.ChartAreas[0].AxisY.Maximum = 250;


            //ТЕМПЕРАТУРА

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Время";
            chart1.ChartAreas[0].AxisY.Title = "Значения";

            var seriesTemp = chart1.Series.Add("Температура");
            seriesTemp.ChartType = SeriesChartType.Line;
            seriesTemp.Color = Color.Red;
            seriesTemp.BorderWidth = 2;
            seriesTemp.XValueMember = "Time";
            seriesTemp.YValueMembers = "Температура";

            //ВОДА

            chart2.Series.Clear();
            chart2.ChartAreas[0].AxisX.Title = "Время";
            chart2.ChartAreas[0].AxisY.Title = "Значения";

            var seriesWater = chart2.Series.Add("Уровень воды");
            seriesWater.ChartType = SeriesChartType.Line;
            seriesWater.Color = Color.Blue;
            seriesWater.BorderWidth = 2;
            seriesWater.XValueMember = "Time";
            seriesWater.YValueMembers = "Уровень воды";

            //РАДИАЦИЯ

            chart3.Series.Clear();
            chart3.ChartAreas[0].AxisX.Title = "Время";
            chart3.ChartAreas[0].AxisY.Title = "Значения";

            var seriesRad = chart3.Series.Add("Радиация");
            seriesRad.ChartType = SeriesChartType.Line;
            seriesRad.Color = Color.Green;
            seriesRad.BorderWidth = 2;
            seriesRad.XValueMember = "Time";
            seriesRad.YValueMembers = "Радиация";

            //НОРМА ДЛЯ ВСЕХ-ВСЕХ

            var seriesNormC = chart1.Series.Add("Норма");
            seriesNormC.ChartType = SeriesChartType.Line;
            seriesNormC.Color = Color.DarkRed;
            seriesNormC.BorderWidth = 2;
            seriesNormC.XValueMember = "Time";
            seriesNormC.YValueMembers = "NormTemp";

            var seriesNormWhater = chart2.Series.Add("Норма");
            seriesNormWhater.ChartType = SeriesChartType.Line;
            seriesNormWhater.Color = Color.DarkRed;
            seriesNormWhater.BorderWidth = 2;
            seriesNormWhater.XValueMember = "Time";
            seriesNormWhater.YValueMembers = "NormWater";

            var seriesNormRad = chart3.Series.Add("Норма");
            seriesNormRad.ChartType = SeriesChartType.Line;
            seriesNormRad.Color = Color.DarkRed;
            seriesNormRad.BorderWidth = 2;
            seriesNormRad.XValueMember = "Time";
            seriesNormRad.YValueMembers = "NormRad";

            //легенда

            var legendC = chart1.Legends.Add("MainLegend");
            legendC.Docking = Docking.Right;
            legendC.Font = new Font("Segoe UI", 9);

            var legendWhater = chart2.Legends.Add("MainLegend");
            legendWhater.Docking = Docking.Right;
            legendWhater.Font = new Font("Segoe UI", 9);

            var legendRad = chart3.Legends.Add("MainLegend");
            legendRad.Docking = Docking.Right;
            legendRad.Font = new Font("Segoe UI", 9);
        }

        private void LoadDataFromJson()
        {
            try
            {
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
            foreach (DataRow row in dataTable.Rows)
            {
                string time = row["Time"].ToString();
                double temp = Convert.ToDouble(row["Температура"]);
                double water = Convert.ToDouble(row["Уровень воды"]);
                double rad = Convert.ToDouble(row["Радиация"]);
                int NormTemp = 1180; // <=
                int NormWater = 40; // >=
                int NormRad = 290; // <=

                chart1.Series["Температура"].Points.AddXY(time, temp);
                chart1.Series["Норма"].Points.AddXY(time, NormTemp);

                chart2.Series["Уровень воды"].Points.AddXY(time, water);
                chart2.Series["Норма"].Points.AddXY(time, NormWater);

                chart3.Series["Радиация"].Points.AddXY(time, rad);
                chart3.Series["Норма"].Points.AddXY(time, NormRad);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
            chart2.ChartAreas[0].RecalculateAxesScale();
            chart3.ChartAreas[0].RecalculateAxesScale();
        }
    }

}
