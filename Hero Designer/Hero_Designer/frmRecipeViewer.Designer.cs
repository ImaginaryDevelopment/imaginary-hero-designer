namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmRecipeViewer : global::System.Windows.Forms.Form
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
        void InitializeComponent()
        {
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmRecipeViewer));
            this.pbRecipe = new global::System.Windows.Forms.PictureBox();
            this.lvPower = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.lvDPA = new global::System.Windows.Forms.ListView();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.ilSets = new global::System.Windows.Forms.ImageList(this.components);
            this.chkSortByLevel = new global::System.Windows.Forms.CheckBox();
            this.lblHeader = new global::System.Windows.Forms.Label();
            this.Panel1 = new global::System.Windows.Forms.Panel();
            this.VScrollBar1 = new global::System.Windows.Forms.VScrollBar();
            this.RecipeInfo = new global::midsControls.ctlPopUp();
            this.Panel2 = new global::System.Windows.Forms.Panel();
            this.chkRecipe = new global::System.Windows.Forms.CheckBox();
            this.ToolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
            this.ibMiniList = new global::midsControls.ImageButton();
            this.ibClipboard = new global::midsControls.ImageButton();
            this.ibTopmost = new global::midsControls.ImageButton();
            this.ibClose = new global::midsControls.ImageButton();
            ((global::System.ComponentModel.ISupportInitialize)this.pbRecipe).BeginInit();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(0, 0);
            this.pbRecipe.Location = point;
            this.pbRecipe.Name = "pbRecipe";
            global::System.Drawing.Size size = new global::System.Drawing.Size(60, 30);
            this.pbRecipe.Size = size;
            this.pbRecipe.TabIndex = 0;
            this.pbRecipe.TabStop = false;
            this.lvPower.CheckBoxes = true;
            this.lvPower.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1
            });
            this.lvPower.FullRowSelect = true;
            this.lvPower.HideSelection = false;
            point = new global::System.Drawing.Point(12, 12);
            this.lvPower.Location = point;
            this.lvPower.MultiSelect = false;
            this.lvPower.Name = "lvPower";
            size = new global::System.Drawing.Size(176, 191);
            this.lvPower.Size = size;
            this.lvPower.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
            this.lvPower.TabIndex = 1;
            this.lvPower.UseCompatibleStateImageBehavior = false;
            this.lvPower.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Power";
            this.ColumnHeader1.Width = 148;
            this.lvDPA.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader3,
                this.ColumnHeader4,
                this.ColumnHeader5
            });
            this.lvDPA.FullRowSelect = true;
            this.lvDPA.HideSelection = false;
            point = new global::System.Drawing.Point(194, 12);
            this.lvDPA.Location = point;
            this.lvDPA.MultiSelect = false;
            this.lvDPA.Name = "lvDPA";
            size = new global::System.Drawing.Size(428, 191);
            this.lvDPA.Size = size;
            this.lvDPA.SmallImageList = this.ilSets;
            this.lvDPA.TabIndex = 8;
            this.lvDPA.UseCompatibleStateImageBehavior = false;
            this.lvDPA.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader3.Text = "Enhancement";
            this.ColumnHeader3.Width = 241;
            this.ColumnHeader4.Text = "Level";
            this.ColumnHeader4.Width = 45;
            this.ColumnHeader5.Text = "Power";
            this.ColumnHeader5.Width = 114;
            this.ilSets.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
            size = new global::System.Drawing.Size(16, 16);
            this.ilSets.ImageSize = size;
            this.ilSets.TransparentColor = global::System.Drawing.Color.Transparent;
            this.chkSortByLevel.Checked = true;
            this.chkSortByLevel.CheckState = global::System.Windows.Forms.CheckState.Checked;
            this.chkSortByLevel.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(12, 209);
            this.chkSortByLevel.Location = point;
            this.chkSortByLevel.Name = "chkSortByLevel";
            size = new global::System.Drawing.Size(176, 16);
            this.chkSortByLevel.Size = size;
            this.chkSortByLevel.TabIndex = 9;
            this.chkSortByLevel.Text = "Sort By Level";
            this.chkSortByLevel.UseVisualStyleBackColor = true;
            this.lblHeader.Font = new global::System.Drawing.Font("Arial", 17.5f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            this.lblHeader.ForeColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            point = new global::System.Drawing.Point(66, 0);
            this.lblHeader.Location = point;
            this.lblHeader.Name = "lblHeader";
            size = new global::System.Drawing.Size(541, 30);
            this.lblHeader.Size = size;
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "Select A Power / Recipe";
            this.lblHeader.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            this.Panel1.Controls.Add(this.VScrollBar1);
            this.Panel1.Controls.Add(this.RecipeInfo);
            point = new global::System.Drawing.Point(0, 36);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            size = new global::System.Drawing.Size(610, 177);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 11;
            point = new global::System.Drawing.Point(593, 0);
            this.VScrollBar1.Location = point;
            this.VScrollBar1.Maximum = 20;
            this.VScrollBar1.Name = "VScrollBar1";
            size = new global::System.Drawing.Size(17, 176);
            this.VScrollBar1.Size = size;
            this.VScrollBar1.TabIndex = 3;
            this.RecipeInfo.BXHeight = 2048;
            this.RecipeInfo.ColumnPosition = 0.5f;
            this.RecipeInfo.ColumnRight = false;
            this.RecipeInfo.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            this.RecipeInfo.ForeColor = global::System.Drawing.Color.Black;
            this.RecipeInfo.InternalPadding = 3;
            point = new global::System.Drawing.Point(3, 3);
            this.RecipeInfo.Location = point;
            this.RecipeInfo.Name = "RecipeInfo";
            this.RecipeInfo.ScrollY = 0f;
            this.RecipeInfo.SectionPadding = 8;
            size = new global::System.Drawing.Size(587, 212);
            this.RecipeInfo.Size = size;
            this.RecipeInfo.TabIndex = 2;
            this.Panel2.BackColor = global::System.Drawing.Color.Black;
            this.Panel2.Controls.Add(this.Panel1);
            this.Panel2.Controls.Add(this.pbRecipe);
            this.Panel2.Controls.Add(this.lblHeader);
            point = new global::System.Drawing.Point(12, 226);
            this.Panel2.Location = point;
            this.Panel2.Name = "Panel2";
            size = new global::System.Drawing.Size(610, 213);
            this.Panel2.Size = size;
            this.Panel2.TabIndex = 12;
            this.chkRecipe.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(234, 445);
            this.chkRecipe.Location = point;
            this.chkRecipe.Name = "chkRecipe";
            size = new global::System.Drawing.Size(166, 22);
            this.chkRecipe.Size = size;
            this.chkRecipe.TabIndex = 15;
            this.chkRecipe.Text = "Include Recipes";
            this.ToolTip1.SetToolTip(this.chkRecipe, "Add a list of recipes to the shopping list");
            this.chkRecipe.UseVisualStyleBackColor = true;
            this.ibMiniList.Checked = false;
            this.ibMiniList.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(0, 0);
            this.ibMiniList.KnockoutLocationPoint = point;
            point = new global::System.Drawing.Point(123, 445);
            this.ibMiniList.Location = point;
            this.ibMiniList.Name = "ibMiniList";
            size = new global::System.Drawing.Size(105, 22);
            this.ibMiniList.Size = size;
            this.ibMiniList.TabIndex = 14;
            this.ibMiniList.TextOff = "To I-G Helper";
            this.ibMiniList.TextOn = "Alt Text";
            this.ibMiniList.Toggle = false;
            this.ibClipboard.Checked = false;
            this.ibClipboard.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Pixel, 0);
            point = new global::System.Drawing.Point(0, 0);
            this.ibClipboard.KnockoutLocationPoint = point;
            point = new global::System.Drawing.Point(12, 445);
            this.ibClipboard.Location = point;
            this.ibClipboard.Name = "ibClipboard";
            size = new global::System.Drawing.Size(105, 22);
            this.ibClipboard.Size = size;
            this.ibClipboard.TabIndex = 13;
            this.ibClipboard.TextOff = "To Clipboard";
            this.ibClipboard.TextOn = "Alt Text";
            this.ibClipboard.Toggle = false;
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
            base.Controls.Add(this.chkRecipe);
            base.Controls.Add(this.ibMiniList);
            base.Controls.Add(this.ibClipboard);
            base.Controls.Add(this.chkSortByLevel);
            base.Controls.Add(this.lvDPA);
            base.Controls.Add(this.ibTopmost);
            base.Controls.Add(this.ibClose);
            base.Controls.Add(this.lvPower);
            base.Controls.Add(this.Panel2);
            this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "frmRecipeViewer";
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Recipe Viewer";
            base.TopMost = true;
            ((global::System.ComponentModel.ISupportInitialize)this.pbRecipe).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            base.ResumeLayout(false);
        }


        global::System.ComponentModel.IContainer components;
    }
}
