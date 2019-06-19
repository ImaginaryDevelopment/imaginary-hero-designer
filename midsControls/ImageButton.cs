// Decompiled with JetBrains decompiler
// Type: midsControls.ImageButton
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Display;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace midsControls
{
  [DefaultEvent("ButtonClicked")]
  [DesignerGenerated]
  public class ImageButton : UserControl
  {
    private IContainer components;
    private ExtendedBitmap bxImage;
    private ExtendedBitmap bxAltImage;
    private ExtendedBitmap bxOut;
    private string pTextOff;
    private string pTextOn;
    private bool pToggle;
    private bool pAltState;
    private bool pTogState;
    private ImageAttributes myIA;
    private PictureBox Knockout;
    private Point KnockoutLocation;

    public event ImageButton.ButtonClickedEventHandler ButtonClicked;

    public string TextOff
    {
      get
      {
        return this.pTextOff;
      }
      set
      {
        this.pTextOff = value;
        this.Redraw();
      }
    }

    public string TextOn
    {
      get
      {
        return this.pTextOn;
      }
      set
      {
        this.pTextOn = value;
        this.Redraw();
      }
    }

    public bool Toggle
    {
      get
      {
        return this.pToggle;
      }
      set
      {
        this.pToggle = value;
        this.Redraw();
      }
    }

    public bool Checked
    {
      get
      {
        return this.pAltState;
      }
      set
      {
        this.pAltState = value;
        this.Redraw();
      }
    }

    public ImageAttributes IA
    {
      set
      {
        this.myIA = value;
      }
    }

    public Bitmap ImageOff
    {
      set
      {
        this.bxImage = new ExtendedBitmap(this.Width, this.Height);
        this.bxImage.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        Graphics graphics = this.bxImage.Graphics;
        Bitmap bitmap = value;
        Size size = this.bxImage.Size;
        int width = size.Width;
        size = this.bxImage.Size;
        int height = size.Height;
        graphics.DrawImage((Image) bitmap, 0, 0, width, height);
        this.Redraw();
      }
    }

    public Bitmap ImageOn
    {
      set
      {
        this.bxAltImage = new ExtendedBitmap(this.Width, this.Height);
        this.bxImage.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        Graphics graphics = this.bxAltImage.Graphics;
        Bitmap bitmap = value;
        Size size = this.bxAltImage.Size;
        int width = size.Width;
        size = this.bxAltImage.Size;
        int height = size.Height;
        graphics.DrawImage((Image) bitmap, 0, 0, width, height);
        this.Redraw();
      }
    }

    public PictureBox KnockoutPB
    {
      set
      {
        this.Knockout = value;
        this.Redraw();
      }
    }

    public Point KnockoutLocationPoint
    {
      get
      {
        return this.KnockoutLocation;
      }
      set
      {
        this.KnockoutLocation = value;
        if (this.Knockout == null)
          return;
        this.Redraw();
      }
    }

    public ImageButton()
    {
      this.MouseDown += new MouseEventHandler(this.ImageButton_MouseDown);
      this.MouseLeave += new EventHandler(this.ImageButton_MouseLeave);
      this.MouseUp += new MouseEventHandler(this.ImageButton_MouseUp);
      this.Paint += new PaintEventHandler(this.ImageButton_Paint);
      this.SizeChanged += new EventHandler(this.ImageButton_SizeChanged);
      this.BackColorChanged += new EventHandler(this.ImageButton_BackColorChanged);
      this.FontChanged += new EventHandler(this.ImageButton_FontChanged);
      this.bxImage = (ExtendedBitmap) null;
      this.bxAltImage = (ExtendedBitmap) null;
      this.bxOut = (ExtendedBitmap) null;
      this.pTextOff = "Button Text";
      this.pTextOn = "Alt Text";
      this.pToggle = false;
      this.pAltState = false;
      this.pTogState = false;
      this.myIA = (ImageAttributes) null;
      this.Knockout = (PictureBox) null;
      this.KnockoutLocation = new Point(0, 0);
      this.InitializeComponent();
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Name = nameof (ImageButton);
      this.ResumeLayout(false);
    }

    private void Redraw()
    {
      this.Draw();
      if (this.bxOut.Bitmap == null)
        return;
      this.CreateGraphics().DrawImage((Image) this.bxOut.Bitmap, 0, 0);
    }

    public void SetImages(ImageAttributes IA, Bitmap ImageOff, Bitmap ImageOn)
    {
      this.IA = IA;
      this.ImageOff = ImageOff;
      this.ImageOn = ImageOn;
      this.Redraw();
    }

    private void ImageButton_BackColorChanged(object sender, EventArgs e)
    {
      this.Redraw();
    }

    private void ImageButton_FontChanged(object sender, EventArgs e)
    {
      this.Redraw();
    }

    private void Draw()
    {
      StringFormat stringFormat = new StringFormat();
      if (this.bxOut == null)
      {
        if (this.Width == 0 | this.Height == 0)
        {
          this.bxOut = (ExtendedBitmap) null;
          return;
        }
        this.bxOut = new ExtendedBitmap(this.Width, this.Height);
      }
      this.bxOut.Graphics.TextContrast = 0;
      this.bxOut.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;
      this.bxOut.Graphics.Clear(this.BackColor);
      Point location;
      Rectangle rectangle;
      if (this.Knockout != null && this.KnockoutLocation.X > -1 & this.KnockoutLocation.Y > -1)
      {
        Rectangle srcRect = new Rectangle(this.KnockoutLocation, this.Size);
        Graphics graphics = this.bxOut.Graphics;
        Image image = this.Knockout.Image;
        location = new Point(0, 0);
        rectangle = new Rectangle(location, this.bxOut.Size);
        graphics.DrawImage(image, rectangle, srcRect, GraphicsUnit.Pixel);
      }
      if (!(this.bxImage == null | this.bxAltImage == null))
      {
        if (this.pAltState | this.pToggle & this.pTogState)
          this.bxOut.Graphics.DrawImageUnscaled((Image) this.bxAltImage.Bitmap, 0, 0);
        else if (this.myIA != null)
        {
          Graphics graphics1 = this.bxOut.Graphics;
          Image bitmap = (Image) this.bxImage.Bitmap;
          location = new Point(0, 0);
          rectangle = new Rectangle(location, this.bxOut.Size);
          Graphics graphics2 = graphics1;
          Image image = bitmap;
          Rectangle destRect = rectangle;
          Size size = this.bxOut.Size;
          int width = size.Width;
          size = this.bxOut.Size;
          int height = size.Height;
          ImageAttributes ia = this.myIA;
          graphics2.DrawImage(image, destRect, 0, 0, width, height, GraphicsUnit.Pixel, ia);
        }
        else
        {
          Graphics graphics1 = this.bxOut.Graphics;
          Image bitmap = (Image) this.bxImage.Bitmap;
          location = new Point(0, 0);
          rectangle = new Rectangle(location, this.bxOut.Size);
          Graphics graphics2 = graphics1;
          Image image = bitmap;
          Rectangle destRect = rectangle;
          Size size = this.bxOut.Size;
          int width = size.Width;
          size = this.bxOut.Size;
          int height = size.Height;
          graphics2.DrawImage(image, destRect, 0, 0, width, height, GraphicsUnit.Pixel);
        }
      }
      else if (this.pAltState | this.pToggle & this.pTogState)
      {
        this.bxOut.Graphics.Clear(Color.LightCoral);
        this.bxOut.Graphics.DrawRectangle(Pens.Red, new Rectangle(0, 0, checked (this.Bounds.Width - 1), checked (this.Bounds.Height - 1)));
      }
      else
      {
        this.bxOut.Graphics.Clear(Color.LavenderBlush);
        Graphics graphics = this.bxOut.Graphics;
        Pen red = Pens.Red;
        rectangle = new Rectangle(0, 0, checked (this.Bounds.Width - 1), checked (this.Bounds.Height - 1));
        graphics.DrawRectangle(red, rectangle);
      }
      float height1 = this.Font.GetHeight(this.bxOut.Graphics) + 2f;
      RectangleF rectangleF = new RectangleF(0.0f, (float) (((double) this.Height - (double) height1) / 2.0), (float) this.Width, height1);
      string iStr = !(!this.pAltState | !this.pToggle) ? this.pTextOn : this.pTextOff;
      RectangleF Bounds = rectangleF;
      Color whiteSmoke = Color.WhiteSmoke;
      Color Outline = Color.FromArgb(192, 0, 0, 0);
      Font font = this.Font;
      float OutlineSpace = 1f;
      Graphics graphics3 = this.bxOut.Graphics;
      this.DrawOutlineText(iStr, Bounds, whiteSmoke, Outline, font, OutlineSpace, ref graphics3, false, false);
    }

    public void DrawOutlineText(
      string iStr,
      RectangleF Bounds,
      Color Text,
      Color Outline,
      Font bFont,
      float OutlineSpace,
      ref Graphics Target,
      bool SmallMode = false,
      bool LeftAlign = false)
    {
      StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
      format.LineAlignment = StringAlignment.Near;
      format.Alignment = !LeftAlign ? StringAlignment.Center : StringAlignment.Near;
      SolidBrush solidBrush1 = new SolidBrush(Outline);
      RectangleF layoutRectangle1 = Bounds;
      RectangleF layoutRectangle2 = new RectangleF(layoutRectangle1.X, layoutRectangle1.Y, layoutRectangle1.Width, bFont.GetHeight(Target));
      layoutRectangle2.X -= OutlineSpace;
      if (!SmallMode)
        Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.Y -= OutlineSpace;
      Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.X += OutlineSpace;
      if (!SmallMode)
        Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.X += OutlineSpace;
      Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.Y += OutlineSpace;
      if (!SmallMode)
        Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.Y += OutlineSpace;
      Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.X -= OutlineSpace;
      if (!SmallMode)
        Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.X -= OutlineSpace;
      Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      layoutRectangle2.Y -= OutlineSpace;
      if (!SmallMode)
        Target.DrawString(iStr, bFont, (Brush) solidBrush1, layoutRectangle2, format);
      SolidBrush solidBrush2 = new SolidBrush(Text);
      Target.DrawString(iStr, bFont, (Brush) solidBrush2, layoutRectangle1, format);
    }

    private void ImageButton_MouseDown(object sender, MouseEventArgs e)
    {
      if (!this.pToggle)
      {
        this.pAltState = true;
        this.Redraw();
      }
      else
      {
        this.pTogState = true;
        this.Redraw();
      }
    }

    private void ImageButton_MouseLeave(object sender, EventArgs e)
    {
      if (!this.pToggle)
      {
        this.pAltState = false;
        this.Redraw();
      }
      else
      {
        this.pTogState = false;
        this.Redraw();
      }
    }

    private void ImageButton_MouseUp(object sender, MouseEventArgs e)
    {
      if (!this.pToggle)
      {
        this.pAltState = false;
        this.Redraw();
        if (!(e.X >= 0 & e.Y >= 0 & e.X <= this.Width & e.Y <= this.Height))
          return;
        ImageButton.ButtonClickedEventHandler buttonClickedEvent = this.ButtonClickedEvent;
        if (buttonClickedEvent != null)
          buttonClickedEvent();
      }
      else
      {
        if (!(e.X >= 0 & e.Y >= 0 & e.X <= this.Width & e.Y <= this.Height))
          return;
        this.pAltState = !this.pAltState;
        this.pTogState = false;
        this.Redraw();
        ImageButton.ButtonClickedEventHandler buttonClickedEvent = this.ButtonClickedEvent;
        if (buttonClickedEvent != null)
          buttonClickedEvent();
      }
    }

        private void ButtonClickedEvent()
        {
            throw new NotImplementedException();
        }

        private void ImageButton_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxOut == null)
        this.Draw();
      if (this.bxOut == null)
        return;
      e.Graphics.DrawImage((Image) this.bxOut.Bitmap, 0, 0);
    }

    private void ImageButton_SizeChanged(object sender, EventArgs e)
    {
      Size size = this.Size;
      int num1 = size.Width != 105 ? 1 : 0;
      size = this.Size;
      int num2 = size.Height != 22 ? 1 : 0;
      if ((num1 | num2) != 0)
        this.Size = new Size(105, 22);
      this.bxOut = new ExtendedBitmap(this.Width, this.Height);
      this.Redraw();
    }

    public delegate void ButtonClickedEventHandler();
  }
}
