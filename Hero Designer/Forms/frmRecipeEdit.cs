
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
  public partial class frmRecipeEdit : Form
  {
        Button btnAdd;

        Button btnCancel;

        Button btnDel;
        Button btnDown;

        Button btnGuessCost;

        Button btnI20;

        Button btnI25;

        Button btnI40;

        Button btnI50;

        Button btnImport;
        Button btnImportUpdate;

        Button btnIncrement;

        Button btnOK;

        Button btnRAdd;

        Button btnRDel;
        Button btnRDown;

        Button btnReGuess;

        Button btnRunSeq;
        Button btnRUp;
        Button btnUp;

        ComboBox cbEnh;

        ComboBox cbRarity;

        ComboBox cbSal0;

        ComboBox cbSal1;

        ComboBox cbSal2;

        ComboBox cbSal3;

        ComboBox cbSal4;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        Label Label1;
        Label Label10;
        Label Label11;
        Label Label12;
        Label Label13;
        Label Label14;
        Label Label15;
        Label Label2;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label Label9;
        Label lblEnh;

        ListBox lstItems;

        ListView lvDPA;

        TextBox txtExtern;

        TextBox txtRecipeName;

    [AccessedThroughProperty("udBuy")]
    NumericUpDown _udBuy;

    [AccessedThroughProperty("udBuyM")]
    NumericUpDown _udBuyM;

    [AccessedThroughProperty("udCraft")]
    NumericUpDown _udCraft;

    [AccessedThroughProperty("udCraftM")]
    NumericUpDown _udCraftM;

    [AccessedThroughProperty("udLevel")]
    NumericUpDown _udLevel;

    [AccessedThroughProperty("udSal0")]
    NumericUpDown _udSal0;

    [AccessedThroughProperty("udSal1")]
    NumericUpDown _udSal1;

    [AccessedThroughProperty("udSal2")]
    NumericUpDown _udSal2;

    [AccessedThroughProperty("udSal3")]
    NumericUpDown _udSal3;

    [AccessedThroughProperty("udSal4")]
    NumericUpDown _udSal4;


    protected bool NoUpdate;
    NumericUpDown udBuy
    {
      get
      {
        return this._udBuy;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udBuy != null)
        {
          this._udBuy.ValueChanged -= eventHandler1;
          this._udBuy.Leave -= eventHandler2;
        }
        this._udBuy = value;
        if (this._udBuy == null)
          return;
        this._udBuy.ValueChanged += eventHandler1;
        this._udBuy.Leave += eventHandler2;
      }
    }

    NumericUpDown udBuyM
    {
      get
      {
        return this._udBuyM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udBuyM != null)
        {
          this._udBuyM.ValueChanged -= eventHandler1;
          this._udBuyM.Leave -= eventHandler2;
        }
        this._udBuyM = value;
        if (this._udBuyM == null)
          return;
        this._udBuyM.ValueChanged += eventHandler1;
        this._udBuyM.Leave += eventHandler2;
      }
    }

    NumericUpDown udCraft
    {
      get
      {
        return this._udCraft;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udCraft != null)
        {
          this._udCraft.ValueChanged -= eventHandler1;
          this._udCraft.Leave -= eventHandler2;
        }
        this._udCraft = value;
        if (this._udCraft == null)
          return;
        this._udCraft.ValueChanged += eventHandler1;
        this._udCraft.Leave += eventHandler2;
      }
    }

    NumericUpDown udCraftM
    {
      get
      {
        return this._udCraftM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udCraftM != null)
        {
          this._udCraftM.ValueChanged -= eventHandler1;
          this._udCraftM.Leave -= eventHandler2;
        }
        this._udCraftM = value;
        if (this._udCraftM == null)
          return;
        this._udCraftM.ValueChanged += eventHandler1;
        this._udCraftM.Leave += eventHandler2;
      }
    }

    NumericUpDown udLevel
    {
      get
      {
        return this._udLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udCostX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udCostX_Leave);
        if (this._udLevel != null)
        {
          this._udLevel.ValueChanged -= eventHandler1;
          this._udLevel.Leave -= eventHandler2;
        }
        this._udLevel = value;
        if (this._udLevel == null)
          return;
        this._udLevel.ValueChanged += eventHandler1;
        this._udLevel.Leave += eventHandler2;
      }
    }

    NumericUpDown udSal0
    {
      get
      {
        return this._udSal0;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal0 != null)
        {
          this._udSal0.ValueChanged -= eventHandler1;
          this._udSal0.Leave -= eventHandler2;
        }
        this._udSal0 = value;
        if (this._udSal0 == null)
          return;
        this._udSal0.ValueChanged += eventHandler1;
        this._udSal0.Leave += eventHandler2;
      }
    }

    NumericUpDown udSal1
    {
      get
      {
        return this._udSal1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal1 != null)
        {
          this._udSal1.ValueChanged -= eventHandler1;
          this._udSal1.Leave -= eventHandler2;
        }
        this._udSal1 = value;
        if (this._udSal1 == null)
          return;
        this._udSal1.ValueChanged += eventHandler1;
        this._udSal1.Leave += eventHandler2;
      }
    }

    NumericUpDown udSal2
    {
      get
      {
        return this._udSal2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal2 != null)
        {
          this._udSal2.ValueChanged -= eventHandler1;
          this._udSal2.Leave -= eventHandler2;
        }
        this._udSal2 = value;
        if (this._udSal2 == null)
          return;
        this._udSal2.ValueChanged += eventHandler1;
        this._udSal2.Leave += eventHandler2;
      }
    }

    NumericUpDown udSal3
    {
      get
      {
        return this._udSal3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal3 != null)
        {
          this._udSal3.ValueChanged -= eventHandler1;
          this._udSal3.Leave -= eventHandler2;
        }
        this._udSal3 = value;
        if (this._udSal3 == null)
          return;
        this._udSal3.ValueChanged += eventHandler1;
        this._udSal3.Leave += eventHandler2;
      }
    }

    NumericUpDown udSal4
    {
      get
      {
        return this._udSal4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udSalX_ValueChanged);
        EventHandler eventHandler2 = new EventHandler(this.udSalX_Leave);
        if (this._udSal4 != null)
        {
          this._udSal4.ValueChanged -= eventHandler1;
          this._udSal4.Leave -= eventHandler2;
        }
        this._udSal4 = value;
        if (this._udSal4 == null)
          return;
        this._udSal4.ValueChanged += eventHandler1;
        this._udSal4.Leave += eventHandler2;
      }
    }

    public frmRecipeEdit()
    {
      this.Load += new EventHandler(this.frmRecipeEdit_Load);
      this.NoUpdate = true;
      this.InitializeComponent();
    }

    void AddListItem(int Index)

    {
      if (!(Index > -1 & Index < DatabaseAPI.Database.Recipes.Length))
        return;
      this.lvDPA.Items.Add(new ListViewItem(new string[4]
      {
        DatabaseAPI.Database.Recipes[Index].InternalName,
        DatabaseAPI.Database.Recipes[Index].EnhIdx <= -1 ? "None" : DatabaseAPI.Database.Recipes[Index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].EnhIdx) + ")",
        Enum.GetName(DatabaseAPI.Database.Recipes[Index].Rarity.GetType(), (object) DatabaseAPI.Database.Recipes[Index].Rarity),
        Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item.Length)
      }));
    }

    static void AssignNewRecipes()

    {
      int num = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (DatabaseAPI.Database.Recipes[index].EnhIdx > -1 & DatabaseAPI.Database.Recipes[index].EnhIdx <= DatabaseAPI.Database.Enhancements.Length - 1 && DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeIDX < 0)
        {
          DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeIDX = index;
          DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[index].EnhIdx].RecipeName = DatabaseAPI.Database.Recipes[index].InternalName;
        }
      }
    }

    void btnAdd_Click(object sender, EventArgs e)

    {
      if (this.RecipeID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array) new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry();
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = 9;
      this.ShowRecipeInfo(this.RecipeID());
      this.UpdateListItem(this.RecipeID());
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      DatabaseAPI.LoadRecipes();
      this.Close();
    }

    void btnDel_Click(object sender, EventArgs e)

    {
      if (this.RecipeID() < 0 || this.lstItems.SelectedIndex < 0)
        return;
      int selectedIndex = this.lstItems.SelectedIndex;
      Recipe.RecipeEntry[] recipeEntryArray = new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2 + 1];
      int index1 = -1;
      int num1 = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          ++index1;
          recipeEntryArray[index1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[index2]);
        }
      }
      DatabaseAPI.Database.Recipes = new Recipe[recipeEntryArray.Length - 1 + 1];
      int num2 = DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
        DatabaseAPI.Database.Recipes[this.RecipeID()].Item[index2] = new Recipe.RecipeEntry(recipeEntryArray[index2]);
      this.ShowRecipeInfo(this.RecipeID());
    }

    void btnGuessCost_Click(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level);
      this.udCraft.Value = new Decimal(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost);
    }

    void btnI20_Click(object sender, EventArgs e)

    {
      this.IncrementX(19);
    }

    void btnI25_Click(object sender, EventArgs e)

    {
      this.IncrementX(24);
    }

    void btnI40_Click(object sender, EventArgs e)

    {
      this.IncrementX(39);
    }

    void btnI50_Click(object sender, EventArgs e)

    {
      this.IncrementX(49);
    }

    void btnImport_Click(object sender, EventArgs e)

    {
      if (Interaction.MsgBox((object) "Really erase all stored recipes and attempt import?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Careful...") != MsgBoxResult.Yes)
        return;
      char[] chArray = new char[1]{ '\r' };
      string[] strArray1 = Clipboard.GetDataObject().GetData("System.String", true).ToString().Split(chArray);
      chArray[0] = '\t';
      DatabaseAPI.Database.Recipes = new Recipe[0];
      int num1 = strArray1.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        string[] strArray2 = strArray1[index1].Split(chArray);
        if (strArray2.Length > 7)
        {
          string iName = strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal) <= 0 ? strArray2[0] : strArray2[0].Substring(0, strArray2[0].Replace("_Memorized", "").LastIndexOf("_", StringComparison.Ordinal));
          if (!char.IsLetterOrDigit(iName[0]))
            iName = iName.Substring(1);
          Recipe recipe1 = DatabaseAPI.GetRecipeByName(iName);
          if (recipe1 == null)
          {
            IDatabase database = DatabaseAPI.Database;
            Recipe[] recipeArray = (Recipe[]) Utils.CopyArray((Array) database.Recipes, (Array) new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
            database.Recipes = recipeArray;
            DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
            recipe1 = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1];
            Recipe recipe2 = recipe1;
            recipe2.InternalName = iName;
            recipe2.ExternalName = !(strArray2[14] == "") ? "" : strArray2[1];
            recipe2.Rarity = (Recipe.RecipeRarity) Math.Round(Conversion.Val(strArray2[15]) - 1.0);
          }
          int index2 = -1;
          Recipe recipe3 = recipe1;
          int num2 = recipe3.Item.Length - 1;
          for (int index3 = 0; index3 <= num2; ++index3)
          {
            if ((double) recipe3.Item[index3].Level == Conversion.Val(strArray2[16]) - 1.0)
              index2 = index3;
          }
          if (index2 < 0)
          {
            recipe3.Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) recipe3.Item, (Array) new Recipe.RecipeEntry[recipe3.Item.Length + 1]);
            recipe3.Item[recipe3.Item.Length - 1] = new Recipe.RecipeEntry();
            index2 = recipe3.Item.Length - 1;
          }
          recipe3.Item[index2].Level = (int) Math.Round(Conversion.Val(strArray2[16]) - 1.0);
          if (strArray2[0].IndexOf("Memorized") > -1)
          {
            recipe3.Item[index2].BuyCostM = (int) Math.Round(Conversion.Val(strArray2[19]) - 1.0);
            recipe3.Item[index2].CraftCostM = (int) Math.Round(Conversion.Val(strArray2[17]) - 1.0);
          }
          else
          {
            recipe3.Item[index2].BuyCost = (int) Math.Round(Conversion.Val(strArray2[19]) - 1.0);
            recipe3.Item[index2].CraftCost = (int) Math.Round(Conversion.Val(strArray2[17]) - 1.0);
          }
          int index4 = 0;
          do
          {
            if (Conversion.Val(strArray2[4 + index4 * 2]) > 0.0)
            {
              recipe3.Item[index2].Count[index4] = (int) Math.Round(Conversion.Val(strArray2[4 + index4 * 2]));
              recipe3.Item[index2].Salvage[index4] = strArray2[5 + index4 * 2];
              recipe3.Item[index2].SalvageIdx[index4] = -1;
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
      int num3 = (int) Interaction.MsgBox((object) "Done. Recipe-Enhancement links have been guessed.", MsgBoxStyle.Information, (object) "Import");
    }

    void btnIncrement_Click(object sender, EventArgs e)

    {
      if (this.RecipeID() < 0 || DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length < 1 | DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length > 53)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array) new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
      ++DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
      this.ShowRecipeInfo(this.RecipeID());
      this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
    }

    void btnOK_Click(object sender, EventArgs e)

    {
      frmRecipeEdit.AssignNewRecipes();
      DatabaseAPI.AssignRecipeSalvageIDs();
      DatabaseAPI.AssignRecipeIDs();
      DatabaseAPI.SaveRecipes();
      DatabaseAPI.SaveEnhancementDb();
      this.Close();
    }

    void btnRAdd_Click(object sender, EventArgs e)

    {
      IDatabase database = DatabaseAPI.Database;
      Recipe[] recipeArray = (Recipe[]) Utils.CopyArray((Array) database.Recipes, (Array) new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
      database.Recipes = recipeArray;
      DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
      this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
      this.cbEnh.Select();
      this.cbEnh.SelectAll();
    }

    void btnRDel_Click(object sender, EventArgs e)

    {
      if (this.RecipeID() < 0)
        return;
      int index1 = this.RecipeID();
      Recipe[] recipeArray = new Recipe[DatabaseAPI.Database.Recipes.Length - 2 + 1];
      int index2 = -1;
      int num1 = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index3 = 0; index3 <= num1; ++index3)
      {
        if (index3 != index1)
        {
          ++index2;
          recipeArray[index2] = new Recipe(ref DatabaseAPI.Database.Recipes[index3]);
        }
      }
      DatabaseAPI.Database.Recipes = new Recipe[recipeArray.Length - 1 + 1];
      int num2 = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index3 = 0; index3 <= num2; ++index3)
        DatabaseAPI.Database.Recipes[index3] = new Recipe(ref recipeArray[index3]);
      this.FillList();
      if (this.lvDPA.Items.Count > index1)
        this.lvDPA.Items[index1].Selected = true;
      else if (this.lvDPA.Items.Count > index1 - 1)
        this.lvDPA.Items[index1 - 1].Selected = true;
      else if (this.lvDPA.Items.Count > 0)
        this.lvDPA.Items[0].Selected = true;
    }

    void btnRunSeq_Click(object sender, EventArgs e)

    {
      int enhIdx = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].EnhIdx;
      int num = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = enhIdx + 1; index <= num; ++index)
      {
        if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO)
        {
          IDatabase database = DatabaseAPI.Database;
          Recipe[] recipeArray = (Recipe[]) Utils.CopyArray((Array) database.Recipes, (Array) new Recipe[DatabaseAPI.Database.Recipes.Length + 1]);
          database.Recipes = recipeArray;
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1] = new Recipe();
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].EnhIdx = index;
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].Enhancement = DatabaseAPI.Database.Enhancements[index].UID;
          DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Recipes.Length - 1].InternalName = DatabaseAPI.Database.Enhancements[index].UID;
          this.AddListItem(DatabaseAPI.Database.Recipes.Length - 1);
        }
      }
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].Selected = true;
      this.lvDPA.Items[this.lvDPA.Items.Count - 1].EnsureVisible();
      this.cbEnh.Select();
      this.cbEnh.SelectAll();
    }

    void Button1_Click(object sender, EventArgs e)

    {
      DatabaseAPI.GuessRecipes();
      DatabaseAPI.AssignRecipeIDs();
    }

    void cbEnh_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() <= -1 || this.cbEnh.SelectedIndex <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].EnhIdx = this.cbEnh.SelectedIndex - 1;
      if (DatabaseAPI.Database.Recipes[this.RecipeID()].EnhIdx > -1)
      {
        DatabaseAPI.Database.Recipes[this.RecipeID()].Enhancement = this.cbEnh.Text;
        DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.cbEnh.Text;
        this.txtRecipeName.Text = this.cbEnh.Text;
        try
        {
          this.lblEnh.Text = DatabaseAPI.Database.Enhancements[DatabaseAPI.Database.Recipes[this.RecipeID()].EnhIdx].LongName;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          this.lblEnh.Text = string.Empty;
          ProjectData.ClearProjectError();
        }
      }
      else
        DatabaseAPI.Database.Recipes[this.RecipeID()].Enhancement = "";
      this.UpdateListItem(this.RecipeID());
    }

    void cbRarity_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() <= -1 || this.cbRarity.SelectedIndex <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Rarity = (Recipe.RecipeRarity) this.cbRarity.SelectedIndex;
      this.UpdateListItem(this.RecipeID());
    }

    void cbSalX_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[0] = this.cbSal0.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[1] = this.cbSal1.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[2] = this.cbSal2.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[3] = this.cbSal3.SelectedIndex - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[4] = this.cbSal4.SelectedIndex - 1;
      if (this.cbSal0.SelectedIndex > 0 & Decimal.Compare(this.udSal0.Value, new Decimal(1)) < 0)
        this.udSal0.Value = new Decimal(1);
      if (this.cbSal1.SelectedIndex > 0 & Decimal.Compare(this.udSal1.Value, new Decimal(1)) < 0)
        this.udSal1.Value = new Decimal(1);
      if (this.cbSal2.SelectedIndex > 0 & Decimal.Compare(this.udSal2.Value, new Decimal(1)) < 0)
        this.udSal2.Value = new Decimal(1);
      if (this.cbSal3.SelectedIndex > 0 & Decimal.Compare(this.udSal3.Value, new Decimal(1)) < 0)
        this.udSal3.Value = new Decimal(1);
      if (this.cbSal4.SelectedIndex > 0 & Decimal.Compare(this.udSal4.Value, new Decimal(1)) < 0)
        this.udSal4.Value = new Decimal(1);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 0);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 1);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 2);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 3);
      this.SetSalvageStringFromIDX(this.RecipeID(), this.EntryID(), 4);
    }

    protected void ClearEntryInfo()
    {
      this.udLevel.Value = new Decimal(1);
      this.udLevel.Enabled = false;
      this.udBuy.Value = new Decimal(1);
      this.udBuy.Enabled = false;
      this.udBuyM.Value = new Decimal(1);
      this.udBuyM.Enabled = false;
      this.udCraft.Value = new Decimal(1);
      this.udCraft.Enabled = false;
      this.udCraftM.Value = new Decimal(1);
      this.udCraftM.Enabled = false;
      this.cbSal0.SelectedIndex = -1;
      this.cbSal0.Enabled = false;
      this.udSal0.Value = new Decimal(0);
      this.udSal0.Enabled = false;
      this.cbSal1.SelectedIndex = -1;
      this.cbSal1.Enabled = false;
      this.udSal1.Value = new Decimal(0);
      this.udSal1.Enabled = false;
      this.cbSal2.SelectedIndex = -1;
      this.cbSal2.Enabled = false;
      this.udSal2.Value = new Decimal(0);
      this.udSal2.Enabled = false;
      this.cbSal3.SelectedIndex = -1;
      this.cbSal3.Enabled = false;
      this.udSal3.Value = new Decimal(0);
      this.udSal3.Enabled = false;
      this.cbSal4.SelectedIndex = -1;
      this.cbSal4.Enabled = false;
      this.udSal4.Value = new Decimal(0);
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

    protected int EntryID()
    {
      return this.RecipeID() <= -1 ? -1 : this.lstItems.SelectedIndex;
    }

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
      this.cbRarity.Items.AddRange((object[]) Enum.GetNames(recipeRarity.GetType()));
      this.cbRarity.EndUpdate();
      this.cbEnh.BeginUpdate();
      this.cbEnh.Items.Clear();
      this.cbEnh.Items.Add((object) "None");
      int num1 = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = 0; index <= num1; ++index)
      {
        if (DatabaseAPI.Database.Enhancements[index].UID != "")
          this.cbEnh.Items.Add((object) DatabaseAPI.Database.Enhancements[index].UID);
        else
          this.cbEnh.Items.Add((object) ("X - " + DatabaseAPI.Database.Enhancements[index].Name));
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
      this.cbSal0.Items.Add((object) "None");
      this.cbSal1.Items.Add((object) "None");
      this.cbSal2.Items.Add((object) "None");
      this.cbSal3.Items.Add((object) "None");
      this.cbSal4.Items.Add((object) "None");
      int num2 = DatabaseAPI.Database.Salvage.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        this.cbSal0.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal1.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal2.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal3.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
        this.cbSal4.Items.Add((object) DatabaseAPI.Database.Salvage[index].ExternalName);
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
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        3600,
        4380,
        5160,
        5940,
        6720,
        7500,
        12900,
        18300,
        23700,
        29100,
        34500,
        35080,
        35660,
        36240,
        36820,
        37400,
        38660,
        39920,
        41180,
        42440,
        43700,
        48200,
        52700,
        57200,
        61700,
        66200,
        73920,
        81640,
        89360,
        97080,
        104800,
        121260,
        137720,
        154180,
        170640,
        187100,
        198720,
        210340,
        221960,
        233580,
        490400,
        513640,
        536880,
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
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) DatabaseAPI.Database.Recipes[this.RecipeID()].Item, (Array) new Recipe.RecipeEntry[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length + 1]);
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1] = new Recipe.RecipeEntry(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 2]);
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level = index;
          DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].CraftCost = this.GetCostByLevel(DatabaseAPI.Database.Recipes[this.RecipeID()].Item[DatabaseAPI.Database.Recipes[this.RecipeID()].Item.Length - 1].Level);
        }
        this.ShowRecipeInfo(this.RecipeID());
        this.lstItems.SelectedIndex = this.lstItems.Items.Count - 1;
      }
    }

    [DebuggerStepThrough]

    void lstItems_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvDPA.SelectedIndices.Count > 0)
        this.ShowEntryInfo(this.lvDPA.SelectedIndices[0], this.lstItems.SelectedIndex);
      else
        this.ClearEntryInfo();
    }

    void lvDPA_SelectedIndexChanged(object sender, EventArgs e)

    {
      if (this.lvDPA.SelectedIndices.Count > 0)
        this.ShowRecipeInfo(this.lvDPA.SelectedIndices[0]);
      else
        this.ClearInfo();
    }

    int MinMax(int iValue, NumericUpDown iControl)

    {
      if (Decimal.Compare(new Decimal(iValue), iControl.Minimum) < 0)
        iValue = Convert.ToInt32(iControl.Minimum);
      if (Decimal.Compare(new Decimal(iValue), iControl.Maximum) > 0)
        iValue = Convert.ToInt32(iControl.Maximum);
      return iValue;
    }

    protected int RecipeID()
    {
      return this.lvDPA.SelectedIndices.Count <= 0 ? -1 : this.lvDPA.SelectedIndices[0];
    }

    public void SetSalvageStringFromIDX(int iRecipe, int iItem, int iIndex)
    {
      if (DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].SalvageIdx[iIndex] > -1)
        DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = DatabaseAPI.Database.Salvage[DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].SalvageIdx[iIndex]].InternalName;
      else
        DatabaseAPI.Database.Recipes[iRecipe].Item[iItem].Salvage[iIndex] = "";
    }

    protected void ShowEntryInfo(int rIDX, int iIDX)
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
        this.udLevel.Value = new Decimal(recipeEntry.Level + 1);
        this.udLevel.Enabled = true;
        this.udBuy.Value = new Decimal(recipeEntry.BuyCost);
        this.udBuy.Enabled = true;
        this.udBuyM.Value = new Decimal(recipeEntry.BuyCostM);
        this.udBuyM.Enabled = true;
        this.udCraft.Value = new Decimal(recipeEntry.CraftCost);
        this.udCraft.Enabled = true;
        this.udCraftM.Value = new Decimal(recipeEntry.CraftCostM);
        this.udCraftM.Enabled = true;
        this.cbSal0.SelectedIndex = recipeEntry.SalvageIdx[0] + 1;
        this.cbSal0.Enabled = true;
        this.udSal0.Value = new Decimal(recipeEntry.Count[0]);
        this.udSal0.Enabled = true;
        this.cbSal1.SelectedIndex = recipeEntry.SalvageIdx[1] + 1;
        this.cbSal1.Enabled = true;
        this.udSal1.Value = new Decimal(recipeEntry.Count[1]);
        this.udSal1.Enabled = true;
        this.cbSal2.SelectedIndex = recipeEntry.SalvageIdx[2] + 1;
        this.cbSal2.Enabled = true;
        this.udSal2.Value = new Decimal(recipeEntry.Count[2]);
        this.udSal2.Enabled = true;
        this.cbSal3.SelectedIndex = recipeEntry.SalvageIdx[3] + 1;
        this.cbSal3.Enabled = true;
        this.udSal3.Value = new Decimal(recipeEntry.Count[3]);
        this.udSal3.Enabled = true;
        this.cbSal4.SelectedIndex = recipeEntry.SalvageIdx[4] + 1;
        this.cbSal4.Enabled = true;
        this.udSal4.Value = new Decimal(recipeEntry.Count[4]);
        this.udSal4.Enabled = true;
        this.NoUpdate = false;
      }
    }

    protected void ShowRecipeInfo(int Index)
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
        this.cbRarity.SelectedIndex = (int) DatabaseAPI.Database.Recipes[Index].Rarity;
        this.txtExtern.Text = DatabaseAPI.Database.Recipes[Index].ExternalName;
        this.lstItems.Items.Clear();
        int num = DatabaseAPI.Database.Recipes[Index].Item.Length - 1;
        for (int index = 0; index <= num; ++index)
          this.lstItems.Items.Add((object) ("Level: " + Conversions.ToString(DatabaseAPI.Database.Recipes[Index].Item[index].Level + 1)));
        if (this.lstItems.Items.Count > 0)
          this.lstItems.SelectedIndex = 0;
        this.NoUpdate = false;
      }
    }

    void txtExtern_TextChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].ExternalName = this.txtExtern.Text;
    }

    void txtRecipeName_TextChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() <= -1)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].InternalName = this.txtRecipeName.Text;
      this.UpdateListItem(this.RecipeID());
    }

    void udCostX_Leave(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level = this.MinMax((int) Math.Round(Conversion.Val(this.udLevel.Text.Replace(",", "").Replace(".", ""))), this.udLevel) - 1;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCost = this.MinMax((int) Math.Round(Conversion.Val(this.udBuy.Text.Replace(",", "").Replace(".", ""))), this.udBuy);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCostM = this.MinMax((int) Math.Round(Conversion.Val(this.udBuyM.Text.Replace(",", "").Replace(".", ""))), this.udBuyM);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = this.MinMax((int) Math.Round(Conversion.Val(this.udCraft.Text.Replace(",", "").Replace(".", ""))), this.udCraft);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCostM = this.MinMax((int) Math.Round(Conversion.Val(this.udCraftM.Text.Replace(",", "").Replace(".", ""))), this.udCraftM);
    }

    void udCostX_ValueChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Level = Convert.ToInt32(Decimal.Subtract(this.udLevel.Value, new Decimal(1)));
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCost = Convert.ToInt32(this.udBuy.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].BuyCostM = Convert.ToInt32(this.udBuyM.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCost = Convert.ToInt32(this.udCraft.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].CraftCostM = Convert.ToInt32(this.udCraftM.Value);
    }

    void udSalX_Leave(object sender, EventArgs e)

    {
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal0.Text)), this.udSal0);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal1.Text)), this.udSal1);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal2.Text)), this.udSal2);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal3.Text)), this.udSal3);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = this.MinMax((int) Math.Round(Conversion.Val(this.udSal4.Text)), this.udSal4);
    }

    void udSalX_ValueChanged(object sender, EventArgs e)

    {
      if (this.NoUpdate || this.RecipeID() < 0 || this.EntryID() < 0)
        return;
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[0] = Convert.ToInt32(this.udSal0.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[1] = Convert.ToInt32(this.udSal1.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[2] = Convert.ToInt32(this.udSal2.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[3] = Convert.ToInt32(this.udSal3.Value);
      DatabaseAPI.Database.Recipes[this.RecipeID()].Item[this.EntryID()].Count[4] = Convert.ToInt32(this.udSal4.Value);
    }

    protected void UpdateListItem(int index)
    {
      if (!(index > -1 & index < DatabaseAPI.Database.Recipes.Length))
        return;
      this.lvDPA.Items[index].SubItems[0].Text = DatabaseAPI.Database.Recipes[index].InternalName;
      this.lvDPA.Items[index].SubItems[1].Text = DatabaseAPI.Database.Recipes[index].EnhIdx <= -1 ? "None" : DatabaseAPI.Database.Recipes[index].Enhancement + " (" + Conversions.ToString(DatabaseAPI.Database.Recipes[index].EnhIdx) + ")";
      this.lvDPA.Items[index].SubItems[2].Text = Enum.GetName(DatabaseAPI.Database.Recipes[index].Rarity.GetType(), (object) DatabaseAPI.Database.Recipes[index].Rarity);
      this.lvDPA.Items[index].SubItems[3].Text = Conversions.ToString(DatabaseAPI.Database.Recipes[index].Item.Length);
    }
  }
}