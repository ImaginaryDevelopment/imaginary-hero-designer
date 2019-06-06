namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmSalvageEdit : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmSalvageEdit));
            this.lvSalvage = new global::System.Windows.Forms.ListView();
            this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new global::System.Windows.Forms.ColumnHeader();
            this.btnOK = new global::System.Windows.Forms.Button();
            this.btnCancel = new global::System.Windows.Forms.Button();
            this.btnImport = new global::System.Windows.Forms.Button();
            this.txtExternal = new global::System.Windows.Forms.TextBox();
            this.Label1 = new global::System.Windows.Forms.Label();
            this.Label2 = new global::System.Windows.Forms.Label();
            this.txtInternal = new global::System.Windows.Forms.TextBox();
            this.cbRarity = new global::System.Windows.Forms.ComboBox();
            this.Label3 = new global::System.Windows.Forms.Label();
            this.Label4 = new global::System.Windows.Forms.Label();
            this.cbOrigin = new global::System.Windows.Forms.ComboBox();
            this.Label5 = new global::System.Windows.Forms.Label();
            this.cbLevel = new global::System.Windows.Forms.ComboBox();
            this.btnDelete = new global::System.Windows.Forms.Button();
            this.btnAdd = new global::System.Windows.Forms.Button();
            base.SuspendLayout();
            this.lvSalvage.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
            {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader3,
                this.ColumnHeader4
            });
            this.lvSalvage.FullRowSelect = true;
            this.lvSalvage.HideSelection = false;
            global::System.Drawing.Point point = new global::System.Drawing.Point(12, 12);
            this.lvSalvage.Location = point;
            this.lvSalvage.MultiSelect = false;
            this.lvSalvage.Name = "lvSalvage";
            global::System.Drawing.Size size = new global::System.Drawing.Size(468, 316);
            this.lvSalvage.Size = size;
            this.lvSalvage.TabIndex = 0;
            this.lvSalvage.UseCompatibleStateImageBehavior = false;
            this.lvSalvage.View = global::System.Windows.Forms.View.Details;
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 213;
            this.ColumnHeader2.Text = "Origin";
            this.ColumnHeader2.Width = 72;
            this.ColumnHeader3.Text = "Rarity";
            this.ColumnHeader3.Width = 76;
            this.ColumnHeader4.Text = "Level";
            this.ColumnHeader4.Width = 75;
            this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
            point = new global::System.Drawing.Point(605, 304);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            size = new global::System.Drawing.Size(113, 24);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Save && Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
            point = new global::System.Drawing.Point(486, 304);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new global::System.Drawing.Size(113, 24);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(486, 274);
            this.btnImport.Location = point;
            this.btnImport.Name = "btnImport";
            size = new global::System.Drawing.Size(232, 24);
            this.btnImport.Size = size;
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Clear and Import from Spreadsheet";
            this.btnImport.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(564, 12);
            this.txtExternal.Location = point;
            this.txtExternal.Name = "txtExternal";
            size = new global::System.Drawing.Size(154, 20);
            this.txtExternal.Size = size;
            this.txtExternal.TabIndex = 4;
            point = new global::System.Drawing.Point(486, 12);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new global::System.Drawing.Size(72, 20);
            this.Label1.Size = size;
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Name:";
            this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            point = new global::System.Drawing.Point(486, 38);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new global::System.Drawing.Size(72, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Internal:";
            this.Label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            point = new global::System.Drawing.Point(564, 38);
            this.txtInternal.Location = point;
            this.txtInternal.Name = "txtInternal";
            size = new global::System.Drawing.Size(154, 20);
            this.txtInternal.Size = size;
            this.txtInternal.TabIndex = 6;
            this.cbRarity.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRarity.FormattingEnabled = true;
            point = new global::System.Drawing.Point(564, 64);
            this.cbRarity.Location = point;
            this.cbRarity.Name = "cbRarity";
            size = new global::System.Drawing.Size(154, 22);
            this.cbRarity.Size = size;
            this.cbRarity.TabIndex = 8;
            point = new global::System.Drawing.Point(486, 64);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new global::System.Drawing.Size(72, 22);
            this.Label3.Size = size;
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Rarity:";
            this.Label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            point = new global::System.Drawing.Point(486, 92);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new global::System.Drawing.Size(72, 22);
            this.Label4.Size = size;
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Origin:";
            this.Label4.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            this.cbOrigin.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigin.FormattingEnabled = true;
            point = new global::System.Drawing.Point(564, 92);
            this.cbOrigin.Location = point;
            this.cbOrigin.Name = "cbOrigin";
            size = new global::System.Drawing.Size(154, 22);
            this.cbOrigin.Size = size;
            this.cbOrigin.TabIndex = 10;
            point = new global::System.Drawing.Point(486, 120);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new global::System.Drawing.Size(72, 22);
            this.Label5.Size = size;
            this.Label5.TabIndex = 13;
            this.Label5.Text = "Level:";
            this.Label5.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
            this.cbLevel.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevel.FormattingEnabled = true;
            point = new global::System.Drawing.Point(564, 120);
            this.cbLevel.Location = point;
            this.cbLevel.Name = "cbLevel";
            size = new global::System.Drawing.Size(154, 22);
            this.cbLevel.Size = size;
            this.cbLevel.TabIndex = 12;
            point = new global::System.Drawing.Point(486, 214);
            this.btnDelete.Location = point;
            this.btnDelete.Name = "btnDelete";
            size = new global::System.Drawing.Size(113, 24);
            this.btnDelete.Size = size;
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(486, 184);
            this.btnAdd.Location = point;
            this.btnAdd.Name = "btnAdd";
            size = new global::System.Drawing.Size(113, 24);
            this.btnAdd.Size = size;
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            base.AcceptButton = this.btnOK;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            base.CancelButton = this.btnCancel;
            size = new global::System.Drawing.Size(730, 340);
            base.ClientSize = size;
            base.Controls.Add(this.btnAdd);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.Label5);
            base.Controls.Add(this.cbLevel);
            base.Controls.Add(this.Label4);
            base.Controls.Add(this.cbOrigin);
            base.Controls.Add(this.Label3);
            base.Controls.Add(this.cbRarity);
            base.Controls.Add(this.Label2);
            base.Controls.Add(this.txtInternal);
            base.Controls.Add(this.Label1);
            base.Controls.Add(this.txtExternal);
            base.Controls.Add(this.btnImport);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.lvSalvage);
            this.Font = new global::System.Drawing.Font("Arial", 11f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Pixel, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSalvageEdit";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Salvage Editor";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
        global::System.ComponentModel.IContainer components;
    }
}
