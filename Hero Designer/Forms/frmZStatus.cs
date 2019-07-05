using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmZStatus : Form
    {
        Label lblStatus1;
        Label lblStatus2;
        Label lblTitle;
        PictureBox PictureBox1;

        public frmZStatus()
        {
            this.VisibleChanged += new EventHandler(this.frmZStatus_VisibleChanged);
            this.InitializeComponent();
            this.Name = nameof(frmZStatus);
            var componentResourceManager = new ComponentResourceManager(typeof(frmZStatus));
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.PictureBox1.Image = (Image)componentResourceManager.GetObject("PictureBox1.Image");
        }

        void frmZStatus_VisibleChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        public void SetText1(string text)
        {
            if (this.lblStatus1.InvokeRequired)
                this.Invoke((Delegate)new frmZStatus.SetTextCallback(this.SetText1), text);
            else
                this.lblStatus1.Text = text;
        }

        public void SetText2(string text)
        {
            if (this.lblStatus2.InvokeRequired)
                this.Invoke((Delegate)new frmZStatus.SetTextCallback(this.SetText1), text);
            else
                this.lblStatus2.Text = text;
        }

        public delegate void SetTextCallback(string text);
    }
}