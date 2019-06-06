using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
    // Token: 0x0200004B RID: 75

    public partial class frmMiniList : Form
    {
        // Token: 0x170004DA RID: 1242
        // (get) Token: 0x06000F1F RID: 3871 RVA: 0x00099038 File Offset: 0x00097238
        // (set) Token: 0x06000F20 RID: 3872 RVA: 0x00099050 File Offset: 0x00097250
        internal virtual ctlPopUp pInfo
        {
            get
            {
                return this._pInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pInfo_MouseWheel);
                EventHandler eventHandler = new EventHandler(this.pInfo_MouseEnter);
                if (this._pInfo != null)
                {
                    this._pInfo.MouseWheel -= mouseEventHandler;
                    this._pInfo.MouseEnter -= eventHandler;
                }
                this._pInfo = value;
                if (this._pInfo != null)
                {
                    this._pInfo.MouseWheel += mouseEventHandler;
                    this._pInfo.MouseEnter += eventHandler;
                }
            }
        }

        // Token: 0x170004DB RID: 1243
        // (get) Token: 0x06000F21 RID: 3873 RVA: 0x000990D4 File Offset: 0x000972D4
        // (set) Token: 0x06000F22 RID: 3874 RVA: 0x000990EC File Offset: 0x000972EC
        internal virtual VScrollBar VScrollBar1
        {
            get
            {
                return this._VScrollBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ScrollEventHandler scrollEventHandler = new ScrollEventHandler(this.VScrollBar1_Scroll);
                if (this._VScrollBar1 != null)
                {
                    this._VScrollBar1.Scroll -= scrollEventHandler;
                }
                this._VScrollBar1 = value;
                if (this._VScrollBar1 != null)
                {
                    this._VScrollBar1.Scroll += scrollEventHandler;
                }
            }
        }

        // Token: 0x06000F23 RID: 3875 RVA: 0x00099146 File Offset: 0x00097346
        public frmMiniList(frmMain iParent)
        {
            base.FormClosed += this.frmMiniList_FormClosed;
            base.ResizeEnd += this.frmMiniList_ResizeEnd;
            this.InitializeComponent();
            this.myParent = iParent;
        }

        // Token: 0x06000F25 RID: 3877 RVA: 0x000991D8 File Offset: 0x000973D8
        private void frmMiniList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.UnSetMiniList();
        }

        // Token: 0x06000F26 RID: 3878 RVA: 0x000991E8 File Offset: 0x000973E8
        private void frmMiniList_ResizeEnd(object sender, EventArgs e)
        {
            this.VScrollBar1.Height = base.ClientSize.Height;
            this.VScrollBar1.Left = base.ClientSize.Width - this.VScrollBar1.Width;
            this.pInfo.Width = base.ClientSize.Width - this.VScrollBar1.Width;
        }

        // Token: 0x06000F28 RID: 3880 RVA: 0x0009949D File Offset: 0x0009769D
        private void pInfo_MouseEnter(object sender, EventArgs e)
        {
            this.VScrollBar1.Focus();
        }

        // Token: 0x06000F29 RID: 3881 RVA: 0x000994AC File Offset: 0x000976AC
        private void pInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            int num = Conversions.ToInteger(Operators.AddObject(this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, -1, 1)));
            if (num < this.VScrollBar1.Minimum)
            {
                num = this.VScrollBar1.Minimum;
            }
            if (num > this.VScrollBar1.Maximum - 9)
            {
                num = this.VScrollBar1.Maximum - 9;
            }
            this.VScrollBar1.Value = num;
            this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        // Token: 0x06000F2A RID: 3882 RVA: 0x0009955C File Offset: 0x0009775C
        public void SizeMe()
        {
            this.pInfo.Width = base.ClientSize.Width;
        }

        // Token: 0x06000F2B RID: 3883 RVA: 0x00099584 File Offset: 0x00097784
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * (double)(this.pInfo.lHeight - (float)base.ClientSize.Height));
        }

        // Token: 0x04000627 RID: 1575
        [AccessedThroughProperty("pInfo")]
        private ctlPopUp _pInfo;

        // Token: 0x04000628 RID: 1576
        [AccessedThroughProperty("VScrollBar1")]
        private VScrollBar _VScrollBar1;

        // Token: 0x0400062A RID: 1578
        protected frmMain myParent;
    }
}
