namespace Diabetikus
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            menuStrip1 = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            mnuItemImport = new ToolStripMenuItem();
            mnuItemClose = new ToolStripMenuItem();
            datenbankToolStripMenuItem = new ToolStripMenuItem();
            mnuItemSettings = new ToolStripMenuItem();
            messungenToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            dgvOverview = new DataGridView();
            filterMeasureTyp = new ComboBox();
            label1 = new Label();
            filterStartDatum = new TextBox();
            label2 = new Label();
            filterTimestamp = new ComboBox();
            label4 = new Label();
            filterEndDatum = new TextBox();
            label3 = new Label();
            chrtSummary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chrtMol = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chrtHba1c = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label5 = new Label();
            lblMedianBlutzucker = new Label();
            lblMmol = new Label();
            label7 = new Label();
            label6 = new Label();
            lblHba1c = new Label();
            label9 = new Label();
            pnStatus = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chrtSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chrtMol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chrtHba1c).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, datenbankToolStripMenuItem, messungenToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1377, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuItemImport, mnuItemClose });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // mnuItemImport
            // 
            mnuItemImport.Name = "mnuItemImport";
            mnuItemImport.Size = new Size(180, 22);
            mnuItemImport.Text = "Importieren";
            mnuItemImport.Click += mnuItemImport_Click;
            // 
            // mnuItemClose
            // 
            mnuItemClose.Name = "mnuItemClose";
            mnuItemClose.Size = new Size(180, 22);
            mnuItemClose.Text = "Schließen";
            mnuItemClose.Click += mnuItemClose_Click;
            // 
            // datenbankToolStripMenuItem
            // 
            datenbankToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuItemSettings });
            datenbankToolStripMenuItem.Name = "datenbankToolStripMenuItem";
            datenbankToolStripMenuItem.Size = new Size(76, 20);
            datenbankToolStripMenuItem.Text = "Datenbank";
            // 
            // mnuItemSettings
            // 
            mnuItemSettings.Name = "mnuItemSettings";
            mnuItemSettings.Size = new Size(180, 22);
            mnuItemSettings.Text = "Einstellungen";
            mnuItemSettings.Click += mnuItemSettings_Click;
            // 
            // messungenToolStripMenuItem
            // 
            messungenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            messungenToolStripMenuItem.Name = "messungenToolStripMenuItem";
            messungenToolStripMenuItem.Size = new Size(80, 20);
            messungenToolStripMenuItem.Text = "Messungen";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(194, 22);
            toolStripMenuItem1.Text = "Messungen bearbeiten";
            toolStripMenuItem1.Click += neueMessungToolStripMenuItem_Click;
            // 
            // dgvOverview
            // 
            dgvOverview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOverview.Location = new Point(12, 113);
            dgvOverview.Name = "dgvOverview";
            dgvOverview.Size = new Size(627, 295);
            dgvOverview.TabIndex = 1;
            // 
            // filterMeasureTyp
            // 
            filterMeasureTyp.FormattingEnabled = true;
            filterMeasureTyp.Location = new Point(477, 78);
            filterMeasureTyp.Name = "filterMeasureTyp";
            filterMeasureTyp.Size = new Size(162, 23);
            filterMeasureTyp.TabIndex = 3;
            filterMeasureTyp.SelectedIndexChanged += filterMeasureTyp_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 81);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 4;
            label1.Text = "Messung";
            // 
            // filterStartDatum
            // 
            filterStartDatum.Location = new Point(98, 42);
            filterStartDatum.Name = "filterStartDatum";
            filterStartDatum.Size = new Size(167, 23);
            filterStartDatum.TabIndex = 6;
            filterStartDatum.KeyPress += FilterDays_keyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 7;
            label2.Text = "Startdatum";
            // 
            // filterTimestamp
            // 
            filterTimestamp.FormattingEnabled = true;
            filterTimestamp.Location = new Point(98, 78);
            filterTimestamp.Name = "filterTimestamp";
            filterTimestamp.Size = new Size(167, 23);
            filterTimestamp.TabIndex = 10;
            filterTimestamp.SelectedIndexChanged += filterTimestamp_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 81);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 11;
            label4.Text = "Zeitraum";
            // 
            // filterEndDatum
            // 
            filterEndDatum.Location = new Point(477, 42);
            filterEndDatum.Name = "filterEndDatum";
            filterEndDatum.Size = new Size(162, 23);
            filterEndDatum.TabIndex = 12;
            filterEndDatum.KeyPress += FilterDays_keyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(386, 45);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 13;
            label3.Text = "Enddatum";
            // 
            // chrtSummary
            // 
            chartArea1.Name = "ChartArea1";
            chrtSummary.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chrtSummary.Legends.Add(legend1);
            chrtSummary.Location = new Point(674, 42);
            chrtSummary.Name = "chrtSummary";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chrtSummary.Series.Add(series1);
            chrtSummary.Size = new Size(680, 366);
            chrtSummary.TabIndex = 14;
            chrtSummary.Text = "chart1";
            // 
            // chrtMol
            // 
            chartArea2.Name = "ChartArea1";
            chrtMol.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chrtMol.Legends.Add(legend2);
            chrtMol.Location = new Point(674, 445);
            chrtMol.Name = "chrtMol";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chrtMol.Series.Add(series2);
            chrtMol.Size = new Size(341, 252);
            chrtMol.TabIndex = 17;
            chrtMol.Text = "chart1";
            // 
            // chrtHba1c
            // 
            chartArea3.Name = "ChartArea1";
            chrtHba1c.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chrtHba1c.Legends.Add(legend3);
            chrtHba1c.Location = new Point(1032, 445);
            chrtHba1c.Name = "chrtHba1c";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chrtHba1c.Series.Add(series3);
            chrtHba1c.Size = new Size(322, 252);
            chrtHba1c.TabIndex = 19;
            chrtHba1c.Text = "chart1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(40, 472);
            label5.Name = "label5";
            label5.Size = new Size(181, 25);
            label5.TabIndex = 20;
            label5.Text = "mittlerer Blutzucker:";
            // 
            // lblMedianBlutzucker
            // 
            lblMedianBlutzucker.BorderStyle = BorderStyle.Fixed3D;
            lblMedianBlutzucker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMedianBlutzucker.Location = new Point(238, 472);
            lblMedianBlutzucker.Name = "lblMedianBlutzucker";
            lblMedianBlutzucker.Size = new Size(177, 25);
            lblMedianBlutzucker.TabIndex = 21;
            // 
            // lblMmol
            // 
            lblMmol.BorderStyle = BorderStyle.Fixed3D;
            lblMmol.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMmol.Location = new Point(40, 575);
            lblMmol.Name = "lblMmol";
            lblMmol.Size = new Size(181, 25);
            lblMmol.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(239, 575);
            label7.Name = "label7";
            label7.Size = new Size(99, 25);
            label7.TabIndex = 24;
            label7.Text = "mmol/mol";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(533, 575);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 26;
            label6.Text = "%HbA1c";
            // 
            // lblHba1c
            // 
            lblHba1c.BorderStyle = BorderStyle.Fixed3D;
            lblHba1c.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHba1c.Location = new Point(386, 575);
            lblHba1c.Name = "lblHba1c";
            lblHba1c.Size = new Size(124, 25);
            lblHba1c.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(439, 473);
            label9.Name = "label9";
            label9.Size = new Size(62, 25);
            label9.TabIndex = 27;
            label9.Text = "mg/dl";
            // 
            // pnStatus
            // 
            pnStatus.Location = new Point(525, 445);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(91, 82);
            pnStatus.TabIndex = 28;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1377, 723);
            Controls.Add(pnStatus);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(lblHba1c);
            Controls.Add(label7);
            Controls.Add(lblMmol);
            Controls.Add(lblMedianBlutzucker);
            Controls.Add(label5);
            Controls.Add(chrtHba1c);
            Controls.Add(chrtMol);
            Controls.Add(chrtSummary);
            Controls.Add(label3);
            Controls.Add(filterEndDatum);
            Controls.Add(label4);
            Controls.Add(filterTimestamp);
            Controls.Add(label2);
            Controls.Add(filterStartDatum);
            Controls.Add(label1);
            Controls.Add(filterMeasureTyp);
            Controls.Add(dgvOverview);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Diabetikus";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverview).EndInit();
            ((System.ComponentModel.ISupportInitialize)chrtSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)chrtMol).EndInit();
            ((System.ComponentModel.ISupportInitialize)chrtHba1c).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem mnuItemImport;
        private ToolStripMenuItem mnuItemClose;
        private DataGridView dgvOverview;
        private ToolStripMenuItem datenbankToolStripMenuItem;
        private ToolStripMenuItem mnuItemSettings;
        private ComboBox filterMeasureTyp;
        private Label label1;
        private TextBox filterStartDatum;
        private Label label2;
        private ComboBox filterTimestamp;
        private Label label4;
        private ToolStripMenuItem messungenToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private TextBox filterEndDatum;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtSummary;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtMol;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtHba1c;
        private Label label5;
        private Label lblMedianBlutzucker;
        private Label lblMmol;
        private Label label7;
        private Label label6;
        private Label lblHba1c;
        private Label label9;
        private Panel pnStatus;
    }
}
