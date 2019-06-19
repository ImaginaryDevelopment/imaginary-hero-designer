// Decompiled with JetBrains decompiler
// Type: midsControls.GFXLabel
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Display;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace midsControls
{
  public class GFXLabel : UserControl
  {
    private IContainer components;
    private string myText;
    private ExtendedBitmap bxBuffer;
    private Graphics myGFX;
    private ContentAlignment myAlign;

    public override string Text
    {
      get
      {
        return this.myText;
      }
      set
      {
        if (Operators.CompareString(value, this.myText, false) == 0)
          return;
        this.myText = value;
        this.Draw();
      }
    }

    public string InitialText
    {
      get
      {
        return this.myText;
      }
      set
      {
        if (Operators.CompareString(value, this.myText, false) == 0)
          return;
        this.myText = value;
        this.Draw();
      }
    }

    public ContentAlignment TextAlign
    {
      get
      {
        return this.myAlign;
      }
      set
      {
        this.myAlign = value;
        this.Draw();
      }
    }

    public GFXLabel()
    {
      this.BackColorChanged += new EventHandler(this.GFXLabel_BackColorChanged);
      this.FontChanged += new EventHandler(this.GFXLabel_FontChanged);
      this.SizeChanged += new EventHandler(this.GFXLabel_SizeChanged);
      this.Resize += new EventHandler(this.GFXLabel_Resize);
      this.Load += new EventHandler(this.GFXLabel_Load);
      this.Paint += new PaintEventHandler(this.GFXlabel_Paint);
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
      this.Name = nameof (GFXLabel);
      this.Size = new Size(324, 72);
    }

    private void GFXLabel_Load(object sender, EventArgs e)
    {
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.Draw();
    }

    private void Draw()
    {
      if (this.bxBuffer == null)
        return;
      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
      RectangleF layoutRectangle = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
      StringFormat format = new StringFormat();
      layoutRectangle.X = 0.0f;
      layoutRectangle.Width = (float) this.Width;
      layoutRectangle.Height = this.Font.GetHeight();
      this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), rect);
      Brush brush = (Brush) new SolidBrush(this.ForeColor);
      float num1 = 1f;
      int num2 = checked ((int) Math.Round((double) this.bxBuffer.Graphics.MeasureString(this.myText, this.Font, (int) Math.Round(unchecked ((double) layoutRectangle.Width * 10.0)), format).Width));
      int num3 = num2;
      Size size = this.bxBuffer.Size;
      int num4 = checked (size.Width - 10);
      if (num3 > num4)
      {
        size = this.bxBuffer.Size;
        num1 = ((float) size.Width - 10f) / (float) num2;
      }
      float num5;
      if ((double) num1 < 0.6)
      {
        num1 = 0.6f;
        num5 = 2f;
      }
      else
        num5 = 1f;
      Font font = new Font(this.Font.Name, this.Font.Size * num1, this.Font.Style, GraphicsUnit.Point, (byte) 0);
      layoutRectangle.Height = font.GetHeight() * num5;
      switch (this.myAlign)
      {
        case ContentAlignment.TopLeft:
          format.Alignment = StringAlignment.Near;
          layoutRectangle.Y = 0.0f;
          break;
        case ContentAlignment.TopCenter:
          format.Alignment = StringAlignment.Center;
          layoutRectangle.Y = 0.0f;
          break;
        case ContentAlignment.TopRight:
          format.Alignment = StringAlignment.Far;
          layoutRectangle.Y = 0.0f;
          break;
        case ContentAlignment.MiddleLeft:
          format.Alignment = StringAlignment.Near;
          layoutRectangle.Y = (float) (((double) this.Height - (double) layoutRectangle.Height) / 2.0);
          break;
        case ContentAlignment.MiddleCenter:
          format.Alignment = StringAlignment.Center;
          layoutRectangle.Y = (float) (((double) this.Height - (double) layoutRectangle.Height) / 2.0);
          break;
        case ContentAlignment.MiddleRight:
          format.Alignment = StringAlignment.Far;
          layoutRectangle.Y = (float) (((double) this.Height - (double) layoutRectangle.Height) / 2.0);
          break;
        case ContentAlignment.BottomLeft:
          format.Alignment = StringAlignment.Near;
          layoutRectangle.Y = (float) this.Height - layoutRectangle.Height;
          break;
        case ContentAlignment.BottomCenter:
          format.Alignment = StringAlignment.Center;
          layoutRectangle.Y = (float) this.Height - layoutRectangle.Height;
          break;
        case ContentAlignment.BottomRight:
          format.Alignment = StringAlignment.Far;
          layoutRectangle.Y = (float) this.Height - layoutRectangle.Height;
          break;
      }
      this.bxBuffer.Graphics.DrawString(this.myText, font, brush, layoutRectangle, format);
      this.myGFX.DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
    }

    private void GFXlabel_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxBuffer == null)
        return;
      this.myGFX.DrawImage((Image) this.bxBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
    }

    protected override void OnResize(EventArgs e)
    {
      this.Draw();
    }

    protected override void OnFontChanged(EventArgs e)
    {
      this.Draw();
    }

    protected override void OnForeColorChanged(EventArgs e)
    {
      this.Draw();
    }

    private void GFXLabel_BackColorChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void GFXLabel_FontChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void GFXLabel_SizeChanged(object sender, EventArgs e)
    {
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.Draw();
    }

    private void GFXLabel_Resize(object sender, EventArgs e)
    {
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.Draw();
    }
  }
}
