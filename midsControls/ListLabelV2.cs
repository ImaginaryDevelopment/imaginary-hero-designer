// Decompiled with JetBrains decompiler
// Type: midsControls.ListLabelV2
// Assembly: midsControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EE51258-A5E0-4D99-9BE8-A021331E2192
// Assembly location: C:\Users\Xbass\Desktop\midsControls.dll

using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace midsControls
{
  [DesignerGenerated]
  public class ListLabelV2 : UserControl
  {
    private IContainer components;
    private ExtendedBitmap bxBuffer;
    public ListLabelV2.ListLabelItemV2[] Items;
    protected Color[] Colours;
    protected Cursor[] Cursors;
    protected bool[] HighlightOn;
    protected Color bgColor;
    protected Color hvrColor;
    protected bool TextOutline;
    protected int xPadding;
    protected int yPadding;
    protected int LineHeight;
    protected int HoverIndex;
    protected bool DisableRedraw;
    protected bool DisableEvents;
    protected bool canScroll;
    protected int ScrollOffset;
    protected bool canExpand;
    protected bool Expanded;
    protected Size szNormal;
    protected int expandMaxY;
    protected Rectangle TextArea;
    protected int ScrollWidth;
    protected Color scBarColor;
    protected Color scButtonColor;
    protected int ScrollSteps;
    protected bool DragMode;
    private ListLabelV2.eMouseTarget LastMouseMovetarget;
    private int VisibleLineCount;

    public event ListLabelV2.ItemClickEventHandler ItemClick;

    public event ListLabelV2.ItemHoverEventHandler ItemHover;

    public event ListLabelV2.EmptyHoverEventHandler EmptyHover;

    public event ListLabelV2.ExpandChangedEventHandler ExpandChanged;

    public bool isExpanded
    {
      get
      {
        return this.Expanded;
      }
    }

    public Color TextColor
    {
      get
      {
        if (this.Item.ItemState < ListLabelV2.LLItemState.Enabled | this.Item.ItemState > ListLabelV2.LLItemState.Heading)
          return Color.Black;
        return this.Colours[(int) this.Item.ItemState];
      }
      set
      {
        if (this.Item.ItemState < ListLabelV2.LLItemState.Enabled | this.Item.ItemState > ListLabelV2.LLItemState.Heading)
          return;
        this.Colours[(int) this.Item.ItemState] = value;
        this.Draw();
      }
    }

    public void UpdateTextColors(ListLabelV2.LLItemState State, Color color)
    {
      if (State < ListLabelV2.LLItemState.Enabled | State > ListLabelV2.LLItemState.Heading)
        return;
      this.Colours[(int) State] = color;
      this.Draw();
    }

    public ListLabelV2.ListLabelItemV2 Item
    {
      get
      {
        if (this.Item.Index < 0 | this.Item.Index > checked (this.Items.Length - 1))
          return new ListLabelV2.ListLabelItemV2();
        return this.Items[this.Item.Index];
      }
      set
      {
        if (this.Item.Index < 0 | this.Item.Index > checked (this.Items.Length - 1))
          return;
        this.Items[this.Item.Index] = new ListLabelV2.ListLabelItemV2(value);
        this.Draw();
      }
    }

    public override Color BackColor
    {
      get
      {
        return this.bgColor;
      }
      set
      {
        this.bgColor = value;
        this.Draw();
      }
    }

    public Color HoverColor
    {
      get
      {
        return this.hvrColor;
      }
      set
      {
        this.hvrColor = value;
        this.Draw();
      }
    }

    public int PaddingX
    {
      get
      {
        return this.xPadding;
      }
      set
      {
        if (!(value >= 0 & checked (value * 2) < checked (this.Width - 5)))
          return;
        this.xPadding = value;
        this.Draw();
      }
    }

    public int PaddingY
    {
      get
      {
        return this.yPadding;
      }
      set
      {
        if (!(value >= 0 & (double) value < (double) this.Height / 3.0))
          return;
        this.yPadding = value;
        this.SetLineHeight();
        this.Draw();
      }
    }

    public bool HighVis
    {
      get
      {
        return this.TextOutline;
      }
      set
      {
        this.TextOutline = value;
        this.Draw();
      }
    }

    public int HoverID
    {
      get
      {
        return this.HoverIndex;
      }
    }

    public bool SuspendRedraw
    {
      get
      {
        return this.DisableRedraw;
      }
      set
      {
        this.DisableRedraw = value;
        if (value)
          return;
        if (this.Expanded)
          this.RecomputeExpand();
        if (!this.Expanded)
        {
          this.Recalculate(false);
          this.Draw();
        }
      }
    }

    public bool Scrollable
    {
      get
      {
        return this.canScroll;
      }
      set
      {
        this.canScroll = value;
        this.Draw();
      }
    }

    public bool Expandable
    {
      get
      {
        return this.canExpand;
      }
      set
      {
        this.canExpand = value;
        this.Draw();
      }
    }

    public Size SizeNormal
    {
      get
      {
        return this.szNormal;
      }
      set
      {
        this.szNormal = value;
        this.Expand(this.Expanded);
        this.Draw();
      }
    }

    public int MaxHeight
    {
      get
      {
        return this.expandMaxY;
      }
      set
      {
        if (value < this.szNormal.Height || value > 2000)
          return;
        this.expandMaxY = value;
        this.Draw();
      }
    }

    public int ScrollBarWidth
    {
      get
      {
        return this.ScrollWidth;
      }
      set
      {
        if (value > 0 & (double) value < (double) this.Width / 2.0)
          this.ScrollWidth = value;
        this.Recalculate(false);
        this.Draw();
      }
    }

    public Color ScrollBarColor
    {
      get
      {
        return this.scBarColor;
      }
      set
      {
        this.scBarColor = value;
        this.Draw();
      }
    }

    public Color ScrollButtonColor
    {
      get
      {
        return this.scButtonColor;
      }
      set
      {
        this.scButtonColor = value;
        this.Draw();
      }
    }

    public int ContentHeight
    {
      get
      {
        return this.Height;
      }
    }

    public int DesiredHeight
    {
      get
      {
        return checked (this.GetTotalLineCount() * this.LineHeight);
      }
    }

    public int ActualLineHeight
    {
      get
      {
        return this.LineHeight;
      }
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
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.DoubleBuffered = true;
      this.Name = nameof (ListLabelV2);
      this.Size = new Size(150, 210);
      this.ResumeLayout(false);
    }

    private void ListLabelV2_FontChanged(object sender, EventArgs e)
    {
      this.Recalculate(false);
      this.Draw();
    }

    private void ListLabelV2_Load(object sender, EventArgs e)
    {
      this.szNormal = this.Size;
      this.DisableRedraw = true;
      this.InitBuffer();
      this.Recalculate(false);
      this.FillDefaultItems();
      this.DisableRedraw = false;
    }

    private void FillDefaultItems()
    {
      this.ClearItems();
      this.AddItem(new ListLabelV2.ListLabelItemV2("Header Item", ListLabelV2.LLItemState.Heading, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Enabled", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Disabled Item", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Selected Item", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold | ListLabelV2.LLFontFlags.Italic, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("SD Item", ListLabelV2.LLItemState.SelectedDisabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Invalid Item", ListLabelV2.LLItemState.Invalid, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Automatic multiline Item", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Scrollable", ListLabelV2.LLItemState.Heading, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 1", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 2", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 3", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 4", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 5", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 6", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 7", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 8", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 9", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 10", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 11", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 12", ListLabelV2.LLItemState.Selected, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 13", ListLabelV2.LLItemState.Invalid, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 14", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.AddItem(new ListLabelV2.ListLabelItemV2("Item 15", ListLabelV2.LLItemState.Enabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left));
      this.Draw();
    }

    public void AddItem(ListLabelV2.ListLabelItemV2 iItem)
    {
      this.DisableEvents = true;
      int length = this.Items.Length;
      this.Items = (ListLabelV2.ListLabelItemV2[]) Utils.CopyArray((Array) this.Items, (Array) new ListLabelV2.ListLabelItemV2[checked (length + 1)]);
      this.Items[length] = iItem;
      this.Items[length].Index = length;
      this.WrapString(length);
      this.GetScrollSteps();
      this.DisableEvents = false;
    }

    public void ClearItems()
    {
      this.Items = new ListLabelV2.ListLabelItemV2[0];
      this.ScrollOffset = 0;
      this.HoverIndex = -1;
    }

    private void SetLineHeight()
    {
      this.LineHeight = checked ((int) Math.Round(unchecked ((double) new Font(this.Font, this.Font.Style).GetHeight() + (double) checked (this.yPadding * 2))));
      this.VisibleLineCount = this.GetVisibleLineCount();
    }

    private void Recalculate(bool Expanded = false)
    {
      if (this.Items.Length == 0)
        return;
      this.InitBuffer();
      if (this.AutoSize)
      {
        if (this.AutoSizeMode == AutoSizeMode.GrowAndShrink)
          this.Height = this.DesiredHeight;
        else if (this.DesiredHeight > this.SizeNormal.Height)
          this.Height = this.DesiredHeight;
        else
          this.Height = this.SizeNormal.Height;
      }
      Rectangle bRect = new Rectangle(this.xPadding, 0, checked (this.Width - this.xPadding * 2), this.Height);
      this.RecalcLines(bRect);
      if (this.ScrollSteps > 0 | this.Expanded)
      {
        bRect = new Rectangle(this.xPadding, 0, checked (this.Width - this.xPadding * 2), checked (this.Height - this.ScrollWidth + this.yPadding));
        this.RecalcLines(bRect);
      }
      if (!Expanded && this.ScrollSteps > 0)
      {
        int num = 0;
        if (this.canExpand)
          num = checked (this.ScrollWidth + this.yPadding);
        bRect = new Rectangle(this.xPadding, 0, checked (this.Width - this.xPadding * 2 + this.ScrollWidth), checked (this.Height - num));
        this.RecalcLines(bRect);
      }
    }

    private void RecalcLines(Rectangle bRect)
    {
      this.TextArea = bRect;
      this.SetLineHeight();
      int num1 = 0;
      int num2 = checked (this.Items.Length - 1);
      int Index = num1;
      while (Index <= num2)
      {
        this.WrapString(Index);
        checked { ++Index; }
      }
      this.GetTotalLineCount();
      this.GetScrollSteps();
    }

    private void WrapString(int Index)
    {
      if (Operators.CompareString(this.Items[Index].Text, "", false) == 0)
        return;
      this.InitBuffer();
      int num1 = 1;
      if (this.Items[Index].Text.Contains(" "))
      {
        string[] strArray = this.Items[Index].Text.Split(" ".ToCharArray());
        StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
        Font font = new Font(this.Font, (FontStyle) this.Items[Index].FontFlags);
        string str1 = "";
        if (this.Items[Index].ItemState == ListLabelV2.LLItemState.Heading)
          str1 = "~  ~";
        string str2 = strArray[0];
        int num2 = 1;
        int num3 = checked (strArray.Length - 1);
        int index = num2;
        while (index <= num3)
        {
          if (Math.Ceiling((double) this.bxBuffer.Graphics.MeasureString(str2 + " " + strArray[index] + str1, font, new SizeF(1024f, (float) this.Height), stringFormat).Width) > (double) this.TextArea.Width)
          {
            str2 = this.Items[Index].ItemState != ListLabelV2.LLItemState.Heading ? str2 + "\r\n " + strArray[index] : str2 + " ~\r\n~ " + strArray[index];
            checked { ++num1; }
          }
          else
            str2 = str2 + " " + strArray[index];
          checked { ++index; }
        }
        this.Items[Index].WrappedText = str2;
      }
      else
        this.Items[Index].WrappedText = this.Items[Index].Text;
      if (this.Items[Index].ItemState == ListLabelV2.LLItemState.Heading)
        this.Items[Index].WrappedText = "~ " + this.Items[Index].WrappedText + " ~";
      this.Items[Index].LineCount = num1;
      this.Items[Index].ItemHeight = checked (num1 * (this.LineHeight - this.yPadding * 2) + this.yPadding * 2);
    }

    private void InitBuffer()
    {
      if (this.DisableRedraw || (this.Width == 0 | this.Height == 0) & this.bxBuffer == null)
        return;
      if (this.bxBuffer == null)
        this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      if (this.bxBuffer.Size.Width != this.Width | this.bxBuffer.Size.Height != this.Height)
      {
        this.bxBuffer.Dispose();
        this.bxBuffer = (ExtendedBitmap) null;
        GC.Collect();
        if (this.Height == 0 | this.Width == 0)
          return;
        this.bxBuffer = new ExtendedBitmap(this.Width, this.Height);
      }
      this.bxBuffer.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      this.bxBuffer.Graphics.TextContrast = 0;
    }

    private int GetRealTotalHeight()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = checked (this.Items.Length - 1);
      int index = num2;
      while (index <= num3)
      {
        checked { num1 += this.Items[index].ItemHeight; }
        checked { ++index; }
      }
      return num1;
    }

    private void Draw()
    {
      if (this.DisableRedraw || !this.Visible)
        return;
      this.InitBuffer();
      if (this.Width == 0 | this.Height == 0)
        return;
      if (this.Expanded)
        this.bxBuffer.Graphics.Clear(Color.Black);
      else
        this.bxBuffer.Graphics.Clear(this.BackColor);
      int scrollOffset = this.ScrollOffset;
      int num = checked (this.Items.Length - 1);
      int Index = scrollOffset;
      while (Index <= num)
      {
        this.DrawItem(Index);
        checked { ++Index; }
      }
      this.DrawScrollBar();
      this.DrawExpandButton();
      this.CreateGraphics().DrawImageUnscaled((Image) this.bxBuffer.Bitmap, 0, 0);
    }

    protected void DrawItem(int Index)
    {
      if (Index < 0 || Index < this.ScrollOffset || Index > checked (this.Items.Length - 1))
        return;
      int y = 0;
      int scrollOffset = this.ScrollOffset;
      int num = checked (Index - 1);
      int index = scrollOffset;
      while (index <= num)
      {
        checked { y += this.Items[index].ItemHeight; }
        if (y > this.Height)
          return;
        checked { ++index; }
      }
      int height = this.Items[Index].ItemHeight;
      if (this.Items[Index].LineCount == 1)
      {
        if (checked (y + this.Items[Index].ItemHeight) > this.TextArea.Height)
          return;
      }
      else if (checked (y + this.Items[Index].ItemHeight) > this.TextArea.Height)
      {
        if (checked (y + this.LineHeight) > this.TextArea.Height)
          return;
        height = checked (this.LineHeight - this.yPadding);
      }
      Rectangle rect = new Rectangle(this.TextArea.Left, y, this.TextArea.Width, height);
      StringFormat format = new StringFormat();
      switch (this.Items[Index].TextAlign)
      {
        case ListLabelV2.LLTextAlign.Left:
          format.Alignment = StringAlignment.Near;
          break;
        case ListLabelV2.LLTextAlign.Center:
          format.Alignment = StringAlignment.Center;
          break;
        case ListLabelV2.LLTextAlign.Right:
          format.Alignment = StringAlignment.Far;
          break;
      }

        // Font Style
        /*Regular = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
        Strikeout = 8
        */
      FontStyle newStyle = FontStyle.Regular;
      if (this.Items[Index].Bold)
        ++newStyle;
      if (this.Items[Index].Italic)
        newStyle += 2;
      if (this.Items[Index].Underline)
        newStyle += 4;
      if (this.Items[Index].Strikethrough)
        newStyle += 8; 
      Font font = new Font(this.Font, newStyle);
      if (Index == this.HoverID && this.HighlightOn[(int) this.Items[Index].ItemState])
        this.bxBuffer.Graphics.FillRectangle((Brush) new SolidBrush(this.hvrColor), rect);
      SolidBrush solidBrush1 = new SolidBrush(Color.Black);
      if (this.TextOutline)
      {
        Rectangle rectangle = rect;
        checked { --rectangle.X; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { --rectangle.Y; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { ++rectangle.X; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { ++rectangle.X; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { ++rectangle.Y; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { ++rectangle.Y; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { --rectangle.X; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
        checked { --rectangle.X; }
        this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush1, (RectangleF) rectangle, format);
      }
      SolidBrush solidBrush2 = new SolidBrush(this.Colours[(int) this.Items[Index].ItemState]);
      this.bxBuffer.Graphics.DrawString(this.Items[Index].WrappedText, font, (Brush) solidBrush2, (RectangleF) rect, format);
    }

    private int GetVisibleLineCount()
    {
      if (!this.canScroll)
      {
        this.ScrollSteps = 0;
        return 0;
      }
      if (this.Expanded)
        return this.GetTotalLineCount();
      return checked ((int) Math.Round(Conversion.Int(unchecked ((double) this.TextArea.Height / (double) this.LineHeight))));
    }

    private int GetTotalLineCount()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = checked (this.Items.Length - 1);
      int index = num2;
      while (index <= num3)
      {
        checked { num1 += this.Items[index].LineCount; }
        checked { ++index; }
      }
      return num1;
    }

    private int GetScrollSteps()
    {
      if (!this.canScroll)
      {
        this.ScrollSteps = 0;
        return 0;
      }
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = checked (this.Items.Length - 1);
      int index = num3;
      while (index <= num4)
      {
        checked { num1 += this.Items[index].LineCount; }
        if (num1 > this.VisibleLineCount)
          checked { ++num2; }
        checked { ++index; }
      }
      if (num2 > 0)
        checked { ++num2; }
      this.ScrollSteps = num2;
      if (this.ScrollSteps <= 1)
        this.ScrollSteps = 0;
      return this.ScrollSteps;
    }

    private void DrawScrollBar()
    {
      if (this.ScrollWidth < 1 | !this.canScroll | this.ScrollSteps < 1)
        return;
      SolidBrush solidBrush1 = new SolidBrush(this.scBarColor);
      Pen pen1 = new Pen(this.scBarColor);
      Pen pen2 = new Pen(Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), 1f);
      Pen pen3 = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
      this.bxBuffer.Graphics.DrawLine(pen1, checked ((int) Math.Round(unchecked ((double) this.TextArea.Right + (double) this.ScrollWidth / 2.0))), checked (this.yPadding + this.ScrollWidth), checked ((int) Math.Round(unchecked ((double) this.TextArea.Right + (double) this.ScrollWidth / 2.0))), checked (this.Height - this.ScrollWidth + this.yPadding));
      SolidBrush solidBrush2 = new SolidBrush(this.scButtonColor);
      PointF[] points = new PointF[3];
      Rectangle rect;
      if (this.ScrollSteps > 0)
      {
        int num = checked (this.Height - (this.yPadding + this.ScrollWidth) * 2 - this.yPadding * 2);
        rect = new Rectangle(this.TextArea.Right, checked ((int) Math.Round(unchecked ((double) checked (this.ScrollWidth + this.yPadding * 2) + (double) num / (double) this.ScrollSteps * (double) this.ScrollOffset))), this.ScrollWidth, checked ((int) Math.Round(unchecked ((double) num / (double) this.ScrollSteps))));
        this.bxBuffer.Graphics.FillRectangle((Brush) solidBrush2, rect);
        this.bxBuffer.Graphics.DrawLine(pen2, rect.Left, rect.Top, rect.Left, rect.Bottom);
        this.bxBuffer.Graphics.DrawLine(pen2, checked (rect.Left + 1), rect.Top, rect.Right, rect.Top);
        this.bxBuffer.Graphics.DrawLine(pen3, rect.Right, rect.Top, rect.Right, rect.Bottom);
        this.bxBuffer.Graphics.DrawLine(pen3, checked (rect.Left + 1), rect.Bottom, checked (rect.Right - 1), rect.Bottom);
      }
      rect = new Rectangle(this.TextArea.Right, checked (this.yPadding + this.ScrollWidth), this.ScrollWidth, checked (this.Height - (this.ScrollWidth + this.yPadding) * 2));
      points[0] = new PointF((float) rect.Left, (float) rect.Top);
      points[1] = new PointF((float) rect.Right, (float) rect.Top);
      points[2] = new PointF((float) rect.Left + (float) rect.Width / 2f, (float) this.yPadding);
      this.bxBuffer.Graphics.FillPolygon((Brush) solidBrush2, points);
      this.bxBuffer.Graphics.DrawLine(pen2, points[0], points[2]);
      this.bxBuffer.Graphics.DrawLine(pen3, points[0], points[1]);
      points[0] = new PointF((float) rect.Left, (float) rect.Bottom);
      points[1] = new PointF((float) rect.Right, (float) rect.Bottom);
      points[2] = new PointF((float) rect.Left + (float) rect.Width / 2f, (float) checked (this.Height - this.yPadding));
      this.bxBuffer.Graphics.FillPolygon((Brush) solidBrush2, points);
      this.bxBuffer.Graphics.DrawLine(pen2, points[0], points[1]);
      this.bxBuffer.Graphics.DrawLine(pen3, points[2], points[1]);
    }

    private void DrawExpandButton()
    {
      if (!this.canExpand | !this.Expanded & this.ScrollSteps < 1)
        return;
      SolidBrush solidBrush1 = new SolidBrush(this.scButtonColor);
      Pen pen1 = new Pen(this.scBarColor);
      Pen pen2 = new Pen(Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), 1f);
      Pen pen3 = new Pen(Color.FromArgb(128, 0, 0, 0), 1f);
      SolidBrush solidBrush2 = new SolidBrush(this.scButtonColor);
      PointF[] points = new PointF[3];
      Rectangle rectangle = new Rectangle(checked ((int) Math.Round(unchecked ((double) this.Width / 3.0))), checked (this.Height - this.ScrollWidth + this.yPadding), checked ((int) Math.Round(unchecked ((double) this.Width / 3.0))), checked (this.ScrollWidth - this.yPadding));
      if (this.Expanded)
      {
        points[0] = new PointF((float) rectangle.Left, (float) rectangle.Bottom);
        points[1] = new PointF((float) rectangle.Right, (float) rectangle.Bottom);
        points[2] = new PointF((float) rectangle.Left + (float) rectangle.Width / 2f, (float) rectangle.Top);
        this.bxBuffer.Graphics.FillPolygon((Brush) solidBrush2, points);
        this.bxBuffer.Graphics.DrawLine(pen2, points[0], points[2]);
        this.bxBuffer.Graphics.DrawLine(pen3, points[0], points[1]);
        this.bxBuffer.Graphics.DrawLine(pen1, 0, 0, 0, checked (this.Height - 1));
        this.bxBuffer.Graphics.DrawLine(pen1, 0, checked (this.Height - 1), checked (this.Width - 1), checked (this.Height - 1));
        this.bxBuffer.Graphics.DrawLine(pen1, checked (this.Width - 1), this.Height, checked (this.Width - 1), 0);
      }
      else
      {
        points[0] = new PointF((float) rectangle.Left, (float) rectangle.Top);
        points[1] = new PointF((float) rectangle.Right, (float) rectangle.Top);
        points[2] = new PointF((float) rectangle.Left + (float) rectangle.Width / 2f, (float) rectangle.Bottom);
        this.bxBuffer.Graphics.FillPolygon((Brush) solidBrush2, points);
        this.bxBuffer.Graphics.DrawLine(pen2, points[0], points[1]);
        this.bxBuffer.Graphics.DrawLine(pen3, points[2], points[1]);
      }
    }

    private int GetItemAtY(int Y)
    {
      int num1 = 0;
      if (Y > this.Height)
        return -1;
      int scrollOffset = this.ScrollOffset;
      int num2 = checked (this.Items.Length - 1);
      int index = scrollOffset;
      while (index <= num2)
      {
        checked { num1 += this.Items[index].ItemHeight; }
        if (Y < num1)
          return index;
        checked { ++index; }
      }
      return -1;
    }

    private ListLabelV2.eMouseTarget GetMouseTarget(int X, int Y)
    {
      if (X >= this.TextArea.Left & X <= this.TextArea.Right & Y <= this.TextArea.Bottom)
        return ListLabelV2.eMouseTarget.Item;
      if (X >= this.TextArea.Left & X <= this.TextArea.Right & Y > this.TextArea.Bottom)
        return ListLabelV2.eMouseTarget.ExpandButton;
      if (X > this.TextArea.Right & Y <= checked (this.ScrollWidth + this.yPadding))
        return ListLabelV2.eMouseTarget.UpButton;
      if (X > this.TextArea.Right & Y >= checked (this.Height - this.ScrollWidth + this.yPadding))
        return ListLabelV2.eMouseTarget.DownButton;
      if (!(X > this.TextArea.Right & this.ScrollSteps > 0))
        return ListLabelV2.eMouseTarget.None;
      int num1 = checked (this.Height - (this.yPadding + this.ScrollWidth) * 2 - this.yPadding * 2);
      int num2 = checked ((int) Math.Round(unchecked ((double) checked (this.ScrollWidth + this.yPadding * 2) + (double) num1 / (double) this.ScrollSteps * (double) this.ScrollOffset)));
      int num3 = checked ((int) Math.Round(unchecked ((double) num1 / (double) this.ScrollSteps)));
      if (Y < num2)
        return ListLabelV2.eMouseTarget.ScrollBarUp;
      return Y > checked (num2 + num3) ? ListLabelV2.eMouseTarget.ScrollBarDown : ListLabelV2.eMouseTarget.ScrollBlock;
    }

    private void ListLabelV2_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left & Control.ModifierKeys == (Keys.Shift | Keys.Control | Keys.Alt))
      {
        this.DisableEvents = false;
        this.DisableRedraw = false;
        this.Recalculate(false);
        this.Draw();
        this.CreateGraphics().DrawRectangle(Pens.PowderBlue, new Rectangle(0, 0, checked (this.Width - 1), checked (this.Height - 1)));
      }
      else
      {
        if (this.DisableEvents)
          return;
        int num1 = (double) this.ScrollSteps / 3.0 >= 5.0 ? 5 : checked ((int) Math.Round(unchecked ((double) this.ScrollSteps / 3.0)));
        switch (this.GetMouseTarget(e.X, e.Y))
        {
          case ListLabelV2.eMouseTarget.Item:
            int itemAtY = this.GetItemAtY(e.Y);
            if (itemAtY > -1)
            {
              int num2 = 0;
              int scrollOffset = this.ScrollOffset;
              int num3 = checked (itemAtY - 1);
              int index = scrollOffset;
              while (index <= num3)
              {
                checked { num2 += this.Items[index].ItemHeight; }
                checked { ++index; }
              }
              if (checked (num2 + this.Items[itemAtY].ItemHeight) >= e.Y & checked (num2 + this.Items[itemAtY].ItemHeight) <= this.TextArea.Height | this.Items[itemAtY].LineCount > 1 & checked (num2 + this.LineHeight) >= e.Y & checked (num2 + this.LineHeight) <= this.TextArea.Height)
              {
                ListLabelV2.ItemClickEventHandler itemClickEvent = this.ItemClickEvent;
                if (itemClickEvent != null)
                  itemClickEvent(this.Items[itemAtY], e.Button);
              }
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.UpButton:
            if (this.ScrollSteps > 0 & this.ScrollOffset > 0)
            {
              checked { --this.ScrollOffset; }
              this.Draw();
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.DownButton:
            if (this.ScrollSteps > 0 & checked (this.ScrollOffset + 1) < this.ScrollSteps)
            {
              checked { ++this.ScrollOffset; }
              this.Draw();
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.ScrollBarUp:
            if (this.ScrollSteps > 0)
            {
              checked { this.ScrollOffset -= num1; }
              if (this.ScrollOffset < 0)
                this.ScrollOffset = 0;
              this.Draw();
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.ScrollBarDown:
            if (this.ScrollSteps > 0)
            {
              checked { this.ScrollOffset += num1; }
              if (this.ScrollOffset >= this.ScrollSteps)
                this.ScrollOffset = checked (this.ScrollSteps - 1);
              this.Draw();
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.ScrollBlock:
            if (this.ScrollSteps > 0)
            {
              this.DragMode = true;
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.ExpandButton:
            if (!this.Expanded)
            {
              this.Expanded = true;
              this.ScrollOffset = 0;
              this.RecomputeExpand();
            }
            else
            {
              this.DisableRedraw = true;
              this.Height = this.szNormal.Height;
              this.Expanded = false;
              this.Recalculate(false);
              this.DisableRedraw = false;
              this.Draw();
            }
                        //ListLabelV2.ExpandChangedEventHandler expandChangedEvent = this.ExpandChangedEvent;
                        ListLabelV2.ExpandChangedEventHandler expandChangedEvent = new ExpandChangedEventHandler(this.Expand);
                        if (expandChangedEvent != null)
            {
              expandChangedEvent(this.Expanded);
              break;
            }
            break;
        }
      }
    }

        private void ItemClickEvent(ListLabelItemV2 Item, MouseButtons Button)
        {
            throw new NotImplementedException();
        }

        private void Expand(bool State)
    {
      if (State)
      {
        this.Expanded = true;
        this.ScrollOffset = 0;
        this.RecomputeExpand();
      }
      else
      {
        this.DisableRedraw = true;
        this.Height = this.szNormal.Height;
        this.Expanded = false;
        this.Recalculate(false);
        this.DisableRedraw = false;
        this.Draw();
      }
      //ListLabelV2.ExpandChangedEventHandler expandChangedEvent = this.ExpandChangedEvent;
      ListLabelV2.ExpandChangedEventHandler expandChangedEvent = new ExpandChangedEventHandler(this.Expand);
      if (expandChangedEvent == null)
        return;
            
      expandChangedEvent(this.Expanded);
    }

        private void RecomputeExpand()
    {
      if (!this.Expanded)
        return;
      int num1 = this.expandMaxY;
      this.Recalculate(true);
      int num2 = checked (this.GetRealTotalHeight() + this.ScrollWidth + this.yPadding * 3);
      if (num2 < num1)
        num1 = num2;
      this.DisableRedraw = true;
      this.Height = num1;
      this.Recalculate(false);
      this.DisableRedraw = false;
      this.Draw();
    }

    private void ListLabelV2_MouseLeave(object sender, EventArgs e)
    {
      this.Cursor = System.Windows.Forms.Cursors.Default;
      this.LastMouseMovetarget = ListLabelV2.eMouseTarget.None;
      this.HoverIndex = -1;
      this.Draw();
      ListLabelV2.EmptyHoverEventHandler emptyHoverEvent = this.EmptyHoverEvent;
      if (emptyHoverEvent == null)
        return;
      emptyHoverEvent();
    }

        private void EmptyHoverEvent()
        {
            throw new NotImplementedException();
        }

        private void ListLabelV2_MouseMove(object sender, MouseEventArgs e)
    {
      Cursor cursor = System.Windows.Forms.Cursors.Default;
      ListLabelV2.eMouseTarget mouseTarget = this.GetMouseTarget(e.X, e.Y);
      bool flag = false;
      if (!this.DragMode)
      {
        switch (mouseTarget)
        {
          case ListLabelV2.eMouseTarget.Item:
            int itemAtY = this.GetItemAtY(e.Y);
            if (itemAtY <= -1)
            {
              if (this.HoverIndex != -1)
                flag = true;
              this.HoverIndex = -1;
              ListLabelV2.EmptyHoverEventHandler emptyHoverEvent = this.EmptyHoverEvent;
              if (emptyHoverEvent != null)
              {
                emptyHoverEvent();
                break;
              }
              break;
            }
            int num1 = 0;
            int scrollOffset = this.ScrollOffset;
            int num2 = checked (itemAtY - 1);
            int index = scrollOffset;
            while (index <= num2)
            {
              checked { num1 += this.Items[index].ItemHeight; }
              checked { ++index; }
            }
            if (!(checked (num1 + this.Items[itemAtY].ItemHeight) >= e.Y & checked (num1 + this.Items[itemAtY].ItemHeight) <= this.TextArea.Height | this.Items[itemAtY].LineCount > 1 & checked (num1 + this.LineHeight) >= e.Y & checked (num1 + this.LineHeight) <= this.TextArea.Height))
            {
              if (this.HoverIndex != -1)
                flag = true;
              this.HoverIndex = -1;
              ListLabelV2.EmptyHoverEventHandler emptyHoverEvent = this.EmptyHoverEvent;
              if (emptyHoverEvent != null)
              {
                emptyHoverEvent();
                break;
              }
              break;
            }
            cursor = this.Cursors[(int) this.Items[itemAtY].ItemState];
            if (itemAtY != this.HoverIndex)
              this.HoverIndex = itemAtY;
            this.Draw();
            ListLabelV2.ItemHoverEventHandler itemHoverEvent = this.ItemHoverEvent;
            if (itemHoverEvent != null)
            {
              itemHoverEvent(this.Items[itemAtY]);
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.UpButton:
            if (this.LastMouseMovetarget != mouseTarget)
              this.Draw();
            ListLabelV2.EmptyHoverEventHandler emptyHoverEvent1 = this.EmptyHoverEvent;
            if (emptyHoverEvent1 != null)
            {
              emptyHoverEvent1();
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.DownButton:
            if (this.LastMouseMovetarget != mouseTarget)
              this.Draw();
            ListLabelV2.EmptyHoverEventHandler emptyHoverEvent2 = this.EmptyHoverEvent;
            if (emptyHoverEvent2 != null)
            {
              emptyHoverEvent2();
              break;
            }
            break;
          case ListLabelV2.eMouseTarget.ExpandButton:
            this.HoverIndex = -1;
            ListLabelV2.EmptyHoverEventHandler emptyHoverEvent3 = this.EmptyHoverEvent;
            if (emptyHoverEvent3 != null)
            {
              emptyHoverEvent3();
              break;
            }
            break;
          default:
            ListLabelV2.EmptyHoverEventHandler emptyHoverEvent4 = this.EmptyHoverEvent;
            if (emptyHoverEvent4 != null)
            {
              emptyHoverEvent4();
              break;
            }
            break;
        }
      }
      else if (e.Button == MouseButtons.None)
      {
        this.DragMode = false;
      }
      else
      {
        cursor = System.Windows.Forms.Cursors.SizeNS;
        int num3 = checked (this.Height - (this.yPadding + this.ScrollWidth) * 2 - this.yPadding * 2);
        int num4 = checked ((int) Math.Round(unchecked ((double) checked (this.ScrollWidth + this.yPadding * 2) + (double) num3 / (double) this.ScrollSteps * (double) this.ScrollOffset)));
        int num5 = checked ((int) Math.Round(unchecked ((double) num3 / (double) this.ScrollSteps)));
        if (e.Y < num4 & this.ScrollOffset > 0)
        {
          checked { --this.ScrollOffset; }
          this.Draw();
        }
        else if (e.Y > checked (num4 + num5) & checked (this.ScrollOffset + 1) < this.ScrollSteps)
        {
          checked { ++this.ScrollOffset; }
          this.Draw();
        }
        ListLabelV2.EmptyHoverEventHandler emptyHoverEvent5 = this.EmptyHoverEvent;
        if (emptyHoverEvent5 != null)
          emptyHoverEvent5();
      }
      if (flag)
        this.Draw();
      this.Cursor = cursor;
      this.LastMouseMovetarget = mouseTarget;
    }

        private void ItemHoverEvent(ListLabelItemV2 Item)
        {
            throw new NotImplementedException();
        }

        private void ListLabelV2_MouseUp(object sender, MouseEventArgs e)
    {
      this.DragMode = false;
      if (!(this.Cursor == System.Windows.Forms.Cursors.SizeNS))
        return;
      this.Cursor = System.Windows.Forms.Cursors.Default;
    }

    private void ListLabelV2_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxBuffer == null)
        this.Draw();
      if (this.bxBuffer == null)
        return;
      e.Graphics.DrawImage((Image) this.bxBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
    }

    private void ListLabelV2_Resize(object sender, EventArgs e)
    {
      this.ScrollOffset = 0;
      this.Recalculate(false);
      this.Draw();
    }

    public ListLabelV2()
    {
      this.MouseLeave += new EventHandler(this.ListLabelV2_MouseLeave);
      this.MouseMove += new MouseEventHandler(this.ListLabelV2_MouseMove);
      this.MouseUp += new MouseEventHandler(this.ListLabelV2_MouseUp);
      this.Paint += new PaintEventHandler(this.ListLabelV2_Paint);
      this.Resize += new EventHandler(this.ListLabelV2_Resize);
      this.FontChanged += new EventHandler(this.ListLabelV2_FontChanged);
      this.Load += new EventHandler(this.ListLabelV2_Load);
      this.MouseDown += new MouseEventHandler(this.ListLabelV2_MouseDown);
      this.bxBuffer = (ExtendedBitmap) null;
      this.Items = new ListLabelV2.ListLabelItemV2[0];
      this.Colours = new Color[6]
      {
        Color.LightBlue,
        Color.LightGreen,
        Color.LightGray,
        Color.DarkGreen,
        Color.Red,
        Color.Orange
      };
      this.Cursors = new Cursor[6]
      {
        System.Windows.Forms.Cursors.Hand,
        System.Windows.Forms.Cursors.Hand,
        System.Windows.Forms.Cursors.Default,
        System.Windows.Forms.Cursors.Hand,
        System.Windows.Forms.Cursors.Hand,
        System.Windows.Forms.Cursors.Default
      };
      this.HighlightOn = new bool[7]
      {
        true,
        true,
        true,
        true,
        true,
        true,
        false
      };
      this.bgColor = Color.Black;
      this.hvrColor = Color.WhiteSmoke;
      this.TextOutline = true;
      this.xPadding = 1;
      this.yPadding = 1;
      this.LineHeight = 8;
      this.HoverIndex = -1;
      this.DisableRedraw = true;
      this.DisableEvents = false;
      this.canScroll = true;
      this.ScrollOffset = 0;
      this.canExpand = false;
      this.Expanded = false;
      this.szNormal = this.Size;
      this.expandMaxY = 400;
      this.TextArea = new Rectangle(0, 0, this.Width, this.Height);
      this.ScrollWidth = 8;
      this.scBarColor = Color.FromArgb(128, 96, 192);
      this.scButtonColor = Color.FromArgb(96, 0, 192);
      this.ScrollSteps = 0;
      this.DragMode = false;
      this.LastMouseMovetarget = ListLabelV2.eMouseTarget.None;
      this.VisibleLineCount = 0;
      this.InitializeComponent();
    }

    public enum LLItemState
    {
      Enabled,
      Selected,
      Disabled,
      SelectedDisabled,
      Invalid,
      Heading,
    }

    [Flags]
    public enum LLFontFlags
    {
      Normal = 0,
      Bold = 1,
      Italic = 2,
      Underline = 4,
      Strikethrough = 8,
    }

    public enum LLTextAlign
    {
      Left,
      Center,
      Right,
    }

    private enum eMouseTarget
    {
      None,
      Item,
      UpButton,
      DownButton,
      ScrollBarUp,
      ScrollBarDown,
      ScrollBlock,
      ExpandButton,
    }

    public class ListLabelItemV2
    {
      protected string Txt;
      public string WrappedText;
      protected ListLabelV2.LLItemState State;
      public ListLabelV2.LLFontFlags FontFlags;
      protected ListLabelV2.LLTextAlign Alignment;
      public int nIDSet;
      public int IDXPower;
      public int nIDPower;
      protected string sTag;
      public int LineCount;
      public int ItemHeight;
      public int Index;

      public string Text
      {
        get
        {
          return this.Txt;
        }
        set
        {
          this.Txt = value;
        }
      }

      public ListLabelV2.LLItemState ItemState
      {
        get
        {
          return this.State;
        }
        set
        {
          this.State = value;
        }
      }

      public bool Bold
      {
        get
        {
          return (this.FontFlags & ListLabelV2.LLFontFlags.Bold) > ListLabelV2.LLFontFlags.Normal;
        }
        set
        {
          if (value)
          {
            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Bold) <= ListLabelV2.LLFontFlags.Normal)
              return;
            ++this.FontFlags;
          }
          else
          {
            if ((this.FontFlags & ListLabelV2.LLFontFlags.Bold) <= ListLabelV2.LLFontFlags.Normal)
              return;
            --this.FontFlags;
          }
        }
      }

      public bool Italic
      {
        get
        {
          return (this.FontFlags & ListLabelV2.LLFontFlags.Italic) > ListLabelV2.LLFontFlags.Normal;
        }
        set
        {
          if (value)
          {
            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Italic) <= ListLabelV2.LLFontFlags.Normal)
              return;
            this.FontFlags += 2;
          }
          else
          {
            if ((this.FontFlags & ListLabelV2.LLFontFlags.Italic) <= ListLabelV2.LLFontFlags.Normal)
              return;
            this.FontFlags -= 2;
          }
        }
      }

      public bool Underline
      {
        get
        {
          return (this.FontFlags & ListLabelV2.LLFontFlags.Underline) > ListLabelV2.LLFontFlags.Normal;
        }
        set
        {
          if (value)
          {
            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Underline) <= ListLabelV2.LLFontFlags.Normal)
              return;
            this.FontFlags += 4;
          }
          else
          {
            if ((this.FontFlags & ListLabelV2.LLFontFlags.Underline) <= ListLabelV2.LLFontFlags.Normal)
              return;
            this.FontFlags -= ListLabelV2.LLFontFlags.Underline;
          }
        }
      }

      public bool Strikethrough
      {
        get
        {
          return (this.FontFlags & ListLabelV2.LLFontFlags.Strikethrough) > ListLabelV2.LLFontFlags.Normal;
        }
        set
        {
          if (value)
          {
            if ((~this.FontFlags & ListLabelV2.LLFontFlags.Strikethrough) <= ListLabelV2.LLFontFlags.Normal)
              return;
            this.FontFlags += 8;
          }
          else
          {
            if ((this.FontFlags & ListLabelV2.LLFontFlags.Strikethrough) <= ListLabelV2.LLFontFlags.Normal)
              return;
            this.FontFlags -= ListLabelV2.LLFontFlags.Strikethrough;
          }
        }
      }

      public ListLabelV2.LLTextAlign TextAlign
      {
        get
        {
          return this.Alignment;
        }
        set
        {
          this.Alignment = value;
        }
      }

      public ListLabelItemV2()
      {
        this.Txt = "";
        this.WrappedText = "";
        this.State = ListLabelV2.LLItemState.Enabled;
        this.FontFlags = ListLabelV2.LLFontFlags.Normal;
        this.Alignment = ListLabelV2.LLTextAlign.Left;
        this.nIDSet = -1;
        this.IDXPower = -1;
        this.nIDPower = -1;
        this.sTag = "";
        this.LineCount = 1;
        this.ItemHeight = 1;
        this.Index = -1;
      }

      public ListLabelItemV2(
        string iText,
        ListLabelV2.LLItemState iState,
        int inIDSet = -1,
        int iIDXPower = -1,
        int inIDPower = -1,
        string iStringTag = "",
        ListLabelV2.LLFontFlags iFont = ListLabelV2.LLFontFlags.Normal,
        ListLabelV2.LLTextAlign iAlign = ListLabelV2.LLTextAlign.Left)
      {
        this.Txt = "";
        this.WrappedText = "";
        this.State = ListLabelV2.LLItemState.Enabled;
        this.FontFlags = ListLabelV2.LLFontFlags.Normal;
        this.Alignment = ListLabelV2.LLTextAlign.Left;
        this.nIDSet = -1;
        this.IDXPower = -1;
        this.nIDPower = -1;
        this.sTag = "";
        this.LineCount = 1;
        this.ItemHeight = 1;
        this.Index = -1;
        this.Txt = iText;
        this.State = iState;
        this.nIDSet = inIDSet;
        this.IDXPower = iIDXPower;
        this.nIDPower = inIDPower;
        this.sTag = iStringTag;
        this.FontFlags = iFont;
        this.Alignment = iAlign;
      }

      public ListLabelItemV2(ListLabelV2.ListLabelItemV2 Template)
      {
        this.Txt = "";
        this.WrappedText = "";
        this.State = ListLabelV2.LLItemState.Enabled;
        this.FontFlags = ListLabelV2.LLFontFlags.Normal;
        this.Alignment = ListLabelV2.LLTextAlign.Left;
        this.nIDSet = -1;
        this.IDXPower = -1;
        this.nIDPower = -1;
        this.sTag = "";
        this.LineCount = 1;
        this.ItemHeight = 1;
        this.Index = -1;
        this.Txt = Template.Txt;
        this.State = Template.State;
        this.FontFlags = Template.FontFlags;
        this.Alignment = Template.Alignment;
        this.LineCount = Template.LineCount;
        this.ItemHeight = Template.ItemHeight;
        this.nIDSet = Template.nIDSet;
        this.IDXPower = Template.IDXPower;
        this.nIDPower = Template.nIDPower;
        this.sTag = Template.sTag;
      }
    }

    public delegate void ItemClickEventHandler(
      ListLabelV2.ListLabelItemV2 Item,
      MouseButtons Button);

    public delegate void ItemHoverEventHandler(ListLabelV2.ListLabelItemV2 Item);

    public delegate void EmptyHoverEventHandler();

    public delegate void ExpandChangedEventHandler(bool Expanded);
  }
}
