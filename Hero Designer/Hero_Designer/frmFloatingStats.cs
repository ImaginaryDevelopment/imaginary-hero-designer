using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{

    public partial class frmFloatingStats : Form
    {

    
    
        internal virtual DataView dvFloat
        {
            get
            {
                return this._dvFloat;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.dvFloat_Load);
                DataView.SizeChangeEventHandler changeEventHandler = new DataView.SizeChangeEventHandler(this.dvFloat_SizeChange);
                DataView.FloatChangeEventHandler changeEventHandler2 = new DataView.FloatChangeEventHandler(this.dvFloat_FloatChanged);
                DataView.Unlock_ClickEventHandler clickEventHandler = new DataView.Unlock_ClickEventHandler(this.dvFloat_Unlock);
                DataView.TabChangedEventHandler changedEventHandler = new DataView.TabChangedEventHandler(this.dvFloat_TabChanged);
                DataView.SlotUpdateEventHandler updateEventHandler = new DataView.SlotUpdateEventHandler(this.dvFloat_SlotUpdate);
                DataView.SlotFlipEventHandler flipEventHandler = new DataView.SlotFlipEventHandler(this.dvFloat_SlotFlip);
                if (this._dvFloat != null)
                {
                    this._dvFloat.Load -= eventHandler;
                    this._dvFloat.SizeChange -= changeEventHandler;
                    this._dvFloat.FloatChange -= changeEventHandler2;
                    this._dvFloat.Unlock_Click -= clickEventHandler;
                    this._dvFloat.TabChanged -= changedEventHandler;
                    this._dvFloat.SlotUpdate -= updateEventHandler;
                    this._dvFloat.SlotFlip -= flipEventHandler;
                }
                this._dvFloat = value;
                if (this._dvFloat != null)
                {
                    this._dvFloat.Load += eventHandler;
                    this._dvFloat.SizeChange += changeEventHandler;
                    this._dvFloat.FloatChange += changeEventHandler2;
                    this._dvFloat.Unlock_Click += clickEventHandler;
                    this._dvFloat.TabChanged += changedEventHandler;
                    this._dvFloat.SlotUpdate += updateEventHandler;
                    this._dvFloat.SlotFlip += flipEventHandler;
                }
            }
        }


        public frmFloatingStats(ref frmMain iOwner)
        {
            base.Load += this.frmFloatingStats_Load;
            base.Closed += this.frmFloatingStats_Closed;
            this.InitializeComponent();
            this.myOwner = iOwner;
        }


        void dvFloat_FloatChanged()
        {
            base.Close();
        }


        void dvFloat_Load(object sender, EventArgs e)
        {
        }


        void dvFloat_SizeChange(Size newSize, bool Compact)
        {
            base.ClientSize = newSize;
        }


        void dvFloat_SlotFlip(int PowerIndex)
        {
            this.myOwner.DataView_SlotFlip(PowerIndex);
        }


        void dvFloat_SlotUpdate()
        {
            this.myOwner.DataView_SlotUpdate();
        }


        void dvFloat_TabChanged(int Index)
        {
            this.myOwner.SetDataViewTab(Index);
        }


        void dvFloat_Unlock()
        {
            this.myOwner.DataViewLocked = false;
            if (this.myOwner.dvLastPower > -1)
            {
                this.myOwner.Info_Power(this.myOwner.dvLastPower, this.myOwner.dvLastEnh, this.myOwner.dvLastNoLev, this.myOwner.DataViewLocked);
            }
        }


        void frmFloatingStats_Closed(object sender, EventArgs e)
        {
            this.myOwner.ShowAnchoredDataView();
            base.Hide();
        }


        void frmFloatingStats_Load(object sender, EventArgs e)
        {
            this.dvFloat.MoveDisable = true;
            this.dvFloat.SetScreenBounds(this.dvFloat.Bounds);
            this.dvFloat.SetLocation(this.dvFloat.Location, true);
        }


        [AccessedThroughProperty("dvFloat")]
        DataView _dvFloat;


        protected frmMain myOwner;
    }
}
