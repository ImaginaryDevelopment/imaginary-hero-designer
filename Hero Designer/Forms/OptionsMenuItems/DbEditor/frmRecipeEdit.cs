
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Windows.Forms;
using Base;

namespace Hero_Designer
{
    public partial class frmRecipeEdit : Form
    {

        bool NoUpdate;

        public frmRecipeEdit()
        {
            this.Load += new EventHandler(this.frmRecipeEdit_Load);
            this.NoUpdate = true;
            this.InitializeComponent();
            var componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipeEdit));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
        }

        void AddListItem(int Index)
        {
            if (!(Index > -1 & Index < DatabaseAPI.Database.Recipes.Length))
                return;
            var recipe = DatabaseAPI.Database.Recipes[Index];
            this.lvDPA.Items.Add(new ListViewItem(new string[4]
            {
                recipe.InternalName,
                recipe.EnhIdx <= -1 ? "None" : recipe.Enhancement + " (" + Conversions.ToString(recipe.EnhIdx) + ")",
                Enum.GetName(recipe.Rarity.GetType(),  recipe.Rarity),
                Conversions.ToString(recipe.Item.Length)
            }));
        }

        static void AssignNewRecipes()
        {
            for (int index = 0; index <= DatabaseAPI.Database.Recipes.Length - 1; ++index)
            {
                var recipe = DatabaseAPI.Database.Recipes[index];
                if (recipe.EnhIdx > -1 & recipe.EnhIdx <= DatabaseAPI.Database.Enhancements.Length - 1 && DatabaseAPI.Database.Enhancements[recipe.EnhIdx].RecipeIDX < 0)
                {
                    DatabaseAPI.Database.Enhancements[recipe.EnhIdx].RecipeIDX = index;
                    DatabaseAPI.Database.Enhancements[recipe.EnhIdx].RecipeName = recipe.InternalName;
                }
            }
        }

        void btnAdd_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
         {
             if (this.RecipeID() < 0)
                 return;
             var recipe = DatabaseAPI.Database.Recipes[this.RecipeID()];
             recipe.Item = recipe.Item.Append(new Recipe.RecipeEntry
             {
                 Level = 9
             }).ToArray();
             this.ShowRecipeInfo(this.RecipeID());
             this.UpdateListItem(this.RecipeID());
         });

        void btnCancel_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
         {
             DatabaseAPI.LoadRecipes();
             this.Close();
         });

        // this delete button is supposed to remove a specific level of recipe, not the whole recipe.
        void btnDel_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
         {
             var recipeid = this.RecipeID();
             if (recipeid < 0 || this.lstItems.SelectedIndex < 0 || this.lstItems.Items.Count < 2)
                 return;
             var recipe = DatabaseAPI.Database.Recipes[recipeid];
             var recipeItemId = this.lstItems.SelectedIndex;
             recipe.Item = recipe.Item.Where((ri, i) => i != recipeItemId).ToArray();
             this.ShowRecipeInfo(this.RecipeID());
         });

        void btnGuessCost_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
         {
             if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
                 return;
             DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level);
             this.udCraft.Value = new decimal(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost);
         });

        void btnI20_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() => this.IncrementX(19));

        void btnI25_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() => this.IncrementX(24));

        void btnI40_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() => this.IncrementX(39));

        void btnI50_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() => this.IncrementX(49));

        void btnImport_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (Interaction.MsgBox("Really erase all stored recipes and attempt import?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Careful...") != MsgBoxResult.Yes)
                return;
            char[] delimiter = new char[1] { '\r' };
            string[] strArray1 = Clipboard.GetDataObject().GetData("System.String", true).ToString().Split(delimiter);
            delimiter[0] = '\t';
            DatabaseAPI.Database.Recipes = new Recipe[0];
            int num1 = strArray1.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                string[] strArray2 = strArray1[index1].Split(delimiter);
                if (strArray2.Length > 7)
                {
                    string iName = strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal) <= 0 ? strArray2[0] : strArray2[0].Substring(0, strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal));
                    if (!char.IsLetterOrDigit(iName[0]))
                        iName = iName.Substring(1);
                    Recipe recipe1 = DatabaseAPI.GetRecipeByName(iName);
                    if (recipe1 == null)
                    {
                        recipe1 =
                            new Recipe()
                            {
                                InternalName = iName,
                                ExternalName = !(strArray2[14] == "") ? "" : strArray2[1],
                                Rarity = (Recipe.RecipeRarity)Math.Round(Conversion.Val(strArray2[15]) - 1.0)
                            };
                        DatabaseAPI.Database.Recipes = DatabaseAPI.Database.Recipes.Append(recipe1).ToArray();
                    }

                    int index2 = -1;
                    int num2 = recipe1.Item.Length - 1;
                    for (int index3 = 0; index3 <= num2; ++index3)
                    {
                        if ((double)recipe1.Item[index3].Level == Conversion.Val(strArray2[16]) - 1.0)
                            index2 = index3;
                    }
                    if (index2 < 0)
                    {
                        recipe1.Item = (Recipe.RecipeEntry[])Utils.CopyArray(recipe1.Item, new Recipe.RecipeEntry[recipe1.Item.Length + 1]);
                        recipe1.Item[recipe1.Item.Length - 1] = new Recipe.RecipeEntry();
                        index2 = recipe1.Item.Length - 1;
                    }
                    recipe1.Item[index2].Level = (int)Math.Round(Conversion.Val(strArray2[16]) - 1.0);
                    if (strArray2[0].IndexOf("Memorized") > -1)
                    {
                        recipe1.Item[index2].BuyCostM = (int)Math.Round(Conversion.Val(strArray2[19]) - 1.0);
                        recipe1.Item[index2].CraftCostM = (int)Math.Round(Conversion.Val(strArray2[17]) - 1.0);
                    }
                    else
                    {
                        recipe1.Item[index2].BuyCost = (int)Math.Round(Conversion.Val(strArray2[19]) - 1.0);
                        recipe1.Item[index2].CraftCost = (int)Math.Round(Conversion.Val(strArray2[17]) - 1.0);
                    }
                    int index4 = 0;
                    do
                    {
                        if (Conversion.Val(strArray2[4 + index4 * 2]) > 0.0)
                        {
                            recipe1.Item[index2].Count[index4] = (int)Math.Round(Conversion.Val(strArray2[4 + index4 * 2]));
                            recipe1.Item[index2].Salvage[index4] = strArray2[5 + index4 * 2];
                            recipe1.Item[index2].SalvageIdx[index4] = -1;
                        }
                        ++index4;
                    }
                    while (index4 <= 4);
                }
            }
            DatabaseAPI.AssignRecipeSalvageIDs();
            DatabaseAPI.GuessRecipes();
            DatabaseAPI.AssignRecipeIDs();
            this.FillList();
            Interaction.MsgBox("Done. Recipe-Enhancement links have been guessed.", MsgBoxStyle.Information, "Import");
        });

        void btnIncrement_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.RecipeID() < 0 || DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53)
                return;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[])Utils.CopyArray(DatabaseAPI.Database.Recipes[RecipeID()].Item, new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
            ++DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
            this.ShowRecipeInfo(this.RecipeID());
            this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
        });

        void btnOK_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            frmRecipeEdit.AssignNewRecipes();
            DatabaseAPI.AssignRecipeSalvageIDs();
            DatabaseAPI.AssignRecipeIDs();
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveRecipes(serializer);
            DatabaseAPI.SaveEnhancementDb(serializer);
            this.Close();
        });

        void btnRAdd_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            var recipe = new Recipe();
            DatabaseAPI.Database.Recipes = DatabaseAPI.Database.Recipes.Append(recipe).ToArray();
            //IDatabase database = DatabaseAPI.Database;
            //Recipe[] recipeArray = (Recipe[])Utils.CopyArray(database.Recipes, new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
            //database.Recipes = recipeArray;
            //DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
            this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
            this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
            this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
            this.cbEnh.Select();
            this.cbEnh.SelectAll();
        });

        void btnRDel_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
            {
                if (this.RecipeID() < 0)
                    return;
                int recipeId = this.RecipeID();
                Recipe[] recipeArray = new Recipe[DatabaseAPI.Database.Recipes.Length - 1];
                int recipeCount = -1;
                for (int recipeIdx = 0; recipeIdx <= DatabaseAPI.Database.Recipes.Length - 1; ++recipeIdx)
                {
                    if (recipeIdx != recipeId)
                    {
                        ++recipeCount;
                        recipeArray[recipeCount] = new Recipe(ref DatabaseAPI.Database.Recipes[recipeIdx]);
                    }
                }
                DatabaseAPI.Database.Recipes = new Recipe[recipeArray.Length - 1 + 1];
                for (int recipeIdx = 0; recipeIdx <= DatabaseAPI.Database.Recipes.Length - 1; ++recipeIdx)
                    DatabaseAPI.Database.Recipes[recipeIdx] = new Recipe(ref recipeArray[recipeIdx]);
                this.FillList();
                if (this.lvDPA.Items.Count > recipeId)
                    this.lvDPA.Items[recipeId].Selected = true;
                else if (this.lvDPA.Items.Count > recipeId - 1)
                    this.lvDPA.Items[recipeId - 1].Selected = true;
                else if (this.lvDPA.Items.Count > 0)
                    this.lvDPA.Items[0].Selected = true;
            });

        void btnRunSeq_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            int enhIdx = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].EnhIdx;
            for (int index = enhIdx + 1; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
            {
                if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO)
                {
                    DatabaseAPI.Database.Recipes = DatabaseAPI.Database.Recipes.Append(new Recipe
                    {
                        EnhIdx = index,
                        Enhancement = DatabaseAPI.Database.Enhancements[index].UID,
                        InternalName = DatabaseAPI.Database.Enhancements[index].UID
                    }
                    ).ToArray();
                    this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
                }
            }
            this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
            this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
            this.cbEnh.Select();
            this.cbEnh.SelectAll();
        });

        void Button1_Click(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            DatabaseAPI.GuessRecipes();
            DatabaseAPI.AssignRecipeIDs();
        });

        void cbEnh_SelectedIndexChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() <= -1 || this.cbEnh.SelectedIndex <= -1)
                return;
            var recipe = DatabaseAPI.Database.Recipes[this.RecipeID()];
            recipe.EnhIdx = this.cbEnh.SelectedIndex - 1;
            if (recipe.EnhIdx > -1)
            {
                recipe.Enhancement = this.cbEnh.Text;
                recipe.InternalName = this.cbEnh.Text;
                this.txtRecipeName.Text = this.cbEnh.Text;
                try
                {
                    this.lblEnh.Text = DatabaseAPI.Database.Enhancements[recipe.EnhIdx].LongName;
                }
                catch (Exception ex)
                {
                    this.lblEnh.Text = string.Empty;
                }
            }
            else
                recipe.Enhancement = "";
            this.UpdateListItem(this.RecipeID());
        });

        void cbRarity_SelectedIndexChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() <= -1 || this.cbRarity.SelectedIndex <= -1)
                return;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Rarity = (Recipe.RecipeRarity)this.cbRarity.SelectedIndex;
            this.UpdateListItem(this.RecipeID());
        });

        void cbSalX_SelectedIndexChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
                return;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[0] = this.cbSal0.SelectedIndex - 1;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[1] = this.cbSal1.SelectedIndex - 1;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[2] = this.cbSal2.SelectedIndex - 1;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[3] = this.cbSal3.SelectedIndex - 1;
            DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[4] = this.cbSal4.SelectedIndex - 1;
            if (this.cbSal0.SelectedIndex > 0 & decimal.Compare(this.udSal0.Value, new decimal(1)) < 0)
                this.udSal0.Value = new decimal(1);
            if (this.cbSal1.SelectedIndex > 0 & decimal.Compare(this.udSal1.Value, new decimal(1)) < 0)
                this.udSal1.Value = new decimal(1);
            if (this.cbSal2.SelectedIndex > 0 & decimal.Compare(this.udSal2.Value, new decimal(1)) < 0)
                this.udSal2.Value = new decimal(1);
            if (this.cbSal3.SelectedIndex > 0 & decimal.Compare(this.udSal3.Value, new decimal(1)) < 0)
                this.udSal3.Value = new decimal(1);
            if (this.cbSal4.SelectedIndex > 0 & decimal.Compare(this.udSal4.Value, new decimal(1)) < 0)
                this.udSal4.Value = new decimal(1);
            this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 0);
            this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 1);
            this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 2);
            this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 3);
            this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 4);
        });

        protected void ClearEntryInfo()
        {
            this.udLevel.Value = new decimal(1);
            this.udLevel.Enabled = false;
            this.udBuy.Value = new decimal(1);
            this.udBuy.Enabled = false;
            this.udBuyM.Value = new decimal(1);
            this.udBuyM.Enabled = false;
            this.udCraft.Value = new decimal(1);
            this.udCraft.Enabled = false;
            this.udCraftM.Value = new decimal(1);
            this.udCraftM.Enabled = false;
            this.cbSal0.SelectedIndex = -1;
            this.cbSal0.Enabled = false;
            this.udSal0.Value = new decimal(0);
            this.udSal0.Enabled = false;
            this.cbSal1.SelectedIndex = -1;
            this.cbSal1.Enabled = false;
            this.udSal1.Value = new decimal(0);
            this.udSal1.Enabled = false;
            this.cbSal2.SelectedIndex = -1;
            this.cbSal2.Enabled = false;
            this.udSal2.Value = new decimal(0);
            this.udSal2.Enabled = false;
            this.cbSal3.SelectedIndex = -1;
            this.cbSal3.Enabled = false;
            this.udSal3.Value = new decimal(0);
            this.udSal3.Enabled = false;
            this.cbSal4.SelectedIndex = -1;
            this.cbSal4.Enabled = false;
            this.udSal4.Value = new decimal(0);
            this.udSal4.Enabled = false;
        }

        protected void ClearInfo()
        {
            this.txtRecipeName.Text = "";
            this.cbEnh.SelectedIndex = -1;
            this.cbRarity.SelectedIndex = -1;
            this.lstItems.Items.Clear();
            this.lblEnh.Text = "";
            this.txtExtern.Text = "";
            this.ClearEntryInfo();
        }

        protected int EntryID() => this.RecipeID() <= -1 ? -1 : this.lstItems.SelectedIndex;

        protected void FillList()
        {
            this.lvDPA.BeginUpdate();
            this.lvDPA.Items.Clear();
            int num = DatabaseAPI.Database.Recipes.Length - 1;
            for (int Index = 0; Index <= num; ++Index)
                this.AddListItem(Index);
            this.lvDPA.EndUpdate();
            if (this.lvDPA.SelectedItems.Count <= 0)
                return;
            this.lvDPA.Items[0].Selected = true;
        }

        void frmRecipeEdit_Load(object sender, EventArgs e)
        {
            Recipe.RecipeRarity recipeRarity = Recipe.RecipeRarity.Common;
            this.cbRarity.BeginUpdate();
            this.cbRarity.Items.Clear();
            this.cbRarity.Items.AddRange((object[])Enum.GetNames(recipeRarity.GetType()));
            this.cbRarity.EndUpdate();
            this.cbEnh.BeginUpdate();
            this.cbEnh.Items.Clear();
            this.cbEnh.Items.Add("None");
            int num1 = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if (DatabaseAPI.Database.Enhancements[index].UID != "")
                    this.cbEnh.Items.Add(DatabaseAPI.Database.Enhancements[index].UID);
                else
                    this.cbEnh.Items.Add(("X - " + DatabaseAPI.Database.Enhancements[index].Name));
            }
            this.cbEnh.EndUpdate();
            this.cbSal0.BeginUpdate();
            this.cbSal1.BeginUpdate();
            this.cbSal2.BeginUpdate();
            this.cbSal3.BeginUpdate();
            this.cbSal4.BeginUpdate();
            this.cbSal0.Items.Clear();
            this.cbSal1.Items.Clear();
            this.cbSal2.Items.Clear();
            this.cbSal3.Items.Clear();
            this.cbSal4.Items.Clear();
            this.cbSal0.Items.Add("None");
            this.cbSal1.Items.Add("None");
            this.cbSal2.Items.Add("None");
            this.cbSal3.Items.Add("None");
            this.cbSal4.Items.Add("None");
            int num2 = DatabaseAPI.Database.Salvage.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                var salvageName = DatabaseAPI.Database.Salvage[index].ExternalName;
                this.cbSal0.Items.Add(salvageName);
                this.cbSal1.Items.Add(salvageName);
                this.cbSal2.Items.Add(salvageName);
                this.cbSal3.Items.Add(salvageName);
                this.cbSal4.Items.Add(salvageName);
            }
            this.cbSal0.EndUpdate();
            this.cbSal1.EndUpdate();
            this.cbSal2.EndUpdate();
            this.cbSal3.EndUpdate();
            this.cbSal4.EndUpdate();
            this.NoUpdate = false;
            this.FillList();
        }

        protected int GetCostByLevel(int iLevelZB)
        {
            int[] numArray = new int[53]
            {
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 3600, 4380, 5160,
                5940, 6720, 7500, 12900,
                18300, 23700, 29100, 34500,
                35080, 35660, 36240, 36820,
                37400, 38660, 39920, 41180,
                42440, 43700, 48200, 52700,
                57200, 61700, 66200, 73920,
                81640, 89360, 97080, 104800,
                121260, 137720, 154180, 170640,
                187100, 198720, 210340, 221960,
                233580, 490400, 513640, 536880,
                560120
            };
            return iLevelZB >= 0 ? (iLevelZB <= numArray.Length - 1 ? numArray[iLevelZB] : 0) : 0;
        }

        void IncrementX(int nMax)
        {
            if (this.RecipeID() < 0 || DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53)
                return;
            int num = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level + 1;
            if (num < nMax)
            {
                for (int index = num; index <= nMax; ++index)
                {
                    DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[])Utils.CopyArray(DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array)new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
                    DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
                    DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = index;
                    DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
                }
                this.ShowRecipeInfo(this.RecipeID());
                this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
            }
        }

        void lstItems_SelectedIndexChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.lvDPA.SelectedIndices.Count > 0)
                this.ShowEntryInfo(this.lvDPA.SelectedIndices[0], this.lstItems.SelectedIndex);
            else
                this.ClearEntryInfo();
        });

        void lvDPA_SelectedIndexChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.lvDPA.SelectedIndices.Count > 0)
                this.ShowRecipeInfo(this.lvDPA.SelectedIndices[0]);
            else
                this.ClearInfo();
        });

        int MinMax(int iValue, NumericUpDown iControl)
        {
            if (decimal.Compare(new decimal(iValue), iControl.Minimum) < 0)
                iValue = Convert.ToInt32(iControl.Minimum);
            if (decimal.Compare(new decimal(iValue), iControl.Maximum) > 0)
                iValue = Convert.ToInt32(iControl.Maximum);
            return iValue;
        }

        int RecipeID() => this.lvDPA.SelectedIndices.Count <= 0 ? -1 : this.lvDPA.SelectedIndices[0];

        void SetSalvageStringFromIDX(int iRecipe, int iItem, int iIndex)
        {
            if (DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].SalvageIdx[iIndex] > -1)
                DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[iIndex]].InternalName;
            else
                DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = "";
        }

        void ShowEntryInfo(int rIDX, int iIDX)
        {
            if (rIDX < 0 | rIDX > DatabaseAPI.Database.Recipes.Length - 1)
                this.ClearEntryInfo();
            else if (iIDX < 0 | iIDX > DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1)
            {
                this.ClearEntryInfo();
            }
            else
            {
                this.NoUpdate = true;
                Recipe.RecipeEntry recipeEntry = DatabaseAPI.Database.Recipes[rIDX].Item[iIDX];
                this.udLevel.Value = new decimal(recipeEntry.Level + 1);
                this.udLevel.Enabled = true;
                this.udBuy.Value = new decimal(recipeEntry.BuyCost);
                this.udBuy.Enabled = true;
                this.udBuyM.Value = new decimal(recipeEntry.BuyCostM);
                this.udBuyM.Enabled = true;
                this.udCraft.Value = new decimal(recipeEntry.CraftCost);
                this.udCraft.Enabled = true;
                this.udCraftM.Value = new decimal(recipeEntry.CraftCostM);
                this.udCraftM.Enabled = true;
                this.cbSal0.SelectedIndex = recipeEntry.SalvageIdx[0] + 1;
                this.cbSal0.Enabled = true;
                this.udSal0.Value = new decimal(recipeEntry.Count[0]);
                this.udSal0.Enabled = true;
                this.cbSal1.SelectedIndex = recipeEntry.SalvageIdx[1] + 1;
                this.cbSal1.Enabled = true;
                this.udSal1.Value = new decimal(recipeEntry.Count[1]);
                this.udSal1.Enabled = true;
                this.cbSal2.SelectedIndex = recipeEntry.SalvageIdx[2] + 1;
                this.cbSal2.Enabled = true;
                this.udSal2.Value = new decimal(recipeEntry.Count[2]);
                this.udSal2.Enabled = true;
                this.cbSal3.SelectedIndex = recipeEntry.SalvageIdx[3] + 1;
                this.cbSal3.Enabled = true;
                this.udSal3.Value = new decimal(recipeEntry.Count[3]);
                this.udSal3.Enabled = true;
                this.cbSal4.SelectedIndex = recipeEntry.SalvageIdx[4] + 1;
                this.cbSal4.Enabled = true;
                this.udSal4.Value = new decimal(recipeEntry.Count[4]);
                this.udSal4.Enabled = true;
                this.NoUpdate = false;
            }
        }

        void ShowRecipeInfo(int Index)
        {
            if (Index < 0 | Index > DatabaseAPI.Database.Recipes.Length - 1)
            {
                this.ClearInfo();
            }
            else
            {
                this.NoUpdate = true;
                this.txtRecipeName.Text = DatabaseAPI.Database.Recipes[Index].InternalName;
                this.cbEnh.SelectedIndex = DatabaseAPI.Database.Recipes[Index].EnhIdx + 1;
                try
                {
                    this.lblEnh.Text = DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[Index].EnhIdx].LongName;
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    this.lblEnh.Text = string.Empty;
                    ProjectData.ClearProjectError();
                }
                this.cbRarity.SelectedIndex = (int)DatabaseAPI.Database.Recipes[Index].Rarity;
                this.txtExtern.Text = DatabaseAPI.Database.Recipes[Index].ExternalName;
                this.lstItems.Items.Clear();
                int num = DatabaseAPI.Database.Recipes[Index].Item.Length - 1;
                for (int index = 0; index <= num; ++index)
                    this.lstItems.Items.Add(("Level: " + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item[index].Level + 1)));
                if (this.lstItems.Items.Count > 0)
                    this.lstItems.SelectedIndex = 0;
                this.NoUpdate = false;
            }
        }

        void txtExtern_TextChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() <= -1)
                return;
            DatabaseAPI.Database.Recipes[this.RecipeID()].ExternalName = this.txtExtern.Text;
        });

        void txtRecipeName_TextChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() <= -1)
                return;
            DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.txtRecipeName.Text;
            this.UpdateListItem(this.RecipeID());
        });

        void udCostX_Leave(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
                return;
            var recipeItem = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()];
            recipeItem.Level = this.MinMax((int)Math.Round(Conversion.Val(this.udLevel.Text.Replace(",", "").Replace(".", ""))), this.udLevel) - 1;
            recipeItem.BuyCost = this.MinMax((int)Math.Round(Conversion.Val(this.udBuy.Text.Replace(",", "").Replace(".", ""))), this.udBuy);
            recipeItem.BuyCostM = this.MinMax((int)Math.Round(Conversion.Val(this.udBuyM.Text.Replace(",", "").Replace(".", ""))), this.udBuyM);
            recipeItem.CraftCost = this.MinMax((int)Math.Round(Conversion.Val(this.udCraft.Text.Replace(",", "").Replace(".", ""))), this.udCraft);
            recipeItem.CraftCostM = this.MinMax((int)Math.Round(Conversion.Val(this.udCraftM.Text.Replace(",", "").Replace(".", ""))), this.udCraftM);
        });

        void udCostX_ValueChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
                return;
            var recipeItem = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()];
            recipeItem.Level = Convert.ToInt32(decimal.Subtract(this.udLevel.Value, new decimal(1)));
            recipeItem.BuyCost = Convert.ToInt32(this.udBuy.Value);
            recipeItem.BuyCostM = Convert.ToInt32(this.udBuyM.Value);
            recipeItem.CraftCost = Convert.ToInt32(this.udCraft.Value);
            recipeItem.CraftCostM = Convert.ToInt32(this.udCraftM.Value);
        });

        void udSalX_Leave(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            var recipeItem = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()];
            recipeItem.Count[0] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal0.Text)), this.udSal0);
            recipeItem.Count[1] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal1.Text)), this.udSal1);
            recipeItem.Count[2] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal2.Text)), this.udSal2);
            recipeItem.Count[3] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal3.Text)), this.udSal3);
            recipeItem.Count[4] = this.MinMax((int)Math.Round(Conversion.Val(this.udSal4.Text)), this.udSal4);
        });

        void udSalX_ValueChanged(object sender, EventArgs e) => this.EventHandlerWithCatch(() =>
        {
            if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
                return;
            var recipeItem = DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()];
            recipeItem.Count[0] = Convert.ToInt32(this.udSal0.Value);
            recipeItem.Count[1] = Convert.ToInt32(this.udSal1.Value);
            recipeItem.Count[2] = Convert.ToInt32(this.udSal2.Value);
            recipeItem.Count[3] = Convert.ToInt32(this.udSal3.Value);
            recipeItem.Count[4] = Convert.ToInt32(this.udSal4.Value);
        });

        protected void UpdateListItem(int index)
        {
            if (!(index > -1 & index < DatabaseAPI.Database.Recipes.Length))
                return;
            this.lvDPA.Items[index].SubItems[0].Text = DatabaseAPI.Database.Recipes[index].InternalName;
            this.lvDPA.Items[index].SubItems[1].Text = DatabaseAPI.Database.Recipes[index].EnhIdx <= -1 ? "None" : DatabaseAPI.Database.Recipes[index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index].EnhIdx) + ")";
            this.lvDPA.Items[index].SubItems[2].Text = Enum.GetName(DatabaseAPI.Database.Recipes[index].Rarity.GetType(), DatabaseAPI.Database.Recipes[index].Rarity);
            this.lvDPA.Items[index].SubItems[3].Text = Conversions.ToString(DatabaseAPI.Database.Recipes[index].Item.Length);
        }
    }
}