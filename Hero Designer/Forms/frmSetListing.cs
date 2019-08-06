
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    public partial class frmSetListing : Form
    {

        public frmSetListing()
        {
            Load += frmSetListing_Load;
            InitializeComponent();
            Name = nameof(frmSetListing);
            var componentResourceManager = new ComponentResourceManager(typeof(frmSetListing));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
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
            int num1 = 0;
            int num2 = enhancementSet.Bonus.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (enhancementSet.Bonus[index].Index.Length > 0)
                    ++num1;
            }
            items[5] = Conversions.ToString(num1);
            lvSets.Items.Add(new ListViewItem(items, Index));
            lvSets.Items[lvSets.Items.Count - 1].Selected = true;
            lvSets.Items[lvSets.Items.Count - 1].EnsureVisible();
        }

        void btnAdd_Click(object sender, EventArgs e)

        {
            EnhancementSet iSet = new EnhancementSet();
            frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
            int num = (int)frmSetEdit.ShowDialog();
            if (frmSetEdit.DialogResult != DialogResult.OK)
                return;
            DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(frmSetEdit.mySet));
            ImageUpdate();
            AddListItem(DatabaseAPI.Database.EnhancementSets.Count - 1);
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            Hide();
        }

        void btnClone_Click(object sender, EventArgs e)

        {
            if (lvSets.SelectedIndices.Count <= 0)
                return;
            EnhancementSet iSet = new EnhancementSet(DatabaseAPI.Database.EnhancementSets[lvSets.SelectedIndices[0]]);
            iSet.DisplayName += " Copy";
            frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
            int num = (int)frmSetEdit.ShowDialog();
            if (frmSetEdit.DialogResult == DialogResult.OK)
            {
                DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(frmSetEdit.mySet));
                ImageUpdate();
                AddListItem(DatabaseAPI.Database.EnhancementSets.Count - 1);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)

        {
            if (lvSets.SelectedIndices.Count <= 0 || Interaction.MsgBox(("Really delete set: " + lvSets.SelectedItems[0].Text + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.Yes)
                return;
            int selectedIndex = lvSets.SelectedIndices[0];
            DatabaseAPI.Database.EnhancementSets.RemoveAt(selectedIndex);
            DatabaseAPI.MatchEnhancementIDs();
            DisplayList();
            if (lvSets.Items.Count > 0)
            {
                if (lvSets.Items.Count > selectedIndex)
                    lvSets.Items[selectedIndex].Selected = true;
                else if (lvSets.Items.Count == selectedIndex)
                    lvSets.Items[selectedIndex - 1].Selected = true;
            }
        }

        void btnDown_Click(object sender, EventArgs e)

        {
            if (lvSets.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = lvSets.SelectedIndices[0];
            if (selectedIndex < lvSets.Items.Count - 1)
            {
                EnhancementSet[] enhancementSetArray = new EnhancementSet[2]
                {
          new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex]),
          new EnhancementSet(DatabaseAPI.Database.EnhancementSets[selectedIndex + 1])
                };
                DatabaseAPI.Database.EnhancementSets[selectedIndex + 1] = new EnhancementSet(enhancementSetArray[0]);
                DatabaseAPI.Database.EnhancementSets[selectedIndex] = new EnhancementSet(enhancementSetArray[1]);
                DatabaseAPI.MatchEnhancementIDs();
                ListViewItem listViewItem1 = (ListViewItem)lvSets.Items[selectedIndex].Clone();
                ListViewItem listViewItem2 = (ListViewItem)lvSets.Items[selectedIndex + 1].Clone();
                lvSets.Items[selectedIndex] = listViewItem2;
                lvSets.Items[selectedIndex + 1] = listViewItem1;
                lvSets.Items[selectedIndex + 1].Selected = true;
                lvSets.Items[selectedIndex + 1].EnsureVisible();
            }
        }

        void btnEdit_Click(object sender, EventArgs e)

        {
            if (lvSets.SelectedIndices.Count <= 0)
                return;
            bool flag = false;
            string uidOld = "";
            int selectedIndex1 = lvSets.SelectedIndices[0];
            EnhancementSetCollection enhancementSets = DatabaseAPI.Database.EnhancementSets;
            int selectedIndex2 = lvSets.SelectedIndices[0];
            EnhancementSet iSet = enhancementSets[selectedIndex2];
            enhancementSets[selectedIndex2] = iSet;
            frmSetEdit frmSetEdit = new frmSetEdit(ref iSet);
            int num = (int)frmSetEdit.ShowDialog();
            if (frmSetEdit.DialogResult == DialogResult.OK)
            {
                if (frmSetEdit.mySet.Uid != DatabaseAPI.Database.EnhancementSets[lvSets.SelectedIndices[0]].Uid)
                {
                    flag = true;
                    uidOld = DatabaseAPI.Database.EnhancementSets[lvSets.SelectedIndices[0]].Uid;
                }
                DatabaseAPI.Database.EnhancementSets[lvSets.SelectedIndices[0]] = new EnhancementSet(frmSetEdit.mySet);
                ImageUpdate();
                UpdateListItem(selectedIndex1);
                if (flag)
                {
                    RenameIOSet(uidOld, frmSetEdit.mySet.Uid);
                    DatabaseAPI.MatchEnhancementIDs();
                }
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var serializer = MyApplication.GetSerializer();
            DatabaseAPI.SaveEnhancementDb(serializer);
            Hide();
        }

        void btnUp_Click(object sender, EventArgs e)

        {
            if (lvSets.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = lvSets.SelectedIndices[0];
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
                ListViewItem listViewItem1 = (ListViewItem)lvSets.Items[selectedIndex].Clone();
                ListViewItem listViewItem2 = (ListViewItem)lvSets.Items[selectedIndex - 1].Clone();
                lvSets.Items[selectedIndex] = listViewItem2;
                lvSets.Items[selectedIndex - 1] = listViewItem1;
                lvSets.Items[selectedIndex - 1].Selected = true;
                lvSets.Items[selectedIndex - 1].EnsureVisible();
            }
        }

        public void DisplayList()
        {
            lvSets.BeginUpdate();
            lvSets.Items.Clear();
            ImageUpdate();
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int Index = 0; Index <= num; ++Index)
                AddListItem(Index);
            if (lvSets.Items.Count > 0)
            {
                lvSets.Items[0].Selected = true;
                lvSets.Items[0].EnsureVisible();
            }
            lvSets.EndUpdate();
        }

        public void FillImageList()
        {
            Size imageSize1 = ilSets.ImageSize;
            int width1 = imageSize1.Width;
            imageSize1 = ilSets.ImageSize;
            int height1 = imageSize1.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
            ilSets.Images.Clear();
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (DatabaseAPI.Database.EnhancementSets[index].ImageIdx > -1)
                {
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancementSet(ref graphics, DatabaseAPI.Database.EnhancementSets[index].ImageIdx);
                    ilSets.Images.Add(extendedBitmap.Bitmap);
                }
                else
                {
                    ImageList.ImageCollection images = ilSets.Images;
                    Size imageSize2 = ilSets.ImageSize;
                    int width2 = imageSize2.Width;
                    imageSize2 = ilSets.ImageSize;
                    int height2 = imageSize2.Height;
                    Bitmap bitmap = new Bitmap(width2, height2);
                    images.Add(bitmap);
                }
            }
        }

        void frmSetListing_Load(object sender, EventArgs e)

        {
            DisplayList();
        }

        public void ImageUpdate()
        {
            if (NoReload.Checked)
                return;
            I9Gfx.LoadSets();
            FillImageList();
        }

        [DebuggerStepThrough]

        void lvSets_DoubleClick(object sender, EventArgs e)

        {
            btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void lvSets_SelectedIndexChanged(object sender, EventArgs e)

        {
        }

        void NoReload_CheckedChanged(object sender, EventArgs e)

        {
            ImageUpdate();
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
            strArray[1] = Enum.GetName(enhancementSet.SetType.GetType(), enhancementSet.SetType);
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
                lvSets.Items[Index].SubItems[index].Text = strArray[index];
            lvSets.Items[Index].ImageIndex = Index;
            lvSets.Refresh();
        }
    }
}