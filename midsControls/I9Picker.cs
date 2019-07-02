using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using HeroDesigner.Schema;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    // Token: 0x02000015 RID: 21
    public class I9Picker : UserControl
    {
        // Token: 0x14000004 RID: 4
        // (add) Token: 0x06000141 RID: 321 RVA: 0x0000B5C9 File Offset: 0x000097C9
        // (remove) Token: 0x06000142 RID: 322 RVA: 0x0000B5E3 File Offset: 0x000097E3
        public event I9Picker.EnhancementPickedEventHandler EnhancementPicked;

        // Token: 0x14000005 RID: 5
        // (add) Token: 0x06000143 RID: 323 RVA: 0x0000B5FD File Offset: 0x000097FD
        // (remove) Token: 0x06000144 RID: 324 RVA: 0x0000B617 File Offset: 0x00009817
        public event I9Picker.HoverEnhancementEventHandler HoverEnhancement;

        // Token: 0x14000006 RID: 6
        // (add) Token: 0x06000145 RID: 325 RVA: 0x0000B631 File Offset: 0x00009831
        // (remove) Token: 0x06000146 RID: 326 RVA: 0x0000B64B File Offset: 0x0000984B
        public event I9Picker.HoverSetEventHandler HoverSet;

        // Token: 0x14000007 RID: 7
        // (add) Token: 0x06000147 RID: 327 RVA: 0x0000B665 File Offset: 0x00009865
        // (remove) Token: 0x06000148 RID: 328 RVA: 0x0000B67F File Offset: 0x0000987F
        public event I9Picker.MovedEventHandler Moved;

        // Token: 0x17000053 RID: 83
        // (get) Token: 0x06000149 RID: 329 RVA: 0x0000B69C File Offset: 0x0000989C
        // (set) Token: 0x0600014A RID: 330 RVA: 0x0000B6B4 File Offset: 0x000098B4
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

        // Token: 0x17000054 RID: 84
        // (get) Token: 0x0600014B RID: 331 RVA: 0x0000B6C0 File Offset: 0x000098C0
        public I9Slot Slot
        {
            get
            {
                return this._mySlot;
            }
        }

        // Token: 0x17000055 RID: 85
        // (get) Token: 0x0600014C RID: 332 RVA: 0x0000B6D8 File Offset: 0x000098D8
        // (set) Token: 0x0600014D RID: 333 RVA: 0x0000B6F0 File Offset: 0x000098F0
        public Color Highlight
        {
            get
            {
                return this._cHighlight;
            }
            set
            {
                this._cHighlight = value;
                this.FullDraw();
            }
        }

        // Token: 0x17000056 RID: 86
        // (get) Token: 0x0600014E RID: 334 RVA: 0x0000B704 File Offset: 0x00009904
        // (set) Token: 0x0600014F RID: 335 RVA: 0x0000B71C File Offset: 0x0000991C
        public Color Selected
        {
            get
            {
                return this._cSelected;
            }
            set
            {
                this._cSelected = value;
                this.FullDraw();
            }
        }

        // Token: 0x17000057 RID: 87
        // (get) Token: 0x06000150 RID: 336 RVA: 0x0000B730 File Offset: 0x00009930
        // (set) Token: 0x06000151 RID: 337 RVA: 0x0000B748 File Offset: 0x00009948
        public new int Padding
        {
            get
            {
                return this._nPad;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > 100)
                {
                    value = 100;
                }
                this._nPad = value;
                this.FullDraw();
            }
        }

        // Token: 0x17000058 RID: 88
        // (get) Token: 0x06000152 RID: 338 RVA: 0x0000B788 File Offset: 0x00009988
        // (set) Token: 0x06000153 RID: 339 RVA: 0x0000B7A0 File Offset: 0x000099A0
        public int ImageSize
        {
            get
            {
                return this._nSize;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value > 256)
                {
                    value = 256;
                }
                this._nSize = value;
                this.FullDraw();
            }
        }

        // Token: 0x06000154 RID: 340 RVA: 0x0000B7E4 File Offset: 0x000099E4
        public I9Picker()
        {
            base.Load += this.I9PickerLoad;
            base.Paint += this.I9PickerPaint;
            base.KeyDown += this.I9PickerKeyDown;
            base.MouseDown += this.I9PickerMouseDown;
            base.MouseMove += this.I9PickerMouseMove;
            this._rows = 5;
            this._hoverCell = new Point(-1, -1);
            this._hoverTitle = "";
            this._hoverText = "";
            this._mySlotted = new int[0];
            this._levelCapped = false;
            this._userLevel = -1;
            this._lastTab = eType.Normal;
            this._lastSet = 0;
            this.LastLevel = -1;
            this._lastGrade = eEnhGrade.SingleO;
            this._lastRelativeLevel = eEnhRelative.Even;
            this._lastSpecial = eSubtype.Hamidon;
            this.UI = new I9Picker.cTracking();
            this._nPad = 8;
            this._nSize = 30;
            this._cHighlight = Color.SlateBlue;
            this._cSelected = Color.BlueViolet;
            this._nPowerIDX = -1;
            this.InitializeComponent();
        }

        // Token: 0x06000155 RID: 341 RVA: 0x0000B908 File Offset: 0x00009B08
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x06000156 RID: 342 RVA: 0x0000B940 File Offset: 0x00009B40
        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            this.tTip = new ToolTip(this.components);
            this.BackColor = Color.Silver;
            base.Name = "I9Picker";
            Size size = new Size(184, 244);
            base.Size = size;
        }

        // Token: 0x06000157 RID: 343 RVA: 0x0000B99D File Offset: 0x00009B9D
        private void I9PickerLoad(object sender, EventArgs e)
        {
            this.FullDraw();
        }

        // Token: 0x06000158 RID: 344 RVA: 0x0000B9A8 File Offset: 0x00009BA8
        private void SetBxSize()
        {
            if (this._myBx == null)
            {
                this._myBx = new ExtendedBitmap(base.Width, base.Height);
            }
            else if (this._myBx.Size.Width != base.Width | this._myBx.Size.Height != base.Height)
            {
                this._myBx = new ExtendedBitmap(base.Width, base.Height);
            }
            this._myBx.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        }

        // Token: 0x06000159 RID: 345 RVA: 0x0000BA50 File Offset: 0x00009C50
        private void FullDraw()
        {
            this.SetBxSize();
            this.DrawLayerLowest();
            if (this._hDraw != null)
            {
                this.DrawLayerImages();
                Graphics graphics = base.CreateGraphics();
                Rectangle clipRect = new Rectangle(0, 0, base.Width, base.Height);
                this.I9PickerPaint(this, new PaintEventArgs(graphics, clipRect));
            }
        }

        // Token: 0x0600015A RID: 346 RVA: 0x0000BAB4 File Offset: 0x00009CB4
        private void DrawLayerLowest()
        {
            this._myBx.Graphics.Clear(this.BackColor);
            this.DrawBorder();
            this.DrawHeaderBox();
            this.DrawLevelBox();
            this.DrawHighlights();
            this.DrawTypeLine();
            this.DrawEnhBox();
            this.DrawTextBox();
        }

        // Token: 0x0600015B RID: 347 RVA: 0x0000BB0A File Offset: 0x00009D0A
        private void DrawLayerImages()
        {
            this.DrawTypeImages();
            this.DrawEnhImages();
        }

        // Token: 0x0600015C RID: 348 RVA: 0x0000BB1C File Offset: 0x00009D1C
        private void DrawHeaderBox()
        {
            Font font = new Font(this.Font, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.White);
            string text = "";
            Pen pen = new Pen(this.ForeColor);
            Rectangle iRect = default(Rectangle);
            iRect.X = this._nPad;
            iRect.Y = this._nPad;
            checked
            {
                iRect.Width = this._nSize * 5 + this._nPad * 4;
                iRect.Height = (int)Math.Round((double)font.GetHeight(this._myBx.Graphics));
                this._headerHeight = iRect.Height + this._nPad;
                RectangleF layoutRectangle = new RectangleF((float)iRect.X, (float)iRect.Y, (float)iRect.Width, (float)iRect.Height);
                this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(iRect, 2));
                if (this._nPowerIDX > -1)
                {
                    text = "Enhancing: " + DatabaseAPI.Database.Power[this._nPowerIDX].DisplayName;
                }
                if (Operators.CompareString(text, "", false) != 0)
                {
                    this._myBx.Graphics.DrawString(text, font, brush, layoutRectangle);
                }
            }
        }

        // Token: 0x0600015D RID: 349 RVA: 0x0000BC6C File Offset: 0x00009E6C
        private void DrawLevelBox()
        {
            Pen pen = new Pen(this.ForeColor);
            Font font = new Font(this.Font, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.White);
            Rectangle rectBounds;
            StringFormat stringFormat;
            RectangleF layoutRectangle;
            checked
            {
                rectBounds = this.GetRectBounds(4, this._rows + 1);
                rectBounds.Y += 2;
                rectBounds.Height = base.Height - (rectBounds.Y + this._nPad);
                this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(rectBounds, 2));
                stringFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.Trimming = StringTrimming.None;
                layoutRectangle = new RectangleF((float)rectBounds.X, (float)rectBounds.Y, (float)rectBounds.Width, (float)rectBounds.Height);
                this._myBx.Graphics.DrawString("LVL", font, brush, layoutRectangle, stringFormat);
            }
            layoutRectangle.Y += font.GetHeight(this._myBx.Graphics) + 3f;
            rectBounds.Height = checked(base.Height - (rectBounds.Y + this._nPad));
            brush = new SolidBrush(this.ForeColor);
            font = new Font("Arial", 19f, FontStyle.Bold, GraphicsUnit.Pixel);
            string s;
            if (this.UI.View.TabID == eType.InventO | this.UI.View.TabID == eType.SetO)
            {
                s = Conversions.ToString(this.UI.View.IOLevel);
            }
            else
            {
                s = I9Picker.GetRelativeString(this.UI.View.RelLevel);
            }
            this._myBx.Graphics.DrawString(s, font, brush, layoutRectangle, stringFormat);
        }

        // Token: 0x0600015E RID: 350 RVA: 0x0000BE38 File Offset: 0x0000A038
        private static string GetRelativeString(eEnhRelative iRel)
        {
            string result;
            switch (iRel)
            {
                case 0:
                    result = "X";
                    break;
                case eEnhRelative.MinusThree:
                    result = "-3";
                    break;
                case eEnhRelative.MinusTwo:
                    result = "-2";
                    break;
                case eEnhRelative.MinusOne:
                    result = "-1";
                    break;
                case eEnhRelative.Even:
                    result = "+/-";
                    break;
                case eEnhRelative.PlusOne:
                    result = "+1";
                    break;
                case eEnhRelative.PlusTwo:
                    result = "+2";
                    break;
                case eEnhRelative.PlusThree:
                    result = "+3";
                    break;
                case eEnhRelative.PlusFour:
                    result = "+4";
                    break;
                case eEnhRelative.PlusFive:
                    result = "+5";
                    break;
                default:
                    result = "!";
                    break;
            }
            return result;
        }

        // Token: 0x0600015F RID: 351 RVA: 0x0000BED4 File Offset: 0x0000A0D4
        private void DrawTextBox()
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(this.ForeColor);
            Rectangle iRect = default(Rectangle);
            iRect.X = this._nPad;
            RectangleF layoutRectangle = default(RectangleF);
            RectangleF layoutRectangle2 = default(RectangleF);
            checked
            {
                iRect.Y = this._headerHeight + (this._nPad * 2 + this._nSize + (this._nSize * this._rows + this._nPad * (this._rows - 1))) + 2 + this._nPad;
                iRect.Height = base.Height - (iRect.Y + this._nPad);
                iRect.Width = this._nSize * 4 + this._nPad * 3;
                layoutRectangle.X = (float)iRect.X;
                layoutRectangle.Y = (float)iRect.Y;
                layoutRectangle.Width = (float)iRect.Width;
                layoutRectangle.Height = this.Font.GetHeight(this._myBx.Graphics);
                layoutRectangle2.X = (float)iRect.X;
            }
            layoutRectangle2.Y = (float)iRect.Y + layoutRectangle.Height;
            layoutRectangle2.Width = (float)iRect.Width;
            layoutRectangle2.Height = (float)iRect.Height - layoutRectangle.Height;
            this._myBx.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            float num = 1f;
            int num2 = checked((int)Math.Round((double)this._myBx.Graphics.MeasureString(this._hoverTitle, this.Font, (int)Math.Round((double)(unchecked(layoutRectangle.Width * 10f)))).Width));
            if ((float)num2 > layoutRectangle.Width - 10f)
            {
                num = (layoutRectangle.Width - 10f) / (float)num2;
            }
            if ((double)num < 0.5)
            {
                num = 0.5f;
            }
            Font font = new Font(base.Name, this.Font.Size * num, FontStyle.Bold, this.Font.Unit, 0);
            this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(iRect, 2));
            if (Operators.CompareString(this._hoverTitle, "", false) != 0)
            {
                this._myBx.Graphics.DrawString(this._hoverTitle, font, brush, layoutRectangle);
            }
            if (Operators.CompareString(this._hoverText, "", false) != 0)
            {
                this._myBx.Graphics.DrawString(this._hoverText, this.Font, brush, layoutRectangle2);
            }
        }

        // Token: 0x06000160 RID: 352 RVA: 0x0000C199 File Offset: 0x0000A399
        private void SetInfoStrings(string title, string message)
        {
            this._hoverTitle = title;
            this._hoverText = message;
        }

        // Token: 0x06000161 RID: 353 RVA: 0x0000C1AC File Offset: 0x0000A3AC
        private void DrawTypeImages()
        {
            Rectangle srcRect = new Rectangle(0, 0, this._nSize, this._nSize);
            eType eType = 0;
            Rectangle rectBounds = this.GetRectBounds(0, 0);
            checked
            {
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect.X, srcRect.Y, 30, 30, GraphicsUnit.Pixel, this._hDraw.pImageAttributes);
                eType = eType.Normal;
                rectBounds = this.GetRectBounds(1, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
                eType = eType.InventO;
                rectBounds = this.GetRectBounds(2, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
                eType = eType.SpecialO;
                rectBounds = this.GetRectBounds(3, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
                eType = eType.SetO;
                rectBounds = this.GetRectBounds(4, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
            }
        }

        // Token: 0x06000162 RID: 354 RVA: 0x0000C30C File Offset: 0x0000A50C
        private void DrawEnhImages()
        {
            checked
            {
                switch (this.UI.View.TabID)
                {
                    case eType.Normal:
                        {
                            int num = 1;
                            for (int i = this.UI.NOGrades.Length - 1; i >= 1; i += -1)
                            {
                                Rectangle srcRect = new Rectangle(this.UI.NOGrades[i] * this._nSize, 0, this._nSize, this._nSize);
                                this._myBx.Graphics.DrawImage(I9Gfx.Borders.Bitmap, this.GetRectBounds(4, num), I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade((eType)1, (eEnhGrade)i)), GraphicsUnit.Pixel);
                                this._myBx.Graphics.DrawImage(I9Gfx.EnhGrades.Bitmap, this.GetRectBounds(4, num), srcRect, GraphicsUnit.Pixel);
                                num++;
                            }
                            int num2 = 0;
                            int num3 = this.UI.NO.Length - 1;
                            for (int i = num2; i <= num3; i++)
                            {
                                Origin.Grade grade;
                                switch (this.UI.View.GradeID)
                                {
                                    case eEnhGrade.TrainingO:
                                        grade = 0;
                                        break;
                                    case eEnhGrade.DualO:
                                        grade = Origin.Grade.DualO;
                                        break;
                                    case eEnhGrade.SingleO:
                                        grade = Origin.Grade.SingleO;
                                        break;
                                    default:
                                        grade = Origin.Grade.SingleO;
                                        break;
                                }
                                Graphics graphics = this._myBx.Graphics;
                                I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(i)), this.UI.NO[i], grade);
                            }
                            break;
                        }
                    case eType.InventO:
                        {
                            int num4 = 0;
                            int num5 = this.UI.IO.Length - 1;
                            for (int i = num4; i <= num5; i++)
                            {
                                Graphics graphics = this._myBx.Graphics;
                                I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(i)), this.UI.IO[i], (Origin.Grade)4);
                            }
                            break;
                        }
                    case eType.SpecialO:
                        {
                            int num6 = 1;
                            int num7 = this.UI.SpecialTypes.Length - 1;
                            for (int i = num6; i <= num7; i++)
                            {
                                Rectangle srcRect2 = new Rectangle(this.UI.SpecialTypes[i] * this._nSize, 0, this._nSize, this._nSize);
                                this._myBx.Graphics.DrawImage(I9Gfx.EnhSpecials.Bitmap, this.GetRectBounds(4, i), srcRect2, GraphicsUnit.Pixel);
                            }
                            int num8 = 0;
                            int num9 = this.UI.SpecialO.Length - 1;
                            for (int i = num8; i <= num9; i++)
                            {
                                Graphics graphics = this._myBx.Graphics;
                                I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(i)), this.UI.SpecialO[i], (Origin.Grade)3);
                            }
                            break;
                        }
                    case eType.SetO:
                        {
                            int num10 = 0;
                            int num11 = this.UI.SetTypes.Length - 1;
                            for (int i = num10; i <= num11; i++)
                            {
                                Rectangle srcRect3 = new Rectangle(this.UI.SetTypes[i] * this._nSize, 0, this._nSize, this._nSize);
                                this._myBx.Graphics.DrawImage(I9Gfx.SetTypes.Bitmap, this.GetRectBounds(4, i + 1), srcRect3, GraphicsUnit.Pixel);
                            }
                            if (this.UI.View.SetID > -1)
                            {
                                this.DisplaySetEnhancements();
                            }
                            else
                            {
                                this.DisplaySetImages();
                            }
                            break;
                        }
                }
            }
        }

        // Token: 0x06000163 RID: 355 RVA: 0x0000C690 File Offset: 0x0000A890
        private static ImageAttributes GreyItem(bool grey)
        {
            checked
            {
                ImageAttributes result;
                if (!grey)
                {
                    result = new ImageAttributes();
                }
                else
                {
                    float[][] array = new float[5][];
                    float[][] array2 = array;
                    int num = 0;
                    float[] array3 = new float[5];
                    array3[0] = 1f;
                    array2[num] = array3;
                    float[][] array4 = array;
                    int num2 = 1;
                    array3 = new float[5];
                    array3[1] = 1f;
                    array4[num2] = array3;
                    float[][] array5 = array;
                    int num3 = 2;
                    array3 = new float[5];
                    array3[2] = 1f;
                    array5[num3] = array3;
                    float[][] array6 = array;
                    int num4 = 3;
                    array3 = new float[5];
                    array3[3] = 1f;
                    array6[num4] = array3;
                    array[4] = new float[]
                    {
                        0f,
                        0f,
                        0f,
                        0f,
                        1f
                    };
                    ColorMatrix colorMatrix = new ColorMatrix(array);
                    int num5 = 0;
                    do
                    {
                        int num6 = 0;
                        do
                        {
                            if (num5 != 4)
                            {
                                ColorMatrix colorMatrix2;
                                int row;
                                int column;
                                (colorMatrix2 = colorMatrix)[row = num5, column = num6] = colorMatrix2[row, column] / 2f;
                            }
                            num6++;
                        }
                        while (num6 <= 2);
                        num5++;
                    }
                    while (num5 <= 2);
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(colorMatrix);
                    result = imageAttributes;
                }
                return result;
            }
        }

        // Token: 0x06000164 RID: 356 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
        private void DisplaySetEnhancements()
        {
            int num = 0;
            checked
            {
                int num2 = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    bool grey = false;
                    int num3 = 0;
                    int num4 = this._mySlotted.Length - 1;
                    for (int j = num3; j <= num4; j++)
                    {
                        if (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[i] == this._mySlotted[j])
                        {
                            grey = true;
                        }
                    }
                    Graphics graphics = this._myBx.Graphics;
                    I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(i)),
                        DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[i], (Origin.Grade)5, I9Picker.GreyItem(grey));
                }
            }
        }

        bool IsPlaced(int index)
        {
            checked
            {
                bool result;
                if (this.UI.View.TabID != eType.SetO)
                {
                    result = false;
                }
                else if (this.UI.View.SetID < 0)
                {
                    result = false;
                }
                else if (this.UI.View.SetTypeID >= this.UI.Sets.Length)
                {
                    result = false;
                }
                else if (this.UI.View.SetID >= this.UI.Sets[this.UI.View.SetTypeID].Length)
                {
                    result = false;
                }
                else if (this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID] >= DatabaseAPI.Database.EnhancementSets.Count)
                {
                    result = false;
                }
                else if (index >= DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements.Length)
                {
                    result = false;
                }
                else if (this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.Initial.SetID == this.UI.View.SetID & this.UI.Initial.PickerID == index)
                {
                    result = false;
                }
                else
                {
                    int num = 0;
                    int num2 = this._mySlotted.Length - 1;
                    for (int i = num; i <= num2; i++)
                    {
                        if (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index] == this._mySlotted[i])
                        {
                            return true;
                        }
                    }
                    result = false;
                }
                return result;
            }
        }

        // Token: 0x06000166 RID: 358 RVA: 0x0000CB60 File Offset: 0x0000AD60
        private void DisplaySetImages()
        {
            checked
            {
                if (this.UI.View.TabID == eType.SetO)
                {
                    if (this.UI.View.SetTypeID > -1)
                    {
                        int num = 0;
                        int num2 = this.UI.Sets[this.UI.View.SetTypeID].Length - 1;
                        for (int i = num; i <= num2; i++)
                        {
                            Rectangle srcRect = new Rectangle(I9Gfx.OriginIndex * this._nSize, 4 * this._nSize, this._nSize, this._nSize);
                            this._myBx.Graphics.DrawImage(I9Gfx.Borders.Bitmap, this.GetRectBounds(this.IndexToXY(i)), srcRect, GraphicsUnit.Pixel);
                            srcRect = new Rectangle(this.UI.Sets[this.UI.View.SetTypeID][i] * this._nSize, 0, this._nSize, this._nSize);
                            this._myBx.Graphics.DrawImage(I9Gfx.Sets.Bitmap, this.GetRectBounds(this.IndexToXY(i)), srcRect, GraphicsUnit.Pixel);
                        }
                    }
                }
            }
        }

        // Token: 0x06000167 RID: 359 RVA: 0x0000CCA8 File Offset: 0x0000AEA8
        private void DrawBorder()
        {
            Pen pen = new Pen(this.ForeColor);
            Rectangle rect = default(Rectangle);
            rect.X = 0;
            rect.Y = 0;
            checked
            {
                rect.Height = base.Height - 1;
                rect.Width = base.Width - 1;
                this._myBx.Graphics.DrawRectangle(pen, rect);
            }
        }

        // Token: 0x06000168 RID: 360 RVA: 0x0000CD14 File Offset: 0x0000AF14
        private void DrawHighlights()
        {
            this.DrawHighlight(this._hoverCell.X, this._hoverCell.Y);
            this.DrawSelected((int)this.UI.View.TabID, 0);
            if (this.UI.View.TabID == eType.SetO)
            {
                if (this.UI.View.SetTypeID > -1)
                {
                    this.DrawSelected(4, checked(this.UI.View.SetTypeID + 1));
                }
            }
            else if (this.UI.View.TabID == eType.Normal)
            {
                if ((int)this.UI.View.GradeID > -1)
                {
                    this.DrawSelected(4, I9Picker.Reverse((int)this.UI.View.GradeID));
                }
            }
            else if (this.UI.View.TabID == eType.SpecialO && (int)this.UI.View.SpecialID > -1)
            {
                this.DrawSelected(4, (int)this.UI.View.SpecialID);
            }
            if (this.UI.Initial.PickerID > -1)
            {
                if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.Initial.SetID == this.UI.View.SetID & this.UI.Initial.GradeID == this.UI.View.GradeID & this.UI.Initial.SpecialID == this.UI.View.SpecialID)
                {
                    this.DrawSelected(this.IndexToXY(this.UI.Initial.PickerID).X, this.IndexToXY(this.UI.Initial.PickerID).Y);
                    this.DrawBox(this.IndexToXY(this.UI.Initial.PickerID).X, this.IndexToXY(this.UI.Initial.PickerID).Y);
                }
                else if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.View.SetID < 0)
                {
                    this.DrawSelected(this.IndexToXY(this.UI.Initial.SetID).X, this.IndexToXY(this.UI.Initial.SetID).Y);
                    this.DrawBox(this.IndexToXY(this.UI.Initial.SetID).X, this.IndexToXY(this.UI.Initial.SetID).Y);
                }
            }
        }

        // Token: 0x06000169 RID: 361 RVA: 0x0000D0A0 File Offset: 0x0000B2A0
        private void DrawTypeLine()
        {
            Rectangle rectBounds = this.GetRectBounds((int)this.UI.View.TabID, 0);
            checked
            {
                int num = this._headerHeight + this._nPad + this._nSize;
                int y = num + this._nPad - 2;
                int num2 = (int)Math.Round(unchecked((double)rectBounds.X + (double)rectBounds.Width / 2.0));
                Pen pen = new Pen(this.ForeColor);
                this._myBx.Graphics.DrawLine(pen, num2, num, num2, y);
            }
        }

        // Token: 0x0600016A RID: 362 RVA: 0x0000D130 File Offset: 0x0000B330
        private void DrawSetLine()
        {
            checked
            {
                if (!((int)this.UI.View.TabID == 4 & this.UI.View.SetTypeID < 0))
                {
                    if (!((int)this.UI.View.TabID == 1 & this.UI.View.GradeID < 0))
                    {
                        if (!((int)this.UI.View.TabID == 3 & this.UI.View.SpecialID < 0))
                        {
                            Rectangle rectangle = default(Rectangle);
                            switch (this.UI.View.TabID)
                            {
                                case eType.Normal:
                                    rectangle = this.GetRectBounds(4, I9Picker.Reverse((int)this.UI.View.GradeID));
                                    break;
                                case eType.SpecialO:
                                    rectangle = this.GetRectBounds(4, (int)this.UI.View.SpecialID);
                                    break;
                                case eType.SetO:
                                    rectangle = this.GetRectBounds(4, this.UI.View.SetTypeID + 1);
                                    break;
                            }
                            int num = (int)Math.Round(unchecked((double)rectangle.Y + (double)rectangle.Height / 2.0));
                            int x = rectangle.X - 2;
                            int x2 = rectangle.X - this._nPad + 2;
                            Pen pen = new Pen(this.ForeColor);
                            this._myBx.Graphics.DrawLine(pen, x, num, x2, num);
                        }
                    }
                }
            }
        }

        // Token: 0x0600016B RID: 363 RVA: 0x0000D2CD File Offset: 0x0000B4CD
        private void DrawEnhBox()
        {
            this.DrawSetBox();
            this.DrawSetLine();
            this.DrawEnhBoxSet();
            this.DrawBox((int)this.UI.View.TabID, 0);
        }

        // Token: 0x0600016C RID: 364 RVA: 0x0000D300 File Offset: 0x0000B500
        private void DrawEnhBoxSet()
        {
            Pen pen = new Pen(this.ForeColor);
            Rectangle iRect = default(Rectangle);
            iRect.X = this._nPad;
            checked
            {
                iRect.Y = this._headerHeight + this._nPad * 2 + this._nSize;
                iRect.Width = this._nSize * 4 + this._nPad * 3;
                iRect.Height = this._nSize * this._rows + this._nPad * (this._rows - 1);
                this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(iRect, 2));
            }
        }

        // Token: 0x0600016D RID: 365 RVA: 0x0000D3A8 File Offset: 0x0000B5A8
        private void DrawSetBox()
        {
            Rectangle rectBounds = this.GetRectBounds(4, 1);
            Pen pen = new Pen(this.ForeColor);
            rectBounds.Height = checked(this._nSize * this._rows + this._nPad * (this._rows - 1));
            this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(rectBounds, 2));
        }

        // Token: 0x0600016E RID: 366 RVA: 0x0000D40C File Offset: 0x0000B60C
        private void DrawHighlight(int x, int y)
        {
            if (x > -1 & y > -1)
            {
                this._myBx.Graphics.FillRectangle(new SolidBrush(this._cHighlight), this.GetRectBounds(x, y));
            }
        }

        // Token: 0x0600016F RID: 367 RVA: 0x0000D450 File Offset: 0x0000B650
        private void DrawSelected(int x, int y)
        {
            if (x > -1 & y > -1)
            {
                this._myBx.Graphics.FillRectangle(new SolidBrush(this._cSelected), this.GetRectBounds(x, y));
            }
        }

        // Token: 0x06000170 RID: 368 RVA: 0x0000D494 File Offset: 0x0000B694
        private void DrawBox(int x, int y)
        {
            checked
            {
                if (x > -1 & y > -1)
                {
                    Pen pen = new Pen(this.ForeColor);
                    Rectangle rectBounds = this.GetRectBounds(x, y);
                    rectBounds.X--;
                    rectBounds.Y--;
                    rectBounds.Width++;
                    rectBounds.Height++;
                    this._myBx.Graphics.DrawRectangle(pen, rectBounds);
                }
            }
        }

        // Token: 0x06000171 RID: 369 RVA: 0x0000D520 File Offset: 0x0000B720
        private static Rectangle Dilate(Rectangle iRect, int extra = 2)
        {
            Rectangle result = checked(new Rectangle(iRect.X - extra, iRect.Y - extra, iRect.Width + extra + 1, iRect.Height + extra + 1));
            return result;
        }

        // Token: 0x06000172 RID: 370 RVA: 0x0000D564 File Offset: 0x0000B764
        private Point IndexToXY(int index)
        {
            int num = 4;
            int num2 = 0;
            checked
            {
                while (index >= num)
                {
                    index -= num;
                    num2++;
                }
                Point result = new Point(index, num2 + 1);
                return result;
            }
        }

        // Token: 0x06000173 RID: 371 RVA: 0x0000D5A4 File Offset: 0x0000B7A4
        private Rectangle GetRectBounds(int x, int y)
        {
            Rectangle result = checked(new Rectangle(this._nPad + x * (this._nSize + this._nPad), this._headerHeight + this._nPad + y * (this._nSize + this._nPad), this._nSize, this._nSize));
            return result;
        }

        // Token: 0x06000174 RID: 372 RVA: 0x0000D600 File Offset: 0x0000B800
        private Rectangle GetRectBounds(Point iPoint)
        {
            return this.GetRectBounds(iPoint.X, iPoint.Y);
        }

        // Token: 0x06000175 RID: 373 RVA: 0x0000D628 File Offset: 0x0000B828
        private void I9PickerPaint(object sender, PaintEventArgs e)
        {
            if (this._myBx.Bitmap != null)
            {
                e.Graphics.DrawImage(this._myBx.Bitmap, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        // Token: 0x06000176 RID: 374 RVA: 0x0000D688 File Offset: 0x0000B888
        private Point GetCellXY(Point iPt)
        {
            int num = 0;
            checked
            {
                int i;
                for (; ; )
                {
                    int num2 = 0;
                    int rows = this._rows;
                    for (i = num2; i <= rows; i++)
                    {
                        Rectangle rectBounds = this.GetRectBounds(num, i);
                        if ((iPt.X >= rectBounds.X & iPt.X <= rectBounds.X + rectBounds.Width) && (iPt.Y >= rectBounds.Y & iPt.Y <= rectBounds.Y + rectBounds.Height))
                        {
                            goto Block_2;
                        }
                    }
                    num++;
                    if (num > 4)
                    {
                        goto Block_4;
                    }
                }
            Block_2:
                Point result = new Point(num, i);
                return result;
            Block_4:
                result = new Point(-1, -1);
                return result;
            }
        }

        // Token: 0x06000177 RID: 375 RVA: 0x0000D780 File Offset: 0x0000B980
        private int GetCellIndex(Point cell)
        {
            int result;
            if (cell.X < 0 | cell.Y <= 0)
            {
                result = -1;
            }
            else
            {
                result = checked((cell.Y - 1) * 4 + cell.X);
            }
            return result;
        }

        // Token: 0x06000178 RID: 376 RVA: 0x0000D7CC File Offset: 0x0000B9CC
        private void I9PickerMouseDown(object sender, MouseEventArgs e)
        {
            Point iPt = new Point(e.X, e.Y);
            Point cellXY = this.GetCellXY(iPt);
            int cellIndex = this.GetCellIndex(cellXY);
            checked
            {
                this._mouseOffset = new Point(0 - e.X, 0 - e.Y);
                if (e.Button != MouseButtons.Right)
                {
                    if (cellXY.Y == 0)
                    {
                        this.UI.View.TabID = (eType)cellXY.X;
                        if (cellXY.X == 4 & this.UI.SetTypes.Length > 0)
                        {
                            this.UI.View.SetTypeID = 0;
                            if ((int)this.UI.View.RelLevel < 4)
                            {
                                this.UI.View.RelLevel = eEnhRelative.Even;
                            }
                        }
                        else if (cellXY.X == 2)
                        {
                            if ((int)this.UI.Initial.TabID == 1)
                            {
                                this.UI.Initial.TabID = eType.InventO;
                            }
                            if ((int)this.UI.View.RelLevel < 4)
                            {
                                this.UI.View.RelLevel = eEnhRelative.Even;
                            }
                        }
                        else if (cellXY.X == 1)
                        {
                            if ((int)this.UI.View.RelLevel > 7)
                            {
                                this.UI.View.RelLevel = eEnhRelative.PlusThree;
                            }
                            if ((int)this.UI.Initial.TabID == 2)
                            {
                                this.UI.Initial.TabID = eType.Normal;
                            }
                        }
                        else if (cellXY.X == 3 && (int)this.UI.View.RelLevel > 7)
                        {
                            this.UI.View.RelLevel = eEnhRelative.PlusThree;
                        }
                        if (cellXY.X == 0)
                        {
                            this.DOEnhancementPicked(-1);
                        }
                    }
                    else if (cellXY.Y > 0)
                    {
                        if (this.CellSetTypeSelect(cellXY))
                        {
                            switch (this.UI.View.TabID)
                            {
                                case eType.Normal:
                                    if (cellXY.Y < this.UI.NOGrades.Length)
                                    {
                                        cellXY.Y = I9Picker.Reverse(cellXY.Y);
                                        this.UI.View.GradeID = (eEnhGrade)cellXY.Y;
                                        if (this.UI.Initial.TabID == eType.Normal)
                                        {
                                            this.UI.Initial.GradeID = this.UI.View.GradeID;
                                        }
                                        this.DoHover(this._hoverCell, true);
                                    }
                                    break;
                                case eType.SpecialO:
                                    if (cellXY.Y < this.UI.SpecialTypes.Length)
                                    {
                                        this.SetSpecialEnhSet((eSubtype)cellXY.Y);
                                        this.DoHover(this._hoverCell, true);
                                    }
                                    break;
                                case eType.SetO:
                                    if (cellXY.Y - 1 < this.UI.SetTypes.Length)
                                    {
                                        this.UI.View.SetTypeID = cellXY.Y - 1;
                                        this.UI.View.SetID = -1;
                                        this.DoHover(this._hoverCell, true);
                                    }
                                    break;
                            }
                        }
                        else if (this.CellSetSelect(cellIndex))
                        {
                            if (e.Button == MouseButtons.Middle)
                            {
                            }
                            this.UI.View.SetID = cellIndex;
                            this.CheckAndFixIOLevel();
                            this.DoHover(this._hoverCell, true);
                        }
                        else if (this.CellEnhSelect(cellIndex))
                        {
                            this.DOEnhancementPicked(cellIndex);
                        }
                    }
                    this.FullDraw();
                }
            }
        }

        // Token: 0x06000179 RID: 377 RVA: 0x0000DC00 File Offset: 0x0000BE00
        private static int Reverse(int iValue)
        {
            if (iValue == 3)
            {
                iValue = 1;
            }
            else if (iValue == 1)
            {
                iValue = 3;
            }
            return iValue;
        }

        // Token: 0x0600017A RID: 378 RVA: 0x0000DC38 File Offset: 0x0000BE38
        private bool CellSetTypeSelect(Point cell)
        {
            return cell.X == 4;
        }

        // Token: 0x0600017B RID: 379 RVA: 0x0000DC54 File Offset: 0x0000BE54
        private bool CellSetSelect(int cellIDX)
        {
            return this.UI.View.SetTypeID >= 0 && (this.UI.View.TabID == eType.SetO & this.UI.View.SetID == -1 & cellIDX > -1 & cellIDX < this.UI.Sets[this.UI.View.SetTypeID].Length);
        }

        // Token: 0x0600017C RID: 380 RVA: 0x0000DCCC File Offset: 0x0000BECC
        private bool CellEnhSelect(int cellIDX)
        {
            bool result;
            if (cellIDX > -1 & (this.UI.View.TabID != eType.SetO | this.UI.View.SetID > -1))
            {
                int[] array = new int[0];
                switch (this.UI.View.TabID)
                {
                    case eType.Normal:
                        array = this.UI.NO;
                        break;
                    case eType.InventO:
                        array = this.UI.IO;
                        break;
                    case eType.SpecialO:
                        array = this.UI.SpecialO;
                        break;
                    case eType.SetO:
                        if (this.UI.View.SetTypeID < 0)
                        {
                            return false;
                        }
                        array = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements;
                        break;
                }
                result = (cellIDX > -1 & cellIDX < array.Length);
            }
            else
            {
                result = false;
            }
            return result;
        }

        // Token: 0x0600017D RID: 381 RVA: 0x0000DDE9 File Offset: 0x0000BFE9
        private void DOEnhancementSetPicked(int index)
        {
        }

        // Token: 0x0600017E RID: 382 RVA: 0x0000DDEC File Offset: 0x0000BFEC
        private void DOEnhancementPicked(int index)
        {
            I9Slot i9Slot = (I9Slot)this._mySlot.Clone();
            this.CheckAndFixIOLevel();
            checked
            {
                if (((this.UI.View.IOLevel != this.UI.Initial.IOLevel & this.UI.View.IOLevel != this._userLevel) | this._userLevel == -1) && !((int)this.UI.View.TabID == 2 & Enhancement.GranularLevelZb(this._userLevel - 1, 9, 49, 5) == this.UI.View.IOLevel))
                {
                    this._levelCapped = true;
                }
                switch (this.UI.View.TabID)
                {
                    case 0:
                        i9Slot = new I9Slot();
                        break;
                    case eType.Normal:
                        i9Slot.Enh = this.UI.NO[index];
                        i9Slot.Grade = this.UI.View.GradeID;
                        i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        break;
                    case eType.InventO:
                        i9Slot.Enh = this.UI.IO[index];
                        i9Slot.IOLevel = this.UI.View.IOLevel - 1;
                        i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        break;
                    case eType.SpecialO:
                        i9Slot.Enh = this.UI.SpecialO[index];
                        i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        this._lastSpecial = this.UI.View.SpecialID;
                        break;
                    case eType.SetO:
                        if (this.IsPlaced(index))
                        {
                            return;
                        }
                        i9Slot.Enh = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index];
                        i9Slot.IOLevel = this.UI.View.IOLevel - 1;
                        if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].GetPower() is IPower power)
                        {
                            if (power.BoostBoostable)
                            {
                                i9Slot.RelativeLevel = this.UI.View.RelLevel;
                            }
                        }
                        else
                        {
                            i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        }
                        break;
                }
                if (this.UI.View.TabID != 0)
                {
                    this._lastTab = this.UI.View.TabID;
                }
                if ((int)this.UI.View.TabID == 4)
                {
                    this._lastSet = this.UI.View.SetTypeID;
                }
                if ((int)this.UI.View.TabID == 1)
                {
                    this._lastGrade = this.UI.View.GradeID;
                    this._lastRelativeLevel = this.UI.View.RelLevel;
                }
                if ((int)this.UI.View.TabID == 3)
                {
                    this._lastSpecial = this.UI.View.SpecialID;
                    this._lastRelativeLevel = this.UI.View.RelLevel;
                }
                if (((int)this.UI.View.TabID == 4 | (int)this.UI.View.TabID == 2) & !this._levelCapped)
                {
                    if ((int)this.UI.View.TabID == 2 & Enhancement.GranularLevelZb(this._userLevel - 1, 9, 49, 5) == this.UI.View.IOLevel)
                    {
                        this.LastLevel = this._userLevel;
                    }
                    else
                    {
                        this.LastLevel = this.UI.View.IOLevel;
                    }
                }
                else if (this._userLevel > -1)
                {
                    this.LastLevel = this._userLevel;
                }
                this.EnhancementPicked?.Invoke(i9Slot);
            }
        }

        // Token: 0x0600017F RID: 383 RVA: 0x0000E268 File Offset: 0x0000C468
        private void RaiseHoverEnhancement(int e)
        {
            this.HoverEnhancement?.Invoke(e);
        }

        // Token: 0x06000180 RID: 384 RVA: 0x0000E290 File Offset: 0x0000C490
        private void RaiseHoverSet(int e)
        {
            this.HoverSet?.Invoke(e);
        }

        // Token: 0x06000181 RID: 385 RVA: 0x0000E2B7 File Offset: 0x0000C4B7
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.FullDraw();
        }

        // Token: 0x06000182 RID: 386 RVA: 0x0000E2C9 File Offset: 0x0000C4C9
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.FullDraw();
        }

        // Token: 0x06000183 RID: 387 RVA: 0x0000E2DB File Offset: 0x0000C4DB
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.FullDraw();
        }

        // Token: 0x06000184 RID: 388 RVA: 0x0000E2F0 File Offset: 0x0000C4F0
        private void I9PickerMouseMove(object sender, MouseEventArgs e)
        {
            Point location = new Point(e.X, e.Y);
            Point cellXY = this.GetCellXY(location);
            this.DoHover(cellXY, false);
            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                point.Offset(this._mouseOffset.X, this._mouseOffset.Y);
                location = base.Location;
                Point location2 = checked(new Point(location.X + point.X, base.Location.Y + point.Y));
                Rectangle bounds = base.Bounds;
                base.Location = location2;
                this.Moved?.Invoke(base.Bounds, bounds);
            }
        }

        // Token: 0x06000185 RID: 389 RVA: 0x0000E3DC File Offset: 0x0000C5DC
        private void DoHover(Point cell, bool alwaysUpdate = false)
        {
            int cellIndex = this.GetCellIndex(cell);
            bool flag = false;
            string[] setTypeStringLong = DatabaseAPI.Database.SetTypeStringLong;
            checked
            {
                if (cell.Y == 0)
                {
                    switch (cell.X)
                    {
                        case 0:
                            this.SetInfoStrings("No Enhancement", "");
                            break;
                        case 1:
                            this.SetInfoStrings("Regular Enhancement", "Training, Dual and Single Origin Types");
                            break;
                        case 2:
                            this.SetInfoStrings("Invention", "Crafted from salvage");
                            break;
                        case 3:
                            this.SetInfoStrings("Special/Hami-O", "These can have multiple effects");
                            break;
                        case 4:
                            this.SetInfoStrings("Invention Set", "Collecting a set will grant additional effects");
                            break;
                    }
                    flag = true;
                }
                else if (cell.Y > 0)
                {
                    if (this.CellSetTypeSelect(cell))
                    {
                        switch (this.UI.View.TabID)
                        {
                            case eType.Normal:
                                if (cell.Y < this.UI.NOGrades.Length)
                                {
                                    string message = "";
                                    int num = cell.Y;
                                    if (num == 1)
                                    {
                                        num = 3;
                                    }
                                    else if (num == 3)
                                    {
                                        num = 1;
                                    }
                                    switch (num)
                                    {
                                        case 0:
                                            message = "This is not an enhancement grade!";
                                            break;
                                        case 1:
                                            message = "This is the weakest type of enhancement.";
                                            break;
                                        case 2:
                                            message = "Half as efective as Single Origin.";
                                            break;
                                        case 3:
                                            message = "The most effective regular enhancement.";
                                            break;
                                    }
                                    this.SetInfoStrings(DatabaseAPI.Database.EnhGradeStringLong[this.UI.NOGrades[num]], message);
                                    flag = true;
                                }
                                break;
                            case eType.SpecialO:
                                if (cell.Y < this.UI.SpecialTypes.Length)
                                {
                                    string message2 = "";
                                    switch (cell.Y)
                                    {
                                        case 0:
                                            message2 = "This is not an enhancement subtype!";
                                            break;
                                        case 1:
                                            message2 = "Hamidon/Synthetic Hamidon enhancements.";
                                            break;
                                        case 2:
                                            message2 = "Rewards from the Sewer Trial.";
                                            break;
                                        case 3:
                                            message2 = "Rewards from the Eden Trial.";
                                            break;
                                    }
                                    this.SetInfoStrings(DatabaseAPI.Database.SpecialEnhStringLong[this.UI.SpecialTypes[cell.Y]], message2);
                                    flag = true;
                                }
                                break;
                            case eType.SetO:
                                if (cell.Y - 1 < this.UI.SetTypes.Length)
                                {
                                    this.SetInfoStrings(setTypeStringLong[this.UI.SetTypes[cell.Y - 1]], "Click here to view the set listing.");
                                    flag = true;
                                }
                                break;
                        }
                    }
                    else if (this.CellSetSelect(cellIndex))
                    {
                        int num2 = this.UI.Sets[this.UI.View.SetTypeID][cellIndex];
                        string str;
                        if (DatabaseAPI.Database.EnhancementSets[num2].LevelMin == DatabaseAPI.Database.EnhancementSets[num2].LevelMax)
                        {
                            str = " (" + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[num2].LevelMin + 1) + ")";
                        }
                        else
                        {
                            str = string.Concat(new string[]
                            {
                                " (",
                                Conversions.ToString(DatabaseAPI.Database.EnhancementSets[num2].LevelMin + 1),
                                "-",
                                Conversions.ToString(DatabaseAPI.Database.EnhancementSets[num2].LevelMax + 1),
                                ")"
                            });
                        }
                        this.SetInfoStrings(DatabaseAPI.Database.EnhancementSets[num2].DisplayName + str, "Type: " + setTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[num2].SetType]);
                        if ((cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y) || alwaysUpdate)
                        {
                            this.RaiseHoverSet(num2);
                        }
                        flag = true;
                    }
                    else if (this.CellEnhSelect(cellIndex))
                    {
                        int num2 = 0;
                        switch (this.UI.View.TabID)
                        {
                            case 0:
                                num2 = -1;
                                this.SetInfoStrings("", "");
                                break;
                            case eType.Normal:
                                num2 = this.UI.NO[cellIndex];
                                this.SetInfoStrings(DatabaseAPI.Database.Enhancements[num2].Name, DatabaseAPI.Database.Enhancements[num2].Desc);
                                break;
                            case eType.InventO:
                                num2 = this.UI.IO[cellIndex];
                                this.SetInfoStrings(DatabaseAPI.Database.Enhancements[num2].Name, DatabaseAPI.Database.Enhancements[num2].Desc);
                                break;
                            case eType.SpecialO:
                                num2 = this.UI.SpecialO[cellIndex];
                                this.SetInfoStrings(DatabaseAPI.Database.Enhancements[num2].Name, DatabaseAPI.Database.Enhancements[num2].Desc);
                                break;
                            case eType.SetO:
                                {
                                    num2 = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[cellIndex];
                                    string text = DatabaseAPI.Database.Enhancements[num2].Name;
                                    string str2;
                                    if (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[num2].nIDSet].LevelMin == DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[num2].nIDSet].LevelMax)
                                    {
                                        str2 = " (" + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[num2].nIDSet].LevelMin + 1) + ")";
                                    }
                                    else
                                    {
                                        str2 = string.Concat(new string[]
                                        {
                                    " (",
                                    Conversions.ToString(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[num2].nIDSet].LevelMin + 1),
                                    "-",
                                    Conversions.ToString(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[num2].nIDSet].LevelMax + 1),
                                    ")"
                                        });
                                        if (DatabaseAPI.Database.Enhancements[num2].Unique)
                                        {
                                            text += " (Unique)";
                                        }
                                    }
                                    this.SetInfoStrings(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[num2].nIDSet].DisplayName + str2, text);
                                    break;
                                }
                        }
                        if ((cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y) || alwaysUpdate)
                        {
                            this.RaiseHoverEnhancement(num2);
                        }
                        flag = true;
                    }
                }
                if (!flag)
                {
                    cell = new Point(-1, -1);
                }
                if (cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y)
                {
                    this._hoverCell = cell;
                    this.FullDraw();
                }
            }
        }

        // Token: 0x06000186 RID: 390 RVA: 0x0000EBF8 File Offset: 0x0000CDF8
        private int SetIDGlobalToLocal(int iId)
        {
            int num = 0;
            checked
            {
                int num2 = this.UI.SetTypes.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    int num3 = 0;
                    int num4 = this.UI.Sets[i].Length - 1;
                    for (int j = num3; j <= num4; j++)
                    {
                        if (this.UI.Sets[i][j] == iId)
                        {
                            return j;
                        }
                    }
                }
                return 0;
            }
        }

        // Token: 0x06000187 RID: 391 RVA: 0x0000EC8C File Offset: 0x0000CE8C
        private static int[] GetSets(eSetType iSetType)
        {
            List<int> list = new List<int>();
            int num = 0;
            checked
            {
                int num2 = DatabaseAPI.Database.EnhancementSets.Count - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (DatabaseAPI.Database.EnhancementSets[i].SetType == iSetType)
                    {
                        list.Add(i);
                    }
                }
                return list.ToArray();
            }
        }

        // Token: 0x06000188 RID: 392 RVA: 0x0000ED04 File Offset: 0x0000CF04
        private static int[] GetValidSetTypes(int iPowerIDX)
        {
            int[] array = new int[0];
            int[] result;
            if (iPowerIDX < 0)
            {
                result = array;
            }
            else
            {
                array = new int[checked(DatabaseAPI.Database.Power[iPowerIDX].SetTypes.Length - 1 + 1)];
                Array.Copy(DatabaseAPI.Database.Power[iPowerIDX].SetTypes, array, DatabaseAPI.Database.Power[iPowerIDX].SetTypes.Length);
                Array.Sort<int>(array);
                result = array;
            }
            return result;
        }

        // Token: 0x06000189 RID: 393 RVA: 0x0000ED80 File Offset: 0x0000CF80
        private static int[] GetValidEnhancements(int iPowerIDX, eType iType, eSubtype iSubType = 0)
        {
            int[] array = new int[0];
            int[] result;
            if (iPowerIDX < 0)
            {
                result = array;
            }
            else
            {
                result = DatabaseAPI.Database.Power[iPowerIDX].GetValidEnhancements(iType, iSubType);
            }
            return result;
        }

        // Token: 0x0600018A RID: 394 RVA: 0x0000EDBC File Offset: 0x0000CFBC
        public void SetData(int iPower, ref I9Slot iSlot, ref clsDrawX iDraw, int[] slotted)
        {
            this.TimerReset();
            this._levelCapped = false;
            this._userLevel = -1;
            this._hDraw = iDraw;
            this._mySlot = (I9Slot)iSlot.Clone();
            this._hoverCell = new Point(-1, -1);
            this._hoverText = "";
            this._hoverTitle = "";
            this._nPowerIDX = iPower;
            this.UI = new I9Picker.cTracking();
            eSubtype eSubtype = 0;
            this.UI.SpecialTypes = (int[])Enum.GetValues(eSubtype.GetType());
            eEnhGrade eEnhGrade = 0;
            this.UI.NOGrades = (int[])Enum.GetValues(eEnhGrade.GetType());
            this.UI.NO = I9Picker.GetValidEnhancements(this._nPowerIDX, eType.Normal, 0);
            this.UI.IO = I9Picker.GetValidEnhancements(this._nPowerIDX, eType.InventO, 0);
            this.UI.Initial.GradeID = this._lastGrade;
            this.UI.Initial.RelLevel = this._lastRelativeLevel;
            this.UI.Initial.SpecialID = this._lastSpecial;
            if (this.UI.Initial.SpecialID == 0)
            {
                this.UI.Initial.SpecialID = eSubtype.Hamidon;
            }
            if (this.UI.Initial.GradeID == 0)
            {
                this.UI.Initial.GradeID = MidsContext.Config.CalcEnhOrigin;
            }
            if (this.UI.Initial.RelLevel == 0)
            {
                this.UI.Initial.RelLevel = MidsContext.Config.CalcEnhLevel;
            }
            if (this._mySlot.Enh > -1)
            {
                if (DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID != 0)
                {
                    this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, eType.SpecialO, DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID);
                    this.UI.Initial.SpecialID = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID;
                }
                else
                {
                    this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, eType.SpecialO, this.UI.Initial.SpecialID);
                }
            }
            else
            {
                this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, eType.SpecialO, this.UI.Initial.SpecialID);
            }
            this.UI.SetTypes = I9Picker.GetValidSetTypes(this._nPowerIDX);
            checked
            {
                this.UI.Sets = new int[this.UI.SetTypes.Length - 1 + 1][];
                int num = 0;
                int num2 = this.UI.SetTypes.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    this.UI.Sets[i] = I9Picker.GetSets((eSetType)this.UI.SetTypes[i]);
                }
                if (this._mySlot.Grade != 0)
                {
                    this.UI.Initial.GradeID = this._mySlot.Grade;
                }
                if (this._mySlot.Enh > -1)
                {
                    this.UI.Initial.RelLevel = this._mySlot.RelativeLevel;
                }
                else
                {
                    this._mySlot.RelativeLevel = this._lastRelativeLevel;
                    this._mySlot.Grade = this._lastGrade;
                }
                if (this._mySlot.Enh > -1)
                {
                    var power = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].GetPower();
                    if (power != null && !power.BoostBoostable)
                    {
                        this._mySlot.RelativeLevel = eEnhRelative.Even;
                    }
                    if (this._nPowerIDX < 0)
                    {
                        switch (DatabaseAPI.Database.Enhancements[this._mySlot.Enh].TypeID)
                        {
                            case eType.Normal:
                                this.UI.NO = new int[1];
                                this.UI.NO[0] = this._mySlot.Enh;
                                break;
                            case eType.InventO:
                                this.UI.IO = new int[1];
                                this.UI.IO[0] = this._mySlot.Enh;
                                break;
                            case eType.SpecialO:
                                this.UI.SpecialO = new int[1];
                                this.UI.SpecialO[0] = this._mySlot.Enh;
                                break;
                            case eType.SetO:
                                {
                                    this.UI.SetTypes = new int[1];
                                    this.UI.SetTypes[0] = (int)DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].SetType;
                                    this.UI.Sets = new int[1][];
                                    int[] array = new int[1];
                                    this.UI.Sets[0] = array;
                                    this.UI.Sets[0][0] = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet;
                                    this.UI.SetO = new int[1];
                                    this.UI.SetO[0] = this._mySlot.Enh;
                                    break;
                                }
                        }
                    }
                    this.UI.Initial.TabID = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].TypeID;
                    if (this.UI.Initial.TabID == eType.SetO)
                    {
                        this.UI.Initial.SetID = this.SetIDGlobalToLocal(DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet);
                        this.UI.Initial.SetTypeID = this.SetTypeToID(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].SetType);
                        this.UI.SetO = new int[DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].Enhancements.Length - 1 + 1];
                        Array.Copy(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].Enhancements, this.UI.SetO, this.UI.SetO.Length);
                    }
                    else if (this.UI.SetTypes.Length > 0)
                    {
                        this.UI.Initial.SetTypeID = 0;
                    }
                    this.UI.Initial.PickerID = this.GetPickerIndex(this._mySlot.Enh, this.UI.Initial.TabID);
                }
                else
                {
                    this.UI.Initial.TabID = 0;
                }
                if ((int)this.UI.Initial.TabID == 2 | (int)this.UI.Initial.TabID == 4)
                {
                    this.UI.Initial.IOLevel = this._mySlot.IOLevel + 1;
                }
                else if (this.LastLevel > 0)
                {
                    this.UI.Initial.IOLevel = this.LastLevel;
                }
                else
                {
                    this.UI.Initial.IOLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
                }
                this.UI.View = new I9Picker.cTracking.cLocation(this.UI.Initial);
                if (this.UI.View.TabID == 0)
                {
                    if (this._lastTab != 0)
                    {
                        this.UI.View.TabID = this._lastTab;
                    }
                    else
                    {
                        this.UI.View.TabID = eType.Normal;
                    }
                    if ((int)this.UI.View.TabID == 4 & this.UI.SetTypes.Length > this._lastSet)
                    {
                        this.UI.View.SetTypeID = this._lastSet;
                    }
                }
                this._mySlotted = new int[slotted.Length - 1 + 1];
                Array.Copy(slotted, this._mySlotted, this._mySlotted.Length);
                if (this.UI.SetTypes.Length > 3)
                {
                    this._rows = this.UI.SetTypes.Length;
                    base.Height = 235 + (this._nSize + 2 + this._nPad) * (this.UI.SetTypes.Length - 3);
                }
                else
                {
                    this._rows = 5;
                    base.Height = 235;
                }
                this.FullDraw();
            }
        }

        // Token: 0x0600018B RID: 395 RVA: 0x0000F770 File Offset: 0x0000D970
        private void SetSpecialEnhSet(eSubtype iSubType)
        {
            this.UI.View.SpecialID = iSubType;
            if (this._nPowerIDX > 0)
            {
                this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, eType.SpecialO, this.UI.View.SpecialID);
            }
            else if (this.UI.Initial.SpecialID == this.UI.View.SpecialID & (int)this.UI.Initial.TabID == 3)
            {
                this.UI.SpecialO = new int[1];
                this.UI.SpecialO[0] = this._mySlot.Enh;
            }
            else
            {
                this.UI.SpecialO = new int[0];
            }
        }

        // Token: 0x0600018C RID: 396 RVA: 0x0000F848 File Offset: 0x0000DA48
        private int SetTypeToID(eSetType iSetType)
        {
            int num = 0;
            checked
            {
                int num2 = this.UI.SetTypes.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (iSetType == (eSetType)this.UI.SetTypes[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        // Token: 0x0600018D RID: 397 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
        private int GetPickerIndex(int index, eType iType)
        {
            int[] array = new int[0];
            switch (iType)
            {
                case eType.Normal:
                    array = this.UI.NO;
                    break;
                case eType.InventO:
                    array = this.UI.IO;
                    break;
                case eType.SpecialO:
                    array = this.UI.SpecialO;
                    break;
                case eType.SetO:
                    array = this.UI.SetO;
                    break;
            }
            int num = 0;
            checked
            {
                int num2 = array.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (array[i] == index)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        // Token: 0x0600018E RID: 398 RVA: 0x0000F94C File Offset: 0x0000DB4C
        private void CheckAndFixIOLevel()
        {
            int num = 50;
            int num2 = 10;
            checked
            {
                if ((int)this.UI.View.TabID == 2)
                {
                    if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.PickerID == this.UI.View.PickerID & this.UI.View.PickerID > -1)
                    {
                        num = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMax + 1;
                        num2 = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMin + 1;
                    }
                }
                else if ((int)this.UI.View.TabID == 4 && (this.UI.View.SetID > -1 & this.UI.View.SetTypeID > -1))
                {
                    num = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMax + 1;
                    num2 = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMin + 1;
                }
                if (this.UI.View.IOLevel > num)
                {
                    this.UI.View.IOLevel = num;
                }
                if (this.UI.View.IOLevel < num2)
                {
                    this.UI.View.IOLevel = num2;
                }
                if ((int)this.UI.View.TabID == 2)
                {
                    if (num > 50)
                    {
                        num = 50;
                    }
                    this.UI.View.IOLevel = Enhancement.GranularLevelZb(this.UI.View.IOLevel - 1, num2 - 1, num - 1, 5) + 1;
                }
            }
        }

        // Token: 0x0600018F RID: 399 RVA: 0x0000FBD0 File Offset: 0x0000DDD0
        public int CheckAndReturnIOLevel()
        {
            int num = 50;
            int num2 = 10;
            int num3 = this.UI.View.IOLevel;
            checked
            {
                if ((int)this.UI.View.TabID == 2)
                {
                    if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.PickerID == this.UI.View.PickerID & this.UI.View.PickerID > -1)
                    {
                        num = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMax + 1;
                        num2 = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMin + 1;
                    }
                }
                else if ((int)this.UI.View.TabID == 4 && (this.UI.View.SetID > -1 & this.UI.View.SetTypeID > -1))
                {
                    num = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMax + 1;
                    num2 = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMin + 1;
                }
                if (num3 > num)
                {
                    num3 = num;
                }
                if (num3 < num2)
                {
                    num3 = num2;
                }
                if ((int)this.UI.View.TabID == 2)
                {
                    if (num > 50)
                    {
                        num = 50;
                    }
                    num3 = Enhancement.GranularLevelZb(num3 - 1, num2 - 1, num - 1, 5) + 1;
                }
                return num3;
            }
        }

        // Token: 0x06000190 RID: 400 RVA: 0x0000FE1C File Offset: 0x0000E01C
        private void TimerReset()
        {
            this._timerLastKeypress = -1.0;
        }

        // Token: 0x06000191 RID: 401 RVA: 0x0000FE30 File Offset: 0x0000E030
        private void NumberPressed(int iNumber)
        {
            double timer = DateAndTime.Timer;
            if (timer - this._timerLastKeypress > 5.0)
            {
                this.UI.View.IOLevel = iNumber;
                this._userLevel = this.UI.View.IOLevel;
                this._timerLastKeypress = timer;
            }
            else
            {
                string text = Conversions.ToString(this.UI.View.IOLevel);
                text += Conversions.ToString(iNumber);
                checked
                {
                    if (text.Length > 2)
                    {
                        text = text.Substring(text.Length - 2);
                    }
                    int num = (int)Math.Round(Conversion.Val(text));
                    if (num > 50)
                    {
                        num = 50;
                    }
                    if (num < 1)
                    {
                        num = 1;
                    }
                    this.UI.View.IOLevel = num;
                    this._userLevel = this.UI.View.IOLevel;
                    if (num >= 10)
                    {
                        this.TimerReset();
                    }
                }
            }
        }

        // Token: 0x06000192 RID: 402 RVA: 0x0000FF40 File Offset: 0x0000E140
        private void I9PickerKeyDown(object sender, KeyEventArgs e)
        {
            int num = -1;
            Keys keyCode = e.KeyCode;
            checked
            {
                if (keyCode == Keys.Return)
                {
                    this.UI.Initial.IOLevel = this.UI.View.IOLevel;
                    this.UI.Initial.RelLevel = this.UI.View.RelLevel;
                    this.UI.View = new I9Picker.cTracking.cLocation(this.UI.Initial);
                    this.DOEnhancementPicked(this.UI.View.PickerID);
                }
                else if (keyCode == Keys.Back)
                {
                    this.UI.View.IOLevel = this.UI.Initial.IOLevel;
                    this.UI.View.RelLevel = this.UI.Initial.RelLevel;
                    this.TimerReset();
                }
                else if (keyCode == Keys.Delete)
                {
                    this.UI.View.IOLevel = this.UI.Initial.IOLevel;
                    this.UI.View.RelLevel = this.UI.Initial.RelLevel;
                    this.TimerReset();
                }
                else if (keyCode == Keys.Decimal)
                {
                    this.UI.View.IOLevel = this.UI.Initial.IOLevel;
                    this.UI.View.RelLevel = this.UI.Initial.RelLevel;
                    this.TimerReset();
                }
                else if (keyCode == Keys.Home)
                {
                    this.UI.View.IOLevel = 0;
                    this.UI.View.RelLevel = eEnhRelative.MinusThree;
                    this.TimerReset();
                }
                else if (keyCode == Keys.End)
                {
                    this.UI.View.IOLevel = 100;
                    this.UI.View.RelLevel = eEnhRelative.PlusFive;
                    this.TimerReset();
                }
                else if (keyCode == Keys.Space)
                {
                    this.UI.View.IOLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
                    this.UI.View.RelLevel = eEnhRelative.Even;
                    this.TimerReset();
                }
                else if (keyCode == Keys.Add)
                {
                    this.RelAdjust(1);
                }
                else if (keyCode == Keys.Subtract)
                {
                    this.RelAdjust(-1);
                }
                else if (keyCode == Keys.Oemplus)
                {
                    this.RelAdjust(1);
                }
                else if (keyCode == Keys.OemMinus)
                {
                    this.RelAdjust(-1);
                }
                else if (e.KeyValue >= 48 & e.KeyValue <= 57)
                {
                    num = e.KeyValue - 48;
                }
                else if (e.KeyValue >= 96 & e.KeyValue <= 105)
                {
                    num = e.KeyValue - 96;
                }
                if ((int)this.UI.View.TabID == 4 | (int)this.UI.View.TabID == 2)
                {
                    if (num > -1)
                    {
                        this.NumberPressed(num);
                    }
                    else
                    {
                        this.CheckAndFixIOLevel();
                    }
                }
                this.DoHover(this._hoverCell, true);
                this.FullDraw();
            }
        }

        // Token: 0x06000193 RID: 403 RVA: 0x000102E0 File Offset: 0x0000E4E0
        private void RelAdjust(int direction)
        {
            eEnhRelative eEnhRelative = this.UI.View.RelLevel;
            checked
            {
                if (direction < 0)
                {
                    if (this.UI.View.RelLevel > 0)
                    {
                        eEnhRelative--;
                    }
                }
                else if (direction > 0 && (int)this.UI.View.RelLevel < 9)
                {
                    eEnhRelative++;
                }
                if ((int)eEnhRelative > 7 & ((int)this.UI.View.TabID == 1 | (int)this.UI.View.TabID == 3))
                {
                    eEnhRelative = eEnhRelative.PlusThree;
                }
                else if ((int)eEnhRelative < 4 & ((int)this.UI.View.TabID == 2 | (int)this.UI.View.TabID == 4))
                {
                    eEnhRelative = eEnhRelative.Even;
                }
                this.UI.View.RelLevel = eEnhRelative;
            }
        }

        // Token: 0x04000095 RID: 149
        private const int IOMax = 50;

        // Token: 0x04000096 RID: 150
        private const int Cols = 5;

        // Token: 0x04000097 RID: 151
        private const int DilateVal = 2;

        // Token: 0x04000098 RID: 152
        private const double timerResetDelay = 5.0;

        // Token: 0x04000099 RID: 153
        private Point _mouseOffset;

        // Token: 0x0400009A RID: 154
        private int _rows;

        // Token: 0x0400009B RID: 155
        private clsDrawX _hDraw;

        // Token: 0x0400009C RID: 156
        private I9Slot _mySlot;

        // Token: 0x0400009D RID: 157
        private ExtendedBitmap _myBx;

        // Token: 0x0400009E RID: 158
        private Point _hoverCell;

        // Token: 0x0400009F RID: 159
        private string _hoverTitle;

        // Token: 0x040000A0 RID: 160
        private string _hoverText;

        // Token: 0x040000A1 RID: 161
        private int _headerHeight;

        // Token: 0x040000A2 RID: 162
        private int[] _mySlotted;

        // Token: 0x040000A3 RID: 163
        private bool _levelCapped;

        // Token: 0x040000A4 RID: 164
        private int _userLevel;

        // Token: 0x040000A5 RID: 165
        private eType _lastTab;

        // Token: 0x040000A6 RID: 166
        private int _lastSet;

        // Token: 0x040000A7 RID: 167
        public int LastLevel;

        // Token: 0x040000A8 RID: 168
        private eEnhGrade _lastGrade;

        // Token: 0x040000A9 RID: 169
        private eEnhRelative _lastRelativeLevel;

        // Token: 0x040000AA RID: 170
        private eSubtype _lastSpecial;

        // Token: 0x040000AB RID: 171
        private double _timerLastKeypress;

        // Token: 0x040000AC RID: 172
        public I9Picker.cTracking UI;

        // Token: 0x040000AD RID: 173
        private int _nPad;

        // Token: 0x040000AE RID: 174
        private int _nSize;

        // Token: 0x040000AF RID: 175
        private Color _cHighlight;

        // Token: 0x040000B0 RID: 176
        private Color _cSelected;

        // Token: 0x040000B1 RID: 177
        private int _nPowerIDX;

        // Token: 0x040000B2 RID: 178
        private IContainer components;

        // Token: 0x040000B3 RID: 179
        [AccessedThroughProperty("tTip")]
        private ToolTip _tTip;

        // Token: 0x02000016 RID: 22
        public class cTracking
        {
            // Token: 0x06000194 RID: 404 RVA: 0x000103DC File Offset: 0x0000E5DC
            public cTracking()
            {
                this.NO = new int[0];
                this.IO = new int[0];
                this.SpecialO = new int[0];
                this.NOGrades = new int[0];
                this.SpecialTypes = new int[0];
                this.SetTypes = new int[0];
                this.Sets = new int[0][];
                this.SetO = new int[0];
                this.Initial = new I9Picker.cTracking.cLocation();
                this.View = new I9Picker.cTracking.cLocation();
            }

            // Token: 0x040000B8 RID: 184
            public int[] NO;

            // Token: 0x040000B9 RID: 185
            public int[] IO;

            // Token: 0x040000BA RID: 186
            public int[] SpecialO;

            // Token: 0x040000BB RID: 187
            public int[] NOGrades;

            // Token: 0x040000BC RID: 188
            public int[] SpecialTypes;

            // Token: 0x040000BD RID: 189
            public int[] SetTypes;

            // Token: 0x040000BE RID: 190
            public int[][] Sets;

            // Token: 0x040000BF RID: 191
            public int[] SetO;

            // Token: 0x040000C0 RID: 192
            public readonly I9Picker.cTracking.cLocation Initial;

            // Token: 0x040000C1 RID: 193
            public I9Picker.cTracking.cLocation View;

            // Token: 0x02000017 RID: 23
            public class cLocation
            {
                // Token: 0x06000195 RID: 405 RVA: 0x00010468 File Offset: 0x0000E668
                public cLocation()
                {
                    this.TabID = 0;
                    this.PickerID = -1;
                    this.SetTypeID = -1;
                    this.SetID = -1;
                    this.GradeID = 0;
                    this.SpecialID = 0;
                    this.IOLevel = 0;
                    this.RelLevel = eEnhRelative.Even;
                }

                // Token: 0x06000196 RID: 406 RVA: 0x000104B8 File Offset: 0x0000E6B8
                public cLocation(I9Picker.cTracking.cLocation iCL)
                {
                    this.TabID = 0;
                    this.PickerID = -1;
                    this.SetTypeID = -1;
                    this.SetID = -1;
                    this.GradeID = 0;
                    this.SpecialID = 0;
                    this.IOLevel = 0;
                    this.RelLevel = eEnhRelative.Even;
                    this.TabID = iCL.TabID;
                    this.PickerID = iCL.PickerID;
                    this.SetTypeID = iCL.SetTypeID;
                    this.GradeID = iCL.GradeID;
                    this.SpecialID = iCL.SpecialID;
                    this.SetID = iCL.SetID;
                    this.IOLevel = iCL.IOLevel;
                    this.RelLevel = iCL.RelLevel;
                }

                // Token: 0x040000C2 RID: 194
                public eType TabID;

                // Token: 0x040000C3 RID: 195
                public int PickerID;

                // Token: 0x040000C4 RID: 196
                public int SetTypeID;

                // Token: 0x040000C5 RID: 197
                public int SetID;

                // Token: 0x040000C6 RID: 198
                public eEnhGrade GradeID;

                // Token: 0x040000C7 RID: 199
                public eSubtype SpecialID;

                // Token: 0x040000C8 RID: 200
                public int IOLevel;

                // Token: 0x040000C9 RID: 201
                public eEnhRelative RelLevel;
            }
        }

        // Token: 0x02000018 RID: 24
        // (Invoke) Token: 0x06000198 RID: 408
        public delegate void EnhancementPickedEventHandler(I9Slot e);

        // Token: 0x02000019 RID: 25
        // (Invoke) Token: 0x0600019C RID: 412
        public delegate void HoverEnhancementEventHandler(int e);

        // Token: 0x0200001A RID: 26
        // (Invoke) Token: 0x060001A0 RID: 416
        public delegate void HoverSetEventHandler(int e);

        // Token: 0x0200001B RID: 27
        // (Invoke) Token: 0x060001A4 RID: 420
        public delegate void MovedEventHandler(Rectangle oldBounds, Rectangle newBounds);
    }
}
