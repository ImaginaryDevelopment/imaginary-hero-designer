
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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
    public class DataView : UserControl
    {
        const int SnapDistance = 10;

        protected const int szDataList = 104;
        protected const int szLargeText = 100;
        protected const int szLineHeight = 16;
        protected const int szPadding = 4;
        ToolTip dbTip;
        GFXLabel Enh_Title;
        ctlPairedList enhListing;
        GFXLabel enhNameDisp;
        Label fx_lblHead1;
        Label fx_lblHead2;
        Label fx_LblHead3;
        ctlPairedList fx_List1;
        ctlPairedList fx_List2;
        ctlPairedList fx_List3;
        GFXLabel fx_Title;
        ctlMultiGraph gDef1;
        ctlMultiGraph gDef2;
        ctlMultiGraph gRes1;
        ctlMultiGraph gRes2;
        ctlDamageDisplay info_Damage;
        ctlPairedList info_DataList;
        GFXLabel info_Title;
        RichTextBox info_txtLarge;
        RichTextBox info_txtSmall;
        Label lblDmg;
        Label lblFloat;
        Label lblLock;
        Label lblShrink;
        Label lblTotal;
        Panel pnlEnh;
        Panel pnlEnhActive;
        Panel pnlEnhInactive;
        Panel pnlFX;
        Panel pnlInfo;
        Panel pnlTabs;
        Panel pnlTotal;
        ctlMultiGraph PowerScaler;
        Label total_lblDef;
        Label total_lblMisc;
        Label total_lblRes;
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
        readonly string[] Pages;

        IPower pBase;

        IPower pEnh;

        int pLastScaleVal;

        Rectangle ScreenBounds;

        public Rectangle SnapLocation;
        public int TabPage;
        bool VillainColour;

        public event FloatChangeEventHandler FloatChange;

        public event MovedEventHandler Moved;

        public event SizeChangeEventHandler SizeChange;

        public event SlotFlipEventHandler SlotFlip;

        public event SlotUpdateEventHandler SlotUpdate;

        public event TabChangedEventHandler TabChanged;

        public event Unlock_ClickEventHandler Unlock_Click;

        public bool DrawVillain
        {
            get
            {
                return VillainColour;
            }
            set
            {
                VillainColour = value;
                if (MidsContext.Config.DisableVillainColours)
                    VillainColour = false;
                if (VillainColour)
                    pnlInfo.BackColor = Color.Maroon;
                else
                    pnlInfo.BackColor = Color.Navy;
                DoPaint();
            }
        }

        public bool Floating
        {
            get
            {
                return bFloating;
            }
            set
            {
                bFloating = value;
                if (bFloating)
                {
                    dbTip.SetToolTip(lblFloat, "Dock Info Display");
                    lblFloat.Text = "D";
                }
                else
                {
                    dbTip.SetToolTip(lblFloat, "Make Floating Window");
                    lblFloat.Text = "F";
                }
            }
        }

        internal ctlDamageDisplay Info_Damage
        {
            get
            {
                return info_Damage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            private set
            {
                info_Damage = value;
            }
        }
        internal RichTextBox Info_txtLarge
        {
            get
            {
                return info_txtLarge;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                info_txtLarge = value;
            }
        }

        public bool IsDocked
        {
            get
            {
                return SnapLocation.X == Location.X & SnapLocation.Y == Location.Y;
            }
        }

        public int TabPageIndex
        {
            get
            {
                return TabPage;
            }
        }

        public Enums.eVisibleSize VisibleSize
        {
            get
            {
                return !Compact ? Enums.eVisibleSize.Full : Enums.eVisibleSize.Compact;
            }
            // why is this ignored?
            set { }
        }

        public DataView()
        {
            MoveDisable = false;
            TabPage = 0;
            Pages = new string[4]
            {
                "Info",
                "Effects",
                "Totals",
                "Enhance"
            };
            pLastScaleVal = -1;
            Lock = false;
            bFloating = false;
            HistoryIDX = -1;
            Compact = false;
            bxFlip = null;
            InitializeComponent();
            BackColorChanged += DataView_BackColorChanged;
            Load += DataView_Load;
            Name = nameof(DataView);
        }

        static ctlPairedList.ItemPair BuildEDItem(

          int index,
          IReadOnlyList<float> value,
          IReadOnlyList<Enums.eSchedule> schedule,
          string Name,
          IReadOnlyList<float> afterED)
        {
            bool flag1 = value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][0];
            bool flag2 = value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][1];
            bool iSpecialCase = value[index] > (double)DatabaseAPI.Database.MultED[(int)schedule[index]][2];
            ctlPairedList.ItemPair itemPair;
            if (value[index] <= 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, string.Empty);
            }
            else
            {
                string iName = Name + ":";
                float num1 = value[index] * 100f;
                float num2 = Enhancement.ApplyED(schedule[index], value[index]) * 100f;
                float num3 = num2 + afterED[index] * 100f;
                float num4 = (float)Math.Round(num1 - (double)num2, 3);
                string str1 = Strings.Format(num1, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str2 = Strings.Format(num4, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str3 = Strings.Format(num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%";
                string str4 = "Total Effect: " + Strings.Format((float)(num1 + afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\nWith ED Applied: " + str3 + "\r\n\r\n";
                string iValue;
                string iTip;
                if (num4 > 0.0)
                {
                    iValue = str3 + "  (Pre-ED: " + Strings.Format((float)(num1 + afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%)";
                    if (afterED[index] > 0.0)
                        str4 = str4 + "Amount from pre-ED sources: " + str1 + "\r\n";
                    iTip = str4 + "ED reduction: " + str2 + " (" + Strings.Format((float)(num4 / (double)num1 * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "% of total)\r\n";
                    if (iSpecialCase)
                        iTip = iTip + "The highest level of ED reduction is being applied.\r\nThreshold: " + Strings.Format((float)(DatabaseAPI.Database.MultED[(int)schedule[index]][2] * 100.0), "##0") + "%\r\n";
                    else if (flag2)
                        iTip = iTip + "The middle level of ED reduction is being applied.\r\nThreshold: " + Strings.Format((float)(DatabaseAPI.Database.MultED[(int)schedule[index]][1] * 100.0), "##0") + "%\r\n";
                    else if (flag1)
                        iTip = iTip + "The lowest level of ED reduction is being applied.\r\nThreshold: " + Strings.Format((float)(DatabaseAPI.Database.MultED[(int)schedule[index]][0] * 100.0), "##0") + "%\r\n";
                    if (afterED[index] > 0.0)
                        iTip = iTip + "Amount from post-ED sources: " + Strings.Format((float)(afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\n";
                }
                else
                {
                    iValue = str3;
                    if (afterED[index] > 0.0)
                        str4 = str4 + "Amount from post-ED sources: " + Strings.Format((float)(afterED[index] * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "%\r\n";
                    iTip = str4 + "This effect has not been affected by ED.\r\n";
                }
                itemPair = new ctlPairedList.ItemPair(iName, iValue, flag2 & !iSpecialCase, flag1 & !flag2, iSpecialCase, iTip);
            }
            return itemPair;
        }

        static string CapString(string iString, int capLength)
            => iString.Length >= capLength ? iString.Substring(0, capLength) : iString;

        public void Clear()
        {
            info_DataList.Clear(true);
            info_Title.Text = Pages[0];
            info_txtLarge.Text = string.Empty;
            info_txtSmall.Text = "Hold the mouse over a power to see its description.";
            PowerScaler.Visible = false;
            fx_lblHead1.Text = string.Empty;
            fx_lblHead2.Text = string.Empty;
            fx_LblHead3.Text = string.Empty;
            fx_List1.Clear(true);
            fx_List2.Clear(true);
            fx_List3.Clear(true);
            fx_Title.Text = Pages[1];
            enhListing.Clear(true);
            Enh_Title.Text = "Enhancements";
            total_Misc.Clear(true);
        }

        void CompactSize()

        {
            Size size = Size;
            info_txtSmall.Height = 16;
            info_txtLarge.Top = info_txtSmall.Bottom + 4;
            if (PowerScaler.Visible)
            {
                info_txtLarge.Height = 48 - PowerScaler.Height;
                PowerScaler.Top = info_txtLarge.Bottom;
                info_DataList.Top = PowerScaler.Bottom + 4;
            }
            else
            {
                info_txtLarge.Height = 48;
                PowerScaler.Top = info_txtLarge.Bottom - PowerScaler.Height;
                info_DataList.Top = info_txtLarge.Bottom + 4;
            }
            info_DataList.Height = 76;
            lblDmg.Visible = true;
            lblDmg.Top = info_DataList.Bottom + 4;
            info_Damage.Top = lblDmg.Bottom + 4;
            info_Damage.PaddingV = 1;
            info_Damage.Height = 30;
            enhListing.Height = info_Damage.Bottom - (enhListing.Top + (pnlEnhActive.Height + 4) * 2);
            pnlEnhActive.Top = enhListing.Bottom + 4;
            pnlEnhInactive.Top = pnlEnhActive.Bottom + 4;
            pnlInfo.Height = info_Damage.Bottom + 4;
            pnlEnh.Height = pnlInfo.Height;
            Height = pnlInfo.Bottom;
            Compact = true;
            if (!(Size != size))
                return;
            SizeChange?.Invoke(Size, Compact);
        }

        void DataView_BackColorChanged(object sender, EventArgs e)
            => SetBackColor();

        void DataView_Load(object sender, EventArgs e)
        {
            Panel pnlInfo = this.pnlInfo;
            pnlInfo.Top = 20;
            pnlInfo.Left = 0;
            Panel pnlFx = pnlFX;
            pnlFx.Top = 20;
            pnlFx.Left = 0;
            Panel pnlTotal = this.pnlTotal;
            pnlTotal.Top = 20;
            pnlTotal.Left = 0;
            Panel pnlEnh = this.pnlEnh;
            pnlEnh.Top = 20;
            pnlEnh.Left = 0;
            ctlDamageDisplay infoDamage = info_Damage;
            infoDamage.nBaseVal = 0.0f;
            infoDamage.nEnhVal = 0.0f;
            infoDamage.nHighBase = 0.0f;
            infoDamage.nHighEnh = 0.0f;
            infoDamage.nMaxEnhVal = 0.0f;
            info_txtLarge.Height = 100;
            Floating = bFloating;
            Clear();
        }

        void Display_EDFigures()
        {
            Enh_Title.Text = pBase.DisplayName;
            enhListing.Clear();
            if (MidsContext.Character == null)
            {
                enhListing.Draw();
            }
            else
            {
                int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
                if (inToonHistory < 0)
                {
                    enhListing.Draw();
                }
                else
                {
                    const Enums.eEnhance eEnhance = Enums.eEnhance.None;
                    const Enums.eMez eMez = Enums.eMez.None;
                    var eEnhs = Enum.GetValues(eEnhance.GetType()).Length;
                    float[] numArray1 = new float[eEnhs];
                    float[] numArray2 = new float[eEnhs];
                    float[] numArray3 = new float[eEnhs];
                    Enums.eSchedule[] schedule1 = new Enums.eSchedule[eEnhs];
                    Enums.eSchedule[] schedule2 = new Enums.eSchedule[eEnhs];
                    Enums.eSchedule[] schedule3 = new Enums.eSchedule[eEnhs];
                    float[] afterED1 = new float[eEnhs];
                    float[] afterED2 = new float[eEnhs];
                    float[] afterED3 = new float[eEnhs];
                    float[] numArray4 = new float[Enum.GetValues(eMez.GetType()).Length];
                    Enums.eSchedule[] schedule4 = new Enums.eSchedule[eEnhs];
                    float[] afterED4 = new float[eEnhs];
                    for (int index = 0; index <= numArray1.Length - 1; ++index)
                    {
                        numArray1[index] = 0.0f;
                        numArray2[index] = 0.0f;
                        numArray3[index] = 0.0f;
                        schedule1[index] = Enhancement.GetSchedule((Enums.eEnhance)index);
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
                            IPower power1 = new Power(MidsContext.Character.CurrentBuild.Powers[index1].Power);
                            power1.AbsorbPetEffects();
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
                        if (numArray1[index] > 0.0)
                        {
                            enhListing.AddItem(BuildEDItem(index, numArray1, schedule1, Enum.GetName(eEnhance.GetType(), index), afterED1));
                            if (enhListing.IsSpecialColor())
                                enhListing.SetUnique();
                        }
                        if (numArray2[index] > 0.0)
                        {
                            enhListing.AddItem(BuildEDItem(index, numArray2, schedule2, Enum.GetName(eEnhance.GetType(), index) + " Debuff", afterED2));
                            if (enhListing.IsSpecialColor())
                                enhListing.SetUnique();
                        }
                        if (numArray3[index] > 0.0)
                        {
                            enhListing.AddItem(BuildEDItem(index, numArray3, schedule3, Enum.GetName(eEnhance.GetType(), index), afterED3));
                            if (enhListing.IsSpecialColor())
                                enhListing.SetUnique();
                        }
                    }
                    int num7 = numArray4.Length - 1;
                    for (int index = 0; index <= num7; ++index)
                    {
                        if (numArray4[index] > 0.0)
                        {
                            enhListing.AddItem(BuildEDItem(index, numArray4, schedule4, Enum.GetName(eMez.GetType(), index), afterED4));
                            if (enhListing.IsSpecialColor())
                                enhListing.SetUnique();
                        }
                    }
                    enhListing.Draw();
                    DisplayFlippedEnhancements();
                }
            }
        }

        void display_Info(bool NoLevel = false, int iEnhLvl = -1)
        {
            if (!NoLevel & pBase.Level > 0)
                info_Title.Text = "[" + Conversions.ToString(pBase.Level) + "] " + pBase.DisplayName;
            else
                info_Title.Text = pBase.DisplayName;
            if (iEnhLvl > -1)
            {
                GFXLabel infoTitle = info_Title;
                infoTitle.Text = infoTitle.Text + " (Slot Level " + Conversions.ToString(iEnhLvl + 1) + ")";
            }
            enhNameDisp.Text = "Enhancement Values";
            info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(pBase.DescShort) + RTF.EndRTF();
            info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(pBase.DescLong) + RTF.EndRTF();
            string Suffix1 = pBase.PowerType != Enums.ePowerType.Toggle ? string.Empty : "/s";
            info_DataList.Clear();
            string Tip1 = string.Empty;
            if (pBase.PowerType == Enums.ePowerType.Click)
            {
                if (pEnh.ToggleCost > 0.0 & pEnh.RechargeTime + (double)pEnh.CastTime + pEnh.InterruptTime > 0.0)
                    Tip1 = "Effective end drain per second: " + Utilities.FixDP(pEnh.ToggleCost / (pEnh.RechargeTime + pEnh.CastTime + pEnh.InterruptTime)) + "/s";
                if (pEnh.ToggleCost > 0.0 & MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.Numeric)
                {
                    float damageValue = pEnh.FXGetDamageValue();
                    if (damageValue > 0.0)
                    {
                        if (Tip1 != string.Empty)
                            Tip1 += "\r\n";
                        Tip1 = Tip1 + "Effective damage per unit of end: " + Utilities.FixDP(damageValue / pEnh.ToggleCost);
                    }
                }
            }
            info_DataList.AddItem(FastItem(ShortStr("End Cost", "End"), pBase.ToggleCost, pEnh.ToggleCost, Suffix1, Tip1));
            var flag1 = pBase.HasAbsorbedEffects && pBase.PowerIndex > -1 && DatabaseAPI.Database.Power[pBase.PowerIndex].EntitiesAutoHit == Enums.eEntity.None;
            bool flag2 = false;
            int num1 = pBase.Effects.Length - 1;
            for (int index = 0; index <= num1 & !flag2; ++index)
            {
                if (pBase.Effects[index].RequiresToHitCheck)
                    flag2 = true;
            }
            if (pBase.EntitiesAutoHit == Enums.eEntity.None | flag2 | flag1 | pBase.Range > 20.0 & pBase.I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt))
            {
                float accuracy1 = pBase.Accuracy;
                float accuracy2 = pEnh.Accuracy;
                float num2 = MidsContext.Config.BaseAcc * pBase.Accuracy;
                string str = string.Empty;
                string Suffix2 = "%";
                if (pBase.EntitiesAutoHit != Enums.eEntity.None & flag2)
                {
                    str = "\r\n* This power is autohit, but has an effect that requires a ToHit roll.";
                    Suffix2 += "*";
                }
                if (accuracy1 != (double)accuracy2 & num2 != (double)accuracy2)
                {
                    string Tip2 = "Accuracy multiplier without other buffs (Real Numbers style): " + Strings.Format((float)(pBase.Accuracy + (pEnh.Accuracy - (double)MidsContext.Config.BaseAcc)), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00000") + "x" + str;
                    info_DataList.AddItem(FastItem(ShortStr("Accuracy", "Acc"), (float)(MidsContext.Config.BaseAcc * (double)pBase.Accuracy * 100.0), pEnh.Accuracy * 100f, Suffix2, Tip2));
                }
                else
                {
                    string Tip2 = "Accuracy multiplier without other buffs (Real Numbers style): " + Strings.Format(pBase.AccuracyMult, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") + "x" + str;
                    info_DataList.AddItem(FastItem(ShortStr("Accuracy", "Acc"), (float)(MidsContext.Config.BaseAcc * (double)pBase.Accuracy * 100.0), (float)(MidsContext.Config.BaseAcc * (double)pBase.Accuracy * 100.0), Suffix2, Tip2));
                }
            }
            else
                info_DataList.AddItem(new ctlPairedList.ItemPair(string.Empty, string.Empty, false, false, false, string.Empty));
            info_DataList.AddItem(FastItem(ShortStr("Recharge", "Rchg"), pBase.RechargeTime, pEnh.RechargeTime, "s"));
            float s1 = 0.0f;
            float s2 = 0.0f;
            int durationEffectId = pBase.GetDurationEffectID();
            if (durationEffectId > -1)
            {
                if (pBase.Effects[durationEffectId].EffectType == Enums.eEffectType.EntCreate & pBase.Effects[durationEffectId].Duration >= 9999.0)
                {
                    s1 = 0.0f;
                    s2 = 0.0f;
                }
                else
                {
                    s1 = pBase.Effects[durationEffectId].Duration;
                    s2 = pEnh.Effects[durationEffectId].Duration;
                }
            }
            info_DataList.AddItem(FastItem(ShortStr("Duration", "Durtn"), s1, s2, "s"));
            info_DataList.AddItem(FastItem(ShortStr("Range", "Range"), pBase.Range, pEnh.Range, string.Empty));
            if (pBase.Arc > 0)
                info_DataList.AddItem(FastItem("Arc", pBase.Arc, pEnh.Arc, "°"));
            else
                info_DataList.AddItem(FastItem("Radius", pBase.Radius, pEnh.Radius, string.Empty));
            info_DataList.AddItem(FastItem(ShortStr("Cast Time", "Cast"), pBase.CastTime, pEnh.CastTime, "s", false, true, false, false, -1, 3));
            if (pBase.PowerType == Enums.ePowerType.Toggle)
                info_DataList.AddItem(FastItem(ShortStr("Activate", "Act"), pBase.ActivatePeriod, pEnh.ActivatePeriod, "s", "The effects of this toggle power are applied at this interval."));
            else
                info_DataList.AddItem(FastItem(ShortStr("Interrupt", "Intrpt"), pBase.InterruptTime, pEnh.InterruptTime, "s", "After activating this power, it can be interrupted for this amount of time."));
            int num3 = 2;
            if (num3 > 1 && durationEffectId > -1 && pBase.Effects[durationEffectId].EffectType == Enums.eEffectType.Mez & pBase.Effects[durationEffectId].MezType != Enums.eMez.Taunt)
            {
                info_DataList.AddItem(new ctlPairedList.ItemPair("Effect:", Enum.GetName(Enums.eMez.None.GetType(), pBase.Effects[durationEffectId].MezType), false, pBase.Effects[durationEffectId].Probability < 1.0, pBase.Effects[durationEffectId].SpecialCase != Enums.eSpecialCase.None, durationEffectId));
                bool iAlternate = pBase.Effects[durationEffectId].Mag != (double)pEnh.Effects[durationEffectId].Mag;
                info_DataList.AddItem(new ctlPairedList.ItemPair("Mag:", Conversions.ToString(pEnh.Effects[durationEffectId].Mag), iAlternate, pBase.Effects[durationEffectId].Probability < 1.0));
                num3 -= 2;
            }
            int[] rankedEffects = pBase.GetRankedEffects();
            int num4 = rankedEffects.Length - 1;
            for (int ID = 0; ID <= num4; ++ID)
            {
                if (num3 > 0 && rankedEffects[ID] > -1)
                {
                    ctlPairedList.ItemPair rankedEffect = GetRankedEffect(rankedEffects, ID);
                    if (pBase.Effects[rankedEffects[ID]].Probability > 0.0 & (MidsContext.Config.Suppression & pBase.Effects[rankedEffects[ID]].Suppression) == Enums.eSuppress.None & pBase.Effects[rankedEffects[ID]].CanInclude())
                    {
                        if (pBase.Effects[rankedEffects[ID]].EffectType != Enums.eEffectType.Enhancement)
                        {
                            if (pBase.Effects[rankedEffects[ID]].EffectType != Enums.eEffectType.Mez)
                            {
                                if (pBase.Effects[rankedEffects[ID]].EffectType == Enums.eEffectType.EntCreate)
                                {
                                    rankedEffect.Name = "Summon";
                                    if (pBase.Effects[rankedEffects[ID]].nSummon > -1)
                                    {
                                        rankedEffect.Value = DatabaseAPI.Database.Entities[pBase.Effects[rankedEffects[ID]].nSummon].DisplayName;
                                    }
                                    else
                                    {
                                        rankedEffect.Value = pBase.Effects[rankedEffects[ID]].Summon;
                                        if (rankedEffect.Value.StartsWith("MastermindPets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("MastermindPets_", string.Empty);
                                        if (rankedEffect.Value.StartsWith("Pets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("Pets_", string.Empty);
                                        if (rankedEffect.Value.StartsWith("Villain_Pets_"))
                                            rankedEffect.Value = rankedEffect.Value.Replace("Villain_Pets_", string.Empty);
                                    }
                                    --num3;
                                }
                                else if (pBase.Effects[rankedEffects[ID]].EffectType == Enums.eEffectType.RevokePower)
                                {
                                    rankedEffect.Name = "Revoke";
                                    if (pBase.Effects[rankedEffects[ID]].nSummon > -1)
                                    {
                                        rankedEffect.Value = DatabaseAPI.Database.Entities[pBase.Effects[rankedEffects[ID]].nSummon].DisplayName;
                                    }
                                    else
                                    {
                                        rankedEffect.Value = pBase.Effects[rankedEffects[ID]].Summon;
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
                                    rankedEffect.Name = ShortStr(Enums.GetEffectName(pBase.Effects[rankedEffects[ID]].EffectType), Enums.GetEffectNameShort(pBase.Effects[rankedEffects[ID]].EffectType));
                            }
                            else
                                rankedEffect.Name = ShortStr(Enums.GetMezName((Enums.eMezShort)pBase.Effects[rankedEffects[ID]].MezType), Enums.GetMezNameShort((Enums.eMezShort)pBase.Effects[rankedEffects[ID]].MezType));
                        }
                        info_DataList.AddItem(rankedEffect);
                        if (pBase.Effects[rankedEffects[ID]].isEnhancementEffect)
                            info_DataList.SetUnique();
                        --num3;
                    }
                }
            }
            info_DataList.Draw();
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
            float damageValue1 = pBase.FXGetDamageValue();
            if (pBase.NIDSubPower.Length > 0 & damageValue1 == 0.0)
            {
                lblDmg.Text = string.Empty;
                info_Damage.nBaseVal = 0.0f;
                info_Damage.nMaxEnhVal = 0.0f;
                info_Damage.nEnhVal = 0.0f;
                info_Damage.Text = string.Empty;
            }
            else
            {
                lblDmg.Text = str1 + ":";
                float damageValue2 = pEnh.FXGetDamageValue();
                float num2 = damageValue1 * (1f + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
                info_Damage.nBaseVal = damageValue1;
                info_Damage.nMaxEnhVal = num2;
                info_Damage.nEnhVal = damageValue2;
                if (damageValue2 != (double)damageValue1)
                    info_Damage.Text = pEnh.FXGetDamageString() + " (" + Utilities.FixDP(damageValue1) + ")";
                else
                    info_Damage.Text = pBase.FXGetDamageString();
            }
            SetPowerScaler();
        }

        void DisplayData(bool noLevel = false, int iEnhLevel = -1)
        {
            if (MidsContext.Config.DisableDataDamageGraph)
            {
                info_Damage.GraphType = MidsContext.Config.DataGraphType;
                switch (MidsContext.Config.DataGraphType)
                {
                    case Enums.eDDGraph.Simple:
                        ctlDamageDisplay infoDamage1 = info_Damage;
                        infoDamage1.TextAlign = Enums.eDDAlign.Center;
                        infoDamage1.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                    case Enums.eDDGraph.Enhanced:
                        ctlDamageDisplay infoDamage2 = info_Damage;
                        infoDamage2.TextAlign = Enums.eDDAlign.Center;
                        infoDamage2.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                    case Enums.eDDGraph.Both:
                        ctlDamageDisplay infoDamage3 = info_Damage;
                        infoDamage3.TextAlign = Enums.eDDAlign.Center;
                        infoDamage3.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                    case Enums.eDDGraph.Stacked:
                        ctlDamageDisplay infoDamage4 = info_Damage;
                        infoDamage4.TextAlign = Enums.eDDAlign.Center;
                        infoDamage4.Style = Enums.eDDStyle.TextUnderGraph;
                        break;
                }
            }
            else
            {
                ctlDamageDisplay infoDamage = info_Damage;
                infoDamage.TextAlign = Enums.eDDAlign.Center;
                infoDamage.Style = Enums.eDDStyle.Text;
            }
            lblLock.Visible = Lock & TabPage != 2;
            display_Info(noLevel, iEnhLevel);
            DisplayEffects(noLevel, iEnhLevel);
            Display_EDFigures();
        }

        void DisplayEffects(bool noLevel = false, int iEnhLvl = -1)
        {
            if (!noLevel & pBase.Level > 0)
                fx_Title.Text = "[" + Conversions.ToString(pBase.Level) + "] " + pBase.DisplayName;
            else
                fx_Title.Text = pBase.DisplayName;
            if (iEnhLvl > -1)
            {
                GFXLabel fxTitle = fx_Title;
                fxTitle.Text = fxTitle.Text + " (Slot Level " + Conversions.ToString(iEnhLvl + 1) + ")";
            }
            ctlPairedList[] ctlPairedListArray = new ctlPairedList[3]
            {
                fx_List1,
                fx_List2,
                fx_List3
            };
            Label[] labelArray = new Label[3]
            {
                fx_lblHead1,
                fx_lblHead2,
                fx_LblHead3
            };
            fx_List1.Clear();
            fx_List2.Clear();
            fx_List3.Clear();
            fx_lblHead1.Text = string.Empty;
            fx_lblHead2.Text = string.Empty;
            fx_LblHead3.Text = string.Empty;
            int index = EffectsDrh();
            int num1 = 0;
            bool flag1 = false;
            bool flag2 = false;
            if (index < ctlPairedListArray.Length)
            {
                ctlPairedListArray[index].Clear();
                num1 = effects_Heal(labelArray[index], ctlPairedListArray[index]);
                if (num1 > 0)
                {
                    flag2 = true;
                    ++index;
                    if (index < ctlPairedListArray.Length)
                        ctlPairedListArray[index].Clear();
                }
            }
            if (index < ctlPairedListArray.Length)
            {
                num1 = effects_Status(labelArray[index], ctlPairedListArray[index]);
                if (num1 > 0)
                    flag1 = true;
                if (num1 > 2 | num1 > 0 & index == 0)
                {
                    ++index;
                    if (index < ctlPairedListArray.Length)
                        ctlPairedListArray[index].Clear();
                }
            }
            if (!flag1 & flag2 & num1 < 3)
                --index;
            if (index < ctlPairedListArray.Length && effects_BuffDebuff(labelArray[index], ctlPairedListArray[index]) > 0 & ctlPairedListArray[index].ItemCount > 2 & index + 1 < ctlPairedListArray.Length)
            {
                ++index;
                if (index < ctlPairedListArray.Length)
                    ctlPairedListArray[index].Clear();
            }
            if (index < ctlPairedListArray.Length)
                index += effects_Movement(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
                index += effects_Summon(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
                index += effects_GrantPower(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
                index += effects_ModifyEffect(labelArray[index], ctlPairedListArray[index]);
            if (index < ctlPairedListArray.Length)
            {
                int num2 = index + effects_Elusivity(labelArray[index], ctlPairedListArray[index]);
            }
            if (fx_lblHead1.Text != string.Empty)
                fx_lblHead1.Text += ":";
            if (fx_lblHead2.Text != string.Empty)
                fx_lblHead2.Text += ":";
            if (fx_LblHead3.Text != string.Empty)
                fx_LblHead3.Text += ":";
            fx_List1.Draw();
            fx_List2.Draw();
            fx_List3.Draw();
        }

        void DisplayFlippedEnhancements()
        {
            Pen pen = enhListing.BackColor.B <= 10 ? new Pen(Color.FromArgb(byte.MaxValue, 0, 0)) : new Pen(Color.FromArgb(0, 0, byte.MaxValue));
            if (bxFlip == null)
                bxFlip = new ExtendedBitmap(pnlEnhActive.Width, pnlEnhInactive.Height * 2);
            bxFlip.Graphics.Clear(enhListing.BackColor);
            bxFlip.Graphics.DrawRectangle(pen, 0, 0, pnlEnhActive.Width - 1, pnlEnhInactive.Height - 1);
            bxFlip.Graphics.DrawRectangle(pen, 0, pnlEnhInactive.Height, pnlEnhActive.Width - 1, pnlEnhInactive.Height - 1);
            if (pBase == null)
                return;
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
            if (inToonHistory < 0)
            {
                RedrawFlip();
            }
            else
            {
                StringFormat format = new StringFormat();
                int num1 = bxFlip.Size.Width - 188;
                Rectangle rectangle1 = new Rectangle();
                ref Rectangle local1 = ref rectangle1;
                int width = num1;
                Size size = bxFlip.Size;
                int height = (int)Math.Round(size.Height / 2.0);
                local1 = new Rectangle(-4, 0, width, height);
                SolidBrush solidBrush1 = new SolidBrush(enhListing.NameColor);
                format.Alignment = StringAlignment.Far;
                format.LineAlignment = StringAlignment.Center;
                bxFlip.Graphics.DrawString("Active Slotting:", pnlEnhActive.Font, solidBrush1, rectangle1, format);
                rectangle1.Y += rectangle1.Height;
                bxFlip.Graphics.DrawString("Alternate:", pnlEnhActive.Font, solidBrush1, rectangle1, format);
                ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MidsContext.Character.IsHero());
                SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                int num2 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    Rectangle iDest = new Rectangle();
                    ref Rectangle local2 = ref iDest;
                    int x1 = num1 + 30 * index;
                    size = bxFlip.Size;
                    int y1 = (int)Math.Round((size.Height / 2.0 - 30.0) / 2.0);
                    local2 = new Rectangle(x1, y1, 30, 30);
                    Rectangle rectangle2 = new Rectangle();
                    ref Rectangle local3 = ref rectangle2;
                    int x2 = num1 + 30 * index;
                    size = bxFlip.Size;
                    double num3 = size.Height / 2.0;
                    size = bxFlip.Size;
                    double num4 = (size.Height / 2.0 - 30.0) / 2.0;
                    int y2 = (int)Math.Round(num3 + num4);
                    local3 = new Rectangle(x2, y2, 30, 30);
                    RectangleF Bounds;
                    Rectangle destRect;
                    if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
                    {
                        Graphics graphics1 = bxFlip.Graphics;
                        I9Gfx.DrawEnhancementAt(ref graphics1, iDest, DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Grade));
                        if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh > -1)
                        {
                            if (!MidsContext.Config.I9.HideIOLevels & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.InventO))
                            {
                                Bounds = iDest;
                                Bounds.Y -= 3f;
                                Bounds.Height = DefaultFont.GetHeight(bxFlip.Graphics);
                                Graphics graphics2 = bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.IOLevel + 1), Bounds, Color.Cyan, Color.FromArgb(128, 0, 0, 0), pnlEnhActive.Font, 1f, graphics2);
                            }
                            else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.Enh].TypeID == Enums.eType.SpecialO))
                            {
                                Bounds = iDest;
                                Bounds.Y -= 3f;
                                Bounds.Height = DefaultFont.GetHeight(bxFlip.Graphics);
                                Color Text = MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel != Enums.eEnhRelative.None ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel >= Enums.eEnhRelative.Even ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel <= Enums.eEnhRelative.Even ? Color.White : Color.FromArgb(0, byte.MaxValue, byte.MaxValue)) : Color.Yellow) : Color.Red;
                                Graphics graphics2 = bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].Enhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols), Bounds, Text, Color.FromArgb(128, 0, 0, 0), pnlEnhActive.Font, 1f, graphics2);
                            }
                        }
                    }
                    else
                    {
                        destRect = new Rectangle(iDest.X, iDest.Y, 30, 30);
                        bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, destRect, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                    }
                    if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh > -1)
                    {
                        Graphics graphics1 = bxFlip.Graphics;
                        I9Gfx.DrawEnhancementAt(ref graphics1, rectangle2, DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Grade));
                        if (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh > -1)
                        {
                            if (!MidsContext.Config.I9.HideIOLevels & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.InventO))
                            {
                                Bounds = rectangle2;
                                Bounds.Y -= 3f;
                                Bounds.Height = DefaultFont.GetHeight(bxFlip.Graphics);
                                Graphics graphics2 = bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.IOLevel + 1), Bounds, Color.Cyan, Color.FromArgb(128, 0, 0, 0), pnlEnhActive.Font, 1f, graphics2);
                            }
                            else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.Enh].TypeID == Enums.eType.SpecialO))
                            {
                                Bounds = rectangle2;
                                Bounds.Y -= 3f;
                                Bounds.Height = DefaultFont.GetHeight(bxFlip.Graphics);
                                Color Text = MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel != Enums.eEnhRelative.None ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel >= Enums.eEnhRelative.Even ? (MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel <= Enums.eEnhRelative.Even ? Color.White : Color.FromArgb(0, byte.MaxValue, byte.MaxValue)) : Color.Yellow) : Color.Red;
                                Graphics graphics2 = bxFlip.Graphics;
                                clsDrawX.DrawOutlineText(Enums.GetRelativeString(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[index].FlippedEnhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols), Bounds, Text, Color.FromArgb(128, 0, 0, 0), pnlEnhActive.Font, 1f, graphics2);
                            }
                        }
                    }
                    else
                    {
                        destRect = new Rectangle(rectangle2.X, rectangle2.Y, 30, 30);
                        bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, destRect, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                    }
                    rectangle2.Inflate(2, 2);
                    bxFlip.Graphics.FillEllipse(solidBrush2, rectangle2);
                }
                RedrawFlip();
            }
        }

        public void DisplayTotals()
        {
            if (MidsContext.Character == null)
                return;
            string[] names = Enum.GetNames(Enums.eDamage.None.GetType());
            total_Misc.Clear();
            Statistics displayStats = MidsContext.Character.DisplayStats;
            gDef1.Clear();
            gDef2.Clear();
            int[] numArray1 = new int[16]
            {
                0, 0, 0, 1,
                1, 0, 0, 1,
                0, 0, 1, 1,
                1, 0, 0, 0
            };
            int num1 = names.Length - 1;
            for (int dType = 1; dType <= num1; ++dType)
            {
                string iTip = Strings.Format(displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType] + " defense";
                if (dType != 9 & dType != 7)
                {
                    if (numArray1[dType] == 0)
                        gDef1.AddItem(names[dType] + ":|" + Strings.Format(displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.Defense(dType), 0.0f, iTip);
                    else
                        gDef2.AddItem(names[dType] + ":|" + Strings.Format(displayStats.Defense(dType), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.Defense(dType), 0.0f, iTip);
                }
            }
            float num2 = gDef1.GetMaxValue();
            float maxValue1 = gDef2.GetMaxValue();
            if (maxValue1 > (double)num2)
                num2 = maxValue1;
            gDef1.Max = num2;
            gDef2.Max = num2;
            gDef1.Draw();
            gDef2.Draw();
            string str = MidsContext.Character.Archetype.DisplayName + " resistance cap: " + Strings.Format((float)(MidsContext.Character.Archetype.ResCap * 100.0), "###0") + "%";
            gRes1.Clear();
            gRes2.Clear();
            int[] numArray2 = new int[13]
            {
                0, 0, 0, 1,
                1, 0, 0, 1,
                1, 0, 1, 1,
                1
            };
            int dType1 = 1;
            do
            {
                if (dType1 != 9)
                {
                    string iTip;
                    if (MidsContext.Character.TotalsCapped.Res[dType1] < (double)MidsContext.Character.Totals.Res[dType1])
                        iTip = Strings.Format(displayStats.DamageResistance(dType1, true), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType1] + " resistance capped at " + Strings.Format(displayStats.DamageResistance(dType1, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "%";
                    else
                        iTip = Strings.Format(displayStats.DamageResistance(dType1, true), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "% " + names[dType1] + " resistance. (" + str + ")";
                    if (numArray2[dType1] == 0)
                        gRes1.AddItem(names[dType1] + ":|" + Strings.Format(displayStats.DamageResistance(dType1, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.DamageResistance(dType1, false), displayStats.DamageResistance(dType1, true), iTip);
                    else
                        gRes2.AddItem(names[dType1] + ":|" + Strings.Format(displayStats.DamageResistance(dType1, false), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", displayStats.DamageResistance(dType1, false), displayStats.DamageResistance(dType1, true), iTip);
                }
                ++dType1;
            }
            while (dType1 <= 9);
            float num3 = gRes1.GetMaxValue();
            float maxValue2 = gRes2.GetMaxValue();
            if (maxValue2 > (double)num3)
                num3 = maxValue2;
            gRes1.Max = num3;
            gRes2.Max = num3;
            gRes1.Draw();
            gRes2.Draw();
            string iTip1 = string.Empty;
            string iTip2 = "Time to go from 0-100% end: " + Utilities.FixDP(displayStats.EnduranceTimeToFull) + "s.\r\nHover the mouse over the End Drain stats for more info.";
            if (displayStats.EnduranceRecoveryNet > 0.0)
            {
                iTip1 = "Net Endurance Gain (Recovery - Drain): " + Utilities.FixDP(displayStats.EnduranceRecoveryNet) + "/s.";
                if (displayStats.EnduranceRecoveryNet != (double)displayStats.EnduranceRecoveryNumeric)
                    iTip1 = iTip1 + "\r\nTime to go from 0-100% end (using net gain): " + Utilities.FixDP(displayStats.EnduranceTimeToFullNet) + "s.";
            }
            else if (displayStats.EnduranceRecoveryNet < 0.0)
                iTip1 = "With current end drain, you will lose end at a rate of: " + Utilities.FixDP(displayStats.EnduranceRecoveryLossNet) + "/s.\r\nFrom 100% you would run out of end in: " + Utilities.FixDP(displayStats.EnduranceTimeToZero) + "s.";
            string iTip3 = "Time to go from 0-100% health: " + Utilities.FixDP(displayStats.HealthRegenTimeToFull) + "s.\r\nHealth regenerated per second: " + Utilities.FixDP(displayStats.HealthRegenHealthPerSec) + "%\r\nHitPoints regenerated per second at level 50: " + Utilities.FixDP(displayStats.HealthRegenHPPerSec) + " HP";
            total_Misc.AddItem(new ctlPairedList.ItemPair("Recovery:", Strings.Format(displayStats.EnduranceRecoveryPercentage(false), "###0") + "% (" + Strings.Format(displayStats.EnduranceRecoveryNumeric, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s)", false, false, false, iTip2));
            total_Misc.AddItem(new ctlPairedList.ItemPair("Regen:", Strings.Format(displayStats.HealthRegenPercent(false), "###0") + "%", false, false, false, iTip3));
            total_Misc.AddItem(new ctlPairedList.ItemPair("EndDrain:", Strings.Format(displayStats.EnduranceUsage, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s", false, false, false, iTip1));
            total_Misc.AddItem(new ctlPairedList.ItemPair("+ToHit:", Strings.Format(displayStats.BuffToHit, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "This effect is increasing the accuracy of all your powers."));
            total_Misc.AddItem(new ctlPairedList.ItemPair("+EndRdx:", Strings.Format(displayStats.BuffEndRdx, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "The end cost of all your powers is being reduced by this effect.\r\nThis is applied like an end-reduction enhancement."));
            total_Misc.AddItem(new ctlPairedList.ItemPair("+Recharge:", Strings.Format((float)(displayStats.BuffHaste(false) - 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%", false, false, false, "The recharge time of your powers is being altered by this effect.\r\nThe higher the value, the faster the recharge."));
            total_Misc.Draw();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            try
            {
                bxFlip?.Dispose();
            }
            catch { }
            base.Dispose(disposing);
        }

        void DoPaint()
        {
            Graphics graphics = pnlTabs.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            Font font1 = new Font(Font, FontStyle.Regular);
            Font font2 = new Font(Font, FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            SolidBrush solidBrush1 = new SolidBrush(Color.White);
            SolidBrush solidBrush2 = new SolidBrush(BackColor);
            SolidBrush solidBrush3 = new SolidBrush(Color.Black);
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(pnlTabs.Size);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Rectangle rect = new Rectangle(0, 0, 75, pnlTabs.Height);
            extendedBitmap.Graphics.FillRectangle(solidBrush2, extendedBitmap.ClipRect);
            switch (TabPage)
            {
                case 0:
                    pnlInfo.Visible = true;
                    pnlFX.Visible = false;
                    pnlTotal.Visible = false;
                    pnlEnh.Visible = false;
                    lblLock.Visible = Lock;
                    solidBrush3 = new SolidBrush(pnlInfo.BackColor);
                    pen = new Pen(pnlInfo.BackColor, 1f);
                    break;
                case 1:
                    pnlInfo.Visible = false;
                    pnlFX.Visible = true;
                    pnlTotal.Visible = false;
                    pnlEnh.Visible = false;
                    lblLock.Visible = Lock;
                    solidBrush3 = new SolidBrush(pnlFX.BackColor);
                    pen = new Pen(pnlFX.BackColor, 1f);
                    break;
                case 2:
                    pnlInfo.Visible = false;
                    pnlFX.Visible = false;
                    pnlTotal.Visible = true;
                    pnlEnh.Visible = false;
                    lblLock.Visible = false;
                    solidBrush3 = new SolidBrush(pnlTotal.BackColor);
                    pen = new Pen(pnlTotal.BackColor, 1f);
                    break;
                case 3:
                    pnlInfo.Visible = false;
                    pnlFX.Visible = false;
                    pnlTotal.Visible = false;
                    pnlEnh.Visible = true;
                    lblLock.Visible = Lock;
                    pen = new Pen(pnlEnh.BackColor, 1f);
                    solidBrush3 = new SolidBrush(pnlEnh.BackColor);
                    break;
            }
            int num = Pages.Length - 1;
            RectangleF layoutRectangle;
            for (int index = 0; index <= num; ++index)
            {
                rect = new Rectangle(rect.Width * index, 2, 70, pnlTabs.Height - 2);
                layoutRectangle = new RectangleF(rect.X, rect.Y + (float)((rect.Height - (double)font1.GetHeight(graphics)) / 2.0), rect.Width, font1.GetHeight(graphics));
                extendedBitmap.Graphics.DrawRectangle(pen, rect);
                extendedBitmap.Graphics.DrawString(Pages[index], font1, solidBrush1, layoutRectangle, format);
            }
            rect = new Rectangle(70 * TabPage, 0, 70, pnlTabs.Height);
            layoutRectangle = new RectangleF(rect.X, (float)((rect.Height - (double)font1.GetHeight(graphics)) / 2.0), rect.Width, font1.GetHeight(graphics));
            extendedBitmap.Graphics.FillRectangle(solidBrush3, rect);
            extendedBitmap.Graphics.DrawRectangle(pen, rect);
            extendedBitmap.Graphics.DrawString(Pages[TabPage], font2, solidBrush1, layoutRectangle, format);
            graphics.DrawImageUnscaled(extendedBitmap.Bitmap, 0, 0);
        }

        int effects_BuffDebuff(Control iLabel, ctlPairedList iList)
        {
            Enums.ShortFX effectMagSum1 = pBase.GetEffectMagSum(Enums.eEffectType.ToHit);
            Enums.ShortFX effectMagSum2 = pEnh.GetEffectMagSum(Enums.eEffectType.ToHit);
            Enums.ShortFX effectMagSum3 = pEnh.GetEffectMagSum(Enums.eEffectType.DamageBuff);
            Enums.ShortFX effectMagSum4 = pBase.GetEffectMagSum(Enums.eEffectType.PerceptionRadius);
            Enums.ShortFX effectMagSum5 = pEnh.GetEffectMagSum(Enums.eEffectType.PerceptionRadius);
            Enums.ShortFX effectMagSum6 = pBase.GetEffectMagSum(Enums.eEffectType.StealthRadius);
            Enums.ShortFX effectMagSum7 = pEnh.GetEffectMagSum(Enums.eEffectType.StealthRadius);
            Enums.ShortFX effectMag1 = pBase.GetEffectMag(Enums.eEffectType.ThreatLevel);
            Enums.ShortFX effectMag2 = pEnh.GetEffectMag(Enums.eEffectType.ThreatLevel);
            Enums.ShortFX effectMag3 = pBase.GetEffectMag(Enums.eEffectType.DropToggles);
            Enums.ShortFX effectMag4 = pEnh.GetEffectMag(Enums.eEffectType.DropToggles);
            Enums.ShortFX effectMag5 = pBase.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Self);
            Enums.ShortFX effectMag6 = pEnh.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Self);
            Enums.ShortFX effectMag7 = pBase.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Target);
            Enums.ShortFX effectMag8 = pEnh.GetEffectMag(Enums.eEffectType.RechargeTime, Enums.eToWho.Target);
            Enums.ShortFX effectMagSum8 = pBase.GetEffectMagSum(Enums.eEffectType.ResEffect);
            Enums.ShortFX effectMagSum9 = pEnh.GetEffectMagSum(Enums.eEffectType.ResEffect);
            Enums.ShortFX effectMagSum10 = pBase.GetEffectMagSum(Enums.eEffectType.Enhancement);
            Enums.ShortFX effectMagSum11 = pEnh.GetEffectMagSum(Enums.eEffectType.Enhancement);
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
                str1 = pBase.Effects[effectMagSum10.Index[0]].ETModifies == Enums.eEffectType.Mez ? Enums.GetMezNameShort((Enums.eMezShort)pBase.Effects[effectMagSum10.Index[0]].MezType) : Enums.GetEffectNameShort(pBase.Effects[effectMagSum10.Index[0]].ETModifies);
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
                    iList.AddItem(FastItem("ToHit", effectMagSum1, effectMagSum2, "%", false, false, pBase.Effects[effectMagSum1.Index[0]].SpecialCase == Enums.eSpecialCase.Combo, false, effectMagSum1));
                if (sFXCheck(effectMagSum1))
                    iList.SetUnique();
                Enums.ShortFX[] shortFxArray = Power.SplitFX(ref effectMagSum3, ref pEnh);
                int num2 = shortFxArray.Length - 1;
                for (int index1 = 0; index1 <= num2; ++index1)
                {
                    if (shortFxArray[index1].Present)
                    {
                        bool flag = true;
                        int num3 = shortFxArray[index1].Index.Length - 1;
                        for (int index2 = 0; index2 <= num3; ++index2)
                        {
                            if (pEnh.Effects[shortFxArray[index1].Index[index2]].SpecialCase != Enums.eSpecialCase.Defiance)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                            iList.AddItem(new ctlPairedList.ItemPair("Defiance:", Utilities.FixDP(shortFxArray[index1].Value[0]) + "%", false, false, false, pEnh.Effects[shortFxArray[index1].Index[0]].BuildEffectString(false, "Damage Buff (Defiance)")));
                        else
                            iList.AddItem(new ctlPairedList.ItemPair("DmgBuff:", Utilities.FixDP(shortFxArray[index1].Value[0]) + "%", false, pEnh.Effects[shortFxArray[index1].Index[0]].SpecialCase == Enums.eSpecialCase.Combo, false, Power.SplitFXGroupTip(ref shortFxArray[index1], ref pEnh, false)));
                        if (pEnh.Effects[shortFxArray[index1].Index[0]].isEnhancementEffect)
                            iList.SetUnique();
                    }
                }
                if (effectMagSum4.Present)
                    iList.AddItem(FastItem("Percept", effectMagSum4, effectMagSum5, "%", effectMagSum4));
                if (sFXCheck(effectMagSum4))
                    iList.SetUnique();
                if (effectMagSum6.Present)
                    iList.AddItem(new ctlPairedList.ItemPair("Stealth", Conversions.ToString(effectMagSum6.Sum) + "ft", false, false, false, pEnh.Effects[effectMagSum7.Index[0]].BuildEffectString(false, "Stealth Radius")));
                if (sFXCheck(effectMagSum6))
                    iList.SetUnique();
                if (effectMag1.Present)
                    iList.AddItem(FastItem("ThretLvl", effectMag1, effectMag2, "%", effectMag1));
                if (sFXCheck(effectMag1))
                    iList.SetUnique();
                if (effectMag3.Present)
                    iList.AddItem(FastItem("TogDrop", effectMag3, effectMag4, "%", false, false, pBase.Effects[effectMag3.Index[0]].Probability < 1.0, false, effectMag3));
                if (sFXCheck(effectMag3))
                    iList.SetUnique();
                if (effectMag7.Present)
                    iList.AddItem(FastItem("Rchrg (Tgt)", effectMag7, effectMag8, "%", effectMag7));
                if (sFXCheck(effectMag7))
                    iList.SetUnique();
                if (effectMag5.Present)
                    iList.AddItem(FastItem("Rchrg (Self)", effectMag5, effectMag6, "%", effectMag5));
                if (sFXCheck(effectMag5))
                    iList.SetUnique();
                if (effectMagSum8.Present)
                {
                    if (!effectMagSum8.Multiple)
                    {
                        if (effectMagSum8.Present)
                            iList.AddItem(FastItem("Res(" + Enums.GetEffectNameShort(pBase.Effects[effectMagSum8.Index[0]].ETModifies) + ")", effectMagSum8, effectMagSum9, "%", effectMagSum8));
                        if (sFXCheck(effectMagSum8))
                            iList.SetUnique();
                    }
                    else
                    {
                        iList.AddItem(new ctlPairedList.ItemPair("Res(Multi):", Conversions.ToString(effectMagSum8.Value[0]) + "%", false, false, false, effectMagSum8));
                        if (sFXCheck(effectMagSum8))
                            iList.SetUnique();
                    }
                }
                if (effectMagSum10.Present & str1 != string.Empty)
                {
                    string str2 = !string.Equals(str1, "EnduranceDiscount", StringComparison.OrdinalIgnoreCase) ? (!string.Equals(str1, "RechargeTime", StringComparison.OrdinalIgnoreCase) ? (!IsMezEffect(str1) ? CapString(str1, 7) : "Effects") : "RechRdx") : "EndRdx";
                    if (effectMagSum10.Multiple)
                    {
                        if (effectMagSum10.Index.Length < 5)
                        {
                            int num3 = effectMagSum10.Index.Length - 1;
                            for (int index = 0; index <= num3; ++index)
                            {
                                string str3 = pBase.Effects[effectMagSum10.Index[index]].ETModifies == Enums.eEffectType.Mez ? Enums.GetMezNameShort((Enums.eMezShort)pBase.Effects[effectMagSum10.Index[index]].MezType) : Enums.GetEffectNameShort(pBase.Effects[effectMagSum10.Index[index]].ETModifies);
                                string str4 = !string.Equals(str3, "EnduranceDiscount", StringComparison.OrdinalIgnoreCase) ? (!string.Equals(str3, "RechargeTime", StringComparison.OrdinalIgnoreCase) ? CapString(str3, 7) : "RechRdx") : "EndRdx";
                                string str5 = string.Empty;
                                if (pEnh.Effects[effectMagSum10.Index[index]].ToWho == Enums.eToWho.Target)
                                    str5 = " (Tgt)";
                                if (pEnh.Effects[effectMagSum10.Index[index]].ToWho == Enums.eToWho.Self)
                                    str5 = " (Self)";
                                if (str4.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) <= -1)
                                {
                                    iList.AddItem(new ctlPairedList.ItemPair("+" + str4 + ":", Conversions.ToString(effectMagSum10.Value[index]) + "%" + str5, false, false, false, pEnh.Effects[effectMagSum10.Index[index]].BuildEffectString()));
                                    if (pEnh.Effects[effectMagSum10.Index[index]].isEnhancementEffect)
                                        iList.SetUnique();
                                }
                            }
                        }
                        else
                        {
                            const string str3 = "Multiple";
                            int iIndex = 0;
                            int num3 = -1;
                            while (iIndex < effectMagSum10.Index.Length)
                            {
                                if (string.Equals(pEnh.Effects[effectMagSum10.Index[iIndex]].Special, "RechargeTime", StringComparison.OrdinalIgnoreCase))
                                {
                                    string str4 = string.Empty;
                                    if (pEnh.Effects[effectMagSum10.Index[iIndex]].ToWho == Enums.eToWho.Target)
                                        str4 = " (Tgt)";
                                    if (pEnh.Effects[effectMagSum10.Index[iIndex]].ToWho == Enums.eToWho.Self)
                                        str4 = " (Self)";
                                    iList.AddItem(new ctlPairedList.ItemPair("+RechRdx:", Conversions.ToString(effectMagSum10.Value[iIndex]) + "%" + str4, false, false, false, pEnh.Effects[effectMagSum10.Index[iIndex]].BuildEffectString()));
                                    if (pEnh.Effects[effectMagSum10.Index[iIndex]].isEnhancementEffect)
                                        iList.SetUnique();
                                    effectMagSum10.Remove(iIndex);
                                }
                                else
                                {
                                    if (num3 == -1)
                                        num3 = (int)Math.Round(effectMagSum10.Value[0]);
                                    else if (num3 > 0 & num3 != (double)effectMagSum10.Value[iIndex])
                                        num3 = -2;
                                    ++iIndex;
                                }
                            }
                            if (effectMagSum10.Present)
                            {
                                string iValue = "Varies";
                                if (num3 > 0)
                                    iValue = num3 + "%";
                                if (effectMagSum10.Multiple)
                                {
                                    iList.AddItem(new ctlPairedList.ItemPair("+" + str3 + ":", iValue, false, false, false, effectMagSum10));
                                }
                                else
                                {
                                    string str4 = CapString(pBase.Effects[effectMagSum10.Index[0]].Special, 7);
                                    if (str4.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) < 0)
                                    {
                                        iList.AddItem(new ctlPairedList.ItemPair("+" + str4 + ":", iValue, false, false, false, effectMagSum10));
                                        if (sFXCheck(effectMagSum10))
                                            iList.SetUnique();
                                    }
                                }
                            }
                        }
                    }
                    else if (str2.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        iList.AddItem(new ctlPairedList.ItemPair("+" + str2 + ":", Conversions.ToString(effectMagSum10.Value[0]) + "%", false, false, false, effectMagSum10));
                        if (sFXCheck(effectMagSum10))
                            iList.SetUnique();
                    }
                }
                num1 = 1;
            }
            return num1;
        }

        int effects_Elusivity(Control iLabel, ctlPairedList iList)
        {
            bool flag = iList.ItemCount == 0;
            const int num1 = 0;
            int num2 = pBase.Effects.Length - 1;
            for (int idEffect = 0; idEffect <= num2; ++idEffect)
            {
                if (pBase.Effects[idEffect].EffectType == Enums.eEffectType.Elusivity & pBase.Effects[idEffect].Probability > 0.0)
                {
                    string empty = string.Empty;
                    int[] returnMask = new int[Enum.GetValues(pBase.Effects[idEffect].DamageType.GetType()).Length + 1];
                    pBase.GetEffectStringGrouped(idEffect, ref empty, ref returnMask, false, true, true);
                    string iTip = empty;
                    float num3 = pBase.Effects[idEffect].MagPercent;
                    if ((pBase.Effects[idEffect].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        num3 = 0.0f;
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("Elusivity:", Strings.Format(num3, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "%", false, pBase.Effects[idEffect].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    const int num4 = num1 + 1;
                    if (flag)
                        iLabel.Text = "Elusivity (PvP)";
                    return num4;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "Elusivity (PvP)";
            return num1;
        }

        int effects_GrantPower(Control iLabel, ctlPairedList iList)
        {
            bool flag = iList.ItemCount == 0;
            int num1 = 0;
            int num2 = pBase.Effects.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (pBase.Effects[index].EffectType == Enums.eEffectType.GrantPower & pBase.Effects[index].Probability > 0.0 & pBase.Effects[index].EffectClass != Enums.eEffectClass.Ignored)
                {
                    string iValue = "[Power]";
                    if (pEnh.Effects[index].nSummon > -1)
                    {
                        iValue = DatabaseAPI.Database.Power[pEnh.Effects[index].nSummon].DisplayName;
                    }
                    else
                    {
                        int startIndex = pEnh.Effects[index].Summon.LastIndexOf(".", StringComparison.Ordinal) + 1;
                        if (startIndex < pEnh.Effects[index].Summon.Length)
                            iValue = pEnh.Effects[index].Summon.Substring(startIndex);
                    }
                    string iTip = pEnh.Effects[index].BuildEffectString();
                    if ((pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        iValue = "(suppressed)";
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("GrantPwr:", iValue, false, pBase.Effects[index].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    if (pBase.Effects[index].isEnhancementEffect)
                        iList.SetUnique();
                    ++num1;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "GrantPower Effects";
            return num1;
        }

        int effects_Heal(Control iLabel, ctlPairedList iList)
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
            BaseSFX1.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Heal));
            EnhSFX1.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Heal));
            BaseSFX2.Assign(pBase.GetEffectMagSum(Enums.eEffectType.HitPoints));
            EnhSFX2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.HitPoints));
            BaseSFX3.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Absorb));
            EnhSFX3.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Absorb));
            BaseSFX5.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, false, true));
            EnhSFX5.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, false, true));
            BaseSFX4.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, true, false, true));
            EnhSFX4.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, true, false, true));
            BaseSFX6.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Recovery, true, true));
            EnhSFX6.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Recovery, true, true));
            BaseSFX7.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Recovery, true, false, true));
            EnhSFX7.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Recovery, true, false, true));
            BaseSFX8.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Endurance, true, true));
            EnhSFX8.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, true, true));
            BaseSFX9.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Endurance, true, false, true));
            EnhSFX9.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, true, false, true));
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
            int num1 = pBase.Effects.Length - 1;
            for (int iIndex = 0; iIndex <= num1; ++iIndex)
            {
                if (pBase.Effects[iIndex].EffectType == Enums.eEffectType.Damage & pBase.Effects[iIndex].DamageType == Enums.eDamage.Special & pBase.Effects[iIndex].ToWho == Enums.eToWho.Self & pBase.Effects[iIndex].Probability > 0.0 & (pBase.Effects[iIndex].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                    shortFx.Add(iIndex, pBase.Effects[iIndex].Mag);
            }
            iList.ValueWidth = 55;
            int num2;
            if (!(shortFx.Present | BaseSFX1.Present | BaseSFX2.Present | BaseSFX5.Present | BaseSFX4.Present | BaseSFX6.Present | BaseSFX7.Present | BaseSFX8.Present | BaseSFX9.Present))
            {
                num2 = 0;
            }
            else
            {
                bool flag1 = pBase.AffectsTarget(Enums.eEffectType.Heal) | pBase.AffectsTarget(Enums.eEffectType.HitPoints) | pBase.AffectsTarget(Enums.eEffectType.Regeneration) | pBase.AffectsTarget(Enums.eEffectType.Recovery) | pBase.AffectsTarget(Enums.eEffectType.Endurance) | pBase.AffectsTarget(Enums.eEffectType.Absorb);
                bool flag2 = pBase.AffectsSelf(Enums.eEffectType.Heal) | pBase.AffectsSelf(Enums.eEffectType.HitPoints) | pBase.AffectsSelf(Enums.eEffectType.Regeneration) | pBase.AffectsSelf(Enums.eEffectType.Recovery) | pBase.AffectsSelf(Enums.eEffectType.Endurance) | pBase.AffectsSelf(Enums.eEffectType.Absorb);
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
                        if (pBase.Effects[shortFx.Index[index]].Aspect == Enums.eAspect.Cur)
                        {
                            if (shortFx.Value[index] == -1.0)
                                shortFx.Value[index] = 0.0f;
                            if (shortFx.Value[index] != 100.0)
                                shortFx.Value[index] *= 100f;
                        }
                    }
                    shortFx.ReSum();
                    iList.AddItem(FastItem("Damage", shortFx, shortFx, " (Self)", shortFx));
                }
                SplitFX_AddToList(ref BaseSFX1, ref EnhSFX1, ref iList);
                SplitFX_AddToList(ref BaseSFX2, ref EnhSFX2, ref iList);
                SplitFX_AddToList(ref BaseSFX3, ref EnhSFX3, ref iList);
                SplitFX_AddToList(ref BaseSFX5, ref EnhSFX5, ref iList, "Regen(S)");
                SplitFX_AddToList(ref BaseSFX4, ref EnhSFX4, ref iList, "Regen(T)");
                SplitFX_AddToList(ref BaseSFX6, ref EnhSFX6, ref iList, "Recvry(S)");
                SplitFX_AddToList(ref BaseSFX7, ref EnhSFX7, ref iList, "Recvry(T)");
                SplitFX_AddToList(ref BaseSFX9, ref EnhSFX9, ref iList, "End (Tgt)");
                SplitFX_AddToList(ref BaseSFX8, ref EnhSFX8, ref iList, "End (Self)");
                num2 = iList.ItemCount;
            }
            return num2;
        }

        int effects_ModifyEffect(Control iLabel, ctlPairedList iList)
        {
            bool flag = iList.ItemCount == 0;
            int num1 = 0;
            int num2 = pBase.Effects.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (pBase.Effects[index].EffectType == Enums.eEffectType.GlobalChanceMod & pBase.Effects[index].Probability > 0.0)
                {
                    string iTip = string.Empty + pEnh.Effects[index].BuildEffectString();
                    string iValue = Conversions.ToString(pBase.Effects[index].MagPercent) + "%";
                    if ((pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        iValue = "(suppressed)";
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(pBase.Effects[index].Reward + ":", iValue, false, pBase.Effects[index].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    ++num1;
                }
            }
            if (num1 > 0 && flag)
                iLabel.Text = "Modify Effect";
            return num1;
        }

        int effects_Movement(Control iLabel, ctlPairedList iList)
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
            shortFx2.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying));
            s2_1.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.SpeedFlying));
            shortFx1.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Fly));
            shortFx3.Assign(pBase.GetEffectMagSum(Enums.eEffectType.JumpHeight));
            s2_2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.JumpHeight));
            shortFx4.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedJumping));
            s2_3.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.SpeedJumping));
            shortFx5.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedRunning));
            s2_4.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.SpeedRunning));
            shortFx6.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Enhancement));
            shortFx8.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, false, false, true));
            shortFx9.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedJumping, false, false, false, true));
            shortFx10.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedRunning, false, false, false, true));
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
                    if (pBase.Effects[shortFx6.Index[index]].Special.IndexOf("Jump", StringComparison.OrdinalIgnoreCase) > -1)
                        shortFx7.Add(shortFx6.Index[index], pBase.Effects[shortFx6.Index[index]].Mag);
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
                bool flag = shortFx2.Present & pBase.AffectsTarget(Enums.eEffectType.SpeedFlying) | shortFx3.Present & pBase.AffectsTarget(Enums.eEffectType.JumpHeight) | shortFx4.Present & pBase.AffectsTarget(Enums.eEffectType.SpeedJumping) | shortFx5.Present & pBase.AffectsTarget(Enums.eEffectType.SpeedRunning);
                if (iList.ItemCount == 0)
                {
                    if (flag)
                        iLabel.Text = "Movement (Target)";
                    else
                        iLabel.Text = "Movement (Self)";
                }
                if (shortFx1.Present)
                    iList.AddItem(FastItem("Fly", shortFx1, shortFx1, string.Empty, shortFx1));
                if (sFXCheck(shortFx1))
                    iList.SetUnique();
                if (shortFx2.Present)
                    iList.AddItem(FastItem("FlySpd", shortFx2, s2_1, "%", shortFx2));
                if (sFXCheck(shortFx2))
                    iList.SetUnique();
                if (shortFx3.Present)
                    iList.AddItem(FastItem("JmpHeight", shortFx3, s2_2, "%", shortFx3));
                if (sFXCheck(shortFx3))
                    iList.SetUnique();
                if (shortFx4.Present)
                    iList.AddItem(FastItem("JmpSpd", shortFx4, s2_3, "%", shortFx4));
                if (sFXCheck(shortFx4))
                    iList.SetUnique();
                if (shortFx7.Present)
                    iList.AddItem(FastItem("+JmpHeight", shortFx7, shortFx7, "%", shortFx7));
                if (sFXCheck(shortFx7))
                    iList.SetUnique();
                if (shortFx5.Present)
                    iList.AddItem(FastItem("RunSpd", shortFx5, s2_4, "%", shortFx5));
                if (sFXCheck(shortFx5))
                    iList.SetUnique();
                if (shortFx10.Present)
                    iList.AddItem(FastItem("MaxRun", shortFx10, shortFx10, string.Empty, shortFx10));
                if (shortFx9.Present)
                    iList.AddItem(FastItem("MaxJmp", shortFx9, shortFx9, string.Empty, shortFx9));
                if (shortFx8.Present)
                    iList.AddItem(FastItem("MaxFly", shortFx8, shortFx8, string.Empty, shortFx8));
                num1 = 1;
            }
            return num1;
        }

        int effects_Status(Control iLabel, ctlPairedList iList)
        {
            const Enums.eMezShort eMezShort = Enums.eMezShort.None;
            Enums.ShortFX shortFx1 = new Enums.ShortFX();
            Enums.ShortFX shortFx2 = new Enums.ShortFX();
            Enums.ShortFX shortFx3 = new Enums.ShortFX();
            Enums.ShortFX shortFx4 = new Enums.ShortFX();
            int num1 = 0;
            shortFx1.Assign(pBase.GetEffectMag(Enums.eEffectType.MezResist));
            shortFx2.Assign(pEnh.GetEffectMag(Enums.eEffectType.MezResist));
            shortFx3.Assign(pBase.GetEffectMag(Enums.eEffectType.Mez, Enums.eToWho.Unspecified, true));
            shortFx4.Assign(pEnh.GetEffectMag(Enums.eEffectType.Mez, Enums.eToWho.Unspecified, true));
            shortFx1.Multiply();
            shortFx2.Multiply();
            iList.ValueWidth = 60;
            if (shortFx1.Present | shortFx3.Present)
            {
                if (pBase.AffectsTarget(Enums.eEffectType.MezResist) | pBase.AffectsTarget(Enums.eEffectType.Mez))
                    iLabel.Text = "Status Effects (Target)";
                else
                    iLabel.Text = "Status Effects (Self)";
            }
            string[] names = Enum.GetNames(eMezShort.GetType());
            if (shortFx3.Present)
            {
                int num2 = pBase.Effects.Length - 1;
                for (int iTagID = 0; iTagID <= num2; ++iTagID)
                {
                    if (pBase.Effects[iTagID].EffectType == Enums.eEffectType.Mez & pBase.Effects[iTagID].Probability > 0.0 & pBase.Effects[iTagID].CanInclude() && pEnh.Effects[iTagID].PvXInclude())
                    {
                        const bool iAlternate1 = false;
                        string str = !(pEnh.Effects[iTagID].Duration < 2.0 | pBase.PowerType == Enums.ePowerType.Auto_) ? " - " + Strings.Format(pEnh.Effects[iTagID].Duration, "#0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "s" : string.Empty;
                        if (pBase.Effects[iTagID].Mag > 0.0)
                        {
                            bool iAlternate2 = pBase.Effects[iTagID].Duration != (double)pEnh.Effects[iTagID].Duration | !Enums.MezDurationEnhancable(pBase.Effects[iTagID].MezType) & pEnh.Effects[iTagID].Mag != (double)pBase.Effects[iTagID].Mag;
                            string iValue = "Mag " + Utilities.FixDP(pEnh.Effects[iTagID].Mag) + str;
                            if ((pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                                iValue = "0";
                            ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(CapString(names[(int)pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate2, pBase.Effects[iTagID].Probability < 1.0 | pBase.Effects[iTagID].SpecialCase == Enums.eSpecialCase.Combo, pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
                            iList.AddItem(iItem);
                            if (pBase.Effects[iTagID].isEnhancementEffect)
                                iList.SetUnique();
                        }
                        else if (pBase.Effects[iTagID].MezType == Enums.eMez.ToggleDrop & pBase.Effects[iTagID].Probability > 0.0)
                        {
                            string iValue = Conversions.ToString(pBase.Effects[iTagID].Probability * 100f) + "%";
                            if ((pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                                iValue = "0%";
                            ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(CapString(names[(int)pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate1, pBase.Effects[iTagID].Probability < 1.0 | pBase.Effects[iTagID].SpecialCase == Enums.eSpecialCase.Combo, pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
                            iList.AddItem(iItem);
                            if (pBase.Effects[iTagID].isEnhancementEffect)
                                iList.SetUnique();
                        }
                        else
                        {
                            bool iAlternate2 = pBase.Effects[iTagID].Duration != (double)pEnh.Effects[iTagID].Duration | !Enums.MezDurationEnhancable(pBase.Effects[iTagID].MezType) & pEnh.Effects[iTagID].Mag != (double)pBase.Effects[iTagID].Mag;
                            string iValue = "Mag " + Utilities.FixDP(pEnh.Effects[iTagID].Mag) + str;
                            if ((pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                                iValue = "0";
                            ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(CapString(names[(int)pBase.Effects[iTagID].MezType], 7) + ":", iValue, iAlternate2, pBase.Effects[iTagID].Probability < 1.0, pBase.Effects[iTagID].SpecialCase != Enums.eSpecialCase.None, iTagID);
                            iList.AddItem(iItem);
                            if (pBase.Effects[iTagID].isEnhancementEffect)
                                iList.SetUnique();
                        }
                        ++num1;
                    }
                }
            }
            if (shortFx1.Present)
            {
                int num2 = pBase.Effects.Length - 1;
                for (int iTagID = 0; iTagID <= num2; ++iTagID)
                {
                    if (pBase.Effects[iTagID].PvMode != Enums.ePvX.PvP & !MidsContext.Config.Inc.DisablePvE | pBase.Effects[iTagID].PvMode != Enums.ePvX.PvE & MidsContext.Config.Inc.DisablePvE && pBase.Effects[iTagID].EffectType == Enums.eEffectType.MezResist & pBase.Effects[iTagID].Probability > 0.0)
                    {
                        string str = (double)pEnh.Effects[iTagID].Duration >= 15.0 ? " - " + Utilities.FixDP(pEnh.Effects[iTagID].Duration) + "s" : string.Empty;
                        string iValue = Conversions.ToString(pBase.Effects[iTagID].MagPercent) + "%" + str;
                        if ((pBase.Effects[iTagID].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                            iValue = "0%";
                        ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair(CapString("-" + names[(int)pBase.Effects[iTagID].MezType], 7) + ":", iValue, false, false, false, iTagID);
                        iList.AddItem(iItem);
                        if (pBase.Effects[iTagID].isEnhancementEffect)
                            iList.SetUnique();
                        ++num1;
                    }
                }
            }
            return num1;
        }

        int effects_Summon(Control iLabel, ctlPairedList iList)
        {
            int num1 = 0;
            bool flag = iList.ItemCount == 0;
            int num2 = pBase.Effects.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (pBase.Effects[index].EffectType == Enums.eEffectType.EntCreate & pBase.Effects[index].Probability > 0.0)
                {
                    string iValue = pEnh.Effects[index].nSummon <= -1 ? pEnh.Effects[index].Summon : DatabaseAPI.Database.Entities[pEnh.Effects[index].nSummon].DisplayName;
                    if (iValue.StartsWith("MastermindPets_"))
                        iValue = iValue.Replace("MastermindPets_", string.Empty);
                    if (iValue.StartsWith("Pets_"))
                        iValue = iValue.Replace("Pets_", string.Empty);
                    if (iValue.StartsWith("Villain_Pets_"))
                        iValue = iValue.Replace("Villain_Pets_", string.Empty);
                    string iTip = pEnh.Effects[index].BuildEffectString();
                    if ((pBase.Effects[index].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        iValue = "(suppressed)";
                    ctlPairedList.ItemPair iItem = new ctlPairedList.ItemPair("Summon:", iValue, false, pBase.Effects[index].Probability < 1.0, false, iTip);
                    iList.AddItem(iItem);
                    if (pBase.Effects[index].isEnhancementEffect)
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
            Enums.ShortFX effectMagSum = pEnh.GetEffectMagSum(Enums.eEffectType.Defense, true);
            if (effectMagSum.Value == null)
                return;
            const Enums.eDamage eDamage = Enums.eDamage.None;
            effectMagSum.Multiply();
            bool flag1 = false;
            bool flag2 = false;
            int num1 = effectMagSum.Value.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if (effectMagSum.Value[index] > 0.0)
                    flag1 = true;
                if (effectMagSum.Value[index] < 0.0)
                    flag2 = true;
            }
            int buffDebuff = !(flag1 & flag2) ? (!flag1 ? (!flag2 ? 0 : -1) : 1) : 1;
            float[] def1 = pBase.GetDef(buffDebuff);
            float[] def2 = pEnh.GetDef(buffDebuff);
            string[] names = Enum.GetNames(eDamage.GetType());
            if (pBase.AffectsTarget(Enums.eEffectType.Defense))
                fx_lblHead1.Text = "Defence (Target)";
            else
                fx_lblHead1.Text = "Defence (Self)";
            fx_List1.ValueWidth = 55;
            int num2 = def1.Length - 1;
            for (int index = 0; index <= num2; ++index)
                def1[index] *= 100f;
            int num3 = def2.Length - 1;
            for (int index = 0; index <= num3; ++index)
                def2[index] *= 100f;
            bool multiple = effectMagSum.Multiple;
            const Enums.eDamage iSub1 = Enums.eDamage.Smashing;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub1, true));
            fx_List1.AddItem(FastItem(names[(int)iSub1], def1[(int)iSub1], def2[(int)iSub1], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub2 = Enums.eDamage.Fire;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub2, true));
            fx_List1.AddItem(FastItem(names[(int)iSub2], def1[(int)iSub2], def2[(int)iSub2], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub3 = Enums.eDamage.Lethal;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub3, true));
            fx_List1.AddItem(FastItem(names[(int)iSub3], def1[(int)iSub3], def2[(int)iSub3], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub4 = Enums.eDamage.Cold;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub4, true));
            fx_List1.AddItem(FastItem(names[(int)iSub4], def1[(int)iSub4], def2[(int)iSub4], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub5 = Enums.eDamage.Energy;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub5, true));
            fx_List1.AddItem(FastItem(names[(int)iSub5], def1[(int)iSub5], def2[(int)iSub5], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub6 = Enums.eDamage.Melee;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub6, true));
            fx_List1.AddItem(FastItem(names[(int)iSub6], def1[(int)iSub6], def2[(int)iSub6], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub7 = Enums.eDamage.Negative;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub7, true));
            fx_List1.AddItem(FastItem(names[(int)iSub7], def1[(int)iSub7], def2[(int)iSub7], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub8 = Enums.eDamage.Ranged;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub8, true));
            fx_List1.AddItem(FastItem(names[(int)iSub8], def1[(int)iSub8], def2[(int)iSub8], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub9 = Enums.eDamage.Psionic;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub9, true));
            fx_List1.AddItem(FastItem(names[(int)iSub9], def1[(int)iSub9], def2[(int)iSub9], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
            const Enums.eDamage iSub10 = Enums.eDamage.AoE;
            if (multiple)
                effectMagSum.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Defense, iSub10, true));
            fx_List1.AddItem(FastItem(names[(int)iSub10], def1[(int)iSub10], def2[(int)iSub10], "%", false, true, false, false, effectMagSum));
            if (sFXCheck(effectMagSum))
                fx_List1.SetUnique();
        }

        int EffectsDrh()
        {
            int index = 0;
            if (pBase.HasDefEffects())
            {
                EffectsDef();
                ++index;
            }
            if (pBase.HasResEffects())
            {
                EffectsRes(index);
                ++index;
            }
            return index;
        }

        void EffectsRes(int index)
        {
            const Enums.eDamage eDamage = Enums.eDamage.None;
            float[] res1 = pBase.GetRes(!MidsContext.Config.Inc.DisablePvE);
            float[] res2 = pEnh.GetRes(!MidsContext.Config.Inc.DisablePvE);
            string[] names = Enum.GetNames(eDamage.GetType());
            Label label;
            ctlPairedList ctlPairedList;
            if (index == 0)
            {
                label = fx_lblHead1;
                ctlPairedList = fx_List1;
            }
            else
            {
                label = fx_lblHead2;
                ctlPairedList = fx_List2;
            }
            if (pBase.AffectsTarget(Enums.eEffectType.Resistance))
                label.Text = "Resistance (Target)";
            else
                label.Text = "Resistance (Self)";
            fx_List2.ValueWidth = 55;
            Enums.ShortFX shortFx = new Enums.ShortFX();
            shortFx.Multiply();
            int num1 = res1.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
                res1[index1] *= 100f;
            int num2 = res2.Length - 1;
            for (int index1 = 0; index1 <= num2; ++index1)
                res2[index1] *= 100f;
            const Enums.eDamage iSub1 = Enums.eDamage.Smashing;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub1, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub1], res1[(int)iSub1], res2[(int)iSub1], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub2 = Enums.eDamage.Fire;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub2, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub2], res1[(int)iSub2], res2[(int)iSub2], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub3 = Enums.eDamage.Lethal;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub3, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub3], res1[(int)iSub3], res2[(int)iSub3], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub4 = Enums.eDamage.Cold;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub4, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub4], res1[(int)iSub4], res2[(int)iSub4], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub5 = Enums.eDamage.Energy;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub5, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub5], res1[(int)iSub5], res2[(int)iSub5], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub6 = Enums.eDamage.Psionic;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub6, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub6], res1[(int)iSub6], res2[(int)iSub6], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub7 = Enums.eDamage.Negative;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub7, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub7], res1[(int)iSub7], res2[(int)iSub7], "%", false, true, false, false, shortFx));
            if (sFXCheck(shortFx))
                ctlPairedList.SetUnique();
            const Enums.eDamage iSub8 = Enums.eDamage.Toxic;
            shortFx.Assign(pEnh.GetDamageMagSum(Enums.eEffectType.Resistance, iSub8, true));
            ctlPairedList.AddItem(FastItem(names[(int)iSub8], res1[(int)iSub8], res2[(int)iSub8], "%", false, true, false, false, shortFx));
        }

        static ctlPairedList.ItemPair FastItem(
          string Title,
          float s1,
          float s2,
          string Suffix)
        {
            return FastItem(Title, s1, s2, Suffix, false, false, false, false, -1, -1);
        }

        static ctlPairedList.ItemPair FastItem(
          string Title,
          Enums.ShortFX s1,
          Enums.ShortFX s2,
          string Suffix,
          Enums.ShortFX Tag)
        {
            return FastItem(Title, s1, s2, Suffix, false, false, false, false, Tag);
        }

        static ctlPairedList.ItemPair FastItem(
          string Title,
          float s1,
          float s2,
          string Suffix,
          string Tip)
        {
            return FastItem(Title, s1, s2, Suffix, false, false, false, false, Tip);
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
            if (s1.Sum == 0.0 & !AlwaysShow)
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false);
            else if (s1.Sum == 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false);
            }
            else
            {
                bool iAlternate;
                if (s1.Sum != (double)s2.Sum)
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
            if (s1 == 0.0 & !AlwaysShow)
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false);
            else if (s1 == 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false);
            }
            else
            {
                bool iAlternate;
                if (s1 != (double)s2)
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
            if (s1 == 0.0 & !AlwaysShow)
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false);
            else if (s1 == 0.0)
            {
                itemPair = new ctlPairedList.ItemPair(Title + ":", string.Empty, false);
            }
            else
            {
                bool iAlternate;
                if (s1 != (double)s2)
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
            if (s1 == 0.0 & !AlwaysShow)
            {
                itemPair = new ctlPairedList.ItemPair(string.Empty, string.Empty, false);
            }
            else
            {
                bool iAlternate;
                if (s1 != (double)s2)
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
            SolidBrush solidBrush1 = new SolidBrush(enhListing.BackColor);
            if (pBase == null)
                return;
            SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            if (PowerID == pBase.PowerIndex)
            {
                ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MidsContext.Character.IsHero());
                Rectangle rectangle1 = new Rectangle();
                ref Rectangle local1 = ref rectangle1;
                Size size = bxFlip.Size;
                int x = size.Width - 188 + 30 * Index;
                size = bxFlip.Size;
                int y1 = (int)Math.Round((size.Height / 2.0 - 30.0) / 2.0);
                local1 = new Rectangle(x, y1, 30, 30);
                Rectangle destRect = rectangle1;
                bxFlip.Graphics.FillRectangle(solidBrush1, rectangle1);
                Rectangle rectangle2 = new Rectangle((int)Math.Round(rectangle1.X + (30.0 - 30.0 * State) / 2.0), rectangle1.Y, (int)Math.Round(30.0 * State), 30);
                Graphics graphics;
                if (Enh1 > -1)
                {
                    graphics = bxFlip.Graphics;
                    I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle1, State, DatabaseAPI.Database.Enhancements[Enh1].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[Enh1].TypeID, Grade1));
                }
                else
                    bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                pnlEnhActive.CreateGraphics().DrawImage(bxFlip.Bitmap, destRect, rectangle1, GraphicsUnit.Pixel);
                ref Rectangle local2 = ref rectangle1;
                double y2 = rectangle1.Y;
                size = bxFlip.Size;
                double num1 = size.Height / 2.0;
                int num2 = (int)Math.Round(y2 + num1);
                local2.Y = num2;
                bxFlip.Graphics.FillRectangle(solidBrush1, rectangle1);
                rectangle2 = new Rectangle((int)Math.Round(rectangle1.X + (30.0 - 30.0 * State) / 2.0), rectangle1.Y, (int)Math.Round(30.0 * State), 30);
                if (Enh2 > -1)
                {
                    graphics = bxFlip.Graphics;
                    I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle1, State, DatabaseAPI.Database.Enhancements[Enh2].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[Enh2].TypeID, Grade2));
                }
                else
                    bxFlip.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                rectangle2.Inflate(2, 2);
                bxFlip.Graphics.FillEllipse(solidBrush2, rectangle2);
                pnlEnhInactive.CreateGraphics().DrawImage(bxFlip.Bitmap, destRect, rectangle1, GraphicsUnit.Pixel);
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

        ctlPairedList.ItemPair GetRankedEffect(IReadOnlyList<int> Index, int ID)
        {
            string Title = string.Empty;
            Enums.ShortFX shortFx = new Enums.ShortFX();
            Enums.ShortFX s2 = new Enums.ShortFX();
            Enums.ShortFX Tag = new Enums.ShortFX();
            string Suffix = string.Empty;
            if (Index[ID] > -1)
            {
                const Enums.eEffectTypeShort eEffectTypeShort = Enums.eEffectTypeShort.None;
                bool flag = false;
                bool onlySelf = pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self;
                bool onlyTarget = pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target;
                if (ID > 0)
                    flag = pBase.Effects[Index[ID]].EffectType == pBase.Effects[Index[ID - 1]].EffectType & (pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self & pBase.Effects[Index[ID - 1]].ToWho == Enums.eToWho.Self) & pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target;
                if (pBase.Effects[Index[ID]].DelayedTime > 5.0)
                    flag = true;
                string[] names = Enum.GetNames(eEffectTypeShort.GetType());
                Title = pBase.Effects[Index[ID]].EffectType != Enums.eEffectType.Enhancement ? (pBase.Effects[Index[ID]].EffectType != Enums.eEffectType.Mez ? names[(int)pBase.Effects[Index[ID]].EffectType] : Enums.GetMezName((Enums.eMezShort)pBase.Effects[Index[ID]].MezType)) : (pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.EnduranceDiscount ? (pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.RechargeTime ? (pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Mez ? (pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Mez ? (pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Defense ? (pBase.Effects[Index[ID]].ETModifies != Enums.eEffectType.Resistance ? CapString(Enum.GetName(pBase.Effects[Index[ID]].ETModifies.GetType(), pBase.Effects[Index[ID]].ETModifies), 7) : "Enh(Res)") : "Enh(Def)") : "Enh(" + Enum.GetName(Enums.eMezShort.None.GetType(), pBase.Effects[Index[ID]].MezType) + ")") : "+Effects") : "+Rechg") : "+EndRdx");
                if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.HitPoints)
                {
                    shortFx.Assign(pBase.GetEffectMagSum(Enums.eEffectType.HitPoints, false, onlySelf, onlyTarget));
                    s2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.HitPoints, false, onlySelf, onlyTarget));
                    Tag.Assign(shortFx);
                    shortFx.Sum = (float)(shortFx.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    s2.Sum = (float)(s2.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    Suffix = "%";
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Heal)
                {
                    shortFx.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Heal, false, onlySelf, onlyTarget));
                    s2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Heal, false, onlySelf, onlyTarget));
                    Tag.Assign(shortFx);
                    shortFx.Sum = (float)(shortFx.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    s2.Sum = (float)(s2.Sum / (double)MidsContext.Archetype.Hitpoints * 100.0);
                    Suffix = "%";
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Absorb)
                {
                    shortFx.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Absorb, false, onlySelf, onlyTarget));
                    s2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Absorb, false, onlySelf, onlyTarget));
                    Tag.Assign(shortFx);
                    Suffix = "%";
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Endurance)
                {
                    shortFx.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Endurance, false, onlySelf, onlyTarget));
                    s2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Endurance, false, onlySelf, onlyTarget));
                    Tag.Assign(shortFx);
                    Suffix = "%";
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Regeneration)
                {
                    shortFx.Assign(pBase.GetEffectMagSum(Enums.eEffectType.Regeneration, false, onlySelf, onlyTarget));
                    s2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.Regeneration, false, onlySelf, onlyTarget));
                    Tag.Assign(shortFx);
                    Suffix = "%";
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Mez & (pBase.Effects[Index[ID]].MezType == Enums.eMez.Taunt | pBase.Effects[Index[ID]].MezType == Enums.eMez.Placate))
                {
                    shortFx.Add(Index[ID], pBase.Effects[Index[ID]].Duration);
                    s2.Add(Index[ID], pEnh.Effects[Index[ID]].Duration);
                    Tag.Assign(shortFx);
                    Suffix = "s";
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.SpeedFlying)
                {
                    shortFx.Assign(pBase.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, onlySelf, onlyTarget));
                    s2.Assign(pEnh.GetEffectMagSum(Enums.eEffectType.SpeedFlying, false, onlySelf, onlyTarget));
                    Tag.Assign(shortFx);
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.DamageBuff | pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Defense | pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Resistance | pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.ResEffect | pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.Enhancement)
                {
                    shortFx.Add(Index[ID], pBase.Effects[Index[ID]].Mag);
                    s2.Add(Index[ID], pEnh.Effects[Index[ID]].Mag);
                    Tag.Assign(pEnh.GetEffectMagSum(pBase.Effects[Index[ID]].EffectType, false, onlySelf, onlyTarget));
                }
                else if (pBase.Effects[Index[ID]].EffectType == Enums.eEffectType.SilentKill)
                {
                    shortFx.Add(Index[ID], pBase.Effects[Index[ID]].Absorbed_Duration);
                    s2.Add(Index[ID], pEnh.Effects[Index[ID]].Absorbed_Duration);
                    Tag.Assign(shortFx);
                }
                else
                {
                    shortFx.Add(Index[ID], pBase.Effects[Index[ID]].Mag);
                    s2.Add(Index[ID], pEnh.Effects[Index[ID]].Mag);
                    Tag.Assign(shortFx);
                }
                if (pBase.Effects[Index[ID]].DisplayPercentage)
                    Suffix = "%";
                if (!(pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target & pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self))
                {
                    if (pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Target)
                        Suffix += " (Tgt)";
                    if (pBase.Effects[Index[ID]].ToWho == Enums.eToWho.Self)
                        Suffix += " (Self)";
                }
                if (flag)
                    return FastItem(Title, 0.0f, 0.0f, string.Empty);
            }
            int num1 = shortFx.Index.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if (shortFx.Index[index] > -1 && pBase.Effects[shortFx.Index[index]].DisplayPercentage)
                {
                    shortFx.Value[index] *= 100f;
                    shortFx.ReSum();
                    break;
                }
            }
            int num2 = s2.Index.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (s2.Index[index] > -1 && pBase.Effects[s2.Index[index]].DisplayPercentage)
                {
                    s2.Value[index] *= 100f;
                    s2.ReSum();
                    break;
                }
            }
            return FastItem(Title, shortFx, s2, Suffix, true, false, pBase.Effects[Index[ID]].Probability < 1.0, pBase.Effects[Index[ID]].SpecialCase != Enums.eSpecialCase.None, Tag);
        }

        public void Init()
        {
        }

        void InitializeComponent()
        {
            components = new Container();
            pnlTabs = new Panel();
            pnlInfo = new Panel();
            PowerScaler = new ctlMultiGraph();
            info_txtSmall = new RichTextBox();
            lblDmg = new Label();
            info_Damage = new ctlDamageDisplay();
            info_DataList = new ctlPairedList();
            info_txtLarge = new RichTextBox();
            info_Title = new GFXLabel();
            pnlFX = new Panel();
            fx_Title = new GFXLabel();
            fx_LblHead3 = new Label();
            fx_List3 = new ctlPairedList();
            fx_lblHead2 = new Label();
            fx_lblHead1 = new Label();
            fx_List2 = new ctlPairedList();
            fx_List1 = new ctlPairedList();
            pnlTotal = new Panel();
            lblTotal = new Label();
            gRes2 = new ctlMultiGraph();
            gRes1 = new ctlMultiGraph();
            gDef2 = new ctlMultiGraph();
            gDef1 = new ctlMultiGraph();
            total_Title = new GFXLabel();
            total_lblMisc = new Label();
            total_Misc = new ctlPairedList();
            total_lblRes = new Label();
            total_lblDef = new Label();
            pnlEnh = new Panel();
            pnlEnhInactive = new Panel();
            pnlEnhActive = new Panel();
            enhNameDisp = new GFXLabel();
            enhListing = new ctlPairedList();
            Enh_Title = new GFXLabel();
            dbTip = new ToolTip(components);
            lblFloat = new Label();
            lblShrink = new Label();
            lblLock = new Label();
            pnlInfo.SuspendLayout();
            pnlFX.SuspendLayout();
            pnlTotal.SuspendLayout();
            pnlEnh.SuspendLayout();
            SuspendLayout();
            pnlTabs.BackColor = Color.FromArgb(64, 64, 64);

            pnlTabs.Location = new Point(0, 0);
            pnlTabs.Name = "pnlTabs";

            pnlTabs.Size = new Size(300, 20);
            pnlTabs.TabIndex = 61;
            pnlInfo.BackColor = Color.Navy;
            pnlInfo.Controls.Add(PowerScaler);
            pnlInfo.Controls.Add(info_txtSmall);
            pnlInfo.Controls.Add(lblDmg);
            pnlInfo.Controls.Add(info_Damage);
            pnlInfo.Controls.Add(info_DataList);
            pnlInfo.Controls.Add(info_txtLarge);
            pnlInfo.Controls.Add(info_Title);

            pnlInfo.Location = new Point(0, 20);
            pnlInfo.Name = "pnlInfo";

            pnlInfo.Size = new Size(300, 328);
            pnlInfo.TabIndex = 62;
            PowerScaler.BackColor = Color.Black;
            PowerScaler.Border = true;
            PowerScaler.Clickable = true;
            PowerScaler.ColorBase = Color.FromArgb(64, byte.MaxValue, 64);
            PowerScaler.ColorEnh = Color.Yellow;
            PowerScaler.ColorFadeEnd = Color.FromArgb(0, 192, 0);
            PowerScaler.ColorFadeStart = Color.Black;
            PowerScaler.ColorHighlight = Color.Gray;
            PowerScaler.ColorLines = Color.Black;
            PowerScaler.ColorMarkerInner = Color.Red;
            PowerScaler.ColorMarkerOuter = Color.Black;
            PowerScaler.Dual = false;
            PowerScaler.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            PowerScaler.ForcedMax = 0.0f;
            PowerScaler.ForeColor = Color.FromArgb(192, 192, byte.MaxValue);
            PowerScaler.Highlight = true;
            PowerScaler.ItemHeight = 10;
            PowerScaler.Lines = true;

            PowerScaler.Location = new Point(4, 145);
            PowerScaler.MarkerValue = 0.0f;
            PowerScaler.Max = 100f;
            PowerScaler.Name = "PowerScaler";
            PowerScaler.PaddingX = 2f;
            PowerScaler.PaddingY = 2f;
            PowerScaler.ScaleHeight = 32;
            PowerScaler.ScaleIndex = 8;
            PowerScaler.ShowScale = false;

            PowerScaler.Size = new Size(292, 15);
            PowerScaler.Style = Enums.GraphStyle.baseOnly;
            PowerScaler.TabIndex = 71;
            PowerScaler.TextWidth = 80;
            info_txtSmall.BackColor = Color.FromArgb(64, 64, 64);
            info_txtSmall.BorderStyle = BorderStyle.None;
            info_txtSmall.Cursor = Cursors.Arrow;
            info_txtSmall.ForeColor = Color.White;

            info_txtSmall.Location = new Point(4, 24);
            info_txtSmall.Name = "info_txtSmall";
            info_txtSmall.ReadOnly = true;
            info_txtSmall.ScrollBars = RichTextBoxScrollBars.None;

            info_txtSmall.Size = new Size(292, 32);
            info_txtSmall.TabIndex = 70;
            info_txtSmall.Text = "info_Rich";
            lblDmg.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDmg.ForeColor = Color.White;

            lblDmg.Location = new Point(4, 272);
            lblDmg.Name = "lblDmg";

            lblDmg.Size = new Size(292, 13);
            lblDmg.TabIndex = 15;
            lblDmg.Text = "Damage:";
            lblDmg.TextAlign = ContentAlignment.MiddleCenter;
            info_Damage.BackColor = Color.FromArgb(64, 64, 64);
            info_Damage.ColorBackEnd = Color.Red;
            info_Damage.ColorBackStart = Color.Black;
            info_Damage.ColorBaseEnd = Color.Blue;
            info_Damage.ColorBaseStart = Color.Blue;
            info_Damage.ColorEnhEnd = Color.Yellow;
            info_Damage.ColorEnhStart = Color.Yellow;
            info_Damage.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            info_Damage.GraphType = Enums.eDDGraph.Enhanced;

            info_Damage.Location = new Point(4, 288);
            info_Damage.Name = "info_Damage";
            info_Damage.nBaseVal = 100f;
            info_Damage.nEnhVal = 150f;
            info_Damage.nHighBase = 200f;
            info_Damage.nHighEnh = 214f;
            info_Damage.nMaxEnhVal = 207f;
            info_Damage.PaddingH = 3;
            info_Damage.PaddingV = 6;

            info_Damage.Size = new Size(292, 36);
            info_Damage.Style = Enums.eDDStyle.TextUnderGraph;
            info_Damage.TabIndex = 20;
            info_Damage.TextAlign = Enums.eDDAlign.Center;
            info_Damage.TextColor = Color.FromArgb(192, 192, byte.MaxValue);
            info_DataList.BackColor = Color.FromArgb(0, 0, 32);
            info_DataList.Columns = 2;
            info_DataList.DoHighlight = true;
            info_DataList.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            info_DataList.ForceBold = false;
            info_DataList.HighlightColor = Color.FromArgb(128, 128, byte.MaxValue);
            info_DataList.HighlightTextColor = Color.Black;
            info_DataList.ItemColor = Color.White;
            info_DataList.ItemColorAlt = Color.Lime;
            info_DataList.ItemColorSpecCase = Color.Red;
            info_DataList.ItemColorSpecial = Color.FromArgb(128, 128, byte.MaxValue);

            info_DataList.Location = new Point(4, 164);
            info_DataList.Name = "info_DataList";
            info_DataList.NameColor = Color.FromArgb(192, 192, byte.MaxValue);

            info_DataList.Size = new Size(292, 104);
            info_DataList.TabIndex = 19;
            info_DataList.ValueWidth = 55;
            info_txtLarge.BackColor = Color.FromArgb(64, 64, 64);
            info_txtLarge.BorderStyle = BorderStyle.None;
            info_txtLarge.Cursor = Cursors.Arrow;
            info_txtLarge.ForeColor = Color.White;

            info_txtLarge.Location = new Point(4, 60);
            info_txtLarge.Name = "info_txtLarge";
            info_txtLarge.ReadOnly = true;
            info_txtLarge.ScrollBars = RichTextBoxScrollBars.ForcedVertical;

            info_txtLarge.Size = new Size(292, 87);
            info_txtLarge.TabIndex = 69;
            info_txtLarge.Text = "info_Rich";
            info_Title.BackColor = Color.FromArgb(64, 64, 64);
            info_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            info_Title.ForeColor = Color.White;
            info_Title.InitialText = "Title";

            info_Title.Location = new Point(24, 4);
            info_Title.Name = "info_Title";

            info_Title.Size = new Size(252, 16);
            info_Title.TabIndex = 69;
            info_Title.TextAlign = ContentAlignment.TopCenter;
            pnlFX.BackColor = Color.Indigo;
            pnlFX.Controls.Add(fx_Title);
            pnlFX.Controls.Add(fx_LblHead3);
            pnlFX.Controls.Add(fx_List3);
            pnlFX.Controls.Add(fx_lblHead2);
            pnlFX.Controls.Add(fx_lblHead1);
            pnlFX.Controls.Add(fx_List2);
            pnlFX.Controls.Add(fx_List1);

            pnlFX.Location = new Point(144, 148);
            pnlFX.Name = "pnlFX";

            pnlFX.Size = new Size(300, 320);
            pnlFX.TabIndex = 63;
            fx_Title.BackColor = Color.FromArgb(64, 64, 64);
            fx_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            fx_Title.ForeColor = Color.White;
            fx_Title.InitialText = "Title";

            fx_Title.Location = new Point(24, 4);
            fx_Title.Name = "fx_Title";

            fx_Title.Size = new Size(252, 16);
            fx_Title.TabIndex = 70;
            fx_Title.TextAlign = ContentAlignment.TopCenter;
            fx_LblHead3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            fx_LblHead3.ForeColor = Color.White;

            fx_LblHead3.Location = new Point(4, 228);
            fx_LblHead3.Name = "fx_LblHead3";

            fx_LblHead3.Size = new Size(292, 16);
            fx_LblHead3.TabIndex = 28;
            fx_LblHead3.Text = "Misc Effects:";
            fx_LblHead3.TextAlign = ContentAlignment.MiddleLeft;
            fx_List3.BackColor = Color.FromArgb(64, 64, 64);
            fx_List3.Columns = 2;
            fx_List3.DoHighlight = true;
            fx_List3.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            fx_List3.ForceBold = false;
            fx_List3.HighlightColor = Color.FromArgb(128, 128, byte.MaxValue);
            fx_List3.HighlightTextColor = Color.Black;
            fx_List3.ItemColor = Color.White;
            fx_List3.ItemColorAlt = Color.Lime;
            fx_List3.ItemColorSpecCase = Color.Red;
            fx_List3.ItemColorSpecial = Color.FromArgb(128, 128, byte.MaxValue);

            fx_List3.Location = new Point(4, 244);
            fx_List3.Name = "fx_List3";
            fx_List3.NameColor = Color.FromArgb(192, 192, byte.MaxValue);

            fx_List3.Size = new Size(292, 72);
            fx_List3.TabIndex = 27;
            fx_List3.ValueWidth = 55;
            fx_lblHead2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            fx_lblHead2.ForeColor = Color.White;

            fx_lblHead2.Location = new Point(4, 136);
            fx_lblHead2.Name = "fx_lblHead2";

            fx_lblHead2.Size = new Size(292, 16);
            fx_lblHead2.TabIndex = 26;
            fx_lblHead2.Text = "Secondary Effects:";
            fx_lblHead2.TextAlign = ContentAlignment.MiddleLeft;
            fx_lblHead1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            fx_lblHead1.ForeColor = Color.White;

            fx_lblHead1.Location = new Point(4, 24);
            fx_lblHead1.Name = "fx_lblHead1";

            fx_lblHead1.Size = new Size(292, 16);
            fx_lblHead1.TabIndex = 25;
            fx_lblHead1.Text = "Primary Effects:";
            fx_lblHead1.TextAlign = ContentAlignment.MiddleLeft;
            fx_List2.BackColor = Color.FromArgb(64, 64, 64);
            fx_List2.Columns = 2;
            fx_List2.DoHighlight = true;
            fx_List2.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            fx_List2.ForceBold = false;
            fx_List2.HighlightColor = Color.FromArgb(128, 128, byte.MaxValue);
            fx_List2.HighlightTextColor = Color.Black;
            fx_List2.ItemColor = Color.White;
            fx_List2.ItemColorAlt = Color.Lime;
            fx_List2.ItemColorSpecCase = Color.Red;
            fx_List2.ItemColorSpecial = Color.FromArgb(128, 128, byte.MaxValue);

            fx_List2.Location = new Point(4, 152);
            fx_List2.Name = "fx_List2";
            fx_List2.NameColor = Color.FromArgb(192, 192, byte.MaxValue);

            fx_List2.Size = new Size(292, 72);
            fx_List2.TabIndex = 24;
            fx_List2.ValueWidth = 55;
            fx_List1.BackColor = Color.FromArgb(64, 64, 64);
            fx_List1.Columns = 2;
            fx_List1.DoHighlight = true;
            fx_List1.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            fx_List1.ForceBold = false;
            fx_List1.HighlightColor = Color.FromArgb(128, 128, byte.MaxValue);
            fx_List1.HighlightTextColor = Color.Black;
            fx_List1.ItemColor = Color.White;
            fx_List1.ItemColorAlt = Color.Lime;
            fx_List1.ItemColorSpecCase = Color.Red;
            fx_List1.ItemColorSpecial = Color.FromArgb(128, 128, byte.MaxValue);

            fx_List1.Location = new Point(4, 40);
            fx_List1.Name = "fx_List1";
            fx_List1.NameColor = Color.FromArgb(192, 192, byte.MaxValue);

            fx_List1.Size = new Size(292, 92);
            fx_List1.TabIndex = 23;
            fx_List1.ValueWidth = 60;
            pnlTotal.BackColor = Color.Green;
            pnlTotal.Controls.Add(lblTotal);
            pnlTotal.Controls.Add(gRes2);
            pnlTotal.Controls.Add(gRes1);
            pnlTotal.Controls.Add(gDef2);
            pnlTotal.Controls.Add(gDef1);
            pnlTotal.Controls.Add(total_Title);
            pnlTotal.Controls.Add(total_lblMisc);
            pnlTotal.Controls.Add(total_Misc);
            pnlTotal.Controls.Add(total_lblRes);
            pnlTotal.Controls.Add(total_lblDef);

            pnlTotal.Location = new Point(248, 15);
            pnlTotal.Name = "pnlTotal";

            pnlTotal.Size = new Size(300, 319);
            pnlTotal.TabIndex = 64;
            lblTotal.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;

            lblTotal.Location = new Point(4, 300);
            lblTotal.Name = "lblTotal";

            lblTotal.Size = new Size(292, 16);
            lblTotal.TabIndex = 75;
            lblTotal.Text = "Click the 'View Totals' button for more.";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            gRes2.BackColor = Color.Black;
            gRes2.Border = true;
            gRes2.Clickable = false;
            gRes2.ColorBase = Color.FromArgb(0, 192, 192);
            gRes2.ColorEnh = Color.FromArgb(byte.MaxValue, 128, 128);
            gRes2.ColorFadeEnd = Color.Teal;
            gRes2.ColorFadeStart = Color.Black;
            gRes2.ColorHighlight = Color.Gray;
            gRes2.ColorLines = Color.Black;
            gRes2.ColorMarkerInner = Color.Black;
            gRes2.ColorMarkerOuter = Color.Yellow;
            gRes2.Dual = false;
            gRes2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            gRes2.ForcedMax = 0.0f;
            gRes2.ForeColor = Color.FromArgb(192, 192, byte.MaxValue);
            gRes2.Highlight = true;
            gRes2.ItemHeight = 13;
            gRes2.Lines = true;

            gRes2.Location = new Point(150, 152);
            gRes2.MarkerValue = 0.0f;
            gRes2.Max = 100f;
            gRes2.Name = "gRes2";
            gRes2.PaddingX = 2f;
            gRes2.PaddingY = 4f;
            gRes2.ScaleHeight = 32;
            gRes2.ScaleIndex = 8;
            gRes2.ShowScale = false;

            gRes2.Size = new Size(146, 72);
            gRes2.Style = Enums.GraphStyle.Stacked;
            gRes2.TabIndex = 74;
            gRes2.TextWidth = 100;
            gRes1.BackColor = Color.Black;
            gRes1.Border = true;
            gRes1.Clickable = false;
            gRes1.ColorBase = Color.FromArgb(0, 192, 192);
            gRes1.ColorEnh = Color.FromArgb(byte.MaxValue, 128, 128);
            gRes1.ColorFadeEnd = Color.Teal;
            gRes1.ColorFadeStart = Color.Black;
            gRes1.ColorHighlight = Color.Gray;
            gRes1.ColorLines = Color.Black;
            gRes1.ColorMarkerInner = Color.Black;
            gRes1.ColorMarkerOuter = Color.Yellow;
            gRes1.Dual = false;
            gRes1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            gRes1.ForcedMax = 0.0f;
            gRes1.ForeColor = Color.FromArgb(192, 192, byte.MaxValue);
            gRes1.Highlight = true;
            gRes1.ItemHeight = 13;
            gRes1.Lines = true;

            gRes1.Location = new Point(4, 152);
            gRes1.MarkerValue = 0.0f;
            gRes1.Max = 100f;
            gRes1.Name = "gRes1";
            gRes1.PaddingX = 2f;
            gRes1.PaddingY = 4f;
            gRes1.ScaleHeight = 32;
            gRes1.ScaleIndex = 8;
            gRes1.ShowScale = false;

            gRes1.Size = new Size(146, 72);
            gRes1.Style = Enums.GraphStyle.Stacked;
            gRes1.TabIndex = 73;
            gRes1.TextWidth = 100;
            gDef2.BackColor = Color.Black;
            gDef2.Border = true;
            gDef2.Clickable = false;
            gDef2.ColorBase = Color.FromArgb(192, 0, 192);
            gDef2.ColorEnh = Color.Yellow;
            gDef2.ColorFadeEnd = Color.Purple;
            gDef2.ColorFadeStart = Color.Black;
            gDef2.ColorHighlight = Color.Gray;
            gDef2.ColorLines = Color.Black;
            gDef2.ColorMarkerInner = Color.Black;
            gDef2.ColorMarkerOuter = Color.Yellow;
            gDef2.Dual = false;
            gDef2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            gDef2.ForcedMax = 0.0f;
            gDef2.ForeColor = Color.FromArgb(192, 192, byte.MaxValue);
            gDef2.Highlight = true;
            gDef2.ItemHeight = 13;
            gDef2.Lines = true;

            gDef2.Location = new Point(150, 40);
            gDef2.MarkerValue = 0.0f;
            gDef2.Max = 100f;
            gDef2.Name = "gDef2";
            gDef2.PaddingX = 2f;
            gDef2.PaddingY = 4f;
            gDef2.ScaleHeight = 32;
            gDef2.ScaleIndex = 8;
            gDef2.ShowScale = false;

            gDef2.Size = new Size(146, 92);
            gDef2.Style = Enums.GraphStyle.baseOnly;
            gDef2.TabIndex = 72;
            gDef2.TextWidth = 100;
            gDef1.BackColor = Color.Black;
            gDef1.Border = true;
            gDef1.Clickable = false;
            gDef1.ColorBase = Color.FromArgb(192, 0, 192);
            gDef1.ColorEnh = Color.Yellow;
            gDef1.ColorFadeEnd = Color.Purple;
            gDef1.ColorFadeStart = Color.Black;
            gDef1.ColorHighlight = Color.Gray;
            gDef1.ColorLines = Color.Black;
            gDef1.ColorMarkerInner = Color.Black;
            gDef1.ColorMarkerOuter = Color.Yellow;
            gDef1.Dual = false;
            gDef1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            gDef1.ForcedMax = 0.0f;
            gDef1.ForeColor = Color.FromArgb(192, 192, byte.MaxValue);
            gDef1.Highlight = true;
            gDef1.ItemHeight = 13;
            gDef1.Lines = true;

            gDef1.Location = new Point(4, 40);
            gDef1.MarkerValue = 0.0f;
            gDef1.Max = 100f;
            gDef1.Name = "gDef1";
            gDef1.PaddingX = 2f;
            gDef1.PaddingY = 4f;
            gDef1.ScaleHeight = 32;
            gDef1.ScaleIndex = 8;
            gDef1.ShowScale = false;

            gDef1.Size = new Size(146, 92);
            gDef1.Style = Enums.GraphStyle.baseOnly;
            gDef1.TabIndex = 71;
            gDef1.TextWidth = 100;
            total_Title.BackColor = Color.FromArgb(64, 64, 64);
            total_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_Title.ForeColor = Color.White;
            total_Title.InitialText = "Cumulative Totals (For Self)";

            total_Title.Location = new Point(24, 4);
            total_Title.Name = "total_Title";

            total_Title.Size = new Size(252, 16);
            total_Title.TabIndex = 70;
            total_Title.TextAlign = ContentAlignment.TopCenter;
            total_lblMisc.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_lblMisc.ForeColor = Color.White;

            total_lblMisc.Location = new Point(4, 228);
            total_lblMisc.Name = "total_lblMisc";

            total_lblMisc.Size = new Size(292, 16);
            total_lblMisc.TabIndex = 28;
            total_lblMisc.Text = "Misc Effects:";
            total_lblMisc.TextAlign = ContentAlignment.MiddleLeft;
            total_Misc.BackColor = Color.FromArgb(64, 64, 64);
            total_Misc.Columns = 2;
            total_Misc.DoHighlight = true;
            total_Misc.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            total_Misc.ForceBold = false;
            total_Misc.HighlightColor = Color.FromArgb(128, 128, byte.MaxValue);
            total_Misc.HighlightTextColor = Color.Black;
            total_Misc.ItemColor = Color.White;
            total_Misc.ItemColorAlt = Color.Lime;
            total_Misc.ItemColorSpecCase = Color.Red;
            total_Misc.ItemColorSpecial = Color.FromArgb(128, 128, byte.MaxValue);

            total_Misc.Location = new Point(4, 244);
            total_Misc.Name = "total_Misc";
            total_Misc.NameColor = Color.FromArgb(192, 192, byte.MaxValue);

            total_Misc.Size = new Size(292, 60);
            total_Misc.TabIndex = 27;
            total_Misc.ValueWidth = 55;
            total_lblRes.BackColor = Color.Green;
            total_lblRes.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_lblRes.ForeColor = Color.White;

            total_lblRes.Location = new Point(4, 136);
            total_lblRes.Name = "total_lblRes";

            total_lblRes.Size = new Size(292, 16);
            total_lblRes.TabIndex = 26;
            total_lblRes.Text = "Resistance:";
            total_lblRes.TextAlign = ContentAlignment.MiddleLeft;
            total_lblDef.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            total_lblDef.ForeColor = Color.White;

            total_lblDef.Location = new Point(4, 24);
            total_lblDef.Name = "total_lblDef";

            total_lblDef.Size = new Size(292, 16);
            total_lblDef.TabIndex = 25;
            total_lblDef.Text = "Defense:";
            total_lblDef.TextAlign = ContentAlignment.MiddleLeft;
            pnlEnh.BackColor = Color.Teal;
            pnlEnh.Controls.Add(pnlEnhInactive);
            pnlEnh.Controls.Add(pnlEnhActive);
            pnlEnh.Controls.Add(enhNameDisp);
            pnlEnh.Controls.Add(enhListing);
            pnlEnh.Controls.Add(Enh_Title);

            pnlEnh.Location = new Point(188, 156);
            pnlEnh.Name = "pnlEnh";

            pnlEnh.Size = new Size(300, 320);
            pnlEnh.TabIndex = 65;
            pnlEnhInactive.BackColor = Color.Black;

            pnlEnhInactive.Location = new Point(4, 279);
            pnlEnhInactive.Name = "pnlEnhInactive";

            pnlEnhInactive.Size = new Size(292, 38);
            pnlEnhInactive.TabIndex = 74;
            pnlEnhActive.BackColor = Color.Black;
            pnlEnhActive.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);

            pnlEnhActive.Location = new Point(4, 239);
            pnlEnhActive.Name = "pnlEnhActive";

            pnlEnhActive.Size = new Size(292, 38);
            pnlEnhActive.TabIndex = 73;
            enhNameDisp.BackColor = Color.FromArgb(64, 64, 64);
            enhNameDisp.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            enhNameDisp.ForeColor = Color.White;
            enhNameDisp.InitialText = "Title";

            enhNameDisp.Location = new Point(4, 24);
            enhNameDisp.Name = "enhNameDisp";

            enhNameDisp.Size = new Size(292, 16);
            enhNameDisp.TabIndex = 72;
            enhNameDisp.TextAlign = ContentAlignment.TopCenter;
            enhListing.BackColor = Color.FromArgb(0, 0, 32);
            enhListing.Columns = 1;
            enhListing.DoHighlight = true;
            enhListing.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 178);
            enhListing.ForceBold = false;
            enhListing.HighlightColor = Color.FromArgb(128, 128, byte.MaxValue);
            enhListing.HighlightTextColor = Color.Black;
            enhListing.ItemColor = Color.White;
            enhListing.ItemColorAlt = Color.Yellow;
            enhListing.ItemColorSpecCase = Color.Red;
            enhListing.ItemColorSpecial = Color.FromArgb(128, 128, byte.MaxValue);

            enhListing.Location = new Point(4, 44);
            enhListing.Name = "enhListing";
            enhListing.NameColor = Color.FromArgb(192, 192, byte.MaxValue);

            enhListing.Size = new Size(292, 192);
            enhListing.TabIndex = 71;
            enhListing.ValueWidth = 65;
            Enh_Title.BackColor = Color.FromArgb(64, 64, 64);
            Enh_Title.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Enh_Title.ForeColor = Color.White;
            Enh_Title.InitialText = "Title";

            Enh_Title.Location = new Point(24, 4);
            Enh_Title.Name = "Enh_Title";

            Enh_Title.Size = new Size(252, 16);
            Enh_Title.TabIndex = 70;
            Enh_Title.TextAlign = ContentAlignment.TopCenter;
            dbTip.AutoPopDelay = 15000;
            dbTip.InitialDelay = 350;
            dbTip.ReshowDelay = 100;
            lblFloat.BackColor = Color.FromArgb(64, 64, 64);
            lblFloat.BorderStyle = BorderStyle.FixedSingle;
            lblFloat.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, 2);
            lblFloat.ForeColor = Color.White;

            lblFloat.Location = new Point(4, 24);
            lblFloat.Name = "lblFloat";

            lblFloat.Size = new Size(16, 16);
            lblFloat.TabIndex = 66;
            lblFloat.Text = "F";
            lblFloat.TextAlign = ContentAlignment.MiddleCenter;
            dbTip.SetToolTip(lblFloat, "Make Floating Window");
            lblFloat.UseCompatibleTextRendering = true;
            lblShrink.BackColor = Color.FromArgb(64, 64, 64);
            lblShrink.BorderStyle = BorderStyle.FixedSingle;
            lblShrink.Font = new Font("Wingdings", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 2);
            lblShrink.ForeColor = Color.White;

            lblShrink.Location = new Point(280, 24);
            lblShrink.Name = "lblShrink";

            lblShrink.Size = new Size(16, 16);
            lblShrink.TabIndex = 67;
            lblShrink.Text = "y";
            lblShrink.TextAlign = ContentAlignment.MiddleCenter;
            dbTip.SetToolTip(lblShrink, "Shrink / Expland the Info Display");
            lblShrink.UseCompatibleTextRendering = true;
            lblLock.BackColor = Color.Red;
            lblLock.BorderStyle = BorderStyle.FixedSingle;
            lblLock.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLock.ForeColor = Color.White;

            lblLock.Location = new Point(220, 24);
            lblLock.Name = "lblLock";

            lblLock.Size = new Size(56, 16);
            lblLock.TabIndex = 68;
            lblLock.Text = "[Unlock]";
            lblLock.TextAlign = ContentAlignment.MiddleCenter;
            dbTip.SetToolTip(lblLock, "The info display is currently locked to display a specific power, click here to unlock it to display powers as you hover the mouse over them.");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(0, 0, 32);
            Controls.Add(lblLock);
            Controls.Add(lblFloat);
            Controls.Add(lblShrink);
            Controls.Add(pnlTabs);
            Controls.Add(pnlInfo);
            Controls.Add(pnlTotal);
            Controls.Add(pnlEnh);
            Controls.Add(pnlFX);
            Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);

            Size = new Size(564, 540);
            pnlInfo.ResumeLayout(false);
            pnlFX.ResumeLayout(false);
            pnlTotal.ResumeLayout(false);
            pnlEnh.ResumeLayout(false);
            //adding events

            // Enh_Title events
            Enh_Title.MouseMove += Title_MouseMove;
            Enh_Title.MouseDown += Title_MouseDown;

            PowerScaler.BarClick += PowerScaler_BarClick;
            enhListing.ItemHover += PairedList_Hover;
            fx_List1.ItemHover += PairedList_Hover;
            fx_List2.ItemHover += PairedList_Hover;
            fx_List3.ItemHover += PairedList_Hover;

            // fx_Title events
            fx_Title.MouseMove += Title_MouseMove;
            fx_Title.MouseDown += Title_MouseDown;

            info_DataList.ItemHover += PairedList_Hover;

            // info_Title events
            info_Title.MouseMove += Title_MouseMove;
            info_Title.MouseDown += Title_MouseDown;

            lblFloat.Click += lblFloat_Click;
            lblLock.Click += lblLock_Click;

            // lblShrink events
            lblShrink.DoubleClick += lblShrink_DoubleClick;
            lblShrink.Click += lblShrink_Click;


            // pnlEnhActive events
            pnlEnhActive.Paint += pnlEnhActive_Paint;
            pnlEnhActive.MouseMove += pnlEnhActive_MouseMove;
            pnlEnhActive.MouseClick += pnlEnhActive_MouseClick;


            // pnlEnhInactive events
            pnlEnhInactive.Paint += pnlEnhInactive_Paint;
            pnlEnhInactive.MouseMove += pnlEnhInactive_MouseMove;
            pnlEnhInactive.MouseClick += pnlEnhInactive_MouseClick;


            // pnlTabs events
            pnlTabs.MouseDown += pnlTabs_MouseDown;
            pnlTabs.Paint += pnlTabs_Paint;

            total_Misc.ItemHover += PairedList_Hover;

            // total_Title events
            total_Title.MouseMove += Title_MouseMove;
            total_Title.MouseDown += Title_MouseDown;

            // finished with events
            ResumeLayout(false);
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
            FloatChangeEventHandler floatChange = FloatChange;
            if (floatChange == null)
                return;
            floatChange();
        }

        void lblLock_Click(object sender, EventArgs e)

        {
            Unlock_ClickEventHandler unlockClick = Unlock_Click;
            if (unlockClick != null)
                unlockClick();
            lblLock.Visible = false;
            pnlTabs.Select();
        }

        void lblShrink_Click(object sender, EventArgs e)

        {
            if (Compact)
                ResetSize();
            else
                CompactSize();
        }

        void lblShrink_DoubleClick(object sender, EventArgs e)
        {
            lblShrink_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        int miniGetEnhIndex(int iX, int iY)
        {
            int num1 = bxFlip.Size.Width - 188;
            if (pBase != null)
            {
                int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
                if (inToonHistory < 0)
                    return -1;
                int num2 = MidsContext.Character.CurrentBuild.Powers[inToonHistory].SlotCount - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    Rectangle rectangle = new Rectangle(num1 + 30 * index, (int)Math.Round((bxFlip.Size.Height / 2.0 - 30.0) / 2.0), 30, 30);
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
                IPower power = new Power(pEnh);
                int num1 = Tag.Index.Length - 1;
                for (int index1 = 0; index1 <= num1; ++index1)
                {
                    if (Tag.Index[index1] != -1 && power.Effects[Tag.Index[index1]].EffectType != Enums.eEffectType.None)
                    {
                        string empty3 = string.Empty;
                        int[] returnMask = new int[0];
                        power.GetEffectStringGrouped(Tag.Index[index1], ref empty3, ref returnMask, false, false);
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
                        empty2 += power.Effects[Tag.Index[index]].BuildEffectString();
                    }
                }
                str1 = empty1 + empty2;
            }
            else
                str1 = "No Valid Tip";
            object[] Arguments = new object[1] { str1 };
            bool[] CopyBack = new bool[1] { true };
            NewLateBinding.LateCall(Sender, null, "SetTip", Arguments, null, null, CopyBack, true);
            if (!CopyBack[0])
                return;
            string str2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(Arguments[0]), typeof(string));
        }

        void pnlEnhActive_MouseClick(object sender, MouseEventArgs e)
        {
            if (pBase == null || e.Button != MouseButtons.Left)
                return;
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
            if (inToonHistory > -1)
            {
                SlotFlipEventHandler slotFlip = SlotFlip;
                if (slotFlip != null)
                    slotFlip(inToonHistory);
            }
        }

        void pnlEnhActive_MouseMove(object sender, MouseEventArgs e)
        {
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
            int enhIndex = miniGetEnhIndex(e.X, e.Y);
            if (enhIndex <= -1)
                return;
            SetEnhancement(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Enhancement, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Level);
        }

        void pnlEnhActive_Paint(object sender, PaintEventArgs e)
        {
            RedrawFlip();
        }

        void pnlEnhInactive_MouseClick(object sender, MouseEventArgs e)
        {
            if (pBase == null || e.Button != MouseButtons.Left)
                return;
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
            if (inToonHistory > -1)
            {
                SlotFlipEventHandler slotFlip = SlotFlip;
                if (slotFlip != null)
                    slotFlip(inToonHistory);
            }
        }

        void pnlEnhInactive_MouseMove(object sender, MouseEventArgs e)
        {
            int inToonHistory = MidsContext.Character.CurrentBuild.FindInToonHistory(pBase.PowerIndex);
            int enhIndex = miniGetEnhIndex(e.X, e.Y);
            if (enhIndex <= -1)
                return;
            SetEnhancement(MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].FlippedEnhancement, MidsContext.Character.CurrentBuild.Powers[inToonHistory].Slots[enhIndex].Level);
        }

        void pnlEnhInactive_Paint(object sender, PaintEventArgs e)
        {
            RedrawFlip();
        }

        void pnlTabs_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle clipRect = new Rectangle(0, 0, 70, pnlTabs.Height);
            int Index = 0;
            while (!(e.X >= clipRect.X & e.X <= clipRect.Width + clipRect.X))
            {
                clipRect.X += clipRect.Width;
                ++Index;
                if (Index > 3)
                    return;
            }
            if (Index != TabPage)
            {
                TabChangedEventHandler tabChanged = TabChanged;
                if (tabChanged != null)
                    tabChanged(Index);
            }
            TabPage = Index;
            pnlTabs_Paint(this, new PaintEventArgs(pnlTabs.CreateGraphics(), clipRect));
        }

        void pnlTabs_Paint(object sender, PaintEventArgs e)
        {
            DoPaint();
        }

        void PowerScaler_BarClick(float Value)
        {
            int num = (int)Math.Round(Value);
            if (num < pBase.VariableMin)
                num = pBase.VariableMin;
            if (num > pBase.VariableMax)
                num = pBase.VariableMax;
            MidsContext.Character.CurrentBuild.Powers[HistoryIDX].VariableValue = num;
            if (num == pLastScaleVal)
                return;
            SetPowerScaler();
            pLastScaleVal = num;
            MainModule.MidsController.Toon.GenerateBuffedPowerArray();
            SlotUpdateEventHandler slotUpdate = SlotUpdate;
            if (slotUpdate != null)
                slotUpdate();
        }

        void RedrawFlip()
        {
            if (bxFlip == null)
                DisplayFlippedEnhancements();
            Rectangle srcRect = new Rectangle(0, 0, pnlEnhActive.Width, pnlEnhActive.Height);
            Rectangle destRect = new Rectangle(0, 0, pnlEnhActive.Width, pnlEnhActive.Height);
            pnlEnhActive.CreateGraphics().DrawImage(bxFlip.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            srcRect = new Rectangle(0, pnlEnhActive.Height, pnlEnhInactive.Width, pnlEnhInactive.Height);
            pnlEnhInactive.CreateGraphics().DrawImage(bxFlip.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
        }

        void ResetSize()
        {
            Size size = Size;
            info_txtSmall.Height = 32;
            info_txtLarge.Top = info_txtSmall.Bottom + 4;
            if (PowerScaler.Visible)
            {
                info_txtLarge.Height = 100 - PowerScaler.Height;
                PowerScaler.Top = info_txtLarge.Bottom;
                info_DataList.Top = PowerScaler.Bottom + 4;
            }
            else
            {
                info_txtLarge.Height = 100;
                PowerScaler.Top = info_txtLarge.Bottom - PowerScaler.Height;
                info_DataList.Top = info_txtLarge.Bottom + 4;
            }
            info_DataList.Height = 104;
            lblDmg.Visible = true;
            lblDmg.Top = info_DataList.Bottom + 4;
            info_Damage.Top = lblDmg.Bottom + 4;
            info_Damage.PaddingV = 6;
            info_Damage.Height = 36;
            enhListing.Height = info_Damage.Bottom - (enhListing.Top + (pnlEnhActive.Height + 4) * 2);
            pnlEnhActive.Top = enhListing.Bottom + 4;
            pnlEnhInactive.Top = pnlEnhActive.Bottom + 4;
            pnlInfo.Height = info_Damage.Bottom + 4;
            pnlEnh.Height = pnlInfo.Height;
            Height = pnlInfo.Bottom;
            Compact = false;
            if (!(Size != size))
                return;
            SizeChangeEventHandler sizeChange = SizeChange;
            if (sizeChange != null)
                sizeChange(Size, Compact);
        }

        void SetBackColor()
        {
            info_Title.BackColor = BackColor;
            info_txtLarge.BackColor = BackColor;
            info_txtSmall.BackColor = BackColor;
            info_DataList.BackColor = BackColor;
            info_Damage.BackColor = BackColor;
            fx_List1.BackColor = BackColor;
            fx_List2.BackColor = BackColor;
            fx_List3.BackColor = BackColor;
            fx_Title.BackColor = BackColor;
            total_Misc.BackColor = BackColor;
            total_Title.BackColor = BackColor;
            enhListing.BackColor = BackColor;
            Enh_Title.BackColor = BackColor;
            enhNameDisp.BackColor = BackColor;
            DoPaint();
            lblFloat.BackColor = BackColor;
            lblShrink.BackColor = BackColor;
            info_DataList.Draw();
            info_Damage.Draw();
            fx_List1.Draw();
            fx_List2.Draw();
            fx_List3.Draw();
            total_Misc.Draw();
            enhListing.Draw();
        }

        void SetDamageTip()
        {
            string iTip = string.Empty;
            int num1 = -1;
            int num2 = -1;
            int num3 = 0;
            int num4 = pEnh.Effects.Length - 1;
            for (int index = 0; index <= num4; ++index)
            {
                IEffect effect = pEnh.Effects[index];
                if (effect.EffectType == Enums.eEffectType.Damage)
                {
                    if (effect.CanInclude() & pEnh.Effects[index].PvXInclude())
                    {
                        if (iTip != string.Empty)
                            iTip += "\r\n";
                        string str = pEnh.Effects[index].BuildEffectString();
                        if (pEnh.Effects[index].isEnhancementEffect & pEnh.PowerType == Enums.ePowerType.Toggle)
                        {
                            ++num1;
                            str += " (Special only every 10s)";
                        }
                        else if (pEnh.PowerType == Enums.ePowerType.Toggle)
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
            if (!(pBase.PowerType == Enums.ePowerType.Toggle & num1 == -1 & num2 == -1) && pBase.PowerType == Enums.ePowerType.Toggle & num2 > -1 && iTip != string.Empty)
                iTip = "Applied every " + Conversions.ToString(pBase.ActivatePeriod) + "s:\r\n" + iTip;
            info_Damage.SetTip(iTip);
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
            Lock = Locked;
            pBase = new Power(iBase);
            pEnh = iEnhanced != null ? (iEnhanced.Effects.Length == iBase.Effects.Length ? new Power(iEnhanced) : new Power(iBase)) : new Power(iBase);
            HistoryIDX = iHistoryIDX;
            SetDamageTip();
            DisplayData(noLevel);
            SizeRefresh();
        }

        public void SetEnhancement(I9Slot iEnh, int iLevel = -1)
        {
            if (Lock & TabPage != 3 || iLevel < 0)
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
                str1 = pBase.DisplayName;
                info_txtSmall.Rtf = RTF.StartRTF() + pBase.DescShort + "\r\n" + RTF.Color(RTF.ElementID.Faded) + "Shift+Click to move slot. Right-Click to place enh." + RTF.EndRTF();
            }
            if (iLevel > -1 & !MidsContext.Config.ShowSlotLevels)
                str1 = str1 + " (Slot Level " + Conversions.ToString(iLevel + 1) + ")";
            info_Title.Text = str1;
            fx_Title.Text = str1;
            enhNameDisp.Text = str1;
            if (TabPage <= 1 && iEnh.Enh >= 0)
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
                        if (DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance < 1.0 & DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 0.0)
                            str2 = str2 + RTF.Color(RTF.ElementID.Enhancement) + Strings.Format((float)(DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance * 100.0), "##0") + "% chance of ";
                    }
                    else
                        iStr1 = iStr1 + RTF.Color(RTF.ElementID.Enhancement) + "Hamidon/Synthetic Hamidon Origin Enhancement";
                }
                else
                {
                    if (iStr1 != string.Empty)
                        iStr1 += " - ";
                    iStr1 += GetEnhancementStringRTF(iEnh);
                }
                string iStr2;
                if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
                {
                    iStr2 = str2 + GetEnhancementStringLongRTF(iEnh) + "\r\n" + EnhancementSetCollection.GetSetInfoLongRTF(DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet);
                }
                else
                {
                    string str3 = str2 + DatabaseAPI.Database.Enhancements[iEnh.Enh].Desc;
                    if (str3 != string.Empty)
                        str3 += "\r\n";
                    iStr2 = str3 + GetEnhancementStringLongRTF(iEnh);
                }
                info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr1) + RTF.Crlf() + RTF.Color(RTF.ElementID.Faded) + "Shift+Click to move slot. Right-Click to place enh." + RTF.EndRTF();
                info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr2) + RTF.EndRTF();
            }
        }

        public void SetEnhancementPicker(I9Slot iEnh)
        {
            if (iEnh.Enh < 0)
                info_Title.Text = "No Enhancement";
            info_Title.Text = DatabaseAPI.Database.Enhancements[iEnh.Enh].LongName;
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
                    if (DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 1.0 & DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance > 0.0)
                        str1 = str1 + RTF.Color(RTF.ElementID.Enhancement) + Strings.Format((float)(DatabaseAPI.Database.Enhancements[iEnh.Enh].EffectChance * 100.0), "##0") + "% chance of ";
                }
                else
                    iStr1 += "Hamidon/Synthetic Hamidon Origin Enhancement";
            }
            else
            {
                if (iStr1 != string.Empty)
                    iStr1 += " - ";
                iStr1 += GetEnhancementStringRTF(iEnh);
            }
            string iStr2;
            if (DatabaseAPI.Database.Enhancements[iEnh.Enh].TypeID == Enums.eType.SetO)
            {
                iStr2 = str1 + GetEnhancementStringLongRTF(iEnh) + RTF.Size(RTF.SizeID.Tiny) + "\r\n" + EnhancementSetCollection.GetSetInfoLongRTF(DatabaseAPI.Database.Enhancements[iEnh.Enh].nIDSet);
            }
            else
            {
                string str2 = str1 + DatabaseAPI.Database.Enhancements[iEnh.Enh].Desc;
                if (str2 != string.Empty)
                    str2 += "\r\n";
                iStr2 = str2 + GetEnhancementStringLongRTF(iEnh);
            }
            info_txtSmall.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr1) + RTF.Crlf() + RTF.EndRTF();
            info_txtLarge.Rtf = RTF.StartRTF() + RTF.ToRTF(iStr2) + RTF.EndRTF();
        }

        public void SetFontData()
        {
            info_DataList.Font = new Font(info_DataList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            fx_List1.Font = new Font(fx_List1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            fx_List2.Font = new Font(fx_List2.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            fx_List3.Font = new Font(fx_List3.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            total_Misc.Font = new Font(total_Misc.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            enhListing.Font = new Font(enhListing.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Regular);
            pnlEnhActive.Font = new Font(enhListing.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold);
            info_DataList.ForceBold = MidsContext.Config.RtFont.PairedBold;
            fx_List1.ForceBold = MidsContext.Config.RtFont.PairedBold;
            fx_List2.ForceBold = MidsContext.Config.RtFont.PairedBold;
            fx_List3.ForceBold = MidsContext.Config.RtFont.PairedBold;
            total_Misc.ForceBold = MidsContext.Config.RtFont.PairedBold;
            enhListing.ForceBold = MidsContext.Config.RtFont.PairedBold;
            gDef1.Font = new Font(gDef1.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold);
            gDef2.Font = gDef1.Font;
            gRes1.Font = gDef1.Font;
            gRes2.Font = gDef1.Font;
            SetBackColor();
            info_DataList.NameColor = MidsContext.Config.RtFont.ColorPlName;
            fx_List1.NameColor = MidsContext.Config.RtFont.ColorPlName;
            fx_List2.NameColor = MidsContext.Config.RtFont.ColorPlName;
            fx_List3.NameColor = MidsContext.Config.RtFont.ColorPlName;
            total_Misc.NameColor = MidsContext.Config.RtFont.ColorPlName;
            enhListing.NameColor = MidsContext.Config.RtFont.ColorPlName;
            info_DataList.ItemColor = MidsContext.Config.RtFont.ColorText;
            fx_List1.ItemColor = MidsContext.Config.RtFont.ColorText;
            fx_List2.ItemColor = MidsContext.Config.RtFont.ColorText;
            fx_List3.ItemColor = MidsContext.Config.RtFont.ColorText;
            enhListing.ItemColor = MidsContext.Config.RtFont.ColorText;
            total_Misc.ItemColor = MidsContext.Config.RtFont.ColorText;
            info_DataList.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            fx_List1.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            fx_List2.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            fx_List3.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            enhListing.ItemColorAlt = Color.Yellow;
            total_Misc.ItemColorAlt = MidsContext.Config.RtFont.ColorEnhancement;
            info_DataList.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            fx_List1.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            fx_List2.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            fx_List3.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            enhListing.ValueColorD = Color.Red;
            total_Misc.ValueColorD = MidsContext.Config.RtFont.ColorInvention;
            info_DataList.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            fx_List1.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            fx_List2.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            fx_List3.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
            enhListing.ItemColorSpecial = Color.FromArgb(0, byte.MaxValue, 0);
            total_Misc.ItemColorSpecial = MidsContext.Config.RtFont.ColorPlSpecial;
        }

        public void SetLocation(Point iLocation, bool Force)
        {
            bool flag = Force | SnapLocation.X == Location.X & SnapLocation.Y == Location.Y;
            SnapLocation.X = iLocation.X;
            SnapLocation.Y = iLocation.Y;
            SnapLocation.Width = Width;
            if (SnapLocation.Height < Height)
                SnapLocation.Height = Height;
            if (!flag)
                return;
            Left = SnapLocation.X;
            Top = SnapLocation.Y;
        }

        void SetPowerScaler()
        {
            if (pBase == null)
                PowerScaler.Visible = false;
            else if (pBase.VariableEnabled & HistoryIDX > -1)
            {
                string str = pBase.VariableName;
                if (string.IsNullOrEmpty(str))
                    str = "Targets";
                PowerScaler.Visible = true;
                PowerScaler.BeginUpdate();
                PowerScaler.ForcedMax = pBase.VariableMax;
                PowerScaler.Clear();
                PowerScaler.AddItem(str + ":|" + Conversions.ToString(MidsContext.Character.CurrentBuild.Powers[HistoryIDX].VariableValue), MidsContext.Character.CurrentBuild.Powers[HistoryIDX].VariableValue, 0.0f, "Use this slider to vary the power's effect.\r\nMin: " + Conversions.ToString(pBase.VariableMin) + "\r\nMax: " + Conversions.ToString(pBase.VariableMax));
                PowerScaler.EndUpdate();
            }
            else
                PowerScaler.Visible = false;
        }

        public void SetScreenBounds(Rectangle iBounds) => ScreenBounds = iBounds;

        public void SetSetPicker(int iSet)
        {
            if (iSet < 0)
            {
                info_Title.Text = "No Enhancement";
                info_txtLarge.Text = string.Empty;
                info_txtSmall.Text = string.Empty;
            }
            else
            {
                info_Title.Text = DatabaseAPI.Database.EnhancementSets[iSet].DisplayName;
                string str1 = DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[iSet].SetType];
                if (!Compact)
                    str1 += RTF.Crlf();
                string str2 = DatabaseAPI.Database.EnhancementSets[iSet].LevelMin != DatabaseAPI.Database.EnhancementSets[iSet].LevelMax ? Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1) + " to " + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMax + 1) : Conversions.ToString(DatabaseAPI.Database.EnhancementSets[iSet].LevelMin + 1);
                info_txtSmall.Rtf = RTF.StartRTF() + (str1 + RTF.Color(RTF.ElementID.Invention) + "Level: " + str2 + RTF.Color(RTF.ElementID.Text)) + RTF.EndRTF();
                info_txtLarge.Rtf = RTF.StartRTF() + EnhancementSetCollection.GetSetInfoLongRTF(iSet) + RTF.EndRTF();
            }
        }

        bool sFXCheck(Enums.ShortFX isFX)
        {
            if (isFX.Index != null)
            {
                int num = isFX.Index.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (pBase.Effects.Length > isFX.Index[index] & isFX.Index[index] > -1 && pBase.Effects[isFX.Index[index]].isEnhancementEffect)
                        return true;
                }
            }
            return false;
        }

        string ShortStr(string full, string brief)
        {
            return (double)info_DataList.Font.Size <= (double)(68f / (float)full.Length) ? full : brief;
        }

        void SizeRefresh()
        {
            if (Compact)
                CompactSize();
            else
                ResetSize();
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
                Enums.ShortFX[] shortFxArray1 = Power.SplitFX(ref BaseSFX, ref pBase);
                Enums.ShortFX[] shortFxArray2 = Power.SplitFX(ref EnhSFX, ref pEnh);
                int num1 = shortFxArray1.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (shortFxArray1[index].Present)
                    {
                        string Suffix = string.Empty;
                        float num2 = shortFxArray1[index].Value[0];
                        float num3 = index < shortFxArray2.Length ? shortFxArray2[index].Value[0] : shortFxArray2[index - 1].Value[0];
                        if (pEnh.Effects[shortFxArray1[index].Index[0]].DisplayPercentage)
                        {
                            Suffix = "%";
                            IEffect effect = pEnh.Effects[shortFxArray1[index].Index[0]];
                            if ((effect.EffectType == Enums.eEffectType.Heal | effect.EffectType == Enums.eEffectType.Endurance | effect.EffectType == Enums.eEffectType.Damage) & pEnh.Effects[shortFxArray1[index].Index[0]].Aspect == Enums.eAspect.Cur)
                            {
                                num2 *= 100f;
                                num3 *= 100f;
                            }
                        }
                        else
                        {
                            switch (pEnh.Effects[shortFxArray1[index].Index[0]].EffectType)
                            {
                                case Enums.eEffectType.Heal:
                                    Suffix = " HP";
                                    break;
                                case Enums.eEffectType.HitPoints:
                                    Suffix = " HP";
                                    break;
                            }
                        }
                        string Title = Enums.GetEffectNameShort(pEnh.Effects[shortFxArray1[index].Index[0]].EffectType);
                        if (SpecialTitle != string.Empty)
                            Title = SpecialTitle;
                        float s1 = num2;
                        float s2 = num3;
                        if ((pEnh.Effects[shortFxArray1[index].Index[0]].Suppression & MidsContext.Config.Suppression) != Enums.eSuppress.None)
                        {
                            s1 = 0.0f;
                            s2 = 0.0f;
                        }
                        iList.AddItem(FastItem(Title, s1, s2, Suffix, false, false, pEnh.Effects[shortFxArray1[index].Index[0]].Probability < 1.0, pEnh.Effects[shortFxArray1[index].Index[0]].SpecialCase != Enums.eSpecialCase.None, Power.SplitFXGroupTip(ref shortFxArray1[index], ref pEnh, false)));
                        if (pEnh.Effects[shortFxArray1[index].Index[0]].isEnhancementEffect)
                            iList.SetUnique();
                    }
                }
                flag = true;
            }
            return flag;
        }

        void Title_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || MoveDisable)
                return;
            Point point1 = new Point(e.X, e.Y);
            point1.Offset(mouse_offset.X, mouse_offset.Y);
            Point point2 = new Point();
            ref Point local = ref point2;
            Point location = Location;
            int x = location.X + point1.X;
            location = Location;
            int y = location.Y + point1.Y;
            local = new Point(x, y);
            if (point2.X - 10 < SnapLocation.X)
                point2.X = SnapLocation.X;
            if (point2.X + Width + 10 > ScreenBounds.Right & point2.X + Width - 20 < ScreenBounds.Right)
                point2.X = ScreenBounds.Right;
            if (point2.Y + 10 > SnapLocation.Y & point2.Y - 20 <= SnapLocation.Y)
                point2.Y = SnapLocation.Y;
            if (point2.Y < ScreenBounds.Top)
                point2.Y = ScreenBounds.Top;
            if (point2.Y + info_Title.Bottom + pnlInfo.Top > ScreenBounds.Bottom)
                point2.Y = ScreenBounds.Bottom - (pnlInfo.Top + info_Title.Bottom);
            if (point2.X + Width > ScreenBounds.Right)
                point2.X = ScreenBounds.Right - Width;
            if (Location != point2)
            {
                Location = point2;
                MovedEventHandler moved = Moved;
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
