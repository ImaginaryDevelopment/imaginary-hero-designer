using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    public class I9Picker : UserControl
    {
        public int LastLevel;

        public event I9Picker.EnhancementPickedEventHandler EnhancementPicked;
        public event I9Picker.HoverEnhancementEventHandler HoverEnhancement;
        public event I9Picker.HoverSetEventHandler HoverSet;
        public event I9Picker.MovedEventHandler Moved;

        const int IOMax = 50;
        const int Cols = 5;
        const int DilateVal = 2;
        const double timerResetDelay = 5.0;

        Point _mouseOffset;
        int _rows;
        clsDrawX _hDraw;
        I9Slot _mySlot;
        ExtendedBitmap _myBx;
        Point _hoverCell;
        string _hoverTitle;
        string _hoverText;
        int _headerHeight;
        int[] _mySlotted;
        bool _levelCapped;
        int _userLevel;
        int _lastSet;
        int _nPad;
        int _nSize;
        int _nPowerIDX;
        Enums.eType _lastTab;
        Enums.eEnhGrade _lastGrade;
        Enums.eEnhRelative _lastRelativeLevel;
        Enums.eSubtype _lastSpecial;
        double _timerLastKeypress;
        public I9Picker.cTracking UI;
        Color _cHighlight;
        Color _cSelected;

        IContainer components;

        [AccessedThroughProperty("tTip")]
        ToolTip _tTip;



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
            this._mySlotted = Array<int>.Empty();
            this._userLevel = -1;
            this._lastTab = Enums.eType.Normal;
            this.LastLevel = -1;
            this._lastGrade = Enums.eEnhGrade.SingleO;
            this._lastRelativeLevel = Enums.eEnhRelative.Even;
            this._lastSpecial = Enums.eSubtype.Hamidon;
            this.UI = new I9Picker.cTracking();
            this._nPad = 8;
            this._nSize = 30;
            this._cHighlight = Color.SlateBlue;
            this._cSelected = Color.BlueViolet;
            this._nPowerIDX = -1;
            this.InitializeComponent();
        }

        ToolTip tTip
        {
            get => this._tTip;
            set
            {
                this._tTip = value;
            }
        }

        public Color Highlight
        {
            get => this._cHighlight;
            set
            {
                this._cHighlight = value;
                this.FullDraw();
            }
        }

        public Color Selected
        {
            get => this._cSelected;
            set
            {
                this._cSelected = value;
                this.FullDraw();
            }
        }

        public new int Padding
        {
            get => this._nPad;
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

        public int ImageSize
        {
            get => this._nSize;
            set
            {
                if (value < 1)
                    value = 1;
                if (value > 256)
                    value = 256;
                this._nSize = value;
                this.FullDraw();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DebuggerStepThrough]
        void InitializeComponent()
        {
            this.components = new Container();
            this.tTip = new ToolTip(this.components);
            this.BackColor = Color.Silver;
            base.Name = "I9Picker";
            Size size = new Size(184, 244);
            base.Size = size;
        }

        // Token: 0x06000157 RID: 343 RVA: 0x0000B99D File Offset: 0x00009B9D
        void I9PickerLoad(object sender, EventArgs e)
        {
            this.FullDraw();
        }

        void SetBxSize()
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

        void FullDraw()
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

        void DrawLayerLowest()
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
        void DrawLayerImages()
        {
            this.DrawTypeImages();
            this.DrawEnhImages();
        }

        // Token: 0x0600015C RID: 348 RVA: 0x0000BB1C File Offset: 0x00009D1C
        void DrawHeaderBox()
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
        void DrawLevelBox()
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
            if (this.UI.View.TabID == Enums.eType.InventO | this.UI.View.TabID == Enums.eType.SetO)
            {
                s = Conversions.ToString(this.UI.View.IOLevel);
            }
            else
            {
                s = I9Picker.GetRelativeString(this.UI.View.RelLevel);
            }
            this._myBx.Graphics.DrawString(s, font, brush, layoutRectangle, stringFormat);
        }

        static string GetRelativeString(Enums.eEnhRelative iRel)
        {
            string result;
            switch (iRel)
            {
                case 0:
                    result = "X";
                    break;
                case Enums.eEnhRelative.MinusThree:
                    result = "-3";
                    break;
                case Enums.eEnhRelative.MinusTwo:
                    result = "-2";
                    break;
                case Enums.eEnhRelative.MinusOne:
                    result = "-1";
                    break;
                case Enums.eEnhRelative.Even:
                    result = "+/-";
                    break;
                case Enums.eEnhRelative.PlusOne:
                    result = "+1";
                    break;
                case Enums.eEnhRelative.PlusTwo:
                    result = "+2";
                    break;
                case Enums.eEnhRelative.PlusThree:
                    result = "+3";
                    break;
                case Enums.eEnhRelative.PlusFour:
                    result = "+4";
                    break;
                case Enums.eEnhRelative.PlusFive:
                    result = "+5";
                    break;
                default:
                    result = "!";
                    break;
            }
            return result;
        }

        void DrawTextBox()
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(this.ForeColor);
            Rectangle iRect = default;
            iRect.X = this._nPad;
            RectangleF layoutRectangle = default;
            RectangleF layoutRectangle2 = default;
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
        void SetInfoStrings(string title, string message)
        {
            this._hoverTitle = title;
            this._hoverText = message;
        }

        // Token: 0x06000161 RID: 353 RVA: 0x0000C1AC File Offset: 0x0000A3AC
        void DrawTypeImages()
        {
            Rectangle srcRect = new Rectangle(0, 0, this._nSize, this._nSize);
            Enums.eType eType = 0;
            Rectangle rectBounds = this.GetRectBounds(0, 0);
            checked
            {
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect.X, srcRect.Y, 30, 30, GraphicsUnit.Pixel, this._hDraw.pImageAttributes);
                eType = Enums.eType.Normal;
                rectBounds = this.GetRectBounds(1, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
                eType = Enums.eType.InventO;
                rectBounds = this.GetRectBounds(2, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
                eType = Enums.eType.SpecialO;
                rectBounds = this.GetRectBounds(3, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
                eType = Enums.eType.SetO;
                rectBounds = this.GetRectBounds(4, 0);
                srcRect.X = (int)eType * this._nSize;
                this._myBx.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectBounds, srcRect, GraphicsUnit.Pixel);
            }
        }

        void DrawEnhImages()
        {
            checked
            {
                switch (this.UI.View.TabID)
                {
                    case Enums.eType.Normal:
                        {
                            int num = 1;
                            for (int i = this.UI.NOGrades.Length - 1; i >= 1; i += -1)
                            {
                                Rectangle srcRect = new Rectangle(this.UI.NOGrades[i] * this._nSize, 0, this._nSize, this._nSize);
                                this._myBx.Graphics.DrawImage(I9Gfx.Borders.Bitmap, this.GetRectBounds(4, num), I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade((Enums.eType)1, (Enums.eEnhGrade)i)), GraphicsUnit.Pixel);
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
                                    case Enums.eEnhGrade.TrainingO:
                                        grade = 0;
                                        break;
                                    case Enums.eEnhGrade.DualO:
                                        grade = Origin.Grade.DualO;
                                        break;
                                    case Enums.eEnhGrade.SingleO:
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
                    case Enums.eType.InventO:
                        {
                            for (int i = 0; i <= this.UI.IO.Length - 1; i++)
                            {
                                Graphics graphics = this._myBx.Graphics;
                                I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(i)), this.UI.IO[i], (Origin.Grade)4);
                            }
                            break;
                        }
                    case Enums.eType.SpecialO:
                        {
                            for (int i = 1; i <= this.UI.SpecialTypes.Length - 1; i++)
                            {
                                Rectangle srcRect2 = new Rectangle(this.UI.SpecialTypes[i] * this._nSize, 0, this._nSize, this._nSize);
                                this._myBx.Graphics.DrawImage(I9Gfx.EnhSpecials.Bitmap, this.GetRectBounds(4, i), srcRect2, GraphicsUnit.Pixel);
                            }
                            for (int i = 0; i <= this.UI.SpecialO.Length - 1; i++)
                            {
                                Graphics graphics = this._myBx.Graphics;
                                I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(i)), this.UI.SpecialO[i], (Origin.Grade)3);
                            }
                            break;
                        }
                    case Enums.eType.SetO:
                        {
                            for (int i = 0; i <= this.UI.SetTypes.Length - 1; i++)
                            {
                                Rectangle srcRect3 = new Rectangle(this.UI.SetTypes[i] * this._nSize, 0, this._nSize, this._nSize);
                                this._myBx.Graphics.DrawImage(I9Gfx.SetTypes.Bitmap, this.GetRectBounds(4, i + 1), srcRect3, GraphicsUnit.Pixel);
                            }
                            if (this.UI.View.SetID > -1)
                                this.DisplaySetEnhancements();
                            else
                                this.DisplaySetImages();
                            break;
                        }
                }
            }
        }

        static ImageAttributes GreyItem(bool grey)
        {
            checked
            {
                if (!grey)
                {
                    return new ImageAttributes();
                }
                else
                {
                    ColorMatrix colorMatrix = new ColorMatrix(clsDrawX.heroMatrix);
                    int r = 0;
                    do
                    {
                        int c = 0;
                        do
                        {
                            if (r != 4)
                            {
                                ColorMatrix colorMatrix2;
                                int row;
                                int column;
                                (colorMatrix2 = colorMatrix)[row = r, column = c] = colorMatrix2[row, column] / 2f;
                            }
                            c++;
                        }
                        while (c <= 2);
                        r++;
                    }
                    while (r <= 2);
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(colorMatrix);
                    return imageAttributes;
                }
            }
        }

        void DisplaySetEnhancements()
        {
            checked
            {
                for (int i = 0; i <= DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements.Length - 1; i++)
                {
                    var enh = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[i];
                    bool grey = false;
                    foreach (var slotted in this._mySlotted)
                    //for (int j = 0; j <= this._mySlotted.Length - 1; j++)
                    {
                        if (enh == slotted)
                        {
                            grey = true;
                            break;
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
                // only check sets
                if (this.UI.View.TabID != Enums.eType.SetO) return false;
                // id must be set
                if (this.UI.View.SetID < 0) return false;
                // the set type must be valid
                if (this.UI.View.SetTypeID >= this.UI.Sets.Length) return false;
                // the id index must be inside the range of the set
                if (this.UI.View.SetID >= this.UI.Sets[this.UI.View.SetTypeID].Length) return false;

                if (this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID] >= DatabaseAPI.Database.EnhancementSets.Count) return false;
                if (index >= DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements.Length) return false;
                if (this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.Initial.SetID == this.UI.View.SetID & this.UI.Initial.PickerID == index) return false;

                int num = 0;
                int num2 = this._mySlotted.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index] == this._mySlotted[i])
                        return true;
                }
                return false;
            }
        }

        void DisplaySetImages()
        {
            checked
            {
                if (this.UI.View.TabID == Enums.eType.SetO)
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

        void DrawBorder()
        {
            Pen pen = new Pen(this.ForeColor);
            Rectangle rect = default;
            rect.X = 0;
            rect.Y = 0;
            checked
            {
                rect.Height = base.Height - 1;
                rect.Width = base.Width - 1;
                this._myBx.Graphics.DrawRectangle(pen, rect);
            }
        }

        void DrawHighlights()
        {
            this.DrawHighlight(this._hoverCell.X, this._hoverCell.Y);
            this.DrawSelected((int)this.UI.View.TabID, 0);
            if (this.UI.View.TabID == Enums.eType.SetO)
            {
                if (this.UI.View.SetTypeID > -1)
                {
                    this.DrawSelected(4, checked(this.UI.View.SetTypeID + 1));
                }
            }
            else if (this.UI.View.TabID == Enums.eType.Normal)
            {
                if ((int)this.UI.View.GradeID > -1)
                {
                    this.DrawSelected(4, I9Picker.Reverse((int)this.UI.View.GradeID));
                }
            }
            else if (this.UI.View.TabID == Enums.eType.SpecialO && (int)this.UI.View.SpecialID > -1)
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
                else if (this.UI.Initial.TabID == this.UI.View.TabID && this.UI.Initial.SetTypeID == this.UI.View.SetTypeID && this.UI.View.SetID < 0)
                {
                    this.DrawSelected(this.IndexToXY(this.UI.Initial.SetID).X, this.IndexToXY(this.UI.Initial.SetID).Y);
                    this.DrawBox(this.IndexToXY(this.UI.Initial.SetID).X, this.IndexToXY(this.UI.Initial.SetID).Y);
                }
            }
        }

        void DrawTypeLine()
        {
            Rectangle rectBounds = this.GetRectBounds((int)this.UI.View.TabID, 0);
            checked
            {
                int ly1 = this._headerHeight + this._nPad + this._nSize;
                int y = ly1 + this._nPad - 2;
                int ly2 = (int)Math.Round(unchecked(rectBounds.X + rectBounds.Width / 2.0));
                Pen pen = new Pen(this.ForeColor);
                this._myBx.Graphics.DrawLine(pen, ly2, ly1, ly2, y);
            }
        }

        void DrawSetLine()
        {
            checked
            {
                if (this.UI.View.TabID == Enums.eType.SetO && this.UI.View.SetTypeID < 0)
                    return;
                if (this.UI.View.TabID == Enums.eType.Normal && this.UI.View.GradeID < 0)
                    return;
                if (this.UI.View.TabID == Enums.eType.SpecialO && this.UI.View.SpecialID < 0)
                    return;

                Rectangle rectangle = default;
                switch (this.UI.View.TabID)
                {
                    case Enums.eType.Normal:
                        rectangle = this.GetRectBounds(4, I9Picker.Reverse((int)this.UI.View.GradeID));
                        break;
                    case Enums.eType.SpecialO:
                        rectangle = this.GetRectBounds(4, (int)this.UI.View.SpecialID);
                        break;
                    case Enums.eType.SetO:
                        rectangle = this.GetRectBounds(4, this.UI.View.SetTypeID + 1);
                        break;
                }
                int ly = (int)Math.Round(unchecked(rectangle.Y + rectangle.Height / 2.0));
                int x = rectangle.X - 2;
                int x2 = rectangle.X - this._nPad + 2;
                Pen pen = new Pen(this.ForeColor);
                this._myBx.Graphics.DrawLine(pen, x, ly, x2, ly);
            }
        }

        void DrawEnhBox()
        {
            this.DrawSetBox();
            this.DrawSetLine();
            this.DrawEnhBoxSet();
            this.DrawBox((int)this.UI.View.TabID, 0);
        }

        void DrawEnhBoxSet()
        {
            Pen pen = new Pen(this.ForeColor);
            Rectangle iRect = default;
            iRect.X = this._nPad;
            checked
            {
                iRect.Y = this._headerHeight + this._nPad * 2 + this._nSize;
                iRect.Width = this._nSize * 4 + this._nPad * 3;
                iRect.Height = this._nSize * this._rows + this._nPad * (this._rows - 1);
                this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(iRect, 2));
            }
        }

        void DrawSetBox()
        {
            Rectangle rectBounds = this.GetRectBounds(4, 1);
            Pen pen = new Pen(this.ForeColor);
            rectBounds.Height = checked(this._nSize * this._rows + this._nPad * (this._rows - 1));
            this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(rectBounds, 2));
        }

        void DrawHighlight(int x, int y)
        {
            if (x > -1 && y > -1)
                this._myBx.Graphics.FillRectangle(new SolidBrush(this._cHighlight), this.GetRectBounds(x, y));
        }

        void DrawSelected(int x, int y)
        {
            if (x > -1 && y > -1)
                this._myBx.Graphics.FillRectangle(new SolidBrush(this._cSelected), this.GetRectBounds(x, y));
        }

        void DrawBox(int x, int y)
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

        static Rectangle Dilate(Rectangle iRect, int extra = 2)
            => checked(new Rectangle(iRect.X - extra, iRect.Y - extra, iRect.Width + extra + 1, iRect.Height + extra + 1));

        Point IndexToXY(int index)
        {
            int tCols = 4;
            int tRow = 0;
            checked
            {
                while (index >= tCols)
                {
                    index -= tCols;
                    tRow++;
                }
                Point result = new Point(index, tRow + 1);
                return result;
            }
        }

        Rectangle GetRectBounds(int x, int y)
            => checked(new Rectangle(this._nPad + x * (this._nSize + this._nPad), this._headerHeight + this._nPad + y * (this._nSize + this._nPad), this._nSize, this._nSize));

        Rectangle GetRectBounds(Point iPoint)
            => this.GetRectBounds(iPoint.X, iPoint.Y);

        void I9PickerPaint(object sender, PaintEventArgs e)
        {
            if (this._myBx.Bitmap != null)
            {
                e.Graphics.DrawImage(this._myBx.Bitmap, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        Point GetCellXY(Point iPt)
        {
            checked
            {
                for (int x = 0; x <= 4; x++)
                {
                    int rows = this._rows;
                    for (int y = 0; y <= rows; y++)
                    {
                        Rectangle rectBounds = this.GetRectBounds(x, y);
                        if ((iPt.X >= rectBounds.X & iPt.X <= rectBounds.X + rectBounds.Width) && (iPt.Y >= rectBounds.Y & iPt.Y <= rectBounds.Y + rectBounds.Height))
                            return new Point(x, y);
                    }
                }
                return new Point(-1, -1);
            }
        }

        int GetCellIndex(Point cell)
        {
            if (cell.X < 0 | cell.Y <= 0)
                return -1;
            return checked((cell.Y - 1) * 4 + cell.X);
        }

        void I9PickerMouseDown(object sender, MouseEventArgs e)
        {
            Point iPt = new Point(e.X, e.Y);
            Point cellXY = this.GetCellXY(iPt);
            int cellIndex = this.GetCellIndex(cellXY);
            checked
            {
                this._mouseOffset = new Point(0 - e.X, 0 - e.Y);
                if (e.Button == MouseButtons.Right)
                    return;

                if (cellXY.Y == 0)
                {
                    this.UI.View.TabID = (Enums.eType)cellXY.X;
                    if (cellXY.X == 4 & this.UI.SetTypes.Length > 0)
                    {
                        this.UI.View.SetTypeID = 0;
                        if (this.UI.View.RelLevel < Enums.eEnhRelative.Even)
                        {
                            this.UI.View.RelLevel = Enums.eEnhRelative.Even;
                        }
                    }
                    else if (cellXY.X == 2)
                    {
                        if (this.UI.Initial.TabID == Enums.eType.Normal)
                            this.UI.Initial.TabID = Enums.eType.InventO;
                        if (this.UI.View.RelLevel < Enums.eEnhRelative.Even)
                            this.UI.View.RelLevel = Enums.eEnhRelative.Even;
                    }
                    else if (cellXY.X == 1)
                    {
                        if (this.UI.View.RelLevel > Enums.eEnhRelative.PlusThree)
                            this.UI.View.RelLevel = Enums.eEnhRelative.PlusThree;
                        if (this.UI.Initial.TabID == Enums.eType.InventO)
                            this.UI.Initial.TabID = Enums.eType.Normal;
                    }
                    else if (cellXY.X == 3 && this.UI.View.RelLevel > Enums.eEnhRelative.PlusThree)
                        this.UI.View.RelLevel = Enums.eEnhRelative.PlusThree;
                    if (cellXY.X == 0)
                        this.DoEnhancementPicked(-1);
                }
                else if (cellXY.Y > 0)
                {
                    if (this.CellSetTypeSelect(cellXY))
                    {
                        switch (this.UI.View.TabID)
                        {
                            case Enums.eType.Normal:
                                if (cellXY.Y < this.UI.NOGrades.Length)
                                {
                                    cellXY.Y = I9Picker.Reverse(cellXY.Y);
                                    this.UI.View.GradeID = (Enums.eEnhGrade)cellXY.Y;
                                    if (this.UI.Initial.TabID == Enums.eType.Normal)
                                    {
                                        this.UI.Initial.GradeID = this.UI.View.GradeID;
                                    }
                                    this.DoHover(this._hoverCell, true);
                                }
                                break;
                            case Enums.eType.SpecialO:
                                if (cellXY.Y < this.UI.SpecialTypes.Length)
                                {
                                    this.SetSpecialEnhSet((Enums.eSubtype)cellXY.Y);
                                    this.DoHover(this._hoverCell, true);
                                }
                                break;
                            case Enums.eType.SetO:
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
                        this.UI.View.SetID = cellIndex;
                        this.CheckAndFixIOLevel();
                        this.DoHover(this._hoverCell, true);
                    }
                    else if (this.CellEnhSelect(cellIndex))
                        this.DoEnhancementPicked(cellIndex);
                }
                this.FullDraw();
            }
        }

        static int Reverse(int iValue)
        {
            if (iValue == 3)
                return 1;
            if (iValue == 1)
                return 3;
            return iValue;
        }

        bool CellSetTypeSelect(Point cell)
            => cell.X == 4;

        bool CellSetSelect(int cellIDX)
            => this.UI.View.SetTypeID >= 0 && (this.UI.View.TabID == Enums.eType.SetO & this.UI.View.SetID == -1 & cellIDX > -1 & cellIDX < this.UI.Sets[this.UI.View.SetTypeID].Length);

        bool CellEnhSelect(int cellIDX)
        {
            if (cellIDX <= -1 || this.UI.View.TabID == Enums.eType.SetO && this.UI.View.SetID <= -1)
                return false;

            int[] array = Array<int>.Empty();
            switch (this.UI.View.TabID)
            {
                case Enums.eType.Normal:
                    array = this.UI.NO;
                    break;
                case Enums.eType.InventO:
                    array = this.UI.IO;
                    break;
                case Enums.eType.SpecialO:
                    array = this.UI.SpecialO;
                    break;
                case Enums.eType.SetO:
                    if (this.UI.View.SetTypeID < 0)
                        return false;
                    array = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements;
                    break;
            }
            return (cellIDX > -1 & cellIDX < array.Length);
        }

        void DoEnhancementPicked(int index)
        {
            I9Slot i9Slot = (I9Slot)this._mySlot.Clone();
            this.CheckAndFixIOLevel();
            checked
            {
                if (((this.UI.View.IOLevel != this.UI.Initial.IOLevel & this.UI.View.IOLevel != this._userLevel) | this._userLevel == -1) && !(this.UI.View.TabID == Enums.eType.InventO & Enhancement.GranularLevelZb(this._userLevel - 1, 9, 49, 5) == this.UI.View.IOLevel))
                    this._levelCapped = true;
                switch (this.UI.View.TabID)
                {
                    case 0:
                        i9Slot = new I9Slot();
                        break;
                    case Enums.eType.Normal:
                        i9Slot.Enh = this.UI.NO[index];
                        i9Slot.Grade = this.UI.View.GradeID;
                        i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        break;
                    case Enums.eType.InventO:
                        i9Slot.Enh = this.UI.IO[index];
                        i9Slot.IOLevel = this.UI.View.IOLevel - 1;
                        i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        break;
                    case Enums.eType.SpecialO:
                        i9Slot.Enh = this.UI.SpecialO[index];
                        i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        this._lastSpecial = this.UI.View.SpecialID;
                        break;
                    case Enums.eType.SetO:
                        if (this.IsPlaced(index))
                            return;
                        i9Slot.Enh = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index];
                        i9Slot.IOLevel = this.UI.View.IOLevel - 1;
                        if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].GetPower() is IPower power)
                        {
                            if (power.BoostBoostable)
                                i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        }
                        else
                            i9Slot.RelativeLevel = this.UI.View.RelLevel;
                        break;
                }
                if (this.UI.View.TabID != 0)
                    this._lastTab = this.UI.View.TabID;
                if (this.UI.View.TabID == Enums.eType.SetO)
                    this._lastSet = this.UI.View.SetTypeID;
                if (this.UI.View.TabID == Enums.eType.Normal)
                {
                    this._lastGrade = this.UI.View.GradeID;
                    this._lastRelativeLevel = this.UI.View.RelLevel;
                }
                if (this.UI.View.TabID == Enums.eType.SpecialO)
                {
                    this._lastSpecial = this.UI.View.SpecialID;
                    this._lastRelativeLevel = this.UI.View.RelLevel;
                }
                if ((this.UI.View.TabID == Enums.eType.SetO | this.UI.View.TabID == Enums.eType.InventO) & !this._levelCapped)
                {
                    if (this.UI.View.TabID == Enums.eType.InventO & Enhancement.GranularLevelZb(this._userLevel - 1, 9, 49, 5) == this.UI.View.IOLevel)
                        this.LastLevel = this._userLevel;
                    else
                        this.LastLevel = this.UI.View.IOLevel;
                }
                else if (this._userLevel > -1)
                {
                    this.LastLevel = this._userLevel;
                }
                this.EnhancementPicked?.Invoke(i9Slot);
            }
        }

        void RaiseHoverEnhancement(int e)
            => this.HoverEnhancement?.Invoke(e);

        void RaiseHoverSet(int e)
            => this.HoverSet?.Invoke(e);

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.FullDraw();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.FullDraw();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.FullDraw();
        }

        void I9PickerMouseMove(object sender, MouseEventArgs e)
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

        void DoHover(Point cell, bool alwaysUpdate = false)
        {
            int cellIndex = this.GetCellIndex(cell);
            bool hlOk = false;
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
                    hlOk = true;
                }
                else if (cell.Y > 0)
                {
                    if (this.CellSetTypeSelect(cell))
                    {
                        switch (this.UI.View.TabID)
                        {
                            case Enums.eType.Normal:
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
                                    hlOk = true;
                                }
                                break;
                            case Enums.eType.SpecialO:
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
                                    hlOk = true;
                                }
                                break;
                            case Enums.eType.SetO:
                                if (cell.Y - 1 < this.UI.SetTypes.Length)
                                {
                                    this.SetInfoStrings(setTypeStringLong[this.UI.SetTypes[cell.Y - 1]], "Click here to view the set listing.");
                                    hlOk = true;
                                }
                                break;
                        }
                    }
                    else if (this.CellSetSelect(cellIndex))
                    {
                        int tId = this.UI.Sets[this.UI.View.SetTypeID][cellIndex];
                        string str;
                        if (DatabaseAPI.Database.EnhancementSets[tId].LevelMin == DatabaseAPI.Database.EnhancementSets[tId].LevelMax)
                        {
                            str = " (" + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[tId].LevelMin + 1) + ")";
                        }
                        else
                        {
                            str = string.Concat(new string[]
                            {
                                " (",
                                Conversions.ToString(DatabaseAPI.Database.EnhancementSets[tId].LevelMin + 1),
                                "-",
                                Conversions.ToString(DatabaseAPI.Database.EnhancementSets[tId].LevelMax + 1),
                                ")"
                            });
                        }
                        this.SetInfoStrings(DatabaseAPI.Database.EnhancementSets[tId].DisplayName + str, "Type: " + setTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[tId].SetType]);
                        if ((cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y) || alwaysUpdate)
                        {
                            this.RaiseHoverSet(tId);
                        }
                        hlOk = true;
                    }
                    else if (this.CellEnhSelect(cellIndex))
                    {
                        int tId = 0;
                        switch (this.UI.View.TabID)
                        {
                            case 0:
                                tId = -1;
                                this.SetInfoStrings("", "");
                                break;
                            case Enums.eType.Normal:
                                tId = this.UI.NO[cellIndex];
                                this.SetInfoStrings(DatabaseAPI.Database.Enhancements[tId].Name, DatabaseAPI.Database.Enhancements[tId].Desc);
                                break;
                            case Enums.eType.InventO:
                                tId = this.UI.IO[cellIndex];
                                this.SetInfoStrings(DatabaseAPI.Database.Enhancements[tId].Name, DatabaseAPI.Database.Enhancements[tId].Desc);
                                break;
                            case Enums.eType.SpecialO:
                                tId = this.UI.SpecialO[cellIndex];
                                this.SetInfoStrings(DatabaseAPI.Database.Enhancements[tId].Name, DatabaseAPI.Database.Enhancements[tId].Desc);
                                break;
                            case Enums.eType.SetO:
                                {
                                    tId = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[cellIndex];
                                    string text = DatabaseAPI.Database.Enhancements[tId].Name;
                                    string str2;
                                    if (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[tId].nIDSet].LevelMin == DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[tId].nIDSet].LevelMax)
                                    {
                                        str2 = " (" + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[tId].nIDSet].LevelMin + 1) + ")";
                                    }
                                    else
                                    {
                                        str2 = string.Concat(new string[]
                                        {
                                    " (",
                                    Conversions.ToString(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[tId].nIDSet].LevelMin + 1),
                                    "-",
                                    Conversions.ToString(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[tId].nIDSet].LevelMax + 1),
                                    ")"
                                        });
                                        if (DatabaseAPI.Database.Enhancements[tId].Unique)
                                        {
                                            text += " (Unique)";
                                        }
                                    }
                                    this.SetInfoStrings(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[tId].nIDSet].DisplayName + str2, text);
                                    break;
                                }
                        }
                        if (cell.X != this._hoverCell.X || cell.Y != this._hoverCell.Y || alwaysUpdate)
                        {
                            this.RaiseHoverEnhancement(tId);
                        }
                        hlOk = true;
                    }
                }
                if (!hlOk)
                {
                    cell = new Point(-1, -1);
                }
                if (cell.X != this._hoverCell.X || cell.Y != this._hoverCell.Y)
                {
                    this._hoverCell = cell;
                    this.FullDraw();
                }
            }
        }

        int SetIDGlobalToLocal(int iId)
        {
            checked
            {
                for (int i = 0; i <= this.UI.SetTypes.Length - 1; i++)
                {
                    for (int j = 0; j <= this.UI.Sets[i].Length - 1; j++)
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

        static int[] GetSets(Enums.eSetType iSetType)
        {
            List<int> list = new List<int>();
            int num = 0;
            checked
            {
                int num2 = DatabaseAPI.Database.EnhancementSets.Count - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (DatabaseAPI.Database.EnhancementSets[i].SetType == iSetType)
                        list.Add(i);
                }
                return list.ToArray();
            }
        }

        static int[] GetValidSetTypes(int iPowerIDX)
        {
            if (iPowerIDX < 0)
                return Array<int>.Empty();
            var array = new int[checked(DatabaseAPI.Database.Power[iPowerIDX].SetTypes.Length - 1 + 1)];
            Array.Copy(DatabaseAPI.Database.Power[iPowerIDX].SetTypes, array, DatabaseAPI.Database.Power[iPowerIDX].SetTypes.Length);
            Array.Sort<int>(array);
            return array;
        }

        static int[] GetValidEnhancements(int iPowerIDX, Enums.eType iType, Enums.eSubtype iSubType = 0)
        {
            if (iPowerIDX < 0)
                return Array<int>.Empty();
            return DatabaseAPI.Database.Power[iPowerIDX].GetValidEnhancements(iType, iSubType);
        }

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
            Enums.eSubtype eSubtype = 0;
            this.UI.SpecialTypes = (int[])Enum.GetValues(eSubtype.GetType());
            Enums.eEnhGrade eEnhGrade = 0;
            this.UI.NOGrades = (int[])Enum.GetValues(eEnhGrade.GetType());
            this.UI.NO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.Normal, 0);
            this.UI.IO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.InventO, 0);
            this.UI.Initial.GradeID = this._lastGrade;
            this.UI.Initial.RelLevel = this._lastRelativeLevel;
            this.UI.Initial.SpecialID = this._lastSpecial;
            if (this.UI.Initial.SpecialID == 0)
            {
                this.UI.Initial.SpecialID = Enums.eSubtype.Hamidon;
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
                    this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID);
                    this.UI.Initial.SpecialID = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID;
                }
                else
                {
                    this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, this.UI.Initial.SpecialID);
                }
            }
            else
            {
                this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, this.UI.Initial.SpecialID);
            }
            this.UI.SetTypes = I9Picker.GetValidSetTypes(this._nPowerIDX);
            checked
            {
                this.UI.Sets = new int[this.UI.SetTypes.Length][];
                for (int i = 0; i <= this.UI.SetTypes.Length - 1; i++)
                {
                    this.UI.Sets[i] = I9Picker.GetSets((Enums.eSetType)this.UI.SetTypes[i]);
                }
                if (this._mySlot.Grade != 0)
                    this.UI.Initial.GradeID = this._mySlot.Grade;
                if (this._mySlot.Enh > -1)
                    this.UI.Initial.RelLevel = this._mySlot.RelativeLevel;
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
                        this._mySlot.RelativeLevel = Enums.eEnhRelative.Even;
                    }
                    if (this._nPowerIDX < 0)
                    {
                        switch (DatabaseAPI.Database.Enhancements[this._mySlot.Enh].TypeID)
                        {
                            case Enums.eType.Normal:
                                this.UI.NO = new int[1];
                                this.UI.NO[0] = this._mySlot.Enh;
                                break;
                            case Enums.eType.InventO:
                                this.UI.IO = new int[1];
                                this.UI.IO[0] = this._mySlot.Enh;
                                break;
                            case Enums.eType.SpecialO:
                                this.UI.SpecialO = new int[1];
                                this.UI.SpecialO[0] = this._mySlot.Enh;
                                break;
                            case Enums.eType.SetO:
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
                    if (this.UI.Initial.TabID == Enums.eType.SetO)
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
                    this.UI.Initial.TabID = 0;
                if (this.UI.Initial.TabID == Enums.eType.InventO || this.UI.Initial.TabID == Enums.eType.SetO)
                    this.UI.Initial.IOLevel = this._mySlot.IOLevel + 1;
                else if (this.LastLevel > 0)
                    this.UI.Initial.IOLevel = this.LastLevel;
                else
                    this.UI.Initial.IOLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
                this.UI.View = new I9Picker.cTracking.cLocation(this.UI.Initial);
                if (this.UI.View.TabID == 0)
                {
                    if (this._lastTab != 0)
                        this.UI.View.TabID = this._lastTab;
                    else
                        this.UI.View.TabID = Enums.eType.Normal;
                    if (this.UI.View.TabID == Enums.eType.SetO & this.UI.SetTypes.Length > this._lastSet)
                        this.UI.View.SetTypeID = this._lastSet;
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

        void SetSpecialEnhSet(Enums.eSubtype iSubType)
        {
            this.UI.View.SpecialID = iSubType;
            if (this._nPowerIDX > 0)
                this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, this.UI.View.SpecialID);
            else if (this.UI.Initial.SpecialID == this.UI.View.SpecialID & (int)this.UI.Initial.TabID == 3)
            {
                this.UI.SpecialO = new int[1];
                this.UI.SpecialO[0] = this._mySlot.Enh;
            }
            else
                this.UI.SpecialO = Array<int>.Empty();
        }

        int SetTypeToID(Enums.eSetType iSetType)
        {
            checked
            {
                for (int i = 0; i <= this.UI.SetTypes.Length - 1; i++)
                {
                    if (iSetType == (Enums.eSetType)this.UI.SetTypes[i])
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        int GetPickerIndex(int index, Enums.eType iType)
        {
            int[] array = Array<int>.Empty();
            switch (iType)
            {
                case Enums.eType.Normal:
                    array = this.UI.NO;
                    break;
                case Enums.eType.InventO:
                    array = this.UI.IO;
                    break;
                case Enums.eType.SpecialO:
                    array = this.UI.SpecialO;
                    break;
                case Enums.eType.SetO:
                    array = this.UI.SetO;
                    break;
            }
            checked
            {
                for (int i = 0; i <= array.Length - 1; i++)
                {
                    if (array[i] == index)
                        return i;
                }
                return -1;
            }
        }

        void CheckAndFixIOLevel()
        {
            int ioMax = IOMax;
            int ioMin = 10;
            checked
            {
                if (this.UI.View.TabID == Enums.eType.InventO)
                {
                    if (this.UI.Initial.TabID == this.UI.View.TabID && this.UI.Initial.PickerID == this.UI.View.PickerID && this.UI.View.PickerID > -1)
                    {
                        ioMax = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMax + 1;
                        ioMin = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMin + 1;
                    }
                }
                else if (this.UI.View.TabID == Enums.eType.SetO && (this.UI.View.SetID > -1 && this.UI.View.SetTypeID > -1))
                {
                    var enhSetMax = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMax + 1;
                    ioMax = enhSetMax;
                    var enhSetMin = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMin + 1;
                    ioMin = enhSetMin;
                }
                if (this.UI.View.IOLevel > ioMax)
                    this.UI.View.IOLevel = ioMax;
                if (this.UI.View.IOLevel < ioMin)
                    this.UI.View.IOLevel = ioMin;

                if (this.UI.View.TabID == Enums.eType.InventO)
                {
                    if (ioMax > IOMax)
                        ioMax = IOMax;
                    var nextLevel = Enhancement.GranularLevelZb(this.UI.View.IOLevel - 1, ioMin - 1, ioMax - 1, 5) + 1;
                    this.UI.View.IOLevel = nextLevel;
                }
            }
        }

        public int CheckAndReturnIOLevel()
        {
            int ioMax = IOMax;
            int ioMin = 10;
            int fixedLevel = this.UI.View.IOLevel;
            checked
            {
                if (this.UI.View.TabID == Enums.eType.InventO)
                {
                    if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.PickerID == this.UI.View.PickerID & this.UI.View.PickerID > -1)
                    {
                        ioMax = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMax + 1;
                        ioMin = DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMin + 1;
                    }
                }
                else if (this.UI.View.TabID == Enums.eType.SetO && (this.UI.View.SetID > -1 & this.UI.View.SetTypeID > -1))
                {
                    ioMax = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMax + 1;
                    ioMin = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMin + 1;
                }
                if (fixedLevel > ioMax)
                {
                    fixedLevel = ioMax;
                }
                if (fixedLevel < ioMin)
                {
                    fixedLevel = ioMin;
                }
                if (this.UI.View.TabID == Enums.eType.InventO)
                {
                    if (ioMax > 50)
                    {
                        ioMax = 50;
                    }
                    fixedLevel = Enhancement.GranularLevelZb(fixedLevel - 1, ioMin - 1, ioMax - 1, 5) + 1;
                }
                return fixedLevel;
            }
        }

        void TimerReset()
            => this._timerLastKeypress = -1.0;

        void NumberPressed(int iNumber)
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
                        text = text.Substring(text.Length - 2);

                    int number = (int)Math.Round(Conversion.Val(text));
                    if (number > 50)
                        number = 50;
                    if (number < 1)
                        number = 1;
                    this.UI.View.IOLevel = number;
                    this._userLevel = this.UI.View.IOLevel;
                    if (number >= 10)
                        this.TimerReset();
                }
            }
        }

        void I9PickerKeyDown(object sender, KeyEventArgs e)
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
                    this.DoEnhancementPicked(this.UI.View.PickerID);
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
                    this.UI.View.RelLevel = Enums.eEnhRelative.MinusThree;
                    this.TimerReset();
                }
                else if (keyCode == Keys.End)
                {
                    this.UI.View.IOLevel = 100;
                    this.UI.View.RelLevel = Enums.eEnhRelative.PlusFive;
                    this.TimerReset();
                }
                else if (keyCode == Keys.Space)
                {
                    this.UI.View.IOLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
                    this.UI.View.RelLevel = Enums.eEnhRelative.Even;
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
                //if (this.UI.View.TabID == Enums.eType.SetO || this.UI.View.TabID ==Enums.eType.InventO)
                if (this.UI.View.TabID == Enums.eType.SetO || this.UI.View.TabID == Enums.eType.InventO)
                {
                    if (num > -1)
                        this.NumberPressed(num);
                    else
                        this.CheckAndFixIOLevel();
                }
                this.DoHover(this._hoverCell, true);
                this.FullDraw();
            }
        }

        void RelAdjust(int direction)
        {
            Enums.eEnhRelative eEnhRelative = this.UI.View.RelLevel;
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
                if (eEnhRelative > Enums.eEnhRelative.PlusThree & (this.UI.View.TabID == Enums.eType.Normal | (int)this.UI.View.TabID == 3))
                {
                    eEnhRelative = Enums.eEnhRelative.PlusThree;
                }
                else if (eEnhRelative < Enums.eEnhRelative.Even & (this.UI.View.TabID == Enums.eType.InventO | this.UI.View.TabID == Enums.eType.SetO))
                {
                    eEnhRelative = Enums.eEnhRelative.Even;
                }
                this.UI.View.RelLevel = eEnhRelative;
            }
        }

        public class cTracking
        {
            public cTracking()
            {
                this.NO = Array<int>.Empty();
                this.IO = Array<int>.Empty();
                this.SpecialO = Array<int>.Empty();
                this.NOGrades = Array<int>.Empty();
                this.SpecialTypes = Array<int>.Empty();
                this.SetTypes = Array<int>.Empty();
                this.Sets = Array<int[]>.Empty();
                this.SetO = Array<int>.Empty();
                this.Initial = new I9Picker.cTracking.cLocation();
                this.View = new I9Picker.cTracking.cLocation();
            }

            public int[] NO;
            public int[] IO;
            public int[] SpecialO;
            public int[] NOGrades;
            public int[] SpecialTypes;
            public int[] SetTypes;
            public int[][] Sets;
            public int[] SetO;
            public readonly I9Picker.cTracking.cLocation Initial;
            public I9Picker.cTracking.cLocation View;

            public class cLocation
            {
                public cLocation()
                {
                    this.TabID = 0;
                    this.PickerID = -1;
                    this.SetTypeID = -1;
                    this.SetID = -1;
                    this.GradeID = 0;
                    this.SpecialID = 0;
                    this.IOLevel = 0;
                    this.RelLevel = Enums.eEnhRelative.Even;
                }

                public cLocation(I9Picker.cTracking.cLocation iCL)
                {
                    this.TabID = 0;
                    this.PickerID = -1;
                    this.SetTypeID = -1;
                    this.SetID = -1;
                    this.GradeID = 0;
                    this.SpecialID = 0;
                    this.IOLevel = 0;
                    this.RelLevel = Enums.eEnhRelative.Even;
                    this.TabID = iCL.TabID;
                    this.PickerID = iCL.PickerID;
                    this.SetTypeID = iCL.SetTypeID;
                    this.GradeID = iCL.GradeID;
                    this.SpecialID = iCL.SpecialID;
                    this.SetID = iCL.SetID;
                    this.IOLevel = iCL.IOLevel;
                    this.RelLevel = iCL.RelLevel;
                }

                public Enums.eType TabID;
                public int PickerID;
                public int SetTypeID;
                public int SetID;
                public Enums.eEnhGrade GradeID;
                public Enums.eSubtype SpecialID;
                public int IOLevel;
                public Enums.eEnhRelative RelLevel;
            }
        }

        public delegate void EnhancementPickedEventHandler(I9Slot e);
        public delegate void HoverEnhancementEventHandler(int e);
        public delegate void HoverSetEventHandler(int e);
        public delegate void MovedEventHandler(Rectangle oldBounds, Rectangle newBounds);
    }
}
