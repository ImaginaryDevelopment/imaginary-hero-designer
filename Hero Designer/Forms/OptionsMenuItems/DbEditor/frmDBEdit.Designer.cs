
using System.ComponentModel;

namespace Hero_Designer
{
    public partial class frmDBEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

            this.udIssue = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnEditEnh = new System.Windows.Forms.Button();
            this.btnEditIOSet = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCountSalvage = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblCountRecipe = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblCountFX = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.lblCountPwr = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.lblCountPS = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.lblCountIOSet = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.lblCountEnh = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblCountAT = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnSalvage = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnEditEntity = new System.Windows.Forms.Button();
            this.btnPSBrowse = new System.Windows.Forms.Button();
            this.txtDBVer = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnFileReport = new System.Windows.Forms.Button();
            this.exportIndexes = new System.Windows.Forms.Button();
            this.udIssue.BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();

            this.udIssue.Location = new System.Drawing.Point(148, 44);
            this.udIssue.Minimum = new System.Decimal(new int[4] { 1, 0, 0, 0 });
            this.udIssue.Name = "udIssue";

            this.udIssue.Size = new System.Drawing.Size(84, 20);
            this.udIssue.TabIndex = 0;
            this.udIssue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udIssue.Value = new System.Decimal(new int[4] { 12, 0, 0, 0 });

            this.Label1.Location = new System.Drawing.Point(22, 44);
            this.Label1.Name = "Label1";

            this.Label1.Size = new System.Drawing.Size(120, 20);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "CoX Issue Supported:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label2.Location = new System.Drawing.Point(4, 16);
            this.Label2.Name = "Label2";

            this.Label2.Size = new System.Drawing.Size(144, 20);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Database Update Date:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblDate.Location = new System.Drawing.Point(148, 16);
            this.lblDate.Name = "lblDate";

