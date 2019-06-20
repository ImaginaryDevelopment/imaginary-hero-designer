
using Base.Data_Classes;
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
  public class frmImport_EnhancementEffects : Form
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

    public frmImport_EnhancementEffects()
    {
      this.Load += new EventHandler(this.frmImport_EnhancementEffects_Load);
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

    private void frmImport_EnhancementEffects_Load(object sender, EventArgs e)
    {
      this.FullFileName = DatabaseAPI.Database.PowerEffectVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_EnhancementEffects));
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
      size = new Size(636, 112);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnImport);
      this.Controls.Add((Control) this.lblFile);
      this.Controls.Add((Control) this.btnFile);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmImport_EnhancementEffects);
      this.ShowInTaskbar = false;
      this.Text = "Import Enhancement Effects";
      this.ResumeLayout(false);
    }

    private bool ParseClasses(string iFileName)
    {
      StreamReader iStream;
      try
      {
        iStream = new StreamReader(iFileName);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Power CSV Not Opened");
        ProjectData.ClearProjectError();
        return false;
      }
      this.BusyMsg("Working...");
      this.Enabled = false;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = DatabaseAPI.Database.Enhancements.Length - 1;
      for (int index = 0; index <= num5; ++index)
      {
        IEffect[] effectArray = new IEffect[0];
        if (DatabaseAPI.Database.Enhancements[index].Power != null)
          DatabaseAPI.Database.Enhancements[index].Power.Effects = effectArray;
      }
      string str1 = "";
      string str2;
      do
      {
        str2 = FileIO.ReadLineUnlimited(iStream, char.MinValue);
        if (str2 != null)
        {
          ++num3;
          if (num3 >= 101)
          {
            this.BusyMsg(Strings.Format((object) num1, "###,##0") + " records parsed.");
            Application.DoEvents();
            num3 = 0;
          }
          ++num1;
          string[] array = CSV.ToArray(str2);
          if (array.Length > 0 && !str2.StartsWith("#") & array[0].StartsWith("Boosts."))
          {
            bool flag = true;
            string uidEnh = array[0];
            int index = DatabaseAPI.NidFromUidEnhExtended(uidEnh);
            if (index < 0)
              flag = false;
            if (flag)
            {
              ++num4;
              IPower power1 = DatabaseAPI.Database.Enhancements[index].Power;
              power1.FullName = uidEnh;
              string[] strArray = power1.FullName.Split('.');
              power1.GroupName = strArray[0];
              power1.SetName = strArray[1];
              power1.PowerName = strArray[2];
              IPower power2 = power1;
              IEffect[] effectArray = (IEffect[]) Utils.CopyArray((Array) power2.Effects, (Array) new IEffect[power1.Effects.Length + 1]);
              power2.Effects = effectArray;
              power1.Effects[power1.Effects.Length - 1] = (IEffect) new Effect(DatabaseAPI.Database.Enhancements[index].Power);
              power1.Effects[power1.Effects.Length - 1].ImportFromCSV(str2);
            }
            else
            {
              ++num2;
              str1 = str1 + uidEnh + "\r\n";
            }
          }
        }
      }
      while (str2 != null);
      iStream.Close();
      Clipboard.SetDataObject((object) str1);
      int num6 = (int) Interaction.MsgBox((object) ("Import Completed!\r\nTotal Records: " + Conversions.ToString(num1) + "\r\nGood: " + Conversions.ToString(num4) + "\r\nRejected: " + Conversions.ToString(num2) + "\r\nRejected List has been placed on the clipboard. Database will be saved when you click OK"), MsgBoxStyle.Information, (object) "Import Done");
      this.Enabled = true;
      this.BusyHide();
      DatabaseAPI.SaveEnhancementDb();
      this.DisplayInfo();
      return true;
    }
  }
}
