namespace Hero_Designer
{
    public partial class frmEnhMiniPick
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

            this.lbList = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lbList.Location = new System.Drawing.Point(4, 44);
            this.lbList.Name = "lbList";

            this.lbList.Size = new System.Drawing.Size(172, 160);
            this.lbList.TabIndex = 0;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.btnOK.Location = new System.Drawing.Point(8, 212);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new System.Drawing.Size(168, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";

            this.lblMessage.Location = new System.Drawing.Point(4, 0);
            this.lblMessage.Name = "lblMessage";

            this.lblMessage.Size = new System.Drawing.Size(176, 40);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Please select an item from the list below and click OK";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btnOK;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btnOK;

            this.ClientSize = new System.Drawing.Size(182, 244);
            this.ControlBox = false;
            this.Controls.Add((System.Windows.Forms.Control)this.lblMessage);
            this.Controls.Add((System.Windows.Forms.Control)this.btnOK);
            this.Controls.Add((System.Windows.Forms.Control)this.lbList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmEnhMiniPick);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details";
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnOK.Click += btnOK_Click;

                // lbList events
                this.lbList.DoubleClick += lbList_DoubleClick;
                this.lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;

            }
            // finished with events
            this.ResumeLayout(false);
        }

        #endregion
    }
}