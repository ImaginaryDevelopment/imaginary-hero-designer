namespace Hero_Designer
{

	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmEntityEdit : global::System.Windows.Forms.Form
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


		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmEntityEdit));
			this.txtEntName = new global::System.Windows.Forms.TextBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.txtDisplayName = new global::System.Windows.Forms.TextBox();
			this.cbEntType = new global::System.Windows.Forms.ComboBox();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btnPDelete = new global::System.Windows.Forms.Button();
			this.lvPower = new global::System.Windows.Forms.ListView();
			this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.btnPAdd = new global::System.Windows.Forms.Button();
			this.lvPSSet = new global::System.Windows.Forms.ListView();
			this.ColumnHeader10 = new global::System.Windows.Forms.ColumnHeader();
			this.btnPDown = new global::System.Windows.Forms.Button();
			this.lvPSGroup = new global::System.Windows.Forms.ListView();
			this.ColumnHeader11 = new global::System.Windows.Forms.ColumnHeader();
			this.btnPUp = new global::System.Windows.Forms.Button();
			this.GroupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btnUGDelete = new global::System.Windows.Forms.Button();
			this.btnUGAdd = new global::System.Windows.Forms.Button();
			this.btnUGDown = new global::System.Windows.Forms.Button();
			this.btnUGUp = new global::System.Windows.Forms.Button();
			this.lvUpgrade = new global::System.Windows.Forms.ListView();
			this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
			this.lvUGPower = new global::System.Windows.Forms.ListView();
			this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.lvUGSet = new global::System.Windows.Forms.ListView();
			this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.lvUGGroup = new global::System.Windows.Forms.ListView();
			this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.Label4 = new global::System.Windows.Forms.Label();
			this.Label5 = new global::System.Windows.Forms.Label();
			this.cbClass = new global::System.Windows.Forms.ComboBox();
			this.btnOK = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			base.SuspendLayout();
			global::System.Drawing.Point point = new global::System.Drawing.Point(101, 9);
			this.txtEntName.Location = point;
			this.txtEntName.Name = "txtEntName";
			global::System.Drawing.Size size = new global::System.Drawing.Size(172, 20);
			this.txtEntName.Size = size;
			this.txtEntName.TabIndex = 0;
			point = new global::System.Drawing.Point(12, 9);
			this.Label1.Location = point;
			this.Label1.Name = "Label1";
			size = new global::System.Drawing.Size(83, 20);
			this.Label1.Size = size;
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Name:";
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			point = new global::System.Drawing.Point(12, 35);
			this.Label2.Location = point;
			this.Label2.Name = "Label2";
			size = new global::System.Drawing.Size(83, 20);
			this.Label2.Size = size;
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Display Name:";
			this.Label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			point = new global::System.Drawing.Point(101, 35);
			this.txtDisplayName.Location = point;
			this.txtDisplayName.Name = "txtDisplayName";
			size = new global::System.Drawing.Size(172, 20);
			this.txtDisplayName.Size = size;
			this.txtDisplayName.TabIndex = 2;
			this.cbEntType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntType.FormattingEnabled = true;
			point = new global::System.Drawing.Point(101, 61);
			this.cbEntType.Location = point;
			this.cbEntType.Name = "cbEntType";
			size = new global::System.Drawing.Size(172, 22);
			this.cbEntType.Size = size;
			this.cbEntType.TabIndex = 4;
			point = new global::System.Drawing.Point(12, 61);
			this.Label3.Location = point;
			this.Label3.Name = "Label3";
			size = new global::System.Drawing.Size(83, 20);
			this.Label3.Size = size;
			this.Label3.TabIndex = 5;
			this.Label3.Text = "Entity Type:";
			this.Label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.GroupBox1.Controls.Add(this.btnPDelete);
			this.GroupBox1.Controls.Add(this.lvPower);
			this.GroupBox1.Controls.Add(this.btnPAdd);
			this.GroupBox1.Controls.Add(this.lvPSSet);
			this.GroupBox1.Controls.Add(this.btnPDown);
			this.GroupBox1.Controls.Add(this.lvPSGroup);
			this.GroupBox1.Controls.Add(this.btnPUp);
			point = new global::System.Drawing.Point(12, 117);
			this.GroupBox1.Location = point;
			this.GroupBox1.Name = "GroupBox1";
			size = new global::System.Drawing.Size(373, 375);
			this.GroupBox1.Size = size;
			this.GroupBox1.TabIndex = 6;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Power Sets";
			point = new global::System.Drawing.Point(283, 134);
			this.btnPDelete.Location = point;
			this.btnPDelete.Name = "btnPDelete";
			size = new global::System.Drawing.Size(84, 23);
			this.btnPDelete.Size = size;
			this.btnPDelete.TabIndex = 11;
			this.btnPDelete.Text = "Remove";
			this.btnPDelete.UseVisualStyleBackColor = true;
			this.lvPower.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader4
			});
			this.lvPower.FullRowSelect = true;
			this.lvPower.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvPower.HideSelection = false;
			point = new global::System.Drawing.Point(6, 19);
			this.lvPower.Location = point;
			this.lvPower.MultiSelect = false;
			this.lvPower.Name = "lvPower";
			size = new global::System.Drawing.Size(271, 138);
			this.lvPower.Size = size;
			this.lvPower.TabIndex = 18;
			this.lvPower.UseCompatibleStateImageBehavior = false;
			this.lvPower.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader4.Text = "Current Sets";
			this.ColumnHeader4.Width = 244;
			point = new global::System.Drawing.Point(283, 105);
			this.btnPAdd.Location = point;
			this.btnPAdd.Name = "btnPAdd";
			size = new global::System.Drawing.Size(84, 23);
			this.btnPAdd.Size = size;
			this.btnPAdd.TabIndex = 10;
			this.btnPAdd.Text = "Add";
			this.btnPAdd.UseVisualStyleBackColor = true;
			this.lvPSSet.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader10
			});
			this.lvPSSet.FullRowSelect = true;
			this.lvPSSet.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvPSSet.HideSelection = false;
			point = new global::System.Drawing.Point(148, 163);
			this.lvPSSet.Location = point;
			this.lvPSSet.MultiSelect = false;
			this.lvPSSet.Name = "lvPSSet";
			size = new global::System.Drawing.Size(219, 206);
			this.lvPSSet.Size = size;
			this.lvPSSet.TabIndex = 17;
			this.lvPSSet.UseCompatibleStateImageBehavior = false;
			this.lvPSSet.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader10.Text = "Set";
			this.ColumnHeader10.Width = 188;
			point = new global::System.Drawing.Point(283, 48);
			this.btnPDown.Location = point;
			this.btnPDown.Name = "btnPDown";
			size = new global::System.Drawing.Size(84, 23);
			this.btnPDown.Size = size;
			this.btnPDown.TabIndex = 9;
			this.btnPDown.Text = "Down";
			this.btnPDown.UseVisualStyleBackColor = true;
			this.lvPSGroup.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader11
			});
			this.lvPSGroup.FullRowSelect = true;
			this.lvPSGroup.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvPSGroup.HideSelection = false;
			point = new global::System.Drawing.Point(6, 163);
			this.lvPSGroup.Location = point;
			this.lvPSGroup.MultiSelect = false;
			this.lvPSGroup.Name = "lvPSGroup";
			size = new global::System.Drawing.Size(136, 206);
			this.lvPSGroup.Size = size;
			this.lvPSGroup.TabIndex = 16;
			this.lvPSGroup.UseCompatibleStateImageBehavior = false;
			this.lvPSGroup.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader11.Text = "Group";
			this.ColumnHeader11.Width = 110;
			point = new global::System.Drawing.Point(283, 19);
			this.btnPUp.Location = point;
			this.btnPUp.Name = "btnPUp";
			size = new global::System.Drawing.Size(84, 23);
			this.btnPUp.Size = size;
			this.btnPUp.TabIndex = 8;
			this.btnPUp.Text = "Up";
			this.btnPUp.UseVisualStyleBackColor = true;
			this.GroupBox2.Controls.Add(this.btnUGDelete);
			this.GroupBox2.Controls.Add(this.btnUGAdd);
			this.GroupBox2.Controls.Add(this.btnUGDown);
			this.GroupBox2.Controls.Add(this.btnUGUp);
			this.GroupBox2.Controls.Add(this.lvUpgrade);
			this.GroupBox2.Controls.Add(this.lvUGPower);
			this.GroupBox2.Controls.Add(this.lvUGSet);
			this.GroupBox2.Controls.Add(this.lvUGGroup);
			point = new global::System.Drawing.Point(391, 117);
			this.GroupBox2.Location = point;
			this.GroupBox2.Name = "GroupBox2";
			size = new global::System.Drawing.Size(514, 375);
			this.GroupBox2.Size = size;
			this.GroupBox2.TabIndex = 7;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Upgrade Powers";
			point = new global::System.Drawing.Point(424, 108);
			this.btnUGDelete.Location = point;
			this.btnUGDelete.Name = "btnUGDelete";
			size = new global::System.Drawing.Size(84, 23);
			this.btnUGDelete.Size = size;
			this.btnUGDelete.TabIndex = 23;
			this.btnUGDelete.Text = "Remove";
			this.btnUGDelete.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(424, 79);
			this.btnUGAdd.Location = point;
			this.btnUGAdd.Name = "btnUGAdd";
			size = new global::System.Drawing.Size(84, 23);
			this.btnUGAdd.Size = size;
			this.btnUGAdd.TabIndex = 22;
			this.btnUGAdd.Text = "Add";
			this.btnUGAdd.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(424, 48);
			this.btnUGDown.Location = point;
			this.btnUGDown.Name = "btnUGDown";
			size = new global::System.Drawing.Size(84, 23);
			this.btnUGDown.Size = size;
			this.btnUGDown.TabIndex = 21;
			this.btnUGDown.Text = "Down";
			this.btnUGDown.UseVisualStyleBackColor = true;
			point = new global::System.Drawing.Point(424, 19);
			this.btnUGUp.Location = point;
			this.btnUGUp.Name = "btnUGUp";
			size = new global::System.Drawing.Size(84, 23);
			this.btnUGUp.Size = size;
			this.btnUGUp.TabIndex = 20;
			this.btnUGUp.Text = "Up";
			this.btnUGUp.UseVisualStyleBackColor = true;
			this.lvUpgrade.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader5
			});
			this.lvUpgrade.FullRowSelect = true;
			this.lvUpgrade.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvUpgrade.HideSelection = false;
			point = new global::System.Drawing.Point(6, 19);
			this.lvUpgrade.Location = point;
			this.lvUpgrade.MultiSelect = false;
			this.lvUpgrade.Name = "lvUpgrade";
			size = new global::System.Drawing.Size(412, 112);
			this.lvUpgrade.Size = size;
			this.lvUpgrade.TabIndex = 19;
			this.lvUpgrade.UseCompatibleStateImageBehavior = false;
			this.lvUpgrade.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader5.Text = "Upgrades";
			this.ColumnHeader5.Width = 382;
			this.lvUGPower.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader3
			});
			this.lvUGPower.FullRowSelect = true;
			this.lvUGPower.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvUGPower.HideSelection = false;
			point = new global::System.Drawing.Point(370, 137);
			this.lvUGPower.Location = point;
			this.lvUGPower.MultiSelect = false;
			this.lvUGPower.Name = "lvUGPower";
			size = new global::System.Drawing.Size(138, 232);
			this.lvUGPower.Size = size;
			this.lvUGPower.TabIndex = 18;
			this.lvUGPower.UseCompatibleStateImageBehavior = false;
			this.lvUGPower.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader3.Text = "Power";
			this.ColumnHeader3.Width = 110;
			this.lvUGSet.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader1
			});
			this.lvUGSet.FullRowSelect = true;
			this.lvUGSet.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvUGSet.HideSelection = false;
			point = new global::System.Drawing.Point(148, 137);
			this.lvUGSet.Location = point;
			this.lvUGSet.MultiSelect = false;
			this.lvUGSet.Name = "lvUGSet";
			size = new global::System.Drawing.Size(216, 232);
			this.lvUGSet.Size = size;
			this.lvUGSet.TabIndex = 17;
			this.lvUGSet.UseCompatibleStateImageBehavior = false;
			this.lvUGSet.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader1.Text = "Set";
			this.ColumnHeader1.Width = 188;
			this.lvUGGroup.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader2
			});
			this.lvUGGroup.FullRowSelect = true;
			this.lvUGGroup.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvUGGroup.HideSelection = false;
			point = new global::System.Drawing.Point(6, 137);
			this.lvUGGroup.Location = point;
			this.lvUGGroup.MultiSelect = false;
			this.lvUGGroup.Name = "lvUGGroup";
			size = new global::System.Drawing.Size(136, 232);
			this.lvUGGroup.Size = size;
			this.lvUGGroup.TabIndex = 16;
			this.lvUGGroup.UseCompatibleStateImageBehavior = false;
			this.lvUGGroup.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader2.Text = "Group";
			this.ColumnHeader2.Width = 110;
			point = new global::System.Drawing.Point(279, 9);
			this.Label4.Location = point;
			this.Label4.Name = "Label4";
			size = new global::System.Drawing.Size(629, 102);
			this.Label4.Size = size;
			this.Label4.TabIndex = 8;
			this.Label4.Text = componentResourceManager.GetString("Label4.Text");
			point = new global::System.Drawing.Point(12, 89);
			this.Label5.Location = point;
			this.Label5.Name = "Label5";
			size = new global::System.Drawing.Size(83, 20);
			this.Label5.Size = size;
			this.Label5.TabIndex = 10;
			this.Label5.Text = "Class:";
			this.Label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.cbClass.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbClass.FormattingEnabled = true;
			point = new global::System.Drawing.Point(101, 89);
			this.cbClass.Location = point;
			this.cbClass.Name = "cbClass";
			size = new global::System.Drawing.Size(172, 22);
			this.cbClass.Size = size;
			this.cbClass.TabIndex = 9;
			point = new global::System.Drawing.Point(830, 498);
			this.btnOK.Location = point;
			this.btnOK.Name = "btnOK";
			size = new global::System.Drawing.Size(75, 23);
			this.btnOK.Size = size;
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			point = new global::System.Drawing.Point(749, 498);
			this.btnCancel.Location = point;
			this.btnCancel.Name = "btnCancel";
			size = new global::System.Drawing.Size(75, 23);
			this.btnCancel.Size = size;
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOK;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.CancelButton = this.btnCancel;
			size = new global::System.Drawing.Size(918, 547);
			base.ClientSize = size;
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.Label5);
			base.Controls.Add(this.cbClass);
			base.Controls.Add(this.Label4);
			base.Controls.Add(this.GroupBox2);
			base.Controls.Add(this.GroupBox1);
			base.Controls.Add(this.Label3);
			base.Controls.Add(this.cbEntType);
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.txtDisplayName);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.txtEntName);
			this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmEntityEdit";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Editing Entity: Entity_Name";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}


		private global::System.ComponentModel.IContainer components;
	}
}
