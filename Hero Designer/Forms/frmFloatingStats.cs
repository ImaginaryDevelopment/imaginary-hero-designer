
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmFloatingStats : Form
    {
        public DataView dvFloat;

        frmMain myOwner;

        public frmFloatingStats(frmMain iOwner)
        {
            InitializeComponent();
            Load += frmFloatingStats_Load;
            Closed += frmFloatingStats_Closed;
            Name = nameof(frmFloatingStats);
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmFloatingStats));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            myOwner = iOwner;
        }

        void dvFloat_FloatChanged()
        {
            Close();
        }

        void dvFloat_Load(object sender, EventArgs e)
        {
        }

        void dvFloat_SizeChange(Size newSize, bool Compact)
        {
            ClientSize = newSize;
        }

        void dvFloat_SlotFlip(int powerIndex) => myOwner.DataView_SlotFlip(powerIndex);

        void dvFloat_SlotUpdate() => myOwner.DataView_SlotUpdate();

        void dvFloat_TabChanged(int index) => myOwner.SetDataViewTab(index);

        void dvFloat_Unlock() => myOwner.UnlockFloatingStats();

        void frmFloatingStats_Closed(object sender, EventArgs e)
        {
            myOwner.ShowAnchoredDataView();
            Hide();
        }

        void frmFloatingStats_Load(object sender, EventArgs e)
        {
            dvFloat.MoveDisable = true;
            dvFloat.SetScreenBounds(dvFloat.Bounds);
            dvFloat.SetLocation(dvFloat.Location, true);
        }
    }
}