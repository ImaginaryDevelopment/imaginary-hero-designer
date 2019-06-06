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


    public partial class frmImport_Recipe : Form
    {

    
    
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


        public frmImport_Recipe()
        {
            base.Load += this.frmImport_Recipe_Load;
            this.InitializeComponent();
        }


        void btnAttribIndex_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribIndex.Text = this.dlgBrowse.FileName;
            }
        }


        void btnAttribLoad_Click(object sender, EventArgs e)
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


        void btnAttribTable_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribTables.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribTables.Text = this.dlgBrowse.FileName;
            }
        }


        void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }


        void BusyMsg(string sMessage)
        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show();
            }
            this.bFrm.SetMessage(sMessage);
        }


        void Button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        void frmImport_Recipe_Load(object sender, EventArgs e)
        {
        }


        bool ImportRecipeCSV(string iFName1, string iFName2)
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


        [AccessedThroughProperty("btnAttribIndex")]
        Button _btnAttribIndex;


        [AccessedThroughProperty("btnAttribLoad")]
        Button _btnAttribLoad;


        [AccessedThroughProperty("btnAttribTable")]
        Button _btnAttribTable;


        [AccessedThroughProperty("Button1")]
        Button _Button1;


        [AccessedThroughProperty("dlgBrowse")]
        OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label3")]
        Label _Label3;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("lblAttribDate")]
        Label _lblAttribDate;


        [AccessedThroughProperty("lblAttribIndex")]
        Label _lblAttribIndex;


        [AccessedThroughProperty("lblAttribTableCount")]
        Label _lblAttribTableCount;


        [AccessedThroughProperty("lblAttribTables")]
        Label _lblAttribTables;


        frmBusy bFrm;
    }
}
