namespace Hero_Designer
{
	// Token: 0x02000059 RID: 89
	public partial class frmStats : global::System.Windows.Forms.Form
	{
		// Token: 0x060012FC RID: 4860 RVA: 0x000BCF18 File Offset: 0x000BB118
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x000BFFBC File Offset: 0x000BE1BC
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmStats));
			this.lblKey2 = new global::System.Windows.Forms.Label();
			this.lblKey1 = new global::System.Windows.Forms.Label();
			this.lblKeyColor2 = new global::System.Windows.Forms.Label();
			this.lblKeyColor1 = new global::System.Windows.Forms.Label();
			this.tbScaleX = new global::System.Windows.Forms.TrackBar();
			this.lblScale = new global::System.Windows.Forms.Label();
			this.tTip = new global::System.Windows.Forms.ToolTip(this.components);
			this.cbSet = new global::System.Windows.Forms.ComboBox();
			this.cbValues = new global::System.Windows.Forms.ComboBox();
			this.cbStyle = new global::System.Windows.Forms.ComboBox();
			this.Graph = new global::midsControls.ctlMultiGraph();
			this.chkOnTop = new global::midsControls.ImageButton();
			this.btnClose = new global::midsControls.ImageButton();
			this.tbScaleX.BeginInit();
			base.SuspendLayout();
			this.lblKey2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			global::System.Drawing.Point point = new global::System.Drawing.Point(56, 463);
			this.lblKey2.Location = point;
			this.lblKey2.Name = "lblKey2";
			global::System.Drawing.Size size = new global::System.Drawing.Size(78, 16);
			this.lblKey2.Size = size;
			this.lblKey2.TabIndex = 3;
			this.lblKey2.Text = "Enhanced";
			this.lblKey2.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lblKey1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			point = new global::System.Drawing.Point(56, 443);
			this.lblKey1.Location = point;
			this.lblKey1.Name = "lblKey1";
			size = new global::System.Drawing.Size(78, 16);
			this.lblKey1.Size = size;
			this.lblKey1.TabIndex = 2;
			this.lblKey1.Text = "Base";
			this.lblKey1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.lblKeyColor2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.lblKeyColor2.BackColor = global::System.Drawing.Color.Yellow;
			this.lblKeyColor2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			point = new global::System.Drawing.Point(12, 463);
			this.lblKeyColor2.Location = point;
			this.lblKeyColor2.Name = "lblKeyColor2";
			size = new global::System.Drawing.Size(40, 16);
			this.lblKeyColor2.Size = size;
			this.lblKeyColor2.TabIndex = 1;
			this.lblKeyColor1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.lblKeyColor1.BackColor = global::System.Drawing.Color.Blue;
			this.lblKeyColor1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			point = new global::System.Drawing.Point(12, 443);
			this.lblKeyColor1.Location = point;
			this.lblKeyColor1.Name = "lblKeyColor1";
			size = new global::System.Drawing.Size(40, 16);
			this.lblKeyColor1.Size = size;
			this.lblKeyColor1.TabIndex = 0;
			this.tbScaleX.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.tbScaleX.LargeChange = 1;
			point = new global::System.Drawing.Point(140, 438);
			this.tbScaleX.Location = point;
			this.tbScaleX.Minimum = 1;
			this.tbScaleX.Name = "tbScaleX";
			size = new global::System.Drawing.Size(237, 45);
			this.tbScaleX.Size = size;
			this.tbScaleX.TabIndex = 6;
			this.tbScaleX.TickFrequency = 10;
			this.tbScaleX.TickStyle = global::System.Windows.Forms.TickStyle.None;
			this.tTip.SetToolTip(this.tbScaleX, "Move the slider to the left to zoom in on lower values.");
			this.tbScaleX.Value = 10;
			this.lblScale.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			point = new global::System.Drawing.Point(212, 462);
			this.lblScale.Location = point;
			this.lblScale.Name = "lblScale";
			size = new global::System.Drawing.Size(108, 20);
			this.lblScale.Size = size;
			this.lblScale.TabIndex = 7;
			this.lblScale.Text = "Scale: 100%";
			this.lblScale.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.tTip.AutoPopDelay = 10000;
			this.tTip.InitialDelay = 500;
			this.tTip.ReshowDelay = 100;
			this.cbSet.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSet.FormattingEnabled = true;
			point = new global::System.Drawing.Point(6, 5);
			this.cbSet.Location = point;
			this.cbSet.MaxDropDownItems = 16;
			this.cbSet.Name = "cbSet";
			size = new global::System.Drawing.Size(158, 21);
			this.cbSet.Size = size;
			this.cbSet.TabIndex = 10;
			this.cbValues.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbValues.FormattingEnabled = true;
			point = new global::System.Drawing.Point(170, 5);
			this.cbValues.Location = point;
			this.cbValues.MaxDropDownItems = 16;
			this.cbValues.Name = "cbValues";
			size = new global::System.Drawing.Size(101, 21);
			this.cbValues.Size = size;
			this.cbValues.TabIndex = 11;
			this.cbStyle.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStyle.FormattingEnabled = true;
			point = new global::System.Drawing.Point(277, 5);
			this.cbStyle.Location = point;
			this.cbStyle.Name = "cbStyle";
			size = new global::System.Drawing.Size(154, 21);
			this.cbStyle.Size = size;
			this.cbStyle.TabIndex = 12;
			this.Graph.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
			this.Graph.Border = true;
			this.Graph.ColorBase = global::System.Drawing.Color.Blue;
			this.Graph.ColorEnh = global::System.Drawing.Color.Yellow;
			this.Graph.ColorFadeEnd = global::System.Drawing.Color.Red;
			this.Graph.ColorFadeStart = global::System.Drawing.Color.Black;
			this.Graph.ColorHighlight = global::System.Drawing.Color.White;
			this.Graph.ColorLines = global::System.Drawing.Color.Black;
			this.Graph.ColorMarkerInner = global::System.Drawing.Color.Black;
			this.Graph.ColorMarkerOuter = global::System.Drawing.Color.Yellow;
			this.Graph.Dual = false;
			this.Graph.Font = new global::System.Drawing.Font("Arial", 7.5f);
			this.Graph.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			this.Graph.Highlight = true;
			this.Graph.ImeMode = global::System.Windows.Forms.ImeMode.Off;
			this.Graph.ItemHeight = 12;
			this.Graph.Lines = true;
			point = new global::System.Drawing.Point(4, 28);
			this.Graph.Location = point;
			this.Graph.MarkerValue = 0f;
			this.Graph.Max = 75f;
			this.Graph.Name = "Graph";
			this.Graph.PaddingX = 2f;
			this.Graph.PaddingY = 4f;
			this.Graph.ScaleHeight = 16;
			this.Graph.ScaleIndex = 7;
			this.Graph.ShowScale = true;
			size = new global::System.Drawing.Size(484, 405);
			this.Graph.Size = size;
			this.Graph.Style = global::Enums.GraphStyle.Stacked;
			this.Graph.TabIndex = 0;
			this.Graph.TextWidth = 100;
			this.chkOnTop.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.chkOnTop.Checked = true;
			this.chkOnTop.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(383, 438);
			this.chkOnTop.Location = point;
			this.chkOnTop.Name = "chkOnTop";
			size = new global::System.Drawing.Size(105, 22);
			this.chkOnTop.Size = size;
			this.chkOnTop.TabIndex = 17;
			this.chkOnTop.TextOff = "Keep On Top";
			this.chkOnTop.TextOn = "Keep On Top";
			this.chkOnTop.Toggle = true;
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.Checked = false;
			this.btnClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(383, 465);
			this.btnClose.Location = point;
			global::System.Windows.Forms.Padding margin = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnClose.Margin = margin;
			this.btnClose.Name = "btnClose";
			size = new global::System.Drawing.Size(105, 22);
			this.btnClose.Size = size;
			this.btnClose.TabIndex = 16;
			this.btnClose.TextOff = "Close";
			this.btnClose.TextOn = "Close";
			this.btnClose.Toggle = false;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
			size = new global::System.Drawing.Size(492, 491);
			base.ClientSize = size;
			base.Controls.Add(this.chkOnTop);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.cbStyle);
			base.Controls.Add(this.lblKey2);
			base.Controls.Add(this.cbValues);
			base.Controls.Add(this.lblKey1);
			base.Controls.Add(this.cbSet);
			base.Controls.Add(this.lblKeyColor2);
			base.Controls.Add(this.lblKeyColor1);
			base.Controls.Add(this.lblScale);
			base.Controls.Add(this.tbScaleX);
			base.Controls.Add(this.Graph);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			size = new global::System.Drawing.Size(400, 340);
			this.MinimumSize = size;
			base.Name = "frmStats";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Power Stats";
			base.TopMost = true;
			this.tbScaleX.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400079F RID: 1951
		private global::System.ComponentModel.IContainer components;
	}
}
