using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x0200003F RID: 63
	
	public partial class frmImport_Powerset : Form
	{
		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x00075E8C File Offset: 0x0007408C
		// (set) Token: 0x06000BC5 RID: 3013 RVA: 0x00075EA4 File Offset: 0x000740A4
		internal virtual Button btnCheckAll
		{
			get
			{
				return this._btnCheckAll;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnCheckAll_Click);
				if (this._btnCheckAll != null)
				{
					this._btnCheckAll.Click -= eventHandler;
				}
				this._btnCheckAll = value;
				if (this._btnCheckAll != null)
				{
					this._btnCheckAll.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x00075F00 File Offset: 0x00074100
		// (set) Token: 0x06000BC7 RID: 3015 RVA: 0x00075F18 File Offset: 0x00074118
		internal virtual Button btnClose
		{
			get
			{
				return this._btnClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnClose_Click);
				if (this._btnClose != null)
				{
					this._btnClose.Click -= eventHandler;
				}
				this._btnClose = value;
				if (this._btnClose != null)
				{
					this._btnClose.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x00075F74 File Offset: 0x00074174
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x00075F8C File Offset: 0x0007418C
		internal virtual Button btnFile
		{
			get
			{
				return this._btnFile;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnFile_Click);
				if (this._btnFile != null)
				{
					this._btnFile.Click -= eventHandler;
				}
				this._btnFile = value;
				if (this._btnFile != null)
				{
					this._btnFile.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x00075FE8 File Offset: 0x000741E8
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x00076000 File Offset: 0x00074200
		internal virtual Button btnImport
		{
			get
			{
				return this._btnImport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnImport_Click);
				if (this._btnImport != null)
				{
					this._btnImport.Click -= eventHandler;
				}
				this._btnImport = value;
				if (this._btnImport != null)
				{
					this._btnImport.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x0007605C File Offset: 0x0007425C
		// (set) Token: 0x06000BCD RID: 3021 RVA: 0x00076074 File Offset: 0x00074274
		internal virtual Button btnUncheckAll
		{
			get
			{
				return this._btnUncheckAll;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnUncheckAll_Click);
				if (this._btnUncheckAll != null)
				{
					this._btnUncheckAll.Click -= eventHandler;
				}
				this._btnUncheckAll = value;
				if (this._btnUncheckAll != null)
				{
					this._btnUncheckAll.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x000760D0 File Offset: 0x000742D0
		// (set) Token: 0x06000BCF RID: 3023 RVA: 0x000760E8 File Offset: 0x000742E8
		internal virtual ColumnHeader ColumnHeader1
		{
			get
			{
				return this._ColumnHeader1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader1 = value;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x000760F4 File Offset: 0x000742F4
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x0007610C File Offset: 0x0007430C
		internal virtual ColumnHeader ColumnHeader2
		{
			get
			{
				return this._ColumnHeader2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader2 = value;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x00076118 File Offset: 0x00074318
		// (set) Token: 0x06000BD3 RID: 3027 RVA: 0x00076130 File Offset: 0x00074330
		internal virtual ColumnHeader ColumnHeader3
		{
			get
			{
				return this._ColumnHeader3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader3 = value;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0007613C File Offset: 0x0007433C
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x00076154 File Offset: 0x00074354
		internal virtual ColumnHeader ColumnHeader4
		{
			get
			{
				return this._ColumnHeader4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader4 = value;
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x00076160 File Offset: 0x00074360
		// (set) Token: 0x06000BD7 RID: 3031 RVA: 0x00076178 File Offset: 0x00074378
		internal virtual ColumnHeader ColumnHeader5
		{
			get
			{
				return this._ColumnHeader5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader5 = value;
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x00076184 File Offset: 0x00074384
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x0007619C File Offset: 0x0007439C
		internal virtual OpenFileDialog dlgBrowse
		{
			get
			{
				return this._dlgBrowse;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._dlgBrowse = value;
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x000761A8 File Offset: 0x000743A8
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x000761C0 File Offset: 0x000743C0
		internal virtual Label Label6
		{
			get
			{
				return this._Label6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x000761CC File Offset: 0x000743CC
		// (set) Token: 0x06000BDD RID: 3037 RVA: 0x000761E4 File Offset: 0x000743E4
		internal virtual Label Label8
		{
			get
			{
				return this._Label8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x000761F0 File Offset: 0x000743F0
		// (set) Token: 0x06000BDF RID: 3039 RVA: 0x00076208 File Offset: 0x00074408
		internal virtual Label lblCount
		{
			get
			{
				return this._lblCount;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblCount = value;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x00076214 File Offset: 0x00074414
		// (set) Token: 0x06000BE1 RID: 3041 RVA: 0x0007622C File Offset: 0x0007442C
		internal virtual Label lblDate
		{
			get
			{
				return this._lblDate;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDate = value;
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x00076238 File Offset: 0x00074438
		// (set) Token: 0x06000BE3 RID: 3043 RVA: 0x00076250 File Offset: 0x00074450
		internal virtual Label lblFile
		{
			get
			{
				return this._lblFile;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblFile = value;
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0007625C File Offset: 0x0007445C
		// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x00076274 File Offset: 0x00074474
		internal virtual ListView lstImport
		{
			get
			{
				return this._lstImport;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lstImport = value;
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x00076280 File Offset: 0x00074480
		// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x00076298 File Offset: 0x00074498
		internal virtual NumericUpDown udRevision
		{
			get
			{
				return this._udRevision;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._udRevision = value;
			}
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x000762A2 File Offset: 0x000744A2
		public frmImport_Powerset()
		{
			base.Load += this.frmImport_Powerset_Load;
			this.FullFileName = "";
			this.ImportBuffer = new PowersetData[0];
			this.InitializeComponent();
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x000762E0 File Offset: 0x000744E0
		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			this.lstImport.BeginUpdate();
			int num = this.lstImport.Items.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				this.lstImport.Items[index].Checked = true;
			}
			this.lstImport.EndUpdate();
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00076346 File Offset: 0x00074546
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00076350 File Offset: 0x00074550
		private void btnFile_Click(object sender, EventArgs e)
		{
			this.dlgBrowse.FileName = this.FullFileName;
			if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
			{
				this.FullFileName = this.dlgBrowse.FileName;
				if (this.ParseClasses(this.FullFileName))
				{
					this.FillListView();
				}
			}
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x000763C3 File Offset: 0x000745C3
		private void btnImport_Click(object sender, EventArgs e)
		{
			this.ProcessImport();
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x000763D0 File Offset: 0x000745D0
		private void btnUncheckAll_Click(object sender, EventArgs e)
		{
			this.lstImport.BeginUpdate();
			int num = this.lstImport.Items.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				this.lstImport.Items[index].Checked = false;
			}
			this.lstImport.EndUpdate();
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00076438 File Offset: 0x00074638
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00076468 File Offset: 0x00074668
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show(this);
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x000764B0 File Offset: 0x000746B0
		public void DisplayInfo()
		{
			this.lblFile.Text = FileIO.StripPath(this.FullFileName);
			this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.udRevision.Value = new decimal(DatabaseAPI.Database.PowersetVersion.Revision);
			this.lblCount.Text = "Records: " + Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x000765A0 File Offset: 0x000747A0
		private void FillListView()
		{
			string[] items = new string[5];
			this.lstImport.BeginUpdate();
			this.lstImport.Items.Clear();
			int num = 0;
			int num2 = this.ImportBuffer.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				num++;
				if (num >= 100)
				{
					this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
					num = 0;
				}
				if (this.ImportBuffer[index].IsValid)
				{
					items[0] = this.ImportBuffer[index].Data.FullName;
					items[1] = this.ImportBuffer[index].Data.GroupName;
					if (this.ImportBuffer[index].IsNew)
					{
						items[2] = "Yes";
					}
					else
					{
						items[2] = "No";
					}
					bool flag = this.ImportBuffer[index].CheckDifference(out items[4]);
					if (flag)
					{
						items[3] = "Yes";
					}
					else
					{
						items[3] = "No";
					}
					ListViewItem value = new ListViewItem(items)
					{
						Checked = flag,
						Tag = index
					};
					this.lstImport.Items.Add(value);
				}
			}
			if (this.lstImport.Items.Count > 0)
			{
				this.lstImport.Items[0].EnsureVisible();
			}
			this.lstImport.EndUpdate();
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00076750 File Offset: 0x00074950
		private void frmImport_Powerset_Load(object sender, EventArgs e)
		{
			this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
			this.DisplayInfo();
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0007704C File Offset: 0x0007524C
		private bool ParseClasses(string iFileName)
		{
			int num = 0;
			StreamReader iStream;
			try
			{
				iStream = new StreamReader(iFileName);
			}
			catch (Exception ex)
			{
				Exception ex3 = ex;
				Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Powerset CSV Not Opened");
				return false;
			}
			int num2 = 0;
			int num3 = 0;
			this.ImportBuffer = new PowersetData[0];
			int num4 = 0;
			try
			{
				string iString;
				do
				{
					iString = FileIO.ReadLineUnlimited(iStream, '\0');
					if (iString != null && !iString.StartsWith("#"))
					{
						num4++;
						if (num4 >= 100)
						{
							this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
							num4 = 0;
						}
						this.ImportBuffer = (PowersetData[])Utils.CopyArray(this.ImportBuffer, new PowersetData[this.ImportBuffer.Length + 1]);
						this.ImportBuffer[this.ImportBuffer.Length - 1] = new PowersetData(iString);
						num2++;
						if (this.ImportBuffer[this.ImportBuffer.Length - 1].IsValid)
						{
							num++;
						}
						else
						{
							num3++;
						}
					}
				}
				while (iString != null);
			}
			catch (Exception ex2)
			{
				Exception exception = ex2;
				iStream.Close();
				Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Powerset Class CSV Parse Error");
				return false;
			}
			iStream.Close();
			Interaction.MsgBox(string.Concat(new string[]
			{
				"Parse Completed!\r\nTotal Records: ",
				Conversions.ToString(num2),
				"\r\nGood: ",
				Conversions.ToString(num),
				"\r\nRejected: ",
				Conversions.ToString(num3)
			}), MsgBoxStyle.Information, "File Parsed");
			return true;
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0007725C File Offset: 0x0007545C
		private bool ProcessImport()
		{
			bool flag = false;
			int num = 0;
			int num2 = this.lstImport.Items.Count - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (this.lstImport.Items[index].Checked)
				{
					this.ImportBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
					num++;
				}
			}
			DatabaseAPI.Database.PowersetVersion.SourceFile = this.dlgBrowse.FileName;
			DatabaseAPI.Database.PowersetVersion.RevisionDate = DateTime.Now;
			DatabaseAPI.Database.PowersetVersion.Revision = Convert.ToInt32(this.udRevision.Value);
			DatabaseAPI.MatchAllIDs(null);
			DatabaseAPI.SaveMainDatabase();
			Interaction.MsgBox("Import of " + Conversions.ToString(num) + " records completed!", MsgBoxStyle.Information, "Done");
			this.DisplayInfo();
			return flag;
		}

		// Token: 0x040004D9 RID: 1241
		[AccessedThroughProperty("btnCheckAll")]
		private Button _btnCheckAll;

		// Token: 0x040004DA RID: 1242
		[AccessedThroughProperty("btnClose")]
		private Button _btnClose;

		// Token: 0x040004DB RID: 1243
		[AccessedThroughProperty("btnFile")]
		private Button _btnFile;

		// Token: 0x040004DC RID: 1244
		[AccessedThroughProperty("btnImport")]
		private Button _btnImport;

		// Token: 0x040004DD RID: 1245
		[AccessedThroughProperty("btnUncheckAll")]
		private Button _btnUncheckAll;

		// Token: 0x040004DE RID: 1246
		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader _ColumnHeader1;

		// Token: 0x040004DF RID: 1247
		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader _ColumnHeader2;

		// Token: 0x040004E0 RID: 1248
		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader _ColumnHeader3;

		// Token: 0x040004E1 RID: 1249
		[AccessedThroughProperty("ColumnHeader4")]
		private ColumnHeader _ColumnHeader4;

		// Token: 0x040004E2 RID: 1250
		[AccessedThroughProperty("ColumnHeader5")]
		private ColumnHeader _ColumnHeader5;

		// Token: 0x040004E3 RID: 1251
		[AccessedThroughProperty("dlgBrowse")]
		private OpenFileDialog _dlgBrowse;

		// Token: 0x040004E4 RID: 1252
		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		// Token: 0x040004E5 RID: 1253
		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		// Token: 0x040004E6 RID: 1254
		[AccessedThroughProperty("lblCount")]
		private Label _lblCount;

		// Token: 0x040004E7 RID: 1255
		[AccessedThroughProperty("lblDate")]
		private Label _lblDate;

		// Token: 0x040004E8 RID: 1256
		[AccessedThroughProperty("lblFile")]
		private Label _lblFile;

		// Token: 0x040004E9 RID: 1257
		[AccessedThroughProperty("lstImport")]
		private ListView _lstImport;

		// Token: 0x040004EA RID: 1258
		[AccessedThroughProperty("udRevision")]
		private NumericUpDown _udRevision;

		// Token: 0x040004EB RID: 1259
		private frmBusy bFrm;

		// Token: 0x040004ED RID: 1261
		private string FullFileName;

		// Token: 0x040004EE RID: 1262
		private PowersetData[] ImportBuffer;
	}
}
