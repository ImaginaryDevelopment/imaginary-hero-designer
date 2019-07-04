using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmAccolade : Form
    {
        ImageButton ibClose;

        Label lblLock;
        ListLabelV2 llLeft;
        ListLabelV2 llRight;

        bool _locked;

        readonly frmMain _myParent;

        readonly List<IPower> _myPowers;
        Panel Panel1;

        ctlPopUp PopInfo;

        VScrollBar VScrollBar1;

        internal frmIncarnate.CustomPanel Panel2;
        internal ListLabelV2 LLLeft
        {
            get => llLeft;
            private set => llLeft = value;
        }
        internal ListLabelV2 LLRight
        {
            get => llRight;
            private set => llRight = value;
        }

        public frmAccolade(frmMain iParent, List<IPower> iPowers)
        {
            this.Load += new EventHandler(this.frmAccolade_Load);
            this._locked = false;
            this.InitializeComponent();
            var componentResourceManager = new ComponentResourceManager(typeof(frmAccolade));
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmAccolade);
            this._myParent = iParent;
            this._myPowers = iPowers;
        }

        void ChangedScrollFrameContents()
        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round(PopInfo.lHeight * (VScrollBar1.LargeChange / (double)this.Panel1.Height));
            this.VScrollBar1_Scroll(this.VScrollBar1, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        void FillLists()
        {
            this.llLeft.SuspendRedraw = true;
            this.llRight.SuspendRedraw = true;
            this.llLeft.ClearItems();
            this.llRight.ClearItems();
            int num = this._myPowers.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                ListLabelV2.LLItemState iState = !MidsContext.Character.CurrentBuild.PowerUsed(this._myPowers[index]) ? (!(this._myPowers[index].PowerType != Enums.ePowerType.Click | this._myPowers[index].ClickBuff) ? (!this._myPowers[index].SubIsAltColour ? ListLabelV2.LLItemState.Disabled : ListLabelV2.LLItemState.Invalid) : ListLabelV2.LLItemState.Enabled) : ListLabelV2.LLItemState.Selected;
                ListLabelV2.ListLabelItemV2 iItem = !MidsContext.Config.RtFont.PairedBold ? new ListLabelV2.ListLabelItemV2(this._myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left) : new ListLabelV2.ListLabelItemV2(this._myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left);
                if (index >= _myPowers.Count / 2.0)
                    this.llRight.AddItem(iItem);
                else
                    this.llLeft.AddItem(iItem);
            }
            this.llLeft.SuspendRedraw = false;
            this.llRight.SuspendRedraw = false;
            this.llLeft.Refresh();
            this.llRight.Refresh();
        }

        void frmAccolade_Load(object sender, EventArgs e)
        {
            this.BackColor = this._myParent.BackColor;
            this.PopInfo.ForeColor = this.BackColor;
            ListLabelV2 llLeft = this.llLeft;
            frmAccolade.UpdateLlColours(ref llLeft);
            this.llLeft = llLeft;
            ListLabelV2 llRight = this.llRight;
            frmAccolade.UpdateLlColours(ref llRight);
            this.llRight = llRight;
            this.ibClose.IA = this._myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this._myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this._myParent.Drawing.bxPower[3].Bitmap;
            PopUp.PopupData iPopup = new PopUp.PopupData();
            int index = iPopup.Add(null);
            iPopup.Sections[index].Add("Click powers to enable/disable them.", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
            iPopup.Sections[index].Add("Powers in gray (or your custom 'power disabled' color) cannot be included in your stats.", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 0);
            this.PopInfo.SetPopup(iPopup);
            this.ChangedScrollFrameContents();
            this.FillLists();
        }

        void ibClose_ButtonClicked()
        {
            this.Close();
        }

        void lblLock_Click(object sender, EventArgs e)
        {
            this._locked = false;
            this.lblLock.Visible = false;
        }

        void llLeft_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Right)
            {
                this._locked = false;
                this.MiniPowerInfo(Item.Index);
                this.lblLock.Visible = true;
                this._locked = true;
            }
            else
            {
                if (Item.ItemState == ListLabelV2.LLItemState.Disabled)
                    return;
                if (MidsContext.Character.CurrentBuild.PowerUsed(this._myPowers[Item.Index]))
                {
                    MidsContext.Character.CurrentBuild.RemovePower(this._myPowers[Item.Index]);
                    Item.ItemState = ListLabelV2.LLItemState.Enabled;
                }
                else
                {
                    MidsContext.Character.CurrentBuild.AddPower(this._myPowers[Item.Index], -1).StatInclude = true;
                    Item.ItemState = ListLabelV2.LLItemState.Selected;
                }
                this.llLeft.Refresh();
                this._myParent.PowerModified();
            }
        }

        void llLeft_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.MiniPowerInfo(Item.Index);
        }

        void llLeft_MouseEnter(object sender, EventArgs e)
        {
            if (!this.ContainsFocus)
                return;
            this.Panel2.Focus();
        }

        void llRight_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            int pIDX = Item.Index + this.llLeft.Items.Length;
            if (Button == MouseButtons.Right)
            {
                this._locked = false;
                this.MiniPowerInfo(pIDX);
                this.lblLock.Visible = true;
                this._locked = true;
            }
            else
            {
                if (Item.ItemState == ListLabelV2.LLItemState.Disabled)
                    return;
                if (MidsContext.Character.CurrentBuild.PowerUsed(this._myPowers[pIDX]))
                {
                    MidsContext.Character.CurrentBuild.RemovePower(this._myPowers[pIDX]);
                    Item.ItemState = ListLabelV2.LLItemState.Enabled;
                }
                else
                {
                    MidsContext.Character.CurrentBuild.AddPower(this._myPowers[pIDX], -1).StatInclude = true;
                    Item.ItemState = ListLabelV2.LLItemState.Selected;
                }
                this.llRight.Refresh();
                this._myParent.PowerModified();
            }
        }

        void llRight_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.MiniPowerInfo(Item.Index + this.llLeft.Items.Length);
        }

        void llRight_MouseEnter(object sender, EventArgs e)
        {
            this.llLeft_MouseEnter(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void MiniPowerInfo(int pIDX)
        {
            if (this._locked)
                return;
            IPower power1 = new Power(this._myPowers[pIDX]);
            PopUp.PopupData iPopup = new PopUp.PopupData();
            if (pIDX < 0)
            {
                this.PopInfo.SetPopup(iPopup);
                this.ChangedScrollFrameContents();
            }
            else
            {
                int index1 = iPopup.Add(null);
                string str = string.Empty;
                switch (power1.PowerType)
                {
                    case Enums.ePowerType.Click:
                        if (power1.ClickBuff)
                        {
                            str = "(Click)";
                            break;
                        }
                        break;
                    case Enums.ePowerType.Auto_:
                        str = "(Auto)";
                        break;
                    case Enums.ePowerType.Toggle:
                        str = "(Toggle)";
                        break;
                }
                iPopup.Sections[index1].Add(power1.DisplayName, PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                iPopup.Sections[index1].Add(str + " " + power1.DescShort, PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 0);
                int index2 = iPopup.Add(null);
                if (power1.EndCost > 0.0)
                {
                    if (power1.ActivatePeriod > 0.0)
                        iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power1.EndCost / power1.ActivatePeriod) + "/s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                    else
                        iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power1.EndCost), PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                }
                if (power1.EntitiesAutoHit == Enums.eEntity.None | power1.Range > 20.0 & power1.I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt))
                    iPopup.Sections[index2].Add("Accuracy:", PopUp.Colors.Title, Utilities.FixDP((float)(MidsContext.Config.BaseAcc * (double)power1.Accuracy * 100.0)) + "%", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.RechargeTime > 0.0)
                    iPopup.Sections[index2].Add("Recharge:", PopUp.Colors.Title, Utilities.FixDP(power1.RechargeTime) + "s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                int durationEffectId = power1.GetDurationEffectID();
                float iNum = 0.0f;
                if (durationEffectId > -1)
                    iNum = power1.Effects[durationEffectId].Duration;
                if (power1.PowerType != Enums.ePowerType.Toggle & power1.PowerType != Enums.ePowerType.Auto_ && iNum > 0.0)
                    iPopup.Sections[index2].Add("Duration:", PopUp.Colors.Title, Utilities.FixDP(iNum) + "s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.Range > 0.0)
                    iPopup.Sections[index2].Add("Range:", PopUp.Colors.Title, Utilities.FixDP(power1.Range) + "ft", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.Arc > 0)
                    iPopup.Sections[index2].Add("Arc:", PopUp.Colors.Title, Conversions.ToString(power1.Arc) + "°", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                else if (power1.Radius > 0.0)
                    iPopup.Sections[index2].Add("Radius:", PopUp.Colors.Title, Conversions.ToString(power1.Radius) + "ft", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.CastTime > 0.0)
                    iPopup.Sections[index2].Add("Cast Time:", PopUp.Colors.Title, Utilities.FixDP(power1.CastTime) + "s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                IPower power2 = power1;
                if (power2.Effects.Length > 0)
                {
                    iPopup.Sections[index2].Add("Effects:", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    char[] chArray = new char[1] { '^' };
                    int num1 = power2.Effects.Length - 1;
                    for (int index3 = 0; index3 <= num1; ++index3)
                    {
                        int index4 = iPopup.Add(null);
                        power1.Effects[index3].SetPower(power1);
                        string[] strArray = power1.Effects[index3].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", string.Empty).Replace("]", string.Empty).Split(chArray);
                        int num2 = strArray.Length - 1;
                        for (int index5 = 0; index5 <= num2; ++index5)
                        {
                            if (index5 == 0)
                                iPopup.Sections[index4].Add(strArray[index5], PopUp.Colors.Effect, 0.9f, System.Drawing.FontStyle.Bold, 1);
                            else
                                iPopup.Sections[index4].Add(strArray[index5], PopUp.Colors.Disabled, 0.9f, System.Drawing.FontStyle.Italic, 2);
                        }
                    }
                }
                this.PopInfo.SetPopup(iPopup);
                this.ChangedScrollFrameContents();
            }
        }

        void PopInfo_MouseEnter(object sender, EventArgs e)
        {
            if (!this.ContainsFocus)
                return;
            this.VScrollBar1.Focus();
        }

        void PopInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject(this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, -1, 1)));
            if (this.VScrollBar1.Value > this.VScrollBar1.Maximum - 9)
                this.VScrollBar1.Value = this.VScrollBar1.Maximum - 9;
            this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        static void UpdateLlColours(ref ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            iList.Font = new System.Drawing.Font(iList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.PopInfo.ScrollY = (float)(VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * (PopInfo.lHeight - (double)this.Panel1.Height));
        }
    }
}