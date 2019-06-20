
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
  public class frmImport_SalvageReq : Form
  {
    [AccessedThroughProperty("btnClose")]
    private Button _btnClose;
    [AccessedThroughProperty("btnFile")]
    private Button _btnFile;
    [AccessedThroughProperty("btnImport")]
    private Button _btnImport;
    [AccessedThroughProperty("dlgBrowse")]
    private OpenFileDialog _dlgBrowse;
    [AccessedThroughProperty("lblFile")]
    private Label _lblFile;
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

    public frmImport_SalvageReq()
    {
      this.Load += new EventHandler(this.frmImport_SalvageReq_Load);
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

    private void frmImport_SalvageReq_Load(object sender, EventArgs e)
    {
      this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile.Replace("powersets", "baserecipes");
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_SalvageReq));
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
      this.btnClose.TabIndex = 56;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      point = new Point(539, 38);
      this.btnImport.Location = point;
      this.btnImport.Name = "btnImport";
      size = new Size(86, 23);
      this.btnImport.Size = size;
      this.btnImport.TabIndex = 54;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.lblFile.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 9);
      this.lblFile.Location = point;
      this.lblFile.Name = "lblFile";
      size = new Size(521, 46);
      this.lblFile.Size = size;
      this.lblFile.TabIndex = 55;
      this.lblFile.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(539, 9);
      this.btnFile.Location = point;
      this.btnFile.Name = "btnFile";
      size = new Size(86, 23);
      this.btnFile.Size = size;
      this.btnFile.TabIndex = 53;
      this.btnFile.Text = "Browse...";
      this.btnFile.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size = new Size(635, 117);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.lblFile);
      this.Controls.Add((Control) this.btnFile);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_SalvageReq);
      this.ShowInTaskbar = false;
      this.Text = "Salvage Requirement Import";
      this.ResumeLayout(false);
    }

    private bool ParseClasses(string iFileName)
    {
      int num1 = 0;
      StreamReader iStream1;
      try
      {
        iStream1 = new StreamReader(iFileName);
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
      string iLine1;
      do
      {
        iLine1 = FileIO.ReadLineUnlimited(iStream1, char.MinValue);
        if (iLine1 != null && !iLine1.StartsWith("#"))
        {
          ++num5;
          if (num5 >= 11)
          {
            this.BusyMsg("Pass 1 of 2: " + Strings.Format((object) num3, "###,##0") + " records scanned.\r\n" + Strings.Format((object) num1, "###,##0") + " records matched, " + Strings.Format((object) num4, "###,##0") + " records discarded.");
            num5 = 0;
          }
          string[] array = CSV.ToArray(iLine1);
          if (array.Length > 1)
          {
            int subIndex = 0;
            int index1 = DatabaseAPI.NidFromUidRecipe(array[0], ref subIndex);
            if (index1 > -1 & index1 < DatabaseAPI.Database.Recipes.Length & subIndex > -1)
            {
              DatabaseAPI.Database.Recipes[index1].Item[subIndex].Salvage = new string[7];
              DatabaseAPI.Database.Recipes[index1].Item[subIndex].SalvageIdx = new int[7];
              DatabaseAPI.Database.Recipes[index1].Item[subIndex].Count = new int[7];
              int index2 = 0;
              do
              {
                DatabaseAPI.Database.Recipes[index1].Item[subIndex].Salvage[index2] = "";
                DatabaseAPI.Database.Recipes[index1].Item[subIndex].SalvageIdx[index2] = -1;
                DatabaseAPI.Database.Recipes[index1].Item[subIndex].Count[index2] = 0;
                ++index2;
              }
              while (index2 <= 6);
              ++num1;
            }
            else
              ++num4;
          }
          ++num3;
        }
      }
      while (iLine1 != null);
      iStream1.Close();
      StreamReader iStream2;
      try
      {
        iStream2 = new StreamReader(iFileName);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "IO CSV Not Opened");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      int num6 = 0;
      int num7 = 0;
      try
      {
        string iLine2;
        do
        {
          iLine2 = FileIO.ReadLineUnlimited(iStream2, char.MinValue);
          if (iLine2 != null && !iLine2.StartsWith("#"))
          {
            ++num5;
            if (num5 >= 11)
            {
              this.BusyMsg("Pass 2 of 2: " + Strings.Format((object) num3, "###,##0") + " records scanned.\r\n" + Strings.Format((object) num6, "###,##0") + " records done, " + Strings.Format((object) num7, "###,##0") + " records discarded.");
              num5 = 0;
            }
            string[] array = CSV.ToArray(iLine2);
            if (array.Length > 1)
            {
              int subIndex = 0;
              int index1 = DatabaseAPI.NidFromUidRecipe(array[0], ref subIndex);
              if (index1 > -1 & index1 < DatabaseAPI.Database.Recipes.Length & subIndex > -1)
              {
                int index2 = -1;
                int num2 = DatabaseAPI.Database.Recipes[index1].Item[subIndex].Count.Length - 1;
                for (int index3 = 0; index3 <= num2; ++index3)
                {
                  if (DatabaseAPI.Database.Recipes[index1].Item[subIndex].Count[index3] == 0)
                  {
                    index2 = index3;
                    break;
                  }
                }
                if (index2 > -1)
                {
                  DatabaseAPI.Database.Recipes[index1].Item[subIndex].Count[index2] = (int) Math.Round(Conversion.Val(array[1]));
                  DatabaseAPI.Database.Recipes[index1].Item[subIndex].Salvage[index2] = array[2];
                  DatabaseAPI.Database.Recipes[index1].Item[subIndex].SalvageIdx[index2] = -1;
                }
                ++num6;
              }
              else
                ++num7;
            }
            ++num3;
          }
        }
        while (iLine2 != null);
        this.BusyMsg("Reassigning salvage IDs and saving...");
        DatabaseAPI.AssignRecipeSalvageIDs();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        iStream2.Close();
        int num2 = (int) Interaction.MsgBox((object) exception.Message, MsgBoxStyle.Critical, (object) "IO CSV Parse Error");
        bool flag = false;
        ProjectData.ClearProjectError();
        return flag;
      }
      DatabaseAPI.SaveRecipes();
      this.DisplayInfo();
      int num8 = (int) Interaction.MsgBox((object) ("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num6) + "\r\nRejected: " + Conversions.ToString(num7)), MsgBoxStyle.Information, (object) "File Parsed");
      return true;
    }
  }
}
