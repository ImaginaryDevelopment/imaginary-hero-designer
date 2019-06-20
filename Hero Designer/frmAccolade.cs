
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
    [DesignerGenerated]
    public class frmAccolade : Form
    {
        [AccessedThroughProperty("ibClose")]
        ImageButton _ibClose;

        [AccessedThroughProperty("lblLock")]
        Label _lblLock;

        [AccessedThroughProperty("llLeft")]
        ListLabelV2 _llLeft;

        [AccessedThroughProperty("llRight")]
        ListLabelV2 _llRight;

        bool _locked;

        readonly frmMain _myParent;

        readonly List<IPower> _myPowers;

        [AccessedThroughProperty("Panel1")]
        Panel _Panel1;

        [AccessedThroughProperty("PopInfo")]
        ctlPopUp _PopInfo;

        [AccessedThroughProperty("VScrollBar1")]
        VScrollBar _VScrollBar1;

        IContainer components;

        internal frmIncarnate.CustomPanel Panel2;

        ImageButton ibClose
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
                    this._ibClose.ButtonClicked -= clickedEventHandler;
                this._ibClose = value;
                if (this._ibClose == null)
                    return;
                this._ibClose.ButtonClicked += clickedEventHandler;
            }
        }

        Label lblLock
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
                    this._lblLock.Click -= eventHandler;
                this._lblLock = value;
                if (this._lblLock == null)
                    return;
                this._lblLock.Click += eventHandler;
            }
        }

        internal ListLabelV2 llLeft
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
                if (this._llLeft == null)
                    return;
                this._llLeft.MouseEnter += eventHandler;
                this._llLeft.ItemHover += hoverEventHandler;
                this._llLeft.ItemClick += clickEventHandler;
            }
        }

        internal ListLabelV2 llRight
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
                if (this._llRight == null)
                    return;
                this._llRight.ItemHover += hoverEventHandler;
                this._llRight.ItemClick += clickEventHandler;
                this._llRight.MouseEnter += eventHandler;
            }
        }

        Panel Panel1
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

        ctlPopUp PopInfo
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
                if (this._PopInfo == null)
                    return;
                this._PopInfo.MouseWheel += mouseEventHandler;
                this._PopInfo.MouseEnter += eventHandler;
            }
        }

        VScrollBar VScrollBar1
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
                    this._VScrollBar1.Scroll -= scrollEventHandler;
                this._VScrollBar1 = value;
                if (this._VScrollBar1 == null)
                    return;
                this._VScrollBar1.Scroll += scrollEventHandler;
            }
        }

        public frmAccolade(ref frmMain iParent, List<IPower> iPowers)
        {
            this.Load += new EventHandler(this.frmAccolade_Load);
            this._locked = false;
            this.InitializeComponent();
            this._myParent = iParent;
            this._myPowers = iPowers;
        }

        void ChangedScrollFrameContents()

        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round((double)this.PopInfo.lHeight * ((double)this.VScrollBar1.LargeChange / (double)this.Panel1.Height));
            this.VScrollBar1_Scroll((object)this.VScrollBar1, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || this.components == null)
                    return;
                this.components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
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
                if ((double)index >= (double)this._myPowers.Count / 2.0)
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
            int index = iPopup.Add((PopUp.Section)null);
            iPopup.Sections[index].Add("Click powers to enable/disable them.", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            iPopup.Sections[index].Add("Powers in gray (or your custom 'power disabled' color) cannot be included in your stats.", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
            this.PopInfo.SetPopup(iPopup);
            this.ChangedScrollFrameContents();
            this.FillLists();
        }

        void ibClose_ButtonClicked()

        {
            this.Close();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAccolade));
            this.Panel1 = new Panel();
            this.VScrollBar1 = new VScrollBar();
            this.PopInfo = new ctlPopUp();
            this.lblLock = new Label();
            this.ibClose = new ImageButton();
            this.Panel2 = new frmIncarnate.CustomPanel();
            this.llRight = new ListLabelV2();
            this.llLeft = new ListLabelV2();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            this.Panel1.BorderStyle = BorderStyle.Fixed3D;
            this.Panel1.Controls.Add((Control)this.VScrollBar1);
            this.Panel1.Controls.Add((Control)this.PopInfo);
            Point point = new Point(12, 174);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            Size size = new Size(414, 189);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 35;
            point = new Point(393, 0);
            this.VScrollBar1.Location = point;
            this.VScrollBar1.Name = "VScrollBar1";
            size = new Size(17, 185);
            this.VScrollBar1.Size = size;
            this.VScrollBar1.TabIndex = 11;
            this.PopInfo.BXHeight = 1024;
            this.PopInfo.ColumnPosition = 0.5f;
            this.PopInfo.ColumnRight = false;
            this.PopInfo.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.PopInfo.ForeColor = Color.FromArgb(0, 0, 32);
            this.PopInfo.InternalPadding = 3;
            point = new Point(0, 0);
            this.PopInfo.Location = point;
            this.PopInfo.Name = "PopInfo";
            this.PopInfo.ScrollY = 0.0f;
            this.PopInfo.SectionPadding = 8;
            size = new Size(391, 200);
            this.PopInfo.Size = size;
            this.PopInfo.TabIndex = 9;
            this.lblLock.BackColor = Color.Red;
            this.lblLock.BorderStyle = BorderStyle.FixedSingle;
            this.lblLock.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            this.lblLock.ForeColor = Color.White;
            point = new Point(12, 155);
            this.lblLock.Location = point;
            this.lblLock.Name = "lblLock";
            size = new Size(56, 16);
            this.lblLock.Size = size;
            this.lblLock.TabIndex = 69;
            this.lblLock.Text = "[Unlock]";
            this.lblLock.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLock.Visible = false;
            this.ibClose.Checked = false;
            this.ibClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibClose.KnockoutLocationPoint = point;
            point = new Point(166, 369);
            this.ibClose.Location = point;
            this.ibClose.Name = "ibClose";
            size = new Size(105, 22);
            this.ibClose.Size = size;
            this.ibClose.TabIndex = 7;
            this.ibClose.TextOff = "Done";
            this.ibClose.TextOn = "Alt Text";
            this.ibClose.Toggle = false;
            this.Panel2.AutoScroll = true;
            this.Panel2.BorderStyle = BorderStyle.Fixed3D;
            this.Panel2.Controls.Add((Control)this.llRight);
            this.Panel2.Controls.Add((Control)this.llLeft);
            point = new Point(12, 12);
            this.Panel2.Location = point;
            this.Panel2.Name = "Panel2";
            size = new Size(414, 140);
            this.Panel2.Size = size;
            this.Panel2.TabIndex = 126;
            this.Panel2.TabStop = true;
            this.llRight.AutoSize = true;
            this.llRight.Expandable = false;
            this.llRight.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.llRight.HighVis = true;
            this.llRight.HoverColor = Color.WhiteSmoke;
            point = new Point(196, 3);
            this.llRight.Location = point;
            this.llRight.MaxHeight = 600;
            this.llRight.Name = "llRight";
            this.llRight.PaddingX = 2;
            this.llRight.PaddingY = 2;
            this.llRight.Scrollable = false;
            this.llRight.ScrollBarColor = Color.Red;
            this.llRight.ScrollBarWidth = 11;
            this.llRight.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            size = new Size(190, 414);
            this.llRight.Size = size;
            size = new Size(190, 120);
            this.llRight.SizeNormal = size;
            this.llRight.SuspendRedraw = false;
            this.llRight.TabIndex = 111;
            this.llLeft.AutoSize = true;
            this.llLeft.Expandable = false;
            this.llLeft.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.llLeft.HighVis = true;
            this.llLeft.HoverColor = Color.WhiteSmoke;
            point = new Point(3, 3);
            this.llLeft.Location = point;
            this.llLeft.MaxHeight = 600;
            this.llLeft.Name = "llLeft";
            this.llLeft.PaddingX = 2;
            this.llLeft.PaddingY = 2;
            this.llLeft.Scrollable = false;
            this.llLeft.ScrollBarColor = Color.Red;
            this.llLeft.ScrollBarWidth = 11;
            this.llLeft.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            size = new Size(187, 414);
            this.llLeft.Size = size;
            size = new Size(187, 120);
            this.llLeft.SizeNormal = size;
            this.llLeft.SuspendRedraw = false;
            this.llLeft.TabIndex = 110;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(0, 0, 32);
            size = new Size(438, 403);
            this.ClientSize = size;
            this.Controls.Add((Control)this.Panel2);
            this.Controls.Add((Control)this.lblLock);
            this.Controls.Add((Control)this.Panel1);
            this.Controls.Add((Control)this.ibClose);
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmAccolade);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Powers";
            this.TopMost = true;
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);
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
            IPower power1 = (IPower)new Power(this._myPowers[pIDX]);
            PopUp.PopupData iPopup = new PopUp.PopupData();
            if (pIDX < 0)
            {
                this.PopInfo.SetPopup(iPopup);
                this.ChangedScrollFrameContents();
            }
            else
            {
                int index1 = iPopup.Add((PopUp.Section)null);
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
                iPopup.Sections[index1].Add(power1.DisplayName, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                iPopup.Sections[index1].Add(str + " " + power1.DescShort, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
                int index2 = iPopup.Add((PopUp.Section)null);
                if ((double)power1.EndCost > 0.0)
                {
                    if ((double)power1.ActivatePeriod > 0.0)
                        iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power1.EndCost / power1.ActivatePeriod) + "/s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                    else
                        iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power1.EndCost), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                }
                if (power1.EntitiesAutoHit == Enums.eEntity.None | (double)power1.Range > 20.0 & power1.I9FXPresentP(Enums.eEffectType.Mez, Enums.eMez.Taunt))
                    iPopup.Sections[index2].Add("Accuracy:", PopUp.Colors.Title, Utilities.FixDP((float)((double)MidsContext.Config.BaseAcc * (double)power1.Accuracy * 100.0)) + "%", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                if ((double)power1.RechargeTime > 0.0)
                    iPopup.Sections[index2].Add("Recharge:", PopUp.Colors.Title, Utilities.FixDP(power1.RechargeTime) + "s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                int durationEffectId = power1.GetDurationEffectID();
                float iNum = 0.0f;
                if (durationEffectId > -1)
                    iNum = power1.Effects[durationEffectId].Duration;
                if (power1.PowerType != Enums.ePowerType.Toggle & power1.PowerType != Enums.ePowerType.Auto_ && (double)iNum > 0.0)
                    iPopup.Sections[index2].Add("Duration:", PopUp.Colors.Title, Utilities.FixDP(iNum) + "s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                if ((double)power1.Range > 0.0)
                    iPopup.Sections[index2].Add("Range:", PopUp.Colors.Title, Utilities.FixDP(power1.Range) + "ft", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                if (power1.Arc > 0)
                    iPopup.Sections[index2].Add("Arc:", PopUp.Colors.Title, Conversions.ToString(power1.Arc) + "°", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                else if ((double)power1.Radius > 0.0)
                    iPopup.Sections[index2].Add("Radius:", PopUp.Colors.Title, Conversions.ToString(power1.Radius) + "ft", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                if ((double)power1.CastTime > 0.0)
                    iPopup.Sections[index2].Add("Cast Time:", PopUp.Colors.Title, Utilities.FixDP(power1.CastTime) + "s", PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                IPower power2 = power1;
                if (power2.Effects.Length > 0)
                {
                    iPopup.Sections[index2].Add("Effects:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    char[] chArray = new char[1] { '^' };
                    int num1 = power2.Effects.Length - 1;
                    for (int index3 = 0; index3 <= num1; ++index3)
                    {
                        int index4 = iPopup.Add((PopUp.Section)null);
                        power1.Effects[index3].Power = power1;
                        string[] strArray = power1.Effects[index3].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", string.Empty).Replace("]", string.Empty).Split(chArray);
                        int num2 = strArray.Length - 1;
                        for (int index5 = 0; index5 <= num2; ++index5)
                        {
                            if (index5 == 0)
                                iPopup.Sections[index4].Add(strArray[index5], PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                            else
                                iPopup.Sections[index4].Add(strArray[index5], PopUp.Colors.Disabled, 0.9f, FontStyle.Italic, 2);
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
            this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject((object)this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, (object)-1, (object)1)));
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
            iList.Font = new Font(iList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)

        {
            this.PopInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * ((double)this.PopInfo.lHeight - (double)this.Panel1.Height));
        }
    }
}
