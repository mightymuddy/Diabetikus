using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Markup;

namespace Diabetikus
{
  
    public class Statistics
    {
        private double[] _values;
        private double median;
        private double max = 0;
        private double min = double.MaxValue;

        public Statistics(double[] values) 
        {
            _values = values;
            median = calcMedian(values);
            clacMax(values);
            calcMin(values);
        }

        private double calcMedian(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum / values.Length;
        }

        private void clacMax(double[] values)
        {
            for(int i = 0; i < values.Length;i++)
                if(values[i] > max)
                    max = values[i];
        }

        private void calcMin(double[] values)
        {
            for(int i = 0;i < values.Length;i++)
                if(values[i] < min)
                    min = values[i];
        }

        public double Median
        {
           get => median;
        }

        public double Max
        {
            get => max;
        }

        public double Min
        {
            get => min;
        }

        public string[] ToStringArray()
        {
            string[] output = new string[_values.Length];
            for (int i = 0; i < _values.Length; i++)
                output[i] = _values[i].ToString();

            return output;
        }

    }
}