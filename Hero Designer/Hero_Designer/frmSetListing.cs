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


        void btnAdd_Click(object sender, EventArgs e)
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


        void btnCancel_Click(object sender, EventArgs e)
        {
            base.Hide();
        }


        void btnClone_Click(object sender, EventArgs e)
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


        void btnDelete_Click(object sender, EventArgs e)
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


        void btnDown_Click(object sender, EventArgs e)
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


        void btnEdit_Click(object sender, EventArgs e)
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


        void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseAPI.SaveEnhancementDb();
            base.Hide();
        }


        void btnUp_Click(object sender, EventArgs e)
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


        void frmSetListing_Load(object sender, EventArgs e)
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


        void lvSets_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        void lvSets_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        void NoReload_CheckedChanged(object sender, EventArgs e)
        {
            this.ImageUpdate();
        }


        static void RenameIOSet(string uidOld, string uidNew)
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
        Button _btnAdd;


        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;


        [AccessedThroughProperty("btnClone")]
        Button _btnClone;


        [AccessedThroughProperty("btnDelete")]
        Button _btnDelete;


        [AccessedThroughProperty("btnDown")]
        Button _btnDown;


        [AccessedThroughProperty("btnEdit")]
        Button _btnEdit;


        [AccessedThroughProperty("btnSave")]
        Button _btnSave;


        [AccessedThroughProperty("btnUp")]
        Button _btnUp;


        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ColumnHeader6")]
        ColumnHeader _ColumnHeader6;


        [AccessedThroughProperty("ilSets")]
        ImageList _ilSets;


        [AccessedThroughProperty("lvSets")]
        ListView _lvSets;


        [AccessedThroughProperty("NoReload")]
        CheckBox _NoReload;
    }
}
