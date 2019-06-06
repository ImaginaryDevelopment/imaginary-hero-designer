namespace Hero_Designer
{

    public partial class frmSetListing : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmSetListing));
            this.ilSets = new global::System.Windows.Forms.ImageList(this.components);
            this.lvSets = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new global::System.Windows.Forms.ColumnHeader();
            this.btnClone = new global::System.Windows.Forms.Button();
            this.btnCancel = new global::System.Windows.Forms.Button();
            this.btnSave = new global::System.Windows.Forms.Button();
            this.btnEdit = new global::System.Windows.Forms.Button();
            this.btnDelete = new global::System.Windows.Forms.Button();
            this.btnAdd = new global::System.Windows.Forms.Button();
            this.btnDown = new global::System.Windows.Forms.Button();
            this.btnUp = new global::System.Windows.Forms.Button();
            this.NoReload = new global::System.Windows.Forms.CheckBox();
            base.SuspendLayout();
            this.ilSets.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
            global::System.Drawing.Size size = new global::System.Drawing.Size(16, 16);
            this.ilSets.ImageSize = size;
            this.ilSets.TransparentColor = global::System.Drawing.Color.Transparent;
            this.lvSets.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader3,
                this.ColumnHeader4,
                this.ColumnHeader5,
                this.ColumnHeader6
            });
            this.lvSets.FullRowSelect = true;
            this.lvSets.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSets.HideSelection = false;
            this.lvSets.LargeImageList = this.ilSets;
            global::System.Drawing.Point point = new global::System.Drawing.Point(16, 16);
            this.lvSets.Location = point;
            this.lvSets.MultiSelect = false;
            this.lvSets.Name = "lvSets";
            size = new global::System.Drawing.Size(600, 520);
            this.lvSets.Size = size;
            this.lvSets.SmallImageList = this.ilSets;
            this.lvSets.TabIndex = 0;
            this.lvSets.UseCompatibleStateImageBehavior = false;
            this.lvSets.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Set Name";
            this.ColumnHeader1.Width = 233;
            this.ColumnHeader2.Text = "Type";
            this.ColumnHeader2.Width = 104;
            this.ColumnHeader3.Text = "Min Level";
            this.ColumnHeader3.Width = 70;
            this.ColumnHeader4.Text = "Max Level";
            this.ColumnHeader4.Width = 70;
            this.ColumnHeader5.Text = "Enh's";
            this.ColumnHeader5.Width = 51;
            this.ColumnHeader6.Text = "FX";
            this.btnClone.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnClone.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(624, 132);
            this.btnClone.Location = point;
            this.btnClone.Name = "btnClone";
            size = new global::System.Drawing.Size(75, 23);
            this.btnClone.Size = size;
            this.btnClone.TabIndex = 32;
            this.btnClone.Text = "Clone...";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(375, 544);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new global::System.Drawing.Size(193, 32);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel and Discard Changes";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnSave.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnSave.DialogResult = global::System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(588, 544);
            this.btnSave.Location = point;
            this.btnSave.Name = "btnSave";
            size = new global::System.Drawing.Size(112, 32);
            this.btnSave.Size = size;
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnEdit.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnEdit.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(624, 172);
            this.btnEdit.Location = point;
            this.btnEdit.Name = "btnEdit";
            size = new global::System.Drawing.Size(75, 23);
            this.btnEdit.Size = size;
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnDelete.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnDelete.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(624, 212);
            this.btnDelete.Location = point;
            this.btnDelete.Name = "btnDelete";
            size = new global::System.Drawing.Size(75, 23);
            this.btnDelete.Size = size;
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnAdd.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnAdd.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(624, 92);
            this.btnAdd.Location = point;
            this.btnAdd.Name = "btnAdd";
            size = new global::System.Drawing.Size(75, 23);
            this.btnAdd.Size = size;
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnDown.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnDown.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(624, 44);
            this.btnDown.Location = point;
            this.btnDown.Name = "btnDown";
            size = new global::System.Drawing.Size(75, 23);
            this.btnDown.Size = size;
            this.btnDown.TabIndex = 26;
            this.btnDown.Text = "Move Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnUp.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnUp.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(624, 16);
            this.btnUp.Location = point;
            this.btnUp.Name = "btnUp";
            size = new global::System.Drawing.Size(75, 23);
            this.btnUp.Size = size;
            this.btnUp.TabIndex = 25;
            this.btnUp.Text = "Move Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.NoReload.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(20, 552);
            this.NoReload.Location = point;
            this.NoReload.Name = "NoReload";
            size = new global::System.Drawing.Size(248, 16);
            this.NoReload.Size = size;
            this.NoReload.TabIndex = 33;
            this.NoReload.Text = "Disable Image Reload";
            size = new global::System.Drawing.Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            size = new global::System.Drawing.Size(706, 584);
            base.ClientSize = size;
            base.Controls.Add(this.NoReload);
            base.Controls.Add(this.btnClone);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnEdit);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnAdd);
            base.Controls.Add(this.btnDown);
            base.Controls.Add(this.btnUp);
            base.Controls.Add(this.lvSets);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSetListing";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invention Set Editor";
            base.ResumeLayout(false);
        }


        global::System.ComponentModel.IContainer components;
    }
}
