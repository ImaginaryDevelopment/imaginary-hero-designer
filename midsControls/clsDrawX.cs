using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using Base.Display;
using Base.Master_Classes;
using HeroDesigner.Schema;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    // Token: 0x0200000A RID: 10
    public class clsDrawX
    {
        // Token: 0x1700000A RID: 10
        // (get) Token: 0x0600001B RID: 27 RVA: 0x000022E0 File Offset: 0x000004E0
        public bool EpicColumns
        {
            get
            {
                return MidsContext.Character != null && MidsContext.Character.Archetype != null && MidsContext.Character.Archetype.ClassType == eClassType.HeroEpic;
            }
        }

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x0600001C RID: 28 RVA: 0x0000231C File Offset: 0x0000051C
        public bool Scaling
        {
            get
            {
                return this.ScaleEnabled;
            }
        }

        // Token: 0x1700000C RID: 12
        // (set) Token: 0x0600001D RID: 29 RVA: 0x00002334 File Offset: 0x00000534
        public int Columns
        {
            set
            {
                this.MiniSetCol(value);
                this.Blank();
                this.szBuffer = this.GetRequiredDrawingArea();
                this.SetScaling(this.cTarget.Size);
            }
        }

        // Token: 0x1700000D RID: 13
        // (set) Token: 0x0600001E RID: 30 RVA: 0x00002364 File Offset: 0x00000564
        private int InitColumns
        {
            set
            {
                if (value != this.vcCols)
                {
                    if (!(value < 2 | value > 4))
                    {
                        this.vcCols = value;
                        this.vcRowsPowers = checked((int)Math.Round(24.0 / (double)this.vcCols));
                    }
                }
            }
        }

        // Token: 0x0600001F RID: 31 RVA: 0x000023BC File Offset: 0x000005BC
        public void ReInit(ref Control iTarget)
        {
            this.gTarget = iTarget.CreateGraphics();
            this.cTarget = iTarget;
            this.DefaultFont = new Font(iTarget.Font.FontFamily, iTarget.Font.Size, FontStyle.Bold, iTarget.Font.Unit);
            this.BackColor = iTarget.BackColor;
        }

        // Token: 0x06000020 RID: 32 RVA: 0x0000241C File Offset: 0x0000061C
        public clsDrawX(ref Control iTarget)
        {
            this.InterfaceMode = 0;
            this.VillainColor = false;
            this.ScaleValue = 1f;
            this.ScaleEnabled = false;
            this.vcCols = 3;
            this.vcRowsPowers = 8;
            this.bxPower = new ExtendedBitmap[4];
            int num = 0;
            checked
            {
                int num2 = this.bxPower.Length - 1;
                for (int i = num; i <= num2; i++)
                {
                    this.bxPower[i] = new ExtendedBitmap(FileIO.AddSlash(Application.StartupPath) + "images\\pSlot" + Strings.Trim(Conversions.ToString(i)) + ".png");
                }
                this.ColourSwitch();
                this.InitColumns = MidsContext.Config.Columns;
                this.szPower = this.bxPower[0].Size;
                this.szSlot = new Size(30, 30);
                this.szBuffer = this.GetMaxDrawingArea();
                Size size = new Size(this.szBuffer.Width, this.szBuffer.Height);
                this.bxBuffer = new ExtendedBitmap(size);
                this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                this.szBuffer = this.GetRequiredDrawingArea();
                this.bxNewSlot = new ExtendedBitmap(FileIO.AddSlash(Application.StartupPath) + "images\\Addslot.png");
                this.gTarget = iTarget.CreateGraphics();
                this.cTarget = iTarget;
                this.gTarget.CompositingMode = CompositingMode.SourceCopy;
                this.gTarget.CompositingQuality = CompositingQuality.HighSpeed;
                this.gTarget.InterpolationMode = InterpolationMode.NearestNeighbor;
                this.gTarget.SmoothingMode = SmoothingMode.None;
                this.DefaultFont = new Font(iTarget.Font.FontFamily, iTarget.Font.Size, FontStyle.Bold, iTarget.Font.Unit);
                this.BackColor = iTarget.BackColor;
                if (this.szBuffer.Height < this.cTarget.Height)
                {
                    this.gTarget.FillRectangle(new SolidBrush(this.BackColor), 0, this.szBuffer.Height, this.cTarget.Width, this.cTarget.Height - this.szBuffer.Height);
                }
            }
        }

        // Token: 0x06000021 RID: 33 RVA: 0x00002660 File Offset: 0x00000860
        private void DrawSplit()
        {
            Pen pen;
            if (this.VillainColor)
            {
                pen = new Pen(Color.Maroon, 2f);
            }
            else
            {
                pen = new Pen(Color.Blue, 2f);
            }
            checked
            {
                int iValue = 4 + this.vcRowsPowers * (this.szPower.Height + 17) - 4;
                this.bxBuffer.Graphics.DrawLine(pen, 0, this.ScaleDown(iValue), this.ScaleDown(this.PowerPosition(15).X + this.szPower.Width + 7), this.ScaleDown(iValue));
            }
        }

        // Token: 0x06000022 RID: 34 RVA: 0x00002704 File Offset: 0x00000904
        private void DrawPowers()
        {
            int num = 0;
            checked
            {
                int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (MidsContext.Character.CanPlaceSlot & this.Highlight == i)
                    {
                        Build currentBuild = MidsContext.Character.CurrentBuild;
                        List<PowerEntry> powers = currentBuild.Powers;
                        int index = i;
                        PowerEntry value = powers[index];
                        this.DrawPowerSlot(ref value, true);
                        currentBuild.Powers[index] = value;
                    }
                    else if (MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                    {
                        Build currentBuild = MidsContext.Character.CurrentBuild;
                        List<PowerEntry> powers2 = currentBuild.Powers;
                        int index = i;
                        PowerEntry value = powers2[index];
                        this.DrawPowerSlot(ref value, false);
                        currentBuild.Powers[index] = value;
                    }
                    else if (MidsContext.Character.CurrentBuild.Powers[i].Power != null && (Operators.CompareString(MidsContext.Character.CurrentBuild.Powers[i].Power.GroupName, "Incarnate", false) == 0 | MidsContext.Character.CurrentBuild.Powers[i].Power.IncludeFlag))
                    {
                        Build currentBuild = MidsContext.Character.CurrentBuild;
                        List<PowerEntry> powers3 = currentBuild.Powers;
                        int index = i;
                        PowerEntry value = powers3[index];
                        this.DrawPowerSlot(ref value, false);
                        currentBuild.Powers[index] = value;
                    }
                }
                Application.DoEvents();
                this.DrawSplit();
            }
        }

        // Token: 0x06000023 RID: 35 RVA: 0x000028D0 File Offset: 0x00000AD0
        private float FontScale(float iSZ)
        {
            float num = this.ScaleDown(iSZ);
            num = (float)((double)num * 1.1);
            if (num > iSZ)
            {
                num = iSZ;
            }
            return num;
        }

        // Token: 0x06000024 RID: 36 RVA: 0x00002908 File Offset: 0x00000B08
        private static int IndexFromLevel()
        {
            int num = 0;
            int lastPower = MidsContext.Character.CurrentBuild.LastPower;
            checked
            {
                for (int i = num; i <= lastPower; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].Level == MidsContext.Character.RequestedLevel)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        // Token: 0x06000025 RID: 37 RVA: 0x0000297C File Offset: 0x00000B7C
        public Point DrawPowerSlot(ref PowerEntry iSlot, bool SingleDraw = false)
        {
            Pen pen = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
            string text = string.Empty;
            string text2 = string.Empty;
            RectangleF rectangleF = new RectangleF(0f, 0f, 0f, 0f);
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
            stringFormat.Trimming = StringTrimming.None;
            Pen pen2 = new Pen(Color.Black);
            Rectangle rectangle = default(Rectangle);
            Font font = new Font(this.DefaultFont.FontFamily, this.FontScale(this.DefaultFont.SizeInPoints), this.DefaultFont.Style, GraphicsUnit.Point);
            int num = MidsContext.Character.SlotCheck(iSlot);
            bool flag = this.InterfaceMode == eInterfaceMode.PowerToggle;
            bool flag2 = false;
            ePowerState ePowerState = iSlot.State;
            bool canPlaceSlot = MidsContext.Character.CanPlaceSlot;
            bool flag3 = iSlot.Power != null;
            if (flag3)
            {
                flag3 = ((((iSlot.State != ePowerState.Empty && canPlaceSlot) & iSlot.Slots.Length < 6) && SingleDraw) & iSlot.Power.Slottable & this.InterfaceMode != eInterfaceMode.PowerToggle);
            }
            Point result = this.PowerPosition(iSlot, -1);
            Point point = default(Point);
            checked
            {
                point.X = (int)Math.Round(unchecked((double)result.X + (double)(checked(this.szPower.Width - this.szSlot.Width * 6)) / 2.0));
                point.Y = result.Y + 18;
                Graphics graphics = this.bxBuffer.Graphics;
                Brush brush = new SolidBrush(this.BackColor);
                Rectangle clipRect = new Rectangle(point.X, point.Y, this.szPower.Width, this.szPower.Height);
                graphics.FillRectangle(brush, this.ScaleDown(clipRect));
                if (!flag)
                {
                    if (iSlot.Power != null)
                    {
                        if (((SingleDraw & num > -1) && canPlaceSlot) & this.InterfaceMode != eInterfaceMode.PowerToggle & iSlot.PowerSet != null & iSlot.Slots.Length < 6 & iSlot.Power.Slottable)
                        {
                            ePowerState = ePowerState.Open;
                        }
                        else if (iSlot.Chosen & !canPlaceSlot & this.InterfaceMode != eInterfaceMode.PowerToggle & this.Highlight == MidsContext.Character.CurrentBuild.Powers.IndexOf(iSlot))
                        {
                            ePowerState = ePowerState.Open;
                        }
                    }
                    else if (MidsContext.Character.CurrentBuild.Powers.IndexOf(iSlot) == clsDrawX.IndexFromLevel())
                    {
                        ePowerState = ePowerState.Open;
                    }
                }
                rectangleF.Height = (float)this.szSlot.Height;
                rectangleF.Width = (float)this.szSlot.Width;
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                bool grey;
                ImageAttributes imageAttr;
                if (flag)
                {
                    if (ePowerState == ePowerState.Open)
                    {
                        ePowerState = ePowerState.Empty;
                    }
                    if (iSlot.StatInclude & ePowerState == ePowerState.Used)
                    {
                        ePowerState = ePowerState.Open;
                        grey = (iSlot.Level >= MidsContext.Config.ForceLevel);
                        imageAttr = this.GreySlot(grey, true);
                    }
                    else if (iSlot.CanIncludeForStats())
                    {
                        grey = (iSlot.Level >= MidsContext.Config.ForceLevel);
                        imageAttr = this.GreySlot(grey, false);
                    }
                    else
                    {
                        imageAttr = this.GreySlot(true, false);
                        grey = true;
                    }
                }
                else
                {
                    flag2 = true;
                    grey = (iSlot.Level >= MidsContext.Config.ForceLevel);
                    imageAttr = this.GreySlot(grey, false);
                }
                Rectangle iValue = new Rectangle(result.X, result.Y, this.bxPower[(int)ePowerState].Size.Width, this.bxPower[(int)ePowerState].Size.Height);
                if (ePowerState == ePowerState.Used || flag)
                {
                    if (MidsContext.Config.DesaturateInherent & !iSlot.Chosen)
                    {
                        imageAttr = this.Desaturate(grey, ePowerState == ePowerState.Open);
                    }
                    Graphics graphics2 = this.bxBuffer.Graphics;
                    Image bitmap = this.bxPower[(int)ePowerState].Bitmap;
                    Rectangle destRect = this.ScaleDown(iValue);
                    int srcX = 0;
                    int srcY = 0;
                    int width = this.bxPower[(int)ePowerState].ClipRect.Width;
                    Rectangle clipRect2 = this.bxPower[(int)ePowerState].ClipRect;
                    graphics2.DrawImage(bitmap, destRect, srcX, srcY, width, clipRect2.Height, GraphicsUnit.Pixel, imageAttr);
                }
                else
                {
                    Graphics graphics3 = this.bxBuffer.Graphics;
                    Image bitmap2 = this.bxPower[(int)ePowerState].Bitmap;
                    Rectangle destRect2 = this.ScaleDown(iValue);
                    int srcX2 = 0;
                    int srcY2 = 0;
                    int width2 = this.bxPower[(int)ePowerState].ClipRect.Width;
                    clipRect = this.bxPower[(int)ePowerState].ClipRect;
                    graphics3.DrawImage(bitmap2, destRect2, srcX2, srcY2, width2, clipRect.Height, GraphicsUnit.Pixel);
                }
                if ((flag2 || flag) & iSlot.CanIncludeForStats())
                {
                    rectangle.Height = 15;
                    rectangle.Width = rectangle.Height;
                    rectangle.Y = (int)Math.Round(unchecked((double)iValue.Top + (double)(checked(iValue.Height - rectangle.Height)) / 2.0));
                    rectangle.X = (int)Math.Round(unchecked((double)iValue.Right - ((double)rectangle.Width + (double)(checked(iValue.Height - rectangle.Height)) / 2.0)));
                    rectangle = this.ScaleDown(rectangle);
                    PathGradientBrush brush2;
                    if (iSlot.StatInclude)
                    {
                        Rectangle iRect = rectangle;
                        PointF iCenter = new PointF(-0.25f, -0.33f);
                        brush2 = this.MakePathBrush(iRect, iCenter, Color.FromArgb(96, 255, 96), Color.FromArgb(0, 32, 0));
                    }
                    else
                    {
                        Rectangle iRect2 = rectangle;
                        PointF iCenter = new PointF(-0.25f, -0.33f);
                        brush2 = this.MakePathBrush(iRect2, iCenter, Color.FromArgb(96, 96, 96), Color.FromArgb(0, 0, 0));
                    }
                    this.bxBuffer.Graphics.FillEllipse(brush2, rectangle);
                    this.bxBuffer.Graphics.DrawEllipse(pen2, rectangle);
                }
                int num2 = 0;
                int num3 = iSlot.Slots.Length - 1;
                int i;
                SolidBrush solidBrush;
                for (i = num2; i <= num3; i++)
                {
                    rectangleF.X = (float)(point.X + this.szSlot.Width * i);
                    rectangleF.Y = (float)point.Y;
                    if (iSlot.Slots[i].Enhancement.Enh < 0)
                    {
                        Graphics graphics4 = this.bxBuffer.Graphics;
                        Image bitmap3 = I9Gfx.EnhTypes.Bitmap;
                        Rectangle clipRect2 = new Rectangle((int)Math.Round((double)rectangleF.X), point.Y, 30, 30);
                        graphics4.DrawImage(bitmap3, this.ScaleDown(clipRect2), 0, 0, 30, 30, GraphicsUnit.Pixel, this.pImageAttributes);
                        if (MidsContext.Config.CalcEnhLevel == 0 | iSlot.Slots[i].Level >= MidsContext.Config.ForceLevel | (this.InterfaceMode == eInterfaceMode.PowerToggle & !iSlot.StatInclude) | (!iSlot.AllowFrontLoading & iSlot.Slots[i].Level < iSlot.Level))
                        {
                            solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                            this.bxBuffer.Graphics.FillEllipse(solidBrush, this.ScaleDown(rectangleF));
                            this.bxBuffer.Graphics.DrawEllipse(pen, this.ScaleDown(rectangleF));
                        }
                    }
                    else
                    {
                        IEnhancement enhancement = DatabaseAPI.Database.Enhancements[iSlot.Slots[i].Enhancement.Enh];
                        Graphics graphics5 = this.bxBuffer.Graphics;
                        Rectangle clipRect2 = new Rectangle((int)Math.Round((double)rectangleF.X), point.Y, 30, 30);
                        I9Gfx.DrawEnhancementAt(ref graphics5, this.ScaleDown(clipRect2), enhancement.ImageIdx, I9Gfx.ToGfxGrade(enhancement.TypeID, iSlot.Slots[i].Enhancement.Grade));
                        if (iSlot.Slots[i].Enhancement.RelativeLevel == 0 | iSlot.Slots[i].Level >= MidsContext.Config.ForceLevel | (this.InterfaceMode == eInterfaceMode.PowerToggle & !iSlot.StatInclude) | (!iSlot.AllowFrontLoading & iSlot.Slots[i].Level < iSlot.Level))
                        {
                            solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                            RectangleF iValue2 = rectangleF;
                            iValue2.Inflate(1f, 1f);
                            this.bxBuffer.Graphics.FillEllipse(solidBrush, this.ScaleDown(iValue2));
                        }
                        unchecked
                        {
                            if (iSlot.Slots[i].Enhancement.Enh > -1)
                            {
                                if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[iSlot.Slots[i].Enhancement.Enh].TypeID == eType.SetO
                                    | DatabaseAPI.Database.Enhancements[iSlot.Slots[i].Enhancement.Enh].TypeID == eType.InventO))
                                {
                                    RectangleF iValue2 = rectangleF;
                                    iValue2.Y -= 3f;
                                    iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                                    string iStr = Conversions.ToString(checked(iSlot.Slots[i].Enhancement.IOLevel + 1));
                                    RectangleF bounds = this.ScaleDown(iValue2);
                                    Color cyan = Color.Cyan;
                                    Color outline = Color.FromArgb(128, 0, 0, 0);
                                    Font bFont = font;
                                    float outlineSpace = 1f;
                                    graphics5 = this.bxBuffer.Graphics;
                                    clsDrawX.DrawOutlineText(iStr, bounds, cyan, outline, bFont, outlineSpace, ref graphics5, false, false);
                                }
                                else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[iSlot.Slots[i].Enhancement.Enh].TypeID == eType.Normal
                                    | DatabaseAPI.Database.Enhancements[iSlot.Slots[i].Enhancement.Enh].TypeID == eType.SpecialO))
                                {
                                    RectangleF iValue2 = rectangleF;
                                    iValue2.Y -= 3f;
                                    iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                                    Color color;
                                    if (iSlot.Slots[i].Enhancement.RelativeLevel == 0)
                                    {
                                        color = Color.Red;
                                    }
                                    else if (iSlot.Slots[i].Enhancement.RelativeLevel < eEnhRelative.Even)
                                    {
                                        color = Color.Yellow;
                                    }
                                    else if (iSlot.Slots[i].Enhancement.RelativeLevel > eEnhRelative.Even)
                                    {
                                        color = Color.FromArgb(0, 255, 255);
                                    }
                                    else
                                    {
                                        color = Color.White;
                                    }
                                    string relativeString = Enums.GetRelativeString(iSlot.Slots[i].Enhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols);
                                    RectangleF bounds2 = this.ScaleDown(iValue2);
                                    Color text3 = color;
                                    Color outline2 = Color.FromArgb(128, 0, 0, 0);
                                    Font bFont2 = font;
                                    float outlineSpace2 = 1f;
                                    graphics5 = this.bxBuffer.Graphics;
                                    clsDrawX.DrawOutlineText(relativeString, bounds2, text3, outline2, bFont2, outlineSpace2, ref graphics5, false, false);
                                }
                            }
                        }
                    }
                    if (MidsContext.Config.ShowSlotLevels)
                    {
                        RectangleF iValue2 = rectangleF;
                        unchecked
                        {
                            iValue2.Y += iValue2.Height;
                            iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                            iValue2.Y -= iValue2.Height;
                        }
                        string iStr2 = Conversions.ToString(iSlot.Slots[i].Level + 1);
                        RectangleF bounds3 = this.ScaleDown(iValue2);
                        Color text4 = Color.FromArgb(0, 255, 0);
                        Color outline3 = Color.FromArgb(192, 0, 0, 0);
                        Font bFont3 = font;
                        float outlineSpace3 = 1f;
                        Graphics graphics5 = this.bxBuffer.Graphics;
                        clsDrawX.DrawOutlineText(iStr2, bounds3, text4, outline3, bFont3, outlineSpace3, ref graphics5, false, false);
                    }
                }
                if (num > -1 && (ePowerState != ePowerState.Empty && flag3))
                {
                    Rectangle clipRect2 = new Rectangle(point.X + this.szSlot.Width * i, point.Y, this.szSlot.Width, this.szSlot.Height);
                    RectangleF iValue2 = clipRect2;
                    this.bxBuffer.Graphics.DrawImage(this.bxNewSlot.Bitmap, this.ScaleDown(iValue2));
                    iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                    unchecked
                    {
                        iValue2.Y += ((float)this.szSlot.Height - iValue2.Height) / 2f;
                    }
                    string iStr3 = Conversions.ToString(num + 1);
                    RectangleF bounds4 = this.ScaleDown(iValue2);
                    Color text5 = Color.FromArgb(0, 255, 255);
                    Color outline4 = Color.FromArgb(192, 0, 0, 0);
                    Font bFont4 = font;
                    float outlineSpace4 = 1f;
                    Graphics graphics5 = this.bxBuffer.Graphics;
                    clsDrawX.DrawOutlineText(iStr3, bounds4, text5, outline4, bFont4, outlineSpace4, ref graphics5, false, false);
                }
                solidBrush = new SolidBrush(Color.Black);
                stringFormat = new StringFormat();
                rectangleF.X = (float)(result.X + 10);
                rectangleF.Y = (float)(result.Y + 4);
                rectangleF.Width = (float)this.szPower.Width;
                rectangleF.Height = unchecked(this.DefaultFont.GetHeight() * 2f);
                ePowerState ePowerState2 = iSlot.State;
                if (ePowerState2 == ePowerState.Empty & ePowerState == ePowerState.Open)
                {
                    ePowerState2 = ePowerState;
                }
                switch (ePowerState2)
                {
                    case 0:
                        solidBrush = new SolidBrush(Color.Transparent);
                        text = "";
                        break;
                    case ePowerState.Empty:
                        solidBrush = new SolidBrush(Color.WhiteSmoke);
                        text = "(" + Conversions.ToString(iSlot.Level + 1) + ")";
                        break;
                    case ePowerState.Used:
                        switch (iSlot.PowerSet.SetType)
                        {
                            case ePowerSetType.Primary:
                                text2 = "(Pri)";
                                break;
                            case ePowerSetType.Secondary:
                                text2 = "(Sec)";
                                break;
                            case ePowerSetType.Ancillary:
                                text2 = "(Ancil)";
                                break;
                            case ePowerSetType.Inherent:
                                text2 = "";
                                break;
                            case ePowerSetType.Pool:
                                text2 = "(Pool)";
                                break;
                        }
                        solidBrush = new SolidBrush(Color.Black);
                        if (iSlot.Virtual)
                        {
                            text = iSlot.Name;
                        }
                        else
                        {
                            text = string.Concat(new string[]
                            {
                            "(",
                            Conversions.ToString(iSlot.Level + 1),
                            ") ",
                            iSlot.Name,
                            " ",
                            text2
                            });
                        }
                        break;
                    case ePowerState.Open:
                        solidBrush = new SolidBrush(Color.Yellow);
                        text = "(" + Conversions.ToString(iSlot.Level + 1) + ")";
                        break;
                }
                if (ePowerState == ePowerState.Empty & iSlot.State == ePowerState.Used)
                {
                    solidBrush = new SolidBrush(Color.WhiteSmoke);
                }
                if (this.InterfaceMode == eInterfaceMode.PowerToggle && solidBrush.Color == Color.Black && !iSlot.CanIncludeForStats())
                {
                    solidBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
                }
                stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
                if (MidsContext.Config.EnhanceVisibility)
                {
                    string iStr4 = text;
                    RectangleF bounds5 = this.ScaleDown(rectangleF);
                    Color whiteSmoke = Color.WhiteSmoke;
                    Color outline5 = Color.FromArgb(192, 0, 0, 0);
                    Font bFont5 = font;
                    float outlineSpace5 = 1f;
                    Graphics graphics5 = this.bxBuffer.Graphics;
                    clsDrawX.DrawOutlineText(iStr4, bounds5, whiteSmoke, outline5, bFont5, outlineSpace5, ref graphics5, false, true);
                }
                else
                {
                    this.bxBuffer.Graphics.DrawString(text, font, solidBrush, this.ScaleDown(rectangleF), stringFormat);
                }
                return result;
            }
        }

        // Token: 0x06000026 RID: 38 RVA: 0x00003B38 File Offset: 0x00001D38
        private PathGradientBrush MakePathBrush(Rectangle iRect, PointF iCenter, Color iColor1, Color icolor2)
        {
            float num = (float)((double)iRect.Left + (double)iRect.Width * 0.5);
            float num2 = (float)((double)iRect.Top + (double)iRect.Height * 0.5);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(iRect);
            PathGradientBrush pathGradientBrush;
            PathGradientBrush pathGradientBrush2;
            checked
            {
                Color[] array = new Color[graphicsPath.PathPoints.GetUpperBound(0) + 1];
                int lowerBound = graphicsPath.PathPoints.GetLowerBound(0);
                int upperBound = graphicsPath.PathPoints.GetUpperBound(0);
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    array[i] = icolor2;
                }
                pathGradientBrush = new PathGradientBrush(graphicsPath);
                pathGradientBrush.CenterColor = iColor1;
                pathGradientBrush.SurroundColors = array;
                pathGradientBrush2 = pathGradientBrush;
            }
            PointF centerPoint = new PointF((float)((double)num + ((double)iCenter.X + (double)iCenter.X * ((double)iRect.Width * 0.5))), (float)((double)num2 + ((double)iCenter.Y + (double)iCenter.Y * ((double)iRect.Height * 0.5))));
            pathGradientBrush2.CenterPoint = centerPoint;
            return pathGradientBrush;
        }

        // Token: 0x06000027 RID: 39 RVA: 0x00003C74 File Offset: 0x00001E74
        public void FullRedraw()
        {
            this.ColourSwitch();
            this.BackColor = this.cTarget.BackColor;
            this.bxBuffer.Graphics.Clear(this.BackColor);
            this.DrawPowers();
            Point location = new Point(0, 0);
            this.OutputUnscaled(ref this.bxBuffer, location);
            GC.Collect();
        }

        // Token: 0x06000028 RID: 40 RVA: 0x00003CD6 File Offset: 0x00001ED6
        public void Refresh(Rectangle Clip)
        {
            this.OutputRefresh(Clip, Clip, GraphicsUnit.Pixel);
        }

        // Token: 0x06000029 RID: 41 RVA: 0x00003CE4 File Offset: 0x00001EE4
        private int GetVisualIDX(int PowerIndex)
        {
            int nidpowerset = MidsContext.Character.CurrentBuild.Powers[PowerIndex].NIDPowerset;
            int idxpower = MidsContext.Character.CurrentBuild.Powers[PowerIndex].IDXPower;
            checked
            {
                int num;
                if (nidpowerset > -1)
                {
                    if (DatabaseAPI.Database.Powersets[nidpowerset].SetType == ePowerSetType.Inherent)
                    {
                        num = DatabaseAPI.Database.Powersets[nidpowerset].Powers[idxpower].LocationIndex;
                    }
                    else
                    {
                        num = -1;
                        for (int i = 0; i <= PowerIndex; i++)
                        {
                            if (MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset > -1)
                            {
                                if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset].SetType != ePowerSetType.Inherent)
                                {
                                    num++;
                                }
                            }
                            else
                            {
                                num++;
                            }
                        }
                    }
                }
                else
                {
                    num = -1;
                    for (int i = 0; i <= PowerIndex; i++)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset > -1)
                        {
                            if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset].SetType != ePowerSetType.Inherent)
                            {
                                num++;
                            }
                        }
                        else
                        {
                            num++;
                        }
                    }
                }
                return num;
            }
        }

        // Token: 0x0600002A RID: 42 RVA: 0x00003E8C File Offset: 0x0000208C
        public static void DrawOutlineText(string iStr, RectangleF Bounds, Color Text, Color Outline, Font bFont, float OutlineSpace, ref Graphics Target, bool SmallMode = false, bool LeftAlign = false)
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

        // Token: 0x0600002B RID: 43 RVA: 0x00004068 File Offset: 0x00002268
        public int WhichSlot(int iX, int iY)
        {
            int num = 0;
            checked
            {
                int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int i = num; i <= num2; i++)
                {
                    Point point;
                    if (MidsContext.Character.CurrentBuild.Powers[i].Power == null | MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                    {
                        point = this.PowerPosition(this.GetVisualIDX(i));
                    }
                    else
                    {
                        point = this.PowerPosition(i);
                    }
                    if ((iX >= point.X & iY >= point.Y) && (iX < this.szPower.Width + point.X & iY < point.Y + this.szPower.Height + 17))
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        // Token: 0x0600002C RID: 44 RVA: 0x00004174 File Offset: 0x00002374
        public int WhichEnh(int iX, int iY)
        {
            int result = -1;
            int num = -1;
            int num2 = 0;
            checked
            {
                int num3 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                Point point = default(Point);
                for (int i = num2; i <= num3; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].Power == null | MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                    {
                        point = this.PowerPosition(this.GetVisualIDX(i));
                    }
                    else
                    {
                        point = this.PowerPosition(i);
                    }
                    if ((iX >= point.X & iY >= point.Y) && (iX < this.szPower.Width + point.X & iY < point.Y + this.szPower.Height + 17))
                    {
                        num = i;
                        break;
                    }
                }
                if (num > -1)
                {
                    bool flag = false;
                    if (iY >= point.Y + 18)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[num].NIDPowerset > -1)
                        {
                            if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[num].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[num].IDXPower].Slottable)
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        int num4 = MidsContext.Character.CurrentBuild.Powers[num].Slots.Length;
                        iX = (int)Math.Round(unchecked((double)iX - ((double)point.X + (double)(checked(this.szPower.Width - this.szSlot.Width * 6)) / 2.0)));
                        int num5 = 0;
                        int num6 = num4 - 1;
                        for (int i = num5; i <= num6; i++)
                        {
                            if (iX <= (i + 1) * this.szSlot.Width)
                            {
                                result = i;
                                break;
                            }
                        }
                        return result;
                    }
                    result = -1;
                }
                return result;
            }
        }

        // Token: 0x0600002D RID: 45 RVA: 0x000043F8 File Offset: 0x000025F8
        public bool HighlightSlot(int Index, bool Force = false)
        {
            checked
            {
                bool result;
                if (MidsContext.Character.CurrentBuild.Powers.Count < 1)
                {
                    result = false;
                }
                else
                {
                    if (this.Highlight != Index || Force)
                    {
                        if (Index != -1)
                        {
                            Build currentBuild;
                            PowerEntry value;
                            Point point2;
                            Rectangle iValue;
                            Rectangle rectangle;
                            if (this.Highlight != -1 && this.Highlight < MidsContext.Character.CurrentBuild.Powers.Count)
                            {
                                currentBuild = MidsContext.Character.CurrentBuild;
                                List<PowerEntry> powers = currentBuild.Powers;
                                int highlight = this.Highlight;
                                value = powers[highlight];
                                Point point = this.DrawPowerSlot(ref value, false);
                                currentBuild.Powers[highlight] = value;
                                point2 = point;
                                iValue = new Rectangle(point2.X, point2.Y, this.szPower.Width, this.szPower.Height + 17);
                                rectangle = this.ScaleDown(iValue);
                                this.DrawSplit();
                                this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
                            }
                            this.Highlight = Index;
                            currentBuild = MidsContext.Character.CurrentBuild;
                            value = currentBuild.Powers[Index];
                            Point point3 = this.DrawPowerSlot(ref value, true);
                            currentBuild.Powers[Index] = value;
                            point2 = point3;
                            iValue = new Rectangle(point2.X, point2.Y, this.szPower.Width, this.szPower.Height + 17);
                            rectangle = this.ScaleDown(iValue);
                            this.DrawSplit();
                            this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
                        }
                        else if (this.Highlight != -1)
                        {
                            Build currentBuild = MidsContext.Character.CurrentBuild;
                            List<PowerEntry> powers2 = currentBuild.Powers;
                            int highlight = this.Highlight;
                            PowerEntry value = powers2[highlight];
                            Point point4 = this.DrawPowerSlot(ref value, false);
                            currentBuild.Powers[highlight] = value;
                            Point point2 = point4;
                            Rectangle iValue = new Rectangle(point2.X, point2.Y, this.szPower.Width, this.szPower.Height + 17);
                            Rectangle rectangle = this.ScaleDown(iValue);
                            this.DrawSplit();
                            this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
                            this.Highlight = Index;
                        }
                    }
                    result = false;
                }
                return result;
            }
        }

        // Token: 0x0600002E RID: 46 RVA: 0x0000466C File Offset: 0x0000286C
        private void Blank()
        {
            if (this.bxBuffer != null)
            {
                this.bxBuffer.Graphics.Clear(this.BackColor);
            }
        }

        // Token: 0x0600002F RID: 47 RVA: 0x000046A0 File Offset: 0x000028A0
        public void SetScaling(Size iSize)
        {
            bool scaleEnabled = this.ScaleEnabled;
            float scaleValue = this.ScaleValue;
            if (!(iSize.Width < 10 | iSize.Height < 10))
            {
                Size drawingArea = this.GetDrawingArea();
                if (drawingArea.Width > iSize.Width | drawingArea.Height > iSize.Height)
                {
                    this.ScaleEnabled = true;
                    if ((double)drawingArea.Width / (double)iSize.Width > (double)drawingArea.Height / (double)iSize.Height)
                    {
                        this.ScaleValue = (float)((double)drawingArea.Width / (double)iSize.Width);
                    }
                    else
                    {
                        this.ScaleValue = (float)((double)drawingArea.Height / (double)iSize.Height);
                    }
                    this.ResetTarget();
                    this.bxBuffer.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;
                    this.bxBuffer.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    this.bxBuffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    if (this.ScaleValue != scaleValue)
                    {
                        this.FullRedraw();
                        this.bxBuffer.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;
                        this.bxBuffer.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        this.bxBuffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    }
                }
                else
                {
                    this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    this.ScaleValue = 1f;
                    this.ResetTarget();
                    this.ScaleEnabled = false;
                    if (scaleEnabled != this.ScaleEnabled | scaleValue != this.ScaleValue)
                    {
                        this.FullRedraw();
                    }
                }
            }
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00004884 File Offset: 0x00002A84
        private void ResetTarget()
        {
            if ((double)this.ScaleValue > 1.125)
            {
                this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            }
            else
            {
                this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            }
            this.gTarget.Dispose();
            this.gTarget = this.cTarget.CreateGraphics();
            this.gTarget.CompositingQuality = CompositingQuality.AssumeLinear;
            this.gTarget.CompositingMode = CompositingMode.SourceCopy;
            this.gTarget.PixelOffsetMode = PixelOffsetMode.None;
            this.gTarget.SmoothingMode = SmoothingMode.None;
        }

        // Token: 0x06000031 RID: 49 RVA: 0x00004928 File Offset: 0x00002B28
        public int ScaleDown(int iValue)
        {
            int result;
            if (!this.ScaleEnabled)
            {
                result = iValue;
            }
            else
            {
                iValue = checked((int)Math.Round((double)((float)iValue / this.ScaleValue)));
                result = iValue;
            }
            return result;
        }

        // Token: 0x06000032 RID: 50 RVA: 0x0000495C File Offset: 0x00002B5C
        public int ScaleUp(int iValue)
        {
            int result;
            if (!this.ScaleEnabled)
            {
                result = iValue;
            }
            else
            {
                iValue = checked((int)Math.Round((double)(unchecked((float)iValue * this.ScaleValue))));
                result = iValue;
            }
            return result;
        }

        // Token: 0x06000033 RID: 51 RVA: 0x00004990 File Offset: 0x00002B90
        private float ScaleDown(float iValue)
        {
            float result;
            if (!this.ScaleEnabled)
            {
                result = iValue;
            }
            else
            {
                iValue /= this.ScaleValue;
                result = iValue;
            }
            return result;
        }

        // Token: 0x06000034 RID: 52 RVA: 0x000049BC File Offset: 0x00002BBC
        public Rectangle ScaleDown(Rectangle iValue)
        {
            checked
            {
                Rectangle result;
                if (!this.ScaleEnabled)
                {
                    result = iValue;
                }
                else
                {
                    iValue.X = (int)Math.Round((double)((float)iValue.X / this.ScaleValue));
                    iValue.Y = (int)Math.Round((double)((float)iValue.Y / this.ScaleValue));
                    iValue.Width = (int)Math.Round((double)((float)iValue.Width / this.ScaleValue));
                    iValue.Height = (int)Math.Round((double)((float)iValue.Height / this.ScaleValue));
                    result = iValue;
                }
                return result;
            }
        }

        // Token: 0x06000035 RID: 53 RVA: 0x00004A58 File Offset: 0x00002C58
        private RectangleF ScaleDown(RectangleF iValue)
        {
            checked
            {
                RectangleF result;
                if (!this.ScaleEnabled)
                {
                    result = iValue;
                }
                else
                {
                    iValue.X = (float)((int)Math.Round((double)(iValue.X / this.ScaleValue)));
                    iValue.Y = (float)((int)Math.Round((double)(iValue.Y / this.ScaleValue)));
                    iValue.Width = (float)((int)Math.Round((double)(iValue.Width / this.ScaleValue)));
                    iValue.Height = (float)((int)Math.Round((double)(iValue.Height / this.ScaleValue)));
                    result = iValue;
                }
                return result;
            }
        }

        // Token: 0x06000036 RID: 54 RVA: 0x00004AF3 File Offset: 0x00002CF3
        private void Output(ref ExtendedBitmap Buffer, Rectangle DestRect, Rectangle SrcRect, GraphicsUnit iUnit)
        {
            this.gTarget.DrawImage(Buffer.Bitmap, DestRect, SrcRect, iUnit);
        }

        // Token: 0x06000037 RID: 55 RVA: 0x00004B0D File Offset: 0x00002D0D
        private void OutputRefresh(Rectangle DestRect, Rectangle SrcRect, GraphicsUnit iUnit)
        {
            this.gTarget.DrawImage(this.bxBuffer.Bitmap, DestRect, SrcRect, iUnit);
        }

        // Token: 0x06000038 RID: 56 RVA: 0x00004B2A File Offset: 0x00002D2A
        private void OutputUnscaled(ref ExtendedBitmap Buffer, Point Location)
        {
            this.gTarget.DrawImageUnscaled(Buffer.Bitmap, Location);
        }

        // Token: 0x06000039 RID: 57 RVA: 0x00004B44 File Offset: 0x00002D44
        public void ColourSwitch()
        {
            bool flag = true;
            if (this.pColorMatrix == null)
            {
                this.pColorMatrix = new ColorMatrix();
            }
            if (MidsContext.Character != null)
            {
                flag = MidsContext.Character.IsHero();
            }
            if (!MidsContext.Config.ShowVillainColours)
            {
                flag = true;
            }
            this.VillainColor = !flag;
            if (flag)
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
                this.pColorMatrix = new ColorMatrix(array);
            }
            else
            {
                float[][] array = new float[5][];
                float[][] array7 = array;
                int num5 = 0;
                float[] array3 = new float[5];
                array3[0] = 0.45f;
                array7[num5] = array3;
                float[][] array8 = array;
                int num6 = 1;
                array3 = new float[5];
                array3[1] = 0.35f;
                array8[num6] = array3;
                float[][] array9 = array;
                int num7 = 2;
                array3 = new float[5];
                array3[0] = 0.75f;
                array3[2] = 0.175f;
                array9[num7] = array3;
                float[][] array10 = array;
                int num8 = 3;
                array3 = new float[5];
                array3[3] = 1f;
                array10[num8] = array3;
                array[4] = new float[]
                {
                    0f,
                    0f,
                    0f,
                    0f,
                    1f
                };
                this.pColorMatrix = new ColorMatrix(array);
            }
            if (this.pImageAttributes == null)
            {
                this.pImageAttributes = new ImageAttributes();
            }
            this.pImageAttributes.SetColorMatrix(this.pColorMatrix);
        }

        // Token: 0x0600003A RID: 58 RVA: 0x00004CD0 File Offset: 0x00002ED0
        public static ImageAttributes GetRecolourIa(bool hero)
        {
            ColorMatrix colorMatrix;
            if (hero)
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
                colorMatrix = new ColorMatrix(array);
            }
            else
            {
                float[][] array = new float[5][];
                float[][] array7 = array;
                int num5 = 0;
                float[] array3 = new float[5];
                array3[0] = 0.45f;
                array7[num5] = array3;
                float[][] array8 = array;
                int num6 = 1;
                array3 = new float[5];
                array3[1] = 0.35f;
                array8[num6] = array3;
                float[][] array9 = array;
                int num7 = 2;
                array3 = new float[5];
                array3[0] = 0.75f;
                array3[2] = 0.175f;
                array9[num7] = array3;
                float[][] array10 = array;
                int num8 = 3;
                array3 = new float[5];
                array3[3] = 1f;
                array10[num8] = array3;
                array[4] = new float[]
                {
                    0f,
                    0f,
                    0f,
                    0f,
                    1f
                };
                colorMatrix = new ColorMatrix(array);
            }
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix);
            return imageAttributes;
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00004E14 File Offset: 0x00003014
        private ImageAttributes GreySlot(bool grey, bool bypassIa = false)
        {
            checked
            {
                ImageAttributes result;
                if (grey)
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
                            if (!bypassIa)
                            {
                                colorMatrix[num5, num6] = this.pColorMatrix[num5, num6];
                            }
                            if (num5 != 4)
                            {
                                colorMatrix[num5, num6] = (float)((double)colorMatrix[num5, num6] / 1.5);
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
                else if (bypassIa)
                {
                    result = new ImageAttributes();
                }
                else
                {
                    result = this.pImageAttributes;
                }
                return result;
            }
        }

        // Token: 0x0600003C RID: 60 RVA: 0x00004FA4 File Offset: 0x000031A4
        private ImageAttributes Desaturate(bool Grey, bool BypassIA = false)
        {
            float[][] array = new float[5][];
            array[0] = new float[]
            {
                0.299f,
                0.299f,
                0.299f,
                0f,
                0f
            };
            array[1] = new float[]
            {
                0.587f,
                0.587f,
                0.587f,
                0f,
                0f
            };
            array[2] = new float[]
            {
                0.114f,
                0.114f,
                0.114f,
                0f,
                0f
            };
            float[][] array2 = array;
            int num = 3;
            float[] array3 = new float[5];
            array3[3] = 1f;
            array2[num] = array3;
            array[4] = new float[]
            {
                0f,
                0f,
                0f,
                0f,
                1f
            };
            ColorMatrix colorMatrix = new ColorMatrix(array);
            array = new float[5][];
            float[][] array4 = array;
            int num2 = 0;
            array3 = new float[5];
            array3[0] = 1f;
            array4[num2] = array3;
            float[][] array5 = array;
            int num3 = 1;
            array3 = new float[5];
            array3[1] = 1f;
            array5[num3] = array3;
            float[][] array6 = array;
            int num4 = 2;
            array3 = new float[5];
            array3[2] = 1f;
            array6[num4] = array3;
            float[][] array7 = array;
            int num5 = 3;
            array3 = new float[5];
            array3[3] = 1f;
            array7[num5] = array3;
            array[4] = new float[]
            {
                0f,
                0f,
                0f,
                0f,
                1f
            };
            ColorMatrix colorMatrix2 = new ColorMatrix(array);
            int num6 = 0;
            checked
            {
                do
                {
                    int num7 = 0;
                    do
                    {
                        if (!BypassIA)
                        {
                            colorMatrix2[num6, num7] = unchecked(this.pColorMatrix[num6, num7] + colorMatrix[num6, num7]) / 2f;
                        }
                        if (Grey & num6 != 4)
                        {
                            colorMatrix2[num6, num7] = (float)((double)colorMatrix2[num6, num7] / 1.5);
                        }
                        num7++;
                    }
                    while (num7 <= 2);
                    num6++;
                }
                while (num6 <= 2);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix2);
                return imageAttributes;
            }
        }

        // Token: 0x0600003D RID: 61 RVA: 0x00005158 File Offset: 0x00003358
        public Rectangle PowerBoundsUnScaled(int hIdx)
        {
            Rectangle rectangle = new Rectangle(0, 0, 1, 1);
            checked
            {
                Rectangle result;
                if (hIdx < 0 | hIdx > MidsContext.Character.CurrentBuild.Powers.Count - 1)
                {
                    result = rectangle;
                }
                else
                {
                    if (!MidsContext.Character.CurrentBuild.Powers[hIdx].Chosen & MidsContext.Character.CurrentBuild.Powers[hIdx].Power != null)
                    {
                        rectangle.Location = this.PowerPosition(hIdx);
                    }
                    else
                    {
                        rectangle.Location = this.PowerPosition(this.GetVisualIDX(hIdx));
                    }
                    rectangle.Width = this.szPower.Width;
                    int num = rectangle.Y + 18;
                    num += this.szSlot.Height;
                    rectangle.Height = num - rectangle.Y;
                    result = rectangle;
                }
                return result;
            }
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00005254 File Offset: 0x00003454
        public bool WithinPowerBar(Rectangle pBounds, Point e)
        {
            pBounds.Height = this.szPower.Height;
            return (e.X >= pBounds.Left & e.X < pBounds.Right) && (e.Y >= pBounds.Top & e.Y < pBounds.Bottom);
        }

        // Token: 0x0600003F RID: 63 RVA: 0x000052C8 File Offset: 0x000034C8
        private Point PowerPosition(int powerEntryIdx)
        {
            return this.PowerPosition(MidsContext.Character.CurrentBuild.Powers[powerEntryIdx], -1);
        }

        // Token: 0x06000040 RID: 64 RVA: 0x00005544 File Offset: 0x00003744
        private int[][] GetInherentGrid()
        {
            switch (this.vcCols)
            {
                case 2:
                    if (MidsContext.Character.Archetype.ClassType == eClassType.HeroEpic)
                    {
                        return new int[][]
                        {
                        new int[]
                        {
                            3,
                            17
                        },
                        new int[]
                        {
                            0,
                            18
                        },
                        new int[]
                        {
                            1,
                            19
                        },
                        new int[]
                        {
                            2,
                            20
                        },
                        new int[]
                        {
                            4,
                            10
                        },
                        new int[]
                        {
                            5,
                            11
                        },
                        new int[]
                        {
                            6,
                            12
                        },
                        new int[]
                        {
                            7,
                            13
                        },
                        new int[]
                        {
                            8,
                            14
                        },
                        new int[]
                        {
                            9,
                            15
                        },
                        new int[]
                        {
                            18,
                            21
                        },
                        new int[]
                        {
                            22,
                            23
                        },
                        new int[]
                        {
                            24,
                            25
                        },
                        new int[]
                        {
                            16,
                            17
                        },
                        new int[]
                        {
                            26,
                            27
                        },
                        new int[]
                        {
                            28,
                            29
                        },
                        new int[]
                        {
                            30,
                            31
                        },
                        new int[]
                        {
                            32,
                            33
                        },
                        new int[]
                        {
                            34,
                            35
                        }
                        };
                    }
                    return new int[][]
                    {
                    new int[]
                    {
                        3,
                        17
                    },
                    new int[]
                    {
                        0,
                        18
                    },
                    new int[]
                    {
                        1,
                        19
                    },
                    new int[]
                    {
                        2,
                        20
                    },
                    new int[]
                    {
                        16,
                        21
                    },
                    new int[]
                    {
                        6,
                        22
                    },
                    new int[]
                    {
                        7,
                        23
                    },
                    new int[]
                    {
                        8,
                        24
                    },
                    new int[]
                    {
                        9,
                        25
                    },
                    new int[]
                    {
                        10,
                        11
                    },
                    new int[]
                    {
                        26,
                        27
                    },
                    new int[]
                    {
                        28,
                        29
                    },
                    new int[]
                    {
                        30,
                        31
                    },
                    new int[]
                    {
                        32,
                        33
                    },
                    new int[]
                    {
                        34,
                        35
                    }
                    };
                case 4:
                    if (MidsContext.Character.Archetype.ClassType == eClassType.HeroEpic)
                    {
                        return new int[][]
                        {
                        new int[]
                        {
                            3,
                            17,
                            4,
                            10
                        },
                        new int[]
                        {
                            0,
                            18,
                            5,
                            11
                        },
                        new int[]
                        {
                            1,
                            19,
                            6,
                            12
                        },
                        new int[]
                        {
                            2,
                            20,
                            7,
                            13
                        },
                        new int[]
                        {
                            16,
                            21,
                            8,
                            14
                        },
                        new int[]
                        {
                            22,
                            23,
                            9,
                            15
                        },
                        new int[]
                        {
                            24,
                            25,
                            26,
                            17
                        },
                        new int[]
                        {
                            28,
                            29,
                            30,
                            31
                        },
                        new int[]
                        {
                            32,
                            33,
                            34,
                            35
                        }
                        };
                    }
                    return new int[][]
                    {
                    new int[]
                    {
                        3,
                        17,
                        21,
                        16
                    },
                    new int[]
                    {
                        0,
                        18,
                        22,
                        6
                    },
                    new int[]
                    {
                        1,
                        19,
                        23,
                        7
                    },
                    new int[]
                    {
                        2,
                        20,
                        24,
                        8
                    },
                    new int[]
                    {
                        26,
                        27,
                        25,
                        9
                    },
                    new int[]
                    {
                        28,
                        29,
                        30,
                        10
                    },
                    new int[]
                    {
                        31,
                        32,
                        33,
                        11
                    },
                    new int[]
                    {
                        34,
                        35,
                        4,
                        5
                    }
                    };
            }
            int[][] result;
            if (MidsContext.Character.Archetype.ClassType == eClassType.HeroEpic)
            {
                result = new int[][]
                {
                    new int[]
                    {
                        3,
                        17,
                        4
                    },
                    new int[]
                    {
                        0,
                        18,
                        5
                    },
                    new int[]
                    {
                        1,
                        19,
                        10
                    },
                    new int[]
                    {
                        2,
                        20,
                        11
                    },
                    new int[]
                    {
                        21,
                        6,
                        12
                    },
                    new int[]
                    {
                        22,
                        7,
                        13
                    },
                    new int[]
                    {
                        23,
                        8,
                        14
                    },
                    new int[]
                    {
                        24,
                        9,
                        15
                    },
                    new int[]
                    {
                        25,
                        16,
                        26
                    },
                    new int[]
                    {
                        27,
                        28,
                        29
                    },
                    new int[]
                    {
                        30,
                        31,
                        32
                    },
                    new int[]
                    {
                        33,
                        34,
                        35
                    }
                };
            }
            else
            {
                result = new int[][]
                {
                    new int[]
                    {
                        3,
                        17,
                        21
                    },
                    new int[]
                    {
                        0,
                        18,
                        22
                    },
                    new int[]
                    {
                        1,
                        19,
                        23
                    },
                    new int[]
                    {
                        2,
                        20,
                        24
                    },
                    new int[]
                    {
                        6,
                        16,
                        25
                    },
                    new int[]
                    {
                        7,
                        26,
                        27
                    },
                    new int[]
                    {
                        8,
                        28,
                        29
                    },
                    new int[]
                    {
                        9,
                        30,
                        31
                    },
                    new int[]
                    {
                        10,
                        32,
                        33
                    },
                    new int[]
                    {
                        11,
                        34,
                        35
                    }
                };
            }
            return result;
        }

        // Token: 0x06000041 RID: 65 RVA: 0x00005C84 File Offset: 0x00003E84
        public Point PowerPosition(PowerEntry powerEntry, int displayLocation = -1)
        {
            int num = MidsContext.Character.CurrentBuild.Powers.IndexOf(powerEntry);
            checked
            {
                if (num == -1)
                {
                    int num2 = 0;
                    int num3 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                    for (int i = num2; i <= num3; i++)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[i].Power.PowerIndex == powerEntry.Power.PowerIndex & MidsContext.Character.CurrentBuild.Powers[i].Level == powerEntry.Level)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                int[][] inherentGrid = this.GetInherentGrid();
                bool flag = false;
                int num4 = 0;
                int num5 = 0;
                if (!powerEntry.Chosen)
                {
                    if (displayLocation == -1 & powerEntry.Power != null)
                    {
                        if (Operators.CompareString(powerEntry.Power.GroupName, "Incarnate", false) == 0)
                        {
                            string setName = powerEntry.PowerSet.SetName;
                            if (Operators.CompareString(setName, "Alpha", false) == 0)
                            {
                                displayLocation = 26;
                            }
                            else if (Operators.CompareString(setName, "Judgement", false) == 0)
                            {
                                displayLocation = 27;
                            }
                            else if (Operators.CompareString(setName, "Interface", false) == 0)
                            {
                                displayLocation = 28;
                            }
                            else if (Operators.CompareString(setName, "Lore", false) == 0)
                            {
                                displayLocation = 29;
                            }
                            else if (Operators.CompareString(setName, "Destiny", false) == 0)
                            {
                                displayLocation = 30;
                            }
                            else if (Operators.CompareString(setName, "Hybrid", false) == 0)
                            {
                                displayLocation = 31;
                            }
                            else if (Operators.CompareString(setName, "Genesis", false) == 0)
                            {
                                displayLocation = 32;
                            }
                            else if (Operators.CompareString(setName, "Stance", false) == 0)
                            {
                                displayLocation = 33;
                            }
                            else if (Operators.CompareString(setName, "Vitae", false) == 0)
                            {
                                displayLocation = 34;
                            }
                            else if (Operators.CompareString(setName, "Omega", false) == 0)
                            {
                                displayLocation = 35;
                            }
                            else
                            {
                                displayLocation = powerEntry.Power.DisplayLocation;
                            }
                        }
                        else
                        {
                            displayLocation = powerEntry.Power.DisplayLocation;
                        }
                    }
                    if (displayLocation > -1)
                    {
                        num4 = this.vcRowsPowers;
                        int num6 = 0;
                        int num7 = inherentGrid.Length - 1;
                        for (int j = num6; j <= num7; j++)
                        {
                            int num8 = 0;
                            int num9 = inherentGrid[j].Length - 1;
                            for (int k = num8; k <= num9; k++)
                            {
                                if (!flag & displayLocation == inherentGrid[j][k])
                                {
                                    num4 += j;
                                    num5 = k;
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (num > -1)
                {
                    int num10 = 1;
                    int num11 = this.vcCols;
                    for (int l = num10; l <= num11; l++)
                    {
                        if (num < this.vcRowsPowers * l)
                        {
                            num5 = l - 1;
                            num4 = num - this.vcRowsPowers * num5;
                            break;
                        }
                    }
                }
                return this.CRtoXY(num5, num4);
            }
        }

        // Token: 0x06000042 RID: 66 RVA: 0x00006054 File Offset: 0x00004254
        private Point CRtoXY(int iCol, int iRow)
        {
            Point result = new Point(0, 0);
            checked
            {
                if (iRow >= this.vcRowsPowers)
                {
                    result.X = iCol * (this.szPower.Width + 7);
                    result.Y = 4 + iRow * (this.szPower.Height + 17);
                }
                else
                {
                    result.X = iCol * (this.szPower.Width + 7);
                    result.Y = iRow * (this.szPower.Height + 17);
                }
                return result;
            }
        }

        // Token: 0x06000043 RID: 67 RVA: 0x000060E8 File Offset: 0x000042E8
        public Size GetDrawingArea()
        {
            Size result = (Size)this.PowerPosition(23);
            checked
            {
                result.Width += this.szPower.Width;
                result.Height = result.Height + this.szPower.Height + 17;
                int num = 0;
                int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int i = num; i <= num2; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].Power != null & !(MidsContext.Character.CurrentBuild.Powers[i].Chosen & i > MidsContext.Character.CurrentBuild.LastPower))
                    {
                        Size size = new Size(result.Width, this.PowerPosition(i).Y + this.szPower.Height + 17);
                        if (size.Height > result.Height)
                        {
                            result.Height = size.Height;
                        }
                        if (size.Width > result.Width)
                        {
                            result.Width = size.Width;
                        }
                    }
                }
                return result;
            }
        }

        // Token: 0x06000044 RID: 68 RVA: 0x0000625C File Offset: 0x0000445C
        private Size GetMaxDrawingArea()
        {
            int cols = this.vcCols;
            this.MiniSetCol(4);
            Size result = (Size)this.PowerPosition(23);
            this.MiniSetCol(2);
            int[][] inherentGrid = this.GetInherentGrid();
            checked
            {
                Size size = (Size)this.CRtoXY(inherentGrid[inherentGrid.Length - 1].Length - 1, inherentGrid.Length - 1);
                if (size.Height > result.Height)
                {
                    result.Height = size.Height;
                }
                if (size.Width > result.Width)
                {
                    result.Width = size.Width;
                }
                this.MiniSetCol(cols);
                result.Width += this.szPower.Width;
                result.Height = result.Height + this.szPower.Height + 17;
                return result;
            }
        }

        // Token: 0x06000045 RID: 69 RVA: 0x00006350 File Offset: 0x00004550
        private void MiniSetCol(int cols)
        {
            if (cols != this.vcCols)
            {
                if (!(cols < 2 | cols > 4))
                {
                    this.vcCols = cols;
                    this.vcRowsPowers = checked((int)Math.Round(24.0 / (double)this.vcCols));
                }
            }
        }

        // Token: 0x06000046 RID: 70 RVA: 0x000063A8 File Offset: 0x000045A8
        public Size GetRequiredDrawingArea()
        {
            int num = -1;
            int num2 = -1;
            int num3 = 0;
            checked
            {
                int num4 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int i = num3; i <= num4; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].IDXPower > -1 | MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                    {
                        Point point = this.PowerPosition(i);
                        if (point.X > num2)
                        {
                            num2 = point.X;
                        }
                        if (point.Y > num)
                        {
                            num = point.Y;
                        }
                    }
                }
                Size result;
                if (num2 > -1 & num > -1)
                {
                    Size size = new Size(num2 + this.szPower.Width, num + this.szPower.Height + 17);
                    result = size;
                }
                else
                {
                    Point point2 = this.PowerPosition(MidsContext.Character.CurrentBuild.LastPower);
                    Size size = new Size(point2.X + this.szPower.Width, point2.Y + this.szPower.Height + 17 + 4);
                    result = size;
                }
                return result;
            }
        }

        // Token: 0x04000009 RID: 9
        private const string GfxPath = "images\\";

        // Token: 0x0400000A RID: 10
        private const string GfxPowerFn = "pSlot";

        // Token: 0x0400000B RID: 11
        private const string GfxFileExt = ".png";

        // Token: 0x0400000C RID: 12
        private const string NewSlotName = "Addslot.png";

        // Token: 0x0400000D RID: 13
        private const int PaddingX = 7;

        // Token: 0x0400000E RID: 14
        private const int PaddingY = 17;

        // Token: 0x0400000F RID: 15
        public const int OffsetY = 18;

        // Token: 0x04000010 RID: 16
        private const int OffsetInherent = 4;

        // Token: 0x04000011 RID: 17
        private const int vcPowers = 24;

        // Token: 0x04000012 RID: 18
        private Size szBuffer;

        // Token: 0x04000013 RID: 19
        public Size szPower;

        // Token: 0x04000014 RID: 20
        public Size szSlot;

        // Token: 0x04000015 RID: 21
        private Font DefaultFont;

        // Token: 0x04000016 RID: 22
        private Color BackColor;

        // Token: 0x04000017 RID: 23
        public ExtendedBitmap bxBuffer;

        // Token: 0x04000018 RID: 24
        public ExtendedBitmap[] bxPower;

        // Token: 0x04000019 RID: 25
        private ExtendedBitmap bxNewSlot;

        // Token: 0x0400001A RID: 26
        private Graphics gTarget;

        // Token: 0x0400001B RID: 27
        private Control cTarget;

        // Token: 0x0400001C RID: 28
        public eInterfaceMode InterfaceMode;

        // Token: 0x0400001D RID: 29
        public int Highlight;

        // Token: 0x0400001E RID: 30
        private ColorMatrix pColorMatrix;

        // Token: 0x0400001F RID: 31
        public ImageAttributes pImageAttributes;

        // Token: 0x04000020 RID: 32
        private bool VillainColor;

        // Token: 0x04000021 RID: 33
        private float ScaleValue;

        // Token: 0x04000022 RID: 34
        private bool ScaleEnabled;

        // Token: 0x04000023 RID: 35
        private int vcCols;

        // Token: 0x04000024 RID: 36
        private int vcRowsPowers;
    }
}
