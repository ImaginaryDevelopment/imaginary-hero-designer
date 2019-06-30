
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public partial class ZStatus : Form
{

    internal Label lblStatus2;
    internal Label lblStatus1;
    internal Label lblTitle;

    public string StatusText1
    {
        set
        {
            if (!(value != this.lblStatus1.Text))
                return;
            this.lblStatus1.Text = value;
            this.lblStatus1.Refresh();
        }
    }

    public string StatusText2
    {
        set
        {
            if (!(value != this.lblStatus2.Text))
                return;
            this.lblStatus2.Text = value;
            this.lblStatus2.Refresh();
        }
    }

    public ZStatus()
    {
        this.InitializeComponent();
    }
}