using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x02000042 RID: 66
	
	public partial class frmImport_SetAssignments : Form
	{
		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000C2D RID: 3117 RVA: 0x000792F0 File Offset: 0x000774F0
		// (set) Token: 0x06000C2E RID: 3118 RVA: 0x00079308 File Offset: 0x00077508
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

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000C2F RID: 3119 RVA: 0x00079364 File Offset: 0x00077564
		// (set) Token: 0x06000C30 RID: 3120 RVA: 0x0007937C File Offset: 0x0007757C
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

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000C31 RID: 3121 RVA: 0x000793D8 File Offset: 0x000775D8
		// (set) Token: 0x06000C32 RID: 3122 RVA: 0x000793F0 File Offset: 0x000775F0
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

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x0007944C File Offset: 0x0007764C
		// (set) Token: 0x06000C34 RID: 3124 RVA: 0x00079464 File Offset: 0x00077664
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

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x00079470 File Offset: 0x00077670
		// (set) Token: 0x06000C36 RID: 3126 RVA: 0x00079488 File Offset: 0x00077688
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

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000C37 RID: 3127 RVA: 0x00079494 File Offset: 0x00077694
		// (set) Token: 0x06000C38 RID: 3128 RVA: 0x000794AC File Offset: 0x000776AC
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

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x000794B8 File Offset: 0x000776B8
		// (set) Token: 0x06000C3A RID: 3130 RVA: 0x000794D0 File Offset: 0x000776D0
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

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000C3B RID: 3131 RVA: 0x000794DC File Offset: 0x000776DC
		// (set) Token: 0x06000C3C RID: 3132 RVA: 0x000794F4 File Offset: 0x000776F4
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

		// Token: 0x06000C3D RID: 3133 RVA: 0x000794FE File Offset: 0x000776FE
		public frmImport_SetAssignments()
		{
			base.Load += this.frmImport_SetAssignments_Load;
			this.FullFileName = "";
			this.InitializeComponent();
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x00079530 File Offset: 0x00077730
		protected void AddSetType(int nIDPower, Enums.eSetType nSetType)
		{
			if (nIDPower > -1 & nIDPower < DatabaseAPI.Database.Power.Length)
			{
				int num = DatabaseAPI.Database.Power[nIDPower].SetTypes.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (DatabaseAPI.Database.Power[nIDPower].SetTypes[index] == nSetType)
					{
						return;
					}
				}
				IPower[] power = DatabaseAPI.Database.Power;
				Enums.eSetType[] eSetTypeArray = (Enums.eSetType[])Utils.CopyArray(power[nIDPower].SetTypes, new Enums.eSetType[DatabaseAPI.Database.Power[nIDPower].SetTypes.Length + 1]);
				power[nIDPower].SetTypes = eSetTypeArray;
				DatabaseAPI.Database.Power[nIDPower].SetTypes[DatabaseAPI.Database.Power[nIDPower].SetTypes.Length - 1] = nSetType;
				Array.Sort<Enums.eSetType>(DatabaseAPI.Database.Power[nIDPower].SetTypes);
			}
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x00079633 File Offset: 0x00077833
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x00079640 File Offset: 0x00077840
		private void btnFile_Click(object sender, EventArgs e)
		{
			this.dlgBrowse.FileName = this.FullFileName;
			if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
			{
				this.FullFileName = this.dlgBrowse.FileName;
			}
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00079697 File Offset: 0x00077897
		private void btnImport_Click(object sender, EventArgs e)
		{
			this.ParseClasses(this.FullFileName);
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x000796B8 File Offset: 0x000778B8
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x000796E8 File Offset: 0x000778E8
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show(this);
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x00079730 File Offset: 0x00077930
		public void DisplayInfo()
		{
			this.lblFile.Text = FileIO.StripPath(this.FullFileName);
			this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.udRevision.Value = new decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x000797FC File Offset: 0x000779FC
		private void frmImport_SetAssignments_Load(object sender, EventArgs e)
		{
			this.FullFileName = DatabaseAPI.Database.IOAssignmentVersion.SourceFile;
			this.DisplayInfo();
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00079D00 File Offset: 0x00077F00
		private bool ParseClasses(string iFileName)
		{
			int num = 0;
			Enums.eSetType eSetType = Enums.eSetType.Untyped;
			StreamReader iStream;
			try
			{
				iStream = new StreamReader(iFileName);
			}
			catch (Exception ex)
			{
				Exception ex3 = ex;
				Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
				return false;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			bool[] flagArray = new bool[Enum.GetValues(eSetType.GetType()).Length - 1 + 1];
			int index = -1;
			int num5 = DatabaseAPI.Database.Power.Length - 1;
			for (int index2 = 0; index2 <= num5; index2++)
			{
				DatabaseAPI.Database.Power[index2].SetTypes = new Enums.eSetType[0];
			}
			try
			{
				string iLine;
				do
				{
					iLine = FileIO.ReadLineUnlimited(iStream, '\0');
					if (iLine != null && !iLine.StartsWith("#"))
					{
						num4++;
						if (num4 >= 9)
						{
							this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
							num4 = 0;
						}
						string[] array = CSV.ToArray(iLine);
						if (array.Length > 1)
						{
							int num6 = DatabaseAPI.NidFromUidioSet(array[0]);
							if (num6 != index & index > -1)
							{
								flagArray[(int)DatabaseAPI.Database.EnhancementSets[index].SetType] = true;
							}
							index = num6;
							if (index > -1 && !flagArray[(int)DatabaseAPI.Database.EnhancementSets[index].SetType])
							{
								int nIDPower = DatabaseAPI.NidFromUidPower(array[1]);
								if (nIDPower > -1)
								{
									this.AddSetType(nIDPower, DatabaseAPI.Database.EnhancementSets[index].SetType);
								}
							}
							num++;
						}
						else
						{
							num3++;
						}
						num2++;
					}
				}
				while (iLine != null);
			}
			catch (Exception ex2)
			{
				Exception exception = ex2;
				iStream.Close();
				Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "IO CSV Parse Error");
				return false;
			}
			iStream.Close();
			DatabaseAPI.Database.IOAssignmentVersion.SourceFile = this.dlgBrowse.FileName;
			DatabaseAPI.Database.IOAssignmentVersion.RevisionDate = DateTime.Now;
			DatabaseAPI.Database.IOAssignmentVersion.Revision = Convert.ToInt32(this.udRevision.Value);
			DatabaseAPI.SaveMainDatabase();
			this.DisplayInfo();
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

		// Token: 0x04000504 RID: 1284
		[AccessedThroughProperty("btnClose")]
		private Button _btnClose;

		// Token: 0x04000505 RID: 1285
		[AccessedThroughProperty("btnFile")]
		private Button _btnFile;

		// Token: 0x04000506 RID: 1286
		[AccessedThroughProperty("btnImport")]
		private Button _btnImport;

		// Token: 0x04000507 RID: 1287
		[AccessedThroughProperty("dlgBrowse")]
		private OpenFileDialog _dlgBrowse;

		// Token: 0x04000508 RID: 1288
		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		// Token: 0x04000509 RID: 1289
		[AccessedThroughProperty("lblDate")]
		private Label _lblDate;

		// Token: 0x0400050A RID: 1290
		[AccessedThroughProperty("lblFile")]
		private Label _lblFile;

		// Token: 0x0400050B RID: 1291
		[AccessedThroughProperty("udRevision")]
		private NumericUpDown _udRevision;

		// Token: 0x0400050C RID: 1292
		private frmBusy bFrm;

		// Token: 0x0400050E RID: 1294
		private string FullFileName;
	}
}
