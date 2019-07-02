
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using HeroDesigner.Schema;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmIncarnate : Form
    {
        ImageButton alphaBtn;

        ImageButton destinyBtn;

        ImageButton GenesisButton;

        ImageButton hybridBtn;

        ImageButton ibClose;

        ImageButton interfaceBtn;

        ImageButton judgementBtn;

        Label lblLock;

        ListLabelV2 _llLeft;

        ListLabelV2 _llRight;

        ImageButton loreBtn;

        ImageButton OmegaButton;
        Panel Panel1;

        ctlPopUp PopInfo;

        ImageButton StanceButton;

        ImageButton VitaeButton;

        VScrollBar VScrollBar1;

        ImageButton[] buttonArray;

        protected bool Locked;
        protected frmMain myParent;
        public IPower[] myPowers;
        internal frmIncarnate.CustomPanel Panel2;
        internal ListLabelV2 llLeft
        {
            get => _llLeft;
            private set => _llLeft = value;
        }
        internal ListLabelV2 llRight
        {
            get => _llRight;
            private set => _llRight = value;
        }
        public frmIncarnate(ref frmMain iParent)
        {
            this.Load += new EventHandler(this.frmIncarnate_Load);
            this.myPowers = new IPower[0];
            this.Locked = false;
            this.buttonArray = new ImageButton[10];
            this.InitializeComponent();
            this.myParent = iParent;
            this.myPowers = DatabaseAPI.GetPowersetByName("Alpha", ePowerSetType.Incarnate).Powers;
        }

        void alphaBtn_ButtonClicked()

        {
            ImageButton alphaBtn = this.alphaBtn;
            this.SetPowerSet("Alpha", ref alphaBtn);
            this.alphaBtn = alphaBtn;
        }

        void ChangedScrollFrameContents()

        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round((double)this.PopInfo.lHeight * ((double)this.VScrollBar1.LargeChange / (double)this.Panel1.Height));
            this.VScrollBar1_Scroll(this.VScrollBar1, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        void destinyBtn_ButtonClicked()

        {
            ImageButton destinyBtn = this.destinyBtn;
            this.SetPowerSet("Destiny", ref destinyBtn);
            this.destinyBtn = destinyBtn;
        }

        public void FillLists()
        {
            this.llLeft.SuspendRedraw = true;
            this.llRight.SuspendRedraw = true;
            this.llLeft.ClearItems();
            this.llRight.ClearItems();
            int[] keys = new int[this.myPowers.Length - 1 + 1];
            if (this.myPowers.Length < 2)
            {
                int num = this.myPowers.Length - 1;
                for (int index = 0; index <= num; ++index)
                    keys[index] = this.myPowers[index].StaticIndex;
            }
            else if (this.myPowers[0].DisplayLocation != this.myPowers[1].DisplayLocation)
            {
                int num = this.myPowers.Length - 1;
                for (int index = 0; index <= num; ++index)
                    keys[index] = this.myPowers[index].DisplayLocation;
            }
            else
            {
                int num = this.myPowers.Length - 1;
                for (int index = 0; index <= num; ++index)
                    keys[index] = this.myPowers[index].StaticIndex;
            }
            Array.Sort<int, IPower>(keys, this.myPowers);
            int num1 = this.myPowers.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                ListLabelV2.LLItemState iState = !MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index]) ? (!(this.myPowers[index].DisplayName == "Nothing") ? ListLabelV2.LLItemState.Enabled : ListLabelV2.LLItemState.Disabled) : ListLabelV2.LLItemState.Selected;
                ListLabelV2.ListLabelItemV2 iItem = !MidsContext.Config.RtFont.PairedBold ? new ListLabelV2.ListLabelItemV2(this.myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left) : new ListLabelV2.ListLabelItemV2(this.myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left);
                if ((double)index >= (double)this.myPowers.Length / 2.0)
                    this.llRight.AddItem(iItem);
                else
                    this.llLeft.AddItem(iItem);
            }
            this.llLeft.SuspendRedraw = false;
            this.llRight.SuspendRedraw = false;
            this.llLeft.Refresh();
            this.llRight.Refresh();
        }

        void frmIncarnate_Load(object sender, EventArgs e)

        {
            this.buttonArray[0] = this.alphaBtn;
            this.buttonArray[1] = this.destinyBtn;
            this.buttonArray[2] = this.hybridBtn;
            this.buttonArray[3] = this.interfaceBtn;
            this.buttonArray[4] = this.judgementBtn;
            this.buttonArray[5] = this.loreBtn;
            this.buttonArray[6] = this.GenesisButton;
            this.buttonArray[7] = this.StanceButton;
            this.buttonArray[8] = this.VitaeButton;
            this.buttonArray[9] = this.OmegaButton;
            foreach (ImageButton button in this.buttonArray)
            {
                button.IA = this.myParent.Drawing.pImageAttributes;
                button.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
                button.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            }
            this.BackColor = this.myParent.BackColor;
            this.PopInfo.ForeColor = this.BackColor;
            ListLabelV2 llLeft = this.llLeft;
            this.UpdateLLColours(ref llLeft);
            this.llLeft = llLeft;
            ListLabelV2 llRight = this.llRight;
            this.UpdateLLColours(ref llRight);
            this.llRight = llRight;
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            PopUp.PopupData iPopup = new PopUp.PopupData();
            int index = iPopup.Add(null);
            iPopup.Sections[index].Add("Click powers to enable/disable them.", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
            iPopup.Sections[index].Add("Powers in gray (or your custom 'power disabled' color) cannot be included in your stats.", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 0);
            this.PopInfo.SetPopup(iPopup);
            this.ChangedScrollFrameContents();
            this.FillLists();
        }

        void GenesisButton_ButtonClicked()

        {
            ImageButton genesisButton = this.GenesisButton;
            this.SetPowerSet("Genesis", ref genesisButton);
            this.GenesisButton = genesisButton;
        }

        void hybridBtn_ButtonClicked()

        {
            ImageButton hybridBtn = this.hybridBtn;
            this.SetPowerSet("Hybrid", ref hybridBtn);
            this.hybridBtn = hybridBtn;
        }

        void ibClose_ButtonClicked()

        {
            this.Close();
        }

        [DebuggerStepThrough]

        void interfaceBtn_ButtonClicked()

        {
            ImageButton interfaceBtn = this.interfaceBtn;
            this.SetPowerSet("Interface", ref interfaceBtn);
            this.interfaceBtn = interfaceBtn;
        }

        void judgementBtn_ButtonClicked()

        {
            ImageButton judgementBtn = this.judgementBtn;
            this.SetPowerSet("Judgement", ref judgementBtn);
            this.judgementBtn = judgementBtn;
        }

        void lblLock_Click(object sender, EventArgs e)

        {
            this.Locked = false;
            this.lblLock.Visible = false;
        }

        void llLeft_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)

        {
            if (Button == MouseButtons.Right)
            {
                this.Locked = false;
                this.miniPowerInfo(Item.Index);
                this.lblLock.Visible = true;
                this.Locked = true;
            }
            else
            {
                if (Item.ItemState == ListLabelV2.LLItemState.Disabled)
                    return;
                bool flag = !MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[Item.Index]);
                int num1 = this.llLeft.Items.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (this.llLeft.Items[index].ItemState == ListLabelV2.LLItemState.Selected)
                        this.llLeft.Items[index].ItemState = ListLabelV2.LLItemState.Enabled;
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index]))
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index]);
                }
                int num2 = this.llRight.Items.Length - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    if (this.llRight.Items[index].ItemState == ListLabelV2.LLItemState.Selected)
                        this.llRight.Items[index].ItemState = ListLabelV2.LLItemState.Enabled;
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index + this.llLeft.Items.Length]))
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index + this.llLeft.Items.Length]);
                }
                if (flag)
                {
                    MidsContext.Character.CurrentBuild.AddPower(this.myPowers[Item.Index], 49).StatInclude = true;
                    Item.ItemState = ListLabelV2.LLItemState.Selected;
                }
                this.llLeft.Refresh();
                this.llRight.Refresh();
                this.myParent.PowerModified();
            }
        }

        void llLeft_ItemHover(ListLabelV2.ListLabelItemV2 Item)

        {
            this.miniPowerInfo(Item.Index);
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
                this.Locked = false;
                this.miniPowerInfo(pIDX);
                this.lblLock.Visible = true;
                this.Locked = true;
            }
            else
            {
                if (Item.ItemState == ListLabelV2.LLItemState.Disabled)
                    return;
                bool flag = !MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[pIDX]);
                int num1 = this.llLeft.Items.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (this.llLeft.Items[index].ItemState == ListLabelV2.LLItemState.Selected)
                        this.llLeft.Items[index].ItemState = ListLabelV2.LLItemState.Enabled;
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index]))
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index]);
                }
                int num2 = this.llRight.Items.Length - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    if (this.llRight.Items[index].ItemState == ListLabelV2.LLItemState.Selected)
                        this.llRight.Items[index].ItemState = ListLabelV2.LLItemState.Enabled;
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index + this.llLeft.Items.Length]))
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index + this.llLeft.Items.Length]);
                }
                if (flag)
                {
                    MidsContext.Character.CurrentBuild.AddPower(this.myPowers[pIDX], 49).StatInclude = true;
                    Item.ItemState = ListLabelV2.LLItemState.Selected;
                }
                this.llLeft.Refresh();
                this.llRight.Refresh();
                this.myParent.PowerModified();
            }
        }

        void llRight_ItemHover(ListLabelV2.ListLabelItemV2 Item)

        {
            this.miniPowerInfo(Item.Index + this.llLeft.Items.Length);
        }

        void llRight_MouseEnter(object sender, EventArgs e)

        {
            this.llLeft_MouseEnter(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void loreBtn_ButtonClicked()

        {
            ImageButton loreBtn = this.loreBtn;
            this.SetPowerSet("Lore", ref loreBtn);
            this.loreBtn = loreBtn;
        }

        public void miniPowerInfo(int pIDX)
        {
            if (this.Locked)
                return;
            IPower power1 = (IPower)new Power(this.myPowers[pIDX]);
            power1.AbsorbPetEffects(-1);
            power1.ApplyGrantPowerEffects();
            PopUp.PopupData iPopup = new PopUp.PopupData();
            if (pIDX < 0)
            {
                this.PopInfo.SetPopup(iPopup);
                this.ChangedScrollFrameContents();
            }
            else
            {
                int index1 = iPopup.Add(null);
                string str1 = "";
                switch (power1.PowerType)
                {
                    case ePowerType.Click:
                        if (power1.ClickBuff)
                        {
                            str1 = "(Click)";
                            break;
                        }
                        break;
                    case ePowerType.Auto_:
                        str1 = "(Auto)";
                        break;
                    case ePowerType.Toggle:
                        str1 = "(Toggle)";
                        break;
                }
                iPopup.Sections[index1].Add(power1.DisplayName, PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                iPopup.Sections[index1].Add(str1 + " " + power1.DescShort, PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 0);
                string str2 = power1.DescLong.Replace("<br>", "\r\n");
                iPopup.Sections[index1].Add(str1 + " " + str2, PopUp.Colors.Common, 1f, System.Drawing.FontStyle.Regular, 0);
                int index2 = iPopup.Add(null);
                if ((double)power1.EndCost > 0.0)
                {
                    if ((double)power1.ActivatePeriod > 0.0)
                        iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power1.EndCost / power1.ActivatePeriod) + "/s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                    else
                        iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Title, Utilities.FixDP(power1.EndCost), PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                }
                if (power1.EntitiesAutoHit == eEntity.None | (double)power1.Range > 20.0 & power1.I9FXPresentP(eEffectType.Mez, eMez.Taunt))
                    iPopup.Sections[index2].Add("Accuracy:", PopUp.Colors.Title, Utilities.FixDP((float)((double)MidsContext.Config.BaseAcc * (double)power1.Accuracy * 100.0)) + "%", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.RechargeTime > 0.0)
                    iPopup.Sections[index2].Add("Recharge:", PopUp.Colors.Title, Utilities.FixDP(power1.RechargeTime) + "s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                int durationEffectId = power1.GetDurationEffectID();
                float iNum = 0.0f;
                if (durationEffectId > -1)
                    iNum = power1.Effects[durationEffectId].Duration;
                if (power1.PowerType != ePowerType.Toggle & power1.PowerType != ePowerType.Auto_ && (double)iNum > 0.0)
                    iPopup.Sections[index2].Add("Duration:", PopUp.Colors.Title, Utilities.FixDP(iNum) + "s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.Range > 0.0)
                    iPopup.Sections[index2].Add("Range:", PopUp.Colors.Title, Utilities.FixDP(power1.Range) + "ft", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.Arc > 0)
                    iPopup.Sections[index2].Add("Arc:", PopUp.Colors.Title, Conversions.ToString(power1.Arc) + "°", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                else if ((double)power1.Radius > 0.0)
                    iPopup.Sections[index2].Add("Radius:", PopUp.Colors.Title, Conversions.ToString(power1.Radius) + "ft", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.CastTime > 0.0)
                    iPopup.Sections[index2].Add("Cast Time:", PopUp.Colors.Title, Utilities.FixDP(power1.CastTime) + "s", PopUp.Colors.Title, 0.9f, System.Drawing.FontStyle.Bold, 1);
                IPower power2 = power1;
                if (power2.Effects.Length > 0)
                {
                    iPopup.Sections[index2].Add("Effects:", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    char[] chArray = new char[1] { '^' };
                    int num1 = power2.Effects.Length - 1;
                    for (int index3 = 0; index3 <= num1; ++index3)
                    {
                        if ((power2.Effects[index3].EffectType != eEffectType.GrantPower | power2.Effects[index3].Absorbed_Effect) & power2.Effects[index3].EffectType != eEffectType.RevokePower & power2.Effects[index3].EffectType != eEffectType.SetMode)
                        {
                            int index4 = iPopup.Add(null);
                            power1.Effects[index3].SetPower(power1);
                            string[] strArray = power1.Effects[index3].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", "").Replace("]", "").Split(chArray);
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
                }
                this.PopInfo.SetPopup(iPopup);
                this.ChangedScrollFrameContents();
            }
        }

        void OmegaButton_ButtonClicked()

        {
            ImageButton omegaButton = this.OmegaButton;
            this.SetPowerSet("Omega", ref omegaButton);
            this.OmegaButton = omegaButton;
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

        void SetPowerSet(string Setname, ref ImageButton button)

        {
            foreach (ImageButton button1 in this.buttonArray)
                button1.Checked = false;
            button.Checked = true;
            this.myPowers = DatabaseAPI.GetPowersetByID(Setname, ePowerSetType.Incarnate).Powers;
            this.FillLists();
        }

        void StanceButton_ButtonClicked()

        {
            ImageButton stanceButton = this.StanceButton;
            this.SetPowerSet("Stance", ref stanceButton);
            this.StanceButton = stanceButton;
        }

        protected void UpdateLLColours(ref ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            iList.Font = new System.Drawing.Font(iList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        }

        void VitaeButton_ButtonClicked()

        {
            ImageButton vitaeButton = this.VitaeButton;
            this.SetPowerSet("Vitae", ref vitaeButton);
            this.VitaeButton = vitaeButton;
        }

        void VScrollBar1_Scroll(object sender, ScrollEventArgs e)

        {
            if ((double)this.PopInfo.lHeight > (double)this.Panel1.Height & this.VScrollBar1.Maximum > this.VScrollBar1.LargeChange)
                this.PopInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * ((double)this.PopInfo.lHeight - (double)this.Panel1.Height));
            else
                this.PopInfo.ScrollY = 0.0f;
        }

        public class CustomPanel : Panel
        {
            protected override Point ScrollToControl(Control activeControl)
            {
                return this.DisplayRectangle.Location;
            }
        }
    }
}