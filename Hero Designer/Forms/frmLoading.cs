
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
            this.Text = nameof(frmLoading);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.PictureBox1.Image = (System.Drawing.Image)componentResourceManager.GetObject("PictureBox1.Image");
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmLoading);
        }

        public void SetMessage(string text)
        {
            if (this.Label1.InvokeRequired)
            {
                this.Invoke(new SetTextCallback(this.SetMessage), text);
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