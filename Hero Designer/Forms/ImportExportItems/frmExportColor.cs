
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmExportColor : Form
    {
        Button btnCancel;

        Button btnOK;
        ColorDialog cPicker;

        Label csHeading;

        Label csHO;

        Label csIO;

        Label csLevel;

        Label csPower;

        Label csSet;

        Label csSlots;

        Label csTitle;
        Label Label1;
        Label Label19;
        Label Label20;
        Label Label21;
        Label Label22;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label7;
        Label Label9;
        ToolTip myTip;

        TextBox txtName;

        IContainer components;

        public ExportConfig.ColorScheme myScheme;

        public frmExportColor(ref ExportConfig.ColorScheme iScheme)
        {
            this.Load += new EventHandler(this.frmExportColor_Load);
            this.InitializeComponent();
            this.myScheme.Assign(iScheme);
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.Hide();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void csHeading_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.Heading;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.Heading = this.cPicker.Color;
            this.updateColours();
        }

        void csHO_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.HOColor;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.HOColor = this.cPicker.Color;
            this.updateColours();
        }

        void csIO_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.IOColor;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.IOColor = this.cPicker.Color;
            this.updateColours();
        }

        void csLevel_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.Level;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.Level = this.cPicker.Color;
            this.updateColours();
        }

        void csPower_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.Power;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.Power = this.cPicker.Color;
            this.updateColours();
        }

        void csSet_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.SetColor;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.SetColor = this.cPicker.Color;
            this.updateColours();
        }

        void csSlots_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.Slots;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.Slots = this.cPicker.Color;
            this.updateColours();
        }

        void csTitle_Click(object sender, EventArgs e)

        {
            this.cPicker.Color = this.myScheme.Title;
            if (this.cPicker.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.myScheme.Title = this.cPicker.Color;
            this.updateColours();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void frmExportColor_Load(object sender, EventArgs e)

        {
            this.txtName.Text = this.myScheme.SchemeName;
            this.updateColours();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmExportColor));
            this.myTip = new ToolTip(this.components);
            this.csSlots = new Label();
            this.csLevel = new Label();
            this.csHeading = new Label();
            this.csTitle = new Label();
            this.csIO = new Label();
            this.csSet = new Label();
            this.csHO = new Label();
            this.csPower = new Label();
            this.cPicker = new ColorDialog();
            this.Label21 = new Label();
            this.Label22 = new Label();
            this.Label20 = new Label();
            this.Label19 = new Label();
            this.txtName = new TextBox();
            this.Label1 = new Label();
            this.Label4 = new Label();
            this.Label5 = new Label();
            this.Label7 = new Label();
            this.Label9 = new Label();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.Label3 = new Label();
            this.SuspendLayout();
            this.myTip.AutoPopDelay = 10000;
            this.myTip.InitialDelay = 500;
            this.myTip.ReshowDelay = 100;
            this.csSlots.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csSlots.BorderStyle = BorderStyle.FixedSingle;

            this.csSlots.Location = new Point(128, 164);
            this.csSlots.Name = "csSlots";

            this.csSlots.Size = new Size(52, 16);
            this.csSlots.TabIndex = 17;
            this.myTip.SetToolTip((Control)this.csSlots, "Click here to select the colour for this attribute.");
            this.csLevel.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csLevel.BorderStyle = BorderStyle.FixedSingle;

            this.csLevel.Location = new Point(128, 124);
            this.csLevel.Name = "csLevel";

            this.csLevel.Size = new Size(52, 16);
            this.csLevel.TabIndex = 16;
            this.myTip.SetToolTip((Control)this.csLevel, "Click here to select the colour for this attribute.");
            this.csHeading.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csHeading.BorderStyle = BorderStyle.FixedSingle;

            this.csHeading.Location = new Point(128, 104);
            this.csHeading.Name = "csHeading";

            this.csHeading.Size = new Size(52, 16);
            this.csHeading.TabIndex = 15;
            this.myTip.SetToolTip((Control)this.csHeading, "Click here to select the colour for this attribute.");
            this.csTitle.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csTitle.BorderStyle = BorderStyle.FixedSingle;

            this.csTitle.Location = new Point(128, 84);
            this.csTitle.Name = "csTitle";

            this.csTitle.Size = new Size(52, 16);
            this.csTitle.TabIndex = 14;
            this.myTip.SetToolTip((Control)this.csTitle, "Click here to select the colour for this attribute.");
            this.csIO.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csIO.BorderStyle = BorderStyle.FixedSingle;

            this.csIO.Location = new Point(128, 184);
            this.csIO.Name = "csIO";

            this.csIO.Size = new Size(52, 16);
            this.csIO.TabIndex = 23;
            this.myTip.SetToolTip((Control)this.csIO, "Click here to select the colour for this attribute.");
            this.csSet.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csSet.BorderStyle = BorderStyle.FixedSingle;

            this.csSet.Location = new Point(128, 204);
            this.csSet.Name = "csSet";

            this.csSet.Size = new Size(52, 16);
            this.csSet.TabIndex = 26;
            this.myTip.SetToolTip((Control)this.csSet, "Click here to select the colour for this attribute.");
            this.csHO.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csHO.BorderStyle = BorderStyle.FixedSingle;

            this.csHO.Location = new Point(128, 224);
            this.csHO.Name = "csHO";

            this.csHO.Size = new Size(52, 16);
            this.csHO.TabIndex = 28;
            this.myTip.SetToolTip((Control)this.csHO, "Click here to select the colour for this attribute.");
            this.csPower.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.csPower.BorderStyle = BorderStyle.FixedSingle;

            this.csPower.Location = new Point(128, 144);
            this.csPower.Name = "csPower";

            this.csPower.Size = new Size(52, 16);
            this.csPower.TabIndex = 32;
            this.myTip.SetToolTip((Control)this.csPower, "Click here to select the colour for this attribute.");
            this.cPicker.FullOpen = true;

            this.Label21.Location = new Point(36, 164);
            this.Label21.Name = "Label21";

            this.Label21.Size = new Size(88, 16);
            this.Label21.TabIndex = 13;
            this.Label21.Text = "Normal Slots:";
            this.Label21.TextAlign = ContentAlignment.MiddleRight;

            this.Label22.Location = new Point(36, 124);
            this.Label22.Name = "Label22";

            this.Label22.Size = new Size(88, 16);
            this.Label22.TabIndex = 12;
            this.Label22.Text = "Levels:";
            this.Label22.TextAlign = ContentAlignment.MiddleRight;

            this.Label20.Location = new Point(36, 104);
            this.Label20.Name = "Label20";

            this.Label20.Size = new Size(88, 16);
            this.Label20.TabIndex = 11;
            this.Label20.Text = "Subheadings:";
            this.Label20.TextAlign = ContentAlignment.MiddleRight;

            this.Label19.Location = new Point(36, 84);
            this.Label19.Name = "Label19";

            this.Label19.Size = new Size(88, 16);
            this.Label19.TabIndex = 10;
            this.Label19.Text = "Title Text:";
            this.Label19.TextAlign = ContentAlignment.MiddleRight;

            this.txtName.Location = new Point(72, 8);
            this.txtName.Name = "txtName";

            this.txtName.Size = new Size(124, 20);
            this.txtName.TabIndex = 18;
            this.txtName.Text = "Scheme Name";

            this.Label1.Location = new Point(8, 8);
            this.Label1.Name = "Label1";

            this.Label1.Size = new Size(64, 20);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Name:";
            this.Label1.TextAlign = ContentAlignment.MiddleRight;

            this.Label4.Location = new Point(36, 184);
            this.Label4.Name = "Label4";

            this.Label4.Size = new Size(88, 16);
            this.Label4.TabIndex = 22;
            this.Label4.Text = "Inventions:";
            this.Label4.TextAlign = ContentAlignment.MiddleRight;

            this.Label5.Location = new Point(8, 36);
            this.Label5.Name = "Label5";

            this.Label5.Size = new Size(192, 36);
            this.Label5.TabIndex = 24;
            this.Label5.Text = "Click on a colour box to modify it.";
            this.Label5.TextAlign = ContentAlignment.MiddleCenter;

            this.Label7.Location = new Point(36, 204);
            this.Label7.Name = "Label7";

            this.Label7.Size = new Size(88, 16);
            this.Label7.TabIndex = 25;
            this.Label7.Text = "Sets:";
            this.Label7.TextAlign = ContentAlignment.MiddleRight;

            this.Label9.Location = new Point(36, 224);
            this.Label9.Name = "Label9";

            this.Label9.Size = new Size(88, 16);
            this.Label9.TabIndex = 27;
            this.Label9.Text = "Hami-Os:";
            this.Label9.TextAlign = ContentAlignment.MiddleRight;
            this.btnOK.DialogResult = DialogResult.OK;

            this.btnOK.Location = new Point(128, 256);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "OK";
            this.btnCancel.DialogResult = DialogResult.Cancel;

            this.btnCancel.Location = new Point(44, 256);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";

            this.Label3.Location = new Point(36, 144);
            this.Label3.Name = "Label3";

            this.Label3.Size = new Size(88, 16);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Power Names:";
            this.Label3.TextAlign = ContentAlignment.MiddleRight;
            this.AcceptButton = (IButtonControl)this.btnOK;
            this.AutoScaleMode = AutoScaleMode.None;
            this.CancelButton = (IButtonControl)this.btnCancel;

            this.ClientSize = new Size(210, 292);
            this.Controls.Add((Control)this.csPower);
            this.Controls.Add((Control)this.Label3);
            this.Controls.Add((Control)this.btnCancel);
            this.Controls.Add((Control)this.btnOK);
            this.Controls.Add((Control)this.csHO);
            this.Controls.Add((Control)this.Label9);
            this.Controls.Add((Control)this.csSet);
            this.Controls.Add((Control)this.Label7);
            this.Controls.Add((Control)this.Label5);
            this.Controls.Add((Control)this.csIO);
            this.Controls.Add((Control)this.Label4);
            this.Controls.Add((Control)this.Label1);
            this.Controls.Add((Control)this.txtName);
            this.Controls.Add((Control)this.csSlots);
            this.Controls.Add((Control)this.csLevel);
            this.Controls.Add((Control)this.csHeading);
            this.Controls.Add((Control)this.csTitle);
            this.Controls.Add((Control)this.Label21);
            this.Controls.Add((Control)this.Label22);
            this.Controls.Add((Control)this.Label20);
            this.Controls.Add((Control)this.Label19);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmExportColor);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
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

        void txtName_TextChanged(object sender, EventArgs e)

        {
            this.myScheme.SchemeName = this.txtName.Text;
        }

        public void updateColours()
        {
            this.csTitle.BackColor = this.myScheme.Title;
            this.csHeading.BackColor = this.myScheme.Heading;
            this.csLevel.BackColor = this.myScheme.Level;
            this.csSlots.BackColor = this.myScheme.Slots;
            this.csIO.BackColor = this.myScheme.IOColor;
            this.csSet.BackColor = this.myScheme.SetColor;
            this.csHO.BackColor = this.myScheme.HOColor;
            this.csPower.BackColor = this.myScheme.Power;
        }
    }
}
