namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmSetFind : global::System.Windows.Forms.Form
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
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmSetFind));
            this.lvBonus = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.lvMag = new global::System.Windows.Forms.ListView();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.lvSet = new global::System.Windows.Forms.ListView();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new global::System.Windows.Forms.ColumnHeader();
            this.ilSets = new global::System.Windows.Forms.ImageList(this.components);
            this.Panel1 = new global::System.Windows.Forms.Panel();
            this.ibClose = new global::midsControls.ImageButton();
            this.ibTopmost = new global::midsControls.ImageButton();
            this.SetInfo = new global::midsControls.ctlPopUp();
            this.Panel1.SuspendLayout();
            base.SuspendLayout();
            this.lvBonus.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1
            });
            this.lvBonus.FullRowSelect = true;
            this.lvBonus.HideSelection = false;
            global::System.Drawing.Point point = new global::System.Drawing.Point(12, 12);
            this.lvBonus.Location = point;
            this.lvBonus.MultiSelect = false;
            this.lvBonus.Name = "lvBonus";
            global::System.Drawing.Size size = new global::System.Drawing.Size(280, 292);
            this.lvBonus.Size = size;
            this.lvBonus.TabIndex = 0;
            this.lvBonus.UseCompatibleStateImageBehavior = false;
            this.lvBonus.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Bonus Effect";
            this.ColumnHeader1.Width = 254;
            this.lvMag.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader2
            });
            this.lvMag.FullRowSelect = true;
            this.lvMag.HideSelection = false;
            point = new global::System.Drawing.Point(298, 12);
            this.lvMag.Location = point;
            this.lvMag.MultiSelect = false;
            this.lvMag.Name = "lvMag";
            size = new global::System.Drawing.Size(127, 116);
            this.lvMag.Size = size;
            this.lvMag.TabIndex = 1;
            this.lvMag.UseCompatibleStateImageBehavior = false;
            this.lvMag.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader2.Text = "Effect Strength";
            this.ColumnHeader2.Width = 99;
            this.lvSet.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader3,
                this.ColumnHeader4,
                this.ColumnHeader5,
                this.ColumnHeader6
            });
            this.lvSet.FullRowSelect = true;
            this.lvSet.HideSelection = false;
            point = new global::System.Drawing.Point(298, 134);
            this.lvSet.Location = point;
            this.lvSet.MultiSelect = false;
            this.lvSet.Name = "lvSet";
            size = new global::System.Drawing.Size(484, 170);
            this.lvSet.Size = size;
            this.lvSet.SmallImageList = this.ilSets;
            this.lvSet.TabIndex = 2;
            this.lvSet.UseCompatibleStateImageBehavior = false;
            this.lvSet.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader3.Text = "Set";
            this.ColumnHeader3.Width = 157;
            this.ColumnHeader4.Text = "Level";
            this.ColumnHeader4.Width = 69;
            this.ColumnHeader5.Text = "Type";
            this.ColumnHeader5.Width = 140;
            this.ColumnHeader6.Text = "Required Enh's.";
            this.ColumnHeader6.Width = 90;
            this.ilSets.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
            size = new global::System.Drawing.Size(16, 16);
            this.ilSets.ImageSize = size;
            this.ilSets.TransparentColor = global::System.Drawing.Color.Transparent;
            this.Panel1.AutoScroll = true;
            this.Panel1.BackColor = global::System.Drawing.Color.Black;
            this.Panel1.Controls.Add(this.SetInfo);
            point = new global::System.Drawing.Point(431, 12);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            size = new global::System.Drawing.Size(351, 115);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 3;
            this.ibClose.Checked = false;
            this.ibClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(677, 310);
            this.ibClose.Location = point;
            this.ibClose.Name = "ibClose";
            size = new global::System.Drawing.Size(105, 22);
            this.ibClose.Size = size;
            this.ibClose.TabIndex = 5;
            this.ibClose.TextOff = "Close";
            this.ibClose.TextOn = "Alt Text";
            this.ibClose.Toggle = false;
            this.ibTopmost.Checked = true;
            this.ibTopmost.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(566, 310);
            this.ibTopmost.Location = point;
            this.ibTopmost.Name = "ibTopmost";
            size = new global::System.Drawing.Size(105, 22);
            this.ibTopmost.Size = size;
            this.ibTopmost.TabIndex = 4;
            this.ibTopmost.TextOff = "Keep On Top";
            this.ibTopmost.TextOn = "Keep On Top";
            this.ibTopmost.Toggle = true;
            this.SetInfo.BXHeight = 600;
            this.SetInfo.ColumnPosition = 0.5f;
            this.SetInfo.ColumnRight = false;
            this.SetInfo.Font = new global::System.Drawing.Font("Arial", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            this.SetInfo.InternalPadding = 3;
            point = new global::System.Drawing.Point(0, 0);
            this.SetInfo.Location = point;
            this.SetInfo.Name = "SetInfo";
            this.SetInfo.SectionPadding = 8;
            size = new global::System.Drawing.Size(331, 198);
            this.SetInfo.Size = size;
            this.SetInfo.TabIndex = 0;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            size = new global::System.Drawing.Size(792, 340);
            base.ClientSize = size;
            base.Controls.Add(this.ibClose);
            base.Controls.Add(this.ibTopmost);
            base.Controls.Add(this.Panel1);
            base.Controls.Add(this.lvSet);
            base.Controls.Add(this.lvMag);
            base.Controls.Add(this.lvBonus);
            this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "frmSetFind";
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Bonus Finder";
            base.TopMost = true;
            this.Panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components;
    }
}
