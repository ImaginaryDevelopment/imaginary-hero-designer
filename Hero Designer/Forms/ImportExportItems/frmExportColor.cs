using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmExportColor : Form
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

        void frmExportColor_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.myScheme.SchemeName;
            this.updateColours();
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