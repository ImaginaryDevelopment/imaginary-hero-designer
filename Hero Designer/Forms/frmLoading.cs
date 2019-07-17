
using Base;
using Base.IO_Classes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmLoading : Form, IMessager
    {
        Label Label1;
        PictureBox PictureBox1;
        Timer tmrOpacity;

        public frmLoading()
        {
            this.InitializeComponent();
            this.Text = nameof(frmLoading);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.PictureBox1.Image = (System.Drawing.Image)componentResourceManager.GetObject("PictureBox1.Image");
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmLoading);
        }

        public void SetMessage(string text)
        {
            if (this.Label1.InvokeRequired)
            {
                Action invoke = () => this.SetMessage(text);
                this.Invoke(invoke);
            }
            else
            {
                if (!(this.Label1.Text != text))
                    return;
                this.Label1.Text = text;
                this.Label1.Refresh();
                this.Refresh();
            }
        }

        static void ShowPrettyError(string title, string text, Action onLabelClick = null)
        {
            var frm = new frmLoading();
            frm.Label1.Text = text;
            frm.Text = title;
            if (onLabelClick != null)
            {
                frm.Label1.Font = new Font(frm.Label1.Font.Name, frm.Label1.Font.SizeInPoints, FontStyle.Underline);
                frm.Label1.Click += (sender, e) => onLabelClick();
            }
            frm.Label1.Dock = DockStyle.Fill;
            frm.Size = new Size(frm.Size.Width, frm.Size.Height + 100);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.ShowDialog();
        }

        public static void ShowLinkDialog(string title, string text, string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException("url value not found", nameof(url));
            if (!url.StartsWith("http")) throw new ArgumentException("url must be http, for security purposes");
            // hosts file could still cause this to be a problem, but if they have access there, security is gone anyhow
            if (!char.IsLetter(url.After("://")[0])) throw new ArgumentException("url must be named, for security purposes");
            ShowPrettyError(title, text, () => Process.Start(url));
        }

        void tmrOpacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.05;
            else
                this.tmrOpacity.Enabled = false;
        }
    }
}