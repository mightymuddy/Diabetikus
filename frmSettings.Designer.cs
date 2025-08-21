namespace Diabetikus
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtDatabaseName = new TextBox();
            grpSettings = new GroupBox();
            chkTrustedCertification = new CheckBox();
            chkTrustedConnection = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            txtProvider = new TextBox();
            txtServer = new TextBox();
            label2 = new Label();
            cbEngines = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            grpSettings.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Datenbank";
            // 
            // txtDatabaseName
            // 
            txtDatabaseName.Location = new Point(82, 15);
            txtDatabaseName.Name = "txtDatabaseName";
            txtDatabaseName.Size = new Size(285, 23);
            txtDatabaseName.TabIndex = 1;
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(chkTrustedCertification);
            grpSettings.Controls.Add(chkTrustedConnection);
            grpSettings.Controls.Add(label4);
            grpSettings.Controls.Add(label3);
            grpSettings.Controls.Add(txtProvider);
            grpSettings.Controls.Add(txtServer);
            grpSettings.Controls.Add(label2);
            grpSettings.Controls.Add(cbEngines);
            grpSettings.Location = new Point(12, 44);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(355, 190);
            grpSettings.TabIndex = 2;
            grpSettings.TabStop = false;
            grpSettings.Text = "Settings";
            // 
            // chkTrustedCertification
            // 
            chkTrustedCertification.AutoSize = true;
            chkTrustedCertification.Location = new Point(202, 150);
            chkTrustedCertification.Name = "chkTrustedCertification";
            chkTrustedCertification.Size = new Size(133, 19);
            chkTrustedCertification.TabIndex = 7;
            chkTrustedCertification.Text = "Trusted Certification";
            chkTrustedCertification.UseVisualStyleBackColor = true;
            // 
            // chkTrustedConnection
            // 
            chkTrustedConnection.AutoSize = true;
            chkTrustedConnection.Location = new Point(16, 150);
            chkTrustedConnection.Name = "chkTrustedConnection";
            chkTrustedConnection.Size = new Size(130, 19);
            chkTrustedConnection.TabIndex = 6;
            chkTrustedConnection.Text = "Trusted Connection";
            chkTrustedConnection.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 108);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 5;
            label4.Text = "Server";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 66);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 4;
            label3.Text = "Provider";
            // 
            // txtProvider
            // 
            txtProvider.Location = new Point(154, 105);
            txtProvider.Name = "txtProvider";
            txtProvider.Size = new Size(181, 23);
            txtProvider.TabIndex = 3;
            // 
            // txtServer
            // 
            txtServer.Location = new Point(154, 63);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(181, 23);
            txtServer.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 25);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 1;
            label2.Text = "Datenbank-Engine";
            // 
            // cbEngines
            // 
            cbEngines.FormattingEnabled = true;
            cbEngines.Location = new Point(154, 22);
            cbEngines.Name = "cbEngines";
            cbEngines.Size = new Size(181, 23);
            cbEngines.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(194, 240);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(83, 26);
            btnSave.TabIndex = 3;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(278, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(83, 26);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 278);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(grpSettings);
            Controls.Add(txtDatabaseName);
            Controls.Add(label1);
            Name = "frmSettings";
            Text = "Datenbank Einstellungen";
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDatabaseName;
        private GroupBox grpSettings;
        private Label label2;
        private ComboBox cbEngines;
        private TextBox txtProvider;
        private TextBox txtServer;
        private Label label4;
        private Label label3;
        private CheckBox chkTrustedCertification;
        private CheckBox chkTrustedConnection;
        private Button btnSave;
        private Button btnCancel;
    }
}