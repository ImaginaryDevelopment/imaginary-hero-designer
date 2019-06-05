using System;
using System.Drawing;

namespace Base.Display
{
	// Token: 0x0200000F RID: 15
	public static class PopUp
	{
		// Token: 0x02000010 RID: 16
		public static class Colors
		{
			// Token: 0x0400012A RID: 298
			public static Color Title = Color.FromArgb(216, 216, 255);

			// Token: 0x0400012B RID: 299
			public static Color Text = Color.FromArgb(255, 255, 255);

			// Token: 0x0400012C RID: 300
			public static Color Disabled = Color.FromArgb(192, 192, 192);

			// Token: 0x0400012D RID: 301
			public static Color Invention = Color.FromArgb(0, 255, 255);

			// Token: 0x0400012E RID: 302
			public static Color Effect = Color.FromArgb(0, 255, 128);

			// Token: 0x0400012F RID: 303
			public static Color Alert = Color.FromArgb(255, 0, 0);

			// Token: 0x04000130 RID: 304
			public static Color UltraRare = Color.FromArgb(192, 96, 192);

			// Token: 0x04000131 RID: 305
			public static Color Rare = Color.FromArgb(255, 128, 0);

			// Token: 0x04000132 RID: 306
			public static Color Uncommon = Color.FromArgb(255, 255, 0);

			// Token: 0x04000133 RID: 307
			public static Color Common = Color.FromArgb(255, 255, 255);
		}

		// Token: 0x02000011 RID: 17
		public struct StringValue
		{
			// Token: 0x170001FA RID: 506
			// (get) Token: 0x06000474 RID: 1140 RVA: 0x00014294 File Offset: 0x00012494
			public bool HasColumn
			{
				get
				{
					return !string.IsNullOrEmpty(this.TextColumn);
				}
			}

			// Token: 0x04000134 RID: 308
			public string Text;

			// Token: 0x04000135 RID: 309
			public Color tColor;

			// Token: 0x04000136 RID: 310
			public float tSize;

			// Token: 0x04000137 RID: 311
			public FontStyle tFormat;

			// Token: 0x04000138 RID: 312
			public int tIndent;

			// Token: 0x04000139 RID: 313
			public string TextColumn;

			// Token: 0x0400013A RID: 314
			public Color tColorColumn;
		}

		// Token: 0x02000012 RID: 18
		public class Section
		{
			// Token: 0x06000475 RID: 1141 RVA: 0x000142B4 File Offset: 0x000124B4
			public void Add(string iText, Color iColor, float iSize = 1f, FontStyle iFormat = FontStyle.Bold, int iIndent = 0)
			{
				if (this.Content == null)
				{
					this.Content = new PopUp.StringValue[0];
				}
				Array.Resize<PopUp.StringValue>(ref this.Content, this.Content.Length + 1);
				this.Content[this.Content.Length - 1].Text = iText;
				this.Content[this.Content.Length - 1].tColor = iColor;
				this.Content[this.Content.Length - 1].tSize = iSize;
				this.Content[this.Content.Length - 1].tFormat = iFormat;
				this.Content[this.Content.Length - 1].tIndent = iIndent;
				this.Content[this.Content.Length - 1].TextColumn = "";
				this.Content[this.Content.Length - 1].tColorColumn = iColor;
			}

			// Token: 0x06000476 RID: 1142 RVA: 0x000143BC File Offset: 0x000125BC
			public void Add(string iText, Color iColor, string iColumnText, Color iColumnColor, float iSize = 1f, FontStyle iFormat = FontStyle.Bold, int iIndent = 0)
			{
				if (this.Content == null)
				{
					this.Content = new PopUp.StringValue[0];
				}
				Array.Resize<PopUp.StringValue>(ref this.Content, this.Content.Length + 1);
				this.Content[this.Content.Length - 1].Text = iText;
				this.Content[this.Content.Length - 1].tColor = iColor;
				this.Content[this.Content.Length - 1].tSize = iSize;
				this.Content[this.Content.Length - 1].tFormat = iFormat;
				this.Content[this.Content.Length - 1].tIndent = iIndent;
				this.Content[this.Content.Length - 1].TextColumn = iColumnText;
				this.Content[this.Content.Length - 1].tColorColumn = iColumnColor;
			}

			// Token: 0x0400013B RID: 315
			public PopUp.StringValue[] Content;
		}

		// Token: 0x02000013 RID: 19
		public struct PopupData
		{
			// Token: 0x170001FB RID: 507
			// (get) Token: 0x06000478 RID: 1144 RVA: 0x000144C8 File Offset: 0x000126C8
			// (set) Token: 0x06000479 RID: 1145 RVA: 0x000144DF File Offset: 0x000126DF
			public bool CustomSet { get; private set; }

			// Token: 0x170001FC RID: 508
			// (get) Token: 0x0600047A RID: 1146 RVA: 0x000144E8 File Offset: 0x000126E8
			// (set) Token: 0x0600047B RID: 1147 RVA: 0x00014500 File Offset: 0x00012700
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

			// Token: 0x170001FD RID: 509
			// (get) Token: 0x0600047C RID: 1148 RVA: 0x00014514 File Offset: 0x00012714
			// (set) Token: 0x0600047D RID: 1149 RVA: 0x0001452C File Offset: 0x0001272C
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

			// Token: 0x0600047E RID: 1150 RVA: 0x00014540 File Offset: 0x00012740
			public int Add(PopUp.Section section = null)
			{
				if (this.Sections == null)
				{
					this.Sections = new PopUp.Section[0];
				}
				if (section == null)
				{
					section = new PopUp.Section
					{
						Content = new PopUp.StringValue[0]
					};
				}
				Array.Resize<PopUp.Section>(ref this.Sections, this.Sections.Length + 1);
				this.Sections[this.Sections.Length - 1] = section;
				return this.Sections.Length - 1;
			}

			// Token: 0x0600047F RID: 1151 RVA: 0x000145C4 File Offset: 0x000127C4
			public void Init()
			{
				int index2 = this.Add(null);
				this.Sections[index2].Add("Popup Information", PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
				this.Sections[index2].Add("This is just an example string. It should wrap around if it gets too long, and not cause too many issues.", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
				this.Sections[index2].Add("This is a second string added as an additional content structure within the section.", PopUp.Colors.Disabled, 1f, FontStyle.Bold, 0);
				index2 = this.Add(null);
				this.Sections[index2].Add("Second Section", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
				this.Sections[index2].Add("Columns follow this item:", PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
				this.Sections[index2].Add("Column 1", PopUp.Colors.Text, "Column 2", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
				this.Sections[index2].Add("Column 1a", PopUp.Colors.Text, "Column 2a", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
				this.Sections[index2].Add("Column 1b", PopUp.Colors.Text, "Column 2b", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
				this.Sections[index2].Add("Page from the Malleus mundi", PopUp.Colors.Text, "1", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
				this.Sections[index2].Add("Extra long column list item 1234567890", PopUp.Colors.Text, "1", PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
			}

			// Token: 0x0400013C RID: 316
			public PopUp.Section[] Sections;

			// Token: 0x0400013D RID: 317
			private float _columnPosition;

			// Token: 0x0400013E RID: 318
			private bool _rightAlignColumn;
		}
	}
}
