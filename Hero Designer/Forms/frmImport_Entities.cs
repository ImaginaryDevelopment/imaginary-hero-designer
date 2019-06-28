
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
        Button btnClose;

        Button btnFile;

        Button btnImport;
        OpenFileDialog dlgBrowse;
        Label Label8;
        Label lblDate;
        Label lblFile;
        NumericUpDown udRevision;

    frmBusy bFrm;

    IContainer components;

    string FullFileName;






    public frmImport_Entities()
    {
      this.Load += new EventHandler(this.frmImport_Entities_Load);
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

    void frmImport_Entities_Load(object sender, EventArgs e)

    {
      this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

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
