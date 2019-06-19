// Decompiled with JetBrains decompiler
// Type: Base.Display.PopUp
// Assembly: Base, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C585B90-7885-49F4-AC02-C3318CC8A42D
// Assembly location: C:\Users\Xbass\Desktop\Base.dll

using System;
using System.Drawing;

namespace Base.Display
{
  public static class PopUp
  {
    public static class Colors
    {
      public static Color Title = Color.FromArgb(216, 216, (int) byte.MaxValue);
      public static Color Text = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      public static Color Disabled = Color.FromArgb(192, 192, 192);
      public static Color Invention = Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue);
      public static Color Effect = Color.FromArgb(0, (int) byte.MaxValue, 128);
      public static Color Alert = Color.FromArgb((int) byte.MaxValue, 0, 0);
      public static Color UltraRare = Color.FromArgb(192, 96, 192);
      public static Color Rare = Color.FromArgb((int) byte.MaxValue, 128, 0);
      public static Color Uncommon = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0);
      public static Color Common = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }

    public struct StringValue
    {
      public string Text;
      public Color tColor;
      public float tSize;
      public FontStyle tFormat;
      public int tIndent;
      public string TextColumn;
      public Color tColorColumn;

      public bool HasColumn
      {
        get
        {
          return !string.IsNullOrEmpty(this.TextColumn);
        }
      }
    }

    public class Section
    {
      public PopUp.StringValue[] Content;

      public void Add(string iText, Color iColor, float iSize = 1f, FontStyle iFormat = FontStyle.Bold, int iIndent = 0)
      {
        if (this.Content == null)
          this.Content = new PopUp.StringValue[0];
        Array.Resize<PopUp.StringValue>(ref this.Content, this.Content.Length + 1);
        this.Content[this.Content.Length - 1].Text = iText;
        this.Content[this.Content.Length - 1].tColor = iColor;
        this.Content[this.Content.Length - 1].tSize = iSize;
        this.Content[this.Content.Length - 1].tFormat = iFormat;
        this.Content[this.Content.Length - 1].tIndent = iIndent;
        this.Content[this.Content.Length - 1].TextColumn = "";
        this.Content[this.Content.Length - 1].tColorColumn = iColor;
      }

      public void Add(
        string iText,
        Color iColor,
        string iColumnText,
        Color iColumnColor,
        float iSize = 1f,
        FontStyle iFormat = FontStyle.Bold,
        int iIndent = 0)
      {
        if (this.Content == null)
          this.Content = new PopUp.StringValue[0];
        Array.Resize<PopUp.StringValue>(ref this.Content, this.Content.Length + 1);
        this.Content[this.Content.Length - 1].Text = iText;
        this.Content[this.Content.Length - 1].tColor = iColor;
        this.Content[this.Content.Length - 1].tSize = iSize;
        this.Content[this.Content.Length - 1].tFormat = iFormat;
        this.Content[this.Content.Length - 1].tIndent = iIndent;
        this.Content[this.Content.Length - 1].TextColumn = iColumnText;
        this.Content[this.Content.Length - 1].tColorColumn = iColumnColor;
      }
    }

    public struct PopupData
    {
      public PopUp.Section[] Sections;
      private float _columnPosition;
      private bool _rightAlignColumn;

      public bool CustomSet { get; private set; }

      public float ColPos
      {
        get
        {
          return this._columnPosition;
        }
        set
        {
          this._columnPosition = value;
          this.CustomSet = true;
        }
      }

      public bool ColRight
      {
        get
        {
          return this._rightAlignColumn;
        }
        set
        {
          this._rightAlignColumn = value;
          this.CustomSet = true;
        }
      }

      public int Add(PopUp.Section section = null)
      {
        if (this.Sections == null)
          this.Sections = new PopUp.Section[0];
        if (section == null)
          section = new PopUp.Section()
          {
            Content = new PopUp.StringValue[0]
          };
        Array.Resize<PopUp.Section>(ref this.Sections, this.Sections.Length + 1);
        this.Sections[this.Sections.Length - 1] = section;
        return this.Sections.Length - 1;
      }

      public void Init()
      {
        int index1 = this.Add((PopUp.Section) null);
        this.Sections[index1].Add("Popup Information", PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
        this.Sections[index1].Add("This is just an example string. It should wrap around if it gets too long, and not cause too many issues.", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
        this.Sections[index1].Add("This is a second string added as an additional content structure within the section.", PopUp.Colors.Disabled, 1f, FontStyle.Bold, 0);
        int index2 = this.Add((PopUp.Section) null);
        this.Sections[index2].Add("Second Section", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
        this.Sections[index2].Add("Columns follow this item:", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
        this.Sections[index2].Add("Column 1", PopUp.Colors.Text, "Column 2", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
        this.Sections[index2].Add("Column 1a", PopUp.Colors.Text, "Column 2a", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
        this.Sections[index2].Add("Column 1b", PopUp.Colors.Text, "Column 2b", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
        this.Sections[index2].Add("Page from the Malleus mundi", PopUp.Colors.Text, "1", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
        this.Sections[index2].Add("Extra long column list item 1234567890", PopUp.Colors.Text, "1", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
      }
    }
  }
}
