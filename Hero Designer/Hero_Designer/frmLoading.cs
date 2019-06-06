using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.IO_Classes;

namespace Hero_Designer
{

    public partial class frmLoading : Form, IMessager
    {
    
        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
        }
        public PictureBox PictureBox1
        {
            get
            {
                return this._PictureBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox1 = value;
            }
        }
        internal virtual Timer tmrOpacity
        {
            get
            {
                return this._tmrOpacity;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tmrOpacity_Tick);
                if (this._tmrOpacity != null)
                {
                    this._tmrOpacity.Tick -= eventHandler;
                }
                this._tmrOpacity = value;
                if (this._tmrOpacity != null)
                {
                    this._tmrOpacity.Tick += eventHandler;
                }
            }
        }
        public frmLoading()
        {
            this.InitializeComponent();
        }
        public void SetMessage(string text)
        {
            if (this.Label1.InvokeRequired)
            {
                frmLoading.SetTextCallback method = new frmLoading.SetTextCallback(this.SetMessage);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else if (this.Label1.Text != text)
            {
                this.Label1.Text = text;
                this.Label1.Refresh();
                this.Refresh();
            }
        }
        void tmrOpacity_Tick(object sender, EventArgs e)
        {
            if (base.Opacity < 1.0)
            {
                base.Opacity += 0.05;
            }
            else
            {
                this.tmrOpacity.Enabled = false;
            }
        }
        [AccessedThroughProperty("Label1")]
        Label _Label1;
        [AccessedThroughProperty("PictureBox1")]
        PictureBox _PictureBox1;
        [AccessedThroughProperty("tmrOpacity")]
        Timer _tmrOpacity;
        // (Invoke) Token: 0x06000CB8 RID: 3256
        public delegate void SetTextCallback(string text);
    }
}
