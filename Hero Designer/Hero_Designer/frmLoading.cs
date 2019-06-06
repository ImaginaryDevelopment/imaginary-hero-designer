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

        // (get) Token: 0x06000CAC RID: 3244 RVA: 0x0007E2F8 File Offset: 0x0007C4F8
        // (set) Token: 0x06000CAD RID: 3245 RVA: 0x0007E310 File Offset: 0x0007C510
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


        // (get) Token: 0x06000CAE RID: 3246 RVA: 0x0007E31C File Offset: 0x0007C51C
        // (set) Token: 0x06000CAF RID: 3247 RVA: 0x0007E334 File Offset: 0x0007C534
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


        // (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0007E340 File Offset: 0x0007C540
        // (set) Token: 0x06000CB1 RID: 3249 RVA: 0x0007E358 File Offset: 0x0007C558
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


        private void tmrOpacity_Tick(object sender, EventArgs e)
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
        private Label _Label1;


        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;


        [AccessedThroughProperty("tmrOpacity")]
        private Timer _tmrOpacity;


        // (Invoke) Token: 0x06000CB8 RID: 3256
        public delegate void SetTextCallback(string text);
    }
}
