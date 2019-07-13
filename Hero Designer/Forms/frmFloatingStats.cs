
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
        public DataView dvFloat;

        frmMain myOwner;

        public frmFloatingStats(frmMain iOwner)
        {
            this.InitializeComponent();
            this.Load += new EventHandler(this.frmFloatingStats_Load);
            this.Closed += new EventHandler(this.frmFloatingStats_Closed);
            this.Name = nameof(frmFloatingStats);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmFloatingStats));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
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