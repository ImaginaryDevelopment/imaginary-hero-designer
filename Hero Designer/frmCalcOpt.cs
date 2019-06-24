
using Base.IO_Classes;
using Base.Master_Classes;
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
    public class frmCalcOpt : Form
    {
        [AccessedThroughProperty("btnBaseReset")]
        Button _btnBaseReset;

        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;

        [AccessedThroughProperty("btnFontColour")]
        Button _btnFontColour;

        [AccessedThroughProperty("btnForceUpdate")]
        Button _btnForceUpdate;

        [AccessedThroughProperty("btnIOReset")]
        Button _btnIOReset;

        [AccessedThroughProperty("btnOK")]
        Button _btnOK;

        [AccessedThroughProperty("btnSaveFolder")]
        Button _btnSaveFolder;

        [AccessedThroughProperty("btnSaveFolderReset")]
        Button _btnSaveFolderReset;

        [AccessedThroughProperty("btnUpdate")]
        Button _btnUpdate;

        [AccessedThroughProperty("btnUpdatePathReset")]
        Button _btnUpdatePathReset;
        ComboBox cbEnhLevel;
        CheckBox chkColorInherent;
        CheckBox chkColourPrint;
        CheckBox chkHighVis;
        CheckBox chkIOEffects;
        CheckBox chkIOLevel;
        CheckBox chkIOPrintLevels;
        CheckBox chkLoadLastFile;
        CheckBox chkMiddle;
        CheckBox chkNoTips;
        CheckBox chkRelSignOnly;
        CheckBox chkSetBonus;
        CheckBox chkShowAlphaPopup;
        CheckBox chkStatBold;
        CheckBox chkTextBold;
        CheckBox chkUpdates;
        CheckBox chkUseArcanaTime;
        CheckBox chkVillainColour;

        [AccessedThroughProperty("clbSuppression")]
        CheckedListBox _clbSuppression;

        [AccessedThroughProperty("cmbAction")]
        ComboBox _cmbAction;
        ColorDialog cPicker;

        [AccessedThroughProperty("csAdd")]
        Button _csAdd;

        [AccessedThroughProperty("csBtnEdit")]
        Button _csBtnEdit;

        [AccessedThroughProperty("csDelete")]
        Button _csDelete;

        [AccessedThroughProperty("csList")]
        ListBox _csList;

        [AccessedThroughProperty("csReset")]
        Button _csReset;
        FolderBrowserDialog fbdSave;

        [AccessedThroughProperty("fcAdd")]
        Button _fcAdd;

        [AccessedThroughProperty("fcBoldOff")]
        TextBox _fcBoldOff;

        [AccessedThroughProperty("fcBoldOn")]
        TextBox _fcBoldOn;

        [AccessedThroughProperty("fcColorOff")]
        TextBox _fcColorOff;

        [AccessedThroughProperty("fcColorOn")]
        TextBox _fcColorOn;

        [AccessedThroughProperty("fcDelete")]
        Button _fcDelete;

        [AccessedThroughProperty("fcItalicOff")]
        TextBox _fcItalicOff;

        [AccessedThroughProperty("fcItalicOn")]
        TextBox _fcItalicOn;

        [AccessedThroughProperty("fcList")]
        ListBox _fcList;
        TextBox fcName;

        [AccessedThroughProperty("fcNotes")]
        TextBox _fcNotes;

        [AccessedThroughProperty("fcReset")]
        Button _fcReset;

        [AccessedThroughProperty("fcSet")]
        Button _fcSet;

        [AccessedThroughProperty("fcTextOff")]
        TextBox _fcTextOff;

        [AccessedThroughProperty("fcTextOn")]
        TextBox _fcTextOn;

        [AccessedThroughProperty("fcUnderlineOff")]
        TextBox _fcUnderlineOff;

        [AccessedThroughProperty("fcUnderlineOn")]
        TextBox _fcUnderlineOn;

        [AccessedThroughProperty("fcWSSpace")]
        RadioButton _fcWSSpace;

        [AccessedThroughProperty("fcWSTab")]
        RadioButton _fcWSTab;
        GroupBox GroupBox1;
        GroupBox GroupBox10;
        GroupBox GroupBox11;
        GroupBox GroupBox12;
        GroupBox GroupBox13;
        GroupBox GroupBox14;
        GroupBox GroupBox15;
        GroupBox GroupBox16;
        GroupBox GroupBox17;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        GroupBox GroupBox4;
        GroupBox GroupBox5;
        GroupBox GroupBox6;
        GroupBox GroupBox7;
        GroupBox GroupBox8;
        GroupBox GroupBox9;
        Label Label1;
        Label Label10;
        Label Label11;
        Label Label12;
        Label Label13;
        Label Label14;
        Label Label15;
        Label Label16;
        Label Label19;
        Label Label2;
        Label Label20;
        Label Label21;
        Label Label22;
        Label Label24;
        Label Label25;
        Label Label26;
        Label Label27;
        Label Label28;
        Label Label29;
        Label Label3;
        Label Label30;
        Label Label31;
        Label Label32;
        Label Label33;
        Label Label34;
        Label Label36;
        Label Label37;
        Label Label38;
        Label Label4;
        Label Label40;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label Label9;
        Label lblExample;
        Label lblSaveFolder;

        [AccessedThroughProperty("listScenarios")]
        ListBox _listScenarios;
        ToolTip myTip;

        [AccessedThroughProperty("optDO")]
        RadioButton _optDO;
        Label optEnh;

        [AccessedThroughProperty("optSO")]
        RadioButton _optSO;

        [AccessedThroughProperty("optTO")]
        RadioButton _optTO;
        RadioButton rbChanceAverage;
        RadioButton rbChanceIgnore;
        RadioButton rbChanceMax;
        RadioButton rbGraphSimple;
        RadioButton rbGraphStacked;
        RadioButton rbGraphTwoLine;
        RadioButton rbPvE;
        RadioButton rbPvP;
        TabControl TabControl1;
        TabPage TabPage1;
        TabPage TabPage2;
        TabPage TabPage3;
        TabPage TabPage4;
        TabPage TabPage5;
        TabPage TabPage6;
        NumericUpDown TeamSize;
        TextBox txtUpdatePath;
        NumericUpDown udBaseToHit;
        NumericUpDown udExHigh;
        NumericUpDown udExLow;
        NumericUpDown udForceLevel;
        NumericUpDown udIOLevel;
        NumericUpDown udRTFSize;
        NumericUpDown udStatSize;

        IContainer components;

        short[] defActs;

        protected bool fcNoUpdate;
        frmMain myParent;
        string[][] scenActs;

        string[] scenarioExample;


        Button btnBaseReset
        {
            get
            {
                return this._btnBaseReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnBaseReset_Click);
                if (this._btnBaseReset != null)
                    this._btnBaseReset.Click -= eventHandler;
                this._btnBaseReset = value;
                if (this._btnBaseReset == null)
                    return;
                this._btnBaseReset.Click += eventHandler;
            }
        }

        Button btnCancel
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
                    this._btnCancel.Click -= eventHandler;
                this._btnCancel = value;
                if (this._btnCancel == null)
                    return;
                this._btnCancel.Click += eventHandler;
            }
        }

        Button btnFontColour
        {
            get
            {
                return this._btnFontColour;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFontColour_Click);
                if (this._btnFontColour != null)
                    this._btnFontColour.Click -= eventHandler;
                this._btnFontColour = value;
                if (this._btnFontColour == null)
                    return;
                this._btnFontColour.Click += eventHandler;
            }
        }

        Button btnForceUpdate
        {
            get
            {
                return this._btnForceUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnForceUpdate_Click);
                if (this._btnForceUpdate != null)
                    this._btnForceUpdate.Click -= eventHandler;
                this._btnForceUpdate = value;
                if (this._btnForceUpdate == null)
                    return;
                this._btnForceUpdate.Click += eventHandler;
            }
        }

        Button btnIOReset
        {
            get
            {
                return this._btnIOReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnIOReset_Click);
                if (this._btnIOReset != null)
                    this._btnIOReset.Click -= eventHandler;
                this._btnIOReset = value;
                if (this._btnIOReset == null)
                    return;
                this._btnIOReset.Click += eventHandler;
            }
        }

        Button btnOK
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
                    this._btnOK.Click -= eventHandler;
                this._btnOK = value;
                if (this._btnOK == null)
                    return;
                this._btnOK.Click += eventHandler;
            }
        }

        Button btnSaveFolder
        {
            get
            {
                return this._btnSaveFolder;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSaveFolder_Click);
                if (this._btnSaveFolder != null)
                    this._btnSaveFolder.Click -= eventHandler;
                this._btnSaveFolder = value;
                if (this._btnSaveFolder == null)
                    return;
                this._btnSaveFolder.Click += eventHandler;
            }
        }

        Button btnSaveFolderReset
        {
            get
            {
                return this._btnSaveFolderReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSaveFolderReset_Click);
                if (this._btnSaveFolderReset != null)
                    this._btnSaveFolderReset.Click -= eventHandler;
                this._btnSaveFolderReset = value;
                if (this._btnSaveFolderReset == null)
                    return;
                this._btnSaveFolderReset.Click += eventHandler;
            }
        }

        Button btnUpdate
        {
            get
            {
                return this._btnUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUpdate_Click);
                if (this._btnUpdate != null)
                    this._btnUpdate.Click -= eventHandler;
                this._btnUpdate = value;
                if (this._btnUpdate == null)
                    return;
                this._btnUpdate.Click += eventHandler;
            }
        }

        Button btnUpdatePathReset
        {
            get
            {
                return this._btnUpdatePathReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUpdatePathReset_Click);
                if (this._btnUpdatePathReset != null)
                    this._btnUpdatePathReset.Click -= eventHandler;
                this._btnUpdatePathReset = value;
                if (this._btnUpdatePathReset == null)
                    return;
                this._btnUpdatePathReset.Click += eventHandler;
            }
        }



















        CheckedListBox clbSuppression
        {
            get
            {
                return this._clbSuppression;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.clbSuppression_SelectedIndexChanged);
                if (this._clbSuppression != null)
                    this._clbSuppression.SelectedIndexChanged -= eventHandler;
                this._clbSuppression = value;
                if (this._clbSuppression == null)
                    return;
                this._clbSuppression.SelectedIndexChanged += eventHandler;
            }
        }

        ComboBox cmbAction
        {
            get
            {
                return this._cmbAction;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cmbAction_SelectedIndexChanged);
                if (this._cmbAction != null)
                    this._cmbAction.SelectedIndexChanged -= eventHandler;
                this._cmbAction = value;
                if (this._cmbAction == null)
                    return;
                this._cmbAction.SelectedIndexChanged += eventHandler;
            }
        }


        Button csAdd
        {
            get
            {
                return this._csAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csAdd_Click);
                if (this._csAdd != null)
                    this._csAdd.Click -= eventHandler;
                this._csAdd = value;
                if (this._csAdd == null)
                    return;
                this._csAdd.Click += eventHandler;
            }
        }

        Button csBtnEdit
        {
            get
            {
                return this._csBtnEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csBtnEdit_Click);
                if (this._csBtnEdit != null)
                    this._csBtnEdit.Click -= eventHandler;
                this._csBtnEdit = value;
                if (this._csBtnEdit == null)
                    return;
                this._csBtnEdit.Click += eventHandler;
            }
        }

        Button csDelete
        {
            get
            {
                return this._csDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csDelete_Click);
                if (this._csDelete != null)
                    this._csDelete.Click -= eventHandler;
                this._csDelete = value;
                if (this._csDelete == null)
                    return;
                this._csDelete.Click += eventHandler;
            }
        }

        ListBox csList
        {
            get
            {
                return this._csList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.csList_KeyPress);
                if (this._csList != null)
                    this._csList.KeyPress -= pressEventHandler;
                this._csList = value;
                if (this._csList == null)
                    return;
                this._csList.KeyPress += pressEventHandler;
            }
        }

        Button csReset
        {
            get
            {
                return this._csReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.csReset_Click);
                if (this._csReset != null)
                    this._csReset.Click -= eventHandler;
                this._csReset = value;
                if (this._csReset == null)
                    return;
                this._csReset.Click += eventHandler;
            }
        }


        Button fcAdd
        {
            get
            {
                return this._fcAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcAdd_Click);
                if (this._fcAdd != null)
                    this._fcAdd.Click -= eventHandler;
                this._fcAdd = value;
                if (this._fcAdd == null)
                    return;
                this._fcAdd.Click += eventHandler;
            }
        }

        TextBox fcBoldOff
        {
            get
            {
                return this._fcBoldOff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcBoldOff_TextChanged);
                if (this._fcBoldOff != null)
                    this._fcBoldOff.TextChanged -= eventHandler;
                this._fcBoldOff = value;
                if (this._fcBoldOff == null)
                    return;
                this._fcBoldOff.TextChanged += eventHandler;
            }
        }

        TextBox fcBoldOn
        {
            get
            {
                return this._fcBoldOn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcBoldOn_TextChanged);
                if (this._fcBoldOn != null)
                    this._fcBoldOn.TextChanged -= eventHandler;
                this._fcBoldOn = value;
                if (this._fcBoldOn == null)
                    return;
                this._fcBoldOn.TextChanged += eventHandler;
            }
        }

        TextBox fcColorOff
        {
            get
            {
                return this._fcColorOff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcColorOff_TextChanged);
                if (this._fcColorOff != null)
                    this._fcColorOff.TextChanged -= eventHandler;
                this._fcColorOff = value;
                if (this._fcColorOff == null)
                    return;
                this._fcColorOff.TextChanged += eventHandler;
            }
        }

        TextBox fcColorOn
        {
            get
            {
                return this._fcColorOn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcColorOn_TextChanged);
                if (this._fcColorOn != null)
                    this._fcColorOn.TextChanged -= eventHandler;
                this._fcColorOn = value;
                if (this._fcColorOn == null)
                    return;
                this._fcColorOn.TextChanged += eventHandler;
            }
        }

        Button fcDelete
        {
            get
            {
                return this._fcDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcDelete_Click);
                if (this._fcDelete != null)
                    this._fcDelete.Click -= eventHandler;
                this._fcDelete = value;
                if (this._fcDelete == null)
                    return;
                this._fcDelete.Click += eventHandler;
            }
        }

        TextBox fcItalicOff
        {
            get
            {
                return this._fcItalicOff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcItalicOff_TextChanged);
                if (this._fcItalicOff != null)
                    this._fcItalicOff.TextChanged -= eventHandler;
                this._fcItalicOff = value;
                if (this._fcItalicOff == null)
                    return;
                this._fcItalicOff.TextChanged += eventHandler;
            }
        }

        TextBox fcItalicOn
        {
            get
            {
                return this._fcItalicOn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcItalicOn_TextChanged);
                if (this._fcItalicOn != null)
                    this._fcItalicOn.TextChanged -= eventHandler;
                this._fcItalicOn = value;
                if (this._fcItalicOn == null)
                    return;
                this._fcItalicOn.TextChanged += eventHandler;
            }
        }

        ListBox fcList
        {
            get
            {
                return this._fcList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcList_SelectedIndexChanged);
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.fcList_KeyPress);
                if (this._fcList != null)
                {
                    this._fcList.SelectedIndexChanged -= eventHandler;
                    this._fcList.KeyPress -= pressEventHandler;
                }
                this._fcList = value;
                if (this._fcList == null)
                    return;
                this._fcList.SelectedIndexChanged += eventHandler;
                this._fcList.KeyPress += pressEventHandler;
            }
        }


        TextBox fcNotes
        {
            get
            {
                return this._fcNotes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcNotes_TextChanged);
                if (this._fcNotes != null)
                    this._fcNotes.TextChanged -= eventHandler;
                this._fcNotes = value;
                if (this._fcNotes == null)
                    return;
                this._fcNotes.TextChanged += eventHandler;
            }
        }

        Button fcReset
        {
            get
            {
                return this._fcReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcReset_Click);
                if (this._fcReset != null)
                    this._fcReset.Click -= eventHandler;
                this._fcReset = value;
                if (this._fcReset == null)
                    return;
                this._fcReset.Click += eventHandler;
            }
        }

        Button fcSet
        {
            get
            {
                return this._fcSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcSet_Click);
                if (this._fcSet != null)
                    this._fcSet.Click -= eventHandler;
                this._fcSet = value;
                if (this._fcSet == null)
                    return;
                this._fcSet.Click += eventHandler;
            }
        }

        TextBox fcTextOff
        {
            get
            {
                return this._fcTextOff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcTextOff_TextChanged);
                if (this._fcTextOff != null)
                    this._fcTextOff.TextChanged -= eventHandler;
                this._fcTextOff = value;
                if (this._fcTextOff == null)
                    return;
                this._fcTextOff.TextChanged += eventHandler;
            }
        }

        TextBox fcTextOn
        {
            get
            {
                return this._fcTextOn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcTextOn_TextChanged);
                if (this._fcTextOn != null)
                    this._fcTextOn.TextChanged -= eventHandler;
                this._fcTextOn = value;
                if (this._fcTextOn == null)
                    return;
                this._fcTextOn.TextChanged += eventHandler;
            }
        }

        TextBox fcUnderlineOff
        {
            get
            {
                return this._fcUnderlineOff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcUnderlineOff_TextChanged);
                if (this._fcUnderlineOff != null)
                    this._fcUnderlineOff.TextChanged -= eventHandler;
                this._fcUnderlineOff = value;
                if (this._fcUnderlineOff == null)
                    return;
                this._fcUnderlineOff.TextChanged += eventHandler;
            }
        }

        TextBox fcUnderlineOn
        {
            get
            {
                return this._fcUnderlineOn;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcUnderlineOn_TextChanged);
                if (this._fcUnderlineOn != null)
                    this._fcUnderlineOn.TextChanged -= eventHandler;
                this._fcUnderlineOn = value;
                if (this._fcUnderlineOn == null)
                    return;
                this._fcUnderlineOn.TextChanged += eventHandler;
            }
        }

        RadioButton fcWSSpace
        {
            get
            {
                return this._fcWSSpace;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcWSSpace_CheckedChanged);
                if (this._fcWSSpace != null)
                    this._fcWSSpace.CheckedChanged -= eventHandler;
                this._fcWSSpace = value;
                if (this._fcWSSpace == null)
                    return;
                this._fcWSSpace.CheckedChanged += eventHandler;
            }
        }

        RadioButton fcWSTab
        {
            get
            {
                return this._fcWSTab;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fcWSSpace_CheckedChanged);
                if (this._fcWSTab != null)
                    this._fcWSTab.CheckedChanged -= eventHandler;
                this._fcWSTab = value;
                if (this._fcWSTab == null)
                    return;
                this._fcWSTab.CheckedChanged += eventHandler;
            }
        }























































        ListBox listScenarios
        {
            get
            {
                return this._listScenarios;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.listScenarios_SelectedIndexChanged);
                if (this._listScenarios != null)
                    this._listScenarios.SelectedIndexChanged -= eventHandler;
                this._listScenarios = value;
                if (this._listScenarios == null)
                    return;
                this._listScenarios.SelectedIndexChanged += eventHandler;
            }
        }


        RadioButton optDO
        {
            get
            {
                return this._optDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.optDO_CheckedChanged);
                if (this._optDO != null)
                    this._optDO.CheckedChanged -= eventHandler;
                this._optDO = value;
                if (this._optDO == null)
                    return;
                this._optDO.CheckedChanged += eventHandler;
            }
        }


        RadioButton optSO
        {
            get
            {
                return this._optSO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.optSO_CheckedChanged);
                if (this._optSO != null)
                    this._optSO.CheckedChanged -= eventHandler;
                this._optSO = value;
                if (this._optSO == null)
                    return;
                this._optSO.CheckedChanged += eventHandler;
            }
        }

        RadioButton optTO
        {
            get
            {
                return this._optTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.optTO_CheckedChanged);
                if (this._optTO != null)
                    this._optTO.CheckedChanged -= eventHandler;
                this._optTO = value;
                if (this._optTO == null)
                    return;
                this._optTO.CheckedChanged += eventHandler;
            }
        }

























        public frmCalcOpt(ref frmMain iParent)
        {
            this.Load += new EventHandler(this.frmCalcOpt_Load);
            this.Closing += new CancelEventHandler(this.frmCalcOpt_Closing);
            this.fcNoUpdate = false;
            this.scenarioExample = new string[20];
            this.scenActs = new string[20][];
            this.defActs = new short[20];
            this.InitializeComponent();
            this.myParent = iParent;
        }

        void btnBaseReset_Click(object sender, EventArgs e)

        {
            this.udBaseToHit.Value = new Decimal(75);
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnFontColour_Click(object sender, EventArgs e)

        {
            int num = (int)new frmColourSettings().ShowDialog();
        }

        void btnForceUpdate_Click(object sender, EventArgs e)

        {
            DateTime date = DatabaseAPI.Database.Date;
            DateTime t2 = new DateTime(1, 1, 1);
            DatabaseAPI.Database.Date = t2;
            this.btnUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
            t2 = new DateTime(1, 1, 1);
            if (DateTime.Compare(DatabaseAPI.Database.Date, t2) != 0)
                return;
            DatabaseAPI.Database.Date = date;
        }

        void btnIOReset_Click(object sender, EventArgs e)

        {
            if (MidsContext.Character == null)
                return;
            int int32 = Convert.ToInt32(this.udIOLevel.Value);
            MidsContext.Character.CurrentBuild.SetIOLevels(int32, false, false);
            this.myParent.ChildRequestedRedraw();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.OK;
            this.StoreControls();
            this.myParent.DoCalcOptUpdates();
            this.Hide();
        }

        void btnSaveFolder_Click(object sender, EventArgs e)

        {
            this.fbdSave.SelectedPath = this.lblSaveFolder.Text;
            if (this.fbdSave.ShowDialog() != DialogResult.OK)
                return;
            this.lblSaveFolder.Text = this.fbdSave.SelectedPath;
        }

        void btnSaveFolderReset_Click(object sender, EventArgs e)

        {
            MidsContext.Config.CreateDefaultSaveFolder();
            MidsContext.Config.DefaultSaveFolder = OS.GetDefaultSaveFolder();
            this.lblSaveFolder.Text = MidsContext.Config.DefaultSaveFolder;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void btnUpdate_Click(object sender, EventArgs e)

        {
            clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("http://repo.cohtitan.com/mids_updates/");
            this.Enabled = false;
            IMessager iLoadFrm = (IMessager)null;
            clsXMLUpdate.eCheckResponse eCheckResponse = clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
            if (eCheckResponse != clsXMLUpdate.eCheckResponse.Updates & eCheckResponse != clsXMLUpdate.eCheckResponse.FailedWithMessage)
            {
                int num = (int)Interaction.MsgBox((object)"No Updates.", MsgBoxStyle.Information, (object)"Update Check");
            }
            if (eCheckResponse == clsXMLUpdate.eCheckResponse.Updates && clsXmlUpdate.RestartNeeded && Interaction.MsgBox((object)"Exit Now?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Update Downloaded") == MsgBoxResult.Yes && !this.myParent.CloseCommand())
            {
                clsXMLUpdate.LaunchSelfUpdate();
                ProjectData.EndApp();
            }
            this.myParent.RefreshInfo();
            this.Enabled = true;
        }

        void btnUpdatePathReset_Click(object sender, EventArgs e)

        {
            this.txtUpdatePath.Text = "http://repo.cohtitan.com/mids_updates/";
        }

        void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)

        {
            int[] values = (int[])Enum.GetValues(MidsContext.Config.Suppression.GetType());
            MidsContext.Config.Suppression = Enums.eSuppress.None;
            int num = this.clbSuppression.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; ++index)
                MidsContext.Config.Suppression += values[this.clbSuppression.CheckedIndices[index]];
        }

        void cmbAction_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.defActs[this.listScenarios.SelectedIndex] = (short)this.cmbAction.SelectedIndex;
        }

        void csAdd_Click(object sender, EventArgs e)

        {
            MidsContext.Config.Export.AddScheme();
            this.csPopulateList(MidsContext.Config.Export.ColorSchemes.Length - 1);
        }

        void csBtnEdit_Click(object sender, EventArgs e)

        {
            if (this.csList.Items.Count <= 0)
                return;
            frmExportColor frmExportColor = new frmExportColor(ref MidsContext.Config.Export.ColorSchemes[this.csList.SelectedIndex]);
            if (frmExportColor.ShowDialog() == DialogResult.OK)
            {
                MidsContext.Config.Export.ColorSchemes[this.csList.SelectedIndex].Assign(frmExportColor.myScheme);
                this.csPopulateList(-1);
            }
            this.BringToFront();
        }

        void csDelete_Click(object sender, EventArgs e)

        {
            if (this.csList.Items.Count <= 0 || Interaction.MsgBox((object)("Delete " + this.csList.SelectedItem.ToString() + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.RemoveScheme(this.csList.SelectedIndex);
            this.csPopulateList(-1);
        }

        void csList_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (Conversions.ToString(e.KeyChar) == "[")
            {
                this.forumColorUp();
            }
            else
            {
                if (!(Conversions.ToString(e.KeyChar) == "]"))
                    return;
                this.ForumColorDown();
            }
        }

        void csPopulateList(int HighlightID = -1)

        {
            this.csList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.ColorSchemes.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.csList.Items.Add((object)export.ColorSchemes[index].SchemeName);
            if (this.csList.Items.Count > 0 & HighlightID == -1)
                this.csList.SelectedIndex = 0;
            if (!(HighlightID < this.csList.Items.Count & HighlightID > -1))
                return;
            this.csList.SelectedIndex = HighlightID;
        }

        void csReset_Click(object sender, EventArgs e)

        {
            if (Interaction.MsgBox((object)"This will remove all of the colour schemes and replace them with the defaults. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.ResetColorsToDefaults();
            this.csPopulateList(-1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void fcAdd_Click(object sender, EventArgs e)

        {
            MidsContext.Config.Export.AddCodes();
            this.fcPopulateList(MidsContext.Config.Export.FormatCode.Length - 1);
        }

        void fcBoldOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].BoldOff = this.fcBoldOff.Text;
        }

        void fcBoldOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].BoldOn = this.fcBoldOn.Text;
        }

        void fcColorOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ColourOff = this.fcColorOff.Text;
        }

        void fcColorOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ColourOn = this.fcColorOn.Text;
        }

        void fcDelete_Click(object sender, EventArgs e)

        {
            if (this.fcList.Items.Count <= 0 || Interaction.MsgBox((object)("Delete " + this.fcList.SelectedItem.ToString() + "?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.RemoveCodes(this.fcList.SelectedIndex);
            this.fcPopulateList(-1);
        }

        void fcDisplay()

        {
            this.fcNoUpdate = true;
            if (this.fcList.SelectedIndex > -1)
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                this.fcName.Text = formatCode[selectedIndex].Name;
                this.fcNotes.Text = formatCode[selectedIndex].Notes;
                this.fcColorOn.Text = formatCode[selectedIndex].ColourOn;
                this.fcColorOff.Text = formatCode[selectedIndex].ColourOff;
                this.fcTextOn.Text = formatCode[selectedIndex].SizeOn;
                this.fcTextOff.Text = formatCode[selectedIndex].SizeOff;
                this.fcBoldOn.Text = formatCode[selectedIndex].BoldOn;
                this.fcBoldOff.Text = formatCode[selectedIndex].BoldOff;
                this.fcItalicOn.Text = formatCode[selectedIndex].ItalicOn;
                this.fcItalicOff.Text = formatCode[selectedIndex].ItalicOff;
                this.fcUnderlineOn.Text = formatCode[selectedIndex].UnderlineOn;
                this.fcUnderlineOff.Text = formatCode[selectedIndex].UnderlineOff;
                this.fcWSSpace.Checked = formatCode[selectedIndex].Space == ExportConfig.WhiteSpace.Space;
                this.fcWSTab.Checked = formatCode[selectedIndex].Space == ExportConfig.WhiteSpace.Tab;
            }
            else
            {
                this.fcName.Text = "";
                this.fcNotes.Text = "";
                this.fcColorOn.Text = "";
                this.fcColorOff.Text = "";
                this.fcTextOn.Text = "";
                this.fcTextOff.Text = "";
                this.fcBoldOn.Text = "";
                this.fcBoldOff.Text = "";
                this.fcItalicOn.Text = "";
                this.fcItalicOff.Text = "";
                this.fcUnderlineOn.Text = "";
                this.fcUnderlineOff.Text = "";
                this.fcWSSpace.Checked = true;
            }
            this.fcNoUpdate = false;
        }

        void fcItalicOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ItalicOff = this.fcItalicOff.Text;
        }

        void fcItalicOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].ItalicOn = this.fcItalicOn.Text;
        }

        void fcList_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (Conversions.ToString(e.KeyChar) == "[")
            {
                this.forumCodeUp();
            }
            else
            {
                if (!(Conversions.ToString(e.KeyChar) == "]"))
                    return;
                this.ForumCodeDown();
            }
        }

        void fcList_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.fcDisplay();
        }

        void fcNotes_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Notes = this.fcNotes.Text;
        }

        void fcPopulateList(int HighlightID = -1)

        {
            this.fcList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.FormatCode.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.fcList.Items.Add((object)export.FormatCode[index].Name);
            if (this.fcList.Items.Count > 0 & HighlightID == -1)
                this.fcList.SelectedIndex = 0;
            if (!(HighlightID < this.fcList.Items.Count & HighlightID > -1))
                return;
            this.fcList.SelectedIndex = HighlightID;
        }

        void fcReset_Click(object sender, EventArgs e)

        {
            if (Interaction.MsgBox((object)"This will remove all of the formatting code sets and replace them with the default set. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") != MsgBoxResult.Yes)
                return;
            MidsContext.Config.Export.ResetCodesToDefaults();
            this.fcPopulateList(-1);
        }

        void fcSet_Click(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Name = this.fcName.Text;
            this.fcPopulateList(this.fcList.SelectedIndex);
        }

        void fcTextOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].SizeOff = this.fcTextOff.Text;
        }

        void fcTextOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].SizeOn = this.fcTextOn.Text;
        }

        void fcUnderlineOff_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].UnderlineOff = this.fcUnderlineOff.Text;
        }

        void fcUnderlineOn_TextChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].UnderlineOn = this.fcUnderlineOn.Text;
        }

        void fcWSSpace_CheckedChanged(object sender, EventArgs e)

        {
            if (this.fcList.SelectedIndex < 0 | this.fcNoUpdate)
                return;
            MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Space = !this.fcWSSpace.Checked ? ExportConfig.WhiteSpace.Tab : ExportConfig.WhiteSpace.Space;
        }

        protected void ForumCodeDown()
        {
            int selectedIndex = this.fcList.SelectedIndex;
            if (selectedIndex >= this.fcList.Items.Count - 1)
                return;
            ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[2];
            formatCodesArray[0].Assign(MidsContext.Config.Export.FormatCode[selectedIndex]);
            formatCodesArray[1].Assign(MidsContext.Config.Export.FormatCode[selectedIndex + 1]);
            MidsContext.Config.Export.FormatCode[selectedIndex].Assign(formatCodesArray[1]);
            MidsContext.Config.Export.FormatCode[selectedIndex + 1].Assign(formatCodesArray[0]);
            this.fcPopulateList(-1);
            if (selectedIndex + 1 > -1 & this.fcList.Items.Count > selectedIndex + 1)
                this.fcList.SelectedIndex = selectedIndex + 1;
            else if (this.fcList.Items.Count > 0)
                this.fcList.SelectedIndex = 0;
        }

        protected void forumCodeUp()
        {
            int selectedIndex = this.fcList.SelectedIndex;
            if (selectedIndex < 1)
                return;
            ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[2];
            formatCodesArray[0].Assign(MidsContext.Config.Export.FormatCode[selectedIndex]);
            formatCodesArray[1].Assign(MidsContext.Config.Export.FormatCode[selectedIndex - 1]);
            MidsContext.Config.Export.FormatCode[selectedIndex].Assign(formatCodesArray[1]);
            MidsContext.Config.Export.FormatCode[selectedIndex - 1].Assign(formatCodesArray[0]);
            this.fcPopulateList(-1);
            if (selectedIndex - 1 > -1 & this.fcList.Items.Count > selectedIndex - 1)
                this.fcList.SelectedIndex = selectedIndex - 1;
            else if (this.fcList.Items.Count > 0)
                this.fcList.SelectedIndex = 0;
        }

        protected void ForumColorDown()
        {
            int selectedIndex = this.csList.SelectedIndex;
            if (selectedIndex >= this.csList.Items.Count - 1)
                return;
            ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[2];
            colorSchemeArray[0].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex]);
            colorSchemeArray[1].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex + 1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex].Assign(colorSchemeArray[1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex + 1].Assign(colorSchemeArray[0]);
            this.csPopulateList(-1);
            if (selectedIndex + 1 > -1 & this.csList.Items.Count > selectedIndex + 1)
                this.csList.SelectedIndex = selectedIndex + 1;
            else if (this.csList.Items.Count > 0)
                this.csList.SelectedIndex = 0;
        }

        protected void forumColorUp()
        {
            int selectedIndex = this.csList.SelectedIndex;
            if (selectedIndex < 1)
                return;
            ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[2];
            colorSchemeArray[0].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex]);
            colorSchemeArray[1].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex - 1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex].Assign(colorSchemeArray[1]);
            MidsContext.Config.Export.ColorSchemes[selectedIndex - 1].Assign(colorSchemeArray[0]);
            this.csPopulateList(-1);
            if (selectedIndex - 1 > -1 & this.csList.Items.Count > selectedIndex - 1)
                this.csList.SelectedIndex = selectedIndex - 1;
            else if (this.csList.Items.Count > 0)
                this.csList.SelectedIndex = 0;
        }

        void frmCalcOpt_Closing(object sender, CancelEventArgs e)

        {
            if (this.DialogResult != DialogResult.Abort)
                return;
            e.Cancel = true;
        }

        void frmCalcOpt_Load(object sender, EventArgs e)

        {
            this.setupScenarios();
            this.SetControls();
            this.csPopulateList(-1);
            this.fcPopulateList(-1);
            this.PopulateSuppression();
            this.SetTips();
        }

        [DebuggerStepThrough]
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCalcOpt));
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.TabControl1 = new TabControl();
            this.TabPage3 = new TabPage();
            this.chkShowAlphaPopup = new CheckBox();
            this.chkNoTips = new CheckBox();
            this.chkMiddle = new CheckBox();
            this.GroupBox17 = new GroupBox();
            this.chkColorInherent = new CheckBox();
            this.chkHighVis = new CheckBox();
            this.Label36 = new Label();
            this.chkStatBold = new CheckBox();
            this.chkTextBold = new CheckBox();
            this.btnFontColour = new Button();
            this.Label22 = new Label();
            this.chkVillainColour = new CheckBox();
            this.Label21 = new Label();
            this.udStatSize = new NumericUpDown();
            this.udRTFSize = new NumericUpDown();
            this.chkIOPrintLevels = new CheckBox();
            this.GroupBox5 = new GroupBox();
            this.rbGraphSimple = new RadioButton();
            this.rbGraphStacked = new RadioButton();
            this.rbGraphTwoLine = new RadioButton();
            this.GroupBox14 = new GroupBox();
            this.chkIOLevel = new CheckBox();
            this.btnIOReset = new Button();
            this.Label40 = new Label();
            this.udIOLevel = new NumericUpDown();
            this.GroupBox3 = new GroupBox();
            this.chkRelSignOnly = new CheckBox();
            this.Label3 = new Label();
            this.optTO = new RadioButton();
            this.optDO = new RadioButton();
            this.optSO = new RadioButton();
            this.optEnh = new Label();
            this.cbEnhLevel = new ComboBox();
            this.Label4 = new Label();
            this.TabPage2 = new TabPage();
            this.GroupBox2 = new GroupBox();
            this.clbSuppression = new CheckedListBox();
            this.Label8 = new Label();
            this.chkUseArcanaTime = new CheckBox();
            this.GroupBox15 = new GroupBox();
            this.Label20 = new Label();
            this.chkSetBonus = new CheckBox();
            this.chkIOEffects = new CheckBox();
            this.GroupBox8 = new GroupBox();
            this.rbChanceIgnore = new RadioButton();
            this.rbChanceAverage = new RadioButton();
            this.rbChanceMax = new RadioButton();
            this.Label9 = new Label();
            this.GroupBox6 = new GroupBox();
            this.Label7 = new Label();
            this.rbPvP = new RadioButton();
            this.rbPvE = new RadioButton();
            this.TabPage6 = new TabPage();
            this.Label6 = new Label();
            this.GroupBox13 = new GroupBox();
            this.udForceLevel = new NumericUpDown();
            this.Label38 = new Label();
            this.GroupBox10 = new GroupBox();
            this.btnBaseReset = new Button();
            this.Label14 = new Label();
            this.udBaseToHit = new NumericUpDown();
            this.Label13 = new Label();
            this.GroupBox4 = new GroupBox();
            this.Label12 = new Label();
            this.udExLow = new NumericUpDown();
            this.Label11 = new Label();
            this.Label5 = new Label();
            this.udExHigh = new NumericUpDown();
            this.TabPage4 = new TabPage();
            this.GroupBox12 = new GroupBox();
            this.fcReset = new Button();
            this.fcSet = new Button();
            this.fcNotes = new TextBox();
            this.fcDelete = new Button();
            this.fcAdd = new Button();
            this.fcName = new TextBox();
            this.fcWSTab = new RadioButton();
            this.fcWSSpace = new RadioButton();
            this.fcUnderlineOff = new TextBox();
            this.fcUnderlineOn = new TextBox();
            this.Label32 = new Label();
            this.fcItalicOff = new TextBox();
            this.fcItalicOn = new TextBox();
            this.Label31 = new Label();
            this.fcBoldOff = new TextBox();
            this.fcBoldOn = new TextBox();
            this.Label30 = new Label();
            this.fcTextOff = new TextBox();
            this.fcTextOn = new TextBox();
            this.Label29 = new Label();
            this.Label28 = new Label();
            this.Label27 = new Label();
            this.fcColorOff = new TextBox();
            this.fcColorOn = new TextBox();
            this.Label26 = new Label();
            this.fcList = new ListBox();
            this.Label25 = new Label();
            this.Label24 = new Label();
            this.Label33 = new Label();
            this.GroupBox11 = new GroupBox();
            this.csReset = new Button();
            this.csBtnEdit = new Button();
            this.csDelete = new Button();
            this.csAdd = new Button();
            this.csList = new ListBox();
            this.TabPage5 = new TabPage();
            this.btnSaveFolderReset = new Button();
            this.lblSaveFolder = new Label();
            this.btnSaveFolder = new Button();
            this.chkLoadLastFile = new CheckBox();
            this.Label1 = new Label();
            this.GroupBox16 = new GroupBox();
            this.btnForceUpdate = new Button();
            this.Label19 = new Label();
            this.GroupBox1 = new GroupBox();
            this.btnUpdatePathReset = new Button();
            this.Label2 = new Label();
            this.txtUpdatePath = new TextBox();
            this.Label37 = new Label();
            this.Label34 = new Label();
            this.btnUpdate = new Button();
            this.chkUpdates = new CheckBox();
            this.TabPage1 = new TabPage();
            this.Label15 = new Label();
            this.Label10 = new Label();
            this.cmbAction = new ComboBox();
            this.GroupBox9 = new GroupBox();
            this.lblExample = new Label();
            this.GroupBox7 = new GroupBox();
            this.listScenarios = new ListBox();
            this.chkColourPrint = new CheckBox();
            this.myTip = new ToolTip(this.components);
            this.cPicker = new ColorDialog();
            this.fbdSave = new FolderBrowserDialog();
            this.TeamSize = new NumericUpDown();
            this.Label16 = new Label();
            this.TabControl1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.GroupBox17.SuspendLayout();
            this.udStatSize.BeginInit();
            this.udRTFSize.BeginInit();
            this.GroupBox5.SuspendLayout();
            this.GroupBox14.SuspendLayout();
            this.udIOLevel.BeginInit();
            this.GroupBox3.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox15.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.TabPage6.SuspendLayout();
            this.GroupBox13.SuspendLayout();
            this.udForceLevel.BeginInit();
            this.GroupBox10.SuspendLayout();
            this.udBaseToHit.BeginInit();
            this.GroupBox4.SuspendLayout();
            this.udExLow.BeginInit();
            this.udExHigh.BeginInit();
            this.TabPage4.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            this.GroupBox11.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.GroupBox16.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.TeamSize.BeginInit();
            this.SuspendLayout();
            this.btnOK.DialogResult = DialogResult.OK;
            Point point = new Point(504, 360);
            this.btnOK.Location = point;
            this.btnOK.Name = "btnOK";
            Size size = new Size(75, 28);
            this.btnOK.Size = size;
            this.btnOK.TabIndex = 59;
            this.btnOK.Text = "OK";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            point = new Point(408, 360);
            this.btnCancel.Location = point;
            this.btnCancel.Name = "btnCancel";
            size = new Size(75, 28);
            this.btnCancel.Size = size;
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Cancel";
            this.TabControl1.Controls.Add((Control)this.TabPage3);
            this.TabControl1.Controls.Add((Control)this.TabPage2);
            this.TabControl1.Controls.Add((Control)this.TabPage6);
            this.TabControl1.Controls.Add((Control)this.TabPage4);
            this.TabControl1.Controls.Add((Control)this.TabPage5);
            this.TabControl1.Controls.Add((Control)this.TabPage1);
            point = new Point(0, 0);
            this.TabControl1.Location = point;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            size = new Size(638, 352);
            this.TabControl1.Size = size;
            this.TabControl1.TabIndex = 0;
            this.TabPage3.Controls.Add((Control)this.chkShowAlphaPopup);
            this.TabPage3.Controls.Add((Control)this.chkNoTips);
            this.TabPage3.Controls.Add((Control)this.chkMiddle);
            this.TabPage3.Controls.Add((Control)this.GroupBox17);
            this.TabPage3.Controls.Add((Control)this.chkIOPrintLevels);
            this.TabPage3.Controls.Add((Control)this.GroupBox5);
            this.TabPage3.Controls.Add((Control)this.GroupBox14);
            this.TabPage3.Controls.Add((Control)this.GroupBox3);
            point = new Point(4, 23);
            this.TabPage3.Location = point;
            this.TabPage3.Name = "TabPage3";
            size = new Size(700, 325);
            this.TabPage3.Size = size;
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Enhancements & View";
            this.TabPage3.UseVisualStyleBackColor = true;
            point = new Point(434, 285);
            this.chkShowAlphaPopup.Location = point;
            this.chkShowAlphaPopup.Name = "chkShowAlphaPopup";
            size = new Size(190, 18);
            this.chkShowAlphaPopup.Size = size;
            this.chkShowAlphaPopup.TabIndex = 79;
            this.chkShowAlphaPopup.Text = "Include Alpha buffs in popups";
            point = new Point(434, 304);
            this.chkNoTips.Location = point;
            this.chkNoTips.Name = "chkNoTips";
            size = new Size(141, 18);
            this.chkNoTips.Size = size;
            this.chkNoTips.TabIndex = 78;
            this.chkNoTips.Text = "No Tooltips";
            this.chkNoTips.Visible = false;
            point = new Point(206, 304);
            this.chkMiddle.Location = point;
            this.chkMiddle.Name = "chkMiddle";
            size = new Size(222, 18);
            this.chkMiddle.Size = size;
            this.chkMiddle.TabIndex = 77;
            this.chkMiddle.Text = "Middle-Click repeats last enhancement";
            this.GroupBox17.Controls.Add((Control)this.chkColorInherent);
            this.GroupBox17.Controls.Add((Control)this.chkHighVis);
            this.GroupBox17.Controls.Add((Control)this.Label36);
            this.GroupBox17.Controls.Add((Control)this.chkStatBold);
            this.GroupBox17.Controls.Add((Control)this.chkTextBold);
            this.GroupBox17.Controls.Add((Control)this.btnFontColour);
            this.GroupBox17.Controls.Add((Control)this.Label22);
            this.GroupBox17.Controls.Add((Control)this.chkVillainColour);
            this.GroupBox17.Controls.Add((Control)this.Label21);
            this.GroupBox17.Controls.Add((Control)this.udStatSize);
            this.GroupBox17.Controls.Add((Control)this.udRTFSize);
            point = new Point(196, 136);
            this.GroupBox17.Location = point;
            this.GroupBox17.Name = "GroupBox17";
            size = new Size(380, 143);
            this.GroupBox17.Size = size;
            this.GroupBox17.TabIndex = 76;
            this.GroupBox17.TabStop = false;
            this.GroupBox17.Text = "Font Size/Colors:";
            point = new Point(10, 118);
            this.chkColorInherent.Location = point;
            this.chkColorInherent.Name = "chkColorInherent";
            size = new Size(222, 20);
            this.chkColorInherent.Size = size;
            this.chkColorInherent.TabIndex = 70;
            this.chkColorInherent.Text = "Use alternate colors for inherents";
            this.myTip.SetToolTip((Control)this.chkColorInherent, "Draws villain builds in red rather than blue.");
            point = new Point(10, 74);
            this.chkHighVis.Location = point;
            this.chkHighVis.Name = "chkHighVis";
            size = new Size(222, 20);
            this.chkHighVis.Size = size;
            this.chkHighVis.TabIndex = 69;
            this.chkHighVis.Text = "Use High-Visiblity text on the build view";
            this.myTip.SetToolTip((Control)this.chkHighVis, "Draw white text with a black outline on the build view (power bars on the right of the screen)");
            point = new Point(141, 9);
            this.Label36.Location = point;
            this.Label36.Name = "Label36";
            size = new Size(39, 16);
            this.Label36.Size = size;
            this.Label36.TabIndex = 64;
            this.Label36.Text = "Bold";
            this.Label36.TextAlign = ContentAlignment.MiddleCenter;
            this.chkStatBold.AutoSize = true;
            point = new Point(150, 51);
            this.chkStatBold.Location = point;
            this.chkStatBold.Name = "chkStatBold";
            size = new Size(15, 14);
            this.chkStatBold.Size = size;
            this.chkStatBold.TabIndex = 63;
            this.chkStatBold.UseVisualStyleBackColor = true;
            this.chkTextBold.AutoSize = true;
            point = new Point(150, 26);
            this.chkTextBold.Location = point;
            this.chkTextBold.Name = "chkTextBold";
            size = new Size(15, 14);
            this.chkTextBold.Size = size;
            this.chkTextBold.TabIndex = 62;
            this.chkTextBold.UseVisualStyleBackColor = true;
            point = new Point(200, 19);
            this.btnFontColour.Location = point;
            this.btnFontColour.Name = "btnFontColour";
            size = new Size(172, 27);
            this.btnFontColour.Size = size;
            this.btnFontColour.TabIndex = 61;
            this.btnFontColour.Text = "Set Colors...";
            this.btnFontColour.UseVisualStyleBackColor = true;
            point = new Point(7, 48);
            this.Label22.Location = point;
            this.Label22.Name = "Label22";
            size = new Size(78, 20);
            this.Label22.Size = size;
            this.Label22.TabIndex = 60;
            this.Label22.Text = "Stats/Powers:";
            this.Label22.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(10, 96);
            this.chkVillainColour.Location = point;
            this.chkVillainColour.Name = "chkVillainColour";
            size = new Size(222, 20);
            this.chkVillainColour.Size = size;
            this.chkVillainColour.TabIndex = 68;
            this.chkVillainColour.Text = "Use alternate colors for villains";
            this.myTip.SetToolTip((Control)this.chkVillainColour, "Draws villain builds in red rather than blue.");
            point = new Point(7, 23);
            this.Label21.Location = point;
            this.Label21.Name = "Label21";
            size = new Size(78, 20);
            this.Label21.Size = size;
            this.Label21.TabIndex = 59;
            this.Label21.Text = "Info Tab Text:";
            this.Label21.TextAlign = ContentAlignment.MiddleRight;
            this.udStatSize.DecimalPlaces = 2;
            point = new Point(87, 48);
            this.udStatSize.Location = point;
            Decimal num = new Decimal(new int[4]
            {
        14,
        0,
        0,
        0
            });
            this.udStatSize.Maximum = num;
            num = new Decimal(new int[4] { 6, 0, 0, 0 });
            this.udStatSize.Minimum = num;
            this.udStatSize.Name = "udStatSize";
            size = new Size(52, 20);
            this.udStatSize.Size = size;
            this.udStatSize.TabIndex = 1;
            num = new Decimal(new int[4] { 825, 0, 0, 131072 });
            this.udStatSize.Value = num;
            point = new Point(87, 22);
            this.udRTFSize.Location = point;
            num = new Decimal(new int[4] { 14, 0, 0, 0 });
            this.udRTFSize.Maximum = num;
            num = new Decimal(new int[4] { 6, 0, 0, 0 });
            this.udRTFSize.Minimum = num;
            this.udRTFSize.Name = "udRTFSize";
            size = new Size(52, 20);
            this.udRTFSize.Size = size;
            this.udRTFSize.TabIndex = 0;
            num = new Decimal(new int[4] { 8, 0, 0, 0 });
            this.udRTFSize.Value = num;
            point = new Point(207, 285);
            this.chkIOPrintLevels.Location = point;
            this.chkIOPrintLevels.Name = "chkIOPrintLevels";
            size = new Size(221, 18);
            this.chkIOPrintLevels.Size = size;
            this.chkIOPrintLevels.TabIndex = 75;
            this.chkIOPrintLevels.Text = "Display Invention levels in printed builds";
            this.GroupBox5.Controls.Add((Control)this.rbGraphSimple);
            this.GroupBox5.Controls.Add((Control)this.rbGraphStacked);
            this.GroupBox5.Controls.Add((Control)this.rbGraphTwoLine);
            point = new Point(388, 4);
            this.GroupBox5.Location = point;
            this.GroupBox5.Name = "GroupBox5";
            size = new Size(188, 125);
            this.GroupBox5.Size = size;
            this.GroupBox5.TabIndex = 72;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Damage Graph Style:";
            point = new Point(6, 89);
            this.rbGraphSimple.Location = point;
            this.rbGraphSimple.Name = "rbGraphSimple";
            size = new Size(164, 32);
            this.rbGraphSimple.Size = size;
            this.rbGraphSimple.TabIndex = 5;
            this.rbGraphSimple.Text = "Base against Enhanced";
            this.myTip.SetToolTip((Control)this.rbGraphSimple, "This graph type doesn't reflect the max damage potential of other powers.");
            point = new Point(6, 53);
            this.rbGraphStacked.Location = point;
            this.rbGraphStacked.Name = "rbGraphStacked";
            size = new Size(164, 32);
            this.rbGraphStacked.Size = size;
            this.rbGraphStacked.TabIndex = 4;
            this.rbGraphStacked.Text = "Base + Enhanced (stacked) against Max Enhancable";
            this.myTip.SetToolTip((Control)this.rbGraphStacked, "'Max Enhacable' is damage if slotted with 6 +3 damage enhancements.");
            this.rbGraphTwoLine.Checked = true;
            point = new Point(6, 17);
            this.rbGraphTwoLine.Location = point;
            this.rbGraphTwoLine.Name = "rbGraphTwoLine";
            size = new Size(164, 32);
            this.rbGraphTwoLine.Size = size;
            this.rbGraphTwoLine.TabIndex = 3;
            this.rbGraphTwoLine.TabStop = true;
            this.rbGraphTwoLine.Text = "Base / Enhanced against Max Enhancable (Default)";
            this.myTip.SetToolTip((Control)this.rbGraphTwoLine, "The blue bar will indicate base damage, the yellow bar will indicate enhanced damage.");
            this.GroupBox14.Controls.Add((Control)this.chkIOLevel);
            this.GroupBox14.Controls.Add((Control)this.btnIOReset);
            this.GroupBox14.Controls.Add((Control)this.Label40);
            this.GroupBox14.Controls.Add((Control)this.udIOLevel);
            point = new Point(196, 4);
            this.GroupBox14.Location = point;
            this.GroupBox14.Name = "GroupBox14";
            size = new Size(188, 125);
            this.GroupBox14.Size = size;
            this.GroupBox14.TabIndex = 69;
            this.GroupBox14.TabStop = false;
            this.GroupBox14.Text = "Inventions:";
            point = new Point(8, 44);
            this.chkIOLevel.Location = point;
            this.chkIOLevel.Name = "chkIOLevel";
            size = new Size(172, 24);
            this.chkIOLevel.Size = size;
            this.chkIOLevel.TabIndex = 60;
            this.chkIOLevel.Text = "Display IO Levels";
            this.myTip.SetToolTip((Control)this.chkIOLevel, "Show the level of Inventions in the build view");
            point = new Point(8, 72);
            this.btnIOReset.Location = point;
            this.btnIOReset.Name = "btnIOReset";
            size = new Size(172, 44);
            this.btnIOReset.Size = size;
            this.btnIOReset.TabIndex = 59;
            this.btnIOReset.Text = "Set All IO and SetO levels to default";
            point = new Point(8, 20);
            this.Label40.Location = point;
            this.Label40.Name = "Label40";
            size = new Size(96, 20);
            this.Label40.Size = size;
            this.Label40.TabIndex = 58;
            this.Label40.Text = "Default IO Level:";
            this.Label40.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(108, 20);
            this.udIOLevel.Location = point;
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udIOLevel.Maximum = num;
            num = new Decimal(new int[4] { 10, 0, 0, 0 });
            this.udIOLevel.Minimum = num;
            this.udIOLevel.Name = "udIOLevel";
            size = new Size(72, 20);
            this.udIOLevel.Size = size;
            this.udIOLevel.TabIndex = 57;
            this.myTip.SetToolTip((Control)this.udIOLevel, "Inventions will be placed at this level by default. You can override the default by typing a level number in the picker.");
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udIOLevel.Value = num;
            this.GroupBox3.Controls.Add((Control)this.chkRelSignOnly);
            this.GroupBox3.Controls.Add((Control)this.Label3);
            this.GroupBox3.Controls.Add((Control)this.optTO);
            this.GroupBox3.Controls.Add((Control)this.optDO);
            this.GroupBox3.Controls.Add((Control)this.optSO);
            this.GroupBox3.Controls.Add((Control)this.optEnh);
            this.GroupBox3.Controls.Add((Control)this.cbEnhLevel);
            this.GroupBox3.Controls.Add((Control)this.Label4);
            point = new Point(4, 4);
            this.GroupBox3.Location = point;
            this.GroupBox3.Name = "GroupBox3";
            size = new Size(184, 301);
            this.GroupBox3.Size = size;
            this.GroupBox3.TabIndex = 62;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Regular Enhancements:";
            point = new Point(11, 252);
            this.chkRelSignOnly.Location = point;
            this.chkRelSignOnly.Name = "chkRelSignOnly";
            size = new Size(167, 43);
            this.chkRelSignOnly.Size = size;
            this.chkRelSignOnly.TabIndex = 69;
            this.chkRelSignOnly.Text = "Show signs only for relative levels ('++' rather than '+2')";
            this.myTip.SetToolTip((Control)this.chkRelSignOnly, "Draws villain builds in red rather than blue.");
            point = new Point(6, 142);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(172, 79);
            this.Label3.Size = size;
            this.Label3.TabIndex = 59;
            this.Label3.Text = "Default Relative Level:\r\n(Ehancements can function up to five levels above or three below that of the character.)";
            this.Label3.TextAlign = ContentAlignment.MiddleCenter;
            this.optTO.Appearance = Appearance.Button;
            this.optTO.CheckAlign = ContentAlignment.TopCenter;
            this.optTO.Image = (Image)componentResourceManager.GetObject("optTO.Image");
            point = new Point(24, 74);
            this.optTO.Location = point;
            this.optTO.Name = "optTO";
            size = new Size(44, 44);
            this.optTO.Size = size;
            this.optTO.TabIndex = 48;
            this.optTO.TextAlign = ContentAlignment.MiddleCenter;
            this.myTip.SetToolTip((Control)this.optTO, "Training enhancements are the weakest kind.");
            this.optDO.Appearance = Appearance.Button;
            this.optDO.CheckAlign = ContentAlignment.TopCenter;
            this.optDO.Image = (Image)componentResourceManager.GetObject("optDO.Image");
            point = new Point(72, 74);
            this.optDO.Location = point;
            this.optDO.Name = "optDO";
            size = new Size(44, 44);
            this.optDO.Size = size;
            this.optDO.TabIndex = 49;
            this.optDO.TextAlign = ContentAlignment.MiddleCenter;
            this.myTip.SetToolTip((Control)this.optDO, "Dual Origin enhancements can be bought from level 12 onwards.");
            this.optSO.Appearance = Appearance.Button;
            this.optSO.CheckAlign = ContentAlignment.TopCenter;
            this.optSO.Checked = true;
            this.optSO.Image = (Image)componentResourceManager.GetObject("optSO.Image");
            point = new Point(120, 74);
            this.optSO.Location = point;
            this.optSO.Name = "optSO";
            size = new Size(44, 44);
            this.optSO.Size = size;
            this.optSO.TabIndex = 50;
            this.optSO.TabStop = true;
            this.optSO.TextAlign = ContentAlignment.MiddleCenter;
            this.myTip.SetToolTip((Control)this.optSO, "Single Origin enhancements are the most powerful kind, and can be bought from level 22.");
            this.optEnh.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.optEnh.ForeColor = SystemColors.ControlText;
            point = new Point(21, 121);
            this.optEnh.Location = point;
            this.optEnh.Name = "optEnh";
            size = new Size(143, 16);
            this.optEnh.Size = size;
            this.optEnh.TabIndex = 52;
            this.optEnh.Text = "Single Origin";
            this.optEnh.TextAlign = ContentAlignment.MiddleCenter;
            this.cbEnhLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbEnhLevel.Items.AddRange(new object[8]
            {
        (object) "None (Enh. has no effect)",
        (object) "-3 Levels",
        (object) "-2 Levels",
        (object) "-1 Level",
        (object) "Even Level",
        (object) "+1 Level",
        (object) "+2 Levels",
        (object) "+3 Levels"
            });
            point = new Point(9, 224);
            this.cbEnhLevel.Location = point;
            this.cbEnhLevel.Name = "cbEnhLevel";
            size = new Size(167, 22);
            this.cbEnhLevel.Size = size;
            this.cbEnhLevel.TabIndex = 53;
            this.cbEnhLevel.Tag = (object)"";
            this.myTip.SetToolTip((Control)this.cbEnhLevel, "This is the relative level of the enhancements in relation to your own. ");
            point = new Point(6, 18);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(172, 50);
            this.Label4.Size = size;
            this.Label4.TabIndex = 58;
            this.Label4.Text = "Default Enhancement Type:\r\n(This does not affect Inventions or Special enhancements)";
            this.Label4.TextAlign = ContentAlignment.MiddleCenter;
            this.TabPage2.Controls.Add((Control)this.Label16);
            this.TabPage2.Controls.Add((Control)this.TeamSize);
            this.TabPage2.Controls.Add((Control)this.GroupBox2);
            this.TabPage2.Controls.Add((Control)this.chkUseArcanaTime);
            this.TabPage2.Controls.Add((Control)this.GroupBox15);
            this.TabPage2.Controls.Add((Control)this.GroupBox8);
            this.TabPage2.Controls.Add((Control)this.GroupBox6);
            point = new Point(4, 23);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            size = new Size(630, 325);
            this.TabPage2.Size = size;
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Effects & Maths";
            this.TabPage2.UseVisualStyleBackColor = true;
            this.GroupBox2.Controls.Add((Control)this.clbSuppression);
            this.GroupBox2.Controls.Add((Control)this.Label8);
            point = new Point(517, 4);
            this.GroupBox2.Location = point;
            this.GroupBox2.Name = "GroupBox2";
            size = new Size(107, 283);
            this.GroupBox2.Size = size;
            this.GroupBox2.TabIndex = 69;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Suppression";
            this.clbSuppression.CheckOnClick = true;
            this.clbSuppression.FormattingEnabled = true;
            point = new Point(9, 104);
            this.clbSuppression.Location = point;
            this.clbSuppression.Name = "clbSuppression";
            size = new Size(92, 169);
            this.clbSuppression.Size = size;
            this.clbSuppression.TabIndex = 9;
            point = new Point(6, 17);
            this.Label8.Location = point;
            this.Label8.Name = "Label8";
            size = new Size(95, 86);
            this.Label8.Size = size;
            this.Label8.TabIndex = 65;
            this.Label8.Text = "Some effects are suppressed on specific conditions. You can enable those conditions here.";
            point = new Point(15, 294);
            this.chkUseArcanaTime.Location = point;
            this.chkUseArcanaTime.Name = "chkUseArcanaTime";
            size = new Size(204, 22);
            this.chkUseArcanaTime.Size = size;
            this.chkUseArcanaTime.TabIndex = 66;
            this.chkUseArcanaTime.Text = "Use ArcanaTime for Animation Times";
            this.myTip.SetToolTip((Control)this.chkUseArcanaTime, "Displays all cast times in ArcanaTime, the real time all animations take due to server clock ticks.");
            this.GroupBox15.Controls.Add((Control)this.Label20);
            this.GroupBox15.Controls.Add((Control)this.chkSetBonus);
            this.GroupBox15.Controls.Add((Control)this.chkIOEffects);
            point = new Point(316, 166);
            this.GroupBox15.Location = point;
            this.GroupBox15.Name = "GroupBox15";
            size = new Size(195, 121);
            this.GroupBox15.Size = size;
            this.GroupBox15.TabIndex = 68;
            this.GroupBox15.TabStop = false;
            this.GroupBox15.Text = "Invention Effects:";
            point = new Point(6, 17);
            this.Label20.Location = point;
            this.Label20.Name = "Label20";
            size = new Size(179, 49);
            this.Label20.Size = size;
            this.Label20.TabIndex = 65;
            this.Label20.Text = "The effects of set bonusses and special IO enhancements can be included when stats are calculated.";
            point = new Point(11, 93);
            this.chkSetBonus.Location = point;
            this.chkSetBonus.Name = "chkSetBonus";
            size = new Size(169, 22);
            this.chkSetBonus.Size = size;
            this.chkSetBonus.TabIndex = 64;
            this.chkSetBonus.Text = "Include Set Bonus effects\r\n";
            this.myTip.SetToolTip((Control)this.chkSetBonus, "Add set bonus effects to the totals view.");
            point = new Point(11, 69);
            this.chkIOEffects.Location = point;
            this.chkIOEffects.Name = "chkIOEffects";
            size = new Size(169, 22);
            this.chkIOEffects.Size = size;
            this.chkIOEffects.TabIndex = 63;
            this.chkIOEffects.Text = "Include Enhancement effects";
            this.myTip.SetToolTip((Control)this.chkIOEffects, "Some enhancments have power effects, such as minor Psionic resistance. This effect can be added into the power.");
            this.GroupBox8.Controls.Add((Control)this.rbChanceIgnore);
            this.GroupBox8.Controls.Add((Control)this.rbChanceAverage);
            this.GroupBox8.Controls.Add((Control)this.rbChanceMax);
            this.GroupBox8.Controls.Add((Control)this.Label9);
            point = new Point(4, 4);
            this.GroupBox8.Location = point;
            this.GroupBox8.Name = "GroupBox8";
            size = new Size(507, 156);
            this.GroupBox8.Size = size;
            this.GroupBox8.TabIndex = 3;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Chance of Damage:";
            point = new Point(221, 113);
            this.rbChanceIgnore.Location = point;
            this.rbChanceIgnore.Name = "rbChanceIgnore";
            size = new Size(224, 20);
            this.rbChanceIgnore.Size = size;
            this.rbChanceIgnore.TabIndex = 8;
            this.rbChanceIgnore.Text = "Ignore Extra Damage (Show minimum)";
            this.rbChanceAverage.Checked = true;
            point = new Point(11, 97);
            this.rbChanceAverage.Location = point;
            this.rbChanceAverage.Name = "rbChanceAverage";
            size = new Size(204, 20);
            this.rbChanceAverage.Size = size;
            this.rbChanceAverage.TabIndex = 7;
            this.rbChanceAverage.TabStop = true;
            this.rbChanceAverage.Text = "Show Average (Damage x Chance)";
            point = new Point(221, 83);
            this.rbChanceMax.Location = point;
            this.rbChanceMax.Name = "rbChanceMax";
            size = new Size(204, 20);
            this.rbChanceMax.Size = size;
            this.rbChanceMax.TabIndex = 6;
            this.rbChanceMax.Text = "Show Max Possible Damage";
            point = new Point(8, 16);
            this.Label9.Location = point;
            this.Label9.Name = "Label9";
            size = new Size(499, 56);
            this.Label9.Size = size;
            this.Label9.TabIndex = 4;
            this.Label9.Text = componentResourceManager.GetString("Label9.Text");
            this.GroupBox6.Controls.Add((Control)this.Label7);
            this.GroupBox6.Controls.Add((Control)this.rbPvP);
            this.GroupBox6.Controls.Add((Control)this.rbPvE);
            point = new Point(8, 166);
            this.GroupBox6.Location = point;
            this.GroupBox6.Name = "GroupBox6";
            size = new Size(301, 122);
            this.GroupBox6.Size = size;
            this.GroupBox6.TabIndex = 1;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Targets:";
            point = new Point(8, 16);
            this.Label7.Location = point;
            this.Label7.Name = "Label7";
            size = new Size(295, 54);
            this.Label7.Size = size;
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Some powers  have different effects when used against players (Mez effects are a good example of this). Where a power has different effects, which should be displayed?";
            point = new Point(11, 93);
            this.rbPvP.Location = point;
            this.rbPvP.Name = "rbPvP";
            size = new Size(260, 20);
            this.rbPvP.Size = size;
            this.rbPvP.TabIndex = 1;
            this.rbPvP.Text = "Show values for Players (PvP)";
            this.rbPvE.Checked = true;
            point = new Point(11, 73);
            this.rbPvE.Location = point;
            this.rbPvE.Name = "rbPvE";
            size = new Size(260, 20);
            this.rbPvE.Size = size;
            this.rbPvE.TabIndex = 0;
            this.rbPvE.TabStop = true;
            this.rbPvE.Text = "Show values for Critters (PvE)";
            this.TabPage6.Controls.Add((Control)this.Label6);
            this.TabPage6.Controls.Add((Control)this.GroupBox13);
            this.TabPage6.Controls.Add((Control)this.GroupBox10);
            this.TabPage6.Controls.Add((Control)this.GroupBox4);
            point = new Point(4, 23);
            this.TabPage6.Location = point;
            this.TabPage6.Name = "TabPage6";
            size = new Size(630, 325);
            this.TabPage6.Size = size;
            this.TabPage6.TabIndex = 5;
            this.TabPage6.Text = "Exemping & Base Values";
            this.TabPage6.UseVisualStyleBackColor = true;
            point = new Point(401, 85);
            this.Label6.Location = point;
            this.Label6.Name = "Label6";
            size = new Size(169, 119);
            this.Label6.Size = size;
            this.Label6.TabIndex = 71;
            this.Label6.Text = "Exemplar and level-accurate scaling features will be added in the future!";
            this.Label6.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox13.Controls.Add((Control)this.udForceLevel);
            this.GroupBox13.Controls.Add((Control)this.Label38);
            this.GroupBox13.Enabled = false;
            point = new Point(284, 4);
            this.GroupBox13.Location = point;
            this.GroupBox13.Name = "GroupBox13";
            size = new Size(96, 184);
            this.GroupBox13.Size = size;
            this.GroupBox13.TabIndex = 70;
            this.GroupBox13.TabStop = false;
            this.GroupBox13.Text = "Forced Level:";
            point = new Point(8, 124);
            this.udForceLevel.Location = point;
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udForceLevel.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udForceLevel.Minimum = num;
            this.udForceLevel.Name = "udForceLevel";
            size = new Size(80, 20);
            this.udForceLevel.Size = size;
            this.udForceLevel.TabIndex = 55;
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udForceLevel.Value = num;
            point = new Point(4, 16);
            this.Label38.Location = point;
            this.Label38.Name = "Label38";
            size = new Size(88, 100);
            this.Label38.Size = size;
            this.Label38.TabIndex = 1;
            this.Label38.Text = "Slots/Powers placed after this level won't be included in stats, and will be dimmed in the build view.";
            this.GroupBox10.Controls.Add((Control)this.btnBaseReset);
            this.GroupBox10.Controls.Add((Control)this.Label14);
            this.GroupBox10.Controls.Add((Control)this.udBaseToHit);
            this.GroupBox10.Controls.Add((Control)this.Label13);
            point = new Point(4, 196);
            this.GroupBox10.Location = point;
            this.GroupBox10.Name = "GroupBox10";
            size = new Size(376, 104);
            this.GroupBox10.Size = size;
            this.GroupBox10.TabIndex = 69;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Base Values:";
            point = new Point(240, 76);
            this.btnBaseReset.Location = point;
            this.btnBaseReset.Name = "btnBaseReset";
            size = new Size(120, 20);
            this.btnBaseReset.Size = size;
            this.btnBaseReset.TabIndex = 61;
            this.btnBaseReset.Text = "Reset Values";
            point = new Point(147, 39);
            this.Label14.Location = point;
            this.Label14.Name = "Label14";
            size = new Size(112, 20);
            this.Label14.Size = size;
            this.Label14.TabIndex = 58;
            this.Label14.Text = "Base ToHit:";
            this.Label14.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(263, 39);
            this.udBaseToHit.Location = point;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udBaseToHit.Minimum = num;
            this.udBaseToHit.Name = "udBaseToHit";
            size = new Size(88, 20);
            this.udBaseToHit.Size = size;
            this.udBaseToHit.TabIndex = 57;
            this.myTip.SetToolTip((Control)this.udBaseToHit, "Chance of hitting a foe. Accuracy = (Base ToHit + Buffs) * Enhancements");
            num = new Decimal(new int[4] { 75, 0, 0, 0 });
            this.udBaseToHit.Value = num;
            point = new Point(8, 16);
            this.Label13.Location = point;
            this.Label13.Name = "Label13";
            size = new Size(136, 84);
            this.Label13.Size = size;
            this.Label13.TabIndex = 0;
            this.Label13.Text = "These values are used as the base for stats calculation. They shouldn't ever need to be changed unless there's a change to the game.";
            this.GroupBox4.Controls.Add((Control)this.Label12);
            this.GroupBox4.Controls.Add((Control)this.udExLow);
            this.GroupBox4.Controls.Add((Control)this.Label11);
            this.GroupBox4.Controls.Add((Control)this.Label5);
            this.GroupBox4.Controls.Add((Control)this.udExHigh);
            this.GroupBox4.Enabled = false;
            point = new Point(4, 4);
            this.GroupBox4.Location = point;
            this.GroupBox4.Name = "GroupBox4";
            size = new Size(276, 184);
            this.GroupBox4.Size = size;
            this.GroupBox4.TabIndex = 68;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Exemplar Level:";
            point = new Point(8, 148);
            this.Label12.Location = point;
            this.Label12.Name = "Label12";
            size = new Size(160, 20);
            this.Label12.Size = size;
            this.Label12.TabIndex = 58;
            this.Label12.Text = "Exemplared (Lower) Level:";
            this.Label12.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(172, 148);
            this.udExLow.Location = point;
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExLow.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udExLow.Minimum = num;
            this.udExLow.Name = "udExLow";
            size = new Size(88, 20);
            this.udExLow.Size = size;
            this.udExLow.TabIndex = 57;
            this.myTip.SetToolTip((Control)this.udExLow, "Set the target exemplar level. Your enhancements will be calculated as though you are exemplared to this level, and their effect will be reduced accordingly");
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExLow.Value = num;
            point = new Point(8, 124);
            this.Label11.Location = point;
            this.Label11.Name = "Label11";
            size = new Size(160, 20);
            this.Label11.Size = size;
            this.Label11.TabIndex = 56;
            this.Label11.Text = "Starting (Higher) Level:";
            this.Label11.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(8, 16);
            this.Label5.Location = point;
            this.Label5.Name = "Label5";
            size = new Size(264, 96);
            this.Label5.Size = size;
            this.Label5.TabIndex = 55;
            this.Label5.Text = componentResourceManager.GetString("Label5.Text");
            point = new Point(172, 124);
            this.udExHigh.Location = point;
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExHigh.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.udExHigh.Minimum = num;
            this.udExHigh.Name = "udExHigh";
            size = new Size(88, 20);
            this.udExHigh.Size = size;
            this.udExHigh.TabIndex = 54;
            this.myTip.SetToolTip((Control)this.udExHigh, componentResourceManager.GetString("udExHigh.ToolTip"));
            num = new Decimal(new int[4] { 50, 0, 0, 0 });
            this.udExHigh.Value = num;
            this.TabPage4.Controls.Add((Control)this.GroupBox12);
            this.TabPage4.Controls.Add((Control)this.GroupBox11);
            point = new Point(4, 23);
            this.TabPage4.Location = point;
            this.TabPage4.Name = "TabPage4";
            size = new Size(630, 325);
            this.TabPage4.Size = size;
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "Forum Export Settings";
            this.TabPage4.UseVisualStyleBackColor = true;
            this.GroupBox12.Controls.Add((Control)this.fcReset);
            this.GroupBox12.Controls.Add((Control)this.fcSet);
            this.GroupBox12.Controls.Add((Control)this.fcNotes);
            this.GroupBox12.Controls.Add((Control)this.fcDelete);
            this.GroupBox12.Controls.Add((Control)this.fcAdd);
            this.GroupBox12.Controls.Add((Control)this.fcName);
            this.GroupBox12.Controls.Add((Control)this.fcWSTab);
            this.GroupBox12.Controls.Add((Control)this.fcWSSpace);
            this.GroupBox12.Controls.Add((Control)this.fcUnderlineOff);
            this.GroupBox12.Controls.Add((Control)this.fcUnderlineOn);
            this.GroupBox12.Controls.Add((Control)this.Label32);
            this.GroupBox12.Controls.Add((Control)this.fcItalicOff);
            this.GroupBox12.Controls.Add((Control)this.fcItalicOn);
            this.GroupBox12.Controls.Add((Control)this.Label31);
            this.GroupBox12.Controls.Add((Control)this.fcBoldOff);
            this.GroupBox12.Controls.Add((Control)this.fcBoldOn);
            this.GroupBox12.Controls.Add((Control)this.Label30);
            this.GroupBox12.Controls.Add((Control)this.fcTextOff);
            this.GroupBox12.Controls.Add((Control)this.fcTextOn);
            this.GroupBox12.Controls.Add((Control)this.Label29);
            this.GroupBox12.Controls.Add((Control)this.Label28);
            this.GroupBox12.Controls.Add((Control)this.Label27);
            this.GroupBox12.Controls.Add((Control)this.fcColorOff);
            this.GroupBox12.Controls.Add((Control)this.fcColorOn);
            this.GroupBox12.Controls.Add((Control)this.Label26);
            this.GroupBox12.Controls.Add((Control)this.fcList);
            this.GroupBox12.Controls.Add((Control)this.Label25);
            this.GroupBox12.Controls.Add((Control)this.Label24);
            this.GroupBox12.Controls.Add((Control)this.Label33);
            point = new Point(180, 8);
            this.GroupBox12.Location = point;
            this.GroupBox12.Name = "GroupBox12";
            size = new Size(392, 308);
            this.GroupBox12.Size = size;
            this.GroupBox12.TabIndex = 1;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "Formatting Codes:";
            point = new Point(16, 280);
            this.fcReset.Location = point;
            this.fcReset.Name = "fcReset";
            size = new Size(124, 24);
            this.fcReset.Size = size;
            this.fcReset.TabIndex = 18;
            this.fcReset.Text = "Reset To Defaults";
            point = new Point(8, 200);
            this.fcSet.Location = point;
            this.fcSet.Name = "fcSet";
            size = new Size(136, 20);
            this.fcSet.Size = size;
            this.fcSet.TabIndex = 4;
            this.fcSet.Text = "Set New Name";
            point = new Point(8, 228);
            this.fcNotes.Location = point;
            this.fcNotes.Multiline = true;
            this.fcNotes.Name = "fcNotes";
            size = new Size(136, 48);
            this.fcNotes.Size = size;
            this.fcNotes.TabIndex = 5;
            point = new Point(8, 148);
            this.fcDelete.Location = point;
            this.fcDelete.Name = "fcDelete";
            size = new Size(64, 20);
            this.fcDelete.Size = size;
            this.fcDelete.TabIndex = 1;
            this.fcDelete.Text = "Delete";
            point = new Point(80, 148);
            this.fcAdd.Location = point;
            this.fcAdd.Name = "fcAdd";
            size = new Size(64, 20);
            this.fcAdd.Size = size;
            this.fcAdd.TabIndex = 2;
            this.fcAdd.Text = "Add";
            point = new Point(8, 176);
            this.fcName.Location = point;
            this.fcName.Name = "fcName";
            size = new Size(136, 20);
            this.fcName.Size = size;
            this.fcName.TabIndex = 3;
            point = new Point(304, 196);
            this.fcWSTab.Location = point;
            this.fcWSTab.Name = "fcWSTab";
            size = new Size(80, 20);
            this.fcWSTab.Size = size;
            this.fcWSTab.TabIndex = 17;
            this.fcWSTab.Text = "Tab";
            point = new Point(220, 196);
            this.fcWSSpace.Location = point;
            this.fcWSSpace.Name = "fcWSSpace";
            size = new Size(80, 20);
            this.fcWSSpace.Size = size;
            this.fcWSSpace.TabIndex = 16;
            this.fcWSSpace.Text = "Space";
            point = new Point(324, 160);
            this.fcUnderlineOff.Location = point;
            this.fcUnderlineOff.Name = "fcUnderlineOff";
            size = new Size(60, 20);
            this.fcUnderlineOff.Size = size;
            this.fcUnderlineOff.TabIndex = 15;
            point = new Point(220, 160);
            this.fcUnderlineOn.Location = point;
            this.fcUnderlineOn.Name = "fcUnderlineOn";
            size = new Size(100, 20);
            this.fcUnderlineOn.Size = size;
            this.fcUnderlineOn.TabIndex = 14;
            point = new Point(148, 160);
            this.Label32.Location = point;
            this.Label32.Name = "Label32";
            size = new Size(68, 20);
            this.Label32.Size = size;
            this.Label32.TabIndex = 30;
            this.Label32.Text = "Underline:";
            this.Label32.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(324, 136);
            this.fcItalicOff.Location = point;
            this.fcItalicOff.Name = "fcItalicOff";
            size = new Size(60, 20);
            this.fcItalicOff.Size = size;
            this.fcItalicOff.TabIndex = 13;
            point = new Point(220, 136);
            this.fcItalicOn.Location = point;
            this.fcItalicOn.Name = "fcItalicOn";
            size = new Size(100, 20);
            this.fcItalicOn.Size = size;
            this.fcItalicOn.TabIndex = 12;
            point = new Point(148, 136);
            this.Label31.Location = point;
            this.Label31.Name = "Label31";
            size = new Size(68, 20);
            this.Label31.Size = size;
            this.Label31.TabIndex = 27;
            this.Label31.Text = "Italic:";
            this.Label31.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(324, 112);
            this.fcBoldOff.Location = point;
            this.fcBoldOff.Name = "fcBoldOff";
            size = new Size(60, 20);
            this.fcBoldOff.Size = size;
            this.fcBoldOff.TabIndex = 11;
            point = new Point(220, 112);
            this.fcBoldOn.Location = point;
            this.fcBoldOn.Name = "fcBoldOn";
            size = new Size(100, 20);
            this.fcBoldOn.Size = size;
            this.fcBoldOn.TabIndex = 10;
            point = new Point(148, 112);
            this.Label30.Location = point;
            this.Label30.Name = "Label30";
            size = new Size(68, 20);
            this.Label30.Size = size;
            this.Label30.TabIndex = 24;
            this.Label30.Text = "Bold:";
            this.Label30.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(324, 88);
            this.fcTextOff.Location = point;
            this.fcTextOff.Name = "fcTextOff";
            size = new Size(60, 20);
            this.fcTextOff.Size = size;
            this.fcTextOff.TabIndex = 9;
            point = new Point(220, 88);
            this.fcTextOn.Location = point;
            this.fcTextOn.Name = "fcTextOn";
            size = new Size(100, 20);
            this.fcTextOn.Size = size;
            this.fcTextOn.TabIndex = 8;
            point = new Point(148, 88);
            this.Label29.Location = point;
            this.Label29.Name = "Label29";
            size = new Size(68, 20);
            this.Label29.Size = size;
            this.Label29.TabIndex = 21;
            this.Label29.Text = "Code Block:";
            this.Label29.TextAlign = ContentAlignment.MiddleRight;
            point = new Point(324, 44);
            this.Label28.Location = point;
            this.Label28.Name = "Label28";
            size = new Size(60, 16);
            this.Label28.Size = size;
            this.Label28.TabIndex = 20;
            this.Label28.Text = "Off";
            this.Label28.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(220, 44);
            this.Label27.Location = point;
            this.Label27.Name = "Label27";
            size = new Size(100, 16);
            this.Label27.Size = size;
            this.Label27.TabIndex = 19;
            this.Label27.Text = "On";
            this.Label27.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(324, 64);
            this.fcColorOff.Location = point;
            this.fcColorOff.Name = "fcColorOff";
            size = new Size(60, 20);
            this.fcColorOff.Size = size;
            this.fcColorOff.TabIndex = 7;
            point = new Point(220, 64);
            this.fcColorOn.Location = point;
            this.fcColorOn.Name = "fcColorOn";
            size = new Size(100, 20);
            this.fcColorOn.Size = size;
            this.fcColorOn.TabIndex = 6;
            point = new Point(148, 64);
            this.Label26.Location = point;
            this.Label26.Name = "Label26";
            size = new Size(68, 20);
            this.Label26.Size = size;
            this.Label26.TabIndex = 16;
            this.Label26.Text = "Color:";
            this.Label26.TextAlign = ContentAlignment.MiddleRight;
            this.fcList.ItemHeight = 14;
            point = new Point(8, 40);
            this.fcList.Location = point;
            this.fcList.Name = "fcList";
            size = new Size(136, 102);
            this.fcList.Size = size;
            this.fcList.TabIndex = 0;
            point = new Point(148, 224);
            this.Label25.Location = point;
            this.Label25.Name = "Label25";
            size = new Size(236, 76);
            this.Label25.Size = size;
            this.Label25.TabIndex = 14;
            this.Label25.Text = "When defining a formatting code which takes a value, such as a color tag, use %VAL% as a placeholder for the actual value, which will replace it when a build is exported.";
            this.Label25.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(8, 16);
            this.Label24.Location = point;
            this.Label24.Name = "Label24";
            size = new Size(344, 20);
            this.Label24.Size = size;
            this.Label24.TabIndex = 13;
            this.Label24.Text = "You can set the formatting codes available for Forum Export here.";
            point = new Point(140, 196);
            this.Label33.Location = point;
            this.Label33.Name = "Label33";
            size = new Size(76, 20);
            this.Label33.Size = size;
            this.Label33.TabIndex = 33;
            this.Label33.Text = "White Space:";
            this.Label33.TextAlign = ContentAlignment.MiddleRight;
            this.GroupBox11.Controls.Add((Control)this.csReset);
            this.GroupBox11.Controls.Add((Control)this.csBtnEdit);
            this.GroupBox11.Controls.Add((Control)this.csDelete);
            this.GroupBox11.Controls.Add((Control)this.csAdd);
            this.GroupBox11.Controls.Add((Control)this.csList);
            point = new Point(12, 8);
            this.GroupBox11.Location = point;
            this.GroupBox11.Name = "GroupBox11";
            size = new Size(160, 308);
            this.GroupBox11.Size = size;
            this.GroupBox11.TabIndex = 0;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "Color Schemes:";
            point = new Point(8, 280);
            this.csReset.Location = point;
            this.csReset.Name = "csReset";
            size = new Size(144, 24);
            this.csReset.Size = size;
            this.csReset.TabIndex = 4;
            this.csReset.Text = "Reset To Defaults";
            point = new Point(8, 242);
            this.csBtnEdit.Location = point;
            this.csBtnEdit.Name = "csBtnEdit";
            size = new Size(144, 32);
            this.csBtnEdit.Size = size;
            this.csBtnEdit.TabIndex = 3;
            this.csBtnEdit.Text = "Edit...";
            point = new Point(8, 216);
            this.csDelete.Location = point;
            this.csDelete.Name = "csDelete";
            size = new Size(64, 20);
            this.csDelete.Size = size;
            this.csDelete.TabIndex = 1;
            this.csDelete.Text = "Delete";
            point = new Point(88, 216);
            this.csAdd.Location = point;
            this.csAdd.Name = "csAdd";
            size = new Size(64, 20);
            this.csAdd.Size = size;
            this.csAdd.TabIndex = 2;
            this.csAdd.Text = "Add";
            this.csList.ItemHeight = 14;
            point = new Point(8, 20);
            this.csList.Location = point;
            this.csList.Name = "csList";
            size = new Size(144, 186);
            this.csList.Size = size;
            this.csList.TabIndex = 0;
            this.TabPage5.Controls.Add((Control)this.btnSaveFolderReset);
            this.TabPage5.Controls.Add((Control)this.lblSaveFolder);
            this.TabPage5.Controls.Add((Control)this.btnSaveFolder);
            this.TabPage5.Controls.Add((Control)this.chkLoadLastFile);
            this.TabPage5.Controls.Add((Control)this.Label1);
            this.TabPage5.Controls.Add((Control)this.GroupBox16);
            this.TabPage5.Controls.Add((Control)this.GroupBox1);
            point = new Point(4, 23);
            this.TabPage5.Location = point;
            this.TabPage5.Name = "TabPage5";
            size = new Size(630, 325);
            this.TabPage5.Size = size;
            this.TabPage5.TabIndex = 4;
            this.TabPage5.Text = "Updates & Paths";
            this.TabPage5.UseVisualStyleBackColor = true;
            point = new Point(459, 298);
            this.btnSaveFolderReset.Location = point;
            this.btnSaveFolderReset.Name = "btnSaveFolderReset";
            size = new Size(105, 22);
            this.btnSaveFolderReset.Size = size;
            this.btnSaveFolderReset.TabIndex = 64;
            this.btnSaveFolderReset.Text = "Reset to Default";
            this.btnSaveFolderReset.UseVisualStyleBackColor = true;
            this.lblSaveFolder.BorderStyle = BorderStyle.FixedSingle;
            point = new Point(17, 270);
            this.lblSaveFolder.Location = point;
            this.lblSaveFolder.Name = "lblSaveFolder";
            size = new Size(436, 22);
            this.lblSaveFolder.Size = size;
            this.lblSaveFolder.TabIndex = 63;
            this.lblSaveFolder.TextAlign = ContentAlignment.MiddleLeft;
            this.lblSaveFolder.UseMnemonic = false;
            point = new Point(459, 270);
            this.btnSaveFolder.Location = point;
            this.btnSaveFolder.Name = "btnSaveFolder";
            size = new Size(105, 22);
            this.btnSaveFolder.Size = size;
            this.btnSaveFolder.TabIndex = 62;
            this.btnSaveFolder.Text = "Browse...";
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            point = new Point(17, 295);
            this.chkLoadLastFile.Location = point;
            this.chkLoadLastFile.Name = "chkLoadLastFile";
            size = new Size(156, 16);
            this.chkLoadLastFile.Size = size;
            this.chkLoadLastFile.TabIndex = 61;
            this.chkLoadLastFile.Text = "Load last file at startup";
            point = new Point(5, 246);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(123, 24);
            this.Label1.Size = size;
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Default Save Folder:";
            this.Label1.TextAlign = ContentAlignment.MiddleLeft;
            this.GroupBox16.Controls.Add((Control)this.btnForceUpdate);
            this.GroupBox16.Controls.Add((Control)this.Label19);
            point = new Point(417, 3);
            this.GroupBox16.Location = point;
            this.GroupBox16.Name = "GroupBox16";
            size = new Size(153, 240);
            this.GroupBox16.Size = size;
            this.GroupBox16.TabIndex = 6;
            this.GroupBox16.TabStop = false;
            this.GroupBox16.Text = "Panic Button:";
            this.GroupBox16.Visible = false;
            point = new Point(6, 157);
            this.btnForceUpdate.Location = point;
            this.btnForceUpdate.Name = "btnForceUpdate";
            size = new Size(140, 44);
            this.btnForceUpdate.Size = size;
            this.btnForceUpdate.TabIndex = 5;
            this.btnForceUpdate.Text = "Force Database Re-Download";
            point = new Point(5, 21);
            this.Label19.Location = point;
            this.Label19.Name = "Label19";
            size = new Size(143, 117);
            this.Label19.Size = size;
            this.Label19.TabIndex = 7;
            this.Label19.Text = "If the database is damaged and not working properly, you can force the application to redownload the most recent version.";
            this.Label19.TextAlign = ContentAlignment.MiddleCenter;
            this.GroupBox1.Controls.Add((Control)this.btnUpdatePathReset);
            this.GroupBox1.Controls.Add((Control)this.Label2);
            this.GroupBox1.Controls.Add((Control)this.txtUpdatePath);
            this.GroupBox1.Controls.Add((Control)this.Label37);
            this.GroupBox1.Controls.Add((Control)this.Label34);
            this.GroupBox1.Controls.Add((Control)this.btnUpdate);
            this.GroupBox1.Controls.Add((Control)this.chkUpdates);
            point = new Point(8, 3);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            size = new Size(403, 240);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Automatic Updates:";
            point = new Point(142, 212);
            this.btnUpdatePathReset.Location = point;
            this.btnUpdatePathReset.Name = "btnUpdatePathReset";
            size = new Size(119, 22);
            this.btnUpdatePathReset.Size = size;
            this.btnUpdatePathReset.TabIndex = 65;
            this.btnUpdatePathReset.Text = "Reset to Default";
            this.btnUpdatePathReset.UseVisualStyleBackColor = true;
            point = new Point(6, 168);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(197, 20);
            this.Label2.Size = size;
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Address of update information data:";
            this.Label2.TextAlign = ContentAlignment.MiddleLeft;
            point = new Point(9, 191);
            this.txtUpdatePath.Location = point;
            this.txtUpdatePath.Name = "txtUpdatePath";
            size = new Size(391, 20);
            this.txtUpdatePath.Size = size;
            this.txtUpdatePath.TabIndex = 9;
            point = new Point(6, 87);
            this.Label37.Location = point;
            this.Label37.Name = "Label37";
            size = new Size(384, 43);
            this.Label37.Size = size;
            this.Label37.TabIndex = 7;
            this.Label37.Text = "Please note that the availability of automatic updates may vary due to bandwidth use of the hosting site.";
            this.Label37.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(6, 16);
            this.Label34.Location = point;
            this.Label34.Name = "Label34";
            size = new Size(384, 41);
            this.Label34.Size = size;
            this.Label34.TabIndex = 5;
            this.Label34.Text = "The hero designer can automatically check for updates and download newer versions when it starts. This feature requires an internet connection.";
            this.Label34.TextAlign = ContentAlignment.MiddleCenter;
            point = new Point(121, 133);
            this.btnUpdate.Location = point;
            this.btnUpdate.Name = "btnUpdate";
            size = new Size(160, 28);
            this.btnUpdate.Size = size;
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Check for updates now";
            point = new Point(9, 60);
            this.chkUpdates.Location = point;
            this.chkUpdates.Name = "chkUpdates";
            size = new Size(304, 24);
            this.chkUpdates.Size = size;
            this.chkUpdates.TabIndex = 6;
            this.chkUpdates.Text = "Check for updates on startup";
            this.TabPage1.Controls.Add((Control)this.Label15);
            this.TabPage1.Controls.Add((Control)this.Label10);
            this.TabPage1.Controls.Add((Control)this.cmbAction);
            this.TabPage1.Controls.Add((Control)this.GroupBox9);
            this.TabPage1.Controls.Add((Control)this.GroupBox7);
            point = new Point(4, 23);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            size = new Size(630, 325);
            this.TabPage1.Size = size;
            this.TabPage1.TabIndex = 6;
            this.TabPage1.Text = "Drag & Drop";
            this.TabPage1.UseVisualStyleBackColor = true;
            point = new Point(14, 9);
            this.Label15.Location = point;
            this.Label15.Name = "Label15";
            size = new Size(602, 92);
            this.Label15.Size = size;
            this.Label15.TabIndex = 4;
            this.Label15.Text = componentResourceManager.GetString("Label15.Text");
            this.Label10.AutoSize = true;
            this.Label10.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            point = new Point(19, 268);
            this.Label10.Location = point;
            this.Label10.Name = "Label10";
            size = new Size(285, 15);
            this.Label10.Size = size;
            this.Label10.TabIndex = 3;
            this.Label10.Text = "Action to take whenever the above scenario occurs:";
            this.cmbAction.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            point = new Point(18, 293);
            this.cmbAction.Location = point;
            this.cmbAction.Name = "cmbAction";
            size = new Size(356, 22);
            this.cmbAction.Size = size;
            this.cmbAction.TabIndex = 2;
            this.GroupBox9.Controls.Add((Control)this.lblExample);
            point = new Point(403, 104);
            this.GroupBox9.Location = point;
            this.GroupBox9.Name = "GroupBox9";
            size = new Size(214, 161);
            this.GroupBox9.Size = size;
            this.GroupBox9.TabIndex = 1;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Description / Example(s)";
            point = new Point(13, 17);
            this.lblExample.Location = point;
            this.lblExample.Name = "lblExample";
            size = new Size(188, 130);
            this.lblExample.Size = size;
            this.lblExample.TabIndex = 0;
            this.GroupBox7.Controls.Add((Control)this.listScenarios);
            point = new Point(8, 102);
            this.GroupBox7.Location = point;
            this.GroupBox7.Name = "GroupBox7";
            size = new Size(380, 163);
            this.GroupBox7.Size = size;
            this.GroupBox7.TabIndex = 0;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Scenario";
            this.listScenarios.FormattingEnabled = true;
            this.listScenarios.ItemHeight = 14;
            this.listScenarios.Items.AddRange(new object[15]
            {
        (object) "Power is moved or swapped too low",
        (object) "Power is moved too high (some powers will no longer fit)",
        (object) "Power is moved or swapped higher than slots' levels",
        (object) "Power is moved or swapped too high to have # slots",
        (object) "Power being replaced is swapped too low",
        (object) "Power being replaced is swapped higher than slots' levels",
        (object) "Power being replaced is swapped too high to have # slots",
        (object) "Power being shifted down cannot shift to the necessary level",
        (object) "Power being shifted up has slots from lower levels",
        (object) "Power being shifted up has impossible # of slots",
        (object) "There is a gap in a group of powers that are being shifted",
        (object) "A power placed at its minimum level is being shifted up",
        (object) "The power in the destination slot is prevented from being shifted up",
        (object) "Slot being level-swapped is too low for the destination power",
        (object) "Slot being level-swapped is too low for the source power"
            });
            point = new Point(13, 19);
            this.listScenarios.Location = point;
            this.listScenarios.Name = "listScenarios";
            size = new Size(353, 116);
            this.listScenarios.Size = size;
            this.listScenarios.TabIndex = 0;
            point = new Point(246, 354);
            this.chkColourPrint.Location = point;
            this.chkColourPrint.Name = "chkColourPrint";
            size = new Size(156, 16);
            this.chkColourPrint.Size = size;
            this.chkColourPrint.TabIndex = 2;
            this.chkColourPrint.Text = "Print in color";
            this.chkColourPrint.Visible = false;
            this.myTip.AutoPopDelay = 10000;
            this.myTip.InitialDelay = 500;
            this.myTip.ReshowDelay = 100;
            this.cPicker.FullOpen = true;
            point = new Point(536, 296);
            this.TeamSize.Location = point;
            num = new Decimal(new int[4] { 8, 0, 0, 0 });
            this.TeamSize.Maximum = num;
            num = new Decimal(new int[4] { 1, 0, 0, 0 });
            this.TeamSize.Minimum = num;
            this.TeamSize.Name = "TeamSize";
            size = new Size(88, 20);
            this.TeamSize.Size = size;
            this.TeamSize.TabIndex = 70;
            this.myTip.SetToolTip((Control)this.TeamSize, "Set this to the number of players on your team.");
            num = new Decimal(new int[4] { 8, 0, 0, 0 });
            this.TeamSize.Value = num;
            point = new Point(473, 297);
            this.Label16.Location = point;
            this.Label16.Name = "Label16";
            size = new Size(57, 18);
            this.Label16.Size = size;
            this.Label16.TabIndex = 66;
            this.Label16.Text = "Team Size";
            this.AcceptButton = (IButtonControl)this.btnOK;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = SystemColors.Control;
            this.CancelButton = (IButtonControl)this.btnCancel;
            size = new Size(640, 392);
            this.ClientSize = size;
            this.Controls.Add((Control)this.chkColourPrint);
            this.Controls.Add((Control)this.TabControl1);
            this.Controls.Add((Control)this.btnCancel);
            this.Controls.Add((Control)this.btnOK);
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.ForeColor = SystemColors.ControlText;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(frmCalcOpt);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.TabControl1.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.GroupBox17.ResumeLayout(false);
            this.GroupBox17.PerformLayout();
            this.udStatSize.EndInit();
            this.udRTFSize.EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox14.ResumeLayout(false);
            this.udIOLevel.EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox15.ResumeLayout(false);
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.TabPage6.ResumeLayout(false);
            this.GroupBox13.ResumeLayout(false);
            this.udForceLevel.EndInit();
            this.GroupBox10.ResumeLayout(false);
            this.udBaseToHit.EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.udExLow.EndInit();
            this.udExHigh.EndInit();
            this.TabPage4.ResumeLayout(false);
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            this.GroupBox11.ResumeLayout(false);
            this.TabPage5.ResumeLayout(false);
            this.GroupBox16.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.TeamSize.EndInit();
            this.ResumeLayout(false);
        }

        void listScenarios_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.lblExample.Text = this.scenarioExample[this.listScenarios.SelectedIndex];
            this.cmbAction.Items.Clear();
            this.cmbAction.Items.AddRange((object[])this.scenActs[this.listScenarios.SelectedIndex]);
            this.cmbAction.SelectedIndex = (int)this.defActs[this.listScenarios.SelectedIndex];
        }

        void optDO_CheckedChanged(object sender, EventArgs e)

        {
            if (!this.optDO.Checked)
                return;
            this.optEnh.Text = "Dual Origin";
        }

        void optSO_CheckedChanged(object sender, EventArgs e)

        {
            if (!this.optSO.Checked)
                return;
            this.optEnh.Text = "Single Origin";
        }

        void optTO_CheckedChanged(object sender, EventArgs e)

        {
            if (!this.optTO.Checked)
                return;
            this.optEnh.Text = "Training Origin";
        }

        void PopulateSuppression()

        {
            this.clbSuppression.BeginUpdate();
            this.clbSuppression.Items.Clear();
            string[] names = Enum.GetNames(MidsContext.Config.Suppression.GetType());
            int[] values = (int[])Enum.GetValues(MidsContext.Config.Suppression.GetType());
            int num = names.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.clbSuppression.Items.Add((object)names[index], (MidsContext.Config.Suppression & (Enums.eSuppress)values[index]) != Enums.eSuppress.None);
            this.clbSuppression.EndUpdate();
        }

        void SetControls()

        {
            ConfigData config = MidsContext.Config;
            this.optSO.Checked = config.CalcEnhOrigin == Enums.eEnhGrade.SingleO;
            this.optDO.Checked = config.CalcEnhOrigin == Enums.eEnhGrade.DualO;
            this.optTO.Checked = config.CalcEnhOrigin == Enums.eEnhGrade.TrainingO;
            this.cbEnhLevel.SelectedIndex = (int)config.CalcEnhLevel;
            this.udExHigh.Value = new Decimal(config.ExempHigh);
            this.udExLow.Value = new Decimal(config.ExempLow);
            this.udForceLevel.Value = new Decimal(config.ForceLevel);
            this.chkHighVis.Checked = config.EnhanceVisibility;
            this.rbGraphTwoLine.Checked = config.DataGraphType == Enums.eDDGraph.Both;
            this.rbGraphStacked.Checked = config.DataGraphType == Enums.eDDGraph.Stacked;
            this.rbGraphSimple.Checked = config.DataGraphType == Enums.eDDGraph.Simple;
            this.rbPvE.Checked = config.Inc.PvE;
            this.rbPvP.Checked = !config.Inc.PvE;
            this.rbChanceAverage.Checked = config.DamageMath.Calculate == ConfigData.EDamageMath.Average;
            this.rbChanceMax.Checked = config.DamageMath.Calculate == ConfigData.EDamageMath.Max;
            this.rbChanceIgnore.Checked = config.DamageMath.Calculate == ConfigData.EDamageMath.Minimum;
            this.udBaseToHit.Value = new Decimal(config.BaseAcc * 100f);
            this.chkVillainColour.Checked = config.ShowVillainColours;
            this.chkUpdates.Checked = config.CheckForUpdates;
            this.udIOLevel.Value = Decimal.Compare(new Decimal(config.I9.DefaultIOLevel + 1), this.udIOLevel.Maximum) <= 0 ? new Decimal(config.I9.DefaultIOLevel + 1) : this.udIOLevel.Maximum;
            this.chkIOLevel.Checked = config.I9.DisplayIOLevels;
            this.chkIOEffects.Checked = config.I9.CalculateEnahncementFX;
            this.chkSetBonus.Checked = config.I9.CalculateSetBonusFX;
            this.chkRelSignOnly.Checked = config.ShowRelSymbols;
            this.chkIOPrintLevels.Checked = config.I9.PrintIOLevels;
            this.chkColourPrint.Checked = config.PrintInColour;
            this.udRTFSize.Value = new Decimal((double)config.RtFont.RTFBase / 2.0);
            this.udStatSize.Value = new Decimal(config.RtFont.PairedBase);
            this.chkTextBold.Checked = config.RtFont.RTFBold;
            this.chkStatBold.Checked = config.RtFont.PairedBold;
            this.chkLoadLastFile.Checked = config.LoadLastFileOnStart;
            this.lblSaveFolder.Text = config.DefaultSaveFolder;
            this.txtUpdatePath.Text = config.UpdatePath;
            this.chkColorInherent.Checked = config.DesaturateInherent;
            this.chkMiddle.Checked = config.ReapeatOnMiddleClick;
            this.chkNoTips.Checked = config.NoToolTips;
            this.chkShowAlphaPopup.Checked = config.ShowAlphaPopup;
            this.chkUseArcanaTime.Checked = config.UseArcanaTime;
            this.TeamSize.Value = new Decimal(config.TeamSize);
            int index = 0;
            do
            {
                this.defActs[index] = config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
        }

        public void SetTips()
        {
        }

        void setupScenarios()

        {
            int index1 = 0;
            this.scenarioExample[index1] = "Swap a travel power with a power taken at level 2.";
            this.scenActs[index1] = new string[4];
            this.scenActs[index1][0] = "Show dialog";
            this.scenActs[index1][1] = "Cancel";
            this.scenActs[index1][2] = "Move/swap power to its lowest possible level";
            this.scenActs[index1][3] = "Allow power to be moved anyway (mark as invalid)";
            int index2 = index1 + 1;
            this.scenarioExample[index2] = "Move a Primary power from level 35 into the level 44 slot of a character with 4 epic powers.";
            this.scenActs[index2] = new string[3];
            this.scenActs[index2][0] = "Show dialog";
            this.scenActs[index2][1] = "Cancel";
            this.scenActs[index2][2] = "Move to the last power that isn't at its min level";
            int index3 = index2 + 1;
            this.scenarioExample[index3] = "Power taken at level 2 with two level 3 slots is swapped with level 4, where there is a power with one slot.";
            this.scenActs[index3] = new string[7];
            this.scenActs[index3][0] = "Show dialog";
            this.scenActs[index3][1] = "Cancel";
            this.scenActs[index3][2] = "Remove slots";
            this.scenActs[index3][3] = "Mark invalid slots";
            this.scenActs[index3][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[index3][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[index3][6] = "Rearrange all slots in build";
            int index4 = index3 + 1;
            this.scenarioExample[index4] = "A 6-slotted power taken at level 41 is moved to level 49.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[index4] = new string[4];
            this.scenActs[index4][0] = "Show dialog";
            this.scenActs[index4][1] = "Cancel";
            this.scenActs[index4][2] = "Remove impossible slots";
            this.scenActs[index4][3] = "Allow anyway (Mark slots as invalid)";
            int index5 = index4 + 1;
            this.scenarioExample[index5] = "Power taken at level 4 is swapped with power taken at level 14, which is a travel power.";
            this.scenActs[index5] = new string[4];
            this.scenActs[index5][0] = "Show dialog";
            this.scenActs[index5][1] = "Cancel";
            this.scenActs[index5][2] = "Overwrite rather than swap";
            this.scenActs[index5][3] = "Allow power to be swapped anyway (mark as invalid)";
            int index6 = index5 + 1;
            this.scenarioExample[index6] = "Power taken at level 8 is swapped with power taken at level 2, when the level 2 power has level 3 slots.";
            this.scenActs[index6] = new string[7];
            this.scenActs[index6][0] = "Show dialog";
            this.scenActs[index6][1] = "Cancel";
            this.scenActs[index6][2] = "Remove slots";
            this.scenActs[index6][3] = "Mark invalid slots";
            this.scenActs[index6][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[index6][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[index6][6] = "Rearrange all slots in build";
            int index7 = index6 + 1;
            this.scenarioExample[index7] = "Pool power taken at level 49 is swapped with a 6-slotted power at level 41.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[index7] = new string[4];
            this.scenActs[index7][0] = "Show dialog";
            this.scenActs[index7][1] = "Cancel";
            this.scenActs[index7][2] = "Remove impossible slots";
            this.scenActs[index7][3] = "Allow anyway (Mark slots as invalid)";
            int index8 = index7 + 1;
            this.scenarioExample[index8] = "Power taken at level 4 is moved to level 8 when the power taken at level 6 is a pool power.\r\n(Note: If the power in the destination slot fails to shift, the 'Moved or swapped too low' scenario applies.)";
            this.scenActs[index8] = new string[5];
            this.scenActs[index8][0] = "Show dialog";
            this.scenActs[index8][1] = "Cancel";
            this.scenActs[index8][2] = "Shift other powers around it";
            this.scenActs[index8][3] = "Overwrite it; leave previous power slot empty";
            this.scenActs[index8][4] = "Allow anyway (mark as invalid)";
            int index9 = index8 + 1;
            this.scenarioExample[index9] = "Power taken at level 8 has level 9 slots, and a power is being moved from level 12 to level 6, so the power at 8 is shifting up to 10.";
            this.scenActs[index9] = new string[7];
            this.scenActs[index9][0] = "Show dialog";
            this.scenActs[index9][1] = "Cancel";
            this.scenActs[index9][2] = "Remove slots";
            this.scenActs[index9][3] = "Mark invalid slots";
            this.scenActs[index9][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[index9][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[index9][6] = "Rearrange all slots in build";
            int index10 = index9 + 1;
            this.scenarioExample[index10] = "Power taken at level 47 has 6 slots, and a power is being moved from level 49 to level 44, so the power at 47 is shifting to 49.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[index10] = new string[4];
            this.scenActs[index10][0] = "Show dialog";
            this.scenActs[index10][1] = "Cancel";
            this.scenActs[index10][2] = "Remove impossible slots";
            this.scenActs[index10][3] = "Allow anyway (Mark slots as invalid)";
            int index11 = index10 + 1;
            this.scenarioExample[index11] = "Power taken at level 8 is being moved to 14, and the level 10 slot is blank.";
            this.scenActs[index11] = new string[4];
            this.scenActs[index11][0] = "Show dialog";
            this.scenActs[index11][1] = "Cancel";
            this.scenActs[index11][2] = "Fill empty slot; don't move powers unnecessarily";
            this.scenActs[index11][3] = "Shift empty slot as if it were a power";
            int index12 = index11 + 1;
            this.scenarioExample[index12] = "Power placed at its minimum level is being shifted up.\r\n(Note: If and only the power in the destination slot fails to shift due to this setting, the next scenario applies.)";
            this.scenActs[index12] = new string[4];
            this.scenActs[index12][0] = "Show dialog";
            this.scenActs[index12][1] = "Cancel";
            this.scenActs[index12][2] = "Shift it along with the other powers";
            this.scenActs[index12][3] = "Shift other powers around it";
            int index13 = index12 + 1;
            this.scenarioExample[index13] = "You chose to shift other powers around ones that are at their minimum levels, but you are moving a power in place of one that is at its minimum level. (This will never occur if you chose 'Cancel' or 'Shift it along with the other powers' from the previous scenario.)";
            this.scenActs[index13] = new string[5];
            this.scenActs[index13][0] = "Show dialog";
            this.scenActs[index13][1] = "Cancel";
            this.scenActs[index13][2] = "Unlock and shift all level-locked powers";
            this.scenActs[index13][3] = "Shift destination power to the first valid and empty slot";
            this.scenActs[index13][4] = "Swap instead of move";
            int index14 = index13 + 1;
            this.scenarioExample[index14] = "Click and drag a level 21 slot from a level 20 power to a level 44 power.";
            this.scenActs[index14] = new string[3];
            this.scenActs[index14][0] = "Show dialog";
            this.scenActs[index14][1] = "Cancel";
            this.scenActs[index14][2] = "Allow swap anyway (mark as invalid)";
            int index15 = index14 + 1;
            this.scenarioExample[index15] = "Click and drag a slot from a level 44 power to a level 20 power in place of a level 21 slot.";
            this.scenActs[index15] = new string[3];
            this.scenActs[index15][0] = "Show dialog";
            this.scenActs[index15][1] = "Cancel";
            this.scenActs[index15][2] = "Allow swap anyway (mark as invalid)";
            int num = index15 + 1;
        }

        void StoreControls()

        {
            ConfigData config = MidsContext.Config;
            if (this.optSO.Checked)
                config.CalcEnhOrigin = Enums.eEnhGrade.SingleO;
            else if (this.optDO.Checked)
                config.CalcEnhOrigin = Enums.eEnhGrade.DualO;
            else if (this.optTO.Checked)
                config.CalcEnhOrigin = Enums.eEnhGrade.TrainingO;
            config.CalcEnhLevel = (Enums.eEnhRelative)this.cbEnhLevel.SelectedIndex;
            config.ExempHigh = Convert.ToInt32(this.udExHigh.Value);
            config.ExempLow = Convert.ToInt32(this.udExLow.Value);
            if (config.ExempHigh < config.ExempLow)
                config.ExempHigh = config.ExempLow;
            config.ForceLevel = Convert.ToInt32(this.udForceLevel.Value);
            if (this.rbGraphTwoLine.Checked)
                config.DataGraphType = Enums.eDDGraph.Both;
            else if (this.rbGraphStacked.Checked)
                config.DataGraphType = Enums.eDDGraph.Stacked;
            else if (this.rbGraphSimple.Checked)
                config.DataGraphType = Enums.eDDGraph.Simple;
            config.Inc.PvE = this.rbPvE.Checked;
            if (this.rbChanceAverage.Checked)
                config.DamageMath.Calculate = ConfigData.EDamageMath.Average;
            else if (this.rbChanceMax.Checked)
                config.DamageMath.Calculate = ConfigData.EDamageMath.Max;
            else if (this.rbChanceIgnore.Checked)
                config.DamageMath.Calculate = ConfigData.EDamageMath.Minimum;
            config.BaseAcc = Convert.ToSingle(Decimal.Divide(this.udBaseToHit.Value, new Decimal(100)));
            config.ShowVillainColours = this.chkVillainColour.Checked;
            config.CheckForUpdates = this.chkUpdates.Checked;
            config.I9.DefaultIOLevel = Convert.ToInt32(this.udIOLevel.Value) - 1;
            config.I9.DisplayIOLevels = this.chkIOLevel.Checked;
            config.I9.CalculateEnahncementFX = this.chkIOEffects.Checked;
            config.I9.CalculateSetBonusFX = this.chkSetBonus.Checked;
            config.ShowRelSymbols = this.chkRelSignOnly.Checked;
            config.I9.PrintIOLevels = this.chkIOPrintLevels.Checked;
            config.PrintInColour = this.chkColourPrint.Checked;
            config.RtFont.RTFBase = Convert.ToInt32(Decimal.Multiply(this.udRTFSize.Value, new Decimal(2)));
            config.RtFont.PairedBase = Convert.ToSingle(this.udStatSize.Value);
            config.RtFont.RTFBold = this.chkTextBold.Checked;
            config.RtFont.PairedBold = this.chkStatBold.Checked;
            config.LoadLastFileOnStart = this.chkLoadLastFile.Checked;
            if (config.DefaultSaveFolder != this.lblSaveFolder.Text)
            {
                config.DefaultSaveFolder = this.lblSaveFolder.Text;
                this.myParent.dlgOpen.InitialDirectory = config.DefaultSaveFolder;
                this.myParent.dlgSave.InitialDirectory = config.DefaultSaveFolder;
            }
            config.EnhanceVisibility = this.chkHighVis.Checked;
            config.UpdatePath = this.txtUpdatePath.Text;
            config.DesaturateInherent = this.chkColorInherent.Checked;
            config.ReapeatOnMiddleClick = this.chkMiddle.Checked;
            config.NoToolTips = this.chkNoTips.Checked;
            config.ShowAlphaPopup = this.chkShowAlphaPopup.Checked;
            config.UseArcanaTime = this.chkUseArcanaTime.Checked;
            config.TeamSize = Convert.ToInt32(this.TeamSize.Value);
            int index = 0;
            do
            {
                config.DragDropScenarioAction[index] = this.defActs[index];
                ++index;
            }
            while (index <= 19);
        }
    }
}
