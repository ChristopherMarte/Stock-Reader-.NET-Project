namespace COP_4365_Project_3
{
    partial class Form_displayCharts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_displayCharts));
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.smartCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_update = new System.Windows.Forms.Button();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox_pattern = new System.Windows.Forms.ComboBox();
            this.label_startChart = new System.Windows.Forms.Label();
            this.label_endChart = new System.Windows.Forms.Label();
            this.label_pattern = new System.Windows.Forms.Label();
            this.label_descriptionPatterns = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartCandlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stockData
            // 
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Price";
            chartArea1.Name = "Chart_OHLC";
            chartArea2.AxisX.Title = "Date";
            chartArea2.AxisY.Title = "Volume";
            chartArea2.Name = "Chart_Volume";
            this.chart_stockData.ChartAreas.Add(chartArea1);
            this.chart_stockData.ChartAreas.Add(chartArea2);
            this.chart_stockData.DataSource = this.smartCandlestickBindingSource;
            legend1.Name = "Legend1";
            this.chart_stockData.Legends.Add(legend1);
            this.chart_stockData.Location = new System.Drawing.Point(12, 12);
            this.chart_stockData.Name = "chart_stockData";
            series1.ChartArea = "Chart_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "Chart_Volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "volume";
            this.chart_stockData.Series.Add(series1);
            this.chart_stockData.Series.Add(series2);
            this.chart_stockData.Size = new System.Drawing.Size(690, 426);
            this.chart_stockData.TabIndex = 0;
            this.chart_stockData.Text = "Stock Data";
            // 
            // smartCandlestickBindingSource
            // 
            this.smartCandlestickBindingSource.DataSource = typeof(COP_4365_Project_3.smartCandlestick);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(778, 169);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(88, 32);
            this.button_update.TabIndex = 1;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(720, 128);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_endDate.TabIndex = 2;
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(720, 74);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_startDate.TabIndex = 3;
            // 
            // comboBox_pattern
            // 
            this.comboBox_pattern.FormattingEnabled = true;
            this.comboBox_pattern.Location = new System.Drawing.Point(720, 243);
            this.comboBox_pattern.Name = "comboBox_pattern";
            this.comboBox_pattern.Size = new System.Drawing.Size(200, 21);
            this.comboBox_pattern.TabIndex = 4;
            this.comboBox_pattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_pattern_SelectedIndexChanged);
            // 
            // label_startChart
            // 
            this.label_startChart.AutoSize = true;
            this.label_startChart.Location = new System.Drawing.Point(796, 58);
            this.label_startChart.Name = "label_startChart";
            this.label_startChart.Size = new System.Drawing.Size(55, 13);
            this.label_startChart.TabIndex = 5;
            this.label_startChart.Text = "Start Date";
            // 
            // label_endChart
            // 
            this.label_endChart.AutoSize = true;
            this.label_endChart.Location = new System.Drawing.Point(796, 112);
            this.label_endChart.Name = "label_endChart";
            this.label_endChart.Size = new System.Drawing.Size(52, 13);
            this.label_endChart.TabIndex = 6;
            this.label_endChart.Text = "End Date";
            // 
            // label_pattern
            // 
            this.label_pattern.Location = new System.Drawing.Point(799, 227);
            this.label_pattern.Name = "label_pattern";
            this.label_pattern.Size = new System.Drawing.Size(52, 13);
            this.label_pattern.TabIndex = 0;
            this.label_pattern.Text = "Pattern";
            // 
            // label_descriptionPatterns
            // 
            this.label_descriptionPatterns.AutoSize = true;
            this.label_descriptionPatterns.Location = new System.Drawing.Point(717, 328);
            this.label_descriptionPatterns.Name = "label_descriptionPatterns";
            this.label_descriptionPatterns.Size = new System.Drawing.Size(206, 91);
            this.label_descriptionPatterns.TabIndex = 7;
            this.label_descriptionPatterns.Text = resources.GetString("label_descriptionPatterns.Text");
            // 
            // Form_displayCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.label_descriptionPatterns);
            this.Controls.Add(this.label_pattern);
            this.Controls.Add(this.label_endChart);
            this.Controls.Add(this.label_startChart);
            this.Controls.Add(this.comboBox_pattern);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.chart_stockData);
            this.Name = "Form_displayCharts";
            this.Text = "Stock Data";
            this.Load += new System.EventHandler(this.Form_displayCharts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartCandlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockData;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.ComboBox comboBox_pattern;
        private System.Windows.Forms.Label label_startChart;
        private System.Windows.Forms.Label label_endChart;
        private System.Windows.Forms.Label label_pattern;
        private System.Windows.Forms.BindingSource smartCandlestickBindingSource;
        private System.Windows.Forms.Label label_descriptionPatterns;
    }
}