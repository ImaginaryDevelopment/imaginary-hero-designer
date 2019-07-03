using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    public class ListLabelV2 : UserControl
    {
        public delegate void ItemClickEventHandler(ListLabelItemV2 Item, MouseButtons Button);

        public delegate void ItemHoverEventHandler(ListLabelItemV2 Item);

        public delegate void EmptyHoverEventHandler();

        public delegate void ExpandChangedEventHandler(bool Expanded);
        public event ItemClickEventHandler ItemClick;
        public event ItemHoverEventHandler ItemHover;
        public event EmptyHoverEventHandler EmptyHover;
        public event ExpandChangedEventHandler ExpandChanged;

        public bool isExpanded
        {
            get
            {
                return this.Expanded;
            }
        }

        public Color TextColor
        {
            get
            {
                Color result;
                if (this.Item.ItemState < ListLabelV2.LLItemState.Enabled | this.Item.ItemState > ListLabelV2.LLItemState.Heading)
                {
                    result = Color.Black;
                }
                else
                {
                    result = this.Colours[(int)this.Item.ItemState];
                }
                return result;
            }
            set
            {
                if (!(this.Item.ItemState < ListLabelV2.LLItemState.Enabled | this.Item.ItemState > ListLabelV2.LLItemState.Heading))
                {
                    this.Colours[(int)this.Item.ItemState] = value;
                    this.Draw();
                }
            }
        }

        // Token: 0x060001D4 RID: 468 RVA: 0x000113CC File Offset: 0x0000F5CC
        public void UpdateTextColors(ListLabelV2.LLItemState State, Color color)
        {
            if (!(State < LLItemState.Enabled | State > LLItemState.Heading))
            {
                this.Colours[(int)State] = color;
                this.Draw();
            }
        }

        public ListLabelItemV2 Item
        {
            get
            {
                if (this.Item.Index < 0 | this.Item.Index > checked(this.Items.Length - 1))
                {
                    return new ListLabelItemV2();
                }
                else
                {
                    return this.Items[this.Item.Index];
                }
            }
            set
            {
                if (!(this.Item.Index < 0 | this.Item.Index > checked(this.Items.Length - 1)))
                {
                    this.Items[this.Item.Index] = new ListLabelItemV2(value);
                    this.Draw();
                }
            }
        }

        // Token: 0x17000065 RID: 101
        // (get) Token: 0x060001D7 RID: 471 RVA: 0x000114C4 File Offset: 0x0000F6C4
        // (set) Token: 0x060001D8 RID: 472 RVA: 0x000114DC File Offset: 0x0000F6DC
        public override Color BackColor
        {
            get
            {
                return this.bgColor;
            }
            set
            {
                this.bgColor = value;
                this.Draw();
            }
        }

        public Color HoverColor
        {
            get
            {
                return this.hvrColor;
            }
            set
            {
                this.hvrColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000067 RID: 103
        // (get) Token: 0x060001DB RID: 475 RVA: 0x0001151C File Offset: 0x0000F71C
        // (set) Token: 0x060001DC RID: 476 RVA: 0x00011534 File Offset: 0x0000F734
        public int PaddingX
        {
            get
            {
                return this.xPadding;
            }
            set
            {
                if (value >= 0 & checked(value * 2 < base.Width - 5))
                {
                    this.xPadding = value;
                    this.Draw();
                }
            }
        }

        // Token: 0x17000068 RID: 104
        // (get) Token: 0x060001DD RID: 477 RVA: 0x00011570 File Offset: 0x0000F770
        // (set) Token: 0x060001DE RID: 478 RVA: 0x00011588 File Offset: 0x0000F788
        public int PaddingY
        {
            get
            {
                return this.yPadding;
            }
            set
            {
                if (value >= 0 & (double)value < (double)base.Height / 3.0)
                {
                    this.yPadding = value;
                    this.SetLineHeight();
                    this.Draw();
                }
            }
        }

        // Token: 0x17000069 RID: 105
        // (get) Token: 0x060001DF RID: 479 RVA: 0x000115D4 File Offset: 0x0000F7D4
        // (set) Token: 0x060001E0 RID: 480 RVA: 0x000115EC File Offset: 0x0000F7EC
        public bool HighVis
        {
            get
            {
                return this.TextOutline;
            }
            set
            {
                this.TextOutline = value;
                this.Draw();
            }
        }

        // Token: 0x1700006A RID: 106
        // (get) Token: 0x060001E1 RID: 481 RVA: 0x00011600 File Offset: 0x0000F800
        public int HoverID
        {
            get
            {
                return this.HoverIndex;
            }
        }

        // Token: 0x1700006B RID: 107
        // (get) Token: 0x060001E2 RID: 482 RVA: 0x00011618 File Offset: 0x0000F818
        // (set) Token: 0x060001E3 RID: 483 RVA: 0x00011630 File Offset: 0x0000F830
        public bool SuspendRedraw
        {
            get
            {
                return this.DisableRedraw;
            }
            set
            {
                this.DisableRedraw = value;
                if (!value)
                {
                    if (this.Expanded)
                    {
                        this.RecomputeExpand();
                    }
                    if (!this.Expanded)
                    {
                        this.Recalculate(false);
                        this.Draw();
                    }
                }
            }
        }

        // Token: 0x1700006C RID: 108
        // (get) Token: 0x060001E4 RID: 484 RVA: 0x00011680 File Offset: 0x0000F880
        // (set) Token: 0x060001E5 RID: 485 RVA: 0x00011698 File Offset: 0x0000F898
        public bool Scrollable
        {
            get
            {
                return this.canScroll;
            }
            set
            {
                this.canScroll = value;
                this.Draw();
            }
        }

        // Token: 0x1700006D RID: 109
        // (get) Token: 0x060001E6 RID: 486 RVA: 0x000116AC File Offset: 0x0000F8AC
        // (set) Token: 0x060001E7 RID: 487 RVA: 0x000116C4 File Offset: 0x0000F8C4
        public bool Expandable
        {
            get
            {
                return this.canExpand;
            }
            set
            {
                this.canExpand = value;
                this.Draw();
            }
        }

        // Token: 0x1700006E RID: 110
        // (get) Token: 0x060001E8 RID: 488 RVA: 0x000116D8 File Offset: 0x0000F8D8
        // (set) Token: 0x060001E9 RID: 489 RVA: 0x000116F0 File Offset: 0x0000F8F0
        public Size SizeNormal
        {
            get
            {
                return this.szNormal;
            }
            set
            {
                this.szNormal = value;
                this.Expand(this.Expanded);
                this.Draw();
            }
        }

        // Token: 0x1700006F RID: 111
        // (get) Token: 0x060001EA RID: 490 RVA: 0x00011710 File Offset: 0x0000F910
        // (set) Token: 0x060001EB RID: 491 RVA: 0x00011728 File Offset: 0x0000F928
        public int MaxHeight
        {
            get
            {
                return this.expandMaxY;
            }
            set
            {
                if (value >= this.szNormal.Height)
                {
                    if (value <= 2000)
                    {
                        this.expandMaxY = value;
                        this.Draw();
                    }
                }
            }
        }

        // Token: 0x17000070 RID: 112
        // (get) Token: 0x060001EC RID: 492 RVA: 0x00011770 File Offset: 0x0000F970
        // (set) Token: 0x060001ED RID: 493 RVA: 0x00011788 File Offset: 0x0000F988
        public int ScrollBarWidth
        {
            get
            {
                return this.ScrollWidth;
            }
            set
            {
                if (value > 0 & (double)value < (double)base.Width / 2.0)
                {
                    this.ScrollWidth = value;
                }
                this.Recalculate(false);
                this.Draw();
            }
        }

        // Token: 0x17000071 RID: 113
        // (get) Token: 0x060001EE RID: 494 RVA: 0x000117D0 File Offset: 0x0000F9D0
        // (set) Token: 0x060001EF RID: 495 RVA: 0x000117E8 File Offset: 0x0000F9E8
        public Color ScrollBarColor
        {
            get
            {
                return this.scBarColor;
            }
            set
            {
                this.scBarColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000072 RID: 114
        // (get) Token: 0x060001F0 RID: 496 RVA: 0x000117FC File Offset: 0x0000F9FC
        // (set) Token: 0x060001F1 RID: 497 RVA: 0x00011814 File Offset: 0x0000FA14
        public Color ScrollButtonColor
        {
            get
            {
                return this.scButtonColor;
            }
            set
            {
                this.scButtonColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000073 RID: 115
        // (get) Token: 0x060001F2 RID: 498 RVA: 0x00011828 File Offset: 0x0000FA28
        public int ContentHeight
        {
            get
            {
                return base.Height;
            }
        }

        // Token: 0x17000074 RID: 116
        // (get) Token: 0x060001F3 RID: 499 RVA: 0x00011840 File Offset: 0x0000FA40
        public int DesiredHeight
        {
            get
            {
                return checked(this.GetTotalLineCount() * this.LineHeight);
            }
        }

        // Token: 0x17000075 RID: 117
        // (get) Token: 0x060001F4 RID: 500 RVA: 0x00011860 File Offset: 0x0000FA60
        public int ActualLineHeight
        {
            get
            {
                return this.LineHeight;
            }
        }

        // Token: 0x060001F5 RID: 501 RVA: 0x00011878 File Offset: 0x0000FA78
        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && this.components != null)
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Token: 0x060001F6 RID: 502 RVA: 0x000118C8 File Offset: 0x0000FAC8
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleMode = AutoScaleMode.Inherit;
            this.DoubleBuffered = true;
            base.Name = "ListLabelV2";
            Size size = new Size(150, 210);
            base.Size = size;
            base.ResumeLayout(false);
        }

        // Token: 0x060001F7 RID: 503 RVA: 0x0001191B File Offset: 0x0000FB1B
        private void ListLabelV2_FontChanged(object sender, EventArgs e)
        {
            this.Recalculate(false);
            this.Draw();
        }

        // Token: 0x060001F8 RID: 504 RVA: 0x0001192D File Offset: 0x0000FB2D
        private void ListLabelV2_Load(object sender, EventArgs e)
        {
            this.szNormal = base.Size;
            this.DisableRedraw = true;
            this.InitBuffer();
            this.Recalculate(false);
            this.FillDefaultItems();
            this.DisableRedraw = false;
        }

        // Token: 0x060001F9 RID: 505 RVA: 0x00011960 File Offset: 0x0000FB60
        private void FillDefaultItems()
        {
            this.ClearItems();
            this.AddItem(new ListLabelV2.ListLabelItemV2("Header Item", ListLabelV2.LLItemState.Heading, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Enabled", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Disabled Item", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Selected Item", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold | ListLabelV2.LLFontFlags.Italic, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("SD Item", ListLabelV2.LLItemState.SelectedDisabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Invalid Item", ListLabelV2.LLItemState.Invalid, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Automatic multiline Item", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Scrollable", ListLabelV2.LLItemState.Heading, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 1", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 2", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 3", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 4", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 5", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 6", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 7", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 8", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 9", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 10", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 11", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 12", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 13", ListLabelV2.LLItemState.Invalid, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 14", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.AddItem(new ListLabelV2.ListLabelItemV2("Item 15", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
            this.Draw();
        }

        // Token: 0x060001FA RID: 506 RVA: 0x00011C00 File Offset: 0x0000FE00
        public void AddItem(ListLabelV2.ListLabelItemV2 iItem)
        {
            this.DisableEvents = true;
            int num = this.Items.Length;
            this.Items = (ListLabelV2.ListLabelItemV2[])Utils.CopyArray(this.Items, new ListLabelV2.ListLabelItemV2[checked(num + 1)]);
            this.Items[num] = iItem;
            this.Items[num].Index = num;
            this.WrapString(num);
            this.GetScrollSteps();
            this.DisableEvents = false;
        }

        // Token: 0x060001FB RID: 507 RVA: 0x00011C69 File Offset: 0x0000FE69
        public void ClearItems()
        {
            this.Items = new ListLabelV2.ListLabelItemV2[0];
            this.ScrollOffset = 0;
            this.HoverIndex = -1;
        }

        // Token: 0x060001FC RID: 508 RVA: 0x00011C88 File Offset: 0x0000FE88
        private void SetLineHeight()
        {
            Font font = new Font(this.Font, this.Font.Style);
            this.LineHeight = checked((int)Math.Round((double)(unchecked(font.GetHeight() + (float)(checked(this.yPadding * 2))))));
            this.VisibleLineCount = this.GetVisibleLineCount();
        }

        // Token: 0x060001FD RID: 509 RVA: 0x00011CD8 File Offset: 0x0000FED8
        private void Recalculate(bool Expanded = false)
        {
            checked
            {
                if (this.Items.Length != 0)
                {
                    this.InitBuffer();
                    if (this.AutoSize)
                    {
                        if (base.AutoSizeMode == AutoSizeMode.GrowAndShrink)
                        {
                            base.Height = this.DesiredHeight;
                        }
                        else if (this.DesiredHeight > this.SizeNormal.Height)
                        {
                            base.Height = this.DesiredHeight;
                        }
                        else
                        {
                            base.Height = this.SizeNormal.Height;
                        }
                    }
                    Rectangle bRect = new Rectangle(this.xPadding, 0, base.Width - this.xPadding * 2, base.Height);
                    this.RecalcLines(bRect);
                    if (this.ScrollSteps > 0 | this.Expanded)
                    {
                        bRect = new Rectangle(this.xPadding, 0, base.Width - this.xPadding * 2, base.Height - (this.ScrollWidth + this.yPadding));
                        this.RecalcLines(bRect);
                    }
                    if (!Expanded && this.ScrollSteps > 0)
                    {
                        int num = 0;
                        if (this.canExpand)
                        {
                            num = this.ScrollWidth + this.yPadding;
                        }
                        bRect = new Rectangle(this.xPadding, 0, base.Width - (this.xPadding * 2 + this.ScrollWidth), base.Height - num);
                        this.RecalcLines(bRect);
                    }
                }
            }
        }

        // Token: 0x060001FE RID: 510 RVA: 0x00011E68 File Offset: 0x00010068
        private void RecalcLines(Rectangle bRect)
        {
            this.TextArea = bRect;
            this.SetLineHeight();
            int num = 0;
            checked
            {
                int num2 = this.Items.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    this.WrapString(i);
                }
                this.GetTotalLineCount();
                this.GetScrollSteps();
            }
        }

        // Token: 0x060001FF RID: 511 RVA: 0x00011EC0 File Offset: 0x000100C0
        private void WrapString(int Index)
        {
            checked
            {
                if (Operators.CompareString(this.Items[Index].Text, "", false) != 0)
                {
                    this.InitBuffer();
                    int num = 1;
                    if (this.Items[Index].Text.Contains(" "))
                    {
                        string[] array = this.Items[Index].Text.Split(" ".ToCharArray());
                        StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
                        Font font = new Font(this.Font, (FontStyle)this.Items[Index].FontFlags);
                        string str = "";
                        if (this.Items[Index].ItemState == ListLabelV2.LLItemState.Heading)
                        {
                            str = "~  ~";
                        }
                        string text = array[0];
                        int num2 = 1;
                        int num3 = array.Length - 1;
                        for (int i = num2; i <= num3; i++)
                        {
                            Graphics graphics = this.bxBuffer.Graphics;
                            string text2 = text + " " + array[i] + str;
                            Font font2 = font;
                            SizeF layoutArea = new SizeF(1024f, (float)base.Height);
                            if (Math.Ceiling((double)graphics.MeasureString(text2, font2, layoutArea, stringFormat).Width) > (double)this.TextArea.Width)
                            {
                                if (this.Items[Index].ItemState == ListLabelV2.LLItemState.Heading)
                                {
                                    text = text + " ~\r\n~ " + array[i];
                                }
                                else
                                {
                                    text = text + "\r\n " + array[i];
                                }
                                num++;
                            }
                            else
                            {
                                text = text + " " + array[i];
                            }
                        }
                        this.Items[Index].WrappedText = text;
                    }
                    else
                    {
                        this.Items[Index].WrappedText = this.Items[Index].Text;
                    }
                    if (this.Items[Index].ItemState == ListLabelV2.LLItemState.Heading)
                    {
                        this.Items[Index].WrappedText = "~ " + this.Items[Index].WrappedText + " ~";
                    }
                    this.Items[Index].LineCount = num;
                    this.Items[Index].ItemHeight = num * (this.LineHeight - this.yPadding * 2) + this.yPadding * 2;
                }
            }
        }

        // Token: 0x06000200 RID: 512 RVA: 0x00012138 File Offset: 0x00010338
        private void InitBuffer()
        {
            if (!this.DisableRedraw)
            {
                if (!((base.Width == 0 | base.Height == 0) & this.bxBuffer == null))
                {
                    if (this.bxBuffer == null)
                    {
                        this.bxBuffer = new ExtendedBitmap(base.Width, base.Height);
                    }
                    if (this.bxBuffer.Size.Width != base.Width | this.bxBuffer.Size.Height != base.Height)
                    {
                        this.bxBuffer.Dispose();
                        this.bxBuffer = null;
                        GC.Collect();
                        if (base.Height == 0 | base.Width == 0)
                        {
                            return;
                        }
                        this.bxBuffer = new ExtendedBitmap(base.Width, base.Height);
                    }
                    this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    this.bxBuffer.Graphics.TextContrast = 0;
                }
            }
        }

        // Token: 0x06000201 RID: 513 RVA: 0x00012264 File Offset: 0x00010464
        private int GetRealTotalHeight()
        {
            int num = 0;
            int num2 = 0;
            checked
            {
                int num3 = this.Items.Length - 1;
                for (int i = num2; i <= num3; i++)
                {
                    num += this.Items[i].ItemHeight;
                }
                return num;
            }
        }

        // Token: 0x06000202 RID: 514 RVA: 0x000122B0 File Offset: 0x000104B0
        private void Draw()
        {
            checked
            {
                if (!this.DisableRedraw)
                {
                    if (base.Visible)
                    {
                        this.InitBuffer();
                        if (!(base.Width == 0 | base.Height == 0))
                        {
                            if (this.Expanded)
                            {
                                this.bxBuffer.Graphics.Clear(Color.Black);
                            }
                            else
                            {
                                this.bxBuffer.Graphics.Clear(this.BackColor);
                            }
                            int scrollOffset = this.ScrollOffset;
                            int num = this.Items.Length - 1;
                            for (int i = scrollOffset; i <= num; i++)
                            {
                                this.DrawItem(i);
                            }
                            this.DrawScrollBar();
                            this.DrawExpandButton();
                            Graphics graphics = base.CreateGraphics();
                            graphics.DrawImageUnscaled(this.bxBuffer.Bitmap, 0, 0);
                        }
                    }
                }
            }
        }

        // Token: 0x06000203 RID: 515 RVA: 0x000123AC File Offset: 0x000105AC
        protected void DrawItem(int Index)
        {
            checked
            {
                if (Index >= 0)
                {
                    if (Index >= this.ScrollOffset)
                    {
                        if (Index <= this.Items.Length - 1)
                        {
                            int num = 0;
                            int scrollOffset = this.ScrollOffset;
                            int num2 = Index - 1;
                            for (int i = scrollOffset; i <= num2; i++)
                            {
                                num += this.Items[i].ItemHeight;
                                if (num > base.Height)
                                {
                                    return;
                                }
                            }
                            int height = this.Items[Index].ItemHeight;
                            if (this.Items[Index].LineCount == 1)
                            {
                                if (num + this.Items[Index].ItemHeight > this.TextArea.Height)
                                {
                                    return;
                                }
                            }
                            else if (num + this.Items[Index].ItemHeight > this.TextArea.Height)
                            {
                                if (num + this.LineHeight > this.TextArea.Height)
                                {
                                    return;
                                }
                                height = this.LineHeight - this.yPadding;
                            }
                            Rectangle rectangle = new Rectangle(this.TextArea.Left, num, this.TextArea.Width, height);
                            StringFormat stringFormat = new StringFormat();
                            switch (this.Items[Index].TextAlign)
                            {
                                case ListLabelV2.LLTextAlign.Left:
                                    stringFormat.Alignment = StringAlignment.Near;
                                    break;
                                case ListLabelV2.LLTextAlign.Center:
                                    stringFormat.Alignment = StringAlignment.Center;
                                    break;
                                case ListLabelV2.LLTextAlign.Right:
                                    stringFormat.Alignment = StringAlignment.Far;
                                    break;
                            }
                            FontStyle fontStyle = FontStyle.Regular;
                            if (this.Items[Index].Bold)
                            {
                                fontStyle++;
                            }
                            if (this.Items[Index].Italic)
                            {
                                fontStyle += 2;
                            }
                            if (this.Items[Index].Underline)
                            {
                                fontStyle += 4;
                            }
                            if (this.Items[Index].Strikethrough)
                            {
                                fontStyle += 8;
                            }
                            Font font = new Font(this.Font, fontStyle);
                            if (Index == this.HoverID && this.HighlightOn[(int)this.Items[Index].ItemState])
                            {
                                SolidBrush brush = new SolidBrush(this.hvrColor);
                                this.bxBuffer.Graphics.FillRectangle(brush, rectangle);
                            }
                            SolidBrush brush2 = new SolidBrush(Color.Black);
                            if (this.TextOutline)
                            {
                                Rectangle r = rectangle;
                                r.X--;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.Y--;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.X++;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.X++;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.Y++;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.Y++;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.X--;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                                r.X--;
                                this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, r, stringFormat);
                            }
                            brush2 = new SolidBrush(this.Colours[(int)this.Items[Index].ItemState]);
                            this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, brush2, rectangle, stringFormat);
                        }
                    }
                }
            }
        }

        // Token: 0x06000204 RID: 516 RVA: 0x00012890 File Offset: 0x00010A90
        private int GetVisibleLineCount()
        {
            int result;
            if (!this.canScroll)
            {
                this.ScrollSteps = 0;
                result = 0;
            }
            else if (this.Expanded)
            {
                result = this.GetTotalLineCount();
            }
            else
            {
                result = checked((int)Math.Round(Conversion.Int((double)this.TextArea.Height / (double)this.LineHeight)));
            }
            return result;
        }

        // Token: 0x06000205 RID: 517 RVA: 0x000128F0 File Offset: 0x00010AF0
        private int GetTotalLineCount()
        {
            int num = 0;
            int num2 = 0;
            checked
            {
                int num3 = this.Items.Length - 1;
                for (int i = num2; i <= num3; i++)
                {
                    num += this.Items[i].LineCount;
                }
                return num;
            }
        }

        // Token: 0x06000206 RID: 518 RVA: 0x0001293C File Offset: 0x00010B3C
        private int GetScrollSteps()
        {
            checked
            {
                int result;
                if (!this.canScroll)
                {
                    this.ScrollSteps = 0;
                    result = 0;
                }
                else
                {
                    int num = 0;
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = this.Items.Length - 1;
                    for (int i = num3; i <= num4; i++)
                    {
                        num += this.Items[i].LineCount;
                        if (num > this.VisibleLineCount)
                        {
                            num2++;
                        }
                    }
                    if (num2 > 0)
                    {
                        num2++;
                    }
                    this.ScrollSteps = num2;
                    if (this.ScrollSteps <= 1)
                    {
                        this.ScrollSteps = 0;
                    }
                    result = this.ScrollSteps;
                }
                return result;
            }
        }

        // Token: 0x06000207 RID: 519 RVA: 0x000129FC File Offset: 0x00010BFC
        private void DrawScrollBar()
        {
            if (!(this.ScrollWidth < 1 | !this.canScroll | this.ScrollSteps < 1))
            {
                SolidBrush brush = new SolidBrush(this.scBarColor);
                Pen pen = new Pen(this.scBarColor);
                Pen pen2 = new Pen(Color.FromArgb(96, 255, 255, 255), 1f);
                Pen pen3 = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
                PointF[] array;
                Rectangle rect;
                checked
                {
                    this.bxBuffer.Graphics.DrawLine(pen, (int)Math.Round(unchecked((double)this.TextArea.Right + (double)this.ScrollWidth / 2.0)), this.yPadding + this.ScrollWidth, (int)Math.Round(unchecked((double)this.TextArea.Right + (double)this.ScrollWidth / 2.0)), base.Height - (this.ScrollWidth + this.yPadding));
                    brush = new SolidBrush(this.scButtonColor);
                    array = new PointF[3];
                    if (this.ScrollSteps > 0)
                    {
                        int num = base.Height - (this.yPadding + this.ScrollWidth) * 2 - this.yPadding * 2;
                        int y = (int)Math.Round(unchecked((double)(checked(this.ScrollWidth + this.yPadding * 2)) + (double)num / (double)this.ScrollSteps * (double)this.ScrollOffset));
                        int height = (int)Math.Round((double)num / (double)this.ScrollSteps);
                        rect = new Rectangle(this.TextArea.Right, y, this.ScrollWidth, height);
                        this.bxBuffer.Graphics.FillRectangle(brush, rect);
                        this.bxBuffer.Graphics.DrawLine(pen2, rect.Left, rect.Top, rect.Left, rect.Bottom);
                        this.bxBuffer.Graphics.DrawLine(pen2, rect.Left + 1, rect.Top, rect.Right, rect.Top);
                        this.bxBuffer.Graphics.DrawLine(pen3, rect.Right, rect.Top, rect.Right, rect.Bottom);
                        this.bxBuffer.Graphics.DrawLine(pen3, rect.Left + 1, rect.Bottom, rect.Right - 1, rect.Bottom);
                    }
                    rect = new Rectangle(this.TextArea.Right, this.yPadding + this.ScrollWidth, this.ScrollWidth, base.Height - (this.ScrollWidth + this.yPadding) * 2);
                    array[0] = new PointF((float)rect.Left, (float)rect.Top);
                    array[1] = new PointF((float)rect.Right, (float)rect.Top);
                }
                array[2] = new PointF((float)rect.Left + (float)rect.Width / 2f, (float)this.yPadding);
                this.bxBuffer.Graphics.FillPolygon(brush, array);
                this.bxBuffer.Graphics.DrawLine(pen2, array[0], array[2]);
                this.bxBuffer.Graphics.DrawLine(pen3, array[0], array[1]);
                array[0] = new PointF((float)rect.Left, (float)rect.Bottom);
                array[1] = new PointF((float)rect.Right, (float)rect.Bottom);
                array[2] = new PointF((float)rect.Left + (float)rect.Width / 2f, (float)(checked(base.Height - this.yPadding)));
                this.bxBuffer.Graphics.FillPolygon(brush, array);
                this.bxBuffer.Graphics.DrawLine(pen2, array[0], array[1]);
                this.bxBuffer.Graphics.DrawLine(pen3, array[2], array[1]);
            }
        }

        // Token: 0x06000208 RID: 520 RVA: 0x00012E84 File Offset: 0x00011084
        private void DrawExpandButton()
        {
            if (!(!this.canExpand | (!this.Expanded & this.ScrollSteps < 1)))
            {
                SolidBrush brush = new SolidBrush(this.scButtonColor);
                Pen pen = new Pen(this.scBarColor);
                Pen pen2 = new Pen(Color.FromArgb(96, 255, 255, 255), 1f);
                Pen pen3 = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
                brush = new SolidBrush(this.scButtonColor);
                PointF[] array = new PointF[3];
                Rectangle rectangle = checked(new Rectangle((int)Math.Round((double)base.Width / 3.0), base.Height - (this.ScrollWidth + this.yPadding), (int)Math.Round((double)base.Width / 3.0), this.ScrollWidth - this.yPadding));
                if (this.Expanded)
                {
                    array[0] = new PointF((float)rectangle.Left, (float)rectangle.Bottom);
                    array[1] = new PointF((float)rectangle.Right, (float)rectangle.Bottom);
                    array[2] = new PointF((float)rectangle.Left + (float)rectangle.Width / 2f, (float)rectangle.Top);
                    this.bxBuffer.Graphics.FillPolygon(brush, array);
                    this.bxBuffer.Graphics.DrawLine(pen2, array[0], array[2]);
                    this.bxBuffer.Graphics.DrawLine(pen3, array[0], array[1]);
                    checked
                    {
                        this.bxBuffer.Graphics.DrawLine(pen, 0, 0, 0, base.Height - 1);
                        this.bxBuffer.Graphics.DrawLine(pen, 0, base.Height - 1, base.Width - 1, base.Height - 1);
                        this.bxBuffer.Graphics.DrawLine(pen, base.Width - 1, base.Height, base.Width - 1, 0);
                    }
                }
                else
                {
                    array[0] = new PointF((float)rectangle.Left, (float)rectangle.Top);
                    array[1] = new PointF((float)rectangle.Right, (float)rectangle.Top);
                    array[2] = new PointF((float)rectangle.Left + (float)rectangle.Width / 2f, (float)rectangle.Bottom);
                    this.bxBuffer.Graphics.FillPolygon(brush, array);
                    this.bxBuffer.Graphics.DrawLine(pen2, array[0], array[1]);
                    this.bxBuffer.Graphics.DrawLine(pen3, array[2], array[1]);
                }
            }
        }

        // Token: 0x06000209 RID: 521 RVA: 0x000131CC File Offset: 0x000113CC
        private int GetItemAtY(int Y)
        {
            int num = 0;
            checked
            {
                int result;
                if (Y > base.Height)
                {
                    result = -1;
                }
                else
                {
                    int scrollOffset = this.ScrollOffset;
                    int num2 = this.Items.Length - 1;
                    for (int i = scrollOffset; i <= num2; i++)
                    {
                        num += this.Items[i].ItemHeight;
                        if (Y < num)
                        {
                            return i;
                        }
                    }
                    result = -1;
                }
                return result;
            }
        }

        // Token: 0x0600020A RID: 522 RVA: 0x00013248 File Offset: 0x00011448
        private ListLabelV2.eMouseTarget GetMouseTarget(int X, int Y)
        {
            checked
            {
                ListLabelV2.eMouseTarget result;
                if (X >= this.TextArea.Left & X <= this.TextArea.Right & Y <= this.TextArea.Bottom)
                {
                    result = ListLabelV2.eMouseTarget.Item;
                }
                else if (X >= this.TextArea.Left & X <= this.TextArea.Right & Y > this.TextArea.Bottom)
                {
                    result = ListLabelV2.eMouseTarget.ExpandButton;
                }
                else if (X > this.TextArea.Right & Y <= this.ScrollWidth + this.yPadding)
                {
                    result = ListLabelV2.eMouseTarget.UpButton;
                }
                else if (X > this.TextArea.Right & Y >= base.Height - (this.ScrollWidth + this.yPadding))
                {
                    result = ListLabelV2.eMouseTarget.DownButton;
                }
                else if (!(X > this.TextArea.Right & this.ScrollSteps > 0))
                {
                    result = ListLabelV2.eMouseTarget.None;
                }
                else
                {
                    int num = base.Height - (this.yPadding + this.ScrollWidth) * 2 - this.yPadding * 2;
                    int num2 = (int)Math.Round(unchecked((double)(checked(this.ScrollWidth + this.yPadding * 2)) + (double)num / (double)this.ScrollSteps * (double)this.ScrollOffset));
                    int num3 = (int)Math.Round((double)num / (double)this.ScrollSteps);
                    if (Y < num2)
                    {
                        result = ListLabelV2.eMouseTarget.ScrollBarUp;
                    }
                    else if (Y > num2 + num3)
                    {
                        result = ListLabelV2.eMouseTarget.ScrollBarDown;
                    }
                    else
                    {
                        result = ListLabelV2.eMouseTarget.ScrollBlock;
                    }
                }
                return result;
            }
        }

        // Token: 0x0600020B RID: 523 RVA: 0x000133FC File Offset: 0x000115FC
        private void ListLabelV2_MouseDown(object sender, MouseEventArgs e)
        {
            checked
            {
                if (e.Button == MouseButtons.Left & Control.ModifierKeys == (Keys.Shift | Keys.Control | Keys.Alt))
                {
                    this.DisableEvents = false;
                    this.DisableRedraw = false;
                    this.Recalculate(false);
                    this.Draw();
                    Graphics graphics = base.CreateGraphics();
                    Pen powderBlue = Pens.PowderBlue;
                    Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
                    graphics.DrawRectangle(powderBlue, rect);
                }
                else if (!this.DisableEvents)
                {
                    int num;
                    if ((double)this.ScrollSteps / 3.0 < 5.0)
                    {
                        num = (int)Math.Round((double)this.ScrollSteps / 3.0);
                    }
                    else
                    {
                        num = 5;
                    }
                    switch (this.GetMouseTarget(e.X, e.Y))
                    {
                        case ListLabelV2.eMouseTarget.Item:
                            {
                                int itemAtY = this.GetItemAtY(e.Y);
                                if (itemAtY > -1)
                                {
                                    int num2 = 0;
                                    int scrollOffset = this.ScrollOffset;
                                    int num3 = itemAtY - 1;
                                    for (int i = scrollOffset; i <= num3; i++)
                                    {
                                        num2 += this.Items[i].ItemHeight;
                                    }
                                    if ((num2 + this.Items[itemAtY].ItemHeight >= e.Y & num2 + this.Items[itemAtY].ItemHeight <= this.TextArea.Height) | (this.Items[itemAtY].LineCount > 1 & num2 + this.LineHeight >= e.Y & num2 + this.LineHeight <= this.TextArea.Height))
                                    {
                                        this.ItemClick?.Invoke(this.Items[itemAtY], e.Button);
                                    }
                                }
                                break;
                            }
                        case ListLabelV2.eMouseTarget.UpButton:
                            if (this.ScrollSteps > 0 & this.ScrollOffset > 0)
                            {
                                this.ScrollOffset--;
                                this.Draw();
                            }
                            break;
                        case ListLabelV2.eMouseTarget.DownButton:
                            if (this.ScrollSteps > 0 & this.ScrollOffset + 1 < this.ScrollSteps)
                            {
                                this.ScrollOffset++;
                                this.Draw();
                            }
                            break;
                        case ListLabelV2.eMouseTarget.ScrollBarUp:
                            if (this.ScrollSteps > 0)
                            {
                                this.ScrollOffset -= num;
                                if (this.ScrollOffset < 0)
                                {
                                    this.ScrollOffset = 0;
                                }
                                this.Draw();
                            }
                            break;
                        case ListLabelV2.eMouseTarget.ScrollBarDown:
                            if (this.ScrollSteps > 0)
                            {
                                this.ScrollOffset += num;
                                if (this.ScrollOffset >= this.ScrollSteps)
                                {
                                    this.ScrollOffset = this.ScrollSteps - 1;
                                }
                                this.Draw();
                            }
                            break;
                        case ListLabelV2.eMouseTarget.ScrollBlock:
                            if (this.ScrollSteps > 0)
                            {
                                this.DragMode = true;
                            }
                            break;
                        case ListLabelV2.eMouseTarget.ExpandButton:
                            {
                                if (!this.Expanded)
                                {
                                    this.Expanded = true;
                                    this.ScrollOffset = 0;
                                    this.RecomputeExpand();
                                }
                                else
                                {
                                    this.DisableRedraw = true;
                                    base.Height = this.szNormal.Height;
                                    this.Expanded = false;
                                    this.Recalculate(false);
                                    this.DisableRedraw = false;
                                    this.Draw();
                                }
                                this.ExpandChanged?.Invoke(this.Expanded);
                                break;
                            }
                    }
                }
            }
        }

        // Token: 0x0600020C RID: 524 RVA: 0x000137F0 File Offset: 0x000119F0
        private void Expand(bool State)
        {
            if (State)
            {
                this.Expanded = true;
                this.ScrollOffset = 0;
                this.RecomputeExpand();
            }
            else
            {
                this.DisableRedraw = true;
                base.Height = this.szNormal.Height;
                this.Expanded = false;
                this.Recalculate(false);
                this.DisableRedraw = false;
                this.Draw();
            }
            this.ExpandChanged?.Invoke(this.Expanded);
        }

        // Token: 0x0600020D RID: 525 RVA: 0x00013878 File Offset: 0x00011A78
        private void RecomputeExpand()
        {
            if (this.Expanded)
            {
                int num = this.expandMaxY;
                this.Recalculate(true);
                int num2 = checked(this.GetRealTotalHeight() + this.ScrollWidth + this.yPadding * 3);
                if (num2 < num)
                {
                    num = num2;
                }
                this.DisableRedraw = true;
                base.Height = num;
                this.Recalculate(false);
                this.DisableRedraw = false;
                this.Draw();
            }
        }

        // Token: 0x0600020E RID: 526 RVA: 0x000138F0 File Offset: 0x00011AF0
        private void ListLabelV2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.LastMouseMovetarget = ListLabelV2.eMouseTarget.None;
            this.HoverIndex = -1;
            this.Draw();
            this.EmptyHover?.Invoke();
        }

        // Token: 0x0600020F RID: 527 RVA: 0x00013938 File Offset: 0x00011B38
        private void ListLabelV2_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor cursor = System.Windows.Forms.Cursors.Default;
            ListLabelV2.eMouseTarget mouseTarget = this.GetMouseTarget(e.X, e.Y);
            bool flag = false;
            checked
            {
                if (!this.DragMode)
                {
                    ListLabelV2.EmptyHoverEventHandler emptyHoverEvent;
                    switch (mouseTarget)
                    {
                        case ListLabelV2.eMouseTarget.Item:
                            {
                                int itemAtY = this.GetItemAtY(e.Y);
                                if (itemAtY <= -1)
                                {
                                    if (this.HoverIndex != -1)
                                    {
                                        flag = true;
                                    }
                                    this.HoverIndex = -1;
                                    this.EmptyHover?.Invoke();
                                    goto IL_3EA;
                                }
                                int num = 0;
                                int scrollOffset = this.ScrollOffset;
                                int num2 = itemAtY - 1;
                                for (int i = scrollOffset; i <= num2; i++)
                                {
                                    num += this.Items[i].ItemHeight;
                                }
                                if (!((num + this.Items[itemAtY].ItemHeight >= e.Y & num + this.Items[itemAtY].ItemHeight <= this.TextArea.Height) | (this.Items[itemAtY].LineCount > 1 & num + this.LineHeight >= e.Y & num + this.LineHeight <= this.TextArea.Height)))
                                {
                                    if (this.HoverIndex != -1)
                                    {
                                        flag = true;
                                    }
                                    this.HoverIndex = -1;
                                    this.EmptyHover?.Invoke();
                                    goto IL_3EA;
                                }
                                cursor = this.Cursors[(int)this.Items[itemAtY].ItemState];
                                if (itemAtY != this.HoverIndex)
                                {
                                    this.HoverIndex = itemAtY;
                                }
                                this.Draw();
                                var itemHoverEvent = this.ItemHover;
                                if (itemHoverEvent != null)
                                {
                                    itemHoverEvent(this.Items[itemAtY]);
                                    goto IL_3EA;
                                }
                                goto IL_3EA;
                            }
                        case ListLabelV2.eMouseTarget.UpButton:
                            if (this.LastMouseMovetarget != mouseTarget)
                            {
                                this.Draw();
                            }
                            emptyHoverEvent = this.EmptyHover;
                            if (emptyHoverEvent != null)
                            {
                                emptyHoverEvent();
                                goto IL_3EA;
                            }
                            goto IL_3EA;
                        case ListLabelV2.eMouseTarget.DownButton:
                            if (this.LastMouseMovetarget != mouseTarget)
                            {
                                this.Draw();
                            }
                            emptyHoverEvent = this.EmptyHover;
                            if (emptyHoverEvent != null)
                            {
                                emptyHoverEvent();
                                goto IL_3EA;
                            }
                            goto IL_3EA;
                        case ListLabelV2.eMouseTarget.ExpandButton:
                            this.HoverIndex = -1;
                            emptyHoverEvent = this.EmptyHover;
                            if (emptyHoverEvent != null)
                            {
                                emptyHoverEvent();
                                goto IL_3EA;
                            }
                            goto IL_3EA;
                    }
                    emptyHoverEvent = this.EmptyHover;
                    if (emptyHoverEvent != null)
                    {
                        emptyHoverEvent();
                    }
                }
                else if (e.Button == MouseButtons.None)
                {
                    this.DragMode = false;
                }
                else
                {
                    cursor = System.Windows.Forms.Cursors.SizeNS;
                    int num3 = base.Height - (this.yPadding + this.ScrollWidth) * 2 - this.yPadding * 2;
                    int num4 = (int)Math.Round(unchecked((double)(checked(this.ScrollWidth + this.yPadding * 2)) + (double)num3 / (double)this.ScrollSteps * (double)this.ScrollOffset));
                    int num5 = (int)Math.Round((double)num3 / (double)this.ScrollSteps);
                    if (e.Y < num4 & this.ScrollOffset > 0)
                    {
                        this.ScrollOffset--;
                        this.Draw();
                    }
                    else if (e.Y > num4 + num5 & this.ScrollOffset + 1 < this.ScrollSteps)
                    {
                        this.ScrollOffset++;
                        this.Draw();
                    }
                    ListLabelV2.EmptyHoverEventHandler emptyHoverEvent = this.EmptyHover;
                    if (emptyHoverEvent != null)
                    {
                        emptyHoverEvent();
                    }
                }
            IL_3EA:
                if (flag)
                {
                    this.Draw();
                }
                this.Cursor = cursor;
                this.LastMouseMovetarget = mouseTarget;
            }
        }

        // Token: 0x06000210 RID: 528 RVA: 0x00013D54 File Offset: 0x00011F54
        private void ListLabelV2_MouseUp(object sender, MouseEventArgs e)
        {
            this.DragMode = false;
            if (this.Cursor == System.Windows.Forms.Cursors.SizeNS)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        // Token: 0x06000211 RID: 529 RVA: 0x00013D90 File Offset: 0x00011F90
        private void ListLabelV2_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxBuffer == null)
            {
                this.Draw();
            }
            if (this.bxBuffer != null)
            {
                e.Graphics.DrawImage(this.bxBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        // Token: 0x06000212 RID: 530 RVA: 0x00013DEE File Offset: 0x00011FEE
        private void ListLabelV2_Resize(object sender, EventArgs e)
        {
            this.ScrollOffset = 0;
            this.Recalculate(false);
            this.Draw();
        }

        // Token: 0x06000213 RID: 531 RVA: 0x00013E10 File Offset: 0x00012010
        public ListLabelV2()
        {
            base.MouseLeave += this.ListLabelV2_MouseLeave;
            base.MouseMove += this.ListLabelV2_MouseMove;
            base.MouseUp += this.ListLabelV2_MouseUp;
            base.Paint += this.ListLabelV2_Paint;
            base.Resize += this.ListLabelV2_Resize;
            base.FontChanged += this.ListLabelV2_FontChanged;
            base.Load += this.ListLabelV2_Load;
            base.MouseDown += this.ListLabelV2_MouseDown;
            this.bxBuffer = null;
            this.Items = new ListLabelV2.ListLabelItemV2[0];
            this.Colours = new Color[]
            {
                Color.LightBlue,
                Color.LightGreen,
                Color.LightGray,
                Color.DarkGreen,
                Color.Red,
                Color.Orange
            };
            this.Cursors = new Cursor[]
            {
                System.Windows.Forms.Cursors.Hand,
                System.Windows.Forms.Cursors.Hand,
                System.Windows.Forms.Cursors.Default,
                System.Windows.Forms.Cursors.Hand,
                System.Windows.Forms.Cursors.Hand,
                System.Windows.Forms.Cursors.Default
            };
            this.HighlightOn = new bool[]
            {
                true,
                true,
                true,
                true,
                true,
                true,
                false
            };
            this.bgColor = Color.Black;
            this.hvrColor = Color.WhiteSmoke;
            this.TextOutline = true;
            this.xPadding = 1;
            this.yPadding = 1;
            this.LineHeight = 8;
            this.HoverIndex = -1;
            this.DisableRedraw = true;
            this.DisableEvents = false;
            this.canScroll = true;
            this.ScrollOffset = 0;
            this.canExpand = false;
            this.Expanded = false;
            this.szNormal = base.Size;
            this.expandMaxY = 400;
            this.TextArea = new Rectangle(0, 0, base.Width, base.Height);
            this.ScrollWidth = 8;
            this.scBarColor = Color.FromArgb(128, 96, 192);
            this.scButtonColor = Color.FromArgb(96, 0, 192);
            this.ScrollSteps = 0;
            this.DragMode = false;
            this.LastMouseMovetarget = ListLabelV2.eMouseTarget.None;
            this.VisibleLineCount = 0;
            this.InitializeComponent();
        }

        // Token: 0x040000D7 RID: 215
        private IContainer components;

        // Token: 0x040000D8 RID: 216
        private ExtendedBitmap bxBuffer;

        // Token: 0x040000D9 RID: 217
        public ListLabelV2.ListLabelItemV2[] Items;

        // Token: 0x040000DA RID: 218
        protected Color[] Colours;

        // Token: 0x040000DB RID: 219
        protected Cursor[] Cursors;

        // Token: 0x040000DC RID: 220
        protected bool[] HighlightOn;

        // Token: 0x040000DD RID: 221
        protected Color bgColor;

        // Token: 0x040000DE RID: 222
        protected Color hvrColor;

        // Token: 0x040000DF RID: 223
        protected bool TextOutline;

        // Token: 0x040000E0 RID: 224
        protected int xPadding;

        // Token: 0x040000E1 RID: 225
        protected int yPadding;

        // Token: 0x040000E2 RID: 226
        protected int LineHeight;

        // Token: 0x040000E3 RID: 227
        protected int HoverIndex;

        // Token: 0x040000E4 RID: 228
        protected bool DisableRedraw;

        // Token: 0x040000E5 RID: 229
        protected bool DisableEvents;

        // Token: 0x040000E6 RID: 230
        protected bool canScroll;

        // Token: 0x040000E7 RID: 231
        protected int ScrollOffset;

        // Token: 0x040000E8 RID: 232
        protected bool canExpand;

        // Token: 0x040000E9 RID: 233
        protected bool Expanded;

        // Token: 0x040000EA RID: 234
        protected Size szNormal;

        // Token: 0x040000EB RID: 235
        protected int expandMaxY;

        // Token: 0x040000EC RID: 236
        protected Rectangle TextArea;

        // Token: 0x040000ED RID: 237
        protected int ScrollWidth;

        // Token: 0x040000EE RID: 238
        protected Color scBarColor;

        // Token: 0x040000EF RID: 239
        protected Color scButtonColor;

        // Token: 0x040000F0 RID: 240
        protected int ScrollSteps;

        // Token: 0x040000F1 RID: 241
        protected bool DragMode;

        // Token: 0x040000F2 RID: 242
        private ListLabelV2.eMouseTarget LastMouseMovetarget;

        // Token: 0x040000F3 RID: 243
        private int VisibleLineCount;

        // Token: 0x0200001F RID: 31
        public enum LLItemState
        {
            // Token: 0x040000F9 RID: 249
            Enabled,
            // Token: 0x040000FA RID: 250
            Selected,
            // Token: 0x040000FB RID: 251
            Disabled,
            // Token: 0x040000FC RID: 252
            SelectedDisabled,
            // Token: 0x040000FD RID: 253
            Invalid,
            // Token: 0x040000FE RID: 254
            Heading
        }

        // Token: 0x02000020 RID: 32
        [Flags]
        public enum LLFontFlags
        {
            // Token: 0x04000100 RID: 256
            Normal = 0,
            // Token: 0x04000101 RID: 257
            Bold = 1,
            // Token: 0x04000102 RID: 258
            Italic = 2,
            // Token: 0x04000103 RID: 259
            Underline = 4,
            // Token: 0x04000104 RID: 260
            Strikethrough = 8
        }

        // Token: 0x02000021 RID: 33
        public enum LLTextAlign
        {
            // Token: 0x04000106 RID: 262
            Left,
            // Token: 0x04000107 RID: 263
            Center,
            // Token: 0x04000108 RID: 264
            Right
        }

        // Token: 0x02000022 RID: 34
        private enum eMouseTarget
        {
            // Token: 0x0400010A RID: 266
            None,
            // Token: 0x0400010B RID: 267
            Item,
            // Token: 0x0400010C RID: 268
            UpButton,
            // Token: 0x0400010D RID: 269
            DownButton,
            // Token: 0x0400010E RID: 270
            ScrollBarUp,
            // Token: 0x0400010F RID: 271
            ScrollBarDown,
            // Token: 0x04000110 RID: 272
            ScrollBlock,
            // Token: 0x04000111 RID: 273
            ExpandButton
        }

        // Token: 0x02000023 RID: 35
        public class ListLabelItemV2
        {
            // Token: 0x17000076 RID: 118
            // (get) Token: 0x06000214 RID: 532 RVA: 0x00014084 File Offset: 0x00012284
            // (set) Token: 0x06000215 RID: 533 RVA: 0x0001409C File Offset: 0x0001229C
            public string Text
            {
                get
                {
                    return this.Txt;
                }
                set
                {
                    this.Txt = value;
                }
            }

            // Token: 0x17000077 RID: 119
            // (get) Token: 0x06000216 RID: 534 RVA: 0x000140A8 File Offset: 0x000122A8
            // (set) Token: 0x06000217 RID: 535 RVA: 0x000140C0 File Offset: 0x000122C0
            public ListLabelV2.LLItemState ItemState
            {
                get
                {
                    return this.State;
                }
                set
                {
                    this.State = value;
                }
            }

            // Token: 0x17000078 RID: 120
            // (get) Token: 0x06000218 RID: 536 RVA: 0x000140CC File Offset: 0x000122CC
            // (set) Token: 0x06000219 RID: 537 RVA: 0x000140EC File Offset: 0x000122EC
            public bool Bold
            {
                get
                {
                    return (this.FontFlags & ListLabelV2.LLFontFlags.Bold) > ListLabelV2.LLFontFlags.Normal;
                }
                set
                {
                    checked
                    {
                        if (value)
                        {
                            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Bold) > ListLabelV2.LLFontFlags.Normal)
                            {
                                this.FontFlags++;
                            }
                        }
                        else if ((this.FontFlags & ListLabelV2.LLFontFlags.Bold) > ListLabelV2.LLFontFlags.Normal)
                        {
                            this.FontFlags--;
                        }
                    }
                }
            }

            // Token: 0x17000079 RID: 121
            // (get) Token: 0x0600021A RID: 538 RVA: 0x00014150 File Offset: 0x00012350
            // (set) Token: 0x0600021B RID: 539 RVA: 0x00014170 File Offset: 0x00012370
            public bool Italic
            {
                get
                {
                    return (this.FontFlags & ListLabelV2.LLFontFlags.Italic) > ListLabelV2.LLFontFlags.Normal;
                }
                set
                {
                    checked
                    {
                        if (value)
                        {
                            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Italic) > ListLabelV2.LLFontFlags.Normal)
                            {
                                this.FontFlags += 2;
                            }
                        }
                        else if ((this.FontFlags & ListLabelV2.LLFontFlags.Italic) > ListLabelV2.LLFontFlags.Normal)
                        {
                            this.FontFlags -= 2;
                        }
                    }
                }
            }

            // Token: 0x1700007A RID: 122
            // (get) Token: 0x0600021C RID: 540 RVA: 0x000141D4 File Offset: 0x000123D4
            // (set) Token: 0x0600021D RID: 541 RVA: 0x000141F4 File Offset: 0x000123F4
            public bool Underline
            {
                get
                {
                    return (this.FontFlags & ListLabelV2.LLFontFlags.Underline) > ListLabelV2.LLFontFlags.Normal;
                }
                set
                {
                    checked
                    {
                        if (value)
                        {
                            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Underline) > ListLabelV2.LLFontFlags.Normal)
                            {
                                this.FontFlags += 4;
                            }
                        }
                        else if ((this.FontFlags & ListLabelV2.LLFontFlags.Underline) > ListLabelV2.LLFontFlags.Normal)
                        {
                            this.FontFlags -= 4;
                        }
                    }
                }
            }

            // Token: 0x1700007B RID: 123
            // (get) Token: 0x0600021E RID: 542 RVA: 0x00014258 File Offset: 0x00012458
            // (set) Token: 0x0600021F RID: 543 RVA: 0x00014278 File Offset: 0x00012478
            public bool Strikethrough
            {
                get
                {
                    return (this.FontFlags & ListLabelV2.LLFontFlags.Strikethrough) > ListLabelV2.LLFontFlags.Normal;
                }
                set
                {
                    checked
                    {
                        if (value)
                        {
                            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Strikethrough) > ListLabelV2.LLFontFlags.Normal)
                            {
                                this.FontFlags += 8;
                            }
                        }
                        else if ((this.FontFlags & ListLabelV2.LLFontFlags.Strikethrough) > ListLabelV2.LLFontFlags.Normal)
                        {
                            this.FontFlags -= 8;
                        }
                    }
                }
            }

            // Token: 0x1700007C RID: 124
            // (get) Token: 0x06000220 RID: 544 RVA: 0x000142DC File Offset: 0x000124DC
            // (set) Token: 0x06000221 RID: 545 RVA: 0x000142F4 File Offset: 0x000124F4
            public ListLabelV2.LLTextAlign TextAlign
            {
                get
                {
                    return this.Alignment;
                }
                set
                {
                    this.Alignment = value;
                }
            }

            // Token: 0x06000222 RID: 546 RVA: 0x00014300 File Offset: 0x00012500
            public ListLabelItemV2()
            {
                this.Txt = "";
                this.WrappedText = "";
                this.State = ListLabelV2.LLItemState.Enabled;
                this.FontFlags = ListLabelV2.LLFontFlags.Normal;
                this.Alignment = ListLabelV2.LLTextAlign.Left;
                this.nIDSet = -1;
                this.IDXPower = -1;
                this.nIDPower = -1;
                this.sTag = "";
                this.LineCount = 1;
                this.ItemHeight = 1;
                this.Index = -1;
            }

            // Token: 0x06000223 RID: 547 RVA: 0x00014378 File Offset: 0x00012578
            public ListLabelItemV2(string iText, ListLabelV2.LLItemState iState, int inIDSet = -1, int iIDXPower = -1, int inIDPower = -1, string iStringTag = "", ListLabelV2.LLFontFlags iFont = ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign iAlign = ListLabelV2.LLTextAlign.Left)
            {
                this.Txt = "";
                this.WrappedText = "";
                this.State = ListLabelV2.LLItemState.Enabled;
                this.FontFlags = ListLabelV2.LLFontFlags.Normal;
                this.Alignment = ListLabelV2.LLTextAlign.Left;
                this.nIDSet = -1;
                this.IDXPower = -1;
                this.nIDPower = -1;
                this.sTag = "";
                this.LineCount = 1;
                this.ItemHeight = 1;
                this.Index = -1;
                this.Txt = iText;
                this.State = iState;
                this.nIDSet = inIDSet;
                this.IDXPower = iIDXPower;
                this.nIDPower = inIDPower;
                this.sTag = iStringTag;
                this.FontFlags = iFont;
                this.Alignment = iAlign;
            }

            // Token: 0x06000224 RID: 548 RVA: 0x0001442C File Offset: 0x0001262C
            public ListLabelItemV2(ListLabelV2.ListLabelItemV2 Template)
            {
                this.Txt = "";
                this.WrappedText = "";
                this.State = ListLabelV2.LLItemState.Enabled;
                this.FontFlags = ListLabelV2.LLFontFlags.Normal;
                this.Alignment = ListLabelV2.LLTextAlign.Left;
                this.nIDSet = -1;
                this.IDXPower = -1;
                this.nIDPower = -1;
                this.sTag = "";
                this.LineCount = 1;
                this.ItemHeight = 1;
                this.Index = -1;
                this.Txt = Template.Txt;
                this.State = Template.State;
                this.FontFlags = Template.FontFlags;
                this.Alignment = Template.Alignment;
                this.LineCount = Template.LineCount;
                this.ItemHeight = Template.ItemHeight;
                this.nIDSet = Template.nIDSet;
                this.IDXPower = Template.IDXPower;
                this.nIDPower = Template.nIDPower;
                this.sTag = Template.sTag;
            }

            // Token: 0x04000112 RID: 274
            protected string Txt;

            // Token: 0x04000113 RID: 275
            public string WrappedText;

            // Token: 0x04000114 RID: 276
            protected ListLabelV2.LLItemState State;

            // Token: 0x04000115 RID: 277
            public ListLabelV2.LLFontFlags FontFlags;

            // Token: 0x04000116 RID: 278
            protected ListLabelV2.LLTextAlign Alignment;

            // Token: 0x04000117 RID: 279
            public int nIDSet;

            // Token: 0x04000118 RID: 280
            public int IDXPower;

            // Token: 0x04000119 RID: 281
            public int nIDPower;

            // Token: 0x0400011A RID: 282
            protected string sTag;

            // Token: 0x0400011B RID: 283
            public int LineCount;

            // Token: 0x0400011C RID: 284
            public int ItemHeight;

            // Token: 0x0400011D RID: 285
            public int Index;
        }

    }
}
