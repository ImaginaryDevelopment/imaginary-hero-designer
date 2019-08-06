﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    // Token: 0x0200000C RID: 12
    [DefaultEvent("BarClick")]
    public class ctlMultiGraph : UserControl
    {
        // Token: 0x14000001 RID: 1
        // (add) Token: 0x0600007B RID: 123 RVA: 0x00007520 File Offset: 0x00005720
        // (remove) Token: 0x0600007C RID: 124 RVA: 0x0000753A File Offset: 0x0000573A
        public event BarClickEventHandler BarClick;

        // Token: 0x17000021 RID: 33
        // (get) Token: 0x0600007D RID: 125 RVA: 0x00007554 File Offset: 0x00005754
        // (set) Token: 0x0600007E RID: 126 RVA: 0x0000756C File Offset: 0x0000576C
        internal virtual ToolTip tTip
        {
            get
            {
                return _tTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _tTip = value;
            }
        }

        // Token: 0x17000022 RID: 34
        // (get) Token: 0x0600007F RID: 127 RVA: 0x00007578 File Offset: 0x00005778
        // (set) Token: 0x06000080 RID: 128 RVA: 0x00007590 File Offset: 0x00005790
        public Color ColorBase
        {
            get
            {
                return pBaseColor;
            }
            set
            {
                pBaseColor = value;
                Draw();
            }
        }

        // Token: 0x17000023 RID: 35
        // (get) Token: 0x06000081 RID: 129 RVA: 0x000075A4 File Offset: 0x000057A4
        // (set) Token: 0x06000082 RID: 130 RVA: 0x000075BC File Offset: 0x000057BC
        public Color ColorEnh
        {
            get
            {
                return pEnhColor;
            }
            set
            {
                pEnhColor = value;
                Draw();
            }
        }

        // Token: 0x17000024 RID: 36
        // (get) Token: 0x06000083 RID: 131 RVA: 0x000075D0 File Offset: 0x000057D0
        // (set) Token: 0x06000084 RID: 132 RVA: 0x000075E8 File Offset: 0x000057E8
        public Color ColorFadeStart
        {
            get
            {
                return pBlendColor1;
            }
            set
            {
                pBlendColor1 = value;
                Draw();
            }
        }

        // Token: 0x17000025 RID: 37
        // (get) Token: 0x06000085 RID: 133 RVA: 0x000075FC File Offset: 0x000057FC
        // (set) Token: 0x06000086 RID: 134 RVA: 0x00007614 File Offset: 0x00005814
        public Color ColorFadeEnd
        {
            get
            {
                return pBlendColor2;
            }
            set
            {
                pBlendColor2 = value;
                Draw();
            }
        }

        // Token: 0x17000026 RID: 38
        // (get) Token: 0x06000087 RID: 135 RVA: 0x00007628 File Offset: 0x00005828
        // (set) Token: 0x06000088 RID: 136 RVA: 0x00007640 File Offset: 0x00005840
        public Color ColorLines
        {
            get
            {
                return pLineColor;
            }
            set
            {
                pLineColor = value;
                Draw();
            }
        }

        // Token: 0x17000027 RID: 39
        // (get) Token: 0x06000089 RID: 137 RVA: 0x00007654 File Offset: 0x00005854
        // (set) Token: 0x0600008A RID: 138 RVA: 0x0000766C File Offset: 0x0000586C
        public Color ColorHighlight
        {
            get
            {
                return pHighlightColor;
            }
            set
            {
                pHighlightColor = value;
                Draw();
            }
        }

        // Token: 0x17000028 RID: 40
        // (get) Token: 0x0600008B RID: 139 RVA: 0x00007680 File Offset: 0x00005880
        // (set) Token: 0x0600008C RID: 140 RVA: 0x00007698 File Offset: 0x00005898
        public Color ColorMarkerInner
        {
            get
            {
                return pMarkerColor;
            }
            set
            {
                pMarkerColor = value;
                Draw();
            }
        }

        // Token: 0x17000029 RID: 41
        // (get) Token: 0x0600008D RID: 141 RVA: 0x000076AC File Offset: 0x000058AC
        // (set) Token: 0x0600008E RID: 142 RVA: 0x000076C4 File Offset: 0x000058C4
        public float MarkerValue
        {
            get
            {
                return pMarkerValue;
            }
            set
            {
                pMarkerValue = value;
            }
        }

        // Token: 0x1700002A RID: 42
        // (get) Token: 0x0600008F RID: 143 RVA: 0x000076D0 File Offset: 0x000058D0
        // (set) Token: 0x06000090 RID: 144 RVA: 0x000076E8 File Offset: 0x000058E8
        public Color ColorMarkerOuter
        {
            get
            {
                return pMarkerColor2;
            }
            set
            {
                pMarkerColor2 = value;
                Draw();
            }
        }

        // Token: 0x1700002B RID: 43
        // (get) Token: 0x06000091 RID: 145 RVA: 0x000076FC File Offset: 0x000058FC
        // (set) Token: 0x06000092 RID: 146 RVA: 0x00007714 File Offset: 0x00005914
        public float Max
        {
            get
            {
                return pMaxValue;
            }
            set
            {
                SetBestScale(value);
                Draw();
            }
        }

        // Token: 0x1700002C RID: 44
        // (get) Token: 0x06000093 RID: 147 RVA: 0x00007728 File Offset: 0x00005928
        // (set) Token: 0x06000094 RID: 148 RVA: 0x00007741 File Offset: 0x00005941
        public float PaddingX
        {
            get
            {
                return xPadding;
            }
            set
            {
                xPadding = checked((int)Math.Round(value));
                Draw();
            }
        }

        // Token: 0x1700002D RID: 45
        // (get) Token: 0x06000095 RID: 149 RVA: 0x0000775C File Offset: 0x0000595C
        // (set) Token: 0x06000096 RID: 150 RVA: 0x00007775 File Offset: 0x00005975
        public float PaddingY
        {
            get
            {
                return yPadding;
            }
            set
            {
                yPadding = checked((int)Math.Round(value));
                Draw();
            }
        }

        // Token: 0x1700002E RID: 46
        // (get) Token: 0x06000097 RID: 151 RVA: 0x00007790 File Offset: 0x00005990
        // (set) Token: 0x06000098 RID: 152 RVA: 0x000077A8 File Offset: 0x000059A8
        public int TextWidth
        {
            get
            {
                return nameWidth;
            }
            set
            {
                nameWidth = value;
                Draw();
            }
        }

        // Token: 0x1700002F RID: 47
        // (get) Token: 0x06000099 RID: 153 RVA: 0x000077BC File Offset: 0x000059BC
        // (set) Token: 0x0600009A RID: 154 RVA: 0x000077D4 File Offset: 0x000059D4
        public int ItemHeight
        {
            get
            {
                return pItemHeight;
            }
            set
            {
                pItemHeight = value;
                Draw();
            }
        }

        // Token: 0x17000030 RID: 48
        // (get) Token: 0x0600009B RID: 155 RVA: 0x000077E8 File Offset: 0x000059E8
        // (set) Token: 0x0600009C RID: 156 RVA: 0x00007800 File Offset: 0x00005A00
        public bool Lines
        {
            get
            {
                return pDrawLines;
            }
            set
            {
                pDrawLines = value;
                Draw();
            }
        }

        // Token: 0x17000031 RID: 49
        // (get) Token: 0x0600009D RID: 157 RVA: 0x00007814 File Offset: 0x00005A14
        // (set) Token: 0x0600009E RID: 158 RVA: 0x0000782C File Offset: 0x00005A2C
        public bool Border
        {
            get
            {
                return pBorder;
            }
            set
            {
                pBorder = value;
                Draw();
            }
        }

        // Token: 0x17000032 RID: 50
        // (get) Token: 0x0600009F RID: 159 RVA: 0x00007840 File Offset: 0x00005A40
        // (set) Token: 0x060000A0 RID: 160 RVA: 0x00007858 File Offset: 0x00005A58
        public bool ShowScale
        {
            get
            {
                return pShowScale;
            }
            set
            {
                pShowScale = value;
                Draw();
            }
        }

        // Token: 0x17000033 RID: 51
        // (get) Token: 0x060000A1 RID: 161 RVA: 0x0000786C File Offset: 0x00005A6C
        // (set) Token: 0x060000A2 RID: 162 RVA: 0x00007884 File Offset: 0x00005A84
        public bool Highlight
        {
            get
            {
                return pShowHighlight;
            }
            set
            {
                pShowHighlight = value;
                Draw();
            }
        }

        // Token: 0x17000034 RID: 52
        // (get) Token: 0x060000A3 RID: 163 RVA: 0x00007898 File Offset: 0x00005A98
        // (set) Token: 0x060000A4 RID: 164 RVA: 0x000078B0 File Offset: 0x00005AB0
        public int ScaleHeight
        {
            get
            {
                return pScaleHeight;
            }
            set
            {
                pScaleHeight = value;
                Draw();
            }
        }

        // Token: 0x17000035 RID: 53
        // (get) Token: 0x060000A5 RID: 165 RVA: 0x000078C4 File Offset: 0x00005AC4
        // (set) Token: 0x060000A6 RID: 166 RVA: 0x000078DC File Offset: 0x00005ADC
        public bool Dual
        {
            get
            {
                return DualName;
            }
            set
            {
                DualName = value;
                Draw();
            }
        }

        // Token: 0x17000036 RID: 54
        // (get) Token: 0x060000A7 RID: 167 RVA: 0x000078F0 File Offset: 0x00005AF0
        // (set) Token: 0x060000A8 RID: 168 RVA: 0x00007908 File Offset: 0x00005B08
        public Enums.GraphStyle Style
        {
            get
            {
                return pStyle;
            }
            set
            {
                pStyle = value;
                Draw();
            }
        }

        // Token: 0x17000037 RID: 55
        // (get) Token: 0x060000A9 RID: 169 RVA: 0x0000791C File Offset: 0x00005B1C
        // (set) Token: 0x060000AA RID: 170 RVA: 0x0000793C File Offset: 0x00005B3C
        public int ScaleIndex
        {
            get
            {
                return WhichScale(pMaxValue);
            }
            set
            {
                if (value > -1 & value < Scales.Length)
                {
                    pMaxValue = Scales[value];
                }
                Draw();
            }
        }

        // Token: 0x17000038 RID: 56
        // (get) Token: 0x060000AB RID: 171 RVA: 0x00007978 File Offset: 0x00005B78
        public float ScaleValue
        {
            get
            {
                return pMaxValue;
            }
        }

        // Token: 0x17000039 RID: 57
        // (get) Token: 0x060000AC RID: 172 RVA: 0x00007990 File Offset: 0x00005B90
        public int ItemCount
        {
            get
            {
                return Items.Length;
            }
        }

        // Token: 0x1700003A RID: 58
        // (get) Token: 0x060000AD RID: 173 RVA: 0x000079AC File Offset: 0x00005BAC
        public int ScaleCount
        {
            get
            {
                return Scales.Length;
            }
        }

        // Token: 0x1700003B RID: 59
        // (get) Token: 0x060000AE RID: 174 RVA: 0x000079C8 File Offset: 0x00005BC8
        // (set) Token: 0x060000AF RID: 175 RVA: 0x000079E4 File Offset: 0x00005BE4
        public float ForcedMax
        {
            get
            {
                return pForcedMax;
            }
            set
            {
                pForcedMax = checked((int)Math.Round(value));
                if (pForcedMax > 0)
                {
                    pMaxValue = pForcedMax;
                }
                else
                {
                    Max = GetMaxValue();
                }
                Draw();
            }
        }

        // Token: 0x1700003C RID: 60
        // (get) Token: 0x060000B0 RID: 176 RVA: 0x00007A38 File Offset: 0x00005C38
        // (set) Token: 0x060000B1 RID: 177 RVA: 0x00007A50 File Offset: 0x00005C50
        public bool Clickable
        {
            get
            {
                return pClickable;
            }
            set
            {
                pClickable = value;
            }
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00007A5C File Offset: 0x00005C5C
        public ctlMultiGraph()
        {
            MouseLeave += ctlMultiGraph_MouseLeave;
            MouseDown += ctlMultiGraph_MouseDown;
            MouseUp += ctlMultiGraph_MouseUp;
            Load += ctlMultiGraph_Load;
            BackColorChanged += ctlMultiGraph_BackColorChanged;
            SizeChanged += ctlMultiGraph_SizeChanged;
            Paint += ctlMultiGraph_Paint;
            FontChanged += ctlMultiGraph_FontChanged;
            ForeColorChanged += ctlMultiGraph_ForeColorChanged;
            Resize += ctlMultiGraph_Resize;
            MouseMove += ctlMultiGraph_MouseMove;
            Scales = new float[0];
            Items = new GraphItem[0];
            pBaseColor = Color.Blue;
            pEnhColor = Color.Yellow;
            pBlendColor1 = Color.Black;
            pBlendColor2 = Color.Red;
            pLineColor = Color.Black;
            pStyle = 0;
            pDrawLines = false;
            pBorder = true;
            pMaxValue = 100f;
            yPadding = 5;
            xPadding = 4;
            oldMouseX = 0;
            oldMouseY = 0;
            pItemHeight = 8;
            nameWidth = 72;
            Loaded = false;
            pShowScale = false;
            pScaleHeight = 32;
            pHighlight = -1;
            pHighlightColor = Color.FromArgb(128, 128, 255);
            NoDraw = false;
            DualName = false;
            pMarkerValue = 0f;
            pMarkerColor = Color.Black;
            pMarkerColor2 = Color.Yellow;
            pForcedMax = 0;
            pClickable = false;
            InitializeComponent();
            FillScales();
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00007C60 File Offset: 0x00005E60
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x00007C98 File Offset: 0x00005E98
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            components = new Container();
            tTip = new ToolTip(components);
            tTip.AutoPopDelay = 10000;
            tTip.InitialDelay = 500;
            tTip.ReshowDelay = 100;
            Name = "ctlMultiGraph";
            Size size = new Size(332, 156);
            Size = size;
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x00007D1C File Offset: 0x00005F1C
        private void ctlMultiGraph_Load(object sender, EventArgs e)
        {
            checked
            {
                if (Items.Length < 1)
                {
                    int num = 0;
                    do
                    {
                        AddItemPair("Value " + Conversions.ToString(num), "Value " + Conversions.ToString(num) + "b", (int)Math.Round(Conversion.Int(101f * VBMath.Rnd() + 0f)), (int)Math.Round(Conversion.Int(101f * VBMath.Rnd() + 0f)), Conversions.ToString(num));
                        num++;
                    }
                    while (num <= 60);
                }
                Loaded = true;
                Draw();
            }
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x00007DD4 File Offset: 0x00005FD4
        public void AddItem(string sName, float nBase, float nEnh, string iTip = "")
        {
            checked
            {
                Items = (GraphItem[])Utils.CopyArray(Items, new GraphItem[Items.Length + 1]);
                Items[Items.Length - 1] = new GraphItem(sName, nBase, nEnh, iTip);
            }
        }

        // Token: 0x060000B7 RID: 183 RVA: 0x00007E24 File Offset: 0x00006024
        public void AddItemPair(string sName, string sName2, float nBase, float nEnh, string iTip = "")
        {
            checked
            {
                Items = (GraphItem[])Utils.CopyArray(Items, new GraphItem[Items.Length + 1]);
                Items[Items.Length - 1] = new GraphItem(sName, sName2, nBase, nEnh, iTip);
            }
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x00007E76 File Offset: 0x00006076
        public void Clear()
        {
            Items = new GraphItem[0];
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x00007E88 File Offset: 0x00006088
        public void Draw()
        {
            checked
            {
                if (!NoDraw)
                {
                    if (Loaded)
                    {
                        myGFX = null;
                        myGFX = CreateGraphics();
                        bxBuffer = new ExtendedBitmap(Size);
                        if (bxBuffer.Graphics != null)
                        {
                            bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                            bxBuffer.Graphics.FillRectangle(new SolidBrush(BackColor), 0, 0, bxBuffer.Size.Width, bxBuffer.Size.Height);
                            Rectangle rectangle = new Rectangle(nameWidth, 0, Width - nameWidth - 1, Height - 1);
                            LinearGradientBrush brush = new LinearGradientBrush(rectangle, pBlendColor1, pBlendColor2, 0f);
                            SolidBrush brush2 = new SolidBrush(ForeColor);
                            Pen pen = new Pen(pLineColor, 1f);
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Far;
                            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                            stringFormat.Trimming = StringTrimming.None;
                            bxBuffer.Graphics.FillRectangle(brush, rectangle);
                            Draw_Scale(ref rectangle);
                            Draw_Highlight(rectangle);
                            const int num = 0;
                            int num2 = Items.Length - 1;
                            for (int i = num; i <= num2; i++)
                            {
                                int num3 = yPadding + i * (pItemHeight + yPadding);
                                if (!DualName | Operators.CompareString(Items[i].Name, Items[i].Name2, false) == 0)
                                {
                                    string text = Items[i].Name;
                                    if (Operators.CompareString(text, "", false) == 0)
                                    {
                                        text = Items[i].Name2;
                                    }
                                    if (Operators.CompareString(text, "", false) != 0 && text.IndexOf(":", StringComparison.Ordinal) < 0)
                                    {
                                        text += ":";
                                    }
                                    int num4 = (int)Math.Round(checked(rectangle.Top + num3) + (pItemHeight - Font.GetHeight(bxBuffer.Graphics)) / 2f);
                                    int num5 = text.IndexOf("|", StringComparison.Ordinal);
                                    RectangleF layoutRectangle = new RectangleF(0f, num4, Width - rectangle.Width - xPadding, ItemHeight + yPadding * 2);
                                    if (num5 < 0)
                                    {
                                        bxBuffer.Graphics.DrawString(text, Font, brush2, layoutRectangle, stringFormat);
                                    }
                                    else
                                    {
                                        stringFormat.Alignment = StringAlignment.Near;
                                        bxBuffer.Graphics.DrawString(text.Substring(0, num5), Font, brush2, layoutRectangle, stringFormat);
                                        stringFormat.Alignment = StringAlignment.Far;
                                        bxBuffer.Graphics.DrawString(text.Substring(num5 + 1), Font, brush2, layoutRectangle, stringFormat);
                                    }
                                }
                                if (pStyle != Enums.GraphStyle.enhOnly & pStyle != Enums.GraphStyle.baseOnly)
                                {
                                    if (Items[i].valueBase > Items[i].valueEnh)
                                    {
                                        DrawBase(i, rectangle, num3);
                                        DrawEnh(i, rectangle, num3);
                                    }
                                    else
                                    {
                                        DrawEnh(i, rectangle, num3);
                                        DrawBase(i, rectangle, num3);
                                    }
                                }
                                else if (pStyle == Enums.GraphStyle.baseOnly)
                                {
                                    DrawBase(i, rectangle, num3);
                                }
                                else if (pStyle == Enums.GraphStyle.enhOnly)
                                {
                                    DrawEnh(i, rectangle, num3);
                                }
                            }
                            if (pBorder)
                            {
                                bxBuffer.Graphics.DrawRectangle(pen, rectangle);
                            }
                            myGFX.DrawImageUnscaled(bxBuffer.Bitmap, 0, 0);
                        }
                    }
                }
            }
        }

        // Token: 0x060000BA RID: 186 RVA: 0x00008310 File Offset: 0x00006510
        public void Draw_Highlight(Rectangle Bounds)
        {
            checked
            {
                if (!(!pShowHighlight | pHighlight == -1))
                {
                    Color color = Color.FromArgb(128, pHighlightColor.R, pHighlightColor.G, pHighlightColor.B);
                    SolidBrush brush = new SolidBrush(color);
                    int width = Bounds.Width;
                    int height = pItemHeight + yPadding * 2;
                    int num = pHighlight * (pItemHeight + yPadding);
                    Rectangle rect = new Rectangle(Bounds.Left, Bounds.Top + num, width, height);
                    bxBuffer.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        // Token: 0x060000BB RID: 187 RVA: 0x000083D4 File Offset: 0x000065D4
        public void Draw_Scale(ref Rectangle Bounds)
        {
            checked
            {
                if (pShowScale)
                {
                    SolidBrush brush = new SolidBrush(ForeColor);
                    Pen pen = new Pen(ForeColor, 1f);
                    StringFormat stringFormat = new StringFormat();
                    Rectangle rect = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, pScaleHeight);
                    Bounds.Y += rect.Height;
                    Bounds.Height -= rect.Height;
                    bxBuffer.Graphics.FillRectangle(new SolidBrush(BackColor), rect);
                    bxBuffer.Graphics.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X + rect.Width, rect.Y + rect.Height);
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                    stringFormat.Trimming = StringTrimming.None;
                    string style;
                    if (Max >= 100f)
                    {
                        style = "#,##0";
                    }
                    else if (Max >= 10f)
                    {
                        style = "#0";
                    }
                    else if (Max >= 5f)
                    {
                        style = "#0.#";
                    }
                    else
                    {
                        style = "#0.##";
                    }
                    int num = (int)Math.Round(rect.Width / 10.0);
                    int num2 = (int)Math.Round(Font.GetHeight(bxBuffer.Graphics) + 1f);
                    int num3 = nameWidth;
                    int num4 = (int)Math.Round(rect.Y + rect.Height / 5.0 * 4.0);
                    int num5 = 0;
                    do
                    {
                        if (num3 > bxBuffer.Size.Width)
                        {
                            num3 = bxBuffer.Size.Width - 1;
                        }
                        bxBuffer.Graphics.DrawLine(pen, num3, num4, num3, rect.Y + rect.Height);
                        RectangleF layoutRectangle = new RectangleF((float)(num3 - num / 2.0), num4 - num2, num, num2);
                        if (num5 == 10)
                        {
                            layoutRectangle.X = num3 - num;
                            stringFormat.Alignment = StringAlignment.Far;
                        }
                        if (num5 > 0)
                        {
                            bxBuffer.Graphics.DrawString(Strings.Format(pMaxValue / 10f * num5, style), Font, brush, layoutRectangle, stringFormat);
                        }
                        else
                        {
                            bxBuffer.Graphics.DrawString("0", Font, brush, layoutRectangle, stringFormat);
                        }
                        num3 += num;
                        num5++;
                    }
                    while (num5 <= 10);
                }
            }
        }

        // Token: 0x060000BC RID: 188 RVA: 0x000086F8 File Offset: 0x000068F8
        public void DrawBase(int Index, Rectangle Bounds, int nY)
        {
            SolidBrush brush = new SolidBrush(pBaseColor);
            Pen pen = new Pen(pLineColor, 1f);
            SolidBrush brush2 = new SolidBrush(ForeColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            stringFormat.Trimming = StringTrimming.None;
            checked
            {
                int width = (int)Math.Round(Bounds.Width * (Items[Index].valueBase / pMaxValue));
                int num = pItemHeight;
                if (Style == 0)
                {
                    num = (int)Math.Round(num / 2.0);
                }
                Rectangle rect = new Rectangle(Bounds.Left, Bounds.Top + nY, width, num);
                bxBuffer.Graphics.FillRectangle(brush, rect);
                if (pDrawLines)
                {
                    bxBuffer.Graphics.DrawRectangle(pen, rect);
                }
                if (pMarkerValue > 0f & pMarkerValue != Items[Index].valueBase)
                {
                    Pen pen2 = new Pen(pMarkerColor2, 3f);
                    int num2 = (int)Math.Round(rect.Left + Bounds.Width * (pMarkerValue / pMaxValue));
                    bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                    pen2 = new Pen(pMarkerColor, 1f);
                    bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                }
                if (Clickable)
                {
                    Pen pen3 = new Pen(pMarkerColor2, 6f);
                    int right = rect.Right;
                    bxBuffer.Graphics.DrawLine(pen3, right, rect.Top + 1, right, rect.Bottom);
                    pen3 = new Pen(pMarkerColor, 2f);
                    bxBuffer.Graphics.DrawLine(pen3, right, rect.Top + 1, right, rect.Bottom);
                    pen3 = new Pen(pMarkerColor2, 1f);
                    bxBuffer.Graphics.DrawLine(pen3, right - 1, rect.Top, right + 1, rect.Top);
                    bxBuffer.Graphics.DrawLine(pen3, right - 1, rect.Bottom, right + 1, rect.Bottom);
                }
                if (DualName & Operators.CompareString(Items[Index].Name, "", false) != 0 & Operators.CompareString(Items[Index].Name, Items[Index].Name2, false) != 0)
                {
                    RectangleF layoutRectangle = new RectangleF(0f, rect.Top, Width - Bounds.Width - xPadding, rect.Height);
                    bxBuffer.Graphics.DrawString(Items[Index].Name + ":", Font, brush2, layoutRectangle, stringFormat);
                }
            }
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00008A7C File Offset: 0x00006C7C
        public void DrawEnh(int Index, Rectangle Bounds, int nY)
        {
            SolidBrush brush = new SolidBrush(pEnhColor);
            Pen pen = new Pen(pLineColor, 1f);
            SolidBrush brush2 = new SolidBrush(ForeColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            stringFormat.Trimming = StringTrimming.None;
            checked
            {
                int width = (int)Math.Round(Bounds.Width * (Items[Index].valueEnh / pMaxValue));
                int num = pItemHeight;
                if (Style == 0)
                {
                    num = (int)Math.Round(num / 2.0);
                    nY += num;
                }
                Rectangle rect = new Rectangle(Bounds.Left, Bounds.Top + nY, width, num);
                bxBuffer.Graphics.FillRectangle(brush, rect);
                if (pDrawLines)
                {
                    bxBuffer.Graphics.DrawRectangle(pen, rect);
                }
                if (pMarkerValue > 0f & pMarkerValue != Items[Index].valueEnh)
                {
                    Pen pen2 = new Pen(pMarkerColor2, 3f);
                    int num2 = (int)Math.Round(rect.Left + Bounds.Width * (pMarkerValue / pMaxValue));
                    bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                    pen2 = new Pen(pMarkerColor, 1f);
                    bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                }
                if (DualName & Operators.CompareString(Items[Index].Name2, "", false) != 0 & Operators.CompareString(Items[Index].Name, Items[Index].Name2, false) != 0)
                {
                    RectangleF layoutRectangle = new RectangleF(0f, rect.Top, Width - Bounds.Width - xPadding, rect.Height);
                    bxBuffer.Graphics.DrawString(Items[Index].Name2 + ":", Font, brush2, layoutRectangle, stringFormat);
                }
            }
        }

        // Token: 0x060000BE RID: 190 RVA: 0x00008D13 File Offset: 0x00006F13
        private void ctlMultiGraph_BackColorChanged(object sender, EventArgs e)
        {
            Draw();
        }

        // Token: 0x060000BF RID: 191 RVA: 0x00008D1D File Offset: 0x00006F1D
        private void ctlMultiGraph_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }

        // Token: 0x060000C0 RID: 192 RVA: 0x00008D28 File Offset: 0x00006F28
        private void ctlMultiGraph_Paint(object sender, PaintEventArgs e)
        {
            if (bxBuffer != null)
            {
                e.Graphics.DrawImage(bxBuffer.Bitmap, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        // Token: 0x060000C1 RID: 193 RVA: 0x00008D83 File Offset: 0x00006F83
        private void ctlMultiGraph_FontChanged(object sender, EventArgs e)
        {
            Draw();
        }

        // Token: 0x060000C2 RID: 194 RVA: 0x00008D8D File Offset: 0x00006F8D
        private void ctlMultiGraph_ForeColorChanged(object sender, EventArgs e)
        {
            Draw();
        }

        // Token: 0x060000C3 RID: 195 RVA: 0x00008D97 File Offset: 0x00006F97
        private void ctlMultiGraph_Resize(object sender, EventArgs e)
        {
            Draw();
        }

        // Token: 0x060000C4 RID: 196 RVA: 0x00008DA4 File Offset: 0x00006FA4
        private void ctlMultiGraph_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if (pClickable & e.Button == MouseButtons.Left)
                {
                    float valueAtXY = GetValueAtXY(e.X, e.Y);
                    BarClickEventHandler barClickEvent = BarClick;
                    if (barClickEvent != null)
                    {
                        barClickEvent(valueAtXY);
                    }
                }
                else if (!(e.X == oldMouseX & e.Y == oldMouseY))
                {
                    oldMouseX = e.X;
                    oldMouseY = e.Y;
                    int num = pHighlight;
                    Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);
                    if (pShowScale)
                    {
                        rectangle.Height -= pScaleHeight;
                        rectangle.Y += pScaleHeight;
                    }
                    int width = rectangle.Width;
                    int height = ItemHeight + yPadding;
                    const int num2 = 0;
                    int num3 = Items.Length - 1;
                    int i = num2;
                    while (i <= num3)
                    {
                        int num4 = (int)Math.Round(yPadding / 2.0 + checked(i * (pItemHeight + yPadding)));
                        Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top + num4, width, height);
                        if ((e.X >= rectangle2.X & e.X <= rectangle2.X + rectangle2.Width) && (e.Y >= rectangle2.Y & e.Y <= rectangle2.Y + rectangle2.Height))
                        {
                            pHighlight = i;
                            tTip.SetToolTip(this, Items[i].Tip);
                            if (num != pHighlight)
                            {
                                Draw();
                                return;
                            }
                            return;
                        }

                        i++;
                    }
                    pHighlight = -1;
                    tTip.SetToolTip(this, "");
                    if (num != pHighlight)
                    {
                        Draw();
                    }
                }
            }
        }

        // Token: 0x060000C5 RID: 197 RVA: 0x0000901C File Offset: 0x0000721C
        private void ctlMultiGraph_MouseLeave(object sender, EventArgs e)
        {
            int num = pHighlight;
            pHighlight = -1;
            if (num != pHighlight)
            {
                Draw();
            }
        }

        // Token: 0x060000C6 RID: 198 RVA: 0x0000904E File Offset: 0x0000724E
        public void BeginUpdate()
        {
            NoDraw = true;
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x00009058 File Offset: 0x00007258
        public void EndUpdate()
        {
            NoDraw = false;
            Draw();
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x0000906C File Offset: 0x0000726C
        public void FillScales()
        {
            Scales = new float[0];
            AddScale(1f);
            AddScale(2f);
            AddScale(3f);
            AddScale(5f);
            AddScale(10f);
            AddScale(25f);
            AddScale(50f);
            AddScale(75f);
            AddScale(100f);
            AddScale(150f);
            AddScale(225f);
            AddScale(300f);
            AddScale(450f);
            AddScale(600f);
            AddScale(900f);
            AddScale(1200f);
            AddScale(2400f);
        }

        // Token: 0x060000C9 RID: 201 RVA: 0x00009152 File Offset: 0x00007352
        protected void AddScale(float iValue)
        {
            checked
            {
                Scales = (float[])Utils.CopyArray(Scales, new float[Scales.Length + 1]);
                Scales[Scales.Length - 1] = iValue;
            }
        }

        // Token: 0x060000CA RID: 202 RVA: 0x00009190 File Offset: 0x00007390
        public float GetMaxValue()
        {
            checked
            {
                float result;
                if (Scales.Length < 1)
                {
                    pMaxValue = 100f;
                    result = 100f;
                }
                else
                {
                    const int num = 0;
                    int num2 = Items.Length - 1;
                    float num3 = 0f;
                    for (int i = num; i <= num2; i++)
                    {
                        if (Items[i].valueBase > num3)
                        {
                            num3 = Items[i].valueBase;
                        }
                        if (Items[i].valueEnh > num3)
                        {
                            num3 = Items[i].valueEnh;
                        }
                    }
                    result = num3;
                }
                return result;
            }
        }

        // Token: 0x060000CB RID: 203 RVA: 0x00009250 File Offset: 0x00007450
        protected void SetBestScale(float iValue)
        {
            checked
            {
                if (Scales.Length < 1)
                {
                    pMaxValue = iValue;
                }
                else
                {
                    const int num = 0;
                    int num2 = Scales.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        if (Scales[i] >= iValue)
                        {
                            pMaxValue = Scales[i];
                            return;
                        }
                    }
                    pMaxValue = Scales[Scales.Length - 1];
                }
            }
        }

        // Token: 0x060000CC RID: 204 RVA: 0x000092D8 File Offset: 0x000074D8
        protected int WhichScale(float iVal)
        {
            const int num = 0;
            checked
            {
                int num2 = Scales.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (Scales[i] == iVal)
                    {
                        return i;
                    }
                }
                return Scales.Length - 1;
            }
        }

        // Token: 0x060000CD RID: 205 RVA: 0x00009334 File Offset: 0x00007534
        private void ctlMultiGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (pClickable & e.Button == MouseButtons.Left)
            {
                float valueAtXY = GetValueAtXY(e.X, e.Y);
                BarClick?.Invoke(valueAtXY);
            }
        }

        // Token: 0x060000CE RID: 206 RVA: 0x0000938C File Offset: 0x0000758C
        protected float GetValueAtXY(int iX, int iY)
        {
            checked
            {
                Rectangle rectangle = new Rectangle(0, 0, Width - 1, Height - 1);
                if (pShowScale)
                {
                    rectangle.Height -= pScaleHeight;
                    rectangle.Y += pScaleHeight;
                }
                int num = rectangle.Width;
                int height = ItemHeight + yPadding;
                const int num2 = 0;
                int num3 = Items.Length - 1;
                for (int i = num2; i <= num3; i++)
                {
                    int num4 = (int)Math.Round(yPadding / 2.0 + checked(i * (pItemHeight + yPadding)));
                    Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top + num4, num, height);
                    if (iX >= rectangle2.X && ((iY >= rectangle2.Y & iY <= rectangle2.Y + rectangle2.Height) | Items.Length == 1))
                    {
                        num -= TextWidth;
                        float result;
                        if (iX > TextWidth)
                        {
                            iX -= TextWidth;
                            result = (float)(iX / (double)num * pMaxValue);
                        }
                        else
                        {
                            result = 0f;
                        }
                        return result;
                    }
                }
                return 0f;
            }
        }

        // Token: 0x060000CF RID: 207 RVA: 0x00009511 File Offset: 0x00007711
        private static void ctlMultiGraph_MouseUp(object sender, MouseEventArgs e)
        {
        }

        // Token: 0x0400003C RID: 60
        private IContainer components;

        // Token: 0x0400003D RID: 61
        [AccessedThroughProperty("tTip")]
        private ToolTip _tTip;

        // Token: 0x0400003E RID: 62
        protected float[] Scales;

        // Token: 0x0400003F RID: 63
        public GraphItem[] Items;

        // Token: 0x04000040 RID: 64
        protected ExtendedBitmap bxBuffer;

        // Token: 0x04000041 RID: 65
        protected Graphics myGFX;

        // Token: 0x04000042 RID: 66
        protected Color pBaseColor;

        // Token: 0x04000043 RID: 67
        protected Color pEnhColor;

        // Token: 0x04000044 RID: 68
        protected Color pBlendColor1;

        // Token: 0x04000045 RID: 69
        protected Color pBlendColor2;

        // Token: 0x04000046 RID: 70
        protected Color pLineColor;

        // Token: 0x04000047 RID: 71
        protected Enums.GraphStyle pStyle;

        // Token: 0x04000048 RID: 72
        protected bool pDrawLines;

        // Token: 0x04000049 RID: 73
        protected bool pBorder;

        // Token: 0x0400004A RID: 74
        protected float pMaxValue;

        // Token: 0x0400004B RID: 75
        protected int yPadding;

        // Token: 0x0400004C RID: 76
        protected int xPadding;

        // Token: 0x0400004D RID: 77
        protected int oldMouseX;

        // Token: 0x0400004E RID: 78
        protected int oldMouseY;

        // Token: 0x0400004F RID: 79
        protected int pItemHeight;

        // Token: 0x04000050 RID: 80
        protected int nameWidth;

        // Token: 0x04000051 RID: 81
        protected bool Loaded;

        // Token: 0x04000052 RID: 82
        protected bool pShowScale;

        // Token: 0x04000053 RID: 83
        protected int pScaleHeight;

        // Token: 0x04000054 RID: 84
        protected bool pShowHighlight;

        // Token: 0x04000055 RID: 85
        protected int pHighlight;

        // Token: 0x04000056 RID: 86
        protected Color pHighlightColor;

        // Token: 0x04000057 RID: 87
        protected bool NoDraw;

        // Token: 0x04000058 RID: 88
        protected bool DualName;

        // Token: 0x04000059 RID: 89
        protected float pMarkerValue;

        // Token: 0x0400005A RID: 90
        protected Color pMarkerColor;

        // Token: 0x0400005B RID: 91
        protected Color pMarkerColor2;

        // Token: 0x0400005C RID: 92
        protected int pForcedMax;

        // Token: 0x0400005D RID: 93
        protected bool pClickable;

        // Token: 0x0200000D RID: 13
        public class GraphItem
        {
            // Token: 0x060000D0 RID: 208 RVA: 0x00009514 File Offset: 0x00007714
            public GraphItem(string iName, float Base, float Enh, string iTip = "")
            {
                valueBase = Base;
                valueEnh = Enh;
                Name = iName;
                Name2 = "";
                Tip = iTip;
            }

            // Token: 0x060000D1 RID: 209 RVA: 0x00009547 File Offset: 0x00007747
            public GraphItem(string iName, string iName2, float Base, float Enh, string iTip = "")
            {
                valueBase = Base;
                valueEnh = Enh;
                Name = iName;
                Name2 = iName2;
                Tip = iTip;
            }

            // Token: 0x0400005F RID: 95
            public float valueBase;

            // Token: 0x04000060 RID: 96
            public float valueEnh;

            // Token: 0x04000061 RID: 97
            public string Name;

            // Token: 0x04000062 RID: 98
            public string Name2;

            // Token: 0x04000063 RID: 99
            public string Tip;
        }

        // Token: 0x0200000E RID: 14
        // (Invoke) Token: 0x060000D3 RID: 211
        public delegate void BarClickEventHandler(float Value);
    }
}
