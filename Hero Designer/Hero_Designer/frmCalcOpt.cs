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

        // (get) Token: 0x060001E3 RID: 483 RVA: 0x00023D98 File Offset: 0x00021F98
        // (set) Token: 0x060001E4 RID: 484 RVA: 0x00023DB0 File Offset: 0x00021FB0
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


        // (get) Token: 0x060001E5 RID: 485 RVA: 0x00023E0C File Offset: 0x0002200C
        // (set) Token: 0x060001E6 RID: 486 RVA: 0x00023E24 File Offset: 0x00022024
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


        // (get) Token: 0x060001E7 RID: 487 RVA: 0x00023E80 File Offset: 0x00022080
        // (set) Token: 0x060001E8 RID: 488 RVA: 0x00023E98 File Offset: 0x00022098
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


        // (get) Token: 0x060001E9 RID: 489 RVA: 0x00023EF4 File Offset: 0x000220F4
        // (set) Token: 0x060001EA RID: 490 RVA: 0x00023F0C File Offset: 0x0002210C
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


        // (get) Token: 0x060001EB RID: 491 RVA: 0x00023F68 File Offset: 0x00022168
        // (set) Token: 0x060001EC RID: 492 RVA: 0x00023F80 File Offset: 0x00022180
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


        // (get) Token: 0x060001ED RID: 493 RVA: 0x00023FDC File Offset: 0x000221DC
        // (set) Token: 0x060001EE RID: 494 RVA: 0x00023FF4 File Offset: 0x000221F4
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


        // (get) Token: 0x060001EF RID: 495 RVA: 0x00024050 File Offset: 0x00022250
        // (set) Token: 0x060001F0 RID: 496 RVA: 0x00024068 File Offset: 0x00022268
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


        // (get) Token: 0x060001F1 RID: 497 RVA: 0x000240C4 File Offset: 0x000222C4
        // (set) Token: 0x060001F2 RID: 498 RVA: 0x000240DC File Offset: 0x000222DC
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


        // (get) Token: 0x060001F3 RID: 499 RVA: 0x00024138 File Offset: 0x00022338
        // (set) Token: 0x060001F4 RID: 500 RVA: 0x00024150 File Offset: 0x00022350
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


        // (get) Token: 0x060001F5 RID: 501 RVA: 0x000241AC File Offset: 0x000223AC
        // (set) Token: 0x060001F6 RID: 502 RVA: 0x000241C4 File Offset: 0x000223C4
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


        // (get) Token: 0x060001F7 RID: 503 RVA: 0x00024220 File Offset: 0x00022420
        // (set) Token: 0x060001F8 RID: 504 RVA: 0x00024238 File Offset: 0x00022438
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


        // (get) Token: 0x060001F9 RID: 505 RVA: 0x00024244 File Offset: 0x00022444
        // (set) Token: 0x060001FA RID: 506 RVA: 0x0002425C File Offset: 0x0002245C
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


        // (get) Token: 0x060001FB RID: 507 RVA: 0x00024268 File Offset: 0x00022468
        // (set) Token: 0x060001FC RID: 508 RVA: 0x00024280 File Offset: 0x00022480
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


        // (get) Token: 0x060001FD RID: 509 RVA: 0x0002428C File Offset: 0x0002248C
        // (set) Token: 0x060001FE RID: 510 RVA: 0x000242A4 File Offset: 0x000224A4
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


        // (get) Token: 0x060001FF RID: 511 RVA: 0x000242B0 File Offset: 0x000224B0
        // (set) Token: 0x06000200 RID: 512 RVA: 0x000242C8 File Offset: 0x000224C8
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


        // (get) Token: 0x06000201 RID: 513 RVA: 0x000242D4 File Offset: 0x000224D4
        // (set) Token: 0x06000202 RID: 514 RVA: 0x000242EC File Offset: 0x000224EC
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


        // (get) Token: 0x06000203 RID: 515 RVA: 0x000242F8 File Offset: 0x000224F8
        // (set) Token: 0x06000204 RID: 516 RVA: 0x00024310 File Offset: 0x00022510
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


        // (get) Token: 0x06000205 RID: 517 RVA: 0x0002431C File Offset: 0x0002251C
        // (set) Token: 0x06000206 RID: 518 RVA: 0x00024334 File Offset: 0x00022534
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


        // (get) Token: 0x06000207 RID: 519 RVA: 0x00024340 File Offset: 0x00022540
        // (set) Token: 0x06000208 RID: 520 RVA: 0x00024358 File Offset: 0x00022558
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


        // (get) Token: 0x06000209 RID: 521 RVA: 0x00024364 File Offset: 0x00022564
        // (set) Token: 0x0600020A RID: 522 RVA: 0x0002437C File Offset: 0x0002257C
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


        // (get) Token: 0x0600020B RID: 523 RVA: 0x00024388 File Offset: 0x00022588
        // (set) Token: 0x0600020C RID: 524 RVA: 0x000243A0 File Offset: 0x000225A0
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


        // (get) Token: 0x0600020D RID: 525 RVA: 0x000243AC File Offset: 0x000225AC
        // (set) Token: 0x0600020E RID: 526 RVA: 0x000243C4 File Offset: 0x000225C4
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


        // (get) Token: 0x0600020F RID: 527 RVA: 0x000243D0 File Offset: 0x000225D0
        // (set) Token: 0x06000210 RID: 528 RVA: 0x000243E8 File Offset: 0x000225E8
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


        // (get) Token: 0x06000211 RID: 529 RVA: 0x000243F4 File Offset: 0x000225F4
        // (set) Token: 0x06000212 RID: 530 RVA: 0x0002440C File Offset: 0x0002260C
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


        // (get) Token: 0x06000213 RID: 531 RVA: 0x00024418 File Offset: 0x00022618
        // (set) Token: 0x06000214 RID: 532 RVA: 0x00024430 File Offset: 0x00022630
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


        // (get) Token: 0x06000215 RID: 533 RVA: 0x0002443C File Offset: 0x0002263C
        // (set) Token: 0x06000216 RID: 534 RVA: 0x00024454 File Offset: 0x00022654
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


        // (get) Token: 0x06000217 RID: 535 RVA: 0x00024460 File Offset: 0x00022660
        // (set) Token: 0x06000218 RID: 536 RVA: 0x00024478 File Offset: 0x00022678
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


        // (get) Token: 0x06000219 RID: 537 RVA: 0x00024484 File Offset: 0x00022684
        // (set) Token: 0x0600021A RID: 538 RVA: 0x0002449C File Offset: 0x0002269C
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


        // (get) Token: 0x0600021B RID: 539 RVA: 0x000244A8 File Offset: 0x000226A8
        // (set) Token: 0x0600021C RID: 540 RVA: 0x000244C0 File Offset: 0x000226C0
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


        // (get) Token: 0x0600021D RID: 541 RVA: 0x0002451C File Offset: 0x0002271C
        // (set) Token: 0x0600021E RID: 542 RVA: 0x00024534 File Offset: 0x00022734
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


        // (get) Token: 0x0600021F RID: 543 RVA: 0x00024590 File Offset: 0x00022790
        // (set) Token: 0x06000220 RID: 544 RVA: 0x000245A8 File Offset: 0x000227A8
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


        // (get) Token: 0x06000221 RID: 545 RVA: 0x000245B4 File Offset: 0x000227B4
        // (set) Token: 0x06000222 RID: 546 RVA: 0x000245CC File Offset: 0x000227CC
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


        // (get) Token: 0x06000223 RID: 547 RVA: 0x00024628 File Offset: 0x00022828
        // (set) Token: 0x06000224 RID: 548 RVA: 0x00024640 File Offset: 0x00022840
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


        // (get) Token: 0x06000225 RID: 549 RVA: 0x0002469C File Offset: 0x0002289C
        // (set) Token: 0x06000226 RID: 550 RVA: 0x000246B4 File Offset: 0x000228B4
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


        // (get) Token: 0x06000227 RID: 551 RVA: 0x00024710 File Offset: 0x00022910
        // (set) Token: 0x06000228 RID: 552 RVA: 0x00024728 File Offset: 0x00022928
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


        // (get) Token: 0x06000229 RID: 553 RVA: 0x00024784 File Offset: 0x00022984
        // (set) Token: 0x0600022A RID: 554 RVA: 0x0002479C File Offset: 0x0002299C
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


        // (get) Token: 0x0600022B RID: 555 RVA: 0x000247F8 File Offset: 0x000229F8
        // (set) Token: 0x0600022C RID: 556 RVA: 0x00024810 File Offset: 0x00022A10
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


        // (get) Token: 0x0600022D RID: 557 RVA: 0x0002481C File Offset: 0x00022A1C
        // (set) Token: 0x0600022E RID: 558 RVA: 0x00024834 File Offset: 0x00022A34
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


        // (get) Token: 0x0600022F RID: 559 RVA: 0x00024890 File Offset: 0x00022A90
        // (set) Token: 0x06000230 RID: 560 RVA: 0x000248A8 File Offset: 0x00022AA8
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


        // (get) Token: 0x06000231 RID: 561 RVA: 0x00024904 File Offset: 0x00022B04
        // (set) Token: 0x06000232 RID: 562 RVA: 0x0002491C File Offset: 0x00022B1C
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


        // (get) Token: 0x06000233 RID: 563 RVA: 0x00024978 File Offset: 0x00022B78
        // (set) Token: 0x06000234 RID: 564 RVA: 0x00024990 File Offset: 0x00022B90
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


        // (get) Token: 0x06000235 RID: 565 RVA: 0x000249EC File Offset: 0x00022BEC
        // (set) Token: 0x06000236 RID: 566 RVA: 0x00024A04 File Offset: 0x00022C04
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


        // (get) Token: 0x06000237 RID: 567 RVA: 0x00024A60 File Offset: 0x00022C60
        // (set) Token: 0x06000238 RID: 568 RVA: 0x00024A78 File Offset: 0x00022C78
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


        // (get) Token: 0x06000239 RID: 569 RVA: 0x00024AD4 File Offset: 0x00022CD4
        // (set) Token: 0x0600023A RID: 570 RVA: 0x00024AEC File Offset: 0x00022CEC
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


        // (get) Token: 0x0600023B RID: 571 RVA: 0x00024B48 File Offset: 0x00022D48
        // (set) Token: 0x0600023C RID: 572 RVA: 0x00024B60 File Offset: 0x00022D60
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


        // (get) Token: 0x0600023D RID: 573 RVA: 0x00024BBC File Offset: 0x00022DBC
        // (set) Token: 0x0600023E RID: 574 RVA: 0x00024BD4 File Offset: 0x00022DD4
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


        // (get) Token: 0x0600023F RID: 575 RVA: 0x00024C58 File Offset: 0x00022E58
        // (set) Token: 0x06000240 RID: 576 RVA: 0x00024C70 File Offset: 0x00022E70
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


        // (get) Token: 0x06000241 RID: 577 RVA: 0x00024C7C File Offset: 0x00022E7C
        // (set) Token: 0x06000242 RID: 578 RVA: 0x00024C94 File Offset: 0x00022E94
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


        // (get) Token: 0x06000243 RID: 579 RVA: 0x00024CF0 File Offset: 0x00022EF0
        // (set) Token: 0x06000244 RID: 580 RVA: 0x00024D08 File Offset: 0x00022F08
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


        // (get) Token: 0x06000245 RID: 581 RVA: 0x00024D64 File Offset: 0x00022F64
        // (set) Token: 0x06000246 RID: 582 RVA: 0x00024D7C File Offset: 0x00022F7C
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


        // (get) Token: 0x06000247 RID: 583 RVA: 0x00024DD8 File Offset: 0x00022FD8
        // (set) Token: 0x06000248 RID: 584 RVA: 0x00024DF0 File Offset: 0x00022FF0
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


        // (get) Token: 0x06000249 RID: 585 RVA: 0x00024E4C File Offset: 0x0002304C
        // (set) Token: 0x0600024A RID: 586 RVA: 0x00024E64 File Offset: 0x00023064
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


        // (get) Token: 0x0600024B RID: 587 RVA: 0x00024EC0 File Offset: 0x000230C0
        // (set) Token: 0x0600024C RID: 588 RVA: 0x00024ED8 File Offset: 0x000230D8
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


        // (get) Token: 0x0600024D RID: 589 RVA: 0x00024F34 File Offset: 0x00023134
        // (set) Token: 0x0600024E RID: 590 RVA: 0x00024F4C File Offset: 0x0002314C
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


        // (get) Token: 0x0600024F RID: 591 RVA: 0x00024FA8 File Offset: 0x000231A8
        // (set) Token: 0x06000250 RID: 592 RVA: 0x00024FC0 File Offset: 0x000231C0
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


        // (get) Token: 0x06000251 RID: 593 RVA: 0x0002501C File Offset: 0x0002321C
        // (set) Token: 0x06000252 RID: 594 RVA: 0x00025034 File Offset: 0x00023234
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


        // (get) Token: 0x06000253 RID: 595 RVA: 0x00025090 File Offset: 0x00023290
        // (set) Token: 0x06000254 RID: 596 RVA: 0x000250A8 File Offset: 0x000232A8
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


        // (get) Token: 0x06000255 RID: 597 RVA: 0x000250B4 File Offset: 0x000232B4
        // (set) Token: 0x06000256 RID: 598 RVA: 0x000250CC File Offset: 0x000232CC
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


        // (get) Token: 0x06000257 RID: 599 RVA: 0x000250D8 File Offset: 0x000232D8
        // (set) Token: 0x06000258 RID: 600 RVA: 0x000250F0 File Offset: 0x000232F0
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


        // (get) Token: 0x06000259 RID: 601 RVA: 0x000250FC File Offset: 0x000232FC
        // (set) Token: 0x0600025A RID: 602 RVA: 0x00025114 File Offset: 0x00023314
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


        // (get) Token: 0x0600025B RID: 603 RVA: 0x00025120 File Offset: 0x00023320
        // (set) Token: 0x0600025C RID: 604 RVA: 0x00025138 File Offset: 0x00023338
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


        // (get) Token: 0x0600025D RID: 605 RVA: 0x00025144 File Offset: 0x00023344
        // (set) Token: 0x0600025E RID: 606 RVA: 0x0002515C File Offset: 0x0002335C
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


        // (get) Token: 0x0600025F RID: 607 RVA: 0x00025168 File Offset: 0x00023368
        // (set) Token: 0x06000260 RID: 608 RVA: 0x00025180 File Offset: 0x00023380
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


        // (get) Token: 0x06000261 RID: 609 RVA: 0x0002518C File Offset: 0x0002338C
        // (set) Token: 0x06000262 RID: 610 RVA: 0x000251A4 File Offset: 0x000233A4
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


        // (get) Token: 0x06000263 RID: 611 RVA: 0x000251B0 File Offset: 0x000233B0
        // (set) Token: 0x06000264 RID: 612 RVA: 0x000251C8 File Offset: 0x000233C8
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


        // (get) Token: 0x06000265 RID: 613 RVA: 0x000251D4 File Offset: 0x000233D4
        // (set) Token: 0x06000266 RID: 614 RVA: 0x000251EC File Offset: 0x000233EC
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


        // (get) Token: 0x06000267 RID: 615 RVA: 0x000251F8 File Offset: 0x000233F8
        // (set) Token: 0x06000268 RID: 616 RVA: 0x00025210 File Offset: 0x00023410
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


        // (get) Token: 0x06000269 RID: 617 RVA: 0x0002521C File Offset: 0x0002341C
        // (set) Token: 0x0600026A RID: 618 RVA: 0x00025234 File Offset: 0x00023434
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


        // (get) Token: 0x0600026B RID: 619 RVA: 0x00025240 File Offset: 0x00023440
        // (set) Token: 0x0600026C RID: 620 RVA: 0x00025258 File Offset: 0x00023458
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


        // (get) Token: 0x0600026D RID: 621 RVA: 0x00025264 File Offset: 0x00023464
        // (set) Token: 0x0600026E RID: 622 RVA: 0x0002527C File Offset: 0x0002347C
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


        // (get) Token: 0x0600026F RID: 623 RVA: 0x00025288 File Offset: 0x00023488
        // (set) Token: 0x06000270 RID: 624 RVA: 0x000252A0 File Offset: 0x000234A0
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


        // (get) Token: 0x06000271 RID: 625 RVA: 0x000252AC File Offset: 0x000234AC
        // (set) Token: 0x06000272 RID: 626 RVA: 0x000252C4 File Offset: 0x000234C4
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


        // (get) Token: 0x06000273 RID: 627 RVA: 0x000252D0 File Offset: 0x000234D0
        // (set) Token: 0x06000274 RID: 628 RVA: 0x000252E8 File Offset: 0x000234E8
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


        // (get) Token: 0x06000275 RID: 629 RVA: 0x000252F4 File Offset: 0x000234F4
        // (set) Token: 0x06000276 RID: 630 RVA: 0x0002530C File Offset: 0x0002350C
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


        // (get) Token: 0x06000277 RID: 631 RVA: 0x00025318 File Offset: 0x00023518
        // (set) Token: 0x06000278 RID: 632 RVA: 0x00025330 File Offset: 0x00023530
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


        // (get) Token: 0x06000279 RID: 633 RVA: 0x0002533C File Offset: 0x0002353C
        // (set) Token: 0x0600027A RID: 634 RVA: 0x00025354 File Offset: 0x00023554
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


        // (get) Token: 0x0600027B RID: 635 RVA: 0x00025360 File Offset: 0x00023560
        // (set) Token: 0x0600027C RID: 636 RVA: 0x00025378 File Offset: 0x00023578
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


        // (get) Token: 0x0600027D RID: 637 RVA: 0x00025384 File Offset: 0x00023584
        // (set) Token: 0x0600027E RID: 638 RVA: 0x0002539C File Offset: 0x0002359C
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


        // (get) Token: 0x0600027F RID: 639 RVA: 0x000253A8 File Offset: 0x000235A8
        // (set) Token: 0x06000280 RID: 640 RVA: 0x000253C0 File Offset: 0x000235C0
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


        // (get) Token: 0x06000281 RID: 641 RVA: 0x000253CC File Offset: 0x000235CC
        // (set) Token: 0x06000282 RID: 642 RVA: 0x000253E4 File Offset: 0x000235E4
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


        // (get) Token: 0x06000283 RID: 643 RVA: 0x000253F0 File Offset: 0x000235F0
        // (set) Token: 0x06000284 RID: 644 RVA: 0x00025408 File Offset: 0x00023608
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


        // (get) Token: 0x06000285 RID: 645 RVA: 0x00025414 File Offset: 0x00023614
        // (set) Token: 0x06000286 RID: 646 RVA: 0x0002542C File Offset: 0x0002362C
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


        // (get) Token: 0x06000287 RID: 647 RVA: 0x00025438 File Offset: 0x00023638
        // (set) Token: 0x06000288 RID: 648 RVA: 0x00025450 File Offset: 0x00023650
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


        // (get) Token: 0x06000289 RID: 649 RVA: 0x0002545C File Offset: 0x0002365C
        // (set) Token: 0x0600028A RID: 650 RVA: 0x00025474 File Offset: 0x00023674
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


        // (get) Token: 0x0600028B RID: 651 RVA: 0x00025480 File Offset: 0x00023680
        // (set) Token: 0x0600028C RID: 652 RVA: 0x00025498 File Offset: 0x00023698
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


        // (get) Token: 0x0600028D RID: 653 RVA: 0x000254A4 File Offset: 0x000236A4
        // (set) Token: 0x0600028E RID: 654 RVA: 0x000254BC File Offset: 0x000236BC
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


        // (get) Token: 0x0600028F RID: 655 RVA: 0x000254C8 File Offset: 0x000236C8
        // (set) Token: 0x06000290 RID: 656 RVA: 0x000254E0 File Offset: 0x000236E0
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


        // (get) Token: 0x06000291 RID: 657 RVA: 0x000254EC File Offset: 0x000236EC
        // (set) Token: 0x06000292 RID: 658 RVA: 0x00025504 File Offset: 0x00023704
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


        // (get) Token: 0x06000293 RID: 659 RVA: 0x00025510 File Offset: 0x00023710
        // (set) Token: 0x06000294 RID: 660 RVA: 0x00025528 File Offset: 0x00023728
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


        // (get) Token: 0x06000295 RID: 661 RVA: 0x00025534 File Offset: 0x00023734
        // (set) Token: 0x06000296 RID: 662 RVA: 0x0002554C File Offset: 0x0002374C
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


        // (get) Token: 0x06000297 RID: 663 RVA: 0x00025558 File Offset: 0x00023758
        // (set) Token: 0x06000298 RID: 664 RVA: 0x00025570 File Offset: 0x00023770
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


        // (get) Token: 0x06000299 RID: 665 RVA: 0x0002557C File Offset: 0x0002377C
        // (set) Token: 0x0600029A RID: 666 RVA: 0x00025594 File Offset: 0x00023794
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


        // (get) Token: 0x0600029B RID: 667 RVA: 0x000255A0 File Offset: 0x000237A0
        // (set) Token: 0x0600029C RID: 668 RVA: 0x000255B8 File Offset: 0x000237B8
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


        // (get) Token: 0x0600029D RID: 669 RVA: 0x000255C4 File Offset: 0x000237C4
        // (set) Token: 0x0600029E RID: 670 RVA: 0x000255DC File Offset: 0x000237DC
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


        // (get) Token: 0x0600029F RID: 671 RVA: 0x000255E8 File Offset: 0x000237E8
        // (set) Token: 0x060002A0 RID: 672 RVA: 0x00025600 File Offset: 0x00023800
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


        // (get) Token: 0x060002A1 RID: 673 RVA: 0x0002560C File Offset: 0x0002380C
        // (set) Token: 0x060002A2 RID: 674 RVA: 0x00025624 File Offset: 0x00023824
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


        // (get) Token: 0x060002A3 RID: 675 RVA: 0x00025630 File Offset: 0x00023830
        // (set) Token: 0x060002A4 RID: 676 RVA: 0x00025648 File Offset: 0x00023848
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


        // (get) Token: 0x060002A5 RID: 677 RVA: 0x00025654 File Offset: 0x00023854
        // (set) Token: 0x060002A6 RID: 678 RVA: 0x0002566C File Offset: 0x0002386C
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


        // (get) Token: 0x060002A7 RID: 679 RVA: 0x00025678 File Offset: 0x00023878
        // (set) Token: 0x060002A8 RID: 680 RVA: 0x00025690 File Offset: 0x00023890
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


        // (get) Token: 0x060002A9 RID: 681 RVA: 0x0002569C File Offset: 0x0002389C
        // (set) Token: 0x060002AA RID: 682 RVA: 0x000256B4 File Offset: 0x000238B4
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


        // (get) Token: 0x060002AB RID: 683 RVA: 0x000256C0 File Offset: 0x000238C0
        // (set) Token: 0x060002AC RID: 684 RVA: 0x000256D8 File Offset: 0x000238D8
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


        // (get) Token: 0x060002AD RID: 685 RVA: 0x000256E4 File Offset: 0x000238E4
        // (set) Token: 0x060002AE RID: 686 RVA: 0x000256FC File Offset: 0x000238FC
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


        // (get) Token: 0x060002AF RID: 687 RVA: 0x00025708 File Offset: 0x00023908
        // (set) Token: 0x060002B0 RID: 688 RVA: 0x00025720 File Offset: 0x00023920
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


        // (get) Token: 0x060002B1 RID: 689 RVA: 0x0002572C File Offset: 0x0002392C
        // (set) Token: 0x060002B2 RID: 690 RVA: 0x00025744 File Offset: 0x00023944
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


        // (get) Token: 0x060002B3 RID: 691 RVA: 0x00025750 File Offset: 0x00023950
        // (set) Token: 0x060002B4 RID: 692 RVA: 0x00025768 File Offset: 0x00023968
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


        // (get) Token: 0x060002B5 RID: 693 RVA: 0x00025774 File Offset: 0x00023974
        // (set) Token: 0x060002B6 RID: 694 RVA: 0x0002578C File Offset: 0x0002398C
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


        // (get) Token: 0x060002B7 RID: 695 RVA: 0x00025798 File Offset: 0x00023998
        // (set) Token: 0x060002B8 RID: 696 RVA: 0x000257B0 File Offset: 0x000239B0
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


        // (get) Token: 0x060002B9 RID: 697 RVA: 0x000257BC File Offset: 0x000239BC
        // (set) Token: 0x060002BA RID: 698 RVA: 0x000257D4 File Offset: 0x000239D4
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


        // (get) Token: 0x060002BB RID: 699 RVA: 0x000257E0 File Offset: 0x000239E0
        // (set) Token: 0x060002BC RID: 700 RVA: 0x000257F8 File Offset: 0x000239F8
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


        // (get) Token: 0x060002BD RID: 701 RVA: 0x00025804 File Offset: 0x00023A04
        // (set) Token: 0x060002BE RID: 702 RVA: 0x0002581C File Offset: 0x00023A1C
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


        // (get) Token: 0x060002BF RID: 703 RVA: 0x00025828 File Offset: 0x00023A28
        // (set) Token: 0x060002C0 RID: 704 RVA: 0x00025840 File Offset: 0x00023A40
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


        // (get) Token: 0x060002C1 RID: 705 RVA: 0x0002589C File Offset: 0x00023A9C
        // (set) Token: 0x060002C2 RID: 706 RVA: 0x000258B4 File Offset: 0x00023AB4
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


        // (get) Token: 0x060002C3 RID: 707 RVA: 0x000258C0 File Offset: 0x00023AC0
        // (set) Token: 0x060002C4 RID: 708 RVA: 0x000258D8 File Offset: 0x00023AD8
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


        // (get) Token: 0x060002C5 RID: 709 RVA: 0x00025934 File Offset: 0x00023B34
        // (set) Token: 0x060002C6 RID: 710 RVA: 0x0002594C File Offset: 0x00023B4C
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


        // (get) Token: 0x060002C7 RID: 711 RVA: 0x00025958 File Offset: 0x00023B58
        // (set) Token: 0x060002C8 RID: 712 RVA: 0x00025970 File Offset: 0x00023B70
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


        // (get) Token: 0x060002C9 RID: 713 RVA: 0x000259CC File Offset: 0x00023BCC
        // (set) Token: 0x060002CA RID: 714 RVA: 0x000259E4 File Offset: 0x00023BE4
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


        // (get) Token: 0x060002CB RID: 715 RVA: 0x00025A40 File Offset: 0x00023C40
        // (set) Token: 0x060002CC RID: 716 RVA: 0x00025A58 File Offset: 0x00023C58
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


        // (get) Token: 0x060002CD RID: 717 RVA: 0x00025A64 File Offset: 0x00023C64
        // (set) Token: 0x060002CE RID: 718 RVA: 0x00025A7C File Offset: 0x00023C7C
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


        // (get) Token: 0x060002CF RID: 719 RVA: 0x00025A88 File Offset: 0x00023C88
        // (set) Token: 0x060002D0 RID: 720 RVA: 0x00025AA0 File Offset: 0x00023CA0
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


        // (get) Token: 0x060002D1 RID: 721 RVA: 0x00025AAC File Offset: 0x00023CAC
        // (set) Token: 0x060002D2 RID: 722 RVA: 0x00025AC4 File Offset: 0x00023CC4
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


        // (get) Token: 0x060002D3 RID: 723 RVA: 0x00025AD0 File Offset: 0x00023CD0
        // (set) Token: 0x060002D4 RID: 724 RVA: 0x00025AE8 File Offset: 0x00023CE8
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


        // (get) Token: 0x060002D5 RID: 725 RVA: 0x00025AF4 File Offset: 0x00023CF4
        // (set) Token: 0x060002D6 RID: 726 RVA: 0x00025B0C File Offset: 0x00023D0C
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


        // (get) Token: 0x060002D7 RID: 727 RVA: 0x00025B18 File Offset: 0x00023D18
        // (set) Token: 0x060002D8 RID: 728 RVA: 0x00025B30 File Offset: 0x00023D30
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


        // (get) Token: 0x060002D9 RID: 729 RVA: 0x00025B3C File Offset: 0x00023D3C
        // (set) Token: 0x060002DA RID: 730 RVA: 0x00025B54 File Offset: 0x00023D54
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


        // (get) Token: 0x060002DB RID: 731 RVA: 0x00025B60 File Offset: 0x00023D60
        // (set) Token: 0x060002DC RID: 732 RVA: 0x00025B78 File Offset: 0x00023D78
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


        // (get) Token: 0x060002DD RID: 733 RVA: 0x00025B84 File Offset: 0x00023D84
        // (set) Token: 0x060002DE RID: 734 RVA: 0x00025B9C File Offset: 0x00023D9C
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


        // (get) Token: 0x060002DF RID: 735 RVA: 0x00025BA8 File Offset: 0x00023DA8
        // (set) Token: 0x060002E0 RID: 736 RVA: 0x00025BC0 File Offset: 0x00023DC0
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


        // (get) Token: 0x060002E1 RID: 737 RVA: 0x00025BCC File Offset: 0x00023DCC
        // (set) Token: 0x060002E2 RID: 738 RVA: 0x00025BE4 File Offset: 0x00023DE4
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


        // (get) Token: 0x060002E3 RID: 739 RVA: 0x00025BF0 File Offset: 0x00023DF0
        // (set) Token: 0x060002E4 RID: 740 RVA: 0x00025C08 File Offset: 0x00023E08
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


        // (get) Token: 0x060002E5 RID: 741 RVA: 0x00025C14 File Offset: 0x00023E14
        // (set) Token: 0x060002E6 RID: 742 RVA: 0x00025C2C File Offset: 0x00023E2C
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


        // (get) Token: 0x060002E7 RID: 743 RVA: 0x00025C38 File Offset: 0x00023E38
        // (set) Token: 0x060002E8 RID: 744 RVA: 0x00025C50 File Offset: 0x00023E50
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


        // (get) Token: 0x060002E9 RID: 745 RVA: 0x00025C5C File Offset: 0x00023E5C
        // (set) Token: 0x060002EA RID: 746 RVA: 0x00025C74 File Offset: 0x00023E74
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


        // (get) Token: 0x060002EB RID: 747 RVA: 0x00025C80 File Offset: 0x00023E80
        // (set) Token: 0x060002EC RID: 748 RVA: 0x00025C98 File Offset: 0x00023E98
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


        // (get) Token: 0x060002ED RID: 749 RVA: 0x00025CA4 File Offset: 0x00023EA4
        // (set) Token: 0x060002EE RID: 750 RVA: 0x00025CBC File Offset: 0x00023EBC
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


        // (get) Token: 0x060002EF RID: 751 RVA: 0x00025CC8 File Offset: 0x00023EC8
        // (set) Token: 0x060002F0 RID: 752 RVA: 0x00025CE0 File Offset: 0x00023EE0
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


        // (get) Token: 0x060002F1 RID: 753 RVA: 0x00025CEC File Offset: 0x00023EEC
        // (set) Token: 0x060002F2 RID: 754 RVA: 0x00025D04 File Offset: 0x00023F04
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


        // (get) Token: 0x060002F3 RID: 755 RVA: 0x00025D10 File Offset: 0x00023F10
        // (set) Token: 0x060002F4 RID: 756 RVA: 0x00025D28 File Offset: 0x00023F28
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


        // (get) Token: 0x060002F5 RID: 757 RVA: 0x00025D34 File Offset: 0x00023F34
        // (set) Token: 0x060002F6 RID: 758 RVA: 0x00025D4C File Offset: 0x00023F4C
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


        // (get) Token: 0x060002F7 RID: 759 RVA: 0x00025D58 File Offset: 0x00023F58
        // (set) Token: 0x060002F8 RID: 760 RVA: 0x00025D70 File Offset: 0x00023F70
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


        // (get) Token: 0x060002F9 RID: 761 RVA: 0x00025D7C File Offset: 0x00023F7C
        // (set) Token: 0x060002FA RID: 762 RVA: 0x00025D94 File Offset: 0x00023F94
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


        private void btnBaseReset_Click(object sender, EventArgs e)
        {
            this.udBaseToHit.Value = 75m;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Hide();
        }


        private void btnFontColour_Click(object sender, EventArgs e)
        {
            new frmColourSettings().ShowDialog();
        }


        private void btnForceUpdate_Click(object sender, EventArgs e)
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


        private void btnIOReset_Click(object sender, EventArgs e)
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


        private void btnOK_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            this.StoreControls();
            this.DoMiscUpdates();
            base.Hide();
        }


        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            this.fbdSave.SelectedPath = this.lblSaveFolder.Text;
            if (this.fbdSave.ShowDialog() == DialogResult.OK)
            {
                this.lblSaveFolder.Text = this.fbdSave.SelectedPath;
            }
        }


        private void btnSaveFolderReset_Click(object sender, EventArgs e)
        {
            MidsContext.Config.CreateDefaultSaveFolder();
            MidsContext.Config.DefaultSaveFolder = OS.GetDefaultSaveFolder();
            this.lblSaveFolder.Text = MidsContext.Config.DefaultSaveFolder;
        }


        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void btnUpdate_Click(object sender, EventArgs e)
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


        private void btnUpdatePathReset_Click(object sender, EventArgs e)
        {
            this.txtUpdatePath.Text = "http://repo.cohtitan.com/mids_updates/";
        }


        private void clbSuppression_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] values = (int[])Enum.GetValues(MidsContext.Config.Suppression.GetType());
            MidsContext.Config.Suppression = Enums.eSuppress.None;
            int num = this.clbSuppression.CheckedIndices.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                MidsContext.Config.Suppression += values[this.clbSuppression.CheckedIndices[index]];
            }
        }


        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.defActs[this.listScenarios.SelectedIndex] = (short)this.cmbAction.SelectedIndex;
        }


        private void csAdd_Click(object sender, EventArgs e)
        {
            MidsContext.Config.Export.AddScheme();
            this.csPopulateList(MidsContext.Config.Export.ColorSchemes.Length - 1);
        }


        private void csBtnEdit_Click(object sender, EventArgs e)
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


        private void csDelete_Click(object sender, EventArgs e)
        {
            if (this.csList.Items.Count > 0 && Interaction.MsgBox("Delete " + this.csList.SelectedItem.ToString() + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.RemoveScheme(this.csList.SelectedIndex);
                this.csPopulateList(-1);
            }
        }


        private void csList_KeyPress(object sender, KeyPressEventArgs e)
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


        private void csPopulateList(int HighlightID = -1)
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


        private void csReset_Click(object sender, EventArgs e)
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


        private void fcAdd_Click(object sender, EventArgs e)
        {
            MidsContext.Config.Export.AddCodes();
            this.fcPopulateList(MidsContext.Config.Export.FormatCode.Length - 1);
        }


        private void fcBoldOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].BoldOff = this.fcBoldOff.Text;
            }
        }


        private void fcBoldOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].BoldOn = this.fcBoldOn.Text;
            }
        }


        private void fcColorOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ColourOff = this.fcColorOff.Text;
            }
        }


        private void fcColorOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ColourOn = this.fcColorOn.Text;
            }
        }


        private void fcDelete_Click(object sender, EventArgs e)
        {
            if (this.fcList.Items.Count > 0 && Interaction.MsgBox("Delete " + this.fcList.SelectedItem.ToString() + "?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.RemoveCodes(this.fcList.SelectedIndex);
                this.fcPopulateList(-1);
            }
        }


        private void fcDisplay()
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


        private void fcItalicOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ItalicOff = this.fcItalicOff.Text;
            }
        }


        private void fcItalicOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].ItalicOn = this.fcItalicOn.Text;
            }
        }


        private void fcList_KeyPress(object sender, KeyPressEventArgs e)
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


        private void fcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fcDisplay();
        }


        private void fcNotes_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].Notes = this.fcNotes.Text;
            }
        }


        private void fcPopulateList(int HighlightID = -1)
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


        private void fcReset_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will remove all of the formatting code sets and replace them with the default set. Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                MidsContext.Config.Export.ResetCodesToDefaults();
                this.fcPopulateList(-1);
            }
        }


        private void fcSet_Click(object sender, EventArgs e)
        {
            if (this.fcList.SelectedIndex >= 0)
            {
                MidsContext.Config.Export.FormatCode[this.fcList.SelectedIndex].Name = this.fcName.Text;
                this.fcPopulateList(this.fcList.SelectedIndex);
            }
        }


        private void fcTextOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].SizeOff = this.fcTextOff.Text;
            }
        }


        private void fcTextOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].SizeOn = this.fcTextOn.Text;
            }
        }


        private void fcUnderlineOff_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].UnderlineOff = this.fcUnderlineOff.Text;
            }
        }


        private void fcUnderlineOn_TextChanged(object sender, EventArgs e)
        {
            if (!(this.fcList.SelectedIndex < 0 | this.fcNoUpdate))
            {
                ExportConfig.FormatCodes[] formatCode = MidsContext.Config.Export.FormatCode;
                int selectedIndex = this.fcList.SelectedIndex;
                formatCode[selectedIndex].UnderlineOn = this.fcUnderlineOn.Text;
            }
        }


        private void fcWSSpace_CheckedChanged(object sender, EventArgs e)
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


        private void frmCalcOpt_Closing(object sender, CancelEventArgs e)
        {
            if (base.DialogResult == DialogResult.Abort)
            {
                e.Cancel = true;
            }
        }


        private void frmCalcOpt_Load(object sender, EventArgs e)
        {
            this.setupScenarios();
            this.SetControls();
            this.csPopulateList(-1);
            this.fcPopulateList(-1);
            this.PopulateSuppression();
            this.SetTips();
        }


        private void listScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblExample.Text = this.scenarioExample[this.listScenarios.SelectedIndex];
            this.cmbAction.Items.Clear();
            this.cmbAction.Items.AddRange(this.scenActs[this.listScenarios.SelectedIndex]);
            this.cmbAction.SelectedIndex = (int)this.defActs[this.listScenarios.SelectedIndex];
        }


        private void optDO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optDO.Checked)
            {
                this.optEnh.Text = "Dual Origin";
            }
        }


        private void optSO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optSO.Checked)
            {
                this.optEnh.Text = "Single Origin";
            }
        }


        private void optTO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.optTO.Checked)
            {
                this.optEnh.Text = "Training Origin";
            }
        }


        private void PopulateSuppression()
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


        private void SetControls()
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


        private void setupScenarios()
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


        private void StoreControls()
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
        private Button _btnBaseReset;


        [AccessedThroughProperty("btnCancel")]
        private Button _btnCancel;


        [AccessedThroughProperty("btnFontColour")]
        private Button _btnFontColour;


        [AccessedThroughProperty("btnForceUpdate")]
        private Button _btnForceUpdate;


        [AccessedThroughProperty("btnIOReset")]
        private Button _btnIOReset;


        [AccessedThroughProperty("btnOK")]
        private Button _btnOK;


        [AccessedThroughProperty("btnSaveFolder")]
        private Button _btnSaveFolder;


        [AccessedThroughProperty("btnSaveFolderReset")]
        private Button _btnSaveFolderReset;


        [AccessedThroughProperty("btnUpdate")]
        private Button _btnUpdate;


        [AccessedThroughProperty("btnUpdatePathReset")]
        private Button _btnUpdatePathReset;


        [AccessedThroughProperty("cbEnhLevel")]
        private ComboBox _cbEnhLevel;


        [AccessedThroughProperty("chkColorInherent")]
        private CheckBox _chkColorInherent;


        [AccessedThroughProperty("chkColourPrint")]
        private CheckBox _chkColourPrint;


        [AccessedThroughProperty("chkHighVis")]
        private CheckBox _chkHighVis;


        [AccessedThroughProperty("chkIOEffects")]
        private CheckBox _chkIOEffects;


        [AccessedThroughProperty("chkIOLevel")]
        private CheckBox _chkIOLevel;


        [AccessedThroughProperty("chkIOPrintLevels")]
        private CheckBox _chkIOPrintLevels;


        [AccessedThroughProperty("chkLoadLastFile")]
        private CheckBox _chkLoadLastFile;


        [AccessedThroughProperty("chkMiddle")]
        private CheckBox _chkMiddle;


        [AccessedThroughProperty("chkNoTips")]
        private CheckBox _chkNoTips;


        [AccessedThroughProperty("chkRelSignOnly")]
        private CheckBox _chkRelSignOnly;


        [AccessedThroughProperty("chkSetBonus")]
        private CheckBox _chkSetBonus;


        [AccessedThroughProperty("chkShowAlphaPopup")]
        private CheckBox _chkShowAlphaPopup;


        [AccessedThroughProperty("chkStatBold")]
        private CheckBox _chkStatBold;


        [AccessedThroughProperty("chkTextBold")]
        private CheckBox _chkTextBold;


        [AccessedThroughProperty("chkUpdates")]
        private CheckBox _chkUpdates;


        [AccessedThroughProperty("chkUseArcanaTime")]
        private CheckBox _chkUseArcanaTime;


        [AccessedThroughProperty("chkVillainColour")]
        private CheckBox _chkVillainColour;


        [AccessedThroughProperty("clbSuppression")]
        private CheckedListBox _clbSuppression;


        [AccessedThroughProperty("cmbAction")]
        private ComboBox _cmbAction;


        [AccessedThroughProperty("cPicker")]
        private ColorDialog _cPicker;


        [AccessedThroughProperty("csAdd")]
        private Button _csAdd;


        [AccessedThroughProperty("csBtnEdit")]
        private Button _csBtnEdit;


        [AccessedThroughProperty("csDelete")]
        private Button _csDelete;


        [AccessedThroughProperty("csList")]
        private ListBox _csList;


        [AccessedThroughProperty("csReset")]
        private Button _csReset;


        [AccessedThroughProperty("fbdSave")]
        private FolderBrowserDialog _fbdSave;


        [AccessedThroughProperty("fcAdd")]
        private Button _fcAdd;


        [AccessedThroughProperty("fcBoldOff")]
        private TextBox _fcBoldOff;


        [AccessedThroughProperty("fcBoldOn")]
        private TextBox _fcBoldOn;


        [AccessedThroughProperty("fcColorOff")]
        private TextBox _fcColorOff;


        [AccessedThroughProperty("fcColorOn")]
        private TextBox _fcColorOn;


        [AccessedThroughProperty("fcDelete")]
        private Button _fcDelete;


        [AccessedThroughProperty("fcItalicOff")]
        private TextBox _fcItalicOff;


        [AccessedThroughProperty("fcItalicOn")]
        private TextBox _fcItalicOn;


        [AccessedThroughProperty("fcList")]
        private ListBox _fcList;


        [AccessedThroughProperty("fcName")]
        private TextBox _fcName;


        [AccessedThroughProperty("fcNotes")]
        private TextBox _fcNotes;


        [AccessedThroughProperty("fcReset")]
        private Button _fcReset;


        [AccessedThroughProperty("fcSet")]
        private Button _fcSet;


        [AccessedThroughProperty("fcTextOff")]
        private TextBox _fcTextOff;


        [AccessedThroughProperty("fcTextOn")]
        private TextBox _fcTextOn;


        [AccessedThroughProperty("fcUnderlineOff")]
        private TextBox _fcUnderlineOff;


        [AccessedThroughProperty("fcUnderlineOn")]
        private TextBox _fcUnderlineOn;


        [AccessedThroughProperty("fcWSSpace")]
        private RadioButton _fcWSSpace;


        [AccessedThroughProperty("fcWSTab")]
        private RadioButton _fcWSTab;


        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox10")]
        private GroupBox _GroupBox10;


        [AccessedThroughProperty("GroupBox11")]
        private GroupBox _GroupBox11;


        [AccessedThroughProperty("GroupBox12")]
        private GroupBox _GroupBox12;


        [AccessedThroughProperty("GroupBox13")]
        private GroupBox _GroupBox13;


        [AccessedThroughProperty("GroupBox14")]
        private GroupBox _GroupBox14;


        [AccessedThroughProperty("GroupBox15")]
        private GroupBox _GroupBox15;


        [AccessedThroughProperty("GroupBox16")]
        private GroupBox _GroupBox16;


        [AccessedThroughProperty("GroupBox17")]
        private GroupBox _GroupBox17;


        [AccessedThroughProperty("GroupBox2")]
        private GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        private GroupBox _GroupBox3;


        [AccessedThroughProperty("GroupBox4")]
        private GroupBox _GroupBox4;


        [AccessedThroughProperty("GroupBox5")]
        private GroupBox _GroupBox5;


        [AccessedThroughProperty("GroupBox6")]
        private GroupBox _GroupBox6;


        [AccessedThroughProperty("GroupBox7")]
        private GroupBox _GroupBox7;


        [AccessedThroughProperty("GroupBox8")]
        private GroupBox _GroupBox8;


        [AccessedThroughProperty("GroupBox9")]
        private GroupBox _GroupBox9;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label10")]
        private Label _Label10;


        [AccessedThroughProperty("Label11")]
        private Label _Label11;


        [AccessedThroughProperty("Label12")]
        private Label _Label12;


        [AccessedThroughProperty("Label13")]
        private Label _Label13;


        [AccessedThroughProperty("Label14")]
        private Label _Label14;


        [AccessedThroughProperty("Label15")]
        private Label _Label15;


        [AccessedThroughProperty("Label16")]
        private Label _Label16;


        [AccessedThroughProperty("Label19")]
        private Label _Label19;


        [AccessedThroughProperty("Label2")]
        private Label _Label2;


        [AccessedThroughProperty("Label20")]
        private Label _Label20;


        [AccessedThroughProperty("Label21")]
        private Label _Label21;


        [AccessedThroughProperty("Label22")]
        private Label _Label22;


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


        [AccessedThroughProperty("Label29")]
        private Label _Label29;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label30")]
        private Label _Label30;


        [AccessedThroughProperty("Label31")]
        private Label _Label31;


        [AccessedThroughProperty("Label32")]
        private Label _Label32;


        [AccessedThroughProperty("Label33")]
        private Label _Label33;


        [AccessedThroughProperty("Label34")]
        private Label _Label34;


        [AccessedThroughProperty("Label36")]
        private Label _Label36;


        [AccessedThroughProperty("Label37")]
        private Label _Label37;


        [AccessedThroughProperty("Label38")]
        private Label _Label38;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("Label40")]
        private Label _Label40;


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


        [AccessedThroughProperty("lblExample")]
        private Label _lblExample;


        [AccessedThroughProperty("lblSaveFolder")]
        private Label _lblSaveFolder;


        [AccessedThroughProperty("listScenarios")]
        private ListBox _listScenarios;


        [AccessedThroughProperty("myTip")]
        private ToolTip _myTip;


        [AccessedThroughProperty("optDO")]
        private RadioButton _optDO;


        [AccessedThroughProperty("optEnh")]
        private Label _optEnh;


        [AccessedThroughProperty("optSO")]
        private RadioButton _optSO;


        [AccessedThroughProperty("optTO")]
        private RadioButton _optTO;


        [AccessedThroughProperty("rbChanceAverage")]
        private RadioButton _rbChanceAverage;


        [AccessedThroughProperty("rbChanceIgnore")]
        private RadioButton _rbChanceIgnore;


        [AccessedThroughProperty("rbChanceMax")]
        private RadioButton _rbChanceMax;


        [AccessedThroughProperty("rbGraphSimple")]
        private RadioButton _rbGraphSimple;


        [AccessedThroughProperty("rbGraphStacked")]
        private RadioButton _rbGraphStacked;


        [AccessedThroughProperty("rbGraphTwoLine")]
        private RadioButton _rbGraphTwoLine;


        [AccessedThroughProperty("rbPvE")]
        private RadioButton _rbPvE;


        [AccessedThroughProperty("rbPvP")]
        private RadioButton _rbPvP;


        [AccessedThroughProperty("TabControl1")]
        private TabControl _TabControl1;


        [AccessedThroughProperty("TabPage1")]
        private TabPage _TabPage1;


        [AccessedThroughProperty("TabPage2")]
        private TabPage _TabPage2;


        [AccessedThroughProperty("TabPage3")]
        private TabPage _TabPage3;


        [AccessedThroughProperty("TabPage4")]
        private TabPage _TabPage4;


        [AccessedThroughProperty("TabPage5")]
        private TabPage _TabPage5;


        [AccessedThroughProperty("TabPage6")]
        private TabPage _TabPage6;


        [AccessedThroughProperty("TeamSize")]
        private NumericUpDown _TeamSize;


        [AccessedThroughProperty("txtUpdatePath")]
        private TextBox _txtUpdatePath;


        [AccessedThroughProperty("udBaseToHit")]
        private NumericUpDown _udBaseToHit;


        [AccessedThroughProperty("udExHigh")]
        private NumericUpDown _udExHigh;


        [AccessedThroughProperty("udExLow")]
        private NumericUpDown _udExLow;


        [AccessedThroughProperty("udForceLevel")]
        private NumericUpDown _udForceLevel;


        [AccessedThroughProperty("udIOLevel")]
        private NumericUpDown _udIOLevel;


        [AccessedThroughProperty("udRTFSize")]
        private NumericUpDown _udRTFSize;


        [AccessedThroughProperty("udStatSize")]
        private NumericUpDown _udStatSize;


        private short[] defActs;


        protected bool fcNoUpdate;


        public frmMain myParent;


        private string[][] scenActs;


        private string[] scenarioExample;
    }
}
