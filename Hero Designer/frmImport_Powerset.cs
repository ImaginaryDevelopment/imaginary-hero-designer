// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmImport_Powerset
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

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
  public class frmImport_Powerset : Form
  {
    [AccessedThroughProperty("btnCheckAll")]
    private Button _btnCheckAll;
    [AccessedThroughProperty("btnClose")]
    private Button _btnClose;
    [AccessedThroughProperty("btnFile")]
    private Button _btnFile;
    [AccessedThroughProperty("btnImport")]
    private Button _btnImport;
    [AccessedThroughProperty("btnUncheckAll")]
    private Button _btnUncheckAll;
    [AccessedThroughProperty("ColumnHeader1")]
    private ColumnHeader _ColumnHeader1;
    [AccessedThroughProperty("ColumnHeader2")]
    private ColumnHeader _ColumnHeader2;
    [AccessedThroughProperty("ColumnHeader3")]
    private ColumnHeader _ColumnHeader3;
    [AccessedThroughProperty("ColumnHeader4")]
    private ColumnHeader _ColumnHeader4;
    [AccessedThroughProperty("ColumnHeader5")]
    private ColumnHeader _ColumnHeader5;
    [AccessedThroughProperty("dlgBrowse")]
    private OpenFileDialog _dlgBrowse;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("lblCount")]
    private Label _lblCount;
    [AccessedThroughProperty("lblDate")]
    private Label _lblDate;
    [AccessedThroughProperty("lblFile")]
    private Label _lblFile;
    [AccessedThroughProperty("lstImport")]
    private ListView _lstImport;
    [AccessedThroughProperty("udRevision")]
    private NumericUpDown _udRevision;
    private frmBusy bFrm;
    private IContainer components;
    private string FullFileName;
    private PowersetData[] ImportBuffer;

    internal virtual Button btnCheckAll
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

    internal virtual Button btnClose
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

    internal virtual Button btnFile
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

    internal virtual Button btnImport
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

    internal virtual Button btnUncheckAll
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

    internal virtual ColumnHeader ColumnHeader1
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

    internal virtual ColumnHeader ColumnHeader2
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

    internal virtual ColumnHeader ColumnHeader3
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

    internal virtual ColumnHeader ColumnHeader4
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

    internal virtual ColumnHeader ColumnHeader5
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

    internal virtual OpenFileDialog dlgBrowse
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

    internal virtual Label Label6
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

    internal virtual Label Label8
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

    internal virtual Label lblCount
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

    internal virtual Label lblDate
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

    internal virtual Label lblFile
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

    internal virtual ListView lstImport
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

    internal virtual NumericUpDown udRevision
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

    public frmImport_Powerset()
    {
      this.Load += new EventHandler(this.frmImport_Powerset_Load);
      this.FullFileName = "";
      this.ImportBuffer = new PowersetData[0];
      this.InitializeComponent();
    }

    private void btnCheckAll_Click(object sender, EventArgs e)
    {
      this.lstImport.BeginUpdate();
      int num = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num; ++index)
        this.lstImport.Items[index].Checked = true;
      this.lstImport.EndUpdate();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnFile_Click(object sender, EventArgs e)
    {
      this.dlgBrowse.FileName = this.FullFileName;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) == DialogResult.OK)
      {
        this.FullFileName = this.dlgBrowse.FileName;
        if (this.ParseClasses(this.FullFileName))
          this.FillListView();
      }
      this.BusyHide();
      this.DisplayInfo();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      this.ProcessImport();
    }

    private void btnUncheckAll_Click(object sender, EventArgs e)
    {
      this.lstImport.BeginUpdate();
      int num = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num; ++index)
        this.lstImport.Items[index].Checked = false;
      this.lstImport.EndUpdate();
    }

    private void BusyHide()
    {
      if (this.bFrm == null)
        return;
      this.bFrm.Close();
      this.bFrm = (frmBusy) null;
    }

    private void BusyMsg(string sMessage)
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
      this.lblDate.Text = "Date: " + Strings.Format((object) DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.udRevision.Value = new Decimal(DatabaseAPI.Database.PowersetVersion.Revision);
      this.lblCount.Text = "Records: " + Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
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

    private void FillListView()
    {
      string[] items = new string[5];
      this.lstImport.BeginUpdate();
      this.lstImport.Items.Clear();
      int num1 = 0;
      int num2 = this.ImportBuffer.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        ++num1;
        if (num1 >= 100)
        {
          this.BusyMsg(Strings.Format((object) index, "###,##0") + " records checked.");
          num1 = 0;
        }
        if (this.ImportBuffer[index].IsValid)
        {
          items[0] = this.ImportBuffer[index].Data.FullName;
          items[1] = this.ImportBuffer[index].Data.GroupName;
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

    private void frmImport_Powerset_Load(object sender, EventArgs e)
    {
      this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_Powerset));
      this.Label8 = new Label();
      this.lblCount = new Label();
      this.lblDate = new Label();
      this.udRevision = new NumericUpDown();
      this.Label6 = new Label();
      this.lblFile = new Label();
      this.btnFile = new Button();
      this.btnClose = new Button();
      this.dlgBrowse = new OpenFileDialog();
      this.btnImport = new Button();
      this.lstImport = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.btnCheckAll = new Button();
      this.btnUncheckAll = new Button();
      this.ColumnHeader3 = new ColumnHeader();
      this.udRevision.BeginInit();
      this.SuspendLayout();
      Point point = new Point(346, 53);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      Size size = new Size(65, 18);
      this.Label8.Size = size;
      this.Label8.TabIndex = 32;
      this.Label8.Text = "Revision:";
      this.Label8.TextAlign = ContentAlignment.TopRight;
      point = new Point(208, 53);
      this.lblCount.Location = point;
      this.lblCount.Name = "lblCount";
      size = new Size(132, 18);
      this.lblCount.Size = size;
      this.lblCount.TabIndex = 31;
      this.lblCount.Text = "Sets:";
      point = new Point(9, 53);
      this.lblDate.Location = point;
      this.lblDate.Name = "lblDate";
      size = new Size(175, 18);
      this.lblDate.Size = size;
      this.lblDate.TabIndex = 30;
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
      this.udRevision.TabIndex = 29;
      point = new Point(12, 9);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(150, 14);
      this.Label6.Size = size;
      this.Label6.TabIndex = 28;
      this.Label6.Text = "Set Definition File:";
      this.lblFile.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 25);
      this.lblFile.Location = point;
      this.lblFile.Name = "lblFile";
      size = new Size(521, 23);
      this.lblFile.Size = size;
      this.lblFile.TabIndex = 27;
      this.lblFile.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 25);
      this.btnFile.Location = point;
      this.btnFile.Name = "btnFile";
      size = new Size(165, 23);
      this.btnFile.Size = size;
      this.btnFile.TabIndex = 26;
      this.btnFile.Text = "Load / Re-Load";
      this.btnFile.UseVisualStyleBackColor = true;
      point = new Point(618, 516);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      size = new Size(86, 23);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 35;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      point = new Point(618, 77);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(86, 22);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 34;
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
      this.lstImport.TabIndex = 33;
      this.lstImport.UseCompatibleStateImageBehavior = false;
      this.lstImport.View = View.Details;
      this.ColumnHeader1.Text = "Powerset";
      this.ColumnHeader1.Width = 180;
      this.ColumnHeader2.Text = "Group";
      this.ColumnHeader2.Width = 176;
      this.ColumnHeader4.Text = "New";
      this.ColumnHeader4.Width = 71;
      this.ColumnHeader5.Text = "Modified";
      point = new Point(12, 545);
      this.btnCheckAll.Location = point;
      this.btnCheckAll.Name = "btnCheckAll";
      size = new Size(75, 23);
      this.btnCheckAll.Size = size;
      this.btnCheckAll.TabIndex = 36;
      this.btnCheckAll.Text = "Check All";
      this.btnCheckAll.UseVisualStyleBackColor = true;
      point = new Point(93, 545);
      this.btnUncheckAll.Location = point;
      this.btnUncheckAll.Name = "btnUncheckAll";
      size = new Size(75, 23);
      this.btnUncheckAll.Size = size;
      this.btnUncheckAll.TabIndex = 37;
      this.btnUncheckAll.Text = "Uncheck All";
      this.btnUncheckAll.UseVisualStyleBackColor = true;
      this.ColumnHeader3.Text = "Change Description";
      this.ColumnHeader3.Width = 106;
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(711, 574);
      this.ClientSize = size;
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
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_Powerset);
      this.ShowInTaskbar = false;
      this.Text = "Powerset Import";
      this.udRevision.EndInit();
      this.ResumeLayout(false);
    }

    private bool ParseClasses(string iFileName)
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
        int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Powerset CSV Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      int num3 = 0;
      int num4 = 0;
      this.ImportBuffer = new PowersetData[0];
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
            if (num5 >= 100)
            {
              this.BusyMsg(Strings.Format((object) num3, "###,##0") + " records parsed.");
              num5 = 0;
            }
            this.ImportBuffer = (PowersetData[]) Utils.CopyArray((Array) this.ImportBuffer, (Array) new PowersetData[this.ImportBuffer.Length + 1]);
            this.ImportBuffer[this.ImportBuffer.Length - 1] = new PowersetData(iString);
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
        int num2 = (int) Interaction.MsgBox((object) exception.Message, MsgBoxStyle.Critical, (object) "Powerset Class CSV Parse Error");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      iStream.Close();
      int num6 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, (object) "File Parsed");
      return true;
    }

    private bool ProcessImport()
    {
      bool flag = false;
      int num1 = 0;
      int num2 = this.lstImport.Items.Count - 1;
      for (int index = 0; index <= num2; ++index)
      {
        if (this.lstImport.Items[index].Checked)
        {
          this.ImportBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
          ++num1;
        }
      }
      DatabaseAPI.Database.PowersetVersion.SourceFile = this.dlgBrowse.FileName;
      DatabaseAPI.Database.PowersetVersion.RevisionDate = DateTime.Now;
      DatabaseAPI.Database.PowersetVersion.Revision = Convert.ToInt32(this.udRevision.Value);
      DatabaseAPI.MatchAllIDs((IMessager) null);
      DatabaseAPI.SaveMainDatabase();
      int num3 = (int) Interaction.MsgBox((object) ("Import of " + Conversions.ToString(num1) + " records completed!"), MsgBoxStyle.Information, (object) "Done");
      this.DisplayInfo();
      return flag;
    }
  }
}
