
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmMiniList : Form
    {
        ctlPopUp _pInfo;

        VScrollBar VScrollBar1;


        frmMain myParent;
        internal ctlPopUp pInfo
        {
            get => _pInfo;
            private set => _pInfo = value;
        }
        public frmMiniList(frmMain iParent)
        {
            this.FormClosed += new FormClosedEventHandler(this.frmMiniList_FormClosed);
            this.ResizeEnd += new EventHandler(this.frmMiniList_ResizeEnd);
            this.InitializeComponent();
            this.myParent = iParent;
        }

        void frmMiniList_FormClosed(object sender, FormClosedEventArgs e)

        {
            this.myParent.UnSetMiniList();
        }

        void frmMiniList_ResizeEnd(object sender, EventArgs e)

        {
            this.VScrollBar1.Height = this.ClientSize.Height;
            this.VScrollBar1.Left = this.ClientSize.Width - this.VScrollBar1.Width;
            this.pInfo.Width = this.ClientSize.Width - this.VScrollBar1.Width;
        }

        [DebuggerStepThrough]

        void pInfo_MouseEnter(object sender, EventArgs e)

        {
            this.VScrollBar1.Focus();
        }

        void pInfo_MouseWheel(object sender, MouseEventArgs e)

        {
            int num = this.VScrollBar1.Value + e.Delta > 0 ? -1 : 1;
            if (num < this.VScrollBar1.Minimum)
                num = this.VScrollBar1.Minimum;
            if (num > this.VScrollBar1.Maximum - 9)
                num = this.VScrollBar1.Maximum - 9;
            this.VScrollBar1.Value = num;
            this.VScrollBar1_Scroll(sender, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        public void SizeMe()
        {
            this.pInfo.Width = this.ClientSize.Width;
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pInfo.ScrollY = (float)(
                (double)this.VScrollBar1.Value /
                (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) *
                ((double)this.pInfo.lHeight - (double)this.ClientSize.Height));
        }
    }
}