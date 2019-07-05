namespace Hero_Designer
{
    public partial class frmImport_Recipe
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

            this.Button1 = new System.Windows.Forms.Button();
            this.lblAttribTableCount = new System.Windows.Forms.Label();
            this.lblAttribDate = new System.Windows.Forms.Label();
            this.lblAttribTables = new System.Windows.Forms.Label();
            this.btnAttribLoad = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblAttribIndex = new System.Windows.Forms.Label();
            this.btnAttribTable = new System.Windows.Forms.Button();
            this.btnAttribIndex = new System.Windows.Forms.Button();
            this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();

            this.Button1.Location = new System.Drawing.Point(539, 197);
            this.Button1.Name = "Button1";

            this.Button1.Size = new System.Drawing.Size(86, 23);
            this.Button1.TabIndex = 34;
            this.Button1.Text = "Close";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(Button1_Click);

            this.lblAttribTableCount.Location = new System.Drawing.Point(208, 159);
            this.lblAttribTableCount.Name = "lblAttribTableCount";

            this.lblAttribTableCount.Size = new System.Drawing.Size(132, 18);
            this.lblAttribTableCount.TabIndex = 33;
            this.lblAttribTableCount.Text = "Recipes:";

            this.lblAttribDate.Location = new System.Drawing.Point(9, 159);
            this.lblAttribDate.Name = "lblAttribDate";

            this.lblAttribDate.Size = new System.Drawing.Size(175, 18);
            this.lblAttribDate.TabIndex = 32;
            this.lblAttribDate.Text = "Date:";
            this.lblAttribTables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblAttribTables.Location = new System.Drawing.Point(12, 99);
            this.lblAttribTables.Name = "lblAttribTables";

            this.lblAttribTables.Size = new System.Drawing.Size(521, 46);
            this.lblAttribTables.TabIndex = 27;
            this.lblAttribTables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnAttribLoad.Location = new System.Drawing.Point(539, 154);
            this.btnAttribLoad.Name = "btnAttribLoad";

            this.btnAttribLoad.Size = new System.Drawing.Size(86, 23);
            this.btnAttribLoad.TabIndex = 25;
            this.btnAttribLoad.Text = "Import";
            this.btnAttribLoad.UseVisualStyleBackColor = true;
            this.btnAttribLoad.Click += new System.EventHandler(btnAttribLoad_Click);

            this.Label4.Location = new System.Drawing.Point(12, 83);
            this.Label4.Name = "Label4";

            this.Label4.Size = new System.Drawing.Size(150, 14);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Ingredients (baserecipes2)";

            this.Label3.Location = new System.Drawing.Point(12, 9);
            this.Label3.Name = "Label3";

            this.Label3.Size = new System.Drawing.Size(150, 14);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "Detail (baserecipes)";
            this.lblAttribIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblAttribIndex.Location = new System.Drawing.Point(12, 25);
            this.lblAttribIndex.Name = "lblAttribIndex";

            this.lblAttribIndex.Size = new System.Drawing.Size(521, 46);
            this.lblAttribIndex.TabIndex = 26;
            this.lblAttribIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnAttribTable.Location = new System.Drawing.Point(539, 99);
            this.btnAttribTable.Name = "btnAttribTable";

            this.btnAttribTable.Size = new System.Drawing.Size(86, 23);
            this.btnAttribTable.TabIndex = 24;
            this.btnAttribTable.Text = "Browse";
            this.btnAttribTable.UseVisualStyleBackColor = true;
            this.btnAttribTable.Click += new System.EventHandler(btnAttribTable_Click);

            this.btnAttribIndex.Location = new System.Drawing.Point(539, 25);
            this.btnAttribIndex.Name = "btnAttribIndex";

            this.btnAttribIndex.Size = new System.Drawing.Size(86, 23);
            this.btnAttribIndex.TabIndex = 23;
            this.btnAttribIndex.Text = "Browse...";
            this.btnAttribIndex.UseVisualStyleBackColor = true;
            this.btnAttribIndex.Click += new System.EventHandler(btnAttribIndex_Click);
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(640, 238);
            this.Controls.Add((System.Windows.Forms.Control)this.Button1);
            this.Controls.Add((System.Windows.Forms.Control)this.lblAttribTableCount);
            this.Controls.Add((System.Windows.Forms.Control)this.lblAttribDate);
            this.Controls.Add((System.Windows.Forms.Control)this.lblAttribTables);
            this.Controls.Add((System.Windows.Forms.Control)this.btnAttribLoad);
            this.Controls.Add((System.Windows.Forms.Control)this.Label4);
            this.Controls.Add((System.Windows.Forms.Control)this.Label3);
            this.Controls.Add((System.Windows.Forms.Control)this.lblAttribIndex);
            this.Controls.Add((System.Windows.Forms.Control)this.btnAttribTable);
            this.Controls.Add((System.Windows.Forms.Control)this.btnAttribIndex);
            this.Text = "Import Recipes";
            this.ResumeLayout(false);
        }
        #endregion

        System.Windows.Forms.Button btnAttribIndex;
        System.Windows.Forms.Button btnAttribLoad;
        System.Windows.Forms.Button btnAttribTable;
        System.Windows.Forms.Button Button1;
        System.Windows.Forms.OpenFileDialog dlgBrowse;
        System.Windows.Forms.Label Label3;
        System.Windows.Forms.Label Label4;
        System.Windows.Forms.Label lblAttribDate;
        System.Windows.Forms.Label lblAttribIndex;
        System.Windows.Forms.Label lblAttribTableCount;
        System.Windows.Forms.Label lblAttribTables;
    }
}