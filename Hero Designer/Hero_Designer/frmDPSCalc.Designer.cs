namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmDPSCalc : global::System.Windows.Forms.Form
	{

		[global::System.Diagnostics.DebuggerNonUserCode]
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


		private void InitializeComponent()
		{
			this.GlobalPowerList = new global::Hero_Designer.frmDPSCalc.PowerList[0];
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmDPSCalc));
			this.lvPower = new global::System.Windows.Forms.ListView();
			this.lvPower.ColumnClick += new global::System.Windows.Forms.ColumnClickEventHandler(this.lvPower_ColumnClick);
			this.chPower = new global::System.Windows.Forms.ColumnHeader();
			this.chDPA = new global::System.Windows.Forms.ColumnHeader();
			this.chDamage = new global::System.Windows.Forms.ColumnHeader();
			this.chRecharge = new global::System.Windows.Forms.ColumnHeader();
			this.chAnimation = new global::System.Windows.Forms.ColumnHeader();
			this.chEndurance = new global::System.Windows.Forms.ColumnHeader();
			this.chDamageBuff = new global::System.Windows.Forms.ColumnHeader();
			this.chResistanceDebuff = new global::System.Windows.Forms.ColumnHeader();
			this.chBuildID = new global::System.Windows.Forms.ColumnHeader();
			this.ilAttackChain = new global::System.Windows.Forms.ImageList(this.components);
			this.chkSortByLevel = new global::System.Windows.Forms.CheckBox();
			this.chkDamageBuffs = new global::System.Windows.Forms.CheckBox();
			this.lblHeader = new global::System.Windows.Forms.Label();
			this.lblDPS = new global::System.Windows.Forms.Label();
			this.lblEPS = new global::System.Windows.Forms.Label();
			this.lblDPSNum = new global::System.Windows.Forms.Label();
			this.lblEPSNum = new global::System.Windows.Forms.Label();
			this.Panel1 = new global::System.Windows.Forms.Panel();
			this.tbDPSOutput = new global::System.Windows.Forms.TextBox();
			this.Panel2 = new global::System.Windows.Forms.Panel();
			this.ToolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.ibAutoMode = new global::midsControls.ImageButton();
			this.ibClear = new global::midsControls.ImageButton();
			this.ibTopmost = new global::midsControls.ImageButton();
			this.ibClose = new global::midsControls.ImageButton();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(0, 0);
			global::System.Drawing.Size size = new global::System.Drawing.Size(60, 30);
			this.lvPower.CheckBoxes = true;
			this.lvPower.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.chPower,
				this.chDPA,
				this.chDamage,
				this.chRecharge,
				this.chAnimation,
				this.chEndurance,
				this.chDamageBuff,
				this.chResistanceDebuff,
				this.chBuildID
			});
			this.lvPower.FullRowSelect = true;
			this.lvPower.HideSelection = false;
			point = new global::System.Drawing.Point(12, 12);
			this.lvPower.Location = point;
			this.lvPower.MultiSelect = false;
			this.lvPower.Name = "lvPower";
			size = new global::System.Drawing.Size(768, 250);
			this.lvPower.Size = size;
			this.lvPower.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.lvPower.TabIndex = 1;
			this.lvPower.UseCompatibleStateImageBehavior = false;
			this.lvPower.View = global::System.Windows.Forms.View.Details;
			this.chPower.Text = "Power";
			this.chPower.Width = 150;
			this.chDPA.Text = "DPA";
			this.chDPA.Width = 88;
			this.chDamage.Text = "Damage";
			this.chDamage.Width = 88;
			this.chRecharge.Text = "Recharge";
			this.chRecharge.Width = 88;
			this.chAnimation.Text = "Animation";
			this.chAnimation.Width = 88;
			this.chEndurance.Text = "Endurance";
			this.chEndurance.Width = 88;
			this.chDamageBuff.Text = "Dmg Buff";
			this.chDamageBuff.Width = 88;
			this.chDamageBuff.Tag = "Damage Buff";
			this.chResistanceDebuff.Text = "Res Debuff";
			this.chResistanceDebuff.Width = 88;
			this.chResistanceDebuff.Tag = "Resistance Debuff";
			this.chBuildID.Width = 0;
			this.chBuildID.Tag = "chBuildID";
			this.ilAttackChain.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
			size = new global::System.Drawing.Size(16, 16);
			this.ilAttackChain.ImageSize = size;
			this.ilAttackChain.TransparentColor = global::System.Drawing.Color.Transparent;
			this.chkSortByLevel.Checked = true;
			this.chkSortByLevel.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkSortByLevel.ForeColor = global::System.Drawing.Color.White;
			point = new global::System.Drawing.Point(12, 263);
			this.chkSortByLevel.Location = point;
			this.chkSortByLevel.Name = "chkSortByLevel";
			size = new global::System.Drawing.Size(176, 16);
			this.chkSortByLevel.Size = size;
			this.chkSortByLevel.TabIndex = 9;
			this.chkSortByLevel.Text = "Sort By Level";
			this.chkSortByLevel.UseVisualStyleBackColor = true;
			this.chkDamageBuffs.Checked = true;
			this.chkDamageBuffs.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.chkDamageBuffs.ForeColor = global::System.Drawing.Color.White;
			point = new global::System.Drawing.Point(250, 450);
			this.chkDamageBuffs.Location = point;
			this.chkDamageBuffs.Name = "chkDamageBuffs";
			size = new global::System.Drawing.Size(150, 16);
			this.chkDamageBuffs.Size = size;
			this.chkDamageBuffs.TabIndex = 9;
			this.chkDamageBuffs.Text = "Add Damage Buffs?";
			this.chkDamageBuffs.UseVisualStyleBackColor = true;
			this.lblHeader.Font = new global::System.Drawing.Font("Arial", 17.5f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.lblHeader.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			point = new global::System.Drawing.Point(0, 0);
			this.lblHeader.Location = point;
			this.lblHeader.Name = "lblHeader";
			size = new global::System.Drawing.Size(700, 30);
			this.lblHeader.Size = size;
			this.lblHeader.TabIndex = 10;
			this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
			this.lblHeader.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.Panel1.Controls.Add(this.tbDPSOutput);
			this.Panel1.Controls.Add(this.lblDPS);
			this.Panel1.Controls.Add(this.lblEPS);
			this.Panel1.Controls.Add(this.lblDPSNum);
			this.Panel1.Controls.Add(this.lblEPSNum);
			this.Panel1.Controls.Add(this.lblHeader);
			point = new global::System.Drawing.Point(0, 36);
			this.Panel1.Location = point;
			this.Panel1.Name = "Panel1";
			size = new global::System.Drawing.Size(790, 177);
			this.Panel1.Size = size;
			this.Panel1.TabIndex = 11;
			point = new global::System.Drawing.Point(0, 36);
			this.tbDPSOutput.Location = point;
			this.tbDPSOutput.BackColor = global::System.Drawing.Color.Black;
			this.tbDPSOutput.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			this.tbDPSOutput.Height = 200;
			this.tbDPSOutput.Width = 600;
			this.tbDPSOutput.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(650, 10);
			this.lblDPS.Location = point;
			size = new global::System.Drawing.Size(200, 30);
			this.lblDPS.MinimumSize = size;
			this.lblDPS.BackColor = global::System.Drawing.Color.Black;
			this.lblDPS.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblDPS.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.lblDPS.Text = "Estimated DPS: ";
			point = new global::System.Drawing.Point(660, 40);
			this.lblDPSNum.Location = point;
			size = new global::System.Drawing.Size(200, 30);
			this.lblDPSNum.MinimumSize = size;
			this.lblDPSNum.BackColor = global::System.Drawing.Color.Black;
			this.lblDPSNum.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblDPSNum.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.lblDPSNum.Text = "-Null-";
			point = new global::System.Drawing.Point(650, 75);
			this.lblEPS.Location = point;
			size = new global::System.Drawing.Size(200, 30);
			this.lblEPS.MinimumSize = size;
			this.lblEPS.BackColor = global::System.Drawing.Color.Black;
			this.lblEPS.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblEPS.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.lblEPS.Text = "Estimated EPS: ";
			point = new global::System.Drawing.Point(660, 105);
			this.lblEPSNum.Location = point;
			size = new global::System.Drawing.Size(200, 30);
			this.lblEPSNum.MinimumSize = size;
			this.lblEPSNum.BackColor = global::System.Drawing.Color.Black;
			this.lblEPSNum.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
			this.lblEPSNum.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			this.lblEPSNum.Text = "-Null-";
			size = new global::System.Drawing.Size(786, 176);
			this.Panel2.BackColor = global::System.Drawing.Color.Black;
			this.Panel2.Controls.Add(this.Panel1);
			point = new global::System.Drawing.Point(12, 260);
			this.Panel2.Location = point;
			this.Panel2.Name = "Panel2";
			size = new global::System.Drawing.Size(790, 213);
			this.Panel2.Size = size;
			this.Panel2.TabIndex = 12;
			point = new global::System.Drawing.Point(234, 445);
			size = new global::System.Drawing.Size(166, 22);
			this.ToolTip1.SetToolTip(this.ibAutoMode, "Click to enable Automagical Mode");
			this.ibAutoMode.Checked = false;
			this.ibAutoMode.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.ibAutoMode.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(123, 445);
			this.ibAutoMode.Location = point;
			this.ibAutoMode.Name = "ibAutoMode";
			size = new global::System.Drawing.Size(105, 22);
			this.ibAutoMode.Size = size;
			this.ibAutoMode.TabIndex = 14;
			this.ibAutoMode.TextOff = "Manual";
			this.ibAutoMode.TextOn = "Alt Text";
			this.ibAutoMode.Toggle = false;
			this.ibClear.Checked = false;
			this.ibClear.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.ibClear.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(12, 445);
			this.ibClear.Location = point;
			this.ibClear.Name = "ibClear";
			size = new global::System.Drawing.Size(105, 22);
			this.ibClear.Size = size;
			this.ibClear.TabIndex = 13;
			this.ibClear.TextOff = "Clear";
			this.ibClear.TextOn = "Alt Text";
			this.ibClear.Toggle = false;
			this.ibTopmost.Checked = true;
			this.ibTopmost.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.ibTopmost.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(406, 445);
			this.ibTopmost.Location = point;
			this.ibTopmost.Name = "ibTopmost";
			size = new global::System.Drawing.Size(105, 22);
			this.ibTopmost.Size = size;
			this.ibTopmost.TabIndex = 7;
			this.ibTopmost.TextOff = "Keep On Top";
			this.ibTopmost.TextOn = "Keep On Top";
			this.ibTopmost.Toggle = true;
			this.ibClose.Checked = false;
			this.ibClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
			point = new global::System.Drawing.Point(0, 0);
			this.ibClose.KnockoutLocationPoint = point;
			point = new global::System.Drawing.Point(517, 445);
			this.ibClose.Location = point;
			this.ibClose.Name = "ibClose";
			size = new global::System.Drawing.Size(105, 22);
			this.ibClose.Size = size;
			this.ibClose.TabIndex = 6;
			this.ibClose.TextOff = "Close";
			this.ibClose.TextOn = "Alt Text";
			this.ibClose.Toggle = false;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
			size = new global::System.Drawing.Size(634, 479);
			base.ClientSize = size;
			base.Controls.Add(this.ibAutoMode);
			base.Controls.Add(this.ibClear);
			base.Controls.Add(this.chkSortByLevel);
			base.Controls.Add(this.chkDamageBuffs);
			base.Controls.Add(this.ibTopmost);
			base.Controls.Add(this.ibClose);
			base.Controls.Add(this.lvPower);
			base.Controls.Add(this.Panel2);
			this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmDPSCalc";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Damage Per Second Calculator (Beta)";
			base.TopMost = true;
			this.Panel1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}


		private global::System.ComponentModel.IContainer components;


		private global::Hero_Designer.frmDPSCalc.PowerList[] GlobalPowerList;
	}
}
