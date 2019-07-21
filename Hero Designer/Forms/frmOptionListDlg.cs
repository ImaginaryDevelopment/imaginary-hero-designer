
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
        public struct ShowWithOptionsResult
        {
            public DialogResult result;
            public bool? remember;
        }

        public static ShowWithOptionsResult ShowWithOptions(
          bool AllowRemember,
          int DefaultOption,
          string descript,
          params string[] OptionList)
        {
            var frm = new frmOptionListDlg();
            frm.chkRemember.Enabled = AllowRemember;
            frm.chkRemember.Visible = AllowRemember;
            frm.chkRemember.Checked = false;
            frm.lblDescript.Text = descript;
            frm.cmbAction.Items.Clear();
            frm.cmbAction.Items.AddRange(OptionList);
            if (DefaultOption < frm.cmbAction.Items.Count - 1)
                frm.cmbAction.SelectedIndex = DefaultOption;
            else
                frm.cmbAction.SelectedIndex = 0;
            var result = frm.ShowDialog();
            return new ShowWithOptionsResult { result = result, remember = frm.remember };
        }
    }
}