
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
    public partial class frmReadme : Form
    {
        ImageButton btnClose;
        PictureBox pbBackground;
        PictureBox pbBottom;
        RichTextBox rtfRead;
        int btnY;
        bool Loading;
        Point mouse_offset;
        string myFile;
        int rtH;
        int rtW;

        internal ImageButton BtnClose
        {
            get => btnClose;
            private set => btnClose = value;
        }

        public frmReadme(string iFile)
        {
            this.Loading = true;
            this.myFile = "";
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmReadme));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.pbBottom.Image = (System.Drawing.Image)componentResourceManager.GetObject("pbBottom.Image");
            this.pbBackground.Image = (System.Drawing.Image)componentResourceManager.GetObject("pbBackground.Image");
            this.myFile = iFile;
        }

        void All_MouseMove(MouseEventArgs e)

        {
            if (e.Button != MouseButtons.Left)
                return;
            Point mousePosition = Control.MousePosition;
            mousePosition.Offset(this.mouse_offset.X, this.mouse_offset.Y);
            this.Location = mousePosition;
        }

        void btnClose_ButtonClicked()
        {
            this.Close();
        }

        void btnClose_Load(object sender, EventArgs e)
        {
        }

        void frmReadme_Load(object sender, EventArgs e)

        {
            this.rtW = this.Size.Width - (this.rtfRead.Width + this.rtfRead.Left);
            this.rtH = this.Size.Height - (this.rtfRead.Height + this.rtfRead.Top);
            this.BtnClose.KnockoutLocationPoint = new System.Drawing.Point(this.BtnClose.Left, this.BtnClose.Top - this.pbBottom.Top);
            this.BtnClose.KnockoutPB = this.pbBottom;
            this.BtnClose.Refresh();
            this.btnY = this.Size.Height - this.BtnClose.Top;
            try
            {
                this.rtfRead.LoadFile(this.myFile);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                this.rtfRead.Text = "Unable to find " + this.myFile + "!";
                ProjectData.ClearProjectError();
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
            if (this.Loading)
                return;
            RichTextBox rtfRead1 = this.rtfRead;
            Size size = this.Size;
            int num1 = size.Height - (this.rtH + this.rtfRead.Top);
            rtfRead1.Height = num1;
            RichTextBox rtfRead2 = this.rtfRead;
            size = this.Size;
            int num2 = size.Width - (this.rtW + this.rtfRead.Left);
            rtfRead2.Width = num2;
            ImageButton btnClose1 = this.BtnClose;
            size = this.Size;
            int num3 = size.Height - this.btnY;
            btnClose1.Top = num3;
            ImageButton btnClose2 = this.BtnClose;
            size = this.Size;
            int num4 = (int)Math.Round((double)(size.Width - this.BtnClose.Width) / 2.0);
            btnClose2.Left = num4;
        }

        [DebuggerStepThrough]

        void pbBackground_Click(object sender, EventArgs e)

        {
        }

        void pbBackground_MouseDown(object sender, MouseEventArgs e)

        {
            this.mouse_offset = new System.Drawing.Point(-e.X, -e.Y);
        }

        void pbBackground_MouseMove(object sender, MouseEventArgs e)

        {
            this.All_MouseMove(e);
        }

        void pbBottom_MouseDown(object sender, MouseEventArgs e)

        {
            this.mouse_offset = new System.Drawing.Point(-e.X, -this.pbBottom.Top + -e.Y);
        }

        void pbBottom_MouseMove(object sender, MouseEventArgs e)

        {
            this.All_MouseMove(e);
        }
    }
}