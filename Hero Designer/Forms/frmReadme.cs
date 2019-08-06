
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using midsControls;

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
        readonly string myFile;
        int rtH;
        int rtW;

        internal ImageButton BtnClose
        {
            get => btnClose;
            private set => btnClose = value;
        }

        public frmReadme(string iFile)
        {
            Loading = true;
            myFile = "";
            InitializeComponent();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmReadme));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            pbBottom.Image = (Image)componentResourceManager.GetObject("pbBottom.Image");
            pbBackground.Image = (Image)componentResourceManager.GetObject("pbBackground.Image");
            myFile = iFile;
        }

        void All_MouseMove(MouseEventArgs e)

        {
            if (e.Button != MouseButtons.Left)
                return;
            Point mousePosition = MousePosition;
            mousePosition.Offset(mouse_offset.X, mouse_offset.Y);
            Location = mousePosition;
        }

        void btnClose_ButtonClicked()
        {
            Close();
        }

        void btnClose_Load(object sender, EventArgs e)
        {
        }

        void frmReadme_Load(object sender, EventArgs e)

        {
            rtW = Size.Width - (rtfRead.Width + rtfRead.Left);
            rtH = Size.Height - (rtfRead.Height + rtfRead.Top);
            BtnClose.KnockoutLocationPoint = new Point(BtnClose.Left, BtnClose.Top - pbBottom.Top);
            BtnClose.KnockoutPB = pbBottom;
            BtnClose.Refresh();
            btnY = Size.Height - BtnClose.Top;
            try
            {
                rtfRead.LoadFile(myFile);
            }
            catch (Exception ex)
            {
                rtfRead.Text = "Unable to find " + myFile + "!";
            }
            Loading = false;
        }

        void frmReadme_MouseDown(object sender, MouseEventArgs e)

        {
            pbBackground_MouseDown(RuntimeHelpers.GetObjectValue(sender), e);
        }

        void frmReadme_MouseMove(object sender, MouseEventArgs e)

        {
            All_MouseMove(e);
        }

        void frmReadme_Resize(object sender, EventArgs e)

        {
            if (Loading)
                return;
            RichTextBox rtfRead1 = rtfRead;
            Size size = Size;
            int num1 = size.Height - (rtH + rtfRead.Top);
            rtfRead1.Height = num1;
            RichTextBox rtfRead2 = rtfRead;
            size = Size;
            int num2 = size.Width - (rtW + rtfRead.Left);
            rtfRead2.Width = num2;
            ImageButton btnClose1 = BtnClose;
            size = Size;
            int num3 = size.Height - btnY;
            btnClose1.Top = num3;
            ImageButton btnClose2 = BtnClose;
            size = Size;
            int num4 = (int)Math.Round((size.Width - BtnClose.Width) / 2.0);
            btnClose2.Left = num4;
        }

        [DebuggerStepThrough]

        void pbBackground_Click(object sender, EventArgs e)

        {
        }

        void pbBackground_MouseDown(object sender, MouseEventArgs e)

        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        void pbBackground_MouseMove(object sender, MouseEventArgs e)

        {
            All_MouseMove(e);
        }

        void pbBottom_MouseDown(object sender, MouseEventArgs e)

        {
            mouse_offset = new Point(-e.X, -pbBottom.Top + -e.Y);
        }

        void pbBottom_MouseMove(object sender, MouseEventArgs e)

        {
            All_MouseMove(e);
        }
    }
}