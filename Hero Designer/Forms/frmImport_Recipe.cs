
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmImport_Recipe : Form
  {
        Button btnAttribIndex;

        Button btnAttribLoad;

        Button btnAttribTable;

        Button Button1;
        OpenFileDialog dlgBrowse;
        Label Label3;
        Label Label4;
        Label lblAttribDate;
        Label lblAttribIndex;
        Label lblAttribTableCount;
        Label lblAttribTables;

    frmBusy bFrm;

    IContainer components;








    public frmImport_Recipe()
    {
      this.Load += new EventHandler(this.frmImport_Recipe_Load);
      this.InitializeComponent();
    }

    void btnAttribIndex_Click(object sender, EventArgs e)

    {
      this.dlgBrowse.FileName = this.lblAttribIndex.Text;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.lblAttribIndex.Text = this.dlgBrowse.FileName;
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
          int num1 = (int) Interaction.MsgBox((object) "Files cannot be found!", MsgBoxStyle.Exclamation, (object) "No Can Do");
        }
      }
      else
      {
        int num2 = (int) Interaction.MsgBox((object) "Files not selected!", MsgBoxStyle.Exclamation, (object) "No Can Do");
      }
    }

    void btnAttribTable_Click(object sender, EventArgs e)

    {
      this.dlgBrowse.FileName = this.lblAttribTables.Text;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) != DialogResult.OK)
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
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Recipe CSVs Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
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
              this.BusyMsg(Strings.Format((object) num1, "###,##0") + " Recipes Created.");
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
              int num6 = (int) Math.Round(Conversion.Val(array[10]));
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
                recipe2.ExternalName = !(array[1] != "") ? iName : array[1];
                recipe2.Rarity = (Recipe.RecipeRarity) Math.Round(Conversion.Val(array[9]) - 1.0);
              }
              int index1 = -1;
              Recipe recipe3 = recipe1;
              int num7 = recipe3.Item.Length - 1;
              for (int index2 = 0; index2 <= num7; ++index2)
              {
                if (recipe3.Item[index2].Level == num6 - 1)
                  index1 = index2;
              }
              if (index1 < 0)
              {
                index1 = recipe3.Item.Length;
                recipe3.Item = (Recipe.RecipeEntry[]) Utils.CopyArray((Array) recipe3.Item, (Array) new Recipe.RecipeEntry[index1 + 1]);
                recipe3.Item[index1] = new Recipe.RecipeEntry();
              }
              recipe3.Item[index1].Level = num6 - 1;
              if (flag)
              {
                recipe3.Item[index1].BuyCostM = (int) Math.Round(Conversion.Val(array[15]));
                recipe3.Item[index1].CraftCostM = (int) Math.Round(Conversion.Val(array[11]));
              }
              else
              {
                recipe3.Item[index1].BuyCost = (int) Math.Round(Conversion.Val(array[15]));
                recipe3.Item[index1].CraftCost = (int) Math.Round(Conversion.Val(array[11]));
              }
              if (array[7].Length > 0)
              {
                int index2 = DatabaseAPI.NidFromUidEnhExtended(array[7]);
                if (index2 > -1)
                {
                  recipe3.Enhancement = DatabaseAPI.Database.Enhancements[index2].UID;
                  DatabaseAPI.Database.Enhancements[index2].RecipeName = recipe3.InternalName;
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
              this.BusyMsg(Strings.Format((object) num5, "###,##0") + " Recipes Created.");
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
                num6 = (int) Math.Round(Conversion.Val(iName.Substring(iName.LastIndexOf("_", StringComparison.Ordinal) + 1)));
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
                      recipe.Item[index1].Count[index2] = (int) Math.Round(Conversion.Val(array[1]));
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
        int num9 = (int) Interaction.MsgBox((object) "Done. Recipe-Enhancement links have been guessed.", MsgBoxStyle.Information, (object) "Import");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        iStream1.Close();
        iStream2.Close();
        this.BusyHide();
        int num6 = (int) Interaction.MsgBox((object) exception.Message, MsgBoxStyle.Critical, (object) "CSV Parse Error");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      this.BusyHide();
      iStream2.Close();
      int num10 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num5) + "\r\nGood: " + Conversions.ToString(num2) + "\r\nRejected: " + Conversions.ToString(num3)), MsgBoxStyle.Information, (object) "File Parsed");
      DatabaseAPI.SaveRecipes();
      DatabaseAPI.SaveEnhancementDb();
      return true;
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_Recipe));
      this.Button1 = new Button();
      this.lblAttribTableCount = new Label();
      this.lblAttribDate = new Label();
      this.lblAttribTables = new Label();
      this.btnAttribLoad = new Button();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.lblAttribIndex = new Label();
      this.btnAttribTable = new Button();
      this.btnAttribIndex = new Button();
      this.dlgBrowse = new OpenFileDialog();
      this.SuspendLayout();

      this.Button1.Location = new Point(539, 197);
      this.Button1.Name = "Button1";

      this.Button1.Size = new Size(86, 23);
      this.Button1.TabIndex = 34;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;

      this.lblAttribTableCount.Location = new Point(208, 159);
      this.lblAttribTableCount.Name = "lblAttribTableCount";

      this.lblAttribTableCount.Size = new Size(132, 18);
      this.lblAttribTableCount.TabIndex = 33;
      this.lblAttribTableCount.Text = "Recipes:";

      this.lblAttribDate.Location = new Point(9, 159);
      this.lblAttribDate.Name = "lblAttribDate";

      this.lblAttribDate.Size = new Size(175, 18);
      this.lblAttribDate.TabIndex = 32;
      this.lblAttribDate.Text = "Date:";
      this.lblAttribTables.BorderStyle = BorderStyle.Fixed3D;

      this.lblAttribTables.Location = new Point(12, 99);
      this.lblAttribTables.Name = "lblAttribTables";

      this.lblAttribTables.Size = new Size(521, 46);
      this.lblAttribTables.TabIndex = 27;
      this.lblAttribTables.TextAlign = ContentAlignment.MiddleLeft;

      this.btnAttribLoad.Location = new Point(539, 154);
      this.btnAttribLoad.Name = "btnAttribLoad";

      this.btnAttribLoad.Size = new Size(86, 23);
      this.btnAttribLoad.TabIndex = 25;
      this.btnAttribLoad.Text = "Import";
      this.btnAttribLoad.UseVisualStyleBackColor = true;

      this.Label4.Location = new Point(12, 83);
      this.Label4.Name = "Label4";

      this.Label4.Size = new Size(150, 14);
      this.Label4.TabIndex = 29;
      this.Label4.Text = "Ingredients (baserecipes2)";

      this.Label3.Location = new Point(12, 9);
      this.Label3.Name = "Label3";

      this.Label3.Size = new Size(150, 14);
      this.Label3.TabIndex = 28;
      this.Label3.Text = "Detail (baserecipes)";
      this.lblAttribIndex.BorderStyle = BorderStyle.Fixed3D;

      this.lblAttribIndex.Location = new Point(12, 25);
      this.lblAttribIndex.Name = "lblAttribIndex";

      this.lblAttribIndex.Size = new Size(521, 46);
      this.lblAttribIndex.TabIndex = 26;
      this.lblAttribIndex.TextAlign = ContentAlignment.MiddleLeft;

      this.btnAttribTable.Location = new Point(539, 99);
      this.btnAttribTable.Name = "btnAttribTable";

      this.btnAttribTable.Size = new Size(86, 23);
      this.btnAttribTable.TabIndex = 24;
      this.btnAttribTable.Text = "Browse";
      this.btnAttribTable.UseVisualStyleBackColor = true;

      this.btnAttribIndex.Location = new Point(539, 25);
      this.btnAttribIndex.Name = "btnAttribIndex";

      this.btnAttribIndex.Size = new Size(86, 23);
      this.btnAttribIndex.TabIndex = 23;
      this.btnAttribIndex.Text = "Browse...";
      this.btnAttribIndex.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;

      this.ClientSize = new Size(640, 238);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.lblAttribTableCount);
      this.Controls.Add((Control) this.lblAttribDate);
      this.Controls.Add((Control) this.lblAttribTables);
      this.Controls.Add((Control) this.btnAttribLoad);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.lblAttribIndex);
      this.Controls.Add((Control) this.btnAttribTable);
      this.Controls.Add((Control) this.btnAttribIndex);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmImport_Recipe);
      this.Text = "Import Recipes";
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.Button1.Click += Button1_Click;
                  this.btnAttribIndex.Click += btnAttribIndex_Click;
                  this.btnAttribLoad.Click += btnAttribLoad_Click;
                  this.btnAttribTable.Click += btnAttribTable_Click;
              }
              // finished with events
      this.ResumeLayout(false);
    }
  }
}
