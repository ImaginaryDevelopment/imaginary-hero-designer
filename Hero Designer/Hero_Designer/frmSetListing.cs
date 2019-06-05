using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000057 RID: 87
	public partial class frmSetListing : Form
	{
		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x0600127A RID: 4730 RVA: 0x000B89D0 File Offset: 0x000B6BD0
		// (set) Token: 0x0600127B RID: 4731 RVA: 0x000B89E8 File Offset: 0x000B6BE8
		internal virtual Button btnAdd
		{
			get
			{
				return this._btnAdd;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
				if (this._btnAdd != null)
				{
					this._btnAdd.Click -= eventHandler;
				}
				this._btnAdd = value;
				if (this._btnAdd != null)
				{
					this._btnAdd.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x0600127C RID: 4732 RVA: 0x000B8A44 File Offset: 0x000B6C44
		// (set) Token: 0x0600127D RID: 4733 RVA: 0x000B8A5C File Offset: 0x000B6C5C
		internal virtual Button btnCancel
		{
			get
			{
				return this._btnCancel;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
				if (this._btnCancel != null)
				{
					this._btnCancel.Click -= eventHandler;
				}
				this._btnCancel = value;
				if (this._btnCancel != null)
				{
					this._btnCancel.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x0600127E RID: 4734 RVA: 0x000B8AB8 File Offset: 0x000B6CB8
		// (set) Token: 0x0600127F RID: 4735 RVA: 0x000B8AD0 File Offset: 0x000B6CD0
		internal virtual Button btnClone
		{
			get
			{
				return this._btnClone;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnClone_Click);
				if (this._btnClone != null)
				{
					this._btnClone.Click -= eventHandler;
				}
				this._btnClone = value;
				if (this._btnClone != null)
				{
					this._btnClone.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06001280 RID: 4736 RVA: 0x000B8B2C File Offset: 0x000B6D2C
		// (set) Token: 0x06001281 RID: 4737 RVA: 0x000B8B44 File Offset: 0x000B6D44
		internal virtual Button btnDelete
		{
			get
			{
				return this._btnDelete;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
				if (this._btnDelete != null)
				{
					this._btnDelete.Click -= eventHandler;
				}
				this._btnDelete = value;
				if (this._btnDelete != null)
				{
					this._btnDelete.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06001282 RID: 4738 RVA: 0x000B8BA0 File Offset: 0x000B6DA0
		// (set) Token: 0x06001283 RID: 4739 RVA: 0x000B8BB8 File Offset: 0x000B6DB8
		internal virtual Button btnDown
		{
			get
			{
				return this._btnDown;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnDown_Click);
				if (this._btnDown != null)
				{
					this._btnDown.Click -= eventHandler;
				}
				this._btnDown = value;
				if (this._btnDown != null)
				{
					this._btnDown.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06001284 RID: 4740 RVA: 0x000B8C14 File Offset: 0x000B6E14
		// (set) Token: 0x06001285 RID: 4741 RVA: 0x000B8C2C File Offset: 0x000B6E2C
		internal virtual Button btnEdit
		{
			get
			{
				return this._btnEdit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
				if (this._btnEdit != null)
				{
					this._btnEdit.Click -= eventHandler;
				}
				this._btnEdit = value;
				if (this._btnEdit != null)
				{
					this._btnEdit.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06001286 RID: 4742 RVA: 0x000B8C88 File Offset: 0x000B6E88
		// (set) Token: 0x06001287 RID: 4743 RVA: 0x000B8CA0 File Offset: 0x000B6EA0
		internal virtual Button btnSave
		{
			get
			{
				return this._btnSave;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnSave_Click);
				if (this._btnSave != null)
				{
					this._btnSave.Click -= eventHandler;
				}
				this._btnSave = value;
				if (this._btnSave != null)
				{
					this._btnSave.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06001288 RID: 4744 RVA: 0x000B8CFC File Offset: 0x000B6EFC
		// (set) Token: 0x06001289 RID: 4745 RVA: 0x000B8D14 File Offset: 0x000B6F14
		internal virtual Button btnUp
		{
			get
			{
				return this._btnUp;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnUp_Click);
				if (this._btnUp != null)
				{
					this._btnUp.Click -= eventHandler;
				}
				this._btnUp = value;
				if (this._btnUp != null)
				{
					this._btnUp.Click += eventHandler;
				}
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x0600128A RID: 4746 RVA: 0x000B8D70 File Offset: 0x000B6F70
		// (set) Token: 0x0600128B RID: 4747 RVA: 0x000B8D88 File Offset: 0x000B6F88
		internal virtual ColumnHeader ColumnHeader1
		{
			get
			{
				return this._ColumnHeader1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader1 = value;
			}
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x0600128C RID: 4748 RVA: 0x000B8D94 File Offset: 0x000B6F94
		// (set) Token: 0x0600128D RID: 4749 RVA: 0x000B8DAC File Offset: 0x000B6FAC
		internal virtual ColumnHeader ColumnHeader2
		{
			get
			{
				return this._ColumnHeader2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader2 = value;
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x0600128E RID: 4750 RVA: 0x000B8DB8 File Offset: 0x000B6FB8
		// (set) Token: 0x0600128F RID: 4751 RVA: 0x000B8DD0 File Offset: 0x000B6FD0
		internal virtual ColumnHeader ColumnHeader3
		{
			get
			{
				return this._ColumnHeader3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader3 = value;
			}
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x000B8DDC File Offset: 0x000B6FDC
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x000B8DF4 File Offset: 0x000B6FF4
		internal virtual ColumnHeader ColumnHeader4
		{
			get
			{
				return this._ColumnHeader4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader4 = value;
			}
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06001292 RID: 4754 RVA: 0x000B8E00 File Offset: 0x000B7000
		// (set) Token: 0x06001293 RID: 4755 RVA: 0x000B8E18 File Offset: 0x000B7018
		internal virtual ColumnHeader ColumnHeader5
		{
			get
			{
				return this._ColumnHeader5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader5 = value;
			}
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x000B8E24 File Offset: 0x000B7024
		// (set) Token: 0x06001295 RID: 4757 RVA: 0x000B8E3C File Offset: 0x000B703C
		internal virtual ColumnHeader ColumnHeader6
		{
			get
			{
				return this._ColumnHeader6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader6 = value;
			}
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x000B8E48 File Offset: 0x000B7048
		// (set) Token: 0x06001297 RID: 4759 RVA: 0x000B8E60 File Offset: 0x000B7060
		internal virtual ImageList ilSets
		{
			get
			{
				return this._ilSets;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ilSets = value;
			}
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x06001298 RID: 4760 RVA: 0x000B8E6C File Offset: 0x000B706C
		// (set) Token: 0x06001299 RID: 4761 RVA: 0x000B8E84 File Offset: 0x000B7084
		internal virtual ListView lvSets
		{
			get
			{
				return this._lvSets;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvSets_DoubleClick);
				EventHandler eventHandler2 = new EventHandler(this.lvSets_SelectedIndexChanged);
				if (this._lvSets != null)
				{
					this._lvSets.DoubleClick -= eventHandler;
					this._lvSets.SelectedIndexChanged -= eventHandler2;
				}
				this._lvSets = value;
				if (this._lvSets != null)
				{
					this._lvSets.DoubleClick += eventHandler;
					this._lvSets.SelectedIndexChanged += eventHandler2;
				}
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x000B8F08 File Offset: 0x000B7108
		// (set) Token: 0x0600129B RID: 4763 RVA: 0x000B8F20 File Offset: 0x000B7120
		internal virtual CheckBox NoReload
		{
			get
			{
				return this._NoReload;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.NoReload_CheckedChanged);
				if (this._NoReload != null)
				{
					this._NoReload.CheckedChanged -= eventHandler;
				}
				this._NoReload = value;
				if (this._NoReload != null)
				{
					this._NoReload.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x000B8F7A File Offset: 0x000B717A
		public frmSetListing()
		{
			base.Load += this.frmSetListing_Load;
			this.InitializeComponent();
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x000B8FA0 File Offset: 0x000B71A0
		public void AddListItem(int Index)
		{
			string[] items = new string[6];
			EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[Index];
			items[0] = enhancementSet.DisplayName + " (" + enhancementSet.ShortName + ")";
			items[1] = Enum.GetName(enhancementSet.SetType.GetType(), enhancementSet.SetType);
			items[2] = Conversions.ToString(enhancementSet.LevelMin + 1);
			items[3] = Conversions.ToString(enhancementSet.LevelMax + 1);
			items[4] = Conversions.ToString(enhancementSet.Enhancements.Length);
			int num = 0;
			int num2 = enhancementSet.Bonus.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (enhancementSet.Bonus[index].Index.Length > 0)
				{
					num++;
				}
			}
			items[5] = Conversions.ToString(num);
			this.lvSets.Items.Add(new ListViewItem(items, Index));
			this.lvSets.Items[this.lvSets.Items.Count - 1].Selected = true;
			this.lvSets.Items[this.lvSets.Items.Count - 1].EnsureVisible();
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x000B90F8 File Offset: 0x000B72F8
		private void btnAdd_Click(object sender, EventArgs e)
		{
			EnhancementSet iSet = new EnhancementSet();
			frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
			frmSetEdit.ShowDialog();
			if (frmSetEdit.DialogResult == DialogResult.OK)
			{
				DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(frmSetEdit.mySet));
				this.ImageUpdate();
				this.AddListItem(DatabaseAPI.Database.EnhancementSets.Count - 1);
			}
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x000B9167 File Offset: 0x000B7367
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x000B9174 File Offset: 0x000B7374
		private void btnClone_Click(object sender, EventArgs e)
		{
			if (this.lvSets.SelectedIndices.Count > 0)
			{
				EnhancementSet iSet = new EnhancementSet(DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]]);
				EnhancementSet enhancementSet = iSet;
				EnhancementSet enhancementSet2 = enhancementSet;
				enhancementSet2.DisplayName += " Copy";
				frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
				frmSetEdit.ShowDialog();
				if (frmSetEdit.DialogResult == DialogResult.OK)
				{
					DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(frmSetEdit.mySet));
					this.ImageUpdate();
					this.AddListItem(DatabaseAPI.Database.EnhancementSets.Count - 1);
				}
			}
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x000B923C File Offset: 0x000B743C
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (this.lvSets.SelectedIndices.Count > 0 && Interaction.MsgBox("Really delete set: " + this.lvSets.SelectedItems[0].Text + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
			{
				int selectedIndex = this.lvSets.SelectedIndices[0];
				DatabaseAPI.Database.EnhancementSets.RemoveAt(selectedIndex);
				DatabaseAPI.MatchEnhancementIDs();
				this.DisplayList();
				if (this.lvSets.Items.Count > 0)
				{
					if (this.lvSets.Items.Count > selectedIndex)
					{
						this.lvSets.Items[selectedIndex].Selected = true;
					}
					else if (this.lvSets.Items.Count == selectedIndex)
					{
						this.lvSets.Items[selectedIndex - 1].Selected = true;
					}
				}
			}
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x000B935C File Offset: 0x000B755C
		private void btnDown_Click(object sender, EventArgs e)
		{
			if (this.lvSets.SelectedIndices.Count > 0)
			{
				int selectedIndex = this.lvSets.SelectedIndices[0];
				if (selectedIndex < this.lvSets.Items.Count - 1)
				{
					EnhancementSet[] enhancementSetArray = new EnhancementSet[]
					{
						new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex]),
						new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex + 1])
					};
					DatabaseAPI.Database.EnhancementSets[selectedIndex + 1] = new EnhancementSet(enhancementSetArray[0]);
					DatabaseAPI.Database.EnhancementSets[selectedIndex] = new EnhancementSet(enhancementSetArray[1]);
					DatabaseAPI.MatchEnhancementIDs();
					ListViewItem listViewItem = (ListViewItem)this.lvSets.Items[selectedIndex].Clone();
					ListViewItem listViewItem2 = (ListViewItem)this.lvSets.Items[selectedIndex + 1].Clone();
					this.lvSets.Items[selectedIndex] = listViewItem2;
					this.lvSets.Items[selectedIndex + 1] = listViewItem;
					this.lvSets.Items[selectedIndex + 1].Selected = true;
					this.lvSets.Items[selectedIndex + 1].EnsureVisible();
				}
			}
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x000B94D0 File Offset: 0x000B76D0
		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (this.lvSets.SelectedIndices.Count > 0)
			{
				bool flag = false;
				string uidOld = "";
				int selectedIndex = this.lvSets.SelectedIndices[0];
				EnhancementSetCollection enhancementSets = DatabaseAPI.Database.EnhancementSets;
				int selectedIndex2 = this.lvSets.SelectedIndices[0];
				EnhancementSet iSet = enhancementSets[selectedIndex2];
				enhancementSets[selectedIndex2] = iSet;
				frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
				frmSetEdit.ShowDialog();
				if (frmSetEdit.DialogResult == DialogResult.OK)
				{
					if (frmSetEdit.mySet.Uid != DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]].Uid)
					{
						flag = true;
						uidOld = DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]].Uid;
					}
					DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]] = new EnhancementSet(frmSetEdit.mySet);
					this.ImageUpdate();
					this.UpdateListItem(selectedIndex);
					if (flag)
					{
						frmSetListing.RenameIOSet(uidOld, frmSetEdit.mySet.Uid);
						DatabaseAPI.MatchEnhancementIDs();
					}
				}
			}
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x000B963F File Offset: 0x000B783F
		private void btnSave_Click(object sender, EventArgs e)
		{
			DatabaseAPI.SaveEnhancementDb();
			base.Hide();
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x000B9650 File Offset: 0x000B7850
		private void btnUp_Click(object sender, EventArgs e)
		{
			if (this.lvSets.SelectedIndices.Count > 0)
			{
				int selectedIndex = this.lvSets.SelectedIndices[0];
				if (selectedIndex >= 1)
				{
					EnhancementSet[] enhancementSetArray = new EnhancementSet[]
					{
						new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex]),
						new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex - 1])
					};
					DatabaseAPI.Database.EnhancementSets[selectedIndex - 1] = new EnhancementSet(enhancementSetArray[0]);
					DatabaseAPI.Database.EnhancementSets[selectedIndex] = new EnhancementSet(enhancementSetArray[1]);
					DatabaseAPI.MatchEnhancementIDs();
					ListViewItem listViewItem = (ListViewItem)this.lvSets.Items[selectedIndex].Clone();
					ListViewItem listViewItem2 = (ListViewItem)this.lvSets.Items[selectedIndex - 1].Clone();
					this.lvSets.Items[selectedIndex] = listViewItem2;
					this.lvSets.Items[selectedIndex - 1] = listViewItem;
					this.lvSets.Items[selectedIndex - 1].Selected = true;
					this.lvSets.Items[selectedIndex - 1].EnsureVisible();
				}
			}
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x000B97B0 File Offset: 0x000B79B0
		public void DisplayList()
		{
			this.lvSets.BeginUpdate();
			this.lvSets.Items.Clear();
			this.ImageUpdate();
			int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
			for (int Index = 0; Index <= num; Index++)
			{
				this.AddListItem(Index);
			}
			if (this.lvSets.Items.Count > 0)
			{
				this.lvSets.Items[0].Selected = true;
				this.lvSets.Items[0].EnsureVisible();
			}
			this.lvSets.EndUpdate();
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x000B98A0 File Offset: 0x000B7AA0
		public void FillImageList()
		{
			ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height);
			this.ilSets.Images.Clear();
			int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[index];
				if (enhancementSet.ImageIdx > -1)
				{
					extendedBitmap.Graphics.Clear(Color.White);
					Graphics graphics = extendedBitmap.Graphics;
					I9Gfx.DrawEnhancementSet(ref graphics, DatabaseAPI.Database.EnhancementSets[index].ImageIdx);
					this.ilSets.Images.Add(extendedBitmap.Bitmap);
				}
				else
				{
					this.ilSets.Images.Add(new Bitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height));
				}
			}
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x000B99D0 File Offset: 0x000B7BD0
		private void frmSetListing_Load(object sender, EventArgs e)
		{
			this.DisplayList();
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x000B99DC File Offset: 0x000B7BDC
		public void ImageUpdate()
		{
			if (!this.NoReload.Checked)
			{
				I9Gfx.LoadSets();
				this.FillImageList();
			}
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x000BA47D File Offset: 0x000B867D
		private void lvSets_DoubleClick(object sender, EventArgs e)
		{
			this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x000BA48E File Offset: 0x000B868E
		private void lvSets_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x000BA491 File Offset: 0x000B8691
		private void NoReload_CheckedChanged(object sender, EventArgs e)
		{
			this.ImageUpdate();
		}

		// Token: 0x060012AF RID: 4783 RVA: 0x000BA49C File Offset: 0x000B869C
		private static void RenameIOSet(string uidOld, string uidNew)
		{
			int num = DatabaseAPI.Database.Enhancements.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (DatabaseAPI.Database.Enhancements[index].UIDSet == uidOld)
				{
					DatabaseAPI.Database.Enhancements[index].UIDSet = uidNew;
				}
			}
		}

		// Token: 0x060012B0 RID: 4784 RVA: 0x000BA504 File Offset: 0x000B8704
		public void UpdateListItem(int Index)
		{
			string[] strArray = new string[6];
			EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[Index];
			strArray[0] = enhancementSet.DisplayName + " (" + enhancementSet.ShortName + ")";
			strArray[1] = Enum.GetName(enhancementSet.SetType.GetType(), enhancementSet.SetType);
			strArray[2] = Conversions.ToString(enhancementSet.LevelMin + 1);
			strArray[3] = Conversions.ToString(enhancementSet.LevelMax + 1);
			strArray[4] = Conversions.ToString(enhancementSet.Enhancements.Length);
			int num = 0;
			int num2 = enhancementSet.Bonus.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (enhancementSet.Bonus[index].Index.Length > 0)
				{
					num++;
				}
			}
			strArray[5] = Conversions.ToString(num);
			int num3 = strArray.Length - 1;
			for (int index2 = 0; index2 <= num3; index2++)
			{
				this.lvSets.Items[Index].SubItems[index2].Text = strArray[index2];
			}
			this.lvSets.Items[Index].ImageIndex = Index;
			this.lvSets.Refresh();
		}

		// Token: 0x0400076F RID: 1903
		[AccessedThroughProperty("btnAdd")]
		private Button _btnAdd;

		// Token: 0x04000770 RID: 1904
		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		// Token: 0x04000771 RID: 1905
		[AccessedThroughProperty("btnClone")]
		private Button _btnClone;

		// Token: 0x04000772 RID: 1906
		[AccessedThroughProperty("btnDelete")]
		private Button _btnDelete;

		// Token: 0x04000773 RID: 1907
		[AccessedThroughProperty("btnDown")]
		private Button _btnDown;

		// Token: 0x04000774 RID: 1908
		[AccessedThroughProperty("btnEdit")]
		private Button _btnEdit;

		// Token: 0x04000775 RID: 1909
		[AccessedThroughProperty("btnSave")]
		private Button _btnSave;

		// Token: 0x04000776 RID: 1910
		[AccessedThroughProperty("btnUp")]
		private Button _btnUp;

		// Token: 0x04000777 RID: 1911
		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader _ColumnHeader1;

		// Token: 0x04000778 RID: 1912
		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader _ColumnHeader2;

		// Token: 0x04000779 RID: 1913
		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader _ColumnHeader3;

		// Token: 0x0400077A RID: 1914
		[AccessedThroughProperty("ColumnHeader4")]
		private ColumnHeader _ColumnHeader4;

		// Token: 0x0400077B RID: 1915
		[AccessedThroughProperty("ColumnHeader5")]
		private ColumnHeader _ColumnHeader5;

		// Token: 0x0400077C RID: 1916
		[AccessedThroughProperty("ColumnHeader6")]
		private ColumnHeader _ColumnHeader6;

		// Token: 0x0400077D RID: 1917
		[AccessedThroughProperty("ilSets")]
		private ImageList _ilSets;

		// Token: 0x0400077E RID: 1918
		[AccessedThroughProperty("lvSets")]
		private ListView _lvSets;

		// Token: 0x0400077F RID: 1919
		[AccessedThroughProperty("NoReload")]
		private CheckBox _NoReload;
	}
}
