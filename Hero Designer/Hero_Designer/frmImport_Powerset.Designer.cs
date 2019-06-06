namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmImport_Powerset : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_Powerset));
            this.Label8 = new global::System.Windows.Forms.Label();
            this.lblCount = new global::System.Windows.Forms.Label();
            this.lblDate = new global::System.Windows.Forms.Label();
            this.udRevision = new global::System.Windows.Forms.NumericUpDown();
            this.Label6 = new global::System.Windows.Forms.Label();
            this.lblFile = new global::System.Windows.Forms.Label();
            this.btnFile = new global::System.Windows.Forms.Button();
            this.btnClose = new global::System.Windows.Forms.Button();
            this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
            this.btnImport = new global::System.Windows.Forms.Button();
            this.lstImport = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.btnCheckAll = new global::System.Windows.Forms.Button();
            this.btnUncheckAll = new global::System.Windows.Forms.Button();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.udRevision.BeginInit();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(346, 53);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            global::System.Drawing.Size size = new global::System.Drawing.Size(65, 18);
            this.Label8.Size = size;
            this.Label8.TabIndex = 32;
            this.Label8.Text = "Revision:";
            this.Label8.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
            point = new global::System.Drawing.Point(208, 53);
            this.lblCount.Location = point;
            this.lblCount.Name = "lblCount";
            size = new global::System.Drawing.Size(132, 18);
            this.lblCount.Size = size;
            this.lblCount.TabIndex = 31;
            this.lblCount.Text = "Sets:";
            point = new global::System.Drawing.Point(9, 53);
            this.lblDate.Location = point;
            this.lblDate.Name = "lblDate";
            size = new global::System.Drawing.Size(175, 18);
            this.lblDate.Size = size;
            this.lblDate.TabIndex = 30;
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
            this.udRevision.TabIndex = 29;
            point = new global::System.Drawing.Point(12, 9);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new global::System.Drawing.Size(150, 14);
            this.Label6.Size = size;
            this.Label6.TabIndex = 28;
            this.Label6.Text = "Set Definition File:";
            this.lblFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(12, 25);
            this.lblFile.Location = point;
            this.lblFile.Name = "lblFile";
            size = new global::System.Drawing.Size(521, 23);
            this.lblFile.Size = size;
            this.lblFile.TabIndex = 27;
            this.lblFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(539, 25);
            this.btnFile.Location = point;
            this.btnFile.Name = "btnFile";
            size = new global::System.Drawing.Size(165, 23);
            this.btnFile.Size = size;
            this.btnFile.TabIndex = 26;
            this.btnFile.Text = "Load / Re-Load";
            this.btnFile.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(618, 516);
            this.btnClose.Location = point;
            this.btnClose.Name = "btnClose";
            size = new global::System.Drawing.Size(86, 23);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            point = new global::System.Drawing.Point(618, 77);
            this.btnImport.Location = point;
            this.btnImport.Name = "btnImport";
            size = new global::System.Drawing.Size(86, 22);
            this.btnImport.Size = size;
            this.btnImport.TabIndex = 34;
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
            this.lstImport.TabIndex = 33;
            this.lstImport.UseCompatibleStateImageBehavior = false;
            this.lstImport.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Powerset";
            this.ColumnHeader1.Width = 180;
            this.ColumnHeader2.Text = "Group";
            this.ColumnHeader2.Width = 176;
            this.ColumnHeader4.Text = "New";
            this.ColumnHeader4.Width = 71;
            this.ColumnHeader5.Text = "Modified";
            point = new global::System.Drawing.Point(12, 545);
            this.btnCheckAll.Location = point;
            this.btnCheckAll.Name = "btnCheckAll";
            size = new global::System.Drawing.Size(75, 23);
            this.btnCheckAll.Size = size;
            this.btnCheckAll.TabIndex = 36;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(93, 545);
            this.btnUncheckAll.Location = point;
            this.btnUncheckAll.Name = "btnUncheckAll";
            size = new global::System.Drawing.Size(75, 23);
            this.btnUncheckAll.Size = size;
            this.btnUncheckAll.TabIndex = 37;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.ColumnHeader3.Text = "Change Description";
            this.ColumnHeader3.Width = 106;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            size = new global::System.Drawing.Size(711, 574);
            base.ClientSize = size;
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
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmImport_Powerset";
            base.ShowInTaskbar = false;
            this.Text = "Powerset Import";
            this.udRevision.EndInit();
            base.ResumeLayout(false);
        }
        global::System.ComponentModel.IContainer components;
    }
}
