
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmRecipeViewer : Form
  {
    [AccessedThroughProperty("chkRecipe")]
    CheckBox _chkRecipe;

    [AccessedThroughProperty("chkSortByLevel")]
    CheckBox _chkSortByLevel;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;

    [AccessedThroughProperty("ibClipboard")]
    ImageButton _ibClipboard;

    [AccessedThroughProperty("ibClose")]
    ImageButton _ibClose;

    [AccessedThroughProperty("ibMiniList")]
    ImageButton _ibMiniList;

    [AccessedThroughProperty("ibTopmost")]
    ImageButton _ibTopmost;
        ImageList ilSets;
        Label lblHeader;

    [AccessedThroughProperty("lvPower")]
    ListView _lvPower;

    [AccessedThroughProperty("lvDPA")]
    ListView _lvDPA;
        Panel Panel1;
        Panel Panel2;
        PictureBox pbRecipe;

    [AccessedThroughProperty("RecipeInfo")]
    ctlPopUp _RecipeInfo;
        ToolTip ToolTip1;

    [AccessedThroughProperty("VScrollBar1")]
    VScrollBar _VScrollBar1;

    protected ExtendedBitmap bxRecipe;
    IContainer components;

    protected bool Loading;
    protected frmMain myParent;
    int nonRecipeCount;


    CheckBox chkRecipe
    {
      get
      {
        return this._chkRecipe;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkRecipe_CheckedChanged);
        if (this._chkRecipe != null)
          this._chkRecipe.CheckedChanged -= eventHandler;
        this._chkRecipe = value;
        if (this._chkRecipe == null)
          return;
        this._chkRecipe.CheckedChanged += eventHandler;
      }
    }

    CheckBox chkSortByLevel
    {
      get
      {
        return this._chkSortByLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSortByLevel_CheckedChanged);
        if (this._chkSortByLevel != null)
          this._chkSortByLevel.CheckedChanged -= eventHandler;
        this._chkSortByLevel = value;
        if (this._chkSortByLevel == null)
          return;
        this._chkSortByLevel.CheckedChanged += eventHandler;
      }
    }





    ImageButton ibClipboard
    {
      get
      {
        return this._ibClipboard;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClipboard_ButtonClicked);
        if (this._ibClipboard != null)
          this._ibClipboard.ButtonClicked -= clickedEventHandler;
        this._ibClipboard = value;
        if (this._ibClipboard == null)
          return;
        this._ibClipboard.ButtonClicked += clickedEventHandler;
      }
    }

    ImageButton ibClose
    {
      get
      {
        return this._ibClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
        if (this._ibClose != null)
          this._ibClose.ButtonClicked -= clickedEventHandler;
        this._ibClose = value;
        if (this._ibClose == null)
          return;
        this._ibClose.ButtonClicked += clickedEventHandler;
      }
    }

    ImageButton ibMiniList
    {
      get
      {
        return this._ibMiniList;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibMiniList_ButtonClicked);
        if (this._ibMiniList != null)
          this._ibMiniList.ButtonClicked -= clickedEventHandler;
        this._ibMiniList = value;
        if (this._ibMiniList == null)
          return;
        this._ibMiniList.ButtonClicked += clickedEventHandler;
      }
    }

    ImageButton ibTopmost
    {
      get
      {
        return this._ibTopmost;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTopmost_ButtonClicked);
        if (this._ibTopmost != null)
          this._ibTopmost.ButtonClicked -= clickedEventHandler;
        this._ibTopmost = value;
        if (this._ibTopmost == null)
          return;
        this._ibTopmost.ButtonClicked += clickedEventHandler;
      }
    }



    ListView lvPower
    {
      get
      {
        return this._lvPower;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvPower_MouseEnter);
        ItemCheckedEventHandler checkedEventHandler = new ItemCheckedEventHandler(this.lvPower_ItemChecked);
        if (this._lvPower != null)
        {
          this._lvPower.MouseEnter -= eventHandler;
          this._lvPower.ItemChecked -= checkedEventHandler;
        }
        this._lvPower = value;
        if (this._lvPower == null)
          return;
        this._lvPower.MouseEnter += eventHandler;
        this._lvPower.ItemChecked += checkedEventHandler;
      }
    }

    ListView lvDPA
    {
      get
      {
        return this._lvDPA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.lvDPA_SelectedIndexChanged);
        EventHandler eventHandler2 = new EventHandler(this.lvDPA_MouseEnter);
        if (this._lvDPA != null)
        {
          this._lvDPA.SelectedIndexChanged -= eventHandler1;
          this._lvDPA.MouseEnter -= eventHandler2;
        }
        this._lvDPA = value;
        if (this._lvDPA == null)
          return;
        this._lvDPA.SelectedIndexChanged += eventHandler1;
        this._lvDPA.MouseEnter += eventHandler2;
      }
    }




    ctlPopUp RecipeInfo
    {
      get
      {
        return this._RecipeInfo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.RecipeInfo_MouseWheel);
        EventHandler eventHandler = new EventHandler(this.RecipeInfo_MouseEnter);
        if (this._RecipeInfo != null)
        {
          this._RecipeInfo.MouseWheel -= mouseEventHandler;
          this._RecipeInfo.MouseEnter -= eventHandler;
        }
        this._RecipeInfo = value;
        if (this._RecipeInfo == null)
          return;
        this._RecipeInfo.MouseWheel += mouseEventHandler;
        this._RecipeInfo.MouseEnter += eventHandler;
      }
    }


    VScrollBar VScrollBar1
    {
      get
      {
        return this._VScrollBar1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ScrollEventHandler scrollEventHandler = new ScrollEventHandler(this.VScrollBar1_Scroll);
        if (this._VScrollBar1 != null)
          this._VScrollBar1.Scroll -= scrollEventHandler;
        this._VScrollBar1 = value;
        if (this._VScrollBar1 == null)
          return;
        this._VScrollBar1.Scroll += scrollEventHandler;
      }
    }

    public frmRecipeViewer(frmMain iParent)
    {
      this.FormClosed += new FormClosedEventHandler(this.frmRecipeViewer_FormClosed);
      this.Load += new EventHandler(this.frmRecipeViewer_Load);
      this.Loading = true;
      this.InitializeComponent();
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
        this.ilSets.Images.Add((Image) extendedBitmap.Bitmap);
      }
      else
        this.ilSets.Images.Add((Image) new Bitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height));
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
          int index3 = popupData.Add((PopUp.Section) null);
          if (Mini)
            iIndent = 0;
          this.lblHeader.Text = "Shopping List";
          if (this.lvPower.CheckedIndices.Count == 1)
          {
            if (!this.lvPower.Items[0].Checked)
              popupData.Sections[index3].Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[Conversions.ToInteger(this.lvPower.CheckedItems[0].Tag)].NIDPower].DisplayName, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            else
              popupData.Sections[index3].Add("All Powers", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
          }
          else
            popupData.Sections[index3].Add(Conversions.ToString(this.lvPower.CheckedIndices.Count) + " Powers", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
          if (!this.chkRecipe.Checked)
            popupData.Sections[index3].Add(Conversions.ToString(this.lvDPA.Items.Count - this.nonRecipeCount) + " Recipes:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
          if (Mini)
          {
            string str = "Buy:";
            if (num2 > 0)
              popupData.Sections[index3].Add(str + " " + Strings.Format((object) num2, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
          }
          else
          {
            string iText = "Buy Cost:";
            if (num2 > 0)
              popupData.Sections[index3].Add(iText, PopUp.Colors.Invention, Strings.Format((object) num2, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
          }
          if (Mini)
          {
            string str = "Craft:";
            if (num1 > 0)
              popupData.Sections[index3].Add(str + " " + Strings.Format((object) num1, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
          }
          else
          {
            string iText = "Craft Cost:";
            if (num1 > 0)
              popupData.Sections[index3].Add(iText, PopUp.Colors.Invention, Strings.Format((object) num1, "###,###,##0"), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, iIndent);
          }
          if (Mini)
          {
            string str = "Craft (Mem'd):";
            if (num3 > 0 & num3 != num1)
              popupData.Sections[index3].Add(str + " " + Strings.Format((object) num3, "###,###,##0"), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, iIndent);
          }
          else
          {
            string iText = "Craft Cost (Memorized Common):";
            if (num3 > 0 & num3 != num1)
              popupData.Sections[index3].Add(iText, PopUp.Colors.Effect, Strings.Format((object) num3, "###,###,##0"), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, iIndent);
          }
          if (this.chkRecipe.Checked)
          {
            this.RecipeInfo.ColumnPosition = 0.75f;
            int index1 = popupData.Add((PopUp.Section) null);
            popupData.Sections[index1].Add(Conversions.ToString(this.lvDPA.Items.Count - this.nonRecipeCount) + " Recipes:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
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
                    popupData.Sections[index1].Add(" " + Conversions.ToString(numArray2[index2][index4]) + " x", color, DatabaseAPI.GetEnhancementNameShortWSet(DatabaseAPI.Database.Recipes[index2].EnhIdx) + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index2].Item[index4].Level + 1) + ")", color, 0.9f, FontStyle.Bold, iIndent);
                  else
                    popupData.Sections[index1].Add(DatabaseAPI.GetEnhancementNameShortWSet(DatabaseAPI.Database.Recipes[index2].EnhIdx) + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index2].Item[index4].Level + 1) + ")", color, Conversions.ToString(numArray2[index2][index4]), color, 0.9f, FontStyle.Bold, iIndent);
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
          int index5 = popupData.Add((PopUp.Section) null);
          string iText1 = !Mini ? Conversions.ToString(num4) + " Salvage Items:" : Conversions.ToString(num4) + " Items:";
          popupData.Sections[index5].Add(iText1, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
          int num9 = numArray1.Length - 1;
          for (int index1 = 0; index1 <= num9; ++index1)
          {
            if (numArray1[index1] > 0)
            {
              Color color = Color.White;
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
                popupData.Sections[index5].Add(" " + Conversions.ToString(numArray1[index1]) + " x", color, DatabaseAPI.Database.Salvage[index1].ExternalName, color, 0.9f, FontStyle.Bold, 0);
              else
                popupData.Sections[index5].Add(DatabaseAPI.Database.Salvage[index1].ExternalName, color, Conversions.ToString(numArray1[index1]), color, 0.9f, FontStyle.Bold, 1);
            }
          }
          popupData.Sections[index5].Content = frmRecipeViewer.sortPopupStrings(Mini, 1, popupData.Sections[index5].Content);
          if (this.nonRecipeCount != 1)
          {
            int index1 = popupData.Add((PopUp.Section) null);
            string iText2 = !Mini ? Conversions.ToString(this.nonRecipeCount - 1) + " Non-Crafted Enhancements:" : Conversions.ToString(this.nonRecipeCount - 1) + " Enhs:";
            popupData.Sections[index1].Add(iText2, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            int num7 = tl.Length - 1;
            for (int index2 = 0; index2 <= num7; ++index2)
            {
              Color common = PopUp.Colors.Common;
              if (Mini)
                popupData.Sections[index1].Add(" " + Conversions.ToString(tl[index2].Count) + " x", common, tl[index2].Text, common, 0.9f, FontStyle.Bold, 0);
              else
                popupData.Sections[index1].Add(tl[index2].Text, common, Conversions.ToString(tl[index2].Count), common, 0.9f, FontStyle.Bold, 1);
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
          int index1 = popupData.Add((PopUp.Section) null);
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
      this.VScrollBar1.Maximum = (int) Math.Round((double) this.RecipeInfo.lHeight * ((double) this.VScrollBar1.LargeChange / (double) this.Panel1.Height));
    }

    void chkRecipe_CheckedChanged(object sender, EventArgs e)

    {
      this.lvDPA_SelectedIndexChanged((object) this, new EventArgs());
      MidsContext.Config.ShoppingListIncludesRecipes = this.chkRecipe.Checked;
    }

    void chkSortByLevel_CheckedChanged(object sender, EventArgs e)

    {
      this.UpdatePowerList();
    }

    static int colorRarityCompare(Color t1, Color t2)

    {
      int num;
      if (t1.Equals((object) t2))
      {
        num = 0;
      }
      else
      {
        if (t1.Equals((object) PopUp.Colors.Common))
        {
          if (t2.Equals((object) PopUp.Colors.Uncommon) | t2.Equals((object) PopUp.Colors.Rare) | t2.Equals((object) PopUp.Colors.UltraRare))
            return -1;
        }
        else if (t1.Equals((object) PopUp.Colors.Uncommon))
        {
          if (t2.Equals((object) PopUp.Colors.Common))
            return 1;
          if (t2.Equals((object) PopUp.Colors.Rare) | t2.Equals((object) PopUp.Colors.UltraRare))
            return -1;
        }
        else if (t1.Equals((object) PopUp.Colors.Rare))
        {
          if (t2.Equals((object) PopUp.Colors.Common) | t2.Equals((object) PopUp.Colors.Uncommon))
            return 1;
          if (t2.Equals((object) PopUp.Colors.UltraRare))
            return -1;
        }
        else if (t1.Equals((object) PopUp.Colors.UltraRare) && t2.Equals((object) PopUp.Colors.Common) | t2.Equals((object) PopUp.Colors.Uncommon) | t2.Equals((object) PopUp.Colors.Rare))
          return 1;
        num = -1;
      }
      return num;
    }

    static int colorRarityCompareB(Color t1, Color t2)

    {
      int num;
      if (t1.Equals((object) t2))
      {
        num = 0;
      }
      else
      {
        if (t1.Equals((object) PopUp.Colors.Common))
        {
          if (t2.Equals((object) PopUp.Colors.Uncommon) | t2.Equals((object) PopUp.Colors.Rare) | t2.Equals((object) PopUp.Colors.UltraRare))
            return -1;
        }
        else if (t1.Equals((object) PopUp.Colors.Uncommon) | t1.Equals((object) PopUp.Colors.Rare))
        {
          if (t2.Equals((object) PopUp.Colors.Common))
            return 1;
          if (t2.Equals((object) PopUp.Colors.Rare))
            return 0;
          if (t2.Equals((object) PopUp.Colors.UltraRare))
            return -1;
        }
        else if (t1.Equals((object) PopUp.Colors.UltraRare) && t2.Equals((object) PopUp.Colors.Common) | t2.Equals((object) PopUp.Colors.Uncommon) | t2.Equals((object) PopUp.Colors.Rare))
          return 1;
        num = -1;
      }
      return num;
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    void DrawIcon(int Index)

    {
      ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.bxRecipe.Size);
      extendedBitmap.Graphics.Clear(Color.Black);
      extendedBitmap.Graphics.DrawImageUnscaled((Image) this.bxRecipe.Bitmap, 0, 0);
      if (Index > -1)
        extendedBitmap.Graphics.DrawImageUnscaled((Image) I9Gfx.Enhancements[Index], 0, 0);
      this.pbRecipe.Image = (Image) new Bitmap((Image) extendedBitmap.Bitmap);
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
                  (strArray2 = strArray1)[(int) (index3 = (IntPtr) num4)] = strArray2[(int)index3] + DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh].Name;
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
                this.lvDPA.Items[this.lvDPA.Items.Count - 1].Tag = (object) MidsContext.Character.CurrentBuild.Powers[hIDX].Slots[index2].Enhancement.Enh;
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
      this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = (object) -1;
      int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
      for (int hIDX = 0; hIDX <= num; ++hIDX)
      {
        if (MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower > -1 & this.HasIOs(hIDX))
        {
          string text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDX].NIDPower].DisplayName;
          if (this.chkSortByLevel.Checked)
            text = Strings.Format((object) (MidsContext.Character.CurrentBuild.Powers[hIDX].Level + 1), "00") + " - " + text;
          this.lvPower.Items.Add(text);
          this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = (object) hIDX;
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

    void ibClipboard_ButtonClicked()

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
      Clipboard.SetDataObject((object) str1, true);
      int num3 = (int) Interaction.MsgBox((object) "Data copied to clipboard!", MsgBoxStyle.Information, (object) "Done");
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
    void InitializeComponent()

    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmRecipeViewer));
      this.pbRecipe = new PictureBox();
      this.lvPower = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.lvDPA = new ListView();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.ilSets = new ImageList(this.components);
      this.chkSortByLevel = new CheckBox();
      this.lblHeader = new Label();
      this.Panel1 = new Panel();
      this.VScrollBar1 = new VScrollBar();
      this.RecipeInfo = new ctlPopUp();
      this.Panel2 = new Panel();
      this.chkRecipe = new CheckBox();
      this.ToolTip1 = new ToolTip(this.components);
      this.ibMiniList = new ImageButton();
      this.ibClipboard = new ImageButton();
      this.ibTopmost = new ImageButton();
      this.ibClose = new ImageButton();
      ((ISupportInitialize) this.pbRecipe).BeginInit();
      this.Panel1.SuspendLayout();
      this.Panel2.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(0, 0);
      this.pbRecipe.Location = point;
      this.pbRecipe.Name = "pbRecipe";
      Size size = new Size(60, 30);
      this.pbRecipe.Size = size;
      this.pbRecipe.TabIndex = 0;
      this.pbRecipe.TabStop = false;
      this.lvPower.CheckBoxes = true;
      this.lvPower.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader1
      });
      this.lvPower.FullRowSelect = true;
      this.lvPower.HideSelection = false;
      point = new Point(12, 12);
      this.lvPower.Location = point;
      this.lvPower.MultiSelect = false;
      this.lvPower.Name = "lvPower";
      size = new Size(176, 191);
      this.lvPower.Size = size;
      this.lvPower.Sorting = SortOrder.Ascending;
      this.lvPower.TabIndex = 1;
      this.lvPower.UseCompatibleStateImageBehavior = false;
      this.lvPower.View = View.Details;
      this.ColumnHeader1.Text = "Power";
      this.ColumnHeader1.Width = 148;
      this.lvDPA.Columns.AddRange(new ColumnHeader[3]
      {
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader5
      });
      this.lvDPA.FullRowSelect = true;
      this.lvDPA.HideSelection = false;
      point = new Point(194, 12);
      this.lvDPA.Location = point;
      this.lvDPA.MultiSelect = false;
      this.lvDPA.Name = "lvDPA";
      size = new Size(428, 191);
      this.lvDPA.Size = size;
      this.lvDPA.SmallImageList = this.ilSets;
      this.lvDPA.TabIndex = 8;
      this.lvDPA.UseCompatibleStateImageBehavior = false;
      this.lvDPA.View = View.Details;
      this.ColumnHeader3.Text = "Enhancement";
      this.ColumnHeader3.Width = 241;
      this.ColumnHeader4.Text = "Level";
      this.ColumnHeader4.Width = 45;
      this.ColumnHeader5.Text = "Power";
      this.ColumnHeader5.Width = 114;
      this.ilSets.ColorDepth = ColorDepth.Depth32Bit;
      size = new Size(16, 16);
      this.ilSets.ImageSize = size;
      this.ilSets.TransparentColor = Color.Transparent;
      this.chkSortByLevel.Checked = true;
      this.chkSortByLevel.CheckState = CheckState.Checked;
      this.chkSortByLevel.ForeColor = Color.White;
      point = new Point(12, 209);
      this.chkSortByLevel.Location = point;
      this.chkSortByLevel.Name = "chkSortByLevel";
      size = new Size(176, 16);
      this.chkSortByLevel.Size = size;
      this.chkSortByLevel.TabIndex = 9;
      this.chkSortByLevel.Text = "Sort By Level";
      this.chkSortByLevel.UseVisualStyleBackColor = true;
      this.lblHeader.Font = new Font("Arial", 17.5f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      this.lblHeader.ForeColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      point = new Point(66, 0);
      this.lblHeader.Location = point;
      this.lblHeader.Name = "lblHeader";
      size = new Size(541, 30);
      this.lblHeader.Size = size;
      this.lblHeader.TabIndex = 10;
      this.lblHeader.Text = "Select A Power / Recipe";
      this.lblHeader.TextAlign = ContentAlignment.MiddleLeft;
      this.Panel1.Controls.Add((Control) this.VScrollBar1);
      this.Panel1.Controls.Add((Control) this.RecipeInfo);
      point = new Point(0, 36);
      this.Panel1.Location = point;
      this.Panel1.Name = "Panel1";
      size = new Size(610, 177);
      this.Panel1.Size = size;
      this.Panel1.TabIndex = 11;
      point = new Point(593, 0);
      this.VScrollBar1.Location = point;
      this.VScrollBar1.Maximum = 20;
      this.VScrollBar1.Name = "VScrollBar1";
      size = new Size(17, 176);
      this.VScrollBar1.Size = size;
      this.VScrollBar1.TabIndex = 3;
      this.RecipeInfo.BXHeight = 2048;
      this.RecipeInfo.ColumnPosition = 0.5f;
      this.RecipeInfo.ColumnRight = false;
      this.RecipeInfo.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.RecipeInfo.ForeColor = Color.Black;
      this.RecipeInfo.InternalPadding = 3;
      point = new Point(3, 3);
      this.RecipeInfo.Location = point;
      this.RecipeInfo.Name = "RecipeInfo";
      this.RecipeInfo.ScrollY = 0.0f;
      this.RecipeInfo.SectionPadding = 8;
      size = new Size(587, 212);
      this.RecipeInfo.Size = size;
      this.RecipeInfo.TabIndex = 2;
      this.Panel2.BackColor = Color.Black;
      this.Panel2.Controls.Add((Control) this.Panel1);
      this.Panel2.Controls.Add((Control) this.pbRecipe);
      this.Panel2.Controls.Add((Control) this.lblHeader);
      point = new Point(12, 226);
      this.Panel2.Location = point;
      this.Panel2.Name = "Panel2";
      size = new Size(610, 213);
      this.Panel2.Size = size;
      this.Panel2.TabIndex = 12;
      this.chkRecipe.ForeColor = Color.White;
      point = new Point(234, 445);
      this.chkRecipe.Location = point;
      this.chkRecipe.Name = "chkRecipe";
      size = new Size(166, 22);
      this.chkRecipe.Size = size;
      this.chkRecipe.TabIndex = 15;
      this.chkRecipe.Text = "Include Recipes";
      this.ToolTip1.SetToolTip((Control) this.chkRecipe, "Add a list of recipes to the shopping list");
      this.chkRecipe.UseVisualStyleBackColor = true;
      this.ibMiniList.Checked = false;
      this.ibMiniList.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibMiniList.KnockoutLocationPoint = point;
      point = new Point(123, 445);
      this.ibMiniList.Location = point;
      this.ibMiniList.Name = "ibMiniList";
      size = new Size(105, 22);
      this.ibMiniList.Size = size;
      this.ibMiniList.TabIndex = 14;
      this.ibMiniList.TextOff = "To I-G Helper";
      this.ibMiniList.TextOn = "Alt Text";
      this.ibMiniList.Toggle = false;
      this.ibClipboard.Checked = false;
      this.ibClipboard.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibClipboard.KnockoutLocationPoint = point;
      point = new Point(12, 445);
      this.ibClipboard.Location = point;
      this.ibClipboard.Name = "ibClipboard";
      size = new Size(105, 22);
      this.ibClipboard.Size = size;
      this.ibClipboard.TabIndex = 13;
      this.ibClipboard.TextOff = "To Clipboard";
      this.ibClipboard.TextOn = "Alt Text";
      this.ibClipboard.Toggle = false;
      this.ibTopmost.Checked = true;
      this.ibTopmost.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibTopmost.KnockoutLocationPoint = point;
      point = new Point(406, 445);
      this.ibTopmost.Location = point;
      this.ibTopmost.Name = "ibTopmost";
      size = new Size(105, 22);
      this.ibTopmost.Size = size;
      this.ibTopmost.TabIndex = 7;
      this.ibTopmost.TextOff = "Keep On Top";
      this.ibTopmost.TextOn = "Keep On Top";
      this.ibTopmost.Toggle = true;
      this.ibClose.Checked = false;
      this.ibClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte) 0);
      point = new Point(0, 0);
      this.ibClose.KnockoutLocationPoint = point;
      point = new Point(517, 445);
      this.ibClose.Location = point;
      this.ibClose.Name = "ibClose";
      size = new Size(105, 22);
      this.ibClose.Size = size;
      this.ibClose.TabIndex = 6;
      this.ibClose.TextOff = "Close";
      this.ibClose.TextOn = "Alt Text";
      this.ibClose.Toggle = false;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackColor = Color.FromArgb(0, 0, 32);
      size = new Size(634, 479);
      this.ClientSize = size;
      this.Controls.Add((Control) this.chkRecipe);
      this.Controls.Add((Control) this.ibMiniList);
      this.Controls.Add((Control) this.ibClipboard);
      this.Controls.Add((Control) this.chkSortByLevel);
      this.Controls.Add((Control) this.lvDPA);
      this.Controls.Add((Control) this.ibTopmost);
      this.Controls.Add((Control) this.ibClose);
      this.Controls.Add((Control) this.lvPower);
      this.Controls.Add((Control) this.Panel2);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmRecipeViewer);
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Recipe Viewer";
      this.TopMost = true;
      ((ISupportInitialize) this.pbRecipe).EndInit();
      this.Panel1.ResumeLayout(false);
      this.Panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void lvPower_ItemChecked(object sender, ItemCheckedEventArgs e)

    {
      if (e.Item.Index == 0)
      {
        if (Operators.ConditionalCompareObjectLess(e.Item.Tag, (object) 0, false) && e.Item.Checked)
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
      tl = (frmRecipeViewer.CountingList[]) Utils.CopyArray((Array) tl, (Array) new frmRecipeViewer.CountingList[tl.Length + 1]);
      tl[tl.Length - 1].Count = 1;
      tl[tl.Length - 1].Text = item;
    }

    void RecipeInfo_MouseEnter(object sender, EventArgs e)

    {
      this.VScrollBar1.Focus();
    }

    void RecipeInfo_MouseWheel(object sender, MouseEventArgs e)

    {
      this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject((object) this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, (object) -1, (object) 1)));
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
        rectangle.X = (int) Math.Round((double) (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2.0);
      if (rectangle.Y < 32)
        rectangle.Y = (int) Math.Round((double) (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2.0);
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
          if (num1 == 0 && string.Compare(Conversions.ToString(Interaction.IIf(Mini, (object) inStrs[index1].TextColumn, (object) inStrs[index1].Text)), Conversions.ToString(Interaction.IIf(Mini, (object) inStrs[numArray[index2]].TextColumn, (object) inStrs[numArray[index2]].Text))) < 0 || num1 > 0)
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
      this.RecipeInfo.ScrollY = (float) ((double) this.VScrollBar1.Value / (double) (this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * ((double) this.RecipeInfo.lHeight - (double) this.Panel1.Height));
    }

    struct CountingList

    {
      public string Text;
      public int Count;
    }
  }
}
