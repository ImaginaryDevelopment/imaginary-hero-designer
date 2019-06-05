using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
	// Token: 0x02000034 RID: 52
	public partial class frmExportColor : Form
	{
		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x00068810 File Offset: 0x00066A10
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x00068828 File Offset: 0x00066A28
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

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x00068884 File Offset: 0x00066A84
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x0006889C File Offset: 0x00066A9C
		internal virtual Button btnOK
		{
			get
			{
				return this._btnOK;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnOK_Click);
				if (this._btnOK != null)
				{
					this._btnOK.Click -= eventHandler;
				}
				this._btnOK = value;
				if (this._btnOK != null)
				{
					this._btnOK.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x000688F8 File Offset: 0x00066AF8
		// (set) Token: 0x060009E5 RID: 2533 RVA: 0x00068910 File Offset: 0x00066B10
		internal virtual ColorDialog cPicker
		{
			get
			{
				return this._cPicker;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cPicker = value;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0006891C File Offset: 0x00066B1C
		// (set) Token: 0x060009E7 RID: 2535 RVA: 0x00068934 File Offset: 0x00066B34
		internal virtual Label csHeading
		{
			get
			{
				return this._csHeading;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csHeading_Click);
				if (this._csHeading != null)
				{
					this._csHeading.Click -= eventHandler;
				}
				this._csHeading = value;
				if (this._csHeading != null)
				{
					this._csHeading.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x00068990 File Offset: 0x00066B90
		// (set) Token: 0x060009E9 RID: 2537 RVA: 0x000689A8 File Offset: 0x00066BA8
		internal virtual Label csHO
		{
			get
			{
				return this._csHO;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csHO_Click);
				if (this._csHO != null)
				{
					this._csHO.Click -= eventHandler;
				}
				this._csHO = value;
				if (this._csHO != null)
				{
					this._csHO.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x00068A04 File Offset: 0x00066C04
		// (set) Token: 0x060009EB RID: 2539 RVA: 0x00068A1C File Offset: 0x00066C1C
		internal virtual Label csIO
		{
			get
			{
				return this._csIO;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csIO_Click);
				if (this._csIO != null)
				{
					this._csIO.Click -= eventHandler;
				}
				this._csIO = value;
				if (this._csIO != null)
				{
					this._csIO.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x00068A78 File Offset: 0x00066C78
		// (set) Token: 0x060009ED RID: 2541 RVA: 0x00068A90 File Offset: 0x00066C90
		internal virtual Label csLevel
		{
			get
			{
				return this._csLevel;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csLevel_Click);
				if (this._csLevel != null)
				{
					this._csLevel.Click -= eventHandler;
				}
				this._csLevel = value;
				if (this._csLevel != null)
				{
					this._csLevel.Click += eventHandler;
				}
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060009EE RID: 2542 RVA: 0x00068AEC File Offset: 0x00066CEC
		// (set) Token: 0x060009EF RID: 2543 RVA: 0x00068B04 File Offset: 0x00066D04
		internal virtual Label csPower
		{
			get
			{
				return this._csPower;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csPower_Click);
				if (this._csPower != null)
				{
					this._csPower.Click -= eventHandler;
				}
				this._csPower = value;
				if (this._csPower != null)
				{
					this._csPower.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060009F0 RID: 2544 RVA: 0x00068B60 File Offset: 0x00066D60
		// (set) Token: 0x060009F1 RID: 2545 RVA: 0x00068B78 File Offset: 0x00066D78
		internal virtual Label csSet
		{
			get
			{
				return this._csSet;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csSet_Click);
				if (this._csSet != null)
				{
					this._csSet.Click -= eventHandler;
				}
				this._csSet = value;
				if (this._csSet != null)
				{
					this._csSet.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060009F2 RID: 2546 RVA: 0x00068BD4 File Offset: 0x00066DD4
		// (set) Token: 0x060009F3 RID: 2547 RVA: 0x00068BEC File Offset: 0x00066DEC
		internal virtual Label csSlots
		{
			get
			{
				return this._csSlots;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csSlots_Click);
				if (this._csSlots != null)
				{
					this._csSlots.Click -= eventHandler;
				}
				this._csSlots = value;
				if (this._csSlots != null)
				{
					this._csSlots.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060009F4 RID: 2548 RVA: 0x00068C48 File Offset: 0x00066E48
		// (set) Token: 0x060009F5 RID: 2549 RVA: 0x00068C60 File Offset: 0x00066E60
		internal virtual Label csTitle
		{
			get
			{
				return this._csTitle;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csTitle_Click);
				if (this._csTitle != null)
				{
					this._csTitle.Click -= eventHandler;
				}
				this._csTitle = value;
				if (this._csTitle != null)
				{
					this._csTitle.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x00068CBC File Offset: 0x00066EBC
		// (set) Token: 0x060009F7 RID: 2551 RVA: 0x00068CD4 File Offset: 0x00066ED4
		internal virtual Label Label1
		{
			get
			{
				return this._Label1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x00068CE0 File Offset: 0x00066EE0
		// (set) Token: 0x060009F9 RID: 2553 RVA: 0x00068CF8 File Offset: 0x00066EF8
		internal virtual Label Label19
		{
			get
			{
				return this._Label19;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label19 = value;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x00068D04 File Offset: 0x00066F04
		// (set) Token: 0x060009FB RID: 2555 RVA: 0x00068D1C File Offset: 0x00066F1C
		internal virtual Label Label20
		{
			get
			{
				return this._Label20;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label20 = value;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x00068D28 File Offset: 0x00066F28
		// (set) Token: 0x060009FD RID: 2557 RVA: 0x00068D40 File Offset: 0x00066F40
		internal virtual Label Label21
		{
			get
			{
				return this._Label21;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label21 = value;
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x00068D4C File Offset: 0x00066F4C
		// (set) Token: 0x060009FF RID: 2559 RVA: 0x00068D64 File Offset: 0x00066F64
		internal virtual Label Label22
		{
			get
			{
				return this._Label22;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label22 = value;
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00068D70 File Offset: 0x00066F70
		// (set) Token: 0x06000A01 RID: 2561 RVA: 0x00068D88 File Offset: 0x00066F88
		internal virtual Label Label3
		{
			get
			{
				return this._Label3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00068D94 File Offset: 0x00066F94
		// (set) Token: 0x06000A03 RID: 2563 RVA: 0x00068DAC File Offset: 0x00066FAC
		internal virtual Label Label4
		{
			get
			{
				return this._Label4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x00068DB8 File Offset: 0x00066FB8
		// (set) Token: 0x06000A05 RID: 2565 RVA: 0x00068DD0 File Offset: 0x00066FD0
		internal virtual Label Label5
		{
			get
			{
				return this._Label5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00068DDC File Offset: 0x00066FDC
		// (set) Token: 0x06000A07 RID: 2567 RVA: 0x00068DF4 File Offset: 0x00066FF4
		internal virtual Label Label7
		{
			get
			{
				return this._Label7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000A08 RID: 2568 RVA: 0x00068E00 File Offset: 0x00067000
		// (set) Token: 0x06000A09 RID: 2569 RVA: 0x00068E18 File Offset: 0x00067018
		internal virtual Label Label9
		{
			get
			{
				return this._Label9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label9 = value;
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000A0A RID: 2570 RVA: 0x00068E24 File Offset: 0x00067024
		// (set) Token: 0x06000A0B RID: 2571 RVA: 0x00068E3C File Offset: 0x0006703C
		internal virtual ToolTip myTip
		{
			get
			{
				return this._myTip;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._myTip = value;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000A0C RID: 2572 RVA: 0x00068E48 File Offset: 0x00067048
		// (set) Token: 0x06000A0D RID: 2573 RVA: 0x00068E60 File Offset: 0x00067060
		internal virtual TextBox txtName
		{
			get
			{
				return this._txtName;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
				if (this._txtName != null)
				{
					this._txtName.TextChanged -= eventHandler;
				}
				this._txtName = value;
				if (this._txtName != null)
				{
					this._txtName.TextChanged += eventHandler;
				}
			}
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00068EBA File Offset: 0x000670BA
		public frmExportColor(ref ExportConfig.ColorScheme iScheme)
		{
			base.Load += this.frmExportColor_Load;
			this.InitializeComponent();
			this.myScheme.Assign(iScheme);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00068EF1 File Offset: 0x000670F1
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00068EFB File Offset: 0x000670FB
		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Hide();
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00068F10 File Offset: 0x00067110
		private void csHeading_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.Heading;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.Heading = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00068F6C File Offset: 0x0006716C
		private void csHO_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.HOColor;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.HOColor = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00068FC8 File Offset: 0x000671C8
		private void csIO_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.IOColor;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.IOColor = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00069024 File Offset: 0x00067224
		private void csLevel_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.Level;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.Level = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00069080 File Offset: 0x00067280
		private void csPower_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.Power;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.Power = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x000690DC File Offset: 0x000672DC
		private void csSet_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.SetColor;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.SetColor = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00069138 File Offset: 0x00067338
		private void csSlots_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.Slots;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.Slots = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00069194 File Offset: 0x00067394
		private void csTitle_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myScheme.Title;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myScheme.Title = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x00069228 File Offset: 0x00067428
		private void frmExportColor_Load(object sender, EventArgs e)
		{
			this.txtName.Text = this.myScheme.SchemeName;
			this.updateColours();
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0006A075 File Offset: 0x00068275
		private void txtName_TextChanged(object sender, EventArgs e)
		{
			this.myScheme.SchemeName = this.txtName.Text;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0006A090 File Offset: 0x00068290
		public void updateColours()
		{
			this.csTitle.BackColor = this.myScheme.Title;
			this.csHeading.BackColor = this.myScheme.Heading;
			this.csLevel.BackColor = this.myScheme.Level;
			this.csSlots.BackColor = this.myScheme.Slots;
			this.csIO.BackColor = this.myScheme.IOColor;
			this.csSet.BackColor = this.myScheme.SetColor;
			this.csHO.BackColor = this.myScheme.HOColor;
			this.csPower.BackColor = this.myScheme.Power;
		}

		// Token: 0x0400040D RID: 1037
		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		// Token: 0x0400040E RID: 1038
		[AccessedThroughProperty("btnOK")]
		private Button _btnOK;

		// Token: 0x0400040F RID: 1039
		[AccessedThroughProperty("cPicker")]
		private ColorDialog _cPicker;

		// Token: 0x04000410 RID: 1040
		[AccessedThroughProperty("csHeading")]
		private Label _csHeading;

		// Token: 0x04000411 RID: 1041
		[AccessedThroughProperty("csHO")]
		private Label _csHO;

		// Token: 0x04000412 RID: 1042
		[AccessedThroughProperty("csIO")]
		private Label _csIO;

		// Token: 0x04000413 RID: 1043
		[AccessedThroughProperty("csLevel")]
		private Label _csLevel;

		// Token: 0x04000414 RID: 1044
		[AccessedThroughProperty("csPower")]
		private Label _csPower;

		// Token: 0x04000415 RID: 1045
		[AccessedThroughProperty("csSet")]
		private Label _csSet;

		// Token: 0x04000416 RID: 1046
		[AccessedThroughProperty("csSlots")]
		private Label _csSlots;

		// Token: 0x04000417 RID: 1047
		[AccessedThroughProperty("csTitle")]
		private Label _csTitle;

		// Token: 0x04000418 RID: 1048
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x04000419 RID: 1049
		[AccessedThroughProperty("Label19")]
		private Label _Label19;

		// Token: 0x0400041A RID: 1050
		[AccessedThroughProperty("Label20")]
		private Label _Label20;

		// Token: 0x0400041B RID: 1051
		[AccessedThroughProperty("Label21")]
		private Label _Label21;

		// Token: 0x0400041C RID: 1052
		[AccessedThroughProperty("Label22")]
		private Label _Label22;

		// Token: 0x0400041D RID: 1053
		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		// Token: 0x0400041E RID: 1054
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x0400041F RID: 1055
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x04000420 RID: 1056
		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		// Token: 0x04000421 RID: 1057
		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		// Token: 0x04000422 RID: 1058
		[AccessedThroughProperty("myTip")]
		private ToolTip _myTip;

		// Token: 0x04000423 RID: 1059
		[AccessedThroughProperty("txtName")]
		private TextBox _txtName;

		// Token: 0x04000425 RID: 1061
		public ExportConfig.ColorScheme myScheme;
	}
}
