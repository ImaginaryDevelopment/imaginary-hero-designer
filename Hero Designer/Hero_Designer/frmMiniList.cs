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


    public partial class frmMiniList : Form
    {

    
    
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


        public frmMiniList(frmMain iParent)
        {
            base.FormClosed += this.frmMiniList_FormClosed;
            base.ResizeEnd += this.frmMiniList_ResizeEnd;
            this.InitializeComponent();
            this.myParent = iParent;
        }


        private void frmMiniList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.UnSetMiniList();
        }


        private void frmMiniList_ResizeEnd(object sender, EventArgs e)
        {
            this.VScrollBar1.Height = base.ClientSize.Height;
            this.VScrollBar1.Left = base.ClientSize.Width - this.VScrollBar1.Width;
            this.pInfo.Width = base.ClientSize.Width - this.VScrollBar1.Width;
        }


        private void pInfo_MouseEnter(object sender, EventArgs e)
        {
            this.VScrollBar1.Focus();
        }


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


        public void SizeMe()
        {
            this.pInfo.Width = base.ClientSize.Width;
        }


        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * (double)(this.pInfo.lHeight - (float)base.ClientSize.Height));
        }


        [AccessedThroughProperty("pInfo")]
        private ctlPopUp _pInfo;


        [AccessedThroughProperty("VScrollBar1")]
        private VScrollBar _VScrollBar1;


        protected frmMain myParent;
    }
}
