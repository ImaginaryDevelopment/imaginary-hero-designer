// Decompiled with JetBrains decompiler
// Type: midsControls.ctlPairedList
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
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace midsControls
{
  public class ctlPairedList : UserControl
  {
    protected ctlPairedList.ItemPair[] MyItems;
    private int LineHeight;
    protected ExtendedBitmap bxBuffer;
    protected Graphics myGFX;
    protected Color NameColour;
    protected Color ValueColor;
    protected Color ValueColorA;
    protected Color ValueColorB;
    protected Color ValueColorC;
    public Color ValueColorD;
    protected Color myHighlightColor;
    protected Color myHighlightTextColor;
    protected int myColumns;
    protected int LinePadding;
    protected int myValueWidth;
    protected bool Highlightable;
    protected int CurrentHighlight;
    protected bool myForceBold;
    private IContainer components;
    [AccessedThroughProperty("myTip")]
    private ToolTip _myTip;
        private ItemClickEventHandler ItemClickEvent;

        public event ctlPairedList.ItemClickEventHandler ItemClick;

    public event ctlPairedList.ItemHoverEventHandler ItemHover;

    public virtual ToolTip myTip
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

    public int Columns
    {
      get
      {
        return this.myColumns;
      }
      set
      {
        if (!(value >= 0 & value < 10))
          return;
        this.myColumns = value;
        this.Draw();
      }
    }

    public int ValueWidth
    {
      get
      {
        return this.myValueWidth;
      }
      set
      {
        if (this.myColumns < 1)
          this.myColumns = 1;
        if (!(value > 0 & value < 100))
          return;
        this.myValueWidth = value;
      }
    }

    public bool DoHighlight
    {
      get
      {
        return this.Highlightable;
      }
      set
      {
        this.Highlightable = value;
        this.Draw();
      }
    }

    public Color HighlightColor
    {
      get
      {
        return this.myHighlightColor;
      }
      set
      {
        this.myHighlightColor = value;
      }
    }

    public Color HighlightTextColor
    {
      get
      {
        return this.myHighlightTextColor;
      }
      set
      {
        this.myHighlightTextColor = value;
      }
    }

    public Color NameColor
    {
      get
      {
        return this.NameColour;
      }
      set
      {
        this.NameColour = value;
      }
    }

    public Color ItemColor
    {
      get
      {
        return this.ValueColor;
      }
      set
      {
        this.ValueColor = value;
      }
    }

    public Color ItemColorAlt
    {
      get
      {
        return this.ValueColorA;
      }
      set
      {
        this.ValueColorA = value;
      }
    }

    public Color ItemColorSpecial
    {
      get
      {
        return this.ValueColorB;
      }
      set
      {
        this.ValueColorB = value;
      }
    }

    public Color ItemColorSpecCase
    {
      get
      {
        return this.ValueColorC;
      }
      set
      {
        this.ValueColorC = value;
      }
    }

    public int ItemCount
    {
      get
      {
        return this.MyItems.Length;
      }
    }

    public bool ForceBold
    {
      get
      {
        return this.myForceBold;
      }
      set
      {
        this.myForceBold = value;
        this.Draw();
      }
    }

    public ctlPairedList()
    {
      this.FontChanged += new EventHandler(this.ctlPairedList_FontChanged);
      this.Load += new EventHandler(this.ctlPairedList_Load);
      this.Paint += new PaintEventHandler(this.ctlPairedList_Paint);
      this.MouseDown += new MouseEventHandler(this.Listlabel_MouseDown);
      this.MouseMove += new MouseEventHandler(this.Listlabel_MouseMove);
      this.MouseLeave += new EventHandler(this.Listlabel_MouseLeave);
      this.BackColorChanged += new EventHandler(this.ctlPairedList_BackColorChanged);
      this.ValueColorD = Color.Aqua;
      this.LinePadding = 3;
      this.myForceBold = false;
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
      this.Name = nameof (ctlPairedList);
    }

    public void SetUnique()
    {
      if (this.MyItems.Length <= 0)
        return;
      this.MyItems[checked (this.MyItems.Length - 1)].UniqueColour = true;
    }

    public bool IsSpecialColor()
    {
      return this.MyItems[this.MyItems.Length - 1].VerySpecialColour;
    }

    private void ctlPairedList_FontChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    private void ctlPairedList_Load(object sender, EventArgs e)
    {
      this.SetLineHeight();
      this.CurrentHighlight = -1;
      this.MyItems = new ctlPairedList.ItemPair[0];
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.AddItem(new ctlPairedList.ItemPair("Item 1:", "Value", false, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("Item 2:", "Alternate", true, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("Item 3:", "1000", false, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("Item 4:", "1,000", false, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("1234567890:", "12345678901234567890", false, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("1234567890:", "12345678901234567890", true, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("1 2 3 4 5 6 7 8 9 0:", "1 2 3 4 5 6 7 8 9 0", false, false, false, -1));
      this.AddItem(new ctlPairedList.ItemPair("1 2 3 4 5 6 7 8 9 0:", "1 2 3 4 5 6 7 8 9 0", true, false, false, -1));
      this.Draw();
    }

    public void FullUpdate()
    {
      this.SetLineHeight();
      this.myGFX = this.CreateGraphics();
      this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      this.Draw();
    }

    public void Draw()
    {
      if (this.bxBuffer == null)
        return;
      this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
      RectangleF rectangleF = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
      StringFormat format = new StringFormat();
      FontStyle newStyle1 = FontStyle.Bold;
      FontStyle newStyle2 = FontStyle.Regular;
      if (this.myForceBold)
      {
        newStyle2 = FontStyle.Bold;
        newStyle1 = FontStyle.Bold;
      }
      Font font1 = new Font(this.Font, newStyle1);
      Font font2 = new Font(this.Font, newStyle2);
      rectangleF.X = 0.0f;
      if (this.myColumns < 1)
        this.myColumns = 1;
      int num1 = checked ((int) Math.Round(unchecked ((double) this.Width / (double) this.myColumns)));
      int num2 = checked ((int) Math.Round(unchecked ((double) num1 * (double) this.myValueWidth / 100.0)));
      int num3 = checked (num1 - num2);
      rectangleF.Height = (float) this.LineHeight;
      this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), rect);
      if (this.MyItems == null)
        this.myGFX.DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
      if (this.MyItems.Length < 1)
        this.myGFX.DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      int num7 = checked (this.MyItems.Length - 1);
      int index = num6;
      while (index <= num7)
      {
        PointF pointF = new PointF((float) checked (num1 * num5), rectangleF.Height * (float) num4 + (float) checked (this.LinePadding * num4));
        rectangleF.Location = pointF;
        rectangleF.Width = (float) num3;
        format.Alignment = StringAlignment.Far;
        format.Trimming = StringTrimming.None;
        format.FormatFlags = StringFormatFlags.NoWrap;
        Brush brush1;
        if (this.Highlightable & this.CurrentHighlight == index)
        {
          this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.myHighlightColor), rectangleF);
          brush1 = (Brush) new SolidBrush(this.myHighlightTextColor);
        }
        else
          brush1 = (Brush) new SolidBrush(this.NameColour);
        string name = this.MyItems[index].Name;
        if (Operators.CompareString(name, "", false) != 0 & !name.EndsWith(":"))
          name += ":";
        this.bxBuffer.Graphics.DrawString(name, font1, brush1, rectangleF, format);
        pointF = new PointF((float) checked (num1 * num5 + num3), rectangleF.Height * (float) num4 + (float) checked (this.LinePadding * num4));
        rectangleF.Location = pointF;
        rectangleF.Width = (float) num2;
        Brush brush2;
        if (this.Highlightable & this.CurrentHighlight == index)
        {
          this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.myHighlightColor), rectangleF);
          brush2 = (Brush) new SolidBrush(this.myHighlightTextColor);
        }
        else
          brush2 = !this.MyItems[index].UniqueColour ? (!this.MyItems[index].AlternateColour ? (!this.MyItems[index].ProbColour ? (Brush) new SolidBrush(this.ValueColor) : (Brush) new SolidBrush(this.ValueColorB)) : (Brush) new SolidBrush(this.ValueColorA)) : (Brush) new SolidBrush(this.ValueColorD);
        format.Alignment = StringAlignment.Near;
        this.bxBuffer.Graphics.DrawString(this.MyItems[index].Value, font2, brush2, rectangleF, format);
        checked { ++num5; }
        if (num5 >= this.myColumns)
        {
          num5 = 0;
          checked { ++num4; }
        }
        checked { ++index; }
      }
      this.myGFX.DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
    }

    private void ctlPairedList_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxBuffer == null)
        return;
      this.myGFX.DrawImage((Image) this.bxBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
    }

    protected override void OnFontChanged(EventArgs e)
    {
      this.SetLineHeight();
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

    private void SetLineHeight()
    {
      this.LineHeight = checked ((int) Math.Round(unchecked ((double) new Font(this.Font, this.Font.Style).GetHeight() + (double) this.LinePadding)));
    }

    public void AddItem(ctlPairedList.ItemPair iItem)
    {
      this.MyItems = (ctlPairedList.ItemPair[]) Utils.CopyArray((Array) this.MyItems, (Array) new ctlPairedList.ItemPair[checked (this.MyItems.Length + 1)]);
      this.MyItems[checked (this.MyItems.Length - 1)] = new ctlPairedList.ItemPair(iItem);
    }

    public void Clear(bool Redraw = false)
    {
      this.MyItems = (ctlPairedList.ItemPair[]) Utils.CopyArray((Array) this.MyItems, (Array) new ctlPairedList.ItemPair[0]);
      if (!Redraw)
        return;
      this.Draw();
    }

    private void Listlabel_MouseDown(object sender, MouseEventArgs e)
    {
      int num1 = 0;
      int num2 = 0;
      int Index = -1;
      Rectangle rectangle = new Rectangle();
      rectangle.X = 0;
      rectangle.Y = 0;
      rectangle.Height = this.LineHeight;
      rectangle.Width = checked ((int) Math.Round(unchecked ((double) this.Width / (double) this.myColumns)));
      int num3 = 0;
      int num4 = checked (this.MyItems.Length - 1);
      int num5 = num3;
      while (num5 <= num4)
      {
        rectangle.X = checked (rectangle.Width * num2);
        rectangle.Y = checked (rectangle.Height + this.LinePadding * num1);
        if (e.Y >= rectangle.Y & e.Y <= checked (rectangle.Height + rectangle.Y) && e.X >= rectangle.X & e.X <= checked (rectangle.Width + rectangle.X))
        {
          Index = num5;
          break;
        }
        checked { ++num2; }
        if (num2 >= this.myColumns)
        {
          num2 = 0;
          checked { ++num1; }
        }
        checked { ++num5; }
      }
      if (Index <= -1)
        return;
      ctlPairedList.ItemClickEventHandler itemClickEvent = this.ItemClickEvent;
      if (itemClickEvent != null)
        itemClickEvent(Index, e.Button);
    }

    private void Listlabel_MouseMove(object sender, MouseEventArgs e)
    {
      int num1 = 0;
      int num2 = 0;
      int Index = -1;
      Rectangle rectangle = new Rectangle();
      rectangle.X = 0;
      rectangle.Y = 0;
      rectangle.Height = this.LineHeight;
      rectangle.Width = checked ((int) Math.Round(unchecked ((double) this.Width / (double) this.myColumns)));
      int num3 = 0;
      int num4 = checked (this.MyItems.Length - 1);
      int num5 = num3;
      while (num5 <= num4)
      {
        rectangle.X = checked (rectangle.Width * num2);
        rectangle.Y = checked (rectangle.Height + this.LinePadding * num1);
        if (e.Y >= rectangle.Y & e.Y <= checked (rectangle.Height + rectangle.Y) && e.X >= rectangle.X & e.X <= checked (rectangle.Width + rectangle.X))
        {
          Index = num5;
          break;
        }
        checked { ++num2; }
        if (num2 >= this.myColumns)
        {
          num2 = 0;
          checked { ++num1; }
        }
        checked { ++num5; }
      }
      if (this.CurrentHighlight == Index)
        return;
      this.CurrentHighlight = Index;
      if (this.Highlightable)
        this.Draw();
      if (Index > -1)
      {
        ctlPairedList.ItemHoverEventHandler itemHoverEvent = this.ItemHoverEvent;
        if (itemHoverEvent != null)
          itemHoverEvent((object) this, Index, this.MyItems[Index].TagID);
      }
    }

        private void ItemHoverEvent(object Sender, int Index, Enums.ShortFX TagID)
        {
            throw new NotImplementedException();
        }

        private void Listlabel_MouseLeave(object sender, EventArgs e)
    {
      this.CurrentHighlight = -1;
      if (this.Highlightable)
        this.Draw();
      this.myTip.SetToolTip((Control) this, "");
    }

    public void SetTip(string iTip)
    {
      this.myTip.SetToolTip((Control) this, iTip);
    }

    private void ctlPairedList_BackColorChanged(object sender, EventArgs e)
    {
      this.Draw();
    }

    public class ItemPair
    {
      public string Name;
      public string Value;
      public bool AlternateColour;
      public bool ProbColour;
      public bool VerySpecialColour;
      public bool UniqueColour;
      public Enums.ShortFX TagID;
      public string SpecialTip;

      public ItemPair(
        string iName,
        string iValue,
        bool iAlternate,
        bool iProbability,
        bool iSpecialCase,
        string iTip)
      {
        this.Name = iName;
        this.Value = iValue;
        this.AlternateColour = iAlternate;
        this.ProbColour = iProbability;
        this.VerySpecialColour = iSpecialCase;
        this.TagID.Add(-1, 0.0f);
        this.SpecialTip = iTip;
      }

      public ItemPair(
        string iName,
        string iValue,
        bool iAlternate,
        bool iProbability = false,
        bool iSpecialCase = false,
        int iTagID = -1)
      {
        this.Name = iName;
        this.Value = iValue;
        this.AlternateColour = iAlternate;
        this.ProbColour = iProbability;
        this.VerySpecialColour = iSpecialCase;
        this.TagID.Add(iTagID, 0.0f);
        this.SpecialTip = "";
      }

      public ItemPair(
        string iName,
        string iValue,
        bool iAlternate,
        bool iProbability,
        bool iSpecialCase,
        Enums.ShortFX iTagID)
      {
        this.Name = iName;
        this.Value = iValue;
        this.AlternateColour = iAlternate;
        this.ProbColour = iProbability;
        this.VerySpecialColour = iSpecialCase;
        this.TagID.Assign(iTagID);
        this.SpecialTip = "";
      }

      public ItemPair(ctlPairedList.ItemPair iItem)
      {
        this.Name = iItem.Name;
        this.Value = iItem.Value;
        this.AlternateColour = iItem.AlternateColour;
        this.ProbColour = iItem.ProbColour;
        this.VerySpecialColour = iItem.VerySpecialColour;
        this.TagID.Assign(iItem.TagID);
        this.SpecialTip = iItem.SpecialTip;
      }
    }

    public delegate void ItemClickEventHandler(int Index, MouseButtons Button);

    public delegate void ItemHoverEventHandler(object Sender, int Index, Enums.ShortFX TagID);
  }
}
