namespace Diabetikus
{
    partial class frmNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNew));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cbMeasureType = new ComboBox();
            btnSave = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            btnCancel = new Button();
            txtDate = new TextBox();
            txtTime = new TextBox();
            txtMgDl = new TextBox();
            lblHbA1c = new Label();
            chkEingenommen = new CheckBox();
            txtRowIndex = new TextBox();
            btnAdd = new Button();
            lblMmol = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 24);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Datum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 24);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Tageszeit";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 73);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 2;
            label3.Text = "MessungsTyp";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 126);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "mg/dl";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(195, 126);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 4;
            label5.Text = "mmol/Mol";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 175);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 5;
            label6.Text = "HbA1c";
            // 
            // cbMeasureType
            // 
            cbMeasureType.FormattingEnabled = true;
            cbMeasureType.Location = new Point(122, 70);
            cbMeasureType.Name = "cbMeasureType";
            cbMeasureType.Size = new Size(255, 23);
            cbMeasureType.TabIndex = 6;
            cbMeasureType.Leave += cbMeasureType_Leave;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(233, 219);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(71, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(19, 219);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(33, 23);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(101, 219);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(33, 23);
            btnNext.TabIndex = 9;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(310, 219);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(68, 21);
            txtDate.Name = "txtDate";
            txtDate.PlaceholderText = "dd.MM.yyyy";
            txtDate.Size = new Size(112, 23);
            txtDate.TabIndex = 11;
            txtDate.Leave += txtDate_Leave;
            // 
            // txtTime
            // 
            txtTime.Location = new Point(261, 21);
            txtTime.Name = "txtTime";
            txtTime.PlaceholderText = "hh.mm.ss";
            txtTime.Size = new Size(116, 23);
            txtTime.TabIndex = 12;
            txtTime.Leave += txtTime_Leave;
            // 
            // txtMgDl
            // 
            txtMgDl.Location = new Point(68, 123);
            txtMgDl.Name = "txtMgDl";
            txtMgDl.Size = new Size(112, 23);
            txtMgDl.TabIndex = 13;
            txtMgDl.Leave += txtMgDl_Leave;
            // 
            // lblHbA1c
            // 
            lblHbA1c.BorderStyle = BorderStyle.Fixed3D;
            lblHbA1c.Location = new Point(68, 174);
            lblHbA1c.Name = "lblHbA1c";
            lblHbA1c.Size = new Size(112, 23);
            lblHbA1c.TabIndex = 14;
            // 
            // chkEingenommen
            // 
            chkEingenommen.AutoSize = true;
            chkEingenommen.Location = new Point(216, 175);
            chkEingenommen.Name = "chkEingenommen";
            chkEingenommen.Size = new Size(164, 19);
            chkEingenommen.TabIndex = 16;
            chkEingenommen.Text = "Metformin eingenommen";
            chkEingenommen.UseVisualStyleBackColor = true;
            // 
            // txtRowIndex
            // 
            txtRowIndex.Location = new Point(58, 219);
            txtRowIndex.Name = "txtRowIndex";
            txtRowIndex.Size = new Size(37, 23);
            txtRowIndex.TabIndex = 17;
            txtRowIndex.TextChanged += txtRowIndex_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(140, 219);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(33, 23);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblMmol
            // 
            lblMmol.BorderStyle = BorderStyle.Fixed3D;
            lblMmol.Location = new Point(266, 123);
            lblMmol.Name = "lblMmol";
            lblMmol.Size = new Size(100, 23);
            lblMmol.TabIndex = 19;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.Control;
            btnDelete.BackgroundImage = (Image)resources.GetObject("btnDelete.BackgroundImage");
            btnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            btnDelete.Location = new Point(179, 219);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(33, 23);
            btnDelete.TabIndex = 20;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // frmNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 251);
            Controls.Add(btnDelete);
            Controls.Add(lblMmol);
            Controls.Add(btnAdd);
            Controls.Add(txtRowIndex);
            Controls.Add(chkEingenommen);
            Controls.Add(lblHbA1c);
            Controls.Add(txtMgDl);
            Controls.Add(txtTime);
            Controls.Add(txtDate);
            Controls.Add(btnCancel);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnSave);
            Controls.Add(cbMeasureType);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNew";
            Text = "Messung Bearbeiten";
            Load += frmNew_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cbMeasureType;
        private Button btnSave;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnCancel;
        private TextBox txtDate;
        private TextBox txtTime;
        private TextBox txtMgDl;
        private Label lblHbA1c;
        private CheckBox chkEingenommen;
        private TextBox txtRowIndex;
        private Button btnAdd;
        private Label lblMmol;
        private Button btnDelete;
    }
}