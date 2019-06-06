using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    // Token: 0x02000040 RID: 64

    public partial class frmImport_Recipe : Form
    {
        // Token: 0x17000402 RID: 1026
        // (get) Token: 0x06000BF7 RID: 3063 RVA: 0x00077370 File Offset: 0x00075570
        // (set) Token: 0x06000BF8 RID: 3064 RVA: 0x00077388 File Offset: 0x00075588
        internal virtual Button btnAttribIndex
        {
            get
            {
                return this._btnAttribIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAttribIndex_Click);
                if (this._btnAttribIndex != null)
                {
                    this._btnAttribIndex.Click -= eventHandler;
                }
                this._btnAttribIndex = value;
                if (this._btnAttribIndex != null)
                {
                    this._btnAttribIndex.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000403 RID: 1027
        // (get) Token: 0x06000BF9 RID: 3065 RVA: 0x000773E4 File Offset: 0x000755E4
        // (set) Token: 0x06000BFA RID: 3066 RVA: 0x000773FC File Offset: 0x000755FC
        internal virtual Button btnAttribLoad
        {
            get
            {
                return this._btnAttribLoad;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAttribLoad_Click);
                if (this._btnAttribLoad != null)
                {
                    this._btnAttribLoad.Click -= eventHandler;
                }
                this._btnAttribLoad = value;
                if (this._btnAttribLoad != null)
                {
                    this._btnAttribLoad.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000404 RID: 1028
        // (get) Token: 0x06000BFB RID: 3067 RVA: 0x00077458 File Offset: 0x00075658
        // (set) Token: 0x06000BFC RID: 3068 RVA: 0x00077470 File Offset: 0x00075670
        internal virtual Button btnAttribTable
        {
            get
            {
                return this._btnAttribTable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAttribTable_Click);
                if (this._btnAttribTable != null)
                {
                    this._btnAttribTable.Click -= eventHandler;
                }
                this._btnAttribTable = value;
                if (this._btnAttribTable != null)
                {
                    this._btnAttribTable.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000405 RID: 1029
        // (get) Token: 0x06000BFD RID: 3069 RVA: 0x000774CC File Offset: 0x000756CC
        // (set) Token: 0x06000BFE RID: 3070 RVA: 0x000774E4 File Offset: 0x000756E4
        internal virtual Button Button1
        {
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Button1_Click);
                if (this._Button1 != null)
                {
                    this._Button1.Click -= eventHandler;
                }
                this._Button1 = value;
                if (this._Button1 != null)
                {
                    this._Button1.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000406 RID: 1030
        // (get) Token: 0x06000BFF RID: 3071 RVA: 0x00077540 File Offset: 0x00075740
        // (set) Token: 0x06000C00 RID: 3072 RVA: 0x00077558 File Offset: 0x00075758
        internal virtual OpenFileDialog dlgBrowse
        {
            get
            {
                return this._dlgBrowse;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgBrowse = value;
            }
        }

        // Token: 0x17000407 RID: 1031
        // (get) Token: 0x06000C01 RID: 3073 RVA: 0x00077564 File Offset: 0x00075764
        // (set) Token: 0x06000C02 RID: 3074 RVA: 0x0007757C File Offset: 0x0007577C
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }

        // Token: 0x17000408 RID: 1032
        // (get) Token: 0x06000C03 RID: 3075 RVA: 0x00077588 File Offset: 0x00075788
        // (set) Token: 0x06000C04 RID: 3076 RVA: 0x000775A0 File Offset: 0x000757A0
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }

        // Token: 0x17000409 RID: 1033
        // (get) Token: 0x06000C05 RID: 3077 RVA: 0x000775AC File Offset: 0x000757AC
        // (set) Token: 0x06000C06 RID: 3078 RVA: 0x000775C4 File Offset: 0x000757C4
        internal virtual Label lblAttribDate
        {
            get
            {
                return this._lblAttribDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribDate = value;
            }
        }

        // Token: 0x1700040A RID: 1034
        // (get) Token: 0x06000C07 RID: 3079 RVA: 0x000775D0 File Offset: 0x000757D0
        // (set) Token: 0x06000C08 RID: 3080 RVA: 0x000775E8 File Offset: 0x000757E8
        internal virtual Label lblAttribIndex
        {
            get
            {
                return this._lblAttribIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribIndex = value;
            }
        }

        // Token: 0x1700040B RID: 1035
        // (get) Token: 0x06000C09 RID: 3081 RVA: 0x000775F4 File Offset: 0x000757F4
        // (set) Token: 0x06000C0A RID: 3082 RVA: 0x0007760C File Offset: 0x0007580C
        internal virtual Label lblAttribTableCount
        {
            get
            {
                return this._lblAttribTableCount;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribTableCount = value;
            }
        }

        // Token: 0x1700040C RID: 1036
        // (get) Token: 0x06000C0B RID: 3083 RVA: 0x00077618 File Offset: 0x00075818
        // (set) Token: 0x06000C0C RID: 3084 RVA: 0x00077630 File Offset: 0x00075830
        internal virtual Label lblAttribTables
        {
            get
            {
                return this._lblAttribTables;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribTables = value;
            }
        }

        // Token: 0x06000C0D RID: 3085 RVA: 0x0007763A File Offset: 0x0007583A
        public frmImport_Recipe()
        {
            base.Load += this.frmImport_Recipe_Load;
            this.InitializeComponent();
        }

        // Token: 0x06000C0E RID: 3086 RVA: 0x00077660 File Offset: 0x00075860
        private void btnAttribIndex_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribIndex.Text = this.dlgBrowse.FileName;
            }
        }

        // Token: 0x06000C0F RID: 3087 RVA: 0x000776B4 File Offset: 0x000758B4
        private void btnAttribLoad_Click(object sender, EventArgs e)
        {
            if (this.lblAttribIndex.Text != "" & this.lblAttribTables.Text != "")
            {
                if (File.Exists(this.lblAttribIndex.Text) & File.Exists(this.lblAttribTables.Text))
                {
                    this.ImportRecipeCSV(this.lblAttribIndex.Text, this.lblAttribTables.Text);
                }
                else
                {
                    Interaction.MsgBox("Files cannot be found!", MsgBoxStyle.Exclamation, "No Can Do");
                }
            }
            else
            {
                Interaction.MsgBox("Files not selected!", MsgBoxStyle.Exclamation, "No Can Do");
            }
        }

        // Token: 0x06000C10 RID: 3088 RVA: 0x0007776C File Offset: 0x0007596C
        private void btnAttribTable_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribTables.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribTables.Text = this.dlgBrowse.FileName;
            }
        }

        // Token: 0x06000C11 RID: 3089 RVA: 0x000777C0 File Offset: 0x000759C0
        private void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }

        // Token: 0x06000C12 RID: 3090 RVA: 0x000777F0 File Offset: 0x000759F0
        private void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show();
            }
            this.bFrm.SetMessage(sMessage);
        }

        // Token: 0x06000C13 RID: 3091 RVA: 0x00077834 File Offset: 0x00075A34
        private void Button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000C15 RID: 3093 RVA: 0x00077890 File Offset: 0x00075A90
        private void frmImport_Recipe_Load(object sender, EventArgs e)
        {
        }

        // Token: 0x06000C16 RID: 3094 RVA: 0x00077894 File Offset: 0x00075A94
        private bool ImportRecipeCSV(string iFName1, string iFName2)
        {
            StreamReader iStream;
            StreamReader iStream2;
            try
            {
                iStream = new StreamReader(iFName1);
                iStream2 = new StreamReader(iFName2);
            }
            catch (Exception ex)
            {
                Exception ex3 = ex;
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Recipe CSVs Not Opened");
                return false;
            }
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            Recipe[] recipeArray = new Recipe[0];
            DatabaseAPI.Database.Recipes = recipeArray;
            try
            {
                string iLine2;
                do
                {
                    iLine2 = FileIO.ReadLineUnlimited(iStream, '\0');
                    if (iLine2 != null && !iLine2.StartsWith("#"))
                    {
                        num8++;
                        if (num8 >= 18)
                        {
                            this.BusyMsg(Strings.Format(num5, "###,##0") + " Recipes Created.");
                            num8 = 0;
                        }
                        string[] array = CSV.ToArray(iLine2);
                        if (array.Length >= 18)
                        {
                            bool flag = false;
                            string iName = array[0];
                            if (iName.Contains("_Memorized"))
                            {
                                iName = iName.Replace("_Memorized", "");
                                flag = true;
                            }
                            if (iName.LastIndexOf("_", StringComparison.Ordinal) > 0)
                            {
                                iName = iName.Substring(0, iName.LastIndexOf("_", StringComparison.Ordinal));
                            }
                            int num9 = (int)Math.Round(Conversion.Val(array[10]));
                            Recipe recipe = DatabaseAPI.GetRecipeByName(iName);
                            if (recipe == null)
                            {
                                IDatabase database = DatabaseAPI.Database;
                                recipeArray = (Recipe[])Utils.CopyArray(database.Recipes, new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
                                database.Recipes = recipeArray;
                                DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
                                recipe = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1];
                                Recipe recipe2 = recipe;
                                recipe2.InternalName = iName;
                                if (array[1] != "")
                                {
                                    recipe2.ExternalName = array[1];
                                }
                                else
                                {
                                    recipe2.ExternalName = iName;
                                }
                                recipe2.Rarity = (Recipe.RecipeRarity)Math.Round(Conversion.Val(array[9]) - 1.0);
                            }
                            int index = -1;
                            Recipe recipe3 = recipe;
                            int num10 = recipe3.Item.Length - 1;
                            for (int index2 = 0; index2 <= num10; index2++)
                            {
                                if (recipe3.Item[index2].Level == num9 - 1)
                                {
                                    index = index2;
                                }
                            }
                            if (index < 0)
                            {
                                index = recipe3.Item.Length;
                                recipe3.Item = (Recipe.RecipeEntry[])Utils.CopyArray(recipe3.Item, new Recipe.RecipeEntry[index + 1]);
                                recipe3.Item[index] = new Recipe.RecipeEntry();
                            }
                            recipe3.Item[index].Level = num9 - 1;
                            if (flag)
                            {
                                recipe3.Item[index].BuyCostM = (int)Math.Round(Conversion.Val(array[15]));
                                recipe3.Item[index].CraftCostM = (int)Math.Round(Conversion.Val(array[11]));
                            }
                            else
                            {
                                recipe3.Item[index].BuyCost = (int)Math.Round(Conversion.Val(array[15]));
                                recipe3.Item[index].CraftCost = (int)Math.Round(Conversion.Val(array[11]));
                            }
                            if (array[7].Length > 0)
                            {
                                int index3 = DatabaseAPI.NidFromUidEnhExtended(array[7]);
                                if (index3 > -1)
                                {
                                    recipe3.Enhancement = DatabaseAPI.Database.Enhancements[index3].UID;
                                    DatabaseAPI.Database.Enhancements[index3].RecipeName = recipe3.InternalName;
                                }
                            }
                            num5++;
                        }
                    }
                }
                while (iLine2 != null);
                iStream.Close();
                num5 = 0;
                do
                {
                    iLine2 = FileIO.ReadLineUnlimited(iStream2, '\0');
                    if (iLine2 != null && !iLine2.StartsWith("#"))
                    {
                        num8++;
                        if (num8 >= 18)
                        {
                            this.BusyMsg(Strings.Format(num5, "###,##0") + " Recipes Created.");
                            num8 = 0;
                        }
                        string[] array2 = CSV.ToArray(iLine2);
                        if (array2.Length >= 3)
                        {
                            int num11 = -1;
                            bool flag2 = false;
                            string iName2 = array2[0];
                            if (iName2.Contains("_Memorized"))
                            {
                                iName2 = iName2.Replace("_Memorized", "");
                                flag2 = true;
                            }
                            if (iName2.LastIndexOf("_", StringComparison.Ordinal) > 0)
                            {
                                num11 = (int)Math.Round(Conversion.Val(iName2.Substring(iName2.LastIndexOf("_", StringComparison.Ordinal) + 1)));
                                iName2 = iName2.Substring(0, iName2.LastIndexOf("_", StringComparison.Ordinal));
                            }
                            if (num11 > -1 & !flag2)
                            {
                                Recipe recipeByName = DatabaseAPI.GetRecipeByName(iName2);
                                if (recipeByName != null)
                                {
                                    int index4 = -1;
                                    num5++;
                                    Recipe recipe4 = recipeByName;
                                    int num12 = recipe4.Item.Length - 1;
                                    for (int index5 = 0; index5 <= num12; index5++)
                                    {
                                        if (recipe4.Item[index5].Level == num11 - 1)
                                        {
                                            index4 = index5;
                                        }
                                    }
                                    if (index4 > -1)
                                    {
                                        int index6 = -1;
                                        int num13 = recipe4.Item[index4].Salvage.Length - 1;
                                        for (int index7 = 0; index7 <= num13; index7++)
                                        {
                                            if (recipe4.Item[index4].Salvage[index7] == "")
                                            {
                                                index6 = index7;
                                                break;
                                            }
                                        }
                                        if (index6 > -1)
                                        {
                                            recipe4.Item[index4].Salvage[index6] = array2[2];
                                            recipe4.Item[index4].Count[index6] = (int)Math.Round(Conversion.Val(array2[1]));
                                            recipe4.Item[index4].SalvageIdx[index6] = -1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                while (iLine2 != null);
                DatabaseAPI.AssignRecipeSalvageIDs();
                DatabaseAPI.GuessRecipes();
                DatabaseAPI.AssignRecipeIDs();
                Interaction.MsgBox("Done. Recipe-Enhancement links have been guessed.", MsgBoxStyle.Information, "Import");
            }
            catch (Exception ex2)
            {
                Exception exception = ex2;
                iStream.Close();
                iStream2.Close();
                this.BusyHide();
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "CSV Parse Error");
                return false;
            }
            this.BusyHide();
            iStream2.Close();
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Parse Completed!\r\nTotal Records: ",
                Conversions.ToString(num5),
                "\r\nGood: ",
                Conversions.ToString(num6),
                "\r\nRejected: ",
                Conversions.ToString(num7)
            }), MsgBoxStyle.Information, "File Parsed");
            DatabaseAPI.SaveRecipes();
            DatabaseAPI.SaveEnhancementDb();
            return true;
        }

        // Token: 0x040004EF RID: 1263
        [AccessedThroughProperty("btnAttribIndex")]
        private Button _btnAttribIndex;

        // Token: 0x040004F0 RID: 1264
        [AccessedThroughProperty("btnAttribLoad")]
        private Button _btnAttribLoad;

        // Token: 0x040004F1 RID: 1265
        [AccessedThroughProperty("btnAttribTable")]
        private Button _btnAttribTable;

        // Token: 0x040004F2 RID: 1266
        [AccessedThroughProperty("Button1")]
        private Button _Button1;

        // Token: 0x040004F3 RID: 1267
        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;

        // Token: 0x040004F4 RID: 1268
        [AccessedThroughProperty("Label3")]
        private Label _Label3;

        // Token: 0x040004F5 RID: 1269
        [AccessedThroughProperty("Label4")]
        private Label _Label4;

        // Token: 0x040004F6 RID: 1270
        [AccessedThroughProperty("lblAttribDate")]
        private Label _lblAttribDate;

        // Token: 0x040004F7 RID: 1271
        [AccessedThroughProperty("lblAttribIndex")]
        private Label _lblAttribIndex;

        // Token: 0x040004F8 RID: 1272
        [AccessedThroughProperty("lblAttribTableCount")]
        private Label _lblAttribTableCount;

        // Token: 0x040004F9 RID: 1273
        [AccessedThroughProperty("lblAttribTables")]
        private Label _lblAttribTables;

        // Token: 0x040004FA RID: 1274
        private frmBusy bFrm;
    }
}
