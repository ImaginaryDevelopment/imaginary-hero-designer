using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmBusy : Form
    {
    
        public frmBusy()
        {
            this.InitializeComponent();
        }
        public void SetMessage(string iMsg)
        {
            if (this.Message.Text != iMsg)
            {
                this.Message.Text = iMsg;
                this.Refresh();
            }
        }
    }
}
