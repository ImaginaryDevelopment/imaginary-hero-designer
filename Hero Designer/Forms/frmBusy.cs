
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
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmBusy));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmBusy);
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