namespace Hero_Designer
{
    public partial class frmImport_SetBonusAssignment
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

            this.btnClose = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();

            this.btnClose.Location = new System.Drawing.Point(539, 81);
            this.btnClose.Name = "btnClose";

            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(btnClose_Click);

            this.btnImport.Location = new System.Drawing.Point(539, 38);
            this.btnImport.Name = "btnImport";

            this.btnImport.Size = new System.Drawing.Size(86, 23);
            this.btnImport.TabIndex = 50;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(btnImport_Click);
            this.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.lblFile.Location = new System.Drawing.Point(12, 9);
            this.lblFile.Name = "lblFile";

            this.lblFile.Size = new System.Drawing.Size(521, 46);
            this.lblFile.TabIndex = 51;
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnFile.Location = new System.Drawing.Point(539, 9);
            this.btnFile.Name = "btnFile";

            this.btnFile.Size = new System.Drawing.Size(86, 23);
            this.btnFile.TabIndex = 49;
            this.btnFile.Text = "Browse...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(btnFile_Click);
            this.dlgBrowse.DefaultExt = "csv";
            this.dlgBrowse.Filter = "CSV Spreadsheets (*.csv)|*.csv";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(640, 114);
            this.Controls.Add((System.Windows.Forms.Control)this.btnClose);
            this.Controls.Add((System.Windows.Forms.Control)this.btnImport);
            this.Controls.Add((System.Windows.Forms.Control)this.lblFile);
            this.Controls.Add((System.Windows.Forms.Control)this.btnFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Text = "Import Set Bonus Assignments";
            this.ResumeLayout(false);
        }
        #endregion
    }
}