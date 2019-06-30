namespace Hero_Designer
{
    public partial class FrmInputLevel
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

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputLevel));
            this.udLevel = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.udLevel.BeginInit();
            this.SuspendLayout();

            this.udLevel.Location = new System.Drawing.Point(41, 42);
            System.Decimal num = new System.Decimal(new int[4]
            {
        50,
        0,
        0,
        0
            });
            this.udLevel.Maximum = num;
            num = new System.Decimal(new int[4] { 10, 0, 0, 0 });
            this.udLevel.Minimum = num;
            this.udLevel.Name = "udLevel";

            this.udLevel.Size = new System.Drawing.Size(120, 20);
            this.udLevel.TabIndex = 0;
            this.udLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            num = new System.Decimal(new int[4] { 50, 0, 0, 0 });
            this.udLevel.Value = num;

            this.Label1.Location = new System.Drawing.Point(3, 9);
            this.Label1.Name = "Label1";

            this.Label1.Size = new System.Drawing.Size(188, 21);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Please input the level to respec to:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.btnOK.Location = new System.Drawing.Point(64, 77);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btnOK;

            this.ClientSize = new System.Drawing.Size(203, 114);
            this.Controls.Add((System.Windows.Forms.Control)this.btnOK);
            this.Controls.Add((System.Windows.Forms.Control)this.Label1);
            this.Controls.Add((System.Windows.Forms.Control)this.udLevel);
            this.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(FrmInputLevel);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respec Helper";
            this.udLevel.EndInit();
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnOK.Click += btnOK_Click;
                this.udLevel.Leave += udLevel_Leave;
            }
            // finished with events
            this.ResumeLayout(false);
        }


        #endregion
    }
}