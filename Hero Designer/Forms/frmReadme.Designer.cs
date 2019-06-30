namespace Hero_Designer
{
    public partial class frmReadme
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

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmReadme));
            this.rtfRead = new System.Windows.Forms.RichTextBox();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.pbBottom = new System.Windows.Forms.PictureBox();
            this.btnClose = new midsControls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)this.pbBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pbBottom).BeginInit();
            this.SuspendLayout();
            this.rtfRead.BackColor = System.Drawing.Color.White;
            this.rtfRead.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtfRead.ForeColor = System.Drawing.Color.Black;

            this.rtfRead.Location = new System.Drawing.Point(12, 31);
            this.rtfRead.Name = "rtfRead";
            this.rtfRead.ReadOnly = true;
            this.rtfRead.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;

            this.rtfRead.Size = new System.Drawing.Size(616, 409);
            this.rtfRead.TabIndex = 0;
            this.rtfRead.Text = "";
            this.pbBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBackground.Image = (System.Drawing.Image)componentResourceManager.GetObject("pbBackground.Image");

            this.pbBackground.Location = new System.Drawing.Point(0, 0);
            this.pbBackground.Name = "pbBackground";

            this.pbBackground.Size = new System.Drawing.Size(642, 41);
            this.pbBackground.TabIndex = 101;
            this.pbBackground.TabStop = false;
            this.pbBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBottom.Image = (System.Drawing.Image)componentResourceManager.GetObject("pbBottom.Image");

            this.pbBottom.Location = new System.Drawing.Point(0, 427);
            this.pbBottom.Name = "pbBottom";

            this.pbBottom.Size = new System.Drawing.Size(642, 53);
            this.pbBottom.TabIndex = 102;
            this.pbBottom.TabStop = false;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(60, 143, 233);
            this.btnClose.Checked = false;
            this.btnClose.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);

            this.btnClose.KnockoutLocationPoint = new System.Drawing.Point(0, 0);

            this.btnClose.Location = new System.Drawing.Point(268, 449);
            this.btnClose.Name = "btnClose";

            this.btnClose.Size = new System.Drawing.Size(105, 22);
            this.btnClose.TabIndex = 100;
            this.btnClose.TextOff = "Close";
            this.btnClose.TextOn = "Alt Text";
            this.btnClose.Toggle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;

            this.ClientSize = new System.Drawing.Size(642, 480);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClose);
            this.Controls.Add((System.Windows.Forms.Control)this.rtfRead);
            this.Controls.Add((System.Windows.Forms.Control)this.pbBottom);
            this.Controls.Add((System.Windows.Forms.Control)this.pbBackground);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");

            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = nameof(frmReadme);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Readme / Help";
            ((System.ComponentModel.ISupportInitialize)this.pbBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pbBottom).EndInit();
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {

                // btnClose events
                this.btnClose.Load += btnClose_Load;
                this.btnClose.ButtonClicked += btnClose_ButtonClicked;


                // pbBackground events
                this.pbBackground.MouseMove += pbBackground_MouseMove;
                this.pbBackground.MouseDown += pbBackground_MouseDown;
                this.pbBackground.Click += pbBackground_Click;


                // pbBottom events
                this.pbBottom.MouseMove += pbBottom_MouseMove;
                this.pbBottom.MouseDown += pbBottom_MouseDown;

            }
            // finished with events
            this.ResumeLayout(false);
        }
        #endregion
    }
}