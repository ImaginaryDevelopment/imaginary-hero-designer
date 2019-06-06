using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.IO_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmCalcOpt : Form
    {

    
    
        internal virtual Button btnBaseReset
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
                {
                    this._btnBaseReset.Click -= eventHandler;
                }
                this._btnBaseReset = value;
                if (this._btnBaseReset != null)
                {
                    this._btnBaseReset.Click += eventHandler;
                }
            }
        }


    
    
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


    
    
        internal virtual Button btnFontColour
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
                {
                    this._btnFontColour.Click -= eventHandler;
                }
                this._btnFontColour = value;
                if (this._btnFontColour != null)
                {
                    this._btnFontColour.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnForceUpdate
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
                {
                    this._btnForceUpdate.Click -= eventHandler;
                }
                this._btnForceUpdate = value;
                if (this._btnForceUpdate != null)
                {
                    this._btnForceUpdate.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnIOReset
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
                {
                    this._btnIOReset.Click -= eventHandler;
                }
                this._btnIOReset = value;
                if (this._btnIOReset != null)
                {
                    this._btnIOReset.Click += eventHandler;
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


    
    
        internal virtual Button btnSaveFolder
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
                {
                    this._btnSaveFolder.Click -= eventHandler;
                }
                this._btnSaveFolder = value;
                if (this._btnSaveFolder != null)
                {
                    this._btnSaveFolder.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSaveFolderReset
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
                {
                    this._btnSaveFolderReset.Click -= eventHandler;
                }
                this._btnSaveFolderReset = value;
                if (this._btnSaveFolderReset != null)
                {
                    this._btnSaveFolderReset.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUpdate
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
                {
                    this._btnUpdate.Click -= eventHandler;
                }
                this._btnUpdate = value;
                if (this._btnUpdate != null)
                {
                    this._btnUpdate.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnUpdatePathReset
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
                {
                    this._btnUpdatePathReset.Click -= eventHandler;
                }
                this._btnUpdatePathReset = value;
                if (this._btnUpdatePathReset != null)
                {
                    this._btnUpdatePathReset.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbEnhLevel
        {
            get
            {
                return this._cbEnhLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._cbEnhLevel = value;
            }
        }


    
    
        internal virtual CheckBox chkColorInherent
        {
            get
            {
                return this._chkColorInherent;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkColorInherent = value;
            }
        }


    
    
        internal virtual CheckBox chkColourPrint
        {
            get
            {
                return this._chkColourPrint;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkColourPrint = value;
            }
        }


    
    
        internal virtual CheckBox chkHighVis
        {
            get
            {
                return this._chkHighVis;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkHighVis = value;
            }
        }


    
    
        internal virtual CheckBox chkIOEffects
        {
            get
            {
                return this._chkIOEffects;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkIOEffects = value;
            }
        }


    
    
        internal virtual CheckBox chkIOLevel
        {
            get
            {
                return this._chkIOLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkIOLevel = value;
            }
        }


    
    
        internal virtual CheckBox chkIOPrintLevels
        {
            get
            {
                return this._chkIOPrintLevels;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkIOPrintLevels = value;
            }
        }


    
    
        internal virtual CheckBox chkLoadLastFile
        {
            get
            {
                return this._chkLoadLastFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkLoadLastFile = value;
            }
        }


    
    
        internal virtual CheckBox chkMiddle
        {
            get
            {
                return this._chkMiddle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkMiddle = value;
            }
        }


    
    
        internal virtual CheckBox chkNoTips
        {
            get
            {
                return this._chkNoTips;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkNoTips = value;
            }
        }


    
    
        internal virtual CheckBox chkRelSignOnly
        {
            get
            {
                return this._chkRelSignOnly;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkRelSignOnly = value;
            }
        }


    
    
        internal virtual CheckBox chkSetBonus
        {
            get
            {
                return this._chkSetBonus;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkSetBonus = value;
            }
        }


    
    
        internal virtual CheckBox chkShowAlphaPopup
        {
            get
            {
                return this._chkShowAlphaPopup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkShowAlphaPopup = value;
            }
        }


    
    
        internal virtual CheckBox chkStatBold
        {
            get
            {
                return this._chkStatBold;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkStatBold = value;
            }
        }


    
    
        internal virtual CheckBox chkTextBold
        {
            get
            {
                return this._chkTextBold;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkTextBold = value;
            }
        }


    
    
        internal virtual CheckBox chkUpdates
        {
            get
            {
                return this._chkUpdates;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkUpdates = value;
            }
        }


    
    
        internal virtual CheckBox chkUseArcanaTime
        {
            get
            {
                return this._chkUseArcanaTime;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkUseArcanaTime = value;
            }
        }


    
    
        internal virtual CheckBox chkVillainColour
        {
            get
            {
                return this._chkVillainColour;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkVillainColour = value;
            }
        }


    
    
        internal virtual CheckedListBox clbSuppression
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
                {
                    this._clbSuppression.SelectedIndexChanged -= eventHandler;
                }
                this._clbSuppression = value;
                if (this._clbSuppression != null)
                {
                    this._clbSuppression.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cmbAction
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
                {
                    this._cmbAction.SelectedIndexChanged -= eventHandler;
                }
                this._cmbAction = value;
                if (this._cmbAction != null)
                {
                    this._cmbAction.SelectedIndexChanged += eventHandler;
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


    
    
        internal virtual Button csAdd
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
                {
                    this._csAdd.Click -= eventHandler;
                }
                this._csAdd = value;
                if (this._csAdd != null)
                {
                    this._csAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button csBtnEdit
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
                {
                    this._csBtnEdit.Click -= eventHandler;
                }
                this._csBtnEdit = value;
                if (this._csBtnEdit != null)
                {
                    this._csBtnEdit.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button csDelete
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
                {
                    this._csDelete.Click -= eventHandler;
                }
                this._csDelete = value;
                if (this._csDelete != null)
                {
                    this._csDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ListBox csList
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
                {
                    this._csList.KeyPress -= pressEventHandler;
                }
                this._csList = value;
                if (this._csList != null)
                {
                    this._csList.KeyPress += pressEventHandler;
                }
            }
        }


    
    
        internal virtual Button csReset
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
                {
                    this._csReset.Click -= eventHandler;
                }
                this._csReset = value;
                if (this._csReset != null)
                {
                    this._csReset.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual FolderBrowserDialog fbdSave
        {
            get
            {
                return this._fbdSave;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fbdSave = value;
            }
        }


    
    
        internal virtual Button fcAdd
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
                {
                    this._fcAdd.Click -= eventHandler;
                }
                this._fcAdd = value;
                if (this._fcAdd != null)
                {
                    this._fcAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcBoldOff
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
                {
                    this._fcBoldOff.TextChanged -= eventHandler;
                }
                this._fcBoldOff = value;
                if (this._fcBoldOff != null)
                {
                    this._fcBoldOff.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcBoldOn
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
                {
                    this._fcBoldOn.TextChanged -= eventHandler;
                }
                this._fcBoldOn = value;
                if (this._fcBoldOn != null)
                {
                    this._fcBoldOn.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcColorOff
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
                {
                    this._fcColorOff.TextChanged -= eventHandler;
                }
                this._fcColorOff = value;
                if (this._fcColorOff != null)
                {
                    this._fcColorOff.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcColorOn
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
                {
                    this._fcColorOn.TextChanged -= eventHandler;
                }
                this._fcColorOn = value;
                if (this._fcColorOn != null)
                {
                    this._fcColorOn.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual Button fcDelete
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
                {
                    this._fcDelete.Click -= eventHandler;
                }
                this._fcDelete = value;
                if (this._fcDelete != null)
                {
                    this._fcDelete.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcItalicOff
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
                {
                    this._fcItalicOff.TextChanged -= eventHandler;
                }
                this._fcItalicOff = value;
                if (this._fcItalicOff != null)
                {
                    this._fcItalicOff.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcItalicOn
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
                {
                    this._fcItalicOn.TextChanged -= eventHandler;
                }
                this._fcItalicOn = value;
                if (this._fcItalicOn != null)
                {
                    this._fcItalicOn.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListBox fcList
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
                if (this._fcList != null)
                {
                    this._fcList.SelectedIndexChanged += eventHandler;
                    this._fcList.KeyPress += pressEventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcName
        {
            get
            {
                return this._fcName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fcName = value;
            }
        }


    
    
        internal virtual TextBox fcNotes
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
                {
                    this._fcNotes.TextChanged -= eventHandler;
                }
                this._fcNotes = value;
                if (this._fcNotes != null)
                {
                    this._fcNotes.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual Button fcReset
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
                {
                    this._fcReset.Click -= eventHandler;
                }
                this._fcReset = value;
                if (this._fcReset != null)
                {
                    this._fcReset.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button fcSet
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
                {
                    this._fcSet.Click -= eventHandler;
                }
                this._fcSet = value;
                if (this._fcSet != null)
                {
                    this._fcSet.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcTextOff
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
                {
                    this._fcTextOff.TextChanged -= eventHandler;
                }
                this._fcTextOff = value;
                if (this._fcTextOff != null)
                {
                    this._fcTextOff.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcTextOn
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
                {
                    this._fcTextOn.TextChanged -= eventHandler;
                }
                this._fcTextOn = value;
                if (this._fcTextOn != null)
                {
                    this._fcTextOn.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcUnderlineOff
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
                {
                    this._fcUnderlineOff.TextChanged -= eventHandler;
                }
                this._fcUnderlineOff = value;
                if (this._fcUnderlineOff != null)
                {
                    this._fcUnderlineOff.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox fcUnderlineOn
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
                {
                    this._fcUnderlineOn.TextChanged -= eventHandler;
                }
                this._fcUnderlineOn = value;
                if (this._fcUnderlineOn != null)
                {
                    this._fcUnderlineOn.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton fcWSSpace
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
                {
                    this._fcWSSpace.CheckedChanged -= eventHandler;
                }
                this._fcWSSpace = value;
                if (this._fcWSSpace != null)
                {
                    this._fcWSSpace.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton fcWSTab
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
                {
                    this._fcWSTab.CheckedChanged -= eventHandler;
                }
                this._fcWSTab = value;
                if (this._fcWSTab != null)
                {
                    this._fcWSTab.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox10
        {
            get
            {
                return this._GroupBox10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox10 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox11
        {
            get
            {
                return this._GroupBox11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox11 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox12
        {
            get
            {
                return this._GroupBox12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox12 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox13
        {
            get
            {
                return this._GroupBox13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox13 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox14
        {
            get
            {
                return this._GroupBox14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox14 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox15
        {
            get
            {
                return this._GroupBox15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox15 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox16
        {
            get
            {
                return this._GroupBox16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox16 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox17
        {
            get
            {
                return this._GroupBox17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox17 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox5
        {
            get
            {
                return this._GroupBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox5 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox6
        {
            get
            {
                return this._GroupBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox6 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox7
        {
            get
            {
                return this._GroupBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox7 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox8
        {
            get
            {
                return this._GroupBox8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox8 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox9
        {
            get
            {
                return this._GroupBox9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox9 = value;
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


    
    
        internal virtual Label Label10
        {
            get
            {
                return this._Label10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label10 = value;
            }
        }


    
    
        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label11 = value;
            }
        }


    
    
        internal virtual Label Label12
        {
            get
            {
                return this._Label12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label12 = value;
            }
        }


    
    
        internal virtual Label Label13
        {
            get
            {
                return this._Label13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label13 = value;
            }
        }


    
    
        internal virtual Label Label14
        {
            get
            {
                return this._Label14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label14 = value;
            }
        }


    
    
        internal virtual Label Label15
        {
            get
            {
                return this._Label15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label15 = value;
            }
        }


    
    
        internal virtual Label Label16
        {
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label16 = value;
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


    
    
        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
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


    
    
        internal virtual Label Label24
        {
            get
            {
                return this._Label24;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label24 = value;
            }
        }


    
    
        internal virtual Label Label25
        {
            get
            {
                return this._Label25;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label25 = value;
            }
        }


    
    
        internal virtual Label Label26
        {
            get
            {
                return this._Label26;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label26 = value;
            }
        }


    
    
        internal virtual Label Label27
        {
            get
            {
                return this._Label27;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label27 = value;
            }
        }


    
    
        internal virtual Label Label28
        {
            get
            {
                return this._Label28;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label28 = value;
            }
        }


    
    
        internal virtual Label Label29
        {
            get
            {
                return this._Label29;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label29 = value;
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


    
    
        internal virtual Label Label30
        {
            get
            {
                return this._Label30;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label30 = value;
            }
        }


    
    
        internal virtual Label Label31
        {
            get
            {
                return this._Label31;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label31 = value;
            }
        }


    
    
        internal virtual Label Label32
        {
            get
            {
                return this._Label32;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label32 = value;
            }
        }


    
    
        internal virtual Label Label33
        {
            get
            {
                return this._Label33;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label33 = value;
            }
        }


    
    
        internal virtual Label Label34
        {
            get
            {
                return this._Label34;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label34 = value;
            }
        }


    
    
        internal virtual Label Label36
        {
            get
            {
                return this._Label36;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label36 = value;
            }
        }


    
    
        internal virtual Label Label37
        {
            get
            {
                return this._Label37;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label37 = value;
            }
        }


    
    
        internal virtual Label Label38
        {
            get
            {
                return this._Label38;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label38 = value;
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


    
    
        internal virtual Label Label40
        {
            get
            {
                return this._Label40;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label40 = value;
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


    
    
        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
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


    
    
        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
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


    
    
        internal virtual Label lblExample
        {
            get
            {
                return this._lblExample;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblExample = value;
            }
        }


    
    
        internal virtual Label lblSaveFolder
        {
            get
            {
                return this._lblSaveFolder;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblSaveFolder = value;
            }
        }


    
    
        internal virtual ListBox listScenarios
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
                {
                    this._listScenarios.SelectedIndexChanged -= eventHandler;
                }
                this._listScenarios = value;
                if (this._listScenarios != null)
                {
                    this._listScenarios.SelectedIndexChanged += eventHandler;
                }
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


    
    
        internal virtual RadioButton optDO
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
                {
                    this._optDO.CheckedChanged -= eventHandler;
                }
                this._optDO = value;
                if (this._optDO != null)
                {
                    this._optDO.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual Label optEnh
        {
            get
            {
                return this._optEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._optEnh = value;
            }
        }


    
    
        internal virtual RadioButton optSO
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
                {
                    this._optSO.CheckedChanged -= eventHandler;
                }
                this._optSO = value;
                if (this._optSO != null)
                {
                    this._optSO.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton optTO
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
                {
                    this._optTO.CheckedChanged -= eventHandler;
                }
                this._optTO = value;
                if (this._optTO != null)
                {
                    this._optTO.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbChanceAverage
        {
            get
            {
                return this._rbChanceAverage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbChanceAverage = value;
            }
        }


    
    
        internal virtual RadioButton rbChanceIgnore
        {
            get
            {
                return this._rbChanceIgnore;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbChanceIgnore = value;
            }
        }


    
    
        internal virtual RadioButton rbChanceMax
        {
            get
            {
                return this._rbChanceMax;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbChanceMax = value;
            }
        }


    
    
        internal virtual RadioButton rbGraphSimple
        {
            get
            {
                return this._rbGraphSimple;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbGraphSimple = value;
            }
        }


    
    
        internal virtual RadioButton rbGraphStacked
        {
            get
            {
                return this._rbGraphStacked;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbGraphStacked = value;
            }
        }


    
    
        internal virtual RadioButton rbGraphTwoLine
        {
            get
            {
                return this._rbGraphTwoLine;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbGraphTwoLine = value;
            }
        }


    
    
        internal virtual RadioButton rbPvE
        {
            get
            {
                return this._rbPvE;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbPvE = value;
            }
        }


    
    
        internal virtual RadioButton rbPvP
        {
            get
            {
                return this._rbPvP;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._rbPvP = value;
            }
        }


    
    
        internal virtual TabControl TabControl1
        {
            get
            {
                return this._TabControl1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabControl1 = value;
            }
        }


    
    
        internal virtual TabPage TabPage1
        {
            get
            {
                return this._TabPage1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage1 = value;
            }
        }


    
    
        internal virtual TabPage TabPage2
        {
            get
            {
                return this._TabPage2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage2 = value;
            }
        }


    
    
        internal virtual TabPage TabPage3
        {
            get
            {
                return this._TabPage3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage3 = value;
            }
        }


    
    
        internal virtual TabPage TabPage4
        {
            get
            {
                return this._TabPage4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage4 = value;
            }
        }


    
    
        internal virtual TabPage TabPage5
        {
            get
            {
                return this._TabPage5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage5 = value;
            }
        }


    
    
        internal virtual TabPage TabPage6
        {
            get
            {
                return this._TabPage6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TabPage6 = value;
            }
        }


    
    
        internal virtual NumericUpDown TeamSize
        {
            get
            {
                return this._TeamSize;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._TeamSize = value;
            }
        }


    
    
        internal virtual TextBox txtUpdatePath
        {
            get
            {
                return this._txtUpdatePath;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtUpdatePath = value;
            }
        }


    
    
        internal virtual NumericUpDown udBaseToHit
        {
            get
            {
                return this._udBaseToHit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udBaseToHit = value;
            }
        }


    
    
        internal virtual NumericUpDown udExHigh
        {
            get
            {
                return this._udExHigh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udExHigh = value;
            }
        }


    
    
        internal virtual NumericUpDown udExLow
        {
            get
            {
                return this._udExLow;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udExLow = value;
            }
        }


    
    
        internal virtual NumericUpDown udForceLevel
        {
            get
            {
                return this._udForceLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udForceLevel = value;
            }
        }


    
    
        internal virtual NumericUpDown udIOLevel
        {
            get
            {
                return this._udIOLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udIOLevel = value;
            }
        }


    
    
        internal virtual NumericUpDown udRTFSize
        {
            get
            {
                return this._udRTFSize;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udRTFSize = value;
            }
        }


    
    
        internal virtual NumericUpDown udStatSize
        {
            get
            {
                return this._udStatSize;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udStatSize = value;
            }
        }


        public frmCalcOpt(ref frmMain iParent)
        {
            base.Load += this.frmCalcOpt_Load;
            base.Closing += this.frmCalcOpt_Closing;
            this.fcNoUpdate = false;
            this.scenarioExample = new string[20];
            this.scenActs = new string[20][];
            this.defActs = new short[20];
            this.InitializeComponent();
            this.myParent = iParent;
        }


        void btnBaseReset_Click(object sender, EventArgs e)
        {
            this.udBaseToHit.Value = 75m;
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        void btnFontColour_Click(object sender, EventArgs e)
        {
            new frmColourSettings().ShowDialog();
        }


        void btnForceUpdate_Click(object sender, EventArgs e)
        {
            DateTime date = DatabaseAPI.Database.Date;
            DateTime t2 = new DateTime(1, 1, 1);
            DatabaseAPI.Database.Date = t2;
            this.btnUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
            t2 = new DateTime(1, 1, 1);
            if (DateTime.Compare(DatabaseAPI.Database.Date, t2) == 0)
            {
                DatabaseAPI.Database.Date = date;
            }
        }


        void btnIOReset_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character != null)
            {
                int int32 = Convert.ToInt32(this.udIOLevel.Value);
                MidsContext.Character.CurrentBuild.SetIOLevels(int32, false, false);
                if (this.myParent.Drawing != null)
                {
                    this.myParent.DoRedraw();
                }
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            this.StoreControls();
            this.DoMiscUpdates();
            base.Hide();
        }


        void btnSaveFolder_Click(object sender, EventArgs e)
        {
            this.fbdSave.SelectedPath = this.lblSaveFolder.Text;
            if (this.fbdSave.ShowDialog() == DialogResult.OK)
            {
                this.lblSaveFolder.Text = this.fbdSave.SelectedPath;
            }
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
            base.Enabled = false;
            IMessager iLoadFrm = null;
            clsXMLUpdate.eCheckResponse eCheckResponse = clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
            if (eCheckResponse != clsXMLUpdate.eCheckResponse.Updates & eCheckResponse != clsXMLUpdate.eCheckResponse.FailedWithMessage)
            {
                Interaction.MsgBox("No Updates.", MsgBoxStyle.Information, "Update Check");
            }
            if (eCheckResponse == clsXMLUpdate.eCheckResponse.Updates && clsXmlUpdate.RestartNeeded && Interaction.MsgBox("Exit Now?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Update Downloaded") == MsgBoxResult.Yes && !this.myParent.CloseCommand())
            {
                clsXMLUpdate.LaunchSelfUpdate();
                ProjectData.EndApp();
            }
            this.myParent.RefreshInfo();
            base.Enabled = true;
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
            for (int index = 0; index <= num; index++)
            {
                MidsContext.Config.Suppression += values[this.clbSuppression.CheckedIndices[index]];
            }
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
            if (this.csList.Items.Count > 0)
            {
                frmExportColor frmExportColor = new frmExportColor(ref MidsContext.Config.Export.ColorSchemes[this.csList.SelectedIndex]);
                if (frmExportColor.ShowDialog() == DialogResult.OK)
                {
                    MidsContext.Config.Export.ColorSchemes[this.csList.SelectedIndex].Assign(frmExportColor.myScheme);
                    this.csPopulateList(-1);
                }
                base.BringToFront();
            }
        }


        void csDelete_Click(object sender, EventArgs e)
        {
            if (this.csList.Items.Count > 0 && Interaction.MsgBox("Delete " + this.csList.SelectedItem.ToString() + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.RemoveScheme(this.csList.SelectedIndex);
                this.csPopulateList(-1);
            }
        }


        void csList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Conversions.ToString(e.KeyChar) == "[")
            {
                this.forumColorUp();
            }
            else if (Conversions.ToString(e.KeyChar) == "]")
            {
                this.ForumColorDown();
            }
        }


        void csPopulateList(int HighlightID = -1)
        {
            this.csList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.ColorSchemes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.csList.Items.Add(export.ColorSchemes[index].SchemeName);
            }
            if (this.csList.Items.Count > 0 & HighlightID == -1)
            {
                this.csList.SelectedIndex = 0;
            }
            if (HighlightID < this.csList.Items.Count & HighlightID > -1)
            {
                this.csList.SelectedIndex = HighlightID;
            }
        }


        void csReset_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will remove all of the colour schemes and replace them with the defaults. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.ResetColorsToDefaults();
                this.csPopulateList(-1);
            }
        }


        public void DoMiscUpdates()
        {
            this.myParent.GetBestDamageValues();
            this.myParent.RefreshInfo();
            this.myParent.DisplayName();
            this.myParent.I9Picker.LastLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
            if (this.myParent.myDataView != null)
            {
                this.myParent.myDataView.SetFontData();
            }
            if (this.myParent.dvLastPower > -1)
            {
                this.myParent.Info_Power(this.myParent.dvLastPower, this.myParent.dvLastEnh, this.myParent.dvLastNoLev, this.myParent.DataViewLocked);
            }
            if (this.myParent.Drawing != null)
            {
                this.myParent.DoRedraw();
            }
            this.myParent.UpdateColours(false);
        }


        void fcAdd_Click(object sender, EventArgs e)
        {
            MidsContext.Config.Export.AddCodes();
            this.fcPopulateList(MidsContext.Config.Export.FormatCode.Length - 1);
        }


        void fcBoldOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].BoldOff = this.fcBoldOff.Text;
            }
        }


        void fcBoldOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].BoldOn = this.fcBoldOn.Text;
            }
        }


        void fcColorOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ColourOff = this.fcColorOff.Text;
            }
        }


        void fcColorOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ColourOn = this.fcColorOn.Text;
            }
        }


        void fcDelete_Click(object sender, EventArgs e)
        {
            if (this.fcList.Items.Count > 0 && Interaction.MsgBox("Delete " + this.fcList.SelectedItem.ToString() + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.RemoveCodes(this.fcList.SelectedIndex);
                this.fcPopulateList(-1);
            }
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
                this.fcWSSpace.Checked = (formatCode[selectedIndex].Space == ExportConfig.WhiteSpace.Space);
                this.fcWSTab.Checked = (formatCode[selectedIndex].Space == ExportConfig.WhiteSpace.Tab);
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
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ItalicOff = this.fcItalicOff.Text;
            }
        }


        void fcItalicOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ItalicOn = this.fcItalicOn.Text;
            }
        }


        void fcList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Conversions.ToString(e.KeyChar) == "[")
            {
                this.forumCodeUp();
            }
            else if (Conversions.ToString(e.KeyChar) == "]")
            {
                this.ForumCodeDown();
            }
        }


        void fcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fcDisplay();
        }


        void fcNotes_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].Notes = this.fcNotes.Text;
            }
        }


        void fcPopulateList(int HighlightID = -1)
        {
            this.fcList.Items.Clear();
            ExportConfig export = MidsContext.Config.Export;
            int num = export.FormatCode.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.fcList.Items.Add(export.FormatCode[index].Name);
            }
            if (this.fcList.Items.Count > 0 & HighlightID == -1)
            {
                this.fcList.SelectedIndex = 0;
            }
            if (HighlightID < this.fcList.Items.Count & HighlightID > -1)
            {
                this.fcList.SelectedIndex = HighlightID;
            }
        }


        void fcReset_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will remove all of the formatting code sets and replace them with the default set. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.ResetCodesToDefaults();
                this.fcPopulateList(-1);
            }
        }


        void fcSet_Click(object sender, EventArgs e)
        {
            if (this.fcList.SelectedIndex >= 0)
            {
                MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Name = this.fcName.Text;
                this.fcPopulateList(this.fcList.SelectedIndex);
            }
        }


        void fcTextOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].SizeOff = this.fcTextOff.Text;
            }
        }


        void fcTextOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].SizeOn = this.fcTextOn.Text;
            }
        }


        void fcUnderlineOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].UnderlineOff = this.fcUnderlineOff.Text;
            }
        }


        void fcUnderlineOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].UnderlineOn = this.fcUnderlineOn.Text;
            }
        }


        void fcWSSpace_CheckedChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                if (this.fcWSSpace.Checked)
                {
                    formatCode[selectedIndex].Space = ExportConfig.WhiteSpace.Space;
                }
                else
                {
                    formatCode[selectedIndex].Space = ExportConfig.WhiteSpace.Tab;
                }
            }
        }


        protected void ForumCodeDown()
        {
            int selectedIndex = this.fcList.SelectedIndex;
            if (selectedIndex < this.fcList.Items.Count - 1)
            {
                ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[2];
                formatCodesArray[0].Assign(MidsContext.Config.Export.FormatCode[selectedIndex]);
                formatCodesArray[1].Assign(MidsContext.Config.Export.FormatCode[selectedIndex + 1]);
                MidsContext.Config.Export.FormatCode[selectedIndex].Assign(formatCodesArray[1]);
                MidsContext.Config.Export.FormatCode[selectedIndex + 1].Assign(formatCodesArray[0]);
                this.fcPopulateList(-1);
                if (selectedIndex + 1 > -1 & this.fcList.Items.Count > selectedIndex + 1)
                {
                    this.fcList.SelectedIndex = selectedIndex + 1;
                }
                else if (this.fcList.Items.Count > 0)
                {
                    this.fcList.SelectedIndex = 0;
                }
            }
        }


        protected void forumCodeUp()
        {
            int selectedIndex = this.fcList.SelectedIndex;
            if (selectedIndex >= 1)
            {
                ExportConfig.FormatCodes[] formatCodesArray = new ExportConfig.FormatCodes[2];
                formatCodesArray[0].Assign(MidsContext.Config.Export.FormatCode[selectedIndex]);
                formatCodesArray[1].Assign(MidsContext.Config.Export.FormatCode[selectedIndex - 1]);
                MidsContext.Config.Export.FormatCode[selectedIndex].Assign(formatCodesArray[1]);
                MidsContext.Config.Export.FormatCode[selectedIndex - 1].Assign(formatCodesArray[0]);
                this.fcPopulateList(-1);
                if (selectedIndex - 1 > -1 & this.fcList.Items.Count > selectedIndex - 1)
                {
                    this.fcList.SelectedIndex = selectedIndex - 1;
                }
                else if (this.fcList.Items.Count > 0)
                {
                    this.fcList.SelectedIndex = 0;
                }
            }
        }


        protected void ForumColorDown()
        {
            int selectedIndex = this.csList.SelectedIndex;
            if (selectedIndex < this.csList.Items.Count - 1)
            {
                ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[2];
                colorSchemeArray[0].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex]);
                colorSchemeArray[1].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex + 1]);
                MidsContext.Config.Export.ColorSchemes[selectedIndex].Assign(colorSchemeArray[1]);
                MidsContext.Config.Export.ColorSchemes[selectedIndex + 1].Assign(colorSchemeArray[0]);
                this.csPopulateList(-1);
                if (selectedIndex + 1 > -1 & this.csList.Items.Count > selectedIndex + 1)
                {
                    this.csList.SelectedIndex = selectedIndex + 1;
                }
                else if (this.csList.Items.Count > 0)
                {
                    this.csList.SelectedIndex = 0;
                }
            }
        }


        protected void forumColorUp()
        {
            int selectedIndex = this.csList.SelectedIndex;
            if (selectedIndex >= 1)
            {
                ExportConfig.ColorScheme[] colorSchemeArray = new ExportConfig.ColorScheme[2];
                colorSchemeArray[0].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex]);
                colorSchemeArray[1].Assign(MidsContext.Config.Export.ColorSchemes[selectedIndex - 1]);
                MidsContext.Config.Export.ColorSchemes[selectedIndex].Assign(colorSchemeArray[1]);
                MidsContext.Config.Export.ColorSchemes[selectedIndex - 1].Assign(colorSchemeArray[0]);
                this.csPopulateList(-1);
                if (selectedIndex - 1 > -1 & this.csList.Items.Count > selectedIndex - 1)
                {
                    this.csList.SelectedIndex = selectedIndex - 1;
                }
                else if (this.csList.Items.Count > 0)
                {
                    this.csList.SelectedIndex = 0;
                }
            }
        }


        void frmCalcOpt_Closing(object sender, CancelEventArgs e)
        {
            if (base.DialogResult == DialogResult.Abort)
            {
                e.Cancel = true;
            }
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


        void listScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblExample.Text = this.scenarioExample[this.listScenarios.SelectedIndex];
            this.cmbAction.Items.Clear();
            this.cmbAction.Items.AddRange(this.scenActs[this.listScenarios.SelectedIndex]);
            this.cmbAction.SelectedIndex = (int)this.defActs[this.listScenarios.SelectedIndex];
        }


        void optDO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optDO.Checked)
            {
                this.optEnh.Text = "Dual Origin";
            }
        }


        void optSO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optSO.Checked)
            {
                this.optEnh.Text = "Single Origin";
            }
        }


        void optTO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optTO.Checked)
            {
                this.optEnh.Text = "Training Origin";
            }
        }


        void PopulateSuppression()
        {
            this.clbSuppression.BeginUpdate();
            this.clbSuppression.Items.Clear();
            string[] names = Enum.GetNames(MidsContext.Config.Suppression.GetType());
            int[] values = (int[])Enum.GetValues(MidsContext.Config.Suppression.GetType());
            int num = names.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.clbSuppression.Items.Add(names[index], (MidsContext.Config.Suppression & (Enums.eSuppress)values[index]) != Enums.eSuppress.None);
            }
            this.clbSuppression.EndUpdate();
        }


        void SetControls()
        {
            ConfigData config = MidsContext.Config;
            this.optSO.Checked = (config.CalcEnhOrigin == Enums.eEnhGrade.SingleO);
            this.optDO.Checked = (config.CalcEnhOrigin == Enums.eEnhGrade.DualO);
            this.optTO.Checked = (config.CalcEnhOrigin == Enums.eEnhGrade.TrainingO);
            this.cbEnhLevel.SelectedIndex = (int)config.CalcEnhLevel;
            this.udExHigh.Value = new decimal(config.ExempHigh);
            this.udExLow.Value = new decimal(config.ExempLow);
            this.udForceLevel.Value = new decimal(config.ForceLevel);
            this.chkHighVis.Checked = config.EnhanceVisibility;
            this.rbGraphTwoLine.Checked = (config.DataGraphType == Enums.eDDGraph.Both);
            this.rbGraphStacked.Checked = (config.DataGraphType == Enums.eDDGraph.Stacked);
            this.rbGraphSimple.Checked = (config.DataGraphType == Enums.eDDGraph.Simple);
            this.rbPvE.Checked = config.Inc.PvE;
            this.rbPvP.Checked = !config.Inc.PvE;
            this.rbChanceAverage.Checked = (config.DamageMath.Calculate == ConfigData.EDamageMath.Average);
            this.rbChanceMax.Checked = (config.DamageMath.Calculate == ConfigData.EDamageMath.Max);
            this.rbChanceIgnore.Checked = (config.DamageMath.Calculate == ConfigData.EDamageMath.Minimum);
            this.udBaseToHit.Value = new decimal(config.BaseAcc * 100f);
            this.chkVillainColour.Checked = config.ShowVillainColours;
            this.chkUpdates.Checked = config.CheckForUpdates;
            if (decimal.Compare(new decimal(config.I9.DefaultIOLevel + 1), this.udIOLevel.Maximum) > 0)
            {
                this.udIOLevel.Value = this.udIOLevel.Maximum;
            }
            else
            {
                this.udIOLevel.Value = new decimal(config.I9.DefaultIOLevel + 1);
            }
            this.chkIOLevel.Checked = config.I9.DisplayIOLevels;
            this.chkIOEffects.Checked = config.I9.CalculateEnahncementFX;
            this.chkSetBonus.Checked = config.I9.CalculateSetBonusFX;
            this.chkRelSignOnly.Checked = config.ShowRelSymbols;
            this.chkIOPrintLevels.Checked = config.I9.PrintIOLevels;
            this.chkColourPrint.Checked = config.PrintInColour;
            this.udRTFSize.Value = new decimal((double)config.RtFont.RTFBase / 2.0);
            this.udStatSize.Value = new decimal(config.RtFont.PairedBase);
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
            this.TeamSize.Value = new decimal(config.TeamSize);
            int index = 0;
            do
            {
                this.defActs[index] = config.DragDropScenarioAction[index];
                index++;
            }
            while (index <= 19);
        }


        public void SetTips()
        {
        }


        void setupScenarios()
        {
            int num = 0;
            this.scenarioExample[num] = "Swap a travel power with a power taken at level 2.";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Move/swap power to its lowest possible level";
            this.scenActs[num][3] = "Allow power to be moved anyway (mark as invalid)";
            num++;
            this.scenarioExample[num] = "Move a Primary power from level 35 into the level 44 slot of a character with 4 epic powers.";
            this.scenActs[num] = new string[3];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Move to the last power that isn't at its min level";
            num++;
            this.scenarioExample[num] = "Power taken at level 2 with two level 3 slots is swapped with level 4, where there is a power with one slot.";
            this.scenActs[num] = new string[7];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Remove slots";
            this.scenActs[num][3] = "Mark invalid slots";
            this.scenActs[num][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[num][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[num][6] = "Rearrange all slots in build";
            num++;
            this.scenarioExample[num] = "A 6-slotted power taken at level 41 is moved to level 49.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Remove impossible slots";
            this.scenActs[num][3] = "Allow anyway (Mark slots as invalid)";
            num++;
            this.scenarioExample[num] = "Power taken at level 4 is swapped with power taken at level 14, which is a travel power.";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Overwrite rather than swap";
            this.scenActs[num][3] = "Allow power to be swapped anyway (mark as invalid)";
            num++;
            this.scenarioExample[num] = "Power taken at level 8 is swapped with power taken at level 2, when the level 2 power has level 3 slots.";
            this.scenActs[num] = new string[7];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Remove slots";
            this.scenActs[num][3] = "Mark invalid slots";
            this.scenActs[num][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[num][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[num][6] = "Rearrange all slots in build";
            num++;
            this.scenarioExample[num] = "Pool power taken at level 49 is swapped with a 6-slotted power at level 41.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Remove impossible slots";
            this.scenActs[num][3] = "Allow anyway (Mark slots as invalid)";
            num++;
            this.scenarioExample[num] = "Power taken at level 4 is moved to level 8 when the power taken at level 6 is a pool power.\r\n(Note: If the power in the destination slot fails to shift, the 'Moved or swapped too low' scenario applies.)";
            this.scenActs[num] = new string[5];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Shift other powers around it";
            this.scenActs[num][3] = "Overwrite it; leave previous power slot empty";
            this.scenActs[num][4] = "Allow anyway (mark as invalid)";
            num++;
            this.scenarioExample[num] = "Power taken at level 8 has level 9 slots, and a power is being moved from level 12 to level 6, so the power at 8 is shifting up to 10.";
            this.scenActs[num] = new string[7];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Remove slots";
            this.scenActs[num][3] = "Mark invalid slots";
            this.scenActs[num][4] = "Swap slot levels if valid; remove invalid ones";
            this.scenActs[num][5] = "Swap slot levels if valid; mark invalid ones";
            this.scenActs[num][6] = "Rearrange all slots in build";
            num++;
            this.scenarioExample[num] = "Power taken at level 47 has 6 slots, and a power is being moved from level 49 to level 44, so the power at 47 is shifting to 49.\r\n(Note: if the remaining slots have invalid levels after impossible slots are removed, the action set for that scenario will be taken.)";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Remove impossible slots";
            this.scenActs[num][3] = "Allow anyway (Mark slots as invalid)";
            num++;
            this.scenarioExample[num] = "Power taken at level 8 is being moved to 14, and the level 10 slot is blank.";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Fill empty slot; don't move powers unnecessarily";
            this.scenActs[num][3] = "Shift empty slot as if it were a power";
            num++;
            this.scenarioExample[num] = "Power placed at its minimum level is being shifted up.\r\n(Note: If and only the power in the destination slot fails to shift due to this setting, the next scenario applies.)";
            this.scenActs[num] = new string[4];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Shift it along with the other powers";
            this.scenActs[num][3] = "Shift other powers around it";
            num++;
            this.scenarioExample[num] = "You chose to shift other powers around ones that are at their minimum levels, but you are moving a power in place of one that is at its minimum level. (This will never occur if you chose 'Cancel' or 'Shift it along with the other powers' from the previous scenario.)";
            this.scenActs[num] = new string[5];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Unlock and shift all level-locked powers";
            this.scenActs[num][3] = "Shift destination power to the first valid and empty slot";
            this.scenActs[num][4] = "Swap instead of move";
            num++;
            this.scenarioExample[num] = "Click and drag a level 21 slot from a level 20 power to a level 44 power.";
            this.scenActs[num] = new string[3];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Allow swap anyway (mark as invalid)";
            num++;
            this.scenarioExample[num] = "Click and drag a slot from a level 44 power to a level 20 power in place of a level 21 slot.";
            this.scenActs[num] = new string[3];
            this.scenActs[num][0] = "Show dialog";
            this.scenActs[num][1] = "Cancel";
            this.scenActs[num][2] = "Allow swap anyway (mark as invalid)";
            num++;
        }


        void StoreControls()
        {
            ConfigData config = MidsContext.Config;
            if (this.optSO.Checked)
            {
                config.CalcEnhOrigin = Enums.eEnhGrade.SingleO;
            }
            else if (this.optDO.Checked)
            {
                config.CalcEnhOrigin = Enums.eEnhGrade.DualO;
            }
            else if (this.optTO.Checked)
            {
                config.CalcEnhOrigin = Enums.eEnhGrade.TrainingO;
            }
            config.CalcEnhLevel = (Enums.eEnhRelative)this.cbEnhLevel.SelectedIndex;
            config.ExempHigh = Convert.ToInt32(this.udExHigh.Value);
            config.ExempLow = Convert.ToInt32(this.udExLow.Value);
            if (config.ExempHigh < config.ExempLow)
            {
                config.ExempHigh = config.ExempLow;
            }
            config.ForceLevel = Convert.ToInt32(this.udForceLevel.Value);
            if (this.rbGraphTwoLine.Checked)
            {
                config.DataGraphType = Enums.eDDGraph.Both;
            }
            else if (this.rbGraphStacked.Checked)
            {
                config.DataGraphType = Enums.eDDGraph.Stacked;
            }
            else if (this.rbGraphSimple.Checked)
            {
                config.DataGraphType = Enums.eDDGraph.Simple;
            }
            config.Inc.PvE = this.rbPvE.Checked;
            if (this.rbChanceAverage.Checked)
            {
                config.DamageMath.Calculate = ConfigData.EDamageMath.Average;
            }
            else if (this.rbChanceMax.Checked)
            {
                config.DamageMath.Calculate = ConfigData.EDamageMath.Max;
            }
            else if (this.rbChanceIgnore.Checked)
            {
                config.DamageMath.Calculate = ConfigData.EDamageMath.Minimum;
            }
            config.BaseAcc = Convert.ToSingle(decimal.Divide(this.udBaseToHit.Value, 100m));
            config.ShowVillainColours = this.chkVillainColour.Checked;
            config.CheckForUpdates = this.chkUpdates.Checked;
            config.I9.DefaultIOLevel = Convert.ToInt32(this.udIOLevel.Value) - 1;
            config.I9.DisplayIOLevels = this.chkIOLevel.Checked;
            config.I9.CalculateEnahncementFX = this.chkIOEffects.Checked;
            config.I9.CalculateSetBonusFX = this.chkSetBonus.Checked;
            config.ShowRelSymbols = this.chkRelSignOnly.Checked;
            config.I9.PrintIOLevels = this.chkIOPrintLevels.Checked;
            config.PrintInColour = this.chkColourPrint.Checked;
            config.RtFont.RTFBase = Convert.ToInt32(decimal.Multiply(this.udRTFSize.Value, 2m));
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
                index++;
            }
            while (index <= 19);
        }


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


        [AccessedThroughProperty("cbEnhLevel")]
        ComboBox _cbEnhLevel;


        [AccessedThroughProperty("chkColorInherent")]
        CheckBox _chkColorInherent;


        [AccessedThroughProperty("chkColourPrint")]
        CheckBox _chkColourPrint;


        [AccessedThroughProperty("chkHighVis")]
        CheckBox _chkHighVis;


        [AccessedThroughProperty("chkIOEffects")]
        CheckBox _chkIOEffects;


        [AccessedThroughProperty("chkIOLevel")]
        CheckBox _chkIOLevel;


        [AccessedThroughProperty("chkIOPrintLevels")]
        CheckBox _chkIOPrintLevels;


        [AccessedThroughProperty("chkLoadLastFile")]
        CheckBox _chkLoadLastFile;


        [AccessedThroughProperty("chkMiddle")]
        CheckBox _chkMiddle;


        [AccessedThroughProperty("chkNoTips")]
        CheckBox _chkNoTips;


        [AccessedThroughProperty("chkRelSignOnly")]
        CheckBox _chkRelSignOnly;


        [AccessedThroughProperty("chkSetBonus")]
        CheckBox _chkSetBonus;


        [AccessedThroughProperty("chkShowAlphaPopup")]
        CheckBox _chkShowAlphaPopup;


        [AccessedThroughProperty("chkStatBold")]
        CheckBox _chkStatBold;


        [AccessedThroughProperty("chkTextBold")]
        CheckBox _chkTextBold;


        [AccessedThroughProperty("chkUpdates")]
        CheckBox _chkUpdates;


        [AccessedThroughProperty("chkUseArcanaTime")]
        CheckBox _chkUseArcanaTime;


        [AccessedThroughProperty("chkVillainColour")]
        CheckBox _chkVillainColour;


        [AccessedThroughProperty("clbSuppression")]
        CheckedListBox _clbSuppression;


        [AccessedThroughProperty("cmbAction")]
        ComboBox _cmbAction;


        [AccessedThroughProperty("cPicker")]
        ColorDialog _cPicker;


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


        [AccessedThroughProperty("fbdSave")]
        FolderBrowserDialog _fbdSave;


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


        [AccessedThroughProperty("fcName")]
        TextBox _fcName;


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


        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox10")]
        GroupBox _GroupBox10;


        [AccessedThroughProperty("GroupBox11")]
        GroupBox _GroupBox11;


        [AccessedThroughProperty("GroupBox12")]
        GroupBox _GroupBox12;


        [AccessedThroughProperty("GroupBox13")]
        GroupBox _GroupBox13;


        [AccessedThroughProperty("GroupBox14")]
        GroupBox _GroupBox14;


        [AccessedThroughProperty("GroupBox15")]
        GroupBox _GroupBox15;


        [AccessedThroughProperty("GroupBox16")]
        GroupBox _GroupBox16;


        [AccessedThroughProperty("GroupBox17")]
        GroupBox _GroupBox17;


        [AccessedThroughProperty("GroupBox2")]
        GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        GroupBox _GroupBox3;


        [AccessedThroughProperty("GroupBox4")]
        GroupBox _GroupBox4;


        [AccessedThroughProperty("GroupBox5")]
        GroupBox _GroupBox5;


        [AccessedThroughProperty("GroupBox6")]
        GroupBox _GroupBox6;


        [AccessedThroughProperty("GroupBox7")]
        GroupBox _GroupBox7;


        [AccessedThroughProperty("GroupBox8")]
        GroupBox _GroupBox8;


        [AccessedThroughProperty("GroupBox9")]
        GroupBox _GroupBox9;


        [AccessedThroughProperty("Label1")]
        Label _Label1;


        [AccessedThroughProperty("Label10")]
        Label _Label10;


        [AccessedThroughProperty("Label11")]
        Label _Label11;


        [AccessedThroughProperty("Label12")]
        Label _Label12;


        [AccessedThroughProperty("Label13")]
        Label _Label13;


        [AccessedThroughProperty("Label14")]
        Label _Label14;


        [AccessedThroughProperty("Label15")]
        Label _Label15;


        [AccessedThroughProperty("Label16")]
        Label _Label16;


        [AccessedThroughProperty("Label19")]
        Label _Label19;


        [AccessedThroughProperty("Label2")]
        Label _Label2;


        [AccessedThroughProperty("Label20")]
        Label _Label20;


        [AccessedThroughProperty("Label21")]
        Label _Label21;


        [AccessedThroughProperty("Label22")]
        Label _Label22;


        [AccessedThroughProperty("Label24")]
        Label _Label24;


        [AccessedThroughProperty("Label25")]
        Label _Label25;


        [AccessedThroughProperty("Label26")]
        Label _Label26;


        [AccessedThroughProperty("Label27")]
        Label _Label27;


        [AccessedThroughProperty("Label28")]
        Label _Label28;


        [AccessedThroughProperty("Label29")]
        Label _Label29;


        [AccessedThroughProperty("Label3")]
        Label _Label3;


        [AccessedThroughProperty("Label30")]
        Label _Label30;


        [AccessedThroughProperty("Label31")]
        Label _Label31;


        [AccessedThroughProperty("Label32")]
        Label _Label32;


        [AccessedThroughProperty("Label33")]
        Label _Label33;


        [AccessedThroughProperty("Label34")]
        Label _Label34;


        [AccessedThroughProperty("Label36")]
        Label _Label36;


        [AccessedThroughProperty("Label37")]
        Label _Label37;


        [AccessedThroughProperty("Label38")]
        Label _Label38;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("Label40")]
        Label _Label40;


        [AccessedThroughProperty("Label5")]
        Label _Label5;


        [AccessedThroughProperty("Label6")]
        Label _Label6;


        [AccessedThroughProperty("Label7")]
        Label _Label7;


        [AccessedThroughProperty("Label8")]
        Label _Label8;


        [AccessedThroughProperty("Label9")]
        Label _Label9;


        [AccessedThroughProperty("lblExample")]
        Label _lblExample;


        [AccessedThroughProperty("lblSaveFolder")]
        Label _lblSaveFolder;


        [AccessedThroughProperty("listScenarios")]
        ListBox _listScenarios;


        [AccessedThroughProperty("myTip")]
        ToolTip _myTip;


        [AccessedThroughProperty("optDO")]
        RadioButton _optDO;


        [AccessedThroughProperty("optEnh")]
        Label _optEnh;


        [AccessedThroughProperty("optSO")]
        RadioButton _optSO;


        [AccessedThroughProperty("optTO")]
        RadioButton _optTO;


        [AccessedThroughProperty("rbChanceAverage")]
        RadioButton _rbChanceAverage;


        [AccessedThroughProperty("rbChanceIgnore")]
        RadioButton _rbChanceIgnore;


        [AccessedThroughProperty("rbChanceMax")]
        RadioButton _rbChanceMax;


        [AccessedThroughProperty("rbGraphSimple")]
        RadioButton _rbGraphSimple;


        [AccessedThroughProperty("rbGraphStacked")]
        RadioButton _rbGraphStacked;


        [AccessedThroughProperty("rbGraphTwoLine")]
        RadioButton _rbGraphTwoLine;


        [AccessedThroughProperty("rbPvE")]
        RadioButton _rbPvE;


        [AccessedThroughProperty("rbPvP")]
        RadioButton _rbPvP;


        [AccessedThroughProperty("TabControl1")]
        TabControl _TabControl1;


        [AccessedThroughProperty("TabPage1")]
        TabPage _TabPage1;


        [AccessedThroughProperty("TabPage2")]
        TabPage _TabPage2;


        [AccessedThroughProperty("TabPage3")]
        TabPage _TabPage3;


        [AccessedThroughProperty("TabPage4")]
        TabPage _TabPage4;


        [AccessedThroughProperty("TabPage5")]
        TabPage _TabPage5;


        [AccessedThroughProperty("TabPage6")]
        TabPage _TabPage6;


        [AccessedThroughProperty("TeamSize")]
        NumericUpDown _TeamSize;


        [AccessedThroughProperty("txtUpdatePath")]
        TextBox _txtUpdatePath;


        [AccessedThroughProperty("udBaseToHit")]
        NumericUpDown _udBaseToHit;


        [AccessedThroughProperty("udExHigh")]
        NumericUpDown _udExHigh;


        [AccessedThroughProperty("udExLow")]
        NumericUpDown _udExLow;


        [AccessedThroughProperty("udForceLevel")]
        NumericUpDown _udForceLevel;


        [AccessedThroughProperty("udIOLevel")]
        NumericUpDown _udIOLevel;


        [AccessedThroughProperty("udRTFSize")]
        NumericUpDown _udRTFSize;


        [AccessedThroughProperty("udStatSize")]
        NumericUpDown _udStatSize;


        short[] defActs;


        protected bool fcNoUpdate;


        public frmMain myParent;


        string[][] scenActs;


        string[] scenarioExample;
    }
}
