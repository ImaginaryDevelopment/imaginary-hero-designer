
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Base.Document_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;

namespace Hero_Designer
{
    public partial class frmPrint : Form
    {
        Print _printer;

        public frmPrint()
        {
            Load += frmPrint_Load;
            InitializeComponent();
            var componentResourceManager = new ComponentResourceManager(typeof(frmPrint));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            Name = nameof(frmPrint);
        }

        void btnCancel_Click(object sender, EventArgs e) => Close();

        void btnLayout_Click(object sender, EventArgs e)
        {
            dlgSetup.Document = _printer.Document;
            dlgSetup.ShowDialog();
            lblPrinter.Text = _printer.Document.PrinterSettings.PrinterName;
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            MidsContext.Config.LastPrinter = _printer.Document.PrinterSettings.PrinterName;
            MidsContext.Config.PrintHistory = chkPrintHistory.Checked;
            MidsContext.Config.DisablePrintProfileEnh = !chkProfileEnh.Checked;
            MidsContext.Config.I9.DisablePrintIOLevels = !chkPrintHistoryEnh.Checked;
            MidsContext.Config.PrintProfile = !rbProfileShort.Checked ? (!rbProfileLong.Checked ? ConfigData.PrintOptionProfile.None : ConfigData.PrintOptionProfile.MultiPage) : ConfigData.PrintOptionProfile.SinglePage;
            if (rbProfileNone.Checked & !chkPrintHistory.Checked)
            {
                Interaction.MsgBox("You have not selected anything to print!", MsgBoxStyle.Information, "Eh?");
            }
            else
            {
                _printer.InitiatePrint();
                Close();
            }
        }

        void btnPrinter_Click(object sender, EventArgs e)
        {
            new PrintDialog
            {
                Document = _printer.Document
            }.ShowDialog();
            lblPrinter.Text = _printer.Document.PrinterSettings.PrinterName;
        }

        void chkPrintHistory_CheckedChanged(object sender, EventArgs e) => chkPrintHistoryEnh.Enabled = chkPrintHistory.Checked;

        void frmPrint_Load(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count < 1)
            {
                Interaction.MsgBox("There are no printers installed!", MsgBoxStyle.Information, "Buh...");
                Close();
            }
            _printer = new Print();
            string printerName = "";
            int printerIndex = -1;
            if (_printer.Document.PrinterSettings.IsDefaultPrinter)
                printerName = _printer.Document.PrinterSettings.PrinterName;
            for (int index = 0; index <= PrinterSettings.InstalledPrinters.Count - 1; ++index)
            {
                if (PrinterSettings.InstalledPrinters[index] == MidsContext.Config.LastPrinter)
                {
                    printerIndex = index;
                    _printer.Document.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[index];
                }
                else if (PrinterSettings.InstalledPrinters[index] == printerName & printerIndex < 0)
                {
                    printerIndex = index;
                    _printer.Document.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[index];
                }
            }
            lblPrinter.Text = _printer.Document.PrinterSettings.PrinterName;
            switch (MidsContext.Config.PrintProfile)
            {
                case ConfigData.PrintOptionProfile.None:
                    rbProfileNone.Checked = true;
                    break;
                case ConfigData.PrintOptionProfile.SinglePage:
                    rbProfileShort.Checked = true;
                    break;
                case ConfigData.PrintOptionProfile.MultiPage:
                    rbProfileLong.Checked = true;
                    break;
                default:
                    rbProfileNone.Checked = true;
                    break;
            }
            chkPrintHistory.Checked = MidsContext.Config.PrintHistory;
            chkPrintHistoryEnh.Checked = !MidsContext.Config.I9.DisablePrintIOLevels;
            chkPrintHistoryEnh.Enabled = chkPrintHistory.Checked;
            chkProfileEnh.Checked = !MidsContext.Config.DisablePrintProfileEnh;
            chkProfileEnh.Enabled = rbProfileShort.Checked;
        }

        void rbProfileShort_CheckedChanged(object sender, EventArgs e) => chkProfileEnh.Enabled = rbProfileShort.Checked;
    }
}