
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
        Button btnCancel;

        Button btnLayout;

        Button btnPrint;

        Button btnPrinter;

        CheckBox chkPrintHistory;
        CheckBox chkPrintHistoryEnh;
        CheckBox chkProfileEnh;
        PageSetupDialog dlgSetup;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        Label lblPrinter;

        Print _printer;
        RadioButton rbProfileLong;
        RadioButton rbProfileNone;

        RadioButton rbProfileShort;

        IContainer components;








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
            int num = (int)this.dlgSetup.ShowDialog();
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
                int num = (int)Interaction.MsgBox((object)"You have not selected anything to print!", MsgBoxStyle.Information, (object)"Eh?");
            }
            else
            {
                this._printer.InitiatePrint();
                this.Close();
            }
        }

        void btnPrinter_Click(object sender, EventArgs e)

        {
            int num = (int)new PrintDialog()
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
                try
                {
                    _printer?.Dispose();

                }
                catch
                {

                }
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
                int num = (int)Interaction.MsgBox((object)"There are no printers installed!", MsgBoxStyle.Information, (object)"Buh...");
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPrint));
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

            this.btnPrinter.Location = new Point(328, 12);
            this.btnPrinter.Name = "btnPrinter";

            this.btnPrinter.Size = new Size(123, 23);
            this.btnPrinter.TabIndex = 1;
            this.btnPrinter.Text = "Properties...";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.GroupBox1.Controls.Add((Control)this.chkProfileEnh);
            this.GroupBox1.Controls.Add((Control)this.rbProfileNone);
            this.GroupBox1.Controls.Add((Control)this.rbProfileLong);
            this.GroupBox1.Controls.Add((Control)this.rbProfileShort);

            this.GroupBox1.Location = new Point(12, 38);
            this.GroupBox1.Name = "GroupBox1";

            this.GroupBox1.Size = new Size(247, 102);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Profile:";
            this.chkProfileEnh.Checked = true;
            this.chkProfileEnh.CheckState = CheckState.Checked;

            this.chkProfileEnh.Location = new Point(110, 45);
            this.chkProfileEnh.Name = "chkProfileEnh";

            this.chkProfileEnh.Size = new Size(131, 20);
            this.chkProfileEnh.TabIndex = 3;
            this.chkProfileEnh.Text = "Show Enhancements";
            this.chkProfileEnh.UseVisualStyleBackColor = true;
            this.rbProfileNone.Checked = true;

            this.rbProfileNone.Location = new Point(6, 19);
            this.rbProfileNone.Name = "rbProfileNone";

            this.rbProfileNone.Size = new Size(200, 20);
            this.rbProfileNone.TabIndex = 2;
            this.rbProfileNone.TabStop = true;
            this.rbProfileNone.Text = "Do Not Print";
            this.rbProfileNone.UseVisualStyleBackColor = true;

            this.rbProfileLong.Location = new Point(6, 71);
            this.rbProfileLong.Name = "rbProfileLong";

            this.rbProfileLong.Size = new Size(200, 20);
            this.rbProfileLong.TabIndex = 1;
            this.rbProfileLong.Text = "Multi-Page (Long Format)";
            this.rbProfileLong.UseVisualStyleBackColor = true;

            this.rbProfileShort.Location = new Point(6, 45);
            this.rbProfileShort.Name = "rbProfileShort";

            this.rbProfileShort.Size = new Size(98, 20);
            this.rbProfileShort.TabIndex = 0;
            this.rbProfileShort.Text = "Single Page";
            this.rbProfileShort.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add((Control)this.chkPrintHistoryEnh);
            this.GroupBox2.Controls.Add((Control)this.chkPrintHistory);

            this.GroupBox2.Location = new Point(265, 67);
            this.GroupBox2.Name = "GroupBox2";

            this.GroupBox2.Size = new Size(186, 73);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Level History:";

            this.chkPrintHistoryEnh.Location = new Point(21, 45);
            this.chkPrintHistoryEnh.Name = "chkPrintHistoryEnh";

            this.chkPrintHistoryEnh.Size = new Size(159, 20);
            this.chkPrintHistoryEnh.TabIndex = 1;
            this.chkPrintHistoryEnh.Text = "Show Invention Levels";
            this.chkPrintHistoryEnh.UseVisualStyleBackColor = true;

            this.chkPrintHistory.Location = new Point(6, 19);
            this.chkPrintHistory.Name = "chkPrintHistory";

            this.chkPrintHistory.Size = new Size(164, 20);
            this.chkPrintHistory.TabIndex = 0;
            this.chkPrintHistory.Text = "Print History Page";
            this.chkPrintHistory.UseVisualStyleBackColor = true;

            this.btnPrint.Location = new Point(107, 145);
            this.btnPrint.Name = "btnPrint";

            this.btnPrint.Size = new Size(90, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = DialogResult.Cancel;

            this.btnCancel.Location = new Point(203, 145);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new Size(90, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.dlgSetup.AllowMargins = false;
            this.dlgSetup.AllowOrientation = false;
            this.dlgSetup.EnableMetric = true;
            this.lblPrinter.BorderStyle = BorderStyle.Fixed3D;

            this.lblPrinter.Location = new Point(12, 12);
            this.lblPrinter.Name = "lblPrinter";

            this.lblPrinter.Size = new Size(310, 23);
            this.lblPrinter.TabIndex = 7;
            this.lblPrinter.Text = "No Printer";
            this.lblPrinter.TextAlign = ContentAlignment.MiddleLeft;

            this.btnLayout.Location = new Point(327, 38);
            this.btnLayout.Name = "btnLayout";

            this.btnLayout.Size = new Size(123, 23);
            this.btnLayout.TabIndex = 8;
            this.btnLayout.Text = "Layout...";
            this.btnLayout.UseVisualStyleBackColor = true;
            this.AcceptButton = (IButtonControl)this.btnPrint;
            this.AutoScaleMode = AutoScaleMode.None;
            this.CancelButton = (IButtonControl)this.btnCancel;

            this.ClientSize = new Size(462, 180);
            this.Controls.Add((Control)this.btnLayout);
            this.Controls.Add((Control)this.lblPrinter);
            this.Controls.Add((Control)this.btnCancel);
            this.Controls.Add((Control)this.btnPrint);
            this.Controls.Add((Control)this.GroupBox2);
            this.Controls.Add((Control)this.GroupBox1);
            this.Controls.Add((Control)this.btnPrinter);
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmPrint);
            this.Text = "Print";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnCancel.Click += btnCancel_Click;
                this.btnLayout.Click += btnLayout_Click;
                this.btnPrint.Click += btnPrint_Click;
                this.btnPrinter.Click += btnPrinter_Click;
                this.chkPrintHistory.CheckedChanged += chkPrintHistory_CheckedChanged;
                this.rbProfileShort.CheckedChanged += rbProfileShort_CheckedChanged;
            }
            // finished with events
            this.ResumeLayout(false);
        }

        void rbProfileShort_CheckedChanged(object sender, EventArgs e)

        {
            this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
        }
    }
}
