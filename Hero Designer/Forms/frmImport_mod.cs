
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
        Button btnAttribIndex;

        Button btnAttribLoad;

        Button btnAttribTable;

        Button Button1;
        OpenFileDialog dlgBrowse;
        Label Label1;
        Label Label3;
        Label Label4;
        Label lblAttribDate;
        Label lblAttribIndex;
        Label lblAttribTableCount;
        Label lblAttribTables;
        NumericUpDown udAttribRevision;

    IContainer components;










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

      this.lblAttribTableCount.Location = new Point(208, 159);
      this.lblAttribTableCount.Name = "lblAttribTableCount";

      this.lblAttribTableCount.Size = new Size(132, 18);
      this.lblAttribTableCount.TabIndex = 21;
      this.lblAttribTableCount.Text = "Tables:";

      this.lblAttribDate.Location = new Point(9, 159);
      this.lblAttribDate.Name = "lblAttribDate";

      this.lblAttribDate.Size = new Size(175, 18);
      this.lblAttribDate.TabIndex = 20;
      this.lblAttribDate.Text = "Date:";

      this.Label1.Location = new Point(346, 159);
      this.Label1.Name = "Label1";

      this.Label1.Size = new Size(65, 18);
      this.Label1.TabIndex = 19;
      this.Label1.Text = "Revision:";
      this.Label1.TextAlign = ContentAlignment.TopRight;

      this.udAttribRevision.Location = new Point(417, 157);
      this.udAttribRevision.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.udAttribRevision.Name = "udAttribRevision";

      this.udAttribRevision.Size = new Size(116, 20);
      this.udAttribRevision.TabIndex = 18;
      this.lblAttribTables.BorderStyle = BorderStyle.Fixed3D;

      this.lblAttribTables.Location = new Point(12, 99);
      this.lblAttribTables.Name = "lblAttribTables";

      this.lblAttribTables.Size = new Size(521, 46);
      this.lblAttribTables.TabIndex = 15;
      this.lblAttribTables.TextAlign = ContentAlignment.MiddleLeft;

      this.btnAttribLoad.Location = new Point(539, 154);
      this.btnAttribLoad.Name = "btnAttribLoad";

      this.btnAttribLoad.Size = new Size(86, 23);
      this.btnAttribLoad.TabIndex = 13;
      this.btnAttribLoad.Text = "Import";
      this.btnAttribLoad.UseVisualStyleBackColor = true;
      this.dlgBrowse.DefaultExt = "csv";
      this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";

      this.Label4.Location = new Point(12, 83);
      this.Label4.Name = "Label4";

      this.Label4.Size = new Size(150, 14);
      this.Label4.TabIndex = 17;
      this.Label4.Text = "Tables:";

      this.Label3.Location = new Point(12, 9);
      this.Label3.Name = "Label3";

      this.Label3.Size = new Size(150, 14);
      this.Label3.TabIndex = 16;
      this.Label3.Text = "Index:";
      this.lblAttribIndex.BorderStyle = BorderStyle.Fixed3D;

      this.lblAttribIndex.Location = new Point(12, 25);
      this.lblAttribIndex.Name = "lblAttribIndex";

      this.lblAttribIndex.Size = new Size(521, 46);
      this.lblAttribIndex.TabIndex = 14;
      this.lblAttribIndex.TextAlign = ContentAlignment.MiddleLeft;

      this.btnAttribTable.Location = new Point(539, 99);
      this.btnAttribTable.Name = "btnAttribTable";

      this.btnAttribTable.Size = new Size(86, 23);
      this.btnAttribTable.TabIndex = 12;
      this.btnAttribTable.Text = "Browse";
      this.btnAttribTable.UseVisualStyleBackColor = true;

      this.btnAttribIndex.Location = new Point(539, 25);
      this.btnAttribIndex.Name = "btnAttribIndex";

      this.btnAttribIndex.Size = new Size(86, 23);
      this.btnAttribIndex.TabIndex = 11;
      this.btnAttribIndex.Text = "Browse...";
      this.btnAttribIndex.UseVisualStyleBackColor = true;

      this.Button1.Location = new Point(539, 197);
      this.Button1.Name = "Button1";

      this.Button1.Size = new Size(86, 23);
      this.Button1.TabIndex = 22;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;

      this.ClientSize = new Size(631, 232);
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
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.Button1.Click += Button1_Click;
                  this.btnAttribIndex.Click += btnAttribIndex_Click;
                  this.btnAttribLoad.Click += btnAttribLoad_Click;
                  this.btnAttribTable.Click += btnAttribTable_Click;
              }
              // finished with events
      this.ResumeLayout(false);
    }
  }
}
