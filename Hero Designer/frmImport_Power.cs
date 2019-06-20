
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
  [DesignerGenerated]
  public class frmImport_Power : Form
  {
    [AccessedThroughProperty("btnCheckAll")]
    Button _btnCheckAll;

    [AccessedThroughProperty("btnCheckModified")]
    Button _btnCheckModified;

    [AccessedThroughProperty("btnClose")]
    Button _btnClose;

    [AccessedThroughProperty("btnEraseAll")]
    Button _btnEraseAll;

    [AccessedThroughProperty("btnFile")]
    Button _btnFile;

    [AccessedThroughProperty("btnImport")]
    Button _btnImport;

    [AccessedThroughProperty("btnUncheckAll")]
    Button _btnUncheckAll;

    [AccessedThroughProperty("ColumnHeader1")]
    ColumnHeader _ColumnHeader1;

    [AccessedThroughProperty("ColumnHeader2")]
    ColumnHeader _ColumnHeader2;

    [AccessedThroughProperty("ColumnHeader3")]
    ColumnHeader _ColumnHeader3;

    [AccessedThroughProperty("ColumnHeader4")]
    ColumnHeader _ColumnHeader4;

    [AccessedThroughProperty("ColumnHeader5")]
    ColumnHeader _ColumnHeader5;

    [AccessedThroughProperty("dlgBrowse")]
    OpenFileDialog _dlgBrowse;

    [AccessedThroughProperty("Label6")]
    Label _Label6;

    [AccessedThroughProperty("Label8")]
    Label _Label8;

    [AccessedThroughProperty("lblCount")]
    Label _lblCount;

    [AccessedThroughProperty("lblDate")]
    Label _lblDate;

    [AccessedThroughProperty("lblFile")]
    Label _lblFile;

    [AccessedThroughProperty("lstImport")]
    ListView _lstImport;

    [AccessedThroughProperty("udRevision")]
    NumericUpDown _udRevision;

    frmBusy bFrm;

    IContainer components;

    string FullFileName;

    PowerData[] ImportBuffer;


    Button btnCheckAll
    {
      get
      {
        return this._btnCheckAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCheckAll_Click);
        if (this._btnCheckAll != null)
          this._btnCheckAll.Click -= eventHandler;
        this._btnCheckAll = value;
        if (this._btnCheckAll == null)
          return;
        this._btnCheckAll.Click += eventHandler;
      }
    }

    Button btnCheckModified
    {
      get
      {
        return this._btnCheckModified;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCheckModified_Click);
        if (this._btnCheckModified != null)
          this._btnCheckModified.Click -= eventHandler;
        this._btnCheckModified = value;
        if (this._btnCheckModified == null)
          return;
        this._btnCheckModified.Click += eventHandler;
      }
    }

    Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        if (this._btnClose != null)
          this._btnClose.Click -= eventHandler;
        this._btnClose = value;
        if (this._btnClose == null)
          return;
        this._btnClose.Click += eventHandler;
      }
    }

    Button btnEraseAll
    {
      get
      {
        return this._btnEraseAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEraseAll_Click);
        if (this._btnEraseAll != null)
          this._btnEraseAll.Click -= eventHandler;
        this._btnEraseAll = value;
        if (this._btnEraseAll == null)
          return;
        this._btnEraseAll.Click += eventHandler;
      }
    }

    Button btnFile
    {
      get
      {
        return this._btnFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFile_Click);
        if (this._btnFile != null)
          this._btnFile.Click -= eventHandler;
        this._btnFile = value;
        if (this._btnFile == null)
          return;
        this._btnFile.Click += eventHandler;
      }
    }

    Button btnImport
    {
      get
      {
        return this._btnImport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnImport_Click);
        if (this._btnImport != null)
          this._btnImport.Click -= eventHandler;
        this._btnImport = value;
        if (this._btnImport == null)
          return;
        this._btnImport.Click += eventHandler;
      }
    }

    Button btnUncheckAll
    {
      get
      {
        return this._btnUncheckAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUncheckAll_Click);
        if (this._btnUncheckAll != null)
          this._btnUncheckAll.Click -= eventHandler;
        this._btnUncheckAll = value;
        if (this._btnUncheckAll == null)
          return;
        this._btnUncheckAll.Click += eventHandler;
      }
    }

    ColumnHeader ColumnHeader1
    {
      get
      {
        return this._ColumnHeader1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader1 = value;
      }
    }

    ColumnHeader ColumnHeader2
    {
      get
      {
        return this._ColumnHeader2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader2 = value;
      }
    }

    ColumnHeader ColumnHeader3
    {
      get
      {
        return this._ColumnHeader3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader3 = value;
      }
    }

    ColumnHeader ColumnHeader4
    {
      get
      {
        return this._ColumnHeader4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader4 = value;
      }
    }

    ColumnHeader ColumnHeader5
    {
      get
      {
        return this._ColumnHeader5;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader5 = value;
      }
    }

    OpenFileDialog dlgBrowse
    {
      get
      {
        return this._dlgBrowse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._dlgBrowse = value;
      }
    }

    Label Label6
    {
      get
      {
        return this._Label6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label6 = value;
      }
    }

    Label Label8
    {
      get
      {
        return this._Label8;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label8 = value;
      }
    }

    Label lblCount
    {
      get
      {
        return this._lblCount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblCount = value;
      }
    }

    Label lblDate
    {
      get
      {
        return this._lblDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblDate = value;
      }
    }

    Label lblFile
    {
      get
      {
        return this._lblFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblFile = value;
      }
    }

    ListView lstImport
    {
      get
      {
        return this._lstImport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lstImport = value;
      }
    }

    NumericUpDown udRevision
    {
      get
      {
        return this._udRevision;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._udRevision = value;
      }
    }

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
      int num2 = (int) Interaction.MsgBox((object) "All powers removed!", MsgBoxStyle.OkOnly, (object) null);
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
        int num2 = (int) Interaction.MsgBox((object) ("Power array size mismatch! Count: " + Conversions.ToString(index1) + " Array Length: " + Conversions.ToString(powerArray.Length) + "\r\nNothing deleted."), MsgBoxStyle.OkOnly, (object) null);
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
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_Power));
      this.dlgBrowse = new OpenFileDialog();
      this.btnUncheckAll = new Button();
      this.btnCheckAll = new Button();
      this.btnClose = new Button();
      this.btnImport = new Button();
      this.lstImport = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.Label8 = new Label();
      this.lblCount = new Label();
      this.lblDate = new Label();
      this.udRevision = new NumericUpDown();
      this.Label6 = new Label();
      this.lblFile = new Label();
      this.btnFile = new Button();
      this.btnCheckModified = new Button();
      this.btnEraseAll = new Button();
      this.ColumnHeader3 = new ColumnHeader();
      this.udRevision.BeginInit();
      this.SuspendLayout();
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      Point point = new Point(93, 545);
      this.btnUncheckAll.Location = point;
      this.btnUncheckAll.Name = "btnUncheckAll";
      Size size = new Size(75, 23);
      this.btnUncheckAll.Size = size;
      this.btnUncheckAll.TabIndex = 49;
      this.btnUncheckAll.Text = "Uncheck All";
      this.btnUncheckAll.UseVisualStyleBackColor = true;
      point = new Point(12, 545);
      this.btnCheckAll.Location = point;
      this.btnCheckAll.Name = "btnCheckAll";
      size = new Size(75, 23);
      this.btnCheckAll.Size = size;
      this.btnCheckAll.TabIndex = 48;
      this.btnCheckAll.Text = "Check All";
      this.btnCheckAll.UseVisualStyleBackColor = true;
      point = new Point(618, 516);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      size = new Size(86, 23);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 47;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      point = new Point(618, 77);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(86, 22);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 46;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.lstImport.CheckBoxes = true;
      this.lstImport.Columns.AddRange(new ColumnHeader[5]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader4,
        this.ColumnHeader5,
        this.ColumnHeader3
      });
      this.lstImport.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      point = new Point(12, 77);
      this.lstImport.Location = point;
      this.lstImport.Name = "lstImport";
      size = new Size(600, 462);
      this.lstImport.Size = size;
      this.lstImport.TabIndex = 45;
      this.lstImport.UseCompatibleStateImageBehavior = false;
      this.lstImport.View = View.Details;
      this.ColumnHeader1.Text = "Power";
      this.ColumnHeader1.Width = 237;
      this.ColumnHeader2.Text = "Name";
      this.ColumnHeader2.Width = 117;
      this.ColumnHeader4.Text = "New";
      this.ColumnHeader4.Width = 71;
      this.ColumnHeader5.Text = "Modified";
      point = new Point(346, 53);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(65, 18);
      this.Label8.Size = size;
      this.Label8.TabIndex = 44;
      this.Label8.Text = "Revision:";
      this.Label8.TextAlign = ContentAlignment.TopRight;
      point = new Point(208, 53);
      this.lblCount.Location = point;
      this.lblCount.Name = "lblCount";
      size = new Size(132, 18);
      this.lblCount.Size = size;
      this.lblCount.TabIndex = 43;
      this.lblCount.Text = "Sets:";
      point = new Point(9, 53);
      this.lblDate.Location = point;
      this.lblDate.Name = "lblDate";
      size = new Size(175, 18);
      this.lblDate.Size = size;
      this.lblDate.TabIndex = 42;
      this.lblDate.Text = "Date:";
      point = new Point(417, 51);
      this.udRevision.Location = point;
      this.udRevision.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.udRevision.Name = "udRevision";
      size = new Size(116, 20);
      this.udRevision.Size = size;
      this.udRevision.TabIndex = 41;
      point = new Point(12, 9);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(150, 14);
      this.Label6.Size = size;
      this.Label6.TabIndex = 40;
      this.Label6.Text = "Power Definition File:";
      this.lblFile.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 25);
      this.lblFile.Location = point;
      this.lblFile.Name = "lblFile";
      size = new Size(521, 23);
      this.lblFile.Size = size;
      this.lblFile.TabIndex = 39;
      this.lblFile.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 25);
      this.btnFile.Location = point;
      this.btnFile.Name = "btnFile";
      size = new Size(165, 23);
      this.btnFile.Size = size;
      this.btnFile.TabIndex = 38;
      this.btnFile.Text = "Load / Re-Load";
      this.btnFile.UseVisualStyleBackColor = true;
      point = new Point(192, 545);
      this.btnCheckModified.Location = point;
      this.btnCheckModified.Name = "btnCheckModified";
      size = new Size(171, 23);
      this.btnCheckModified.Size = size;
      this.btnCheckModified.TabIndex = 50;
      this.btnCheckModified.Text = "Modified Only (Skip New)";
      this.btnCheckModified.UseVisualStyleBackColor = true;
      point = new Point(618, 137);
      this.btnEraseAll.Location = point;
      this.btnEraseAll.Name = "btnEraseAll";
      size = new Size(86, 69);
      this.btnEraseAll.Size = size;
      this.btnEraseAll.TabIndex = 63;
      this.btnEraseAll.Text = "Erase All Powers";
      this.btnEraseAll.UseVisualStyleBackColor = true;
      this.ColumnHeader3.Text = "Change Description";
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(716, 575);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnEraseAll);
      this.Controls.Add((Control) this.btnCheckModified);
      this.Controls.Add((Control) this.btnUncheckAll);
      this.Controls.Add((Control) this.btnCheckAll);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.lstImport);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.lblCount);
      this.Controls.Add((Control) this.lblDate);
      this.Controls.Add((Control) this.udRevision);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.lblFile);
      this.Controls.Add((Control) this.btnFile);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_Power);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Power Import";
      this.udRevision.EndInit();
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
      DatabaseAPI.MatchAllIDs((IMessager) null);
      DatabaseAPI.SaveMainDatabase();
      int num3 = (int) Interaction.MsgBox((object) ("Import of " + Conversions.ToString(num1) + " records completed!"), MsgBoxStyle.Information, (object) "Done");
      this.DisplayInfo();
      return flag;
    }
  }
}
