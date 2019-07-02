using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Display;
using HeroDesigner.Schema;
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
        public event ctlMultiGraph.BarClickEventHandler BarClick;

        // Token: 0x17000021 RID: 33
        // (get) Token: 0x0600007D RID: 125 RVA: 0x00007554 File Offset: 0x00005754
        // (set) Token: 0x0600007E RID: 126 RVA: 0x0000756C File Offset: 0x0000576C
        internal virtual ToolTip tTip
        {
            get
            {
                return this._tTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tTip = value;
            }
        }

        // Token: 0x17000022 RID: 34
        // (get) Token: 0x0600007F RID: 127 RVA: 0x00007578 File Offset: 0x00005778
        // (set) Token: 0x06000080 RID: 128 RVA: 0x00007590 File Offset: 0x00005790
        public Color ColorBase
        {
            get
            {
                return this.pBaseColor;
            }
            set
            {
                this.pBaseColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000023 RID: 35
        // (get) Token: 0x06000081 RID: 129 RVA: 0x000075A4 File Offset: 0x000057A4
        // (set) Token: 0x06000082 RID: 130 RVA: 0x000075BC File Offset: 0x000057BC
        public Color ColorEnh
        {
            get
            {
                return this.pEnhColor;
            }
            set
            {
                this.pEnhColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000024 RID: 36
        // (get) Token: 0x06000083 RID: 131 RVA: 0x000075D0 File Offset: 0x000057D0
        // (set) Token: 0x06000084 RID: 132 RVA: 0x000075E8 File Offset: 0x000057E8
        public Color ColorFadeStart
        {
            get
            {
                return this.pBlendColor1;
            }
            set
            {
                this.pBlendColor1 = value;
                this.Draw();
            }
        }

        // Token: 0x17000025 RID: 37
        // (get) Token: 0x06000085 RID: 133 RVA: 0x000075FC File Offset: 0x000057FC
        // (set) Token: 0x06000086 RID: 134 RVA: 0x00007614 File Offset: 0x00005814
        public Color ColorFadeEnd
        {
            get
            {
                return this.pBlendColor2;
            }
            set
            {
                this.pBlendColor2 = value;
                this.Draw();
            }
        }

        // Token: 0x17000026 RID: 38
        // (get) Token: 0x06000087 RID: 135 RVA: 0x00007628 File Offset: 0x00005828
        // (set) Token: 0x06000088 RID: 136 RVA: 0x00007640 File Offset: 0x00005840
        public Color ColorLines
        {
            get
            {
                return this.pLineColor;
            }
            set
            {
                this.pLineColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000027 RID: 39
        // (get) Token: 0x06000089 RID: 137 RVA: 0x00007654 File Offset: 0x00005854
        // (set) Token: 0x0600008A RID: 138 RVA: 0x0000766C File Offset: 0x0000586C
        public Color ColorHighlight
        {
            get
            {
                return this.pHighlightColor;
            }
            set
            {
                this.pHighlightColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000028 RID: 40
        // (get) Token: 0x0600008B RID: 139 RVA: 0x00007680 File Offset: 0x00005880
        // (set) Token: 0x0600008C RID: 140 RVA: 0x00007698 File Offset: 0x00005898
        public Color ColorMarkerInner
        {
            get
            {
                return this.pMarkerColor;
            }
            set
            {
                this.pMarkerColor = value;
                this.Draw();
            }
        }

        // Token: 0x17000029 RID: 41
        // (get) Token: 0x0600008D RID: 141 RVA: 0x000076AC File Offset: 0x000058AC
        // (set) Token: 0x0600008E RID: 142 RVA: 0x000076C4 File Offset: 0x000058C4
        public float MarkerValue
        {
            get
            {
                return this.pMarkerValue;
            }
            set
            {
                this.pMarkerValue = value;
            }
        }

        // Token: 0x1700002A RID: 42
        // (get) Token: 0x0600008F RID: 143 RVA: 0x000076D0 File Offset: 0x000058D0
        // (set) Token: 0x06000090 RID: 144 RVA: 0x000076E8 File Offset: 0x000058E8
        public Color ColorMarkerOuter
        {
            get
            {
                return this.pMarkerColor2;
            }
            set
            {
                this.pMarkerColor2 = value;
                this.Draw();
            }
        }

        // Token: 0x1700002B RID: 43
        // (get) Token: 0x06000091 RID: 145 RVA: 0x000076FC File Offset: 0x000058FC
        // (set) Token: 0x06000092 RID: 146 RVA: 0x00007714 File Offset: 0x00005914
        public float Max
        {
            get
            {
                return this.pMaxValue;
            }
            set
            {
                this.SetBestScale(value);
                this.Draw();
            }
        }

        // Token: 0x1700002C RID: 44
        // (get) Token: 0x06000093 RID: 147 RVA: 0x00007728 File Offset: 0x00005928
        // (set) Token: 0x06000094 RID: 148 RVA: 0x00007741 File Offset: 0x00005941
        public float PaddingX
        {
            get
            {
                return (float)this.xPadding;
            }
            set
            {
                this.xPadding = checked((int)Math.Round((double)value));
                this.Draw();
            }
        }

        // Token: 0x1700002D RID: 45
        // (get) Token: 0x06000095 RID: 149 RVA: 0x0000775C File Offset: 0x0000595C
        // (set) Token: 0x06000096 RID: 150 RVA: 0x00007775 File Offset: 0x00005975
        public float PaddingY
        {
            get
            {
                return (float)this.yPadding;
            }
            set
            {
                this.yPadding = checked((int)Math.Round((double)value));
                this.Draw();
            }
        }

        // Token: 0x1700002E RID: 46
        // (get) Token: 0x06000097 RID: 151 RVA: 0x00007790 File Offset: 0x00005990
        // (set) Token: 0x06000098 RID: 152 RVA: 0x000077A8 File Offset: 0x000059A8
        public int TextWidth
        {
            get
            {
                return this.nameWidth;
            }
            set
            {
                this.nameWidth = value;
                this.Draw();
            }
        }

        // Token: 0x1700002F RID: 47
        // (get) Token: 0x06000099 RID: 153 RVA: 0x000077BC File Offset: 0x000059BC
        // (set) Token: 0x0600009A RID: 154 RVA: 0x000077D4 File Offset: 0x000059D4
        public int ItemHeight
        {
            get
            {
                return this.pItemHeight;
            }
            set
            {
                this.pItemHeight = value;
                this.Draw();
            }
        }

        // Token: 0x17000030 RID: 48
        // (get) Token: 0x0600009B RID: 155 RVA: 0x000077E8 File Offset: 0x000059E8
        // (set) Token: 0x0600009C RID: 156 RVA: 0x00007800 File Offset: 0x00005A00
        public bool Lines
        {
            get
            {
                return this.pDrawLines;
            }
            set
            {
                this.pDrawLines = value;
                this.Draw();
            }
        }

        // Token: 0x17000031 RID: 49
        // (get) Token: 0x0600009D RID: 157 RVA: 0x00007814 File Offset: 0x00005A14
        // (set) Token: 0x0600009E RID: 158 RVA: 0x0000782C File Offset: 0x00005A2C
        public bool Border
        {
            get
            {
                return this.pBorder;
            }
            set
            {
                this.pBorder = value;
                this.Draw();
            }
        }

        // Token: 0x17000032 RID: 50
        // (get) Token: 0x0600009F RID: 159 RVA: 0x00007840 File Offset: 0x00005A40
        // (set) Token: 0x060000A0 RID: 160 RVA: 0x00007858 File Offset: 0x00005A58
        public bool ShowScale
        {
            get
            {
                return this.pShowScale;
            }
            set
            {
                this.pShowScale = value;
                this.Draw();
            }
        }

        // Token: 0x17000033 RID: 51
        // (get) Token: 0x060000A1 RID: 161 RVA: 0x0000786C File Offset: 0x00005A6C
        // (set) Token: 0x060000A2 RID: 162 RVA: 0x00007884 File Offset: 0x00005A84
        public bool Highlight
        {
            get
            {
                return this.pShowHighlight;
            }
            set
            {
                this.pShowHighlight = value;
                this.Draw();
            }
        }

        // Token: 0x17000034 RID: 52
        // (get) Token: 0x060000A3 RID: 163 RVA: 0x00007898 File Offset: 0x00005A98
        // (set) Token: 0x060000A4 RID: 164 RVA: 0x000078B0 File Offset: 0x00005AB0
        public int ScaleHeight
        {
            get
            {
                return this.pScaleHeight;
            }
            set
            {
                this.pScaleHeight = value;
                this.Draw();
            }
        }

        // Token: 0x17000035 RID: 53
        // (get) Token: 0x060000A5 RID: 165 RVA: 0x000078C4 File Offset: 0x00005AC4
        // (set) Token: 0x060000A6 RID: 166 RVA: 0x000078DC File Offset: 0x00005ADC
        public bool Dual
        {
            get
            {
                return this.DualName;
            }
            set
            {
                this.DualName = value;
                this.Draw();
            }
        }

        // Token: 0x17000036 RID: 54
        // (get) Token: 0x060000A7 RID: 167 RVA: 0x000078F0 File Offset: 0x00005AF0
        // (set) Token: 0x060000A8 RID: 168 RVA: 0x00007908 File Offset: 0x00005B08
        public GraphStyle Style
        {
            get
            {
                return this.pStyle;
            }
            set
            {
                this.pStyle = value;
                this.Draw();
            }
        }

        // Token: 0x17000037 RID: 55
        // (get) Token: 0x060000A9 RID: 169 RVA: 0x0000791C File Offset: 0x00005B1C
        // (set) Token: 0x060000AA RID: 170 RVA: 0x0000793C File Offset: 0x00005B3C
        public int ScaleIndex
        {
            get
            {
                return this.WhichScale(this.pMaxValue);
            }
            set
            {
                if (value > -1 & value < this.Scales.Length)
                {
                    this.pMaxValue = this.Scales[value];
                }
                this.Draw();
            }
        }

        // Token: 0x17000038 RID: 56
        // (get) Token: 0x060000AB RID: 171 RVA: 0x00007978 File Offset: 0x00005B78
        public float ScaleValue
        {
            get
            {
                return this.pMaxValue;
            }
        }

        // Token: 0x17000039 RID: 57
        // (get) Token: 0x060000AC RID: 172 RVA: 0x00007990 File Offset: 0x00005B90
        public int ItemCount
        {
            get
            {
                return this.Items.Length;
            }
        }

        // Token: 0x1700003A RID: 58
        // (get) Token: 0x060000AD RID: 173 RVA: 0x000079AC File Offset: 0x00005BAC
        public int ScaleCount
        {
            get
            {
                return this.Scales.Length;
            }
        }

        // Token: 0x1700003B RID: 59
        // (get) Token: 0x060000AE RID: 174 RVA: 0x000079C8 File Offset: 0x00005BC8
        // (set) Token: 0x060000AF RID: 175 RVA: 0x000079E4 File Offset: 0x00005BE4
        public float ForcedMax
        {
            get
            {
                return (float)this.pForcedMax;
            }
            set
            {
                this.pForcedMax = checked((int)Math.Round((double)value));
                if (this.pForcedMax > 0)
                {
                    this.pMaxValue = (float)this.pForcedMax;
                }
                else
                {
                    this.Max = this.GetMaxValue();
                }
                this.Draw();
            }
        }

        // Token: 0x1700003C RID: 60
        // (get) Token: 0x060000B0 RID: 176 RVA: 0x00007A38 File Offset: 0x00005C38
        // (set) Token: 0x060000B1 RID: 177 RVA: 0x00007A50 File Offset: 0x00005C50
        public bool Clickable
        {
            get
            {
                return this.pClickable;
            }
            set
            {
                this.pClickable = value;
            }
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00007A5C File Offset: 0x00005C5C
        public ctlMultiGraph()
        {
            base.MouseLeave += this.ctlMultiGraph_MouseLeave;
            base.MouseDown += this.ctlMultiGraph_MouseDown;
            base.MouseUp += this.ctlMultiGraph_MouseUp;
            base.Load += this.ctlMultiGraph_Load;
            base.BackColorChanged += this.ctlMultiGraph_BackColorChanged;
            base.SizeChanged += this.ctlMultiGraph_SizeChanged;
            base.Paint += this.ctlMultiGraph_Paint;
            base.FontChanged += this.ctlMultiGraph_FontChanged;
            base.ForeColorChanged += this.ctlMultiGraph_ForeColorChanged;
            base.Resize += this.ctlMultiGraph_Resize;
            base.MouseMove += this.ctlMultiGraph_MouseMove;
            this.Scales = new float[0];
            this.Items = new ctlMultiGraph.GraphItem[0];
            this.pBaseColor = Color.Blue;
            this.pEnhColor = Color.Yellow;
            this.pBlendColor1 = Color.Black;
            this.pBlendColor2 = Color.Red;
            this.pLineColor = Color.Black;
            this.pStyle = 0;
            this.pDrawLines = false;
            this.pBorder = true;
            this.pMaxValue = 100f;
            this.yPadding = 5;
            this.xPadding = 4;
            this.oldMouseX = 0;
            this.oldMouseY = 0;
            this.pItemHeight = 8;
            this.nameWidth = 72;
            this.Loaded = false;
            this.pShowScale = false;
            this.pScaleHeight = 32;
            this.pHighlight = -1;
            this.pHighlightColor = Color.FromArgb(128, 128, 255);
            this.NoDraw = false;
            this.DualName = false;
            this.pMarkerValue = 0f;
            this.pMarkerColor = Color.Black;
            this.pMarkerColor2 = Color.Yellow;
            this.pForcedMax = 0;
            this.pClickable = false;
            this.InitializeComponent();
            this.FillScales();
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00007C60 File Offset: 0x00005E60
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x00007C98 File Offset: 0x00005E98
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            this.tTip = new ToolTip(this.components);
            this.tTip.AutoPopDelay = 10000;
            this.tTip.InitialDelay = 500;
            this.tTip.ReshowDelay = 100;
            base.Name = "ctlMultiGraph";
            Size size = new Size(332, 156);
            base.Size = size;
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x00007D1C File Offset: 0x00005F1C
        private void ctlMultiGraph_Load(object sender, EventArgs e)
        {
            checked
            {
                if (this.Items.Length < 1)
                {
                    int num = 0;
                    do
                    {
                        this.AddItemPair("Value " + Conversions.ToString(num), "Value " + Conversions.ToString(num) + "b", (float)((int)Math.Round((double)Conversion.Int(unchecked(101f * VBMath.Rnd() + 0f)))), (float)((int)Math.Round((double)Conversion.Int(unchecked(101f * VBMath.Rnd() + 0f)))), Conversions.ToString(num));
                        num++;
                    }
                    while (num <= 60);
                }
                this.Loaded = true;
                this.Draw();
            }
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x00007DD4 File Offset: 0x00005FD4
        public void AddItem(string sName, float nBase, float nEnh, string iTip = "")
        {
            checked
            {
                this.Items = (ctlMultiGraph.GraphItem[])Utils.CopyArray(this.Items, new ctlMultiGraph.GraphItem[this.Items.Length + 1]);
                this.Items[this.Items.Length - 1] = new ctlMultiGraph.GraphItem(sName, nBase, nEnh, iTip);
            }
        }

        // Token: 0x060000B7 RID: 183 RVA: 0x00007E24 File Offset: 0x00006024
        public void AddItemPair(string sName, string sName2, float nBase, float nEnh, string iTip = "")
        {
            checked
            {
                this.Items = (ctlMultiGraph.GraphItem[])Utils.CopyArray(this.Items, new ctlMultiGraph.GraphItem[this.Items.Length + 1]);
                this.Items[this.Items.Length - 1] = new ctlMultiGraph.GraphItem(sName, sName2, nBase, nEnh, iTip);
            }
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x00007E76 File Offset: 0x00006076
        public void Clear()
        {
            this.Items = new ctlMultiGraph.GraphItem[0];
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x00007E88 File Offset: 0x00006088
        public void Draw()
        {
            checked
            {
                if (!this.NoDraw)
                {
                    if (this.Loaded)
                    {
                        this.myGFX = null;
                        this.myGFX = base.CreateGraphics();
                        this.bxBuffer = new ExtendedBitmap(base.Size);
                        if (this.bxBuffer.Graphics != null)
                        {
                            this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                            this.bxBuffer.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.bxBuffer.Size.Width, this.bxBuffer.Size.Height);
                            Rectangle rectangle = new Rectangle(this.nameWidth, 0, base.Width - this.nameWidth - 1, base.Height - 1);
                            LinearGradientBrush brush = new LinearGradientBrush(rectangle, this.pBlendColor1, this.pBlendColor2, 0f);
                            SolidBrush brush2 = new SolidBrush(this.ForeColor);
                            Pen pen = new Pen(this.pLineColor, 1f);
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Far;
                            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                            stringFormat.Trimming = StringTrimming.None;
                            this.bxBuffer.Graphics.FillRectangle(brush, rectangle);
                            this.Draw_Scale(ref rectangle);
                            this.Draw_Highlight(rectangle);
                            int num = 0;
                            int num2 = this.Items.Length - 1;
                            for (int i = num; i <= num2; i++)
                            {
                                int num3 = this.yPadding + i * (this.pItemHeight + this.yPadding);
                                if (!this.DualName | Operators.CompareString(this.Items[i].Name, this.Items[i].Name2, false) == 0)
                                {
                                    string text = this.Items[i].Name;
                                    if (Operators.CompareString(text, "", false) == 0)
                                    {
                                        text = this.Items[i].Name2;
                                    }
                                    if (Operators.CompareString(text, "", false) != 0 && text.IndexOf(":") < 0)
                                    {
                                        text += ":";
                                    }
                                    int num4 = (int)Math.Round((double)(unchecked((float)(checked(rectangle.Top + num3)) + ((float)this.pItemHeight - this.Font.GetHeight(this.bxBuffer.Graphics)) / 2f)));
                                    int num5 = text.IndexOf("|");
                                    RectangleF layoutRectangle = new RectangleF(0f, (float)num4, (float)(base.Width - rectangle.Width - this.xPadding), (float)(this.ItemHeight + this.yPadding * 2));
                                    if (num5 < 0)
                                    {
                                        this.bxBuffer.Graphics.DrawString(text, this.Font, brush2, layoutRectangle, stringFormat);
                                    }
                                    else
                                    {
                                        stringFormat.Alignment = StringAlignment.Near;
                                        this.bxBuffer.Graphics.DrawString(text.Substring(0, num5), this.Font, brush2, layoutRectangle, stringFormat);
                                        stringFormat.Alignment = StringAlignment.Far;
                                        this.bxBuffer.Graphics.DrawString(text.Substring(num5 + 1), this.Font, brush2, layoutRectangle, stringFormat);
                                    }
                                }
                                if (this.pStyle != GraphStyle.enhOnly & this.pStyle != GraphStyle.baseOnly)
                                {
                                    if (this.Items[i].valueBase > this.Items[i].valueEnh)
                                    {
                                        this.DrawBase(i, rectangle, num3);
                                        this.DrawEnh(i, rectangle, num3);
                                    }
                                    else
                                    {
                                        this.DrawEnh(i, rectangle, num3);
                                        this.DrawBase(i, rectangle, num3);
                                    }
                                }
                                else if (this.pStyle == GraphStyle.baseOnly)
                                {
                                    this.DrawBase(i, rectangle, num3);
                                }
                                else if (this.pStyle == GraphStyle.enhOnly)
                                {
                                    this.DrawEnh(i, rectangle, num3);
                                }
                            }
                            if (this.pBorder)
                            {
                                this.bxBuffer.Graphics.DrawRectangle(pen, rectangle);
                            }
                            this.myGFX.DrawImageUnscaled(this.bxBuffer.Bitmap, 0, 0);
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
                if (!(!this.pShowHighlight | this.pHighlight == -1))
                {
                    Color color = Color.FromArgb(128, (int)this.pHighlightColor.R, (int)this.pHighlightColor.G, (int)this.pHighlightColor.B);
                    SolidBrush brush = new SolidBrush(color);
                    int width = Bounds.Width;
                    int height = this.pItemHeight + this.yPadding * 2;
                    int num = this.pHighlight * (this.pItemHeight + this.yPadding);
                    Rectangle rect = new Rectangle(Bounds.Left, Bounds.Top + num, width, height);
                    this.bxBuffer.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        // Token: 0x060000BB RID: 187 RVA: 0x000083D4 File Offset: 0x000065D4
        public void Draw_Scale(ref Rectangle Bounds)
        {
            checked
            {
                if (this.pShowScale)
                {
                    SolidBrush brush = new SolidBrush(this.ForeColor);
                    Pen pen = new Pen(this.ForeColor, 1f);
                    StringFormat stringFormat = new StringFormat();
                    Rectangle rect = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, this.pScaleHeight);
                    Bounds.Y += rect.Height;
                    Bounds.Height -= rect.Height;
                    this.bxBuffer.Graphics.FillRectangle(new SolidBrush(this.BackColor), rect);
                    this.bxBuffer.Graphics.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X + rect.Width, rect.Y + rect.Height);
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                    stringFormat.Trimming = StringTrimming.None;
                    string style;
                    if (this.Max >= 100f)
                    {
                        style = "#,##0";
                    }
                    else if (this.Max >= 10f)
                    {
                        style = "#0";
                    }
                    else if (this.Max >= 5f)
                    {
                        style = "#0.#";
                    }
                    else
                    {
                        style = "#0.##";
                    }
                    int num = (int)Math.Round((double)rect.Width / 10.0);
                    int num2 = (int)Math.Round((double)(unchecked(this.Font.GetHeight(this.bxBuffer.Graphics) + 1f)));
                    int num3 = this.nameWidth;
                    int num4 = (int)Math.Round(unchecked((double)rect.Y + (double)rect.Height / 5.0 * 4.0));
                    int num5 = 0;
                    do
                    {
                        if (num3 > this.bxBuffer.Size.Width)
                        {
                            num3 = this.bxBuffer.Size.Width - 1;
                        }
                        this.bxBuffer.Graphics.DrawLine(pen, num3, num4, num3, rect.Y + rect.Height);
                        RectangleF layoutRectangle = new RectangleF((float)(unchecked((double)num3 - (double)num / 2.0)), (float)(num4 - num2), (float)num, (float)num2);
                        if (num5 == 10)
                        {
                            layoutRectangle.X = (float)(num3 - num);
                            stringFormat.Alignment = StringAlignment.Far;
                        }
                        if (num5 > 0)
                        {
                            this.bxBuffer.Graphics.DrawString(Strings.Format(unchecked(this.pMaxValue / 10f * (float)num5), style), this.Font, brush, layoutRectangle, stringFormat);
                        }
                        else
                        {
                            this.bxBuffer.Graphics.DrawString("0", this.Font, brush, layoutRectangle, stringFormat);
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
            SolidBrush brush = new SolidBrush(this.pBaseColor);
            Pen pen = new Pen(this.pLineColor, 1f);
            SolidBrush brush2 = new SolidBrush(this.ForeColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            stringFormat.Trimming = StringTrimming.None;
            checked
            {
                int width = (int)Math.Round((double)(unchecked((float)Bounds.Width * (this.Items[Index].valueBase / this.pMaxValue))));
                int num = this.pItemHeight;
                if (this.Style == 0)
                {
                    num = (int)Math.Round((double)num / 2.0);
                }
                Rectangle rect = new Rectangle(Bounds.Left, Bounds.Top + nY, width, num);
                this.bxBuffer.Graphics.FillRectangle(brush, rect);
                if (this.pDrawLines)
                {
                    this.bxBuffer.Graphics.DrawRectangle(pen, rect);
                }
                if (this.pMarkerValue > 0f & this.pMarkerValue != this.Items[Index].valueBase)
                {
                    Pen pen2 = new Pen(this.pMarkerColor2, 3f);
                    int num2 = (int)Math.Round((double)(unchecked((float)rect.Left + (float)Bounds.Width * (this.pMarkerValue / this.pMaxValue))));
                    this.bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                    pen2 = new Pen(this.pMarkerColor, 1f);
                    this.bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                }
                if (this.Clickable)
                {
                    Pen pen3 = new Pen(this.pMarkerColor2, 6f);
                    int right = rect.Right;
                    this.bxBuffer.Graphics.DrawLine(pen3, right, rect.Top + 1, right, rect.Bottom);
                    pen3 = new Pen(this.pMarkerColor, 2f);
                    this.bxBuffer.Graphics.DrawLine(pen3, right, rect.Top + 1, right, rect.Bottom);
                    pen3 = new Pen(this.pMarkerColor2, 1f);
                    this.bxBuffer.Graphics.DrawLine(pen3, right - 1, rect.Top, right + 1, rect.Top);
                    this.bxBuffer.Graphics.DrawLine(pen3, right - 1, rect.Bottom, right + 1, rect.Bottom);
                }
                if (this.DualName & Operators.CompareString(this.Items[Index].Name, "", false) != 0 & Operators.CompareString(this.Items[Index].Name, this.Items[Index].Name2, false) != 0)
                {
                    RectangleF layoutRectangle = new RectangleF(0f, (float)rect.Top, (float)(base.Width - Bounds.Width - this.xPadding), (float)rect.Height);
                    this.bxBuffer.Graphics.DrawString(this.Items[Index].Name + ":", this.Font, brush2, layoutRectangle, stringFormat);
                }
            }
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00008A7C File Offset: 0x00006C7C
        public void DrawEnh(int Index, Rectangle Bounds, int nY)
        {
            SolidBrush brush = new SolidBrush(this.pEnhColor);
            Pen pen = new Pen(this.pLineColor, 1f);
            SolidBrush brush2 = new SolidBrush(this.ForeColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Far;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            stringFormat.Trimming = StringTrimming.None;
            checked
            {
                int width = (int)Math.Round((double)(unchecked((float)Bounds.Width * (this.Items[Index].valueEnh / this.pMaxValue))));
                int num = this.pItemHeight;
                if (this.Style == 0)
                {
                    num = (int)Math.Round((double)num / 2.0);
                    nY += num;
                }
                Rectangle rect = new Rectangle(Bounds.Left, Bounds.Top + nY, width, num);
                this.bxBuffer.Graphics.FillRectangle(brush, rect);
                if (this.pDrawLines)
                {
                    this.bxBuffer.Graphics.DrawRectangle(pen, rect);
                }
                if (this.pMarkerValue > 0f & this.pMarkerValue != this.Items[Index].valueEnh)
                {
                    Pen pen2 = new Pen(this.pMarkerColor2, 3f);
                    int num2 = (int)Math.Round((double)(unchecked((float)rect.Left + (float)Bounds.Width * (this.pMarkerValue / this.pMaxValue))));
                    this.bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                    pen2 = new Pen(this.pMarkerColor, 1f);
                    this.bxBuffer.Graphics.DrawLine(pen2, num2, rect.Top + 1, num2, rect.Bottom);
                }
                if (this.DualName & Operators.CompareString(this.Items[Index].Name2, "", false) != 0 & Operators.CompareString(this.Items[Index].Name, this.Items[Index].Name2, false) != 0)
                {
                    RectangleF layoutRectangle = new RectangleF(0f, (float)rect.Top, (float)(base.Width - Bounds.Width - this.xPadding), (float)rect.Height);
                    this.bxBuffer.Graphics.DrawString(this.Items[Index].Name2 + ":", this.Font, brush2, layoutRectangle, stringFormat);
                }
            }
        }

        // Token: 0x060000BE RID: 190 RVA: 0x00008D13 File Offset: 0x00006F13
        private void ctlMultiGraph_BackColorChanged(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000BF RID: 191 RVA: 0x00008D1D File Offset: 0x00006F1D
        private void ctlMultiGraph_SizeChanged(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000C0 RID: 192 RVA: 0x00008D28 File Offset: 0x00006F28
        private void ctlMultiGraph_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxBuffer != null)
            {
                e.Graphics.DrawImage(this.bxBuffer.Bitmap, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        // Token: 0x060000C1 RID: 193 RVA: 0x00008D83 File Offset: 0x00006F83
        private void ctlMultiGraph_FontChanged(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000C2 RID: 194 RVA: 0x00008D8D File Offset: 0x00006F8D
        private void ctlMultiGraph_ForeColorChanged(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000C3 RID: 195 RVA: 0x00008D97 File Offset: 0x00006F97
        private void ctlMultiGraph_Resize(object sender, EventArgs e)
        {
            this.Draw();
        }

        // Token: 0x060000C4 RID: 196 RVA: 0x00008DA4 File Offset: 0x00006FA4
        private void ctlMultiGraph_MouseMove(object sender, MouseEventArgs e)
        {
            checked
            {
                if (this.pClickable & e.Button == MouseButtons.Left)
                {
                    float valueAtXY = this.GetValueAtXY(e.X, e.Y);
                    ctlMultiGraph.BarClickEventHandler barClickEvent = this.BarClick;
                    if (barClickEvent != null)
                    {
                        barClickEvent(valueAtXY);
                    }
                }
                else if (!(e.X == this.oldMouseX & e.Y == this.oldMouseY))
                {
                    this.oldMouseX = e.X;
                    this.oldMouseY = e.Y;
                    int num = this.pHighlight;
                    Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
                    if (this.pShowScale)
                    {
                        rectangle.Height -= this.pScaleHeight;
                        rectangle.Y += this.pScaleHeight;
                    }
                    int width = rectangle.Width;
                    int height = this.ItemHeight + this.yPadding;
                    int num2 = 0;
                    int num3 = this.Items.Length - 1;
                    int i = num2;
                    while (i <= num3)
                    {
                        int num4 = (int)Math.Round(unchecked((double)this.yPadding / 2.0 + (double)(checked(i * (this.pItemHeight + this.yPadding)))));
                        Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top + num4, width, height);
                        if ((e.X >= rectangle2.X & e.X <= rectangle2.X + rectangle2.Width) && (e.Y >= rectangle2.Y & e.Y <= rectangle2.Y + rectangle2.Height))
                        {
                            this.pHighlight = i;
                            this.tTip.SetToolTip(this, this.Items[i].Tip);
                            if (num != this.pHighlight)
                            {
                                this.Draw();
                                return;
                            }
                            return;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    this.pHighlight = -1;
                    this.tTip.SetToolTip(this, "");
                    if (num != this.pHighlight)
                    {
                        this.Draw();
                    }
                }
            }
        }

        // Token: 0x060000C5 RID: 197 RVA: 0x0000901C File Offset: 0x0000721C
        private void ctlMultiGraph_MouseLeave(object sender, EventArgs e)
        {
            int num = this.pHighlight;
            this.pHighlight = -1;
            if (num != this.pHighlight)
            {
                this.Draw();
            }
        }

        // Token: 0x060000C6 RID: 198 RVA: 0x0000904E File Offset: 0x0000724E
        public void BeginUpdate()
        {
            this.NoDraw = true;
        }

        // Token: 0x060000C7 RID: 199 RVA: 0x00009058 File Offset: 0x00007258
        public void EndUpdate()
        {
            this.NoDraw = false;
            this.Draw();
        }

        // Token: 0x060000C8 RID: 200 RVA: 0x0000906C File Offset: 0x0000726C
        public void FillScales()
        {
            this.Scales = new float[0];
            this.AddScale(1f);
            this.AddScale(2f);
            this.AddScale(3f);
            this.AddScale(5f);
            this.AddScale(10f);
            this.AddScale(25f);
            this.AddScale(50f);
            this.AddScale(75f);
            this.AddScale(100f);
            this.AddScale(150f);
            this.AddScale(225f);
            this.AddScale(300f);
            this.AddScale(450f);
            this.AddScale(600f);
            this.AddScale(900f);
            this.AddScale(1200f);
            this.AddScale(2400f);
        }

        // Token: 0x060000C9 RID: 201 RVA: 0x00009152 File Offset: 0x00007352
        protected void AddScale(float iValue)
        {
            checked
            {
                this.Scales = (float[])Utils.CopyArray(this.Scales, new float[this.Scales.Length + 1]);
                this.Scales[this.Scales.Length - 1] = iValue;
            }
        }

        // Token: 0x060000CA RID: 202 RVA: 0x00009190 File Offset: 0x00007390
        public float GetMaxValue()
        {
            checked
            {
                float result;
                if (this.Scales.Length < 1)
                {
                    this.pMaxValue = 100f;
                    result = 100f;
                }
                else
                {
                    int num = 0;
                    int num2 = this.Items.Length - 1;
                    float num3 = 0f;
                    for (int i = num; i <= num2; i++)
                    {
                        if (this.Items[i].valueBase > num3)
                        {
                            num3 = this.Items[i].valueBase;
                        }
                        if (this.Items[i].valueEnh > num3)
                        {
                            num3 = this.Items[i].valueEnh;
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
                if (this.Scales.Length < 1)
                {
                    this.pMaxValue = iValue;
                }
                else
                {
                    int num = 0;
                    int num2 = this.Scales.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        if (this.Scales[i] >= iValue)
                        {
                            this.pMaxValue = this.Scales[i];
                            return;
                        }
                    }
                    this.pMaxValue = this.Scales[this.Scales.Length - 1];
                }
            }
        }

        // Token: 0x060000CC RID: 204 RVA: 0x000092D8 File Offset: 0x000074D8
        protected int WhichScale(float iVal)
        {
            int num = 0;
            checked
            {
                int num2 = this.Scales.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (this.Scales[i] == iVal)
                    {
                        return i;
                    }
                }
                return this.Scales.Length - 1;
            }
        }

        // Token: 0x060000CD RID: 205 RVA: 0x00009334 File Offset: 0x00007534
        private void ctlMultiGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.pClickable & e.Button == MouseButtons.Left)
            {
                float valueAtXY = this.GetValueAtXY(e.X, e.Y);
                this.BarClick?.Invoke(valueAtXY);
            }
        }

        // Token: 0x060000CE RID: 206 RVA: 0x0000938C File Offset: 0x0000758C
        protected float GetValueAtXY(int iX, int iY)
        {
            checked
            {
                Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
                if (this.pShowScale)
                {
                    rectangle.Height -= this.pScaleHeight;
                    rectangle.Y += this.pScaleHeight;
                }
                int num = rectangle.Width;
                int height = this.ItemHeight + this.yPadding;
                int num2 = 0;
                int num3 = this.Items.Length - 1;
                for (int i = num2; i <= num3; i++)
                {
                    int num4 = (int)Math.Round(unchecked((double)this.yPadding / 2.0 + (double)(checked(i * (this.pItemHeight + this.yPadding)))));
                    Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top + num4, num, height);
                    if (iX >= rectangle2.X && ((iY >= rectangle2.Y & iY <= rectangle2.Y + rectangle2.Height) | this.Items.Length == 1))
                    {
                        num -= this.TextWidth;
                        float result;
                        if (iX > this.TextWidth)
                        {
                            iX -= this.TextWidth;
                            result = (float)(unchecked((double)iX / (double)num * (double)this.pMaxValue));
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
        private void ctlMultiGraph_MouseUp(object sender, MouseEventArgs e)
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
        public ctlMultiGraph.GraphItem[] Items;

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
        protected GraphStyle pStyle;

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
                this.valueBase = Base;
                this.valueEnh = Enh;
                this.Name = iName;
                this.Name2 = "";
                this.Tip = iTip;
            }

            // Token: 0x060000D1 RID: 209 RVA: 0x00009547 File Offset: 0x00007747
            public GraphItem(string iName, string iName2, float Base, float Enh, string iTip = "")
            {
                this.valueBase = Base;
                this.valueEnh = Enh;
                this.Name = iName;
                this.Name2 = iName2;
                this.Tip = iTip;
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
