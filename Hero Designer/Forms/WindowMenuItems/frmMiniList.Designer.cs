namespace Hero_Designer
{
    public partial class frmMiniList
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

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmMiniList));
            this.pInfo = new midsControls.ctlPopUp();
            this.VScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            this.pInfo.BXHeight = 2048;
            this.pInfo.ColumnPosition = 0.5f;
            this.pInfo.ColumnRight = true;
            this.pInfo.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.pInfo.InternalPadding = 3;

            this.pInfo.Location = new System.Drawing.Point(0, 0);
            this.pInfo.Name = "pInfo";
            this.pInfo.ScrollY = 0.0f;
            this.pInfo.SectionPadding = 8;

            this.pInfo.Size = new System.Drawing.Size(230, 227);
            this.pInfo.TabIndex = 0;

            this.VScrollBar1.Location = new System.Drawing.Point(233, 0);
            this.VScrollBar1.Name = "VScrollBar1";

            this.VScrollBar1.Size = new System.Drawing.Size(17, 284);
            this.VScrollBar1.TabIndex = 1;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;

            this.ClientSize = new System.Drawing.Size(249, 284);
            this.Controls.Add((System.Windows.Forms.Control)this.VScrollBar1);
            this.Controls.Add((System.Windows.Forms.Control)this.pInfo);
            this.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");

            this.MaximumSize = new System.Drawing.Size(600, 600);

            this.MinimumSize = new System.Drawing.Size(100, 150);
            this.Name = nameof(frmMiniList);
            this.Text = "Mini List";
            this.TopMost = true;
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.VScrollBar1.Scroll += VScrollBar1_Scroll;

                // pInfo events
                this.pInfo.MouseWheel += pInfo_MouseWheel;
                this.pInfo.MouseEnter += pInfo_MouseEnter;

            }
            // finished with events
            this.ResumeLayout(false);
        }
        #endregion

    }
}