
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
  public class frmPowerEffect : Form
  {
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnCopy")]
    private Button _btnCopy;
    [AccessedThroughProperty("btnCSV")]
    private Button _btnCSV;
    [AccessedThroughProperty("btnOK")]
    private Button _btnOK;
    [AccessedThroughProperty("btnPaste")]
    private Button _btnPaste;
    [AccessedThroughProperty("cbAffects")]
    private ComboBox _cbAffects;
    [AccessedThroughProperty("cbAspect")]
    private ComboBox _cbAspect;
    [AccessedThroughProperty("cbAttribute")]
    private ComboBox _cbAttribute;
    [AccessedThroughProperty("cbFXClass")]
    private ComboBox _cbFXClass;
    [AccessedThroughProperty("cbFXSpecialCase")]
    private ComboBox _cbFXSpecialCase;
    [AccessedThroughProperty("cbModifier")]
    private ComboBox _cbModifier;
    [AccessedThroughProperty("cbPercentageOverride")]
    private ComboBox _cbPercentageOverride;
    [AccessedThroughProperty("chkFXBuffable")]
    private CheckBox _chkFXBuffable;
    [AccessedThroughProperty("chkFXResistable")]
    private CheckBox _chkFXResistable;
    [AccessedThroughProperty("chkNearGround")]
    private CheckBox _chkNearGround;
    [AccessedThroughProperty("chkStack")]
    private CheckBox _chkStack;
    [AccessedThroughProperty("chkVariable")]
    private CheckBox _chkVariable;
    [AccessedThroughProperty("chSub")]
    private ColumnHeader _chSub;
    [AccessedThroughProperty("chSubSub")]
    private ColumnHeader _chSubSub;
    [AccessedThroughProperty("clbSuppression")]
    private CheckedListBox _clbSuppression;
    [AccessedThroughProperty("cmbEffectId")]
    private ComboBox _cmbEffectId;
    [AccessedThroughProperty("ColumnHeader1")]
    private ColumnHeader _ColumnHeader1;
    [AccessedThroughProperty("GroupBox3")]
    private GroupBox _GroupBox3;
    [AccessedThroughProperty("IgnoreED")]
    private CheckBox _IgnoreED;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label11")]
    private Label _Label11;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("Label22")]
    private Label _Label22;
    [AccessedThroughProperty("Label23")]
    private Label _Label23;
    [AccessedThroughProperty("Label24")]
    private Label _Label24;
    [AccessedThroughProperty("Label25")]
    private Label _Label25;
    [AccessedThroughProperty("Label26")]
    private Label _Label26;
    [AccessedThroughProperty("Label27")]
    private Label _Label27;
    [AccessedThroughProperty("Label28")]
    private Label _Label28;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Label30")]
    private Label _Label30;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;
    [AccessedThroughProperty("Label5")]
    private Label _Label5;
    [AccessedThroughProperty("Label6")]
    private Label _Label6;
    [AccessedThroughProperty("Label7")]
    private Label _Label7;
    [AccessedThroughProperty("Label8")]
    private Label _Label8;
    [AccessedThroughProperty("Label9")]
    private Label _Label9;
    [AccessedThroughProperty("lblAffectsCaster")]
    private Label _lblAffectsCaster;
    [AccessedThroughProperty("lblEffectDescription")]
    private Label _lblEffectDescription;
    [AccessedThroughProperty("lblProb")]
    private Label _lblProb;
    [AccessedThroughProperty("lvEffectType")]
    private ListView _lvEffectType;
    [AccessedThroughProperty("lvSubAttribute")]
    private ListView _lvSubAttribute;
    [AccessedThroughProperty("lvSubSub")]
    private ListView _lvSubSub;
    [AccessedThroughProperty("rbIfAny")]
    private RadioButton _rbIfAny;
    [AccessedThroughProperty("rbIfCritter")]
    private RadioButton _rbIfCritter;
    [AccessedThroughProperty("rbIfPlayer")]
    private RadioButton _rbIfPlayer;
    [AccessedThroughProperty("txtFXDelay")]
    private TextBox _txtFXDelay;
    [AccessedThroughProperty("txtFXDuration")]
    private TextBox _txtFXDuration;
    [AccessedThroughProperty("txtFXMag")]
    private TextBox _txtFXMag;
    [AccessedThroughProperty("txtFXProb")]
    private TextBox _txtFXProb;
    [AccessedThroughProperty("txtFXScale")]
    private TextBox _txtFXScale;
    [AccessedThroughProperty("txtFXTicks")]
    private TextBox _txtFXTicks;
    [AccessedThroughProperty("txtOverride")]
    private TextBox _txtOverride;
    [AccessedThroughProperty("txtPPM")]
    private TextBox _txtPPM;
    private IContainer components;
    private bool Loading;
    public IEffect myFX;

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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

    internal virtual Button btnCopy
    {
      get
      {
        return this._btnCopy;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCopy_Click);
        if (this._btnCopy != null)
          this._btnCopy.Click -= eventHandler;
        this._btnCopy = value;
        if (this._btnCopy == null)
          return;
        this._btnCopy.Click += eventHandler;
      }
    }

    internal virtual Button btnCSV
    {
      get
      {
        return this._btnCSV;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCSV_Click);
        if (this._btnCSV != null)
          this._btnCSV.Click -= eventHandler;
        this._btnCSV = value;
        if (this._btnCSV == null)
          return;
        this._btnCSV.Click += eventHandler;
      }
    }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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

    internal virtual Button btnPaste
    {
      get
      {
        return this._btnPaste;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPaste_Click);
        if (this._btnPaste != null)
          this._btnPaste.Click -= eventHandler;
        this._btnPaste = value;
        if (this._btnPaste == null)
          return;
        this._btnPaste.Click += eventHandler;
      }
    }

    internal virtual ComboBox cbAffects
    {
      get
      {
        return this._cbAffects;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbAffects_SelectedIndexChanged);
        if (this._cbAffects != null)
          this._cbAffects.SelectedIndexChanged -= eventHandler;
        this._cbAffects = value;
        if (this._cbAffects == null)
          return;
        this._cbAffects.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbAspect
    {
      get
      {
        return this._cbAspect;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbAspect_SelectedIndexChanged);
        if (this._cbAspect != null)
          this._cbAspect.SelectedIndexChanged -= eventHandler;
        this._cbAspect = value;
        if (this._cbAspect == null)
          return;
        this._cbAspect.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbAttribute
    {
      get
      {
        return this._cbAttribute;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbAttribute_SelectedIndexChanged);
        if (this._cbAttribute != null)
          this._cbAttribute.SelectedIndexChanged -= eventHandler;
        this._cbAttribute = value;
        if (this._cbAttribute == null)
          return;
        this._cbAttribute.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbFXClass
    {
      get
      {
        return this._cbFXClass;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbFXClass_SelectedIndexChanged);
        if (this._cbFXClass != null)
          this._cbFXClass.SelectedIndexChanged -= eventHandler;
        this._cbFXClass = value;
        if (this._cbFXClass == null)
          return;
        this._cbFXClass.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbFXSpecialCase
    {
      get
      {
        return this._cbFXSpecialCase;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbFXSpecialCase_SelectedIndexChanged);
        if (this._cbFXSpecialCase != null)
          this._cbFXSpecialCase.SelectedIndexChanged -= eventHandler;
        this._cbFXSpecialCase = value;
        if (this._cbFXSpecialCase == null)
          return;
        this._cbFXSpecialCase.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbModifier
    {
      get
      {
        return this._cbModifier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbModifier_SelectedIndexChanged);
        if (this._cbModifier != null)
          this._cbModifier.SelectedIndexChanged -= eventHandler;
        this._cbModifier = value;
        if (this._cbModifier == null)
          return;
        this._cbModifier.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbPercentageOverride
    {
      get
      {
        return this._cbPercentageOverride;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbPercentageOverride_SelectedIndexChanged);
        if (this._cbPercentageOverride != null)
          this._cbPercentageOverride.SelectedIndexChanged -= eventHandler;
        this._cbPercentageOverride = value;
        if (this._cbPercentageOverride == null)
          return;
        this._cbPercentageOverride.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkFXBuffable
    {
      get
      {
        return this._chkFXBuffable;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkFXBuffable_CheckedChanged);
        if (this._chkFXBuffable != null)
          this._chkFXBuffable.CheckedChanged -= eventHandler;
        this._chkFXBuffable = value;
        if (this._chkFXBuffable == null)
          return;
        this._chkFXBuffable.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkFXResistable
    {
      get
      {
        return this._chkFXResistable;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkFXResistable_CheckedChanged);
        if (this._chkFXResistable != null)
          this._chkFXResistable.CheckedChanged -= eventHandler;
        this._chkFXResistable = value;
        if (this._chkFXResistable == null)
          return;
        this._chkFXResistable.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkNearGround
    {
      get
      {
        return this._chkNearGround;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkFxNoStack_CheckedChanged);
        if (this._chkStack != null)
          this._chkStack.CheckedChanged -= eventHandler;
        this._chkStack = value;
        if (this._chkStack == null)
          return;
        this._chkStack.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkVariable
    {
      get
      {
        return this._chkVariable;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkVariable_CheckedChanged);
        if (this._chkVariable != null)
          this._chkVariable.CheckedChanged -= eventHandler;
        this._chkVariable = value;
        if (this._chkVariable == null)
          return;
        this._chkVariable.CheckedChanged += eventHandler;
      }
    }

    internal virtual ColumnHeader chSub
    {
      get
      {
        return this._chSub;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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

    internal virtual ComboBox cmbEffectId
    {
      get
      {
        return this._cmbEffectId;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cmbEffectId_TextChanged);
        if (this._cmbEffectId != null)
          this._cmbEffectId.TextChanged -= eventHandler;
        this._cmbEffectId = value;
        if (this._cmbEffectId == null)
          return;
        this._cmbEffectId.TextChanged += eventHandler;
      }
    }

    internal virtual ColumnHeader ColumnHeader1
    {
      get
      {
        return this._ColumnHeader1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.IgnoreED_CheckedChanged);
        if (this._IgnoreED != null)
          this._IgnoreED.CheckedChanged -= eventHandler;
        this._IgnoreED = value;
        if (this._IgnoreED == null)
          return;
        this._IgnoreED.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label1
    {
      get
      {
        return this._Label1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
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
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvEffectType_SelectedIndexChanged);
        if (this._lvEffectType != null)
          this._lvEffectType.SelectedIndexChanged -= eventHandler;
        this._lvEffectType = value;
        if (this._lvEffectType == null)
          return;
        this._lvEffectType.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ListView lvSubAttribute
    {
      get
      {
        return this._lvSubAttribute;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvSubAttribute_SelectedIndexChanged);
        if (this._lvSubAttribute != null)
          this._lvSubAttribute.SelectedIndexChanged -= eventHandler;
        this._lvSubAttribute = value;
        if (this._lvSubAttribute == null)
          return;
        this._lvSubAttribute.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ListView lvSubSub
    {
      get
      {
        return this._lvSubSub;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lvSubSub_SelectedIndexChanged);
        if (this._lvSubSub != null)
          this._lvSubSub.SelectedIndexChanged -= eventHandler;
        this._lvSubSub = value;
        if (this._lvSubSub == null)
          return;
        this._lvSubSub.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbIfAny
    {
      get
      {
        return this._rbIfAny;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
        if (this._rbIfAny != null)
          this._rbIfAny.CheckedChanged -= eventHandler;
        this._rbIfAny = value;
        if (this._rbIfAny == null)
          return;
        this._rbIfAny.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbIfCritter
    {
      get
      {
        return this._rbIfCritter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
        if (this._rbIfCritter != null)
          this._rbIfCritter.CheckedChanged -= eventHandler;
        this._rbIfCritter = value;
        if (this._rbIfCritter == null)
          return;
        this._rbIfCritter.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbIfPlayer
    {
      get
      {
        return this._rbIfPlayer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbIfACP_CheckedChanged);
        if (this._rbIfPlayer != null)
          this._rbIfPlayer.CheckedChanged -= eventHandler;
        this._rbIfPlayer = value;
        if (this._rbIfPlayer == null)
          return;
        this._rbIfPlayer.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtFXDelay
    {
      get
      {
        return this._txtFXDelay;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtFXDelay_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtFXDelay_TextChanged);
        if (this._txtFXDelay != null)
        {
          this._txtFXDelay.Leave -= eventHandler1;
          this._txtFXDelay.TextChanged -= eventHandler2;
        }
        this._txtFXDelay = value;
        if (this._txtFXDelay == null)
          return;
        this._txtFXDelay.Leave += eventHandler1;
        this._txtFXDelay.TextChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtFXDuration
    {
      get
      {
        return this._txtFXDuration;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtFXDuration_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtFXDuration_TextChanged);
        if (this._txtFXDuration != null)
        {
          this._txtFXDuration.Leave -= eventHandler1;
          this._txtFXDuration.TextChanged -= eventHandler2;
        }
        this._txtFXDuration = value;
        if (this._txtFXDuration == null)
          return;
        this._txtFXDuration.Leave += eventHandler1;
        this._txtFXDuration.TextChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtFXMag
    {
      get
      {
        return this._txtFXMag;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtFXMag_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtFXMag_TextChanged);
        if (this._txtFXMag != null)
        {
          this._txtFXMag.Leave -= eventHandler1;
          this._txtFXMag.TextChanged -= eventHandler2;
        }
        this._txtFXMag = value;
        if (this._txtFXMag == null)
          return;
        this._txtFXMag.Leave += eventHandler1;
        this._txtFXMag.TextChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtFXProb
    {
      get
      {
        return this._txtFXProb;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtFXProb_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtFXProb_TextChanged);
        if (this._txtFXProb != null)
        {
          this._txtFXProb.Leave -= eventHandler1;
          this._txtFXProb.TextChanged -= eventHandler2;
        }
        this._txtFXProb = value;
        if (this._txtFXProb == null)
          return;
        this._txtFXProb.Leave += eventHandler1;
        this._txtFXProb.TextChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtFXScale
    {
      get
      {
        return this._txtFXScale;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtFXScale_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtFXScale_TextChanged);
        if (this._txtFXScale != null)
        {
          this._txtFXScale.Leave -= eventHandler1;
          this._txtFXScale.TextChanged -= eventHandler2;
        }
        this._txtFXScale = value;
        if (this._txtFXScale == null)
          return;
        this._txtFXScale.Leave += eventHandler1;
        this._txtFXScale.TextChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtFXTicks
    {
      get
      {
        return this._txtFXTicks;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtFXTicks_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtFXTicks_TextChanged);
        if (this._txtFXTicks != null)
        {
          this._txtFXTicks.Leave -= eventHandler1;
          this._txtFXTicks.TextChanged -= eventHandler2;
        }
        this._txtFXTicks = value;
        if (this._txtFXTicks == null)
          return;
        this._txtFXTicks.Leave += eventHandler1;
        this._txtFXTicks.TextChanged += eventHandler2;
      }
    }

    internal virtual TextBox txtOverride
    {
      get
      {
        return this._txtOverride;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtOverride_TextChanged);
        if (this._txtOverride != null)
          this._txtOverride.TextChanged -= eventHandler;
        this._txtOverride = value;
        if (this._txtOverride == null)
          return;
        this._txtOverride.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtPPM
    {
      get
      {
        return this._txtPPM;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtPPM_TextChanged);
        EventHandler eventHandler2 = new EventHandler(this.txtPPM_Leave);
        if (this._txtPPM != null)
        {
          this._txtPPM.TextChanged -= eventHandler1;
          this._txtPPM.Leave -= eventHandler2;
        }
        this._txtPPM = value;
        if (this._txtPPM == null)
          return;
        this._txtPPM.TextChanged += eventHandler1;
        this._txtPPM.Leave += eventHandler2;
      }
    }

    public frmPowerEffect(ref IEffect iFX)
    {
      this.Load += new EventHandler(this.frmPowerEffect_Load);
      this.Loading = true;
      this.InitializeComponent();
      this.myFX = (IEffect) iFX.Clone();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
      this.FullCopy();
    }

    private void btnCSV_Click(object sender, EventArgs e)
    {
      IEffect effect = (IEffect) this.myFX.Clone();
      try
      {
        effect.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
        return;
      }
      this.myFX.ImportFromCSV(Clipboard.GetDataObject().GetData("System.String", true).ToString());
      this.DisplayEffectData();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.StoreSuppression();
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    private void btnPaste_Click(object sender, EventArgs e)
    {
      this.FullPaste();
    }

    private void cbAffects_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.cbAffects.SelectedIndex < 0)
        return;
      this.myFX.ToWho = (Enums.eToWho) this.cbAffects.SelectedIndex;
      this.lblAffectsCaster.Text = "";
      if (this.myFX.Power != null && (this.myFX.Power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
        this.lblAffectsCaster.Text = "Power also affects Self";
      this.UpdateFXText();
    }

    private void cbAspect_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.cbAspect.SelectedIndex < 0)
        return;
      this.myFX.Aspect = (Enums.eAspect) this.cbAspect.SelectedIndex;
      this.UpdateFXText();
    }

    private void cbAttribute_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.cbAttribute.SelectedIndex < 0)
        return;
      this.myFX.AttribType = (Enums.eAttribType) this.cbAttribute.SelectedIndex;
      this.UpdateFXText();
    }

    private void cbFXClass_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.EffectClass = (Enums.eEffectClass) this.cbFXClass.SelectedIndex;
      this.UpdateFXText();
    }

    private void cbFXSpecialCase_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.SpecialCase = (Enums.eSpecialCase) this.cbFXSpecialCase.SelectedIndex;
      this.UpdateFXText();
    }

    private void cbModifier_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.cbModifier.SelectedIndex < 0)
        return;
      this.myFX.ModifierTable = this.cbModifier.Text;
      this.myFX.nModifierTable = DatabaseAPI.NidFromUidAttribMod(this.myFX.ModifierTable);
      this.UpdateFXText();
    }

    private void cbPercentageOverride_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.cbPercentageOverride.SelectedIndex < 0)
        return;
      this.myFX.DisplayPercentageOverride = (Enums.eOverrideBoolean) this.cbPercentageOverride.SelectedIndex;
      this.UpdateFXText();
    }

    private void chkFXBuffable_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.Buffable = !this.chkFXBuffable.Checked;
      this.UpdateFXText();
    }

    private void chkFxNoStack_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.Stacking = !this.chkStack.Checked ? Enums.eStacking.No : Enums.eStacking.Yes;
      this.UpdateFXText();
    }

    private void chkFXResistable_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.Resistible = !this.chkFXResistable.Checked;
      this.UpdateFXText();
    }

    private void chkVariable_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.VariableModifiedOverride = this.chkVariable.Checked;
      this.UpdateFXText();
    }

    private void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.StoreSuppression();
      this.UpdateFXText();
    }

    private void cmbEffectId_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.EffectId = this.cmbEffectId.Text;
      this.UpdateFXText();
    }

    public void DisplayEffectData()
    {
      string Style = "####0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##";
      IEffect fx = this.myFX;
      this.cbPercentageOverride.SelectedIndex = (int) fx.DisplayPercentageOverride;
      this.txtFXScale.Text = Strings.Format((object) fx.Scale, Style);
      this.txtFXDuration.Text = Strings.Format((object) fx.nDuration, Style);
      this.txtFXMag.Text = Strings.Format((object) fx.nMagnitude, Style);
      this.cmbEffectId.Text = fx.EffectId;
      this.txtFXTicks.Text = Strings.Format((object) fx.Ticks, "####0");
      this.txtOverride.Text = fx.Override;
      this.txtFXDelay.Text = Strings.Format((object) fx.DelayedTime, Style);
      this.txtFXProb.Text = Strings.Format((object) fx.BaseProbability, Style);
      this.lblProb.Text = "(" + Strings.Format((object) (float) ((double) fx.BaseProbability * 100.0), "####0") + "%)";
      this.cbAttribute.SelectedIndex = (int) fx.AttribType;
      this.cbAspect.SelectedIndex = (int) fx.Aspect;
      this.cbModifier.SelectedIndex = DatabaseAPI.NidFromUidAttribMod(fx.ModifierTable);
      this.lblAffectsCaster.Text = "";
      if (fx.ToWho == Enums.eToWho.All)
        this.cbAffects.SelectedIndex = 1;
      else
        this.cbAffects.SelectedIndex = (int) fx.ToWho;
      if (fx.Power != null && (fx.Power.EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
        this.lblAffectsCaster.Text = "Power also affects Self";
      this.rbIfAny.Checked = fx.PvMode == Enums.ePvX.Any;
      this.rbIfCritter.Checked = fx.PvMode == Enums.ePvX.PvE;
      this.rbIfPlayer.Checked = fx.PvMode == Enums.ePvX.PvP;
      this.chkStack.Checked = fx.Stacking == Enums.eStacking.Yes;
      this.chkFXBuffable.Checked = !fx.Buffable;
      this.chkFXResistable.Checked = !fx.Resistible;
      this.chkNearGround.Checked = fx.NearGround;
      this.IgnoreED.Checked = fx.IgnoreED;
      this.cbFXSpecialCase.SelectedIndex = (int) fx.SpecialCase;
      this.cbFXClass.SelectedIndex = (int) fx.EffectClass;
      this.chkVariable.Checked = fx.VariableModifiedOverride;
      this.clbSuppression.BeginUpdate();
      this.clbSuppression.Items.Clear();
      string[] names1 = Enum.GetNames(fx.Suppression.GetType());
      int[] values = (int[]) Enum.GetValues(fx.Suppression.GetType());
      int num1 = names1.Length - 1;
      for (int index = 0; index <= num1; ++index)
        this.clbSuppression.Items.Add((object) names1[index], (fx.Suppression & (Enums.eSuppress) values[index]) != Enums.eSuppress.None);
      this.clbSuppression.EndUpdate();
      this.lvEffectType.BeginUpdate();
      this.lvEffectType.Items.Clear();
      int index1 = -1;
      string[] names2 = Enum.GetNames(fx.EffectType.GetType());
      int num2 = names2.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
      {
        this.lvEffectType.Items.Add(names2[index2]);
        if ((Enums.eEffectType) index2 == fx.EffectType)
          index1 = index2;
      }
      if (index1 > -1)
      {
        this.lvEffectType.Items[index1].Selected = true;
        this.lvEffectType.Items[index1].EnsureVisible();
      }
      this.lvEffectType.EndUpdate();
      this.UpdateEffectSubAttribList();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void FillComboBoxes()
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
      this.cbFXClass.Items.AddRange((object[]) Enum.GetNames(this.myFX.EffectClass.GetType()));
      this.cbFXSpecialCase.Items.AddRange((object[]) Enum.GetNames(this.myFX.SpecialCase.GetType()));
      this.cbPercentageOverride.Items.Add((object) "Auto");
      this.cbPercentageOverride.Items.Add((object) "Yes");
      this.cbPercentageOverride.Items.Add((object) "No");
      this.cbAttribute.Items.AddRange((object[]) Enum.GetNames(this.myFX.AttribType.GetType()));
      this.cbAspect.Items.AddRange((object[]) Enum.GetNames(this.myFX.Aspect.GetType()));
      int num1 = DatabaseAPI.Database.AttribMods.Modifier.Length - 1;
      for (int index = 0; index <= num1; ++index)
        this.cbModifier.Items.Add((object) DatabaseAPI.Database.AttribMods.Modifier[index].ID);
      this.cbAffects.Items.Add((object) "None");
      this.cbAffects.Items.Add((object) "Target");
      this.cbAffects.Items.Add((object) "Self");
      this.cbFXClass.EndUpdate();
      this.cbFXSpecialCase.EndUpdate();
      this.cbPercentageOverride.EndUpdate();
      this.cbAttribute.EndUpdate();
      this.cbAspect.EndUpdate();
      this.cbModifier.EndUpdate();
      this.cbAffects.EndUpdate();
      string[] strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
      int num2 = DatabaseAPI.Database.EffectIds.Count - 1;
      for (int index = 0; index <= num2; ++index)
        strArray[index] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index]);
      if (strArray.Length <= 0)
        return;
      int num3 = strArray.Length - 1;
      for (int index = 0; index <= num3; ++index)
        this.cmbEffectId.Items.Add((object) strArray[index]);
      this.lvSubAttribute.Enabled = true;
    }

    private void frmPowerEffect_Load(object sender, EventArgs e)
    {
      this.FillComboBoxes();
      this.DisplayEffectData();
      if (this.myFX.Power != null)
        this.Text = "Edit Effect " + Conversions.ToString(this.myFX.nID) + " for: " + this.myFX.Power.FullName;
      else if (this.myFX.Enhancement != null)
        this.Text = "Edit Effect for: " + this.myFX.Enhancement.UID;
      else
        this.Text = "Edit Effect";
      this.Loading = false;
      this.UpdateFXText();
    }

    private void FullCopy()
    {
      DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
      MemoryStream memoryStream = new MemoryStream();
      BinaryWriter writer = new BinaryWriter((Stream) memoryStream);
      this.myFX.StoreTo(ref writer);
      writer.Close();
      Clipboard.SetDataObject((object) new DataObject(format.Name, (object) memoryStream.GetBuffer()));
      memoryStream.Close();
    }

    private void FullPaste()
    {
      DataFormats.Format format = DataFormats.GetFormat("mhdEffectBIN");
      if (!Clipboard.ContainsData(format.Name))
      {
        int num = (int) Interaction.MsgBox((object) "No effect data on the clipboard!", MsgBoxStyle.Information, (object) "Unable to Paste");
      }
      else
      {
        MemoryStream memoryStream = new MemoryStream((byte[]) Clipboard.GetDataObject().GetData(format.Name));
        BinaryReader reader = new BinaryReader((Stream) memoryStream);
        string powerFullName = this.myFX.PowerFullName;
        IPower power = this.myFX.Power;
        IEnhancement enhancement = this.myFX.Enhancement;
        this.myFX = (IEffect) new Effect(reader);
        this.myFX.PowerFullName = powerFullName;
        this.myFX.Power = power;
        this.myFX.Enhancement = enhancement;
        this.DisplayEffectData();
        reader.Close();
        memoryStream.Close();
      }
    }

    private void IgnoreED_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.IgnoreED = this.IgnoreED.Checked;
      this.UpdateFXText();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmPowerEffect));
      this.btnPaste = new Button();
      this.btnCopy = new Button();
      this.chkStack = new CheckBox();
      this.GroupBox3 = new GroupBox();
      this.clbSuppression = new CheckedListBox();
      this.Label27 = new Label();
      this.rbIfPlayer = new RadioButton();
      this.rbIfCritter = new RadioButton();
      this.rbIfAny = new RadioButton();
      this.chkFXResistable = new CheckBox();
      this.chkFXBuffable = new CheckBox();
      this.Label26 = new Label();
      this.txtFXProb = new TextBox();
      this.Label25 = new Label();
      this.txtFXDelay = new TextBox();
      this.Label24 = new Label();
      this.txtFXTicks = new TextBox();
      this.Label23 = new Label();
      this.txtFXDuration = new TextBox();
      this.Label22 = new Label();
      this.txtFXMag = new TextBox();
      this.Label28 = new Label();
      this.Label30 = new Label();
      this.cbFXClass = new ComboBox();
      this.cbFXSpecialCase = new ComboBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.lblEffectDescription = new Label();
      this.chkVariable = new CheckBox();
      this.cbPercentageOverride = new ComboBox();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.txtFXScale = new TextBox();
      this.Label3 = new Label();
      this.cbAffects = new ComboBox();
      this.Label4 = new Label();
      this.cbAttribute = new ComboBox();
      this.Label5 = new Label();
      this.cbAspect = new ComboBox();
      this.Label6 = new Label();
      this.cbModifier = new ComboBox();
      this.chkNearGround = new CheckBox();
      this.lblAffectsCaster = new Label();
      this.lvEffectType = new ListView();
      this.ColumnHeader1 = new ColumnHeader();
      this.lvSubAttribute = new ListView();
      this.chSub = new ColumnHeader();
      this.lblProb = new Label();
      this.lvSubSub = new ListView();
      this.chSubSub = new ColumnHeader();
      this.Label7 = new Label();
      this.Label8 = new Label();
      this.btnCSV = new Button();
      this.Label9 = new Label();
      this.cmbEffectId = new ComboBox();
      this.IgnoreED = new CheckBox();
      this.Label10 = new Label();
      this.txtOverride = new TextBox();
      this.Label11 = new Label();
      this.txtPPM = new TextBox();
      this.GroupBox3.SuspendLayout();
      this.SuspendLayout();
      Point point = new Point(804, 497);
      this.btnPaste.Location = point;
      this.btnPaste.Name = "btnPaste";
      Size size = new Size(150, 26);
      this.btnPaste.Size = size;
      this.btnPaste.TabIndex = 116;
      this.btnPaste.Text = "Paste Effect Data";
      point = new Point(804, 465);
      this.btnCopy.Location = point;
      this.btnCopy.Name = "btnCopy";
      size = new Size(150, 26);
      this.btnCopy.Size = size;
      this.btnCopy.TabIndex = 115;
      this.btnCopy.Text = "Copy Effect Data";
      this.chkStack.CheckAlign = ContentAlignment.MiddleRight;
      point = new Point(20, 510);
      this.chkStack.Location = point;
      this.chkStack.Name = "chkStack";
      size = new Size(172, 20);
      this.chkStack.Size = size;
      this.chkStack.TabIndex = 112;
      this.chkStack.Text = "Effect Can Stack";
      this.chkStack.TextAlign = ContentAlignment.MiddleRight;
      this.GroupBox3.Controls.Add((Control) this.clbSuppression);
      point = new Point(794, 124);
      this.GroupBox3.Location = point;
      this.GroupBox3.Name = "GroupBox3";
      size = new Size(166, 240);
      this.GroupBox3.Size = size;
      this.GroupBox3.TabIndex = 107;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Suppression";
      this.clbSuppression.FormattingEnabled = true;
      point = new Point(10, 19);
      this.clbSuppression.Location = point;
      this.clbSuppression.Name = "clbSuppression";
      size = new Size(150, 214);
      this.clbSuppression.Size = size;
      this.clbSuppression.TabIndex = 0;
      point = new Point(12, 596);
      this.Label27.Location = point;
      this.Label27.Name = "Label27";
      size = new Size(76, 20);
      this.Label27.Size = size;
      this.Label27.TabIndex = 102;
      this.Label27.Text = "If Target =";
      this.Label27.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(224, 597);
      this.rbIfPlayer.Location = point;
      this.rbIfPlayer.Name = "rbIfPlayer";
      size = new Size(76, 20);
      this.rbIfPlayer.Size = size;
      this.rbIfPlayer.TabIndex = 88;
      this.rbIfPlayer.Text = "Players";
      point = new Point(147, 597);
      this.rbIfCritter.Location = point;
      this.rbIfCritter.Name = "rbIfCritter";
      size = new Size(71, 20);
      this.rbIfCritter.Size = size;
      this.rbIfCritter.TabIndex = 87;
      this.rbIfCritter.Text = "Critters";
      this.rbIfAny.Checked = true;
      point = new Point(94, 597);
      this.rbIfAny.Location = point;
      this.rbIfAny.Name = "rbIfAny";
      size = new Size(57, 20);
      this.rbIfAny.Size = size;
      this.rbIfAny.TabIndex = 86;
      this.rbIfAny.TabStop = true;
      this.rbIfAny.Text = "Any";
      this.chkFXResistable.CheckAlign = ContentAlignment.MiddleRight;
      point = new Point(20, 561);
      this.chkFXResistable.Location = point;
      this.chkFXResistable.Name = "chkFXResistable";
      size = new Size(172, 20);
      this.chkFXResistable.Size = size;
      this.chkFXResistable.TabIndex = 90;
      this.chkFXResistable.Text = "Effect is Unresistible";
      this.chkFXResistable.TextAlign = ContentAlignment.MiddleRight;
      this.chkFXBuffable.CheckAlign = ContentAlignment.MiddleRight;
      point = new Point(20, 528);
      this.chkFXBuffable.Location = point;
      this.chkFXBuffable.Name = "chkFXBuffable";
      size = new Size(172, 20);
      this.chkFXBuffable.Size = size;
      this.chkFXBuffable.TabIndex = 89;
      this.chkFXBuffable.Text = "Ignore Buffs / Enhancements";
      this.chkFXBuffable.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(12, 273);
      this.Label26.Location = point;
      this.Label26.Name = "Label26";
      size = new Size(76, 20);
      this.Label26.Size = size;
      this.Label26.TabIndex = 101;
      this.Label26.Text = "Probability:";
      this.Label26.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 273);
      this.txtFXProb.Location = point;
      this.txtFXProb.Name = "txtFXProb";
      size = new Size(42, 20);
      this.txtFXProb.Size = size;
      this.txtFXProb.TabIndex = 85;
      this.txtFXProb.Text = "1";
      point = new Point(12, 247);
      this.Label25.Location = point;
      this.Label25.Name = "Label25";
      size = new Size(76, 20);
      this.Label25.Size = size;
      this.Label25.TabIndex = 100;
      this.Label25.Text = "Delay Time:";
      this.Label25.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 247);
      this.txtFXDelay.Location = point;
      this.txtFXDelay.Name = "txtFXDelay";
      size = new Size(42, 20);
      this.txtFXDelay.Size = size;
      this.txtFXDelay.TabIndex = 84;
      this.txtFXDelay.Text = "0";
      point = new Point(14, 221);
      this.Label24.Location = point;
      this.Label24.Name = "Label24";
      size = new Size(76, 20);
      this.Label24.Size = size;
      this.Label24.TabIndex = 99;
      this.Label24.Text = "Ticks:";
      this.Label24.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 221);
      this.txtFXTicks.Location = point;
      this.txtFXTicks.Name = "txtFXTicks";
      size = new Size(42, 20);
      this.txtFXTicks.Size = size;
      this.txtFXTicks.TabIndex = 83;
      this.txtFXTicks.Text = "0";
      point = new Point(14, 169);
      this.Label23.Location = point;
      this.Label23.Name = "Label23";
      size = new Size(76, 20);
      this.Label23.Size = size;
      this.Label23.TabIndex = 98;
      this.Label23.Text = "Duration:";
      this.Label23.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 169);
      this.txtFXDuration.Location = point;
      this.txtFXDuration.Name = "txtFXDuration";
      size = new Size(42, 20);
      this.txtFXDuration.Size = size;
      this.txtFXDuration.TabIndex = 82;
      this.txtFXDuration.Text = "0";
      point = new Point(14, 195);
      this.Label22.Location = point;
      this.Label22.Name = "Label22";
      size = new Size(76, 20);
      this.Label22.Size = size;
      this.Label22.TabIndex = 97;
      this.Label22.Text = "Magnitude:";
      this.Label22.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 195);
      this.txtFXMag.Location = point;
      this.txtFXMag.Name = "txtFXMag";
      size = new Size(42, 20);
      this.txtFXMag.Size = size;
      this.txtFXMag.TabIndex = 80;
      this.txtFXMag.Text = "0";
      point = new Point(202, 118);
      this.Label28.Location = point;
      this.Label28.Name = "Label28";
      size = new Size(98, 20);
      this.Label28.Size = size;
      this.Label28.TabIndex = 104;
      this.Label28.Text = "DIsplay Priority:";
      this.Label28.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(408, 597);
      this.Label30.Location = point;
      this.Label30.Name = "Label30";
      size = new Size(76, 20);
      this.Label30.Size = size;
      this.Label30.TabIndex = 105;
      this.Label30.Text = "Special Case:";
      this.Label30.TextAlign = ContentAlignment.MiddleRight;
      this.cbFXClass.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(306, 116);
      this.cbFXClass.Location = point;
      this.cbFXClass.Name = "cbFXClass";
      size = new Size(132, 22);
      this.cbFXClass.Size = size;
      this.cbFXClass.TabIndex = 93;
      this.cbFXSpecialCase.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(489, 597);
      this.cbFXSpecialCase.Location = point;
      this.cbFXSpecialCase.Name = "cbFXSpecialCase";
      size = new Size(136, 22);
      this.cbFXSpecialCase.Size = size;
      this.cbFXSpecialCase.TabIndex = 94;
      this.btnOK.DialogResult = DialogResult.OK;
      point = new Point(881, 578);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(85, 36);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 119;
      this.btnOK.Text = "OK";
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(794, 578);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(85, 36);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 118;
      this.btnCancel.Text = "Cancel";
      this.lblEffectDescription.BorderStyle = BorderStyle.FixedSingle;
      point = new Point(8, 11);
      this.lblEffectDescription.Location = point;
      this.lblEffectDescription.Name = "lblEffectDescription";
      size = new Size(950, 102);
      this.lblEffectDescription.Size = size;
      this.lblEffectDescription.TabIndex = 120;
      this.lblEffectDescription.TextAlign = ContentAlignment.MiddleLeft;
      this.lblEffectDescription.UseMnemonic = false;
      point = new Point(461, 116);
      this.chkVariable.Location = point;
      this.chkVariable.Name = "chkVariable";
      size = new Size(285, 20);
      this.chkVariable.Size = size;
      this.chkVariable.TabIndex = 126;
      this.chkVariable.Text = "Enable Power Scaling (Override)";
      this.cbPercentageOverride.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(96, 116);
      this.cbPercentageOverride.Location = point;
      this.cbPercentageOverride.Name = "cbPercentageOverride";
      size = new Size(96, 22);
      this.cbPercentageOverride.Size = size;
      this.cbPercentageOverride.TabIndex = (int) sbyte.MaxValue;
      point = new Point(14, 118);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(76, 20);
      this.Label2.Size = size;
      this.Label2.TabIndex = 128;
      this.Label2.Text = "Percentage:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(14, 143);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(76, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 130;
      this.Label1.Text = "Scale:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 143);
      this.txtFXScale.Location = point;
      this.txtFXScale.Name = "txtFXScale";
      size = new Size(42, 20);
      this.txtFXScale.Size = size;
      this.txtFXScale.TabIndex = 129;
      this.txtFXScale.Text = "0";
      point = new Point(14, 443);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(76, 20);
      this.Label3.Size = size;
      this.Label3.TabIndex = 132;
      this.Label3.Text = "Affects:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      this.cbAffects.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(96, 443);
      this.cbAffects.Location = point;
      this.cbAffects.Name = "cbAffects";
      size = new Size(122, 22);
      this.cbAffects.Size = size;
      this.cbAffects.TabIndex = 131;
      point = new Point(14, 328);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(76, 20);
      this.Label4.Size = size;
      this.Label4.TabIndex = 134;
      this.Label4.Text = "AttribType:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      this.cbAttribute.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(96, 328);
      this.cbAttribute.Location = point;
      this.cbAttribute.Name = "cbAttribute";
      size = new Size(122, 22);
      this.cbAttribute.Size = size;
      this.cbAttribute.TabIndex = 133;
      point = new Point(14, 356);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(76, 20);
      this.Label5.Size = size;
      this.Label5.TabIndex = 136;
      this.Label5.Text = "Aspect:";
      this.Label5.TextAlign = ContentAlignment.MiddleRight;
      this.cbAspect.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(96, 356);
      this.cbAspect.Location = point;
      this.cbAspect.Name = "cbAspect";
      size = new Size(122, 22);
      this.cbAspect.Size = size;
      this.cbAspect.TabIndex = 135;
      point = new Point(14, 384);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(178, 20);
      this.Label6.Size = size;
      this.Label6.TabIndex = 138;
      this.Label6.Text = "Modifier Table:";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.cbModifier.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(20, 405);
      this.cbModifier.Location = point;
      this.cbModifier.Name = "cbModifier";
      size = new Size(198, 22);
      this.cbModifier.Size = size;
      this.cbModifier.TabIndex = 137;
      this.chkNearGround.CheckAlign = ContentAlignment.MiddleRight;
      point = new Point(20, 577);
      this.chkNearGround.Location = point;
      this.chkNearGround.Name = "chkNearGround";
      size = new Size(172, 20);
      this.chkNearGround.Size = size;
      this.chkNearGround.TabIndex = 139;
      this.chkNearGround.Text = "Target must be Near Ground";
      this.chkNearGround.TextAlign = ContentAlignment.MiddleRight;
      this.lblAffectsCaster.BorderStyle = BorderStyle.Fixed3D;
      point = new Point(96, 464);
      this.lblAffectsCaster.Location = point;
      this.lblAffectsCaster.Name = "lblAffectsCaster";
      size = new Size(122, 32);
      this.lblAffectsCaster.Size = size;
      this.lblAffectsCaster.TabIndex = 140;
      this.lblAffectsCaster.Text = "Power also affects caster";
      this.lblAffectsCaster.TextAlign = ContentAlignment.MiddleCenter;
      this.lvEffectType.Columns.AddRange(new ColumnHeader[1]
      {
        this.ColumnHeader1
      });
      this.lvEffectType.FullRowSelect = true;
      this.lvEffectType.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvEffectType.HideSelection = false;
      point = new Point(224, 143);
      this.lvEffectType.Location = point;
      this.lvEffectType.MultiSelect = false;
      this.lvEffectType.Name = "lvEffectType";
      size = new Size(197, 447);
      this.lvEffectType.Size = size;
      this.lvEffectType.TabIndex = 141;
      this.lvEffectType.UseCompatibleStateImageBehavior = false;
      this.lvEffectType.View = View.Details;
      this.ColumnHeader1.Text = "Effect Attribute";
      this.ColumnHeader1.Width = 174;
      this.lvSubAttribute.Columns.AddRange(new ColumnHeader[1]
      {
        this.chSub
      });
      this.lvSubAttribute.FullRowSelect = true;
      this.lvSubAttribute.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvSubAttribute.HideSelection = false;
      point = new Point(427, 143);
      this.lvSubAttribute.Location = point;
      this.lvSubAttribute.MultiSelect = false;
      this.lvSubAttribute.Name = "lvSubAttribute";
      size = new Size(197, 447);
      this.lvSubAttribute.Size = size;
      this.lvSubAttribute.TabIndex = 142;
      this.lvSubAttribute.UseCompatibleStateImageBehavior = false;
      this.lvSubAttribute.View = View.Details;
      this.chSub.Text = "Sub-Attribute";
      this.chSub.Width = 173;
      point = new Point(142, 273);
      this.lblProb.Location = point;
      this.lblProb.Name = "lblProb";
      size = new Size(76, 20);
      this.lblProb.Size = size;
      this.lblProb.TabIndex = 143;
      this.lblProb.Text = "(100%)";
      this.lblProb.TextAlign = ContentAlignment.MiddleLeft;
      this.lvSubSub.Columns.AddRange(new ColumnHeader[1]
      {
        this.chSubSub
      });
      this.lvSubSub.FullRowSelect = true;
      this.lvSubSub.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.lvSubSub.HideSelection = false;
      point = new Point(630, 143);
      this.lvSubSub.Location = point;
      this.lvSubSub.MultiSelect = false;
      this.lvSubSub.Name = "lvSubSub";
      size = new Size(158, 447);
      this.lvSubSub.Size = size;
      this.lvSubSub.TabIndex = 144;
      this.lvSubSub.UseCompatibleStateImageBehavior = false;
      this.lvSubSub.View = View.Details;
      this.chSubSub.Text = "Sub-Sub";
      this.chSubSub.Width = 130;
      point = new Point(144, 247);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(76, 20);
      this.Label7.Size = size;
      this.Label7.TabIndex = 145;
      this.Label7.Text = "s";
      this.Label7.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(142, 169);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(76, 20);
      this.Label8.Size = size;
      this.Label8.TabIndex = 146;
      this.Label8.Text = "s";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(804, 529);
      this.btnCSV.Location = point;
      this.btnCSV.Name = "btnCSV";
      size = new Size(150, 26);
      this.btnCSV.Size = size;
      this.btnCSV.TabIndex = 147;
      this.btnCSV.Text = "Import from CSV String";
      point = new Point(794, 367);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(160, 20);
      this.Label9.Size = size;
      this.Label9.TabIndex = 149;
      this.Label9.Text = "GlobalChanceMod Flag:";
      this.cmbEffectId.FormattingEnabled = true;
      point = new Point(795, 389);
      this.cmbEffectId.Location = point;
      this.cmbEffectId.Name = "cmbEffectId";
      size = new Size(159, 22);
      this.cmbEffectId.Size = size;
      this.cmbEffectId.TabIndex = 150;
      this.IgnoreED.CheckAlign = ContentAlignment.MiddleRight;
      point = new Point(20, 544);
      this.IgnoreED.Location = point;
      this.IgnoreED.Name = "IgnoreED";
      size = new Size(172, 20);
      this.IgnoreED.Size = size;
      this.IgnoreED.TabIndex = 151;
      this.IgnoreED.Text = "Ignore ED";
      this.IgnoreED.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(794, 417);
      this.Label10.Location = point;
      this.Label10.Name = "Label10";
      size = new Size(160, 20);
      this.Label10.Size = size;
      this.Label10.TabIndex = 152;
      this.Label10.Text = "Override:";
      point = new Point(797, 435);
      this.txtOverride.Location = point;
      this.txtOverride.Name = "txtOverride";
      size = new Size(157, 20);
      this.txtOverride.Size = size;
      this.txtOverride.TabIndex = 153;
      point = new Point(14, 299);
      this.Label11.Location = point;
      this.Label11.Name = "Label11";
      size = new Size(76, 20);
      this.Label11.Size = size;
      this.Label11.TabIndex = 155;
      this.Label11.Text = "PPM:";
      this.Label11.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(96, 299);
      this.txtPPM.Location = point;
      this.txtPPM.Name = "txtPPM";
      size = new Size(42, 20);
      this.txtPPM.Size = size;
      this.txtPPM.TabIndex = 154;
      this.txtPPM.Text = "0";
      this.AutoScaleMode = AutoScaleMode.None;
      size = new Size(971, 626);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Label11);
      this.Controls.Add((Control) this.txtPPM);
      this.Controls.Add((Control) this.txtOverride);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.IgnoreED);
      this.Controls.Add((Control) this.cmbEffectId);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.btnCSV);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.lvSubSub);
      this.Controls.Add((Control) this.lblProb);
      this.Controls.Add((Control) this.lvSubAttribute);
      this.Controls.Add((Control) this.lvEffectType);
      this.Controls.Add((Control) this.chkNearGround);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.cbModifier);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cbAspect);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cbAttribute);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cbAffects);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.txtFXScale);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cbPercentageOverride);
      this.Controls.Add((Control) this.chkVariable);
      this.Controls.Add((Control) this.lblEffectDescription);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnPaste);
      this.Controls.Add((Control) this.btnCopy);
      this.Controls.Add((Control) this.chkStack);
      this.Controls.Add((Control) this.GroupBox3);
      this.Controls.Add((Control) this.Label27);
      this.Controls.Add((Control) this.rbIfPlayer);
      this.Controls.Add((Control) this.rbIfCritter);
      this.Controls.Add((Control) this.rbIfAny);
      this.Controls.Add((Control) this.chkFXResistable);
      this.Controls.Add((Control) this.chkFXBuffable);
      this.Controls.Add((Control) this.Label26);
      this.Controls.Add((Control) this.txtFXProb);
      this.Controls.Add((Control) this.Label25);
      this.Controls.Add((Control) this.txtFXDelay);
      this.Controls.Add((Control) this.Label24);
      this.Controls.Add((Control) this.txtFXTicks);
      this.Controls.Add((Control) this.Label23);
      this.Controls.Add((Control) this.txtFXDuration);
      this.Controls.Add((Control) this.Label22);
      this.Controls.Add((Control) this.txtFXMag);
      this.Controls.Add((Control) this.Label28);
      this.Controls.Add((Control) this.Label30);
      this.Controls.Add((Control) this.cbFXClass);
      this.Controls.Add((Control) this.cbFXSpecialCase);
      this.Controls.Add((Control) this.lblAffectsCaster);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmPowerEffect);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Edit Effect";
      this.GroupBox3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void lvEffectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.lvEffectType.SelectedIndices.Count < 1)
        return;
      this.myFX.EffectType = (Enums.eEffectType) this.lvEffectType.SelectedIndices[0];
      this.UpdateEffectSubAttribList();
      this.UpdateFXText();
    }

    private void lvSubAttribute_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.lvSubAttribute.SelectedIndices.Count < 1)
        return;
      IEffect fx = this.myFX;
      if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance)
        fx.DamageType = (Enums.eDamage) this.lvSubAttribute.SelectedIndices[0];
      else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
        fx.MezType = (Enums.eMez) this.lvSubAttribute.SelectedIndices[0];
      else if (fx.EffectType == Enums.eEffectType.ResEffect)
        fx.ETModifies = (Enums.eEffectType) this.lvSubAttribute.SelectedIndices[0];
      else if (fx.EffectType == Enums.eEffectType.EntCreate)
        fx.Summon = this.lvSubAttribute.SelectedItems[0].Text;
      else if (fx.EffectType == Enums.eEffectType.Enhancement)
        fx.ETModifies = (Enums.eEffectType) this.lvSubAttribute.SelectedIndices[0];
      else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
        fx.Reward = this.lvSubAttribute.SelectedItems[0].Text;
      this.UpdateFXText();
      this.UpdateSubSubList();
    }

    private void lvSubSub_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.lvSubSub.SelectedIndices.Count < 1)
        return;
      IEffect fx = this.myFX;
      if (fx.EffectType == Enums.eEffectType.Enhancement & fx.ETModifies == Enums.eEffectType.Mez)
        fx.MezType = (Enums.eMez) this.lvSubSub.SelectedIndices[0];
      this.UpdateFXText();
    }

    private void rbIfACP_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.PvMode = !this.rbIfCritter.Checked ? (!this.rbIfPlayer.Checked ? Enums.ePvX.Any : Enums.ePvX.PvP) : Enums.ePvX.PvE;
      this.UpdateFXText();
    }

    private void StoreSuppression()
    {
      int[] values = (int[]) Enum.GetValues(this.myFX.Suppression.GetType());
      this.myFX.Suppression = Enums.eSuppress.None;
      int num = this.clbSuppression.CheckedIndices.Count - 1;
      for (int index = 0; index <= num; ++index)
        //this.myFX.Suppression += (Enums.eSuppress) values[this.clbSuppression.CheckedIndices[index]];
            myFX.Suppression += values[clbSuppression.CheckedIndices[index]];
        }

    private void txtFXDelay_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtFXDelay.Text = Conversions.ToString(this.myFX.DelayedTime);
      this.UpdateFXText();
    }

    private void txtFXDelay_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      IEffect fx = this.myFX;
      float num = (float) Conversion.Val(this.txtFXDelay.Text);
      if ((double) num >= 0.0 & (double) num <= 2147483904.0)
        fx.DelayedTime = num;
      this.UpdateFXText();
    }

    private void txtFXDuration_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtFXDuration.Text = Strings.Format((object) this.myFX.nDuration, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0##");
      this.UpdateFXText();
    }

    private void txtFXDuration_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      IEffect fx = this.myFX;
      float num = (float) Conversion.Val(this.txtFXDuration.Text);
      if ((double) num >= 0.0 & (double) num <= 2147483904.0)
        fx.nDuration = num;
      this.UpdateFXText();
    }

    private void txtFXMag_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtFXMag.Text = Conversions.ToString(this.myFX.nMagnitude);
      this.UpdateFXText();
    }

    private void txtFXMag_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      IEffect fx = this.myFX;
      string InputStr = this.txtFXMag.Text;
      if (InputStr.EndsWith("%"))
        InputStr = InputStr.Substring(0, InputStr.Length - 1);
      float num = (float) Conversion.Val(InputStr);
      if ((double) num >= -2147483904.0 & (double) num <= 2147483904.0)
        fx.nMagnitude = num;
      this.UpdateFXText();
    }

    private void txtFXProb_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtFXProb.Text = Conversions.ToString(this.myFX.BaseProbability);
      this.UpdateFXText();
    }

    private void txtFXProb_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      IEffect fx = this.myFX;
      float num = (float) Conversion.Val(this.txtFXProb.Text);
      if ((double) num >= 0.0 & (double) num <= 2147483904.0)
      {
        if ((double) num > 1.0)
          num /= 100f;
        fx.BaseProbability = num;
        this.lblProb.Text = "(" + Strings.Format((object) (float) ((double) fx.BaseProbability * 100.0), "###0") + "%)";
      }
      this.UpdateFXText();
    }

    private void txtFXScale_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtFXScale.Text = Strings.Format((object) this.myFX.Scale, "####0.0##");
      this.UpdateFXText();
    }

    private void txtFXScale_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      IEffect fx = this.myFX;
      string InputStr = this.txtFXScale.Text;
      if (InputStr.EndsWith("%"))
        InputStr = InputStr.Substring(0, InputStr.Length - 1);
      float num = (float) Conversion.Val(InputStr);
      if ((double) num >= -2147483904.0 & (double) num <= 2147483904.0)
        fx.Scale = num;
      this.UpdateFXText();
    }

    private void txtFXTicks_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtFXTicks.Text = Conversions.ToString(this.myFX.Ticks);
      this.UpdateFXText();
    }

    private void txtFXTicks_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      IEffect fx = this.myFX;
      float num = (float) Conversion.Val(this.txtFXTicks.Text);
      if ((double) num >= 0.0 & (double) num <= 2147483904.0)
        fx.Ticks = (int) Math.Round((double) num);
      this.UpdateFXText();
    }

    private void txtOverride_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myFX.Override = this.txtOverride.Text;
      this.UpdateFXText();
    }

    private void txtPPM_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtPPM.Text = Conversions.ToString(this.myFX.ProcsPerMinute);
    }

    private void txtPPM_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      float num = (float) Conversion.Val(this.txtPPM.Text);
      if ((double) num >= 0.0 & (double) num < 2147483904.0)
        this.myFX.ProcsPerMinute = num;
    }

    public void UpdateEffectSubAttribList()
    {
      int index1 = 0;
      this.lvSubAttribute.BeginUpdate();
      this.lvSubAttribute.Items.Clear();
      string[] strArray = new string[0];
      IEffect fx = this.myFX;
      if (fx.EffectType == Enums.eEffectType.Damage | fx.EffectType == Enums.eEffectType.DamageBuff | fx.EffectType == Enums.eEffectType.Defense | fx.EffectType == Enums.eEffectType.Resistance | fx.EffectType == Enums.eEffectType.Elusivity)
      {
        strArray = Enum.GetNames(fx.DamageType.GetType());
        index1 = (int) fx.DamageType;
        this.lvSubAttribute.Columns[0].Text = "Damage Type / Vector";
      }
      else if (fx.EffectType == Enums.eEffectType.Mez | fx.EffectType == Enums.eEffectType.MezResist)
      {
        strArray = Enum.GetNames(fx.MezType.GetType());
        index1 = (int) fx.MezType;
        this.lvSubAttribute.Columns[0].Text = "Mez Type";
      }
      else if (fx.EffectType == Enums.eEffectType.ResEffect)
      {
        strArray = Enum.GetNames(fx.EffectType.GetType());
        index1 = (int) fx.ETModifies;
        this.lvSubAttribute.Columns[0].Text = "Effect Type";
      }
      else if (fx.EffectType == Enums.eEffectType.EntCreate)
      {
        strArray = new string[DatabaseAPI.Database.Entities.Length - 1 + 1];
        string lower = fx.Summon.ToLower();
        int num = DatabaseAPI.Database.Entities.Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          strArray[index2] = DatabaseAPI.Database.Entities[index2].UID;
          if (strArray[index2].ToLower() == lower)
            index1 = index2;
        }
        this.lvSubAttribute.Columns[0].Text = "Entity Name";
      }
      else if (fx.EffectType == Enums.eEffectType.GrantPower)
      {
        strArray = new string[DatabaseAPI.Database.Power.Length - 1 + 1];
        string lower = fx.Summon.ToLower();
        int num = DatabaseAPI.Database.Power.Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          strArray[index2] = DatabaseAPI.Database.Power[index2].FullName;
          if (strArray[index2].ToLower() == lower)
            index1 = index2;
        }
        this.lvSubAttribute.Columns[0].Text = "Power Name";
      }
      else if (fx.EffectType == Enums.eEffectType.Enhancement)
      {
        strArray = Enum.GetNames(fx.EffectType.GetType());
        index1 = (int) fx.ETModifies;
        this.lvSubAttribute.Columns[0].Text = "Effect Type";
      }
      else if (fx.EffectType == Enums.eEffectType.GlobalChanceMod)
      {
        strArray = new string[DatabaseAPI.Database.EffectIds.Count - 1 + 1];
        string lower = fx.Reward.ToLower();
        int num = DatabaseAPI.Database.EffectIds.Count - 1;
        for (int index2 = 0; index2 <= num; ++index2)
        {
          strArray[index2] = Conversions.ToString(DatabaseAPI.Database.EffectIds[index2]);
          if (strArray[index2].ToLower() == lower)
            index1 = index2;
        }
        this.lvSubAttribute.Columns[0].Text = "GlobalChanceMod Flag";
      }
      if (strArray.Length > 0)
      {
        int num = strArray.Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
          this.lvSubAttribute.Items.Add(strArray[index2]);
        this.lvSubAttribute.Enabled = true;
      }
      else
      {
        this.lvSubAttribute.Enabled = false;
        this.chSub.Text = "";
      }
      if (this.lvSubAttribute.Items.Count > index1)
      {
        this.lvSubAttribute.Items[index1].Selected = true;
        this.lvSubAttribute.Items[index1].EnsureVisible();
      }
      this.lvSubAttribute.EndUpdate();
      this.UpdateSubSubList();
    }

    private void UpdateFXText()
    {
      if (this.Loading)
        return;
      this.lblEffectDescription.Text = this.myFX.BuildEffectString(false, "", false, false, false);
    }

    public void UpdateSubSubList()
    {
      int index1 = 0;
      this.lvSubSub.BeginUpdate();
      this.lvSubSub.Items.Clear();
      string[] strArray = new string[0];
      IEffect fx = this.myFX;
      if ((fx.EffectType == Enums.eEffectType.Enhancement | fx.EffectType == Enums.eEffectType.ResEffect) & fx.ETModifies == Enums.eEffectType.Mez)
      {
        this.lvSubSub.Columns[0].Text = "Mez Type";
        strArray = Enum.GetNames(fx.MezType.GetType());
        index1 = (int) fx.MezType;
      }
      if (strArray.Length > 0)
      {
        int num = strArray.Length - 1;
        for (int index2 = 0; index2 <= num; ++index2)
          this.lvSubSub.Items.Add(strArray[index2]);
        this.lvSubSub.Enabled = true;
      }
      else
      {
        this.lvSubSub.Enabled = false;
        this.lvSubSub.Columns[0].Text = "";
      }
      if (this.lvSubSub.Items.Count > index1)
      {
        this.lvSubSub.Items[index1].Selected = true;
        this.lvSubSub.Items[index1].EnsureVisible();
      }
      this.lvSubSub.EndUpdate();
    }
  }
}
