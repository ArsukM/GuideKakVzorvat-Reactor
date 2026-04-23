namespace WindowsFormsApp1
{
    partial class controlPanelForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.waterBtn = new System.Windows.Forms.Button();
            this.coolingBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.paramTableDGV = new System.Windows.Forms.DataGridView();
            this.infoBtn = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.historyRichTB = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramTableDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // waterBtn
            // 
            this.waterBtn.Location = new System.Drawing.Point(1039, 12);
            this.waterBtn.Name = "waterBtn";
            this.waterBtn.Size = new System.Drawing.Size(136, 45);
            this.waterBtn.TabIndex = 1;
            this.waterBtn.Text = "ДОЛИВ";
            this.waterBtn.UseVisualStyleBackColor = true;
            this.waterBtn.Click += new System.EventHandler(this.waterBtn_Click);
            // 
            // coolingBtn
            // 
            this.coolingBtn.Location = new System.Drawing.Point(1039, 63);
            this.coolingBtn.Name = "coolingBtn";
            this.coolingBtn.Size = new System.Drawing.Size(136, 36);
            this.coolingBtn.TabIndex = 2;
            this.coolingBtn.Text = "ОХЛАЖДЕНИЕ";
            this.coolingBtn.UseVisualStyleBackColor = true;
            this.coolingBtn.Click += new System.EventHandler(this.coolingBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(1039, 105);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(136, 54);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "ВЫХОД";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // chart1
            // 
            chartArea10.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chart1.Legends.Add(legend10);
            this.chart1.Location = new System.Drawing.Point(14, 12);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(332, 373);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea11.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart2.Legends.Add(legend11);
            this.chart2.Location = new System.Drawing.Point(347, 12);
            this.chart2.Name = "chart2";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart2.Series.Add(series11);
            this.chart2.Size = new System.Drawing.Size(341, 373);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea12.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chart3.Legends.Add(legend12);
            this.chart3.Location = new System.Drawing.Point(694, 12);
            this.chart3.Name = "chart3";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chart3.Series.Add(series12);
            this.chart3.Size = new System.Drawing.Size(339, 373);
            this.chart3.TabIndex = 6;
            this.chart3.Text = "chart3";
            // 
            // paramTableDGV
            // 
            this.paramTableDGV.AllowUserToAddRows = false;
            this.paramTableDGV.AllowUserToDeleteRows = false;
            this.paramTableDGV.AllowUserToOrderColumns = true;
            this.paramTableDGV.AllowUserToResizeColumns = false;
            this.paramTableDGV.AllowUserToResizeRows = false;
            this.paramTableDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paramTableDGV.Location = new System.Drawing.Point(829, 459);
            this.paramTableDGV.Name = "paramTableDGV";
            this.paramTableDGV.RowHeadersWidth = 51;
            this.paramTableDGV.RowTemplate.Height = 24;
            this.paramTableDGV.Size = new System.Drawing.Size(337, 154);
            this.paramTableDGV.TabIndex = 7;
            // 
            // infoBtn
            // 
            this.infoBtn.Location = new System.Drawing.Point(1039, 165);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(136, 60);
            this.infoBtn.TabIndex = 8;
            this.infoBtn.Text = "СМ. ИНФУ";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // historyRichTB
            // 
            this.historyRichTB.Location = new System.Drawing.Point(14, 401);
            this.historyRichTB.Name = "historyRichTB";
            this.historyRichTB.Size = new System.Drawing.Size(809, 212);
            this.historyRichTB.TabIndex = 11;
            this.historyRichTB.Text = "";
            // 
            // controlPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 625);
            this.Controls.Add(this.historyRichTB);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.paramTableDGV);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.coolingBtn);
            this.Controls.Add(this.waterBtn);
            this.Name = "controlPanelForm";
            this.Text = "Панель управления";
            this.Load += new System.EventHandler(this.controlPanelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paramTableDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button waterBtn;
        private System.Windows.Forms.Button coolingBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataGridView paramTableDGV;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.RichTextBox historyRichTB;
    }
}

