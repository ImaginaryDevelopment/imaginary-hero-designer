using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{

    public partial class frmZStatus : Form
    {

        // (get) Token: 0x060013BD RID: 5053 RVA: 0x000C9A68 File Offset: 0x000C7C68
        // (set) Token: 0x060013BE RID: 5054 RVA: 0x000C9A80 File Offset: 0x000C7C80
        internal virtual Label lblStatus1
        {
            get
            {
                return this._lblStatus1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblStatus1 = value;
            }
        }


        // (get) Token: 0x060013BF RID: 5055 RVA: 0x000C9A8C File Offset: 0x000C7C8C
        // (set) Token: 0x060013C0 RID: 5056 RVA: 0x000C9AA4 File Offset: 0x000C7CA4
        internal virtual Label lblStatus2
        {
            get
            {
                return this._lblStatus2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblStatus2 = value;
            }
        }


        // (get) Token: 0x060013C1 RID: 5057 RVA: 0x000C9AB0 File Offset: 0x000C7CB0
        // (set) Token: 0x060013C2 RID: 5058 RVA: 0x000C9AC8 File Offset: 0x000C7CC8
        internal virtual Label lblTitle
        {
            get
            {
                return this._lblTitle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblTitle = value;
            }
        }


        // (get) Token: 0x060013C3 RID: 5059 RVA: 0x000C9AD4 File Offset: 0x000C7CD4
        // (set) Token: 0x060013C4 RID: 5060 RVA: 0x000C9AEC File Offset: 0x000C7CEC
        internal virtual PictureBox PictureBox1
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


        public frmZStatus()
        {
            base.VisibleChanged += this.frmZStatus_VisibleChanged;
            this.InitializeComponent();
        }


        private void frmZStatus_VisibleChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }


        public void SetText1(string text)
        {
            if (this.lblStatus1.InvokeRequired)
            {
                frmZStatus.SetTextCallback method = new frmZStatus.SetTextCallback(this.SetText1);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                this.lblStatus1.Text = text;
            }
        }


        public void SetText2(string text)
        {
            if (this.lblStatus2.InvokeRequired)
            {
                frmZStatus.SetTextCallback method = new frmZStatus.SetTextCallback(this.SetText1);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                this.lblStatus2.Text = text;
            }
        }


        [AccessedThroughProperty("lblStatus1")]
        private Label _lblStatus1;


        [AccessedThroughProperty("lblStatus2")]
        private Label _lblStatus2;


        [AccessedThroughProperty("lblTitle")]
        private Label _lblTitle;


        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;


        // (Invoke) Token: 0x060013CC RID: 5068
        public delegate void SetTextCallback(string text);
    }
}
