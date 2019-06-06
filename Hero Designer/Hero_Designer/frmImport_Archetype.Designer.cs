namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmImport_Archetype : global::System.Windows.Forms.Form
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
        private void InitializeComponent()
        {
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_Archetype));
            this.Label8 = new global::System.Windows.Forms.Label();
            this.lblATCount = new global::System.Windows.Forms.Label();
            this.lblATDate = new global::System.Windows.Forms.Label();
            this.udATRevision = new global::System.Windows.Forms.NumericUpDown();
            this.Label6 = new global::System.Windows.Forms.Label();
            this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
            this.lblATFile = new global::System.Windows.Forms.Label();
            this.btnATFile = new global::System.Windows.Forms.Button();
            this.lstImport = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.btnImport = new global::System.Windows.Forms.Button();
            this.btnClose = new global::System.Windows.Forms.Button();
            this.ColumnHeader6 = new global::System.Windows.Forms.ColumnHeader();
            this.udATRevision.BeginInit();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(346, 53);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            global::System.Drawing.Size size = new global::System.Drawing.Size(65, 18);
            this.Label8.Size = size;
            this.Label8.TabIndex = 25;
            this.Label8.Text = "Revision:";
            this.Label8.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
            point = new global::System.Drawing.Point(208, 53);
            this.lblATCount.Location = point;
            this.lblATCount.Name = "lblATCount";
            size = new global::System.Drawing.Size(132, 18);
            this.lblATCount.Size = size;
            this.lblATCount.TabIndex = 24;
            this.lblATCount.Text = "Classes:";
            point = new global::System.Drawing.Point(9, 53);
            this.lblATDate.Location = point;
            this.lblATDate.Name = "lblATDate";
            size = new global::System.Drawing.Size(175, 18);
            this.lblATDate.Size = size;
            this.lblATDate.TabIndex = 23;
            this.lblATDate.Text = "Date:";
            point = new global::System.Drawing.Point(417, 51);
            this.udATRevision.Location = point;
            int[] array = new int[4];
            array[0] = 65535;
            decimal maximum = new decimal(array);
            this.udATRevision.Maximum = maximum;
            this.udATRevision.Name = "udATRevision";
            size = new global::System.Drawing.Size(116, 20);
            this.udATRevision.Size = size;
            this.udATRevision.TabIndex = 22;
            point = new global::System.Drawing.Point(12, 9);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new global::System.Drawing.Size(150, 14);
            this.Label6.Size = size;
            this.Label6.TabIndex = 21;
            this.Label6.Text = "Class Definition File:";
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            this.lblATFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(12, 25);
            this.lblATFile.Location = point;
            this.lblATFile.Name = "lblATFile";
            size = new global::System.Drawing.Size(521, 23);
            this.lblATFile.Size = size;
            this.lblATFile.TabIndex = 20;
            this.lblATFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(539, 25);
            this.btnATFile.Location = point;
            this.btnATFile.Name = "btnATFile";
            size = new global::System.Drawing.Size(165, 23);
            this.btnATFile.Size = size;
            this.btnATFile.TabIndex = 19;
            this.btnATFile.Text = "Load / Re-Load";
            this.btnATFile.UseVisualStyleBackColor = true;
            this.lstImport.CheckBoxes = true;
            this.lstImport.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader3,
                this.ColumnHeader4,
                this.ColumnHeader5,
                this.ColumnHeader6
            });
            this.lstImport.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            point = new global::System.Drawing.Point(12, 77);
            this.lstImport.Location = point;
            this.lstImport.Name = "lstImport";
            size = new global::System.Drawing.Size(600, 309);
            this.lstImport.Size = size;
            this.lstImport.TabIndex = 26;
            this.lstImport.UseCompatibleStateImageBehavior = false;
            this.lstImport.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Class";
            this.ColumnHeader1.Width = 128;
            this.ColumnHeader2.Text = "ClassID";
            this.ColumnHeader2.Width = 165;
            this.ColumnHeader3.Text = "Playable";
            this.ColumnHeader3.Width = 72;
            this.ColumnHeader4.Text = "New";
            this.ColumnHeader4.Width = 71;
            this.ColumnHeader5.Text = "Modified";
            point = new global::System.Drawing.Point(618, 77);
            this.btnImport.Location = point;
            this.btnImport.Name = "btnImport";
            size = new global::System.Drawing.Size(86, 22);
            this.btnImport.Size = size;
            this.btnImport.TabIndex = 27;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(618, 363);
            this.btnClose.Location = point;
            this.btnClose.Name = "btnClose";
            size = new global::System.Drawing.Size(86, 23);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.ColumnHeader6.Text = "Change Description";
            this.ColumnHeader6.Width = 98;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            size = new global::System.Drawing.Size(711, 400);
            base.ClientSize = size;
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnImport);
            base.Controls.Add(this.lstImport);
            base.Controls.Add(this.Label8);
            base.Controls.Add(this.lblATCount);
            base.Controls.Add(this.lblATDate);
            base.Controls.Add(this.udATRevision);
            base.Controls.Add(this.Label6);
            base.Controls.Add(this.lblATFile);
            base.Controls.Add(this.btnATFile);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmImport_Archetype";
            base.ShowInTaskbar = false;
            this.Text = "Archetype Class Import";
            this.udATRevision.EndInit();
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components;
    }
}
