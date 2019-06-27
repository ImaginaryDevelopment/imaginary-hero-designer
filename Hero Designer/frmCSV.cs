
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
  [DesignerGenerated]
  public class frmCSV : Form
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

    IContainer components;


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
      DatabaseAPI.MatchAllIDs((IMessager) null);
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
        int num = (int) Interaction.MsgBox((object) "Copied to clipboard and saved in StaticIndexes.txt", MsgBoxStyle.OkOnly, (object) null);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) "Copied to clipboard only", MsgBoxStyle.OkOnly, (object) null);
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
    void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmCSV));
      this.GroupBox1 = new GroupBox();
      this.mod_Revision = new Label();
      this.Label4 = new Label();
      this.mod_Import = new Button();
      this.mod_Count = new Label();
      this.mod_Date = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.GroupBox2 = new GroupBox();
      this.at_Revision = new Label();
      this.Label15 = new Label();
      this.at_Import = new Button();
      this.at_Count = new Label();
      this.at_Date = new Label();
      this.Label5 = new Label();
      this.Label6 = new Label();
      this.GroupBox3 = new GroupBox();
      this.set_Revision = new Label();
      this.Label17 = new Label();
      this.set_Import = new Button();
      this.set_Count = new Label();
      this.set_Date = new Label();
      this.Label7 = new Label();
      this.Label8 = new Label();
      this.GroupBox4 = new GroupBox();
      this.pow_Revision = new Label();
      this.Label19 = new Label();
      this.pow_Import = new Button();
      this.pow_Count = new Label();
      this.pow_Date = new Label();
      this.Label9 = new Label();
      this.Label10 = new Label();
      this.GroupBox5 = new GroupBox();
      this.fx_Revision = new Label();
      this.Label21 = new Label();
      this.fx_Import = new Button();
      this.fx_Count = new Label();
      this.fx_Date = new Label();
      this.Label11 = new Label();
      this.Label12 = new Label();
      this.GroupBox6 = new GroupBox();
      this.inventSetImport = new Button();
      this.btnIOLevels = new Button();
      this.btnImportRecipes = new Button();
      this.btnSalvageUpdate = new Button();
      this.invent_Revision = new Label();
      this.btnEnhEffects = new Button();
      this.Label23 = new Label();
      this.btnBonusLookup = new Button();
      this.invent_Import = new Button();
      this.invent_RecipeDate = new Label();
      this.invent_Date = new Label();
      this.Label13 = new Label();
      this.Label14 = new Label();
      this.GroupBox7 = new GroupBox();
      this.lev_Revision = new Label();
      this.Label16 = new Label();
      this.level_import = new Button();
      this.lev_Count = new Label();
      this.lev_date = new Label();
      this.Label22 = new Label();
      this.Label24 = new Label();
      this.GroupBox8 = new GroupBox();
      this.btnEntities = new Button();
      this.btnClearSI = new Button();
      this.btnStaticIndex = new Button();
      this.btnDefiance = new Button();
      this.btnStaticExport = new Button();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.GroupBox5.SuspendLayout();
      this.GroupBox6.SuspendLayout();
      this.GroupBox7.SuspendLayout();
      this.GroupBox8.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.mod_Revision);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.mod_Import);
      this.GroupBox1.Controls.Add((Control) this.mod_Count);
      this.GroupBox1.Controls.Add((Control) this.mod_Date);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      Point point = new Point(12, 12);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      Size size = new Size(257, 115);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Modifier Tables";
      point = new Point(124, 60);
      this.mod_Revision.Location = point;
      this.mod_Revision.Name = "mod_Revision";
      size = new Size(112, 22);
      this.mod_Revision.Size = size;
      this.mod_Revision.TabIndex = 6;
      this.mod_Revision.Text = "000";
      this.mod_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 60);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(112, 22);
      this.Label4.Size = size;
      this.Label4.TabIndex = 5;
      this.Label4.Text = "Revision:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 85);
      this.mod_Import.Location = point;
      this.mod_Import.Name = "mod_Import";
      size = new Size(245, 23);
      this.mod_Import.Size = size;
      this.mod_Import.TabIndex = 4;
      this.mod_Import.Text = "Import New";
      this.mod_Import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.mod_Count.Location = point;
      this.mod_Count.Name = "mod_Count";
      size = new Size(112, 22);
      this.mod_Count.Size = size;
      this.mod_Count.TabIndex = 3;
      this.mod_Count.Text = "000";
      this.mod_Count.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.mod_Date.Location = point;
      this.mod_Date.Name = "mod_Date";
      size = new Size(112, 22);
      this.mod_Date.Size = size;
      this.mod_Date.TabIndex = 2;
      this.mod_Date.Text = "DD/MMM/YYYY";
      this.mod_Date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(112, 22);
      this.Label2.Size = size;
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Table Count:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(112, 22);
      this.Label1.Size = size;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Last Updated:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox2.Controls.Add((Control) this.at_Revision);
      this.GroupBox2.Controls.Add((Control) this.Label15);
      this.GroupBox2.Controls.Add((Control) this.at_Import);
      this.GroupBox2.Controls.Add((Control) this.at_Count);
      this.GroupBox2.Controls.Add((Control) this.at_Date);
      this.GroupBox2.Controls.Add((Control) this.Label5);
      this.GroupBox2.Controls.Add((Control) this.Label6);
      point = new Point(12, 133);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(257, 115);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 1;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Archetype Classes";
      point = new Point(124, 60);
      this.at_Revision.Location = point;
      this.at_Revision.Name = "at_Revision";
      size = new Size(112, 22);
      this.at_Revision.Size = size;
      this.at_Revision.TabIndex = 8;
      this.at_Revision.Text = "000";
      this.at_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 60);
      this.Label15.Location = point;
      this.Label15.Name = "Label15";
      size = new Size(112, 22);
      this.Label15.Size = size;
      this.Label15.TabIndex = 7;
      this.Label15.Text = "Revision:";
      this.Label15.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 85);
      this.at_Import.Location = point;
      this.at_Import.Name = "at_Import";
      size = new Size(245, 23);
      this.at_Import.Size = size;
      this.at_Import.TabIndex = 4;
      this.at_Import.Text = "Import";
      this.at_Import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.at_Count.Location = point;
      this.at_Count.Name = "at_Count";
      size = new Size(112, 22);
      this.at_Count.Size = size;
      this.at_Count.TabIndex = 3;
      this.at_Count.Text = "000";
      this.at_Count.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.at_Date.Location = point;
      this.at_Date.Name = "at_Date";
      size = new Size(112, 22);
      this.at_Date.Size = size;
      this.at_Date.TabIndex = 2;
      this.at_Date.Text = "DD/MMM/YYYY";
      this.at_Date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(112, 22);
      this.Label5.Size = size;
      this.Label5.TabIndex = 1;
      this.Label5.Text = "Record Count:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(112, 22);
      this.Label6.Size = size;
      this.Label6.TabIndex = 0;
      this.Label6.Text = "Last Updated:";
      this.Label6.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox3.Controls.Add((Control) this.set_Revision);
      this.GroupBox3.Controls.Add((Control) this.Label17);
      this.GroupBox3.Controls.Add((Control) this.set_Import);
      this.GroupBox3.Controls.Add((Control) this.set_Count);
      this.GroupBox3.Controls.Add((Control) this.set_Date);
      this.GroupBox3.Controls.Add((Control) this.Label7);
      this.GroupBox3.Controls.Add((Control) this.Label8);
      point = new Point(12, 254);
      this.GroupBox3.Location = point;
      this.GroupBox3.Name = "GroupBox3";
      size = new Size(257, 115);
      this.GroupBox3.Size = size;
      this.GroupBox3.TabIndex = 2;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Power Sets";
      point = new Point(124, 60);
      this.set_Revision.Location = point;
      this.set_Revision.Name = "set_Revision";
      size = new Size(112, 22);
      this.set_Revision.Size = size;
      this.set_Revision.TabIndex = 8;
      this.set_Revision.Text = "000";
      this.set_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 60);
      this.Label17.Location = point;
      this.Label17.Name = "Label17";
      size = new Size(112, 22);
      this.Label17.Size = size;
      this.Label17.TabIndex = 7;
      this.Label17.Text = "Revision:";
      this.Label17.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 85);
      this.set_Import.Location = point;
      this.set_Import.Name = "set_Import";
      size = new Size(245, 23);
      this.set_Import.Size = size;
      this.set_Import.TabIndex = 4;
      this.set_Import.Text = "Import";
      this.set_Import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.set_Count.Location = point;
      this.set_Count.Name = "set_Count";
      size = new Size(112, 22);
      this.set_Count.Size = size;
      this.set_Count.TabIndex = 3;
      this.set_Count.Text = "000";
      this.set_Count.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.set_Date.Location = point;
      this.set_Date.Name = "set_Date";
      size = new Size(112, 22);
      this.set_Date.Size = size;
      this.set_Date.TabIndex = 2;
      this.set_Date.Text = "DD/MMM/YYYY";
      this.set_Date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(112, 22);
      this.Label7.Size = size;
      this.Label7.TabIndex = 1;
      this.Label7.Text = "Record Count:";
      this.Label7.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(112, 22);
      this.Label8.Size = size;
      this.Label8.TabIndex = 0;
      this.Label8.Text = "Last Updated:";
      this.Label8.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox4.Controls.Add((Control) this.pow_Revision);
      this.GroupBox4.Controls.Add((Control) this.Label19);
      this.GroupBox4.Controls.Add((Control) this.pow_Import);
      this.GroupBox4.Controls.Add((Control) this.pow_Count);
      this.GroupBox4.Controls.Add((Control) this.pow_Date);
      this.GroupBox4.Controls.Add((Control) this.Label9);
      this.GroupBox4.Controls.Add((Control) this.Label10);
      point = new Point(275, 12);
      this.GroupBox4.Location = point;
      this.GroupBox4.Name = "GroupBox4";
      size = new Size(257, 115);
      this.GroupBox4.Size = size;
      this.GroupBox4.TabIndex = 3;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Powers";
      point = new Point(124, 60);
      this.pow_Revision.Location = point;
      this.pow_Revision.Name = "pow_Revision";
      size = new Size(112, 22);
      this.pow_Revision.Size = size;
      this.pow_Revision.TabIndex = 8;
      this.pow_Revision.Text = "000";
      this.pow_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 60);
      this.Label19.Location = point;
      this.Label19.Name = "Label19";
      size = new Size(112, 22);
      this.Label19.Size = size;
      this.Label19.TabIndex = 7;
      this.Label19.Text = "Revision:";
      this.Label19.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 85);
      this.pow_Import.Location = point;
      this.pow_Import.Name = "pow_Import";
      size = new Size(245, 23);
      this.pow_Import.Size = size;
      this.pow_Import.TabIndex = 4;
      this.pow_Import.Text = "Import";
      this.pow_Import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.pow_Count.Location = point;
      this.pow_Count.Name = "pow_Count";
      size = new Size(112, 22);
      this.pow_Count.Size = size;
      this.pow_Count.TabIndex = 3;
      this.pow_Count.Text = "000";
      this.pow_Count.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.pow_Date.Location = point;
      this.pow_Date.Name = "pow_Date";
      size = new Size(112, 22);
      this.pow_Date.Size = size;
      this.pow_Date.TabIndex = 2;
      this.pow_Date.Text = "DD/MMM/YYYY";
      this.pow_Date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(112, 22);
      this.Label9.Size = size;
      this.Label9.TabIndex = 1;
      this.Label9.Text = "Record Count:";
      this.Label9.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label10.Location = point;
      this.Label10.Name = "Label10";
      size = new Size(112, 22);
      this.Label10.Size = size;
      this.Label10.TabIndex = 0;
      this.Label10.Text = "Last Updated:";
      this.Label10.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox5.Controls.Add((Control) this.fx_Revision);
      this.GroupBox5.Controls.Add((Control) this.Label21);
      this.GroupBox5.Controls.Add((Control) this.fx_Import);
      this.GroupBox5.Controls.Add((Control) this.fx_Count);
      this.GroupBox5.Controls.Add((Control) this.fx_Date);
      this.GroupBox5.Controls.Add((Control) this.Label11);
      this.GroupBox5.Controls.Add((Control) this.Label12);
      point = new Point(275, 254);
      this.GroupBox5.Location = point;
      this.GroupBox5.Name = "GroupBox5";
      size = new Size(257, 115);
      this.GroupBox5.Size = size;
      this.GroupBox5.TabIndex = 4;
      this.GroupBox5.TabStop = false;
      this.GroupBox5.Text = "Power Effects";
      point = new Point(124, 60);
      this.fx_Revision.Location = point;
      this.fx_Revision.Name = "fx_Revision";
      size = new Size(112, 22);
      this.fx_Revision.Size = size;
      this.fx_Revision.TabIndex = 8;
      this.fx_Revision.Text = "000";
      this.fx_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 60);
      this.Label21.Location = point;
      this.Label21.Name = "Label21";
      size = new Size(112, 22);
      this.Label21.Size = size;
      this.Label21.TabIndex = 7;
      this.Label21.Text = "Revision:";
      this.Label21.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 85);
      this.fx_Import.Location = point;
      this.fx_Import.Name = "fx_Import";
      size = new Size(245, 23);
      this.fx_Import.Size = size;
      this.fx_Import.TabIndex = 4;
      this.fx_Import.Text = "Import";
      this.fx_Import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.fx_Count.Location = point;
      this.fx_Count.Name = "fx_Count";
      size = new Size(112, 22);
      this.fx_Count.Size = size;
      this.fx_Count.TabIndex = 3;
      this.fx_Count.Text = "000";
      this.fx_Count.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.fx_Date.Location = point;
      this.fx_Date.Name = "fx_Date";
      size = new Size(112, 22);
      this.fx_Date.Size = size;
      this.fx_Date.TabIndex = 2;
      this.fx_Date.Text = "DD/MMM/YYYY";
      this.fx_Date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label11.Location = point;
      this.Label11.Name = "Label11";
      size = new Size(112, 22);
      this.Label11.Size = size;
      this.Label11.TabIndex = 1;
      this.Label11.Text = "Record Count:";
      this.Label11.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label12.Location = point;
      this.Label12.Name = "Label12";
      size = new Size(112, 22);
      this.Label12.Size = size;
      this.Label12.TabIndex = 0;
      this.Label12.Text = "Last Updated:";
      this.Label12.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox6.Controls.Add((Control) this.inventSetImport);
      this.GroupBox6.Controls.Add((Control) this.btnIOLevels);
      this.GroupBox6.Controls.Add((Control) this.btnImportRecipes);
      this.GroupBox6.Controls.Add((Control) this.btnSalvageUpdate);
      this.GroupBox6.Controls.Add((Control) this.invent_Revision);
      this.GroupBox6.Controls.Add((Control) this.btnEnhEffects);
      this.GroupBox6.Controls.Add((Control) this.Label23);
      this.GroupBox6.Controls.Add((Control) this.btnBonusLookup);
      this.GroupBox6.Controls.Add((Control) this.invent_Import);
      this.GroupBox6.Controls.Add((Control) this.invent_RecipeDate);
      this.GroupBox6.Controls.Add((Control) this.invent_Date);
      this.GroupBox6.Controls.Add((Control) this.Label13);
      this.GroupBox6.Controls.Add((Control) this.Label14);
      point = new Point(538, 78);
      this.GroupBox6.Location = point;
      this.GroupBox6.Name = "GroupBox6";
      size = new Size(257, 291);
      this.GroupBox6.Size = size;
      this.GroupBox6.TabIndex = 5;
      this.GroupBox6.TabStop = false;
      this.GroupBox6.Text = "Invention Sets";
      point = new Point(6, 93);
      this.inventSetImport.Location = point;
      this.inventSetImport.Name = "inventSetImport";
      size = new Size(245, 23);
      this.inventSetImport.Size = size;
      this.inventSetImport.TabIndex = 12;
      this.inventSetImport.Text = "Import Sets";
      this.inventSetImport.UseVisualStyleBackColor = true;
      point = new Point(6, 206);
      this.btnIOLevels.Location = point;
      this.btnIOLevels.Name = "btnIOLevels";
      size = new Size(245, 23);
      this.btnIOLevels.Size = size;
      this.btnIOLevels.TabIndex = 11;
      this.btnIOLevels.Text = "Compute IO Set Level Ranges";
      this.btnIOLevels.UseVisualStyleBackColor = true;
      point = new Point(6, 148);
      this.btnImportRecipes.Location = point;
      this.btnImportRecipes.Name = "btnImportRecipes";
      size = new Size(245, 23);
      this.btnImportRecipes.Size = size;
      this.btnImportRecipes.TabIndex = 10;
      this.btnImportRecipes.Text = "Import Recipes (Full Import)";
      this.btnImportRecipes.UseVisualStyleBackColor = true;
      point = new Point(9, 263);
      this.btnSalvageUpdate.Location = point;
      this.btnSalvageUpdate.Name = "btnSalvageUpdate";
      size = new Size(245, 23);
      this.btnSalvageUpdate.Size = size;
      this.btnSalvageUpdate.TabIndex = 9;
      this.btnSalvageUpdate.Text = "Update Salvage Requirements";
      this.btnSalvageUpdate.UseVisualStyleBackColor = true;
      point = new Point(124, 60);
      this.invent_Revision.Location = point;
      this.invent_Revision.Name = "invent_Revision";
      size = new Size(112, 22);
      this.invent_Revision.Size = size;
      this.invent_Revision.TabIndex = 8;
      this.invent_Revision.Text = "000";
      this.invent_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(9, 234);
      this.btnEnhEffects.Location = point;
      this.btnEnhEffects.Name = "btnEnhEffects";
      size = new Size(245, 23);
      this.btnEnhEffects.Size = size;
      this.btnEnhEffects.TabIndex = 8;
      this.btnEnhEffects.Text = "Load Enhancement Effects";
      this.btnEnhEffects.UseVisualStyleBackColor = true;
      point = new Point(6, 60);
      this.Label23.Location = point;
      this.Label23.Name = "Label23";
      size = new Size(112, 22);
      this.Label23.Size = size;
      this.Label23.TabIndex = 7;
      this.Label23.Text = "Revision:";
      this.Label23.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 177);
      this.btnBonusLookup.Location = point;
      this.btnBonusLookup.Name = "btnBonusLookup";
      size = new Size(245, 23);
      this.btnBonusLookup.Size = size;
      this.btnBonusLookup.TabIndex = 7;
      this.btnBonusLookup.Text = "Import Set Bonus Assignments";
      this.btnBonusLookup.UseVisualStyleBackColor = true;
      point = new Point(6, 119);
      this.invent_Import.Location = point;
      this.invent_Import.Name = "invent_Import";
      size = new Size(245, 23);
      this.invent_Import.Size = size;
      this.invent_Import.TabIndex = 4;
      this.invent_Import.Text = "Import Power-Set Type Assignments";
      this.invent_Import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.invent_RecipeDate.Location = point;
      this.invent_RecipeDate.Name = "invent_RecipeDate";
      size = new Size(112, 22);
      this.invent_RecipeDate.Size = size;
      this.invent_RecipeDate.TabIndex = 3;
      this.invent_RecipeDate.Text = "000";
      this.invent_RecipeDate.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.invent_Date.Location = point;
      this.invent_Date.Name = "invent_Date";
      size = new Size(112, 22);
      this.invent_Date.Size = size;
      this.invent_Date.TabIndex = 2;
      this.invent_Date.Text = "DD/MMM/YYYY";
      this.invent_Date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label13.Location = point;
      this.Label13.Name = "Label13";
      size = new Size(112, 22);
      this.Label13.Size = size;
      this.Label13.TabIndex = 1;
      this.Label13.Text = "Recipe Date:";
      this.Label13.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label14.Location = point;
      this.Label14.Name = "Label14";
      size = new Size(112, 22);
      this.Label14.Size = size;
      this.Label14.TabIndex = 0;
      this.Label14.Text = "Set-Power Date:";
      this.Label14.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox7.Controls.Add((Control) this.lev_Revision);
      this.GroupBox7.Controls.Add((Control) this.Label16);
      this.GroupBox7.Controls.Add((Control) this.level_import);
      this.GroupBox7.Controls.Add((Control) this.lev_Count);
      this.GroupBox7.Controls.Add((Control) this.lev_date);
      this.GroupBox7.Controls.Add((Control) this.Label22);
      this.GroupBox7.Controls.Add((Control) this.Label24);
      point = new Point(275, 133);
      this.GroupBox7.Location = point;
      this.GroupBox7.Name = "GroupBox7";
      size = new Size(257, 115);
      this.GroupBox7.Size = size;
      this.GroupBox7.TabIndex = 6;
      this.GroupBox7.TabStop = false;
      this.GroupBox7.Text = "Power Levels";
      point = new Point(124, 60);
      this.lev_Revision.Location = point;
      this.lev_Revision.Name = "lev_Revision";
      size = new Size(112, 22);
      this.lev_Revision.Size = size;
      this.lev_Revision.TabIndex = 8;
      this.lev_Revision.Text = "000";
      this.lev_Revision.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 60);
      this.Label16.Location = point;
      this.Label16.Name = "Label16";
      size = new Size(112, 22);
      this.Label16.Size = size;
      this.Label16.TabIndex = 7;
      this.Label16.Text = "Revision:";
      this.Label16.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 85);
      this.level_import.Location = point;
      this.level_import.Name = "level_import";
      size = new Size(245, 23);
      this.level_import.Size = size;
      this.level_import.TabIndex = 4;
      this.level_import.Text = "Import";
      this.level_import.UseVisualStyleBackColor = true;
      point = new Point(124, 38);
      this.lev_Count.Location = point;
      this.lev_Count.Name = "lev_Count";
      size = new Size(112, 22);
      this.lev_Count.Size = size;
      this.lev_Count.TabIndex = 3;
      this.lev_Count.Text = "000";
      this.lev_Count.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(124, 16);
      this.lev_date.Location = point;
      this.lev_date.Name = "lev_date";
      size = new Size(112, 22);
      this.lev_date.Size = size;
      this.lev_date.TabIndex = 2;
      this.lev_date.Text = "DD/MMM/YYYY";
      this.lev_date.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(6, 38);
      this.Label22.Location = point;
      this.Label22.Name = "Label22";
      size = new Size(112, 22);
      this.Label22.Size = size;
      this.Label22.TabIndex = 1;
      this.Label22.Text = "Record Count:";
      this.Label22.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(6, 16);
      this.Label24.Location = point;
      this.Label24.Name = "Label24";
      size = new Size(112, 22);
      this.Label24.Size = size;
      this.Label24.TabIndex = 0;
      this.Label24.Text = "Last Updated:";
      this.Label24.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox8.Controls.Add((Control) this.btnEntities);
      point = new Point(538, 12);
      this.GroupBox8.Location = point;
      this.GroupBox8.Name = "GroupBox8";
      size = new Size(257, 60);
      this.GroupBox8.Size = size;
      this.GroupBox8.TabIndex = 9;
      this.GroupBox8.TabStop = false;
      this.GroupBox8.Text = "Entities";
      point = new Point(6, 19);
      this.btnEntities.Location = point;
      this.btnEntities.Name = "btnEntities";
      size = new Size(245, 23);
      this.btnEntities.Size = size;
      this.btnEntities.TabIndex = 4;
      this.btnEntities.Text = "Import";
      this.btnEntities.UseVisualStyleBackColor = true;
      this.btnClearSI.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnClearSI.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnClearSI.ForeColor = SystemColors.ControlText;
      point = new Point(18, 374);
      this.btnClearSI.Location = point;
      this.btnClearSI.Name = "btnClearSI";
      size = new Size(245, 24);
      this.btnClearSI.Size = size;
      this.btnClearSI.TabIndex = 22;
      this.btnClearSI.Text = "Clear StaticIndex Values";
      this.btnClearSI.UseVisualStyleBackColor = true;
      this.btnStaticIndex.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnStaticIndex.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnStaticIndex.ForeColor = SystemColors.ControlText;
      point = new Point(18, 404);
      this.btnStaticIndex.Location = point;
      this.btnStaticIndex.Name = "btnStaticIndex";
      size = new Size(245, 24);
      this.btnStaticIndex.Size = size;
      this.btnStaticIndex.TabIndex = 21;
      this.btnStaticIndex.Text = "Assign StaticIndex Values";
      this.btnStaticIndex.UseVisualStyleBackColor = true;
      this.btnDefiance.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      this.btnDefiance.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnDefiance.ForeColor = SystemColors.ControlText;
      point = new Point(18, 434);
      this.btnDefiance.Location = point;
      this.btnDefiance.Name = "btnDefiance";
      size = new Size(245, 24);
      this.btnDefiance.Size = size;
      this.btnDefiance.TabIndex = 23;
      this.btnDefiance.Text = "Scan and Tag Blaster Defiance Effects";
      this.btnDefiance.UseVisualStyleBackColor = true;
      point = new Point(281, 375);
      this.btnStaticExport.Location = point;
      this.btnStaticExport.Name = "btnStaticExport";
      size = new Size(245, 23);
      this.btnStaticExport.Size = size;
      this.btnStaticExport.TabIndex = 24;
      this.btnStaticExport.Text = "Export StaticIndex values";
      this.btnStaticExport.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size = new Size(815, 562);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnStaticExport);
      this.Controls.Add((Control) this.btnDefiance);
      this.Controls.Add((Control) this.btnClearSI);
      this.Controls.Add((Control) this.btnStaticIndex);
      this.Controls.Add((Control) this.GroupBox8);
      this.Controls.Add((Control) this.GroupBox7);
      this.Controls.Add((Control) this.GroupBox6);
      this.Controls.Add((Control) this.GroupBox5);
      this.Controls.Add((Control) this.GroupBox4);
      this.Controls.Add((Control) this.GroupBox3);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmCSV);
      this.ShowInTaskbar = false;
      this.Text = "Data Import Hub";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.GroupBox5.ResumeLayout(false);
      this.GroupBox6.ResumeLayout(false);
      this.GroupBox7.ResumeLayout(false);
      this.GroupBox8.ResumeLayout(false);
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.at_Import.Click += at_Import_Click;
                  this.btnBonusLookup.Click += btnBonusLookup_Click;
                  this.btnClearSI.Click += btnClearSI_Click;
                  this.btnDefiance.Click += btnDefiance_Click;
                  this.btnEnhEffects.Click += btnEnhEffects_Click;
                  this.btnEntities.Click += btnEntities_Click;
                  this.btnIOLevels.Click += btnIOLevels_Click;
                  this.btnImportRecipes.Click += btnImportRecipes_Click;
                  this.btnSalvageUpdate.Click += btnSalvageUpdate_Click;
                  this.btnStaticIndex.Click += Button2_Click;
                  this.fx_Import.Click += fx_Import_Click;
                  this.inventSetImport.Click += inventSetImport_Click;
                  this.invent_Import.Click += invent_Import_Click;
                  this.level_import.Click += level_import_Click;
                  this.mod_Import.Click += mod_Import_Click;
                  this.pow_Import.Click += pow_Import_Click;
                  this.set_Import.Click += set_Import_Click;
              }
              // finished with events
      this.ResumeLayout(false);
    }

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
