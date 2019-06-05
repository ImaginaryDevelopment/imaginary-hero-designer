using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000033 RID: 51
	[DesignerGenerated]
	public partial class frmEntityListing : Form
	{
		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x00067260 File Offset: 0x00065460
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x00067278 File Offset: 0x00065478
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

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x000672D4 File Offset: 0x000654D4
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x000672EC File Offset: 0x000654EC
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

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x00067348 File Offset: 0x00065548
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x00067360 File Offset: 0x00065560
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

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x000673BC File Offset: 0x000655BC
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x000673D4 File Offset: 0x000655D4
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

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x00067430 File Offset: 0x00065630
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00067448 File Offset: 0x00065648
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

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x000674A4 File Offset: 0x000656A4
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x000674BC File Offset: 0x000656BC
		internal virtual Button btnedit
		{
			get
			{
				return this._btnedit;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
				if (this._btnedit != null)
				{
					this._btnedit.Click -= eventHandler;
				}
				this._btnedit = value;
				if (this._btnedit != null)
				{
					this._btnedit.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00067518 File Offset: 0x00065718
		// (set) Token: 0x060009C3 RID: 2499 RVA: 0x00067530 File Offset: 0x00065730
		internal virtual Button btnOK
		{
			get
			{
				return this._btnOK;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnOK_Click);
				if (this._btnOK != null)
				{
					this._btnOK.Click -= eventHandler;
				}
				this._btnOK = value;
				if (this._btnOK != null)
				{
					this._btnOK.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0006758C File Offset: 0x0006578C
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x000675A4 File Offset: 0x000657A4
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

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x00067600 File Offset: 0x00065800
		// (set) Token: 0x060009C7 RID: 2503 RVA: 0x00067618 File Offset: 0x00065818
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

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x00067624 File Offset: 0x00065824
		// (set) Token: 0x060009C9 RID: 2505 RVA: 0x0006763C File Offset: 0x0006583C
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

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060009CA RID: 2506 RVA: 0x00067648 File Offset: 0x00065848
		// (set) Token: 0x060009CB RID: 2507 RVA: 0x00067660 File Offset: 0x00065860
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

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060009CC RID: 2508 RVA: 0x0006766C File Offset: 0x0006586C
		// (set) Token: 0x060009CD RID: 2509 RVA: 0x00067684 File Offset: 0x00065884
		internal virtual ListView lvEntity
		{
			get
			{
				return this._lvEntity;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvEntity_DoubleClick);
				if (this._lvEntity != null)
				{
					this._lvEntity.DoubleClick -= eventHandler;
				}
				this._lvEntity = value;
				if (this._lvEntity != null)
				{
					this._lvEntity.DoubleClick += eventHandler;
				}
			}
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x000676DE File Offset: 0x000658DE
		public frmEntityListing()
		{
			base.Load += this.frmEntityListing_Load;
			this.InitializeComponent();
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x00067704 File Offset: 0x00065904
		private void btnAdd_Click(object sender, EventArgs e)
		{
			SummonedEntity iEntity = new SummonedEntity();
			int num = 0;
			bool flag;
			do
			{
				iEntity.UID = "NewEntity_" + Conversions.ToString(num);
				flag = true;
				int num2 = DatabaseAPI.Database.Entities.Length - 1;
				for (int index = 0; index <= num2; index++)
				{
					if (DatabaseAPI.Database.Entities[index].UID.ToLower() == iEntity.UID.ToLower())
					{
						flag = false;
					}
				}
				num++;
			}
			while (!flag);
			frmEntityEdit frmEntityEdit = new frmEntityEdit(iEntity);
			frmEntityEdit.ShowDialog();
			if (frmEntityEdit.DialogResult == DialogResult.OK)
			{
				IDatabase database = DatabaseAPI.Database;
				SummonedEntity[] summonedEntityArray = (SummonedEntity[])Utils.CopyArray(database.Entities, new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
				database.Entities = summonedEntityArray;
				DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity(frmEntityEdit.myEntity);
				DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1].nID = DatabaseAPI.Database.Entities.Length - 1;
				this.ListAddItem(DatabaseAPI.Database.Entities.Length - 1);
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00067868 File Offset: 0x00065A68
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.BusyMsg("Re-Indexing...");
			DatabaseAPI.LoadMainDatabase();
			DatabaseAPI.MatchAllIDs(null);
			this.BusyHide();
			base.Hide();
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00067894 File Offset: 0x00065A94
		private void btnClone_Click(object sender, EventArgs e)
		{
			if (this.lvEntity.SelectedIndices.Count > 0)
			{
				int num = this.lvEntity.SelectedIndices[0];
				SummonedEntity iEntity = new SummonedEntity(DatabaseAPI.Database.Entities[num])
				{
					nID = DatabaseAPI.Database.Entities.Length
				};
				frmEntityEdit frmEntityEdit = new frmEntityEdit(iEntity);
				frmEntityEdit.ShowDialog();
				if (frmEntityEdit.DialogResult == DialogResult.OK)
				{
					IDatabase database = DatabaseAPI.Database;
					SummonedEntity[] summonedEntityArray = (SummonedEntity[])Utils.CopyArray(database.Entities, new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
					database.Entities = summonedEntityArray;
					DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity(frmEntityEdit.myEntity);
					this.ListAddItem(DatabaseAPI.Database.Entities.Length - 1);
				}
			}
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00067990 File Offset: 0x00065B90
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (this.lvEntity.SelectedIndices.Count > 0 && Interaction.MsgBox("Really delete entity: " + DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]].DisplayName + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
			{
				SummonedEntity[] summonedEntityArray = new SummonedEntity[DatabaseAPI.Database.Entities.Length - 1 + 1];
				int selectedIndex = this.lvEntity.SelectedIndices[0];
				int index = 0;
				int num = DatabaseAPI.Database.Entities.Length - 1;
				for (int index2 = 0; index2 <= num; index2++)
				{
					if (index2 != selectedIndex)
					{
						summonedEntityArray[index] = new SummonedEntity(DatabaseAPI.Database.Entities[index2]);
						index++;
					}
				}
				DatabaseAPI.Database.Entities = new SummonedEntity[DatabaseAPI.Database.Entities.Length - 2 + 1];
				int num2 = DatabaseAPI.Database.Entities.Length - 1;
				for (int index2 = 0; index2 <= num2; index2++)
				{
					DatabaseAPI.Database.Entities[index2] = new SummonedEntity(summonedEntityArray[index2]);
				}
				this.DisplayList();
				if (this.lvEntity.Items.Count > 0)
				{
					if (this.lvEntity.Items.Count > selectedIndex)
					{
						this.lvEntity.Items[selectedIndex].Selected = true;
					}
					else if (this.lvEntity.Items.Count == selectedIndex)
					{
						this.lvEntity.Items[selectedIndex - 1].Selected = true;
					}
				}
			}
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00067B74 File Offset: 0x00065D74
		private void btnDown_Click(object sender, EventArgs e)
		{
			if (this.lvEntity.SelectedIndices.Count > 0)
			{
				int selectedIndex = this.lvEntity.SelectedIndices[0];
				if (selectedIndex < this.lvEntity.Items.Count - 1)
				{
					SummonedEntity[] summonedEntityArray = new SummonedEntity[]
					{
						new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex]),
						new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex + 1])
					};
					DatabaseAPI.Database.Entities[selectedIndex + 1] = new SummonedEntity(summonedEntityArray[0]);
					DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(summonedEntityArray[1]);
					this.DisplayList();
					this.lvEntity.Items[selectedIndex + 1].Selected = true;
					this.lvEntity.Items[selectedIndex + 1].EnsureVisible();
				}
			}
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x00067C6C File Offset: 0x00065E6C
		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (this.lvEntity.SelectedIndices.Count > 0)
			{
				int selectedIndex = this.lvEntity.SelectedIndices[0];
				frmEntityEdit frmEntityEdit = new frmEntityEdit(DatabaseAPI.Database.Entities[this.lvEntity.SelectedIndices[0]]);
				if (frmEntityEdit.ShowDialog() == DialogResult.OK)
				{
					DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(frmEntityEdit.myEntity);
					this.ListUpdateItem(selectedIndex);
				}
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00067CFB File Offset: 0x00065EFB
		private void btnOK_Click(object sender, EventArgs e)
		{
			DatabaseAPI.MatchSummonIDs();
			DatabaseAPI.SaveMainDatabase();
			base.Hide();
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x00067D14 File Offset: 0x00065F14
		private void btnUp_Click(object sender, EventArgs e)
		{
			if (this.lvEntity.SelectedIndices.Count > 0)
			{
				int selectedIndex = this.lvEntity.SelectedIndices[0];
				if (selectedIndex >= 1)
				{
					SummonedEntity[] summonedEntityArray = new SummonedEntity[]
					{
						new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex]),
						new SummonedEntity(DatabaseAPI.Database.Entities[selectedIndex - 1])
					};
					DatabaseAPI.Database.Entities[selectedIndex - 1] = new SummonedEntity(summonedEntityArray[0]);
					DatabaseAPI.Database.Entities[selectedIndex] = new SummonedEntity(summonedEntityArray[1]);
					this.DisplayList();
					this.lvEntity.Items[selectedIndex - 1].Selected = true;
					this.lvEntity.Items[selectedIndex - 1].EnsureVisible();
				}
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00067DF8 File Offset: 0x00065FF8
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x00067E28 File Offset: 0x00066028
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show(this);
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00067E70 File Offset: 0x00066070
		public void DisplayList()
		{
			this.lvEntity.BeginUpdate();
			this.lvEntity.Items.Clear();
			int num = DatabaseAPI.Database.Entities.Length - 1;
			for (int Index = 0; Index <= num; Index++)
			{
				this.ListAddItem(Index);
			}
			if (this.lvEntity.Items.Count > 0)
			{
				this.lvEntity.Items[0].Selected = true;
				this.lvEntity.Items[0].EnsureVisible();
			}
			this.lvEntity.EndUpdate();
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00067F70 File Offset: 0x00066170
		private void frmEntityListing_Load(object sender, EventArgs e)
		{
			this.DisplayList();
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0006863C File Offset: 0x0006683C
		public void ListAddItem(int Index)
		{
			string[] items = new string[]
			{
				DatabaseAPI.Database.Entities[Index].UID,
				DatabaseAPI.Database.Entities[Index].DisplayName,
				Enum.GetName(DatabaseAPI.Database.Entities[Index].EntityType.GetType(), DatabaseAPI.Database.Entities[Index].EntityType)
			};
			this.lvEntity.Items.Add(new ListViewItem(items, Index));
			this.lvEntity.Items[this.lvEntity.Items.Count - 1].Selected = true;
			this.lvEntity.Items[this.lvEntity.Items.Count - 1].EnsureVisible();
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00068720 File Offset: 0x00066920
		public void ListUpdateItem(int Index)
		{
			string[] strArray = new string[]
			{
				DatabaseAPI.Database.Entities[Index].UID,
				DatabaseAPI.Database.Entities[Index].DisplayName,
				Enum.GetName(DatabaseAPI.Database.Entities[Index].EntityType.GetType(), DatabaseAPI.Database.Entities[Index].EntityType)
			};
			int num = strArray.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.lvEntity.Items[Index].SubItems[index].Text = strArray[index];
			}
			this.lvEntity.Items[Index].EnsureVisible();
			this.lvEntity.Refresh();
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x000687FD File Offset: 0x000669FD
		private void lvEntity_DoubleClick(object sender, EventArgs e)
		{
			this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
		}

		// Token: 0x040003FF RID: 1023
		[AccessedThroughProperty("btnAdd")]
		private Button _btnAdd;

		// Token: 0x04000400 RID: 1024
		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		// Token: 0x04000401 RID: 1025
		[AccessedThroughProperty("btnClone")]
		private Button _btnClone;

		// Token: 0x04000402 RID: 1026
		[AccessedThroughProperty("btnDelete")]
		private Button _btnDelete;

		// Token: 0x04000403 RID: 1027
		[AccessedThroughProperty("btnDown")]
		private Button _btnDown;

		// Token: 0x04000404 RID: 1028
		[AccessedThroughProperty("btnedit")]
		private Button _btnedit;

		// Token: 0x04000405 RID: 1029
		[AccessedThroughProperty("btnOK")]
		private Button _btnOK;

		// Token: 0x04000406 RID: 1030
		[AccessedThroughProperty("btnUp")]
		private Button _btnUp;

		// Token: 0x04000407 RID: 1031
		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader _ColumnHeader1;

		// Token: 0x04000408 RID: 1032
		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader _ColumnHeader2;

		// Token: 0x04000409 RID: 1033
		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader _ColumnHeader3;

		// Token: 0x0400040A RID: 1034
		[AccessedThroughProperty("lvEntity")]
		private ListView _lvEntity;

		// Token: 0x0400040B RID: 1035
		private frmBusy bFrm;
	}
}
