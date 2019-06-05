using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x02000059 RID: 89
	public partial class frmStats : Form
	{
		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x060012DB RID: 4827 RVA: 0x000BC728 File Offset: 0x000BA928
		// (set) Token: 0x060012DC RID: 4828 RVA: 0x000BC740 File Offset: 0x000BA940
		internal virtual ImageButton btnClose
		{
			get
			{
				return this._btnClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_Click);
				if (this._btnClose != null)
				{
					this._btnClose.ButtonClicked -= clickedEventHandler;
				}
				this._btnClose = value;
				if (this._btnClose != null)
				{
					this._btnClose.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x060012DD RID: 4829 RVA: 0x000BC79C File Offset: 0x000BA99C
		// (set) Token: 0x060012DE RID: 4830 RVA: 0x000BC7B4 File Offset: 0x000BA9B4
		internal virtual ComboBox cbSet
		{
			get
			{
				return this._cbSet;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cbSet_SelectedIndexChanged);
				if (this._cbSet != null)
				{
					this._cbSet.SelectedIndexChanged -= eventHandler;
				}
				this._cbSet = value;
				if (this._cbSet != null)
				{
					this._cbSet.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x060012DF RID: 4831 RVA: 0x000BC810 File Offset: 0x000BAA10
		// (set) Token: 0x060012E0 RID: 4832 RVA: 0x000BC828 File Offset: 0x000BAA28
		internal virtual ComboBox cbStyle
		{
			get
			{
				return this._cbStyle;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cbStyle_SelectedIndexChanged);
				if (this._cbStyle != null)
				{
					this._cbStyle.SelectedIndexChanged -= eventHandler;
				}
				this._cbStyle = value;
				if (this._cbStyle != null)
				{
					this._cbStyle.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x000BC884 File Offset: 0x000BAA84
		// (set) Token: 0x060012E2 RID: 4834 RVA: 0x000BC89C File Offset: 0x000BAA9C
		internal virtual ComboBox cbValues
		{
			get
			{
				return this._cbValues;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.cbValues_SelectedIndexChanged);
				if (this._cbValues != null)
				{
					this._cbValues.SelectedIndexChanged -= eventHandler;
				}
				this._cbValues = value;
				if (this._cbValues != null)
				{
					this._cbValues.SelectedIndexChanged += eventHandler;
				}
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x000BC8F8 File Offset: 0x000BAAF8
		// (set) Token: 0x060012E4 RID: 4836 RVA: 0x000BC910 File Offset: 0x000BAB10
		internal virtual ImageButton chkOnTop
		{
			get
			{
				return this._chkOnTop;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.chkOnTop_CheckedChanged);
				if (this._chkOnTop != null)
				{
					this._chkOnTop.ButtonClicked -= clickedEventHandler;
				}
				this._chkOnTop = value;
				if (this._chkOnTop != null)
				{
					this._chkOnTop.ButtonClicked += clickedEventHandler;
				}
			}
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x000BC96C File Offset: 0x000BAB6C
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x000BC984 File Offset: 0x000BAB84
		internal virtual ctlMultiGraph Graph
		{
			get
			{
				return this._Graph;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Graph = value;
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x000BC990 File Offset: 0x000BAB90
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x000BC9A8 File Offset: 0x000BABA8
		internal virtual Label lblKey1
		{
			get
			{
				return this._lblKey1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblKey1 = value;
			}
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x000BC9B4 File Offset: 0x000BABB4
		// (set) Token: 0x060012EA RID: 4842 RVA: 0x000BC9CC File Offset: 0x000BABCC
		internal virtual Label lblKey2
		{
			get
			{
				return this._lblKey2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblKey2 = value;
			}
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x000BC9D8 File Offset: 0x000BABD8
		// (set) Token: 0x060012EC RID: 4844 RVA: 0x000BC9F0 File Offset: 0x000BABF0
		internal virtual Label lblKeyColor1
		{
			get
			{
				return this._lblKeyColor1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblKeyColor1 = value;
			}
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x000BC9FC File Offset: 0x000BABFC
		// (set) Token: 0x060012EE RID: 4846 RVA: 0x000BCA14 File Offset: 0x000BAC14
		internal virtual Label lblKeyColor2
		{
			get
			{
				return this._lblKeyColor2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblKeyColor2 = value;
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x000BCA20 File Offset: 0x000BAC20
		// (set) Token: 0x060012F0 RID: 4848 RVA: 0x000BCA38 File Offset: 0x000BAC38
		internal virtual Label lblScale
		{
			get
			{
				return this._lblScale;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblScale = value;
			}
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x000BCA44 File Offset: 0x000BAC44
		// (set) Token: 0x060012F2 RID: 4850 RVA: 0x000BCA5C File Offset: 0x000BAC5C
		internal virtual TrackBar tbScaleX
		{
			get
			{
				return this._tbScaleX;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.tbScaleX_Scroll);
				if (this._tbScaleX != null)
				{
					this._tbScaleX.Scroll -= eventHandler;
				}
				this._tbScaleX = value;
				if (this._tbScaleX != null)
				{
					this._tbScaleX.Scroll += eventHandler;
				}
			}
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x060012F3 RID: 4851 RVA: 0x000BCAB8 File Offset: 0x000BACB8
		// (set) Token: 0x060012F4 RID: 4852 RVA: 0x000BCAD0 File Offset: 0x000BACD0
		internal virtual ToolTip tTip
		{
			get
			{
				return this._tTip;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._tTip = value;
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000BCADC File Offset: 0x000BACDC
		public frmStats(ref frmMain iParent)
		{
			base.FormClosed += this.frmStats_FormClosed;
			base.Load += this.frmStats_Load;
			base.Move += this.frmStats_Move;
			base.Resize += this.frmStats_Resize;
			base.VisibleChanged += this.frmStats_VisibleChanged;
			this.BaseArray = new IPower[0];
			this.EnhArray = new IPower[0];
			this.GraphMax = 1f;
			this.BaseOverride = false;
			this.Loaded = false;
			this.InitializeComponent();
			this.myParent = iParent;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x000BCB91 File Offset: 0x000BAD91
		private void btnClose_Click()
		{
			base.Close();
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000BCB9C File Offset: 0x000BAD9C
		private void cbSet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.GetPowerArray();
				this.DisplayGraph();
			}
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000BCBC8 File Offset: 0x000BADC8
		private void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.SetGraphType();
				this.DisplayGraph();
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000BCBF4 File Offset: 0x000BADF4
		private void cbValues_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Loaded)
			{
				this.DisplayGraph();
			}
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x000BCC18 File Offset: 0x000BAE18
		private void chkOnTop_CheckedChanged()
		{
			base.TopMost = this.chkOnTop.Checked;
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x000BCC30 File Offset: 0x000BAE30
		public void DisplayGraph()
		{
			if (!(MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized))
			{
				this.Graph.BeginUpdate();
				this.Graph.Clear();
				if (this.cbValues.SelectedIndex > -1)
				{
					switch (this.cbValues.SelectedIndex)
					{
					case 0:
						this.Graph.ColorFadeEnd = Color.FromArgb(255, 255, 0);
						this.Graph_Acc();
						break;
					case 1:
						this.Graph.ColorFadeEnd = Color.Red;
						this.Graph_Damage();
						break;
					case 2:
						this.Graph.ColorFadeEnd = Color.Red;
						this.Graph_DPA();
						break;
					case 3:
						this.Graph.ColorFadeEnd = Color.Red;
						this.Graph_DPS();
						break;
					case 4:
						this.Graph.ColorFadeEnd = Color.Red;
						this.Graph_DPE();
						break;
					case 5:
						this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 255);
						this.Graph_End();
						break;
					case 6:
						this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 255);
						this.Graph_EPS();
						break;
					case 7:
						this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
						this.Graph_Heal();
						break;
					case 8:
						this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
						this.Graph_HealPS();
						break;
					case 9:
						this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
						this.Graph_HealPE();
						break;
					case 10:
						this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, 255);
						this.Graph_Duration();
						break;
					case 11:
						this.Graph.ColorFadeEnd = Color.FromArgb(64, 128, 96);
						this.Graph_Range();
						break;
					case 12:
						this.Graph.ColorFadeEnd = Color.FromArgb(255, 192, 128);
						this.Graph_Recharge();
						break;
					case 13:
						this.Graph.ColorFadeEnd = Color.FromArgb(96, 192, 96);
						this.Graph_Regen();
						break;
					}
				}
				this.Graph.Max = this.GraphMax;
				this.tbScaleX.Value = this.Graph.ScaleIndex;
				this.SetScaleLabel();
				this.SetGraphMetrics();
				this.Graph.EndUpdate();
			}
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x000BCF50 File Offset: 0x000BB150
		private void FillComboBoxes()
		{
			this.NewSets();
			this.cbValues.BeginUpdate();
			ComboBox.ObjectCollection items = this.cbValues.Items;
			items.Clear();
			items.Add("Accuracy");
			items.Add("Damage");
			items.Add("Damage / Anim");
			items.Add("Damage / Sec");
			items.Add("Damage / End");
			items.Add("End Use");
			items.Add("End / Sec");
			items.Add("Healing");
			items.Add("Heal / Sec");
			items.Add("Heal / End");
			items.Add("Effect Duration");
			items.Add("Range");
			items.Add("Recharge Time");
			items.Add("Regeneration");
			this.cbValues.SelectedIndex = 1;
			this.cbValues.EndUpdate();
			this.cbStyle.BeginUpdate();
			ComboBox.ObjectCollection items2 = this.cbStyle.Items;
			items2.Clear();
			items2.Add("Base & Enhanced");
			items2.Add("Stacked Base + Enhanced");
			items2.Add("Base Only");
			items2.Add("Enhanced Only");
			items2.Add("Active & Alternate");
			items2.Add("Stacked Active + Alt");
			if (MidsContext.Config.StatGraphStyle > (Enums.GraphStyle)(this.cbStyle.Items.Count - 1))
			{
				MidsContext.Config.StatGraphStyle = Enums.GraphStyle.Stacked;
			}
			this.cbStyle.SelectedIndex = (int)MidsContext.Config.StatGraphStyle;
			this.cbStyle.EndUpdate();
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x000BD100 File Offset: 0x000BB300
		private void frmStats_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.myParent.FloatStatGraph(false);
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x000BD110 File Offset: 0x000BB310
		private void frmStats_Load(object sender, EventArgs e)
		{
			this.FillComboBoxes();
			this.Loaded = true;
			this.tbScaleX.Minimum = 0;
			this.tbScaleX.Maximum = this.Graph.ScaleCount - 1;
			this.UpdateData(false);
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x000BD14F File Offset: 0x000BB34F
		private void frmStats_Move(object sender, EventArgs e)
		{
			this.StoreLocation();
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x000BD15C File Offset: 0x000BB35C
		private void frmStats_Resize(object sender, EventArgs e)
		{
			if (this.Graph != null)
			{
				this.Graph.Width = base.ClientSize.Width - (this.Graph.Left + 4);
				this.Graph.Height = base.ClientSize.Height - (this.Graph.Top + (base.ClientSize.Height - this.tbScaleX.Top) + 4);
				this.tbScaleX.Width = base.ClientSize.Width - (this.tbScaleX.Left + (base.ClientSize.Width - this.chkOnTop.Left) + 4);
				this.lblScale.Left = (int)Math.Round((double)this.tbScaleX.Left + (double)(this.tbScaleX.Width - this.lblScale.Width) / 2.0);
				if (this.cbStyle.Left + 154 > base.ClientSize.Width - 3)
				{
					this.cbStyle.Width = base.ClientSize.Width - this.cbStyle.Left - 4;
				}
				else
				{
					this.cbStyle.Width = 154;
				}
			}
			this.StoreLocation();
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x000BD2DB File Offset: 0x000BB4DB
		private void frmStats_VisibleChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x000BD2E0 File Offset: 0x000BB4E0
		public void GetPowerArray()
		{
			if (!(MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized))
			{
				this.BaseArray = new IPower[0];
				this.EnhArray = new IPower[0];
				MainModule.MidsController.Toon.GenerateBuffedPowerArray();
				if (this.cbSet.SelectedIndex > -1)
				{
					switch (this.cbSet.SelectedIndex)
					{
					case 0:
						this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Auto_);
						break;
					case 1:
						this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Auto_);
						break;
					case 2:
						this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Auto_);
						break;
					case 3:
						this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Auto_);
						break;
					case 4:
						this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Auto_);
						break;
					case 5:
						this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Auto_);
						this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Auto_);
						break;
					case 6:
						if (!this.BaseOverride)
						{
							int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
							for (int iPower = 0; iPower <= num; iPower++)
							{
								if ((MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1) && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
								{
									this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
									this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
									int index = this.BaseArray.Length - 1;
									this.BaseArray[index] = new Power(DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MainModule.MidsController.Toon.CurrentBuild.Powers[iPower].IDXPower]);
									this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
								}
							}
						}
						else
						{
							int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
							for (int iPower = 0; iPower <= num2; iPower++)
							{
								if ((MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1) && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
								{
									this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
									int num4 = this.BaseArray.Length - 1;
									this.BaseArray[num4] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
								}
							}
							MainModule.MidsController.Toon.FlipAllSlots();
							int num3 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
							for (int iPower = 0; iPower <= num3; iPower++)
							{
								if ((MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset > -1 & MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower > -1) && DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[iPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[iPower].IDXPower].Slottable)
								{
									this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
									int num5 = this.EnhArray.Length - 1;
									this.EnhArray[num5] = MainModule.MidsController.Toon.GetEnhancedPower(iPower);
								}
							}
							MainModule.MidsController.Toon.FlipAllSlots();
						}
						break;
					case 7:
						this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Toggle);
						this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Toggle);
						this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Toggle);
						this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Toggle);
						this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Toggle);
						this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Toggle);
						this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Toggle);
						break;
					case 8:
						this.GetSetArray(Enums.PowersetType.Primary, Enums.ePowerType.Click);
						this.GetSetArray(Enums.PowersetType.Secondary, Enums.ePowerType.Click);
						this.GetSetArray(Enums.PowersetType.Ancillary, Enums.ePowerType.Click);
						this.GetSetArray(Enums.PowersetType.Pool0, Enums.ePowerType.Click);
						this.GetSetArray(Enums.PowersetType.Pool1, Enums.ePowerType.Click);
						this.GetSetArray(Enums.PowersetType.Pool2, Enums.ePowerType.Click);
						this.GetSetArray(Enums.PowersetType.Pool3, Enums.ePowerType.Click);
						break;
					}
				}
			}
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x000BD890 File Offset: 0x000BBA90
		public void GetSetArray(Enums.PowersetType SetType, Enums.ePowerType iType)
		{
			if (MidsContext.Character.Powersets[(int)SetType] != null)
			{
				if (this.cbStyle.SelectedIndex >= this.cbStyle.Items.Count - 2)
				{
					int num = MidsContext.Character.Powersets[(int)SetType].Powers.Length - 1;
					for (int iPower = 0; iPower <= num; iPower++)
					{
						if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int)SetType].Powers[iPower].PowerType == iType)
						{
							this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
							int index = this.BaseArray.Length - 1;
							this.BaseArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int)SetType].nID, iPower));
							if (this.BaseArray[index] == null)
							{
								this.BaseArray[index] = new Power(MidsContext.Character.Powersets[(int)SetType].Powers[iPower]);
								IPower[] array = this.BaseArray;
								int num4 = index;
								array[num4].Accuracy *= MidsContext.Config.BaseAcc;
							}
						}
					}
					MainModule.MidsController.Toon.FlipAllSlots();
					int num2 = MidsContext.Character.Powersets[(int)SetType].Powers.Length - 1;
					for (int iPower = 0; iPower <= num2; iPower++)
					{
						if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int)SetType].Powers[iPower].PowerType == iType)
						{
							this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
							int index = this.EnhArray.Length - 1;
							this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int)SetType].nID, iPower));
							if (this.EnhArray[index] == null)
							{
								this.EnhArray[index] = new Power(MidsContext.Character.Powersets[(int)SetType].Powers[iPower]);
								IPower[] array = this.EnhArray;
								int num4 = index;
								array[num4].Accuracy *= MidsContext.Config.BaseAcc;
							}
						}
					}
					MainModule.MidsController.Toon.FlipAllSlots();
				}
				else
				{
					int num3 = MidsContext.Character.Powersets[(int)SetType].Powers.Length - 1;
					for (int iPower = 0; iPower <= num3; iPower++)
					{
						if (iType == Enums.ePowerType.Auto_ | MidsContext.Character.Powersets[(int)SetType].Powers[iPower].PowerType == iType)
						{
							this.BaseArray = (IPower[])Utils.CopyArray(this.BaseArray, new IPower[this.BaseArray.Length + 1]);
							this.EnhArray = (IPower[])Utils.CopyArray(this.EnhArray, new IPower[this.EnhArray.Length + 1]);
							int index = this.BaseArray.Length - 1;
							this.BaseArray[index] = new Power(MidsContext.Character.Powersets[(int)SetType].Powers[iPower]);
							this.EnhArray[index] = MainModule.MidsController.Toon.GetEnhancedPower(this.GrabPlaced(MidsContext.Character.Powersets[(int)SetType].nID, iPower));
							if (this.EnhArray[index] == null)
							{
								this.EnhArray[index] = new Power(this.BaseArray[index]);
							}
						}
					}
				}
			}
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x000BDC5C File Offset: 0x000BBE5C
		public int GrabPlaced(int iSet, int iPower)
		{
			if (MainModule.MidsController.Toon.Locked)
			{
				int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
				for (int index = 0; index <= num; index++)
				{
					if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset == iSet & MidsContext.Character.CurrentBuild.Powers[index].IDXPower == iPower)
					{
						return index;
					}
				}
			}
			return -1;
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x000BDD00 File Offset: 0x000BBF00
		public void Graph_Acc()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				if (this.BaseArray[index].EntitiesAutoHit == Enums.eEntity.None | (this.BaseArray[index].Range > 20f & this.BaseArray[index].I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt)))
				{
					float nBase = this.BaseArray[index].Accuracy;
					if (nBase != 0f)
					{
						float nEnh = this.EnhArray[index].Accuracy;
						if (this.BaseOverride)
						{
							nEnh *= 100f;
							nBase *= 100f;
						}
						else
						{
							if (this.EnhArray[index].Accuracy == nBase)
							{
								nEnh = MidsContext.Config.BaseAcc * nEnh;
							}
							nEnh *= 100f;
							nBase = MidsContext.Config.BaseAcc * nBase * 100f;
						}
						string iTip = this.BaseArray[index].DisplayName;
						if (num < nEnh)
						{
							num = nEnh;
						}
						if (num < nBase)
						{
							num = nBase;
						}
						if (this.BaseOverride)
						{
							float num3 = nBase;
							nBase = nEnh;
							nEnh = num3;
						}
						if (this.Graph.Style == Enums.GraphStyle.baseOnly)
						{
							iTip = iTip + ": " + Strings.Format(nBase, "##0.#") + "%";
						}
						else
						{
							iTip = iTip + ": " + Strings.Format(nEnh, "##0.#") + "%";
						}
						if (nBase != nEnh)
						{
							iTip = iTip + " (" + Strings.Format(nBase, "##0.#") + "%)";
						}
						if (this.BaseOverride)
						{
							float num4 = nBase;
							nBase = nEnh;
							nEnh = num4;
						}
						this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
					}
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x000BDF50 File Offset: 0x000BC150
		public void Graph_Damage()
		{
			float num = 1f;
			ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].FXGetDamageValue();
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].FXGetDamageValue();
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
					}
					else
					{
						if (!this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
						}
						if (this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
						}
					}
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
					}
					if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
					{
						iTip = iTip + "\r\n(Applied every " + Conversions.ToString(this.BaseArray[index].ActivatePeriod) + "s)";
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
			MidsContext.Config.DamageMath.ReturnValue = returnValue;
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x000BE190 File Offset: 0x000BC390
		public void Graph_DPA()
		{
			float num = 1f;
			ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].FXGetDamageValue();
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].FXGetDamageValue();
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
					}
					else
					{
						if (!this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
						}
						if (this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
						}
					}
					iTip += "/s";
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
			MidsContext.Config.DamageMath.ReturnValue = returnValue;
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x000BE39C File Offset: 0x000BC59C
		public void Graph_DPE()
		{
			float num = 1f;
			ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].FXGetDamageValue();
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].FXGetDamageValue();
					if (this.EnhArray[index].EndCost > 0f)
					{
						nBase /= this.BaseArray[index].EndCost;
						nEnh /= this.EnhArray[index].EndCost;
					}
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
					}
					else
					{
						if (!this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
						}
						if (this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
						}
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + "\r\nDamage per unit of End: " + Strings.Format(nBase, "##0.##");
					}
					else
					{
						iTip = iTip + "\r\nDamage per unit of End: " + Strings.Format(nEnh, "##0.##");
						if (nBase != nEnh)
						{
							iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
						}
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
			MidsContext.Config.DamageMath.ReturnValue = returnValue;
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x000BE638 File Offset: 0x000BC838
		public void Graph_DPS()
		{
			float num = 1f;
			ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
			MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].FXGetDamageValue();
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].FXGetDamageValue();
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
					}
					else
					{
						if (!this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.EnhArray[index].FXGetDamageString();
						}
						if (this.BaseOverride)
						{
							iTip = iTip + "\r\n" + this.BaseArray[index].FXGetDamageString();
						}
					}
					iTip += "/s";
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
			MidsContext.Config.DamageMath.ReturnValue = returnValue;
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x000BE844 File Offset: 0x000BCA44
		public void Graph_Duration()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				int durationEffectId = this.BaseArray[index].GetDurationEffectID();
				if (durationEffectId > -1)
				{
					float nBase = this.BaseArray[index].Effects[durationEffectId].Duration;
					float nEnh = this.EnhArray[index].Effects[durationEffectId].Duration;
					if (nBase != 0f & this.BaseArray[index].PowerType == Enums.ePowerType.Click)
					{
						string str;
						if (this.EnhArray[index].Effects[durationEffectId].EffectType == Enums.eEffectType.Mez)
						{
							str = Enums.GetMezName((Enums.eMezShort)this.EnhArray[index].Effects[durationEffectId].MezType);
						}
						else
						{
							str = Enums.GetEffectName(this.EnhArray[index].Effects[durationEffectId].EffectType);
						}
						if (this.EnhArray[index].Effects[durationEffectId].Mag < 0f)
						{
							str = "-" + str;
						}
						string iTip = this.BaseArray[index].DisplayName;
						if (num < nEnh)
						{
							num = nEnh;
						}
						if (num < nBase)
						{
							num = nBase;
						}
						if (this.BaseOverride)
						{
							float num3 = nBase;
							nBase = nEnh;
							nEnh = num3;
						}
						if (this.Graph.Style == Enums.GraphStyle.baseOnly)
						{
							iTip = string.Concat(new string[]
							{
								iTip,
								" (",
								str,
								"): ",
								Strings.Format(nBase, "##0.#")
							});
						}
						else
						{
							iTip = string.Concat(new string[]
							{
								iTip,
								" (",
								str,
								"): ",
								Strings.Format(nEnh, "##0.#")
							});
						}
						if (nBase != nEnh)
						{
							iTip = iTip + " (" + Strings.Format(nBase, "##0.#") + ")";
						}
						iTip += "s";
						if (this.BaseOverride)
						{
							float num4 = nBase;
							nBase = nEnh;
							nEnh = num4;
						}
						this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
					}
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x000BEB10 File Offset: 0x000BCD10
		public void Graph_End()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].EndCost;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].EndCost;
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(nBase, "##0.##");
					}
					else
					{
						iTip = iTip + ": " + Strings.Format(nEnh, "##0.##");
					}
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
					}
					if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
					{
						iTip += "\r\n(Per Second)";
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x000BECCC File Offset: 0x000BCECC
		public void Graph_EPS()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].EndCost;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].EndCost;
					if (this.BaseArray[index].PowerType == Enums.ePowerType.Click)
					{
						if (this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime > 0f)
						{
							nBase = this.BaseArray[index].EndCost / (this.BaseArray[index].RechargeTime + this.BaseArray[index].CastTime + this.BaseArray[index].InterruptTime);
							nEnh = this.EnhArray[index].EndCost / (this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime);
						}
					}
					else if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
					{
						nBase = this.BaseArray[index].EndCost / this.BaseArray[index].ActivatePeriod;
						nEnh = this.EnhArray[index].EndCost / this.EnhArray[index].ActivatePeriod;
					}
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(nBase, "##0.##");
					}
					else
					{
						iTip = iTip + ": " + Strings.Format(nEnh, "##0.##");
					}
					iTip += "/s";
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x000BEF8C File Offset: 0x000BD18C
		public void Graph_Heal()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					float num4 = nBase / (float)MidsContext.Archetype.Hitpoints * 100f;
					float num5 = nEnh / (float)MidsContext.Archetype.Hitpoints * 100f;
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(num4, "##0.#") + "%";
					}
					else
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n  Enhanced: ",
							Strings.Format(num5, "##0.#"),
							"% (",
							Strings.Format(nEnh, "##0.#"),
							" HP)"
						});
					}
					if (nBase != nEnh)
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n  Base: ",
							Strings.Format(num4, "##0.#"),
							"% (",
							Strings.Format(nBase, "##0.#"),
							" HP)"
						});
					}
					if (this.BaseOverride)
					{
						float num6 = nBase;
						nBase = nEnh;
						nEnh = num6;
						iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x000BF1FC File Offset: 0x000BD3FC
		public void Graph_HealPE()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
					if (this.EnhArray[index].EndCost > 0f)
					{
						nBase /= this.BaseArray[index].EndCost;
						nEnh /= this.EnhArray[index].EndCost;
					}
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					float num4 = nBase / (float)MidsContext.Archetype.Hitpoints * 100f;
					float num5 = nEnh / (float)MidsContext.Archetype.Hitpoints * 100f;
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(nBase, "##0.##") + "%";
					}
					else
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n  Enhanced Heal per unit of End: ",
							Strings.Format(num5, "##0.##"),
							"% (",
							Strings.Format(nEnh, "##0.##"),
							" HP)"
						});
					}
					if (nBase != nEnh)
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n  Base Heal per unit of End: ",
							Strings.Format(num4, "##0.##"),
							"% (",
							Strings.Format(nBase, "##0.##"),
							" HP)"
						});
					}
					if (this.BaseOverride)
					{
						float num6 = nBase;
						nBase = nEnh;
						nEnh = num6;
						iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x000BF4AC File Offset: 0x000BD6AC
		public void Graph_HealPS()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false).Sum;
					if (this.BaseArray[index].PowerType == Enums.ePowerType.Click)
					{
						if (this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime > 0f)
						{
							nBase /= this.BaseArray[index].RechargeTime + this.BaseArray[index].CastTime + this.BaseArray[index].InterruptTime;
							nEnh /= this.EnhArray[index].RechargeTime + this.EnhArray[index].CastTime + this.EnhArray[index].InterruptTime;
						}
					}
					else if (this.BaseArray[index].PowerType == Enums.ePowerType.Toggle)
					{
						nBase /= this.BaseArray[index].ActivatePeriod;
						nEnh /= this.EnhArray[index].ActivatePeriod;
					}
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					float num4 = nBase / (float)MidsContext.Archetype.Hitpoints * 100f;
					float num5 = nEnh / (float)MidsContext.Archetype.Hitpoints * 100f;
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(num4, "##0.##") + "%";
					}
					else
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n  Enhanced: ",
							Strings.Format(num5, "##0.##"),
							"%/s (",
							Strings.Format(nEnh, "##0.##"),
							" HP)"
						});
					}
					if (nBase != nEnh)
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n  Base: ",
							Strings.Format(num4, "##0.##"),
							"%/s (",
							Strings.Format(nBase, "##0.##"),
							" HP)"
						});
					}
					if (this.BaseOverride)
					{
						float num6 = nBase;
						nBase = nEnh;
						nEnh = num6;
						iTip = iTip.Replace("Enhanced", "Acive").Replace("Base", "Alternate");
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x000BF80C File Offset: 0x000BDA0C
		public void Graph_Range()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = 0f;
				float nEnh = 0f;
				if (this.BaseArray[index].Range > 0f)
				{
					nBase = this.BaseArray[index].Range;
					nEnh = this.EnhArray[index].Range;
				}
				else if (this.BaseArray[index].Radius > 0f)
				{
					nBase = this.BaseArray[index].Radius;
					nEnh = this.EnhArray[index].Radius;
				}
				if (nBase != 0f)
				{
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(nBase, "##0.#");
					}
					else
					{
						iTip = iTip + ": " + Strings.Format(nEnh, "##0.#");
					}
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.#") + ")";
					}
					iTip += "ft";
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x000BFA14 File Offset: 0x000BDC14
		public void Graph_Recharge()
		{
			float num = 1f;
			int num2 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num2; index++)
			{
				float nBase = this.BaseArray[index].RechargeTime;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].RechargeTime;
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num3 = nBase;
						nBase = nEnh;
						nEnh = num3;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(nBase, "##0.##");
					}
					else
					{
						iTip = iTip + ": " + Strings.Format(nEnh, "##0.##");
					}
					iTip += "s";
					if (nBase != nEnh)
					{
						iTip = iTip + " (" + Strings.Format(nBase, "##0.##") + ")";
					}
					if (this.BaseOverride)
					{
						float num4 = nBase;
						nBase = nEnh;
						nEnh = num4;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x000BFBB4 File Offset: 0x000BDDB4
		public void Graph_Regen()
		{
			float num = 1f;
			float num2 = MidsContext.Character.DisplayStats.HealthHitpointsNumeric(false);
			int num3 = this.BaseArray.Length - 1;
			for (int index = 0; index <= num3; index++)
			{
				float nBase = this.BaseArray[index].GetEffectMagSum(Enums.eEffectType.Regeneration, false, false, false, false).Sum;
				if (nBase != 0f)
				{
					float nEnh = this.EnhArray[index].GetEffectMagSum(Enums.eEffectType.Regeneration, false, false, false, false).Sum;
					float num4 = (float)((double)(num2 / 12f) * (0.05 + 0.05 * (double)((nBase - 100f) / 100f)));
					float num5 = num4 / num2 * 100f;
					float num6 = (float)((double)(num2 / 12f) * (0.05 + 0.05 * (double)((nEnh - 100f) / 100f)));
					float num7 = num6 / num2 * 100f;
					string iTip = this.BaseArray[index].DisplayName;
					if (num < nEnh)
					{
						num = nEnh;
					}
					if (num < nBase)
					{
						num = nBase;
					}
					if (this.BaseOverride)
					{
						float num8 = nBase;
						nBase = nEnh;
						nEnh = num8;
						num8 = num4;
						num4 = num6;
						num6 = num8;
						num8 = num5;
						num5 = num7;
						num7 = num8;
					}
					if (this.Graph.Style == Enums.GraphStyle.baseOnly)
					{
						iTip = iTip + ": " + Strings.Format(nBase, "##0.#") + "%";
						iTip = string.Concat(new string[]
						{
							" Health regenerated per second: ",
							Strings.Format(num5, "##0.##"),
							"%\r\n HitPoints regenerated per second at level 50: ",
							Strings.Format(num4, "##0.##"),
							" HP"
						});
					}
					else if (nBase == nEnh)
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							": ",
							Strings.Format(nBase, "##0.#"),
							"%\r\n Health regenerated per second: ",
							Strings.Format(num5, "##0.##"),
							"%\r\n HitPoints regenerated per second at level 50: ",
							Strings.Format(num4, "##0.##"),
							" HP"
						});
					}
					else
					{
						iTip = string.Concat(new string[]
						{
							iTip,
							": ",
							Strings.Format(nEnh, "##0.#"),
							"% (",
							Strings.Format(nBase, "##0.#"),
							"%)"
						});
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n Health regenerated per second: ",
							Strings.Format(num7, "##0.##"),
							"% (",
							Strings.Format(num5, "##0.##"),
							")"
						});
						iTip = string.Concat(new string[]
						{
							iTip,
							"\r\n HitPoints regenerated per second at level 50: ",
							Strings.Format(num6, "##0.##"),
							" HP (",
							Strings.Format(num4, "##0.##"),
							")"
						});
					}
					if (this.BaseOverride)
					{
						float num9 = nBase;
						nBase = nEnh;
						nEnh = num9;
					}
					this.Graph.AddItem(this.BaseArray[index].DisplayName, nBase, nEnh, iTip);
				}
			}
			this.GraphMax = (float)((double)num * 1.025);
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x000C0AA8 File Offset: 0x000BECA8
		private void NewSets()
		{
			this.cbSet.BeginUpdate();
			ComboBox.ObjectCollection items = this.cbSet.Items;
			items.Clear();
			items.Add("All Sets");
			items.Add("Primary & Secondary");
			items.Add("Primary (" + MidsContext.Character.Powersets[0].DisplayName + ")");
			items.Add("Secondary (" + MidsContext.Character.Powersets[1].DisplayName + ")");
			items.Add("Ancillary");
			items.Add("Pools");
			items.Add("Powers Taken");
			items.Add("All Toggles");
			items.Add("All Clicks");
			this.cbSet.SelectedIndex = 1;
			this.cbSet.EndUpdate();
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x000C0B90 File Offset: 0x000BED90
		public void SetGraphMetrics()
		{
			if ((double)this.Graph.ItemCount < 13.5)
			{
				this.Graph.ItemHeight = 18;
				this.Graph.PaddingY = 6f;
			}
			else if ((double)this.Graph.ItemCount < 18.0)
			{
				this.Graph.ItemHeight = 15;
				this.Graph.PaddingY = 5f;
			}
			else if (this.Graph.ItemCount > 32)
			{
				this.Graph.PaddingY = 2f;
				this.Graph.ItemHeight = 10;
			}
			else if (this.Graph.ItemCount > 30)
			{
				this.Graph.PaddingY = 2f;
				this.Graph.ItemHeight = 11;
			}
			else if (this.Graph.ItemCount > 27)
			{
				this.Graph.PaddingY = 2.666667f;
				this.Graph.ItemHeight = 11;
			}
			else
			{
				this.Graph.ItemHeight = 12;
				this.Graph.PaddingY = 4f;
			}
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x000C0CF8 File Offset: 0x000BEEF8
		public void SetGraphType()
		{
			if (this.cbStyle.SelectedIndex > -1 & this.cbStyle.SelectedIndex < this.cbStyle.Items.Count - 2)
			{
				this.Graph.Style = (Enums.GraphStyle)this.cbStyle.SelectedIndex;
				MidsContext.Config.StatGraphStyle = this.Graph.Style;
				this.BaseOverride = false;
			}
			else if (this.cbStyle.SelectedIndex == this.cbStyle.Items.Count - 2)
			{
				this.Graph.Style = Enums.GraphStyle.Twin;
				this.BaseOverride = true;
			}
			else if (this.cbStyle.SelectedIndex == this.cbStyle.Items.Count - 1)
			{
				this.Graph.Style = Enums.GraphStyle.Stacked;
				this.BaseOverride = true;
			}
			this.GetPowerArray();
			if (this.BaseOverride)
			{
				this.lblKey1.Text = "Active";
				this.lblKey2.Text = "Alternate";
			}
			else
			{
				this.lblKey1.Text = "Base";
				this.lblKey2.Text = "Enhanced";
			}
			MidsContext.Config.StatGraphStyle = this.Graph.Style;
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x000C0E60 File Offset: 0x000BF060
		public void SetLocation()
		{
			Rectangle rectangle = default(Rectangle);
			rectangle.X = MainModule.MidsController.SzFrmStats.X;
			rectangle.Y = MainModule.MidsController.SzFrmStats.Y;
			rectangle.Width = MainModule.MidsController.SzFrmStats.Width;
			rectangle.Height = MainModule.MidsController.SzFrmStats.Height;
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

		// Token: 0x06001319 RID: 4889 RVA: 0x000C102F File Offset: 0x000BF22F
		public void SetScaleLabel()
		{
			this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x000C1058 File Offset: 0x000BF258
		private void StoreLocation()
		{
			if (MainModule.MidsController.IsAppInitialized)
			{
				MainModule.MidsController.SzFrmStats.X = base.Left;
				MainModule.MidsController.SzFrmStats.Y = base.Top;
				MainModule.MidsController.SzFrmStats.Width = base.Width;
				MainModule.MidsController.SzFrmStats.Height = base.Height;
			}
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x000C10B8 File Offset: 0x000BF2B8
		private void tbScaleX_Scroll(object sender, EventArgs e)
		{
			this.Graph.ScaleIndex = this.tbScaleX.Value;
			this.SetScaleLabel();
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x000C10DC File Offset: 0x000BF2DC
		public void UpdateData(bool NewData)
		{
			this.BackColor = this.myParent.BackColor;
			this.btnClose.IA = this.myParent.Drawing.pImageAttributes;
			this.btnClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.btnClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.chkOnTop.IA = this.myParent.Drawing.pImageAttributes;
			this.chkOnTop.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
			this.chkOnTop.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
			this.Graph.BackColor = this.BackColor;
			if (NewData)
			{
				this.NewSets();
			}
			this.SetGraphType();
			this.GetPowerArray();
			this.DisplayGraph();
		}

		// Token: 0x04000790 RID: 1936
		[AccessedThroughProperty("btnClose")]
		private ImageButton _btnClose;

		// Token: 0x04000791 RID: 1937
		[AccessedThroughProperty("cbSet")]
		private ComboBox _cbSet;

		// Token: 0x04000792 RID: 1938
		[AccessedThroughProperty("cbStyle")]
		private ComboBox _cbStyle;

		// Token: 0x04000793 RID: 1939
		[AccessedThroughProperty("cbValues")]
		private ComboBox _cbValues;

		// Token: 0x04000794 RID: 1940
		[AccessedThroughProperty("chkOnTop")]
		private ImageButton _chkOnTop;

		// Token: 0x04000795 RID: 1941
		[AccessedThroughProperty("Graph")]
		private ctlMultiGraph _Graph;

		// Token: 0x04000796 RID: 1942
		[AccessedThroughProperty("lblKey1")]
		private Label _lblKey1;

		// Token: 0x04000797 RID: 1943
		[AccessedThroughProperty("lblKey2")]
		private Label _lblKey2;

		// Token: 0x04000798 RID: 1944
		[AccessedThroughProperty("lblKeyColor1")]
		private Label _lblKeyColor1;

		// Token: 0x04000799 RID: 1945
		[AccessedThroughProperty("lblKeyColor2")]
		private Label _lblKeyColor2;

		// Token: 0x0400079A RID: 1946
		[AccessedThroughProperty("lblScale")]
		private Label _lblScale;

		// Token: 0x0400079B RID: 1947
		[AccessedThroughProperty("tbScaleX")]
		private TrackBar _tbScaleX;

		// Token: 0x0400079C RID: 1948
		[AccessedThroughProperty("tTip")]
		private ToolTip _tTip;

		// Token: 0x0400079D RID: 1949
		protected IPower[] BaseArray;

		// Token: 0x0400079E RID: 1950
		protected bool BaseOverride;

		// Token: 0x040007A0 RID: 1952
		protected IPower[] EnhArray;

		// Token: 0x040007A1 RID: 1953
		protected float GraphMax;

		// Token: 0x040007A2 RID: 1954
		private bool Loaded;

		// Token: 0x040007A3 RID: 1955
		protected frmMain myParent;
	}
}
