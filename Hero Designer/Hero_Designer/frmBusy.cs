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

    
    
        internal virtual Label Message
        {
            get
            {
                return this._Message;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Message = value;
            }
        }


        public frmBusy()
        {
            base.Load += this.frmBusy_Load;
            this.InitializeComponent();
        }


        private void frmBusy_Load(object sender, EventArgs e)
        {
        }


        public void SetMessage(string iMsg)
        {
            if (this.Message.Text != iMsg)
            {
                this.Message.Text = iMsg;
                this.Refresh();
            }
        }


        [AccessedThroughProperty("Message")]
        private Label _Message;
    }
}
