
using Base.Data_Classes;
using Base.Display;
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
  public class frmEnhData : Form
  {
    [AccessedThroughProperty("btnAdd")]
    private Button _btnAdd;
    [AccessedThroughProperty("btnAddFX")]
    private Button _btnAddFX;
    [AccessedThroughProperty("btnAutoFill")]
    private Button _btnAutoFill;
    [AccessedThroughProperty("btnCancel")]
    private Button _btnCancel;
    [AccessedThroughProperty("btnDown")]
    private Button _btnDown;
    [AccessedThroughProperty("btnEdit")]
    private Button _btnEdit;
    [AccessedThroughProperty("btnEditPowerData")]
    private Button _btnEditPowerData;
    [AccessedThroughProperty("btnImage")]
    private Button _btnImage;
    [AccessedThroughProperty("btnNoImage")]
    private Button _btnNoImage;
    [AccessedThroughProperty("btnOK")]
    private Button _btnOK;
    [AccessedThroughProperty("btnRemove")]
    private Button _btnRemove;
    [AccessedThroughProperty("btnUp")]
    private Button _btnUp;
    [AccessedThroughProperty("cbMutEx")]
    private ComboBox _cbMutEx;
    [AccessedThroughProperty("cbRecipe")]
    private ComboBox _cbRecipe;
    [AccessedThroughProperty("cbSched")]
    private ComboBox _cbSched;
    [AccessedThroughProperty("cbSet")]
    private ComboBox _cbSet;
    [AccessedThroughProperty("cbSubType")]
    private ComboBox _cbSubType;
    [AccessedThroughProperty("chkSuperior")]
    private CheckBox _chkSuperior;
    [AccessedThroughProperty("chkUnique")]
    private CheckBox _chkUnique;
    [AccessedThroughProperty("gbBasic")]
    private GroupBox _gbBasic;
    [AccessedThroughProperty("gbClass")]
    private GroupBox _gbClass;
    [AccessedThroughProperty("gbEffects")]
    private GroupBox _gbEffects;
    [AccessedThroughProperty("gbMod")]
    private GroupBox _gbMod;
    [AccessedThroughProperty("gbSet")]
    private GroupBox _gbSet;
    [AccessedThroughProperty("gbType")]
    private GroupBox _gbType;
    [AccessedThroughProperty("ImagePicker")]
    private OpenFileDialog _ImagePicker;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label10")]
    private Label _Label10;
    [AccessedThroughProperty("Label11")]
    private Label _Label11;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
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
    [AccessedThroughProperty("lblClass")]
    private Label _lblClass;
    [AccessedThroughProperty("lblSched")]
    private Label _lblSched;
    [AccessedThroughProperty("lstAvailable")]
    private ListBox _lstAvailable;
    [AccessedThroughProperty("lstSelected")]
    private ListBox _lstSelected;
    [AccessedThroughProperty("pbSet")]
    private PictureBox _pbSet;
    [AccessedThroughProperty("pnlClass")]
    private Panel _pnlClass;
    [AccessedThroughProperty("pnlClassList")]
    private Panel _pnlClassList;
    [AccessedThroughProperty("rbBoth")]
    private RadioButton _rbBoth;
    [AccessedThroughProperty("rbBuff")]
    private RadioButton _rbBuff;
    [AccessedThroughProperty("rbDebuff")]
    private RadioButton _rbDebuff;
    [AccessedThroughProperty("rbMod1")]
    private RadioButton _rbMod1;
    [AccessedThroughProperty("rbMod2")]
    private RadioButton _rbMod2;
    [AccessedThroughProperty("rbMod3")]
    private RadioButton _rbMod3;
    [AccessedThroughProperty("rbMod4")]
    private RadioButton _rbMod4;
    [AccessedThroughProperty("rbModOther")]
    private RadioButton _rbModOther;
    [AccessedThroughProperty("StaticIndex")]
    private TextBox _StaticIndex;
    [AccessedThroughProperty("tTip")]
    private ToolTip _tTip;
    [AccessedThroughProperty("txtDesc")]
    private TextBox _txtDesc;
    [AccessedThroughProperty("txtInternal")]
    private TextBox _txtInternal;
    [AccessedThroughProperty("txtModOther")]
    private TextBox _txtModOther;
    [AccessedThroughProperty("txtNameFull")]
    private TextBox _txtNameFull;
    [AccessedThroughProperty("txtNameShort")]
    private TextBox _txtNameShort;
    [AccessedThroughProperty("txtProb")]
    private TextBox _txtProb;
    [AccessedThroughProperty("typeHO")]
    private RadioButton _typeHO;
    [AccessedThroughProperty("typeIO")]
    private RadioButton _typeIO;
    [AccessedThroughProperty("typeRegular")]
    private RadioButton _typeRegular;
    [AccessedThroughProperty("typeSet")]
    private RadioButton _typeSet;
    [AccessedThroughProperty("udMaxLevel")]
    private NumericUpDown _udMaxLevel;
    [AccessedThroughProperty("udMinLevel")]
    private NumericUpDown _udMinLevel;
    protected ExtendedBitmap bxClass;
    protected ExtendedBitmap bxClassList;
    protected int ClassSize;
    private IContainer components;
    protected int EnhAcross;
    protected int EnhPadding;
    protected bool Loading;
    public IEnhancement myEnh;

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        if (this._btnAdd != null)
          this._btnAdd.Click -= eventHandler;
        this._btnAdd = value;
        if (this._btnAdd == null)
          return;
        this._btnAdd.Click += eventHandler;
      }
    }

    internal virtual Button btnAddFX
    {
      get
      {
        return this._btnAddFX;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddFX_Click);
        if (this._btnAddFX != null)
          this._btnAddFX.Click -= eventHandler;
        this._btnAddFX = value;
        if (this._btnAddFX == null)
          return;
        this._btnAddFX.Click += eventHandler;
      }
    }

    internal virtual Button btnAutoFill
    {
      get
      {
        return this._btnAutoFill;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAutoFill_Click);
        if (this._btnAutoFill != null)
          this._btnAutoFill.Click -= eventHandler;
        this._btnAutoFill = value;
        if (this._btnAutoFill == null)
          return;
        this._btnAutoFill.Click += eventHandler;
      }
    }

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

    internal virtual Button btnDown
    {
      get
      {
        return this._btnDown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDown_Click);
        if (this._btnDown != null)
          this._btnDown.Click -= eventHandler;
        this._btnDown = value;
        if (this._btnDown == null)
          return;
        this._btnDown.Click += eventHandler;
      }
    }

    internal virtual Button btnEdit
    {
      get
      {
        return this._btnEdit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
        if (this._btnEdit != null)
          this._btnEdit.Click -= eventHandler;
        this._btnEdit = value;
        if (this._btnEdit == null)
          return;
        this._btnEdit.Click += eventHandler;
      }
    }

    internal virtual Button btnEditPowerData
    {
      get
      {
        return this._btnEditPowerData;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEditPowerData_Click);
        if (this._btnEditPowerData != null)
          this._btnEditPowerData.Click -= eventHandler;
        this._btnEditPowerData = value;
        if (this._btnEditPowerData == null)
          return;
        this._btnEditPowerData.Click += eventHandler;
      }
    }

    internal virtual Button btnImage
    {
      get
      {
        return this._btnImage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnImage_Click);
        if (this._btnImage != null)
          this._btnImage.Click -= eventHandler;
        this._btnImage = value;
        if (this._btnImage == null)
          return;
        this._btnImage.Click += eventHandler;
      }
    }

    internal virtual Button btnNoImage
    {
      get
      {
        return this._btnNoImage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNoImage_Click);
        if (this._btnNoImage != null)
          this._btnNoImage.Click -= eventHandler;
        this._btnNoImage = value;
        if (this._btnNoImage == null)
          return;
        this._btnNoImage.Click += eventHandler;
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

    internal virtual Button btnRemove
    {
      get
      {
        return this._btnRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
        if (this._btnRemove != null)
          this._btnRemove.Click -= eventHandler;
        this._btnRemove = value;
        if (this._btnRemove == null)
          return;
        this._btnRemove.Click += eventHandler;
      }
    }

    internal virtual Button btnUp
    {
      get
      {
        return this._btnUp;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUp_Click);
        if (this._btnUp != null)
          this._btnUp.Click -= eventHandler;
        this._btnUp = value;
        if (this._btnUp == null)
          return;
        this._btnUp.Click += eventHandler;
      }
    }

    internal virtual ComboBox cbMutEx
    {
      get
      {
        return this._cbMutEx;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbMutEx_SelectedIndexChanged);
        if (this._cbMutEx != null)
          this._cbMutEx.SelectedIndexChanged -= eventHandler;
        this._cbMutEx = value;
        if (this._cbMutEx == null)
          return;
        this._cbMutEx.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbRecipe
    {
      get
      {
        return this._cbRecipe;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbRecipe_SelectedIndexChanged);
        if (this._cbRecipe != null)
          this._cbRecipe.SelectedIndexChanged -= eventHandler;
        this._cbRecipe = value;
        if (this._cbRecipe == null)
          return;
        this._cbRecipe.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSched
    {
      get
      {
        return this._cbSched;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSched_SelectedIndexChanged);
        if (this._cbSched != null)
          this._cbSched.SelectedIndexChanged -= eventHandler;
        this._cbSched = value;
        if (this._cbSched == null)
          return;
        this._cbSched.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSet
    {
      get
      {
        return this._cbSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSet_SelectedIndexChanged);
        if (this._cbSet != null)
          this._cbSet.SelectedIndexChanged -= eventHandler;
        this._cbSet = value;
        if (this._cbSet == null)
          return;
        this._cbSet.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual ComboBox cbSubType
    {
      get
      {
        return this._cbSubType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbSubType_SelectedIndexChanged);
        if (this._cbSubType != null)
          this._cbSubType.SelectedIndexChanged -= eventHandler;
        this._cbSubType = value;
        if (this._cbSubType == null)
          return;
        this._cbSubType.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkSuperior
    {
      get
      {
        return this._chkSuperior;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSuperior_CheckedChanged);
        if (this._chkSuperior != null)
          this._chkSuperior.CheckedChanged -= eventHandler;
        this._chkSuperior = value;
        if (this._chkSuperior == null)
          return;
        this._chkSuperior.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox chkUnique
    {
      get
      {
        return this._chkUnique;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkUnique_CheckedChanged);
        if (this._chkUnique != null)
          this._chkUnique.CheckedChanged -= eventHandler;
        this._chkUnique = value;
        if (this._chkUnique == null)
          return;
        this._chkUnique.CheckedChanged += eventHandler;
      }
    }

    internal virtual GroupBox gbBasic
    {
      get
      {
        return this._gbBasic;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbBasic = value;
      }
    }

    internal virtual GroupBox gbClass
    {
      get
      {
        return this._gbClass;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbClass = value;
      }
    }

    internal virtual GroupBox gbEffects
    {
      get
      {
        return this._gbEffects;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbEffects = value;
      }
    }

    internal virtual GroupBox gbMod
    {
      get
      {
        return this._gbMod;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbMod = value;
      }
    }

    internal virtual GroupBox gbSet
    {
      get
      {
        return this._gbSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbSet = value;
      }
    }

    internal virtual GroupBox gbType
    {
      get
      {
        return this._gbType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._gbType = value;
      }
    }

    internal virtual OpenFileDialog ImagePicker
    {
      get
      {
        return this._ImagePicker;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ImagePicker = value;
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

    internal virtual Label lblClass
    {
      get
      {
        return this._lblClass;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblClass = value;
      }
    }

    internal virtual Label lblSched
    {
      get
      {
        return this._lblSched;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblSched = value;
      }
    }

    internal virtual ListBox lstAvailable
    {
      get
      {
        return this._lstAvailable;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lstAvailable_DoubleClick);
        if (this._lstAvailable != null)
          this._lstAvailable.DoubleClick -= eventHandler;
        this._lstAvailable = value;
        if (this._lstAvailable == null)
          return;
        this._lstAvailable.DoubleClick += eventHandler;
      }
    }

    internal virtual ListBox lstSelected
    {
      get
      {
        return this._lstSelected;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lstSelected_SelectedIndexChanged);
        if (this._lstSelected != null)
          this._lstSelected.SelectedIndexChanged -= eventHandler;
        this._lstSelected = value;
        if (this._lstSelected == null)
          return;
        this._lstSelected.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual PictureBox pbSet
    {
      get
      {
        return this._pbSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._pbSet = value;
      }
    }

    internal virtual Panel pnlClass
    {
      get
      {
        return this._pnlClass;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.pnlClass_MouseMove);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlClass_Paint);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlClass_MouseDown);
        if (this._pnlClass != null)
        {
          this._pnlClass.MouseMove -= mouseEventHandler1;
          this._pnlClass.Paint -= paintEventHandler;
          this._pnlClass.MouseDown -= mouseEventHandler2;
        }
        this._pnlClass = value;
        if (this._pnlClass == null)
          return;
        this._pnlClass.MouseMove += mouseEventHandler1;
        this._pnlClass.Paint += paintEventHandler;
        this._pnlClass.MouseDown += mouseEventHandler2;
      }
    }

    internal virtual Panel pnlClassList
    {
      get
      {
        return this._pnlClassList;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.pnlClassList_MouseMove);
        PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlClassList_Paint);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlClassList_MouseDown);
        if (this._pnlClassList != null)
        {
          this._pnlClassList.MouseMove -= mouseEventHandler1;
          this._pnlClassList.Paint -= paintEventHandler;
          this._pnlClassList.MouseDown -= mouseEventHandler2;
        }
        this._pnlClassList = value;
        if (this._pnlClassList == null)
          return;
        this._pnlClassList.MouseMove += mouseEventHandler1;
        this._pnlClassList.Paint += paintEventHandler;
        this._pnlClassList.MouseDown += mouseEventHandler2;
      }
    }

    internal virtual RadioButton rbBoth
    {
      get
      {
        return this._rbBoth;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbBuffDebuff_CheckedChanged);
        if (this._rbBoth != null)
          this._rbBoth.CheckedChanged -= eventHandler;
        this._rbBoth = value;
        if (this._rbBoth == null)
          return;
        this._rbBoth.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbBuff
    {
      get
      {
        return this._rbBuff;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbBuffDebuff_CheckedChanged);
        if (this._rbBuff != null)
          this._rbBuff.CheckedChanged -= eventHandler;
        this._rbBuff = value;
        if (this._rbBuff == null)
          return;
        this._rbBuff.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbDebuff
    {
      get
      {
        return this._rbDebuff;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbBuffDebuff_CheckedChanged);
        if (this._rbDebuff != null)
          this._rbDebuff.CheckedChanged -= eventHandler;
        this._rbDebuff = value;
        if (this._rbDebuff == null)
          return;
        this._rbDebuff.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbMod1
    {
      get
      {
        return this._rbMod1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
        if (this._rbMod1 != null)
          this._rbMod1.CheckedChanged -= eventHandler;
        this._rbMod1 = value;
        if (this._rbMod1 == null)
          return;
        this._rbMod1.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbMod2
    {
      get
      {
        return this._rbMod2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
        if (this._rbMod2 != null)
          this._rbMod2.CheckedChanged -= eventHandler;
        this._rbMod2 = value;
        if (this._rbMod2 == null)
          return;
        this._rbMod2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbMod3
    {
      get
      {
        return this._rbMod3;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
        if (this._rbMod3 != null)
          this._rbMod3.CheckedChanged -= eventHandler;
        this._rbMod3 = value;
        if (this._rbMod3 == null)
          return;
        this._rbMod3.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbMod4
    {
      get
      {
        return this._rbMod4;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
        if (this._rbMod4 != null)
          this._rbMod4.CheckedChanged -= eventHandler;
        this._rbMod4 = value;
        if (this._rbMod4 == null)
          return;
        this._rbMod4.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rbModOther
    {
      get
      {
        return this._rbModOther;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
        if (this._rbModOther != null)
          this._rbModOther.CheckedChanged -= eventHandler;
        this._rbModOther = value;
        if (this._rbModOther == null)
          return;
        this._rbModOther.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox StaticIndex
    {
      get
      {
        return this._StaticIndex;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.StaticIndex_TextChanged);
        if (this._StaticIndex != null)
          this._StaticIndex.TextChanged -= eventHandler;
        this._StaticIndex = value;
        if (this._StaticIndex == null)
          return;
        this._StaticIndex.TextChanged += eventHandler;
      }
    }

    internal virtual ToolTip tTip
    {
      get
      {
        return this._tTip;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._tTip = value;
      }
    }

    internal virtual TextBox txtDesc
    {
      get
      {
        return this._txtDesc;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtDesc_TextChanged);
        if (this._txtDesc != null)
          this._txtDesc.TextChanged -= eventHandler;
        this._txtDesc = value;
        if (this._txtDesc == null)
          return;
        this._txtDesc.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtInternal
    {
      get
      {
        return this._txtInternal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtInternal_TextChanged);
        if (this._txtInternal != null)
          this._txtInternal.TextChanged -= eventHandler;
        this._txtInternal = value;
        if (this._txtInternal == null)
          return;
        this._txtInternal.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtModOther
    {
      get
      {
        return this._txtModOther;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtModOther_TextChanged);
        if (this._txtModOther != null)
          this._txtModOther.TextChanged -= eventHandler;
        this._txtModOther = value;
        if (this._txtModOther == null)
          return;
        this._txtModOther.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtNameFull
    {
      get
      {
        return this._txtNameFull;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtNameFull_TextChanged);
        if (this._txtNameFull != null)
          this._txtNameFull.TextChanged -= eventHandler;
        this._txtNameFull = value;
        if (this._txtNameFull == null)
          return;
        this._txtNameFull.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtNameShort
    {
      get
      {
        return this._txtNameShort;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtNameShort_TextChanged);
        if (this._txtNameShort != null)
          this._txtNameShort.TextChanged -= eventHandler;
        this._txtNameShort = value;
        if (this._txtNameShort == null)
          return;
        this._txtNameShort.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtProb
    {
      get
      {
        return this._txtProb;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.txtProb_Leave);
        EventHandler eventHandler2 = new EventHandler(this.txtProb_TextChanged);
        if (this._txtProb != null)
        {
          this._txtProb.Leave -= eventHandler1;
          this._txtProb.TextChanged -= eventHandler2;
        }
        this._txtProb = value;
        if (this._txtProb == null)
          return;
        this._txtProb.Leave += eventHandler1;
        this._txtProb.TextChanged += eventHandler2;
      }
    }

    internal virtual RadioButton typeHO
    {
      get
      {
        return this._typeHO;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
        if (this._typeHO != null)
          this._typeHO.CheckedChanged -= eventHandler;
        this._typeHO = value;
        if (this._typeHO == null)
          return;
        this._typeHO.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton typeIO
    {
      get
      {
        return this._typeIO;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
        if (this._typeIO != null)
          this._typeIO.CheckedChanged -= eventHandler;
        this._typeIO = value;
        if (this._typeIO == null)
          return;
        this._typeIO.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton typeRegular
    {
      get
      {
        return this._typeRegular;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
        if (this._typeRegular != null)
          this._typeRegular.CheckedChanged -= eventHandler;
        this._typeRegular = value;
        if (this._typeRegular == null)
          return;
        this._typeRegular.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton typeSet
    {
      get
      {
        return this._typeSet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
        if (this._typeSet != null)
          this._typeSet.CheckedChanged -= eventHandler;
        this._typeSet = value;
        if (this._typeSet == null)
          return;
        this._typeSet.CheckedChanged += eventHandler;
      }
    }

    internal virtual NumericUpDown udMaxLevel
    {
      get
      {
        return this._udMaxLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udMaxLevel_Leave);
        EventHandler eventHandler2 = new EventHandler(this.udMaxLevel_ValueChanged);
        if (this._udMaxLevel != null)
        {
          this._udMaxLevel.Leave -= eventHandler1;
          this._udMaxLevel.ValueChanged -= eventHandler2;
        }
        this._udMaxLevel = value;
        if (this._udMaxLevel == null)
          return;
        this._udMaxLevel.Leave += eventHandler1;
        this._udMaxLevel.ValueChanged += eventHandler2;
      }
    }

    internal virtual NumericUpDown udMinLevel
    {
      get
      {
        return this._udMinLevel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.udMinLevel_Leave);
        EventHandler eventHandler2 = new EventHandler(this.udMinLevel_ValueChanged);
        if (this._udMinLevel != null)
        {
          this._udMinLevel.Leave -= eventHandler1;
          this._udMinLevel.ValueChanged -= eventHandler2;
        }
        this._udMinLevel = value;
        if (this._udMinLevel == null)
          return;
        this._udMinLevel.Leave += eventHandler1;
        this._udMinLevel.ValueChanged += eventHandler2;
      }
    }

    public frmEnhData(ref IEnhancement iEnh)
    {
      this.Load += new EventHandler(this.frmEnhData_Load);
      this.ClassSize = 15;
      this.EnhPadding = 3;
      this.EnhAcross = 5;
      this.Loading = true;
      this.InitializeComponent();
      this.myEnh = (IEnhancement) new Enhancement(iEnh);
      this.ClassSize = 22;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      this.EffectList_Add();
    }

    private void btnAddFX_Click(object sender, EventArgs e)
    {
      IEffect iFX = (IEffect) new Effect((IPower) null);
      frmPowerEffect frmPowerEffect = new frmPowerEffect(ref iFX);
      if (frmPowerEffect.ShowDialog() != DialogResult.OK)
        return;
      IEnhancement enh = this.myEnh;
      Enums.sEffect[] sEffectArray = (Enums.sEffect[]) Utils.CopyArray((Array) enh.Effect, (Array) new Enums.sEffect[this.myEnh.Effect.Length + 1]);
      enh.Effect = sEffectArray;
      Enums.sEffect[] effect = this.myEnh.Effect;
      int index = this.myEnh.Effect.Length - 1;
      effect[index].Mode = Enums.eEffMode.FX;
      effect[index].Enhance.ID = -1;
      effect[index].Enhance.SubID = -1;
      effect[index].Multiplier = 1f;
      effect[index].Schedule = Enums.eSchedule.A;
      effect[index].FX = (IEffect) frmPowerEffect.myFX.Clone();
      effect[index].FX.isEnahncementEffect = true;
      this.ListSelectedEffects();
      this.lstSelected.SelectedIndex = this.lstSelected.Items.Count - 1;
    }

    private void btnAutoFill_Click(object sender, EventArgs e)
    {
      Enums.eEnhance eEnhance = Enums.eEnhance.None;
      Enums.eEnhanceShort eEnhanceShort = Enums.eEnhanceShort.None;
      Enums.eMez eMez = Enums.eMez.None;
      Enums.eMezShort eMezShort = Enums.eMezShort.None;
      string[] names1 = Enum.GetNames(eEnhance.GetType());
      string[] names2 = Enum.GetNames(eEnhanceShort.GetType());
      string[] names3 = Enum.GetNames(eMez.GetType());
      string[] names4 = Enum.GetNames(eMezShort.GetType());
      this.myEnh.Name = "";
      this.myEnh.ShortName = "";
      names1[4] = "Endurance";
      names1[18] = "Resistance";
      names1[5] = "EndMod";
      names2[18] = "ResDam";
      names3[2] = "Hold";
      names4[2] = "Hold";
      if (this.myEnh.TypeID == Enums.eType.SetO & this.myEnh.nIDSet > -1 & this.myEnh.nIDSet < DatabaseAPI.Database.EnhancementSets.Count - 1)
        this.myEnh.UID = DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].DisplayName.Replace(" ", "_") + "_";
      int num1 = 0;
      int num2 = this.myEnh.Effect.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        if (this.myEnh.Effect[index].Mode == Enums.eEffMode.Enhancement)
        {
          ++num1;
          Enums.eEnhance id = (Enums.eEnhance) this.myEnh.Effect[index].Enhance.ID;
          if (id != Enums.eEnhance.Mez)
          {
            if (this.myEnh.Name != "")
              this.myEnh.Name += "/";
            this.myEnh.Name += names1[(int) id];
            if (this.myEnh.ShortName != "")
              this.myEnh.ShortName += "/";
            this.myEnh.ShortName += names2[(int) id];
          }
          else
          {
            if (this.myEnh.Name != "")
              this.myEnh.Name += "/";
            this.myEnh.Name += names3[this.myEnh.Effect[index].Enhance.SubID];
            if (this.myEnh.ShortName != "")
              this.myEnh.ShortName += "/";
            this.myEnh.ShortName += names4[this.myEnh.Effect[index].Enhance.SubID];
          }
        }
      }
      float num3 = 1f;
      switch (num1)
      {
        case 2:
          num3 = 0.625f;
          break;
        case 3:
          num3 = 0.5f;
          break;
        case 4:
          num3 = 7f / 16f;
          break;
      }
      int num4 = this.myEnh.Effect.Length - 1;
      for (int index = 0; index <= num4; ++index)
      {
        if (this.myEnh.Effect[index].Mode == Enums.eEffMode.Enhancement)
          this.myEnh.Effect[index].Multiplier = num3;
      }
      this.DisplayAll();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Hide();
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      if (this.lstSelected.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lstSelected.SelectedIndices[0];
      if (selectedIndex < this.lstSelected.Items.Count - 1)
      {
        Enums.sEffect[] sEffectArray = new Enums.sEffect[2];
        sEffectArray[0].Assign(this.myEnh.Effect[selectedIndex]);
        sEffectArray[1].Assign(this.myEnh.Effect[selectedIndex + 1]);
        this.myEnh.Effect[selectedIndex + 1].Assign(sEffectArray[0]);
        this.myEnh.Effect[selectedIndex].Assign(sEffectArray[1]);
        this.FillEffectList();
        this.ListSelectedEffects();
        this.lstSelected.SelectedIndex = selectedIndex + 1;
      }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      this.EditClick();
    }

    private void btnEditPowerData_Click(object sender, EventArgs e)
    {
      IEnhancement enh = this.myEnh;
      IPower power = enh.Power;
      enh.Power = power;
      frmEditPower frmEditPower = new frmEditPower(ref power);
      if (frmEditPower.ShowDialog() != DialogResult.OK)
        return;
      this.myEnh.Power = (IPower) new Power(frmEditPower.myPower);
      this.myEnh.Power.IsModified = true;
      int num = this.myEnh.Power.Effects.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.myEnh.Power.Effects[index].PowerFullName = this.myEnh.Power.FullName;
    }

    private void btnImage_Click(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.ImagePicker.InitialDirectory = I9Gfx.GetEnhancementsPath();
      this.ImagePicker.FileName = this.myEnh.Image;
      if (this.ImagePicker.ShowDialog() == DialogResult.OK)
      {
        string str = FileIO.StripPath(this.ImagePicker.FileName);
        if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
        {
          int num = (int) Interaction.MsgBox((object) ("You must select an image from the " + I9Gfx.GetEnhancementsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it."), MsgBoxStyle.Information, (object) "Ah...");
        }
        else
        {
          this.myEnh.Image = str;
          this.DisplayIcon();
          this.SetTypeIcons();
        }
      }
    }

    private void btnNoImage_Click(object sender, EventArgs e)
    {
      this.myEnh.Image = "";
      this.SetTypeIcons();
      this.DisplayIcon();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Hide();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      if (this.lstSelected.SelectedIndex <= -1)
        return;
      Enums.sEffect[] sEffectArray = new Enums.sEffect[this.myEnh.Effect.Length - 1 + 1];
      int selectedIndex = this.lstSelected.SelectedIndex;
      int index1 = 0;
      int num1 = this.myEnh.Effect.Length - 1;
      for (int index2 = 0; index2 <= num1; ++index2)
      {
        if (index2 != selectedIndex)
        {
          sEffectArray[index1].Assign(this.myEnh.Effect[index2]);
          ++index1;
        }
      }
      this.myEnh.Effect = new Enums.sEffect[this.myEnh.Effect.Length - 2 + 1];
      int num2 = this.myEnh.Effect.Length - 1;
      for (int index2 = 0; index2 <= num2; ++index2)
        this.myEnh.Effect[index2].Assign(sEffectArray[index2]);
      this.FillEffectList();
      this.ListSelectedEffects();
      if (this.lstSelected.Items.Count > selectedIndex)
        this.lstSelected.SelectedIndex = selectedIndex;
      else if (this.lstSelected.Items.Count == selectedIndex)
        this.lstSelected.SelectedIndex = selectedIndex - 1;
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
      if (this.lstSelected.SelectedIndices.Count <= 0)
        return;
      int selectedIndex = this.lstSelected.SelectedIndices[0];
      if (selectedIndex >= 1)
      {
        Enums.sEffect[] sEffectArray = new Enums.sEffect[2];
        sEffectArray[0].Assign(this.myEnh.Effect[selectedIndex]);
        sEffectArray[1].Assign(this.myEnh.Effect[selectedIndex - 1]);
        this.myEnh.Effect[selectedIndex - 1].Assign(sEffectArray[0]);
        this.myEnh.Effect[selectedIndex].Assign(sEffectArray[1]);
        this.FillEffectList();
        this.ListSelectedEffects();
        this.lstSelected.SelectedIndex = selectedIndex - 1;
      }
    }

    private void cbMutEx_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.MutExID = (Enums.eEnhMutex) this.cbMutEx.SelectedIndex;
    }

    private void cbRecipe_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cbRecipe.SelectedIndex > 0)
      {
        this.myEnh.RecipeName = this.cbRecipe.Text;
        this.myEnh.RecipeIDX = this.cbRecipe.SelectedIndex - 1;
      }
      else
      {
        this.myEnh.RecipeName = "";
        this.myEnh.RecipeIDX = -1;
      }
    }

    private void cbSched_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lstSelected.SelectedIndex <= -1)
        return;
      int selectedIndex = this.lstSelected.SelectedIndex;
      if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
        this.myEnh.Effect[selectedIndex].Schedule = (Enums.eSchedule) this.cbSched.SelectedIndex;
    }

    private void cbSet_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.nIDSet = this.cbSet.SelectedIndex - 1;
      this.myEnh.UIDSet = this.myEnh.nIDSet <= -1 ? string.Empty : DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Uid;
      this.UpdateTitle();
      this.DisplaySetImage();
    }

    private void cbSubType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.myEnh.SubTypeID = (Enums.eSubtype) this.cbSubType.SelectedIndex;
    }

    private void chkSuperior_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.Superior = this.chkSuperior.Checked;
      if (this.chkSuperior.Checked)
      {
        this.myEnh.LevelMin = 49;
        this.myEnh.LevelMax = 49;
        this.udMinLevel.Value = new Decimal(50);
        this.udMaxLevel.Value = new Decimal(50);
      }
      this.chkUnique.Checked = true;
    }

    private void chkUnique_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.Unique = this.chkUnique.Checked;
    }

    public void DisplayAll()
    {
      this.txtNameFull.Text = this.myEnh.Name;
      this.txtNameShort.Text = this.myEnh.ShortName;
      this.txtDesc.Text = this.myEnh.Desc;
      this.txtProb.Text = Conversions.ToString(this.myEnh.EffectChance);
      this.txtInternal.Text = this.myEnh.UID;
      this.StaticIndex.Text = Conversions.ToString(this.myEnh.StaticIndex);
      this.SetMinLevel(this.myEnh.LevelMin + 1);
      this.SetMaxLevel(this.myEnh.LevelMax + 1);
      this.udMaxLevel.Minimum = this.udMinLevel.Value;
      this.udMinLevel.Maximum = this.udMaxLevel.Value;
      this.chkUnique.Checked = this.myEnh.Unique;
      this.cbMutEx.SelectedIndex = (int) this.myEnh.MutExID;
      this.chkSuperior.Checked = this.myEnh.Superior;
      switch (this.myEnh.TypeID)
      {
        case Enums.eType.Normal:
          this.typeRegular.Checked = true;
          this.cbSubType.SelectedIndex = -1;
          this.cbSubType.Enabled = false;
          this.cbRecipe.SelectedIndex = 0;
          this.cbRecipe.Enabled = false;
          break;
        case Enums.eType.InventO:
          this.typeIO.Checked = true;
          this.cbSubType.SelectedIndex = -1;
          this.cbSubType.Enabled = false;
          this.cbRecipe.SelectedIndex = this.myEnh.RecipeIDX + 1;
          this.cbRecipe.Enabled = true;
          break;
        case Enums.eType.SpecialO:
          this.typeHO.Checked = true;
          this.cbSubType.SelectedIndex = (int) this.myEnh.SubTypeID;
          this.cbSubType.Enabled = true;
          this.cbRecipe.Enabled = false;
          this.cbRecipe.SelectedIndex = 0;
          break;
        case Enums.eType.SetO:
          this.cbSubType.SelectedIndex = -1;
          this.cbSubType.Enabled = false;
          this.typeSet.Checked = true;
          this.cbRecipe.SelectedIndex = this.myEnh.RecipeIDX + 1;
          this.cbRecipe.Enabled = true;
          break;
        default:
          this.typeRegular.Checked = true;
          this.cbSubType.SelectedIndex = -1;
          this.cbSubType.Enabled = false;
          this.cbRecipe.Enabled = false;
          break;
      }
      this.DisplaySet();
      this.btnImage.Text = this.myEnh.Image;
      this.DisplayIcon();
      this.DisplaySetImage();
      this.DrawClasses();
      this.ListSelectedEffects();
      this.DisplayEnhanceData();
    }

    public void DisplayEnhanceData()
    {
      if (this.lstSelected.SelectedIndex <= -1)
      {
        this.btnRemove.Enabled = false;
        this.gbMod.Enabled = false;
        this.cbSched.Enabled = false;
        this.btnEdit.Enabled = false;
      }
      else
      {
        this.btnRemove.Enabled = true;
        int selectedIndex = this.lstSelected.SelectedIndex;
        if (this.myEnh.Effect[selectedIndex].Mode != Enums.eEffMode.Enhancement)
        {
          this.btnEdit.Enabled = true;
          this.gbMod.Enabled = false;
          this.cbSched.Enabled = false;
        }
        else
        {
          if (this.myEnh.Effect[selectedIndex].Enhance.ID == 12)
            this.btnEdit.Enabled = true;
          else
            this.btnEdit.Enabled = false;
          this.gbMod.Enabled = true;
          this.cbSched.Enabled = true;
          switch (this.myEnh.Effect[selectedIndex].Multiplier.ToString())
          {
            case "1":
              this.rbMod1.Checked = true;
              this.txtModOther.Text = "";
              this.txtModOther.Enabled = false;
              break;
            case "0.625":
              this.rbMod2.Checked = true;
              this.txtModOther.Text = "";
              this.txtModOther.Enabled = false;
              break;
            case "0.5":
              this.rbMod3.Checked = true;
              this.txtModOther.Text = "";
              this.txtModOther.Enabled = false;
              break;
            default:
              this.txtModOther.Text = Conversions.ToString(this.myEnh.Effect[selectedIndex].Multiplier);
              this.rbModOther.Checked = true;
              this.txtModOther.Enabled = true;
              break;
          }
          switch (this.myEnh.Effect[selectedIndex].BuffMode)
          {
            case Enums.eBuffDebuff.BuffOnly:
              this.rbBuff.Checked = true;
              break;
            case Enums.eBuffDebuff.DeBuffOnly:
              this.rbDebuff.Checked = true;
              break;
            default:
              this.rbBoth.Checked = true;
              break;
          }
          this.cbSched.SelectedIndex = (int) this.myEnh.Effect[selectedIndex].Schedule;
        }
      }
    }

    public void DisplayIcon()
    {
      if (this.myEnh.Image != string.Empty)
      {
        ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.myEnh.Image);
        ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
        extendedBitmap2.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(this.myEnh.TypeID)), GraphicsUnit.Pixel);
        extendedBitmap2.Graphics.DrawImage((Image) extendedBitmap1.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, GraphicsUnit.Pixel);
        this.btnImage.Image = (Image) new Bitmap((Image) extendedBitmap2.Bitmap);
        this.btnImage.Text = this.myEnh.Image;
      }
      else
      {
        switch (this.myEnh.TypeID)
        {
          case Enums.eType.Normal:
            this.btnImage.Image = this.typeRegular.Image;
            break;
          case Enums.eType.InventO:
            this.btnImage.Image = this.typeIO.Image;
            break;
          case Enums.eType.SpecialO:
            this.btnImage.Image = this.typeHO.Image;
            break;
          case Enums.eType.SetO:
            this.btnImage.Image = this.typeSet.Image;
            break;
        }
        this.btnImage.Text = "Select Image";
      }
    }

    public void DisplaySet()
    {
      this.gbSet.Enabled = this.myEnh.TypeID == Enums.eType.SetO;
      this.cbSet.SelectedIndex = this.myEnh.nIDSet + 1;
      this.DisplaySetImage();
    }

    public void DisplaySetImage()
    {
      if (this.myEnh.nIDSet > -1)
      {
        this.myEnh.Image = DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Image;
        this.DisplayIcon();
        this.SetTypeIcons();
        if (DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Image != "")
        {
          ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Image);
          ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
          extendedBitmap2.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), GraphicsUnit.Pixel);
          extendedBitmap2.Graphics.DrawImage((Image) extendedBitmap1.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, GraphicsUnit.Pixel);
          this.pbSet.Image = (Image) new Bitmap((Image) extendedBitmap2.Bitmap);
        }
        else
        {
          ExtendedBitmap extendedBitmap = new ExtendedBitmap(30, 30);
          extendedBitmap.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), GraphicsUnit.Pixel);
          this.pbSet.Image = (Image) new Bitmap((Image) extendedBitmap.Bitmap);
        }
      }
      else
        this.pbSet.Image = (Image) new Bitmap(this.pbSet.Width, this.pbSet.Height);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public void DrawClasses()
    {
      this.bxClass = new ExtendedBitmap(this.pnlClass.Width, this.pnlClass.Height);
      int enhPadding1 = this.EnhPadding;
      int enhPadding2 = this.EnhPadding;
      int num1 = 0;
      this.bxClass.Graphics.FillRectangle((Brush) new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxClass.ClipRect);
      int num2 = this.myEnh.ClassID.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, this.ClassSize, this.ClassSize);
        this.bxClass.Graphics.DrawImage((Image) I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(this.myEnh.ClassID[index]), GraphicsUnit.Pixel);
        enhPadding2 += this.ClassSize + this.EnhPadding;
        ++num1;
        if (num1 == 2)
        {
          num1 = 0;
          enhPadding2 = this.EnhPadding;
          enhPadding1 += this.ClassSize + this.EnhPadding;
        }
      }
      this.pnlClass.CreateGraphics().DrawImageUnscaled((Image) this.bxClass.Bitmap, 0, 0);
    }

    public void DrawClassList()
    {
      this.bxClassList = new ExtendedBitmap(this.pnlClassList.Width, this.pnlClassList.Height);
      int enhPadding1 = this.EnhPadding;
      int enhPadding2 = this.EnhPadding;
      int num1 = 0;
      this.bxClassList.Graphics.FillRectangle((Brush) new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxClassList.ClipRect);
      int num2 = DatabaseAPI.Database.EnhancementClasses.Length - 1;
      for (int index = 0; index <= num2; ++index)
      {
        Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, 30, 30);
        this.bxClassList.Graphics.DrawImage((Image) I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(index), GraphicsUnit.Pixel);
        enhPadding2 += 30 + this.EnhPadding;
        ++num1;
        if (num1 == this.EnhAcross)
        {
          num1 = 0;
          enhPadding2 = this.EnhPadding;
          enhPadding1 += 30 + this.EnhPadding;
        }
      }
      this.pnlClassList.CreateGraphics().DrawImageUnscaled((Image) this.bxClassList.Bitmap, 0, 0);
    }

    public void EditClick()
    {
      bool flag = true;
      int num1 = -1;
      if (this.lstSelected.SelectedIndex <= -1)
        return;
      int selectedIndex = this.lstSelected.SelectedIndex;
      if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
      {
        if (this.myEnh.Effect[selectedIndex].Enhance.ID == 12)
        {
          int subId = this.myEnh.Effect[selectedIndex].Enhance.SubID;
          num1 = this.MezPicker(subId);
          if (num1 == subId)
            return;
          int num2 = this.myEnh.Effect.Length - 1;
          for (int index1 = 0; index1 <= num2; ++index1)
          {
            Enums.sEffect[] effect = this.myEnh.Effect;
            int index2 = index1;
            if (effect[index2].Mode == Enums.eEffMode.Enhancement & effect[index2].Enhance.SubID == num1)
              flag = false;
          }
        }
        if (!flag)
        {
          int num2 = (int) Interaction.MsgBox((object) "This effect has already been added!", MsgBoxStyle.Information, (object) "There can be only one.");
          return;
        }
        this.myEnh.Effect[selectedIndex].Enhance.SubID = num1;
      }
      else
      {
        frmPowerEffect frmPowerEffect = new frmPowerEffect(ref this.myEnh.Effect[selectedIndex].FX);
        if (frmPowerEffect.ShowDialog() == DialogResult.OK)
        {
          Enums.sEffect[] effect = this.myEnh.Effect;
          int index = selectedIndex;
          effect[index].Mode = Enums.eEffMode.FX;
          effect[index].Enhance.ID = -1;
          effect[index].Enhance.SubID = -1;
          effect[index].Multiplier = 1f;
          effect[index].Schedule = Enums.eSchedule.A;
          effect[index].FX = (IEffect) frmPowerEffect.myFX.Clone();
        }
      }
      this.ListSelectedEffects();
      this.lstSelected.SelectedIndex = selectedIndex;
    }

    public void EffectList_Add()
    {
      if (this.lstAvailable.SelectedIndex <= -1)
        return;
      Enums.eEnhance eEnhance = Enums.eEnhance.None;
      bool flag = true;
      int tSub = -1;
      Enums.eEnhance integer = (Enums.eEnhance) Conversions.ToInteger(Enum.Parse(eEnhance.GetType(), Conversions.ToString(this.lstAvailable.Items[this.lstAvailable.SelectedIndex])));
      if (integer == Enums.eEnhance.Mez)
      {
        tSub = this.MezPicker(1);
        int num = this.myEnh.Effect.Length - 1;
        for (int index1 = 0; index1 <= num; ++index1)
        {
          Enums.sEffect[] effect = this.myEnh.Effect;
          int index2 = index1;
          if (effect[index2].Mode == Enums.eEffMode.Enhancement & effect[index2].Enhance.SubID == tSub)
            flag = false;
        }
      }
      if (!flag)
      {
        int num1 = (int) Interaction.MsgBox((object) "This effect has already been added!", MsgBoxStyle.Information, (object) "There can be only one.");
      }
      else
      {
        IEnhancement enh = this.myEnh;
        Enums.sEffect[] sEffectArray = (Enums.sEffect[]) Utils.CopyArray((Array) enh.Effect, (Array) new Enums.sEffect[this.myEnh.Effect.Length + 1]);
        enh.Effect = sEffectArray;
        Enums.sEffect[] effect = this.myEnh.Effect;
        int index = this.myEnh.Effect.Length - 1;
        effect[index].Mode = Enums.eEffMode.Enhancement;
        effect[index].Enhance.ID = (int) integer;
        effect[index].Enhance.SubID = tSub;
        effect[index].Multiplier = 1f;
        effect[index].Schedule = Enhancement.GetSchedule(integer, tSub);
        this.FillEffectList();
        this.ListSelectedEffects();
        this.lstSelected.SelectedIndex = this.lstSelected.Items.Count - 1;
      }
    }

    public void FillEffectList()
    {
      Enums.eEnhance eEnhance1 = Enums.eEnhance.None;
      this.lstAvailable.BeginUpdate();
      this.lstAvailable.Items.Clear();
      string[] names = Enum.GetNames(eEnhance1.GetType());
      int num1 = names.Length - 1;
      for (int index1 = 1; index1 <= num1; ++index1)
      {
        Enums.eEnhance eEnhance2 = (Enums.eEnhance) index1;
        bool flag = false;
        int num2 = this.myEnh.Effect.Length - 1;
        for (int index2 = 0; index2 <= num2; ++index2)
        {
          if (this.myEnh.Effect[index2].Mode == Enums.eEffMode.Enhancement && this.myEnh.Effect[index2].Enhance.ID == index1 & eEnhance2 != Enums.eEnhance.Mez)
            flag = true;
        }
        if (!flag)
          this.lstAvailable.Items.Add((object) names[index1]);
      }
      this.btnAdd.Enabled = this.lstAvailable.Items.Count > 0;
      this.lstAvailable.EndUpdate();
    }

    public void FillMutExList()
    {
      string[] names = Enum.GetNames(Enums.eEnhMutex.None.GetType());
      this.cbMutEx.BeginUpdate();
      this.cbMutEx.Items.Clear();
      this.cbMutEx.Items.AddRange((object[]) names);
      this.cbMutEx.EndUpdate();
    }

    public void FillRecipeList()
    {
      this.cbRecipe.BeginUpdate();
      this.cbRecipe.Items.Clear();
      this.cbRecipe.Items.Add((object) "None");
      int num = DatabaseAPI.Database.Recipes.Length - 1;
      for (int index = 0; index <= num; ++index)
        this.cbRecipe.Items.Add((object) DatabaseAPI.Database.Recipes[index].InternalName);
      this.cbRecipe.EndUpdate();
    }

    public void FillSchedules()
    {
      this.cbSched.BeginUpdate();
      this.cbSched.Items.Clear();
      string Style = "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##";
      this.cbSched.Items.Add((object) ("A (" + Strings.Format((object) (float) ((double) DatabaseAPI.Database.MultSO[0][0] * 100.0), Style) + "%)"));
      this.cbSched.Items.Add((object) ("B (" + Strings.Format((object) (float) ((double) DatabaseAPI.Database.MultSO[0][1] * 100.0), Style) + "%)"));
      this.cbSched.Items.Add((object) ("C (" + Strings.Format((object) (float) ((double) DatabaseAPI.Database.MultSO[0][2] * 100.0), Style) + "%)"));
      this.cbSched.Items.Add((object) ("D (" + Strings.Format((object) (float) ((double) DatabaseAPI.Database.MultSO[0][3] * 100.0), Style) + "%)"));
      this.cbSched.EndUpdate();
    }

    public void FillSetList()
    {
      this.cbSet.BeginUpdate();
      this.cbSet.Items.Clear();
      this.cbSet.Items.Add((object) "None");
      int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
      for (int index = 0; index <= num; ++index)
        this.cbSet.Items.Add((object) DatabaseAPI.Database.EnhancementSets[index].Uid);
      this.cbSet.EndUpdate();
    }

    public void FillSubTypeList()
    {
      string[] names = Enum.GetNames(Enums.eSubtype.None.GetType());
      this.cbSubType.BeginUpdate();
      this.cbSubType.Items.Clear();
      this.cbSubType.Items.AddRange((object[]) names);
      this.cbSubType.EndUpdate();
    }

    private void frmEnhData_Load(object sender, EventArgs e)
    {
      this.FillSetList();
      this.FillEffectList();
      this.FillMutExList();
      this.FillSubTypeList();
      this.FillRecipeList();
      this.DisplayAll();
      this.SetTypeIcons();
      this.DrawClassList();
      this.FillSchedules();
      this.UpdateTitle();
      this.Loading = false;
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEnhData));
      this.gbBasic = new GroupBox();
      this.txtInternal = new TextBox();
      this.Label9 = new Label();
      this.Label7 = new Label();
      this.Label6 = new Label();
      this.udMinLevel = new NumericUpDown();
      this.udMaxLevel = new NumericUpDown();
      this.txtDesc = new TextBox();
      this.Label4 = new Label();
      this.txtNameShort = new TextBox();
      this.Label3 = new Label();
      this.txtNameFull = new TextBox();
      this.Label2 = new Label();
      this.btnImage = new Button();
      this.gbType = new GroupBox();
      this.cbSubType = new ComboBox();
      this.typeSet = new RadioButton();
      this.typeIO = new RadioButton();
      this.typeRegular = new RadioButton();
      this.typeHO = new RadioButton();
      this.cbSet = new ComboBox();
      this.gbSet = new GroupBox();
      this.chkSuperior = new CheckBox();
      this.pbSet = new PictureBox();
      this.chkUnique = new CheckBox();
      this.gbEffects = new GroupBox();
      this.btnDown = new Button();
      this.btnUp = new Button();
      this.rbBoth = new RadioButton();
      this.rbDebuff = new RadioButton();
      this.rbBuff = new RadioButton();
      this.btnAutoFill = new Button();
      this.Label5 = new Label();
      this.txtProb = new TextBox();
      this.Label1 = new Label();
      this.btnEdit = new Button();
      this.btnAddFX = new Button();
      this.btnRemove = new Button();
      this.btnAdd = new Button();
      this.gbMod = new GroupBox();
      this.rbMod4 = new RadioButton();
      this.txtModOther = new TextBox();
      this.rbModOther = new RadioButton();
      this.rbMod3 = new RadioButton();
      this.rbMod2 = new RadioButton();
      this.rbMod1 = new RadioButton();
      this.lstSelected = new ListBox();
      this.lstAvailable = new ListBox();
      this.cbSched = new ComboBox();
      this.lblSched = new Label();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.gbClass = new GroupBox();
      this.lblClass = new Label();
      this.pnlClassList = new Panel();
      this.pnlClass = new Panel();
      this.ImagePicker = new OpenFileDialog();
      this.btnNoImage = new Button();
      this.tTip = new ToolTip(this.components);
      this.cbMutEx = new ComboBox();
      this.cbRecipe = new ComboBox();
      this.Label8 = new Label();
      this.Label10 = new Label();
      this.btnEditPowerData = new Button();
      this.StaticIndex = new TextBox();
      this.Label11 = new Label();
      this.gbBasic.SuspendLayout();
      this.udMinLevel.BeginInit();
      this.udMaxLevel.BeginInit();
      this.gbType.SuspendLayout();
      this.gbSet.SuspendLayout();
      ((ISupportInitialize) this.pbSet).BeginInit();
      this.gbEffects.SuspendLayout();
      this.gbMod.SuspendLayout();
      this.gbClass.SuspendLayout();
      this.SuspendLayout();
      this.gbBasic.Controls.Add((Control) this.txtInternal);
      this.gbBasic.Controls.Add((Control) this.Label9);
      this.gbBasic.Controls.Add((Control) this.Label7);
      this.gbBasic.Controls.Add((Control) this.Label6);
      this.gbBasic.Controls.Add((Control) this.udMinLevel);
      this.gbBasic.Controls.Add((Control) this.udMaxLevel);
      this.gbBasic.Controls.Add((Control) this.txtDesc);
      this.gbBasic.Controls.Add((Control) this.Label4);
      this.gbBasic.Controls.Add((Control) this.txtNameShort);
      this.gbBasic.Controls.Add((Control) this.Label3);
      this.gbBasic.Controls.Add((Control) this.txtNameFull);
      this.gbBasic.Controls.Add((Control) this.Label2);
      Point point = new Point(96, 8);
      this.gbBasic.Location = point;
      this.gbBasic.Name = "gbBasic";
      Size size = new Size(248, 169);
      this.gbBasic.Size = size;
      this.gbBasic.TabIndex = 11;
      this.gbBasic.TabStop = false;
      this.gbBasic.Text = "Basic:";
      point = new Point(84, 68);
      this.txtInternal.Location = point;
      this.txtInternal.Name = "txtInternal";
      size = new Size(156, 20);
      this.txtInternal.Size = size;
      this.txtInternal.TabIndex = 21;
      point = new Point(8, 68);
      this.Label9.Location = point;
      this.Label9.Name = "Label9";
      size = new Size(72, 20);
      this.Label9.Size = size;
      this.Label9.TabIndex = 20;
      this.Label9.Text = "Internal:";
      this.Label9.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(134, 140);
      this.Label7.Location = point;
      this.Label7.Name = "Label7";
      size = new Size(56, 20);
      this.Label7.Size = size;
      this.Label7.TabIndex = 19;
      this.Label7.Text = "to";
      this.Label7.TextAlign = ContentAlignment.MiddleCenter;
      point = new Point(6, 140);
      this.Label6.Location = point;
      this.Label6.Name = "Label6";
      size = new Size(74, 20);
      this.Label6.Size = size;
      this.Label6.TabIndex = 18;
      this.Label6.Text = "Level range:";
      this.Label6.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(84, 140);
      this.udMinLevel.Location = point;
      Decimal num = new Decimal(new int[4]
      {
        53,
        0,
        0,
        0
      });
      this.udMinLevel.Maximum = num;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udMinLevel.Minimum = num;
      this.udMinLevel.Name = "udMinLevel";
      size = new Size(44, 20);
      this.udMinLevel.Size = size;
      this.udMinLevel.TabIndex = 17;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udMinLevel.Value = num;
      point = new Point(196, 140);
      this.udMaxLevel.Location = point;
      num = new Decimal(new int[4]{ 53, 0, 0, 0 });
      this.udMaxLevel.Maximum = num;
      num = new Decimal(new int[4]{ 1, 0, 0, 0 });
      this.udMaxLevel.Minimum = num;
      this.udMaxLevel.Name = "udMaxLevel";
      size = new Size(44, 20);
      this.udMaxLevel.Size = size;
      this.udMaxLevel.TabIndex = 16;
      num = new Decimal(new int[4]{ 53, 0, 0, 0 });
      this.udMaxLevel.Value = num;
      point = new Point(84, 94);
      this.txtDesc.Location = point;
      this.txtDesc.Multiline = true;
      this.txtDesc.Name = "txtDesc";
      size = new Size(156, 40);
      this.txtDesc.Size = size;
      this.txtDesc.TabIndex = 15;
      point = new Point(8, 98);
      this.Label4.Location = point;
      this.Label4.Name = "Label4";
      size = new Size(72, 20);
      this.Label4.Size = size;
      this.Label4.TabIndex = 14;
      this.Label4.Text = "Description:";
      this.Label4.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(84, 42);
      this.txtNameShort.Location = point;
      this.txtNameShort.Name = "txtNameShort";
      size = new Size(156, 20);
      this.txtNameShort.Size = size;
      this.txtNameShort.TabIndex = 13;
      point = new Point(8, 42);
      this.Label3.Location = point;
      this.Label3.Name = "Label3";
      size = new Size(72, 20);
      this.Label3.Size = size;
      this.Label3.TabIndex = 12;
      this.Label3.Text = "Short Name:";
      this.Label3.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(84, 16);
      this.txtNameFull.Location = point;
      this.txtNameFull.Name = "txtNameFull";
      size = new Size(156, 20);
      this.txtNameFull.Size = size;
      this.txtNameFull.TabIndex = 11;
      point = new Point(8, 16);
      this.Label2.Location = point;
      this.Label2.Name = "Label2";
      size = new Size(72, 20);
      this.Label2.Size = size;
      this.Label2.TabIndex = 10;
      this.Label2.Text = "Full Name:";
      this.Label2.TextAlign = ContentAlignment.MiddleRight;
      this.btnImage.Image = (Image) componentResourceManager.GetObject("btnImage.Image");
      this.btnImage.ImageAlign = ContentAlignment.TopCenter;
      point = new Point(8, 12);
      this.btnImage.Location = point;
      this.btnImage.Name = "btnImage";
      size = new Size(80, 68);
      this.btnImage.Size = size;
      this.btnImage.TabIndex = 9;
      this.btnImage.Text = "ImageName";
      this.btnImage.TextAlign = ContentAlignment.BottomCenter;
      this.gbType.Controls.Add((Control) this.cbSubType);
      this.gbType.Controls.Add((Control) this.typeSet);
      this.gbType.Controls.Add((Control) this.typeIO);
      this.gbType.Controls.Add((Control) this.typeRegular);
      this.gbType.Controls.Add((Control) this.typeHO);
      point = new Point(352, 8);
      this.gbType.Location = point;
      this.gbType.Name = "gbType";
      size = new Size(140, 169);
      this.gbType.Size = size;
      this.gbType.TabIndex = 2;
      this.gbType.TabStop = false;
      this.gbType.Text = "Enhancement Type:";
      this.cbSubType.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 138);
      this.cbSubType.Location = point;
      this.cbSubType.Name = "cbSubType";
      size = new Size(124, 22);
      this.cbSubType.Size = size;
      this.cbSubType.TabIndex = 54;
      this.tTip.SetToolTip((Control) this.cbSubType, "(Currently only apllicable to Stealth IOs");
      this.typeSet.Appearance = Appearance.Button;
      this.typeSet.CheckAlign = ContentAlignment.TopCenter;
      this.typeSet.Image = (Image) componentResourceManager.GetObject("typeSet.Image");
      this.typeSet.ImageAlign = ContentAlignment.TopCenter;
      point = new Point(72, 76);
      this.typeSet.Location = point;
      this.typeSet.Name = "typeSet";
      size = new Size(60, 56);
      this.typeSet.Size = size;
      this.typeSet.TabIndex = 53;
      this.typeSet.Text = "IO Set";
      this.typeSet.TextAlign = ContentAlignment.BottomCenter;
      this.typeIO.Appearance = Appearance.Button;
      this.typeIO.CheckAlign = ContentAlignment.TopCenter;
      this.typeIO.Image = (Image) componentResourceManager.GetObject("typeIO.Image");
      this.typeIO.ImageAlign = ContentAlignment.TopCenter;
      point = new Point(72, 16);
      this.typeIO.Location = point;
      this.typeIO.Name = "typeIO";
      size = new Size(60, 56);
      this.typeIO.Size = size;
      this.typeIO.TabIndex = 52;
      this.typeIO.Text = "Invention";
      this.typeIO.TextAlign = ContentAlignment.BottomCenter;
      this.typeRegular.Appearance = Appearance.Button;
      this.typeRegular.CheckAlign = ContentAlignment.TopCenter;
      this.typeRegular.Image = (Image) componentResourceManager.GetObject("typeRegular.Image");
      this.typeRegular.ImageAlign = ContentAlignment.TopCenter;
      point = new Point(8, 16);
      this.typeRegular.Location = point;
      this.typeRegular.Name = "typeRegular";
      size = new Size(60, 56);
      this.typeRegular.Size = size;
      this.typeRegular.TabIndex = 50;
      this.typeRegular.Text = "Regular";
      this.typeRegular.TextAlign = ContentAlignment.BottomCenter;
      this.typeHO.Appearance = Appearance.Button;
      this.typeHO.CheckAlign = ContentAlignment.TopCenter;
      this.typeHO.Image = (Image) componentResourceManager.GetObject("typeHO.Image");
      this.typeHO.ImageAlign = ContentAlignment.TopCenter;
      point = new Point(8, 76);
      this.typeHO.Location = point;
      this.typeHO.Name = "typeHO";
      size = new Size(60, 56);
      this.typeHO.Size = size;
      this.typeHO.TabIndex = 51;
      this.typeHO.Text = "Special";
      this.typeHO.TextAlign = ContentAlignment.BottomCenter;
      this.cbSet.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(8, 20);
      this.cbSet.Location = point;
      this.cbSet.Name = "cbSet";
      size = new Size(168, 22);
      this.cbSet.Size = size;
      this.cbSet.TabIndex = 13;
      this.gbSet.Controls.Add((Control) this.chkSuperior);
      this.gbSet.Controls.Add((Control) this.pbSet);
      this.gbSet.Controls.Add((Control) this.cbSet);
      this.gbSet.Controls.Add((Control) this.chkUnique);
      point = new Point(496, 8);
      this.gbSet.Location = point;
      this.gbSet.Name = "gbSet";
      size = new Size(184, 119);
      this.gbSet.Size = size;
      this.gbSet.TabIndex = 14;
      this.gbSet.TabStop = false;
      this.gbSet.Text = "Invention Origin Set:";
      point = new Point(60, 94);
      this.chkSuperior.Location = point;
      this.chkSuperior.Name = "chkSuperior";
      size = new Size(84, 16);
      this.chkSuperior.Size = size;
      this.chkSuperior.TabIndex = 21;
      this.chkSuperior.Text = "Superior";
      point = new Point(12, 52);
      this.pbSet.Location = point;
      this.pbSet.Name = "pbSet";
      size = new Size(30, 30);
      this.pbSet.Size = size;
      this.pbSet.TabIndex = 14;
      this.pbSet.TabStop = false;
      point = new Point(60, 60);
      this.chkUnique.Location = point;
      this.chkUnique.Name = "chkUnique";
      size = new Size(84, 16);
      this.chkUnique.Size = size;
      this.chkUnique.TabIndex = 20;
      this.chkUnique.Text = "Unique";
      this.gbEffects.Controls.Add((Control) this.btnDown);
      this.gbEffects.Controls.Add((Control) this.btnUp);
      this.gbEffects.Controls.Add((Control) this.rbBoth);
      this.gbEffects.Controls.Add((Control) this.rbDebuff);
      this.gbEffects.Controls.Add((Control) this.rbBuff);
      this.gbEffects.Controls.Add((Control) this.btnAutoFill);
      this.gbEffects.Controls.Add((Control) this.Label5);
      this.gbEffects.Controls.Add((Control) this.txtProb);
      this.gbEffects.Controls.Add((Control) this.Label1);
      this.gbEffects.Controls.Add((Control) this.btnEdit);
      this.gbEffects.Controls.Add((Control) this.btnAddFX);
      this.gbEffects.Controls.Add((Control) this.btnRemove);
      this.gbEffects.Controls.Add((Control) this.btnAdd);
      this.gbEffects.Controls.Add((Control) this.gbMod);
      this.gbEffects.Controls.Add((Control) this.lstSelected);
      this.gbEffects.Controls.Add((Control) this.lstAvailable);
      this.gbEffects.Controls.Add((Control) this.cbSched);
      this.gbEffects.Controls.Add((Control) this.lblSched);
      point = new Point(4, 210);
      this.gbEffects.Location = point;
      this.gbEffects.Name = "gbEffects";
      size = new Size(584, 284);
      this.gbEffects.Size = size;
      this.gbEffects.TabIndex = 15;
      this.gbEffects.TabStop = false;
      this.gbEffects.Text = "Effects:";
      point = new Point(188, 172);
      this.btnDown.Location = point;
      this.btnDown.Name = "btnDown";
      size = new Size(48, 20);
      this.btnDown.Size = size;
      this.btnDown.TabIndex = 32;
      this.btnDown.Text = "Down";
      point = new Point(188, 148);
      this.btnUp.Location = point;
      this.btnUp.Name = "btnUp";
      size = new Size(48, 20);
      this.btnUp.Size = size;
      this.btnUp.TabIndex = 31;
      this.btnUp.Text = "Up";
      this.rbBoth.Checked = true;
      point = new Point(428, 228);
      this.rbBoth.Location = point;
      this.rbBoth.Name = "rbBoth";
      size = new Size(148, 16);
      this.rbBoth.Size = size;
      this.rbBoth.TabIndex = 30;
      this.rbBoth.TabStop = true;
      this.rbBoth.Text = "Buff/Debuff Effects";
      this.tTip.SetToolTip((Control) this.rbBoth, "Apply to effects regardles of whether the Mag is positive or negative");
      point = new Point(428, 212);
      this.rbDebuff.Location = point;
      this.rbDebuff.Name = "rbDebuff";
      size = new Size(148, 16);
      this.rbDebuff.Size = size;
      this.rbDebuff.TabIndex = 29;
      this.rbDebuff.Text = "Debuff Effects";
      this.tTip.SetToolTip((Control) this.rbDebuff, "Apply only to effects with a negative Mag");
      point = new Point(428, 196);
      this.rbBuff.Location = point;
      this.rbBuff.Name = "rbBuff";
      size = new Size(148, 16);
      this.rbBuff.Size = size;
      this.rbBuff.TabIndex = 28;
      this.rbBuff.Text = "Buff Effects";
      this.tTip.SetToolTip((Control) this.rbBuff, "Apply only to effects with a positive Mag");
      point = new Point(128, 24);
      this.btnAutoFill.Location = point;
      this.btnAutoFill.Name = "btnAutoFill";
      size = new Size(108, 32);
      this.btnAutoFill.Size = size;
      this.btnAutoFill.TabIndex = 27;
      this.btnAutoFill.Text = "AutoFill Names";
      point = new Point(196, 244);
      this.Label5.Location = point;
      this.Label5.Name = "Label5";
      size = new Size(28, 20);
      this.Label5.Size = size;
      this.Label5.TabIndex = 26;
      this.Label5.Text = "(0-1)";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      point = new Point(156, 244);
      this.txtProb.Location = point;
      this.txtProb.Name = "txtProb";
      size = new Size(36, 20);
      this.txtProb.Size = size;
      this.txtProb.TabIndex = 25;
      this.txtProb.Text = "1";
      point = new Point(8, 244);
      this.Label1.Location = point;
      this.Label1.Name = "Label1";
      size = new Size(148, 20);
      this.Label1.Size = size;
      this.Label1.TabIndex = 24;
      this.Label1.Text = "Special Effect Probability:";
      this.Label1.TextAlign = ContentAlignment.MiddleRight;
      this.btnEdit.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      point = new Point(424, 248);
      this.btnEdit.Location = point;
      this.btnEdit.Name = "btnEdit";
      size = new Size(152, 28);
      this.btnEdit.Size = size;
      this.btnEdit.TabIndex = 23;
      this.btnEdit.Text = "Edit Selected...";
      this.btnAddFX.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      point = new Point(8, 208);
      this.btnAddFX.Location = point;
      this.btnAddFX.Name = "btnAddFX";
      size = new Size(228, 28);
      this.btnAddFX.Size = size;
      this.btnAddFX.TabIndex = 22;
      this.btnAddFX.Text = "Add Special Effect... ->";
      this.btnRemove.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      point = new Point(240, 248);
      this.btnRemove.Location = point;
      this.btnRemove.Name = "btnRemove";
      size = new Size(176, 28);
      this.btnRemove.Size = size;
      this.btnRemove.TabIndex = 21;
      this.btnRemove.Text = "Remove Selected";
      this.btnAdd.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      point = new Point(128, 100);
      this.btnAdd.Location = point;
      this.btnAdd.Name = "btnAdd";
      size = new Size(108, 28);
      this.btnAdd.Size = size;
      this.btnAdd.TabIndex = 20;
      this.btnAdd.Text = "Add ->";
      this.gbMod.Controls.Add((Control) this.rbMod4);
      this.gbMod.Controls.Add((Control) this.txtModOther);
      this.gbMod.Controls.Add((Control) this.rbModOther);
      this.gbMod.Controls.Add((Control) this.rbMod3);
      this.gbMod.Controls.Add((Control) this.rbMod2);
      this.gbMod.Controls.Add((Control) this.rbMod1);
      point = new Point(424, 44);
      this.gbMod.Location = point;
      this.gbMod.Name = "gbMod";
      size = new Size(152, 148);
      this.gbMod.Size = size;
      this.gbMod.TabIndex = 19;
      this.gbMod.TabStop = false;
      this.gbMod.Text = "Effect Modifier:";
      point = new Point(12, 80);
      this.rbMod4.Location = point;
      this.rbMod4.Name = "rbMod4";
      size = new Size(128, 20);
      this.rbMod4.Size = size;
      this.rbMod4.TabIndex = 5;
      this.rbMod4.Text = "0.4375 (4-Effect IO)";
      this.txtModOther.Enabled = false;
      point = new Point(28, 120);
      this.txtModOther.Location = point;
      this.txtModOther.Name = "txtModOther";
      size = new Size(112, 20);
      this.txtModOther.Size = size;
      this.txtModOther.TabIndex = 4;
      point = new Point(12, 100);
      this.rbModOther.Location = point;
      this.rbModOther.Name = "rbModOther";
      size = new Size(128, 20);
      this.rbModOther.Size = size;
      this.rbModOther.TabIndex = 3;
      this.rbModOther.Text = "Other";
      point = new Point(12, 60);
      this.rbMod3.Location = point;
      this.rbMod3.Name = "rbMod3";
      size = new Size(128, 20);
      this.rbMod3.Size = size;
      this.rbMod3.TabIndex = 2;
      this.rbMod3.Text = "0.5 (3-Effect IO)";
      point = new Point(12, 40);
      this.rbMod2.Location = point;
      this.rbMod2.Name = "rbMod2";
      size = new Size(128, 20);
      this.rbMod2.Size = size;
      this.rbMod2.TabIndex = 1;
      this.rbMod2.Text = "0.625 (2-Effect IO)";
      this.rbMod1.Checked = true;
      point = new Point(12, 20);
      this.rbMod1.Location = point;
      this.rbMod1.Name = "rbMod1";
      size = new Size(128, 20);
      this.rbMod1.Size = size;
      this.rbMod1.TabIndex = 0;
      this.rbMod1.TabStop = true;
      this.rbMod1.Text = "1.0 (No modifier)";
      this.lstSelected.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstSelected.ItemHeight = 14;
      point = new Point(240, 20);
      this.lstSelected.Location = point;
      this.lstSelected.Name = "lstSelected";
      size = new Size(176, 214);
      this.lstSelected.Size = size;
      this.lstSelected.TabIndex = 16;
      this.lstAvailable.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lstAvailable.ItemHeight = 14;
      point = new Point(8, 20);
      this.lstAvailable.Location = point;
      this.lstAvailable.Name = "lstAvailable";
      size = new Size(116, 172);
      this.lstAvailable.Size = size;
      this.lstAvailable.TabIndex = 15;
      this.cbSched.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(488, 20);
      this.cbSched.Location = point;
      this.cbSched.Name = "cbSched";
      size = new Size(88, 22);
      this.cbSched.Size = size;
      this.cbSched.TabIndex = 14;
      point = new Point(424, 20);
      this.lblSched.Location = point;
      this.lblSched.Name = "lblSched";
      size = new Size(64, 20);
      this.lblSched.Size = size;
      this.lblSched.TabIndex = 3;
      this.lblSched.Text = "Schedule:";
      this.lblSched.TextAlign = ContentAlignment.MiddleRight;
      this.btnOK.DialogResult = DialogResult.OK;
      point = new Point(596, 434);
      this.btnOK.Location = point;
      this.btnOK.Name = "btnOK";
      size = new Size(84, 28);
      this.btnOK.Size = size;
      this.btnOK.TabIndex = 16;
      this.btnOK.Text = "OK";
      this.btnCancel.DialogResult = DialogResult.Cancel;
      point = new Point(596, 466);
      this.btnCancel.Location = point;
      this.btnCancel.Name = "btnCancel";
      size = new Size(84, 28);
      this.btnCancel.Size = size;
      this.btnCancel.TabIndex = 17;
      this.btnCancel.Text = "Cancel";
      this.gbClass.Controls.Add((Control) this.lblClass);
      this.gbClass.Controls.Add((Control) this.pnlClassList);
      this.gbClass.Controls.Add((Control) this.pnlClass);
      point = new Point(596, 178);
      this.gbClass.Location = point;
      this.gbClass.Name = "gbClass";
      size = new Size(84, 252);
      this.gbClass.Size = size;
      this.gbClass.TabIndex = 18;
      this.gbClass.TabStop = false;
      this.gbClass.Text = "Class(es):";
      point = new Point(8, 232);
      this.lblClass.Location = point;
      this.lblClass.Name = "lblClass";
      size = new Size(68, 16);
      this.lblClass.Size = size;
      this.lblClass.TabIndex = 2;
      this.pnlClassList.BackColor = Color.Black;
      point = new Point(84, 16);
      this.pnlClassList.Location = point;
      this.pnlClassList.Name = "pnlClassList";
      size = new Size(180, 212);
      this.pnlClassList.Size = size;
      this.pnlClassList.TabIndex = 1;
      this.pnlClass.BackColor = Color.Black;
      point = new Point(8, 16);
      this.pnlClass.Location = point;
      this.pnlClass.Name = "pnlClass";
      size = new Size(68, 212);
      this.pnlClass.Size = size;
      this.pnlClass.TabIndex = 0;
      this.ImagePicker.Filter = "PNG Images|*.png";
      this.ImagePicker.Title = "Select Image File";
      point = new Point(8, 84);
      this.btnNoImage.Location = point;
      this.btnNoImage.Name = "btnNoImage";
      size = new Size(80, 20);
      this.btnNoImage.Size = size;
      this.btnNoImage.TabIndex = 19;
      this.btnNoImage.Text = "Clear Image";
      this.tTip.AutoPopDelay = 10000;
      this.tTip.InitialDelay = 250;
      this.tTip.ReshowDelay = 100;
      this.cbMutEx.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(504, 146);
      this.cbMutEx.Location = point;
      this.cbMutEx.Name = "cbMutEx";
      size = new Size(168, 22);
      this.cbMutEx.Size = size;
      this.cbMutEx.TabIndex = 21;
      this.tTip.SetToolTip((Control) this.cbMutEx, "(Currently only apllicable to Stealth IOs");
      this.cbRecipe.DropDownStyle = ComboBoxStyle.DropDownList;
      point = new Point(96, 183);
      this.cbRecipe.Location = point;
      this.cbRecipe.Name = "cbRecipe";
      size = new Size(248, 22);
      this.cbRecipe.Size = size;
      this.cbRecipe.TabIndex = 23;
      this.tTip.SetToolTip((Control) this.cbRecipe, "(Currently only apllicable to Stealth IOs");
      point = new Point(496, 130);
      this.Label8.Location = point;
      this.Label8.Name = "Label8";
      size = new Size(80, 16);
      this.Label8.Size = size;
      this.Label8.TabIndex = 22;
      this.Label8.Text = "MutEx Group:";
      point = new Point(10, 183);
      this.Label10.Location = point;
      this.Label10.Name = "Label10";
      size = new Size(80, 22);
      this.Label10.Size = size;
      this.Label10.TabIndex = 24;
      this.Label10.Text = "Recipe:";
      this.Label10.TextAlign = ContentAlignment.MiddleRight;
      point = new Point(352, 183);
      this.btnEditPowerData.Location = point;
      this.btnEditPowerData.Name = "btnEditPowerData";
      size = new Size(236, 22);
      this.btnEditPowerData.Size = size;
      this.btnEditPowerData.TabIndex = 25;
      this.btnEditPowerData.Text = "Edit Power_Mode Data";
      this.btnEditPowerData.UseVisualStyleBackColor = true;
      point = new Point(8, 146);
      this.StaticIndex.Location = point;
      this.StaticIndex.Name = "StaticIndex";
      size = new Size(82, 20);
      this.StaticIndex.Size = size;
      this.StaticIndex.TabIndex = 26;
      this.Label11.AutoSize = true;
      point = new Point(8, 126);
      this.Label11.Location = point;
      this.Label11.Name = "Label11";
      size = new Size(63, 14);
      this.Label11.Size = size;
      this.Label11.TabIndex = 27;
      this.Label11.Text = "Static Index";
      this.AcceptButton = (IButtonControl) this.btnOK;
      size = new Size(5, 13);
      this.AutoScaleBaseSize = size;
      this.CancelButton = (IButtonControl) this.btnCancel;
      size = new Size(686, 501);
      this.ClientSize = size;
      this.Controls.Add((Control) this.Label11);
      this.Controls.Add((Control) this.StaticIndex);
      this.Controls.Add((Control) this.btnEditPowerData);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.cbRecipe);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.btnNoImage);
      this.Controls.Add((Control) this.gbClass);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.gbEffects);
      this.Controls.Add((Control) this.gbSet);
      this.Controls.Add((Control) this.gbBasic);
      this.Controls.Add((Control) this.gbType);
      this.Controls.Add((Control) this.btnImage);
      this.Controls.Add((Control) this.cbMutEx);
      this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmEnhData);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Edit [EnhancementName]";
      this.gbBasic.ResumeLayout(false);
      this.gbBasic.PerformLayout();
      this.udMinLevel.EndInit();
      this.udMaxLevel.EndInit();
      this.gbType.ResumeLayout(false);
      this.gbSet.ResumeLayout(false);
      ((ISupportInitialize) this.pbSet).EndInit();
      this.gbEffects.ResumeLayout(false);
      this.gbEffects.PerformLayout();
      this.gbMod.ResumeLayout(false);
      this.gbMod.PerformLayout();
      this.gbClass.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void ListSelectedEffects()
    {
      Enums.eEnhance eEnhance = Enums.eEnhance.None;
      Enums.eMez eMez = Enums.eMez.None;
      string[] names1 = Enum.GetNames(eEnhance.GetType());
      string[] names2 = Enum.GetNames(eMez.GetType());
      this.lstSelected.BeginUpdate();
      this.lstSelected.Items.Clear();
      int num = this.myEnh.Effect.Length - 1;
      for (int index = 0; index <= num; ++index)
      {
        if (this.myEnh.Effect[index].Mode == Enums.eEffMode.Enhancement)
        {
          string str = names1[this.myEnh.Effect[index].Enhance.ID];
          if (this.myEnh.Effect[index].Enhance.SubID > -1)
            str = str + ":" + names2[this.myEnh.Effect[index].Enhance.SubID];
          this.lstSelected.Items.Add((object) str);
        }
        else
          this.lstSelected.Items.Add((object) ("Special: " + this.myEnh.Effect[index].FX.BuildEffectString(false, "", false, false, false)));
      }
      this.lstSelected.EndUpdate();
    }

    private void lstAvailable_DoubleClick(object sender, EventArgs e)
    {
      this.EffectList_Add();
    }

    private void lstSelected_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.DisplayEnhanceData();
      this.tTip.SetToolTip((Control) this.lstSelected, Conversions.ToString(this.lstSelected.SelectedItem));
    }

    public int MezPicker(int Index = 1)
    {
      Enums.eMez eMez = Enums.eMez.None;
      frmEnhMiniPick frmEnhMiniPick = new frmEnhMiniPick();
      string[] names = Enum.GetNames(eMez.GetType());
      int num1 = names.Length - 1;
      for (int index = 1; index <= num1; ++index)
        frmEnhMiniPick.lbList.Items.Add((object) names[index]);
      if (Index > -1 & Index < frmEnhMiniPick.lbList.Items.Count)
        frmEnhMiniPick.lbList.SelectedIndex = Index - 1;
      else
        frmEnhMiniPick.lbList.SelectedIndex = 0;
      int num2 = (int) frmEnhMiniPick.ShowDialog();
      return frmEnhMiniPick.lbList.SelectedIndex + 1;
    }

    private void PickerExpand()
    {
      if (this.gbClass.Width == 84)
      {
        this.gbClass.Width = 272;
        this.gbClass.Left -= 188;
        this.lblClass.Width = 256;
      }
      else
      {
        this.gbClass.Width = 84;
        this.gbClass.Left = 596;
        this.lblClass.Width = this.pnlClass.Width;
      }
    }

    private void pnlClass_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        this.PickerExpand();
      }
      else
      {
        if (this.gbClass.Width <= 84 || this.Loading)
          return;
        int num1 = -1;
        int num2 = -1;
        int num3 = 0;
        do
        {
          if (e.X > (this.EnhPadding + this.ClassSize) * num3 & e.X < (this.EnhPadding + this.ClassSize) * (num3 + 1))
            num1 = num3;
          ++num3;
        }
        while (num3 <= 1);
        int num4 = 0;
        do
        {
          if (e.Y > (this.EnhPadding + this.ClassSize) * num4 & e.Y < (this.EnhPadding + this.ClassSize) * (num4 + 1))
            num2 = num4;
          ++num4;
        }
        while (num4 <= 10);
        int num5 = num1 + num2 * 2;
        if (num5 < this.myEnh.ClassID.Length & num1 > -1 & num2 > -1)
        {
          int[] numArray = new int[this.myEnh.ClassID.Length - 1 + 1];
          int num6 = this.myEnh.ClassID.Length - 1;
          for (int index = 0; index <= num6; ++index)
            numArray[index] = this.myEnh.ClassID[index];
          int index1 = 0;
          this.myEnh.ClassID = new int[this.myEnh.ClassID.Length - 2 + 1];
          int num7 = numArray.Length - 1;
          for (int index2 = 0; index2 <= num7; ++index2)
          {
            if (index2 != num5)
            {
              this.myEnh.ClassID[index1] = numArray[index2];
              ++index1;
            }
          }
          Array.Sort<int>(this.myEnh.ClassID);
          this.DrawClasses();
        }
      }
    }

    private void pnlClass_MouseMove(object sender, MouseEventArgs e)
    {
      int num1 = -1;
      int num2 = -1;
      int num3 = 0;
      do
      {
        if (e.X > (this.EnhPadding + this.ClassSize) * num3 & e.X < (this.EnhPadding + this.ClassSize) * (num3 + 1))
          num1 = num3;
        ++num3;
      }
      while (num3 <= 1);
      int num4 = 0;
      do
      {
        if (e.Y > (this.EnhPadding + this.ClassSize) * num4 & e.Y < (this.EnhPadding + this.ClassSize) * (num4 + 1))
          num2 = num4;
        ++num4;
      }
      while (num4 <= 10);
      int index = num1 + num2 * 2;
      if (index < this.myEnh.ClassID.Length & num1 > -1 & num2 > -1)
      {
        if (this.gbClass.Width < 100)
          this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[this.myEnh.ClassID[index]].ShortName;
        else
          this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[this.myEnh.ClassID[index]].Name;
      }
      else
        this.lblClass.Text = "";
    }

    private void pnlClass_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxClass == null)
        return;
      e.Graphics.DrawImageUnscaled((Image) this.bxClass.Bitmap, 0, 0);
    }

    private void pnlClassList_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        this.PickerExpand();
      }
      else
      {
        if (this.gbClass.Width <= 84 || this.Loading)
          return;
        int num1 = -1;
        int num2 = -1;
        int num3 = this.EnhAcross - 1;
        for (int index = 0; index <= num3; ++index)
        {
          if (e.X > (this.EnhPadding + 30) * index & e.X < (this.EnhPadding + 30) * (index + 1))
            num1 = index;
        }
        int num4 = 0;
        do
        {
          if (e.Y > (this.EnhPadding + 30) * num4 & e.Y < (this.EnhPadding + 30) * (num4 + 1))
            num2 = num4;
          ++num4;
        }
        while (num4 <= 10);
        int num5 = num1 + num2 * this.EnhAcross;
        if (num5 < DatabaseAPI.Database.EnhancementClasses.Length & num1 > -1 & num2 > -1)
        {
          bool flag = false;
          int num6 = this.myEnh.ClassID.Length - 1;
          for (int index = 0; index <= num6; ++index)
          {
            if (this.myEnh.ClassID[index] == num5)
              flag = true;
          }
          if (!flag)
          {
            IEnhancement enh = this.myEnh;
            int[] numArray = (int[]) Utils.CopyArray((Array) enh.ClassID, (Array) new int[this.myEnh.ClassID.Length + 1]);
            enh.ClassID = numArray;
            this.myEnh.ClassID[this.myEnh.ClassID.Length - 1] = num5;
            Array.Sort<int>(this.myEnh.ClassID);
            this.DrawClasses();
          }
        }
      }
    }

    private void pnlClassList_MouseMove(object sender, MouseEventArgs e)
    {
      int num1 = -1;
      int num2 = -1;
      int num3 = this.EnhAcross - 1;
      for (int index = 0; index <= num3; ++index)
      {
        if (e.X > (this.EnhPadding + 30) * index & e.X < (this.EnhPadding + 30) * (index + 1))
          num1 = index;
      }
      int num4 = 0;
      do
      {
        if (e.Y > (this.EnhPadding + 30) * num4 & e.Y < (this.EnhPadding + 30) * (num4 + 1))
          num2 = num4;
        ++num4;
      }
      while (num4 <= 10);
      int index1 = num1 + num2 * this.EnhAcross;
      if (index1 < DatabaseAPI.Database.EnhancementClasses.Length & num1 > -1 & num2 > -1)
        this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[index1].Name;
      else
        this.lblClass.Text = string.Empty;
    }

    private void pnlClassList_Paint(object sender, PaintEventArgs e)
    {
      if (this.bxClassList == null)
        return;
      e.Graphics.DrawImageUnscaled((Image) this.bxClassList.Bitmap, 0, 0);
    }

    private void rbBuffDebuff_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading || this.lstSelected.SelectedIndex <= -1)
        return;
      int selectedIndex = this.lstSelected.SelectedIndex;
      if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
      {
        if (this.rbBuff.Checked)
          this.myEnh.Effect[selectedIndex].BuffMode = Enums.eBuffDebuff.BuffOnly;
        else if (this.rbDebuff.Checked)
          this.myEnh.Effect[selectedIndex].BuffMode = Enums.eBuffDebuff.DeBuffOnly;
        else if (this.rbBoth.Checked)
          this.myEnh.Effect[selectedIndex].BuffMode = Enums.eBuffDebuff.Any;
      }
    }

    private void rbMod_CheckedChanged(object sender, EventArgs e)
    {
      if (this.lstSelected.SelectedIndex <= -1)
        return;
      int selectedIndex = this.lstSelected.SelectedIndex;
      if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
      {
        this.txtModOther.Enabled = false;
        if (this.rbModOther.Checked)
        {
          this.txtModOther.Enabled = true;
          this.myEnh.Effect[selectedIndex].Multiplier = (float) Conversion.Val(this.txtModOther.Text);
          this.txtModOther.SelectAll();
          this.txtModOther.Select();
        }
        else if (this.rbMod1.Checked)
          this.myEnh.Effect[selectedIndex].Multiplier = 1f;
        else if (this.rbMod2.Checked)
          this.myEnh.Effect[selectedIndex].Multiplier = 0.625f;
        else if (this.rbMod3.Checked)
          this.myEnh.Effect[selectedIndex].Multiplier = 0.5f;
        else if (this.rbMod4.Checked)
          this.myEnh.Effect[selectedIndex].Multiplier = 7f / 16f;
      }
    }

    public void SetMaxLevel(int iValue)
    {
      if (Decimal.Compare(new Decimal(iValue), this.udMaxLevel.Minimum) < 0)
        iValue = Convert.ToInt32(this.udMaxLevel.Minimum);
      if (Decimal.Compare(new Decimal(iValue), this.udMaxLevel.Maximum) > 0)
        iValue = Convert.ToInt32(this.udMaxLevel.Maximum);
      this.udMaxLevel.Value = new Decimal(iValue);
    }

    public void SetMinLevel(int iValue)
    {
      if (Decimal.Compare(new Decimal(iValue), this.udMinLevel.Minimum) < 0)
        iValue = Convert.ToInt32(this.udMinLevel.Minimum);
      if (Decimal.Compare(new Decimal(iValue), this.udMinLevel.Maximum) > 0)
        iValue = Convert.ToInt32(this.udMinLevel.Maximum);
      this.udMinLevel.Value = new Decimal(iValue);
    }

    public void SetTypeIcons()
    {
      ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(30, 30);
      ExtendedBitmap extendedBitmap2 = !(this.myEnh.Image != "") ? new ExtendedBitmap(30, 30) : new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.myEnh.Image);
      extendedBitmap1.Graphics.Clear(Color.Transparent);
      extendedBitmap1.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.Normal)), GraphicsUnit.Pixel);
      extendedBitmap1.Graphics.DrawImage((Image) extendedBitmap2.Bitmap, 0, 0);
      this.typeRegular.Image = (Image) new Bitmap((Image) extendedBitmap1.Bitmap);
      extendedBitmap1.Graphics.Clear(Color.Transparent);
      extendedBitmap1.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.InventO)), GraphicsUnit.Pixel);
      extendedBitmap1.Graphics.DrawImage((Image) extendedBitmap2.Bitmap, 0, 0);
      this.typeIO.Image = (Image) new Bitmap((Image) extendedBitmap1.Bitmap);
      extendedBitmap1.Graphics.Clear(Color.Transparent);
      extendedBitmap1.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.SpecialO)), GraphicsUnit.Pixel);
      extendedBitmap1.Graphics.DrawImage((Image) extendedBitmap2.Bitmap, 0, 0);
      this.typeHO.Image = (Image) new Bitmap((Image) extendedBitmap1.Bitmap);
      extendedBitmap1.Graphics.Clear(Color.Transparent);
      extendedBitmap1.Graphics.DrawImage((Image) I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.SetO)), GraphicsUnit.Pixel);
      extendedBitmap1.Graphics.DrawImage((Image) extendedBitmap2.Bitmap, 0, 0);
      this.typeSet.Image = (Image) new Bitmap((Image) extendedBitmap1.Bitmap);
    }

    private void StaticIndex_TextChanged(object sender, EventArgs e)
    {
      this.myEnh.StaticIndex = Conversions.ToInteger(this.StaticIndex.Text);
    }

    private void txtDesc_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.Desc = this.txtDesc.Text;
    }

    private void txtInternal_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.UID = this.txtInternal.Text;
    }

    private void txtModOther_TextChanged(object sender, EventArgs e)
    {
      if (this.lstSelected.SelectedIndex <= -1)
        return;
      int selectedIndex = this.lstSelected.SelectedIndex;
      if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement && this.rbModOther.Checked)
        this.myEnh.Effect[selectedIndex].Multiplier = (float) Conversion.Val(this.txtModOther.Text);
    }

    private void txtNameFull_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.Name = this.txtNameFull.Text;
      this.UpdateTitle();
    }

    private void txtNameShort_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.ShortName = this.txtNameShort.Text;
    }

    private void txtProb_Leave(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.txtProb.Text = Conversions.ToString(this.myEnh.EffectChance);
    }

    private void txtProb_TextChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      float num = (float) Conversion.Val(this.txtProb.Text);
      if ((double) num > 1.0)
        num = 1f;
      if ((double) num < 0.0)
        num = 0.0f;
      this.myEnh.EffectChance = num;
    }

    private void type_CheckedChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      if (this.typeRegular.Checked)
      {
        this.myEnh.TypeID = Enums.eType.Normal;
        this.chkUnique.Checked = false;
        this.cbSubType.Enabled = false;
        this.cbSubType.SelectedIndex = -1;
        this.cbRecipe.SelectedIndex = -1;
        this.cbRecipe.Enabled = false;
      }
      else if (this.typeIO.Checked)
      {
        this.myEnh.TypeID = Enums.eType.InventO;
        this.chkUnique.Checked = false;
        this.cbSubType.Enabled = false;
        this.cbSubType.SelectedIndex = -1;
        this.cbRecipe.SelectedIndex = 0;
        this.cbRecipe.Enabled = true;
      }
      else if (this.typeHO.Checked)
      {
        this.myEnh.TypeID = Enums.eType.SpecialO;
        this.chkUnique.Checked = false;
        this.cbSubType.Enabled = true;
        this.cbSubType.SelectedIndex = 0;
        this.cbRecipe.SelectedIndex = -1;
        this.cbRecipe.Enabled = false;
      }
      else if (this.typeSet.Checked)
      {
        this.myEnh.TypeID = Enums.eType.SetO;
        this.cbSet.Select();
        this.cbSubType.Enabled = false;
        this.cbSubType.SelectedIndex = -1;
        this.cbRecipe.SelectedIndex = 0;
        this.cbRecipe.Enabled = true;
      }
      this.DisplaySet();
      this.UpdateTitle();
      this.DisplayIcon();
    }

    private void udMaxLevel_Leave(object sender, EventArgs e)
    {
      this.SetMaxLevel((int) Math.Round(Conversion.Val(this.udMaxLevel.Text)));
      this.myEnh.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
    }

    private void udMaxLevel_ValueChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
      this.udMinLevel.Maximum = this.udMaxLevel.Value;
    }

    private void udMinLevel_Leave(object sender, EventArgs e)
    {
      this.SetMinLevel((int) Math.Round(Conversion.Val(this.udMinLevel.Text)));
      this.myEnh.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
    }

    private void udMinLevel_ValueChanged(object sender, EventArgs e)
    {
      if (this.Loading)
        return;
      this.myEnh.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
      this.udMaxLevel.Minimum = this.udMinLevel.Value;
    }

    public void UpdateTitle()
    {
      string str1 = "Edit ";
      string str2;
      switch (this.myEnh.TypeID)
      {
        case Enums.eType.InventO:
          str2 = str1 + "Invention: ";
          break;
        case Enums.eType.SpecialO:
          str2 = str1 + "HO: ";
          break;
        case Enums.eType.SetO:
          str2 = this.myEnh.nIDSet > -1 ? str1 + DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].DisplayName + ": " : str1 + "Set Invention: ";
          break;
        default:
          str2 = str1 + "Enhancement: ";
          break;
      }
      this.Text = str2 + this.myEnh.Name;
    }
  }
}
