
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmOptionListDlg : Form
    {
        Button Cancel_Button;
        CheckBox chkRemember;
        ComboBox cmbAction;
        Label lblDescript;

        Button OK_Button;
        TableLayoutPanel TableLayoutPanel1;

        internal bool? remember => chkRemember?.Checked;

        public frmOptionListDlg()
        {
            this.InitializeComponent();
            this.Name = nameof(frmOptionListDlg);
        }

        void Cancel_Button_Click(object sender, EventArgs e)

        {
            this.chkRemember.Checked = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void OK_Button_Click(object sender, EventArgs e)

        {
            this.DialogResult = (DialogResult)(this.cmbAction.SelectedIndex + 2);
            this.Close();
        }

        public void ShowWithOptions(
          bool AllowRemember,
          int DefaultOption,
          string descript,
          params string[] OptionList)
        {
            this.chkRemember.Enabled = AllowRemember;
            this.chkRemember.Visible = AllowRemember;
            this.chkRemember.Checked = false;
            this.lblDescript.Text = descript;
            this.cmbAction.Items.Clear();
            this.cmbAction.Items.AddRange((object[])OptionList);
            if (DefaultOption < this.cmbAction.Items.Count - 1)
                this.cmbAction.SelectedIndex = DefaultOption;
            else
                this.cmbAction.SelectedIndex = 0;
            int num = (int)this.ShowDialog();
        }
    }
}