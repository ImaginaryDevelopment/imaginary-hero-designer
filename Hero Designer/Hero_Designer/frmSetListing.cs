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

    public partial class frmSetListing : Form
    {

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


        public frmSetListing()
        {
            base.Load += this.frmSetListing_Load;
            this.InitializeComponent();
        }


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


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Hide();
        }


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


        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseAPI.SaveEnhancementDb();
            base.Hide();
        }


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


        private void frmSetListing_Load(object sender, EventArgs e)
        {
            this.DisplayList();
        }


        public void ImageUpdate()
        {
            if (!this.NoReload.Checked)
            {
                I9Gfx.LoadSets();
                this.FillImageList();
            }
        }


        private void lvSets_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        private void lvSets_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void NoReload_CheckedChanged(object sender, EventArgs e)
        {
            this.ImageUpdate();
        }


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


        [AccessedThroughProperty("btnAdd")]
        private Button _btnAdd;


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnClone")]
        private Button _btnClone;


        [AccessedThroughProperty("btnDelete")]
        private Button _btnDelete;


        [AccessedThroughProperty("btnDown")]
        private Button _btnDown;


        [AccessedThroughProperty("btnEdit")]
        private Button _btnEdit;


        [AccessedThroughProperty("btnSave")]
        private Button _btnSave;


        [AccessedThroughProperty("btnUp")]
        private Button _btnUp;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;


        [AccessedThroughProperty("ilSets")]
        private ImageList _ilSets;


        [AccessedThroughProperty("lvSets")]
        private ListView _lvSets;


        [AccessedThroughProperty("NoReload")]
        private CheckBox _NoReload;
    }
}
