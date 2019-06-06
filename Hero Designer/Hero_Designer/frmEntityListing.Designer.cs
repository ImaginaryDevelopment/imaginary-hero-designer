namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmEntityListing : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmEntityListing));
            this.lvEntity = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.btnUp = new global::System.Windows.Forms.Button();
            this.btnDown = new global::System.Windows.Forms.Button();
            this.btnAdd = new global::System.Windows.Forms.Button();
            this.btnDelete = new global::System.Windows.Forms.Button();
            this.btnedit = new global::System.Windows.Forms.Button();
            this.btnOK = new global::System.Windows.Forms.Button();
            this.btnCancel = new global::System.Windows.Forms.Button();
            this.btnClone = new global::System.Windows.Forms.Button();
            base.SuspendLayout();
            this.lvEntity.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader3
            });
            this.lvEntity.FullRowSelect = true;
            this.lvEntity.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvEntity.HideSelection = false;
            global::System.Drawing.Point point = new global::System.Drawing.Point(12, 12);
            this.lvEntity.Location = point;
            this.lvEntity.MultiSelect = false;
            this.lvEntity.Name = "lvEntity";
            global::System.Drawing.Size size = new global::System.Drawing.Size(398, 431);
            this.lvEntity.Size = size;
            this.lvEntity.TabIndex = 0;
            this.lvEntity.UseCompatibleStateImageBehavior = false;
            this.lvEntity.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Entity";
            this.ColumnHeader1.Width = 153;
            this.ColumnHeader2.Text = "Name";
            this.ColumnHeader2.Width = 120;
            this.ColumnHeader3.Text = "Type";
            this.ColumnHeader3.Width = 96;
            point = new global::System.Drawing.Point(416, 12);
            this.btnUp.Location = point;
            this.btnUp.Name = "btnUp";
            size = new global::System.Drawing.Size(75, 23);
            this.btnUp.Size = size;
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 41);
            this.btnDown.Location = point;
            this.btnDown.Name = "btnDown";
            size = new global::System.Drawing.Size(75, 23);
            this.btnDown.Size = size;
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 100);
            this.btnAdd.Location = point;
            this.btnAdd.Name = "btnAdd";
            size = new global::System.Drawing.Size(75, 23);
            this.btnAdd.Size = size;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 158);
            this.btnDelete.Location = point;
            this.btnDelete.Name = "btnDelete";
            size = new global::System.Drawing.Size(75, 23);
            this.btnDelete.Size = size;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 187);
            this.btnedit.Location = point;
            this.btnedit.Name = "btnedit";
            size = new global::System.Drawing.Size(75, 23);
            this.btnedit.Size = size;
            this.btnedit.TabIndex = 5;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 391);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            size = new global::System.Drawing.Size(75, 23);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 420);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new global::System.Drawing.Size(75, 23);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(416, 129);
            this.btnClone.Location = point;
            this.btnClone.Name = "btnClone";
            size = new global::System.Drawing.Size(75, 23);
            this.btnClone.Size = size;
            this.btnClone.TabIndex = 8;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            size = new global::System.Drawing.Size(501, 454);
            base.ClientSize = size;
            base.Controls.Add(this.btnClone);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnedit);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnAdd);
            base.Controls.Add(this.btnDown);
            base.Controls.Add(this.btnUp);
            base.Controls.Add(this.lvEntity);
            this.Font = new global::System.Drawing.Font("Arial", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEntityListing";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entity Editor";
            base.ResumeLayout(false);
        }
        global::System.ComponentModel.IContainer components;
    }
}
