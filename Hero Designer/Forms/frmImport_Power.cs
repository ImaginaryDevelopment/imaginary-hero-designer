
using Base.Data_Classes;
using Base.IO_Classes;
using Import;
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
  public partial class frmImport_Power : Form
  {
        Button btnCheckAll;

        Button btnCheckModified;

        Button btnClose;

        Button btnEraseAll;

        Button btnFile;

        Button btnImport;

        Button btnUncheckAll;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        OpenFileDialog dlgBrowse;
        Label Label6;
        Label Label8;
        Label lblCount;
        Label lblDate;
        Label lblFile;
        ListView lstImport;
        NumericUpDown udRevision;

    frmBusy bFrm;

    string FullFileName;

    PowerData[] ImportBuffer;

    public frmImport_Power()
    {
      this.Load += new EventHandler(this.frmImport_Power_Load);
      this.FullFileName = "";
      this.ImportBuffer = new PowerData[0];
      this.InitializeComponent();
    }

    void btnCheckAll_Click(object sender, EventArgs e)

    {
      this.lstImport.BeginUpdate();
      int num = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num; ++index)
        this.lstImport.Items[index].Checked = true;
      this.lstImport.EndUpdate();
    }

    void btnCheckModified_Click(object sender, EventArgs e)

    {
      this.lstImport.BeginUpdate();
      int num = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num; ++index)
        this.lstImport.Items[index].Checked = this.lstImport.Items[index].SubItems[2].Text == "No" & this.lstImport.Items[index].SubItems[3].Text == "Yes";
      this.lstImport.EndUpdate();
    }

    void btnClose_Click(object sender, EventArgs e)

    {
      this.Close();
    }

    void btnEraseAll_Click(object sender, EventArgs e)

    {
      if (Interaction.MsgBox((object) "Really wipte the power array. You shouldn't do this if you want to preserve any special power settings.", MsgBoxStyle.YesNo, (object) "Really?") == MsgBoxResult.No)
        return;
      DatabaseAPI.Database.Power = new IPower[0];
      int num1 = this.ImportBuffer.Length - 1;
      for (int index = 0; index <= num1; ++index)
      {
        if (this.ImportBuffer[index].IsValid)
          this.ImportBuffer[index].IsNew = true;
      }
      int num2 = (int) Interaction.MsgBox((object) "All powers removed!", MsgBoxStyle.OkOnly, null);
    }

    void btnFile_Click(object sender, EventArgs e)

    {
      this.dlgBrowse.FileName = this.FullFileName;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) == DialogResult.OK)
      {
        this.FullFileName = this.dlgBrowse.FileName;
        this.Enabled = false;
        if (this.ParseClasses(this.FullFileName))
          this.FillListView();
        this.Enabled = true;
      }
      this.BusyHide();
      this.DisplayInfo();
    }

    void btnImport_Click(object sender, EventArgs e)

    {
      this.ProcessImport();
    }

    void btnUncheckAll_Click(object sender, EventArgs e)

    {
      this.lstImport.BeginUpdate();
      int num = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num; ++index)
        this.lstImport.Items[index].Checked = false;
      this.lstImport.EndUpdate();
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
        this.bFrm.Show((IWin32Window) this);
      }
      this.bFrm.SetMessage(sMessage);
    }

    int[] CheckForDeletedPowers()

    {
      int[] numArray = new int[0];
      int num1 = 0;
      int num2 = DatabaseAPI.Database.Power.Length - 1;
      for (int index1 = 0; index1 <= num2; ++index1)
      {
        ++num1;
        if (num1 >= 9)
        {
          this.BusyMsg("Checking for deleted powers..." + Strings.Format((object) index1, "###,##0") + " of " + Conversions.ToString(DatabaseAPI.Database.Power.Length) + " done.");
          Application.DoEvents();
          num1 = 0;
        }
        bool flag = false;
        int num3 = this.ImportBuffer.Length - 1;
        for (int index2 = 0; index2 <= num3; ++index2)
        {
          if (this.ImportBuffer[index2].Index == index1)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          numArray = (int[]) Utils.CopyArray((Array) numArray, (Array) new int[numArray.Length + 1]);
          numArray[numArray.Length - 1] = index1;
        }
      }
      this.BusyHide();
      string str = "";
      int num4 = numArray.Length - 1;
      for (int index = 0; index <= num4; ++index)
        str = str + DatabaseAPI.Database.Power[numArray[index]].FullName + "\r\n";
      Clipboard.SetDataObject((object) str);
      return numArray;
    }

    static int DeletePowers(int[] pList)

    {
      int index1 = 0;
      IPower[] powerArray = new IPower[DatabaseAPI.Database.Power.Length - pList.Length - 1 + 1];
      int num1 = DatabaseAPI.Database.Power.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        bool flag = false;
        int num2 = pList.Length - 1;
        for (int index3 = 0; index3 <= num2; ++index3)
        {
          if (index2 == pList[index3])
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          powerArray[index1] = (IPower) new Power(DatabaseAPI.Database.Power[index2]);
          ++index1;
        }
      }
      int num3;
      if (index1 != powerArray.Length)
      {
        int num2 = (int) Interaction.MsgBox((object) ("Power array size mismatch! Count: " + Conversions.ToString(index1) + " Array Length: " + Conversions.ToString(powerArray.Length) + "\r\nNothing deleted."), MsgBoxStyle.OkOnly, null);
        num3 = 0;
      }
      else
      {
        DatabaseAPI.Database.Power = new IPower[powerArray.Length - 1 + 1];
        int num2 = DatabaseAPI.Database.Power.Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
          DatabaseAPI.Database.Power[index2] = (IPower) new Power(powerArray[index2]);
        num3 = index1;
      }
      return num3;
    }

    void DisplayInfo()

    {
      this.lblFile.Text = FileIO.StripPath(this.FullFileName);
      this.lblDate.Text = "Date: " + Strings.Format((object) DatabaseAPI.Database.PowerVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.udRevision.Value = new Decimal(DatabaseAPI.Database.PowerVersion.Revision);
      this.lblCount.Text = "Records: " + Conversions.ToString(DatabaseAPI.Database.Power.Length);
    }

    void FillListView()

    {
      string[] items = new string[5];
      this.lstImport.BeginUpdate();
      this.lstImport.Items.Clear();
      int num1 = 0;
      int num2 = this.ImportBuffer.Length - 1;
      for (int index = 0; index <= num2 - 1; ++index)
      {
        ++num1;
        if (num1 >= 100)
        {
          this.BusyMsg(Strings.Format((object) index, "###,##0") + " records checked.");
          Application.DoEvents();
          num1 = 0;
        }
        if (this.ImportBuffer[index].IsValid)
        {
          items[0] = this.ImportBuffer[index].Data.FullName;
          items[1] = this.ImportBuffer[index].Data.DisplayName;
          items[2] = !this.ImportBuffer[index].IsNew ? "No" : "Yes";
          bool flag = this.ImportBuffer[index].CheckDifference(out items[4]);
          items[3] = !flag ? "No" : "Yes";
          this.lstImport.Items.Add(new ListViewItem(items)
          {
            Checked = flag,
            Tag = (object) index
          });
        }
      }
      if (this.lstImport.Items.Count > 0)
        this.lstImport.Items[0].EnsureVisible();
      this.lstImport.EndUpdate();
    }

    void frmImport_Power_Load(object sender, EventArgs e)

    {
      this.FullFileName = DatabaseAPI.Database.PowerVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]

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
        int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Power CSV Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      int num3 = 0;
      int num4 = 0;
      this.ImportBuffer = new PowerData[0];
      int num5 = 0;
      try
      {
        string iString;
        do
        {
          iString = FileIO.ReadLineUnlimited(iStream, char.MinValue);
          if (iString != null && !iString.StartsWith("#"))
          {
            ++num5;
            if (num5 >= 9)
            {
              this.BusyMsg(Strings.Format((object) num3, "###,##0") + " records parsed.");
              Application.DoEvents();
              num5 = 0;
            }
            this.ImportBuffer = (PowerData[]) Utils.CopyArray((Array) this.ImportBuffer, (Array) new PowerData[this.ImportBuffer.Length + 1]);
            this.ImportBuffer[this.ImportBuffer.Length - 1] = new PowerData(iString);
            ++num3;
            if (this.ImportBuffer[this.ImportBuffer.Length - 1].IsValid)
              ++num1;
            else
              ++num4;
          }
        }
        while (iString != null);
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
      int num6 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, (object) "File Parsed");
      return true;
    }

    bool ProcessImport()

    {
      bool flag = false;
      int num1 = 0;
      int num2 = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num2 - 1; ++index)
      {
        if (this.lstImport.Items[index].Checked)
        {
          this.ImportBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
          ++num1;
        }
      }
      if (Interaction.MsgBox((object) "Check for deleted powers?", MsgBoxStyle.YesNo, (object) "Additional Check") == MsgBoxResult.Yes)
      {
        int[] pList = this.CheckForDeletedPowers();
        if (pList.Length > 0 && Interaction.MsgBox((object) (Conversions.ToString(pList.Length) + "  deleted powers found. Delete them?"), MsgBoxStyle.YesNo, (object) "Additional Check") == MsgBoxResult.Yes)
          frmImport_Power.DeletePowers(pList);
      }
      DatabaseAPI.Database.PowerVersion.SourceFile = this.dlgBrowse.FileName;
      DatabaseAPI.Database.PowerVersion.RevisionDate = DateTime.Now;
      DatabaseAPI.Database.PowerVersion.Revision = Convert.ToInt32(this.udRevision.Value);
      DatabaseAPI.MatchAllIDs(null);
      DatabaseAPI.SaveMainDatabase();
      int num3 = (int) Interaction.MsgBox((object) ("Import of " + Conversions.ToString(num1) + " records completed!"), MsgBoxStyle.Information, (object) "Done");
      this.DisplayInfo();
      return flag;
    }
  }
}