            this.lblDate.Size = new System.Drawing.Size(84, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "DD/MM/YYYY";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditEnh.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEditEnh.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnEditEnh.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnEditEnh.Location = new System.Drawing.Point(48, 168);
            this.btnEditEnh.Name = "btnEditEnh";

            this.btnEditEnh.Size = new System.Drawing.Size(160, 24);
            this.btnEditEnh.TabIndex = 5;
            this.btnEditEnh.Text = "Enhancement Editor";
            this.btnEditEnh.UseVisualStyleBackColor = true;
            this.btnEditEnh.Click += new System.EventHandler(btnEditEnh_Click);
            this.btnEditIOSet.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEditIOSet.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnEditIOSet.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnEditIOSet.Location = new System.Drawing.Point(48, 198);
            this.btnEditIOSet.Name = "btnEditIOSet";

            this.btnEditIOSet.Size = new System.Drawing.Size(160, 24);
            this.btnEditIOSet.TabIndex = 6;
            this.btnEditIOSet.Text = "Invention Set Editor";
            this.btnEditIOSet.UseVisualStyleBackColor = true;
            this.btnEditIOSet.Click += new System.EventHandler(btnEditIOSet_Click);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountSalvage);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label6);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountRecipe);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label4);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountFX);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label15);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountPwr);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label13);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountPS);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label11);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountIOSet);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label9);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountEnh);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label7);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.lblCountAT);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.Label5);
            this.GroupBox1.ForeColor = System.Drawing.Color.White;

            this.GroupBox1.Location = new System.Drawing.Point(236, 4);
            this.GroupBox1.Name = "GroupBox1";

            this.GroupBox1.Size = new System.Drawing.Size(164, 218);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Statistics:";
            this.lblCountSalvage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountSalvage.Location = new System.Drawing.Point(88, 184);
            this.lblCountSalvage.Name = "lblCountSalvage";

            this.lblCountSalvage.Size = new System.Drawing.Size(68, 20);
            this.lblCountSalvage.TabIndex = 20;
            this.lblCountSalvage.Text = "Count";
            this.lblCountSalvage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label6.Location = new System.Drawing.Point(4, 184);
            this.Label6.Name = "Label6";

            this.Label6.Size = new System.Drawing.Size(84, 20);
            this.Label6.TabIndex = 19;
            this.Label6.Text = "Salvage:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountRecipe.Location = new System.Drawing.Point(88, 160);
            this.lblCountRecipe.Name = "lblCountRecipe";

            this.lblCountRecipe.Size = new System.Drawing.Size(68, 20);
            this.lblCountRecipe.TabIndex = 18;
            this.lblCountRecipe.Text = "Count";
            this.lblCountRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label4.Location = new System.Drawing.Point(4, 160);
            this.Label4.Name = "Label4";

            this.Label4.Size = new System.Drawing.Size(84, 20);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Recipes:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountFX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountFX.Location = new System.Drawing.Point(88, 136);
            this.lblCountFX.Name = "lblCountFX";

            this.lblCountFX.Size = new System.Drawing.Size(68, 20);
            this.lblCountFX.TabIndex = 16;
            this.lblCountFX.Text = "Count";
            this.lblCountFX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label15.Location = new System.Drawing.Point(4, 136);
            this.Label15.Name = "Label15";

            this.Label15.Size = new System.Drawing.Size(84, 20);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Power Effects:";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountPwr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountPwr.Location = new System.Drawing.Point(88, 112);
            this.lblCountPwr.Name = "lblCountPwr";

            this.lblCountPwr.Size = new System.Drawing.Size(68, 20);
            this.lblCountPwr.TabIndex = 14;
            this.lblCountPwr.Text = "Count";
            this.lblCountPwr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label13.Location = new System.Drawing.Point(4, 112);
            this.Label13.Name = "Label13";

            this.Label13.Size = new System.Drawing.Size(84, 20);
            this.Label13.TabIndex = 13;
            this.Label13.Text = "Powers:";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountPS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountPS.Location = new System.Drawing.Point(88, 88);
            this.lblCountPS.Name = "lblCountPS";

            this.lblCountPS.Size = new System.Drawing.Size(68, 20);
            this.lblCountPS.TabIndex = 12;
            this.lblCountPS.Text = "Count";
            this.lblCountPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label11.Location = new System.Drawing.Point(4, 88);
            this.Label11.Name = "Label11";

            this.Label11.Size = new System.Drawing.Size(84, 20);
            this.Label11.TabIndex = 11;
            this.Label11.Text = "Powersets:";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountIOSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountIOSet.Location = new System.Drawing.Point(88, 64);
            this.lblCountIOSet.Name = "lblCountIOSet";

            this.lblCountIOSet.Size = new System.Drawing.Size(68, 20);
            this.lblCountIOSet.TabIndex = 10;
            this.lblCountIOSet.Text = "Count";
            this.lblCountIOSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label9.Location = new System.Drawing.Point(4, 64);
            this.Label9.Name = "Label9";

            this.Label9.Size = new System.Drawing.Size(84, 20);
            this.Label9.TabIndex = 9;
            this.Label9.Text = "Invention Sets:";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountEnh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountEnh.Location = new System.Drawing.Point(88, 40);
            this.lblCountEnh.Name = "lblCountEnh";

            this.lblCountEnh.Size = new System.Drawing.Size(68, 20);
            this.lblCountEnh.TabIndex = 8;
            this.lblCountEnh.Text = "Count";
            this.lblCountEnh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label7.Location = new System.Drawing.Point(4, 40);
            this.Label7.Name = "Label7";

            this.Label7.Size = new System.Drawing.Size(84, 20);
            this.Label7.TabIndex = 7;
            this.Label7.Text = "Enhancements:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCountAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblCountAT.Location = new System.Drawing.Point(88, 16);
            this.lblCountAT.Name = "lblCountAT";

            this.lblCountAT.Size = new System.Drawing.Size(68, 20);
            this.lblCountAT.TabIndex = 6;
            this.lblCountAT.Text = "Count";
            this.lblCountAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Label5.Location = new System.Drawing.Point(4, 16);
            this.Label5.Name = "Label5";

            this.Label5.Size = new System.Drawing.Size(84, 20);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "Classes:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnClose.Location = new System.Drawing.Point(236, 288);
            this.btnClose.Name = "btnClose";

            this.btnClose.Size = new System.Drawing.Size(164, 24);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(btnClose_Click);
            this.btnDate.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnDate.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnDate.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnDate.Location = new System.Drawing.Point(31, 16);
            this.btnDate.Name = "btnDate";

            this.btnDate.Size = new System.Drawing.Size(111, 20);
            this.btnDate.TabIndex = 13;
            this.btnDate.Text = "Set Date";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Visible = false;
            this.btnDate.Click += new System.EventHandler(btnDate_Click);
            this.btnSalvage.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnSalvage.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnSalvage.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnSalvage.Location = new System.Drawing.Point(48, 228);
            this.btnSalvage.Name = "btnSalvage";

            this.btnSalvage.Size = new System.Drawing.Size(160, 24);
            this.btnSalvage.TabIndex = 14;
            this.btnSalvage.Text = "Salvage Editor";
            this.btnSalvage.UseVisualStyleBackColor = true;
            this.btnSalvage.Click += new System.EventHandler(btnSalvage_Click);
            this.btnRecipe.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnRecipe.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnRecipe.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnRecipe.Location = new System.Drawing.Point(48, 258);
            this.btnRecipe.Name = "btnRecipe";

            this.btnRecipe.Size = new System.Drawing.Size(160, 24);
            this.btnRecipe.TabIndex = 15;
            this.btnRecipe.Text = "Recipe Editor";
            this.btnRecipe.UseVisualStyleBackColor = true;
            this.btnRecipe.Click += new System.EventHandler(btnRecipe_Click);
            this.btnCSV.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnCSV.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnCSV.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnCSV.Location = new System.Drawing.Point(48, 288);
            this.btnCSV.Name = "btnCSV";

            this.btnCSV.Size = new System.Drawing.Size(160, 24);
            this.btnCSV.TabIndex = 16;
            this.btnCSV.Text = "CSV Importer";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(btnCSV_Click);
            this.btnEditEntity.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEditEntity.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnEditEntity.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnEditEntity.Location = new System.Drawing.Point(48, 138);
            this.btnEditEntity.Name = "btnEditEntity";

            this.btnEditEntity.Size = new System.Drawing.Size(160, 24);
            this.btnEditEntity.TabIndex = 17;
            this.btnEditEntity.Text = "Entity Editor";
            this.btnEditEntity.UseVisualStyleBackColor = true;
            this.btnEditEntity.Click += new System.EventHandler(btnEditEntity_Click);
            this.btnPSBrowse.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnPSBrowse.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnPSBrowse.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnPSBrowse.Location = new System.Drawing.Point(48, 94);
            this.btnPSBrowse.Name = "btnPSBrowse";

            this.btnPSBrowse.Size = new System.Drawing.Size(160, 38);
            this.btnPSBrowse.TabIndex = 18;
            this.btnPSBrowse.Text = "Main Database Editor";
            this.btnPSBrowse.UseVisualStyleBackColor = true;
            this.btnPSBrowse.Click += new System.EventHandler(btnPSBrowse_Click);

            this.txtDBVer.Location = new System.Drawing.Point(148, 68);
            this.txtDBVer.Name = "txtDBVer";

            this.txtDBVer.Size = new System.Drawing.Size(84, 20);
            this.txtDBVer.TabIndex = 21;
            this.txtDBVer.TextChanged += new System.EventHandler(txtDBVer_TextChanged);

            this.Label3.Location = new System.Drawing.Point(22, 68);
            this.Label3.Name = "Label3";

            this.Label3.Size = new System.Drawing.Size(120, 20);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Database Version:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileReport.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnFileReport.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnFileReport.ForeColor = System.Drawing.SystemColors.ControlText;

            this.btnFileReport.Location = new System.Drawing.Point(236, 258);
            this.btnFileReport.Name = "btnFileReport";

            this.btnFileReport.Size = new System.Drawing.Size(164, 24);
            this.btnFileReport.TabIndex = 23;
            this.btnFileReport.Text = "File Load Report";
            this.btnFileReport.UseVisualStyleBackColor = true;
            this.btnFileReport.Visible = false;
            this.btnFileReport.Click += new System.EventHandler(btnFileReport_Click);
            this.exportIndexes.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.exportIndexes.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.exportIndexes.ForeColor = System.Drawing.SystemColors.ControlText;

            this.exportIndexes.Location = new System.Drawing.Point(236, 228);
            this.exportIndexes.Name = "exportIndexes";

            this.exportIndexes.Size = new System.Drawing.Size(164, 24);
            this.exportIndexes.TabIndex = 24;
            this.exportIndexes.Text = "Export Power Indexes";
            this.exportIndexes.UseVisualStyleBackColor = true;
            this.exportIndexes.Visible = false;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(0, 0, 32);

            this.ClientSize = new System.Drawing.Size(416, 327);
            this.Controls.Add((System.Windows.Forms.Control)this.btnFileReport);
            this.Controls.Add((System.Windows.Forms.Control)this.Label3);
            this.Controls.Add((System.Windows.Forms.Control)this.txtDBVer);
            this.Controls.Add((System.Windows.Forms.Control)this.btnPSBrowse);
            this.Controls.Add((System.Windows.Forms.Control)this.btnEditEntity);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCSV);
            this.Controls.Add((System.Windows.Forms.Control)this.btnRecipe);
            this.Controls.Add((System.Windows.Forms.Control)this.btnSalvage);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDate);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClose);
            this.Controls.Add((System.Windows.Forms.Control)this.GroupBox1);
            this.Controls.Add((System.Windows.Forms.Control)this.btnEditIOSet);
            this.Controls.Add((System.Windows.Forms.Control)this.btnEditEnh);
            this.Controls.Add((System.Windows.Forms.Control)this.lblDate);
            this.Controls.Add((System.Windows.Forms.Control)this.Label2);
            this.Controls.Add((System.Windows.Forms.Control)this.Label1);
            this.Controls.Add((System.Windows.Forms.Control)this.udIssue);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Editor";
            this.udIssue.EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        System.Windows.Forms.NumericUpDown udIssue;
        #endregion
    }
}