using System.ComponentModel;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmPowerBrowser
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

            this.lvPower = new System.Windows.Forms.ListView();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.lvSet = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.ilPS = new System.Windows.Forms.ImageList(this.components);
            this.lvGroup = new System.Windows.Forms.ListView();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ilAT = new System.Windows.Forms.ImageList(this.components);
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnPowerSort = new System.Windows.Forms.Button();
            this.ilPower = new System.Windows.Forms.ImageList(this.components);
            this.btnPowerUp = new System.Windows.Forms.Button();
            this.btnPowerDown = new System.Windows.Forms.Button();
            this.btnPowerAdd = new System.Windows.Forms.Button();
            this.btnPowerDelete = new System.Windows.Forms.Button();
            this.btnPowerClone = new System.Windows.Forms.Button();
            this.btnPowerEdit = new System.Windows.Forms.Button();
            this.btnSetSort = new System.Windows.Forms.Button();
            this.btnSetEdit = new System.Windows.Forms.Button();
            this.btnSetDelete = new System.Windows.Forms.Button();
            this.btnSetAdd = new System.Windows.Forms.Button();
            this.btnClassClone = new System.Windows.Forms.Button();
            this.btnClassSort = new System.Windows.Forms.Button();
            this.btnClassEdit = new System.Windows.Forms.Button();
            this.btnClassDelete = new System.Windows.Forms.Button();
            this.btnClassAdd = new System.Windows.Forms.Button();
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.btnClassUp = new System.Windows.Forms.Button();
            this.btnClassDown = new System.Windows.Forms.Button();
            this.pnlSet = new System.Windows.Forms.Panel();
            this.btnPSUp = new System.Windows.Forms.Button();
            this.btnPSDown = new System.Windows.Forms.Button();
            this.pnlPower = new System.Windows.Forms.Panel();
            this.lblSet = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.pnlGroup.SuspendLayout();
            this.pnlSet.SuspendLayout();
            this.pnlPower.SuspendLayout();
            this.SuspendLayout();
            this.lvPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvPower.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
            {
        this.ColumnHeader3,
        this.ColumnHeader5,
        this.ColumnHeader7
            });
            this.lvPower.FullRowSelect = true;
            this.lvPower.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPower.HideSelection = false;

            this.lvPower.Location = new System.Drawing.Point(587, 37);
            this.lvPower.MultiSelect = false;
            this.lvPower.Name = "lvPower";

            this.lvPower.Size = new System.Drawing.Size(400, 429);
            this.lvPower.TabIndex = 21;
            this.lvPower.UseCompatibleStateImageBehavior = false;
            this.lvPower.View = System.Windows.Forms.View.Details;
            this.lvPower.SelectedIndexChanged += new System.EventHandler(this.lvPower_SelectedIndexChanged);
            this.lvPower.DoubleClick += new System.EventHandler(this.lvPower_DoubleClick);
            this.ColumnHeader3.Text = "Power";
            this.ColumnHeader3.Width = 206;
            this.ColumnHeader5.Text = "Name";
            this.ColumnHeader5.Width = 108;
            this.ColumnHeader7.Text = "Level";
            this.lvSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
            {
        this.ColumnHeader1,
        this.ColumnHeader4,
        this.ColumnHeader6
            });
            this.lvSet.FullRowSelect = true;
            this.lvSet.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSet.HideSelection = false;

            this.lvSet.Location = new System.Drawing.Point(251, 37);
            this.lvSet.MultiSelect = false;
            this.lvSet.Name = "lvSet";

            this.lvSet.Size = new System.Drawing.Size(330, 429);
            this.lvSet.SmallImageList = this.ilPS;
            this.lvSet.TabIndex = 20;
            this.lvSet.UseCompatibleStateImageBehavior = false;
            this.lvSet.View = System.Windows.Forms.View.Details;
            this.lvSet.SelectedIndexChanged += new System.EventHandler(this.lvSet_SelectedIndexChanged);
            this.lvSet.DoubleClick += new System.EventHandler(this.lvSet_DoubleClick);
            this.ColumnHeader1.Text = "Set";
            this.ColumnHeader1.Width = 129;
            this.ColumnHeader4.Text = "Name";
            this.ColumnHeader4.Width = 115;
            this.ColumnHeader6.Text = "Type";
            this.ilPS.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.ilPS.ImageSize = new System.Drawing.Size(34, 18);
            this.ilPS.TransparentColor = System.Drawing.Color.Transparent;
            this.lvGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1]
            {
        this.ColumnHeader2
            });
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGroup.HideSelection = false;

            this.lvGroup.Location = new System.Drawing.Point(12, 37);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";

            this.lvGroup.Size = new System.Drawing.Size(233, 429);
            this.lvGroup.SmallImageList = this.ilAT;
            this.lvGroup.TabIndex = 19;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.SelectedIndexChanged += new System.EventHandler(this.lvGroup_SelectedIndexChanged);
            this.lvGroup.DoubleClick += new System.EventHandler(this.lvGroup_DoubleClick);
            this.ColumnHeader2.Text = "Group";
            this.ColumnHeader2.Width = 207;
            this.ilAT.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.ilAT.ImageSize = new System.Drawing.Size(16, 16);
            this.ilAT.TransparentColor = System.Drawing.Color.Transparent;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;

            this.cbFilter.Location = new System.Drawing.Point(86, 9);
            this.cbFilter.Name = "cbFilter";

            this.cbFilter.Size = new System.Drawing.Size(221, 22);
            this.cbFilter.TabIndex = 22;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(cbFilter_SelectedIndexChanged);

            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";

            this.Label1.Size = new System.Drawing.Size(68, 22);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Filter By:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.btnPowerSort.Location = new System.Drawing.Point(239, 44);
            this.btnPowerSort.Name = "btnPowerSort";

            this.btnPowerSort.Size = new System.Drawing.Size(75, 23);
            this.btnPowerSort.TabIndex = 26;
            this.btnPowerSort.Text = "Re-Sort";
            this.btnPowerSort.Click += new System.EventHandler(btnPowerSort_Click);
            this.btnPowerSort.UseVisualStyleBackColor = true;
            this.ilPower.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;

            this.ilPower.ImageSize = new System.Drawing.Size(16, 16);
            this.ilPower.TransparentColor = System.Drawing.Color.Transparent;

            this.btnPowerUp.Location = new System.Drawing.Point(3, 15);
            this.btnPowerUp.Name = "btnPowerUp";

            this.btnPowerUp.Size = new System.Drawing.Size(75, 23);
            this.btnPowerUp.TabIndex = 28;
            this.btnPowerUp.Text = "Up";
            this.btnPowerUp.UseVisualStyleBackColor = true;
            this.btnPowerUp.Click += new System.EventHandler(btnPowerUp_Click);

            this.btnPowerDown.Location = new System.Drawing.Point(3, 44);
            this.btnPowerDown.Name = "btnPowerDown";

            this.btnPowerDown.Size = new System.Drawing.Size(75, 23);
            this.btnPowerDown.TabIndex = 29;
            this.btnPowerDown.Text = "Down";
            this.btnPowerDown.UseVisualStyleBackColor = true;
            this.btnPowerDown.Click += new System.EventHandler(btnPowerDown_Click);

            this.btnPowerAdd.Location = new System.Drawing.Point(320, 15);
            this.btnPowerAdd.Name = "btnPowerAdd";

            this.btnPowerAdd.Size = new System.Drawing.Size(75, 23);
            this.btnPowerAdd.TabIndex = 30;
            this.btnPowerAdd.Text = "Add";
            this.btnPowerAdd.UseVisualStyleBackColor = true;
            this.btnPowerAdd.Click += new System.EventHandler(btnPowerAdd_Click);

            this.btnPowerDelete.Location = new System.Drawing.Point(239, 15);
            this.btnPowerDelete.Name = "btnPowerDelete";

            this.btnPowerDelete.Size = new System.Drawing.Size(75, 23);
            this.btnPowerDelete.TabIndex = 31;
            this.btnPowerDelete.Text = "Delete";
            this.btnPowerDelete.UseVisualStyleBackColor = true;
            this.btnPowerDelete.Click += new System.EventHandler(btnPowerDelete_Click);

            this.btnPowerClone.Location = new System.Drawing.Point(320, 44);
            this.btnPowerClone.Name = "btnPowerClone";

            this.btnPowerClone.Size = new System.Drawing.Size(75, 23);
            this.btnPowerClone.TabIndex = 33;
            this.btnPowerClone.Text = "Clone";
            this.btnPowerClone.UseVisualStyleBackColor = true;
            this.btnPowerClone.Click += new System.EventHandler(btnPowerClone_Click);

            this.btnPowerEdit.Location = new System.Drawing.Point(320, 73);
            this.btnPowerEdit.Name = "btnPowerEdit";

            this.btnPowerEdit.Size = new System.Drawing.Size(75, 23);
            this.btnPowerEdit.TabIndex = 32;
            this.btnPowerEdit.Text = "Edit";
            this.btnPowerEdit.UseVisualStyleBackColor = true;
            this.btnPowerEdit.Click += new System.EventHandler(btnPowerEdit_Click);

            this.btnSetSort.Location = new System.Drawing.Point(169, 44);
            this.btnSetSort.Name = "btnSetSort";

            this.btnSetSort.Size = new System.Drawing.Size(75, 23);
            this.btnSetSort.TabIndex = 35;
            this.btnSetSort.Text = "Re-Sort";
            this.btnSetSort.UseVisualStyleBackColor = true;
            this.btnSetSort.Click += new System.EventHandler(btnSetSort_Click);

            this.btnSetEdit.Location = new System.Drawing.Point(250, 44);
            this.btnSetEdit.Name = "btnSetEdit";

            this.btnSetEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSetEdit.TabIndex = 40;
            this.btnSetEdit.Text = "Edit";
            this.btnSetEdit.UseVisualStyleBackColor = true;
            this.btnSetEdit.Click += new System.EventHandler(btnSetEdit_Click);

            this.btnSetDelete.Location = new System.Drawing.Point(169, 15);
            this.btnSetDelete.Name = "btnSetDelete";

            this.btnSetDelete.Size = new System.Drawing.Size(75, 23);
            this.btnSetDelete.TabIndex = 39;
            this.btnSetDelete.Text = "Delete";
            this.btnSetDelete.UseVisualStyleBackColor = true;
            this.btnSetDelete.Click += new System.EventHandler(btnSetDelete_Click);

            this.btnSetAdd.Location = new System.Drawing.Point(250, 15);
            this.btnSetAdd.Name = "btnSetAdd";

            this.btnSetAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSetAdd.TabIndex = 38;
            this.btnSetAdd.Text = "Add";
            this.btnSetAdd.UseVisualStyleBackColor = true;
            this.btnSetAdd.Click += new System.EventHandler(btnSetAdd_Click);

            this.btnClassClone.Location = new System.Drawing.Point(153, 44);
            this.btnClassClone.Name = "btnClassClone";

            this.btnClassClone.Size = new System.Drawing.Size(75, 23);
            this.btnClassClone.TabIndex = 46;
            this.btnClassClone.Text = "Clone";
            this.btnClassClone.UseVisualStyleBackColor = true;
            this.btnClassClone.Click += new System.EventHandler(btnClassClone_Click);

            this.btnClassSort.Location = new System.Drawing.Point(72, 44);
            this.btnClassSort.Name = "btnClassSort";

            this.btnClassSort.Size = new System.Drawing.Size(75, 23);
            this.btnClassSort.TabIndex = 42;
            this.btnClassSort.Text = "Re-Sort";
            this.btnClassSort.UseVisualStyleBackColor = true;
            this.btnClassSort.Click += new System.EventHandler(btnClassSort_Click);

            this.btnClassEdit.Location = new System.Drawing.Point(153, 73);
            this.btnClassEdit.Name = "btnClassEdit";

            this.btnClassEdit.Size = new System.Drawing.Size(75, 23);
            this.btnClassEdit.TabIndex = 45;
            this.btnClassEdit.Text = "Edit";
            this.btnClassEdit.UseVisualStyleBackColor = true;
            this.btnClassEdit.Click += new System.EventHandler(btnClassEdit_Click);

            this.btnClassDelete.Location = new System.Drawing.Point(72, 15);
            this.btnClassDelete.Name = "btnClassDelete";

            this.btnClassDelete.Size = new System.Drawing.Size(75, 23);
            this.btnClassDelete.TabIndex = 44;
            this.btnClassDelete.Text = "Delete";
            this.btnClassDelete.UseVisualStyleBackColor = true;
            this.btnClassDelete.Click += new System.EventHandler(btnClassDelete_Click);

            this.btnClassAdd.Location = new System.Drawing.Point(153, 15);
            this.btnClassAdd.Name = "btnClassAdd";

            this.btnClassAdd.Size = new System.Drawing.Size(75, 23);
            this.btnClassAdd.TabIndex = 43;
            this.btnClassAdd.Text = "Add";
            this.btnClassAdd.UseVisualStyleBackColor = true;
            this.btnClassAdd.Click += new System.EventHandler(btnClassAdd_Click);
            this.pnlGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassUp);
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassDown);
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassClone);
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassDelete);
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassSort);
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassAdd);
            this.pnlGroup.Controls.Add((System.Windows.Forms.Control)this.btnClassEdit);

            this.pnlGroup.Location = new System.Drawing.Point(12, 494);
            this.pnlGroup.Name = "pnlGroup";

            this.pnlGroup.Size = new System.Drawing.Size(233, 105);
            this.pnlGroup.TabIndex = 47;

            this.btnClassUp.Location = new System.Drawing.Point(3, 15);
            this.btnClassUp.Name = "btnClassUp";

            this.btnClassUp.Size = new System.Drawing.Size(64, 23);
            this.btnClassUp.TabIndex = 47;
            this.btnClassUp.Text = "Up";
            this.btnClassUp.UseVisualStyleBackColor = true;
            this.btnClassUp.Click += new System.EventHandler(btnClassUp_Click);

            this.btnClassDown.Location = new System.Drawing.Point(3, 44);
            this.btnClassDown.Name = "btnClassDown";

            this.btnClassDown.Size = new System.Drawing.Size(64, 23);
            this.btnClassDown.TabIndex = 48;
            this.btnClassDown.Text = "Down";
            this.btnClassDown.UseVisualStyleBackColor = true;
            this.btnClassDown.Click += new System.EventHandler(btnClassDown_Click);
            this.pnlSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSet.Controls.Add((System.Windows.Forms.Control)this.btnPSUp);
            this.pnlSet.Controls.Add((System.Windows.Forms.Control)this.btnPSDown);
            this.pnlSet.Controls.Add((System.Windows.Forms.Control)this.btnSetDelete);
            this.pnlSet.Controls.Add((System.Windows.Forms.Control)this.btnSetSort);
            this.pnlSet.Controls.Add((System.Windows.Forms.Control)this.btnSetAdd);
            this.pnlSet.Controls.Add((System.Windows.Forms.Control)this.btnSetEdit);

            this.pnlSet.Location = new System.Drawing.Point(251, 494);
            this.pnlSet.Name = "pnlSet";

            this.pnlSet.Size = new System.Drawing.Size(330, 105);
            this.pnlSet.TabIndex = 48;

            this.btnPSUp.Location = new System.Drawing.Point(3, 15);
            this.btnPSUp.Name = "btnPSUp";

            this.btnPSUp.Size = new System.Drawing.Size(75, 23);
            this.btnPSUp.TabIndex = 41;
            this.btnPSUp.Text = "Up";
            this.btnPSUp.UseVisualStyleBackColor = true;
            this.btnPSUp.Click += new System.EventHandler(btnPSUp_Click);

            this.btnPSDown.Location = new System.Drawing.Point(3, 44);
            this.btnPSDown.Name = "btnPSDown";

            this.btnPSDown.Size = new System.Drawing.Size(75, 23);
            this.btnPSDown.TabIndex = 42;
            this.btnPSDown.Text = "Down";
            this.btnPSDown.UseVisualStyleBackColor = true;
            this.btnPSDown.Click += new System.EventHandler(btnPSDown_Click);
            this.pnlPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerClone);
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerUp);
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerSort);
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerDown);
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerEdit);
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerDelete);
            this.pnlPower.Controls.Add((System.Windows.Forms.Control)this.btnPowerAdd);

            this.pnlPower.Location = new System.Drawing.Point(587, 494);
            this.pnlPower.Name = "pnlPower";

            this.pnlPower.Size = new System.Drawing.Size(400, 105);
            this.pnlPower.TabIndex = 49;

            this.lblSet.Location = new System.Drawing.Point(251, 467);
            this.lblSet.Name = "lblSet";

            this.lblSet.Size = new System.Drawing.Size(326, 24);
            this.lblSet.TabIndex = 50;
            this.lblSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPower.Location = new System.Drawing.Point(587, 467);
            this.lblPower.Name = "lblPower";

            this.lblPower.Size = new System.Drawing.Size(400, 24);
            this.lblPower.TabIndex = 51;
            this.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnOK.Location = new System.Drawing.Point(855, 607);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new System.Drawing.Size(132, 32);
            this.btnOK.TabIndex = 52;
            this.btnOK.Text = "Save && Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(btnOK_Click);

            this.btnCancel.Location = new System.Drawing.Point(717, 607);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(132, 32);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel && Discard";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);

            this.Label2.Location = new System.Drawing.Point(313, 13);
            this.Label2.Name = "Label2";

            this.Label2.Size = new System.Drawing.Size(323, 16);
            this.Label2.TabIndex = 54;
            this.Label2.Text = "To edit Archetype Classes, change filtering to Classes";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            this.ClientSize = new System.Drawing.Size(999, 651);
            this.Controls.Add((System.Windows.Forms.Control)this.Label2);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnOK);
            this.Controls.Add((System.Windows.Forms.Control)this.lblPower);
            this.Controls.Add((System.Windows.Forms.Control)this.lblSet);
            this.Controls.Add((System.Windows.Forms.Control)this.Label1);
            this.Controls.Add((System.Windows.Forms.Control)this.cbFilter);
            this.Controls.Add((System.Windows.Forms.Control)this.lvPower);
            this.Controls.Add((System.Windows.Forms.Control)this.lvSet);
            this.Controls.Add((System.Windows.Forms.Control)this.lvGroup);
            this.Controls.Add((System.Windows.Forms.Control)this.pnlGroup);
            this.Controls.Add((System.Windows.Forms.Control)this.pnlSet);
            this.Controls.Add((System.Windows.Forms.Control)this.pnlPower);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Database Browser";
            this.pnlGroup.ResumeLayout(false);
            this.pnlSet.ResumeLayout(false);
            this.pnlPower.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        Button btnCancel;
        Button btnClassAdd;
        Button btnClassClone;
        Button btnClassDelete;
        Button btnClassDown;
        Button btnClassEdit;
        Button btnClassSort;
        Button btnClassUp;
        Button btnOK;
        Button btnPowerAdd;
        Button btnPowerClone;
        Button btnPowerDelete;
        Button btnPowerDown;
        Button btnPowerEdit;
        Button btnPowerSort;
        Button btnPowerUp;
        Button btnPSDown;
        Button btnPSUp;
        Button btnSetAdd;
        Button btnSetDelete;
        Button btnSetEdit;
        Button btnSetSort;
        ComboBox cbFilter;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;
        ColumnHeader ColumnHeader7;
        ImageList ilAT;
        ImageList ilPower;
        ImageList ilPS;
        Label Label1;
        Label Label2;
        Label lblPower;
        Label lblSet;
        ListView lvGroup;
        ListView lvPower;
        ListView lvSet;
        Panel pnlGroup;
        Panel pnlPower;
        Panel pnlSet;
    }
}