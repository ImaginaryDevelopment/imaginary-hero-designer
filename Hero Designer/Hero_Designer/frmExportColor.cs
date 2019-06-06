using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{

    public partial class frmExportColor : Form
    {

        // (get) Token: 0x060009E0 RID: 2528 RVA: 0x00068810 File Offset: 0x00066A10
        // (set) Token: 0x060009E1 RID: 2529 RVA: 0x00068828 File Offset: 0x00066A28
        internal virtual Button btnCancel
        {
            get
            {
                return this._btnCancel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click -= eventHandler;
                }
                this._btnCancel = value;
                if (this._btnCancel != null)
                {
                    this._btnCancel.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009E2 RID: 2530 RVA: 0x00068884 File Offset: 0x00066A84
        // (set) Token: 0x060009E3 RID: 2531 RVA: 0x0006889C File Offset: 0x00066A9C
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


        // (get) Token: 0x060009E4 RID: 2532 RVA: 0x000688F8 File Offset: 0x00066AF8
        // (set) Token: 0x060009E5 RID: 2533 RVA: 0x00068910 File Offset: 0x00066B10
        internal virtual ColorDialog cPicker
        {
            get
            {
                return this._cPicker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cPicker = value;
            }
        }


        // (get) Token: 0x060009E6 RID: 2534 RVA: 0x0006891C File Offset: 0x00066B1C
        // (set) Token: 0x060009E7 RID: 2535 RVA: 0x00068934 File Offset: 0x00066B34
        internal virtual Label csHeading
        {
            get
            {
                return this._csHeading;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csHeading_Click);
                if (this._csHeading != null)
                {
                    this._csHeading.Click -= eventHandler;
                }
                this._csHeading = value;
                if (this._csHeading != null)
                {
                    this._csHeading.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009E8 RID: 2536 RVA: 0x00068990 File Offset: 0x00066B90
        // (set) Token: 0x060009E9 RID: 2537 RVA: 0x000689A8 File Offset: 0x00066BA8
        internal virtual Label csHO
        {
            get
            {
                return this._csHO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csHO_Click);
                if (this._csHO != null)
                {
                    this._csHO.Click -= eventHandler;
                }
                this._csHO = value;
                if (this._csHO != null)
                {
                    this._csHO.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009EA RID: 2538 RVA: 0x00068A04 File Offset: 0x00066C04
        // (set) Token: 0x060009EB RID: 2539 RVA: 0x00068A1C File Offset: 0x00066C1C
        internal virtual Label csIO
        {
            get
            {
                return this._csIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csIO_Click);
                if (this._csIO != null)
                {
                    this._csIO.Click -= eventHandler;
                }
                this._csIO = value;
                if (this._csIO != null)
                {
                    this._csIO.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009EC RID: 2540 RVA: 0x00068A78 File Offset: 0x00066C78
        // (set) Token: 0x060009ED RID: 2541 RVA: 0x00068A90 File Offset: 0x00066C90
        internal virtual Label csLevel
        {
            get
            {
                return this._csLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csLevel_Click);
                if (this._csLevel != null)
                {
                    this._csLevel.Click -= eventHandler;
                }
                this._csLevel = value;
                if (this._csLevel != null)
                {
                    this._csLevel.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009EE RID: 2542 RVA: 0x00068AEC File Offset: 0x00066CEC
        // (set) Token: 0x060009EF RID: 2543 RVA: 0x00068B04 File Offset: 0x00066D04
        internal virtual Label csPower
        {
            get
            {
                return this._csPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csPower_Click);
                if (this._csPower != null)
                {
                    this._csPower.Click -= eventHandler;
                }
                this._csPower = value;
                if (this._csPower != null)
                {
                    this._csPower.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009F0 RID: 2544 RVA: 0x00068B60 File Offset: 0x00066D60
        // (set) Token: 0x060009F1 RID: 2545 RVA: 0x00068B78 File Offset: 0x00066D78
        internal virtual Label csSet
        {
            get
            {
                return this._csSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csSet_Click);
                if (this._csSet != null)
                {
                    this._csSet.Click -= eventHandler;
                }
                this._csSet = value;
                if (this._csSet != null)
                {
                    this._csSet.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009F2 RID: 2546 RVA: 0x00068BD4 File Offset: 0x00066DD4
        // (set) Token: 0x060009F3 RID: 2547 RVA: 0x00068BEC File Offset: 0x00066DEC
        internal virtual Label csSlots
        {
            get
            {
                return this._csSlots;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csSlots_Click);
                if (this._csSlots != null)
                {
                    this._csSlots.Click -= eventHandler;
                }
                this._csSlots = value;
                if (this._csSlots != null)
                {
                    this._csSlots.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009F4 RID: 2548 RVA: 0x00068C48 File Offset: 0x00066E48
        // (set) Token: 0x060009F5 RID: 2549 RVA: 0x00068C60 File Offset: 0x00066E60
        internal virtual Label csTitle
        {
            get
            {
                return this._csTitle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csTitle_Click);
                if (this._csTitle != null)
                {
                    this._csTitle.Click -= eventHandler;
                }
                this._csTitle = value;
                if (this._csTitle != null)
                {
                    this._csTitle.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x060009F6 RID: 2550 RVA: 0x00068CBC File Offset: 0x00066EBC
        // (set) Token: 0x060009F7 RID: 2551 RVA: 0x00068CD4 File Offset: 0x00066ED4
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


        // (get) Token: 0x060009F8 RID: 2552 RVA: 0x00068CE0 File Offset: 0x00066EE0
        // (set) Token: 0x060009F9 RID: 2553 RVA: 0x00068CF8 File Offset: 0x00066EF8
        internal virtual Label Label19
        {
            get
            {
                return this._Label19;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label19 = value;
            }
        }


        // (get) Token: 0x060009FA RID: 2554 RVA: 0x00068D04 File Offset: 0x00066F04
        // (set) Token: 0x060009FB RID: 2555 RVA: 0x00068D1C File Offset: 0x00066F1C
        internal virtual Label Label20
        {
            get
            {
                return this._Label20;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label20 = value;
            }
        }


        // (get) Token: 0x060009FC RID: 2556 RVA: 0x00068D28 File Offset: 0x00066F28
        // (set) Token: 0x060009FD RID: 2557 RVA: 0x00068D40 File Offset: 0x00066F40
        internal virtual Label Label21
        {
            get
            {
                return this._Label21;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label21 = value;
            }
        }


        // (get) Token: 0x060009FE RID: 2558 RVA: 0x00068D4C File Offset: 0x00066F4C
        // (set) Token: 0x060009FF RID: 2559 RVA: 0x00068D64 File Offset: 0x00066F64
        internal virtual Label Label22
        {
            get
            {
                return this._Label22;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label22 = value;
            }
        }


        // (get) Token: 0x06000A00 RID: 2560 RVA: 0x00068D70 File Offset: 0x00066F70
        // (set) Token: 0x06000A01 RID: 2561 RVA: 0x00068D88 File Offset: 0x00066F88
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }


        // (get) Token: 0x06000A02 RID: 2562 RVA: 0x00068D94 File Offset: 0x00066F94
        // (set) Token: 0x06000A03 RID: 2563 RVA: 0x00068DAC File Offset: 0x00066FAC
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }


        // (get) Token: 0x06000A04 RID: 2564 RVA: 0x00068DB8 File Offset: 0x00066FB8
        // (set) Token: 0x06000A05 RID: 2565 RVA: 0x00068DD0 File Offset: 0x00066FD0
        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
            }
        }


        // (get) Token: 0x06000A06 RID: 2566 RVA: 0x00068DDC File Offset: 0x00066FDC
        // (set) Token: 0x06000A07 RID: 2567 RVA: 0x00068DF4 File Offset: 0x00066FF4
        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
            }
        }


        // (get) Token: 0x06000A08 RID: 2568 RVA: 0x00068E00 File Offset: 0x00067000
        // (set) Token: 0x06000A09 RID: 2569 RVA: 0x00068E18 File Offset: 0x00067018
        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label9 = value;
            }
        }


        // (get) Token: 0x06000A0A RID: 2570 RVA: 0x00068E24 File Offset: 0x00067024
        // (set) Token: 0x06000A0B RID: 2571 RVA: 0x00068E3C File Offset: 0x0006703C
        internal virtual ToolTip myTip
        {
            get
            {
                return this._myTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._myTip = value;
            }
        }


        // (get) Token: 0x06000A0C RID: 2572 RVA: 0x00068E48 File Offset: 0x00067048
        // (set) Token: 0x06000A0D RID: 2573 RVA: 0x00068E60 File Offset: 0x00067060
        internal virtual TextBox txtName
        {
            get
            {
                return this._txtName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtName_TextChanged);
                if (this._txtName != null)
                {
                    this._txtName.TextChanged -= eventHandler;
                }
                this._txtName = value;
                if (this._txtName != null)
                {
                    this._txtName.TextChanged += eventHandler;
                }
            }
        }


        public frmExportColor(ref ExportConfig.ColorScheme iScheme)
        {
            base.Load += this.frmExportColor_Load;
            this.InitializeComponent();
            this.myScheme.Assign(iScheme);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Hide();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }


        private void csHeading_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Heading;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Heading = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csHO_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.HOColor;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.HOColor = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csIO_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.IOColor;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.IOColor = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csLevel_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Level;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Level = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csPower_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Power;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Power = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csSet_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.SetColor;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.SetColor = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csSlots_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Slots;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Slots = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void csTitle_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Title;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Title = this.cPicker.Color;
            }
            this.updateColours();
        }


        private void frmExportColor_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.myScheme.SchemeName;
            this.updateColours();
        }


        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.myScheme.SchemeName = this.txtName.Text;
        }


        public void updateColours()
        {
            this.csTitle.BackColor = this.myScheme.Title;
            this.csHeading.BackColor = this.myScheme.Heading;
            this.csLevel.BackColor = this.myScheme.Level;
            this.csSlots.BackColor = this.myScheme.Slots;
            this.csIO.BackColor = this.myScheme.IOColor;
            this.csSet.BackColor = this.myScheme.SetColor;
            this.csHO.BackColor = this.myScheme.HOColor;
            this.csPower.BackColor = this.myScheme.Power;
        }


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("cPicker")]
        private ColorDialog _cPicker;


        [AccessedThroughProperty("csHeading")]
        private Label _csHeading;


        [AccessedThroughProperty("csHO")]
        private Label _csHO;


        [AccessedThroughProperty("csIO")]
        private Label _csIO;


        [AccessedThroughProperty("csLevel")]
        private Label _csLevel;


        [AccessedThroughProperty("csPower")]
        private Label _csPower;


        [AccessedThroughProperty("csSet")]
        private Label _csSet;


        [AccessedThroughProperty("csSlots")]
        private Label _csSlots;


        [AccessedThroughProperty("csTitle")]
        private Label _csTitle;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label19")]
        private Label _Label19;


        [AccessedThroughProperty("Label20")]
        private Label _Label20;


        [AccessedThroughProperty("Label21")]
        private Label _Label21;


        [AccessedThroughProperty("Label22")]
        private Label _Label22;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("Label5")]
        private Label _Label5;


        [AccessedThroughProperty("Label7")]
        private Label _Label7;


        [AccessedThroughProperty("Label9")]
        private Label _Label9;


        [AccessedThroughProperty("myTip")]
        private ToolTip _myTip;


        [AccessedThroughProperty("txtName")]
        private TextBox _txtName;


        public ExportConfig.ColorScheme myScheme;
    }
}
