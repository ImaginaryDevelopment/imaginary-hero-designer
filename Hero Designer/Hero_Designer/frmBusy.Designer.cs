using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmBusy : global::System.Windows.Forms.Form
    {

        System.ComponentModel.IContainer components = null;
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

        #region Windows Form Designer generated code
        void InitializeComponent()
        {
            var componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Hero_Designer.frmBusy));
            this.Message = new global::System.Windows.Forms.Label();
            base.SuspendLayout();
            global::System.Drawing.Point location = new System.Drawing.Point(12, 9);
            this.Message.Location = location;
            this.Message.Name = "Message";
            global::System.Drawing.Size size = new System.Drawing.Size(381, 61);
            this.Message.Size = size;
            this.Message.TabIndex = 0;
            this.Message.Text = "Busy";
            this.Message.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
            base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
            size = new global::System.Drawing.Size(405, 79);
            base.ClientSize = size;
            base.ControlBox = false;
            base.Controls.Add(this.Message);
            this.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
            base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmBusy";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Working...";
            base.TopMost = true;
            base.ResumeLayout(false);
        }

        #endregion

        [AccessedThroughProperty("Message")]
        Label _Message;

        internal virtual Label Message
        {
            get
            {
                return this._Message;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Message = value;
            }
        }
    }
}
