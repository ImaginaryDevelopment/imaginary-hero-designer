using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x02000029 RID: 41
	public partial class frmDPSCalc : Form
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x0003DEA4 File Offset: 0x0003C0A4
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x0003DEBC File Offset: 0x0003C0BC
		internal virtual CheckBox chkSortByLevel
		{
			get
			{
				return this._chkSortByLevel;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.chkSortByLevel_CheckedChanged);
				if (this._chkSortByLevel != null)
				{
					this._chkSortByLevel.CheckedChanged -= eventHandler;
				}
				this._chkSortByLevel = value;
				if (this._chkSortByLevel != null)
				{
					this._chkSortByLevel.CheckedChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0003DF18 File Offset: 0x0003C118
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x0003DF30 File Offset: 0x0003C130
		internal virtual CheckBox chkDamageBuffs
		{
			get
			{
				return this._chkDamageBuffs;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkDamageBuffs = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0003DF3C File Offset: 0x0003C13C
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0003DF54 File Offset: 0x0003C154
		internal virtual ColumnHeader chPower
		{
			get
			{
				return this._chPower;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chPower = value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0003DF60 File Offset: 0x0003C160
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x0003DF78 File Offset: 0x0003C178
		internal virtual ColumnHeader chDPA
		{
			get
			{
				return this._chDPA;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chDPA = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0003DF84 File Offset: 0x0003C184
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0003DF9C File Offset: 0x0003C19C
		internal virtual ColumnHeader chDamage
		{
			get
			{
				return this._chDamage;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chDamage = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0003DFA8 File Offset: 0x0003C1A8
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0003DFC0 File Offset: 0x0003C1C0
		internal virtual ColumnHeader chRecharge
		{
			get
			{
				return this._chRecharge;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chRecharge = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0003DFCC File Offset: 0x0003C1CC
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x0003DFE4 File Offset: 0x0003C1E4
		internal virtual ColumnHeader chAnimation
		{
			get
			{
				return this._chAnimation;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chAnimation = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0003DFF0 File Offset: 0x0003C1F0
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x0003E008 File Offset: 0x0003C208
		internal virtual ColumnHeader chEndurance
		{
			get
			{
				return this._chEndurance;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chEndurance = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x0003E014 File Offset: 0x0003C214
		// (set) Token: 0x060004FA RID: 1274 RVA: 0x0003E02C File Offset: 0x0003C22C
		internal virtual ColumnHeader chDamageBuff
		{
			get
			{
				return this._chDamageBuff;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chDamageBuff = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0003E038 File Offset: 0x0003C238
		// (set) Token: 0x060004FC RID: 1276 RVA: 0x0003E050 File Offset: 0x0003C250
		internal virtual ColumnHeader chResistanceDebuff
		{
			get
			{
				return this._chResistanceDebuff;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chResistanceDebuff = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0003E05C File Offset: 0x0003C25C
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x0003E074 File Offset: 0x0003C274
		internal virtual ColumnHeader chBuildID
		{
			get
			{
				return this._chBuildID;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chBuildID = value;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x0003E080 File Offset: 0x0003C280
		// (set) Token: 0x06000500 RID: 1280 RVA: 0x0003E098 File Offset: 0x0003C298
		internal virtual ImageButton ibClear
		{
			get
			{
				return this._ibClear;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClear_ButtonClicked);
				if (this._ibClear != null)
				{
					this._ibClear.ButtonClicked -= clickedEventHandler;
				}
				this._ibClear = value;
				if (this._ibClear != null)
				{
					this._ibClear.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0003E0F4 File Offset: 0x0003C2F4
		// (set) Token: 0x06000502 RID: 1282 RVA: 0x0003E10C File Offset: 0x0003C30C
		internal virtual ImageButton ibClose
		{
			get
			{
				return this._ibClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
				if (this._ibClose != null)
				{
					this._ibClose.ButtonClicked -= clickedEventHandler;
				}
				this._ibClose = value;
				if (this._ibClose != null)
				{
					this._ibClose.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0003E168 File Offset: 0x0003C368
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0003E180 File Offset: 0x0003C380
		internal virtual ImageButton ibAutoMode
		{
			get
			{
				return this._ibAutoMode;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibAutoMode_ButtonClicked);
				if (this._ibAutoMode != null)
				{
					this._ibAutoMode.ButtonClicked -= clickedEventHandler;
				}
				this._ibAutoMode = value;
				if (this._ibAutoMode != null)
				{
					this._ibAutoMode.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0003E1DC File Offset: 0x0003C3DC
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x0003E1F4 File Offset: 0x0003C3F4
		internal virtual ImageButton ibTopmost
		{
			get
			{
				return this._ibTopmost;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTopmost_ButtonClicked);
				if (this._ibTopmost != null)
				{
					this._ibTopmost.ButtonClicked -= clickedEventHandler;
				}
				this._ibTopmost = value;
				if (this._ibTopmost != null)
				{
					this._ibTopmost.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0003E250 File Offset: 0x0003C450
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x0003E268 File Offset: 0x0003C468
		internal virtual ImageList ilAttackChain
		{
			get
			{
				return this._ilAttackChain;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ilAttackChain = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0003E274 File Offset: 0x0003C474
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x0003E28C File Offset: 0x0003C48C
		internal virtual Label lblHeader
		{
			get
			{
				return this._lblHeader;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblHeader = value;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0003E298 File Offset: 0x0003C498
		// (set) Token: 0x0600050C RID: 1292 RVA: 0x0003E2B0 File Offset: 0x0003C4B0
		internal virtual Label lblDPS
		{
			get
			{
				return this._lblDPS;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDPS = value;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x0003E2BC File Offset: 0x0003C4BC
		// (set) Token: 0x0600050E RID: 1294 RVA: 0x0003E2D4 File Offset: 0x0003C4D4
		internal virtual Label lblEPS
		{
			get
			{
				return this._lblEPS;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblEPS = value;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x0003E2E0 File Offset: 0x0003C4E0
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0003E2F8 File Offset: 0x0003C4F8
		internal virtual Label lblDPSNum
		{
			get
			{
				return this._lblDPSNum;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblDPSNum = value;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0003E304 File Offset: 0x0003C504
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x0003E31C File Offset: 0x0003C51C
		internal virtual Label lblEPSNum
		{
			get
			{
				return this._lblEPSNum;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblEPSNum = value;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x0003E328 File Offset: 0x0003C528
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x0003E340 File Offset: 0x0003C540
		internal virtual TextBox tbDPSOutput
		{
			get
			{
				return this._tbDPSOutput;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._tbDPSOutput = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x0003E34C File Offset: 0x0003C54C
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x0003E364 File Offset: 0x0003C564
		internal virtual ListView lvPower
		{
			get
			{
				return this._lvPower;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvPower_MouseEnter);
				ItemCheckedEventHandler checkedEventHandler = new ItemCheckedEventHandler(this.lvPower_ItemChecked);
				ListViewItemSelectionChangedEventHandler changedEventHandler = new ListViewItemSelectionChangedEventHandler(this.lvPower_Clicked);
				if (this._lvPower != null)
				{
					this._lvPower.MouseEnter -= eventHandler;
					this._lvPower.ItemChecked -= checkedEventHandler;
					this._lvPower.ItemSelectionChanged -= changedEventHandler;
				}
				this._lvPower = value;
				if (this._lvPower != null)
				{
					this._lvPower.MouseEnter += eventHandler;
					this._lvPower.ItemChecked += checkedEventHandler;
					this._lvPower.ItemSelectionChanged += changedEventHandler;
				}
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x0003E40C File Offset: 0x0003C60C
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x0003E424 File Offset: 0x0003C624
		internal virtual Panel Panel1
		{
			get
			{
				return this._Panel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel1 = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x0003E430 File Offset: 0x0003C630
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x0003E448 File Offset: 0x0003C648
		internal virtual Panel Panel2
		{
			get
			{
				return this._Panel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel2 = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0003E454 File Offset: 0x0003C654
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x0003E46C File Offset: 0x0003C66C
		internal virtual ToolTip ToolTip1
		{
			get
			{
				return this._ToolTip1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ToolTip1 = value;
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0003E478 File Offset: 0x0003C678
		public frmDPSCalc(frmMain iParent)
		{
			base.FormClosed += this.frmDPSCalc_FormClosed;
			base.Load += this.frmDPSCalc_Load;
			this.Loading = true;
			this.InitializeComponent();
			this.myParent = iParent;
			this.bxRecipe = new ExtendedBitmap(I9Gfx.GetRecipeName());
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0003E4D9 File Offset: 0x0003C6D9
		private void chkRecipe_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0003E4DC File Offset: 0x0003C6DC
		private void chkSortByLevel_CheckedChanged(object sender, EventArgs e)
		{
			this.FillPowerList();
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0003E538 File Offset: 0x0003C738
		private void FillAttackChainWindow(frmDPSCalc.PowerList[] AttackChain)
		{
			int index;
			if (this.chkSortByLevel.Checked)
			{
				index = 0;
				while (AttackChain[index].DPA != 0f)
				{
					string[] strArray = AttackChain[index].PowerName.Split(new char[]
					{
						'-'
					});
					AttackChain[index].PowerName = strArray[1];
					index++;
				}
			}
			string str = AttackChain[0].PowerName;
			float damage = AttackChain[0].Damage;
			float endurance = AttackChain[0].Endurance;
			float animation = AttackChain[0].Animation;
			index = 1;
			while (AttackChain[index].DPA != 0f)
			{
				str += " --> ";
				str += AttackChain[index].PowerName;
				damage += AttackChain[index].Damage;
				animation += AttackChain[index].Animation;
				endurance += AttackChain[index].Endurance;
				index++;
			}
			this.lblDPSNum.Text = (damage / animation).ToString();
			this.lblEPSNum.Text = (endurance / animation).ToString();
			this.tbDPSOutput.Text = str;
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0003E6A0 File Offset: 0x0003C8A0
		private void FillPowerList()
		{
			this.GlobalDamageBuff = 0f;
			this.lvPower.BeginUpdate();
			this.lvPower.Items.Clear();
			this.lvPower.Sorting = SortOrder.None;
			this.lvPower.Items.Add(" - All Powers - ");
			this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = -1;
			int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
			for (int powerLocation = 0; powerLocation <= num; powerLocation++)
			{
				if (MidsContext.Character.CurrentBuild.Powers[powerLocation].NIDPower > -1)
				{
					bool flag = false;
					if (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.DisplayName == "Rest")
					{
						flag = true;
					}
					int index = 0;
					while (index < MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects.Length && !flag)
					{
						if (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.Damage || (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.Resistance && MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].MagPercent < 0f) || (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.DamageBuff && MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].Mag > 0f && !MidsContext.Character.CurrentBuild.Powers[powerLocation].StatInclude) || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.EntCreate)
						{
							string text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[powerLocation].NIDPower].DisplayName;
							if (this.chkSortByLevel.Checked)
							{
								text = Strings.Format(MidsContext.Character.CurrentBuild.Powers[powerLocation].Level + 1, "00") + " - " + text;
							}
							string[] damageData = this.GetDamageData(powerLocation);
							this.lvPower.Items.Add(text).SubItems.AddRange(damageData);
							this.GlobalDamageBuff += float.Parse(damageData[5]) * (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].Duration / float.Parse(damageData[2]));
							this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = powerLocation;
							flag = true;
						}
						index++;
					}
				}
			}
			this.lvPower.Sorting = SortOrder.Ascending;
			this.lvPower.Sort();
			if (this.lvPower.Items.Count > 0)
			{
				this.lvPower.Items[0].Selected = true;
				this.lvPower.Items[0].Checked = true;
			}
			this.lvPower.EndUpdate();
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0003EAC1 File Offset: 0x0003CCC1
		private void frmDPSCalc_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.StoreLocation();
			this.myParent.FloatDPSCalc(false);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0003EAD8 File Offset: 0x0003CCD8
		private void frmDPSCalc_Load(object sender, EventArgs e)
		{
			this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
			this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
			this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.Loading = false;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0003EBB4 File Offset: 0x0003CDB4
		private void ibClear_ButtonClicked()
		{
			this.ibClear.Checked = true;
			for (int index = 1; index < this.lvPower.Items.Count; index++)
			{
				this.lvPower.Items[index].Checked = false;
			}
			this.lvPower.Items[0].Checked = true;
			this.lvPower.Items[0].Selected = true;
			this.GlobalPowerList = new frmDPSCalc.PowerList[0];
			this.tbDPSOutput.Text = "";
			this.lblDPSNum.Text = " - Null - ";
			this.lblEPSNum.Text = " - Null - ";
			this.ibClear.Checked = false;
			this.lblHeader.ForeColor = Color.FromArgb(192, 192, 255);
			this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
			if (this.ibAutoMode.TextOff == "Automagical")
			{
				this.CalculateDPS();
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0003ECDA File Offset: 0x0003CEDA
		private void ibClose_ButtonClicked()
		{
			base.Close();
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0003ECE4 File Offset: 0x0003CEE4
		private void ibAutoMode_ButtonClicked()
		{
			if (this.ibAutoMode.TextOff == "Automagical")
			{
				this.ToolTip1.SetToolTip(this.ibAutoMode, "Click to enable Automagical Mode");
				this.ibAutoMode.TextOff = "Manual";
				this.lvPower.Items[0].Selected = true;
				if (this.GlobalPowerList.Length > 0)
				{
					string powerName2;
					if (!this.chkSortByLevel.Checked)
					{
						powerName2 = this.GlobalPowerList[0].PowerName;
					}
					else
					{
						string[] array = this.GlobalPowerList[0].PowerName.Split(new char[]
						{
							'-'
						});
						powerName2 = array[1];
					}
					this.tbDPSOutput.Text = powerName2;
					for (int num = 1; num < this.GlobalPowerList.Length; num++)
					{
						if (!this.chkSortByLevel.Checked)
						{
							powerName2 = this.GlobalPowerList[num].PowerName;
						}
						else
						{
							string[] array = this.GlobalPowerList[num].PowerName.Split(new char[]
							{
								'-'
							});
							powerName2 = array[1];
						}
						TextBox tbDpsOutput = this.tbDPSOutput;
						tbDpsOutput.Text = tbDpsOutput.Text + " --> " + powerName2;
					}
				}
				else
				{
					this.ibClear_ButtonClicked();
				}
				for (int num = 1; num < this.GlobalPowerList.Length; num++)
				{
				}
			}
			else
			{
				this.ibAutoMode.TextOff = "Automagical";
				this.ToolTip1.SetToolTip(this.ibAutoMode, "Click to enable Manual Mode");
			}
			this.CalculateDPS();
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0003EEBC File Offset: 0x0003D0BC
		private void ibTopmost_ButtonClicked()
		{
			base.TopMost = this.ibTopmost.Checked;
			if (base.TopMost)
			{
				base.BringToFront();
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0003FE2C File Offset: 0x0003E02C
		private void lvPower_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (e.Item.Index == 0)
			{
				if (Operators.ConditionalCompareObjectLess(e.Item.Tag, 0, false) && e.Item.Checked)
				{
					int num = this.lvPower.Items.Count - 1;
					for (int index = 1; index <= num; index++)
					{
						this.lvPower.Items[index].Checked = false;
					}
				}
			}
			else if (e.Item.Checked)
			{
				this.lvPower.Items[0].Checked = false;
			}
			this.CalculateDPS();
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0003FEF8 File Offset: 0x0003E0F8
		private void lvPower_Clicked(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (this.ibAutoMode.TextOff == "Manual" && e.Item.Index != 0 && e.Item.Selected)
			{
				e.Item.Checked = true;
				frmDPSCalc.PowerList[] globalPowerList = this.GlobalPowerList;
				this.GlobalPowerList = new frmDPSCalc.PowerList[globalPowerList.Length + 1];
				for (int index = 0; index < globalPowerList.Length; index++)
				{
					this.GlobalPowerList[index] = globalPowerList[index];
				}
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].PowerName = e.Item.Text;
				string text;
				if (!this.chkSortByLevel.Checked)
				{
					text = e.Item.Text;
				}
				else
				{
					string[] array = e.Item.Text.Split(new char[]
					{
						'-'
					});
					text = array[1];
				}
				if (this.tbDPSOutput.Text == "")
				{
					this.tbDPSOutput.Text = text;
				}
				else
				{
					TextBox tbDpsOutput = this.tbDPSOutput;
					tbDpsOutput.Text = tbDpsOutput.Text + " -->" + text;
				}
				if (e.Item.SubItems[2].Text != "-")
				{
					this.GlobalPowerList[this.GlobalPowerList.Length - 1].Damage = float.Parse(e.Item.SubItems[2].Text);
				}
				else
				{
					this.GlobalPowerList[this.GlobalPowerList.Length - 1].Damage = 0f;
				}
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].Endurance = float.Parse(e.Item.SubItems[5].Text);
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].Recharge = float.Parse(e.Item.SubItems[3].Text);
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].DamageBuff = float.Parse(e.Item.SubItems[6].Text);
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].ResistanceDeBuff = float.Parse(e.Item.SubItems[7].Text);
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].Animation = float.Parse(e.Item.SubItems[4].Text);
				this.GlobalPowerList[this.GlobalPowerList.Length - 1].RechargeTimer = 0f;
			}
			this.CalculateDPS();
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00040210 File Offset: 0x0003E410
		private void lvPower_MouseEnter(object sender, EventArgs e)
		{
			this.lvPower.Focus();
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00040220 File Offset: 0x0003E420
		private static void putInList(ref frmDPSCalc.CountingList[] tl, string item)
		{
			int num = tl.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (tl[index].Text == item)
				{
					frmDPSCalc.CountingList[] array = tl;
					int num2 = index;
					array[num2].Count = array[num2].Count + 1;
					return;
				}
			}
			tl = (frmDPSCalc.CountingList[])Utils.CopyArray(tl, new frmDPSCalc.CountingList[tl.Length + 1]);
			tl[tl.Length - 1].Count = 1;
			tl[tl.Length - 1].Text = item;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x000402CC File Offset: 0x0003E4CC
		public void SetLocation()
		{
			Rectangle rectangle = default(Rectangle);
			rectangle.X = MainModule.MidsController.SzFrmRecipe.X;
			rectangle.Y = MainModule.MidsController.SzFrmRecipe.Y;
			rectangle.Width = 800;
			rectangle.Height = MainModule.MidsController.SzFrmRecipe.Height;
			if (rectangle.Width < 1)
			{
				rectangle.Width = base.Width;
			}
			if (rectangle.Height < 1)
			{
				rectangle.Height = base.Height;
			}
			if (rectangle.Width < this.MinimumSize.Width)
			{
				rectangle.Width = this.MinimumSize.Width;
			}
			if (rectangle.Height < this.MinimumSize.Height)
			{
				rectangle.Height = this.MinimumSize.Height;
			}
			if (rectangle.X < 1)
			{
				rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - base.Width) / 2.0);
			}
			if (rectangle.Y < 32)
			{
				rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - base.Height) / 2.0);
			}
			base.Top = rectangle.Y;
			base.Left = rectangle.X;
			base.Height = rectangle.Height;
			base.Width = rectangle.Width;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00040498 File Offset: 0x0003E698
		private void StoreLocation()
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				MainModule.MidsController.SzFrmRecipe.X = base.Left;
				MainModule.MidsController.SzFrmRecipe.Y = base.Top;
				MainModule.MidsController.SzFrmRecipe.Width = base.Width;
				MainModule.MidsController.SzFrmRecipe.Height = base.Height;
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x000404F8 File Offset: 0x0003E6F8
		public void UpdateData()
		{
			this.BackColor = this.myParent.BackColor;
			this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
			this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
			this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.ibClear.IA = this.myParent.Drawing.pImageAttributes;
			this.ibClear.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibClear.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.ibAutoMode.IA = this.myParent.Drawing.pImageAttributes;
			this.ibAutoMode.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibAutoMode.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.FillPowerList();
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x000406A8 File Offset: 0x0003E8A8
		private string[] GetDamageData(int powerLocation)
		{
			IPower enhancedPower = MainModule.MidsController.Toon.GetEnhancedPower(powerLocation);
			float damageValue = enhancedPower.FXGetDamageValue();
			float rechargeTime = enhancedPower.RechargeTime;
			float num = (float)(Math.Ceiling((double)(enhancedPower.CastTimeReal / 0.132f)) + 1.0) * 0.132f;
			float endCost = enhancedPower.EndCost;
			Enums.ShortFX effectMag = enhancedPower.GetEffectMag(Enums.eEffectType.DamageBuff, Enums.eToWho.Self, false);
			Enums.ShortFX effectMag2 = enhancedPower.GetEffectMag(Enums.eEffectType.Resistance, Enums.eToWho.Target, false);
			effectMag.Multiply();
			effectMag2.Multiply();
			float num2 = damageValue / num;
			string[] strArray;
			if (damageValue != 0f)
			{
				string[] array = new string[]
				{
					num2.ToString(),
					damageValue.ToString(),
					rechargeTime.ToString(),
					num.ToString(),
					endCost.ToString(),
					effectMag.Sum.ToString(),
					effectMag2.Sum.ToString(),
					powerLocation.ToString()
				};
				strArray = array;
			}
			else
			{
				string[] array = new string[]
				{
					"-",
					"-",
					rechargeTime.ToString(),
					num.ToString(),
					endCost.ToString(),
					effectMag.Sum.ToString(),
					effectMag2.Sum.ToString(),
					powerLocation.ToString()
				};
				strArray = array;
			}
			return strArray;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00040824 File Offset: 0x0003EA24
		private void lvPower_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			this.lvPower.Sort();
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00040834 File Offset: 0x0003EA34
		private frmDPSCalc.PowerList[] IncrementRecharge(frmDPSCalc.PowerList[] List, float Time)
		{
			for (int index = 0; index < List.Length; index++)
			{
				int index2 = index;
				List[index2].RechargeTimer = List[index2].RechargeTimer - Time;
			}
			return List;
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0004089C File Offset: 0x0003EA9C
		private void CalculateDPS()
		{
			if (this.ibAutoMode.TextOff == "Automagical")
			{
				frmDPSCalc.PowerList[] array = new frmDPSCalc.PowerList[this.lvPower.Items.Count - 1];
				int length = 0;
				for (int index = 1; index < this.lvPower.Items.Count; index++)
				{
					if (this.lvPower.Items[0].Checked || this.lvPower.Items[index].Checked)
					{
						array[length].PowerName = this.lvPower.Items[index].Text;
						if (this.lvPower.Items[index].SubItems[1].Text != "-")
						{
							array[length].Damage = float.Parse(this.lvPower.Items[index].SubItems[2].Text);
							if (!this.chkDamageBuffs.Checked)
							{
								IPower basePower = MainModule.MidsController.Toon.GetBasePower(int.Parse(this.lvPower.Items[index].SubItems[8].Text), -1);
								frmDPSCalc.PowerList[] array2 = array;
								int num9 = length;
								array2[num9].Damage = array2[num9].Damage + basePower.FXGetDamageValue() * (this.GlobalDamageBuff / 100f);
							}
							array[length].DPA = float.Parse(this.lvPower.Items[index].SubItems[1].Text);
							array[length].HidenDPA = float.Parse(this.lvPower.Items[index].SubItems[1].Text);
						}
						array[length].Recharge = float.Parse(this.lvPower.Items[index].SubItems[3].Text);
						array[length].Animation = float.Parse(this.lvPower.Items[index].SubItems[4].Text);
						array[length].Endurance = float.Parse(this.lvPower.Items[index].SubItems[5].Text);
						array[length].DamageBuff = float.Parse(this.lvPower.Items[index].SubItems[6].Text);
						array[length].ResistanceDeBuff = float.Parse(this.lvPower.Items[index].SubItems[7].Text);
						array[length].RechargeTimer = -1f;
						if (array[length].DamageBuff > 0f && array[length].DPA != 0f)
						{
							IPower basePower = MainModule.MidsController.Toon.GetBasePower(int.Parse(this.lvPower.Items[index].SubItems[8].Text), -1);
							array[length].HidenDPA = basePower.FXGetDamageValue();
							array[length].HidenDPA = array[length].HidenDPA * (array[length].DamageBuff / array[length].Recharge) / array[length].Animation;
						}
						length++;
					}
				}
				if (length < this.lvPower.Items.Count - 1)
				{
					frmDPSCalc.PowerList[] powerListArray = array;
					array = new frmDPSCalc.PowerList[length];
					for (int index = 0; index < length; index++)
					{
						array[index] = powerListArray[index];
					}
				}
				if (array.Length > 1)
				{
					Array.Sort<frmDPSCalc.PowerList>(array, (frmDPSCalc.PowerList x, frmDPSCalc.PowerList y) => x.HidenDPA.CompareTo(y.HidenDPA));
					float num10 = array[length - 1].Recharge + 5f;
					float num = num10;
					int num2 = length - 1;
					while (num > 0f && num2 > 0)
					{
						num -= array[num2--].Animation;
					}
					frmDPSCalc.PowerList[] List = new frmDPSCalc.PowerList[length - num2];
					int num3 = 0;
					for (int index = 0; index < length - num2; index++)
					{
						if (array[length - 1 - index].Recharge <= 20f)
						{
							List[num3++] = array[length - 1 - index];
						}
					}
					float num4 = 0f;
					for (int index = 0; index < List.Length; index++)
					{
						if (num4 < List[index].Recharge)
						{
							num4 = List[index].Recharge;
						}
					}
					frmDPSCalc.PowerList[] AttackChain = new frmDPSCalc.PowerList[20];
					int index2 = 1;
					int index3 = 1;
					AttackChain[0] = List[0];
					float animation = AttackChain[0].Animation;
					List[0].RechargeTimer = List[0].Recharge;
					while (animation < num4 + 1f)
					{
						for (int index = index2; index >= 0; index--)
						{
							if (index2 >= List.Length)
							{
								animation += 0.01f;
								List = this.IncrementRecharge(List, 0.01f);
							}
							else if (List[index].RechargeTimer <= 0f)
							{
								index2 = index;
							}
						}
						if (index2 >= List.Length)
						{
							index2--;
							animation += 0.01f;
							List = this.IncrementRecharge(List, 0.01f);
						}
						while (List[index2].RechargeTimer > 0f)
						{
							index2++;
							if (index2 >= List.Length)
							{
								index2 = 0;
								animation += 0.01f;
								List = this.IncrementRecharge(List, 0.01f);
							}
						}
						AttackChain[index3] = List[index2];
						animation += AttackChain[index3].Animation;
						List = this.IncrementRecharge(List, AttackChain[index3].Animation);
						List[index2].RechargeTimer = List[index2].Recharge;
						index2++;
						index3++;
					}
					this.FillAttackChainWindow(AttackChain);
				}
				else if (array.Length == 1)
				{
					this.tbDPSOutput.Text = "You cannot make an attack chain from one attack";
				}
				else
				{
					this.tbDPSOutput.Text = "Come on Kiddo, gotta pick something :)";
				}
			}
			else
			{
				float num5 = 0f;
				float num6 = 0f;
				float num7 = 0f;
				bool flag = true;
				for (int index = 0; index < this.GlobalPowerList.Length; index++)
				{
					if (this.GlobalPowerList[index].Damage > 0f)
					{
						num5 += this.GlobalPowerList[index].Damage;
						num6 += this.GlobalPowerList[index].Endurance;
						num7 += this.GlobalPowerList[index].Animation;
						this.GlobalPowerList[index].RechargeTimer = this.GlobalPowerList[index].Recharge;
					}
					float animation = this.GlobalPowerList[index].Animation;
				}
				frmDPSCalc.PowerList[] powerListArray2 = new frmDPSCalc.PowerList[this.GlobalPowerList.Length * 2];
				int num8 = 0;
				for (int index = 0; index < powerListArray2.Length; index++)
				{
					if (index > this.GlobalPowerList.Length - 1)
					{
						num8 = index - (this.GlobalPowerList.Length - 1) - 1;
					}
					powerListArray2[index] = this.GlobalPowerList[num8++];
				}
				for (int index = 0; index < powerListArray2.Length; index++)
				{
					for (int index4 = index + 1; index4 < powerListArray2.Length; index4++)
					{
						if (powerListArray2[index].PowerName != powerListArray2[index4].PowerName)
						{
							frmDPSCalc.PowerList[] array3 = powerListArray2;
							int num11 = index;
							array3[num11].RechargeTimer = array3[num11].RechargeTimer - powerListArray2[index4].Animation;
						}
						else if (powerListArray2[index].RechargeTimer > 0f)
						{
							flag = false;
						}
					}
				}
				for (int index = powerListArray2.Length - 1; index >= 0; index--)
				{
					for (int index4 = index - 1; index4 >= 0; index4--)
					{
						if (powerListArray2[index].PowerName != powerListArray2[index4].PowerName)
						{
							frmDPSCalc.PowerList[] array4 = powerListArray2;
							int num12 = index;
							array4[num12].RechargeTimer = array4[num12].RechargeTimer - powerListArray2[index4].Animation;
						}
						else if (powerListArray2[index].RechargeTimer > 0f)
						{
							flag = false;
						}
					}
				}
				if (!flag)
				{
					this.lblHeader.ForeColor = Color.Red;
					this.lblHeader.Text = "Impossible Chain";
				}
				else
				{
					this.lblHeader.ForeColor = Color.FromArgb(192, 192, 255);
					this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
				}
				this.lblDPSNum.Text = (num5 / num7).ToString();
				this.lblEPSNum.Text = (num6 / num7).ToString();
			}
		}

		// Token: 0x0400021F RID: 543
		[AccessedThroughProperty("chkSortByLevel")]
		private CheckBox _chkSortByLevel;

		// Token: 0x04000220 RID: 544
		[AccessedThroughProperty("chkDamageBuffs")]
		private CheckBox _chkDamageBuffs;

		// Token: 0x04000221 RID: 545
		[AccessedThroughProperty("chPower")]
		private ColumnHeader _chPower;

		// Token: 0x04000222 RID: 546
		[AccessedThroughProperty("chDPA")]
		private ColumnHeader _chDPA;

		// Token: 0x04000223 RID: 547
		[AccessedThroughProperty("chDamage")]
		private ColumnHeader _chDamage;

		// Token: 0x04000224 RID: 548
		[AccessedThroughProperty("chRecharge")]
		private ColumnHeader _chRecharge;

		// Token: 0x04000225 RID: 549
		[AccessedThroughProperty("chAnimation")]
		private ColumnHeader _chAnimation;

		// Token: 0x04000226 RID: 550
		[AccessedThroughProperty("chEndurance")]
		private ColumnHeader _chEndurance;

		// Token: 0x04000227 RID: 551
		[AccessedThroughProperty("chDamageBuff")]
		private ColumnHeader _chDamageBuff;

		// Token: 0x04000228 RID: 552
		[AccessedThroughProperty("chResistanceDebuff")]
		private ColumnHeader _chResistanceDebuff;

		// Token: 0x04000229 RID: 553
		[AccessedThroughProperty("chBuildID")]
		private ColumnHeader _chBuildID;

		// Token: 0x0400022A RID: 554
		[AccessedThroughProperty("ibClear")]
		private ImageButton _ibClear;

		// Token: 0x0400022B RID: 555
		[AccessedThroughProperty("ibClose")]
		private ImageButton _ibClose;

		// Token: 0x0400022C RID: 556
		[AccessedThroughProperty("ibAutoMode")]
		private ImageButton _ibAutoMode;

		// Token: 0x0400022D RID: 557
		[AccessedThroughProperty("ibTopmost")]
		private ImageButton _ibTopmost;

		// Token: 0x0400022E RID: 558
		[AccessedThroughProperty("ilAttackChain")]
		private ImageList _ilAttackChain;

		// Token: 0x0400022F RID: 559
		[AccessedThroughProperty("lblHeader")]
		private Label _lblHeader;

		// Token: 0x04000230 RID: 560
		[AccessedThroughProperty("lblDPS")]
		private Label _lblDPS;

		// Token: 0x04000231 RID: 561
		[AccessedThroughProperty("lblEPS")]
		private Label _lblEPS;

		// Token: 0x04000232 RID: 562
		[AccessedThroughProperty("lblDPSNum")]
		private Label _lblDPSNum;

		// Token: 0x04000233 RID: 563
		[AccessedThroughProperty("lblEPSNum")]
		private Label _lblEPSNum;

		// Token: 0x04000234 RID: 564
		[AccessedThroughProperty("tbDPSOutput")]
		private TextBox _tbDPSOutput;

		// Token: 0x04000235 RID: 565
		[AccessedThroughProperty("lvPower")]
		private ListView _lvPower;

		// Token: 0x04000236 RID: 566
		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		// Token: 0x04000237 RID: 567
		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		// Token: 0x04000238 RID: 568
		[AccessedThroughProperty("ToolTip1")]
		private ToolTip _ToolTip1;

		// Token: 0x04000239 RID: 569
		protected ExtendedBitmap bxRecipe;

		// Token: 0x0400023B RID: 571
		protected bool Loading;

		// Token: 0x0400023C RID: 572
		protected frmMain myParent;

		// Token: 0x0400023E RID: 574
		private float GlobalDamageBuff;

		// Token: 0x0200002A RID: 42
		private struct CountingList
		{
			// Token: 0x04000240 RID: 576
			public string Text;

			// Token: 0x04000241 RID: 577
			public int Count;
		}

		// Token: 0x0200002B RID: 43
		public struct PowerList
		{
			// Token: 0x04000242 RID: 578
			public string PowerName;

			// Token: 0x04000243 RID: 579
			public float baseDamage;

			// Token: 0x04000244 RID: 580
			public float Damage;

			// Token: 0x04000245 RID: 581
			public float DPA;

			// Token: 0x04000246 RID: 582
			public float HidenDPA;

			// Token: 0x04000247 RID: 583
			public float Recharge;

			// Token: 0x04000248 RID: 584
			public float Animation;

			// Token: 0x04000249 RID: 585
			public float Endurance;

			// Token: 0x0400024A RID: 586
			public float DamageBuff;

			// Token: 0x0400024B RID: 587
			public float ResistanceDeBuff;

			// Token: 0x0400024C RID: 588
			public float RechargeTimer;
		}
	}
}
