using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    // Token: 0x0200005C RID: 92
    public partial class frmZStatus : Form
    {
        // Token: 0x1700065A RID: 1626
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

        // Token: 0x1700065B RID: 1627
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

        // Token: 0x1700065C RID: 1628
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

        // Token: 0x1700065D RID: 1629
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

        // Token: 0x060013C5 RID: 5061 RVA: 0x000C9AF6 File Offset: 0x000C7CF6
        public frmZStatus()
        {
            base.VisibleChanged += this.frmZStatus_VisibleChanged;
            this.InitializeComponent();
        }

        // Token: 0x060013C7 RID: 5063 RVA: 0x000C9B54 File Offset: 0x000C7D54
        private void frmZStatus_VisibleChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        // Token: 0x060013C9 RID: 5065 RVA: 0x000C9F20 File Offset: 0x000C8120
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

        // Token: 0x060013CA RID: 5066 RVA: 0x000C9F74 File Offset: 0x000C8174
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

        // Token: 0x040007E3 RID: 2019
        [AccessedThroughProperty("lblStatus1")]
        private Label _lblStatus1;

        // Token: 0x040007E4 RID: 2020
        [AccessedThroughProperty("lblStatus2")]
        private Label _lblStatus2;

        // Token: 0x040007E5 RID: 2021
        [AccessedThroughProperty("lblTitle")]
        private Label _lblTitle;

        // Token: 0x040007E6 RID: 2022
        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;

        // Token: 0x0200005D RID: 93
        // (Invoke) Token: 0x060013CC RID: 5068
        public delegate void SetTextCallback(string text);
    }
}
