using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{

    public partial class frmZStatus : Form
    {

    
    
        internal virtual Label lblStatus1
        {
            get
            {
                return this._lblStatus1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblStatus1 = value;
            }
        }


    
    
        internal virtual Label lblStatus2
        {
            get
            {
                return this._lblStatus2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblStatus2 = value;
            }
        }


    
    
        internal virtual Label lblTitle
        {
            get
            {
                return this._lblTitle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblTitle = value;
            }
        }


    
    
        internal virtual PictureBox PictureBox1
        {
            get
            {
                return this._PictureBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._PictureBox1 = value;
            }
        }


        public frmZStatus()
        {
            base.VisibleChanged += this.frmZStatus_VisibleChanged;
            this.InitializeComponent();
        }


        private void frmZStatus_VisibleChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }


        public void SetText1(string text)
        {
            if (this.lblStatus1.InvokeRequired)
            {
                frmZStatus.SetTextCallback method = new frmZStatus.SetTextCallback(this.SetText1);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                this.lblStatus1.Text = text;
            }
        }


        public void SetText2(string text)
        {
            if (this.lblStatus2.InvokeRequired)
            {
                frmZStatus.SetTextCallback method = new frmZStatus.SetTextCallback(this.SetText1);
                base.Invoke(method, new object[]
                {
                    text
                });
            }
            else
            {
                this.lblStatus2.Text = text;
            }
        }


        [AccessedThroughProperty("lblStatus1")]
        private Label _lblStatus1;


        [AccessedThroughProperty("lblStatus2")]
        private Label _lblStatus2;


        [AccessedThroughProperty("lblTitle")]
        private Label _lblTitle;


        [AccessedThroughProperty("PictureBox1")]
        private PictureBox _PictureBox1;


        // (Invoke) Token: 0x060013CC RID: 5068
        public delegate void SetTextCallback(string text);
    }
}
