namespace Hero_Designer
{

    public partial class frmEnhMiniPick : global::System.Windows.Forms.Form
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
            this.lbList = new global::System.Windows.Forms.ListBox();
            this.btnOK = new global::System.Windows.Forms.Button();
            this.lblMessage = new global::System.Windows.Forms.Label();
            base.SuspendLayout();
            global::System.Drawing.Point point = new global::System.Drawing.Point(4, 44);
            this.lbList.Location = point;
            this.lbList.Name = "lbList";
            global::System.Drawing.Size size = new global::System.Drawing.Size(172, 160);
            this.lbList.Size = size;
            this.lbList.TabIndex = 0;
            this.btnOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
            point = new global::System.Drawing.Point(8, 212);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            size = new global::System.Drawing.Size(168, 24);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            point = new global::System.Drawing.Point(4, 0);
            this.lblMessage.Location = point;
            this.lblMessage.Name = "lblMessage";
            size = new global::System.Drawing.Size(176, 40);
            this.lblMessage.Size = size;
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Please select an item from the list below and click OK";
            this.lblMessage.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            base.AcceptButton = this.btnOK;
            size = new global::System.Drawing.Size(5, 13);
            this.AutoScaleBaseSize = size;
            base.CancelButton = this.btnOK;
            size = new global::System.Drawing.Size(182, 244);
            base.ClientSize = size;
            base.ControlBox = false;
            base.Controls.Add(this.lblMessage);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.lbList);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEnhMiniPick";
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Details";
            base.ResumeLayout(false);
        }
        global::System.ComponentModel.IContainer components;
    }
}
