using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmSetEdit : Form
    {

        // (get) Token: 0x060011D9 RID: 4569 RVA: 0x000B2D90 File Offset: 0x000B0F90
        // (set) Token: 0x060011DA RID: 4570 RVA: 0x000B2DA8 File Offset: 0x000B0FA8
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


        // (get) Token: 0x060011DB RID: 4571 RVA: 0x000B2E04 File Offset: 0x000B1004
        // (set) Token: 0x060011DC RID: 4572 RVA: 0x000B2E1C File Offset: 0x000B101C
        internal virtual Button btnImage
        {
            get
            {
                return this._btnImage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnImage_Click);
                if (this._btnImage != null)
                {
                    this._btnImage.Click -= eventHandler;
                }
                this._btnImage = value;
                if (this._btnImage != null)
                {
                    this._btnImage.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060011DD RID: 4573 RVA: 0x000B2E78 File Offset: 0x000B1078
        // (set) Token: 0x060011DE RID: 4574 RVA: 0x000B2E90 File Offset: 0x000B1090
        internal virtual Button btnNoImage
        {
            get
            {
                return this._btnNoImage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnNoImage_Click);
                if (this._btnNoImage != null)
                {
                    this._btnNoImage.Click -= eventHandler;
                }
                this._btnNoImage = value;
                if (this._btnNoImage != null)
                {
                    this._btnNoImage.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060011DF RID: 4575 RVA: 0x000B2EEC File Offset: 0x000B10EC
        // (set) Token: 0x060011E0 RID: 4576 RVA: 0x000B2F04 File Offset: 0x000B1104
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


        // (get) Token: 0x060011E1 RID: 4577 RVA: 0x000B2F60 File Offset: 0x000B1160
        // (set) Token: 0x060011E2 RID: 4578 RVA: 0x000B2F78 File Offset: 0x000B1178
        internal virtual Button btnPaste
        {
            get
            {
                return this._btnPaste;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPaste_Click);
                if (this._btnPaste != null)
                {
                    this._btnPaste.Click -= eventHandler;
                }
                this._btnPaste = value;
                if (this._btnPaste != null)
                {
                    this._btnPaste.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060011E3 RID: 4579 RVA: 0x000B2FD4 File Offset: 0x000B11D4
        // (set) Token: 0x060011E4 RID: 4580 RVA: 0x000B2FEC File Offset: 0x000B11EC
        internal virtual ComboBox cbSetType
        {
            get
            {
                return this._cbSetType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSetType_SelectedIndexChanged);
                if (this._cbSetType != null)
                {
                    this._cbSetType.SelectedIndexChanged -= eventHandler;
                }
                this._cbSetType = value;
                if (this._cbSetType != null)
                {
                    this._cbSetType.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x060011E5 RID: 4581 RVA: 0x000B3048 File Offset: 0x000B1248
        // (set) Token: 0x060011E6 RID: 4582 RVA: 0x000B3060 File Offset: 0x000B1260
        internal virtual ComboBox cbSlotCount
        {
            get
            {
                return this._cbSlotCount;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSlotX_SelectedIndexChanged);
                if (this._cbSlotCount != null)
                {
                    this._cbSlotCount.SelectedIndexChanged -= eventHandler;
                }
                this._cbSlotCount = value;
                if (this._cbSlotCount != null)
                {
                    this._cbSlotCount.SelectedIndexChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x060011E7 RID: 4583 RVA: 0x000B30BC File Offset: 0x000B12BC
        // (set) Token: 0x060011E8 RID: 4584 RVA: 0x000B30D4 File Offset: 0x000B12D4
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


        // (get) Token: 0x060011E9 RID: 4585 RVA: 0x000B30E0 File Offset: 0x000B12E0
        // (set) Token: 0x060011EA RID: 4586 RVA: 0x000B30F8 File Offset: 0x000B12F8
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


        // (get) Token: 0x060011EB RID: 4587 RVA: 0x000B3104 File Offset: 0x000B1304
        // (set) Token: 0x060011EC RID: 4588 RVA: 0x000B311C File Offset: 0x000B131C
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


        // (get) Token: 0x060011ED RID: 4589 RVA: 0x000B3128 File Offset: 0x000B1328
        // (set) Token: 0x060011EE RID: 4590 RVA: 0x000B3140 File Offset: 0x000B1340
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


        // (get) Token: 0x060011EF RID: 4591 RVA: 0x000B314C File Offset: 0x000B134C
        // (set) Token: 0x060011F0 RID: 4592 RVA: 0x000B3164 File Offset: 0x000B1364
        internal virtual GroupBox gbBasic
        {
            get
            {
                return this._gbBasic;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gbBasic = value;
            }
        }


        // (get) Token: 0x060011F1 RID: 4593 RVA: 0x000B3170 File Offset: 0x000B1370
        // (set) Token: 0x060011F2 RID: 4594 RVA: 0x000B3188 File Offset: 0x000B1388
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


        // (get) Token: 0x060011F3 RID: 4595 RVA: 0x000B3194 File Offset: 0x000B1394
        // (set) Token: 0x060011F4 RID: 4596 RVA: 0x000B31AC File Offset: 0x000B13AC
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }


        // (get) Token: 0x060011F5 RID: 4597 RVA: 0x000B31B8 File Offset: 0x000B13B8
        // (set) Token: 0x060011F6 RID: 4598 RVA: 0x000B31D0 File Offset: 0x000B13D0
        internal virtual ImageList ilEnh
        {
            get
            {
                return this._ilEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilEnh = value;
            }
        }


        // (get) Token: 0x060011F7 RID: 4599 RVA: 0x000B31DC File Offset: 0x000B13DC
        // (set) Token: 0x060011F8 RID: 4600 RVA: 0x000B31F4 File Offset: 0x000B13F4
        internal virtual OpenFileDialog ImagePicker
        {
            get
            {
                return this._ImagePicker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ImagePicker = value;
            }
        }


        // (get) Token: 0x060011F9 RID: 4601 RVA: 0x000B3200 File Offset: 0x000B1400
        // (set) Token: 0x060011FA RID: 4602 RVA: 0x000B3218 File Offset: 0x000B1418
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


        // (get) Token: 0x060011FB RID: 4603 RVA: 0x000B3224 File Offset: 0x000B1424
        // (set) Token: 0x060011FC RID: 4604 RVA: 0x000B323C File Offset: 0x000B143C
        internal virtual Label Label16
        {
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label16 = value;
            }
        }


        // (get) Token: 0x060011FD RID: 4605 RVA: 0x000B3248 File Offset: 0x000B1448
        // (set) Token: 0x060011FE RID: 4606 RVA: 0x000B3260 File Offset: 0x000B1460
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


        // (get) Token: 0x060011FF RID: 4607 RVA: 0x000B326C File Offset: 0x000B146C
        // (set) Token: 0x06001200 RID: 4608 RVA: 0x000B3284 File Offset: 0x000B1484
        internal virtual Label Label27
        {
            get
            {
                return this._Label27;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label27 = value;
            }
        }


        // (get) Token: 0x06001201 RID: 4609 RVA: 0x000B3290 File Offset: 0x000B1490
        // (set) Token: 0x06001202 RID: 4610 RVA: 0x000B32A8 File Offset: 0x000B14A8
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


        // (get) Token: 0x06001203 RID: 4611 RVA: 0x000B32B4 File Offset: 0x000B14B4
        // (set) Token: 0x06001204 RID: 4612 RVA: 0x000B32CC File Offset: 0x000B14CC
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


        // (get) Token: 0x06001205 RID: 4613 RVA: 0x000B32D8 File Offset: 0x000B14D8
        // (set) Token: 0x06001206 RID: 4614 RVA: 0x000B32F0 File Offset: 0x000B14F0
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


        // (get) Token: 0x06001207 RID: 4615 RVA: 0x000B32FC File Offset: 0x000B14FC
        // (set) Token: 0x06001208 RID: 4616 RVA: 0x000B3314 File Offset: 0x000B1514
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


        // (get) Token: 0x06001209 RID: 4617 RVA: 0x000B3320 File Offset: 0x000B1520
        // (set) Token: 0x0600120A RID: 4618 RVA: 0x000B3338 File Offset: 0x000B1538
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


        // (get) Token: 0x0600120B RID: 4619 RVA: 0x000B3344 File Offset: 0x000B1544
        // (set) Token: 0x0600120C RID: 4620 RVA: 0x000B335C File Offset: 0x000B155C
        internal virtual ListBox lstBonus
        {
            get
            {
                return this._lstBonus;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstBonus_DoubleClick);
                if (this._lstBonus != null)
                {
                    this._lstBonus.DoubleClick -= eventHandler;
                }
                this._lstBonus = value;
                if (this._lstBonus != null)
                {
                    this._lstBonus.DoubleClick += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600120D RID: 4621 RVA: 0x000B33B8 File Offset: 0x000B15B8
        // (set) Token: 0x0600120E RID: 4622 RVA: 0x000B33D0 File Offset: 0x000B15D0
        internal virtual ListView lvBonusList
        {
            get
            {
                return this._lvBonusList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvBonusList_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvBonusList_DoubleClick);
                if (this._lvBonusList != null)
                {
                    this._lvBonusList.SelectedIndexChanged -= eventHandler;
                    this._lvBonusList.DoubleClick -= eventHandler2;
                }
                this._lvBonusList = value;
                if (this._lvBonusList != null)
                {
                    this._lvBonusList.SelectedIndexChanged += eventHandler;
                    this._lvBonusList.DoubleClick += eventHandler2;
                }
            }
        }


        // (get) Token: 0x0600120F RID: 4623 RVA: 0x000B3454 File Offset: 0x000B1654
        // (set) Token: 0x06001210 RID: 4624 RVA: 0x000B346C File Offset: 0x000B166C
        internal virtual ListView lvEnh
        {
            get
            {
                return this._lvEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lvEnh = value;
            }
        }


        // (get) Token: 0x06001211 RID: 4625 RVA: 0x000B3478 File Offset: 0x000B1678
        // (set) Token: 0x06001212 RID: 4626 RVA: 0x000B3490 File Offset: 0x000B1690
        internal virtual RadioButton rbIfAny
        {
            get
            {
                return this._rbIfAny;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbIfAny = value;
            }
        }


        // (get) Token: 0x06001213 RID: 4627 RVA: 0x000B349C File Offset: 0x000B169C
        // (set) Token: 0x06001214 RID: 4628 RVA: 0x000B34B4 File Offset: 0x000B16B4
        internal virtual RadioButton rbIfCritter
        {
            get
            {
                return this._rbIfCritter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbIfCritter = value;
            }
        }


        // (get) Token: 0x06001215 RID: 4629 RVA: 0x000B34C0 File Offset: 0x000B16C0
        // (set) Token: 0x06001216 RID: 4630 RVA: 0x000B34D8 File Offset: 0x000B16D8
        internal virtual RadioButton rbIfPlayer
        {
            get
            {
                return this._rbIfPlayer;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbIfPlayer = value;
            }
        }


        // (get) Token: 0x06001217 RID: 4631 RVA: 0x000B34E4 File Offset: 0x000B16E4
        // (set) Token: 0x06001218 RID: 4632 RVA: 0x000B34FC File Offset: 0x000B16FC
        internal virtual RichTextBox rtbBonus
        {
            get
            {
                return this._rtbBonus;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtbBonus = value;
            }
        }


        // (get) Token: 0x06001219 RID: 4633 RVA: 0x000B3508 File Offset: 0x000B1708
        // (set) Token: 0x0600121A RID: 4634 RVA: 0x000B3520 File Offset: 0x000B1720
        internal virtual TextBox txtAlternate
        {
            get
            {
                return this._txtAlternate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtAlternate_TextChanged);
                if (this._txtAlternate != null)
                {
                    this._txtAlternate.TextChanged -= eventHandler;
                }
                this._txtAlternate = value;
                if (this._txtAlternate != null)
                {
                    this._txtAlternate.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600121B RID: 4635 RVA: 0x000B357C File Offset: 0x000B177C
        // (set) Token: 0x0600121C RID: 4636 RVA: 0x000B3594 File Offset: 0x000B1794
        internal virtual TextBox txtDesc
        {
            get
            {
                return this._txtDesc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDesc_TextChanged);
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged -= eventHandler;
                }
                this._txtDesc = value;
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600121D RID: 4637 RVA: 0x000B35F0 File Offset: 0x000B17F0
        // (set) Token: 0x0600121E RID: 4638 RVA: 0x000B3608 File Offset: 0x000B1808
        internal virtual TextBox txtInternal
        {
            get
            {
                return this._txtInternal;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtInternal_TextChanged);
                if (this._txtInternal != null)
                {
                    this._txtInternal.TextChanged -= eventHandler;
                }
                this._txtInternal = value;
                if (this._txtInternal != null)
                {
                    this._txtInternal.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x0600121F RID: 4639 RVA: 0x000B3664 File Offset: 0x000B1864
        // (set) Token: 0x06001220 RID: 4640 RVA: 0x000B367C File Offset: 0x000B187C
        internal virtual TextBox txtNameFull
        {
            get
            {
                return this._txtNameFull;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNameFull_TextChanged);
                if (this._txtNameFull != null)
                {
                    this._txtNameFull.TextChanged -= eventHandler;
                }
                this._txtNameFull = value;
                if (this._txtNameFull != null)
                {
                    this._txtNameFull.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001221 RID: 4641 RVA: 0x000B36D8 File Offset: 0x000B18D8
        // (set) Token: 0x06001222 RID: 4642 RVA: 0x000B36F0 File Offset: 0x000B18F0
        internal virtual TextBox txtNameShort
        {
            get
            {
                return this._txtNameShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNameShort_TextChanged);
                if (this._txtNameShort != null)
                {
                    this._txtNameShort.TextChanged -= eventHandler;
                }
                this._txtNameShort = value;
                if (this._txtNameShort != null)
                {
                    this._txtNameShort.TextChanged += eventHandler;
                }
            }
        }


        // (get) Token: 0x06001223 RID: 4643 RVA: 0x000B374C File Offset: 0x000B194C
        // (set) Token: 0x06001224 RID: 4644 RVA: 0x000B3764 File Offset: 0x000B1964
        internal virtual NumericUpDown udMaxLevel
        {
            get
            {
                return this._udMaxLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udMaxLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.udMaxLevel_ValueChanged);
                if (this._udMaxLevel != null)
                {
                    this._udMaxLevel.Leave -= eventHandler;
                    this._udMaxLevel.ValueChanged -= eventHandler2;
                }
                this._udMaxLevel = value;
                if (this._udMaxLevel != null)
                {
                    this._udMaxLevel.Leave += eventHandler;
                    this._udMaxLevel.ValueChanged += eventHandler2;
                }
            }
        }


        // (get) Token: 0x06001225 RID: 4645 RVA: 0x000B37E8 File Offset: 0x000B19E8
        // (set) Token: 0x06001226 RID: 4646 RVA: 0x000B3800 File Offset: 0x000B1A00
        internal virtual NumericUpDown udMinLevel
        {
            get
            {
                return this._udMinLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udMinLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.udMinLevel_ValueChanged);
                if (this._udMinLevel != null)
                {
                    this._udMinLevel.Leave -= eventHandler;
                    this._udMinLevel.ValueChanged -= eventHandler2;
                }
                this._udMinLevel = value;
                if (this._udMinLevel != null)
                {
                    this._udMinLevel.Leave += eventHandler;
                    this._udMinLevel.ValueChanged += eventHandler2;
                }
            }
        }


        public frmSetEdit(ref EnhancementSet iSet)
        {
            base.Load += this.frmSetEdit_Load;
            this.SetBonusList = new int[0];
            this.SetBonusListPVP = new int[0];
            this.Loading = true;
            this.InitializeComponent();
            this.mySet = new EnhancementSet(iSet);
        }


        public int BonusID()
        {
            return this.cbSlotCount.SelectedIndex;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        private void btnImage_Click(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.ImagePicker.InitialDirectory = I9Gfx.GetEnhancementsPath();
                this.ImagePicker.FileName = this.mySet.Image;
                if (this.ImagePicker.ShowDialog() == DialogResult.OK)
                {
                    string str = FileIO.StripPath(this.ImagePicker.FileName);
                    if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
                    {
                        Interaction.MsgBox("You must select an image from the " + I9Gfx.GetEnhancementsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it.", MsgBoxStyle.Information, "Ah...");
                    }
                    else
                    {
                        this.mySet.Image = str;
                        this.DisplayIcon();
                    }
                }
            }
        }


        private void btnNoImage_Click(object sender, EventArgs e)
        {
            this.mySet.Image = "";
            this.DisplayIcon();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.mySet.LevelMin = Convert.ToInt32(decimal.Subtract(this.udMinLevel.Value, 1m));
            this.mySet.LevelMax = Convert.ToInt32(decimal.Subtract(this.udMaxLevel.Value, 1m));
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        private void btnPaste_Click(object sender, EventArgs e)
        {
            string str = Conversions.ToString(Clipboard.GetData("System.String"));
            char[] chArray = new char[]
            {
                '^'
            };
            string[] strArray = str.Replace("\r\n", Conversions.ToString(chArray[0])).Split(chArray);
            chArray[0] = '\t';
            this.mySet.InitBonus();
            int num = strArray.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string[] strArray2 = strArray[index].Split(chArray);
                if (strArray2.Length > 3)
                {
                    int num2 = (int)Math.Round(Conversion.Val(strArray2[0]));
                    int index2 = DatabaseAPI.NidFromUidPower(strArray2[3]);
                    num2 -= 2;
                    if (num2 > -1 & index2 > -1)
                    {
                        EnhancementSet.BonusItem[] bonus = this.mySet.Bonus;
                        int index3 = num2;
                        bonus[index3].Name = (string[])Utils.CopyArray(bonus[index3].Name, new string[bonus[index3].Name.Length + 1]);
                        bonus[index3].Index = (int[])Utils.CopyArray(bonus[index3].Index, new int[bonus[index3].Index.Length + 1]);
                        bonus[index3].Index[bonus[index3].Index.Length - 1] = index2;
                        bonus[index3].Name[bonus[index3].Name.Length - 1] = DatabaseAPI.Database.Power[index2].FullName;
                    }
                }
            }
            this.DisplayBonus();
            this.DisplayBonusText();
        }


        private void cbSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.SetType = (Enums.eSetType)this.cbSetType.SelectedIndex;
            }
        }


        private void cbSlotX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.DisplayBonus();
                this.DisplayBonusText();
            }
        }


        public void DisplayBonus()
        {
            try
            {
                this.lstBonus.BeginUpdate();
                this.lstBonus.Items.Clear();
                if (this.isBonus())
                {
                    int index = this.BonusID();
                    int num = this.mySet.Bonus[index].Index.Length - 1;
                    for (int index2 = 0; index2 <= num; index2++)
                    {
                        this.lstBonus.Items.Add(DatabaseAPI.Database.Power[this.mySet.Bonus[index].Index[index2]].PowerName);
                    }
                    this.txtAlternate.Text = this.mySet.Bonus[index].AltString;
                }
                else if (this.isSpecial())
                {
                    int index = this.SpecialID();
                    int num2 = this.mySet.SpecialBonus[index].Index.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        this.lstBonus.Items.Add(DatabaseAPI.Database.Power[this.mySet.SpecialBonus[index].Index[index2]].PowerName);
                    }
                    this.txtAlternate.Text = this.mySet.SpecialBonus[index].AltString;
                }
                this.lstBonus.EndUpdate();
                this.cbSlotCount.Enabled = (this.mySet.Enhancements.Length > 1);
            }
            catch (Exception ex)
            {
            }
        }


        public void DisplayBonusText()
        {
            string str = RTF.StartRTF();
            int num = this.mySet.Bonus.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (this.mySet.Bonus[index].Index.Length > 0)
                {
                    str = str + RTF.Color(RTF.ElementID.Black) + RTF.Bold(Conversions.ToString(this.mySet.Bonus[index].Slotted) + " Enhancements: ");
                }
                int num2 = this.mySet.Bonus[index].Index.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (this.mySet.Bonus[index].Index[index2] > -1)
                    {
                        if (index2 > 0)
                        {
                            str += ", ";
                        }
                        str = str + RTF.Color(RTF.ElementID.InentionInvert) + DatabaseAPI.Database.Power[this.mySet.Bonus[index].Index[index2]].PowerName;
                    }
                }
                if (this.mySet.Bonus[index].Index.Length > 0)
                {
                    str = str + RTF.Crlf() + "   " + RTF.Italic(this.mySet.GetEffectString(index, false, false));
                }
                if (this.mySet.Bonus[index].PvMode == Enums.ePvX.PvP)
                {
                    str += "(PvP)";
                }
                if (this.mySet.Bonus[index].Index.Length > 0)
                {
                    str += RTF.Crlf();
                }
            }
            int num3 = this.mySet.SpecialBonus.Length - 1;
            for (int index = 0; index <= num3; index++)
            {
                if (this.mySet.SpecialBonus[index].Special > -1)
                {
                    str = str + RTF.Color(RTF.ElementID.Black) + RTF.Bold("Special Case Enhancement: ") + RTF.Color(RTF.ElementID.InentionInvert);
                    if (this.mySet.Enhancements[this.mySet.SpecialBonus[index].Special] > -1)
                    {
                        str += DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[this.mySet.SpecialBonus[index].Special]].Name;
                    }
                    str += RTF.Crlf();
                    int num4 = this.mySet.SpecialBonus[index].Index.Length - 1;
                    for (int index2 = 0; index2 <= num4; index2++)
                    {
                        if (this.mySet.SpecialBonus[index].Index[index2] > -1)
                        {
                            if (index2 > 0)
                            {
                                str += ", ";
                            }
                            str = str + RTF.Color(RTF.ElementID.InentionInvert) + DatabaseAPI.Database.Power[this.mySet.SpecialBonus[index].Index[index2]].PowerName;
                        }
                    }
                    str = string.Concat(new string[]
                    {
                        str,
                        RTF.Crlf(),
                        "   ",
                        RTF.Italic(this.mySet.GetEffectString(index, true, false)),
                        RTF.Crlf()
                    });
                }
                if (this.mySet.SpecialBonus[index].Index.Length > 0)
                {
                    str += RTF.Crlf();
                }
            }
            str += RTF.EndRTF();
            this.rtbBonus.Rtf = str;
        }


        private void DisplayIcon()
        {
            if (this.mySet.Image != "")
            {
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.mySet.Image);
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                extendedBitmap2.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), GraphicsUnit.Pixel);
                extendedBitmap2.Graphics.DrawImage(extendedBitmap.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, GraphicsUnit.Pixel);
                this.btnImage.Image = new Bitmap(extendedBitmap2.Bitmap);
                this.btnImage.Text = this.mySet.Image;
            }
            else
            {
                ExtendedBitmap extendedBitmap3 = new ExtendedBitmap(30, 30);
                extendedBitmap3.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap3.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), GraphicsUnit.Pixel);
                this.btnImage.Image = new Bitmap(extendedBitmap3.Bitmap);
                this.btnImage.Text = "Select Image";
            }
        }


        public void DisplaySetData()
        {
            this.DisplaySetIcons();
            this.DisplayIcon();
            this.txtNameFull.Text = this.mySet.DisplayName;
            this.txtNameShort.Text = this.mySet.ShortName;
            this.txtDesc.Text = this.mySet.Desc;
            this.txtInternal.Text = this.mySet.Uid;
            this.SetMinLevel(this.mySet.LevelMin + 1);
            this.SetMaxLevel(this.mySet.LevelMax + 1);
            this.udMaxLevel.Minimum = this.udMinLevel.Value;
            this.udMinLevel.Maximum = this.udMaxLevel.Value;
            this.cbSetType.SelectedIndex = (int)this.mySet.SetType;
            this.btnImage.Text = this.mySet.Image;
            this.DisplayBonusText();
            this.DisplayBonus();
        }


        public void DisplaySetIcons()
        {
            this.FillImageList();
            string[] items = new string[2];
            this.lvEnh.BeginUpdate();
            this.lvEnh.Items.Clear();
            this.FillImageList();
            int num = this.mySet.Enhancements.Length - 1;
            for (int imageIndex = 0; imageIndex <= num; imageIndex++)
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[imageIndex]];
                items[0] = enhancement.Name + " (" + enhancement.ShortName + ")";
                items[1] = "";
                int num2 = enhancement.ClassID.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    string[] strArray3;
                    int num3;
                    string[] strArray4;
                    IntPtr index2;
                    if (items[1] != "")
                    {
                        strArray3 = items;
                        num3 = 1;
                        (strArray4 = strArray3)[(int)(index2 = (IntPtr)num3)] = strArray4[(int)index2] + ",";
                    }
                    strArray3 = items;
                    num3 = 1;
                    (strArray4 = strArray3)[(int)(index2 = (IntPtr)num3)] = strArray4[(int)index2] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index]].ShortName;
                }
                this.lvEnh.Items.Add(new ListViewItem(items, imageIndex));
            }
            this.lvEnh.EndUpdate();
        }


        public void FillBonusCombos()
        {
            this.cbSlotCount.BeginUpdate();
            this.cbSlotCount.Items.Clear();
            int num = this.mySet.Enhancements.Length - 2;
            for (int index = 0; index <= num; index++)
            {
                this.cbSlotCount.Items.Add(Conversions.ToString(index + 2) + " Enhancements");
            }
            int num2 = this.mySet.Enhancements.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                this.cbSlotCount.Items.Add(DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[index]].Name);
            }
            if (this.cbSlotCount.Items.Count > 0)
            {
                this.cbSlotCount.SelectedIndex = 0;
            }
            this.cbSlotCount.EndUpdate();
        }


        public void FillBonusList()
        {
            this.lvBonusList.BeginUpdate();
            this.lvBonusList.Items.Clear();
            string[] items = new string[2];
            int num = this.SetBonusList.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                items[1] = "";
                if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects.Length > 0)
                {
                    items[1] = DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].BuildEffectStringShort(false, true, false);
                }
                items[0] = DatabaseAPI.Database.Power[this.SetBonusList[index]].PowerName;
                ListViewItem value = new ListViewItem(items)
                {
                    Tag = this.SetBonusList[index]
                };
                this.lvBonusList.Items.Add(value);
            }
            int num2 = this.SetBonusListPVP.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                items[1] = "";
                if (DatabaseAPI.Database.Power[this.SetBonusListPVP[index]].Effects.Length > 0)
                {
                    items[1] = DatabaseAPI.Database.Power[this.SetBonusListPVP[index]].Effects[0].BuildEffectStringShort(false, true, false);
                }
                items[0] = DatabaseAPI.Database.Power[this.SetBonusListPVP[index]].PowerName + " (PVP Only)";
                ListViewItem value2 = new ListViewItem(items)
                {
                    Tag = this.SetBonusListPVP[index]
                };
                this.lvBonusList.Items.Add(value2);
            }
            this.lvBonusList.Sort();
            this.lvBonusList.EndUpdate();
        }


        public void FillComboBoxes()
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            string[] names = Enum.GetNames(eSetType.GetType());
            this.cbSetType.BeginUpdate();
            this.cbSetType.Items.Clear();
            this.cbSetType.Items.AddRange(names);
            this.cbSetType.EndUpdate();
        }


        public void FillImageList()
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilEnh.ImageSize.Width, this.ilEnh.ImageSize.Height);
            this.ilEnh.Images.Clear();
            int num = this.mySet.Enhancements.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[index]];
                if (enhancement.ImageIdx > -1)
                {
                    Origin.Grade gfxGrade = I9Gfx.ToGfxGrade(enhancement.TypeID);
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancement(ref graphics, DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[index]].ImageIdx, gfxGrade);
                    this.ilEnh.Images.Add(extendedBitmap.Bitmap);
                }
                else
                {
                    this.ilEnh.Images.Add(new Bitmap(this.ilEnh.ImageSize.Width, this.ilEnh.ImageSize.Height));
                }
            }
        }


        private void frmSetEdit_Load(object sender, EventArgs e)
        {
            if (MidsContext.Config.MasterMode)
            {
                this.btnPaste.Visible = true;
            }
            this.SetBonusList = DatabaseAPI.NidPowers("set_bonus.set_bonus", "");
            this.SetBonusListPVP = DatabaseAPI.NidPowers("set_bonus.pvp_set_bonus", "");
            if (this.mySet.Bonus.Length < 1)
            {
                this.mySet.InitBonus();
            }
            this.FillComboBoxes();
            this.FillBonusCombos();
            this.FillBonusList();
            this.DisplaySetData();
            this.Loading = false;
            this.DisplayBonus();
        }


        public bool isBonus()
        {
            return this.cbSlotCount.SelectedIndex > -1 & this.cbSlotCount.SelectedIndex < this.mySet.Enhancements.Length - 1;
        }


        public bool isSpecial()
        {
            return this.cbSlotCount.SelectedIndex >= this.mySet.Enhancements.Length - 1 & this.cbSlotCount.SelectedIndex < this.mySet.Enhancements.Length + this.mySet.Enhancements.Length - 1;
        }


        private void lstBonus_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstBonus.SelectedIndex >= 0)
            {
                int selectedIndex = this.lstBonus.SelectedIndex;
                int[] numArray2 = new int[0];
                string[] strArray2 = new string[0];
                int index = 0;
                if (this.isBonus())
                {
                    numArray2 = new int[this.mySet.Bonus[this.BonusID()].Index.Length - 2 + 1];
                    strArray2 = new string[this.mySet.Bonus[this.BonusID()].Name.Length - 2 + 1];
                    int num = this.mySet.Bonus[this.BonusID()].Index.Length - 1;
                    for (int index2 = 0; index2 <= num; index2++)
                    {
                        if (index2 != selectedIndex)
                        {
                            numArray2[index] = this.mySet.Bonus[this.BonusID()].Index[index2];
                            strArray2[index] = this.mySet.Bonus[this.BonusID()].Name[index2];
                            index++;
                        }
                    }
                    this.mySet.Bonus[this.BonusID()].Name = new string[numArray2.Length - 1 + 1];
                    this.mySet.Bonus[this.BonusID()].Index = new int[strArray2.Length - 1 + 1];
                    int num2 = numArray2.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        this.mySet.Bonus[this.BonusID()].Index[index2] = numArray2[index2];
                        this.mySet.Bonus[this.BonusID()].Name[index2] = strArray2[index2];
                    }
                }
                else if (this.isSpecial())
                {
                    numArray2 = new int[this.mySet.SpecialBonus[this.SpecialID()].Index.Length - 2 + 1];
                    strArray2 = new string[this.mySet.SpecialBonus[this.SpecialID()].Name.Length - 2 + 1];
                    int num3 = this.mySet.SpecialBonus[this.SpecialID()].Index.Length - 1;
                    for (int index2 = 0; index2 <= num3; index2++)
                    {
                        if (index2 != selectedIndex)
                        {
                            numArray2[index] = this.mySet.SpecialBonus[this.SpecialID()].Index[index2];
                            strArray2[index] = this.mySet.SpecialBonus[this.SpecialID()].Name[index2];
                            index++;
                        }
                    }
                    this.mySet.SpecialBonus[this.SpecialID()].Name = new string[numArray2.Length - 1 + 1];
                    this.mySet.SpecialBonus[this.SpecialID()].Index = new int[strArray2.Length - 1 + 1];
                    int num4 = numArray2.Length - 1;
                    for (int index2 = 0; index2 <= num4; index2++)
                    {
                        this.mySet.SpecialBonus[this.SpecialID()].Index[index2] = numArray2[index2];
                        this.mySet.SpecialBonus[this.SpecialID()].Name[index2] = strArray2[index2];
                    }
                    if (this.mySet.SpecialBonus[this.SpecialID()].Index.Length < 1)
                    {
                        this.mySet.SpecialBonus[this.SpecialID()].Special = -1;
                    }
                }
                this.DisplayBonus();
                this.DisplayBonusText();
            }
        }


        private void lvBonusList_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvBonusList.SelectedIndices.Count >= 1)
            {
                int index = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvBonusList.SelectedItems[0].Tag)));
                if (index < 0)
                {
                    Interaction.MsgBox("Tag was < 0!", MsgBoxStyle.OkOnly, null);
                }
                else
                {
                    if (this.isBonus())
                    {
                        this.mySet.Bonus[this.BonusID()].Name = (string[])Utils.CopyArray(this.mySet.Bonus[this.BonusID()].Name, new string[this.mySet.Bonus[this.BonusID()].Name.Length + 1]);
                        this.mySet.Bonus[this.BonusID()].Index = (int[])Utils.CopyArray(this.mySet.Bonus[this.BonusID()].Index, new int[this.mySet.Bonus[this.BonusID()].Index.Length + 1]);
                        this.mySet.Bonus[this.BonusID()].Name[this.mySet.Bonus[this.BonusID()].Name.Length - 1] = DatabaseAPI.Database.Power[index].FullName;
                        this.mySet.Bonus[this.BonusID()].Index[this.mySet.Bonus[this.BonusID()].Index.Length - 1] = index;
                    }
                    else if (this.isSpecial())
                    {
                        this.mySet.SpecialBonus[this.SpecialID()].Special = this.SpecialID();
                        this.mySet.SpecialBonus[this.SpecialID()].Name = (string[])Utils.CopyArray(this.mySet.SpecialBonus[this.SpecialID()].Name, new string[this.mySet.SpecialBonus[this.SpecialID()].Name.Length + 1]);
                        this.mySet.SpecialBonus[this.SpecialID()].Index = (int[])Utils.CopyArray(this.mySet.SpecialBonus[this.SpecialID()].Index, new int[this.mySet.SpecialBonus[this.SpecialID()].Index.Length + 1]);
                        this.mySet.SpecialBonus[this.SpecialID()].Name[this.mySet.SpecialBonus[this.SpecialID()].Name.Length - 1] = DatabaseAPI.Database.Power[index].FullName;
                        this.mySet.SpecialBonus[this.SpecialID()].Index[this.mySet.SpecialBonus[this.SpecialID()].Index.Length - 1] = index;
                    }
                    this.DisplayBonus();
                    this.DisplayBonusText();
                }
            }
        }


        private void lvBonusList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        public void SetMaxLevel(int iValue)
        {
            if (decimal.Compare(new decimal(iValue), this.udMaxLevel.Minimum) < 0)
            {
                iValue = Convert.ToInt32(this.udMaxLevel.Minimum);
            }
            if (decimal.Compare(new decimal(iValue), this.udMaxLevel.Maximum) > 0)
            {
                iValue = Convert.ToInt32(this.udMaxLevel.Maximum);
            }
            this.udMaxLevel.Value = new decimal(iValue);
        }


        public void SetMinLevel(int iValue)
        {
            if (decimal.Compare(new decimal(iValue), this.udMinLevel.Minimum) < 0)
            {
                iValue = Convert.ToInt32(this.udMinLevel.Minimum);
            }
            if (decimal.Compare(new decimal(iValue), this.udMinLevel.Maximum) > 0)
            {
                iValue = Convert.ToInt32(this.udMinLevel.Maximum);
            }
            this.udMinLevel.Value = new decimal(iValue);
        }


        public int SpecialID()
        {
            return this.cbSlotCount.SelectedIndex - (this.mySet.Enhancements.Length - 1);
        }


        private void txtAlternate_TextChanged(object sender, EventArgs e)
        {
            if (this.isBonus())
            {
                this.mySet.Bonus[this.BonusID()].AltString = this.txtAlternate.Text;
            }
            else if (this.isSpecial())
            {
                this.mySet.SpecialBonus[this.SpecialID()].AltString = this.txtAlternate.Text;
            }
            this.DisplayBonusText();
        }


        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.Desc = this.txtDesc.Text;
            }
        }


        private void txtInternal_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.Uid = this.txtInternal.Text;
            }
        }


        private void txtNameFull_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.DisplayName = this.txtNameFull.Text;
            }
        }


        private void txtNameShort_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.ShortName = this.txtNameShort.Text;
            }
        }


        private void udMaxLevel_Leave(object sender, EventArgs e)
        {
            this.SetMaxLevel((int)Math.Round(Conversion.Val(this.udMaxLevel.Text)));
            this.mySet.LevelMax = Convert.ToInt32(decimal.Subtract(this.udMaxLevel.Value, 1m));
        }


        private void udMaxLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.LevelMax = Convert.ToInt32(decimal.Subtract(this.udMaxLevel.Value, 1m));
                this.udMinLevel.Maximum = this.udMaxLevel.Value;
            }
        }


        private void udMinLevel_Leave(object sender, EventArgs e)
        {
            this.SetMinLevel((int)Math.Round(Conversion.Val(this.udMinLevel.Text)));
            this.mySet.LevelMin = Convert.ToInt32(decimal.Subtract(this.udMinLevel.Value, 1m));
        }


        private void udMinLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.mySet.LevelMin = Convert.ToInt32(decimal.Subtract(this.udMinLevel.Value, 1m));
                this.udMaxLevel.Minimum = this.udMinLevel.Value;
            }
        }


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnImage")]
        private Button _btnImage;


        [AccessedThroughProperty("btnNoImage")]
        private Button _btnNoImage;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("btnPaste")]
        private Button _btnPaste;


        [AccessedThroughProperty("cbSetType")]
        private ComboBox _cbSetType;


        [AccessedThroughProperty("cbSlotCount")]
        private ComboBox _cbSlotCount;


        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("gbBasic")]
        private GroupBox _gbBasic;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;


        [AccessedThroughProperty("ilEnh")]
        private ImageList _ilEnh;


        [AccessedThroughProperty("ImagePicker")]
        private OpenFileDialog _ImagePicker;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label16")]
        private Label _Label16;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("Label27")]
        private Label _Label27;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("Label5")]
        private Label _Label5;


        [AccessedThroughProperty("Label6")]
        private Label _Label6;


        [AccessedThroughProperty("Label7")]
        private Label _Label7;


        [AccessedThroughProperty("lstBonus")]
        private ListBox _lstBonus;


        [AccessedThroughProperty("lvBonusList")]
        private ListView _lvBonusList;


        [AccessedThroughProperty("lvEnh")]
        private ListView _lvEnh;


        [AccessedThroughProperty("rbIfAny")]
        private RadioButton _rbIfAny;


        [AccessedThroughProperty("rbIfCritter")]
        private RadioButton _rbIfCritter;


        [AccessedThroughProperty("rbIfPlayer")]
        private RadioButton _rbIfPlayer;


        [AccessedThroughProperty("rtbBonus")]
        private RichTextBox _rtbBonus;


        [AccessedThroughProperty("txtAlternate")]
        private TextBox _txtAlternate;


        [AccessedThroughProperty("txtDesc")]
        private TextBox _txtDesc;


        [AccessedThroughProperty("txtInternal")]
        private TextBox _txtInternal;


        [AccessedThroughProperty("txtNameFull")]
        private TextBox _txtNameFull;


        [AccessedThroughProperty("txtNameShort")]
        private TextBox _txtNameShort;


        [AccessedThroughProperty("udMaxLevel")]
        private NumericUpDown _udMaxLevel;


        [AccessedThroughProperty("udMinLevel")]
        private NumericUpDown _udMinLevel;


        protected bool Loading;


        public EnhancementSet mySet;


        protected int[] SetBonusList;


        protected int[] SetBonusListPVP;
    }
}
