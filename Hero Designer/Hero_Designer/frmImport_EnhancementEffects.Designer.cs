namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmImport_EnhancementEffects : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_EnhancementEffects));
            this.btnClose = new global::System.Windows.Forms.Button();
            this.btnImport = new global::System.Windows.Forms.Button();
            this.lblFile = new global::System.Windows.Forms.Label();
            this.btnFile = new global::System.Windows.Forms.Button();
            this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(539, 81);
            this.btnClose.Location = point;
            this.btnClose.Name = "btnClose";
            global::System.Drawing.Size size = new global::System.Drawing.Size(86, 23);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(539, 38);
            this.btnImport.Location = point;
            this.btnImport.Name = "btnImport";
            size = new global::System.Drawing.Size(86, 23);
            this.btnImport.Size = size;
            this.btnImport.TabIndex = 54;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.lblFile.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(12, 9);
            this.lblFile.Location = point;
            this.lblFile.Name = "lblFile";
            size = new global::System.Drawing.Size(521, 46);
            this.lblFile.Size = size;
            this.lblFile.TabIndex = 55;
            this.lblFile.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(539, 9);
            this.btnFile.Location = point;
            this.btnFile.Name = "btnFile";
            size = new global::System.Drawing.Size(86, 23);
            this.btnFile.Size = size;
            this.btnFile.TabIndex = 53;
            this.btnFile.Text = "Browse...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
            base.AutoScaleDimensions = autoScaleDimensions;
            size = new global::System.Drawing.Size(636, 112);
            base.ClientSize = size;
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnImport);
            base.Controls.Add(this.lblFile);
            base.Controls.Add(this.btnFile);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmImport_EnhancementEffects";
            base.ShowInTaskbar = false;
            this.Text = "Import Enhancement Effects";
            base.ResumeLayout(false);
        }
        global::System.ComponentModel.IContainer components;
    }
}
