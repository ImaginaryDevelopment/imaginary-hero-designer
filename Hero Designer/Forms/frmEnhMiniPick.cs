
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmEnhMiniPick : Form
    {
        Button btnOK;

        ListBox _lbList;
        Label lblMessage;

        IContainer components;

        internal ListBox lbList
        {
            get => _lbList;
            private set => _lbList = value;
        }

        public frmEnhMiniPick()
        {
            this.Load += new EventHandler(this.frmEnhMez_Load);
            this.InitializeComponent();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void frmEnhMez_Load(object sender, EventArgs e)

        {
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.lbList = new ListBox();
            this.btnOK = new Button();
            this.lblMessage = new Label();
            this.SuspendLayout();
            Point point = new Point(4, 44);
            this.lbList.Location = point;
            this.lbList.Name = "lbList";
            Size size = new Size(172, 160);
            this.lbList.Size = size;
            this.lbList.TabIndex = 0;
            this.btnOK.DialogResult = DialogResult.OK;
            point = new Point(8, 212);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            size = new Size(168, 24);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            point = new Point(4, 0);
            this.lblMessage.Location = point;
            this.lblMessage.Name = "lblMessage";
            size = new Size(176, 40);
            this.lblMessage.Size = size;
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Please select an item from the list below and click OK";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.AcceptButton = (IButtonControl)this.btnOK;
            size = new Size(5, 13);
            this.AutoScaleBaseSize = size;
            this.CancelButton = (IButtonControl)this.btnOK;
            size = new Size(182, 244);
            this.ClientSize = size;
            this.ControlBox = false;
            this.Controls.Add((Control)this.lblMessage);
            this.Controls.Add((Control)this.btnOK);
            this.Controls.Add((Control)this.lbList);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmEnhMiniPick);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Details";
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.btnOK.Click += btnOK_Click;
                  
                  // lbList events
                  this.lbList.DoubleClick += lbList_DoubleClick;
                  this.lbList.SelectedIndexChanged += lbList_SelectedIndexChanged;
                  
              }
              // finished with events
            this.ResumeLayout(false);
        }

        void lbList_DoubleClick(object sender, EventArgs e)

        {
            this.btnOK_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void lbList_SelectedIndexChanged(object sender, EventArgs e)

        {
        }
    }
}
