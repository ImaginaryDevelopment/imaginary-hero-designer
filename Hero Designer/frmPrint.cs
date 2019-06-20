
using Base.Document_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  [DesignerGenerated]
  public class frmPrint : Form
  {
    [AccessedThroughProperty("btnCancel")]
    Button _btnCancel;

    [AccessedThroughProperty("btnLayout")]
    Button _btnLayout;

    [AccessedThroughProperty("btnPrint")]
    Button _btnPrint;

    [AccessedThroughProperty("btnPrinter")]
    Button _btnPrinter;

    [AccessedThroughProperty("chkPrintHistory")]
    CheckBox _chkPrintHistory;

    [AccessedThroughProperty("chkPrintHistoryEnh")]
    CheckBox _chkPrintHistoryEnh;

    [AccessedThroughProperty("chkProfileEnh")]
    CheckBox _chkProfileEnh;

    [AccessedThroughProperty("dlgSetup")]
    PageSetupDialog _dlgSetup;

    [AccessedThroughProperty("GroupBox1")]
    GroupBox _GroupBox1;

    [AccessedThroughProperty("GroupBox2")]
    GroupBox _GroupBox2;

    [AccessedThroughProperty("lblPrinter")]
    Label _lblPrinter;

    Print _printer;

    [AccessedThroughProperty("rbProfileLong")]
    RadioButton _rbProfileLong;

    [AccessedThroughProperty("rbProfileNone")]
    RadioButton _rbProfileNone;

    [AccessedThroughProperty("rbProfileShort")]
    RadioButton _rbProfileShort;

    IContainer components;


    Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        if (this._btnCancel != null)
          this._btnCancel.Click -= eventHandler;
        this._btnCancel = value;
        if (this._btnCancel == null)
          return;
        this._btnCancel.Click += eventHandler;
      }
    }

    Button btnLayout
    {
      get
      {
        return this._btnLayout;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnLayout_Click);
        if (this._btnLayout != null)
          this._btnLayout.Click -= eventHandler;
        this._btnLayout = value;
        if (this._btnLayout == null)
          return;
        this._btnLayout.Click += eventHandler;
      }
    }

    Button btnPrint
    {
      get
      {
        return this._btnPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
        if (this._btnPrint != null)
          this._btnPrint.Click -= eventHandler;
        this._btnPrint = value;
        if (this._btnPrint == null)
          return;
        this._btnPrint.Click += eventHandler;
      }
    }

    Button btnPrinter
    {
      get
      {
        return this._btnPrinter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrinter_Click);
        if (this._btnPrinter != null)
          this._btnPrinter.Click -= eventHandler;
        this._btnPrinter = value;
        if (this._btnPrinter == null)
          return;
        this._btnPrinter.Click += eventHandler;
      }
    }

    CheckBox chkPrintHistory
    {
      get
      {
        return this._chkPrintHistory;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkPrintHistory_CheckedChanged);
        if (this._chkPrintHistory != null)
          this._chkPrintHistory.CheckedChanged -= eventHandler;
        this._chkPrintHistory = value;
        if (this._chkPrintHistory == null)
          return;
        this._chkPrintHistory.CheckedChanged += eventHandler;
      }
    }

    CheckBox chkPrintHistoryEnh
    {
      get
      {
        return this._chkPrintHistoryEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chkPrintHistoryEnh = value;
      }
    }

    CheckBox chkProfileEnh
    {
      get
      {
        return this._chkProfileEnh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._chkProfileEnh = value;
      }
    }

    PageSetupDialog dlgSetup
    {
      get
      {
        return this._dlgSetup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._dlgSetup = value;
      }
    }

    GroupBox GroupBox1
    {
      get
      {
        return this._GroupBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._GroupBox1 = value;
      }
    }

    GroupBox GroupBox2
    {
      get
      {
        return this._GroupBox2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._GroupBox2 = value;
      }
    }

    Label lblPrinter
    {
      get
      {
        return this._lblPrinter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblPrinter = value;
      }
    }

    RadioButton rbProfileLong
    {
      get
      {
        return this._rbProfileLong;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._rbProfileLong = value;
      }
    }

    RadioButton rbProfileNone
    {
      get
      {
        return this._rbProfileNone;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._rbProfileNone = value;
      }
    }

    RadioButton rbProfileShort
    {
      get
      {
        return this._rbProfileShort;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbProfileShort_CheckedChanged);
        if (this._rbProfileShort != null)
          this._rbProfileShort.CheckedChanged -= eventHandler;
        this._rbProfileShort = value;
        if (this._rbProfileShort == null)
          return;
        this._rbProfileShort.CheckedChanged += eventHandler;
      }
    }

    public frmPrint()
    {
      this.Load += new EventHandler(this.frmPrint_Load);
      this.InitializeComponent();
    }

    void btnCancel_Click(object sender, EventArgs e)

    {
      this.Close();
    }

    void btnLayout_Click(object sender, EventArgs e)

    {
      this.dlgSetup.Document = this._printer.Document;
      int num = (int) this.dlgSetup.ShowDialog();
      this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
    }

    void btnPrint_Click(object sender, EventArgs e)

    {
      MidsContext.Config.LastPrinter = this._printer.Document.PrinterSettings.PrinterName;
      MidsContext.Config.PrintHistory = this.chkPrintHistory.Checked;
      MidsContext.Config.PrintProfileEnh = this.chkProfileEnh.Checked;
      MidsContext.Config.PrintHistoryIOLevels = this.chkPrintHistoryEnh.Checked;
      MidsContext.Config.PrintProfile = !this.rbProfileShort.Checked ? (!this.rbProfileLong.Checked ? ConfigData.PrintOptionProfile.None : ConfigData.PrintOptionProfile.MultiPage) : ConfigData.PrintOptionProfile.SinglePage;
      if (this.rbProfileNone.Checked & !this.chkPrintHistory.Checked)
      {
        int num = (int) Interaction.MsgBox((object) "You have not selected anything to print!", MsgBoxStyle.Information, (object) "Eh?");
      }
      else
      {
        this._printer.InitiatePrint();
        this.Close();
      }
    }

    void btnPrinter_Click(object sender, EventArgs e)

    {
      int num = (int) new PrintDialog()
      {
        Document = this._printer.Document
      }.ShowDialog();
      this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
    }

    void chkPrintHistory_CheckedChanged(object sender, EventArgs e)

    {
      this.chkPrintHistoryEnh.Enabled = this.chkPrintHistory.Checked;
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

    void frmPrint_Load(object sender, EventArgs e)

    {
      if (PrinterSettings.InstalledPrinters.Count < 1)
      {
        int num = (int) Interaction.MsgBox((object) "There are no printers installed!", MsgBoxStyle.Information, (object) "Buh...");
        this.Close();
      }
      this._printer = new Print();
      string str = "";
      int num1 = -1;
      if (this._printer.Document.PrinterSettings.IsDefaultPrinter)
        str = this._printer.Document.PrinterSettings.PrinterName;
      int num2 = PrinterSettings.InstalledPrinters.Count - 1;
      for (int index = 0; index <= num2; ++index)
      {
        if (PrinterSettings.InstalledPrinters[index] == MidsContext.Config.LastPrinter)
        {
          num1 = index;
          this._printer.Document.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[index];
        }
        else if (PrinterSettings.InstalledPrinters[index] == str & num1 < 0)
        {
          num1 = index;
          this._printer.Document.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[index];
        }
      }
      this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
      switch (MidsContext.Config.PrintProfile)
      {
        case ConfigData.PrintOptionProfile.None:
          this.rbProfileNone.Checked = true;
          break;
        case ConfigData.PrintOptionProfile.SinglePage:
          this.rbProfileShort.Checked = true;
          break;
        case ConfigData.PrintOptionProfile.MultiPage:
          this.rbProfileLong.Checked = true;
          break;
        default:
          this.rbProfileNone.Checked = true;
          break;
      }
      this.chkPrintHistory.Checked = MidsContext.Config.PrintHistory;
      this.chkPrintHistoryEnh.Checked = MidsContext.Config.PrintHistoryIOLevels;
      this.chkPrintHistoryEnh.Enabled = this.chkPrintHistory.Checked;
      this.chkProfileEnh.Checked = MidsContext.Config.PrintProfileEnh;
      this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
    }

    [DebuggerStepThrough]
    void InitializeComponent()

    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPrint));
      this.btnPrinter = new Button();
      this.GroupBox1 = new GroupBox();
      this.chkProfileEnh = new CheckBox();
      this.rbProfileNone = new RadioButton();
      this.rbProfileLong = new RadioButton();
      this.rbProfileShort = new RadioButton();
      this.GroupBox2 = new GroupBox();
      this.chkPrintHistoryEnh = new CheckBox();
      this.chkPrintHistory = new CheckBox();
      this.btnPrint = new Button();
      this.btnCancel = new Button();
      this.dlgSetup = new PageSetupDialog();
      this.lblPrinter = new Label();
      this.btnLayout = new Button();
      this.GroupBox1.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(328, 12);
      this.btnPrinter.Location = point;
      this.btnPrinter.Name = "btnPrinter";
      Size size = new Size(123, 23);
      this.btnPrinter.Size = size;
      this.btnPrinter.TabIndex = 1;
      this.btnPrinter.Text = "Properties...";
      this.btnPrinter.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add((Control) this.chkProfileEnh);
      this.GroupBox1.Controls.Add((Control) this.rbProfileNone);
      this.GroupBox1.Controls.Add((Control) this.rbProfileLong);
      this.GroupBox1.Controls.Add((Control) this.rbProfileShort);
      point = new Point(12, 38);
      this.GroupBox1.Location = point;
      this.GroupBox1.Name = "GroupBox1";
      size = new Size(247, 102);
      this.GroupBox1.Size = size;
      this.GroupBox1.TabIndex = 3;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Profile:";
      this.chkProfileEnh.Checked = true;
      this.chkProfileEnh.CheckState = CheckState.Checked;
      point = new Point(110, 45);
      this.chkProfileEnh.Location = point;
      this.chkProfileEnh.Name = "chkProfileEnh";
      size = new Size(131, 20);
      this.chkProfileEnh.Size = size;
      this.chkProfileEnh.TabIndex = 3;
      this.chkProfileEnh.Text = "Show Enhancements";
      this.chkProfileEnh.UseVisualStyleBackColor = true;
      this.rbProfileNone.Checked = true;
      point = new Point(6, 19);
      this.rbProfileNone.Location = point;
      this.rbProfileNone.Name = "rbProfileNone";
      size = new Size(200, 20);
      this.rbProfileNone.Size = size;
      this.rbProfileNone.TabIndex = 2;
      this.rbProfileNone.TabStop = true;
      this.rbProfileNone.Text = "Do Not Print";
      this.rbProfileNone.UseVisualStyleBackColor = true;
      point = new Point(6, 71);
      this.rbProfileLong.Location = point;
      this.rbProfileLong.Name = "rbProfileLong";
      size = new Size(200, 20);
      this.rbProfileLong.Size = size;
      this.rbProfileLong.TabIndex = 1;
      this.rbProfileLong.Text = "Multi-Page (Long Format)";
      this.rbProfileLong.UseVisualStyleBackColor = true;
      point = new Point(6, 45);
      this.rbProfileShort.Location = point;
      this.rbProfileShort.Name = "rbProfileShort";
      size = new Size(98, 20);
      this.rbProfileShort.Size = size;
      this.rbProfileShort.TabIndex = 0;
      this.rbProfileShort.Text = "Single Page";
      this.rbProfileShort.UseVisualStyleBackColor = true;
      this.GroupBox2.Controls.Add((Control) this.chkPrintHistoryEnh);
      this.GroupBox2.Controls.Add((Control) this.chkPrintHistory);
      point = new Point(265, 67);
      this.GroupBox2.Location = point;
      this.GroupBox2.Name = "GroupBox2";
      size = new Size(186, 73);
      this.GroupBox2.Size = size;
      this.GroupBox2.TabIndex = 4;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Level History:";
      point = new Point(21, 45);
      this.chkPrintHistoryEnh.Location = point;
      this.chkPrintHistoryEnh.Name = "chkPrintHistoryEnh";
      size = new Size(159, 20);
      this.chkPrintHistoryEnh.Size = size;
      this.chkPrintHistoryEnh.TabIndex = 1;
      this.chkPrintHistoryEnh.Text = "Show Invention Levels";
      this.chkPrintHistoryEnh.UseVisualStyleBackColor = true;
      point = new Point(6, 19);
      this.chkPrintHistory.Location = point;
      this.chkPrintHistory.Name = "chkPrintHistory";
      size = new Size(164, 20);
      this.chkPrintHistory.Size = size;
      this.chkPrintHistory.TabIndex = 0;
      this.chkPrintHistory.Text = "Print History Page";
      this.chkPrintHistory.UseVisualStyleBackColor = true;
      point = new Point(107, 145);
      this.btnPrint.Location = point;
      this.btnPrint.Name = "btnPrint";
      size = new Size(90, 23);
      this.btnPrint.Size = size;
      this.btnPrint.TabIndex = 5;
      this.btnPrint.Text = "&Print";
      this.btnPrint.UseVisualStyleBackColor = true;
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(203, 145);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(90, 23);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.dlgSetup.AllowMargins = false;
      this.dlgSetup.AllowOrientation = false;
      this.dlgSetup.EnableMetric = true;
      this.lblPrinter.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(12, 12);
      this.lblPrinter.Location = point;
      this.lblPrinter.Name = "lblPrinter";
      size = new Size(310, 23);
      this.lblPrinter.Size = size;
      this.lblPrinter.TabIndex = 7;
      this.lblPrinter.Text = "No Printer";
      this.lblPrinter.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(327, 38);
      this.btnLayout.Location = point;
      this.btnLayout.Name = "btnLayout";
      size = new Size(123, 23);
      this.btnLayout.Size = size;
      this.btnLayout.TabIndex = 8;
      this.btnLayout.Text = "Layout...";
      this.btnLayout.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.btnPrint;
      this.AutoScaleMode = AutoScaleMode.None;
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(462, 180);
      this.ClientSize = size;
      this.Controls.Add((Control) this.btnLayout);
      this.Controls.Add((Control) this.lblPrinter);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnPrint);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.GroupBox1);
      this.Controls.Add((Control) this.btnPrinter);
      this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmPrint);
      this.Text = "Print";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void rbProfileShort_CheckedChanged(object sender, EventArgs e)

    {
      this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
    }
  }
}
