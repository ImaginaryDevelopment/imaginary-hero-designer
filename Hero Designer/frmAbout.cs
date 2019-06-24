
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmAbout : Form
    {
        ImageButton _ibClose;
        Label Label1;
        Label Label3;
        Label Label4;
        Label Label5;
        Label lblDBDate;
        Label lblDBIssue;

        Label lblDonate;

        Label lblEmail;
        Label lblLegal;
        Label lblVersion;

        Label lblWebPage;

        PictureBox pbBackground;
        ToolTip tTip;

        IContainer components;

        Point mouse_offset;

        internal ImageButton ibClose
        {
            get => _ibClose;
            private set => _ibClose = value;
        }







        public frmAbout()
        {
            this.Load += new EventHandler(this.frmAbout_Load);
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void frmAbout_Load(object sender, EventArgs e)

        {
            string str = "http://www.cohplanner.com/".Replace("http://", "");
            if (str.EndsWith("/") & str.IndexOf("/") == str.Length - 1)
                str = str.Substring(0, str.Length - 1);
            this.lblWebPage.Text = str;
            this.lblVersion.Text = Strings.Format((object)MainModule.MidsController.HeroDesignerVersion, "#0.0####");
            this.lblDBIssue.Text = Conversions.ToString(DatabaseAPI.Database.Issue);
            this.lblDBDate.Text = Strings.Format((object)DatabaseAPI.Database.Version, "#0.0####") + " (" + Strings.Format((object)DatabaseAPI.Database.Date, "dd/MMM/yyyy") + ")";
        }

        void ibClose_ButtonClicked()

        {
            this.Close();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.SuspendLayout();
            //
            // frmAbout
            //
            this.ClientSize = new System.Drawing.Size(511, 372);
            this.Name = "frmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load_1);
            this.ResumeLayout(false);
              //adding events
              if(!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
              {
                  this.ibClose.ButtonClicked += ibClose_ButtonClicked;
                  this.lblDonate.Click += lblDonate_Click;
                  this.lblEmail.Click += lblEmail_Click;
                  this.lblWebPage.Click += lblWebPage_Click;
                  
                  // pbBackground events
                  this.pbBackground.MouseMove += PictureBox1_MouseMove;
                  this.pbBackground.MouseDown += PictureBox1_MouseDown;
                  
              }
              // finished with events

        }

        void lblDonate_Click(object sender, EventArgs e)

        {
            clsXMLUpdate.Donate();
        }

        void lblEmail_Click(object sender, EventArgs e)

        {
            clsXMLUpdate.MailMe();
        }

        void lblWebPage_Click(object sender, EventArgs e)

        {
            clsXMLUpdate.GoToCoHPlanner();
        }

        void pbPayPal_Click(object sender, EventArgs e)

        {
            clsXMLUpdate.Donate();
        }

        void PictureBox1_MouseDown(object sender, MouseEventArgs e)

        {
            this.mouse_offset = new Point(-e.X, -e.Y);
        }

        void PictureBox1_MouseMove(object sender, MouseEventArgs e)

        {
            if (e.Button != MouseButtons.Left)
                return;
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
            this.Location = mousePosition;
        }

        void FrmAbout_Load_1(object sender, EventArgs e)

        {

        }
    }
}
