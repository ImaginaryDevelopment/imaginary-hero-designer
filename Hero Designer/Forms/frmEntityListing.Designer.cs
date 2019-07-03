namespace Hero_Designer
{
    public partial class frmEntityListing
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

            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmEntityListing));
            this.lvEntity = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.lvEntity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
            {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3
            });
            this.lvEntity.FullRowSelect = true;
            this.lvEntity.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvEntity.HideSelection = false;

            this.lvEntity.Location = new System.Drawing.Point(12, 12);
            this.lvEntity.MultiSelect = false;
            this.lvEntity.Name = "lvEntity";

            this.lvEntity.Size = new System.Drawing.Size(398, 431);
            this.lvEntity.TabIndex = 0;
            this.lvEntity.UseCompatibleStateImageBehavior = false;
            this.lvEntity.View = System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Entity";
            this.ColumnHeader1.Width = 153;
            this.ColumnHeader2.Text = "Name";
            this.ColumnHeader2.Width = 120;
            this.ColumnHeader3.Text = "Type";
            this.ColumnHeader3.Width = 96;

            this.btnUp.Location = new System.Drawing.Point(416, 12);
            this.btnUp.Name = "btnUp";

            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;

            this.btnDown.Location = new System.Drawing.Point(416, 41);
            this.btnDown.Name = "btnDown";

            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;

            this.btnAdd.Location = new System.Drawing.Point(416, 100);
            this.btnAdd.Name = "btnAdd";

            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;

            this.btnDelete.Location = new System.Drawing.Point(416, 158);
            this.btnDelete.Name = "btnDelete";

            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = true;

            this.btnedit.Location = new System.Drawing.Point(416, 187);
            this.btnedit.Name = "btnedit";

            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 5;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;

            this.btnOK.Location = new System.Drawing.Point(416, 391);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;

            this.btnCancel.Location = new System.Drawing.Point(416, 420);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            this.btnClone.Location = new System.Drawing.Point(416, 129);
            this.btnClone.Name = "btnClone";

            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 8;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            this.ClientSize = new System.Drawing.Size(501, 454);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClone);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnOK);
            this.Controls.Add((System.Windows.Forms.Control)this.btnedit);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDelete);
            this.Controls.Add((System.Windows.Forms.Control)this.btnAdd);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDown);
            this.Controls.Add((System.Windows.Forms.Control)this.btnUp);
            this.Controls.Add((System.Windows.Forms.Control)this.lvEntity);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmEntityListing);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entity Editor";
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.btnAdd.Click += btnAdd_Click;
                this.btnCancel.Click += btnCancel_Click;
                this.btnClone.Click += btnClone_Click;
                this.btnDelete.Click += btnDelete_Click;
                this.btnDown.Click += btnDown_Click;
                this.btnOK.Click += btnOK_Click;
                this.btnUp.Click += btnUp_Click;
                this.btnedit.Click += btnEdit_Click;
                this.lvEntity.DoubleClick += lvEntity_DoubleClick;
            }
            // finished with events
            this.ResumeLayout(false);
        }

        #endregion
    }
}