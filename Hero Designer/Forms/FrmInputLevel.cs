
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Hero_Designer
{
    public partial class FrmInputLevel : Form
    {

        bool longFormat;

        bool mode2;

        frmMain myparent;

        public FrmInputLevel(frmMain iParent, bool iLF, bool iMode2)
        {
            InitializeComponent();
            Name = nameof(FrmInputLevel);
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmInputLevel));
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            myparent = iParent;
            longFormat = iLF;
            mode2 = iMode2;
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            int num;
            if (Conversion.Val(udLevel.Text) != Convert.ToDouble(udLevel.Value))
            {
                num = (int)Math.Round(Conversion.Val(udLevel.Text));
                if (Decimal.Compare(new Decimal(num), udLevel.Minimum) < 0)
                    num = Convert.ToInt32(udLevel.Minimum);
                if (Decimal.Compare(new Decimal(num), udLevel.Maximum) > 0)
                    num = Convert.ToInt32(udLevel.Maximum);
            }
            else
                num = Convert.ToInt32(udLevel.Value);
            if (longFormat)
                myparent.smlRespecLong(num - 1, mode2);
            else
                myparent.smlRespecShort(num - 1, mode2);
            Close();
        }

        void FrmInputLevel_Load(object sender, EventArgs e)
        {
        }

        void udLevel_Leave(object sender, EventArgs e)
        {
            udLevel.Validate();
        }
    }
}