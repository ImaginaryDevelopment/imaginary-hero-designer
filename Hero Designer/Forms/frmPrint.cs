
using Base.Document_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmPrint : Form
    {
        Print _printer;

        public frmPrint()
        {
            this.Load += new EventHandler(this.frmPrint_Load);
            this.InitializeComponent();
            var componentResourceManager = new ComponentResourceManager(typeof(frmPrint));
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmPrint);
        }

        void btnCancel_Click(object sender, EventArgs e) => this.Close();

        void btnLayout_Click(object sender, EventArgs e)
        {
            this.dlgSetup.Document = this._printer.Document;
            this.dlgSetup.ShowDialog();
            this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            MidsContext.Config.LastPrinter = this._printer.Document.PrinterSettings.PrinterName;
            MidsContext.Config.PrintHistory = this.chkPrintHistory.Checked;
            MidsContext.Config.DisablePrintProfileEnh = !this.chkProfileEnh.Checked;
            MidsContext.Config.I9.DisablePrintIOLevels = !this.chkPrintHistoryEnh.Checked;
            MidsContext.Config.PrintProfile = !this.rbProfileShort.Checked ? (!this.rbProfileLong.Checked ? ConfigData.PrintOptionProfile.None : ConfigData.PrintOptionProfile.MultiPage) : ConfigData.PrintOptionProfile.SinglePage;
            if (this.rbProfileNone.Checked & !this.chkPrintHistory.Checked)
            {
                Interaction.MsgBox("You have not selected anything to print!", MsgBoxStyle.Information, "Eh?");
            }
            else
            {
                this._printer.InitiatePrint();
                this.Close();
            }
        }

        void btnPrinter_Click(object sender, EventArgs e)
        {
            new PrintDialog()
            {
                Document = this._printer.Document
            }.ShowDialog();
            this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
        }

        void chkPrintHistory_CheckedChanged(object sender, EventArgs e) => this.chkPrintHistoryEnh.Enabled = this.chkPrintHistory.Checked;

        void frmPrint_Load(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count < 1)
            {
                Interaction.MsgBox("There are no printers installed!", MsgBoxStyle.Information, "Buh...");
                this.Close();
            }
            this._printer = new Print();
            string printerName = "";
            int printerIndex = -1;
            if (this._printer.Document.PrinterSettings.IsDefaultPrinter)
                printerName = this._printer.Document.PrinterSettings.PrinterName;
            for (int index = 0; index <= PrinterSettings.InstalledPrinters.Count - 1; ++index)
            {
                if (PrinterSettings.InstalledPrinters[index] == MidsContext.Config.LastPrinter)
                {
                    printerIndex = index;
                    this._printer.Document.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[index];
                }
                else if (PrinterSettings.InstalledPrinters[index] == printerName & printerIndex < 0)
                {
                    printerIndex = index;
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
            this.chkPrintHistoryEnh.Checked = !MidsContext.Config.I9.DisablePrintIOLevels;
            this.chkPrintHistoryEnh.Enabled = this.chkPrintHistory.Checked;
            this.chkProfileEnh.Checked = !MidsContext.Config.DisablePrintProfileEnh;
            this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
        }

        void rbProfileShort_CheckedChanged(object sender, EventArgs e) => this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
    }
}