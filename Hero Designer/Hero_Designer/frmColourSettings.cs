using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Master_Classes;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
	// Token: 0x02000023 RID: 35
	public partial class frmColourSettings : Form
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0002DAD0 File Offset: 0x0002BCD0
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0002DAE8 File Offset: 0x0002BCE8
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

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0002DB44 File Offset: 0x0002BD44
		// (set) Token: 0x06000337 RID: 823 RVA: 0x0002DB5C File Offset: 0x0002BD5C
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

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0002DBB8 File Offset: 0x0002BDB8
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0002DBD0 File Offset: 0x0002BDD0
		internal virtual Button btnReset
		{
			get
			{
				return this._btnReset;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.btnReset_Click);
				if (this._btnReset != null)
				{
					this._btnReset.Click -= eventHandler;
				}
				this._btnReset = value;
				if (this._btnReset != null)
				{
					this._btnReset.Click += eventHandler;
				}
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0002DC2C File Offset: 0x0002BE2C
		// (set) Token: 0x0600033B RID: 827 RVA: 0x0002DC44 File Offset: 0x0002BE44
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

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600033C RID: 828 RVA: 0x0002DC50 File Offset: 0x0002BE50
		// (set) Token: 0x0600033D RID: 829 RVA: 0x0002DC68 File Offset: 0x0002BE68
		internal virtual Label csAlert
		{
			get
			{
				return this._csAlert;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csAlert_Click);
				if (this._csAlert != null)
				{
					this._csAlert.Click -= eventHandler;
				}
				this._csAlert = value;
				if (this._csAlert != null)
				{
					this._csAlert.Click += eventHandler;
				}
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0002DCC4 File Offset: 0x0002BEC4
		// (set) Token: 0x0600033F RID: 831 RVA: 0x0002DCDC File Offset: 0x0002BEDC
		internal virtual Label csEnh
		{
			get
			{
				return this._csEnh;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csEnh_Click);
				if (this._csEnh != null)
				{
					this._csEnh.Click -= eventHandler;
				}
				this._csEnh = value;
				if (this._csEnh != null)
				{
					this._csEnh.Click += eventHandler;
				}
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0002DD38 File Offset: 0x0002BF38
		// (set) Token: 0x06000341 RID: 833 RVA: 0x0002DD50 File Offset: 0x0002BF50
		internal virtual Label csFade
		{
			get
			{
				return this._csFade;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csFade_Click);
				if (this._csFade != null)
				{
					this._csFade.Click -= eventHandler;
				}
				this._csFade = value;
				if (this._csFade != null)
				{
					this._csFade.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0002DDAC File Offset: 0x0002BFAC
		// (set) Token: 0x06000343 RID: 835 RVA: 0x0002DDC4 File Offset: 0x0002BFC4
		internal virtual Label csHero
		{
			get
			{
				return this._csHero;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csHero_Click);
				if (this._csHero != null)
				{
					this._csHero.Click -= eventHandler;
				}
				this._csHero = value;
				if (this._csHero != null)
				{
					this._csHero.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0002DE20 File Offset: 0x0002C020
		// (set) Token: 0x06000345 RID: 837 RVA: 0x0002DE38 File Offset: 0x0002C038
		internal virtual Label csInv
		{
			get
			{
				return this._csInv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csInv_Click);
				if (this._csInv != null)
				{
					this._csInv.Click -= eventHandler;
				}
				this._csInv = value;
				if (this._csInv != null)
				{
					this._csInv.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0002DE94 File Offset: 0x0002C094
		// (set) Token: 0x06000347 RID: 839 RVA: 0x0002DEAC File Offset: 0x0002C0AC
		internal virtual Label csInvInv
		{
			get
			{
				return this._csInvInv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csInvInv_Click);
				if (this._csInvInv != null)
				{
					this._csInvInv.Click -= eventHandler;
				}
				this._csInvInv = value;
				if (this._csInvInv != null)
				{
					this._csInvInv.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0002DF08 File Offset: 0x0002C108
		// (set) Token: 0x06000349 RID: 841 RVA: 0x0002DF20 File Offset: 0x0002C120
		internal virtual Label csSpecial
		{
			get
			{
				return this._csSpecial;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csSpecial_Click);
				if (this._csSpecial != null)
				{
					this._csSpecial.Click -= eventHandler;
				}
				this._csSpecial = value;
				if (this._csSpecial != null)
				{
					this._csSpecial.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0002DF7C File Offset: 0x0002C17C
		// (set) Token: 0x0600034B RID: 843 RVA: 0x0002DF94 File Offset: 0x0002C194
		internal virtual Label csText
		{
			get
			{
				return this._csText;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csText_Click);
				if (this._csText != null)
				{
					this._csText.Click -= eventHandler;
				}
				this._csText = value;
				if (this._csText != null)
				{
					this._csText.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0002DFF0 File Offset: 0x0002C1F0
		// (set) Token: 0x0600034D RID: 845 RVA: 0x0002E008 File Offset: 0x0002C208
		internal virtual Label csValue
		{
			get
			{
				return this._csValue;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csValue_Click);
				if (this._csValue != null)
				{
					this._csValue.Click -= eventHandler;
				}
				this._csValue = value;
				if (this._csValue != null)
				{
					this._csValue.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600034E RID: 846 RVA: 0x0002E064 File Offset: 0x0002C264
		// (set) Token: 0x0600034F RID: 847 RVA: 0x0002E07C File Offset: 0x0002C27C
		internal virtual Label csVillain
		{
			get
			{
				return this._csVillain;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.csVillain_Click);
				if (this._csVillain != null)
				{
					this._csVillain.Click -= eventHandler;
				}
				this._csVillain = value;
				if (this._csVillain != null)
				{
					this._csVillain.Click += eventHandler;
				}
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000350 RID: 848 RVA: 0x0002E0D8 File Offset: 0x0002C2D8
		// (set) Token: 0x06000351 RID: 849 RVA: 0x0002E0F0 File Offset: 0x0002C2F0
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

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000352 RID: 850 RVA: 0x0002E0FC File Offset: 0x0002C2FC
		// (set) Token: 0x06000353 RID: 851 RVA: 0x0002E114 File Offset: 0x0002C314
		internal virtual Label Label10
		{
			get
			{
				return this._Label10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label10 = value;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000354 RID: 852 RVA: 0x0002E120 File Offset: 0x0002C320
		// (set) Token: 0x06000355 RID: 853 RVA: 0x0002E138 File Offset: 0x0002C338
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

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000356 RID: 854 RVA: 0x0002E144 File Offset: 0x0002C344
		// (set) Token: 0x06000357 RID: 855 RVA: 0x0002E15C File Offset: 0x0002C35C
		internal virtual Label Label2
		{
			get
			{
				return this._Label2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0002E168 File Offset: 0x0002C368
		// (set) Token: 0x06000359 RID: 857 RVA: 0x0002E180 File Offset: 0x0002C380
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

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0002E18C File Offset: 0x0002C38C
		// (set) Token: 0x0600035B RID: 859 RVA: 0x0002E1A4 File Offset: 0x0002C3A4
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0002E1B0 File Offset: 0x0002C3B0
		// (set) Token: 0x0600035D RID: 861 RVA: 0x0002E1C8 File Offset: 0x0002C3C8
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

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0002E1D4 File Offset: 0x0002C3D4
		// (set) Token: 0x0600035F RID: 863 RVA: 0x0002E1EC File Offset: 0x0002C3EC
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

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000360 RID: 864 RVA: 0x0002E1F8 File Offset: 0x0002C3F8
		// (set) Token: 0x06000361 RID: 865 RVA: 0x0002E210 File Offset: 0x0002C410
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

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0002E21C File Offset: 0x0002C41C
		// (set) Token: 0x06000363 RID: 867 RVA: 0x0002E234 File Offset: 0x0002C434
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

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000364 RID: 868 RVA: 0x0002E240 File Offset: 0x0002C440
		// (set) Token: 0x06000365 RID: 869 RVA: 0x0002E258 File Offset: 0x0002C458
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

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0002E264 File Offset: 0x0002C464
		// (set) Token: 0x06000367 RID: 871 RVA: 0x0002E27C File Offset: 0x0002C47C
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

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0002E288 File Offset: 0x0002C488
		// (set) Token: 0x06000369 RID: 873 RVA: 0x0002E2A0 File Offset: 0x0002C4A0
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

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0002E2AC File Offset: 0x0002C4AC
		// (set) Token: 0x0600036B RID: 875 RVA: 0x0002E2C4 File Offset: 0x0002C4C4
		internal virtual ListLabelV2 Listlabel1
		{
			get
			{
				return this._Listlabel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.Listlabel1_ItemClick);
				if (this._Listlabel1 != null)
				{
					this._Listlabel1.ItemClick -= clickEventHandler;
				}
				this._Listlabel1 = value;
				if (this._Listlabel1 != null)
				{
					this._Listlabel1.ItemClick += clickEventHandler;
				}
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600036C RID: 876 RVA: 0x0002E320 File Offset: 0x0002C520
		// (set) Token: 0x0600036D RID: 877 RVA: 0x0002E338 File Offset: 0x0002C538
		internal virtual RichTextBox rtPreview
		{
			get
			{
				return this._rtPreview;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._rtPreview = value;
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0002E342 File Offset: 0x0002C542
		public frmColourSettings()
		{
			base.Load += this.frmColourSettings_Load;
			this.InitializeComponent();
			this.myFS.Assign(MidsContext.Config.RtFont);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0002E37D File Offset: 0x0002C57D
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0002E387 File Offset: 0x0002C587
		private void btnOK_Click(object sender, EventArgs e)
		{
			MidsContext.Config.RtFont.Assign(this.myFS);
			base.Hide();
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0002E3A7 File Offset: 0x0002C5A7
		private void btnReset_Click(object sender, EventArgs e)
		{
			this.myFS.SetDefault();
			this.updateColours();
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0002E3C0 File Offset: 0x0002C5C0
		private void csAlert_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorWarning;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorWarning = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0002E41C File Offset: 0x0002C61C
		private void csEnh_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorEnhancement;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorEnhancement = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0002E478 File Offset: 0x0002C678
		private void csFade_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorFaded;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorFaded = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0002E4D4 File Offset: 0x0002C6D4
		private void csHero_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorBackgroundHero;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorBackgroundHero = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0002E530 File Offset: 0x0002C730
		private void csInv_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorInvention;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorInvention = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0002E58C File Offset: 0x0002C78C
		private void csInvInv_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorInventionInv;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorInventionInv = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0002E5E8 File Offset: 0x0002C7E8
		private void csSpecial_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorPlSpecial;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorPlSpecial = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0002E644 File Offset: 0x0002C844
		private void csText_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorText;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorText = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0002E6A0 File Offset: 0x0002C8A0
		private void csValue_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorPlName;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorPlName = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0002E6FC File Offset: 0x0002C8FC
		private void csVillain_Click(object sender, EventArgs e)
		{
			this.cPicker.Color = this.myFS.ColorBackgroundVillain;
			if (this.cPicker.ShowDialog(this) == DialogResult.OK)
			{
				this.myFS.ColorBackgroundVillain = this.cPicker.Color;
			}
			this.updateColours();
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0002E790 File Offset: 0x0002C990
		private void frmColourSettings_Load(object sender, EventArgs e)
		{
			this.updateColours();
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0002F9B0 File Offset: 0x0002DBB0
		private void Listlabel1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
		{
			switch (Item.Index)
			{
			case 0:
				this.cPicker.Color = this.myFS.ColorPowerAvailable;
				if (this.cPicker.ShowDialog(this) == DialogResult.OK)
				{
					this.myFS.ColorPowerAvailable = this.cPicker.Color;
				}
				break;
			case 1:
				this.cPicker.Color = this.myFS.ColorPowerTaken;
				if (this.cPicker.ShowDialog(this) == DialogResult.OK)
				{
					this.myFS.ColorPowerTaken = this.cPicker.Color;
				}
				break;
			case 2:
				this.cPicker.Color = this.myFS.ColorPowerTakenDark;
				if (this.cPicker.ShowDialog(this) == DialogResult.OK)
				{
					this.myFS.ColorPowerTakenDark = this.cPicker.Color;
				}
				break;
			case 3:
				this.cPicker.Color = this.myFS.ColorPowerDisabled;
				if (this.cPicker.ShowDialog(this) == DialogResult.OK)
				{
					this.myFS.ColorPowerDisabled = this.cPicker.Color;
				}
				break;
			case 4:
				this.cPicker.Color = this.myFS.ColorPowerHighlight;
				if (this.cPicker.ShowDialog(this) == DialogResult.OK)
				{
					this.myFS.ColorPowerHighlight = this.cPicker.Color;
				}
				break;
			}
			this.updateColours();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0002FB58 File Offset: 0x0002DD58
		public void updateColours()
		{
			ConfigData.FontSettings iFs = default(ConfigData.FontSettings);
			this.csHero.BackColor = this.myFS.ColorBackgroundHero;
			this.csVillain.BackColor = this.myFS.ColorBackgroundVillain;
			this.csText.BackColor = this.myFS.ColorText;
			this.csInv.BackColor = this.myFS.ColorInvention;
			this.csInvInv.BackColor = this.myFS.ColorInventionInv;
			this.csFade.BackColor = this.myFS.ColorFaded;
			this.csEnh.BackColor = this.myFS.ColorEnhancement;
			this.csAlert.BackColor = this.myFS.ColorWarning;
			this.csValue.BackColor = this.myFS.ColorPlName;
			this.csSpecial.BackColor = this.myFS.ColorPlSpecial;
			iFs.Assign(MidsContext.Config.RtFont);
			MidsContext.Config.RtFont.Assign(this.myFS);
			this.rtPreview.BackColor = this.myFS.ColorBackgroundHero;
			MidsContext.Config.RtFont.ColorBackgroundHero = this.myFS.ColorPlName;
			MidsContext.Config.RtFont.ColorBackgroundVillain = this.myFS.ColorPlSpecial;
			RTF rtf = MidsContext.Config.RTF;
			string text = RTF.StartRTF() + RTF.Color(RTF.ElementID.Invention) + RTF.Underline("Invention Name") + RTF.Crlf();
			text = string.Concat(new string[]
			{
				text,
				RTF.Color(RTF.ElementID.Enhancement),
				RTF.Italic("Enhancement Text"),
				RTF.Color(RTF.ElementID.Warning),
				" (Alert)",
				RTF.Crlf(),
				RTF.Color(RTF.ElementID.Text),
				"  Regular Text",
				RTF.Crlf(),
				RTF.Color(RTF.ElementID.Text),
				"  Regular Text",
				RTF.Crlf()
			});
			text = string.Concat(new string[]
			{
				text,
				RTF.Color(RTF.ElementID.Faded),
				"  Faded Text",
				RTF.Crlf(),
				RTF.Crlf()
			});
			text = string.Concat(new string[]
			{
				text,
				RTF.Color(RTF.ElementID.BackgroundHero),
				RTF.Bold("Value Name: "),
				RTF.Color(RTF.ElementID.Text),
				"Normal Text",
				RTF.Crlf()
			});
			text = string.Concat(new string[]
			{
				text,
				RTF.Color(RTF.ElementID.BackgroundHero),
				RTF.Bold("Value Name: "),
				RTF.Color(RTF.ElementID.BackgroundVillain),
				"Special Case",
				RTF.Crlf()
			});
			text = string.Concat(new string[]
			{
				text,
				RTF.Color(RTF.ElementID.BackgroundHero),
				RTF.Bold("Value Name: "),
				RTF.Color(RTF.ElementID.Enhancement),
				"Enahnced value",
				RTF.Crlf()
			});
			text = string.Concat(new string[]
			{
				text,
				RTF.Color(RTF.ElementID.BackgroundHero),
				RTF.Bold("Value Name: "),
				RTF.Color(RTF.ElementID.Invention),
				"Invention Effect",
				RTF.Crlf(),
				RTF.EndRTF()
			});
			this.rtPreview.Rtf = text;
			this.Listlabel1.SuspendRedraw = true;
			this.Listlabel1.ClearItems();
			this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Available Power", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
			this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Taken Power", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
			this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Taken Power (Dark)", ListLabelV2.LLItemState.SelectedDisabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
			this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Unavailable Power", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
			this.Listlabel1.AddItem(new ListLabelV2.ListLabelItemV2("Highlight Colour", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
			this.Listlabel1.HoverColor = this.myFS.ColorPowerHighlight;
			this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.Enabled, this.myFS.ColorPowerAvailable);
			this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.Selected, this.myFS.ColorPowerTaken);
			this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, this.myFS.ColorPowerTakenDark);
			this.Listlabel1.UpdateTextColors(ListLabelV2.LLItemState.Disabled, this.myFS.ColorPowerDisabled);
			this.Listlabel1.Font = new Font(this.Listlabel1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase);
			int num = this.Listlabel1.Items.Length - 1;
			for (int index = 0; index <= num; index++)
			{
				this.Listlabel1.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
			}
			this.Listlabel1.SuspendRedraw = false;
			this.Listlabel1.Refresh();
			MidsContext.Config.RtFont.Assign(iFs);
		}

		// Token: 0x0400015D RID: 349
		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		// Token: 0x0400015E RID: 350
		[AccessedThroughProperty("btnOK")]
		private Button _btnOK;

		// Token: 0x0400015F RID: 351
		[AccessedThroughProperty("btnReset")]
		private Button _btnReset;

		// Token: 0x04000160 RID: 352
		[AccessedThroughProperty("cPicker")]
		private ColorDialog _cPicker;

		// Token: 0x04000161 RID: 353
		[AccessedThroughProperty("csAlert")]
		private Label _csAlert;

		// Token: 0x04000162 RID: 354
		[AccessedThroughProperty("csEnh")]
		private Label _csEnh;

		// Token: 0x04000163 RID: 355
		[AccessedThroughProperty("csFade")]
		private Label _csFade;

		// Token: 0x04000164 RID: 356
		[AccessedThroughProperty("csHero")]
		private Label _csHero;

		// Token: 0x04000165 RID: 357
		[AccessedThroughProperty("csInv")]
		private Label _csInv;

		// Token: 0x04000166 RID: 358
		[AccessedThroughProperty("csInvInv")]
		private Label _csInvInv;

		// Token: 0x04000167 RID: 359
		[AccessedThroughProperty("csSpecial")]
		private Label _csSpecial;

		// Token: 0x04000168 RID: 360
		[AccessedThroughProperty("csText")]
		private Label _csText;

		// Token: 0x04000169 RID: 361
		[AccessedThroughProperty("csValue")]
		private Label _csValue;

		// Token: 0x0400016A RID: 362
		[AccessedThroughProperty("csVillain")]
		private Label _csVillain;

		// Token: 0x0400016B RID: 363
		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		// Token: 0x0400016C RID: 364
		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		// Token: 0x0400016D RID: 365
		[AccessedThroughProperty("Label19")]
		private Label _Label19;

		// Token: 0x0400016E RID: 366
		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		// Token: 0x0400016F RID: 367
		[AccessedThroughProperty("Label20")]
		private Label _Label20;

		// Token: 0x04000170 RID: 368
		[AccessedThroughProperty("Label21")]
		private Label _Label21;

		// Token: 0x04000171 RID: 369
		[AccessedThroughProperty("Label22")]
		private Label _Label22;

		// Token: 0x04000172 RID: 370
		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		// Token: 0x04000173 RID: 371
		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		// Token: 0x04000174 RID: 372
		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		// Token: 0x04000175 RID: 373
		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		// Token: 0x04000176 RID: 374
		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		// Token: 0x04000177 RID: 375
		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		// Token: 0x04000178 RID: 376
		[AccessedThroughProperty("Listlabel1")]
		private ListLabelV2 _Listlabel1;

		// Token: 0x04000179 RID: 377
		[AccessedThroughProperty("rtPreview")]
		private RichTextBox _rtPreview;

		// Token: 0x0400017B RID: 379
		protected ConfigData.FontSettings myFS;
	}
}
