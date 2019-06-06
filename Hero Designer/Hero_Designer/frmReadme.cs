using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{
    public partial class frmReadme : Form
    {
    
        internal virtual ImageButton btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClose_Load);
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.btnClose_ButtonClicked);
                if (this._btnClose != null)
                {
                    this._btnClose.Load -= eventHandler;
                    this._btnClose.ButtonClicked -= clickedEventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.Load += eventHandler;
                    this._btnClose.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual PictureBox pbBackground
        {
            get
            {
                return this._pbBackground;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbBackground_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbBackground_MouseDown);
                EventHandler eventHandler = new EventHandler(this.pbBackground_Click);
                if (this._pbBackground != null)
                {
                    this._pbBackground.MouseMove -= mouseEventHandler;
                    this._pbBackground.MouseDown -= mouseEventHandler2;
                    this._pbBackground.Click -= eventHandler;
                }
                this._pbBackground = value;
                if (this._pbBackground != null)
                {
                    this._pbBackground.MouseMove += mouseEventHandler;
                    this._pbBackground.MouseDown += mouseEventHandler2;
                    this._pbBackground.Click += eventHandler;
                }
            }
        }
        internal virtual PictureBox pbBottom
        {
            get
            {
                return this._pbBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbBottom_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbBottom_MouseDown);
                if (this._pbBottom != null)
                {
                    this._pbBottom.MouseMove -= mouseEventHandler;
                    this._pbBottom.MouseDown -= mouseEventHandler2;
                }
                this._pbBottom = value;
                if (this._pbBottom != null)
                {
                    this._pbBottom.MouseMove += mouseEventHandler;
                    this._pbBottom.MouseDown += mouseEventHandler2;
                }
            }
        }
        internal virtual RichTextBox rtfRead
        {
            get
            {
                return this._rtfRead;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rtfRead = value;
            }
        }
        public frmReadme(string iFile)
        {
            base.MouseDown += this.frmReadme_MouseDown;
            base.MouseMove += this.frmReadme_MouseMove;
            base.Load += this.frmReadme_Load;
            base.Resize += this.frmReadme_Resize;
            this.Loading = true;
            this.myFile = "";
            this.InitializeComponent();
            this.myFile = iFile;
        }
        void All_MouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
                base.Location = mousePosition;
            }
        }
        void btnClose_ButtonClicked()
        {
            base.Close();
        }
        void btnClose_Load(object sender, EventArgs e)
        {
        }
        void frmReadme_Load(object sender, EventArgs e)
        {
            this.rtW = base.Size.Width - (this.rtfRead.Width + this.rtfRead.Left);
            this.rtH = base.Size.Height - (this.rtfRead.Height + this.rtfRead.Top);
            Point knockoutLocationPoint = new Point(this.btnClose.Left, this.btnClose.Top - this.pbBottom.Top);
            this.btnClose.KnockoutLocationPoint = knockoutLocationPoint;
            this.btnClose.KnockoutPB = this.pbBottom;
            this.btnClose.Refresh();
            this.btnY = base.Size.Height - this.btnClose.Top;
            try
            {
                this.rtfRead.LoadFile(this.myFile);
            }
            catch (Exception ex)
            {
                this.rtfRead.Text = "Unable to find " + this.myFile + "!";
            }
            this.Loading = false;
        }
        void frmReadme_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbBackground_MouseDown(RuntimeHelpers.GetObjectValue(sender), e);
        }
        void frmReadme_MouseMove(object sender, MouseEventArgs e)
        {
            this.All_MouseMove(e);
        }
        void frmReadme_Resize(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.rtfRead.Height = base.Size.Height - (this.rtH + this.rtfRead.Top);
                this.rtfRead.Width = base.Size.Width - (this.rtW + this.rtfRead.Left);
                this.btnClose.Top = base.Size.Height - this.btnY;
                this.btnClose.Left = (int)Math.Round((double)(base.Size.Width - this.btnClose.Width) / 2.0);
            }
        }
        void pbBackground_Click(object sender, EventArgs e)
        {
        }
        void pbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-e.X, -e.Y);
        }
        void pbBackground_MouseMove(object sender, MouseEventArgs e)
        {
            this.All_MouseMove(e);
        }
        void pbBottom_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouse_offset = new Point(-e.X, -this.pbBottom.Top + -e.Y);
        }
        void pbBottom_MouseMove(object sender, MouseEventArgs e)
        {
            this.All_MouseMove(e);
        }
        [AccessedThroughProperty("btnClose")]
        ImageButton _btnClose;
        [AccessedThroughProperty("pbBackground")]
        PictureBox _pbBackground;
        [AccessedThroughProperty("pbBottom")]
        PictureBox _pbBottom;
        [AccessedThroughProperty("rtfRead")]
        RichTextBox _rtfRead;
        int btnY;
        bool Loading;
        Point mouse_offset;
        string myFile;
        int rtH;
        int rtW;
    }
}
