﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    // Token: 0x0200000F RID: 15
    public class ctlPairedList : UserControl
    {
        // Token: 0x14000002 RID: 2
        // (add) Token: 0x060000D6 RID: 214 RVA: 0x00009577 File Offset: 0x00007777
        // (remove) Token: 0x060000D7 RID: 215 RVA: 0x00009591 File Offset: 0x00007791
        public event ctlPairedList.ItemClickEventHandler ItemClick;

        // Token: 0x14000003 RID: 3
        // (add) Token: 0x060000D8 RID: 216 RVA: 0x000095AB File Offset: 0x000077AB
        // (remove) Token: 0x060000D9 RID: 217 RVA: 0x000095C5 File Offset: 0x000077C5
        public event ctlPairedList.ItemHoverEventHandler ItemHover;

        // Token: 0x1700003D RID: 61
        // (get) Token: 0x060000DA RID: 218 RVA: 0x000095E0 File Offset: 0x000077E0
        // (set) Token: 0x060000DB RID: 219 RVA: 0x000095F8 File Offset: 0x000077F8
        public virtual ToolTip myTip
        {
            get
            {
                return this._myTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._myTip = value;
            }
        }

        // Token: 0x1700003E RID: 62
        // (get) Token: 0x060000DC RID: 220 RVA: 0x00009604 File Offset: 0x00007804
        // (set) Token: 0x060000DD RID: 221 RVA: 0x0000961C File Offset: 0x0000781C
        public int Columns
        {
            get
            {
                return this.myColumns;
            }
            set
            {
                if (value >= 0 & value < 10)
                {
                    this.myColumns = value;
                    this.Draw();
                }
            }
        }

        // Token: 0x1700003F RID: 63
        // (get) Token: 0x060000DE RID: 222 RVA: 0x00009650 File Offset: 0x00007850
        // (set) Token: 0x060000DF RID: 223 RVA: 0x00009668 File Offset: 0x00007868
        public int ValueWidth
        {
            get
            {
                return this.myValueWidth;
            }
            set
            {
                if (this.myColumns < 1)
                {
                    this.myColumns = 1;
                }
                if (value > 0 & value < 100)
                {
                    this.myValueWidth = value;
                }
            }
        }

        // Token: 0x17000040 RID: 64
        // (get) Token: 0x060000E0 RID: 224 RVA: 0x000096AC File Offset: 0x000078AC
        // (set) Token: 0x060000E1 RID: 225 RVA: 0x000096C4 File Offset: 0x000078C4
        public bool DoHighlight
        {
            get
            {
                return this.Highlightable;
            }
            set
            {
                this.Highlightable = value;
                this.Draw();
            }
        }

        // Token: 0x17000041 RID: 65
        // (get) Token: 0x060000E2 RID: 226 RVA: 0x000096D8 File Offset: 0x000078D8
        // (set) Token: 0x060000E3 RID: 227 RVA: 0x000096F0 File Offset: 0x000078F0
        public Color HighlightColor
        {
            get
            {
                return this.myHighlightColor;
            }
            set
            {
                this.myHighlightColor = value;
            }
        }

        // Token: 0x17000042 RID: 66
        // (get) Token: 0x060000E4 RID: 228 RVA: 0x000096FC File Offset: 0x000078FC
        // (set) Token: 0x060000E5 RID: 229 RVA: 0x00009714 File Offset: 0x00007914
        public Color HighlightTextColor
        {
            get
            {
                return this.myHighlightTextColor;
            }
            set
            {
                this.myHighlightTextColor = value;
            }
        }

        // Token: 0x17000043 RID: 67
        // (get) Token: 0x060000E6 RID: 230 RVA: 0x00009720 File Offset: 0x00007920
        // (set) Token: 0x060000E7 RID: 231 RVA: 0x00009738 File Offset: 0x00007938
        public Color NameColor
        {
            get
            {
                return this.NameColour;
            }
            set
            {
                this.NameColour = value;
            }
        }

        // Token: 0x17000044 RID: 68
        // (get) Token: 0x060000E8 RID: 232 RVA: 0x00009744 File Offset: 0x00007944
        // (set) Token: 0x060000E9 RID: 233 RVA: 0x0000975C File Offset: 0x0000795C
        public Color ItemColor
        {
            get
            {
                return this.ValueColor;
            }
            set
            {
                this.ValueColor = value;
            }
        }

        // Token: 0x17000045 RID: 69
        // (get) Token: 0x060000EA RID: 234 RVA: 0x00009768 File Offset: 0x00007968
        // (set) Token: 0x060000EB RID: 235 RVA: 0x00009780 File Offset: 0x00007980
        public Color ItemColorAlt
        {
            get
            {
                return this.ValueColorA;
            }
            set
            {
                this.ValueColorA = value;
            }
        }

        // Token: 0x17000046 RID: 70
        // (get) Token: 0x060000EC RID: 236 RVA: 0x0000978C File Offset: 0x0000798C
        // (set) Token: 0x060000ED RID: 237 RVA: 0x000097A4 File Offset: 0x000079A4
        public Color ItemColorSpecial
        {
            get
            {
                return this.ValueColorB;
            }
            set
            {
                this.ValueColorB = value;
            }
        }

        // Token: 0x17000047 RID: 71
        // (get) Token: 0x060000EE RID: 238 RVA: 0x000097B0 File Offset: 0x000079B0
        // (set) Token: 0x060000EF RID: 239 RVA: 0x000097C8 File Offset: 0x000079C8
        public Color ItemColorSpecCase
        {
            get
            {
                return this.ValueColorC;
            }
            set
            {
                this.ValueColorC = value;
            }
        }

        // Token: 0x17000048 RID: 72
        // (get) Token: 0x060000F0 RID: 240 RVA: 0x000097D4 File Offset: 0x000079D4
        public int ItemCount
        {
            get
            {
                return this.MyItems.Length;
            }
        }

        // Token: 0x17000049 RID: 73
        // (get) Token: 0x060000F1 RID: 241 RVA: 0x000097F0 File Offset: 0x000079F0
        // (set) Token: 0x060000F2 RID: 242 RVA: 0x00009808 File Offset: 0x00007A08
        public bool ForceBold
        {
            get
            {
                return this.myForceBold;
            }
            set
            {
                this.myForceBold = value;
                this.Draw();
            }
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x0000981C File Offset: 0x00007A1C
        public ctlPairedList()
        {
            base.FontChanged += this.ctlPairedList_FontChanged;
            base.Load += this.ctlPairedList_Load;
            base.Paint += this.ctlPairedList_Paint;
            base.MouseDown += this.Listlabel_MouseDown;
            base.MouseMove += this.Listlabel_MouseMove;
            base.MouseLeave += this.Listlabel_MouseLeave;
            base.BackColorChanged += this.ctlPairedList_BackColorChanged;
            this.ValueColorD = Color.Aqua;
            this.LinePadding = 3;
            this.myForceBold = false;
            this.InitializeComponent();
        }

        // Token: 0x060000F4 RID: 244 RVA: 0x000098D8 File Offset: 0x00007AD8
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x060000F5 RID: 245 RVA: 0x00009910 File Offset: 0x00007B10
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            this.myTip = new ToolTip(this.components);
            base.Name = "ctlPairedList";
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x0000993C File Offset: 0x00007B3C
        public void SetUnique()
        {
            if (this.MyItems.Length > 0)
            {
                this.MyItems[checked(this.MyItems.Length - 1)].UniqueColour = true;
            }
        }

        // Token: 0x060000F7 RID: 247 RVA: 0x00009978 File Offset: 0x00007B78
        public bool IsSpecialColor()
        {
            return this.MyItems[this.MyItems.Length - 1].VerySpecialColour;
        }

        // Token: 0x060000F8 RID: 248 RVA: 0x000099AE File Offset: 0x00007BAE
        private void ctlPairedList_FontChanged(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000F9 RID: 249 RVA: 0x000099B8 File Offset: 0x00007BB8
        private void ctlPairedList_Load(object sender, EventArgs e)
        {
            this.SetLineHeight();
            this.CurrentHighlight = -1;
            this.MyItems = new ctlPairedList.ItemPair[0];
            this.myGFX = base.CreateGraphics();
            this.bxBuffer = new ExtendedBitmap(base.Width, base.Height);
            this.AddItem(new ctlPairedList.ItemPair("Item 1:", "Value", false, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("Item 2:", "Alternate", true, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("Item 3:", "1000", false, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("Item 4:", "1,000", false, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("1234567890:", "12345678901234567890", false, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("1234567890:", "12345678901234567890", true, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("1 2 3 4 5 6 7 8 9 0:", "1 2 3 4 5 6 7 8 9 0", false, false, false, -1));
            this.AddItem(new ctlPairedList.ItemPair("1 2 3 4 5 6 7 8 9 0:", "1 2 3 4 5 6 7 8 9 0", true, false, false, -1));
            this.Draw();
        }

        // Token: 0x060000FA RID: 250 RVA: 0x00009ADA File Offset: 0x00007CDA
        public void FullUpdate()
        {
            this.SetLineHeight();
            this.myGFX = base.CreateGraphics();
            this.bxBuffer = new ExtendedBitmap(base.Width, base.Height);
            this.Draw();
        }

        // Token: 0x060000FB RID: 251 RVA: 0x00009B10 File Offset: 0x00007D10
        public void Draw()
        {
            checked
            {
                if (this.bxBuffer != null)
                {
                    this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
                    RectangleF rectangleF = new RectangleF(0f, 0f, 0f, 0f);
                    StringFormat stringFormat = new StringFormat();
                    FontStyle newStyle = FontStyle.Bold;
                    FontStyle newStyle2 = FontStyle.Regular;
                    if (this.myForceBold)
                    {
                        newStyle2 = FontStyle.Bold;
                        newStyle = FontStyle.Bold;
                    }
                    Font font = new Font(this.Font, newStyle);
                    Font font2 = new Font(this.Font, newStyle2);
                    rectangleF.X = 0f;
                    if (this.myColumns < 1)
                    {
                        this.myColumns = 1;
                    }
                    int num = (int)Math.Round((double)base.Width / (double)this.myColumns);
                    int num2 = (int)Math.Round((double)(unchecked((float)num * ((float)this.myValueWidth / 100f))));
                    int num3 = num - num2;
                    rectangleF.Height = (float)this.LineHeight;
                    this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    Brush brush = new SolidBrush(this.BackColor);
                    this.bxBuffer.Graphics.FillRectangle(brush, rect);
                    if (this.MyItems == null)
                    {
                        this.myGFX.DrawImageUnscaled(this.bxBuffer.Bitmap, 0, 0);
                    }
                    if (this.MyItems.Length < 1)
                    {
                        this.myGFX.DrawImageUnscaled(this.bxBuffer.Bitmap, 0, 0);
                    }
                    int num4 = 0;
                    int num5 = 0;
                    int num6 = 0;
                    int num7 = this.MyItems.Length - 1;
                    for (int i = num6; i <= num7; i++)
                    {
                        PointF location = new PointF((float)(num * num5), unchecked(rectangleF.Height * (float)num4 + (float)(checked(this.LinePadding * num4))));
                        rectangleF.Location = location;
                        rectangleF.Width = (float)num3;
                        stringFormat.Alignment = StringAlignment.Far;
                        stringFormat.Trimming = StringTrimming.None;
                        stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                        if (this.Highlightable & this.CurrentHighlight == i)
                        {
                            brush = new SolidBrush(this.myHighlightColor);
                            this.bxBuffer.Graphics.FillRectangle(brush, rectangleF);
                            brush = new SolidBrush(this.myHighlightTextColor);
                        }
                        else
                        {
                            brush = new SolidBrush(this.NameColour);
                        }
                        string text = this.MyItems[i].Name;
                        if (Operators.CompareString(text, "", false) != 0 & !text.EndsWith(":"))
                        {
                            text += ":";
                        }
                        this.bxBuffer.Graphics.DrawString(text, font, brush, rectangleF, stringFormat);
                        location = new PointF((float)(num * num5 + num3), unchecked(rectangleF.Height * (float)num4 + (float)(checked(this.LinePadding * num4))));
                        rectangleF.Location = location;
                        rectangleF.Width = (float)num2;
                        if (this.Highlightable & this.CurrentHighlight == i)
                        {
                            brush = new SolidBrush(this.myHighlightColor);
                            this.bxBuffer.Graphics.FillRectangle(brush, rectangleF);
                            brush = new SolidBrush(this.myHighlightTextColor);
                        }
                        else if (this.MyItems[i].UniqueColour)
                        {
                            brush = new SolidBrush(this.ValueColorD);
                        }
                        else if (this.MyItems[i].AlternateColour)
                        {
                            brush = new SolidBrush(this.ValueColorA);
                        }
                        else if (this.MyItems[i].ProbColour)
                        {
                            brush = new SolidBrush(this.ValueColorB);
                        }
                        else
                        {
                            brush = new SolidBrush(this.ValueColor);
                        }
                        stringFormat.Alignment = StringAlignment.Near;
                        this.bxBuffer.Graphics.DrawString(this.MyItems[i].Value, font2, brush, rectangleF, stringFormat);
                        num5++;
                        if (num5 >= this.myColumns)
                        {
                            num5 = 0;
                            num4++;
                        }
                    }
                    this.myGFX.DrawImageUnscaled(this.bxBuffer.Bitmap, 0, 0);
                }
            }
        }

        // Token: 0x060000FC RID: 252 RVA: 0x00009F80 File Offset: 0x00008180
        private void ctlPairedList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxBuffer != null)
            {
                this.myGFX.DrawImage(this.bxBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        // Token: 0x060000FD RID: 253 RVA: 0x00009FC5 File Offset: 0x000081C5
        protected override void OnFontChanged(EventArgs e)
        {
            this.SetLineHeight();
            this.Draw();
        }

        // Token: 0x060000FE RID: 254 RVA: 0x00009FD6 File Offset: 0x000081D6
        protected override void OnForeColorChanged(EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000FF RID: 255 RVA: 0x00009FE0 File Offset: 0x000081E0
        protected override void OnResize(EventArgs e)
        {
            this.FullUpdate();
        }

        // Token: 0x06000100 RID: 256 RVA: 0x00009FEC File Offset: 0x000081EC
        private void SetLineHeight()
        {
            Font font = new Font(this.Font, this.Font.Style);
            this.LineHeight = checked((int)Math.Round((double)(unchecked(font.GetHeight() + (float)this.LinePadding))));
        }

        // Token: 0x06000101 RID: 257 RVA: 0x0000A02C File Offset: 0x0000822C
        public void AddItem(ctlPairedList.ItemPair iItem)
        {
            checked
            {
                this.MyItems = (ctlPairedList.ItemPair[])Utils.CopyArray(this.MyItems, new ctlPairedList.ItemPair[this.MyItems.Length + 1]);
                this.MyItems[this.MyItems.Length - 1] = new ctlPairedList.ItemPair(iItem);
            }
        }

        // Token: 0x06000102 RID: 258 RVA: 0x0000A078 File Offset: 0x00008278
        public void Clear(bool Redraw = false)
        {
            this.MyItems = (ctlPairedList.ItemPair[])Utils.CopyArray(this.MyItems, new ctlPairedList.ItemPair[0]);
            if (Redraw)
            {
                this.Draw();
            }
        }

        // Token: 0x06000103 RID: 259 RVA: 0x0000A0B4 File Offset: 0x000082B4
        private void Listlabel_MouseDown(object sender, MouseEventArgs e)
        {
            int num = 0;
            int num2 = 0;
            int num3 = -1;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = 0;
            rectangle.Y = 0;
            rectangle.Height = this.LineHeight;
            checked
            {
                rectangle.Width = (int)Math.Round((double)base.Width / (double)this.myColumns);
                int num4 = 0;
                int num5 = this.MyItems.Length - 1;
                for (int i = num4; i <= num5; i++)
                {
                    rectangle.X = rectangle.Width * num2;
                    rectangle.Y = (rectangle.Height + this.LinePadding) * num;
                    if ((e.Y >= rectangle.Y & e.Y <= rectangle.Height + rectangle.Y) && (e.X >= rectangle.X & e.X <= rectangle.Width + rectangle.X))
                    {
                        num3 = i;
                        break;
                    }
                    num2++;
                    if (num2 >= this.myColumns)
                    {
                        num2 = 0;
                        num++;
                    }
                }
                if (num3 > -1)
                {
                    ctlPairedList.ItemClickEventHandler itemClickEvent = this.ItemClick;
                    if (itemClickEvent != null)
                    {
                        itemClickEvent(num3, e.Button);
                    }
                }
            }
        }

        // Token: 0x06000104 RID: 260 RVA: 0x0000A228 File Offset: 0x00008428
        private void Listlabel_MouseMove(object sender, MouseEventArgs e)
        {
            int num = 0;
            int num2 = 0;
            int num3 = -1;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = 0;
            rectangle.Y = 0;
            rectangle.Height = this.LineHeight;
            checked
            {
                rectangle.Width = (int)Math.Round((double)base.Width / (double)this.myColumns);
                int num4 = 0;
                int num5 = this.MyItems.Length - 1;
                for (int i = num4; i <= num5; i++)
                {
                    rectangle.X = rectangle.Width * num2;
                    rectangle.Y = (rectangle.Height + this.LinePadding) * num;
                    if ((e.Y >= rectangle.Y & e.Y <= rectangle.Height + rectangle.Y) && (e.X >= rectangle.X & e.X <= rectangle.Width + rectangle.X))
                    {
                        num3 = i;
                        break;
                    }
                    num2++;
                    if (num2 >= this.myColumns)
                    {
                        num2 = 0;
                        num++;
                    }
                }
                if (this.CurrentHighlight != num3)
                {
                    this.CurrentHighlight = num3;
                    if (this.Highlightable)
                    {
                        this.Draw();
                    }
                    if (num3 > -1)
                    {
                        this.ItemHover?.Invoke(this, num3, this.MyItems[num3].TagID);
                    }
                }
            }
        }

        // Token: 0x06000105 RID: 261 RVA: 0x0000A3D4 File Offset: 0x000085D4
        private void Listlabel_MouseLeave(object sender, EventArgs e)
        {
            this.CurrentHighlight = -1;
            if (this.Highlightable)
            {
                this.Draw();
            }
            this.myTip.SetToolTip(this, "");
        }

        // Token: 0x06000106 RID: 262 RVA: 0x0000A411 File Offset: 0x00008611
        public void SetTip(string iTip)
        {
            this.myTip.SetToolTip(this, iTip);
        }

        // Token: 0x06000107 RID: 263 RVA: 0x0000A422 File Offset: 0x00008622
        private void ctlPairedList_BackColorChanged(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x04000064 RID: 100
        protected ctlPairedList.ItemPair[] MyItems;

        // Token: 0x04000065 RID: 101
        private int LineHeight;

        // Token: 0x04000066 RID: 102
        protected ExtendedBitmap bxBuffer;

        // Token: 0x04000067 RID: 103
        protected Graphics myGFX;

        // Token: 0x04000068 RID: 104
        protected Color NameColour;

        // Token: 0x04000069 RID: 105
        protected Color ValueColor;

        // Token: 0x0400006A RID: 106
        protected Color ValueColorA;

        // Token: 0x0400006B RID: 107
        protected Color ValueColorB;

        // Token: 0x0400006C RID: 108
        protected Color ValueColorC;

        // Token: 0x0400006D RID: 109
        public Color ValueColorD;

        // Token: 0x0400006E RID: 110
        protected Color myHighlightColor;

        // Token: 0x0400006F RID: 111
        protected Color myHighlightTextColor;

        // Token: 0x04000070 RID: 112
        protected int myColumns;

        // Token: 0x04000071 RID: 113
        protected int LinePadding;

        // Token: 0x04000072 RID: 114
        protected int myValueWidth;

        // Token: 0x04000073 RID: 115
        protected bool Highlightable;

        // Token: 0x04000074 RID: 116
        protected int CurrentHighlight;

        // Token: 0x04000075 RID: 117
        protected bool myForceBold;

        // Token: 0x04000076 RID: 118
        private IContainer components;

        // Token: 0x04000077 RID: 119
        [AccessedThroughProperty("myTip")]
        private ToolTip _myTip;

        // Token: 0x02000010 RID: 16
        public class ItemPair
        {
            // Token: 0x06000108 RID: 264 RVA: 0x0000A42C File Offset: 0x0000862C
            public ItemPair(string iName, string iValue, bool iAlternate, bool iProbability, bool iSpecialCase, string iTip)
            {
                this.Name = iName;
                this.Value = iValue;
                this.AlternateColour = iAlternate;
                this.ProbColour = iProbability;
                this.VerySpecialColour = iSpecialCase;
                this.TagID.Add(-1, 0f);
                this.SpecialTip = iTip;
            }

            // Token: 0x06000109 RID: 265 RVA: 0x0000A484 File Offset: 0x00008684
            public ItemPair(string iName, string iValue, bool iAlternate, bool iProbability = false, bool iSpecialCase = false, int iTagID = -1)
            {
                this.Name = iName;
                this.Value = iValue;
                this.AlternateColour = iAlternate;
                this.ProbColour = iProbability;
                this.VerySpecialColour = iSpecialCase;
                this.TagID.Add(iTagID, 0f);
                this.SpecialTip = "";
            }

            // Token: 0x0600010A RID: 266 RVA: 0x0000A4E0 File Offset: 0x000086E0
            public ItemPair(string iName, string iValue, bool iAlternate, bool iProbability, bool iSpecialCase, Enums.ShortFX iTagID)
            {
                this.Name = iName;
                this.Value = iValue;
                this.AlternateColour = iAlternate;
                this.ProbColour = iProbability;
                this.VerySpecialColour = iSpecialCase;
                this.TagID.Assign(iTagID);
                this.SpecialTip = "";
            }

            // Token: 0x0600010B RID: 267 RVA: 0x0000A534 File Offset: 0x00008734
            public ItemPair(ctlPairedList.ItemPair iItem)
            {
                this.Name = iItem.Name;
                this.Value = iItem.Value;
                this.AlternateColour = iItem.AlternateColour;
                this.ProbColour = iItem.ProbColour;
                this.VerySpecialColour = iItem.VerySpecialColour;
                this.TagID.Assign(iItem.TagID);
                this.SpecialTip = iItem.SpecialTip;
            }

            // Token: 0x0400007A RID: 122
            public string Name;

            // Token: 0x0400007B RID: 123
            public string Value;

            // Token: 0x0400007C RID: 124
            public bool AlternateColour;

            // Token: 0x0400007D RID: 125
            public bool ProbColour;

            // Token: 0x0400007E RID: 126
            public bool VerySpecialColour;

            // Token: 0x0400007F RID: 127
            public bool UniqueColour;

            // Token: 0x04000080 RID: 128
            public Enums.ShortFX TagID;

            // Token: 0x04000081 RID: 129
            public string SpecialTip;
        }

        // Token: 0x02000011 RID: 17
        // (Invoke) Token: 0x0600010D RID: 269
        public delegate void ItemClickEventHandler(int Index, MouseButtons Button);

        // Token: 0x02000012 RID: 18
        // (Invoke) Token: 0x06000111 RID: 273
        public delegate void ItemHoverEventHandler(object Sender, int Index, Enums.ShortFX TagID);
    }
}
