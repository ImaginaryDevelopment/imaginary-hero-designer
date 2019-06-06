namespace Hero_Designer
{

    public partial class frmTweakMatching : global::System.Windows.Forms.Form
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
        void InitializeComponent()
        {
            global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmTweakMatching));
            this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
            this.Button2 = new global::System.Windows.Forms.Button();
            this.Button1 = new global::System.Windows.Forms.Button();
            this.btnDel = new global::System.Windows.Forms.Button();
            this.txtOvr = new global::System.Windows.Forms.TextBox();
            this.lstTweaks = new global::System.Windows.Forms.ListBox();
            this.GroupBox2 = new global::System.Windows.Forms.GroupBox();
            this.cbPower = new global::System.Windows.Forms.ComboBox();
            this.cbSet1 = new global::System.Windows.Forms.ComboBox();
            this.cbType1 = new global::System.Windows.Forms.ComboBox();
            this.cbAT1 = new global::System.Windows.Forms.ComboBox();
            this.txtAddActual = new global::System.Windows.Forms.TextBox();
            this.txtAddOvr = new global::System.Windows.Forms.TextBox();
            this.btnAdd = new global::System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            base.SuspendLayout();
            this.GroupBox1.Controls.Add(this.Button2);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.btnDel);
            this.GroupBox1.Controls.Add(this.txtOvr);
            this.GroupBox1.Controls.Add(this.lstTweaks);
            this.GroupBox1.Controls.Add(this.GroupBox2);
            global::System.Drawing.Point point = new global::System.Drawing.Point(8, 8);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            global::System.Drawing.Size size = new global::System.Drawing.Size(580, 424);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Override Editor";
            this.Button2.BackColor = global::System.Drawing.Color.FromArgb(128, 128, 255);
            this.Button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Button2.ForeColor = global::System.Drawing.Color.Black;
            point = new global::System.Drawing.Point(320, 52);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new global::System.Drawing.Size(56, 24);
            this.Button2.Size = size;
            this.Button2.TabIndex = 9;
            this.Button2.Text = "Update";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button1.BackColor = global::System.Drawing.Color.FromArgb(128, 128, 255);
            this.Button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.Button1.ForeColor = global::System.Drawing.Color.Black;
            point = new global::System.Drawing.Point(516, 392);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new global::System.Drawing.Size(56, 24);
            this.Button1.Size = size;
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Close";
            this.Button1.UseVisualStyleBackColor = false;
            this.btnDel.BackColor = global::System.Drawing.Color.FromArgb(128, 128, 255);
            this.btnDel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.btnDel.ForeColor = global::System.Drawing.Color.Black;
            point = new global::System.Drawing.Point(236, 52);
            this.btnDel.Location = point;
            this.btnDel.Name = "btnDel";
            size = new global::System.Drawing.Size(56, 24);
            this.btnDel.Size = size;
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            point = new global::System.Drawing.Point(232, 24);
            this.txtOvr.Location = point;
            this.txtOvr.Name = "txtOvr";
            size = new global::System.Drawing.Size(336, 20);
            this.txtOvr.Size = size;
            this.txtOvr.TabIndex = 6;
            this.txtOvr.Text = "Override Desc";
            point = new global::System.Drawing.Point(8, 20);
            this.lstTweaks.Location = point;
            this.lstTweaks.Name = "lstTweaks";
            size = new global::System.Drawing.Size(216, 394);
            this.lstTweaks.Size = size;
            this.lstTweaks.TabIndex = 0;
            this.GroupBox2.Controls.Add(this.cbPower);
            this.GroupBox2.Controls.Add(this.cbSet1);
            this.GroupBox2.Controls.Add(this.cbType1);
            this.GroupBox2.Controls.Add(this.cbAT1);
            this.GroupBox2.Controls.Add(this.txtAddActual);
            this.GroupBox2.Controls.Add(this.txtAddOvr);
            this.GroupBox2.Controls.Add(this.btnAdd);
            point = new global::System.Drawing.Point(232, 112);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new global::System.Drawing.Size(336, 204);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Add:";
            this.cbPower.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            point = new global::System.Drawing.Point(8, 92);
            this.cbPower.Location = point;
            this.cbPower.Name = "cbPower";
            size = new global::System.Drawing.Size(132, 21);
            this.cbPower.Size = size;
            this.cbPower.TabIndex = 6;
            this.cbSet1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            point = new global::System.Drawing.Point(8, 68);
            this.cbSet1.Location = point;
            this.cbSet1.Name = "cbSet1";
            size = new global::System.Drawing.Size(132, 21);
            this.cbSet1.Size = size;
            this.cbSet1.TabIndex = 2;
            this.cbType1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            point = new global::System.Drawing.Point(8, 44);
            this.cbType1.Location = point;
            this.cbType1.Name = "cbType1";
            size = new global::System.Drawing.Size(132, 21);
            this.cbType1.Size = size;
            this.cbType1.TabIndex = 1;
            this.cbAT1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
            point = new global::System.Drawing.Point(8, 20);
            this.cbAT1.Location = point;
            this.cbAT1.Name = "cbAT1";
            size = new global::System.Drawing.Size(132, 21);
            this.cbAT1.Size = size;
            this.cbAT1.TabIndex = 0;
            this.txtAddActual.Enabled = false;
            point = new global::System.Drawing.Point(8, 120);
            this.txtAddActual.Location = point;
            this.txtAddActual.Name = "txtAddActual";
            size = new global::System.Drawing.Size(336, 20);
            this.txtAddActual.Size = size;
            this.txtAddActual.TabIndex = 3;
            this.txtAddActual.Text = "Actual Desc";
            point = new global::System.Drawing.Point(8, 148);
            this.txtAddOvr.Location = point;
            this.txtAddOvr.Name = "txtAddOvr";
            size = new global::System.Drawing.Size(336, 20);
            this.txtAddOvr.Size = size;
            this.txtAddOvr.TabIndex = 4;
            this.txtAddOvr.Text = "Override Desc";
            this.btnAdd.BackColor = global::System.Drawing.Color.FromArgb(128, 128, 255);
            this.btnAdd.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            this.btnAdd.ForeColor = global::System.Drawing.Color.Black;
            point = new global::System.Drawing.Point(8, 172);
            this.btnAdd.Location = point;
            this.btnAdd.Name = "btnAdd";
            size = new global::System.Drawing.Size(56, 24);
            this.btnAdd.Size = size;
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 32);
            size = new global::System.Drawing.Size(602, 446);
            base.ClientSize = size;
            base.Controls.Add(this.GroupBox1);
            this.ForeColor = global::System.Drawing.Color.White;
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmTweakMatching";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tweak Powerset Matching";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            base.ResumeLayout(false);
        }


        global::System.ComponentModel.IContainer components;
    }
}
