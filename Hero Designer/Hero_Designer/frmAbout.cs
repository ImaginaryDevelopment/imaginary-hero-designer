using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public partial class frmAbout : Form
    {

        // (get) Token: 0x06000194 RID: 404 RVA: 0x00020FF4 File Offset: 0x0001F1F4
        // (set) Token: 0x06000195 RID: 405 RVA: 0x0002100C File Offset: 0x0001F20C
        internal virtual ImageButton ibClose
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
                {
                    this._ibClose.ButtonClicked -= clickedEventHandler;
                }
                this._ibClose = value;
                if (this._ibClose != null)
                {
                    this._ibClose.ButtonClicked += clickedEventHandler;
                }
            }
        }


        // (get) Token: 0x06000196 RID: 406 RVA: 0x00021068 File Offset: 0x0001F268
        // (set) Token: 0x06000197 RID: 407 RVA: 0x00021080 File Offset: 0x0001F280
        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
        }


        // (get) Token: 0x06000198 RID: 408 RVA: 0x0002108C File Offset: 0x0001F28C
        // (set) Token: 0x06000199 RID: 409 RVA: 0x000210A4 File Offset: 0x0001F2A4
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }


        // (get) Token: 0x0600019A RID: 410 RVA: 0x000210B0 File Offset: 0x0001F2B0
        // (set) Token: 0x0600019B RID: 411 RVA: 0x000210C8 File Offset: 0x0001F2C8
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }


        // (get) Token: 0x0600019C RID: 412 RVA: 0x000210D4 File Offset: 0x0001F2D4
        // (set) Token: 0x0600019D RID: 413 RVA: 0x000210EC File Offset: 0x0001F2EC
        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }


        // (get) Token: 0x0600019E RID: 414 RVA: 0x000210F8 File Offset: 0x0001F2F8
        // (set) Token: 0x0600019F RID: 415 RVA: 0x00021110 File Offset: 0x0001F310
        internal virtual Label lblDBDate
        {
            get
            {
                return this._lblDBDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDBDate = value;
            }
        }


        // (get) Token: 0x060001A0 RID: 416 RVA: 0x0002111C File Offset: 0x0001F31C
        // (set) Token: 0x060001A1 RID: 417 RVA: 0x00021134 File Offset: 0x0001F334
        internal virtual Label lblDBIssue
        {
            get
            {
                return this._lblDBIssue;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDBIssue = value;
            }
        }


        // (get) Token: 0x060001A2 RID: 418 RVA: 0x00021140 File Offset: 0x0001F340
        // (set) Token: 0x060001A3 RID: 419 RVA: 0x00021158 File Offset: 0x0001F358
        internal virtual Label lblDonate
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
                {
                    this._lblDonate.Click -= eventHandler;
                }
                this._lblDonate = value;
                if (this._lblDonate != null)
                {
                    this._lblDonate.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060001A4 RID: 420 RVA: 0x000211B4 File Offset: 0x0001F3B4
        // (set) Token: 0x060001A5 RID: 421 RVA: 0x000211CC File Offset: 0x0001F3CC
        internal virtual Label lblEmail
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
                {
                    this._lblEmail.Click -= eventHandler;
                }
                this._lblEmail = value;
                if (this._lblEmail != null)
                {
                    this._lblEmail.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060001A6 RID: 422 RVA: 0x00021228 File Offset: 0x0001F428
        // (set) Token: 0x060001A7 RID: 423 RVA: 0x00021240 File Offset: 0x0001F440
        internal virtual Label lblLegal
        {
            get
            {
                return this._lblLegal;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblLegal = value;
            }
        }


        // (get) Token: 0x060001A8 RID: 424 RVA: 0x0002124C File Offset: 0x0001F44C
        // (set) Token: 0x060001A9 RID: 425 RVA: 0x00021264 File Offset: 0x0001F464
        internal virtual Label lblVersion
        {
            get
            {
                return this._lblVersion;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblVersion = value;
            }
        }


        // (get) Token: 0x060001AA RID: 426 RVA: 0x00021270 File Offset: 0x0001F470
        // (set) Token: 0x060001AB RID: 427 RVA: 0x00021288 File Offset: 0x0001F488
        internal virtual Label lblWebPage
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
                {
                    this._lblWebPage.Click -= eventHandler;
                }
                this._lblWebPage = value;
                if (this._lblWebPage != null)
                {
                    this._lblWebPage.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060001AC RID: 428 RVA: 0x000212E4 File Offset: 0x0001F4E4
        // (set) Token: 0x060001AD RID: 429 RVA: 0x000212FC File Offset: 0x0001F4FC
        internal virtual PictureBox pbBackground
        {
            get
            {
                return this._pbBackground;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.PictureBox1_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.PictureBox1_MouseDown);
                if (this._pbBackground != null)
                {
                    this._pbBackground.MouseMove -= mouseEventHandler;
                    this._pbBackground.MouseDown -= mouseEventHandler2;
                }
                this._pbBackground = value;
                if (this._pbBackground != null)
                {
                    this._pbBackground.MouseMove += mouseEventHandler;
                    this._pbBackground.MouseDown += mouseEventHandler2;
                }
            }
        }


        // (get) Token: 0x060001AE RID: 430 RVA: 0x00021380 File Offset: 0x0001F580
        // (set) Token: 0x060001AF RID: 431 RVA: 0x00021398 File Offset: 0x0001F598
        internal virtual ToolTip tTip
        {
            get
            {
                return this._tTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tTip = value;
            }
        }


        public frmAbout()
        {
            base.Load += this.frmAbout_Load;
            this.InitializeComponent();
        }


        private void frmAbout_Load(object sender, EventArgs e)
        {
            string str = "http://www.cohplanner.com/".Replace("http://", "");
            if (str.EndsWith("/") & str.IndexOf("/") == str.Length - 1)
            {
                str = str.Substring(0, str.Length - 1);
            }
            this.lblWebPage.Text = str;
            this.lblVersion.Text = Strings.Format(MainModule.MidsController.HeroDesignerVersion, "#0.0####");
            this.lblDBIssue.Text = Conversions.ToString(DatabaseAPI.Database.Issue);
            this.lblDBDate.Text = Strings.Format(DatabaseAPI.Database.Version, "#0.0####") + " (" + Strings.Format(DatabaseAPI.Database.Date, "dd/MMM/yyyy") + ")";
        }


        private void ibClose_ButtonClicked()
        {
            base.Close();
        }


        private void lblDonate_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.Donate();
        }


        private void lblEmail_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.MailMe();
        }


        private void lblWebPage_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.GoToCoHPlanner();
        }


        private void pbPayPal_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.Donate();
        }


        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-e.X, -e.Y);
        }


        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
                base.Location = mousePosition;
            }
        }


        [AccessedThroughProperty("ibClose")]
        private ImageButton _ibClose;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("Label5")]
        private Label _Label5;


        [AccessedThroughProperty("lblDBDate")]
        private Label _lblDBDate;


        [AccessedThroughProperty("lblDBIssue")]
        private Label _lblDBIssue;


        [AccessedThroughProperty("lblDonate")]
        private Label _lblDonate;


        [AccessedThroughProperty("lblEmail")]
        private Label _lblEmail;


        [AccessedThroughProperty("lblLegal")]
        private Label _lblLegal;


        [AccessedThroughProperty("lblVersion")]
        private Label _lblVersion;


        [AccessedThroughProperty("lblWebPage")]
        private Label _lblWebPage;


        [AccessedThroughProperty("pbBackground")]
        private PictureBox _pbBackground;


        [AccessedThroughProperty("tTip")]
        private ToolTip _tTip;


        private Point mouse_offset;
    }
}
