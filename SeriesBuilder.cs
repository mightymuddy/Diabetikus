using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diabetikus
{
    public class SeriesBuilder
    {
        private Series _serie = new Series();


        public SeriesBuilder UpdateSeries(Series serie)
        {
            _serie = serie;
            return this;
        }
        public SeriesBuilder Create()
        {
            _serie = new Series();
            return this;
        }
        public SeriesBuilder Name(string name)
        {
            _serie.Name = name;
            return this;
        }

        public SeriesBuilder setType(SeriesChartType chartType)
        {
            _serie.ChartType = chartType;
            return this;
        }

        public SeriesBuilder Color(Color color)
        {
            _serie.Color = color;
            return this;
        }

        public SeriesBuilder BorderWidth(int width)
        { 
            _serie.BorderWidth = width;
            return this; 
        }
        public SeriesBuilder AddPoints(DateTime[] X, double Y)
        {
            for (int i = 0; i < X.Length; i++)
                if (X[i] != null && Y != null)
                    _serie.Points.AddXY(X[i], Y);
                
            return this;
        }
        public SeriesBuilder AddPoints(DateTime[] X, double[] Y)
        {
            for (int i = 0; i < X.Length; i++)
                if (X[i] != null && Y[i] != null)
                    _serie.Points.AddXY(X[i], Y[i]);
                        
            return this;
        }

       
        public Series Build()
        {
            return _serie;
        }

        public SeriesBuilder  setValueTypeX(ChartValueType type)        
        {
            _serie.XValueType = type;
            return this;
        }

        public SeriesBuilder setValueTypeY(ChartValueType type)
        {
            _serie.YValueType = type;
            return this;
        }
    }
}
