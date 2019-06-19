// Decompiled with JetBrains decompiler
// Type: midsControls.I9Picker
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace midsControls
{
  public class I9Picker : UserControl
  {
    private const int IOMax = 50;
    private const int Cols = 5;
    private const int DilateVal = 2;
    private const double timerResetDelay = 5.0;
    private Point _mouseOffset;
    private int _rows;
    private clsDrawX _hDraw;
    private I9Slot _mySlot;
    private ExtendedBitmap _myBx;
    private Point _hoverCell;
    private string _hoverTitle;
    private string _hoverText;
    private int _headerHeight;
    private int[] _mySlotted;
    private bool _levelCapped;
    private int _userLevel;
    private Enums.eType _lastTab;
    private int _lastSet;
    public int LastLevel;
    private Enums.eEnhGrade _lastGrade;
    private Enums.eEnhRelative _lastRelativeLevel;
    private Enums.eSubtype _lastSpecial;
    private double _timerLastKeypress;
    public I9Picker.cTracking UI;
    private int _nPad;
    private int _nSize;
    private Color _cHighlight;
    private Color _cSelected;
    private int _nPowerIDX;
    private IContainer components;
    [AccessedThroughProperty("tTip")]
    private ToolTip _tTip;

    public event I9Picker.EnhancementPickedEventHandler EnhancementPicked;

    public event I9Picker.HoverEnhancementEventHandler HoverEnhancement;

    public event I9Picker.HoverSetEventHandler HoverSet;

    public event I9Picker.MovedEventHandler Moved;

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

    public I9Slot Slot
    {
      get
      {
        return this._mySlot;
      }
    }

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

    public int Padding
    {
      get
      {
        return this._nPad;
      }
      set
      {
        if (value < 0)
          value = 0;
        if (value > 100)
          value = 100;
        this._nPad = value;
        this.FullDraw();
      }
    }

    public int ImageSize
    {
      get
      {
        return this._nSize;
      }
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

    public I9Picker()
    {
      this.Load += new EventHandler(this.I9PickerLoad);
      this.Paint += new PaintEventHandler(this.I9PickerPaint);
      this.KeyDown += new KeyEventHandler(this.I9PickerKeyDown);
      this.MouseDown += new MouseEventHandler(this.I9PickerMouseDown);
      this.MouseMove += new MouseEventHandler(this.I9PickerMouseMove);
      this._rows = 5;
      this._hoverCell = new Point(-1, -1);
      this._hoverTitle = "";
      this._hoverText = "";
      this._mySlotted = new int[0];
      this._levelCapped = false;
      this._userLevel = -1;
      this._lastTab = Enums.eType.Normal;
      this._lastSet = 0;
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
      this.BackColor = Color.Silver;
      this.Name = nameof (I9Picker);
      this.Size = new Size(184, 244);
    }

    private void I9PickerLoad(object sender, EventArgs e)
    {
      this.FullDraw();
    }

    private void SetBxSize()
    {
      if (this._myBx == null)
        this._myBx = new ExtendedBitmap(this.Width, this.Height);
      else if (this._myBx.Size.Width != this.Width | this._myBx.Size.Height != this.Height)
        this._myBx = new ExtendedBitmap(this.Width, this.Height);
      this._myBx.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    }

    private void FullDraw()
    {
      this.SetBxSize();
      this.DrawLayerLowest();
      if (this._hDraw == null)
        return;
      this.DrawLayerImages();
      this.I9PickerPaint((object) this, new PaintEventArgs(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height)));
    }

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

    private void DrawLayerImages()
    {
      this.DrawTypeImages();
      this.DrawEnhImages();
    }

    private void DrawHeaderBox()
    {
      Font font = new Font(this.Font, FontStyle.Bold);
      SolidBrush solidBrush = new SolidBrush(Color.White);
      string str = "";
      Pen pen = new Pen(this.ForeColor);
      Rectangle iRect = new Rectangle();
      iRect.X = this._nPad;
      iRect.Y = this._nPad;
      iRect.Width = checked (this._nSize * 5 + this._nPad * 4);
      iRect.Height = checked ((int) Math.Round((double) font.GetHeight(this._myBx.Graphics)));
      this._headerHeight = checked (iRect.Height + this._nPad);
      RectangleF layoutRectangle = new RectangleF((float) iRect.X, (float) iRect.Y, (float) iRect.Width, (float) iRect.Height);
      this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(iRect, 2));
      if (this._nPowerIDX > -1)
        str = "Enhancing: " + DatabaseAPI.Database.Power[this._nPowerIDX].DisplayName;
      if (Operators.CompareString(str, "", false) == 0)
        return;
      this._myBx.Graphics.DrawString(str, font, (Brush) solidBrush, layoutRectangle);
    }

    private void DrawLevelBox()
    {
      Pen pen = new Pen(this.ForeColor);
      Font font1 = new Font(this.Font, FontStyle.Bold);
      SolidBrush solidBrush1 = new SolidBrush(Color.White);
      Rectangle rectBounds = this.GetRectBounds(4, checked (this._rows + 1));
      checked { rectBounds.Y += 2; }
      rectBounds.Height = checked (this.Height - rectBounds.Y + this._nPad);
      this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(rectBounds, 2));
      StringFormat format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
      format.Alignment = StringAlignment.Center;
      format.Trimming = StringTrimming.None;
      RectangleF layoutRectangle = new RectangleF((float) rectBounds.X, (float) rectBounds.Y, (float) rectBounds.Width, (float) rectBounds.Height);
      this._myBx.Graphics.DrawString("LVL", font1, (Brush) solidBrush1, layoutRectangle, format);
      layoutRectangle.Y += font1.GetHeight(this._myBx.Graphics) + 3f;
      rectBounds.Height = checked (this.Height - rectBounds.Y + this._nPad);
      SolidBrush solidBrush2 = new SolidBrush(this.ForeColor);
      Font font2 = new Font("Arial", 19f, FontStyle.Bold, GraphicsUnit.Pixel);
      this._myBx.Graphics.DrawString(!(this.UI.View.TabID == Enums.eType.InventO | this.UI.View.TabID == Enums.eType.SetO) ? I9Picker.GetRelativeString(this.UI.View.RelLevel) : Conversions.ToString(this.UI.View.IOLevel), font2, (Brush) solidBrush2, layoutRectangle, format);
    }

    private static string GetRelativeString(Enums.eEnhRelative iRel)
    {
      switch (iRel)
      {
        case Enums.eEnhRelative.None:
          return "X";
        case Enums.eEnhRelative.MinusThree:
          return "-3";
        case Enums.eEnhRelative.MinusTwo:
          return "-2";
        case Enums.eEnhRelative.MinusOne:
          return "-1";
        case Enums.eEnhRelative.Even:
          return "+/-";
        case Enums.eEnhRelative.PlusOne:
          return "+1";
        case Enums.eEnhRelative.PlusTwo:
          return "+2";
        case Enums.eEnhRelative.PlusThree:
          return "+3";
        case Enums.eEnhRelative.PlusFour:
          return "+4";
        case Enums.eEnhRelative.PlusFive:
          return "+5";
        default:
          return "!";
      }
    }

    private void DrawTextBox()
    {
      SolidBrush solidBrush = new SolidBrush(Color.White);
      Pen pen = new Pen(this.ForeColor);
      Rectangle iRect = new Rectangle();
      iRect.X = this._nPad;
      RectangleF layoutRectangle1 = new RectangleF();
      RectangleF layoutRectangle2 = new RectangleF();
      iRect.Y = checked (this._headerHeight + (this._nPad * 2 + this._nSize + (this._nSize * this._rows + this._nPad * (this._rows - 1))) + 2 + this._nPad);
      iRect.Height = checked (this.Height - iRect.Y + this._nPad);
      iRect.Width = checked (this._nSize * 4 + this._nPad * 3);
      layoutRectangle1.X = (float) iRect.X;
      layoutRectangle1.Y = (float) iRect.Y;
      layoutRectangle1.Width = (float) iRect.Width;
      layoutRectangle1.Height = this.Font.GetHeight(this._myBx.Graphics);
      layoutRectangle2.X = (float) iRect.X;
      layoutRectangle2.Y = (float) iRect.Y + layoutRectangle1.Height;
      layoutRectangle2.Width = (float) iRect.Width;
      layoutRectangle2.Height = (float) iRect.Height - layoutRectangle1.Height;
      this._myBx.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      float num1 = 1f;
      int num2 = checked ((int) Math.Round((double) this._myBx.Graphics.MeasureString(this._hoverTitle, this.Font, (int) Math.Round(unchecked ((double) layoutRectangle1.Width * 10.0))).Width));
      if ((double) num2 > (double) layoutRectangle1.Width - 10.0)
        num1 = (layoutRectangle1.Width - 10f) / (float) num2;
      if ((double) num1 < 0.5)
        num1 = 0.5f;
      Font font = new Font(this.Name, this.Font.Size * num1, FontStyle.Bold, this.Font.Unit, (byte) 0);
      this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(iRect, 2));
      if (Operators.CompareString(this._hoverTitle, "", false) != 0)
        this._myBx.Graphics.DrawString(this._hoverTitle, font, (Brush) solidBrush, layoutRectangle1);
      if (Operators.CompareString(this._hoverText, "", false) == 0)
        return;
      this._myBx.Graphics.DrawString(this._hoverText, this.Font, (Brush) solidBrush, layoutRectangle2);
    }

    private void SetInfoStrings(string title, string message)
    {
      this._hoverTitle = title;
      this._hoverText = message;
    }

    private void DrawTypeImages()
    {
      Rectangle srcRect = new Rectangle(0, 0, this._nSize, this._nSize);
      Enums.eType eType1 = Enums.eType.None;
      Rectangle rectBounds1 = this.GetRectBounds(0, 0);
      srcRect.X = checked (unchecked ((int) eType1) * this._nSize);
      this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhTypes.Bitmap, rectBounds1, srcRect.X, srcRect.Y, 30, 30, GraphicsUnit.Pixel, this._hDraw.pImageAttributes);
      Enums.eType eType2 = Enums.eType.Normal;
      Rectangle rectBounds2 = this.GetRectBounds(1, 0);
      srcRect.X = checked (unchecked ((int) eType2) * this._nSize);
      this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhTypes.Bitmap, rectBounds2, srcRect, GraphicsUnit.Pixel);
      Enums.eType eType3 = Enums.eType.InventO;
      Rectangle rectBounds3 = this.GetRectBounds(2, 0);
      srcRect.X = checked (unchecked ((int) eType3) * this._nSize);
      this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhTypes.Bitmap, rectBounds3, srcRect, GraphicsUnit.Pixel);
      Enums.eType eType4 = Enums.eType.SpecialO;
      Rectangle rectBounds4 = this.GetRectBounds(3, 0);
      srcRect.X = checked (unchecked ((int) eType4) * this._nSize);
      this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhTypes.Bitmap, rectBounds4, srcRect, GraphicsUnit.Pixel);
      Enums.eType eType5 = Enums.eType.SetO;
      Rectangle rectBounds5 = this.GetRectBounds(4, 0);
      srcRect.X = checked (unchecked ((int) eType5) * this._nSize);
      this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhTypes.Bitmap, rectBounds5, srcRect, GraphicsUnit.Pixel);
    }

    private void DrawEnhImages()
    {
      switch (this.UI.View.TabID)
      {
        case Enums.eType.Normal:
          int y1 = 1;
          int index1 = checked (this.UI.NOGrades.Length - 1);
          while (index1 >= 1)
          {
            Rectangle srcRect = new Rectangle(checked (this.UI.NOGrades[index1] * this._nSize), 0, this._nSize, this._nSize);
            this._myBx.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, this.GetRectBounds(4, y1), I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.Normal, (Enums.eEnhGrade) index1)), GraphicsUnit.Pixel);
            this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhGrades.Bitmap, this.GetRectBounds(4, y1), srcRect, GraphicsUnit.Pixel);
            checked { ++y1; }
            checked { index1 += -1; }
          }
          int num1 = 0;
          int num2 = checked (this.UI.NO.Length - 1);
          int index2 = num1;
          while (index2 <= num2)
          {
            Origin.Grade iGrade;
            switch (this.UI.View.GradeID)
            {
              case Enums.eEnhGrade.TrainingO:
                iGrade = Origin.Grade.TrainingO;
                break;
              case Enums.eEnhGrade.DualO:
                iGrade = Origin.Grade.DualO;
                break;
              case Enums.eEnhGrade.SingleO:
                iGrade = Origin.Grade.SingleO;
                break;
              default:
                iGrade = Origin.Grade.SingleO;
                break;
            }
            Graphics graphics = this._myBx.Graphics;
            I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(index2)), this.UI.NO[index2], iGrade);
            checked { ++index2; }
          }
          break;
        case Enums.eType.InventO:
          int num3 = 0;
          int num4 = checked (this.UI.IO.Length - 1);
          int index3 = num3;
          while (index3 <= num4)
          {
            Graphics graphics = this._myBx.Graphics;
            I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(index3)), this.UI.IO[index3], Origin.Grade.IO);
            checked { ++index3; }
          }
          break;
        case Enums.eType.SpecialO:
          int num5 = 1;
          int num6 = checked (this.UI.SpecialTypes.Length - 1);
          int y2 = num5;
          while (y2 <= num6)
          {
            Rectangle srcRect = new Rectangle(checked (this.UI.SpecialTypes[y2] * this._nSize), 0, this._nSize, this._nSize);
            this._myBx.Graphics.DrawImage((Image) I9Gfx.EnhSpecials.Bitmap, this.GetRectBounds(4, y2), srcRect, GraphicsUnit.Pixel);
            checked { ++y2; }
          }
          int num7 = 0;
          int num8 = checked (this.UI.SpecialO.Length - 1);
          int index4 = num7;
          while (index4 <= num8)
          {
            Graphics graphics = this._myBx.Graphics;
            I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(index4)), this.UI.SpecialO[index4], Origin.Grade.HO);
            checked { ++index4; }
          }
          break;
        case Enums.eType.SetO:
          int num9 = 0;
          int num10 = checked (this.UI.SetTypes.Length - 1);
          int index5 = num9;
          while (index5 <= num10)
          {
            Rectangle srcRect = new Rectangle(checked (this.UI.SetTypes[index5] * this._nSize), 0, this._nSize, this._nSize);
            this._myBx.Graphics.DrawImage((Image) I9Gfx.SetTypes.Bitmap, this.GetRectBounds(4, checked (index5 + 1)), srcRect, GraphicsUnit.Pixel);
            checked { ++index5; }
          }
          if (this.UI.View.SetID > -1)
          {
            this.DisplaySetEnhancements();
            break;
          }
          this.DisplaySetImages();
          break;
      }
    }

    private static ImageAttributes GreyItem(bool grey)
    {
      if (!grey)
        return new ImageAttributes();
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
          if (index1 != 4)
            newColorMatrix[index1, index2] /= 2f;
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

    private void DisplaySetEnhancements()
    {
      int num1 = 0;
      int num2 = checked (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements.Length - 1);
      int index1 = num1;
      while (index1 <= num2)
      {
        bool grey = false;
        int num3 = 0;
        int num4 = checked (this._mySlotted.Length - 1);
        int index2 = num3;
        while (index2 <= num4)
        {
          if (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index1] == this._mySlotted[index2])
            grey = true;
          checked { ++index2; }
        }
        Graphics graphics = this._myBx.Graphics;
        I9Gfx.DrawEnhancementAt(ref graphics, this.GetRectBounds(this.IndexToXY(index1)), DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index1], Origin.Grade.SetO, I9Picker.GreyItem(grey));
        checked { ++index1; }
      }
    }

    private bool IsPlaced(int index)
    {
      if (this.UI.View.TabID != Enums.eType.SetO || this.UI.View.SetID < 0 || (this.UI.View.SetTypeID >= this.UI.Sets.Length || this.UI.View.SetID >= this.UI.Sets[this.UI.View.SetTypeID].Length) || (this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID] >= DatabaseAPI.Database.EnhancementSets.Count || index >= DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements.Length || this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.Initial.SetID == this.UI.View.SetID & this.UI.Initial.PickerID == index))
        return false;
      int num1 = 0;
      int num2 = checked (this._mySlotted.Length - 1);
      int index1 = num1;
      while (index1 <= num2)
      {
        if (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index] == this._mySlotted[index1])
          return true;
        checked { ++index1; }
      }
      return false;
    }

    private void DisplaySetImages()
    {
      if (this.UI.View.TabID != Enums.eType.SetO || this.UI.View.SetTypeID <= -1)
        return;
      int num1 = 0;
      int num2 = checked (this.UI.Sets[this.UI.View.SetTypeID].Length - 1);
      int index = num1;
      while (index <= num2)
      {
        Rectangle srcRect = new Rectangle(checked (I9Gfx.OriginIndex * this._nSize), checked (4 * this._nSize), this._nSize, this._nSize);
        this._myBx.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, this.GetRectBounds(this.IndexToXY(index)), srcRect, GraphicsUnit.Pixel);
        srcRect = new Rectangle(checked (this.UI.Sets[this.UI.View.SetTypeID][index] * this._nSize), 0, this._nSize, this._nSize);
        this._myBx.Graphics.DrawImage((Image) I9Gfx.Sets.Bitmap, this.GetRectBounds(this.IndexToXY(index)), srcRect, GraphicsUnit.Pixel);
        checked { ++index; }
      }
    }

    private void DrawBorder()
    {
      this._myBx.Graphics.DrawRectangle(new Pen(this.ForeColor), new Rectangle()
      {
        X = 0,
        Y = 0,
        Height = checked (this.Height - 1),
        Width = checked (this.Width - 1)
      });
    }

    private void DrawHighlights()
    {
      this.DrawHighlight(this._hoverCell.X, this._hoverCell.Y);
      this.DrawSelected((int) this.UI.View.TabID, 0);
      if (this.UI.View.TabID == Enums.eType.SetO)
      {
        if (this.UI.View.SetTypeID > -1)
          this.DrawSelected(4, checked (this.UI.View.SetTypeID + 1));
      }
      else if (this.UI.View.TabID == Enums.eType.Normal)
      {
        if (this.UI.View.GradeID > ~Enums.eEnhGrade.None)
          this.DrawSelected(4, I9Picker.Reverse((int) this.UI.View.GradeID));
      }
      else if (this.UI.View.TabID == Enums.eType.SpecialO && this.UI.View.SpecialID > ~Enums.eSubtype.None)
        this.DrawSelected(4, (int) this.UI.View.SpecialID);
      if (this.UI.Initial.PickerID <= -1)
        return;
      if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.Initial.SetID == this.UI.View.SetID & this.UI.Initial.GradeID == this.UI.View.GradeID & this.UI.Initial.SpecialID == this.UI.View.SpecialID)
      {
        Point xy = this.IndexToXY(this.UI.Initial.PickerID);
        int x1 = xy.X;
        xy = this.IndexToXY(this.UI.Initial.PickerID);
        int y1 = xy.Y;
        this.DrawSelected(x1, y1);
        xy = this.IndexToXY(this.UI.Initial.PickerID);
        int x2 = xy.X;
        xy = this.IndexToXY(this.UI.Initial.PickerID);
        int y2 = xy.Y;
        this.DrawBox(x2, y2);
      }
      else if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.SetTypeID == this.UI.View.SetTypeID & this.UI.View.SetID < 0)
      {
        Point xy = this.IndexToXY(this.UI.Initial.SetID);
        int x1 = xy.X;
        xy = this.IndexToXY(this.UI.Initial.SetID);
        int y1 = xy.Y;
        this.DrawSelected(x1, y1);
        xy = this.IndexToXY(this.UI.Initial.SetID);
        int x2 = xy.X;
        xy = this.IndexToXY(this.UI.Initial.SetID);
        int y2 = xy.Y;
        this.DrawBox(x2, y2);
      }
    }

    private void DrawTypeLine()
    {
      Rectangle rectBounds = this.GetRectBounds((int) this.UI.View.TabID, 0);
      int y1 = checked (this._headerHeight + this._nPad + this._nSize);
      int y2 = checked (y1 + this._nPad - 2);
      int num = checked ((int) Math.Round(unchecked ((double) rectBounds.X + (double) rectBounds.Width / 2.0)));
      this._myBx.Graphics.DrawLine(new Pen(this.ForeColor), num, y1, num, y2);
    }

    private void DrawSetLine()
    {
      if (this.UI.View.TabID == Enums.eType.SetO & this.UI.View.SetTypeID < 0 || this.UI.View.TabID == Enums.eType.Normal & this.UI.View.GradeID < Enums.eEnhGrade.None || this.UI.View.TabID == Enums.eType.SpecialO & this.UI.View.SpecialID < Enums.eSubtype.None)
        return;
      Rectangle rectangle = new Rectangle();
      switch (this.UI.View.TabID)
      {
        case Enums.eType.Normal:
          rectangle = this.GetRectBounds(4, I9Picker.Reverse((int) this.UI.View.GradeID));
          break;
        case Enums.eType.SpecialO:
          rectangle = this.GetRectBounds(4, (int) this.UI.View.SpecialID);
          break;
        case Enums.eType.SetO:
          rectangle = this.GetRectBounds(4, checked (this.UI.View.SetTypeID + 1));
          break;
      }
      int num = checked ((int) Math.Round(unchecked ((double) rectangle.Y + (double) rectangle.Height / 2.0)));
      int x1 = checked (rectangle.X - 2);
      int x2 = checked (rectangle.X - this._nPad + 2);
      this._myBx.Graphics.DrawLine(new Pen(this.ForeColor), x1, num, x2, num);
    }

    private void DrawEnhBox()
    {
      this.DrawSetBox();
      this.DrawSetLine();
      this.DrawEnhBoxSet();
      this.DrawBox((int) this.UI.View.TabID, 0);
    }

    private void DrawEnhBoxSet()
    {
      this._myBx.Graphics.DrawRectangle(new Pen(this.ForeColor), I9Picker.Dilate(new Rectangle()
      {
        X = this._nPad,
        Y = checked (this._headerHeight + this._nPad * 2 + this._nSize),
        Width = checked (this._nSize * 4 + this._nPad * 3),
        Height = checked (this._nSize * this._rows + this._nPad * (this._rows - 1))
      }, 2));
    }

    private void DrawSetBox()
    {
      Rectangle rectBounds = this.GetRectBounds(4, 1);
      Pen pen = new Pen(this.ForeColor);
      rectBounds.Height = checked (this._nSize * this._rows + this._nPad * (this._rows - 1));
      this._myBx.Graphics.DrawRectangle(pen, I9Picker.Dilate(rectBounds, 2));
    }

    private void DrawHighlight(int x, int y)
    {
      if (!(x > -1 & y > -1))
        return;
      this._myBx.Graphics.FillRectangle((Brush) new SolidBrush(this._cHighlight), this.GetRectBounds(x, y));
    }

    private void DrawSelected(int x, int y)
    {
      if (!(x > -1 & y > -1))
        return;
      this._myBx.Graphics.FillRectangle((Brush) new SolidBrush(this._cSelected), this.GetRectBounds(x, y));
    }

    private void DrawBox(int x, int y)
    {
      if (!(x > -1 & y > -1))
        return;
      Pen pen = new Pen(this.ForeColor);
      Rectangle rectBounds = this.GetRectBounds(x, y);
      checked { --rectBounds.X; }
      checked { --rectBounds.Y; }
      checked { ++rectBounds.Width; }
      checked { ++rectBounds.Height; }
      this._myBx.Graphics.DrawRectangle(pen, rectBounds);
    }

    private static Rectangle Dilate(Rectangle iRect, int extra = 2)
    {
      return new Rectangle(checked (iRect.X - extra), checked (iRect.Y - extra), checked (iRect.Width + extra + 1), checked (iRect.Height + extra + 1));
    }

    private Point IndexToXY(int index)
    {
      int num1 = 4;
      int num2 = 0;
      while (index >= num1)
      {
        checked { index -= num1; }
        checked { ++num2; }
      }
      return new Point(index, checked (num2 + 1));
    }

    private Rectangle GetRectBounds(int x, int y)
    {
      return new Rectangle(checked (this._nPad + x * (this._nSize + this._nPad)), checked (this._headerHeight + this._nPad + y * (this._nSize + this._nPad)), this._nSize, this._nSize);
    }

    private Rectangle GetRectBounds(Point iPoint)
    {
      return this.GetRectBounds(iPoint.X, iPoint.Y);
    }

    private void I9PickerPaint(object sender, PaintEventArgs e)
    {
      if (this._myBx.Bitmap == null)
        return;
      Graphics graphics = e.Graphics;
      Bitmap bitmap = this._myBx.Bitmap;
      Rectangle clipRectangle1 = e.ClipRectangle;
      int x = clipRectangle1.X;
      clipRectangle1 = e.ClipRectangle;
      int y = clipRectangle1.Y;
      Rectangle clipRectangle2 = e.ClipRectangle;
      graphics.DrawImage((Image) bitmap, x, y, clipRectangle2, GraphicsUnit.Pixel);
    }

    private Point GetCellXY(Point iPt)
    {
      int x = 0;
      do
      {
        int num = 0;
        int rows = this._rows;
        int y = num;
        while (y <= rows)
        {
          Rectangle rectBounds = this.GetRectBounds(x, y);
          if (iPt.X >= rectBounds.X & iPt.X <= checked (rectBounds.X + rectBounds.Width) && iPt.Y >= rectBounds.Y & iPt.Y <= checked (rectBounds.Y + rectBounds.Height))
            return new Point(x, y);
          checked { ++y; }
        }
        checked { ++x; }
      }
      while (x <= 4);
      return new Point(-1, -1);
    }

    private int GetCellIndex(Point cell)
    {
      if (cell.X < 0 | cell.Y <= 0)
        return -1;
      return checked ((cell.Y - 1) * 4 + cell.X);
    }

    private void I9PickerMouseDown(object sender, MouseEventArgs e)
    {
      Point cellXy = this.GetCellXY(new Point(e.X, e.Y));
      int cellIndex = this.GetCellIndex(cellXy);
      this._mouseOffset = new Point(checked (-e.X), checked (-e.Y));
      if (e.Button == MouseButtons.Right)
        return;
      if (cellXy.Y == 0)
      {
        this.UI.View.TabID = (Enums.eType) cellXy.X;
        if (cellXy.X == 4 & this.UI.SetTypes.Length > 0)
        {
          this.UI.View.SetTypeID = 0;
          if (this.UI.View.RelLevel < Enums.eEnhRelative.Even)
            this.UI.View.RelLevel = Enums.eEnhRelative.Even;
        }
        else if (cellXy.X == 2)
        {
          if (this.UI.Initial.TabID == Enums.eType.Normal)
            this.UI.Initial.TabID = Enums.eType.InventO;
          if (this.UI.View.RelLevel < Enums.eEnhRelative.Even)
            this.UI.View.RelLevel = Enums.eEnhRelative.Even;
        }
        else if (cellXy.X == 1)
        {
          if (this.UI.View.RelLevel > Enums.eEnhRelative.PlusThree)
            this.UI.View.RelLevel = Enums.eEnhRelative.PlusThree;
          if (this.UI.Initial.TabID == Enums.eType.InventO)
            this.UI.Initial.TabID = Enums.eType.Normal;
        }
        else if (cellXy.X == 3 && this.UI.View.RelLevel > Enums.eEnhRelative.PlusThree)
          this.UI.View.RelLevel = Enums.eEnhRelative.PlusThree;
        if (cellXy.X == 0)
          this.DOEnhancementPicked(-1);
      }
      else if (cellXy.Y > 0)
      {
        if (this.CellSetTypeSelect(cellXy))
        {
          switch (this.UI.View.TabID)
          {
            case Enums.eType.Normal:
              if (cellXy.Y < this.UI.NOGrades.Length)
              {
                cellXy.Y = I9Picker.Reverse(cellXy.Y);
                this.UI.View.GradeID = (Enums.eEnhGrade) cellXy.Y;
                if (this.UI.Initial.TabID == Enums.eType.Normal)
                  this.UI.Initial.GradeID = this.UI.View.GradeID;
                this.DoHover(this._hoverCell, true);
                break;
              }
              break;
            case Enums.eType.SpecialO:
              if (cellXy.Y < this.UI.SpecialTypes.Length)
              {
                this.SetSpecialEnhSet((Enums.eSubtype) cellXy.Y);
                this.DoHover(this._hoverCell, true);
                break;
              }
              break;
            case Enums.eType.SetO:
              if (checked (cellXy.Y - 1) < this.UI.SetTypes.Length)
              {
                this.UI.View.SetTypeID = checked (cellXy.Y - 1);
                this.UI.View.SetID = -1;
                this.DoHover(this._hoverCell, true);
                break;
              }
              break;
          }
        }
        else if (this.CellSetSelect(cellIndex))
        {
          if (e.Button != MouseButtons.Middle)
            ;
          this.UI.View.SetID = cellIndex;
          this.CheckAndFixIOLevel();
          this.DoHover(this._hoverCell, true);
        }
        else if (this.CellEnhSelect(cellIndex))
          this.DOEnhancementPicked(cellIndex);
      }
      this.FullDraw();
    }

    private static int Reverse(int iValue)
    {
      switch (iValue)
      {
        case 1:
          iValue = 3;
          break;
        case 3:
          iValue = 1;
          break;
      }
      return iValue;
    }

    private bool CellSetTypeSelect(Point cell)
    {
      return cell.X == 4;
    }

    private bool CellSetSelect(int cellIDX)
    {
      return this.UI.View.SetTypeID >= 0 && this.UI.View.TabID == Enums.eType.SetO & this.UI.View.SetID == -1 & cellIDX > -1 & cellIDX < this.UI.Sets[this.UI.View.SetTypeID].Length;
    }

    private bool CellEnhSelect(int cellIDX)
    {
      if (!(cellIDX > -1 & (this.UI.View.TabID != Enums.eType.SetO | this.UI.View.SetID > -1)))
        return false;
      int[] numArray = new int[0];
      switch (this.UI.View.TabID)
      {
        case Enums.eType.Normal:
          numArray = this.UI.NO;
          break;
        case Enums.eType.InventO:
          numArray = this.UI.IO;
          break;
        case Enums.eType.SpecialO:
          numArray = this.UI.SpecialO;
          break;
        case Enums.eType.SetO:
          if (this.UI.View.SetTypeID < 0)
            return false;
          numArray = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements;
          break;
      }
      return cellIDX > -1 & cellIDX < numArray.Length;
    }

    private void DOEnhancementSetPicked(int index)
    {
    }

    private void DOEnhancementPicked(int index)
    {
      I9Slot e = (I9Slot) this._mySlot.Clone();
      this.CheckAndFixIOLevel();
      if (this.UI.View.IOLevel != this.UI.Initial.IOLevel & this.UI.View.IOLevel != this._userLevel | this._userLevel == -1 && !(this.UI.View.TabID == Enums.eType.InventO & Enhancement.GranularLevelZb(checked (this._userLevel - 1), 9, 49, 5) == this.UI.View.IOLevel))
        this._levelCapped = true;
      switch (this.UI.View.TabID)
      {
        case Enums.eType.None:
          e = new I9Slot();
          break;
        case Enums.eType.Normal:
          e.Enh = this.UI.NO[index];
          e.Grade = this.UI.View.GradeID;
          e.RelativeLevel = this.UI.View.RelLevel;
          break;
        case Enums.eType.InventO:
          e.Enh = this.UI.IO[index];
          e.IOLevel = checked (this.UI.View.IOLevel - 1);
          e.RelativeLevel = this.UI.View.RelLevel;
          break;
        case Enums.eType.SpecialO:
          e.Enh = this.UI.SpecialO[index];
          e.RelativeLevel = this.UI.View.RelLevel;
          this._lastSpecial = this.UI.View.SpecialID;
          break;
        case Enums.eType.SetO:
          if (this.IsPlaced(index))
            return;
          e.Enh = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[index];
          e.IOLevel = checked (this.UI.View.IOLevel - 1);
          if (DatabaseAPI.Database.Enhancements[e.Enh].Power != null)
          {
            if (DatabaseAPI.Database.Enhancements[e.Enh].Power.BoostBoostable)
            {
              e.RelativeLevel = this.UI.View.RelLevel;
              break;
            }
            break;
          }
          e.RelativeLevel = this.UI.View.RelLevel;
          break;
      }
      if (this.UI.View.TabID != Enums.eType.None)
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
        this.LastLevel = !(this.UI.View.TabID == Enums.eType.InventO & Enhancement.GranularLevelZb(checked (this._userLevel - 1), 9, 49, 5) == this.UI.View.IOLevel) ? this.UI.View.IOLevel : this._userLevel;
      else if (this._userLevel > -1)
        this.LastLevel = this._userLevel;
      I9Picker.EnhancementPickedEventHandler enhancementPickedEvent = this.EnhancementPickedEvent;
      if (enhancementPickedEvent != null)
        enhancementPickedEvent(e);
    }

        private void EnhancementPickedEvent(I9Slot e)
        {
            throw new NotImplementedException();
        }

        private void RaiseHoverEnhancement(int e)
    {
      I9Picker.HoverEnhancementEventHandler enhancementEvent = this.HoverEnhancementEvent;
      if (enhancementEvent == null)
        return;
      enhancementEvent(e);
    }

        private void HoverEnhancementEvent(int e)
        {
            throw new NotImplementedException();
        }

        private void RaiseHoverSet(int e)
    {
      I9Picker.HoverSetEventHandler hoverSetEvent = this.HoverSetEvent;
      if (hoverSetEvent == null)
        return;
      hoverSetEvent(e);
    }

        private void HoverSetEvent(int e)
        {
            throw new NotImplementedException();
        }

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

    private void I9PickerMouseMove(object sender, MouseEventArgs e)
    {
      this.DoHover(this.GetCellXY(new Point(e.X, e.Y)), false);
      if (e.Button != MouseButtons.Left)
        return;
      Point point1 = new Point(e.X, e.Y);
      point1.Offset(this._mouseOffset.X, this._mouseOffset.Y);
      Point point2 = new Point(checked (this.Location.X + point1.X), checked (this.Location.Y + point1.Y));
      Rectangle bounds = this.Bounds;
      this.Location = point2;
      I9Picker.MovedEventHandler movedEvent = this.MovedEvent;
      if (movedEvent != null)
        movedEvent(this.Bounds, bounds);
    }

        private void MovedEvent(Rectangle oldBounds, Rectangle newBounds)
        {
            throw new NotImplementedException();
        }

        private void DoHover(Point cell, bool alwaysUpdate = false)
    {
      int cellIndex = this.GetCellIndex(cell);
      bool flag = false;
      string[] setTypeStringLong = DatabaseAPI.Database.SetTypeStringLong;
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
            case Enums.eType.Normal:
              if (cell.Y < this.UI.NOGrades.Length)
              {
                string message = "";
                int index = cell.Y;
                if (index == 1)
                  index = 3;
                else if (index == 3)
                  index = 1;
                switch (index)
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
                this.SetInfoStrings(DatabaseAPI.Database.EnhGradeStringLong[this.UI.NOGrades[index]], message);
                flag = true;
                break;
              }
              break;
            case Enums.eType.SpecialO:
              if (cell.Y < this.UI.SpecialTypes.Length)
              {
                string message = "";
                switch (cell.Y)
                {
                  case 0:
                    message = "This is not an enhancement subtype!";
                    break;
                  case 1:
                    message = "Hamidon/Synthetic Hamidon enhancements.";
                    break;
                  case 2:
                    message = "Rewards from the Sewer Trial.";
                    break;
                  case 3:
                    message = "Rewards from the Eden Trial.";
                    break;
                }
                this.SetInfoStrings(DatabaseAPI.Database.SpecialEnhStringLong[this.UI.SpecialTypes[cell.Y]], message);
                flag = true;
                break;
              }
              break;
            case Enums.eType.SetO:
              if (checked (cell.Y - 1) < this.UI.SetTypes.Length)
              {
                this.SetInfoStrings(setTypeStringLong[this.UI.SetTypes[checked (cell.Y - 1)]], "Click here to view the set listing.");
                flag = true;
                break;
              }
              break;
          }
        }
        else if (this.CellSetSelect(cellIndex))
        {
          int e = this.UI.Sets[this.UI.View.SetTypeID][cellIndex];
          string str;
          if (DatabaseAPI.Database.EnhancementSets[e].LevelMin == DatabaseAPI.Database.EnhancementSets[e].LevelMax)
            str = " (" + Conversions.ToString(checked (DatabaseAPI.Database.EnhancementSets[e].LevelMin + 1)) + ")";
          else
            str = " (" + Conversions.ToString(checked (DatabaseAPI.Database.EnhancementSets[e].LevelMin + 1)) + "-" + Conversions.ToString(checked (DatabaseAPI.Database.EnhancementSets[e].LevelMax + 1)) + ")";
          this.SetInfoStrings(DatabaseAPI.Database.EnhancementSets[e].DisplayName + str, "Type: " + setTypeStringLong[(int) DatabaseAPI.Database.EnhancementSets[e].SetType]);
          if (cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y | alwaysUpdate)
            this.RaiseHoverSet(e);
          flag = true;
        }
        else if (this.CellEnhSelect(cellIndex))
        {
          int e = 0;
          switch (this.UI.View.TabID)
          {
            case Enums.eType.None:
              e = -1;
              this.SetInfoStrings("", "");
              break;
            case Enums.eType.Normal:
              e = this.UI.NO[cellIndex];
              this.SetInfoStrings(DatabaseAPI.Database.Enhancements[e].Name, DatabaseAPI.Database.Enhancements[e].Desc);
              break;
            case Enums.eType.InventO:
              e = this.UI.IO[cellIndex];
              this.SetInfoStrings(DatabaseAPI.Database.Enhancements[e].Name, DatabaseAPI.Database.Enhancements[e].Desc);
              break;
            case Enums.eType.SpecialO:
              e = this.UI.SpecialO[cellIndex];
              this.SetInfoStrings(DatabaseAPI.Database.Enhancements[e].Name, DatabaseAPI.Database.Enhancements[e].Desc);
              break;
            case Enums.eType.SetO:
              e = DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].Enhancements[cellIndex];
              string name = DatabaseAPI.Database.Enhancements[e].Name;
              string str;
              if (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[e].nIDSet].LevelMin == DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[e].nIDSet].LevelMax)
              {
                str = " (" + Conversions.ToString(checked (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[e].nIDSet].LevelMin + 1)) + ")";
              }
              else
              {
                str = " (" + Conversions.ToString(checked (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[e].nIDSet].LevelMin + 1)) + "-" + Conversions.ToString(checked (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[e].nIDSet].LevelMax + 1)) + ")";
                if (DatabaseAPI.Database.Enhancements[e].Unique)
                  name += " (Unique)";
              }
              this.SetInfoStrings(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[e].nIDSet].DisplayName + str, name);
              break;
          }
          if (cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y | alwaysUpdate)
            this.RaiseHoverEnhancement(e);
          flag = true;
        }
      }
      if (!flag)
        cell = new Point(-1, -1);
      if (!(cell.X != this._hoverCell.X | cell.Y != this._hoverCell.Y))
        return;
      this._hoverCell = cell;
      this.FullDraw();
    }

    private int SetIDGlobalToLocal(int iId)
    {
      int num1 = 0;
      int num2 = checked (this.UI.SetTypes.Length - 1);
      int index1 = num1;
      while (index1 <= num2)
      {
        int num3 = 0;
        int num4 = checked (this.UI.Sets[index1].Length - 1);
        int index2 = num3;
        while (index2 <= num4)
        {
          if (this.UI.Sets[index1][index2] == iId)
            return index2;
          checked { ++index2; }
        }
        checked { ++index1; }
      }
      return 0;
    }

    private static int[] GetSets(Enums.eSetType iSetType)
    {
      List<int> intList = new List<int>();
      int num1 = 0;
      int num2 = checked (DatabaseAPI.Database.EnhancementSets.Count - 1);
      int index = num1;
      while (index <= num2)
      {
        if (DatabaseAPI.Database.EnhancementSets[index].SetType == iSetType)
          intList.Add(index);
        checked { ++index; }
      }
      return intList.ToArray();
    }

    private static int[] GetValidSetTypes(int iPowerIDX)
    {
      int[] numArray = new int[0];
      if (iPowerIDX < 0)
        return numArray;
      int[] array = new int[checked (DatabaseAPI.Database.Power[iPowerIDX].SetTypes.Length - 1 + 1)];
      Array.Copy((Array) DatabaseAPI.Database.Power[iPowerIDX].SetTypes, (Array) array, DatabaseAPI.Database.Power[iPowerIDX].SetTypes.Length);
      Array.Sort<int>(array);
      return array;
    }

    private static int[] GetValidEnhancements(
      int iPowerIDX,
      Enums.eType iType,
      Enums.eSubtype iSubType = Enums.eSubtype.None)
    {
      int[] numArray = new int[0];
      if (iPowerIDX < 0)
        return numArray;
      return DatabaseAPI.Database.Power[iPowerIDX].GetValidEnhancements(iType, iSubType);
    }

    public void SetData(int iPower, ref I9Slot iSlot, ref clsDrawX iDraw, int[] slotted)
    {
      this.TimerReset();
      this._levelCapped = false;
      this._userLevel = -1;
      this._hDraw = iDraw;
      this._mySlot = (I9Slot) iSlot.Clone();
      this._hoverCell = new Point(-1, -1);
      this._hoverText = "";
      this._hoverTitle = "";
      this._nPowerIDX = iPower;
      this.UI = new I9Picker.cTracking();
      this.UI.SpecialTypes = (int[]) Enum.GetValues(Enums.eSubtype.None.GetType());
      this.UI.NOGrades = (int[]) Enum.GetValues(Enums.eEnhGrade.None.GetType());
      this.UI.NO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.Normal, Enums.eSubtype.None);
      this.UI.IO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.InventO, Enums.eSubtype.None);
      this.UI.Initial.GradeID = this._lastGrade;
      this.UI.Initial.RelLevel = this._lastRelativeLevel;
      this.UI.Initial.SpecialID = this._lastSpecial;
      if (this.UI.Initial.SpecialID == Enums.eSubtype.None)
        this.UI.Initial.SpecialID = Enums.eSubtype.Hamidon;
      if (this.UI.Initial.GradeID == Enums.eEnhGrade.None)
        this.UI.Initial.GradeID = MidsContext.Config.CalcEnhOrigin;
      if (this.UI.Initial.RelLevel == Enums.eEnhRelative.None)
        this.UI.Initial.RelLevel = MidsContext.Config.CalcEnhLevel;
      if (this._mySlot.Enh > -1)
      {
        if (DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID != Enums.eSubtype.None)
        {
          this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID);
          this.UI.Initial.SpecialID = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].SubTypeID;
        }
        else
          this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, this.UI.Initial.SpecialID);
      }
      else
        this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, this.UI.Initial.SpecialID);
      this.UI.SetTypes = I9Picker.GetValidSetTypes(this._nPowerIDX);
      this.UI.Sets = new int[checked (this.UI.SetTypes.Length - 1 + 1)][];
      int num1 = 0;
      int num2 = checked (this.UI.SetTypes.Length - 1);
      int index = num1;
      while (index <= num2)
      {
        this.UI.Sets[index] = I9Picker.GetSets((Enums.eSetType) this.UI.SetTypes[index]);
        checked { ++index; }
      }
      if (this._mySlot.Grade != Enums.eEnhGrade.None)
        this.UI.Initial.GradeID = this._mySlot.Grade;
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
        if (DatabaseAPI.Database.Enhancements[this._mySlot.Enh].Power != null && !DatabaseAPI.Database.Enhancements[this._mySlot.Enh].Power.BoostBoostable)
          this._mySlot.RelativeLevel = Enums.eEnhRelative.Even;
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
              this.UI.SetTypes = new int[1];
              this.UI.SetTypes[0] = (int) DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].SetType;
              this.UI.Sets = new int[1][];
              this.UI.Sets[0] = new int[1];
              this.UI.Sets[0][0] = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet;
              this.UI.SetO = new int[1];
              this.UI.SetO[0] = this._mySlot.Enh;
              break;
          }
        }
        this.UI.Initial.TabID = DatabaseAPI.Database.Enhancements[this._mySlot.Enh].TypeID;
        if (this.UI.Initial.TabID == Enums.eType.SetO)
        {
          this.UI.Initial.SetID = this.SetIDGlobalToLocal(DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet);
          this.UI.Initial.SetTypeID = this.SetTypeToID(DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].SetType);
          this.UI.SetO = new int[checked (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].Enhancements.Length - 1 + 1)];
          Array.Copy((Array) DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[this._mySlot.Enh].nIDSet].Enhancements, (Array) this.UI.SetO, this.UI.SetO.Length);
        }
        else if (this.UI.SetTypes.Length > 0)
          this.UI.Initial.SetTypeID = 0;
        this.UI.Initial.PickerID = this.GetPickerIndex(this._mySlot.Enh, this.UI.Initial.TabID);
      }
      else
        this.UI.Initial.TabID = Enums.eType.None;
      this.UI.Initial.IOLevel = !(this.UI.Initial.TabID == Enums.eType.InventO | this.UI.Initial.TabID == Enums.eType.SetO) ? (this.LastLevel <= 0 ? checked (MidsContext.Config.I9.DefaultIOLevel + 1) : this.LastLevel) : checked (this._mySlot.IOLevel + 1);
      this.UI.View = new I9Picker.cTracking.cLocation(this.UI.Initial);
      if (this.UI.View.TabID == Enums.eType.None)
      {
        this.UI.View.TabID = this._lastTab == Enums.eType.None ? Enums.eType.Normal : this._lastTab;
        if (this.UI.View.TabID == Enums.eType.SetO & this.UI.SetTypes.Length > this._lastSet)
          this.UI.View.SetTypeID = this._lastSet;
      }
      this._mySlotted = new int[checked (slotted.Length - 1 + 1)];
      Array.Copy((Array) slotted, (Array) this._mySlotted, this._mySlotted.Length);
      if (this.UI.SetTypes.Length > 3)
      {
        this._rows = this.UI.SetTypes.Length;
        this.Height = checked (235 + (this._nSize + 2 + this._nPad) * (this.UI.SetTypes.Length - 3));
      }
      else
      {
        this._rows = 5;
        this.Height = 235;
      }
      this.FullDraw();
    }

    private void SetSpecialEnhSet(Enums.eSubtype iSubType)
    {
      this.UI.View.SpecialID = iSubType;
      if (this._nPowerIDX > 0)
        this.UI.SpecialO = I9Picker.GetValidEnhancements(this._nPowerIDX, Enums.eType.SpecialO, this.UI.View.SpecialID);
      else if (this.UI.Initial.SpecialID == this.UI.View.SpecialID & this.UI.Initial.TabID == Enums.eType.SpecialO)
      {
        this.UI.SpecialO = new int[1];
        this.UI.SpecialO[0] = this._mySlot.Enh;
      }
      else
        this.UI.SpecialO = new int[0];
    }

    private int SetTypeToID(Enums.eSetType iSetType)
    {
      int num1 = 0;
      int num2 = checked (this.UI.SetTypes.Length - 1);
      int index = num1;
      while (index <= num2)
      {
        if (iSetType == (Enums.eSetType) this.UI.SetTypes[index])
          return index;
        checked { ++index; }
      }
      return -1;
    }

    private int GetPickerIndex(int index, Enums.eType iType)
    {
      int[] numArray = new int[0];
      switch (iType)
      {
        case Enums.eType.Normal:
          numArray = this.UI.NO;
          break;
        case Enums.eType.InventO:
          numArray = this.UI.IO;
          break;
        case Enums.eType.SpecialO:
          numArray = this.UI.SpecialO;
          break;
        case Enums.eType.SetO:
          numArray = this.UI.SetO;
          break;
      }
      int num1 = 0;
      int num2 = checked (numArray.Length - 1);
      int index1 = num1;
      while (index1 <= num2)
      {
        if (numArray[index1] == index)
          return index1;
        checked { ++index1; }
      }
      return -1;
    }

    private void CheckAndFixIOLevel()
    {
      int num1 = 50;
      int num2 = 10;
      if (this.UI.View.TabID == Enums.eType.InventO)
      {
        if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.PickerID == this.UI.View.PickerID & this.UI.View.PickerID > -1)
        {
          num1 = checked (DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMax + 1);
          num2 = checked (DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMin + 1);
        }
      }
      else if (this.UI.View.TabID == Enums.eType.SetO && this.UI.View.SetID > -1 & this.UI.View.SetTypeID > -1)
      {
        num1 = checked (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMax + 1);
        num2 = checked (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMin + 1);
      }
      if (this.UI.View.IOLevel > num1)
        this.UI.View.IOLevel = num1;
      if (this.UI.View.IOLevel < num2)
        this.UI.View.IOLevel = num2;
      if (this.UI.View.TabID != Enums.eType.InventO)
        return;
      if (num1 > 50)
        num1 = 50;
      this.UI.View.IOLevel = checked (Enhancement.GranularLevelZb(this.UI.View.IOLevel - 1, num2 - 1, num1 - 1, 5) + 1);
    }

    public int CheckAndReturnIOLevel()
    {
      int num1 = 50;
      int num2 = 10;
      int num3 = this.UI.View.IOLevel;
      if (this.UI.View.TabID == Enums.eType.InventO)
      {
        if (this.UI.Initial.TabID == this.UI.View.TabID & this.UI.Initial.PickerID == this.UI.View.PickerID & this.UI.View.PickerID > -1)
        {
          num1 = checked (DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMax + 1);
          num2 = checked (DatabaseAPI.Database.Enhancements[this.UI.IO[this.UI.View.PickerID]].LevelMin + 1);
        }
      }
      else if (this.UI.View.TabID == Enums.eType.SetO && this.UI.View.SetID > -1 & this.UI.View.SetTypeID > -1)
      {
        num1 = checked (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMax + 1);
        num2 = checked (DatabaseAPI.Database.EnhancementSets[this.UI.Sets[this.UI.View.SetTypeID][this.UI.View.SetID]].LevelMin + 1);
      }
      if (num3 > num1)
        num3 = num1;
      if (num3 < num2)
        num3 = num2;
      if (this.UI.View.TabID == Enums.eType.InventO)
      {
        if (num1 > 50)
          num1 = 50;
        num3 = checked (Enhancement.GranularLevelZb(num3 - 1, num2 - 1, num1 - 1, 5) + 1);
      }
      return num3;
    }

    private void TimerReset()
    {
      this._timerLastKeypress = -1.0;
    }

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
        string InputStr = Conversions.ToString(this.UI.View.IOLevel) + Conversions.ToString(iNumber);
        if (InputStr.Length > 2)
          InputStr = InputStr.Substring(checked (InputStr.Length - 2));
        int num = checked ((int) Math.Round(Conversion.Val(InputStr)));
        if (num > 50)
          num = 50;
        if (num < 1)
          num = 1;
        this.UI.View.IOLevel = num;
        this._userLevel = this.UI.View.IOLevel;
        if (num >= 10)
          this.TimerReset();
      }
    }

    private void I9PickerKeyDown(object sender, KeyEventArgs e)
    {
      int iNumber = -1;
      switch (e.KeyCode)
      {
        case Keys.Back:
          this.UI.View.IOLevel = this.UI.Initial.IOLevel;
          this.UI.View.RelLevel = this.UI.Initial.RelLevel;
          this.TimerReset();
          break;
        case Keys.Return:
          this.UI.Initial.IOLevel = this.UI.View.IOLevel;
          this.UI.Initial.RelLevel = this.UI.View.RelLevel;
          this.UI.View = new I9Picker.cTracking.cLocation(this.UI.Initial);
          this.DOEnhancementPicked(this.UI.View.PickerID);
          break;
        case Keys.Space:
          this.UI.View.IOLevel = checked (MidsContext.Config.I9.DefaultIOLevel + 1);
          this.UI.View.RelLevel = Enums.eEnhRelative.Even;
          this.TimerReset();
          break;
        case Keys.End:
          this.UI.View.IOLevel = 100;
          this.UI.View.RelLevel = Enums.eEnhRelative.PlusFive;
          this.TimerReset();
          break;
        case Keys.Home:
          this.UI.View.IOLevel = 0;
          this.UI.View.RelLevel = Enums.eEnhRelative.MinusThree;
          this.TimerReset();
          break;
        case Keys.Delete:
          this.UI.View.IOLevel = this.UI.Initial.IOLevel;
          this.UI.View.RelLevel = this.UI.Initial.RelLevel;
          this.TimerReset();
          break;
        case Keys.Add:
          this.RelAdjust(1);
          break;
        case Keys.Subtract:
          this.RelAdjust(-1);
          break;
        case Keys.Decimal:
          this.UI.View.IOLevel = this.UI.Initial.IOLevel;
          this.UI.View.RelLevel = this.UI.Initial.RelLevel;
          this.TimerReset();
          break;
        case Keys.Oemplus:
          this.RelAdjust(1);
          break;
        case Keys.OemMinus:
          this.RelAdjust(-1);
          break;
        default:
          if (e.KeyValue >= 48 & e.KeyValue <= 57)
          {
            iNumber = checked (e.KeyValue - 48);
            break;
          }
          if (e.KeyValue >= 96 & e.KeyValue <= 105)
          {
            iNumber = checked (e.KeyValue - 96);
            break;
          }
          break;
      }
      if (this.UI.View.TabID == Enums.eType.SetO | this.UI.View.TabID == Enums.eType.InventO)
      {
        if (iNumber > -1)
          this.NumberPressed(iNumber);
        else
          this.CheckAndFixIOLevel();
      }
      this.DoHover(this._hoverCell, true);
      this.FullDraw();
    }

    private void RelAdjust(int direction)
    {
      Enums.eEnhRelative eEnhRelative = this.UI.View.RelLevel;
      if (direction < 0)
      {
        if (this.UI.View.RelLevel > Enums.eEnhRelative.None)
          --eEnhRelative;
      }
      else if (direction > 0 && this.UI.View.RelLevel < Enums.eEnhRelative.PlusFive)
        ++eEnhRelative;
      if (eEnhRelative > Enums.eEnhRelative.PlusThree & (this.UI.View.TabID == Enums.eType.Normal | this.UI.View.TabID == Enums.eType.SpecialO))
        eEnhRelative = Enums.eEnhRelative.PlusThree;
      else if (eEnhRelative < Enums.eEnhRelative.Even & (this.UI.View.TabID == Enums.eType.InventO | this.UI.View.TabID == Enums.eType.SetO))
        eEnhRelative = Enums.eEnhRelative.Even;
      this.UI.View.RelLevel = eEnhRelative;
    }

    public class cTracking
    {
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

      public class cLocation
      {
        public Enums.eType TabID;
        public int PickerID;
        public int SetTypeID;
        public int SetID;
        public Enums.eEnhGrade GradeID;
        public Enums.eSubtype SpecialID;
        public int IOLevel;
        public Enums.eEnhRelative RelLevel;

        public cLocation()
        {
          this.TabID = Enums.eType.None;
          this.PickerID = -1;
          this.SetTypeID = -1;
          this.SetID = -1;
          this.GradeID = Enums.eEnhGrade.None;
          this.SpecialID = Enums.eSubtype.None;
          this.IOLevel = 0;
          this.RelLevel = Enums.eEnhRelative.Even;
        }

        public cLocation(I9Picker.cTracking.cLocation iCL)
        {
          this.TabID = Enums.eType.None;
          this.PickerID = -1;
          this.SetTypeID = -1;
          this.SetID = -1;
          this.GradeID = Enums.eEnhGrade.None;
          this.SpecialID = Enums.eSubtype.None;
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
      }
    }

    public delegate void EnhancementPickedEventHandler(I9Slot e);

    public delegate void HoverEnhancementEventHandler(int e);

    public delegate void HoverSetEventHandler(int e);

    public delegate void MovedEventHandler(Rectangle oldBounds, Rectangle newBounds);
  }
}
