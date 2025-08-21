using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Diabetikus
{
    public partial class Form1 : Form
    {
        SqlDatabase database = null;
        public Form1()
        {
            InitializeComponent();
        }

        DataSet ds = null;
        DataView dv = null;
        ConfigCharts configCharts;
        SqlCommandBuilder cb = null;
        IDataAdapter adapter = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            database = SqlDatabase._getInstance();
            InitializeDataGridView();
            InitializeCharts();
            InitializeFilters();


        }



        private void mnuItemImport_Click(object sender, EventArgs e)
        {
            string[] data = utils.FileImport();

            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    {
                        string[] values = data[i].Split(';');

                        if (dgvOverview.Columns.Count <= 0)
                        {
                            dgvOverview.Columns.Add(values[0], "Datum");
                            dgvOverview.Columns.Add(values[1], "Tageszeit");
                            dgvOverview.Columns.Add(values[2], "MessungsTyp");
                            dgvOverview.Columns.Add(values[3], "mg/dl");
                            dgvOverview.Columns.Add(values[4], "mmol(mol");
                            dgvOverview.Columns.Add(values[5], "HBa1c");
                            dgvOverview.Columns.Add(values[6], "Tablette");
                        }
                        if (dgvOverview.Columns.Count > 0 && i > 0)
                        {
                            DataRow row = ds.Tables["Blutzuckerwerte"].NewRow();
                            row["Datum"] = DateTime.Parse(values[0]);
                            row["Tageszeit"] = values[1];
                            row["MessungsTyp"] = values[2];
                            row["milligramm"] = Double.Parse(values[3]);
                            row["mmol"] = Double.Parse(values[4]);
                            row["hba1c"] = Double.Parse(values[5]);
                            row["eingenommen"] = values[6] == "1" ? true : false;

                            ds.Tables["Blutzuckerwerte"].Rows.Add(row);


                            string sqlMessure = SqlDatabase.createCommandString(CmdType.Select, "MessungsTyp");
                            sqlMessure += $" WHERE MessungsTyp = '{row["MessungsTyp"]}'";
                            database.Connection.Open();
                            SqlDataReader reader = (SqlDataReader)database.Command(sqlMessure).ExecuteReader();
                            reader.Read();
                            string[] fields = { "Datum", "Tageszeit", "Art", "milligramm", "mmol", "hba1c", "eingenommen" };
                            string[] input = new string[fields.Length];
                            input[0] = $"'{row["Datum"].ToString()}'";
                            input[1] = $"'{row["Tageszeit"].ToString()}'";
                            input[2] = reader["ID"].ToString();
                            input[3] = $"{row["milligramm"].ToString()}";
                            input[4] = $"{row["mmol"].ToString()}";
                            input[5] = $"{Double.Parse(row["hba1c"].ToString()).ToString(CultureInfo.InvariantCulture)}";
                            input[6] = $"'{row["eingenommen"].ToString()}'";
                            reader.Close();
                            string sqlString = SqlDatabase.createCommandString(CmdType.Insert, "Blutzuckerwerte", fields, input);
                            database.Command(sqlString).ExecuteNonQuery();
                            database.Connection.Close();
                        }

                    }
                }
            }

        }



        private void mnuItemSettings_Click(object sender, EventArgs e)
        {
            if (database != null && database.Connection.State == ConnectionState.Open)
            {
                database.Connection.Close();
            }

            frmSettings einstellungen = new frmSettings();
            einstellungen.ShowDialog();
        }



        private void InitializeDataGridView()
        {
            string[] fields = { "Datum", "Tageszeit", "MessungsTyp.MessungsTyp", "milligramm", "mmol", "hba1c", "eingenommen" };
            string[] tables = { "Blutzuckerwerte, MessungsTyp" };
            string join = SqlDatabase.JoinTables(JoinType.Inner, "Blutzuckerwerte", "MessungsTyp", "Art", "MessungsTyp.ID");
            string sqlString = SqlDatabase.createCommandString(CmdType.Select, join, fields);
            adapter = database.Adapter(sqlString);
            try
            {
                ds = createDataSet(sqlString, "Blutzuckerwerte");
                dv = new DataView(ds.Tables["Blutzuckerwerte"]);
                dv.Sort = "Datum ASC";
                dgvOverview.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgvOverview.AutoResizeColumns();

        }

        private void InitializeCharts()
        {

            chrtSummary.Series.Clear();
            configCharts = new ConfigCharts(dgvOverview);

            configCharts.setChart(chrtSummary, "Blutzucker");
            configCharts.addSeriesToChat(chrtSummary, configCharts.getMilligrammSeries());
            configCharts.addSeriesToChat(chrtSummary, configCharts.getSeries("Blutzucker"));
            configCharts.addSeriesToChat(chrtSummary, configCharts.getSeries("Blutzucker","Max"));
            configCharts.addSeriesToChat(chrtSummary, configCharts.getSeries("Blutzucker","Min"));
           
            chrtSummary.ChartAreas[0].AxisY.Minimum = 40.0;

            configCharts.setChart(chrtMol, "Mol");
            configCharts.addSeriesToChat(chrtMol, configCharts.getMolSeries());
            configCharts.addSeriesToChat(chrtMol, configCharts.getSeries("mmol"));
            configCharts.addSeriesToChat(chrtMol, configCharts.getSeries("mmol", "Max"));
            configCharts.addSeriesToChat(chrtMol, configCharts.getSeries("mmol", "Min"));
            chrtMol.ChartAreas[0].AxisY.Maximum = 90.0;
            chrtMol.ChartAreas[0].AxisY.Minimum = 20.0;

            configCharts.setChart(chrtHba1c, "Hba1c");
            configCharts.addSeriesToChat(chrtHba1c, configCharts.getHba1c());
            chrtHba1c.ChartAreas[0].AxisY.Maximum = 10.0;
            chrtHba1c.ChartAreas[0].AxisY.Minimum = 1.0;

        }

        private void InitializeFilters()
        {
            string sqlString = SqlDatabase.createCommandString(CmdType.Select, "MessungsTyp");
            DataSet dsMessTyp = createDataSet(sqlString, "MessungsTyp");

            foreach (DataRow row in dsMessTyp.Tables["MessungsTyp"].Rows)
                filterMeasureTyp.Items.Add(row["MessungsTyp"]);

            filterTimestamp.Items.Add("heute");
            filterTimestamp.Items.Add("7");
            filterTimestamp.Items.Add("14");
            filterTimestamp.Items.Add("30");
            filterTimestamp.Items.Add("90");

            filterTimestamp.SelectedItem = filterTimestamp.Items[4];
        }

        private DataSet createDataSet(string sqlString, string name)
        {
            DataSet dsCreate = new DataSet();
            database.Connection.Open();
            IDataAdapter adapter = database.Adapter(database.Command(sqlString));
            if (adapter.GetType() == typeof(OleDbDataAdapter))
                ((OleDbDataAdapter)adapter).Fill(dsCreate, name);
            if (adapter.GetType() == typeof(SqlDataAdapter))
                ((SqlDataAdapter)adapter).Fill(dsCreate, name);
            cb = new SqlCommandBuilder((SqlDataAdapter)adapter);
            database.Connection.Close();
            return dsCreate;
        }

        private void FilterDays_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Filtering();
        }

        private void filterTimestamp_SelectedIndexChanged(object sender, EventArgs e)
            => Filtering();


        private void filterMeasureTyp_SelectedIndexChanged(object sender, EventArgs e)
            => Filtering();


        private void Filtering()
        {
            string filter = "";
            if (filterTimestamp.SelectedIndex == 0)
                if (filterStartDatum.Text.Length > 0 && filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToEndDate(DateTime.Parse(filterStartDatum.Text), DateTime.Parse(filterStartDatum.Text));
                else if (filterStartDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterStartDatum.Text), 0.0);
                else if (filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterEndDatum.Text), -0.0);
                else
                    filter += Filter.filterStartToScalar(DateTime.Now, -0.0);

            if (filterTimestamp.SelectedIndex == 1)
                if (filterStartDatum.Text.Length > 0 && filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToEndDate(DateTime.Parse(filterStartDatum.Text), DateTime.Parse(filterStartDatum.Text));
                else if (filterStartDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterStartDatum.Text), 7.0);
                else if (filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterEndDatum.Text), -7.0);
                else
                    filter += Filter.filterStartToScalar(DateTime.Now, -7.0);

            if (filterTimestamp.SelectedIndex == 2)
                if (filterStartDatum.Text.Length > 0 && filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToEndDate(DateTime.Parse(filterStartDatum.Text), DateTime.Parse(filterStartDatum.Text));
                else if (filterStartDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterStartDatum.Text), 14.0);
                else if (filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterEndDatum.Text), -14.0);
                else
                    filter += Filter.filterStartToScalar(DateTime.Now, -14.0);

            if (filterTimestamp.SelectedIndex == 3)
                if (filterStartDatum.Text.Length > 0 && filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToEndDate(DateTime.Parse(filterStartDatum.Text), DateTime.Parse(filterStartDatum.Text));
                else if (filterStartDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterStartDatum.Text), 30.0);
                else if (filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterEndDatum.Text), -30.0);
                else
                    filter += Filter.filterStartToScalar(DateTime.Now, -30.0);

            if (filterTimestamp.SelectedIndex == 4)
                if (filterStartDatum.Text.Length > 0 && filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToEndDate(DateTime.Parse(filterStartDatum.Text), DateTime.Parse(filterStartDatum.Text));
                else if (filterStartDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterStartDatum.Text), 90.0);
                else if (filterEndDatum.Text.Length > 0)
                    filter += Filter.filterStartToScalar(DateTime.Parse(filterEndDatum.Text), -90.0);
                else
                    filter += Filter.filterStartToScalar(DateTime.Now, -90.0);


            if (filterMeasureTyp.SelectedIndex > -1)
                filter += filter.Length > 0 ?
                        " AND " + Filter.filterValue("MessungsTyp", filterMeasureTyp.Text)
                        : Filter.filterValue("MessungsTyp", filterMeasureTyp.Text);


            dv.Sort = "Datum ASC";
            dv.RowFilter = filter;
            configCharts.UpdateSeries(dgvOverview, chrtSummary.Series["Blutzucker"]);
            configCharts.UpdateSeries(dgvOverview, chrtSummary.Series["Median"], "Blutzucker");
            configCharts.UpdateSeries(dgvOverview, chrtSummary.Series["Max"], "Blutzucker");
            configCharts.UpdateSeries(dgvOverview, chrtSummary.Series["Min"], "Blutzucker");
            configCharts.UpdateSeries(dgvOverview, chrtMol.Series["Mol"]);
            configCharts.UpdateSeries(dgvOverview, chrtMol.Series["Median"], "Mol");
            configCharts.UpdateSeries(dgvOverview, chrtMol.Series["Max"], "Mol");
            configCharts.UpdateSeries(dgvOverview, chrtMol.Series["Min"], "Mol");
            configCharts.UpdateSeries(dgvOverview, chrtHba1c.Series["Hba1c"]);

            double mittlererMgDl = chrtSummary.Series["Median"].Points[0].YValues[0];
            lblMedianBlutzucker.Text = $"{chrtSummary.Series["Median"].Points[0].YValues[0]}";
            lblMmol.Text = $"{chrtMol.Series["Median"].Points[0].YValues[0]}";
            lblHba1c.Text = $"{chrtHba1c.Series["Hba1c"].Points[0].YValues[0]}";

            if (mittlererMgDl < 125.0d)
                pnStatus.BackColor = Color.Green;
            else if (mittlererMgDl > 125.0d && mittlererMgDl < 180.0d)
                pnStatus.BackColor = Color.Orange;
            else if (mittlererMgDl > 180.0d)
                pnStatus.BackColor = Color.Red;


        }



        private void neueMessungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNew frmNew = new frmNew();
            if (frmNew.ShowDialog() == DialogResult.OK)
                InitializeDataGridView();
        }

        private void mnuItemClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

     


    }
}
