
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class FrmInputLevel : Form
    {
        Button btnOK;
        Label Label1;

        NumericUpDown udLevel;

        bool LongFormat;

        bool Mode2;

        frmMain myparent;

        public FrmInputLevel(ref frmMain iParent, bool iLF, bool iMode2)
        {
            this.Load += new EventHandler(this.FrmInputLevel_Load);
            this.InitializeComponent();
            this.myparent = iParent;
            this.LongFormat = iLF;
            this.Mode2 = iMode2;
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            int num;
            if (Conversion.Val(this.udLevel.Text) != Convert.ToDouble(this.udLevel.Value))
            {
                num = (int)Math.Round(Conversion.Val(this.udLevel.Text));
                if (Decimal.Compare(new Decimal(num), this.udLevel.Minimum) < 0)
                    num = Convert.ToInt32(this.udLevel.Minimum);
                if (Decimal.Compare(new Decimal(num), this.udLevel.Maximum) > 0)
                    num = Convert.ToInt32(this.udLevel.Maximum);
            }
            else
                num = Convert.ToInt32(this.udLevel.Value);
            if (this.LongFormat)
                this.myparent.smlRespecLong(num - 1, this.Mode2);
            else
                this.myparent.smlRespecShort(num - 1, this.Mode2);
            this.Close();
        }

        void FrmInputLevel_Load(object sender, EventArgs e)
        {
        }

        [DebuggerStepThrough]

        void udLevel_Leave(object sender, EventArgs e)
        {
            this.udLevel.Validate();
        }
    }
}