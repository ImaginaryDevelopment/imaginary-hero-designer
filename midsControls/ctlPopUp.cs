﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Base.Display;
using Microsoft.VisualBasic.CompilerServices;

namespace midsControls
{
	// Token: 0x02000013 RID: 19
	[DesignerGenerated]
	public class ctlPopUp : UserControl
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000114 RID: 276 RVA: 0x0000A5A4 File Offset: 0x000087A4
		// (set) Token: 0x06000115 RID: 277 RVA: 0x0000A5BC File Offset: 0x000087BC
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

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000116 RID: 278 RVA: 0x0000A5D0 File Offset: 0x000087D0
		// (set) Token: 0x06000117 RID: 279 RVA: 0x0000A5E8 File Offset: 0x000087E8
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

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000A5FC File Offset: 0x000087FC
		// (set) Token: 0x06000119 RID: 281 RVA: 0x0000A614 File Offset: 0x00008814
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

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600011A RID: 282 RVA: 0x0000A628 File Offset: 0x00008828
		// (set) Token: 0x0600011B RID: 283 RVA: 0x0000A640 File Offset: 0x00008840
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

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600011C RID: 284 RVA: 0x0000A654 File Offset: 0x00008854
		// (set) Token: 0x0600011D RID: 285 RVA: 0x0000A66C File Offset: 0x0000886C
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0000A680 File Offset: 0x00008880
		// (set) Token: 0x0600011F RID: 287 RVA: 0x0000A698 File Offset: 0x00008898
		public float ScrollY
		{
			get
			{
				return this.pScroll;
			}
			set
			{
				if (this.pScroll != value)
				{
					this.pScroll = value;
					this.Draw();
				}
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000A6C4 File Offset: 0x000088C4
		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000A714 File Offset: 0x00008914
		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.Font = new Font("Arial", 14f, FontStyle.Regular, GraphicsUnit.Pixel, 0);
			base.Name = "ctlPopUp";
			Size size = new Size(167, 104);
			base.Size = size;
			base.ResumeLayout(false);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000A775 File Offset: 0x00008975
		private void ctlPopUp_BackColorChanged(object sender, EventArgs e)
		{
			this.NewBX();
			this.Draw();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000A786 File Offset: 0x00008986
		private void ctlPopUp_FontChanged(object sender, EventArgs e)
		{
			this.NewBX();
			this.Draw();
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000A797 File Offset: 0x00008997
		private void ctlPopUp_ForeColorChanged(object sender, EventArgs e)
		{
			this.NewBX();
			this.Draw();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000A7A8 File Offset: 0x000089A8
		private void ctlPopUp_Load(object sender, EventArgs e)
		{
			this.NewBX();
			this.pData = default(PopUp.PopupData);
			this.pData.Init();
			this.Draw();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000A7D4 File Offset: 0x000089D4
		private void NewBX()
		{
			if (this.pBXHeight < 300)
			{
				this.pBXHeight = 300;
			}
			this.myBX = new ExtendedBitmap(base.Size.Width, this.pBXHeight);
			this.myBX.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000A834 File Offset: 0x00008A34
		public void SetPopup(PopUp.PopupData iPopup)
		{
			this.pData = iPopup;
			this.Draw();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000A848 File Offset: 0x00008A48
		private void Draw()
		{
			if (this.myBX == null)
			{
				this.NewBX();
			}
			this.myBX.Graphics.Clear(this.BackColor);
			this.DrawBorder();
			this.DrawStrings();
			base.CreateGraphics().DrawImageUnscaled(this.myBX.Bitmap, 0, 0);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000A8B0 File Offset: 0x00008AB0
		private void DrawStrings()
		{
			float num = 0f;
			checked
			{
				if (this.pData.Sections != null)
				{
					StringFormat stringFormat = new StringFormat(StringFormatFlags.NoClip);
					float num2 = this.pColumnPosition;
					bool flag = this.pRightAlignColumn;
					if (this.pData.CustomSet)
					{
						this.pColumnPosition = this.pData.ColPos;
						this.pRightAlignColumn = this.pData.ColRight;
					}
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.Trimming = StringTrimming.None;
					int num3 = 0;
					int num4 = this.pData.Sections.Length - 1;
					for (int i = num3; i <= num4; i++)
					{
						if (this.pData.Sections[i].Content != null)
						{
							int num5 = 0;
							int num6 = this.pData.Sections[i].Content.Length - 1;
							for (int j = num5; j <= num6; j++)
							{
								unchecked
								{
									Font font = new Font(this.Font.FontFamily, this.Font.Size * this.pData.Sections[i].Content[j].tSize, this.pData.Sections[i].Content[j].tFormat, this.Font.Unit);
									RectangleF layoutRectangle = new RectangleF((float)this.pInternalPadding + (float)this.pData.Sections[i].Content[j].tIndent * this.Font.Size, num + (float)this.pInternalPadding, (float)base.Width - ((float)(checked(this.pInternalPadding * 2)) + (float)this.pData.Sections[i].Content[j].tIndent * this.Font.Size), (float)this.myBX.Size.Height);
									if (this.pData.Sections[i].Content[j].HasColumn)
									{
										stringFormat.FormatFlags |= StringFormatFlags.NoWrap;
									}
									SizeF sizeF;
									if (Operators.CompareString(this.pData.Sections[i].Content[j].Text, "", false) == 0)
									{
										sizeF = this.myBX.Graphics.MeasureString("Null String", font, layoutRectangle.Size, stringFormat);
									}
									else
									{
										sizeF = this.myBX.Graphics.MeasureString(this.pData.Sections[i].Content[j].Text, font, layoutRectangle.Size, stringFormat);
									}
									SolidBrush brush = new SolidBrush(this.pData.Sections[i].Content[j].tColor);
									layoutRectangle.Height = sizeF.Height + 1f;
									layoutRectangle = new RectangleF(layoutRectangle.X, layoutRectangle.Y - this.pScroll, layoutRectangle.Width, layoutRectangle.Height);
									this.myBX.Graphics.DrawString(this.pData.Sections[i].Content[j].Text, font, brush, layoutRectangle, stringFormat);
									if (this.pData.Sections[i].Content[j].HasColumn)
									{
										if (this.pRightAlignColumn)
										{
											stringFormat.Alignment = StringAlignment.Far;
										}
										layoutRectangle.X = (float)this.pInternalPadding + (float)(checked(base.Width - this.pInternalPadding * 2)) * this.pColumnPosition;
										layoutRectangle.Width = (float)base.Width - ((float)this.pInternalPadding + layoutRectangle.X);
										brush = new SolidBrush(this.pData.Sections[i].Content[j].tColorColumn);
										this.myBX.Graphics.DrawString(this.pData.Sections[i].Content[j].TextColumn, font, brush, layoutRectangle, stringFormat);
										stringFormat.FormatFlags = StringFormatFlags.NoClip;
									}
									stringFormat.Alignment = StringAlignment.Near;
									num += sizeF.Height + 1f;
								}
							}
							unchecked
							{
								num += (float)this.pSectionPadding;
							}
						}
					}
					base.Height = (int)Math.Round((double)num);
					this.lHeight = num;
					this.pColumnPosition = num2;
					this.pRightAlignColumn = flag;
				}
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000AD94 File Offset: 0x00008F94
		private void DrawBorder()
		{
			Pen pen = new Pen(this.ForeColor);
			Rectangle rect = default(Rectangle);
			rect.X = 0;
			rect.Y = 0;
			checked
			{
				rect.Height = base.Height - 1;
				rect.Width = base.Width - 1;
				this.myBX.Graphics.DrawRectangle(pen, rect);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000AE00 File Offset: 0x00009000
		private void ctlPopUp_Paint(object sender, PaintEventArgs e)
		{
			if (this.myBX != null)
			{
				e.Graphics.DrawImageUnscaled(this.myBX.Bitmap, 0, 0);
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000AE3A File Offset: 0x0000903A
		private void ctlPopUp_SizeChanged(object sender, EventArgs e)
		{
			this.NewBX();
			this.Draw();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000AE4C File Offset: 0x0000904C
		public ctlPopUp()
		{
			base.BackColorChanged += this.ctlPopUp_BackColorChanged;
			base.FontChanged += this.ctlPopUp_FontChanged;
			base.ForeColorChanged += this.ctlPopUp_ForeColorChanged;
			base.Paint += this.ctlPopUp_Paint;
			base.Load += this.ctlPopUp_Load;
			base.SizeChanged += this.ctlPopUp_SizeChanged;
			this.pSectionPadding = 8;
			this.pInternalPadding = 3;
			this.pScroll = 0f;
			this.lHeight = 0f;
			this.pBXHeight = 600;
			this.pColumnPosition = 0.5f;
			this.pRightAlignColumn = false;
			this.hIDX = -1;
			this.pIDX = -1;
			this.eIDX = -1;
			this.psIDX = -1;
			this.InitializeComponent();
		}

		// Token: 0x04000082 RID: 130
		private IContainer components;

		// Token: 0x04000083 RID: 131
		private ExtendedBitmap myBX;

		// Token: 0x04000084 RID: 132
		public PopUp.PopupData pData;

		// Token: 0x04000085 RID: 133
		private int pSectionPadding;

		// Token: 0x04000086 RID: 134
		private int pInternalPadding;

		// Token: 0x04000087 RID: 135
		private float pScroll;

		// Token: 0x04000088 RID: 136
		public float lHeight;

		// Token: 0x04000089 RID: 137
		private int pBXHeight;

		// Token: 0x0400008A RID: 138
		private float pColumnPosition;

		// Token: 0x0400008B RID: 139
		private bool pRightAlignColumn;

		// Token: 0x0400008C RID: 140
		public int hIDX;

		// Token: 0x0400008D RID: 141
		public int pIDX;

		// Token: 0x0400008E RID: 142
		public int eIDX;

		// Token: 0x0400008F RID: 143
		public int psIDX;
	}
}
