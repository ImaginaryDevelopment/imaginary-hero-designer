
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class DataView : UserControl
    {
        const int SnapDistance = 10;

        protected const int szDataList = 104;
        protected const int szLargeText = 100;
        protected const int szLineHeight = 16;
        protected const int szPadding = 4;
        [AccessedThroughProperty("CtlDamageDisplay1")]
        ctlDamageDisplay _CtlDamageDisplay1;

        [AccessedThroughProperty("dbTip")]
        ToolTip _dbTip;

        GFXLabel Enh_Title;

        ctlPairedList enhListing;

        [AccessedThroughProperty("enhNameDisp")]
        GFXLabel _enhNameDisp;

        [AccessedThroughProperty("fx_lblHead1")]
        Label _fx_lblHead1;

        [AccessedThroughProperty("fx_lblHead2")]
        Label _fx_lblHead2;

        [AccessedThroughProperty("fx_LblHead3")]
        Label _fx_LblHead3;

        ctlPairedList fx_List1;

        ctlPairedList fx_List2;

        ctlPairedList fx_List3;

        GFXLabel fx_Title;

        [AccessedThroughProperty("gDef1")]
        ctlMultiGraph _gDef1;

        [AccessedThroughProperty("gDef2")]
        ctlMultiGraph _gDef2;

        [AccessedThroughProperty("gRes1")]
        ctlMultiGraph _gRes1;

        [AccessedThroughProperty("gRes2")]
        ctlMultiGraph _gRes2;

        [AccessedThroughProperty("info_Damage")]
        ctlDamageDisplay _info_Damage;

        ctlPairedList info_DataList;

        GFXLabel info_Title;

        [AccessedThroughProperty("info_txtLarge")]
        RichTextBox _info_txtLarge;

        [AccessedThroughProperty("info_txtSmall")]
        RichTextBox _info_txtSmall;

        [AccessedThroughProperty("lblDmg")]
        Label _lblDmg;

        Label lblFloat;

        Label lblLock;

        Label lblShrink;

        [AccessedThroughProperty("lblTotal")]
        Label _lblTotal;

        [AccessedThroughProperty("pnlEnh")]
        Panel _pnlEnh;

        Panel pnlEnhActive;

        Panel pnlEnhInactive;

        [AccessedThroughProperty("pnlFX")]
        Panel _pnlFX;

        [AccessedThroughProperty("pnlInfo")]
        Panel _pnlInfo;

        Panel pnlTabs;

        [AccessedThroughProperty("pnlTotal")]
        Panel _pnlTotal;

        ctlMultiGraph PowerScaler;

        [AccessedThroughProperty("total_lblDef")]
        Label _total_lblDef;

        [AccessedThroughProperty("total_lblMisc")]
        Label _total_lblMisc;

        [AccessedThroughProperty("total_lblRes")]
        Label _total_lblRes;

        ctlPairedList total_Misc;

        GFXLabel total_Title;

        bool bFloating;

        ExtendedBitmap bxFlip;

        bool Compact;

        IContainer components;

        int HistoryIDX;

        bool Lock;

        Point mouse_offset;

        public bool MoveDisable;
        string[] Pages;

        IPower pBase;

        IPower pEnh;

        int pLastScaleVal;

        Rectangle ScreenBounds;

        public Rectangle SnapLocation;
        public int TabPage;
        bool VillainColour;


        public event DataView.FloatChangeEventHandler FloatChange;

        public event DataView.MovedEventHandler Moved;

        public event DataView.SizeChangeEventHandler SizeChange;

        public event DataView.SlotFlipEventHandler SlotFlip;

        public event DataView.SlotUpdateEventHandler SlotUpdate;

        public event DataView.TabChangedEventHandler TabChanged;

        public event DataView.Unlock_ClickEventHandler Unlock_Click;

        ctlDamageDisplay CtlDamageDisplay1
        {
            get
            {
                return this._CtlDamageDisplay1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CtlDamageDisplay1 = value;
            }
        }

        ToolTip dbTip
        {
            get
            {
                return this._dbTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dbTip = value;
            }
        }

        public bool DrawVillain
        {
            get
            {
                return this.VillainColour;
            }
            set
            {
                this.VillainColour = value;
                if (!MidsContext.Config.ShowVillainColours)
                    this.VillainColour = false;
                if (this.VillainColour)
                    this.pnlInfo.BackColor = Color.Maroon;
                else
                    this.pnlInfo.BackColor = Color.Navy;
                this.DoPaint();
            }
        }
        GFXLabel enhNameDisp
        {
            get
            {
                return this._enhNameDisp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._enhNameDisp = value;
            }
        }

        public bool Floating
        {
            get
            {
                return this.bFloating;
            }
            set
            {
                this.bFloating = value;
                if (this.bFloating)
                {
                    this.dbTip.SetToolTip((Control)this.lblFloat, "Dock Info Display");
                    this.lblFloat.Text = "D";
                }
                else
                {
                    this.dbTip.SetToolTip((Control)this.lblFloat, "Make Floating Window");
                    this.lblFloat.Text = "F";
                }
            }
        }

        Label fx_lblHead1
        {
            get
            {
                return this._fx_lblHead1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fx_lblHead1 = value;
            }
        }

        Label fx_lblHead2
        {
            get
            {
                return this._fx_lblHead2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fx_lblHead2 = value;
            }
        }

        Label fx_LblHead3
        {
            get
            {
                return this._fx_LblHead3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fx_LblHead3 = value;
            }
        }
        ctlMultiGraph gDef1
        {
            get
            {
                return this._gDef1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gDef1 = value;
            }
        }

        ctlMultiGraph gDef2
        {
            get
            {
                return this._gDef2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gDef2 = value;
            }
        }

        ctlMultiGraph gRes1
        {
            get
            {
                return this._gRes1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gRes1 = value;
            }
        }

        ctlMultiGraph gRes2
        {
            get
            {
                return this._gRes2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._gRes2 = value;
            }
        }

        internal ctlDamageDisplay info_Damage
        {
            get
            {
                return this._info_Damage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            private set
            {
                this._info_Damage = value;
            }
        }
        internal RichTextBox info_txtLarge
        {
            get
            {
                return this._info_txtLarge;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._info_txtLarge = value;
            }
        }

        RichTextBox info_txtSmall
        {
            get
            {
                return this._info_txtSmall;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._info_txtSmall = value;
            }
        }

        public bool IsDocked
        {
            get
            {
                return this.SnapLocation.X == this.Location.X & this.SnapLocation.Y == this.Location.Y;
            }
        }

        Label lblDmg
        {
            get
            {
                return this._lblDmg;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDmg = value;
            }
        }
        Label lblTotal
        {
            get
            {
                return this._lblTotal;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblTotal = value;
            }
        }

        Panel pnlEnh
        {
            get
            {
                return this._pnlEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlEnh = value;
            }
        }
        Panel pnlFX
        {
            get
            {
                return this._pnlFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlFX = value;
            }
        }

        Panel pnlInfo
        {
            get
            {
                return this._pnlInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlInfo = value;
            }
        }
        Panel pnlTotal
        {
            get
            {
                return this._pnlTotal;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlTotal = value;
            }
        }
        public int TabPageIndex
        {
            get
            {
                return this.TabPage;
            }
        }

        Label total_lblDef
        {
            get
            {
                return this._total_lblDef;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._total_lblDef = value;
            }
        }

        Label total_lblMisc
        {
            get
            {
                return this._total_lblMisc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._total_lblMisc = value;
            }
        }

        Label total_lblRes
        {
            get
            {
                return this._total_lblRes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._total_lblRes = value;
            }
        }
        public Enums.eVisibleSize VisibleSize
        {
            get
            {
                return !this.Compact ? Enums.eVisibleSize.Full : Enums.eVisibleSize.Compact;
            }
            set
            {
            }
        }

        public DataView()
        {
            this.BackColorChanged += new EventHandler(this.DataView_BackColorChanged);
            this.Load += new EventHandler(this.DataView_Load);
            this.MoveDisable = false;
            this.TabPage = 0;
            this.Pages = new string[4]
            {
        "Info",
        "Effects",
        "Totals",
        "Enhance"
            };
            this.pLastScaleVal = -1;
            this.Lock = false;
            this.bFloating = false;
            this.HistoryIDX = -1;
            this.Compact = false;
            this.bxFlip = (ExtendedBitmap)null;
            this.InitializeComponent();
        }

        static ctlPairedList.ItemPair BuildEDItem(

          int index,
          float[] value,
          Enums.eSchedule[] schedule,
          string Name,
          float[] afterED)
        {
            bool flag1 = (double)value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][0];
            bool flag2 = (double)value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][1];
            bool iSpecialCase = (double)value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][2];
            ctlPairedList.ItemPair itemPair;
            if ((double)value[index] <= 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, string.Empty);
            }
            else
            {
                string iName = Name + ":";
                float num1 = value[index] * 100f;
                float num2 = Enhancement.ApplyED(schedule[index], value[index]) * 100f;
                float num3 = num2 + afterED[index] * 100f;
                float num4 = (float)Math.Round((double)num1 - (double)num2, 3);
                string str1 = Strings.Format((object)num1, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str2 = Strings.Format((object)num4, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str3 = Strings.Format((object)num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str4 = "Total Effect: " + Strings.Format((object)(float)((double)num1 + (double)afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\nWith ED Applied: " + str3 + "\r\n\r\n";
                string iValue;
                string iTip;
                if ((double)num4 > 0.0)
                {
                    iValue = str3 + "  (Pre-ED: " + Strings.Format((object)(float)((double)num1 + (double)afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%)";
                    if ((double)afterED[index] > 0.0)
                        str4 = str4 + "Amount from pre-ED sources: " + str1 + "\r\n";
                    iTip = str4 + "ED reduction: " + str2 + " (" + Strings.Format((object)(float)((double)num4 / (double)num1 * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "% of total)\r\n";
                    if (iSpecialCase)
                        iTip = iTip + "The highest level of ED reduction is being applied.\r\nThreshold: " + Strings.Format((object)(float)((double)DatabaseAPI.Database.MultED[(int)schedule[index]][2] * 100.0), "##0") + "%\r\n";
                    else if (flag2)
                        iTip = iTip + "The middle level of ED reduction is being applied.\r\nThreshold: " + Strings.Format((object)(float)((double)DatabaseAPI.Database.MultED[(int)schedule[index]][1] * 100.0), "##0") + "%\r\n";
                    else if (flag1)
                        iTip = iTip + "The lowest level of ED reduction is being applied.\r\nThreshold: " + Strings.Format((object)(float)((double)DatabaseAPI.Database.MultED[(int)schedule[index]][0] * 100.0), "##0") + "%\r\n";
                    if ((double)afterED[index] > 0.0)
                        iTip = iTip + "Amount from post-ED sources: " + Strings.Format((object)(float)((double)afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\n";
                }
                else
                {
                    iValue = str3;
                    if ((double)afterED[index] > 0.0)
                        str4 = str4 + "Amount from post-ED sources: " + Strings.Format((object)(float)((double)afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\n";
                    iTip = str4 + "This effect has not been affected by ED.\r\n";
                }
                itemPair = new ctlPairedList.ItemPair(iName, iValue, flag2 & !iSpecialCase, flag1 & !flag2, iSpecialCase, iTip);
            }
            return itemPair;
        }

        static string CapString(string iString, int capLength)

        {
            return iString.Length >= capLength ? iString.Substring(0, capLength) : iString;
        }

        public void Clear()
        {
            this.info_DataList.Clear(true);
            this.info_Title.Text = this.Pages[0];
            this.info_txtLarge.Text = string.Empty;
            this.info_txtSmall.Text = "Hold the mouse over a power to see its description.";
            this.PowerScaler.Visible = false;
            this.fx_lblHead1.Text = string.Empty;
            this.fx_lblHead2.Text = string.Empty;
            this.fx_LblHead3.Text = string.Empty;
            this.fx_List1.Clear(true);
            this.fx_List2.Clear(true);
            this.fx_List3.Clear(true);
            this.fx_Title.Text = this.Pages[1];
            this.enhListing.Clear(true);
            this.Enh_Title.Text = "Enhancements";
            this.total_Misc.Clear(true);
        }

        void CompactSize()

        {
            Size size = this.Size;
            this.info_txtSmall.Height = 16;
            this.info_txtLarge.Top = this.info_txtSmall.Bottom + 4;
            if (this.PowerScaler.Visible)
            {
                this.info_txtLarge.Height = 48 - this.PowerScaler.Height;
                this.PowerScaler.Top = this.info_txtLarge.Bottom;
                this.info_DataList.Top = this.PowerScaler.Bottom + 4;
            }
            else
            {
                this.info_txtLarge.Height = 48;
                this.PowerScaler.Top = this.info_txtLarge.Bottom - this.PowerScaler.Height;
                this.info_DataList.Top = this.info_txtLarge.Bottom + 4;
            }
            this.info_DataList.Height = 76;
            this.lblDmg.Visible = true;
            this.lblDmg.Top = this.info_DataList.Bottom + 4;
            this.info_Damage.Top = this.lblDmg.Bottom + 4;
            this.info_Damage.PaddingV = 1;
            this.info_Damage.Height = 30;
            this.enhListing.Height = this.info_Damage.Bottom - (this.enhListing.Top + (this.pnlEnhActive.Height + 4) * 2);
            this.pnlEnhActive.Top = this.enhListing.Bottom + 4;
            this.pnlEnhInactive.Top = this.pnlEnhActive.Bottom + 4;
            this.pnlInfo.Height = this.info_Damage.Bottom + 4;
            this.pnlEnh.Height = this.pnlInfo.Height;
            this.Height = this.pnlInfo.Bottom;
            this.Compact = true;
            if (!(this.Size != size))
                return;
            DataView.SizeChangeEventHandler sizeChange = this.SizeChange;
            if (sizeChange != null)
                sizeChange(this.Size, this.Compact);
        }

        void DataView_BackColorChanged(object sender, EventArgs e)

        {
            this.SetBackColor();
        }

        void DataView_Load(object sender, EventArgs e)
        {
            Panel pnlInfo = this.pnlInfo;
            pnlInfo.Top = 20;
            pnlInfo.Left = 0;
            Panel pnlFx = this.pnlFX;
            pnlFx.Top = 20;
            pnlFx.Left = 0;
            Panel pnlTotal = this.pnlTotal;
            pnlTotal.Top = 20;
            pnlTotal.Left = 0;
            Panel pnlEnh = this.pnlEnh;
            pnlEnh.Top = 20;
            pnlEnh.Left = 0;
            ctlDamageDisplay infoDamage = this.info_Damage;
            infoDamage.nBaseVal = 0.0f;
            infoDamage.nEnhVal = 0.0f;
            infoDamage.nHighBase = 0.0f;
            infoDamage.nHighEnh = 0.0f;
            infoDamage.nMaxEnhVal = 0.0f;
            this.info_txtLarge.Height = 100;
            this.Floating = this.bFloating;
            this.Clear();
        }

        void Display_EDFigures()

        {
            this.Enh_Title.Text = this.pBase.DisplayName;
            this.enhListing.Clear(false);
            if (MidsContext.Character == null)
            {
                this.enhListing.Draw();
            }
            else
            {
                int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
                if (inToonHistory < 0)
                {
                    this.enhListing.Draw();
                }
                else
                {
                    Enums.eEnhance eEnhance = Enums.eEnhance.None;
                    Enums.eMez eMez = Enums.eMez.None;
                    float[] numArray1 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] numArray2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] numArray3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    Enums.eSchedule[] schedule1 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    Enums.eSchedule[] schedule2 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    Enums.eSchedule[] schedule3 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] afterED1 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] afterED2 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] afterED3 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] numArray4 = new float[Enum.GetValues(eMez.GetType()).Length - 1 + 1];
                    Enums.eSchedule[] schedule4 = new Enums.eSchedule[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    float[] afterED4 = new float[Enum.GetValues(eEnhance.GetType()).Length - 1 + 1];
                    int num1 = numArray1.Length - 1;
                    for (int index = 0; index <= num1; ++index)
                    {
                        numArray1[index] = 0.0f;
                        numArray2[index] = 0.0f;
                        numArray3[index] = 0.0f;
                        schedule1[index] = Enhancement.GetSchedule((Enums.eEnhance)index, -1);
                        schedule2[index] = schedule1[index];
                        schedule3[index] = schedule1[index];
                    }
                    schedule2[3] = Enums.eSchedule.A;
                    int num2 = numArray4.Length - 1;
                    for (int tSub = 0; tSub <= num2; ++tSub)
                    {
                        numArray4[tSub] = 0.0f;
                        schedule4[tSub] = Enhancement.GetSchedule(Enums.eEnhance.Mez, tSub);
                    }
                    int num3 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
                    for (int index1 = 0; index1 <= num3; ++index1)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.Enh > -1)
                        {
                            int num4 = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.Enh].Effect.Length - 1;
                            for (int index2 = 0; index2 <= num4; ++index2)
                            {
                                Enums.sEffect[] effect = DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.Enh].Effect;
                                int index3 = index2;
                                if (effect[index3].Mode == Enums.eEffMode.Enhancement)
                                {
                                    if (effect[index3].Enhance.ID == 12)
                                    {
                                        numArray4[effect[index3].Enhance.SubID] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.GetEnhancementEffect(Enums.eEnhance.Mez, effect[index3].Enhance.SubID, 1f);
                                    }
                                    else
                                    {
                                        switch (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.Enh].Effect[index2].BuffMode)
                                        {
                                            case Enums.eBuffDebuff.BuffOnly:
                                                numArray1[effect[index3].Enhance.ID] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
                                                break;
                                            case Enums.eBuffDebuff.DeBuffOnly:
                                                if (effect[index3].Enhance.ID != 6 & effect[index3].Enhance.ID != 19 & effect[index3].Enhance.ID != 11)
                                                {
                                                    numArray2[effect[index3].Enhance.ID] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, -1f);
                                                    break;
                                                }
                                                break;
                                            default:
                                                numArray3[effect[index3].Enhance.ID] += MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index1].Enhancement.GetEnhancementEffect((Enums.eEnhance)effect[index3].Enhance.ID, -1, 1f);
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    int num5 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                    for (int index1 = 0; index1 <= num5; ++index1)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[index1].Power != null && MidsContext.Character.CurrentBuild.Powers[index1].StatInclude)
                        {
                            IPower power1 = (IPower)new Power(MidsContext.Character.CurrentBuild.Powers[index1].Power);
                            power1.AbsorbPetEffects(-1);
                            power1.ApplyGrantPowerEffects();
                            foreach (IEffect effect in power1.Effects)
                            {
                                if (!(power1.PowerType != Enums.ePowerType.GlobalBoost & (!effect.Absorbed_Effect | effect.Absorbed_PowerType != Enums.ePowerType.GlobalBoost)))
                                {
                                    IPower power2 = power1;
                                    if (effect.Absorbed_Effect & effect.Absorbed_Power_nID > -1)
                                        power2 = DatabaseAPI.Database.Power[effect.Absorbed_Power_nID];
                                    Enums.eBuffDebuff eBuffDebuff = Enums.eBuffDebuff.Any;
                                    bool flag = false;
                                    foreach (string str1 in MidsContext.Character.CurrentBuild.Powers[inToonHistory].Power.BoostsAllowed)
                                    {
                                        foreach (string str2 in power2.BoostsAllowed)
                                        {
                                            if (str1 == str2)
                                            {
                                                if (str1.Contains("Buff"))
                                                    eBuffDebuff = Enums.eBuffDebuff.BuffOnly;
                                                if (str1.Contains("Debuff"))
                                                    eBuffDebuff = Enums.eBuffDebuff.DeBuffOnly;
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (flag)
                                            break;
                                    }
                                    if (flag)
                                    {
                                        if (effect.EffectType == Enums.eEffectType.Enhancement)
                                        {
                                            switch (effect.ETModifies)
                                            {
                                                case Enums.eEffectType.Defense:
                                                    if (effect.DamageType == Enums.eDamage.Smashing)
                                                    {
                                                        if (effect.IgnoreED)
                                                        {
                                                            switch (eBuffDebuff)
                                                            {
                                                                case Enums.eBuffDebuff.BuffOnly:
                                                                    afterED1[3] += effect.Mag;
                                                                    break;
                                                                case Enums.eBuffDebuff.DeBuffOnly:
                                                                    afterED2[3] += effect.Mag;
                                                                    break;
                                                                default:
                                                                    afterED3[3] += effect.Mag;
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (eBuffDebuff)
                                                            {
                                                                case Enums.eBuffDebuff.BuffOnly:
                                                                    numArray1[3] += effect.Mag;
                                                                    break;
                                                                case Enums.eBuffDebuff.DeBuffOnly:
                                                                    numArray2[3] += effect.Mag;
                                                                    break;
                                                                default:
                                                                    numArray3[3] += effect.Mag;
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    break;
                                                case Enums.eEffectType.Mez:
                                                    if (effect.IgnoreED)
                                                    {
                                                        afterED4[(int)effect.MezType] += effect.Mag;
                                                        break;
                                                    }
                                                    numArray4[(int)effect.MezType] += effect.Mag;
                                                    break;
                                                default:
                                                    int index2 = effect.ETModifies != Enums.eEffectType.RechargeTime ? Conversions.ToInteger(Enum.Parse(typeof(Enums.eEnhance), effect.ETModifies.ToString())) : 14;
                                                    if (effect.IgnoreED)
                                                    {
                                                        afterED3[index2] += effect.Mag;
                                                        break;
                                                    }
                                                    numArray3[index2] += effect.Mag;
                                                    break;
                                            }
                                        }
                                        else if (effect.EffectType == Enums.eEffectType.DamageBuff & effect.DamageType == Enums.eDamage.Smashing)
                                        {
                                            if (effect.IgnoreED)
                                            {
                                                foreach (string str in power2.BoostsAllowed)
                                                {
                                                    if (str.StartsWith("Res_Damage"))
                                                    {
                                                        afterED3[18] += effect.Mag;
                                                        break;
                                                    }
                                                    if (str.StartsWith("Damage"))
                                                    {
                                                        afterED3[2] += effect.Mag;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (string str in power2.BoostsAllowed)
                                                {
                                                    if (str.StartsWith("Res_Damage"))
                                                    {
                                                        numArray3[18] += effect.Mag;
                                                        break;
                                                    }
                                                    if (str.StartsWith("Damage"))
                                                    {
                                                        numArray3[2] += effect.Mag;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    numArray1[8] = 0.0f;
                    numArray2[8] = 0.0f;
                    numArray3[8] = 0.0f;
                    numArray1[17] = 0.0f;
                    numArray2[17] = 0.0f;
                    numArray3[17] = 0.0f;
                    numArray1[16] = 0.0f;
                    numArray2[16] = 0.0f;
                    numArray3[16] = 0.0f;
                    int num6 = numArray1.Length - 1;
                    for (int index = 0; index <= num6; ++index)
                    {
                        if ((double)numArray1[index] > 0.0)
                        {
                            this.enhListing.AddItem(DataView.BuildEDItem(index, numArray1, schedule1, Enum.GetName(eEnhance.GetType(), (object)index), afterED1));
                            if (this.enhListing.IsSpecialColor())
                                this.enhListing.SetUnique();
                        }
                        if ((double)numArray2[index] > 0.0)
                        {
                            this.enhListing.AddItem(DataView.BuildEDItem(index, numArray2, schedule2, Enum.GetName(eEnhance.GetType(), (object)index) + " Debuff", afterED2));
                            if (this.enhListing.IsSpecialColor())
                                this.enhListing.SetUnique();
                        }
                        if ((double)numArray3[index] > 0.0)
                        {
                            this.enhListing.AddItem(DataView.BuildEDItem(index, numArray3, schedule3, Enum.GetName(eEnhance.GetType(), (object)index), afterED3));
                            if (this.enhListing.IsSpecialColor())
                                this.enhListing.SetUnique();
                        }
                    }
                    int num7 = numArray4.Length - 1;
                    for (int index = 0; index <= num7; ++index)
                    {
                        if ((double)numArray4[index] > 0.0)
                        {
                            this.enhListing.AddItem(DataView.BuildEDItem(index, numArray4, schedule4, Enum.GetName(eMez.GetType(), (object)index), afterED4));
                            if (this.enhListing.IsSpecialColor())
                                this.enhListing.SetUnique();
                        }
                    }
                    this.enhListing.Draw();
                    this.DisplayFlippedEnhancements();
                }
            }
        }

        void display_Info(bool NoLevel = false, int iEnhLvl = -1)

        {
            if (!NoLevel & this.pBase.Level > 0)
                this.info_Title.Text = "[" + Conversions.ToString(this.pBase.Level) + "] " + this.pBase.DisplayName;
            else
                this.info_Title.Text = this.pBase.DisplayName;
            if (iEnhLvl > -1)
            {
                GFXLabel infoTitle = this.info_Title;
                infoTitle.Text = infoTitle.Text + " (Slot Level " + Conversions.ToString(iEnhLvl + 1) + ")";
            }
            this.enhNameDisp.Text = "Enhancement Values";
            this.info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(this.pBase.DescShort) + RTF.EndRTF();
            this.info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(this.pBase.DescLong) + RTF.EndRTF();
            string Suffix1 = this.pBase.PowerType != Enums.ePowerType.Toggle ? string.Empty : "/s";
            this.info_DataList.Clear(false);
            string Tip1 = string.Empty;
            if (this.pBase.PowerType == Enums.ePowerType.Click)
            {
                if ((double)this.pEnh.ToggleCost > 0.0 & (double)this.pEnh.RechargeTime + (double)this.pEnh.CastTime + (double)this.pEnh.InterruptTime > 0.0)
                    Tip1 = "Effective end drain per second: " + Utilities.FixDP(this.pEnh.ToggleCost / (this.pEnh.RechargeTime + this.pEnh.CastTime + this.pEnh.InterruptTime)) + "/s";
                if ((double)this.pEnh.ToggleCost > 0.0 & MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.Numeric)
                {
                    float damageValue = this.pEnh.FXGetDamageValue();
                    if ((double)damageValue > 0.0)
                    {
                        if (Tip1 != string.Empty)
                            Tip1 += "\r\n";
                        Tip1 = Tip1 + "Effective damage per unit of end: " + Utilities.FixDP(damageValue / this.pEnh.ToggleCost);
                    }
                }
            }
            this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("End Cost", "End"), this.pBase.ToggleCost, this.pEnh.ToggleCost, Suffix1, Tip1));
            bool flag1 = false;
            if (this.pBase.HasAbsorbedEffects && this.pBase.PowerIndex > -1 && DatabaseAPI.Database.Power[this.pBase.PowerIndex].EntitiesAutoHit == Enums.eEntity.None)
                flag1 = true;
            bool flag2 = false;
            int num1 = this.pBase.Effects.Length - 1;
            for (int index = 0; index <= num1 & !flag2; ++index)
            {
                if (this.pBase.Effects[index].RequiresToHitCheck)
                    flag2 = true;
            }
            if (this.pBase.EntitiesAutoHit == Enums.eEntity.None | flag2 | flag1 | (double)this.pBase.Range > 20.0 & this.pBase.I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt))
            {
                float accuracy1 = this.pBase.Accuracy;
                float accuracy2 = this.pEnh.Accuracy;
                float num2 = MidsContext.Config.BaseAcc * this.pBase.Accuracy;
                string str = string.Empty;
                string Suffix2 = "%";
                if (this.pBase.EntitiesAutoHit != Enums.eEntity.None & flag2)
                {
                    str = "\r\n* This power is autohit, but has an effect that requires a ToHit roll.";
                    Suffix2 += "*";
                }
                if ((double)accuracy1 != (double)accuracy2 & (double)num2 != (double)accuracy2)
                {
                    string Tip2 = "Accuracy multiplier without other buffs (Real Numbers style): " + Strings.Format((object)(float)((double)this.pBase.Accuracy + ((double)this.pEnh.Accuracy - (double)MidsContext.Config.BaseAcc)), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000") + "x" + str;
                    this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Accuracy", "Acc"), (float)((double)MidsContext.Config.BaseAcc * (double)this.pBase.Accuracy * 100.0), this.pEnh.Accuracy * 100f, Suffix2, Tip2));
                }
                else
                {
                    string Tip2 = "Accuracy multiplier without other buffs (Real Numbers style): " + Strings.Format((object)this.pBase.AccuracyMult, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "x" + str;
                    this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Accuracy", "Acc"), (float)((double)MidsContext.Config.BaseAcc * (double)this.pBase.Accuracy * 100.0), (float)((double)MidsContext.Config.BaseAcc * (double)this.pBase.Accuracy * 100.0), Suffix2, Tip2));
                }
            }
            else
                this.info_DataList.AddItem(new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, string.Empty));
            this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Recharge", "Rchg"), this.pBase.RechargeTime, this.pEnh.RechargeTime, "s"));
            float s1 = 0.0f;
            float s2 = 0.0f;
            int durationEffectId = this.pBase.GetDurationEffectID();
            if (durationEffectId > -1)
            {
                if (this.pBase.Effects[durationEffectId].EffectType == Enums.eEffectType.EntCreate & (double)this.pBase.Effects[durationEffectId].Duration >= 9999.0)
                {
                    s1 = 0.0f;
                    s2 = 0.0f;
                }
                else
                {
                    s1 = this.pBase.Effects[durationEffectId].Duration;
                    s2 = this.pEnh.Effects[durationEffectId].Duration;
                }
            }
            this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Duration", "Durtn"), s1, s2, "s"));
            this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Range", "Range"), this.pBase.Range, this.pEnh.Range, string.Empty));
            if (this.pBase.Arc > 0)
                this.info_DataList.AddItem(DataView.FastItem("Arc", (float)this.pBase.Arc, (float)this.pEnh.Arc, "°"));
            else
                this.info_DataList.AddItem(DataView.FastItem("Radius", this.pBase.Radius, this.pEnh.Radius, string.Empty));
            this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Cast Time", "Cast"), this.pBase.CastTime, this.pEnh.CastTime, "s", false, true, false, false, -1, 3));
            if (this.pBase.PowerType == Enums.ePowerType.Toggle)
                this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Activate", "Act"), this.pBase.ActivatePeriod, this.pEnh.ActivatePeriod, "s", "The effects of this toggle power are applied at this interval."));
            else
                this.info_DataList.AddItem(DataView.FastItem(this.ShortStr("Interrupt", "Intrpt"), this.pBase.InterruptTime, this.pEnh.InterruptTime, "s", "After activating this power, it can be interrupted for this amount of time."));
            int num3 = 2;
            if (num3 > 1 && durationEffectId > -1 && this.pBase.Effects[durationEffectId].EffectType == Enums.eEffectType.Mez & this.pBase.Effects[durationEffectId].MezType != Enums.eMez.Taunt)
            {
                this.info_DataList.AddItem(new ctlPairedList.ItemPair("Effect:", Enum.GetName(Enums.eMez.None.GetType(), (object)this.pBase.Effects[durationEffectId].MezType), false, (double)this.pBase.Effects[durationEffectId].Probability < 1.0, this.pBase.Effects[durationEffectId].SpecialCase != Enums.eSpecialCase.None, durationEffectId));
                bool iAlternate = (double)this.pBase.Effects[durationEffectId].Mag != (double)this.pEnh.Effects[durationEffectId].Mag;
                this.info_DataList.AddItem(new ctlPairedList.ItemPair("Mag:", Conversions.ToString(this.pEnh.Effects[durationEffectId].Mag), iAlternate, (double)this.pBase.Effects[durationEffectId].Probability < 1.0, false, -1));
                num3 -= 2;
            }
            int[] rankedEffects = this.pBase.GetRankedEffects();
            int num4 = rankedEffects.Length - 1;
            for (int ID = 0; ID <= num4; ++ID)
            {
                if (num3 > 0 && rankedEffects[ID] > -1)
                {
                    ctlPairedList.ItemPair rankedEffect = this.GetRankedEffect(rankedEffects, ID);
                    if ((double)this.pBase.Effects[rankedEffects[ID]].Probability > 0.0 & (MidsContext.Config.Suppression & this.pBase.Effects[rankedEffects[ID]].Suppression) == Enums.eSuppress.None & this.pBase.Effects[rankedEffects[ID]].CanInclude())
                    {
                        if (this.pBase.Effects[rankedEffects[ID]].EffectType != Enums.eEffectType.Enhancement)
                        {
                            if (this.pBase.Effects[rankedEffects[ID]].EffectType != Enums.eEffectType.Mez)
                            {
                                if (this.pBase.Effects[rankedEffects[ID]].EffectType == Enums.eEffectType.EntCreate)
                                {
                                    rankedEffect.Name = "Summon";
                                    if (this.pBase.Effects[rankedEffects[ID]].nSummon > -1)
                                    {
                                        rankedEffect.Value = DatabaseAPI.Database.Entities[this.pBase.Effects[rankedEffects[ID]].nSummon].DisplayName;
                                    }
                                    else
                                    {
                                        rankedEffect.Value = this.pBase.Effects[rankedEffects[ID]].Summon;
                                        if (rankedEffect.Value.StartsWith("MastermindPets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("MastermindPets_", string.Empty);
                                        if (rankedEffect.Value.StartsWith("Pets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("Pets_", string.Empty);
                                        if (rankedEffect.Value.StartsWith("Villain_Pets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("Villain_Pets_", string.Empty);
                                    }
                                    --num3;
                                }
                                else if (this.pBase.Effects[rankedEffects[ID]].EffectType == Enums.eEffectType.RevokePower)
                                {
                                    rankedEffect.Name = "Revoke";
                                    if (this.pBase.Effects[rankedEffects[ID]].nSummon > -1)
                                    {
                                        rankedEffect.Value = DatabaseAPI.Database.Entities[this.pBase.Effects[rankedEffects[ID]].nSummon].DisplayName;
                                    }
                                    else
                                    {
                                        rankedEffect.Value = this.pBase.Effects[rankedEffects[ID]].Summon;
                                        if (rankedEffect.Value.StartsWith("MastermindPets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("MastermindPets_", string.Empty);
                                        if (rankedEffect.Value.StartsWith("Pets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("Pets_", string.Empty);
                                        if (rankedEffect.Value.StartsWith("Villain_Pets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("Villain_Pets_", string.Empty);
                                    }
                                    --num3;
                                }
                                else
                                    rankedEffect.Name = this.ShortStr(Enums.GetEffectName(this.pBase.Effects[rankedEffects[ID]].EffectType), Enums.GetEffectNameShort(this.pBase.Effects[rankedEffects[ID]].EffectType));
                            }
                            else
                                rankedEffect.Name = this.ShortStr(Enums.GetMezName((Enums.eMezShort)this.pBase.Effects[rankedEffects[ID]].MezType), Enums.GetMezNameShort((Enums.eMezShort)this.pBase.Effects[rankedEffects[ID]].MezType));
                        }
                        this.info_DataList.AddItem(rankedEffect);
                        if (this.pBase.Effects[rankedEffects[ID]].isEnahncementEffect)
                            this.info_DataList.SetUnique();
                        --num3;
                    }
                }
            }
            this.info_DataList.Draw();
            string str1 = "Damage";
            switch (MidsContext.Config.DamageMath.ReturnValue)
            {
                case ConfigData.EDamageReturn.DPS:
                    str1 += " Per Second";
                    break;
                case ConfigData.EDamageReturn.DPA:
                    str1 += " Per Animation Second";
                    break;
            }
            if (MidsContext.Config.DataDamageGraphPercentageOnly)
                str1 += " (% only)";
            float damageValue1 = this.pBase.FXGetDamageValue();
            if (this.pBase.NIDSubPower.Length > 0 & (double)damageValue1 == 0.0)
            {
                this.lblDmg.Text = string.Empty;
                this.info_Damage.nBaseVal = 0.0f;
                this.info_Damage.nMaxEnhVal = 0.0f;
                this.info_Damage.nEnhVal = 0.0f;
                this.info_Damage.Text = string.Empty;
            }
            else
            {
                this.lblDmg.Text = str1 + ":";
                float damageValue2 = this.pEnh.FXGetDamageValue();
                float num2 = damageValue1 * (1f + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
                this.info_Damage.nBaseVal = damageValue1;
                this.info_Damage.nMaxEnhVal = num2;
                this.info_Damage.nEnhVal = damageValue2;
                if ((double)damageValue2 != (double)damageValue1)
                    this.info_Damage.Text = this.pEnh.FXGetDamageString() + " (" + Utilities.FixDP(damageValue1) + ")";
                else
                    this.info_Damage.Text = this.pBase.FXGetDamageString();
            }
            this.SetPowerScaler();
        }

        void DisplayData(bool noLevel = false, int iEnhLevel = -1)

        {
            if (MidsContext.Config.DataDamageGraph)
            {
                this.info_Damage.GraphType = MidsContext.Config.DataGraphType;
                switch (MidsContext.Config.DataGraphType)
                {
                    case Enums.eDDGraph.Simple:
                        ctlDamageDisplay infoDamage1 = this.info_Damage;
                        infoDamage1.TextAlign = Enums.eDDAlign.Center;
                        infoDamage1.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                    case Enums.eDDGraph.Enhanced:
                        ctlDamageDisplay infoDamage2 = this.info_Damage;
                        infoDamage2.TextAlign = Enums.eDDAlign.Center;
                        infoDamage2.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                    case Enums.eDDGraph.Both:
                        ctlDamageDisplay infoDamage3 = this.info_Damage;
                        infoDamage3.TextAlign = Enums.eDDAlign.Center;
                        infoDamage3.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                    case Enums.eDDGraph.Stacked:
                        ctlDamageDisplay infoDamage4 = this.info_Damage;
                        infoDamage4.TextAlign = Enums.eDDAlign.Center;
                        infoDamage4.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                }
            }
            else
            {
                ctlDamageDisplay infoDamage = this.info_Damage;
                infoDamage.TextAlign = Enums.eDDAlign.Center;
                infoDamage.Style = Enums.eDDStyle.Text;
            }
            this.lblLock.Visible = this.Lock & this.TabPage != 2;
            this.display_Info(noLevel, iEnhLevel);
            this.DisplayEffects(noLevel, iEnhLevel);
            this.Display_EDFigures();
        }

        void DisplayEffects(bool noLevel = false, int iEnhLvl = -1)

        {
            if (!noLevel & this.pBase.Level > 0)
                this.fx_Title.Text = "[" + Conversions.ToString(this.pBase.Level) + "] " + this.pBase.DisplayName;
            else
                this.fx_Title.Text = this.pBase.DisplayName;
            if (iEnhLvl > -1)
            {
                GFXLabel fxTitle = this.fx_Title;
                fxTitle.Text = fxTitle.Text + " (Slot Level " + Conversions.ToString(iEnhLvl + 1) + ")";
            }
            ctlPairedList[] ctlPairedListArray = new ctlPairedList[3]
            {
        this.fx_List1,
        this.fx_List2,
        this.fx_List3
            };
            Label[] labelArray = new Label[3]
            {
        this.fx_lblHead1,
        this.fx_lblHead2,
        this.fx_LblHead3
            };
            this.fx_List1.Clear(false);
            this.fx_List2.Clear(false);
            this.fx_List3.Clear(false);
            this.fx_lblHead1.Text = string.Empty;
            this.fx_lblHead2.Text = string.Empty;
            this.fx_LblHead3.Text = string.Empty;
            int index = this.EffectsDrh();
            int num1 = 0;
            bool flag1 = false;
            bool flag2 = false;
            if (index < ctlPairedListArray.Length)
            {
                ctlPairedListArray[index].Clear(false);
                num1 = this.effects_Heal(labelArray[index], ctlPairedListArray[index]);
                if (num1 > 0)
                {
                    flag2 = true;
                    ++index;
                    if (index < ctlPairedListArray.Length)
                        ctlPairedListArray[index].Clear(false);
                }
            }
            if (index < ctlPairedListArray.Length)
            {
                num1 = this.effects_Status(labelArray[index], ctlPairedListArray[index]);
                if (num1 > 0)
                    flag1 = true;
                if (num1 > 2 | num1 > 0 & index == 0)
                {
                    ++index;
                    if (index < ctlPairedListArray.Length)
                        ctlPairedListArray[index].Clear(false);
                }
            }
            if (!flag1 & flag2 & num1 < 3)
                --index;
            if (index < ctlPairedListArray.Length && this.effects_BuffDebuff(labelArray[index], ctlPairedListArray[index]) > 0 & ctlPairedListArray[index].ItemCount > 2 & index + 1 < ctlPairedListArray.Length)
            {
                ++index;
                if (index < ctlPairedListArray.Length)
                    ctlPairedListArray[index].Clear(false);
            }
            if (index < ctlPairedListArray.Length)
                index += this.effects_Movement(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
                index += this.effects_Summon(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
                index += this.effects_GrantPower(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
                index += this.effects_ModifyEffect(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
            {
                int num2 = index + this.effects_Elusivity(labelArray[index], ctlPairedListArray[index]);
            }
            if (this.fx_lblHead1.Text != string.Empty)
                this.fx_lblHead1.Text += ":";
            if (this.fx_lblHead2.Text != string.Empty)
                this.fx_lblHead2.Text += ":";
            if (this.fx_LblHead3.Text != string.Empty)
                this.fx_LblHead3.Text += ":";
            this.fx_List1.Draw();
            this.fx_List2.Draw();
            this.fx_List3.Draw();
        }

        void DisplayFlippedEnhancements()

        {
            Pen pen = this.enhListing.BackColor.B <= (byte)10 ? new Pen(Color.FromArgb((int)byte.MaxValue, 0, 0)) : new Pen(Color.FromArgb(0, 0, (int)byte.MaxValue));
            if (this.bxFlip == null)
                this.bxFlip = new ExtendedBitmap(this.pnlEnhActive.Width, this.pnlEnhInactive.Height * 2);
            this.bxFlip.Graphics.Clear(this.enhListing.BackColor);
            this.bxFlip.Graphics.DrawRectangle(pen, 0, 0, this.pnlEnhActive.Width - 1, this.pnlEnhInactive.Height - 1);
            this.bxFlip.Graphics.DrawRectangle(pen, 0, this.pnlEnhInactive.Height, this.pnlEnhActive.Width - 1, this.pnlEnhInactive.Height - 1);
            if (this.pBase == null)
                return;
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
            if (inToonHistory < 0)
            {
                this.RedrawFlip();
            }
            else
            {
                StringFormat format = new StringFormat();
                int num1 = this.bxFlip.Size.Width - 188;
                Rectangle rectangle1 = new Rectangle();
                ref Rectangle local1 = ref rectangle1;
                int width = num1;
                Size size = this.bxFlip.Size;
                int height = (int)Math.Round((double)size.Height / 2.0);
                local1 = new Rectangle(-4, 0, width, height);
                SolidBrush solidBrush1 = new SolidBrush(this.enhListing.NameColor);
                format.Alignment = StringAlignment.Far;
                format.LineAlignment = StringAlignment.Center;
                this.bxFlip.Graphics.DrawString("Active Slotting:", this.pnlEnhActive.Font, (Brush)solidBrush1, (RectangleF)rectangle1, format);
                rectangle1.Y += rectangle1.Height;
                this.bxFlip.Graphics.DrawString("Alternate:", this.pnlEnhActive.Font, (Brush)solidBrush1, (RectangleF)rectangle1, format);
                ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MidsContext.Character.IsHero());
                SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                int num2 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    Rectangle iDest = new Rectangle();
                    ref Rectangle local2 = ref iDest;
                    int x1 = num1 + 30 * index;
                    size = this.bxFlip.Size;
                    int y1 = (int)Math.Round(((double)size.Height / 2.0 - 30.0) / 2.0);
                    local2 = new Rectangle(x1, y1, 30, 30);
                    Rectangle rectangle2 = new Rectangle();
                    ref Rectangle local3 = ref rectangle2;
                    int x2 = num1 + 30 * index;
                    size = this.bxFlip.Size;
                    double num3 = (double)size.Height / 2.0;
                    size = this.bxFlip.Size;
                    double num4 = ((double)size.Height / 2.0 - 30.0) / 2.0;
                    int y2 = (int)Math.Round(num3 + num4);
                    local3 = new Rectangle(x2, y2, 30, 30);
                    RectangleF Bounds;
                    Rectangle destRect;
                    if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
                    {
                        Graphics graphics1 = this.bxFlip.Graphics;
                        I9Gfx.DrawEnhancementAt(ref graphics1, iDest, DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Grade));
                        if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
                        {
                            if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.InventO))
                            {
                                Bounds = (RectangleF)iDest;
                                Bounds.Y -= 3f;
                                Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
                                Graphics graphics2 = this.bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.IOLevel + 1), Bounds, Color.Cyan, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
                            }
                            else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.SpecialO))
                            {
                                Bounds = (RectangleF)iDest;
                                Bounds.Y -= 3f;
                                Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
                                Color Text = MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel != Enums.eEnhRelative.None ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel >= Enums.eEnhRelative.Even ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel <= Enums.eEnhRelative.Even ? Color.White : Color.FromArgb(0, (int)byte.MaxValue, (int)byte.MaxValue)) : Color.Yellow) : Color.Red;
                                Graphics graphics2 = this.bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols), Bounds, Text, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
                            }
                        }
                    }
                    else
                    {
                        destRect = new Rectangle(iDest.X, iDest.Y, 30, 30);
                        this.bxFlip.Graphics.DrawImage((Image)I9Gfx.EnhTypes.Bitmap, destRect, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                    }
                    if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh > -1)
                    {
                        Graphics graphics1 = this.bxFlip.Graphics;
                        I9Gfx.DrawEnhancementAt(ref graphics1, rectangle2, DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Grade));
                        if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh > -1)
                        {
                            if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.InventO))
                            {
                                Bounds = (RectangleF)rectangle2;
                                Bounds.Y -= 3f;
                                Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
                                Graphics graphics2 = this.bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.IOLevel + 1), Bounds, Color.Cyan, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
                            }
                            else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.SpecialO))
                            {
                                Bounds = (RectangleF)rectangle2;
                                Bounds.Y -= 3f;
                                Bounds.Height = Control.DefaultFont.GetHeight(this.bxFlip.Graphics);
                                Color Text = MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel != Enums.eEnhRelative.None ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel >= Enums.eEnhRelative.Even ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel <= Enums.eEnhRelative.Even ? Color.White : Color.FromArgb(0, (int)byte.MaxValue, (int)byte.MaxValue)) : Color.Yellow) : Color.Red;
                                Graphics graphics2 = this.bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols), Bounds, Text, Color.FromArgb(128, 0, 0, 0), this.pnlEnhActive.Font, 1f, ref graphics2, false, false);
                            }
                        }
                    }
                    else
                    {
                        destRect = new Rectangle(rectangle2.X, rectangle2.Y, 30, 30);
                        this.bxFlip.Graphics.DrawImage((Image)I9Gfx.EnhTypes.Bitmap, destRect, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                    }
                    rectangle2.Inflate(2, 2);
                    this.bxFlip.Graphics.FillEllipse((Brush)solidBrush2, rectangle2);
                }
                this.RedrawFlip();
            }
        }

        public void DisplayTotals()
        {
            if (MidsContext.Character == null)
                return;
            string[] names = Enum.GetNames(Enums.eDamage.None.GetType());
            this.total_Misc.Clear(false);
            Statistics displayStats = MidsContext.Character.DisplayStats;
            this.gDef1.Clear();
            this.gDef2.Clear();
            int[] numArray1 = new int[16]
            {
        0,
        0,
        0,
        1,
        1,
        0,
        0,
        1,
        0,
        0,
        1,
        1,
        1,
        0,
        0,
        0
            };
            int num1 = names.Length - 1;
            for (int dType = 1; dType <= num1; ++dType)
            {
                string iTip = Strings.Format((object)displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType] + " defense";
                if (dType != 9 & dType != 7)
                {
                    if (numArray1[dType] == 0)
                        this.gDef1.AddItem(names[dType] + ":|" + Strings.Format((object)displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.Defense(dType), 0.0f, iTip);
                    else
                        this.gDef2.AddItem(names[dType] + ":|" + Strings.Format((object)displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.Defense(dType), 0.0f, iTip);
                }
            }
            float num2 = this.gDef1.GetMaxValue();
            float maxValue1 = this.gDef2.GetMaxValue();
            if ((double)maxValue1 > (double)num2)
                num2 = maxValue1;
            this.gDef1.Max = num2;
            this.gDef2.Max = num2;
            this.gDef1.Draw();
            this.gDef2.Draw();
            string str = MidsContext.Character.Archetype.DisplayName + " resistance cap: " + Strings.Format((object)(float)((double)MidsContext.Character.Archetype.ResCap * 100.0), "###0") + "%";
            string empty = string.Empty;
            this.gRes1.Clear();
            this.gRes2.Clear();
            int[] numArray2 = new int[13]
            {
        0,
        0,
        0,
        1,
        1,
        0,
        0,
        1,
        1,
        0,
        1,
        1,
        1
            };
            int dType1 = 1;
            do
            {
                if (dType1 != 9)
                {
                    string iTip;
                    if ((double)MidsContext.Character.TotalsCapped.Res[dType1] < (double)MidsContext.Character.Totals.Res[dType1])
                        iTip = Strings.Format((object)displayStats.DamageResistance(dType1, true), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType1] + " resistance capped at " + Strings.Format((object)displayStats.DamageResistance(dType1, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "%";
                    else
                        iTip = Strings.Format((object)displayStats.DamageResistance(dType1, true), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType1] + " resistance. (" + str + ")";
                    if (numArray2[dType1] == 0)
                        this.gRes1.AddItem(names[dType1] + ":|" + Strings.Format((object)displayStats.DamageResistance(dType1, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.DamageResistance(dType1, false), displayStats.DamageResistance(dType1, true), iTip);
                    else
                        this.gRes2.AddItem(names[dType1] + ":|" + Strings.Format((object)displayStats.DamageResistance(dType1, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.DamageResistance(dType1, false), displayStats.DamageResistance(dType1, true), iTip);
                }
                ++dType1;
            }
            while (dType1 <= 9);
            float num3 = this.gRes1.GetMaxValue();
            float maxValue2 = this.gRes2.GetMaxValue();
            if ((double)maxValue2 > (double)num3)
                num3 = maxValue2;
            this.gRes1.Max = num3;
            this.gRes2.Max = num3;
            this.gRes1.Draw();
            this.gRes2.Draw();
            string iTip1 = string.Empty;
            string iTip2 = "Time to go from 0-100% end: " + Utilities.FixDP(displayStats.EnduranceTimeToFull) + "s.\r\nHover the mouse over the End Drain stats for more info.";
            if ((double)displayStats.EnduranceRecoveryNet > 0.0)
            {
                iTip1 = "Net Endurance Gain (Recovery - Drain): " + Utilities.FixDP(displayStats.EnduranceRecoveryNet) + "/s.";
                if ((double)displayStats.EnduranceRecoveryNet != (double)displayStats.EnduranceRecoveryNumeric)
                    iTip1 = iTip1 + "\r\nTime to go from 0-100% end (using net gain): " + Utilities.FixDP(displayStats.EnduranceTimeToFullNet) + "s.";
            }
            else if ((double)displayStats.EnduranceRecoveryNet < 0.0)
                iTip1 = "With current end drain, you will lose end at a rate of: " + Utilities.FixDP(displayStats.EnduranceRecoveryLossNet) + "/s.\r\nFrom 100% you would run out of end in: " + Utilities.FixDP(displayStats.EnduranceTimeToZero) + "s.";
            string iTip3 = "Time to go from 0-100% health: " + Utilities.FixDP(displayStats.HealthRegenTimeToFull) + "s.\r\nHealth regenerated per second: " + Utilities.FixDP(displayStats.HealthRegenHealthPerSec) + "%\r\nHitPoints regenerated per second at level 50: " + Utilities.FixDP(displayStats.HealthRegenHPPerSec) + " HP";
            this.total_Misc.AddItem(new ctlPairedList.ItemPair("Recovery:", Strings.Format((object)displayStats.EnduranceRecoveryPercentage(false), "###0") + "% (" + Strings.Format((object)displayStats.EnduranceRecoveryNumeric, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s)", false, false, false, iTip2));
            this.total_Misc.AddItem(new ctlPairedList.ItemPair("Regen:", Strings.Format((object)displayStats.HealthRegenPercent(false), "###0") + "%", false, false, false, iTip3));
            this.total_Misc.AddItem(new ctlPairedList.ItemPair("EndDrain:", Strings.Format((object)displayStats.EnduranceUsage, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s", false, false, false, iTip1));
            this.total_Misc.AddItem(new ctlPairedList.ItemPair("+ToHit:", Strings.Format((object)displayStats.BuffToHit, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "This effect is increasing the accuracy of all your powers."));
            this.total_Misc.AddItem(new ctlPairedList.ItemPair("+EndRdx:", Strings.Format((object)displayStats.BuffEndRdx, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "The end cost of all your powers is being reduced by this effect.\r\nThis is applied like an end-reduction enhancement."));
            this.total_Misc.AddItem(new ctlPairedList.ItemPair("+Recharge:", Strings.Format((object)(float)((double)displayStats.BuffHaste(false) - 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "The recharge time of your powers is being altered by this effect.\r\nThe higher the value, the faster the recharge."));
            this.total_Misc.Draw();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            try
            {
                bxFlip?.Dispose();
            }
            catch { }
            base.Dispose(disposing);
        }

        void DoPaint()

        {
            Graphics graphics = this.pnlTabs.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            Font font1 = new Font(this.Font, FontStyle.Regular);
            Font font2 = new Font(this.Font, FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            SolidBrush solidBrush1 = new SolidBrush(Color.White);
            SolidBrush solidBrush2 = new SolidBrush(this.BackColor);
            SolidBrush solidBrush3 = new SolidBrush(Color.Black);
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.pnlTabs.Size);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Rectangle rect = new Rectangle(0, 0, 75, this.pnlTabs.Height);
            extendedBitmap.Graphics.FillRectangle((Brush)solidBrush2, extendedBitmap.ClipRect);
            switch (this.TabPage)
            {
                case 0:
                    this.pnlInfo.Visible = true;
                    this.pnlFX.Visible = false;
                    this.pnlTotal.Visible = false;
                    this.pnlEnh.Visible = false;
                    this.lblLock.Visible = this.Lock;
                    solidBrush3 = new SolidBrush(this.pnlInfo.BackColor);
                    pen = new Pen(this.pnlInfo.BackColor, 1f);
                    break;
                case 1:
                    this.pnlInfo.Visible = false;
                    this.pnlFX.Visible = true;
                    this.pnlTotal.Visible = false;
                    this.pnlEnh.Visible = false;
                    this.lblLock.Visible = this.Lock;
                    solidBrush3 = new SolidBrush(this.pnlFX.BackColor);
                    pen = new Pen(this.pnlFX.BackColor, 1f);
                    break;
                case 2:
                    this.pnlInfo.Visible = false;
                    this.pnlFX.Visible = false;
                    this.pnlTotal.Visible = true;
                    this.pnlEnh.Visible = false;
                    this.lblLock.Visible = false;
                    solidBrush3 = new SolidBrush(this.pnlTotal.BackColor);
                    pen = new Pen(this.pnlTotal.BackColor, 1f);
                    break;
                case 3:
                    this.pnlInfo.Visible = false;
                    this.pnlFX.Visible = false;
                    this.pnlTotal.Visible = false;
                    this.pnlEnh.Visible = true;
                    this.lblLock.Visible = this.Lock;
                    pen = new Pen(this.pnlEnh.BackColor, 1f);
                    solidBrush3 = new SolidBrush(this.pnlEnh.BackColor);
                    break;
            }
            int num = this.Pages.Length - 1;
            RectangleF layoutRectangle;
            for (int index = 0; index <= num; ++index)
            {
                rect = new Rectangle(rect.Width * index, 2, 70, this.pnlTabs.Height - 2);
                layoutRectangle = new RectangleF((float)rect.X, (float)rect.Y + (float)(((double)rect.Height - (double)font1.GetHeight(graphics)) / 2.0), (float)rect.Width, font1.GetHeight(graphics));
                extendedBitmap.Graphics.DrawRectangle(pen, rect);
                extendedBitmap.Graphics.DrawString(this.Pages[index], font1, (Brush)solidBrush1, layoutRectangle, format);
            }
            rect = new Rectangle(70 * this.TabPage, 0, 70, this.pnlTabs.Height);
            layoutRectangle = new RectangleF((float)rect.X, (float)(((double)rect.Height - (double)font1.GetHeight(graphics)) / 2.0), (float)rect.Width, font1.GetHeight(graphics));
            extendedBitmap.Graphics.FillRectangle((Brush)solidBrush3, rect);
            extendedBitmap.Graphics.DrawRectangle(pen, rect);
            extendedBitmap.Graphics.DrawString(this.Pages[this.TabPage], font2, (Brush)solidBrush1, layoutRectangle, format);
            graphics.DrawImageUnscaled((Image)extendedBitmap.Bitmap, 0, 0);
        }

        int effects_BuffDebuff(Label iLabel, ctlPairedList iList)

        {
            Enums.ShortFX effectMagSum1 = this.pBase.GetEffectMagSum(Enums.eEffectType.ToHit, false, false, false, false);
            Enums.ShortFX effectMagSum2 = this.pEnh.GetEffectMagSum(Enums.eEffectType.ToHit, false, false, false, false);
            Enums.ShortFX effectMagSum3 = this.pEnh.GetEffectMagSum(Enums.eEffectType.DamageBuff, false, false, false, false);
            Enums.ShortFX effectMagSum4 = this.pBase.GetEffectMagSum(Enums.eEffectType.PerceptionRadius, false, false, false, false);
            Enums.ShortFX effectMagSum5 = this.pEnh.GetEffectMagSum(Enums.eEffectType.PerceptionRadius, false, false, false, false);
            Enums.ShortFX effectMagSum6 = this.pBase.GetEffectMagSum(Enums.eEffectType.StealthRadius, false, false, false, false);
            Enums.ShortFX effectMagSum7 = this.pEnh.GetEffectMagSum(Enums.eEffectType.StealthRadius, false, false, false, false);
            Enums.ShortFX effectMag1 = this.pBase.GetEffectMag(Enums.eEffectType.ThreatLevel, Enums.eToWho.Unspecified, false);
            Enums.ShortFX effectMag2 = this.pEnh.GetEffectMag(Enums.eEffectType.ThreatLevel, Enums.eToWho.Unspecified, false);
            Enums.ShortFX effectMag3 = this.pBase.GetEffectMag(Enums.eEffectType.DropToggles, Enums.eToWho.Unspecified, false);
            Enums.ShortFX effectMag4 = this.pEnh.GetEffectMag(Enums.eEffectType.DropToggles, Enums.eToWho.Unspecified, false);
            Enums.ShortFX effectMag5 = this.pBase.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Self, false);
            Enums.ShortFX effectMag6 = this.pEnh.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Self, false);
            Enums.ShortFX effectMag7 = this.pBase.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Target, false);
            Enums.ShortFX effectMag8 = this.pEnh.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Target, false);
            Enums.ShortFX effectMagSum8 = this.pBase.GetEffectMagSum(Enums.eEffectType.ResEffect, false, false, false, false);
            Enums.ShortFX effectMagSum9 = this.pEnh.GetEffectMagSum(Enums.eEffectType.ResEffect, false, false, false, false);
            Enums.ShortFX effectMagSum10 = this.pBase.GetEffectMagSum(Enums.eEffectType.Enhancement, false, false, false, false);
            Enums.ShortFX effectMagSum11 = this.pEnh.GetEffectMagSum(Enums.eEffectType.Enhancement, false, false, false, false);
            effectMagSum1.Multiply();
            effectMagSum2.Multiply();
            effectMagSum3.Multiply();
            effectMagSum4.Multiply();
            effectMagSum5.Multiply();
            effectMag1.Multiply();
            effectMag2.Multiply();
            effectMag5.Multiply();
            effectMag6.Multiply();
            effectMag7.Multiply();
            effectMag8.Multiply();
            effectMagSum8.Multiply();
            effectMagSum9.Multiply();
            effectMagSum10.Multiply();
            effectMagSum11.Multiply();
            string str1 = string.Empty;
            if (effectMagSum10.Present)
                str1 = this.pBase.Effects[effectMagSum10.Index[0]].ETModifies == Enums.eEffectType.Mez ? Enums.GetMezNameShort((Enums.eMezShort)this.pBase.Effects[effectMagSum10.Index[0]].MezType) : Enums.GetEffectNameShort(this.pBase.Effects[effectMagSum10.Index[0]].ETModifies);
            iList.ValueWidth = 55;
            int num1;
            if (!(effectMagSum1.Present | effectMagSum3.Present | effectMagSum4.Present | effectMagSum6.Present | effectMag1.Present | effectMag3.Present | effectMag5.Present | effectMag7.Present | effectMagSum10.Present | effectMagSum8.Present))
            {
                num1 = 0;
            }
            else
            {
                if (iLabel.Text != string.Empty)
                    iLabel.Text += " / Misc ";
                iLabel.Text += "Effects";
                if (effectMagSum1.Present)
                    iList.AddItem(DataView.FastItem("ToHit", effectMagSum1, effectMagSum2, "%", false, false, this.pBase.Effects[effectMagSum1.Index[0]].SpecialCase == Enums.eSpecialCase.Combo, false, effectMagSum1));
                if (this.sFXCheck(effectMagSum1))
                    iList.SetUnique();
                Enums.ShortFX[] shortFxArray = Power.SplitFX(ref effectMagSum3, ref this.pEnh);
                int num2 = shortFxArray.Length - 1;
                for (int index1 = 0; index1 <= num2; ++index1)
                {
                    if (shortFxArray[index1].Present)
                    {
                        bool flag = true;
                        int num3 = shortFxArray[index1].Index.Length - 1;
                        for (int index2 = 0; index2 <= num3; ++index2)
                        {
                            if (this.pEnh.Effects[shortFxArray[index1].Index[index2]].SpecialCase != Enums.eSpecialCase.Defiance)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                            iList.AddItem(new ctlPairedList.ItemPair("Defiance:", Utilities.FixDP(shortFxArray[index1].Value[0]) + "%", false, false, false, this.pEnh.Effects[shortFxArray[index1].Index[0]].BuildEffectString(false, "Damage Buff (Defiance)", false, false, false)));
                        else
                            iList.AddItem(new ctlPairedList.ItemPair("DmgBuff:", Utilities.FixDP(shortFxArray[index1].Value[0]) + "%", false, this.pEnh.Effects[shortFxArray[index1].Index[0]].SpecialCase == Enums.eSpecialCase.Combo, false, Power.SplitFXGroupTip(ref shortFxArray[index1], ref this.pEnh, false)));
                        if (this.pEnh.Effects[shortFxArray[index1].Index[0]].isEnahncementEffect)
                            iList.SetUnique();
                    }
                }
                if (effectMagSum4.Present)
                    iList.AddItem(DataView.FastItem("Percept", effectMagSum4, effectMagSum5, "%", effectMagSum4));
                if (this.sFXCheck(effectMagSum4))
                    iList.SetUnique();
                if (effectMagSum6.Present)
                    iList.AddItem(new ctlPairedList.ItemPair("Stealth", Conversions.ToString(effectMagSum6.Sum) + "ft", false, false, false, this.pEnh.Effects[effectMagSum7.Index[0]].BuildEffectString(false, "Stealth Radius", false, false, false)));
                if (this.sFXCheck(effectMagSum6))
                    iList.SetUnique();
                if (effectMag1.Present)
                    iList.AddItem(DataView.FastItem("ThretLvl", effectMag1, effectMag2, "%", effectMag1));
                if (this.sFXCheck(effectMag1))
                    iList.SetUnique();
                if (effectMag3.Present)
                    iList.AddItem(DataView.FastItem("TogDrop", effectMag3, effectMag4, "%", false, false, (double)this.pBase.Effects[effectMag3.Index[0]].Probability < 1.0, false, effectMag3));
                if (this.sFXCheck(effectMag3))
                    iList.SetUnique();
                if (effectMag7.Present)
                    iList.AddItem(DataView.FastItem("Rchrg (Tgt)", effectMag7, effectMag8, "%", effectMag7));
                if (this.sFXCheck(effectMag7))
                    iList.SetUnique();
                if (effectMag5.Present)
                    iList.AddItem(DataView.FastItem("Rchrg (Self)", effectMag5, effectMag6, "%", effectMag5));
                if (this.sFXCheck(effectMag5))
                    iList.SetUnique();
                if (effectMagSum8.Present)
                {
                    if (!effectMagSum8.Multiple)
                    {
                        if (effectMagSum8.Present)
                            iList.AddItem(DataView.FastItem("Res(" + Enums.GetEffectNameShort(this.pBase.Effects[effectMagSum8.Index[0]].ETModifies) + ")", effectMagSum8, effectMagSum9, "%", effectMagSum8));
                        if (this.sFXCheck(effectMagSum8))
                            iList.SetUnique();
                    }
                    else
                    {
                        iList.AddItem(new ctlPairedList.ItemPair("Res(Multi):", Conversions.ToString(effectMagSum8.Value[0]) + "%", false, false, false, effectMagSum8));
                        if (this.sFXCheck(effectMagSum8))
                            iList.SetUnique();
                    }
                }
                if (effectMagSum10.Present & str1 != string.Empty)
                {
                    string str2 = !string.Equals(str1, "EnduranceDiscount", StringComparison.OrdinalIgnoreCase) ? (!string.Equals(str1, "RechargeTime", StringComparison.OrdinalIgnoreCase) ? (!DataView.IsMezEffect(str1) ? DataView.CapString(str1, 7) : "Effects") : "RechRdx") : "EndRdx";
                    if (effectMagSum10.Multiple)
                    {
                        if (effectMagSum10.Index.Length < 5)
                        {
                            int num3 = effectMagSum10.Index.Length - 1;
                            for (int index = 0; index <= num3; ++index)
                            {
                                string str3 = this.pBase.Effects[effectMagSum10.Index[index]].ETModifies == Enums.eEffectType.Mez ? Enums.GetMezNameShort((Enums.eMezShort)this.pBase.Effects[effectMagSum10.Index[index]].MezType) : Enums.GetEffectNameShort(this.pBase.Effects[effectMagSum10.Index[index]].ETModifies);
                                string str4 = !string.Equals(str3, "EnduranceDiscount", StringComparison.OrdinalIgnoreCase) ? (!string.Equals(str3, "RechargeTime", StringComparison.OrdinalIgnoreCase) ? DataView.CapString(str3, 7) : "RechRdx") : "EndRdx";
                                string str5 = string.Empty;
                                if (this.pEnh.Effects[effectMagSum10.Index[index]].ToWho == Enums.eToWho.Target)
                                    str5 = " (Tgt)";
                                if (this.pEnh.Effects[effectMagSum10.Index[index]].ToWho == Enums.eToWho.Self)
                                    str5 = " (Self)";
                                if (str4.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) <= -1)
                                {
                                    iList.AddItem(new ctlPairedList.ItemPair("+" + str4 + ":", Conversions.ToString(effectMagSum10.Value[index]) + "%" + str5, false, false, false, this.pEnh.Effects[effectMagSum10.Index[index]].BuildEffectString(false, "", false, false, false)));
                                    if (this.pEnh.Effects[effectMagSum10.Index[index]].isEnahncementEffect)
                                        iList.SetUnique();
                                }
                            }
                        }
                        else
                        {
                            string str3 = "Multiple";
                            int iIndex = 0;
                            int num3 = -1;
                            while (iIndex < effectMagSum10.Index.Length)
                            {
                                if (string.Equals(this.pEnh.Effects[effectMagSum10.Index[iIndex]].Special, "RechargeTime", StringComparison.OrdinalIgnoreCase))
                                {
                                    string str4 = string.Empty;
                                    if (this.pEnh.Effects[effectMagSum10.Index[iIndex]].ToWho == Enums.eToWho.Target)
                                        str4 = " (Tgt)";
                                    if (this.pEnh.Effects[effectMagSum10.Index[iIndex]].ToWho == Enums.eToWho.Self)
                                        str4 = " (Self)";
                                    iList.AddItem(new ctlPairedList.ItemPair("+RechRdx:", Conversions.ToString(effectMagSum10.Value[iIndex]) + "%" + str4, false, false, false, this.pEnh.Effects[effectMagSum10.Index[iIndex]].BuildEffectString(false, "", false, false, false)));
                                    if (this.pEnh.Effects[effectMagSum10.Index[iIndex]].isEnahncementEffect)
                                        iList.SetUnique();
                                    effectMagSum10.Remove(iIndex);
                                }
                                else
                                {
                                    if (num3 == -1)
                                        num3 = (int)Math.Round((double)effectMagSum10.Value[0]);
                                    else if (num3 > 0 & (double)num3 != (double)effectMagSum10.Value[iIndex])
                                        num3 = -2;
                                    ++iIndex;
                                }
                            }
                            if (effectMagSum10.Present)
                            {
                                string iValue = "Varies";
                                if (num3 > 0)
                                    iValue = num3.ToString() + "%";
                                if (effectMagSum10.Multiple)
                                {
                                    iList.AddItem(new ctlPairedList.ItemPair("+" + str3 + ":", iValue, false, false, false, effectMagSum10));
                                }
                                else
                                {
                                    string str4 = DataView.CapString(this.pBase.Effects[effectMagSum10.Index[0]].Special, 7);
                                    if (str4.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) < 0)
                                    {
                                        iList.AddItem(new ctlPairedList.ItemPair("+" + str4 + ":", iValue, false, false, false, effectMagSum10));
                                        if (this.sFXCheck(effectMagSum10))
                                            iList.SetUnique();
                                    }
                                }
                            }
                        }
                    }
                    else if (str2.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        iList.AddItem(new ctlPairedList.ItemPair("+" + str2 + ":", Conversions.ToString(effectMagSum10.Value[0]) + "%", false, false, false, effectMagSum10));
                        if (this.sFXCheck(effectMagSum10))
                            iList.SetUnique();
                    }
                }
                num1 = 1;
            }
            return num1;
        }

        int effects_Elusivity(Label iLabel, ctlPairedList iList)

        {
            bool flag = iList.ItemCount == 0;
            int num1 = 0;
            int num2 = this.pBase.Effects.Length - 1;
            for (int idEffect = 0; idEffect <= num2; ++idEffect)
            {
                if (this.pBase.Effects[idEffect].EffectType == Enums.eEffectType.Elusivity & (double)this.pBase.Effects[idEffect].Probability > 0.0)
                {
                    string empty = string.Empty;
                    int[] returnMask = new int[Enum.GetValues(this.pBase.Effects[idEffect].DamageType.GetType()).Length + 1];
                    this.pBase.GetEffectStringGrouped(idEffect, ref empty, ref returnMask, false, true, true);
                    string iTip = empty;
                    float num3 = this.pBase.Effects[idEffect].MagPercent;
                    if ((this.pBase.Effects[idEffect].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        num3 = 0.0f;
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("Elusivity:", Strings.Format((object)num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "%", false, (double)this.pBase.Effects[idEffect].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    int num4 = num1 + 1;
                    if (flag)
                        iLabel.Text = "Elusivity (PvP)";
                    return num4;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "Elusivity (PvP)";
            return num1;
        }

        int effects_GrantPower(Label iLabel, ctlPairedList iList)

        {
            bool flag = iList.ItemCount == 0;
            int num1 = 0;
            int num2 = this.pBase.Effects.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.pBase.Effects[index].EffectType == Enums.eEffectType.GrantPower & (double)this.pBase.Effects[index].Probability > 0.0 & this.pBase.Effects[index].EffectClass != Enums.eEffectClass.Ignored)
                {
                    string iValue = "[Power]";
                    if (this.pEnh.Effects[index].nSummon > -1)
                    {
                        iValue = DatabaseAPI.Database.Power[this.pEnh.Effects[index].nSummon].DisplayName;
                    }
                    else
                    {
                        int startIndex = this.pEnh.Effects[index].Summon.LastIndexOf(".", StringComparison.Ordinal) + 1;
                        if (startIndex < this.pEnh.Effects[index].Summon.Length)
                            iValue = this.pEnh.Effects[index].Summon.Substring(startIndex);
                    }
                    string iTip = this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
                    if ((this.pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        iValue = "(suppressed)";
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("GrantPwr:", iValue, false, (double)this.pBase.Effects[index].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    if (this.pBase.Effects[index].isEnahncementEffect)
                        iList.SetUnique();
                    ++num1;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "GrantPower Effects";
            return num1;
        }

        int effects_Heal(Label iLabel, ctlPairedList iList)

        {
            Enums.ShortFX BaseSFX1 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX1 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX2 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX2 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX3 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX3 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX4 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX4 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX5 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX5 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX6 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX6 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX7 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX7 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX8 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX8 = new Enums.ShortFX();
            Enums.ShortFX BaseSFX9 = new Enums.ShortFX();
            Enums.ShortFX EnhSFX9 = new Enums.ShortFX();
            Enums.ShortFX shortFx = new Enums.ShortFX();
            BaseSFX1.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false));
            EnhSFX1.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Heal, false, false, false, false));
            BaseSFX2.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.HitPoints, false, false, false, false));
            EnhSFX2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.HitPoints, false, false, false, false));
            BaseSFX3.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Absorb, false, false, false, false));
            EnhSFX3.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Absorb, false, false, false, false));
            BaseSFX5.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, false, true, false, false));
            EnhSFX5.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, false, true, false, false));
            BaseSFX4.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, true, false, true, false));
            EnhSFX4.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, true, false, true, false));
            BaseSFX6.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Recovery, true, true, false, false));
            EnhSFX6.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Recovery, true, true, false, false));
            BaseSFX7.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Recovery, true, false, true, false));
            EnhSFX7.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Recovery, true, false, true, false));
            BaseSFX8.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Endurance, true, true, false, false));
            EnhSFX8.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, true, true, false, false));
            BaseSFX9.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Endurance, true, false, true, false));
            EnhSFX9.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, true, false, true, false));
            BaseSFX3.Multiply();
            EnhSFX3.Multiply();
            BaseSFX5.Multiply();
            EnhSFX5.Multiply();
            BaseSFX4.Multiply();
            EnhSFX4.Multiply();
            BaseSFX6.Multiply();
            EnhSFX6.Multiply();
            BaseSFX7.Multiply();
            EnhSFX7.Multiply();
            int num1 = this.pBase.Effects.Length - 1;
            for (int iIndex = 0; iIndex <= num1; ++iIndex)
            {
                if (this.pBase.Effects[iIndex].EffectType == Enums.eEffectType.Damage & this.pBase.Effects[iIndex].DamageType == Enums.eDamage.Special & this.pBase.Effects[iIndex].ToWho == Enums.eToWho.Self & (double)this.pBase.Effects[iIndex].Probability > 0.0 & (this.pBase.Effects[iIndex].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                    shortFx.Add(iIndex, this.pBase.Effects[iIndex].Mag);
            }
            iList.ValueWidth = 55;
            int num2;
            if (!(shortFx.Present | BaseSFX1.Present | BaseSFX2.Present | BaseSFX5.Present | BaseSFX4.Present | BaseSFX6.Present | BaseSFX7.Present | BaseSFX8.Present | BaseSFX9.Present))
            {
                num2 = 0;
            }
            else
            {
                bool flag1 = this.pBase.AffectsTarget(Enums.eEffectType.Heal) | this.pBase.AffectsTarget(Enums.eEffectType.HitPoints) | this.pBase.AffectsTarget(Enums.eEffectType.Regeneration) | this.pBase.AffectsTarget(Enums.eEffectType.Recovery) | this.pBase.AffectsTarget(Enums.eEffectType.Endurance) | this.pBase.AffectsTarget(Enums.eEffectType.Absorb);
                bool flag2 = this.pBase.AffectsSelf(Enums.eEffectType.Heal) | this.pBase.AffectsSelf(Enums.eEffectType.HitPoints) | this.pBase.AffectsSelf(Enums.eEffectType.Regeneration) | this.pBase.AffectsSelf(Enums.eEffectType.Recovery) | this.pBase.AffectsSelf(Enums.eEffectType.Endurance) | this.pBase.AffectsSelf(Enums.eEffectType.Absorb);
                if (flag1 & !flag2)
                    iLabel.Text = "Health / Endurance  (Target)";
                else if (!flag1 & flag2)
                    iLabel.Text = "Health / Endurance (Self)";
                else
                    iLabel.Text = "Health / Endurance";
                if (shortFx.Present)
                {
                    int num3 = shortFx.Index.Length - 1;
                    for (int index = 0; index <= num3; ++index)
                    {
                        if (this.pBase.Effects[shortFx.Index[index]].Aspect == Enums.eAspect.Cur)
                        {
                            if ((double)shortFx.Value[index] == -1.0)
                                shortFx.Value[index] = 0.0f;
                            if ((double)shortFx.Value[index] != 100.0)
                                shortFx.Value[index] *= 100f;
                        }
                    }
                    shortFx.ReSum();
                    iList.AddItem(DataView.FastItem("Damage", shortFx, shortFx, " (Self)", shortFx));
                }
                this.SplitFX_AddToList(ref BaseSFX1, ref EnhSFX1, ref iList, "");
                this.SplitFX_AddToList(ref BaseSFX2, ref EnhSFX2, ref iList, "");
                this.SplitFX_AddToList(ref BaseSFX3, ref EnhSFX3, ref iList, "");
                this.SplitFX_AddToList(ref BaseSFX5, ref EnhSFX5, ref iList, "Regen(S)");
                this.SplitFX_AddToList(ref BaseSFX4, ref EnhSFX4, ref iList, "Regen(T)");
                this.SplitFX_AddToList(ref BaseSFX6, ref EnhSFX6, ref iList, "Recvry(S)");
                this.SplitFX_AddToList(ref BaseSFX7, ref EnhSFX7, ref iList, "Recvry(T)");
                this.SplitFX_AddToList(ref BaseSFX9, ref EnhSFX9, ref iList, "End (Tgt)");
                this.SplitFX_AddToList(ref BaseSFX8, ref EnhSFX8, ref iList, "End (Self)");
                num2 = iList.ItemCount;
            }
            return num2;
        }

        int effects_ModifyEffect(Label iLabel, ctlPairedList iList)

        {
            bool flag = iList.ItemCount == 0;
            int num1 = 0;
            int num2 = this.pBase.Effects.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.pBase.Effects[index].EffectType == Enums.eEffectType.GlobalChanceMod & (double)this.pBase.Effects[index].Probability > 0.0)
                {
                    string iTip = string.Empty + this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
                    string iValue = Conversions.ToString(this.pBase.Effects[index].MagPercent) + "%";
                    if ((this.pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        iValue = "(suppressed)";
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(this.pBase.Effects[index].Reward + ":", iValue, false, (double)this.pBase.Effects[index].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    ++num1;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "Modify Effect";
            return num1;
        }

        int effects_Movement(Label iLabel, ctlPairedList iList)

        {
            Enums.ShortFX shortFx1 = new Enums.ShortFX();
            Enums.ShortFX shortFx2 = new Enums.ShortFX();
            Enums.ShortFX s2_1 = new Enums.ShortFX();
            Enums.ShortFX shortFx3 = new Enums.ShortFX();
            Enums.ShortFX s2_2 = new Enums.ShortFX();
            Enums.ShortFX shortFx4 = new Enums.ShortFX();
            Enums.ShortFX s2_3 = new Enums.ShortFX();
            Enums.ShortFX shortFx5 = new Enums.ShortFX();
            Enums.ShortFX s2_4 = new Enums.ShortFX();
            Enums.ShortFX shortFx6 = new Enums.ShortFX();
            Enums.ShortFX shortFx7 = new Enums.ShortFX();
            Enums.ShortFX shortFx8 = new Enums.ShortFX();
            Enums.ShortFX shortFx9 = new Enums.ShortFX();
            Enums.ShortFX shortFx10 = new Enums.ShortFX();
            shortFx2.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, false));
            s2_1.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, false));
            shortFx1.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Fly, false, false, false, false));
            shortFx3.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.JumpHeight, false, false, false, false));
            s2_2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.JumpHeight, false, false, false, false));
            shortFx4.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, false));
            s2_3.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, false));
            shortFx5.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, false));
            s2_4.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, false));
            shortFx6.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Enhancement, false, false, false, false));
            shortFx8.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, true));
            shortFx9.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, true));
            shortFx10.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, true));
            shortFx2.Multiply();
            s2_1.Multiply();
            shortFx3.Multiply();
            s2_2.Multiply();
            shortFx4.Multiply();
            s2_3.Multiply();
            shortFx5.Multiply();
            s2_4.Multiply();
            if (shortFx6.Present)
            {
                int num = shortFx6.Index.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (this.pBase.Effects[shortFx6.Index[index]].Special.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) > -1)
                        shortFx7.Add(shortFx6.Index[index], this.pBase.Effects[shortFx6.Index[index]].Mag);
                }
            }
            iList.ValueWidth = 55;
            int num1;
            if (!(shortFx7.Present | shortFx1.Present | shortFx2.Present | shortFx3.Present | shortFx4.Present | shortFx5.Present))
            {
                num1 = 0;
            }
            else
            {
                bool flag = shortFx2.Present & this.pBase.AffectsTarget(Enums.eEffectType.SpeedFlying) | shortFx3.Present & this.pBase.AffectsTarget(Enums.eEffectType.JumpHeight) | shortFx4.Present & this.pBase.AffectsTarget(Enums.eEffectType.SpeedJumping) | shortFx5.Present & this.pBase.AffectsTarget(Enums.eEffectType.SpeedRunning);
                if (iList.ItemCount == 0)
                {
                    if (flag)
                        iLabel.Text = "Movement (Target)";
                    else
                        iLabel.Text = "Movement (Self)";
                }
                if (shortFx1.Present)
                    iList.AddItem(DataView.FastItem("Fly", shortFx1, shortFx1, string.Empty, shortFx1));
                if (this.sFXCheck(shortFx1))
                    iList.SetUnique();
                if (shortFx2.Present)
                    iList.AddItem(DataView.FastItem("FlySpd", shortFx2, s2_1, "%", shortFx2));
                if (this.sFXCheck(shortFx2))
                    iList.SetUnique();
                if (shortFx3.Present)
                    iList.AddItem(DataView.FastItem("JmpHeight", shortFx3, s2_2, "%", shortFx3));
                if (this.sFXCheck(shortFx3))
                    iList.SetUnique();
                if (shortFx4.Present)
                    iList.AddItem(DataView.FastItem("JmpSpd", shortFx4, s2_3, "%", shortFx4));
                if (this.sFXCheck(shortFx4))
                    iList.SetUnique();
                if (shortFx7.Present)
                    iList.AddItem(DataView.FastItem("+JmpHeight", shortFx7, shortFx7, "%", shortFx7));
                if (this.sFXCheck(shortFx7))
                    iList.SetUnique();
                if (shortFx5.Present)
                    iList.AddItem(DataView.FastItem("RunSpd", shortFx5, s2_4, "%", shortFx5));
                if (this.sFXCheck(shortFx5))
                    iList.SetUnique();
                if (shortFx10.Present)
                    iList.AddItem(DataView.FastItem("MaxRun", shortFx10, shortFx10, string.Empty, shortFx10));
                if (shortFx9.Present)
                    iList.AddItem(DataView.FastItem("MaxJmp", shortFx9, shortFx9, string.Empty, shortFx9));
                if (shortFx8.Present)
                    iList.AddItem(DataView.FastItem("MaxFly", shortFx8, shortFx8, string.Empty, shortFx8));
                num1 = 1;
            }
            return num1;
        }

        int effects_Status(Label iLabel, ctlPairedList iList)

        {
            Enums.eMezShort eMezShort = Enums.eMezShort.None;
            Enums.ShortFX shortFx1 = new Enums.ShortFX();
            Enums.ShortFX shortFx2 = new Enums.ShortFX();
            Enums.ShortFX shortFx3 = new Enums.ShortFX();
            Enums.ShortFX shortFx4 = new Enums.ShortFX();
            int num1 = 0;
            shortFx1.Assign(this.pBase.GetEffectMag(Enums.eEffectType.MezResist, Enums.eToWho.Unspecified, false));
            shortFx2.Assign(this.pEnh.GetEffectMag(Enums.eEffectType.MezResist, Enums.eToWho.Unspecified, false));
            shortFx3.Assign(this.pBase.GetEffectMag(Enums.eEffectType.Mez, Enums.eToWho.Unspecified, true));
            shortFx4.Assign(this.pEnh.GetEffectMag(Enums.eEffectType.Mez, Enums.eToWho.Unspecified, true));
            shortFx1.Multiply();
            shortFx2.Multiply();
            iList.ValueWidth = 60;
            if (shortFx1.Present | shortFx3.Present)
            {
                if (this.pBase.AffectsTarget(Enums.eEffectType.MezResist) | this.pBase.AffectsTarget(Enums.eEffectType.Mez))
                    iLabel.Text = "Status Effects (Target)";
                else
                    iLabel.Text = "Status Effects (Self)";
            }
            string[] names = Enum.GetNames(eMezShort.GetType());
            if (shortFx3.Present)
            {
                int num2 = this.pBase.Effects.Length - 1;
                for (int iTagID = 0; iTagID <= num2; ++iTagID)
                {
                    if (this.pBase.Effects[iTagID].EffectType == Enums.eEffectType.Mez & (double)this.pBase.Effects[iTagID].Probability > 0.0 & this.pBase.Effects[iTagID].CanInclude() && this.pEnh.Effects[iTagID].PvXInclude())
                    {
                        bool iAlternate1 = false;
                        string str = !((double)this.pEnh.Effects[iTagID].Duration < 2.0 | this.pBase.PowerType == Enums.ePowerType.Auto_) ? " - " + Strings.Format((object)this.pEnh.Effects[iTagID].Duration, "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "s" : string.Empty;
                        if ((double)this.pBase.Effects[iTagID].Mag > 0.0)
                        {
                            bool iAlternate2 = (double)this.pBase.Effects[iTagID].Duration != (double)this.pEnh.Effects[iTagID].Duration | !Enums.MezDurationEnhancable(this.pBase.Effects[iTagID].MezType) & (double)this.pEnh.Effects[iTagID].Mag != (double)this.pBase.Effects[iTagID].Mag;
                            string iValue = "Mag " + Utilities.FixDP(this.pEnh.Effects[iTagID].Mag) + str;
                            if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                                iValue = "0";
                            ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(DataView.CapString(names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate2, (double)this.pBase.Effects[iTagID].Probability < 1.0 | this.pBase.Effects[iTagID].SpecialCase == Enums.eSpecialCase.Combo, this.pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
                            iList.AddItem(iItem);
                            if (this.pBase.Effects[iTagID].isEnahncementEffect)
                                iList.SetUnique();
                        }
                        else if (this.pBase.Effects[iTagID].MezType == Enums.eMez.ToggleDrop & (double)this.pBase.Effects[iTagID].Probability > 0.0)
                        {
                            string iValue = Conversions.ToString(this.pBase.Effects[iTagID].Probability * 100f) + "%";
                            if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                                iValue = "0%";
                            ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(DataView.CapString(names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate1, (double)this.pBase.Effects[iTagID].Probability < 1.0 | this.pBase.Effects[iTagID].SpecialCase == Enums.eSpecialCase.Combo, this.pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
                            iList.AddItem(iItem);
                            if (this.pBase.Effects[iTagID].isEnahncementEffect)
                                iList.SetUnique();
                        }
                        else
                        {
                            bool iAlternate2 = (double)this.pBase.Effects[iTagID].Duration != (double)this.pEnh.Effects[iTagID].Duration | !Enums.MezDurationEnhancable(this.pBase.Effects[iTagID].MezType) & (double)this.pEnh.Effects[iTagID].Mag != (double)this.pBase.Effects[iTagID].Mag;
                            string iValue = "Mag " + Utilities.FixDP(this.pEnh.Effects[iTagID].Mag) + str;
                            if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                                iValue = "0";
                            ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(DataView.CapString(names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate2, (double)this.pBase.Effects[iTagID].Probability < 1.0, this.pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
                            iList.AddItem(iItem);
                            if (this.pBase.Effects[iTagID].isEnahncementEffect)
                                iList.SetUnique();
                        }
                        ++num1;
                    }
                }
            }
            if (shortFx1.Present)
            {
                int num2 = this.pBase.Effects.Length - 1;
                for (int iTagID = 0; iTagID <= num2; ++iTagID)
                {
                    if (this.pBase.Effects[iTagID].PvMode != Enums.ePvX.PvP & MidsContext.Config.Inc.PvE | this.pBase.Effects[iTagID].PvMode != Enums.ePvX.PvE & !MidsContext.Config.Inc.PvE && this.pBase.Effects[iTagID].EffectType == Enums.eEffectType.MezResist & (double)this.pBase.Effects[iTagID].Probability > 0.0)
                    {
                        string str = (double)this.pEnh.Effects[iTagID].Duration >= 15.0 ? " - " + Utilities.FixDP(this.pEnh.Effects[iTagID].Duration) + "s" : string.Empty;
                        string iValue = Conversions.ToString(this.pBase.Effects[iTagID].MagPercent) + "%" + str;
                        if ((this.pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                            iValue = "0%";
                        ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(DataView.CapString("-" + names[(int)this.pBase.Effects[iTagID].MezType], 7) + ":", iValue, false, false, false, iTagID);
                        iList.AddItem(iItem);
                        if (this.pBase.Effects[iTagID].isEnahncementEffect)
                            iList.SetUnique();
                        ++num1;
                    }
                }
            }
            return num1;
        }

        int effects_Summon(Label iLabel, ctlPairedList iList)

        {
            int num1 = 0;
            bool flag = iList.ItemCount == 0;
            int num2 = this.pBase.Effects.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.pBase.Effects[index].EffectType == Enums.eEffectType.EntCreate & (double)this.pBase.Effects[index].Probability > 0.0)
                {
                    string iValue = this.pEnh.Effects[index].nSummon <= -1 ? this.pEnh.Effects[index].Summon : DatabaseAPI.Database.Entities[this.pEnh.Effects[index].nSummon].DisplayName;
                    if (iValue.StartsWith("MastermindPets_"))
                        iValue = iValue.Replace("MastermindPets_", string.Empty);
                    if (iValue.StartsWith("Pets_"))
                        iValue = iValue.Replace("Pets_", string.Empty);
                    if (iValue.StartsWith("Villain_Pets_"))
                        iValue = iValue.Replace("Villain_Pets_", string.Empty);
                    string iTip = this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
                    if ((this.pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        iValue = "(suppressed)";
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("Summon:", iValue, false, (double)this.pBase.Effects[index].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    if (this.pBase.Effects[index].isEnahncementEffect)
                        iList.SetUnique();
                    ++num1;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "Summoned Entities";
            return num1;
        }

        void EffectsDef()

        {
            Enums.ShortFX effectMagSum = this.pEnh.GetEffectMagSum(Enums.eEffectType.Defense, true, false, false, false);
            if (effectMagSum.Value == null)
                return;
            Enums.eDamage eDamage = Enums.eDamage.None;
            effectMagSum.Multiply();
            bool flag1 = false;
            bool flag2 = false;
            int num1 = effectMagSum.Value.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if ((double)effectMagSum.Value[index] > 0.0)
                    flag1 = true;
                if ((double)effectMagSum.Value[index] < 0.0)
                    flag2 = true;
            }
            int buffDebuff = !(flag1 & flag2) ? (!flag1 ? (!flag2 ? 0 : -1) : 1) : 1;
            float[] def1 = this.pBase.GetDef(buffDebuff);
            float[] def2 = this.pEnh.GetDef(buffDebuff);
            string[] names = Enum.GetNames(eDamage.GetType());
            if (this.pBase.AffectsTarget(Enums.eEffectType.Defense))
                this.fx_lblHead1.Text = "Defence (Target)";
            else
                this.fx_lblHead1.Text = "Defence (Self)";
            this.fx_List1.ValueWidth = 55;
            int num2 = def1.Length - 1;
            for (int index = 0; index <= num2; ++index)
                def1[index] *= 100f;
            int num3 = def2.Length - 1;
            for (int index = 0; index <= num3; ++index)
                def2[index] *= 100f;
            bool multiple = effectMagSum.Multiple;
            Enums.eDamage iSub1 = Enums.eDamage.Smashing;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub1, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub1], def1[(int)iSub1], def2[(int)iSub1], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub2 = Enums.eDamage.Fire;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub2, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub2], def1[(int)iSub2], def2[(int)iSub2], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub3 = Enums.eDamage.Lethal;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub3, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub3], def1[(int)iSub3], def2[(int)iSub3], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub4 = Enums.eDamage.Cold;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub4, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub4], def1[(int)iSub4], def2[(int)iSub4], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub5 = Enums.eDamage.Energy;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub5, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub5], def1[(int)iSub5], def2[(int)iSub5], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub6 = Enums.eDamage.Melee;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub6, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub6], def1[(int)iSub6], def2[(int)iSub6], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub7 = Enums.eDamage.Negative;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub7, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub7], def1[(int)iSub7], def2[(int)iSub7], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub8 = Enums.eDamage.Ranged;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub8, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub8], def1[(int)iSub8], def2[(int)iSub8], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub9 = Enums.eDamage.Psionic;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub9, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub9], def1[(int)iSub9], def2[(int)iSub9], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
            Enums.eDamage iSub10 = Enums.eDamage.AoE;
            if (multiple)
                effectMagSum.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
            this.fx_List1.AddItem(DataView.FastItem(names[(int)iSub10], def1[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
            if (this.sFXCheck(effectMagSum))
                this.fx_List1.SetUnique();
        }

        int EffectsDrh()

        {
            int index = 0;
            if (this.pBase.HasDefEffects())
            {
                this.EffectsDef();
                ++index;
            }
            if (this.pBase.HasResEffects())
            {
                this.EffectsRes(index);
                ++index;
            }
            return index;
        }

        void EffectsRes(int index)

        {
            Enums.eDamage eDamage = Enums.eDamage.None;
            float[] res1 = this.pBase.GetRes(MidsContext.Config.Inc.PvE);
            float[] res2 = this.pEnh.GetRes(MidsContext.Config.Inc.PvE);
            string[] names = Enum.GetNames(eDamage.GetType());
            Label label;
            ctlPairedList ctlPairedList;
            if (index == 0)
            {
                label = this.fx_lblHead1;
                ctlPairedList = this.fx_List1;
            }
            else
            {
                label = this.fx_lblHead2;
                ctlPairedList = this.fx_List2;
            }
            if (this.pBase.AffectsTarget(Enums.eEffectType.Resistance))
                label.Text = "Resistance (Target)";
            else
                label.Text = "Resistance (Self)";
            this.fx_List2.ValueWidth = 55;
            Enums.ShortFX shortFx = new Enums.ShortFX();
            shortFx.Multiply();
            int num1 = res1.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
                res1[index1] *= 100f;
            int num2 = res2.Length - 1;
            for (int index1 = 0; index1 <= num2; ++index1)
                res2[index1] *= 100f;
            Enums.eDamage iSub1 = Enums.eDamage.Smashing;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub1, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub1], res1[(int)iSub1], res2[(int)iSub1], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub2 = Enums.eDamage.Fire;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub2, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub2], res1[(int)iSub2], res2[(int)iSub2], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub3 = Enums.eDamage.Lethal;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub3, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub3], res1[(int)iSub3], res2[(int)iSub3], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub4 = Enums.eDamage.Cold;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub4, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub4], res1[(int)iSub4], res2[(int)iSub4], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub5 = Enums.eDamage.Energy;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub5, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub5], res1[(int)iSub5], res2[(int)iSub5], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub6 = Enums.eDamage.Psionic;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub6, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub6], res1[(int)iSub6], res2[(int)iSub6], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub7 = Enums.eDamage.Negative;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub7, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub7], res1[(int)iSub7], res2[(int)iSub7], "%", false, true, false, false, shortFx));
            if (this.sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            Enums.eDamage iSub8 = Enums.eDamage.Toxic;
            shortFx.Assign(this.pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
            ctlPairedList.AddItem(DataView.FastItem(names[(int)iSub8], res1[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          float s1,
          float s2,
          string Suffix)
        {
            return DataView.FastItem(Title, s1, s2, Suffix, false, false, false, false, -1, -1);
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          Enums.ShortFX s1,
          Enums.ShortFX s2,
          string Suffix,
          Enums.ShortFX Tag)
        {
            return DataView.FastItem(Title, s1, s2, Suffix, false, false, false, false, Tag);
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          float s1,
          float s2,
          string Suffix,
          string Tip)
        {
            return DataView.FastItem(Title, s1, s2, Suffix, false, false, false, false, Tip);
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          Enums.ShortFX s1,
          Enums.ShortFX s2,
          string Suffix,
          bool SkipBase,
          bool AlwaysShow,
          bool isChance,
          bool isSpecial,
          Enums.ShortFX Tag)
        {
            string iValue = Utilities.FixDP(s2.Sum) + Suffix;
            ctlPairedList.ItemPair itemPair;
            if ((double)s1.Sum == 0.0 & !AlwaysShow)
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
            else if ((double)s1.Sum == 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false, false, false, -1);
            }
            else
            {
                bool iAlternate;
                if ((double)s1.Sum != (double)s2.Sum)
                {
                    if (!SkipBase)
                        iValue = iValue + " (" + Utilities.FixDP(s1.Sum) + ")";
                    iAlternate = true;
                }
                else
                    iAlternate = false;
                itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, Tag);
            }
            return itemPair;
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          float s1,
          float s2,
          string Suffix,
          bool SkipBase,
          bool AlwaysShow,
          bool isChance,
          bool isSpecial,
          Enums.ShortFX Tag)
        {
            string iValue = Utilities.FixDP(s2) + Suffix;
            ctlPairedList.ItemPair itemPair;
            if ((double)s1 == 0.0 & !AlwaysShow)
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
            else if ((double)s1 == 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false, false, false, -1);
            }
            else
            {
                bool iAlternate;
                if ((double)s1 != (double)s2)
                {
                    if (!SkipBase)
                        iValue = iValue + " (" + Utilities.FixDP(s1) + ")";
                    iAlternate = true;
                }
                else
                    iAlternate = false;
                itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, Tag);
            }
            return itemPair;
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          float s1,
          float s2,
          string Suffix,
          bool SkipBase,
          bool AlwaysShow,
          bool isChance,
          bool isSpecial,
          string Tip)
        {
            string iValue = Utilities.FixDP(s2) + Suffix;
            ctlPairedList.ItemPair itemPair;
            if ((double)s1 == 0.0 & !AlwaysShow)
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
            else if ((double)s1 == 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false, false, false, -1);
            }
            else
            {
                bool iAlternate;
                if ((double)s1 != (double)s2)
                {
                    if (!SkipBase)
                        iValue = iValue + " (" + Utilities.FixDP(s1) + ")";
                    iAlternate = true;
                }
                else
                    iAlternate = false;
                itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, Tip);
            }
            return itemPair;
        }

        static ctlPairedList.ItemPair FastItem(

          string Title,
          float s1,
          float s2,
          string Suffix,
          bool SkipBase,
          bool AlwaysShow,
          bool isChance,
          bool isSpecial,
          int TagID,
          int maxDecimal)
        {
            string iValue = maxDecimal < 0 ? Utilities.FixDP(s2) + Suffix : Utilities.FixDP(s2, maxDecimal) + Suffix;
            ctlPairedList.ItemPair itemPair;
            if ((double)s1 == 0.0 & !AlwaysShow)
            {
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, -1);
            }
            else
            {
                bool iAlternate;
                if ((double)s1 != (double)s2)
                {
                    if (!SkipBase)
                        iValue = iValue + " (" + Utilities.FixDP(s1) + ")";
                    iAlternate = true;
                }
                else
                    iAlternate = false;
                itemPair = new ctlPairedList.ItemPair(Title + ":", iValue, iAlternate, isChance, isSpecial, TagID);
            }
            return itemPair;
        }

        public void FlipStage(
          int Index,
          int Enh1,
          int Enh2,
          float State,
          int PowerID,
          Enums.eEnhGrade Grade1,
          Enums.eEnhGrade Grade2)
        {
            SolidBrush solidBrush1 = new SolidBrush(this.enhListing.BackColor);
            if (this.pBase == null)
                return;
            SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            if (PowerID == this.pBase.PowerIndex)
            {
                ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MidsContext.Character.IsHero());
                Rectangle rectangle1 = new Rectangle();
                ref Rectangle local1 = ref rectangle1;
                Size size = this.bxFlip.Size;
                int x = size.Width - 188 + 30 * Index;
                size = this.bxFlip.Size;
                int y1 = (int)Math.Round(((double)size.Height / 2.0 - 30.0) / 2.0);
                local1 = new Rectangle(x, y1, 30, 30);
                Rectangle destRect = rectangle1;
                this.bxFlip.Graphics.FillRectangle((Brush)solidBrush1, rectangle1);
                Rectangle rectangle2 = new Rectangle((int)Math.Round((double)rectangle1.X + (30.0 - 30.0 * (double)State) / 2.0), rectangle1.Y, (int)Math.Round(30.0 * (double)State), 30);
                Graphics graphics;
                if (Enh1 > -1)
                {
                    graphics = this.bxFlip.Graphics;
                    I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle1, State, DatabaseAPI.Database.Enhancements[Enh1].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[Enh1].TypeID, Grade1));
                }
                else
                    this.bxFlip.Graphics.DrawImage((Image)I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                this.pnlEnhActive.CreateGraphics().DrawImage((Image)this.bxFlip.Bitmap, destRect, rectangle1, GraphicsUnit.Pixel);
                ref Rectangle local2 = ref rectangle1;
                double y2 = (double)rectangle1.Y;
                size = this.bxFlip.Size;
                double num1 = (double)size.Height / 2.0;
                int num2 = (int)Math.Round(y2 + num1);
                local2.Y = num2;
                this.bxFlip.Graphics.FillRectangle((Brush)solidBrush1, rectangle1);
                rectangle2 = new Rectangle((int)Math.Round((double)rectangle1.X + (30.0 - 30.0 * (double)State) / 2.0), rectangle1.Y, (int)Math.Round(30.0 * (double)State), 30);
                if (Enh2 > -1)
                {
                    graphics = this.bxFlip.Graphics;
                    I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle1, State, DatabaseAPI.Database.Enhancements[Enh2].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[Enh2].TypeID, Grade2));
                }
                else
                    this.bxFlip.Graphics.DrawImage((Image)I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                rectangle2.Inflate(2, 2);
                this.bxFlip.Graphics.FillEllipse((Brush)solidBrush2, rectangle2);
                this.pnlEnhInactive.CreateGraphics().DrawImage((Image)this.bxFlip.Bitmap, destRect, rectangle1, GraphicsUnit.Pixel);
            }
        }

        static string GetEnhancementStringLongRTF(I9Slot iEnh)

        {
            string iStr = iEnh.GetEnhancementStringLong();
            if (iStr != string.Empty)
                iStr = RTF.Color(RTF.ElementID.Enhancement) + RTF.Italic(iStr) + RTF.Color(RTF.ElementID.Text);
            return iStr;
        }

        static string GetEnhancementStringRTF(I9Slot iEnh)

        {
            string str = iEnh.GetEnhancementString();
            if (str != string.Empty)
                str = RTF.Color(RTF.ElementID.Enhancement) + str + RTF.Color(RTF.ElementID.Text);
            return str;
        }

        ctlPairedList.ItemPair GetRankedEffect(int[] Index, int ID)

        {
            string Title = string.Empty;
            Enums.ShortFX shortFx = new Enums.ShortFX();
            Enums.ShortFX s2 = new Enums.ShortFX();
            Enums.ShortFX Tag = new Enums.ShortFX();
            string Suffix = string.Empty;
            if (Index[ID] > -1)
            {
                Enums.eEffectTypeShort eEffectTypeShort = Enums.eEffectTypeShort.None;
                bool flag = false;
                bool onlySelf = this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self;
                bool onlyTarget = this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target;
                if (ID > 0)
                    flag = this.pBase.Effects[Index[ID]].EffectType == this.pBase.Effects[Index[ID - 1]].EffectType & (this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self & this.pBase.Effects[Index[ID - 1]].ToWho == Enums.eToWho.Self) & this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target;
                if ((double)this.pBase.Effects[Index[ID]].DelayedTime > 5.0)
                    flag = true;
                string[] names = Enum.GetNames(eEffectTypeShort.GetType());
                Title = this.pBase.Effects[Index[ID]].EffectType != Enums.eEffectType.Enhancement ? (this.pBase.Effects[Index[ID]].EffectType != Enums.eEffectType.Mez ? names[(int)this.pBase.Effects[Index[ID]].EffectType] : Enums.GetMezName((Enums.eMezShort)this.pBase.Effects[Index[ID]].MezType)) : (this.pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.EnduranceDiscount ? (this.pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.RechargeTime ? (this.pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Mez ? (this.pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Mez ? (this.pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Defense ? (this.pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Resistance ? DataView.CapString(Enum.GetName(this.pBase.Effects[Index[ID]].ETModifies.GetType(), (object)this.pBase.Effects[Index[ID]].ETModifies), 7) : "Enh(Res)") : "Enh(Def)") : "Enh(" + Enum.GetName(Enums.eMezShort.None.GetType(), (object)this.pBase.Effects[Index[ID]].MezType) + ")") : "+Effects") : "+Rechg") : "+EndRdx");
                if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.HitPoints)
                {
                    shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.HitPoints, false, onlySelf, onlyTarget, false));
                    s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.HitPoints, false, onlySelf, onlyTarget, false));
                    Tag.Assign(shortFx);
                    shortFx.Sum = (float)((double)shortFx.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    s2.Sum = (float)((double)s2.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    Suffix = "%";
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Heal)
                {
                    shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Heal, false, onlySelf, onlyTarget, false));
                    s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Heal, false, onlySelf, onlyTarget, false));
                    Tag.Assign(shortFx);
                    shortFx.Sum = (float)((double)shortFx.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    s2.Sum = (float)((double)s2.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    Suffix = "%";
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Absorb)
                {
                    shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Absorb, false, onlySelf, onlyTarget, false));
                    s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Absorb, false, onlySelf, onlyTarget, false));
                    Tag.Assign(shortFx);
                    Suffix = "%";
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Endurance)
                {
                    shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Endurance, false, onlySelf, onlyTarget, false));
                    s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, false, onlySelf, onlyTarget, false));
                    Tag.Assign(shortFx);
                    Suffix = "%";
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Regeneration)
                {
                    shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, false, onlySelf, onlyTarget, false));
                    s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, false, onlySelf, onlyTarget, false));
                    Tag.Assign(shortFx);
                    Suffix = "%";
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Mez & (this.pBase.Effects[Index[ID]].MezType == Enums.eMez.Taunt | this.pBase.Effects[Index[ID]].MezType == Enums.eMez.Placate))
                {
                    shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Duration);
                    s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Duration);
                    Tag.Assign(shortFx);
                    Suffix = "s";
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.SpeedFlying)
                {
                    shortFx.Assign(this.pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, onlySelf, onlyTarget, false));
                    s2.Assign(this.pEnh.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, onlySelf, onlyTarget, false));
                    Tag.Assign(shortFx);
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.DamageBuff | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Defense | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Resistance | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.ResEffect | this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Enhancement)
                {
                    shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Mag);
                    s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Mag);
                    Tag.Assign(this.pEnh.GetEffectMagSum(this.pBase.Effects[Index[ID]].EffectType, false, onlySelf, onlyTarget, false));
                }
                else if (this.pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.SilentKill)
                {
                    shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Absorbed_Duration);
                    s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Absorbed_Duration);
                    Tag.Assign(shortFx);
                }
                else
                {
                    shortFx.Add(Index[ID], this.pBase.Effects[Index[ID]].Mag);
                    s2.Add(Index[ID], this.pEnh.Effects[Index[ID]].Mag);
                    Tag.Assign(shortFx);
                }
                if (this.pBase.Effects[Index[ID]].DisplayPercentage)
                    Suffix = "%";
                if (!(this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target & this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self))
                {
                    if (this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target)
                        Suffix += " (Tgt)";
                    if (this.pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self)
                        Suffix += " (Self)";
                }
                if (flag)
                    return DataView.FastItem(Title, 0.0f, 0.0f, string.Empty);
            }
            int num1 = shortFx.Index.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if (shortFx.Index[index] > -1 && this.pBase.Effects[shortFx.Index[index]].DisplayPercentage)
                {
                    shortFx.Value[index] *= 100f;
                    shortFx.ReSum();
                    break;
                }
            }
            int num2 = s2.Index.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (s2.Index[index] > -1 && this.pBase.Effects[s2.Index[index]].DisplayPercentage)
                {
                    s2.Value[index] *= 100f;
                    s2.ReSum();
                    break;
                }
            }
            return DataView.FastItem(Title, shortFx, s2, Suffix, true, false, (double)this.pBase.Effects[Index[ID]].Probability < 1.0, this.pBase.Effects[Index[ID]].SpecialCase != Enums.eSpecialCase.None, Tag);
        }

        public void Init()
        {
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            this.pnlTabs = new Panel();
            this.pnlInfo = new Panel();
            this.PowerScaler = new ctlMultiGraph();
            this.info_txtSmall = new RichTextBox();
            this.lblDmg = new Label();
            this.info_Damage = new ctlDamageDisplay();
            this.info_DataList = new ctlPairedList();
            this.info_txtLarge = new RichTextBox();
            this.info_Title = new GFXLabel();
            this.pnlFX = new Panel();
            this.fx_Title = new GFXLabel();
            this.fx_LblHead3 = new Label();
            this.fx_List3 = new ctlPairedList();
            this.fx_lblHead2 = new Label();
            this.fx_lblHead1 = new Label();
            this.fx_List2 = new ctlPairedList();
            this.fx_List1 = new ctlPairedList();
            this.pnlTotal = new Panel();
            this.lblTotal = new Label();
            this.gRes2 = new ctlMultiGraph();
            this.gRes1 = new ctlMultiGraph();
            this.gDef2 = new ctlMultiGraph();
            this.gDef1 = new ctlMultiGraph();
            this.total_Title = new GFXLabel();
            this.total_lblMisc = new Label();
            this.total_Misc = new ctlPairedList();
            this.total_lblRes = new Label();
            this.total_lblDef = new Label();
            this.pnlEnh = new Panel();
            this.pnlEnhInactive = new Panel();
            this.pnlEnhActive = new Panel();
            this.enhNameDisp = new GFXLabel();
            this.enhListing = new ctlPairedList();
            this.Enh_Title = new GFXLabel();
            this.dbTip = new ToolTip(this.components);
            this.lblFloat = new Label();
            this.lblShrink = new Label();
            this.lblLock = new Label();
            this.pnlInfo.SuspendLayout();
            this.pnlFX.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlEnh.SuspendLayout();
            this.SuspendLayout();
            this.pnlTabs.BackColor = Color.FromArgb(64, 64, 64);
            Point point = new Point(0, 0);
            this.pnlTabs.Location = point;
            this.pnlTabs.Name = "pnlTabs";
            Size size = new Size(300, 20);
            this.pnlTabs.Size = size;
            this.pnlTabs.TabIndex = 61;
            this.pnlInfo.BackColor = Color.Navy;
            this.pnlInfo.Controls.Add((Control)this.PowerScaler);
            this.pnlInfo.Controls.Add((Control)this.info_txtSmall);
            this.pnlInfo.Controls.Add((Control)this.lblDmg);
            this.pnlInfo.Controls.Add((Control)this.info_Damage);
            this.pnlInfo.Controls.Add((Control)this.info_DataList);
            this.pnlInfo.Controls.Add((Control)this.info_txtLarge);
            this.pnlInfo.Controls.Add((Control)this.info_Title);
            point = new Point(0, 20);
            this.pnlInfo.Location = point;
            this.pnlInfo.Name = "pnlInfo";
            size = new Size(300, 328);
            this.pnlInfo.Size = size;
            this.pnlInfo.TabIndex = 62;
            this.PowerScaler.BackColor = Color.Black;
            this.PowerScaler.Border = true;
            this.PowerScaler.Clickable = true;
            this.PowerScaler.ColorBase = Color.FromArgb(64, (int)byte.MaxValue, 64);
            this.PowerScaler.ColorEnh = Color.Yellow;
            this.PowerScaler.ColorFadeEnd = Color.FromArgb(0, 192, 0);
            this.PowerScaler.ColorFadeStart = Color.Black;
            this.PowerScaler.ColorHighlight = Color.Gray;
            this.PowerScaler.ColorLines = Color.Black;
            this.PowerScaler.ColorMarkerInner = Color.Red;
            this.PowerScaler.ColorMarkerOuter = Color.Black;
            this.PowerScaler.Dual = false;
            this.PowerScaler.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.PowerScaler.ForcedMax = 0.0f;
            this.PowerScaler.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.PowerScaler.Highlight = true;
            this.PowerScaler.ItemHeight = 10;
            this.PowerScaler.Lines = true;
            point = new Point(4, 145);
            this.PowerScaler.Location = point;
            this.PowerScaler.MarkerValue = 0.0f;
            this.PowerScaler.Max = 100f;
            this.PowerScaler.Name = "PowerScaler";
            this.PowerScaler.PaddingX = 2f;
            this.PowerScaler.PaddingY = 2f;
            this.PowerScaler.ScaleHeight = 32;
            this.PowerScaler.ScaleIndex = 8;
            this.PowerScaler.ShowScale = false;
            size = new Size(292, 15);
            this.PowerScaler.Size = size;
            this.PowerScaler.Style = Enums.GraphStyle.baseOnly;
            this.PowerScaler.TabIndex = 71;
            this.PowerScaler.TextWidth = 80;
            this.info_txtSmall.BackColor = Color.FromArgb(64, 64, 64);
            this.info_txtSmall.BorderStyle = BorderStyle.None;
            this.info_txtSmall.Cursor = Cursors.Arrow;
            this.info_txtSmall.ForeColor = Color.White;
            point = new Point(4, 24);
            this.info_txtSmall.Location = point;
            this.info_txtSmall.Name = "info_txtSmall";
            this.info_txtSmall.ReadOnly = true;
            this.info_txtSmall.ScrollBars = RichTextBoxScrollBars.None;
            size = new Size(292, 32);
            this.info_txtSmall.Size = size;
            this.info_txtSmall.TabIndex = 70;
            this.info_txtSmall.Text = "info_Rich";
            this.lblDmg.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblDmg.ForeColor = Color.White;
            point = new Point(4, 272);
            this.lblDmg.Location = point;
            this.lblDmg.Name = "lblDmg";
            size = new Size(292, 13);
            this.lblDmg.Size = size;
            this.lblDmg.TabIndex = 15;
            this.lblDmg.Text = "Damage:";
            this.lblDmg.TextAlign = ContentAlignment.MiddleCenter;
            this.info_Damage.BackColor = Color.FromArgb(64, 64, 64);
            this.info_Damage.ColorBackEnd = Color.Red;
            this.info_Damage.ColorBackStart = Color.Black;
            this.info_Damage.ColorBaseEnd = Color.Blue;
            this.info_Damage.ColorBaseStart = Color.Blue;
            this.info_Damage.ColorEnhEnd = Color.Yellow;
            this.info_Damage.ColorEnhStart = Color.Yellow;
            this.info_Damage.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.info_Damage.GraphType = Enums.eDDGraph.Enhanced;
            point = new Point(4, 288);
            this.info_Damage.Location = point;
            this.info_Damage.Name = "info_Damage";
            this.info_Damage.nBaseVal = 100f;
            this.info_Damage.nEnhVal = 150f;
            this.info_Damage.nHighBase = 200f;
            this.info_Damage.nHighEnh = 214f;
            this.info_Damage.nMaxEnhVal = 207f;
            this.info_Damage.PaddingH = 3;
            this.info_Damage.PaddingV = 6;
            size = new Size(292, 36);
            this.info_Damage.Size = size;
            this.info_Damage.Style = Enums.eDDStyle.TextUnderGraph;
            this.info_Damage.TabIndex = 20;
            this.info_Damage.TextAlign = Enums.eDDAlign.Center;
            this.info_Damage.TextColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.info_DataList.BackColor = Color.FromArgb(0, 0, 32);
            this.info_DataList.Columns = 2;
            this.info_DataList.DoHighlight = true;
            this.info_DataList.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
            this.info_DataList.ForceBold = false;
            this.info_DataList.HighlightColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.info_DataList.HighlightTextColor = Color.Black;
            this.info_DataList.ItemColor = Color.White;
            this.info_DataList.ItemColorAlt = Color.Lime;
            this.info_DataList.ItemColorSpecCase = Color.Red;
            this.info_DataList.ItemColorSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            point = new Point(4, 164);
            this.info_DataList.Location = point;
            this.info_DataList.Name = "info_DataList";
            this.info_DataList.NameColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            size = new Size(292, 104);
            this.info_DataList.Size = size;
            this.info_DataList.TabIndex = 19;
            this.info_DataList.ValueWidth = 55;
            this.info_txtLarge.BackColor = Color.FromArgb(64, 64, 64);
            this.info_txtLarge.BorderStyle = BorderStyle.None;
            this.info_txtLarge.Cursor = Cursors.Arrow;
            this.info_txtLarge.ForeColor = Color.White;
            point = new Point(4, 60);
            this.info_txtLarge.Location = point;
            this.info_txtLarge.Name = "info_txtLarge";
            this.info_txtLarge.ReadOnly = true;
            this.info_txtLarge.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            size = new Size(292, 87);
            this.info_txtLarge.Size = size;
            this.info_txtLarge.TabIndex = 69;
            this.info_txtLarge.Text = "info_Rich";
            this.info_Title.BackColor = Color.FromArgb(64, 64, 64);
            this.info_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.info_Title.ForeColor = Color.White;
            this.info_Title.InitialText = "Title";
            point = new Point(24, 4);
            this.info_Title.Location = point;
            this.info_Title.Name = "info_Title";
            size = new Size(252, 16);
            this.info_Title.Size = size;
            this.info_Title.TabIndex = 69;
            this.info_Title.TextAlign = ContentAlignment.TopCenter;
            this.pnlFX.BackColor = Color.Indigo;
            this.pnlFX.Controls.Add((Control)this.fx_Title);
            this.pnlFX.Controls.Add((Control)this.fx_LblHead3);
            this.pnlFX.Controls.Add((Control)this.fx_List3);
            this.pnlFX.Controls.Add((Control)this.fx_lblHead2);
            this.pnlFX.Controls.Add((Control)this.fx_lblHead1);
            this.pnlFX.Controls.Add((Control)this.fx_List2);
            this.pnlFX.Controls.Add((Control)this.fx_List1);
            point = new Point(144, 148);
            this.pnlFX.Location = point;
            this.pnlFX.Name = "pnlFX";
            size = new Size(300, 320);
            this.pnlFX.Size = size;
            this.pnlFX.TabIndex = 63;
            this.fx_Title.BackColor = Color.FromArgb(64, 64, 64);
            this.fx_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.fx_Title.ForeColor = Color.White;
            this.fx_Title.InitialText = "Title";
            point = new Point(24, 4);
            this.fx_Title.Location = point;
            this.fx_Title.Name = "fx_Title";
            size = new Size(252, 16);
            this.fx_Title.Size = size;
            this.fx_Title.TabIndex = 70;
            this.fx_Title.TextAlign = ContentAlignment.TopCenter;
            this.fx_LblHead3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.fx_LblHead3.ForeColor = Color.White;
            point = new Point(4, 228);
            this.fx_LblHead3.Location = point;
            this.fx_LblHead3.Name = "fx_LblHead3";
            size = new Size(292, 16);
            this.fx_LblHead3.Size = size;
            this.fx_LblHead3.TabIndex = 28;
            this.fx_LblHead3.Text = "Misc Effects:";
            this.fx_LblHead3.TextAlign = ContentAlignment.MiddleLeft;
            this.fx_List3.BackColor = Color.FromArgb(64, 64, 64);
            this.fx_List3.Columns = 2;
            this.fx_List3.DoHighlight = true;
            this.fx_List3.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
            this.fx_List3.ForceBold = false;
            this.fx_List3.HighlightColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.fx_List3.HighlightTextColor = Color.Black;
            this.fx_List3.ItemColor = Color.White;
            this.fx_List3.ItemColorAlt = Color.Lime;
            this.fx_List3.ItemColorSpecCase = Color.Red;
            this.fx_List3.ItemColorSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            point = new Point(4, 244);
            this.fx_List3.Location = point;
            this.fx_List3.Name = "fx_List3";
            this.fx_List3.NameColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            size = new Size(292, 72);
            this.fx_List3.Size = size;
            this.fx_List3.TabIndex = 27;
            this.fx_List3.ValueWidth = 55;
            this.fx_lblHead2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.fx_lblHead2.ForeColor = Color.White;
            point = new Point(4, 136);
            this.fx_lblHead2.Location = point;
            this.fx_lblHead2.Name = "fx_lblHead2";
            size = new Size(292, 16);
            this.fx_lblHead2.Size = size;
            this.fx_lblHead2.TabIndex = 26;
            this.fx_lblHead2.Text = "Secondary Effects:";
            this.fx_lblHead2.TextAlign = ContentAlignment.MiddleLeft;
            this.fx_lblHead1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.fx_lblHead1.ForeColor = Color.White;
            point = new Point(4, 24);
            this.fx_lblHead1.Location = point;
            this.fx_lblHead1.Name = "fx_lblHead1";
            size = new Size(292, 16);
            this.fx_lblHead1.Size = size;
            this.fx_lblHead1.TabIndex = 25;
            this.fx_lblHead1.Text = "Primary Effects:";
            this.fx_lblHead1.TextAlign = ContentAlignment.MiddleLeft;
            this.fx_List2.BackColor = Color.FromArgb(64, 64, 64);
            this.fx_List2.Columns = 2;
            this.fx_List2.DoHighlight = true;
            this.fx_List2.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
            this.fx_List2.ForceBold = false;
            this.fx_List2.HighlightColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.fx_List2.HighlightTextColor = Color.Black;
            this.fx_List2.ItemColor = Color.White;
            this.fx_List2.ItemColorAlt = Color.Lime;
            this.fx_List2.ItemColorSpecCase = Color.Red;
            this.fx_List2.ItemColorSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            point = new Point(4, 152);
            this.fx_List2.Location = point;
            this.fx_List2.Name = "fx_List2";
            this.fx_List2.NameColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            size = new Size(292, 72);
            this.fx_List2.Size = size;
            this.fx_List2.TabIndex = 24;
            this.fx_List2.ValueWidth = 55;
            this.fx_List1.BackColor = Color.FromArgb(64, 64, 64);
            this.fx_List1.Columns = 2;
            this.fx_List1.DoHighlight = true;
            this.fx_List1.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
            this.fx_List1.ForceBold = false;
            this.fx_List1.HighlightColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.fx_List1.HighlightTextColor = Color.Black;
            this.fx_List1.ItemColor = Color.White;
            this.fx_List1.ItemColorAlt = Color.Lime;
            this.fx_List1.ItemColorSpecCase = Color.Red;
            this.fx_List1.ItemColorSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            point = new Point(4, 40);
            this.fx_List1.Location = point;
            this.fx_List1.Name = "fx_List1";
            this.fx_List1.NameColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            size = new Size(292, 92);
            this.fx_List1.Size = size;
            this.fx_List1.TabIndex = 23;
            this.fx_List1.ValueWidth = 60;
            this.pnlTotal.BackColor = Color.Green;
            this.pnlTotal.Controls.Add((Control)this.lblTotal);
            this.pnlTotal.Controls.Add((Control)this.gRes2);
            this.pnlTotal.Controls.Add((Control)this.gRes1);
            this.pnlTotal.Controls.Add((Control)this.gDef2);
            this.pnlTotal.Controls.Add((Control)this.gDef1);
            this.pnlTotal.Controls.Add((Control)this.total_Title);
            this.pnlTotal.Controls.Add((Control)this.total_lblMisc);
            this.pnlTotal.Controls.Add((Control)this.total_Misc);
            this.pnlTotal.Controls.Add((Control)this.total_lblRes);
            this.pnlTotal.Controls.Add((Control)this.total_lblDef);
            point = new Point(248, 15);
            this.pnlTotal.Location = point;
            this.pnlTotal.Name = "pnlTotal";
            size = new Size(300, 319);
            this.pnlTotal.Size = size;
            this.pnlTotal.TabIndex = 64;
            this.lblTotal.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblTotal.ForeColor = Color.White;
            point = new Point(4, 300);
            this.lblTotal.Location = point;
            this.lblTotal.Name = "lblTotal";
            size = new Size(292, 16);
            this.lblTotal.Size = size;
            this.lblTotal.TabIndex = 75;
            this.lblTotal.Text = "Click the 'View Totals' button for more.";
            this.lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            this.gRes2.BackColor = Color.Black;
            this.gRes2.Border = true;
            this.gRes2.Clickable = false;
            this.gRes2.ColorBase = Color.FromArgb(0, 192, 192);
            this.gRes2.ColorEnh = Color.FromArgb((int)byte.MaxValue, 128, 128);
            this.gRes2.ColorFadeEnd = Color.Teal;
            this.gRes2.ColorFadeStart = Color.Black;
            this.gRes2.ColorHighlight = Color.Gray;
            this.gRes2.ColorLines = Color.Black;
            this.gRes2.ColorMarkerInner = Color.Black;
            this.gRes2.ColorMarkerOuter = Color.Yellow;
            this.gRes2.Dual = false;
            this.gRes2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.gRes2.ForcedMax = 0.0f;
            this.gRes2.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.gRes2.Highlight = true;
            this.gRes2.ItemHeight = 13;
            this.gRes2.Lines = true;
            point = new Point(150, 152);
            this.gRes2.Location = point;
            this.gRes2.MarkerValue = 0.0f;
            this.gRes2.Max = 100f;
            this.gRes2.Name = "gRes2";
            this.gRes2.PaddingX = 2f;
            this.gRes2.PaddingY = 4f;
            this.gRes2.ScaleHeight = 32;
            this.gRes2.ScaleIndex = 8;
            this.gRes2.ShowScale = false;
            size = new Size(146, 72);
            this.gRes2.Size = size;
            this.gRes2.Style = Enums.GraphStyle.Stacked;
            this.gRes2.TabIndex = 74;
            this.gRes2.TextWidth = 100;
            this.gRes1.BackColor = Color.Black;
            this.gRes1.Border = true;
            this.gRes1.Clickable = false;
            this.gRes1.ColorBase = Color.FromArgb(0, 192, 192);
            this.gRes1.ColorEnh = Color.FromArgb((int)byte.MaxValue, 128, 128);
            this.gRes1.ColorFadeEnd = Color.Teal;
            this.gRes1.ColorFadeStart = Color.Black;
            this.gRes1.ColorHighlight = Color.Gray;
            this.gRes1.ColorLines = Color.Black;
            this.gRes1.ColorMarkerInner = Color.Black;
            this.gRes1.ColorMarkerOuter = Color.Yellow;
            this.gRes1.Dual = false;
            this.gRes1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.gRes1.ForcedMax = 0.0f;
            this.gRes1.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.gRes1.Highlight = true;
            this.gRes1.ItemHeight = 13;
            this.gRes1.Lines = true;
            point = new Point(4, 152);
            this.gRes1.Location = point;
            this.gRes1.MarkerValue = 0.0f;
            this.gRes1.Max = 100f;
            this.gRes1.Name = "gRes1";
            this.gRes1.PaddingX = 2f;
            this.gRes1.PaddingY = 4f;
            this.gRes1.ScaleHeight = 32;
            this.gRes1.ScaleIndex = 8;
            this.gRes1.ShowScale = false;
            size = new Size(146, 72);
            this.gRes1.Size = size;
            this.gRes1.Style = Enums.GraphStyle.Stacked;
            this.gRes1.TabIndex = 73;
            this.gRes1.TextWidth = 100;
            this.gDef2.BackColor = Color.Black;
            this.gDef2.Border = true;
            this.gDef2.Clickable = false;
            this.gDef2.ColorBase = Color.FromArgb(192, 0, 192);
            this.gDef2.ColorEnh = Color.Yellow;
            this.gDef2.ColorFadeEnd = Color.Purple;
            this.gDef2.ColorFadeStart = Color.Black;
            this.gDef2.ColorHighlight = Color.Gray;
            this.gDef2.ColorLines = Color.Black;
            this.gDef2.ColorMarkerInner = Color.Black;
            this.gDef2.ColorMarkerOuter = Color.Yellow;
            this.gDef2.Dual = false;
            this.gDef2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.gDef2.ForcedMax = 0.0f;
            this.gDef2.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.gDef2.Highlight = true;
            this.gDef2.ItemHeight = 13;
            this.gDef2.Lines = true;
            point = new Point(150, 40);
            this.gDef2.Location = point;
            this.gDef2.MarkerValue = 0.0f;
            this.gDef2.Max = 100f;
            this.gDef2.Name = "gDef2";
            this.gDef2.PaddingX = 2f;
            this.gDef2.PaddingY = 4f;
            this.gDef2.ScaleHeight = 32;
            this.gDef2.ScaleIndex = 8;
            this.gDef2.ShowScale = false;
            size = new Size(146, 92);
            this.gDef2.Size = size;
            this.gDef2.Style = Enums.GraphStyle.baseOnly;
            this.gDef2.TabIndex = 72;
            this.gDef2.TextWidth = 100;
            this.gDef1.BackColor = Color.Black;
            this.gDef1.Border = true;
            this.gDef1.Clickable = false;
            this.gDef1.ColorBase = Color.FromArgb(192, 0, 192);
            this.gDef1.ColorEnh = Color.Yellow;
            this.gDef1.ColorFadeEnd = Color.Purple;
            this.gDef1.ColorFadeStart = Color.Black;
            this.gDef1.ColorHighlight = Color.Gray;
            this.gDef1.ColorLines = Color.Black;
            this.gDef1.ColorMarkerInner = Color.Black;
            this.gDef1.ColorMarkerOuter = Color.Yellow;
            this.gDef1.Dual = false;
            this.gDef1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.gDef1.ForcedMax = 0.0f;
            this.gDef1.ForeColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.gDef1.Highlight = true;
            this.gDef1.ItemHeight = 13;
            this.gDef1.Lines = true;
            point = new Point(4, 40);
            this.gDef1.Location = point;
            this.gDef1.MarkerValue = 0.0f;
            this.gDef1.Max = 100f;
            this.gDef1.Name = "gDef1";
            this.gDef1.PaddingX = 2f;
            this.gDef1.PaddingY = 4f;
            this.gDef1.ScaleHeight = 32;
            this.gDef1.ScaleIndex = 8;
            this.gDef1.ShowScale = false;
            size = new Size(146, 92);
            this.gDef1.Size = size;
            this.gDef1.Style = Enums.GraphStyle.baseOnly;
            this.gDef1.TabIndex = 71;
            this.gDef1.TextWidth = 100;
            this.total_Title.BackColor = Color.FromArgb(64, 64, 64);
            this.total_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.total_Title.ForeColor = Color.White;
            this.total_Title.InitialText = "Cumulative Totals (For Self)";
            point = new Point(24, 4);
            this.total_Title.Location = point;
            this.total_Title.Name = "total_Title";
            size = new Size(252, 16);
            this.total_Title.Size = size;
            this.total_Title.TabIndex = 70;
            this.total_Title.TextAlign = ContentAlignment.TopCenter;
            this.total_lblMisc.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.total_lblMisc.ForeColor = Color.White;
            point = new Point(4, 228);
            this.total_lblMisc.Location = point;
            this.total_lblMisc.Name = "total_lblMisc";
            size = new Size(292, 16);
            this.total_lblMisc.Size = size;
            this.total_lblMisc.TabIndex = 28;
            this.total_lblMisc.Text = "Misc Effects:";
            this.total_lblMisc.TextAlign = ContentAlignment.MiddleLeft;
            this.total_Misc.BackColor = Color.FromArgb(64, 64, 64);
            this.total_Misc.Columns = 2;
            this.total_Misc.DoHighlight = true;
            this.total_Misc.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
            this.total_Misc.ForceBold = false;
            this.total_Misc.HighlightColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.total_Misc.HighlightTextColor = Color.Black;
            this.total_Misc.ItemColor = Color.White;
            this.total_Misc.ItemColorAlt = Color.Lime;
            this.total_Misc.ItemColorSpecCase = Color.Red;
            this.total_Misc.ItemColorSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            point = new Point(4, 244);
            this.total_Misc.Location = point;
            this.total_Misc.Name = "total_Misc";
            this.total_Misc.NameColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            size = new Size(292, 60);
            this.total_Misc.Size = size;
            this.total_Misc.TabIndex = 27;
            this.total_Misc.ValueWidth = 55;
            this.total_lblRes.BackColor = Color.Green;
            this.total_lblRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.total_lblRes.ForeColor = Color.White;
            point = new Point(4, 136);
            this.total_lblRes.Location = point;
            this.total_lblRes.Name = "total_lblRes";
            size = new Size(292, 16);
            this.total_lblRes.Size = size;
            this.total_lblRes.TabIndex = 26;
            this.total_lblRes.Text = "Resistance:";
            this.total_lblRes.TextAlign = ContentAlignment.MiddleLeft;
            this.total_lblDef.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.total_lblDef.ForeColor = Color.White;
            point = new Point(4, 24);
            this.total_lblDef.Location = point;
            this.total_lblDef.Name = "total_lblDef";
            size = new Size(292, 16);
            this.total_lblDef.Size = size;
            this.total_lblDef.TabIndex = 25;
            this.total_lblDef.Text = "Defense:";
            this.total_lblDef.TextAlign = ContentAlignment.MiddleLeft;
            this.pnlEnh.BackColor = Color.Teal;
            this.pnlEnh.Controls.Add((Control)this.pnlEnhInactive);
            this.pnlEnh.Controls.Add((Control)this.pnlEnhActive);
            this.pnlEnh.Controls.Add((Control)this.enhNameDisp);
            this.pnlEnh.Controls.Add((Control)this.enhListing);
            this.pnlEnh.Controls.Add((Control)this.Enh_Title);
            point = new Point(188, 156);
            this.pnlEnh.Location = point;
            this.pnlEnh.Name = "pnlEnh";
            size = new Size(300, 320);
            this.pnlEnh.Size = size;
            this.pnlEnh.TabIndex = 65;
            this.pnlEnhInactive.BackColor = Color.Black;
            point = new Point(4, 279);
            this.pnlEnhInactive.Location = point;
            this.pnlEnhInactive.Name = "pnlEnhInactive";
            size = new Size(292, 38);
            this.pnlEnhInactive.Size = size;
            this.pnlEnhInactive.TabIndex = 74;
            this.pnlEnhActive.BackColor = Color.Black;
            this.pnlEnhActive.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            point = new Point(4, 239);
            this.pnlEnhActive.Location = point;
            this.pnlEnhActive.Name = "pnlEnhActive";
            size = new Size(292, 38);
            this.pnlEnhActive.Size = size;
            this.pnlEnhActive.TabIndex = 73;
            this.enhNameDisp.BackColor = Color.FromArgb(64, 64, 64);
            this.enhNameDisp.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.enhNameDisp.ForeColor = Color.White;
            this.enhNameDisp.InitialText = "Title";
            point = new Point(4, 24);
            this.enhNameDisp.Location = point;
            this.enhNameDisp.Name = "enhNameDisp";
            size = new Size(292, 16);
            this.enhNameDisp.Size = size;
            this.enhNameDisp.TabIndex = 72;
            this.enhNameDisp.TextAlign = ContentAlignment.TopCenter;
            this.enhListing.BackColor = Color.FromArgb(0, 0, 32);
            this.enhListing.Columns = 1;
            this.enhListing.DoHighlight = true;
            this.enhListing.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)178);
            this.enhListing.ForceBold = false;
            this.enhListing.HighlightColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
            this.enhListing.HighlightTextColor = Color.Black;
            this.enhListing.ItemColor = Color.White;
            this.enhListing.ItemColorAlt = Color.Yellow;
            this.enhListing.ItemColorSpecCase = Color.Red;
            this.enhListing.ItemColorSpecial = Color.FromArgb(128, 128, (int)byte.MaxValue);
            point = new Point(4, 44);
            this.enhListing.Location = point;
            this.enhListing.Name = "enhListing";
            this.enhListing.NameColor = Color.FromArgb(192, 192, (int)byte.MaxValue);
            size = new Size(292, 192);
            this.enhListing.Size = size;
            this.enhListing.TabIndex = 71;
            this.enhListing.ValueWidth = 65;
            this.Enh_Title.BackColor = Color.FromArgb(64, 64, 64);
            this.Enh_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.Enh_Title.ForeColor = Color.White;
            this.Enh_Title.InitialText = "Title";
            point = new Point(24, 4);
            this.Enh_Title.Location = point;
            this.Enh_Title.Name = "Enh_Title";
            size = new Size(252, 16);
            this.Enh_Title.Size = size;
            this.Enh_Title.TabIndex = 70;
            this.Enh_Title.TextAlign = ContentAlignment.TopCenter;
            this.dbTip.AutoPopDelay = 15000;
            this.dbTip.InitialDelay = 350;
            this.dbTip.ReshowDelay = 100;
            this.lblFloat.BackColor = Color.FromArgb(64, 64, 64);
            this.lblFloat.BorderStyle = BorderStyle.FixedSingle;
            this.lblFloat.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)2);
            this.lblFloat.ForeColor = Color.White;
            point = new Point(4, 24);
            this.lblFloat.Location = point;
            this.lblFloat.Name = "lblFloat";
            size = new Size(16, 16);
            this.lblFloat.Size = size;
            this.lblFloat.TabIndex = 66;
            this.lblFloat.Text = "F";
            this.lblFloat.TextAlign = ContentAlignment.MiddleCenter;
            this.dbTip.SetToolTip((Control)this.lblFloat, "Make Floating Window");
            this.lblFloat.UseCompatibleTextRendering = true;
            this.lblShrink.BackColor = Color.FromArgb(64, 64, 64);
            this.lblShrink.BorderStyle = BorderStyle.FixedSingle;
            this.lblShrink.Font = new Font("Wingdings", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)2);
            this.lblShrink.ForeColor = Color.White;
            point = new Point(280, 24);
            this.lblShrink.Location = point;
            this.lblShrink.Name = "lblShrink";
            size = new Size(16, 16);
            this.lblShrink.Size = size;
            this.lblShrink.TabIndex = 67;
            this.lblShrink.Text = "y";
            this.lblShrink.TextAlign = ContentAlignment.MiddleCenter;
            this.dbTip.SetToolTip((Control)this.lblShrink, "Shrink / Expland the Info Display");
            this.lblShrink.UseCompatibleTextRendering = true;
            this.lblLock.BackColor = Color.Red;
            this.lblLock.BorderStyle = BorderStyle.FixedSingle;
            this.lblLock.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLock.ForeColor = Color.White;
            point = new Point(220, 24);
            this.lblLock.Location = point;
            this.lblLock.Name = "lblLock";
            size = new Size(56, 16);
            this.lblLock.Size = size;
            this.lblLock.TabIndex = 68;
            this.lblLock.Text = "[Unlock]";
            this.lblLock.TextAlign = ContentAlignment.MiddleCenter;
            this.dbTip.SetToolTip((Control)this.lblLock, "The info display is currently locked to display a specific power, click here to unlock it to display powers as you hover the mouse over them.");
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(0, 0, 32);
            this.Controls.Add((Control)this.lblLock);
            this.Controls.Add((Control)this.lblFloat);
            this.Controls.Add((Control)this.lblShrink);
            this.Controls.Add((Control)this.pnlTabs);
            this.Controls.Add((Control)this.pnlInfo);
            this.Controls.Add((Control)this.pnlTotal);
            this.Controls.Add((Control)this.pnlEnh);
            this.Controls.Add((Control)this.pnlFX);
            this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.Name = nameof(DataView);
            size = new Size(564, 540);
            this.Size = size;
            this.pnlInfo.ResumeLayout(false);
            this.pnlFX.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlEnh.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {

                // Enh_Title events
                this.Enh_Title.MouseMove += Title_MouseMove;
                this.Enh_Title.MouseDown += Title_MouseDown;

                this.PowerScaler.BarClick += PowerScaler_BarClick;
                this.enhListing.ItemHover += PairedList_Hover;
                this.fx_List1.ItemHover += PairedList_Hover;
                this.fx_List2.ItemHover += PairedList_Hover;
                this.fx_List3.ItemHover += PairedList_Hover;

                // fx_Title events
                this.fx_Title.MouseMove += Title_MouseMove;
                this.fx_Title.MouseDown += Title_MouseDown;

                this.info_DataList.ItemHover += PairedList_Hover;

                // info_Title events
                this.info_Title.MouseMove += Title_MouseMove;
                this.info_Title.MouseDown += Title_MouseDown;

                this.lblFloat.Click += lblFloat_Click;
                this.lblLock.Click += lblLock_Click;

                // lblShrink events
                this.lblShrink.DoubleClick += lblShrink_DoubleClick;
                this.lblShrink.Click += lblShrink_Click;


                // pnlEnhActive events
                this.pnlEnhActive.Paint += pnlEnhActive_Paint;
                this.pnlEnhActive.MouseMove += pnlEnhActive_MouseMove;
                this.pnlEnhActive.MouseClick += pnlEnhActive_MouseClick;


                // pnlEnhInactive events
                this.pnlEnhInactive.Paint += pnlEnhInactive_Paint;
                this.pnlEnhInactive.MouseMove += pnlEnhInactive_MouseMove;
                this.pnlEnhInactive.MouseClick += pnlEnhInactive_MouseClick;


                // pnlTabs events
                this.pnlTabs.MouseDown += pnlTabs_MouseDown;
                this.pnlTabs.Paint += pnlTabs_Paint;

                this.total_Misc.ItemHover += PairedList_Hover;

                // total_Title events
                this.total_Title.MouseMove += Title_MouseMove;
                this.total_Title.MouseDown += Title_MouseDown;

            }
            // finished with events
            this.ResumeLayout(false);
        }

        static bool IsMezEffect(string iStr)

        {
            string[] names = Enum.GetNames(Enums.eMez.None.GetType());
            int num = names.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (string.Equals(iStr, names[index], StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        void lblFloat_Click(object sender, EventArgs e)

        {
            DataView.FloatChangeEventHandler floatChange = this.FloatChange;
            if (floatChange == null)
                return;
            floatChange();
        }

        void lblLock_Click(object sender, EventArgs e)

        {
            DataView.Unlock_ClickEventHandler unlockClick = this.Unlock_Click;
            if (unlockClick != null)
                unlockClick();
            this.lblLock.Visible = false;
            this.pnlTabs.Select();
        }

        void lblShrink_Click(object sender, EventArgs e)

        {
            if (this.Compact)
                this.ResetSize();
            else
                this.CompactSize();
        }

        void lblShrink_DoubleClick(object sender, EventArgs e)

        {
            this.lblShrink_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        int miniGetEnhIndex(int iX, int iY)

        {
            int num1 = this.bxFlip.Size.Width - 188;
            if (this.pBase != null)
            {
                int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
                if (inToonHistory < 0)
                    return -1;
                int num2 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    Rectangle rectangle = new Rectangle(num1 + 30 * index, (int)Math.Round(((double)this.bxFlip.Size.Height / 2.0 - 30.0) / 2.0), 30, 30);
                    if (iX > rectangle.X & iX < rectangle.X + rectangle.Width && iY > rectangle.Y & iY < rectangle.Y + rectangle.Height)
                        return index;
                }
            }
            return -1;
        }

        void PairedList_Hover(object Sender, int Index, Enums.ShortFX Tag)

        {
            string empty1 = string.Empty;
            string str1;
            if (Tag.Present)
            {
                int[] numArray = new int[0];
                string empty2 = string.Empty;
                IPower power = (IPower)new Power(this.pEnh);
                int num1 = Tag.Index.Length - 1;
                for (int index1 = 0; index1 <= num1; ++index1)
                {
                    if (Tag.Index[index1] != -1 && power.Effects[Tag.Index[index1]].EffectType != Enums.eEffectType.None)
                    {
                        string empty3 = string.Empty;
                        int[] returnMask = new int[0];
                        power.GetEffectStringGrouped(Tag.Index[index1], ref empty3, ref returnMask, false, false, false);
                        if (returnMask.Length > 0)
                        {
                            if (empty2 != string.Empty)
                                empty2 += "\r\n";
                            empty2 += empty3;
                            int num2 = returnMask.Length - 1;
                            for (int index2 = 0; index2 <= num2; ++index2)
                                power.Effects[returnMask[index2]].EffectType = Enums.eEffectType.None;
                        }
                    }
                }
                int num3 = Tag.Index.Length - 1;
                for (int index = 0; index <= num3; ++index)
                {
                    if (power.Effects[Tag.Index[index]].EffectType != Enums.eEffectType.None)
                    {
                        if (empty2 != string.Empty)
                            empty2 += "\r\n";
                        empty2 += power.Effects[Tag.Index[index]].BuildEffectString(false, "", false, false, false);
                    }
                }
                str1 = empty1 + empty2;
            }
            else
                str1 = "No Valid Tip";
            object[] Arguments = new object[1] { (object)str1 };
            bool[] CopyBack = new bool[1] { true };
            NewLateBinding.LateCall(Sender, (System.Type)null, "SetTip", Arguments, (string[])null, (System.Type[])null, CopyBack, true);
            if (!CopyBack[0])
                return;
            string str2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(Arguments[0]), typeof(string));
        }

        void pnlEnhActive_MouseClick(object sender, MouseEventArgs e)

        {
            if (this.pBase == null || e.Button != MouseButtons.Left)
                return;
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
            if (inToonHistory > -1)
            {
                DataView.SlotFlipEventHandler slotFlip = this.SlotFlip;
                if (slotFlip != null)
                    slotFlip(inToonHistory);
            }
        }

        void pnlEnhActive_MouseMove(object sender, MouseEventArgs e)

        {
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
            int enhIndex = this.miniGetEnhIndex(e.X, e.Y);
            if (enhIndex <= -1)
                return;
            this.SetEnhancement(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Enhancement, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Level);
        }

        void pnlEnhActive_Paint(object sender, PaintEventArgs e)

        {
            this.RedrawFlip();
        }

        void pnlEnhInactive_MouseClick(object sender, MouseEventArgs e)

        {
            if (this.pBase == null || e.Button != MouseButtons.Left)
                return;
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
            if (inToonHistory > -1)
            {
                DataView.SlotFlipEventHandler slotFlip = this.SlotFlip;
                if (slotFlip != null)
                    slotFlip(inToonHistory);
            }
        }

        void pnlEnhInactive_MouseMove(object sender, MouseEventArgs e)

        {
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(this.pBase.PowerIndex);
            int enhIndex = this.miniGetEnhIndex(e.X, e.Y);
            if (enhIndex <= -1)
                return;
            this.SetEnhancement(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].FlippedEnhancement, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Level);
        }

        void pnlEnhInactive_Paint(object sender, PaintEventArgs e)

        {
            this.RedrawFlip();
        }

        void pnlTabs_MouseDown(object sender, MouseEventArgs e)

        {
            Rectangle clipRect = new Rectangle(0, 0, 70, this.pnlTabs.Height);
            int Index = 0;
            while (!(e.X >= clipRect.X & e.X <= clipRect.Width + clipRect.X))
            {
                clipRect.X += clipRect.Width;
                ++Index;
                if (Index > 3)
                    return;
            }
            if (Index != this.TabPage)
            {
                DataView.TabChangedEventHandler tabChanged = this.TabChanged;
                if (tabChanged != null)
                    tabChanged(Index);
            }
            this.TabPage = Index;
            this.pnlTabs_Paint((object)this, new PaintEventArgs(this.pnlTabs.CreateGraphics(), clipRect));
        }

        void pnlTabs_Paint(object sender, PaintEventArgs e)

        {
            this.DoPaint();
        }

        void PowerScaler_BarClick(float Value)

        {
            int num = (int)Math.Round((double)Value);
            if (num < this.pBase.VariableMin)
                num = this.pBase.VariableMin;
            if (num > this.pBase.VariableMax)
                num = this.pBase.VariableMax;
            MidsContext.Character.CurrentBuild.Powers[this.HistoryIDX].VariableValue = num;
            if (num == this.pLastScaleVal)
                return;
            this.SetPowerScaler();
            this.pLastScaleVal = num;
            MainModule.MidsController.Toon.GenerateBuffedPowerArray();
            DataView.SlotUpdateEventHandler slotUpdate = this.SlotUpdate;
            if (slotUpdate != null)
                slotUpdate();
        }

        void RedrawFlip()

        {
            if (this.bxFlip == null)
                this.DisplayFlippedEnhancements();
            Rectangle srcRect = new Rectangle(0, 0, this.pnlEnhActive.Width, this.pnlEnhActive.Height);
            Rectangle destRect = new Rectangle(0, 0, this.pnlEnhActive.Width, this.pnlEnhActive.Height);
            this.pnlEnhActive.CreateGraphics().DrawImage((Image)this.bxFlip.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            srcRect = new Rectangle(0, this.pnlEnhActive.Height, this.pnlEnhInactive.Width, this.pnlEnhInactive.Height);
            this.pnlEnhInactive.CreateGraphics().DrawImage((Image)this.bxFlip.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
        }

        void ResetSize()

        {
            Size size = this.Size;
            this.info_txtSmall.Height = 32;
            this.info_txtLarge.Top = this.info_txtSmall.Bottom + 4;
            if (this.PowerScaler.Visible)
            {
                this.info_txtLarge.Height = 100 - this.PowerScaler.Height;
                this.PowerScaler.Top = this.info_txtLarge.Bottom;
                this.info_DataList.Top = this.PowerScaler.Bottom + 4;
            }
            else
            {
                this.info_txtLarge.Height = 100;
                this.PowerScaler.Top = this.info_txtLarge.Bottom - this.PowerScaler.Height;
                this.info_DataList.Top = this.info_txtLarge.Bottom + 4;
            }
            this.info_DataList.Height = 104;
            this.lblDmg.Visible = true;
            this.lblDmg.Top = this.info_DataList.Bottom + 4;
            this.info_Damage.Top = this.lblDmg.Bottom + 4;
            this.info_Damage.PaddingV = 6;
            this.info_Damage.Height = 36;
            this.enhListing.Height = this.info_Damage.Bottom - (this.enhListing.Top + (this.pnlEnhActive.Height + 4) * 2);
            this.pnlEnhActive.Top = this.enhListing.Bottom + 4;
            this.pnlEnhInactive.Top = this.pnlEnhActive.Bottom + 4;
            this.pnlInfo.Height = this.info_Damage.Bottom + 4;
            this.pnlEnh.Height = this.pnlInfo.Height;
            this.Height = this.pnlInfo.Bottom;
            this.Compact = false;
            if (!(this.Size != size))
                return;
            DataView.SizeChangeEventHandler sizeChange = this.SizeChange;
            if (sizeChange != null)
                sizeChange(this.Size, this.Compact);
        }

        void SetBackColor()

        {
            this.info_Title.BackColor = this.BackColor;
            this.info_txtLarge.BackColor = this.BackColor;
            this.info_txtSmall.BackColor = this.BackColor;
            this.info_DataList.BackColor = this.BackColor;
            this.info_Damage.BackColor = this.BackColor;
            this.fx_List1.BackColor = this.BackColor;
            this.fx_List2.BackColor = this.BackColor;
            this.fx_List3.BackColor = this.BackColor;
            this.fx_Title.BackColor = this.BackColor;
            this.total_Misc.BackColor = this.BackColor;
            this.total_Title.BackColor = this.BackColor;
            this.enhListing.BackColor = this.BackColor;
            this.Enh_Title.BackColor = this.BackColor;
            this.enhNameDisp.BackColor = this.BackColor;
            this.DoPaint();
            this.lblFloat.BackColor = this.BackColor;
            this.lblShrink.BackColor = this.BackColor;
            this.info_DataList.Draw();
            this.info_Damage.Draw();
            this.fx_List1.Draw();
            this.fx_List2.Draw();
            this.fx_List3.Draw();
            this.total_Misc.Draw();
            this.enhListing.Draw();
        }

        void SetDamageTip()

        {
            string iTip = string.Empty;
            int num1 = -1;
            int num2 = -1;
            int num3 = 0;
            int num4 = this.pEnh.Effects.Length - 1;
            for (int index = 0; index <= num4; ++index)
            {
                IEffect effect = this.pEnh.Effects[index];
                if (effect.EffectType == Enums.eEffectType.Damage)
                {
                    if (effect.CanInclude() & this.pEnh.Effects[index].PvXInclude())
                    {
                        if (iTip != string.Empty)
                            iTip += "\r\n";
                        string str = this.pEnh.Effects[index].BuildEffectString(false, "", false, false, false);
                        if (this.pEnh.Effects[index].isEnahncementEffect & this.pEnh.PowerType == Enums.ePowerType.Toggle)
                        {
                            ++num1;
                            str += " (Special only every 10s)";
                        }
                        else if (this.pEnh.PowerType == Enums.ePowerType.Toggle)
                            ++num2;
                        iTip += str;
                    }
                    else
                        ++num3;
                }
            }
            if (num3 > 0)
            {
                if (iTip != string.Empty)
                    iTip += "\r\n";
                iTip += "\r\nThis power deals different damage in PvP and PvE modes.";
            }
            if (!(this.pBase.PowerType == Enums.ePowerType.Toggle & num1 == -1 & num2 == -1) && this.pBase.PowerType == Enums.ePowerType.Toggle & num2 > -1 && iTip != string.Empty)
                iTip = "Applied every " + Conversions.ToString(this.pBase.ActivatePeriod) + "s:\r\n" + iTip;
            this.info_Damage.SetTip(iTip);
        }

        public void SetData(
          IPower iBase,
          IPower iEnhanced,
          bool noLevel = false,
          bool Locked = false,
          int iHistoryIDX = -1)
        {
            if (iBase == null)
                return;
            this.Lock = Locked;
            this.pBase = (IPower)new Power(iBase);
            this.pEnh = iEnhanced != null ? (iEnhanced.Effects.Length == iBase.Effects.Length ? (IPower)new Power(iEnhanced) : (IPower)new Power(iBase)) : (IPower)new Power(iBase);
            this.HistoryIDX = iHistoryIDX;
            this.SetDamageTip();
            this.DisplayData(noLevel, -1);
            this.SizeRefresh();
        }

        public void SetEnhancement(I9Slot iEnh, int iLevel = -1)
        {
            if (this.Lock & this.TabPage != 3 || iLevel < 0)
                return;
            string str1;
            if (iEnh.Enh > -1)
            {
                str1 = DatabaseAPI.Database.Enhancements[iEnh.Enh].LongName;
                if (str1.Length > 38 & iLevel > -1)
                    str1 = DatabaseAPI.GetEnhancementNameShortWSet(iEnh.Enh);
            }
            else
            {
                str1 = this.pBase.DisplayName;
                this.info_txtSmall.Rtf = RTF.StartRTF() + this.pBase.DescShort + "\r\n" + RTF.Color(RTF.ElementID.Faded) + "Shift+Click to move slot. Right-Click to place enh." + RTF.EndRTF();
            }
            if (iLevel > -1 & !MidsContext.Config.ShowSlotLevels)
                str1 = str1 + " (Slot Level " + Conversions.ToString(iLevel + 1) + ")";
            this.info_Title.Text = str1;
            this.fx_Title.Text = str1;
            this.enhNameDisp.Text = str1;
            if (this.TabPage <= 1 && iEnh.Enh >= 0)
            {
                string iStr1 = string.Empty;
                string str2 = string.Empty;
                if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.InventO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
                    iStr1 = RTF.Color(RTF.ElementID.Invention) + "Invention Level: " + Conversions.ToString(iEnh.IOLevel + 1) + Enums.GetRelativeString(iEnh.RelativeLevel, false) + RTF.Color(RTF.ElementID.Text);
                if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SpecialO)
                {
                    if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
                    {
                        if (DatabaseAPI.Database.Enhancements[iEnh.Enh].Unique)
                            iStr1 = iStr1 + RTF.Color(RTF.ElementID.Warning) + " (Unique) " + RTF.Color(RTF.ElementID.Text);
                        if ((double)DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance < 1.0 & (double)DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 0.0)
                            str2 = str2 + RTF.Color(RTF.ElementID.Enhancement) + Strings.Format((object)(float)((double)DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance * 100.0), "##0") + "% chance of ";
                    }
                    else
                        iStr1 = iStr1 + RTF.Color(RTF.ElementID.Enhancement) + "Hamidon/Synthetic Hamidon Origin Enhancement";
                }
                else
                {
                    if (iStr1 != string.Empty)
                        iStr1 += " - ";
                    iStr1 += DataView.GetEnhancementStringRTF(iEnh);
                }
                string iStr2;
                if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
                {
                    iStr2 = str2 + DataView.GetEnhancementStringLongRTF(iEnh) + "\r\n" + EnhancementSetCollection.GetSetInfoLongRTF(DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet, -1);
                }
                else
                {
                    string str3 = str2 + DatabaseAPI.Database.Enhancements[iEnh.Enh].Desc;
                    if (str3 != string.Empty)
                        str3 += "\r\n";
                    iStr2 = str3 + DataView.GetEnhancementStringLongRTF(iEnh);
                }
                this.info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr1) + RTF.Crlf() + RTF.Color(RTF.ElementID.Faded) + "Shift+Click to move slot. Right-Click to place enh." + RTF.EndRTF();
                this.info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr2) + RTF.EndRTF();
            }
        }

        public void SetEnhancementPicker(I9Slot iEnh)
        {
            if (iEnh.Enh < 0)
                this.info_Title.Text = "No Enhancement";
            this.info_Title.Text = DatabaseAPI.Database.Enhancements[iEnh.Enh].LongName;
            if (iEnh.Enh < 0)
                return;
            string str1 = string.Empty;
            string iStr1 = string.Empty;
            if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.InventO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
                iStr1 = RTF.Color(RTF.ElementID.Invention) + "Invention Level: " + Conversions.ToString(iEnh.IOLevel + 1) + Enums.GetRelativeString(iEnh.RelativeLevel, false) + RTF.Color(RTF.ElementID.Text);
            if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SpecialO)
            {
                if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
                {
                    if (DatabaseAPI.Database.Enhancements[iEnh.Enh].Unique)
                        iStr1 = iStr1 + RTF.Color(RTF.ElementID.Warning) + " (Unique) " + RTF.Color(RTF.ElementID.Text);
                    if ((double)DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 1.0 & (double)DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 0.0)
                        str1 = str1 + RTF.Color(RTF.ElementID.Enhancement) + Strings.Format((object)(float)((double)DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance * 100.0), "##0") + "% chance of ";
                }
                else
                    iStr1 += "Hamidon/Synthetic Hamidon Origin Enhancement";
            }
            else
            {
                if (iStr1 != string.Empty)
                    iStr1 += " - ";
                iStr1 += DataView.GetEnhancementStringRTF(iEnh);
            }
            string iStr2;
            if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
            {
                iStr2 = str1 + DataView.GetEnhancementStringLongRTF(iEnh) + RTF.Size(RTF.SizeID.Tiny) + "\r\n" + EnhancementSetCollection.GetSetInfoLongRTF(DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet, -1);
            }
            else
            {
                string str2 = str1 + DatabaseAPI.Database.Enhancements[iEnh.Enh].Desc;
                if (str2 != string.Empty)
                    str2 += "\r\n";
                iStr2 = str2 + DataView.GetEnhancementStringLongRTF(iEnh);
            }
            this.info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr1) + RTF.Crlf() + RTF.EndRTF();
            this.info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr2) + RTF.EndRTF();
        }

        public void SetFontData()
        {
            this.info_DataList.Font = new Font(this.info_DataList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            this.fx_List1.Font = new Font(this.fx_List1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            this.fx_List2.Font = new Font(this.fx_List2.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            this.fx_List3.Font = new Font(this.fx_List3.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            this.total_Misc.Font = new Font(this.total_Misc.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            this.enhListing.Font = new Font(this.enhListing.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            this.pnlEnhActive.Font = new Font(this.enhListing.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold);
            this.info_DataList.ForceBold = MidsContext.Config.RtFont.PairedBold;
            this.fx_List1.ForceBold = MidsContext.Config.RtFont.PairedBold;
            this.fx_List2.ForceBold = MidsContext.Config.RtFont.PairedBold;
            this.fx_List3.ForceBold = MidsContext.Config.RtFont.PairedBold;
            this.total_Misc.ForceBold = MidsContext.Config.RtFont.PairedBold;
            this.enhListing.ForceBold = MidsContext.Config.RtFont.PairedBold;
            this.gDef1.Font = new Font(this.gDef1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold);
            this.gDef2.Font = this.gDef1.Font;
            this.gRes1.Font = this.gDef1.Font;
            this.gRes2.Font = this.gDef1.Font;
            this.SetBackColor();
            this.info_DataList.NameColor = MidsContext.Config.RtFont.ColorPlName;
            this.fx_List1.NameColor = MidsContext.Config.RtFont.ColorPlName;
            this.fx_List2.NameColor = MidsContext.Config.RtFont.ColorPlName;
            this.fx_List3.NameColor = MidsContext.Config.RtFont.ColorPlName;
            this.total_Misc.NameColor = MidsContext.Config.RtFont.ColorPlName;
            this.enhListing.NameColor = MidsContext.Config.RtFont.ColorPlName;
            this.info_DataList.ItemColor = MidsContext.Config.RtFont.ColorText;
            this.fx_List1.ItemColor = MidsContext.Config.RtFont.ColorText;
            this.fx_List2.ItemColor = MidsContext.Config.RtFont.ColorText;
            this.fx_List3.ItemColor = MidsContext.Config.RtFont.ColorText;
            this.enhListing.ItemColor = MidsContext.Config.RtFont.ColorText;
            this.total_Misc.ItemColor = MidsContext.Config.RtFont.ColorText;
            this.info_DataList.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            this.fx_List1.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            this.fx_List2.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            this.fx_List3.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            this.enhListing.ItemColorAlt = Color.Yellow;
            this.total_Misc.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            this.info_DataList.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            this.fx_List1.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            this.fx_List2.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            this.fx_List3.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            this.enhListing.ValueColorD = Color.Red;
            this.total_Misc.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            this.info_DataList.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            this.fx_List1.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            this.fx_List2.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            this.fx_List3.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            this.enhListing.ItemColorSpecial = Color.FromArgb(0, (int)byte.MaxValue, 0);
            this.total_Misc.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
        }

        public void SetLocation(Point iLocation, bool Force)
        {
            bool flag = Force | this.SnapLocation.X == this.Location.X & this.SnapLocation.Y == this.Location.Y;
            this.SnapLocation.X = iLocation.X;
            this.SnapLocation.Y = iLocation.Y;
            this.SnapLocation.Width = this.Width;
            if (this.SnapLocation.Height < this.Height)
                this.SnapLocation.Height = this.Height;
            if (!flag)
                return;
            this.Left = this.SnapLocation.X;
            this.Top = this.SnapLocation.Y;
        }

        void SetPowerScaler()

        {
            if (this.pBase == null)
                this.PowerScaler.Visible = false;
            else if (this.pBase.VariableEnabled & this.HistoryIDX > -1)
            {
                string str = this.pBase.VariableName;
                if (string.IsNullOrEmpty(str))
                    str = "Targets";
                this.PowerScaler.Visible = true;
                this.PowerScaler.BeginUpdate();
                this.PowerScaler.ForcedMax = (float)this.pBase.VariableMax;
                this.PowerScaler.Clear();
                this.PowerScaler.AddItem(str + ":|" + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[this.HistoryIDX].VariableValue), (float)MidsContext.Character.CurrentBuild.Powers[this.HistoryIDX].VariableValue, 0.0f, "Use this slider to vary the power's effect.\r\nMin: " + Conversions.ToString(this.pBase.VariableMin) + "\r\nMax: " + Conversions.ToString(this.pBase.VariableMax));
                this.PowerScaler.EndUpdate();
            }
            else
                this.PowerScaler.Visible = false;
        }

        public void SetScreenBounds(Rectangle iBounds)
        {
            this.ScreenBounds = iBounds;
        }

        public void SetSetPicker(int iSet)
        {
            if (iSet < 0)
            {
                this.info_Title.Text = "No Enhancement";
                this.info_txtLarge.Text = string.Empty;
                this.info_txtSmall.Text = string.Empty;
            }
            else
            {
                this.info_Title.Text = DatabaseAPI.Database.EnhancementSets[iSet].DisplayName;
                string str1 = DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[iSet].SetType];
                if (!this.Compact)
                    str1 += RTF.Crlf();
                string str2 = DatabaseAPI.Database.EnhancementSets[iSet].LevelMin != DatabaseAPI.Database.EnhancementSets[iSet].LevelMax ? Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1) + " to " + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMax + 1) : Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1);
                this.info_txtSmall.Rtf = RTF.StartRTF() + (str1 + RTF.Color(RTF.ElementID.Invention) + "Level: " + str2 + RTF.Color(RTF.ElementID.Text)) + RTF.EndRTF();
                this.info_txtLarge.Rtf = RTF.StartRTF() + EnhancementSetCollection.GetSetInfoLongRTF(iSet, -1) + RTF.EndRTF();
            }
        }

        bool sFXCheck(Enums.ShortFX isFX)

        {
            if (isFX.Index != null)
            {
                int num = isFX.Index.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (this.pBase.Effects.Length > isFX.Index[index] & isFX.Index[index] > -1 && this.pBase.Effects[isFX.Index[index]].isEnahncementEffect)
                        return true;
                }
            }
            return false;
        }

        string ShortStr(string full, string brief)

        {
            return (double)this.info_DataList.Font.Size <= (double)(68f / (float)full.Length) ? full : brief;
        }

        void SizeRefresh()

        {
            if (this.Compact)
                this.CompactSize();
            else
                this.ResetSize();
        }

        bool SplitFX_AddToList(

          ref Enums.ShortFX BaseSFX,
          ref Enums.ShortFX EnhSFX,
          ref ctlPairedList iList,
          string SpecialTitle = "")
        {
            bool flag;
            if (!BaseSFX.Present)
            {
                flag = false;
            }
            else
            {
                Enums.ShortFX[] shortFxArray1 = Power.SplitFX(ref BaseSFX, ref this.pBase);
                Enums.ShortFX[] shortFxArray2 = Power.SplitFX(ref EnhSFX, ref this.pEnh);
                int num1 = shortFxArray1.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (shortFxArray1[index].Present)
                    {
                        string Suffix = string.Empty;
                        float num2 = shortFxArray1[index].Value[0];
                        float num3 = index < shortFxArray2.Length ? shortFxArray2[index].Value[0] : shortFxArray2[index - 1].Value[0];
                        if (this.pEnh.Effects[shortFxArray1[index].Index[0]].DisplayPercentage)
                        {
                            Suffix = "%";
                            IEffect effect = this.pEnh.Effects[shortFxArray1[index].Index[0]];
                            if ((effect.EffectType == Enums.eEffectType.Heal | effect.EffectType == Enums.eEffectType.Endurance | effect.EffectType == Enums.eEffectType.Damage) & this.pEnh.Effects[shortFxArray1[index].Index[0]].Aspect == Enums.eAspect.Cur)
                            {
                                num2 *= 100f;
                                num3 *= 100f;
                            }
                        }
                        else
                        {
                            switch (this.pEnh.Effects[shortFxArray1[index].Index[0]].EffectType)
                            {
                                case Enums.eEffectType.Heal:
                                    Suffix = " HP";
                                    break;
                                case Enums.eEffectType.HitPoints:
                                    Suffix = " HP";
                                    break;
                            }
                        }
                        string Title = Enums.GetEffectNameShort(this.pEnh.Effects[shortFxArray1[index].Index[0]].EffectType);
                        if (SpecialTitle != string.Empty)
                            Title = SpecialTitle;
                        float s1 = num2;
                        float s2 = num3;
                        if ((this.pEnh.Effects[shortFxArray1[index].Index[0]].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        {
                            s1 = 0.0f;
                            s2 = 0.0f;
                        }
                        iList.AddItem(DataView.FastItem(Title, s1, s2, Suffix, false, false, (double)this.pEnh.Effects[shortFxArray1[index].Index[0]].Probability < 1.0, this.pEnh.Effects[shortFxArray1[index].Index[0]].SpecialCase != Enums.eSpecialCase.None, Power.SplitFXGroupTip(ref shortFxArray1[index], ref this.pEnh, false)));
                        if (this.pEnh.Effects[shortFxArray1[index].Index[0]].isEnahncementEffect)
                            iList.SetUnique();
                    }
                }
                flag = true;
            }
            return flag;
        }

        void Title_MouseDown(object sender, MouseEventArgs e)

        {
            this.mouse_offset = new Point(-e.X, -e.Y);
        }

        void Title_MouseMove(object sender, MouseEventArgs e)

        {
            if (e.Button != MouseButtons.Left || this.MoveDisable)
                return;
            Point point1 = new Point(e.X, e.Y);
            point1.Offset(this.mouse_offset.X, this.mouse_offset.Y);
            Point point2 = new Point();
            ref Point local = ref point2;
            Point location = this.Location;
            int x = location.X + point1.X;
            location = this.Location;
            int y = location.Y + point1.Y;
            local = new Point(x, y);
            if (point2.X - 10 < this.SnapLocation.X)
                point2.X = this.SnapLocation.X;
            if (point2.X + this.Width + 10 > this.ScreenBounds.Right & point2.X + this.Width - 20 < this.ScreenBounds.Right)
                point2.X = this.ScreenBounds.Right;
            if (point2.Y + 10 > this.SnapLocation.Y & point2.Y - 20 <= this.SnapLocation.Y)
                point2.Y = this.SnapLocation.Y;
            if (point2.Y < this.ScreenBounds.Top)
                point2.Y = this.ScreenBounds.Top;
            if (point2.Y + this.info_Title.Bottom + this.pnlInfo.Top > this.ScreenBounds.Bottom)
                point2.Y = this.ScreenBounds.Bottom - (this.pnlInfo.Top + this.info_Title.Bottom);
            if (point2.X + this.Width > this.ScreenBounds.Right)
                point2.X = this.ScreenBounds.Right - this.Width;
            if (this.Location != point2)
            {
                this.Location = point2;
                DataView.MovedEventHandler moved = this.Moved;
                if (moved != null)
                    moved();
            }
        }

        public delegate void FloatChangeEventHandler();

        public delegate void MovedEventHandler();

        public delegate void SizeChangeEventHandler(Size newSize, bool isCompact);

        public delegate void SlotFlipEventHandler(int PowerIndex);

        public delegate void SlotUpdateEventHandler();

        public delegate void TabChangedEventHandler(int Index);

        public delegate void Unlock_ClickEventHandler();
    }
}
