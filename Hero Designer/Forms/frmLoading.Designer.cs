namespace Hero_Designer
{
    public partial class frmLoading
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
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tmrOpacity = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
            this.SuspendLayout();
            this.PictureBox1.Image = (System.Drawing.Image)componentResourceManager.GetObject("PictureBox1.Image");

            this.PictureBox1.Location = new System.Drawing.Point(1, 1);
            this.PictureBox1.Name = "PictureBox1";

            this.PictureBox1.Size = new System.Drawing.Size(515, 75);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);

            this.Label1.Location = new System.Drawing.Point(18, 33);
            this.Label1.Name = "Label1";

            this.Label1.Size = new System.Drawing.Size(480, 35);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Reading data files, please wait.";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tmrOpacity.Enabled = true;
            this.tmrOpacity.Interval = 25;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;

            this.ClientSize = new System.Drawing.Size(517, 77);
            this.Controls.Add((System.Windows.Forms.Control)this.Label1);
            this.Controls.Add((System.Windows.Forms.Control)this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmLoading);
            this.Opacity = 0.25;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = nameof(frmLoading);
            ((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.tmrOpacity.Tick += tmrOpacity_Tick;
            }
            // finished with events
            this.ResumeLayout(false);
        }
        #endregion
    }
}