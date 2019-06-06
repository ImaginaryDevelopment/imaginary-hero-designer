namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmImport_Power : global::System.Windows.Forms.Form
    {

        [global::System.Diagnostics.DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && this.components != null)
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }


        [global::System.Diagnostics.DebuggerStepThrough]
        void InitializeComponent()
        {
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_Power));
            this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
            this.btnUncheckAll = new global::System.Windows.Forms.Button();
            this.btnCheckAll = new global::System.Windows.Forms.Button();
            this.btnClose = new global::System.Windows.Forms.Button();
            this.btnImport = new global::System.Windows.Forms.Button();
            this.lstImport = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.Label8 = new global::System.Windows.Forms.Label();
            this.lblCount = new global::System.Windows.Forms.Label();
            this.lblDate = new global::System.Windows.Forms.Label();
            this.udRevision = new global::System.Windows.Forms.NumericUpDown();
            this.Label6 = new global::System.Windows.Forms.Label();
            this.lblFile = new global::System.Windows.Forms.Label();
            this.btnFile = new global::System.Windows.Forms.Button();
            this.btnCheckModified = new global::System.Windows.Forms.Button();
            this.btnEraseAll = new global::System.Windows.Forms.Button();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.udRevision.BeginInit();
            base.SuspendLayout();
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            global::System.Drawing.Point point = new global::System.Drawing.Point(93, 545);
            this.btnUncheckAll.Location = point;
            this.btnUncheckAll.Name = "btnUncheckAll";
            global::System.Drawing.Size size = new global::System.Drawing.Size(75, 23);
            this.btnUncheckAll.Size = size;
            this.btnUncheckAll.TabIndex = 49;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(12, 545);
            this.btnCheckAll.Location = point;
            this.btnCheckAll.Name = "btnCheckAll";
            size = new global::System.Drawing.Size(75, 23);
            this.btnCheckAll.Size = size;
            this.btnCheckAll.TabIndex = 48;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(618, 516);
            this.btnClose.Location = point;
            this.btnClose.Name = "btnClose";
            size = new global::System.Drawing.Size(86, 23);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(618, 77);
            this.btnImport.Location = point;
            this.btnImport.Name = "btnImport";
            size = new global::System.Drawing.Size(86, 22);
            this.btnImport.Size = size;
            this.btnImport.TabIndex = 46;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.lstImport.CheckBoxes = true;
            this.lstImport.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader4,
                this.ColumnHeader5,
                this.ColumnHeader3
            });
            this.lstImport.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            point = new global::System.Drawing.Point(12, 77);
            this.lstImport.Location = point;
            this.lstImport.Name = "lstImport";
            size = new global::System.Drawing.Size(600, 462);
            this.lstImport.Size = size;
            this.lstImport.TabIndex = 45;
            this.lstImport.UseCompatibleStateImageBehavior = false;
            this.lstImport.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Power";
            this.ColumnHeader1.Width = 237;
            this.ColumnHeader2.Text = "Name";
            this.ColumnHeader2.Width = 117;
            this.ColumnHeader4.Text = "New";
            this.ColumnHeader4.Width = 71;
            this.ColumnHeader5.Text = "Modified";
            point = new global::System.Drawing.Point(346, 53);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new global::System.Drawing.Size(65, 18);
            this.Label8.Size = size;
            this.Label8.TabIndex = 44;
            this.Label8.Text = "Revision:";
            this.Label8.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
            point = new global::System.Drawing.Point(208, 53);
            this.lblCount.Location = point;
            this.lblCount.Name = "lblCount";
            size = new global::System.Drawing.Size(132, 18);
            this.lblCount.Size = size;
            this.lblCount.TabIndex = 43;
            this.lblCount.Text = "Sets:";
            point = new global::System.Drawing.Point(9, 53);
            this.lblDate.Location = point;
            this.lblDate.Name = "lblDate";
            size = new global::System.Drawing.Size(175, 18);
            this.lblDate.Size = size;
            this.lblDate.TabIndex = 42;
            this.lblDate.Text = "Date:";
            point = new global::System.Drawing.Point(417, 51);
            this.udRevision.Location = point;
            int[] array = new int[4];
            array[0] = 65535;
            decimal maximum = new decimal(array);
            this.udRevision.Maximum = maximum;
            this.udRevision.Name = "udRevision";
            size = new global::System.Drawing.Size(116, 20);
            this.udRevision.Size = size;
            this.udRevision.TabIndex = 41;
            point = new global::System.Drawing.Point(12, 9);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new global::System.Drawing.Size(150, 14);
            this.Label6.Size = size;
            this.Label6.TabIndex = 40;
            this.Label6.Text = "Power Definition File:";
            this.lblFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(12, 25);
            this.lblFile.Location = point;
            this.lblFile.Name = "lblFile";
            size = new global::System.Drawing.Size(521, 23);
            this.lblFile.Size = size;
            this.lblFile.TabIndex = 39;
            this.lblFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(539, 25);
            this.btnFile.Location = point;
            this.btnFile.Name = "btnFile";
            size = new global::System.Drawing.Size(165, 23);
            this.btnFile.Size = size;
            this.btnFile.TabIndex = 38;
            this.btnFile.Text = "Load / Re-Load";
            this.btnFile.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(192, 545);
            this.btnCheckModified.Location = point;
            this.btnCheckModified.Name = "btnCheckModified";
            size = new global::System.Drawing.Size(171, 23);
            this.btnCheckModified.Size = size;
            this.btnCheckModified.TabIndex = 50;
            this.btnCheckModified.Text = "Modified Only (Skip New)";
            this.btnCheckModified.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(618, 137);
            this.btnEraseAll.Location = point;
            this.btnEraseAll.Name = "btnEraseAll";
            size = new global::System.Drawing.Size(86, 69);
            this.btnEraseAll.Size = size;
            this.btnEraseAll.TabIndex = 63;
            this.btnEraseAll.Text = "Erase All Powers";
            this.btnEraseAll.UseVisualStyleBackColor = true;
            this.ColumnHeader3.Text = "Change Description";
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            size = new global::System.Drawing.Size(716, 575);
            base.ClientSize = size;
            base.Controls.Add(this.btnEraseAll);
            base.Controls.Add(this.btnCheckModified);
            base.Controls.Add(this.btnUncheckAll);
            base.Controls.Add(this.btnCheckAll);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnImport);
            base.Controls.Add(this.lstImport);
            base.Controls.Add(this.Label8);
            base.Controls.Add(this.lblCount);
            base.Controls.Add(this.lblDate);
            base.Controls.Add(this.udRevision);
            base.Controls.Add(this.Label6);
            base.Controls.Add(this.lblFile);
            base.Controls.Add(this.btnFile);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmImport_Power";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Import";
            this.udRevision.EndInit();
            base.ResumeLayout(false);
        }


        global::System.ComponentModel.IContainer components;
    }
}
