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
        void btnCancel_Click(object sender, EventArgs e)
        {
            base.Hide();
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }
        void csHeading_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Heading;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Heading = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csHO_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.HOColor;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.HOColor = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csIO_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.IOColor;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.IOColor = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csLevel_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Level;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Level = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csPower_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Power;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Power = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csSet_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.SetColor;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.SetColor = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csSlots_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Slots;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Slots = this.cPicker.Color;
            }
            this.updateColours();
        }
        void csTitle_Click(object sender, EventArgs e)
        {
            this.cPicker.Color = this.myScheme.Title;
            if (this.cPicker.ShowDialog(this) == DialogResult.OK)
            {
                this.myScheme.Title = this.cPicker.Color;
            }
            this.updateColours();
        }
        void frmExportColor_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.myScheme.SchemeName;
            this.updateColours();
        }
        void txtName_TextChanged(object sender, EventArgs e)
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
        Button _btnCancel;
        [AccessedThroughProperty("btnOK")]
        Button _btnOK;
        [AccessedThroughProperty("cPicker")]
        ColorDialog _cPicker;
        [AccessedThroughProperty("csHeading")]
        Label _csHeading;
        [AccessedThroughProperty("csHO")]
        Label _csHO;
        [AccessedThroughProperty("csIO")]
        Label _csIO;
        [AccessedThroughProperty("csLevel")]
        Label _csLevel;
        [AccessedThroughProperty("csPower")]
        Label _csPower;
        [AccessedThroughProperty("csSet")]
        Label _csSet;
        [AccessedThroughProperty("csSlots")]
        Label _csSlots;
        [AccessedThroughProperty("csTitle")]
        Label _csTitle;
        [AccessedThroughProperty("Label1")]
        Label _Label1;
        [AccessedThroughProperty("Label19")]
        Label _Label19;
        [AccessedThroughProperty("Label20")]
        Label _Label20;
        [AccessedThroughProperty("Label21")]
        Label _Label21;
        [AccessedThroughProperty("Label22")]
        Label _Label22;
        [AccessedThroughProperty("Label3")]
        Label _Label3;
        [AccessedThroughProperty("Label4")]
        Label _Label4;
        [AccessedThroughProperty("Label5")]
        Label _Label5;
        [AccessedThroughProperty("Label7")]
        Label _Label7;
        [AccessedThroughProperty("Label9")]
        Label _Label9;
        [AccessedThroughProperty("myTip")]
        ToolTip _myTip;
        [AccessedThroughProperty("txtName")]
        TextBox _txtName;
        public ExportConfig.ColorScheme myScheme;
    }
}
