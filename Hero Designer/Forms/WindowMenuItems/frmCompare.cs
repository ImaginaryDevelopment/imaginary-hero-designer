
using Base.Data_Classes;
using Base.Master_Classes;
using HeroDesigner.Schema;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmCompare : Form
    {
        ImageButton btnClose;

        Button btnTweakMatch;

        ComboBox cbAT1;

        ComboBox cbAT2;

        ComboBox cbSet1;

        ComboBox cbSet2;

        ComboBox cbType1;

        ComboBox cbType2;

        CheckBox chkMatching;

        ImageButton chkOnTop;

        ctlMultiGraph Graph;
        GroupBox GroupBox1;
        GroupBox GroupBox2;
        GroupBox GroupBox4;
        Label lblKeyColor1;
        Label lblKeyColor2;
        Label lblScale;

        ListBox lstDisplay;

        TrackBar tbScaleX;
        ToolTip tTip;

        protected string[] DisplayValueStrings;
        protected float GraphMax;
        protected bool Loaded;
        protected Enums.CompMap Map;
        protected bool Matching;
        protected frmMain myParent;
        protected IPower[][] Powers;
        protected string[][] Tips;
        protected float[][] Values;

        public frmCompare(ref frmMain iFrm)
        {
            this.Load += new EventHandler(this.frmCompare_Load);
            this.KeyDown += new KeyEventHandler(this.frmCompare_KeyDown);
            this.VisibleChanged += new EventHandler(this.frmCompare_VisibleChanged);
            this.Resize += new EventHandler(this.frmCompare_Resize);
            this.Move += new EventHandler(this.frmCompare_Move);
            this.FormClosed += new FormClosedEventHandler(this.frmCompare_FormClosed);
            this.Powers = new IPower[2][];
            this.Values = new float[2][];
            this.Tips = new string[2][];
            this.GraphMax = 1f;
            this.Matching = false;
            this.Loaded = false;
            this.DisplayValueStrings = new string[23]
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

        void btnClose_ButtonClicked()
        {
            this.Close();
        }

        void btnClose_Load(object sender, EventArgs e)
        {
        }

        void btnTweakMatch_Click(object sender, EventArgs e)

        {
            int num = (int)new frmTweakMatching().ShowDialog((IWin32Window)this);
            this.DisplayGraph();
        }

        void cbAT1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.List_Sets(0);
        }

        void cbAT2_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.List_Sets(1);
        }

        void cbSet1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.ResetScale();
            this.DisplayGraph();
        }

        void cbSet2_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.ResetScale();
            this.DisplayGraph();
        }

        void cbType1_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.List_Sets(0);
        }

        void cbType2_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.List_Sets(1);
        }

        void chkMatching_CheckedChanged(object sender, EventArgs e)

        {
            this.Matching = this.chkMatching.Checked;
            if (!this.Loaded)
                return;
            this.DisplayGraph();
        }

        void chkOnTop_CheckedChanged()

        {
            this.TopMost = this.chkOnTop.Checked;
        }

        public void DisplayGraph()
        {
            if (this.lstDisplay.SelectedIndex < 0)
                return;
            this.Graph.BeginUpdate();
            this.Graph.Clear();
            this.GetPowers();
            if (this.Matching)
                this.map_Advanced();
            else
                this.map_Simple();
            switch (this.lstDisplay.SelectedIndex)
            {
                case 0:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 0);
                    this.values_Accuracy();
                    break;
                case 1:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.Red;
                    this.values_Damage();
                    break;
                case 2:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.Red;
                    this.values_DPA();
                    break;
                case 3:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.Red;
                    this.values_DPS();
                    break;
                case 4:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.Red;
                    this.values_DPE();
                    break;
                case 5:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(192, 0, 0);
                    this.Values_Universal(eEffectType.DamageBuff, false, false);
                    break;
                case 6:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(192, 0, 192);
                    this.Values_Universal(eEffectType.Defense, false, false);
                    break;
                case 7:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(128, 0, 128);
                    this.Values_Universal(eEffectType.Defense, false, true);
                    break;
                case 8:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(128, 0, (int)byte.MaxValue);
                    this.values_Duration();
                    break;
                case 9:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
                    this.values_End();
                    break;
                case 10:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
                    this.values_EPS();
                    break;
                case 11:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(96, (int)byte.MaxValue, 96);
                    this.values_Heal();
                    break;
                case 12:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(96, (int)byte.MaxValue, 96);
                    this.values_HPS();
                    break;
                case 13:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(96, (int)byte.MaxValue, 96);
                    this.values_HPE();
                    break;
                case 14:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(96, (int)byte.MaxValue, 96);
                    this.Values_Universal(eEffectType.HitPoints, true, false);
                    break;
                case 15:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(64, 128, 128);
                    this.values_MaxTargets();
                    break;
                case 16:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(96, 128, 96);
                    this.values_Range();
                    break;
                case 17:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb((int)byte.MaxValue, 192, 128);
                    this.values_Recharge();
                    break;
                case 18:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(96, (int)byte.MaxValue, 96);
                    this.Values_Universal(eEffectType.Regeneration, true, false);
                    break;
                case 19:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(0, 192, 192);
                    this.Values_Universal(eEffectType.Resistance, false, false);
                    break;
                case 20:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(0, 128, 128);
                    this.Values_Universal(eEffectType.Resistance, false, true);
                    break;
                case 21:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 96);
                    this.Values_Universal(eEffectType.ToHit, true, false);
                    break;
                case 22:
                    this.Graph.ColorFadeEnd = System.Drawing.Color.FromArgb(192, 192, 64);
                    this.Values_Universal(eEffectType.ToHit, true, true);
                    break;
            }
            int index1 = 0;
            do
            {
                string[] strArray = new string[2] { "", "" };
                float[] numArray = new float[2];
                string iTip = "";
                int index2 = 0;
                do
                {
                    if (this.Map.Map[index1, index2] > -1)
                    {
                        strArray[index2] = this.Powers[index2][this.Map.Map[index1, index2]].DisplayName;
                        numArray[index2] = this.Values[index2][this.Map.Map[index1, index2]];
                        if (iTip != "" & this.Tips[index2][this.Map.Map[index1, index2]] != "")
                            iTip += "\r\n----------\r\n";
                        iTip += this.Tips[index2][this.Map.Map[index1, index2]];
                    }
                    ++index2;
                }
                while (index2 <= 1);
                this.Graph.AddItemPair(strArray[0], strArray[1], numArray[0], numArray[1], iTip);
                ++index1;
            }
            while (index1 <= 20);
            this.Graph.Max = this.GraphMax;
            this.tbScaleX.Value = this.Graph.ScaleIndex;
            this.SetScaleLabel();
            this.Graph.EndUpdate();
        }

        protected void FillDisplayList()
        {
            ListBox lstDisplay = this.lstDisplay;
            lstDisplay.BeginUpdate();
            lstDisplay.Items.Clear();
            lstDisplay.Items.AddRange((object[])this.DisplayValueStrings);
            this.lstDisplay.SelectedIndex = 0;
            lstDisplay.EndUpdate();
        }

        void frmCompare_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.myParent.FloatCompareGraph(false);
        }

        void frmCompare_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control & e.Shift & e.KeyCode == System.Windows.Forms.Keys.T))
                return;
            this.btnTweakMatch.Visible = true;
        }

        void frmCompare_Load(object sender, EventArgs e)
        {
            this.FillDisplayList();
            this.UpdateData();
            this.list_AT();
            if (MidsContext.Character.Archetype.Idx > -1)
                this.cbAT1.SelectedIndex = MidsContext.Character.Archetype.Idx;
            if (MidsContext.Character.Archetype.Idx > -1)
                this.cbAT2.SelectedIndex = MidsContext.Character.Archetype.Idx;
            this.tbScaleX.Minimum = 0;
            this.tbScaleX.Maximum = this.Graph.ScaleCount - 1;
            this.list_Type();
            this.List_Sets(0);
            this.List_Sets(1);
            this.Map.Init();
            this.chkMatching.Checked = this.Matching;
            this.Loaded = true;
            this.DisplayGraph();
            this.tTip.SetToolTip((Control)this.chkMatching, "Re-order powers so that similar powers are compared directly, regardless of their position in the set.\r\nFor example, moving snipe powers to directly compare.\r\n(This isn't known for its stunning accuracy, and gets confused by vastly different sets)");
        }

        void frmCompare_Move(object sender, EventArgs e)

        {
            this.StoreLocation();
        }

        void frmCompare_Resize(object sender, EventArgs e)

        {
            this.StoreLocation();
        }

        void frmCompare_VisibleChanged(object sender, EventArgs e)

        {
            this.Graph.BackColor = this.BackColor;
        }

        public int getAT(int Index)
        {
            int num;
            switch (Index)
            {
                case 0:
                    num = this.cbAT1.SelectedIndex;
                    break;
                case 1:
                    num = this.cbAT2.SelectedIndex;
                    break;
                default:
                    num = 0;
                    break;
            }
            return num;
        }

        public int getMax(int iVal1, int ival2)
        {
            return iVal1 <= ival2 ? ival2 : iVal1;
        }

        public int GetNextFreeSlot()
        {
            int index = 0;
            while (this.Map.Map[index, 1] != -1)
            {
                ++index;
                if (index > 20)
                    return 20;
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
                int nIDClass = Index != 0 ? this.cbAT2.SelectedIndex : this.cbAT1.SelectedIndex;
                int num = this.Powers[Index].Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    this.Powers[Index][index] = (IPower)new Power(DatabaseAPI.Database.Powersets[numArray[Index]].Powers[index]);
                    this.Powers[Index][index].AbsorbPetEffects(-1);
                    this.Powers[Index][index].ApplyGrantPowerEffects();
                    if (nIDClass > -1)
                    {
                        this.Powers[Index][index].ForcedClassID = nIDClass;
                        this.Powers[Index][index].ForcedClass = DatabaseAPI.UidFromNidClass(nIDClass);
                    }
                }
                ++Index;
            }
            while (Index <= 1);
        }

        public int getSetIndex(int Index)
        {
            ComboBox comboBox;
            switch (Index)
            {
                case 0:
                    comboBox = this.cbSet1;
                    break;
                case 1:
                    comboBox = this.cbSet2;
                    break;
                default:
                    return 0;
            }
            return DatabaseAPI.GetPowersetIndexes(this.getAT(Index), this.getSetType(Index))[comboBox.SelectedIndex].nID;
        }

        public ePowerSetType getSetType(int Index)
        {
            ComboBox comboBox;
            switch (Index)
            {
                case 0:
                    comboBox = this.cbType1;
                    break;
                case 1:
                    comboBox = this.cbType2;
                    break;
                default:
                    return ePowerSetType.Primary;
            }
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    return ePowerSetType.Primary;
                case 1:
                    return ePowerSetType.Secondary;
                case 2:
                    return ePowerSetType.Ancillary;
                default:
                    return ePowerSetType.Primary;
            }
        }

        public string GetUniversalTipString(Enums.ShortFX iSFX, ref IPower iPower)
        {
            string str1 = "";
            string str2;
            if (iSFX.Present)
            {
                int[] numArray = new int[0];
                string str3 = "";
                IPower power = (IPower)new Power(iPower);
                int num1 = iSFX.Index.Length - 1;
                for (int index1 = 0; index1 <= num1; ++index1)
                {
                    if (iSFX.Index[index1] != -1 && power.Effects[iSFX.Index[index1]].EffectType != eEffectType.None)
                    {
                        string returnString = "";
                        int[] returnMask = new int[0];
                        power.GetEffectStringGrouped(iSFX.Index[index1], ref returnString, ref returnMask, false, false, false);
                        if (returnMask.Length > 0)
                        {
                            if (str3 != "")
                                str3 += "\r\n  ";
                            str3 += returnString.Replace("\r\n", "\r\n  ");
                            int num2 = returnMask.Length - 1;
                            for (int index2 = 0; index2 <= num2; ++index2)
                                power.Effects[returnMask[index2]].EffectType = eEffectType.None;
                        }
                    }
                }
                int num3 = iSFX.Index.Length - 1;
                for (int index = 0; index <= num3; ++index)
                {
                    if (power.Effects[iSFX.Index[index]].EffectType != eEffectType.None)
                    {
                        if (str3 != "")
                            str3 += "\r\n  ";
                        str3 += power.Effects[iSFX.Index[index]].BuildEffectString(false, "", false, false, false).Replace("\r\n", "\r\n  ");
                    }
                }
                str2 = str1 + str3;
            }
            else
                str2 = "";
            return str2;
        }

        void Graph_Load(object sender, EventArgs e)

        {
        }

        [DebuggerStepThrough]

        void list_AT()

        {
            this.cbAT1.BeginUpdate();
            this.cbAT1.Items.Clear();
            this.cbAT2.BeginUpdate();
            this.cbAT2.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; ++index)
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
            ePowerSetType iSet = ePowerSetType.None;
            ComboBox comboBox1;
            ComboBox comboBox2;
            int selectedIndex;
            if (Index == 0)
            {
                comboBox1 = this.cbSet1;
                comboBox2 = this.cbType1;
                selectedIndex = this.cbAT1.SelectedIndex;
            }
            else
            {
                comboBox1 = this.cbSet2;
                comboBox2 = this.cbType2;
                selectedIndex = this.cbAT2.SelectedIndex;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    iSet = ePowerSetType.Primary;
                    break;
                case 1:
                    iSet = ePowerSetType.Secondary;
                    break;
                case 2:
                    iSet = ePowerSetType.Ancillary;
                    break;
            }
            comboBox1.BeginUpdate();
            comboBox1.Items.Clear();
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(selectedIndex, iSet);
            int num = powersetIndexes.Length - 1;
            for (int index = 0; index <= num; ++index)
                comboBox1.Items.Add(powersetIndexes[index].DisplayName);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            comboBox1.EndUpdate();
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

        void lstDisplay_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (!this.Loaded)
                return;
            this.ResetScale();
            this.DisplayGraph();
        }

        public void map_Advanced()
        {
            bool[] Placed = new bool[this.Powers[1].Length - 1 + 1];
            int num1 = Placed.Length - 1;
            for (int index = 0; index <= num1; ++index)
                Placed[index] = false;
            this.Map.Init();
            int num2 = this.getMax(this.Powers[0].Length, this.Powers[1].Length);
            if (num2 > 20)
                num2 = 20;
            int num3 = num2;
            for (int index = 0; index <= num3; ++index)
            {
                if (this.Powers[0].Length > index)
                    this.Map.Map[index, 0] = index;
            }
            int num4 = this.Powers[1].Length - 1;
            for (int index1 = 0; index1 <= num4; ++index1)
            {
                string displayName = this.Powers[1][index1].DisplayName;
                int num5 = this.Powers[0].Length - 1;
                for (int index2 = 0; index2 <= num5; ++index2)
                {
                    if (string.Equals(this.Powers[0][index2].DisplayName, displayName, StringComparison.OrdinalIgnoreCase) & !Placed[index1])
                    {
                        this.Map.Map[index2, 1] = index1;
                        Placed[index1] = true;
                        break;
                    }
                }
            }
            this.mapOverride();
            this.mapDescString(new string[1] { "summon" }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+def",
        "smash"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+def",
        "energy"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+def",
        "fire"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+def",
        "ranged"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+def",
        "melee"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+def",
        "aoe"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+def",
        "smash"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+def",
        "energy"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+def",
        "fire"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+def",
        "ranged"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+def",
        "melee"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+def",
        "aoe"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+res",
        "smash"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+res",
        "energy"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "toggle",
        "+res",
        "fire"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+res",
        "smash"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+res",
        "energy"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "auto",
        "+res",
        "fire"
            }, ref Placed);
            this.mapDescString(new string[2] { "toggle", "+def" }, ref Placed);
            this.mapDescString(new string[2] { "toggle", "+res" }, ref Placed);
            this.mapDescString(new string[2] { "auto", "+def" }, ref Placed);
            this.mapDescString(new string[2] { "auto", "+res" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "disorient" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "stun" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "hold" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "sleep" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "AoE",
        "immobilize"
            }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "confuse" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "fear" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "Cone",
        "disorient"
            }, ref Placed);
            this.mapDescString(new string[2] { "Cone", "stun" }, ref Placed);
            this.mapDescString(new string[2] { "Cone", "hold" }, ref Placed);
            this.mapDescString(new string[2] { "Cone", "sleep" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "Cone",
        "immobilize"
            }, ref Placed);
            this.mapDescString(new string[2] { "Cone", "confuse" }, ref Placed);
            this.mapDescString(new string[2] { "Cone", "fear" }, ref Placed);
            this.mapDescString(new string[1] { "snipe" }, ref Placed);
            this.mapDescString(new string[3]
            {
        "AoE",
        "Extreme",
        "Self -Recovery"
            }, ref Placed);
            this.mapDescString(new string[2] { "close", "high" }, ref Placed);
            this.mapDescString(new string[3]
            {
        "ranged",
        "disorient",
        "minor"
            }, ref Placed);
            this.mapDescString(new string[2] { "ranged", "hold" }, ref Placed);
            this.mapDescString(new string[2] { "cone", "extreme" }, ref Placed);
            this.mapDescString(new string[2] { "cone", "superior" }, ref Placed);
            this.mapDescString(new string[2] { "cone", "high" }, ref Placed);
            this.mapDescString(new string[2] { "cone", "moderate" }, ref Placed);
            this.mapDescString(new string[2] { "cone", "minor" }, ref Placed);
            this.mapDescString(new string[3]
            {
        "ranged",
        "AoE",
        "extreme"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "ranged",
        "AoE",
        "superior"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "ranged",
        "AoE",
        "high"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "ranged",
        "AoE",
        "moderate"
            }, ref Placed);
            this.mapDescString(new string[3]
            {
        "ranged",
        "AoE",
        "minor"
            }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "extreme" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "superior" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "high" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "moderate" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "minor" }, ref Placed);
            this.mapDescString(new string[2] { "melee", "extreme" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "melee",
        "superior"
            }, ref Placed);
            this.mapDescString(new string[2] { "melee", "high" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "melee",
        "moderate"
            }, ref Placed);
            this.mapDescString(new string[2] { "melee", "minor" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "melee",
        "disorient"
            }, ref Placed);
            this.mapDescString(new string[2] { "melee", "stun" }, ref Placed);
            this.mapDescString(new string[2] { "melee", "hold" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "knockback" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "knockup" }, ref Placed);
            this.mapDescString(new string[2]
            {
        "Cone",
        "knockback"
            }, ref Placed);
            this.mapDescString(new string[2] { "Cone", "knockup" }, ref Placed);
            this.mapDescString(new string[2] { "AoE", "stealth" }, ref Placed);
            this.mapDescString(new string[1] { "stealth" }, ref Placed);
            this.mapDescString(new string[2] { "toggle", "-def" }, ref Placed);
            this.mapDescString(new string[2] { "toggle", "-res" }, ref Placed);
            this.mapDescString(new string[2] { "toggle", "-acc" }, ref Placed);
            this.mapDescString(new string[2] { "toggle", "-dmg" }, ref Placed);
            this.mapDescString(new string[1] { "-def" }, ref Placed);
            this.mapDescString(new string[1] { "-res" }, ref Placed);
            this.mapDescString(new string[1] { "-acc" }, ref Placed);
            this.mapDescString(new string[1] { "-dmg" }, ref Placed);
            this.mapDescString(new string[1] { "+dmg" }, ref Placed);
            this.mapDescString(new string[1] { "+acc" }, ref Placed);
            this.mapDescString(new string[2] { "heal", "team" }, ref Placed);
            this.mapDescString(new string[2] { "heal", "ally" }, ref Placed);
            this.mapDescString(new string[1] { "heal" }, ref Placed);
            this.mapDescString(new string[1] { "+recovery" }, ref Placed);
            this.mapDescString(new string[1] { "-recovery" }, ref Placed);
            this.mapDescString(new string[1] { "-regen" }, ref Placed);
            this.mapDescString(new string[1] { "extreme" }, ref Placed);
            this.mapDescString(new string[1] { "superior" }, ref Placed);
            this.mapDescString(new string[1] { "high" }, ref Placed);
            this.mapDescString(new string[1] { "moderate" }, ref Placed);
            this.mapDescString(new string[1] { "minor" }, ref Placed);
            this.mapDescString(new string[1] { "disorient" }, ref Placed);
            this.mapDescString(new string[1] { "stun" }, ref Placed);
            this.mapDescString(new string[1] { "hold" }, ref Placed);
            this.mapDescString(new string[1] { "sleep" }, ref Placed);
            this.mapDescString(new string[1] { "immobilize" }, ref Placed);
            this.mapDescString(new string[1] { "confuse" }, ref Placed);
            this.mapDescString(new string[1] { "fear" }, ref Placed);
            this.mapDescString(new string[1] { "cone" }, ref Placed);
            this.mapDescString(new string[1] { "aoe" }, ref Placed);
            this.mapDescString(new string[1] { "melee" }, ref Placed);
            this.mapDescString(new string[1] { "ranged" }, ref Placed);
            int num6 = this.Powers[1].Length - 1;
            for (int index = 0; index <= num6; ++index)
            {
                if (!Placed[index] && this.Map.Map[index, 1] == -1)
                {
                    this.Map.Map[index, 1] = index;
                    Placed[index] = true;
                }
            }
            int num7 = this.Powers[1].Length - 1;
            for (int index = 0; index <= num7; ++index)
            {
                if (!Placed[index])
                {
                    this.Map.Map[this.GetNextFreeSlot(), 1] = index;
                    Placed[index] = true;
                }
            }
        }

        public void map_Simple()
        {
            this.Map.Init();
            int Index = 0;
            do
            {
                this.Map.IdxAT[Index] = this.getAT(Index);
                this.Map.IdxSet[Index] = this.getSetIndex(Index);
                ++Index;
            }
            while (Index <= 1);
            int num1 = this.getMax(this.Powers[0].Length, this.Powers[1].Length);
            if (num1 > 20)
                num1 = 20;
            int num2 = num1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.Powers[0].Length > index)
                    this.Map.Map[index, 0] = index;
                if (this.Powers[1].Length > index)
                    this.Map.Map[index, 1] = index;
            }
        }

        public int mapDescString(string[] iStrings, ref bool[] Placed)
        {
            int num1 = 0;
            int num2 = this.Powers[1].Length - 1;
            for (int index1 = 0; index1 <= num2; ++index1)
            {
                bool flag1 = true;
                int num3 = iStrings.Length - 1;
                for (int index2 = 0; index2 <= num3; ++index2)
                {
                    if (this.Powers[1][index1].DescShort.IndexOf(iStrings[index2], StringComparison.OrdinalIgnoreCase) < 0)
                        flag1 = false;
                }
                if (flag1 & !Placed[index1])
                {
                    int num4 = this.Powers[0].Length - 1;
                    for (int index2 = 0; index2 <= num4; ++index2)
                    {
                        bool flag2 = this.Map.Map[index2, 1] < 0;
                        int num5 = iStrings.Length - 1;
                        for (int index3 = 0; index3 <= num5; ++index3)
                        {
                            if (this.Powers[0][index2].DescShort.IndexOf(iStrings[index3], StringComparison.OrdinalIgnoreCase) < 0)
                                flag2 = false;
                        }
                        if (flag2)
                        {
                            this.Map.Map[index2, 1] = index1;
                            Placed[index1] = true;
                            return index1;
                        }
                    }
                }
            }
            return num1;
        }

        public void mapOverride()
        {
            int num = MidsContext.Config.CompOverride.Length - 1;
            for (int index1 = 0; index1 <= num; ++index1)
            {
                var compOverride = MidsContext.Config.CompOverride;
                int index2 = index1;
                this.mapOverrideDo(compOverride[index2].Powerset, compOverride[index2].Power, compOverride[index2].Override);
            }
        }

        public void mapOverrideDo(string iSet, string iPower, string iNewStr)
        {
            int index1 = 0;
            do
            {
                int num = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num; ++index2)
                {
                    if (this.Powers[index1][index2].PowerSetID > -1 && string.Equals(this.Powers[index1][index2].DisplayName, iPower, StringComparison.OrdinalIgnoreCase) & string.Equals(DatabaseAPI.Database.Powersets[this.Powers[index1][index2].PowerSetID].DisplayName, iSet, StringComparison.OrdinalIgnoreCase))
                        this.Powers[index1][index2].DescShort = iNewStr.ToUpper();
                }
                ++index1;
            }
            while (index1 <= 1);
        }

        void ResetScale()

        {
            this.tbScaleX.Value = 10;
            this.Graph.Max = this.GraphMax;
            this.SetScaleLabel();
        }

        public void SetLocation()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = MainModule.MidsController.SzFrmCompare.X;
            rectangle.Y = MainModule.MidsController.SzFrmCompare.Y;
            if (rectangle.X < 1)
                rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - this.Width) / 2.0);
            if (rectangle.Y < 32)
                rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - this.Height) / 2.0);
            this.Top = rectangle.Y;
            this.Left = rectangle.X;
        }

        void SetScaleLabel()

        {
            this.lblScale.Text = "Scale: 0 - " + Conversions.ToString(this.Graph.ScaleValue);
        }

        void StoreLocation()

        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            MainModule.MidsController.SzFrmCompare.X = this.Left;
            MainModule.MidsController.SzFrmCompare.Y = this.Top;
        }

        void tbScaleX_Scroll(object sender, EventArgs e)

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
            if (!this.Loaded)
                return;
            this.ResetScale();
            this.DisplayGraph();
        }

        public void values_Accuracy()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    bool flag = false;
                    int num3 = this.Powers[index1][index2].Effects.Length - 1;
                    for (int index3 = 0; index3 <= num3; ++index3)
                    {
                        if (this.Powers[index1][index2].Effects[index3].RequiresToHitCheck)
                            flag = true;
                    }
                    this.Values[index1][index2] = !(this.Powers[index1][index2].EntitiesAutoHit == eEntity.None | flag) ? 0.0f : (float)((double)this.Powers[index1][index2].Accuracy * (double)MidsContext.Config.BaseAcc * 100.0);
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + Strings.Format(this.Values[index1][index2], "##0.##") + "% base Accuracy";
                        string[][] tips2 = this.Tips;
                        int index7 = index1;
                        int index8 = index2;
                        tips2[index7][index8] = tips2[index7][index8] + "\r\n  (Real Numbers style: " + Strings.Format(this.Powers[index1][index2].Accuracy, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "x)";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void values_Damage()
        {
            float num1 = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString();
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                        if (this.Powers[index1][index2].PowerType == ePowerType.Toggle)
                        {
                            string[][] tips2 = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips2[index3][index4] = tips2[index3][index4] + "\r\n  (Applied every " + Conversions.ToString(this.Powers[index1][index2].ActivatePeriod) + "s)";
                        }
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        public void values_DPA()
        {
            float num1 = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString() + "/s";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        public void values_DPE()
        {
            float num1 = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        if (this.Powers[index1][index2].PowerType == ePowerType.Click && (double)this.Powers[index1][index2].EndCost > 0.0)
                            this.Values[index1][index2] /= this.Powers[index1][index2].EndCost;
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString();
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                        string[][] tips2 = this.Tips;
                        int index7 = index1;
                        int index8 = index2;
                        tips2[index7][index8] = tips2[index7][index8] + " - DPE: " + Strings.Format(this.Values[index1][index2], "##0.##");
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        public void values_DPS()
        {
            float num1 = 1f;
            ConfigData.EDamageReturn returnValue = MidsContext.Config.DamageMath.ReturnValue;
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].FXGetDamageValue();
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].FXGetDamageString() + "/s";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Config.DamageMath.ReturnValue = returnValue;
        }

        public void values_Duration()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    int durationEffectId = this.Powers[index1][index2].GetDurationEffectID();
                    if (durationEffectId > -1)
                    {
                        this.Values[index1][index2] = this.Powers[index1][index2].Effects[durationEffectId].Duration;
                        if ((double)this.Values[index1][index2] != 0.0)
                        {
                            this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                            if (this.Matching)
                            {
                                string[][] tips = this.Tips;
                                int index3 = index1;
                                int index4 = index2;
                                tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                            }
                            string[][] tips1 = this.Tips;
                            int index5 = index1;
                            int index6 = index2;
                            tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].Effects[durationEffectId].BuildEffectString(false, "", false, false, false);
                            if ((double)num1 < (double)this.Values[index1][index2])
                                num1 = this.Values[index1][index2];
                        }
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void values_End()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].EndCost;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  End: " + Strings.Format(this.Powers[index1][index2].EndCost, "##0.##");
                        if (this.Powers[index1][index2].PowerType == ePowerType.Toggle)
                        {
                            string[][] tips2 = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips2[index3][index4] = tips2[index3][index4] + " (Per Second)";
                        }
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void values_EPS()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].EndCost;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        if (this.Powers[index1][index2].PowerType == ePowerType.Click)
                        {
                            if ((double)this.Powers[index1][index2].RechargeTime + (double)this.Powers[index1][index2].CastTime + (double)this.Powers[index1][index2].InterruptTime > 0.0)
                                this.Values[index1][index2] = this.Powers[index1][index2].EndCost / (this.Powers[index1][index2].RechargeTime + this.Powers[index1][index2].CastTime + this.Powers[index1][index2].InterruptTime);
                        }
                        else if (this.Powers[index1][index2].PowerType == ePowerType.Toggle)
                            this.Values[index1][index2] = this.Powers[index1][index2].EndCost / this.Powers[index1][index2].ActivatePeriod;
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  End: " + Strings.Format(this.Values[index1][index2], "##0.##");
                        string[][] tips2 = this.Tips;
                        int index7 = index1;
                        int index8 = index2;
                        tips2[index7][index8] = tips2[index7][index8] + "/s";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void values_Heal()
        {
            Archetype archetype = MidsContext.Archetype;
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
                    var effectMagSum = this.Powers[index1][index2].GetEffectMagSum(eEffectType.Heal, false, false, false, false);
                    this.Values[index1][index2] = effectMagSum.Sum;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = MidsContext.Archetype.DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + this.Powers[index1][index2].Effects[effectMagSum.Index[0]].BuildEffectString(false, "", false, false, false);
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Archetype = archetype;
        }

        public void values_HPE()
        {
            Archetype archetype = MidsContext.Archetype;
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(eEffectType.Heal, false, false, false, false);
                    this.Values[index1][index2] = effectMagSum.Sum;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        if ((double)this.Powers[index1][index2].EndCost > 0.0)
                            this.Values[index1][index2] /= this.Powers[index1][index2].EndCost;
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  Heal: " + Strings.Format(this.Values[index1][index2], "##0.##") + " HP per unit of end.";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Archetype = archetype;
        }

        public void values_HPS()
        {
            Archetype archetype = MidsContext.Archetype;
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(eEffectType.Heal, false, false, false, false);
                    this.Values[index1][index2] = effectMagSum.Sum;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        if (this.Powers[index1][index2].PowerType == ePowerType.Click && (double)this.Powers[index1][index2].RechargeTime + (double)this.Powers[index1][index2].CastTime + (double)this.Powers[index1][index2].InterruptTime > 0.0)
                            this.Values[index1][index2] /= this.Powers[index1][index2].RechargeTime + this.Powers[index1][index2].CastTime + this.Powers[index1][index2].InterruptTime;
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  Heal: " + Strings.Format(this.Values[index1][index2], "##0.##") + " HP/s";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Archetype = archetype;
        }

        public void values_MaxTargets()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = (float)this.Powers[index1][index2].MaxTargets;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        if ((double)this.Values[index1][index2] > 1.0)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + "\r\n  " + Conversions.ToString(this.Values[index1][index2]) + " Targets Max.";
                        }
                        else
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + "\r\n  " + Conversions.ToString(this.Values[index1][index2]) + " Target Max.";
                        }
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void values_Range()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    string str = "";
                    switch (this.Powers[index1][index2].EffectArea)
                    {
                        case eEffectArea.Character:
                            str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range.";
                            this.Values[index1][index2] = this.Powers[index1][index2].Range;
                            break;
                        case eEffectArea.Sphere:
                            this.Values[index1][index2] = this.Powers[index1][index2].Radius;
                            if ((double)this.Powers[index1][index2].Range > 0.0)
                            {
                                str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, ";
                                this.Values[index1][index2] = this.Powers[index1][index2].Range;
                            }
                            str = str + Conversions.ToString(this.Powers[index1][index2].Radius) + "ft radius.";
                            break;
                        case eEffectArea.Cone:
                            this.Values[index1][index2] = this.Powers[index1][index2].Range;
                            str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, " + Conversions.ToString(this.Powers[index1][index2].Arc) + " degree cone.";
                            break;
                        case eEffectArea.Location:
                            this.Values[index1][index2] = this.Powers[index1][index2].Range;
                            str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, " + Conversions.ToString(this.Powers[index1][index2].Radius) + "ft radius.";
                            break;
                        case eEffectArea.Volume:
                            this.Values[index1][index2] = this.Powers[index1][index2].Radius;
                            if ((double)this.Powers[index1][index2].Range > 0.0)
                            {
                                str = Conversions.ToString(this.Powers[index1][index2].Range) + "ft range, ";
                                this.Values[index1][index2] = this.Powers[index1][index2].Range;
                            }
                            str = str + Conversions.ToString(this.Powers[index1][index2].Radius) + "ft radius.";
                            break;
                    }
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + str;
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void values_Recharge()
        {
            float num1 = 1f;
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.Values[index1][index2] = this.Powers[index1][index2].RechargeTime;
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index3 = index1;
                            int index4 = index2;
                            tips[index3][index4] = tips[index3][index4] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        string[][] tips1 = this.Tips;
                        int index5 = index1;
                        int index6 = index2;
                        tips1[index5][index6] = tips1[index5][index6] + "\r\n  " + Strings.Format(this.Values[index1][index2], "##0.##") + "s";
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
        }

        public void Values_Universal(eEffectType iEffectType, bool Sum, bool Debuff)
        {
            Archetype archetype = MidsContext.Archetype;
            float num1 = 1f;
            string str = "";
            int index1 = 0;
            do
            {
                int num2 = this.Powers[index1].Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    MidsContext.Archetype = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID];
                    Enums.ShortFX effectMagSum = this.Powers[index1][index2].GetEffectMagSum(iEffectType, false, false, false, false);
                    int index3 = 0;
                    if (effectMagSum.Present)
                    {
                        if (Debuff)
                        {
                            int num3 = effectMagSum.Index.Length - 1;
                            for (int index4 = 0; index4 <= num3; ++index4)
                            {
                                if ((double)effectMagSum.Value[index4] > 0.0)
                                    effectMagSum.Value[index4] = 0.0f;
                                else
                                    effectMagSum.Value[index4] *= -1f;
                            }
                            effectMagSum.ReSum();
                            index3 = effectMagSum.Max;
                        }
                        else
                        {
                            int num3 = effectMagSum.Index.Length - 1;
                            for (int index4 = 0; index4 <= num3; ++index4)
                            {
                                if ((double)effectMagSum.Value[index4] < 0.0)
                                    effectMagSum.Value[index4] = 0.0f;
                            }
                            index3 = effectMagSum.Max;
                            effectMagSum.ReSum();
                        }
                    }
                    if (!Sum)
                    {
                        if (effectMagSum.Present)
                        {
                            str = this.GetUniversalTipString(effectMagSum, ref this.Powers[index1][index2]);
                            this.Values[index1][index2] = effectMagSum.Value[index3];
                            if (this.Powers[index1][index2].Effects[effectMagSum.Index[index3]].DisplayPercentage)
                                this.Values[index1][index2] *= 100f;
                        }
                    }
                    else
                    {
                        if (effectMagSum.Present && this.Powers[index1][index2].Effects[effectMagSum.Index[index3]].DisplayPercentage)
                            effectMagSum.Multiply();
                        this.Values[index1][index2] = effectMagSum.Sum;
                    }
                    if ((double)this.Values[index1][index2] != 0.0)
                    {
                        this.Tips[index1][index2] = DatabaseAPI.Database.Classes[this.Powers[index1][index2].ForcedClassID].DisplayName + ":" + this.Powers[index1][index2].DisplayName;
                        if (this.Matching)
                        {
                            string[][] tips = this.Tips;
                            int index4 = index1;
                            int index5 = index2;
                            tips[index4][index5] = tips[index4][index5] + " [Level " + Conversions.ToString(this.Powers[index1][index2].Level) + "]";
                        }
                        if (Sum)
                        {
                            str = "";
                            int num3 = effectMagSum.Index.Length - 1;
                            for (int index4 = 0; index4 <= num3; ++index4)
                            {
                                if (str != "")
                                    str += "\r\n";
                                str = str + "  " + this.Powers[index1][index2].Effects[effectMagSum.Index[index4]].BuildEffectString(false, "", false, false, false).Replace("\r\n", "\r\n  ");
                            }
                            string[][] tips = this.Tips;
                            int index5 = index1;
                            int index6 = index2;
                            tips[index5][index6] = tips[index5][index6] + "\r\n" + str;
                        }
                        else
                        {
                            string[][] tips = this.Tips;
                            int index4 = index1;
                            int index5 = index2;
                            tips[index4][index5] = tips[index4][index5] + "\r\n  " + str;
                        }
                        if ((double)num1 < (double)this.Values[index1][index2])
                            num1 = this.Values[index1][index2];
                    }
                }
                ++index1;
            }
            while (index1 <= 1);
            this.GraphMax = num1 * 1.025f;
            MidsContext.Archetype = archetype;
        }

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
            ToHitDeBuff,
        }
    }
}