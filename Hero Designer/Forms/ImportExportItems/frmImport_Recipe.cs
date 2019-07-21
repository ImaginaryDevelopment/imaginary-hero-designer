
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmImport_Recipe : Form
    {

        frmBusy bFrm;

        public frmImport_Recipe()
        {
            this.Load += new EventHandler(this.frmImport_Recipe_Load);
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmImport_Recipe));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmImport_Recipe);
        }

        void btnAttribIndex_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog(this) != DialogResult.OK)
                return;
            this.lblAttribIndex.Text = this.dlgBrowse.FileName;
        }

        void btnAttribLoad_Click(object sender, EventArgs e)
        {
            if (this.lblAttribIndex.Text != "" & this.lblAttribTables.Text != "")
            {
                if (File.Exists(this.lblAttribIndex.Text) & File.Exists(this.lblAttribTables.Text))
                    this.ImportRecipeCSV(this.lblAttribIndex.Text, this.lblAttribTables.Text);
                else
                    Interaction.MsgBox("Files cannot be found!", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else
                Interaction.MsgBox("Files not selected!", MsgBoxStyle.Exclamation, "No Can Do");
        }

        void btnAttribTable_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribTables.Text;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) != DialogResult.OK)
                return;
            this.lblAttribTables.Text = this.dlgBrowse.FileName;
        }

        void BusyHide()
        {
            if (this.bFrm == null)
                return;
            this.bFrm.Close();
            this.bFrm = null;
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
            this.Close();
        }

        void frmImport_Recipe_Load(object sender, EventArgs e)
        {
        }

        bool ImportRecipeCSV(string iFName1, string iFName2)
        {
            StreamReader iStream1;
            StreamReader iStream2;
            try
            {
                iStream1 = new StreamReader(iFName1);
                iStream2 = new StreamReader(iFName2);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Recipe CSVs Not Opened");
                return false;
            }
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            DatabaseAPI.Database.Recipes = new Recipe[0];
            int num5;
            try
            {
                string iLine1;
                do
                {
                    iLine1 = FileIO.ReadLineUnlimited(iStream1, char.MinValue);
                    if (iLine1 != null && !iLine1.StartsWith("#"))
                    {
                        ++num4;
                        if (num4 >= 18)
                        {
                            this.BusyMsg(Strings.Format(num1, "###,##0") + " Recipes Created.");
                            num4 = 0;
                        }
                        string[] array = CSV.ToArray(iLine1);
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
                                iName = iName.Substring(0, iName.LastIndexOf("_", StringComparison.Ordinal));
                            int num6 = (int)Math.Round(Conversion.Val(array[10]));
                            Recipe recipe1 = DatabaseAPI.GetRecipeByName(iName);
                            if (recipe1 == null)
                            {
                                recipe1 = new Recipe
                                {
                                    InternalName = iName,
                                    ExternalName = !(array[1] != "") ? iName : array[1],
                                    Rarity = (Recipe.RecipeRarity)Math.Round(Conversion.Val(array[9]) - 1.0)
                                };
                                DatabaseAPI.Database.Recipes = DatabaseAPI.Database.Recipes.Append(recipe1).ToArray();
                            }
                            int index1 = -1;
                            int num7 = recipe1.Item.Length - 1;
                            for (int index2 = 0; index2 <= num7; ++index2)
                            {
                                if (recipe1.Item[index2].Level == num6 - 1)
                                    index1 = index2;
                            }
                            if (index1 < 0)
                            {
                                recipe1.Item = recipe1.Item.Append(new Recipe.RecipeEntry()).ToArray();
                            }
                            recipe1.Item[index1].Level = num6 - 1;
                            if (flag)
                            {
                                recipe1.Item[index1].BuyCostM = (int)Math.Round(Conversion.Val(array[15]));
                                recipe1.Item[index1].CraftCostM = (int)Math.Round(Conversion.Val(array[11]));
                            }
                            else
                            {
                                recipe1.Item[index1].BuyCost = (int)Math.Round(Conversion.Val(array[15]));
                                recipe1.Item[index1].CraftCost = (int)Math.Round(Conversion.Val(array[11]));
                            }
                            if (array[7].Length > 0)
                            {
                                int index2 = DatabaseAPI.NidFromUidEnhExtended(array[7]);
                                if (index2 > -1)
                                {
                                    recipe1.Enhancement = DatabaseAPI.Database.Enhancements[index2].UID;
                                    DatabaseAPI.Database.Enhancements[index2].RecipeName = recipe1.InternalName;
                                }
                            }
                            ++num1;
                        }
                    }
                }
                while (iLine1 != null);
                iStream1.Close();
                num5 = 0;
                string iLine2;
                do
                {
                    iLine2 = FileIO.ReadLineUnlimited(iStream2, char.MinValue);
                    if (iLine2 != null && !iLine2.StartsWith("#"))
                    {
                        ++num4;
                        if (num4 >= 18)
                        {
                            this.BusyMsg(Strings.Format(num5, "###,##0") + " Recipes Created.");
                            num4 = 0;
                        }
                        string[] array = CSV.ToArray(iLine2);
                        if (array.Length >= 3)
                        {
                            int num6 = -1;
                            bool flag = false;
                            string iName = array[0];
                            if (iName.Contains("_Memorized"))
                            {
                                iName = iName.Replace("_Memorized", "");
                                flag = true;
                            }
                            if (iName.LastIndexOf("_", StringComparison.Ordinal) > 0)
                            {
                                num6 = (int)Math.Round(Conversion.Val(iName.Substring(iName.LastIndexOf("_", StringComparison.Ordinal) + 1)));
                                iName = iName.Substring(0, iName.LastIndexOf("_", StringComparison.Ordinal));
                            }
                            if (num6 > -1 & !flag)
                            {
                                Recipe recipeByName = DatabaseAPI.GetRecipeByName(iName);
                                if (recipeByName != null)
                                {
                                    int index1 = -1;
                                    ++num5;
                                    Recipe recipe = recipeByName;
                                    int num7 = recipe.Item.Length - 1;
                                    for (int index2 = 0; index2 <= num7; ++index2)
                                    {
                                        if (recipe.Item[index2].Level == num6 - 1)
                                            index1 = index2;
                                    }
                                    if (index1 > -1)
                                    {
                                        int index2 = -1;
                                        int num8 = recipe.Item[index1].Salvage.Length - 1;
                                        for (int index3 = 0; index3 <= num8; ++index3)
                                        {
                                            if (recipe.Item[index1].Salvage[index3] == "")
                                            {
                                                index2 = index3;
                                                break;
                                            }
                                        }
                                        if (index2 > -1)
                                        {
                                            recipe.Item[index1].Salvage[index2] = array[2];
                                            recipe.Item[index1].Count[index2] = (int)Math.Round(Conversion.Val(array[1]));
                                            recipe.Item[index1].SalvageIdx[index2] = -1;
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
            catch (Exception ex)
            {
                Exception exception = ex;
                iStream1.Close();
                iStream2.Close();
                this.BusyHide();
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "CSV Parse Error");
                return false;
            }
            this.BusyHide();
            iStream2.Close();
            Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + num5.ToString() + "\r\nGood: " + num2.ToString() + "\r\nRejected: " + num3.ToString()), MsgBoxStyle.Information, "File Parsed");
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveRecipes(serializer);
            DatabaseAPI.SaveEnhancementDb(serializer);
            return true;
        }
    }
}