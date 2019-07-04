namespace Hero_Designer
{
    public partial class frmEnhEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = (System.ComponentModel.IContainer)new System.ComponentModel.Container();

            this.lvEnh = new System.Windows.Forms.ListView();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ilEnh = new System.Windows.Forms.ImageList(this.components);
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.NoReload = new System.Windows.Forms.CheckBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.lvEnh.BackColor = System.Drawing.Color.White;
            this.lvEnh.Columns.AddRange(new System.Windows.Forms.ColumnHeader[5]
            {
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader1,
        this.ColumnHeader5
            });
            this.lvEnh.ForeColor = System.Drawing.Color.Black;
            this.lvEnh.FullRowSelect = true;
            this.lvEnh.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvEnh.HideSelection = false;

            this.lvEnh.Location = new System.Drawing.Point(8, 8);
            this.lvEnh.MultiSelect = false;
            this.lvEnh.Name = "lvEnh";

            this.lvEnh.Size = new System.Drawing.Size(740, 556);
            this.lvEnh.SmallImageList = this.ilEnh;
            this.lvEnh.TabIndex = 0;
            this.lvEnh.UseCompatibleStateImageBehavior = false;
            this.lvEnh.View = System.Windows.Forms.View.Details;
            this.lvEnh.SelectedIndexChanged += this.lvEnh_SelectedIndexChanged;
            this.lvEnh.DoubleClick += this.lvEnh_DoubleClick;
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
            this.ilEnh.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.ilEnh.ImageSize = new System.Drawing.Size(16, 16);
            this.ilEnh.TransparentColor = System.Drawing.Color.Transparent;
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnUp.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnUp.Location = new System.Drawing.Point(756, 28);
            this.btnUp.Name = "btnUp";

            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Move Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += btnUp_Click;
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnDown.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnDown.Location = new System.Drawing.Point(756, 56);
            this.btnDown.Name = "btnDown";

            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Move Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += btnDown_Click;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnAdd.Location = new System.Drawing.Point(756, 104);
            this.btnAdd.Name = "btnAdd";

            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += btnAdd_Click;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnDelete.Location = new System.Drawing.Point(756, 224);
            this.btnDelete.Name = "btnDelete";

            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += btnDelete_Click;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnEdit.Location = new System.Drawing.Point(756, 184);
            this.btnEdit.Name = "btnEdit";

            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += btnEdit_Click;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnSave.Location = new System.Drawing.Point(720, 580);
            this.btnSave.Name = "btnSave";

            this.btnSave.Size = new System.Drawing.Size(112, 32);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnCancel.Location = new System.Drawing.Point(493, 580);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(207, 32);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel and Discard Changes";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += btnCancel_Click;
            this.btnClone.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnClone.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnClone.Location = new System.Drawing.Point(756, 144);
            this.btnClone.Name = "btnClone";

            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 24;
            this.btnClone.Text = "Clone...";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += btnClone_Click;
            this.NoReload.ForeColor = System.Drawing.Color.White;

            this.NoReload.Location = new System.Drawing.Point(12, 580);
            this.NoReload.Name = "NoReload";

            this.NoReload.Size = new System.Drawing.Size(248, 16);
            this.NoReload.TabIndex = 25;
            this.NoReload.Text = "Disable Image Reload";
            this.NoReload.CheckedChanged += NoReload_CheckedChanged;
            this.lblLoading.BackColor = System.Drawing.Color.White;
            this.lblLoading.Font = new System.Drawing.Font("Arial", 14f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLoading.ForeColor = System.Drawing.Color.Black;

            this.lblLoading.Location = new System.Drawing.Point(256, 264);
            this.lblLoading.Name = "lblLoading";

            this.lblLoading.Size = new System.Drawing.Size(116, 24);
            this.lblLoading.TabIndex = 26;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btnSave;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(0, 0, 32);
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btnCancel;

            this.ClientSize = new System.Drawing.Size(838, 620);
            this.Controls.Add((System.Windows.Forms.Control)this.lblLoading);
            this.Controls.Add((System.Windows.Forms.Control)this.NoReload);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClone);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnSave);
            this.Controls.Add((System.Windows.Forms.Control)this.btnEdit);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDelete);
            this.Controls.Add((System.Windows.Forms.Control)this.btnAdd);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDown);
            this.Controls.Add((System.Windows.Forms.Control)this.btnUp);
            this.Controls.Add((System.Windows.Forms.Control)this.lvEnh);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enhancement Editor";
            this.ResumeLayout(false);
        }
        #endregion
        System.Windows.Forms.Button btnAdd;
        System.Windows.Forms.Button btnCancel;
        System.Windows.Forms.Button btnClone;
        System.Windows.Forms.Button btnDelete;
        System.Windows.Forms.Button btnDown;
        System.Windows.Forms.Button btnEdit;
        System.Windows.Forms.Button btnSave;
        System.Windows.Forms.Button btnUp;
        System.Windows.Forms.ColumnHeader ColumnHeader1;
        System.Windows.Forms.ColumnHeader ColumnHeader2;
        System.Windows.Forms.ColumnHeader ColumnHeader3;
        System.Windows.Forms.ColumnHeader ColumnHeader4;
        System.Windows.Forms.ColumnHeader ColumnHeader5;
        System.Windows.Forms.ImageList ilEnh;
        System.Windows.Forms.Label lblLoading;
        System.Windows.Forms.ListView lvEnh;
        System.Windows.Forms.CheckBox NoReload;
    }
}