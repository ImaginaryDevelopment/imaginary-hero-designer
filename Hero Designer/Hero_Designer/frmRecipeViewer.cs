using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{


    public partial class frmRecipeViewer : Form
    {

    
    
        internal virtual CheckBox chkRecipe
        {
            get
            {
                return this._chkRecipe;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkRecipe_CheckedChanged);
                if (this._chkRecipe != null)
                {
                    this._chkRecipe.CheckedChanged -= eventHandler;
                }
                this._chkRecipe = value;
                if (this._chkRecipe != null)
                {
                    this._chkRecipe.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkSortByLevel
        {
            get
            {
                return this._chkSortByLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSortByLevel_CheckedChanged);
                if (this._chkSortByLevel != null)
                {
                    this._chkSortByLevel.CheckedChanged -= eventHandler;
                }
                this._chkSortByLevel = value;
                if (this._chkSortByLevel != null)
                {
                    this._chkSortByLevel.CheckedChanged += eventHandler;
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


    
    
        internal virtual ImageButton ibClipboard
        {
            get
            {
                return this._ibClipboard;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClipboard_ButtonClicked);
                if (this._ibClipboard != null)
                {
                    this._ibClipboard.ButtonClicked -= clickedEventHandler;
                }
                this._ibClipboard = value;
                if (this._ibClipboard != null)
                {
                    this._ibClipboard.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ImageButton ibClose
        {
            get
            {
                return this._ibClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
                if (this._ibClose != null)
                {
                    this._ibClose.ButtonClicked -= clickedEventHandler;
                }
                this._ibClose = value;
                if (this._ibClose != null)
                {
                    this._ibClose.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ImageButton ibMiniList
        {
            get
            {
                return this._ibMiniList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibMiniList_ButtonClicked);
                if (this._ibMiniList != null)
                {
                    this._ibMiniList.ButtonClicked -= clickedEventHandler;
                }
                this._ibMiniList = value;
                if (this._ibMiniList != null)
                {
                    this._ibMiniList.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ImageButton ibTopmost
        {
            get
            {
                return this._ibTopmost;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTopmost_ButtonClicked);
                if (this._ibTopmost != null)
                {
                    this._ibTopmost.ButtonClicked -= clickedEventHandler;
                }
                this._ibTopmost = value;
                if (this._ibTopmost != null)
                {
                    this._ibTopmost.ButtonClicked += clickedEventHandler;
                }
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


    
    
        internal virtual Label lblHeader
        {
            get
            {
                return this._lblHeader;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblHeader = value;
            }
        }


    
    
        internal virtual ListView lvPower
        {
            get
            {
                return this._lvPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPower_MouseEnter);
                ItemCheckedEventHandler checkedEventHandler = new ItemCheckedEventHandler(this.lvPower_ItemChecked);
                if (this._lvPower != null)
                {
                    this._lvPower.MouseEnter -= eventHandler;
                    this._lvPower.ItemChecked -= checkedEventHandler;
                }
                this._lvPower = value;
                if (this._lvPower != null)
                {
                    this._lvPower.MouseEnter += eventHandler;
                    this._lvPower.ItemChecked += checkedEventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvDPA
        {
            get
            {
                return this._lvDPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvDPA_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvDPA_MouseEnter);
                if (this._lvDPA != null)
                {
                    this._lvDPA.SelectedIndexChanged -= eventHandler;
                    this._lvDPA.MouseEnter -= eventHandler2;
                }
                this._lvDPA = value;
                if (this._lvDPA != null)
                {
                    this._lvDPA.SelectedIndexChanged += eventHandler;
                    this._lvDPA.MouseEnter += eventHandler2;
                }
            }
        }


    
    
        internal virtual Panel Panel1
        {
            get
            {
                return this._Panel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Panel1 = value;
            }
        }


    
    
        internal virtual Panel Panel2
        {
            get
            {
                return this._Panel2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Panel2 = value;
            }
        }


    
    
        internal virtual PictureBox pbRecipe
        {
            get
            {
                return this._pbRecipe;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pbRecipe = value;
            }
        }


    
    
        internal virtual ctlPopUp RecipeInfo
        {
            get
            {
                return this._RecipeInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.RecipeInfo_MouseWheel);
                EventHandler eventHandler = new EventHandler(this.RecipeInfo_MouseEnter);
                if (this._RecipeInfo != null)
                {
                    this._RecipeInfo.MouseWheel -= mouseEventHandler;
                    this._RecipeInfo.MouseEnter -= eventHandler;
                }
                this._RecipeInfo = value;
                if (this._RecipeInfo != null)
                {
                    this._RecipeInfo.MouseWheel += mouseEventHandler;
                    this._RecipeInfo.MouseEnter += eventHandler;
                }
            }
        }


    
    
        internal virtual ToolTip ToolTip1
        {
            get
            {
                return this._ToolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolTip1 = value;
            }
        }


    
    
        internal virtual VScrollBar VScrollBar1
        {
            get
            {
                return this._VScrollBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ScrollEventHandler scrollEventHandler = new ScrollEventHandler(this.VScrollBar1_Scroll);
                if (this._VScrollBar1 != null)
                {
                    this._VScrollBar1.Scroll -= scrollEventHandler;
                }
                this._VScrollBar1 = value;
                if (this._VScrollBar1 != null)
                {
                    this._VScrollBar1.Scroll += scrollEventHandler;
                }
            }
        }


        public frmRecipeViewer(frmMain iParent)
        {
            base.FormClosed += this.frmRecipeViewer_FormClosed;
            base.Load += this.frmRecipeViewer_Load;
            this.Loading = true;
            this.InitializeComponent();
            this.myParent = iParent;
            this.bxRecipe = new ExtendedBitmap(I9Gfx.GetRecipeName());
        }


        private void AddToImageList(int eIDX)
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height);
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[eIDX];
            if (enhancement.ImageIdx > -1)
            {
                extendedBitmap.Graphics.Clear(Color.White);
                Graphics graphics = extendedBitmap.Graphics;
                I9Gfx.DrawEnhancement(ref graphics, enhancement.ImageIdx, Origin.Grade.IO);
                this.ilSets.Images.Add(extendedBitmap.Bitmap);
            }
            else
            {
                this.ilSets.Images.Add(new Bitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height));
            }
        }


        private PopUp.PopupData BuildList(bool Mini)
        {
            int iIndent = 1;
            PopUp.PopupData popupData = default(PopUp.PopupData);
            frmRecipeViewer.CountingList[] tl = new frmRecipeViewer.CountingList[0];
            if (this.lvDPA.SelectedIndices.Count >= 1)
            {
                int num12 = this.lvDPA.SelectedIndices[0];
                int rIdx;
                if (num12 == 0)
                {
                    int[] numArray = new int[DatabaseAPI.Database.Salvage.Length - 1 + 1];
                    int num = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    this.DrawIcon(-1);
                    int[][] numArray2 = new int[DatabaseAPI.Database.Recipes.Length - 1 + 1][];
                    int num5 = numArray2.Length - 1;
                    for (int index2 = 0; index2 <= num5; index2++)
                    {
                        int[] numArray3 = new int[DatabaseAPI.Database.Recipes[index2].Item.Length - 1 + 1];
                        numArray2[index2] = numArray3;
                    }
                    int num6 = this.lvDPA.Items.Count - 1;
                    for (int index2 = 1; index2 <= num6; index2++)
                    {
                        rIdx = DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.Items[index2].Tag)].RecipeIDX;
                        if (this.lvDPA.Items[index2].SubItems[1].Text == "*")
                        {
                            rIdx = -1;
                            frmRecipeViewer.putInList(ref tl, this.lvDPA.Items[index2].Text);
                        }
                        if (rIdx > -1)
                        {
                            int iLevel = Conversions.ToInteger(this.lvDPA.Items[index2].SubItems[1].Text) - 1;
                            int itemId = frmRecipeViewer.FindItemID(rIdx, iLevel);
                            if (itemId > -1)
                            {
                                if (this.chkRecipe.Checked)
                                {
                                    int[][] array = numArray2;
                                    int num13 = rIdx;
                                    int index3 = itemId;
                                    array[num13][index3]++;
                                }
                                Recipe.RecipeEntry recipeEntry = DatabaseAPI.Database.Recipes[rIdx].Item[itemId];
                                int num7 = recipeEntry.SalvageIdx.Length - 1;
                                for (int index4 = 0; index4 <= num7; index4++)
                                {
                                    if (recipeEntry.SalvageIdx[index4] > -1 & recipeEntry.Count[index4] > 0)
                                    {
                                        if (index4 != 0 & recipeEntry.SalvageIdx[index4] == recipeEntry.SalvageIdx[0])
                                        {
                                            break;
                                        }
                                        int[] numArray3 = numArray;
                                        int[] salvageIdx = recipeEntry.SalvageIdx;
                                        int index3 = index4;
                                        numArray3[salvageIdx[index3]] += recipeEntry.Count[index4];
                                        num4 += recipeEntry.Count[index4];
                                    }
                                }
                                num += recipeEntry.CraftCost;
                                if (recipeEntry.CraftCostM > 0)
                                {
                                    num3 += recipeEntry.CraftCostM;
                                }
                                else if (DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.Items[index2].Tag)].TypeID == Enums.eType.SetO)
                                {
                                    num3 += recipeEntry.CraftCost;
                                }
                                num2 += recipeEntry.BuyCost;
                            }
                        }
                    }
                    int index5 = popupData.Add(null);
                    if (Mini)
                    {
                        iIndent = 0;
                    }
                    this.lblHeader.Text = "Shopping List";
                    if (this.lvPower.CheckedIndices.Count == 1)
                    {
                        if (!this.lvPower.Items[0].Checked)
                        {
                            popupData.Sections[index5].Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[Conversions.ToInteger(this.lvPower.CheckedItems[0].Tag)].NIDPower].DisplayName, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        }
                        else
                        {
                            popupData.Sections[index5].Add("All Powers", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        }
                    }
                    else
                    {
                        popupData.Sections[index5].Add(Conversions.ToString(this.lvPower.CheckedIndices.Count) + " Powers", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    }
                    if (!this.chkRecipe.Checked)
                    {
                        popupData.Sections[index5].Add(Conversions.ToString(this.lvDPA.Items.Count - this.nonRecipeCount) + " Recipes:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    }
                    string iText2;
                    if (Mini)
                    {
                        iText2 = "Buy:";
                        if (num2 > 0)
                        {
                            popupData.Sections[index5].Add(iText2 + " " + Strings.Format(num2, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
                        }
                    }
                    else
                    {
                        iText2 = "Buy Cost:";
                        if (num2 > 0)
                        {
                            popupData.Sections[index5].Add(iText2, PopUp.Colors.Invention, Strings.Format(num2, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
                        }
                    }
                    if (Mini)
                    {
                        iText2 = "Craft:";
                        if (num > 0)
                        {
                            popupData.Sections[index5].Add(iText2 + " " + Strings.Format(num, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
                        }
                    }
                    else
                    {
                        iText2 = "Craft Cost:";
                        if (num > 0)
                        {
                            popupData.Sections[index5].Add(iText2, PopUp.Colors.Invention, Strings.Format(num, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
                        }
                    }
                    if (Mini)
                    {
                        iText2 = "Craft (Mem'd):";
                        if (num3 > 0 & num3 != num)
                        {
                            popupData.Sections[index5].Add(iText2 + " " + Strings.Format(num3, "###,###,##0"), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, iIndent);
                        }
                    }
                    else
                    {
                        iText2 = "Craft Cost (Memorized Common):";
                        if (num3 > 0 & num3 != num)
                        {
                            popupData.Sections[index5].Add(iText2, PopUp.Colors.Effect, Strings.Format(num3, "###,###,##0"), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, iIndent);
                        }
                    }
                    if (this.chkRecipe.Checked)
                    {
                        this.RecipeInfo.ColumnPosition = 0.75f;
                        index5 = popupData.Add(null);
                        popupData.Sections[index5].Add(Conversions.ToString(this.lvDPA.Items.Count - this.nonRecipeCount) + " Recipes:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        int num8 = numArray2.Length - 1;
                        for (int index2 = 0; index2 <= num8; index2++)
                        {
                            int num9 = numArray2[index2].Length - 1;
                            for (int index6 = 0; index6 <= num9; index6++)
                            {
                                if (numArray2[index2][index6] > 0)
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
                                    {
                                        popupData.Sections[index5].Add(" " + Conversions.ToString(numArray2[index2][index6]) + " x", color, DatabaseAPI.GetEnhancementNameShortWSet(DatabaseAPI.Database.Recipes[index2].EnhIdx) + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index2].Item[index6].Level + 1) + ")", color, 0.9f, FontStyle.Bold, iIndent);
                                    }
                                    else
                                    {
                                        popupData.Sections[index5].Add(DatabaseAPI.GetEnhancementNameShortWSet(DatabaseAPI.Database.Recipes[index2].EnhIdx) + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index2].Item[index6].Level + 1) + ")", color, Conversions.ToString(numArray2[index2][index6]), color, 0.9f, FontStyle.Bold, iIndent);
                                    }
                                }
                            }
                        }
                        popupData.Sections[index5].Content = frmRecipeViewer.sortPopupStrings(Mini, 2, popupData.Sections[index5].Content);
                    }
                    else
                    {
                        this.RecipeInfo.ColumnPosition = 0.5f;
                    }
                    if (Mini)
                    {
                        popupData.ColPos = 0.15f;
                        popupData.ColRight = false;
                    }
                    index5 = popupData.Add(null);
                    if (Mini)
                    {
                        iText2 = Conversions.ToString(num4) + " Items:";
                    }
                    else
                    {
                        iText2 = Conversions.ToString(num4) + " Salvage Items:";
                    }
                    popupData.Sections[index5].Add(iText2, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    int num10 = numArray.Length - 1;
                    for (int index2 = 0; index2 <= num10; index2++)
                    {
                        if (numArray[index2] > 0)
                        {
                            Color color2 = Color.White;
                            switch (DatabaseAPI.Database.Salvage[index2].Rarity)
                            {
                                case Recipe.RecipeRarity.Common:
                                    color2 = PopUp.Colors.Common;
                                    break;
                                case Recipe.RecipeRarity.Uncommon:
                                    color2 = PopUp.Colors.Uncommon;
                                    break;
                                case Recipe.RecipeRarity.Rare:
                                    color2 = PopUp.Colors.Rare;
                                    break;
                            }
                            if (Mini)
                            {
                                popupData.Sections[index5].Add(" " + Conversions.ToString(numArray[index2]) + " x", color2, DatabaseAPI.Database.Salvage[index2].ExternalName, color2, 0.9f, FontStyle.Bold, 0);
                            }
                            else
                            {
                                popupData.Sections[index5].Add(DatabaseAPI.Database.Salvage[index2].ExternalName, color2, Conversions.ToString(numArray[index2]), color2, 0.9f, FontStyle.Bold, 1);
                            }
                        }
                    }
                    popupData.Sections[index5].Content = frmRecipeViewer.sortPopupStrings(Mini, 1, popupData.Sections[index5].Content);
                    if (this.nonRecipeCount != 1)
                    {
                        index5 = popupData.Add(null);
                        if (Mini)
                        {
                            iText2 = Conversions.ToString(this.nonRecipeCount - 1) + " Enhs:";
                        }
                        else
                        {
                            iText2 = Conversions.ToString(this.nonRecipeCount - 1) + " Non-Crafted Enhancements:";
                        }
                        popupData.Sections[index5].Add(iText2, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        int num11 = tl.Length - 1;
                        for (int index2 = 0; index2 <= num11; index2++)
                        {
                            Color common = PopUp.Colors.Common;
                            if (Mini)
                            {
                                popupData.Sections[index5].Add(" " + Conversions.ToString(tl[index2].Count) + " x", common, tl[index2].Text, common, 0.9f, FontStyle.Bold, 0);
                            }
                            else
                            {
                                popupData.Sections[index5].Add(tl[index2].Text, common, Conversions.ToString(tl[index2].Count), common, 0.9f, FontStyle.Bold, 1);
                            }
                        }
                        popupData.Sections[index5].Content = frmRecipeViewer.sortPopupStrings(Mini, 1, popupData.Sections[index5].Content);
                    }
                    return popupData;
                }
                this.lblHeader.Text = DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.SelectedItems[0].Tag)].LongName + " (" + this.lvDPA.SelectedItems[0].SubItems[1].Text + ")";
                rIdx = DatabaseAPI.Database.Enhancements[Conversions.ToInteger(this.lvDPA.SelectedItems[0].Tag)].RecipeIDX;
                if (this.lvDPA.SelectedItems[0].SubItems[1].Text == "*")
                {
                    rIdx = -1;
                }
                this.DrawIcon(Conversions.ToInteger(this.lvDPA.SelectedItems[0].Tag));
                if (rIdx > -1)
                {
                    int index5 = popupData.Add(null);
                    popupData.Sections[index5] = Character.PopRecipeInfo(rIdx, Conversions.ToInteger(this.lvDPA.SelectedItems[0].SubItems[1].Text) - 1);
                    if (popupData.Sections[index5].Content != null && popupData.Sections[index5].Content.Length > 0)
                    {
                        PopUp.StringValue[] content = popupData.Sections[index5].Content;
                        int index3 = 0;
                        content[index3].Text = content[index3].Text + " (" + this.lvDPA.SelectedItems[0].SubItems[1].Text + ")";
                        return popupData;
                    }
                    popupData.Sections[index5].Content[0].Text = "";
                }
            }
            return popupData;
        }


        private void ChangedRecipeInfoElements()
        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round((double)this.RecipeInfo.lHeight * ((double)this.VScrollBar1.LargeChange / (double)this.Panel1.Height));
        }


        private void chkRecipe_CheckedChanged(object sender, EventArgs e)
        {
            this.lvDPA_SelectedIndexChanged(this, new EventArgs());
            MidsContext.Config.ShoppingListIncludesRecipes = this.chkRecipe.Checked;
        }


        private void chkSortByLevel_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdatePowerList();
        }


        private static int colorRarityCompare(Color t1, Color t2)
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
                    {
                        return -1;
                    }
                }
                else if (t1.Equals(PopUp.Colors.Uncommon))
                {
                    if (t2.Equals(PopUp.Colors.Common))
                    {
                        return 1;
                    }
                    if (t2.Equals(PopUp.Colors.Rare) | t2.Equals(PopUp.Colors.UltraRare))
                    {
                        return -1;
                    }
                }
                else if (t1.Equals(PopUp.Colors.Rare))
                {
                    if (t2.Equals(PopUp.Colors.Common) | t2.Equals(PopUp.Colors.Uncommon))
                    {
                        return 1;
                    }
                    if (t2.Equals(PopUp.Colors.UltraRare))
                    {
                        return -1;
                    }
                }
                else if (t1.Equals(PopUp.Colors.UltraRare) && (t2.Equals(PopUp.Colors.Common) | t2.Equals(PopUp.Colors.Uncommon) | t2.Equals(PopUp.Colors.Rare)))
                {
                    return 1;
                }
                num = -1;
            }
            return num;
        }


        private static int colorRarityCompareB(Color t1, Color t2)
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
                    {
                        return -1;
                    }
                }
                else if (t1.Equals(PopUp.Colors.Uncommon) | t1.Equals(PopUp.Colors.Rare))
                {
                    if (t2.Equals(PopUp.Colors.Common))
                    {
                        return 1;
                    }
                    if (t2.Equals(PopUp.Colors.Rare))
                    {
                        return 0;
                    }
                    if (t2.Equals(PopUp.Colors.UltraRare))
                    {
                        return -1;
                    }
                }
                else if (t1.Equals(PopUp.Colors.UltraRare) && (t2.Equals(PopUp.Colors.Common) | t2.Equals(PopUp.Colors.Uncommon) | t2.Equals(PopUp.Colors.Rare)))
                {
                    return 1;
                }
                num = -1;
            }
            return num;
        }


        private void DrawIcon(int Index)
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.bxRecipe.Size);
            extendedBitmap.Graphics.Clear(Color.Black);
            extendedBitmap.Graphics.DrawImageUnscaled(this.bxRecipe.Bitmap, 0, 0);
            if (Index > -1)
            {
                extendedBitmap.Graphics.DrawImageUnscaled(I9Gfx.Enhancements[Index], 0, 0);
            }
            this.pbRecipe.Image = new Bitmap(extendedBitmap.Bitmap);
        }


        private void FillEnhList()
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
                int num = this.lvPower.CheckedIndices.Count - 1;
                if (this.lvPower.Items[0].Checked)
                {
                    flag = true;
                    num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                }
                this.ilSets.Images.Clear();
                this.nonRecipeCount = 1;
                this.lvDPA.Items.Add(" - All Recipes - ");
                int num2 = num;
                for (int index = 0; index <= num2; index++)
                {
                    int hIDX;
                    if (!flag)
                    {
                        hIDX = Conversions.ToInteger(this.lvPower.CheckedItems[index].Tag);
                    }
                    else
                    {
                        hIDX = index;
                    }
                    if (MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPowerset > -1 & this.HasIOs(hIDX))
                    {
                        int num3 = MidsContext.Character.CurrentBuild.Powers[hIDX].Slots.Length - 1;
                        for (int index2 = 0; index2 <= num3; index2++)
                        {
                            if (MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh > -1)
                            {
                                if (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                {
                                    items[0] = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].nIDSet].DisplayName + ": ";
                                    string[] strArray = items;
                                    int num4 = 0;
                                    string[] strArray2;
                                    IntPtr index3;
                                    (strArray2 = strArray)[(int)(index3 = (IntPtr)num4)] = strArray2[(int)index3] + DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].Name;
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
                                    this.nonRecipeCount++;
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
                {
                    this.lvDPA.Items[0].Selected = true;
                }
            }
        }


        private void FillPowerList()
        {
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            this.lvPower.Sorting = SortOrder.None;
            this.lvPower.Items.Add(" - All Powers - ");
            this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = -1;
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int hIDX = 0; hIDX <= num; hIDX++)
            {
                if (MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower > -1 & this.HasIOs(hIDX))
                {
                    string text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower].DisplayName;
                    if (this.chkSortByLevel.Checked)
                    {
                        text = Strings.Format(MidsContext.Character.CurrentBuild.Powers[hIDX].Level + 1, "00") + " - " + text;
                    }
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


        private static int FindItemID(int rIDX, int iLevel)
        {
            int num = -1;
            int num2 = 52;
            int num3 = 0;
            int num4 = DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1;
            for (int index = 0; index <= num4; index++)
            {
                if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level > num3)
                {
                    num3 = DatabaseAPI.Database.Recipes[rIDX].Item[index].Level;
                }
                if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level < num2)
                {
                    num2 = DatabaseAPI.Database.Recipes[rIDX].Item[index].Level;
                }
                if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level == iLevel)
                {
                    num = index;
                    break;
                }
            }
            if (num < 0)
            {
                iLevel = Enhancement.GranularLevelZb(iLevel, 0, 49, 5);
                int num5 = DatabaseAPI.Database.Recipes[rIDX].Item.Length - 1;
                for (int index = 0; index <= num5; index++)
                {
                    if (DatabaseAPI.Database.Recipes[rIDX].Item[index].Level == iLevel)
                    {
                        num = index;
                        break;
                    }
                }
            }
            int result;
            if (num < 0)
            {
                result = -1;
            }
            else
            {
                result = num;
            }
            return result;
        }


        private void frmRecipeViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StoreLocation();
            this.myParent.FloatRecipe(false);
        }


        private void frmRecipeViewer_Load(object sender, EventArgs e)
        {
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
            this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.RecipeInfo.SetPopup(default(PopUp.PopupData));
            this.ChangedRecipeInfoElements();
            this.chkRecipe.Checked = MidsContext.Config.ShoppingListIncludesRecipes;
            this.Loading = false;
        }


        private bool HasIOs(int hIDX)
        {
            if (hIDX >= 0)
            {
                int num = MidsContext.Character.CurrentBuild.Powers[hIDX].Slots.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index].Enhancement.Enh > -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private void ibClipboard_ButtonClicked()
        {
            string str = "";
            PopUp.PopupData popupData = this.BuildList(true);
            int num = this.RecipeInfo.pData.Sections.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                int num2 = this.RecipeInfo.pData.Sections[index].Content.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    PopUp.StringValue[] content = popupData.Sections[index].Content;
                    int index3 = index2;
                    str += content[index3].Text;
                    if (content[index3].TextColumn != "")
                    {
                        str = str + "  " + content[index3].TextColumn;
                    }
                    str += "\r\n";
                }
                str += "\r\n";
            }
            Clipboard.SetDataObject(str, true);
            Interaction.MsgBox("Data copied to clipboard!", MsgBoxStyle.Information, "Done");
        }


        private void ibClose_ButtonClicked()
        {
            base.Close();
        }


        private void ibMiniList_ButtonClicked()
        {
            this.myParent.SetMiniList(this.BuildList(true), "Shopping List", 2048);
        }


        private void ibTopmost_ButtonClicked()
        {
            base.TopMost = this.ibTopmost.Checked;
            if (base.TopMost)
            {
                base.BringToFront();
            }
        }


        private void lvPower_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Index == 0)
            {
                if (Operators.ConditionalCompareObjectLess(e.Item.Tag, 0, false) && e.Item.Checked)
                {
                    int num = this.lvPower.Items.Count - 1;
                    for (int index = 1; index <= num; index++)
                    {
                        this.lvPower.Items[index].Checked = false;
                    }
                }
            }
            else if (e.Item.Checked)
            {
                this.lvPower.Items[0].Checked = false;
            }
            this.FillEnhList();
        }


        private void lvPower_MouseEnter(object sender, EventArgs e)
        {
            this.lvPower.Focus();
        }


        private void lvDPA_MouseEnter(object sender, EventArgs e)
        {
            this.lvDPA.Focus();
        }


        private void lvDPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RecipeInfo.ScrollY = 0f;
            this.RecipeInfo.SetPopup(this.BuildList(false));
            this.ChangedRecipeInfoElements();
        }


        private static void putInList(ref frmRecipeViewer.CountingList[] tl, string item)
        {
            int num = tl.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (tl[index].Text == item)
                {
                    frmRecipeViewer.CountingList[] array = tl;
                    int num2 = index;
                    array[num2].Count = array[num2].Count + 1;
                    return;
                }
            }
            tl = (frmRecipeViewer.CountingList[])Utils.CopyArray(tl, new frmRecipeViewer.CountingList[tl.Length + 1]);
            tl[tl.Length - 1].Count = 1;
            tl[tl.Length - 1].Text = item;
        }


        private void RecipeInfo_MouseEnter(object sender, EventArgs e)
        {
            this.VScrollBar1.Focus();
        }


        private void RecipeInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject(this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, -1, 1)));
            if (this.VScrollBar1.Value > this.VScrollBar1.Maximum - 9)
            {
                this.VScrollBar1.Value = this.VScrollBar1.Maximum - 9;
            }
            this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }


        public void SetLocation()
        {
            Rectangle rectangle = default(Rectangle);
            rectangle.X = MainModule.MidsController.SzFrmRecipe.X;
            rectangle.Y = MainModule.MidsController.SzFrmRecipe.Y;
            rectangle.Width = MainModule.MidsController.SzFrmRecipe.Width;
            rectangle.Height = MainModule.MidsController.SzFrmRecipe.Height;
            if (rectangle.Width < 1)
            {
                rectangle.Width = base.Width;
            }
            if (rectangle.Height < 1)
            {
                rectangle.Height = base.Height;
            }
            if (rectangle.Width < this.MinimumSize.Width)
            {
                rectangle.Width = this.MinimumSize.Width;
            }
            if (rectangle.Height < this.MinimumSize.Height)
            {
                rectangle.Height = this.MinimumSize.Height;
            }
            if (rectangle.X < 1)
            {
                rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - base.Width) / 2.0);
            }
            if (rectangle.Y < 32)
            {
                rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - base.Height) / 2.0);
            }
            base.Top = rectangle.Y;
            base.Left = rectangle.X;
            base.Height = rectangle.Height;
            base.Width = rectangle.Width;
        }


        private static PopUp.StringValue[] sortPopupStrings(bool Mini, int colorSortMode, PopUp.StringValue[] inStrs)
        {
            int num = 0;
            int[] numArray = new int[inStrs.Length - 1 + 1];
            int num2 = numArray.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                bool flag = false;
                int num3 = index - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    flag = true;
                    if (colorSortMode == 1)
                    {
                        num = frmRecipeViewer.colorRarityCompare(inStrs[numArray[index2]].tColor, inStrs[index].tColor);
                    }
                    else if (colorSortMode == 2)
                    {
                        num = frmRecipeViewer.colorRarityCompareB(inStrs[numArray[index2]].tColor, inStrs[index].tColor);
                    }
                    if ((num == 0 && string.Compare(Conversions.ToString(Interaction.IIf(Mini, inStrs[index].TextColumn, inStrs[index].Text)), Conversions.ToString(Interaction.IIf(Mini, inStrs[numArray[index2]].TextColumn, inStrs[numArray[index2]].Text))) < 0) || num > 0)
                    {
                        int num4 = index2;
                        for (int index3 = index - 1; index3 >= num4; index3 += -1)
                        {
                            numArray[index3 + 1] = numArray[index3];
                        }
                        numArray[index2] = index;
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    numArray[index] = index;
                }
            }
            PopUp.StringValue[] stringValueArray = new PopUp.StringValue[inStrs.Length - 1 + 1];
            int num5 = inStrs.Length - 1;
            for (int index4 = 0; index4 <= num5; index4++)
            {
                stringValueArray[index4] = inStrs[numArray[index4]];
            }
            return stringValueArray;
        }


        private void StoreLocation()
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                MainModule.MidsController.SzFrmRecipe.X = base.Left;
                MainModule.MidsController.SzFrmRecipe.Y = base.Top;
                MainModule.MidsController.SzFrmRecipe.Width = base.Width;
                MainModule.MidsController.SzFrmRecipe.Height = base.Height;
            }
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


        private void UpdatePowerList()
        {
            if (!this.Loading)
            {
                this.FillPowerList();
            }
        }


        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.RecipeInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * (double)(this.RecipeInfo.lHeight - (float)this.Panel1.Height));
        }


        [AccessedThroughProperty("chkRecipe")]
        private CheckBox _chkRecipe;


        [AccessedThroughProperty("chkSortByLevel")]
        private CheckBox _chkSortByLevel;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ibClipboard")]
        private ImageButton _ibClipboard;


        [AccessedThroughProperty("ibClose")]
        private ImageButton _ibClose;


        [AccessedThroughProperty("ibMiniList")]
        private ImageButton _ibMiniList;


        [AccessedThroughProperty("ibTopmost")]
        private ImageButton _ibTopmost;


        [AccessedThroughProperty("ilSets")]
        private ImageList _ilSets;


        [AccessedThroughProperty("lblHeader")]
        private Label _lblHeader;


        [AccessedThroughProperty("lvPower")]
        private ListView _lvPower;


        [AccessedThroughProperty("lvDPA")]
        private ListView _lvDPA;


        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;


        [AccessedThroughProperty("Panel2")]
        private Panel _Panel2;


        [AccessedThroughProperty("pbRecipe")]
        private PictureBox _pbRecipe;


        [AccessedThroughProperty("RecipeInfo")]
        private ctlPopUp _RecipeInfo;


        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;


        [AccessedThroughProperty("VScrollBar1")]
        private VScrollBar _VScrollBar1;


        protected ExtendedBitmap bxRecipe;


        protected bool Loading;


        protected frmMain myParent;


        private int nonRecipeCount;


        private struct CountingList
        {

            public string Text;


            public int Count;
        }
    }
}
