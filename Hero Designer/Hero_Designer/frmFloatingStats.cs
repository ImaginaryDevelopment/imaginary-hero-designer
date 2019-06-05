using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
	// Token: 0x02000035 RID: 53
	public partial class frmFloatingStats : Form
	{
		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000A1E RID: 2590 RVA: 0x0006A158 File Offset: 0x00068358
		// (set) Token: 0x06000A1F RID: 2591 RVA: 0x0006A170 File Offset: 0x00068370
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

		// Token: 0x06000A20 RID: 2592 RVA: 0x0006A2C1 File Offset: 0x000684C1
		public frmFloatingStats(ref frmMain iOwner)
		{
			base.Load += this.frmFloatingStats_Load;
			base.Closed += this.frmFloatingStats_Closed;
			this.InitializeComponent();
			this.myOwner = iOwner;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0006A33C File Offset: 0x0006853C
		private void dvFloat_FloatChanged()
		{
			base.Close();
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0006A346 File Offset: 0x00068546
		private void dvFloat_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0006A349 File Offset: 0x00068549
		private void dvFloat_SizeChange(Size newSize, bool Compact)
		{
			base.ClientSize = newSize;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0006A354 File Offset: 0x00068554
		private void dvFloat_SlotFlip(int PowerIndex)
		{
			this.myOwner.DataView_SlotFlip(PowerIndex);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0006A364 File Offset: 0x00068564
		private void dvFloat_SlotUpdate()
		{
			this.myOwner.DataView_SlotUpdate();
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0006A373 File Offset: 0x00068573
		private void dvFloat_TabChanged(int Index)
		{
			this.myOwner.SetDataViewTab(Index);
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0006A384 File Offset: 0x00068584
		private void dvFloat_Unlock()
		{
			this.myOwner.DataViewLocked = false;
			if (this.myOwner.dvLastPower > -1)
			{
				this.myOwner.Info_Power(this.myOwner.dvLastPower, this.myOwner.dvLastEnh, this.myOwner.dvLastNoLev, this.myOwner.DataViewLocked);
			}
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0006A3ED File Offset: 0x000685ED
		private void frmFloatingStats_Closed(object sender, EventArgs e)
		{
			this.myOwner.ShowAnchoredDataView();
			base.Hide();
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0006A403 File Offset: 0x00068603
		private void frmFloatingStats_Load(object sender, EventArgs e)
		{
			this.dvFloat.MoveDisable = true;
			this.dvFloat.SetScreenBounds(this.dvFloat.Bounds);
			this.dvFloat.SetLocation(this.dvFloat.Location, true);
		}

		// Token: 0x04000426 RID: 1062
		[AccessedThroughProperty("dvFloat")]
		private DataView _dvFloat;

		// Token: 0x04000428 RID: 1064
		protected frmMain myOwner;
	}
}
