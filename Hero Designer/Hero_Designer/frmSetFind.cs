using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x02000056 RID: 86
	[DesignerGenerated]
	public partial class frmSetFind : Form
	{
		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x0600124D RID: 4685 RVA: 0x000B6E44 File Offset: 0x000B5044
		// (set) Token: 0x0600124E RID: 4686 RVA: 0x000B6E5C File Offset: 0x000B505C
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

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x0600124F RID: 4687 RVA: 0x000B6E68 File Offset: 0x000B5068
		// (set) Token: 0x06001250 RID: 4688 RVA: 0x000B6E80 File Offset: 0x000B5080
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

		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001251 RID: 4689 RVA: 0x000B6E8C File Offset: 0x000B508C
		// (set) Token: 0x06001252 RID: 4690 RVA: 0x000B6EA4 File Offset: 0x000B50A4
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

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06001253 RID: 4691 RVA: 0x000B6EB0 File Offset: 0x000B50B0
		// (set) Token: 0x06001254 RID: 4692 RVA: 0x000B6EC8 File Offset: 0x000B50C8
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

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06001255 RID: 4693 RVA: 0x000B6ED4 File Offset: 0x000B50D4
		// (set) Token: 0x06001256 RID: 4694 RVA: 0x000B6EEC File Offset: 0x000B50EC
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

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001257 RID: 4695 RVA: 0x000B6EF8 File Offset: 0x000B50F8
		// (set) Token: 0x06001258 RID: 4696 RVA: 0x000B6F10 File Offset: 0x000B5110
		internal virtual ColumnHeader ColumnHeader6
		{
			get
			{
				return this._ColumnHeader6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ColumnHeader6 = value;
			}
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06001259 RID: 4697 RVA: 0x000B6F1C File Offset: 0x000B511C
		// (set) Token: 0x0600125A RID: 4698 RVA: 0x000B6F34 File Offset: 0x000B5134
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

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x0600125B RID: 4699 RVA: 0x000B6F90 File Offset: 0x000B5190
		// (set) Token: 0x0600125C RID: 4700 RVA: 0x000B6FA8 File Offset: 0x000B51A8
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

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x0600125D RID: 4701 RVA: 0x000B7004 File Offset: 0x000B5204
		// (set) Token: 0x0600125E RID: 4702 RVA: 0x000B701C File Offset: 0x000B521C
		internal virtual ImageList ilSets
		{
			get
			{
				return this._ilSets;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ilSets = value;
			}
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x0600125F RID: 4703 RVA: 0x000B7028 File Offset: 0x000B5228
		// (set) Token: 0x06001260 RID: 4704 RVA: 0x000B7040 File Offset: 0x000B5240
		internal virtual ListView lvBonus
		{
			get
			{
				return this._lvBonus;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvBonus_SelectedIndexChanged);
				if (this._lvBonus != null)
				{
					this._lvBonus.SelectedIndexChanged -= eventHandler;
				}
				this._lvBonus = value;
				if (this._lvBonus != null)
				{
					this._lvBonus.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001261 RID: 4705 RVA: 0x000B709C File Offset: 0x000B529C
		// (set) Token: 0x06001262 RID: 4706 RVA: 0x000B70B4 File Offset: 0x000B52B4
		internal virtual ListView lvMag
		{
			get
			{
				return this._lvMag;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvMag_SelectedIndexChanged);
				if (this._lvMag != null)
				{
					this._lvMag.SelectedIndexChanged -= eventHandler;
				}
				this._lvMag = value;
				if (this._lvMag != null)
				{
					this._lvMag.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06001263 RID: 4707 RVA: 0x000B7110 File Offset: 0x000B5310
		// (set) Token: 0x06001264 RID: 4708 RVA: 0x000B7128 File Offset: 0x000B5328
		internal virtual ListView lvSet
		{
			get
			{
				return this._lvSet;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.lvSet_SelectedIndexChanged);
				if (this._lvSet != null)
				{
					this._lvSet.SelectedIndexChanged -= eventHandler;
				}
				this._lvSet = value;
				if (this._lvSet != null)
				{
					this._lvSet.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06001265 RID: 4709 RVA: 0x000B7184 File Offset: 0x000B5384
		// (set) Token: 0x06001266 RID: 4710 RVA: 0x000B719C File Offset: 0x000B539C
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

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06001267 RID: 4711 RVA: 0x000B71A8 File Offset: 0x000B53A8
		// (set) Token: 0x06001268 RID: 4712 RVA: 0x000B71C0 File Offset: 0x000B53C0
		internal virtual ctlPopUp SetInfo
		{
			get
			{
				return this._SetInfo;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SetInfo = value;
			}
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x000B71CC File Offset: 0x000B53CC
		public frmSetFind(frmMain iParent)
		{
			base.FormClosed += this.frmSetFind_FormClosed;
			base.Load += this.frmSetFind_Load;
			this.SetBonusList = new int[0];
			this.InitializeComponent();
			this.myParent = iParent;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x000B7224 File Offset: 0x000B5424
		private void AddEffect(ref string[] List, ref int[] nIDList, string Effect, int nID)
		{
			int num = List.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if (string.Equals(List[index], Effect, StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
			}
			List = (string[])Utils.CopyArray(List, new string[List.Length + 1]);
			nIDList = (int[])Utils.CopyArray(nIDList, new int[List.Length + 1]);
			List[List.Length - 1] = Effect;
			nIDList[List.Length - 1] = nID;
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x000B72AC File Offset: 0x000B54AC
		private void AddSetString(int nIDSet, int BonusID)
		{
			string[] array = new string[4];
			array[0] = DatabaseAPI.Database.EnhancementSets[nIDSet].DisplayName;
			array[1] = Conversions.ToString(DatabaseAPI.Database.EnhancementSets[nIDSet].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[nIDSet].LevelMax + 1);
			array[2] = DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[nIDSet].SetType];
			if (BonusID < 0)
			{
				array[3] = "Special";
			}
			else
			{
				array[3] = Conversions.ToString(DatabaseAPI.Database.EnhancementSets.GetSetBonusEnhCount(nIDSet, BonusID));
			}
			this.lvSet.Items.Add(new ListViewItem(array, nIDSet));
			this.lvSet.Items[this.lvSet.Items.Count - 1].Tag = nIDSet;
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x000B740C File Offset: 0x000B560C
		public void FillEffectList()
		{
			string[] List = new string[0];
			int[] nIDList = new int[0];
			this.lvBonus.BeginUpdate();
			this.lvBonus.Items.Clear();
			int num = this.SetBonusList.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				if ((DatabaseAPI.Database.Power[this.SetBonusList[index]].EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
				{
					this.AddEffect(ref List, ref nIDList, this.GetPowerString(this.SetBonusList[index]), -1);
				}
			}
			int num2 = List.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				ListViewItem value = new ListViewItem(List[index]);
				this.lvBonus.Items.Add(value);
			}
			this.lvBonus.Sorting = SortOrder.Ascending;
			this.lvBonus.Sort();
			if (this.lvBonus.Items.Count > 0)
			{
				this.lvBonus.Items[0].Selected = true;
			}
			this.lvBonus.EndUpdate();
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x000B7540 File Offset: 0x000B5740
		public void FillImageList()
		{
			ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height);
			this.ilSets.Images.Clear();
			int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
			for (int index = 0; index <= num; index++)
			{
				EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[index];
				if (enhancementSet.ImageIdx > -1)
				{
					extendedBitmap.Graphics.Clear(Color.White);
					Graphics graphics = extendedBitmap.Graphics;
					I9Gfx.DrawEnhancementSet(ref graphics, DatabaseAPI.Database.EnhancementSets[index].ImageIdx);
					this.ilSets.Images.Add(extendedBitmap.Bitmap);
				}
				else
				{
					this.ilSets.Images.Add(new Bitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height));
				}
			}
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x000B7670 File Offset: 0x000B5870
		public void FillMagList()
		{
			if (this.lvBonus.SelectedItems.Count < 1)
			{
				this.lvMag.Items.Clear();
			}
			else
			{
				string[] List = new string[0];
				int[] nIDList = new int[0];
				string text = this.lvBonus.SelectedItems[0].Text;
				int num = this.SetBonusList.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects.Length > 0)
					{
						string powerString = this.GetPowerString(this.SetBonusList[index]);
						if (text == powerString)
						{
							string Effect;
							if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].EffectType == Enums.eEffectType.HitPoints)
							{
								Effect = Strings.Format(DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].Mag / (float)MidsContext.Archetype.Hitpoints * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00");
							}
							else if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].EffectType == Enums.eEffectType.Endurance)
							{
								Effect = Strings.Format(DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].Mag, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00");
							}
							else
							{
								Effect = Strings.Format(DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].MagPercent, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00");
							}
							Effect += "%";
							this.AddEffect(ref List, ref nIDList, Effect, this.SetBonusList[index]);
						}
					}
				}
				this.lvMag.BeginUpdate();
				this.lvMag.Items.Clear();
				this.lvMag.Items.Add("All");
				int num2 = List.Length - 1;
				for (int index = 0; index <= num2; index++)
				{
					ListViewItem value = new ListViewItem(List[index])
					{
						Tag = nIDList[index]
					};
					this.lvMag.Items.Add(value);
				}
				if (this.lvMag.Items.Count > 0)
				{
					this.lvMag.Items[0].Selected = true;
				}
				this.lvMag.EndUpdate();
			}
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x000B7990 File Offset: 0x000B5B90
		private void FillSetList()
		{
			if (this.lvBonus.SelectedItems.Count < 1 | this.lvMag.SelectedItems.Count < 1)
			{
				this.lvSet.Items.Clear();
			}
			else
			{
				this.lvSet.BeginUpdate();
				this.lvSet.Items.Clear();
				string[] List = new string[0];
				int[] nIDList = new int[0];
				string text = this.lvBonus.SelectedItems[0].Text;
				bool flag = false;
				if (this.lvMag.Items[0].Selected)
				{
					flag = true;
				}
				if (!flag)
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvMag.SelectedItems[0].Tag)) > -1.0)
					{
						this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[Conversions.ToInteger(this.lvMag.SelectedItems[0].Tag)].PowerName, Conversions.ToInteger(this.lvMag.SelectedItems[0].Tag));
					}
				}
				else
				{
					int num = this.SetBonusList.Length - 1;
					for (int nIDSet = 0; nIDSet <= num; nIDSet++)
					{
						if (DatabaseAPI.Database.Power[this.SetBonusList[nIDSet]].Effects.Length > 0)
						{
							string powerString = this.GetPowerString(this.SetBonusList[nIDSet]);
							if (text == powerString)
							{
								this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[this.SetBonusList[nIDSet]].PowerName, this.SetBonusList[nIDSet]);
							}
						}
					}
				}
				int num2 = DatabaseAPI.Database.EnhancementSets.Count - 1;
				for (int nIDSet = 0; nIDSet <= num2; nIDSet++)
				{
					int num3 = DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus.Length - 1;
					for (int BonusID = 0; BonusID <= num3; BonusID++)
					{
						int num4 = DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus[BonusID].Index.Length - 1;
						for (int index = 0; index <= num4; index++)
						{
							int num5 = nIDList.Length - 1;
							for (int index2 = 0; index2 <= num5; index2++)
							{
								if (DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus[BonusID].Index[index] == nIDList[index2])
								{
									this.AddSetString(nIDSet, BonusID);
								}
							}
						}
					}
					int num6 = DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus.Length - 1;
					for (int BonusID = 0; BonusID <= num6; BonusID++)
					{
						int num7 = DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus[BonusID].Index.Length - 1;
						for (int index = 0; index <= num7; index++)
						{
							int num8 = nIDList.Length - 1;
							for (int index2 = 0; index2 <= num8; index2++)
							{
								if (DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus[BonusID].Index[index] == nIDList[index2])
								{
									this.AddSetString(nIDSet, BonusID);
								}
							}
						}
					}
				}
				if (this.lvSet.Items.Count > 0)
				{
					this.lvSet.Items[0].Selected = true;
				}
				this.lvSet.EndUpdate();
			}
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x000B7DD4 File Offset: 0x000B5FD4
		private void frmSetFind_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.myParent.FloatSetFinder(false);
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x000B7DE4 File Offset: 0x000B5FE4
		private void frmSetFind_Load(object sender, EventArgs e)
		{
			this.SetBonusList = DatabaseAPI.NidPowers("Set_Bonus.Set_Bonus", "");
			this.BackColor = this.myParent.BackColor;
			this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
			this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
			this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.SetInfo.SetPopup(default(PopUp.PopupData));
			this.FillImageList();
			this.FillEffectList();
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x000B7F00 File Offset: 0x000B6100
		private string GetPowerString(int nIDPower)
		{
			string str = "";
			string returnString = "";
			int[] returnMask = new int[0];
			DatabaseAPI.Database.Power[nIDPower].GetEffectStringGrouped(0, ref returnString, ref returnMask, true, true, true);
			string str2;
			if (returnString != "")
			{
				str2 = returnString;
			}
			else
			{
				int num = DatabaseAPI.Database.Power[nIDPower].Effects.Length - 1;
				for (int index = 0; index <= num; index++)
				{
					bool flag = false;
					int num2 = returnMask.Length - 1;
					for (int index2 = 0; index2 <= num2; index2++)
					{
						if (index == returnMask[index2])
						{
							flag = true;
						}
					}
					if (!flag)
					{
						if (str != "")
						{
							str += ", ";
						}
						string str3 = Strings.Trim(DatabaseAPI.Database.Power[nIDPower].Effects[index].BuildEffectString(true, "", true, false, false));
						if (str3.Contains("Res("))
						{
							str3 = str3.Replace("Res(", "Resistance(");
						}
						if (str3.Contains("Def("))
						{
							str3 = str3.Replace("Def(", "Defense(");
						}
						if (str3.Contains("EndRec"))
						{
							str3 = str3.Replace("EndRec", "Recovery");
						}
						if (str3.Contains("Endurance"))
						{
							str3 = str3.Replace("Endurance", "Max End");
						}
						else if (str3.Contains("End") & !str3.Contains("Max End"))
						{
							str3 = str3.Replace("End", "Max End");
						}
						str += str3;
					}
				}
				str2 = str;
			}
			return str2;
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x000B811D File Offset: 0x000B631D
		private void ibClose_ButtonClicked()
		{
			base.Close();
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x000B8128 File Offset: 0x000B6328
		private void ibTopmost_ButtonClicked()
		{
			base.TopMost = this.ibTopmost.Checked;
			if (base.TopMost)
			{
				base.BringToFront();
			}
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x000B8961 File Offset: 0x000B6B61
		private void lvBonus_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.FillMagList();
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x000B896B File Offset: 0x000B6B6B
		private void lvMag_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.FillSetList();
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x000B8978 File Offset: 0x000B6B78
		private void lvSet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvSet.SelectedItems.Count > 0)
			{
				this.SetInfo.SetPopup(Character.PopSetInfo(Conversions.ToInteger(this.lvSet.SelectedItems[0].Tag), null));
			}
		}

		// Token: 0x0400075E RID: 1886
		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader _ColumnHeader1;

		// Token: 0x0400075F RID: 1887
		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader _ColumnHeader2;

		// Token: 0x04000760 RID: 1888
		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader _ColumnHeader3;

		// Token: 0x04000761 RID: 1889
		[AccessedThroughProperty("ColumnHeader4")]
		private ColumnHeader _ColumnHeader4;

		// Token: 0x04000762 RID: 1890
		[AccessedThroughProperty("ColumnHeader5")]
		private ColumnHeader _ColumnHeader5;

		// Token: 0x04000763 RID: 1891
		[AccessedThroughProperty("ColumnHeader6")]
		private ColumnHeader _ColumnHeader6;

		// Token: 0x04000764 RID: 1892
		[AccessedThroughProperty("ibClose")]
		private ImageButton _ibClose;

		// Token: 0x04000765 RID: 1893
		[AccessedThroughProperty("ibTopmost")]
		private ImageButton _ibTopmost;

		// Token: 0x04000766 RID: 1894
		[AccessedThroughProperty("ilSets")]
		private ImageList _ilSets;

		// Token: 0x04000767 RID: 1895
		[AccessedThroughProperty("lvBonus")]
		private ListView _lvBonus;

		// Token: 0x04000768 RID: 1896
		[AccessedThroughProperty("lvMag")]
		private ListView _lvMag;

		// Token: 0x04000769 RID: 1897
		[AccessedThroughProperty("lvSet")]
		private ListView _lvSet;

		// Token: 0x0400076A RID: 1898
		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		// Token: 0x0400076B RID: 1899
		[AccessedThroughProperty("SetInfo")]
		private ctlPopUp _SetInfo;

		// Token: 0x0400076D RID: 1901
		protected frmMain myParent;

		// Token: 0x0400076E RID: 1902
		protected int[] SetBonusList;
	}
}
