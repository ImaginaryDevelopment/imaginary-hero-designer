
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
        [AccessedThroughProperty("dvFloat")]
        DataView _dvFloat;

        protected frmMain myOwner;

        internal DataView dvFloat
        {
            get
            {
                return this._dvFloat;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            private set
            {
                EventHandler eventHandler = new EventHandler(this.dvFloat_Load);
                DataView.SizeChangeEventHandler changeEventHandler1 = new DataView.SizeChangeEventHandler(this.dvFloat_SizeChange);
                DataView.FloatChangeEventHandler changeEventHandler2 = new DataView.FloatChangeEventHandler(this.dvFloat_FloatChanged);
                DataView.Unlock_ClickEventHandler clickEventHandler = new DataView.Unlock_ClickEventHandler(this.dvFloat_Unlock);
                DataView.TabChangedEventHandler changedEventHandler = new DataView.TabChangedEventHandler(this.dvFloat_TabChanged);
                DataView.SlotUpdateEventHandler updateEventHandler = new DataView.SlotUpdateEventHandler(this.dvFloat_SlotUpdate);
                DataView.SlotFlipEventHandler flipEventHandler = new DataView.SlotFlipEventHandler(this.dvFloat_SlotFlip);
                if (this._dvFloat != null)
                {
                    this._dvFloat.Load -= eventHandler;
                    this._dvFloat.SizeChange -= changeEventHandler1;
                    this._dvFloat.FloatChange -= changeEventHandler2;
                    this._dvFloat.Unlock_Click -= clickEventHandler;
                    this._dvFloat.TabChanged -= changedEventHandler;
                    this._dvFloat.SlotUpdate -= updateEventHandler;
                    this._dvFloat.SlotFlip -= flipEventHandler;
                }
                this._dvFloat = value;
                if (this._dvFloat == null)
                    return;
                this._dvFloat.Load += eventHandler;
                this._dvFloat.SizeChange += changeEventHandler1;
                this._dvFloat.FloatChange += changeEventHandler2;
                this._dvFloat.Unlock_Click += clickEventHandler;
                this._dvFloat.TabChanged += changedEventHandler;
                this._dvFloat.SlotUpdate += updateEventHandler;
                this._dvFloat.SlotFlip += flipEventHandler;
            }
        }

        public frmFloatingStats(ref frmMain iOwner)
        {
            this.Load += new EventHandler(this.frmFloatingStats_Load);
            this.Closed += new EventHandler(this.frmFloatingStats_Closed);
            this.InitializeComponent();
            this.myOwner = iOwner;
        }

        void dvFloat_FloatChanged()

        {
            this.Close();
        }

        void dvFloat_Load(object sender, EventArgs e)

        {
        }

        void dvFloat_SizeChange(Size newSize, bool Compact)

        {
            this.ClientSize = newSize;
        }

        void dvFloat_SlotFlip(int powerIndex) => this.myOwner.DataView_SlotFlip(powerIndex);

        void dvFloat_SlotUpdate() => this.myOwner.DataView_SlotUpdate();

        void dvFloat_TabChanged(int index) => this.myOwner.SetDataViewTab(index);

        void dvFloat_Unlock() => this.myOwner.UnlockFloatingStats();

        void frmFloatingStats_Closed(object sender, EventArgs e)

        {
            this.myOwner.ShowAnchoredDataView();
            this.Hide();
        }

        void frmFloatingStats_Load(object sender, EventArgs e)

        {
            this.dvFloat.MoveDisable = true;
            this.dvFloat.SetScreenBounds(this.dvFloat.Bounds);
            this.dvFloat.SetLocation(this.dvFloat.Location, true);
        }
    }
}