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
using Base.Master_Classes;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmEditPower : Form
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


    
    
        internal virtual Button btnCSVImport
        {
            get
            {
                return this._btnCSVImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCSVImport_Click);
                if (this._btnCSVImport != null)
                {
                    this._btnCSVImport.Click -= eventHandler;
                }
                this._btnCSVImport = value;
                if (this._btnCSVImport != null)
                {
                    this._btnCSVImport.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFullCopy
        {
            get
            {
                return this._btnFullCopy;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFullCopy_Click);
                if (this._btnFullCopy != null)
                {
                    this._btnFullCopy.Click -= eventHandler;
                }
                this._btnFullCopy = value;
                if (this._btnFullCopy != null)
                {
                    this._btnFullCopy.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFullPaste
        {
            get
            {
                return this._btnFullPaste;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFullPaste_Click);
                if (this._btnFullPaste != null)
                {
                    this._btnFullPaste.Click -= eventHandler;
                }
                this._btnFullPaste = value;
                if (this._btnFullPaste != null)
                {
                    this._btnFullPaste.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFXAdd
        {
            get
            {
                return this._btnFXAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFXAdd_Click);
                if (this._btnFXAdd != null)
                {
                    this._btnFXAdd.Click -= eventHandler;
                }
                this._btnFXAdd = value;
                if (this._btnFXAdd != null)
                {
                    this._btnFXAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFXDown
        {
            get
            {
                return this._btnFXDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFXDown_Click);
                if (this._btnFXDown != null)
                {
                    this._btnFXDown.Click -= eventHandler;
                }
                this._btnFXDown = value;
                if (this._btnFXDown != null)
                {
                    this._btnFXDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFXDuplicate
        {
            get
            {
                return this._btnFXDuplicate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFXDuplicate_Click);
                if (this._btnFXDuplicate != null)
                {
                    this._btnFXDuplicate.Click -= eventHandler;
                }
                this._btnFXDuplicate = value;
                if (this._btnFXDuplicate != null)
                {
                    this._btnFXDuplicate.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFXEdit
        {
            get
            {
                return this._btnFXEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFXEdit_Click);
                if (this._btnFXEdit != null)
                {
                    this._btnFXEdit.Click -= eventHandler;
                }
                this._btnFXEdit = value;
                if (this._btnFXEdit != null)
                {
                    this._btnFXEdit.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFXRemove
        {
            get
            {
                return this._btnFXRemove;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFXRemove_Click);
                if (this._btnFXRemove != null)
                {
                    this._btnFXRemove.Click -= eventHandler;
                }
                this._btnFXRemove = value;
                if (this._btnFXRemove != null)
                {
                    this._btnFXRemove.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnFXUp
        {
            get
            {
                return this._btnFXUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFXUp_Click);
                if (this._btnFXUp != null)
                {
                    this._btnFXUp.Click -= eventHandler;
                }
                this._btnFXUp = value;
                if (this._btnFXUp != null)
                {
                    this._btnFXUp.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnMutexAdd
        {
            get
            {
                return this._btnMutexAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnMutexAdd_Click);
                if (this._btnMutexAdd != null)
                {
                    this._btnMutexAdd.Click -= eventHandler;
                }
                this._btnMutexAdd = value;
                if (this._btnMutexAdd != null)
                {
                    this._btnMutexAdd.Click += eventHandler;
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


    
    
        internal virtual Button btnPrDown
        {
            get
            {
                return this._btnPrDown;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPrDown_Click);
                if (this._btnPrDown != null)
                {
                    this._btnPrDown.Click -= eventHandler;
                }
                this._btnPrDown = value;
                if (this._btnPrDown != null)
                {
                    this._btnPrDown.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPrReset
        {
            get
            {
                return this._btnPrReset;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPrReset_Click);
                if (this._btnPrReset != null)
                {
                    this._btnPrReset.Click -= eventHandler;
                }
                this._btnPrReset = value;
                if (this._btnPrReset != null)
                {
                    this._btnPrReset.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPrSetNone
        {
            get
            {
                return this._btnPrSetNone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPrSetNone_Click);
                if (this._btnPrSetNone != null)
                {
                    this._btnPrSetNone.Click -= eventHandler;
                }
                this._btnPrSetNone = value;
                if (this._btnPrSetNone != null)
                {
                    this._btnPrSetNone.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnPrUp
        {
            get
            {
                return this._btnPrUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnPrUp_Click);
                if (this._btnPrUp != null)
                {
                    this._btnPrUp.Click -= eventHandler;
                }
                this._btnPrUp = value;
                if (this._btnPrUp != null)
                {
                    this._btnPrUp.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSetDamage
        {
            get
            {
                return this._btnSetDamage;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._btnSetDamage = value;
            }
        }


    
    
        internal virtual Button btnSPAdd
        {
            get
            {
                return this._btnSPAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSPAdd_Click);
                if (this._btnSPAdd != null)
                {
                    this._btnSPAdd.Click -= eventHandler;
                }
                this._btnSPAdd = value;
                if (this._btnSPAdd != null)
                {
                    this._btnSPAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSPRemove
        {
            get
            {
                return this._btnSPRemove;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSPRemove_Click);
                if (this._btnSPRemove != null)
                {
                    this._btnSPRemove.Click -= eventHandler;
                }
                this._btnSPRemove = value;
                if (this._btnSPRemove != null)
                {
                    this._btnSPRemove.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbEffectArea
        {
            get
            {
                return this._cbEffectArea;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbEffectArea_SelectedIndexChanged);
                if (this._cbEffectArea != null)
                {
                    this._cbEffectArea.SelectedIndexChanged -= eventHandler;
                }
                this._cbEffectArea = value;
                if (this._cbEffectArea != null)
                {
                    this._cbEffectArea.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbForcedClass
        {
            get
            {
                return this._cbForcedClass;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbForcedClass_SelectedIndexChanged);
                if (this._cbForcedClass != null)
                {
                    this._cbForcedClass.SelectedIndexChanged -= eventHandler;
                }
                this._cbForcedClass = value;
                if (this._cbForcedClass != null)
                {
                    this._cbForcedClass.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbNameGroup
        {
            get
            {
                return this._cbNameGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbNameGroup_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.cbNameGroup_SelectedIndexChanged);
                EventHandler eventHandler3 = new EventHandler(this.cbNameGroup_Leave);
                if (this._cbNameGroup != null)
                {
                    this._cbNameGroup.TextChanged -= eventHandler;
                    this._cbNameGroup.SelectedIndexChanged -= eventHandler2;
                    this._cbNameGroup.Leave -= eventHandler3;
                }
                this._cbNameGroup = value;
                if (this._cbNameGroup != null)
                {
                    this._cbNameGroup.TextChanged += eventHandler;
                    this._cbNameGroup.SelectedIndexChanged += eventHandler2;
                    this._cbNameGroup.Leave += eventHandler3;
                }
            }
        }


    
    
        internal virtual ComboBox cbNameSet
        {
            get
            {
                return this._cbNameSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbNameSet_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.cbNameSet_SelectedIndexChanged);
                EventHandler eventHandler3 = new EventHandler(this.cbNameSet_Leave);
                if (this._cbNameSet != null)
                {
                    this._cbNameSet.TextChanged -= eventHandler;
                    this._cbNameSet.SelectedIndexChanged -= eventHandler2;
                    this._cbNameSet.Leave -= eventHandler3;
                }
                this._cbNameSet = value;
                if (this._cbNameSet != null)
                {
                    this._cbNameSet.TextChanged += eventHandler;
                    this._cbNameSet.SelectedIndexChanged += eventHandler2;
                    this._cbNameSet.Leave += eventHandler3;
                }
            }
        }


    
    
        internal virtual ComboBox cbNotify
        {
            get
            {
                return this._cbNotify;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbNotify_SelectedIndexChanged);
                if (this._cbNotify != null)
                {
                    this._cbNotify.SelectedIndexChanged -= eventHandler;
                }
                this._cbNotify = value;
                if (this._cbNotify != null)
                {
                    this._cbNotify.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ComboBox cbPowerType
        {
            get
            {
                return this._cbPowerType;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.cbPowerType_SelectedIndexChanged);
                if (this._cbPowerType != null)
                {
                    this._cbPowerType.SelectedIndexChanged -= eventHandler;
                }
                this._cbPowerType = value;
                if (this._cbPowerType != null)
                {
                    this._cbPowerType.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkAltSub
        {
            get
            {
                return this._chkAltSub;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkAltSub_CheckedChanged);
                if (this._chkAltSub != null)
                {
                    this._chkAltSub.CheckedChanged -= eventHandler;
                }
                this._chkAltSub = value;
                if (this._chkAltSub != null)
                {
                    this._chkAltSub.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkAlwaysToggle
        {
            get
            {
                return this._chkAlwaysToggle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkAlwaysToggle_CheckedChanged);
                if (this._chkAlwaysToggle != null)
                {
                    this._chkAlwaysToggle.CheckedChanged -= eventHandler;
                }
                this._chkAlwaysToggle = value;
                if (this._chkAlwaysToggle != null)
                {
                    this._chkAlwaysToggle.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkBoostBoostable
        {
            get
            {
                return this._chkBoostBoostable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkBoostBoostable_CheckedChanged);
                if (this._chkBoostBoostable != null)
                {
                    this._chkBoostBoostable.CheckedChanged -= eventHandler;
                }
                this._chkBoostBoostable = value;
                if (this._chkBoostBoostable != null)
                {
                    this._chkBoostBoostable.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkBoostUsePlayerLevel
        {
            get
            {
                return this._chkBoostUsePlayerLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkBoostUsePlayerLevel_CheckedChanged);
                if (this._chkBoostUsePlayerLevel != null)
                {
                    this._chkBoostUsePlayerLevel.CheckedChanged -= eventHandler;
                }
                this._chkBoostUsePlayerLevel = value;
                if (this._chkBoostUsePlayerLevel != null)
                {
                    this._chkBoostUsePlayerLevel.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkBuffCycle
        {
            get
            {
                return this._chkBuffCycle;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkBuffCycle_CheckedChanged);
                if (this._chkBuffCycle != null)
                {
                    this._chkBuffCycle.CheckedChanged -= eventHandler;
                }
                this._chkBuffCycle = value;
                if (this._chkBuffCycle != null)
                {
                    this._chkBuffCycle.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkGraphFix
        {
            get
            {
                return this._chkGraphFix;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkGraphFix_CheckedChanged);
                if (this._chkGraphFix != null)
                {
                    this._chkGraphFix.CheckedChanged -= eventHandler;
                }
                this._chkGraphFix = value;
                if (this._chkGraphFix != null)
                {
                    this._chkGraphFix.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkHidden
        {
            get
            {
                return this._chkHidden;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkHidden_CheckedChanged);
                if (this._chkHidden != null)
                {
                    this._chkHidden.CheckedChanged -= eventHandler;
                }
                this._chkHidden = value;
                if (this._chkHidden != null)
                {
                    this._chkHidden.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkIgnoreStrength
        {
            get
            {
                return this._chkIgnoreStrength;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkIgnoreStrength_CheckedChanged);
                if (this._chkIgnoreStrength != null)
                {
                    this._chkIgnoreStrength.CheckedChanged -= eventHandler;
                }
                this._chkIgnoreStrength = value;
                if (this._chkIgnoreStrength != null)
                {
                    this._chkIgnoreStrength.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkLos
        {
            get
            {
                return this._chkLos;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkLos_CheckedChanged);
                if (this._chkLos != null)
                {
                    this._chkLos.CheckedChanged -= eventHandler;
                }
                this._chkLos = value;
                if (this._chkLos != null)
                {
                    this._chkLos.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkMutexAuto
        {
            get
            {
                return this._chkMutexAuto;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkMutexAuto_CheckedChanged);
                if (this._chkMutexAuto != null)
                {
                    this._chkMutexAuto.CheckedChanged -= eventHandler;
                }
                this._chkMutexAuto = value;
                if (this._chkMutexAuto != null)
                {
                    this._chkMutexAuto.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkMutexSkip
        {
            get
            {
                return this._chkMutexSkip;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkMutexSkip_CheckedChanged);
                if (this._chkMutexSkip != null)
                {
                    this._chkMutexSkip.CheckedChanged -= eventHandler;
                }
                this._chkMutexSkip = value;
                if (this._chkMutexSkip != null)
                {
                    this._chkMutexSkip.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkNoAUReq
        {
            get
            {
                return this._chkNoAUReq;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkNoAUReq_CheckedChanged);
                if (this._chkNoAUReq != null)
                {
                    this._chkNoAUReq.CheckedChanged -= eventHandler;
                }
                this._chkNoAUReq = value;
                if (this._chkNoAUReq != null)
                {
                    this._chkNoAUReq.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkNoAutoUpdate
        {
            get
            {
                return this._chkNoAutoUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkNoAutoUpdate_CheckedChanged);
                if (this._chkNoAutoUpdate != null)
                {
                    this._chkNoAutoUpdate.CheckedChanged -= eventHandler;
                }
                this._chkNoAutoUpdate = value;
                if (this._chkNoAutoUpdate != null)
                {
                    this._chkNoAutoUpdate.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkPRFrontLoad
        {
            get
            {
                return this._chkPRFrontLoad;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkPRFrontLoad_CheckedChanged);
                if (this._chkPRFrontLoad != null)
                {
                    this._chkPRFrontLoad.CheckedChanged -= eventHandler;
                }
                this._chkPRFrontLoad = value;
                if (this._chkPRFrontLoad != null)
                {
                    this._chkPRFrontLoad.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkScale
        {
            get
            {
                return this._chkScale;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkScale_CheckedChanged);
                if (this._chkScale != null)
                {
                    this._chkScale.CheckedChanged -= eventHandler;
                }
                this._chkScale = value;
                if (this._chkScale != null)
                {
                    this._chkScale.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkSortOverride
        {
            get
            {
                return this._chkSortOverride;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSortOverride_CheckedChanged);
                if (this._chkSortOverride != null)
                {
                    this._chkSortOverride.CheckedChanged -= eventHandler;
                }
                this._chkSortOverride = value;
                if (this._chkSortOverride != null)
                {
                    this._chkSortOverride.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkSubInclude
        {
            get
            {
                return this._chkSubInclude;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSubInclude_CheckedChanged);
                if (this._chkSubInclude != null)
                {
                    this._chkSubInclude.CheckedChanged -= eventHandler;
                }
                this._chkSubInclude = value;
                if (this._chkSubInclude != null)
                {
                    this._chkSubInclude.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkSummonDisplayEntity
        {
            get
            {
                return this._chkSummonDisplayEntity;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSummonDisplayEntity_CheckedChanged);
                if (this._chkSummonDisplayEntity != null)
                {
                    this._chkSummonDisplayEntity.CheckedChanged -= eventHandler;
                }
                this._chkSummonDisplayEntity = value;
                if (this._chkSummonDisplayEntity != null)
                {
                    this._chkSummonDisplayEntity.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkSummonStealAttributes
        {
            get
            {
                return this._chkSummonStealAttributes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSummonStealAttributes_CheckedChanged);
                if (this._chkSummonStealAttributes != null)
                {
                    this._chkSummonStealAttributes.CheckedChanged -= eventHandler;
                }
                this._chkSummonStealAttributes = value;
                if (this._chkSummonStealAttributes != null)
                {
                    this._chkSummonStealAttributes.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckBox chkSummonStealEffects
        {
            get
            {
                return this._chkSummonStealEffects;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.chkSummonStealEffects_CheckedChanged);
                if (this._chkSummonStealEffects != null)
                {
                    this._chkSummonStealEffects.CheckedChanged -= eventHandler;
                }
                this._chkSummonStealEffects = value;
                if (this._chkSummonStealEffects != null)
                {
                    this._chkSummonStealEffects.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual CheckedListBox clbClassExclude
        {
            get
            {
                return this._clbClassExclude;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._clbClassExclude = value;
            }
        }


    
    
        internal virtual CheckedListBox clbClassReq
        {
            get
            {
                return this._clbClassReq;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._clbClassReq = value;
            }
        }


    
    
        internal virtual CheckedListBox clbFlags
        {
            get
            {
                return this._clbFlags;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ItemCheckEventHandler checkEventHandler = new ItemCheckEventHandler(this.clbFlags_ItemCheck);
                if (this._clbFlags != null)
                {
                    this._clbFlags.ItemCheck -= checkEventHandler;
                }
                this._clbFlags = value;
                if (this._clbFlags != null)
                {
                    this._clbFlags.ItemCheck += checkEventHandler;
                }
            }
        }


    
    
        internal virtual CheckedListBox clbMutex
        {
            get
            {
                return this._clbMutex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._clbMutex = value;
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


    
    
        internal virtual ColumnHeader ColumnHeader10
        {
            get
            {
                return this._ColumnHeader10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader10 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader11
        {
            get
            {
                return this._ColumnHeader11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader11 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader2
        {
            get
            {
                return this._ColumnHeader2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader2 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader3
        {
            get
            {
                return this._ColumnHeader3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader3 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader4
        {
            get
            {
                return this._ColumnHeader4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader4 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader6
        {
            get
            {
                return this._ColumnHeader6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader6 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader7
        {
            get
            {
                return this._ColumnHeader7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader7 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader8
        {
            get
            {
                return this._ColumnHeader8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader8 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader9
        {
            get
            {
                return this._ColumnHeader9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader9 = value;
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


    
    
        internal virtual Label Label17
        {
            get
            {
                return this._Label17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label17 = value;
            }
        }


    
    
        internal virtual Label Label18
        {
            get
            {
                return this._Label18;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label18 = value;
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


    
    
        internal virtual Label Label35
        {
            get
            {
                return this._Label35;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label35 = value;
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


    
    
        internal virtual Label Label39
        {
            get
            {
                return this._Label39;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label39 = value;
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


    
    
        internal virtual Label Label41
        {
            get
            {
                return this._Label41;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label41 = value;
            }
        }


    
    
        internal virtual Label Label42
        {
            get
            {
                return this._Label42;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label42 = value;
            }
        }


    
    
        internal virtual Label Label43
        {
            get
            {
                return this._Label43;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label43 = value;
            }
        }


    
    
        internal virtual Label Label44
        {
            get
            {
                return this._Label44;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label44 = value;
            }
        }


    
    
        internal virtual Label Label45
        {
            get
            {
                return this._Label45;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label45 = value;
            }
        }


    
    
        internal virtual Label Label46
        {
            get
            {
                return this._Label46;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label46 = value;
            }
        }


    
    
        internal virtual Label Label47
        {
            get
            {
                return this._Label47;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label47 = value;
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


    
    
        internal virtual Label lblAcc
        {
            get
            {
                return this._lblAcc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAcc = value;
            }
        }


    
    
        internal virtual Label lblEndCost
        {
            get
            {
                return this._lblEndCost;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblEndCost = value;
            }
        }


    
    
        internal virtual Label lblEnhName
        {
            get
            {
                return this._lblEnhName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblEnhName = value;
            }
        }


    
    
        internal virtual Label lblInvSet
        {
            get
            {
                return this._lblInvSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblInvSet = value;
            }
        }


    
    
        internal virtual Label lblNameFull
        {
            get
            {
                return this._lblNameFull;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblNameFull = value;
            }
        }


    
    
        internal virtual Label lblNameUnique
        {
            get
            {
                return this._lblNameUnique;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblNameUnique = value;
            }
        }


    
    
        internal virtual Label lblStaticIndex
        {
            get
            {
                return this._lblStaticIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lblStaticIndex_Click);
                if (this._lblStaticIndex != null)
                {
                    this._lblStaticIndex.Click -= eventHandler;
                }
                this._lblStaticIndex = value;
                if (this._lblStaticIndex != null)
                {
                    this._lblStaticIndex.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual ListBox lvDisablePass1
        {
            get
            {
                return this._lvDisablePass1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvDisablePass1_SelectedIndexChanged);
                if (this._lvDisablePass1 != null)
                {
                    this._lvDisablePass1.SelectedIndexChanged -= eventHandler;
                }
                this._lvDisablePass1 = value;
                if (this._lvDisablePass1 != null)
                {
                    this._lvDisablePass1.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListBox lvDisablePass4
        {
            get
            {
                return this._lvDisablePass4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvDisablePass4_SelectedIndexChanged);
                if (this._lvDisablePass4 != null)
                {
                    this._lvDisablePass4.SelectedIndexChanged -= eventHandler;
                }
                this._lvDisablePass4 = value;
                if (this._lvDisablePass4 != null)
                {
                    this._lvDisablePass4.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListBox lvFX
        {
            get
            {
                return this._lvFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.lvFX_KeyPress);
                EventHandler eventHandler = new EventHandler(this.lvFX_DoubleClick);
                if (this._lvFX != null)
                {
                    this._lvFX.KeyPress -= pressEventHandler;
                    this._lvFX.DoubleClick -= eventHandler;
                }
                this._lvFX = value;
                if (this._lvFX != null)
                {
                    this._lvFX.KeyPress += pressEventHandler;
                    this._lvFX.DoubleClick += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvPrGroup
        {
            get
            {
                return this._lvPrGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPrGroup_SelectedIndexChanged);
                if (this._lvPrGroup != null)
                {
                    this._lvPrGroup.SelectedIndexChanged -= eventHandler;
                }
                this._lvPrGroup = value;
                if (this._lvPrGroup != null)
                {
                    this._lvPrGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvPrListing
        {
            get
            {
                return this._lvPrListing;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPrListing_SelectedIndexChanged);
                if (this._lvPrListing != null)
                {
                    this._lvPrListing.SelectedIndexChanged -= eventHandler;
                }
                this._lvPrListing = value;
                if (this._lvPrListing != null)
                {
                    this._lvPrListing.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvPrPower
        {
            get
            {
                return this._lvPrPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPrPower_SelectedIndexChanged);
                if (this._lvPrPower != null)
                {
                    this._lvPrPower.SelectedIndexChanged -= eventHandler;
                }
                this._lvPrPower = value;
                if (this._lvPrPower != null)
                {
                    this._lvPrPower.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvPrSet
        {
            get
            {
                return this._lvPrSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvPrSet_SelectedIndexChanged);
                if (this._lvPrSet != null)
                {
                    this._lvPrSet.SelectedIndexChanged -= eventHandler;
                }
                this._lvPrSet = value;
                if (this._lvPrSet != null)
                {
                    this._lvPrSet.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvSPGroup
        {
            get
            {
                return this._lvSPGroup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSPGroup_SelectedIndexChanged);
                if (this._lvSPGroup != null)
                {
                    this._lvSPGroup.SelectedIndexChanged -= eventHandler;
                }
                this._lvSPGroup = value;
                if (this._lvSPGroup != null)
                {
                    this._lvSPGroup.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvSPPower
        {
            get
            {
                return this._lvSPPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSPPower_SelectedIndexChanged);
                if (this._lvSPPower != null)
                {
                    this._lvSPPower.SelectedIndexChanged -= eventHandler;
                }
                this._lvSPPower = value;
                if (this._lvSPPower != null)
                {
                    this._lvSPPower.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvSPSelected
        {
            get
            {
                return this._lvSPSelected;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lvSPSelected = value;
            }
        }


    
    
        internal virtual ListView lvSPSet
        {
            get
            {
                return this._lvSPSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSPSet_SelectedIndexChanged);
                if (this._lvSPSet != null)
                {
                    this._lvSPSet.SelectedIndexChanged -= eventHandler;
                }
                this._lvSPSet = value;
                if (this._lvSPSet != null)
                {
                    this._lvSPSet.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual PictureBox pbEnhancementList
        {
            get
            {
                return this._pbEnhancementList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbEnhancementList_MouseDown);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbEnhancementList_Hover);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pbEnhancementList_Paint);
                if (this._pbEnhancementList != null)
                {
                    this._pbEnhancementList.MouseDown -= mouseEventHandler;
                    this._pbEnhancementList.MouseMove -= mouseEventHandler2;
                    this._pbEnhancementList.Paint -= paintEventHandler;
                }
                this._pbEnhancementList = value;
                if (this._pbEnhancementList != null)
                {
                    this._pbEnhancementList.MouseDown += mouseEventHandler;
                    this._pbEnhancementList.MouseMove += mouseEventHandler2;
                    this._pbEnhancementList.Paint += paintEventHandler;
                }
            }
        }


    
    
        internal virtual PictureBox pbEnhancements
        {
            get
            {
                return this._pbEnhancements;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbEnhancements_MouseDown);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbEnhancements_Hover);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pbEnhancements_Paint);
                if (this._pbEnhancements != null)
                {
                    this._pbEnhancements.MouseDown -= mouseEventHandler;
                    this._pbEnhancements.MouseMove -= mouseEventHandler2;
                    this._pbEnhancements.Paint -= paintEventHandler;
                }
                this._pbEnhancements = value;
                if (this._pbEnhancements != null)
                {
                    this._pbEnhancements.MouseDown += mouseEventHandler;
                    this._pbEnhancements.MouseMove += mouseEventHandler2;
                    this._pbEnhancements.Paint += paintEventHandler;
                }
            }
        }


    
    
        internal virtual PictureBox pbInvSetList
        {
            get
            {
                return this._pbInvSetList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbInvSetList_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbInvSetList_MouseDown);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pbInvSetList_Paint);
                if (this._pbInvSetList != null)
                {
                    this._pbInvSetList.MouseMove -= mouseEventHandler;
                    this._pbInvSetList.MouseDown -= mouseEventHandler2;
                    this._pbInvSetList.Paint -= paintEventHandler;
                }
                this._pbInvSetList = value;
                if (this._pbInvSetList != null)
                {
                    this._pbInvSetList.MouseMove += mouseEventHandler;
                    this._pbInvSetList.MouseDown += mouseEventHandler2;
                    this._pbInvSetList.Paint += paintEventHandler;
                }
            }
        }


    
    
        internal virtual PictureBox pbInvSetUsed
        {
            get
            {
                return this._pbInvSetUsed;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pbInvSetUsed_MouseDown);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pbInvSetUsed_MouseMove);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pbInvSetUsed_Paint);
                if (this._pbInvSetUsed != null)
                {
                    this._pbInvSetUsed.MouseDown -= mouseEventHandler;
                    this._pbInvSetUsed.MouseMove -= mouseEventHandler2;
                    this._pbInvSetUsed.Paint -= paintEventHandler;
                }
                this._pbInvSetUsed = value;
                if (this._pbInvSetUsed != null)
                {
                    this._pbInvSetUsed.MouseDown += mouseEventHandler;
                    this._pbInvSetUsed.MouseMove += mouseEventHandler2;
                    this._pbInvSetUsed.Paint += paintEventHandler;
                }
            }
        }


    
    
        internal virtual Panel pnlFX
        {
            get
            {
                return this._pnlFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pnlFX = value;
            }
        }


    
    
        internal virtual RadioButton rbFlagAffected
        {
            get
            {
                return this._rbFlagAffected;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagAffected != null)
                {
                    this._rbFlagAffected.CheckedChanged -= eventHandler;
                }
                this._rbFlagAffected = value;
                if (this._rbFlagAffected != null)
                {
                    this._rbFlagAffected.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagAutoHit
        {
            get
            {
                return this._rbFlagAutoHit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagAutoHit != null)
                {
                    this._rbFlagAutoHit.CheckedChanged -= eventHandler;
                }
                this._rbFlagAutoHit = value;
                if (this._rbFlagAutoHit != null)
                {
                    this._rbFlagAutoHit.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagCast
        {
            get
            {
                return this._rbFlagCast;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagCast != null)
                {
                    this._rbFlagCast.CheckedChanged -= eventHandler;
                }
                this._rbFlagCast = value;
                if (this._rbFlagCast != null)
                {
                    this._rbFlagCast.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagCastThrough
        {
            get
            {
                return this._rbFlagCastThrough;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagCastThrough != null)
                {
                    this._rbFlagCastThrough.CheckedChanged -= eventHandler;
                }
                this._rbFlagCastThrough = value;
                if (this._rbFlagCastThrough != null)
                {
                    this._rbFlagCastThrough.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagDisallow
        {
            get
            {
                return this._rbFlagDisallow;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagDisallow != null)
                {
                    this._rbFlagDisallow.CheckedChanged -= eventHandler;
                }
                this._rbFlagDisallow = value;
                if (this._rbFlagDisallow != null)
                {
                    this._rbFlagDisallow.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagRequired
        {
            get
            {
                return this._rbFlagRequired;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagRequired != null)
                {
                    this._rbFlagRequired.CheckedChanged -= eventHandler;
                }
                this._rbFlagRequired = value;
                if (this._rbFlagRequired != null)
                {
                    this._rbFlagRequired.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagTargets
        {
            get
            {
                return this._rbFlagTargets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagTargets != null)
                {
                    this._rbFlagTargets.CheckedChanged -= eventHandler;
                }
                this._rbFlagTargets = value;
                if (this._rbFlagTargets != null)
                {
                    this._rbFlagTargets.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagTargetsSec
        {
            get
            {
                return this._rbFlagTargetsSec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagTargetsSec != null)
                {
                    this._rbFlagTargetsSec.CheckedChanged -= eventHandler;
                }
                this._rbFlagTargetsSec = value;
                if (this._rbFlagTargetsSec != null)
                {
                    this._rbFlagTargetsSec.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbFlagVector
        {
            get
            {
                return this._rbFlagVector;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbFlagX_CheckedChanged);
                if (this._rbFlagVector != null)
                {
                    this._rbFlagVector.CheckedChanged -= eventHandler;
                }
                this._rbFlagVector = value;
                if (this._rbFlagVector != null)
                {
                    this._rbFlagVector.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual Button rbPrAdd
        {
            get
            {
                return this._rbPrAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbPrAdd_Click);
                if (this._rbPrAdd != null)
                {
                    this._rbPrAdd.Click -= eventHandler;
                }
                this._rbPrAdd = value;
                if (this._rbPrAdd != null)
                {
                    this._rbPrAdd.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbPrPowerA
        {
            get
            {
                return this._rbPrPowerA;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbPrPowerX_CheckedChanged);
                if (this._rbPrPowerA != null)
                {
                    this._rbPrPowerA.CheckedChanged -= eventHandler;
                }
                this._rbPrPowerA = value;
                if (this._rbPrPowerA != null)
                {
                    this._rbPrPowerA.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual RadioButton rbPrPowerB
        {
            get
            {
                return this._rbPrPowerB;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbPrPowerX_CheckedChanged);
                if (this._rbPrPowerB != null)
                {
                    this._rbPrPowerB.CheckedChanged -= eventHandler;
                }
                this._rbPrPowerB = value;
                if (this._rbPrPowerB != null)
                {
                    this._rbPrPowerB.CheckedChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual Button rbPrRemove
        {
            get
            {
                return this._rbPrRemove;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.rbPrRemove_Click);
                if (this._rbPrRemove != null)
                {
                    this._rbPrRemove.Click -= eventHandler;
                }
                this._rbPrRemove = value;
                if (this._rbPrRemove != null)
                {
                    this._rbPrRemove.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual TabControl tcPower
        {
            get
            {
                return this._tcPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tcPower = value;
            }
        }


    
    
        internal virtual TabPage tpBasic
        {
            get
            {
                return this._tpBasic;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpBasic = value;
            }
        }


    
    
        internal virtual TabPage tpEffects
        {
            get
            {
                return this._tpEffects;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpEffects = value;
            }
        }


    
    
        internal virtual TabPage tpEnh
        {
            get
            {
                return this._tpEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpEnh = value;
            }
        }


    
    
        internal virtual TabPage tpMutex
        {
            get
            {
                return this._tpMutex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpMutex = value;
            }
        }


    
    
        internal virtual TabPage tpPreReq
        {
            get
            {
                return this._tpPreReq;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpPreReq = value;
            }
        }


    
    
        internal virtual TabPage tpSets
        {
            get
            {
                return this._tpSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpSets = value;
            }
        }


    
    
        internal virtual TabPage tpSpecialEnh
        {
            get
            {
                return this._tpSpecialEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpSpecialEnh = value;
            }
        }


    
    
        internal virtual TabPage tpSubPower
        {
            get
            {
                return this._tpSubPower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpSubPower = value;
            }
        }


    
    
        internal virtual TabPage tpText
        {
            get
            {
                return this._tpText;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpText = value;
            }
        }


    
    
        internal virtual TextBox txtAcc
        {
            get
            {
                return this._txtAcc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtAcc_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtAcc_TextChanged);
                if (this._txtAcc != null)
                {
                    this._txtAcc.Leave -= eventHandler;
                    this._txtAcc.TextChanged -= eventHandler2;
                }
                this._txtAcc = value;
                if (this._txtAcc != null)
                {
                    this._txtAcc.Leave += eventHandler;
                    this._txtAcc.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtActivate
        {
            get
            {
                return this._txtActivate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtActivate_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtActivate_TextChanged);
                if (this._txtActivate != null)
                {
                    this._txtActivate.Leave -= eventHandler;
                    this._txtActivate.TextChanged -= eventHandler2;
                }
                this._txtActivate = value;
                if (this._txtActivate != null)
                {
                    this._txtActivate.Leave += eventHandler;
                    this._txtActivate.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtArc
        {
            get
            {
                return this._txtArc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtArc_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtArc_TextChanged);
                if (this._txtArc != null)
                {
                    this._txtArc.Leave -= eventHandler;
                    this._txtArc.TextChanged -= eventHandler2;
                }
                this._txtArc = value;
                if (this._txtArc != null)
                {
                    this._txtArc.Leave += eventHandler;
                    this._txtArc.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtCastTime
        {
            get
            {
                return this._txtCastTime;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtCastTime_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtCastTime_TextChanged);
                if (this._txtCastTime != null)
                {
                    this._txtCastTime.Leave -= eventHandler;
                    this._txtCastTime.TextChanged -= eventHandler2;
                }
                this._txtCastTime = value;
                if (this._txtCastTime != null)
                {
                    this._txtCastTime.Leave += eventHandler;
                    this._txtCastTime.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtDescLong
        {
            get
            {
                return this._txtDescLong;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDescLong_TextChanged);
                if (this._txtDescLong != null)
                {
                    this._txtDescLong.TextChanged -= eventHandler;
                }
                this._txtDescLong = value;
                if (this._txtDescLong != null)
                {
                    this._txtDescLong.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtDescShort
        {
            get
            {
                return this._txtDescShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtDescShort_TextChanged);
                if (this._txtDescShort != null)
                {
                    this._txtDescShort.TextChanged -= eventHandler;
                }
                this._txtDescShort = value;
                if (this._txtDescShort != null)
                {
                    this._txtDescShort.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtEndCost
        {
            get
            {
                return this._txtEndCost;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtEndCost_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtEndCost_TextChanged);
                if (this._txtEndCost != null)
                {
                    this._txtEndCost.Leave -= eventHandler;
                    this._txtEndCost.TextChanged -= eventHandler2;
                }
                this._txtEndCost = value;
                if (this._txtEndCost != null)
                {
                    this._txtEndCost.Leave += eventHandler;
                    this._txtEndCost.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtInterrupt
        {
            get
            {
                return this._txtInterrupt;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtInterrupt_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtInterrupt_TextChanged);
                if (this._txtInterrupt != null)
                {
                    this._txtInterrupt.Leave -= eventHandler;
                    this._txtInterrupt.TextChanged -= eventHandler2;
                }
                this._txtInterrupt = value;
                if (this._txtInterrupt != null)
                {
                    this._txtInterrupt.Leave += eventHandler;
                    this._txtInterrupt.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtLevel
        {
            get
            {
                return this._txtLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtLevel_TextChanged);
                if (this._txtLevel != null)
                {
                    this._txtLevel.Leave -= eventHandler;
                    this._txtLevel.TextChanged -= eventHandler2;
                }
                this._txtLevel = value;
                if (this._txtLevel != null)
                {
                    this._txtLevel.Leave += eventHandler;
                    this._txtLevel.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtLifeTimeGame
        {
            get
            {
                return this._txtLifeTimeGame;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtLifeTimeGame_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtLifeTimeGame_Leave);
                if (this._txtLifeTimeGame != null)
                {
                    this._txtLifeTimeGame.TextChanged -= eventHandler;
                    this._txtLifeTimeGame.Leave -= eventHandler2;
                }
                this._txtLifeTimeGame = value;
                if (this._txtLifeTimeGame != null)
                {
                    this._txtLifeTimeGame.TextChanged += eventHandler;
                    this._txtLifeTimeGame.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtLifeTimeReal
        {
            get
            {
                return this._txtLifeTimeReal;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtLifeTimeReal_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtLifeTimeReal_Leave);
                if (this._txtLifeTimeReal != null)
                {
                    this._txtLifeTimeReal.TextChanged -= eventHandler;
                    this._txtLifeTimeReal.Leave -= eventHandler2;
                }
                this._txtLifeTimeReal = value;
                if (this._txtLifeTimeReal != null)
                {
                    this._txtLifeTimeReal.TextChanged += eventHandler;
                    this._txtLifeTimeReal.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtMaxTargets
        {
            get
            {
                return this._txtMaxTargets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtMaxTargets_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtMaxTargets_TextChanged);
                if (this._txtMaxTargets != null)
                {
                    this._txtMaxTargets.Leave -= eventHandler;
                    this._txtMaxTargets.TextChanged -= eventHandler2;
                }
                this._txtMaxTargets = value;
                if (this._txtMaxTargets != null)
                {
                    this._txtMaxTargets.Leave += eventHandler;
                    this._txtMaxTargets.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtNameDisplay
        {
            get
            {
                return this._txtNameDisplay;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtPowerName_TextChanged);
                if (this._txtNameDisplay != null)
                {
                    this._txtNameDisplay.TextChanged -= eventHandler;
                }
                this._txtNameDisplay = value;
                if (this._txtNameDisplay != null)
                {
                    this._txtNameDisplay.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtNamePower
        {
            get
            {
                return this._txtNamePower;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNamePower_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtNamePower_Leave);
                if (this._txtNamePower != null)
                {
                    this._txtNamePower.TextChanged -= eventHandler;
                    this._txtNamePower.Leave -= eventHandler2;
                }
                this._txtNamePower = value;
                if (this._txtNamePower != null)
                {
                    this._txtNamePower.TextChanged += eventHandler;
                    this._txtNamePower.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtNumCharges
        {
            get
            {
                return this._txtNumCharges;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtNumCharges_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtNumCharges_Leave);
                if (this._txtNumCharges != null)
                {
                    this._txtNumCharges.TextChanged -= eventHandler;
                    this._txtNumCharges.Leave -= eventHandler2;
                }
                this._txtNumCharges = value;
                if (this._txtNumCharges != null)
                {
                    this._txtNumCharges.TextChanged += eventHandler;
                    this._txtNumCharges.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtRadius
        {
            get
            {
                return this._txtRadius;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtRadius_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtRadius_TextChanged);
                if (this._txtRadius != null)
                {
                    this._txtRadius.Leave -= eventHandler;
                    this._txtRadius.TextChanged -= eventHandler2;
                }
                this._txtRadius = value;
                if (this._txtRadius != null)
                {
                    this._txtRadius.Leave += eventHandler;
                    this._txtRadius.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtRange
        {
            get
            {
                return this._txtRange;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtRange_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtRange_TextChanged);
                if (this._txtRange != null)
                {
                    this._txtRange.Leave -= eventHandler;
                    this._txtRange.TextChanged -= eventHandler2;
                }
                this._txtRange = value;
                if (this._txtRange != null)
                {
                    this._txtRange.Leave += eventHandler;
                    this._txtRange.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtRangeSec
        {
            get
            {
                return this._txtRangeSec;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtRangeSec_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtRangeSec_Leave);
                if (this._txtRangeSec != null)
                {
                    this._txtRangeSec.TextChanged -= eventHandler;
                    this._txtRangeSec.Leave -= eventHandler2;
                }
                this._txtRangeSec = value;
                if (this._txtRangeSec != null)
                {
                    this._txtRangeSec.TextChanged += eventHandler;
                    this._txtRangeSec.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtRechargeTime
        {
            get
            {
                return this._txtRechargeTime;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtRechargeTime_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtRechargeTime_TextChanged);
                if (this._txtRechargeTime != null)
                {
                    this._txtRechargeTime.Leave -= eventHandler;
                    this._txtRechargeTime.TextChanged -= eventHandler2;
                }
                this._txtRechargeTime = value;
                if (this._txtRechargeTime != null)
                {
                    this._txtRechargeTime.Leave += eventHandler;
                    this._txtRechargeTime.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtScaleName
        {
            get
            {
                return this._txtScaleName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtScaleName_TextChanged);
                if (this._txtScaleName != null)
                {
                    this._txtScaleName.TextChanged -= eventHandler;
                }
                this._txtScaleName = value;
                if (this._txtScaleName != null)
                {
                    this._txtScaleName.TextChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual TextBox txtUseageTime
        {
            get
            {
                return this._txtUseageTime;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtUseageTime_TextChanged);
                EventHandler eventHandler2 = new EventHandler(this.txtUseageTime_Leave);
                if (this._txtUseageTime != null)
                {
                    this._txtUseageTime.TextChanged -= eventHandler;
                    this._txtUseageTime.Leave -= eventHandler2;
                }
                this._txtUseageTime = value;
                if (this._txtUseageTime != null)
                {
                    this._txtUseageTime.TextChanged += eventHandler;
                    this._txtUseageTime.Leave += eventHandler2;
                }
            }
        }


    
    
        internal virtual TextBox txtVisualLocation
        {
            get
            {
                return this._txtVisualLocation;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.txtVisualLocation_Leave);
                EventHandler eventHandler2 = new EventHandler(this.txtVisualLocation_TextChanged);
                if (this._txtVisualLocation != null)
                {
                    this._txtVisualLocation.Leave -= eventHandler;
                    this._txtVisualLocation.TextChanged -= eventHandler2;
                }
                this._txtVisualLocation = value;
                if (this._txtVisualLocation != null)
                {
                    this._txtVisualLocation.Leave += eventHandler;
                    this._txtVisualLocation.TextChanged += eventHandler2;
                }
            }
        }


    
    
        internal virtual NumericUpDown udScaleMax
        {
            get
            {
                return this._udScaleMax;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udScaleMax_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udScaleMax_Leave);
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.udScaleMax_KeyPress);
                if (this._udScaleMax != null)
                {
                    this._udScaleMax.ValueChanged -= eventHandler;
                    this._udScaleMax.Leave -= eventHandler2;
                    this._udScaleMax.KeyPress -= pressEventHandler;
                }
                this._udScaleMax = value;
                if (this._udScaleMax != null)
                {
                    this._udScaleMax.ValueChanged += eventHandler;
                    this._udScaleMax.Leave += eventHandler2;
                    this._udScaleMax.KeyPress += pressEventHandler;
                }
            }
        }


    
    
        internal virtual NumericUpDown udScaleMin
        {
            get
            {
                return this._udScaleMin;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.udScaleMin_ValueChanged);
                EventHandler eventHandler2 = new EventHandler(this.udScaleMin_Leave);
                KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.udScaleMin_KeyPress);
                if (this._udScaleMin != null)
                {
                    this._udScaleMin.ValueChanged -= eventHandler;
                    this._udScaleMin.Leave -= eventHandler2;
                    this._udScaleMin.KeyPress -= pressEventHandler;
                }
                this._udScaleMin = value;
                if (this._udScaleMin != null)
                {
                    this._udScaleMin.ValueChanged += eventHandler;
                    this._udScaleMin.Leave += eventHandler2;
                    this._udScaleMin.KeyPress += pressEventHandler;
                }
            }
        }


        public frmEditPower(ref IPower iPower)
        {
            base.Load += this.frmEditPower_Load;
            this.enhPadding = 6;
            this.enhAcross = 8;
            this.Updating = true;
            this.ReqChanging = false;
            this.InitializeComponent();
            this.myPower = new Power(iPower);
            this.backup_Requires = new Requirement(this.myPower.Requires);
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        void btnCSVImport_Click(object sender, EventArgs e)
        {
            string str = Clipboard.GetDataObject().GetData("System.String", true).ToString();
            if (str != "")
            {
                PowerData powerData = new PowerData(str.Replace("\t", ","));
                if (powerData.IsValid)
                {
                    Interaction.MsgBox("Import successful.", MsgBoxStyle.OkOnly, null);
                    this.refresh_PowerData();
                }
                else
                {
                    Interaction.MsgBox("Import failed. No changes made.", MsgBoxStyle.OkOnly, null);
                }
            }
        }


        void btnFullCopy_Click(object sender, EventArgs e)
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdPowerBIN");
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            this.myPower.StoreTo(ref writer);
            writer.Close();
            DataObject dataObject = new DataObject(format.Name, memoryStream.GetBuffer());
            Clipboard.SetDataObject(dataObject);
            memoryStream.Close();
        }


        void btnFullPaste_Click(object sender, EventArgs e)
        {
            DataFormats.Format format = DataFormats.GetFormat("mhdPowerBIN");
            string groupName = this.myPower.GroupName;
            string setName = this.myPower.SetName;
            if (!Clipboard.ContainsData(format.Name))
            {
                Interaction.MsgBox("No power data on the clipboard!", MsgBoxStyle.Information, "Unable to Paste");
            }
            else
            {
                byte[] buffer = (byte[])Clipboard.GetDataObject().GetData(format.Name);
                MemoryStream memoryStream = new MemoryStream(buffer);
                BinaryReader reader = new BinaryReader(memoryStream);
                this.myPower = new Power(reader);
                this.myPower.GroupName = groupName;
                this.myPower.SetName = setName;
                this.SetFullName();
                this.refresh_PowerData();
                reader.Close();
                memoryStream.Close();
            }
        }


        void btnFXAdd_Click(object sender, EventArgs e)
        {
            IEffect iFX = new Effect();
            frmPowerEffect frmPowerEffect = new frmPowerEffect(ref iFX);
            if (frmPowerEffect.ShowDialog() == DialogResult.OK)
            {
                IPower power = this.myPower;
                IPower power2 = power;
                IEffect[] effectArray = (IEffect[])Utils.CopyArray(power2.Effects, new IEffect[power.Effects.Length + 1]);
                power2.Effects = effectArray;
                power.Effects[power.Effects.Length - 1] = (IEffect)frmPowerEffect.myFX.Clone();
                this.RefreshFXData(0);
                this.lvFX.SelectedIndex = this.lvFX.Items.Count - 1;
            }
        }


        void btnFXDown_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvFX.SelectedIndices[0];
                if (selectedIndex <= this.myPower.Effects.Length - 2)
                {
                    IEffect[] effectArray = new IEffect[]
                    {
                        (IEffect)this.myPower.Effects[selectedIndex].Clone(),
                        (IEffect)this.myPower.Effects[selectedIndex + 1].Clone()
                    };
                    this.myPower.Effects[selectedIndex] = (IEffect)effectArray[1].Clone();
                    this.myPower.Effects[selectedIndex + 1] = (IEffect)effectArray[0].Clone();
                    this.RefreshFXData(0);
                    this.lvFX.SelectedIndex = selectedIndex + 1;
                }
            }
        }


        void btnFXDuplicate_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count > 0)
            {
                IEffect iFX = (IEffect)this.myPower.Effects[this.lvFX.SelectedIndices[0]].Clone();
                frmPowerEffect frmPowerEffect = new frmPowerEffect(ref iFX);
                if (frmPowerEffect.ShowDialog() == DialogResult.OK)
                {
                    IPower power = this.myPower;
                    IPower power2 = power;
                    IEffect[] effectArray = (IEffect[])Utils.CopyArray(power2.Effects, new IEffect[power.Effects.Length + 1]);
                    power2.Effects = effectArray;
                    power.Effects[power.Effects.Length - 1] = (IEffect)frmPowerEffect.myFX.Clone();
                    this.RefreshFXData(0);
                    this.lvFX.SelectedIndex = this.lvFX.Items.Count - 1;
                }
            }
        }


        void btnFXEdit_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvFX.SelectedIndices[0];
                IEffect iFX = (IEffect)this.myPower.Effects[selectedIndex].Clone();
                frmPowerEffect frmPowerEffect = new frmPowerEffect(ref iFX);
                if (frmPowerEffect.ShowDialog() == DialogResult.OK)
                {
                    this.myPower.Effects[selectedIndex] = (IEffect)frmPowerEffect.myFX.Clone();
                    this.RefreshFXData(0);
                    this.lvFX.SelectedIndex = selectedIndex;
                }
            }
        }


        void btnFXRemove_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndex >= 0)
            {
                IEffect[] effectArray = new IEffect[this.myPower.Effects.Length - 1 + 1];
                int selectedIndex = this.lvFX.SelectedIndex;
                int num = effectArray.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    effectArray[index2] = (IEffect)this.myPower.Effects[index2].Clone();
                }
                this.myPower.Effects = new IEffect[this.myPower.Effects.Length - 2 + 1];
                int index3 = 0;
                int num2 = effectArray.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (index2 != selectedIndex)
                    {
                        this.myPower.Effects[index3] = effectArray[index2];
                        index3++;
                    }
                }
                this.RefreshFXData(0);
                if (this.lvFX.Items.Count > selectedIndex)
                {
                    this.lvFX.SelectedIndex = selectedIndex;
                }
                else if (this.lvFX.Items.Count > selectedIndex - 1)
                {
                    this.lvFX.SelectedIndex = selectedIndex - 1;
                }
            }
        }


        void btnFXUp_Click(object sender, EventArgs e)
        {
            if (this.lvFX.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.lvFX.SelectedIndices[0];
                IEffect[] effectArray = new IEffect[2];
                if (selectedIndex >= 1)
                {
                    effectArray[0] = (IEffect)this.myPower.Effects[selectedIndex].Clone();
                    effectArray[1] = (IEffect)this.myPower.Effects[selectedIndex - 1].Clone();
                    this.myPower.Effects[selectedIndex] = (IEffect)effectArray[1].Clone();
                    this.myPower.Effects[selectedIndex - 1] = (IEffect)effectArray[0].Clone();
                    this.RefreshFXData(0);
                    this.lvFX.SelectedIndex = selectedIndex - 1;
                }
            }
        }


        void btnMutexAdd_Click(object sender, EventArgs e)
        {
            string b = Interaction.InputBox("Please enter a new group name. It must be different to all the others", "Add Mutex Group", "New_Group", -1, -1).Replace(" ", "_");
            int count = this.clbMutex.Items.Count;
            int index = 0;
            if (index <= count)
            {
                if (string.Equals(this.clbMutex.Items[index].ToString(), b, StringComparison.OrdinalIgnoreCase))
                {
                    Interaction.MsgBox("'" + b + "' is not unique!", MsgBoxStyle.Information, "Unable to add");
                }
                else
                {
                    this.clbMutex.Items.Add(b, true);
                    this.clbMutex.SelectedIndex = this.clbMutex.Items.Count - 1;
                }
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            IPower power = this.myPower;
            this.lblNameFull.Text = string.Concat(new string[]
            {
                power.GroupName,
                ".",
                power.SetName,
                ".",
                power.PowerName
            });
            if (power.GroupName == "" | power.SetName == "" | power.PowerName == "")
            {
                Interaction.MsgBox("Power name '" + power.FullName + " is invalid.", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else if (!frmEditPower.PowerFullNameIsUnique(Conversions.ToString(power.PowerIndex), -1))
            {
                Interaction.MsgBox("Power name '" + power.FullName + " already exists, please enter a unique name.", MsgBoxStyle.Exclamation, "No Can Do");
            }
            else
            {
                Array.Sort<string>(this.myPower.UIDSubPower);
                this.Store_Req_Classes();
                this.myPower.IsModified = true;
                if (this.myPower.VariableEnabled)
                {
                    if (this.myPower.VariableMin >= this.myPower.VariableMax)
                    {
                        this.myPower.VariableMin = 0;
                        if (this.myPower.VariableMax == 0)
                        {
                            this.myPower.VariableMax = 1;
                        }
                    }
                    if (this.myPower.MaxTargets > 1 & this.myPower.MaxTargets != this.myPower.VariableMax)
                    {
                        this.myPower.VariableMax = this.myPower.MaxTargets;
                    }
                }
                this.myPower.GroupMembership = new string[this.clbMutex.CheckedItems.Count - 1 + 1];
                this.myPower.NGroupMembership = new int[this.clbMutex.CheckedItems.Count - 1 + 1];
                int num3 = this.clbMutex.CheckedItems.Count - 1;
                for (int index = 0; index <= num3; index++)
                {
                    this.myPower.GroupMembership[index] = Conversions.ToString(this.clbMutex.CheckedItems[index]);
                    this.myPower.NGroupMembership[index] = this.clbMutex.CheckedIndices[index];
                }
                base.DialogResult = DialogResult.OK;
                base.Hide();
            }
        }


        void btnPrDown_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count >= 1)
            {
                int num = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
                bool flag = this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1;
                int index = num;
                int index2 = index + 1;
                string[][] strArray = new string[2][];
                string[] strArray2 = new string[2];
                strArray[0] = strArray2;
                strArray2 = new string[2];
                strArray[1] = strArray2;
                if (flag)
                {
                    if (num > this.myPower.Requires.PowerIDNot.Length - 2)
                    {
                        return;
                    }
                    strArray[0][0] = this.myPower.Requires.PowerIDNot[index][0];
                    strArray[0][1] = this.myPower.Requires.PowerIDNot[index][1];
                    strArray[1][0] = this.myPower.Requires.PowerIDNot[index2][0];
                    strArray[1][1] = this.myPower.Requires.PowerIDNot[index2][1];
                    this.myPower.Requires.PowerIDNot[index][0] = strArray[1][0];
                    this.myPower.Requires.PowerIDNot[index][1] = strArray[1][1];
                    this.myPower.Requires.PowerIDNot[index2][0] = strArray[0][0];
                    this.myPower.Requires.PowerIDNot[index2][1] = strArray[0][1];
                    index2 = this.lvPrListing.SelectedIndices[0] + 1;
                }
                else
                {
                    if (num > this.myPower.Requires.PowerID.Length - 2)
                    {
                        return;
                    }
                    strArray[0][0] = this.myPower.Requires.PowerID[index][0];
                    strArray[0][1] = this.myPower.Requires.PowerID[index][1];
                    strArray[1][0] = this.myPower.Requires.PowerID[index2][0];
                    strArray[1][1] = this.myPower.Requires.PowerID[index2][1];
                    this.myPower.Requires.PowerID[index][0] = strArray[1][0];
                    this.myPower.Requires.PowerID[index][1] = strArray[1][1];
                    this.myPower.Requires.PowerID[index2][0] = strArray[0][0];
                    this.myPower.Requires.PowerID[index2][1] = strArray[0][1];
                }
                this.FillTab_Req();
                this.lvPrListing.Items[index2].Selected = true;
                this.lvPrListing.Items[index2].EnsureVisible();
            }
        }


        void btnPrReset_Click(object sender, EventArgs e)
        {
            this.myPower.Requires = new Requirement(this.backup_Requires);
            this.FillTab_Req();
        }


        void btnPrSetNone_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count >= 1)
            {
                if (this.rbPrPowerA.Checked)
                {
                    if (this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1] != "")
                    {
                        this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][0] = this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1];
                        this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1] = "";
                    }
                    else
                    {
                        this.rbPrRemove_Click(this, new EventArgs());
                    }
                }
                else
                {
                    this.myPower.Requires.PowerID[this.lvPrListing.SelectedIndices[0]][1] = "";
                }
                this.FillTab_Req();
            }
        }


        void btnPrUp_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count >= 1)
            {
                int num = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
                bool flag = this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1;
                if (num >= 1)
                {
                    int index = num;
                    int index2 = index - 1;
                    string[][] strArray = new string[2][];
                    string[] strArray2 = new string[2];
                    strArray[0] = strArray2;
                    strArray2 = new string[2];
                    strArray[1] = strArray2;
                    if (flag)
                    {
                        strArray[0][0] = this.myPower.Requires.PowerIDNot[index][0];
                        strArray[0][1] = this.myPower.Requires.PowerIDNot[index][1];
                        strArray[1][0] = this.myPower.Requires.PowerIDNot[index2][0];
                        strArray[1][1] = this.myPower.Requires.PowerIDNot[index2][1];
                        this.myPower.Requires.PowerIDNot[index][0] = strArray[1][0];
                        this.myPower.Requires.PowerIDNot[index][1] = strArray[1][1];
                        this.myPower.Requires.PowerIDNot[index2][0] = strArray[0][0];
                        this.myPower.Requires.PowerIDNot[index2][1] = strArray[0][1];
                        index2 = this.lvPrListing.SelectedIndices[0] - 1;
                    }
                    else
                    {
                        strArray[0][0] = this.myPower.Requires.PowerID[index][0];
                        strArray[0][1] = this.myPower.Requires.PowerID[index][1];
                        strArray[1][0] = this.myPower.Requires.PowerID[index2][0];
                        strArray[1][1] = this.myPower.Requires.PowerID[index2][1];
                        this.myPower.Requires.PowerID[index][0] = strArray[1][0];
                        this.myPower.Requires.PowerID[index][1] = strArray[1][1];
                        this.myPower.Requires.PowerID[index2][0] = strArray[0][0];
                        this.myPower.Requires.PowerID[index2][1] = strArray[0][1];
                    }
                    this.FillTab_Req();
                    this.lvPrListing.Items[index2].Selected = true;
                    this.lvPrListing.Items[index2].EnsureVisible();
                }
            }
        }


        void btnSPAdd_Click(object sender, EventArgs e)
        {
            if (this.lvSPPower.SelectedItems.Count >= 1)
            {
                string b = Conversions.ToString(this.lvSPPower.SelectedItems[0].Tag);
                int num = this.myPower.UIDSubPower.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (string.Equals(this.myPower.UIDSubPower[index], b, StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                }
                IPower power = this.myPower;
                string[] strArray = (string[])Utils.CopyArray(power.UIDSubPower, new string[this.myPower.UIDSubPower.Length + 1]);
                power.UIDSubPower = strArray;
                this.myPower.UIDSubPower[this.myPower.UIDSubPower.Length - 1] = b;
                this.SPFillList();
                this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].Selected = true;
                this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].EnsureVisible();
            }
        }


        void btnSPRemove_Click(object sender, EventArgs e)
        {
            if (this.lvSPSelected.SelectedItems.Count >= 1)
            {
                string text = this.lvSPSelected.SelectedItems[0].Text;
                string[] strArray = new string[this.myPower.UIDSubPower.Length - 2 + 1];
                int num2 = 0;
                int num3 = this.myPower.UIDSubPower.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    if (!string.Equals(this.myPower.UIDSubPower[index2], text, StringComparison.OrdinalIgnoreCase))
                    {
                        strArray[num2] = this.myPower.UIDSubPower[index2];
                        num2++;
                    }
                }
                this.myPower.UIDSubPower = new string[strArray.Length - 1 + 1];
                Array.Copy(strArray, this.myPower.UIDSubPower, strArray.Length);
                this.SPFillList();
                num2--;
                if (num2 > this.lvSPSelected.Items.Count - 1)
                {
                    num2 = this.lvSPSelected.Items.Count - 1;
                }
                else if (num2 < 0)
                {
                }
                this.SPFillList();
                if (this.lvSPSelected.Items.Count > 0)
                {
                    this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].Selected = true;
                    this.lvSPSelected.Items[this.lvSPSelected.Items.Count - 1].EnsureVisible();
                }
            }
        }


        void cbEffectArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.EffectArea = (Enums.eEffectArea)this.cbEffectArea.SelectedIndex;
            }
        }


        void cbForcedClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                int index = this.cbForcedClass.SelectedIndex - 1;
                if (index < 0 | index > DatabaseAPI.Database.Classes.Length - 1)
                {
                    this.myPower.ForcedClass = "";
                }
                else
                {
                    this.myPower.ForcedClass = DatabaseAPI.Database.Classes[index].ClassName;
                }
            }
        }


        void cbNameGroup_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.DisplayNameData();
            }
        }


        void cbNameGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.GroupName = this.cbNameGroup.Text;
                this.SetFullName();
            }
        }


        void cbNameGroup_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.GroupName = this.cbNameGroup.Text;
                this.SetFullName();
            }
        }


        void cbNameSet_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.DisplayNameData();
            }
        }


        void cbNameSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SetName = this.cbNameSet.Text;
                this.SetFullName();
            }
        }


        void cbNameSet_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SetName = this.cbNameSet.Text;
                this.SetFullName();
            }
        }


        void cbNotify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AIReport = (Enums.eNotify)this.cbNotify.SelectedIndex;
            }
        }


        void cbPowerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.PowerType = (Enums.ePowerType)this.cbPowerType.SelectedIndex;
            }
        }


        public void CheckScaleValues()
        {
            if (Conversion.Val(this.udScaleMin.Text) >= Conversion.Val(this.udScaleMax.Text))
            {
                this.udScaleMin.BackColor = Color.Coral;
                this.udScaleMax.BackColor = Color.Coral;
            }
            else
            {
                this.udScaleMin.BackColor = SystemColors.Window;
                this.udScaleMax.BackColor = SystemColors.Window;
            }
        }


        void chkAltSub_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SubIsAltColour = this.chkAltSub.Checked;
            }
        }


        void chkAlwaysToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AlwaysToggle = this.chkAlwaysToggle.Checked;
            }
        }


        void chkBoostBoostable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.BoostBoostable = this.chkPRFrontLoad.Checked;
            }
        }


        void chkBoostUsePlayerLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.BoostUsePlayerLevel = this.chkPRFrontLoad.Checked;
            }
        }


        void chkBuffCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.ClickBuff = this.chkBuffCycle.Checked;
            }
        }


        void chkGraphFix_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SkipMax = this.chkGraphFix.Checked;
            }
        }


        void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.HiddenPower = this.chkHidden.Checked;
            }
        }


        void chkIgnoreStrength_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.IgnoreStrength = this.chkIgnoreStrength.Checked;
            }
        }


        void chkLos_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.TargetLoS = this.chkLos.Checked;
            }
        }


        void chkMutexAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.MutexAuto = this.chkMutexAuto.Checked;
            }
        }


        void chkMutexSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.MutexIgnore = this.chkMutexSkip.Checked;
            }
        }


        void chkNoAUReq_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.NeverAutoUpdateRequirements = this.chkNoAUReq.Checked;
            }
        }


        void chkNoAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.NeverAutoUpdate = this.chkNoAutoUpdate.Checked;
            }
        }


        void chkPRFrontLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AllowFrontLoading = this.chkPRFrontLoad.Checked;
            }
        }


        void chkScale_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                if (!this.myPower.VariableEnabled)
                {
                    this.udScaleMin.Value = 0m;
                    if (this.myPower.MaxTargets > 1)
                    {
                        this.udScaleMax.Value = new decimal(this.myPower.MaxTargets);
                    }
                    else
                    {
                        this.udScaleMax.Value = 3m;
                    }
                }
                this.myPower.VariableEnabled = this.chkScale.Checked;
                this.udScaleMax.Enabled = this.myPower.VariableEnabled;
                this.udScaleMin.Enabled = this.myPower.VariableEnabled;
                this.txtScaleName.Enabled = this.myPower.VariableEnabled;
            }
        }


        void chkSortOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SortOverride = this.chkSortOverride.Checked;
            }
        }


        void chkSubInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.IncludeFlag = this.chkSubInclude.Checked;
            }
        }


        void chkSummonDisplayEntity_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.ShowSummonAnyway = this.chkSummonDisplayEntity.Checked;
            }
        }


        void chkSummonStealAttributes_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AbsorbSummonAttributes = this.chkSummonStealAttributes.Checked;
            }
        }


        void chkSummonStealEffects_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AbsorbSummonEffects = this.chkSummonStealEffects.Checked;
            }
        }


        void clbFlags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!this.Updating)
            {
                if (this.rbFlagCastThrough.Checked)
                {
                    if (e.Index == 0)
                    {
                        this.myPower.CastThroughHold = (e.NewValue > CheckState.Unchecked);
                    }
                }
                else
                {
                    int[] numArray = new int[26];
                    int num = 0;
                    int num2 = 1;
                    int num3 = numArray.Length - 1;
                    for (int index = 1; index <= num3; index++)
                    {
                        numArray[index] = num2;
                        num2 *= 2;
                    }
                    if (this.rbFlagAutoHit.Checked)
                    {
                        num = (int)this.myPower.EntitiesAutoHit;
                    }
                    else if (this.rbFlagAffected.Checked)
                    {
                        num = (int)this.myPower.EntitiesAffected;
                    }
                    else if (this.rbFlagTargets.Checked)
                    {
                        num = (int)this.myPower.Target;
                    }
                    else if (this.rbFlagTargetsSec.Checked)
                    {
                        num = (int)this.myPower.TargetSecondary;
                    }
                    else if (this.rbFlagCast.Checked)
                    {
                        num = (int)this.myPower.CastFlags;
                    }
                    else if (this.rbFlagVector.Checked)
                    {
                        num = (int)this.myPower.AttackTypes;
                    }
                    else if (this.rbFlagRequired.Checked)
                    {
                        num = (int)this.myPower.ModesRequired;
                    }
                    else if (this.rbFlagDisallow.Checked)
                    {
                        num = (int)this.myPower.ModesDisallowed;
                    }
                    if (e.CurrentValue == CheckState.Unchecked & e.NewValue == CheckState.Checked)
                    {
                        num += numArray[e.Index];
                    }
                    else if (e.CurrentValue == CheckState.Checked & e.NewValue == CheckState.Unchecked)
                    {
                        num -= numArray[e.Index];
                    }
                    if (this.rbFlagAutoHit.Checked)
                    {
                        this.myPower.EntitiesAutoHit = (Enums.eEntity)num;
                    }
                    else if (this.rbFlagAffected.Checked)
                    {
                        this.myPower.EntitiesAffected = (Enums.eEntity)num;
                    }
                    else if (this.rbFlagTargets.Checked)
                    {
                        this.myPower.Target = (Enums.eEntity)num;
                    }
                    else if (this.rbFlagTargetsSec.Checked)
                    {
                        this.myPower.TargetSecondary = (Enums.eEntity)num;
                    }
                    else if (this.rbFlagCast.Checked)
                    {
                        this.myPower.CastFlags = (Enums.eCastFlags)num;
                    }
                    else if (this.rbFlagVector.Checked)
                    {
                        this.myPower.AttackTypes = (Enums.eVector)num;
                    }
                    else if (this.rbFlagRequired.Checked)
                    {
                        this.myPower.ModesRequired = (Enums.eModeFlags)num;
                    }
                    else if (this.rbFlagDisallow.Checked)
                    {
                        this.myPower.ModesDisallowed = (Enums.eModeFlags)num;
                    }
                }
            }
        }


        void DisplayNameData()
        {
            IPower power = this.myPower;
            this.lblNameFull.Text = string.Concat(new string[]
            {
                power.GroupName,
                ".",
                power.SetName,
                ".",
                power.PowerName
            });
            if (power.GroupName == "" | power.SetName == "" | power.PowerName == "")
            {
                this.lblNameUnique.Text = "This name is invalid.";
            }
            else if (frmEditPower.PowerFullNameIsUnique(Conversions.ToString(power.PowerIndex), -1))
            {
                this.lblNameUnique.Text = "This name is unique.";
            }
            else
            {
                this.lblNameUnique.Text = "This name is NOT unique.";
            }
        }


        void DrawAcceptedSets()
        {
            this.bxSet = new ExtendedBitmap(this.pbInvSetUsed.Width, this.pbInvSetUsed.Height);
            int enhPadding = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            Font font = new Font(this.Font, FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(0, 255, 0));
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            this.bxSet.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxSet.ClipRect);
            int num = this.myPower.SetTypes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding, 30, 30);
                this.bxSet.Graphics.DrawImage(I9Gfx.SetTypes.Bitmap, destRect, I9Gfx.GetImageRect((int)this.myPower.SetTypes[index]), GraphicsUnit.Pixel);
                string s;
                switch (this.myPower.SetTypes[index])
                {
                    case Enums.eSetType.MeleeST:
                        s = "M\r\nST";
                        break;
                    case Enums.eSetType.RangedST:
                        s = "R\r\nST";
                        break;
                    case Enums.eSetType.RangedAoE:
                        s = "R\r\nAoE";
                        break;
                    case Enums.eSetType.MeleeAoE:
                        s = "M\r\nAoE";
                        break;
                    case Enums.eSetType.Snipe:
                        s = "S";
                        break;
                    default:
                        s = "";
                        break;
                }
                RectangleF layoutRectangle = new RectangleF((float)destRect.X, (float)destRect.Y, (float)destRect.Width, (float)destRect.Height);
                layoutRectangle.X -= 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.Y -= 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X += 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X += 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.Y += 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.Y += 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X -= 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X -= 1f;
                this.bxSet.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle = new RectangleF((float)destRect.X, (float)destRect.Y, (float)destRect.Width, (float)destRect.Height);
                this.bxSet.Graphics.DrawString(s, font, solidBrush2, layoutRectangle, format);
                enhPadding2 += 30 + this.enhPadding;
            }
            this.pbInvSetUsed.CreateGraphics().DrawImageUnscaled(this.bxSet.Bitmap, 0, 0);
        }


        void DrawSetList()
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            this.bxSetList = new ExtendedBitmap(this.pbInvSetList.Width, this.pbInvSetList.Height);
            int enhPadding = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            int num = 0;
            Font font = new Font(this.Font, FontStyle.Bold);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(0, 255, 0));
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            string[] names = Enum.GetNames(eSetType.GetType());
            this.bxSetList.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxSetList.ClipRect);
            int num2 = names.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding, 30, 30);
                this.bxSetList.Graphics.DrawImage(I9Gfx.SetTypes.Bitmap, destRect, I9Gfx.GetImageRect(index), GraphicsUnit.Pixel);
                Enums.eSetType eSetType2 = (Enums.eSetType)index;
                string s;
                switch (eSetType2)
                {
                    case Enums.eSetType.MeleeST:
                        s = "M\r\nST";
                        break;
                    case Enums.eSetType.RangedST:
                        s = "R\r\nST";
                        break;
                    case Enums.eSetType.RangedAoE:
                        s = "R\r\nAoE";
                        break;
                    case Enums.eSetType.MeleeAoE:
                        s = "M\r\nAoE";
                        break;
                    case Enums.eSetType.Snipe:
                        s = "S";
                        break;
                    default:
                        if (eSetType2 != Enums.eSetType.UniversalDamage)
                        {
                            s = "";
                        }
                        else
                        {
                            s = "Dmg";
                        }
                        break;
                }
                RectangleF layoutRectangle = new RectangleF((float)destRect.X, (float)destRect.Y, (float)destRect.Width, (float)destRect.Height);
                layoutRectangle.X -= 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.Y -= 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X += 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X += 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.Y += 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.Y += 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X -= 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle.X -= 1f;
                this.bxSetList.Graphics.DrawString(s, font, solidBrush, layoutRectangle, format);
                layoutRectangle = new RectangleF((float)destRect.X, (float)destRect.Y, (float)destRect.Width, (float)destRect.Height);
                this.bxSetList.Graphics.DrawString(s, font, solidBrush2, layoutRectangle, format);
                enhPadding2 += 30 + this.enhPadding;
                num++;
                if (num == this.enhAcross)
                {
                    num = 0;
                    enhPadding2 = this.enhPadding;
                    enhPadding += 30 + this.enhPadding;
                }
            }
            this.pbInvSetList.CreateGraphics().DrawImageUnscaled(this.bxSetList.Bitmap, 0, 0);
        }


        void FillAdvAtrList()
        {
            int num = 0;
            Type type = this.myPower.EntitiesAutoHit.GetType();
            bool flag = true;
            bool updating = this.Updating;
            this.Updating = true;
            this.clbFlags.BeginUpdate();
            this.clbFlags.Items.Clear();
            if (this.rbFlagAutoHit.Checked)
            {
                type = this.myPower.EntitiesAutoHit.GetType();
                num = (int)this.myPower.EntitiesAutoHit;
            }
            else if (this.rbFlagAffected.Checked)
            {
                type = this.myPower.EntitiesAffected.GetType();
                num = (int)this.myPower.EntitiesAffected;
            }
            else if (this.rbFlagTargets.Checked)
            {
                type = this.myPower.Target.GetType();
                num = (int)this.myPower.Target;
            }
            else if (this.rbFlagTargetsSec.Checked)
            {
                type = this.myPower.TargetSecondary.GetType();
                num = (int)this.myPower.TargetSecondary;
            }
            else if (this.rbFlagCast.Checked)
            {
                type = this.myPower.CastFlags.GetType();
                num = (int)this.myPower.CastFlags;
            }
            else if (this.rbFlagVector.Checked)
            {
                type = this.myPower.AttackTypes.GetType();
                num = (int)this.myPower.AttackTypes;
            }
            else if (this.rbFlagRequired.Checked)
            {
                type = this.myPower.ModesRequired.GetType();
                num = (int)this.myPower.ModesRequired;
            }
            else if (this.rbFlagDisallow.Checked)
            {
                type = this.myPower.ModesDisallowed.GetType();
                num = (int)this.myPower.ModesDisallowed;
            }
            else if (this.rbFlagCastThrough.Checked)
            {
                flag = false;
                this.clbFlags.Items.Add("Mez", this.myPower.CastThroughHold);
            }
            if (flag)
            {
                string[] names = Enum.GetNames(type);
                int[] values = (int[])Enum.GetValues(type);
                int num2 = values.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    int num3 = values[index] & num;
                    bool isChecked = num3 != 0;
                    this.clbFlags.Items.Add(names[index], isChecked);
                }
            }
            this.clbFlags.EndUpdate();
            this.Updating = updating;
        }


        void FillCombo_Attribs()
        {
            Enums.ePowerType ePowerType = Enums.ePowerType.Click;
            bool updating = this.Updating;
            this.Updating = true;
            this.cbEffectArea.BeginUpdate();
            this.cbNotify.BeginUpdate();
            this.cbPowerType.BeginUpdate();
            this.cbEffectArea.Items.Clear();
            this.cbNotify.Items.Clear();
            this.cbPowerType.Items.Clear();
            this.cbEffectArea.Items.AddRange(Enum.GetNames(this.myPower.EffectArea.GetType()));
            this.cbNotify.Items.AddRange(Enum.GetNames(this.myPower.AIReport.GetType()));
            string[] names = Enum.GetNames(ePowerType.GetType());
            int num = names.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                names[index] = names[index].Replace("_", "");
            }
            this.cbPowerType.Items.AddRange(names);
            this.cbEffectArea.EndUpdate();
            this.cbNotify.EndUpdate();
            this.cbPowerType.EndUpdate();
            this.Updating = updating;
        }


        void FillCombo_Basic()
        {
            bool updating = this.Updating;
            this.Updating = true;
            this.cbNameGroup.BeginUpdate();
            this.cbNameGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.cbNameGroup.Items.Add(key);
            }
            this.cbNameGroup.EndUpdate();
            this.cbNameSet.BeginUpdate();
            this.cbNameSet.Items.Clear();
            int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.myPower.GroupName);
            int num = indexesByGroupName.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.cbNameSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
            }
            this.cbNameSet.EndUpdate();
            this.cbForcedClass.BeginUpdate();
            this.cbForcedClass.Items.Clear();
            this.cbForcedClass.Items.Add("None");
            int num2 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                this.cbForcedClass.Items.Add(DatabaseAPI.Database.Classes[index].ClassName);
            }
            this.cbForcedClass.EndUpdate();
            this.Updating = updating;
        }


        void FillComboBoxes()
        {
            Enums.eEnhance eEnhance = Enums.eEnhance.X_RechargeTime;
            this.lvDisablePass1.BeginUpdate();
            this.lvDisablePass1.Items.Clear();
            this.lvDisablePass1.Items.AddRange(Enum.GetNames(eEnhance.GetType()));
            this.lvDisablePass1.EndUpdate();
            this.lvDisablePass4.BeginUpdate();
            this.lvDisablePass4.Items.Clear();
            this.lvDisablePass4.Items.AddRange(Enum.GetNames(eEnhance.GetType()));
            this.lvDisablePass4.EndUpdate();
        }


        void FillTab_Attribs()
        {
            IPower power = this.myPower;
            string Style = "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0###";
            this.txtLevel.Text = Conversions.ToString(power.Level);
            this.txtAcc.Text = Strings.Format(power.Accuracy, Style);
            this.txtInterrupt.Text = Strings.Format(power.InterruptTime, Style);
            this.txtCastTime.Text = Strings.Format(power.CastTimeReal, Style);
            this.txtRechargeTime.Text = Strings.Format(power.RechargeTime, Style);
            this.txtActivate.Text = Strings.Format(power.ActivatePeriod, Style);
            this.txtEndCost.Text = Strings.Format(power.EndCost, Style);
            this.txtRange.Text = Strings.Format(power.Range, Style);
            this.txtRangeSec.Text = Strings.Format(power.RangeSecondary, Style);
            this.txtRadius.Text = Conversions.ToString(power.Radius);
            this.txtArc.Text = Conversions.ToString(power.Arc);
            this.txtMaxTargets.Text = Conversions.ToString(power.MaxTargets);
            this.cbPowerType.SelectedIndex = (int)power.PowerType;
            this.cbEffectArea.SelectedIndex = (int)power.EffectArea;
            this.cbNotify.SelectedIndex = (int)power.AIReport;
            this.chkLos.Checked = power.TargetLoS;
            this.chkIgnoreStrength.Checked = power.IgnoreStrength;
            this.txtNumCharges.Text = Conversions.ToString(power.NumCharges);
            this.txtUseageTime.Text = Conversions.ToString(power.UsageTime);
            this.txtLifeTimeGame.Text = Conversions.ToString(power.LifeTimeInGame);
            this.txtLifeTimeReal.Text = Conversions.ToString(power.LifeTime);
            this.rbFlagAutoHit.Checked = true;
            this.FillAdvAtrList();
        }


        void FillTab_Basic()
        {
            IPower power = this.myPower;
            this.txtNameDisplay.Text = power.DisplayName;
            this.txtNamePower.Text = power.PowerName;
            this.cbNameGroup.Text = power.GroupName;
            this.cbNameSet.Text = power.SetName;
            this.DisplayNameData();
            this.txtDescLong.Text = power.DescLong;
            this.txtDescShort.Text = power.DescShort;
            this.udScaleMin.Value = new decimal(power.VariableMin);
            this.udScaleMax.Value = new decimal(power.VariableMax);
            this.txtScaleName.Text = power.VariableName;
            this.chkScale.Checked = power.VariableEnabled;
            this.chkBuffCycle.Checked = power.ClickBuff;
            this.chkAlwaysToggle.Checked = power.AlwaysToggle;
            this.chkGraphFix.Checked = this.myPower.SkipMax;
            this.chkAltSub.Checked = power.SubIsAltColour;
            this.chkSubInclude.Checked = power.IncludeFlag;
            this.chkSortOverride.Checked = power.SortOverride;
            this.txtVisualLocation.Text = Conversions.ToString(power.DisplayLocation);
            this.chkSummonStealEffects.Checked = power.AbsorbSummonEffects;
            this.chkSummonStealAttributes.Checked = power.AbsorbSummonAttributes;
            this.chkSummonDisplayEntity.Checked = power.ShowSummonAnyway;
            this.chkNoAUReq.Checked = this.myPower.NeverAutoUpdateRequirements;
            int selectedIndex = DatabaseAPI.NidFromUidClass(power.ForcedClass) + 1;
            this.cbForcedClass.SelectedIndex = selectedIndex;
            this.chkNoAutoUpdate.Checked = this.myPower.NeverAutoUpdate;
            this.chkHidden.Visible = MidsContext.Config.MasterMode;
            this.chkHidden.Checked = this.myPower.HiddenPower;
        }


        void FillTab_Disabling()
        {
            int num = this.myPower.IgnoreEnh.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (this.myPower.IgnoreEnh[index] <= (Enums.eEnhance)(this.lvDisablePass1.Items.Count - 1))
                {
                    this.lvDisablePass1.SetSelected((int)this.myPower.IgnoreEnh[index], true);
                }
            }
            int num2 = this.myPower.Ignore_Buff.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (this.myPower.Ignore_Buff[index] <= (Enums.eEnhance)(this.lvDisablePass4.Items.Count - 1))
                {
                    this.lvDisablePass4.SetSelected((int)this.myPower.Ignore_Buff[index], true);
                }
            }
        }


        void FillTab_Effects()
        {
            this.RefreshFXData(0);
        }


        void FillTab_Enhancements()
        {
            this.RedrawEnhList();
            this.chkPRFrontLoad.Checked = this.myPower.AllowFrontLoading;
            this.chkBoostBoostable.Checked = this.myPower.BoostBoostable;
            this.chkBoostUsePlayerLevel.Checked = this.myPower.BoostUsePlayerLevel;
        }


        void FillTab_Mutex()
        {
            this.chkMutexAuto.Checked = this.myPower.MutexAuto;
            this.chkMutexSkip.Checked = this.myPower.MutexIgnore;
            this.clbMutex.BeginUpdate();
            this.clbMutex.Items.Clear();
            string[] strArray = DatabaseAPI.UidMutexAll();
            int num = strArray.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                bool isChecked = false;
                int num2 = this.myPower.GroupMembership.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (string.Equals(strArray[index], this.myPower.GroupMembership[index2], StringComparison.OrdinalIgnoreCase))
                    {
                        isChecked = true;
                        break;
                    }
                }
                this.clbMutex.Items.Add(strArray[index], isChecked);
            }
            this.clbMutex.EndUpdate();
        }


        void FillTab_Req()
        {
            this.ReqChanging = true;
            this.lvPrListing.BeginUpdate();
            this.lvPrListing.Items.Clear();
            int num = this.myPower.Requires.PowerID.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string[] items = new string[3];
                if (this.myPower.Requires.PowerID[index].Length > 0)
                {
                    items[0] = this.myPower.Requires.PowerID[index][0];
                    if (this.myPower.Requires.PowerID[index][1] != "")
                    {
                        items[1] = "AND";
                        items[2] = this.myPower.Requires.PowerID[index][1];
                    }
                    ListViewItem value = new ListViewItem(items)
                    {
                        Tag = index
                    };
                    this.lvPrListing.Items.Add(value);
                }
            }
            int num2 = this.myPower.Requires.PowerIDNot.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                string[] items2 = new string[3];
                if (this.myPower.Requires.PowerIDNot[index].Length > 0)
                {
                    items2[0] = "NOT " + this.myPower.Requires.PowerIDNot[index][0];
                    if (this.myPower.Requires.PowerIDNot[index][1] != "")
                    {
                        items2[1] = "AND";
                        items2[2] = "NOT " + this.myPower.Requires.PowerIDNot[index][1];
                    }
                    ListViewItem value = new ListViewItem(items2)
                    {
                        Tag = index
                    };
                    this.lvPrListing.Items.Add(value);
                }
            }
            this.lvPrListing.EndUpdate();
            this.ReqChanging = false;
            if (this.lvPrListing.Items.Count > 0)
            {
                this.lvPrListing.Items[0].Selected = true;
            }
        }


        void Filltab_ReqClasses()
        {
            this.clbClassReq.BeginUpdate();
            this.clbClassReq.Items.Clear();
            int num = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                bool isChecked = false;
                int num2 = this.myPower.Requires.ClassName.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.myPower.Requires.ClassName[index2], StringComparison.OrdinalIgnoreCase))
                    {
                        isChecked = true;
                    }
                }
                this.clbClassReq.Items.Add(DatabaseAPI.Database.Classes[index].ClassName, isChecked);
            }
            this.clbClassReq.EndUpdate();
            this.clbClassExclude.BeginUpdate();
            this.clbClassExclude.Items.Clear();
            int num3 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num3; index++)
            {
                bool isChecked2 = false;
                int num4 = this.myPower.Requires.ClassNameNot.Length - 1;
                for (int index2 = 0; index2 <= num4; index2++)
                {
                    if (string.Equals(DatabaseAPI.Database.Classes[index].ClassName, this.myPower.Requires.ClassNameNot[index2], StringComparison.OrdinalIgnoreCase))
                    {
                        isChecked2 = true;
                    }
                }
                this.clbClassExclude.Items.Add(DatabaseAPI.Database.Classes[index].ClassName, isChecked2);
            }
            this.clbClassExclude.EndUpdate();
        }


        void FillTab_Sets()
        {
            this.DrawAcceptedSets();
        }


        void FillTab_SubPowers()
        {
            bool reqChanging = this.ReqChanging;
            this.ReqChanging = true;
            this.SP_GroupList();
            if (this.lvSPGroup.Items.Count > 0)
            {
                this.lvSPGroup.Items[0].Selected = true;
            }
            this.SP_SetList();
            if (this.lvSPSet.Items.Count > 0)
            {
                this.lvSPSet.Items[0].Selected = true;
            }
            this.SP_PowerList();
            this.ReqChanging = reqChanging;
            this.SPFillList();
        }


        void frmEditPower_Load(object sender, EventArgs e)
        {
            this.RedrawEnhPicker();
            this.FillComboBoxes();
            this.DrawSetList();
            this.Req_GroupList();
            this.FillTab_SubPowers();
            this.refresh_PowerData();
            this.Updating = false;
        }


        static int GetClassByID(int iID)
        {
            int num = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (DatabaseAPI.Database.EnhancementClasses[index].ID == iID)
                {
                    return index;
                }
            }
            return 0;
        }


        int GetInvSetIndex(Point e)
        {
            int num = -1;
            int num2 = -1;
            int num3 = 0;
            do
            {
                if (e.X > (this.enhPadding + 30) * num3 & e.X < (this.enhPadding + 30) * (num3 + 1))
                {
                    num = num3;
                }
                num3++;
            }
            while (num3 <= 9);
            num3 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num3 & e.Y < (this.enhPadding + 30) * (num3 + 1))
                {
                    num2 = num3;
                }
                num3++;
            }
            while (num3 <= 10);
            return num + num2 * 10;
        }


        int GetInvSetListIndex(Point e)
        {
            int num = -1;
            int num2 = -1;
            int num3 = this.enhAcross - 1;
            int num4;
            for (num4 = 0; num4 <= num3; num4++)
            {
                if (e.X > (this.enhPadding + 30) * num4 & e.X < (this.enhPadding + 30) * (num4 + 1))
                {
                    num = num4;
                }
            }
            num4 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num4 & e.Y < (this.enhPadding + 30) * (num4 + 1))
                {
                    num2 = num4;
                }
                num4++;
            }
            while (num4 <= 10);
            return num + num2 * this.enhAcross;
        }


        void lblStaticIndex_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Insert new static index for this power.", "", Conversions.ToString(this.myPower.StaticIndex), -1, -1);
            try
            {
                int num = int.Parse(s);
                if (num < 0)
                {
                    Interaction.MsgBox("The static index cannot be a negative number.", MsgBoxStyle.Exclamation, null);
                }
                else
                {
                    this.lblStaticIndex.Text = Conversions.ToString(num);
                    this.myPower.StaticIndex = num;
                }
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, null);
            }
        }


        void lvDisablePass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.myPower.IgnoreEnh = new Enums.eEnhance[this.lvDisablePass1.SelectedIndices.Count - 1 + 1];
                int num = this.lvDisablePass1.SelectedIndices.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.myPower.IgnoreEnh[index] = (Enums.eEnhance)this.lvDisablePass1.SelectedIndices[index];
                }
            }
        }


        void lvDisablePass4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.myPower.Ignore_Buff = new Enums.eEnhance[this.lvDisablePass4.SelectedIndices.Count - 1 + 1];
                int num = this.lvDisablePass4.SelectedIndices.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.myPower.Ignore_Buff[index] = (Enums.eEnhance)this.lvDisablePass4.SelectedIndices[index];
                }
            }
        }


        void lvFX_DoubleClick(object sender, EventArgs e)
        {
            this.btnFXEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }


        void lvFX_KeyPress(object sender, KeyPressEventArgs e)
        {
        }


        void lvPrGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging && this.lvPrGroup.SelectedItems.Count > 0)
            {
                this.Req_SetList();
                if (this.lvPrSet.Items.Count > 0)
                {
                    this.lvPrSet.Items[0].Selected = true;
                }
            }
        }


        void lvPrListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Req_Listing_IndexChanged();
        }


        void lvPrPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging)
            {
                this.Req_UpdateItem();
            }
        }


        void lvPrSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging && this.lvPrSet.SelectedItems.Count > 0)
            {
                this.Req_PowerList();
            }
        }


        void lvSPGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging && this.lvSPGroup.SelectedItems.Count > 0)
            {
                this.SP_SetList();
                if (this.lvSPSet.Items.Count > 0)
                {
                    this.lvSPSet.Items[0].Selected = true;
                }
            }
        }


        void lvSPPower_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        void lvSPSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging && this.lvSPSet.SelectedItems.Count > 0)
            {
                this.SP_PowerList();
            }
        }


        void pbEnhancementList_Hover(object sender, MouseEventArgs e)
        {
            int num = -1;
            int num2 = -1;
            int num3 = this.enhAcross - 1;
            int num4;
            for (num4 = 0; num4 <= num3; num4++)
            {
                if (e.X > (this.enhPadding + 30) * num4 & e.X < (this.enhPadding + 30) * (num4 + 1))
                {
                    num = num4;
                }
            }
            num4 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * num4 & e.Y < (this.enhPadding + 30) * (num4 + 1))
                {
                    num2 = num4;
                }
                num4++;
            }
            while (num4 <= 10);
            int index = num + num2 * this.enhAcross;
            if (index < DatabaseAPI.Database.EnhancementClasses.Length & num > -1 & num2 > -1)
            {
                this.lblEnhName.Text = DatabaseAPI.Database.EnhancementClasses[index].Name;
            }
            else
            {
                this.lblEnhName.Text = "";
            }
        }


        void pbEnhancementList_MouseDown(object sender, MouseEventArgs e)
        {
            int num = -1;
            int num2 = -1;
            int num3 = this.enhAcross - 1;
            int index2;
            for (index2 = 0; index2 <= num3; index2++)
            {
                if (e.X > (this.enhPadding + 30) * index2 & e.X < (this.enhPadding + 30) * (index2 + 1))
                {
                    num = index2;
                }
            }
            index2 = 0;
            do
            {
                if (e.Y > (this.enhPadding + 30) * index2 & e.Y < (this.enhPadding + 30) * (index2 + 1))
                {
                    num2 = index2;
                }
                index2++;
            }
            while (index2 <= 10);
            int index3 = num + num2 * this.enhAcross;
            if (index3 <= DatabaseAPI.Database.EnhancementClasses.Length - 1 & num > -1 & num2 > -1)
            {
                bool flag = false;
                int num4 = this.myPower.Enhancements.Length - 1;
                for (index2 = 0; index2 <= num4; index2++)
                {
                    if (this.myPower.Enhancements[index2] == DatabaseAPI.Database.EnhancementClasses[index3].ID)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    IPower power = this.myPower;
                    int[] numArray = (int[])Utils.CopyArray(power.Enhancements, new int[this.myPower.Enhancements.Length + 1]);
                    power.Enhancements = numArray;
                    this.myPower.Enhancements[this.myPower.Enhancements.Length - 1] = DatabaseAPI.Database.EnhancementClasses[index3].ID;
                    Array.Sort<int>(this.myPower.Enhancements);
                    this.RedrawEnhList();
                }
            }
        }


        void pbEnhancementList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxEnhPicker != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxEnhPicker.Bitmap, 0, 0);
            }
        }


        void pbEnhancements_Hover(object sender, MouseEventArgs e)
        {
            int num = -1;
            int length = this.myPower.Enhancements.Length;
            for (int index = 0; index <= length; index++)
            {
                if (e.X > (this.enhPadding + 30) * index & e.X < (this.enhPadding + 30) * (index + 1))
                {
                    num = index;
                }
            }
            int index2 = num;
            if (index2 < this.myPower.Enhancements.Length & num > -1)
            {
                this.lblEnhName.Text = DatabaseAPI.Database.EnhancementClasses[frmEditPower.GetClassByID(this.myPower.Enhancements[index2])].Name;
            }
            else
            {
                this.lblEnhName.Text = "";
            }
        }


        void pbEnhancements_MouseDown(object sender, MouseEventArgs e)
        {
            int num = -1;
            int length = this.myPower.Enhancements.Length;
            for (int index2 = 0; index2 <= length; index2++)
            {
                if (e.X > (this.enhPadding + 30) * index2 & e.X < (this.enhPadding + 30) * (index2 + 1))
                {
                    num = index2;
                }
            }
            int num2 = num;
            if (num2 < this.myPower.Enhancements.Length & num > -1)
            {
                IPower power = this.myPower;
                int[] numArray = new int[power.Enhancements.Length - 1 + 1];
                int num3 = power.Enhancements.Length - 1;
                for (int index2 = 0; index2 <= num3; index2++)
                {
                    numArray[index2] = power.Enhancements[index2];
                }
                int index3 = 0;
                power.Enhancements = new int[power.Enhancements.Length - 2 + 1];
                int num4 = numArray.Length - 1;
                for (int index2 = 0; index2 <= num4; index2++)
                {
                    if (index2 != num2)
                    {
                        power.Enhancements[index3] = numArray[index2];
                        index3++;
                    }
                }
                Array.Sort<int>(power.Enhancements);
                this.RedrawEnhList();
            }
        }


        void pbEnhancements_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxEnhPicked != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxEnhPicked.Bitmap, 0, 0);
            }
        }


        void pbInvSetList_MouseDown(object sender, MouseEventArgs e)
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            Point e2 = new Point(e.X, e.Y);
            int invSetListIndex = this.GetInvSetListIndex(e2);
            string[] names = Enum.GetNames(eSetType.GetType());
            if (invSetListIndex < names.Length & invSetListIndex > -1)
            {
                bool flag = false;
                int num = this.myPower.SetTypes.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (this.myPower.SetTypes[index] == (Enums.eSetType)invSetListIndex)
                    {
                        flag = true;
                    }
                }
                if (!(flag | this.myPower.SetTypes.Length > 10))
                {
                    IPower power = this.myPower;
                    Enums.eSetType[] eSetTypeArray = (Enums.eSetType[])Utils.CopyArray(power.SetTypes, new Enums.eSetType[this.myPower.SetTypes.Length + 1]);
                    power.SetTypes = eSetTypeArray;
                    this.myPower.SetTypes[this.myPower.SetTypes.Length - 1] = (Enums.eSetType)invSetListIndex;
                    Array.Sort<Enums.eSetType>(this.myPower.SetTypes);
                    this.DrawAcceptedSets();
                }
            }
        }


        void pbInvSetList_MouseMove(object sender, MouseEventArgs e)
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            Point e2 = new Point(e.X, e.Y);
            int invSetListIndex = this.GetInvSetListIndex(e2);
            string[] names = Enum.GetNames(eSetType.GetType());
            if (invSetListIndex < names.Length & invSetListIndex > -1)
            {
                this.lblInvSet.Text = names[invSetListIndex];
            }
            else
            {
                this.lblInvSet.Text = "";
            }
        }


        void pbInvSetList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxSetList != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxSetList.Bitmap, 0, 0);
            }
        }


        void pbInvSetUsed_MouseDown(object sender, MouseEventArgs e)
        {
            Point e2 = new Point(e.X, e.Y);
            int invSetIndex = this.GetInvSetIndex(e2);
            if (invSetIndex < this.myPower.SetTypes.Length & invSetIndex > -1)
            {
                int[] numArray = new int[this.myPower.SetTypes.Length - 1 + 1];
                int num = this.myPower.SetTypes.Length - 1;
                for (int index2 = 0; index2 <= num; index2++)
                {
                    numArray[index2] = (int)this.myPower.SetTypes[index2];
                }
                int index3 = 0;
                this.myPower.SetTypes = new Enums.eSetType[this.myPower.SetTypes.Length - 2 + 1];
                int num2 = numArray.Length - 1;
                for (int index2 = 0; index2 <= num2; index2++)
                {
                    if (index2 != invSetIndex)
                    {
                        this.myPower.SetTypes[index3] = (Enums.eSetType)numArray[index2];
                        index3++;
                    }
                }
                Array.Sort<Enums.eSetType>(this.myPower.SetTypes);
                this.DrawAcceptedSets();
            }
        }


        void pbInvSetUsed_MouseMove(object sender, MouseEventArgs e)
        {
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            Point e2 = new Point(e.X, e.Y);
            int invSetIndex = this.GetInvSetIndex(e2);
            string[] names = Enum.GetNames(eSetType.GetType());
            if (invSetIndex < this.myPower.SetTypes.Length & invSetIndex > -1)
            {
                this.lblInvSet.Text = names[(int)this.myPower.SetTypes[invSetIndex]];
            }
            else
            {
                this.lblInvSet.Text = "";
            }
        }


        void pbInvSetUsed_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxSet != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxSet.Bitmap, 0, 0);
            }
        }


        static bool PowerFullNameIsUnique(string iFullName, int skipId = -1)
        {
            if (!string.IsNullOrEmpty(iFullName))
            {
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (index != skipId)
                    {
                        IPower power = DatabaseAPI.Database.Power[index];
                        if (string.Equals(power.FullName, iFullName, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        void rbFlagX_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.FillAdvAtrList();
            }
        }


        void rbPrAdd_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("If this power is required to be present, click 'Yes'.\r\nIf this power must NOT be present, click 'No'.", MsgBoxStyle.YesNo, "Query") == MsgBoxResult.No)
            {
                this.myPower.Requires.PowerIDNot = (string[][])Utils.CopyArray(this.myPower.Requires.PowerIDNot, new string[this.myPower.Requires.PowerIDNot.Length + 1][]);
                string[] array = new string[2];
                this.myPower.Requires.PowerIDNot[this.myPower.Requires.PowerIDNot.Length - 1] = array;
                this.myPower.Requires.PowerIDNot[this.myPower.Requires.PowerIDNot.Length - 1][0] = "Empty";
                this.myPower.Requires.PowerIDNot[this.myPower.Requires.PowerIDNot.Length - 1][1] = "";
                this.FillTab_Req();
                this.lvPrListing.Items[this.lvPrListing.Items.Count - 1].Selected = true;
                this.lvPrListing.Items[this.lvPrListing.Items.Count - 1].EnsureVisible();
            }
            else
            {
                this.myPower.Requires.PowerID = (string[][])Utils.CopyArray(this.myPower.Requires.PowerID, new string[this.myPower.Requires.PowerID.Length + 1][]);
                string[] array = new string[2];
                this.myPower.Requires.PowerID[this.myPower.Requires.PowerID.Length - 1] = array;
                this.myPower.Requires.PowerID[this.myPower.Requires.PowerID.Length - 1][0] = "Empty";
                this.myPower.Requires.PowerID[this.myPower.Requires.PowerID.Length - 1][1] = "";
                this.FillTab_Req();
                this.lvPrListing.Items[this.myPower.Requires.PowerID.Length - 1].Selected = true;
                this.lvPrListing.Items[this.myPower.Requires.PowerID.Length - 1].EnsureVisible();
            }
        }


        void rbPrPowerX_CheckedChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == this.rbPrPowerB.GetType())
            {
                RadioButton radioButton = (RadioButton)sender;
                if (radioButton.Text == "Power B")
                {
                    return;
                }
            }
            if (this.rbPrPowerA.Checked)
            {
                this.btnPrSetNone.Text = "Set Power A to None";
            }
            else
            {
                this.btnPrSetNone.Text = "Set Power B to None";
            }
            this.Req_Listing_IndexChanged();
        }


        void rbPrRemove_Click(object sender, EventArgs e)
        {
            if (this.lvPrListing.SelectedItems.Count >= 1)
            {
                int num = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
                if (this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1)
                {
                    string[][] strArray = new string[this.myPower.Requires.PowerIDNot.Length - 1 + 1][];
                    int num2 = num;
                    int num3 = strArray.Length - 1;
                    for (int index2 = 0; index2 <= num3; index2++)
                    {
                        string[] strArray2 = new string[2];
                        strArray[index2] = strArray2;
                        strArray[index2][0] = this.myPower.Requires.PowerIDNot[index2][0];
                        strArray[index2][1] = this.myPower.Requires.PowerIDNot[index2][1];
                    }
                    this.myPower.Requires.PowerIDNot = new string[this.myPower.Requires.PowerIDNot.Length - 2 + 1][];
                    int index3 = 0;
                    int num4 = strArray.Length - 1;
                    for (int index2 = 0; index2 <= num4; index2++)
                    {
                        if (index2 != num2)
                        {
                            string[] strArray2 = new string[2];
                            this.myPower.Requires.PowerIDNot[index3] = strArray2;
                            this.myPower.Requires.PowerIDNot[index3][0] = strArray[index2][0];
                            this.myPower.Requires.PowerIDNot[index3][1] = strArray[index2][1];
                            index3++;
                        }
                    }
                }
                else
                {
                    string[][] strArray3 = new string[this.myPower.Requires.PowerID.Length - 1 + 1][];
                    int num5 = num;
                    int num6 = strArray3.Length - 1;
                    for (int index4 = 0; index4 <= num6; index4++)
                    {
                        string[] strArray2 = new string[2];
                        strArray3[index4] = strArray2;
                        strArray3[index4][0] = this.myPower.Requires.PowerID[index4][0];
                        strArray3[index4][1] = this.myPower.Requires.PowerID[index4][1];
                    }
                    this.myPower.Requires.PowerID = new string[this.myPower.Requires.PowerID.Length - 2 + 1][];
                    int index5 = 0;
                    int num7 = strArray3.Length - 1;
                    for (int index4 = 0; index4 <= num7; index4++)
                    {
                        if (index4 != num5)
                        {
                            this.myPower.Requires.PowerID[index5] = new string[2];
                            this.myPower.Requires.PowerID[index5][0] = strArray3[index4][0];
                            this.myPower.Requires.PowerID[index5][1] = strArray3[index4][1];
                            index5++;
                        }
                    }
                }
                this.FillTab_Req();
            }
        }


        void RedrawEnhList()
        {
            this.bxEnhPicked = new ExtendedBitmap(this.pbEnhancements.Width, this.pbEnhancements.Height);
            int enhPadding = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            this.bxEnhPicked.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxEnhPicked.ClipRect);
            this.bxEnhPicked.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, 255), 1f), 0, 0, this.bxEnhPicked.Size.Width - 1, this.bxEnhPicked.Size.Height - 1);
            int num = this.myPower.Enhancements.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding, 30, 30);
                this.bxEnhPicked.Graphics.DrawImage(I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(frmEditPower.GetClassByID(this.myPower.Enhancements[index])), GraphicsUnit.Pixel);
                enhPadding2 += 30 + this.enhPadding;
            }
            this.pbEnhancements.CreateGraphics().DrawImageUnscaled(this.bxEnhPicked.Bitmap, 0, 0);
        }


        void RedrawEnhPicker()
        {
            this.pbEnhancementList.Width = (this.enhPadding + 30) * this.enhAcross + this.enhPadding;
            this.pbEnhancementList.Height = (this.enhPadding + 30) * 6 + this.enhPadding;
            this.bxEnhPicker = new ExtendedBitmap(this.pbEnhancementList.Width, this.pbEnhancementList.Height);
            int enhPadding = this.enhPadding;
            int enhPadding2 = this.enhPadding;
            int num = 0;
            this.bxEnhPicker.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxEnhPicker.ClipRect);
            this.bxEnhPicker.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, 255), 1f), 0, 0, this.bxEnhPicker.Size.Width - 1, this.bxEnhPicker.Size.Height - 1);
            int num2 = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding, 30, 30);
                this.bxEnhPicker.Graphics.DrawImage(I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(index), GraphicsUnit.Pixel);
                enhPadding2 += 30 + this.enhPadding;
                num++;
                if (num == this.enhAcross)
                {
                    num = 0;
                    enhPadding2 = this.enhPadding;
                    enhPadding += 30 + this.enhPadding;
                }
            }
            this.pbEnhancementList.CreateGraphics().DrawImageUnscaled(this.bxEnhPicker.Bitmap, 0, 0);
        }


        void refresh_PowerData()
        {
            this.Text = "Edit Power (" + this.myPower.FullName + ")";
            this.lblStaticIndex.Text = Conversions.ToString(this.myPower.StaticIndex);
            this.FillCombo_Basic();
            this.FillTab_Basic();
            this.FillCombo_Attribs();
            this.FillTab_Attribs();
            this.FillTab_Effects();
            this.FillTab_Enhancements();
            this.FillTab_Sets();
            this.FillTab_Req();
            this.Filltab_ReqClasses();
            this.FillTab_Disabling();
            this.FillTab_Mutex();
            this.SetDynamics();
        }


        void RefreshFXData(int Index = 0)
        {
            IPower power = this.myPower;
            this.lvFX.BeginUpdate();
            this.lvFX.Items.Clear();
            int num = power.Effects.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                string item = power.Effects[index].BuildEffectString(false, "", false, false, true).Replace("\r\n", " - ");
                this.lvFX.Items.Add(item);
            }
            this.lvFX.EndUpdate();
            if (this.lvFX.Items.Count > Index)
            {
                this.lvFX.SelectedIndex = Index;
            }
            else
            {
                this.lvFX.SelectedIndex = this.lvFX.Items.Count - 1;
            }
        }


        void Req_GroupList()
        {
            this.lvPrGroup.BeginUpdate();
            this.lvPrGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.lvPrGroup.Items.Add(key);
            }
            this.lvPrGroup.EndUpdate();
        }


        void Req_Listing_IndexChanged()
        {
            if (this.lvPrListing.SelectedIndices.Count >= 1)
            {
                int index = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
                string iPower;
                if (this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1)
                {
                    if (this.rbPrPowerA.Checked)
                    {
                        iPower = this.myPower.Requires.PowerIDNot[index][0];
                    }
                    else
                    {
                        iPower = this.myPower.Requires.PowerIDNot[index][1];
                    }
                }
                else if (this.rbPrPowerA.Checked)
                {
                    iPower = this.myPower.Requires.PowerID[index][0];
                }
                else
                {
                    iPower = this.myPower.Requires.PowerID[index][1];
                }
                this.ReqDisplayPower(iPower);
            }
        }


        void Req_PowerList()
        {
            this.lvPrPower.BeginUpdate();
            this.lvPrPower.Items.Clear();
            if (this.lvPrSet.SelectedIndices.Count < 1)
            {
                this.lvPrPower.EndUpdate();
            }
            else
            {
                int index = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvPrSet.SelectedItems[0].Tag));
                if (index > -1)
                {
                    int num = DatabaseAPI.Database.Powersets[index].Powers.Length - 1;
                    for (int index2 = 0; index2 <= num; index2++)
                    {
                        if (!DatabaseAPI.Database.Powersets[index].Powers[index2].HiddenPower)
                        {
                            this.lvPrPower.Items.Add(DatabaseAPI.Database.Powersets[index].Powers[index2].PowerName);
                        }
                    }
                }
                this.lvPrPower.EndUpdate();
            }
        }


        void Req_SetList()
        {
            this.lvPrSet.BeginUpdate();
            this.lvPrSet.Items.Clear();
            if (this.lvPrGroup.SelectedIndices.Count < 1)
            {
                this.lvPrSet.EndUpdate();
            }
            else
            {
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvPrGroup.SelectedItems[0].Text);
                int num = indexesByGroupName.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.lvPrSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
                    this.lvPrSet.Items[this.lvPrSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
                }
                this.lvPrSet.EndUpdate();
            }
        }


        void Req_UpdateItem()
        {
            if (!(this.lvPrListing.SelectedIndices.Count < 1 | this.lvPrGroup.SelectedIndices.Count < 1 | this.lvPrSet.SelectedIndices.Count < 1 | this.lvPrPower.SelectedIndices.Count < 1))
            {
                string str = string.Concat(new string[]
                {
                    this.lvPrGroup.SelectedItems[0].Text,
                    ".",
                    this.lvPrSet.SelectedItems[0].Text,
                    ".",
                    this.lvPrPower.SelectedItems[0].Text
                });
                int index = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvPrListing.SelectedItems[0].Tag)));
                if (this.lvPrListing.SelectedIndices[0] > this.myPower.Requires.PowerID.Length - 1)
                {
                    if (this.rbPrPowerA.Checked)
                    {
                        this.myPower.Requires.PowerIDNot[index][0] = str;
                        this.lvPrListing.SelectedItems[0].SubItems[0].Text = "NOT " + str;
                    }
                    else
                    {
                        this.myPower.Requires.PowerIDNot[index][1] = str;
                        this.lvPrListing.SelectedItems[0].SubItems[2].Text = "NOT " + str;
                    }
                }
                else if (this.rbPrPowerA.Checked)
                {
                    this.myPower.Requires.PowerID[index][0] = str;
                    this.lvPrListing.SelectedItems[0].SubItems[0].Text = str;
                }
                else
                {
                    this.myPower.Requires.PowerID[index][1] = str;
                    this.lvPrListing.SelectedItems[0].SubItems[2].Text = str;
                }
            }
        }


        void ReqDisplayPower(string iPower)
        {
            this.ReqChanging = true;
            string[] strArray = iPower.Split(".".ToCharArray());
            if (strArray.Length > 0)
            {
                int num = this.lvPrGroup.Items.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (string.Equals(this.lvPrGroup.Items[index].Text, strArray[0], StringComparison.OrdinalIgnoreCase))
                    {
                        this.lvPrGroup.Items[index].Selected = true;
                        this.lvPrGroup.Items[index].EnsureVisible();
                        break;
                    }
                }
            }
            this.Req_SetList();
            if (strArray.Length > 1)
            {
                int num2 = this.lvPrSet.Items.Count - 1;
                for (int index = 0; index <= num2; index++)
                {
                    if (string.Equals(this.lvPrSet.Items[index].Text, strArray[1], StringComparison.OrdinalIgnoreCase))
                    {
                        this.lvPrSet.Items[index].Selected = true;
                        this.lvPrSet.Items[index].EnsureVisible();
                        break;
                    }
                }
            }
            this.Req_PowerList();
            if (strArray.Length > 2)
            {
                int num3 = this.lvPrPower.Items.Count - 1;
                for (int index = 0; index <= num3; index++)
                {
                    if (string.Equals(this.lvPrPower.Items[index].Text, strArray[2], StringComparison.OrdinalIgnoreCase))
                    {
                        this.lvPrPower.Items[index].Selected = true;
                        this.lvPrPower.Items[index].EnsureVisible();
                        break;
                    }
                }
            }
            this.ReqChanging = false;
        }


        void SetDynamics()
        {
            IPower power = this.myPower;
            this.chkBuffCycle.Enabled = (power.PowerType == Enums.ePowerType.Click);
            this.chkAlwaysToggle.Enabled = (power.PowerType == Enums.ePowerType.Toggle);
            if (power.ActivatePeriod > 0f & power.PowerType == Enums.ePowerType.Toggle)
            {
                this.lblEndCost.Text = "(" + Strings.Format(power.EndCost / power.ActivatePeriod, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##") + "/s)";
            }
            else
            {
                this.lblEndCost.Text = "";
            }
            this.lblAcc.Text = "(" + Strings.Format(power.Accuracy * MidsContext.Config.BaseAcc * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "#") + "%)";
        }


        void SetFullName()
        {
            IPower power = this.myPower;
            power.FullName = string.Concat(new string[]
            {
                power.GroupName,
                ".",
                power.SetName,
                ".",
                power.PowerName
            });
        }


        void SP_GroupList()
        {
            this.lvSPGroup.BeginUpdate();
            this.lvSPGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.lvSPGroup.Items.Add(key);
            }
            this.lvSPGroup.EndUpdate();
        }


        void SP_PowerList()
        {
            this.lvSPPower.BeginUpdate();
            this.lvSPPower.Items.Clear();
            if (this.lvSPSet.SelectedIndices.Count < 1)
            {
                this.lvSPPower.EndUpdate();
            }
            else
            {
                int index = DatabaseAPI.NidFromUidPowerset(Conversions.ToString(this.lvSPSet.SelectedItems[0].Tag));
                if (index > -1)
                {
                    int num = DatabaseAPI.Database.Powersets[index].Powers.Length - 1;
                    for (int index2 = 0; index2 <= num; index2++)
                    {
                        if (!DatabaseAPI.Database.Powersets[index].Powers[index2].HiddenPower)
                        {
                            this.lvSPPower.Items.Add(DatabaseAPI.Database.Powersets[index].Powers[index2].PowerName);
                            this.lvSPPower.Items[this.lvSPPower.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[index].Powers[index2].FullName;
                        }
                    }
                }
                this.lvSPPower.EndUpdate();
            }
        }


        void SP_SetList()
        {
            this.lvSPSet.BeginUpdate();
            this.lvSPSet.Items.Clear();
            if (this.lvSPGroup.SelectedIndices.Count < 1)
            {
                this.lvSPSet.EndUpdate();
            }
            else
            {
                int[] indexesByGroupName = DatabaseAPI.GetPowersetIndexesByGroupName(this.lvSPGroup.SelectedItems[0].Text);
                int num = indexesByGroupName.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.lvSPSet.Items.Add(DatabaseAPI.Database.Powersets[indexesByGroupName[index]].SetName);
                    this.lvSPSet.Items[this.lvSPSet.Items.Count - 1].Tag = DatabaseAPI.Database.Powersets[indexesByGroupName[index]].FullName;
                }
                this.lvSPSet.EndUpdate();
            }
        }


        void SPFillList()
        {
            this.lvSPSelected.BeginUpdate();
            this.lvSPSelected.Items.Clear();
            int num = this.myPower.UIDSubPower.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lvSPSelected.Items.Add(this.myPower.UIDSubPower[index]);
            }
            this.lvSPSelected.EndUpdate();
        }


        void Store_Req_Classes()
        {
            this.myPower.Requires.ClassName = new string[this.clbClassReq.CheckedIndices.Count - 1 + 1];
            int num = this.clbClassReq.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.myPower.Requires.ClassName[index] = DatabaseAPI.Database.Classes[this.clbClassReq.CheckedIndices[index]].ClassName;
            }
            this.myPower.Requires.ClassNameNot = new string[this.clbClassExclude.CheckedIndices.Count - 1 + 1];
            int num2 = this.clbClassExclude.CheckedIndices.Count - 1;
            for (int index = 0; index <= num2; index++)
            {
                this.myPower.Requires.ClassNameNot[index] = DatabaseAPI.Database.Classes[this.clbClassExclude.CheckedIndices[index]].ClassName;
            }
        }


        void txtAcc_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtAcc.Text = Conversions.ToString(power.Accuracy);
            }
        }


        void txtAcc_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtAcc.Text);
                if (num >= 0f & num <= 100f)
                {
                    power.Accuracy = num;
                }
            }
        }


        void txtActivate_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtActivate.Text = Conversions.ToString(power.ActivatePeriod);
            }
        }


        void txtActivate_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtActivate.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.ActivatePeriod = num;
                }
            }
        }


        void txtArc_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtArc.Text = Conversions.ToString(power.Arc);
            }
        }


        void txtArc_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtArc.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.Arc = (int)Math.Round((double)num);
                }
            }
        }


        void txtCastTime_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtCastTime.Text = Conversions.ToString(power.CastTimeReal);
            }
        }


        void txtCastTime_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtCastTime.Text);
                if (num >= 0f & num <= 100f)
                {
                    power.CastTimeReal = num;
                }
            }
        }


        void txtDescLong_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.DescLong = this.txtDescLong.Text;
            }
        }


        void txtDescShort_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.DescShort = this.txtDescShort.Text;
            }
        }


        void txtEndCost_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtEndCost.Text = Conversions.ToString(power.EndCost);
            }
        }


        void txtEndCost_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtEndCost.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.EndCost = num;
                }
            }
        }


        void txtInterrupt_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtInterrupt.Text = Conversions.ToString(power.InterruptTime);
            }
        }


        void txtInterrupt_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtInterrupt.Text);
                if (num >= 0f & num <= 100f)
                {
                    power.InterruptTime = num;
                }
            }
        }


        void txtLevel_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtLevel.Text = Conversions.ToString(power.Level);
            }
        }


        void txtLevel_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                int num = (int)Math.Round(Conversion.Val(this.txtLevel.Text));
                if (num >= 0 & num < 51)
                {
                    power.Level = num;
                }
            }
        }


        void txtLifeTimeGame_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtLifeTimeGame.Text = Conversions.ToString(power.LifeTimeInGame);
            }
        }


        void txtLifeTimeGame_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtLifeTimeGame.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    power.LifeTimeInGame = (int)Math.Round((double)num);
                }
            }
        }


        void txtLifeTimeReal_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtLifeTimeReal.Text = Conversions.ToString(power.LifeTime);
            }
        }


        void txtLifeTimeReal_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtLifeTimeReal.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    power.LifeTime = (int)Math.Round((double)num);
                }
            }
        }


        void txtMaxTargets_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtMaxTargets.Text = Conversions.ToString(power.MaxTargets);
            }
        }


        void txtMaxTargets_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtMaxTargets.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.MaxTargets = (int)Math.Round((double)num);
                }
            }
        }


        void txtNamePower_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.DisplayNameData();
            }
        }


        void txtNamePower_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.PowerName = this.txtNamePower.Text;
                this.SetFullName();
            }
        }


        void txtNumCharges_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtNumCharges.Text = Conversions.ToString(power.NumCharges);
            }
        }


        void txtNumCharges_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtNumCharges.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    power.NumCharges = (int)Math.Round((double)num);
                }
            }
        }


        void txtPowerName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.DisplayName = this.txtNameDisplay.Text;
            }
        }


        void txtRadius_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRadius.Text = Conversions.ToString(power.Radius);
            }
        }


        void txtRadius_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtRadius.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.Radius = (float)((int)Math.Round((double)num));
                }
            }
        }


        void txtRange_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRange.Text = Conversions.ToString(power.Range);
            }
        }


        void txtRange_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtRange.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    power.Range = num;
                }
            }
        }


        void txtRangeSec_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRangeSec.Text = Conversions.ToString(power.RangeSecondary);
            }
        }


        void txtRangeSec_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtRangeSec.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    power.RangeSecondary = num;
                }
            }
        }


        void txtRechargeTime_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRechargeTime.Text = Conversions.ToString(power.RechargeTime);
            }
        }


        void txtRechargeTime_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtRechargeTime.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.RechargeTime = num;
                }
            }
        }


        void txtScaleName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.VariableName = this.txtScaleName.Text;
            }
        }


        void txtUseageTime_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtUseageTime.Text = Conversions.ToString(power.UsageTime);
            }
        }


        void txtUseageTime_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtUseageTime.Text);
                if (num >= 0f & num < 2.147484E+09f)
                {
                    power.UsageTime = (int)Math.Round((double)num);
                }
            }
        }


        void txtVisualLocation_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtVisualLocation.Text = Conversions.ToString(power.DisplayLocation);
            }
        }


        void txtVisualLocation_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                float num = (float)Conversion.Val(this.txtVisualLocation.Text);
                if (num >= 0f & num <= 2.147484E+09f)
                {
                    power.DisplayLocation = (int)Math.Round((double)num);
                }
            }
        }


        void udScaleMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CheckScaleValues();
        }


        void udScaleMax_Leave(object sender, EventArgs e)
        {
            this.myPower.VariableMax = (int)Math.Round(Conversion.Val(this.udScaleMax.Text));
            this.CheckScaleValues();
        }


        void udScaleMax_ValueChanged(object sender, EventArgs e)
        {
            this.myPower.VariableMax = Convert.ToInt32(this.udScaleMax.Value);
            this.CheckScaleValues();
        }


        void udScaleMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CheckScaleValues();
        }


        void udScaleMin_Leave(object sender, EventArgs e)
        {
            this.myPower.VariableMin = (int)Math.Round(Conversion.Val(this.udScaleMin.Text));
            this.CheckScaleValues();
        }


        void udScaleMin_ValueChanged(object sender, EventArgs e)
        {
            this.myPower.VariableMin = Convert.ToInt32(this.udScaleMin.Value);
            this.CheckScaleValues();
        }


        [AccessedThroughProperty("btnCancel")]
        Button _btnCancel;


        [AccessedThroughProperty("btnCSVImport")]
        Button _btnCSVImport;


        [AccessedThroughProperty("btnFullCopy")]
        Button _btnFullCopy;


        [AccessedThroughProperty("btnFullPaste")]
        Button _btnFullPaste;


        [AccessedThroughProperty("btnFXAdd")]
        Button _btnFXAdd;


        [AccessedThroughProperty("btnFXDown")]
        Button _btnFXDown;


        [AccessedThroughProperty("btnFXDuplicate")]
        Button _btnFXDuplicate;


        [AccessedThroughProperty("btnFXEdit")]
        Button _btnFXEdit;


        [AccessedThroughProperty("btnFXRemove")]
        Button _btnFXRemove;


        [AccessedThroughProperty("btnFXUp")]
        Button _btnFXUp;


        [AccessedThroughProperty("btnMutexAdd")]
        Button _btnMutexAdd;


        [AccessedThroughProperty("btnOK")]
        Button _btnOK;


        [AccessedThroughProperty("btnPrDown")]
        Button _btnPrDown;


        [AccessedThroughProperty("btnPrReset")]
        Button _btnPrReset;


        [AccessedThroughProperty("btnPrSetNone")]
        Button _btnPrSetNone;


        [AccessedThroughProperty("btnPrUp")]
        Button _btnPrUp;


        [AccessedThroughProperty("btnSetDamage")]
        Button _btnSetDamage;


        [AccessedThroughProperty("btnSPAdd")]
        Button _btnSPAdd;


        [AccessedThroughProperty("btnSPRemove")]
        Button _btnSPRemove;


        [AccessedThroughProperty("cbEffectArea")]
        ComboBox _cbEffectArea;


        [AccessedThroughProperty("cbForcedClass")]
        ComboBox _cbForcedClass;


        [AccessedThroughProperty("cbNameGroup")]
        ComboBox _cbNameGroup;


        [AccessedThroughProperty("cbNameSet")]
        ComboBox _cbNameSet;


        [AccessedThroughProperty("cbNotify")]
        ComboBox _cbNotify;


        [AccessedThroughProperty("cbPowerType")]
        ComboBox _cbPowerType;


        [AccessedThroughProperty("chkAltSub")]
        CheckBox _chkAltSub;


        [AccessedThroughProperty("chkAlwaysToggle")]
        CheckBox _chkAlwaysToggle;


        [AccessedThroughProperty("chkBoostBoostable")]
        CheckBox _chkBoostBoostable;


        [AccessedThroughProperty("chkBoostUsePlayerLevel")]
        CheckBox _chkBoostUsePlayerLevel;


        [AccessedThroughProperty("chkBuffCycle")]
        CheckBox _chkBuffCycle;


        [AccessedThroughProperty("chkGraphFix")]
        CheckBox _chkGraphFix;


        [AccessedThroughProperty("chkHidden")]
        CheckBox _chkHidden;


        [AccessedThroughProperty("chkIgnoreStrength")]
        CheckBox _chkIgnoreStrength;


        [AccessedThroughProperty("chkLos")]
        CheckBox _chkLos;


        [AccessedThroughProperty("chkMutexAuto")]
        CheckBox _chkMutexAuto;


        [AccessedThroughProperty("chkMutexSkip")]
        CheckBox _chkMutexSkip;


        [AccessedThroughProperty("chkNoAUReq")]
        CheckBox _chkNoAUReq;


        [AccessedThroughProperty("chkNoAutoUpdate")]
        CheckBox _chkNoAutoUpdate;


        [AccessedThroughProperty("chkPRFrontLoad")]
        CheckBox _chkPRFrontLoad;


        [AccessedThroughProperty("chkScale")]
        CheckBox _chkScale;


        [AccessedThroughProperty("chkSortOverride")]
        CheckBox _chkSortOverride;


        [AccessedThroughProperty("chkSubInclude")]
        CheckBox _chkSubInclude;


        [AccessedThroughProperty("chkSummonDisplayEntity")]
        CheckBox _chkSummonDisplayEntity;


        [AccessedThroughProperty("chkSummonStealAttributes")]
        CheckBox _chkSummonStealAttributes;


        [AccessedThroughProperty("chkSummonStealEffects")]
        CheckBox _chkSummonStealEffects;


        [AccessedThroughProperty("clbClassExclude")]
        CheckedListBox _clbClassExclude;


        [AccessedThroughProperty("clbClassReq")]
        CheckedListBox _clbClassReq;


        [AccessedThroughProperty("clbFlags")]
        CheckedListBox _clbFlags;


        [AccessedThroughProperty("clbMutex")]
        CheckedListBox _clbMutex;


        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader10")]
        ColumnHeader _ColumnHeader10;


        [AccessedThroughProperty("ColumnHeader11")]
        ColumnHeader _ColumnHeader11;


        [AccessedThroughProperty("ColumnHeader2")]
        ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader6")]
        ColumnHeader _ColumnHeader6;


        [AccessedThroughProperty("ColumnHeader7")]
        ColumnHeader _ColumnHeader7;


        [AccessedThroughProperty("ColumnHeader8")]
        ColumnHeader _ColumnHeader8;


        [AccessedThroughProperty("ColumnHeader9")]
        ColumnHeader _ColumnHeader9;


        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox10")]
        GroupBox _GroupBox10;


        [AccessedThroughProperty("GroupBox11")]
        GroupBox _GroupBox11;


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


        [AccessedThroughProperty("Label17")]
        Label _Label17;


        [AccessedThroughProperty("Label18")]
        Label _Label18;


        [AccessedThroughProperty("Label2")]
        Label _Label2;


        [AccessedThroughProperty("Label20")]
        Label _Label20;


        [AccessedThroughProperty("Label21")]
        Label _Label21;


        [AccessedThroughProperty("Label22")]
        Label _Label22;


        [AccessedThroughProperty("Label23")]
        Label _Label23;


        [AccessedThroughProperty("Label24")]
        Label _Label24;


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


        [AccessedThroughProperty("Label35")]
        Label _Label35;


        [AccessedThroughProperty("Label36")]
        Label _Label36;


        [AccessedThroughProperty("Label37")]
        Label _Label37;


        [AccessedThroughProperty("Label38")]
        Label _Label38;


        [AccessedThroughProperty("Label39")]
        Label _Label39;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("Label40")]
        Label _Label40;


        [AccessedThroughProperty("Label41")]
        Label _Label41;


        [AccessedThroughProperty("Label42")]
        Label _Label42;


        [AccessedThroughProperty("Label43")]
        Label _Label43;


        [AccessedThroughProperty("Label44")]
        Label _Label44;


        [AccessedThroughProperty("Label45")]
        Label _Label45;


        [AccessedThroughProperty("Label46")]
        Label _Label46;


        [AccessedThroughProperty("Label47")]
        Label _Label47;


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


        [AccessedThroughProperty("lblAcc")]
        Label _lblAcc;


        [AccessedThroughProperty("lblEndCost")]
        Label _lblEndCost;


        [AccessedThroughProperty("lblEnhName")]
        Label _lblEnhName;


        [AccessedThroughProperty("lblInvSet")]
        Label _lblInvSet;


        [AccessedThroughProperty("lblNameFull")]
        Label _lblNameFull;


        [AccessedThroughProperty("lblNameUnique")]
        Label _lblNameUnique;


        [AccessedThroughProperty("lblStaticIndex")]
        Label _lblStaticIndex;


        [AccessedThroughProperty("lvDisablePass1")]
        ListBox _lvDisablePass1;


        [AccessedThroughProperty("lvDisablePass4")]
        ListBox _lvDisablePass4;


        [AccessedThroughProperty("lvFX")]
        ListBox _lvFX;


        [AccessedThroughProperty("lvPrGroup")]
        ListView _lvPrGroup;


        [AccessedThroughProperty("lvPrListing")]
        ListView _lvPrListing;


        [AccessedThroughProperty("lvPrPower")]
        ListView _lvPrPower;


        [AccessedThroughProperty("lvPrSet")]
        ListView _lvPrSet;


        [AccessedThroughProperty("lvSPGroup")]
        ListView _lvSPGroup;


        [AccessedThroughProperty("lvSPPower")]
        ListView _lvSPPower;


        [AccessedThroughProperty("lvSPSelected")]
        ListView _lvSPSelected;


        [AccessedThroughProperty("lvSPSet")]
        ListView _lvSPSet;


        [AccessedThroughProperty("pbEnhancementList")]
        PictureBox _pbEnhancementList;


        [AccessedThroughProperty("pbEnhancements")]
        PictureBox _pbEnhancements;


        [AccessedThroughProperty("pbInvSetList")]
        PictureBox _pbInvSetList;


        [AccessedThroughProperty("pbInvSetUsed")]
        PictureBox _pbInvSetUsed;


        [AccessedThroughProperty("pnlFX")]
        Panel _pnlFX;


        [AccessedThroughProperty("rbFlagAffected")]
        RadioButton _rbFlagAffected;


        [AccessedThroughProperty("rbFlagAutoHit")]
        RadioButton _rbFlagAutoHit;


        [AccessedThroughProperty("rbFlagCast")]
        RadioButton _rbFlagCast;


        [AccessedThroughProperty("rbFlagCastThrough")]
        RadioButton _rbFlagCastThrough;


        [AccessedThroughProperty("rbFlagDisallow")]
        RadioButton _rbFlagDisallow;


        [AccessedThroughProperty("rbFlagRequired")]
        RadioButton _rbFlagRequired;


        [AccessedThroughProperty("rbFlagTargets")]
        RadioButton _rbFlagTargets;


        [AccessedThroughProperty("rbFlagTargetsSec")]
        RadioButton _rbFlagTargetsSec;


        [AccessedThroughProperty("rbFlagVector")]
        RadioButton _rbFlagVector;


        [AccessedThroughProperty("rbPrAdd")]
        Button _rbPrAdd;


        [AccessedThroughProperty("rbPrPowerA")]
        RadioButton _rbPrPowerA;


        [AccessedThroughProperty("rbPrPowerB")]
        RadioButton _rbPrPowerB;


        [AccessedThroughProperty("rbPrRemove")]
        Button _rbPrRemove;


        [AccessedThroughProperty("tcPower")]
        TabControl _tcPower;


        [AccessedThroughProperty("tpBasic")]
        TabPage _tpBasic;


        [AccessedThroughProperty("tpEffects")]
        TabPage _tpEffects;


        [AccessedThroughProperty("tpEnh")]
        TabPage _tpEnh;


        [AccessedThroughProperty("tpMutex")]
        TabPage _tpMutex;


        [AccessedThroughProperty("tpPreReq")]
        TabPage _tpPreReq;


        [AccessedThroughProperty("tpSets")]
        TabPage _tpSets;


        [AccessedThroughProperty("tpSpecialEnh")]
        TabPage _tpSpecialEnh;


        [AccessedThroughProperty("tpSubPower")]
        TabPage _tpSubPower;


        [AccessedThroughProperty("tpText")]
        TabPage _tpText;


        [AccessedThroughProperty("txtAcc")]
        TextBox _txtAcc;


        [AccessedThroughProperty("txtActivate")]
        TextBox _txtActivate;


        [AccessedThroughProperty("txtArc")]
        TextBox _txtArc;


        [AccessedThroughProperty("txtCastTime")]
        TextBox _txtCastTime;


        [AccessedThroughProperty("txtDescLong")]
        TextBox _txtDescLong;


        [AccessedThroughProperty("txtDescShort")]
        TextBox _txtDescShort;


        [AccessedThroughProperty("txtEndCost")]
        TextBox _txtEndCost;


        [AccessedThroughProperty("txtInterrupt")]
        TextBox _txtInterrupt;


        [AccessedThroughProperty("txtLevel")]
        TextBox _txtLevel;


        [AccessedThroughProperty("txtLifeTimeGame")]
        TextBox _txtLifeTimeGame;


        [AccessedThroughProperty("txtLifeTimeReal")]
        TextBox _txtLifeTimeReal;


        [AccessedThroughProperty("txtMaxTargets")]
        TextBox _txtMaxTargets;


        [AccessedThroughProperty("txtNameDisplay")]
        TextBox _txtNameDisplay;


        [AccessedThroughProperty("txtNamePower")]
        TextBox _txtNamePower;


        [AccessedThroughProperty("txtNumCharges")]
        TextBox _txtNumCharges;


        [AccessedThroughProperty("txtRadius")]
        TextBox _txtRadius;


        [AccessedThroughProperty("txtRange")]
        TextBox _txtRange;


        [AccessedThroughProperty("txtRangeSec")]
        TextBox _txtRangeSec;


        [AccessedThroughProperty("txtRechargeTime")]
        TextBox _txtRechargeTime;


        [AccessedThroughProperty("txtScaleName")]
        TextBox _txtScaleName;


        [AccessedThroughProperty("txtUseageTime")]
        TextBox _txtUseageTime;


        [AccessedThroughProperty("txtVisualLocation")]
        TextBox _txtVisualLocation;


        [AccessedThroughProperty("udScaleMax")]
        NumericUpDown _udScaleMax;


        [AccessedThroughProperty("udScaleMin")]
        NumericUpDown _udScaleMin;


        protected Requirement backup_Requires;


        ExtendedBitmap bxEnhPicked;


        ExtendedBitmap bxEnhPicker;


        protected ExtendedBitmap bxSet;


        protected ExtendedBitmap bxSetList;


        protected int enhAcross;


        protected int enhPadding;


        public IPower myPower;


        protected bool ReqChanging;


        protected bool Updating;
    }
}
