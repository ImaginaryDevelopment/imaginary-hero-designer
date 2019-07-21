using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
    public class clsDrawX
    {
        // Token: 0x1700000A RID: 10
        // (get) Token: 0x0600001B RID: 27 RVA: 0x000022E0 File Offset: 0x000004E0
        public bool EpicColumns
        {
            get
            {
                return MidsContext.Character != null && MidsContext.Character.Archetype != null && MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic;
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

        int InitColumns
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

        public Size SzPower { get; set; }

        public void ReInit(Control iTarget)
        {
            this.gTarget = iTarget.CreateGraphics();
            this.cTarget = iTarget;
            this.DefaultFont = new Font(iTarget.Font.FontFamily, iTarget.Font.Size, FontStyle.Bold, iTarget.Font.Unit);
            this.BackColor = iTarget.BackColor;
        }

        public clsDrawX(Control iTarget)
        {
            this.InterfaceMode = 0;
            this.VillainColor = false;
            this.ScaleValue = 1f;
            this.ScaleEnabled = false;
            this.vcCols = 3;
            this.vcRowsPowers = 8;
            this.bxPower = new ExtendedBitmap[4];
            checked
            {
                int num2 = this.bxPower.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    this.bxPower[i] = new ExtendedBitmap(FileIO.AddSlash(Application.StartupPath) + GfxPath + GfxPowerFn + Strings.Trim(Conversions.ToString(i)) + GfxFileExt);
                }
                this.ColourSwitch();
                this.InitColumns = MidsContext.Config.Columns;
                this.SzPower = this.bxPower[0].Size;
                this.szSlot = new Size(30, 30);
                this.szBuffer = this.GetMaxDrawingArea();
                Size size = new Size(this.szBuffer.Width, this.szBuffer.Height);
                this.bxBuffer = new ExtendedBitmap(size);
                this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                this.szBuffer = this.GetRequiredDrawingArea();
                this.bxNewSlot = new ExtendedBitmap(FileIO.AddSlash(Application.StartupPath) + GfxPath + "Addslot.png");
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

        void DrawSplit()
        {
            Pen pen = this.VillainColor ? new Pen(Color.Maroon, 2f) : new Pen(Color.Blue, 2f);
            checked
            {
                int iValue = 4 + this.vcRowsPowers * (this.SzPower.Height + 17) - 4;
                this.bxBuffer.Graphics.DrawLine(pen, 0, this.ScaleDown(iValue), this.ScaleDown(this.PowerPosition(15).X + this.SzPower.Width + 7), this.ScaleDown(iValue));
            }
        }

        void DrawPowers()
        {
            checked
            {
                for (int i = 0; i <= MidsContext.Character.CurrentBuild.Powers.Count - 1; i++)
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

        float FontScale(float iSZ) => Math.Min(this.ScaleDown(iSZ) * 1.1f, iSZ);

        static int IndexFromLevel()
            => MidsContext.Character.CurrentBuild.Powers.FindIndex(pow => pow?.Level == MidsContext.Character.RequestedLevel);

        void DrawEnhancement(SlotEntry slot, Font font, Graphics g, ref RectangleF rect)
        {
            unchecked
            {
                if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.SetO
                    | DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.InventO))
                {
                    RectangleF iValue2 = rect;
                    iValue2.Y -= 3f;
                    iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                    string iStr = Conversions.ToString(checked(slot.Enhancement.IOLevel + 1));
                    RectangleF bounds = this.ScaleDown(iValue2);
                    Color cyan = Color.Cyan;
                    Color outline = Color.FromArgb(128, 0, 0, 0);
                    float outlineSpace = 1f;
                    g = this.bxBuffer.Graphics;
                    clsDrawX.DrawOutlineText(iStr, bounds, cyan, outline, font, outlineSpace, g, false, false);
                }
                else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal
                    | DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.SpecialO))
                {
                    RectangleF iValue2 = rect;
                    iValue2.Y -= 3f;
                    iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                    Color color;
                    if (slot.Enhancement.RelativeLevel == 0)
                    {
                        color = Color.Red;
                    }
                    else if (slot.Enhancement.RelativeLevel < Enums.eEnhRelative.Even)
                    {
                        color = Color.Yellow;
                    }
                    else if (slot.Enhancement.RelativeLevel > Enums.eEnhRelative.Even)
                    {
                        color = Color.FromArgb(0, 255, 255);
                    }
                    else
                    {
                        color = Color.White;
                    }
                    string relativeString = Enums.GetRelativeString(slot.Enhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols);
                    RectangleF bounds2 = this.ScaleDown(iValue2);
                    Color text3 = color;
                    Color outline2 = Color.FromArgb(128, 0, 0, 0);
                    Font bFont2 = font;
                    float outlineSpace2 = 1f;
                    clsDrawX.DrawOutlineText(relativeString, bounds2, text3, outline2, bFont2, outlineSpace2, g, false, false);
                }
            }
        }

        public Point DrawPowerSlot(ref PowerEntry iSlot, bool singleDraw = false)
        {
            Pen pen = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
            string text = string.Empty;
            string text2 = string.Empty;
            RectangleF rectangleF = new RectangleF(0f, 0f, 0f, 0f);
            var stringFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip)
            {
                Trimming = StringTrimming.None
            };
            Pen pen2 = new Pen(Color.Black);
            Rectangle rectangle = default;
            Font font = new Font(this.DefaultFont.FontFamily, this.FontScale(this.DefaultFont.SizeInPoints), this.DefaultFont.Style, GraphicsUnit.Point);
            int slotChk = MidsContext.Character.SlotCheck(iSlot);
            bool indicating = false;
            Enums.ePowerState ePowerState = iSlot.State;
            bool canPlaceSlot = MidsContext.Character.CanPlaceSlot;
            bool drawNewSlot = iSlot.Power != null && (iSlot.State != Enums.ePowerState.Empty && canPlaceSlot) && iSlot.Slots.Length < 6 && singleDraw && iSlot.Power.Slottable & this.InterfaceMode != Enums.eInterfaceMode.PowerToggle;
            Point result = this.PowerPosition(iSlot, -1);
            Point point = default;
            checked
            {
                point.X = (int)Math.Round(unchecked(result.X + (checked(this.SzPower.Width - (this.szSlot.Width * 6)) / 2.0)));
                point.Y = result.Y + 18;
                Graphics graphics = this.bxBuffer.Graphics;
                Brush brush = new SolidBrush(this.BackColor);
                Rectangle clipRect = new Rectangle(point.X, point.Y, this.SzPower.Width, this.SzPower.Height);
                graphics.FillRectangle(brush, this.ScaleDown(clipRect));
                var toggling = this.InterfaceMode == Enums.eInterfaceMode.PowerToggle;
                if (!toggling)
                {
                    if (iSlot.Power != null)
                    {
                        if (singleDraw
                                && slotChk > -1
                                && canPlaceSlot
                                && this.InterfaceMode != Enums.eInterfaceMode.PowerToggle
                                && iSlot.PowerSet != null
                                && iSlot.Slots.Length < 6
                                && iSlot.Power.Slottable)
                            ePowerState = Enums.ePowerState.Open;
                        else if (iSlot.Chosen & !canPlaceSlot & this.InterfaceMode != Enums.eInterfaceMode.PowerToggle & this.Highlight == MidsContext.Character.CurrentBuild.Powers.IndexOf(iSlot))
                        {
                            ePowerState = Enums.ePowerState.Open;
                        }
                    }
                    else if (MidsContext.Character.CurrentBuild.Powers.IndexOf(iSlot) == clsDrawX.IndexFromLevel())
                    {
                        ePowerState = Enums.ePowerState.Open;
                    }
                }
                rectangleF.Height = szSlot.Height;
                rectangleF.Width = szSlot.Width;
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                bool grey;
                ImageAttributes imageAttr;
                if (toggling)
                {
                    if (ePowerState == Enums.ePowerState.Open)
                    {
                        ePowerState = Enums.ePowerState.Empty;
                    }
                    if (iSlot.StatInclude & ePowerState == Enums.ePowerState.Used)
                    {
                        ePowerState = Enums.ePowerState.Open;
                        grey = iSlot.Level >= MidsContext.Config.ForceLevel;
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
                    indicating = true;
                    grey = (iSlot.Level >= MidsContext.Config.ForceLevel);
                    imageAttr = this.GreySlot(grey, false);
                }
                Rectangle iValue = new Rectangle(result.X, result.Y, this.bxPower[(int)ePowerState].Size.Width, this.bxPower[(int)ePowerState].Size.Height);
                if (ePowerState == Enums.ePowerState.Used || toggling)
                {
                    if (MidsContext.Config.DesaturateInherent & !iSlot.Chosen)
                    {
                        imageAttr = this.Desaturate(grey, ePowerState == Enums.ePowerState.Open);
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
                if ((indicating || toggling) && iSlot.CanIncludeForStats())
                {
                    rectangle.Height = 15;
                    rectangle.Width = rectangle.Height;
                    rectangle.Y = (int)Math.Round(unchecked(iValue.Top + checked(iValue.Height - rectangle.Height) / 2.0));
                    rectangle.X = (int)Math.Round(unchecked(iValue.Right - (rectangle.Width + checked(iValue.Height - rectangle.Height) / 2.0)));
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
                SolidBrush solidBrush;
                //if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
                var inDesigner = System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv");
                for (var i = 0; i <= iSlot.Slots.Length - 1; i++)
                {
                    var slot = iSlot.Slots[i];
                    rectangleF.X = point.X + this.szSlot.Width * i;
                    rectangleF.Y = point.Y;
                    if (slot.Enhancement.Enh < 0)
                    {
                        Rectangle clipRect2 = new Rectangle((int)Math.Round((double)rectangleF.X), point.Y, 30, 30);
                        this.bxBuffer.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, this.ScaleDown(clipRect2), 0, 0, 30, 30, GraphicsUnit.Pixel, this.pImageAttributes);
                        if (MidsContext.Config.CalcEnhLevel == 0 | slot.Level >= MidsContext.Config.ForceLevel | (this.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !iSlot.StatInclude) | (!iSlot.AllowFrontLoading & slot.Level < iSlot.Level))
                        {
                            solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                            this.bxBuffer.Graphics.FillEllipse(solidBrush, this.ScaleDown(rectangleF));
                            this.bxBuffer.Graphics.DrawEllipse(pen, this.ScaleDown(rectangleF));
                        }
                    }
                    else
                    {
                        if (inDesigner) continue;
                        IEnhancement enhancement = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh];
                        Graphics graphics5 = this.bxBuffer.Graphics;
                        Rectangle clipRect2 = new Rectangle((int)Math.Round((double)rectangleF.X), point.Y, 30, 30);
                        I9Gfx.DrawEnhancementAt(ref graphics5, this.ScaleDown(clipRect2), enhancement.ImageIdx, I9Gfx.ToGfxGrade(enhancement.TypeID, slot.Enhancement.Grade));
                        if (slot.Enhancement.RelativeLevel == 0 | slot.Level >= MidsContext.Config.ForceLevel | (this.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !iSlot.StatInclude) | (!iSlot.AllowFrontLoading & slot.Level < iSlot.Level))
                        {
                            solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                            RectangleF iValue2 = rectangleF;
                            iValue2.Inflate(1f, 1f);
                            this.bxBuffer.Graphics.FillEllipse(solidBrush, this.ScaleDown(iValue2));
                        }
                        if (slot.Enhancement.Enh > -1)
                            DrawEnhancement(slot, font, graphics, ref rectangleF);
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
                        Graphics graphics5 = this.bxBuffer.Graphics;
                        clsDrawX.DrawOutlineText(
                            iStr: Conversions.ToString(slot.Level + 1),
                            bounds: this.ScaleDown(iValue2),
                            textColor: Color.FromArgb(0, 255, 0),
                            outlineColor: Color.FromArgb(192, 0, 0, 0),
                            bFont: font,
                            outlineSpace: 1f,
                            g: graphics5);


                    }
                }
                if (slotChk > -1 && (ePowerState != Enums.ePowerState.Empty && drawNewSlot))
                {
                    Rectangle clipRect2 = new Rectangle(point.X + this.szSlot.Width * (iSlot.Slots.Length), point.Y, this.szSlot.Width, this.szSlot.Height);
                    RectangleF iValue2 = clipRect2;
                    this.bxBuffer.Graphics.DrawImage(this.bxNewSlot.Bitmap, this.ScaleDown(iValue2));
                    iValue2.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
                    unchecked
                    {
                        iValue2.Y += (szSlot.Height - iValue2.Height) / 2f;
                    }
                    clsDrawX.DrawOutlineText(Conversions.ToString(slotChk + 1), this.ScaleDown(iValue2),
                        Color.FromArgb(0, 255, 255), Color.FromArgb(192, 0, 0, 0), font, 1f, this.bxBuffer.Graphics, false, false);
                }
                solidBrush = new SolidBrush(Color.Black);
                stringFormat = new StringFormat();
                rectangleF.X = result.X + 10;
                rectangleF.Y = result.Y + 4;
                rectangleF.Width = SzPower.Width;
                rectangleF.Height = unchecked(this.DefaultFont.GetHeight() * 2f);
                Enums.ePowerState ePowerState2 = iSlot.State;
                if (ePowerState2 == Enums.ePowerState.Empty & ePowerState == Enums.ePowerState.Open)
                {
                    ePowerState2 = ePowerState;
                }
                switch (ePowerState2)
                {
                    case 0:
                        solidBrush = new SolidBrush(Color.Transparent);
                        text = "";
                        break;
                    case Enums.ePowerState.Empty:
                        solidBrush = new SolidBrush(Color.WhiteSmoke);
                        text = "(" + Conversions.ToString(iSlot.Level + 1) + ")";
                        break;
                    case Enums.ePowerState.Used:
                        switch (iSlot.PowerSet.SetType)
                        {
                            case Enums.ePowerSetType.Primary:
                                text2 = "(Pri)";
                                break;
                            case Enums.ePowerSetType.Secondary:
                                text2 = "(Sec)";
                                break;
                            case Enums.ePowerSetType.Ancillary:
                                text2 = "(Ancil)";
                                break;
                            case Enums.ePowerSetType.Inherent:
                                text2 = "";
                                break;
                            case Enums.ePowerSetType.Pool:
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
                    case Enums.ePowerState.Open:
                        solidBrush = new SolidBrush(Color.Yellow);
                        text = "(" + Conversions.ToString(iSlot.Level + 1) + ")";
                        break;
                }
                if (ePowerState == Enums.ePowerState.Empty & iSlot.State == Enums.ePowerState.Used)
                {
                    solidBrush = new SolidBrush(Color.WhiteSmoke);
                }
                if (this.InterfaceMode == Enums.eInterfaceMode.PowerToggle && solidBrush.Color == Color.Black && !iSlot.CanIncludeForStats())
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
                    clsDrawX.DrawOutlineText(iStr4, bounds5, whiteSmoke, outline5, bFont5, outlineSpace5, graphics5, false, true);
                }
                else
                {
                    this.bxBuffer.Graphics.DrawString(text, font, solidBrush, this.ScaleDown(rectangleF), stringFormat);
                }
                return result;
            }
        }

        PathGradientBrush MakePathBrush(Rectangle iRect, PointF iCenter, Color iColor1, Color icolor2)
        {
            float num = (float)(iRect.Left + iRect.Width * 0.5);
            float num2 = (float)(iRect.Top + iRect.Height * 0.5);
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
                pathGradientBrush = new PathGradientBrush(graphicsPath)
                {
                    CenterColor = iColor1,
                    SurroundColors = array
                };
                pathGradientBrush2 = pathGradientBrush;
            }
            PointF centerPoint = new PointF((float)(num + (iCenter.X + iCenter.X * (iRect.Width * 0.5))), (float)(num2 + (iCenter.Y + iCenter.Y * (iRect.Height * 0.5))));
            pathGradientBrush2.CenterPoint = centerPoint;
            return pathGradientBrush;
        }

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

        public void Refresh(Rectangle Clip)
            => this.OutputRefresh(Clip, Clip, GraphicsUnit.Pixel);

        int GetVisualIDX(int PowerIndex)
        {
            int nidpowerset = MidsContext.Character.CurrentBuild.Powers[PowerIndex].NIDPowerset;
            int idxpower = MidsContext.Character.CurrentBuild.Powers[PowerIndex].IDXPower;
            checked
            {
                if (nidpowerset > -1)
                {
                    int vIdx;
                    if (DatabaseAPI.Database.Powersets[nidpowerset].SetType == Enums.ePowerSetType.Inherent)
                    {
                        vIdx = DatabaseAPI.Database.Powersets[nidpowerset].Powers[idxpower].LocationIndex;
                    }
                    else
                    {
                        vIdx = -1;
                        for (int i = 0; i <= PowerIndex; i++)
                        {
                            if (MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset > -1)
                            {
                                if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset].SetType != Enums.ePowerSetType.Inherent)
                                {
                                    vIdx++;
                                }
                            }
                            else
                            {
                                vIdx++;
                            }
                        }
                    }
                    return vIdx;
                }
                else
                {
                    var vIdx = -1;
                    for (int i = 0; i <= PowerIndex; i++)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset > -1)
                        {
                            if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[i].NIDPowerset].SetType != Enums.ePowerSetType.Inherent)
                            {
                                vIdx++;
                            }
                        }
                        else
                        {
                            vIdx++;
                        }
                    }
                    return vIdx;
                }
            }
        }

        public static void DrawOutlineText(string iStr, RectangleF bounds, Color textColor, Color outlineColor, Font bFont, float outlineSpace, Graphics g, bool smallMode = false, bool leftAlign = false)
        {
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap)
            {
                LineAlignment = StringAlignment.Near,
                Alignment = leftAlign ? StringAlignment.Near : StringAlignment.Center
            };

            SolidBrush brush = new SolidBrush(outlineColor);
            RectangleF layoutRectangle = bounds;
            RectangleF layoutRectangle2 = new RectangleF(layoutRectangle.X, layoutRectangle.Y, layoutRectangle.Width, bFont.GetHeight(g));
            layoutRectangle2.X -= outlineSpace;
            if (!smallMode)
                g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.Y -= outlineSpace;
            g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.X += outlineSpace;
            if (!smallMode)
                g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.X += outlineSpace;
            g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.Y += outlineSpace;
            if (!smallMode)
                g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.Y += outlineSpace;
            g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.X -= outlineSpace;
            if (!smallMode)
                g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.X -= outlineSpace;
            g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            layoutRectangle2.Y -= outlineSpace;
            if (!smallMode)
                g.DrawString(iStr, bFont, brush, layoutRectangle2, stringFormat);
            g.DrawString(iStr, bFont, new SolidBrush(textColor), layoutRectangle, stringFormat);
        }

        public int WhichSlot(int iX, int iY)
        {
            checked
            {
                for (int i = 0; i <= MidsContext.Character.CurrentBuild.Powers.Count - 1; i++)
                {
                    Point point;
                    if (MidsContext.Character.CurrentBuild.Powers[i].Power == null || MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                        point = this.PowerPosition(this.GetVisualIDX(i));
                    else
                        point = this.PowerPosition(i);
                    if (iX >= point.X && iY >= point.Y && iX < this.SzPower.Width + point.X && iY < point.Y + this.SzPower.Height + 17)
                        return i;
                }
                return -1;
            }
        }

        public int WhichEnh(int iX, int iY)
        {
            int oPower = -1;
            checked
            {
                Point point = default;
                for (int i = 0; i <= MidsContext.Character.CurrentBuild.Powers.Count - 1; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].Power == null || MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                    {
                        point = this.PowerPosition(this.GetVisualIDX(i));
                    }
                    else
                    {
                        point = this.PowerPosition(i);
                    }
                    if ((iX >= point.X && iY >= point.Y) && (iX < this.SzPower.Width + point.X && iY < point.Y + this.SzPower.Height + 17))
                    {
                        oPower = i;
                        break;
                    }
                }
                if (oPower > -1)
                {
                    bool isValid = false;
                    if (iY >= point.Y + 18)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[oPower].NIDPowerset > -1)
                        {
                            if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[oPower].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[oPower].IDXPower].Slottable)
                            {
                                isValid = true;
                            }
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                    if (isValid)
                    {
                        iX = (int)Math.Round(unchecked(iX - (point.X + checked(this.SzPower.Width - this.szSlot.Width * 6) / 2.0)));
                        for (int i = 0; i <= MidsContext.Character.CurrentBuild.Powers[oPower].Slots.Length - 1; i++)
                        {
                            if (iX <= (i + 1) * this.szSlot.Width)
                            {
                                return i;
                            }
                        }
                        return -1;
                    }
                    return -1;
                }
                return -1;
            }
        }

        public bool HighlightSlot(int idx, bool Force = false)
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
                    if (this.Highlight != idx || Force)
                    {
                        if (idx != -1)
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
                                iValue = new Rectangle(point2.X, point2.Y, this.SzPower.Width, this.SzPower.Height + 17);
                                rectangle = this.ScaleDown(iValue);
                                this.DrawSplit();
                                this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
                            }
                            this.Highlight = idx;
                            currentBuild = MidsContext.Character.CurrentBuild;
                            value = currentBuild.Powers[idx];
                            Point point3 = this.DrawPowerSlot(ref value, true);
                            currentBuild.Powers[idx] = value;
                            point2 = point3;
                            iValue = new Rectangle(point2.X, point2.Y, this.SzPower.Width, this.SzPower.Height + 17);
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
                            Rectangle iValue = new Rectangle(point2.X, point2.Y, this.SzPower.Width, this.SzPower.Height + 17);
                            Rectangle rectangle = this.ScaleDown(iValue);
                            this.DrawSplit();
                            this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
                            this.Highlight = idx;
                        }
                    }
                    result = false;
                }
                return result;
            }
        }

        void Blank()
        {
            if (this.bxBuffer != null)
            {
                this.bxBuffer.Graphics.Clear(this.BackColor);
            }
        }

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
                    this.ScaleValue = (double)drawingArea.Width / iSize.Width > drawingArea.Height / (double)iSize.Height
                        ? (float)(drawingArea.Width / (double)iSize.Width)
                        : (float)(drawingArea.Height / (double)iSize.Height);
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

        void ResetTarget()
        {
            if (this.ScaleValue > 1.125)
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

        public int ScaleDown(int iValue)
        {
            int result;
            if (!this.ScaleEnabled)
            {
                result = iValue;
            }
            else
            {
                iValue = checked((int)Math.Round(iValue / this.ScaleValue));
                result = iValue;
            }
            return result;
        }

        public int ScaleUp(int iValue)
        {
            int result;
            if (!this.ScaleEnabled)
            {
                result = iValue;
            }
            else
            {
                iValue = checked((int)Math.Round(unchecked(iValue * this.ScaleValue)));
                result = iValue;
            }
            return result;
        }

        float ScaleDown(float iValue)
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
                    iValue.X = (int)Math.Round(iValue.X / this.ScaleValue);
                    iValue.Y = (int)Math.Round(iValue.Y / this.ScaleValue);
                    iValue.Width = (int)Math.Round(iValue.Width / this.ScaleValue);
                    iValue.Height = (int)Math.Round(iValue.Height / this.ScaleValue);
                    result = iValue;
                }
                return result;
            }
        }

        RectangleF ScaleDown(RectangleF iValue)
        {
            checked
            {
                if (!this.ScaleEnabled)
                    return iValue;
                iValue.X = (int)Math.Round(iValue.X / this.ScaleValue);
                iValue.Y = (int)Math.Round(iValue.Y / this.ScaleValue);
                iValue.Width = (int)Math.Round(iValue.Width / this.ScaleValue);
                iValue.Height = (int)Math.Round(iValue.Height / this.ScaleValue);
                return iValue;
            }
        }

        void Output(ref ExtendedBitmap Buffer, Rectangle DestRect, Rectangle SrcRect, GraphicsUnit iUnit)
            => this.gTarget.DrawImage(Buffer.Bitmap, DestRect, SrcRect, iUnit);

        void OutputRefresh(Rectangle DestRect, Rectangle SrcRect, GraphicsUnit iUnit)
            => this.gTarget.DrawImage(this.bxBuffer.Bitmap, DestRect, SrcRect, iUnit);

        void OutputUnscaled(ref ExtendedBitmap Buffer, Point Location)
            => this.gTarget.DrawImageUnscaled(Buffer.Bitmap, Location);

        public readonly static float[][] heroMatrix = new[]
        {
                new[] { 1f, 0f, 0f, 0f, 0f },
                new[] { 0f, 1f, 0f, 0f, 0f },
                new[] { 0f, 0f, 1f, 0f, 0f },
                new[] { 0f, 0f, 0f, 1f, 0f },
                new[] { 0f, 0f, 0f, 0f, 1f },
        };
        readonly static float[][] villainMatrix = new[]
        {
                new[] {0.45f, 0, 0, 0, 0},
                new[] {0, 0.35f, 0, 0, 0},
                new[] {0.75f, 0, 0, 0.175f, 0, 0},
                new[] {0,0,0,1f,0},
                new[] {0,0,0,0,1f}
        };
        public void ColourSwitch()
        {
            bool useHeroColors = true;
            if (MidsContext.Character != null)
                useHeroColors = MidsContext.Character.IsHero();
            if (!MidsContext.Config.ShowVillainColours)
                useHeroColors = true;

            this.VillainColor = !useHeroColors;
            this.pColorMatrix = new ColorMatrix(useHeroColors ? heroMatrix : villainMatrix);
            if (this.pImageAttributes == null)
                this.pImageAttributes = new ImageAttributes();
            this.pImageAttributes.SetColorMatrix(this.pColorMatrix);
        }

        public static ImageAttributes GetRecolourIa(bool hero)
        {
            var colorMatrix = new ColorMatrix(hero ? heroMatrix : villainMatrix);
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix);
            return imageAttributes;
        }

        ImageAttributes GreySlot(bool grey, bool bypassIa = false)
        {
            if (!grey)
            {
                if (bypassIa) return new ImageAttributes();
                return this.pImageAttributes;
            }
            checked
            {

                ColorMatrix colorMatrix = new ColorMatrix(heroMatrix);
                int r = 0;
                do
                {
                    int c = 0;
                    do
                    {
                        if (!bypassIa)
                        {
                            colorMatrix[r, c] = this.pColorMatrix[r, c];
                        }
                        if (r != 4)
                        {
                            colorMatrix[r, c] = (float)(colorMatrix[r, c] / 1.5);
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

        ImageAttributes Desaturate(bool Grey, bool BypassIA = false)
        {
            ColorMatrix tMM = new ColorMatrix(new[]
            {
                new [] { 0.299f, 0.299f, 0.299f, 0f, 0f },
                new [] { 0.587f, 0.587f, 0.587f, 0f, 0f},
                new [] { 0.114f, 0.114f, 0.114f, 0f, 0f },
                new [] { 0, 0, 0, 1f, 0},
                new [] { 0, 0, 0, 0, 1f},
            });
            ColorMatrix tCM = new ColorMatrix(heroMatrix);
            int r = 0;
            checked
            {
                do
                {
                    int c = 0;
                    do
                    {
                        if (!BypassIA)
                        {
                            tCM[r, c] = unchecked(this.pColorMatrix[r, c] + tMM[r, c]) / 2f;
                        }
                        if (Grey && r != 4)
                        {
                            tCM[r, c] = (float)((double)tCM[r, c] / 1.5);
                        }
                        c++;
                    }
                    while (c <= 2);
                    r++;
                }
                while (r <= 2);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(tCM);
                return imageAttributes;
            }
        }

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
                    if (!MidsContext.Character.CurrentBuild.Powers[hIdx].Chosen && MidsContext.Character.CurrentBuild.Powers[hIdx].Power != null)
                    {
                        rectangle.Location = this.PowerPosition(hIdx);
                    }
                    else
                    {
                        rectangle.Location = this.PowerPosition(this.GetVisualIDX(hIdx));
                    }
                    rectangle.Width = this.SzPower.Width;
                    int num = rectangle.Y + 18;
                    num += this.szSlot.Height;
                    rectangle.Height = num - rectangle.Y;
                    result = rectangle;
                }
                return result;
            }
        }

        public bool WithinPowerBar(Rectangle pBounds, Point e)
        {
            pBounds.Height = this.SzPower.Height;
            return (e.X >= pBounds.Left && e.X < pBounds.Right) && (e.Y >= pBounds.Top && e.Y < pBounds.Bottom);
        }

        Point PowerPosition(int powerEntryIdx)
        {
            return this.PowerPosition(MidsContext.Character.CurrentBuild.Powers[powerEntryIdx], -1);
        }

        int[][] GetInherentGrid()
        {
            switch (this.vcCols)
            {
                case 2:
                    if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic)
                    {
                        return new int[][]
                        {
                            new [] { 3, 17 },
                            new [] { 0, 18 },
                            new [] { 1, 19 },
                            new [] { 2, 20 },
                            new [] { 4, 10 },
                            new [] { 5, 11 },
                            new [] { 6, 12 },
                            new [] { 7, 13 },
                            new [] { 8, 14 },
                            new [] { 9, 15 },
                            new [] { 18, 21 },
                            new [] { 22, 23 },
                            new [] { 24, 25 },
                            new [] { 16, 17 },
                            new [] { 26, 27 },
                            new [] { 28, 29 },
                            new [] { 30, 31 },
                            new [] { 32, 33 },
                            new [] { 34, 35 }
                        };
                    }
                    return new int[][]
                    {
                        new [] { 3, 17 },
                        new [] { 0, 18 },
                        new [] { 1, 19 },
                        new [] { 2, 20 },
                        new [] { 16, 21 },
                        new [] { 6, 22 },
                        new [] { 7, 23 },
                        new [] { 8, 24 },
                        new [] { 9, 25 },
                        new [] { 10, 11 },
                        new [] { 26, 27 },
                        new [] { 28, 29 },
                        new [] { 30, 31 },
                        new [] { 32, 33 },
                        new [] { 34, 35 }
                    };
                case 4:
                    if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic)
                    {
                        return new int[][]
                        {
                            new [] { 3, 17, 4, 10 },
                            new [] { 0, 18, 5, 11 },
                            new [] { 1, 19, 6, 12 },
                            new [] { 2, 20, 7, 13 },
                            new [] { 16, 21, 8, 14 },
                            new [] { 22, 23, 9, 15 },
                            new [] { 24, 25, 26, 17 },
                            new [] { 28, 29, 30, 31 },
                            new [] { 32, 33, 34, 35 }
                        };
                    }
                    return new int[][]
                    {
                        new [] { 3, 17, 21, 16 },
                        new [] { 0, 18, 22, 6 },
                        new [] { 1, 19, 23, 7 },
                        new [] { 2, 20, 24, 8 },
                        new [] { 26, 27, 25, 9 },
                        new [] { 28, 29, 30, 10 },
                        new [] { 31, 32, 33, 11 },
                        new [] { 34, 35, 4, 5 }
                    };
            }
            if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic)
            {
                return new int[][]
                {
                    new int[] { 3, 17, 4 },
                    new int[] { 0, 18, 5 },
                    new int[] { 1, 19, 10 },
                    new int[] { 2, 20, 11 },
                    new int[] { 21, 6, 12 },
                    new int[] { 22, 7, 13 },
                    new int[] { 23, 8, 14 },
                    new int[] { 24, 9, 15 },
                    new int[] { 25, 16, 26 },
                    new int[] { 27, 28, 29 },
                    new int[] { 30, 31, 32 },
                    new int[] { 33, 34, 35 }
                };
            }
            return new int[][]
            {
                    new int[] { 3, 17, 21 },
                    new int[] { 0, 18, 22 },
                    new int[] { 1, 19, 23 },
                    new int[] { 2, 20, 24 },
                    new int[] { 6, 16, 25 },
                    new int[] { 7, 26, 27 },
                    new int[] { 8, 28, 29 },
                    new int[] { 9, 30, 31 },
                    new int[] { 10, 32, 33 },
                    new int[] { 11, 34, 35 }
            };
        }

        public Point PowerPosition(PowerEntry powerEntry, int displayLocation = -1)
        {
            int powerIdx = MidsContext.Character.CurrentBuild.Powers.IndexOf(powerEntry);
            checked
            {
                if (powerIdx == -1)
                {
                    int num2 = 0;
                    int num3 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                    for (int i = num2; i <= num3; i++)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[i].Power.PowerIndex == powerEntry.Power.PowerIndex && MidsContext.Character.CurrentBuild.Powers[i].Level == powerEntry.Level)
                        {
                            powerIdx = i;
                            break;
                        }
                    }
                }
                int[][] inherentGrid = this.GetInherentGrid();
                bool flag = false;
                int iRow = 0;
                int iCol = 0;
                if (!powerEntry.Chosen)
                {
                    if (displayLocation == -1 && powerEntry.Power != null)
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
                        iRow = this.vcRowsPowers;
                        for (int i = 0; i <= inherentGrid.Length - 1; i++)
                        {
                            for (int k = 0; k <= inherentGrid[i].Length - 1; k++)
                            {
                                if (!flag && displayLocation == inherentGrid[i][k])
                                {
                                    iRow += i;
                                    iCol = k;
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
                else if (powerIdx > -1)
                {
                    for (int i = 1; i <= this.vcCols; i++)
                    {
                        if (powerIdx < this.vcRowsPowers * i)
                        {
                            iCol = i - 1;
                            iRow = powerIdx - this.vcRowsPowers * iCol;
                            break;
                        }
                    }
                }
                return this.CRtoXY(iCol, iRow);
            }
        }

        Point CRtoXY(int iCol, int iRow)
        {
            Point result = new Point(0, 0);
            checked
            {
                if (iRow >= this.vcRowsPowers)
                {
                    result.X = iCol * (this.SzPower.Width + 7);
                    result.Y = 4 + iRow * (this.SzPower.Height + 17);
                }
                else
                {
                    result.X = iCol * (this.SzPower.Width + 7);
                    result.Y = iRow * (this.SzPower.Height + 17);
                }
                return result;
            }
        }

        public Size GetDrawingArea()
        {
            Size result = (Size)this.PowerPosition(23);
            checked
            {
                result.Width += this.SzPower.Width;
                result.Height = result.Height + this.SzPower.Height + 17;
                for (int i = 0; i <= MidsContext.Character.CurrentBuild.Powers.Count - 1; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].Power != null && !(MidsContext.Character.CurrentBuild.Powers[i].Chosen && i > MidsContext.Character.CurrentBuild.LastPower))
                    {
                        Size size = new Size(result.Width, this.PowerPosition(i).Y + this.SzPower.Height + 17);
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

        Size GetMaxDrawingArea()
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
                result.Width += this.SzPower.Width;
                result.Height = result.Height + this.SzPower.Height + 17;
                return result;
            }
        }

        void MiniSetCol(int cols)
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

        public Size GetRequiredDrawingArea()
        {
            int maxY = -1;
            int maxX = -1;
            checked
            {
                int num4 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int i = 0; i <= num4; i++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[i].IDXPower > -1 | MidsContext.Character.CurrentBuild.Powers[i].Chosen)
                    {
                        Point point = this.PowerPosition(i);
                        if (point.X > maxX)
                        {
                            maxX = point.X;
                        }
                        if (point.Y > maxY)
                        {
                            maxY = point.Y;
                        }
                    }
                }
                Size result;
                if (maxX > -1 & maxY > -1)
                {
                    Size size = new Size(maxX + this.SzPower.Width, maxY + this.SzPower.Height + 17);
                    result = size;
                }
                else
                {
                    Point point2 = this.PowerPosition(MidsContext.Character.CurrentBuild.LastPower);
                    Size size = new Size(point2.X + this.SzPower.Width, point2.Y + this.SzPower.Height + 17 + 4);
                    result = size;
                }
                return result;
            }
        }

        const string GfxPath = "images\\";

        const string GfxPowerFn = "pSlot";

        const string GfxFileExt = ".png";

        const string NewSlotName = "Addslot.png";

        const int PaddingX = 7;

        const int PaddingY = 17;

        public const int OffsetY = 18;

        const int OffsetInherent = 4;

        const int vcPowers = 24;

        Size szBuffer;

        public Size szSlot;

        Font DefaultFont;

        Color BackColor;

        public ExtendedBitmap bxBuffer;

        public ExtendedBitmap[] bxPower;

        ExtendedBitmap bxNewSlot;

        Graphics gTarget;

        Control cTarget;

        public Enums.eInterfaceMode InterfaceMode;

        public int Highlight;

        ColorMatrix pColorMatrix;

        public ImageAttributes pImageAttributes;

        bool VillainColor;

        float ScaleValue;

        bool ScaleEnabled;

        int vcCols;
        int vcRowsPowers;
    }
}
