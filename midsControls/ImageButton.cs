using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    // Token: 0x0200001C RID: 28
    [DefaultEvent("ButtonClicked")]
    [DesignerGenerated]
    public class ImageButton : UserControl
    {
        // Token: 0x14000008 RID: 8
        // (add) Token: 0x060001A7 RID: 423 RVA: 0x00010566 File Offset: 0x0000E766
        // (remove) Token: 0x060001A8 RID: 424 RVA: 0x00010580 File Offset: 0x0000E780
        public event ImageButton.ButtonClickedEventHandler ButtonClicked;

        // Token: 0x17000059 RID: 89
        // (get) Token: 0x060001A9 RID: 425 RVA: 0x0001059C File Offset: 0x0000E79C
        // (set) Token: 0x060001AA RID: 426 RVA: 0x000105B4 File Offset: 0x0000E7B4
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

        // Token: 0x1700005A RID: 90
        // (get) Token: 0x060001AB RID: 427 RVA: 0x000105C8 File Offset: 0x0000E7C8
        // (set) Token: 0x060001AC RID: 428 RVA: 0x000105E0 File Offset: 0x0000E7E0
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

        // Token: 0x1700005B RID: 91
        // (get) Token: 0x060001AD RID: 429 RVA: 0x000105F4 File Offset: 0x0000E7F4
        // (set) Token: 0x060001AE RID: 430 RVA: 0x0001060C File Offset: 0x0000E80C
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

        // Token: 0x1700005C RID: 92
        // (get) Token: 0x060001AF RID: 431 RVA: 0x00010620 File Offset: 0x0000E820
        // (set) Token: 0x060001B0 RID: 432 RVA: 0x00010638 File Offset: 0x0000E838
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

        // Token: 0x1700005D RID: 93
        // (set) Token: 0x060001B1 RID: 433 RVA: 0x00010649 File Offset: 0x0000E849
        public ImageAttributes IA
        {
            set
            {
                this.myIA = value;
            }
        }

        // Token: 0x1700005E RID: 94
        // (set) Token: 0x060001B2 RID: 434 RVA: 0x00010654 File Offset: 0x0000E854
        public Bitmap ImageOff
        {
            set
            {
                this.bxImage = new ExtendedBitmap(base.Width, base.Height);
                this.bxImage.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                this.bxImage.Graphics.DrawImage(value, 0, 0, this.bxImage.Size.Width, this.bxImage.Size.Height);
                this.Redraw();
            }
        }

        // Token: 0x1700005F RID: 95
        // (set) Token: 0x060001B3 RID: 435 RVA: 0x000106CC File Offset: 0x0000E8CC
        public Bitmap ImageOn
        {
            set
            {
                this.bxAltImage = new ExtendedBitmap(base.Width, base.Height);
                this.bxImage.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                this.bxAltImage.Graphics.DrawImage(value, 0, 0, this.bxAltImage.Size.Width, this.bxAltImage.Size.Height);
                this.Redraw();
            }
        }

        // Token: 0x17000060 RID: 96
        // (set) Token: 0x060001B4 RID: 436 RVA: 0x00010744 File Offset: 0x0000E944
        public PictureBox KnockoutPB
        {
            set
            {
                this.Knockout = value;
                this.Redraw();
            }
        }

        // Token: 0x17000061 RID: 97
        // (get) Token: 0x060001B5 RID: 437 RVA: 0x00010758 File Offset: 0x0000E958
        // (set) Token: 0x060001B6 RID: 438 RVA: 0x00010770 File Offset: 0x0000E970
        public Point KnockoutLocationPoint
        {
            get
            {
                return this.KnockoutLocation;
            }
            set
            {
                this.KnockoutLocation = value;
                if (this.Knockout != null)
                {
                    this.Redraw();
                }
            }
        }

        // Token: 0x060001B7 RID: 439 RVA: 0x0001079C File Offset: 0x0000E99C
        public ImageButton()
        {
            base.MouseDown += this.ImageButton_MouseDown;
            base.MouseLeave += this.ImageButton_MouseLeave;
            base.MouseUp += this.ImageButton_MouseUp;
            base.Paint += this.ImageButton_Paint;
            base.SizeChanged += this.ImageButton_SizeChanged;
            base.BackColorChanged += this.ImageButton_BackColorChanged;
            base.FontChanged += this.ImageButton_FontChanged;
            this.bxImage = null;
            this.bxAltImage = null;
            this.bxOut = null;
            this.pTextOff = "Button Text";
            this.pTextOn = "Alt Text";
            this.pToggle = false;
            this.pAltState = false;
            this.pTogState = false;
            this.myIA = null;
            this.Knockout = null;
            this.KnockoutLocation = new Point(0, 0);
            this.InitializeComponent();
        }

        // Token: 0x060001B8 RID: 440 RVA: 0x0001089C File Offset: 0x0000EA9C
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

        // Token: 0x060001B9 RID: 441 RVA: 0x000108EC File Offset: 0x0000EAEC
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            base.SuspendLayout();
            SizeF autoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleDimensions = autoScaleDimensions;
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Name = "ImageButton";
            base.ResumeLayout(false);
        }

        // Token: 0x060001BA RID: 442 RVA: 0x00010938 File Offset: 0x0000EB38
        private void Redraw()
        {
            this.Draw();
            if (this.bxOut.Bitmap != null)
            {
                base.CreateGraphics().DrawImage(this.bxOut.Bitmap, 0, 0);
            }
        }

        // Token: 0x060001BB RID: 443 RVA: 0x0001097A File Offset: 0x0000EB7A
        public void SetImages(ImageAttributes IA, Bitmap ImageOff, Bitmap ImageOn)
        {
            this.IA = IA;
            this.ImageOff = ImageOff;
            this.ImageOn = ImageOn;
            this.Redraw();
        }

        // Token: 0x060001BC RID: 444 RVA: 0x0001099C File Offset: 0x0000EB9C
        private void ImageButton_BackColorChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        // Token: 0x060001BD RID: 445 RVA: 0x000109A6 File Offset: 0x0000EBA6
        private void ImageButton_FontChanged(object sender, EventArgs e)
        {
            this.Redraw();
        }

        // Token: 0x060001BE RID: 446 RVA: 0x000109B0 File Offset: 0x0000EBB0
        private void Draw()
        {
            StringFormat stringFormat = new StringFormat();
            if (this.bxOut == null)
            {
                if (base.Width == 0 | base.Height == 0)
                {
                    this.bxOut = null;
                    return;
                }
                this.bxOut = new ExtendedBitmap(base.Width, base.Height);
            }
            this.bxOut.Graphics.TextContrast = 0;
            this.bxOut.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            this.bxOut.Graphics.Clear(this.BackColor);
            if (this.Knockout != null && (this.KnockoutLocation.X > -1 & this.KnockoutLocation.Y > -1))
            {
                Rectangle srcRect = new Rectangle(this.KnockoutLocation, base.Size);
                Graphics graphics = this.bxOut.Graphics;
                Image image = this.Knockout.Image;
                Point location = new Point(0, 0);
                Rectangle bounds = new Rectangle(location, this.bxOut.Size);
                graphics.DrawImage(image, bounds, srcRect, GraphicsUnit.Pixel);
            }
            checked
            {
                if (!(this.bxImage == null | this.bxAltImage == null))
                {
                    if (this.pAltState | (this.pToggle & this.pTogState))
                    {
                        this.bxOut.Graphics.DrawImageUnscaled(this.bxAltImage.Bitmap, 0, 0);
                    }
                    else if (this.myIA != null)
                    {
                        Graphics graphics2 = this.bxOut.Graphics;
                        Image bitmap = this.bxImage.Bitmap;
                        Point location = new Point(0, 0);
                        Rectangle bounds = new Rectangle(location, this.bxOut.Size);
                        graphics2.DrawImage(bitmap, bounds, 0, 0, this.bxOut.Size.Width, this.bxOut.Size.Height, GraphicsUnit.Pixel, this.myIA);
                    }
                    else
                    {
                        Graphics graphics3 = this.bxOut.Graphics;
                        Image bitmap2 = this.bxImage.Bitmap;
                        Point location = new Point(0, 0);
                        Rectangle bounds = new Rectangle(location, this.bxOut.Size);
                        graphics3.DrawImage(bitmap2, bounds, 0, 0, this.bxOut.Size.Width, this.bxOut.Size.Height, GraphicsUnit.Pixel);
                    }
                }
                else if (this.pAltState | (this.pToggle & this.pTogState))
                {
                    this.bxOut.Graphics.Clear(Color.LightCoral);
                    Graphics graphics4 = this.bxOut.Graphics;
                    Pen red = Pens.Red;
                    int x = 0;
                    int y = 0;
                    Rectangle bounds = base.Bounds;
                    Rectangle bounds2 = new Rectangle(x, y, bounds.Width - 1, base.Bounds.Height - 1);
                    graphics4.DrawRectangle(red, bounds2);
                }
                else
                {
                    this.bxOut.Graphics.Clear(Color.LavenderBlush);
                    Graphics graphics5 = this.bxOut.Graphics;
                    Pen red2 = Pens.Red;
                    int x2 = 0;
                    int y2 = 0;
                    Rectangle bounds2 = base.Bounds;
                    Rectangle bounds = new Rectangle(x2, y2, bounds2.Width - 1, base.Bounds.Height - 1);
                    graphics5.DrawRectangle(red2, bounds);
                }
            }
            float num = this.Font.GetHeight(this.bxOut.Graphics) + 2f;
            RectangleF rectangleF = new RectangleF(0f, ((float)base.Height - num) / 2f, (float)base.Width, num);
            string text;
            if (!this.pAltState | !this.pToggle)
            {
                text = this.pTextOff;
            }
            else
            {
                text = this.pTextOn;
            }
            string iStr = text;
            RectangleF bounds3 = rectangleF;
            Color whiteSmoke = Color.WhiteSmoke;
            Color outline = Color.FromArgb(192, 0, 0, 0);
            Font font = this.Font;
            float outlineSpace = 1f;
            Graphics graphics6 = this.bxOut.Graphics;
            this.DrawOutlineText(iStr, bounds3, whiteSmoke, outline, font, outlineSpace, ref graphics6, false, false);
        }

        // Token: 0x060001BF RID: 447 RVA: 0x00010E10 File Offset: 0x0000F010
        public void DrawOutlineText(string iStr, RectangleF Bounds, Color Text, Color Outline, Font bFont, float OutlineSpace, ref Graphics Target, bool SmallMode = false, bool LeftAlign = false)
        {
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
            stringFormat.LineAlignment = StringAlignment.Near;
            if (LeftAlign)
            {
                stringFormat.Alignment = StringAlignment.Near;
            }
            else
            {
                stringFormat.Alignment = StringAlignment.Center;
            }
            SolidBrush brush = new SolidBrush(Outline);
            RectangleF layoutRectangle = Bounds;
            RectangleF layoutRectangle2 = new RectangleF(layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width, bFont.GetHeight(Target));
            layoutRectangle2.X -= OutlineSpace;
            if (!SmallMode)
            {
                Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            }
            layoutRectangle2.Y -= OutlineSpace;
            Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.X += OutlineSpace;
            if (!SmallMode)
            {
                Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            }
            layoutRectangle2.X += OutlineSpace;
            Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.Y += OutlineSpace;
            if (!SmallMode)
            {
                Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            }
            layoutRectangle2.Y += OutlineSpace;
            Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.X -= OutlineSpace;
            if (!SmallMode)
            {
                Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            }
            layoutRectangle2.X -= OutlineSpace;
            Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.Y -= OutlineSpace;
            if (!SmallMode)
            {
                Target.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            }
            brush = new SolidBrush(Text);
            Target.DrawString(iStr, bFont, brush, layoutRectangle, stringFormat);
        }

        // Token: 0x060001C0 RID: 448 RVA: 0x00010FEC File Offset: 0x0000F1EC
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

        // Token: 0x060001C1 RID: 449 RVA: 0x00011028 File Offset: 0x0000F228
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

        // Token: 0x060001C2 RID: 450 RVA: 0x00011064 File Offset: 0x0000F264
        private void ImageButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.pToggle)
            {
                this.pAltState = false;
                this.Redraw();
                if (e.X >= 0 & e.Y >= 0 & e.X <= base.Width & e.Y <= base.Height)
                {
                    this.ButtonClicked?.Invoke();
                }
            }
            else if (e.X >= 0 & e.Y >= 0 & e.X <= base.Width & e.Y <= base.Height)
            {
                this.pAltState = !this.pAltState;
                this.pTogState = false;
                this.Redraw();
                this.ButtonClicked?.Invoke();
            }
        }

        // Token: 0x060001C3 RID: 451 RVA: 0x00011168 File Offset: 0x0000F368
        private void ImageButton_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxOut == null)
            {
                this.Draw();
            }
            if (this.bxOut != null)
            {
                e.Graphics.DrawImage(this.bxOut.Bitmap, 0, 0);
            }
        }

        // Token: 0x060001C4 RID: 452 RVA: 0x000111BC File Offset: 0x0000F3BC
        private void ImageButton_SizeChanged(object sender, EventArgs e)
        {
            if (base.Size.Width != 105 | base.Size.Height != 22)
            {
                Size size = new Size(105, 22);
                base.Size = size;
            }
            this.bxOut = new ExtendedBitmap(base.Width, base.Height);
            this.Redraw();
        }

        // Token: 0x040000CA RID: 202
        private IContainer components;

        // Token: 0x040000CB RID: 203
        private ExtendedBitmap bxImage;

        // Token: 0x040000CC RID: 204
        private ExtendedBitmap bxAltImage;

        // Token: 0x040000CD RID: 205
        private ExtendedBitmap bxOut;

        // Token: 0x040000CE RID: 206
        private string pTextOff;

        // Token: 0x040000CF RID: 207
        private string pTextOn;

        // Token: 0x040000D0 RID: 208
        private bool pToggle;

        // Token: 0x040000D1 RID: 209
        private bool pAltState;

        // Token: 0x040000D2 RID: 210
        private bool pTogState;

        // Token: 0x040000D3 RID: 211
        private ImageAttributes myIA;

        // Token: 0x040000D4 RID: 212
        private PictureBox Knockout;

        // Token: 0x040000D5 RID: 213
        private Point KnockoutLocation;

        // Token: 0x0200001D RID: 29
        // (Invoke) Token: 0x060001C6 RID: 454
        public delegate void ButtonClickedEventHandler();
    }
}
