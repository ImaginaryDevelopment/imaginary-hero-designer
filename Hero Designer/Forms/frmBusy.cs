
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmBusy : Form
    {
        Label Message;


        public frmBusy()
        {
            this.Load += new EventHandler(this.frmBusy_Load);
            this.InitializeComponent();
        }

        void frmBusy_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]

        public void SetMessage(string iMsg)
        {
            if (!(this.Message.Text != iMsg))
                return;
            this.Message.Text = iMsg;
            this.Refresh();
        }
    }
}