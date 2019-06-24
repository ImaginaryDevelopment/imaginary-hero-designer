
using Base.Data_Classes;
using Base.Display;
using Base.IO_Classes;
using Base.Master_Classes;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class frmMain : Form
    {
        [AccessedThroughProperty("accoladeButton")]
        ImageButton _accoladeButton;
        [AccessedThroughProperty("AccoladesWindowToolStripMenuItem")]
        ToolStripMenuItem _AccoladesWindowToolStripMenuItem;
        ToolStripMenuItem AdvancedToolStripMenuItem1;
        [AccessedThroughProperty("AutoArrangeAllSlotsToolStripMenuItem")]
        ToolStripMenuItem _AutoArrangeAllSlotsToolStripMenuItem;
        [AccessedThroughProperty("cbAncillary")]
        ComboBox _cbAncillary;
        [AccessedThroughProperty("cbAT")]
        ComboBox _cbAT;
        [AccessedThroughProperty("cbOrigin")]
        ComboBox _cbOrigin;
        [AccessedThroughProperty("cbPool0")]
        ComboBox _cbPool0;
        [AccessedThroughProperty("cbPool1")]
        ComboBox _cbPool1;
        [AccessedThroughProperty("cbPool2")]
        ComboBox _cbPool2;
        [AccessedThroughProperty("cbPool3")]
        ComboBox _cbPool3;
        [AccessedThroughProperty("cbPrimary")]
        ComboBox _cbPrimary;
        [AccessedThroughProperty("cbSecondary")]
        ComboBox _cbSecondary;
        ToolStripMenuItem CharacterToolStripMenuItem;
        [AccessedThroughProperty("dlgOpen")]
        OpenFileDialog _dlgOpen;
        [AccessedThroughProperty("dlgSave")]
        SaveFileDialog _dlgSave;
        [AccessedThroughProperty("dvAnchored")]
        DataView _dvAnchored;
        ToolStripMenuItem FileToolStripMenuItem;
        ToolStripMenuItem HelpToolStripMenuItem1;
        [AccessedThroughProperty("heroVillain")]
        ImageButton _heroVillain;
        [AccessedThroughProperty("I9Picker")]
        I9Picker _I9Picker;
        [AccessedThroughProperty("I9Popup")]
        ctlPopUp _I9Popup;
        ImageButton ibAccolade;
        [AccessedThroughProperty("ibMode")]
        ImageButton _ibMode;
        [AccessedThroughProperty("ibPopup")]
        ImageButton _ibPopup;
        [AccessedThroughProperty("ibPvX")]
        ImageButton _ibPvX;
        [AccessedThroughProperty("ibRecipe")]
        ImageButton _ibRecipe;
        [AccessedThroughProperty("ibSets")]
        ImageButton _ibSets;
        [AccessedThroughProperty("ibSlotLevels")]
        ImageButton _ibSlotLevels;
        [AccessedThroughProperty("ibTotals")]
        ImageButton _ibTotals;
        ImageButton ibVetPools;
        ToolStripMenuItem ImportExportToolStripMenuItem;
        [AccessedThroughProperty("incarnateButton")]
        ImageButton _incarnateButton;
        [AccessedThroughProperty("IncarnateWindowToolStripMenuItem")]
        ToolStripMenuItem _IncarnateWindowToolStripMenuItem;
        ToolStripMenuItem InGameRespecHelperToolStripMenuItem;
        GFXLabel lblAT;
        [AccessedThroughProperty("lblATLocked")]
        Label _lblATLocked;
        Label lblEpic;
        GFXLabel lblHero;
        [AccessedThroughProperty("lblLocked0")]
        Label _lblLocked0;
        [AccessedThroughProperty("lblLocked1")]
        Label _lblLocked1;
        [AccessedThroughProperty("lblLocked2")]
        Label _lblLocked2;
        [AccessedThroughProperty("lblLocked3")]
        Label _lblLocked3;
        [AccessedThroughProperty("lblLockedAncillary")]
        Label _lblLockedAncillary;
        [AccessedThroughProperty("lblLockedSecondary")]
        Label _lblLockedSecondary;
        GFXLabel lblName;
        GFXLabel lblOrigin;
        Label lblPool1;
        Label lblPool2;
        Label lblPool3;
        Label lblPool4;
        Label lblPrimary;
        Label lblSecondary;
        [AccessedThroughProperty("llAncillary")]
        ListLabelV2 _llAncillary;
        [AccessedThroughProperty("llPool0")]
        ListLabelV2 _llPool0;
        [AccessedThroughProperty("llPool1")]
        ListLabelV2 _llPool1;
        [AccessedThroughProperty("llPool2")]
        ListLabelV2 _llPool2;
        [AccessedThroughProperty("llPool3")]
        ListLabelV2 _llPool3;
        [AccessedThroughProperty("llPrimary")]
        ListLabelV2 _llPrimary;
        [AccessedThroughProperty("llSecondary")]
        ListLabelV2 _llSecondary;
        MenuStrip MenuBar;
        ToolStripMenuItem OptionsToolStripMenuItem;
        [AccessedThroughProperty("pbDynMode")]
        PictureBox _pbDynMode;
        [AccessedThroughProperty("pnlGFX")]
        PictureBox _pnlGFX;
        [AccessedThroughProperty("pnlGFXFlow")]
        FlowLayoutPanel _pnlGFXFlow;
        ToolStripMenuItem SetAllIOsToDefault35ToolStripMenuItem;
        ToolStripMenuItem SlotsToolStripMenuItem;
        [AccessedThroughProperty("TemporaryPowersWindowToolStripMenuItem")]
        ToolStripMenuItem _TemporaryPowersWindowToolStripMenuItem;
        [AccessedThroughProperty("tempPowersButton")]
        ImageButton _tempPowersButton;
        [AccessedThroughProperty("tlsDPA")]
        ToolStripMenuItem _tlsDPA;
        [AccessedThroughProperty("tmrGfx")]
        System.Windows.Forms.Timer _tmrGfx;
        ToolStripMenuItem ToolStripMenuItem1;
        ToolStripMenuItem ToolStripMenuItem2;
        ToolStripSeparator ToolStripMenuItem4;
        ToolStripSeparator ToolStripSeparator1;
        ToolStripSeparator ToolStripSeparator10;
        ToolStripSeparator ToolStripSeparator11;
        ToolStripSeparator ToolStripSeparator12;
        ToolStripSeparator ToolStripSeparator13;
        ToolStripSeparator ToolStripSeparator14;
        ToolStripSeparator ToolStripSeparator15;
        ToolStripSeparator ToolStripSeparator16;
        ToolStripSeparator ToolStripSeparator17;
        ToolStripSeparator ToolStripSeparator18;
        ToolStripSeparator ToolStripSeparator19;
        ToolStripSeparator ToolStripSeparator2;
        ToolStripSeparator ToolStripSeparator20;
        ToolStripSeparator ToolStripSeparator21;
        ToolStripSeparator ToolStripSeparator22;
        ToolStripSeparator ToolStripSeparator23;
        ToolStripSeparator ToolStripSeparator24;
        ToolStripSeparator ToolStripSeparator4;
        ToolStripSeparator ToolStripSeparator5;
        ToolStripSeparator ToolStripSeparator7;
        ToolStripSeparator ToolStripSeparator8;
        ToolStripSeparator ToolStripSeparator9;
        [AccessedThroughProperty("tsAbout")]
        ToolStripMenuItem _tsAbout;
        [AccessedThroughProperty("tsAdvDBEdit")]
        ToolStripMenuItem _tsAdvDBEdit;
        [AccessedThroughProperty("tsAdvFreshInstall")]
        ToolStripMenuItem _tsAdvFreshInstall;
        [AccessedThroughProperty("tsAdvResetTips")]
        ToolStripMenuItem _tsAdvResetTips;
        [AccessedThroughProperty("tsBug")]
        ToolStripMenuItem _tsBug;
        [AccessedThroughProperty("tsClearAllEnh")]
        ToolStripMenuItem _tsClearAllEnh;
        [AccessedThroughProperty("tsConfig")]
        ToolStripMenuItem _tsConfig;
        [AccessedThroughProperty("tsDonate")]
        ToolStripMenuItem _tsDonate;
        [AccessedThroughProperty("tsDynamic")]
        ToolStripMenuItem _tsDynamic;
        [AccessedThroughProperty("tsEnhToDO")]
        ToolStripMenuItem _tsEnhToDO;
        [AccessedThroughProperty("tsEnhToEven")]
        ToolStripMenuItem _tsEnhToEven;
        [AccessedThroughProperty("tsEnhToMinus1")]
        ToolStripMenuItem _tsEnhToMinus1;
        [AccessedThroughProperty("tsEnhToMinus2")]
        ToolStripMenuItem _tsEnhToMinus2;
        [AccessedThroughProperty("tsEnhToMinus3")]
        ToolStripMenuItem _tsEnhToMinus3;
        [AccessedThroughProperty("tsEnhToNone")]
        ToolStripMenuItem _tsEnhToNone;
        [AccessedThroughProperty("tsEnhToPlus1")]
        ToolStripMenuItem _tsEnhToPlus1;
        [AccessedThroughProperty("tsEnhToPlus2")]
        ToolStripMenuItem _tsEnhToPlus2;
        [AccessedThroughProperty("tsEnhToPlus3")]
        ToolStripMenuItem _tsEnhToPlus3;
        [AccessedThroughProperty("tsEnhToPlus4")]
        ToolStripMenuItem _tsEnhToPlus4;
        [AccessedThroughProperty("tsEnhToPlus5")]
        ToolStripMenuItem _tsEnhToPlus5;
        [AccessedThroughProperty("tsEnhToSO")]
        ToolStripMenuItem _tsEnhToSO;
        [AccessedThroughProperty("tsEnhToTO")]
        ToolStripMenuItem _tsEnhToTO;
        [AccessedThroughProperty("tsExport")]
        ToolStripMenuItem _tsExport;
        [AccessedThroughProperty("tsExportDataLink")]
        ToolStripMenuItem _tsExportDataLink;
        [AccessedThroughProperty("tsExportLong")]
        ToolStripMenuItem _tsExportLong;
        [AccessedThroughProperty("tsFileNew")]
        ToolStripMenuItem _tsFileNew;
        [AccessedThroughProperty("tsFileOpen")]
        ToolStripMenuItem _tsFileOpen;
        [AccessedThroughProperty("tsFilePrint")]
        ToolStripMenuItem _tsFilePrint;
        [AccessedThroughProperty("tsFileQuit")]
        ToolStripMenuItem _tsFileQuit;
        [AccessedThroughProperty("tsFileSave")]
        ToolStripMenuItem _tsFileSave;
        [AccessedThroughProperty("tsFileSaveAs")]
        ToolStripMenuItem _tsFileSaveAs;
        [AccessedThroughProperty("tsFlipAllEnh")]
        ToolStripMenuItem _tsFlipAllEnh;
        [AccessedThroughProperty("tsHelp")]
        ToolStripMenuItem _tsHelp;
        [AccessedThroughProperty("tsHelperLong")]
        ToolStripMenuItem _tsHelperLong;
        [AccessedThroughProperty("tsHelperLong2")]
        ToolStripMenuItem _tsHelperLong2;
        [AccessedThroughProperty("tsHelperShort")]
        ToolStripMenuItem _tsHelperShort;
        [AccessedThroughProperty("tsHelperShort2")]
        ToolStripMenuItem _tsHelperShort2;
        [AccessedThroughProperty("tsImport")]
        ToolStripMenuItem _tsImport;
        [AccessedThroughProperty("tsIODefault")]
        ToolStripMenuItem _tsIODefault;
        [AccessedThroughProperty("tsIOMax")]
        ToolStripMenuItem _tsIOMax;
        [AccessedThroughProperty("tsIOMin")]
        ToolStripMenuItem _tsIOMin;
        [AccessedThroughProperty("tsLevelUp")]
        ToolStripMenuItem _tsLevelUp;
        [AccessedThroughProperty("tsPatchNotes")]
        ToolStripMenuItem _tsPatchNotes;
        [AccessedThroughProperty("tsRecipeViewer")]
        ToolStripMenuItem _tsRecipeViewer;
        [AccessedThroughProperty("tsDPSCalc")]
        ToolStripMenuItem _tsDPSCalc;
        [AccessedThroughProperty("tsRemoveAllSlots")]
        ToolStripMenuItem _tsRemoveAllSlots;
        [AccessedThroughProperty("tsSetFind")]
        ToolStripMenuItem _tsSetFind;
        [AccessedThroughProperty("tsTitanForum")]
        ToolStripMenuItem _tsTitanForum;
        [AccessedThroughProperty("tsTitanPlanner")]
        ToolStripMenuItem _tsTitanPlanner;
        [AccessedThroughProperty("tsTitanSite")]
        ToolStripMenuItem _tsTitanSite;
        [AccessedThroughProperty("tsUpdateCheck")]
        ToolStripMenuItem _tsUpdateCheck;
        [AccessedThroughProperty("tsView2Col")]
        ToolStripMenuItem _tsView2Col;
        [AccessedThroughProperty("tsView3Col")]
        ToolStripMenuItem _tsView3Col;
        [AccessedThroughProperty("tsView4Col")]
        ToolStripMenuItem _tsView4Col;
        [AccessedThroughProperty("tsViewActualDamage_New")]
        ToolStripMenuItem _tsViewActualDamage_New;
        [AccessedThroughProperty("tsViewData")]
        ToolStripMenuItem _tsViewData;
        [AccessedThroughProperty("tsViewDPS_New")]
        ToolStripMenuItem _tsViewDPS_New;
        [AccessedThroughProperty("tsViewGraphs")]
        ToolStripMenuItem _tsViewGraphs;
        [AccessedThroughProperty("tsViewIOLevels")]
        ToolStripMenuItem _tsViewIOLevels;
        [AccessedThroughProperty("tsViewRelative")]
        ToolStripMenuItem _tsViewRelative;
        [AccessedThroughProperty("tsViewSetCompare")]
        ToolStripMenuItem _tsViewSetCompare;
        [AccessedThroughProperty("tsViewSets")]
        ToolStripMenuItem _tsViewSets;
        [AccessedThroughProperty("tsViewSlotLevels")]
        ToolStripMenuItem _tsViewSlotLevels;
        [AccessedThroughProperty("tsViewTotals")]
        ToolStripMenuItem _tsViewTotals;
        ToolTip tTip;
        [AccessedThroughProperty("txtName")]
        TextBox _txtName;
        ToolStripMenuItem ViewToolStripMenuItem;
        ToolStripMenuItem WindowToolStripMenuItem;
        Rectangle ActivePopupBounds;
        IContainer components;
        bool DataViewLocked;
        short[] ddsa;
        ExtendedBitmap dmBuffer;
        bool DoneDblClick;
        int dragFinishPower;
        int dragFinishSlot;
        Rectangle dragRect;
        int dragStartPower;
        int dragStartSlot;
        int dragStartX;
        int dragStartY;
        int dragXOffset;
        int dragYOffset;
        clsDrawX drawing;
        int dvLastEnh;
        bool dvLastNoLev;
        int dvLastPower;
        int EnhancingPower;
        int EnhancingSlot;
        bool EnhPickerActive;
        frmAccolade fAccolade;
        frmData fData;
        frmCompare fGraphCompare;
        frmStats fGraphStats;
        bool FileModified;
        frmIncarnate fIncarnate;
        bool FlipActive;
        PowerEntry FlipGP;
        int FlipInterval;
        int FlipPowerID;
        int[] FlipSlotState;
        int FlipStepDelay;
        int FlipSteps;
        frmFloatingStats FloatingDataForm;
        frmMiniList fMini;
        frmRecipeViewer fRecipe;
        frmDPSCalc fDPSCalc;
        frmSetFind fSetFinder;
        frmSetViewer fSets;
        frmAccolade fTemp;
        frmTotals fTotals;
        bool HasSentBack;
        bool HasSentForwards;
        bool LastClickPlacedSlot;
        int LastEnhIndex;
        I9Slot LastEnhPlaced;
        string LastFileName;
        int LastIndex;
        FormWindowState LastState;
        DataView myDataView;
        bool NoResizeEvent;
        bool NoUpdate;
        Rectangle oldDragRect;
        int PickerHID;
        bool PopUpVisible;
        bool top_fData;
        bool top_fGraphCompare;
        bool top_fGraphStats;
        bool top_fRecipe;
        bool top_fSetFinder;
        bool top_fSets;
        bool top_fTotals;
        int xCursorOffset;
        int yCursorOffset;

        ImageButton accoladeButton
        {
            get
            {
                return this._accoladeButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.accoladeButton_MouseDown);
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.accoladeButton_ButtonClicked);
                if (this._accoladeButton != null)
                {
                    this._accoladeButton.MouseDown -= mouseEventHandler;
                    this._accoladeButton.ButtonClicked -= clickedEventHandler;
                }
                this._accoladeButton = value;
                if (this._accoladeButton == null)
                    return;
                this._accoladeButton.MouseDown += mouseEventHandler;
                this._accoladeButton.ButtonClicked += clickedEventHandler;
            }
        }

        ToolStripMenuItem AccoladesWindowToolStripMenuItem
        {
            get
            {
                return this._AccoladesWindowToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.AccoladesWindowToolStripMenuItem_Click);
                if (this._AccoladesWindowToolStripMenuItem != null)
                    this._AccoladesWindowToolStripMenuItem.Click -= eventHandler;
                this._AccoladesWindowToolStripMenuItem = value;
                if (this._AccoladesWindowToolStripMenuItem == null)
                    return;
                this._AccoladesWindowToolStripMenuItem.Click += eventHandler;
            }
        }


        ToolStripMenuItem AutoArrangeAllSlotsToolStripMenuItem
        {
            get
            {
                return this._AutoArrangeAllSlotsToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.AutoArrangeAllSlotsToolStripMenuItem_Click);
                if (this._AutoArrangeAllSlotsToolStripMenuItem != null)
                    this._AutoArrangeAllSlotsToolStripMenuItem.Click -= eventHandler;
                this._AutoArrangeAllSlotsToolStripMenuItem = value;
                if (this._AutoArrangeAllSlotsToolStripMenuItem == null)
                    return;
                this._AutoArrangeAllSlotsToolStripMenuItem.Click += eventHandler;
            }
        }

        ComboBox cbAncillary
        {
            get
            {
                return this._cbAncillary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbAncillary_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbAncillery_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbAncillary_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbAncillary != null)
                {
                    this._cbAncillary.DrawItem -= itemEventHandler;
                    this._cbAncillary.SelectionChangeCommitted -= eventHandler1;
                    this._cbAncillary.MouseMove -= mouseEventHandler;
                    this._cbAncillary.MouseLeave -= eventHandler2;
                }
                this._cbAncillary = value;
                if (this._cbAncillary == null)
                    return;
                this._cbAncillary.DrawItem += itemEventHandler;
                this._cbAncillary.SelectionChangeCommitted += eventHandler1;
                this._cbAncillary.MouseMove += mouseEventHandler;
                this._cbAncillary.MouseLeave += eventHandler2;
            }
        }

        ComboBox cbAT
        {
            get
            {
                return this._cbAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbAT_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbAT_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbAT_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbAT_MouseLeave);
                if (this._cbAT != null)
                {
                    this._cbAT.DrawItem -= itemEventHandler;
                    this._cbAT.SelectionChangeCommitted -= eventHandler1;
                    this._cbAT.MouseMove -= mouseEventHandler;
                    this._cbAT.MouseLeave -= eventHandler2;
                }
                this._cbAT = value;
                if (this._cbAT == null)
                    return;
                this._cbAT.DrawItem += itemEventHandler;
                this._cbAT.SelectionChangeCommitted += eventHandler1;
                this._cbAT.MouseMove += mouseEventHandler;
                this._cbAT.MouseLeave += eventHandler2;
            }
        }

        ComboBox cbOrigin
        {
            get
            {
                return this._cbOrigin;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbOrigin_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbOrigin_SelectedIndexChanged);
                if (this._cbOrigin != null)
                {
                    this._cbOrigin.DrawItem -= itemEventHandler;
                    this._cbOrigin.SelectionChangeCommitted -= eventHandler;
                }
                this._cbOrigin = value;
                if (this._cbOrigin == null)
                    return;
                this._cbOrigin.DrawItem += itemEventHandler;
                this._cbOrigin.SelectionChangeCommitted += eventHandler;
            }
        }

        ComboBox cbPool0
        {
            get
            {
                return this._cbPool0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool0_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbPool0_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool0_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool0 != null)
                {
                    this._cbPool0.DrawItem -= itemEventHandler;
                    this._cbPool0.SelectionChangeCommitted -= eventHandler1;
                    this._cbPool0.MouseMove -= mouseEventHandler;
                    this._cbPool0.MouseLeave -= eventHandler2;
                }
                this._cbPool0 = value;
                if (this._cbPool0 == null)
                    return;
                this._cbPool0.DrawItem += itemEventHandler;
                this._cbPool0.SelectionChangeCommitted += eventHandler1;
                this._cbPool0.MouseMove += mouseEventHandler;
                this._cbPool0.MouseLeave += eventHandler2;
            }
        }

        ComboBox cbPool1
        {
            get
            {
                return this._cbPool1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool1_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbPool1_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool1_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool1 != null)
                {
                    this._cbPool1.DrawItem -= itemEventHandler;
                    this._cbPool1.SelectionChangeCommitted -= eventHandler1;
                    this._cbPool1.MouseMove -= mouseEventHandler;
                    this._cbPool1.MouseLeave -= eventHandler2;
                }
                this._cbPool1 = value;
                if (this._cbPool1 == null)
                    return;
                this._cbPool1.DrawItem += itemEventHandler;
                this._cbPool1.SelectionChangeCommitted += eventHandler1;
                this._cbPool1.MouseMove += mouseEventHandler;
                this._cbPool1.MouseLeave += eventHandler2;
            }
        }

        ComboBox cbPool2
        {
            get
            {
                return this._cbPool2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool2_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbPool2_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool2_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool2 != null)
                {
                    this._cbPool2.DrawItem -= itemEventHandler;
                    this._cbPool2.SelectionChangeCommitted -= eventHandler1;
                    this._cbPool2.MouseMove -= mouseEventHandler;
                    this._cbPool2.MouseLeave -= eventHandler2;
                }
                this._cbPool2 = value;
                if (this._cbPool2 == null)
                    return;
                this._cbPool2.DrawItem += itemEventHandler;
                this._cbPool2.SelectionChangeCommitted += eventHandler1;
                this._cbPool2.MouseMove += mouseEventHandler;
                this._cbPool2.MouseLeave += eventHandler2;
            }
        }

        ComboBox cbPool3
        {
            get
            {
                return this._cbPool3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool3_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbPool3_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool3_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool3 != null)
                {
                    this._cbPool3.DrawItem -= itemEventHandler;
                    this._cbPool3.SelectionChangeCommitted -= eventHandler1;
                    this._cbPool3.MouseMove -= mouseEventHandler;
                    this._cbPool3.MouseLeave -= eventHandler2;
                }
                this._cbPool3 = value;
                if (this._cbPool3 == null)
                    return;
                this._cbPool3.DrawItem += itemEventHandler;
                this._cbPool3.SelectionChangeCommitted += eventHandler1;
                this._cbPool3.MouseMove += mouseEventHandler;
                this._cbPool3.MouseLeave += eventHandler2;
            }
        }

        internal ComboBox cbPrimary
        {
            get
            {
                return this._cbPrimary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            private set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPrimary_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbPrimary_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPrimary_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPrimary_MouseLeave);
                if (this._cbPrimary != null)
                {
                    this._cbPrimary.DrawItem -= itemEventHandler;
                    this._cbPrimary.SelectionChangeCommitted -= eventHandler1;
                    this._cbPrimary.MouseMove -= mouseEventHandler;
                    this._cbPrimary.MouseLeave -= eventHandler2;
                }
                this._cbPrimary = value;
                if (this._cbPrimary == null)
                    return;
                this._cbPrimary.DrawItem += itemEventHandler;
                this._cbPrimary.SelectionChangeCommitted += eventHandler1;
                this._cbPrimary.MouseMove += mouseEventHandler;
                this._cbPrimary.MouseLeave += eventHandler2;
            }
        }

        ComboBox cbSecondary
        {
            get
            {
                return this._cbSecondary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbSecondary_DrawItem);
                EventHandler eventHandler1 = new EventHandler(this.cbSecondary_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbSecondary_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbSecondary_MouseLeave);
                if (this._cbSecondary != null)
                {
                    this._cbSecondary.DrawItem -= itemEventHandler;
                    this._cbSecondary.SelectionChangeCommitted -= eventHandler1;
                    this._cbSecondary.MouseMove -= mouseEventHandler;
                    this._cbSecondary.MouseLeave -= eventHandler2;
                }
                this._cbSecondary = value;
                if (this._cbSecondary == null)
                    return;
                this._cbSecondary.DrawItem += itemEventHandler;
                this._cbSecondary.SelectionChangeCommitted += eventHandler1;
                this._cbSecondary.MouseMove += mouseEventHandler;
                this._cbSecondary.MouseLeave += eventHandler2;
            }
        }


        internal OpenFileDialog dlgOpen
        {
            get
            {
                return this._dlgOpen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgOpen = value;
            }
        }

        internal SaveFileDialog dlgSave
        {
            get
            {
                return this._dlgSave;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgSave = value;
            }
        }

        DataView dvAnchored
        {
            get
            {
                return this._dvAnchored;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.frmMain_MouseWheel);
                DataView.SizeChangeEventHandler changeEventHandler1 = new DataView.SizeChangeEventHandler(this.dvAnchored_SizeChange);
                DataView.FloatChangeEventHandler changeEventHandler2 = new DataView.FloatChangeEventHandler(this.dvAnchored_Float);
                DataView.Unlock_ClickEventHandler clickEventHandler = new DataView.Unlock_ClickEventHandler(this.dvAnchored_Unlock);
                DataView.SlotUpdateEventHandler updateEventHandler = new DataView.SlotUpdateEventHandler(this.DataView_SlotUpdate);
                DataView.SlotFlipEventHandler flipEventHandler = new DataView.SlotFlipEventHandler(this.DataView_SlotFlip);
                DataView.MovedEventHandler movedEventHandler = new DataView.MovedEventHandler(this.dvAnchored_Move);
                DataView.TabChangedEventHandler changedEventHandler = new DataView.TabChangedEventHandler(this.dvAnchored_TabChanged);
                if (this._dvAnchored != null)
                {
                    this._dvAnchored.MouseWheel -= mouseEventHandler;
                    this._dvAnchored.SizeChange -= changeEventHandler1;
                    this._dvAnchored.FloatChange -= changeEventHandler2;
                    this._dvAnchored.Unlock_Click -= clickEventHandler;
                    this._dvAnchored.SlotUpdate -= updateEventHandler;
                    this._dvAnchored.SlotFlip -= flipEventHandler;
                    this._dvAnchored.Moved -= movedEventHandler;
                    this._dvAnchored.TabChanged -= changedEventHandler;
                }
                this._dvAnchored = value;
                if (this._dvAnchored == null)
                    return;
                this._dvAnchored.MouseWheel += mouseEventHandler;
                this._dvAnchored.SizeChange += changeEventHandler1;
                this._dvAnchored.FloatChange += changeEventHandler2;
                this._dvAnchored.Unlock_Click += clickEventHandler;
                this._dvAnchored.SlotUpdate += updateEventHandler;
                this._dvAnchored.SlotFlip += flipEventHandler;
                this._dvAnchored.Moved += movedEventHandler;
                this._dvAnchored.TabChanged += changedEventHandler;
            }
        }

        ImageButton heroVillain
        {
            get
            {
                return this._heroVillain;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.heroVillain_ButtonClicked);
                if (this._heroVillain != null)
                    this._heroVillain.ButtonClicked -= clickedEventHandler;
                this._heroVillain = value;
                if (this._heroVillain == null)
                    return;
                this._heroVillain.ButtonClicked += clickedEventHandler;
            }
        }

        internal I9Picker I9Picker
        {
            get
            {
                if (this._I9Picker.Height <= 235)
                    this._I9Picker.Height = 315;
                return this._I9Picker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            private set
            {
                I9Picker.MovedEventHandler movedEventHandler = new I9Picker.MovedEventHandler(this.I9Picker_Moved);
                I9Picker.HoverSetEventHandler hoverSetEventHandler = new I9Picker.HoverSetEventHandler(this.I9Picker_HoverSet);
                I9Picker.HoverEnhancementEventHandler enhancementEventHandler = new I9Picker.HoverEnhancementEventHandler(this.I9Picker_HoverEnhancement);
                EventHandler eventHandler = new EventHandler(this.I9Picker_Hiding);
                I9Picker.EnhancementPickedEventHandler pickedEventHandler = new I9Picker.EnhancementPickedEventHandler(this.I9Picker_EnhancementPicked);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.I9Picker_MouseDown);
                if (this._I9Picker != null)
                {
                    this._I9Picker.Moved -= movedEventHandler;
                    this._I9Picker.HoverSet -= hoverSetEventHandler;
                    this._I9Picker.HoverEnhancement -= enhancementEventHandler;
                    this._I9Picker.MouseLeave -= eventHandler;
                    this._I9Picker.EnhancementPicked -= pickedEventHandler;
                    this._I9Picker.MouseDown -= mouseEventHandler;
                }
                this._I9Picker = value;
                if (this._I9Picker == null)
                    return;
                this._I9Picker.Moved += movedEventHandler;
                this._I9Picker.HoverSet += hoverSetEventHandler;
                this._I9Picker.HoverEnhancement += enhancementEventHandler;
                this._I9Picker.MouseLeave += eventHandler;
                this._I9Picker.EnhancementPicked += pickedEventHandler;
                this._I9Picker.MouseDown += mouseEventHandler;
            }
        }

        ctlPopUp I9Popup
        {
            get
            {
                return this._I9Popup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.I9Popup_MouseMove);
                if (this._I9Popup != null)
                    this._I9Popup.MouseMove -= mouseEventHandler;
                this._I9Popup = value;
                if (this._I9Popup == null)
                    return;
                this._I9Popup.MouseMove += mouseEventHandler;
            }
        }

        ImageButton ibMode
        {
            get
            {
                return this._ibMode;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibMode_ButtonClicked);
                if (this._ibMode != null)
                    this._ibMode.ButtonClicked -= clickedEventHandler;
                this._ibMode = value;
                if (this._ibMode == null)
                    return;
                this._ibMode.ButtonClicked += clickedEventHandler;
            }
        }

        ImageButton ibPopup
        {
            get
            {
                return this._ibPopup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibPopup_ButtonClicked);
                if (this._ibPopup != null)
                    this._ibPopup.ButtonClicked -= clickedEventHandler;
                this._ibPopup = value;
                if (this._ibPopup == null)
                    return;
                this._ibPopup.ButtonClicked += clickedEventHandler;
            }
        }

        ImageButton ibPvX
        {
            get
            {
                return this._ibPvX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibPvX_ButtonClicked);
                if (this._ibPvX != null)
                    this._ibPvX.ButtonClicked -= clickedEventHandler;
                this._ibPvX = value;
                if (this._ibPvX == null)
                    return;
                this._ibPvX.ButtonClicked += clickedEventHandler;
            }
        }

        ImageButton ibRecipe
        {
            get
            {
                return this._ibRecipe;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibRecipe_ButtonClicked);
                if (this._ibRecipe != null)
                    this._ibRecipe.ButtonClicked -= clickedEventHandler;
                this._ibRecipe = value;
                if (this._ibRecipe == null)
                    return;
                this._ibRecipe.ButtonClicked += clickedEventHandler;
            }
        }

        ImageButton ibSets
        {
            get
            {
                return this._ibSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibSets_ButtonClicked);
                if (this._ibSets != null)
                    this._ibSets.ButtonClicked -= clickedEventHandler;
                this._ibSets = value;
                if (this._ibSets == null)
                    return;
                this._ibSets.ButtonClicked += clickedEventHandler;
            }
        }

        ImageButton ibSlotLevels
        {
            get
            {
                return this._ibSlotLevels;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibSlotLevels_ButtonClicked);
                if (this._ibSlotLevels != null)
                    this._ibSlotLevels.ButtonClicked -= clickedEventHandler;
                this._ibSlotLevels = value;
                if (this._ibSlotLevels == null)
                    return;
                this._ibSlotLevels.ButtonClicked += clickedEventHandler;
            }
        }

        ImageButton ibTotals
        {
            get
            {
                return this._ibTotals;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTotals_ButtonClicked);
                if (this._ibTotals != null)
                    this._ibTotals.ButtonClicked -= clickedEventHandler;
                this._ibTotals = value;
                if (this._ibTotals == null)
                    return;
                this._ibTotals.ButtonClicked += clickedEventHandler;
            }
        }


        ImageButton incarnateButton
        {
            get
            {
                return this._incarnateButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.incarnateButton_MouseDown);
                if (this._incarnateButton != null)
                    this._incarnateButton.MouseDown -= mouseEventHandler;
                this._incarnateButton = value;
                if (this._incarnateButton == null)
                    return;
                this._incarnateButton.MouseDown += mouseEventHandler;
            }
        }

        ToolStripMenuItem IncarnateWindowToolStripMenuItem
        {
            get
            {
                return this._IncarnateWindowToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.IncarnateWindowToolStripMenuItem_Click);
                if (this._IncarnateWindowToolStripMenuItem != null)
                    this._IncarnateWindowToolStripMenuItem.Click -= eventHandler;
                this._IncarnateWindowToolStripMenuItem = value;
                if (this._IncarnateWindowToolStripMenuItem == null)
                    return;
                this._IncarnateWindowToolStripMenuItem.Click += eventHandler;
            }
        }

        Label lblATLocked
        {
            get
            {
                return this._lblATLocked;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblATLocked_MouseMove);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblATLocked_Paint);
                EventHandler eventHandler = new EventHandler(this.lblATLocked_MouseLeave);
                if (this._lblATLocked != null)
                {
                    this._lblATLocked.MouseMove -= mouseEventHandler;
                    this._lblATLocked.Paint -= paintEventHandler;
                    this._lblATLocked.MouseLeave -= eventHandler;
                }
                this._lblATLocked = value;
                if (this._lblATLocked == null)
                    return;
                this._lblATLocked.MouseMove += mouseEventHandler;
                this._lblATLocked.Paint += paintEventHandler;
                this._lblATLocked.MouseLeave += eventHandler;
            }
        }

        Label lblLocked0
        {
            get
            {
                return this._lblLocked0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked0_Paint);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked0_MouseMove);
                EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
                if (this._lblLocked0 != null)
                {
                    this._lblLocked0.Paint -= paintEventHandler;
                    this._lblLocked0.MouseMove -= mouseEventHandler;
                    this._lblLocked0.MouseLeave -= eventHandler;
                }
                this._lblLocked0 = value;
                if (this._lblLocked0 == null)
                    return;
                this._lblLocked0.Paint += paintEventHandler;
                this._lblLocked0.MouseMove += mouseEventHandler;
                this._lblLocked0.MouseLeave += eventHandler;
            }
        }

        Label lblLocked1
        {
            get
            {
                return this._lblLocked1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked1_Paint);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked1_MouseMove);
                EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
                if (this._lblLocked1 != null)
                {
                    this._lblLocked1.Paint -= paintEventHandler;
                    this._lblLocked1.MouseMove -= mouseEventHandler;
                    this._lblLocked1.MouseLeave -= eventHandler;
                }
                this._lblLocked1 = value;
                if (this._lblLocked1 == null)
                    return;
                this._lblLocked1.Paint += paintEventHandler;
                this._lblLocked1.MouseMove += mouseEventHandler;
                this._lblLocked1.MouseLeave += eventHandler;
            }
        }

        Label lblLocked2
        {
            get
            {
                return this._lblLocked2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked2_Paint);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked2_MouseMove);
                EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
                if (this._lblLocked2 != null)
                {
                    this._lblLocked2.Paint -= paintEventHandler;
                    this._lblLocked2.MouseMove -= mouseEventHandler;
                    this._lblLocked2.MouseLeave -= eventHandler;
                }
                this._lblLocked2 = value;
                if (this._lblLocked2 == null)
                    return;
                this._lblLocked2.Paint += paintEventHandler;
                this._lblLocked2.MouseMove += mouseEventHandler;
                this._lblLocked2.MouseLeave += eventHandler;
            }
        }

        Label lblLocked3
        {
            get
            {
                return this._lblLocked3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLocked3_Paint);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLocked3_MouseMove);
                EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
                if (this._lblLocked3 != null)
                {
                    this._lblLocked3.Paint -= paintEventHandler;
                    this._lblLocked3.MouseMove -= mouseEventHandler;
                    this._lblLocked3.MouseLeave -= eventHandler;
                }
                this._lblLocked3 = value;
                if (this._lblLocked3 == null)
                    return;
                this._lblLocked3.Paint += paintEventHandler;
                this._lblLocked3.MouseMove += mouseEventHandler;
                this._lblLocked3.MouseLeave += eventHandler;
            }
        }

        Label lblLockedAncillary
        {
            get
            {
                return this._lblLockedAncillary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLockedAncillary_MouseMove);
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.lblLockedAncillary_Paint);
                EventHandler eventHandler = new EventHandler(this.lblLocked0_MouseLeave);
                if (this._lblLockedAncillary != null)
                {
                    this._lblLockedAncillary.MouseMove -= mouseEventHandler;
                    this._lblLockedAncillary.Paint -= paintEventHandler;
                    this._lblLockedAncillary.MouseLeave -= eventHandler;
                }
                this._lblLockedAncillary = value;
                if (this._lblLockedAncillary == null)
                    return;
                this._lblLockedAncillary.MouseMove += mouseEventHandler;
                this._lblLockedAncillary.Paint += paintEventHandler;
                this._lblLockedAncillary.MouseLeave += eventHandler;
            }
        }

        Label lblLockedSecondary
        {
            get
            {
                return this._lblLockedSecondary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.lblLockedSecondary_MouseMove);
                EventHandler eventHandler = new EventHandler(this.lblLockedSecondary_MouseLeave);
                if (this._lblLockedSecondary != null)
                {
                    this._lblLockedSecondary.MouseMove -= mouseEventHandler;
                    this._lblLockedSecondary.MouseLeave -= eventHandler;
                }
                this._lblLockedSecondary = value;
                if (this._lblLockedSecondary == null)
                    return;
                this._lblLockedSecondary.MouseMove += mouseEventHandler;
                this._lblLockedSecondary.MouseLeave += eventHandler;
            }
        }

        ListLabelV2 llAncillary
        {
            get
            {
                return this._llAncillary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llAncillary_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llAncillary_ItemClick);
                if (this._llAncillary != null)
                {
                    this._llAncillary.ItemHover -= hoverEventHandler;
                    this._llAncillary.ItemClick -= clickEventHandler;
                }
                this._llAncillary = value;
                if (this._llAncillary == null)
                    return;
                this._llAncillary.ItemHover += hoverEventHandler;
                this._llAncillary.ItemClick += clickEventHandler;
            }
        }

        ListLabelV2 llPool0
        {
            get
            {
                return this._llPool0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler1 = new ListLabelV2.ItemHoverEventHandler(this.llPool0_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool0_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool0 != null)
                {
                    this._llPool0.ItemHover -= hoverEventHandler1;
                    this._llPool0.ItemClick -= clickEventHandler;
                    this._llPool0.MouseLeave -= eventHandler;
                    this._llPool0.EmptyHover -= hoverEventHandler2;
                }
                this._llPool0 = value;
                if (this._llPool0 == null)
                    return;
                this._llPool0.ItemHover += hoverEventHandler1;
                this._llPool0.ItemClick += clickEventHandler;
                this._llPool0.MouseLeave += eventHandler;
                this._llPool0.EmptyHover += hoverEventHandler2;
            }
        }

        ListLabelV2 llPool1
        {
            get
            {
                return this._llPool1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler1 = new ListLabelV2.ItemHoverEventHandler(this.llPool1_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool1_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool1 != null)
                {
                    this._llPool1.ItemHover -= hoverEventHandler1;
                    this._llPool1.ItemClick -= clickEventHandler;
                    this._llPool1.MouseLeave -= eventHandler;
                    this._llPool1.EmptyHover -= hoverEventHandler2;
                }
                this._llPool1 = value;
                if (this._llPool1 == null)
                    return;
                this._llPool1.ItemHover += hoverEventHandler1;
                this._llPool1.ItemClick += clickEventHandler;
                this._llPool1.MouseLeave += eventHandler;
                this._llPool1.EmptyHover += hoverEventHandler2;
            }
        }

        ListLabelV2 llPool2
        {
            get
            {
                return this._llPool2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler1 = new ListLabelV2.ItemHoverEventHandler(this.llPool2_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool2_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool2 != null)
                {
                    this._llPool2.ItemHover -= hoverEventHandler1;
                    this._llPool2.ItemClick -= clickEventHandler;
                    this._llPool2.MouseLeave -= eventHandler;
                    this._llPool2.EmptyHover -= hoverEventHandler2;
                }
                this._llPool2 = value;
                if (this._llPool2 == null)
                    return;
                this._llPool2.ItemHover += hoverEventHandler1;
                this._llPool2.ItemClick += clickEventHandler;
                this._llPool2.MouseLeave += eventHandler;
                this._llPool2.EmptyHover += hoverEventHandler2;
            }
        }

        ListLabelV2 llPool3
        {
            get
            {
                return this._llPool3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler1 = new ListLabelV2.ItemHoverEventHandler(this.llPool3_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool3_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool3 != null)
                {
                    this._llPool3.ItemHover -= hoverEventHandler1;
                    this._llPool3.ItemClick -= clickEventHandler;
                    this._llPool3.MouseLeave -= eventHandler;
                    this._llPool3.EmptyHover -= hoverEventHandler2;
                }
                this._llPool3 = value;
                if (this._llPool3 == null)
                    return;
                this._llPool3.ItemHover += hoverEventHandler1;
                this._llPool3.ItemClick += clickEventHandler;
                this._llPool3.MouseLeave += eventHandler;
                this._llPool3.EmptyHover += hoverEventHandler2;
            }
        }

        ListLabelV2 llPrimary
        {
            get
            {
                return this._llPrimary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler1 = new ListLabelV2.ItemHoverEventHandler(this.llPrimary_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPrimary_ItemClick);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                ListLabelV2.ExpandChangedEventHandler changedEventHandler = new ListLabelV2.ExpandChangedEventHandler(this.PriSec_ExpandChanged);
                if (this._llPrimary != null)
                {
                    this._llPrimary.ItemHover -= hoverEventHandler1;
                    this._llPrimary.ItemClick -= clickEventHandler;
                    this._llPrimary.EmptyHover -= hoverEventHandler2;
                    this._llPrimary.ExpandChanged -= changedEventHandler;
                }
                this._llPrimary = value;
                if (this._llPrimary == null)
                    return;
                this._llPrimary.ItemHover += hoverEventHandler1;
                this._llPrimary.ItemClick += clickEventHandler;
                this._llPrimary.EmptyHover += hoverEventHandler2;
                this._llPrimary.ExpandChanged += changedEventHandler;
            }
        }

        ListLabelV2 llSecondary
        {
            get
            {
                return this._llSecondary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler1 = new ListLabelV2.ItemHoverEventHandler(this.llSecondary_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llSecondary_ItemClick);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                ListLabelV2.ExpandChangedEventHandler changedEventHandler = new ListLabelV2.ExpandChangedEventHandler(this.PriSec_ExpandChanged);
                if (this._llSecondary != null)
                {
                    this._llSecondary.ItemHover -= hoverEventHandler1;
                    this._llSecondary.ItemClick -= clickEventHandler;
                    this._llSecondary.EmptyHover -= hoverEventHandler2;
                    this._llSecondary.ExpandChanged -= changedEventHandler;
                }
                this._llSecondary = value;
                if (this._llSecondary == null)
                    return;
                this._llSecondary.ItemHover += hoverEventHandler1;
                this._llSecondary.ItemClick += clickEventHandler;
                this._llSecondary.EmptyHover += hoverEventHandler2;
                this._llSecondary.ExpandChanged += changedEventHandler;
            }
        }

        PictureBox pbDynMode
        {
            get
            {
                return this._pbDynMode;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                PaintEventHandler paintEventHandler = new PaintEventHandler(this.pbDynMode_Paint);
                EventHandler eventHandler = new EventHandler(this.pbDynMode_Click);
                if (this._pbDynMode != null)
                {
                    this._pbDynMode.Paint -= paintEventHandler;
                    this._pbDynMode.Click -= eventHandler;
                }
                this._pbDynMode = value;
                if (this._pbDynMode == null)
                    return;
                this._pbDynMode.Paint += paintEventHandler;
                this._pbDynMode.Click += eventHandler;
            }
        }

        PictureBox pnlGFX
        {
            get
            {
                return this._pnlGFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.pnlGFX_MouseEnter);
                EventHandler eventHandler2 = new EventHandler(this.pnlGFX_MouseLeave);
                MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.pnlGFX_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlGFX_MouseUp);
                MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.pnlGFX_MouseDoubleClick);
                MouseEventHandler mouseEventHandler4 = new MouseEventHandler(this.pnlGFX_MouseDown);
                DragEventHandler dragEventHandler1 = new DragEventHandler(this.pnlGFX_DragOver);
                DragEventHandler dragEventHandler2 = new DragEventHandler(this.pnlGFX_DragEnter);
                DragEventHandler dragEventHandler3 = new DragEventHandler(this.pnlGFX_DragDrop);
                if (this._pnlGFX != null)
                {
                    this._pnlGFX.MouseEnter -= eventHandler1;
                    this._pnlGFX.MouseLeave -= eventHandler2;
                    this._pnlGFX.MouseMove -= mouseEventHandler1;
                    this._pnlGFX.MouseUp -= mouseEventHandler2;
                    this._pnlGFX.MouseDoubleClick -= mouseEventHandler3;
                    this._pnlGFX.MouseDown -= mouseEventHandler4;
                    this._pnlGFX.DragOver -= dragEventHandler1;
                    this._pnlGFX.DragEnter -= dragEventHandler2;
                    this._pnlGFX.DragDrop -= dragEventHandler3;
                }
                this._pnlGFX = value;
                if (this._pnlGFX == null)
                    return;
                this._pnlGFX.MouseEnter += eventHandler1;
                this._pnlGFX.MouseLeave += eventHandler2;
                this._pnlGFX.MouseMove += mouseEventHandler1;
                this._pnlGFX.MouseUp += mouseEventHandler2;
                this._pnlGFX.MouseDoubleClick += mouseEventHandler3;
                this._pnlGFX.MouseDown += mouseEventHandler4;
                this._pnlGFX.DragOver += dragEventHandler1;
                this._pnlGFX.DragEnter += dragEventHandler2;
                this._pnlGFX.DragDrop += dragEventHandler3;
            }
        }

        FlowLayoutPanel pnlGFXFlow
        {
            get
            {
                return this._pnlGFXFlow;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.pnlGFXFlow_MouseEnter);
                if (this._pnlGFXFlow != null)
                    this._pnlGFXFlow.MouseEnter -= eventHandler;
                this._pnlGFXFlow = value;
                if (this._pnlGFXFlow == null)
                    return;
                this._pnlGFXFlow.MouseEnter += eventHandler;
            }
        }


        ToolStripMenuItem TemporaryPowersWindowToolStripMenuItem
        {
            get
            {
                return this._TemporaryPowersWindowToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.TemporaryPowersWindowToolStripMenuItem_Click);
                if (this._TemporaryPowersWindowToolStripMenuItem != null)
                    this._TemporaryPowersWindowToolStripMenuItem.Click -= eventHandler;
                this._TemporaryPowersWindowToolStripMenuItem = value;
                if (this._TemporaryPowersWindowToolStripMenuItem == null)
                    return;
                this._TemporaryPowersWindowToolStripMenuItem.Click += eventHandler;
            }
        }

        ImageButton tempPowersButton
        {
            get
            {
                return this._tempPowersButton;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.tempPowersButton_MouseDown);
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.tempPowersButton_ButtonClicked);
                if (this._tempPowersButton != null)
                {
                    this._tempPowersButton.MouseDown -= mouseEventHandler;
                    this._tempPowersButton.ButtonClicked -= clickedEventHandler;
                }
                this._tempPowersButton = value;
                if (this._tempPowersButton == null)
                    return;
                this._tempPowersButton.MouseDown += mouseEventHandler;
                this._tempPowersButton.ButtonClicked += clickedEventHandler;
            }
        }

        ToolStripMenuItem tlsDPA
        {
            get
            {
                return this._tlsDPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tlsDPA_Click);
                if (this._tlsDPA != null)
                    this._tlsDPA.Click -= eventHandler;
                this._tlsDPA = value;
                if (this._tlsDPA == null)
                    return;
                this._tlsDPA.Click += eventHandler;
            }
        }

        System.Windows.Forms.Timer tmrGfx
        {
            get
            {
                return this._tmrGfx;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tmrGfx_Tick);
                if (this._tmrGfx != null)
                    this._tmrGfx.Tick -= eventHandler;
                this._tmrGfx = value;
                if (this._tmrGfx == null)
                    return;
                this._tmrGfx.Tick += eventHandler;
            }
        }

        ToolStripMenuItem tsAbout
        {
            get
            {
                return this._tsAbout;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsAbout_Click);
                if (this._tsAbout != null)
                    this._tsAbout.Click -= eventHandler;
                this._tsAbout = value;
                if (this._tsAbout == null)
                    return;
                this._tsAbout.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsAdvDBEdit
        {
            get
            {
                return this._tsAdvDBEdit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsAdvDBEdit_Click);
                if (this._tsAdvDBEdit != null)
                    this._tsAdvDBEdit.Click -= eventHandler;
                this._tsAdvDBEdit = value;
                if (this._tsAdvDBEdit == null)
                    return;
                this._tsAdvDBEdit.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsAdvFreshInstall
        {
            get
            {
                return this._tsAdvFreshInstall;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsAdvFreshInstall_Click);
                if (this._tsAdvFreshInstall != null)
                    this._tsAdvFreshInstall.Click -= eventHandler;
                this._tsAdvFreshInstall = value;
                if (this._tsAdvFreshInstall == null)
                    return;
                this._tsAdvFreshInstall.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsAdvResetTips
        {
            get
            {
                return this._tsAdvResetTips;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsAdvResetTips_Click);
                if (this._tsAdvResetTips != null)
                    this._tsAdvResetTips.Click -= eventHandler;
                this._tsAdvResetTips = value;
                if (this._tsAdvResetTips == null)
                    return;
                this._tsAdvResetTips.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsBug
        {
            get
            {
                return this._tsBug;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsBug_Click);
                if (this._tsBug != null)
                    this._tsBug.Click -= eventHandler;
                this._tsBug = value;
                if (this._tsBug == null)
                    return;
                this._tsBug.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsClearAllEnh
        {
            get
            {
                return this._tsClearAllEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsClearAllEnh_Click);
                if (this._tsClearAllEnh != null)
                    this._tsClearAllEnh.Click -= eventHandler;
                this._tsClearAllEnh = value;
                if (this._tsClearAllEnh == null)
                    return;
                this._tsClearAllEnh.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsConfig
        {
            get
            {
                return this._tsConfig;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsConfig_Click);
                if (this._tsConfig != null)
                    this._tsConfig.Click -= eventHandler;
                this._tsConfig = value;
                if (this._tsConfig == null)
                    return;
                this._tsConfig.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsDonate
        {
            get
            {
                return this._tsDonate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsDonate_Click);
                if (this._tsDonate != null)
                    this._tsDonate.Click -= eventHandler;
                this._tsDonate = value;
                if (this._tsDonate == null)
                    return;
                this._tsDonate.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsDynamic
        {
            get
            {
                return this._tsDynamic;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsDynamic_Click);
                if (this._tsDynamic != null)
                    this._tsDynamic.Click -= eventHandler;
                this._tsDynamic = value;
                if (this._tsDynamic == null)
                    return;
                this._tsDynamic.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToDO
        {
            get
            {
                return this._tsEnhToDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToDO_Click);
                if (this._tsEnhToDO != null)
                    this._tsEnhToDO.Click -= eventHandler;
                this._tsEnhToDO = value;
                if (this._tsEnhToDO == null)
                    return;
                this._tsEnhToDO.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToEven
        {
            get
            {
                return this._tsEnhToEven;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToEven_Click);
                if (this._tsEnhToEven != null)
                    this._tsEnhToEven.Click -= eventHandler;
                this._tsEnhToEven = value;
                if (this._tsEnhToEven == null)
                    return;
                this._tsEnhToEven.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToMinus1
        {
            get
            {
                return this._tsEnhToMinus1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToMinus1_Click);
                if (this._tsEnhToMinus1 != null)
                    this._tsEnhToMinus1.Click -= eventHandler;
                this._tsEnhToMinus1 = value;
                if (this._tsEnhToMinus1 == null)
                    return;
                this._tsEnhToMinus1.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToMinus2
        {
            get
            {
                return this._tsEnhToMinus2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToMinus2_Click);
                if (this._tsEnhToMinus2 != null)
                    this._tsEnhToMinus2.Click -= eventHandler;
                this._tsEnhToMinus2 = value;
                if (this._tsEnhToMinus2 == null)
                    return;
                this._tsEnhToMinus2.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToMinus3
        {
            get
            {
                return this._tsEnhToMinus3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToMinus3_Click);
                if (this._tsEnhToMinus3 != null)
                    this._tsEnhToMinus3.Click -= eventHandler;
                this._tsEnhToMinus3 = value;
                if (this._tsEnhToMinus3 == null)
                    return;
                this._tsEnhToMinus3.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToNone
        {
            get
            {
                return this._tsEnhToNone;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToNone_Click);
                if (this._tsEnhToNone != null)
                    this._tsEnhToNone.Click -= eventHandler;
                this._tsEnhToNone = value;
                if (this._tsEnhToNone == null)
                    return;
                this._tsEnhToNone.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToPlus1
        {
            get
            {
                return this._tsEnhToPlus1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToPlus1_Click);
                if (this._tsEnhToPlus1 != null)
                    this._tsEnhToPlus1.Click -= eventHandler;
                this._tsEnhToPlus1 = value;
                if (this._tsEnhToPlus1 == null)
                    return;
                this._tsEnhToPlus1.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToPlus2
        {
            get
            {
                return this._tsEnhToPlus2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToPlus2_Click);
                if (this._tsEnhToPlus2 != null)
                    this._tsEnhToPlus2.Click -= eventHandler;
                this._tsEnhToPlus2 = value;
                if (this._tsEnhToPlus2 == null)
                    return;
                this._tsEnhToPlus2.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToPlus3
        {
            get
            {
                return this._tsEnhToPlus3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToPlus3_Click);
                if (this._tsEnhToPlus3 != null)
                    this._tsEnhToPlus3.Click -= eventHandler;
                this._tsEnhToPlus3 = value;
                if (this._tsEnhToPlus3 == null)
                    return;
                this._tsEnhToPlus3.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToPlus4
        {
            get
            {
                return this._tsEnhToPlus4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToPlus4_Click);
                if (this._tsEnhToPlus4 != null)
                    this._tsEnhToPlus4.Click -= eventHandler;
                this._tsEnhToPlus4 = value;
                if (this._tsEnhToPlus4 == null)
                    return;
                this._tsEnhToPlus4.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToPlus5
        {
            get
            {
                return this._tsEnhToPlus5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToPlus5_Click);
                if (this._tsEnhToPlus5 != null)
                    this._tsEnhToPlus5.Click -= eventHandler;
                this._tsEnhToPlus5 = value;
                if (this._tsEnhToPlus5 == null)
                    return;
                this._tsEnhToPlus5.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToSO
        {
            get
            {
                return this._tsEnhToSO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToSO_Click);
                if (this._tsEnhToSO != null)
                    this._tsEnhToSO.Click -= eventHandler;
                this._tsEnhToSO = value;
                if (this._tsEnhToSO == null)
                    return;
                this._tsEnhToSO.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsEnhToTO
        {
            get
            {
                return this._tsEnhToTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsEnhToTO_Click);
                if (this._tsEnhToTO != null)
                    this._tsEnhToTO.Click -= eventHandler;
                this._tsEnhToTO = value;
                if (this._tsEnhToTO == null)
                    return;
                this._tsEnhToTO.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsExport
        {
            get
            {
                return this._tsExport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsExport_Click);
                if (this._tsExport != null)
                    this._tsExport.Click -= eventHandler;
                this._tsExport = value;
                if (this._tsExport == null)
                    return;
                this._tsExport.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsExportDataLink
        {
            get
            {
                return this._tsExportDataLink;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsExportDataLink_Click);
                if (this._tsExportDataLink != null)
                    this._tsExportDataLink.Click -= eventHandler;
                this._tsExportDataLink = value;
                if (this._tsExportDataLink == null)
                    return;
                this._tsExportDataLink.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsExportLong
        {
            get
            {
                return this._tsExportLong;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsExportLong_Click);
                if (this._tsExportLong != null)
                    this._tsExportLong.Click -= eventHandler;
                this._tsExportLong = value;
                if (this._tsExportLong == null)
                    return;
                this._tsExportLong.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFileNew
        {
            get
            {
                return this._tsFileNew;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFileNew_Click);
                if (this._tsFileNew != null)
                    this._tsFileNew.Click -= eventHandler;
                this._tsFileNew = value;
                if (this._tsFileNew == null)
                    return;
                this._tsFileNew.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFileOpen
        {
            get
            {
                return this._tsFileOpen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFileOpen_Click);
                if (this._tsFileOpen != null)
                    this._tsFileOpen.Click -= eventHandler;
                this._tsFileOpen = value;
                if (this._tsFileOpen == null)
                    return;
                this._tsFileOpen.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFilePrint
        {
            get
            {
                return this._tsFilePrint;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFilePrint_Click);
                if (this._tsFilePrint != null)
                    this._tsFilePrint.Click -= eventHandler;
                this._tsFilePrint = value;
                if (this._tsFilePrint == null)
                    return;
                this._tsFilePrint.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFileQuit
        {
            get
            {
                return this._tsFileQuit;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFileQuit_Click);
                if (this._tsFileQuit != null)
                    this._tsFileQuit.Click -= eventHandler;
                this._tsFileQuit = value;
                if (this._tsFileQuit == null)
                    return;
                this._tsFileQuit.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFileSave
        {
            get
            {
                return this._tsFileSave;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFileSave_Click);
                if (this._tsFileSave != null)
                    this._tsFileSave.Click -= eventHandler;
                this._tsFileSave = value;
                if (this._tsFileSave == null)
                    return;
                this._tsFileSave.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFileSaveAs
        {
            get
            {
                return this._tsFileSaveAs;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFileSaveAs_Click);
                if (this._tsFileSaveAs != null)
                    this._tsFileSaveAs.Click -= eventHandler;
                this._tsFileSaveAs = value;
                if (this._tsFileSaveAs == null)
                    return;
                this._tsFileSaveAs.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsFlipAllEnh
        {
            get
            {
                return this._tsFlipAllEnh;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsFlipAllEnh_Click);
                if (this._tsFlipAllEnh != null)
                    this._tsFlipAllEnh.Click -= eventHandler;
                this._tsFlipAllEnh = value;
                if (this._tsFlipAllEnh == null)
                    return;
                this._tsFlipAllEnh.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsHelp
        {
            get
            {
                return this._tsHelp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsHelp_Click);
                if (this._tsHelp != null)
                    this._tsHelp.Click -= eventHandler;
                this._tsHelp = value;
                if (this._tsHelp == null)
                    return;
                this._tsHelp.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsHelperLong
        {
            get
            {
                return this._tsHelperLong;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsHelperLong_Click);
                if (this._tsHelperLong != null)
                    this._tsHelperLong.Click -= eventHandler;
                this._tsHelperLong = value;
                if (this._tsHelperLong == null)
                    return;
                this._tsHelperLong.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsHelperLong2
        {
            get
            {
                return this._tsHelperLong2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsHelperLong2_Click);
                if (this._tsHelperLong2 != null)
                    this._tsHelperLong2.Click -= eventHandler;
                this._tsHelperLong2 = value;
                if (this._tsHelperLong2 == null)
                    return;
                this._tsHelperLong2.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsHelperShort
        {
            get
            {
                return this._tsHelperShort;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsHelperShort_Click);
                if (this._tsHelperShort != null)
                    this._tsHelperShort.Click -= eventHandler;
                this._tsHelperShort = value;
                if (this._tsHelperShort == null)
                    return;
                this._tsHelperShort.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsHelperShort2
        {
            get
            {
                return this._tsHelperShort2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsHelperShort2_Click);
                if (this._tsHelperShort2 != null)
                    this._tsHelperShort2.Click -= eventHandler;
                this._tsHelperShort2 = value;
                if (this._tsHelperShort2 == null)
                    return;
                this._tsHelperShort2.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsImport
        {
            get
            {
                return this._tsImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsImport_Click);
                if (this._tsImport != null)
                    this._tsImport.Click -= eventHandler;
                this._tsImport = value;
                if (this._tsImport == null)
                    return;
                this._tsImport.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsIODefault
        {
            get
            {
                return this._tsIODefault;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsIODefault_Click);
                if (this._tsIODefault != null)
                    this._tsIODefault.Click -= eventHandler;
                this._tsIODefault = value;
                if (this._tsIODefault == null)
                    return;
                this._tsIODefault.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsIOMax
        {
            get
            {
                return this._tsIOMax;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsIOMax_Click);
                if (this._tsIOMax != null)
                    this._tsIOMax.Click -= eventHandler;
                this._tsIOMax = value;
                if (this._tsIOMax == null)
                    return;
                this._tsIOMax.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsIOMin
        {
            get
            {
                return this._tsIOMin;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsIOMin_Click);
                if (this._tsIOMin != null)
                    this._tsIOMin.Click -= eventHandler;
                this._tsIOMin = value;
                if (this._tsIOMin == null)
                    return;
                this._tsIOMin.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsLevelUp
        {
            get
            {
                return this._tsLevelUp;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsLevelUp_Click);
                if (this._tsLevelUp != null)
                    this._tsLevelUp.Click -= eventHandler;
                this._tsLevelUp = value;
                if (this._tsLevelUp == null)
                    return;
                this._tsLevelUp.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsPatchNotes
        {
            get
            {
                return this._tsPatchNotes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsPatchNotes_Click);
                if (this._tsPatchNotes != null)
                    this._tsPatchNotes.Click -= eventHandler;
                this._tsPatchNotes = value;
                if (this._tsPatchNotes == null)
                    return;
                this._tsPatchNotes.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsRecipeViewer
        {
            get
            {
                return this._tsRecipeViewer;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsRecipeViewer_Click);
                if (this._tsRecipeViewer != null)
                    this._tsRecipeViewer.Click -= eventHandler;
                this._tsRecipeViewer = value;
                if (this._tsRecipeViewer == null)
                    return;
                this._tsRecipeViewer.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsDPSCalc
        {
            get
            {
                return this._tsDPSCalc;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsDPSCalc_Click);
                if (this._tsDPSCalc != null)
                    this._tsDPSCalc.Click -= eventHandler;
                this._tsDPSCalc = value;
                if (this._tsDPSCalc == null)
                    return;
                this._tsDPSCalc.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsRemoveAllSlots
        {
            get
            {
                return this._tsRemoveAllSlots;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsRemoveAllSlots_Click);
                if (this._tsRemoveAllSlots != null)
                    this._tsRemoveAllSlots.Click -= eventHandler;
                this._tsRemoveAllSlots = value;
                if (this._tsRemoveAllSlots == null)
                    return;
                this._tsRemoveAllSlots.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsSetFind
        {
            get
            {
                return this._tsSetFind;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsSetFind_Click);
                if (this._tsSetFind != null)
                    this._tsSetFind.Click -= eventHandler;
                this._tsSetFind = value;
                if (this._tsSetFind == null)
                    return;
                this._tsSetFind.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsTitanForum
        {
            get
            {
                return this._tsTitanForum;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsTitanForum_Click);
                if (this._tsTitanForum != null)
                    this._tsTitanForum.Click -= eventHandler;
                this._tsTitanForum = value;
                if (this._tsTitanForum == null)
                    return;
                this._tsTitanForum.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsTitanPlanner
        {
            get
            {
                return this._tsTitanPlanner;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsTitanPlanner_Click);
                if (this._tsTitanPlanner != null)
                    this._tsTitanPlanner.Click -= eventHandler;
                this._tsTitanPlanner = value;
                if (this._tsTitanPlanner == null)
                    return;
                this._tsTitanPlanner.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsTitanSite
        {
            get
            {
                return this._tsTitanSite;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsTitanSite_Click);
                if (this._tsTitanSite != null)
                    this._tsTitanSite.Click -= eventHandler;
                this._tsTitanSite = value;
                if (this._tsTitanSite == null)
                    return;
                this._tsTitanSite.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsUpdateCheck
        {
            get
            {
                return this._tsUpdateCheck;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsUpdateCheck_Click);
                if (this._tsUpdateCheck != null)
                    this._tsUpdateCheck.Click -= eventHandler;
                this._tsUpdateCheck = value;
                if (this._tsUpdateCheck == null)
                    return;
                this._tsUpdateCheck.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsView2Col
        {
            get
            {
                return this._tsView2Col;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsView2Col_Click);
                if (this._tsView2Col != null)
                    this._tsView2Col.Click -= eventHandler;
                this._tsView2Col = value;
                if (this._tsView2Col == null)
                    return;
                this._tsView2Col.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsView3Col
        {
            get
            {
                return this._tsView3Col;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsView3Col_Click);
                if (this._tsView3Col != null)
                    this._tsView3Col.Click -= eventHandler;
                this._tsView3Col = value;
                if (this._tsView3Col == null)
                    return;
                this._tsView3Col.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsView4Col
        {
            get
            {
                return this._tsView4Col;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsView4Col_Click);
                if (this._tsView4Col != null)
                    this._tsView4Col.Click -= eventHandler;
                this._tsView4Col = value;
                if (this._tsView4Col == null)
                    return;
                this._tsView4Col.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewActualDamage_New
        {
            get
            {
                return this._tsViewActualDamage_New;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewActualDamage_New_Click);
                if (this._tsViewActualDamage_New != null)
                    this._tsViewActualDamage_New.Click -= eventHandler;
                this._tsViewActualDamage_New = value;
                if (this._tsViewActualDamage_New == null)
                    return;
                this._tsViewActualDamage_New.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewData
        {
            get
            {
                return this._tsViewData;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewData_Click);
                if (this._tsViewData != null)
                    this._tsViewData.Click -= eventHandler;
                this._tsViewData = value;
                if (this._tsViewData == null)
                    return;
                this._tsViewData.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewDPS_New
        {
            get
            {
                return this._tsViewDPS_New;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewDPS_New_Click);
                if (this._tsViewDPS_New != null)
                    this._tsViewDPS_New.Click -= eventHandler;
                this._tsViewDPS_New = value;
                if (this._tsViewDPS_New == null)
                    return;
                this._tsViewDPS_New.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewGraphs
        {
            get
            {
                return this._tsViewGraphs;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewGraphs_Click);
                if (this._tsViewGraphs != null)
                    this._tsViewGraphs.Click -= eventHandler;
                this._tsViewGraphs = value;
                if (this._tsViewGraphs == null)
                    return;
                this._tsViewGraphs.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewIOLevels
        {
            get
            {
                return this._tsViewIOLevels;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewIOLevels_Click);
                if (this._tsViewIOLevels != null)
                    this._tsViewIOLevels.Click -= eventHandler;
                this._tsViewIOLevels = value;
                if (this._tsViewIOLevels == null)
                    return;
                this._tsViewIOLevels.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewRelative
        {
            get
            {
                return this._tsViewRelative;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewRelative_Click);
                if (this._tsViewRelative != null)
                    this._tsViewRelative.Click -= eventHandler;
                this._tsViewRelative = value;
                if (this._tsViewRelative == null)
                    return;
                this._tsViewRelative.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewSetCompare
        {
            get
            {
                return this._tsViewSetCompare;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewSetCompare_Click);
                if (this._tsViewSetCompare != null)
                    this._tsViewSetCompare.Click -= eventHandler;
                this._tsViewSetCompare = value;
                if (this._tsViewSetCompare == null)
                    return;
                this._tsViewSetCompare.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewSets
        {
            get
            {
                return this._tsViewSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewSets_Click);
                if (this._tsViewSets != null)
                    this._tsViewSets.Click -= eventHandler;
                this._tsViewSets = value;
                if (this._tsViewSets == null)
                    return;
                this._tsViewSets.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewSlotLevels
        {
            get
            {
                return this._tsViewSlotLevels;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewSlotLevels_Click);
                if (this._tsViewSlotLevels != null)
                    this._tsViewSlotLevels.Click -= eventHandler;
                this._tsViewSlotLevels = value;
                if (this._tsViewSlotLevels == null)
                    return;
                this._tsViewSlotLevels.Click += eventHandler;
            }
        }

        ToolStripMenuItem tsViewTotals
        {
            get
            {
                return this._tsViewTotals;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.tsViewTotals_Click);
                if (this._tsViewTotals != null)
                    this._tsViewTotals.Click -= eventHandler;
                this._tsViewTotals = value;
                if (this._tsViewTotals == null)
                    return;
                this._tsViewTotals.Click += eventHandler;
            }
        }


        TextBox txtName
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
                    this._txtName.TextChanged -= eventHandler;
                this._txtName = value;
                if (this._txtName == null)
                    return;
                this._txtName.TextChanged += eventHandler;
            }
        }

        internal clsDrawX Drawing => this.drawing;

        public frmMain()
        {
            this.Load += new EventHandler(this.frmMain_Load);
            this.Closed += new EventHandler(this.frmMain_Closed);
            this.FormClosing += new FormClosingEventHandler(this.frmMain_Closing);
            this.ResizeEnd += new EventHandler(this.frmMain_Resize);
            this.KeyDown += new KeyEventHandler(this.frmMain_KeyDown);
            this.Resize += new EventHandler(this.frmMain_Maximize);
            this.MouseWheel += new MouseEventHandler(this.frmMain_MouseWheel);
            this.NoUpdate = false;
            this.EnhancingSlot = -1;
            this.EnhancingPower = -1;
            this.EnhPickerActive = false;
            this.PickerHID = -1;
            this.LastFileName = "";
            this.FileModified = false;
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.LastEnhPlaced = (I9Slot)null;
            this.dvLastPower = -1;
            this.dvLastEnh = -1;
            this.dvLastNoLev = true;
            this.DataViewLocked = false;
            this.fGraphCompare = (frmCompare)null;
            this.fGraphStats = (frmStats)null;
            this.fSets = (frmSetViewer)null;
            this.fTotals = (frmTotals)null;
            this.fRecipe = (frmRecipeViewer)null;
            this.fData = (frmData)null;
            this.fSetFinder = (frmSetFind)null;
            this.fAccolade = (frmAccolade)null;
            this.fTemp = (frmAccolade)null;
            this.fIncarnate = (frmIncarnate)null;
            this.fMini = (frmMiniList)null;
            this.ActivePopupBounds = new Rectangle(0, 0, 1, 1);
            this.LastState = FormWindowState.Normal;
            this.PopUpVisible = false;
            this.FlipSteps = 5;
            this.FlipInterval = 10;
            this.FlipStepDelay = 3;
            this.FlipActive = false;
            this.FlipPowerID = -1;
            this.FlipSlotState = new int[0];
            this.FlipGP = (PowerEntry)null;
            this.LastClickPlacedSlot = false;
            this.HasSentBack = false;
            this.HasSentForwards = false;
            this.NoResizeEvent = false;
            this.dragStartPower = -1;
            this.dragStartSlot = -1;
            this.ddsa = new short[20];
            this.DoneDblClick = false;
            this.InitializeComponent();
        }

        internal void ChildRequestedRedraw()
        {
            if (this.drawing != null)
                this.DoRedraw();
        }
        void accoladeButton_ButtonClicked()
        {
            this.PowerModified();
        }

        void accoladeButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            this.accoladeButton.Checked = false;
            if (this.fAccolade == null || this.fAccolade.IsDisposed)
            {
                IPower power = !MainModule.MidsController.Toon.IsHero() ? DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3258)] : DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3257)];
                List<IPower> iPowers = new List<IPower>();
                int num = power.NIDSubPower.Length - 1;
                for (int index = 0; index <= num; ++index)
                    iPowers.Add(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
                this.fAccolade = new frmAccolade(this, iPowers);
                this.fAccolade.Text = "Accolades";
            }
            if (!this.fAccolade.Visible)
                this.fAccolade.Show((IWin32Window)this);
        }

        void AccoladesWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.accoladeButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
            this.accoladeButton.Checked = true;
        }

        static int ArchetypeIndirectToIndex(int iIndirect)
        {
            int num1 = -1;
            int num2 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (DatabaseAPI.Database.Classes[index].Playable)
                {
                    ++num1;
                    if (num1 == iIndirect)
                        return index;
                }
            }
            return 0;
        }

        void AssemblePowerList(ref ListLabelV2 llPower, IPowerset Powerset)
        {
            if (Powerset == null)
            {
                llPower.SuspendRedraw = true;
                llPower.ClearItems();
                llPower.SuspendRedraw = false;
            }
            else
            {
                llPower.SuspendRedraw = true;
                llPower.ClearItems();
                bool flag = Powerset.nIDTrunkSet > -1;
                string message;
                if (flag)
                {
                    IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset.nIDTrunkSet];
                    ListLabelV2.ListLabelItemV2 iItem1 = new ListLabelV2.ListLabelItemV2(powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nIDTrunkSet, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
                    llPower.AddItem(iItem1);
                    int num = powerset.Powers.Length - 1;
                    for (int iIDXPower = 0; iIDXPower <= num; ++iIDXPower)
                    {
                        if (powerset.Powers[iIDXPower].Level > 0)
                        {
                            message = "";
                            ListLabelV2.ListLabelItemV2 iItem2 = new ListLabelV2.ListLabelItemV2(powerset.Powers[iIDXPower].DisplayName, MainModule.MidsController.Toon.PowerState(powerset.Powers[iIDXPower].PowerIndex, ref message), Powerset.nIDTrunkSet, iIDXPower, powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
                            {
                                Bold = MidsContext.Config.RtFont.PairedBold
                            };
                            if (iItem2.ItemState == ListLabelV2.LLItemState.Invalid)
                                iItem2.Italic = true;
                            llPower.AddItem(iItem2);
                        }
                    }
                }
                if (flag)
                {
                    ListLabelV2.ListLabelItemV2 iItem = new ListLabelV2.ListLabelItemV2(Powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nID, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
                    llPower.AddItem(iItem);
                }
                int num1 = 0;
                int num2 = Powerset.Powers.Length - 1;
                for (int iIDXPower = 0; iIDXPower <= num2; ++iIDXPower)
                {
                    if (Powerset.Powers[iIDXPower].Level > 0)
                    {
                        message = "";
                        ListLabelV2.ListLabelItemV2 iItem = new ListLabelV2.ListLabelItemV2(Powerset.Powers[iIDXPower].DisplayName, MainModule.MidsController.Toon.PowerState(Powerset.Powers[iIDXPower].PowerIndex, ref message), Powerset.nID, iIDXPower, Powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
                        {
                            Bold = MidsContext.Config.RtFont.PairedBold
                        };
                        if (iItem.ItemState == ListLabelV2.LLItemState.Invalid)
                            iItem.Italic = true;
                        llPower.AddItem(iItem);
                        ++num1;
                    }
                }
                llPower.SuspendRedraw = false;
            }
        }

        void AutoArrangeAllSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PowerEntry[] powerEntryArray = frmMain.DeepCopyPowerList();
            this.RearrangeAllSlotsInBuild(powerEntryArray, true);
            this.ShallowCopyPowerList(powerEntryArray);
            this.PowerModified();
            this.DoRedraw();
        }

        void cbAncillary_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbAncillary = this.cbAncillary;
            frmMain.cbDrawItem(ref cbAncillary, Enums.ePowerSetType.Ancillary, e);
            this.cbAncillary = cbAncillary;
        }

        void cbAncillary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[7] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.cbAncillary.Bounds, ExtraString);
        }

        void cbAncillery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbAT_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.DrawBackground();
            SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
            if (e.Index > -1)
            {
                int index = frmMain.ArchetypeIndirectToIndex(e.Index);
                RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
                RectangleF srcRect = new RectangleF((float)(index * 16), 0.0f, 16f, 16f);
                e.Graphics.DrawImage((Image)I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center
                };
                RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
                e.Graphics.DrawString(Conversions.ToString(NewLateBinding.LateGet(this.cbAT.Items[e.Index], (System.Type)null, "DisplayName", new object[0], (string[])null, (System.Type[])null, (bool[])null)), e.Font, (Brush)solidBrush, layoutRectangle, format);
            }
            e.DrawFocusRectangle();
        }

        void cbAT_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void cbAT_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || this.cbAT.SelectedIndex < 0)
                return;
            this.ShowPopup(-1, Conversions.ToInteger(NewLateBinding.LateGet(this.cbAT.SelectedItem, (System.Type)null, "Idx", new object[0], (string[])null, (System.Type[])null, (bool[])null)), this.cbAT.Bounds, "");
        }

        void cbAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.NewToon(false, false);
            this.SetFormHeight(false);
            this.SetAncilPoolHeight();
            this.GetBestDamageValues();
        }

        static void cbDrawItem(
          ref ComboBox Target,
          Enums.ePowerSetType SetType,
          DrawItemEventArgs e)
        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.DrawBackground();
            SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, SetType);
            if (e.Index > -1 & e.Index < powersetIndexes.Length)
            {
                int nId = powersetIndexes[e.Index].nID;
                RectangleF destRect = new RectangleF();
                ref RectangleF local1 = ref destRect;
                Rectangle bounds = e.Bounds;
                double num1 = (double)(bounds.X + 1);
                bounds = e.Bounds;
                double y1 = (double)bounds.Y;
                local1 = new RectangleF((float)num1, (float)y1, 16f, 16f);
                RectangleF srcRect = new RectangleF((float)(nId * 16), 0.0f, 16f, 16f);
                if ((e.State & DrawItemState.ComboBoxEdit) > DrawItemState.None)
                {
                    double width = (double)e.Graphics.MeasureString(Conversions.ToString(Target.Items[e.Index]), e.Font).Width;
                    bounds = e.Bounds;
                    double num2 = (double)(bounds.Width - 10);
                    if (width <= num2)
                        e.Graphics.DrawImage((Image)I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    else
                        destRect.Width = 0.0f;
                }
                else
                    e.Graphics.DrawImage((Image)I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center
                };
                RectangleF layoutRectangle = new RectangleF();
                ref RectangleF local2 = ref layoutRectangle;
                bounds = e.Bounds;
                double num3 = (double)bounds.X + (double)destRect.X + (double)destRect.Width;
                bounds = e.Bounds;
                double y2 = (double)bounds.Y;
                bounds = e.Bounds;
                double width1 = (double)bounds.Width;
                bounds = e.Bounds;
                double height = (double)bounds.Height;
                local2 = new RectangleF((float)num3, (float)y2, (float)width1, (float)height);
                e.Graphics.DrawString(Conversions.ToString(Target.Items[e.Index]), e.Font, (Brush)solidBrush, layoutRectangle, format);
            }
            e.DrawFocusRectangle();
        }

        void cbOrigin_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.DrawBackground();
            SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
            if (e.Index > -1)
            {
                RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
                RectangleF srcRect = new RectangleF((float)(DatabaseAPI.GetOriginIDByName(Conversions.ToString(this.cbOrigin.Items[e.Index])) * 16), 0.0f, 16f, 16f);
                e.Graphics.DrawImage((Image)I9Gfx.Origins.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center
                };
                RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
                e.Graphics.DrawString(Conversions.ToString(this.cbOrigin.Items[e.Index]), e.Font, (Brush)solidBrush, layoutRectangle, format);
            }
            e.DrawFocusRectangle();
        }

        void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            MidsContext.Character.Origin = this.cbOrigin.SelectedIndex;
            I9Gfx.SetOrigin(Conversions.ToString(this.cbOrigin.SelectedItem));
            if (this.drawing != null)
                this.DoRedraw();
            this.DisplayName();
        }

        void cbPool0_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool0 = this.cbPool0;
            frmMain.cbDrawItem(ref cbPool0, Enums.ePowerSetType.Pool, e);
            this.cbPool0 = cbPool0;
        }

        void cbPool0_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void cbPool0_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[3] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
        }

        void cbPool0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbPool1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool1 = this.cbPool1;
            frmMain.cbDrawItem(ref cbPool1, Enums.ePowerSetType.Pool, e);
            this.cbPool1 = cbPool1;
        }

        void cbPool1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[4] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
        }

        void cbPool1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbPool2_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool2 = this.cbPool2;
            frmMain.cbDrawItem(ref cbPool2, Enums.ePowerSetType.Pool, e);
            this.cbPool2 = cbPool2;
        }

        void cbPool2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[5] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
        }

        void cbPool2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbPool3_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool3 = this.cbPool3;
            frmMain.cbDrawItem(ref cbPool3, Enums.ePowerSetType.Pool, e);
            this.cbPool3 = cbPool3;
        }

        void cbPool3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[6] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
        }

        void cbPool3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbPrimary_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPrimary = this.cbPrimary;
            frmMain.cbDrawItem(ref cbPrimary, Enums.ePowerSetType.Primary, e);
            this.cbPrimary = cbPrimary;
        }

        void cbPrimary_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void cbPrimary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MidsContext.Character == null || MidsContext.Character.Archetype == null || this.cbPrimary.SelectedIndex < 0)
                return;
            string ExtraString = "This is your primary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
            this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Primary)[this.cbPrimary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbPrimary.Bounds, ExtraString);
        }

        void cbPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbSecondary_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbSecondary = this.cbSecondary;
            frmMain.cbDrawItem(ref cbSecondary, Enums.ePowerSetType.Secondary, e);
            this.cbSecondary = cbSecondary;
        }

        void cbSecondary_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void cbSecondary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Archetype.Idx < 0 || this.cbSecondary.SelectedIndex < 0)
                return;
            string ExtraString = MidsContext.Character.Powersets[0].nIDLinkSecondary <= -1 ? "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set." : "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
            this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
        }

        void cbSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void ChangeSets()
        {
            IPowerset[] powersetIndexes1 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Primary);
            IPowerset[] powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary);
            IPowerset[] powersetIndexes3 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Pool);
            IPowerset[] powersetIndexes4 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Ancillary);
            if (MainModule.MidsController.Toon != null)
            {
                IPowerset powerset1 = MidsContext.Character.Powersets[0];
                IPowerset newPowerset1 = powersetIndexes1[this.cbPrimary.SelectedIndex];
                if (powerset1.nID != newPowerset1.nID)
                    MainModule.MidsController.Toon.SwitchSets(newPowerset1, powerset1);
                if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                {
                    IPowerset powerset2 = MidsContext.Character.Powersets[1];
                    IPowerset powerset3 = DatabaseAPI.Database.Powersets[MidsContext.Character.Powersets[0].nIDLinkSecondary];
                    if (powerset2.nID != powerset3.nID)
                        MainModule.MidsController.Toon.SwitchSets(powerset3, powerset2);
                }
                else
                {
                    this.cbSecondary.Enabled = true;
                    IPowerset powerset2 = MidsContext.Character.Powersets[1];
                    IPowerset newPowerset2 = powersetIndexes2[this.cbSecondary.SelectedIndex];
                    if (powerset2.nID != newPowerset2.nID)
                        MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
                }
            }
            else
            {
                MidsContext.Character.Powersets[0] = powersetIndexes1[this.cbPrimary.SelectedIndex];
                MidsContext.Character.Powersets[1] = powersetIndexes2[this.cbSecondary.SelectedIndex];
            }
            MidsContext.Character.Powersets[3] = powersetIndexes3[this.cbPool0.SelectedIndex];
            MidsContext.Character.Powersets[4] = powersetIndexes3[this.cbPool1.SelectedIndex];
            MidsContext.Character.Powersets[5] = powersetIndexes3[this.cbPool2.SelectedIndex];
            MidsContext.Character.Powersets[6] = powersetIndexes3[this.cbPool3.SelectedIndex];
            if (powersetIndexes4.Length > 0)
                MidsContext.Character.Powersets[7] = powersetIndexes4[this.cbAncillary.SelectedIndex];
            MidsContext.Character.Validate();
            this.DataViewLocked = false;
            this.ActiveControl = (Control)this.llPrimary;
            this.PowerModified();
            this.FloatUpdate(true);
            this.GetBestDamageValues();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void CheckForDownloadedUpdate()
        {
            try
            {
                if (!File.Exists(FileIO.AddSlash(Application.StartupPath) + "MHD.mhz") || !Zlib.CheckTag(FileIO.AddSlash(Application.StartupPath) + "MHD.mhz"))
                    return;
                int num = (int)Interaction.MsgBox((object)("A recently downloaded update pack has not yet been applied!\r\n\r\nIn order for a previously downloaded update to be applied, Mids' Hero/Villain designer must restart.\r\n\r\nThe program will now exit to apply the update. Please close any other running instances of Mids' Hero/Villain Designer.If this message is in error, please delete the MHD.mhz file from " + Application.StartupPath + " directory."), MsgBoxStyle.Information, (object)"Update Pending");
                clsXMLUpdate.LaunchSelfUpdate();
                ProjectData.EndApp();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)Interaction.MsgBox((object)("An unexpected error was encountered when checking for a downloaded pack.\r\nIf you see this error again, delete the 'MHD.mhz' file from the " + Application.StartupPath + " directory."), MsgBoxStyle.Exclamation, (object)"Non-Fatal Error");
                ProjectData.ClearProjectError();
            }
        }

        void clearPower(PowerEntry[] tp, int pwrIdx)
        {
            tp[pwrIdx].Slots = new SlotEntry[0];
            tp[pwrIdx].SubPowers = new PowerSubEntry[0];
            tp[pwrIdx].IDXPower = -1;
            tp[pwrIdx].NIDPower = -1;
            tp[pwrIdx].NIDPowerset = -1;
            tp[pwrIdx].Tag = false;
            tp[pwrIdx].StatInclude = false;
        }

        internal bool CloseCommand()
        {
            bool flag1 = false;
            bool flag2;
            if (MainModule.MidsController.Toon == null)
            {
                flag2 = false;
            }
            else
            {
                if (MainModule.MidsController.Toon.Locked & this.FileModified)
                {
                    this.FloatTop(false);
                    MsgBoxResult msgBoxResult = Interaction.MsgBox((object)"Do you wish to save your hero/villain data before quitting?", MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question, (object)"Question");
                    this.FloatTop(true);
                    int num;
                    switch (msgBoxResult)
                    {
                        case MsgBoxResult.Cancel:
                            return true;
                        case MsgBoxResult.Yes:
                            num = this.doSave() ? 1 : 0;
                            break;
                        default:
                            num = 1;
                            break;
                    }
                    if (num == 0)
                        flag1 = true;
                }
                flag2 = flag1;
            }
            return flag2;
        }

        bool ComboCheckAT(ref Archetype[] playableClasses)
        {
            bool flag;
            if (this.cbAT.Items.Count != playableClasses.Length)
            {
                flag = true;
            }
            else
            {
                int num = playableClasses.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(this.cbAT.Items[index], (System.Type)null, "Idx", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)playableClasses[index].Idx, false))
                        return true;
                }
                flag = false;
            }
            return flag;
        }

        bool ComboCheckOrigin()
        {
            bool flag;
            if (this.cbOrigin.Items.Count != MidsContext.Character.Archetype.Origin.Length)
            {
                flag = true;
            }
            else
            {
                if (this.cbOrigin.Items.Count <= 1)
                {
                    int num = MidsContext.Character.Archetype.Origin.Length - 1;
                    for (int index = 0; index <= num; ++index)
                    {
                        if (Conversions.ToString(this.cbOrigin.Items[index]) != MidsContext.Character.Archetype.Origin[index])
                            return true;
                    }
                }
                flag = false;
            }
            return flag;
        }

        static bool ComboCheckPool(ref ComboBox iCB, Enums.ePowerSetType iSetType)
        {
            bool flag1 = false;
            bool flag2 = false;
            string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
            if (iCB.Items.Count != powersetNames.Length)
            {
                flag2 = true;
            }
            else
            {
                int num = iCB.Items.Count - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (Conversions.ToString(iCB.Items[index]) != powersetNames[index])
                    {
                        flag2 = true;
                        break;
                    }
                }
            }
            bool flag3;
            if (!flag2)
            {
                flag3 = false;
            }
            else
            {
                iCB.BeginUpdate();
                iCB.Items.Clear();
                iCB.Items.AddRange((object[])powersetNames);
                iCB.EndUpdate();
                flag3 = flag1;
            }
            return flag3;
        }

        static bool ComboCheckPS(
          ref ComboBox iCB,
          Enums.PowersetType iSetID,
          Enums.ePowerSetType iSetType)
        {
            bool flag1 = false;
            bool flag2 = false;
            string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
            if (iCB.Items.Count != powersetNames.Length)
                flag2 = true;
            int num = iCB.Items.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (Conversions.ToString(iCB.Items[index]) != powersetNames[index])
                {
                    flag2 = true;
                    break;
                }
            }
            if (flag2)
            {
                iCB.BeginUpdate();
                iCB.Items.Clear();
                iCB.Items.AddRange((object[])powersetNames);
                iCB.EndUpdate();
            }
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, iSetType);
            iCB.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[(int)iSetID], powersetIndexes);
            return flag1;
        }

        void command_ForumImport()
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                MsgBoxResult msgBoxResult = Interaction.MsgBox((object)"Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Question");
                this.FloatTop(true);
                if (msgBoxResult == MsgBoxResult.No)
                    return;
            }
            this.FloatTop(false);
            this.FileModified = false;
            bool flag = false;
            if (Interaction.MsgBox((object)"Copy the build data on the forum to the clipboard. When that's done, click on OK.", MsgBoxStyle.OkCancel | MsgBoxStyle.Information, (object)"Standing By") != MsgBoxResult.Ok)
                return;
            string str = Clipboard.GetDataObject().GetData("System.String", true).ToString();
            this.NewToon(true, false);
            try
            {
                if (str.Length < 1)
                {
                    int num = (int)Interaction.MsgBox((object)"No data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, (object)"Forum Import");
                }
                else
                {
                    if (str.Contains("MxDz") | str.Contains("MxDu"))
                    {
                        Stream mStream = (Stream)new MemoryStream(new ASCIIEncoding().GetBytes(str));
                        flag = MainModule.MidsController.Toon.Load("", ref mStream);
                    }
                    else if (str.Contains("Character Profile:") || str.Contains("build.txt"))
                    {
                        this.GameImport(str);
                        flag = true;
                    }
                    if (!flag)
                        flag = MainModule.MidsController.Toon.StringToInternalData(str);
                    if (flag)
                    {
                        this.drawing.Highlight = -1;
                        this.NewDraw(false);
                        this.myDataView.Clear();
                        this.PowerModified();
                        this.UpdateControls(true);
                        this.SetFormHeight(false);
                    }
                    else
                    {
                        this.NewToon(true, false);
                        this.myDataView.Clear();
                        this.PowerModified();
                    }
                    this.GetBestDamageValues();
                    if (this.drawing != null)
                        this.DoRedraw();
                    this.UpdateColours(false);
                    this.FloatTop(true);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                this.FloatTop(true);
                ProjectData.ClearProjectError();
            }
        }

        void command_New()
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                MsgBoxResult msgBoxResult = Interaction.MsgBox((object)"Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Question");
                this.FloatTop(true);
                if (msgBoxResult == MsgBoxResult.No)
                    return;
            }
            this.DataViewLocked = false;
            this.NewToon(false, false);
            MidsContext.Config.LastFileName = "";
            this.LastFileName = "";
            this.PowerModified();
            this.SetTitleBar(true);
            this.myDataView.Clear();
        }

        internal void DataView_SlotFlip(int PowerIndex)
        {
            this.StartFlip(PowerIndex);
        }

        internal void DataView_SlotUpdate()
        {
            this.DoRedraw();
            this.RefreshInfo();
        }

        static PowerEntry[] DeepCopyPowerList()
        {
            PowerEntry[] powerEntryArray = new PowerEntry[MidsContext.Character.CurrentBuild.Powers.Count - 1 + 1];
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; ++index)
                powerEntryArray[index] = (PowerEntry)MidsContext.Character.CurrentBuild.Powers[index].Clone();
            return powerEntryArray;
        }

        Rectangle Dilate(Rectangle irect, int iAdd)
        {
            irect.X -= iAdd;
            irect.Y -= iAdd;
            irect.Height += iAdd * 2;
            irect.Width += iAdd * 2;
            return irect;
        }

        void DisplayFormatChanged()
        {
            this.GetBestDamageValues();
            this.RefreshInfo();
        }

        void DisplayName()
        {
            string str1 = "";
            string str2 = "";
            int level = MidsContext.Character.Level;
            if (!(MidsContext.Character.CurrentBuild.TotalSlotsAvailable - MidsContext.Character.CurrentBuild.SlotsPlaced < 1 & MidsContext.Character.CurrentBuild.LastPower + 1 - MidsContext.Character.CurrentBuild.PowersPlaced < 1) && MidsContext.Character.Level > 0)
                str1 = " (Placing " + Conversions.ToString(MidsContext.Character.Level + 1) + ")";
            this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
            string str3 = MidsContext.Character.Name + ": ";
            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp & str1 != "")
                str3 = str3 + "Level " + Conversions.ToString(level) + str1 + " ";
            string str4 = str3 + MidsContext.Character.Archetype.Origin[MidsContext.Character.Origin] + " " + MidsContext.Character.Archetype.DisplayName;
            if (MainModule.MidsController.Toon.Locked)
                str4 = str4 + " (" + MidsContext.Character.Powersets[0].DisplayName + " / " + MidsContext.Character.Powersets[1].DisplayName + ")" + str2;
            if (MidsContext.Config.ExempLow < MidsContext.Config.ExempHigh)
                str4 = str4 + " - Exemped from " + Conversions.ToString(MidsContext.Config.ExempHigh) + " to " + Conversions.ToString(MidsContext.Config.ExempLow);
            this.lblHero.Text = str4;
            if (!(this.txtName.Text != MidsContext.Character.Name))
                return;
            this.txtName.Text = MidsContext.Character.Name;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        void doFlipStep()
        {
            if (!this.FlipActive)
                return;
            Point point1 = new Point();
            Build currentBuild = MidsContext.Character.CurrentBuild;
            int flipPowerId = this.FlipPowerID;
            PowerEntry power = currentBuild.Powers[flipPowerId];
            currentBuild.Powers[flipPowerId] = power;
            Point point2 = this.drawing.DrawPowerSlot(ref power, false);
            int index = -1;
            int Enh1 = -1;
            int Enh2 = -1;
            I9Slot i9Slot1 = (I9Slot)null;
            I9Slot i9Slot2 = (I9Slot)null;
            ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MainModule.MidsController.Toon.IsHero());
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            int num1 = this.FlipSlotState.Length - 1;
            Rectangle rectangle1;
            for (int Index = 0; Index <= num1; ++Index)
            {
                point1.X = (int)Math.Round((double)point2.X + (double)(this.drawing.szPower.Width - this.drawing.szSlot.Width * 6) / 2.0);
                point1.Y = point2.Y + 18;
                ++this.FlipSlotState[Index];
                float num2 = 1f;
                if (this.FlipSlotState[Index] < 0)
                {
                    index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                    Enh1 = index;
                    Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                    i9Slot1 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                    i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                }
                else if (this.FlipSlotState[Index] > this.FlipSteps)
                {
                    index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                    Enh1 = index;
                    Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                    i9Slot1 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                    i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                }
                if (this.FlipSlotState[Index] >= 0 & this.FlipSlotState[Index] <= this.FlipSteps)
                {
                    float num3 = (float)this.FlipSlotState[Index] / ((float)this.FlipSteps / 2f);
                    if ((double)num3 > 1.0)
                    {
                        num2 = (float)(-1.0 * (1.0 - (double)num3));
                        index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                        Enh1 = index;
                        Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                        i9Slot1 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                        i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                    }
                    else
                    {
                        num2 = 1f - num3;
                        index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                        Enh1 = index;
                        Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                        i9Slot1 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                        i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                    }
                }
                rectangle1 = new Rectangle(point1.X + 30 * Index, point1.Y, 30, 30);
                if ((double)num2 > 0.0)
                {
                    Rectangle rectangle2 = new Rectangle((int)Math.Round((double)rectangle1.X + (30.0 - 30.0 * (double)num2) / 2.0), rectangle1.Y, (int)Math.Round(30.0 * (double)num2), 30);
                    rectangle2 = this.drawing.ScaleDown(rectangle2);
                    rectangle1 = this.drawing.ScaleDown(rectangle1);
                    if (index > -1)
                    {
                        Graphics graphics = this.drawing.bxBuffer.Graphics;
                        I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle1, num2, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[index].TypeID, i9Slot1.Grade));
                    }
                    else
                        this.drawing.bxBuffer.Graphics.DrawImage((Image)I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                    if (MidsContext.Config.CalcEnhLevel == Enums.eEnhRelative.None | MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Level >= MidsContext.Config.ForceLevel | this.drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].StatInclude)
                    {
                        rectangle2.Inflate(1, 1);
                        this.drawing.bxBuffer.Graphics.FillEllipse((Brush)solidBrush, rectangle2);
                    }
                    if (!(this.myDataView == null | i9Slot1 == null | i9Slot2 == null))
                        this.myDataView.FlipStage(Index, Enh1, Enh2, num2, MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].NIDPower, i9Slot1.Grade, i9Slot2.Grade);
                }
            }
            rectangle1 = new Rectangle(point1.X - 1, point1.Y - 1, this.drawing.szPower.Width + 1, this.drawing.szSlot.Height + 1);
            this.drawing.Refresh(this.drawing.ScaleDown(rectangle1));
            if (this.FlipSlotState[this.FlipSlotState.Length - 1] >= this.FlipSteps)
                this.EndFlip();
        }

        bool DoOpen(string fName)
        {
            bool flag;
            if (!File.Exists(fName))
            {
                flag = false;
            }
            else
            {
                this.DataViewLocked = false;
                this.NewToon(true, true);
                Stream mStream = (Stream)null;
                if (fName.Contains(".txt"))
                    this.GameImport(fName);
                else if (!MainModule.MidsController.Toon.Load(fName, ref mStream))
                {
                    this.NewToon(true, false);
                    this.LastFileName = "";
                    MidsContext.Config.LastFileName = "";
                }
                else
                {
                    this.LastFileName = fName;
                    if (!fName.EndsWith("mids_build.mxd"))
                        MidsContext.Config.LastFileName = fName;
                }
                this.FileModified = false;
                this.drawing.Highlight = -1;
                this.NewDraw(false);
                this.UpdateControls(false);
                this.SetFormHeight(false);
                this.myDataView.Clear();
                MidsContext.Character.ResetLevel();
                this.PowerModified();
                this.UpdateControls(true);
                this.SetTitleBar(true);
                Application.DoEvents();
                this.GetBestDamageValues();
                this.UpdateColours(false);
                this.FloatUpdate(true);
                flag = true;
            }
            return flag;
        }

        void DoRedraw()
        {
            this.NoResizeEvent = true;
            int width = this.pnlGFXFlow.Width;
            int height = this.pnlGFXFlow.Height;
            double num1 = 1.0;
            Size drawingArea = this.drawing.GetDrawingArea();
            int num2 = 30;
            int num3 = width - num2;
            if (num3 < drawingArea.Width)
                num1 = (double)num3 / (double)drawingArea.Width;
            int num4 = (int)Math.Round((double)drawingArea.Height * num1);
            this.pnlGFX.Width = num3;
            this.pnlGFX.Height = num4;
            this.pnlGFX.Update();
            this.pnlGFXFlow.Update();
            this.NoResizeEvent = false;
            this.drawing.FullRedraw();
        }

        void DoResize()
        {
            this.lblHero.Width = this.ibRecipe.Left - 4;
            if (this.NoResizeEvent || this.drawing == null)
                return;
            int num1 = this.ClientSize.Width - this.pnlGFXFlow.Left;
            int num2 = this.ClientSize.Height - this.pnlGFXFlow.Top;
            this.pnlGFXFlow.Width = num1;
            this.pnlGFXFlow.Height = num2;
            double num3 = 1.0;
            Size drawingArea = this.drawing.GetDrawingArea();
            int num4 = 30;
            int num5 = num1 - num4;
            if (num5 < drawingArea.Width)
                num3 = (double)num5 / (double)drawingArea.Width;
            int num6 = (int)Math.Round((double)drawingArea.Height * num3);
            this.pnlGFX.Width = num5;
            this.pnlGFX.Height = num6;
            if (this.drawing.Scaling & num3 == 1.0 | num3 != 1.0)
            {
                this.drawing.bxBuffer.Size = this.pnlGFX.Size;
                Control pnlGfx = (Control)this.pnlGFX;
                this.drawing.ReInit(ref pnlGfx);
                this.pnlGFX = (PictureBox)pnlGfx;
                this.pnlGFX.Image = (Image)this.drawing.bxBuffer.Bitmap;
            }
            this.NoResizeEvent = true;
            if (num3 < 1.0)
                this.drawing.SetScaling(this.pnlGFX.Size);
            else
                this.drawing.SetScaling(this.drawing.bxBuffer.Size);
            this.NoResizeEvent = false;
            this.ReArrange(false);
        }

        bool doSave()
        {
            bool flag;
            if (this.LastFileName == "")
                flag = this.doSaveAs();
            else if (this.LastFileName.Length > 3 && this.LastFileName.ToUpper().EndsWith(".TXT"))
            {
                flag = this.doSaveAs();
            }
            else
            {
                MainModule.MidsController.Toon.Save(this.LastFileName);
                this.FileModified = false;
                flag = true;
            }
            return flag;
        }

        bool doSaveAs()
        {
            this.FloatTop(false);
            if (this.LastFileName != "")
            {
                this.dlgSave.FileName = FileIO.StripPath(this.LastFileName);
                if (this.dlgSave.FileName.Length > 3 && this.dlgSave.FileName.ToUpper().EndsWith(".TXT"))
                    this.dlgSave.FileName = this.dlgSave.FileName.Substring(0, this.dlgSave.FileName.Length - 3) + this.dlgSave.DefaultExt;
                this.dlgSave.InitialDirectory = this.LastFileName.Substring(0, this.LastFileName.LastIndexOf("\\", StringComparison.Ordinal));
            }
            else if (MidsContext.Character.Name != "")
            {
                if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
                    this.dlgSave.FileName = MidsContext.Character.Name + " - Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", "").Replace("Arachnos ", "");
                else
                    this.dlgSave.FileName = MidsContext.Character.Name + " - " + MidsContext.Character.Archetype.DisplayName + " (" + MidsContext.Character.Powersets[0].DisplayName + ")";
            }
            else if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
            {
                this.dlgSave.FileName = "Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", "").Replace("Arachnos ", "");
            }
            else
            {
                this.dlgSave.FileName = MidsContext.Character.Archetype.DisplayName;
                SaveFileDialog dlgSave = this.dlgSave;
                dlgSave.FileName = dlgSave.FileName + " - " + MidsContext.Character.Powersets[0].DisplayName + " - " + MidsContext.Character.Powersets[1].DisplayName;
            }
            bool flag;
            if (this.dlgSave.ShowDialog() == DialogResult.OK)
            {
                MainModule.MidsController.Toon.Save(this.dlgSave.FileName);
                this.FileModified = false;
                this.LastFileName = this.dlgSave.FileName;
                MidsContext.Config.LastFileName = this.dlgSave.FileName;
                this.SetTitleBar(true);
                this.FloatTop(true);
                flag = true;
            }
            else
            {
                this.FloatTop(true);
                flag = false;
            }
            return flag;
        }

        void dvAnchored_Float()
        {
            frmMain iOwner = this;
            this.FloatingDataForm = new frmFloatingStats(ref iOwner);
            this.FloatingDataForm.Left = this.Left + this.dvAnchored.Left;
            this.FloatingDataForm.Top = this.Top + this.dvAnchored.Top;
            this.FloatingDataForm.dvFloat.VisibleSize = this.dvAnchored.VisibleSize;
            this.myDataView = this.FloatingDataForm.dvFloat;
            this.myDataView.TabPage = this.dvAnchored.TabPage;
            this.FloatingDataForm.dvFloat.Init();
            this.FloatingDataForm.dvFloat.SetFontData();
            this.myDataView.BackColor = this.BackColor;
            this.myDataView.DrawVillain = !MainModule.MidsController.Toon.IsHero();
            this.dvAnchored.Visible = false;
            this.pnlGFX.Select();
            this.FloatingDataForm.Show();
            this.RefreshInfo();
            this.ReArrange(false);
            if (this.dvLastPower <= -1)
                return;
            this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
        }

        void dvAnchored_Move()
        {
            this.PriSec_ExpandChanged(true);
            this.ReArrange(false);
        }

        void dvAnchored_SizeChange(Size newSize, bool Compact)
        {
            this.ReArrange(false);
            if (!(MainModule.MidsController.IsAppInitialized & this.Visible))
                return;
            MidsContext.Config.DvState = this.dvAnchored.VisibleSize;
        }

        void dvAnchored_TabChanged(int Index)
        {
            this.SetDataViewTab(Index);
        }

        void dvAnchored_Unlock()
        {
            this.DataViewLocked = false;
            if (this.dvLastPower <= -1)
                return;
            this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
        }

        bool EditAccoladesOrTemps(int hIDPower)
        {
            bool flag;
            if (hIDPower <= -1 || MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length <= 0)
            {
                flag = false;
            }
            else
            {
                List<IPower> iPowers = new List<IPower>();
                int num1 = MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length - 1;
                for (int index = 0; index <= num1; ++index)
                    iPowers.Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers[index].nIDPower]);
                frmAccolade frmAccolade = new frmAccolade(this, iPowers);
                frmAccolade.Text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower].DisplayName;
                frmAccolade.ShowDialog(this);
                this.EnhancementModified();
                this.LastClickPlacedSlot = false;
                flag = true;
            }
            return flag;
        }

        void EndFlip()
        {
            this.FlipActive = false;
            this.tmrGfx.Enabled = false;
            this.FlipPowerID = -1;
            this.FlipSlotState = new int[0];
            this.DoRedraw();
        }

        void EnhancementModified()
        {
            this.DoRedraw();
            this.RefreshInfo();
        }

        int[] fakeInitialize(params int[] nums)
        {
            return nums;
        }

        void FixPrimarySecondaryHeight()
        {
            if (this.dvAnchored.Visible & this.dvAnchored.Bounds.IntersectsWith(this.dvAnchored.SnapLocation))
            {
                Size size = this.ClientSize;
                int height = size.Height - this.dvAnchored.Height - this.cbPrimary.Top - this.cbPrimary.Height - 10;
                if (this.llPrimary.DesiredHeight < height)
                {
                    size = this.llPrimary.SizeNormal;
                    this.llPrimary.SizeNormal = new Size(size.Width, this.llPrimary.DesiredHeight);
                }
                else
                {
                    if (height < 70)
                        height = 70;
                    size = new Size(this.llPrimary.SizeNormal.Width, height);
                    this.llPrimary.SizeNormal = size;
                }
                if (this.llSecondary.DesiredHeight < height)
                {
                    size = new Size(this.llSecondary.SizeNormal.Width, this.llSecondary.DesiredHeight);
                    this.llSecondary.SizeNormal = size;
                }
                else
                {
                    if (height < 70)
                        height = 70;
                    size = new Size(this.llSecondary.SizeNormal.Width, height);
                    this.llSecondary.SizeNormal = size;
                }
            }
            else
            {
                Size size = new Size(this.llPrimary.SizeNormal.Width, this.llPrimary.DesiredHeight);
                this.llPrimary.SizeNormal = size;
                size = new Size(this.llSecondary.SizeNormal.Width, this.llSecondary.DesiredHeight);
                this.llSecondary.SizeNormal = size;
            }
        }

        void fixStatIncludes()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet != null)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet.DisplayName == "Temporary Powers")
                        MidsContext.Character.CurrentBuild.Powers[index].StatInclude = this.tempPowersButton.Checked;
                    else if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet.DisplayName == "Accolades")
                        MidsContext.Character.CurrentBuild.Powers[index].StatInclude = this.accoladeButton.Checked;
                }
            }
        }

        internal void FloatCompareGraph(bool Show)
        {
            if (Show)
            {
                if (this.fGraphCompare == null)
                {
                    frmMain iFrm = this;
                    this.fGraphCompare = new frmCompare(ref iFrm);
                }
                this.fGraphCompare.SetLocation();
                this.fGraphCompare.Show();
                this.fGraphCompare.Activate();
            }
            else
            {
                if (this.fGraphCompare == null)
                    return;
                this.fGraphCompare.Hide();
                this.fGraphCompare.Dispose();
                this.fGraphCompare = (frmCompare)null;
            }
        }

        void FloatData(bool show)
        {
            if (show)
            {
                if (this.fData == null)
                {
                    frmMain iParent = this;
                    this.fData = new frmData(() => this.FloatData(false));
                }
                this.fData.SetLocation();
                this.fData.Show();
                this.FloatUpdate(false);
                this.fData.Activate();
            }
            else
            {
                if (this.fData == null)
                    return;
                this.fData.Hide();
                this.fData.Dispose();
                this.fData = (frmData)null;
            }
        }

        internal void FloatRecipe(bool show)
        {
            if (show)
            {
                if (this.fRecipe == null)
                    this.fRecipe = new frmRecipeViewer(this);
                this.fRecipe.SetLocation();
                this.fRecipe.Show();
                this.FloatUpdate(false);
                this.fRecipe.Activate();
            }
            else
            {
                if (this.fRecipe == null)
                    return;
                this.fRecipe.Hide();
                this.fRecipe.Dispose();
                this.fRecipe = null;
            }
        }

        internal void FloatDPSCalc(bool Show)
        {
            if (Show)
            {
                if (this.fDPSCalc == null)
                    this.fDPSCalc = new frmDPSCalc(this);
                this.fDPSCalc.SetLocation();
                this.fDPSCalc.Show();
                this.FloatUpdate(false);
                this.fDPSCalc.Activate();
            }
            else
            {
                if (this.fDPSCalc == null)
                    return;
                this.fDPSCalc.Hide();
                this.fDPSCalc = (frmDPSCalc)null;
            }
        }

        internal void FloatSetFinder(bool Show)
        {
            if (Show)
            {
                if (this.fSetFinder == null)
                    this.fSetFinder = new frmSetFind(this);
                this.fSetFinder.Show();
                this.fSetFinder.Activate();
            }
            else
            {
                if (this.fSetFinder == null)
                    return;
                this.fSetFinder.Hide();
                this.fSetFinder.Dispose();
                this.fSetFinder = (frmSetFind)null;
            }
        }

        internal void FloatSets(bool Show)
        {
            if (Show)
            {
                if (this.fSets == null)
                {
                    frmMain iParent = this;
                    this.fSets = new frmSetViewer(ref iParent);
                }
                this.fSets.SetLocation();
                this.fSets.Show();
                this.FloatUpdate(false);
                this.fSets.Activate();
            }
            else
            {
                if (this.fSets == null)
                    return;
                this.fSets.Hide();
                this.fSets.Dispose();
                this.fSets = (frmSetViewer)null;
            }
        }

        internal void FloatStatGraph(bool Show)
        {
            if (Show)
            {
                if (this.fGraphStats == null)
                {
                    frmMain iParent = this;
                    this.fGraphStats = new frmStats(ref iParent);
                }
                this.fGraphStats.SetLocation();
                this.fGraphStats.Show();
                this.fGraphStats.Activate();
            }
            else
            {
                if (this.fGraphStats == null)
                    return;
                this.fGraphStats.Hide();
                this.fGraphStats.Dispose();
                this.fGraphStats = (frmStats)null;
            }
        }

        void FloatTop(bool OnTop)
        {
            if (!OnTop)
            {
                if (this.fSets != null)
                {
                    this.top_fSets = this.fSets.TopMost;
                    if (this.fSets.TopMost)
                        this.fSets.TopMost = false;
                }
                if (this.fGraphStats != null)
                {
                    this.top_fGraphStats = this.fGraphStats.TopMost;
                    if (this.fGraphStats.TopMost)
                        this.fGraphStats.TopMost = false;
                }
                if (this.fGraphCompare != null)
                {
                    this.top_fGraphCompare = this.fGraphCompare.TopMost;
                    if (this.fGraphCompare.TopMost)
                        this.fGraphCompare.TopMost = false;
                }
                if (this.fTotals != null)
                {
                    this.top_fTotals = this.fTotals.TopMost;
                    if (this.fTotals.TopMost)
                        this.fTotals.TopMost = false;
                }
                if (this.fRecipe != null)
                {
                    this.top_fRecipe = this.fRecipe.TopMost;
                    if (this.fRecipe.TopMost)
                        this.fRecipe.TopMost = false;
                }
                if (this.fData != null)
                {
                    this.top_fData = this.fData.TopMost;
                    if (this.fData.TopMost)
                        this.fData.TopMost = false;
                }
                if (this.fSetFinder == null)
                    return;
                this.top_fSetFinder = this.fSetFinder.TopMost;
                if (this.fSetFinder.TopMost)
                    this.fSetFinder.TopMost = false;
            }
            else
            {
                this.BringToFront();
                if (this.fSets != null && this.fSets.TopMost != this.top_fSets)
                {
                    this.fSets.TopMost = this.top_fSets;
                    if (this.fSets.TopMost)
                        this.fSets.BringToFront();
                }
                if (this.fGraphStats != null && this.fGraphStats.TopMost != this.top_fGraphStats)
                {
                    this.fGraphStats.TopMost = this.top_fGraphStats;
                    if (this.fGraphStats.TopMost)
                        this.fGraphStats.BringToFront();
                }
                if (this.fGraphCompare != null && this.fGraphCompare.TopMost != this.top_fGraphCompare)
                {
                    this.fGraphCompare.TopMost = this.top_fGraphCompare;
                    if (this.fGraphCompare.TopMost)
                        this.fGraphCompare.BringToFront();
                }
                if (this.fTotals != null && this.fTotals.TopMost != this.top_fTotals)
                {
                    this.fTotals.TopMost = this.top_fTotals;
                    if (this.fTotals.TopMost)
                        this.fTotals.BringToFront();
                }
                if (this.fRecipe != null && this.fRecipe.TopMost != this.top_fRecipe)
                {
                    this.fRecipe.TopMost = this.top_fRecipe;
                    if (this.fRecipe.TopMost)
                        this.fRecipe.BringToFront();
                }
                if (this.fData != null && this.fData.TopMost != this.top_fData)
                {
                    this.fData.TopMost = this.top_fData;
                    if (this.fData.TopMost)
                        this.fData.BringToFront();
                }
                if (this.fSetFinder != null && this.fSetFinder.TopMost != this.top_fSetFinder)
                {
                    this.fSetFinder.TopMost = this.top_fSetFinder;
                    if (this.fSetFinder.TopMost)
                        this.fSetFinder.BringToFront();
                }
            }
        }

        internal void FloatTotals(bool Show)
        {
            if (Show)
            {
                if (this.fTotals == null)
                {
                    frmMain iParent = this;
                    this.fTotals = new frmTotals(ref iParent);
                }
                this.DoRedraw();
                this.fTotals.SetLocation();
                this.fTotals.Show();
                this.fTotals.BringToFront();
                this.fTotals.UpdateData();
                this.fTotals.Activate();
            }
            else
            {
                if (this.fTotals == null)
                    return;
                this.fTotals.Hide();
                this.fTotals.Dispose();
                this.fTotals = (frmTotals)null;
            }
        }

        void FloatUpdate(bool NewData = false)
        {
            if (this.fSets != null)
                this.fSets.UpdateData();
            if (this.fGraphStats != null)
                this.fGraphStats.UpdateData(NewData);
            if (this.fTotals != null)
                this.fTotals.UpdateData();
            if (this.fGraphCompare != null)
                this.fGraphCompare.UpdateData();
            if (this.fRecipe != null)
                this.fRecipe.UpdateData();
            if (this.fDPSCalc != null)
                this.fDPSCalc.UpdateData();
            if (this.fData == null)
                return;
            this.fData.UpdateData(this.dvLastPower);
        }

        void frmMain_Closed(object sender, EventArgs e)
        {
            MidsContext.Config.LastSize = this.Size;
            MidsContext.Config.SaveConfig();
        }

        void frmMain_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.CloseCommand();
        }

        void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Alt & e.Control & e.Shift & e.KeyCode == System.Windows.Forms.Keys.A))
                return;
            this.tsAdvFreshInstall.Visible = true;
            MidsContext.Config.MasterMode = true;
            this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (MidsContext.Config.I9.DefaultIOLevel == 27)
                    MidsContext.Config.I9.DefaultIOLevel = 49;
                int height1 = 0;
                int width1 = 0;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
                frmLoading iFrm = new frmLoading();
                iFrm.Show();
                this.myDataView = this.dvAnchored;
                this.pnlGFX.BackColor = this.BackColor;
                this.NoUpdate = true;
                this.CheckForDownloadedUpdate();
                if (MidsContext.Config.CheckForUpdates)
                {
                    clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("https://www.dropbox.com/sh/amsfzb91s88dvzh/AAB6AkjTgHto4neEmkWwLWQEa?dl=0");
                    IMessager iLoadFrm = (IMessager)iFrm;
                    int num = (int)clsXmlUpdate.UpdateCheck(true, ref iLoadFrm);
                    iFrm = (frmLoading)iLoadFrm;
                }
                if (MidsContext.Config.FreshInstall)
                {
                    MidsContext.Config.CheckForUpdates = Interaction.MsgBox((object)("Welcome to Mids' Hero Designer " + Strings.Format((object)1.962f, "#0.00") + "! Please check the Readme/Help for quick instructions.\r\n\r\nMids' Hero Designer is able to check for and download updates automatically when it starts.\r\nIt's recommended that you turn on automatic updating. Do you want to?\r\n\r\n(If you don't, you can manually check from the 'Updates' tab in the options.)"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Welcome!") == MsgBoxResult.Yes;
                    MidsContext.Config.DefaultSaveFolder = "";
                    MidsContext.Config.CreateDefaultSaveFolder();
                    MidsContext.Config.FreshInstall = false;
                }
                string str1 = Interaction.Command();
                if (str1.IndexOf("RECOVERY", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    int num = (int)Interaction.MsgBox((object)"As recovery mode has been invoked, you will be redirected to the download site for the most recent full install package.", MsgBoxStyle.Information, (object)"Recovery Mode");
                    clsXMLUpdate.GoToCoHPlanner();
                    ProjectData.EndApp();
                }
                if (str1.IndexOf("MASTERMODE=YES", StringComparison.OrdinalIgnoreCase) > -1)
                    MidsContext.Config.MasterMode = true;
                MainModule.MidsController.LoadData(ref iFrm);
                this.dvAnchored.VisibleSize = MidsContext.Config.DvState;
                this.SetTitleBar(true);
                this.NewToon(true, false);
                this.dvAnchored.Init();
                this.cbAT.SelectedItem = (object)MidsContext.Character.Archetype;
                this.lblATLocked.Location = this.cbAT.Location;
                this.lblATLocked.Size = this.cbAT.Size;
                this.lblATLocked.Visible = false;
                this.lblLocked0.Location = this.cbPool0.Location;
                this.lblLocked0.Size = this.cbPool0.Size;
                this.lblLocked0.Visible = false;
                this.lblLocked1.Location = this.cbPool1.Location;
                this.lblLocked1.Size = this.cbPool1.Size;
                this.lblLocked1.Visible = false;
                this.lblLocked2.Location = this.cbPool2.Location;
                this.lblLocked2.Size = this.cbPool2.Size;
                this.lblLocked2.Visible = false;
                this.lblLocked3.Location = this.cbPool3.Location;
                this.lblLocked3.Size = this.cbPool3.Size;
                this.lblLocked3.Visible = false;
                this.lblLockedAncillary.Location = this.cbAncillary.Location;
                this.lblLockedAncillary.Size = this.cbAncillary.Size;
                this.lblLockedAncillary.Visible = false;
                if (this.pnlGFXFlow.Top + this.drawing.GetRequiredDrawingArea().Height < this.dvAnchored.Top + this.dvAnchored.Height + 48)
                {
                    int num1 = this.dvAnchored.Top + this.dvAnchored.Height + 48;
                }
                Size size1;
                if (Screen.PrimaryScreen.WorkingArea.Width > MidsContext.Config.LastSize.Width & MidsContext.Config.LastSize.Width >= this.MinimumSize.Width)
                {
                    int num2 = this.MaximumSize.Width > 0 ? 1 : 0;
                    size1 = this.MaximumSize;
                    int num3 = size1.Width - MidsContext.Config.LastSize.Width < 32 ? 1 : 0;
                    int num4 = num2 & num3;
                    int width2 = Screen.PrimaryScreen.WorkingArea.Width;
                    size1 = this.MaximumSize;
                    int width3 = size1.Width;
                    int num5 = width2 > width3 ? 1 : 0;
                    if ((num4 & num5) != 0)
                    {
                        size1 = this.MaximumSize;
                        width1 = size1.Width;
                    }
                    else
                        width1 = MidsContext.Config.LastSize.Width;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width <= MidsContext.Config.LastSize.Width)
                {
                    int width2 = Screen.PrimaryScreen.WorkingArea.Width;
                    size1 = this.Size;
                    int width3 = size1.Width;
                    size1 = this.ClientSize;
                    int width4 = size1.Width;
                    int num2 = width3 - width4;
                    width1 = width2 - num2;
                }
                Size size2 = this.MinimumSize;
                if (Screen.PrimaryScreen.WorkingArea.Height > MidsContext.Config.LastSize.Height & MidsContext.Config.LastSize.Height >= size2.Height)
                    height1 = MidsContext.Config.LastSize.Height;
                else if (Screen.PrimaryScreen.WorkingArea.Height <= MidsContext.Config.LastSize.Height)
                {
                    size2 = this.Size;
                    int height2 = Screen.PrimaryScreen.WorkingArea.Height;
                    int height3 = size2.Height;
                    size1 = this.ClientSize;
                    int height4 = size1.Height;
                    int num2 = height3 - height4;
                    height1 = height2 - num2;
                }
                size2 = new Size(width1, height1);
                this.Size = size2;
                this.tsView2Col.Checked = MidsContext.Config.Columns == 2;
                this.tsView3Col.Checked = MidsContext.Config.Columns == 3;
                this.tsView4Col.Checked = MidsContext.Config.Columns == 4;
                this.tsViewIOLevels.Checked = MidsContext.Config.I9.DisplayIOLevels;
                this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
                this.tsIODefault.Text = "Default (" + Conversions.ToString(MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
                this.SetDamageMenuCheckMarks();
                this.ReArrange(true);
                this.GetBestDamageValues();
                this.dvAnchored.SetFontData();
                this.dlgSave.InitialDirectory = MidsContext.Config.DefaultSaveFolder;
                this.dlgOpen.InitialDirectory = MidsContext.Config.DefaultSaveFolder;
                this.NoUpdate = false;
                this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
                this.ibSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
                this.tsViewRelative.Checked = MidsContext.Config.ShowEnhRel;
                this.ibPopup.Checked = MidsContext.Config.ShowPopup;
                this.ibRecipe.Checked = MidsContext.Config.PopupRecipes;
                string str2 = Files.FPathAppData + "patch.rtf";
                if (File.Exists(str2))
                {
                    int num2 = (int)new frmReadme(str2)
                    {
                        btnClose = {
              IA = this.drawing.pImageAttributes,
              ImageOff = this.drawing.bxPower[2].Bitmap,
              ImageOn = this.drawing.bxPower[3].Bitmap
            }
                    }.ShowDialog();
                    if (File.Exists(Files.FPathAppData + "patchnotes.rtf"))
                        File.Delete(Files.FPathAppData + "patchnotes.rtf");
                    File.Move(Files.FPathAppData + "patch.rtf", Files.FPathAppData + "patchnotes.rtf");
                }
                if (str1 != "")
                {
                    string str3 = str1.Replace("\"", "");
                    if (File.Exists(str3.Trim()) && !this.DoOpen(str3.Trim()))
                        this.PowerModified();
                }
                else if (MidsContext.Config.LoadLastFileOnStart && !this.DoOpen(MidsContext.Config.LastFileName))
                    this.PowerModified();
                if (MidsContext.Config.MasterMode)
                {
                    this.tsAdvFreshInstall.Visible = true;
                    this.tsAdvResetTips.Visible = true;
                }
                this.Show();
                iFrm.Hide();
                iFrm.Close();
                iFrm = (frmLoading)null;
                this.Refresh();
                this.dvAnchored.SetScreenBounds(this.ClientRectangle);
                Point iLocation = new Point();
                ref Point local = ref iLocation;
                int left = this.llPrimary.Left;
                int top = this.llPrimary.Top;
                size1 = this.llPrimary.SizeNormal;
                int height5 = size1.Height;
                int y = top + height5 + 5;
                local = new Point(left, y);
                this.dvAnchored.SetLocation(iLocation, true);
                this.PriSec_ExpandChanged(true);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num = (int)MessageBox.Show("An error has occurred when loading the main form. Error: " + ex.Message, "OMIGODHAX");
                throw;
            }
        }

        void frmMain_Maximize(object sender, EventArgs e)
        {
            if (this.WindowState != this.LastState)
                this.frmMain_Resize(RuntimeHelpers.GetObjectValue(sender), e);
            this.LastState = this.WindowState;
        }

        void frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            this.dvAnchored.info_txtLarge.Focus();
        }

        void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.dvAnchored != null)
            {
                this.dvAnchored.SetScreenBounds(this.ClientRectangle);
                if (this.WindowState == FormWindowState.Minimized)
                {
                    if (this.dvAnchored.Visible || this.FloatingDataForm == null)
                        return;
                    this.FloatingDataForm.Visible = false;
                    return;
                }
                if (!this.dvAnchored.Visible && this.FloatingDataForm != null)
                    this.FloatingDataForm.Visible = true;
            }
            if (!this.NoResizeEvent & MainModule.MidsController.IsAppInitialized & this.Visible)
                MidsContext.Config.LastSize = this.Size;
            this.UpdateControls(false);
        }

        internal void DoCalcOptUpdates()
        {
            this.GetBestDamageValues();
            this.RefreshInfo();
            this.DisplayName();
            this.I9Picker.LastLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
            if (this.myDataView != null)
                this.myDataView.SetFontData();
            if (this.dvLastPower > -1)
                this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
            if (this.drawing != null)
                this.DoRedraw();
            this.UpdateColours(false);
        }

        void GetBestDamageValues()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            float num1 = 0.0f;
            int num2 = MidsContext.Character.Powersets[0].Powers.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                IPower power = MidsContext.Character.Powersets[0].Powers[index];
                if (!power.SkipMax)
                {
                    float damageValue = power.FXGetDamageValue();
                    if ((double)damageValue > (double)num1)
                        num1 = damageValue;
                }
            }
            int num3 = MidsContext.Character.Powersets[1].Powers.Length - 1;
            for (int index = 0; index <= num3; ++index)
            {
                IPower power = MidsContext.Character.Powersets[1].Powers[index];
                if (!power.SkipMax)
                {
                    float damageValue = power.FXGetDamageValue();
                    if ((double)damageValue > (double)num1)
                        num1 = damageValue;
                }
            }
            float num4 = num1;
            MainModule.MidsController.Toon.GenerateBuffedPowerArray();
            float num5 = num1 * (1f + MidsContext.Character.TotalsCapped.BuffDam + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
            if (MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPS | MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPA)
                num5 *= 1.5f;
            this.myDataView.info_Damage.nHighBase = num4;
            this.myDataView.info_Damage.nHighEnh = num5;
        }

        int GetFirstValidSetEnh(int SlotIndex, int hID)
        {
            if (this.LastEnhPlaced != null && this.LastEnhPlaced.Enh >= 0 && DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID == Enums.eType.SetO)
            {
                int nIdSet = DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].nIDSet;
                if (nIdSet < 0)
                    return -1;
                if (MidsContext.Character.CurrentBuild.EnhancementTest(SlotIndex, hID, this.LastEnhPlaced.Enh, true))
                    return this.LastEnhPlaced.Enh;
                int num = DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.EnhancementTest(SlotIndex, hID, DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index], true))
                        return DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index];
                }
            }
            return -1;
        }

        bool GetPlayableClasses(Archetype a)
        {
            return a.Playable;
        }

        I9Slot GetRepeatEnhancement(int powerIndex, int iSlotIndex)
        {
            if (this.LastEnhPlaced != null)
            {
                if (MidsContext.Character.CurrentBuild.Powers[powerIndex].NIDPower < 0)
                    return new I9Slot();
                if (this.LastEnhPlaced.Enh <= -1)
                    return new I9Slot();
                if (DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID != Enums.eType.SetO)
                {
                    if (DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[powerIndex].NIDPower].IsEnhancementValid(this.LastEnhPlaced.Enh))
                        return this.LastEnhPlaced;
                    return new I9Slot();
                }
                int firstValidSetEnh = this.GetFirstValidSetEnh(iSlotIndex, powerIndex);
                if (firstValidSetEnh > -1)
                {
                    this.LastEnhPlaced.Enh = firstValidSetEnh;
                    this.LastEnhPlaced.IOLevel = DatabaseAPI.Database.Enhancements[firstValidSetEnh].CheckAndFixIOLevel(this.LastEnhPlaced.IOLevel);
                    return this.LastEnhPlaced;
                }
            }
            return new I9Slot();
        }

        void heroVillain_ButtonClicked()
        {
            MidsContext.Character.Alignment = !this.heroVillain.Checked ? Enums.Alignment.Hero : Enums.Alignment.Villain;
            if (this.fAccolade != null)
            {
                if (!this.fAccolade.IsDisposed)
                    this.fAccolade.Dispose();
                IPower power = MidsContext.Character.IsHero() ? DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3258)] : DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3257)];
                int num = power.NIDSubPower.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.PowerUsed(DatabaseAPI.Database.Power[power.NIDSubPower[index]]))
                        MidsContext.Character.CurrentBuild.RemovePower(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
                }
            }
            this.drawing.ColourSwitch();
            this.SetTitleBar(true);
            this.UpdateColours(false);
            this.DoRedraw();
        }

        void HidePopup()
        {
            if (!this.PopUpVisible)
                return;
            this.PopUpVisible = false;
            Rectangle bounds = this.I9Popup.Bounds;
            bounds.X -= this.pnlGFXFlow.Left;
            bounds.Y -= this.pnlGFXFlow.Top;
            this.I9Popup.Visible = false;
            this.I9Popup.eIDX = -1;
            this.I9Popup.pIDX = -1;
            this.I9Popup.hIDX = -1;
            this.I9Popup.psIDX = -1;
            this.ActivePopupBounds = new Rectangle(0, 0, 1, 1);
            this.drawing.Refresh(bounds);
        }

        void I9Picker_EnhancementPicked(I9Slot e)
        {
            e.RelativeLevel = this.I9Picker.UI.View.RelLevel;
            if (this.EnhancingSlot <= -1)
                return;
            bool flag1 = false;
            if (MidsContext.Character.CurrentBuild.EnhancementTest(this.EnhancingSlot, this.EnhancingPower, e.Enh, false) | e.Enh < 0)
            {
                if (e.Enh != MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].Slots[this.EnhancingSlot].Enhancement.Enh)
                    flag1 = true;
                bool flag2 = MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].HasProc();
                MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].Slots[this.EnhancingSlot].Enhancement = (I9Slot)e.Clone();
                if (e.Enh > -1)
                    this.LastEnhPlaced = (I9Slot)e.Clone();
                if (flag1)
                {
                    if (e.Enh > -1)
                    {
                        if (!flag2 & (MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].HasProc() & ((double)DatabaseAPI.Database.Enhancements[e.Enh].Probability == 0.0 | (double)DatabaseAPI.Database.Enhancements[e.Enh].Probability == 1.0)))
                            MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = true;
                        else if (!MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].CanIncludeForStats())
                            MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = false;
                    }
                    else if (!MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].CanIncludeForStats())
                        MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = false;
                }
                this.I9Picker.Visible = false;
                this.PowerModified();
                if (this.EnhancingPower > -1)
                    this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].NIDPower, e, -1);
            }
            this.I9Picker.Visible = false;
            this.EnhancingSlot = -1;
            this.EnhancingPower = -1;
        }

        void I9Picker_Hiding(object sender, EventArgs e)
        {
            if (!this.I9Picker.Visible)
                return;
            this.I9Picker.Visible = false;
            this.HidePopup();
            this.EnhancingSlot = -1;
            this.RefreshInfo();
        }

        void I9Picker_HoverEnhancement(int e)
        {
            I9Slot i9Slot = new I9Slot()
            {
                Enh = e,
                IOLevel = this.I9Picker.CheckAndReturnIOLevel() - 1,
                Grade = this.I9Picker.UI.View.GradeID,
                RelativeLevel = this.I9Picker.UI.View.RelLevel
            };
            this.myDataView.SetEnhancementPicker(i9Slot);
            this.ShowPopup(this.PickerHID, -1, -1, new Point(), this.I9Picker.Bounds, i9Slot, -1);
        }

        void I9Picker_HoverSet(int e)
        {
            this.myDataView.SetSetPicker(e);
            this.ShowPopup(this.PickerHID, -1, -1, new Point(), this.I9Picker.Bounds, (I9Slot)null, e);
        }

        void I9Picker_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || this.EnhancingSlot <= -1)
                return;
            this.I9Picker.Visible = false;
            this.EnhancingSlot = -1;
            this.RefreshInfo();
        }

        void I9Picker_Moved(Rectangle NewBounds, Rectangle OldBounds)
        {
            this.MovePopup(this.I9Picker.Bounds);
            this.RedrawUnderPopup(OldBounds);
        }

        void I9Popup_MouseMove(object sender, MouseEventArgs e)
        {
            this.HidePopup();
        }

        void ibMode_ButtonClicked()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            MidsContext.Config.BuildMode = MidsContext.Config.BuildMode != Enums.dmModes.Dynamic ? Enums.dmModes.Dynamic : Enums.dmModes.LevelUp;
            MidsContext.Character.ResetLevel();
            this.PowerModified();
            this.UpdateDMBuffer();
            this.pbDynMode.Refresh();
        }

        void ibPopup_ButtonClicked()
        {
            MidsContext.Config.ShowPopup = this.ibPopup.Checked;
        }

        void ibPvX_ButtonClicked()
        {
            MidsContext.Config.Inc.PvE = !this.ibPvX.Checked;
            this.RefreshInfo();
        }

        void ibRecipe_ButtonClicked()
        {
            MidsContext.Config.PopupRecipes = this.ibRecipe.Checked;
        }

        void ibSets_ButtonClicked()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            this.FloatSets(true);
        }

        void ibSlotLevels_ButtonClicked()
        {
            this.tsViewSlotLevels_Click((object)this, new EventArgs());
        }

        void ibTotals_ButtonClicked()
        {
            this.FloatTotals(true);
        }

        void incarnateButton_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = false;
            if (this.fIncarnate == null)
                flag = true;
            else if (this.fIncarnate.IsDisposed)
                flag = true;
            if (flag)
            {
                frmMain iParent = this;
                this.fIncarnate = new frmIncarnate(ref iParent);
            }
            if (this.fIncarnate.Visible)
                return;
            this.fIncarnate.Show((IWin32Window)this);
        }

        void IncarnateWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.incarnateButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
        }

        void Info_Enhancement(I9Slot iEnh, int iLevel = -1)
        {
            this.myDataView.SetEnhancement(iEnh, iLevel);
        }

        internal void UnlockFloatingStats()
        {
            this.DataViewLocked = false;
            if (this.dvLastPower <= -1)
                return;
            this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);

        }
        void Info_Power(int powerIdx, int iEnhLvl = -1, bool NoLevel = false, bool Lock = false)
        {
            if (!Lock & this.DataViewLocked)
            {
                if (this.dvLastPower != powerIdx)
                    return;
                Lock = true;
            }
            this.dvLastEnh = iEnhLvl;
            this.dvLastPower = powerIdx;
            this.dvLastNoLev = NoLevel;
            if (this.fData != null)
                this.fData.UpdateData(this.dvLastPower);
            int num1 = -1;
            if (MainModule.MidsController.Toon.Locked)
            {
                int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num2; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].NIDPower == powerIdx)
                    {
                        num1 = index;
                        break;
                    }
                }
            }
            this.DataViewLocked = Lock;
            if (num1 > -1)
                this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num1, -1), MainModule.MidsController.Toon.GetEnhancedPower(num1), NoLevel, this.DataViewLocked, num1);
            else
                this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num1, powerIdx), (IPower)null, NoLevel, this.DataViewLocked, num1);
            if (!Lock || this.dvAnchored.Visible)
                return;
            this.FloatingDataForm.Activate();
        }

        void info_Totals()
        {
            if (MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized)
                return;
            MainModule.MidsController.Toon.GenerateBuffedPowerArray();
            this.myDataView.DisplayTotals();
            this.FloatUpdate(false);
        }

        void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));
            this.txtName = new TextBox();
            this.cbAT = new ComboBox();
            this.cbOrigin = new ComboBox();
            this.cbPrimary = new ComboBox();
            this.lblPrimary = new Label();
            this.lblSecondary = new Label();
            this.cbSecondary = new ComboBox();
            this.cbPool0 = new ComboBox();
            this.lblPool1 = new Label();
            this.cbPool1 = new ComboBox();
            this.lblPool2 = new Label();
            this.cbPool2 = new ComboBox();
            this.lblPool3 = new Label();
            this.cbPool3 = new ComboBox();
            this.lblPool4 = new Label();
            this.cbAncillary = new ComboBox();
            this.lblEpic = new Label();
            this.lblATLocked = new Label();
            this.dlgOpen = new OpenFileDialog();
            this.dlgSave = new SaveFileDialog();
            this.tTip = new ToolTip(this.components);
            this.lblLocked0 = new Label();
            this.lblLocked1 = new Label();
            this.lblLocked2 = new Label();
            this.lblLocked3 = new Label();
            this.lblLockedAncillary = new Label();
            this.lblLockedSecondary = new Label();
            this.tmrGfx = new System.Windows.Forms.Timer(this.components);
            this.MenuBar = new MenuStrip();
            this.FileToolStripMenuItem = new ToolStripMenuItem();
            this.tsFileNew = new ToolStripMenuItem();
            this.ToolStripSeparator7 = new ToolStripSeparator();
            this.tsFileOpen = new ToolStripMenuItem();
            this.tsFileSave = new ToolStripMenuItem();
            this.tsFileSaveAs = new ToolStripMenuItem();
            this.ToolStripSeparator8 = new ToolStripSeparator();
            this.tsFilePrint = new ToolStripMenuItem();
            this.ToolStripSeparator9 = new ToolStripSeparator();
            this.tsFileQuit = new ToolStripMenuItem();
            this.ImportExportToolStripMenuItem = new ToolStripMenuItem();
            this.tsImport = new ToolStripMenuItem();
            this.ToolStripSeparator12 = new ToolStripSeparator();
            this.tsExport = new ToolStripMenuItem();
            this.tsExportLong = new ToolStripMenuItem();
            this.tsExportDataLink = new ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new ToolStripMenuItem();
            this.tsConfig = new ToolStripMenuItem();
            this.ToolStripSeparator14 = new ToolStripSeparator();
            this.tsUpdateCheck = new ToolStripMenuItem();
            this.ToolStripSeparator22 = new ToolStripSeparator();
            this.tsLevelUp = new ToolStripMenuItem();
            this.tsDynamic = new ToolStripMenuItem();
            this.ToolStripSeparator5 = new ToolStripSeparator();
            this.AdvancedToolStripMenuItem1 = new ToolStripMenuItem();
            this.tsAdvDBEdit = new ToolStripMenuItem();
            this.ToolStripSeparator15 = new ToolStripSeparator();
            this.tsAdvFreshInstall = new ToolStripMenuItem();
            this.tsAdvResetTips = new ToolStripMenuItem();
            this.CharacterToolStripMenuItem = new ToolStripMenuItem();
            this.SetAllIOsToDefault35ToolStripMenuItem = new ToolStripMenuItem();
            this.tsIODefault = new ToolStripMenuItem();
            this.ToolStripSeparator11 = new ToolStripSeparator();
            this.tsIOMin = new ToolStripMenuItem();
            this.tsIOMax = new ToolStripMenuItem();
            this.ToolStripSeparator16 = new ToolStripSeparator();
            this.ToolStripMenuItem1 = new ToolStripMenuItem();
            this.tsEnhToSO = new ToolStripMenuItem();
            this.tsEnhToDO = new ToolStripMenuItem();
            this.tsEnhToTO = new ToolStripMenuItem();
            this.ToolStripMenuItem2 = new ToolStripMenuItem();
            this.tsEnhToPlus5 = new ToolStripMenuItem();
            this.tsEnhToPlus4 = new ToolStripMenuItem();
            this.tsEnhToPlus3 = new ToolStripMenuItem();
            this.tsEnhToPlus2 = new ToolStripMenuItem();
            this.tsEnhToPlus1 = new ToolStripMenuItem();
            this.tsEnhToEven = new ToolStripMenuItem();
            this.tsEnhToMinus1 = new ToolStripMenuItem();
            this.tsEnhToMinus2 = new ToolStripMenuItem();
            this.tsEnhToMinus3 = new ToolStripMenuItem();
            this.tsEnhToNone = new ToolStripMenuItem();
            this.ToolStripSeparator17 = new ToolStripSeparator();
            this.SlotsToolStripMenuItem = new ToolStripMenuItem();
            this.tsFlipAllEnh = new ToolStripMenuItem();
            this.ToolStripSeparator4 = new ToolStripSeparator();
            this.tsClearAllEnh = new ToolStripMenuItem();
            this.tsRemoveAllSlots = new ToolStripMenuItem();
            this.ToolStripSeparator1 = new ToolStripSeparator();
            this.AutoArrangeAllSlotsToolStripMenuItem = new ToolStripMenuItem();
            this.ViewToolStripMenuItem = new ToolStripMenuItem();
            this.tsView4Col = new ToolStripMenuItem();
            this.tsView3Col = new ToolStripMenuItem();
            this.tsView2Col = new ToolStripMenuItem();
            this.ToolStripSeparator13 = new ToolStripSeparator();
            this.tsViewIOLevels = new ToolStripMenuItem();
            this.tsViewRelative = new ToolStripMenuItem();
            this.tsViewSlotLevels = new ToolStripMenuItem();
            this.ToolStripSeparator2 = new ToolStripSeparator();
            this.tsViewActualDamage_New = new ToolStripMenuItem();
            this.tsViewDPS_New = new ToolStripMenuItem();
            this.tlsDPA = new ToolStripMenuItem();
            this.tsAbout = new ToolStripMenuItem();
            this.HelpToolStripMenuItem1 = new ToolStripMenuItem();
            this.tsHelp = new ToolStripMenuItem();
            this.tsPatchNotes = new ToolStripMenuItem();
            this.ToolStripSeparator10 = new ToolStripSeparator();
            this.tsBug = new ToolStripMenuItem();
            this.tsTitanForum = new ToolStripMenuItem();
            this.ToolStripSeparator23 = new ToolStripSeparator();
            this.tsDonate = new ToolStripMenuItem();
            this.ToolStripSeparator24 = new ToolStripSeparator();
            this.tsTitanPlanner = new ToolStripMenuItem();
            this.tsTitanSite = new ToolStripMenuItem();
            this.WindowToolStripMenuItem = new ToolStripMenuItem();
            this.tsViewSets = new ToolStripMenuItem();
            this.tsViewGraphs = new ToolStripMenuItem();
            this.tsViewSetCompare = new ToolStripMenuItem();
            this.tsViewData = new ToolStripMenuItem();
            this.tsViewTotals = new ToolStripMenuItem();
            this.ToolStripSeparator18 = new ToolStripSeparator();
            this.tsRecipeViewer = new ToolStripMenuItem();
            this.tsDPSCalc = new ToolStripMenuItem();
            this.ToolStripSeparator19 = new ToolStripSeparator();
            this.tsSetFind = new ToolStripMenuItem();
            this.ToolStripSeparator21 = new ToolStripSeparator();
            this.InGameRespecHelperToolStripMenuItem = new ToolStripMenuItem();
            this.tsHelperShort = new ToolStripMenuItem();
            this.tsHelperLong = new ToolStripMenuItem();
            this.ToolStripSeparator20 = new ToolStripSeparator();
            this.tsHelperShort2 = new ToolStripMenuItem();
            this.tsHelperLong2 = new ToolStripMenuItem();
            this.ToolStripMenuItem4 = new ToolStripSeparator();
            this.AccoladesWindowToolStripMenuItem = new ToolStripMenuItem();
            this.IncarnateWindowToolStripMenuItem = new ToolStripMenuItem();
            this.TemporaryPowersWindowToolStripMenuItem = new ToolStripMenuItem();
            this.pbDynMode = new PictureBox();
            this.pnlGFX = new PictureBox();
            this.pnlGFXFlow = new FlowLayoutPanel();
            this.llAncillary = new ListLabelV2();
            this.lblName = new GFXLabel();
            this.lblOrigin = new GFXLabel();
            this.lblAT = new GFXLabel();
            this.llPool0 = new ListLabelV2();
            this.llPool1 = new ListLabelV2();
            this.llSecondary = new ListLabelV2();
            this.llPrimary = new ListLabelV2();
            this.llPool3 = new ListLabelV2();
            this.llPool2 = new ListLabelV2();
            this.lblHero = new GFXLabel();
            this.heroVillain = new ImageButton();
            this.tempPowersButton = new ImageButton();
            this.accoladeButton = new ImageButton();
            this.incarnateButton = new ImageButton();
            this.I9Picker = new I9Picker();
            this.I9Popup = new ctlPopUp();
            this.ibVetPools = new ImageButton();
            this.ibPvX = new ImageButton();
            this.dvAnchored = new DataView();
            this.ibTotals = new ImageButton();
            this.ibSlotLevels = new ImageButton();
            this.ibMode = new ImageButton();
            this.ibSets = new ImageButton();
            this.ibAccolade = new ImageButton();
            this.ibRecipe = new ImageButton();
            this.ibPopup = new ImageButton();
            this.MenuBar.SuspendLayout();
            ((ISupportInitialize)this.pbDynMode).BeginInit();
            ((ISupportInitialize)this.pnlGFX).BeginInit();
            this.pnlGFXFlow.SuspendLayout();
            this.SuspendLayout();
            this.txtName.BackColor = Color.WhiteSmoke;
            this.txtName.ForeColor = SystemColors.ControlText;
            Point point = new Point(96, 82);
            this.txtName.Location = point;
            this.txtName.Name = "txtName";
            Size size = new Size(142, 20);
            this.txtName.Size = size;
            this.txtName.TabIndex = 1;
            this.cbAT.BackColor = Color.WhiteSmoke;
            this.cbAT.DisplayMember = "DisplayName";
            this.cbAT.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbAT.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbAT.ForeColor = SystemColors.ControlText;
            this.cbAT.ItemHeight = 16;
            point = new Point(94, 109);
            this.cbAT.Location = point;
            this.cbAT.MaxDropDownItems = 15;
            this.cbAT.Name = "cbAT";
            size = new Size(144, 22);
            this.cbAT.Size = size;
            this.cbAT.TabIndex = 3;
            this.cbAT.ValueMember = "Idx";
            this.cbOrigin.BackColor = Color.WhiteSmoke;
            this.cbOrigin.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbOrigin.ForeColor = SystemColors.ControlText;
            this.cbOrigin.ItemHeight = 16;
            point = new Point(94, 133);
            this.cbOrigin.Location = point;
            this.cbOrigin.Name = "cbOrigin";
            size = new Size(144, 22);
            this.cbOrigin.Size = size;
            this.cbOrigin.TabIndex = 5;
            this.cbPrimary.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPrimary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPrimary.ForeColor = SystemColors.ControlText;
            this.cbPrimary.ItemHeight = 16;
            point = new Point(16, 182);
            this.cbPrimary.Location = point;
            this.cbPrimary.MaxDropDownItems = 15;
            this.cbPrimary.Name = "cbPrimary";
            size = new Size(144, 22);
            this.cbPrimary.Size = size;
            this.cbPrimary.TabIndex = 7;
            this.lblPrimary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPrimary.ForeColor = Color.White;
            point = new Point(20, 166);
            this.lblPrimary.Location = point;
            this.lblPrimary.Name = "lblPrimary";
            size = new Size(136, 17);
            this.lblPrimary.Size = size;
            this.lblPrimary.TabIndex = 9;
            this.lblPrimary.Text = "Primary Power Set";
            this.lblPrimary.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSecondary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblSecondary.ForeColor = Color.White;
            point = new Point(172, 166);
            this.lblSecondary.Location = point;
            this.lblSecondary.Name = "lblSecondary";
            size = new Size(136, 17);
            this.lblSecondary.Size = size;
            this.lblSecondary.TabIndex = 10;
            this.lblSecondary.Text = "Secondary Power Set";
            this.lblSecondary.TextAlign = ContentAlignment.MiddleCenter;
            this.cbSecondary.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbSecondary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSecondary.ForeColor = SystemColors.ControlText;
            this.cbSecondary.ItemHeight = 16;
            point = new Point(168, 182);
            this.cbSecondary.Location = point;
            this.cbSecondary.MaxDropDownItems = 15;
            this.cbSecondary.Name = "cbSecondary";
            size = new Size(144, 22);
            this.cbSecondary.Size = size;
            this.cbSecondary.TabIndex = 11;
            this.cbPool0.BackColor = Color.WhiteSmoke;
            this.cbPool0.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool0.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool0.ForeColor = SystemColors.ControlText;
            this.cbPool0.ItemHeight = 16;
            point = new Point(328, 182);
            this.cbPool0.Location = point;
            this.cbPool0.MaxDropDownItems = 15;
            this.cbPool0.Name = "cbPool0";
            size = new Size(136, 22);
            this.cbPool0.Size = size;
            this.cbPool0.TabIndex = 15;
            this.lblPool1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool1.ForeColor = Color.White;
            point = new Point(328, 166);
            this.lblPool1.Location = point;
            this.lblPool1.Name = "lblPool1";
            size = new Size(136, 17);
            this.lblPool1.Size = size;
            this.lblPool1.TabIndex = 14;
            this.lblPool1.Text = "Pool 1";
            this.lblPool1.TextAlign = ContentAlignment.MiddleCenter;
            this.cbPool1.BackColor = Color.WhiteSmoke;
            this.cbPool1.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool1.ForeColor = SystemColors.ControlText;
            this.cbPool1.ItemHeight = 16;
            point = new Point(328, 290);
            this.cbPool1.Location = point;
            this.cbPool1.MaxDropDownItems = 15;
            this.cbPool1.Name = "cbPool1";
            size = new Size(136, 22);
            this.cbPool1.Size = size;
            this.cbPool1.TabIndex = 18;
            this.lblPool2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool2.ForeColor = Color.White;
            point = new Point(328, 274);
            this.lblPool2.Location = point;
            this.lblPool2.Name = "lblPool2";
            size = new Size(136, 17);
            this.lblPool2.Size = size;
            this.lblPool2.TabIndex = 17;
            this.lblPool2.Text = "Pool 2";
            this.lblPool2.TextAlign = ContentAlignment.MiddleCenter;
            this.cbPool2.BackColor = Color.WhiteSmoke;
            this.cbPool2.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool2.ForeColor = SystemColors.ControlText;
            this.cbPool2.ItemHeight = 16;
            point = new Point(328, 398);
            this.cbPool2.Location = point;
            this.cbPool2.MaxDropDownItems = 15;
            this.cbPool2.Name = "cbPool2";
            size = new Size(136, 22);
            this.cbPool2.Size = size;
            this.cbPool2.TabIndex = 21;
            this.lblPool3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool3.ForeColor = Color.White;
            point = new Point(328, 382);
            this.lblPool3.Location = point;
            this.lblPool3.Name = "lblPool3";
            size = new Size(136, 17);
            this.lblPool3.Size = size;
            this.lblPool3.TabIndex = 20;
            this.lblPool3.Text = "Pool 3";
            this.lblPool3.TextAlign = ContentAlignment.MiddleCenter;
            this.cbPool3.BackColor = Color.WhiteSmoke;
            this.cbPool3.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool3.ForeColor = SystemColors.ControlText;
            this.cbPool3.ItemHeight = 16;
            point = new Point(328, 506);
            this.cbPool3.Location = point;
            this.cbPool3.MaxDropDownItems = 15;
            this.cbPool3.Name = "cbPool3";
            size = new Size(136, 22);
            this.cbPool3.Size = size;
            this.cbPool3.TabIndex = 24;
            this.lblPool4.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool4.ForeColor = Color.White;
            point = new Point(328, 490);
            this.lblPool4.Location = point;
            this.lblPool4.Name = "lblPool4";
            size = new Size(136, 17);
            this.lblPool4.Size = size;
            this.lblPool4.TabIndex = 23;
            this.lblPool4.Text = "Pool 4";
            this.lblPool4.TextAlign = ContentAlignment.MiddleCenter;
            this.cbAncillary.BackColor = Color.WhiteSmoke;
            this.cbAncillary.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbAncillary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbAncillary.ForeColor = SystemColors.ControlText;
            this.cbAncillary.ItemHeight = 16;
            point = new Point(328, 614);
            this.cbAncillary.Location = point;
            this.cbAncillary.Name = "cbAncillary";
            size = new Size(136, 22);
            this.cbAncillary.Size = size;
            this.cbAncillary.TabIndex = 27;
            this.lblEpic.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblEpic.ForeColor = Color.White;
            point = new Point(328, 598);
            this.lblEpic.Location = point;
            this.lblEpic.Name = "lblEpic";
            size = new Size(136, 17);
            this.lblEpic.Size = size;
            this.lblEpic.TabIndex = 26;
            this.lblEpic.Text = "Ancillary/Epic Pool";
            this.lblEpic.TextAlign = ContentAlignment.MiddleCenter;
            this.lblATLocked.BackColor = Color.FromArgb(224, 224, 224);
            this.lblATLocked.BorderStyle = BorderStyle.Fixed3D;
            this.lblATLocked.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblATLocked.ForeColor = Color.Black;
            point = new Point(94, 113);
            this.lblATLocked.Location = point;
            this.lblATLocked.Name = "lblATLocked";
            size = new Size(92, 29);
            this.lblATLocked.Size = size;
            this.lblATLocked.TabIndex = 53;
            this.lblATLocked.Text = "Archetype Locked";
            this.lblATLocked.TextAlign = ContentAlignment.MiddleCenter;
            this.dlgOpen.DefaultExt = "mxd";
            this.dlgOpen.Filter = "Hero/Villain Builds (*.mxd)|*.mxd;*.txt|Text Files (*.txt)|*.txt";
            this.dlgSave.DefaultExt = "mxd";
            this.dlgSave.Filter = "Hero/Villain Builds (*.mxd)|*.mxd";
            this.tTip.AutoPopDelay = 5000;
            this.tTip.InitialDelay = 500;
            this.tTip.ReshowDelay = 100;
            this.lblLocked0.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked0.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked0.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked0.ForeColor = Color.Black;
            point = new Point(308, 166);
            this.lblLocked0.Location = point;
            this.lblLocked0.Name = "lblLocked0";
            size = new Size(92, 29);
            this.lblLocked0.Size = size;
            this.lblLocked0.TabIndex = 72;
            this.lblLocked0.Text = "Pool Locked";
            this.lblLocked0.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLocked1.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked1.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked1.ForeColor = Color.Black;
            point = new Point(308, 186);
            this.lblLocked1.Location = point;
            this.lblLocked1.Name = "lblLocked1";
            size = new Size(92, 29);
            this.lblLocked1.Size = size;
            this.lblLocked1.TabIndex = 73;
            this.lblLocked1.Text = "Pool Locked";
            this.lblLocked1.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLocked2.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked2.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked2.ForeColor = Color.Black;
            point = new Point(304, 194);
            this.lblLocked2.Location = point;
            this.lblLocked2.Name = "lblLocked2";
            size = new Size(92, 29);
            this.lblLocked2.Size = size;
            this.lblLocked2.TabIndex = 74;
            this.lblLocked2.Text = "Pool Locked";
            this.lblLocked2.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLocked3.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked3.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked3.ForeColor = Color.Black;
            point = new Point(284, 210);
            this.lblLocked3.Location = point;
            this.lblLocked3.Name = "lblLocked3";
            size = new Size(92, 29);
            this.lblLocked3.Size = size;
            this.lblLocked3.TabIndex = 75;
            this.lblLocked3.Text = "Pool Locked";
            this.lblLocked3.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLockedAncillary.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLockedAncillary.BorderStyle = BorderStyle.Fixed3D;
            this.lblLockedAncillary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLockedAncillary.ForeColor = Color.Black;
            point = new Point(268, 230);
            this.lblLockedAncillary.Location = point;
            this.lblLockedAncillary.Name = "lblLockedAncillary";
            size = new Size(92, 29);
            this.lblLockedAncillary.Size = size;
            this.lblLockedAncillary.TabIndex = 76;
            this.lblLockedAncillary.Text = "Pool Locked";
            this.lblLockedAncillary.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLockedSecondary.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLockedSecondary.BorderStyle = BorderStyle.Fixed3D;
            this.lblLockedSecondary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLockedSecondary.ForeColor = Color.Black;
            point = new Point(257, 246);
            this.lblLockedSecondary.Location = point;
            this.lblLockedSecondary.Name = "lblLockedSecondary";
            size = new Size(92, 29);
            this.lblLockedSecondary.Size = size;
            this.lblLockedSecondary.TabIndex = 109;
            this.lblLockedSecondary.Text = "Sec. Locked";
            this.lblLockedSecondary.TextAlign = ContentAlignment.MiddleCenter;
            this.MenuBar.BackColor = SystemColors.Control;
            this.MenuBar.Items.AddRange(new ToolStripItem[8]
            {
        (ToolStripItem) this.FileToolStripMenuItem,
        (ToolStripItem) this.ImportExportToolStripMenuItem,
        (ToolStripItem) this.OptionsToolStripMenuItem,
        (ToolStripItem) this.CharacterToolStripMenuItem,
        (ToolStripItem) this.ViewToolStripMenuItem,
        (ToolStripItem) this.tsAbout,
        (ToolStripItem) this.HelpToolStripMenuItem1,
        (ToolStripItem) this.WindowToolStripMenuItem
            });
            point = new Point(0, 0);
            this.MenuBar.Location = point;
            this.MenuBar.Name = "MenuBar";
            size = new Size(1056, 24);
            this.MenuBar.Size = size;
            this.MenuBar.TabIndex = 84;
            this.MenuBar.Text = "MenuStrip1";
            this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[9]
            {
        (ToolStripItem) this.tsFileNew,
        (ToolStripItem) this.ToolStripSeparator7,
        (ToolStripItem) this.tsFileOpen,
        (ToolStripItem) this.tsFileSave,
        (ToolStripItem) this.tsFileSaveAs,
        (ToolStripItem) this.ToolStripSeparator8,
        (ToolStripItem) this.tsFilePrint,
        (ToolStripItem) this.ToolStripSeparator9,
        (ToolStripItem) this.tsFileQuit
            });
            this.FileToolStripMenuItem.ForeColor = SystemColors.ControlText;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            size = new Size(37, 20);
            this.FileToolStripMenuItem.Size = size;
            this.FileToolStripMenuItem.Text = "&File";
            this.tsFileNew.Name = "tsFileNew";
            this.tsFileNew.ShortcutKeys = System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control;
            size = new Size(179, 22);
            this.tsFileNew.Size = size;
            this.tsFileNew.Text = "&New / Clear";
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            size = new Size(176, 6);
            this.ToolStripSeparator7.Size = size;
            this.tsFileOpen.Name = "tsFileOpen";
            this.tsFileOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;
            size = new Size(179, 22);
            this.tsFileOpen.Size = size;
            this.tsFileOpen.Text = "&Open...";
            this.tsFileSave.Name = "tsFileSave";
            this.tsFileSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
            size = new Size(179, 22);
            this.tsFileSave.Size = size;
            this.tsFileSave.Text = "&Save";
            this.tsFileSaveAs.Name = "tsFileSaveAs";
            size = new Size(179, 22);
            this.tsFileSaveAs.Size = size;
            this.tsFileSaveAs.Text = "Save &As...";
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            size = new Size(176, 6);
            this.ToolStripSeparator8.Size = size;
            this.tsFilePrint.Name = "tsFilePrint";
            this.tsFilePrint.ShortcutKeys = System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control;
            size = new Size(179, 22);
            this.tsFilePrint.Size = size;
            this.tsFilePrint.Text = "&Print...";
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            size = new Size(176, 6);
            this.ToolStripSeparator9.Size = size;
            this.tsFileQuit.Name = "tsFileQuit";
            this.tsFileQuit.ShortcutKeys = System.Windows.Forms.Keys.Q | System.Windows.Forms.Keys.Control;
            size = new Size(179, 22);
            this.tsFileQuit.Size = size;
            this.tsFileQuit.Text = "&Quit";
            this.ImportExportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
            {
        (ToolStripItem) this.tsImport,
        (ToolStripItem) this.ToolStripSeparator12,
        (ToolStripItem) this.tsExport,
        (ToolStripItem) this.tsExportLong,
        (ToolStripItem) this.tsExportDataLink
            });
            this.ImportExportToolStripMenuItem.ForeColor = SystemColors.ControlText;
            this.ImportExportToolStripMenuItem.Name = "ImportExportToolStripMenuItem";
            size = new Size(99, 20);
            this.ImportExportToolStripMenuItem.Size = size;
            this.ImportExportToolStripMenuItem.Text = "&Import / Export";
            this.tsImport.Name = "tsImport";
            this.tsImport.ShortcutKeys = System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control;
            size = new Size(240, 22);
            this.tsImport.Size = size;
            this.tsImport.Text = "&Import from Forum Post";
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";
            size = new Size(237, 6);
            this.ToolStripSeparator12.Size = size;
            this.tsExport.Name = "tsExport";
            size = new Size(240, 22);
            this.tsExport.Size = size;
            this.tsExport.Text = "&Short Forum Export...";
            this.tsExportLong.Name = "tsExportLong";
            size = new Size(240, 22);
            this.tsExportLong.Size = size;
            this.tsExportLong.Text = "&Long Forum Export...";
            this.tsExportDataLink.Name = "tsExportDataLink";
            size = new Size(240, 22);
            this.tsExportDataLink.Size = size;
            this.tsExportDataLink.Text = "Export Data Link";
            this.OptionsToolStripMenuItem.BackColor = SystemColors.Control;
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8]
            {
        (ToolStripItem) this.tsConfig,
        (ToolStripItem) this.ToolStripSeparator14,
        (ToolStripItem) this.tsUpdateCheck,
        (ToolStripItem) this.ToolStripSeparator22,
        (ToolStripItem) this.tsLevelUp,
        (ToolStripItem) this.tsDynamic,
        (ToolStripItem) this.ToolStripSeparator5,
        (ToolStripItem) this.AdvancedToolStripMenuItem1
            });
            this.OptionsToolStripMenuItem.ForeColor = SystemColors.ControlText;
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            size = new Size(61, 20);
            this.OptionsToolStripMenuItem.Size = size;
            this.OptionsToolStripMenuItem.Text = "&Options";
            this.tsConfig.Name = "tsConfig";
            size = new Size(199, 22);
            this.tsConfig.Size = size;
            this.tsConfig.Text = "&Configuration...";
            this.ToolStripSeparator14.Name = "ToolStripSeparator14";
            size = new Size(196, 6);
            this.ToolStripSeparator14.Size = size;
            this.tsUpdateCheck.Name = "tsUpdateCheck";
            size = new Size(199, 22);
            this.tsUpdateCheck.Size = size;
            this.tsUpdateCheck.Text = "Check for &Updates Now";
            this.ToolStripSeparator22.Name = "ToolStripSeparator22";
            size = new Size(196, 6);
            this.ToolStripSeparator22.Size = size;
            this.tsLevelUp.Name = "tsLevelUp";
            size = new Size(199, 22);
            this.tsLevelUp.Size = size;
            this.tsLevelUp.Text = "&Level-Up Mode";
            this.tsLevelUp.ToolTipText = "Alternate between placing powers and slots, just like levelling up in-game.";
            this.tsDynamic.Name = "tsDynamic";
            size = new Size(199, 22);
            this.tsDynamic.Size = size;
            this.tsDynamic.Text = "&Dynamic Mode";
            this.tsDynamic.ToolTipText = "Place powers and slots in any order.";
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            size = new Size(196, 6);
            this.ToolStripSeparator5.Size = size;
            this.AdvancedToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[4]
            {
        (ToolStripItem) this.tsAdvDBEdit,
        (ToolStripItem) this.ToolStripSeparator15,
        (ToolStripItem) this.tsAdvFreshInstall,
        (ToolStripItem) this.tsAdvResetTips
            });
            this.AdvancedToolStripMenuItem1.Name = "AdvancedToolStripMenuItem1";
            size = new Size(199, 22);
            this.AdvancedToolStripMenuItem1.Size = size;
            this.AdvancedToolStripMenuItem1.Text = "&Advanced";
            this.tsAdvDBEdit.Name = "tsAdvDBEdit";
            size = new Size(165, 22);
            this.tsAdvDBEdit.Size = size;
            this.tsAdvDBEdit.Text = "&Database Editor...";
            this.ToolStripSeparator15.Name = "ToolStripSeparator15";
            size = new Size(162, 6);
            this.ToolStripSeparator15.Size = size;
            this.tsAdvFreshInstall.Name = "tsAdvFreshInstall";
            size = new Size(165, 22);
            this.tsAdvFreshInstall.Size = size;
            this.tsAdvFreshInstall.Text = "FreshInstall Flag";
            this.tsAdvFreshInstall.Visible = false;
            this.tsAdvResetTips.Name = "tsAdvResetTips";
            size = new Size(165, 22);
            this.tsAdvResetTips.Size = size;
            this.tsAdvResetTips.Text = "Reset Tips";
            this.CharacterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
            {
        (ToolStripItem) this.SetAllIOsToDefault35ToolStripMenuItem,
        (ToolStripItem) this.ToolStripSeparator16,
        (ToolStripItem) this.ToolStripMenuItem1,
        (ToolStripItem) this.ToolStripMenuItem2,
        (ToolStripItem) this.ToolStripSeparator17,
        (ToolStripItem) this.SlotsToolStripMenuItem
            });
            this.CharacterToolStripMenuItem.ForeColor = SystemColors.ControlText;
            this.CharacterToolStripMenuItem.Name = "CharacterToolStripMenuItem";
            size = new Size(133, 20);
            this.CharacterToolStripMenuItem.Size = size;
            this.CharacterToolStripMenuItem.Text = "&Slots / Enhancements";
            this.SetAllIOsToDefault35ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
            {
        (ToolStripItem) this.tsIODefault,
        (ToolStripItem) this.ToolStripSeparator11,
        (ToolStripItem) this.tsIOMin,
        (ToolStripItem) this.tsIOMax
            });
            this.SetAllIOsToDefault35ToolStripMenuItem.Name = "SetAllIOsToDefault35ToolStripMenuItem";
            size = new Size(245, 22);
            this.SetAllIOsToDefault35ToolStripMenuItem.Size = size;
            this.SetAllIOsToDefault35ToolStripMenuItem.Text = "&Set all IOs to...";
            this.tsIODefault.Name = "tsIODefault";
            size = new Size(135, 22);
            this.tsIODefault.Size = size;
            this.tsIODefault.Text = "Default (35)";
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            size = new Size(132, 6);
            this.ToolStripSeparator11.Size = size;
            this.tsIOMin.Name = "tsIOMin";
            size = new Size(135, 22);
            this.tsIOMin.Size = size;
            this.tsIOMin.Text = "Minimum";
            this.tsIOMax.Name = "tsIOMax";
            size = new Size(135, 22);
            this.tsIOMax.Size = size;
            this.tsIOMax.Text = "Maximum";
            this.ToolStripSeparator16.Name = "ToolStripSeparator16";
            size = new Size(242, 6);
            this.ToolStripSeparator16.Size = size;
            this.ToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[3]
            {
        (ToolStripItem) this.tsEnhToSO,
        (ToolStripItem) this.tsEnhToDO,
        (ToolStripItem) this.tsEnhToTO
            });
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            size = new Size(245, 22);
            this.ToolStripMenuItem1.Size = size;
            this.ToolStripMenuItem1.Text = "Set all Enhancement &Origins to...";
            this.tsEnhToSO.Name = "tsEnhToSO";
            size = new Size(142, 22);
            this.tsEnhToSO.Size = size;
            this.tsEnhToSO.Text = "Single Origin";
            this.tsEnhToDO.Name = "tsEnhToDO";
            size = new Size(142, 22);
            this.tsEnhToDO.Size = size;
            this.tsEnhToDO.Text = "Dual Origin";
            this.tsEnhToTO.Name = "tsEnhToTO";
            size = new Size(142, 22);
            this.tsEnhToTO.Size = size;
            this.tsEnhToTO.Text = "Training";
            this.ToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[10]
            {
        (ToolStripItem) this.tsEnhToPlus5,
        (ToolStripItem) this.tsEnhToPlus4,
        (ToolStripItem) this.tsEnhToPlus3,
        (ToolStripItem) this.tsEnhToPlus2,
        (ToolStripItem) this.tsEnhToPlus1,
        (ToolStripItem) this.tsEnhToEven,
        (ToolStripItem) this.tsEnhToMinus1,
        (ToolStripItem) this.tsEnhToMinus2,
        (ToolStripItem) this.tsEnhToMinus3,
        (ToolStripItem) this.tsEnhToNone
            });
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            size = new Size(245, 22);
            this.ToolStripMenuItem2.Size = size;
            this.ToolStripMenuItem2.Text = "Set all &Relative Levels to...";
            this.tsEnhToPlus5.Name = "tsEnhToPlus5";
            size = new Size(205, 22);
            this.tsEnhToPlus5.Size = size;
            this.tsEnhToPlus5.Text = "+5 Levels";
            this.tsEnhToPlus4.Name = "tsEnhToPlus4";
            size = new Size(205, 22);
            this.tsEnhToPlus4.Size = size;
            this.tsEnhToPlus4.Text = "+4 Levels";
            this.tsEnhToPlus3.Name = "tsEnhToPlus3";
            size = new Size(205, 22);
            this.tsEnhToPlus3.Size = size;
            this.tsEnhToPlus3.Text = "+3 Levels";
            this.tsEnhToPlus2.Name = "tsEnhToPlus2";
            size = new Size(205, 22);
            this.tsEnhToPlus2.Size = size;
            this.tsEnhToPlus2.Text = "+2 Levels";
            this.tsEnhToPlus1.Name = "tsEnhToPlus1";
            size = new Size(205, 22);
            this.tsEnhToPlus1.Size = size;
            this.tsEnhToPlus1.Text = "+1 Level";
            this.tsEnhToEven.Name = "tsEnhToEven";
            size = new Size(205, 22);
            this.tsEnhToEven.Size = size;
            this.tsEnhToEven.Text = "Even Level";
            this.tsEnhToMinus1.Name = "tsEnhToMinus1";
            size = new Size(205, 22);
            this.tsEnhToMinus1.Size = size;
            this.tsEnhToMinus1.Text = "-1 Level";
            this.tsEnhToMinus2.Name = "tsEnhToMinus2";
            size = new Size(205, 22);
            this.tsEnhToMinus2.Size = size;
            this.tsEnhToMinus2.Text = "-2 Levels";
            this.tsEnhToMinus3.Name = "tsEnhToMinus3";
            size = new Size(205, 22);
            this.tsEnhToMinus3.Size = size;
            this.tsEnhToMinus3.Text = "-3 Levels";
            this.tsEnhToNone.Name = "tsEnhToNone";
            size = new Size(205, 22);
            this.tsEnhToNone.Size = size;
            this.tsEnhToNone.Text = "None (Enh has no effect)";
            this.ToolStripSeparator17.Name = "ToolStripSeparator17";
            size = new Size(242, 6);
            this.ToolStripSeparator17.Size = size;
            this.SlotsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
            {
        (ToolStripItem) this.tsFlipAllEnh,
        (ToolStripItem) this.ToolStripSeparator4,
        (ToolStripItem) this.tsClearAllEnh,
        (ToolStripItem) this.tsRemoveAllSlots,
        (ToolStripItem) this.ToolStripSeparator1,
        (ToolStripItem) this.AutoArrangeAllSlotsToolStripMenuItem
            });
            this.SlotsToolStripMenuItem.Name = "SlotsToolStripMenuItem";
            size = new Size(245, 22);
            this.SlotsToolStripMenuItem.Size = size;
            this.SlotsToolStripMenuItem.Text = "Slo&ts";
            this.tsFlipAllEnh.Name = "tsFlipAllEnh";
            size = new Size(199, 22);
            this.tsFlipAllEnh.Size = size;
            this.tsFlipAllEnh.Text = "Flip All to Alternate";
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            size = new Size(196, 6);
            this.ToolStripSeparator4.Size = size;
            this.tsClearAllEnh.Name = "tsClearAllEnh";
            size = new Size(199, 22);
            this.tsClearAllEnh.Size = size;
            this.tsClearAllEnh.Text = "Clear All Enhancements";
            this.tsRemoveAllSlots.Name = "tsRemoveAllSlots";
            size = new Size(199, 22);
            this.tsRemoveAllSlots.Size = size;
            this.tsRemoveAllSlots.Text = "Remove All Slots";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            size = new Size(196, 6);
            this.ToolStripSeparator1.Size = size;
            this.AutoArrangeAllSlotsToolStripMenuItem.Name = "AutoArrangeAllSlotsToolStripMenuItem";
            size = new Size(199, 22);
            this.AutoArrangeAllSlotsToolStripMenuItem.Size = size;
            this.AutoArrangeAllSlotsToolStripMenuItem.Text = "&Auto-Arrange All Slots";
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[11]
            {
        (ToolStripItem) this.tsView4Col,
        (ToolStripItem) this.tsView3Col,
        (ToolStripItem) this.tsView2Col,
        (ToolStripItem) this.ToolStripSeparator13,
        (ToolStripItem) this.tsViewIOLevels,
        (ToolStripItem) this.tsViewRelative,
        (ToolStripItem) this.tsViewSlotLevels,
        (ToolStripItem) this.ToolStripSeparator2,
        (ToolStripItem) this.tsViewActualDamage_New,
        (ToolStripItem) this.tsViewDPS_New,
        (ToolStripItem) this.tlsDPA
            });
            this.ViewToolStripMenuItem.ForeColor = SystemColors.ControlText;
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            size = new Size(44, 20);
            this.ViewToolStripMenuItem.Size = size;
            this.ViewToolStripMenuItem.Text = "&View";
            this.tsView4Col.Name = "tsView4Col";
            size = new Size(282, 22);
            this.tsView4Col.Size = size;
            this.tsView4Col.Text = "&4 Columns";
            this.tsView3Col.Checked = true;
            this.tsView3Col.CheckState = CheckState.Checked;
            this.tsView3Col.Name = "tsView3Col";
            size = new Size(282, 22);
            this.tsView3Col.Size = size;
            this.tsView3Col.Text = "&3 Columns";
            this.tsView2Col.Name = "tsView2Col";
            size = new Size(282, 22);
            this.tsView2Col.Size = size;
            this.tsView2Col.Text = "&2 Columns";
            this.ToolStripSeparator13.Name = "ToolStripSeparator13";
            size = new Size(279, 6);
            this.ToolStripSeparator13.Size = size;
            this.tsViewIOLevels.Checked = true;
            this.tsViewIOLevels.CheckState = CheckState.Checked;
            this.tsViewIOLevels.Name = "tsViewIOLevels";
            size = new Size(282, 22);
            this.tsViewIOLevels.Size = size;
            this.tsViewIOLevels.Text = "Show &IO Levels";
            this.tsViewRelative.Name = "tsViewRelative";
            size = new Size(282, 22);
            this.tsViewRelative.Size = size;
            this.tsViewRelative.Text = "Show &Enhancement Relative Levels";
            this.tsViewSlotLevels.Name = "tsViewSlotLevels";
            size = new Size(282, 22);
            this.tsViewSlotLevels.Size = size;
            this.tsViewSlotLevels.Text = "Show &Slot Placement Levels";
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            size = new Size(279, 6);
            this.ToolStripSeparator2.Size = size;
            this.tsViewActualDamage_New.Checked = true;
            this.tsViewActualDamage_New.CheckState = CheckState.Checked;
            this.tsViewActualDamage_New.Name = "tsViewActualDamage_New";
            size = new Size(282, 22);
            this.tsViewActualDamage_New.Size = size;
            this.tsViewActualDamage_New.Text = "Show Damage Per Activation (Level 50)";
            this.tsViewDPS_New.Name = "tsViewDPS_New";
            size = new Size(282, 22);
            this.tsViewDPS_New.Size = size;
            this.tsViewDPS_New.Text = "Show Damage Per Second (Level 50)";
            this.tlsDPA.Name = "tlsDPA";
            size = new Size(282, 22);
            this.tlsDPA.Size = size;
            this.tlsDPA.Text = "Show Damage Per Animation (Level 50)";
            this.tsAbout.Alignment = ToolStripItemAlignment.Right;
            this.tsAbout.ForeColor = SystemColors.ControlText;
            this.tsAbout.Name = "tsAbout";
            size = new Size(52, 20);
            this.tsAbout.Size = size;
            this.tsAbout.Text = "&About";
            this.HelpToolStripMenuItem1.Alignment = ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[10]
            {
        (ToolStripItem) this.tsHelp,
        (ToolStripItem) this.tsPatchNotes,
        (ToolStripItem) this.ToolStripSeparator10,
        (ToolStripItem) this.tsBug,
        (ToolStripItem) this.tsTitanForum,
        (ToolStripItem) this.ToolStripSeparator23,
        (ToolStripItem) this.tsDonate,
        (ToolStripItem) this.ToolStripSeparator24,
        (ToolStripItem) this.tsTitanPlanner,
        (ToolStripItem) this.tsTitanSite
            });
            this.HelpToolStripMenuItem1.ForeColor = SystemColors.ControlText;
            this.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
            size = new Size(102, 20);
            this.HelpToolStripMenuItem1.Size = size;
            this.HelpToolStripMenuItem1.Text = "&Help && Support";
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            size = new Size(258, 22);
            this.tsHelp.Size = size;
            this.tsHelp.Text = "&Read Me - Instructions";
            this.tsPatchNotes.Name = "tsPatchNotes";
            size = new Size(258, 22);
            this.tsPatchNotes.Size = size;
            this.tsPatchNotes.Text = "Read &Latest Patch Notes...";
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            size = new Size((int)byte.MaxValue, 6);
            this.ToolStripSeparator10.Size = size;
            this.tsBug.Name = "tsBug";
            size = new Size(258, 22);
            this.tsBug.Size = size;
            this.tsBug.Text = "Feedback Form / &Bug Report";
            this.tsBug.Visible = false;
            this.tsTitanForum.Name = "tsTitanForum";
            size = new Size(258, 22);
            this.tsTitanForum.Size = size;
            this.tsTitanForum.Text = "Go to Support / Discussion &Forums";
            this.ToolStripSeparator23.Name = "ToolStripSeparator23";
            size = new Size((int)byte.MaxValue, 6);
            this.ToolStripSeparator23.Size = size;
            this.tsDonate.Name = "tsDonate";
            size = new Size(258, 22);
            this.tsDonate.Size = size;
            this.tsDonate.Text = "Make a Donation (PayPal)";
            this.ToolStripSeparator24.Name = "ToolStripSeparator24";
            size = new Size((int)byte.MaxValue, 6);
            this.ToolStripSeparator24.Size = size;
            this.tsTitanPlanner.Name = "tsTitanPlanner";
            size = new Size(258, 22);
            this.tsTitanPlanner.Size = size;
            this.tsTitanPlanner.Text = "CoH &Planner Website";
            this.tsTitanSite.Name = "tsTitanSite";
            size = new Size(258, 22);
            this.tsTitanSite.Size = size;
            this.tsTitanSite.Text = "&Titan Network Website";
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[16]
            {
        (ToolStripItem) this.tsViewSets,
        (ToolStripItem) this.tsViewGraphs,
        (ToolStripItem) this.tsViewSetCompare,
        (ToolStripItem) this.tsViewData,
        (ToolStripItem) this.tsViewTotals,
        (ToolStripItem) this.ToolStripSeparator18,
        (ToolStripItem) this.tsRecipeViewer,
        (ToolStripItem) this.tsDPSCalc,
        (ToolStripItem) this.ToolStripSeparator19,
        (ToolStripItem) this.tsSetFind,
        (ToolStripItem) this.ToolStripSeparator21,
        (ToolStripItem) this.InGameRespecHelperToolStripMenuItem,
        (ToolStripItem) this.ToolStripMenuItem4,
        (ToolStripItem) this.AccoladesWindowToolStripMenuItem,
        (ToolStripItem) this.IncarnateWindowToolStripMenuItem,
        (ToolStripItem) this.TemporaryPowersWindowToolStripMenuItem
            });
            this.WindowToolStripMenuItem.ForeColor = SystemColors.ControlText;
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            size = new Size(63, 20);
            this.WindowToolStripMenuItem.Size = size;
            this.WindowToolStripMenuItem.Text = "&Window";
            this.tsViewSets.Name = "tsViewSets";
            this.tsViewSets.ShortcutKeys = System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsViewSets.Size = size;
            this.tsViewSets.Text = "&Sets && Bonuses";
            this.tsViewGraphs.Name = "tsViewGraphs";
            this.tsViewGraphs.ShortcutKeys = System.Windows.Forms.Keys.G | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsViewGraphs.Size = size;
            this.tsViewGraphs.Text = "Power &Graphs";
            this.tsViewSetCompare.Name = "tsViewSetCompare";
            this.tsViewSetCompare.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsViewSetCompare.Size = size;
            this.tsViewSetCompare.Text = "Powerset &Comparison";
            this.tsViewData.Name = "tsViewData";
            this.tsViewData.ShortcutKeys = System.Windows.Forms.Keys.D | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsViewData.Size = size;
            this.tsViewData.Text = "&Data View";
            this.tsViewTotals.Name = "tsViewTotals";
            this.tsViewTotals.ShortcutKeys = System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsViewTotals.Size = size;
            this.tsViewTotals.Text = "Advanced &Totals";
            this.ToolStripSeparator18.Name = "ToolStripSeparator18";
            size = new Size(229, 6);
            this.ToolStripSeparator18.Size = size;
            this.tsRecipeViewer.Name = "tsRecipeViewer";
            this.tsRecipeViewer.ShortcutKeys = System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsRecipeViewer.Size = size;
            this.tsRecipeViewer.Text = "&Recipe Viewer";
            this.tsDPSCalc.Name = "tsDPSCalc";
            this.tsDPSCalc.ShortcutKeys = System.Windows.Forms.Keys.Z | System.Windows.Forms.Keys.Control;
            size = new Size(232, 22);
            this.tsDPSCalc.Size = size;
            this.tsDPSCalc.Text = "DPS Calculator (Beta)";
            this.ToolStripSeparator19.Name = "ToolStripSeparator19";
            size = new Size(229, 6);
            this.ToolStripSeparator19.Size = size;
            this.tsSetFind.Name = "tsSetFind";
            size = new Size(232, 22);
            this.tsSetFind.Size = size;
            this.tsSetFind.Text = "Set &Bonus Finder";
            this.ToolStripSeparator21.Name = "ToolStripSeparator21";
            size = new Size(229, 6);
            this.ToolStripSeparator21.Size = size;
            this.InGameRespecHelperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
            {
        (ToolStripItem) this.tsHelperShort,
        (ToolStripItem) this.tsHelperLong,
        (ToolStripItem) this.ToolStripSeparator20,
        (ToolStripItem) this.tsHelperShort2,
        (ToolStripItem) this.tsHelperLong2
            });
            this.InGameRespecHelperToolStripMenuItem.Name = "InGameRespecHelperToolStripMenuItem";
            size = new Size(232, 22);
            this.InGameRespecHelperToolStripMenuItem.Size = size;
            this.InGameRespecHelperToolStripMenuItem.Text = "In-Game &Respec Helper";
            this.tsHelperShort.Name = "tsHelperShort";
            size = new Size(143, 22);
            this.tsHelperShort.Size = size;
            this.tsHelperShort.Text = "Profile &Short";
            this.tsHelperLong.Name = "tsHelperLong";
            size = new Size(143, 22);
            this.tsHelperLong.Size = size;
            this.tsHelperLong.Text = "Profile &Long";
            this.ToolStripSeparator20.Name = "ToolStripSeparator20";
            size = new Size(140, 6);
            this.ToolStripSeparator20.Size = size;
            this.tsHelperShort2.Name = "tsHelperShort2";
            size = new Size(143, 22);
            this.tsHelperShort2.Size = size;
            this.tsHelperShort2.Text = "History S&hort";
            this.tsHelperLong2.Name = "tsHelperLong2";
            size = new Size(143, 22);
            this.tsHelperLong2.Size = size;
            this.tsHelperLong2.Text = "History L&ong";
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            size = new Size(229, 6);
            this.ToolStripMenuItem4.Size = size;
            this.AccoladesWindowToolStripMenuItem.Name = "AccoladesWindowToolStripMenuItem";
            size = new Size(232, 22);
            this.AccoladesWindowToolStripMenuItem.Size = size;
            this.AccoladesWindowToolStripMenuItem.Text = "&Accolades Window";
            this.IncarnateWindowToolStripMenuItem.Name = "IncarnateWindowToolStripMenuItem";
            size = new Size(232, 22);
            this.IncarnateWindowToolStripMenuItem.Size = size;
            this.IncarnateWindowToolStripMenuItem.Text = "&Incarnate Window";
            this.TemporaryPowersWindowToolStripMenuItem.Name = "TemporaryPowersWindowToolStripMenuItem";
            size = new Size(232, 22);
            this.TemporaryPowersWindowToolStripMenuItem.Size = size;
            this.TemporaryPowersWindowToolStripMenuItem.Text = "T&emporary Powers Window";
            point = new Point(355, 80);
            this.pbDynMode.Location = point;
            this.pbDynMode.Name = "pbDynMode";
            size = new Size(105, 22);
            this.pbDynMode.Size = size;
            this.pbDynMode.TabIndex = 92;
            this.pbDynMode.TabStop = false;
            this.pnlGFX.BackColor = Color.Black;
            point = new Point(3, 3);
            this.pnlGFX.Location = point;
            this.pnlGFX.Name = "pnlGFX";
            size = new Size(584, 709);
            this.pnlGFX.Size = size;
            this.pnlGFX.TabIndex = 103;
            this.pnlGFX.TabStop = false;
            this.pnlGFXFlow.AutoScroll = true;
            this.pnlGFXFlow.Controls.Add((Control)this.pnlGFX);
            point = new Point(472, 78);
            this.pnlGFXFlow.Location = point;
            this.pnlGFXFlow.Name = "pnlGFXFlow";
            size = new Size(584, 629);
            this.pnlGFXFlow.Size = size;
            this.pnlGFXFlow.TabIndex = 112;
            this.llAncillary.Expandable = false;
            this.llAncillary.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.llAncillary.HighVis = true;
            this.llAncillary.HoverColor = Color.WhiteSmoke;
            point = new Point(328, 638);
            this.llAncillary.Location = point;
            this.llAncillary.MaxHeight = 500;
            this.llAncillary.Name = "llAncillary";
            this.llAncillary.PaddingX = 2;
            this.llAncillary.PaddingY = 2;
            this.llAncillary.Scrollable = true;
            this.llAncillary.ScrollBarColor = Color.Red;
            this.llAncillary.ScrollBarWidth = 11;
            this.llAncillary.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            size = new Size(138, 69);
            this.llAncillary.Size = size;
            size = new Size(138, 69);
            this.llAncillary.SizeNormal = size;
            this.llAncillary.SuspendRedraw = false;
            this.llAncillary.TabIndex = 110;
            this.lblName.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblName.ForeColor = Color.White;
            this.lblName.InitialText = "Name:";
            point = new Point(4, 82);
            this.lblName.Location = point;
            this.lblName.Name = "lblName";
            size = new Size(92, 21);
            this.lblName.Size = size;
            this.lblName.TabIndex = 44;
            this.lblName.TextAlign = ContentAlignment.MiddleRight;
            this.lblOrigin.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblOrigin.InitialText = "Origin:";
            point = new Point(2, 133);
            this.lblOrigin.Location = point;
            this.lblOrigin.Name = "lblOrigin";
            size = new Size(92, 21);
            this.lblOrigin.Size = size;
            this.lblOrigin.TabIndex = 46;
            this.lblOrigin.TextAlign = ContentAlignment.MiddleRight;
            this.lblAT.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblAT.InitialText = "Archetype:";
            point = new Point(2, 109);
            this.lblAT.Location = point;
            this.lblAT.Name = "lblAT";
            size = new Size(92, 21);
            this.lblAT.Size = size;
            this.lblAT.TabIndex = 45;
            this.lblAT.TextAlign = ContentAlignment.MiddleRight;
            this.llPool0.Expandable = false;
            this.llPool0.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool0.HighVis = true;
            this.llPool0.HoverColor = Color.WhiteSmoke;
            point = new Point(328, 206);
            this.llPool0.Location = point;
            this.llPool0.MaxHeight = 500;
            this.llPool0.Name = "llPool0";
            this.llPool0.PaddingX = 2;
            this.llPool0.PaddingY = 2;
            this.llPool0.Scrollable = true;
            this.llPool0.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool0.ScrollBarWidth = 11;
            this.llPool0.ScrollButtonColor = Color.FromArgb(96, 0, 192);
            size = new Size(136, 69);
            this.llPool0.Size = size;
            size = new Size(136, 69);
            this.llPool0.SizeNormal = size;
            this.llPool0.SuspendRedraw = false;
            this.llPool0.TabIndex = 34;
            this.llPool1.Expandable = false;
            this.llPool1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool1.ForeColor = Color.Yellow;
            this.llPool1.HighVis = true;
            this.llPool1.HoverColor = Color.WhiteSmoke;
            point = new Point(328, 314);
            this.llPool1.Location = point;
            this.llPool1.MaxHeight = 500;
            this.llPool1.Name = "llPool1";
            this.llPool1.PaddingX = 2;
            this.llPool1.PaddingY = 2;
            this.llPool1.Scrollable = true;
            this.llPool1.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool1.ScrollBarWidth = 8;
            this.llPool1.ScrollButtonColor = Color.FromArgb(96, 0, 192);
            size = new Size(136, 69);
            this.llPool1.Size = size;
            size = new Size(136, 69);
            this.llPool1.SizeNormal = size;
            this.llPool1.SuspendRedraw = false;
            this.llPool1.TabIndex = 35;
            this.llSecondary.Expandable = true;
            this.llSecondary.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.llSecondary.HighVis = true;
            this.llSecondary.HoverColor = Color.WhiteSmoke;
            point = new Point(168, 206);
            this.llSecondary.Location = point;
            this.llSecondary.MaxHeight = 600;
            this.llSecondary.Name = "llSecondary";
            this.llSecondary.PaddingX = 2;
            this.llSecondary.PaddingY = 2;
            this.llSecondary.Scrollable = true;
            this.llSecondary.ScrollBarColor = Color.Red;
            this.llSecondary.ScrollBarWidth = 11;
            this.llSecondary.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            size = new Size(144, 160);
            this.llSecondary.Size = size;
            size = new Size(144, 160);
            this.llSecondary.SizeNormal = size;
            this.llSecondary.SuspendRedraw = false;
            this.llSecondary.TabIndex = 108;
            this.llPrimary.Expandable = true;
            this.llPrimary.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.llPrimary.HighVis = true;
            this.llPrimary.HoverColor = Color.WhiteSmoke;
            point = new Point(16, 206);
            this.llPrimary.Location = point;
            this.llPrimary.MaxHeight = 600;
            this.llPrimary.Name = "llPrimary";
            this.llPrimary.PaddingX = 2;
            this.llPrimary.PaddingY = 2;
            this.llPrimary.Scrollable = true;
            this.llPrimary.ScrollBarColor = Color.Red;
            this.llPrimary.ScrollBarWidth = 11;
            this.llPrimary.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            size = new Size(144, 160);
            this.llPrimary.Size = size;
            size = new Size(144, 160);
            this.llPrimary.SizeNormal = size;
            this.llPrimary.SuspendRedraw = false;
            this.llPrimary.TabIndex = 107;
            this.llPool3.Expandable = false;
            this.llPool3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool3.ForeColor = Color.Yellow;
            this.llPool3.HighVis = true;
            this.llPool3.HoverColor = Color.WhiteSmoke;
            point = new Point(328, 530);
            this.llPool3.Location = point;
            this.llPool3.MaxHeight = 500;
            this.llPool3.Name = "llPool3";
            this.llPool3.PaddingX = 1;
            this.llPool3.PaddingY = 1;
            this.llPool3.Scrollable = true;
            this.llPool3.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool3.ScrollBarWidth = 8;
            this.llPool3.ScrollButtonColor = Color.FromArgb(96, 0, 192);
            size = new Size(136, 69);
            this.llPool3.Size = size;
            size = new Size(136, 69);
            this.llPool3.SizeNormal = size;
            this.llPool3.SuspendRedraw = false;
            this.llPool3.TabIndex = 37;
            this.llPool2.Expandable = false;
            this.llPool2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool2.ForeColor = Color.Yellow;
            this.llPool2.HighVis = true;
            this.llPool2.HoverColor = Color.WhiteSmoke;
            point = new Point(328, 422);
            this.llPool2.Location = point;
            this.llPool2.MaxHeight = 500;
            this.llPool2.Name = "llPool2";
            this.llPool2.PaddingX = 1;
            this.llPool2.PaddingY = 1;
            this.llPool2.Scrollable = true;
            this.llPool2.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool2.ScrollBarWidth = 8;
            this.llPool2.ScrollButtonColor = Color.FromArgb(96, 0, 192);
            size = new Size(136, 69);
            this.llPool2.Size = size;
            size = new Size(136, 69);
            this.llPool2.SizeNormal = size;
            this.llPool2.SuspendRedraw = false;
            this.llPool2.TabIndex = 36;
            this.lblHero.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblHero.ForeColor = Color.White;
            this.lblHero.InitialText = "Name: Level 0 Origin Archetype (Primary / Secondary)";
            point = new Point(4, 26);
            this.lblHero.Location = point;
            this.lblHero.Name = "lblHero";
            size = new Size(834, 46);
            this.lblHero.Size = size;
            this.lblHero.TabIndex = 43;
            this.lblHero.TextAlign = ContentAlignment.TopLeft;
            this.heroVillain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.heroVillain.Checked = false;
            this.heroVillain.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.heroVillain.KnockoutLocationPoint = point;
            point = new Point(630, 27);
            this.heroVillain.Location = point;
            this.heroVillain.Name = "heroVillain";
            size = new Size(105, 22);
            this.heroVillain.Size = size;
            this.heroVillain.TabIndex = 116;
            this.heroVillain.TextOff = "Hero";
            this.heroVillain.TextOn = "Villain";
            this.heroVillain.Toggle = true;
            this.tempPowersButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.tempPowersButton.Checked = false;
            this.tempPowersButton.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.tempPowersButton.KnockoutLocationPoint = point;
            point = new Point(951, 50);
            this.tempPowersButton.Location = point;
            this.tempPowersButton.Name = "tempPowersButton";
            size = new Size(105, 22);
            this.tempPowersButton.Size = size;
            this.tempPowersButton.TabIndex = 115;
            this.tempPowersButton.TextOff = "Temp Pwrs (Off)";
            this.tempPowersButton.TextOn = "Temp Pwrs (On)";
            this.tempPowersButton.Toggle = true;
            this.accoladeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.accoladeButton.Checked = false;
            this.accoladeButton.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.accoladeButton.KnockoutLocationPoint = point;
            point = new Point(737, 50);
            this.accoladeButton.Location = point;
            this.accoladeButton.Name = "accoladeButton";
            size = new Size(105, 22);
            this.accoladeButton.Size = size;
            this.accoladeButton.TabIndex = 114;
            this.accoladeButton.TextOff = "Accolades (Off)";
            this.accoladeButton.TextOn = "Accolades (On)";
            this.accoladeButton.Toggle = true;
            this.incarnateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.incarnateButton.Checked = false;
            this.incarnateButton.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.incarnateButton.KnockoutLocationPoint = point;
            point = new Point(844, 50);
            this.incarnateButton.Location = point;
            this.incarnateButton.Name = "incarnateButton";
            size = new Size(105, 22);
            this.incarnateButton.Size = size;
            this.incarnateButton.TabIndex = 113;
            this.incarnateButton.TextOff = "Incarnate";
            this.incarnateButton.TextOn = "Incarnate";
            this.incarnateButton.Toggle = false;
            this.I9Picker.BackColor = Color.Black;
            this.I9Picker.ForeColor = Color.Blue;
            this.I9Picker.Highlight = Color.MediumSlateBlue;
            this.I9Picker.ImageSize = 30;
            point = new Point(452, 131);
            this.I9Picker.Location = point;
            this.I9Picker.Name = "I9Picker";
            this.I9Picker.Selected = Color.SlateBlue;
            size = new Size(198, 235);
            this.I9Picker.Size = size;
            this.I9Picker.TabIndex = 83;
            this.I9Picker.Visible = false;
            this.I9Popup.BackColor = Color.Black;
            this.I9Popup.BXHeight = 600;
            this.I9Popup.ColumnPosition = 0.5f;
            this.I9Popup.ColumnRight = false;
            this.I9Popup.Font = new Font("Arial", 13f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.I9Popup.ForeColor = Color.FromArgb(96, 48, (int)byte.MaxValue);
            this.I9Popup.InternalPadding = 3;
            point = new Point(513, 490);
            this.I9Popup.Location = point;
            this.I9Popup.Name = "I9Popup";
            this.I9Popup.ScrollY = 0.0f;
            this.I9Popup.SectionPadding = 8;
            size = new Size(400, 214);
            this.I9Popup.Size = size;
            this.I9Popup.TabIndex = 102;
            this.I9Popup.Visible = false;
            this.ibVetPools.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibVetPools.Checked = false;
            this.ibVetPools.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibVetPools.KnockoutLocationPoint = point;
            point = new Point(441, 50);
            this.ibVetPools.Location = point;
            this.ibVetPools.Name = "ibVetPools";
            size = new Size(105, 22);
            this.ibVetPools.Size = size;
            this.ibVetPools.TabIndex = 111;
            this.ibVetPools.TextOff = "Veteran Pools: Off";
            this.ibVetPools.TextOn = "Veteran Pools: On";
            this.ibVetPools.Toggle = true;
            this.ibVetPools.Visible = false;
            this.ibPvX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibPvX.Checked = false;
            this.ibPvX.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibPvX.KnockoutLocationPoint = point;
            point = new Point(737, 27);
            this.ibPvX.Location = point;
            this.ibPvX.Name = "ibPvX";
            size = new Size(105, 22);
            this.ibPvX.Size = size;
            this.ibPvX.TabIndex = 111;
            this.ibPvX.TextOff = "Mode: PvE";
            this.ibPvX.TextOn = "Mode: PvP";
            this.ibPvX.Toggle = true;
            this.dvAnchored.BackColor = Color.Black;
            this.dvAnchored.DrawVillain = false;
            this.dvAnchored.Floating = false;
            this.dvAnchored.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            point = new Point(16, 391);
            this.dvAnchored.Location = point;
            this.dvAnchored.Name = "dvAnchored";
            size = new Size(300, 347);
            this.dvAnchored.Size = size;
            this.dvAnchored.TabIndex = 69;
            this.dvAnchored.VisibleSize = Enums.eVisibleSize.Full;
            this.ibTotals.Checked = false;
            this.ibTotals.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibTotals.KnockoutLocationPoint = point;
            point = new Point(355, 109);
            this.ibTotals.Location = point;
            this.ibTotals.Name = "ibTotals";
            size = new Size(105, 22);
            this.ibTotals.Size = size;
            this.ibTotals.TabIndex = 99;
            this.ibTotals.TextOff = "View Totals";
            this.ibTotals.TextOn = "Alt Text";
            this.ibTotals.Toggle = false;
            this.ibSlotLevels.Checked = false;
            this.ibSlotLevels.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibSlotLevels.KnockoutLocationPoint = point;
            point = new Point(244, 133);
            this.ibSlotLevels.Location = point;
            this.ibSlotLevels.Name = "ibSlotLevels";
            size = new Size(105, 22);
            this.ibSlotLevels.Size = size;
            this.ibSlotLevels.TabIndex = 101;
            this.ibSlotLevels.TextOff = "Slot Levels: Off";
            this.ibSlotLevels.TextOn = "Slot Levels: On";
            this.ibSlotLevels.Toggle = true;
            this.ibMode.Checked = false;
            this.ibMode.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibMode.KnockoutLocationPoint = point;
            point = new Point(244, 80);
            this.ibMode.Location = point;
            this.ibMode.Name = "ibMode";
            size = new Size(105, 22);
            this.ibMode.Size = size;
            this.ibMode.TabIndex = 100;
            this.ibMode.TextOff = "Mode Switch";
            this.ibMode.TextOn = "Alt Text";
            this.ibMode.Toggle = false;
            this.ibSets.Checked = false;
            this.ibSets.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibSets.KnockoutLocationPoint = point;
            point = new Point(244, 109);
            this.ibSets.Location = point;
            this.ibSets.Name = "ibSets";
            size = new Size(105, 22);
            this.ibSets.Size = size;
            this.ibSets.TabIndex = 98;
            this.ibSets.TextOff = "View Active Sets";
            this.ibSets.TextOn = "Alt Text";
            this.ibSets.Toggle = false;
            this.ibAccolade.Checked = false;
            this.ibAccolade.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibAccolade.KnockoutLocationPoint = point;
            point = new Point(355, 133);
            this.ibAccolade.Location = point;
            this.ibAccolade.Name = "ibAccolade";
            size = new Size(105, 22);
            this.ibAccolade.Size = size;
            this.ibAccolade.TabIndex = 106;
            this.ibAccolade.TextOff = "67 Slots to go";
            this.ibAccolade.TextOn = "0 Slots placed";
            this.ibAccolade.Toggle = true;
            this.ibRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibRecipe.Checked = false;
            this.ibRecipe.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibRecipe.KnockoutLocationPoint = point;
            point = new Point(844, 27);
            this.ibRecipe.Location = point;
            this.ibRecipe.Name = "ibRecipe";
            size = new Size(105, 22);
            this.ibRecipe.Size = size;
            this.ibRecipe.TabIndex = 105;
            this.ibRecipe.TextOff = "Recipes: Off";
            this.ibRecipe.TextOn = "Recipes: On";
            this.ibRecipe.Toggle = true;
            this.ibPopup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibPopup.Checked = false;
            this.ibPopup.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(0, 0);
            this.ibPopup.KnockoutLocationPoint = point;
            point = new Point(951, 27);
            this.ibPopup.Location = point;
            this.ibPopup.Name = "ibPopup";
            size = new Size(105, 22);
            this.ibPopup.Size = size;
            this.ibPopup.TabIndex = 104;
            this.ibPopup.TextOff = "Pop-Up: Off";
            this.ibPopup.TextOn = "Pop-Up: On";
            this.ibPopup.Toggle = true;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Black;
            size = new Size(1056, 752);
            this.ClientSize = size;
            this.Controls.Add((Control)this.heroVillain);
            this.Controls.Add((Control)this.tempPowersButton);
            this.Controls.Add((Control)this.accoladeButton);
            this.Controls.Add((Control)this.incarnateButton);
            this.Controls.Add((Control)this.I9Picker);
            this.Controls.Add((Control)this.I9Popup);
            this.Controls.Add((Control)this.ibVetPools);
            this.Controls.Add((Control)this.ibPvX);
            this.Controls.Add((Control)this.llAncillary);
            this.Controls.Add((Control)this.dvAnchored);
            this.Controls.Add((Control)this.lblLockedSecondary);
            this.Controls.Add((Control)this.ibTotals);
            this.Controls.Add((Control)this.ibSlotLevels);
            this.Controls.Add((Control)this.ibMode);
            this.Controls.Add((Control)this.ibSets);
            this.Controls.Add((Control)this.pbDynMode);
            this.Controls.Add((Control)this.MenuBar);
            this.Controls.Add((Control)this.lblLockedAncillary);
            this.Controls.Add((Control)this.lblLocked3);
            this.Controls.Add((Control)this.lblLocked2);
            this.Controls.Add((Control)this.lblLocked1);
            this.Controls.Add((Control)this.lblLocked0);
            this.Controls.Add((Control)this.lblName);
            this.Controls.Add((Control)this.lblATLocked);
            this.Controls.Add((Control)this.lblOrigin);
            this.Controls.Add((Control)this.lblAT);
            this.Controls.Add((Control)this.txtName);
            this.Controls.Add((Control)this.llPool0);
            this.Controls.Add((Control)this.llPool1);
            this.Controls.Add((Control)this.lblPool3);
            this.Controls.Add((Control)this.cbPool1);
            this.Controls.Add((Control)this.lblPool2);
            this.Controls.Add((Control)this.cbPool0);
            this.Controls.Add((Control)this.lblPool1);
            this.Controls.Add((Control)this.cbSecondary);
            this.Controls.Add((Control)this.lblSecondary);
            this.Controls.Add((Control)this.cbPrimary);
            this.Controls.Add((Control)this.cbOrigin);
            this.Controls.Add((Control)this.cbAT);
            this.Controls.Add((Control)this.ibAccolade);
            this.Controls.Add((Control)this.ibRecipe);
            this.Controls.Add((Control)this.ibPopup);
            this.Controls.Add((Control)this.lblPrimary);
            this.Controls.Add((Control)this.llSecondary);
            this.Controls.Add((Control)this.llPrimary);
            this.Controls.Add((Control)this.llPool3);
            this.Controls.Add((Control)this.llPool2);
            this.Controls.Add((Control)this.cbAncillary);
            this.Controls.Add((Control)this.lblEpic);
            this.Controls.Add((Control)this.cbPool3);
            this.Controls.Add((Control)this.lblPool4);
            this.Controls.Add((Control)this.cbPool2);
            this.Controls.Add((Control)this.pnlGFXFlow);
            this.Controls.Add((Control)this.lblHero);
            this.DoubleBuffered = true;
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.ForeColor = Color.White;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuBar;
            size = new Size(640, 480);
            this.MinimumSize = size;
            this.Name = nameof(frmMain);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hero Designer";
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            ((ISupportInitialize)this.pbDynMode).EndInit();
            ((ISupportInitialize)this.pnlGFX).EndInit();
            this.pnlGFXFlow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        void lblATLocked_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void lblATLocked_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || this.cbAT.SelectedIndex < 0)
                return;
            this.ShowPopup(-1, Conversions.ToInteger(NewLateBinding.LateGet(this.cbAT.SelectedItem, (System.Type)null, "Idx", new object[0], (string[])null, (System.Type[])null, (bool[])null)), this.cbAT.Bounds, "");
        }

        void lblATLocked_Paint(object sender, PaintEventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            RectangleF destRect = new RectangleF(1f, (float)(this.lblATLocked.Height - 16) / 2f, 16f, 16f);
            --destRect.Y;
            RectangleF srcRect = new RectangleF((float)(MidsContext.Character.Archetype.Idx * 16), 0.0f, 16f, 16f);
            Graphics graphics = e.Graphics;
            graphics.DrawImage((Image)I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            destRect.X = (float)(this.lblATLocked.Width - 19);
            graphics.DrawImage((Image)I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
        }

        void lblLocked0_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void lblLocked0_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[3] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
        }

        void lblLocked0_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool0);
        }

        void lblLocked1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[4] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
        }

        void lblLocked1_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool1);
        }

        void lblLocked2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[5] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
        }

        void lblLocked2_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool2);
        }

        void lblLocked3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[6] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
        }

        void lblLocked3_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool3);
        }

        void lblLockedAncillary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[7] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.cbAncillary.Bounds, ExtraString);
        }

        void lblLockedAncillary_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Ancillary);
        }

        void lblLockedSecondary_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void lblLockedSecondary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Archetype.Idx < 0 || this.cbSecondary.SelectedIndex < 0)
                return;
            string ExtraString = MidsContext.Character.Powersets[0].nIDLinkSecondary <= -1 ? "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set." : "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
            this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
        }

        void llAll_EmptyHover()
        {
            this.HidePopup();
        }

        void llALL_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }

        void llAncillary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Item.ItemState == ListLabelV2.LLItemState.Heading)
                return;
            switch (Button)
            {
                case MouseButtons.Left:
                    this.PowerPicked(Item.nIDSet, Item.nIDPower);
                    break;
                case MouseButtons.Right:
                    this.Info_Power(Item.nIDPower, -1, false, true);
                    break;
            }
        }

        void llAncillary_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            if (Item.ItemState == ListLabelV2.LLItemState.Heading)
            {
                this.ShowPopup(Item.nIDSet, -1, this.llAncillary.Bounds, "");
            }
            else
            {
                this.Info_Power(Item.nIDPower, -1, false, false);
                this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llAncillary.Bounds, (I9Slot)null, -1);
            }
        }

        void llPool0_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool0, Item.nIDPower);
            }
            else
            {
                if (Button != MouseButtons.Right)
                    return;
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }

        void llPool0_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llPool0.Bounds, (I9Slot)null, -1);
        }

        void llPool1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool1, Item.nIDPower);
            }
            else
            {
                if (Button != MouseButtons.Right)
                    return;
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }

        void llPool1_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llPool1.Bounds, (I9Slot)null, -1);
        }

        void llPool2_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool2, Item.nIDPower);
            }
            else
            {
                if (Button != MouseButtons.Right)
                    return;
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }

        void llPool2_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llPool2.Bounds, (I9Slot)null, -1);
        }

        void llPool3_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool3, Item.nIDPower);
            }
            else
            {
                if (Button != MouseButtons.Right)
                    return;
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }

        void llPool3_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llPool3.Bounds, (I9Slot)null, -1);
        }

        void llPrimary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Item.ItemState == ListLabelV2.LLItemState.Heading)
                return;
            switch (Button)
            {
                case MouseButtons.Left:
                    this.PowerPicked(Item.nIDSet, Item.nIDPower);
                    break;
                case MouseButtons.Right:
                    this.Info_Power(Item.nIDPower, -1, false, true);
                    break;
            }
        }

        void llPrimary_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            if (Item.ItemState == ListLabelV2.LLItemState.Heading)
            {
                this.ShowPopup(Item.nIDSet, -1, this.llPrimary.Bounds, "");
            }
            else
            {
                this.Info_Power(Item.nIDPower, -1, false, false);
                this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llPrimary.Bounds, (I9Slot)null, -1);
            }
        }

        void llSecondary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Item.ItemState == ListLabelV2.LLItemState.Heading)
                return;
            switch (Button)
            {
                case MouseButtons.Left:
                    this.PowerPicked(Item.nIDSet, Item.nIDPower);
                    break;
                case MouseButtons.Right:
                    this.Info_Power(Item.nIDPower, -1, false, true);
                    break;
            }
        }

        void llSecondary_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            if (Item.ItemState == ListLabelV2.LLItemState.Heading)
            {
                this.ShowPopup(Item.nIDSet, -1, this.llSecondary.Bounds, "");
            }
            else
            {
                this.Info_Power(Item.nIDPower, -1, false, false);
                this.ShowPopup(-1, Item.nIDPower, -1, new Point(), this.llSecondary.Bounds, (I9Slot)null, -1);
            }
        }

        void MiniPaint(ref PaintEventArgs e, Enums.PowersetType iId)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[(int)iId] == null)
                return;
            RectangleF destRect = new RectangleF(1f, (float)(this.lblLocked0.Height - 16) / 2f, 16f, 16f);
            --destRect.Y;
            RectangleF srcRect = new RectangleF((float)(MidsContext.Character.Powersets[(int)iId].nID * 16), 0.0f, 16f, 16f);
            Graphics graphics = e.Graphics;
            graphics.DrawImage((Image)I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            destRect.X = (float)(this.lblLocked0.Width - 19);
            graphics.DrawImage((Image)I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
        }

        void MovePopup(Rectangle rBounds)
        {
            if (!this.PopUpVisible)
                return;
            Rectangle bounds = this.I9Popup.Bounds;
            if (rBounds != bounds)
            {
                this.SetPopupLocation(rBounds, false, true);
                this.RedrawUnderPopup(bounds);
            }
        }

        void NewDraw(bool skipDraw = false)
        {
            if (this.drawing == null)
            {
                Control pnlGfx = (Control)this.pnlGFX;
                this.pnlGFX = (PictureBox)pnlGfx;
                this.drawing = new clsDrawX(ref pnlGfx);
            }
            else
            {
                Control pnlGfx = (Control)this.pnlGFX;
                this.drawing.ReInit(ref pnlGfx);
                this.pnlGFX = (PictureBox)pnlGfx;
            }
            this.pnlGFX.Image = (Image)this.drawing.bxBuffer.Bitmap;
            if (this.drawing != null)
                this.drawing.Highlight = -1;
            if (skipDraw)
                return;
            this.DoRedraw();
        }

        void NewToon(bool Init = true, bool SkipDraw = false)
        {
            if (MainModule.MidsController.Toon == null)
                MainModule.MidsController.Toon = new clsToonX();
            else if (Init)
            {
                MidsContext.Character.Reset((Archetype)null, 0);
            }
            else
            {
                string str = !MainModule.MidsController.Toon.Locked ? MidsContext.Character.Name : "";
                MidsContext.Character.Reset((Archetype)this.cbAT.SelectedItem, this.cbOrigin.SelectedIndex);
                if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                    MidsContext.Character.Powersets[1] = DatabaseAPI.Database.Powersets[MidsContext.Character.Powersets[0].nIDLinkSecondary];
                MidsContext.Character.Name = str;
            }
            if (this.fAccolade != null && !this.fAccolade.IsDisposed)
                this.fAccolade.Dispose();
            if (this.fTemp != null && !this.fTemp.IsDisposed)
                this.fTemp.Dispose();
            if (this.fIncarnate != null && !this.fIncarnate.IsDisposed)
                this.fIncarnate.Dispose();
            this.NewDraw(SkipDraw);
            this.UpdateControls(false);
            this.SetTitleBar(MidsContext.Character.IsHero());
            this.UpdateColours(false);
            this.info_Totals();
            this.FileModified = false;
        }

        void pbDynMode_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Config.BuildMode != Enums.dmModes.Dynamic)
                return;
            MidsContext.Config.BuildOption = MidsContext.Config.BuildOption == Enums.dmItem.Power ? Enums.dmItem.Slot : Enums.dmItem.Power;
            this.UpdateDMBuffer();
            this.pbDynMode.Refresh();
        }

        void pbDynMode_Paint(object sender, PaintEventArgs e)
        {
            if (this.dmBuffer == null)
                this.UpdateDMBuffer();
            if (this.dmBuffer == null)
                return;
            e.Graphics.DrawImage((Image)this.dmBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
        }

        void pnlGFX_DragDrop(object sender, DragEventArgs e)
        {
            if (!sender.Equals((object)this.pnlGFX))
                return;
            this.pnlGFX.AllowDrop = false;
            ControlPaint.DrawReversibleFrame(this.dragRect, Color.White, FrameStyle.Thick);
            this.oldDragRect = Rectangle.Empty;
            this.dragRect = Rectangle.Empty;
            int iValue1 = e.X + this.xCursorOffset;
            int iValue2 = e.Y + this.yCursorOffset;
            this.dragFinishPower = this.drawing.WhichSlot(this.drawing.ScaleUp(iValue1), this.drawing.ScaleUp(iValue2));
            if (this.dragStartSlot != -1)
            {
                this.dragFinishSlot = this.drawing.WhichEnh(this.drawing.ScaleUp(iValue1), this.drawing.ScaleUp(iValue2));
                if (this.dragFinishSlot == 0)
                {
                    int num = (int)Interaction.MsgBox((object)"You cannot change the level of any power's automatic slot.", MsgBoxStyle.OkOnly, (object)null);
                }
                else
                    this.SlotLevelSwap(this.dragStartPower, this.dragStartSlot, this.dragFinishPower, this.dragFinishSlot);
            }
            else if ((e.KeyState & 4) > 0)
                this.PowerMoveByUser(this.dragStartPower, this.dragFinishPower);
            else
                this.PowerSwapByUser(this.dragStartPower, this.dragFinishPower);
        }

        void pnlGFX_DragEnter(object sender, DragEventArgs e)
        {
            if (sender.Equals((object)this.pnlGFX))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        void pnlGFX_DragOver(object sender, DragEventArgs e)
        {
            Point position;
            int num1;
            if (sender.Equals((object)this.pnlGFX))
            {
                if (!this.dragRect.IsEmpty)
                {
                    int top = this.dragRect.Top;
                    position = Cursor.Position;
                    int num2 = position.Y - this.dragYOffset;
                    int num3 = top != num2 ? 1 : 0;
                    int left = this.dragRect.Left;
                    position = Cursor.Position;
                    int num4 = position.X - this.dragXOffset;
                    int num5 = left != num4 ? 1 : 0;
                    num1 = (num3 | num5) == 0 ? 1 : 0;
                }
                else
                    num1 = 0;
            }
            else
                num1 = 1;
            if (num1 != 0)
                return;
            if (this.dragStartSlot != -1)
            {
                position = Cursor.Position;
                int x = position.X - this.dragXOffset;
                position = Cursor.Position;
                int y = position.Y - this.dragYOffset;
                int width = this.drawing.ScaleDown(this.drawing.szSlot.Width);
                int height = this.drawing.ScaleDown(this.drawing.szSlot.Height);
                this.dragRect = new Rectangle(x, y, width, height);
            }
            else
            {
                position = Cursor.Position;
                int x = position.X - this.dragXOffset;
                position = Cursor.Position;
                int y = position.Y - this.dragYOffset;
                int width = this.drawing.ScaleDown(this.drawing.szPower.Width);
                int height = this.drawing.ScaleDown(this.drawing.szPower.Height);
                this.dragRect = new Rectangle(x, y, width, height);
            }
            if (!this.oldDragRect.IsEmpty)
                ControlPaint.DrawReversibleFrame(this.oldDragRect, Color.White, FrameStyle.Thick);
            if (this.ClientRectangle.Contains(this.RectangleToClient(this.dragRect)))
                this.oldDragRect = this.dragRect;
            else
                this.dragRect = this.oldDragRect;
            ControlPaint.DrawReversibleFrame(this.dragRect, Color.White, FrameStyle.Thick);
        }

        void pnlGFX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(!this.LastClickPlacedSlot & this.dragStartSlot >= 0))
                return;
            MainModule.MidsController.Toon.BuildSlot(this.dragStartPower, this.dragStartSlot);
            this.PowerModified();
            this.FileModified = true;
            this.DoneDblClick = true;
            this.LastClickPlacedSlot = false;
        }

        void pnlGFX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.pnlGFX.AllowDrop = true;
            this.dragStartX = e.X;
            this.dragStartY = e.Y;
            this.dragStartPower = this.drawing.WhichSlot(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
            this.dragStartSlot = this.drawing.WhichEnh(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
        }

        void pnlGFX_MouseEnter(object sender, EventArgs e)
        {
            this.pnlGFXFlow.Focus();
        }

        void pnlGFX_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
            this.drawing.HighlightSlot(-1, false);
        }

        void pnlGFX_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.pnlGFX.AllowDrop && Math.Abs(e.X - this.dragStartX) + Math.Abs(e.Y - this.dragStartY) > 7)
            {
                if (this.dragStartSlot == 0)
                {
                    int num = (int)Interaction.MsgBox((object)"You cannot change the level of any power's automatic slot.", MsgBoxStyle.OkOnly, (object)null);
                    this.pnlGFX.AllowDrop = false;
                }
                else
                {
                    this.xCursorOffset = e.X - Cursor.Position.X;
                    this.yCursorOffset = e.Y - Cursor.Position.Y;
                    if (this.dragStartSlot != -1)
                    {
                        this.dragXOffset = this.drawing.ScaleDown(this.drawing.szSlot.Width / 2);
                        this.dragYOffset = this.drawing.ScaleDown(this.drawing.szSlot.Height / 2);
                    }
                    else
                    {
                        this.dragXOffset = this.drawing.ScaleDown(this.drawing.szPower.Width / 2);
                        this.dragYOffset = this.drawing.ScaleDown(this.drawing.szPower.Height / 2);
                    }
                    DataObject dataObject = new DataObject();
                    dataObject.SetText("This is some filler power text right here");
                    this.HidePopup();
                    this.pnlGFX.Cursor = Cursors.Default;
                    this.drawing.HighlightSlot(-1, false);
                    Application.DoEvents();
                    int num = (int)this.ibPopup.DoDragDrop((object)dataObject, DragDropEffects.Move);
                }
            }
            else
            {
                int index = this.drawing.WhichSlot(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                int sIDX = this.drawing.WhichEnh(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                if (index < 0 | index >= MidsContext.Character.CurrentBuild.Powers.Count)
                {
                    this.HidePopup();
                }
                else
                {
                    Point e1 = new Point(e.X, e.Y);
                    this.ShowPopup(index, -1, sIDX, e1, new Rectangle(), (I9Slot)null, -1);
                    if (MidsContext.Character.CanPlaceSlot & MainModule.MidsController.Toon.SlotCheck(MidsContext.Character.CurrentBuild.Powers[index]) > -1)
                    {
                        this.drawing.HighlightSlot(index, false);
                        if (index > -1 & this.drawing.InterfaceMode != Enums.eInterfaceMode.PowerToggle)
                            this.pnlGFX.Cursor = Cursors.Hand;
                        else
                            this.pnlGFX.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.pnlGFX.Cursor = Cursors.Default;
                        this.drawing.HighlightSlot(-1, false);
                    }
                    if (index > -1 && index != this.LastIndex | this.LastEnhIndex != sIDX)
                    {
                        this.LastIndex = index;
                        this.LastEnhIndex = sIDX;
                        if (sIDX > -1)
                            this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, MidsContext.Character.CurrentBuild.Powers[index].Slots[sIDX].Enhancement, MidsContext.Character.CurrentBuild.Powers[index].Slots[sIDX].Level);
                        else
                            this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, new I9Slot(), -1);
                    }
                }
            }
        }

        void pnlGFX_MouseUp(object sender, MouseEventArgs e)
        {
            this.pnlGFX.AllowDrop = false;
            if (this.DoneDblClick)
            {
                this.DoneDblClick = false;
            }
            else
            {
                int index1 = this.drawing.WhichSlot(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                int index2 = this.drawing.WhichEnh(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                if (!(index1 < 0 | index1 >= MidsContext.Character.CurrentBuild.Powers.Count))
                {
                    bool flag = MidsContext.Character.CurrentBuild.Powers[index1].NIDPower < 0;
                    if (!(e.Button == MouseButtons.Left & Control.ModifierKeys == (System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control)) || !this.EditAccoladesOrTemps(index1))
                    {
                        if (this.drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & e.Button == MouseButtons.Left)
                        {
                            if (!flag && MidsContext.Character.CurrentBuild.Powers[index1].CanIncludeForStats())
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[index1].StatInclude)
                                {
                                    MidsContext.Character.CurrentBuild.Powers[index1].StatInclude = false;
                                }
                                else
                                {
                                    Enums.eMutex eMutex = MainModule.MidsController.Toon.CurrentBuild.MutexV2(index1, false, false);
                                    if (eMutex == Enums.eMutex.NoConflict | eMutex == Enums.eMutex.NoGroup)
                                        MidsContext.Character.CurrentBuild.Powers[index1].StatInclude = true;
                                }
                            }
                            this.EnhancementModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (this.ToggleClicked(index1, this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y)) & e.Button == MouseButtons.Left)
                        {
                            if (!flag && MidsContext.Character.CurrentBuild.Powers[index1].CanIncludeForStats())
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[index1].StatInclude)
                                {
                                    MidsContext.Character.CurrentBuild.Powers[index1].StatInclude = false;
                                }
                                else
                                {
                                    Enums.eMutex eMutex = MainModule.MidsController.Toon.CurrentBuild.MutexV2(index1, false, false);
                                    if (eMutex == Enums.eMutex.NoConflict | eMutex == Enums.eMutex.NoGroup)
                                        MidsContext.Character.CurrentBuild.Powers[index1].StatInclude = true;
                                }
                                MidsContext.Character.Validate();
                            }
                            this.EnhancementModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (e.Button == MouseButtons.Left & Control.ModifierKeys == System.Windows.Forms.Keys.Alt)
                        {
                            MainModule.MidsController.Toon.BuildPower(MidsContext.Character.CurrentBuild.Powers[index1].NIDPowerset, MidsContext.Character.CurrentBuild.Powers[index1].NIDPower, false);
                            this.PowerModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (e.Button == MouseButtons.Left & Control.ModifierKeys == System.Windows.Forms.Keys.Shift & index2 > -1)
                        {
                            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                            {
                                MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Level;
                                MidsContext.Character.ResetLevel();
                            }
                            MainModule.MidsController.Toon.BuildSlot(index1, index2);
                            this.PowerModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else
                        {
                            if (e.Button == MouseButtons.Left & !this.EnhPickerActive)
                            {
                                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic & flag)
                                {
                                    if (flag & MidsContext.Character.CurrentBuild.Powers[index1].Level > -1)
                                    {
                                        MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index1].Level;
                                        this.UpdatePowerLists();
                                        this.DoRedraw();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MainModule.MidsController.Toon.BuildSlot(index1, -1) > -1)
                                    {
                                        this.PowerModified();
                                        this.LastClickPlacedSlot = true;
                                        MidsContext.Config.Tips.Show(Tips.TipType.FirstEnh);
                                        return;
                                    }
                                    this.LastClickPlacedSlot = false;
                                }
                            }
                            if (e.Button == MouseButtons.Middle & index2 > -1 & MidsContext.Config.ReapeatOnMiddleClick)
                            {
                                this.EnhancingSlot = index2;
                                this.EnhancingPower = index1;
                                this.I9Picker_EnhancementPicked(this.GetRepeatEnhancement(index1, index2));
                                this.EnhancementModified();
                            }
                            else if (e.Button == MouseButtons.Right & index2 > -1 && Control.ModifierKeys != System.Windows.Forms.Keys.Shift)
                            {
                                Point point = new Point();
                                this.EnhancingSlot = index2;
                                this.EnhancingPower = index1;
                                int[] enhancements = MainModule.MidsController.Toon.GetEnhancements(index1);
                                this.PickerHID = index1;
                                if (!flag)
                                    this.I9Picker.SetData(MidsContext.Character.CurrentBuild.Powers[index1].NIDPower, ref MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement, ref this.drawing, enhancements);
                                else
                                    this.I9Picker.SetData(-1, ref MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement, ref this.drawing, enhancements);
                                point = new Point((int)Math.Round((double)(this.pnlGFXFlow.Left - this.pnlGFXFlow.HorizontalScroll.Value + e.X) - (double)this.I9Picker.Width / 2.0), (int)Math.Round((double)(this.pnlGFXFlow.Top - this.pnlGFXFlow.VerticalScroll.Value + e.Y) - (double)this.I9Picker.Height / 2.0));
                                if (point.Y < this.MenuBar.Height)
                                    point.Y = this.MenuBar.Height;
                                Size clientSize;
                                if (point.Y + this.I9Picker.Height > this.ClientSize.Height)
                                {
                                    ref Point local = ref point;
                                    clientSize = this.ClientSize;
                                    int num = clientSize.Height - this.I9Picker.Height;
                                    local.Y = num;
                                }
                                int num1 = point.X + this.I9Picker.Width;
                                clientSize = this.ClientSize;
                                int width = clientSize.Width;
                                if (num1 > width)
                                {
                                    ref Point local = ref point;
                                    clientSize = this.ClientSize;
                                    int num2 = clientSize.Width - this.I9Picker.Width;
                                    local.X = num2;
                                }
                                this.I9Picker.Location = point;
                                this.I9Picker.BringToFront();
                                this.I9Picker.Visible = true;
                                this.I9Picker.Select();
                                this.LastClickPlacedSlot = false;
                            }
                            else if (e.Button == MouseButtons.Right & Control.ModifierKeys == System.Windows.Forms.Keys.Shift)
                                this.StartFlip(index1);
                            else if (e.Button == MouseButtons.Right)
                            {
                                this.Info_Power(MidsContext.Character.CurrentBuild.Powers[index1].NIDPower, -1, true, true);
                                this.LastClickPlacedSlot = false;
                            }
                        }
                    }
                }
            }
        }

        void pnlGFXFlow_MouseEnter(object sender, EventArgs e)
        {
            this.pnlGFXFlow.Focus();
        }

        internal void PowerModified()
        {
            int index = -1;
            MainModule.MidsController.Toon.Complete = false;
            this.fixStatIncludes();
            this.FileModified = true;
            if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
            {
                index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(MainModule.MidsController.Toon.RequestedLevel);
                if (index < 0)
                    index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(0);
            }
            else if (DatabaseAPI.Database.Levels[MidsContext.Character.Level].LevelType() == Enums.dmItem.Power)
            {
                index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(0);
                this.drawing.HighlightSlot(-1, false);
            }
            if (MainModule.MidsController.Toon.Complete)
                this.drawing.HighlightSlot(-1, false);
            int[] slotCounts = MainModule.MidsController.Toon.GetSlotCounts();
            this.ibAccolade.TextOff = slotCounts[0] <= 0 ? "No slots left" : Conversions.ToString(slotCounts[0]) + " slots to go";
            this.ibAccolade.TextOn = slotCounts[1] <= 0 ? "No slots placed" : Conversions.ToString(slotCounts[1]) + " slots placed";
            if (index > -1 & index <= MidsContext.Character.CurrentBuild.Powers.Count)
                MidsContext.Character.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Level;
            MidsContext.Character.Validate();
            this.DoRedraw();
            Application.DoEvents();
            this.UpdateControls(false);
            this.RefreshInfo();
            this.UpdateDynamicModeInfo();
            this.pbDynMode.Refresh();
        }

        int PowerMove(PowerEntry[] tp, params int[] pow)
        {
            if (tp[pow[0]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 > tp[pow[1]].Level)
            {
                if (this.ddsa[0] == (short)0)
                {
                    if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", "Allow power to be moved anyway (mark as invalid)");
                        this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (this.ddsa[0] == (short)2)
                            this.ddsa[0] = (short)3;
                    }
                    else
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", "Move/swap power to its lowest possible level", "Allow power to be moved anyway (mark as invalid)");
                        this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    }
                    if (MyProject.Forms.frmOptionListDlg.remember == true)
                        MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
                }
                if (this.ddsa[0] == (short)1)
                    return 0;
                if (this.ddsa[0] == (short)2)
                {
                    if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                    {
                        int num = (int)Interaction.MsgBox((object)"You have chosen to always swap a power with its minimum level when attempting to move it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", MsgBoxStyle.OkOnly, (object)null);
                        return 0;
                    }
                    int num1 = DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1;
                    int index = 0;
                    while (tp[index].Level != num1)
                    {
                        ++index;
                        if (index > 23)
                            return this.PowerMove(tp, pow[0], num1);
                    }
                }
                else if (this.ddsa[0] != (short)3)
                    ;
            }
            bool flag1 = pow[0] < pow[1];
            bool[] flagArray = new bool[tp.Length - 1 + 1];
            if (flag1)
            {
                flagArray[pow[0]] = true;
                int level = tp[pow[0]].Level;
                int num = pow[1];
                for (int index = pow[0] + 1; index <= num; ++index)
                {
                    if (tp[index].NIDPower < 0)
                    {
                        flagArray[index] = true;
                        level = tp[index].Level;
                    }
                    else if (DatabaseAPI.Database.Power[tp[index].NIDPower].Level - 1 == tp[index].Level)
                        flagArray[index] = false;
                    else if (level >= DatabaseAPI.Database.Power[tp[index].NIDPower].Level - 1)
                    {
                        flagArray[index] = true;
                        level = tp[index].Level;
                    }
                    else
                        flagArray[index] = false;
                }
            }
            if (flag1 & !flagArray[pow[1]])
            {
                if (this.ddsa[1] == (short)0)
                {
                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved too high (some powers will no longer fit)", "Move to the last power slot that can be shifted");
                    this.ddsa[1] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    if (MyProject.Forms.frmOptionListDlg.remember == true)
                        MidsContext.Config.DragDropScenarioAction[1] = this.ddsa[1];
                }
                if (this.ddsa[1] == (short)1)
                    return 0;
                if (this.ddsa[1] == (short)2)
                {
                    int num1 = pow[0] + 1;
                    int index;
                    for (index = pow[1]; index >= num1; index += -1)
                    {
                        if (flagArray[index])
                        {
                            pow[1] = index;
                            break;
                        }
                    }
                    if (pow[1] != index)
                    {
                        int num2 = (int)Interaction.MsgBox((object)"None of the powers can be shifted, so the power was not moved.", MsgBoxStyle.OkOnly, (object)null);
                        return 0;
                    }
                }
            }
            PowerEntry powerEntry = tp[pow[0]].NIDPower != -1 ? new PowerEntry(DatabaseAPI.Database.Power[tp[pow[0]].NIDPower]) : new PowerEntry(-1, (IPower)null, false);
            powerEntry.Slots = (SlotEntry[])tp[pow[0]].Slots.Clone();
            powerEntry.Level = tp[pow[0]].Level;
            this.clearPower(tp, pow[0]);
            bool flag2 = false;
            int num3;
            int num4;
            int num5;
            if (flag1)
            {
                num3 = pow[1];
                num4 = pow[0] + 1;
                num5 = -1;
            }
            else
            {
                num3 = pow[0] + 1;
                num4 = pow[1];
                num5 = 1;
            }
            int num6 = num4;
            int num7 = num5;
            for (int index = num3; (num7 >> 31 ^ index) <= (num7 >> 31 ^ num6); index += num7)
            {
                if (tp[index].NIDPower != -1 && flag1 && !flagArray[index])
                {
                    if (this.ddsa[7] == (short)0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being shifted down cannot shift to the necessary level", "Shift other powers around it", "Overwrite it; leave previous power slot empty", "Allow anyway (mark as invalid)");
                        this.ddsa[7] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.remember == true)
                            MidsContext.Config.DragDropScenarioAction[7] = this.ddsa[7];
                    }
                    if (this.ddsa[7] == (short)1)
                        return 0;
                    if (this.ddsa[7] == (short)3)
                    {
                        if (!flag2)
                        {
                            pow[0] = index;
                            break;
                        }
                        break;
                    }
                }
                if (!flag2 & tp[index].NIDPower < 0)
                {
                    if (this.ddsa[10] == (short)0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "There is a gap in a group of powers that are being shifted", "Fill empty slot; don't move powers unnecessarily", "Shift empty slot as if it were a power");
                        this.ddsa[10] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.remember == true)
                            MidsContext.Config.DragDropScenarioAction[10] = this.ddsa[10];
                    }
                    if (this.ddsa[10] == (short)1)
                        return 0;
                    if (this.ddsa[10] == (short)2)
                    {
                        if (tp[pow[1]].NIDPower < 0)
                        {
                            powerEntry.Level = tp[pow[0]].Level;
                            tp[pow[0]] = powerEntry;
                            return this.PowerSwap(1, ref tp, pow[0], pow[1]) == 0 ? 0 : -1;
                        }
                        pow[0] = index;
                    }
                    flag2 = true;
                }
            }
            int index1 = pow[0];
            int num8 = !flag1 ? index1 - 1 : index1 + 1;
            while (num8 != pow[1])
            {
                switch (this.PowerSwap(2, ref tp, index1, num8))
                {
                    case -1:
                        index1 = num8;
                        if (flag1)
                        {
                            ++num8;
                            break;
                        }
                        --num8;
                        break;
                    case 0:
                        int num9 = (int)Interaction.MsgBox((object)"Move canceled by user. If you didn't click Cancel, check that none of your Shift options are set to Cancel by default.", MsgBoxStyle.OkOnly, (object)null);
                        return 0;
                    case 1:
                        if (flag1)
                        {
                            ++num8;
                            break;
                        }
                        --num8;
                        break;
                    case 2:
                        this.PowerMoveByUser(this.dragStartPower, this.dragFinishPower);
                        return 0;
                }
            }
            powerEntry.Level = tp[index1].Level;
            tp[index1] = powerEntry;
            int num10;
            switch (this.PowerSwap(1, ref tp, index1, num8))
            {
                case 0:
                    num10 = 0;
                    break;
                case 3:
                    this.PowerSwapByUser(this.dragStartPower, this.dragFinishPower);
                    num10 = 0;
                    break;
                default:
                    num10 = -1;
                    break;
            }
            return num10;
        }

        void PowerMoveByUser(params int[] pow)
        {
            if (pow[0] < 0 | pow[0] > 23 | pow[1] < 0 | pow[1] > 23 | pow[0] == pow[1])
                return;
            int index = 0;
            do
            {
                this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
            PowerEntry[] powerEntryArray = frmMain.DeepCopyPowerList();
            if (this.PowerMove(powerEntryArray, pow) != 0)
            {
                this.ShallowCopyPowerList(powerEntryArray);
                this.PowerModified();
                this.DoRedraw();
            }
        }

        void PowerPicked(Enums.PowersetType SetID, int nIDPower)
        {
            MainModule.MidsController.Toon.BuildPower(MidsContext.Character.Powersets[(int)SetID].nID, nIDPower, false);
            this.PowerModified();
            MidsContext.Config.Tips.Show(Tips.TipType.FirstPower);
        }

        void PowerPicked(int nIDPowerset, int nIDPower)
        {
            MainModule.MidsController.Toon.BuildPower(nIDPowerset, nIDPower, false);
            this.PowerModified();
            MidsContext.Config.Tips.Show(Tips.TipType.FirstPower);
            this.DoRedraw();
        }

        int PowerSwap(int mode, ref PowerEntry[] tp, params int[] pow)
        {
            int num1;
            if (pow[0] < 0 | pow[0] > 23 | pow[1] < 0 | pow[1] > 23 | pow[0] == pow[1])
            {
                num1 = 0;
            }
            else
            {
                if (tp[pow[0]].NIDPower == -1 || DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 <= tp[pow[1]].Level)
                {
                    if (tp[pow[1]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[1]].NIDPower].Level - 1 > tp[pow[0]].Level)
                    {
                        int num2;
                        switch (mode)
                        {
                            case 0:
                                if (this.ddsa[4] == (short)0)
                                {
                                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being replaced is swapped too low", "Overwrite rather than swap", "Allow power to be swapped anyway (mark as invalid)");
                                    this.ddsa[4] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                    if (MyProject.Forms.frmOptionListDlg.remember == true)
                                        MidsContext.Config.DragDropScenarioAction[4] = this.ddsa[4];
                                }
                                if (this.ddsa[4] == (short)1)
                                    return 0;
                                if (this.ddsa[4] == (short)2)
                                {
                                    tp[pow[1]].NIDPower = -1;
                                    tp[pow[1]].NIDPowerset = -1;
                                    tp[pow[1]].IDXPower = -1;
                                    tp[pow[1]].StatInclude = false;
                                    tp[pow[1]].VariableValue = 0;
                                    tp[pow[1]].Slots = new SlotEntry[0];
                                    goto label_18;
                                }
                                else if (this.ddsa[4] != (short)3)
                                    goto label_18;
                                else
                                    goto label_18;
                            case 2:
                                num2 = this.ddsa[7] != (short)2 ? 1 : 0;
                                break;
                            default:
                                num2 = 1;
                                break;
                        }
                        if (num2 == 0)
                            return 1;
                        label_18:;
                    }
                }
                else if (mode == 0)
                {
                    if (this.ddsa[0] == (short)0)
                    {
                        if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", "Allow power to be moved anyway (mark as invalid)");
                            this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                            if (this.ddsa[0] == (short)2)
                                this.ddsa[0] = (short)3;
                        }
                        else
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", "Move/swap power to its lowest possible level", "Allow power to be moved anyway (mark as invalid)");
                            this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        }
                        if (MyProject.Forms.frmOptionListDlg.remember == true)
                            MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
                    }
                    if (this.ddsa[0] == (short)1)
                        return 0;
                    if (this.ddsa[0] == (short)2)
                    {
                        if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                        {
                            int num2 = (int)Interaction.MsgBox((object)"You have chosen to always swap a power with its minimum level when attempting to swap it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", MsgBoxStyle.OkOnly, (object)null);
                            return 0;
                        }
                        int num3 = DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1;
                        int index = 0;
                        while (tp[index].Level != num3)
                        {
                            ++index;
                            if (index > 23)
                                return this.PowerSwap(mode, ref tp, pow[0], num3);
                        }
                        int num4 = index;
                        return this.PowerSwap(mode, ref tp, pow[0], num4);
                    }
                    if (this.ddsa[0] != (short)3)
                        ;
                }
                if (mode == 1 | mode == 2 && tp[pow[1]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[1]].NIDPower].Level - 1 == tp[pow[1]].Level)
                {
                    if (mode == 1)
                    {
                        if (this.ddsa[12] == (short)0)
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "The power in the destination slot is prevented from being shifted up", "Unlock and shift all level-locked powers", "Shift destination power to the first valid and empty slot", "Swap instead of move");
                            this.ddsa[12] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                            if (MyProject.Forms.frmOptionListDlg.remember == true)
                                MidsContext.Config.DragDropScenarioAction[12] = this.ddsa[12];
                        }
                        if (this.ddsa[12] == (short)1)
                            return 0;
                        if (this.ddsa[12] == (short)2)
                        {
                            this.ddsa[11] = (short)2;
                            return 2;
                        }
                        if (this.ddsa[12] != (short)3 && this.ddsa[12] == (short)4)
                            return 3;
                    }
                    else if (mode == 2)
                    {
                        if (this.ddsa[11] == (short)0)
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "A power placed at its minimum level is being shifted up", "Shift it along with the other powers", "Shift other powers around it");
                            this.ddsa[11] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                            if (MyProject.Forms.frmOptionListDlg.remember == true)
                                MidsContext.Config.DragDropScenarioAction[11] = this.ddsa[11];
                        }
                        if (this.ddsa[11] == (short)1)
                            return 0;
                        if (this.ddsa[11] != (short)2 && this.ddsa[11] == (short)3)
                            return 1;
                    }
                }
                int num5 = tp[22].SlotCount + tp[23].SlotCount;
                int num6 = -1;
                if (pow[0] == 22 & pow[1] < 22 & num5 <= 8 & tp[pow[1]].SlotCount + tp[23].SlotCount > 8 | pow[0] == 23 & pow[1] < 22 & tp[pow[0]].SlotCount <= 4 & tp[pow[1]].SlotCount > 4 | pow[0] == 23 & pow[1] < 22 & num5 <= 8 & tp[22].SlotCount + tp[pow[1]].SlotCount > 8 | pow[0] == 23 & pow[1] == 22 & tp[pow[1]].SlotCount > 4)
                {
                    if (mode < 2 & this.ddsa[6] == (short)0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being replaced is swapped too high to have # slots", "Remove impossible slots", "Allow anyway (Mark slots as invalid)");
                        this.ddsa[6] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.remember == true)
                            MidsContext.Config.DragDropScenarioAction[6] = this.ddsa[6];
                    }
                    num6 = 6;
                }
                else if (pow[0] < 22 & pow[1] == 22 & num5 <= 8 & tp[pow[0]].SlotCount + tp[23].SlotCount > 8 | pow[0] < 22 & pow[1] == 23 & tp[pow[1]].SlotCount <= 4 & tp[pow[0]].SlotCount > 4 | pow[0] < 22 & pow[1] == 23 & num5 <= 8 & tp[22].SlotCount + tp[pow[0]].SlotCount > 8 | pow[0] == 22 & pow[1] == 23 & tp[pow[0]].SlotCount > 4)
                {
                    if (mode < 2 & this.ddsa[3] == (short)0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too high to have # slots", "Remove impossible slots", "Allow anyway (Mark slots as invalid)");
                        this.ddsa[3] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.remember == true)
                            MidsContext.Config.DragDropScenarioAction[3] = this.ddsa[3];
                    }
                    num6 = 3;
                }
                if (num6 != -1 && mode == 2)
                {
                    if (this.ddsa[9] == (short)0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being shifted up has impossible # of slots", "Remove impossible slots", "Allow anyway (Mark slots as invalid)");
                        this.ddsa[9] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.remember == true)
                            MidsContext.Config.DragDropScenarioAction[9] = this.ddsa[9];
                    }
                    num6 = 9;
                }
                if (((num6 != 6 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[6] == (short)1 ? 1 : 0)) != 0 || ((num6 != 3 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[3] == (short)1 ? 1 : 0)) != 0 || num6 == 9 && this.ddsa[9] == (short)1)
                {
                    num1 = 0;
                }
                else
                {
                    if (((num6 != 6 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[6] == (short)2 ? 1 : 0)) != 0 || ((num6 != 3 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[3] == (short)2 ? 1 : 0)) != 0 || num6 == 9 && this.ddsa[9] == (short)2)
                    {
                        int index;
                        int num2;
                        if (pow[0] > pow[1])
                        {
                            index = pow[1];
                            num2 = pow[0];
                        }
                        else
                        {
                            index = pow[0];
                            num2 = pow[1];
                        }
                        int integer1 = Conversions.ToInteger(Interaction.IIf(num2 == 22, (object)index, RuntimeHelpers.GetObjectValue(Interaction.IIf(index == 22, (object)num2, (object)22))));
                        int integer2 = Conversions.ToInteger(Interaction.IIf(num2 == 23, (object)index, (object)23));
                        while (tp[integer1].SlotCount + tp[integer2].SlotCount > 8 | tp[index].SlotCount > 4 & integer2 != 23)
                            tp[index].Slots = (SlotEntry[])Utils.CopyArray((Array)tp[index].Slots, (Array)new SlotEntry[tp[index].SlotCount - 2 + 1]);
                    }
                    else if (((num6 != 6 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[6] == (short)3 ? 1 : 0)) != 0 || ((num6 != 3 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[3] == (short)3 ? 1 : 0)) != 0 || num6 == 9 && this.ddsa[9] == (short)3)
                    {
                        int index1 = pow[0] <= pow[1] ? pow[0] : pow[1];
                        if (pow[0] == 23 | pow[1] == 23)
                        {
                            for (int index2 = tp[index1].SlotCount - 1; index2 >= 1; index2 += -1)
                            {
                                if (index2 + tp[22].SlotCount > 7 | index2 > 3)
                                    tp[index1].Slots[index2].Level = 50;
                            }
                        }
                        else
                        {
                            for (int index2 = tp[index1].SlotCount - 1; index2 >= 1; index2 += -1)
                            {
                                if (index2 + tp[22].SlotCount > 7)
                                    tp[index1].Slots[index2].Level = 50;
                            }
                        }
                    }
                    PowerEntry powerEntry = tp[pow[0]];
                    tp[pow[0]] = tp[pow[1]];
                    tp[pow[1]] = powerEntry;
                    int level1 = tp[pow[0]].Level;
                    tp[pow[0]].Level = tp[pow[1]].Level;
                    tp[pow[1]].Level = level1;
                    int num3 = pow[0];
                    pow[0] = pow[1];
                    pow[1] = num3;
                    int index3 = 0;
                    do
                    {
                        if (tp[pow[index3]].SlotCount > 0)
                        {
                            tp[pow[index3]].Slots[0].Level = tp[pow[index3]].Level;
                            int num2 = tp[pow[index3]].SlotCount - 1;
                            int slotIDX = 1;
                            while (true)
                            {
                                if (slotIDX <= num2 && slotIDX <= tp[pow[index3]].SlotCount - 1)
                                {
                                    if (tp[pow[index3]].Slots[slotIDX].Level < tp[pow[index3]].Level)
                                    {
                                        if (mode < 2 & index3 == 0 & this.ddsa[2] == (short)0)
                                        {
                                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power is moved or swapped higher than slots' levels", "Remove slots", "Mark invalid slots", "Swap slot levels if valid; remove invalid ones", "Swap slot levels if valid; mark invalid ones", "Rearrange all slots in build");
                                            this.ddsa[2] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                            if (MyProject.Forms.frmOptionListDlg.remember == true)
                                                MidsContext.Config.DragDropScenarioAction[2] = this.ddsa[2];
                                        }
                                        else if (mode == 0 & index3 == 1 & this.ddsa[5] == (short)0)
                                        {
                                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power being replaced is swapped higher than slots' levels", "Remove slots", "Mark invalid slots", "Swap slot levels if valid; remove invalid ones", "Swap slot levels if valid; mark invalid ones", "Rearrange all slots in build");
                                            this.ddsa[5] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                            if (MyProject.Forms.frmOptionListDlg.remember == true)
                                                MidsContext.Config.DragDropScenarioAction[5] = this.ddsa[5];
                                        }
                                        else if (mode == 2 & this.ddsa[8] == (short)0)
                                        {
                                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power being shifted up has slots from lower levels", "Remove slots", "Mark invalid slots", "Swap slot levels if valid; remove invalid ones", "Swap slot levels if valid; mark invalid ones", "Rearrange all slots in build");
                                            this.ddsa[8] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                            if (MyProject.Forms.frmOptionListDlg.remember == true)
                                                MidsContext.Config.DragDropScenarioAction[8] = this.ddsa[8];
                                        }
                                        if (!(mode < 2 & index3 == 0 & this.ddsa[2] == (short)1 | mode == 0 & index3 == 1 & this.ddsa[5] == (short)1 | mode == 2 & this.ddsa[8] == (short)1))
                                        {
                                            if (mode < 2 & index3 == 0 & this.ddsa[2] == (short)2 | mode == 0 & index3 == 1 & this.ddsa[5] == (short)2 | mode == 2 & this.ddsa[8] == (short)2)
                                            {
                                                this.RemoveSlotFromTempList(tp[pow[index3]], slotIDX);
                                                --slotIDX;
                                            }
                                            else if (mode < 2 & index3 == 0 & this.ddsa[2] == (short)4 | mode == 0 & index3 == 1 & this.ddsa[5] == (short)4 | mode == 2 & this.ddsa[8] == (short)4)
                                            {
                                                if (tp[pow[1 - index3]].SlotCount > slotIDX)
                                                {
                                                    int level2 = tp[pow[1 - index3]].Slots[slotIDX].Level;
                                                    tp[pow[1 - index3]].Slots[slotIDX].Level = tp[pow[index3]].Slots[slotIDX].Level;
                                                    tp[pow[index3]].Slots[slotIDX].Level = level2;
                                                }
                                                else
                                                {
                                                    this.RemoveSlotFromTempList(tp[pow[index3]], slotIDX);
                                                    --slotIDX;
                                                }
                                            }
                                            else if (mode < 2 & index3 == 0 & this.ddsa[2] == (short)5 | mode == 0 & index3 == 1 & this.ddsa[5] == (short)5 | mode == 2 & this.ddsa[8] == (short)5)
                                            {
                                                if (tp[pow[1 - index3]].SlotCount > slotIDX)
                                                {
                                                    int level2 = tp[pow[1 - index3]].Slots[slotIDX].Level;
                                                    tp[pow[1 - index3]].Slots[slotIDX].Level = tp[pow[index3]].Slots[slotIDX].Level;
                                                    tp[pow[index3]].Slots[slotIDX].Level = level2;
                                                }
                                            }
                                            else if (mode < 2 & index3 == 0 & this.ddsa[2] == (short)6 | mode == 0 & index3 == 1 & this.ddsa[5] == (short)6 | mode == 2 & this.ddsa[8] == (short)6)
                                                this.RearrangeAllSlotsInBuild(tp, true);
                                        }
                                        else
                                            goto label_132;
                                    }
                                    ++slotIDX;
                                }
                                else
                                    break;
                            }
                        }
                        ++index3;
                    }
                    while (index3 <= 1);
                    goto label_133;
                label_132:
                    return 0;
                label_133:
                    num1 = -1;
                }
            }
            return num1;
        }

        void PowerSwapByUser(params int[] pow)
        {
            int index = 0;
            do
            {
                this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
            PowerEntry[] tp = frmMain.DeepCopyPowerList();
            if (this.PowerSwap(0, ref tp, pow) != -1)
                return;
            this.ShallowCopyPowerList(tp);
            this.PowerModified();
            this.DoRedraw();
        }

        void PriSec_ExpandChanged(bool Expanded)
        {
            if (this.llPrimary.isExpanded | this.llSecondary.isExpanded & this.dvAnchored.IsDocked & !this.HasSentForwards)
            {
                this.llPrimary.BringToFront();
                this.llSecondary.BringToFront();
                this.HasSentBack = false;
                this.HasSentForwards = true;
            }
            else
            {
                if (!(this.llPrimary.Bounds.IntersectsWith(this.dvAnchored.Bounds) & !this.HasSentBack))
                    return;
                this.llPrimary.SendToBack();
                this.llSecondary.SendToBack();
                this.HasSentBack = true;
                this.HasSentForwards = false;
            }
        }

        Rectangle raGetPoolRect(int Index)
        {
            Label label;
            object Instance;
            switch (Index)
            {
                case 0:
                    label = this.lblPool1;
                    Instance = (object)this.llPool0;
                    break;
                case 1:
                    label = this.lblPool2;
                    Instance = (object)this.llPool1;
                    break;
                case 2:
                    label = this.lblPool3;
                    Instance = (object)this.llPool2;
                    break;
                case 3:
                    label = this.lblPool4;
                    Instance = (object)this.llPool3;
                    break;
                case 4:
                    label = this.lblEpic;
                    Instance = (object)this.llAncillary;
                    break;
                default:
                    return new Rectangle(0, 0, 10, 10);
            }
            return new Rectangle(label.Left, label.Top, Conversions.ToInteger(NewLateBinding.LateGet(Instance, (System.Type)null, "Width", new object[0], (string[])null, (System.Type[])null, (bool[])null)), Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(NewLateBinding.LateGet(Instance, (System.Type)null, "Top", new object[0], (string[])null, (System.Type[])null, (bool[])null), NewLateBinding.LateGet(Instance, (System.Type)null, "Height", new object[0], (string[])null, (System.Type[])null, (bool[])null)), (object)label.Top)));
        }

        int raGetTop()
        {
            return MainModule.MidsController.Toon != null ? 4 + this.llPrimary.Top + this.raGreater(this.llPrimary.Height, this.llSecondary.Height) : this.llPrimary.Top + this.llPrimary.Height;
        }

        int raGreater(int iVal1, int iVal2)
        {
            return iVal1 <= iVal2 ? iVal2 : iVal1;
        }

        void raMovePool(int Index, int X, int Y)
        {
            Label label1;
            ComboBox comboBox;
            Label label2;
            object Instance;
            switch (Index)
            {
                case 0:
                    label1 = this.lblPool1;
                    comboBox = this.cbPool0;
                    label2 = this.lblLocked0;
                    Instance = (object)this.llPool0;
                    break;
                case 1:
                    label1 = this.lblPool2;
                    comboBox = this.cbPool1;
                    label2 = this.lblLocked1;
                    Instance = (object)this.llPool1;
                    break;
                case 2:
                    label1 = this.lblPool3;
                    comboBox = this.cbPool2;
                    label2 = this.lblLocked2;
                    Instance = (object)this.llPool2;
                    break;
                case 3:
                    label1 = this.lblPool4;
                    comboBox = this.cbPool3;
                    label2 = this.lblLocked3;
                    Instance = (object)this.llPool3;
                    break;
                case 4:
                    label1 = this.lblEpic;
                    comboBox = this.cbAncillary;
                    label2 = this.lblLockedAncillary;
                    Instance = (object)this.llAncillary;
                    break;
                default:
                    return;
            }
            Point point = new Point(X, Y);
            label1.Location = point;
            point.Y += label1.Height;
            comboBox.Location = point;
            label2.Location = point;
            point.Y += comboBox.Height;
            NewLateBinding.LateSet(Instance, (System.Type)null, "Location", new object[1]
            {
        (object) point
            }, (string[])null, (System.Type[])null);
        }

        bool raToFloat()
        {
            bool flag = false;
            this.llPool0.Height = this.llPool0.DesiredHeight;
            this.llPool1.Height = this.llPool1.DesiredHeight;
            this.llPool2.Height = this.llPool2.DesiredHeight;
            this.llPool3.Height = this.llPool3.DesiredHeight;
            this.llAncillary.Height = this.llAncillary.DesiredHeight;
            Rectangle poolRect1 = this.raGetPoolRect(0);
            this.raMovePool(1, poolRect1.Left, poolRect1.Bottom);
            Rectangle poolRect2 = this.raGetPoolRect(1);
            this.raMovePool(2, poolRect2.Left, poolRect2.Bottom);
            this.FixPrimarySecondaryHeight();
            int num = this.raGreater(this.raGetTop(), this.lblPool3.Top);
            if (num + this.llAncillary.DesiredHeight > this.ClientSize.Height)
            {
                num = this.ClientSize.Height - this.llAncillary.DesiredHeight - this.cbAncillary.Height - this.lblEpic.Height;
                Size size = this.llPrimary.SizeNormal;
                this.llPrimary.SizeNormal = new Size(size.Width, num - 4 - this.llPrimary.Top);
                size = new Size(this.llSecondary.SizeNormal.Width, num - 4 - this.llPrimary.Top);
                this.llSecondary.SizeNormal = size;
            }
            Rectangle poolRect3 = this.raGetPoolRect(2);
            poolRect3.X = this.llPrimary.Left;
            poolRect3.Y = num;
            this.raMovePool(4, poolRect3.Left, poolRect3.Top);
            poolRect3.X = this.llSecondary.Left;
            this.raMovePool(3, poolRect3.Left, poolRect3.Top);
            return flag;
        }

        bool raToNormal()
        {
            bool flag = false;
            this.llPool0.SuspendRedraw = true;
            this.llPool1.SuspendRedraw = true;
            this.llPool2.SuspendRedraw = true;
            this.llPool3.SuspendRedraw = true;
            this.llAncillary.SuspendRedraw = true;
            this.llPool0.Height = this.llPool0.DesiredHeight;
            this.llPool1.Height = this.llPool1.DesiredHeight;
            this.llPool2.Height = this.llPool2.DesiredHeight;
            this.llPool3.Height = this.llPool3.DesiredHeight;
            this.llAncillary.Height = this.llAncillary.DesiredHeight;
            this.FixPrimarySecondaryHeight();
            int num1 = this.llPool0.Top + this.cbPool0.Height * 4 + this.lblPool1.Height * 4;
            int num2 = 3 * this.llAncillary.ActualLineHeight;
            if (num1 + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > this.ClientSize.Height)
            {
                int num3 = this.ClientSize.Height - num1 - this.llPool0.Height - this.llPool1.Height - this.llPool2.Height - this.llPool3.Height;
                if (num3 < num2)
                    num3 = num2;
                if (this.llAncillary.Height > num3)
                    this.llAncillary.Height = num3;
                if (num1 + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > this.ClientSize.Height)
                {
                    int num4 = this.ClientSize.Height - num1 - this.llPool0.Height - this.llPool1.Height - this.llPool2.Height - this.llAncillary.Height;
                    if (num4 < num2)
                        num4 = num2;
                    this.llPool3.Height = num4;
                    if (num1 + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > this.ClientSize.Height)
                    {
                        int num5 = this.ClientSize.Height - num1 - this.llPool0.Height - this.llPool1.Height - this.llPool3.Height - this.llAncillary.Height;
                        if (num5 < num2)
                            num5 = num2;
                        this.llPool2.Height = num5;
                        if (num1 + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > this.ClientSize.Height)
                        {
                            int num6 = this.ClientSize.Height - num1 - this.llPool0.Height - this.llPool2.Height - this.llPool3.Height - this.llAncillary.Height;
                            if (num6 < num2)
                                num6 = num2;
                            this.llPool1.Height = num6;
                            if (num1 + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > this.ClientSize.Height)
                            {
                                int num7 = this.ClientSize.Height - num1 - this.llPool1.Height - this.llPool2.Height - this.llPool3.Height - this.llAncillary.Height;
                                if (num7 < num2)
                                    num7 = num2;
                                this.llPool0.Height = num7;
                            }
                        }
                    }
                }
            }
            Rectangle poolRect = this.raGetPoolRect(0);
            this.raMovePool(1, poolRect.Left, poolRect.Bottom);
            poolRect = this.raGetPoolRect(1);
            this.raMovePool(2, poolRect.Left, poolRect.Bottom);
            poolRect = this.raGetPoolRect(2);
            this.raMovePool(3, poolRect.Left, poolRect.Bottom);
            poolRect = this.raGetPoolRect(3);
            this.raMovePool(4, poolRect.Left, poolRect.Bottom);
            this.llPool0.SuspendRedraw = false;
            this.llPool1.SuspendRedraw = false;
            this.llPool2.SuspendRedraw = false;
            this.llPool3.SuspendRedraw = false;
            this.llAncillary.SuspendRedraw = false;
            return flag;
        }

        bool ReArrange(bool Init)
        {
            bool flag1 = false;
            bool flag2;
            if (this.drawing == null)
            {
                flag2 = false;
            }
            else
            {
                bool flag3 = !this.dvAnchored.Visible;
                if (Init)
                {
                    flag2 = this.raToNormal();
                }
                else
                {
                    if (!flag3 & this.dvAnchored.Bounds.IntersectsWith(this.dvAnchored.SnapLocation))
                        this.raToNormal();
                    else
                        this.raToFloat();
                    this.SetAncilPoolHeight();
                    flag2 = flag1;
                }
            }
            return flag2;
        }

        void RearrangeAllSlotsInBuild(PowerEntry[] tp, bool notifyUser = false)
        {
            int index1 = 0;
            int[] numArray1 = new int[tp.Length - 1 + 1];
            int num1 = tp.Length - 1;
            for (int index2 = 0; index2 <= num1; ++index2)
            {
                if (tp[index2].NIDPower != -1 && DatabaseAPI.Database.Power[tp[index2].NIDPower].AllowFrontLoading)
                {
                    numArray1[index1] = index2;
                    ++index1;
                }
            }
            int index3 = index1;
            int num2 = tp.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
            {
                if (((tp[index2].NIDPower == -1 ? 0 : (!DatabaseAPI.Database.Power[tp[index2].NIDPower].AllowFrontLoading ? 1 : 0)) | (tp[index2].NIDPower == -1 ? 1 : 0)) != 0)
                {
                    bool flag = true;
                    int num3 = index2 - 1;
                    for (int index4 = index1; index4 <= num3; ++index4)
                    {
                        if (tp[index2].Level < tp[numArray1[index4]].Level)
                        {
                            int num4 = index4;
                            for (int index5 = index3 - 1; index5 >= num4; index5 += -1)
                                numArray1[index5 + 1] = numArray1[index5];
                            numArray1[index4] = index2;
                            ++index3;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        numArray1[index3] = index2;
                        ++index3;
                    }
                }
            }
            int[] numArray2 = this.fakeInitialize(3, 3, 5, 5, 7, 7, 9, 9, 11, 11, 13, 13, 15, 15, 17, 17, 19, 19, 21, 21, 23, 23, 25, 25, 27, 27, 29, 29, 31, 31, 31, 33, 33, 33, 34, 34, 34, 36, 36, 36, 37, 37, 37, 39, 39, 39, 40, 40, 40, 42, 42, 42, 43, 43, 43, 45, 45, 45, 46, 46, 46, 48, 48, 48, 50, 50, 50);
            bool flag1 = false;
            int index6 = 0;
            int num5 = tp.Length - 1;
            for (int index2 = 0; index2 <= num5; ++index2)
            {
                int num3 = tp[numArray1[index2]].SlotCount - 1;
                for (int index4 = 1; index4 <= num3; ++index4)
                {
                    if (index6 == numArray2.Length)
                        flag1 = true;
                    tp[numArray1[index2]].Slots[index4].Level = 50;
                    if (!flag1)
                    {
                        if (tp[numArray1[index2]].NIDPower == -1 || !DatabaseAPI.Database.Power[tp[numArray1[index2]].NIDPower].AllowFrontLoading)
                        {
                            while (numArray2[index6] <= tp[numArray1[index2]].Level)
                            {
                                ++index6;
                                if (index6 == numArray2.Length)
                                {
                                    flag1 = true;
                                    break;
                                }
                            }
                        }
                        tp[numArray1[index2]].Slots[index4].Level = numArray2[index6] - 1;
                        ++index6;
                    }
                }
            }
            if (!(flag1 & notifyUser))
                return;
            int num6 = (int)Interaction.MsgBox((object)"The current arrangement of powers and their slots is impossible in-game. Invalid slots have been darkened and marked as level 51.", MsgBoxStyle.OkOnly, (object)null);
        }

        void RedrawUnderPopup(Rectangle RectRedraw)
        {
            Rectangle Clip = RectRedraw;
            ref Rectangle local = ref Clip;
            Point location = this.pnlGFXFlow.Location;
            int x = -location.X;
            location = this.pnlGFXFlow.Location;
            int y = -location.Y;
            local.Offset(x, y);
            this.drawing.Refresh(Clip);
            if (this.llPrimary.Bounds.IntersectsWith(RectRedraw))
                this.llPrimary.Refresh();
            if (this.llSecondary.Bounds.IntersectsWith(RectRedraw))
                this.llSecondary.Refresh();
            if (this.raGetPoolRect(0).IntersectsWith(RectRedraw))
            {
                this.llPool0.Refresh();
                this.cbPool0.Refresh();
                this.lblPool1.Refresh();
                this.lblLocked0.Refresh();
            }
            if (this.raGetPoolRect(1).IntersectsWith(RectRedraw))
            {
                this.llPool1.Refresh();
                this.cbPool1.Refresh();
                this.lblPool2.Refresh();
                this.lblLocked1.Refresh();
            }
            if (this.raGetPoolRect(2).IntersectsWith(RectRedraw))
            {
                this.llPool2.Refresh();
                this.cbPool2.Refresh();
                this.lblPool3.Refresh();
                this.lblLocked2.Refresh();
            }
            if (this.raGetPoolRect(3).IntersectsWith(RectRedraw))
            {
                this.llPool3.Refresh();
                this.cbPool3.Refresh();
                this.lblPool4.Refresh();
                this.lblLocked3.Refresh();
            }
            if (!this.raGetPoolRect(4).IntersectsWith(RectRedraw))
                return;
            this.llAncillary.Refresh();
            this.cbAncillary.Refresh();
            this.lblEpic.Refresh();
            this.lblLockedAncillary.Refresh();
        }

        internal void RefreshInfo()
        {
            this.info_Totals();
            if (this.dvLastPower <= -1)
                return;
            this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
        }

        void RefreshTabs(int iPower, I9Slot iEnh, int iLevel = -1)
        {
            if (iEnh.Enh > -1)
            {
                this.Info_Power(iPower, iLevel, false, false);
                this.Info_Enhancement(iEnh, iLevel);
            }
            else
                this.Info_Power(iPower, iLevel, true, false);
        }

        void RemoveSlotFromTempList(PowerEntry tp, int slotIDX)
        {
            int num = tp.SlotCount - 2;
            for (int index = slotIDX; index <= num; ++index)
                tp.Slots[index] = tp.Slots[index + 1];
            tp.Slots = (SlotEntry[])Utils.CopyArray((Array)tp.Slots, (Array)new SlotEntry[tp.SlotCount - 2 + 1]);
        }

        void SetAncilPoolHeight()
        {
            int num1 = this.llAncillary.ActualLineHeight * 2;
            int num2 = 1;
            do
            {
                if (this.llAncillary.Top + num1 + this.llAncillary.ActualLineHeight <= this.ClientRectangle.Size.Height)
                    num1 += this.llAncillary.ActualLineHeight;
                ++num2;
            }
            while (num2 <= 4);
            if (num1 < this.llAncillary.ActualLineHeight * 2)
                num1 = this.llAncillary.ActualLineHeight * 2;
            this.llAncillary.Height = num1;
        }

        void setColumns(int columns)
        {
            MidsContext.Config.Columns = columns;
            this.drawing.Columns = columns;
            this.DoResize();
            this.DoRedraw();
            this.SetFormWidth(false);
            this.tsView4Col.Checked = columns == 4;
            this.tsView3Col.Checked = columns == 3;
            this.tsView2Col.Checked = columns == 2;
        }

        void SetDamageMenuCheckMarks()
        {
            switch (MidsContext.Config.DamageMath.ReturnValue)
            {
                case ConfigData.EDamageReturn.Numeric:
                    this.tsViewDPS_New.Checked = false;
                    this.tsViewActualDamage_New.Checked = true;
                    this.tlsDPA.Checked = false;
                    break;
                case ConfigData.EDamageReturn.DPS:
                    this.tsViewDPS_New.Checked = true;
                    this.tsViewActualDamage_New.Checked = false;
                    this.tlsDPA.Checked = false;
                    break;
                case ConfigData.EDamageReturn.DPA:
                    this.tsViewDPS_New.Checked = false;
                    this.tsViewActualDamage_New.Checked = false;
                    this.tlsDPA.Checked = true;
                    break;
            }
        }

        internal void SetDataViewTab(int index)
        {
            if (index == 2)
            {
                this.drawing.InterfaceMode = Enums.eInterfaceMode.PowerToggle;
                this.DoRedraw();
                MidsContext.Config.Tips.Show(Tips.TipType.TotalsTab);
            }
            else
            {
                if (this.drawing.InterfaceMode == Enums.eInterfaceMode.Normal)
                    return;
                this.drawing.InterfaceMode = Enums.eInterfaceMode.Normal;
                this.DoRedraw();
            }
        }

        void SetFormHeight(bool Force = false)
        {
            int iVal2 = 0;
            int num = this.Height - this.ClientSize.Height;
            int bottom = this.dvAnchored.SnapLocation.Bottom;
            if (!this.dvAnchored.Visible)
            {
                iVal2 = this.llPool3.Top + this.llPool3.Height * 2 + 4 + num;
            }
            else
            {
                switch (this.dvAnchored.VisibleSize)
                {
                    case Enums.eVisibleSize.Full:
                        iVal2 = this.raGreater(this.dvAnchored.SnapLocation.Bottom, this.llAncillary.Top + this.llAncillary.ActualLineHeight * this.llAncillary.Items.Length) + 4 + num;
                        break;
                    case Enums.eVisibleSize.Small:
                        return;
                    case Enums.eVisibleSize.VerySmall:
                        return;
                    case Enums.eVisibleSize.Compact:
                        switch (this.drawing.EpicColumns)
                        {
                            case false:
                                iVal2 = this.raGreater(bottom, this.llAncillary.Top + this.llAncillary.ActualLineHeight * this.llAncillary.Items.Length) + 4 + num;
                                break;
                            case true:
                                iVal2 = this.raGreater(bottom, iVal2) + 4 + num;
                                break;
                        }
                        return;
                    default:
                        return;
                }
            }
            if (iVal2 > this.Height | Force | this.dvAnchored.IsDocked)
            {
                if (Screen.PrimaryScreen.WorkingArea.Height > iVal2)
                    this.Height = iVal2;
                else if (Screen.PrimaryScreen.WorkingArea.Height < iVal2)
                    this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            this.NoResizeEvent = false;
        }

        void SetFormWidth(bool ToFull = false)
        {
            this.NoResizeEvent = true;
            int num1 = this.Width - this.ClientSize.Width;
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            int num2 = (MidsContext.Config.Columns != 2 ? num1 + this.drawing.GetRequiredDrawingArea().Width + this.pnlGFXFlow.Left : (!ToFull ? num1 + this.pnlGFXFlow.Left + this.drawing.ScaleDown(this.drawing.GetRequiredDrawingArea().Width) : num1 + this.drawing.GetRequiredDrawingArea().Width + this.pnlGFXFlow.Left)) + 8;
            if (Screen.PrimaryScreen.WorkingArea.Width > num2)
            {
                this.Width = num2;
            }
            else
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                if (workingArea.Width <= num2)
                {
                    workingArea = Screen.PrimaryScreen.WorkingArea;
                    this.Width = workingArea.Width - num1;
                }
            }
            this.NoResizeEvent = false;
            this.DoResize();
        }

        internal void SetMiniList(PopUp.PopupData iData, string iTitle, int bxHeight = 2048)
        {
            if (this.fMini == null)
                this.fMini = new frmMiniList(this);
            this.fMini.pInfo.BXHeight = bxHeight;
            this.fMini.SizeMe();
            this.fMini.Text = iTitle;
            this.fMini.pInfo.SetPopup(iData);
            this.fMini.Show();
            this.fMini.BringToFront();
        }

        void SetPopupLocation(Rectangle ObjectBounds, bool PowerListing = false, bool Picker = false)
        {
            int y = 0;
            int top = ObjectBounds.Top;
            int num1 = this.ClientSize.Height - ObjectBounds.Bottom;
            int left = ObjectBounds.Left;
            int num2 = this.ClientSize.Width - ObjectBounds.Right;
            Rectangle rectangle = new Rectangle(0, 0, 1, 1);
            if (this.dvAnchored.Visible)
            {
                rectangle.X = this.dvAnchored.Left;
                rectangle.Y = this.dvAnchored.Top;
                rectangle.Width = this.dvAnchored.Width;
                rectangle.Height = this.dvAnchored.Height;
            }
            int x = -1;
            Size clientSize;
            if (!PowerListing & !Picker)
            {
                if (num1 >= this.I9Popup.Height)
                    y = ObjectBounds.Bottom;
                else if (top >= this.I9Popup.Height)
                    y = ObjectBounds.Top - this.I9Popup.Height;
                else if (num2 >= this.I9Popup.Width)
                {
                    x = ObjectBounds.Right;
                    y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
                }
                else if (left >= this.I9Popup.Width)
                {
                    x = ObjectBounds.Left - this.I9Popup.Width;
                    y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
                }
                else
                    y = ObjectBounds.Bottom;
            }
            else if (Picker)
            {
                if (num2 >= this.I9Popup.Width)
                {
                    x = ObjectBounds.Right;
                    y = ObjectBounds.Top;
                }
                else if (left >= this.I9Popup.Width)
                {
                    x = ObjectBounds.Left - this.I9Popup.Width;
                    y = ObjectBounds.Top;
                }
                else
                    y = num1 < this.I9Popup.Height ? (top < this.I9Popup.Height ? ObjectBounds.Bottom : ObjectBounds.Top - this.I9Popup.Height) : ObjectBounds.Bottom;
            }
            else if (PowerListing)
            {
                y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
                if (y < 0)
                    y = 0;
                int num3 = y + this.I9Popup.Height;
                clientSize = this.ClientSize;
                int height = clientSize.Height;
                if (num3 > height)
                {
                    clientSize = this.ClientSize;
                    y = clientSize.Height - this.I9Popup.Height;
                }
                x = ObjectBounds.Right;
            }
            if (x < 0)
            {
                x = (int)Math.Round((double)ObjectBounds.Left + (double)ObjectBounds.Width / 2.0 - (double)this.I9Popup.Width / 2.0);
                if ((double)left < (double)(this.I9Popup.Width - ObjectBounds.Width) / 2.0)
                    x = left;
                else if ((double)num2 < (double)(this.I9Popup.Width - ObjectBounds.Width) / 2.0)
                {
                    clientSize = this.ClientSize;
                    x = clientSize.Width - this.I9Popup.Width;
                }
            }
            this.I9Popup.BringToFront();
            this.I9Popup.Location = new Point(x, y);
        }

        void SetTitleBar(bool Hero = true)
        {
            if (MainModule.MidsController.Toon != null)
                Hero = MainModule.MidsController.Toon.IsHero();
            string str1 = "";
            if (MainModule.MidsController.Toon != null)
            {
                if (this.LastFileName != "")
                {
                    str1 = FileIO.StripPath(this.LastFileName) + " - ";
                    this.tsFileSave.Text = "&Save '" + FileIO.StripPath(this.LastFileName) + "'";
                }
                else
                    this.tsFileSave.Text = "&Save";
            }
            else
                this.tsFileSave.Text = "&Save";
            string str2 = str1 + "Pine's Hero Designer";
            if (!Hero)
                str2 = str2.Replace(nameof(Hero), "Villain");
            if (MidsContext.Config.MasterMode)
            {
                this.Text = str2 + " (Master Mode) v" + Strings.Format((object)MainModule.MidsController.HeroDesignerVersion, "#0.0#######") + " (DB: I" + Conversions.ToString(DatabaseAPI.Database.Issue) + " - Updated: " + Strings.Format((object)DatabaseAPI.Database.Date, " dd / MMM / yyyy @ hh:mm tt") + ")";
            }
            else
            {
                string str3 = Strings.Format((object)MainModule.MidsController.HeroDesignerVersion, "#0.0#######");
                if (str3.Length > 5)
                    str3 = str3.Substring(0, 5);
                string str4 = str3.Trim("0".ToCharArray());
                this.Text = str2 + " v" + str4 + " (Database Issue: " + Conversions.ToString(DatabaseAPI.Database.Issue) + " - Updated: " + Strings.Format((object)DatabaseAPI.Database.Date, "dd/MM/yy") + ")";
            }
        }

        void ShallowCopyPowerList(PowerEntry[] source)
        {
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; ++index)
                MidsContext.Character.CurrentBuild.Powers[index] = source[index];
        }

        internal void ShowAnchoredDataView()
        {
            if (this.FloatingDataForm != null)
            {
                this.dvAnchored.VisibleSize = this.FloatingDataForm.dvFloat.VisibleSize;
                this.dvAnchored.TabPage = this.FloatingDataForm.dvFloat.TabPage;
            }
            this.myDataView = this.dvAnchored;
            this.myDataView.Init();
            this.myDataView.BackColor = this.BackColor;
            this.myDataView.DrawVillain = !MainModule.MidsController.Toon.IsHero();
            this.dvAnchored.Visible = true;
            this.NoResizeEvent = true;
            this.OnResizeEnd(new EventArgs());
            this.NoResizeEvent = false;
            this.RefreshInfo();
            this.ReArrange(false);
            this.FloatingDataForm = (frmFloatingStats)null;
        }

        void ShowPopup(int nIDPowerset, int nIDClass, Rectangle rBounds, string ExtraString = "")
        {
            if (!MidsContext.Config.ShowPopup)
            {
                this.HidePopup();
            }
            else
            {
                PopUp.PopupData popupData = new PopUp.PopupData();
                Rectangle bounds = this.I9Popup.Bounds;
                this.RedrawUnderPopup(bounds);
                if (nIDPowerset > -1 | nIDClass > -1)
                {
                    if (this.I9Popup.psIDX != (nIDPowerset <= -1 ? nIDClass : nIDPowerset))
                    {
                        PopUp.PopupData iPopup = nIDPowerset <= -1 ? MidsContext.Character.Archetype.PopInfo() : MainModule.MidsController.Toon.PopPowersetInfo(nIDPowerset, ExtraString);
                        if (true & iPopup.Sections != null)
                        {
                            this.I9Popup.SetPopup(iPopup);
                            this.PopUpVisible = true;
                            this.SetPopupLocation(rBounds, false, true);
                        }
                        else
                            this.HidePopup();
                        this.I9Popup.Visible = true;
                        if (this.ActivePopupBounds != this.I9Popup.Bounds)
                        {
                            this.RedrawUnderPopup(bounds);
                            this.ActivePopupBounds = this.I9Popup.Bounds;
                        }
                    }
                    this.I9Popup.hIDX = -1;
                    this.I9Popup.eIDX = -1;
                    this.I9Popup.pIDX = -1;
                    this.I9Popup.psIDX = nIDPowerset;
                }
            }
        }

        void ShowPopup(
          int hIDX,
          int pIDX,
          int sIDX,
          Point e,
          Rectangle rBounds,
          I9Slot eSlot = null,
          int setIDX = -1)
        {
            if (!MidsContext.Config.ShowPopup)
            {
                this.HidePopup();
            }
            else
            {
                bool flag = false;
                PopUp.PopupData iPopup = new PopUp.PopupData();
                bool Picker = false;
                bool PowerListing = false;
                Rectangle bounds = this.I9Popup.Bounds;
                if (hIDX < 0 & pIDX > -1)
                    hIDX = MidsContext.Character.CurrentBuild.FindInToonHistory(pIDX);
                PowerEntry powerEntry = (PowerEntry)null;
                if (hIDX > -1)
                    powerEntry = MidsContext.Character.CurrentBuild.Powers[hIDX];
                if (this.I9Popup.hIDX != hIDX | this.I9Popup.eIDX != sIDX | this.I9Popup.pIDX != pIDX | (this.I9Popup.hIDX == -1 | this.I9Popup.eIDX == -1 | this.I9Popup.pIDX == -1))
                {
                    Rectangle rectangle = new Rectangle();
                    if (hIDX > -1 & sIDX < 0 & pIDX < 0 & eSlot == null & setIDX < 0)
                    {
                        rectangle = this.drawing.PowerBoundsUnScaled(hIDX);
                        Point e1 = new Point(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                        if (this.drawing.WithinPowerBar(rectangle, e1))
                        {
                            if (powerEntry.NIDPower > 0)
                                iPopup = MainModule.MidsController.Toon.PopPowerInfo(hIDX, powerEntry.NIDPower);
                            flag = true;
                        }
                    }
                    else if (sIDX > -1)
                    {
                        rectangle = this.drawing.PowerBoundsUnScaled(hIDX);
                        iPopup = Character.PopEnhInfo(powerEntry.Slots[sIDX].Enhancement, powerEntry.Slots[sIDX].Level, powerEntry);
                        flag = true;
                    }
                    else if (pIDX > -1)
                    {
                        rectangle = rBounds;
                        iPopup = MainModule.MidsController.Toon.PopPowerInfo(hIDX, pIDX);
                        flag = true;
                        PowerListing = true;
                    }
                    else if (eSlot != null & setIDX < 0)
                    {
                        rectangle = rBounds;
                        iPopup = Character.PopEnhInfo(eSlot, -1, powerEntry);
                        flag = true;
                        Picker = true;
                    }
                    else if (setIDX > -1)
                    {
                        rectangle = rBounds;
                        iPopup = Character.PopSetInfo(setIDX, powerEntry);
                        flag = true;
                        Picker = true;
                    }
                    if (flag & iPopup.Sections != null)
                    {
                        if (this.I9Popup.hIDX != hIDX | this.I9Popup.eIDX != sIDX | this.I9Popup.pIDX != pIDX | (this.I9Popup.hIDX == -1 | this.I9Popup.eIDX == -1 | this.I9Popup.pIDX == -1))
                        {
                            if (!Picker & !PowerListing)
                            {
                                rectangle = this.Dilate(this.drawing.ScaleDown(rectangle), 2);
                                rectangle.X += this.pnlGFXFlow.Left - this.pnlGFXFlow.HorizontalScroll.Value;
                                rectangle.Y += this.pnlGFXFlow.Top - this.pnlGFXFlow.VerticalScroll.Value;
                            }
                            this.I9Popup.SetPopup(iPopup);
                            this.PopUpVisible = true;
                            this.SetPopupLocation(rectangle, PowerListing, Picker);
                        }
                        this.I9Popup.Visible = true;
                        if (this.ActivePopupBounds != this.I9Popup.Bounds)
                        {
                            this.RedrawUnderPopup(bounds);
                            this.ActivePopupBounds = this.I9Popup.Bounds;
                        }
                    }
                    else
                        this.HidePopup();
                    this.I9Popup.hIDX = hIDX;
                    this.I9Popup.eIDX = sIDX;
                    this.I9Popup.pIDX = pIDX;
                    this.I9Popup.psIDX = -1;
                }
            }
        }

        void SlotLevelSwap(int sourcePower, int sourceSlot, int destPower, int destSlot)
        {
            int index = 0;
            do
            {
                this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
            if (MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level < MidsContext.Character.CurrentBuild.Powers[destPower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[destPower].NIDPower].AllowFrontLoading)
            {
                if (this.ddsa[13] == (short)0)
                {
                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Slot being level-swapped is too low for the destination power", "Allow swap anyway (mark as invalid)");
                    this.ddsa[13] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    if (MyProject.Forms.frmOptionListDlg.remember == true)
                        MidsContext.Config.DragDropScenarioAction[13] = this.ddsa[13];
                }
                if (this.ddsa[13] == (short)1)
                    return;
            }
            if (MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level < MidsContext.Character.CurrentBuild.Powers[sourcePower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[sourcePower].NIDPower].AllowFrontLoading)
            {
                if (this.ddsa[14] == (short)0)
                {
                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Slot being level-swapped is too low for the source power", "Allow swap anyway (mark as invalid)");
                    this.ddsa[14] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    if (MyProject.Forms.frmOptionListDlg.remember == true)
                        MidsContext.Config.DragDropScenarioAction[14] = this.ddsa[14];
                }
                if (this.ddsa[14] == (short)1)
                    return;
            }
            int level = MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level;
            MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level = MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level;
            MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level = level;
            this.PowerModified();
            this.DoRedraw();
        }

        internal void smlRespecLong(int iLevel, bool Mode2)
        {
            if (Mode2)
                this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper2(true, iLevel), "Respec Helper", 5096);
            else
                this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper(true, iLevel), "Respec Helper", 4072);
            this.fMini.Width = 350;
            this.fMini.SizeMe();
        }

        internal void smlRespecShort(int iLevel, bool Mode2)
        {
            if (Mode2)
            {
                this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper2(false, iLevel), "Respec Helper", 4072);
                this.fMini.Width = 300;
            }
            else
            {
                this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper(false, iLevel), "Respec Helper", 2048);
                this.fMini.Width = 250;
            }
            this.fMini.SizeMe();
        }

        void StartFlip(int iPowerIndex)
        {
            if (this.FlipActive)
                this.EndFlip();
            if (iPowerIndex <= -1 || MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length == 0)
                return;
            this.FileModified = true;
            MainModule.MidsController.Toon.FlipSlots(iPowerIndex);
            this.RefreshInfo();
            this.FlipPowerID = iPowerIndex;
            this.FlipSlotState = new int[MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length - 1 + 1];
            int num = this.FlipSlotState.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.FlipSlotState[index] = -(this.FlipStepDelay * index);
            this.FlipGP = new PowerEntry(-1, (IPower)null, false);
            this.FlipGP.Assign(MidsContext.Character.CurrentBuild.Powers[iPowerIndex]);
            this.FlipGP.Slots = new SlotEntry[0];
            if (this.tmrGfx == null)
                this.tmrGfx = new System.Windows.Forms.Timer(this.Container);
            this.tmrGfx.Interval = this.FlipInterval;
            this.FlipActive = true;
            this.tmrGfx.Enabled = true;
            this.tmrGfx.Start();
        }

        void TemporaryPowersWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tempPowersButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
            this.tempPowersButton.Checked = true;
        }

        void tempPowersButton_ButtonClicked()
        {
            this.PowerModified();
        }

        void tempPowersButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            this.tempPowersButton.Checked = false;
            bool flag = false;
            if (this.fTemp == null)
                flag = true;
            else if (this.fTemp.IsDisposed)
                flag = true;
            if (flag)
            {
                IPower power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3259)];
                List<IPower> iPowers = new List<IPower>();
                int num = power.NIDSubPower.Length - 1;
                for (int index = 0; index <= num; ++index)
                    iPowers.Add(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
                this.fTemp = new frmAccolade(this, iPowers) { Text = "Temporary Powers" };
            }
            if (!this.fTemp.Visible)
                this.fTemp.Show(this);
        }

        void tlsDPA_Click(object sender, EventArgs e)
        {
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
            this.SetDamageMenuCheckMarks();
            this.DisplayFormatChanged();
        }

        void tmrGfx_Tick(object sender, EventArgs e)
        {
            if (!this.FlipActive)
                return;
            this.doFlipStep();
        }

        bool ToggleClicked(int hID, int iX, int iY)
        {
            Rectangle rectangle1 = new Rectangle();
            bool flag;
            if (hID < 0)
                flag = false;
            else if (MidsContext.Character.CurrentBuild.Powers[hID].IDXPower < 0)
            {
                flag = false;
            }
            else
            {
                Rectangle rectangle2 = new Rectangle()
                {
                    Location = this.drawing.PowerPosition(MidsContext.Character.CurrentBuild.Powers[hID], -1),
                    Size = this.drawing.bxPower[0].Size
                };
                rectangle1.Height = 15;
                rectangle1.Width = rectangle1.Height;
                rectangle1.Y = (int)Math.Round((double)rectangle2.Top + (double)(rectangle2.Height - rectangle1.Height) / 2.0);
                rectangle1.X = (int)Math.Round((double)rectangle2.Right - ((double)rectangle1.Width + (double)(rectangle2.Height - rectangle1.Height) / 2.0));
                flag = iX > rectangle1.X & iX < rectangle1.Right & iY > rectangle1.Top & iY < rectangle1.Bottom;
            }
            return flag;
        }

        void tsAbout_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            int num = (int)new frmAbout()
            {
                ibClose = {
          IA = this.drawing.pImageAttributes,
          ImageOff = this.drawing.bxPower[2].Bitmap,
          ImageOn = this.drawing.bxPower[3].Bitmap
        }
            }.ShowDialog((IWin32Window)this);
            this.FloatTop(true);
        }

        void tsAdvDBEdit_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            int num = (int)new frmDBEdit().ShowDialog((IWin32Window)this);
            this.FloatTop(true);
        }

        void tsAdvFreshInstall_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (MidsContext.Config.FreshInstall)
            {
                MidsContext.Config.FreshInstall = false;
                MidsContext.Config.SaveFolderChecked = true;
                int num = (int)Interaction.MsgBox((object)"Fresh Install flag has been unset!", MsgBoxStyle.OkOnly, (object)null);
            }
            else
            {
                MidsContext.Config.FreshInstall = true;
                MidsContext.Config.SaveFolderChecked = false;
                int num = (int)Interaction.MsgBox((object)"Fresh Install flag has been set!", MsgBoxStyle.OkOnly, (object)null);
            }
            this.tsAdvFreshInstall.Checked = MidsContext.Config.FreshInstall;
            this.FloatTop(true);
        }

        void tsAdvResetTips_Click(object sender, EventArgs e)
        {
            MidsContext.Config.Tips = new Tips();
        }

        void tsBug_Click(object sender, EventArgs e)
        {
            string at = "ATFailed";
            string pri = "PriFailed";
            string sec = "SecFailed";
            try
            {
                at = MidsContext.Character.Archetype.DisplayName;
                pri = MidsContext.Character.Powersets[0].DisplayName;
                sec = MidsContext.Character.Powersets[1].DisplayName;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            clsXMLUpdate.BugReport(at, pri, sec, "");
        }

        void tsClearAllEnh_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (Interaction.MsgBox((object)"Really clear all slotted enhancements?\r\nThis will not clear the alternate slotting, only the currently active slots.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") == MsgBoxResult.Yes)
            {
                int num1 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index1 = 0; index1 <= num1; ++index1)
                {
                    int num2 = MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length - 1;
                    for (int index2 = 0; index2 <= num2; ++index2)
                        MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2].Enhancement.Enh = -1;
                }
                this.DoRedraw();
                this.RefreshInfo();
            }
            this.FloatTop(true);
        }

        void tsConfig_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            frmMain iParent = this;
            frmCalcOpt frmCalcOpt = new frmCalcOpt(ref iParent);
            if (frmCalcOpt.ShowDialog((IWin32Window)this) == DialogResult.OK)
            {
                this.UpdateControls(false);
                this.UpdateOtherFormsFonts();
            }
            frmCalcOpt.Dispose();
            this.tsIODefault.Text = "Default (" + Conversions.ToString(MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
            this.FloatTop(true);
        }

        void tsDonate_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.Donate();
        }

        void tsDynamic_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
            MidsContext.Character.ResetLevel();
            this.PowerModified();
        }

        void tsEnhToDO_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character == null)
                return;
            if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.DualO))
                this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.DualO;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToEven_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.Even;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToMinus1_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusOne;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToMinus2_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusTwo;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToMinus3_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusThree;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToNone_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.None;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToPlus1_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusOne;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToPlus2_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusTwo;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToPlus3_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusThree;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToPlus4_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusFour;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToPlus5_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusFive;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToSO_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character == null)
                return;
            if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.SingleO))
                this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.SingleO;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToTO_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character == null)
                return;
            if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.TrainingO))
                this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.TrainingO;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsExport_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            MidsContext.Config.LongExport = false;
            frmForum frmForum1 = new frmForum();
            frmForum1.BackColor = this.BackColor;
            frmForum frmForum2 = frmForum1;
            frmForum2.ibCancel.IA = this.drawing.pImageAttributes;
            frmForum2.ibCancel.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum2.ibCancel.ImageOn = this.drawing.bxPower[3].Bitmap;
            frmForum2.ibExport.IA = this.drawing.pImageAttributes;
            frmForum2.ibExport.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum2.ibExport.ImageOn = this.drawing.bxPower[3].Bitmap;
            int num = (int)frmForum2.ShowDialog((IWin32Window)this);
            this.FloatTop(true);
        }

        void tsExportDataLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject((object)MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true), true);
            int num = (int)Interaction.MsgBox((object)"The data link has been placed on the clipboard and is ready to paste.", MsgBoxStyle.Information, (object)"Export Done");
        }

        void tsExportLong_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            MidsContext.Config.LongExport = true;
            frmForum frmForum1 = new frmForum();
            frmForum1.BackColor = this.BackColor;
            frmForum frmForum2 = frmForum1;
            frmForum2.ibCancel.IA = this.drawing.pImageAttributes;
            frmForum2.ibCancel.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum2.ibCancel.ImageOn = this.drawing.bxPower[3].Bitmap;
            frmForum2.ibExport.IA = this.drawing.pImageAttributes;
            frmForum2.ibExport.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum2.ibExport.ImageOn = this.drawing.bxPower[3].Bitmap;
            int num = (int)frmForum2.ShowDialog((IWin32Window)this);
            this.FloatTop(true);
            MidsContext.Config.LongExport = false;
        }

        void tsFileNew_Click(object sender, EventArgs e)
        {
            this.command_New();
        }

        void tsFileOpen_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                MsgBoxResult msgBoxResult = Interaction.MsgBox((object)"Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Question");
                this.FloatTop(true);
                if (msgBoxResult == MsgBoxResult.No)
                    return;
            }
            this.FloatTop(false);
            if (this.dlgOpen.ShowDialog() == DialogResult.OK)
                this.DoOpen(this.dlgOpen.FileName);
            this.FloatTop(true);
        }

        void tsFilePrint_Click(object sender, EventArgs e)
        {
            int num = (int)new frmPrint().ShowDialog((IWin32Window)this);
        }

        void tsFileQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void tsFileSave_Click(object sender, EventArgs e)
        {
            this.doSave();
        }

        void tsFileSaveAs_Click(object sender, EventArgs e)
        {
            this.doSaveAs();
        }

        void tsFlipAllEnh_Click(object sender, EventArgs e)
        {
            MainModule.MidsController.Toon.FlipAllSlots();
            this.DoRedraw();
            this.RefreshInfo();
            this.FloatUpdate(false);
        }

        void tsHelp_Click(object sender, EventArgs e)
        {
            frmReadme frmReadme = new frmReadme(OS.GetApplicationPath() + "readme.rtf")
            {
                btnClose = {
          IA = this.drawing.pImageAttributes,
          ImageOff = this.drawing.bxPower[2].Bitmap,
          ImageOn = this.drawing.bxPower[3].Bitmap
        }
            };
            this.FloatTop(false);
            int num = (int)frmReadme.ShowDialog((IWin32Window)this);
            this.FloatTop(true);
        }

        void tsHelperLong_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            int num = (int)new FrmInputLevel(ref iParent, true, false).ShowDialog((IWin32Window)this);
        }

        void tsHelperLong2_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            int num = (int)new FrmInputLevel(ref iParent, true, true).ShowDialog((IWin32Window)this);
        }

        void tsHelperShort_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            int num = (int)new FrmInputLevel(ref iParent, false, false).ShowDialog((IWin32Window)this);
        }

        void tsHelperShort2_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            int num = (int)new FrmInputLevel(ref iParent, false, true).ShowDialog((IWin32Window)this);
        }

        void tsImport_Click(object sender, EventArgs e)
        {
            this.command_ForumImport();
        }

        void tsIODefault_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, false))
                this.I9Picker.LastLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
            if (this.drawing == null)
                return;
            this.DoRedraw();
        }

        void tsIOMax_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, true))
                this.I9Picker.LastLevel = 50;
            if (this.drawing == null)
                return;
            this.DoRedraw();
        }

        void tsIOMin_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, true, false))
                this.I9Picker.LastLevel = 10;
            if (this.drawing == null)
                return;
            this.DoRedraw();
        }

        void tsLevelUp_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            MidsContext.Config.BuildMode = Enums.dmModes.LevelUp;
            MidsContext.Character.ResetLevel();
            this.PowerModified();
        }

        void tsPatchNotes_Click(object sender, EventArgs e)
        {
            string str = OS.GetApplicationPath() + "Data\\patch.rtf";
            if (File.Exists(str))
            {
                frmReadme frmReadme = new frmReadme(str)
                {
                    btnClose = {
            IA = this.drawing.pImageAttributes,
            ImageOff = this.drawing.bxPower[2].Bitmap,
            ImageOn = this.drawing.bxPower[3].Bitmap
          }
                };
                this.FloatTop(false);
                int num = (int)frmReadme.ShowDialog((IWin32Window)this);
                this.FloatTop(true);
            }
            else
            {
                this.FloatTop(false);
                int num = (int)Interaction.MsgBox((object)"No recent patches have been installed.", MsgBoxStyle.Information, (object)"No Notes");
                this.FloatTop(true);
            }
        }

        void tsRecipeViewer_Click(object sender, EventArgs e)
        {
            this.FloatRecipe(true);
        }

        void tsDPSCalc_Click(object sender, EventArgs e)
        {
            this.FloatDPSCalc(true);
        }

        void tsRemoveAllSlots_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (Interaction.MsgBox((object)"Really remove all slots?\r\nThis will not remove the slots granted automatically with powers, but will remove all the slots you placed manually.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Are you sure?") == MsgBoxResult.Yes)
            {
                int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].SlotCount > 1)
                        MidsContext.Character.CurrentBuild.Powers[index].Slots = (SlotEntry[])Utils.CopyArray((Array)MidsContext.Character.CurrentBuild.Powers[index].Slots, (Array)new SlotEntry[1]);
                }
                this.DoRedraw();
                MidsContext.Character.ResetLevel();
                this.PowerModified();
                this.RefreshInfo();
            }
            this.FloatTop(true);
        }

        void tsSetFind_Click(object sender, EventArgs e)
        {
            this.FloatSetFinder(true);
        }

        void tsTitanForum_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.GoToForums();
        }

        void tsTitanPlanner_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.GoToCoHPlanner();
        }

        void tsTitanSite_Click(object sender, EventArgs e)
        {
            clsXMLUpdate.GoToTitan();
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void tsUpdateCheck_Click(object sender, EventArgs e)
        {
            clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("http://repo.cohtitan.com/mids_updates/");
            IMessager iLoadFrm = (IMessager)null;
            clsXMLUpdate.eCheckResponse eCheckResponse = clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
            if (eCheckResponse != clsXMLUpdate.eCheckResponse.Updates & eCheckResponse != clsXMLUpdate.eCheckResponse.FailedWithMessage)
            {
                int num = (int)Interaction.MsgBox((object)"No Updates.", MsgBoxStyle.Information, (object)"Update Check");
            }
            if (eCheckResponse == clsXMLUpdate.eCheckResponse.Updates && clsXmlUpdate.RestartNeeded && Interaction.MsgBox((object)"Exit Now?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object)"Update Downloaded") == MsgBoxResult.Yes && !this.CloseCommand())
            {
                clsXMLUpdate.LaunchSelfUpdate();
                ProjectData.EndApp();
            }
            this.RefreshInfo();
        }

        void tsView2Col_Click(object sender, EventArgs e)
        {
            this.setColumns(2);
        }

        void tsView3Col_Click(object sender, EventArgs e)
        {
            this.setColumns(3);
        }

        void tsView4Col_Click(object sender, EventArgs e)
        {
            this.setColumns(4);
        }

        void tsViewActualDamage_New_Click(object sender, EventArgs e)
        {
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            this.SetDamageMenuCheckMarks();
            this.DisplayFormatChanged();
        }

        void tsViewData_Click(object sender, EventArgs e)
        {
            this.FloatData(true);
        }

        void tsViewDPS_New_Click(object sender, EventArgs e)
        {
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
            this.SetDamageMenuCheckMarks();
            this.DisplayFormatChanged();
        }

        void tsViewGraphs_Click(object sender, EventArgs e)
        {
            this.FloatStatGraph(true);
        }

        void tsViewIOLevels_Click(object sender, EventArgs e)
        {
            MidsContext.Config.I9.DisplayIOLevels = !MidsContext.Config.I9.DisplayIOLevels;
            this.tsViewIOLevels.Checked = MidsContext.Config.I9.DisplayIOLevels;
            this.DoRedraw();
        }

        void tsViewRelative_Click(object sender, EventArgs e)
        {
            MidsContext.Config.ShowEnhRel = !MidsContext.Config.ShowEnhRel;
            this.tsViewRelative.Checked = MidsContext.Config.ShowEnhRel;
            this.DoRedraw();
        }

        void tsViewSetCompare_Click(object sender, EventArgs e)
        {
            this.FloatCompareGraph(true);
        }

        void tsViewSets_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            this.FloatSets(true);
        }

        void tsViewSlotLevels_Click(object sender, EventArgs e)
        {
            MidsContext.Config.ShowSlotLevels = !MidsContext.Config.ShowSlotLevels;
            this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
            this.ibSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
            this.DoRedraw();
        }

        void tsViewTotals_Click(object sender, EventArgs e)
        {
            this.FloatTotals(true);
        }

        void txtName_TextChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            MidsContext.Character.Name = this.txtName.Text;
            this.DisplayName();
        }

        internal void UnSetMiniList()
        {
            if (this.fMini != null)
                this.fMini.Dispose();
            this.fMini = (frmMiniList)null;
            GC.Collect();
        }

        void UpdateColours(bool skipDraw = false)
        {
            this.myDataView.DrawVillain = !MidsContext.Character.IsHero();
            bool flag;
            if (this.myDataView.DrawVillain)
            {
                flag = this.I9Picker.ForeColor.R != byte.MaxValue;
                this.BackColor = Color.FromArgb(0, 0, 0);
                this.lblATLocked.BackColor = Color.FromArgb((int)byte.MaxValue, 128, 128);
                this.I9Picker.ForeColor = Color.FromArgb((int)byte.MaxValue, 0, 0);
            }
            else
            {
                flag = this.I9Picker.ForeColor.R != (byte)96;
                this.BackColor = Color.FromArgb(0, 0, 0);
                this.lblATLocked.BackColor = Color.FromArgb(128, 128, (int)byte.MaxValue);
                this.I9Picker.ForeColor = Color.FromArgb(96, 48, (int)byte.MaxValue);
            }
            this.I9Picker.BackColor = this.BackColor;
            this.I9Popup.BackColor = Color.Black;
            this.I9Popup.ForeColor = this.I9Picker.ForeColor;
            this.myDataView.BackColor = this.BackColor;
            this.llPrimary.BackColor = this.BackColor;
            this.llSecondary.BackColor = this.BackColor;
            this.llPool0.BackColor = this.BackColor;
            this.llPool1.BackColor = this.BackColor;
            this.llPool2.BackColor = this.BackColor;
            this.llPool3.BackColor = this.BackColor;
            this.llAncillary.BackColor = this.BackColor;
            ListLabelV2 llPrimary = this.llPrimary;
            this.UpdateLLColours(ref llPrimary);
            this.llPrimary = llPrimary;
            ListLabelV2 llSecondary = this.llSecondary;
            this.UpdateLLColours(ref llSecondary);
            this.llSecondary = llSecondary;
            ListLabelV2 llAncillary = this.llAncillary;
            this.UpdateLLColours(ref llAncillary);
            this.llAncillary = llAncillary;
            ListLabelV2 llPool0 = this.llPool0;
            this.UpdateLLColours(ref llPool0);
            this.llPool0 = llPool0;
            ListLabelV2 llPool1 = this.llPool1;
            this.UpdateLLColours(ref llPool1);
            this.llPool1 = llPool1;
            ListLabelV2 iList = this.llPool2;
            this.UpdateLLColours(ref iList);
            this.llPool2 = iList;
            iList = this.llPool3;
            this.UpdateLLColours(ref iList);
            this.llPool3 = iList;
            this.llPrimary.Font = new Font(this.llPrimary.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
            this.llSecondary.Font = this.llPrimary.Font;
            this.llPool0.Font = this.llPrimary.Font;
            this.llPool1.Font = this.llPrimary.Font;
            this.llPool2.Font = this.llPrimary.Font;
            this.llPool3.Font = this.llPrimary.Font;
            this.llAncillary.Font = this.llPrimary.Font;
            this.lblName.BackColor = this.BackColor;
            this.lblAT.BackColor = this.BackColor;
            this.lblOrigin.BackColor = this.BackColor;
            this.lblHero.BackColor = this.BackColor;
            this.pnlGFX.BackColor = this.BackColor;
            this.lblLocked0.BackColor = this.lblATLocked.BackColor;
            this.lblLocked1.BackColor = this.lblATLocked.BackColor;
            this.lblLocked2.BackColor = this.lblATLocked.BackColor;
            this.lblLocked3.BackColor = this.lblATLocked.BackColor;
            this.lblLockedAncillary.BackColor = this.lblATLocked.BackColor;
            this.lblLockedSecondary.BackColor = this.lblATLocked.BackColor;
            this.lblATLocked.BackColor = this.lblATLocked.BackColor;
            this.ibSets.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibPvX.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.incarnateButton.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.tempPowersButton.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.accoladeButton.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.heroVillain.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibVetPools.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibTotals.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibMode.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibSlotLevels.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibPopup.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibRecipe.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            this.ibAccolade.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);
            if (!flag)
                return;
            if (!skipDraw)
                this.DoRedraw();
            this.UpdateDMBuffer();
            this.pbDynMode.Refresh();
        }

        void UpdateControls(bool ForceComplete = false)
        {
            this.NoUpdate = true;
            Archetype[] all = Array.FindAll<Archetype>(DatabaseAPI.Database.Classes, new Predicate<Archetype>(this.GetPlayableClasses));
            if (this.ComboCheckAT(ref all))
            {
                this.cbAT.BeginUpdate();
                this.cbAT.Items.Clear();
                this.cbAT.Items.AddRange((object[])all);
                this.cbAT.EndUpdate();
            }
            if (this.cbAT.SelectedItem == null)
                this.cbAT.SelectedItem = (object)MidsContext.Character.Archetype;
            else if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(this.cbAT.SelectedItem, (System.Type)null, "Idx", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)MidsContext.Character.Archetype.Idx, false))
                this.cbAT.SelectedItem = (object)MidsContext.Character.Archetype;
            this.ibPvX.Checked = !MidsContext.Config.Inc.PvE;
            if (this.ComboCheckOrigin())
            {
                this.cbOrigin.BeginUpdate();
                this.cbOrigin.Items.Clear();
                this.cbOrigin.Items.AddRange((object[])NewLateBinding.LateGet(this.cbAT.SelectedItem, (System.Type)null, "Origin", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                this.cbOrigin.EndUpdate();
            }
            if (this.cbOrigin.SelectedIndex != MidsContext.Character.Origin)
            {
                if (MidsContext.Character.Origin < this.cbOrigin.Items.Count)
                    this.cbOrigin.SelectedIndex = MidsContext.Character.Origin;
                else
                    this.cbOrigin.SelectedIndex = 0;
                I9Gfx.SetOrigin(Conversions.ToString(this.cbOrigin.SelectedItem));
            }
            ComboBox iCB = this.cbPrimary;
            frmMain.ComboCheckPS(ref iCB, Enums.PowersetType.Primary, Enums.ePowerSetType.Primary);
            this.cbPrimary = iCB;
            iCB = this.cbSecondary;
            frmMain.ComboCheckPS(ref iCB, Enums.PowersetType.Secondary, Enums.ePowerSetType.Secondary);
            this.cbSecondary = iCB;
            if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                this.cbSecondary.Enabled = false;
            else
                this.cbSecondary.Enabled = true;
            iCB = this.cbPool0;
            frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
            this.cbPool0 = iCB;
            iCB = this.cbPool1;
            frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
            this.cbPool1 = iCB;
            iCB = this.cbPool2;
            frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
            this.cbPool2 = iCB;
            iCB = this.cbPool3;
            frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Pool);
            this.cbPool3 = iCB;
            iCB = this.cbAncillary;
            frmMain.ComboCheckPool(ref iCB, Enums.ePowerSetType.Ancillary);
            this.cbAncillary = iCB;
            this.cbPool0.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(0, MidsContext.Character.Powersets[3].nID);
            this.cbPool1.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(1, MidsContext.Character.Powersets[4].nID);
            this.cbPool2.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(2, MidsContext.Character.Powersets[5].nID);
            this.cbPool3.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(3, MidsContext.Character.Powersets[6].nID);
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Ancillary);
            if (MidsContext.Character.Powersets[7] != null)
                this.cbAncillary.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[7], powersetIndexes);
            else
                this.cbAncillary.SelectedIndex = 0;
            if (MidsContext.Character.Powersets[7] == null)
                this.cbAncillary.Enabled = false;
            else
                this.cbAncillary.Enabled = true;
            this.UpdatePowerLists();
            this.DisplayName();
            this.cbAT.Enabled = !MainModule.MidsController.Toon.Locked;
            this.cbPool0.Enabled = !MainModule.MidsController.Toon.PoolLocked[0];
            this.cbPool1.Enabled = !MainModule.MidsController.Toon.PoolLocked[1];
            this.cbPool2.Enabled = !MainModule.MidsController.Toon.PoolLocked[2];
            this.cbPool3.Enabled = !MainModule.MidsController.Toon.PoolLocked[3];
            this.cbAncillary.Enabled = !MainModule.MidsController.Toon.PoolLocked[4];
            this.lblATLocked.Text = Conversions.ToString(NewLateBinding.LateGet(this.cbAT.SelectedItem, (System.Type)null, "DisplayName", new object[0], (string[])null, (System.Type[])null, (bool[])null));
            this.lblATLocked.Visible = MainModule.MidsController.Toon.Locked;
            this.lblLocked0.Location = this.cbPool0.Location;
            this.lblLocked0.Size = this.cbPool0.Size;
            this.lblLocked0.Text = this.cbPool0.Text;
            this.lblLocked0.Visible = MainModule.MidsController.Toon.PoolLocked[0];
            this.lblLocked1.Location = this.cbPool1.Location;
            this.lblLocked1.Size = this.cbPool1.Size;
            this.lblLocked1.Text = this.cbPool1.Text;
            this.lblLocked1.Visible = MainModule.MidsController.Toon.PoolLocked[1];
            this.lblLocked2.Location = this.cbPool2.Location;
            this.lblLocked2.Size = this.cbPool2.Size;
            this.lblLocked2.Text = this.cbPool2.Text;
            this.lblLocked2.Visible = MainModule.MidsController.Toon.PoolLocked[2];
            this.lblLocked3.Location = this.cbPool3.Location;
            this.lblLocked3.Size = this.cbPool3.Size;
            this.lblLocked3.Text = this.cbPool3.Text;
            this.lblLocked3.Visible = MainModule.MidsController.Toon.PoolLocked[3];
            this.lblLockedAncillary.Location = this.cbAncillary.Location;
            this.lblLockedAncillary.Size = this.cbAncillary.Size;
            this.lblLockedAncillary.Text = this.cbAncillary.Text;
            this.lblLockedAncillary.Visible = !this.cbAncillary.Enabled;
            this.lblLockedSecondary.Location = this.cbSecondary.Location;
            this.lblLockedSecondary.Size = this.cbSecondary.Size;
            this.lblLockedSecondary.Text = this.cbSecondary.Text;
            this.lblLockedSecondary.Visible = !this.cbSecondary.Enabled;
            this.llPrimary.SuspendRedraw = true;
            this.llSecondary.SuspendRedraw = true;
            this.llPrimary.PaddingY = 2;
            this.llSecondary.PaddingY = 2;
            this.FixPrimarySecondaryHeight();
            this.llPrimary.Font = new Font(this.llPrimary.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, FontStyle.Bold, GraphicsUnit.Point);
            this.llSecondary.Font = this.llPrimary.Font;
            int num1 = this.llPrimary.Items.Length - 1;
            for (int index = 0; index <= num1; ++index)
                this.llPrimary.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            int num2 = this.llSecondary.Items.Length - 1;
            for (int index = 0; index <= num2; ++index)
                this.llSecondary.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            this.heroVillain.Checked = !MidsContext.Character.IsHero();
            this.dvAnchored.SetLocation(new Point(this.llPrimary.Left, this.llPrimary.Top + this.raGreater(this.llPrimary.SizeNormal.Height, this.llSecondary.SizeNormal.Height) + 5), ForceComplete);
            this.llPrimary.SuspendRedraw = false;
            this.llSecondary.SuspendRedraw = false;
            if (this.myDataView != null && this.drawing.InterfaceMode == Enums.eInterfaceMode.Normal & this.myDataView.TabPageIndex == 2)
                this.dvAnchored_TabChanged(this.myDataView.TabPageIndex);
            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
            {
                this.UpdateDMBuffer();
                this.pbDynMode.Refresh();
            }
            this.DoResize();
            this.NoUpdate = false;
        }

        void UpdateDMBuffer()
        {
            if (this.drawing == null || MainModule.MidsController.Toon == null)
                return;
            if (this.dmBuffer == null)
                this.dmBuffer = new ExtendedBitmap(this.pbDynMode.Width, this.pbDynMode.Height);
            Enums.ePowerState ePowerState;
            string iStr;
            if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
            {
                if (MidsContext.Config.BuildOption == Enums.dmItem.Slot)
                {
                    ePowerState = Enums.ePowerState.Open;
                    iStr = "Power / Slot";
                }
                else
                {
                    ePowerState = Enums.ePowerState.Used;
                    iStr = "Power Only";
                }
            }
            else if (DatabaseAPI.Database.Levels[MidsContext.Character.Level].LevelType() == Enums.dmItem.Power)
            {
                ePowerState = Enums.ePowerState.Used;
                iStr = "Power";
            }
            else
            {
                int slotsRemaining = MainModule.MidsController.Toon.SlotsRemaining;
                ePowerState = Enums.ePowerState.Open;
                iStr = Conversions.ToString(slotsRemaining) + " Slot";
                if (slotsRemaining > 1)
                    iStr += "s";
            }
            if (MainModule.MidsController.Toon.Complete)
            {
                if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                    ePowerState = Enums.ePowerState.Used;
                iStr = "Complete";
            }
            Rectangle rectangle = new Rectangle();
            ref Rectangle local = ref rectangle;
            Size size = this.drawing.bxPower[(int)ePowerState].Size;
            int width = size.Width;
            size = this.drawing.bxPower[(int)ePowerState].Size;
            int height1 = size.Height;
            local = new Rectangle(0, 0, width, height1);
            Rectangle destRect = new Rectangle(0, 0, this.pbDynMode.Width, this.pbDynMode.Height);
            StringFormat stringFormat = new StringFormat();
            Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            if (ePowerState == Enums.ePowerState.Open)
                this.dmBuffer.Graphics.DrawImage((Image)this.drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
            else
                this.dmBuffer.Graphics.DrawImage((Image)this.drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this.drawing.pImageAttributes);
            float height2 = bFont.GetHeight(this.dmBuffer.Graphics) + 2f;
            RectangleF Bounds = new RectangleF(0.0f, (float)(((double)this.pbDynMode.Height - (double)height2) / 2.0), (float)this.pbDynMode.Width, height2);
            Graphics graphics = this.dmBuffer.Graphics;
            clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
        }

        void UpdateDynamicModeInfo()
        {
            if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
            {
                this.tsDynamic.Checked = true;
                this.tsLevelUp.Checked = false;
            }
            else
            {
                this.tsDynamic.Checked = false;
                this.tsLevelUp.Checked = true;
            }
            this.ibMode.TextOff = MidsContext.Config.BuildMode != Enums.dmModes.Dynamic ? (!MainModule.MidsController.Toon.Complete ? "Level-Up: " + Conversions.ToString(MidsContext.Character.Level + 1) : "Level-Up") : "Dynamic";
        }

        void UpdateLLColours(ref ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            if (this.myDataView.DrawVillain)
            {
                iList.ScrollBarColor = Color.FromArgb((int)byte.MaxValue, 0, 0);
                iList.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                iList.ScrollBarColor = Color.FromArgb(64, 64, (int)byte.MaxValue);
                iList.ScrollButtonColor = Color.FromArgb(32, 32, (int)byte.MaxValue);
            }
        }

        void UpdateOtherFormsFonts()
        {
            if (this.fIncarnate != null)
            {
                frmIncarnate fIncarnate = this.fIncarnate;
                if (fIncarnate.Visible)
                {
                    fIncarnate.llLeft.SuspendRedraw = true;
                    fIncarnate.llRight.SuspendRedraw = true;
                    fIncarnate.llLeft.Font = this.llPrimary.Font;
                    fIncarnate.llRight.Font = this.llPrimary.Font;
                    fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                    fIncarnate.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                    fIncarnate.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    int num1 = fIncarnate.llLeft.Items.Length - 1;
                    for (int index = 0; index <= num1; ++index)
                        fIncarnate.llLeft.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    int num2 = fIncarnate.llRight.Items.Length - 1;
                    for (int index = 0; index <= num2; ++index)
                        fIncarnate.llRight.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    fIncarnate.llLeft.SuspendRedraw = false;
                    fIncarnate.llRight.SuspendRedraw = false;
                    fIncarnate.llLeft.Refresh();
                    fIncarnate.llRight.Refresh();
                }
            }
            if (this.fTemp != null)
            {
                frmAccolade fTemp = this.fTemp;
                if (fTemp.Visible)
                {
                    fTemp.llLeft.SuspendRedraw = true;
                    fTemp.llRight.SuspendRedraw = true;
                    fTemp.llLeft.Font = this.llPrimary.Font;
                    fTemp.llRight.Font = this.llPrimary.Font;
                    fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                    fTemp.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                    fTemp.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    int num1 = fTemp.llLeft.Items.Length - 1;
                    for (int index = 0; index <= num1; ++index)
                        fTemp.llLeft.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    int num2 = fTemp.llRight.Items.Length - 1;
                    for (int index = 0; index <= num2; ++index)
                        fTemp.llRight.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    fTemp.llLeft.SuspendRedraw = false;
                    fTemp.llRight.SuspendRedraw = false;
                    fTemp.llLeft.Refresh();
                    fTemp.llRight.Refresh();
                }
            }
            if (this.fAccolade == null)
                return;
            frmAccolade fAccolade = this.fAccolade;
            if (fAccolade.Visible)
            {
                fAccolade.llLeft.SuspendRedraw = true;
                fAccolade.llRight.SuspendRedraw = true;
                fAccolade.llLeft.Font = this.llPrimary.Font;
                fAccolade.llRight.Font = this.llPrimary.Font;
                fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                fAccolade.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                fAccolade.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                int num1 = fAccolade.llLeft.Items.Length - 1;
                for (int index = 0; index <= num1; ++index)
                    fAccolade.llLeft.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                int num2 = fAccolade.llRight.Items.Length - 1;
                for (int index = 0; index <= num2; ++index)
                    fAccolade.llRight.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                fAccolade.llLeft.SuspendRedraw = false;
                fAccolade.llRight.SuspendRedraw = false;
                fAccolade.llLeft.Refresh();
                fAccolade.llRight.Refresh();
            }
        }

        void UpdatePowerList(ref ListLabelV2 llPower)
        {
            llPower.SuspendRedraw = true;
            if (llPower.Items.Length == 0)
                llPower.AddItem(new ListLabelV2.ListLabelItemV2("Nothing", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
            int num = llPower.Items.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                ListLabelV2.ListLabelItemV2 listLabelItemV2 = llPower.Items[index];
                if (listLabelItemV2.nIDSet > -1 & listLabelItemV2.IDXPower > -1)
                {
                    string message = "";
                    listLabelItemV2.ItemState = MainModule.MidsController.Toon.PowerState(listLabelItemV2.nIDPower, ref message);
                    listLabelItemV2.Italic = listLabelItemV2.ItemState == ListLabelV2.LLItemState.Invalid;
                    listLabelItemV2.Bold = MidsContext.Config.RtFont.PairedBold;
                }
            }
            llPower.SuspendRedraw = false;
        }

        void UpdatePowerLists()
        {
            bool flag1 = false;
            if (this.llPrimary.Items.Length == 0)
                flag1 = true;
            else if (this.llPrimary.Items[this.llPrimary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[0].nID)
                flag1 = true;
            if (this.llSecondary.Items.Length == 0)
                flag1 = true;
            else if (this.llSecondary.Items[this.llSecondary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[1].nID)
                flag1 = true;
            bool flag2 = false;
            if (this.llAncillary.Items.Length == 0 | MidsContext.Character.Powersets[7] == null)
                flag2 = true;
            else if (this.llAncillary.Items[this.llAncillary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[7].nID)
                flag2 = true;
            ListLabelV2 llPower;
            if (flag1)
            {
                ListLabelV2 llPrimary = this.llPrimary;
                this.AssemblePowerList(ref llPrimary, MidsContext.Character.Powersets[0]);
                this.llPrimary = llPrimary;
                llPower = this.llSecondary;
                this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[1]);
                this.llSecondary = llPower;
            }
            else
            {
                ListLabelV2 llPrimary = this.llPrimary;
                this.UpdatePowerList(ref llPrimary);
                this.llPrimary = llPrimary;
                ListLabelV2 llSecondary = this.llSecondary;
                this.UpdatePowerList(ref llSecondary);
                this.llSecondary = llSecondary;
            }
            if (flag2 | flag1)
            {
                llPower = this.llAncillary;
                this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[7]);
                this.llAncillary = llPower;
                llPower = this.llAncillary;
                this.UpdatePowerList(ref llPower);
                this.llAncillary = llPower;
            }
            else
            {
                llPower = this.llAncillary;
                this.UpdatePowerList(ref llPower);
                this.llAncillary = llPower;
            }
            llPower = this.llPool0;
            this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[3]);
            this.llPool0 = llPower;
            llPower = this.llPool1;
            this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[4]);
            this.llPool1 = llPower;
            llPower = this.llPool2;
            this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[5]);
            this.llPool2 = llPower;
            llPower = this.llPool3;
            this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[6]);
            this.llPool3 = llPower;
            llPower = this.llPool0;
            this.UpdatePowerList(ref llPower);
            this.llPool0 = llPower;
            llPower = this.llPool1;
            this.UpdatePowerList(ref llPower);
            this.llPool1 = llPower;
            llPower = this.llPool2;
            this.UpdatePowerList(ref llPower);
            this.llPool2 = llPower;
            llPower = this.llPool3;
            this.UpdatePowerList(ref llPower);
            this.llPool3 = llPower;
        }

        void GameImport(string buildString)
        {
            string str1 = "";
            try
            {
                if (buildString.Contains("build.txt"))
                {
                    str1 = buildString + " is an invalid file name";
                    StreamReader streamReader = new StreamReader(buildString);
                    buildString = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                frmMain.BuildFileLines[] buildFileLinesArray = new frmMain.BuildFileLines[200];
                buildString = buildString.Replace("Level ", "");
                string[] strArray1 = buildString.Split('\r');
                string[] strArray2 = strArray1[0].Split(':');
                string[] strArray3 = strArray2[1].Split(' ');
                string[] strArray4 = strArray3[3].Split('_');
                MidsContext.Character.Archetype = DatabaseAPI.GetArchetypeByName(strArray4[1]);
                MidsContext.Character.Origin = DatabaseAPI.GetOriginByName(MidsContext.Character.Archetype, strArray3[2]);
                MidsContext.Character.Reset(MidsContext.Character.Archetype, MidsContext.Character.Origin);
                MidsContext.Character.Name = strArray2[0];
                int num1 = 0;
                int num2 = 0;
                string str2 = "";
                List<string> stringList = new List<string>();
                for (int index1 = 0; index1 + 4 < strArray1.Length - 2; ++index1)
                {
                    string[] strArray5 = this.BuildLineSplitter(strArray1[index1 + 4]);
                    if (strArray1[index1 + 4][1] != '\t')
                    {
                        ++num2;
                        string str3 = "";
                        num1 = 0;
                        for (int index2 = 1; index2 < strArray5.Length - 1; ++index2)
                            str3 = str3 + strArray5[index2] + ".";
                        string str4 = str3.TrimEnd('.');
                        string str5 = str3 + strArray5[strArray5.Length - 1];
                        buildFileLinesArray[index1].powerSetName = str4;
                        buildFileLinesArray[index1].powerName = str5;
                        buildFileLinesArray[index1].powerLevel = Convert.ToInt32(strArray5[0].Trim());
                        if (str2 != str4)
                        {
                            if (!str4.Contains("Inherent") && !str4.Contains("Incarnate"))
                                stringList.Add(str4);
                            str2 = str4;
                        }
                    }
                    else
                    {
                        num1 = buildFileLinesArray[index1 - num1 - 1].powerSlotsAmount = num1 + 1;
                        if (strArray1[index1 + 4].Contains("EMPTY"))
                        {
                            buildFileLinesArray[index1].enhancementName = "Empty";
                        }
                        else
                        {
                            int num3 = 0;
                            strArray5[1] = strArray5[1].TrimStart('(');
                            strArray5[1] = strArray5[1].TrimEnd(')');
                            int num4;
                            if (strArray5[1].Contains("+"))
                            {
                                string[] strArray6 = strArray5[1].Split('+');
                                num3 = Convert.ToInt32(strArray6[1]);
                                num4 = Convert.ToInt32(strArray6[0]);
                            }
                            else
                                num4 = Convert.ToInt32(strArray5[1]);
                            strArray5[0] = strArray5[0].Replace("_Attuned_Superior", "");
                            strArray5[0] = strArray5[0].Replace("Synthetic_", "");
                            strArray5[0] = strArray5[0].Replace("Natural", "Magic");
                            strArray5[0] = strArray5[0].Replace("Technology", "Magic");
                            strArray5[0] = strArray5[0].Replace("Mutation", "Magic");
                            strArray5[0] = strArray5[0].Replace("Science", "Magic");
                            buildFileLinesArray[index1].enhancementName = strArray5[0];
                            buildFileLinesArray[index1].enhancementRelativeLevel = num3;
                            if (num4 == 1)
                                num4 = 50;
                            buildFileLinesArray[index1].enhancementLevel = num4 - 1;
                        }
                    }
                }
                if (stringList.Count > MidsContext.Character.Powersets.Length + 1)
                    MidsContext.Character.Powersets = new IPowerset[stringList.Count];
                IPowerset powersetByName1 = DatabaseAPI.GetPowersetByName(stringList[0]);
                if (powersetByName1 == null)
                    str1 = stringList[0];
                MidsContext.Character.Powersets[0] = powersetByName1;
                IPowerset powersetByName2 = DatabaseAPI.GetPowersetByName(stringList[1]);
                if (powersetByName2 == null)
                    str1 = stringList[1];
                MidsContext.Character.Powersets[1] = powersetByName2;
                for (int index = 2; index < stringList.Count; ++index)
                {
                    IPowerset powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[index]);
                    if (powersetByName3 == null)
                        str1 = stringList[index];
                    MidsContext.Character.Powersets[index + 1] = powersetByName3;
                }
                MidsContext.Character.CurrentBuild.LastPower = 24;
                int index3 = 0;
                List<PowerEntry> listPowerEntry = new List<PowerEntry>();
                for (int index1 = 0; index1 < num2; ++index1)
                {
                    str1 = buildFileLinesArray[index3].powerName;
                    IPower powerByName = DatabaseAPI.GetPowerByName(buildFileLinesArray[index3].powerName);
                    if (!powerByName.FullName.Contains("Incarnate"))
                    {
                        PowerEntry powerEntry = new PowerEntry(-1, (IPower)null, false);
                        powerEntry.Level = buildFileLinesArray[index3].powerLevel;
                        powerEntry.StatInclude = false;
                        powerEntry.VariableValue = 0;
                        powerEntry.Slots = new SlotEntry[buildFileLinesArray[index3].powerSlotsAmount];
                        if (buildFileLinesArray[index3].powerSlotsAmount > 0)
                        {
                            for (int index2 = 0; index2 < powerEntry.Slots.Length; ++index2)
                            {
                                ++index3;
                                powerEntry.Slots[index2] = new SlotEntry()
                                {
                                    Level = 49,
                                    Enhancement = new I9Slot(),
                                    FlippedEnhancement = new I9Slot()
                                };
                                if (buildFileLinesArray[index3].enhancementName != "Empty")
                                {
                                    I9Slot i9Slot = new I9Slot();
                                    i9Slot.Enh = DatabaseAPI.GetEnhancementByUIDName(buildFileLinesArray[index3].enhancementName);
                                    str1 = buildFileLinesArray[index3].enhancementName;
                                    if (i9Slot.Enh == -1)
                                    {
                                        string iName = buildFileLinesArray[index3].enhancementName.Replace("Attuned", "Crafted");
                                        i9Slot.Enh = DatabaseAPI.GetEnhancementByUIDName(iName);
                                        if (i9Slot.Enh == -1)
                                        {
                                            int num3 = (int)Interaction.MsgBox((object)("Error with: " + str1), MsgBoxStyle.OkOnly, (object)null);
                                            i9Slot.Enh = 0;
                                        }
                                    }
                                    if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.Normal || DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.SpecialO)
                                    {
                                        i9Slot.RelativeLevel = (Enums.eEnhRelative)(buildFileLinesArray[index3].enhancementRelativeLevel + 4);
                                        i9Slot.Grade = Enums.eEnhGrade.TrainingO;
                                    }
                                    if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.SetO)
                                    {
                                        i9Slot.IOLevel = buildFileLinesArray[index3].enhancementLevel;
                                        i9Slot.RelativeLevel = (Enums.eEnhRelative)(buildFileLinesArray[index3].enhancementRelativeLevel + 4);
                                    }
                                    powerEntry.Slots[index2].Enhancement = i9Slot;
                                }
                            }
                        }
                        powerEntry.NIDPower = powerByName.PowerIndex;
                        powerEntry.NIDPowerset = powerByName.PowerSetID;
                        powerEntry.IDXPower = powerByName.PowerSetIndex;
                        if (powerEntry.Level == 0 && powerEntry.Power.FullSetName == "Pool.Fitness")
                        {
                            if (powerEntry.NIDPower == 2553)
                                powerEntry.NIDPower = 1521;
                            if (powerEntry.NIDPower == 2554)
                                powerEntry.NIDPower = 1523;
                            if (powerEntry.NIDPower == 2555)
                                powerEntry.NIDPower = 1522;
                            if (powerEntry.NIDPower == 2556)
                                powerEntry.NIDPower = 1524;
                            powerEntry.NIDPowerset = powerByName.PowerSetID;
                            powerEntry.IDXPower = powerByName.PowerSetIndex;
                        }
                        if (powerEntry.Slots.Length > 0)
                            powerEntry.Slots[0].Level = powerEntry.Level;
                        listPowerEntry.Add(powerEntry);
                    }
                    ++index3;
                }
                List<PowerEntry> powerEntryList = this.sortPowerEntryList(listPowerEntry);
                for (int index1 = 0; index1 < powerEntryList.Count; ++index1)
                {
                    if (!powerEntryList[index1].PowerSet.FullName.Contains("Inherent"))
                        this.PowerPicked(powerEntryList[index1].NIDPowerset, powerEntryList[index1].NIDPower);
                }
                List<SlotEntry> slotEntryList = new List<SlotEntry>();
                for (int index1 = 0; index1 < MidsContext.Character.CurrentBuild.Powers.Count; ++index1)
                {
                    bool flag = false;
                    for (int index2 = 0; index2 < powerEntryList.Count; ++index2)
                    {
                        if (powerEntryList[index2].Power.FullName == MidsContext.Character.CurrentBuild.Powers[index1].Power.FullName)
                        {
                            if (powerEntryList[index2].Slots.Length > 0)
                                slotEntryList.Add(powerEntryList[index2].Slots[0]);
                            for (int index4 = 0; index4 < powerEntryList[index2].Slots.Length - 1; ++index4)
                            {
                                slotEntryList.Add(powerEntryList[index2].Slots[index4 + 1]);
                                MidsContext.Character.CurrentBuild.Powers[index1].AddSlot(49);
                            }
                            break;
                        }
                        if (flag)
                            break;
                    }
                }
                int num5 = 0;
                for (int index1 = 0; index1 < MidsContext.Character.CurrentBuild.Powers.Count; ++index1)
                {
                    for (int index2 = 0; index2 < MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length; ++index2)
                        MidsContext.Character.CurrentBuild.Powers[index1].Slots[index2] = slotEntryList[num5++];
                }
                MidsContext.Archetype = MidsContext.Character.Archetype;
                MidsContext.Character.Validate();
                MidsContext.Character.Lock();
                MidsContext.Character.ResetLevel();
                MidsContext.Character.PoolShuffle(false);
                I9Gfx.OriginIndex = MidsContext.Character.Origin;
                MidsContext.Character.Validate();
            }
            catch
            {
                int num = (int)Interaction.MsgBox((object)("Invalid Import Data, Blame Sai!\nError: " + str1), MsgBoxStyle.OkOnly, (object)null);
            }
        }

        List<PowerEntry> sortPowerEntryList(List<PowerEntry> listPowerEntry)
        {
            listPowerEntry.Sort((Comparison<PowerEntry>)((p1, p2) => p1.Level.CompareTo(p2.Level)));
            return listPowerEntry;
        }

        string[] BuildLineSplitter(string build)
        {
            string[] strArray = build.Split(' ');
            strArray[0] = strArray[0].Trim();
            strArray[0] = strArray[0].TrimEnd(':');
            return strArray;
        }

        struct BuildFileLines
        {
            public string powerSetName;
            public string powerName;
            public int powerLevel;
            public int powerSlotsAmount;
            public string enhancementName;
            public int enhancementLevel;
            public int enhancementRelativeLevel;
        }
    }
}
