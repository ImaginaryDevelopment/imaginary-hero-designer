using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
    // Token: 0x02000024 RID: 36
    public partial class frmCompare : Form
    {
        // Token: 0x17000116 RID: 278
        // (get) Token: 0x06000381 RID: 897 RVA: 0x000300C8 File Offset: 0x0002E2C8
        // (set) Token: 0x06000382 RID: 898 RVA: 0x000300E0 File Offset: 0x0002E2E0
        internal virtual ImageButton btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClose_Load);
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_ButtonClicked);
                if (this._btnClose != null)
                {
                    this._btnClose.Load -= eventHandler;
                    this._btnClose.ButtonClicked -= clickedEventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.Load += eventHandler;
                    this._btnClose.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000117 RID: 279
        // (get) Token: 0x06000383 RID: 899 RVA: 0x00030164 File Offset: 0x0002E364
        // (set) Token: 0x06000384 RID: 900 RVA: 0x0003017C File Offset: 0x0002E37C
        internal virtual Button btnTweakMatch
        {
            get
            {
                return this._btnTweakMatch;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnTweakMatch_Click);
                if (this._btnTweakMatch != null)
                {
                    this._btnTweakMatch.Click -= eventHandler;
                }
                this._btnTweakMatch = value;
                if (this._btnTweakMatch != null)
                {
                    this._btnTweakMatch.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000118 RID: 280
        // (get) Token: 0x06000385 RID: 901 RVA: 0x000301D8 File Offset: 0x0002E3D8
        // (set) Token: 0x06000386 RID: 902 RVA: 0x000301F0 File Offset: 0x0002E3F0
        internal virtual ComboBox cbAT1
        {
            get
            {
                return this._cbAT1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAT1_SelectedIndexChanged);
                if (this._cbAT1 != null)
                {
                    this._cbAT1.SelectedIndexChanged -= eventHandler;
                }
                this._cbAT1 = value;
                if (this._cbAT1 != null)
                {
                    this._cbAT1.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000119 RID: 281
        // (get) Token: 0x06000387 RID: 903 RVA: 0x0003024C File Offset: 0x0002E44C
        // (set) Token: 0x06000388 RID: 904 RVA: 0x00030264 File Offset: 0x0002E464
        internal virtual ComboBox cbAT2
        {
            get
            {
                return this._cbAT2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAT2_SelectedIndexChanged);
                if (this._cbAT2 != null)
                {
                    this._cbAT2.SelectedIndexChanged -= eventHandler;
                }
                this._cbAT2 = value;
                if (this._cbAT2 != null)
                {
                    this._cbAT2.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700011A RID: 282
        // (get) Token: 0x06000389 RID: 905 RVA: 0x000302C0 File Offset: 0x0002E4C0
        // (set) Token: 0x0600038A RID: 906 RVA: 0x000302D8 File Offset: 0x0002E4D8
        internal virtual ComboBox cbSet1
        {
            get
            {
                return this._cbSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSet1_SelectedIndexChanged);
                if (this._cbSet1 != null)
                {
                    this._cbSet1.SelectedIndexChanged -= eventHandler;
                }
                this._cbSet1 = value;
                if (this._cbSet1 != null)
                {
                    this._cbSet1.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700011B RID: 283
        // (get) Token: 0x0600038B RID: 907 RVA: 0x00030334 File Offset: 0x0002E534
        // (set) Token: 0x0600038C RID: 908 RVA: 0x0003034C File Offset: 0x0002E54C
        internal virtual ComboBox cbSet2
        {
            get
            {
                return this._cbSet2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSet2_SelectedIndexChanged);
                if (this._cbSet2 != null)
                {
                    this._cbSet2.SelectedIndexChanged -= eventHandler;
                }
                this._cbSet2 = value;
                if (this._cbSet2 != null)
                {
                    this._cbSet2.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700011C RID: 284
        // (get) Token: 0x0600038D RID: 909 RVA: 0x000303A8 File Offset: 0x0002E5A8
        // (set) Token: 0x0600038E RID: 910 RVA: 0x000303C0 File Offset: 0x0002E5C0
        internal virtual ComboBox cbType1
        {
            get
            {
                return this._cbType1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbType1_SelectedIndexChanged);
                if (this._cbType1 != null)
                {
                    this._cbType1.SelectedIndexChanged -= eventHandler;
                }
                this._cbType1 = value;
                if (this._cbType1 != null)
                {
                    this._cbType1.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700011D RID: 285
        // (get) Token: 0x0600038F RID: 911 RVA: 0x0003041C File Offset: 0x0002E61C
        // (set) Token: 0x06000390 RID: 912 RVA: 0x00030434 File Offset: 0x0002E634
        internal virtual ComboBox cbType2
        {
            get
            {
                return this._cbType2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbType2_SelectedIndexChanged);
                if (this._cbType2 != null)
                {
                    this._cbType2.SelectedIndexChanged -= eventHandler;
                }
                this._cbType2 = value;
                if (this._cbType2 != null)
                {
                    this._cbType2.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700011E RID: 286
        // (get) Token: 0x06000391 RID: 913 RVA: 0x00030490 File Offset: 0x0002E690
        // (set) Token: 0x06000392 RID: 914 RVA: 0x000304A8 File Offset: 0x0002E6A8
        internal virtual CheckBox chkMatching
        {
            get
            {
                return this._chkMatching;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkMatching_CheckedChanged);
                if (this._chkMatching != null)
                {
                    this._chkMatching.CheckedChanged -= eventHandler;
                }
                this._chkMatching = value;
                if (this._chkMatching != null)
                {
                    this._chkMatching.CheckedChanged += eventHandler;
                }
            }
        }

        // Token: 0x1700011F RID: 287
        // (get) Token: 0x06000393 RID: 915 RVA: 0x00030504 File Offset: 0x0002E704
        // (set) Token: 0x06000394 RID: 916 RVA: 0x0003051C File Offset: 0x0002E71C
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

        // Token: 0x17000120 RID: 288
        // (get) Token: 0x06000395 RID: 917 RVA: 0x00030578 File Offset: 0x0002E778
        // (set) Token: 0x06000396 RID: 918 RVA: 0x00030590 File Offset: 0x0002E790
        internal virtual ctlMultiGraph Graph
        {
            get
            {
                return this._Graph;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Graph_Load);
                if (this._Graph != null)
                {
                    this._Graph.Load -= eventHandler;
                }
                this._Graph = value;
                if (this._Graph != null)
                {
                    this._Graph.Load += eventHandler;
                }
            }
        }

        // Token: 0x17000121 RID: 289
        // (get) Token: 0x06000397 RID: 919 RVA: 0x000305EC File Offset: 0x0002E7EC
        // (set) Token: 0x06000398 RID: 920 RVA: 0x00030604 File Offset: 0x0002E804
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }

        // Token: 0x17000122 RID: 290
        // (get) Token: 0x06000399 RID: 921 RVA: 0x00030610 File Offset: 0x0002E810
        // (set) Token: 0x0600039A RID: 922 RVA: 0x00030628 File Offset: 0x0002E828
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

        // Token: 0x17000123 RID: 291
        // (get) Token: 0x0600039B RID: 923 RVA: 0x00030634 File Offset: 0x0002E834
        // (set) Token: 0x0600039C RID: 924 RVA: 0x0003064C File Offset: 0x0002E84C
        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }

        // Token: 0x17000124 RID: 292
        // (get) Token: 0x0600039D RID: 925 RVA: 0x00030658 File Offset: 0x0002E858
        // (set) Token: 0x0600039E RID: 926 RVA: 0x00030670 File Offset: 0x0002E870
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

        // Token: 0x17000125 RID: 293
        // (get) Token: 0x0600039F RID: 927 RVA: 0x0003067C File Offset: 0x0002E87C
        // (set) Token: 0x060003A0 RID: 928 RVA: 0x00030694 File Offset: 0x0002E894
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

        // Token: 0x17000126 RID: 294
        // (get) Token: 0x060003A1 RID: 929 RVA: 0x000306A0 File Offset: 0x0002E8A0
        // (set) Token: 0x060003A2 RID: 930 RVA: 0x000306B8 File Offset: 0x0002E8B8
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

        // Token: 0x17000127 RID: 295
        // (get) Token: 0x060003A3 RID: 931 RVA: 0x000306C4 File Offset: 0x0002E8C4
        // (set) Token: 0x060003A4 RID: 932 RVA: 0x000306DC File Offset: 0x0002E8DC
        internal virtual ListBox lstDisplay
        {
            get
            {
                return this._lstDisplay;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstDisplay_SelectedIndexChanged);
                if (this._lstDisplay != null)
                {
                    this._lstDisplay.SelectedIndexChanged -= eventHandler;
                }
                this._lstDisplay = value;
                if (this._lstDisplay != null)
                {
                    this._lstDisplay.SelectedIndexChanged += eventHandler;
                }
            }
        }

        // Token: 0x17000128 RID: 296
        // (get) Token: 0x060003A5 RID: 933 RVA: 0x00030738 File Offset: 0x0002E938
        // (set) Token: 0x060003A6 RID: 934 RVA: 0x00030750 File Offset: 0x0002E950
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

        // Token: 0x17000129 RID: 297
        // (get) Token: 0x060003A7 RID: 935 RVA: 0x000307AC File Offset: 0x0002E9AC
        // (set) Token: 0x060003A8 RID: 936 RVA: 0x000307C4 File Offset: 0x0002E9C4
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

        // Token: 0x060003A9 RID: 937 RVA: 0x000307D0 File Offset: 0x0002E9D0
        public frmCompare(ref frmMain iFrm)
        {
            base.Load += this.frmCompare_Load;
            base.KeyDown += this.frmCompare_KeyDown;
            base.VisibleChanged += this.frmCompare_VisibleChanged;
            base.Resize += this.frmCompare_Resize;
            base.Move += this.frmCompare_Move;
            base.FormClosed += this.frmCompare_FormClosed;
            this.Powers = new IPower[2][];
            this.Values = new float[2][];
            this.Tips = new string[2][];
            this.GraphMax = 1f;
            this.Matching = false;
            this.Loaded = false;
            this.DisplayValueStrings = new string[]
            {
                "Base Accuracy",
                "Damage",
                "Damage / Anim",
                "Damage / Sec",
                "Damage / End",
                "Damage Buff",
                "Defense",
                "Defense Debuff",
                "Duration",
                "End Use",
                "End Use / Sec",
                "Healing",
                "Healing / Sec",
                "Healing / End",
                "+HP",
                "Max Targets",
                "Range",
                "Recharge Time",
                "Regeneration",
                "Resistance",
                "Resistance Debuff",
                "ToHit Buff",
                "ToHit Debuff"
            };
            this.InitializeComponent();
            this.myParent = iFrm;
        }

        // Token: 0x060003AA RID: 938 RVA: 0x00030979 File Offset: 0x0002EB79
        private void btnClose_ButtonClicked()
        {
            base.Close();
        }

        // Token: 0x060003AB RID: 939 RVA: 0x00030983 File Offset: 0x0002EB83
        private void btnClose_Load(object sender, EventArgs e)
        {
        }

        // Token: 0x060003AC RID: 940 RVA: 0x00030986 File Offset: 0x0002EB86
        private void btnTweakMatch_Click(object sender, EventArgs e)
        {
            new frmTweakMatching().ShowDialog(this);
            this.DisplayGraph();
        }

        // Token: 0x060003AD RID: 941 RVA: 0x0003099C File Offset: 0x0002EB9C
        private void cbAT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(0);
            }
        }

        // Token: 0x060003AE RID: 942 RVA: 0x000309C4 File Offset: 0x0002EBC4
        private void cbAT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(1);
            }
        }

        // Token: 0x060003AF RID: 943 RVA: 0x000309EC File Offset: 0x0002EBEC
        private void cbSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }

        // Token: 0x060003B0 RID: 944 RVA: 0x00030A18 File Offset: 0x0002EC18
        private void cbSet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }

        // Token: 0x060003B1 RID: 945 RVA: 0x00030A44 File Offset: 0x0002EC44
        private void cbType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(0);
            }
        }

        // Token: 0x060003B2 RID: 946 RVA: 0x00030A6C File Offset: 0x0002EC6C
        private void cbType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(1);
            }
        }

        // Token: 0x060003B3 RID: 947 RVA: 0x00030A94 File Offset: 0x0002EC94
        private void chkMatching_CheckedChanged(object sender, EventArgs e)
        {
            this.Matching = this.chkMatching.Checked;
            if (this.Loaded)
            {
                this.DisplayGraph();
            }
        }

        // Token: 0x060003B4 RID: 948 RVA: 0x00030AC9 File Offset: 0x0002ECC9
        private void chkOnTop_CheckedChanged()
        {
            base.TopMost = this.chkOnTop.Checked;
        }

        // Token: 0x060003B5 RID: 949 RVA: 0x00030AE0 File Offset: 0x0002ECE0
        public void DisplayGraph()
        {
            if (this.lstDisplay.SelectedIndex >= 0)
            {
                this.Graph.BeginUpdate();
                this.Graph.Clear();
                this.GetPowers();
                if (this.Matching)
                {
                    this.map_Advanced();
                }
                else
                {
                    this.map_Simple();
                }
                switch (this.lstDisplay.SelectedIndex)
                {
                    case 0:
                        this.Graph.ColorFadeEnd = Color.FromArgb(255, 255, 0);
                        this.values_Accuracy();
                        break;
                    case 1:
                        this.Graph.ColorFadeEnd = Color.Red;
                        this.values_Damage();
                        break;
                    case 2:
                        this.Graph.ColorFadeEnd = Color.Red;
                        this.values_DPA();
                        break;
                    case 3:
                        this.Graph.ColorFadeEnd = Color.Red;
                        this.values_DPS();
                        break;
                    case 4:
                        this.Graph.ColorFadeEnd = Color.Red;
                        this.values_DPE();
                        break;
                    case 5:
                        this.Graph.ColorFadeEnd = Color.FromArgb(192, 0, 0);
                        this.Values_Universal(Enums.eEffectType.DamageBuff, false, false);
                        break;
                    case 6:
                        this.Graph.ColorFadeEnd = Color.FromArgb(192, 0, 192);
                        this.Values_Universal(Enums.eEffectType.Defense, false, false);
                        break;
                    case 7:
                        this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, 128);
                        this.Values_Universal(Enums.eEffectType.Defense, false, true);
                        break;
                    case 8:
                        this.Graph.ColorFadeEnd = Color.FromArgb(128, 0, 255);
                        this.values_Duration();
                        break;
                    case 9:
                        this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 255);
                        this.values_End();
                        break;
                    case 10:
                        this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 255);
                        this.values_EPS();
                        break;
                    case 11:
                        this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                        this.values_Heal();
                        break;
                    case 12:
                        this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                        this.values_HPS();
                        break;
                    case 13:
                        this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                        this.values_HPE();
                        break;
                    case 14:
                        this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                        this.Values_Universal(Enums.eEffectType.HitPoints, true, false);
                        break;
                    case 15:
                        this.Graph.ColorFadeEnd = Color.FromArgb(64, 128, 128);
                        this.values_MaxTargets();
                        break;
                    case 16:
                        this.Graph.ColorFadeEnd = Color.FromArgb(96, 128, 96);
                        this.values_Range();
                        break;
                    case 17:
                        this.Graph.ColorFadeEnd = Color.FromArgb(255, 192, 128);
                        this.values_Recharge();
                        break;
                    case 18:
                        this.Graph.ColorFadeEnd = Color.FromArgb(96, 255, 96);
                        this.Values_Universal(Enums.eEffectType.Regeneration, true, false);
                        break;
                    case 19:
                        this.Graph.ColorFadeEnd = Color.FromArgb(0, 192, 192);
                        this.Values_Universal(Enums.eEffectType.Resistance, false, false);
                        break;
                    case 20:
                        this.Graph.ColorFadeEnd = Color.FromArgb(0, 128, 128);
                        this.Values_Universal(Enums.eEffectType.Resistance, false, true);
                        break;
                    case 21:
                        this.Graph.ColorFadeEnd = Color.FromArgb(255, 255, 96);
                        this.Values_Universal(Enums.eEffectType.ToHit, true, false);
                        break;
                    case 22:
                        this.Graph.ColorFadeEnd = Color.FromArgb(192, 192, 64);
                        this.Values_Universal(Enums.eEffectType.ToHit, true, true);
                        break;
                }
                int index = 0;
                do
                {
                    string[] strArray = new string[]
                    {
                        "",
                        ""
                    };
                    float[] array = new float[2];
                    float[] numArray = array;
                    string iTip = "";
                    int index2 = 0;
                    do
                    {
                        if (this.Map.Map[index, index2] > -1)
                        {
                            strArray[index2] = this.Powers[index2][this.Map.Map[index, index2]].DisplayName;
                            numArray[index2] = this.Values[index2][this.Map.Map[index, index2]];
                            if (iTip != "" & this.Tips[index2][this.Map.Map[index, index2]] != "")
                            {
                                iTip += "\r\n----------\r\n";
                            }
                            iTip += this.Tips[index2][this.Map.Map[index, index2]];
                        }
                        index2++;
                    }
                    while (index2 <= 1);
                    this.Graph.AddItemPair(strArray[0], strArray[1], numArray[0], numArray[1], iTip);
                    index++;
                }
                while (index <= 20);
                this.Graph.Max = this.GraphMax;
                this.tbScaleX.Value = this.Graph.ScaleIndex;
                this.SetScaleLabel();
                this.Graph.EndUpdate();
            }
        }

        // Token: 0x060003B7 RID: 951 RVA: 0x0003110C File Offset: 0x0002F30C
        protected void FillDisplayList()
        {
            ListBox lstDisplay = this.lstDisplay;
            lstDisplay.BeginUpdate();
            lstDisplay.Items.Clear();
            lstDisplay.Items.AddRange(this.DisplayValueStrings);
            this.lstDisplay.SelectedIndex = 0;
            lstDisplay.EndUpdate();
        }

        // Token: 0x060003B8 RID: 952 RVA: 0x0003115A File Offset: 0x0002F35A
        private void frmCompare_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.FloatCompareGraph(false);
        }

        // Token: 0x060003B9 RID: 953 RVA: 0x0003116C File Offset: 0x0002F36C
        private void frmCompare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.Shift & e.KeyCode == Keys.T)
            {
                this.btnTweakMatch.Visible = true;
            }
        }

        // Token: 0x060003BA RID: 954 RVA: 0x000311A8 File Offset: 0x0002F3A8
        private void frmCompare_Load(object sender, EventArgs e)
        {
            this.FillDisplayList();
            this.UpdateData();
            this.list_AT();
            if (MidsContext.Character.Archetype.Idx > -1)
            {
                this.cbAT1.SelectedIndex = MidsContext.Character.Archetype.Idx;
            }
            if (MidsContext.Character.Archetype.Idx > -1)
            {
                this.cbAT2.SelectedIndex = MidsContext.Character.Archetype.Idx;
            }
            this.tbScaleX.Minimum = 0;
            this.tbScaleX.Maximum = this.Graph.ScaleCount - 1;
            this.list_Type();
            this.List_Sets(0);
            this.List_Sets(1);
            this.Map.Init();
            this.chkMatching.Checked = this.Matching;
            this.Loaded = true;
            this.DisplayGraph();
            this.tTip.SetToolTip(this.chkMatching, "Re-order powers so that similar powers are compared directly, regardless of their position in the set.\r\nFor example, moving snipe powers to directly compare.\r\n(This isn't known for its stunning accuracy, and gets confused by vastly different sets)");
        }

        // Token: 0x060003BB RID: 955 RVA: 0x000312B7 File Offset: 0x0002F4B7
        private void frmCompare_Move(object sender, EventArgs e)
        {
            this.StoreLocation();
        }

        // Token: 0x060003BC RID: 956 RVA: 0x000312C1 File Offset: 0x0002F4C1
        private void frmCompare_Resize(object sender, EventArgs e)
        {
            this.StoreLocation();
        }

        // Token: 0x060003BD RID: 957 RVA: 0x000312CB File Offset: 0x0002F4CB
        private void frmCompare_VisibleChanged(object sender, EventArgs e)
        {
            this.Graph.BackColor = this.BackColor;
        }

        // Token: 0x060003BE RID: 958 RVA: 0x000312E0 File Offset: 0x0002F4E0
        public int getAT(int Index)
        {
            int num;
            if (Index == 0)
            {
                num = this.cbAT1.SelectedIndex;
            }
            else if (Index == 1)
            {
                num = this.cbAT2.SelectedIndex;
            }
            else
            {
                num = 0;
            }
            return num;
        }

        // Token: 0x060003BF RID: 959 RVA: 0x00031330 File Offset: 0x0002F530
        public int getMax(int iVal1, int ival2)
        {
            int result;
            if (iVal1 > ival2)
            {
                result = iVal1;
            }
            else
            {
                result = ival2;
            }
            return result;
        }

        // Token: 0x060003C0 RID: 960 RVA: 0x00031358 File Offset: 0x0002F558
        public int GetNextFreeSlot()
        {
            int index = 0;
            while (this.Map.Map[index, 1] != -1)
            {
                index++;
                if (index > 20)
                {
                    return 20;
                }
            }
            return index;
        }

        // Token: 0x060003C1 RID: 961 RVA: 0x000313A8 File Offset: 0x0002F5A8
        public void GetPowers()
        {
            int[] numArray = new int[2];
            int Index = 0;
            do
            {
                numArray[Index] = this.getSetIndex(Index);
                this.Powers[Index] = new IPower[DatabaseAPI.Database.Powersets[numArray[Index]].Powers.Length - 1 + 1];
                this.Values[Index] = new float[this.Powers[Index].Length + 1];
                this.Tips[Index] = new string[this.Powers[Index].Length + 1];
                int nIDClass;
                if (Index == 0)
                {
                    nIDClass = this.cbAT1.SelectedIndex;
                }
                else
                {
                    nIDClass = this.cbAT2.SelectedIndex;
                }
                int num = this.Powers[Index].Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.Powers[Index][index] = new Power(DatabaseAPI.Database.Powersets[numArray[Index]].Powers[index]);
                    this.Powers[Index][index].AbsorbPetEffects(-1);
                    this.Powers[Index][index].ApplyGrantPowerEffects();
                    if (nIDClass > -1)
                    {
                        this.Powers[Index][index].ForcedClassID = nIDClass;
                        this.Powers[Index][index].ForcedClass = DatabaseAPI.UidFromNidClass(nIDClass);
                    }
                }
                Index++;
            }
            while (Index <= 1);
        }

        // Token: 0x060003C2 RID: 962 RVA: 0x00031514 File Offset: 0x0002F714
        public int getSetIndex(int Index)
        {
            ComboBox comboBox;
            if (Index == 0)
            {
                comboBox = this.cbSet1;
            }
            else
            {
                if (Index != 1)
                {
                    return 0;
                }
                comboBox = this.cbSet2;
            }
            return DatabaseAPI.GetPowersetIndexes(this.getAT(Index), this.getSetType(Index))[comboBox.SelectedIndex].nID;
        }

        // Token: 0x060003C3 RID: 963 RVA: 0x00031578 File Offset: 0x0002F778
        public Enums.ePowerSetType getSetType(int Index)
        {
            ComboBox comboBox;
            if (Index == 0)
            {
                comboBox = this.cbType1;
            }
            else
            {
                if (Index != 1)
                {
                    return Enums.ePowerSetType.Primary;
                }
                comboBox = this.cbType2;
            }
            Enums.ePowerSetType ePowerSetType;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    ePowerSetType = Enums.ePowerSetType.Primary;
                    break;
                case 1:
                    ePowerSetType = Enums.ePowerSetType.Secondary;
                    break;
                case 2:
                    ePowerSetType = Enums.ePowerSetType.Ancillary;
                    break;
                default:
                    ePowerSetType = Enums.ePowerSetType.Primary;
                    break;
            }
            return ePowerSetType;
        }

        // Token: 0x060003C4 RID: 964 RVA: 0x000315E8 File Offset: 0x0002F7E8
        public string GetUniversalTipString(Enums.ShortFX iSFX, ref IPower iPower)
        {
            string str = "";
            string str3;
            if (iSFX.Present)
            {
                string returnString = "";
                int[] returnMask = new int[0];
                string str2 = "";
                IPower power = new Power(iPower);
                int num = iSFX.Index.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (iSFX.Index[index] != -1 && power.Effects[iSFX.Index[index]].EffectType != Enums.eEffectType.None)
                    {
                        returnString = "";
                        returnMask = new int[0];
                        power.GetEffectStringGrouped(iSFX.Index[index], ref returnString, ref returnMask, false, false, false);
                        if (returnMask.Length > 0)
                        {
                            if (str2 != "")
                            {
                                str2 += "\r\n  ";
                            }
                            str2 += returnString.Replace("\r\n", "\r\n  ");
                            int num2 = returnMask.Length - 1;
                            for (int index2 = 0; index2 <= num2; index2++)
                            {
                                power.Effects[returnMask[index2]].EffectType = Enums.eEffectType.None;
                            }
                        }
                    }
                }
                int num3 = iSFX.Index.Length - 1;
                for (int index = 0; index <= num3; index++)
                {
                    if (power.Effects[iSFX.Index[index]].EffectType != Enums.eEffectType.None)
                    {
                        if (str2 != "")
                        {
                            str2 += "\r\n  ";
                        }
                        str2 += power.Effects[iSFX.Index[index]].BuildEffectString(false, "", false, false, false).Replace("\r\n", "\r\n  ");
                    }
                }
                str3 = str + str2;
            }
            else
            {
                str3 = "";
            }
            return str3;
        }

        // Token: 0x060003C5 RID: 965 RVA: 0x00031806 File Offset: 0x0002FA06
        private void Graph_Load(object sender, EventArgs e)
        {
        }

        // Token: 0x060003C7 RID: 967 RVA: 0x0003275C File Offset: 0x0003095C
        private void list_AT()
        {
            this.cbAT1.BeginUpdate();
            this.cbAT1.Items.Clear();
            this.cbAT2.BeginUpdate();
            this.cbAT2.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (DatabaseAPI.Database.Classes[index].Playable)
                {
                    this.cbAT1.Items.Add(DatabaseAPI.Database.Classes[index].DisplayName);
                    this.cbAT2.Items.Add(DatabaseAPI.Database.Classes[index].DisplayName);
                }
            }
            this.cbAT1.SelectedIndex = MidsContext.Character.Archetype.Idx;
            this.cbAT2.SelectedIndex = MidsContext.Character.Archetype.Idx;
            this.cbAT1.EndUpdate();
            this.cbAT2.EndUpdate();
        }

        // Token: 0x060003C8 RID: 968 RVA: 0x00032874 File Offset: 0x00030A74
        public void List_Sets(int Index)
        {
            Enums.ePowerSetType iSet = Enums.ePowerSetType.None;
            ComboBox comboBox;
            ComboBox comboBox2;
            int selectedIndex;
            if (Index == 0)
            {
                comboBox = this.cbSet1;
                comboBox2 = this.cbType1;
                selectedIndex = this.cbAT1.SelectedIndex;
            }
            else
            {
                comboBox = this.cbSet2;
                comboBox2 = this.cbType2;
                selectedIndex = this.cbAT2.SelectedIndex;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    iSet = Enums.ePowerSetType.Primary;
                    break;
                case 1:
                    iSet = Enums.ePowerSetType.Secondary;
                    break;
                case 2:
                    iSet = Enums.ePowerSetType.Ancillary;
                    break;
            }
            comboBox.BeginUpdate();
            comboBox.Items.Clear();
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(selectedIndex, iSet);
            int num = powersetIndexes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                comboBox.Items.Add(powersetIndexes[index].DisplayName);
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            comboBox.EndUpdate();
        }

        // Token: 0x060003C9 RID: 969 RVA: 0x00032974 File Offset: 0x00030B74
        public void list_Type()
        {
            this.cbType1.BeginUpdate();
            this.cbType1.Items.Clear();
            this.cbType2.BeginUpdate();
            this.cbType2.Items.Clear();
            this.cbType1.Items.Add("Primary");
            this.cbType1.Items.Add("Secondary");
            this.cbType1.Items.Add("Ancillary");
            this.cbType2.Items.Add("Primary");
            this.cbType2.Items.Add("Secondary");
            this.cbType2.Items.Add("Ancillary");
            this.cbType1.SelectedIndex = 0;
            this.cbType2.SelectedIndex = 0;
            this.cbType1.EndUpdate();
            this.cbType2.EndUpdate();
        }

        // Token: 0x060003CA RID: 970 RVA: 0x00032A74 File Offset: 0x00030C74
        private void lstDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }

        // Token: 0x060003CB RID: 971 RVA: 0x00032AA0 File Offset: 0x00030CA0
        public void map_Advanced()
        {
            bool[] Placed = new bool[this.Powers[1].Length - 1 + 1];
            int num = Placed.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                Placed[index] = false;
            }
            this.Map.Init();
            int num2 = this.getMax(this.Powers[0].Length, this.Powers[1].Length);
            if (num2 > 20)
            {
                num2 = 20;
            }
            int num3 = num2;
            for (int index = 0; index <= num3; index++)
            {
                if (this.Powers[0].Length > index)
                {
                    this.Map.Map[index, 0] = index;
                }
            }
            int num4 = this.Powers[1].Length - 1;
            for (int index = 0; index <= num4; index++)
            {
                string displayName = this.Powers[1][index].DisplayName;
                int num5 = this.Powers[0].Length - 1;
                for (int index2 = 0; index2 <= num5; index2++)
                {
                    if (string.Equals(this.Powers[0][index2].DisplayName, displayName, StringComparison.OrdinalIgnoreCase) & !Placed[index])
                    {
                        this.Map.Map[index2, 1] = index;
                        Placed[index] = true;
                        break;
                    }
                }
            }
            this.mapOverride();
            string[] iStrings = new string[]
            {
                "summon"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def",
                "smash"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def",
                "energy"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def",
                "fire"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def",
                "ranged"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def",
                "melee"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def",
                "aoe"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def",
                "smash"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def",
                "energy"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def",
                "fire"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def",
                "ranged"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def",
                "melee"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def",
                "aoe"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+res",
                "smash"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+res",
                "energy"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+res",
                "fire"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+res",
                "smash"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+res",
                "energy"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+res",
                "fire"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+def"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "+res"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+def"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "auto",
                "+res"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "disorient"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "stun"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "hold"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "sleep"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "immobilize"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "confuse"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "fear"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "disorient"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "stun"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "hold"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "sleep"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "immobilize"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "confuse"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "fear"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "snipe"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "Extreme",
                "Self -Recovery"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "close",
                "high"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "disorient",
                "minor"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "hold"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "cone",
                "extreme"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "cone",
                "superior"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "cone",
                "high"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "cone",
                "moderate"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "cone",
                "minor"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "AoE",
                "extreme"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "AoE",
                "superior"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "AoE",
                "high"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "AoE",
                "moderate"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged",
                "AoE",
                "minor"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "extreme"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "superior"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "high"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "moderate"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "minor"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "extreme"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "superior"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "high"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "moderate"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "minor"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "disorient"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "stun"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee",
                "hold"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "knockback"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "knockup"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "knockback"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "Cone",
                "knockup"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "AoE",
                "stealth"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "stealth"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "-def"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "-res"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "-acc"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "toggle",
                "-dmg"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "-def"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "-res"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "-acc"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "-dmg"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "+dmg"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "+acc"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "heal",
                "team"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "heal",
                "ally"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "heal"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "+recovery"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "-recovery"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "-regen"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "extreme"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "superior"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "high"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "moderate"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "minor"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "disorient"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "stun"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "hold"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "sleep"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "immobilize"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "confuse"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "fear"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "cone"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "aoe"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "melee"
            };
            this.mapDescString(iStrings, ref Placed);
            iStrings = new string[]
            {
                "ranged"
            };
            this.mapDescString(iStrings, ref Placed);
            int num6 = this.Powers[1].Length - 1;
            for (int index = 0; index <= num6; index++)
            {
                if (!Placed[index] && this.Map.Map[index, 1] == -1)
                {
                    this.Map.Map[index, 1] = index;
                    Placed[index] = true;
                }
            }
            int num7 = this.Powers[1].Length - 1;
            for (int index = 0; index <= num7; index++)
            {
                if (!Placed[index])
                {
                    int nextFreeSlot = this.GetNextFreeSlot();
                    this.Map.Map[nextFreeSlot, 1] = index;
                    Placed[index] = true;
                }
            }
        }

        // Token: 0x060003CC RID: 972 RVA: 0x00033D28 File Offset: 0x00031F28
        public void map_Simple()
        {
            this.Map.Init();
            int index = 0;
            do
            {
                this.Map.IdxAT[index] = this.getAT(index);
                this.Map.IdxSet[index] = this.getSetIndex(index);
                index++;
            }
            while (index <= 1);
            int num = this.getMax(this.Powers[0].Length, this.Powers[1].Length);
            if (num > 20)
            {
                num = 20;
            }
            int num2 = num;
            for (index = 0; index <= num2; index++)
            {
                if (this.Powers[0].Length > index)
                {
                    this.Map.Map[index, 0] = index;
                }
                if (this.Powers[1].Length > index)
                {
                    this.Map.Map[index, 1] = index;
                }
            }
        }

        // Token: 0x060003CD RID: 973 RVA: 0x00033E14 File Offset: 0x00032014
        public int mapDescString(string[] iStrings, ref bool[] Placed)
        {
            int num = 0;
            int num2 = this.Powers[1].Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                bool flag2 = true;
                int num3 = iStrings.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    if (this.Powers[1][index].DescShort.IndexOf(iStrings[index2], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        flag2 = false;
                    }
                }
                if (flag2 & !Placed[index])
                {
                    int num4 = this.Powers[0].Length - 1;
                    for (int index3 = 0; index3 <= num4; index3++)
                    {
                        flag2 = (this.Map.Map[index3, 1] < 0);
                        int num5 = iStrings.Length - 1;
                        for (int index2 = 0; index2 <= num5; index2++)
                        {
                            if (this.Powers[0][index3].DescShort.IndexOf(iStrings[index2], StringComparison.OrdinalIgnoreCase) < 0)
                            {
                                flag2 = false;
                            }
                        }
                        if (flag2)
                        {
                            this.Map.Map[index3, 1] = index;
                            Placed[index] = true;
                            return index;
                        }
                    }
                }
            }
            return num;
        }

        // Token: 0x060003CE RID: 974 RVA: 0x00033F84 File Offset: 0x00032184
        public void mapOverride()
        {
            int num = MidsContext.Config.CompOverride.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                Enums.CompOverride[] compOverride = MidsContext.Config.CompOverride;
                int index2 = index;
                this.mapOverrideDo(compOverride[index2].Powerset, compOverride[index2].Power, compOverride[index2].Override);
            }
        }

        // Token: 0x060003CF RID: 975 RVA: 0x00033FF0 File Offset: 0x000321F0
        public void mapOverrideDo(string iSet, string iPower, string iNewStr)
        {
            int index = 0;
            do
            {
                int num = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (this.Powers[index][index2].PowerSetID > -1 && (string.Equals(this.Powers[index][index2].DisplayName, iPower, StringComparison.OrdinalIgnoreCase) & string.Equals(DatabaseAPI.Database.Powersets[this.Powers[index][index2].PowerSetID].DisplayName, iSet, StringComparison.OrdinalIgnoreCase)))
                    {
                        this.Powers[index][index2].DescShort = iNewStr.ToUpper();
                    }
                }
                index++;
            }
            while (index <= 1);
        }

        // Token: 0x060003D0 RID: 976 RVA: 0x000340AB File Offset: 0x000322AB
        private void ResetScale()
        {
            this.tbScaleX.Value = 10;
            this.Graph.Max = this.GraphMax;
            this.SetScaleLabel();
        }

        // Token: 0x060003D1 RID: 977 RVA: 0x000340D8 File Offset: 0x000322D8
        public void SetLocation()
        {
            Rectangle rectangle = default(Rectangle);
            rectangle.X = MainModule.MidsController.SzFrmCompare.X;
            rectangle.Y = MainModule.MidsController.SzFrmCompare.Y;
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
        }

        // Token: 0x060003D2 RID: 978 RVA: 0x000341B9 File Offset: 0x000323B9
        private void SetScaleLabel()
        {
            this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
        }

        // Token: 0x060003D3 RID: 979 RVA: 0x000341E4 File Offset: 0x000323E4
        private void StoreLocation()
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                MainModule.MidsController.SzFrmCompare.X = base.Left;
                MainModule.MidsController.SzFrmCompare.Y = base.Top;
            }
        }

        // Token: 0x060003D4 RID: 980 RVA: 0x00034222 File Offset: 0x00032422
        private void tbScaleX_Scroll(object sender, EventArgs e)
        {
            this.Graph.ScaleIndex = this.tbScaleX.Value;
            this.SetScaleLabel();
        }

        // Token: 0x060003D5 RID: 981 RVA: 0x00034244 File Offset: 0x00032444
        public void UpdateData()
        {
            this.btnClose.IA = this.myParent.Drawing.pImageAttributes;
            this.btnClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.btnClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.chkOnTop.IA = this.myParent.Drawing.pImageAttributes;
            this.chkOnTop.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.chkOnTop.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }

        // Token: 0x060003D6 RID: 982 RVA: 0x00034334 File Offset: 0x00032534
        public void values_Accuracy()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    bool flag = false;
                    int num3 = this.Powers[index][index2].Effects.Length - 1;
                    for (int index3 = 0; index3 <= num3; index3++)
                    {
                        if (this.Powers[index][index2].Effects[index3].RequiresToHitCheck)
                        {
                            flag = true;
                        }
                    }
                    if (this.Powers[index][index2].EntitiesAutoHit == Enums.eEntity.None || flag)
                    {
                        this.Values[index][index2] = this.Powers[index][index2].Accuracy * MidsContext.Config.BaseAcc * 100f;
                    }
                    else
                    {
                        this.Values[index][index2] = 0f;
                    }
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips2;
                        int index4;
                        int index5;
                        if (this.Matching)
                        {
                            tips2 = this.Tips;
                            index4 = index;
                            index5 = index2;
                            tips2[index4][index5] = tips2[index4][index5] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips2 = this.Tips;
                        index5 = index;
                        index4 = index2;
                        tips2[index5][index4] = tips2[index5][index4] + "\r\n  " + Strings.Format(this.Values[index][index2], "##0.##") + "% base Accuracy";
                        tips2 = this.Tips;
                        index5 = index;
                        index4 = index2;
                        tips2[index5][index4] = tips2[index5][index4] + "\r\n  (Real Numbers style: " + Strings.Format(this.Powers[index][index2].Accuracy, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "x)";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003D7 RID: 983 RVA: 0x000345CC File Offset: 0x000327CC
        public void values_Damage()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].FXGetDamageValue();
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips2;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips2 = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips2[index3][index4] = tips2[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips2 = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips2[index4][index3] = tips2[index4][index3] + "\r\n  " + this.Powers[index][index2].FXGetDamageString();
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                        if (this.Powers[index][index2].PowerType == Enums.ePowerType.Toggle)
                        {
                            tips2 = this.Tips;
                            index4 = index;
                            index3 = index2;
                            tips2[index4][index3] = tips2[index4][index3] + "\r\n  (Applied every " + Conversions.ToString(this.Powers[index][index2].ActivatePeriod) + "s)";
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        // Token: 0x060003D8 RID: 984 RVA: 0x000347FC File Offset: 0x000329FC
        public void values_DPA()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].FXGetDamageValue();
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  " + this.Powers[index][index2].FXGetDamageString() + "/s";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        // Token: 0x060003D9 RID: 985 RVA: 0x000349D0 File Offset: 0x00032BD0
        public void values_DPE()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].FXGetDamageValue();
                    if (this.Values[index][index2] != 0f)
                    {
                        if (this.Powers[index][index2].PowerType == Enums.ePowerType.Click && this.Powers[index][index2].EndCost > 0f)
                        {
                            this.Values[index][index2] /= this.Powers[index][index2].EndCost;
                        }
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips2;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips2 = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips2[index3][index4] = tips2[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips2 = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips2[index4][index3] = tips2[index4][index3] + "\r\n  " + this.Powers[index][index2].FXGetDamageString();
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                        tips2 = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips2[index4][index3] = tips2[index4][index3] + " - DPE: " + Strings.Format(this.Values[index][index2], "##0.##");
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        // Token: 0x060003DA RID: 986 RVA: 0x00034C44 File Offset: 0x00032E44
        public void values_DPS()
        {
            float num = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].FXGetDamageValue();
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  " + this.Powers[index][index2].FXGetDamageString() + "/s";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        // Token: 0x060003DB RID: 987 RVA: 0x00034E18 File Offset: 0x00033018
        public void values_Duration()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    int durationEffectId = this.Powers[index][index2].GetDurationEffectID();
                    if (durationEffectId > -1)
                    {
                        this.Values[index][index2] = this.Powers[index][index2].Effects[durationEffectId].Duration;
                        if (this.Values[index][index2] != 0f)
                        {
                            this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                            string[][] tips;
                            int index3;
                            int index4;
                            if (this.Matching)
                            {
                                tips = this.Tips;
                                index3 = index;
                                index4 = index2;
                                tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                            }
                            tips = this.Tips;
                            index4 = index;
                            index3 = index2;
                            tips[index4][index3] = tips[index4][index3] + "\r\n  " + this.Powers[index][index2].Effects[durationEffectId].BuildEffectString(false, "", false, false, false);
                            if (num < this.Values[index][index2])
                            {
                                num = this.Values[index][index2];
                            }
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003DC RID: 988 RVA: 0x00034FE4 File Offset: 0x000331E4
        public void values_End()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].EndCost;
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips2;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips2 = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips2[index3][index4] = tips2[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips2 = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips2[index4][index3] = tips2[index4][index3] + "\r\n  End: " + Strings.Format(this.Powers[index][index2].EndCost, "##0.##");
                        if (this.Powers[index][index2].PowerType == Enums.ePowerType.Toggle)
                        {
                            tips2 = this.Tips;
                            index4 = index;
                            index3 = index2;
                            tips2[index4][index3] = tips2[index4][index3] + " (Per Second)";
                        }
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003DD RID: 989 RVA: 0x000351C4 File Offset: 0x000333C4
        public void values_EPS()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].EndCost;
                    if (this.Values[index][index2] != 0f)
                    {
                        if (this.Powers[index][index2].PowerType == Enums.ePowerType.Click)
                        {
                            if (this.Powers[index][index2].RechargeTime + this.Powers[index][index2].CastTime + this.Powers[index][index2].InterruptTime > 0f)
                            {
                                this.Values[index][index2] = this.Powers[index][index2].EndCost / (this.Powers[index][index2].RechargeTime + this.Powers[index][index2].CastTime + this.Powers[index][index2].InterruptTime);
                            }
                        }
                        else if (this.Powers[index][index2].PowerType == Enums.ePowerType.Toggle)
                        {
                            this.Values[index][index2] = this.Powers[index][index2].EndCost / this.Powers[index][index2].ActivatePeriod;
                        }
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips2;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips2 = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips2[index3][index4] = tips2[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips2 = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips2[index4][index3] = tips2[index4][index3] + "\r\n  End: " + Strings.Format(this.Values[index][index2], "##0.##");
                        tips2 = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips2[index4][index3] = tips2[index4][index3] + "/s";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003DE RID: 990 RVA: 0x00035474 File Offset: 0x00033674
        public void values_Heal()
        {
            Archetype archetype = MidsContext.Archetype;
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index][index2].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false);
                    this.Values[index][index2] = effectMagSum.Sum;
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = MidsContext.Archetype.DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  " + this.Powers[index][index2].Effects[effectMagSum.Index[0]].BuildEffectString(false, "", false, false, false);
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Archetype = archetype;
        }

        // Token: 0x060003DF RID: 991 RVA: 0x00035650 File Offset: 0x00033850
        public void values_HPE()
        {
            Archetype archetype = MidsContext.Archetype;
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index][index2].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false);
                    this.Values[index][index2] = effectMagSum.Sum;
                    if (this.Values[index][index2] != 0f)
                    {
                        if (this.Powers[index][index2].EndCost > 0f)
                        {
                            this.Values[index][index2] /= this.Powers[index][index2].EndCost;
                        }
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  Heal: " + Strings.Format(this.Values[index][index2], "##0.##") + " HP per unit of end.";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Archetype = archetype;
        }

        // Token: 0x060003E0 RID: 992 RVA: 0x00035884 File Offset: 0x00033A84
        public void values_HPS()
        {
            Archetype archetype = MidsContext.Archetype;
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index][index2].GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false);
                    this.Values[index][index2] = effectMagSum.Sum;
                    if (this.Values[index][index2] != 0f)
                    {
                        if (this.Powers[index][index2].PowerType == Enums.ePowerType.Click && this.Powers[index][index2].RechargeTime + this.Powers[index][index2].CastTime + this.Powers[index][index2].InterruptTime > 0f)
                        {
                            this.Values[index][index2] /= this.Powers[index][index2].RechargeTime + this.Powers[index][index2].CastTime + this.Powers[index][index2].InterruptTime;
                        }
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  Heal: " + Strings.Format(this.Values[index][index2], "##0.##") + " HP/s";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Archetype = archetype;
        }

        // Token: 0x060003E1 RID: 993 RVA: 0x00035B14 File Offset: 0x00033D14
        public void values_MaxTargets()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = (float)this.Powers[index][index2].MaxTargets;
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        if (this.Values[index][index2] > 1f)
                        {
                            string[][] tips = this.Tips;
                            int index4 = index;
                            int index3 = index2;
                            tips[index4][index3] = tips[index4][index3] + "\r\n  " + Conversions.ToString(this.Values[index][index2]) + " Targets Max.";
                        }
                        else
                        {
                            string[][] tips = this.Tips;
                            int index4 = index;
                            int index3 = index2;
                            tips[index4][index3] = tips[index4][index3] + "\r\n  " + Conversions.ToString(this.Values[index][index2]) + " Target Max.";
                        }
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003E2 RID: 994 RVA: 0x00035D04 File Offset: 0x00033F04
        public void values_Range()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    string str = "";
                    switch (this.Powers[index][index2].EffectArea)
                    {
                        case Enums.eEffectArea.Character:
                            str = Conversions.ToString(this.Powers[index][index2].Range) + "ft range.";
                            this.Values[index][index2] = this.Powers[index][index2].Range;
                            break;
                        case Enums.eEffectArea.Sphere:
                            this.Values[index][index2] = this.Powers[index][index2].Radius;
                            if (this.Powers[index][index2].Range > 0f)
                            {
                                str = Conversions.ToString(this.Powers[index][index2].Range) + "ft range, ";
                                this.Values[index][index2] = this.Powers[index][index2].Range;
                            }
                            str = str + Conversions.ToString(this.Powers[index][index2].Radius) + "ft radius.";
                            break;
                        case Enums.eEffectArea.Cone:
                            this.Values[index][index2] = this.Powers[index][index2].Range;
                            str = Conversions.ToString(this.Powers[index][index2].Range) + "ft range, " + Conversions.ToString(this.Powers[index][index2].Arc) + " degree cone.";
                            break;
                        case Enums.eEffectArea.Location:
                            this.Values[index][index2] = this.Powers[index][index2].Range;
                            str = Conversions.ToString(this.Powers[index][index2].Range) + "ft range, " + Conversions.ToString(this.Powers[index][index2].Radius) + "ft radius.";
                            break;
                        case Enums.eEffectArea.Volume:
                            this.Values[index][index2] = this.Powers[index][index2].Radius;
                            if (this.Powers[index][index2].Range > 0f)
                            {
                                str = Conversions.ToString(this.Powers[index][index2].Range) + "ft range, ";
                                this.Values[index][index2] = this.Powers[index][index2].Range;
                            }
                            str = str + Conversions.ToString(this.Powers[index][index2].Radius) + "ft radius.";
                            break;
                    }
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  " + str;
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003E3 RID: 995 RVA: 0x000360C4 File Offset: 0x000342C4
        public void values_Recharge()
        {
            float num = 1f;
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.Values[index][index2] = this.Powers[index][index2].RechargeTime;
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        string[][] tips;
                        int index3;
                        int index4;
                        if (this.Matching)
                        {
                            tips = this.Tips;
                            index3 = index;
                            index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        tips = this.Tips;
                        index4 = index;
                        index3 = index2;
                        tips[index4][index3] = tips[index4][index3] + "\r\n  " + Strings.Format(this.Values[index][index2], "##0.##") + "s";
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
        }

        // Token: 0x060003E4 RID: 996 RVA: 0x00036260 File Offset: 0x00034460
        public void Values_Universal(Enums.eEffectType iEffectType, bool Sum, bool Debuff)
        {
            Archetype archetype = MidsContext.Archetype;
            float num = 1f;
            string str = "";
            int index = 0;
            do
            {
                int num2 = this.Powers[index].Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index][index2].GetEffectMagSum(iEffectType, false, false, false, false);
                    int index3 = 0;
                    if (effectMagSum.Present)
                    {
                        if (Debuff)
                        {
                            int num3 = effectMagSum.Index.Length - 1;
                            for (int index4 = 0; index4 <= num3; index4++)
                            {
                                if (effectMagSum.Value[index4] > 0f)
                                {
                                    effectMagSum.Value[index4] = 0f;
                                }
                                else
                                {
                                    float[] value = effectMagSum.Value;
                                    int index5 = index4;
                                    value[index5] *= -1f;
                                }
                            }
                            effectMagSum.ReSum();
                            index3 = effectMagSum.Max;
                        }
                        else
                        {
                            int num4 = effectMagSum.Index.Length - 1;
                            for (int index4 = 0; index4 <= num4; index4++)
                            {
                                if (effectMagSum.Value[index4] < 0f)
                                {
                                    effectMagSum.Value[index4] = 0f;
                                }
                            }
                            index3 = effectMagSum.Max;
                            effectMagSum.ReSum();
                        }
                    }
                    if (!Sum)
                    {
                        if (effectMagSum.Present)
                        {
                            str = this.GetUniversalTipString(effectMagSum, ref this.Powers[index][index2]);
                            this.Values[index][index2] = effectMagSum.Value[index3];
                            if (this.Powers[index][index2].Effects[effectMagSum.Index[index3]].DisplayPercentage)
                            {
                                float[][] values = this.Values;
                                int index5 = index;
                                int index6 = index2;
                                values[index5][index6] *= 100f;
                            }
                        }
                    }
                    else
                    {
                        if (effectMagSum.Present && this.Powers[index][index2].Effects[effectMagSum.Index[index3]].DisplayPercentage)
                        {
                            effectMagSum.Multiply();
                        }
                        this.Values[index][index2] = effectMagSum.Sum;
                    }
                    if (this.Values[index][index2] != 0f)
                    {
                        this.Tips[index][index2] = DatabaseAPI.Database.Classes[this.Powers[index][index2].ForcedClassID].DisplayName + ":" + this.Powers[index][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index6 = index;
                            int index5 = index2;
                            tips[index6][index5] = tips[index6][index5] + " [Level " + Conversions.ToString(this.Powers[index][index2].Level) + "]";
                        }
                        if (Sum)
                        {
                            str = "";
                            int num5 = effectMagSum.Index.Length - 1;
                            for (int index7 = 0; index7 <= num5; index7++)
                            {
                                if (str != "")
                                {
                                    str += "\r\n";
                                }
                                str = str + "  " + this.Powers[index][index2].Effects[effectMagSum.Index[index7]].BuildEffectString(false, "", false, false, false).Replace("\r\n", "\r\n  ");
                            }
                            string[][] tips = this.Tips;
                            int index6 = index;
                            int index5 = index2;
                            tips[index6][index5] = tips[index6][index5] + "\r\n" + str;
                        }
                        else
                        {
                            string[][] tips = this.Tips;
                            int index6 = index;
                            int index5 = index2;
                            tips[index6][index5] = tips[index6][index5] + "\r\n  " + str;
                        }
                        if (num < this.Values[index][index2])
                        {
                            num = this.Values[index][index2];
                        }
                    }
                }
                index++;
            }
            while (index <= 1);
            this.GraphMax = (float)((double)num * 1.025);
            MidsContext.Archetype = archetype;
        }

        // Token: 0x0400017C RID: 380
        [AccessedThroughProperty("btnClose")]
        private ImageButton _btnClose;

        // Token: 0x0400017D RID: 381
        [AccessedThroughProperty("btnTweakMatch")]
        private Button _btnTweakMatch;

        // Token: 0x0400017E RID: 382
        [AccessedThroughProperty("cbAT1")]
        private ComboBox _cbAT1;

        // Token: 0x0400017F RID: 383
        [AccessedThroughProperty("cbAT2")]
        private ComboBox _cbAT2;

        // Token: 0x04000180 RID: 384
        [AccessedThroughProperty("cbSet1")]
        private ComboBox _cbSet1;

        // Token: 0x04000181 RID: 385
        [AccessedThroughProperty("cbSet2")]
        private ComboBox _cbSet2;

        // Token: 0x04000182 RID: 386
        [AccessedThroughProperty("cbType1")]
        private ComboBox _cbType1;

        // Token: 0x04000183 RID: 387
        [AccessedThroughProperty("cbType2")]
        private ComboBox _cbType2;

        // Token: 0x04000184 RID: 388
        [AccessedThroughProperty("chkMatching")]
        private CheckBox _chkMatching;

        // Token: 0x04000185 RID: 389
        [AccessedThroughProperty("chkOnTop")]
        private ImageButton _chkOnTop;

        // Token: 0x04000186 RID: 390
        [AccessedThroughProperty("Graph")]
        private ctlMultiGraph _Graph;

        // Token: 0x04000187 RID: 391
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;

        // Token: 0x04000188 RID: 392
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;

        // Token: 0x04000189 RID: 393
        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;

        // Token: 0x0400018A RID: 394
        [AccessedThroughProperty("lblKeyColor1")]
        private Label _lblKeyColor1;

        // Token: 0x0400018B RID: 395
        [AccessedThroughProperty("lblKeyColor2")]
        private Label _lblKeyColor2;

        // Token: 0x0400018C RID: 396
        [AccessedThroughProperty("lblScale")]
        private Label _lblScale;

        // Token: 0x0400018D RID: 397
        [AccessedThroughProperty("lstDisplay")]
        private ListBox _lstDisplay;

        // Token: 0x0400018E RID: 398
        [AccessedThroughProperty("tbScaleX")]
        private TrackBar _tbScaleX;

        // Token: 0x0400018F RID: 399
        [AccessedThroughProperty("tTip")]
        private ToolTip _tTip;

        // Token: 0x04000191 RID: 401
        protected string[] DisplayValueStrings;

        // Token: 0x04000192 RID: 402
        protected float GraphMax;

        // Token: 0x04000193 RID: 403
        protected bool Loaded;

        // Token: 0x04000194 RID: 404
        protected Enums.CompMap Map;

        // Token: 0x04000195 RID: 405
        protected bool Matching;

        // Token: 0x04000196 RID: 406
        protected frmMain myParent;

        // Token: 0x04000197 RID: 407
        protected IPower[][] Powers;

        // Token: 0x04000198 RID: 408
        protected string[][] Tips;

        // Token: 0x04000199 RID: 409
        protected float[][] Values;

        // Token: 0x02000025 RID: 37
        protected enum eDisplayItems
        {
            // Token: 0x0400019B RID: 411
            Accuracy,
            // Token: 0x0400019C RID: 412
            Damage,
            // Token: 0x0400019D RID: 413
            DamagePA,
            // Token: 0x0400019E RID: 414
            DamagePS,
            // Token: 0x0400019F RID: 415
            DamagePE,
            // Token: 0x040001A0 RID: 416
            DamageBuff,
            // Token: 0x040001A1 RID: 417
            Defense,
            // Token: 0x040001A2 RID: 418
            DefenseDebuff,
            // Token: 0x040001A3 RID: 419
            Duration,
            // Token: 0x040001A4 RID: 420
            EndUse,
            // Token: 0x040001A5 RID: 421
            EndUsePS,
            // Token: 0x040001A6 RID: 422
            Heal,
            // Token: 0x040001A7 RID: 423
            HealPS,
            // Token: 0x040001A8 RID: 424
            HealPE,
            // Token: 0x040001A9 RID: 425
            HitPoints,
            // Token: 0x040001AA RID: 426
            TargetCount,
            // Token: 0x040001AB RID: 427
            Range,
            // Token: 0x040001AC RID: 428
            Recharge,
            // Token: 0x040001AD RID: 429
            Regen,
            // Token: 0x040001AE RID: 430
            Resistance,
            // Token: 0x040001AF RID: 431
            ResistanceDebuff,
            // Token: 0x040001B0 RID: 432
            ToHitBuff,
            // Token: 0x040001B1 RID: 433
            ToHitDeBuff
        }
    }
}
