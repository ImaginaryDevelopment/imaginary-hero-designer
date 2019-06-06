using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class FrmInputLevel : Form
    {

        // (get) Token: 0x06000CA0 RID: 3232 RVA: 0x0007DD54 File Offset: 0x0007BF54
        // (set) Token: 0x06000CA1 RID: 3233 RVA: 0x0007DD6C File Offset: 0x0007BF6C
        internal virtual Button btnOK
        {
            get
            {
                return this._btnOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnOK_Click);
                if (this._btnOK != null)
                {
                    this._btnOK.Click -= eventHandler;
                }
                this._btnOK = value;
                if (this._btnOK != null)
                {
                    this._btnOK.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000CA2 RID: 3234 RVA: 0x0007DDC8 File Offset: 0x0007BFC8
        // (set) Token: 0x06000CA3 RID: 3235 RVA: 0x0007DDE0 File Offset: 0x0007BFE0
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


        // (get) Token: 0x06000CA4 RID: 3236 RVA: 0x0007DDEC File Offset: 0x0007BFEC
        // (set) Token: 0x06000CA5 RID: 3237 RVA: 0x0007DE04 File Offset: 0x0007C004
        internal virtual NumericUpDown udLevel
        {
            get
            {
                return this._udLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udLevel_Leave);
                if (this._udLevel != null)
                {
                    this._udLevel.Leave -= eventHandler;
                }
                this._udLevel = value;
                if (this._udLevel != null)
                {
                    this._udLevel.Leave += eventHandler;
                }
            }
        }


        public FrmInputLevel(ref frmMain iParent, bool iLF, bool iMode2)
        {
            base.Load += this.FrmInputLevel_Load;
            this.InitializeComponent();
            this.myparent = iParent;
            this.LongFormat = iLF;
            this.Mode2 = iMode2;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            int num;
            if (Conversion.Val(this.udLevel.Text) != Convert.ToDouble(this.udLevel.Value))
            {
                num = (int)Math.Round(Conversion.Val(this.udLevel.Text));
                if (decimal.Compare(new decimal(num), this.udLevel.Minimum) < 0)
                {
                    num = Convert.ToInt32(this.udLevel.Minimum);
                }
                if (decimal.Compare(new decimal(num), this.udLevel.Maximum) > 0)
                {
                    num = Convert.ToInt32(this.udLevel.Maximum);
                }
            }
            else
            {
                num = Convert.ToInt32(this.udLevel.Value);
            }
            if (this.LongFormat)
            {
                this.myparent.smlRespecLong(num - 1, this.Mode2);
            }
            else
            {
                this.myparent.smlRespecShort(num - 1, this.Mode2);
            }
            base.Close();
        }


        private void FrmInputLevel_Load(object sender, EventArgs e)
        {
        }


        private void udLevel_Leave(object sender, EventArgs e)
        {
            this.udLevel.Validate();
        }


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("udLevel")]
        private NumericUpDown _udLevel;


        private bool LongFormat;


        private bool Mode2;


        private frmMain myparent;
    }
}
