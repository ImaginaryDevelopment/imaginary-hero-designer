namespace Hero_Designer
{

    public partial class frmEnhEdit : global::System.Windows.Forms.Form
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
        private void InitializeComponent()
        {
            this.components = new global::System.ComponentModel.Container();
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmEnhEdit));
            this.lvEnh = new global::System.Windows.Forms.ListView();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new global::System.Windows.Forms.ColumnHeader();
            this.ilEnh = new global::System.Windows.Forms.ImageList(this.components);
            this.btnUp = new global::System.Windows.Forms.Button();
            this.btnDown = new global::System.Windows.Forms.Button();
            this.btnAdd = new global::System.Windows.Forms.Button();
            this.btnDelete = new global::System.Windows.Forms.Button();
            this.btnEdit = new global::System.Windows.Forms.Button();
            this.btnSave = new global::System.Windows.Forms.Button();
            this.btnCancel = new global::System.Windows.Forms.Button();
            this.btnClone = new global::System.Windows.Forms.Button();
            this.NoReload = new global::System.Windows.Forms.CheckBox();
            this.lblLoading = new global::System.Windows.Forms.Label();
            base.SuspendLayout();
            this.lvEnh.BackColor = global::System.Drawing.Color.White;
            this.lvEnh.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader2,
                this.ColumnHeader3,
                this.ColumnHeader4,
                this.ColumnHeader1,
                this.ColumnHeader5
            });
            this.lvEnh.ForeColor = global::System.Drawing.Color.Black;
            this.lvEnh.FullRowSelect = true;
            this.lvEnh.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvEnh.HideSelection = false;
            global::System.Drawing.Point point = new global::System.Drawing.Point(8, 8);
            this.lvEnh.Location = point;
            this.lvEnh.MultiSelect = false;
            this.lvEnh.Name = "lvEnh";
            global::System.Drawing.Size size = new global::System.Drawing.Size(740, 556);
            this.lvEnh.Size = size;
            this.lvEnh.SmallImageList = this.ilEnh;
            this.lvEnh.TabIndex = 0;
            this.lvEnh.UseCompatibleStateImageBehavior = false;
            this.lvEnh.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader2.Text = "Name";
            this.ColumnHeader2.Width = 312;
            this.ColumnHeader3.Text = "Type";
            this.ColumnHeader3.Width = 72;
            this.ColumnHeader4.Text = "Effects";
            this.ColumnHeader4.Width = 48;
            this.ColumnHeader1.Text = "Classes";
            this.ColumnHeader1.Width = 135;
            this.ColumnHeader5.Text = "Set";
            this.ColumnHeader5.Width = 147;
            this.ilEnh.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth32Bit;
            size = new global::System.Drawing.Size(16, 16);
            this.ilEnh.ImageSize = size;
            this.ilEnh.TransparentColor = global::System.Drawing.Color.Transparent;
            this.btnUp.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnUp.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(756, 28);
            this.btnUp.Location = point;
            this.btnUp.Name = "btnUp";
            size = new global::System.Drawing.Size(75, 23);
            this.btnUp.Size = size;
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Move Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnDown.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnDown.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(756, 56);
            this.btnDown.Location = point;
            this.btnDown.Name = "btnDown";
            size = new global::System.Drawing.Size(75, 23);
            this.btnDown.Size = size;
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Move Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnAdd.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnAdd.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(756, 104);
            this.btnAdd.Location = point;
            this.btnAdd.Name = "btnAdd";
            size = new global::System.Drawing.Size(75, 23);
            this.btnAdd.Size = size;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnDelete.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnDelete.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(756, 224);
            this.btnDelete.Location = point;
            this.btnDelete.Name = "btnDelete";
            size = new global::System.Drawing.Size(75, 23);
            this.btnDelete.Size = size;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnEdit.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnEdit.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(756, 184);
            this.btnEdit.Location = point;
            this.btnEdit.Name = "btnEdit";
            size = new global::System.Drawing.Size(75, 23);
            this.btnEdit.Size = size;
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnSave.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnSave.DialogResult = global::System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(720, 580);
            this.btnSave.Location = point;
            this.btnSave.Name = "btnSave";
            size = new global::System.Drawing.Size(112, 32);
            this.btnSave.Size = size;
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(493, 580);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new global::System.Drawing.Size(207, 32);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel and Discard Changes";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnClone.BackColor = global::System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnClone.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            point = new global::System.Drawing.Point(756, 144);
            this.btnClone.Location = point;
            this.btnClone.Name = "btnClone";
            size = new global::System.Drawing.Size(75, 23);
            this.btnClone.Size = size;
            this.btnClone.TabIndex = 24;
            this.btnClone.Text = "Clone...";
            this.btnClone.UseVisualStyleBackColor = true;
            this.NoReload.ForeColor = global::System.Drawing.Color.White;
            point = new global::System.Drawing.Point(12, 580);
            this.NoReload.Location = point;
            this.NoReload.Name = "NoReload";
            size = new global::System.Drawing.Size(248, 16);
            this.NoReload.Size = size;
            this.NoReload.TabIndex = 25;
            this.NoReload.Text = "Disable Image Reload";
            this.lblLoading.BackColor = global::System.Drawing.Color.White;
            this.lblLoading.Font = new global::System.Drawing.Font("Arial", 14f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.lblLoading.ForeColor = global::System.Drawing.Color.Black;
            point = new global::System.Drawing.Point(256, 264);
            this.lblLoading.Location = point;
            this.lblLoading.Name = "lblLoading";
            size = new global::System.Drawing.Size(116, 24);
            this.lblLoading.Size = size;
            this.lblLoading.TabIndex = 26;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            base.AcceptButton = this.btnSave;
            size = new global::System.Drawing.Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            base.CancelButton = this.btnCancel;
            size = new global::System.Drawing.Size(838, 620);
            base.ClientSize = size;
            base.Controls.Add(this.lblLoading);
            base.Controls.Add(this.NoReload);
            base.Controls.Add(this.btnClone);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnEdit);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnAdd);
            base.Controls.Add(this.btnDown);
            base.Controls.Add(this.btnUp);
            base.Controls.Add(this.lvEnh);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            this.ForeColor = global::System.Drawing.SystemColors.ControlText;
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEnhEdit";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enhancement Editor";
            base.ResumeLayout(false);
        }


        private global::System.ComponentModel.IContainer components;
    }
}
