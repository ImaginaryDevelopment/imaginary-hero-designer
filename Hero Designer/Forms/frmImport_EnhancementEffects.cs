
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
        Button btnClose;

        Button btnFile;

        Button btnImport;
        OpenFileDialog dlgBrowse;
        Label lblFile;

    frmBusy bFrm;

    IContainer components;

    string FullFileName;



    public frmImport_EnhancementEffects()
    {
      this.Load += new EventHandler(this.frmImport_EnhancementEffects_Load);
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

    void frmImport_EnhancementEffects_Load(object sender, EventArgs e)

    {
      this.FullFileName = DatabaseAPI.Database.PowerEffectVersion.SourceFile;
      this.DisplayInfo();
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImport_EnhancementEffects));
      this.btnClose = new Button();
      this.btnImport = new Button();
      this.lblFile = new Label();
      this.btnFile = new Button();
      this.dlgBrowse = new OpenFileDialog();
      this.SuspendLayout();

      this.btnClose.Location = new Point(539, 81);
      this.btnClose.Name = "btnClose";

      this.btnClose.Size = new Size(86, 23);
      this.btnClose.TabIndex = 56;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;

      this.btnImport.Location = new Point(539, 38);
      this.btnImport.Name = "btnImport";

      this.btnImport.Size = new Size(86, 23);
      this.btnImport.TabIndex = 54;
      this.btnImport.Text = "Import";
      this.btnImport.UseVisualStyleBackColor = true;
      this.lblFile.BorderStyle = BorderStyle.Fixed3D;

      this.lblFile.Location = new Point(12, 9);
      this.lblFile.Name = "lblFile";

      this.lblFile.Size = new Size(521, 46);
      this.lblFile.TabIndex = 55;
      this.lblFile.TextAlign = ContentAlignment.MiddleLeft;

      this.btnFile.Location = new Point(539, 9);
      this.btnFile.Name = "btnFile";

      this.btnFile.Size = new Size(86, 23);
      this.btnFile.TabIndex = 53;
      this.btnFile.Text = "Browse...";
      this.btnFile.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
      this.AutoScaleDimensions = new SizeF(6f, 13f);

      this.ClientSize = new Size(636, 112);
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
