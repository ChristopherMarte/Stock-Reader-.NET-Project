using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace COP_4365_Project_3
{
    public class smartCandlestick : candlestick
    {
        // Extra properties added to smart candlestick
        public Decimal range;
        public Decimal bodyRange;
        public Decimal topPrice;
        public Decimal bottomPrice;
        public Decimal topTail;
        public Decimal bottomTail;

        // Properties to determine patterns (threshold)
        public Decimal threshold;
        public Decimal thresholdPercent = 0.1m;

        // Single Pattern Information
        public bool bullishPattern;
        public bool bearishPattern;
        public bool neutralPattern;
        public bool marubozuPattern;
        public bool dojiPattern;
        public bool dragonflyDojiPattern;
        public bool gravestoneDojiPattern;
        public bool hammerPattern;
        public bool invertedHammerPattern;

        // Default constructor (empty)
        public smartCandlestick() { }
        // smartCandlestick constructor from a normal candlestick
        public smartCandlestick(candlestick cs) 
        { 
            this.open = cs.open;
            this.close = cs.close;
            this.date = cs.date;
            this.high = cs.high;
            this.low = cs.low;
            this.ticker = cs.ticker;
            this.volume = cs.volume;

            calculateHighLevelProperties();
            computePatterns();
        }

        // Default constructor (given ticker, date, open, high, low, close, volume)
        public smartCandlestick(string ticker, DateTime date, decimal open = 0, decimal high = 0, decimal low = 0, decimal close = 0, long volume = 0)
        {
            this.ticker = ticker;
            this.date = date;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;

            calculateHighLevelProperties();
            computePatterns();
        }

        // Constructor used when given a string representing a row of data from the file
        public smartCandlestick(string rowOfData) : base(rowOfData)
        {
            // Constructs a smartCandlestick from a string using the method from the 
            // base candlestick class

            // High level properties and patterns from the smartCandlestick class
            calculateHighLevelProperties();
            computePatterns();
        }

        //Determines if candlestick is bullish
        public bool IsBullish()
        {
            return close > open;
        }
        //Determines if candlestick is bearish
        public bool IsBearish()
        {
            return open > close;
        }
        //Determines if candlestick is neutral
        public bool IsNeutral()
        {
            return Math.Abs(close - open) <= threshold;
        }
        //Determines if candlestick is marubozu
        public bool IsMarubozu()
        {
            return bodyRange >= threshold && topTail <= threshold && bottomTail <= threshold;
        }
        //Determines if candlestick is doji
        public bool IsDoji()
        {
            return Math.Abs(close - open) <= threshold && topTail > threshold && bottomTail > threshold;
        }
        //Determines if candlestick is dragonfly doji
        public bool IsDragonflyDoji()
        {
            return IsDoji() && topTail < bottomTail;
        }
        //Determines if candlestick is gravestone doji
        public bool IsGravestoneDoji()
        {
            return IsDoji() && bottomTail < topTail;
        }
        //Determines if candlestick is hammer
        public bool IsHammer()
        {
            return IsBullish() && bottomTail > 2 * bodyRange && topTail < threshold;
        }
        //Determines if candlestick is inverted hammer
        public bool IsInvertedHammer()
        {
            return IsBearish() && topTail > 2 * bodyRange && bottomTail < threshold;
        }
        // Calculate all high level properties of a smart candlestick
        public void calculateHighLevelProperties() 
        {
            range = high - low;
            bodyRange = Math.Abs(open - close);

            topPrice = Math.Max(open, close);
            bottomPrice = Math.Min(open, close);

            topTail = high - Math.Max(open, close);
            bottomTail = Math.Min(open, close) - low;

            threshold = thresholdPercent * range;
        }
        // Computes all single candlestick patterns
        public void computePatterns() 
        {
            bullishPattern = IsBullish();
            bearishPattern = IsBearish();
            neutralPattern = IsNeutral();
            marubozuPattern = IsMarubozu();
            dojiPattern = IsDoji();
            dragonflyDojiPattern = IsDragonflyDoji();
            gravestoneDojiPattern = IsGravestoneDoji();
            hammerPattern = IsHammer();
            invertedHammerPattern = IsInvertedHammer();
        }
    }
}
