// Decompiled with JetBrains decompiler
// Type: midsControls.ctlPopUp
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
using System.Windows.Forms;

namespace midsControls
{
  [DesignerGenerated]
  public class ctlPopUp : UserControl
  {
    private IContainer components;
    private ExtendedBitmap myBX;
    public PopUp.PopupData pData;
    private int pSectionPadding;
    private int pInternalPadding;
    private float pScroll;
    public float lHeight;
    private int pBXHeight;
    private float pColumnPosition;
    private bool pRightAlignColumn;
    public int hIDX;
    public int pIDX;
    public int eIDX;
    public int psIDX;

    public int BXHeight
    {
      get
      {
        return this.pBXHeight;
      }
      set
      {
        this.pBXHeight = value;
        this.NewBX();
      }
    }

    public float ColumnPosition
    {
      get
      {
        return this.pColumnPosition;
      }
      set
      {
        this.pColumnPosition = value;
        this.Draw();
      }
    }

    public bool ColumnRight
    {
      get
      {
        return this.pRightAlignColumn;
      }
      set
      {
        this.pRightAlignColumn = value;
        this.Draw();
      }
    }

    public int SectionPadding
    {
      get
      {
        return this.pSectionPadding;
      }
      set
      {
        this.pSectionPadding = value;
        this.Draw();
      }
    }

    public int InternalPadding
    {
      get
      {
        return this.pInternalPadding;
      }
      set
      {
        this.pInternalPadding = value;
        this.Draw();
      }
    }

    public float ScrollY
    {
      get
      {
        return this.pScroll;
      }
      set
      {
        if ((double) this.pScroll == (double) value)
          return;
        this.pScroll = value;
        this.Draw();
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
      this.AutoScaleMode = AutoScaleMode.None;
      this.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, (byte) 0);
      this.Name = nameof (ctlPopUp);
      this.Size = new Size(167, 104);
      this.ResumeLayout(false);
    }

    private void ctlPopUp_BackColorChanged(object sender, EventArgs e)
    {
      this.NewBX();
      this.Draw();
    }

    private void ctlPopUp_FontChanged(object sender, EventArgs e)
    {
      this.NewBX();
      this.Draw();
    }

    private void ctlPopUp_ForeColorChanged(object sender, EventArgs e)
    {
      this.NewBX();
      this.Draw();
    }

    private void ctlPopUp_Load(object sender, EventArgs e)
    {
      this.NewBX();
      this.pData = new PopUp.PopupData();
      this.pData.Init();
      this.Draw();
    }

    private void NewBX()
    {
      if (this.pBXHeight < 300)
        this.pBXHeight = 300;
      this.myBX = new ExtendedBitmap(this.Size.Width, this.pBXHeight);
      this.myBX.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    }

    public void SetPopup(PopUp.PopupData iPopup)
    {
      this.pData = iPopup;
      this.Draw();
    }

    private void Draw()
    {
      if (this.myBX == null)
        this.NewBX();
      this.myBX.Graphics.Clear(this.BackColor);
      this.DrawBorder();
      this.DrawStrings();
      this.CreateGraphics().DrawImageUnscaled((Image) this.myBX.Bitmap, 0, 0);
    }

