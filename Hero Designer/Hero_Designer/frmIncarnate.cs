using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
    // Token: 0x02000044 RID: 68

    public partial class frmIncarnate : Form
    {
        // Token: 0x1700041F RID: 1055
        // (get) Token: 0x06000C5E RID: 3166 RVA: 0x0007AE1C File Offset: 0x0007901C
        // (set) Token: 0x06000C5F RID: 3167 RVA: 0x0007AE34 File Offset: 0x00079034
        internal virtual ImageButton alphaBtn
        {
            get
            {
                return this._alphaBtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.alphaBtn_ButtonClicked);
                if (this._alphaBtn != null)
                {
                    this._alphaBtn.ButtonClicked -= clickedEventHandler;
                }
                this._alphaBtn = value;
                if (this._alphaBtn != null)
                {
                    this._alphaBtn.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000420 RID: 1056
        // (get) Token: 0x06000C60 RID: 3168 RVA: 0x0007AE90 File Offset: 0x00079090
        // (set) Token: 0x06000C61 RID: 3169 RVA: 0x0007AEA8 File Offset: 0x000790A8
        internal virtual ImageButton destinyBtn
        {
            get
            {
                return this._destinyBtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.destinyBtn_ButtonClicked);
                if (this._destinyBtn != null)
                {
                    this._destinyBtn.ButtonClicked -= clickedEventHandler;
                }
                this._destinyBtn = value;
                if (this._destinyBtn != null)
                {
                    this._destinyBtn.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000421 RID: 1057
        // (get) Token: 0x06000C62 RID: 3170 RVA: 0x0007AF04 File Offset: 0x00079104
        // (set) Token: 0x06000C63 RID: 3171 RVA: 0x0007AF1C File Offset: 0x0007911C
        internal virtual ImageButton GenesisButton
        {
            get
            {
                return this._GenesisButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.GenesisButton_ButtonClicked);
                if (this._GenesisButton != null)
                {
                    this._GenesisButton.ButtonClicked -= clickedEventHandler;
                }
                this._GenesisButton = value;
                if (this._GenesisButton != null)
                {
                    this._GenesisButton.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000422 RID: 1058
        // (get) Token: 0x06000C64 RID: 3172 RVA: 0x0007AF78 File Offset: 0x00079178
        // (set) Token: 0x06000C65 RID: 3173 RVA: 0x0007AF90 File Offset: 0x00079190
        internal virtual ImageButton hybridBtn
        {
            get
            {
                return this._hybridBtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.hybridBtn_ButtonClicked);
                if (this._hybridBtn != null)
                {
                    this._hybridBtn.ButtonClicked -= clickedEventHandler;
                }
                this._hybridBtn = value;
                if (this._hybridBtn != null)
                {
                    this._hybridBtn.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000423 RID: 1059
        // (get) Token: 0x06000C66 RID: 3174 RVA: 0x0007AFEC File Offset: 0x000791EC
        // (set) Token: 0x06000C67 RID: 3175 RVA: 0x0007B004 File Offset: 0x00079204
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

        // Token: 0x17000424 RID: 1060
        // (get) Token: 0x06000C68 RID: 3176 RVA: 0x0007B060 File Offset: 0x00079260
        // (set) Token: 0x06000C69 RID: 3177 RVA: 0x0007B078 File Offset: 0x00079278
        internal virtual ImageButton interfaceBtn
        {
            get
            {
                return this._interfaceBtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.interfaceBtn_ButtonClicked);
                if (this._interfaceBtn != null)
                {
                    this._interfaceBtn.ButtonClicked -= clickedEventHandler;
                }
                this._interfaceBtn = value;
                if (this._interfaceBtn != null)
                {
                    this._interfaceBtn.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000425 RID: 1061
        // (get) Token: 0x06000C6A RID: 3178 RVA: 0x0007B0D4 File Offset: 0x000792D4
        // (set) Token: 0x06000C6B RID: 3179 RVA: 0x0007B0EC File Offset: 0x000792EC
        internal virtual ImageButton judgementBtn
        {
            get
            {
                return this._judgementBtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.judgementBtn_ButtonClicked);
                if (this._judgementBtn != null)
                {
                    this._judgementBtn.ButtonClicked -= clickedEventHandler;
                }
                this._judgementBtn = value;
                if (this._judgementBtn != null)
                {
                    this._judgementBtn.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x17000426 RID: 1062
        // (get) Token: 0x06000C6C RID: 3180 RVA: 0x0007B148 File Offset: 0x00079348
        // (set) Token: 0x06000C6D RID: 3181 RVA: 0x0007B160 File Offset: 0x00079360
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

        // Token: 0x17000427 RID: 1063
        // (get) Token: 0x06000C6E RID: 3182 RVA: 0x0007B1BC File Offset: 0x000793BC
        // (set) Token: 0x06000C6F RID: 3183 RVA: 0x0007B1D4 File Offset: 0x000793D4
        internal virtual ListLabelV2 llLeft
        {
            get
            {
                return this._llLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llLeft_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llLeft_MouseEnter);
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llLeft_ItemHover);
                if (this._llLeft != null)
                {
                    this._llLeft.ItemClick -= clickEventHandler;
                    this._llLeft.MouseEnter -= eventHandler;
                    this._llLeft.ItemHover -= hoverEventHandler;
                }
                this._llLeft = value;
                if (this._llLeft != null)
                {
                    this._llLeft.ItemClick += clickEventHandler;
                    this._llLeft.MouseEnter += eventHandler;
                    this._llLeft.ItemHover += hoverEventHandler;
                }
            }
        }

        // Token: 0x17000428 RID: 1064
        // (get) Token: 0x06000C70 RID: 3184 RVA: 0x0007B27C File Offset: 0x0007947C
        // (set) Token: 0x06000C71 RID: 3185 RVA: 0x0007B294 File Offset: 0x00079494
        internal virtual ListLabelV2 llRight
        {
            get
            {
                return this._llRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.llRight_MouseEnter);
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llRight_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llRight_ItemClick);
                if (this._llRight != null)
                {
                    this._llRight.MouseEnter -= eventHandler;
                    this._llRight.ItemHover -= hoverEventHandler;
                    this._llRight.ItemClick -= clickEventHandler;
                }
                this._llRight = value;
                if (this._llRight != null)
                {
                    this._llRight.MouseEnter += eventHandler;
                    this._llRight.ItemHover += hoverEventHandler;
                    this._llRight.ItemClick += clickEventHandler;
                }
            }
        }

        // Token: 0x17000429 RID: 1065
        // (get) Token: 0x06000C72 RID: 3186 RVA: 0x0007B33C File Offset: 0x0007953C
        // (set) Token: 0x06000C73 RID: 3187 RVA: 0x0007B354 File Offset: 0x00079554
        internal virtual ImageButton loreBtn
        {
            get
            {
                return this._loreBtn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.loreBtn_ButtonClicked);
                if (this._loreBtn != null)
                {
                    this._loreBtn.ButtonClicked -= clickedEventHandler;
                }
                this._loreBtn = value;
                if (this._loreBtn != null)
                {
                    this._loreBtn.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x1700042A RID: 1066
        // (get) Token: 0x06000C74 RID: 3188 RVA: 0x0007B3B0 File Offset: 0x000795B0
        // (set) Token: 0x06000C75 RID: 3189 RVA: 0x0007B3C8 File Offset: 0x000795C8
        internal virtual ImageButton OmegaButton
        {
            get
            {
                return this._OmegaButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.OmegaButton_ButtonClicked);
                if (this._OmegaButton != null)
                {
                    this._OmegaButton.ButtonClicked -= clickedEventHandler;
                }
                this._OmegaButton = value;
                if (this._OmegaButton != null)
                {
                    this._OmegaButton.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x1700042B RID: 1067
        // (get) Token: 0x06000C76 RID: 3190 RVA: 0x0007B424 File Offset: 0x00079624
        // (set) Token: 0x06000C77 RID: 3191 RVA: 0x0007B43C File Offset: 0x0007963C
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

        // Token: 0x1700042C RID: 1068
        // (get) Token: 0x06000C78 RID: 3192 RVA: 0x0007B448 File Offset: 0x00079648
        // (set) Token: 0x06000C79 RID: 3193 RVA: 0x0007B460 File Offset: 0x00079660
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

        // Token: 0x1700042D RID: 1069
        // (get) Token: 0x06000C7A RID: 3194 RVA: 0x0007B4E4 File Offset: 0x000796E4
        // (set) Token: 0x06000C7B RID: 3195 RVA: 0x0007B4FC File Offset: 0x000796FC
        internal virtual ImageButton StanceButton
        {
            get
            {
                return this._StanceButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.StanceButton_ButtonClicked);
                if (this._StanceButton != null)
                {
                    this._StanceButton.ButtonClicked -= clickedEventHandler;
                }
                this._StanceButton = value;
                if (this._StanceButton != null)
                {
                    this._StanceButton.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x1700042E RID: 1070
        // (get) Token: 0x06000C7C RID: 3196 RVA: 0x0007B558 File Offset: 0x00079758
        // (set) Token: 0x06000C7D RID: 3197 RVA: 0x0007B570 File Offset: 0x00079770
        internal virtual ImageButton VitaeButton
        {
            get
            {
                return this._VitaeButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.VitaeButton_ButtonClicked);
                if (this._VitaeButton != null)
                {
                    this._VitaeButton.ButtonClicked -= clickedEventHandler;
                }
                this._VitaeButton = value;
                if (this._VitaeButton != null)
                {
                    this._VitaeButton.ButtonClicked += clickedEventHandler;
                }
            }
        }

        // Token: 0x1700042F RID: 1071
        // (get) Token: 0x06000C7E RID: 3198 RVA: 0x0007B5CC File Offset: 0x000797CC
        // (set) Token: 0x06000C7F RID: 3199 RVA: 0x0007B5E4 File Offset: 0x000797E4
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

        // Token: 0x06000C80 RID: 3200 RVA: 0x0007B640 File Offset: 0x00079840
        public frmIncarnate(ref frmMain iParent)
        {
            base.Load += this.frmIncarnate_Load;
            this.myPowers = new IPower[0];
            this.Locked = false;
            this.buttonArray = new ImageButton[10];
            this.InitializeComponent();
            this.myParent = iParent;
            this.myPowers = DatabaseAPI.GetPowersetByName("Alpha", Enums.ePowerSetType.Incarnate).Powers;
        }

        // Token: 0x06000C81 RID: 3201 RVA: 0x0007B6B0 File Offset: 0x000798B0
        private void alphaBtn_ButtonClicked()
        {
            ImageButton alphaBtn = this.alphaBtn;
            this.SetPowerSet("Alpha", ref alphaBtn);
            this.alphaBtn = alphaBtn;
        }

        // Token: 0x06000C82 RID: 3202 RVA: 0x0007B6DC File Offset: 0x000798DC
        private void ChangedScrollFrameContents()
        {
            this.VScrollBar1.Value = 0;
            this.VScrollBar1.Maximum = (int)Math.Round((double)this.PopInfo.lHeight * ((double)this.VScrollBar1.LargeChange / (double)this.Panel1.Height));
            this.VScrollBar1_Scroll(this.VScrollBar1, new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        // Token: 0x06000C83 RID: 3203 RVA: 0x0007B744 File Offset: 0x00079944
        private void destinyBtn_ButtonClicked()
        {
            ImageButton destinyBtn = this.destinyBtn;
            this.SetPowerSet("Destiny", ref destinyBtn);
            this.destinyBtn = destinyBtn;
        }

        // Token: 0x06000C85 RID: 3205 RVA: 0x0007B7C0 File Offset: 0x000799C0
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
                for (int index = 0; index <= num; index++)
                {
                    keys[index] = this.myPowers[index].StaticIndex;
                }
            }
            else if (this.myPowers[0].DisplayLocation != this.myPowers[1].DisplayLocation)
            {
                int num2 = this.myPowers.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    keys[index] = this.myPowers[index].DisplayLocation;
                }
            }
            else
            {
                int num3 = this.myPowers.Length - 1;
                for (int index = 0; index <= num3; index++)
                {
                    keys[index] = this.myPowers[index].StaticIndex;
                }
            }
            Array.Sort<int, IPower>(keys, this.myPowers);
            int num4 = this.myPowers.Length - 1;
            for (int index = 0; index <= num4; index++)
            {
                ListLabelV2.LLItemState iState;
                if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index]))
                {
                    iState = ListLabelV2.LLItemState.Selected;
                }
                else if (this.myPowers[index].DisplayName == "Nothing")
                {
                    iState = ListLabelV2.LLItemState.Disabled;
                }
                else
                {
                    iState = ListLabelV2.LLItemState.Enabled;
                }
                ListLabelV2.ListLabelItemV2 iItem;
                if (MidsContext.Config.RtFont.PairedBold)
                {
                    iItem = new ListLabelV2.ListLabelItemV2(this.myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left);
                }
                else
                {
                    iItem = new ListLabelV2.ListLabelItemV2(this.myPowers[index].DisplayName, iState, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left);
                }
                if ((double)index >= (double)this.myPowers.Length / 2.0)
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

        // Token: 0x06000C86 RID: 3206 RVA: 0x0007BA48 File Offset: 0x00079C48
        private void frmIncarnate_Load(object sender, EventArgs e)
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
            ListLabelV2 llRight = this.llLeft;
            this.UpdateLLColours(ref llRight);
            this.llLeft = llRight;
            llRight = this.llRight;
            this.UpdateLLColours(ref llRight);
            this.llRight = llRight;
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            PopUp.PopupData iPopup = default(PopUp.PopupData);
            int index = iPopup.Add(null);
            iPopup.Sections[index].Add("Click powers to enable/disable them.", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            iPopup.Sections[index].Add("Powers in gray (or your custom 'power disabled' color) cannot be included in your stats.", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
            this.PopInfo.SetPopup(iPopup);
            this.ChangedScrollFrameContents();
            this.FillLists();
        }

        // Token: 0x06000C87 RID: 3207 RVA: 0x0007BC80 File Offset: 0x00079E80
        private void GenesisButton_ButtonClicked()
        {
            ImageButton genesisButton = this.GenesisButton;
            this.SetPowerSet("Genesis", ref genesisButton);
            this.GenesisButton = genesisButton;
        }

        // Token: 0x06000C88 RID: 3208 RVA: 0x0007BCAC File Offset: 0x00079EAC
        private void hybridBtn_ButtonClicked()
        {
            ImageButton hybridBtn = this.hybridBtn;
            this.SetPowerSet("Hybrid", ref hybridBtn);
            this.hybridBtn = hybridBtn;
        }

        // Token: 0x06000C89 RID: 3209 RVA: 0x0007BCD7 File Offset: 0x00079ED7
        private void ibClose_ButtonClicked()
        {
            base.Close();
        }

        // Token: 0x06000C8B RID: 3211 RVA: 0x0007CDFC File Offset: 0x0007AFFC
        private void interfaceBtn_ButtonClicked()
        {
            ImageButton interfaceBtn = this.interfaceBtn;
            this.SetPowerSet("Interface", ref interfaceBtn);
            this.interfaceBtn = interfaceBtn;
        }

        // Token: 0x06000C8C RID: 3212 RVA: 0x0007CE28 File Offset: 0x0007B028
        private void judgementBtn_ButtonClicked()
        {
            ImageButton judgementBtn = this.judgementBtn;
            this.SetPowerSet("Judgement", ref judgementBtn);
            this.judgementBtn = judgementBtn;
        }

        // Token: 0x06000C8D RID: 3213 RVA: 0x0007CE53 File Offset: 0x0007B053
        private void lblLock_Click(object sender, EventArgs e)
        {
            this.Locked = false;
            this.lblLock.Visible = false;
        }

        // Token: 0x06000C8E RID: 3214 RVA: 0x0007CE6C File Offset: 0x0007B06C
        private void llLeft_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Right)
            {
                this.Locked = false;
                this.miniPowerInfo(Item.Index);
                this.lblLock.Visible = true;
                this.Locked = true;
            }
            else if (Item.ItemState != ListLabelV2.LLItemState.Disabled)
            {
                bool flag = !MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[Item.Index]);
                int num = this.llLeft.Items.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (this.llLeft.Items[index].ItemState == ListLabelV2.LLItemState.Selected)
                    {
                        this.llLeft.Items[index].ItemState = ListLabelV2.LLItemState.Enabled;
                    }
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index]))
                    {
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index]);
                    }
                }
                int num2 = this.llRight.Items.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (this.llRight.Items[index2].ItemState == ListLabelV2.LLItemState.Selected)
                    {
                        this.llRight.Items[index2].ItemState = ListLabelV2.LLItemState.Enabled;
                    }
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index2 + this.llLeft.Items.Length]))
                    {
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index2 + this.llLeft.Items.Length]);
                    }
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

        // Token: 0x06000C8F RID: 3215 RVA: 0x0007D0A1 File Offset: 0x0007B2A1
        private void llLeft_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.miniPowerInfo(Item.Index);
        }

        // Token: 0x06000C90 RID: 3216 RVA: 0x0007D0B4 File Offset: 0x0007B2B4
        private void llLeft_MouseEnter(object sender, EventArgs e)
        {
            if (base.ContainsFocus)
            {
                this.Panel2.Focus();
            }
        }

        // Token: 0x06000C91 RID: 3217 RVA: 0x0007D0E0 File Offset: 0x0007B2E0
        private void llRight_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            int pIDX = Item.Index + this.llLeft.Items.Length;
            if (Button == MouseButtons.Right)
            {
                this.Locked = false;
                this.miniPowerInfo(pIDX);
                this.lblLock.Visible = true;
                this.Locked = true;
            }
            else if (Item.ItemState != ListLabelV2.LLItemState.Disabled)
            {
                bool flag = !MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[pIDX]);
                int num = this.llLeft.Items.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (this.llLeft.Items[index].ItemState == ListLabelV2.LLItemState.Selected)
                    {
                        this.llLeft.Items[index].ItemState = ListLabelV2.LLItemState.Enabled;
                    }
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index]))
                    {
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index]);
                    }
                }
                int num2 = this.llRight.Items.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (this.llRight.Items[index2].ItemState == ListLabelV2.LLItemState.Selected)
                    {
                        this.llRight.Items[index2].ItemState = ListLabelV2.LLItemState.Enabled;
                    }
                    if (MidsContext.Character.CurrentBuild.PowerUsed(this.myPowers[index2 + this.llLeft.Items.Length]))
                    {
                        MidsContext.Character.CurrentBuild.RemovePower(this.myPowers[index2 + this.llLeft.Items.Length]);
                    }
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

        // Token: 0x06000C92 RID: 3218 RVA: 0x0007D320 File Offset: 0x0007B520
        private void llRight_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            int pIDX = Item.Index + this.llLeft.Items.Length;
            this.miniPowerInfo(pIDX);
        }

        // Token: 0x06000C93 RID: 3219 RVA: 0x0007D34B File Offset: 0x0007B54B
        private void llRight_MouseEnter(object sender, EventArgs e)
        {
            this.llLeft_MouseEnter(RuntimeHelpers.GetObjectValue(sender), e);
        }

        // Token: 0x06000C94 RID: 3220 RVA: 0x0007D35C File Offset: 0x0007B55C
        private void loreBtn_ButtonClicked()
        {
            ImageButton loreBtn = this.loreBtn;
            this.SetPowerSet("Lore", ref loreBtn);
            this.loreBtn = loreBtn;
        }

        // Token: 0x06000C95 RID: 3221 RVA: 0x0007D388 File Offset: 0x0007B588
        public void miniPowerInfo(int pIDX)
        {
            if (!this.Locked)
            {
                IPower power = new Power(this.myPowers[pIDX]);
                power.AbsorbPetEffects(-1);
                power.ApplyGrantPowerEffects();
                PopUp.PopupData iPopup = default(PopUp.PopupData);
                if (pIDX < 0)
                {
                    this.PopInfo.SetPopup(iPopup);
                    this.ChangedScrollFrameContents();
                }
                else
                {
                    int index4 = iPopup.Add(null);
                    string str = "";
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
                    string str2 = power.DescLong.Replace("<br>", "\r\n");
                    iPopup.Sections[index4].Add(str + " " + str2, PopUp.Colors.Common, 1f, FontStyle.Regular, 0);
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
                            if ((power2.Effects[index5].EffectType != Enums.eEffectType.GrantPower | power2.Effects[index5].Absorbed_Effect) & power2.Effects[index5].EffectType != Enums.eEffectType.RevokePower & power2.Effects[index5].EffectType != Enums.eEffectType.SetMode)
                            {
                                index4 = iPopup.Add(null);
                                power.Effects[index5].Power = power;
                                string[] strArray = power.Effects[index5].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", "").Replace("]", "").Split(chArray);
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
                    }
                    this.PopInfo.SetPopup(iPopup);
                    this.ChangedScrollFrameContents();
                }
            }
        }

        // Token: 0x06000C96 RID: 3222 RVA: 0x0007DA14 File Offset: 0x0007BC14
        private void OmegaButton_ButtonClicked()
        {
            ImageButton omegaButton = this.OmegaButton;
            this.SetPowerSet("Omega", ref omegaButton);
            this.OmegaButton = omegaButton;
        }

        // Token: 0x06000C97 RID: 3223 RVA: 0x0007DA40 File Offset: 0x0007BC40
        private void PopInfo_MouseEnter(object sender, EventArgs e)
        {
            if (base.ContainsFocus)
            {
                this.VScrollBar1.Focus();
            }
        }

        // Token: 0x06000C98 RID: 3224 RVA: 0x0007DA6C File Offset: 0x0007BC6C
        private void PopInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            this.VScrollBar1.Value = Conversions.ToInteger(Operators.AddObject(this.VScrollBar1.Value, Interaction.IIf(e.Delta > 0, -1, 1)));
            if (this.VScrollBar1.Value > this.VScrollBar1.Maximum - 9)
            {
                this.VScrollBar1.Value = this.VScrollBar1.Maximum - 9;
            }
            this.VScrollBar1_Scroll(RuntimeHelpers.GetObjectValue(sender), new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        // Token: 0x06000C99 RID: 3225 RVA: 0x0007DB0C File Offset: 0x0007BD0C
        private void SetPowerSet(string Setname, ref ImageButton button)
        {
            foreach (ImageButton button2 in this.buttonArray)
            {
                button2.Checked = false;
            }
            button.Checked = true;
            this.myPowers = DatabaseAPI.GetPowersetByID(Setname, Enums.ePowerSetType.Incarnate).Powers;
            this.FillLists();
        }

        // Token: 0x06000C9A RID: 3226 RVA: 0x0007DB64 File Offset: 0x0007BD64
        private void StanceButton_ButtonClicked()
        {
            ImageButton stanceButton = this.StanceButton;
            this.SetPowerSet("Stance", ref stanceButton);
            this.StanceButton = stanceButton;
        }

        // Token: 0x06000C9B RID: 3227 RVA: 0x0007DB90 File Offset: 0x0007BD90
        protected void UpdateLLColours(ref ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            iList.Font = new Font(iList.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
        }

        // Token: 0x06000C9C RID: 3228 RVA: 0x0007DC54 File Offset: 0x0007BE54
        private void VitaeButton_ButtonClicked()
        {
            ImageButton vitaeButton = this.VitaeButton;
            this.SetPowerSet("Vitae", ref vitaeButton);
            this.VitaeButton = vitaeButton;
        }

        // Token: 0x06000C9D RID: 3229 RVA: 0x0007DC80 File Offset: 0x0007BE80
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.PopInfo.lHeight > (float)this.Panel1.Height & this.VScrollBar1.Maximum > this.VScrollBar1.LargeChange)
            {
                this.PopInfo.ScrollY = (float)((double)this.VScrollBar1.Value / (double)(this.VScrollBar1.Maximum - this.VScrollBar1.LargeChange) * (double)(this.PopInfo.lHeight - (float)this.Panel1.Height));
            }
            else
            {
                this.PopInfo.ScrollY = 0f;
            }
        }

        // Token: 0x04000517 RID: 1303
        [AccessedThroughProperty("alphaBtn")]
        private ImageButton _alphaBtn;

        // Token: 0x04000518 RID: 1304
        [AccessedThroughProperty("destinyBtn")]
        private ImageButton _destinyBtn;

        // Token: 0x04000519 RID: 1305
        [AccessedThroughProperty("GenesisButton")]
        private ImageButton _GenesisButton;

        // Token: 0x0400051A RID: 1306
        [AccessedThroughProperty("hybridBtn")]
        private ImageButton _hybridBtn;

        // Token: 0x0400051B RID: 1307
        [AccessedThroughProperty("ibClose")]
        private ImageButton _ibClose;

        // Token: 0x0400051C RID: 1308
        [AccessedThroughProperty("interfaceBtn")]
        private ImageButton _interfaceBtn;

        // Token: 0x0400051D RID: 1309
        [AccessedThroughProperty("judgementBtn")]
        private ImageButton _judgementBtn;

        // Token: 0x0400051E RID: 1310
        [AccessedThroughProperty("lblLock")]
        private Label _lblLock;

        // Token: 0x0400051F RID: 1311
        [AccessedThroughProperty("llLeft")]
        private ListLabelV2 _llLeft;

        // Token: 0x04000520 RID: 1312
        [AccessedThroughProperty("llRight")]
        private ListLabelV2 _llRight;

        // Token: 0x04000521 RID: 1313
        [AccessedThroughProperty("loreBtn")]
        private ImageButton _loreBtn;

        // Token: 0x04000522 RID: 1314
        [AccessedThroughProperty("OmegaButton")]
        private ImageButton _OmegaButton;

        // Token: 0x04000523 RID: 1315
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;

        // Token: 0x04000524 RID: 1316
        [AccessedThroughProperty("PopInfo")]
        private ctlPopUp _PopInfo;

        // Token: 0x04000525 RID: 1317
        [AccessedThroughProperty("StanceButton")]
        private ImageButton _StanceButton;

        // Token: 0x04000526 RID: 1318
        [AccessedThroughProperty("VitaeButton")]
        private ImageButton _VitaeButton;

        // Token: 0x04000527 RID: 1319
        [AccessedThroughProperty("VScrollBar1")]
        private VScrollBar _VScrollBar1;

        // Token: 0x04000528 RID: 1320
        private ImageButton[] buttonArray;

        // Token: 0x0400052A RID: 1322
        protected bool Locked;

        // Token: 0x0400052B RID: 1323
        protected frmMain myParent;

        // Token: 0x0400052C RID: 1324
        public IPower[] myPowers;

        // Token: 0x02000045 RID: 69
        public class CustomPanel : Panel
        {
            // Token: 0x06000C9E RID: 3230 RVA: 0x0007DD2C File Offset: 0x0007BF2C
            protected override Point ScrollToControl(Control activeControl)
            {
                return this.DisplayRectangle.Location;
            }
        }
    }
}
