
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using midsControls;

namespace Hero_Designer
{
    public partial class frmMiniList : Form
    {
        ctlPopUp pInfo;

        VScrollBar VScrollBar1;

        readonly frmMain myParent;
        internal ctlPopUp PInfo
        {
            get => pInfo;
            private set => pInfo = value;
        }

        public frmMiniList(frmMain iParent)
        {
            FormClosed += frmMiniList_FormClosed;
            ResizeEnd += frmMiniList_ResizeEnd;
            InitializeComponent();
            VScrollBar1.Scroll += VScrollBar1_Scroll;
            PInfo.MouseWheel += pInfo_MouseWheel;
            PInfo.MouseEnter += pInfo_MouseEnter;
            Name = nameof(frmMiniList);
            var componentResourceManager = new ComponentResourceManager(typeof(frmMiniList));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            myParent = iParent;
        }

        void frmMiniList_FormClosed(object sender, FormClosedEventArgs e)
        {
            myParent.UnSetMiniList();
        }

        void frmMiniList_ResizeEnd(object sender, EventArgs e)
        {
            VScrollBar1.Height = ClientSize.Height;
            VScrollBar1.Left = ClientSize.Width - VScrollBar1.Width;
            PInfo.Width = ClientSize.Width - VScrollBar1.Width;
        }

        void pInfo_MouseEnter(object sender, EventArgs e)
        {
            VScrollBar1.Focus();
        }

        void pInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            int num = VScrollBar1.Value + e.Delta > 0 ? -1 : 1;
            if (num < VScrollBar1.Minimum)
                num = VScrollBar1.Minimum;
            if (num > VScrollBar1.Maximum - 9)
                num = VScrollBar1.Maximum - 9;
            VScrollBar1.Value = num;
            VScrollBar1_Scroll(sender, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        public void SizeMe()
        {
            PInfo.Width = ClientSize.Width;
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            PInfo.ScrollY = (float)(
                VScrollBar1.Value /
                (double)(VScrollBar1.Maximum - VScrollBar1.LargeChange) *
                (PInfo.lHeight - (double)ClientSize.Height));
        }
    }
}