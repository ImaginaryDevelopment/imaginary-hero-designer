using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000A4 RID: 164
public partial class ZStatus : Form
{

    
    public string StatusText1
    {
        set
        {
            if (value != this.lblStatus1.Text)
            {
                this.lblStatus1.Text = value;
                this.lblStatus1.Refresh();
            }
        }
    }


    
    public string StatusText2
    {
        set
        {
            if (value != this.lblStatus2.Text)
            {
                this.lblStatus2.Text = value;
                this.lblStatus2.Refresh();
            }
        }
    }


    public ZStatus()
    {
        this.InitializeComponent();
    }
}
