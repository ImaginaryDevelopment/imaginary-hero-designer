
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
    public partial class frmEnhEdit : Form
    {
        public frmEnhEdit()
        {
            this.Load += new EventHandler(this.frmEnhEdit_Load);
            this.InitializeComponent();
            this.Name = nameof(frmEnhEdit);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmEnhEdit));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
        }

        void AddListItem(int Index)
        {
            string[] items = new string[5];
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[Index];
            items[0] = enhancement.Name + " (" + enhancement.ShortName + ") - " + Conversions.ToString(enhancement.StaticIndex);
            items[1] = Enum.GetName(enhancement.TypeID.GetType(), enhancement.TypeID);
            items[2] = Conversions.ToString(enhancement.Effect.Length);
            items[3] = "";
            int num1 = enhancement.ClassID.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                if (items[3] != "")
                {
                    string[] strArray1 = items;
                    int num2 = 3;
                    string[] strArray2;
                    IntPtr index2;
                    (strArray2 = strArray1)[(int)(index2 = (IntPtr)num2)] = strArray2[(int)index2] + ",";
                }
                string[] strArray3 = items;
                int num3 = 3;
                string[] strArray4;
                IntPtr index3;
                (strArray4 = strArray3)[(int)(index3 = (IntPtr)num3)] = strArray4[(int)index3] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index1]].ShortName;
            }
            if (enhancement.nIDSet > -1)
            {
                items[4] = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName;
                items[0] = items[4] + ": " + items[0];
            }
            else
                items[4] = "";
            this.lvEnh.Items.Add(new ListViewItem(items, Index));
            this.lvEnh.Items[this.lvEnh.Items.Count - 1].Selected = true;
            this.lvEnh.Items[this.lvEnh.Items.Count - 1].EnsureVisible();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            IEnhancement iEnh = (IEnhancement)new Enhancement();
            frmEnhData frmEnhData = new frmEnhData(ref iEnh);
            int num = (int)frmEnhData.ShowDialog();
            if (frmEnhData.DialogResult != DialogResult.OK)
                return;
            IDatabase database = DatabaseAPI.Database;
            IEnhancement[] enhancementArray = (IEnhancement[])Utils.CopyArray(database.Enhancements, (Array)new IEnhancement[DatabaseAPI.Database.Enhancements.Length + 1]);
            database.Enhancements = enhancementArray;
            DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1] = (IEnhancement)new Enhancement(frmEnhData.myEnh);
            DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].IsNew = true;
            DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].StaticIndex = -1;
            this.ImageUpdate();
            this.AddListItem(DatabaseAPI.Database.Enhancements.Length - 1);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void btnClone_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count <= 0)
                return;
            frmEnhData frmEnhData = new frmEnhData(ref DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]]);
            int num = (int)frmEnhData.ShowDialog();
            if (frmEnhData.DialogResult == DialogResult.OK)
            {
                IDatabase database = DatabaseAPI.Database;
                IEnhancement[] enhancementArray = (IEnhancement[])Utils.CopyArray(database.Enhancements, new IEnhancement[DatabaseAPI.Database.Enhancements.Length + 1]);
                database.Enhancements = enhancementArray;
                DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1] = (IEnhancement)new Enhancement(frmEnhData.myEnh);
                DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].IsNew = true;
                DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Enhancements.Length - 1].StaticIndex = -1;
                this.ImageUpdate();
                this.AddListItem(DatabaseAPI.Database.Enhancements.Length - 1);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count <= 0 || Interaction.MsgBox(("Really delete enhancement: " + this.lvEnh.SelectedItems[0].Text + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.Yes)
                return;
            Enhancement[] enhancementArray = new Enhancement[DatabaseAPI.Database.Enhancements.Length - 1 + 1];
            int selectedIndex = this.lvEnh.SelectedIndices[0];
            int index1 = 0;
            int num1 = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index2 = 0; index2 <= num1; ++index2)
            {
                if (index2 != selectedIndex)
                {
                    enhancementArray[index1] = new Enhancement(DatabaseAPI.Database.Enhancements[index2]);
                    ++index1;
                }
            }
            DatabaseAPI.Database.Enhancements = new IEnhancement[DatabaseAPI.Database.Enhancements.Length - 2 + 1];
            int num2 = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
                DatabaseAPI.Database.Enhancements[index2] = (IEnhancement)new Enhancement((IEnhancement)enhancementArray[index2]);
            this.DisplayList();
            if (this.lvEnh.Items.Count > 0)
            {
                if (this.lvEnh.Items.Count > selectedIndex)
                {
                    this.lvEnh.Items[selectedIndex].Selected = true;
                    this.lvEnh.Items[selectedIndex].EnsureVisible();
                }
                else if (this.lvEnh.Items.Count == selectedIndex)
                {
                    this.lvEnh.Items[selectedIndex - 1].Selected = true;
                    this.lvEnh.Items[selectedIndex - 1].EnsureVisible();
                }
            }
        }

        void btnDown_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvEnh.SelectedIndices[0];
            if (selectedIndex < this.lvEnh.Items.Count - 1)
            {
                IEnhancement[] enhancementArray = new IEnhancement[2]
                {
          (IEnhancement) new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex]),
          (IEnhancement) new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex + 1])
                };
                DatabaseAPI.Database.Enhancements[selectedIndex + 1] = (IEnhancement)new Enhancement(enhancementArray[0]);
                DatabaseAPI.Database.Enhancements[selectedIndex] = (IEnhancement)new Enhancement(enhancementArray[1]);
                this.DisplayList();
                this.lvEnh.Items[selectedIndex + 1].Selected = true;
                this.lvEnh.Items[selectedIndex + 1].EnsureVisible();
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvEnh.SelectedIndices[0];
            frmEnhData frmEnhData = new frmEnhData(ref DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]]);
            int num = (int)frmEnhData.ShowDialog();
            if (frmEnhData.DialogResult == DialogResult.OK)
            {
                DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]] = (IEnhancement)new Enhancement(frmEnhData.myEnh);
                DatabaseAPI.Database.Enhancements[this.lvEnh.SelectedIndices[0]].IsModified = true;
                this.ImageUpdate();
                this.UpdateListItem(selectedIndex);
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            I9Gfx.LoadEnhancements();
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.AssignStaticIndexValues(serializer);
            DatabaseAPI.AssignRecipeIDs();
            DatabaseAPI.SaveEnhancementDb(serializer);
            this.Hide();
        }

        void btnUp_Click(object sender, EventArgs e)
        {
            if (this.lvEnh.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lvEnh.SelectedIndices[0];
            if (selectedIndex >= 1)
            {
                IEnhancement[] enhancementArray = new IEnhancement[2]
                {
                   new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex]),
                   new Enhancement(DatabaseAPI.Database.Enhancements[selectedIndex - 1])
                };
                DatabaseAPI.Database.Enhancements[selectedIndex - 1] = (IEnhancement)new Enhancement(enhancementArray[0]);
                DatabaseAPI.Database.Enhancements[selectedIndex] = (IEnhancement)new Enhancement(enhancementArray[1]);
                this.DisplayList();
                this.lvEnh.Items[selectedIndex - 1].Selected = true;
                this.lvEnh.Items[selectedIndex - 1].EnsureVisible();
            }
        }

        void DisplayList()
        {
            this.ImageUpdate();
            this.lvEnh.BeginUpdate();
            this.lvEnh.Items.Clear();
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int Index = 0; Index <= num; ++Index)
                this.AddListItem(Index);
            if (this.lvEnh.Items.Count > 0)
            {
                this.lvEnh.Items[0].Selected = true;
                this.lvEnh.Items[0].EnsureVisible();
            }
            this.lvEnh.EndUpdate();
        }

        public void FillImageList()
        {
            Size imageSize1 = this.ilEnh.ImageSize;
            int width1 = imageSize1.Width;
            imageSize1 = this.ilEnh.ImageSize;
            int height1 = imageSize1.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
            this.ilEnh.Images.Clear();
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[index];
                if (enhancement.ImageIdx > -1)
                {
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancement(ref graphics, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(enhancement.TypeID));
                    this.ilEnh.Images.Add((Image)extendedBitmap.Bitmap);
                }
                else
                {
                    ImageList.ImageCollection images = this.ilEnh.Images;
                    Size imageSize2 = this.ilEnh.ImageSize;
                    int width2 = imageSize2.Width;
                    imageSize2 = this.ilEnh.ImageSize;
                    int height2 = imageSize2.Height;
                    Bitmap bitmap = new Bitmap(width2, height2);
                    images.Add((Image)bitmap);
                }
            }
        }

        void frmEnhEdit_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Refresh();
            this.DisplayList();
            this.lblLoading.Visible = false;
            this.lvEnh.Select();
        }

        public void ImageUpdate()
        {
            if (this.NoReload.Checked)
                return;
            I9Gfx.LoadEnhancements();
            this.FillImageList();
        }

        void lvEnh_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void lvEnh_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void NoReload_CheckedChanged(object sender, EventArgs e)
        {
            this.ImageUpdate();
        }

        void UpdateListItem(int Index)
        {
            string[] strArray1 = new string[5];
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[Index];
            strArray1[0] = enhancement.Name + " (" + enhancement.ShortName + ") - " + Conversions.ToString(enhancement.StaticIndex);
            strArray1[1] = Enum.GetName(enhancement.TypeID.GetType(), enhancement.TypeID);
            strArray1[2] = Conversions.ToString(enhancement.Effect.Length);
            strArray1[3] = "";
            int num1 = enhancement.ClassID.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                if (strArray1[3] != "")
                {
                    string[] strArray2 = strArray1;
                    int num2 = 3;
                    string[] strArray3;
                    IntPtr index2;
                    (strArray3 = strArray2)[(int)(index2 = (IntPtr)num2)] = strArray3[(int)index2] + ",";
                }
                string[] strArray4 = strArray1;
                int num3 = 3;
                string[] strArray5;
                IntPtr index3;
                (strArray5 = strArray4)[(int)(index3 = (IntPtr)num3)] = strArray5[(int)index3] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index1]].ShortName;
            }
            if (enhancement.nIDSet > -1)
            {
                strArray1[4] = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName;
                strArray1[0] = strArray1[4] + ": " + strArray1[0];
            }
            else
                strArray1[4] = "";
            int num4 = strArray1.Length - 1;
            for (int index = 0; index <= num4; ++index)
                this.lvEnh.Items[Index].SubItems[index].Text = strArray1[index];
            this.lvEnh.Items[Index].ImageIndex = Index;
            this.lvEnh.Items[Index].EnsureVisible();
            this.lvEnh.Refresh();
        }
    }
}