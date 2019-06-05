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
	// Token: 0x0200004F RID: 79
	[DesignerGenerated]
	public partial class frmPrint : Form
	{
		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x0600106D RID: 4205 RVA: 0x000A4AD8 File Offset: 0x000A2CD8
		// (set) Token: 0x0600106E RID: 4206 RVA: 0x000A4AF0 File Offset: 0x000A2CF0
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

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x000A4B4C File Offset: 0x000A2D4C
		// (set) Token: 0x06001070 RID: 4208 RVA: 0x000A4B64 File Offset: 0x000A2D64
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

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06001071 RID: 4209 RVA: 0x000A4BC0 File Offset: 0x000A2DC0
		// (set) Token: 0x06001072 RID: 4210 RVA: 0x000A4BD8 File Offset: 0x000A2DD8
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

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06001073 RID: 4211 RVA: 0x000A4C34 File Offset: 0x000A2E34
		// (set) Token: 0x06001074 RID: 4212 RVA: 0x000A4C4C File Offset: 0x000A2E4C
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

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06001075 RID: 4213 RVA: 0x000A4CA8 File Offset: 0x000A2EA8
		// (set) Token: 0x06001076 RID: 4214 RVA: 0x000A4CC0 File Offset: 0x000A2EC0
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

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06001077 RID: 4215 RVA: 0x000A4D1C File Offset: 0x000A2F1C
		// (set) Token: 0x06001078 RID: 4216 RVA: 0x000A4D34 File Offset: 0x000A2F34
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

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06001079 RID: 4217 RVA: 0x000A4D40 File Offset: 0x000A2F40
		// (set) Token: 0x0600107A RID: 4218 RVA: 0x000A4D58 File Offset: 0x000A2F58
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

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x0600107B RID: 4219 RVA: 0x000A4D64 File Offset: 0x000A2F64
		// (set) Token: 0x0600107C RID: 4220 RVA: 0x000A4D7C File Offset: 0x000A2F7C
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

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x0600107D RID: 4221 RVA: 0x000A4D88 File Offset: 0x000A2F88
		// (set) Token: 0x0600107E RID: 4222 RVA: 0x000A4DA0 File Offset: 0x000A2FA0
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

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x0600107F RID: 4223 RVA: 0x000A4DAC File Offset: 0x000A2FAC
		// (set) Token: 0x06001080 RID: 4224 RVA: 0x000A4DC4 File Offset: 0x000A2FC4
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

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06001081 RID: 4225 RVA: 0x000A4DD0 File Offset: 0x000A2FD0
		// (set) Token: 0x06001082 RID: 4226 RVA: 0x000A4DE8 File Offset: 0x000A2FE8
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

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06001083 RID: 4227 RVA: 0x000A4DF4 File Offset: 0x000A2FF4
		// (set) Token: 0x06001084 RID: 4228 RVA: 0x000A4E0C File Offset: 0x000A300C
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

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06001085 RID: 4229 RVA: 0x000A4E18 File Offset: 0x000A3018
		// (set) Token: 0x06001086 RID: 4230 RVA: 0x000A4E30 File Offset: 0x000A3030
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

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001087 RID: 4231 RVA: 0x000A4E3C File Offset: 0x000A303C
		// (set) Token: 0x06001088 RID: 4232 RVA: 0x000A4E54 File Offset: 0x000A3054
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

		// Token: 0x06001089 RID: 4233 RVA: 0x000A4EAE File Offset: 0x000A30AE
		public frmPrint()
		{
			base.Load += this.frmPrint_Load;
			this.InitializeComponent();
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x000A4ED3 File Offset: 0x000A30D3
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x000A4EE0 File Offset: 0x000A30E0
		private void btnLayout_Click(object sender, EventArgs e)
		{
			this.dlgSetup.Document = this._printer.Document;
			this.dlgSetup.ShowDialog();
			this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x000A4F34 File Offset: 0x000A3134
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

		// Token: 0x0600108D RID: 4237 RVA: 0x000A503C File Offset: 0x000A323C
		private void btnPrinter_Click(object sender, EventArgs e)
		{
			new PrintDialog
			{
				Document = this._printer.Document
			}.ShowDialog();
			this.lblPrinter.Text = this._printer.Document.PrinterSettings.PrinterName;
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x000A508A File Offset: 0x000A328A
		private void chkPrintHistory_CheckedChanged(object sender, EventArgs e)
		{
			this.chkPrintHistoryEnh.Enabled = this.chkPrintHistory.Checked;
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x000A50F4 File Offset: 0x000A32F4
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

		// Token: 0x06001092 RID: 4242 RVA: 0x000A5C01 File Offset: 0x000A3E01
		private void rbProfileShort_CheckedChanged(object sender, EventArgs e)
		{
			this.chkProfileEnh.Enabled = this.rbProfileShort.Checked;
		}

		// Token: 0x040006A5 RID: 1701
		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		// Token: 0x040006A6 RID: 1702
		[AccessedThroughProperty("btnLayout")]
		private Button _btnLayout;

		// Token: 0x040006A7 RID: 1703
		[AccessedThroughProperty("btnPrint")]
		private Button _btnPrint;

		// Token: 0x040006A8 RID: 1704
		[AccessedThroughProperty("btnPrinter")]
		private Button _btnPrinter;

		// Token: 0x040006A9 RID: 1705
		[AccessedThroughProperty("chkPrintHistory")]
		private CheckBox _chkPrintHistory;

		// Token: 0x040006AA RID: 1706
		[AccessedThroughProperty("chkPrintHistoryEnh")]
		private CheckBox _chkPrintHistoryEnh;

		// Token: 0x040006AB RID: 1707
		[AccessedThroughProperty("chkProfileEnh")]
		private CheckBox _chkProfileEnh;

		// Token: 0x040006AC RID: 1708
		[AccessedThroughProperty("dlgSetup")]
		private PageSetupDialog _dlgSetup;

		// Token: 0x040006AD RID: 1709
		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		// Token: 0x040006AE RID: 1710
		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		// Token: 0x040006AF RID: 1711
		[AccessedThroughProperty("lblPrinter")]
		private Label _lblPrinter;

		// Token: 0x040006B0 RID: 1712
		private Print _printer;

		// Token: 0x040006B1 RID: 1713
		[AccessedThroughProperty("rbProfileLong")]
		private RadioButton _rbProfileLong;

		// Token: 0x040006B2 RID: 1714
		[AccessedThroughProperty("rbProfileNone")]
		private RadioButton _rbProfileNone;

		// Token: 0x040006B3 RID: 1715
		[AccessedThroughProperty("rbProfileShort")]
		private RadioButton _rbProfileShort;
	}
}
