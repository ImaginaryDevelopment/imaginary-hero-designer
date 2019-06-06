namespace Hero_Designer
{

    public partial class frmSetViewer : global::System.Windows.Forms.Form
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        [global::System.Diagnostics.DebuggerStepThrough]
        void InitializeComponent()
        {
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmSetViewer));
            this.lstSets = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ilSet = new global::System.Windows.Forms.ImageList(this.components);
            this.rtxtInfo = new global::System.Windows.Forms.RichTextBox();
            this.rtxtFX = new global::System.Windows.Forms.RichTextBox();
            this.Label1 = new global::System.Windows.Forms.Label();
            this.rtApplied = new global::System.Windows.Forms.RichTextBox();
            this.Label2 = new global::System.Windows.Forms.Label();
            this.chkOnTop = new global::midsControls.ImageButton();
            this.btnClose = new global::midsControls.ImageButton();
            this.btnSmall = new global::midsControls.ImageButton();
            base.SuspendLayout();
            this.lstSets.BackColor = global::System.Drawing.Color.White;
            this.lstSets.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader3
            });
            this.lstSets.ForeColor = global::System.Drawing.Color.Black;
            this.lstSets.FullRowSelect = true;
            this.lstSets.HideSelection = false;
            this.lstSets.LargeImageList = this.ilSet;
            global::System.Drawing.Point point = new global::System.Drawing.Point(12, 168);
            this.lstSets.Location = point;
            this.lstSets.MultiSelect = false;
            this.lstSets.Name = "lstSets";
            global::System.Drawing.Size size = new global::System.Drawing.Size(360, 136);
            this.lstSets.Size = size;
            this.lstSets.SmallImageList = this.ilSet;
            this.lstSets.TabIndex = 0;
            this.lstSets.UseCompatibleStateImageBehavior = false;
            this.lstSets.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Set";
            this.ColumnHeader1.Width = 148;
            this.ColumnHeader2.Text = "Power";
            this.ColumnHeader2.Width = 124;
            this.ColumnHeader3.Text = "Slots";
            this.ilSet.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
            size = new global::System.Drawing.Size(16, 16);
            this.ilSet.ImageSize = size;
            this.ilSet.TransparentColor = global::System.Drawing.Color.Transparent;
            this.rtxtInfo.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            this.rtxtInfo.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(12, 308);
            this.rtxtInfo.Location = point;
            this.rtxtInfo.Name = "rtxtInfo";
            this.rtxtInfo.ReadOnly = true;
            this.rtxtInfo.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            size = new global::System.Drawing.Size(360, 132);
            this.rtxtInfo.Size = size;
            this.rtxtInfo.TabIndex = 1;
            this.rtxtInfo.Text = "";
            this.rtxtFX.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            this.rtxtFX.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(384, 20);
            this.rtxtFX.Location = point;
            this.rtxtFX.Name = "rtxtFX";
            this.rtxtFX.ReadOnly = true;
            this.rtxtFX.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            size = new global::System.Drawing.Size(279, 366);
            this.rtxtFX.Size = size;
            this.rtxtFX.TabIndex = 3;
            this.rtxtFX.Text = "";
            this.Label1.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Label1.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(384, 4);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new global::System.Drawing.Size(188, 16);
            this.Label1.Size = size;
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Effect Breakdown:";
            this.rtApplied.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            this.rtApplied.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(12, 20);
            this.rtApplied.Location = point;
            this.rtApplied.Name = "rtApplied";
            this.rtApplied.ReadOnly = true;
            this.rtApplied.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            size = new global::System.Drawing.Size(360, 140);
            this.rtApplied.Size = size;
            this.rtApplied.TabIndex = 5;
            this.rtApplied.Text = "";
            this.Label2.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Label2.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(12, 4);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new global::System.Drawing.Size(188, 16);
            this.Label2.Size = size;
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Applied Bonus Effects:";
            this.chkOnTop.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
            this.chkOnTop.Checked = true;
            this.chkOnTop.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(558, 392);
            this.chkOnTop.Location = point;
            this.chkOnTop.Name = "chkOnTop";
            size = new global::System.Drawing.Size(105, 22);
            this.chkOnTop.Size = size;
            this.chkOnTop.TabIndex = 19;
            this.chkOnTop.TextOff = "Keep On Top";
            this.chkOnTop.TextOn = "Keep On Top";
            this.chkOnTop.Toggle = true;
            this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
            this.btnClose.Checked = false;
            this.btnClose.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(558, 418);
            this.btnClose.Location = point;
            global::System.Windows.Forms.Padding padding = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Margin = padding;
            this.btnClose.Name = "btnClose";
            size = new global::System.Drawing.Size(105, 22);
            this.btnClose.Size = size;
            this.btnClose.TabIndex = 18;
            this.btnClose.TextOff = "Close";
            this.btnClose.TextOn = "Close";
            this.btnClose.Toggle = false;
            this.btnSmall.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
            this.btnSmall.Checked = false;
            this.btnSmall.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(384, 418);
            this.btnSmall.Location = point;
            padding = new global::System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSmall.Margin = padding;
            this.btnSmall.Name = "btnSmall";
            size = new global::System.Drawing.Size(105, 22);
            this.btnSmall.Size = size;
            this.btnSmall.TabIndex = 20;
            this.btnSmall.TextOff = "<< Shrink";
            this.btnSmall.TextOn = ">>";
            this.btnSmall.Toggle = false;
            size = new global::System.Drawing.Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            size = new global::System.Drawing.Size(675, 448);
            base.ClientSize = size;
            base.Controls.Add(this.btnSmall);
            base.Controls.Add(this.chkOnTop);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.Label2);
            base.Controls.Add(this.rtApplied);
            base.Controls.Add(this.Label1);
            base.Controls.Add(this.rtxtFX);
            base.Controls.Add(this.rtxtInfo);
            base.Controls.Add(this.lstSets);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.ForeColor = global::System.Drawing.Color.White;
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSetViewer";
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Currently Active Sets & Bonuses";
            base.TopMost = true;
            base.ResumeLayout(false);
        }
        global::System.ComponentModel.IContainer components;
    }
}
