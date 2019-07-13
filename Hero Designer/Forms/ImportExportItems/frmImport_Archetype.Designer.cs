namespace Hero_Designer
{
    public partial class frmImport_Archetype
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
            this.components = (System.ComponentModel.IContainer)new System.ComponentModel.Container();

            this.Label8 = new System.Windows.Forms.Label();
            this.lblATCount = new System.Windows.Forms.Label();
            this.lblATDate = new System.Windows.Forms.Label();
            this.udATRevision = new System.Windows.Forms.NumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
            this.lblATFile = new System.Windows.Forms.Label();
            this.btnATFile = new System.Windows.Forms.Button();
            this.lstImport = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.udATRevision.BeginInit();
            this.SuspendLayout();

            this.Label8.Location = new System.Drawing.Point(346, 53);
            this.Label8.Name = "Label8";

            this.Label8.Size = new System.Drawing.Size(65, 18);
            this.Label8.TabIndex = 25;
            this.Label8.Text = "Revision:";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;

            this.lblATCount.Location = new System.Drawing.Point(208, 53);
            this.lblATCount.Name = "lblATCount";

            this.lblATCount.Size = new System.Drawing.Size(132, 18);
            this.lblATCount.TabIndex = 24;
            this.lblATCount.Text = "Classes:";

            this.lblATDate.Location = new System.Drawing.Point(9, 53);
            this.lblATDate.Name = "lblATDate";

            this.lblATDate.Size = new System.Drawing.Size(175, 18);
            this.lblATDate.TabIndex = 23;
            this.lblATDate.Text = "Date:";

            this.udATRevision.Location = new System.Drawing.Point(417, 51);
            this.udATRevision.Maximum = new System.Decimal(new int[4]
            {
        (int) ushort.MaxValue,
        0,
        0,
        0
            });
            this.udATRevision.Name = "udATRevision";

            this.udATRevision.Size = new System.Drawing.Size(116, 20);
            this.udATRevision.TabIndex = 22;

            this.Label6.Location = new System.Drawing.Point(12, 9);
            this.Label6.Name = "Label6";

            this.Label6.Size = new System.Drawing.Size(150, 14);
            this.Label6.TabIndex = 21;
            this.Label6.Text = "Class Definition File:";
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            this.lblATFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblATFile.Location = new System.Drawing.Point(12, 25);
            this.lblATFile.Name = "lblATFile";

            this.lblATFile.Size = new System.Drawing.Size(521, 23);
            this.lblATFile.TabIndex = 20;
            this.lblATFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnATFile.Location = new System.Drawing.Point(539, 25);
            this.btnATFile.Name = "btnATFile";

            this.btnATFile.Size = new System.Drawing.Size(165, 23);
            this.btnATFile.TabIndex = 19;
            this.btnATFile.Text = "Load / Re-Load";
            this.btnATFile.UseVisualStyleBackColor = true;
            this.btnATFile.Click += new System.EventHandler(btnATFile_Click);
            this.lstImport.CheckBoxes = true;
            this.lstImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[6]
            {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader5,
        this.ColumnHeader6
            });
            this.lstImport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;

            this.lstImport.Location = new System.Drawing.Point(12, 77);
            this.lstImport.Name = "lstImport";

            this.lstImport.Size = new System.Drawing.Size(600, 309);
            this.lstImport.TabIndex = 26;
            this.lstImport.UseCompatibleStateImageBehavior = false;
            this.lstImport.View = System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Class";
            this.ColumnHeader1.Width = 128;
            this.ColumnHeader2.Text = "ClassID";
            this.ColumnHeader2.Width = 165;
            this.ColumnHeader3.Text = "Playable";
            this.ColumnHeader3.Width = 72;
            this.ColumnHeader4.Text = "New";
            this.ColumnHeader4.Width = 71;
            this.ColumnHeader5.Text = "Modified";

            this.btnImport.Location = new System.Drawing.Point(618, 77);
            this.btnImport.Name = "btnImport";

            this.btnImport.Size = new System.Drawing.Size(86, 22);
            this.btnImport.TabIndex = 27;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(btnImport_Click);

            this.btnClose.Location = new System.Drawing.Point(618, 363);
            this.btnClose.Name = "btnClose";

            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(btnClose_Click);
            this.ColumnHeader6.Text = "Change Description";
            this.ColumnHeader6.Width = 98;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            this.ClientSize = new System.Drawing.Size(711, 400);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClose);
            this.Controls.Add((System.Windows.Forms.Control)this.btnImport);
            this.Controls.Add((System.Windows.Forms.Control)this.lstImport);
            this.Controls.Add((System.Windows.Forms.Control)this.Label8);
            this.Controls.Add((System.Windows.Forms.Control)this.lblATCount);
            this.Controls.Add((System.Windows.Forms.Control)this.lblATDate);
            this.Controls.Add((System.Windows.Forms.Control)this.udATRevision);
            this.Controls.Add((System.Windows.Forms.Control)this.Label6);
            this.Controls.Add((System.Windows.Forms.Control)this.lblATFile);
            this.Controls.Add((System.Windows.Forms.Control)this.btnATFile);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Text = "Archetype Class Import";
            this.udATRevision.EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        System.Windows.Forms.Button btnATFile;
        System.Windows.Forms.Button btnClose;
        System.Windows.Forms.Button btnImport;
        System.Windows.Forms.ColumnHeader ColumnHeader1;
        System.Windows.Forms.ColumnHeader ColumnHeader2;
        System.Windows.Forms.ColumnHeader ColumnHeader3;
        System.Windows.Forms.ColumnHeader ColumnHeader4;
        System.Windows.Forms.ColumnHeader ColumnHeader5;
        System.Windows.Forms.ColumnHeader ColumnHeader6;
        System.Windows.Forms.OpenFileDialog dlgBrowse;
        System.Windows.Forms.Label Label6;
        System.Windows.Forms.Label Label8;
        System.Windows.Forms.Label lblATCount;
        System.Windows.Forms.Label lblATDate;
        System.Windows.Forms.Label lblATFile;
        System.Windows.Forms.ListView lstImport;
        System.Windows.Forms.NumericUpDown udATRevision;
    }
}