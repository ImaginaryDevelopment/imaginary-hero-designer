namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmImportPowerLevels : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImportPowerLevels));
            this.btnClose = new global::System.Windows.Forms.Button();
            this.btnImport = new global::System.Windows.Forms.Button();
            this.Label3 = new global::System.Windows.Forms.Label();
            this.lblFile = new global::System.Windows.Forms.Label();
            this.btnFile = new global::System.Windows.Forms.Button();
            this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
            this.Label8 = new global::System.Windows.Forms.Label();
            this.lblDate = new global::System.Windows.Forms.Label();
            this.udRevision = new global::System.Windows.Forms.NumericUpDown();
            this.udRevision.BeginInit();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(545, 77);
            this.btnClose.Location = point;
            this.btnClose.Name = "btnClose";
            global::System.Drawing.Size size = new global::System.Drawing.Size(86, 23);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(545, 34);
            this.btnImport.Location = point;
            this.btnImport.Name = "btnImport";
            size = new global::System.Drawing.Size(86, 23);
            this.btnImport.Size = size;
            this.btnImport.TabIndex = 24;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(18, -11);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new global::System.Drawing.Size(150, 14);
            this.Label3.Size = size;
            this.Label3.TabIndex = 26;
            this.Label3.Text = "Index:";
            this.lblFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(18, 5);
            this.lblFile.Location = point;
            this.lblFile.Name = "lblFile";
            size = new global::System.Drawing.Size(521, 46);
            this.lblFile.Size = size;
            this.lblFile.TabIndex = 25;
            this.lblFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(545, 5);
            this.btnFile.Location = point;
            this.btnFile.Name = "btnFile";
            size = new global::System.Drawing.Size(86, 23);
            this.btnFile.Size = size;
            this.btnFile.TabIndex = 23;
            this.btnFile.Text = "Browse...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            point = new global::System.Drawing.Point(352, 81);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new global::System.Drawing.Size(65, 18);
            this.Label8.Size = size;
            this.Label8.TabIndex = 48;
            this.Label8.Text = "Revision:";
            this.Label8.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
            point = new global::System.Drawing.Point(15, 81);
            this.lblDate.Location = point;
            this.lblDate.Name = "lblDate";
            size = new global::System.Drawing.Size(175, 18);
            this.lblDate.Size = size;
            this.lblDate.TabIndex = 46;
            this.lblDate.Text = "Date:";
            point = new global::System.Drawing.Point(423, 79);
            this.udRevision.Location = point;
            int[] array = new int[4];
            array[0] = 65535;
            decimal maximum = new decimal(array);
            this.udRevision.Maximum = maximum;
            this.udRevision.Name = "udRevision";
            size = new global::System.Drawing.Size(116, 20);
            this.udRevision.Size = size;
            this.udRevision.TabIndex = 45;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            size = new global::System.Drawing.Size(637, 109);
            base.ClientSize = size;
            base.Controls.Add(this.Label8);
            base.Controls.Add(this.lblDate);
            base.Controls.Add(this.udRevision);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnImport);
            base.Controls.Add(this.Label3);
            base.Controls.Add(this.lblFile);
            base.Controls.Add(this.btnFile);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmImportPowerLevels";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Level Data Import";
            this.udRevision.EndInit();
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components;
    }
}
