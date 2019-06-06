using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x020000A4 RID: 164
public partial class ZStatus : Form
{
    // Token: 0x1700028E RID: 654
    // (set) Token: 0x0600070D RID: 1805 RVA: 0x00033CFC File Offset: 0x00031EFC
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

    // Token: 0x1700028F RID: 655
    // (set) Token: 0x0600070E RID: 1806 RVA: 0x00033D40 File Offset: 0x00031F40
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

    // Token: 0x0600070F RID: 1807 RVA: 0x00033D81 File Offset: 0x00031F81
    public ZStatus()
    {
        this.InitializeComponent();
    }
}