    private void DrawStrings()
    {
      float num1 = 0.0f;
      if (this.pData.Sections == null)
        return;
      StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
      float pColumnPosition = this.pColumnPosition;
      bool rightAlignColumn = this.pRightAlignColumn;
      if (this.pData.CustomSet)
      {
        this.pColumnPosition = this.pData.ColPos;
        this.pRightAlignColumn = this.pData.ColRight;
      }
      stringFormat.LineAlignment = StringAlignment.Near;
      stringFormat.Alignment = StringAlignment.Near;
      stringFormat.Trimming = StringTrimming.None;
      int num2 = 0;
      int num3 = checked (this.pData.Sections.Length - 1);
      int index1 = num2;
      while (index1 <= num3)
      {
        if (this.pData.Sections[index1].Content != null)
        {
          int num4 = 0;
          int num5 = checked (this.pData.Sections[index1].Content.Length - 1);
          int index2 = num4;
          while (index2 <= num5)
          {
            Font font = new Font(this.Font.FontFamily, this.Font.Size * this.pData.Sections[index1].Content[index2].tSize, this.pData.Sections[index1].Content[index2].tFormat, this.Font.Unit);
            RectangleF layoutRectangle = new RectangleF((float) this.pInternalPadding + (float) this.pData.Sections[index1].Content[index2].tIndent * this.Font.Size, num1 + (float) this.pInternalPadding, (float) this.Width - ((float) checked (this.pInternalPadding * 2) + (float) this.pData.Sections[index1].Content[index2].tIndent * this.Font.Size), (float) this.myBX.Size.Height);
            if (this.pData.Sections[index1].Content[index2].HasColumn)
              stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
            SizeF sizeF = Operators.CompareString(this.pData.Sections[index1].Content[index2].Text, "", false) != 0 ? this.myBX.Graphics.MeasureString(this.pData.Sections[index1].Content[index2].Text, font, layoutRectangle.Size, stringFormat) : this.myBX.Graphics.MeasureString("Null String", font, layoutRectangle.Size, stringFormat);
            SolidBrush solidBrush1 = new SolidBrush(this.pData.Sections[index1].Content[index2].tColor);
            layoutRectangle.Height = sizeF.Height + 1f;
            layoutRectangle = new RectangleF(layoutRectangle.X, layoutRectangle.Y - this.pScroll, layoutRectangle.Width, layoutRectangle.Height);
            this.myBX.Graphics.DrawString(this.pData.Sections[index1].Content[index2].Text, font, (Brush) solidBrush1, layoutRectangle, stringFormat);
            if (this.pData.Sections[index1].Content[index2].HasColumn)
            {
              if (this.pRightAlignColumn)
                stringFormat.Alignment = StringAlignment.Far;
              layoutRectangle.X = (float) this.pInternalPadding + (float) checked (this.Width - this.pInternalPadding * 2) * this.pColumnPosition;
              layoutRectangle.Width = (float) this.Width - ((float) this.pInternalPadding + layoutRectangle.X);
              SolidBrush solidBrush2 = new SolidBrush(this.pData.Sections[index1].Content[index2].tColorColumn);
              this.myBX.Graphics.DrawString(this.pData.Sections[index1].Content[index2].TextColumn, font, (Brush) solidBrush2, layoutRectangle, stringFormat);
              stringFormat.FormatFlags = StringFormatFlags.NoClip;
            }
            stringFormat.Alignment = StringAlignment.Near;
            num1 += sizeF.Height + 1f;
            checked { ++index2; }
          }
          num1 += (float) this.pSectionPadding;
        }
        checked { ++index1; }
      }
      this.Height = checked ((int) Math.Round((double) num1));
      this.lHeight = num1;
      this.pColumnPosition = pColumnPosition;
      this.pRightAlignColumn = rightAlignColumn;
    }

    private void DrawBorder()
    {
      this.myBX.Graphics.DrawRectangle(new Pen(this.ForeColor), new Rectangle()
      {
        X = 0,
        Y = 0,
        Height = checked (this.Height - 1),
        Width = checked (this.Width - 1)
      });
    }

    private void ctlPopUp_Paint(object sender, PaintEventArgs e)
    {
      if (this.myBX == null)
        return;
      e.Graphics.DrawImageUnscaled((Image) this.myBX.Bitmap, 0, 0);
    }

    private void ctlPopUp_SizeChanged(object sender, EventArgs e)
    {
      this.NewBX();
      this.Draw();
    }

    public ctlPopUp()
    {
      this.BackColorChanged += new EventHandler(this.ctlPopUp_BackColorChanged);
      this.FontChanged += new EventHandler(this.ctlPopUp_FontChanged);
      this.ForeColorChanged += new EventHandler(this.ctlPopUp_ForeColorChanged);
      this.Paint += new PaintEventHandler(this.ctlPopUp_Paint);
      this.Load += new EventHandler(this.ctlPopUp_Load);
      this.SizeChanged += new EventHandler(this.ctlPopUp_SizeChanged);
      this.pSectionPadding = 8;
      this.pInternalPadding = 3;
      this.pScroll = 0.0f;
      this.lHeight = 0.0f;
      this.pBXHeight = 600;
      this.pColumnPosition = 0.5f;
      this.pRightAlignColumn = false;
      this.hIDX = -1;
      this.pIDX = -1;
      this.eIDX = -1;
      this.psIDX = -1;
      this.InitializeComponent();
    }
  }
}
