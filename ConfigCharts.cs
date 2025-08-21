using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diabetikus
{
    public class ConfigCharts
    {
        static SeriesBuilder seriesBuilder = new SeriesBuilder();
        static ChartBuilder chartBuilder = new ChartBuilder();
        double[] _bloodsugar;
        double[] _mol;
        DateTime[] _dates;


        public ConfigCharts(DataGridView dgv)
        {
            _bloodsugar = setBloodsugar(dgv);
            _mol = setMol(dgv);
            _dates = setDates(dgv);
        }

        public double[] setBloodsugar(DataGridView dgv)
        {
            return dgv.Rows.Cast<DataGridViewRow>()
                            .Where(r => r.Cells["milligramm"].Value != null)
                            .Select(r => Double.Parse(r.Cells["milligramm"].Value.ToString()))
                            .ToArray();
        }

        public double[] setMol(DataGridView dgv)
        {
            return dgv.Rows.Cast<DataGridViewRow>()
                            .Where(r => r.Cells["mmol"].Value != null)
                            .Select(r => Double.Parse(r.Cells["mmol"].Value.ToString()))
                            .ToArray();
        }

        public DateTime[] setDates(DataGridView dgv)
        {
            return dgv.Rows.Cast<DataGridViewRow>()
                            .Where(r => r.Cells["Datum"].Value != null && r.Cells["Tageszeit"].Value != null)
                            .Select(r =>
                            {
                                DateTime Datum = (DateTime)r.Cells["Datum"].Value;
                                TimeSpan time = (TimeSpan)r.Cells["Tageszeit"].Value;
                                return Datum.Add(time);
                            })
                            .ToArray();
        }

        public void UpdateSeries(DataGridView dgv, Series serie, string columnType = "")
        {
            serie.Points.Clear();
            _dates = setDates(dgv);
            if (serie.Name == "Blutzucker")
            {
                _bloodsugar = setBloodsugar(dgv);
                seriesBuilder.UpdateSeries(serie)
                            .AddPoints(_dates, _bloodsugar);
            }
            else if (serie.Name == "Mol")
            {
                _mol = setMol(dgv);
                seriesBuilder.UpdateSeries(serie)
                            .AddPoints(_dates, _mol);
            }
            else if (serie.Name == "Hba1c")
            {
                _bloodsugar = setBloodsugar(dgv);
                Statistics statistics = new Statistics(_bloodsugar);
                double hba1c = (statistics.Median + 46.7d) / 28.7d;

                seriesBuilder.UpdateSeries(serie)
                            .AddPoints(_dates, hba1c);
            }
            else if (serie.Name == "Median")
            {
                Statistics statistics = columnType == "Blutzucker" ? new Statistics(_bloodsugar)
                                        : new Statistics(_mol);

                seriesBuilder.UpdateSeries(serie)
                            .AddPoints(_dates, statistics.Median);
            }
            else if (serie.Name == "Max")
            {
                Statistics statistics = columnType == "Blutzucker" ? new Statistics(_bloodsugar)
                                        : new Statistics(_mol);
                seriesBuilder.UpdateSeries(serie)
                            .AddPoints(_dates, statistics.Max);
            }
            else if (serie.Name == "Min")
            {
                Statistics statistics = columnType == "Blutzucker" ? new Statistics(_bloodsugar)
                                        : new Statistics(_mol);
                seriesBuilder.UpdateSeries(serie)
                            .AddPoints(_dates, statistics.Min);
            }
        }

        public void setChart(Chart chart, string type)
        {
            chartBuilder.Create(chart)
                        .setInterval(2.0, 20.0)
                        .setMaximumAutoSize(80, 100)
                        .setLabelStyleX("dd.MM.yyyy")
                        .setAxisTitleX("Datum", new Font("Arial", 12), StringAlignment.Far)
                        .setAxisTitleY(type, new("Arial", 12), StringAlignment.Far)
                        .setAngle(-45)
                        .Build();
        }

        public void addSeriesToChat(Chart chart, Series s)
        {
            chartBuilder.AddSeries(s);
        }

        public Series getMolSeries()
        {
            return seriesBuilder.Create()
                                .Name("Mol")
                                .setType(SeriesChartType.Line)
                                .BorderWidth(5)
                                .Color(Color.MediumPurple)
                                .setValueTypeX(ChartValueType.DateTime)
                                .setValueTypeY(ChartValueType.Double)
                                .AddPoints(_dates, _mol)
                                .Build();
        }



        public Series getMilligrammSeries()
        {
            return seriesBuilder.Create()
                                .Name("Blutzucker")
                                .setType(SeriesChartType.Line)
                                .BorderWidth(5)
                                .Color(Color.LightBlue)
                                .setValueTypeX(ChartValueType.DateTime)
                                .setValueTypeY(ChartValueType.Double)
                                .AddPoints(_dates, _bloodsugar)
                                .Build();
        }

        public Series getSeries(string columnType, string valueType = "Median")
        {
            Statistics statistics = columnType == "Blutzucker" ? new Statistics(_bloodsugar)
                        : new Statistics(_mol);

            seriesBuilder = seriesBuilder.Create()
                        .Name(valueType)
                        .setType(SeriesChartType.Line)
                        .setValueTypeX(ChartValueType.DateTime)
                        .setValueTypeY(ChartValueType.Double)
                        .BorderWidth(2);
            if (valueType == "Max")
            {
                seriesBuilder = seriesBuilder.AddPoints(_dates, statistics.Max)
                                        .Color(Color.Black);
            }
            else if (valueType == "Min")
            {
                seriesBuilder = seriesBuilder.AddPoints(_dates, statistics.Min)
                                        .Color(Color.DarkGray);
            }
            else
            {
                seriesBuilder = seriesBuilder.AddPoints(_dates, statistics.Median);
                if (statistics.Median < 125.0d)
                    seriesBuilder = seriesBuilder.Color(Color.Green);
                else if (statistics.Median > 125.0d && statistics.Median < 180.0d)
                    seriesBuilder = seriesBuilder.Color(Color.Orange);
                else if (statistics.Median > 180.0d)
                    seriesBuilder = seriesBuilder.Color(Color.Red);
            }

            return seriesBuilder.Build();
        }

        public Series getHba1c()
        {
            Statistics statistics = new Statistics(_bloodsugar);
            double hba1c = (statistics.Median + 46.7d) / 28.7d;

            return seriesBuilder.Create()
                                .Name("Hba1c")
                                .setType(SeriesChartType.Line)
                                .setValueTypeX(ChartValueType.DateTime)
                                .setValueTypeY(ChartValueType.Double)
                                .AddPoints(_dates, hba1c)
                                .Color(Color.Red)
                                .Build();
        }


    }
}
