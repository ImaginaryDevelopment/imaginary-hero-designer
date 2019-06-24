
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
  public class frmImport_SetBonusAssignment : Form
  {
        Button btnClose;

        Button btnFile;

        Button btnImport;
        OpenFileDialog dlgBrowse;
        Label lblFile;

    frmBusy bFrm;

    IContainer components;

    string FullFileName;



    public frmImport_SetBonusAssignment()
    {
      this.Load += new EventHandler(this.frmImport_SetBonusAssignment_Load);
      this.FullFileName = "";
      this.InitializeComponent();
    }

    void btnClose_Click(object sender, EventArgs e)

    {
      this.Close();
    }

    void btnFile_Click(object sender, EventArgs e)

    {
      this.dlgBrowse.FileName = this.FullFileName;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.FullFileName = this.dlgBrowse.FileName;
      this.BusyHide();
      this.DisplayInfo();
    }

    void btnImport_Click(object sender, EventArgs e)

    {
      this.ParseClasses(this.FullFileName);
      this.BusyHide();
      this.DisplayInfo();
    }

    void BusyHide()

    {
      if (this.bFrm == null)
        return;
      this.bFrm.Close();
      this.bFrm = (frmBusy) null;
    }

    void BusyMsg(string sMessage)

    {
      if (this.bFrm == null)
      {
        this.bFrm = new frmBusy();
        this.bFrm.Show((IWin32Window) this);
      }
      this.bFrm.SetMessage(sMessage);
    }

    public void DisplayInfo()
    {
      this.lblFile.Text = FileIO.StripPath(this.FullFileName);
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

    void frmImport_SetBonusAssignment_Load(object sender, EventArgs e)

    {
      this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile.Replace("powersets2", "boostsets4");
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_SetBonusAssignment));
      this.btnClose = new Button();
      this.btnImport = new Button();
      this.lblFile = new Label();
      this.btnFile = new Button();
      this.dlgBrowse = new OpenFileDialog();
      this.SuspendLayout();
      Point point = new Point(539, 81);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      Size size = new Size(86, 23);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 52;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      point = new Point(539, 38);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(86, 23);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 50;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.lblFile.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 9);
      this.lblFile.Location = point;
      this.lblFile.Name = "lblFile";
      size = new Size(521, 46);
      this.lblFile.Size = size;
      this.lblFile.TabIndex = 51;
      this.lblFile.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 9);
      this.btnFile.Location = point;
      this.btnFile.Name = "btnFile";
      size = new Size(86, 23);
      this.btnFile.Size = size;
      this.btnFile.TabIndex = 49;
      this.btnFile.Text = "Browse...";
      this.btnFile.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size = new Size(640, 114);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.lblFile);
      this.Controls.Add((Control) this.btnFile);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_SetBonusAssignment);
      this.ShowInTaskbar = false;
      this.Text = "Import Set Bonus Assignments";
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnClose.Click += btnClose_Click;
                  this.btnFile.Click += btnFile_Click;
                  this.btnImport.Click += btnImport_Click;
              }
              // finished with events
      this.ResumeLayout(false);
    }

    bool ParseClasses(string iFileName)

    {
      int num1 = 0;
      StreamReader iStream;
      try
      {
        iStream = new StreamReader(iFileName);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Bonus CSV Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = DatabaseAPI.Database.EnhancementSets.Count - 1;
      for (int index1 = 0; index1 <= num6; ++index1)
      {
        DatabaseAPI.Database.EnhancementSets[index1].Bonus = new EnhancementSet.BonusItem[0];
        DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus = new EnhancementSet.BonusItem[6];
        int num2 = DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus.Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus[index2] = new EnhancementSet.BonusItem();
          DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus[index2].Name = new string[0];
          DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus[index2].Index = new int[0];
          DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus[index2].AltString = "";
          DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus[index2].Special = -1;
        }
      }
      try
      {
        string iLine;
        do
        {
          iLine = FileIO.ReadLineUnlimited(iStream, char.MinValue);
          if (iLine != null && !iLine.StartsWith("#"))
          {
            ++num5;
            if (num5 >= 9)
            {
              this.BusyMsg(Strings.Format((object) num3, "###,##0") + " records parsed.");
              num5 = 0;
            }
            string[] array = CSV.ToArray(iLine);
            int index1 = DatabaseAPI.NidFromUidioSet(array[0]);
            if (index1 > -1)
            {
              int integer = Conversions.ToInteger(array[1]);
              string[] strArray1 = array[3].Split(" ".ToCharArray());
              Enums.ePvX ePvX = Enums.ePvX.Any;
              if (array[2].Contains("isPVPMap?"))
              {
                ePvX = Enums.ePvX.PvP;
                array[2] = array[2].Replace("isPVPMap?", "").Replace("  ", " ");
              }
              string[] strArray2 = array[2].Split(" ".ToCharArray());
              if (array[2] == "")
              {
                DatabaseAPI.Database.EnhancementSets[index1].Bonus = (EnhancementSet.BonusItem[]) Utils.CopyArray((Array) DatabaseAPI.Database.EnhancementSets[index1].Bonus, (Array) new EnhancementSet.BonusItem[DatabaseAPI.Database.EnhancementSets[index1].Bonus.Length + 1]);
                DatabaseAPI.Database.EnhancementSets[index1].Bonus[DatabaseAPI.Database.EnhancementSets[index1].Bonus.Length - 1] = new EnhancementSet.BonusItem();
                EnhancementSet.BonusItem[] bonus = DatabaseAPI.Database.EnhancementSets[index1].Bonus;
                int index2 = DatabaseAPI.Database.EnhancementSets[index1].Bonus.Length - 1;
                bonus[index2].AltString = "";
                bonus[index2].Name = new string[strArray1.Length - 1 + 1];
                bonus[index2].Index = new int[strArray1.Length - 1 + 1];
                int num2 = bonus[index2].Name.Length - 1;
                for (int index3 = 0; index3 <= num2; ++index3)
                {
                  bonus[index2].Name[index3] = strArray1[index3];
                  bonus[index2].Index[index3] = DatabaseAPI.NidFromUidPower(strArray1[index3]);
                }
                bonus[index2].Special = -1;
                bonus[index2].PvMode = ePvX;
                bonus[index2].Slotted = integer;
              }
              else
              {
                int num2 = -1;
                int num7 = strArray2.Length - 1;
                for (int index2 = 0; index2 <= num7; ++index2)
                {
                  int num8 = DatabaseAPI.NidFromUidEnh(strArray2[index2]);
                  if (num8 > -1)
                  {
                    int num9 = DatabaseAPI.Database.EnhancementSets[index1].Enhancements.Length - 1;
                    for (int index3 = 0; index3 <= num9; ++index3)
                    {
                      if (DatabaseAPI.Database.EnhancementSets[index1].Enhancements[index3] == num8)
                      {
                        num2 = index3;
                        break;
                      }
                    }
                    break;
                  }
                }
                if (num2 > -1)
                {
                  EnhancementSet.BonusItem[] specialBonus = DatabaseAPI.Database.EnhancementSets[index1].SpecialBonus;
                  int index2 = num2;
                  specialBonus[index2].AltString = "";
                  specialBonus[index2].Name = new string[strArray1.Length - 1 + 1];
                  specialBonus[index2].Index = new int[strArray1.Length - 1 + 1];
                  int num8 = specialBonus[index2].Name.Length - 1;
                  for (int index3 = 0; index3 <= num8; ++index3)
                  {
                    specialBonus[index2].Name[index3] = strArray1[index3];
                    specialBonus[index2].Index[index3] = DatabaseAPI.NidFromUidPower(strArray1[index3]);
                  }
                  specialBonus[index2].Special = num2;
                  specialBonus[index2].PvMode = ePvX;
                  specialBonus[index2].Slotted = integer;
                }
              }
              ++num1;
            }
            else
              ++num4;
            ++num3;
          }
        }
        while (iLine != null);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        iStream.Close();
        int num2 = (int) Interaction.MsgBox((object) exception.Message, MsgBoxStyle.Critical, (object) "Power Class CSV Parse Error");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      iStream.Close();
      DatabaseAPI.SaveEnhancementDb();
      this.DisplayInfo();
      int num10 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, (object) "File Parsed");
      return true;
    }
  }
}
