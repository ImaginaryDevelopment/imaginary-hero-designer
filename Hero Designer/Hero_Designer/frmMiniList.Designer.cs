namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmMiniList : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmMiniList));
            this.pInfo = new global::midsControls.ctlPopUp();
            this.VScrollBar1 = new global::System.Windows.Forms.VScrollBar();
            base.SuspendLayout();
            this.pInfo.BXHeight = 2048;
            this.pInfo.ColumnPosition = 0.5f;
            this.pInfo.ColumnRight = true;
            this.pInfo.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            this.pInfo.InternalPadding = 3;
            global::System.Drawing.Point point = new global::System.Drawing.Point(0, 0);
            this.pInfo.Location = point;
            this.pInfo.Name = "pInfo";
            this.pInfo.ScrollY = 0f;
            this.pInfo.SectionPadding = 8;
            global::System.Drawing.Size size = new global::System.Drawing.Size(230, 227);
            this.pInfo.Size = size;
            this.pInfo.TabIndex = 0;
            point = new global::System.Drawing.Point(233, 0);
            this.VScrollBar1.Location = point;
            this.VScrollBar1.Name = "VScrollBar1";
            size = new global::System.Drawing.Size(17, 284);
            this.VScrollBar1.Size = size;
            this.VScrollBar1.TabIndex = 1;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = global::System.Drawing.Color.Black;
            size = new global::System.Drawing.Size(249, 284);
            base.ClientSize = size;
            base.Controls.Add(this.VScrollBar1);
            base.Controls.Add(this.pInfo);
            this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            size = new global::System.Drawing.Size(600, 600);
            this.MaximumSize = size;
            size = new global::System.Drawing.Size(100, 150);
            this.MinimumSize = size;
            base.Name = "frmMiniList";
            this.Text = "Mini List";
            base.TopMost = true;
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components;
    }
}
