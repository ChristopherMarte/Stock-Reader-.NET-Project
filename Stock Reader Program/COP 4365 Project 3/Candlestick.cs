using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_Project_3
{
    // Candlestick class definition that stores ticker, open, high, low, close, volume and date
    public class candlestick
    {
        // Basic constructors with getters and setters for all information stored from .csv file
        public string ticker { get; set; }
        public Decimal open { get; set; }
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal close { get; set; }
        public long volume { get; set; }
        public DateTime date { get; set; }

        // Default constructor (empty)
        public candlestick() { }

        // Default constructor (given ticker, date, open, high, low, close, volume)
        public candlestick(string ticker, DateTime date, decimal open = 0, decimal high = 0, decimal low = 0, decimal close = 0, long volume = 0)
        {
            this.ticker = ticker;
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
        }

        // Constructor used when given a string representing a row of data from the file
        public candlestick(string rowOfData)
        {
            // Define separators and separate the string, storing the result in the subs array
            char[] separators = new char[] { ',', ' ', '"', '-' };

            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Dictionary used for date parsing
            Dictionary<string, int> map = new Dictionary<string, int>();
            int i = 1;
            map.Add("Jan", i++);
            map.Add("Feb", i++);
            map.Add("Mar", i++);
            map.Add("Apr", i++);
            map.Add("May", i++);
            map.Add("Jun", i++);
            map.Add("Jul", i++);
            map.Add("Aug", i++);
            map.Add("Sep", i++);
            map.Add("Oct", i++);
            map.Add("Nov", i++);
            map.Add("Dec", i++);

            bool success = false;

            //date parsing
            int monthValue = map[subs[2]]; // Get the month value from the map
            int day = int.Parse(subs[3]);
            int year = int.Parse(subs[4]);

            // Format the date as "MM/dd/yyyy"
            string formattedDate = $"{monthValue:D2}/{day:D2}/{year}";

            // Store values from subs array in approprite parts after parsing (ex. store date in date class member)
            ticker = subs[0];

            Decimal temp;
            success = Decimal.TryParse(subs[5], out temp);
            open = temp;
            success = Decimal.TryParse(subs[6], out temp);
            high = temp;
            success = Decimal.TryParse(subs[7], out temp);
            low = temp;
            success = Decimal.TryParse(subs[8], out temp);
            close = temp;

            long tempVolume;
            success = long.TryParse(subs[9], out tempVolume);
            volume = tempVolume;

            // Set the formatted date to the date property
            date = DateTime.ParseExact(formattedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

    }
}
