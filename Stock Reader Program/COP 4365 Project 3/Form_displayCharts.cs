using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP_4365_Project_3
{
    public partial class Form_displayCharts : Form
    {
        public List<Recognizer> listOfRecognizers = new List<Recognizer>();
        // List of all stored candlesticks
        public List<smartCandlestick> listOfAllScs { get; private set; }
        // Name of file
        public string filename { get; private set; }
        // Binding list of candlesticks for graph 
        public BindingList <smartCandlestick> candlesticks { get; private set; }
        //Default constructor of chart
        public Form_displayCharts()
        {
            InitializeComponent();
        }
        // Constructor that takes in a start and end date, a list of candlesticks, and the ticker file
        public Form_displayCharts(DateTime startDate, DateTime endDate, List<smartCandlestick> smartCsList, string ticker)
        {
            InitializeComponent();

            // Copy all arguments into their respective global variables 
            filename = ticker;

            // Add title of chart
            chart_stockData.Titles.Add(Path.GetFileNameWithoutExtension(ticker));

            // Set dates of date time pickers to given arguments
            dateTimePicker_startDate.Value = startDate;
            dateTimePicker_endDate.Value = endDate;

            // Store copy of candlestick list
            listOfAllScs = smartCsList;

            // Create list of recognizers
            listOfRecognizers.Add(new PeakRecognizer());
            listOfRecognizers.Add(new ValleyRecognizer());
            listOfRecognizers.Add(new DojiRecognizer());
            listOfRecognizers.Add(new GravestoneDojiRecognizer());
            listOfRecognizers.Add(new DragonflyDojiRecognizer());
            listOfRecognizers.Add(new NeutralRecognizer());
            listOfRecognizers.Add(new HammerRecognizer());
            listOfRecognizers.Add(new InvertedHammerRecognizer());
            listOfRecognizers.Add(new MarubozuRecognizer());
            listOfRecognizers.Add(new BullishRecognizer());
            listOfRecognizers.Add(new BearishRecognizer());
            listOfRecognizers.Add(new EngulfingBearishRecognizer());
            listOfRecognizers.Add(new EngulfingBullishRecognizer());
            listOfRecognizers.Add(new BullishHaramiRecognizer());
            listOfRecognizers.Add(new BearishHaramiRecognizer());

            comboBox_pattern.Items.Add("None");

            // Add all recognizers to the combo box
            foreach(Recognizer r in listOfRecognizers) 
            {
                comboBox_pattern.Items.Add(r.patternName);
            }

            // Filter all candlesticks
            filterCandlesticks();

        }
        // Form load function
        private void Form_displayCharts_Load(object sender, EventArgs e)
        {

        }

        // Function to filter the candlesticks based on the desired date range from dateTimePickers
        private void filterCandlesticks()
        {
            // If list is not empty proceed to filter
            if (listOfAllScs.Count != 0)
            {
                candlesticks = new BindingList<smartCandlestick>();
                // Filter candlesticks and only add those in valid date range to binding list
                foreach (smartCandlestick Scs in listOfAllScs)
                {
                    if (Scs.date > dateTimePicker_endDate.Value)
                        break;
                    if (Scs.date >= dateTimePicker_startDate.Value)
                        candlesticks.Add(Scs);
                }

                // Bind the data from the candlesticks list to the chart
                chart_stockData.DataSource = candlesticks;
                chart_stockData.DataBind();

                // Resize axes based of both volume and candlestick chart
                chart_stockData.ChartAreas[1].RecalculateAxesScale();

                // Get Y-axis minimum and maximum values to resize the chart
                double minY = (double)candlesticks.Min(Scs => Scs.low);
                double maxY = (double)candlesticks.Max(Scs => Scs.high);

                // Set minimum values to 10% below or above min and max
                chart_stockData.ChartAreas[0].AxisY.Minimum = minY - 0.1 * (maxY - minY);
                chart_stockData.ChartAreas[0].AxisY.Maximum = maxY + 0.1 * (maxY - minY);
                chart_stockData.ChartAreas[0].AxisY.LabelStyle.Format = "0.0";

                // Update annotations based on current range of candlesticks
                if (comboBox_pattern.SelectedItem != null)
                {
                    string selectedPattern = comboBox_pattern.SelectedItem.ToString();
                    DisplayAnnotations(selectedPattern);
                }
            }
        }
        // Update candlesticks based on dates when pressed
        private void button_update_Click(object sender, EventArgs e)
        {
            filterCandlesticks();
        }
        // Function used to create and display all pattern annotations
        private void DisplayAnnotations(string selectedPattern)
        {
            // Clear for new annotations
            chart_stockData.Annotations.Clear();

            if (comboBox_pattern.SelectedIndex > 0) {

                // Check for the desired recognizer from the combo box index
                Recognizer r = listOfRecognizers[comboBox_pattern.SelectedIndex - 1];

                if (r.patternName == selectedPattern)
                {
                    List<int> indexes = r.Recognize(candlesticks.ToList());


                    // Create and display the annotations if they match the selected pattern from combo box
                    foreach (int index in indexes)
                    {
                        // Display annotation with background color
                        var annotation = new RectangleAnnotation();
                        annotation.Text = selectedPattern;
                        annotation.BackColor = Color.Cyan;

                        // Anchor annotation to data point
                        if (r.patternSize > 1)
                        {
                            annotation.AnchorDataPoint = chart_stockData.Series[0].Points[index - 1];
                        }
                        else 
                        {
                            annotation.AnchorDataPoint = chart_stockData.Series[0].Points[index];
                        }
                        chart_stockData.Annotations.Add(annotation);
                        chart_stockData.Refresh();
                    }
                }
            }
        }
        // Update annotation when combo box detects pattern change
        private void comboBox_pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_pattern.SelectedItem != null)
            {
                string selectedPattern = comboBox_pattern.SelectedItem.ToString();
                DisplayAnnotations(selectedPattern);
            }
        }
    }
}
