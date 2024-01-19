using COP_4365_Project_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_Project_3
{
    // Base recognizer class
    public abstract class Recognizer
    {
        // Recognizer variables
        public int patternSize;
        public string patternName;
        // Default constructor
        public Recognizer() { }
        // Set the pattern name and size
        public Recognizer(string pn, int ps)
        {
            patternName = pn;
            patternSize = ps;
        }
        // Create list of indices from the given list of smartCandlesticks
        public List<int> Recognize(List<smartCandlestick> Lscs)
        {
            List<int> result = new List<int>(Lscs.Count());
            for (int i = patternSize - 1; i < Lscs.Count(); i++)
            {
                List<smartCandlestick> sublist = Lscs.GetRange(i-patternSize+1, patternSize);
                if (recognizePattern(sublist))
                {
                    result.Add(i);
                }
            }

            return result;
        }
        // Virtual function to be overriden by each child class
        public virtual bool recognizePattern(List<smartCandlestick> Lscs) 
        {
            return false;
        }

    }
    // Recognizer for Peak pattern
    class PeakRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public PeakRecognizer() : base("Peak",3) { } 
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs) 
        { 
            smartCandlestick s0 = Lscs[0];
            smartCandlestick s1 = Lscs[1];
            smartCandlestick s2 = Lscs[2];

            return (s1.high > s0.high) && (s1.high > s2.high);
        }
    }
    // Recognizer for Valley pattern
    class ValleyRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public ValleyRecognizer() : base("Valley", 3) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            smartCandlestick s1 = Lscs[1];
            smartCandlestick s2 = Lscs[2];

            return (s1.low < s0.low) && (s1.low < s2.low);
        }
    }
    // Recognizer for Doji Pattern
    class DojiRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public DojiRecognizer() : base("Doji", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.dojiPattern;
        }
    }
    // Recognizer for DragonflyDoji pattern
    class DragonflyDojiRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public DragonflyDojiRecognizer() : base("DragonflyDoji", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.dragonflyDojiPattern;
        }
    }
    // Recognizer for Neutral pattern
    class NeutralRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public NeutralRecognizer() : base("Neutral", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.neutralPattern;
        }
    }
    // Recognizer for Hammer pattern
    class HammerRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public HammerRecognizer() : base("Hammer", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.hammerPattern;
        }
    }
    // Recognizer for Inverted Hammer pattern
    class InvertedHammerRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public InvertedHammerRecognizer() : base("InvertedHammer", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.invertedHammerPattern;
        }
    }
    // Recognizer for Bullish pattern
    class BullishRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public BullishRecognizer() : base("Bullish", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.bullishPattern;
        }
    }
    // Recognizer for Bearish pattern
    class BearishRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public BearishRecognizer() : base("Bearish", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.bearishPattern;
        }
    }
    // Recognizer for GravestoneDoji pattern
    class GravestoneDojiRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public GravestoneDojiRecognizer() : base("GravestoneDoji", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.gravestoneDojiPattern;
        }
    }
    // Recognizer for Marubozu pattern
    class MarubozuRecognizer : Recognizer 
    {
        // Call default constructor from base class and set pattern name and size
        public MarubozuRecognizer() : base("Marubozu", 1) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            return s0.marubozuPattern;
        }
    }
    // Recognizer for EngulfingBullish pattern
    class EngulfingBullishRecognizer : Recognizer
    {
        // Call default constructor from base class and set pattern name and size
        public EngulfingBullishRecognizer() : base("EngulfingBullish", 2) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            smartCandlestick s1 = Lscs[1];

            return s0.bearishPattern && s1.bullishPattern && s1.range > s0.range && s0.bodyRange < s1.bodyRange;
        }
    }
    // Recognizer for EngulfingBearish pattern
    class EngulfingBearishRecognizer : Recognizer
    {
        // Call default constructor from base class and set pattern name and size
        public EngulfingBearishRecognizer() : base("EngulfingBearish", 2) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            smartCandlestick s1 = Lscs[1];

            return s0.bullishPattern && s1.bearishPattern && s1.range > s0.range && s0.bodyRange < s1.bodyRange;
        }
    }
    // Recognizer for BearishHarami pattern
    class BearishHaramiRecognizer : Recognizer
    {
        // Call default constructor from base class and set pattern name and size
        public BearishHaramiRecognizer() : base("BearishHarami", 2) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            smartCandlestick s1 = Lscs[1];

            return s0.bullishPattern && s1.bearishPattern && s0.range > s1.range && s0.bodyRange > s1.bodyRange;
        }
    }
    // Recognizer for BullishHarami pattern
    class BullishHaramiRecognizer : Recognizer
    {
        // Call default constructor from base class and set pattern name and size
        public BullishHaramiRecognizer() : base("BullishHarami", 2) { }
        // Override the recognize pattern function to be able to recognize the desired pattern
        public override bool recognizePattern(List<smartCandlestick> Lscs)
        {
            smartCandlestick s0 = Lscs[0];
            smartCandlestick s1 = Lscs[1];

            return s0.bearishPattern && s1.bullishPattern && s0.range > s1.range && s0.bodyRange > s1.bodyRange;
        }
    }
}