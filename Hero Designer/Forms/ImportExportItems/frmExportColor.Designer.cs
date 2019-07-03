namespace Hero_Designer
{
    public partial class frmExportColor
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

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmExportColor));
            this.myTip = new System.Windows.Forms.ToolTip(this.components);
            this.csSlots = new System.Windows.Forms.Label();
            this.csLevel = new System.Windows.Forms.Label();
            this.csHeading = new System.Windows.Forms.Label();
            this.csTitle = new System.Windows.Forms.Label();
            this.csIO = new System.Windows.Forms.Label();
            this.csSet = new System.Windows.Forms.Label();
            this.csHO = new System.Windows.Forms.Label();
            this.csPower = new System.Windows.Forms.Label();
            this.cPicker = new System.Windows.Forms.ColorDialog();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.myTip.AutoPopDelay = 10000;
            this.myTip.InitialDelay = 500;
            this.myTip.ReshowDelay = 100;
            this.csSlots.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csSlots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csSlots.Location = new System.Drawing.Point(128, 164);
            this.csSlots.Name = "csSlots";

            this.csSlots.Size = new System.Drawing.Size(52, 16);
            this.csSlots.TabIndex = 17;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csSlots, "Click here to select the colour for this attribute.");
            this.csLevel.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csLevel.Location = new System.Drawing.Point(128, 124);
            this.csLevel.Name = "csLevel";

            this.csLevel.Size = new System.Drawing.Size(52, 16);
            this.csLevel.TabIndex = 16;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csLevel, "Click here to select the colour for this attribute.");
            this.csHeading.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csHeading.Location = new System.Drawing.Point(128, 104);
            this.csHeading.Name = "csHeading";

            this.csHeading.Size = new System.Drawing.Size(52, 16);
            this.csHeading.TabIndex = 15;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csHeading, "Click here to select the colour for this attribute.");
            this.csTitle.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csTitle.Location = new System.Drawing.Point(128, 84);
            this.csTitle.Name = "csTitle";

            this.csTitle.Size = new System.Drawing.Size(52, 16);
            this.csTitle.TabIndex = 14;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csTitle, "Click here to select the colour for this attribute.");
            this.csIO.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csIO.Location = new System.Drawing.Point(128, 184);
            this.csIO.Name = "csIO";

            this.csIO.Size = new System.Drawing.Size(52, 16);
            this.csIO.TabIndex = 23;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csIO, "Click here to select the colour for this attribute.");
            this.csSet.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csSet.Location = new System.Drawing.Point(128, 204);
            this.csSet.Name = "csSet";

            this.csSet.Size = new System.Drawing.Size(52, 16);
            this.csSet.TabIndex = 26;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csSet, "Click here to select the colour for this attribute.");
            this.csHO.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csHO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csHO.Location = new System.Drawing.Point(128, 224);
            this.csHO.Name = "csHO";

            this.csHO.Size = new System.Drawing.Size(52, 16);
            this.csHO.TabIndex = 28;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csHO, "Click here to select the colour for this attribute.");
            this.csPower.BackColor = System.Drawing.Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.csPower.Location = new System.Drawing.Point(128, 144);
            this.csPower.Name = "csPower";

            this.csPower.Size = new System.Drawing.Size(52, 16);
            this.csPower.TabIndex = 32;
            this.myTip.SetToolTip((System.Windows.Forms.Control)this.csPower, "Click here to select the colour for this attribute.");
            this.cPicker.FullOpen = true;

            this.Label21.Location = new System.Drawing.Point(36, 164);
            this.Label21.Name = "Label21";

            this.Label21.Size = new System.Drawing.Size(88, 16);
            this.Label21.TabIndex = 13;
            this.Label21.Text = "Normal Slots:";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label22.Location = new System.Drawing.Point(36, 124);
            this.Label22.Name = "Label22";

            this.Label22.Size = new System.Drawing.Size(88, 16);
            this.Label22.TabIndex = 12;
            this.Label22.Text = "Levels:";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label20.Location = new System.Drawing.Point(36, 104);
            this.Label20.Name = "Label20";

            this.Label20.Size = new System.Drawing.Size(88, 16);
            this.Label20.TabIndex = 11;
            this.Label20.Text = "Subheadings:";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label19.Location = new System.Drawing.Point(36, 84);
            this.Label19.Name = "Label19";

            this.Label19.Size = new System.Drawing.Size(88, 16);
            this.Label19.TabIndex = 10;
            this.Label19.Text = "Title Text:";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtName.Location = new System.Drawing.Point(72, 8);
            this.txtName.Name = "txtName";

            this.txtName.Size = new System.Drawing.Size(124, 20);
            this.txtName.TabIndex = 18;
            this.txtName.Text = "Scheme Name";

            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";

            this.Label1.Size = new System.Drawing.Size(64, 20);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Name:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label4.Location = new System.Drawing.Point(36, 184);
            this.Label4.Name = "Label4";

            this.Label4.Size = new System.Drawing.Size(88, 16);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Inventions:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label5.Location = new System.Drawing.Point(8, 36);
            this.Label5.Name = "Label5";

            this.Label5.Size = new System.Drawing.Size(192, 36);
            this.Label5.TabIndex = 24;
            this.Label5.Text = "Click on a colour box to modify it.";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.Label7.Location = new System.Drawing.Point(36, 204);
            this.Label7.Name = "Label7";

            this.Label7.Size = new System.Drawing.Size(88, 16);
            this.Label7.TabIndex = 25;
            this.Label7.Text = "Sets:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label9.Location = new System.Drawing.Point(36, 224);
            this.Label9.Name = "Label9";

            this.Label9.Size = new System.Drawing.Size(88, 16);
            this.Label9.TabIndex = 27;
            this.Label9.Text = "Hami-Os:";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.btnOK.Location = new System.Drawing.Point(128, 256);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "OK";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.btnCancel.Location = new System.Drawing.Point(44, 256);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";

            this.Label3.Location = new System.Drawing.Point(36, 144);
            this.Label3.Name = "Label3";

            this.Label3.Size = new System.Drawing.Size(88, 16);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Power Names:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btnCancel;

            this.ClientSize = new System.Drawing.Size(210, 292);
            this.Controls.Add((System.Windows.Forms.Control)this.csPower);
            this.Controls.Add((System.Windows.Forms.Control)this.Label3);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnOK);
            this.Controls.Add((System.Windows.Forms.Control)this.csHO);
            this.Controls.Add((System.Windows.Forms.Control)this.Label9);
            this.Controls.Add((System.Windows.Forms.Control)this.csSet);
            this.Controls.Add((System.Windows.Forms.Control)this.Label7);
            this.Controls.Add((System.Windows.Forms.Control)this.Label5);
            this.Controls.Add((System.Windows.Forms.Control)this.csIO);
            this.Controls.Add((System.Windows.Forms.Control)this.Label4);
            this.Controls.Add((System.Windows.Forms.Control)this.Label1);
            this.Controls.Add((System.Windows.Forms.Control)this.txtName);
            this.Controls.Add((System.Windows.Forms.Control)this.csSlots);
            this.Controls.Add((System.Windows.Forms.Control)this.csLevel);
            this.Controls.Add((System.Windows.Forms.Control)this.csHeading);
            this.Controls.Add((System.Windows.Forms.Control)this.csTitle);
            this.Controls.Add((System.Windows.Forms.Control)this.Label21);
            this.Controls.Add((System.Windows.Forms.Control)this.Label22);
            this.Controls.Add((System.Windows.Forms.Control)this.Label20);
            this.Controls.Add((System.Windows.Forms.Control)this.Label19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmExportColor);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Colour Scheme Editor";
            this.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnCancel.Click += btnCancel_Click;
                this.btnOK.Click += btnOK_Click;
                this.csHO.Click += csHO_Click;
                this.csHeading.Click += csHeading_Click;
                this.csIO.Click += csIO_Click;
                this.csLevel.Click += csLevel_Click;
                this.csPower.Click += csPower_Click;
                this.csSet.Click += csSet_Click;
                this.csSlots.Click += csSlots_Click;
                this.csTitle.Click += csTitle_Click;
                this.txtName.TextChanged += txtName_TextChanged;
            }
            // finished with events
            this.PerformLayout();
        }
        #endregion
    }
}