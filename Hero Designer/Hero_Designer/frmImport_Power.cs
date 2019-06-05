using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
	// Token: 0x0200003E RID: 62
	[DesignerGenerated]
	public partial class frmImport_Power : Form
	{
		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x000742C8 File Offset: 0x000724C8
		// (set) Token: 0x06000B8A RID: 2954 RVA: 0x000742E0 File Offset: 0x000724E0
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

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000B8B RID: 2955 RVA: 0x0007433C File Offset: 0x0007253C
		// (set) Token: 0x06000B8C RID: 2956 RVA: 0x00074354 File Offset: 0x00072554
		internal virtual Button btnCheckModified
		{
			get
			{
				return this._btnCheckModified;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnCheckModified_Click);
				if (this._btnCheckModified != null)
				{
					this._btnCheckModified.Click -= eventHandler;
				}
				this._btnCheckModified = value;
				if (this._btnCheckModified != null)
				{
					this._btnCheckModified.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x000743B0 File Offset: 0x000725B0
		// (set) Token: 0x06000B8E RID: 2958 RVA: 0x000743C8 File Offset: 0x000725C8
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

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x00074424 File Offset: 0x00072624
		// (set) Token: 0x06000B90 RID: 2960 RVA: 0x0007443C File Offset: 0x0007263C
		internal virtual Button btnEraseAll
		{
			get
			{
				return this._btnEraseAll;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnEraseAll_Click);
				if (this._btnEraseAll != null)
				{
					this._btnEraseAll.Click -= eventHandler;
				}
				this._btnEraseAll = value;
				if (this._btnEraseAll != null)
				{
					this._btnEraseAll.Click += eventHandler;
				}
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x00074498 File Offset: 0x00072698
		// (set) Token: 0x06000B92 RID: 2962 RVA: 0x000744B0 File Offset: 0x000726B0
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

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0007450C File Offset: 0x0007270C
		// (set) Token: 0x06000B94 RID: 2964 RVA: 0x00074524 File Offset: 0x00072724
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

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x00074580 File Offset: 0x00072780
		// (set) Token: 0x06000B96 RID: 2966 RVA: 0x00074598 File Offset: 0x00072798
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

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x000745F4 File Offset: 0x000727F4
		// (set) Token: 0x06000B98 RID: 2968 RVA: 0x0007460C File Offset: 0x0007280C
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

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x00074618 File Offset: 0x00072818
		// (set) Token: 0x06000B9A RID: 2970 RVA: 0x00074630 File Offset: 0x00072830
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

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0007463C File Offset: 0x0007283C
		// (set) Token: 0x06000B9C RID: 2972 RVA: 0x00074654 File Offset: 0x00072854
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

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x00074660 File Offset: 0x00072860
		// (set) Token: 0x06000B9E RID: 2974 RVA: 0x00074678 File Offset: 0x00072878
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

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x00074684 File Offset: 0x00072884
		// (set) Token: 0x06000BA0 RID: 2976 RVA: 0x0007469C File Offset: 0x0007289C
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

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x000746A8 File Offset: 0x000728A8
		// (set) Token: 0x06000BA2 RID: 2978 RVA: 0x000746C0 File Offset: 0x000728C0
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

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x000746CC File Offset: 0x000728CC
		// (set) Token: 0x06000BA4 RID: 2980 RVA: 0x000746E4 File Offset: 0x000728E4
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

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x000746F0 File Offset: 0x000728F0
		// (set) Token: 0x06000BA6 RID: 2982 RVA: 0x00074708 File Offset: 0x00072908
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

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x00074714 File Offset: 0x00072914
		// (set) Token: 0x06000BA8 RID: 2984 RVA: 0x0007472C File Offset: 0x0007292C
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

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x00074738 File Offset: 0x00072938
		// (set) Token: 0x06000BAA RID: 2986 RVA: 0x00074750 File Offset: 0x00072950
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

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x0007475C File Offset: 0x0007295C
		// (set) Token: 0x06000BAC RID: 2988 RVA: 0x00074774 File Offset: 0x00072974
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

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x00074780 File Offset: 0x00072980
		// (set) Token: 0x06000BAE RID: 2990 RVA: 0x00074798 File Offset: 0x00072998
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

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x000747A4 File Offset: 0x000729A4
		// (set) Token: 0x06000BB0 RID: 2992 RVA: 0x000747BC File Offset: 0x000729BC
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

		// Token: 0x06000BB1 RID: 2993 RVA: 0x000747C6 File Offset: 0x000729C6
		public frmImport_Power()
		{
			base.Load += this.frmImport_Power_Load;
			this.FullFileName = "";
			this.ImportBuffer = new PowerData[0];
			this.InitializeComponent();
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x00074804 File Offset: 0x00072A04
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

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0007486C File Offset: 0x00072A6C
		private void btnCheckModified_Click(object sender, EventArgs e)
		{
			this.lstImport.BeginUpdate();
			int num = this.lstImport.Items.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				if (this.lstImport.Items[index].SubItems[2].Text == "No" & this.lstImport.Items[index].SubItems[3].Text == "Yes")
				{
					this.lstImport.Items[index].Checked = true;
				}
				else
				{
					this.lstImport.Items[index].Checked = false;
				}
			}
			this.lstImport.EndUpdate();
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x00074954 File Offset: 0x00072B54
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x00074960 File Offset: 0x00072B60
		private void btnEraseAll_Click(object sender, EventArgs e)
		{
			if (Interaction.MsgBox("Really wipte the power array. You shouldn't do this if you want to preserve any special power settings.", MsgBoxStyle.YesNo, "Really?") != MsgBoxResult.No)
			{
				DatabaseAPI.Database.Power = new IPower[0];
				int num = this.ImportBuffer.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (this.ImportBuffer[index].IsValid)
					{
						this.ImportBuffer[index].IsNew = true;
					}
				}
				Interaction.MsgBox("All powers removed!", MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x000749EC File Offset: 0x00072BEC
		private void btnFile_Click(object sender, EventArgs e)
		{
			this.dlgBrowse.FileName = this.FullFileName;
			if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
			{
				this.FullFileName = this.dlgBrowse.FileName;
				base.Enabled = false;
				if (this.ParseClasses(this.FullFileName))
				{
					this.FillListView();
				}
				base.Enabled = true;
			}
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x00074A6F File Offset: 0x00072C6F
		private void btnImport_Click(object sender, EventArgs e)
		{
			this.ProcessImport();
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x00074A7C File Offset: 0x00072C7C
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

		// Token: 0x06000BB9 RID: 3001 RVA: 0x00074AE4 File Offset: 0x00072CE4
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x00074B14 File Offset: 0x00072D14
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show(this);
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00074B5C File Offset: 0x00072D5C
		private int[] CheckForDeletedPowers()
		{
			int[] numArray = new int[0];
			int num = 0;
			int num2 = DatabaseAPI.Database.Power.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				num++;
				if (num >= 9)
				{
					this.BusyMsg(string.Concat(new string[]
					{
						"Checking for deleted powers...",
						Strings.Format(index, "###,##0"),
						" of ",
						Conversions.ToString(DatabaseAPI.Database.Power.Length),
						" done."
					}));
					Application.DoEvents();
					num = 0;
				}
				bool flag = false;
				int num3 = this.ImportBuffer.Length - 1;
				for (int index2 = 0; index2 <= num3; index2++)
				{
					if (this.ImportBuffer[index2].Index == index)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					numArray = (int[])Utils.CopyArray(numArray, new int[numArray.Length + 1]);
					numArray[numArray.Length - 1] = index;
				}
			}
			this.BusyHide();
			string str = "";
			int num4 = numArray.Length - 1;
			for (int index = 0; index <= num4; index++)
			{
				str = str + DatabaseAPI.Database.Power[numArray[index]].FullName + "\r\n";
			}
			Clipboard.SetDataObject(str);
			return numArray;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x00074CE4 File Offset: 0x00072EE4
		private static int DeletePowers(int[] pList)
		{
			int index = 0;
			IPower[] powerArray = new IPower[DatabaseAPI.Database.Power.Length - pList.Length - 1 + 1];
			int num = DatabaseAPI.Database.Power.Length - 1;
			for (int index2 = 0; index2 <= num; index2++)
			{
				bool flag = false;
				int num2 = pList.Length - 1;
				for (int index3 = 0; index3 <= num2; index3++)
				{
					if (index2 == pList[index3])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					powerArray[index] = new Power(DatabaseAPI.Database.Power[index2]);
					index++;
				}
			}
			int num3;
			if (index != powerArray.Length)
			{
				Interaction.MsgBox(string.Concat(new string[]
				{
					"Power array size mismatch! Count: ",
					Conversions.ToString(index),
					" Array Length: ",
					Conversions.ToString(powerArray.Length),
					"\r\nNothing deleted."
				}), MsgBoxStyle.OkOnly, null);
				num3 = 0;
			}
			else
			{
				DatabaseAPI.Database.Power = new IPower[powerArray.Length - 1 + 1];
				int num4 = DatabaseAPI.Database.Power.Length - 1;
				for (int index2 = 0; index2 <= num4; index2++)
				{
					DatabaseAPI.Database.Power[index2] = new Power(powerArray[index2]);
				}
				num3 = index;
			}
			return num3;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x00074E50 File Offset: 0x00073050
		private void DisplayInfo()
		{
			this.lblFile.Text = FileIO.StripPath(this.FullFileName);
			this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowerVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
			this.udRevision.Value = new decimal(DatabaseAPI.Database.PowerVersion.Revision);
			this.lblCount.Text = "Records: " + Conversions.ToString(DatabaseAPI.Database.Power.Length);
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00074F40 File Offset: 0x00073140
		private void FillListView()
		{
			string[] items = new string[5];
			this.lstImport.BeginUpdate();
			this.lstImport.Items.Clear();
			int num = 0;
			int num2 = this.ImportBuffer.Length - 1;
			for (int index = 0; index <= num2 - 1; index++)
			{
				num++;
				if (num >= 100)
				{
					this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
					Application.DoEvents();
					num = 0;
				}
				if (this.ImportBuffer[index].IsValid)
				{
					items[0] = this.ImportBuffer[index].Data.FullName;
					items[1] = this.ImportBuffer[index].Data.DisplayName;
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

		// Token: 0x06000BC0 RID: 3008 RVA: 0x000750F8 File Offset: 0x000732F8
		private void frmImport_Power_Load(object sender, EventArgs e)
		{
			this.FullFileName = DatabaseAPI.Database.PowerVersion.SourceFile;
			this.DisplayInfo();
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x00075AF8 File Offset: 0x00073CF8
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
				Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
				return false;
			}
			int num2 = 0;
			int num3 = 0;
			this.ImportBuffer = new PowerData[0];
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
						if (num4 >= 9)
						{
							this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
							Application.DoEvents();
							num4 = 0;
						}
						this.ImportBuffer = (PowerData[])Utils.CopyArray(this.ImportBuffer, new PowerData[this.ImportBuffer.Length + 1]);
						this.ImportBuffer[this.ImportBuffer.Length - 1] = new PowerData(iString);
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
				Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Power Class CSV Parse Error");
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

		// Token: 0x06000BC3 RID: 3011 RVA: 0x00075D10 File Offset: 0x00073F10
		private bool ProcessImport()
		{
			bool flag = false;
			int num = 0;
			int num2 = this.lstImport.Items.Count - 1;
			for (int index = 0; index <= num2 - 1; index++)
			{
				if (this.lstImport.Items[index].Checked)
				{
					this.ImportBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
					num++;
				}
			}
			if (Interaction.MsgBox("Check for deleted powers?", MsgBoxStyle.YesNo, "Additional Check") == MsgBoxResult.Yes)
			{
				int[] pList = this.CheckForDeletedPowers();
				if (pList.Length > 0 && Interaction.MsgBox(Conversions.ToString(pList.Length) + "  deleted powers found. Delete them?", MsgBoxStyle.YesNo, "Additional Check") == MsgBoxResult.Yes)
				{
					frmImport_Power.DeletePowers(pList);
				}
			}
			DatabaseAPI.Database.PowerVersion.SourceFile = this.dlgBrowse.FileName;
			DatabaseAPI.Database.PowerVersion.RevisionDate = DateTime.Now;
			DatabaseAPI.Database.PowerVersion.Revision = Convert.ToInt32(this.udRevision.Value);
			DatabaseAPI.MatchAllIDs(null);
			DatabaseAPI.SaveMainDatabase();
			Interaction.MsgBox("Import of " + Conversions.ToString(num) + " records completed!", MsgBoxStyle.Information, "Done");
			this.DisplayInfo();
			return flag;
		}

		// Token: 0x040004C1 RID: 1217
		[AccessedThroughProperty("btnCheckAll")]
		private Button _btnCheckAll;

		// Token: 0x040004C2 RID: 1218
		[AccessedThroughProperty("btnCheckModified")]
		private Button _btnCheckModified;

		// Token: 0x040004C3 RID: 1219
		[AccessedThroughProperty("btnClose")]
		private Button _btnClose;

		// Token: 0x040004C4 RID: 1220
		[AccessedThroughProperty("btnEraseAll")]
		private Button _btnEraseAll;

		// Token: 0x040004C5 RID: 1221
		[AccessedThroughProperty("btnFile")]
		private Button _btnFile;

		// Token: 0x040004C6 RID: 1222
		[AccessedThroughProperty("btnImport")]
		private Button _btnImport;

		// Token: 0x040004C7 RID: 1223
		[AccessedThroughProperty("btnUncheckAll")]
		private Button _btnUncheckAll;

		// Token: 0x040004C8 RID: 1224
		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader _ColumnHeader1;

		// Token: 0x040004C9 RID: 1225
		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader _ColumnHeader2;

		// Token: 0x040004CA RID: 1226
		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader _ColumnHeader3;

		// Token: 0x040004CB RID: 1227
		[AccessedThroughProperty("ColumnHeader4")]
		private ColumnHeader _ColumnHeader4;

		// Token: 0x040004CC RID: 1228
		[AccessedThroughProperty("ColumnHeader5")]
		private ColumnHeader _ColumnHeader5;

		// Token: 0x040004CD RID: 1229
		[AccessedThroughProperty("dlgBrowse")]
		private OpenFileDialog _dlgBrowse;

		// Token: 0x040004CE RID: 1230
		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		// Token: 0x040004CF RID: 1231
		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		// Token: 0x040004D0 RID: 1232
		[AccessedThroughProperty("lblCount")]
		private Label _lblCount;

		// Token: 0x040004D1 RID: 1233
		[AccessedThroughProperty("lblDate")]
		private Label _lblDate;

		// Token: 0x040004D2 RID: 1234
		[AccessedThroughProperty("lblFile")]
		private Label _lblFile;

		// Token: 0x040004D3 RID: 1235
		[AccessedThroughProperty("lstImport")]
		private ListView _lstImport;

		// Token: 0x040004D4 RID: 1236
		[AccessedThroughProperty("udRevision")]
		private NumericUpDown _udRevision;

		// Token: 0x040004D5 RID: 1237
		private frmBusy bFrm;

		// Token: 0x040004D7 RID: 1239
		private string FullFileName;

		// Token: 0x040004D8 RID: 1240
		private PowerData[] ImportBuffer;
	}
}
