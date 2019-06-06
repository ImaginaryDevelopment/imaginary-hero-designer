using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmPowerEffect : Form
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
        internal virtual Button btnCopy
        {
            get
            {
                return this._btnCopy;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCopy_Click);
                if (this._btnCopy != null)
                {
                    this._btnCopy.Click -= eventHandler;
                }
                this._btnCopy = value;
                if (this._btnCopy != null)
                {
                    this._btnCopy.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnCSV
        {
            get
            {
                return this._btnCSV;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCSV_Click);
                if (this._btnCSV != null)
                {
                    this._btnCSV.Click -= eventHandler;
                }
                this._btnCSV = value;
                if (this._btnCSV != null)
                {
                    this._btnCSV.Click += eventHandler;
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
        internal virtual Button btnPaste
        {
            get
            {
                return this._btnPaste;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPaste_Click);
                if (this._btnPaste != null)
                {
                    this._btnPaste.Click -= eventHandler;
                }
                this._btnPaste = value;
                if (this._btnPaste != null)
                {
                    this._btnPaste.Click += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbAffects
        {
            get
            {
                return this._cbAffects;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAffects_SelectedIndexChanged);
                if (this._cbAffects != null)
                {
                    this._cbAffects.SelectedIndexChanged -= eventHandler;
                }
                this._cbAffects = value;
                if (this._cbAffects != null)
                {
                    this._cbAffects.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbAspect
        {
            get
            {
                return this._cbAspect;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAspect_SelectedIndexChanged);
                if (this._cbAspect != null)
                {
                    this._cbAspect.SelectedIndexChanged -= eventHandler;
                }
                this._cbAspect = value;
                if (this._cbAspect != null)
                {
                    this._cbAspect.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbAttribute
        {
            get
            {
                return this._cbAttribute;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbAttribute_SelectedIndexChanged);
                if (this._cbAttribute != null)
                {
                    this._cbAttribute.SelectedIndexChanged -= eventHandler;
                }
                this._cbAttribute = value;
                if (this._cbAttribute != null)
                {
                    this._cbAttribute.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbFXClass
        {
            get
            {
                return this._cbFXClass;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbFXClass_SelectedIndexChanged);
                if (this._cbFXClass != null)
                {
                    this._cbFXClass.SelectedIndexChanged -= eventHandler;
                }
                this._cbFXClass = value;
                if (this._cbFXClass != null)
                {
                    this._cbFXClass.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbFXSpecialCase
        {
            get
            {
                return this._cbFXSpecialCase;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbFXSpecialCase_SelectedIndexChanged);
                if (this._cbFXSpecialCase != null)
                {
                    this._cbFXSpecialCase.SelectedIndexChanged -= eventHandler;
                }
                this._cbFXSpecialCase = value;
                if (this._cbFXSpecialCase != null)
                {
                    this._cbFXSpecialCase.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbModifier
        {
            get
            {
                return this._cbModifier;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbModifier_SelectedIndexChanged);
                if (this._cbModifier != null)
                {
                    this._cbModifier.SelectedIndexChanged -= eventHandler;
                }
                this._cbModifier = value;
                if (this._cbModifier != null)
                {
                    this._cbModifier.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbPercentageOverride
        {
            get
            {
                return this._cbPercentageOverride;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbPercentageOverride_SelectedIndexChanged);
                if (this._cbPercentageOverride != null)
                {
                    this._cbPercentageOverride.SelectedIndexChanged -= eventHandler;
                }
                this._cbPercentageOverride = value;
                if (this._cbPercentageOverride != null)
                {
                    this._cbPercentageOverride.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkFXBuffable
        {
            get
            {
                return this._chkFXBuffable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkFXBuffable_CheckedChanged);
                if (this._chkFXBuffable != null)
                {
                    this._chkFXBuffable.CheckedChanged -= eventHandler;
                }
                this._chkFXBuffable = value;
                if (this._chkFXBuffable != null)
                {
                    this._chkFXBuffable.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkFXResistable
        {
            get
            {
                return this._chkFXResistable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkFXResistable_CheckedChanged);
                if (this._chkFXResistable != null)
                {
                    this._chkFXResistable.CheckedChanged -= eventHandler;
                }
                this._chkFXResistable = value;
                if (this._chkFXResistable != null)
                {
                    this._chkFXResistable.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkNearGround
        {
            get
            {
                return this._chkNearGround;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chkNearGround = value;
            }
        }
        internal virtual CheckBox chkStack
        {
            get
            {
                return this._chkStack;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkFxNoStack_CheckedChanged);
                if (this._chkStack != null)
                {
                    this._chkStack.CheckedChanged -= eventHandler;
                }
                this._chkStack = value;
                if (this._chkStack != null)
                {
                    this._chkStack.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkVariable
        {
            get
            {
                return this._chkVariable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkVariable_CheckedChanged);
                if (this._chkVariable != null)
                {
                    this._chkVariable.CheckedChanged -= eventHandler;
                }
                this._chkVariable = value;
                if (this._chkVariable != null)
                {
                    this._chkVariable.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual ColumnHeader chSub
        {
            get
            {
                return this._chSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chSub = value;
            }
        }
        internal virtual ColumnHeader chSubSub
        {
            get
            {
                return this._chSubSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._chSubSub = value;
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
        internal virtual ComboBox cmbEffectId
        {
            get
            {
                return this._cmbEffectId;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cmbEffectId_TextChanged);
                if (this._cmbEffectId != null)
                {
                    this._cmbEffectId.TextChanged -= eventHandler;
                }
                this._cmbEffectId = value;
                if (this._cmbEffectId != null)
                {
                    this._cmbEffectId.TextChanged += eventHandler;
                }
            }
        }
        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this._ColumnHeader1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader1 = value;
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
        internal virtual CheckBox IgnoreED
        {
            get
            {
                return this._IgnoreED;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.IgnoreED_CheckedChanged);
                if (this._IgnoreED != null)
                {
                    this._IgnoreED.CheckedChanged -= eventHandler;
                }
                this._IgnoreED = value;
                if (this._IgnoreED != null)
                {
                    this._IgnoreED.CheckedChanged += eventHandler;
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
        internal virtual Label Label23
        {
            get
            {
                return this._Label23;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label23 = value;
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
        internal virtual Label lblAffectsCaster
        {
            get
            {
                return this._lblAffectsCaster;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAffectsCaster = value;
            }
        }
        internal virtual Label lblEffectDescription
        {
            get
            {
                return this._lblEffectDescription;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblEffectDescription = value;
            }
        }
        internal virtual Label lblProb
        {
            get
            {
                return this._lblProb;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblProb = value;
            }
        }
        internal virtual ListView lvEffectType
        {
            get
            {
                return this._lvEffectType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvEffectType_SelectedIndexChanged);
                if (this._lvEffectType != null)
                {
                    this._lvEffectType.SelectedIndexChanged -= eventHandler;
                }
                this._lvEffectType = value;
                if (this._lvEffectType != null)
                {
                    this._lvEffectType.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ListView lvSubAttribute
        {
            get
            {
                return this._lvSubAttribute;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSubAttribute_SelectedIndexChanged);
                if (this._lvSubAttribute != null)
                {
                    this._lvSubAttribute.SelectedIndexChanged -= eventHandler;
                }
                this._lvSubAttribute = value;
                if (this._lvSubAttribute != null)
                {
                    this._lvSubAttribute.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ListView lvSubSub
        {
            get
            {
                return this._lvSubSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSubSub_SelectedIndexChanged);
                if (this._lvSubSub != null)
                {
                    this._lvSubSub.SelectedIndexChanged -= eventHandler;
                }
                this._lvSubSub = value;
                if (this._lvSubSub != null)
                {
                    this._lvSubSub.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbIfAny
        {
            get
            {
                return this._rbIfAny;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
                if (this._rbIfAny != null)
                {
                    this._rbIfAny.CheckedChanged -= eventHandler;
                }
                this._rbIfAny = value;
                if (this._rbIfAny != null)
                {
                    this._rbIfAny.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbIfCritter
        {
            get
            {
                return this._rbIfCritter;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
                if (this._rbIfCritter != null)
                {
                    this._rbIfCritter.CheckedChanged -= eventHandler;
                }
                this._rbIfCritter = value;
                if (this._rbIfCritter != null)
                {
                    this._rbIfCritter.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbIfPlayer
        {
            get
            {
                return this._rbIfPlayer;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
                if (this._rbIfPlayer != null)
                {
                    this._rbIfPlayer.CheckedChanged -= eventHandler;
                }
                this._rbIfPlayer = value;
                if (this._rbIfPlayer != null)
                {
                    this._rbIfPlayer.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtFXDelay
        {
            get
            {
                return this._txtFXDelay;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXDelay_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXDelay_TextChanged);
                if (this._txtFXDelay != null)
                {
                    this._txtFXDelay.Leave -= eventHandler;
                    this._txtFXDelay.TextChanged -= eventHandler2;
                }
                this._txtFXDelay = value;
                if (this._txtFXDelay != null)
                {
                    this._txtFXDelay.Leave += eventHandler;
                    this._txtFXDelay.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual TextBox txtFXDuration
        {
            get
            {
                return this._txtFXDuration;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXDuration_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXDuration_TextChanged);
                if (this._txtFXDuration != null)
                {
                    this._txtFXDuration.Leave -= eventHandler;
                    this._txtFXDuration.TextChanged -= eventHandler2;
                }
                this._txtFXDuration = value;
                if (this._txtFXDuration != null)
                {
                    this._txtFXDuration.Leave += eventHandler;
                    this._txtFXDuration.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual TextBox txtFXMag
        {
            get
            {
                return this._txtFXMag;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXMag_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXMag_TextChanged);
                if (this._txtFXMag != null)
                {
                    this._txtFXMag.Leave -= eventHandler;
                    this._txtFXMag.TextChanged -= eventHandler2;
                }
                this._txtFXMag = value;
                if (this._txtFXMag != null)
                {
                    this._txtFXMag.Leave += eventHandler;
                    this._txtFXMag.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual TextBox txtFXProb
        {
            get
            {
                return this._txtFXProb;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXProb_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXProb_TextChanged);
                if (this._txtFXProb != null)
                {
                    this._txtFXProb.Leave -= eventHandler;
                    this._txtFXProb.TextChanged -= eventHandler2;
                }
                this._txtFXProb = value;
                if (this._txtFXProb != null)
                {
                    this._txtFXProb.Leave += eventHandler;
                    this._txtFXProb.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual TextBox txtFXScale
        {
            get
            {
                return this._txtFXScale;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXScale_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXScale_TextChanged);
                if (this._txtFXScale != null)
                {
                    this._txtFXScale.Leave -= eventHandler;
                    this._txtFXScale.TextChanged -= eventHandler2;
                }
                this._txtFXScale = value;
                if (this._txtFXScale != null)
                {
                    this._txtFXScale.Leave += eventHandler;
                    this._txtFXScale.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual TextBox txtFXTicks
        {
            get
            {
                return this._txtFXTicks;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtFXTicks_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtFXTicks_TextChanged);
                if (this._txtFXTicks != null)
                {
                    this._txtFXTicks.Leave -= eventHandler;
                    this._txtFXTicks.TextChanged -= eventHandler2;
                }
                this._txtFXTicks = value;
                if (this._txtFXTicks != null)
                {
                    this._txtFXTicks.Leave += eventHandler;
                    this._txtFXTicks.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual TextBox txtOverride
        {
            get
            {
                return this._txtOverride;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtOverride_TextChanged);
                if (this._txtOverride != null)
                {
                    this._txtOverride.TextChanged -= eventHandler;
                }
                this._txtOverride = value;
                if (this._txtOverride != null)
                {
                    this._txtOverride.TextChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtPPM
        {
            get
            {
                return this._txtPPM;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtPPM_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtPPM_Leave);
                if (this._txtPPM != null)
                {
                    this._txtPPM.TextChanged -= eventHandler;
                    this._txtPPM.Leave -= eventHandler2;
                }
                this._txtPPM = value;
                if (this._txtPPM != null)
                {
                    this._txtPPM.TextChanged += eventHandler;
                    this._txtPPM.Leave += eventHandler2;
                }
            }
        }
        public frmPowerEffect(ref IEffect iFX)
        {
            base.Load += this.frmPowerEffect_Load;
            this.Loading = true;
            this.InitializeComponent();
            this.myFX = (IEffect)iFX.Clone();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }
        void btnCopy_Click(object sender, EventArgs e)
        {
            this.FullCopy();
        }
        void btnCSV_Click(object sender, EventArgs e)
        {
            IEffect effect = (IEffect)this.myFX.Clone();
            try
            {
                effect.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, null);
                return;
            }
            this.myFX.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
            this.DisplayEffectData();
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            this.StoreSuppression();
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }
        void btnPaste_Click(object sender, EventArgs e)
        {
            this.FullPaste();
        }
        void cbAffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbAffects.SelectedIndex >= 0)
            {
                this.myFX.ToWho = (Enums.eToWho)this.cbAffects.SelectedIndex;
                this.lblAffectsCaster.Text = "";
                if (this.myFX.Power != null && (this.myFX.Power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                {
                    this.lblAffectsCaster.Text = "Power also affects Self";
                }
                this.UpdateFXText();
            }
        }
        void cbAspect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbAspect.SelectedIndex >= 0)
            {
                this.myFX.Aspect = (Enums.eAspect)this.cbAspect.SelectedIndex;
                this.UpdateFXText();
            }
        }
        void cbAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbAttribute.SelectedIndex >= 0)
            {
                this.myFX.AttribType = (Enums.eAttribType)this.cbAttribute.SelectedIndex;
                this.UpdateFXText();
            }
        }
        void cbFXClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.EffectClass = (Enums.eEffectClass)this.cbFXClass.SelectedIndex;
                this.UpdateFXText();
            }
        }
        void cbFXSpecialCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.SpecialCase = (Enums.eSpecialCase)this.cbFXSpecialCase.SelectedIndex;
                this.UpdateFXText();
            }
        }
        void cbModifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbModifier.SelectedIndex >= 0)
            {
                this.myFX.ModifierTable = this.cbModifier.Text;
                this.myFX.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.myFX.ModifierTable);
                this.UpdateFXText();
            }
        }
        void cbPercentageOverride_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.cbPercentageOverride.SelectedIndex >= 0)
            {
                this.myFX.DisplayPercentageOverride = (Enums.eOverrideBoolean)this.cbPercentageOverride.SelectedIndex;
                this.UpdateFXText();
            }
        }
        void chkFXBuffable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.Buffable = !this.chkFXBuffable.Checked;
                this.UpdateFXText();
            }
        }
        void chkFxNoStack_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                if (this.chkStack.Checked)
                {
                    effect.Stacking = Enums.eStacking.Yes;
                }
                else
                {
                    effect.Stacking = Enums.eStacking.No;
                }
                this.UpdateFXText();
            }
        }
        void chkFXResistable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.Resistible = !this.chkFXResistable.Checked;
                this.UpdateFXText();
            }
        }
        void chkVariable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.VariableModifiedOverride = this.chkVariable.Checked;
                this.UpdateFXText();
            }
        }
        void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StoreSuppression();
            this.UpdateFXText();
        }
        void cmbEffectId_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.EffectId = this.cmbEffectId.Text;
                this.UpdateFXText();
            }
        }
        public void DisplayEffectData()
        {
            string Style = "####0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##";
            IEffect fx = this.myFX;
            this.cbPercentageOverride.SelectedIndex = (int)fx.DisplayPercentageOverride;
            this.txtFXScale.Text = Strings.Format(fx.Scale, Style);
            this.txtFXDuration.Text = Strings.Format(fx.nDuration, Style);
            this.txtFXMag.Text = Strings.Format(fx.nMagnitude, Style);
            this.cmbEffectId.Text = fx.EffectId;
            this.txtFXTicks.Text = Strings.Format(fx.Ticks, "####0");
            this.txtOverride.Text = fx.Override;
            this.txtFXDelay.Text = Strings.Format(fx.DelayedTime, Style);
            this.txtFXProb.Text = Strings.Format(fx.BaseProbability, Style);
            this.lblProb.Text = "(" + Strings.Format(fx.BaseProbability * 100f, "####0") + "%)";
            this.cbAttribute.SelectedIndex = (int)fx.AttribType;
            this.cbAspect.SelectedIndex = (int)fx.Aspect;
            this.cbModifier.SelectedIndex = DatabaseAPI.NidFromUidAttribMod(fx.ModifierTable);
            this.lblAffectsCaster.Text = "";
            if (fx.ToWho == Enums.eToWho.All)
            {
                this.cbAffects.SelectedIndex = 1;
            }
            else
            {
                this.cbAffects.SelectedIndex = (int)fx.ToWho;
            }
            if (fx.Power != null && (fx.Power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
            {
                this.lblAffectsCaster.Text = "Power also affects Self";
            }
            this.rbIfAny.Checked = (fx.PvMode == Enums.ePvX.Any);
            this.rbIfCritter.Checked = (fx.PvMode == Enums.ePvX.PvE);
            this.rbIfPlayer.Checked = (fx.PvMode == Enums.ePvX.PvP);
            this.chkStack.Checked = (fx.Stacking == Enums.eStacking.Yes);
            this.chkFXBuffable.Checked = !fx.Buffable;
            this.chkFXResistable.Checked = !fx.Resistible;
            this.chkNearGround.Checked = fx.NearGround;
            this.IgnoreED.Checked = fx.IgnoreED;
            this.cbFXSpecialCase.SelectedIndex = (int)fx.SpecialCase;
            this.cbFXClass.SelectedIndex = (int)fx.EffectClass;
            this.chkVariable.Checked = fx.VariableModifiedOverride;
            this.clbSuppression.BeginUpdate();
            this.clbSuppression.Items.Clear();
            string[] names = Enum.GetNames(fx.Suppression.GetType());
            int[] values = (int[])Enum.GetValues(fx.Suppression.GetType());
            int num = names.Length - 1;
            for (int index2 = 0; index2 <= num; index2++)
            {
                this.clbSuppression.Items.Add(names[index2], (fx.Suppression & (Enums.eSuppress)values[index2]) != Enums.eSuppress.None);
            }
            this.clbSuppression.EndUpdate();
            this.lvEffectType.BeginUpdate();
            this.lvEffectType.Items.Clear();
            int index3 = -1;
            string[] names2 = Enum.GetNames(fx.EffectType.GetType());
            int num2 = names2.Length - 1;
            for (int index2 = 0; index2 <= num2; index2++)
            {
                this.lvEffectType.Items.Add(names2[index2]);
                if (index2 == (int)fx.EffectType)
                {
                    index3 = index2;
                }
            }
            if (index3 > -1)
            {
                this.lvEffectType.Items[index3].Selected = true;
                this.lvEffectType.Items[index3].EnsureVisible();
            }
            this.lvEffectType.EndUpdate();
            this.UpdateEffectSubAttribList();
        }
        void FillComboBoxes()
        {
            this.cbFXClass.BeginUpdate();
            this.cbFXSpecialCase.BeginUpdate();
            this.cbPercentageOverride.BeginUpdate();
            this.cbAttribute.BeginUpdate();
            this.cbAspect.BeginUpdate();
            this.cbModifier.BeginUpdate();
            this.cbAffects.BeginUpdate();
            this.cbFXClass.Items.Clear();
            this.cbFXSpecialCase.Items.Clear();
            this.cbPercentageOverride.Items.Clear();
            this.cbAttribute.Items.Clear();
            this.cbAspect.Items.Clear();
            this.cbModifier.Items.Clear();
            this.cbAffects.Items.Clear();
            this.cbFXClass.Items.AddRange(Enum.GetNames(this.myFX.EffectClass.GetType()));
            this.cbFXSpecialCase.Items.AddRange(Enum.GetNames(this.myFX.SpecialCase.GetType()));
            this.cbPercentageOverride.Items.Add("Auto");
            this.cbPercentageOverride.Items.Add("Yes");
            this.cbPercentageOverride.Items.Add("No");
            this.cbAttribute.Items.AddRange(Enum.GetNames(this.myFX.AttribType.GetType()));
            this.cbAspect.Items.AddRange(Enum.GetNames(this.myFX.Aspect.GetType()));
            int num = DatabaseAPI.Database.AttribMods.Modifier.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbModifier.Items.Add(DatabaseAPI.Database.AttribMods.Modifier[index].ID);
            }
            this.cbAffects.Items.Add("None");
            this.cbAffects.Items.Add("Target");
            this.cbAffects.Items.Add("Self");
            this.cbFXClass.EndUpdate();
            this.cbFXSpecialCase.EndUpdate();
            this.cbPercentageOverride.EndUpdate();
            this.cbAttribute.EndUpdate();
            this.cbAspect.EndUpdate();
            this.cbModifier.EndUpdate();
            this.cbAffects.EndUpdate();
            string[] strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
            int num2 = DatabaseAPI.Database.EffectIds.Count - 1;
            for (int index = 0; index <= num2; index++)
            {
                strArray[index] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index]);
            }
            if (strArray.Length > 0)
            {
                int num3 = strArray.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    this.cmbEffectId.Items.Add(strArray[index2]);
                }
                this.lvSubAttribute.Enabled = true;
            }
        }
        void frmPowerEffect_Load(object sender, EventArgs e)
        {
            this.FillComboBoxes();
            this.DisplayEffectData();
            if (this.myFX.Power != null)
            {
                this.Text = "Edit Effect " + Conversions.ToString(this.myFX.nID) + " for: " + this.myFX.Power.FullName;
            }
            else if (this.myFX.Enhancement != null)
            {
                this.Text = "Edit Effect for: " + this.myFX.Enhancement.UID;
            }
            else
            {
                this.Text = "Edit Effect";
            }
            this.Loading = false;
            this.UpdateFXText();
        }
        void FullCopy()
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            this.myFX.StoreTo(ref writer);
            writer.Close();
            DataObject dataObject = new DataObject(format.Name, memoryStream.GetBuffer());
            Clipboard.SetDataObject(dataObject);
            memoryStream.Close();
        }
        void FullPaste()
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
            if (!Clipboard.ContainsData(format.Name))
            {
                Interaction.MsgBox("No effect data on the clipboard!", MsgBoxStyle.Information, "Unable to Paste");
            }
            else
            {
                byte[] buffer = (byte[])Clipboard.GetDataObject().GetData(format.Name);
                MemoryStream memoryStream = new MemoryStream(buffer);
                BinaryReader reader = new BinaryReader(memoryStream);
                string powerFullName = this.myFX.PowerFullName;
                IPower power = this.myFX.Power;
                IEnhancement enhancement = this.myFX.Enhancement;
                this.myFX = new Effect(reader);
                this.myFX.PowerFullName = powerFullName;
                this.myFX.Power = power;
                this.myFX.Enhancement = enhancement;
                this.DisplayEffectData();
                reader.Close();
                memoryStream.Close();
            }
        }
        void IgnoreED_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.IgnoreED = this.IgnoreED.Checked;
                this.UpdateFXText();
            }
        }
        void lvEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lvEffectType.SelectedIndices.Count >= 1)
            {
                this.myFX.EffectType = (Enums.eEffectType)this.lvEffectType.SelectedIndices[0];
                this.UpdateEffectSubAttribList();
                this.UpdateFXText();
            }
        }
        void lvSubAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lvSubAttribute.SelectedIndices.Count >= 1)
            {
                IEffect fx = this.myFX;
                if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance)
                {
                    fx.DamageType = (Enums.eDamage)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
                {
                    fx.MezType = (Enums.eMez)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.ResEffect)
                {
                    fx.ETModifies = (Enums.eEffectType)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.EntCreate)
                {
                    fx.Summon = this.lvSubAttribute.SelectedItems[0].Text;
                }
                else if (fx.EffectType == Enums.eEffectType.Enhancement)
                {
                    fx.ETModifies = (Enums.eEffectType)this.lvSubAttribute.SelectedIndices[0];
                }
                else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
                {
                    fx.Reward = this.lvSubAttribute.SelectedItems[0].Text;
                }
                this.UpdateFXText();
                this.UpdateSubSubList();
            }
        }
        void lvSubSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lvSubSub.SelectedIndices.Count >= 1)
            {
                IEffect fx = this.myFX;
                if (fx.EffectType == Enums.eEffectType.Enhancement & fx.ETModifies == Enums.eEffectType.Mez)
                {
                    fx.MezType = (Enums.eMez)this.lvSubSub.SelectedIndices[0];
                }
                this.UpdateFXText();
            }
        }
        void rbIfACP_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                if (this.rbIfCritter.Checked)
                {
                    effect.PvMode = Enums.ePvX.PvE;
                }
                else if (this.rbIfPlayer.Checked)
                {
                    effect.PvMode = Enums.ePvX.PvP;
                }
                else
                {
                    effect.PvMode = Enums.ePvX.Any;
                }
                this.UpdateFXText();
            }
        }
        void StoreSuppression()
        {
            int[] values = (int[])Enum.GetValues(this.myFX.Suppression.GetType());
            this.myFX.Suppression = Enums.eSuppress.None;
            int num = this.clbSuppression.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.myFX.Suppression += values[this.clbSuppression.CheckedIndices[index]];
            }
        }
        void txtFXDelay_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXDelay.Text = Conversions.ToString(effect.DelayedTime);
                this.UpdateFXText();
            }
        }
        void txtFXDelay_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXDelay.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    fx.DelayedTime = num;
                }
                this.UpdateFXText();
            }
        }
        void txtFXDuration_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXDuration.Text = Strings.Format(effect.nDuration, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##");
                this.UpdateFXText();
            }
        }
        void txtFXDuration_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXDuration.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    fx.nDuration = num;
                }
                this.UpdateFXText();
            }
        }
        void txtFXMag_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXMag.Text = Conversions.ToString(effect.nMagnitude);
                this.UpdateFXText();
            }
        }
        void txtFXMag_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                string InputStr = this.txtFXMag.Text;
                if (InputStr.EndsWith("%"))
                {
                    InputStr = InputStr.Substring(0, InputStr.Length - 1);
                }
                float num = (float)Conversion.Val(InputStr);
                if (num >= -2.147484E+09f & num <= 2.147484E+09f)
                {
                    fx.nMagnitude = num;
                }
                this.UpdateFXText();
            }
        }
        void txtFXProb_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXProb.Text = Conversions.ToString(effect.BaseProbability);
                this.UpdateFXText();
            }
        }
        void txtFXProb_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXProb.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    if (num > 1f)
                    {
                        num /= 100f;
                    }
                    fx.BaseProbability = num;
                    this.lblProb.Text = "(" + Strings.Format(fx.BaseProbability * 100f, "###0") + "%)";
                }
                this.UpdateFXText();
            }
        }
        void txtFXScale_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXScale.Text = Strings.Format(effect.Scale, "####0.0##");
                this.UpdateFXText();
            }
        }
        void txtFXScale_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                string InputStr = this.txtFXScale.Text;
                if (InputStr.EndsWith("%"))
                {
                    InputStr = InputStr.Substring(0, InputStr.Length - 1);
                }
                float num = (float)Conversion.Val(InputStr);
                if (num >= -2.147484E+09f & num <= 2.147484E+09f)
                {
                    fx.Scale = num;
                }
                this.UpdateFXText();
            }
        }
        void txtFXTicks_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect effect = this.myFX;
                this.txtFXTicks.Text = Conversions.ToString(effect.Ticks);
                this.UpdateFXText();
            }
        }
        void txtFXTicks_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                IEffect fx = this.myFX;
                float num = (float)Conversion.Val(this.txtFXTicks.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    fx.Ticks = (int)Math.Round((double)num);
                }
                this.UpdateFXText();
            }
        }
        void txtOverride_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myFX.Override = this.txtOverride.Text;
                this.UpdateFXText();
            }
        }
        void txtPPM_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.txtPPM.Text = Conversions.ToString(this.myFX.ProcsPerMinute);
            }
        }
        void txtPPM_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                float num = (float)Conversion.Val(this.txtPPM.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    this.myFX.ProcsPerMinute = num;
                }
            }
        }
        public void UpdateEffectSubAttribList()
        {
            int index = 0;
            this.lvSubAttribute.BeginUpdate();
            this.lvSubAttribute.Items.Clear();
            string[] strArray = new string[0];
            IEffect fx = this.myFX;
            if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance | fx.EffectType == Enums.eEffectType.Elusivity)
            {
                strArray = Enum.GetNames(fx.DamageType.GetType());
                index = (int)fx.DamageType;
                this.lvSubAttribute.Columns[0].Text = "Damage Type / Vector";
            }
            else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
            {
                strArray = Enum.GetNames(fx.MezType.GetType());
                index = (int)fx.MezType;
                this.lvSubAttribute.Columns[0].Text = "Mez Type";
            }
            else if (fx.EffectType == Enums.eEffectType.ResEffect)
            {
                strArray = Enum.GetNames(fx.EffectType.GetType());
                index = (int)fx.ETModifies;
                this.lvSubAttribute.Columns[0].Text = "Effect Type";
            }
            else if (fx.EffectType == Enums.eEffectType.EntCreate)
            {
                strArray = new string[DatabaseAPI.Database.Entities.Length - 1 + 1];
                string lower = fx.Summon.ToLower();
                int num = DatabaseAPI.Database.Entities.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    strArray[index2] = DatabaseAPI.Database.Entities[index2].UID;
                    if (strArray[index2].ToLower() == lower)
                    {
                        index = index2;
                    }
                }
                this.lvSubAttribute.Columns[0].Text = "Entity Name";
            }
            else if (fx.EffectType == Enums.eEffectType.GrantPower)
            {
                strArray = new string[DatabaseAPI.Database.Power.Length - 1 + 1];
                string lower2 = fx.Summon.ToLower();
                int num2 = DatabaseAPI.Database.Power.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    strArray[index2] = DatabaseAPI.Database.Power[index2].FullName;
                    if (strArray[index2].ToLower() == lower2)
                    {
                        index = index2;
                    }
                }
                this.lvSubAttribute.Columns[0].Text = "Power Name";
            }
            else if (fx.EffectType == Enums.eEffectType.Enhancement)
            {
                strArray = Enum.GetNames(fx.EffectType.GetType());
                index = (int)fx.ETModifies;
                this.lvSubAttribute.Columns[0].Text = "Effect Type";
            }
            else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
            {
                strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
                string lower3 = fx.Reward.ToLower();
                int num3 = DatabaseAPI.Database.EffectIds.Count - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    strArray[index2] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index2]);
                    if (strArray[index2].ToLower() == lower3)
                    {
                        index = index2;
                    }
                }
                this.lvSubAttribute.Columns[0].Text = "GlobalChanceMod Flag";
            }
            if (strArray.Length > 0)
            {
                int num4 = strArray.Length - 1;
                for (int index3 = 0; index3 <= num4; index3++)
                {
                    this.lvSubAttribute.Items.Add(strArray[index3]);
                }
                this.lvSubAttribute.Enabled = true;
            }
            else
            {
                this.lvSubAttribute.Enabled = false;
                this.chSub.Text = "";
            }
            if (this.lvSubAttribute.Items.Count > index)
            {
                this.lvSubAttribute.Items[index].Selected = true;
                this.lvSubAttribute.Items[index].EnsureVisible();
            }
            this.lvSubAttribute.EndUpdate();
            this.UpdateSubSubList();
        }
        void UpdateFXText()
        {
            if (!this.Loading)
            {
                this.lblEffectDescription.Text = this.myFX.BuildEffectString(false, "", false, false, false);
            }
        }
        public void UpdateSubSubList()
        {
            int index = 0;
            this.lvSubSub.BeginUpdate();
            this.lvSubSub.Items.Clear();
            string[] strArray = new string[0];
            IEffect fx = this.myFX;
            if ((fx.EffectType == Enums.eEffectType.Enhancement | fx.EffectType == Enums.eEffectType.ResEffect) & fx.ETModifies == Enums.eEffectType.Mez)
            {
                this.lvSubSub.Columns[0].Text = "Mez Type";
                strArray = Enum.GetNames(fx.MezType.GetType());
                index = (int)fx.MezType;
            }
            if (strArray.Length > 0)
            {
                int num = strArray.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    this.lvSubSub.Items.Add(strArray[index2]);
                }
                this.lvSubSub.Enabled = true;
            }
            else
            {
                this.lvSubSub.Enabled = false;
                this.lvSubSub.Columns[0].Text = "";
            }
            if (this.lvSubSub.Items.Count > index)
            {
                this.lvSubSub.Items[index].Selected = true;
                this.lvSubSub.Items[index].EnsureVisible();
            }
            this.lvSubSub.EndUpdate();
        }
        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;
        [AccessedThroughProperty("btnCopy")]
        Button _btnCopy;
        [AccessedThroughProperty("btnCSV")]
        Button _btnCSV;
        [AccessedThroughProperty("btnOK")]
        Button _btnOK;
        [AccessedThroughProperty("btnPaste")]
        Button _btnPaste;
        [AccessedThroughProperty("cbAffects")]
        ComboBox _cbAffects;
        [AccessedThroughProperty("cbAspect")]
        ComboBox _cbAspect;
        [AccessedThroughProperty("cbAttribute")]
        ComboBox _cbAttribute;
        [AccessedThroughProperty("cbFXClass")]
        ComboBox _cbFXClass;
        [AccessedThroughProperty("cbFXSpecialCase")]
        ComboBox _cbFXSpecialCase;
        [AccessedThroughProperty("cbModifier")]
        ComboBox _cbModifier;
        [AccessedThroughProperty("cbPercentageOverride")]
        ComboBox _cbPercentageOverride;
        [AccessedThroughProperty("chkFXBuffable")]
        CheckBox _chkFXBuffable;
        [AccessedThroughProperty("chkFXResistable")]
        CheckBox _chkFXResistable;
        [AccessedThroughProperty("chkNearGround")]
        CheckBox _chkNearGround;
        [AccessedThroughProperty("chkStack")]
        CheckBox _chkStack;
        [AccessedThroughProperty("chkVariable")]
        CheckBox _chkVariable;
        [AccessedThroughProperty("chSub")]
        ColumnHeader _chSub;
        [AccessedThroughProperty("chSubSub")]
        ColumnHeader _chSubSub;
        [AccessedThroughProperty("clbSuppression")]
        CheckedListBox _clbSuppression;
        [AccessedThroughProperty("cmbEffectId")]
        ComboBox _cmbEffectId;
        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;
        [AccessedThroughProperty("GroupBox3")]
        GroupBox _GroupBox3;
        [AccessedThroughProperty("IgnoreED")]
        CheckBox _IgnoreED;
        [AccessedThroughProperty("Label1")]
        Label _Label1;
        [AccessedThroughProperty("Label10")]
        Label _Label10;
        [AccessedThroughProperty("Label11")]
        Label _Label11;
        [AccessedThroughProperty("Label2")]
        Label _Label2;
        [AccessedThroughProperty("Label22")]
        Label _Label22;
        [AccessedThroughProperty("Label23")]
        Label _Label23;
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
        [AccessedThroughProperty("Label3")]
        Label _Label3;
        [AccessedThroughProperty("Label30")]
        Label _Label30;
        [AccessedThroughProperty("Label4")]
        Label _Label4;
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
        [AccessedThroughProperty("lblAffectsCaster")]
        Label _lblAffectsCaster;
        [AccessedThroughProperty("lblEffectDescription")]
        Label _lblEffectDescription;
        [AccessedThroughProperty("lblProb")]
        Label _lblProb;
        [AccessedThroughProperty("lvEffectType")]
        ListView _lvEffectType;
        [AccessedThroughProperty("lvSubAttribute")]
        ListView _lvSubAttribute;
        [AccessedThroughProperty("lvSubSub")]
        ListView _lvSubSub;
        [AccessedThroughProperty("rbIfAny")]
        RadioButton _rbIfAny;
        [AccessedThroughProperty("rbIfCritter")]
        RadioButton _rbIfCritter;
        [AccessedThroughProperty("rbIfPlayer")]
        RadioButton _rbIfPlayer;
        [AccessedThroughProperty("txtFXDelay")]
        TextBox _txtFXDelay;
        [AccessedThroughProperty("txtFXDuration")]
        TextBox _txtFXDuration;
        [AccessedThroughProperty("txtFXMag")]
        TextBox _txtFXMag;
        [AccessedThroughProperty("txtFXProb")]
        TextBox _txtFXProb;
        [AccessedThroughProperty("txtFXScale")]
        TextBox _txtFXScale;
        [AccessedThroughProperty("txtFXTicks")]
        TextBox _txtFXTicks;
        [AccessedThroughProperty("txtOverride")]
        TextBox _txtOverride;
        [AccessedThroughProperty("txtPPM")]
        TextBox _txtPPM;
        bool Loading;
        public IEffect myFX;
    }
}
