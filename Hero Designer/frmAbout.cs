
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
        [AccessedThroughProperty("ibClose")]
        ImageButton _ibClose;
        Label Label1;
        Label Label3;
        Label Label4;
        Label Label5;
        Label lblDBDate;
        Label lblDBIssue;

        [AccessedThroughProperty("lblDonate")]
        Label _lblDonate;

        [AccessedThroughProperty("lblEmail")]
        Label _lblEmail;
        Label lblLegal;
        Label lblVersion;

        [AccessedThroughProperty("lblWebPage")]
        Label _lblWebPage;

        [AccessedThroughProperty("pbBackground")]
        PictureBox _pbBackground;
        ToolTip tTip;

        IContainer components;

        Point mouse_offset;


        internal ImageButton ibClose
        {
            get
            {
                return this._ibClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
                if (this._ibClose != null)
                    this._ibClose.ButtonClicked -= clickedEventHandler;
                this._ibClose = value;
                if (this._ibClose == null)
                    return;
                this._ibClose.ButtonClicked += clickedEventHandler;
            }
        }







        Label lblDonate
        {
            get
            {
                return this._lblDonate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lblDonate_Click);
                if (this._lblDonate != null)
                    this._lblDonate.Click -= eventHandler;
                this._lblDonate = value;
                if (this._lblDonate == null)
                    return;
                this._lblDonate.Click += eventHandler;
            }
        }

        Label lblEmail
        {
            get
            {
                return this._lblEmail;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lblEmail_Click);
                if (this._lblEmail != null)
                    this._lblEmail.Click -= eventHandler;
                this._lblEmail = value;
                if (this._lblEmail == null)
                    return;
                this._lblEmail.Click += eventHandler;
            }
        }



        Label lblWebPage
        {
            get
            {
                return this._lblWebPage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lblWebPage_Click);
                if (this._lblWebPage != null)
                    this._lblWebPage.Click -= eventHandler;
                this._lblWebPage = value;
                if (this._lblWebPage == null)
                    return;
                this._lblWebPage.Click += eventHandler;
            }
        }

        PictureBox pbBackground
        {
            get
            {
                return this._pbBackground;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.PictureBox1_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.PictureBox1_MouseDown);
                if (this._pbBackground != null)
                {
                    this._pbBackground.MouseMove -= mouseEventHandler1;
                    this._pbBackground.MouseDown -= mouseEventHandler2;
                }
                this._pbBackground = value;
                if (this._pbBackground == null)
                    return;
                this._pbBackground.MouseMove += mouseEventHandler1;
                this._pbBackground.MouseDown += mouseEventHandler2;
            }
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
