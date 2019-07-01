
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmSetListing : Form
    {
        Button btnAdd;

        Button btnCancel;

        Button btnClone;

        Button btnDelete;

        Button btnDown;

        Button btnEdit;

        Button btnSave;

        Button btnUp;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;
        ImageList ilSets;

        [AccessedThroughProperty("lvSets")]
        ListView _lvSets;

        CheckBox NoReload;

        ListView lvSets
        {
            get
            {
                return this._lvSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.lvSets_DoubleClick);
                EventHandler eventHandler2 = new EventHandler(this.lvSets_SelectedIndexChanged);
                if (this._lvSets != null)
                {
                    this._lvSets.DoubleClick -= eventHandler1;
                    this._lvSets.SelectedIndexChanged -= eventHandler2;
                }
                this._lvSets = value;
                if (this._lvSets == null)
                    return;
                this._lvSets.DoubleClick += eventHandler1;
                this._lvSets.SelectedIndexChanged += eventHandler2;
            }
        }
        public frmSetListing()
        {
            this.Load += new EventHandler(this.frmSetListing_Load);
            this.InitializeComponent();
        }

        public void AddListItem(int Index)
        {
            string[] items = new string[6];
            EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[Index];
            items[0] = enhancementSet.DisplayName + " (" + enhancementSet.ShortName + ")";
            items[1] = Enum.GetName(enhancementSet.SetType.GetType(), (object)enhancementSet.SetType);
            items[2] = Conversions.ToString(enhancementSet.LevelMin + 1);
            items[3] = Conversions.ToString(enhancementSet.LevelMax + 1);
            items[4] = Conversions.ToString(enhancementSet.Enhancements.Length);
            int num1 = 0;
            int num2 = enhancementSet.Bonus.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (enhancementSet.Bonus[index].Index.Length > 0)
                    ++num1;
            }
            items[5] = Conversions.ToString(num1);
            this.lvSets.Items.Add(new ListViewItem(items, Index));
            this.lvSets.Items[this.lvSets.Items.Count - 1].Selected = true;
            this.lvSets.Items[this.lvSets.Items.Count - 1].EnsureVisible();
        }

        void btnAdd_Click(object sender, EventArgs e)

        {
            EnhancementSet iSet = new EnhancementSet();
            frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
            int num = (int)frmSetEdit.ShowDialog();
            if (frmSetEdit.DialogResult != DialogResult.OK)
                return;
            DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(frmSetEdit.mySet));
            this.ImageUpdate();
            this.AddListItem(DatabaseAPI.Database.EnhancementSets.Count - 1);
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.Hide();
        }

        void btnClone_Click(object sender, EventArgs e)

        {
            if (this.lvSets.SelectedIndices.Count <= 0)
                return;
            EnhancementSet iSet = new EnhancementSet(DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]]);
            iSet.DisplayName += " Copy";
            frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
            int num = (int)frmSetEdit.ShowDialog();
            if (frmSetEdit.DialogResult == DialogResult.OK)
            {
                DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(frmSetEdit.mySet));
                this.ImageUpdate();
                this.AddListItem(DatabaseAPI.Database.EnhancementSets.Count - 1);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)

        {
            if (this.lvSets.SelectedIndices.Count <= 0 || Interaction.MsgBox((object)("Really delete set: " + this.lvSets.SelectedItems[0].Text + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            int selectedIndex = this.lvSets.SelectedIndices[0];
            DatabaseAPI.Database.EnhancementSets.RemoveAt(selectedIndex);
            DatabaseAPI.MatchEnhancementIDs();
            this.DisplayList();
            if (this.lvSets.Items.Count > 0)
            {
                if (this.lvSets.Items.Count > selectedIndex)
                    this.lvSets.Items[selectedIndex].Selected = true;
                else if (this.lvSets.Items.Count == selectedIndex)
                    this.lvSets.Items[selectedIndex - 1].Selected = true;
            }
        }

        void btnDown_Click(object sender, EventArgs e)

        {
            if (this.lvSets.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvSets.SelectedIndices[0];
            if (selectedIndex < this.lvSets.Items.Count - 1)
            {
                EnhancementSet[] enhancementSetArray = new EnhancementSet[2]
                {
          new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex]),
          new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex + 1])
                };
                DatabaseAPI.Database.EnhancementSets[selectedIndex + 1] = new EnhancementSet(enhancementSetArray[0]);
                DatabaseAPI.Database.EnhancementSets[selectedIndex] = new EnhancementSet(enhancementSetArray[1]);
                DatabaseAPI.MatchEnhancementIDs();
                ListViewItem listViewItem1 = (ListViewItem)this.lvSets.Items[selectedIndex].Clone();
                ListViewItem listViewItem2 = (ListViewItem)this.lvSets.Items[selectedIndex + 1].Clone();
                this.lvSets.Items[selectedIndex] = listViewItem2;
                this.lvSets.Items[selectedIndex + 1] = listViewItem1;
                this.lvSets.Items[selectedIndex + 1].Selected = true;
                this.lvSets.Items[selectedIndex + 1].EnsureVisible();
            }
        }

        void btnEdit_Click(object sender, EventArgs e)

        {
            if (this.lvSets.SelectedIndices.Count <= 0)
                return;
            bool flag = false;
            string uidOld = "";
            int selectedIndex1 = this.lvSets.SelectedIndices[0];
            EnhancementSetCollection enhancementSets = DatabaseAPI.Database.EnhancementSets;
            int selectedIndex2 = this.lvSets.SelectedIndices[0];
            EnhancementSet iSet = enhancementSets[selectedIndex2];
            enhancementSets[selectedIndex2] = iSet;
            frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
            int num = (int)frmSetEdit.ShowDialog();
            if (frmSetEdit.DialogResult == DialogResult.OK)
            {
                if (frmSetEdit.mySet.Uid != DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]].Uid)
                {
                    flag = true;
                    uidOld = DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]].Uid;
                }
                DatabaseAPI.Database.EnhancementSets[this.lvSets.SelectedIndices[0]] = new EnhancementSet(frmSetEdit.mySet);
                this.ImageUpdate();
                this.UpdateListItem(selectedIndex1);
                if (flag)
                {
                    frmSetListing.RenameIOSet(uidOld, frmSetEdit.mySet.Uid);
                    DatabaseAPI.MatchEnhancementIDs();
                }
            }
        }

        void btnSave_Click(object sender, EventArgs e)

        {
            DatabaseAPI.SaveEnhancementDb();
            this.Hide();
        }

        void btnUp_Click(object sender, EventArgs e)

        {
            if (this.lvSets.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvSets.SelectedIndices[0];
            if (selectedIndex >= 1)
            {
                EnhancementSet[] enhancementSetArray = new EnhancementSet[2]
                {
          new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex]),
          new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex - 1])
                };
                DatabaseAPI.Database.EnhancementSets[selectedIndex - 1] = new EnhancementSet(enhancementSetArray[0]);
                DatabaseAPI.Database.EnhancementSets[selectedIndex] = new EnhancementSet(enhancementSetArray[1]);
                DatabaseAPI.MatchEnhancementIDs();
                ListViewItem listViewItem1 = (ListViewItem)this.lvSets.Items[selectedIndex].Clone();
                ListViewItem listViewItem2 = (ListViewItem)this.lvSets.Items[selectedIndex - 1].Clone();
                this.lvSets.Items[selectedIndex] = listViewItem2;
                this.lvSets.Items[selectedIndex - 1] = listViewItem1;
                this.lvSets.Items[selectedIndex - 1].Selected = true;
                this.lvSets.Items[selectedIndex - 1].EnsureVisible();
            }
        }

        public void DisplayList()
        {
            this.lvSets.BeginUpdate();
            this.lvSets.Items.Clear();
            this.ImageUpdate();
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int Index = 0; Index <= num; ++Index)
                this.AddListItem(Index);
            if (this.lvSets.Items.Count > 0)
            {
                this.lvSets.Items[0].Selected = true;
                this.lvSets.Items[0].EnsureVisible();
            }
            this.lvSets.EndUpdate();
        }

        public void FillImageList()
        {
            Size imageSize1 = this.ilSets.ImageSize;
            int width1 = imageSize1.Width;
            imageSize1 = this.ilSets.ImageSize;
            int height1 = imageSize1.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
            this.ilSets.Images.Clear();
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (DatabaseAPI.Database.EnhancementSets[index].ImageIdx > -1)
                {
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancementSet(ref graphics, DatabaseAPI.Database.EnhancementSets[index].ImageIdx);
                    this.ilSets.Images.Add((Image)extendedBitmap.Bitmap);
                }
                else
                {
                    ImageList.ImageCollection images = this.ilSets.Images;
                    Size imageSize2 = this.ilSets.ImageSize;
                    int width2 = imageSize2.Width;
                    imageSize2 = this.ilSets.ImageSize;
                    int height2 = imageSize2.Height;
                    Bitmap bitmap = new Bitmap(width2, height2);
                    images.Add((Image)bitmap);
                }
            }
        }

        void frmSetListing_Load(object sender, EventArgs e)

        {
            this.DisplayList();
        }

        public void ImageUpdate()
        {
            if (this.NoReload.Checked)
                return;
            I9Gfx.LoadSets();
            this.FillImageList();
        }

        [DebuggerStepThrough]

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
            for (int index = 0; index <= num; ++index)
            {
                if (DatabaseAPI.Database.Enhancements[index].UIDSet == uidOld)
                    DatabaseAPI.Database.Enhancements[index].UIDSet = uidNew;
            }
        }

        public void UpdateListItem(int Index)
        {
            string[] strArray = new string[6];
            EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[Index];
            strArray[0] = enhancementSet.DisplayName + " (" + enhancementSet.ShortName + ")";
            strArray[1] = Enum.GetName(enhancementSet.SetType.GetType(), (object)enhancementSet.SetType);
            strArray[2] = Conversions.ToString(enhancementSet.LevelMin + 1);
            strArray[3] = Conversions.ToString(enhancementSet.LevelMax + 1);
            strArray[4] = Conversions.ToString(enhancementSet.Enhancements.Length);
            int num1 = 0;
            int num2 = enhancementSet.Bonus.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (enhancementSet.Bonus[index].Index.Length > 0)
                    ++num1;
            }
            strArray[5] = Conversions.ToString(num1);
            int num3 = strArray.Length - 1;
            for (int index = 0; index <= num3; ++index)
                this.lvSets.Items[Index].SubItems[index].Text = strArray[index];
            this.lvSets.Items[Index].ImageIndex = Index;
            this.lvSets.Refresh();
        }
    }
}