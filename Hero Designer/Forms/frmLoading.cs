
using Base.IO_Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmLoading : Form, IMessager
    {
        Label Label1;

        PictureBox PictureBox1;

        Timer tmrOpacity;

        public frmLoading()
        {
            this.InitializeComponent();
        }

        public void SetMessage(string text)
        {
            if (this.Label1.InvokeRequired)
            {
                this.Invoke((Delegate)new frmLoading.SetTextCallback(this.SetMessage), (object)text);
            }
            else
            {
                if (!(this.Label1.Text != text))
                    return;
                this.Label1.Text = text;
                this.Label1.Refresh();
                this.Refresh();
            }
        }

        void tmrOpacity_Tick(object sender, EventArgs e)

        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.05;
            else
                this.tmrOpacity.Enabled = false;
        }

        public delegate void SetTextCallback(string text);
    }
}