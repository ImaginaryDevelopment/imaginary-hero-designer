using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Document_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class frmPrint : Form
    {

    
    
        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= eventHandler;
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnLayout
        {
            get
            {
                return this._btnLayout;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnLayout_Click);
                if (this._btnLayout != null)
                {
                    this._btnLayout.Click -= eventHandler;
                }
                this._btnLayout = value;
                if (this._btnLayout != null)
                {
                    this._btnLayout.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPrint
        {
            get
            {
                return this._btnPrint;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPrint_Click);
                if (this._btnPrint != null)
                {
                    this._btnPrint.Click -= eventHandler;
                }
                this._btnPrint = value;
                if (this._btnPrint != null)
                {
                    this._btnPrint.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPrinter
        {
            get
            {
                return this._btnPrinter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPrinter_Click);
                if (this._btnPrinter != null)
                {
                    this._btnPrinter.Click -= eventHandler;
                }
                this._btnPrinter = value;
                if (this._btnPrinter != null)
                {
                    this._btnPrinter.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkPrintHistory
        {
            get
            {
                return this._chkPrintHistory;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkPrintHistory_CheckedChanged);
                if (this._chkPrintHistory != null)
                {
                    this._chkPrintHistory.CheckedChanged -= eventHandler;
                }
                this._chkPrintHistory = value;
                if (this._chkPrintHistory != null)
                {
                    this._chkPrintHistory.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkPrintHistoryEnh
        {
            get
            {
                return this._chkPrintHistoryEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkPrintHistoryEnh = value;
            }
        }


    
    
        internal virtual CheckBox chkProfileEnh
        {
            get
            {
                return this._chkProfileEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkProfileEnh = value;
            }
        }


    
    
        internal virtual PageSetupDialog dlgSetup
        {
            get
            {
                return this._dlgSetup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgSetup = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }
        }


    
    
        internal virtual Label lblPrinter
        {
            get
            {
                return this._lblPrinter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPrinter = value;
            }
        }


    
    
        internal virtual RadioButton rbProfileLong
        {
            get
            {
                return this._rbProfileLong;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbProfileLong = value;
            }
        }


    
    
        internal virtual RadioButton rbProfileNone
        {
            get
            {
                return this._rbProfileNone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbProfileNone = value;
            }
        }


    
    
        internal virtual RadioButton rbProfileShort
        {
            get
            {
                return this._rbProfileShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbProfileShort_CheckedChanged);
                if (this._rbProfileShort != null)
                {
                    this._rbProfileShort.CheckedChanged -= eventHandler;
                }
                this._rbProfileShort = value;
                if (this._rbProfileShort != null)
                {
                    this._rbProfileShort.CheckedChanged += eventHandler;
                }
            }
        }


        public frmPrint()
        {
            base.Load += this.frmPrint_Load;
            this.InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void btnLayout_Click(object sender, EventArgs e)
        {
            this.dlgSetup.Document = this._printer.Document;
            this.dlgSetup.ShowDialog();
            this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            MidsContext.Config.LastPrinter = this._printer.Document.PrinterSettings.PrinterName;
            MidsContext.Config.PrintHistory = this.chkPrintHistory.Checked;
            MidsContext.Config.PrintProfileEnh = this.chkProfileEnh.Checked;
            MidsContext.Config.PrintHistoryIOLevels = this.chkPrintHistoryEnh.Checked;
            if (this.rbProfileShort.Checked)
            {
                MidsContext.Config.PrintProfile = ConfigData.PrintOptionProfile.SinglePage;
            }
            else if (this.rbProfileLong.Checked)
            {
                MidsContext.Config.PrintProfile = ConfigData.PrintOptionProfile.MultiPage;
            }
            else
            {
                MidsContext.Config.PrintProfile = ConfigData.PrintOptionProfile.None;
            }
            if (this.rbProfileNone.Checked & !this.chkPrintHistory.Checked)
            {
                Interaction.MsgBox("You have not selected anything to print!", MsgBoxStyle.Information, "Eh?");
            }
            else
            {
                this._printer.InitiatePrint();
                base.Close();
            }
        }


        private void btnPrinter_Click(object sender, EventArgs e)
        {
            new PrintDialog
            {
                Document = this._printer.Document
            }.ShowDialog();
            this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
        }


        private void chkPrintHistory_CheckedChanged(object sender, EventArgs e)
        {
            this.chkPrintHistoryEnh.Enabled = this.chkPrintHistory.Checked;
        }


        private void frmPrint_Load(object sender, EventArgs e)
        {
            if (PrinterSettings.InstalledPrinters.Count < 1)
            {
                Interaction.MsgBox("There are no printers installed!", MsgBoxStyle.Information, "Buh...");
                base.Close();
            }
            this._printer = new Print();
            string str = "";
            int num = -1;
            if (this._printer.Document.PrinterSettings.IsDefaultPrinter)
            {
                str = this._printer.Document.PrinterSettings.PrinterName;
            }
            int num2 = PrinterSettings.InstalledPrinters.Count - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (PrinterSettings.InstalledPrinters[index] == MidsContext.Config.LastPrinter)
                {
                    num = index;
                    this._printer.Document.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[index];
                }
                else if (PrinterSettings.InstalledPrinters[index] == str & num < 0)
                {
                    num = index;
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


        private void rbProfileShort_CheckedChanged(object sender, EventArgs e)
        {
            this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
        }


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnLayout")]
        private Button _btnLayout;


        [AccessedThroughProperty("btnPrint")]
        private Button _btnPrint;


        [AccessedThroughProperty("btnPrinter")]
        private Button _btnPrinter;


        [AccessedThroughProperty("chkPrintHistory")]
        private CheckBox _chkPrintHistory;


        [AccessedThroughProperty("chkPrintHistoryEnh")]
        private CheckBox _chkPrintHistoryEnh;


        [AccessedThroughProperty("chkProfileEnh")]
        private CheckBox _chkProfileEnh;


        [AccessedThroughProperty("dlgSetup")]
        private PageSetupDialog _dlgSetup;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("lblPrinter")]
        private Label _lblPrinter;


        private Print _printer;


        [AccessedThroughProperty("rbProfileLong")]
        private RadioButton _rbProfileLong;


        [AccessedThroughProperty("rbProfileNone")]
        private RadioButton _rbProfileNone;


        [AccessedThroughProperty("rbProfileShort")]
        private RadioButton _rbProfileShort;
    }
}
