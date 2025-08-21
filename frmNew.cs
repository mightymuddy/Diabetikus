using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diabetikus
{
    public partial class frmNew : Form
    {
        public frmNew()
        {
            InitializeComponent();
            database = SqlDatabase._getInstance();
        }

        DataTable dt = null;
        SqlDatabase database = null;
        SqlDataAdapter da = null;
        SqlCommandBuilder cb = null;

        public void LoadData(DataGridViewRow? dgrRow = null)
        {

            string sqlString = SqlDatabase.createCommandString(CmdType.Select, "Blutzuckerwerte");
            da = (SqlDataAdapter)database.Adapter(sqlString);
            dt = new DataTable();
            da.Fill(dt);
            cb = new SqlCommandBuilder(da);
            if (dgrRow != null)
                txtRowIndex.Text = dgrRow.Index.ToString();
            else txtRowIndex.Text = "0";
        }

        private void LoadMeassureTypes()
        {
            string sqlString = SqlDatabase.createCommandString(CmdType.Select, "MessungsTyp");
            SqlDataAdapter da = (SqlDataAdapter)database.Adapter(sqlString);
            DataTable dtMeassure = new DataTable();
            da.Fill(dtMeassure);

            foreach (DataRow dr in dtMeassure.Rows)
                cbMeasureType.Items.Add(dr["MessungsTyp"].ToString());
        }

        private void loadDataRow(DataRow dr)
        {

            if (dr.RowState == DataRowState.Added)
            {
                txtDate.Text = "";
                txtTime.Text = "";
                cbMeasureType.SelectedIndex = -1;
                txtMgDl.Text = "0";
                lblMmol.Text = "0";
                lblHbA1c.Text = "0";
                chkEingenommen.Checked = false;
            }
            else
            {
                txtDate.Text = Convert.ToDateTime(dr["Datum"]).ToShortDateString();
                txtTime.Text = dr["Tageszeit"].ToString();
                string id = GetMessureTypName(dr["Art"].ToString());
                cbMeasureType.SelectedItem = cbMeasureType.Items[cbMeasureType.Items.IndexOf(id)];
                txtMgDl.Text = dr["milligramm"].ToString();
                lblMmol.Text = dr["mmol"].ToString();
                lblHbA1c.Text = dr["hba1c"].ToString();
                chkEingenommen.Checked = Convert.ToBoolean(dr["eingenommen"]);
            }
        }


        private string GetMessureTypName(string v)
        {
            string sqlString = SqlDatabase.createCommandString(CmdType.Select, "MessungsTyp");
            sqlString += $" WHERE ID = {v}";
            database.Connection.Open();
            SqlDataReader reader = (SqlDataReader)database.Command(sqlString).ExecuteReader();
            reader.Read();
            string output = reader["MessungsTyp"].ToString();
            reader.Close();
            database.Connection.Close();
            return output;
        }

        private int getMessureTypID(string? v)
        {
            string sqlString = SqlDatabase.createCommandString(CmdType.Select, "MessungsTyp");
            sqlString += $" WHERE MessungsTyp = '{v}'";
            database.Connection.Open();
            SqlDataReader reader = (SqlDataReader)database.Command(sqlString).ExecuteReader();
            reader.Read();
            int output = Convert.ToInt32(reader["ID"]);
            reader.Close();
            database.Connection.Close();
            return output;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtRowIndex.Text);

            if (index < dt.Rows.Count - 1)
                index += 1;
            else index = 0;

            txtRowIndex.Text = index.ToString();
        }

        private void txtRowIndex_TextChanged(object sender, EventArgs e)
        {
            int index = int.Parse(txtRowIndex.Text);
            loadDataRow(dt.Rows[index]);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtRowIndex.Text);

            if (index > 0)
                index -= 1;
            else index = dt.Rows.Count - 1;

            txtRowIndex.Text = index.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cb = new SqlCommandBuilder(da);
            if (!String.IsNullOrEmpty(txtDate.Text) || !String.IsNullOrEmpty(txtTime.Text))
                da.Update(dt);
            LoadData();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmNew_Load(object sender, EventArgs e)
        {
            LoadMeassureTypes();
            LoadData();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            dt.Rows.Add(dt.NewRow());
            txtRowIndex.Text = (dt.Rows.Count - 1).ToString();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtDate.Text, out DateTime parsedDate))
                dt.Rows[int.Parse(txtRowIndex.Text)]["Datum"] = parsedDate;
            else
            {
                MessageBox.Show("Das eingegebene Datum ist ungütlig. Bitte geben Sie ein gültiges Datum ein",
                                "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDate.Focus();
            }
        }

        private void txtTime_Leave(object sender, EventArgs e)
        {
            if (TimeSpan.TryParse(txtTime.Text, out TimeSpan parsedTime))
                dt.Rows[int.Parse(txtRowIndex.Text)]["Tageszeit"] = parsedTime.ToString();
            else
            {
                MessageBox.Show("Das eingegebene Uhrzeit ist ungütlig. Bitte geben Sie ein gültiges Datum ein",
                                "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTime.Focus();
            }
        }

        private void cbMeasureType_Leave(object sender, EventArgs e)
        {
            if (cbMeasureType.SelectedIndex != -1)
            {

                dt.Rows[int.Parse(txtRowIndex.Text)]["Art"] = getMessureTypID(cbMeasureType.Text);
                database.Connection.Close();

            }
        }

        private void txtMgDl_Leave(object sender, EventArgs e)
        {
            if (Double.TryParse(txtMgDl.Text, out Double parsedValue))
            {
                dt.Rows[int.Parse(txtRowIndex.Text)]["milligramm"] = parsedValue;
                double hba1c = (parsedValue + 46.7d) / 28.7d;
                lblHbA1c.Text = hba1c.ToString();
                dt.Rows[int.Parse(txtRowIndex.Text)]["hba1c"] = hba1c.ToString();
                lblMmol.Text = ((hba1c - 2.15d) * 10.929).ToString();
                dt.Rows[int.Parse(txtRowIndex.Text)]["mmol"] = lblMmol.Text;
            }
            else
            {
                MessageBox.Show("Der Wert ist ungültig.",
                                "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMgDl.Focus();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtRowIndex.Text);
            dt.Rows[index].Delete();
            da.Update(dt);
            dt.Rows.RemoveAt(index);
            loadDataRow(dt.Rows[index]);
        }
    }
}
