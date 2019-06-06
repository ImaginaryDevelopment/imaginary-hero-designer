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

    public partial class frmCompare : Form
    {

    
    
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


        private void btnClose_ButtonClicked()
        {
            base.Close();
        }


        private void btnClose_Load(object sender, EventArgs e)
        {
        }


        private void btnTweakMatch_Click(object sender, EventArgs e)
        {
            new frmTweakMatching().ShowDialog(this);
            this.DisplayGraph();
        }


        private void cbAT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(0);
            }
        }


        private void cbAT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(1);
            }
        }


        private void cbSet1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }


        private void cbSet2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }


        private void cbType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(0);
            }
        }


        private void cbType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.List_Sets(1);
            }
        }


        private void chkMatching_CheckedChanged(object sender, EventArgs e)
        {
            this.Matching = this.chkMatching.Checked;
            if (this.Loaded)
            {
                this.DisplayGraph();
            }
        }


        private void chkOnTop_CheckedChanged()
        {
            base.TopMost = this.chkOnTop.Checked;
        }


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


        protected void FillDisplayList()
        {
            ListBox lstDisplay = this.lstDisplay;
            lstDisplay.BeginUpdate();
            lstDisplay.Items.Clear();
            lstDisplay.Items.AddRange(this.DisplayValueStrings);
            this.lstDisplay.SelectedIndex = 0;
            lstDisplay.EndUpdate();
        }


        private void frmCompare_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.FloatCompareGraph(false);
        }


        private void frmCompare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.Shift & e.KeyCode == Keys.T)
            {
                this.btnTweakMatch.Visible = true;
            }
        }


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


        private void frmCompare_Move(object sender, EventArgs e)
        {
            this.StoreLocation();
        }


        private void frmCompare_Resize(object sender, EventArgs e)
        {
            this.StoreLocation();
        }


        private void frmCompare_VisibleChanged(object sender, EventArgs e)
        {
            this.Graph.BackColor = this.BackColor;
        }


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


        private void Graph_Load(object sender, EventArgs e)
        {
        }


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


        private void lstDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Loaded)
            {
                this.ResetScale();
                this.DisplayGraph();
            }
        }


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


        private void ResetScale()
        {
            this.tbScaleX.Value = 10;
            this.Graph.Max = this.GraphMax;
            this.SetScaleLabel();
        }


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


        private void SetScaleLabel()
        {
            this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
        }


        private void StoreLocation()
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                MainModule.MidsController.SzFrmCompare.X = base.Left;
                MainModule.MidsController.SzFrmCompare.Y = base.Top;
            }
        }


        private void tbScaleX_Scroll(object sender, EventArgs e)
        {
            this.Graph.ScaleIndex = this.tbScaleX.Value;
            this.SetScaleLabel();
        }


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


        [AccessedThroughProperty("btnClose")]
        private ImageButton _btnClose;


        [AccessedThroughProperty("btnTweakMatch")]
        private Button _btnTweakMatch;


        [AccessedThroughProperty("cbAT1")]
        private ComboBox _cbAT1;


        [AccessedThroughProperty("cbAT2")]
        private ComboBox _cbAT2;


        [AccessedThroughProperty("cbSet1")]
        private ComboBox _cbSet1;


        [AccessedThroughProperty("cbSet2")]
        private ComboBox _cbSet2;


        [AccessedThroughProperty("cbType1")]
        private ComboBox _cbType1;


        [AccessedThroughProperty("cbType2")]
        private ComboBox _cbType2;


        [AccessedThroughProperty("chkMatching")]
        private CheckBox _chkMatching;


        [AccessedThroughProperty("chkOnTop")]
        private ImageButton _chkOnTop;


        [AccessedThroughProperty("Graph")]
        private ctlMultiGraph _Graph;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;


        [AccessedThroughProperty("lblKeyColor1")]
        private Label _lblKeyColor1;


        [AccessedThroughProperty("lblKeyColor2")]
        private Label _lblKeyColor2;


        [AccessedThroughProperty("lblScale")]
        private Label _lblScale;


        [AccessedThroughProperty("lstDisplay")]
        private ListBox _lstDisplay;


        [AccessedThroughProperty("tbScaleX")]
        private TrackBar _tbScaleX;


        [AccessedThroughProperty("tTip")]
        private ToolTip _tTip;


        protected string[] DisplayValueStrings;


        protected float GraphMax;


        protected bool Loaded;


        protected Enums.CompMap Map;


        protected bool Matching;


        protected frmMain myParent;


        protected IPower[][] Powers;


        protected string[][] Tips;


        protected float[][] Values;


        protected enum eDisplayItems
        {

            Accuracy,

            Damage,

            DamagePA,

            DamagePS,

            DamagePE,

            DamageBuff,

            Defense,

            DefenseDebuff,

            Duration,

            EndUse,

            EndUsePS,

            Heal,

            HealPS,

            HealPE,

            HitPoints,

            TargetCount,

            Range,

            Recharge,

            Regen,

            Resistance,

            ResistanceDebuff,

            ToHitBuff,

            ToHitDeBuff
        }
    }
}
