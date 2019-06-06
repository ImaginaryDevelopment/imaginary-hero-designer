namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmAccolade : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmAccolade));
            this.Panel1 = new global::System.Windows.Forms.Panel();
            this.VScrollBar1 = new global::System.Windows.Forms.VScrollBar();
            this.PopInfo = new global::midsControls.ctlPopUp();
            this.lblLock = new global::System.Windows.Forms.Label();
            this.ibClose = new global::midsControls.ImageButton();
            this.Panel2 = new global::Hero_Designer.frmIncarnate.CustomPanel();
            this.llRight = new global::midsControls.ListLabelV2();
            this.llLeft = new global::midsControls.ListLabelV2();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            base.SuspendLayout();
            this.Panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel1.Controls.Add(this.VScrollBar1);
            this.Panel1.Controls.Add(this.PopInfo);
            global::System.Drawing.Point point = new global::System.Drawing.Point(12, 174);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            global::System.Drawing.Size size = new global::System.Drawing.Size(414, 189);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 35;
            point = new global::System.Drawing.Point(393, 0);
            this.VScrollBar1.Location = point;
            this.VScrollBar1.Name = "VScrollBar1";
            size = new global::System.Drawing.Size(17, 185);
            this.VScrollBar1.Size = size;
            this.VScrollBar1.TabIndex = 11;
            this.PopInfo.BXHeight = 1024;
            this.PopInfo.ColumnPosition = 0.5f;
            this.PopInfo.ColumnRight = false;
            this.PopInfo.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            this.PopInfo.ForeColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            this.PopInfo.InternalPadding = 3;
            point = new global::System.Drawing.Point(0, 0);
            this.PopInfo.Location = point;
            this.PopInfo.Name = "PopInfo";
            this.PopInfo.ScrollY = 0f;
            this.PopInfo.SectionPadding = 8;
            size = new global::System.Drawing.Size(391, 200);
            this.PopInfo.Size = size;
            this.PopInfo.TabIndex = 9;
            this.lblLock.BackColor = global::System.Drawing.Color.Red;
            this.lblLock.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLock.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            this.lblLock.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(12, 155);
            this.lblLock.Location = point;
            this.lblLock.Name = "lblLock";
            size = new global::System.Drawing.Size(56, 16);
            this.lblLock.Size = size;
            this.lblLock.TabIndex = 69;
            this.lblLock.Text = "[Unlock]";
            this.lblLock.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLock.Visible = false;
            this.ibClose.Checked = false;
            this.ibClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(0, 0);
            this.ibClose.KnockoutLocationPoint = point;
            point = new global::System.Drawing.Point(166, 369);
            this.ibClose.Location = point;
            this.ibClose.Name = "ibClose";
            size = new global::System.Drawing.Size(105, 22);
            this.ibClose.Size = size;
            this.ibClose.TabIndex = 7;
            this.ibClose.TextOff = "Done";
            this.ibClose.TextOn = "Alt Text";
            this.ibClose.Toggle = false;
            this.Panel2.AutoScroll = true;
            this.Panel2.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel2.Controls.Add(this.llRight);
            this.Panel2.Controls.Add(this.llLeft);
            point = new global::System.Drawing.Point(12, 12);
            this.Panel2.Location = point;
            this.Panel2.Name = "Panel2";
            size = new global::System.Drawing.Size(414, 140);
            this.Panel2.Size = size;
            this.Panel2.TabIndex = 126;
            this.Panel2.TabStop = true;
            this.llRight.AutoSize = true;
            this.llRight.Expandable = false;
            this.llRight.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel);
            this.llRight.HighVis = true;
            this.llRight.HoverColor = global::System.Drawing.Color.WhiteSmoke;
            point = new global::System.Drawing.Point(196, 3);
            this.llRight.Location = point;
            this.llRight.MaxHeight = 600;
            this.llRight.Name = "llRight";
            this.llRight.PaddingX = 2;
            this.llRight.PaddingY = 2;
            this.llRight.Scrollable = false;
            this.llRight.ScrollBarColor = global::System.Drawing.Color.Red;
            this.llRight.ScrollBarWidth = 11;
            this.llRight.ScrollButtonColor = global::System.Drawing.Color.FromArgb(192, 0, 0);
            size = new global::System.Drawing.Size(190, 414);
            this.llRight.Size = size;
            size = new global::System.Drawing.Size(190, 120);
            this.llRight.SizeNormal = size;
            this.llRight.SuspendRedraw = false;
            this.llRight.TabIndex = 111;
            this.llLeft.AutoSize = true;
            this.llLeft.Expandable = false;
            this.llLeft.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel);
            this.llLeft.HighVis = true;
            this.llLeft.HoverColor = global::System.Drawing.Color.WhiteSmoke;
            point = new global::System.Drawing.Point(3, 3);
            this.llLeft.Location = point;
            this.llLeft.MaxHeight = 600;
            this.llLeft.Name = "llLeft";
            this.llLeft.PaddingX = 2;
            this.llLeft.PaddingY = 2;
            this.llLeft.Scrollable = false;
            this.llLeft.ScrollBarColor = global::System.Drawing.Color.Red;
            this.llLeft.ScrollBarWidth = 11;
            this.llLeft.ScrollButtonColor = global::System.Drawing.Color.FromArgb(192, 0, 0);
            size = new global::System.Drawing.Size(187, 414);
            this.llLeft.Size = size;
            size = new global::System.Drawing.Size(187, 120);
            this.llLeft.SizeNormal = size;
            this.llLeft.SuspendRedraw = false;
            this.llLeft.TabIndex = 110;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            size = new global::System.Drawing.Size(438, 403);
            base.ClientSize = size;
            base.Controls.Add(this.Panel2);
            base.Controls.Add(this.lblLock);
            base.Controls.Add(this.Panel1);
            base.Controls.Add(this.ibClose);
            this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "frmAccolade";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Powers";
            base.TopMost = true;
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components;


        internal global::Hero_Designer.frmIncarnate.CustomPanel Panel2;
    }
}
