using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmEnhData : Form
    {
    
        internal virtual Button btnAdd
        {
            get
            {
                return this._btnAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click -= eventHandler;
                }
                this._btnAdd = value;
                if (this._btnAdd != null)
                {
                    this._btnAdd.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnAddFX
        {
            get
            {
                return this._btnAddFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAddFX_Click);
                if (this._btnAddFX != null)
                {
                    this._btnAddFX.Click -= eventHandler;
                }
                this._btnAddFX = value;
                if (this._btnAddFX != null)
                {
                    this._btnAddFX.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnAutoFill
        {
            get
            {
                return this._btnAutoFill;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAutoFill_Click);
                if (this._btnAutoFill != null)
                {
                    this._btnAutoFill.Click -= eventHandler;
                }
                this._btnAutoFill = value;
                if (this._btnAutoFill != null)
                {
                    this._btnAutoFill.Click += eventHandler;
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
        internal virtual Button btnDown
        {
            get
            {
                return this._btnDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDown_Click);
                if (this._btnDown != null)
                {
                    this._btnDown.Click -= eventHandler;
                }
                this._btnDown = value;
                if (this._btnDown != null)
                {
                    this._btnDown.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnEdit
        {
            get
            {
                return this._btnEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEdit_Click);
                if (this._btnEdit != null)
                {
                    this._btnEdit.Click -= eventHandler;
                }
                this._btnEdit = value;
                if (this._btnEdit != null)
                {
                    this._btnEdit.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnEditPowerData
        {
            get
            {
                return this._btnEditPowerData;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEditPowerData_Click);
                if (this._btnEditPowerData != null)
                {
                    this._btnEditPowerData.Click -= eventHandler;
                }
                this._btnEditPowerData = value;
                if (this._btnEditPowerData != null)
                {
                    this._btnEditPowerData.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnImage
        {
            get
            {
                return this._btnImage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnImage_Click);
                if (this._btnImage != null)
                {
                    this._btnImage.Click -= eventHandler;
                }
                this._btnImage = value;
                if (this._btnImage != null)
                {
                    this._btnImage.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnNoImage
        {
            get
            {
                return this._btnNoImage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnNoImage_Click);
                if (this._btnNoImage != null)
                {
                    this._btnNoImage.Click -= eventHandler;
                }
                this._btnNoImage = value;
                if (this._btnNoImage != null)
                {
                    this._btnNoImage.Click += eventHandler;
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
        internal virtual Button btnRemove
        {
            get
            {
                return this._btnRemove;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnRemove_Click);
                if (this._btnRemove != null)
                {
                    this._btnRemove.Click -= eventHandler;
                }
                this._btnRemove = value;
                if (this._btnRemove != null)
                {
                    this._btnRemove.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnUp
        {
            get
            {
                return this._btnUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUp_Click);
                if (this._btnUp != null)
                {
                    this._btnUp.Click -= eventHandler;
                }
                this._btnUp = value;
                if (this._btnUp != null)
                {
                    this._btnUp.Click += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbMutEx
        {
            get
            {
                return this._cbMutEx;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbMutEx_SelectedIndexChanged);
                if (this._cbMutEx != null)
                {
                    this._cbMutEx.SelectedIndexChanged -= eventHandler;
                }
                this._cbMutEx = value;
                if (this._cbMutEx != null)
                {
                    this._cbMutEx.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbRecipe
        {
            get
            {
                return this._cbRecipe;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbRecipe_SelectedIndexChanged);
                if (this._cbRecipe != null)
                {
                    this._cbRecipe.SelectedIndexChanged -= eventHandler;
                }
                this._cbRecipe = value;
                if (this._cbRecipe != null)
                {
                    this._cbRecipe.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbSched
        {
            get
            {
                return this._cbSched;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSched_SelectedIndexChanged);
                if (this._cbSched != null)
                {
                    this._cbSched.SelectedIndexChanged -= eventHandler;
                }
                this._cbSched = value;
                if (this._cbSched != null)
                {
                    this._cbSched.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbSet
        {
            get
            {
                return this._cbSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSet_SelectedIndexChanged);
                if (this._cbSet != null)
                {
                    this._cbSet.SelectedIndexChanged -= eventHandler;
                }
                this._cbSet = value;
                if (this._cbSet != null)
                {
                    this._cbSet.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbSubType
        {
            get
            {
                return this._cbSubType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbSubType_SelectedIndexChanged);
                if (this._cbSubType != null)
                {
                    this._cbSubType.SelectedIndexChanged -= eventHandler;
                }
                this._cbSubType = value;
                if (this._cbSubType != null)
                {
                    this._cbSubType.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkSuperior
        {
            get
            {
                return this._chkSuperior;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSuperior_CheckedChanged);
                if (this._chkSuperior != null)
                {
                    this._chkSuperior.CheckedChanged -= eventHandler;
                }
                this._chkSuperior = value;
                if (this._chkSuperior != null)
                {
                    this._chkSuperior.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual CheckBox chkUnique
        {
            get
            {
                return this._chkUnique;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkUnique_CheckedChanged);
                if (this._chkUnique != null)
                {
                    this._chkUnique.CheckedChanged -= eventHandler;
                }
                this._chkUnique = value;
                if (this._chkUnique != null)
                {
                    this._chkUnique.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual GroupBox gbBasic
        {
            get
            {
                return this._gbBasic;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
        internal virtual Label lblClass
        {
            get
            {
                return this._lblClass;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstAvailable_DoubleClick);
                if (this._lstAvailable != null)
                {
                    this._lstAvailable.DoubleClick -= eventHandler;
                }
                this._lstAvailable = value;
                if (this._lstAvailable != null)
                {
                    this._lstAvailable.DoubleClick += eventHandler;
                }
            }
        }
        internal virtual ListBox lstSelected
        {
            get
            {
                return this._lstSelected;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lstSelected_SelectedIndexChanged);
                if (this._lstSelected != null)
                {
                    this._lstSelected.SelectedIndexChanged -= eventHandler;
                }
                this._lstSelected = value;
                if (this._lstSelected != null)
                {
                    this._lstSelected.SelectedIndexChanged += eventHandler;
                }
            }
        }
        internal virtual PictureBox pbSet
        {
            get
            {
                return this._pbSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlClass_MouseMove);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlClass_Paint);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlClass_MouseDown);
                if (this._pnlClass != null)
                {
                    this._pnlClass.MouseMove -= mouseEventHandler;
                    this._pnlClass.Paint -= paintEventHandler;
                    this._pnlClass.MouseDown -= mouseEventHandler2;
                }
                this._pnlClass = value;
                if (this._pnlClass != null)
                {
                    this._pnlClass.MouseMove += mouseEventHandler;
                    this._pnlClass.Paint += paintEventHandler;
                    this._pnlClass.MouseDown += mouseEventHandler2;
                }
            }
        }
        internal virtual Panel pnlClassList
        {
            get
            {
                return this._pnlClassList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlClassList_MouseMove);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pnlClassList_Paint);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlClassList_MouseDown);
                if (this._pnlClassList != null)
                {
                    this._pnlClassList.MouseMove -= mouseEventHandler;
                    this._pnlClassList.Paint -= paintEventHandler;
                    this._pnlClassList.MouseDown -= mouseEventHandler2;
                }
                this._pnlClassList = value;
                if (this._pnlClassList != null)
                {
                    this._pnlClassList.MouseMove += mouseEventHandler;
                    this._pnlClassList.Paint += paintEventHandler;
                    this._pnlClassList.MouseDown += mouseEventHandler2;
                }
            }
        }
        internal virtual RadioButton rbBoth
        {
            get
            {
                return this._rbBoth;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbBuffDebuff_CheckedChanged);
                if (this._rbBoth != null)
                {
                    this._rbBoth.CheckedChanged -= eventHandler;
                }
                this._rbBoth = value;
                if (this._rbBoth != null)
                {
                    this._rbBoth.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbBuff
        {
            get
            {
                return this._rbBuff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbBuffDebuff_CheckedChanged);
                if (this._rbBuff != null)
                {
                    this._rbBuff.CheckedChanged -= eventHandler;
                }
                this._rbBuff = value;
                if (this._rbBuff != null)
                {
                    this._rbBuff.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbDebuff
        {
            get
            {
                return this._rbDebuff;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbBuffDebuff_CheckedChanged);
                if (this._rbDebuff != null)
                {
                    this._rbDebuff.CheckedChanged -= eventHandler;
                }
                this._rbDebuff = value;
                if (this._rbDebuff != null)
                {
                    this._rbDebuff.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbMod1
        {
            get
            {
                return this._rbMod1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
                if (this._rbMod1 != null)
                {
                    this._rbMod1.CheckedChanged -= eventHandler;
                }
                this._rbMod1 = value;
                if (this._rbMod1 != null)
                {
                    this._rbMod1.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbMod2
        {
            get
            {
                return this._rbMod2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
                if (this._rbMod2 != null)
                {
                    this._rbMod2.CheckedChanged -= eventHandler;
                }
                this._rbMod2 = value;
                if (this._rbMod2 != null)
                {
                    this._rbMod2.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbMod3
        {
            get
            {
                return this._rbMod3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
                if (this._rbMod3 != null)
                {
                    this._rbMod3.CheckedChanged -= eventHandler;
                }
                this._rbMod3 = value;
                if (this._rbMod3 != null)
                {
                    this._rbMod3.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbMod4
        {
            get
            {
                return this._rbMod4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
                if (this._rbMod4 != null)
                {
                    this._rbMod4.CheckedChanged -= eventHandler;
                }
                this._rbMod4 = value;
                if (this._rbMod4 != null)
                {
                    this._rbMod4.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton rbModOther
        {
            get
            {
                return this._rbModOther;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbMod_CheckedChanged);
                if (this._rbModOther != null)
                {
                    this._rbModOther.CheckedChanged -= eventHandler;
                }
                this._rbModOther = value;
                if (this._rbModOther != null)
                {
                    this._rbModOther.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox StaticIndex
        {
            get
            {
                return this._StaticIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.StaticIndex_TextChanged);
                if (this._StaticIndex != null)
                {
                    this._StaticIndex.TextChanged -= eventHandler;
                }
                this._StaticIndex = value;
                if (this._StaticIndex != null)
                {
                    this._StaticIndex.TextChanged += eventHandler;
                }
            }
        }
        internal virtual ToolTip tTip
        {
            get
            {
                return this._tTip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDesc_TextChanged);
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged -= eventHandler;
                }
                this._txtDesc = value;
                if (this._txtDesc != null)
                {
                    this._txtDesc.TextChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtInternal
        {
            get
            {
                return this._txtInternal;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtInternal_TextChanged);
                if (this._txtInternal != null)
                {
                    this._txtInternal.TextChanged -= eventHandler;
                }
                this._txtInternal = value;
                if (this._txtInternal != null)
                {
                    this._txtInternal.TextChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtModOther
        {
            get
            {
                return this._txtModOther;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtModOther_TextChanged);
                if (this._txtModOther != null)
                {
                    this._txtModOther.TextChanged -= eventHandler;
                }
                this._txtModOther = value;
                if (this._txtModOther != null)
                {
                    this._txtModOther.TextChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtNameFull
        {
            get
            {
                return this._txtNameFull;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNameFull_TextChanged);
                if (this._txtNameFull != null)
                {
                    this._txtNameFull.TextChanged -= eventHandler;
                }
                this._txtNameFull = value;
                if (this._txtNameFull != null)
                {
                    this._txtNameFull.TextChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtNameShort
        {
            get
            {
                return this._txtNameShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNameShort_TextChanged);
                if (this._txtNameShort != null)
                {
                    this._txtNameShort.TextChanged -= eventHandler;
                }
                this._txtNameShort = value;
                if (this._txtNameShort != null)
                {
                    this._txtNameShort.TextChanged += eventHandler;
                }
            }
        }
        internal virtual TextBox txtProb
        {
            get
            {
                return this._txtProb;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtProb_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtProb_TextChanged);
                if (this._txtProb != null)
                {
                    this._txtProb.Leave -= eventHandler;
                    this._txtProb.TextChanged -= eventHandler2;
                }
                this._txtProb = value;
                if (this._txtProb != null)
                {
                    this._txtProb.Leave += eventHandler;
                    this._txtProb.TextChanged += eventHandler2;
                }
            }
        }
        internal virtual RadioButton typeHO
        {
            get
            {
                return this._typeHO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
                if (this._typeHO != null)
                {
                    this._typeHO.CheckedChanged -= eventHandler;
                }
                this._typeHO = value;
                if (this._typeHO != null)
                {
                    this._typeHO.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton typeIO
        {
            get
            {
                return this._typeIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
                if (this._typeIO != null)
                {
                    this._typeIO.CheckedChanged -= eventHandler;
                }
                this._typeIO = value;
                if (this._typeIO != null)
                {
                    this._typeIO.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton typeRegular
        {
            get
            {
                return this._typeRegular;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
                if (this._typeRegular != null)
                {
                    this._typeRegular.CheckedChanged -= eventHandler;
                }
                this._typeRegular = value;
                if (this._typeRegular != null)
                {
                    this._typeRegular.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual RadioButton typeSet
        {
            get
            {
                return this._typeSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.type_CheckedChanged);
                if (this._typeSet != null)
                {
                    this._typeSet.CheckedChanged -= eventHandler;
                }
                this._typeSet = value;
                if (this._typeSet != null)
                {
                    this._typeSet.CheckedChanged += eventHandler;
                }
            }
        }
        internal virtual NumericUpDown udMaxLevel
        {
            get
            {
                return this._udMaxLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udMaxLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.udMaxLevel_ValueChanged);
                if (this._udMaxLevel != null)
                {
                    this._udMaxLevel.Leave -= eventHandler;
                    this._udMaxLevel.ValueChanged -= eventHandler2;
                }
                this._udMaxLevel = value;
                if (this._udMaxLevel != null)
                {
                    this._udMaxLevel.Leave += eventHandler;
                    this._udMaxLevel.ValueChanged += eventHandler2;
                }
            }
        }
        internal virtual NumericUpDown udMinLevel
        {
            get
            {
                return this._udMinLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udMinLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.udMinLevel_ValueChanged);
                if (this._udMinLevel != null)
                {
                    this._udMinLevel.Leave -= eventHandler;
                    this._udMinLevel.ValueChanged -= eventHandler2;
                }
                this._udMinLevel = value;
                if (this._udMinLevel != null)
                {
                    this._udMinLevel.Leave += eventHandler;
                    this._udMinLevel.ValueChanged += eventHandler2;
                }
            }
        }
        public frmEnhData(ref IEnhancement iEnh)
        {
            base.Load += this.frmEnhData_Load;
            this.ClassSize = 15;
            this.EnhPadding = 3;
            this.EnhAcross = 5;
            this.Loading = true;
            this.InitializeComponent();
            this.myEnh = new Enhancement(iEnh);
            this.ClassSize = 22;
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            this.EffectList_Add();
        }
        void btnAddFX_Click(object sender, EventArgs e)
        {
            IEffect iFX = new Effect();
            frmPowerEffect frmPowerEffect = new frmPowerEffect(ref iFX);
            if (frmPowerEffect.ShowDialog() == DialogResult.OK)
            {
                IEnhancement enh = this.myEnh;
                Enums.sEffect[] sEffectArray = (Enums.sEffect[])Utils.CopyArray(enh.Effect, new Enums.sEffect[this.myEnh.Effect.Length + 1]);
                enh.Effect = sEffectArray;
                Enums.sEffect[] effect = this.myEnh.Effect;
                int index = this.myEnh.Effect.Length - 1;
                effect[index].Mode = Enums.eEffMode.FX;
                effect[index].Enhance.ID = -1;
                effect[index].Enhance.SubID = -1;
                effect[index].Multiplier = 1f;
                effect[index].Schedule = Enums.eSchedule.A;
                effect[index].FX = (IEffect)frmPowerEffect.myFX.Clone();
                effect[index].FX.isEnahncementEffect = true;
                this.ListSelectedEffects();
                this.lstSelected.SelectedIndex = this.lstSelected.Items.Count - 1;
            }
        }
        void btnAutoFill_Click(object sender, EventArgs e)
        {
            Enums.eEnhance id = Enums.eEnhance.None;
            Enums.eEnhanceShort eEnhanceShort = Enums.eEnhanceShort.None;
            Enums.eMez eMez = Enums.eMez.None;
            Enums.eMezShort eMezShort = Enums.eMezShort.None;
            string[] names = Enum.GetNames(id.GetType());
            string[] names2 = Enum.GetNames(eEnhanceShort.GetType());
            string[] names3 = Enum.GetNames(eMez.GetType());
            string[] names4 = Enum.GetNames(eMezShort.GetType());
            this.myEnh.Name = "";
            this.myEnh.ShortName = "";
            names[4] = "Endurance";
            names[18] = "Resistance";
            names[5] = "EndMod";
            names2[18] = "ResDam";
            names3[2] = "Hold";
            names4[2] = "Hold";
            if (this.myEnh.TypeID == Enums.eType.SetO & this.myEnh.nIDSet > -1 & this.myEnh.nIDSet < DatabaseAPI.Database.EnhancementSets.Count - 1)
            {
                this.myEnh.UID = DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].DisplayName.Replace(" ", "_") + "_";
            }
            int num = 0;
            int num2 = this.myEnh.Effect.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (this.myEnh.Effect[index].Mode == Enums.eEffMode.Enhancement)
                {
                    num++;
                    id = (Enums.eEnhance)this.myEnh.Effect[index].Enhance.ID;
                    if (id != Enums.eEnhance.Mez)
                    {
                        IEnhancement enhancement;
                        if (this.myEnh.Name != "")
                        {
                            enhancement = this.myEnh;
                            IEnhancement enhancement2 = enhancement;
                            enhancement2.Name += "/";
                        }
                        enhancement = this.myEnh;
                        IEnhancement enhancement3 = enhancement;
                        enhancement3.Name += names[(int)id];
                        if (this.myEnh.ShortName != "")
                        {
                            enhancement = this.myEnh;
                            IEnhancement enhancement4 = enhancement;
                            enhancement4.ShortName += "/";
                        }
                        enhancement = this.myEnh;
                        IEnhancement enhancement5 = enhancement;
                        enhancement5.ShortName += names2[(int)id];
                    }
                    else
                    {
                        IEnhancement enhancement;
                        if (this.myEnh.Name != "")
                        {
                            enhancement = this.myEnh;
                            IEnhancement enhancement6 = enhancement;
                            enhancement6.Name += "/";
                        }
                        enhancement = this.myEnh;
                        IEnhancement enhancement7 = enhancement;
                        enhancement7.Name += names3[this.myEnh.Effect[index].Enhance.SubID];
                        if (this.myEnh.ShortName != "")
                        {
                            enhancement = this.myEnh;
                            IEnhancement enhancement8 = enhancement;
                            enhancement8.ShortName += "/";
                        }
                        enhancement = this.myEnh;
                        IEnhancement enhancement9 = enhancement;
                        enhancement9.ShortName += names4[this.myEnh.Effect[index].Enhance.SubID];
                    }
                }
            }
            float num3 = 1f;
            switch (num)
            {
                case 2:
                    num3 = 0.625f;
                    break;
                case 3:
                    num3 = 0.5f;
                    break;
                case 4:
                    num3 = 0.4375f;
                    break;
            }
            int num4 = this.myEnh.Effect.Length - 1;
            for (int index = 0; index <= num4; index++)
            {
                if (this.myEnh.Effect[index].Mode == Enums.eEffMode.Enhancement)
                {
                    this.myEnh.Effect[index].Multiplier = num3;
                }
            }
            this.DisplayAll();
        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }
        void btnDown_Click(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedIndices.Count > 0)
            {
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
        }
        void btnEdit_Click(object sender, EventArgs e)
        {
            this.EditClick();
        }
        void btnEditPowerData_Click(object sender, EventArgs e)
        {
            IEnhancement enh = this.myEnh;
            IPower power = enh.Power;
            enh.Power = power;
            frmEditPower frmEditPower = new frmEditPower(ref power);
            if (frmEditPower.ShowDialog() == DialogResult.OK)
            {
                this.myEnh.Power = new Power(frmEditPower.myPower);
                this.myEnh.Power.IsModified = true;
                int num = this.myEnh.Power.Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.myEnh.Power.Effects[index].PowerFullName = this.myEnh.Power.FullName;
                }
            }
        }
        void btnImage_Click(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.ImagePicker.InitialDirectory = I9Gfx.GetEnhancementsPath();
                this.ImagePicker.FileName = this.myEnh.Image;
                if (this.ImagePicker.ShowDialog() == DialogResult.OK)
                {
                    string str = FileIO.StripPath(this.ImagePicker.FileName);
                    if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
                    {
                        Interaction.MsgBox("You must select an image from the " + I9Gfx.GetEnhancementsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it.", MsgBoxStyle.Information, "Ah...");
                    }
                    else
                    {
                        this.myEnh.Image = str;
                        this.DisplayIcon();
                        this.SetTypeIcons();
                    }
                }
            }
        }
        void btnNoImage_Click(object sender, EventArgs e)
        {
            this.myEnh.Image = "";
            this.SetTypeIcons();
            this.DisplayIcon();
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Hide();
        }
        void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedIndex > -1)
            {
                Enums.sEffect[] sEffectArray = new Enums.sEffect[this.myEnh.Effect.Length - 1 + 1];
                int selectedIndex = this.lstSelected.SelectedIndex;
                int index = 0;
                int num = this.myEnh.Effect.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        sEffectArray[index].Assign(this.myEnh.Effect[index2]);
                        index++;
                    }
                }
                this.myEnh.Effect = new Enums.sEffect[this.myEnh.Effect.Length - 2 + 1];
                int num2 = this.myEnh.Effect.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    this.myEnh.Effect[index2].Assign(sEffectArray[index2]);
                }
                this.FillEffectList();
                this.ListSelectedEffects();
                if (this.lstSelected.Items.Count > selectedIndex)
                {
                    this.lstSelected.SelectedIndex = selectedIndex;
                }
                else if (this.lstSelected.Items.Count == selectedIndex)
                {
                    this.lstSelected.SelectedIndex = selectedIndex - 1;
                }
            }
        }
        void btnUp_Click(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedIndices.Count > 0)
            {
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
        }
        void cbMutEx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.MutExID = (Enums.eEnhMutex)this.cbMutEx.SelectedIndex;
            }
        }
        void cbRecipe_SelectedIndexChanged(object sender, EventArgs e)
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
        void cbSched_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedIndex > -1)
            {
                int selectedIndex = this.lstSelected.SelectedIndex;
                if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
                {
                    this.myEnh.Effect[selectedIndex].Schedule = (Enums.eSchedule)this.cbSched.SelectedIndex;
                }
            }
        }
        void cbSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.nIDSet = this.cbSet.SelectedIndex - 1;
                if (this.myEnh.nIDSet > -1)
                {
                    this.myEnh.UIDSet = DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Uid;
                }
                else
                {
                    this.myEnh.UIDSet = string.Empty;
                }
                this.UpdateTitle();
                this.DisplaySetImage();
            }
        }
        void cbSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.myEnh.SubTypeID = (Enums.eSubtype)this.cbSubType.SelectedIndex;
        }
        void chkSuperior_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.Superior = this.chkSuperior.Checked;
                if (this.chkSuperior.Checked)
                {
                    this.myEnh.LevelMin = 49;
                    this.myEnh.LevelMax = 49;
                    this.udMinLevel.Value = 50m;
                    this.udMaxLevel.Value = 50m;
                }
                this.chkUnique.Checked = true;
            }
        }
        void chkUnique_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.Unique = this.chkUnique.Checked;
            }
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
            this.cbMutEx.SelectedIndex = (int)this.myEnh.MutExID;
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
                    this.cbSubType.SelectedIndex = (int)this.myEnh.SubTypeID;
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
                    {
                        this.btnEdit.Enabled = true;
                    }
                    else
                    {
                        this.btnEdit.Enabled = false;
                    }
                    this.gbMod.Enabled = true;
                    this.cbSched.Enabled = true;
                    string text = this.myEnh.Effect[selectedIndex].Multiplier.ToString();
                    string text2 = text;
                    if (text2 != null)
                    {
                        if (text2 == "1")
                        {
                            this.rbMod1.Checked = true;
                            this.txtModOther.Text = "";
                            this.txtModOther.Enabled = false;
                            goto IL_246;
                        }
                        if (text2 == "0.625")
                        {
                            this.rbMod2.Checked = true;
                            this.txtModOther.Text = "";
                            this.txtModOther.Enabled = false;
                            goto IL_246;
                        }
                        if (text2 == "0.5")
                        {
                            this.rbMod3.Checked = true;
                            this.txtModOther.Text = "";
                            this.txtModOther.Enabled = false;
                            goto IL_246;
                        }
                    }
                    this.txtModOther.Text = Conversions.ToString(this.myEnh.Effect[selectedIndex].Multiplier);
                    this.rbModOther.Checked = true;
                    this.txtModOther.Enabled = true;
                IL_246:
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
                    this.cbSched.SelectedIndex = (int)this.myEnh.Effect[selectedIndex].Schedule;
                }
            }
        }
        public void DisplayIcon()
        {
            if (this.myEnh.Image != string.Empty)
            {
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.myEnh.Image);
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                extendedBitmap2.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(this.myEnh.TypeID)), GraphicsUnit.Pixel);
                extendedBitmap2.Graphics.DrawImage(extendedBitmap.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, GraphicsUnit.Pixel);
                this.btnImage.Image = new Bitmap(extendedBitmap2.Bitmap);
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
            this.gbSet.Enabled = (this.myEnh.TypeID == Enums.eType.SetO);
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
                    ExtendedBitmap extendedBitmap = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Image);
                    ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                    extendedBitmap2.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), GraphicsUnit.Pixel);
                    extendedBitmap2.Graphics.DrawImage(extendedBitmap.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, GraphicsUnit.Pixel);
                    this.pbSet.Image = new Bitmap(extendedBitmap2.Bitmap);
                }
                else
                {
                    ExtendedBitmap extendedBitmap3 = new ExtendedBitmap(30, 30);
                    extendedBitmap3.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap3.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), GraphicsUnit.Pixel);
                    this.pbSet.Image = new Bitmap(extendedBitmap3.Bitmap);
                }
            }
            else
            {
                this.pbSet.Image = new Bitmap(this.pbSet.Width, this.pbSet.Height);
            }
        }
        public void DrawClasses()
        {
            this.bxClass = new ExtendedBitmap(this.pnlClass.Width, this.pnlClass.Height);
            int enhPadding = this.EnhPadding;
            int enhPadding2 = this.EnhPadding;
            int num = 0;
            this.bxClass.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxClass.ClipRect);
            int num2 = this.myEnh.ClassID.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding, this.ClassSize, this.ClassSize);
                this.bxClass.Graphics.DrawImage(I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(this.myEnh.ClassID[index]), GraphicsUnit.Pixel);
                enhPadding2 += this.ClassSize + this.EnhPadding;
                num++;
                if (num == 2)
                {
                    num = 0;
                    enhPadding2 = this.EnhPadding;
                    enhPadding += this.ClassSize + this.EnhPadding;
                }
            }
            this.pnlClass.CreateGraphics().DrawImageUnscaled(this.bxClass.Bitmap, 0, 0);
        }
        public void DrawClassList()
        {
            this.bxClassList = new ExtendedBitmap(this.pnlClassList.Width, this.pnlClassList.Height);
            int enhPadding = this.EnhPadding;
            int enhPadding2 = this.EnhPadding;
            int num = 0;
            this.bxClassList.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxClassList.ClipRect);
            int num2 = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding, 30, 30);
                this.bxClassList.Graphics.DrawImage(I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(index), GraphicsUnit.Pixel);
                enhPadding2 += 30 + this.EnhPadding;
                num++;
                if (num == this.EnhAcross)
                {
                    num = 0;
                    enhPadding2 = this.EnhPadding;
                    enhPadding += 30 + this.EnhPadding;
                }
            }
            this.pnlClassList.CreateGraphics().DrawImageUnscaled(this.bxClassList.Bitmap, 0, 0);
        }
        public void EditClick()
        {
            bool flag = true;
            int num = -1;
            if (this.lstSelected.SelectedIndex > -1)
            {
                int selectedIndex = this.lstSelected.SelectedIndex;
                if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
                {
                    if (this.myEnh.Effect[selectedIndex].Enhance.ID == 12)
                    {
                        int subId = this.myEnh.Effect[selectedIndex].Enhance.SubID;
                        num = this.MezPicker(subId);
                        if (num == subId)
                        {
                            return;
                        }
                        int num2 = this.myEnh.Effect.Length - 1;
                        for (int index = 0; index <= num2; index++)
                        {
                            Enums.sEffect[] effect = this.myEnh.Effect;
                            int index2 = index;
                            if (effect[index2].Mode == Enums.eEffMode.Enhancement & effect[index2].Enhance.SubID == num)
                            {
                                flag = false;
                            }
                        }
                    }
                    if (!flag)
                    {
                        Interaction.MsgBox("This effect has already been added!", MsgBoxStyle.Information, "There can be only one.");
                        return;
                    }
                    this.myEnh.Effect[selectedIndex].Enhance.SubID = num;
                }
                else
                {
                    frmPowerEffect frmPowerEffect = new frmPowerEffect(ref this.myEnh.Effect[selectedIndex].FX);
                    if (frmPowerEffect.ShowDialog() == DialogResult.OK)
                    {
                        Enums.sEffect[] effect2 = this.myEnh.Effect;
                        int index3 = selectedIndex;
                        effect2[index3].Mode = Enums.eEffMode.FX;
                        effect2[index3].Enhance.ID = -1;
                        effect2[index3].Enhance.SubID = -1;
                        effect2[index3].Multiplier = 1f;
                        effect2[index3].Schedule = Enums.eSchedule.A;
                        effect2[index3].FX = (IEffect)frmPowerEffect.myFX.Clone();
                    }
                }
                this.ListSelectedEffects();
                this.lstSelected.SelectedIndex = selectedIndex;
            }
        }
        public void EffectList_Add()
        {
            if (this.lstAvailable.SelectedIndex > -1)
            {
                Enums.eEnhance integer = Enums.eEnhance.None;
                bool flag = true;
                int tSub = -1;
                integer = (Enums.eEnhance)Conversions.ToInteger(Enum.Parse(integer.GetType(), Conversions.ToString(this.lstAvailable.Items[this.lstAvailable.SelectedIndex])));
                if (integer == Enums.eEnhance.Mez)
                {
                    tSub = this.MezPicker(1);
                    int num = this.myEnh.Effect.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        Enums.sEffect[] effect = this.myEnh.Effect;
                        int index2 = index;
                        if (effect[index2].Mode == Enums.eEffMode.Enhancement & effect[index2].Enhance.SubID == tSub)
                        {
                            flag = false;
                        }
                    }
                }
                if (!flag)
                {
                    Interaction.MsgBox("This effect has already been added!", MsgBoxStyle.Information, "There can be only one.");
                }
                else
                {
                    IEnhancement enh = this.myEnh;
                    Enums.sEffect[] sEffectArray = (Enums.sEffect[])Utils.CopyArray(enh.Effect, new Enums.sEffect[this.myEnh.Effect.Length + 1]);
                    enh.Effect = sEffectArray;
                    Enums.sEffect[] effect2 = this.myEnh.Effect;
                    int index3 = this.myEnh.Effect.Length - 1;
                    effect2[index3].Mode = Enums.eEffMode.Enhancement;
                    effect2[index3].Enhance.ID = (int)integer;
                    effect2[index3].Enhance.SubID = tSub;
                    effect2[index3].Multiplier = 1f;
                    effect2[index3].Schedule = Enhancement.GetSchedule(integer, tSub);
                    this.FillEffectList();
                    this.ListSelectedEffects();
                    this.lstSelected.SelectedIndex = this.lstSelected.Items.Count - 1;
                }
            }
        }
        public void FillEffectList()
        {
            Enums.eEnhance eEnhance2 = Enums.eEnhance.None;
            this.lstAvailable.BeginUpdate();
            this.lstAvailable.Items.Clear();
            string[] names = Enum.GetNames(eEnhance2.GetType());
            int num = names.Length - 1;
            for (int index = 1; index <= num; index++)
            {
                eEnhance2 = (Enums.eEnhance)index;
                bool flag = false;
                int num2 = this.myEnh.Effect.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (this.myEnh.Effect[index2].Mode == Enums.eEffMode.Enhancement && (this.myEnh.Effect[index2].Enhance.ID == index & eEnhance2 != Enums.eEnhance.Mez))
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    this.lstAvailable.Items.Add(names[index]);
                }
            }
            this.btnAdd.Enabled = (this.lstAvailable.Items.Count > 0);
            this.lstAvailable.EndUpdate();
        }
        public void FillMutExList()
        {
            Enums.eEnhMutex eEnhMutex = Enums.eEnhMutex.None;
            string[] names = Enum.GetNames(eEnhMutex.GetType());
            this.cbMutEx.BeginUpdate();
            this.cbMutEx.Items.Clear();
            this.cbMutEx.Items.AddRange(names);
            this.cbMutEx.EndUpdate();
        }
        public void FillRecipeList()
        {
            this.cbRecipe.BeginUpdate();
            this.cbRecipe.Items.Clear();
            this.cbRecipe.Items.Add("None");
            int num = DatabaseAPI.Database.Recipes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbRecipe.Items.Add(DatabaseAPI.Database.Recipes[index].InternalName);
            }
            this.cbRecipe.EndUpdate();
        }
        public void FillSchedules()
        {
            this.cbSched.BeginUpdate();
            this.cbSched.Items.Clear();
            string Style = "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##";
            this.cbSched.Items.Add("A (" + Strings.Format(DatabaseAPI.Database.MultSO[0][0] * 100f, Style) + "%)");
            this.cbSched.Items.Add("B (" + Strings.Format(DatabaseAPI.Database.MultSO[0][1] * 100f, Style) + "%)");
            this.cbSched.Items.Add("C (" + Strings.Format(DatabaseAPI.Database.MultSO[0][2] * 100f, Style) + "%)");
            this.cbSched.Items.Add("D (" + Strings.Format(DatabaseAPI.Database.MultSO[0][3] * 100f, Style) + "%)");
            this.cbSched.EndUpdate();
        }
        public void FillSetList()
        {
            this.cbSet.BeginUpdate();
            this.cbSet.Items.Clear();
            this.cbSet.Items.Add("None");
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbSet.Items.Add(DatabaseAPI.Database.EnhancementSets[index].Uid);
            }
            this.cbSet.EndUpdate();
        }
        public void FillSubTypeList()
        {
            Enums.eSubtype eSubtype = Enums.eSubtype.None;
            string[] names = Enum.GetNames(eSubtype.GetType());
            this.cbSubType.BeginUpdate();
            this.cbSubType.Items.Clear();
            this.cbSubType.Items.AddRange(names);
            this.cbSubType.EndUpdate();
        }
        void frmEnhData_Load(object sender, EventArgs e)
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
        public void ListSelectedEffects()
        {
            Enums.eEnhance eEnhance = Enums.eEnhance.None;
            Enums.eMez eMez = Enums.eMez.None;
            string[] names = Enum.GetNames(eEnhance.GetType());
            string[] names2 = Enum.GetNames(eMez.GetType());
            this.lstSelected.BeginUpdate();
            this.lstSelected.Items.Clear();
            int num = this.myEnh.Effect.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (this.myEnh.Effect[index].Mode == Enums.eEffMode.Enhancement)
                {
                    string str = names[this.myEnh.Effect[index].Enhance.ID];
                    if (this.myEnh.Effect[index].Enhance.SubID > -1)
                    {
                        str = str + ":" + names2[this.myEnh.Effect[index].Enhance.SubID];
                    }
                    this.lstSelected.Items.Add(str);
                }
                else
                {
                    string str = "Special: ";
                    str += this.myEnh.Effect[index].FX.BuildEffectString(false, "", false, false, false);
                    this.lstSelected.Items.Add(str);
                }
            }
            this.lstSelected.EndUpdate();
        }
        void lstAvailable_DoubleClick(object sender, EventArgs e)
        {
            this.EffectList_Add();
        }
        void lstSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DisplayEnhanceData();
            this.tTip.SetToolTip(this.lstSelected, Conversions.ToString(this.lstSelected.SelectedItem));
        }
        public int MezPicker(int Index = 1)
        {
            Enums.eMez eMez = Enums.eMez.None;
            frmEnhMiniPick frmEnhMiniPick = new frmEnhMiniPick();
            string[] names = Enum.GetNames(eMez.GetType());
            int num = names.Length - 1;
            for (int index = 1; index <= num; index++)
            {
                frmEnhMiniPick.lbList.Items.Add(names[index]);
            }
            if (Index > -1 & Index < frmEnhMiniPick.lbList.Items.Count)
            {
                frmEnhMiniPick.lbList.SelectedIndex = Index - 1;
            }
            else
            {
                frmEnhMiniPick.lbList.SelectedIndex = 0;
            }
            frmEnhMiniPick.ShowDialog();
            return frmEnhMiniPick.lbList.SelectedIndex + 1;
        }
        void PickerExpand()
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
        void pnlClass_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.PickerExpand();
            }
            else if (this.gbClass.Width > 84 && !this.Loading)
            {
                int num = -1;
                int num2 = -1;
                int index2 = 0;
                do
                {
                    if (e.X > (this.EnhPadding + this.ClassSize) * index2 & e.X < (this.EnhPadding + this.ClassSize) * (index2 + 1))
                    {
                        num = index2;
                    }
                    index2++;
                }
                while (index2 <= 1);
                index2 = 0;
                do
                {
                    if (e.Y > (this.EnhPadding + this.ClassSize) * index2 & e.Y < (this.EnhPadding + this.ClassSize) * (index2 + 1))
                    {
                        num2 = index2;
                    }
                    index2++;
                }
                while (index2 <= 10);
                int num3 = num + num2 * 2;
                if (num3 < this.myEnh.ClassID.Length & num > -1 & num2 > -1)
                {
                    int[] numArray = new int[this.myEnh.ClassID.Length - 1 + 1];
                    int num4 = this.myEnh.ClassID.Length - 1;
                    for (index2 = 0; index2 <= num4; index2++)
                    {
                        numArray[index2] = this.myEnh.ClassID[index2];
                    }
                    int index3 = 0;
                    this.myEnh.ClassID = new int[this.myEnh.ClassID.Length - 2 + 1];
                    int num5 = numArray.Length - 1;
                    for (index2 = 0; index2 <= num5; index2++)
                    {
                        if (index2 != num3)
                        {
                            this.myEnh.ClassID[index3] = numArray[index2];
                            index3++;
                        }
                    }
                    Array.Sort<int>(this.myEnh.ClassID);
                    this.DrawClasses();
                }
            }
        }
        void pnlClass_MouseMove(object sender, MouseEventArgs e)
        {
            int num = -1;
            int num2 = -1;
            int num3 = 0;
            do
            {
                if (e.X > (this.EnhPadding + this.ClassSize) * num3 & e.X < (this.EnhPadding + this.ClassSize) * (num3 + 1))
                {
                    num = num3;
                }
                num3++;
            }
            while (num3 <= 1);
            num3 = 0;
            do
            {
                if (e.Y > (this.EnhPadding + this.ClassSize) * num3 & e.Y < (this.EnhPadding + this.ClassSize) * (num3 + 1))
                {
                    num2 = num3;
                }
                num3++;
            }
            while (num3 <= 10);
            int index = num + num2 * 2;
            if (index < this.myEnh.ClassID.Length & num > -1 & num2 > -1)
            {
                if (this.gbClass.Width < 100)
                {
                    this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[this.myEnh.ClassID[index]].ShortName;
                }
                else
                {
                    this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[this.myEnh.ClassID[index]].Name;
                }
            }
            else
            {
                this.lblClass.Text = "";
            }
        }
        void pnlClass_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxClass != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxClass.Bitmap, 0, 0);
            }
        }
        void pnlClassList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.PickerExpand();
            }
            else if (this.gbClass.Width > 84 && !this.Loading)
            {
                int num = -1;
                int num2 = -1;
                int num3 = this.EnhAcross - 1;
                int index;
                for (index = 0; index <= num3; index++)
                {
                    if (e.X > (this.EnhPadding + 30) * index & e.X < (this.EnhPadding + 30) * (index + 1))
                    {
                        num = index;
                    }
                }
                index = 0;
                do
                {
                    if (e.Y > (this.EnhPadding + 30) * index & e.Y < (this.EnhPadding + 30) * (index + 1))
                    {
                        num2 = index;
                    }
                    index++;
                }
                while (index <= 10);
                int num4 = num + num2 * this.EnhAcross;
                if (num4 < DatabaseAPI.Database.EnhancementClasses.Length & num > -1 & num2 > -1)
                {
                    bool flag = false;
                    int num5 = this.myEnh.ClassID.Length - 1;
                    for (index = 0; index <= num5; index++)
                    {
                        if (this.myEnh.ClassID[index] == num4)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        IEnhancement enh = this.myEnh;
                        int[] numArray = (int[])Utils.CopyArray(enh.ClassID, new int[this.myEnh.ClassID.Length + 1]);
                        enh.ClassID = numArray;
                        this.myEnh.ClassID[this.myEnh.ClassID.Length - 1] = num4;
                        Array.Sort<int>(this.myEnh.ClassID);
                        this.DrawClasses();
                    }
                }
            }
        }
        void pnlClassList_MouseMove(object sender, MouseEventArgs e)
        {
            int num = -1;
            int num2 = -1;
            int num3 = this.EnhAcross - 1;
            int num4;
            for (num4 = 0; num4 <= num3; num4++)
            {
                if (e.X > (this.EnhPadding + 30) * num4 & e.X < (this.EnhPadding + 30) * (num4 + 1))
                {
                    num = num4;
                }
            }
            num4 = 0;
            do
            {
                if (e.Y > (this.EnhPadding + 30) * num4 & e.Y < (this.EnhPadding + 30) * (num4 + 1))
                {
                    num2 = num4;
                }
                num4++;
            }
            while (num4 <= 10);
            int index = num + num2 * this.EnhAcross;
            if (index < DatabaseAPI.Database.EnhancementClasses.Length & num > -1 & num2 > -1)
            {
                this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[index].Name;
            }
            else
            {
                this.lblClass.Text = string.Empty;
            }
        }
        void pnlClassList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxClassList != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxClassList.Bitmap, 0, 0);
            }
        }
        void rbBuffDebuff_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading && this.lstSelected.SelectedIndex > -1)
            {
                int selectedIndex = this.lstSelected.SelectedIndex;
                if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
                {
                    if (this.rbBuff.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].BuffMode = Enums.eBuffDebuff.BuffOnly;
                    }
                    else if (this.rbDebuff.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].BuffMode = Enums.eBuffDebuff.DeBuffOnly;
                    }
                    else if (this.rbBoth.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].BuffMode = Enums.eBuffDebuff.Any;
                    }
                }
            }
        }
        void rbMod_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedIndex > -1)
            {
                int selectedIndex = this.lstSelected.SelectedIndex;
                if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement)
                {
                    this.txtModOther.Enabled = false;
                    if (this.rbModOther.Checked)
                    {
                        this.txtModOther.Enabled = true;
                        this.myEnh.Effect[selectedIndex].Multiplier = (float)Conversion.Val(this.txtModOther.Text);
                        this.txtModOther.SelectAll();
                        this.txtModOther.Select();
                    }
                    else if (this.rbMod1.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].Multiplier = 1f;
                    }
                    else if (this.rbMod2.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].Multiplier = 0.625f;
                    }
                    else if (this.rbMod3.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].Multiplier = 0.5f;
                    }
                    else if (this.rbMod4.Checked)
                    {
                        this.myEnh.Effect[selectedIndex].Multiplier = 0.4375f;
                    }
                }
            }
        }
        public void SetMaxLevel(int iValue)
        {
            if (decimal.Compare(new decimal(iValue), this.udMaxLevel.Minimum) < 0)
            {
                iValue = Convert.ToInt32(this.udMaxLevel.Minimum);
            }
            if (decimal.Compare(new decimal(iValue), this.udMaxLevel.Maximum) > 0)
            {
                iValue = Convert.ToInt32(this.udMaxLevel.Maximum);
            }
            this.udMaxLevel.Value = new decimal(iValue);
        }
        public void SetMinLevel(int iValue)
        {
            if (decimal.Compare(new decimal(iValue), this.udMinLevel.Minimum) < 0)
            {
                iValue = Convert.ToInt32(this.udMinLevel.Minimum);
            }
            if (decimal.Compare(new decimal(iValue), this.udMinLevel.Maximum) > 0)
            {
                iValue = Convert.ToInt32(this.udMinLevel.Maximum);
            }
            this.udMinLevel.Value = new decimal(iValue);
        }
        public void SetTypeIcons()
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(30, 30);
            ExtendedBitmap extendedBitmap2;
            if (this.myEnh.Image != "")
            {
                extendedBitmap2 = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.myEnh.Image);
            }
            else
            {
                extendedBitmap2 = new ExtendedBitmap(30, 30);
            }
            extendedBitmap.Graphics.Clear(Color.Transparent);
            extendedBitmap.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.Normal)), GraphicsUnit.Pixel);
            extendedBitmap.Graphics.DrawImage(extendedBitmap2.Bitmap, 0, 0);
            this.typeRegular.Image = new Bitmap(extendedBitmap.Bitmap);
            extendedBitmap.Graphics.Clear(Color.Transparent);
            extendedBitmap.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.InventO)), GraphicsUnit.Pixel);
            extendedBitmap.Graphics.DrawImage(extendedBitmap2.Bitmap, 0, 0);
            this.typeIO.Image = new Bitmap(extendedBitmap.Bitmap);
            extendedBitmap.Graphics.Clear(Color.Transparent);
            extendedBitmap.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.SpecialO)), GraphicsUnit.Pixel);
            extendedBitmap.Graphics.DrawImage(extendedBitmap2.Bitmap, 0, 0);
            this.typeHO.Image = new Bitmap(extendedBitmap.Bitmap);
            extendedBitmap.Graphics.Clear(Color.Transparent);
            extendedBitmap.Graphics.DrawImage(I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(Enums.eType.SetO)), GraphicsUnit.Pixel);
            extendedBitmap.Graphics.DrawImage(extendedBitmap2.Bitmap, 0, 0);
            this.typeSet.Image = new Bitmap(extendedBitmap.Bitmap);
        }
        void StaticIndex_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(this.StaticIndex.Text, out var si)){
            this.myEnh.StaticIndex = si;
            }
        }
        void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.Desc = this.txtDesc.Text;
            }
        }
        void txtInternal_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.UID = this.txtInternal.Text;
            }
        }
        void txtModOther_TextChanged(object sender, EventArgs e)
        {
            if (this.lstSelected.SelectedIndex > -1)
            {
                int selectedIndex = this.lstSelected.SelectedIndex;
                if (this.myEnh.Effect[selectedIndex].Mode == Enums.eEffMode.Enhancement && this.rbModOther.Checked)
                {
                    this.myEnh.Effect[selectedIndex].Multiplier = (float)Conversion.Val(this.txtModOther.Text);
                }
            }
        }
        void txtNameFull_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.Name = this.txtNameFull.Text;
                this.UpdateTitle();
            }
        }
        void txtNameShort_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.ShortName = this.txtNameShort.Text;
            }
        }
        void txtProb_Leave(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.txtProb.Text = Conversions.ToString(this.myEnh.EffectChance);
            }
        }
        void txtProb_TextChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                float num = (float)Conversion.Val(this.txtProb.Text);
                if (num > 1f)
                {
                    num = 1f;
                }
                if (num < 0f)
                {
                    num = 0f;
                }
                this.myEnh.EffectChance = num;
            }
        }
        void type_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
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
        }
        void udMaxLevel_Leave(object sender, EventArgs e)
        {
            this.SetMaxLevel((int)Math.Round(Conversion.Val(this.udMaxLevel.Text)));
            this.myEnh.LevelMax = Convert.ToInt32(decimal.Subtract(this.udMaxLevel.Value, 1m));
        }
        void udMaxLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.LevelMax = Convert.ToInt32(decimal.Subtract(this.udMaxLevel.Value, 1m));
                this.udMinLevel.Maximum = this.udMaxLevel.Value;
            }
        }
        void udMinLevel_Leave(object sender, EventArgs e)
        {
            this.SetMinLevel((int)Math.Round(Conversion.Val(this.udMinLevel.Text)));
            this.myEnh.LevelMin = Convert.ToInt32(decimal.Subtract(this.udMinLevel.Value, 1m));
        }
        void udMinLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!this.Loading)
            {
                this.myEnh.LevelMin = Convert.ToInt32(decimal.Subtract(this.udMinLevel.Value, 1m));
                this.udMaxLevel.Minimum = this.udMinLevel.Value;
            }
        }
        public void UpdateTitle()
        {
            string str2 = "Edit ";
            switch (this.myEnh.TypeID)
            {
                case Enums.eType.InventO:
                    str2 += "Invention: ";
                    break;
                case Enums.eType.SpecialO:
                    str2 += "HO: ";
                    break;
                case Enums.eType.SetO:
                    if (this.myEnh.nIDSet <= -1)
                    {
                        str2 += "Set Invention: ";
                    }
                    else
                    {
                        str2 = str2 + DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].DisplayName + ": ";
                    }
                    break;
                default:
                    str2 += "Enhancement: ";
                    break;
            }
            str2 += this.myEnh.Name;
            this.Text = str2;
        }
        [AccessedThroughProperty("btnAdd")]
        Button _btnAdd;
        [AccessedThroughProperty("btnAddFX")]
        Button _btnAddFX;
        [AccessedThroughProperty("btnAutoFill")]
        Button _btnAutoFill;
        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;
        [AccessedThroughProperty("btnDown")]
        Button _btnDown;
        [AccessedThroughProperty("btnEdit")]
        Button _btnEdit;
        [AccessedThroughProperty("btnEditPowerData")]
        Button _btnEditPowerData;
        [AccessedThroughProperty("btnImage")]
        Button _btnImage;
        [AccessedThroughProperty("btnNoImage")]
        Button _btnNoImage;
        [AccessedThroughProperty("btnOK")]
        Button _btnOK;
        [AccessedThroughProperty("btnRemove")]
        Button _btnRemove;
        [AccessedThroughProperty("btnUp")]
        Button _btnUp;
        [AccessedThroughProperty("cbMutEx")]
        ComboBox _cbMutEx;
        [AccessedThroughProperty("cbRecipe")]
        ComboBox _cbRecipe;
        [AccessedThroughProperty("cbSched")]
        ComboBox _cbSched;
        [AccessedThroughProperty("cbSet")]
        ComboBox _cbSet;
        [AccessedThroughProperty("cbSubType")]
        ComboBox _cbSubType;
        [AccessedThroughProperty("chkSuperior")]
        CheckBox _chkSuperior;
        [AccessedThroughProperty("chkUnique")]
        CheckBox _chkUnique;
        [AccessedThroughProperty("gbBasic")]
        GroupBox _gbBasic;
        [AccessedThroughProperty("gbClass")]
        GroupBox _gbClass;
        [AccessedThroughProperty("gbEffects")]
        GroupBox _gbEffects;
        [AccessedThroughProperty("gbMod")]
        GroupBox _gbMod;
        [AccessedThroughProperty("gbSet")]
        GroupBox _gbSet;
        [AccessedThroughProperty("gbType")]
        GroupBox _gbType;
        [AccessedThroughProperty("ImagePicker")]
        OpenFileDialog _ImagePicker;
        [AccessedThroughProperty("Label1")]
        Label _Label1;
        [AccessedThroughProperty("Label10")]
        Label _Label10;
        [AccessedThroughProperty("Label11")]
        Label _Label11;
        [AccessedThroughProperty("Label2")]
        Label _Label2;
        [AccessedThroughProperty("Label3")]
        Label _Label3;
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
        [AccessedThroughProperty("lblClass")]
        Label _lblClass;
        [AccessedThroughProperty("lblSched")]
        Label _lblSched;
        [AccessedThroughProperty("lstAvailable")]
        ListBox _lstAvailable;
        [AccessedThroughProperty("lstSelected")]
        ListBox _lstSelected;
        [AccessedThroughProperty("pbSet")]
        PictureBox _pbSet;
        [AccessedThroughProperty("pnlClass")]
        Panel _pnlClass;
        [AccessedThroughProperty("pnlClassList")]
        Panel _pnlClassList;
        [AccessedThroughProperty("rbBoth")]
        RadioButton _rbBoth;
        [AccessedThroughProperty("rbBuff")]
        RadioButton _rbBuff;
        [AccessedThroughProperty("rbDebuff")]
        RadioButton _rbDebuff;
        [AccessedThroughProperty("rbMod1")]
        RadioButton _rbMod1;
        [AccessedThroughProperty("rbMod2")]
        RadioButton _rbMod2;
        [AccessedThroughProperty("rbMod3")]
        RadioButton _rbMod3;
        [AccessedThroughProperty("rbMod4")]
        RadioButton _rbMod4;
        [AccessedThroughProperty("rbModOther")]
        RadioButton _rbModOther;
        [AccessedThroughProperty("StaticIndex")]
        TextBox _StaticIndex;
        [AccessedThroughProperty("tTip")]
        ToolTip _tTip;
        [AccessedThroughProperty("txtDesc")]
        TextBox _txtDesc;
        [AccessedThroughProperty("txtInternal")]
        TextBox _txtInternal;
        [AccessedThroughProperty("txtModOther")]
        TextBox _txtModOther;
        [AccessedThroughProperty("txtNameFull")]
        TextBox _txtNameFull;
        [AccessedThroughProperty("txtNameShort")]
        TextBox _txtNameShort;
        [AccessedThroughProperty("txtProb")]
        TextBox _txtProb;
        [AccessedThroughProperty("typeHO")]
        RadioButton _typeHO;
        [AccessedThroughProperty("typeIO")]
        RadioButton _typeIO;
        [AccessedThroughProperty("typeRegular")]
        RadioButton _typeRegular;
        [AccessedThroughProperty("typeSet")]
        RadioButton _typeSet;
        [AccessedThroughProperty("udMaxLevel")]
        NumericUpDown _udMaxLevel;
        [AccessedThroughProperty("udMinLevel")]
        NumericUpDown _udMinLevel;
        protected ExtendedBitmap bxClass;
        protected ExtendedBitmap bxClassList;
        protected int ClassSize;
        protected int EnhAcross;
        protected int EnhPadding;
        protected bool Loading;
        public IEnhancement myEnh;
    }
}
