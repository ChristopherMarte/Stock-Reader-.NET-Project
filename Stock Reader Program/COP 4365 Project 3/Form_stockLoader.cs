using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COP_4365_Project_3
{
    public partial class Form_stockLoader : Form
    {
        // List<smartCandlestick> tempList = new List<smartCandlestick>(1024);
        // Default constructor
        public Form_stockLoader()
        {
            InitializeComponent();
        }
        // Load form
        private void Form_stockLoader_Load(object sender, EventArgs e)
        {

        }
        // Display open file dialog on button click
        private void button_loadStock_Click(object sender, EventArgs e)
        {
            openFileDialog_stockLoader.ShowDialog();
        }
        // If result == OK, display all the selected stocks in new form
        private void openFileDialog_stockLoader_FileOk(object sender, CancelEventArgs e)
        {
            // Store filenames and load stocks from files
            string[] files = openFileDialog_stockLoader.FileNames;
            List<List<smartCandlestick>> listOfStockData = loadStocks(files);
            displayStocks(files, listOfStockData);
        }
        // Convert array of strings into list of strings and call function again with a list
        private List<List<smartCandlestick>> loadStocks(string[] filenames)
        {
            List<string> listOfFilenames = filenames.ToList<string>();
            return loadStocks(listOfFilenames);
        }
        // Load stock data from list of files
        private List<List<smartCandlestick>> loadStocks(List<string> filenames)
        {
            List<List<smartCandlestick>> listOfListsOfScs = new List<List<smartCandlestick>>(openFileDialog_stockLoader.FileNames.Count());
            
            // Clear list to make sure it is empty 

            foreach (string filename in filenames)
            {
                // Clear list to make sure it is empty 
                List <smartCandlestick> tempList = new List<smartCandlestick>(1024);
                String referenceString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

                String fn = filename;
                Text = fn;
                String line;

                // We read the first line and compare to our reference string
                using (StreamReader sr = new StreamReader(fn))
                {


                    string header = sr.ReadLine();
                    if (header == referenceString)
                    {
                        // If file is valid (reference string == header), we read the entire file and contruct candlesticks
                        // from the data using the entire string as the input for the candlestick constructor. After we create
                        // the candlestick, we store it in the tempList
                        while ((line = sr.ReadLine()) != null)
                        {
                            smartCandlestick Scs = new smartCandlestick(line);
                            tempList.Add(Scs);
                        }
                        // Reverse the tempList to have the correct order (data is read in from most recent to oldest)
                        tempList.Reverse();
                        listOfListsOfScs.Add(tempList);
                    }
                }


            }

            return listOfListsOfScs;
        }
        // Create new form and pass all the data needed to display the charts
        public void displayStocks(string[] files, List<List<smartCandlestick>> allCandlesticks) 
        {
            // Iterate over all files in array of files
            for (int i = 0; i < files.Count(); i++) 
            { 
                // Data to be passed to new form
                string ticker = Path.GetFileNameWithoutExtension(files[i]);
                List<smartCandlestick> listOfScs = allCandlesticks[i];

                DateTime startDate = dateTimePicker_startDate.Value;
                DateTime endDate = dateTimePicker_endDate.Value;
                
                // Create new form and show it
                Form_displayCharts displayCharts = new Form_displayCharts(startDate, endDate, listOfScs, ticker);
                displayCharts.Show();
            }
        }
    }
}
