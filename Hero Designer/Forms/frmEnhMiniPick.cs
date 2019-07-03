
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
        Button btnOK;

        ListBox _lbList;
        Label lblMessage;

        internal ListBox lbList
        {
            get => _lbList;
            private set => _lbList = value;
        }

        public frmEnhMiniPick()
        {
            this.Load += new EventHandler(this.frmEnhMez_Load);
            this.InitializeComponent();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void frmEnhMez_Load(object sender, EventArgs e)

        {
        }

        [DebuggerStepThrough]

        void lbList_DoubleClick(object sender, EventArgs e)

        {
            this.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void lbList_SelectedIndexChanged(object sender, EventArgs e)

        {
        }
    }
}