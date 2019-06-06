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
    // Token: 0x0200002D RID: 45
    public partial class frmEditPower : Form
    {
        // Token: 0x170001DF RID: 479
        // (get) Token: 0x060005AC RID: 1452 RVA: 0x00044A70 File Offset: 0x00042C70
        // (set) Token: 0x060005AD RID: 1453 RVA: 0x00044A88 File Offset: 0x00042C88
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

        // Token: 0x170001E0 RID: 480
        // (get) Token: 0x060005AE RID: 1454 RVA: 0x00044AE4 File Offset: 0x00042CE4
        // (set) Token: 0x060005AF RID: 1455 RVA: 0x00044AFC File Offset: 0x00042CFC
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

        // Token: 0x170001E1 RID: 481
        // (get) Token: 0x060005B0 RID: 1456 RVA: 0x00044B58 File Offset: 0x00042D58
        // (set) Token: 0x060005B1 RID: 1457 RVA: 0x00044B70 File Offset: 0x00042D70
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

        // Token: 0x170001E2 RID: 482
        // (get) Token: 0x060005B2 RID: 1458 RVA: 0x00044BCC File Offset: 0x00042DCC
        // (set) Token: 0x060005B3 RID: 1459 RVA: 0x00044BE4 File Offset: 0x00042DE4
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

        // Token: 0x170001E3 RID: 483
        // (get) Token: 0x060005B4 RID: 1460 RVA: 0x00044C40 File Offset: 0x00042E40
        // (set) Token: 0x060005B5 RID: 1461 RVA: 0x00044C58 File Offset: 0x00042E58
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

        // Token: 0x170001E4 RID: 484
        // (get) Token: 0x060005B6 RID: 1462 RVA: 0x00044CB4 File Offset: 0x00042EB4
        // (set) Token: 0x060005B7 RID: 1463 RVA: 0x00044CCC File Offset: 0x00042ECC
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

        // Token: 0x170001E5 RID: 485
        // (get) Token: 0x060005B8 RID: 1464 RVA: 0x00044D28 File Offset: 0x00042F28
        // (set) Token: 0x060005B9 RID: 1465 RVA: 0x00044D40 File Offset: 0x00042F40
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

        // Token: 0x170001E6 RID: 486
        // (get) Token: 0x060005BA RID: 1466 RVA: 0x00044D9C File Offset: 0x00042F9C
        // (set) Token: 0x060005BB RID: 1467 RVA: 0x00044DB4 File Offset: 0x00042FB4
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

        // Token: 0x170001E7 RID: 487
        // (get) Token: 0x060005BC RID: 1468 RVA: 0x00044E10 File Offset: 0x00043010
        // (set) Token: 0x060005BD RID: 1469 RVA: 0x00044E28 File Offset: 0x00043028
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

        // Token: 0x170001E8 RID: 488
        // (get) Token: 0x060005BE RID: 1470 RVA: 0x00044E84 File Offset: 0x00043084
        // (set) Token: 0x060005BF RID: 1471 RVA: 0x00044E9C File Offset: 0x0004309C
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

        // Token: 0x170001E9 RID: 489
        // (get) Token: 0x060005C0 RID: 1472 RVA: 0x00044EF8 File Offset: 0x000430F8
        // (set) Token: 0x060005C1 RID: 1473 RVA: 0x00044F10 File Offset: 0x00043110
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

        // Token: 0x170001EA RID: 490
        // (get) Token: 0x060005C2 RID: 1474 RVA: 0x00044F6C File Offset: 0x0004316C
        // (set) Token: 0x060005C3 RID: 1475 RVA: 0x00044F84 File Offset: 0x00043184
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

        // Token: 0x170001EB RID: 491
        // (get) Token: 0x060005C4 RID: 1476 RVA: 0x00044FE0 File Offset: 0x000431E0
        // (set) Token: 0x060005C5 RID: 1477 RVA: 0x00044FF8 File Offset: 0x000431F8
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

        // Token: 0x170001EC RID: 492
        // (get) Token: 0x060005C6 RID: 1478 RVA: 0x00045054 File Offset: 0x00043254
        // (set) Token: 0x060005C7 RID: 1479 RVA: 0x0004506C File Offset: 0x0004326C
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

        // Token: 0x170001ED RID: 493
        // (get) Token: 0x060005C8 RID: 1480 RVA: 0x000450C8 File Offset: 0x000432C8
        // (set) Token: 0x060005C9 RID: 1481 RVA: 0x000450E0 File Offset: 0x000432E0
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

        // Token: 0x170001EE RID: 494
        // (get) Token: 0x060005CA RID: 1482 RVA: 0x0004513C File Offset: 0x0004333C
        // (set) Token: 0x060005CB RID: 1483 RVA: 0x00045154 File Offset: 0x00043354
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

        // Token: 0x170001EF RID: 495
        // (get) Token: 0x060005CC RID: 1484 RVA: 0x000451B0 File Offset: 0x000433B0
        // (set) Token: 0x060005CD RID: 1485 RVA: 0x000451C8 File Offset: 0x000433C8
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

        // Token: 0x170001F0 RID: 496
        // (get) Token: 0x060005CE RID: 1486 RVA: 0x000451D4 File Offset: 0x000433D4
        // (set) Token: 0x060005CF RID: 1487 RVA: 0x000451EC File Offset: 0x000433EC
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

        // Token: 0x170001F1 RID: 497
        // (get) Token: 0x060005D0 RID: 1488 RVA: 0x00045248 File Offset: 0x00043448
        // (set) Token: 0x060005D1 RID: 1489 RVA: 0x00045260 File Offset: 0x00043460
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

        // Token: 0x170001F2 RID: 498
        // (get) Token: 0x060005D2 RID: 1490 RVA: 0x000452BC File Offset: 0x000434BC
        // (set) Token: 0x060005D3 RID: 1491 RVA: 0x000452D4 File Offset: 0x000434D4
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

        // Token: 0x170001F3 RID: 499
        // (get) Token: 0x060005D4 RID: 1492 RVA: 0x00045330 File Offset: 0x00043530
        // (set) Token: 0x060005D5 RID: 1493 RVA: 0x00045348 File Offset: 0x00043548
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

        // Token: 0x170001F4 RID: 500
        // (get) Token: 0x060005D6 RID: 1494 RVA: 0x000453A4 File Offset: 0x000435A4
        // (set) Token: 0x060005D7 RID: 1495 RVA: 0x000453BC File Offset: 0x000435BC
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

        // Token: 0x170001F5 RID: 501
        // (get) Token: 0x060005D8 RID: 1496 RVA: 0x00045464 File Offset: 0x00043664
        // (set) Token: 0x060005D9 RID: 1497 RVA: 0x0004547C File Offset: 0x0004367C
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

        // Token: 0x170001F6 RID: 502
        // (get) Token: 0x060005DA RID: 1498 RVA: 0x00045524 File Offset: 0x00043724
        // (set) Token: 0x060005DB RID: 1499 RVA: 0x0004553C File Offset: 0x0004373C
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

        // Token: 0x170001F7 RID: 503
        // (get) Token: 0x060005DC RID: 1500 RVA: 0x00045598 File Offset: 0x00043798
        // (set) Token: 0x060005DD RID: 1501 RVA: 0x000455B0 File Offset: 0x000437B0
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

        // Token: 0x170001F8 RID: 504
        // (get) Token: 0x060005DE RID: 1502 RVA: 0x0004560C File Offset: 0x0004380C
        // (set) Token: 0x060005DF RID: 1503 RVA: 0x00045624 File Offset: 0x00043824
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

        // Token: 0x170001F9 RID: 505
        // (get) Token: 0x060005E0 RID: 1504 RVA: 0x00045680 File Offset: 0x00043880
        // (set) Token: 0x060005E1 RID: 1505 RVA: 0x00045698 File Offset: 0x00043898
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

        // Token: 0x170001FA RID: 506
        // (get) Token: 0x060005E2 RID: 1506 RVA: 0x000456F4 File Offset: 0x000438F4
        // (set) Token: 0x060005E3 RID: 1507 RVA: 0x0004570C File Offset: 0x0004390C
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

        // Token: 0x170001FB RID: 507
        // (get) Token: 0x060005E4 RID: 1508 RVA: 0x00045768 File Offset: 0x00043968
        // (set) Token: 0x060005E5 RID: 1509 RVA: 0x00045780 File Offset: 0x00043980
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

        // Token: 0x170001FC RID: 508
        // (get) Token: 0x060005E6 RID: 1510 RVA: 0x000457DC File Offset: 0x000439DC
        // (set) Token: 0x060005E7 RID: 1511 RVA: 0x000457F4 File Offset: 0x000439F4
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

        // Token: 0x170001FD RID: 509
        // (get) Token: 0x060005E8 RID: 1512 RVA: 0x00045850 File Offset: 0x00043A50
        // (set) Token: 0x060005E9 RID: 1513 RVA: 0x00045868 File Offset: 0x00043A68
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

        // Token: 0x170001FE RID: 510
        // (get) Token: 0x060005EA RID: 1514 RVA: 0x000458C4 File Offset: 0x00043AC4
        // (set) Token: 0x060005EB RID: 1515 RVA: 0x000458DC File Offset: 0x00043ADC
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

        // Token: 0x170001FF RID: 511
        // (get) Token: 0x060005EC RID: 1516 RVA: 0x00045938 File Offset: 0x00043B38
        // (set) Token: 0x060005ED RID: 1517 RVA: 0x00045950 File Offset: 0x00043B50
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

        // Token: 0x17000200 RID: 512
        // (get) Token: 0x060005EE RID: 1518 RVA: 0x000459AC File Offset: 0x00043BAC
        // (set) Token: 0x060005EF RID: 1519 RVA: 0x000459C4 File Offset: 0x00043BC4
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

        // Token: 0x17000201 RID: 513
        // (get) Token: 0x060005F0 RID: 1520 RVA: 0x00045A20 File Offset: 0x00043C20
        // (set) Token: 0x060005F1 RID: 1521 RVA: 0x00045A38 File Offset: 0x00043C38
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

        // Token: 0x17000202 RID: 514
        // (get) Token: 0x060005F2 RID: 1522 RVA: 0x00045A94 File Offset: 0x00043C94
        // (set) Token: 0x060005F3 RID: 1523 RVA: 0x00045AAC File Offset: 0x00043CAC
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

        // Token: 0x17000203 RID: 515
        // (get) Token: 0x060005F4 RID: 1524 RVA: 0x00045B08 File Offset: 0x00043D08
        // (set) Token: 0x060005F5 RID: 1525 RVA: 0x00045B20 File Offset: 0x00043D20
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

        // Token: 0x17000204 RID: 516
        // (get) Token: 0x060005F6 RID: 1526 RVA: 0x00045B7C File Offset: 0x00043D7C
        // (set) Token: 0x060005F7 RID: 1527 RVA: 0x00045B94 File Offset: 0x00043D94
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

        // Token: 0x17000205 RID: 517
        // (get) Token: 0x060005F8 RID: 1528 RVA: 0x00045BF0 File Offset: 0x00043DF0
        // (set) Token: 0x060005F9 RID: 1529 RVA: 0x00045C08 File Offset: 0x00043E08
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

        // Token: 0x17000206 RID: 518
        // (get) Token: 0x060005FA RID: 1530 RVA: 0x00045C64 File Offset: 0x00043E64
        // (set) Token: 0x060005FB RID: 1531 RVA: 0x00045C7C File Offset: 0x00043E7C
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

        // Token: 0x17000207 RID: 519
        // (get) Token: 0x060005FC RID: 1532 RVA: 0x00045CD8 File Offset: 0x00043ED8
        // (set) Token: 0x060005FD RID: 1533 RVA: 0x00045CF0 File Offset: 0x00043EF0
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

        // Token: 0x17000208 RID: 520
        // (get) Token: 0x060005FE RID: 1534 RVA: 0x00045D4C File Offset: 0x00043F4C
        // (set) Token: 0x060005FF RID: 1535 RVA: 0x00045D64 File Offset: 0x00043F64
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

        // Token: 0x17000209 RID: 521
        // (get) Token: 0x06000600 RID: 1536 RVA: 0x00045DC0 File Offset: 0x00043FC0
        // (set) Token: 0x06000601 RID: 1537 RVA: 0x00045DD8 File Offset: 0x00043FD8
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

        // Token: 0x1700020A RID: 522
        // (get) Token: 0x06000602 RID: 1538 RVA: 0x00045E34 File Offset: 0x00044034
        // (set) Token: 0x06000603 RID: 1539 RVA: 0x00045E4C File Offset: 0x0004404C
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

        // Token: 0x1700020B RID: 523
        // (get) Token: 0x06000604 RID: 1540 RVA: 0x00045EA8 File Offset: 0x000440A8
        // (set) Token: 0x06000605 RID: 1541 RVA: 0x00045EC0 File Offset: 0x000440C0
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

        // Token: 0x1700020C RID: 524
        // (get) Token: 0x06000606 RID: 1542 RVA: 0x00045F1C File Offset: 0x0004411C
        // (set) Token: 0x06000607 RID: 1543 RVA: 0x00045F34 File Offset: 0x00044134
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

        // Token: 0x1700020D RID: 525
        // (get) Token: 0x06000608 RID: 1544 RVA: 0x00045F40 File Offset: 0x00044140
        // (set) Token: 0x06000609 RID: 1545 RVA: 0x00045F58 File Offset: 0x00044158
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

        // Token: 0x1700020E RID: 526
        // (get) Token: 0x0600060A RID: 1546 RVA: 0x00045F64 File Offset: 0x00044164
        // (set) Token: 0x0600060B RID: 1547 RVA: 0x00045F7C File Offset: 0x0004417C
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

        // Token: 0x1700020F RID: 527
        // (get) Token: 0x0600060C RID: 1548 RVA: 0x00045FD8 File Offset: 0x000441D8
        // (set) Token: 0x0600060D RID: 1549 RVA: 0x00045FF0 File Offset: 0x000441F0
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

        // Token: 0x17000210 RID: 528
        // (get) Token: 0x0600060E RID: 1550 RVA: 0x00045FFC File Offset: 0x000441FC
        // (set) Token: 0x0600060F RID: 1551 RVA: 0x00046014 File Offset: 0x00044214
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

        // Token: 0x17000211 RID: 529
        // (get) Token: 0x06000610 RID: 1552 RVA: 0x00046020 File Offset: 0x00044220
        // (set) Token: 0x06000611 RID: 1553 RVA: 0x00046038 File Offset: 0x00044238
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

        // Token: 0x17000212 RID: 530
        // (get) Token: 0x06000612 RID: 1554 RVA: 0x00046044 File Offset: 0x00044244
        // (set) Token: 0x06000613 RID: 1555 RVA: 0x0004605C File Offset: 0x0004425C
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

        // Token: 0x17000213 RID: 531
        // (get) Token: 0x06000614 RID: 1556 RVA: 0x00046068 File Offset: 0x00044268
        // (set) Token: 0x06000615 RID: 1557 RVA: 0x00046080 File Offset: 0x00044280
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

        // Token: 0x17000214 RID: 532
        // (get) Token: 0x06000616 RID: 1558 RVA: 0x0004608C File Offset: 0x0004428C
        // (set) Token: 0x06000617 RID: 1559 RVA: 0x000460A4 File Offset: 0x000442A4
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

        // Token: 0x17000215 RID: 533
        // (get) Token: 0x06000618 RID: 1560 RVA: 0x000460B0 File Offset: 0x000442B0
        // (set) Token: 0x06000619 RID: 1561 RVA: 0x000460C8 File Offset: 0x000442C8
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

        // Token: 0x17000216 RID: 534
        // (get) Token: 0x0600061A RID: 1562 RVA: 0x000460D4 File Offset: 0x000442D4
        // (set) Token: 0x0600061B RID: 1563 RVA: 0x000460EC File Offset: 0x000442EC
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

        // Token: 0x17000217 RID: 535
        // (get) Token: 0x0600061C RID: 1564 RVA: 0x000460F8 File Offset: 0x000442F8
        // (set) Token: 0x0600061D RID: 1565 RVA: 0x00046110 File Offset: 0x00044310
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

        // Token: 0x17000218 RID: 536
        // (get) Token: 0x0600061E RID: 1566 RVA: 0x0004611C File Offset: 0x0004431C
        // (set) Token: 0x0600061F RID: 1567 RVA: 0x00046134 File Offset: 0x00044334
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

        // Token: 0x17000219 RID: 537
        // (get) Token: 0x06000620 RID: 1568 RVA: 0x00046140 File Offset: 0x00044340
        // (set) Token: 0x06000621 RID: 1569 RVA: 0x00046158 File Offset: 0x00044358
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

        // Token: 0x1700021A RID: 538
        // (get) Token: 0x06000622 RID: 1570 RVA: 0x00046164 File Offset: 0x00044364
        // (set) Token: 0x06000623 RID: 1571 RVA: 0x0004617C File Offset: 0x0004437C
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

        // Token: 0x1700021B RID: 539
        // (get) Token: 0x06000624 RID: 1572 RVA: 0x00046188 File Offset: 0x00044388
        // (set) Token: 0x06000625 RID: 1573 RVA: 0x000461A0 File Offset: 0x000443A0
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

        // Token: 0x1700021C RID: 540
        // (get) Token: 0x06000626 RID: 1574 RVA: 0x000461AC File Offset: 0x000443AC
        // (set) Token: 0x06000627 RID: 1575 RVA: 0x000461C4 File Offset: 0x000443C4
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

        // Token: 0x1700021D RID: 541
        // (get) Token: 0x06000628 RID: 1576 RVA: 0x000461D0 File Offset: 0x000443D0
        // (set) Token: 0x06000629 RID: 1577 RVA: 0x000461E8 File Offset: 0x000443E8
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

        // Token: 0x1700021E RID: 542
        // (get) Token: 0x0600062A RID: 1578 RVA: 0x000461F4 File Offset: 0x000443F4
        // (set) Token: 0x0600062B RID: 1579 RVA: 0x0004620C File Offset: 0x0004440C
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

        // Token: 0x1700021F RID: 543
        // (get) Token: 0x0600062C RID: 1580 RVA: 0x00046218 File Offset: 0x00044418
        // (set) Token: 0x0600062D RID: 1581 RVA: 0x00046230 File Offset: 0x00044430
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

        // Token: 0x17000220 RID: 544
        // (get) Token: 0x0600062E RID: 1582 RVA: 0x0004623C File Offset: 0x0004443C
        // (set) Token: 0x0600062F RID: 1583 RVA: 0x00046254 File Offset: 0x00044454
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

        // Token: 0x17000221 RID: 545
        // (get) Token: 0x06000630 RID: 1584 RVA: 0x00046260 File Offset: 0x00044460
        // (set) Token: 0x06000631 RID: 1585 RVA: 0x00046278 File Offset: 0x00044478
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

        // Token: 0x17000222 RID: 546
        // (get) Token: 0x06000632 RID: 1586 RVA: 0x00046284 File Offset: 0x00044484
        // (set) Token: 0x06000633 RID: 1587 RVA: 0x0004629C File Offset: 0x0004449C
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

        // Token: 0x17000223 RID: 547
        // (get) Token: 0x06000634 RID: 1588 RVA: 0x000462A8 File Offset: 0x000444A8
        // (set) Token: 0x06000635 RID: 1589 RVA: 0x000462C0 File Offset: 0x000444C0
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

        // Token: 0x17000224 RID: 548
        // (get) Token: 0x06000636 RID: 1590 RVA: 0x000462CC File Offset: 0x000444CC
        // (set) Token: 0x06000637 RID: 1591 RVA: 0x000462E4 File Offset: 0x000444E4
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

        // Token: 0x17000225 RID: 549
        // (get) Token: 0x06000638 RID: 1592 RVA: 0x000462F0 File Offset: 0x000444F0
        // (set) Token: 0x06000639 RID: 1593 RVA: 0x00046308 File Offset: 0x00044508
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

        // Token: 0x17000226 RID: 550
        // (get) Token: 0x0600063A RID: 1594 RVA: 0x00046314 File Offset: 0x00044514
        // (set) Token: 0x0600063B RID: 1595 RVA: 0x0004632C File Offset: 0x0004452C
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

        // Token: 0x17000227 RID: 551
        // (get) Token: 0x0600063C RID: 1596 RVA: 0x00046338 File Offset: 0x00044538
        // (set) Token: 0x0600063D RID: 1597 RVA: 0x00046350 File Offset: 0x00044550
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

        // Token: 0x17000228 RID: 552
        // (get) Token: 0x0600063E RID: 1598 RVA: 0x0004635C File Offset: 0x0004455C
        // (set) Token: 0x0600063F RID: 1599 RVA: 0x00046374 File Offset: 0x00044574
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

        // Token: 0x17000229 RID: 553
        // (get) Token: 0x06000640 RID: 1600 RVA: 0x00046380 File Offset: 0x00044580
        // (set) Token: 0x06000641 RID: 1601 RVA: 0x00046398 File Offset: 0x00044598
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

        // Token: 0x1700022A RID: 554
        // (get) Token: 0x06000642 RID: 1602 RVA: 0x000463A4 File Offset: 0x000445A4
        // (set) Token: 0x06000643 RID: 1603 RVA: 0x000463BC File Offset: 0x000445BC
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

        // Token: 0x1700022B RID: 555
        // (get) Token: 0x06000644 RID: 1604 RVA: 0x000463C8 File Offset: 0x000445C8
        // (set) Token: 0x06000645 RID: 1605 RVA: 0x000463E0 File Offset: 0x000445E0
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

        // Token: 0x1700022C RID: 556
        // (get) Token: 0x06000646 RID: 1606 RVA: 0x000463EC File Offset: 0x000445EC
        // (set) Token: 0x06000647 RID: 1607 RVA: 0x00046404 File Offset: 0x00044604
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

        // Token: 0x1700022D RID: 557
        // (get) Token: 0x06000648 RID: 1608 RVA: 0x00046410 File Offset: 0x00044610
        // (set) Token: 0x06000649 RID: 1609 RVA: 0x00046428 File Offset: 0x00044628
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

        // Token: 0x1700022E RID: 558
        // (get) Token: 0x0600064A RID: 1610 RVA: 0x00046434 File Offset: 0x00044634
        // (set) Token: 0x0600064B RID: 1611 RVA: 0x0004644C File Offset: 0x0004464C
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

        // Token: 0x1700022F RID: 559
        // (get) Token: 0x0600064C RID: 1612 RVA: 0x00046458 File Offset: 0x00044658
        // (set) Token: 0x0600064D RID: 1613 RVA: 0x00046470 File Offset: 0x00044670
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

        // Token: 0x17000230 RID: 560
        // (get) Token: 0x0600064E RID: 1614 RVA: 0x0004647C File Offset: 0x0004467C
        // (set) Token: 0x0600064F RID: 1615 RVA: 0x00046494 File Offset: 0x00044694
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

        // Token: 0x17000231 RID: 561
        // (get) Token: 0x06000650 RID: 1616 RVA: 0x000464A0 File Offset: 0x000446A0
        // (set) Token: 0x06000651 RID: 1617 RVA: 0x000464B8 File Offset: 0x000446B8
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

        // Token: 0x17000232 RID: 562
        // (get) Token: 0x06000652 RID: 1618 RVA: 0x000464C4 File Offset: 0x000446C4
        // (set) Token: 0x06000653 RID: 1619 RVA: 0x000464DC File Offset: 0x000446DC
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

        // Token: 0x17000233 RID: 563
        // (get) Token: 0x06000654 RID: 1620 RVA: 0x000464E8 File Offset: 0x000446E8
        // (set) Token: 0x06000655 RID: 1621 RVA: 0x00046500 File Offset: 0x00044700
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

        // Token: 0x17000234 RID: 564
        // (get) Token: 0x06000656 RID: 1622 RVA: 0x0004650C File Offset: 0x0004470C
        // (set) Token: 0x06000657 RID: 1623 RVA: 0x00046524 File Offset: 0x00044724
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

        // Token: 0x17000235 RID: 565
        // (get) Token: 0x06000658 RID: 1624 RVA: 0x00046530 File Offset: 0x00044730
        // (set) Token: 0x06000659 RID: 1625 RVA: 0x00046548 File Offset: 0x00044748
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

        // Token: 0x17000236 RID: 566
        // (get) Token: 0x0600065A RID: 1626 RVA: 0x00046554 File Offset: 0x00044754
        // (set) Token: 0x0600065B RID: 1627 RVA: 0x0004656C File Offset: 0x0004476C
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

        // Token: 0x17000237 RID: 567
        // (get) Token: 0x0600065C RID: 1628 RVA: 0x00046578 File Offset: 0x00044778
        // (set) Token: 0x0600065D RID: 1629 RVA: 0x00046590 File Offset: 0x00044790
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

        // Token: 0x17000238 RID: 568
        // (get) Token: 0x0600065E RID: 1630 RVA: 0x0004659C File Offset: 0x0004479C
        // (set) Token: 0x0600065F RID: 1631 RVA: 0x000465B4 File Offset: 0x000447B4
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

        // Token: 0x17000239 RID: 569
        // (get) Token: 0x06000660 RID: 1632 RVA: 0x000465C0 File Offset: 0x000447C0
        // (set) Token: 0x06000661 RID: 1633 RVA: 0x000465D8 File Offset: 0x000447D8
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

        // Token: 0x1700023A RID: 570
        // (get) Token: 0x06000662 RID: 1634 RVA: 0x000465E4 File Offset: 0x000447E4
        // (set) Token: 0x06000663 RID: 1635 RVA: 0x000465FC File Offset: 0x000447FC
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

        // Token: 0x1700023B RID: 571
        // (get) Token: 0x06000664 RID: 1636 RVA: 0x00046608 File Offset: 0x00044808
        // (set) Token: 0x06000665 RID: 1637 RVA: 0x00046620 File Offset: 0x00044820
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

        // Token: 0x1700023C RID: 572
        // (get) Token: 0x06000666 RID: 1638 RVA: 0x0004662C File Offset: 0x0004482C
        // (set) Token: 0x06000667 RID: 1639 RVA: 0x00046644 File Offset: 0x00044844
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

        // Token: 0x1700023D RID: 573
        // (get) Token: 0x06000668 RID: 1640 RVA: 0x00046650 File Offset: 0x00044850
        // (set) Token: 0x06000669 RID: 1641 RVA: 0x00046668 File Offset: 0x00044868
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

        // Token: 0x1700023E RID: 574
        // (get) Token: 0x0600066A RID: 1642 RVA: 0x00046674 File Offset: 0x00044874
        // (set) Token: 0x0600066B RID: 1643 RVA: 0x0004668C File Offset: 0x0004488C
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

        // Token: 0x1700023F RID: 575
        // (get) Token: 0x0600066C RID: 1644 RVA: 0x00046698 File Offset: 0x00044898
        // (set) Token: 0x0600066D RID: 1645 RVA: 0x000466B0 File Offset: 0x000448B0
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

        // Token: 0x17000240 RID: 576
        // (get) Token: 0x0600066E RID: 1646 RVA: 0x000466BC File Offset: 0x000448BC
        // (set) Token: 0x0600066F RID: 1647 RVA: 0x000466D4 File Offset: 0x000448D4
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

        // Token: 0x17000241 RID: 577
        // (get) Token: 0x06000670 RID: 1648 RVA: 0x000466E0 File Offset: 0x000448E0
        // (set) Token: 0x06000671 RID: 1649 RVA: 0x000466F8 File Offset: 0x000448F8
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

        // Token: 0x17000242 RID: 578
        // (get) Token: 0x06000672 RID: 1650 RVA: 0x00046704 File Offset: 0x00044904
        // (set) Token: 0x06000673 RID: 1651 RVA: 0x0004671C File Offset: 0x0004491C
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

        // Token: 0x17000243 RID: 579
        // (get) Token: 0x06000674 RID: 1652 RVA: 0x00046728 File Offset: 0x00044928
        // (set) Token: 0x06000675 RID: 1653 RVA: 0x00046740 File Offset: 0x00044940
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

        // Token: 0x17000244 RID: 580
        // (get) Token: 0x06000676 RID: 1654 RVA: 0x0004674C File Offset: 0x0004494C
        // (set) Token: 0x06000677 RID: 1655 RVA: 0x00046764 File Offset: 0x00044964
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

        // Token: 0x17000245 RID: 581
        // (get) Token: 0x06000678 RID: 1656 RVA: 0x00046770 File Offset: 0x00044970
        // (set) Token: 0x06000679 RID: 1657 RVA: 0x00046788 File Offset: 0x00044988
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

        // Token: 0x17000246 RID: 582
        // (get) Token: 0x0600067A RID: 1658 RVA: 0x00046794 File Offset: 0x00044994
        // (set) Token: 0x0600067B RID: 1659 RVA: 0x000467AC File Offset: 0x000449AC
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

        // Token: 0x17000247 RID: 583
        // (get) Token: 0x0600067C RID: 1660 RVA: 0x000467B8 File Offset: 0x000449B8
        // (set) Token: 0x0600067D RID: 1661 RVA: 0x000467D0 File Offset: 0x000449D0
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

        // Token: 0x17000248 RID: 584
        // (get) Token: 0x0600067E RID: 1662 RVA: 0x000467DC File Offset: 0x000449DC
        // (set) Token: 0x0600067F RID: 1663 RVA: 0x000467F4 File Offset: 0x000449F4
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

        // Token: 0x17000249 RID: 585
        // (get) Token: 0x06000680 RID: 1664 RVA: 0x00046800 File Offset: 0x00044A00
        // (set) Token: 0x06000681 RID: 1665 RVA: 0x00046818 File Offset: 0x00044A18
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

        // Token: 0x1700024A RID: 586
        // (get) Token: 0x06000682 RID: 1666 RVA: 0x00046824 File Offset: 0x00044A24
        // (set) Token: 0x06000683 RID: 1667 RVA: 0x0004683C File Offset: 0x00044A3C
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

        // Token: 0x1700024B RID: 587
        // (get) Token: 0x06000684 RID: 1668 RVA: 0x00046848 File Offset: 0x00044A48
        // (set) Token: 0x06000685 RID: 1669 RVA: 0x00046860 File Offset: 0x00044A60
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

        // Token: 0x1700024C RID: 588
        // (get) Token: 0x06000686 RID: 1670 RVA: 0x0004686C File Offset: 0x00044A6C
        // (set) Token: 0x06000687 RID: 1671 RVA: 0x00046884 File Offset: 0x00044A84
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

        // Token: 0x1700024D RID: 589
        // (get) Token: 0x06000688 RID: 1672 RVA: 0x00046890 File Offset: 0x00044A90
        // (set) Token: 0x06000689 RID: 1673 RVA: 0x000468A8 File Offset: 0x00044AA8
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

        // Token: 0x1700024E RID: 590
        // (get) Token: 0x0600068A RID: 1674 RVA: 0x000468B4 File Offset: 0x00044AB4
        // (set) Token: 0x0600068B RID: 1675 RVA: 0x000468CC File Offset: 0x00044ACC
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

        // Token: 0x1700024F RID: 591
        // (get) Token: 0x0600068C RID: 1676 RVA: 0x000468D8 File Offset: 0x00044AD8
        // (set) Token: 0x0600068D RID: 1677 RVA: 0x000468F0 File Offset: 0x00044AF0
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

        // Token: 0x17000250 RID: 592
        // (get) Token: 0x0600068E RID: 1678 RVA: 0x000468FC File Offset: 0x00044AFC
        // (set) Token: 0x0600068F RID: 1679 RVA: 0x00046914 File Offset: 0x00044B14
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

        // Token: 0x17000251 RID: 593
        // (get) Token: 0x06000690 RID: 1680 RVA: 0x00046920 File Offset: 0x00044B20
        // (set) Token: 0x06000691 RID: 1681 RVA: 0x00046938 File Offset: 0x00044B38
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

        // Token: 0x17000252 RID: 594
        // (get) Token: 0x06000692 RID: 1682 RVA: 0x00046944 File Offset: 0x00044B44
        // (set) Token: 0x06000693 RID: 1683 RVA: 0x0004695C File Offset: 0x00044B5C
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

        // Token: 0x17000253 RID: 595
        // (get) Token: 0x06000694 RID: 1684 RVA: 0x00046968 File Offset: 0x00044B68
        // (set) Token: 0x06000695 RID: 1685 RVA: 0x00046980 File Offset: 0x00044B80
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

        // Token: 0x17000254 RID: 596
        // (get) Token: 0x06000696 RID: 1686 RVA: 0x0004698C File Offset: 0x00044B8C
        // (set) Token: 0x06000697 RID: 1687 RVA: 0x000469A4 File Offset: 0x00044BA4
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

        // Token: 0x17000255 RID: 597
        // (get) Token: 0x06000698 RID: 1688 RVA: 0x000469B0 File Offset: 0x00044BB0
        // (set) Token: 0x06000699 RID: 1689 RVA: 0x000469C8 File Offset: 0x00044BC8
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

        // Token: 0x17000256 RID: 598
        // (get) Token: 0x0600069A RID: 1690 RVA: 0x000469D4 File Offset: 0x00044BD4
        // (set) Token: 0x0600069B RID: 1691 RVA: 0x000469EC File Offset: 0x00044BEC
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

        // Token: 0x17000257 RID: 599
        // (get) Token: 0x0600069C RID: 1692 RVA: 0x000469F8 File Offset: 0x00044BF8
        // (set) Token: 0x0600069D RID: 1693 RVA: 0x00046A10 File Offset: 0x00044C10
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

        // Token: 0x17000258 RID: 600
        // (get) Token: 0x0600069E RID: 1694 RVA: 0x00046A1C File Offset: 0x00044C1C
        // (set) Token: 0x0600069F RID: 1695 RVA: 0x00046A34 File Offset: 0x00044C34
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

        // Token: 0x17000259 RID: 601
        // (get) Token: 0x060006A0 RID: 1696 RVA: 0x00046A90 File Offset: 0x00044C90
        // (set) Token: 0x060006A1 RID: 1697 RVA: 0x00046AA8 File Offset: 0x00044CA8
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

        // Token: 0x1700025A RID: 602
        // (get) Token: 0x060006A2 RID: 1698 RVA: 0x00046B04 File Offset: 0x00044D04
        // (set) Token: 0x060006A3 RID: 1699 RVA: 0x00046B1C File Offset: 0x00044D1C
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

        // Token: 0x1700025B RID: 603
        // (get) Token: 0x060006A4 RID: 1700 RVA: 0x00046B78 File Offset: 0x00044D78
        // (set) Token: 0x060006A5 RID: 1701 RVA: 0x00046B90 File Offset: 0x00044D90
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

        // Token: 0x1700025C RID: 604
        // (get) Token: 0x060006A6 RID: 1702 RVA: 0x00046C14 File Offset: 0x00044E14
        // (set) Token: 0x060006A7 RID: 1703 RVA: 0x00046C2C File Offset: 0x00044E2C
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

        // Token: 0x1700025D RID: 605
        // (get) Token: 0x060006A8 RID: 1704 RVA: 0x00046C88 File Offset: 0x00044E88
        // (set) Token: 0x060006A9 RID: 1705 RVA: 0x00046CA0 File Offset: 0x00044EA0
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

        // Token: 0x1700025E RID: 606
        // (get) Token: 0x060006AA RID: 1706 RVA: 0x00046CFC File Offset: 0x00044EFC
        // (set) Token: 0x060006AB RID: 1707 RVA: 0x00046D14 File Offset: 0x00044F14
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

        // Token: 0x1700025F RID: 607
        // (get) Token: 0x060006AC RID: 1708 RVA: 0x00046D70 File Offset: 0x00044F70
        // (set) Token: 0x060006AD RID: 1709 RVA: 0x00046D88 File Offset: 0x00044F88
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

        // Token: 0x17000260 RID: 608
        // (get) Token: 0x060006AE RID: 1710 RVA: 0x00046DE4 File Offset: 0x00044FE4
        // (set) Token: 0x060006AF RID: 1711 RVA: 0x00046DFC File Offset: 0x00044FFC
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

        // Token: 0x17000261 RID: 609
        // (get) Token: 0x060006B0 RID: 1712 RVA: 0x00046E58 File Offset: 0x00045058
        // (set) Token: 0x060006B1 RID: 1713 RVA: 0x00046E70 File Offset: 0x00045070
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

        // Token: 0x17000262 RID: 610
        // (get) Token: 0x060006B2 RID: 1714 RVA: 0x00046ECC File Offset: 0x000450CC
        // (set) Token: 0x060006B3 RID: 1715 RVA: 0x00046EE4 File Offset: 0x000450E4
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

        // Token: 0x17000263 RID: 611
        // (get) Token: 0x060006B4 RID: 1716 RVA: 0x00046EF0 File Offset: 0x000450F0
        // (set) Token: 0x060006B5 RID: 1717 RVA: 0x00046F08 File Offset: 0x00045108
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

        // Token: 0x17000264 RID: 612
        // (get) Token: 0x060006B6 RID: 1718 RVA: 0x00046F64 File Offset: 0x00045164
        // (set) Token: 0x060006B7 RID: 1719 RVA: 0x00046F7C File Offset: 0x0004517C
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

        // Token: 0x17000265 RID: 613
        // (get) Token: 0x060006B8 RID: 1720 RVA: 0x00047024 File Offset: 0x00045224
        // (set) Token: 0x060006B9 RID: 1721 RVA: 0x0004703C File Offset: 0x0004523C
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

        // Token: 0x17000266 RID: 614
        // (get) Token: 0x060006BA RID: 1722 RVA: 0x000470E4 File Offset: 0x000452E4
        // (set) Token: 0x060006BB RID: 1723 RVA: 0x000470FC File Offset: 0x000452FC
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

        // Token: 0x17000267 RID: 615
        // (get) Token: 0x060006BC RID: 1724 RVA: 0x000471A4 File Offset: 0x000453A4
        // (set) Token: 0x060006BD RID: 1725 RVA: 0x000471BC File Offset: 0x000453BC
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

        // Token: 0x17000268 RID: 616
        // (get) Token: 0x060006BE RID: 1726 RVA: 0x00047264 File Offset: 0x00045464
        // (set) Token: 0x060006BF RID: 1727 RVA: 0x0004727C File Offset: 0x0004547C
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

        // Token: 0x17000269 RID: 617
        // (get) Token: 0x060006C0 RID: 1728 RVA: 0x00047288 File Offset: 0x00045488
        // (set) Token: 0x060006C1 RID: 1729 RVA: 0x000472A0 File Offset: 0x000454A0
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

        // Token: 0x1700026A RID: 618
        // (get) Token: 0x060006C2 RID: 1730 RVA: 0x000472FC File Offset: 0x000454FC
        // (set) Token: 0x060006C3 RID: 1731 RVA: 0x00047314 File Offset: 0x00045514
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

        // Token: 0x1700026B RID: 619
        // (get) Token: 0x060006C4 RID: 1732 RVA: 0x00047370 File Offset: 0x00045570
        // (set) Token: 0x060006C5 RID: 1733 RVA: 0x00047388 File Offset: 0x00045588
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

        // Token: 0x1700026C RID: 620
        // (get) Token: 0x060006C6 RID: 1734 RVA: 0x000473E4 File Offset: 0x000455E4
        // (set) Token: 0x060006C7 RID: 1735 RVA: 0x000473FC File Offset: 0x000455FC
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

        // Token: 0x1700026D RID: 621
        // (get) Token: 0x060006C8 RID: 1736 RVA: 0x00047458 File Offset: 0x00045658
        // (set) Token: 0x060006C9 RID: 1737 RVA: 0x00047470 File Offset: 0x00045670
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

        // Token: 0x1700026E RID: 622
        // (get) Token: 0x060006CA RID: 1738 RVA: 0x000474CC File Offset: 0x000456CC
        // (set) Token: 0x060006CB RID: 1739 RVA: 0x000474E4 File Offset: 0x000456E4
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

        // Token: 0x1700026F RID: 623
        // (get) Token: 0x060006CC RID: 1740 RVA: 0x00047540 File Offset: 0x00045740
        // (set) Token: 0x060006CD RID: 1741 RVA: 0x00047558 File Offset: 0x00045758
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

        // Token: 0x17000270 RID: 624
        // (get) Token: 0x060006CE RID: 1742 RVA: 0x000475B4 File Offset: 0x000457B4
        // (set) Token: 0x060006CF RID: 1743 RVA: 0x000475CC File Offset: 0x000457CC
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

        // Token: 0x17000271 RID: 625
        // (get) Token: 0x060006D0 RID: 1744 RVA: 0x00047628 File Offset: 0x00045828
        // (set) Token: 0x060006D1 RID: 1745 RVA: 0x00047640 File Offset: 0x00045840
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

        // Token: 0x17000272 RID: 626
        // (get) Token: 0x060006D2 RID: 1746 RVA: 0x0004769C File Offset: 0x0004589C
        // (set) Token: 0x060006D3 RID: 1747 RVA: 0x000476B4 File Offset: 0x000458B4
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

        // Token: 0x17000273 RID: 627
        // (get) Token: 0x060006D4 RID: 1748 RVA: 0x00047710 File Offset: 0x00045910
        // (set) Token: 0x060006D5 RID: 1749 RVA: 0x00047728 File Offset: 0x00045928
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

        // Token: 0x17000274 RID: 628
        // (get) Token: 0x060006D6 RID: 1750 RVA: 0x00047784 File Offset: 0x00045984
        // (set) Token: 0x060006D7 RID: 1751 RVA: 0x0004779C File Offset: 0x0004599C
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

        // Token: 0x17000275 RID: 629
        // (get) Token: 0x060006D8 RID: 1752 RVA: 0x000477F8 File Offset: 0x000459F8
        // (set) Token: 0x060006D9 RID: 1753 RVA: 0x00047810 File Offset: 0x00045A10
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

        // Token: 0x17000276 RID: 630
        // (get) Token: 0x060006DA RID: 1754 RVA: 0x0004786C File Offset: 0x00045A6C
        // (set) Token: 0x060006DB RID: 1755 RVA: 0x00047884 File Offset: 0x00045A84
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

        // Token: 0x17000277 RID: 631
        // (get) Token: 0x060006DC RID: 1756 RVA: 0x00047890 File Offset: 0x00045A90
        // (set) Token: 0x060006DD RID: 1757 RVA: 0x000478A8 File Offset: 0x00045AA8
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

        // Token: 0x17000278 RID: 632
        // (get) Token: 0x060006DE RID: 1758 RVA: 0x000478B4 File Offset: 0x00045AB4
        // (set) Token: 0x060006DF RID: 1759 RVA: 0x000478CC File Offset: 0x00045ACC
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

        // Token: 0x17000279 RID: 633
        // (get) Token: 0x060006E0 RID: 1760 RVA: 0x000478D8 File Offset: 0x00045AD8
        // (set) Token: 0x060006E1 RID: 1761 RVA: 0x000478F0 File Offset: 0x00045AF0
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

        // Token: 0x1700027A RID: 634
        // (get) Token: 0x060006E2 RID: 1762 RVA: 0x000478FC File Offset: 0x00045AFC
        // (set) Token: 0x060006E3 RID: 1763 RVA: 0x00047914 File Offset: 0x00045B14
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

        // Token: 0x1700027B RID: 635
        // (get) Token: 0x060006E4 RID: 1764 RVA: 0x00047920 File Offset: 0x00045B20
        // (set) Token: 0x060006E5 RID: 1765 RVA: 0x00047938 File Offset: 0x00045B38
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

        // Token: 0x1700027C RID: 636
        // (get) Token: 0x060006E6 RID: 1766 RVA: 0x00047944 File Offset: 0x00045B44
        // (set) Token: 0x060006E7 RID: 1767 RVA: 0x0004795C File Offset: 0x00045B5C
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

        // Token: 0x1700027D RID: 637
        // (get) Token: 0x060006E8 RID: 1768 RVA: 0x00047968 File Offset: 0x00045B68
        // (set) Token: 0x060006E9 RID: 1769 RVA: 0x00047980 File Offset: 0x00045B80
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

        // Token: 0x1700027E RID: 638
        // (get) Token: 0x060006EA RID: 1770 RVA: 0x0004798C File Offset: 0x00045B8C
        // (set) Token: 0x060006EB RID: 1771 RVA: 0x000479A4 File Offset: 0x00045BA4
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

        // Token: 0x1700027F RID: 639
        // (get) Token: 0x060006EC RID: 1772 RVA: 0x000479B0 File Offset: 0x00045BB0
        // (set) Token: 0x060006ED RID: 1773 RVA: 0x000479C8 File Offset: 0x00045BC8
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

        // Token: 0x17000280 RID: 640
        // (get) Token: 0x060006EE RID: 1774 RVA: 0x000479D4 File Offset: 0x00045BD4
        // (set) Token: 0x060006EF RID: 1775 RVA: 0x000479EC File Offset: 0x00045BEC
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

        // Token: 0x17000281 RID: 641
        // (get) Token: 0x060006F0 RID: 1776 RVA: 0x00047A70 File Offset: 0x00045C70
        // (set) Token: 0x060006F1 RID: 1777 RVA: 0x00047A88 File Offset: 0x00045C88
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

        // Token: 0x17000282 RID: 642
        // (get) Token: 0x060006F2 RID: 1778 RVA: 0x00047B0C File Offset: 0x00045D0C
        // (set) Token: 0x060006F3 RID: 1779 RVA: 0x00047B24 File Offset: 0x00045D24
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

        // Token: 0x17000283 RID: 643
        // (get) Token: 0x060006F4 RID: 1780 RVA: 0x00047BA8 File Offset: 0x00045DA8
        // (set) Token: 0x060006F5 RID: 1781 RVA: 0x00047BC0 File Offset: 0x00045DC0
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

        // Token: 0x17000284 RID: 644
        // (get) Token: 0x060006F6 RID: 1782 RVA: 0x00047C44 File Offset: 0x00045E44
        // (set) Token: 0x060006F7 RID: 1783 RVA: 0x00047C5C File Offset: 0x00045E5C
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

        // Token: 0x17000285 RID: 645
        // (get) Token: 0x060006F8 RID: 1784 RVA: 0x00047CB8 File Offset: 0x00045EB8
        // (set) Token: 0x060006F9 RID: 1785 RVA: 0x00047CD0 File Offset: 0x00045ED0
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

        // Token: 0x17000286 RID: 646
        // (get) Token: 0x060006FA RID: 1786 RVA: 0x00047D2C File Offset: 0x00045F2C
        // (set) Token: 0x060006FB RID: 1787 RVA: 0x00047D44 File Offset: 0x00045F44
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

        // Token: 0x17000287 RID: 647
        // (get) Token: 0x060006FC RID: 1788 RVA: 0x00047DC8 File Offset: 0x00045FC8
        // (set) Token: 0x060006FD RID: 1789 RVA: 0x00047DE0 File Offset: 0x00045FE0
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

        // Token: 0x17000288 RID: 648
        // (get) Token: 0x060006FE RID: 1790 RVA: 0x00047E64 File Offset: 0x00046064
        // (set) Token: 0x060006FF RID: 1791 RVA: 0x00047E7C File Offset: 0x0004607C
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

        // Token: 0x17000289 RID: 649
        // (get) Token: 0x06000700 RID: 1792 RVA: 0x00047F00 File Offset: 0x00046100
        // (set) Token: 0x06000701 RID: 1793 RVA: 0x00047F18 File Offset: 0x00046118
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

        // Token: 0x1700028A RID: 650
        // (get) Token: 0x06000702 RID: 1794 RVA: 0x00047F9C File Offset: 0x0004619C
        // (set) Token: 0x06000703 RID: 1795 RVA: 0x00047FB4 File Offset: 0x000461B4
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

        // Token: 0x1700028B RID: 651
        // (get) Token: 0x06000704 RID: 1796 RVA: 0x00048038 File Offset: 0x00046238
        // (set) Token: 0x06000705 RID: 1797 RVA: 0x00048050 File Offset: 0x00046250
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

        // Token: 0x1700028C RID: 652
        // (get) Token: 0x06000706 RID: 1798 RVA: 0x000480D4 File Offset: 0x000462D4
        // (set) Token: 0x06000707 RID: 1799 RVA: 0x000480EC File Offset: 0x000462EC
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

        // Token: 0x1700028D RID: 653
        // (get) Token: 0x06000708 RID: 1800 RVA: 0x00048148 File Offset: 0x00046348
        // (set) Token: 0x06000709 RID: 1801 RVA: 0x00048160 File Offset: 0x00046360
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

        // Token: 0x1700028E RID: 654
        // (get) Token: 0x0600070A RID: 1802 RVA: 0x000481E4 File Offset: 0x000463E4
        // (set) Token: 0x0600070B RID: 1803 RVA: 0x000481FC File Offset: 0x000463FC
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

        // Token: 0x1700028F RID: 655
        // (get) Token: 0x0600070C RID: 1804 RVA: 0x00048280 File Offset: 0x00046480
        // (set) Token: 0x0600070D RID: 1805 RVA: 0x00048298 File Offset: 0x00046498
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

        // Token: 0x17000290 RID: 656
        // (get) Token: 0x0600070E RID: 1806 RVA: 0x0004831C File Offset: 0x0004651C
        // (set) Token: 0x0600070F RID: 1807 RVA: 0x00048334 File Offset: 0x00046534
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

        // Token: 0x17000291 RID: 657
        // (get) Token: 0x06000710 RID: 1808 RVA: 0x000483B8 File Offset: 0x000465B8
        // (set) Token: 0x06000711 RID: 1809 RVA: 0x000483D0 File Offset: 0x000465D0
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

        // Token: 0x17000292 RID: 658
        // (get) Token: 0x06000712 RID: 1810 RVA: 0x00048454 File Offset: 0x00046654
        // (set) Token: 0x06000713 RID: 1811 RVA: 0x0004846C File Offset: 0x0004666C
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

        // Token: 0x17000293 RID: 659
        // (get) Token: 0x06000714 RID: 1812 RVA: 0x000484F0 File Offset: 0x000466F0
        // (set) Token: 0x06000715 RID: 1813 RVA: 0x00048508 File Offset: 0x00046708
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

        // Token: 0x17000294 RID: 660
        // (get) Token: 0x06000716 RID: 1814 RVA: 0x00048564 File Offset: 0x00046764
        // (set) Token: 0x06000717 RID: 1815 RVA: 0x0004857C File Offset: 0x0004677C
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

        // Token: 0x17000295 RID: 661
        // (get) Token: 0x06000718 RID: 1816 RVA: 0x00048600 File Offset: 0x00046800
        // (set) Token: 0x06000719 RID: 1817 RVA: 0x00048618 File Offset: 0x00046818
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

        // Token: 0x17000296 RID: 662
        // (get) Token: 0x0600071A RID: 1818 RVA: 0x0004869C File Offset: 0x0004689C
        // (set) Token: 0x0600071B RID: 1819 RVA: 0x000486B4 File Offset: 0x000468B4
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

        // Token: 0x17000297 RID: 663
        // (get) Token: 0x0600071C RID: 1820 RVA: 0x0004875C File Offset: 0x0004695C
        // (set) Token: 0x0600071D RID: 1821 RVA: 0x00048774 File Offset: 0x00046974
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

        // Token: 0x0600071E RID: 1822 RVA: 0x0004881C File Offset: 0x00046A1C
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

        // Token: 0x0600071F RID: 1823 RVA: 0x0004888B File Offset: 0x00046A8B
        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }

        // Token: 0x06000720 RID: 1824 RVA: 0x000488A0 File Offset: 0x00046AA0
        private void btnCSVImport_Click(object sender, EventArgs e)
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

        // Token: 0x06000721 RID: 1825 RVA: 0x00048924 File Offset: 0x00046B24
        private void btnFullCopy_Click(object sender, EventArgs e)
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

        // Token: 0x06000722 RID: 1826 RVA: 0x00048980 File Offset: 0x00046B80
        private void btnFullPaste_Click(object sender, EventArgs e)
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

        // Token: 0x06000723 RID: 1827 RVA: 0x00048A48 File Offset: 0x00046C48
        private void btnFXAdd_Click(object sender, EventArgs e)
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

        // Token: 0x06000724 RID: 1828 RVA: 0x00048AF4 File Offset: 0x00046CF4
        private void btnFXDown_Click(object sender, EventArgs e)
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

        // Token: 0x06000725 RID: 1829 RVA: 0x00048BDC File Offset: 0x00046DDC
        private void btnFXDuplicate_Click(object sender, EventArgs e)
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

        // Token: 0x06000726 RID: 1830 RVA: 0x00048CCC File Offset: 0x00046ECC
        private void btnFXEdit_Click(object sender, EventArgs e)
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

        // Token: 0x06000727 RID: 1831 RVA: 0x00048D6C File Offset: 0x00046F6C
        private void btnFXRemove_Click(object sender, EventArgs e)
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

        // Token: 0x06000728 RID: 1832 RVA: 0x00048EB8 File Offset: 0x000470B8
        private void btnFXUp_Click(object sender, EventArgs e)
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

        // Token: 0x06000729 RID: 1833 RVA: 0x00048F90 File Offset: 0x00047190
        private void btnMutexAdd_Click(object sender, EventArgs e)
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

        // Token: 0x0600072A RID: 1834 RVA: 0x0004905C File Offset: 0x0004725C
        private void btnOK_Click(object sender, EventArgs e)
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

        // Token: 0x0600072B RID: 1835 RVA: 0x000492FC File Offset: 0x000474FC
        private void btnPrDown_Click(object sender, EventArgs e)
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

        // Token: 0x0600072C RID: 1836 RVA: 0x000495ED File Offset: 0x000477ED
        private void btnPrReset_Click(object sender, EventArgs e)
        {
            this.myPower.Requires = new Requirement(this.backup_Requires);
            this.FillTab_Req();
        }

        // Token: 0x0600072D RID: 1837 RVA: 0x00049610 File Offset: 0x00047810
        private void btnPrSetNone_Click(object sender, EventArgs e)
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

        // Token: 0x0600072E RID: 1838 RVA: 0x00049740 File Offset: 0x00047940
        private void btnPrUp_Click(object sender, EventArgs e)
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

        // Token: 0x0600072F RID: 1839 RVA: 0x000499F4 File Offset: 0x00047BF4
        private void btnSPAdd_Click(object sender, EventArgs e)
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

        // Token: 0x06000730 RID: 1840 RVA: 0x00049B30 File Offset: 0x00047D30
        private void btnSPRemove_Click(object sender, EventArgs e)
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

        // Token: 0x06000731 RID: 1841 RVA: 0x00049CDC File Offset: 0x00047EDC
        private void cbEffectArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.EffectArea = (Enums.eEffectArea)this.cbEffectArea.SelectedIndex;
            }
        }

        // Token: 0x06000732 RID: 1842 RVA: 0x00049D10 File Offset: 0x00047F10
        private void cbForcedClass_SelectedIndexChanged(object sender, EventArgs e)
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

        // Token: 0x06000733 RID: 1843 RVA: 0x00049D8C File Offset: 0x00047F8C
        private void cbNameGroup_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.DisplayNameData();
            }
        }

        // Token: 0x06000734 RID: 1844 RVA: 0x00049DB0 File Offset: 0x00047FB0
        private void cbNameGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.GroupName = this.cbNameGroup.Text;
                this.SetFullName();
            }
        }

        // Token: 0x06000735 RID: 1845 RVA: 0x00049DE8 File Offset: 0x00047FE8
        private void cbNameGroup_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.GroupName = this.cbNameGroup.Text;
                this.SetFullName();
            }
        }

        // Token: 0x06000736 RID: 1846 RVA: 0x00049E20 File Offset: 0x00048020
        private void cbNameSet_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.DisplayNameData();
            }
        }

        // Token: 0x06000737 RID: 1847 RVA: 0x00049E44 File Offset: 0x00048044
        private void cbNameSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SetName = this.cbNameSet.Text;
                this.SetFullName();
            }
        }

        // Token: 0x06000738 RID: 1848 RVA: 0x00049E7C File Offset: 0x0004807C
        private void cbNameSet_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SetName = this.cbNameSet.Text;
                this.SetFullName();
            }
        }

        // Token: 0x06000739 RID: 1849 RVA: 0x00049EB4 File Offset: 0x000480B4
        private void cbNotify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AIReport = (Enums.eNotify)this.cbNotify.SelectedIndex;
            }
        }

        // Token: 0x0600073A RID: 1850 RVA: 0x00049EE8 File Offset: 0x000480E8
        private void cbPowerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.PowerType = (Enums.ePowerType)this.cbPowerType.SelectedIndex;
            }
        }

        // Token: 0x0600073B RID: 1851 RVA: 0x00049F1C File Offset: 0x0004811C
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

        // Token: 0x0600073C RID: 1852 RVA: 0x00049F9C File Offset: 0x0004819C
        private void chkAltSub_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SubIsAltColour = this.chkAltSub.Checked;
            }
        }

        // Token: 0x0600073D RID: 1853 RVA: 0x00049FD0 File Offset: 0x000481D0
        private void chkAlwaysToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AlwaysToggle = this.chkAlwaysToggle.Checked;
            }
        }

        // Token: 0x0600073E RID: 1854 RVA: 0x0004A004 File Offset: 0x00048204
        private void chkBoostBoostable_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.BoostBoostable = this.chkPRFrontLoad.Checked;
            }
        }

        // Token: 0x0600073F RID: 1855 RVA: 0x0004A038 File Offset: 0x00048238
        private void chkBoostUsePlayerLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.BoostUsePlayerLevel = this.chkPRFrontLoad.Checked;
            }
        }

        // Token: 0x06000740 RID: 1856 RVA: 0x0004A06C File Offset: 0x0004826C
        private void chkBuffCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.ClickBuff = this.chkBuffCycle.Checked;
            }
        }

        // Token: 0x06000741 RID: 1857 RVA: 0x0004A0A0 File Offset: 0x000482A0
        private void chkGraphFix_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SkipMax = this.chkGraphFix.Checked;
            }
        }

        // Token: 0x06000742 RID: 1858 RVA: 0x0004A0D4 File Offset: 0x000482D4
        private void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.HiddenPower = this.chkHidden.Checked;
            }
        }

        // Token: 0x06000743 RID: 1859 RVA: 0x0004A108 File Offset: 0x00048308
        private void chkIgnoreStrength_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.IgnoreStrength = this.chkIgnoreStrength.Checked;
            }
        }

        // Token: 0x06000744 RID: 1860 RVA: 0x0004A13C File Offset: 0x0004833C
        private void chkLos_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.TargetLoS = this.chkLos.Checked;
            }
        }

        // Token: 0x06000745 RID: 1861 RVA: 0x0004A170 File Offset: 0x00048370
        private void chkMutexAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.MutexAuto = this.chkMutexAuto.Checked;
            }
        }

        // Token: 0x06000746 RID: 1862 RVA: 0x0004A1A4 File Offset: 0x000483A4
        private void chkMutexSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.MutexIgnore = this.chkMutexSkip.Checked;
            }
        }

        // Token: 0x06000747 RID: 1863 RVA: 0x0004A1D8 File Offset: 0x000483D8
        private void chkNoAUReq_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.NeverAutoUpdateRequirements = this.chkNoAUReq.Checked;
            }
        }

        // Token: 0x06000748 RID: 1864 RVA: 0x0004A20C File Offset: 0x0004840C
        private void chkNoAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.NeverAutoUpdate = this.chkNoAutoUpdate.Checked;
            }
        }

        // Token: 0x06000749 RID: 1865 RVA: 0x0004A240 File Offset: 0x00048440
        private void chkPRFrontLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AllowFrontLoading = this.chkPRFrontLoad.Checked;
            }
        }

        // Token: 0x0600074A RID: 1866 RVA: 0x0004A274 File Offset: 0x00048474
        private void chkScale_CheckedChanged(object sender, EventArgs e)
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

        // Token: 0x0600074B RID: 1867 RVA: 0x0004A35C File Offset: 0x0004855C
        private void chkSortOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.SortOverride = this.chkSortOverride.Checked;
            }
        }

        // Token: 0x0600074C RID: 1868 RVA: 0x0004A390 File Offset: 0x00048590
        private void chkSubInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.IncludeFlag = this.chkSubInclude.Checked;
            }
        }

        // Token: 0x0600074D RID: 1869 RVA: 0x0004A3C4 File Offset: 0x000485C4
        private void chkSummonDisplayEntity_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.ShowSummonAnyway = this.chkSummonDisplayEntity.Checked;
            }
        }

        // Token: 0x0600074E RID: 1870 RVA: 0x0004A3F8 File Offset: 0x000485F8
        private void chkSummonStealAttributes_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AbsorbSummonAttributes = this.chkSummonStealAttributes.Checked;
            }
        }

        // Token: 0x0600074F RID: 1871 RVA: 0x0004A42C File Offset: 0x0004862C
        private void chkSummonStealEffects_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.AbsorbSummonEffects = this.chkSummonStealEffects.Checked;
            }
        }

        // Token: 0x06000750 RID: 1872 RVA: 0x0004A460 File Offset: 0x00048660
        private void clbFlags_ItemCheck(object sender, ItemCheckEventArgs e)
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

        // Token: 0x06000751 RID: 1873 RVA: 0x0004A7AC File Offset: 0x000489AC
        private void DisplayNameData()
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

        // Token: 0x06000753 RID: 1875 RVA: 0x0004A8CC File Offset: 0x00048ACC
        private void DrawAcceptedSets()
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

        // Token: 0x06000754 RID: 1876 RVA: 0x0004AC4C File Offset: 0x00048E4C
        private void DrawSetList()
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

        // Token: 0x06000755 RID: 1877 RVA: 0x0004B020 File Offset: 0x00049220
        private void FillAdvAtrList()
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

        // Token: 0x06000756 RID: 1878 RVA: 0x0004B314 File Offset: 0x00049514
        private void FillCombo_Attribs()
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

        // Token: 0x06000757 RID: 1879 RVA: 0x0004B468 File Offset: 0x00049668
        private void FillCombo_Basic()
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

        // Token: 0x06000758 RID: 1880 RVA: 0x0004B62C File Offset: 0x0004982C
        private void FillComboBoxes()
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

        // Token: 0x06000759 RID: 1881 RVA: 0x0004B6D4 File Offset: 0x000498D4
        private void FillTab_Attribs()
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

        // Token: 0x0600075A RID: 1882 RVA: 0x0004B914 File Offset: 0x00049B14
        private void FillTab_Basic()
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

        // Token: 0x0600075B RID: 1883 RVA: 0x0004BB24 File Offset: 0x00049D24
        private void FillTab_Disabling()
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

        // Token: 0x0600075C RID: 1884 RVA: 0x0004BBFE File Offset: 0x00049DFE
        private void FillTab_Effects()
        {
            this.RefreshFXData(0);
        }

        // Token: 0x0600075D RID: 1885 RVA: 0x0004BC0C File Offset: 0x00049E0C
        private void FillTab_Enhancements()
        {
            this.RedrawEnhList();
            this.chkPRFrontLoad.Checked = this.myPower.AllowFrontLoading;
            this.chkBoostBoostable.Checked = this.myPower.BoostBoostable;
            this.chkBoostUsePlayerLevel.Checked = this.myPower.BoostUsePlayerLevel;
        }

        // Token: 0x0600075E RID: 1886 RVA: 0x0004BC68 File Offset: 0x00049E68
        private void FillTab_Mutex()
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

        // Token: 0x0600075F RID: 1887 RVA: 0x0004BD5C File Offset: 0x00049F5C
        private void FillTab_Req()
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

        // Token: 0x06000760 RID: 1888 RVA: 0x0004BFC4 File Offset: 0x0004A1C4
        private void Filltab_ReqClasses()
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

        // Token: 0x06000761 RID: 1889 RVA: 0x0004C19B File Offset: 0x0004A39B
        private void FillTab_Sets()
        {
            this.DrawAcceptedSets();
        }

        // Token: 0x06000762 RID: 1890 RVA: 0x0004C1A8 File Offset: 0x0004A3A8
        private void FillTab_SubPowers()
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

        // Token: 0x06000763 RID: 1891 RVA: 0x0004C24F File Offset: 0x0004A44F
        private void frmEditPower_Load(object sender, EventArgs e)
        {
            this.RedrawEnhPicker();
            this.FillComboBoxes();
            this.DrawSetList();
            this.Req_GroupList();
            this.FillTab_SubPowers();
            this.refresh_PowerData();
            this.Updating = false;
        }

        // Token: 0x06000764 RID: 1892 RVA: 0x0004C284 File Offset: 0x0004A484
        private static int GetClassByID(int iID)
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

        // Token: 0x06000765 RID: 1893 RVA: 0x0004C2E8 File Offset: 0x0004A4E8
        private int GetInvSetIndex(Point e)
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

        // Token: 0x06000766 RID: 1894 RVA: 0x0004C3A0 File Offset: 0x0004A5A0
        private int GetInvSetListIndex(Point e)
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

        // Token: 0x06000768 RID: 1896 RVA: 0x000533B0 File Offset: 0x000515B0
        private void lblStaticIndex_Click(object sender, EventArgs e)
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

        // Token: 0x06000769 RID: 1897 RVA: 0x00053460 File Offset: 0x00051660
        private void lvDisablePass1_SelectedIndexChanged(object sender, EventArgs e)
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

        // Token: 0x0600076A RID: 1898 RVA: 0x000534EC File Offset: 0x000516EC
        private void lvDisablePass4_SelectedIndexChanged(object sender, EventArgs e)
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

        // Token: 0x0600076B RID: 1899 RVA: 0x00053578 File Offset: 0x00051778
        private void lvFX_DoubleClick(object sender, EventArgs e)
        {
            this.btnFXEdit_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        // Token: 0x0600076C RID: 1900 RVA: 0x00053589 File Offset: 0x00051789
        private void lvFX_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        // Token: 0x0600076D RID: 1901 RVA: 0x0005358C File Offset: 0x0005178C
        private void lvPrGroup_SelectedIndexChanged(object sender, EventArgs e)
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

        // Token: 0x0600076E RID: 1902 RVA: 0x000535FD File Offset: 0x000517FD
        private void lvPrListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Req_Listing_IndexChanged();
        }

        // Token: 0x0600076F RID: 1903 RVA: 0x00053608 File Offset: 0x00051808
        private void lvPrPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging)
            {
                this.Req_UpdateItem();
            }
        }

        // Token: 0x06000770 RID: 1904 RVA: 0x0005362C File Offset: 0x0005182C
        private void lvPrSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging && this.lvPrSet.SelectedItems.Count > 0)
            {
                this.Req_PowerList();
            }
        }

        // Token: 0x06000771 RID: 1905 RVA: 0x0005366C File Offset: 0x0005186C
        private void lvSPGroup_SelectedIndexChanged(object sender, EventArgs e)
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

        // Token: 0x06000772 RID: 1906 RVA: 0x000536DD File Offset: 0x000518DD
        private void lvSPPower_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Token: 0x06000773 RID: 1907 RVA: 0x000536E0 File Offset: 0x000518E0
        private void lvSPSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.ReqChanging && this.lvSPSet.SelectedItems.Count > 0)
            {
                this.SP_PowerList();
            }
        }

        // Token: 0x06000774 RID: 1908 RVA: 0x00053720 File Offset: 0x00051920
        private void pbEnhancementList_Hover(object sender, MouseEventArgs e)
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

        // Token: 0x06000775 RID: 1909 RVA: 0x0005383C File Offset: 0x00051A3C
        private void pbEnhancementList_MouseDown(object sender, MouseEventArgs e)
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

        // Token: 0x06000776 RID: 1910 RVA: 0x00053A18 File Offset: 0x00051C18
        private void pbEnhancementList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxEnhPicker != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxEnhPicker.Bitmap, 0, 0);
            }
        }

        // Token: 0x06000777 RID: 1911 RVA: 0x00053A50 File Offset: 0x00051C50
        private void pbEnhancements_Hover(object sender, MouseEventArgs e)
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

        // Token: 0x06000778 RID: 1912 RVA: 0x00053B24 File Offset: 0x00051D24
        private void pbEnhancements_MouseDown(object sender, MouseEventArgs e)
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

        // Token: 0x06000779 RID: 1913 RVA: 0x00053C74 File Offset: 0x00051E74
        private void pbEnhancements_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxEnhPicked != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxEnhPicked.Bitmap, 0, 0);
            }
        }

        // Token: 0x0600077A RID: 1914 RVA: 0x00053CAC File Offset: 0x00051EAC
        private void pbInvSetList_MouseDown(object sender, MouseEventArgs e)
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

        // Token: 0x0600077B RID: 1915 RVA: 0x00053DDC File Offset: 0x00051FDC
        private void pbInvSetList_MouseMove(object sender, MouseEventArgs e)
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

        // Token: 0x0600077C RID: 1916 RVA: 0x00053E54 File Offset: 0x00052054
        private void pbInvSetList_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxSetList != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxSetList.Bitmap, 0, 0);
            }
        }

        // Token: 0x0600077D RID: 1917 RVA: 0x00053E8C File Offset: 0x0005208C
        private void pbInvSetUsed_MouseDown(object sender, MouseEventArgs e)
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

        // Token: 0x0600077E RID: 1918 RVA: 0x00053FB4 File Offset: 0x000521B4
        private void pbInvSetUsed_MouseMove(object sender, MouseEventArgs e)
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

        // Token: 0x0600077F RID: 1919 RVA: 0x00054044 File Offset: 0x00052244
        private void pbInvSetUsed_Paint(object sender, PaintEventArgs e)
        {
            if (this.bxSet != null)
            {
                e.Graphics.DrawImageUnscaled(this.bxSet.Bitmap, 0, 0);
            }
        }

        // Token: 0x06000780 RID: 1920 RVA: 0x0005407C File Offset: 0x0005227C
        private static bool PowerFullNameIsUnique(string iFullName, int skipId = -1)
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

        // Token: 0x06000781 RID: 1921 RVA: 0x00054100 File Offset: 0x00052300
        private void rbFlagX_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.FillAdvAtrList();
            }
        }

        // Token: 0x06000782 RID: 1922 RVA: 0x00054124 File Offset: 0x00052324
        private void rbPrAdd_Click(object sender, EventArgs e)
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

        // Token: 0x06000783 RID: 1923 RVA: 0x0005439C File Offset: 0x0005259C
        private void rbPrPowerX_CheckedChanged(object sender, EventArgs e)
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

        // Token: 0x06000784 RID: 1924 RVA: 0x0005442C File Offset: 0x0005262C
        private void rbPrRemove_Click(object sender, EventArgs e)
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

        // Token: 0x06000785 RID: 1925 RVA: 0x00054740 File Offset: 0x00052940
        private void RedrawEnhList()
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

        // Token: 0x06000786 RID: 1926 RVA: 0x00054890 File Offset: 0x00052A90
        private void RedrawEnhPicker()
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

        // Token: 0x06000787 RID: 1927 RVA: 0x00054A48 File Offset: 0x00052C48
        private void refresh_PowerData()
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

        // Token: 0x06000788 RID: 1928 RVA: 0x00054AE8 File Offset: 0x00052CE8
        private void RefreshFXData(int Index = 0)
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

        // Token: 0x06000789 RID: 1929 RVA: 0x00054BD0 File Offset: 0x00052DD0
        private void Req_GroupList()
        {
            this.lvPrGroup.BeginUpdate();
            this.lvPrGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.lvPrGroup.Items.Add(key);
            }
            this.lvPrGroup.EndUpdate();
        }

        // Token: 0x0600078A RID: 1930 RVA: 0x00054C68 File Offset: 0x00052E68
        private void Req_Listing_IndexChanged()
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

        // Token: 0x0600078B RID: 1931 RVA: 0x00054D78 File Offset: 0x00052F78
        private void Req_PowerList()
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

        // Token: 0x0600078C RID: 1932 RVA: 0x00054E80 File Offset: 0x00053080
        private void Req_SetList()
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

        // Token: 0x0600078D RID: 1933 RVA: 0x00054F7C File Offset: 0x0005317C
        private void Req_UpdateItem()
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

        // Token: 0x0600078E RID: 1934 RVA: 0x000551D0 File Offset: 0x000533D0
        private void ReqDisplayPower(string iPower)
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

        // Token: 0x0600078F RID: 1935 RVA: 0x000553D8 File Offset: 0x000535D8
        private void SetDynamics()
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

        // Token: 0x06000790 RID: 1936 RVA: 0x000554EC File Offset: 0x000536EC
        private void SetFullName()
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

        // Token: 0x06000791 RID: 1937 RVA: 0x00055540 File Offset: 0x00053740
        private void SP_GroupList()
        {
            this.lvSPGroup.BeginUpdate();
            this.lvSPGroup.Items.Clear();
            foreach (string key in DatabaseAPI.Database.PowersetGroups.Keys)
            {
                this.lvSPGroup.Items.Add(key);
            }
            this.lvSPGroup.EndUpdate();
        }

        // Token: 0x06000792 RID: 1938 RVA: 0x000555D8 File Offset: 0x000537D8
        private void SP_PowerList()
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

        // Token: 0x06000793 RID: 1939 RVA: 0x00055728 File Offset: 0x00053928
        private void SP_SetList()
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

        // Token: 0x06000794 RID: 1940 RVA: 0x00055824 File Offset: 0x00053A24
        private void SPFillList()
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

        // Token: 0x06000795 RID: 1941 RVA: 0x000558A0 File Offset: 0x00053AA0
        private void Store_Req_Classes()
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

        // Token: 0x06000796 RID: 1942 RVA: 0x000559B8 File Offset: 0x00053BB8
        private void txtAcc_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtAcc.Text = Conversions.ToString(power.Accuracy);
            }
        }

        // Token: 0x06000797 RID: 1943 RVA: 0x000559F0 File Offset: 0x00053BF0
        private void txtAcc_TextChanged(object sender, EventArgs e)
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

        // Token: 0x06000798 RID: 1944 RVA: 0x00055A4C File Offset: 0x00053C4C
        private void txtActivate_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtActivate.Text = Conversions.ToString(power.ActivatePeriod);
            }
        }

        // Token: 0x06000799 RID: 1945 RVA: 0x00055A84 File Offset: 0x00053C84
        private void txtActivate_TextChanged(object sender, EventArgs e)
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

        // Token: 0x0600079A RID: 1946 RVA: 0x00055AE0 File Offset: 0x00053CE0
        private void txtArc_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtArc.Text = Conversions.ToString(power.Arc);
            }
        }

        // Token: 0x0600079B RID: 1947 RVA: 0x00055B18 File Offset: 0x00053D18
        private void txtArc_TextChanged(object sender, EventArgs e)
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

        // Token: 0x0600079C RID: 1948 RVA: 0x00055B7C File Offset: 0x00053D7C
        private void txtCastTime_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtCastTime.Text = Conversions.ToString(power.CastTimeReal);
            }
        }

        // Token: 0x0600079D RID: 1949 RVA: 0x00055BB4 File Offset: 0x00053DB4
        private void txtCastTime_TextChanged(object sender, EventArgs e)
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

        // Token: 0x0600079E RID: 1950 RVA: 0x00055C10 File Offset: 0x00053E10
        private void txtDescLong_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.DescLong = this.txtDescLong.Text;
            }
        }

        // Token: 0x0600079F RID: 1951 RVA: 0x00055C44 File Offset: 0x00053E44
        private void txtDescShort_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.DescShort = this.txtDescShort.Text;
            }
        }

        // Token: 0x060007A0 RID: 1952 RVA: 0x00055C78 File Offset: 0x00053E78
        private void txtEndCost_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtEndCost.Text = Conversions.ToString(power.EndCost);
            }
        }

        // Token: 0x060007A1 RID: 1953 RVA: 0x00055CB0 File Offset: 0x00053EB0
        private void txtEndCost_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007A2 RID: 1954 RVA: 0x00055D0C File Offset: 0x00053F0C
        private void txtInterrupt_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtInterrupt.Text = Conversions.ToString(power.InterruptTime);
            }
        }

        // Token: 0x060007A3 RID: 1955 RVA: 0x00055D44 File Offset: 0x00053F44
        private void txtInterrupt_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007A4 RID: 1956 RVA: 0x00055DA0 File Offset: 0x00053FA0
        private void txtLevel_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtLevel.Text = Conversions.ToString(power.Level);
            }
        }

        // Token: 0x060007A5 RID: 1957 RVA: 0x00055DD8 File Offset: 0x00053FD8
        private void txtLevel_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007A6 RID: 1958 RVA: 0x00055E30 File Offset: 0x00054030
        private void txtLifeTimeGame_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtLifeTimeGame.Text = Conversions.ToString(power.LifeTimeInGame);
            }
        }

        // Token: 0x060007A7 RID: 1959 RVA: 0x00055E68 File Offset: 0x00054068
        private void txtLifeTimeGame_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007A8 RID: 1960 RVA: 0x00055EC8 File Offset: 0x000540C8
        private void txtLifeTimeReal_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtLifeTimeReal.Text = Conversions.ToString(power.LifeTime);
            }
        }

        // Token: 0x060007A9 RID: 1961 RVA: 0x00055F00 File Offset: 0x00054100
        private void txtLifeTimeReal_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007AA RID: 1962 RVA: 0x00055F60 File Offset: 0x00054160
        private void txtMaxTargets_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtMaxTargets.Text = Conversions.ToString(power.MaxTargets);
            }
        }

        // Token: 0x060007AB RID: 1963 RVA: 0x00055F98 File Offset: 0x00054198
        private void txtMaxTargets_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007AC RID: 1964 RVA: 0x00055FFC File Offset: 0x000541FC
        private void txtNamePower_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.DisplayNameData();
            }
        }

        // Token: 0x060007AD RID: 1965 RVA: 0x00056020 File Offset: 0x00054220
        private void txtNamePower_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.PowerName = this.txtNamePower.Text;
                this.SetFullName();
            }
        }

        // Token: 0x060007AE RID: 1966 RVA: 0x00056058 File Offset: 0x00054258
        private void txtNumCharges_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtNumCharges.Text = Conversions.ToString(power.NumCharges);
            }
        }

        // Token: 0x060007AF RID: 1967 RVA: 0x00056090 File Offset: 0x00054290
        private void txtNumCharges_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007B0 RID: 1968 RVA: 0x000560F0 File Offset: 0x000542F0
        private void txtPowerName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.DisplayName = this.txtNameDisplay.Text;
            }
        }

        // Token: 0x060007B1 RID: 1969 RVA: 0x00056124 File Offset: 0x00054324
        private void txtRadius_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRadius.Text = Conversions.ToString(power.Radius);
            }
        }

        // Token: 0x060007B2 RID: 1970 RVA: 0x0005615C File Offset: 0x0005435C
        private void txtRadius_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007B3 RID: 1971 RVA: 0x000561C0 File Offset: 0x000543C0
        private void txtRange_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRange.Text = Conversions.ToString(power.Range);
            }
        }

        // Token: 0x060007B4 RID: 1972 RVA: 0x000561F8 File Offset: 0x000543F8
        private void txtRange_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007B5 RID: 1973 RVA: 0x00056250 File Offset: 0x00054450
        private void txtRangeSec_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRangeSec.Text = Conversions.ToString(power.RangeSecondary);
            }
        }

        // Token: 0x060007B6 RID: 1974 RVA: 0x00056288 File Offset: 0x00054488
        private void txtRangeSec_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007B7 RID: 1975 RVA: 0x000562E0 File Offset: 0x000544E0
        private void txtRechargeTime_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtRechargeTime.Text = Conversions.ToString(power.RechargeTime);
            }
        }

        // Token: 0x060007B8 RID: 1976 RVA: 0x00056318 File Offset: 0x00054518
        private void txtRechargeTime_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007B9 RID: 1977 RVA: 0x00056374 File Offset: 0x00054574
        private void txtScaleName_TextChanged(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                this.myPower.VariableName = this.txtScaleName.Text;
            }
        }

        // Token: 0x060007BA RID: 1978 RVA: 0x000563A8 File Offset: 0x000545A8
        private void txtUseageTime_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtUseageTime.Text = Conversions.ToString(power.UsageTime);
            }
        }

        // Token: 0x060007BB RID: 1979 RVA: 0x000563E0 File Offset: 0x000545E0
        private void txtUseageTime_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007BC RID: 1980 RVA: 0x00056440 File Offset: 0x00054640
        private void txtVisualLocation_Leave(object sender, EventArgs e)
        {
            if (!this.Updating)
            {
                IPower power = this.myPower;
                this.txtVisualLocation.Text = Conversions.ToString(power.DisplayLocation);
            }
        }

        // Token: 0x060007BD RID: 1981 RVA: 0x00056478 File Offset: 0x00054678
        private void txtVisualLocation_TextChanged(object sender, EventArgs e)
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

        // Token: 0x060007BE RID: 1982 RVA: 0x000564DA File Offset: 0x000546DA
        private void udScaleMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CheckScaleValues();
        }

        // Token: 0x060007BF RID: 1983 RVA: 0x000564E4 File Offset: 0x000546E4
        private void udScaleMax_Leave(object sender, EventArgs e)
        {
            this.myPower.VariableMax = (int)Math.Round(Conversion.Val(this.udScaleMax.Text));
            this.CheckScaleValues();
        }

        // Token: 0x060007C0 RID: 1984 RVA: 0x00056510 File Offset: 0x00054710
        private void udScaleMax_ValueChanged(object sender, EventArgs e)
        {
            this.myPower.VariableMax = Convert.ToInt32(this.udScaleMax.Value);
            this.CheckScaleValues();
        }

        // Token: 0x060007C1 RID: 1985 RVA: 0x00056536 File Offset: 0x00054736
        private void udScaleMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.CheckScaleValues();
        }

        // Token: 0x060007C2 RID: 1986 RVA: 0x00056540 File Offset: 0x00054740
        private void udScaleMin_Leave(object sender, EventArgs e)
        {
            this.myPower.VariableMin = (int)Math.Round(Conversion.Val(this.udScaleMin.Text));
            this.CheckScaleValues();
        }

        // Token: 0x060007C3 RID: 1987 RVA: 0x0005656C File Offset: 0x0005476C
        private void udScaleMin_ValueChanged(object sender, EventArgs e)
        {
            this.myPower.VariableMin = Convert.ToInt32(this.udScaleMin.Value);
            this.CheckScaleValues();
        }

        // Token: 0x04000286 RID: 646
        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;

        // Token: 0x04000287 RID: 647
        [AccessedThroughProperty("btnCSVImport")]
        private Button _btnCSVImport;

        // Token: 0x04000288 RID: 648
        [AccessedThroughProperty("btnFullCopy")]
        private Button _btnFullCopy;

        // Token: 0x04000289 RID: 649
        [AccessedThroughProperty("btnFullPaste")]
        private Button _btnFullPaste;

        // Token: 0x0400028A RID: 650
        [AccessedThroughProperty("btnFXAdd")]
        private Button _btnFXAdd;

        // Token: 0x0400028B RID: 651
        [AccessedThroughProperty("btnFXDown")]
        private Button _btnFXDown;

        // Token: 0x0400028C RID: 652
        [AccessedThroughProperty("btnFXDuplicate")]
        private Button _btnFXDuplicate;

        // Token: 0x0400028D RID: 653
        [AccessedThroughProperty("btnFXEdit")]
        private Button _btnFXEdit;

        // Token: 0x0400028E RID: 654
        [AccessedThroughProperty("btnFXRemove")]
        private Button _btnFXRemove;

        // Token: 0x0400028F RID: 655
        [AccessedThroughProperty("btnFXUp")]
        private Button _btnFXUp;

        // Token: 0x04000290 RID: 656
        [AccessedThroughProperty("btnMutexAdd")]
        private Button _btnMutexAdd;

        // Token: 0x04000291 RID: 657
        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;

        // Token: 0x04000292 RID: 658
        [AccessedThroughProperty("btnPrDown")]
        private Button _btnPrDown;

        // Token: 0x04000293 RID: 659
        [AccessedThroughProperty("btnPrReset")]
        private Button _btnPrReset;

        // Token: 0x04000294 RID: 660
        [AccessedThroughProperty("btnPrSetNone")]
        private Button _btnPrSetNone;

        // Token: 0x04000295 RID: 661
        [AccessedThroughProperty("btnPrUp")]
        private Button _btnPrUp;

        // Token: 0x04000296 RID: 662
        [AccessedThroughProperty("btnSetDamage")]
        private Button _btnSetDamage;

        // Token: 0x04000297 RID: 663
        [AccessedThroughProperty("btnSPAdd")]
        private Button _btnSPAdd;

        // Token: 0x04000298 RID: 664
        [AccessedThroughProperty("btnSPRemove")]
        private Button _btnSPRemove;

        // Token: 0x04000299 RID: 665
        [AccessedThroughProperty("cbEffectArea")]
        private ComboBox _cbEffectArea;

        // Token: 0x0400029A RID: 666
        [AccessedThroughProperty("cbForcedClass")]
        private ComboBox _cbForcedClass;

        // Token: 0x0400029B RID: 667
        [AccessedThroughProperty("cbNameGroup")]
        private ComboBox _cbNameGroup;

        // Token: 0x0400029C RID: 668
        [AccessedThroughProperty("cbNameSet")]
        private ComboBox _cbNameSet;

        // Token: 0x0400029D RID: 669
        [AccessedThroughProperty("cbNotify")]
        private ComboBox _cbNotify;

        // Token: 0x0400029E RID: 670
        [AccessedThroughProperty("cbPowerType")]
        private ComboBox _cbPowerType;

        // Token: 0x0400029F RID: 671
        [AccessedThroughProperty("chkAltSub")]
        private CheckBox _chkAltSub;

        // Token: 0x040002A0 RID: 672
        [AccessedThroughProperty("chkAlwaysToggle")]
        private CheckBox _chkAlwaysToggle;

        // Token: 0x040002A1 RID: 673
        [AccessedThroughProperty("chkBoostBoostable")]
        private CheckBox _chkBoostBoostable;

        // Token: 0x040002A2 RID: 674
        [AccessedThroughProperty("chkBoostUsePlayerLevel")]
        private CheckBox _chkBoostUsePlayerLevel;

        // Token: 0x040002A3 RID: 675
        [AccessedThroughProperty("chkBuffCycle")]
        private CheckBox _chkBuffCycle;

        // Token: 0x040002A4 RID: 676
        [AccessedThroughProperty("chkGraphFix")]
        private CheckBox _chkGraphFix;

        // Token: 0x040002A5 RID: 677
        [AccessedThroughProperty("chkHidden")]
        private CheckBox _chkHidden;

        // Token: 0x040002A6 RID: 678
        [AccessedThroughProperty("chkIgnoreStrength")]
        private CheckBox _chkIgnoreStrength;

        // Token: 0x040002A7 RID: 679
        [AccessedThroughProperty("chkLos")]
        private CheckBox _chkLos;

        // Token: 0x040002A8 RID: 680
        [AccessedThroughProperty("chkMutexAuto")]
        private CheckBox _chkMutexAuto;

        // Token: 0x040002A9 RID: 681
        [AccessedThroughProperty("chkMutexSkip")]
        private CheckBox _chkMutexSkip;

        // Token: 0x040002AA RID: 682
        [AccessedThroughProperty("chkNoAUReq")]
        private CheckBox _chkNoAUReq;

        // Token: 0x040002AB RID: 683
        [AccessedThroughProperty("chkNoAutoUpdate")]
        private CheckBox _chkNoAutoUpdate;

        // Token: 0x040002AC RID: 684
        [AccessedThroughProperty("chkPRFrontLoad")]
        private CheckBox _chkPRFrontLoad;

        // Token: 0x040002AD RID: 685
        [AccessedThroughProperty("chkScale")]
        private CheckBox _chkScale;

        // Token: 0x040002AE RID: 686
        [AccessedThroughProperty("chkSortOverride")]
        private CheckBox _chkSortOverride;

        // Token: 0x040002AF RID: 687
        [AccessedThroughProperty("chkSubInclude")]
        private CheckBox _chkSubInclude;

        // Token: 0x040002B0 RID: 688
        [AccessedThroughProperty("chkSummonDisplayEntity")]
        private CheckBox _chkSummonDisplayEntity;

        // Token: 0x040002B1 RID: 689
        [AccessedThroughProperty("chkSummonStealAttributes")]
        private CheckBox _chkSummonStealAttributes;

        // Token: 0x040002B2 RID: 690
        [AccessedThroughProperty("chkSummonStealEffects")]
        private CheckBox _chkSummonStealEffects;

        // Token: 0x040002B3 RID: 691
        [AccessedThroughProperty("clbClassExclude")]
        private CheckedListBox _clbClassExclude;

        // Token: 0x040002B4 RID: 692
        [AccessedThroughProperty("clbClassReq")]
        private CheckedListBox _clbClassReq;

        // Token: 0x040002B5 RID: 693
        [AccessedThroughProperty("clbFlags")]
        private CheckedListBox _clbFlags;

        // Token: 0x040002B6 RID: 694
        [AccessedThroughProperty("clbMutex")]
        private CheckedListBox _clbMutex;

        // Token: 0x040002B7 RID: 695
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;

        // Token: 0x040002B8 RID: 696
        [AccessedThroughProperty("ColumnHeader10")]
        private ColumnHeader _ColumnHeader10;

        // Token: 0x040002B9 RID: 697
        [AccessedThroughProperty("ColumnHeader11")]
        private ColumnHeader _ColumnHeader11;

        // Token: 0x040002BA RID: 698
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;

        // Token: 0x040002BB RID: 699
        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;

        // Token: 0x040002BC RID: 700
        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;

        // Token: 0x040002BD RID: 701
        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;

        // Token: 0x040002BE RID: 702
        [AccessedThroughProperty("ColumnHeader7")]
        private ColumnHeader _ColumnHeader7;

        // Token: 0x040002BF RID: 703
        [AccessedThroughProperty("ColumnHeader8")]
        private ColumnHeader _ColumnHeader8;

        // Token: 0x040002C0 RID: 704
        [AccessedThroughProperty("ColumnHeader9")]
        private ColumnHeader _ColumnHeader9;

        // Token: 0x040002C1 RID: 705
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;

        // Token: 0x040002C2 RID: 706
        [AccessedThroughProperty("GroupBox10")]
        private GroupBox _GroupBox10;

        // Token: 0x040002C3 RID: 707
        [AccessedThroughProperty("GroupBox11")]
        private GroupBox _GroupBox11;

        // Token: 0x040002C4 RID: 708
        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;

        // Token: 0x040002C5 RID: 709
        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;

        // Token: 0x040002C6 RID: 710
        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;

        // Token: 0x040002C7 RID: 711
        [AccessedThroughProperty("GroupBox5")]
        private GroupBox _GroupBox5;

        // Token: 0x040002C8 RID: 712
        [AccessedThroughProperty("GroupBox6")]
        private GroupBox _GroupBox6;

        // Token: 0x040002C9 RID: 713
        [AccessedThroughProperty("GroupBox7")]
        private GroupBox _GroupBox7;

        // Token: 0x040002CA RID: 714
        [AccessedThroughProperty("GroupBox8")]
        private GroupBox _GroupBox8;

        // Token: 0x040002CB RID: 715
        [AccessedThroughProperty("GroupBox9")]
        private GroupBox _GroupBox9;

        // Token: 0x040002CC RID: 716
        [AccessedThroughProperty("Label1")]
        private Label _Label1;

        // Token: 0x040002CD RID: 717
        [AccessedThroughProperty("Label10")]
        private Label _Label10;

        // Token: 0x040002CE RID: 718
        [AccessedThroughProperty("Label11")]
        private Label _Label11;

        // Token: 0x040002CF RID: 719
        [AccessedThroughProperty("Label12")]
        private Label _Label12;

        // Token: 0x040002D0 RID: 720
        [AccessedThroughProperty("Label13")]
        private Label _Label13;

        // Token: 0x040002D1 RID: 721
        [AccessedThroughProperty("Label14")]
        private Label _Label14;

        // Token: 0x040002D2 RID: 722
        [AccessedThroughProperty("Label15")]
        private Label _Label15;

        // Token: 0x040002D3 RID: 723
        [AccessedThroughProperty("Label16")]
        private Label _Label16;

        // Token: 0x040002D4 RID: 724
        [AccessedThroughProperty("Label17")]
        private Label _Label17;

        // Token: 0x040002D5 RID: 725
        [AccessedThroughProperty("Label18")]
        private Label _Label18;

        // Token: 0x040002D6 RID: 726
        [AccessedThroughProperty("Label2")]
        private Label _Label2;

        // Token: 0x040002D7 RID: 727
        [AccessedThroughProperty("Label20")]
        private Label _Label20;

        // Token: 0x040002D8 RID: 728
        [AccessedThroughProperty("Label21")]
        private Label _Label21;

        // Token: 0x040002D9 RID: 729
        [AccessedThroughProperty("Label22")]
        private Label _Label22;

        // Token: 0x040002DA RID: 730
        [AccessedThroughProperty("Label23")]
        private Label _Label23;

        // Token: 0x040002DB RID: 731
        [AccessedThroughProperty("Label24")]
        private Label _Label24;

        // Token: 0x040002DC RID: 732
        [AccessedThroughProperty("Label26")]
        private Label _Label26;

        // Token: 0x040002DD RID: 733
        [AccessedThroughProperty("Label27")]
        private Label _Label27;

        // Token: 0x040002DE RID: 734
        [AccessedThroughProperty("Label28")]
        private Label _Label28;

        // Token: 0x040002DF RID: 735
        [AccessedThroughProperty("Label29")]
        private Label _Label29;

        // Token: 0x040002E0 RID: 736
        [AccessedThroughProperty("Label3")]
        private Label _Label3;

        // Token: 0x040002E1 RID: 737
        [AccessedThroughProperty("Label30")]
        private Label _Label30;

        // Token: 0x040002E2 RID: 738
        [AccessedThroughProperty("Label31")]
        private Label _Label31;

        // Token: 0x040002E3 RID: 739
        [AccessedThroughProperty("Label32")]
        private Label _Label32;

        // Token: 0x040002E4 RID: 740
        [AccessedThroughProperty("Label33")]
        private Label _Label33;

        // Token: 0x040002E5 RID: 741
        [AccessedThroughProperty("Label34")]
        private Label _Label34;

        // Token: 0x040002E6 RID: 742
        [AccessedThroughProperty("Label35")]
        private Label _Label35;

        // Token: 0x040002E7 RID: 743
        [AccessedThroughProperty("Label36")]
        private Label _Label36;

        // Token: 0x040002E8 RID: 744
        [AccessedThroughProperty("Label37")]
        private Label _Label37;

        // Token: 0x040002E9 RID: 745
        [AccessedThroughProperty("Label38")]
        private Label _Label38;

        // Token: 0x040002EA RID: 746
        [AccessedThroughProperty("Label39")]
        private Label _Label39;

        // Token: 0x040002EB RID: 747
        [AccessedThroughProperty("Label4")]
        private Label _Label4;

        // Token: 0x040002EC RID: 748
        [AccessedThroughProperty("Label40")]
        private Label _Label40;

        // Token: 0x040002ED RID: 749
        [AccessedThroughProperty("Label41")]
        private Label _Label41;

        // Token: 0x040002EE RID: 750
        [AccessedThroughProperty("Label42")]
        private Label _Label42;

        // Token: 0x040002EF RID: 751
        [AccessedThroughProperty("Label43")]
        private Label _Label43;

        // Token: 0x040002F0 RID: 752
        [AccessedThroughProperty("Label44")]
        private Label _Label44;

        // Token: 0x040002F1 RID: 753
        [AccessedThroughProperty("Label45")]
        private Label _Label45;

        // Token: 0x040002F2 RID: 754
        [AccessedThroughProperty("Label46")]
        private Label _Label46;

        // Token: 0x040002F3 RID: 755
        [AccessedThroughProperty("Label47")]
        private Label _Label47;

        // Token: 0x040002F4 RID: 756
        [AccessedThroughProperty("Label5")]
        private Label _Label5;

        // Token: 0x040002F5 RID: 757
        [AccessedThroughProperty("Label6")]
        private Label _Label6;

        // Token: 0x040002F6 RID: 758
        [AccessedThroughProperty("Label7")]
        private Label _Label7;

        // Token: 0x040002F7 RID: 759
        [AccessedThroughProperty("Label8")]
        private Label _Label8;

        // Token: 0x040002F8 RID: 760
        [AccessedThroughProperty("Label9")]
        private Label _Label9;

        // Token: 0x040002F9 RID: 761
        [AccessedThroughProperty("lblAcc")]
        private Label _lblAcc;

        // Token: 0x040002FA RID: 762
        [AccessedThroughProperty("lblEndCost")]
        private Label _lblEndCost;

        // Token: 0x040002FB RID: 763
        [AccessedThroughProperty("lblEnhName")]
        private Label _lblEnhName;

        // Token: 0x040002FC RID: 764
        [AccessedThroughProperty("lblInvSet")]
        private Label _lblInvSet;

        // Token: 0x040002FD RID: 765
        [AccessedThroughProperty("lblNameFull")]
        private Label _lblNameFull;

        // Token: 0x040002FE RID: 766
        [AccessedThroughProperty("lblNameUnique")]
        private Label _lblNameUnique;

        // Token: 0x040002FF RID: 767
        [AccessedThroughProperty("lblStaticIndex")]
        private Label _lblStaticIndex;

        // Token: 0x04000300 RID: 768
        [AccessedThroughProperty("lvDisablePass1")]
        private ListBox _lvDisablePass1;

        // Token: 0x04000301 RID: 769
        [AccessedThroughProperty("lvDisablePass4")]
        private ListBox _lvDisablePass4;

        // Token: 0x04000302 RID: 770
        [AccessedThroughProperty("lvFX")]
        private ListBox _lvFX;

        // Token: 0x04000303 RID: 771
        [AccessedThroughProperty("lvPrGroup")]
        private ListView _lvPrGroup;

        // Token: 0x04000304 RID: 772
        [AccessedThroughProperty("lvPrListing")]
        private ListView _lvPrListing;

        // Token: 0x04000305 RID: 773
        [AccessedThroughProperty("lvPrPower")]
        private ListView _lvPrPower;

        // Token: 0x04000306 RID: 774
        [AccessedThroughProperty("lvPrSet")]
        private ListView _lvPrSet;

        // Token: 0x04000307 RID: 775
        [AccessedThroughProperty("lvSPGroup")]
        private ListView _lvSPGroup;

        // Token: 0x04000308 RID: 776
        [AccessedThroughProperty("lvSPPower")]
        private ListView _lvSPPower;

        // Token: 0x04000309 RID: 777
        [AccessedThroughProperty("lvSPSelected")]
        private ListView _lvSPSelected;

        // Token: 0x0400030A RID: 778
        [AccessedThroughProperty("lvSPSet")]
        private ListView _lvSPSet;

        // Token: 0x0400030B RID: 779
        [AccessedThroughProperty("pbEnhancementList")]
        private PictureBox _pbEnhancementList;

        // Token: 0x0400030C RID: 780
        [AccessedThroughProperty("pbEnhancements")]
        private PictureBox _pbEnhancements;

        // Token: 0x0400030D RID: 781
        [AccessedThroughProperty("pbInvSetList")]
        private PictureBox _pbInvSetList;

        // Token: 0x0400030E RID: 782
        [AccessedThroughProperty("pbInvSetUsed")]
        private PictureBox _pbInvSetUsed;

        // Token: 0x0400030F RID: 783
        [AccessedThroughProperty("pnlFX")]
        private Panel _pnlFX;

        // Token: 0x04000310 RID: 784
        [AccessedThroughProperty("rbFlagAffected")]
        private RadioButton _rbFlagAffected;

        // Token: 0x04000311 RID: 785
        [AccessedThroughProperty("rbFlagAutoHit")]
        private RadioButton _rbFlagAutoHit;

        // Token: 0x04000312 RID: 786
        [AccessedThroughProperty("rbFlagCast")]
        private RadioButton _rbFlagCast;

        // Token: 0x04000313 RID: 787
        [AccessedThroughProperty("rbFlagCastThrough")]
        private RadioButton _rbFlagCastThrough;

        // Token: 0x04000314 RID: 788
        [AccessedThroughProperty("rbFlagDisallow")]
        private RadioButton _rbFlagDisallow;

        // Token: 0x04000315 RID: 789
        [AccessedThroughProperty("rbFlagRequired")]
        private RadioButton _rbFlagRequired;

        // Token: 0x04000316 RID: 790
        [AccessedThroughProperty("rbFlagTargets")]
        private RadioButton _rbFlagTargets;

        // Token: 0x04000317 RID: 791
        [AccessedThroughProperty("rbFlagTargetsSec")]
        private RadioButton _rbFlagTargetsSec;

        // Token: 0x04000318 RID: 792
        [AccessedThroughProperty("rbFlagVector")]
        private RadioButton _rbFlagVector;

        // Token: 0x04000319 RID: 793
        [AccessedThroughProperty("rbPrAdd")]
        private Button _rbPrAdd;

        // Token: 0x0400031A RID: 794
        [AccessedThroughProperty("rbPrPowerA")]
        private RadioButton _rbPrPowerA;

        // Token: 0x0400031B RID: 795
        [AccessedThroughProperty("rbPrPowerB")]
        private RadioButton _rbPrPowerB;

        // Token: 0x0400031C RID: 796
        [AccessedThroughProperty("rbPrRemove")]
        private Button _rbPrRemove;

        // Token: 0x0400031D RID: 797
        [AccessedThroughProperty("tcPower")]
        private TabControl _tcPower;

        // Token: 0x0400031E RID: 798
        [AccessedThroughProperty("tpBasic")]
        private TabPage _tpBasic;

        // Token: 0x0400031F RID: 799
        [AccessedThroughProperty("tpEffects")]
        private TabPage _tpEffects;

        // Token: 0x04000320 RID: 800
        [AccessedThroughProperty("tpEnh")]
        private TabPage _tpEnh;

        // Token: 0x04000321 RID: 801
        [AccessedThroughProperty("tpMutex")]
        private TabPage _tpMutex;

        // Token: 0x04000322 RID: 802
        [AccessedThroughProperty("tpPreReq")]
        private TabPage _tpPreReq;

        // Token: 0x04000323 RID: 803
        [AccessedThroughProperty("tpSets")]
        private TabPage _tpSets;

        // Token: 0x04000324 RID: 804
        [AccessedThroughProperty("tpSpecialEnh")]
        private TabPage _tpSpecialEnh;

        // Token: 0x04000325 RID: 805
        [AccessedThroughProperty("tpSubPower")]
        private TabPage _tpSubPower;

        // Token: 0x04000326 RID: 806
        [AccessedThroughProperty("tpText")]
        private TabPage _tpText;

        // Token: 0x04000327 RID: 807
        [AccessedThroughProperty("txtAcc")]
        private TextBox _txtAcc;

        // Token: 0x04000328 RID: 808
        [AccessedThroughProperty("txtActivate")]
        private TextBox _txtActivate;

        // Token: 0x04000329 RID: 809
        [AccessedThroughProperty("txtArc")]
        private TextBox _txtArc;

        // Token: 0x0400032A RID: 810
        [AccessedThroughProperty("txtCastTime")]
        private TextBox _txtCastTime;

        // Token: 0x0400032B RID: 811
        [AccessedThroughProperty("txtDescLong")]
        private TextBox _txtDescLong;

        // Token: 0x0400032C RID: 812
        [AccessedThroughProperty("txtDescShort")]
        private TextBox _txtDescShort;

        // Token: 0x0400032D RID: 813
        [AccessedThroughProperty("txtEndCost")]
        private TextBox _txtEndCost;

        // Token: 0x0400032E RID: 814
        [AccessedThroughProperty("txtInterrupt")]
        private TextBox _txtInterrupt;

        // Token: 0x0400032F RID: 815
        [AccessedThroughProperty("txtLevel")]
        private TextBox _txtLevel;

        // Token: 0x04000330 RID: 816
        [AccessedThroughProperty("txtLifeTimeGame")]
        private TextBox _txtLifeTimeGame;

        // Token: 0x04000331 RID: 817
        [AccessedThroughProperty("txtLifeTimeReal")]
        private TextBox _txtLifeTimeReal;

        // Token: 0x04000332 RID: 818
        [AccessedThroughProperty("txtMaxTargets")]
        private TextBox _txtMaxTargets;

        // Token: 0x04000333 RID: 819
        [AccessedThroughProperty("txtNameDisplay")]
        private TextBox _txtNameDisplay;

        // Token: 0x04000334 RID: 820
        [AccessedThroughProperty("txtNamePower")]
        private TextBox _txtNamePower;

        // Token: 0x04000335 RID: 821
        [AccessedThroughProperty("txtNumCharges")]
        private TextBox _txtNumCharges;

        // Token: 0x04000336 RID: 822
        [AccessedThroughProperty("txtRadius")]
        private TextBox _txtRadius;

        // Token: 0x04000337 RID: 823
        [AccessedThroughProperty("txtRange")]
        private TextBox _txtRange;

        // Token: 0x04000338 RID: 824
        [AccessedThroughProperty("txtRangeSec")]
        private TextBox _txtRangeSec;

        // Token: 0x04000339 RID: 825
        [AccessedThroughProperty("txtRechargeTime")]
        private TextBox _txtRechargeTime;

        // Token: 0x0400033A RID: 826
        [AccessedThroughProperty("txtScaleName")]
        private TextBox _txtScaleName;

        // Token: 0x0400033B RID: 827
        [AccessedThroughProperty("txtUseageTime")]
        private TextBox _txtUseageTime;

        // Token: 0x0400033C RID: 828
        [AccessedThroughProperty("txtVisualLocation")]
        private TextBox _txtVisualLocation;

        // Token: 0x0400033D RID: 829
        [AccessedThroughProperty("udScaleMax")]
        private NumericUpDown _udScaleMax;

        // Token: 0x0400033E RID: 830
        [AccessedThroughProperty("udScaleMin")]
        private NumericUpDown _udScaleMin;

        // Token: 0x0400033F RID: 831
        protected Requirement backup_Requires;

        // Token: 0x04000340 RID: 832
        private ExtendedBitmap bxEnhPicked;

        // Token: 0x04000341 RID: 833
        private ExtendedBitmap bxEnhPicker;

        // Token: 0x04000342 RID: 834
        protected ExtendedBitmap bxSet;

        // Token: 0x04000343 RID: 835
        protected ExtendedBitmap bxSetList;

        // Token: 0x04000345 RID: 837
        protected int enhAcross;

        // Token: 0x04000346 RID: 838
        protected int enhPadding;

        // Token: 0x04000347 RID: 839
        public IPower myPower;

        // Token: 0x04000348 RID: 840
        protected bool ReqChanging;

        // Token: 0x04000349 RID: 841
        protected bool Updating;
    }
}
