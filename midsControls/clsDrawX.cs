// Decompiled with JetBrains decompiler
// Type: midsControls.clsDrawX
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace midsControls
{
  public class clsDrawX
  {
    private const string GfxPath = "images\\";
    private const string GfxPowerFn = "pSlot";
    private const string GfxFileExt = ".png";
    private const string NewSlotName = "Addslot.png";
    private const int PaddingX = 7;
    private const int PaddingY = 17;
    public const int OffsetY = 18;
    private const int OffsetInherent = 4;
    private const int vcPowers = 24;
    private Size szBuffer;
    public Size szPower;
    public Size szSlot;
    private Font DefaultFont;
    private Color BackColor;
    public ExtendedBitmap bxBuffer;
    public ExtendedBitmap[] bxPower;
    private ExtendedBitmap bxNewSlot;
    private Graphics gTarget;
    private Control cTarget;
    public Enums.eInterfaceMode InterfaceMode;
    public int Highlight;
    private ColorMatrix pColorMatrix;
    public ImageAttributes pImageAttributes;
    private bool VillainColor;
    private float ScaleValue;
    private bool ScaleEnabled;
    private int vcCols;
    private int vcRowsPowers;

    public bool EpicColumns
    {
      get
      {
        return MidsContext.Character != null && MidsContext.Character.Archetype != null && MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic;
      }
    }

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

    private int InitColumns
    {
      set
      {
        if (value == this.vcCols || value < 2 | value > 4)
          return;
        this.vcCols = value;
        this.vcRowsPowers = checked ((int) Math.Round(unchecked (24.0 / (double) this.vcCols)));
      }
    }

    public void ReInit(ref Control iTarget)
    {
      this.gTarget = iTarget.CreateGraphics();
      this.cTarget = iTarget;
      this.DefaultFont = new Font(iTarget.Font.FontFamily, iTarget.Font.Size, FontStyle.Bold, iTarget.Font.Unit);
      this.BackColor = iTarget.BackColor;
    }

    public clsDrawX(ref Control iTarget)
    {
      this.InterfaceMode = Enums.eInterfaceMode.Normal;
      this.VillainColor = false;
      this.ScaleValue = 1f;
      this.ScaleEnabled = false;
      this.vcCols = 3;
      this.vcRowsPowers = 8;
      this.bxPower = new ExtendedBitmap[4];
      int num1 = 0;
      int num2 = checked (this.bxPower.Length - 1);
      int index = num1;
      while (index <= num2)
      {
        this.bxPower[index] = new ExtendedBitmap(FileIO.AddSlash(Application.StartupPath) + "images\\pSlot" + Strings.Trim(Conversions.ToString(index)) + ".png");
        checked { ++index; }
      }
      this.ColourSwitch();
      this.InitColumns = MidsContext.Config.Columns;
      this.szPower = this.bxPower[0].Size;
      this.szSlot = new Size(30, 30);
      this.szBuffer = this.GetMaxDrawingArea();
      this.bxBuffer = new ExtendedBitmap(new Size(this.szBuffer.Width, this.szBuffer.Height));
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
      if (this.szBuffer.Height >= this.cTarget.Height)
        return;
      this.gTarget.FillRectangle((Brush) new SolidBrush(this.BackColor), 0, this.szBuffer.Height, this.cTarget.Width, checked (this.cTarget.Height - this.szBuffer.Height));
    }

    private void DrawSplit()
    {
      Pen pen = !this.VillainColor ? new Pen(Color.Blue, 2f) : new Pen(Color.Maroon, 2f);
      int iValue = checked (4 + this.vcRowsPowers * (this.szPower.Height + 17) - 4);
      this.bxBuffer.Graphics.DrawLine(pen, 0, this.ScaleDown(iValue), this.ScaleDown(checked (this.PowerPosition(15).X + this.szPower.Width + 7)), this.ScaleDown(iValue));
    }

    private void DrawPowers()
    {
      int num1 = 0;
      int num2 = checked (MidsContext.Character.CurrentBuild.Powers.Count - 1);
      int index1 = num1;
      while (index1 <= num2)
      {
        PowerEntry iSlot;
        if (MidsContext.Character.CanPlaceSlot & this.Highlight == index1)
        {
          Build currentBuild = MidsContext.Character.CurrentBuild;
          List<PowerEntry> powers = currentBuild.Powers;
          int index2 = index1;
          iSlot = powers[index2];
          this.DrawPowerSlot(ref iSlot, true);
          currentBuild.Powers[index2] = iSlot;
        }
        else if (MidsContext.Character.CurrentBuild.Powers[index1].Chosen)
        {
          Build currentBuild = MidsContext.Character.CurrentBuild;
          List<PowerEntry> powers = currentBuild.Powers;
          int index2 = index1;
          iSlot = powers[index2];
          this.DrawPowerSlot(ref iSlot, false);
          currentBuild.Powers[index2] = iSlot;
        }
        else if (MidsContext.Character.CurrentBuild.Powers[index1].Power != null && Operators.CompareString(MidsContext.Character.CurrentBuild.Powers[index1].Power.GroupName, "Incarnate", false) == 0 | MidsContext.Character.CurrentBuild.Powers[index1].Power.IncludeFlag)
        {
          Build currentBuild = MidsContext.Character.CurrentBuild;
          List<PowerEntry> powers = currentBuild.Powers;
          int index2 = index1;
          iSlot = powers[index2];
          this.DrawPowerSlot(ref iSlot, false);
          currentBuild.Powers[index2] = iSlot;
        }
        checked { ++index1; }
      }
      Application.DoEvents();
      this.DrawSplit();
    }

    private float FontScale(float iSZ)
    {
      float num = this.ScaleDown(iSZ) * 1.1f;
      if ((double) num > (double) iSZ)
        num = iSZ;
      return num;
    }

    private static int IndexFromLevel()
    {
      int num = 0;
      int lastPower = MidsContext.Character.CurrentBuild.LastPower;
      int index = num;
      while (index <= lastPower)
      {
        if (MidsContext.Character.CurrentBuild.Powers[index].Level == MidsContext.Character.RequestedLevel)
          return index;
        checked { ++index; }
      }
      return -1;
    }

    public Point DrawPowerSlot(ref PowerEntry iSlot, bool SingleDraw = false)
    {
      Pen pen1 = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
      string s = string.Empty;
      string str = string.Empty;
      RectangleF iValue1 = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
      StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
      stringFormat.Trimming = StringTrimming.None;
      Pen pen2 = new Pen(Color.Black);
      Rectangle rectangle = new Rectangle();
      Font font = new Font(this.DefaultFont.FontFamily, this.FontScale(this.DefaultFont.SizeInPoints), this.DefaultFont.Style, GraphicsUnit.Point);
      int num1 = MidsContext.Character.SlotCheck(iSlot);
      bool flag1 = this.InterfaceMode == Enums.eInterfaceMode.PowerToggle;
      bool flag2 = false;
      Enums.ePowerState ePowerState1 = iSlot.State;
      bool canPlaceSlot = MidsContext.Character.CanPlaceSlot;
      bool flag3 = iSlot.Power != null;
      if (flag3)
        flag3 = iSlot.State != Enums.ePowerState.Empty & canPlaceSlot & iSlot.Slots.Length < 6 & SingleDraw & iSlot.Power.Slottable & this.InterfaceMode != Enums.eInterfaceMode.PowerToggle;
      Point point1 = this.PowerPosition(iSlot, -1);
      Point point2 = new Point();
      point2.X = checked ((int) Math.Round(unchecked ((double) point1.X + (double) checked (this.szPower.Width - this.szSlot.Width * 6) / 2.0)));
      point2.Y = checked (point1.Y + 18);
      Graphics graphics1 = this.bxBuffer.Graphics;
      Brush brush = (Brush) new SolidBrush(this.BackColor);
      Rectangle iValue2 = new Rectangle(point2.X, point2.Y, this.szPower.Width, this.szPower.Height);
      graphics1.FillRectangle(brush, this.ScaleDown(iValue2));
      if (!flag1)
      {
        if (iSlot.Power != null)
        {
          if (SingleDraw & num1 > -1 & canPlaceSlot & this.InterfaceMode != Enums.eInterfaceMode.PowerToggle & iSlot.PowerSet != null & iSlot.Slots.Length < 6 & iSlot.Power.Slottable)
            ePowerState1 = Enums.ePowerState.Open;
          else if (iSlot.Chosen & !canPlaceSlot & this.InterfaceMode != Enums.eInterfaceMode.PowerToggle & this.Highlight == MidsContext.Character.CurrentBuild.Powers.IndexOf(iSlot))
            ePowerState1 = Enums.ePowerState.Open;
        }
        else if (MidsContext.Character.CurrentBuild.Powers.IndexOf(iSlot) == clsDrawX.IndexFromLevel())
          ePowerState1 = Enums.ePowerState.Open;
      }
      iValue1.Height = (float) this.szSlot.Height;
      iValue1.Width = (float) this.szSlot.Width;
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;
      this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      bool flag4;
      ImageAttributes imageAttr;
      if (flag1)
      {
        if (ePowerState1 == Enums.ePowerState.Open)
          ePowerState1 = Enums.ePowerState.Empty;
        if (iSlot.StatInclude & ePowerState1 == Enums.ePowerState.Used)
        {
          ePowerState1 = Enums.ePowerState.Open;
          flag4 = iSlot.Level >= MidsContext.Config.ForceLevel;
          imageAttr = this.GreySlot(flag4, true);
        }
        else if (iSlot.CanIncludeForStats())
        {
          flag4 = iSlot.Level >= MidsContext.Config.ForceLevel;
          imageAttr = this.GreySlot(flag4, false);
        }
        else
        {
          imageAttr = this.GreySlot(true, false);
          flag4 = true;
        }
      }
      else
      {
        flag2 = true;
        flag4 = iSlot.Level >= MidsContext.Config.ForceLevel;
        imageAttr = this.GreySlot(flag4, false);
      }
      Rectangle iValue3 = new Rectangle(point1.X, point1.Y, this.bxPower[(int) ePowerState1].Size.Width, this.bxPower[(int) ePowerState1].Size.Height);
      Rectangle iValue4;
      if (ePowerState1 == Enums.ePowerState.Used | flag1)
      {
        if (MidsContext.Config.DesaturateInherent & !iSlot.Chosen)
          imageAttr = this.Desaturate(flag4, ePowerState1 == Enums.ePowerState.Open);
        Graphics graphics2 = this.bxBuffer.Graphics;
        Image bitmap = (Image) this.bxPower[(int) ePowerState1].Bitmap;
        Rectangle destRect = this.ScaleDown(iValue3);
        int srcX = 0;
        int srcY = 0;
        int width = this.bxPower[(int) ePowerState1].ClipRect.Width;
        iValue4 = this.bxPower[(int) ePowerState1].ClipRect;
        graphics2.DrawImage(bitmap, destRect, srcX, srcY, width, iValue4.Height, GraphicsUnit.Pixel, imageAttr);
      }
      else
      {
        Graphics graphics2 = this.bxBuffer.Graphics;
        Image bitmap = (Image) this.bxPower[(int) ePowerState1].Bitmap;
        Rectangle destRect = this.ScaleDown(iValue3);
        int srcX = 0;
        int srcY = 0;
        int width = this.bxPower[(int) ePowerState1].ClipRect.Width;
        iValue2 = this.bxPower[(int) ePowerState1].ClipRect;
        graphics2.DrawImage(bitmap, destRect, srcX, srcY, width, iValue2.Height, GraphicsUnit.Pixel);
      }
      if ((flag2 | flag1) & iSlot.CanIncludeForStats())
      {
        rectangle.Height = 15;
        rectangle.Width = rectangle.Height;
        rectangle.Y = checked ((int) Math.Round(unchecked ((double) iValue3.Top + (double) checked (iValue3.Height - rectangle.Height) / 2.0)));
        rectangle.X = checked ((int) Math.Round(unchecked ((double) iValue3.Right - (double) rectangle.Width + (double) checked (iValue3.Height - rectangle.Height) / 2.0)));
        rectangle = this.ScaleDown(rectangle);
        this.bxBuffer.Graphics.FillEllipse(!iSlot.StatInclude ? (Brush) this.MakePathBrush(rectangle, new PointF(-0.25f, -0.33f), Color.FromArgb(96, 96, 96), Color.FromArgb(0, 0, 0)) : (Brush) this.MakePathBrush(rectangle, new PointF(-0.25f, -0.33f), Color.FromArgb(96, (int) byte.MaxValue, 96), Color.FromArgb(0, 32, 0)), rectangle);
        this.bxBuffer.Graphics.DrawEllipse(pen2, rectangle);
      }
      int num2 = 0;
      int num3 = checked (iSlot.Slots.Length - 1);
      int index = num2;
      RectangleF iValue5;
      while (index <= num3)
      {
        iValue1.X = (float) checked (point2.X + this.szSlot.Width * index);
        iValue1.Y = (float) point2.Y;
        if (iSlot.Slots[index].Enhancement.Enh < 0)
        {
          Graphics graphics2 = this.bxBuffer.Graphics;
          Image bitmap = (Image) I9Gfx.EnhTypes.Bitmap;
          iValue4 = new Rectangle(checked ((int) Math.Round((double) iValue1.X)), point2.Y, 30, 30);
          graphics2.DrawImage(bitmap, this.ScaleDown(iValue4), 0, 0, 30, 30, GraphicsUnit.Pixel, this.pImageAttributes);
          if (MidsContext.Config.CalcEnhLevel == Enums.eEnhRelative.None | iSlot.Slots[index].Level >= MidsContext.Config.ForceLevel | this.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !iSlot.StatInclude | !iSlot.AllowFrontLoading & iSlot.Slots[index].Level < iSlot.Level)
          {
            this.bxBuffer.Graphics.FillEllipse((Brush) new SolidBrush(Color.FromArgb(160, 0, 0, 0)), this.ScaleDown(iValue1));
            this.bxBuffer.Graphics.DrawEllipse(pen1, this.ScaleDown(iValue1));
          }
        }
        else
        {
          IEnhancement enhancement = DatabaseAPI.Database.Enhancements[iSlot.Slots[index].Enhancement.Enh];
          Graphics graphics2 = this.bxBuffer.Graphics;
          iValue4 = new Rectangle(checked ((int) Math.Round((double) iValue1.X)), point2.Y, 30, 30);
          I9Gfx.DrawEnhancementAt(ref graphics2, this.ScaleDown(iValue4), enhancement.ImageIdx, I9Gfx.ToGfxGrade(enhancement.TypeID, iSlot.Slots[index].Enhancement.Grade));
          if (iSlot.Slots[index].Enhancement.RelativeLevel == Enums.eEnhRelative.None | iSlot.Slots[index].Level >= MidsContext.Config.ForceLevel | this.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !iSlot.StatInclude | !iSlot.AllowFrontLoading & iSlot.Slots[index].Level < iSlot.Level)
          {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            iValue5 = iValue1;
            iValue5.Inflate(1f, 1f);
            this.bxBuffer.Graphics.FillEllipse((Brush) solidBrush, this.ScaleDown(iValue5));
          }
          if (iSlot.Slots[index].Enhancement.Enh > -1)
          {
            if (MidsContext.Config.I9.DisplayIOLevels & (DatabaseAPI.Database.Enhancements[iSlot.Slots[index].Enhancement.Enh].TypeID == Enums.eType.SetO | DatabaseAPI.Database.Enhancements[iSlot.Slots[index].Enhancement.Enh].TypeID == Enums.eType.InventO))
            {
              iValue5 = iValue1;
              iValue5.Y -= 3f;
              iValue5.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
              string iStr = Conversions.ToString(checked (iSlot.Slots[index].Enhancement.IOLevel + 1));
              RectangleF Bounds = this.ScaleDown(iValue5);
              Color cyan = Color.Cyan;
              Color Outline = Color.FromArgb(128, 0, 0, 0);
              Font bFont = font;
              float OutlineSpace = 1f;
              Graphics graphics3 = this.bxBuffer.Graphics;
              clsDrawX.DrawOutlineText(iStr, Bounds, cyan, Outline, bFont, OutlineSpace, ref graphics3, false, false);
            }
            else if (MidsContext.Config.ShowEnhRel & (DatabaseAPI.Database.Enhancements[iSlot.Slots[index].Enhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[iSlot.Slots[index].Enhancement.Enh].TypeID == Enums.eType.SpecialO))
            {
              iValue5 = iValue1;
              iValue5.Y -= 3f;
              iValue5.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
              Color color = iSlot.Slots[index].Enhancement.RelativeLevel != Enums.eEnhRelative.None ? (iSlot.Slots[index].Enhancement.RelativeLevel >= Enums.eEnhRelative.Even ? (iSlot.Slots[index].Enhancement.RelativeLevel <= Enums.eEnhRelative.Even ? Color.White : Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue)) : Color.Yellow) : Color.Red;
              string relativeString = Enums.GetRelativeString(iSlot.Slots[index].Enhancement.RelativeLevel, MidsContext.Config.ShowRelSymbols);
              RectangleF Bounds = this.ScaleDown(iValue5);
              Color Text = color;
              Color Outline = Color.FromArgb(128, 0, 0, 0);
              Font bFont = font;
              float OutlineSpace = 1f;
              Graphics graphics3 = this.bxBuffer.Graphics;
              clsDrawX.DrawOutlineText(relativeString, Bounds, Text, Outline, bFont, OutlineSpace, ref graphics3, false, false);
            }
          }
        }
        if (MidsContext.Config.ShowSlotLevels)
        {
          iValue5 = iValue1;
          iValue5.Y += iValue5.Height;
          iValue5.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
          iValue5.Y -= iValue5.Height;
          string iStr = Conversions.ToString(checked (iSlot.Slots[index].Level + 1));
          RectangleF Bounds = this.ScaleDown(iValue5);
          Color Text = Color.FromArgb(0, (int) byte.MaxValue, 0);
          Color Outline = Color.FromArgb(192, 0, 0, 0);
          Font bFont = font;
          float OutlineSpace = 1f;
          Graphics graphics2 = this.bxBuffer.Graphics;
          clsDrawX.DrawOutlineText(iStr, Bounds, Text, Outline, bFont, OutlineSpace, ref graphics2, false, false);
        }
        checked { ++index; }
      }
      if (num1 > -1 && ePowerState1 != Enums.ePowerState.Empty & flag3)
      {
        iValue4 = new Rectangle(checked (point2.X + this.szSlot.Width * index), point2.Y, this.szSlot.Width, this.szSlot.Height);
        iValue5 = (RectangleF) iValue4;
        this.bxBuffer.Graphics.DrawImage((Image) this.bxNewSlot.Bitmap, this.ScaleDown(iValue5));
        iValue5.Height = this.DefaultFont.GetHeight(this.bxBuffer.Graphics);
        iValue5.Y += (float) (((double) this.szSlot.Height - (double) iValue5.Height) / 2.0);
        string iStr = Conversions.ToString(checked (num1 + 1));
        RectangleF Bounds = this.ScaleDown(iValue5);
        Color Text = Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue);
        Color Outline = Color.FromArgb(192, 0, 0, 0);
        Font bFont = font;
        float OutlineSpace = 1f;
        Graphics graphics2 = this.bxBuffer.Graphics;
        clsDrawX.DrawOutlineText(iStr, Bounds, Text, Outline, bFont, OutlineSpace, ref graphics2, false, false);
      }
      SolidBrush solidBrush1 = new SolidBrush(Color.Black);
      StringFormat format = new StringFormat();
      iValue1.X = (float) checked (point1.X + 10);
      iValue1.Y = (float) checked (point1.Y + 4);
      iValue1.Width = (float) this.szPower.Width;
      iValue1.Height = this.DefaultFont.GetHeight() * 2f;
      Enums.ePowerState ePowerState2 = iSlot.State;
      if (ePowerState2 == Enums.ePowerState.Empty & ePowerState1 == Enums.ePowerState.Open)
        ePowerState2 = ePowerState1;
      switch (ePowerState2)
      {
        case Enums.ePowerState.Disabled:
          solidBrush1 = new SolidBrush(Color.Transparent);
          s = "";
          break;
        case Enums.ePowerState.Empty:
          solidBrush1 = new SolidBrush(Color.WhiteSmoke);
          s = "(" + Conversions.ToString(checked (iSlot.Level + 1)) + ")";
          break;
        case Enums.ePowerState.Used:
          switch (iSlot.PowerSet.SetType)
          {
            case Enums.ePowerSetType.Primary:
              str = "(Pri)";
              break;
            case Enums.ePowerSetType.Secondary:
              str = "(Sec)";
              break;
            case Enums.ePowerSetType.Ancillary:
              str = "(Ancil)";
              break;
            case Enums.ePowerSetType.Inherent:
              str = "";
              break;
            case Enums.ePowerSetType.Pool:
              str = "(Pool)";
              break;
          }
          solidBrush1 = new SolidBrush(Color.Black);
          if (iSlot.Virtual)
          {
            s = iSlot.Name;
            break;
          }
          s = "(" + Conversions.ToString(checked (iSlot.Level + 1)) + ") " + iSlot.Name + " " + str;
          break;
        case Enums.ePowerState.Open:
          solidBrush1 = new SolidBrush(Color.Yellow);
          s = "(" + Conversions.ToString(checked (iSlot.Level + 1)) + ")";
          break;
      }
      if (ePowerState1 == Enums.ePowerState.Empty & iSlot.State == Enums.ePowerState.Used)
        solidBrush1 = new SolidBrush(Color.WhiteSmoke);
      if (this.InterfaceMode == Enums.eInterfaceMode.PowerToggle && solidBrush1.Color == Color.Black && !iSlot.CanIncludeForStats())
        solidBrush1 = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
      format.FormatFlags |= StringFormatFlags.NoWrap;
      if (MidsContext.Config.EnhanceVisibility)
      {
        string iStr = s;
        RectangleF Bounds = this.ScaleDown(iValue1);
        Color whiteSmoke = Color.WhiteSmoke;
        Color Outline = Color.FromArgb(192, 0, 0, 0);
        Font bFont = font;
        float OutlineSpace = 1f;
        Graphics graphics2 = this.bxBuffer.Graphics;
        clsDrawX.DrawOutlineText(iStr, Bounds, whiteSmoke, Outline, bFont, OutlineSpace, ref graphics2, false, true);
      }
      else
        this.bxBuffer.Graphics.DrawString(s, font, (Brush) solidBrush1, this.ScaleDown(iValue1), format);
      return point1;
    }

    private PathGradientBrush MakePathBrush(
      Rectangle iRect,
      PointF iCenter,
      Color iColor1,
      Color icolor2)
    {
      float num1 = (float) iRect.Left + (float) iRect.Width * 0.5f;
      float num2 = (float) iRect.Top + (float) iRect.Height * 0.5f;
      GraphicsPath path = new GraphicsPath();
      path.AddEllipse(iRect);
      Color[] colorArray = new Color[checked (path.PathPoints.GetUpperBound(0) + 1)];
      int lowerBound = path.PathPoints.GetLowerBound(0);
      int upperBound = path.PathPoints.GetUpperBound(0);
      int index = lowerBound;
      while (index <= upperBound)
      {
        colorArray[index] = icolor2;
        checked { ++index; }
      }
      return new PathGradientBrush(path)
      {
        CenterColor = iColor1,
        SurroundColors = colorArray,
        CenterPoint = new PointF(num1 + (iCenter.X + iCenter.X * ((float) iRect.Width * 0.5f)), num2 + (iCenter.Y + iCenter.Y * ((float) iRect.Height * 0.5f)))
      };
    }

    public void FullRedraw()
    {
      this.ColourSwitch();
      this.BackColor = this.cTarget.BackColor;
      this.bxBuffer.Graphics.Clear(this.BackColor);
      this.DrawPowers();
      this.OutputUnscaled(ref this.bxBuffer, new Point(0, 0));
      GC.Collect();
    }

    public void Refresh(Rectangle Clip)
    {
      this.OutputRefresh(Clip, Clip, GraphicsUnit.Pixel);
    }

    private int GetVisualIDX(int PowerIndex)
    {
      int nidPowerset = MidsContext.Character.CurrentBuild.Powers[PowerIndex].NIDPowerset;
      int idxPower = MidsContext.Character.CurrentBuild.Powers[PowerIndex].IDXPower;
      int num;
      if (nidPowerset > -1)
      {
        if (DatabaseAPI.Database.Powersets[nidPowerset].SetType == Enums.ePowerSetType.Inherent)
        {
          num = DatabaseAPI.Database.Powersets[nidPowerset].Powers[idxPower].LocationIndex;
        }
        else
        {
          num = -1;
          int index = 0;
          while (index <= PowerIndex)
          {
            if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset > -1)
            {
              if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset].SetType != Enums.ePowerSetType.Inherent)
                checked { ++num; }
            }
            else
              checked { ++num; }
            checked { ++index; }
          }
        }
      }
      else
      {
        num = -1;
        int index = 0;
        while (index <= PowerIndex)
        {
          if (MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset > -1)
          {
            if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset].SetType != Enums.ePowerSetType.Inherent)
              checked { ++num; }
          }
          else
            checked { ++num; }
          checked { ++index; }
        }
      }
      return num;
    }

    public static void DrawOutlineText(
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

    public int WhichSlot(int iX, int iY)
    {
      int num1 = 0;
      int num2 = checked (MidsContext.Character.CurrentBuild.Powers.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        Point point = !(MidsContext.Character.CurrentBuild.Powers[index].Power == null | MidsContext.Character.CurrentBuild.Powers[index].Chosen) ? this.PowerPosition(index) : this.PowerPosition(this.GetVisualIDX(index));
        if (iX >= point.X & iY >= point.Y && iX < checked (this.szPower.Width + point.X) & iY < checked (point.Y + this.szPower.Height + 17))
          return index;
        checked { ++index; }
      }
      return -1;
    }

    public int WhichEnh(int iX, int iY)
    {
      int num1 = -1;
      int index1 = -1;
      int num2 = 0;
      int num3 = checked (MidsContext.Character.CurrentBuild.Powers.Count - 1);
      Point point = new Point();
      int index2 = num2;
      while (index2 <= num3)
      {
        point = !(MidsContext.Character.CurrentBuild.Powers[index2].Power == null | MidsContext.Character.CurrentBuild.Powers[index2].Chosen) ? this.PowerPosition(index2) : this.PowerPosition(this.GetVisualIDX(index2));
        if (iX >= point.X & iY >= point.Y && iX < checked (this.szPower.Width + point.X) & iY < checked (point.Y + this.szPower.Height + 17))
        {
          index1 = index2;
          break;
        }
        checked { ++index2; }
      }
      if (index1 > -1)
      {
        bool flag = false;
        if (iY >= checked (point.Y + 18))
        {
          if (MidsContext.Character.CurrentBuild.Powers[index1].NIDPowerset > -1)
          {
            if (DatabaseAPI.Database.Powersets[MidsContext.Character.CurrentBuild.Powers[index1].NIDPowerset].Powers[MidsContext.Character.CurrentBuild.Powers[index1].IDXPower].Slottable)
              flag = true;
          }
          else
            flag = true;
        }
        if (flag)
        {
          int length = MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length;
          iX = checked ((int) Math.Round(unchecked ((double) iX - (double) point.X + (double) checked (this.szPower.Width - this.szSlot.Width * 6) / 2.0)));
          int num4 = 0;
          int num5 = checked (length - 1);
          int num6 = num4;
          while (num6 <= num5)
          {
            if (iX <= checked (num6 + 1 * this.szSlot.Width))
            {
              num1 = num6;
              break;
            }
            checked { ++num6; }
          }
          return num1;
        }
        num1 = -1;
      }
      return num1;
    }

    public bool HighlightSlot(int Index, bool Force = false)
    {
      if (MidsContext.Character.CurrentBuild.Powers.Count < 1 || !(this.Highlight != Index | Force))
        return false;
      if (Index != -1)
      {
        PowerEntry power;
        Point point1;
        Rectangle iValue;
        if (this.Highlight != -1 && this.Highlight < MidsContext.Character.CurrentBuild.Powers.Count)
        {
          Build currentBuild = MidsContext.Character.CurrentBuild;
          List<PowerEntry> powers = currentBuild.Powers;
          int highlight = this.Highlight;
          power = powers[highlight];
          Point point2 = this.DrawPowerSlot(ref power, false);
          currentBuild.Powers[highlight] = power;
          point1 = point2;
          iValue = new Rectangle(point1.X, point1.Y, this.szPower.Width, checked (this.szPower.Height + 17));
          Rectangle rectangle = this.ScaleDown(iValue);
          this.DrawSplit();
          this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
        }
        this.Highlight = Index;
        Build currentBuild1 = MidsContext.Character.CurrentBuild;
        power = currentBuild1.Powers[Index];
        Point point3 = this.DrawPowerSlot(ref power, true);
        currentBuild1.Powers[Index] = power;
        point1 = point3;
        iValue = new Rectangle(point1.X, point1.Y, this.szPower.Width, checked (this.szPower.Height + 17));
        Rectangle rectangle1 = this.ScaleDown(iValue);
        this.DrawSplit();
        this.Output(ref this.bxBuffer, rectangle1, rectangle1, GraphicsUnit.Pixel);
      }
      else if (this.Highlight != -1)
      {
        Build currentBuild = MidsContext.Character.CurrentBuild;
        List<PowerEntry> powers = currentBuild.Powers;
        int highlight = this.Highlight;
        PowerEntry iSlot = powers[highlight];
        Point point1 = this.DrawPowerSlot(ref iSlot, false);
        currentBuild.Powers[highlight] = iSlot;
        Point point2 = point1;
        Rectangle rectangle = this.ScaleDown(new Rectangle(point2.X, point2.Y, this.szPower.Width, checked (this.szPower.Height + 17)));
        this.DrawSplit();
        this.Output(ref this.bxBuffer, rectangle, rectangle, GraphicsUnit.Pixel);
        this.Highlight = Index;
      }
      return false;
    }

    private void Blank()
    {
      if (this.bxBuffer == null)
        return;
      this.bxBuffer.Graphics.Clear(this.BackColor);
    }

    public void SetScaling(Size iSize)
    {
      bool scaleEnabled = this.ScaleEnabled;
      float scaleValue = this.ScaleValue;
      if (iSize.Width < 10 | iSize.Height < 10)
        return;
      Size drawingArea = this.GetDrawingArea();
      if (drawingArea.Width > iSize.Width | drawingArea.Height > iSize.Height)
      {
        this.ScaleEnabled = true;
        this.ScaleValue = (double) drawingArea.Width / (double) iSize.Width <= (double) drawingArea.Height / (double) iSize.Height ? (float) drawingArea.Height / (float) iSize.Height : (float) drawingArea.Width / (float) iSize.Width;
        this.ResetTarget();
        this.bxBuffer.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;
        this.bxBuffer.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        this.bxBuffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        if ((double) this.ScaleValue == (double) scaleValue)
          return;
        this.FullRedraw();
        this.bxBuffer.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;
        this.bxBuffer.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        this.bxBuffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        this.bxBuffer.Graphics.SmoothingMode = SmoothingMode.HighQuality;
      }
      else
      {
        this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        this.ScaleValue = 1f;
        this.ResetTarget();
        this.ScaleEnabled = false;
        if (scaleEnabled != this.ScaleEnabled | (double) scaleValue != (double) this.ScaleValue)
          this.FullRedraw();
      }
    }

    private void ResetTarget()
    {
      this.bxBuffer.Graphics.TextRenderingHint = (double) this.ScaleValue <= 1.125 ? TextRenderingHint.AntiAliasGridFit : TextRenderingHint.ClearTypeGridFit;
      this.gTarget.Dispose();
      this.gTarget = this.cTarget.CreateGraphics();
      this.gTarget.CompositingQuality = CompositingQuality.AssumeLinear;
      this.gTarget.CompositingMode = CompositingMode.SourceCopy;
      this.gTarget.PixelOffsetMode = PixelOffsetMode.None;
      this.gTarget.SmoothingMode = SmoothingMode.None;
    }

    public int ScaleDown(int iValue)
    {
      if (!this.ScaleEnabled)
        return iValue;
      iValue = checked ((int) Math.Round(unchecked ((double) iValue / (double) this.ScaleValue)));
      return iValue;
    }

    public int ScaleUp(int iValue)
    {
      if (!this.ScaleEnabled)
        return iValue;
      iValue = checked ((int) Math.Round(unchecked ((double) iValue * (double) this.ScaleValue)));
      return iValue;
    }

    private float ScaleDown(float iValue)
    {
      if (!this.ScaleEnabled)
        return iValue;
      iValue /= this.ScaleValue;
      return iValue;
    }

    public Rectangle ScaleDown(Rectangle iValue)
    {
      if (!this.ScaleEnabled)
        return iValue;
      iValue.X = checked ((int) Math.Round(unchecked ((double) iValue.X / (double) this.ScaleValue)));
      iValue.Y = checked ((int) Math.Round(unchecked ((double) iValue.Y / (double) this.ScaleValue)));
      iValue.Width = checked ((int) Math.Round(unchecked ((double) iValue.Width / (double) this.ScaleValue)));
      iValue.Height = checked ((int) Math.Round(unchecked ((double) iValue.Height / (double) this.ScaleValue)));
      return iValue;
    }

    private RectangleF ScaleDown(RectangleF iValue)
    {
      if (!this.ScaleEnabled)
        return iValue;
      iValue.X = (float) checked ((int) Math.Round(unchecked ((double) iValue.X / (double) this.ScaleValue)));
      iValue.Y = (float) checked ((int) Math.Round(unchecked ((double) iValue.Y / (double) this.ScaleValue)));
      iValue.Width = (float) checked ((int) Math.Round(unchecked ((double) iValue.Width / (double) this.ScaleValue)));
      iValue.Height = (float) checked ((int) Math.Round(unchecked ((double) iValue.Height / (double) this.ScaleValue)));
      return iValue;
    }

    private void Output(
      ref ExtendedBitmap Buffer,
      Rectangle DestRect,
      Rectangle SrcRect,
      GraphicsUnit iUnit)
    {
      this.gTarget.DrawImage((Image) Buffer.Bitmap, DestRect, SrcRect, iUnit);
    }

    private void OutputRefresh(Rectangle DestRect, Rectangle SrcRect, GraphicsUnit iUnit)
    {
      this.gTarget.DrawImage((Image) this.bxBuffer.Bitmap, DestRect, SrcRect, iUnit);
    }

    private void OutputUnscaled(ref ExtendedBitmap Buffer, Point Location)
    {
      this.gTarget.DrawImageUnscaled((Image) Buffer.Bitmap, Location);
    }

    public void ColourSwitch()
    {
      bool flag = true;
      if (this.pColorMatrix == null)
        this.pColorMatrix = new ColorMatrix();
      if (MidsContext.Character != null)
        flag = MidsContext.Character.IsHero();
      if (!MidsContext.Config.ShowVillainColours)
        flag = true;
      this.VillainColor = !flag;
      if (flag)
        this.pColorMatrix = new ColorMatrix(new float[5][]
        {
          new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
        });
      else
        this.pColorMatrix = new ColorMatrix(new float[5][]
        {
          new float[5]{ 0.45f, 0.0f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.35f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.75f, 0.0f, 0.175f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
        });
      if (this.pImageAttributes == null)
        this.pImageAttributes = new ImageAttributes();
      this.pImageAttributes.SetColorMatrix(this.pColorMatrix);
    }

    public static ImageAttributes GetRecolourIa(bool hero)
    {
      ColorMatrix newColorMatrix;
      if (hero)
        newColorMatrix = new ColorMatrix(new float[5][]
        {
          new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
        });
      else
        newColorMatrix = new ColorMatrix(new float[5][]
        {
          new float[5]{ 0.45f, 0.0f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.35f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.75f, 0.0f, 0.175f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
        });
      ImageAttributes imageAttributes = new ImageAttributes();
      imageAttributes.SetColorMatrix(newColorMatrix);
      return imageAttributes;
    }

    private ImageAttributes GreySlot(bool grey, bool bypassIa = false)
    {
      if (grey)
      {
        ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
        {
          new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
          new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
        });
        int index1 = 0;
        do
        {
          int index2 = 0;
          do
          {
            if (!bypassIa)
              newColorMatrix[index1, index2] = this.pColorMatrix[index1, index2];
            if (index1 != 4)
              newColorMatrix[index1, index2] /= 1.5f;
            checked { ++index2; }
          }
          while (index2 <= 2);
          checked { ++index1; }
        }
        while (index1 <= 2);
        ImageAttributes imageAttributes = new ImageAttributes();
        imageAttributes.SetColorMatrix(newColorMatrix);
        return imageAttributes;
      }
      if (bypassIa)
        return new ImageAttributes();
      return this.pImageAttributes;
    }

    private ImageAttributes Desaturate(bool Grey, bool BypassIA = false)
    {
      ColorMatrix colorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 0.299f, 0.299f, 0.299f, 0.0f, 0.0f },
        new float[5]{ 0.587f, 0.587f, 0.587f, 0.0f, 0.0f },
        new float[5]
        {
          57f / 500f,
          57f / 500f,
          57f / 500f,
          0.0f,
          0.0f
        },
        new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      ColorMatrix newColorMatrix = new ColorMatrix(new float[5][]
      {
        new float[5]{ 1f, 0.0f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 1f, 0.0f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 1f, 0.0f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 1f, 0.0f },
        new float[5]{ 0.0f, 0.0f, 0.0f, 0.0f, 1f }
      });
      int index1 = 0;
      do
      {
        int index2 = 0;
        do
        {
          if (!BypassIA)
            newColorMatrix[index1, index2] = (float) (((double) this.pColorMatrix[index1, index2] + (double) colorMatrix[index1, index2]) / 2.0);
          if (Grey & index1 != 4)
            newColorMatrix[index1, index2] /= 1.5f;
          checked { ++index2; }
        }
        while (index2 <= 2);
        checked { ++index1; }
      }
      while (index1 <= 2);
      ImageAttributes imageAttributes = new ImageAttributes();
      imageAttributes.SetColorMatrix(newColorMatrix);
      return imageAttributes;
    }

    public Rectangle PowerBoundsUnScaled(int hIdx)
    {
      Rectangle rectangle = new Rectangle(0, 0, 1, 1);
      if (hIdx < 0 | hIdx > checked (MidsContext.Character.CurrentBuild.Powers.Count - 1))
        return rectangle;
      rectangle.Location = !(!MidsContext.Character.CurrentBuild.Powers[hIdx].Chosen & MidsContext.Character.CurrentBuild.Powers[hIdx].Power != null) ? this.PowerPosition(this.GetVisualIDX(hIdx)) : this.PowerPosition(hIdx);
      rectangle.Width = this.szPower.Width;
      int num = checked (rectangle.Y + 18 + this.szSlot.Height);
      rectangle.Height = checked (num - rectangle.Y);
      return rectangle;
    }

    public bool WithinPowerBar(Rectangle pBounds, Point e)
    {
      pBounds.Height = this.szPower.Height;
      return e.X >= pBounds.Left & e.X < pBounds.Right && e.Y >= pBounds.Top & e.Y < pBounds.Bottom;
    }

    private Point PowerPosition(int powerEntryIdx)
    {
      return this.PowerPosition(MidsContext.Character.CurrentBuild.Powers[powerEntryIdx], -1);
    }

    private int[][] GetInherentGrid()
    {
      switch (this.vcCols)
      {
        case 2:
          if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic)
            return new int[19][]
            {
              new int[2]{ 3, 17 },
              new int[2]{ 0, 18 },
              new int[2]{ 1, 19 },
              new int[2]{ 2, 20 },
              new int[2]{ 4, 10 },
              new int[2]{ 5, 11 },
              new int[2]{ 6, 12 },
              new int[2]{ 7, 13 },
              new int[2]{ 8, 14 },
              new int[2]{ 9, 15 },
              new int[2]{ 18, 21 },
              new int[2]{ 22, 23 },
              new int[2]{ 24, 25 },
              new int[2]{ 16, 17 },
              new int[2]{ 26, 27 },
              new int[2]{ 28, 29 },
              new int[2]{ 30, 31 },
              new int[2]{ 32, 33 },
              new int[2]{ 34, 35 }
            };
          return new int[15][]
          {
            new int[2]{ 3, 17 },
            new int[2]{ 0, 18 },
            new int[2]{ 1, 19 },
            new int[2]{ 2, 20 },
            new int[2]{ 16, 21 },
            new int[2]{ 6, 22 },
            new int[2]{ 7, 23 },
            new int[2]{ 8, 24 },
            new int[2]{ 9, 25 },
            new int[2]{ 10, 11 },
            new int[2]{ 26, 27 },
            new int[2]{ 28, 29 },
            new int[2]{ 30, 31 },
            new int[2]{ 32, 33 },
            new int[2]{ 34, 35 }
          };
        case 4:
          if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic)
            return new int[9][]
            {
              new int[4]{ 3, 17, 4, 10 },
              new int[4]{ 0, 18, 5, 11 },
              new int[4]{ 1, 19, 6, 12 },
              new int[4]{ 2, 20, 7, 13 },
              new int[4]{ 16, 21, 8, 14 },
              new int[4]{ 22, 23, 9, 15 },
              new int[4]{ 24, 25, 26, 17 },
              new int[4]{ 28, 29, 30, 31 },
              new int[4]{ 32, 33, 34, 35 }
            };
          return new int[8][]
          {
            new int[4]{ 3, 17, 21, 16 },
            new int[4]{ 0, 18, 22, 6 },
            new int[4]{ 1, 19, 23, 7 },
            new int[4]{ 2, 20, 24, 8 },
            new int[4]{ 26, 27, 25, 9 },
            new int[4]{ 28, 29, 30, 10 },
            new int[4]{ 31, 32, 33, 11 },
            new int[4]{ 34, 35, 4, 5 }
          };
        default:
          if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.HeroEpic)
            return new int[12][]
            {
              new int[3]{ 3, 17, 4 },
              new int[3]{ 0, 18, 5 },
              new int[3]{ 1, 19, 10 },
              new int[3]{ 2, 20, 11 },
              new int[3]{ 21, 6, 12 },
              new int[3]{ 22, 7, 13 },
              new int[3]{ 23, 8, 14 },
              new int[3]{ 24, 9, 15 },
              new int[3]{ 25, 16, 26 },
              new int[3]{ 27, 28, 29 },
              new int[3]{ 30, 31, 32 },
              new int[3]{ 33, 34, 35 }
            };
          return new int[10][]
          {
            new int[3]{ 3, 17, 21 },
            new int[3]{ 0, 18, 22 },
            new int[3]{ 1, 19, 23 },
            new int[3]{ 2, 20, 24 },
            new int[3]{ 6, 16, 25 },
            new int[3]{ 7, 26, 27 },
            new int[3]{ 8, 28, 29 },
            new int[3]{ 9, 30, 31 },
            new int[3]{ 10, 32, 33 },
            new int[3]{ 11, 34, 35 }
          };
      }
    }

    public Point PowerPosition(PowerEntry powerEntry, int displayLocation = -1)
    {
      int num1 = MidsContext.Character.CurrentBuild.Powers.IndexOf(powerEntry);
      if (num1 == -1)
      {
        int num2 = 0;
        int num3 = checked (MidsContext.Character.CurrentBuild.Powers.Count - 1);
        int index = num2;
        while (index <= num3)
        {
          if (MidsContext.Character.CurrentBuild.Powers[index].Power.PowerIndex == powerEntry.Power.PowerIndex & MidsContext.Character.CurrentBuild.Powers[index].Level == powerEntry.Level)
          {
            num1 = index;
            break;
          }
          checked { ++index; }
        }
      }
      int[][] inherentGrid = this.GetInherentGrid();
      bool flag = false;
      int iRow = 0;
      int iCol = 0;
      if (!powerEntry.Chosen)
      {
        if (displayLocation == -1 & powerEntry.Power != null)
        {
          if (Operators.CompareString(powerEntry.Power.GroupName, "Incarnate", false) == 0)
          {
            string setName = powerEntry.PowerSet.SetName;
            displayLocation = Operators.CompareString(setName, "Alpha", false) != 0 ? (Operators.CompareString(setName, "Judgement", false) != 0 ? (Operators.CompareString(setName, "Interface", false) != 0 ? (Operators.CompareString(setName, "Lore", false) != 0 ? (Operators.CompareString(setName, "Destiny", false) != 0 ? (Operators.CompareString(setName, "Hybrid", false) != 0 ? (Operators.CompareString(setName, "Genesis", false) != 0 ? (Operators.CompareString(setName, "Stance", false) != 0 ? (Operators.CompareString(setName, "Vitae", false) != 0 ? (Operators.CompareString(setName, "Omega", false) != 0 ? powerEntry.Power.DisplayLocation : 35) : 34) : 33) : 32) : 31) : 30) : 29) : 28) : 27) : 26;
          }
          else
            displayLocation = powerEntry.Power.DisplayLocation;
        }
        if (displayLocation > -1)
        {
          iRow = this.vcRowsPowers;
          int num2 = 0;
          int num3 = checked (inherentGrid.Length - 1);
          int index1 = num2;
          while (index1 <= num3)
          {
            int num4 = 0;
            int num5 = checked (inherentGrid[index1].Length - 1);
            int index2 = num4;
            while (index2 <= num5)
            {
              if (!flag & displayLocation == inherentGrid[index1][index2])
              {
                checked { iRow += index1; }
                iCol = index2;
                flag = true;
                break;
              }
              checked { ++index2; }
            }
            if (!flag)
              checked { ++index1; }
            else
              break;
          }
        }
      }
      else if (num1 > -1)
      {
        int num2 = 1;
        int vcCols = this.vcCols;
        int num3 = num2;
        while (num3 <= vcCols)
        {
          if (num1 < checked (this.vcRowsPowers * num3))
          {
            iCol = checked (num3 - 1);
            iRow = checked (num1 - this.vcRowsPowers * iCol);
            break;
          }
          checked { ++num3; }
        }
      }
      return this.CRtoXY(iCol, iRow);
    }

    private Point CRtoXY(int iCol, int iRow)
    {
      Point point = new Point(0, 0);
      if (iRow >= this.vcRowsPowers)
      {
        point.X = checked (iCol * this.szPower.Width + 7);
        point.Y = checked (4 + iRow * (this.szPower.Height + 17));
      }
      else
      {
        point.X = checked (iCol * this.szPower.Width + 7);
        point.Y = checked (iRow * this.szPower.Height + 17);
      }
      return point;
    }

    public Size GetDrawingArea()
    {
      Size size1 = (Size) this.PowerPosition(23);
      checked { size1.Width += this.szPower.Width; }
      size1.Height = checked (size1.Height + this.szPower.Height + 17);
      int num1 = 0;
      int num2 = checked (MidsContext.Character.CurrentBuild.Powers.Count - 1);
      int powerEntryIdx = num1;
      while (powerEntryIdx <= num2)
      {
        if (MidsContext.Character.CurrentBuild.Powers[powerEntryIdx].Power != null & !(MidsContext.Character.CurrentBuild.Powers[powerEntryIdx].Chosen & powerEntryIdx > MidsContext.Character.CurrentBuild.LastPower))
        {
          Size size2 = new Size(size1.Width, checked (this.PowerPosition(powerEntryIdx).Y + this.szPower.Height + 17));
          if (size2.Height > size1.Height)
            size1.Height = size2.Height;
          if (size2.Width > size1.Width)
            size1.Width = size2.Width;
        }
        checked { ++powerEntryIdx; }
      }
      return size1;
    }

    private Size GetMaxDrawingArea()
    {
      int vcCols = this.vcCols;
      this.MiniSetCol(4);
      Size size1 = (Size) this.PowerPosition(23);
      this.MiniSetCol(2);
      int[][] inherentGrid = this.GetInherentGrid();
      Size size2 = (Size) this.CRtoXY(checked (inherentGrid[inherentGrid.Length - 1].Length - 1), checked (inherentGrid.Length - 1));
      if (size2.Height > size1.Height)
        size1.Height = size2.Height;
      if (size2.Width > size1.Width)
        size1.Width = size2.Width;
      this.MiniSetCol(vcCols);
      checked { size1.Width += this.szPower.Width; }
      size1.Height = checked (size1.Height + this.szPower.Height + 17);
      return size1;
    }

    private void MiniSetCol(int cols)
    {
      if (cols == this.vcCols || cols < 2 | cols > 4)
        return;
      this.vcCols = cols;
      this.vcRowsPowers = checked ((int) Math.Round(unchecked (24.0 / (double) this.vcCols)));
    }

    public Size GetRequiredDrawingArea()
    {
      int num1 = -1;
      int num2 = -1;
      int num3 = 0;
      int num4 = checked (MidsContext.Character.CurrentBuild.Powers.Count - 1);
      int powerEntryIdx = num3;
      while (powerEntryIdx <= num4)
      {
        if (MidsContext.Character.CurrentBuild.Powers[powerEntryIdx].IDXPower > -1 | MidsContext.Character.CurrentBuild.Powers[powerEntryIdx].Chosen)
        {
          Point point = this.PowerPosition(powerEntryIdx);
          if (point.X > num2)
            num2 = point.X;
          if (point.Y > num1)
            num1 = point.Y;
        }
        checked { ++powerEntryIdx; }
      }
      if (num2 > -1 & num1 > -1)
        return new Size(checked (num2 + this.szPower.Width), checked (num1 + this.szPower.Height + 17));
      Point point1 = this.PowerPosition(MidsContext.Character.CurrentBuild.LastPower);
      return new Size(checked (point1.X + this.szPower.Width), checked (point1.Y + this.szPower.Height + 17 + 4));
    }
  }
}
