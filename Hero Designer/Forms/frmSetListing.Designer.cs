using System.ComponentModel;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmSetListing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

            this.ilSets = new System.Windows.Forms.ImageList(this.components);
            this.lvSets = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.NoReload = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            this.ilSets.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.ilSets.ImageSize = new System.Drawing.Size(16, 16);
            this.ilSets.TransparentColor = System.Drawing.Color.Transparent;
            this.lvSets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[6]
            {
        this.ColumnHeader1,
        this.ColumnHeader2,
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader5,
        this.ColumnHeader6
            });
            this.lvSets.FullRowSelect = true;
            this.lvSets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSets.HideSelection = false;
            this.lvSets.LargeImageList = this.ilSets;

            this.lvSets.Location = new System.Drawing.Point(16, 16);
            this.lvSets.MultiSelect = false;
            this.lvSets.Name = "lvSets";

            this.lvSets.Size = new System.Drawing.Size(600, 520);
            this.lvSets.SmallImageList = this.ilSets;
            this.lvSets.TabIndex = 0;
            this.lvSets.UseCompatibleStateImageBehavior = false;
            this.lvSets.View = System.Windows.Forms.View.Details;
            this.lvSets.DoubleClick += new System.EventHandler(this.lvSets_DoubleClick);
            this.lvSets.SelectedIndexChanged += new System.EventHandler(this.lvSets_SelectedIndexChanged);
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
            this.btnClone.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnClone.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnClone.Location = new System.Drawing.Point(624, 132);
            this.btnClone.Name = "btnClone";

            this.btnClone.Size = new System.Drawing.Size(75, 23);
            this.btnClone.TabIndex = 32;
            this.btnClone.Text = "Clone...";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Click += new System.EventHandler(btnClone_Click);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnCancel.Location = new System.Drawing.Point(375, 544);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(193, 32);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel and Discard Changes";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnSave.Location = new System.Drawing.Point(588, 544);
            this.btnSave.Name = "btnSave";

            this.btnSave.Size = new System.Drawing.Size(112, 32);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save and Close";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(btnSave_Click);
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnEdit.Location = new System.Drawing.Point(624, 172);
            this.btnEdit.Name = "btnEdit";

            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(btnEdit_Click);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnDelete.Location = new System.Drawing.Point(624, 212);
            this.btnDelete.Name = "btnDelete";

            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(btnDelete_Click);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnAdd.Location = new System.Drawing.Point(624, 92);
            this.btnAdd.Name = "btnAdd";

            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(btnAdd_Click);
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnDown.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnDown.Location = new System.Drawing.Point(624, 44);
            this.btnDown.Name = "btnDown";

            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 26;
            this.btnDown.Text = "Move Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(btnDown_Click);
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.btnUp.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnUp.Location = new System.Drawing.Point(624, 16);
            this.btnUp.Name = "btnUp";

            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 25;
            this.btnUp.Text = "Move Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(btnUp_Click);
            this.NoReload.ForeColor = System.Drawing.Color.White;

            this.NoReload.Location = new System.Drawing.Point(20, 552);
            this.NoReload.Name = "NoReload";

            this.NoReload.Size = new System.Drawing.Size(248, 16);
            this.NoReload.TabIndex = 33;
            this.NoReload.Text = "Disable Image Reload";
            this.NoReload.CheckedChanged += new System.EventHandler(NoReload_CheckedChanged);

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(0, 0, 32);

            this.ClientSize = new System.Drawing.Size(706, 584);
            this.Controls.Add((System.Windows.Forms.Control)this.NoReload);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClone);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnSave);
            this.Controls.Add((System.Windows.Forms.Control)this.btnEdit);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDelete);
            this.Controls.Add((System.Windows.Forms.Control)this.btnAdd);
            this.Controls.Add((System.Windows.Forms.Control)this.btnDown);
            this.Controls.Add((System.Windows.Forms.Control)this.btnUp);
            this.Controls.Add((System.Windows.Forms.Control)this.lvSets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invention Set Editor";
            this.ResumeLayout(false);
        }
        #endregion

        Button btnAdd;
        Button btnCancel;
        Button btnClone;
        Button btnDelete;
        Button btnDown;
        Button btnEdit;
        Button btnSave;
        Button btnUp;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;
        ImageList ilSets;
        ListView lvSets;
        CheckBox NoReload;
    }
}