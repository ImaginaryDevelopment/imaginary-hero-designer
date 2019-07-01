
using Base.Data_Classes;
using Base.IO_Classes;
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
  public partial class frmCSV : Form
  {
        Label at_Count;
        Label at_Date;

        Button at_Import;
        Label at_Revision;

        Button btnBonusLookup;

        Button btnClearSI;

        Button btnDefiance;

        Button btnEnhEffects;

        Button btnEntities;

        Button btnImportRecipes;

        Button btnIOLevels;

        Button btnSalvageUpdate;

    [AccessedThroughProperty("btnStaticExport")]
    Button _btnStaticExport;

        Button btnStaticIndex;
        Label fx_Count;
        Label fx_Date;

        Button fx_Import;
        Label fx_Revision;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        GroupBox GroupBox4;
        GroupBox GroupBox5;
        GroupBox GroupBox6;
        GroupBox GroupBox7;
        GroupBox GroupBox8;
        Label invent_Date;

        Button invent_Import;
        Label invent_RecipeDate;
        Label invent_Revision;

        Button inventSetImport;
        Label Label1;
        Label Label10;
        Label Label11;
        Label Label12;
        Label Label13;
        Label Label14;
        Label Label15;
        Label Label16;
        Label Label17;
        Label Label19;
        Label Label2;
        Label Label21;
        Label Label22;
        Label Label23;
        Label Label24;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label Label9;
        Label lev_Count;
        Label lev_date;
        Label lev_Revision;

        Button level_import;
        Label mod_Count;
        Label mod_Date;

        Button mod_Import;
        Label mod_Revision;
        Label pow_Count;
        Label pow_Date;

        Button pow_Import;
        Label pow_Revision;
        Label set_Count;
        Label set_Date;

        Button set_Import;
        Label set_Revision;

    frmBusy bFrm;

    Button btnStaticExport
    {
      get
      {
        return this._btnStaticExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(frmCSV.btnStaticExport_Click);
        if (this._btnStaticExport != null)
          this._btnStaticExport.Click -= eventHandler;
        this._btnStaticExport = value;
        if (this._btnStaticExport == null)
          return;
        this._btnStaticExport.Click += eventHandler;
      }
    }








































    public frmCSV()
    {
      this.Load += new EventHandler(this.frmCSV_Load);
      this.InitializeComponent();
    }

    void at_Import_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_Archetype().ShowDialog();
      this.DisplayInfo();
    }

    void btnBonusLookup_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_SetBonusAssignment().ShowDialog();
      this.DisplayInfo();
    }

    void btnClearSI_Click(object sender, EventArgs e)

    {
      if (Interaction.MsgBox((object) "Really set all StaticIndex values to -1?\r\nIf not using qualified names for Save/Load, files will be unopenable until Statics are re-indexed. Full Re-Indexing may result in changed index assignments.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Are you sure?") == MsgBoxResult.No)
        return;
      int num1 = DatabaseAPI.Database.Power.Length - 1;
      for (int index = 0; index <= num1; ++index)
        DatabaseAPI.Database.Power[index].StaticIndex = -1;
      int num2 = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = 0; index <= num2; ++index)
        DatabaseAPI.Database.Enhancements[index].StaticIndex = -1;
      int num3 = (int) Interaction.MsgBox((object) "Static Index values cleared.", MsgBoxStyle.Information, (object) "De-Indexing Complete");
    }

    void btnDefiance_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Working...");
      int num1 = DatabaseAPI.Database.Powersets.Length - 1;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        if (string.Equals(DatabaseAPI.Database.Powersets[index1].ATClass, "CLASS_BLASTER", StringComparison.OrdinalIgnoreCase))
        {
          int num2 = DatabaseAPI.Database.Powersets[index1].Powers.Length - 1;
          for (int index2 = 0; index2 <= num2; ++index2)
          {
            int num3 = DatabaseAPI.Database.Powersets[index1].Powers[index2].Effects.Length - 1;
            for (int index3 = 0; index3 <= num3; ++index3)
            {
              IEffect effect = DatabaseAPI.Database.Powersets[index1].Powers[index2].Effects[index3];
              if (effect.EffectType == Enums.eEffectType.DamageBuff && (double) effect.Mag < 0.4 & (double) effect.Mag > 0.0 & effect.ToWho == Enums.eToWho.Self & effect.SpecialCase == Enums.eSpecialCase.None)
                effect.SpecialCase = Enums.eSpecialCase.Defiance;
            }
          }
        }
      }
      this.BusyMsg("Re-Indexing && Saving...");
      DatabaseAPI.MatchAllIDs(null);
      DatabaseAPI.SaveMainDatabase();
      this.BusyHide();
    }

    void btnEnhEffects_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_EnhancementEffects().ShowDialog();
      this.DisplayInfo();
    }

    void btnEntities_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_Entities().ShowDialog();
      this.DisplayInfo();
    }

    void btnImportRecipes_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_Recipe().ShowDialog();
      this.DisplayInfo();
    }

    void btnIOLevels_Click(object sender, EventArgs e)

    {
      this.BusyMsg("Working...");
      frmCSV.SetEnhancementLevels();
      this.BusyMsg("Saving...");
      DatabaseAPI.SaveEnhancementDb();
      this.BusyHide();
    }

    void btnSalvageUpdate_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_SalvageReq().ShowDialog();
      this.DisplayInfo();
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    static void btnStaticExport_Click(object sender, EventArgs e)

    {
      string str1 = "Static Indexes, App version " + Base.Master_Classes.MidsContext.AppVersion + ", database version " + Conversions.ToString(DatabaseAPI.Database.Version) + ":\r\n";
      foreach (Power power in DatabaseAPI.Database.Power)
      {
        if (power.PowerSet.SetType != Enums.ePowerSetType.Boost)
        {
          string str2 = Conversions.ToString(power.StaticIndex) + "\t" + power.FullName + "\r\n";
          str1 += str2;
        }
      }
      string text = str1 + "Enhancements\r\n";
      foreach (Enhancement enhancement in DatabaseAPI.Database.Enhancements)
      {
        string str2;
        if (enhancement.Power != null)
          str2 = Conversions.ToString(enhancement.StaticIndex) + "\t" + enhancement.Power.FullName + "\r\n";
        else
          str2 = "THIS ONE IS NULL  " + Conversions.ToString(enhancement.StaticIndex) + "\t" + enhancement.Name + "\r\n";
        text += str2;
      }
      Clipboard.SetText(text);
      try
      {
        int FileNumber = FileSystem.FreeFile();
        FileSystem.FileOpen(FileNumber, "StaticIndexes.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
        FileSystem.WriteLine(FileNumber, (object) text);
        FileSystem.FileClose(FileNumber);
        int num = (int) Interaction.MsgBox((object) "Copied to clipboard and saved in StaticIndexes.txt", MsgBoxStyle.OkOnly, null);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) "Copied to clipboard only", MsgBoxStyle.OkOnly, null);
        ProjectData.ClearProjectError();
      }
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

    void Button2_Click(object sender, EventArgs e)
    {
      DatabaseAPI.AssignStaticIndexValues();
      int num = (int) Interaction.MsgBox((object) "Static Index values assigned.", MsgBoxStyle.Information, (object) "Indexing Complete");
    }

    void DisplayInfo()
    {
      this.mod_Date.Text = Strings.Format((object) DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.mod_Revision.Text = Conversions.ToString(DatabaseAPI.Database.AttribMods.Revision);
      this.mod_Count.Text = Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
      this.at_Date.Text = Strings.Format((object) DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.at_Revision.Text = Conversions.ToString(DatabaseAPI.Database.ArchetypeVersion.Revision);
      this.at_Count.Text = Conversions.ToString(DatabaseAPI.Database.Classes.Length);
      this.set_Date.Text = Strings.Format((object) DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.set_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowersetVersion.Revision);
      this.set_Count.Text = Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
      this.pow_Date.Text = Strings.Format((object) DatabaseAPI.Database.PowerVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.pow_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerVersion.Revision);
      this.pow_Count.Text = Conversions.ToString(DatabaseAPI.Database.Power.Length);
      this.lev_date.Text = Strings.Format((object) DatabaseAPI.Database.PowerLevelVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.lev_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerLevelVersion.Revision);
      this.lev_Count.Text = Conversions.ToString(DatabaseAPI.Database.Power.Length);
      this.fx_Date.Text = Strings.Format((object) DatabaseAPI.Database.PowerEffectVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.fx_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerEffectVersion.Revision);
      this.fx_Count.Text = "Many Lots";
      this.invent_Date.Text = Strings.Format((object) DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.invent_Revision.Text = Conversions.ToString(DatabaseAPI.Database.IOAssignmentVersion.Revision);
      this.invent_RecipeDate.Text = Strings.Format((object) DatabaseAPI.Database.RecipeRevisionDate, "dd/MMM/yy HH:mm:ss");
    }

    void frmCSV_Load(object sender, EventArgs e)
    {
      this.DisplayInfo();
    }

    void fx_Import_Click(object sender, EventArgs e)
    {
      int num = (int) new frmImportEffects().ShowDialog();
      this.DisplayInfo();
    }

    [DebuggerStepThrough]

    void invent_Import_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_SetAssignments().ShowDialog();
      this.DisplayInfo();
    }

    void inventSetImport_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImportEnhSets().ShowDialog();
      this.DisplayInfo();
    }

    void level_import_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImportPowerLevels().ShowDialog();
      this.DisplayInfo();
    }

    void mod_Import_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_mod().ShowDialog();
      this.DisplayInfo();
    }

    void pow_Import_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_Power().ShowDialog();
      this.DisplayInfo();
    }

    void set_Import_Click(object sender, EventArgs e)

    {
      int num = (int) new frmImport_Powerset().ShowDialog();
      this.DisplayInfo();
    }

    static void SetEnhancementLevels()

    {
      int num = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO && DatabaseAPI.Database.Enhancements[index].RecipeIDX > -1 && DatabaseAPI.Database.Recipes.Length > DatabaseAPI.Database.Enhancements[index].RecipeIDX && DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item.Length > 0)
        {
          DatabaseAPI.Database.Enhancements[index].LevelMin = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item[0].Level;
          DatabaseAPI.Database.Enhancements[index].LevelMax = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item[DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item.Length - 1].Level;
          if (DatabaseAPI.Database.Enhancements[index].nIDSet > -1)
          {
            DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].LevelMin = DatabaseAPI.Database.Enhancements[index].LevelMin;
            DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].LevelMax = DatabaseAPI.Database.Enhancements[index].LevelMax;
          }
        }
      }
    }
  }
}