// Decompiled with JetBrains decompiler
// Type: midsControls.ctlDamageDisplay
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Display;
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
  public class ctlDamageDisplay : UserControl
  {
    private IContainer components;
    [AccessedThroughProperty("myTip")]
    private ToolTip _myTip;
    protected ExtendedBitmap bxBuffer;
    protected Graphics myGFX;
    protected Enums.eDDStyle pStyle;
    protected Enums.eDDText pText;
    protected Enums.eDDGraph pGraph;
    protected Color pFadeBackStart;
    protected Color pFadeBackEnd;
    protected Color pFadeBaseStart;
    protected Color pFadeBaseEnd;
    protected Color pFadeEnhStart;
    protected Color pFadeEnhEnd;
    protected Color pTextColor;
    protected int pvPadding;
    protected int phPadding;
    protected Enums.eDDAlign pAlign;
    protected float nBase;
    protected float nEnhanced;
    protected float nMaxEnhanced;
    protected float nHighestBase;
    protected float nHighestEnhanced;
    protected string pString;

    internal virtual ToolTip myTip
    {
      get
      {
        return this._myTip;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._myTip = value;
      }
    }

    public int PaddingV
    {
      get
      {
        return this.pvPadding;
      }
      set
      {
        if (!(value >= 0 & checked (value * 2) < checked (this.Height - 5)))
          return;
        this.pvPadding = value;
        this.Draw();
      }
    }

    public int PaddingH
    {
      get
      {
        return this.phPadding;
      }
      set
      {
        if (!(value >= 0 & checked (value * 2) < checked (this.Width - 5)))
          return;
        this.phPadding = value;
        this.Draw();
      }
    }

    public Color ColorBackStart
    {
      get
      {
        return this.pFadeBackStart;
      }
      set
      {
        this.pFadeBackStart = value;
        this.Draw();
      }
    }

    public Color ColorBackEnd
    {
      get
      {
        return this.pFadeBackEnd;
      }
      set
      {
        this.pFadeBackEnd = value;
        this.Draw();
      }
    }

    public Color ColorBaseStart
    {
      get
      {
        return this.pFadeBaseStart;
      }
      set
      {
        this.pFadeBaseStart = value;
        this.Draw();
      }
    }

    public Color ColorBaseEnd
    {
      get
      {
        return this.pFadeBaseEnd;
      }
      set
      {
        this.pFadeBaseEnd = value;
        this.Draw();
      }
    }

    public Color ColorEnhStart
    {
      get
      {
        return this.pFadeEnhStart;
      }
      set
      {
        this.pFadeEnhStart = value;
        this.Draw();
      }
    }

    public Color ColorEnhEnd
    {
      get
      {
        return this.pFadeEnhEnd;
      }
      set
      {
        this.pFadeEnhEnd = value;
        this.Draw();
      }
    }

    public Color TextColor
    {
      get
      {
        return this.pTextColor;
      }
      set
      {
        this.pTextColor = value;
        this.Draw();
      }
    }

    public Enums.eDDAlign TextAlign
    {
      get
      {
        return this.pAlign;
      }
      set
      {
        this.pAlign = value;
        this.Draw();
      }
    }

    public Enums.eDDStyle Style
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

    public Enums.eDDGraph GraphType
    {
      get
      {
        return this.pGraph;
      }
      set
      {
        this.pGraph = value;
        this.Draw();
      }
    }

    public float nBaseVal
    {
      get
      {
        return this.nBase;
      }
      set
      {
        this.nBase = value;
        this.Draw();
      }
    }

    public float nEnhVal
    {
      get
      {
        return this.nEnhanced;
      }
      set
      {
        this.nEnhanced = value;
        this.Draw();
      }
    }

    public float nMaxEnhVal
    {
      get
      {
        return this.nMaxEnhanced;
      }
      set
      {
        this.nMaxEnhanced = value;
        this.Draw();
      }
    }

    public float nHighBase
    {
      get
      {
        return this.nHighestBase;
      }
      set
      {
        this.nHighestBase = value;
        this.Draw();
      }
    }

    public float nHighEnh
    {
      get
      {
        return this.nHighestEnhanced;
      }
      set
      {
        this.nHighestEnhanced = value;
        this.Draw();
      }
    }

    public override string Text
    {
      get
      {
        return this.pString;
      }
      set
      {
        this.pString = value;
        this.Draw();
      }
    }

    public ctlDamageDisplay()
    {
      this.BackColorChanged += new EventHandler(this.ctlDamageDisplay_BackColorChanged);
      this.Load += new EventHandler(this.ctlDamageDisplay_Load);
      this.Paint += new PaintEventHandler(this.ctlDamageDisplayt_Paint);
      this.pStyle = Enums.eDDStyle.TextUnderGraph;
      this.pText = Enums.eDDText.ActualValues;
      this.pGraph = Enums.eDDGraph.Both;
      this.pFadeBackStart = Color.Lime;
      this.pFadeBackEnd = Color.Yellow;
      this.pFadeBaseStart = Color.Blue;
      this.pFadeBaseEnd = Color.LightBlue;
      this.pFadeEnhStart = Color.Blue;
      this.pFadeEnhEnd = Color.Red;
      this.pTextColor = Color.Black;
      this.pvPadding = 6;
      this.phPadding = 3;
      this.pAlign = Enums.eDDAlign.Center;
      this.nBase = 100f;
      this.nEnhanced = 196f;
      this.nMaxEnhanced = 207f;
      this.nHighestBase = 200f;
      this.nHighestEnhanced = 414f;
      this.pString = "196 (100)";
      this.InitializeComponent();
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
      this.myTip = new ToolTip(this.components);
      this.myTip.AutoPopDelay = 20000;
      this.myTip.InitialDelay = 350;
      this.myTip.ReshowDelay = 100;
      this.Name = nameof (ctlDamageDisplay);
      this.Size = new Size(312, 104);
    }

    private void ctlDamageDisplay_Load(object sender, EventArgs e)
    {
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.Draw();
    }

    public void FullUpdate()
    {
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.Draw();
    }

    private void ctlDamageDisplayt_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxBuffer == null)
        return;
      this.myGFX.DrawImage((Image) this.bxBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
    }

    protected override void OnFontChanged(EventArgs e)
    {
      this.Draw();
    }

    protected override void OnForeColorChanged(EventArgs e)
    {
      this.Draw();
    }

    protected override void OnResize(EventArgs e)
    {
      this.FullUpdate();
    }

    public void DrawGraph()
    {
      float height1 = this.Font.GetHeight(this.bxBuffer.Graphics);
      Rectangle rectangle1 = new Rectangle(0, 0, this.Width, this.Height);
      Rectangle rect1 = new Rectangle(0, 0, this.Width, this.Height);
      if (this.pStyle == Enums.eDDStyle.TextUnderGraph)
        rect1.Height = checked ((int) Math.Round(unchecked ((double) rect1.Height - (double) height1)));
      Rectangle rectangle2 = new Rectangle(this.phPadding, this.pvPadding, checked (this.Width - this.phPadding * 2), checked (rect1.Height - this.pvPadding * 2));
      this.bxBuffer.Graphics.FillRectangle((Brush) new LinearGradientBrush(rect1, this.pFadeBackStart, this.pFadeBackEnd, 0.0f), rect1);
      if ((double) this.nBase == 0.0)
        return;
      if ((double) this.nMaxEnhanced == 0.0)
        this.nMaxEnhanced = this.nBase * 2f;
      if ((double) this.nHighestEnhanced == 0.0)
        this.nHighestEnhanced = this.nBase * 2f;
      if ((double) this.nHighestBase == 0.0)
        this.nHighestBase = this.nBase * 2f;
      Rectangle rectangle3;
      if (this.pGraph == Enums.eDDGraph.Simple)
      {
        int width1 = checked ((int) Math.Round(unchecked ((double) this.nBase / (double) this.nMaxEnhanced * (double) rectangle2.Width)));
        SolidBrush solidBrush = new SolidBrush(this.pFadeBaseStart);
        Rectangle rect2 = new Rectangle(rectangle2.X, rectangle2.Y, width1, rectangle2.Height);
        this.bxBuffer.Graphics.FillRectangle((Brush) solidBrush, rect2);
        int width2 = checked ((int) Math.Round(unchecked ((double) this.nEnhanced / (double) this.nMaxEnhanced * (double) rectangle2.Width - (double) width1)));
        rect2 = new Rectangle(checked (rectangle2.X + width1), rectangle2.Y, width2, rectangle2.Height);
        this.bxBuffer.Graphics.FillRectangle((Brush) new LinearGradientBrush(new Rectangle()
        {
          X = checked (rectangle2.X + width1),
          Y = rectangle2.Y,
          Width = checked (rectangle2.Width - width1) <= 0 ? 1 : checked (rectangle2.Width - width1),
          Height = rectangle2.Height
        }, this.pFadeEnhStart, this.pFadeEnhEnd, 0.0f), rect2);
      }
      else if (this.pGraph == Enums.eDDGraph.Stacked)
      {
        int width1 = checked ((int) Math.Round(unchecked ((double) this.nBase / (double) this.nHighestEnhanced * (double) rectangle2.Width)));
        Rectangle rect2 = new Rectangle(rectangle2.X, rectangle2.Y, checked ((int) Math.Round(unchecked ((double) this.nBase / (double) this.nHighestBase * (double) rectangle2.Width))), rectangle2.Height);
        if (rect2.Width < 1)
          rect2.Width = 1;
        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, this.pFadeBaseStart, this.pFadeBaseEnd, 0.0f);
        rect2 = new Rectangle(rectangle2.X, rectangle2.Y, width1, rectangle2.Height);
        this.bxBuffer.Graphics.FillRectangle((Brush) linearGradientBrush, rect2);
        int width2 = checked ((int) Math.Round(unchecked (((double) this.nEnhanced - (double) this.nBase) / (double) this.nHighestEnhanced * (double) rectangle2.Width)));
        rect2 = new Rectangle(checked (rectangle2.X + width1), rectangle2.Y, width2, rectangle2.Height);
        if (rect2.Width < 1)
          rect2.Width = 1;
        this.bxBuffer.Graphics.FillRectangle((Brush) new LinearGradientBrush(rectangle2, this.pFadeEnhStart, this.pFadeEnhEnd, 0.0f), rect2);
      }
      else if (this.pGraph == Enums.eDDGraph.Both)
      {
        int height2 = checked ((int) Math.Round(unchecked ((double) rectangle2.Height / 2.0)));
        int width1 = checked ((int) Math.Round(unchecked ((double) this.nBase / (double) this.nHighestEnhanced * (double) rectangle2.Width)));
        Rectangle rect2 = new Rectangle(rectangle2.X, rectangle2.Y, checked ((int) Math.Round(unchecked (0.5 * (double) rectangle2.Width))), height2);
        if (rect2.Width < 1)
          rect2.Width = 1;
        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, this.pFadeBaseStart, this.pFadeBaseEnd, 0.0f);
        rect2 = new Rectangle(rectangle2.X, rectangle2.Y, width1, height2);
        if (rect2.Width < 1)
          rect2.Width = 1;
        this.bxBuffer.Graphics.FillRectangle((Brush) linearGradientBrush, rect2);
        int width2 = checked ((int) Math.Round(unchecked ((double) this.nEnhanced / (double) this.nHighestEnhanced * (double) rectangle2.Width)));
        rect2 = new Rectangle(rectangle2.X, checked (height2 + rectangle2.Y), width2, height2);
        if (rect2.Width < 1)
          rect2.Width = 1;
        this.bxBuffer.Graphics.FillRectangle((Brush) new LinearGradientBrush(rectangle2, this.pFadeEnhStart, this.pFadeEnhEnd, 0.0f), rect2);
      }
      else if (this.pGraph == Enums.eDDGraph.Enhanced)
      {
        int width = checked ((int) Math.Round(unchecked ((double) this.nEnhanced / (double) this.nHighestEnhanced * (double) rectangle2.Width)));
        Rectangle rect2 = new Rectangle(rectangle2.X, rectangle2.Y, width, rectangle2.Height);
        if (rect2.Width < 1)
          rect2.Width = 1;
        rectangle3 = new Rectangle(checked (rectangle2.X + width), rectangle2.Y, checked (rectangle2.Width - width), rectangle2.Height);
        this.bxBuffer.Graphics.FillRectangle((Brush) new LinearGradientBrush(rectangle3, this.pFadeEnhStart, this.pFadeEnhEnd, 0.0f), rect2);
      }
      if (this.pStyle == Enums.eDDStyle.TextOnGraph)
        this.DrawText(rectangle2);
      else if (this.pStyle == Enums.eDDStyle.TextUnderGraph)
      {
        rectangle3 = new Rectangle(rectangle2.X, checked (rectangle2.Y + rectangle2.Height), rectangle2.Width, checked (rectangle1.Height - rectangle2.Y + rectangle2.Height));
        this.DrawText(rectangle3);
      }
    }

    public void DrawText(Rectangle Bounds)
    {
      RectangleF layoutRectangle = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
      StringFormat format = new StringFormat();
      float height = this.Font.GetHeight(this.myGFX);
      this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      layoutRectangle.X = (float) checked (Bounds.X + this.phPadding);
      layoutRectangle.Y = this.pStyle != Enums.eDDStyle.TextUnderGraph ? (float) ((double) Bounds.Y + ((double) Bounds.Height - (double) height) / 2.0 - 1.0) : (float) ((double) Bounds.Y + ((double) Bounds.Height - (double) height) / 2.0 + 2.0);
      layoutRectangle.Width = (float) checked (Bounds.Width - this.phPadding * 2);
      layoutRectangle.Height = (float) Bounds.Height;
      Brush brush = (Brush) new SolidBrush(this.pTextColor);
      switch (this.pAlign)
      {
        case Enums.eDDAlign.Left:
          format.Alignment = StringAlignment.Near;
          break;
        case Enums.eDDAlign.Center:
          format.Alignment = StringAlignment.Center;
          break;
        case Enums.eDDAlign.Right:
          format.Alignment = StringAlignment.Far;
          break;
      }
      if (this.pText != Enums.eDDText.ActualValues)
        ;
      SizeF sizeF = this.bxBuffer.Graphics.MeasureString(this.pString, this.Font);
      if ((double) sizeF.Width > (double) layoutRectangle.Width)
      {
        this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        this.bxBuffer.Graphics.DrawString(this.pString, new Font(this.Font.Name, this.Font.Size * (layoutRectangle.Width / sizeF.Width), this.Font.Style, GraphicsUnit.Point), brush, layoutRectangle, format);
      }
      else
      {
        this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        this.bxBuffer.Graphics.DrawString(this.pString, this.Font, brush, layoutRectangle, format);
      }
    }

    public void Draw()
    {
      if (this.bxBuffer == null)
        return;
      Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);
      this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), rectangle);
      if (this.pStyle != Enums.eDDStyle.Text)
        this.DrawGraph();
      else
        this.DrawText(rectangle);
      this.myGFX.DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
    }

    public void SetTip(string iTip)
    {
      this.myTip.SetToolTip((Control) this, iTip);
    }

    private void ctlDamageDisplay_BackColorChanged(object sender, EventArgs e)
    {
      this.Draw();
    }
  }
}
