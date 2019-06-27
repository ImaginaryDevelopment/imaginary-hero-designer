
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
        Button btnCheckAll;

        Button btnClose;

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

    IContainer components;

    string FullFileName;

    PowersetData[] ImportBuffer;














    public frmImport_Powerset()
    {
      this.Load += new EventHandler(this.frmImport_Powerset_Load);
      this.FullFileName = "";
      this.ImportBuffer = new PowersetData[0];
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

    void btnClose_Click(object sender, EventArgs e)

    {
      this.Close();
    }

    void btnFile_Click(object sender, EventArgs e)

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

    void FillListView()

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

    void frmImport_Powerset_Load(object sender, EventArgs e)

    {
      this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

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
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnCheckAll.Click += btnCheckAll_Click;
                  this.btnClose.Click += btnClose_Click;
                  this.btnFile.Click += btnFile_Click;
                  this.btnImport.Click += btnImport_Click;
                  this.btnUncheckAll.Click += btnUncheckAll_Click;
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

    bool ProcessImport()

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
