
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmBusy : Form
    {
        Label Message;

        public frmBusy()
        {
            InitializeComponent();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmBusy));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            Name = nameof(frmBusy);
        }

        [DebuggerStepThrough]

        public void SetMessage(string iMsg)
        {
            if (Message.Text == iMsg)
                return;
            Message.Text = iMsg;
            Refresh();
        }
    }
}