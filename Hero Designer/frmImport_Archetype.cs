
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
  public class frmImport_Archetype : Form
  {
    [AccessedThroughProperty("btnATFile")]
    Button _btnATFile;

    [AccessedThroughProperty("btnClose")]
    Button _btnClose;

    [AccessedThroughProperty("btnImport")]
    Button _btnImport;

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

    [AccessedThroughProperty("ColumnHeader6")]
    ColumnHeader _ColumnHeader6;

    [AccessedThroughProperty("dlgBrowse")]
    OpenFileDialog _dlgBrowse;

    [AccessedThroughProperty("Label6")]
    Label _Label6;

    [AccessedThroughProperty("Label8")]
    Label _Label8;

    [AccessedThroughProperty("lblATCount")]
    Label _lblATCount;

    [AccessedThroughProperty("lblATDate")]
    Label _lblATDate;

    [AccessedThroughProperty("lblATFile")]
    Label _lblATFile;

    [AccessedThroughProperty("lstImport")]
    ListView _lstImport;

    [AccessedThroughProperty("udATRevision")]
    NumericUpDown _udATRevision;

    IContainer components;

    string FullFileName;

    ArchetypeData[] ImportBuffer;


    Button btnATFile
    {
      get
      {
        return this._btnATFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnATFile_Click);
        if (this._btnATFile != null)
          this._btnATFile.Click -= eventHandler;
        this._btnATFile = value;
        if (this._btnATFile == null)
          return;
        this._btnATFile.Click += eventHandler;
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

    ColumnHeader ColumnHeader6
    {
      get
      {
        return this._ColumnHeader6;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ColumnHeader6 = value;
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

    Label lblATCount
    {
      get
      {
        return this._lblATCount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblATCount = value;
      }
    }

    Label lblATDate
    {
      get
      {
        return this._lblATDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblATDate = value;
      }
    }

    Label lblATFile
    {
      get
      {
        return this._lblATFile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblATFile = value;
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

    NumericUpDown udATRevision
    {
      get
      {
        return this._udATRevision;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._udATRevision = value;
      }
    }

    public frmImport_Archetype()
    {
      this.Load += new EventHandler(this.frmImport_Archetype_Load);
      this.FullFileName = "";
      this.ImportBuffer = new ArchetypeData[0];
      this.InitializeComponent();
    }

    void btnATFile_Click(object sender, EventArgs e)

    {
      this.dlgBrowse.FileName = this.FullFileName;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) == DialogResult.OK)
      {
        this.FullFileName = this.dlgBrowse.FileName;
        if (this.ParseClasses(this.FullFileName))
          this.FillListView();
      }
      this.DisplayInfo();
    }

    void btnClose_Click(object sender, EventArgs e)

    {
      this.Close();
    }

    void btnImport_Click(object sender, EventArgs e)

    {
      this.ProcessImport();
    }

    public void DisplayInfo()
    {
      this.lblATFile.Text = FileIO.StripPath(this.FullFileName);
      this.lblATDate.Text = "Date: " + Strings.Format((object) DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.udATRevision.Value = new Decimal(DatabaseAPI.Database.ArchetypeVersion.Revision);
      this.lblATCount.Text = "Classes: " + Conversions.ToString(DatabaseAPI.Database.Classes.Length);
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
      string[] items = new string[6];
      this.lstImport.BeginUpdate();
      this.lstImport.Items.Clear();
      int num = this.ImportBuffer.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (this.ImportBuffer[index].IsValid)
        {
          items[0] = this.ImportBuffer[index].Data.DisplayName;
          items[1] = this.ImportBuffer[index].Data.ClassName;
          items[2] = !this.ImportBuffer[index].Data.Playable ? "No" : "Yes";
          items[3] = !this.ImportBuffer[index].IsNew ? "No" : "Yes";
          bool flag = this.ImportBuffer[index].CheckDifference(out items[5]);
          items[4] = !flag ? "No" : "Yes";
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

    void frmImport_Archetype_Load(object sender, EventArgs e)

    {
      this.FullFileName = DatabaseAPI.Database.ArchetypeVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_Archetype));
      this.Label8 = new Label();
      this.lblATCount = new Label();
      this.lblATDate = new Label();
      this.udATRevision = new NumericUpDown();
      this.Label6 = new Label();
      this.dlgBrowse = new OpenFileDialog();
      this.lblATFile = new Label();
      this.btnATFile = new Button();
      this.lstImport = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.ColumnHeader2 = new ColumnHeader();
      this.ColumnHeader3 = new ColumnHeader();
      this.ColumnHeader4 = new ColumnHeader();
      this.ColumnHeader5 = new ColumnHeader();
      this.btnImport = new Button();
      this.btnClose = new Button();
      this.ColumnHeader6 = new ColumnHeader();
      this.udATRevision.BeginInit();
      this.SuspendLayout();
      Point point = new Point(346, 53);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      Size size = new Size(65, 18);
      this.Label8.Size = size;
      this.Label8.TabIndex = 25;
      this.Label8.Text = "Revision:";
      this.Label8.TextAlign = ContentAlignment.TopRight;
      point = new Point(208, 53);
      this.lblATCount.Location = point;
      this.lblATCount.Name = "lblATCount";
      size = new Size(132, 18);
      this.lblATCount.Size = size;
      this.lblATCount.TabIndex = 24;
      this.lblATCount.Text = "Classes:";
      point = new Point(9, 53);
      this.lblATDate.Location = point;
      this.lblATDate.Name = "lblATDate";
      size = new Size(175, 18);
      this.lblATDate.Size = size;
      this.lblATDate.TabIndex = 23;
      this.lblATDate.Text = "Date:";
      point = new Point(417, 51);
      this.udATRevision.Location = point;
      this.udATRevision.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.udATRevision.Name = "udATRevision";
      size = new Size(116, 20);
      this.udATRevision.Size = size;
      this.udATRevision.TabIndex = 22;
      point = new Point(12, 9);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(150, 14);
      this.Label6.Size = size;
      this.Label6.TabIndex = 21;
      this.Label6.Text = "Class Definition File:";
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      this.lblATFile.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 25);
      this.lblATFile.Location = point;
      this.lblATFile.Name = "lblATFile";
      size = new Size(521, 23);
      this.lblATFile.Size = size;
      this.lblATFile.TabIndex = 20;
      this.lblATFile.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 25);
      this.btnATFile.Location = point;
      this.btnATFile.Name = "btnATFile";
      size = new Size(165, 23);
      this.btnATFile.Size = size;
      this.btnATFile.TabIndex = 19;
      this.btnATFile.Text = "Load / Re-Load";
      this.btnATFile.UseVisualStyleBackColor = true;
      this.lstImport.CheckBoxes = true;
      this.lstImport.Columns.AddRange(new ColumnHeader[6]
      {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader5,
        this.ColumnHeader6
      });
      this.lstImport.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      point = new Point(12, 77);
      this.lstImport.Location = point;
      this.lstImport.Name = "lstImport";
      size = new Size(600, 309);
      this.lstImport.Size = size;
      this.lstImport.TabIndex = 26;
      this.lstImport.UseCompatibleStateImageBehavior = false;
      this.lstImport.View = View.Details;
      this.ColumnHeader1.Text = "Class";
      this.ColumnHeader1.Width = 128;
      this.ColumnHeader2.Text = "ClassID";
      this.ColumnHeader2.Width = 165;
      this.ColumnHeader3.Text = "Playable";
      this.ColumnHeader3.Width = 72;
      this.ColumnHeader4.Text = "New";
      this.ColumnHeader4.Width = 71;
      this.ColumnHeader5.Text = "Modified";
      point = new Point(618, 77);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(86, 22);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 27;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      point = new Point(618, 363);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      size = new Size(86, 23);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 28;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.ColumnHeader6.Text = "Change Description";
      this.ColumnHeader6.Width = 98;
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(711, 400);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.lstImport);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.lblATCount);
      this.Controls.Add((Control) this.lblATDate);
      this.Controls.Add((Control) this.udATRevision);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.lblATFile);
      this.Controls.Add((Control) this.btnATFile);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_Archetype);
      this.ShowInTaskbar = false;
      this.Text = "Archetype Class Import";
      this.udATRevision.EndInit();
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
        int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Archetype Class CSV Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      int num3 = 0;
      int num4 = 0;
      this.ImportBuffer = new ArchetypeData[0];
      try
      {
        string iString;
        do
        {
          iString = FileIO.ReadLineUnlimited(iStream, char.MinValue);
          if (iString != null && !iString.StartsWith("#"))
          {
            this.ImportBuffer = (ArchetypeData[]) Utils.CopyArray((Array) this.ImportBuffer, (Array) new ArchetypeData[this.ImportBuffer.Length + 1]);
            this.ImportBuffer[this.ImportBuffer.Length - 1] = new ArchetypeData(iString);
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
        int num2 = (int) Interaction.MsgBox((object) exception.Message, MsgBoxStyle.Critical, (object) "Archetype Class CSV Parse Error");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      iStream.Close();
      int num5 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nBad: " + Conversions.ToString(num4)), MsgBoxStyle.Information, (object) "File Parsed");
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
      DatabaseAPI.Database.ArchetypeVersion.SourceFile = this.dlgBrowse.FileName;
      DatabaseAPI.Database.ArchetypeVersion.RevisionDate = DateTime.Now;
      DatabaseAPI.Database.ArchetypeVersion.Revision = Convert.ToInt32(this.udATRevision.Value);
      DatabaseAPI.SaveMainDatabase();
      int num3 = (int) Interaction.MsgBox((object) ("Import of " + Conversions.ToString(num1) + " classes completed!"), MsgBoxStyle.Information, (object) "Done");
      this.DisplayInfo();
      return flag;
    }
  }
}
