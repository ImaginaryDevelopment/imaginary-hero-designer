// Decompiled with JetBrains decompiler
// Type: Hero_Designer.frmImport_Entities
// Assembly: Hero Designer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 971EB14D-7E2B-4ADC-89DF-A9C8225AA28C
// Assembly location: C:\Users\Xbass\Desktop\Hero Designer.exe

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
  public class frmImport_Entities : Form
  {
    [AccessedThroughProperty("btnClose")]
    private Button _btnClose;
    [AccessedThroughProperty("btnFile")]
    private Button _btnFile;
    [AccessedThroughProperty("btnImport")]
    private Button _btnImport;
    [AccessedThroughProperty("dlgBrowse")]
    private OpenFileDialog _dlgBrowse;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("lblDate")]
    private Label _lblDate;
    [AccessedThroughProperty("lblFile")]
    private Label _lblFile;
    [AccessedThroughProperty("udRevision")]
    private NumericUpDown _udRevision;
    private frmBusy bFrm;
    private IContainer components;
    private string FullFileName;

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

    public frmImport_Entities()
    {
      this.Load += new EventHandler(this.frmImport_Entities_Load);
      this.FullFileName = "";
      this.InitializeComponent();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnFile_Click(object sender, EventArgs e)
    {
      this.dlgBrowse.FileName = this.FullFileName;
      if (this.dlgBrowse.ShowDialog((IWin32Window) this) == DialogResult.OK)
        this.FullFileName = this.dlgBrowse.FileName;
      this.BusyHide();
      this.DisplayInfo();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
      this.ParseClasses(this.FullFileName);
      this.BusyHide();
      this.DisplayInfo();
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
      this.lblDate.Text = "Date: " + Strings.Format((object) DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
      this.udRevision.Value = new Decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
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

    private void frmImport_Entities_Load(object sender, EventArgs e)
    {
      this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_Entities));
      this.Label8 = new Label();
      this.lblDate = new Label();
      this.udRevision = new NumericUpDown();
      this.btnClose = new Button();
      this.btnImport = new Button();
      this.lblFile = new Label();
      this.btnFile = new Button();
      this.dlgBrowse = new OpenFileDialog();
      this.udRevision.BeginInit();
      this.SuspendLayout();
      Point point = new Point(346, 85);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      Size size = new Size(65, 18);
      this.Label8.Size = size;
      this.Label8.TabIndex = 62;
      this.Label8.Text = "Revision:";
      this.Label8.TextAlign = ContentAlignment.TopRight;
      point = new Point(9, 85);
      this.lblDate.Location = point;
      this.lblDate.Name = "lblDate";
      size = new Size(175, 18);
      this.lblDate.Size = size;
      this.lblDate.TabIndex = 61;
      this.lblDate.Text = "Date:";
      point = new Point(417, 83);
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
      this.udRevision.TabIndex = 60;
      point = new Point(539, 81);
      this.btnClose.Location = point;
      this.btnClose.Name = "btnClose";
      size = new Size(86, 23);
      this.btnClose.Size = size;
      this.btnClose.TabIndex = 59;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      point = new Point(539, 38);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(86, 23);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 57;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.lblFile.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 9);
      this.lblFile.Location = point;
      this.lblFile.Name = "lblFile";
      size = new Size(521, 46);
      this.lblFile.Size = size;
      this.lblFile.TabIndex = 58;
      this.lblFile.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 9);
      this.btnFile.Location = point;
      this.btnFile.Name = "btnFile";
      size = new Size(86, 23);
      this.btnFile.Size = size;
      this.btnFile.TabIndex = 56;
      this.btnFile.Text = "Browse...";
      this.btnFile.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size = new Size(646, 120);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.lblDate);
      this.Controls.Add((Control) this.udRevision);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.lblFile);
      this.Controls.Add((Control) this.btnFile);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_Entities);
      this.ShowInTaskbar = false;
      this.Text = "Import Entities";
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
        int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "IO CSV Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      int num3 = 0;
      int num4 = 0;
      int num5 = 0;
      try
      {
        string iLine;
        do
        {
          iLine = FileIO.ReadLineUnlimited(iStream, char.MinValue);
          if (iLine != null)
          {
            if (!iLine.StartsWith("#"))
            {
              ++num5;
              if (num5 >= 9)
              {
                this.BusyMsg(Strings.Format((object) num3, "###,##0") + " records parsed.");
                num5 = 0;
              }
              string[] array = CSV.ToArray(iLine);
              string uidEntity = "";
              if (array.Length > 1)
              {
                int index = -2;
                if (array[0].StartsWith("Pets."))
                {
                  uidEntity = "Pets_" + array[1];
                  index = DatabaseAPI.NidFromUidEntity(uidEntity);
                }
                else if (array[0].StartsWith("Villain_Pets."))
                {
                  uidEntity = "Pets_" + array[1];
                  index = DatabaseAPI.NidFromUidEntity(uidEntity);
                }
                if (index > -2)
                {
                  if (index < 0)
                  {
                    IDatabase database = DatabaseAPI.Database;
                    SummonedEntity[] summonedEntityArray = (SummonedEntity[]) Utils.CopyArray((Array) database.Entities, (Array) new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
                    database.Entities = summonedEntityArray;
                    DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity();
                    SummonedEntity entity = DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1];
                    entity.UID = uidEntity;
                    entity.nID = DatabaseAPI.Database.Entities.Length - 1;
                    index = entity.nID;
                  }
                  SummonedEntity entity1 = DatabaseAPI.Database.Entities[index];
                  entity1.DisplayName = array[2];
                  entity1.ClassName = "Class_Minion_Pets";
                  entity1.nClassID = DatabaseAPI.NidFromUidClass(entity1.ClassName);
                  entity1.EntityType = Enums.eSummonEntity.Pet;
                  entity1.PowersetFullName = new string[1];
                  entity1.nPowerset = new int[1];
                  entity1.PowersetFullName[0] = array[0];
                  entity1.nPowerset[0] = DatabaseAPI.NidFromUidPowerset(entity1.PowersetFullName[0]);
                  entity1.UpgradePowerFullName = new string[0];
                  entity1.nUpgradePower = new int[0];
                  ++num1;
                }
                else
                  ++num4;
              }
            }
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
        int num2 = (int) Interaction.MsgBox((object) exception.Message, MsgBoxStyle.Critical, (object) "Entity CSV Parse Error");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      iStream.Close();
      DatabaseAPI.SaveMainDatabase();
      this.DisplayInfo();
      int num6 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, (object) "File Parsed");
      return true;
    }
  }
}
