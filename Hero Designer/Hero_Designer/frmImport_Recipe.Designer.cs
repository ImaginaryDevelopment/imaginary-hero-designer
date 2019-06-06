namespace Hero_Designer
{

    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
    public partial class frmImport_Recipe : global::System.Windows.Forms.Form
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
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmImport_Recipe));
            this.Button1 = new global::System.Windows.Forms.Button();
            this.lblAttribTableCount = new global::System.Windows.Forms.Label();
            this.lblAttribDate = new global::System.Windows.Forms.Label();
            this.lblAttribTables = new global::System.Windows.Forms.Label();
            this.btnAttribLoad = new global::System.Windows.Forms.Button();
            this.Label4 = new global::System.Windows.Forms.Label();
            this.Label3 = new global::System.Windows.Forms.Label();
            this.lblAttribIndex = new global::System.Windows.Forms.Label();
            this.btnAttribTable = new global::System.Windows.Forms.Button();
            this.btnAttribIndex = new global::System.Windows.Forms.Button();
            this.dlgBrowse = new global::System.Windows.Forms.OpenFileDialog();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(539, 197);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            global::System.Drawing.Size size = new global::System.Drawing.Size(86, 23);
            this.Button1.Size = size;
            this.Button1.TabIndex = 34;
            this.Button1.Text = "Close";
            this.Button1.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(208, 159);
            this.lblAttribTableCount.Location = point;
            this.lblAttribTableCount.Name = "lblAttribTableCount";
            size = new global::System.Drawing.Size(132, 18);
            this.lblAttribTableCount.Size = size;
            this.lblAttribTableCount.TabIndex = 33;
            this.lblAttribTableCount.Text = "Recipes:";
            point = new global::System.Drawing.Point(9, 159);
            this.lblAttribDate.Location = point;
            this.lblAttribDate.Name = "lblAttribDate";
            size = new global::System.Drawing.Size(175, 18);
            this.lblAttribDate.Size = size;
            this.lblAttribDate.TabIndex = 32;
            this.lblAttribDate.Text = "Date:";
            this.lblAttribTables.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(12, 99);
            this.lblAttribTables.Location = point;
            this.lblAttribTables.Name = "lblAttribTables";
            size = new global::System.Drawing.Size(521, 46);
            this.lblAttribTables.Size = size;
            this.lblAttribTables.TabIndex = 27;
            this.lblAttribTables.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(539, 154);
            this.btnAttribLoad.Location = point;
            this.btnAttribLoad.Name = "btnAttribLoad";
            size = new global::System.Drawing.Size(86, 23);
            this.btnAttribLoad.Size = size;
            this.btnAttribLoad.TabIndex = 25;
            this.btnAttribLoad.Text = "Import";
            this.btnAttribLoad.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(12, 83);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new global::System.Drawing.Size(150, 14);
            this.Label4.Size = size;
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Ingredients (baserecipes2)";
            point = new global::System.Drawing.Point(12, 9);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new global::System.Drawing.Size(150, 14);
            this.Label3.Size = size;
            this.Label3.TabIndex = 28;
            this.Label3.Text = "Detail (baserecipes)";
            this.lblAttribIndex.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
            point = new global::System.Drawing.Point(12, 25);
            this.lblAttribIndex.Location = point;
            this.lblAttribIndex.Name = "lblAttribIndex";
            size = new global::System.Drawing.Size(521, 46);
            this.lblAttribIndex.Size = size;
            this.lblAttribIndex.TabIndex = 26;
            this.lblAttribIndex.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
            point = new global::System.Drawing.Point(539, 99);
            this.btnAttribTable.Location = point;
            this.btnAttribTable.Name = "btnAttribTable";
            size = new global::System.Drawing.Size(86, 23);
            this.btnAttribTable.Size = size;
            this.btnAttribTable.TabIndex = 24;
            this.btnAttribTable.Text = "Browse";
            this.btnAttribTable.UseVisualStyleBackColor = true;
            point = new global::System.Drawing.Point(539, 25);
            this.btnAttribIndex.Location = point;
            this.btnAttribIndex.Name = "btnAttribIndex";
            size = new global::System.Drawing.Size(86, 23);
            this.btnAttribIndex.Size = size;
            this.btnAttribIndex.TabIndex = 23;
            this.btnAttribIndex.Text = "Browse...";
            this.btnAttribIndex.UseVisualStyleBackColor = true;
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
            base.AutoScaleDimensions = autoScaleDimensions;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
            size = new global::System.Drawing.Size(640, 238);
            base.ClientSize = size;
            base.Controls.Add(this.Button1);
            base.Controls.Add(this.lblAttribTableCount);
            base.Controls.Add(this.lblAttribDate);
            base.Controls.Add(this.lblAttribTables);
            base.Controls.Add(this.btnAttribLoad);
            base.Controls.Add(this.Label4);
            base.Controls.Add(this.Label3);
            base.Controls.Add(this.lblAttribIndex);
            base.Controls.Add(this.btnAttribTable);
            base.Controls.Add(this.btnAttribIndex);
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "frmImport_Recipe";
            this.Text = "Import Recipes";
            base.ResumeLayout(false);
        }
        global::System.ComponentModel.IContainer components;
    }
}
