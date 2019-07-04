
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmEnhMiniPick : Form
    {

        public frmEnhMiniPick()
        {
            this.InitializeComponent();
            this.Name = nameof(frmEnhMiniPick);
        }

        public static int MezPicker(int startIndex)
        {
            Enums.eMez eMez = Enums.eMez.None;
            frmEnhMiniPick frmEnhMiniPick = new frmEnhMiniPick();
            string[] names = Enum.GetNames(eMez.GetType());
            int num1 = names.Length - 1;
            for (int index = 1; index <= num1; ++index)
                frmEnhMiniPick.lbList.Items.Add(names[index]);
            if (startIndex > -1 & startIndex < frmEnhMiniPick.lbList.Items.Count)
                frmEnhMiniPick.lbList.SelectedIndex = startIndex - 1;
            else
                frmEnhMiniPick.lbList.SelectedIndex = 0;
            frmEnhMiniPick.ShowDialog();
            return frmEnhMiniPick.lbList.SelectedIndex + 1;
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void lbList_DoubleClick(object sender, EventArgs e)

        {
            this.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }
    }
}