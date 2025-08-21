using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diabetikus
{
    public class ChartBuilder
    {
        private Chart _charts = new Chart();

        public ChartBuilder Create(Chart chart) 
        {
            _charts = chart;
            _charts.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            return this;
        }
        public ChartBuilder AddSeries(Series serie)
        {
            _charts.Series.Add(serie);
            _charts.Legends[0].Enabled = false;
            return this;
        }

        public ChartBuilder BackColor(Color color) 
        {
            _charts.BackColor = color;
            return this;
        }

        public ChartBuilder setMax(double maxX, double maxY)
        {
            _charts.ChartAreas[0].AxisX.Maximum = maxX;
            _charts.ChartAreas[0].AxisY.Maximum = maxY;
            return this;
        }

        public ChartBuilder setMin(double minX, double minY)
        {
            _charts.ChartAreas[0].AxisX.Minimum = minX;
            _charts.ChartAreas[0].AxisY.Minimum = minY;
            return this;
        }

        public ChartBuilder setAxisTitleX(string titleX, Font font, StringAlignment alignment)
        {
            _charts.ChartAreas[0].AxisX.Title = titleX;
            _charts.ChartAreas[0].AxisX.TitleFont = font;
            _charts.ChartAreas[0].AxisX.TitleAlignment = alignment;    
            return this;
        }

        public ChartBuilder setAxisTitleY(string titleY, Font font, StringAlignment alignment)
        {
            _charts.ChartAreas[0].AxisY.Title = titleY;
            _charts.ChartAreas[0].AxisY.TitleFont = font;
            _charts.ChartAreas[0].AxisY.TitleAlignment = alignment;
            return this;
        }


        public Chart Build()
        {
            return _charts;
        }

        public ChartBuilder setLabelStyleX(string v)
        {
            _charts.ChartAreas[0].AxisX.LabelStyle.Format = v;
            return this;
        }

        public ChartBuilder setLabelStyleY(string v)
        {
            _charts.ChartAreas[0].AxisY.LabelStyle.Format = v;
            return this;
        }

        public ChartBuilder setAngle(int v)
        {
            _charts.ChartAreas[0].AxisX.LabelStyle.Angle = v;
            return this;
        }

        public ChartBuilder setInterval(double v1, double v2)
        {
            _charts.ChartAreas[0].AxisX.Interval = v1;
            _charts.ChartAreas[0].AxisY.Interval = v2;
            return this;
        }

        public ChartBuilder setMaximumAutoSize(int v1, int v2)
        {
            _charts.ChartAreas[0].AxisX.MaximumAutoSize = v1;
            _charts.ChartAreas[0].AxisY.MaximumAutoSize = v2;
            return this;
        }
    }
}
