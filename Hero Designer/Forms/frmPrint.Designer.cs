namespace Hero_Designer
{
    public partial class frmPrint
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

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.btnPrinter = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProfileEnh = new System.Windows.Forms.CheckBox();
            this.rbProfileNone = new System.Windows.Forms.RadioButton();
            this.rbProfileLong = new System.Windows.Forms.RadioButton();
            this.rbProfileShort = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrintHistoryEnh = new System.Windows.Forms.CheckBox();
            this.chkPrintHistory = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgSetup = new System.Windows.Forms.PageSetupDialog();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.btnLayout = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();

            this.btnPrinter.Location = new System.Drawing.Point(328, 12);
            this.btnPrinter.Name = "btnPrinter";

            this.btnPrinter.Size = new System.Drawing.Size(123, 23);
            this.btnPrinter.TabIndex = 1;
            this.btnPrinter.Text = "Properties...";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.chkProfileEnh);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.rbProfileNone);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.rbProfileLong);
            this.GroupBox1.Controls.Add((System.Windows.Forms.Control)this.rbProfileShort);

            this.GroupBox1.Location = new System.Drawing.Point(12, 38);
            this.GroupBox1.Name = "GroupBox1";

            this.GroupBox1.Size = new System.Drawing.Size(247, 102);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Profile:";
            this.chkProfileEnh.Checked = true;
            this.chkProfileEnh.CheckState = System.Windows.Forms.CheckState.Checked;

            this.chkProfileEnh.Location = new System.Drawing.Point(110, 45);
            this.chkProfileEnh.Name = "chkProfileEnh";

            this.chkProfileEnh.Size = new System.Drawing.Size(131, 20);
            this.chkProfileEnh.TabIndex = 3;
            this.chkProfileEnh.Text = "Show Enhancements";
            this.chkProfileEnh.UseVisualStyleBackColor = true;
            this.rbProfileNone.Checked = true;

            this.rbProfileNone.Location = new System.Drawing.Point(6, 19);
            this.rbProfileNone.Name = "rbProfileNone";

            this.rbProfileNone.Size = new System.Drawing.Size(200, 20);
            this.rbProfileNone.TabIndex = 2;
            this.rbProfileNone.TabStop = true;
            this.rbProfileNone.Text = "Do Not Print";
            this.rbProfileNone.UseVisualStyleBackColor = true;

            this.rbProfileLong.Location = new System.Drawing.Point(6, 71);
            this.rbProfileLong.Name = "rbProfileLong";

            this.rbProfileLong.Size = new System.Drawing.Size(200, 20);
            this.rbProfileLong.TabIndex = 1;
            this.rbProfileLong.Text = "Multi-Page (Long Format)";
            this.rbProfileLong.UseVisualStyleBackColor = true;

            this.rbProfileShort.Location = new System.Drawing.Point(6, 45);
            this.rbProfileShort.Name = "rbProfileShort";

            this.rbProfileShort.Size = new System.Drawing.Size(98, 20);
            this.rbProfileShort.TabIndex = 0;
            this.rbProfileShort.Text = "Single Page";
            this.rbProfileShort.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add((System.Windows.Forms.Control)this.chkPrintHistoryEnh);
            this.GroupBox2.Controls.Add((System.Windows.Forms.Control)this.chkPrintHistory);

            this.GroupBox2.Location = new System.Drawing.Point(265, 67);
            this.GroupBox2.Name = "GroupBox2";

            this.GroupBox2.Size = new System.Drawing.Size(186, 73);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Level History:";

            this.chkPrintHistoryEnh.Location = new System.Drawing.Point(21, 45);
            this.chkPrintHistoryEnh.Name = "chkPrintHistoryEnh";

            this.chkPrintHistoryEnh.Size = new System.Drawing.Size(159, 20);
            this.chkPrintHistoryEnh.TabIndex = 1;
            this.chkPrintHistoryEnh.Text = "Show Invention Levels";
            this.chkPrintHistoryEnh.UseVisualStyleBackColor = true;

            this.chkPrintHistory.Location = new System.Drawing.Point(6, 19);
            this.chkPrintHistory.Name = "chkPrintHistory";

            this.chkPrintHistory.Size = new System.Drawing.Size(164, 20);
            this.chkPrintHistory.TabIndex = 0;
            this.chkPrintHistory.Text = "Print History Page";
            this.chkPrintHistory.UseVisualStyleBackColor = true;

            this.btnPrint.Location = new System.Drawing.Point(107, 145);
            this.btnPrint.Name = "btnPrint";

            this.btnPrint.Size = new System.Drawing.Size(90, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.btnCancel.Location = new System.Drawing.Point(203, 145);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.dlgSetup.AllowMargins = false;
            this.dlgSetup.AllowOrientation = false;
            this.dlgSetup.EnableMetric = true;
            this.lblPrinter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblPrinter.Location = new System.Drawing.Point(12, 12);
            this.lblPrinter.Name = "lblPrinter";

            this.lblPrinter.Size = new System.Drawing.Size(310, 23);
            this.lblPrinter.TabIndex = 7;
            this.lblPrinter.Text = "No Printer";
            this.lblPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnLayout.Location = new System.Drawing.Point(327, 38);
            this.btnLayout.Name = "btnLayout";

            this.btnLayout.Size = new System.Drawing.Size(123, 23);
            this.btnLayout.TabIndex = 8;
            this.btnLayout.Text = "Layout...";
            this.btnLayout.UseVisualStyleBackColor = true;
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btnPrint;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btnCancel;

            this.ClientSize = new System.Drawing.Size(462, 180);
            this.Controls.Add((System.Windows.Forms.Control)this.btnLayout);
            this.Controls.Add((System.Windows.Forms.Control)this.lblPrinter);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnPrint);
            this.Controls.Add((System.Windows.Forms.Control)this.GroupBox2);
            this.Controls.Add((System.Windows.Forms.Control)this.GroupBox1);
            this.Controls.Add((System.Windows.Forms.Control)this.btnPrinter);
            this.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmPrint);
            this.Text = "Print";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnCancel.Click += btnCancel_Click;
                this.btnLayout.Click += btnLayout_Click;
                this.btnPrint.Click += btnPrint_Click;
                this.btnPrinter.Click += btnPrinter_Click;
                this.chkPrintHistory.CheckedChanged += chkPrintHistory_CheckedChanged;
                this.rbProfileShort.CheckedChanged += rbProfileShort_CheckedChanged;
            }
            // finished with events
            this.ResumeLayout(false);
        }
        #endregion
    }
}