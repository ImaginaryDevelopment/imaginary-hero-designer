
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
  public class frmImport_mod : Form
  {
    [AccessedThroughProperty("btnAttribIndex")]
    Button _btnAttribIndex;

    [AccessedThroughProperty("btnAttribLoad")]
    Button _btnAttribLoad;

    [AccessedThroughProperty("btnAttribTable")]
    Button _btnAttribTable;

    [AccessedThroughProperty("Button1")]
    Button _Button1;

    [AccessedThroughProperty("dlgBrowse")]
    OpenFileDialog _dlgBrowse;

    [AccessedThroughProperty("Label1")]
    Label _Label1;

    [AccessedThroughProperty("Label3")]
    Label _Label3;

    [AccessedThroughProperty("Label4")]
    Label _Label4;

    [AccessedThroughProperty("lblAttribDate")]
    Label _lblAttribDate;

    [AccessedThroughProperty("lblAttribIndex")]
    Label _lblAttribIndex;

    [AccessedThroughProperty("lblAttribTableCount")]
    Label _lblAttribTableCount;

    [AccessedThroughProperty("lblAttribTables")]
    Label _lblAttribTables;

    [AccessedThroughProperty("udAttribRevision")]
    NumericUpDown _udAttribRevision;

    IContainer components;


    Button btnAttribIndex
    {
      get
      {
        return this._btnAttribIndex;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAttribIndex_Click);
        if (this._btnAttribIndex != null)
          this._btnAttribIndex.Click -= eventHandler;
        this._btnAttribIndex = value;
        if (this._btnAttribIndex == null)
          return;
        this._btnAttribIndex.Click += eventHandler;
      }
    }

    Button btnAttribLoad
    {
      get
      {
        return this._btnAttribLoad;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAttribLoad_Click);
        if (this._btnAttribLoad != null)
          this._btnAttribLoad.Click -= eventHandler;
        this._btnAttribLoad = value;
        if (this._btnAttribLoad == null)
          return;
        this._btnAttribLoad.Click += eventHandler;
      }
    }

    Button btnAttribTable
    {
      get
      {
        return this._btnAttribTable;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAttribTable_Click);
        if (this._btnAttribTable != null)
          this._btnAttribTable.Click -= eventHandler;
        this._btnAttribTable = value;
        if (this._btnAttribTable == null)
          return;
        this._btnAttribTable.Click += eventHandler;
      }
    }

    Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        if (this._Button1 != null)
          this._Button1.Click -= eventHandler;
        this._Button1 = value;
        if (this._Button1 == null)
          return;
        this._Button1.Click += eventHandler;
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

    Label Label1
    {
      get
      {
        return this._Label1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    Label Label3
    {
      get
      {
        return this._Label3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label3 = value;
      }
    }

    Label Label4
    {
      get
      {
        return this._Label4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label4 = value;
      }
    }

    Label lblAttribDate
    {
      get
      {
        return this._lblAttribDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblAttribDate = value;
      }
    }

    Label lblAttribIndex
    {
      get
      {
        return this._lblAttribIndex;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblAttribIndex = value;
      }
    }

    Label lblAttribTableCount
    {
      get
      {
        return this._lblAttribTableCount;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblAttribTableCount = value;
      }
    }

    Label lblAttribTables
    {
      get
      {
        return this._lblAttribTables;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblAttribTables = value;
      }
    }

    NumericUpDown udAttribRevision
    {
      get
      {
        return this._udAttribRevision;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._udAttribRevision = value;
      }
    }

    public frmImport_mod()
    {
      this.Load += new EventHandler(this.frmImport_mod_Load);
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
          if (DatabaseAPI.Database.AttribMods.ImportModifierTablefromCSV(this.lblAttribIndex.Text, this.lblAttribTables.Text, Convert.ToInt32(this.udAttribRevision.Value)))
          {
            DatabaseAPI.Database.AttribMods.Store();
            int num = (int) Interaction.MsgBox((object) (Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length) + " modifier tables imported and saved."), MsgBoxStyle.Information, (object) "Done.");
          }
          else
          {
            int num1 = (int) Interaction.MsgBox((object) "Import failed. attempting reload of binary data file.", MsgBoxStyle.Information, (object) "Error.");
            if (DatabaseAPI.Database.AttribMods.Load())
            {
              int num2 = (int) Interaction.MsgBox((object) "Binary reload successful.", MsgBoxStyle.Information, (object) "Done.");
            }
          }
        }
        else
        {
          int num3 = (int) Interaction.MsgBox((object) "Files cannot be found!", MsgBoxStyle.Exclamation, (object) "No Can Do");
        }
      }
      else
      {
        int num4 = (int) Interaction.MsgBox((object) "Files not selected!", MsgBoxStyle.Exclamation, (object) "No Can Do");
      }
      this.DisplayInfo();
    }

    void btnAttribTable_Click(object sender, EventArgs e)

    {
      this.dlgBrowse.FileName = this.lblAttribTables.Text;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.lblAttribTables.Text = this.dlgBrowse.FileName;
    }

    void Button1_Click(object sender, EventArgs e)

    {
      this.Close();
    }

    void DisplayInfo()

    {
      this.lblAttribIndex.Text = DatabaseAPI.Database.AttribMods.SourceIndex;
      this.lblAttribTables.Text = DatabaseAPI.Database.AttribMods.SourceTables;
      this.lblAttribDate.Text = "Date: " + Strings.Format((object) DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.udAttribRevision.Value = new Decimal(DatabaseAPI.Database.AttribMods.Revision);
      this.lblAttribTableCount.Text = "Tables: " + Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
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

    void frmImport_mod_Load(object sender, EventArgs e)

    {
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_mod));
      this.lblAttribTableCount = new Label();
      this.lblAttribDate = new Label();
      this.Label1 = new Label();
      this.udAttribRevision = new NumericUpDown();
      this.lblAttribTables = new Label();
      this.btnAttribLoad = new Button();
      this.dlgBrowse = new OpenFileDialog();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.lblAttribIndex = new Label();
      this.btnAttribTable = new Button();
      this.btnAttribIndex = new Button();
      this.Button1 = new Button();
      this.udAttribRevision.BeginInit();
      this.SuspendLayout();
      Point point = new Point(208, 159);
      this.lblAttribTableCount.Location = point;
      this.lblAttribTableCount.Name = "lblAttribTableCount";
      Size size = new Size(132, 18);
      this.lblAttribTableCount.Size = size;
      this.lblAttribTableCount.TabIndex = 21;
      this.lblAttribTableCount.Text = "Tables:";
      point = new Point(9, 159);
      this.lblAttribDate.Location = point;
      this.lblAttribDate.Name = "lblAttribDate";
      size = new Size(175, 18);
      this.lblAttribDate.Size = size;
      this.lblAttribDate.TabIndex = 20;
      this.lblAttribDate.Text = "Date:";
      point = new Point(346, 159);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(65, 18);
      this.Label1.Size = size;
      this.Label1.TabIndex = 19;
      this.Label1.Text = "Revision:";
      this.Label1.TextAlign = ContentAlignment.TopRight;
      point = new Point(417, 157);
      this.udAttribRevision.Location = point;
      this.udAttribRevision.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.udAttribRevision.Name = "udAttribRevision";
      size = new Size(116, 20);
      this.udAttribRevision.Size = size;
      this.udAttribRevision.TabIndex = 18;
      this.lblAttribTables.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 99);
      this.lblAttribTables.Location = point;
      this.lblAttribTables.Name = "lblAttribTables";
      size = new Size(521, 46);
      this.lblAttribTables.Size = size;
      this.lblAttribTables.TabIndex = 15;
      this.lblAttribTables.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 154);
      this.btnAttribLoad.Location = point;
      this.btnAttribLoad.Name = "btnAttribLoad";
      size = new Size(86, 23);
      this.btnAttribLoad.Size = size;
      this.btnAttribLoad.TabIndex = 13;
      this.btnAttribLoad.Text = "Import";
      this.btnAttribLoad.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      point = new Point(12, 83);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(150, 14);
      this.Label4.Size = size;
      this.Label4.TabIndex = 17;
      this.Label4.Text = "Tables:";
      point = new Point(12, 9);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(150, 14);
      this.Label3.Size = size;
      this.Label3.TabIndex = 16;
      this.Label3.Text = "Index:";
      this.lblAttribIndex.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 25);
      this.lblAttribIndex.Location = point;
      this.lblAttribIndex.Name = "lblAttribIndex";
      size = new Size(521, 46);
      this.lblAttribIndex.Size = size;
      this.lblAttribIndex.TabIndex = 14;
      this.lblAttribIndex.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 99);
      this.btnAttribTable.Location = point;
      this.btnAttribTable.Name = "btnAttribTable";
      size = new Size(86, 23);
      this.btnAttribTable.Size = size;
      this.btnAttribTable.TabIndex = 12;
      this.btnAttribTable.Text = "Browse";
      this.btnAttribTable.UseVisualStyleBackColor = true;
      point = new Point(539, 25);
      this.btnAttribIndex.Location = point;
      this.btnAttribIndex.Name = "btnAttribIndex";
      size = new Size(86, 23);
      this.btnAttribIndex.Size = size;
      this.btnAttribIndex.TabIndex = 11;
      this.btnAttribIndex.Text = "Browse...";
      this.btnAttribIndex.UseVisualStyleBackColor = true;
      point = new Point(539, 197);
      this.Button1.Location = point;
      this.Button1.Name = "Button1";
      size = new Size(86, 23);
      this.Button1.Size = size;
      this.Button1.TabIndex = 22;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size = new Size(631, 232);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.lblAttribTableCount);
      this.Controls.Add((Control) this.lblAttribDate);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.udAttribRevision);
      this.Controls.Add((Control) this.lblAttribTables);
      this.Controls.Add((Control) this.btnAttribLoad);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.lblAttribIndex);
      this.Controls.Add((Control) this.btnAttribTable);
      this.Controls.Add((Control) this.btnAttribIndex);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_mod);
      this.ShowInTaskbar = false;
      this.Text = "Modifier Table Import";
      this.udAttribRevision.EndInit();
      this.ResumeLayout(false);
    }
  }
}
