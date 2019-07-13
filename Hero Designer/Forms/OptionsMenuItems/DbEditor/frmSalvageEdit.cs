
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
    public partial class frmSalvageEdit : Form
    {

        public bool Updating;

        public frmSalvageEdit()
        {
            this.Load += new EventHandler(this.frmSalvageEdit_Load);
            this.Updating = true;
            this.InitializeComponent();
            this.Name = nameof(frmSalvageEdit);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmSalvageEdit));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
        }

        protected void AddListItem(int Index)
        {
            string[] items = new string[4];
            if (Index > DatabaseAPI.Database.Salvage.Length - 1 | Index < 0)
                return;
            items[0] = DatabaseAPI.Database.Salvage[Index].ExternalName;
            items[1] = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Origin.GetType(), DatabaseAPI.Database.Salvage[Index].Origin);
            items[2] = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Rarity.GetType(), DatabaseAPI.Database.Salvage[Index].Rarity);
            items[3] = Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMax + 1);
            this.lvSalvage.Items.Add(new ListViewItem(items));
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            IDatabase database = DatabaseAPI.Database;
            Salvage[] salvageArray = (Salvage[])Utils.CopyArray(database.Salvage, (Array)new Salvage[DatabaseAPI.Database.Salvage.Length + 1]);
            database.Salvage = salvageArray;
            DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Salvage.Length - 1] = new Salvage();
            this.AddListItem(DatabaseAPI.Database.Salvage.Length - 1);
            this.lvSalvage.Items[this.lvSalvage.Items.Count - 1].Selected = true;
            this.lvSalvage.Items[this.lvSalvage.Items.Count - 1].EnsureVisible();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            DatabaseAPI.LoadSalvage();
            this.Close();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
                return;
            int selectedIndex = this.lvSalvage.SelectedIndices[0];
            Salvage[] salvageArray = new Salvage[DatabaseAPI.Database.Salvage.Length - 2 + 1];
            int index1 = -1;
            int num1 = DatabaseAPI.Database.Salvage.Length - 1;
            for (int index2 = 0; index2 <= num1; ++index2)
            {
                if (index2 != selectedIndex)
                {
                    ++index1;
                    salvageArray[index1] = new Salvage(ref DatabaseAPI.Database.Salvage[index2]);
                }
            }
            DatabaseAPI.Database.Salvage = new Salvage[salvageArray.Length - 1 + 1];
            int num2 = DatabaseAPI.Database.Salvage.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
                DatabaseAPI.Database.Salvage[index2] = new Salvage(ref salvageArray[index2]);
            this.FillList();
            if (this.lvSalvage.Items.Count > selectedIndex)
                this.lvSalvage.Items[selectedIndex].Selected = true;
            else if (this.lvSalvage.Items.Count > selectedIndex - 1)
                this.lvSalvage.Items[selectedIndex - 1].Selected = true;
            else if (this.lvSalvage.Items.Count > 0)
                this.lvSalvage.Items[0].Selected = true;
        }

        void btnImport_Click(object sender, EventArgs e)
        {
            char[] chArray = new char[1] { '\r' };
            string[] strArray1 = Clipboard.GetDataObject().GetData("System.String", true).ToString().Split(chArray);
            chArray[0] = '\t';
            DatabaseAPI.Database.Salvage = new Salvage[0];
            int num = strArray1.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                string[] strArray2 = strArray1[index].Split(chArray);
                if (strArray2.Length > 7)
                {
                    IDatabase database = DatabaseAPI.Database;
                    Salvage[] salvageArray = (Salvage[])Utils.CopyArray(database.Salvage, new Salvage[DatabaseAPI.Database.Salvage.Length + 1]);
                    database.Salvage = salvageArray;
                    DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Salvage.Length - 1] = new Salvage();
                    Salvage salvage = DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Salvage.Length - 1];
                    if (!strArray2[0].StartsWith("S") & strArray2[0].Length > 2)
                        strArray2[0] = strArray2[0].Substring(1);
                    salvage.InternalName = strArray2[0];
                    salvage.ExternalName = strArray2[1];
                    if (strArray2[10].StartsWith("10"))
                    {
                        salvage.LevelMin = 9;
                        salvage.LevelMax = 24;
                    }
                    else if (strArray2[10].StartsWith("26"))
                    {
                        salvage.LevelMin = 25;
                        salvage.LevelMax = 39;
                    }
                    else
                    {
                        salvage.LevelMin = 40;
                        salvage.LevelMax = 52;
                    }
                    salvage.Origin = strArray2[9].IndexOf("Magic") <= -1 ? Salvage.SalvageOrigin.Tech : Salvage.SalvageOrigin.Magic;
                    salvage.Rarity = (Recipe.RecipeRarity)Math.Round(Conversion.Val(strArray2[6]) - 1.0);
                }
            }
            this.FillList();
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            DatabaseAPI.SaveSalvage(My.MyApplication.GetSerializer());
            this.Close();
        }

        void cbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
                return;
            int selectedIndex = this.lvSalvage.SelectedIndices[0];
            if (this.cbLevel.SelectedIndex == 0)
            {
                DatabaseAPI.Database.Salvage[selectedIndex].LevelMin = 9;
                DatabaseAPI.Database.Salvage[selectedIndex].LevelMax = 24;
            }
            else if (this.cbLevel.SelectedIndex == 1)
            {
                DatabaseAPI.Database.Salvage[selectedIndex].LevelMin = 25;
                DatabaseAPI.Database.Salvage[selectedIndex].LevelMax = 39;
            }
            else
            {
                DatabaseAPI.Database.Salvage[selectedIndex].LevelMin = 40;
                DatabaseAPI.Database.Salvage[selectedIndex].LevelMax = 52;
            }
            this.UpdateListItem(selectedIndex);
        }

        void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
                return;
            int selectedIndex = this.lvSalvage.SelectedIndices[0];
            DatabaseAPI.Database.Salvage[selectedIndex].Origin = (Salvage.SalvageOrigin)this.cbOrigin.SelectedIndex;
            this.UpdateListItem(selectedIndex);
        }

        void cbRarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
                return;
            int selectedIndex = this.lvSalvage.SelectedIndices[0];
            DatabaseAPI.Database.Salvage[selectedIndex].Rarity = (Recipe.RecipeRarity)this.cbRarity.SelectedIndex;
            this.UpdateListItem(selectedIndex);
        }

        protected void DisplayItem(int Index)
        {
            if (Index > DatabaseAPI.Database.Salvage.Length - 1 | Index < 0)
                return;
            this.Updating = true;
            this.cbRarity.SelectedIndex = (int)DatabaseAPI.Database.Salvage[Index].Rarity;
            this.cbOrigin.SelectedIndex = (int)DatabaseAPI.Database.Salvage[Index].Origin;
            int levelMin = DatabaseAPI.Database.Salvage[Index].LevelMin;
            if (levelMin < 25)
                this.cbLevel.SelectedIndex = 0;
            else if (levelMin < 40)
                this.cbLevel.SelectedIndex = 1;
            else if (levelMin < 53)
                this.cbLevel.SelectedIndex = 2;
            this.txtExternal.Text = DatabaseAPI.Database.Salvage[Index].ExternalName;
            this.txtInternal.Text = DatabaseAPI.Database.Salvage[Index].InternalName;
            this.Updating = false;
        }

        protected void FillList()
        {
            this.lvSalvage.BeginUpdate();
            this.lvSalvage.Items.Clear();
            int num = DatabaseAPI.Database.Salvage.Length - 1;
            for (int Index = 0; Index <= num; ++Index)
                this.AddListItem(Index);
            this.lvSalvage.EndUpdate();
        }

        void frmSalvageEdit_Load(object sender, EventArgs e)
        {
            Salvage.SalvageOrigin salvageOrigin = Salvage.SalvageOrigin.Tech;
            Recipe.RecipeRarity recipeRarity = Recipe.RecipeRarity.Common;
            this.FillList();
            this.cbRarity.Items.AddRange((object[])Enum.GetNames(recipeRarity.GetType()));
            this.cbOrigin.Items.AddRange((object[])Enum.GetNames(salvageOrigin.GetType()));
            this.cbLevel.Items.Add("10 - 25");
            this.cbLevel.Items.Add("26 - 40");
            this.cbLevel.Items.Add("41 - 53");
            this.Updating = false;
            if (this.lvSalvage.Items.Count <= 0)
                return;
            this.lvSalvage.Items[0].Selected = true;
        }

        [DebuggerStepThrough]

        void lvSalvage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedIndices.Count <= 0)
                return;
            this.DisplayItem(this.lvSalvage.SelectedIndices[0]);
        }

        void txtExternal_TextChanged(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
                return;
            int selectedIndex = this.lvSalvage.SelectedIndices[0];
            DatabaseAPI.Database.Salvage[selectedIndex].ExternalName = this.txtExternal.Text;
            this.UpdateListItem(selectedIndex);
        }

        void txtInternal_TextChanged(object sender, EventArgs e)
        {
            if (this.lvSalvage.SelectedItems.Count < 1 || this.Updating)
                return;
            int selectedIndex = this.lvSalvage.SelectedIndices[0];
            DatabaseAPI.Database.Salvage[selectedIndex].ExternalName = this.txtInternal.Text;
            this.UpdateListItem(selectedIndex);
        }

        protected void UpdateListItem(int Index)
        {
            if (Index > DatabaseAPI.Database.Salvage.Length - 1 | Index < 0)
                return;
            this.lvSalvage.Items[Index].SubItems[0].Text = DatabaseAPI.Database.Salvage[Index].ExternalName;
            this.lvSalvage.Items[Index].SubItems[1].Text = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Origin.GetType(), DatabaseAPI.Database.Salvage[Index].Origin);
            this.lvSalvage.Items[Index].SubItems[2].Text = Enum.GetName(DatabaseAPI.Database.Salvage[Index].Rarity.GetType(), DatabaseAPI.Database.Salvage[Index].Rarity);
            this.lvSalvage.Items[Index].SubItems[3].Text = Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.Salvage[Index].LevelMax + 1);
        }
    }
}