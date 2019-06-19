// Decompiled with JetBrains decompiler
// Type: midsControls.ctlMultiGraph
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace midsControls
{
  [DefaultEvent("BarClick")]
  public class ctlMultiGraph : UserControl
  {
    private IContainer components;
    [AccessedThroughProperty("tTip")]
    private ToolTip _tTip;
    protected float[] Scales;
    public ctlMultiGraph.GraphItem[] Items;
    protected ExtendedBitmap bxBuffer;
    protected Graphics myGFX;
    protected Color pBaseColor;
    protected Color pEnhColor;
    protected Color pBlendColor1;
    protected Color pBlendColor2;
    protected Color pLineColor;
    protected Enums.GraphStyle pStyle;
    protected bool pDrawLines;
    protected bool pBorder;
    protected float pMaxValue;
    protected int yPadding;
    protected int xPadding;
    protected int oldMouseX;
    protected int oldMouseY;
    protected int pItemHeight;
    protected int nameWidth;
    protected bool Loaded;
    protected bool pShowScale;
    protected int pScaleHeight;
    protected bool pShowHighlight;
    protected int pHighlight;
    protected Color pHighlightColor;
    protected bool NoDraw;
    protected bool DualName;
    protected float pMarkerValue;
    protected Color pMarkerColor;
    protected Color pMarkerColor2;
    protected int pForcedMax;
    protected bool pClickable;
        private BarClickEventHandler BarClickEvent;

        public event ctlMultiGraph.BarClickEventHandler BarClick;

    internal virtual ToolTip tTip
    {
      get
      {
        return this._tTip;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tTip = value;
      }
    }

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

    public float PaddingX
    {
      get
      {
        return (float) this.xPadding;
      }
      set
      {
        this.xPadding = checked ((int) Math.Round((double) value));
        this.Draw();
      }
    }

    public float PaddingY
    {
      get
      {
        return (float) this.yPadding;
      }
      set
      {
        this.yPadding = checked ((int) Math.Round((double) value));
        this.Draw();
      }
    }

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

    public Enums.GraphStyle Style
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

    public int ScaleIndex
    {
      get
      {
        return this.WhichScale(this.pMaxValue);
      }
      set
      {
        if (value > -1 & value < this.Scales.Length)
          this.pMaxValue = this.Scales[value];
        this.Draw();
      }
    }

    public float ScaleValue
    {
      get
      {
        return this.pMaxValue;
      }
    }

    public int ItemCount
    {
      get
      {
        return this.Items.Length;
      }
    }

    public int ScaleCount
    {
      get
      {
        return this.Scales.Length;
      }
    }

    public float ForcedMax
    {
      get
      {
        return (float) this.pForcedMax;
      }
      set
      {
        this.pForcedMax = checked ((int) Math.Round((double) value));
        if (this.pForcedMax > 0)
          this.pMaxValue = (float) this.pForcedMax;
        else
          this.Max = this.GetMaxValue();
        this.Draw();
      }
    }

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

    public ctlMultiGraph()
    {
      this.MouseLeave += new EventHandler(this.ctlMultiGraph_MouseLeave);
      this.MouseDown += new MouseEventHandler(this.ctlMultiGraph_MouseDown);
      this.MouseUp += new MouseEventHandler(this.ctlMultiGraph_MouseUp);
      this.Load += new EventHandler(this.ctlMultiGraph_Load);
      this.BackColorChanged += new EventHandler(this.ctlMultiGraph_BackColorChanged);
      this.SizeChanged += new EventHandler(this.ctlMultiGraph_SizeChanged);
      this.Paint += new PaintEventHandler(this.ctlMultiGraph_Paint);
      this.FontChanged += new EventHandler(this.ctlMultiGraph_FontChanged);
      this.ForeColorChanged += new EventHandler(this.ctlMultiGraph_ForeColorChanged);
      this.Resize += new EventHandler(this.ctlMultiGraph_Resize);
      this.MouseMove += new MouseEventHandler(this.ctlMultiGraph_MouseMove);
      this.Scales = new float[0];
      this.Items = new ctlMultiGraph.GraphItem[0];
      this.pBaseColor = Color.Blue;
      this.pEnhColor = Color.Yellow;
      this.pBlendColor1 = Color.Black;
      this.pBlendColor2 = Color.Red;
      this.pLineColor = Color.Black;
      this.pStyle = Enums.GraphStyle.Twin;
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
      this.pHighlightColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.NoDraw = false;
      this.DualName = false;
      this.pMarkerValue = 0.0f;
      this.pMarkerColor = Color.Black;
      this.pMarkerColor2 = Color.Yellow;
      this.pForcedMax = 0;
      this.pClickable = false;
      this.InitializeComponent();
      this.FillScales();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.tTip = new ToolTip(this.components);
      this.tTip.AutoPopDelay = 10000;
      this.tTip.InitialDelay = 500;
      this.tTip.ReshowDelay = 100;
      this.Name = nameof (ctlMultiGraph);
      this.Size = new Size(332, 156);
    }

    private void ctlMultiGraph_Load(object sender, EventArgs e)
    {
      if (this.Items.Length < 1)
      {
        int num = 0;
        do
        {
          this.AddItemPair("Value " + Conversions.ToString(num), "Value " + Conversions.ToString(num) + "b", (float) checked ((int) Math.Round((double) Conversion.Int((float) unchecked (101.0 * (double) VBMath.Rnd() + 0.0)))), (float) checked ((int) Math.Round((double) Conversion.Int((float) unchecked (101.0 * (double) VBMath.Rnd() + 0.0)))), Conversions.ToString(num));
          checked { ++num; }
        }
        while (num <= 60);
      }
      this.Loaded = true;
      this.Draw();
    }

    public void AddItem(string sName, float nBase, float nEnh, string iTip = "")
    {
      this.Items = (ctlMultiGraph.GraphItem[]) Utils.CopyArray((Array) this.Items, (Array) new ctlMultiGraph.GraphItem[checked (this.Items.Length + 1)]);
      this.Items[checked (this.Items.Length - 1)] = new ctlMultiGraph.GraphItem(sName, nBase, nEnh, iTip);
    }

    public void AddItemPair(string sName, string sName2, float nBase, float nEnh, string iTip = "")
    {
      this.Items = (ctlMultiGraph.GraphItem[]) Utils.CopyArray((Array) this.Items, (Array) new ctlMultiGraph.GraphItem[checked (this.Items.Length + 1)]);
      this.Items[checked (this.Items.Length - 1)] = new ctlMultiGraph.GraphItem(sName, sName2, nBase, nEnh, iTip);
    }

    public void Clear()
    {
      this.Items = new ctlMultiGraph.GraphItem[0];
    }

    public void Draw()
    {
      if (this.NoDraw || !this.Loaded)
        return;
      this.myGFX = (Graphics) null;
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Size);
      if (this.bxBuffer.Graphics == null)
        return;
      this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), 0, 0, this.bxBuffer.Size.Width, this.bxBuffer.Size.Height);
      Rectangle Bounds = new Rectangle(this.nameWidth, 0, checked (this.Width - this.nameWidth - 1), checked (this.Height - 1));
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(Bounds, this.pBlendColor1, this.pBlendColor2, 0.0f);
      SolidBrush solidBrush = new SolidBrush(this.ForeColor);
      Pen pen = new Pen(this.pLineColor, 1f);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Far;
      format.FormatFlags = StringFormatFlags.NoWrap;
      format.Trimming = StringTrimming.None;
      this.bxBuffer.Graphics.FillRectangle((Brush) linearGradientBrush, Bounds);
      this.Draw_Scale(ref Bounds);
      this.Draw_Highlight(Bounds);
      int num1 = 0;
      int num2 = checked (this.Items.Length - 1);
      int Index = num1;
      while (Index <= num2)
      {
        int nY = checked (this.yPadding + Index * (this.pItemHeight + this.yPadding));
        if (!this.DualName | Operators.CompareString(this.Items[Index].Name, this.Items[Index].Name2, false) == 0)
        {
          string str = this.Items[Index].Name;
          if (Operators.CompareString(str, "", false) == 0)
            str = this.Items[Index].Name2;
          if (Operators.CompareString(str, "", false) != 0 && str.IndexOf(":") < 0)
            str += ":";
          int num3 = checked ((int) Math.Round(unchecked ((double) checked (Bounds.Top + nY) + ((double) this.pItemHeight - (double) this.Font.GetHeight(this.bxBuffer.Graphics)) / 2.0)));
          int length = str.IndexOf("|");
          RectangleF layoutRectangle = new RectangleF(0.0f, (float) num3, (float) checked (this.Width - Bounds.Width - this.xPadding), (float) checked (this.ItemHeight + this.yPadding * 2));
          if (length < 0)
          {
            this.bxBuffer.Graphics.DrawString(str, this.Font, (Brush) solidBrush, layoutRectangle, format);
          }
          else
          {
            format.Alignment = StringAlignment.Near;
            this.bxBuffer.Graphics.DrawString(str.Substring(0, length), this.Font, (Brush) solidBrush, layoutRectangle, format);
            format.Alignment = StringAlignment.Far;
            this.bxBuffer.Graphics.DrawString(str.Substring(checked (length + 1)), this.Font, (Brush) solidBrush, layoutRectangle, format);
          }
        }
        if (this.pStyle != Enums.GraphStyle.enhOnly & this.pStyle != Enums.GraphStyle.baseOnly)
        {
          if ((double) this.Items[Index].valueBase > (double) this.Items[Index].valueEnh)
          {
            this.DrawBase(Index, Bounds, nY);
            this.DrawEnh(Index, Bounds, nY);
          }
          else
          {
            this.DrawEnh(Index, Bounds, nY);
            this.DrawBase(Index, Bounds, nY);
          }
        }
        else if (this.pStyle == Enums.GraphStyle.baseOnly)
          this.DrawBase(Index, Bounds, nY);
        else if (this.pStyle == Enums.GraphStyle.enhOnly)
          this.DrawEnh(Index, Bounds, nY);
        checked { ++Index; }
      }
      if (this.pBorder)
        this.bxBuffer.Graphics.DrawRectangle(pen, Bounds);
      this.myGFX.DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
    }

    public void Draw_Highlight(Rectangle Bounds)
    {
      if (!this.pShowHighlight | this.pHighlight == -1)
        return;
      SolidBrush solidBrush = new SolidBrush(Color.FromArgb(128, (int) this.pHighlightColor.R, (int) this.pHighlightColor.G, (int) this.pHighlightColor.B));
      int width = Bounds.Width;
      int height = checked (this.pItemHeight + this.yPadding * 2);
      int num = checked (this.pHighlight * this.pItemHeight + this.yPadding);
      Rectangle rect = new Rectangle(Bounds.Left, checked (Bounds.Top + num), width, height);
      this.bxBuffer.Graphics.FillRectangle((Brush) solidBrush, rect);
    }

    public void Draw_Scale(ref Rectangle Bounds)
    {
      if (!this.pShowScale)
        return;
      SolidBrush solidBrush = new SolidBrush(this.ForeColor);
      Pen pen = new Pen(this.ForeColor, 1f);
      StringFormat format = new StringFormat();
      Rectangle rect = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, this.pScaleHeight);
      checked { Bounds.Y += rect.Height; }
      checked { Bounds.Height -= rect.Height; }
      this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), rect);
      this.bxBuffer.Graphics.DrawLine(pen, rect.X, checked (rect.Y + rect.Height), checked (rect.X + rect.Width), checked (rect.Y + rect.Height));
      format.Alignment = StringAlignment.Center;
      format.FormatFlags = StringFormatFlags.NoWrap;
      format.Trimming = StringTrimming.None;
      string Style = (double) this.Max < 100.0 ? ((double) this.Max < 10.0 ? ((double) this.Max < 5.0 ? "#0.##" : "#0.#") : "#0") : "#,##0";
      int num1 = checked ((int) Math.Round(unchecked ((double) rect.Width / 10.0)));
      int num2 = checked ((int) Math.Round(unchecked ((double) this.Font.GetHeight(this.bxBuffer.Graphics) + 1.0)));
      int num3 = this.nameWidth;
      int y1 = checked ((int) Math.Round(unchecked ((double) rect.Y + (double) rect.Height / 5.0 * 4.0)));
      int num4 = 0;
      do
      {
        int num5 = num3;
        Size size = this.bxBuffer.Size;
        int width = size.Width;
        if (num5 > width)
        {
          size = this.bxBuffer.Size;
          num3 = checked (size.Width - 1);
        }
        this.bxBuffer.Graphics.DrawLine(pen, num3, y1, num3, checked (rect.Y + rect.Height));
        RectangleF layoutRectangle = new RectangleF((float) num3 - (float) num1 / 2f, (float) checked (y1 - num2), (float) num1, (float) num2);
        if (num4 == 10)
        {
          layoutRectangle.X = (float) checked (num3 - num1);
          format.Alignment = StringAlignment.Far;
        }
        if (num4 > 0)
          this.bxBuffer.Graphics.DrawString(Strings.Format((object) (float) ((double) this.pMaxValue / 10.0 * (double) num4), Style), this.Font, (Brush) solidBrush, layoutRectangle, format);
        else
          this.bxBuffer.Graphics.DrawString("0", this.Font, (Brush) solidBrush, layoutRectangle, format);
        checked { num3 += num1; }
        checked { ++num4; }
      }
      while (num4 <= 10);
    }

    public void DrawBase(int Index, Rectangle Bounds, int nY)
    {
      SolidBrush solidBrush1 = new SolidBrush(this.pBaseColor);
      Pen pen1 = new Pen(this.pLineColor, 1f);
      SolidBrush solidBrush2 = new SolidBrush(this.ForeColor);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Far;
      format.FormatFlags = StringFormatFlags.NoWrap;
      format.Trimming = StringTrimming.None;
      int width = checked ((int) Math.Round(unchecked ((double) Bounds.Width * (double) this.Items[Index].valueBase / (double) this.pMaxValue)));
      int height = this.pItemHeight;
      if (this.Style == Enums.GraphStyle.Twin)
        height = checked ((int) Math.Round(unchecked ((double) height / 2.0)));
      Rectangle rect = new Rectangle(Bounds.Left, checked (Bounds.Top + nY), width, height);
      this.bxBuffer.Graphics.FillRectangle((Brush) solidBrush1, rect);
      if (this.pDrawLines)
        this.bxBuffer.Graphics.DrawRectangle(pen1, rect);
      if ((double) this.pMarkerValue > 0.0 & (double) this.pMarkerValue != (double) this.Items[Index].valueBase)
      {
        Pen pen2 = new Pen(this.pMarkerColor2, 3f);
        int num = checked ((int) Math.Round(unchecked ((double) rect.Left + (double) Bounds.Width * ((double) this.pMarkerValue / (double) this.pMaxValue))));
        this.bxBuffer.Graphics.DrawLine(pen2, num, checked (rect.Top + 1), num, rect.Bottom);
        this.bxBuffer.Graphics.DrawLine(new Pen(this.pMarkerColor, 1f), num, checked (rect.Top + 1), num, rect.Bottom);
      }
      if (this.Clickable)
      {
        Pen pen2 = new Pen(this.pMarkerColor2, 6f);
        int right = rect.Right;
        this.bxBuffer.Graphics.DrawLine(pen2, right, checked (rect.Top + 1), right, rect.Bottom);
        this.bxBuffer.Graphics.DrawLine(new Pen(this.pMarkerColor, 2f), right, checked (rect.Top + 1), right, rect.Bottom);
        Pen pen3 = new Pen(this.pMarkerColor2, 1f);
        this.bxBuffer.Graphics.DrawLine(pen3, checked (right - 1), rect.Top, checked (right + 1), rect.Top);
        this.bxBuffer.Graphics.DrawLine(pen3, checked (right - 1), rect.Bottom, checked (right + 1), rect.Bottom);
      }
      if (!(this.DualName & Operators.CompareString(this.Items[Index].Name, "", false) != 0 & Operators.CompareString(this.Items[Index].Name, this.Items[Index].Name2, false) != 0))
        return;
      RectangleF layoutRectangle = new RectangleF(0.0f, (float) rect.Top, (float) checked (this.Width - Bounds.Width - this.xPadding), (float) rect.Height);
      this.bxBuffer.Graphics.DrawString(this.Items[Index].Name + ":", this.Font, (Brush) solidBrush2, layoutRectangle, format);
    }

    public void DrawEnh(int Index, Rectangle Bounds, int nY)
    {
      SolidBrush solidBrush1 = new SolidBrush(this.pEnhColor);
      Pen pen1 = new Pen(this.pLineColor, 1f);
      SolidBrush solidBrush2 = new SolidBrush(this.ForeColor);
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Far;
      format.FormatFlags = StringFormatFlags.NoWrap;
      format.Trimming = StringTrimming.None;
      int width = checked ((int) Math.Round(unchecked ((double) Bounds.Width * (double) this.Items[Index].valueEnh / (double) this.pMaxValue)));
      int height = this.pItemHeight;
      if (this.Style == Enums.GraphStyle.Twin)
      {
        height = checked ((int) Math.Round(unchecked ((double) height / 2.0)));
        checked { nY += height; }
      }
      Rectangle rect = new Rectangle(Bounds.Left, checked (Bounds.Top + nY), width, height);
      this.bxBuffer.Graphics.FillRectangle((Brush) solidBrush1, rect);
      if (this.pDrawLines)
        this.bxBuffer.Graphics.DrawRectangle(pen1, rect);
      if ((double) this.pMarkerValue > 0.0 & (double) this.pMarkerValue != (double) this.Items[Index].valueEnh)
      {
        Pen pen2 = new Pen(this.pMarkerColor2, 3f);
        int num = checked ((int) Math.Round(unchecked ((double) rect.Left + (double) Bounds.Width * ((double) this.pMarkerValue / (double) this.pMaxValue))));
        this.bxBuffer.Graphics.DrawLine(pen2, num, checked (rect.Top + 1), num, rect.Bottom);
        this.bxBuffer.Graphics.DrawLine(new Pen(this.pMarkerColor, 1f), num, checked (rect.Top + 1), num, rect.Bottom);
      }
      if (!(this.DualName & Operators.CompareString(this.Items[Index].Name2, "", false) != 0 & Operators.CompareString(this.Items[Index].Name, this.Items[Index].Name2, false) != 0))
        return;
      RectangleF layoutRectangle = new RectangleF(0.0f, (float) rect.Top, (float) checked (this.Width - Bounds.Width - this.xPadding), (float) rect.Height);
      this.bxBuffer.Graphics.DrawString(this.Items[Index].Name2 + ":", this.Font, (Brush) solidBrush2, layoutRectangle, format);
    }

    private void ctlMultiGraph_BackColorChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void ctlMultiGraph_SizeChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void ctlMultiGraph_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxBuffer == null)
        return;
      e.Graphics.DrawImage((Image) this.bxBuffer.Bitmap, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle, GraphicsUnit.Pixel);
    }

    private void ctlMultiGraph_FontChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void ctlMultiGraph_ForeColorChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void ctlMultiGraph_Resize(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void ctlMultiGraph_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.pClickable & e.Button == MouseButtons.Left)
      {
        float valueAtXy = this.GetValueAtXY(e.X, e.Y);
        ctlMultiGraph.BarClickEventHandler barClickEvent = this.BarClickEvent;
        if (barClickEvent != null)
          barClickEvent(valueAtXy);
      }
      else
      {
        if (e.X == this.oldMouseX & e.Y == this.oldMouseY)
          return;
        this.oldMouseX = e.X;
        this.oldMouseY = e.Y;
        int pHighlight = this.pHighlight;
        Rectangle rectangle1 = new Rectangle(0, 0, checked (this.Width - 1), checked (this.Height - 1));
        if (this.pShowScale)
        {
          checked { rectangle1.Height -= this.pScaleHeight; }
          checked { rectangle1.Y += this.pScaleHeight; }
        }
        int width = rectangle1.Width;
        int height = checked (this.ItemHeight + this.yPadding);
        int num1 = 0;
        int num2 = checked (this.Items.Length - 1);
        int index = num1;
        while (index <= num2)
        {
          int num3 = checked ((int) Math.Round(unchecked ((double) this.yPadding / 2.0 + (double) checked (index * this.pItemHeight + this.yPadding))));
          Rectangle rectangle2 = new Rectangle(rectangle1.Left, checked (rectangle1.Top + num3), width, height);
          if (e.X >= rectangle2.X & e.X <= checked (rectangle2.X + rectangle2.Width) && e.Y >= rectangle2.Y & e.Y <= checked (rectangle2.Y + rectangle2.Height))
          {
            this.pHighlight = index;
            this.tTip.SetToolTip((Control) this, this.Items[index].Tip);
            if (pHighlight == this.pHighlight)
              return;
            this.Draw();
            return;
          }
          checked { ++index; }
        }
        this.pHighlight = -1;
        this.tTip.SetToolTip((Control) this, "");
        if (pHighlight != this.pHighlight)
          this.Draw();
      }
    }

    private void ctlMultiGraph_MouseLeave(object sender, EventArgs e)
    {
      int pHighlight = this.pHighlight;
      this.pHighlight = -1;
      if (pHighlight == this.pHighlight)
        return;
      this.Draw();
    }

    public void BeginUpdate()
    {
      this.NoDraw = true;
    }

    public void EndUpdate()
    {
      this.NoDraw = false;
      this.Draw();
    }

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

    protected void AddScale(float iValue)
    {
      this.Scales = (float[]) Utils.CopyArray((Array) this.Scales, (Array) new float[checked (this.Scales.Length + 1)]);
      this.Scales[checked (this.Scales.Length - 1)] = iValue;
    }

    public float GetMaxValue()
    {
      if (this.Scales.Length < 1)
      {
        this.pMaxValue = 100f;
        return 100f;
      }
      int num1 = 0;
      int num2 = checked (this.Items.Length - 1);
      float num3 = 0.0f;
      int index = num1;
      while (index <= num2)
      {
        if ((double) this.Items[index].valueBase > (double) num3)
          num3 = this.Items[index].valueBase;
        if ((double) this.Items[index].valueEnh > (double) num3)
          num3 = this.Items[index].valueEnh;
        checked { ++index; }
      }
      return num3;
    }

    protected void SetBestScale(float iValue)
    {
      if (this.Scales.Length < 1)
      {
        this.pMaxValue = iValue;
      }
      else
      {
        int num1 = 0;
        int num2 = checked (this.Scales.Length - 1);
        int index = num1;
        while (index <= num2)
        {
          if ((double) this.Scales[index] >= (double) iValue)
          {
            this.pMaxValue = this.Scales[index];
            return;
          }
          checked { ++index; }
        }
        this.pMaxValue = this.Scales[checked (this.Scales.Length - 1)];
      }
    }

    protected int WhichScale(float iVal)
    {
      int num1 = 0;
      int num2 = checked (this.Scales.Length - 1);
      int index = num1;
      while (index <= num2)
      {
        if ((double) this.Scales[index] == (double) iVal)
          return index;
        checked { ++index; }
      }
      return checked (this.Scales.Length - 1);
    }

    private void ctlMultiGraph_MouseDown(object sender, MouseEventArgs e)
    {
      if (!(this.pClickable & e.Button == MouseButtons.Left))
        return;
      float valueAtXy = this.GetValueAtXY(e.X, e.Y);
      ctlMultiGraph.BarClickEventHandler barClickEvent = this.BarClickEvent;
      if (barClickEvent != null)
        barClickEvent(valueAtXy);
    }

    protected float GetValueAtXY(int iX, int iY)
    {
      Rectangle rectangle1 = new Rectangle(0, 0, checked (this.Width - 1), checked (this.Height - 1));
      if (this.pShowScale)
      {
        checked { rectangle1.Height -= this.pScaleHeight; }
        checked { rectangle1.Y += this.pScaleHeight; }
      }
      int width = rectangle1.Width;
      int height = checked (this.ItemHeight + this.yPadding);
      int num1 = 0;
      int num2 = checked (this.Items.Length - 1);
      int num3 = num1;
      while (num3 <= num2)
      {
        int num4 = checked ((int) Math.Round(unchecked ((double) this.yPadding / 2.0 + (double) checked (num3 * this.pItemHeight + this.yPadding))));
        Rectangle rectangle2 = new Rectangle(rectangle1.Left, checked (rectangle1.Top + num4), width, height);
        if (iX >= rectangle2.X && iY >= rectangle2.Y & iY <= checked (rectangle2.Y + rectangle2.Height) | this.Items.Length == 1)
        {
          int num5 = checked (width - this.TextWidth);
          if (iX <= this.TextWidth)
            return 0.0f;
          checked { iX -= this.TextWidth; }
          return (float) iX / (float) num5 * this.pMaxValue;
        }
        checked { ++num3; }
      }
      return 0.0f;
    }

    private void ctlMultiGraph_MouseUp(object sender, MouseEventArgs e)
    {
    }

    public class GraphItem
    {
      public float valueBase;
      public float valueEnh;
      public string Name;
      public string Name2;
      public string Tip;

      public GraphItem(string iName, float Base, float Enh, string iTip = "")
      {
        this.valueBase = Base;
        this.valueEnh = Enh;
        this.Name = iName;
        this.Name2 = "";
        this.Tip = iTip;
      }

      public GraphItem(string iName, string iName2, float Base, float Enh, string iTip = "")
      {
        this.valueBase = Base;
        this.valueEnh = Enh;
        this.Name = iName;
        this.Name2 = iName2;
        this.Tip = iTip;
      }
    }

    public delegate void BarClickEventHandler(float Value);
  }
}
