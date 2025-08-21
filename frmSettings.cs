using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diabetikus
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            InitializeOtherComponent();
            InitializeDatabaseSettings();
        }

        public void InitializeOtherComponent()
        {
            cbEngines.Items.Add("SQLServer");
            cbEngines.Items.Add("ADO.OleDb");
        }
        public void InitializeDatabaseSettings()
        {
            DatabaseSettings databaseSettings = new DatabaseSettings();
            int index = cbEngines.Items.IndexOf(databaseSettings.Engine);
            cbEngines.SelectedItem = cbEngines.Items[index];

            txtDatabaseName.Text = databaseSettings.Database;
            txtServer.Text = databaseSettings.Server;
            txtProvider.Text = databaseSettings.Provider;

            chkTrustedConnection.Checked = databaseSettings.TrustedConnection;
            chkTrustedCertification.Checked = databaseSettings.TrustedCertification;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
    }
}
