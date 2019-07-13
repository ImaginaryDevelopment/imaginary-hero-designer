
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
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
    public partial class frmRecipeViewer : Form
    {

        midsControls.ImageButton ibClipboard;
        midsControls.ImageButton ibClose;
        midsControls.ImageButton ibMiniList;
        midsControls.ImageButton ibTopmost;
        midsControls.ctlPopUp RecipeInfo;
        ExtendedBitmap bxRecipe;

        bool Loading;
        frmMain myParent;
        int nonRecipeCount;

        public frmRecipeViewer(frmMain iParent)
        {
            this.FormClosed += new FormClosedEventHandler(this.frmRecipeViewer_FormClosed);
            this.Load += new EventHandler(this.frmRecipeViewer_Load);
            this.Loading = true;
            this.InitializeComponent();
            this.Name = nameof(frmRecipeViewer);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipeViewer));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.RecipeInfo.MouseWheel += new MouseEventHandler(this.RecipeInfo_MouseWheel);
            this.RecipeInfo.MouseEnter += new EventHandler(this.RecipeInfo_MouseEnter);
            this.lvPower.MouseEnter += new EventHandler(this.lvPower_MouseEnter);
            this.lvPower.ItemChecked += new ItemCheckedEventHandler(this.lvPower_ItemChecked);
            this.lvDPA.SelectedIndexChanged += new EventHandler(this.lvDPA_SelectedIndexChanged);
            this.lvDPA.MouseEnter += new EventHandler(this.lvDPA_MouseEnter);
            this.VScrollBar1.Scroll += VScrollBar1_Scroll;
            this.chkRecipe.CheckedChanged += chkRecipe_CheckedChanged;
            this.chkSortByLevel.CheckedChanged += chkSortByLevel_CheckedChanged;
            this.ibClipboard.ButtonClicked += ibClipboard_ButtonClicked;
            this.ibClose.ButtonClicked += ibClose_ButtonClicked;
            this.ibMiniList.ButtonClicked += ibMiniList_ButtonClicked;
            this.ibTopmost.ButtonClicked += ibTopmost_ButtonClicked;
            this.myParent = iParent;
            this.bxRecipe = new ExtendedBitmap(I9Gfx.GetRecipeName());
        }

        void AddToImageList(int eIDX)

        {
            Size imageSize = this.ilSets.ImageSize;
            int width = imageSize.Width;
            imageSize = this.ilSets.ImageSize;
            int height = imageSize.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width, height);
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[eIDX];
            if (enhancement.ImageIdx > -1)
            {
                extendedBitmap.Graphics.Clear(Color.White);
                Graphics graphics = extendedBitmap.Graphics;
                I9Gfx.DrawEnhancement(ref graphics, enhancement.ImageIdx, Origin.Grade.IO);
                this.ilSets.Images.Add((Image)extendedBitmap.Bitmap);
            }
            else
                this.ilSets.Images.Add((Image)new Bitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height));
        }

        PopUp.PopupData BuildList(bool Mini)

        {
            int iIndent = 1;
            PopUp.PopupData popupData = new PopUp.PopupData();
            frmRecipeViewer.CountingList[] tl = new frmRecipeViewer.CountingList[0];
            if (this.lvDPA.SelectedIndices.Count >= 1)
            {
                if (this.lvDPA.SelectedIndices[0] == 0)
                {
                    int[] numArray1 = new int[DatabaseAPI.Database.Salvage.Length - 1 + 1];
                    int num1 = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    this.DrawIcon(-1);
                    int[][] numArray2 = new int[DatabaseAPI.Database.Recipes.Length - 1 + 1][];
                    int num5 = numArray2.Length - 1;
                    for (int index = 0; index <= num5; ++index)
                    {
                        int[] numArray3 = new int[DatabaseAPI.Database.Recipes[index].Item.Length - 1 + 1];
                        numArray2[index] = numArray3;
                    }
                    int num6 = this.lvDPA.Items.Count - 1;
                    for (int index1 = 1; index1 <= num6; ++index1)
                    {
                        int rIDX = DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.Items[index1].Tag)].RecipeIDX;
                        if (this.lvDPA.Items[index1].SubItems[1].Text == "*")
                        {
                            rIDX = -1;
                            frmRecipeViewer.putInList(ref tl, this.lvDPA.Items[index1].Text);
                        }
                        if (rIDX > -1)
                        {
                            int iLevel = Conversions.ToInteger(this.lvDPA.Items[index1].SubItems[1].Text) - 1;
                            int itemId = frmRecipeViewer.FindItemID(rIDX, iLevel);
                            if (itemId > -1)
                            {
                                if (this.chkRecipe.Checked)
                                    ++numArray2[rIDX][itemId];
                                Recipe.RecipeEntry recipeEntry = DatabaseAPI.Database.Recipes[rIDX].Item[itemId];
                                int num7 = recipeEntry.SalvageIdx.Length - 1;
                                for (int index2 = 0; index2 <= num7; ++index2)
                                {
                                    if (recipeEntry.SalvageIdx[index2] > -1 & recipeEntry.Count[index2] > 0)
                                    {
                                        if (!(index2 != 0 & recipeEntry.SalvageIdx[index2] == recipeEntry.SalvageIdx[0]))
                                        {
                                            numArray1[recipeEntry.SalvageIdx[index2]] += recipeEntry.Count[index2];
                                            num4 += recipeEntry.Count[index2];
                                        }
                                        else
                                            break;
                                    }
                                }
                                num1 += recipeEntry.CraftCost;
                                if (recipeEntry.CraftCostM > 0)
                                    num3 += recipeEntry.CraftCostM;
                                else if (DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.Items[index1].Tag)].TypeID == Enums.eType.SetO)
                                    num3 += recipeEntry.CraftCost;
                                num2 += recipeEntry.BuyCost;
                            }
                        }
                    }
                    int index3 = popupData.Add(null);
                    if (Mini)
                        iIndent = 0;
                    this.lblHeader.Text = "Shopping List";
                    if (this.lvPower.CheckedIndices.Count == 1)
                    {
                        if (!this.lvPower.Items[0].Checked)
                            popupData.Sections[index3].Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[Conversions.ToInteger(this.lvPower.CheckedItems[0].Tag)].NIDPower].DisplayName, PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                        else
                            popupData.Sections[index3].Add("All Powers", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    }
                    else
                        popupData.Sections[index3].Add(Conversions.ToString(this.lvPower.CheckedIndices.Count) + " Powers", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    if (!this.chkRecipe.Checked)
                        popupData.Sections[index3].Add(Conversions.ToString(this.lvDPA.Items.Count - this.nonRecipeCount) + " Recipes:", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    if (Mini)
                    {
                        string str = "Buy:";
                        if (num2 > 0)
                            popupData.Sections[index3].Add(str + " " + Strings.Format(num2, "###,###,##0"), PopUp.Colors.Invention, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                    }
                    else
                    {
                        string iText = "Buy Cost:";
                        if (num2 > 0)
                            popupData.Sections[index3].Add(iText, PopUp.Colors.Invention, Strings.Format(num2, "###,###,##0"), PopUp.Colors.Invention, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                    }
                    if (Mini)
                    {
                        string str = "Craft:";
                        if (num1 > 0)
                            popupData.Sections[index3].Add(str + " " + Strings.Format(num1, "###,###,##0"), PopUp.Colors.Invention, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                    }
                    else
                    {
                        string iText = "Craft Cost:";
                        if (num1 > 0)
                            popupData.Sections[index3].Add(iText, PopUp.Colors.Invention, Strings.Format(num1, "###,###,##0"), PopUp.Colors.Invention, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                    }
                    if (Mini)
                    {
                        string str = "Craft (Mem'd):";
                        if (num3 > 0 & num3 != num1)
                            popupData.Sections[index3].Add(str + " " + Strings.Format(num3, "###,###,##0"), PopUp.Colors.Effect, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                    }
                    else
                    {
                        string iText = "Craft Cost (Memorized Common):";
                        if (num3 > 0 & num3 != num1)
                            popupData.Sections[index3].Add(iText, PopUp.Colors.Effect, Strings.Format(num3, "###,###,##0"), PopUp.Colors.Effect, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                    }
                    if (this.chkRecipe.Checked)
                    {
                        this.RecipeInfo.ColumnPosition = 0.75f;
                        int index1 = popupData.Add(null);
                        popupData.Sections[index1].Add(Conversions.ToString(this.lvDPA.Items.Count - this.nonRecipeCount) + " Recipes:", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                        int num7 = numArray2.Length - 1;
                        for (int index2 = 0; index2 <= num7; ++index2)
                        {
                            int num8 = numArray2[index2].Length - 1;
                            for (int index4 = 0; index4 <= num8; ++index4)
                            {
                                if (numArray2[index2][index4] > 0)
                                {
                                    Color color;
                                    switch (DatabaseAPI.Database.Recipes[index2].Rarity)
                                    {
                                        case Recipe.RecipeRarity.Uncommon:
                                            color = PopUp.Colors.Uncommon;
                                            break;
                                        case Recipe.RecipeRarity.Rare:
                                            color = PopUp.Colors.Rare;
                                            break;
                                        case Recipe.RecipeRarity.UltraRare:
                                            color = PopUp.Colors.UltraRare;
                                            break;
                                        default:
                                            color = PopUp.Colors.Text;
                                            break;
                                    }
                                    if (Mini)
                                        popupData.Sections[index1].Add(" " + Conversions.ToString(numArray2[index2][index4]) + " x", color, DatabaseAPI.GetEnhancementNameShortWSet(DatabaseAPI.Database.Recipes[index2].EnhIdx) + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index2].Item[index4].Level + 1) + ")", color, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                                    else
                                        popupData.Sections[index1].Add(DatabaseAPI.GetEnhancementNameShortWSet(DatabaseAPI.Database.Recipes[index2].EnhIdx) + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index2].Item[index4].Level + 1) + ")", color, Conversions.ToString(numArray2[index2][index4]), color, 0.9f, System.Drawing.FontStyle.Bold, iIndent);
                                }
                            }
                        }
                        popupData.Sections[index1].Content = frmRecipeViewer.sortPopupStrings(Mini, 2, popupData.Sections[index1].Content);
                    }
                    else
                        this.RecipeInfo.ColumnPosition = 0.5f;
                    if (Mini)
                    {
                        popupData.ColPos = 0.15f;
                        popupData.ColRight = false;
                    }
                    int index5 = popupData.Add(null);
                    string iText1 = !Mini ? Conversions.ToString(num4) + " Salvage Items:" : Conversions.ToString(num4) + " Items:";
                    popupData.Sections[index5].Add(iText1, PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    int num9 = numArray1.Length - 1;
                    for (int index1 = 0; index1 <= num9; ++index1)
                    {
                        if (numArray1[index1] > 0)
                        {
                            Color color = System.Drawing.Color.White;
                            switch (DatabaseAPI.Database.Salvage[index1].Rarity)
                            {
                                case Recipe.RecipeRarity.Common:
                                    color = PopUp.Colors.Common;
                                    break;
                                case Recipe.RecipeRarity.Uncommon:
                                    color = PopUp.Colors.Uncommon;
                                    break;
                                case Recipe.RecipeRarity.Rare:
                                    color = PopUp.Colors.Rare;
                                    break;
                            }
                            if (Mini)
                                popupData.Sections[index5].Add(" " + Conversions.ToString(numArray1[index1]) + " x", color, DatabaseAPI.Database.Salvage[index1].ExternalName, color, 0.9f, System.Drawing.FontStyle.Bold, 0);
                            else
                                popupData.Sections[index5].Add(DatabaseAPI.Database.Salvage[index1].ExternalName, color, Conversions.ToString(numArray1[index1]), color, 0.9f, System.Drawing.FontStyle.Bold, 1);
                        }
                    }
                    popupData.Sections[index5].Content = frmRecipeViewer.sortPopupStrings(Mini, 1, popupData.Sections[index5].Content);
                    if (this.nonRecipeCount != 1)
                    {
                        int index1 = popupData.Add(null);
                        string iText2 = !Mini ? Conversions.ToString(this.nonRecipeCount - 1) + " Non-Crafted Enhancements:" : Conversions.ToString(this.nonRecipeCount - 1) + " Enhs:";
                        popupData.Sections[index1].Add(iText2, PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                        int num7 = tl.Length - 1;
                        for (int index2 = 0; index2 <= num7; ++index2)
                        {
                            Color common = PopUp.Colors.Common;
                            if (Mini)
                                popupData.Sections[index1].Add(" " + Conversions.ToString(tl[index2].Count) + " x", common, tl[index2].Text, common, 0.9f, System.Drawing.FontStyle.Bold, 0);
                            else
                                popupData.Sections[index1].Add(tl[index2].Text, common, Conversions.ToString(tl[index2].Count), common, 0.9f, System.Drawing.FontStyle.Bold, 1);
                        }
                        popupData.Sections[index1].Content = frmRecipeViewer.sortPopupStrings(Mini, 1, popupData.Sections[index1].Content);
                    }
                    return popupData;
                }
                this.lblHeader.Text = DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.SelectedItems[0].Tag)].LongName + " (" + this.lvDPA.SelectedItems[0].SubItems[1].Text + ")";
                int rIdx = DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.SelectedItems[0].Tag)].RecipeIDX;
                if (this.lvDPA.SelectedItems[0].SubItems[1].Text == "*")
                    rIdx = -1;
                this.DrawIcon(Conversions.ToInteger(this.lvDPA.SelectedItems[0].Tag));
                if (rIdx > -1)
                {
                    int index1 = popupData.Add(null);
                    popupData.Sections[index1] = Character.PopRecipeInfo(rIdx, Conversions.ToInteger(this.lvDPA.SelectedItems[0].SubItems[1].Text) - 1);
                    if (popupData.Sections[index1].Content != null && popupData.Sections[index1].Content.Length > 0)
                    {
                        PopUp.StringValue[] content = popupData.Sections[index1].Content;
                        int index2 = 0;
                        content[index2].Text = content[index2].Text + " (" + this.lvDPA.SelectedItems[0].SubItems[1].Text + ")";
                        return popupData;
                    }
                    popupData.Sections[index1].Content[0].Text = "";
                }
            }
            return popupData;
        }

        void ChangedRecipeInfoElements()

        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round((double)this.RecipeInfo.lHeight * ((double)this.VScrollBar1.LargeChange / (double)this.Panel1.Height));
        }

        void chkRecipe_CheckedChanged(object sender, EventArgs e)

        {
            this.lvDPA_SelectedIndexChanged(this, new EventArgs());
            MidsContext.Config.ShoppingListIncludesRecipes = this.chkRecipe.Checked;
        }

        void chkSortByLevel_CheckedChanged(object sender, EventArgs e)

        {
            this.UpdatePowerList();
        }

        static int colorRarityCompare(Color t1, Color t2)

        {
            int num;
            if (t1.Equals(t2))
            {
                num = 0;
            }
            else
            {
                if (t1.Equals(PopUp.Colors.Common))
                {
                    if (t2.Equals(PopUp.Colors.Uncommon) | t2.Equals(PopUp.Colors.Rare) | t2.Equals(PopUp.Colors.UltraRare))
                        return -1;
                }
                else if (t1.Equals(PopUp.Colors.Uncommon))
                {
                    if (t2.Equals(PopUp.Colors.Common))
                        return 1;
                    if (t2.Equals(PopUp.Colors.Rare) | t2.Equals(PopUp.Colors.UltraRare))
                        return -1;
                }
                else if (t1.Equals(PopUp.Colors.Rare))
                {
                    if (t2.Equals(PopUp.Colors.Common) | t2.Equals(PopUp.Colors.Uncommon))
                        return 1;
                    if (t2.Equals(PopUp.Colors.UltraRare))
                        return -1;
                }
                else if (t1.Equals(PopUp.Colors.UltraRare) && t2.Equals(PopUp.Colors.Common) | t2.Equals(PopUp.Colors.Uncommon) | t2.Equals(PopUp.Colors.Rare))
                    return 1;
                num = -1;
            }
            return num;
        }

        static int colorRarityCompareB(Color t1, Color t2)

        {
            int num;
            if (t1.Equals(t2))
            {
                num = 0;
            }
            else
            {
                if (t1.Equals(PopUp.Colors.Common))
                {
                    if (t2.Equals(PopUp.Colors.Uncommon) | t2.Equals(PopUp.Colors.Rare) | t2.Equals(PopUp.Colors.UltraRare))
                        return -1;
                }
                else if (t1.Equals(PopUp.Colors.Uncommon) | t1.Equals(PopUp.Colors.Rare))
                {
                    if (t2.Equals(PopUp.Colors.Common))
                        return 1;
                    if (t2.Equals(PopUp.Colors.Rare))
                        return 0;
                    if (t2.Equals(PopUp.Colors.UltraRare))
                        return -1;
                }
                else if (t1.Equals(PopUp.Colors.UltraRare) && t2.Equals(PopUp.Colors.Common) | t2.Equals(PopUp.Colors.Uncommon) | t2.Equals(PopUp.Colors.Rare))
                    return 1;
                num = -1;
            }
            return num;
        }

        void DrawIcon(int Index)

        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.bxRecipe.Size);
            extendedBitmap.Graphics.Clear(Color.Black);
            extendedBitmap.Graphics.DrawImageUnscaled((Image)this.bxRecipe.Bitmap, 0, 0);
            if (Index > -1)
                extendedBitmap.Graphics.DrawImageUnscaled((Image)I9Gfx.Enhancements[Index], 0, 0);
            this.pbRecipe.Image = (Image)new Bitmap((Image)extendedBitmap.Bitmap);
        }

        void FillEnhList()

        {
            if (this.lvPower.CheckedIndices.Count < 1)
            {
                this.lvDPA.Items.Clear();
            }
            else
            {
                this.lvDPA.BeginUpdate();
                this.lvDPA.Items.Clear();
                string[] items = new string[3];
                bool flag = false;
                int num1 = this.lvPower.CheckedIndices.Count - 1;
                if (this.lvPower.Items[0].Checked)
                {
                    flag = true;
                    num1 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                }
                this.ilSets.Images.Clear();
                this.nonRecipeCount = 1;
                this.lvDPA.Items.Add(" - All Recipes - ");
                int num2 = num1;
                for (int index1 = 0; index1 <= num2; ++index1)
                {
                    int hIDX = flag ? index1 : Conversions.ToInteger(this.lvPower.CheckedItems[index1].Tag);
                    if (MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPowerset > -1 & this.HasIOs(hIDX))
                    {
                        int num3 = MidsContext.Character.CurrentBuild.Powers[hIDX].Slots.Length - 1;
                        for (int index2 = 0; index2 <= num3; ++index2)
                        {
                            if (MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh > -1)
                            {
                                if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                {
                                    items[0] = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].nIDSet].DisplayName + ": ";
                                    string[] strArray1 = items;
                                    int num4 = 0;
                                    string[] strArray2;
                                    IntPtr index3;
                                    (strArray2 = strArray1)[(int)(index3 = (IntPtr)num4)] = strArray2[(int)index3] + DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].Name;
                                    items[1] = Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.IOLevel + 1);
                                }
                                else if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].TypeID == Enums.eType.InventO)
                                {
                                    items[0] = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].Name + " (Common)";
                                    items[1] = Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.IOLevel + 1);
                                }
                                else
                                {
                                    items[0] = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].Name;
                                    ++this.nonRecipeCount;
                                    items[1] = "*";
                                }
                                this.AddToImageList(MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh);
                                items[2] = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower].DisplayName;
                                this.lvDPA.Items.Add(new ListViewItem(items, this.ilSets.Images.Count - 1));
                                this.lvDPA.Items[this.lvDPA.Items.Count - 1].Tag = MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh;
                            }
                        }
                    }
                }
                this.lvDPA.EndUpdate();
                if (this.lvDPA.Items.Count > 0)
                    this.lvDPA.Items[0].Selected = true;
            }
        }

        void FillPowerList()

        {
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            this.lvPower.Sorting = SortOrder.None;
            this.lvPower.Items.Add(" - All Powers - ");
            this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = -1;
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int hIDX = 0; hIDX <= num; ++hIDX)
            {
                if (MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower > -1 & this.HasIOs(hIDX))
                {
                    string text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower].DisplayName;
                    if (this.chkSortByLevel.Checked)
                        text = Strings.Format((MidsContext.Character.CurrentBuild.Powers[hIDX].Level + 1), "00") + " - " + text;
                    this.lvPower.Items.Add(text);
                    this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = hIDX;
                }
            }
            this.lvPower.Sorting = SortOrder.Ascending;
            this.lvPower.Sort();
            if (this.lvPower.Items.Count > 0)
            {
                this.lvPower.Items[0].Selected = true;
                this.lvPower.Items[0].Checked = true;
            }
            this.lvPower.EndUpdate();
        }

        static int FindItemID(int rIDX, int iLevel)

        {
            int num1 = -1;
            int num2 = 52;
            int num3 = 0;
            int num4 = DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1;
            for (int index = 0; index <= num4; ++index)
            {
                if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level > num3)
                    num3 = DatabaseAPI.Database.Recipes[rIDX].Item[index].Level;
                if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level < num2)
                    num2 = DatabaseAPI.Database.Recipes[rIDX].Item[index].Level;
                if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level == iLevel)
                {
                    num1 = index;
                    break;
                }
            }
            if (num1 < 0)
            {
                iLevel = Enhancement.GranularLevelZb(iLevel, 0, 49, 5);
                int num5 = DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1;
                for (int index = 0; index <= num5; ++index)
                {
                    if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level == iLevel)
                    {
                        num1 = index;
                        break;
                    }
                }
            }
            return num1 >= 0 ? num1 : -1;
        }

        void frmRecipeViewer_FormClosed(object sender, FormClosedEventArgs e)

        {
            this.StoreLocation();
            this.myParent.FloatRecipe(false);
        }

        void frmRecipeViewer_Load(object sender, EventArgs e)

        {
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
            this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.RecipeInfo.SetPopup(new PopUp.PopupData());
            this.ChangedRecipeInfoElements();
            this.chkRecipe.Checked = MidsContext.Config.ShoppingListIncludesRecipes;
            this.Loading = false;
        }

        bool HasIOs(int hIDX)

        {
            if (hIDX >= 0)
            {
                int num = MidsContext.Character.CurrentBuild.Powers[hIDX].Slots.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh > -1)
                        return true;
                }
            }
            return false;
        }

        void CopyToClipboard()
        {
            string str1 = "";
            PopUp.PopupData popupData = this.BuildList(true);
            int num1 = this.RecipeInfo.pData.Sections.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                int num2 = this.RecipeInfo.pData.Sections[index1].Content.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    PopUp.StringValue[] content = popupData.Sections[index1].Content;
                    int index3 = index2;
                    string str2 = str1 + content[index3].Text;
                    if (content[index3].TextColumn != "")
                        str2 = str2 + "  " + content[index3].TextColumn;
                    str1 = str2 + "\r\n";
                }
                str1 += "\r\n";
            }
            Clipboard.SetDataObject(str1, true);
            int num3 = (int)Interaction.MsgBox("Data copied to clipboard!", MsgBoxStyle.Information, "Done");
        }
        void ibClipboard_ButtonClicked()
        {
            try
            {
                CopyToClipboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clipboard copy failed:" + ex.Message);
            }
        }

        void ibClose_ButtonClicked()

        {
            this.Close();
        }

        void ibMiniList_ButtonClicked()

        {
            this.myParent.SetMiniList(this.BuildList(true), "Shopping List", 2048);
        }

        void ibTopmost_ButtonClicked()

        {
            this.TopMost = this.ibTopmost.Checked;
            if (!this.TopMost)
                return;
            this.BringToFront();
        }

        [DebuggerStepThrough]

        void lvPower_ItemChecked(object sender, ItemCheckedEventArgs e)

        {
            if (e.Item.Index == 0)
            {
                if (Operators.ConditionalCompareObjectLess(e.Item.Tag, 0, false) && e.Item.Checked)
                {
                    int num = this.lvPower.Items.Count - 1;
                    for (int index = 1; index <= num; ++index)
                        this.lvPower.Items[index].Checked = false;
                }
            }
            else if (e.Item.Checked)
                this.lvPower.Items[0].Checked = false;
            this.FillEnhList();
        }

        void lvPower_MouseEnter(object sender, EventArgs e)

        {
            this.lvPower.Focus();
        }

        void lvDPA_MouseEnter(object sender, EventArgs e)

        {
            this.lvDPA.Focus();
        }

        void lvDPA_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.RecipeInfo.ScrollY = 0.0f;
            this.RecipeInfo.SetPopup(this.BuildList(false));
            this.ChangedRecipeInfoElements();
        }

        static void putInList(ref frmRecipeViewer.CountingList[] tl, string item)

        {
            int num = tl.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (tl[index].Text == item)
                {
                    ++tl[index].Count;
                    return;
                }
            }
            tl = (frmRecipeViewer.CountingList[])Utils.CopyArray(tl, (Array)new frmRecipeViewer.CountingList[tl.Length + 1]);
            tl[tl.Length - 1].Count = 1;
            tl[tl.Length - 1].Text = item;
        }

        void RecipeInfo_MouseEnter(object sender, EventArgs e)

        {
            this.VScrollBar1.Focus();
        }

        void RecipeInfo_MouseWheel(object sender, MouseEventArgs e)

        {
            this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject(this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, -1, 1)));
            if (this.VScrollBar1.Value > this.VScrollBar1.Maximum - 9)
                this.VScrollBar1.Value = this.VScrollBar1.Maximum - 9;
            this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        public void SetLocation()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = MainModule.MidsController.SzFrmRecipe.X;
            rectangle.Y = MainModule.MidsController.SzFrmRecipe.Y;
            rectangle.Width = MainModule.MidsController.SzFrmRecipe.Width;
            rectangle.Height = MainModule.MidsController.SzFrmRecipe.Height;
            if (rectangle.Width < 1)
                rectangle.Width = this.Width;
            if (rectangle.Height < 1)
                rectangle.Height = this.Height;
            if (rectangle.Width < this.MinimumSize.Width)
                rectangle.Width = this.MinimumSize.Width;
            if (rectangle.Height < this.MinimumSize.Height)
                rectangle.Height = this.MinimumSize.Height;
            if (rectangle.X < 1)
                rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - this.Width) / 2.0);
            if (rectangle.Y < 32)
                rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - this.Height) / 2.0);
            this.Top = rectangle.Y;
            this.Left = rectangle.X;
            this.Height = rectangle.Height;
            this.Width = rectangle.Width;
        }

        static PopUp.StringValue[] sortPopupStrings(

          bool Mini,
          int colorSortMode,
          PopUp.StringValue[] inStrs)
        {
            int num1 = 0;
            int[] numArray = new int[inStrs.Length - 1 + 1];
            int num2 = numArray.Length - 1;
            for (int index1 = 0; index1 <= num2; ++index1)
            {
                bool flag = false;
                int num3 = index1 - 1;
                for (int index2 = 0; index2 <= num3; ++index2)
                {
                    flag = true;
                    switch (colorSortMode)
                    {
                        case 1:
                            num1 = frmRecipeViewer.colorRarityCompare(inStrs[numArray[index2]].tColor, inStrs[index1].tColor);
                            break;
                        case 2:
                            num1 = frmRecipeViewer.colorRarityCompareB(inStrs[numArray[index2]].tColor, inStrs[index1].tColor);
                            break;
                    }
                    if (num1 == 0 && string.Compare(Conversions.ToString(Interaction.IIf(Mini, inStrs[index1].TextColumn, inStrs[index1].Text)), Conversions.ToString(Interaction.IIf(Mini, inStrs[numArray[index2]].TextColumn, inStrs[numArray[index2]].Text))) < 0 || num1 > 0)
                    {
                        int num4 = index2;
                        for (int index3 = index1 - 1; index3 >= num4; index3 += -1)
                            numArray[index3 + 1] = numArray[index3];
                        numArray[index2] = index1;
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    numArray[index1] = index1;
            }
            PopUp.StringValue[] stringValueArray = new PopUp.StringValue[inStrs.Length - 1 + 1];
            int num5 = inStrs.Length - 1;
            for (int index = 0; index <= num5; ++index)
                stringValueArray[index] = inStrs[numArray[index]];
            return stringValueArray;
        }

        void StoreLocation()

        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            MainModule.MidsController.SzFrmRecipe.X = this.Left;
            MainModule.MidsController.SzFrmRecipe.Y = this.Top;
            MainModule.MidsController.SzFrmRecipe.Width = this.Width;
            MainModule.MidsController.SzFrmRecipe.Height = this.Height;
        }

        public void UpdateData()
        {
            this.BackColor = this.myParent.BackColor;
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
            this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibClipboard.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClipboard.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClipboard.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibMiniList.IA = this.myParent.Drawing.pImageAttributes;
            this.ibMiniList.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibMiniList.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.FillPowerList();
        }

        void UpdatePowerList()

        {
            if (this.Loading)
                return;
            this.FillPowerList();
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)

        {
            this.RecipeInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * ((double)this.RecipeInfo.lHeight - (double)this.Panel1.Height));
        }

        struct CountingList

        {
            public string Text;
            public int Count;
        }
    }
}