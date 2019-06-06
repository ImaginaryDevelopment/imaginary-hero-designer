using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    // Token: 0x02000020 RID: 32
    public partial class frmAccolade : Form
    {
        // Token: 0x17000065 RID: 101
        // (get) Token: 0x060001BB RID: 443 RVA: 0x00022138 File Offset: 0x00020338
        // (set) Token: 0x060001BC RID: 444 RVA: 0x00022150 File Offset: 0x00020350
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

        // Token: 0x17000066 RID: 102
        // (get) Token: 0x060001BD RID: 445 RVA: 0x000221AC File Offset: 0x000203AC
        // (set) Token: 0x060001BE RID: 446 RVA: 0x000221C4 File Offset: 0x000203C4
        internal virtual Label lblLock
        {
            get
            {
                return this._lblLock;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lblLock_Click);
                if (this._lblLock != null)
                {
                    this._lblLock.Click -= eventHandler;
                }
                this._lblLock = value;
                if (this._lblLock != null)
                {
                    this._lblLock.Click += eventHandler;
                }
            }
        }

        // Token: 0x17000067 RID: 103
        // (get) Token: 0x060001BF RID: 447 RVA: 0x00022220 File Offset: 0x00020420
        // (set) Token: 0x060001C0 RID: 448 RVA: 0x00022238 File Offset: 0x00020438
        internal virtual ListLabelV2 llLeft
        {
            get
            {
                return this._llLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.llLeft_MouseEnter);
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llLeft_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llLeft_ItemClick);
                if (this._llLeft != null)
                {
                    this._llLeft.MouseEnter -= eventHandler;
                    this._llLeft.ItemHover -= hoverEventHandler;
                    this._llLeft.ItemClick -= clickEventHandler;
                }
                this._llLeft = value;
                if (this._llLeft != null)
                {
                    this._llLeft.MouseEnter += eventHandler;
                    this._llLeft.ItemHover += hoverEventHandler;
                    this._llLeft.ItemClick += clickEventHandler;
                }
            }
        }

        // Token: 0x17000068 RID: 104
        // (get) Token: 0x060001C1 RID: 449 RVA: 0x000222E0 File Offset: 0x000204E0
        // (set) Token: 0x060001C2 RID: 450 RVA: 0x000222F8 File Offset: 0x000204F8
        internal virtual ListLabelV2 llRight
        {
            get
            {
                return this._llRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llRight_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llRight_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llRight_MouseEnter);
                if (this._llRight != null)
                {
                    this._llRight.ItemHover -= hoverEventHandler;
                    this._llRight.ItemClick -= clickEventHandler;
                    this._llRight.MouseEnter -= eventHandler;
                }
                this._llRight = value;
                if (this._llRight != null)
                {
                    this._llRight.ItemHover += hoverEventHandler;
                    this._llRight.ItemClick += clickEventHandler;
                    this._llRight.MouseEnter += eventHandler;
                }
            }
        }

        // Token: 0x17000069 RID: 105
        // (get) Token: 0x060001C3 RID: 451 RVA: 0x000223A0 File Offset: 0x000205A0
        // (set) Token: 0x060001C4 RID: 452 RVA: 0x000223B8 File Offset: 0x000205B8
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

        // Token: 0x1700006A RID: 106
        // (get) Token: 0x060001C5 RID: 453 RVA: 0x000223C4 File Offset: 0x000205C4
        // (set) Token: 0x060001C6 RID: 454 RVA: 0x000223DC File Offset: 0x000205DC
        internal virtual ctlPopUp PopInfo
        {
            get
            {
                return this._PopInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.PopInfo_MouseWheel);
                EventHandler eventHandler = new EventHandler(this.PopInfo_MouseEnter);
                if (this._PopInfo != null)
                {
                    this._PopInfo.MouseWheel -= mouseEventHandler;
                    this._PopInfo.MouseEnter -= eventHandler;
                }
                this._PopInfo = value;
                if (this._PopInfo != null)
                {
                    this._PopInfo.MouseWheel += mouseEventHandler;
                    this._PopInfo.MouseEnter += eventHandler;
                }
            }
        }

        // Token: 0x1700006B RID: 107
        // (get) Token: 0x060001C7 RID: 455 RVA: 0x00022460 File Offset: 0x00020660
        // (set) Token: 0x060001C8 RID: 456 RVA: 0x00022478 File Offset: 0x00020678
        internal virtual VScrollBar VScrollBar1
        {
            get
            {
                return this._VScrollBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ScrollEventHandler scrollEventHandler = new ScrollEventHandler(this.VScrollBar1_Scroll);
                if (this._VScrollBar1 != null)
                {
                    this._VScrollBar1.Scroll -= scrollEventHandler;
                }
                this._VScrollBar1 = value;
                if (this._VScrollBar1 != null)
                {
                    this._VScrollBar1.Scroll += scrollEventHandler;
                }
            }
        }

        // Token: 0x060001C9 RID: 457 RVA: 0x000224D2 File Offset: 0x000206D2
        public frmAccolade(ref frmMain iParent, List<IPower> iPowers)
        {
            base.Load += this.frmAccolade_Load;
            this._locked = false;
            this.InitializeComponent();
            this._myParent = iParent;
            this._myPowers = iPowers;
        }

        // Token: 0x060001CA RID: 458 RVA: 0x00022510 File Offset: 0x00020710
        private void ChangedScrollFrameContents()
        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round((double)this.PopInfo.lHeight * ((double)this.VScrollBar1.LargeChange / (double)this.Panel1.Height));
            this.VScrollBar1_Scroll(this.VScrollBar1, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        // Token: 0x060001CC RID: 460 RVA: 0x000225C8 File Offset: 0x000207C8
        private void FillLists()
        {
            this.llLeft.SuspendRedraw = true;
            this.llRight.SuspendRedraw = true;
            this.llLeft.ClearItems();
            this.llRight.ClearItems();
            int num = this._myPowers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                ListLabelV2.LLItemState iState;
                if (MidsContext.Character.CurrentBuild.PowerUsed(this._myPowers[index]))
                {
                    iState = ListLabelV2.LLItemState.Selected;
                }
                else if (this._myPowers[index].PowerType != Enums.ePowerType.Click | this._myPowers[index].ClickBuff)
                {
                    iState = ListLabelV2.LLItemState.Enabled;
                }
                else if (this._myPowers[index].SubIsAltColour)
                {
                    iState = ListLabelV2.LLItemState.Invalid;
                }
                else
                {
                    iState = ListLabelV2.LLItemState.Disabled;
                }
                ListLabelV2.ListLabelItemV2 iItem;
                if (MidsContext.Config.RtFont.PairedBold)
                {
                    iItem = new ListLabelV2.ListLabelItemV2(this._myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left);
                }
                else
                {
                    iItem = new ListLabelV2.ListLabelItemV2(this._myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left);
                }
                if ((double)index >= (double)this._myPowers.Count / 2.0)
                {
                    this.llRight.AddItem(iItem);
                }
                else
                {
                    this.llLeft.AddItem(iItem);
                }
            }
            this.llLeft.SuspendRedraw = false;
            this.llRight.SuspendRedraw = false;
            this.llLeft.Refresh();
            this.llRight.Refresh();
        }

        // Token: 0x060001CD RID: 461 RVA: 0x00022790 File Offset: 0x00020990
        private void frmAccolade_Load(object sender, EventArgs e)
        {
            this.BackColor = this._myParent.BackColor;
            this.PopInfo.ForeColor = this.BackColor;
            ListLabelV2 llRight = this.llLeft;
            frmAccolade.UpdateLlColours(ref llRight);
            this.llLeft = llRight;
            llRight = this.llRight;
            frmAccolade.UpdateLlColours(ref llRight);
            this.llRight = llRight;
            this.ibClose.IA = this._myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this._myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this._myParent.Drawing.bxPower[3].Bitmap;
            PopUp.PopupData iPopup = default(PopUp.PopupData);
            int index = iPopup.Add(null);
            iPopup.Sections[index].Add("Click powers to enable/disable them.", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            iPopup.Sections[index].Add("Powers in gray (or your custom 'power disabled' color) cannot be included in your stats.", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
            this.PopInfo.SetPopup(iPopup);
            this.ChangedScrollFrameContents();
            this.FillLists();
        }

        // Token: 0x060001CE RID: 462 RVA: 0x000228BE File Offset: 0x00020ABE
        private void ibClose_ButtonClicked()
        {
            base.Close();
        }

        // Token: 0x060001D0 RID: 464 RVA: 0x00023109 File Offset: 0x00021309
        private void lblLock_Click(object sender, EventArgs e)
        {
            this._locked = false;
            this.lblLock.Visible = false;
        }

        // Token: 0x060001D1 RID: 465 RVA: 0x00023120 File Offset: 0x00021320
        private void llLeft_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Right)
            {
                this._locked = false;
                this.MiniPowerInfo(Item.Index);
                this.lblLock.Visible = true;
                this._locked = true;
            }
            else if (Item.ItemState != ListLabelV2.LLItemState.Disabled)
            {
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

        // Token: 0x060001D2 RID: 466 RVA: 0x0002321B File Offset: 0x0002141B
        private void llLeft_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.MiniPowerInfo(Item.Index);
        }

        // Token: 0x060001D3 RID: 467 RVA: 0x0002322C File Offset: 0x0002142C
        private void llLeft_MouseEnter(object sender, EventArgs e)
        {
            if (base.ContainsFocus)
            {
                this.Panel2.Focus();
            }
        }

        // Token: 0x060001D4 RID: 468 RVA: 0x00023258 File Offset: 0x00021458
        private void llRight_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            int pIDX = Item.Index + this.llLeft.Items.Length;
            if (Button == MouseButtons.Right)
            {
                this._locked = false;
                this.MiniPowerInfo(pIDX);
                this.lblLock.Visible = true;
                this._locked = true;
            }
            else if (Item.ItemState != ListLabelV2.LLItemState.Disabled)
            {
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

        // Token: 0x060001D5 RID: 469 RVA: 0x00023354 File Offset: 0x00021554
        private void llRight_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            int pIDX = Item.Index + this.llLeft.Items.Length;
            this.MiniPowerInfo(pIDX);
        }

        // Token: 0x060001D6 RID: 470 RVA: 0x0002337F File Offset: 0x0002157F
        private void llRight_MouseEnter(object sender, EventArgs e)
        {
            this.llLeft_MouseEnter(RuntimeHelpers.GetObjectValue(sender), e);
        }

        // Token: 0x060001D7 RID: 471 RVA: 0x00023390 File Offset: 0x00021590
        private void MiniPowerInfo(int pIDX)
        {
            if (!this._locked)
            {
                IPower power = new Power(this._myPowers[pIDX]);
                PopUp.PopupData iPopup = default(PopUp.PopupData);
                if (pIDX < 0)
                {
                    this.PopInfo.SetPopup(iPopup);
                    this.ChangedScrollFrameContents();
                }
                else
                {
                    int index4 = iPopup.Add(null);
                    string str = string.Empty;
                    switch (power.PowerType)
                    {
                        case Enums.ePowerType.Click:
                            if (power.ClickBuff)
                            {
                                str = "(Click)";
                            }
                            break;
                        case Enums.ePowerType.Auto_:
                            str = "(Auto)";
                            break;
                        case Enums.ePowerType.Toggle:
                            str = "(Toggle)";
                            break;
                    }
                    iPopup.Sections[index4].Add(power.DisplayName, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    iPopup.Sections[index4].Add(str + " " + power.DescShort, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
                    index4 = iPopup.Add(null);
                    if (power.EndCost > 0f)
                    {
                        if (power.ActivatePeriod > 0f)
                        {
                            iPopup.Sections[index4].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power.EndCost / power.ActivatePeriod) + "/s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                        }
                        else
                        {
                            iPopup.Sections[index4].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power.EndCost), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                        }
                    }
                    if (power.EntitiesAutoHit == Enums.eEntity.None | (power.Range > 20f & power.I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt)))
                    {
                        iPopup.Sections[index4].Add("Accuracy:", PopUp.Colors.Title, Utilities.FixDP(MidsContext.Config.BaseAcc * power.Accuracy * 100f) + "%", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    if (power.RechargeTime > 0f)
                    {
                        iPopup.Sections[index4].Add("Recharge:", PopUp.Colors.Title, Utilities.FixDP(power.RechargeTime) + "s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    int durationEffectId = power.GetDurationEffectID();
                    float iNum = 0f;
                    if (durationEffectId > -1)
                    {
                        iNum = power.Effects[durationEffectId].Duration;
                    }
                    if ((power.PowerType != Enums.ePowerType.Toggle & power.PowerType != Enums.ePowerType.Auto_) && iNum > 0f)
                    {
                        iPopup.Sections[index4].Add("Duration:", PopUp.Colors.Title, Utilities.FixDP(iNum) + "s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    if (power.Range > 0f)
                    {
                        iPopup.Sections[index4].Add("Range:", PopUp.Colors.Title, Utilities.FixDP(power.Range) + "ft", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    if (power.Arc > 0)
                    {
                        iPopup.Sections[index4].Add("Arc:", PopUp.Colors.Title, Conversions.ToString(power.Arc) + "°", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    else if (power.Radius > 0f)
                    {
                        iPopup.Sections[index4].Add("Radius:", PopUp.Colors.Title, Conversions.ToString(power.Radius) + "ft", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    if (power.CastTime > 0f)
                    {
                        iPopup.Sections[index4].Add("Cast Time:", PopUp.Colors.Title, Utilities.FixDP(power.CastTime) + "s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    }
                    IPower power2 = power;
                    if (power2.Effects.Length > 0)
                    {
                        iPopup.Sections[index4].Add("Effects:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        char[] chArray = new char[]
                        {
                            '^'
                        };
                        int num = power2.Effects.Length - 1;
                        for (int index5 = 0; index5 <= num; index5++)
                        {
                            index4 = iPopup.Add(null);
                            power.Effects[index5].Power = power;
                            string[] strArray = power.Effects[index5].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", string.Empty).Replace("]", string.Empty).Split(chArray);
                            int num2 = strArray.Length - 1;
                            for (int index6 = 0; index6 <= num2; index6++)
                            {
                                if (index6 == 0)
                                {
                                    iPopup.Sections[index4].Add(strArray[index6], PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                                }
                                else
                                {
                                    iPopup.Sections[index4].Add(strArray[index6], PopUp.Colors.Disabled, 0.9f, FontStyle.Italic, 2);
                                }
                            }
                        }
                    }
                    this.PopInfo.SetPopup(iPopup);
                    this.ChangedScrollFrameContents();
                }
            }
        }

        // Token: 0x060001D8 RID: 472 RVA: 0x00023970 File Offset: 0x00021B70
        private void PopInfo_MouseEnter(object sender, EventArgs e)
        {
            if (base.ContainsFocus)
            {
                this.VScrollBar1.Focus();
            }
        }

        // Token: 0x060001D9 RID: 473 RVA: 0x0002399C File Offset: 0x00021B9C
        private void PopInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject(this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, -1, 1)));
            if (this.VScrollBar1.Value > this.VScrollBar1.Maximum - 9)
            {
                this.VScrollBar1.Value = this.VScrollBar1.Maximum - 9;
            }
            this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        // Token: 0x060001DA RID: 474 RVA: 0x00023A3C File Offset: 0x00021C3C
        private static void UpdateLlColours(ref ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            iList.Font = new Font(iList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
        }

        // Token: 0x060001DB RID: 475 RVA: 0x00023B00 File Offset: 0x00021D00
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.PopInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * (double)(this.PopInfo.lHeight - (float)this.Panel1.Height));
        }

        // Token: 0x040000BD RID: 189
        [AccessedThroughProperty("ibClose")]
        private ImageButton _ibClose;

        // Token: 0x040000BE RID: 190
        [AccessedThroughProperty("lblLock")]
        private Label _lblLock;

        // Token: 0x040000BF RID: 191
        [AccessedThroughProperty("llLeft")]
        private ListLabelV2 _llLeft;

        // Token: 0x040000C0 RID: 192
        [AccessedThroughProperty("llRight")]
        private ListLabelV2 _llRight;

        // Token: 0x040000C1 RID: 193
        private bool _locked;

        // Token: 0x040000C2 RID: 194
        private readonly frmMain _myParent;

        // Token: 0x040000C3 RID: 195
        private readonly List<IPower> _myPowers;

        // Token: 0x040000C4 RID: 196
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;

        // Token: 0x040000C5 RID: 197
        [AccessedThroughProperty("PopInfo")]
        private ctlPopUp _PopInfo;

        // Token: 0x040000C6 RID: 198
        [AccessedThroughProperty("VScrollBar1")]
        private VScrollBar _VScrollBar1;
    }
}
