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
	// Token: 0x02000043 RID: 67
	
	public partial class frmImport_SetBonusAssignment : Form
	{
		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000C49 RID: 3145 RVA: 0x0007A04C File Offset: 0x0007824C
		// (set) Token: 0x06000C4A RID: 3146 RVA: 0x0007A064 File Offset: 0x00078264
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

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000C4B RID: 3147 RVA: 0x0007A0C0 File Offset: 0x000782C0
		// (set) Token: 0x06000C4C RID: 3148 RVA: 0x0007A0D8 File Offset: 0x000782D8
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

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x0007A134 File Offset: 0x00078334
		// (set) Token: 0x06000C4E RID: 3150 RVA: 0x0007A14C File Offset: 0x0007834C
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

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000C4F RID: 3151 RVA: 0x0007A1A8 File Offset: 0x000783A8
		// (set) Token: 0x06000C50 RID: 3152 RVA: 0x0007A1C0 File Offset: 0x000783C0
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

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000C51 RID: 3153 RVA: 0x0007A1CC File Offset: 0x000783CC
		// (set) Token: 0x06000C52 RID: 3154 RVA: 0x0007A1E4 File Offset: 0x000783E4
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

		// Token: 0x06000C53 RID: 3155 RVA: 0x0007A1EE File Offset: 0x000783EE
		public frmImport_SetBonusAssignment()
		{
			base.Load += this.frmImport_SetBonusAssignment_Load;
			this.FullFileName = "";
			this.InitializeComponent();
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0007A21E File Offset: 0x0007841E
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0007A228 File Offset: 0x00078428
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

		// Token: 0x06000C56 RID: 3158 RVA: 0x0007A27F File Offset: 0x0007847F
		private void btnImport_Click(object sender, EventArgs e)
		{
			this.ParseClasses(this.FullFileName);
			this.BusyHide();
			this.DisplayInfo();
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0007A2A0 File Offset: 0x000784A0
		private void BusyHide()
		{
			if (this.bFrm != null)
			{
				this.bFrm.Close();
				this.bFrm = null;
			}
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0007A2D0 File Offset: 0x000784D0
		private void BusyMsg(string sMessage)
		{
			if (this.bFrm == null)
			{
				this.bFrm = new frmBusy();
				this.bFrm.Show(this);
			}
			this.bFrm.SetMessage(sMessage);
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x0007A315 File Offset: 0x00078515
		public void DisplayInfo()
		{
			this.lblFile.Text = FileIO.StripPath(this.FullFileName);
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0007A380 File Offset: 0x00078580
		private void frmImport_SetBonusAssignment_Load(object sender, EventArgs e)
		{
			this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile.Replace("powersets2", "boostsets4");
			this.DisplayInfo();
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x0007A6D0 File Offset: 0x000788D0
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
				Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Bonus CSV Not Opened");
				return false;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = DatabaseAPI.Database.EnhancementSets.Count - 1;
			for (int index3 = 0; index3 <= num5; index3++)
			{
				DatabaseAPI.Database.EnhancementSets[index3].Bonus = new EnhancementSet.BonusItem[0];
				DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus = new EnhancementSet.BonusItem[6];
				int num6 = DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus.Length - 1;
				for (int index4 = 0; index4 <= num6; index4++)
				{
					DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus[index4] = default(EnhancementSet.BonusItem);
					DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus[index4].Name = new string[0];
					DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus[index4].Index = new int[0];
					DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus[index4].AltString = "";
					DatabaseAPI.Database.EnhancementSets[index3].SpecialBonus[index4].Special = -1;
				}
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
						int index5 = DatabaseAPI.NidFromUidioSet(array[0]);
						if (index5 > -1)
						{
							int integer = Conversions.ToInteger(array[1]);
							string[] strArray = array[3].Split(" ".ToCharArray());
							Enums.ePvX ePvX = Enums.ePvX.Any;
							if (array[2].Contains("isPVPMap?"))
							{
								ePvX = Enums.ePvX.PvP;
								array[2] = array[2].Replace("isPVPMap?", "").Replace("  ", " ");
							}
							string[] strArray2 = array[2].Split(" ".ToCharArray());
							if (array[2] == "")
							{
								DatabaseAPI.Database.EnhancementSets[index5].Bonus = (EnhancementSet.BonusItem[])Utils.CopyArray(DatabaseAPI.Database.EnhancementSets[index5].Bonus, new EnhancementSet.BonusItem[DatabaseAPI.Database.EnhancementSets[index5].Bonus.Length + 1]);
								DatabaseAPI.Database.EnhancementSets[index5].Bonus[DatabaseAPI.Database.EnhancementSets[index5].Bonus.Length - 1] = default(EnhancementSet.BonusItem);
								EnhancementSet.BonusItem[] bonus = DatabaseAPI.Database.EnhancementSets[index5].Bonus;
								int index6 = DatabaseAPI.Database.EnhancementSets[index5].Bonus.Length - 1;
								bonus[index6].AltString = "";
								bonus[index6].Name = new string[strArray.Length - 1 + 1];
								bonus[index6].Index = new int[strArray.Length - 1 + 1];
								int num7 = bonus[index6].Name.Length - 1;
								for (int index3 = 0; index3 <= num7; index3++)
								{
									bonus[index6].Name[index3] = strArray[index3];
									bonus[index6].Index[index3] = DatabaseAPI.NidFromUidPower(strArray[index3]);
								}
								bonus[index6].Special = -1;
								bonus[index6].PvMode = ePvX;
								bonus[index6].Slotted = integer;
							}
							else
							{
								int num8 = -1;
								int num9 = strArray2.Length - 1;
								for (int index3 = 0; index3 <= num9; index3++)
								{
									int num10 = DatabaseAPI.NidFromUidEnh(strArray2[index3]);
									if (num10 > -1)
									{
										int num11 = DatabaseAPI.Database.EnhancementSets[index5].Enhancements.Length - 1;
										for (int index7 = 0; index7 <= num11; index7++)
										{
											if (DatabaseAPI.Database.EnhancementSets[index5].Enhancements[index7] == num10)
											{
												num8 = index7;
												break;
											}
										}
										break;
									}
								}
								if (num8 > -1)
								{
									EnhancementSet.BonusItem[] specialBonus = DatabaseAPI.Database.EnhancementSets[index5].SpecialBonus;
									int index8 = num8;
									specialBonus[index8].AltString = "";
									specialBonus[index8].Name = new string[strArray.Length - 1 + 1];
									specialBonus[index8].Index = new int[strArray.Length - 1 + 1];
									int num12 = specialBonus[index8].Name.Length - 1;
									for (int index3 = 0; index3 <= num12; index3++)
									{
										specialBonus[index8].Name[index3] = strArray[index3];
										specialBonus[index8].Index[index3] = DatabaseAPI.NidFromUidPower(strArray[index3]);
									}
									specialBonus[index8].Special = num8;
									specialBonus[index8].PvMode = ePvX;
									specialBonus[index8].Slotted = integer;
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
				Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Power Class CSV Parse Error");
				return false;
			}
			iStream.Close();
			DatabaseAPI.SaveEnhancementDb();
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

		// Token: 0x0400050F RID: 1295
		[AccessedThroughProperty("btnClose")]
		private Button _btnClose;

		// Token: 0x04000510 RID: 1296
		[AccessedThroughProperty("btnFile")]
		private Button _btnFile;

		// Token: 0x04000511 RID: 1297
		[AccessedThroughProperty("btnImport")]
		private Button _btnImport;

		// Token: 0x04000512 RID: 1298
		[AccessedThroughProperty("dlgBrowse")]
		private OpenFileDialog _dlgBrowse;

		// Token: 0x04000513 RID: 1299
		[AccessedThroughProperty("lblFile")]
		private Label _lblFile;

		// Token: 0x04000514 RID: 1300
		private frmBusy bFrm;

		// Token: 0x04000516 RID: 1302
		private string FullFileName;
	}
}
