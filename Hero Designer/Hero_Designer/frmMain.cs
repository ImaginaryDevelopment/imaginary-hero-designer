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
using Base.Data_Classes;
using Base.Display;
using Base.IO_Classes;
using Base.Master_Classes;
using Hero_Designer.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public partial class frmMain : Form
    {
    
        internal virtual ImageButton accoladeButton
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
                if (this._accoladeButton != null)
                {
                    this._accoladeButton.MouseDown += mouseEventHandler;
                    this._accoladeButton.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem AccoladesWindowToolStripMenuItem
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
                {
                    this._AccoladesWindowToolStripMenuItem.Click -= eventHandler;
                }
                this._AccoladesWindowToolStripMenuItem = value;
                if (this._AccoladesWindowToolStripMenuItem != null)
                {
                    this._AccoladesWindowToolStripMenuItem.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem AdvancedToolStripMenuItem1
        {
            get
            {
                return this._AdvancedToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._AdvancedToolStripMenuItem1 = value;
            }
        }
        internal virtual ToolStripMenuItem AutoArrangeAllSlotsToolStripMenuItem
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
                {
                    this._AutoArrangeAllSlotsToolStripMenuItem.Click -= eventHandler;
                }
                this._AutoArrangeAllSlotsToolStripMenuItem = value;
                if (this._AutoArrangeAllSlotsToolStripMenuItem != null)
                {
                    this._AutoArrangeAllSlotsToolStripMenuItem.Click += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbAncillary
        {
            get
            {
                return this._cbAncillary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbAncillary_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbAncillery_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbAncillary_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbAncillary != null)
                {
                    this._cbAncillary.DrawItem -= itemEventHandler;
                    this._cbAncillary.SelectionChangeCommitted -= eventHandler;
                    this._cbAncillary.MouseMove -= mouseEventHandler;
                    this._cbAncillary.MouseLeave -= eventHandler2;
                }
                this._cbAncillary = value;
                if (this._cbAncillary != null)
                {
                    this._cbAncillary.DrawItem += itemEventHandler;
                    this._cbAncillary.SelectionChangeCommitted += eventHandler;
                    this._cbAncillary.MouseMove += mouseEventHandler;
                    this._cbAncillary.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbAT
        {
            get
            {
                return this._cbAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbAT_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbAT_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbAT_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbAT_MouseLeave);
                if (this._cbAT != null)
                {
                    this._cbAT.DrawItem -= itemEventHandler;
                    this._cbAT.SelectionChangeCommitted -= eventHandler;
                    this._cbAT.MouseMove -= mouseEventHandler;
                    this._cbAT.MouseLeave -= eventHandler2;
                }
                this._cbAT = value;
                if (this._cbAT != null)
                {
                    this._cbAT.DrawItem += itemEventHandler;
                    this._cbAT.SelectionChangeCommitted += eventHandler;
                    this._cbAT.MouseMove += mouseEventHandler;
                    this._cbAT.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbOrigin
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
                if (this._cbOrigin != null)
                {
                    this._cbOrigin.DrawItem += itemEventHandler;
                    this._cbOrigin.SelectionChangeCommitted += eventHandler;
                }
            }
        }
        internal virtual ComboBox cbPool0
        {
            get
            {
                return this._cbPool0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool0_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbPool0_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool0_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool0 != null)
                {
                    this._cbPool0.DrawItem -= itemEventHandler;
                    this._cbPool0.SelectionChangeCommitted -= eventHandler;
                    this._cbPool0.MouseMove -= mouseEventHandler;
                    this._cbPool0.MouseLeave -= eventHandler2;
                }
                this._cbPool0 = value;
                if (this._cbPool0 != null)
                {
                    this._cbPool0.DrawItem += itemEventHandler;
                    this._cbPool0.SelectionChangeCommitted += eventHandler;
                    this._cbPool0.MouseMove += mouseEventHandler;
                    this._cbPool0.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbPool1
        {
            get
            {
                return this._cbPool1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool1_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbPool1_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool1_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool1 != null)
                {
                    this._cbPool1.DrawItem -= itemEventHandler;
                    this._cbPool1.SelectionChangeCommitted -= eventHandler;
                    this._cbPool1.MouseMove -= mouseEventHandler;
                    this._cbPool1.MouseLeave -= eventHandler2;
                }
                this._cbPool1 = value;
                if (this._cbPool1 != null)
                {
                    this._cbPool1.DrawItem += itemEventHandler;
                    this._cbPool1.SelectionChangeCommitted += eventHandler;
                    this._cbPool1.MouseMove += mouseEventHandler;
                    this._cbPool1.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbPool2
        {
            get
            {
                return this._cbPool2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool2_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbPool2_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool2_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool2 != null)
                {
                    this._cbPool2.DrawItem -= itemEventHandler;
                    this._cbPool2.SelectionChangeCommitted -= eventHandler;
                    this._cbPool2.MouseMove -= mouseEventHandler;
                    this._cbPool2.MouseLeave -= eventHandler2;
                }
                this._cbPool2 = value;
                if (this._cbPool2 != null)
                {
                    this._cbPool2.DrawItem += itemEventHandler;
                    this._cbPool2.SelectionChangeCommitted += eventHandler;
                    this._cbPool2.MouseMove += mouseEventHandler;
                    this._cbPool2.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbPool3
        {
            get
            {
                return this._cbPool3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPool3_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbPool3_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPool3_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPool0_MouseLeave);
                if (this._cbPool3 != null)
                {
                    this._cbPool3.DrawItem -= itemEventHandler;
                    this._cbPool3.SelectionChangeCommitted -= eventHandler;
                    this._cbPool3.MouseMove -= mouseEventHandler;
                    this._cbPool3.MouseLeave -= eventHandler2;
                }
                this._cbPool3 = value;
                if (this._cbPool3 != null)
                {
                    this._cbPool3.DrawItem += itemEventHandler;
                    this._cbPool3.SelectionChangeCommitted += eventHandler;
                    this._cbPool3.MouseMove += mouseEventHandler;
                    this._cbPool3.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbPrimary
        {
            get
            {
                return this._cbPrimary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbPrimary_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbPrimary_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbPrimary_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbPrimary_MouseLeave);
                if (this._cbPrimary != null)
                {
                    this._cbPrimary.DrawItem -= itemEventHandler;
                    this._cbPrimary.SelectionChangeCommitted -= eventHandler;
                    this._cbPrimary.MouseMove -= mouseEventHandler;
                    this._cbPrimary.MouseLeave -= eventHandler2;
                }
                this._cbPrimary = value;
                if (this._cbPrimary != null)
                {
                    this._cbPrimary.DrawItem += itemEventHandler;
                    this._cbPrimary.SelectionChangeCommitted += eventHandler;
                    this._cbPrimary.MouseMove += mouseEventHandler;
                    this._cbPrimary.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ComboBox cbSecondary
        {
            get
            {
                return this._cbSecondary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                DrawItemEventHandler itemEventHandler = new DrawItemEventHandler(this.cbSecondary_DrawItem);
                EventHandler eventHandler = new EventHandler(this.cbSecondary_SelectedIndexChanged);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.cbSecondary_MouseMove);
                EventHandler eventHandler2 = new EventHandler(this.cbSecondary_MouseLeave);
                if (this._cbSecondary != null)
                {
                    this._cbSecondary.DrawItem -= itemEventHandler;
                    this._cbSecondary.SelectionChangeCommitted -= eventHandler;
                    this._cbSecondary.MouseMove -= mouseEventHandler;
                    this._cbSecondary.MouseLeave -= eventHandler2;
                }
                this._cbSecondary = value;
                if (this._cbSecondary != null)
                {
                    this._cbSecondary.DrawItem += itemEventHandler;
                    this._cbSecondary.SelectionChangeCommitted += eventHandler;
                    this._cbSecondary.MouseMove += mouseEventHandler;
                    this._cbSecondary.MouseLeave += eventHandler2;
                }
            }
        }
        internal virtual ToolStripMenuItem CharacterToolStripMenuItem
        {
            get
            {
                return this._CharacterToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._CharacterToolStripMenuItem = value;
            }
        }
        internal virtual OpenFileDialog dlgOpen
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
        internal virtual SaveFileDialog dlgSave
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
        internal virtual DataView dvAnchored
        {
            get
            {
                return this._dvAnchored;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.frmMain_MouseWheel);
                DataView.SizeChangeEventHandler changeEventHandler = new DataView.SizeChangeEventHandler(this.dvAnchored_SizeChange);
                DataView.FloatChangeEventHandler changeEventHandler2 = new DataView.FloatChangeEventHandler(this.dvAnchored_Float);
                DataView.Unlock_ClickEventHandler clickEventHandler = new DataView.Unlock_ClickEventHandler(this.dvAnchored_Unlock);
                DataView.SlotUpdateEventHandler updateEventHandler = new DataView.SlotUpdateEventHandler(this.DataView_SlotUpdate);
                DataView.SlotFlipEventHandler flipEventHandler = new DataView.SlotFlipEventHandler(this.DataView_SlotFlip);
                DataView.MovedEventHandler movedEventHandler = new DataView.MovedEventHandler(this.dvAnchored_Move);
                DataView.TabChangedEventHandler changedEventHandler = new DataView.TabChangedEventHandler(this.dvAnchored_TabChanged);
                if (this._dvAnchored != null)
                {
                    this._dvAnchored.MouseWheel -= mouseEventHandler;
                    this._dvAnchored.SizeChange -= changeEventHandler;
                    this._dvAnchored.FloatChange -= changeEventHandler2;
                    this._dvAnchored.Unlock_Click -= clickEventHandler;
                    this._dvAnchored.SlotUpdate -= updateEventHandler;
                    this._dvAnchored.SlotFlip -= flipEventHandler;
                    this._dvAnchored.Moved -= movedEventHandler;
                    this._dvAnchored.TabChanged -= changedEventHandler;
                }
                this._dvAnchored = value;
                if (this._dvAnchored != null)
                {
                    this._dvAnchored.MouseWheel += mouseEventHandler;
                    this._dvAnchored.SizeChange += changeEventHandler;
                    this._dvAnchored.FloatChange += changeEventHandler2;
                    this._dvAnchored.Unlock_Click += clickEventHandler;
                    this._dvAnchored.SlotUpdate += updateEventHandler;
                    this._dvAnchored.SlotFlip += flipEventHandler;
                    this._dvAnchored.Moved += movedEventHandler;
                    this._dvAnchored.TabChanged += changedEventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem FileToolStripMenuItem
        {
            get
            {
                return this._FileToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FileToolStripMenuItem = value;
            }
        }
        internal virtual ToolStripMenuItem HelpToolStripMenuItem1
        {
            get
            {
                return this._HelpToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._HelpToolStripMenuItem1 = value;
            }
        }
        internal virtual ImageButton heroVillain
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
                {
                    this._heroVillain.ButtonClicked -= clickedEventHandler;
                }
                this._heroVillain = value;
                if (this._heroVillain != null)
                {
                    this._heroVillain.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual I9Picker I9Picker
        {
            get
            {
                if (this._I9Picker.Height <= 235)
                {
                    this._I9Picker.Height = 315;
                }
                return this._I9Picker;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
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
                if (this._I9Picker != null)
                {
                    this._I9Picker.Moved += movedEventHandler;
                    this._I9Picker.HoverSet += hoverSetEventHandler;
                    this._I9Picker.HoverEnhancement += enhancementEventHandler;
                    this._I9Picker.MouseLeave += eventHandler;
                    this._I9Picker.EnhancementPicked += pickedEventHandler;
                    this._I9Picker.MouseDown += mouseEventHandler;
                }
            }
        }
        internal virtual ctlPopUp I9Popup
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
                {
                    this._I9Popup.MouseMove -= mouseEventHandler;
                }
                this._I9Popup = value;
                if (this._I9Popup != null)
                {
                    this._I9Popup.MouseMove += mouseEventHandler;
                }
            }
        }
        internal virtual ImageButton ibAccolade
        {
            get
            {
                return this._ibAccolade;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ibAccolade = value;
            }
        }
        internal virtual ImageButton ibMode
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
                {
                    this._ibMode.ButtonClicked -= clickedEventHandler;
                }
                this._ibMode = value;
                if (this._ibMode != null)
                {
                    this._ibMode.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibPopup
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
                {
                    this._ibPopup.ButtonClicked -= clickedEventHandler;
                }
                this._ibPopup = value;
                if (this._ibPopup != null)
                {
                    this._ibPopup.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibPvX
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
                {
                    this._ibPvX.ButtonClicked -= clickedEventHandler;
                }
                this._ibPvX = value;
                if (this._ibPvX != null)
                {
                    this._ibPvX.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibRecipe
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
                {
                    this._ibRecipe.ButtonClicked -= clickedEventHandler;
                }
                this._ibRecipe = value;
                if (this._ibRecipe != null)
                {
                    this._ibRecipe.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibSets
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
                {
                    this._ibSets.ButtonClicked -= clickedEventHandler;
                }
                this._ibSets = value;
                if (this._ibSets != null)
                {
                    this._ibSets.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibSlotLevels
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
                {
                    this._ibSlotLevels.ButtonClicked -= clickedEventHandler;
                }
                this._ibSlotLevels = value;
                if (this._ibSlotLevels != null)
                {
                    this._ibSlotLevels.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibTotals
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
                {
                    this._ibTotals.ButtonClicked -= clickedEventHandler;
                }
                this._ibTotals = value;
                if (this._ibTotals != null)
                {
                    this._ibTotals.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ImageButton ibVetPools
        {
            get
            {
                return this._ibVetPools;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ibVetPools = value;
            }
        }
        internal virtual ToolStripMenuItem ImportExportToolStripMenuItem
        {
            get
            {
                return this._ImportExportToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ImportExportToolStripMenuItem = value;
            }
        }
        internal virtual ImageButton incarnateButton
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
                {
                    this._incarnateButton.MouseDown -= mouseEventHandler;
                }
                this._incarnateButton = value;
                if (this._incarnateButton != null)
                {
                    this._incarnateButton.MouseDown += mouseEventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem IncarnateWindowToolStripMenuItem
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
                {
                    this._IncarnateWindowToolStripMenuItem.Click -= eventHandler;
                }
                this._IncarnateWindowToolStripMenuItem = value;
                if (this._IncarnateWindowToolStripMenuItem != null)
                {
                    this._IncarnateWindowToolStripMenuItem.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem InGameRespecHelperToolStripMenuItem
        {
            get
            {
                return this._InGameRespecHelperToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._InGameRespecHelperToolStripMenuItem = value;
            }
        }
        internal virtual GFXLabel lblAT
        {
            get
            {
                return this._lblAT;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAT = value;
            }
        }
        internal virtual Label lblATLocked
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
                if (this._lblATLocked != null)
                {
                    this._lblATLocked.MouseMove += mouseEventHandler;
                    this._lblATLocked.Paint += paintEventHandler;
                    this._lblATLocked.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual Label lblEpic
        {
            get
            {
                return this._lblEpic;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblEpic = value;
            }
        }
        internal virtual GFXLabel lblHero
        {
            get
            {
                return this._lblHero;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblHero = value;
            }
        }
        internal virtual Label lblLocked0
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
                if (this._lblLocked0 != null)
                {
                    this._lblLocked0.Paint += paintEventHandler;
                    this._lblLocked0.MouseMove += mouseEventHandler;
                    this._lblLocked0.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual Label lblLocked1
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
                if (this._lblLocked1 != null)
                {
                    this._lblLocked1.Paint += paintEventHandler;
                    this._lblLocked1.MouseMove += mouseEventHandler;
                    this._lblLocked1.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual Label lblLocked2
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
                if (this._lblLocked2 != null)
                {
                    this._lblLocked2.Paint += paintEventHandler;
                    this._lblLocked2.MouseMove += mouseEventHandler;
                    this._lblLocked2.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual Label lblLocked3
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
                if (this._lblLocked3 != null)
                {
                    this._lblLocked3.Paint += paintEventHandler;
                    this._lblLocked3.MouseMove += mouseEventHandler;
                    this._lblLocked3.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual Label lblLockedAncillary
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
                if (this._lblLockedAncillary != null)
                {
                    this._lblLockedAncillary.MouseMove += mouseEventHandler;
                    this._lblLockedAncillary.Paint += paintEventHandler;
                    this._lblLockedAncillary.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual Label lblLockedSecondary
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
                if (this._lblLockedSecondary != null)
                {
                    this._lblLockedSecondary.MouseMove += mouseEventHandler;
                    this._lblLockedSecondary.MouseLeave += eventHandler;
                }
            }
        }
        internal virtual GFXLabel lblName
        {
            get
            {
                return this._lblName;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblName = value;
            }
        }
        internal virtual GFXLabel lblOrigin
        {
            get
            {
                return this._lblOrigin;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblOrigin = value;
            }
        }
        internal virtual Label lblPool1
        {
            get
            {
                return this._lblPool1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPool1 = value;
            }
        }
        internal virtual Label lblPool2
        {
            get
            {
                return this._lblPool2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPool2 = value;
            }
        }
        internal virtual Label lblPool3
        {
            get
            {
                return this._lblPool3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPool3 = value;
            }
        }
        internal virtual Label lblPool4
        {
            get
            {
                return this._lblPool4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPool4 = value;
            }
        }
        internal virtual Label lblPrimary
        {
            get
            {
                return this._lblPrimary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblPrimary = value;
            }
        }
        internal virtual Label lblSecondary
        {
            get
            {
                return this._lblSecondary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblSecondary = value;
            }
        }
        internal virtual ListLabelV2 llAncillary
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
                if (this._llAncillary != null)
                {
                    this._llAncillary.ItemHover += hoverEventHandler;
                    this._llAncillary.ItemClick += clickEventHandler;
                }
            }
        }
        internal virtual ListLabelV2 llPool0
        {
            get
            {
                return this._llPool0;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool0_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool0_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool0 != null)
                {
                    this._llPool0.ItemHover -= hoverEventHandler;
                    this._llPool0.ItemClick -= clickEventHandler;
                    this._llPool0.MouseLeave -= eventHandler;
                    this._llPool0.EmptyHover -= hoverEventHandler2;
                }
                this._llPool0 = value;
                if (this._llPool0 != null)
                {
                    this._llPool0.ItemHover += hoverEventHandler;
                    this._llPool0.ItemClick += clickEventHandler;
                    this._llPool0.MouseLeave += eventHandler;
                    this._llPool0.EmptyHover += hoverEventHandler2;
                }
            }
        }
        internal virtual ListLabelV2 llPool1
        {
            get
            {
                return this._llPool1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool1_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool1_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool1 != null)
                {
                    this._llPool1.ItemHover -= hoverEventHandler;
                    this._llPool1.ItemClick -= clickEventHandler;
                    this._llPool1.MouseLeave -= eventHandler;
                    this._llPool1.EmptyHover -= hoverEventHandler2;
                }
                this._llPool1 = value;
                if (this._llPool1 != null)
                {
                    this._llPool1.ItemHover += hoverEventHandler;
                    this._llPool1.ItemClick += clickEventHandler;
                    this._llPool1.MouseLeave += eventHandler;
                    this._llPool1.EmptyHover += hoverEventHandler2;
                }
            }
        }
        internal virtual ListLabelV2 llPool2
        {
            get
            {
                return this._llPool2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool2_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool2_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool2 != null)
                {
                    this._llPool2.ItemHover -= hoverEventHandler;
                    this._llPool2.ItemClick -= clickEventHandler;
                    this._llPool2.MouseLeave -= eventHandler;
                    this._llPool2.EmptyHover -= hoverEventHandler2;
                }
                this._llPool2 = value;
                if (this._llPool2 != null)
                {
                    this._llPool2.ItemHover += hoverEventHandler;
                    this._llPool2.ItemClick += clickEventHandler;
                    this._llPool2.MouseLeave += eventHandler;
                    this._llPool2.EmptyHover += hoverEventHandler2;
                }
            }
        }
        internal virtual ListLabelV2 llPool3
        {
            get
            {
                return this._llPool3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPool3_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPool3_ItemClick);
                EventHandler eventHandler = new EventHandler(this.llALL_MouseLeave);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                if (this._llPool3 != null)
                {
                    this._llPool3.ItemHover -= hoverEventHandler;
                    this._llPool3.ItemClick -= clickEventHandler;
                    this._llPool3.MouseLeave -= eventHandler;
                    this._llPool3.EmptyHover -= hoverEventHandler2;
                }
                this._llPool3 = value;
                if (this._llPool3 != null)
                {
                    this._llPool3.ItemHover += hoverEventHandler;
                    this._llPool3.ItemClick += clickEventHandler;
                    this._llPool3.MouseLeave += eventHandler;
                    this._llPool3.EmptyHover += hoverEventHandler2;
                }
            }
        }
        internal virtual ListLabelV2 llPrimary
        {
            get
            {
                return this._llPrimary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llPrimary_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llPrimary_ItemClick);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                ListLabelV2.ExpandChangedEventHandler changedEventHandler = new ListLabelV2.ExpandChangedEventHandler(this.PriSec_ExpandChanged);
                if (this._llPrimary != null)
                {
                    this._llPrimary.ItemHover -= hoverEventHandler;
                    this._llPrimary.ItemClick -= clickEventHandler;
                    this._llPrimary.EmptyHover -= hoverEventHandler2;
                    this._llPrimary.ExpandChanged -= changedEventHandler;
                }
                this._llPrimary = value;
                if (this._llPrimary != null)
                {
                    this._llPrimary.ItemHover += hoverEventHandler;
                    this._llPrimary.ItemClick += clickEventHandler;
                    this._llPrimary.EmptyHover += hoverEventHandler2;
                    this._llPrimary.ExpandChanged += changedEventHandler;
                }
            }
        }
        internal virtual ListLabelV2 llSecondary
        {
            get
            {
                return this._llSecondary;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ListLabelV2.ItemHoverEventHandler hoverEventHandler = new ListLabelV2.ItemHoverEventHandler(this.llSecondary_ItemHover);
                ListLabelV2.ItemClickEventHandler clickEventHandler = new ListLabelV2.ItemClickEventHandler(this.llSecondary_ItemClick);
                ListLabelV2.EmptyHoverEventHandler hoverEventHandler2 = new ListLabelV2.EmptyHoverEventHandler(this.llAll_EmptyHover);
                ListLabelV2.ExpandChangedEventHandler changedEventHandler = new ListLabelV2.ExpandChangedEventHandler(this.PriSec_ExpandChanged);
                if (this._llSecondary != null)
                {
                    this._llSecondary.ItemHover -= hoverEventHandler;
                    this._llSecondary.ItemClick -= clickEventHandler;
                    this._llSecondary.EmptyHover -= hoverEventHandler2;
                    this._llSecondary.ExpandChanged -= changedEventHandler;
                }
                this._llSecondary = value;
                if (this._llSecondary != null)
                {
                    this._llSecondary.ItemHover += hoverEventHandler;
                    this._llSecondary.ItemClick += clickEventHandler;
                    this._llSecondary.EmptyHover += hoverEventHandler2;
                    this._llSecondary.ExpandChanged += changedEventHandler;
                }
            }
        }
        internal virtual MenuStrip MenuBar
        {
            get
            {
                return this._MenuBar;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MenuBar = value;
            }
        }
        internal virtual ToolStripMenuItem OptionsToolStripMenuItem
        {
            get
            {
                return this._OptionsToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._OptionsToolStripMenuItem = value;
            }
        }
        internal virtual PictureBox pbDynMode
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
                if (this._pbDynMode != null)
                {
                    this._pbDynMode.Paint += paintEventHandler;
                    this._pbDynMode.Click += eventHandler;
                }
            }
        }
        internal virtual PictureBox pnlGFX
        {
            get
            {
                return this._pnlGFX;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.pnlGFX_MouseEnter);
                EventHandler eventHandler2 = new EventHandler(this.pnlGFX_MouseLeave);
                MouseEventHandler mouseEventHandler = new MouseEventHandler(this.pnlGFX_MouseMove);
                MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.pnlGFX_MouseUp);
                MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.pnlGFX_MouseDoubleClick);
                MouseEventHandler mouseEventHandler4 = new MouseEventHandler(this.pnlGFX_MouseDown);
                DragEventHandler dragEventHandler = new DragEventHandler(this.pnlGFX_DragOver);
                DragEventHandler dragEventHandler2 = new DragEventHandler(this.pnlGFX_DragEnter);
                DragEventHandler dragEventHandler3 = new DragEventHandler(this.pnlGFX_DragDrop);
                if (this._pnlGFX != null)
                {
                    this._pnlGFX.MouseEnter -= eventHandler;
                    this._pnlGFX.MouseLeave -= eventHandler2;
                    this._pnlGFX.MouseMove -= mouseEventHandler;
                    this._pnlGFX.MouseUp -= mouseEventHandler2;
                    this._pnlGFX.MouseDoubleClick -= mouseEventHandler3;
                    this._pnlGFX.MouseDown -= mouseEventHandler4;
                    this._pnlGFX.DragOver -= dragEventHandler;
                    this._pnlGFX.DragEnter -= dragEventHandler2;
                    this._pnlGFX.DragDrop -= dragEventHandler3;
                }
                this._pnlGFX = value;
                if (this._pnlGFX != null)
                {
                    this._pnlGFX.MouseEnter += eventHandler;
                    this._pnlGFX.MouseLeave += eventHandler2;
                    this._pnlGFX.MouseMove += mouseEventHandler;
                    this._pnlGFX.MouseUp += mouseEventHandler2;
                    this._pnlGFX.MouseDoubleClick += mouseEventHandler3;
                    this._pnlGFX.MouseDown += mouseEventHandler4;
                    this._pnlGFX.DragOver += dragEventHandler;
                    this._pnlGFX.DragEnter += dragEventHandler2;
                    this._pnlGFX.DragDrop += dragEventHandler3;
                }
            }
        }
        internal virtual FlowLayoutPanel pnlGFXFlow
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
                {
                    this._pnlGFXFlow.MouseEnter -= eventHandler;
                }
                this._pnlGFXFlow = value;
                if (this._pnlGFXFlow != null)
                {
                    this._pnlGFXFlow.MouseEnter += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem SetAllIOsToDefault35ToolStripMenuItem
        {
            get
            {
                return this._SetAllIOsToDefault35ToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SetAllIOsToDefault35ToolStripMenuItem = value;
            }
        }
        internal virtual ToolStripMenuItem SlotsToolStripMenuItem
        {
            get
            {
                return this._SlotsToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SlotsToolStripMenuItem = value;
            }
        }
        internal virtual ToolStripMenuItem TemporaryPowersWindowToolStripMenuItem
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
                {
                    this._TemporaryPowersWindowToolStripMenuItem.Click -= eventHandler;
                }
                this._TemporaryPowersWindowToolStripMenuItem = value;
                if (this._TemporaryPowersWindowToolStripMenuItem != null)
                {
                    this._TemporaryPowersWindowToolStripMenuItem.Click += eventHandler;
                }
            }
        }
        internal virtual ImageButton tempPowersButton
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
                if (this._tempPowersButton != null)
                {
                    this._tempPowersButton.MouseDown += mouseEventHandler;
                    this._tempPowersButton.ButtonClicked += clickedEventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tlsDPA
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
                {
                    this._tlsDPA.Click -= eventHandler;
                }
                this._tlsDPA = value;
                if (this._tlsDPA != null)
                {
                    this._tlsDPA.Click += eventHandler;
                }
            }
        }
        internal virtual System.Windows.Forms.Timer tmrGfx
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
                {
                    this._tmrGfx.Tick -= eventHandler;
                }
                this._tmrGfx = value;
                if (this._tmrGfx != null)
                {
                    this._tmrGfx.Tick += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem ToolStripMenuItem1
        {
            get
            {
                return this._ToolStripMenuItem1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripMenuItem1 = value;
            }
        }
        internal virtual ToolStripMenuItem ToolStripMenuItem2
        {
            get
            {
                return this._ToolStripMenuItem2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripMenuItem2 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripMenuItem4
        {
            get
            {
                return this._ToolStripMenuItem4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripMenuItem4 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator1
        {
            get
            {
                return this._ToolStripSeparator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator1 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator10
        {
            get
            {
                return this._ToolStripSeparator10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator10 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator11
        {
            get
            {
                return this._ToolStripSeparator11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator11 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator12
        {
            get
            {
                return this._ToolStripSeparator12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator12 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator13
        {
            get
            {
                return this._ToolStripSeparator13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator13 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator14
        {
            get
            {
                return this._ToolStripSeparator14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator14 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator15
        {
            get
            {
                return this._ToolStripSeparator15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator15 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator16
        {
            get
            {
                return this._ToolStripSeparator16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator16 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator17
        {
            get
            {
                return this._ToolStripSeparator17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator17 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator18
        {
            get
            {
                return this._ToolStripSeparator18;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator18 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator19
        {
            get
            {
                return this._ToolStripSeparator19;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator19 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator2
        {
            get
            {
                return this._ToolStripSeparator2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator2 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator20
        {
            get
            {
                return this._ToolStripSeparator20;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator20 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator21
        {
            get
            {
                return this._ToolStripSeparator21;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator21 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator22
        {
            get
            {
                return this._ToolStripSeparator22;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator22 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator23
        {
            get
            {
                return this._ToolStripSeparator23;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator23 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator24
        {
            get
            {
                return this._ToolStripSeparator24;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator24 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator4
        {
            get
            {
                return this._ToolStripSeparator4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator4 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator5
        {
            get
            {
                return this._ToolStripSeparator5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator5 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator7
        {
            get
            {
                return this._ToolStripSeparator7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator7 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator8
        {
            get
            {
                return this._ToolStripSeparator8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator8 = value;
            }
        }
        internal virtual ToolStripSeparator ToolStripSeparator9
        {
            get
            {
                return this._ToolStripSeparator9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolStripSeparator9 = value;
            }
        }
        internal virtual ToolStripMenuItem tsAbout
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
                {
                    this._tsAbout.Click -= eventHandler;
                }
                this._tsAbout = value;
                if (this._tsAbout != null)
                {
                    this._tsAbout.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsAdvDBEdit
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
                {
                    this._tsAdvDBEdit.Click -= eventHandler;
                }
                this._tsAdvDBEdit = value;
                if (this._tsAdvDBEdit != null)
                {
                    this._tsAdvDBEdit.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsAdvFreshInstall
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
                {
                    this._tsAdvFreshInstall.Click -= eventHandler;
                }
                this._tsAdvFreshInstall = value;
                if (this._tsAdvFreshInstall != null)
                {
                    this._tsAdvFreshInstall.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsAdvResetTips
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
                {
                    this._tsAdvResetTips.Click -= eventHandler;
                }
                this._tsAdvResetTips = value;
                if (this._tsAdvResetTips != null)
                {
                    this._tsAdvResetTips.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsBug
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
                {
                    this._tsBug.Click -= eventHandler;
                }
                this._tsBug = value;
                if (this._tsBug != null)
                {
                    this._tsBug.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsClearAllEnh
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
                {
                    this._tsClearAllEnh.Click -= eventHandler;
                }
                this._tsClearAllEnh = value;
                if (this._tsClearAllEnh != null)
                {
                    this._tsClearAllEnh.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsConfig
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
                {
                    this._tsConfig.Click -= eventHandler;
                }
                this._tsConfig = value;
                if (this._tsConfig != null)
                {
                    this._tsConfig.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsDynamic
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
                {
                    this._tsDynamic.Click -= eventHandler;
                }
                this._tsDynamic = value;
                if (this._tsDynamic != null)
                {
                    this._tsDynamic.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToDO
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
                {
                    this._tsEnhToDO.Click -= eventHandler;
                }
                this._tsEnhToDO = value;
                if (this._tsEnhToDO != null)
                {
                    this._tsEnhToDO.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToEven
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
                {
                    this._tsEnhToEven.Click -= eventHandler;
                }
                this._tsEnhToEven = value;
                if (this._tsEnhToEven != null)
                {
                    this._tsEnhToEven.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToMinus1
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
                {
                    this._tsEnhToMinus1.Click -= eventHandler;
                }
                this._tsEnhToMinus1 = value;
                if (this._tsEnhToMinus1 != null)
                {
                    this._tsEnhToMinus1.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToMinus2
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
                {
                    this._tsEnhToMinus2.Click -= eventHandler;
                }
                this._tsEnhToMinus2 = value;
                if (this._tsEnhToMinus2 != null)
                {
                    this._tsEnhToMinus2.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToMinus3
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
                {
                    this._tsEnhToMinus3.Click -= eventHandler;
                }
                this._tsEnhToMinus3 = value;
                if (this._tsEnhToMinus3 != null)
                {
                    this._tsEnhToMinus3.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToNone
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
                {
                    this._tsEnhToNone.Click -= eventHandler;
                }
                this._tsEnhToNone = value;
                if (this._tsEnhToNone != null)
                {
                    this._tsEnhToNone.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToPlus1
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
                {
                    this._tsEnhToPlus1.Click -= eventHandler;
                }
                this._tsEnhToPlus1 = value;
                if (this._tsEnhToPlus1 != null)
                {
                    this._tsEnhToPlus1.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToPlus2
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
                {
                    this._tsEnhToPlus2.Click -= eventHandler;
                }
                this._tsEnhToPlus2 = value;
                if (this._tsEnhToPlus2 != null)
                {
                    this._tsEnhToPlus2.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToPlus3
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
                {
                    this._tsEnhToPlus3.Click -= eventHandler;
                }
                this._tsEnhToPlus3 = value;
                if (this._tsEnhToPlus3 != null)
                {
                    this._tsEnhToPlus3.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToPlus4
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
                {
                    this._tsEnhToPlus4.Click -= eventHandler;
                }
                this._tsEnhToPlus4 = value;
                if (this._tsEnhToPlus4 != null)
                {
                    this._tsEnhToPlus4.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToPlus5
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
                {
                    this._tsEnhToPlus5.Click -= eventHandler;
                }
                this._tsEnhToPlus5 = value;
                if (this._tsEnhToPlus5 != null)
                {
                    this._tsEnhToPlus5.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToSO
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
                {
                    this._tsEnhToSO.Click -= eventHandler;
                }
                this._tsEnhToSO = value;
                if (this._tsEnhToSO != null)
                {
                    this._tsEnhToSO.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsEnhToTO
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
                {
                    this._tsEnhToTO.Click -= eventHandler;
                }
                this._tsEnhToTO = value;
                if (this._tsEnhToTO != null)
                {
                    this._tsEnhToTO.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsExport
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
                {
                    this._tsExport.Click -= eventHandler;
                }
                this._tsExport = value;
                if (this._tsExport != null)
                {
                    this._tsExport.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsExportDataLink
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
                {
                    this._tsExportDataLink.Click -= eventHandler;
                }
                this._tsExportDataLink = value;
                if (this._tsExportDataLink != null)
                {
                    this._tsExportDataLink.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsExportLong
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
                {
                    this._tsExportLong.Click -= eventHandler;
                }
                this._tsExportLong = value;
                if (this._tsExportLong != null)
                {
                    this._tsExportLong.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFileNew
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
                {
                    this._tsFileNew.Click -= eventHandler;
                }
                this._tsFileNew = value;
                if (this._tsFileNew != null)
                {
                    this._tsFileNew.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFileOpen
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
                {
                    this._tsFileOpen.Click -= eventHandler;
                }
                this._tsFileOpen = value;
                if (this._tsFileOpen != null)
                {
                    this._tsFileOpen.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFilePrint
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
                {
                    this._tsFilePrint.Click -= eventHandler;
                }
                this._tsFilePrint = value;
                if (this._tsFilePrint != null)
                {
                    this._tsFilePrint.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFileQuit
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
                {
                    this._tsFileQuit.Click -= eventHandler;
                }
                this._tsFileQuit = value;
                if (this._tsFileQuit != null)
                {
                    this._tsFileQuit.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFileSave
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
                {
                    this._tsFileSave.Click -= eventHandler;
                }
                this._tsFileSave = value;
                if (this._tsFileSave != null)
                {
                    this._tsFileSave.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFileSaveAs
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
                {
                    this._tsFileSaveAs.Click -= eventHandler;
                }
                this._tsFileSaveAs = value;
                if (this._tsFileSaveAs != null)
                {
                    this._tsFileSaveAs.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsFlipAllEnh
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
                {
                    this._tsFlipAllEnh.Click -= eventHandler;
                }
                this._tsFlipAllEnh = value;
                if (this._tsFlipAllEnh != null)
                {
                    this._tsFlipAllEnh.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsHelp
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
                {
                    this._tsHelp.Click -= eventHandler;
                }
                this._tsHelp = value;
                if (this._tsHelp != null)
                {
                    this._tsHelp.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsHelperLong
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
                {
                    this._tsHelperLong.Click -= eventHandler;
                }
                this._tsHelperLong = value;
                if (this._tsHelperLong != null)
                {
                    this._tsHelperLong.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsHelperLong2
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
                {
                    this._tsHelperLong2.Click -= eventHandler;
                }
                this._tsHelperLong2 = value;
                if (this._tsHelperLong2 != null)
                {
                    this._tsHelperLong2.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsHelperShort
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
                {
                    this._tsHelperShort.Click -= eventHandler;
                }
                this._tsHelperShort = value;
                if (this._tsHelperShort != null)
                {
                    this._tsHelperShort.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsHelperShort2
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
                {
                    this._tsHelperShort2.Click -= eventHandler;
                }
                this._tsHelperShort2 = value;
                if (this._tsHelperShort2 != null)
                {
                    this._tsHelperShort2.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsImport
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
                {
                    this._tsImport.Click -= eventHandler;
                }
                this._tsImport = value;
                if (this._tsImport != null)
                {
                    this._tsImport.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsIODefault
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
                {
                    this._tsIODefault.Click -= eventHandler;
                }
                this._tsIODefault = value;
                if (this._tsIODefault != null)
                {
                    this._tsIODefault.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsIOMax
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
                {
                    this._tsIOMax.Click -= eventHandler;
                }
                this._tsIOMax = value;
                if (this._tsIOMax != null)
                {
                    this._tsIOMax.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsIOMin
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
                {
                    this._tsIOMin.Click -= eventHandler;
                }
                this._tsIOMin = value;
                if (this._tsIOMin != null)
                {
                    this._tsIOMin.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsLevelUp
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
                {
                    this._tsLevelUp.Click -= eventHandler;
                }
                this._tsLevelUp = value;
                if (this._tsLevelUp != null)
                {
                    this._tsLevelUp.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsPatchNotes
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
                {
                    this._tsPatchNotes.Click -= eventHandler;
                }
                this._tsPatchNotes = value;
                if (this._tsPatchNotes != null)
                {
                    this._tsPatchNotes.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsRecipeViewer
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
                {
                    this._tsRecipeViewer.Click -= eventHandler;
                }
                this._tsRecipeViewer = value;
                if (this._tsRecipeViewer != null)
                {
                    this._tsRecipeViewer.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsDPSCalc
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
                {
                    this._tsDPSCalc.Click -= eventHandler;
                }
                this._tsDPSCalc = value;
                if (this._tsDPSCalc != null)
                {
                    this._tsDPSCalc.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsRemoveAllSlots
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
                {
                    this._tsRemoveAllSlots.Click -= eventHandler;
                }
                this._tsRemoveAllSlots = value;
                if (this._tsRemoveAllSlots != null)
                {
                    this._tsRemoveAllSlots.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsSetFind
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
                {
                    this._tsSetFind.Click -= eventHandler;
                }
                this._tsSetFind = value;
                if (this._tsSetFind != null)
                {
                    this._tsSetFind.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsTitanForum
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
                {
                    this._tsTitanForum.Click -= eventHandler;
                }
                this._tsTitanForum = value;
                if (this._tsTitanForum != null)
                {
                    this._tsTitanForum.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsTitanPlanner
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
                {
                    this._tsTitanPlanner.Click -= eventHandler;
                }
                this._tsTitanPlanner = value;
                if (this._tsTitanPlanner != null)
                {
                    this._tsTitanPlanner.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsTitanSite
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
                {
                    this._tsTitanSite.Click -= eventHandler;
                }
                this._tsTitanSite = value;
                if (this._tsTitanSite != null)
                {
                    this._tsTitanSite.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsUpdateCheck
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
                {
                    this._tsUpdateCheck.Click -= eventHandler;
                }
                this._tsUpdateCheck = value;
                if (this._tsUpdateCheck != null)
                {
                    this._tsUpdateCheck.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsView2Col
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
                {
                    this._tsView2Col.Click -= eventHandler;
                }
                this._tsView2Col = value;
                if (this._tsView2Col != null)
                {
                    this._tsView2Col.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsView3Col
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
                {
                    this._tsView3Col.Click -= eventHandler;
                }
                this._tsView3Col = value;
                if (this._tsView3Col != null)
                {
                    this._tsView3Col.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsView4Col
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
                {
                    this._tsView4Col.Click -= eventHandler;
                }
                this._tsView4Col = value;
                if (this._tsView4Col != null)
                {
                    this._tsView4Col.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewActualDamage_New
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
                {
                    this._tsViewActualDamage_New.Click -= eventHandler;
                }
                this._tsViewActualDamage_New = value;
                if (this._tsViewActualDamage_New != null)
                {
                    this._tsViewActualDamage_New.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewData
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
                {
                    this._tsViewData.Click -= eventHandler;
                }
                this._tsViewData = value;
                if (this._tsViewData != null)
                {
                    this._tsViewData.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewDPS_New
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
                {
                    this._tsViewDPS_New.Click -= eventHandler;
                }
                this._tsViewDPS_New = value;
                if (this._tsViewDPS_New != null)
                {
                    this._tsViewDPS_New.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewGraphs
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
                {
                    this._tsViewGraphs.Click -= eventHandler;
                }
                this._tsViewGraphs = value;
                if (this._tsViewGraphs != null)
                {
                    this._tsViewGraphs.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewIOLevels
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
                {
                    this._tsViewIOLevels.Click -= eventHandler;
                }
                this._tsViewIOLevels = value;
                if (this._tsViewIOLevels != null)
                {
                    this._tsViewIOLevels.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewRelative
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
                {
                    this._tsViewRelative.Click -= eventHandler;
                }
                this._tsViewRelative = value;
                if (this._tsViewRelative != null)
                {
                    this._tsViewRelative.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewSetCompare
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
                {
                    this._tsViewSetCompare.Click -= eventHandler;
                }
                this._tsViewSetCompare = value;
                if (this._tsViewSetCompare != null)
                {
                    this._tsViewSetCompare.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewSets
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
                {
                    this._tsViewSets.Click -= eventHandler;
                }
                this._tsViewSets = value;
                if (this._tsViewSets != null)
                {
                    this._tsViewSets.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewSlotLevels
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
                {
                    this._tsViewSlotLevels.Click -= eventHandler;
                }
                this._tsViewSlotLevels = value;
                if (this._tsViewSlotLevels != null)
                {
                    this._tsViewSlotLevels.Click += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem tsViewTotals
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
                {
                    this._tsViewTotals.Click -= eventHandler;
                }
                this._tsViewTotals = value;
                if (this._tsViewTotals != null)
                {
                    this._tsViewTotals.Click += eventHandler;
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
        internal virtual TextBox txtName
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
                {
                    this._txtName.TextChanged -= eventHandler;
                }
                this._txtName = value;
                if (this._txtName != null)
                {
                    this._txtName.TextChanged += eventHandler;
                }
            }
        }
        internal virtual ToolStripMenuItem ViewToolStripMenuItem
        {
            get
            {
                return this._ViewToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ViewToolStripMenuItem = value;
            }
        }
        internal virtual ToolStripMenuItem WindowToolStripMenuItem
        {
            get
            {
                return this._WindowToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._WindowToolStripMenuItem = value;
            }
        }
        public frmMain()
        {
            //base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            //base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("Hero_Designer");

            base.Load += this.frmMain_Load;
            base.Closed += this.frmMain_Closed;
            base.FormClosing += this.frmMain_Closing;
            base.ResizeEnd += this.frmMain_Resize;
            base.KeyDown += this.frmMain_KeyDown;
            base.Resize += this.frmMain_Maximize;
            base.MouseWheel += this.frmMain_MouseWheel;
            this.NoUpdate = false;
            this.EnhancingSlot = -1;
            this.EnhancingPower = -1;
            this.EnhPickerActive = false;
            this.PickerHID = -1;
            this.LastFileName = "";
            this.FileModified = false;
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.LastEnhPlaced = null;
            this.dvLastPower = -1;
            this.dvLastEnh = -1;
            this.dvLastNoLev = true;
            this.DataViewLocked = false;
            this.fGraphCompare = null;
            this.fGraphStats = null;
            this.fSets = null;
            this.fTotals = null;
            this.fRecipe = null;
            this.fData = null;
            this.fSetFinder = null;
            this.fAccolade = null;
            this.fTemp = null;
            this.fIncarnate = null;
            this.fMini = null;
            this.ActivePopupBounds = new Rectangle(0, 0, 1, 1);
            this.LastState = FormWindowState.Normal;
            this.PopUpVisible = false;
            this.FlipSteps = 5;
            this.FlipInterval = 10;
            this.FlipStepDelay = 3;
            this.FlipActive = false;
            this.FlipPowerID = -1;
            this.FlipSlotState = new int[0];
            this.FlipGP = null;
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
        void accoladeButton_ButtonClicked()
        {
            this.PowerModified();
        }
        void accoladeButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                this.accoladeButton.Checked = false;
                bool flag = false;
                if (this.fAccolade == null)
                {
                    flag = true;
                }
                else if (this.fAccolade.IsDisposed)
                {
                    flag = true;
                }
                if (flag)
                {
                    IPower power;
                    if (MainModule.MidsController.Toon.IsHero())
                    {
                        power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3257)];
                    }
                    else
                    {
                        power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3258)];
                    }
                    List<IPower> iPowers = new List<IPower>();
                    int num = power.NIDSubPower.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        iPowers.Add(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
                    }
                    frmMain iParent = this;
                    this.fAccolade = new frmAccolade(ref iParent, iPowers);
                    this.fAccolade.Text = "Accolades";
                }
                if (!this.fAccolade.Visible)
                {
                    this.fAccolade.Show(this);
                }
            }
        }
        void AccoladesWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.accoladeButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
            this.accoladeButton.Checked = true;
        }
        static int ArchetypeIndirectToIndex(int iIndirect)
        {
            int num = -1;
            int num2 = DatabaseAPI.Database.Classes.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (DatabaseAPI.Database.Classes[index].Playable)
                {
                    num++;
                    if (num == iIndirect)
                    {
                        return index;
                    }
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
                if (flag)
                {
                    IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset.nIDTrunkSet];
                    ListLabelV2.ListLabelItemV2 iItem = new ListLabelV2.ListLabelItemV2(powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nIDTrunkSet, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
                    llPower.AddItem(iItem);
                    int num = powerset.Powers.Length - 1;
                    for (int iIDXPower = 0; iIDXPower <= num; iIDXPower++)
                    {
                        if (powerset.Powers[iIDXPower].Level > 0)
                        {
                            string message = "";
                            ListLabelV2.ListLabelItemV2 iItem2 = new ListLabelV2.ListLabelItemV2(powerset.Powers[iIDXPower].DisplayName, MainModule.MidsController.Toon.PowerState(powerset.Powers[iIDXPower].PowerIndex, ref message), Powerset.nIDTrunkSet, iIDXPower, powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
                            {
                                Bold = MidsContext.Config.RtFont.PairedBold
                            };
                            if (iItem2.ItemState == ListLabelV2.LLItemState.Invalid)
                            {
                                iItem2.Italic = true;
                            }
                            llPower.AddItem(iItem2);
                        }
                    }
                }
                if (flag)
                {
                    ListLabelV2.ListLabelItemV2 iItem3 = new ListLabelV2.ListLabelItemV2(Powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nID, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
                    llPower.AddItem(iItem3);
                }
                int num2 = 0;
                int num3 = Powerset.Powers.Length - 1;
                for (int iIDXPower = 0; iIDXPower <= num3; iIDXPower++)
                {
                    if (Powerset.Powers[iIDXPower].Level > 0)
                    {
                        string message = "";
                        ListLabelV2.ListLabelItemV2 iItem4 = new ListLabelV2.ListLabelItemV2(Powerset.Powers[iIDXPower].DisplayName, MainModule.MidsController.Toon.PowerState(Powerset.Powers[iIDXPower].PowerIndex, ref message), Powerset.nID, iIDXPower, Powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
                        {
                            Bold = MidsContext.Config.RtFont.PairedBold
                        };
                        if (iItem4.ItemState == ListLabelV2.LLItemState.Invalid)
                        {
                            iItem4.Italic = true;
                        }
                        llPower.AddItem(iItem4);
                        num2++;
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
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[7] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.cbAncillary.Bounds, ExtraString);
            }
        }
        void cbAncillery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
        }
        void cbAT_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.DrawBackground();
                SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
                if (e.Index > -1)
                {
                    int index = frmMain.ArchetypeIndirectToIndex(e.Index);
                    RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
                    RectangleF srcRect = new RectangleF((float)(index * 16), 0f, 16f, 16f);
                    e.Graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                    {
                        LineAlignment = StringAlignment.Center
                    };
                    RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
                    e.Graphics.DrawString(Conversions.ToString(NewLateBinding.LateGet(this.cbAT.Items[e.Index], null, "DisplayName", new object[0], null, null, null)), e.Font, solidBrush, layoutRectangle, format);
                }
                e.DrawFocusRectangle();
            }
        }
        void cbAT_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }
        void cbAT_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && this.cbAT.SelectedIndex >= 0)
            {
                this.ShowPopup(-1, Conversions.ToInteger(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Idx", new object[0], null, null, null)), this.cbAT.Bounds, "");
            }
        }
        void cbAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.NewToon(false, false);
                this.SetFormHeight(false);
                this.SetAncilPoolHeight();
                this.GetBestDamageValues();
            }
        }
        static void cbDrawItem(ref ComboBox Target, Enums.ePowerSetType SetType, DrawItemEventArgs e)
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.DrawBackground();
                SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
                IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, SetType);
                if (e.Index > -1 & e.Index < powersetIndexes.Length)
                {
                    int nId = powersetIndexes[e.Index].nID;
                    RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
                    RectangleF srcRect = new RectangleF((float)(nId * 16), 0f, 16f, 16f);
                    if ((e.State & DrawItemState.ComboBoxEdit) > DrawItemState.None)
                    {
                        if (e.Graphics.MeasureString(Conversions.ToString(Target.Items[e.Index]), e.Font).Width <= (float)(e.Bounds.Width - 10))
                        {
                            e.Graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                        }
                        else
                        {
                            destRect.Width = 0f;
                        }
                    }
                    else
                    {
                        e.Graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                    {
                        LineAlignment = StringAlignment.Center
                    };
                    RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width, (float)e.Bounds.Height);
                    e.Graphics.DrawString(Conversions.ToString(Target.Items[e.Index]), e.Font, solidBrush, layoutRectangle, format);
                }
                e.DrawFocusRectangle();
            }
        }
        void cbOrigin_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                e.DrawBackground();
                SolidBrush solidBrush = new SolidBrush(SystemColors.ControlText);
                if (e.Index > -1)
                {
                    RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
                    RectangleF srcRect = new RectangleF((float)(DatabaseAPI.GetOriginIDByName(Conversions.ToString(this.cbOrigin.Items[e.Index])) * 16), 0f, 16f, 16f);
                    e.Graphics.DrawImage(I9Gfx.Origins.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                    {
                        LineAlignment = StringAlignment.Center
                    };
                    RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
                    e.Graphics.DrawString(Conversions.ToString(this.cbOrigin.Items[e.Index]), e.Font, solidBrush, layoutRectangle, format);
                }
                e.DrawFocusRectangle();
            }
        }
        void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                MidsContext.Character.Origin = this.cbOrigin.SelectedIndex;
                I9Gfx.SetOrigin(Conversions.ToString(this.cbOrigin.SelectedItem));
                if (this.Drawing != null)
                {
                    this.DoRedraw();
                }
                this.DisplayName();
            }
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
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[3] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
            }
        }
        void cbPool0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
        }
        void cbPool1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool = this.cbPool1;
            frmMain.cbDrawItem(ref cbPool, Enums.ePowerSetType.Pool, e);
            this.cbPool1 = cbPool;
        }
        void cbPool1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[4] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
            }
        }
        void cbPool1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
        }
        void cbPool2_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool2 = this.cbPool2;
            frmMain.cbDrawItem(ref cbPool2, Enums.ePowerSetType.Pool, e);
            this.cbPool2 = cbPool2;
        }
        void cbPool2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[5] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
            }
        }
        void cbPool2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
        }
        void cbPool3_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbPool3 = this.cbPool3;
            frmMain.cbDrawItem(ref cbPool3, Enums.ePowerSetType.Pool, e);
            this.cbPool3 = cbPool3;
        }
        void cbPool3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[6] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
            }
        }
        void cbPool3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
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
            if (MidsContext.Character != null && MidsContext.Character.Archetype != null && this.cbPrimary.SelectedIndex >= 0)
            {
                string ExtraString = "This is your primary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
                this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Primary)[this.cbPrimary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbPrimary.Bounds, ExtraString);
            }
        }
        void cbPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
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
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Archetype.Idx >= 0 && this.cbSecondary.SelectedIndex >= 0)
            {
                string ExtraString;
                if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                {
                    ExtraString = "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
                }
                else
                {
                    ExtraString = "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
                }
                this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
            }
        }
        void cbSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.NoUpdate)
            {
                this.ChangeSets();
                this.UpdatePowerLists();
            }
        }
        void ChangeSets()
        {
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Primary);
            IPowerset[] powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary);
            IPowerset[] powersetIndexes3 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Pool);
            IPowerset[] powersetIndexes4 = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Ancillary);
            if (MainModule.MidsController.Toon != null)
            {
                IPowerset powerset2 = MidsContext.Character.Powersets[0];
                IPowerset newPowerset2 = powersetIndexes[this.cbPrimary.SelectedIndex];
                if (powerset2.nID != newPowerset2.nID)
                {
                    MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
                }
                if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                {
                    powerset2 = MidsContext.Character.Powersets[1];
                    newPowerset2 = DatabaseAPI.Database.Powersets[MidsContext.Character.Powersets[0].nIDLinkSecondary];
                    if (powerset2.nID != newPowerset2.nID)
                    {
                        MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
                    }
                }
                else
                {
                    this.cbSecondary.Enabled = true;
                    powerset2 = MidsContext.Character.Powersets[1];
                    newPowerset2 = powersetIndexes2[this.cbSecondary.SelectedIndex];
                    if (powerset2.nID != newPowerset2.nID)
                    {
                        MainModule.MidsController.Toon.SwitchSets(newPowerset2, powerset2);
                    }
                }
            }
            else
            {
                MidsContext.Character.Powersets[0] = powersetIndexes[this.cbPrimary.SelectedIndex];
                MidsContext.Character.Powersets[1] = powersetIndexes2[this.cbSecondary.SelectedIndex];
            }
            MidsContext.Character.Powersets[3] = powersetIndexes3[this.cbPool0.SelectedIndex];
            MidsContext.Character.Powersets[4] = powersetIndexes3[this.cbPool1.SelectedIndex];
            MidsContext.Character.Powersets[5] = powersetIndexes3[this.cbPool2.SelectedIndex];
            MidsContext.Character.Powersets[6] = powersetIndexes3[this.cbPool3.SelectedIndex];
            if (powersetIndexes4.Length > 0)
            {
                MidsContext.Character.Powersets[7] = powersetIndexes4[this.cbAncillary.SelectedIndex];
            }
            MidsContext.Character.Validate();
            this.DataViewLocked = false;
            base.ActiveControl = this.llPrimary;
            this.PowerModified();
            this.FloatUpdate(true);
            this.GetBestDamageValues();
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void CheckForDownloadedUpdate()
        {
            try
            {
                if (File.Exists(FileIO.AddSlash(Application.StartupPath) + "MHD.mhz") && Zlib.CheckTag(FileIO.AddSlash(Application.StartupPath) + "MHD.mhz"))
                {
                    Interaction.MsgBox("A recently downloaded update pack has not yet been applied!\r\n\r\nIn order for a previously downloaded update to be applied, Mids' Hero/Villain designer must restart.\r\n\r\nThe program will now exit to apply the update. Please close any other running instances of Mids' Hero/Villain Designer.If this message is in error, please delete the MHD.mhz file from " + Application.StartupPath + " directory.", MsgBoxStyle.Information, "Update Pending");
                    clsXMLUpdate.LaunchSelfUpdate();
                    ProjectData.EndApp();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("An unexpected error was encountered when checking for a downloaded pack.\r\nIf you see this error again, delete the 'MHD.mhz' file from the " + Application.StartupPath + " directory.", MsgBoxStyle.Exclamation, "Non-Fatal Error");
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
        public bool CloseCommand()
        {
            bool flag = false;
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
                    MsgBoxResult msgBoxResult = Interaction.MsgBox("Do you wish to save your hero/villain data before quitting?", MsgBoxStyle.OkCancel | MsgBoxStyle.AbortRetryIgnore | MsgBoxStyle.Question, "Question");
                    this.FloatTop(true);
                    if (msgBoxResult == MsgBoxResult.Cancel)
                    {
                        return true;
                    }
                    if (msgBoxResult == MsgBoxResult.Yes && !this.doSave())
                    {
                        flag = true;
                    }
                }
                flag2 = flag;
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
                for (int index = 0; index <= num; index++)
                {
                    if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(this.cbAT.Items[index], null, "Idx", new object[0], null, null, null), playableClasses[index].Idx, false))
                    {
                        return true;
                    }
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
                    for (int index = 0; index <= num; index++)
                    {
                        if (Conversions.ToString(this.cbOrigin.Items[index]) != MidsContext.Character.Archetype.Origin[index])
                        {
                            return true;
                        }
                    }
                }
                flag = false;
            }
            return flag;
        }
        static bool ComboCheckPool(ref ComboBox iCB, Enums.ePowerSetType iSetType)
        {
            bool flag = false;
            bool flag2 = false;
            string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
            if (iCB.Items.Count != powersetNames.Length)
            {
                flag2 = true;
            }
            else
            {
                int num = iCB.Items.Count - 1;
                for (int index = 0; index <= num; index++)
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
                iCB.Items.AddRange(powersetNames);
                iCB.EndUpdate();
                flag3 = flag;
            }
            return flag3;
        }
        static bool ComboCheckPS(ref ComboBox iCB, Enums.PowersetType iSetID, Enums.ePowerSetType iSetType)
        {
            bool flag = false;
            bool flag2 = false;
            string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
            if (iCB.Items.Count != powersetNames.Length)
            {
                flag2 = true;
            }
            int num = iCB.Items.Count - 1;
            for (int index = 0; index <= num; index++)
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
                iCB.Items.AddRange(powersetNames);
                iCB.EndUpdate();
            }
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, iSetType);
            iCB.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[(int)iSetID], powersetIndexes);
            return flag;
        }
        void command_ForumImport()
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                MsgBoxResult msgBoxResult = Interaction.MsgBox("Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Question");
                this.FloatTop(true);
                if (msgBoxResult == MsgBoxResult.No)
                {
                    return;
                }
            }
            this.FloatTop(false);
            this.FileModified = false;
            bool flag = false;
            if (Interaction.MsgBox("Copy the build data on the forum to the clipboard. When that's done, click on OK.", MsgBoxStyle.OkCancel | MsgBoxStyle.Information, "Standing By") == MsgBoxResult.Ok)
            {
                string str = Clipboard.GetDataObject().GetData("System.String", true).ToString();
                this.NewToon(true, false);
                try
                {
                    if (str.Length < 1)
                    {
                        Interaction.MsgBox("No data. Please check that you copied the build data from the forum correctly and that it's a valid format.", MsgBoxStyle.Information, "Forum Import");
                    }
                    else
                    {
                        if (str.Contains("MxDz") | str.Contains("MxDu"))
                        {
                            ASCIIEncoding asciiencoding = new ASCIIEncoding();
                            MemoryStream memoryStream = new MemoryStream(asciiencoding.GetBytes(str));
                            Stream mStream = memoryStream;
                            memoryStream = (MemoryStream)mStream;
                            flag = MainModule.MidsController.Toon.Load("", ref mStream);
                        }
                        else if (str.Contains("Character Profile:") || str.Contains("build.txt"))
                        {
                            this.GameImport(str);
                            flag = true;
                        }
                        if (!flag)
                        {
                            flag = MainModule.MidsController.Toon.StringToInternalData(str);
                        }
                        if (flag)
                        {
                            this.Drawing.Highlight = -1;
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
                        if (this.Drawing != null)
                        {
                            this.DoRedraw();
                        }
                        this.UpdateColours(false);
                        this.FloatTop(true);
                    }
                }
                catch (Exception ex)
                {
                    this.FloatTop(true);
                }
            }
        }
        void command_New()
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                MsgBoxResult msgBoxResult = Interaction.MsgBox("Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Question");
                this.FloatTop(true);
                if (msgBoxResult == MsgBoxResult.No)
                {
                    return;
                }
            }
            this.DataViewLocked = false;
            this.NewToon(false, false);
            MidsContext.Config.LastFileName = "";
            this.LastFileName = "";
            this.PowerModified();
            this.SetTitleBar(true);
            this.myDataView.Clear();
        }
        public void DataView_SlotFlip(int PowerIndex)
        {
            this.StartFlip(PowerIndex);
        }
        public void DataView_SlotUpdate()
        {
            this.DoRedraw();
            this.RefreshInfo();
        }
        static PowerEntry[] DeepCopyPowerList()
        {
            PowerEntry[] powerEntryArray = new PowerEntry[MidsContext.Character.CurrentBuild.Powers.Count - 1 + 1];
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                powerEntryArray[index] = (PowerEntry)MidsContext.Character.CurrentBuild.Powers[index].Clone();
            }
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
        public void DisplayName()
        {
            string str = "";
            string str2 = "";
            int level = MidsContext.Character.Level;
            int num = MidsContext.Character.CurrentBuild.TotalSlotsAvailable - MidsContext.Character.CurrentBuild.SlotsPlaced;
            int num2 = MidsContext.Character.CurrentBuild.LastPower + 1 - MidsContext.Character.CurrentBuild.PowersPlaced;
            if (!(num < 1 & num2 < 1) && MidsContext.Character.Level > 0)
            {
                str = " (Placing " + Conversions.ToString(MidsContext.Character.Level + 1) + ")";
            }
            this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
            string str3 = MidsContext.Character.Name + ": ";
            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp & str != "")
            {
                str3 = string.Concat(new string[]
                {
                    str3,
                    "Level ",
                    Conversions.ToString(level),
                    str,
                    " "
                });
            }
            str3 = str3 + MidsContext.Character.Archetype.Origin[MidsContext.Character.Origin] + " " + MidsContext.Character.Archetype.DisplayName;
            if (MainModule.MidsController.Toon.Locked)
            {
                str3 = string.Concat(new string[]
                {
                    str3,
                    " (",
                    MidsContext.Character.Powersets[0].DisplayName,
                    " / ",
                    MidsContext.Character.Powersets[1].DisplayName,
                    ")",
                    str2
                });
            }
            if (MidsContext.Config.ExempLow < MidsContext.Config.ExempHigh)
            {
                str3 = string.Concat(new string[]
                {
                    str3,
                    " - Exemped from ",
                    Conversions.ToString(MidsContext.Config.ExempHigh),
                    " to ",
                    Conversions.ToString(MidsContext.Config.ExempLow)
                });
            }
            this.lblHero.Text = str3;
            if (this.txtName.Text != MidsContext.Character.Name)
            {
                this.txtName.Text = MidsContext.Character.Name;
            }
        }
        void doFlipStep()
        {
            if (this.FlipActive)
            {
                Point point = default(Point);
                Build currentBuild = MidsContext.Character.CurrentBuild;
                int flipPowerId = this.FlipPowerID;
                PowerEntry power = currentBuild.Powers[flipPowerId];
                currentBuild.Powers[flipPowerId] = power;
                Point point2 = this.Drawing.DrawPowerSlot(ref power, false);
                int index = -1;
                int Enh = -1;
                int Enh2 = -1;
                I9Slot i9Slot = null;
                I9Slot i9Slot2 = null;
                ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MainModule.MidsController.Toon.IsHero());
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
                int num = this.FlipSlotState.Length - 1;
                Rectangle rectangle;
                for (int Index = 0; Index <= num; Index++)
                {
                    point.X = (int)Math.Round((double)point2.X + (double)(this.Drawing.szPower.Width - this.Drawing.szSlot.Width * 6) / 2.0);
                    point.Y = point2.Y + 18;
                    int[] flipSlotState = this.FlipSlotState;
                    flipPowerId = Index;
                    flipSlotState[flipPowerId]++;
                    float num2 = 1f;
                    if (this.FlipSlotState[Index] < 0)
                    {
                        index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                        Enh = index;
                        Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                        i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                        i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                    }
                    else if (this.FlipSlotState[Index] > this.FlipSteps)
                    {
                        index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                        Enh = index;
                        Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                        i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                        i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                    }
                    if (this.FlipSlotState[Index] >= 0 & this.FlipSlotState[Index] <= this.FlipSteps)
                    {
                        num2 = (float)((double)this.FlipSlotState[Index] / ((double)this.FlipSteps / 2.0));
                        if (num2 > 1f)
                        {
                            num2 = -1f * (1f - num2);
                            index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                            Enh = index;
                            Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                            i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                            i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                        }
                        else
                        {
                            num2 = 1f - num2;
                            index = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement.Enh;
                            Enh = index;
                            Enh2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement.Enh;
                            i9Slot = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].FlippedEnhancement;
                            i9Slot2 = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Enhancement;
                        }
                    }
                    rectangle = new Rectangle(point.X + 30 * Index, point.Y, 30, 30);
                    if (num2 > 0f)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Math.Round((double)((float)rectangle.X + (30f - 30f * num2) / 2f)), rectangle.Y, (int)Math.Round((double)(30f * num2)), 30);
                        rectangle2 = this.Drawing.ScaleDown(rectangle2);
                        rectangle = this.Drawing.ScaleDown(rectangle);
                        if (index > -1)
                        {
                            Graphics graphics = this.Drawing.bxBuffer.Graphics;
                            I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle, num2, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[index].TypeID, i9Slot.Grade));
                        }
                        else
                        {
                            this.Drawing.bxBuffer.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, GraphicsUnit.Pixel, recolourIa);
                        }
                        if (MidsContext.Config.CalcEnhLevel == Enums.eEnhRelative.None | MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].Slots[Index].Level >= MidsContext.Config.ForceLevel | (this.Drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].StatInclude))
                        {
                            rectangle2.Inflate(1, 1);
                            this.Drawing.bxBuffer.Graphics.FillEllipse(solidBrush, rectangle2);
                        }
                        if (!(this.myDataView == null | i9Slot == null | i9Slot2 == null))
                        {
                            this.myDataView.FlipStage(Index, Enh, Enh2, num2, MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID].NIDPower, i9Slot.Grade, i9Slot2.Grade);
                        }
                    }
                }
                rectangle = new Rectangle(point.X - 1, point.Y - 1, this.Drawing.szPower.Width + 1, this.Drawing.szSlot.Height + 1);
                this.Drawing.Refresh(this.Drawing.ScaleDown(rectangle));
                if (this.FlipSlotState[this.FlipSlotState.Length - 1] >= this.FlipSteps)
                {
                    this.EndFlip();
                }
            }
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
                Stream mStream = null;
                if (fName.Contains(".txt"))
                {
                    this.GameImport(fName);
                }
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
                    {
                        MidsContext.Config.LastFileName = fName;
                    }
                }
                this.FileModified = false;
                this.Drawing.Highlight = -1;
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
        public void DoRedraw()
        {
            this.NoResizeEvent = true;
            int num3 = this.pnlGFXFlow.Width;
            int num4 = this.pnlGFXFlow.Height;
            double num5 = 1.0;
            Size drawingArea = this.Drawing.GetDrawingArea();
            int num6 = 30;
            num3 -= num6;
            if (num3 < drawingArea.Width)
            {
                num5 = (double)num3 / (double)drawingArea.Width;
            }
            num4 = (int)Math.Round((double)drawingArea.Height * num5);
            this.pnlGFX.Width = num3;
            this.pnlGFX.Height = num4;
            this.pnlGFX.Update();
            this.pnlGFXFlow.Update();
            this.NoResizeEvent = false;
            this.Drawing.FullRedraw();
        }
        void DoResize()
        {
            this.lblHero.Width = this.ibRecipe.Left - 4;
            if (!this.NoResizeEvent && this.Drawing != null)
            {
                int num5 = base.ClientSize.Width - this.pnlGFXFlow.Left;
                int num6 = base.ClientSize.Height - this.pnlGFXFlow.Top;
                this.pnlGFXFlow.Width = num5;
                this.pnlGFXFlow.Height = num6;
                double num7 = 1.0;
                Size drawingArea = this.Drawing.GetDrawingArea();
                int num8 = 30;
                num5 -= num8;
                if (num5 < drawingArea.Width)
                {
                    num7 = (double)num5 / (double)drawingArea.Width;
                }
                num6 = (int)Math.Round((double)drawingArea.Height * num7);
                this.pnlGFX.Width = num5;
                this.pnlGFX.Height = num6;
                if ((this.Drawing.Scaling & num7 == 1.0) | num7 != 1.0)
                {
                    this.Drawing.bxBuffer.Size = this.pnlGFX.Size;
                    Control pnlGfx = this.pnlGFX;
                    this.Drawing.ReInit(ref pnlGfx);
                    this.pnlGFX = (PictureBox)pnlGfx;
                    this.pnlGFX.Image = this.Drawing.bxBuffer.Bitmap;
                }
                this.NoResizeEvent = true;
                if (num7 < 1.0)
                {
                    this.Drawing.SetScaling(this.pnlGFX.Size);
                }
                else
                {
                    this.Drawing.SetScaling(this.Drawing.bxBuffer.Size);
                }
                this.NoResizeEvent = false;
                this.ReArrange(false);
            }
        }
        bool doSave()
        {
            bool flag;
            if (this.LastFileName == "")
            {
                flag = this.doSaveAs();
            }
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
                {
                    this.dlgSave.FileName = this.dlgSave.FileName.Substring(0, this.dlgSave.FileName.Length - 3) + this.dlgSave.DefaultExt;
                }
                this.dlgSave.InitialDirectory = this.LastFileName.Substring(0, this.LastFileName.LastIndexOf("\\", StringComparison.Ordinal));
            }
            else if (MidsContext.Character.Name != "")
            {
                if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
                {
                    this.dlgSave.FileName = MidsContext.Character.Name + " - Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", "").Replace("Arachnos ", "");
                }
                else
                {
                    this.dlgSave.FileName = string.Concat(new string[]
                    {
                        MidsContext.Character.Name,
                        " - ",
                        MidsContext.Character.Archetype.DisplayName,
                        " (",
                        MidsContext.Character.Powersets[0].DisplayName,
                        ")"
                    });
                }
            }
            else if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
            {
                this.dlgSave.FileName = "Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", "").Replace("Arachnos ", "");
            }
            else
            {
                this.dlgSave.FileName = MidsContext.Character.Archetype.DisplayName;
                SaveFileDialog dlgSave = this.dlgSave;
                dlgSave.FileName = string.Concat(new string[]
                {
                    dlgSave.FileName,
                    " - ",
                    MidsContext.Character.Powersets[0].DisplayName,
                    " - ",
                    MidsContext.Character.Powersets[1].DisplayName
                });
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
            this.FloatingDataForm.Left = base.Left + this.dvAnchored.Left;
            this.FloatingDataForm.Top = base.Top + this.dvAnchored.Top;
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
            if (this.dvLastPower > -1)
            {
                this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
            }
        }
        void dvAnchored_Move()
        {
            this.PriSec_ExpandChanged(true);
            this.ReArrange(false);
        }
        void dvAnchored_SizeChange(Size newSize, bool Compact)
        {
            this.ReArrange(false);
            if (MainModule.MidsController.IsAppInitialized & base.Visible)
            {
                MidsContext.Config.DvState = this.dvAnchored.VisibleSize;
            }
        }
        void dvAnchored_TabChanged(int Index)
        {
            this.SetDataViewTab(Index);
        }
        void dvAnchored_Unlock()
        {
            this.DataViewLocked = false;
            if (this.dvLastPower > -1)
            {
                this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
            }
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
                int num = MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    iPowers.Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers[index].nIDPower]);
                }
                frmMain iParent = this;
                new frmAccolade(ref iParent, iPowers)
                {
                    Text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower].DisplayName
                }.ShowDialog(this);
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
                Size size = base.ClientSize;
                int height = size.Height - this.dvAnchored.Height - this.cbPrimary.Top - this.cbPrimary.Height - 10;
                if (this.llPrimary.DesiredHeight < height)
                {
                    size = this.llPrimary.SizeNormal;
                    Size sizeNormal = new Size(size.Width, this.llPrimary.DesiredHeight);
                    this.llPrimary.SizeNormal = sizeNormal;
                }
                else
                {
                    if (height < 70)
                    {
                        height = 70;
                    }
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
                    {
                        height = 70;
                    }
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
            if (MainModule.MidsController.Toon != null)
            {
                int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet != null)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet.DisplayName == "Temporary Powers")
                        {
                            MidsContext.Character.CurrentBuild.Powers[index].StatInclude = this.tempPowersButton.Checked;
                        }
                        else if (MidsContext.Character.CurrentBuild.Powers[index].PowerSet.DisplayName == "Accolades")
                        {
                            MidsContext.Character.CurrentBuild.Powers[index].StatInclude = this.accoladeButton.Checked;
                        }
                    }
                }
            }
        }
        public void FloatCompareGraph(bool Show)
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
            else if (this.fGraphCompare != null)
            {
                this.fGraphCompare.Hide();
                this.fGraphCompare.Dispose();
                this.fGraphCompare = null;
            }
        }
        public void FloatData(bool Show)
        {
            if (Show)
            {
                if (this.fData == null)
                {
                    frmMain iParent = this;
                    this.fData = new frmData(ref iParent);
                }
                this.fData.SetLocation();
                this.fData.Show();
                this.FloatUpdate(false);
                this.fData.Activate();
            }
            else if (this.fData != null)
            {
                this.fData.Hide();
                this.fData.Dispose();
                this.fData = null;
            }
        }
        public void FloatRecipe(bool Show)
        {
            if (Show)
            {
                if (this.fRecipe == null)
                {
                    this.fRecipe = new frmRecipeViewer(this);
                }
                this.fRecipe.SetLocation();
                this.fRecipe.Show();
                this.FloatUpdate(false);
                this.fRecipe.Activate();
            }
            else if (this.fRecipe != null)
            {
                this.fRecipe.Hide();
                this.fRecipe.Dispose();
                this.fRecipe = null;
            }
        }
        public void FloatDPSCalc(bool Show)
        {
            if (Show)
            {
                if (this.fDPSCalc == null)
                {
                    this.fDPSCalc = new frmDPSCalc(this);
                }
                this.fDPSCalc.SetLocation();
                this.fDPSCalc.Show();
                this.FloatUpdate(false);
                this.fDPSCalc.Activate();
            }
            else if (this.fDPSCalc != null)
            {
                this.fDPSCalc.Hide();
                this.fDPSCalc = null;
            }
        }
        public void FloatSetFinder(bool Show)
        {
            if (Show)
            {
                if (this.fSetFinder == null)
                {
                    this.fSetFinder = new frmSetFind(this);
                }
                this.fSetFinder.Show();
                this.fSetFinder.Activate();
            }
            else if (this.fSetFinder != null)
            {
                this.fSetFinder.Hide();
                this.fSetFinder.Dispose();
                this.fSetFinder = null;
            }
        }
        public void FloatSets(bool Show)
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
            else if (this.fSets != null)
            {
                this.fSets.Hide();
                this.fSets.Dispose();
                this.fSets = null;
            }
        }
        public void FloatStatGraph(bool Show)
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
            else if (this.fGraphStats != null)
            {
                this.fGraphStats.Hide();
                this.fGraphStats.Dispose();
                this.fGraphStats = null;
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
                    {
                        this.fSets.TopMost = false;
                    }
                }
                if (this.fGraphStats != null)
                {
                    this.top_fGraphStats = this.fGraphStats.TopMost;
                    if (this.fGraphStats.TopMost)
                    {
                        this.fGraphStats.TopMost = false;
                    }
                }
                if (this.fGraphCompare != null)
                {
                    this.top_fGraphCompare = this.fGraphCompare.TopMost;
                    if (this.fGraphCompare.TopMost)
                    {
                        this.fGraphCompare.TopMost = false;
                    }
                }
                if (this.fTotals != null)
                {
                    this.top_fTotals = this.fTotals.TopMost;
                    if (this.fTotals.TopMost)
                    {
                        this.fTotals.TopMost = false;
                    }
                }
                if (this.fRecipe != null)
                {
                    this.top_fRecipe = this.fRecipe.TopMost;
                    if (this.fRecipe.TopMost)
                    {
                        this.fRecipe.TopMost = false;
                    }
                }
                if (this.fData != null)
                {
                    this.top_fData = this.fData.TopMost;
                    if (this.fData.TopMost)
                    {
                        this.fData.TopMost = false;
                    }
                }
                if (this.fSetFinder != null)
                {
                    this.top_fSetFinder = this.fSetFinder.TopMost;
                    if (this.fSetFinder.TopMost)
                    {
                        this.fSetFinder.TopMost = false;
                    }
                }
            }
            else
            {
                base.BringToFront();
                if (this.fSets != null && this.fSets.TopMost != this.top_fSets)
                {
                    this.fSets.TopMost = this.top_fSets;
                    if (this.fSets.TopMost)
                    {
                        this.fSets.BringToFront();
                    }
                }
                if (this.fGraphStats != null && this.fGraphStats.TopMost != this.top_fGraphStats)
                {
                    this.fGraphStats.TopMost = this.top_fGraphStats;
                    if (this.fGraphStats.TopMost)
                    {
                        this.fGraphStats.BringToFront();
                    }
                }
                if (this.fGraphCompare != null && this.fGraphCompare.TopMost != this.top_fGraphCompare)
                {
                    this.fGraphCompare.TopMost = this.top_fGraphCompare;
                    if (this.fGraphCompare.TopMost)
                    {
                        this.fGraphCompare.BringToFront();
                    }
                }
                if (this.fTotals != null && this.fTotals.TopMost != this.top_fTotals)
                {
                    this.fTotals.TopMost = this.top_fTotals;
                    if (this.fTotals.TopMost)
                    {
                        this.fTotals.BringToFront();
                    }
                }
                if (this.fRecipe != null && this.fRecipe.TopMost != this.top_fRecipe)
                {
                    this.fRecipe.TopMost = this.top_fRecipe;
                    if (this.fRecipe.TopMost)
                    {
                        this.fRecipe.BringToFront();
                    }
                }
                if (this.fData != null && this.fData.TopMost != this.top_fData)
                {
                    this.fData.TopMost = this.top_fData;
                    if (this.fData.TopMost)
                    {
                        this.fData.BringToFront();
                    }
                }
                if (this.fSetFinder != null && this.fSetFinder.TopMost != this.top_fSetFinder)
                {
                    this.fSetFinder.TopMost = this.top_fSetFinder;
                    if (this.fSetFinder.TopMost)
                    {
                        this.fSetFinder.BringToFront();
                    }
                }
            }
        }
        public void FloatTotals(bool Show)
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
            else if (this.fTotals != null)
            {
                this.fTotals.Hide();
                this.fTotals.Dispose();
                this.fTotals = null;
            }
        }
        void FloatUpdate(bool NewData = false)
        {
            if (this.fSets != null)
            {
                this.fSets.UpdateData();
            }
            if (this.fGraphStats != null)
            {
                this.fGraphStats.UpdateData(NewData);
            }
            if (this.fTotals != null)
            {
                this.fTotals.UpdateData();
            }
            if (this.fGraphCompare != null)
            {
                this.fGraphCompare.UpdateData();
            }
            if (this.fRecipe != null)
            {
                this.fRecipe.UpdateData();
            }
            if (this.fDPSCalc != null)
            {
                this.fDPSCalc.UpdateData();
            }
            if (this.fData != null)
            {
                this.fData.UpdateData(this.dvLastPower);
            }
        }
        void frmMain_Closed(object sender, EventArgs e)
        {
            MidsContext.Config.LastSize = base.Size;
            MidsContext.Config.SaveConfig();
        }
        void frmMain_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.CloseCommand();
        }
        void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt & e.Control & e.Shift & e.KeyCode == Keys.A)
            {
                this.tsAdvFreshInstall.Visible = true;
                MidsContext.Config.MasterMode = true;
                this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (MidsContext.Config.I9.DefaultIOLevel == 27)
                {
                    MidsContext.Config.I9.DefaultIOLevel = 49;
                }
                int height = 0;
                int width = 0;
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
                    IMessager iLoadFrm = iFrm;
                    clsXmlUpdate.UpdateCheck(true, ref iLoadFrm);
                    iFrm = (frmLoading)iLoadFrm;
                }
                if (MidsContext.Config.FreshInstall)
                {
                    if (Interaction.MsgBox("Welcome to Mids' Hero Designer " + Strings.Format(1.962f, "#0.00") + "! Please check the Readme/Help for quick instructions.\r\n\r\nMids' Hero Designer is able to check for and download updates automatically when it starts.\r\nIt's recommended that you turn on automatic updating. Do you want to?\r\n\r\n(If you don't, you can manually check from the 'Updates' tab in the options.)", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Welcome!") == MsgBoxResult.Yes)
                    {
                        MidsContext.Config.CheckForUpdates = true;
                    }
                    else
                    {
                        MidsContext.Config.CheckForUpdates = false;
                    }
                    MidsContext.Config.DefaultSaveFolder = "";
                    MidsContext.Config.CreateDefaultSaveFolder();
                    MidsContext.Config.FreshInstall = false;
                }
                string str3 = Interaction.Command();
                if (str3.IndexOf("RECOVERY", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    Interaction.MsgBox("As recovery mode has been invoked, you will be redirected to the download site for the most recent full install package.", MsgBoxStyle.Information, "Recovery Mode");
                    clsXMLUpdate.GoToCoHPlanner();
                    ProjectData.EndApp();
                }
                if (str3.IndexOf("MASTERMODE=YES", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    MidsContext.Config.MasterMode = true;
                }
                MainModule.MidsController.LoadData(ref iFrm);
                this.dvAnchored.VisibleSize = MidsContext.Config.DvState;
                this.SetTitleBar(true);
                this.NewToon(true, false);
                this.dvAnchored.Init();
                this.cbAT.SelectedItem = MidsContext.Character.Archetype;
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
                int num = this.pnlGFXFlow.Top + this.Drawing.GetRequiredDrawingArea().Height;
                if (num < this.dvAnchored.Top + this.dvAnchored.Height + 48)
                {
                    num = this.dvAnchored.Top + this.dvAnchored.Height + 48;
                }
                if (Screen.PrimaryScreen.WorkingArea.Width > MidsContext.Config.LastSize.Width & MidsContext.Config.LastSize.Width >= this.MinimumSize.Width)
                {
                    if (this.MaximumSize.Width > 0 & this.MaximumSize.Width - MidsContext.Config.LastSize.Width < 32 & Screen.PrimaryScreen.WorkingArea.Width > this.MaximumSize.Width)
                    {
                        width = this.MaximumSize.Width;
                    }
                    else
                    {
                        width = MidsContext.Config.LastSize.Width;
                    }
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width <= MidsContext.Config.LastSize.Width)
                {
                    width = Screen.PrimaryScreen.WorkingArea.Width - (base.Size.Width - base.ClientSize.Width);
                }
                Size size2 = this.MinimumSize;
                if (Screen.PrimaryScreen.WorkingArea.Height > MidsContext.Config.LastSize.Height & MidsContext.Config.LastSize.Height >= size2.Height)
                {
                    height = MidsContext.Config.LastSize.Height;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Height <= MidsContext.Config.LastSize.Height)
                {
                    size2 = base.Size;
                    height = Screen.PrimaryScreen.WorkingArea.Height - (size2.Height - base.ClientSize.Height);
                }
                size2 = new Size(width, height);
                base.Size = size2;
                this.tsView2Col.Checked = (MidsContext.Config.Columns == 2);
                this.tsView3Col.Checked = (MidsContext.Config.Columns == 3);
                this.tsView4Col.Checked = (MidsContext.Config.Columns == 4);
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
                string str4 = Files.FPathAppData + "patch.rtf";
                if (File.Exists(str4))
                {
                    new frmReadme(str4)
                    {
                        btnClose =
                        {
                            IA = this.Drawing.pImageAttributes,
                            ImageOff = this.Drawing.bxPower[2].Bitmap,
                            ImageOn = this.Drawing.bxPower[3].Bitmap
                        }
                    }.ShowDialog();
                    if (File.Exists(Files.FPathAppData + "patchnotes.rtf"))
                    {
                        File.Delete(Files.FPathAppData + "patchnotes.rtf");
                    }
                    File.Move(Files.FPathAppData + "patch.rtf", Files.FPathAppData + "patchnotes.rtf");
                }
                if (str3 != "")
                {
                    str3 = str3.Replace("\"", "");
                    if (File.Exists(str3.Trim()) && !this.DoOpen(str3.Trim()))
                    {
                        this.PowerModified();
                    }
                }
                else if (MidsContext.Config.LoadLastFileOnStart && !this.DoOpen(MidsContext.Config.LastFileName))
                {
                    this.PowerModified();
                }
                if (MidsContext.Config.MasterMode)
                {
                    this.tsAdvFreshInstall.Visible = true;
                    this.tsAdvResetTips.Visible = true;
                }
                base.Show();
                iFrm.Hide();
                iFrm.Close();
                iFrm = null;
                this.Refresh();
                this.dvAnchored.SetScreenBounds(base.ClientRectangle);
                Point iLocation = new Point(this.llPrimary.Left, this.llPrimary.Top + this.llPrimary.SizeNormal.Height + 5);
                this.dvAnchored.SetLocation(iLocation, true);
                this.PriSec_ExpandChanged(true);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                MessageBox.Show("An error has occurred when loading the main form. Error: " + ex2.Message, "OMIGODHAX");
                throw;
            }
        }
        void frmMain_Maximize(object sender, EventArgs e)
        {
            if (base.WindowState != this.LastState)
            {
                this.frmMain_Resize(RuntimeHelpers.GetObjectValue(sender), e);
            }
            this.LastState = base.WindowState;
        }
        void frmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            this.dvAnchored.info_txtLarge.Focus();
        }
        void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.dvAnchored != null)
            {
                this.dvAnchored.SetScreenBounds(base.ClientRectangle);
                if (base.WindowState == FormWindowState.Minimized)
                {
                    if (!this.dvAnchored.Visible)
                    {
                        if (this.FloatingDataForm != null)
                        {
                            this.FloatingDataForm.Visible = false;
                        }
                        return;
                    }
                    return;
                }
                else if (!this.dvAnchored.Visible && this.FloatingDataForm != null)
                {
                    this.FloatingDataForm.Visible = true;
                }
            }
            if (!this.NoResizeEvent & MainModule.MidsController.IsAppInitialized & base.Visible)
            {
                MidsContext.Config.LastSize = base.Size;
            }
            this.UpdateControls(false);
        }
        public void GetBestDamageValues()
        {
            if (MainModule.MidsController.Toon != null)
            {
                float num = 0f;
                int num2 = MidsContext.Character.Powersets[0].Powers.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    IPower power = MidsContext.Character.Powersets[0].Powers[index];
                    if (!power.SkipMax)
                    {
                        float damageValue = power.FXGetDamageValue();
                        if (damageValue > num)
                        {
                            num = damageValue;
                        }
                    }
                }
                int num3 = MidsContext.Character.Powersets[1].Powers.Length - 1;
                for (int index = 0; index <= num3; index++)
                {
                    IPower power2 = MidsContext.Character.Powersets[1].Powers[index];
                    if (!power2.SkipMax)
                    {
                        float damageValue = power2.FXGetDamageValue();
                        if (damageValue > num)
                        {
                            num = damageValue;
                        }
                    }
                }
                float num4 = num;
                MainModule.MidsController.Toon.GenerateBuffedPowerArray();
                float num5 = num * (1f + MidsContext.Character.TotalsCapped.BuffDam + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
                if (MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPS | MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPA)
                {
                    num5 = (float)((double)num5 * 1.5);
                }
                this.myDataView.info_Damage.nHighBase = num4;
                this.myDataView.info_Damage.nHighEnh = num5;
            }
        }
        int GetFirstValidSetEnh(int SlotIndex, int hID)
        {
            if (this.LastEnhPlaced != null)
            {
                if (this.LastEnhPlaced.Enh < 0)
                {
                    return -1;
                }
                if (DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID != Enums.eType.SetO)
                {
                    return -1;
                }
                int nIdSet = DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].nIDSet;
                if (nIdSet < 0)
                {
                    return -1;
                }
                if (MidsContext.Character.CurrentBuild.EnhancementTest(SlotIndex, hID, this.LastEnhPlaced.Enh, true))
                {
                    return this.LastEnhPlaced.Enh;
                }
                int num = DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (MidsContext.Character.CurrentBuild.EnhancementTest(SlotIndex, hID, DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index], true))
                    {
                        return DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index];
                    }
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
                {
                    return new I9Slot();
                }
                if (this.LastEnhPlaced.Enh <= -1)
                {
                    return new I9Slot();
                }
                if (DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID != Enums.eType.SetO)
                {
                    if (DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[powerIndex].NIDPower].IsEnhancementValid(this.LastEnhPlaced.Enh))
                    {
                        return this.LastEnhPlaced;
                    }
                    return new I9Slot();
                }
                else
                {
                    int firstValidSetEnh = this.GetFirstValidSetEnh(iSlotIndex, powerIndex);
                    if (firstValidSetEnh > -1)
                    {
                        this.LastEnhPlaced.Enh = firstValidSetEnh;
                        this.LastEnhPlaced.IOLevel = DatabaseAPI.Database.Enhancements[firstValidSetEnh].CheckAndFixIOLevel(this.LastEnhPlaced.IOLevel);
                        return this.LastEnhPlaced;
                    }
                }
            }
            return new I9Slot();
        }
        void heroVillain_ButtonClicked()
        {
            if (this.heroVillain.Checked)
            {
                MidsContext.Character.Alignment = Enums.Alignment.Villain;
            }
            else
            {
                MidsContext.Character.Alignment = Enums.Alignment.Hero;
            }
            if (this.fAccolade != null)
            {
                if (!this.fAccolade.IsDisposed)
                {
                    this.fAccolade.Dispose();
                }
                IPower power;
                if (!MidsContext.Character.IsHero())
                {
                    power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3257)];
                }
                else
                {
                    power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3258)];
                }
                int num = power.NIDSubPower.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (MidsContext.Character.CurrentBuild.PowerUsed(DatabaseAPI.Database.Power[power.NIDSubPower[index]]))
                    {
                        MidsContext.Character.CurrentBuild.RemovePower(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
                    }
                }
            }
            this.Drawing.ColourSwitch();
            this.SetTitleBar(true);
            this.UpdateColours(false);
            this.DoRedraw();
        }
        void HidePopup()
        {
            if (this.PopUpVisible)
            {
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
                this.Drawing.Refresh(bounds);
            }
        }
        void I9Picker_EnhancementPicked(I9Slot e)
        {
            e.RelativeLevel = this.I9Picker.UI.View.RelLevel;
            if (this.EnhancingSlot > -1)
            {
                bool flag = false;
                if (MidsContext.Character.CurrentBuild.EnhancementTest(this.EnhancingSlot, this.EnhancingPower, e.Enh, false) | e.Enh < 0)
                {
                    if (e.Enh != MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].Slots[this.EnhancingSlot].Enhancement.Enh)
                    {
                        flag = true;
                    }
                    bool flag2 = MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].HasProc();
                    MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].Slots[this.EnhancingSlot].Enhancement = (I9Slot)e.Clone();
                    if (e.Enh > -1)
                    {
                        this.LastEnhPlaced = (I9Slot)e.Clone();
                    }
                    if (flag)
                    {
                        if (e.Enh > -1)
                        {
                            if (!flag2 & (MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].HasProc() & (DatabaseAPI.Database.Enhancements[e.Enh].Probability == 0f | DatabaseAPI.Database.Enhancements[e.Enh].Probability == 1f)))
                            {
                                MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = true;
                            }
                            else if (!MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].CanIncludeForStats())
                            {
                                MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = false;
                            }
                        }
                        else if (!MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].CanIncludeForStats())
                        {
                            MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].StatInclude = false;
                        }
                    }
                    this.I9Picker.Visible = false;
                    this.PowerModified();
                    if (this.EnhancingPower > -1)
                    {
                        this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower].NIDPower, e, -1);
                    }
                }
                this.I9Picker.Visible = false;
                this.EnhancingSlot = -1;
                this.EnhancingPower = -1;
            }
        }
        void I9Picker_Hiding(object sender, EventArgs e)
        {
            if (this.I9Picker.Visible)
            {
                this.I9Picker.Visible = false;
                this.HidePopup();
                this.EnhancingSlot = -1;
                this.RefreshInfo();
            }
        }
        void I9Picker_HoverEnhancement(int e)
        {
            I9Slot i9Slot = new I9Slot
            {
                Enh = e,
                IOLevel = this.I9Picker.CheckAndReturnIOLevel() - 1,
                Grade = this.I9Picker.UI.View.GradeID,
                RelativeLevel = this.I9Picker.UI.View.RelLevel
            };
            this.myDataView.SetEnhancementPicker(i9Slot);
            this.ShowPopup(this.PickerHID, -1, -1, default(Point), this.I9Picker.Bounds, i9Slot, -1);
        }
        void I9Picker_HoverSet(int e)
        {
            this.myDataView.SetSetPicker(e);
            this.ShowPopup(this.PickerHID, -1, -1, default(Point), this.I9Picker.Bounds, null, e);
        }
        void I9Picker_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.EnhancingSlot > -1)
            {
                this.I9Picker.Visible = false;
                this.EnhancingSlot = -1;
                this.RefreshInfo();
            }
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
            if (MainModule.MidsController.Toon != null)
            {
                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
                {
                    MidsContext.Config.BuildMode = Enums.dmModes.LevelUp;
                }
                else
                {
                    MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
                }
                MidsContext.Character.ResetLevel();
                this.PowerModified();
                this.UpdateDMBuffer();
                this.pbDynMode.Refresh();
            }
        }
        void ibPopup_ButtonClicked()
        {
            MidsContext.Config.ShowPopup = this.ibPopup.Checked;
        }
        void ibPvX_ButtonClicked()
        {
            if (!this.ibPvX.Checked)
            {
                MidsContext.Config.Inc.PvE = true;
            }
            else
            {
                MidsContext.Config.Inc.PvE = false;
            }
            this.RefreshInfo();
        }
        void ibRecipe_ButtonClicked()
        {
            MidsContext.Config.PopupRecipes = this.ibRecipe.Checked;
        }
        void ibSets_ButtonClicked()
        {
            if (MainModule.MidsController.Toon != null)
            {
                this.FloatSets(true);
            }
        }
        void ibSlotLevels_ButtonClicked()
        {
            this.tsViewSlotLevels_Click(this, new EventArgs());
        }
        void ibTotals_ButtonClicked()
        {
            this.FloatTotals(true);
        }
        void incarnateButton_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = false;
            if (this.fIncarnate == null)
            {
                flag = true;
            }
            else if (this.fIncarnate.IsDisposed)
            {
                flag = true;
            }
            if (flag)
            {
                frmMain iParent = this;
                this.fIncarnate = new frmIncarnate(ref iParent);
            }
            if (!this.fIncarnate.Visible)
            {
                this.fIncarnate.Show(this);
            }
        }
        void IncarnateWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.incarnateButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
        }
        void Info_Enhancement(I9Slot iEnh, int iLevel = -1)
        {
            this.myDataView.SetEnhancement(iEnh, iLevel);
        }
        public void Info_Power(int powerIdx, int iEnhLvl = -1, bool NoLevel = false, bool Lock = false)
        {
            if (!Lock & this.DataViewLocked)
            {
                if (this.dvLastPower != powerIdx)
                {
                    return;
                }
                Lock = true;
            }
            this.dvLastEnh = iEnhLvl;
            this.dvLastPower = powerIdx;
            this.dvLastNoLev = NoLevel;
            if (this.fData != null)
            {
                this.fData.UpdateData(this.dvLastPower);
            }
            int num = -1;
            if (MainModule.MidsController.Toon.Locked)
            {
                int num2 = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num2; index++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].NIDPower == powerIdx)
                    {
                        num = index;
                        break;
                    }
                }
            }
            this.DataViewLocked = Lock;
            if (num > -1)
            {
                this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num, -1), MainModule.MidsController.Toon.GetEnhancedPower(num), NoLevel, this.DataViewLocked, num);
            }
            else
            {
                this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num, powerIdx), null, NoLevel, this.DataViewLocked, num);
            }
            if (Lock && !this.dvAnchored.Visible)
            {
                this.FloatingDataForm.Activate();
            }
        }
        void info_Totals()
        {
            if (!(MainModule.MidsController.Toon == null | !MainModule.MidsController.IsAppInitialized))
            {
                MainModule.MidsController.Toon.GenerateBuffedPowerArray();
                this.myDataView.DisplayTotals();
                this.FloatUpdate(false);
            }
        }
        void lblATLocked_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }
        void lblATLocked_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && this.cbAT.SelectedIndex >= 0)
            {
                this.ShowPopup(-1, Conversions.ToInteger(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Idx", new object[0], null, null, null)), this.cbAT.Bounds, "");
            }
        }
        void lblATLocked_Paint(object sender, PaintEventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                RectangleF destRect = new RectangleF(1f, (float)((double)(this.lblATLocked.Height - 16) / 2.0), 16f, 16f);
                destRect.Y -= 1f;
                RectangleF srcRect = new RectangleF((float)(MidsContext.Character.Archetype.Idx * 16), 0f, 16f, 16f);
                Graphics graphics = e.Graphics;
                graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                destRect.X = (float)(this.lblATLocked.Width - 19);
                graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
        void lblLocked0_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
        }
        void lblLocked0_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[3] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
            }
        }
        void lblLocked0_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool0);
        }
        void lblLocked1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[4] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
            }
        }
        void lblLocked1_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool1);
        }
        void lblLocked2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[5] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
            }
        }
        void lblLocked2_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool2);
        }
        void lblLocked3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[6] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
            }
        }
        void lblLocked3_Paint(object sender, PaintEventArgs e)
        {
            this.MiniPaint(ref e, Enums.PowersetType.Pool3);
        }
        void lblLockedAncillary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[7] != null)
            {
                string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
                this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.cbAncillary.Bounds, ExtraString);
            }
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
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Archetype.Idx >= 0 && this.cbSecondary.SelectedIndex >= 0)
            {
                string ExtraString;
                if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                {
                    ExtraString = "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
                }
                else
                {
                    ExtraString = "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set.";
                }
                this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
            }
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
            if (Item.ItemState != ListLabelV2.LLItemState.Heading)
            {
                if (Button == MouseButtons.Left)
                {
                    this.PowerPicked(Item.nIDSet, Item.nIDPower);
                }
                else if (Button == MouseButtons.Right)
                {
                    this.Info_Power(Item.nIDPower, -1, false, true);
                }
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
                this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llAncillary.Bounds, null, -1);
            }
        }
        void llPool0_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool0, Item.nIDPower);
            }
            else if (Button == MouseButtons.Right)
            {
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }
        void llPool0_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool0.Bounds, null, -1);
        }
        void llPool1_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool1, Item.nIDPower);
            }
            else if (Button == MouseButtons.Right)
            {
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }
        void llPool1_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool1.Bounds, null, -1);
        }
        void llPool2_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool2, Item.nIDPower);
            }
            else if (Button == MouseButtons.Right)
            {
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }
        void llPool2_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool2.Bounds, null, -1);
        }
        void llPool3_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Button == MouseButtons.Left)
            {
                this.PowerPicked(Enums.PowersetType.Pool3, Item.nIDPower);
            }
            else if (Button == MouseButtons.Right)
            {
                this.Info_Power(Item.nIDPower, -1, false, true);
            }
        }
        void llPool3_ItemHover(ListLabelV2.ListLabelItemV2 Item)
        {
            this.LastIndex = -1;
            this.LastEnhIndex = -1;
            this.Info_Power(Item.nIDPower, -1, false, false);
            this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPool3.Bounds, null, -1);
        }
        void llPrimary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Item.ItemState != ListLabelV2.LLItemState.Heading)
            {
                if (Button == MouseButtons.Left)
                {
                    this.PowerPicked(Item.nIDSet, Item.nIDPower);
                }
                else if (Button == MouseButtons.Right)
                {
                    this.Info_Power(Item.nIDPower, -1, false, true);
                }
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
                this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llPrimary.Bounds, null, -1);
            }
        }
        void llSecondary_ItemClick(ListLabelV2.ListLabelItemV2 Item, MouseButtons Button)
        {
            if (Item.ItemState != ListLabelV2.LLItemState.Heading)
            {
                if (Button == MouseButtons.Left)
                {
                    this.PowerPicked(Item.nIDSet, Item.nIDPower);
                }
                else if (Button == MouseButtons.Right)
                {
                    this.Info_Power(Item.nIDPower, -1, false, true);
                }
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
                this.ShowPopup(-1, Item.nIDPower, -1, default(Point), this.llSecondary.Bounds, null, -1);
            }
        }
        void MiniPaint(ref PaintEventArgs e, Enums.PowersetType iId)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Character.Powersets[(int)iId] != null)
            {
                RectangleF destRect = new RectangleF(1f, (float)((double)(this.lblLocked0.Height - 16) / 2.0), 16f, 16f);
                destRect.Y -= 1f;
                RectangleF srcRect = new RectangleF((float)(MidsContext.Character.Powersets[(int)iId].nID * 16), 0f, 16f, 16f);
                Graphics graphics = e.Graphics;
                graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
                destRect.X = (float)(this.lblLocked0.Width - 19);
                graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
        void MovePopup(Rectangle rBounds)
        {
            if (this.PopUpVisible)
            {
                Rectangle bounds = this.I9Popup.Bounds;
                if (rBounds != bounds)
                {
                    this.SetPopupLocation(rBounds, false, true);
                    this.RedrawUnderPopup(bounds);
                }
            }
        }
        void NewDraw(bool skipDraw = false)
        {
            if (this.Drawing == null)
            {
                Control pnlGfx = this.pnlGFX;
                this.pnlGFX = (PictureBox)pnlGfx;
                this.Drawing = new clsDrawX(ref pnlGfx);
            }
            else
            {
                Control pnlGfx = this.pnlGFX;
                this.Drawing.ReInit(ref pnlGfx);
                this.pnlGFX = (PictureBox)pnlGfx;
            }
            this.pnlGFX.Image = this.Drawing.bxBuffer.Bitmap;
            if (this.Drawing != null)
            {
                this.Drawing.Highlight = -1;
            }
            if (!skipDraw)
            {
                this.DoRedraw();
            }
        }
        void NewToon(bool Init = true, bool SkipDraw = false)
        {
            if (MainModule.MidsController.Toon == null)
            {
                MainModule.MidsController.Toon = new clsToonX();
            }
            else if (Init)
            {
                MidsContext.Character.Reset(null, 0);
            }
            else
            {
                string str;
                if (MainModule.MidsController.Toon.Locked)
                {
                    str = "";
                }
                else
                {
                    str = MidsContext.Character.Name;
                }
                MidsContext.Character.Reset((Archetype)this.cbAT.SelectedItem, this.cbOrigin.SelectedIndex);
                if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                {
                    MidsContext.Character.Powersets[1] = DatabaseAPI.Database.Powersets[MidsContext.Character.Powersets[0].nIDLinkSecondary];
                }
                MidsContext.Character.Name = str;
            }
            if (this.fAccolade != null && !this.fAccolade.IsDisposed)
            {
                this.fAccolade.Dispose();
            }
            if (this.fTemp != null && !this.fTemp.IsDisposed)
            {
                this.fTemp.Dispose();
            }
            if (this.fIncarnate != null && !this.fIncarnate.IsDisposed)
            {
                this.fIncarnate.Dispose();
            }
            this.NewDraw(SkipDraw);
            this.UpdateControls(false);
            this.SetTitleBar(MidsContext.Character.IsHero());
            this.UpdateColours(false);
            this.info_Totals();
            this.FileModified = false;
        }
        void pbDynMode_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null && MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
            {
                if (MidsContext.Config.BuildOption != Enums.dmItem.Power)
                {
                    MidsContext.Config.BuildOption = Enums.dmItem.Power;
                }
                else
                {
                    MidsContext.Config.BuildOption = Enums.dmItem.Slot;
                }
                this.UpdateDMBuffer();
                this.pbDynMode.Refresh();
            }
        }
        void pbDynMode_Paint(object sender, PaintEventArgs e)
        {
            if (this.dmBuffer == null)
            {
                this.UpdateDMBuffer();
            }
            if (this.dmBuffer != null)
            {
                e.Graphics.DrawImage(this.dmBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }
        void pnlGFX_DragDrop(object sender, DragEventArgs e)
        {
            if (sender.Equals(this.pnlGFX))
            {
                this.pnlGFX.AllowDrop = false;
                ControlPaint.DrawReversibleFrame(this.dragRect, Color.White, FrameStyle.Thick);
                this.oldDragRect = Rectangle.Empty;
                this.dragRect = Rectangle.Empty;
                int iValue = e.X + this.xCursorOffset;
                int iValue2 = e.Y + this.yCursorOffset;
                this.dragFinishPower = this.Drawing.WhichSlot(this.Drawing.ScaleUp(iValue), this.Drawing.ScaleUp(iValue2));
                if (this.dragStartSlot != -1)
                {
                    this.dragFinishSlot = this.Drawing.WhichEnh(this.Drawing.ScaleUp(iValue), this.Drawing.ScaleUp(iValue2));
                    if (this.dragFinishSlot == 0)
                    {
                        Interaction.MsgBox("You cannot change the level of any power's automatic slot.", MsgBoxStyle.OkOnly, null);
                    }
                    else
                    {
                        this.SlotLevelSwap(this.dragStartPower, this.dragStartSlot, this.dragFinishPower, this.dragFinishSlot);
                    }
                }
                else if ((e.KeyState & 4) > 0)
                {
                    this.PowerMoveByUser(new int[]
                    {
                        this.dragStartPower,
                        this.dragFinishPower
                    });
                }
                else
                {
                    this.PowerSwapByUser(new int[]
                    {
                        this.dragStartPower,
                        this.dragFinishPower
                    });
                }
            }
        }
        void pnlGFX_DragEnter(object sender, DragEventArgs e)
        {
            if (sender.Equals(this.pnlGFX))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        void pnlGFX_DragOver(object sender, DragEventArgs e)
        {
            if (sender.Equals(this.pnlGFX) && (this.dragRect.IsEmpty || (this.dragRect.Top != Cursor.Position.Y - this.dragYOffset | this.dragRect.Left != Cursor.Position.X - this.dragXOffset)))
            {
                if (this.dragStartSlot != -1)
                {
                    this.dragRect = new Rectangle(Cursor.Position.X - this.dragXOffset, Cursor.Position.Y - this.dragYOffset, this.Drawing.ScaleDown(this.Drawing.szSlot.Width), this.Drawing.ScaleDown(this.Drawing.szSlot.Height));
                }
                else
                {
                    this.dragRect = new Rectangle(Cursor.Position.X - this.dragXOffset, Cursor.Position.Y - this.dragYOffset, this.Drawing.ScaleDown(this.Drawing.szPower.Width), this.Drawing.ScaleDown(this.Drawing.szPower.Height));
                }
                if (!this.oldDragRect.IsEmpty)
                {
                    ControlPaint.DrawReversibleFrame(this.oldDragRect, Color.White, FrameStyle.Thick);
                }
                if (base.ClientRectangle.Contains(base.RectangleToClient(this.dragRect)))
                {
                    this.oldDragRect = this.dragRect;
                }
                else
                {
                    this.dragRect = this.oldDragRect;
                }
                ControlPaint.DrawReversibleFrame(this.dragRect, Color.White, FrameStyle.Thick);
            }
        }
        void pnlGFX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.LastClickPlacedSlot & this.dragStartSlot >= 0)
            {
                MainModule.MidsController.Toon.BuildSlot(this.dragStartPower, this.dragStartSlot);
                this.PowerModified();
                this.FileModified = true;
                this.DoneDblClick = true;
                this.LastClickPlacedSlot = false;
            }
        }
        void pnlGFX_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.pnlGFX.AllowDrop = true;
                this.dragStartX = e.X;
                this.dragStartY = e.Y;
                this.dragStartPower = this.Drawing.WhichSlot(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
                this.dragStartSlot = this.Drawing.WhichEnh(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
            }
        }
        void pnlGFX_MouseEnter(object sender, EventArgs e)
        {
            this.pnlGFXFlow.Focus();
        }
        void pnlGFX_MouseLeave(object sender, EventArgs e)
        {
            this.HidePopup();
            this.Drawing.HighlightSlot(-1, false);
        }
        void pnlGFX_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left & this.pnlGFX.AllowDrop) && Math.Abs(e.X - this.dragStartX) + Math.Abs(e.Y - this.dragStartY) > 7)
            {
                if (this.dragStartSlot == 0)
                {
                    Interaction.MsgBox("You cannot change the level of any power's automatic slot.", MsgBoxStyle.OkOnly, null);
                    this.pnlGFX.AllowDrop = false;
                }
                else
                {
                    this.xCursorOffset = e.X - Cursor.Position.X;
                    this.yCursorOffset = e.Y - Cursor.Position.Y;
                    if (this.dragStartSlot != -1)
                    {
                        this.dragXOffset = this.Drawing.ScaleDown(this.Drawing.szSlot.Width / 2);
                        this.dragYOffset = this.Drawing.ScaleDown(this.Drawing.szSlot.Height / 2);
                    }
                    else
                    {
                        this.dragXOffset = this.Drawing.ScaleDown(this.Drawing.szPower.Width / 2);
                        this.dragYOffset = this.Drawing.ScaleDown(this.Drawing.szPower.Height / 2);
                    }
                    DataObject dataObject = new DataObject();
                    dataObject.SetText("This is some filler power text right here");
                    this.HidePopup();
                    this.pnlGFX.Cursor = Cursors.Default;
                    this.Drawing.HighlightSlot(-1, false);
                    Application.DoEvents();
                    this.ibPopup.DoDragDrop(dataObject, DragDropEffects.Move);
                }
            }
            else
            {
                int index = this.Drawing.WhichSlot(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
                int sIDX = this.Drawing.WhichEnh(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
                if (index < 0 | index >= MidsContext.Character.CurrentBuild.Powers.Count)
                {
                    this.HidePopup();
                }
                else
                {
                    Point e2 = new Point(e.X, e.Y);
                    this.ShowPopup(index, -1, sIDX, e2, default(Rectangle), null, -1);
                    if (MidsContext.Character.CanPlaceSlot & MainModule.MidsController.Toon.SlotCheck(MidsContext.Character.CurrentBuild.Powers[index]) > -1)
                    {
                        this.Drawing.HighlightSlot(index, false);
                        if (index > -1 & this.Drawing.InterfaceMode != Enums.eInterfaceMode.PowerToggle)
                        {
                            this.pnlGFX.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            this.pnlGFX.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        this.pnlGFX.Cursor = Cursors.Default;
                        this.Drawing.HighlightSlot(-1, false);
                    }
                    if (index > -1 && (index != this.LastIndex | this.LastEnhIndex != sIDX))
                    {
                        this.LastIndex = index;
                        this.LastEnhIndex = sIDX;
                        if (sIDX > -1)
                        {
                            this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, MidsContext.Character.CurrentBuild.Powers[index].Slots[sIDX].Enhancement, MidsContext.Character.CurrentBuild.Powers[index].Slots[sIDX].Level);
                        }
                        else
                        {
                            this.RefreshTabs(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, new I9Slot(), -1);
                        }
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
                int index = this.Drawing.WhichSlot(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
                int index2 = this.Drawing.WhichEnh(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
                if (!(index < 0 | index >= MidsContext.Character.CurrentBuild.Powers.Count))
                {
                    bool flag = MidsContext.Character.CurrentBuild.Powers[index].NIDPower < 0;
                    if (!(e.Button == MouseButtons.Left & Control.ModifierKeys == (Keys.Shift | Keys.Control)) || !this.EditAccoladesOrTemps(index))
                    {
                        if (this.Drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & e.Button == MouseButtons.Left)
                        {
                            if (!flag && MidsContext.Character.CurrentBuild.Powers[index].CanIncludeForStats())
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[index].StatInclude)
                                {
                                    MidsContext.Character.CurrentBuild.Powers[index].StatInclude = false;
                                }
                                else
                                {
                                    Enums.eMutex eMutex = MainModule.MidsController.Toon.CurrentBuild.MutexV2(index, false, false);
                                    if (eMutex == Enums.eMutex.NoConflict | eMutex == Enums.eMutex.NoGroup)
                                    {
                                        MidsContext.Character.CurrentBuild.Powers[index].StatInclude = true;
                                    }
                                }
                            }
                            this.EnhancementModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (this.ToggleClicked(index, this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y)) & e.Button == MouseButtons.Left)
                        {
                            if (!flag && MidsContext.Character.CurrentBuild.Powers[index].CanIncludeForStats())
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[index].StatInclude)
                                {
                                    MidsContext.Character.CurrentBuild.Powers[index].StatInclude = false;
                                }
                                else
                                {
                                    Enums.eMutex eMutex2 = MainModule.MidsController.Toon.CurrentBuild.MutexV2(index, false, false);
                                    if (eMutex2 == Enums.eMutex.NoConflict | eMutex2 == Enums.eMutex.NoGroup)
                                    {
                                        MidsContext.Character.CurrentBuild.Powers[index].StatInclude = true;
                                    }
                                }
                                MidsContext.Character.Validate();
                            }
                            this.EnhancementModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (e.Button == MouseButtons.Left & Control.ModifierKeys == Keys.Alt)
                        {
                            MainModule.MidsController.Toon.BuildPower(MidsContext.Character.CurrentBuild.Powers[index].NIDPowerset, MidsContext.Character.CurrentBuild.Powers[index].NIDPower, false);
                            this.PowerModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (e.Button == MouseButtons.Left & Control.ModifierKeys == Keys.Shift & index2 > -1)
                        {
                            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                            {
                                MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Level;
                                MidsContext.Character.ResetLevel();
                            }
                            MainModule.MidsController.Toon.BuildSlot(index, index2);
                            this.PowerModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else
                        {
                            if (e.Button == MouseButtons.Left & !this.EnhPickerActive)
                            {
                                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic && flag)
                                {
                                    if (flag & MidsContext.Character.CurrentBuild.Powers[index].Level > -1)
                                    {
                                        MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Level;
                                        this.UpdatePowerLists();
                                        this.DoRedraw();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MainModule.MidsController.Toon.BuildSlot(index, -1) > -1)
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
                                this.EnhancingPower = index;
                                this.I9Picker_EnhancementPicked(this.GetRepeatEnhancement(index, index2));
                                this.EnhancementModified();
                            }
                            else if ((e.Button == MouseButtons.Right & index2 > -1) && Control.ModifierKeys != Keys.Shift)
                            {
                                Point point = default(Point);
                                this.EnhancingSlot = index2;
                                this.EnhancingPower = index;
                                int[] enhancements = MainModule.MidsController.Toon.GetEnhancements(index);
                                this.PickerHID = index;
                                if (!flag)
                                {
                                    this.I9Picker.SetData(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, ref MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement, ref this.Drawing, enhancements);
                                }
                                else
                                {
                                    this.I9Picker.SetData(-1, ref MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement, ref this.Drawing, enhancements);
                                }
                                point = new Point((int)Math.Round((double)(this.pnlGFXFlow.Left - this.pnlGFXFlow.HorizontalScroll.Value + e.X) - (double)this.I9Picker.Width / 2.0), (int)Math.Round((double)(this.pnlGFXFlow.Top - this.pnlGFXFlow.VerticalScroll.Value + e.Y) - (double)this.I9Picker.Height / 2.0));
                                if (point.Y < this.MenuBar.Height)
                                {
                                    point.Y = this.MenuBar.Height;
                                }
                                if (point.Y + this.I9Picker.Height > base.ClientSize.Height)
                                {
                                    point.Y = base.ClientSize.Height - this.I9Picker.Height;
                                }
                                if (point.X + this.I9Picker.Width > base.ClientSize.Width)
                                {
                                    point.X = base.ClientSize.Width - this.I9Picker.Width;
                                }
                                this.I9Picker.Location = point;
                                this.I9Picker.BringToFront();
                                this.I9Picker.Visible = true;
                                this.I9Picker.Select();
                                this.LastClickPlacedSlot = false;
                            }
                            else if (e.Button == MouseButtons.Right & Control.ModifierKeys == Keys.Shift)
                            {
                                this.StartFlip(index);
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                this.Info_Power(MidsContext.Character.CurrentBuild.Powers[index].NIDPower, -1, true, true);
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
        public void PowerModified()
        {
            int index = -1;
            MainModule.MidsController.Toon.Complete = false;
            this.fixStatIncludes();
            this.FileModified = true;
            if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
            {
                index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(MainModule.MidsController.Toon.RequestedLevel);
                if (index < 0)
                {
                    index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(0);
                }
            }
            else if (DatabaseAPI.Database.Levels[MidsContext.Character.Level].LevelType() == Enums.dmItem.Power)
            {
                index = MainModule.MidsController.Toon.GetFirstAvailablePowerIndex(0);
                this.Drawing.HighlightSlot(-1, false);
            }
            if (MainModule.MidsController.Toon.Complete)
            {
                this.Drawing.HighlightSlot(-1, false);
            }
            int[] slotCounts = MainModule.MidsController.Toon.GetSlotCounts();
            if (slotCounts[0] > 0)
            {
                this.ibAccolade.TextOff = Conversions.ToString(slotCounts[0]) + " slots to go";
            }
            else
            {
                this.ibAccolade.TextOff = "No slots left";
            }
            if (slotCounts[1] > 0)
            {
                this.ibAccolade.TextOn = Conversions.ToString(slotCounts[1]) + " slots placed";
            }
            else
            {
                this.ibAccolade.TextOn = "No slots placed";
            }
            if (index > -1 & index <= MidsContext.Character.CurrentBuild.Powers.Count)
            {
                MidsContext.Character.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[index].Level;
            }
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
                if (this.ddsa[0] == 0)
                {
                    if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", new string[]
                        {
                            "Allow power to be moved anyway (mark as invalid)"
                        });
                        this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (this.ddsa[0] == 2)
                        {
                            this.ddsa[0] = 3;
                        }
                    }
                    else
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", new string[]
                        {
                            "Move/swap power to its lowest possible level",
                            "Allow power to be moved anyway (mark as invalid)"
                        });
                        this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    }
                    if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                    {
                        MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
                    }
                }
                if (this.ddsa[0] == 1)
                {
                    return 0;
                }
                if (this.ddsa[0] == 2)
                {
                    if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                    {
                        Interaction.MsgBox("You have chosen to always swap a power with its minimum level when attempting to move it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", MsgBoxStyle.OkOnly, null);
                        return 0;
                    }
                    int num = DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1;
                    int index = 0;
                    while (tp[index].Level != num)
                    {
                        index++;
                        if (index > 23)
                        {
                            return this.PowerMove(tp, new int[]
                            {
                                pow[0],
                                num
                            });
                        }
                    }
                }
                else if (this.ddsa[0] == 3)
                {
                }
            }
            bool flag = pow[0] < pow[1];
            bool[] flagArray = new bool[tp.Length - 1 + 1];
            if (flag)
            {
                flagArray[pow[0]] = true;
                int level = tp[pow[0]].Level;
                int num2 = pow[1];
                for (int index2 = pow[0] + 1; index2 <= num2; index2++)
                {
                    if (tp[index2].NIDPower < 0)
                    {
                        flagArray[index2] = true;
                        level = tp[index2].Level;
                    }
                    else if (DatabaseAPI.Database.Power[tp[index2].NIDPower].Level - 1 == tp[index2].Level)
                    {
                        flagArray[index2] = false;
                    }
                    else if (level >= DatabaseAPI.Database.Power[tp[index2].NIDPower].Level - 1)
                    {
                        flagArray[index2] = true;
                        level = tp[index2].Level;
                    }
                    else
                    {
                        flagArray[index2] = false;
                    }
                }
            }
            if (flag & !flagArray[pow[1]])
            {
                if (this.ddsa[1] == 0)
                {
                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved too high (some powers will no longer fit)", new string[]
                    {
                        "Move to the last power slot that can be shifted"
                    });
                    this.ddsa[1] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                    {
                        MidsContext.Config.DragDropScenarioAction[1] = this.ddsa[1];
                    }
                }
                if (this.ddsa[1] == 1)
                {
                    return 0;
                }
                if (this.ddsa[1] == 2)
                {
                    int num3 = pow[0] + 1;
                    int index3;
                    for (index3 = pow[1]; index3 >= num3; index3 += -1)
                    {
                        if (flagArray[index3])
                        {
                            pow[1] = index3;
                            break;
                        }
                    }
                    if (pow[1] != index3)
                    {
                        Interaction.MsgBox("None of the powers can be shifted, so the power was not moved.", MsgBoxStyle.OkOnly, null);
                        return 0;
                    }
                }
            }
            PowerEntry powerEntry;
            if (tp[pow[0]].NIDPower == -1)
            {
                powerEntry = new PowerEntry(-1, null, false);
            }
            else
            {
                powerEntry = new PowerEntry(DatabaseAPI.Database.Power[tp[pow[0]].NIDPower]);
            }
            powerEntry.Slots = (SlotEntry[])tp[pow[0]].Slots.Clone();
            powerEntry.Level = tp[pow[0]].Level;
            this.clearPower(tp, pow[0]);
            bool flag2 = false;
            int num4;
            int num5;
            int num6;
            if (flag)
            {
                num4 = pow[1];
                num5 = pow[0] + 1;
                num6 = -1;
            }
            else
            {
                num4 = pow[0] + 1;
                num5 = pow[1];
                num6 = 1;
            }
            int num7 = num5;
            int num8 = num6;
            int index4 = num4;
            while ((num8 >> 31 ^ index4) <= (num8 >> 31 ^ num7))
            {
                if (tp[index4].NIDPower != -1 && flag && !flagArray[index4])
                {
                    if (this.ddsa[7] == 0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being shifted down cannot shift to the necessary level", new string[]
                        {
                            "Shift other powers around it",
                            "Overwrite it; leave previous power slot empty",
                            "Allow anyway (mark as invalid)"
                        });
                        this.ddsa[7] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                        {
                            MidsContext.Config.DragDropScenarioAction[7] = this.ddsa[7];
                        }
                    }
                    if (this.ddsa[7] == 1)
                    {
                        return 0;
                    }
                    if (this.ddsa[7] == 3)
                    {
                        if (!flag2)
                        {
                            pow[0] = index4;
                        }
                        break;
                    }
                }
                if (!flag2 & tp[index4].NIDPower < 0)
                {
                    if (this.ddsa[10] == 0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "There is a gap in a group of powers that are being shifted", new string[]
                        {
                            "Fill empty slot; don't move powers unnecessarily",
                            "Shift empty slot as if it were a power"
                        });
                        this.ddsa[10] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                        {
                            MidsContext.Config.DragDropScenarioAction[10] = this.ddsa[10];
                        }
                    }
                    if (this.ddsa[10] == 1)
                    {
                        return 0;
                    }
                    if (this.ddsa[10] == 2)
                    {
                        if (tp[pow[1]].NIDPower < 0)
                        {
                            powerEntry.Level = tp[pow[0]].Level;
                            tp[pow[0]] = powerEntry;
                            if (this.PowerSwap(1, ref tp, new int[]
                            {
                                pow[0],
                                pow[1]
                            }) == 0)
                            {
                                return 0;
                            }
                            return -1;
                        }
                        else
                        {
                            pow[0] = index4;
                        }
                    }
                    flag2 = true;
                }
                index4 += num8;
            }
            int index5 = pow[0];
            int num9;
            if (flag)
            {
                num9 = index5 + 1;
            }
            else
            {
                num9 = index5 - 1;
            }
            while (num9 != pow[1])
            {
                switch (this.PowerSwap(2, ref tp, new int[]
                {
                    index5,
                    num9
                }))
                {
                    case -1:
                        index5 = num9;
                        if (flag)
                        {
                            num9++;
                        }
                        else
                        {
                            num9--;
                        }
                        break;
                    case 0:
                        Interaction.MsgBox("Move canceled by user. If you didn't click Cancel, check that none of your Shift options are set to Cancel by default.", MsgBoxStyle.OkOnly, null);
                        return 0;
                    case 1:
                        if (flag)
                        {
                            num9++;
                        }
                        else
                        {
                            num9--;
                        }
                        break;
                    case 2:
                        this.PowerMoveByUser(new int[]
                        {
                        this.dragStartPower,
                        this.dragFinishPower
                        });
                        return 0;
                }
            }
            powerEntry.Level = tp[index5].Level;
            tp[index5] = powerEntry;
            int num11 = this.PowerSwap(1, ref tp, new int[]
            {
                index5,
                num9
            });
            int num10;
            if (num11 != 0)
            {
                if (num11 != 3)
                {
                    num10 = -1;
                }
                else
                {
                    this.PowerSwapByUser(new int[]
                    {
                        this.dragStartPower,
                        this.dragFinishPower
                    });
                    num10 = 0;
                }
            }
            else
            {
                num10 = 0;
            }
            return num10;
        }
        void PowerMoveByUser(params int[] pow)
        {
            if (!(pow[0] < 0 | pow[0] > 23 | pow[1] < 0 | pow[1] > 23 | pow[0] == pow[1]))
            {
                int index = 0;
                do
                {
                    this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                    index++;
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
            int num;
            if (pow[0] < 0 | pow[0] > 23 | pow[1] < 0 | pow[1] > 23 | pow[0] == pow[1])
            {
                num = 0;
            }
            else
            {
                if (tp[pow[0]].NIDPower == -1 || DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 <= tp[pow[1]].Level)
                {
                    if (tp[pow[1]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[1]].NIDPower].Level - 1 > tp[pow[0]].Level)
                    {
                        if (mode == 0)
                        {
                            if (this.ddsa[4] == 0)
                            {
                                MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being replaced is swapped too low", new string[]
                                {
                                    "Overwrite rather than swap",
                                    "Allow power to be swapped anyway (mark as invalid)"
                                });
                                this.ddsa[4] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                                {
                                    MidsContext.Config.DragDropScenarioAction[4] = this.ddsa[4];
                                }
                            }
                            if (this.ddsa[4] == 1)
                            {
                                return 0;
                            }
                            if (this.ddsa[4] == 2)
                            {
                                tp[pow[1]].NIDPower = -1;
                                tp[pow[1]].NIDPowerset = -1;
                                tp[pow[1]].IDXPower = -1;
                                tp[pow[1]].StatInclude = false;
                                tp[pow[1]].VariableValue = 0;
                                tp[pow[1]].Slots = new SlotEntry[0];
                            }
                            else if (this.ddsa[4] == 3)
                            {
                            }
                        }
                        else if (mode == 2 && this.ddsa[7] == 2)
                        {
                            return 1;
                        }
                    }
                }
                else if (mode == 0)
                {
                    if (this.ddsa[0] == 0)
                    {
                        if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", new string[]
                            {
                                "Allow power to be moved anyway (mark as invalid)"
                            });
                            this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                            if (this.ddsa[0] == 2)
                            {
                                this.ddsa[0] = 3;
                            }
                        }
                        else
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", new string[]
                            {
                                "Move/swap power to its lowest possible level",
                                "Allow power to be moved anyway (mark as invalid)"
                            });
                            this.ddsa[0] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        }
                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                        {
                            MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
                        }
                    }
                    if (this.ddsa[0] == 1)
                    {
                        return 0;
                    }
                    if (this.ddsa[0] == 2)
                    {
                        if (DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1 == tp[pow[0]].Level)
                        {
                            Interaction.MsgBox("You have chosen to always swap a power with its minimum level when attempting to swap it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", MsgBoxStyle.OkOnly, null);
                            return 0;
                        }
                        int num2 = DatabaseAPI.Database.Power[tp[pow[0]].NIDPower].Level - 1;
                        int index = 0;
                        while (tp[index].Level != num2)
                        {
                            index++;
                            if (index > 23)
                            {
                                return this.PowerSwap(mode, ref tp, new int[]
                                {
                                    pow[0],
                                    num2
                                });
                            }
                        }
                        num2 = index;
                        return this.PowerSwap(mode, ref tp, new int[]
                        {
                            pow[0],
                            num2
                        });
                    }
                    else if (this.ddsa[0] == 3)
                    {
                    }
                }
                if ((mode == 1 | mode == 2) && tp[pow[1]].NIDPower != -1 && DatabaseAPI.Database.Power[tp[pow[1]].NIDPower].Level - 1 == tp[pow[1]].Level)
                {
                    if (mode == 1)
                    {
                        if (this.ddsa[12] == 0)
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "The power in the destination slot is prevented from being shifted up", new string[]
                            {
                                "Unlock and shift all level-locked powers",
                                "Shift destination power to the first valid and empty slot",
                                "Swap instead of move"
                            });
                            this.ddsa[12] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                            if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                            {
                                MidsContext.Config.DragDropScenarioAction[12] = this.ddsa[12];
                            }
                        }
                        if (this.ddsa[12] == 1)
                        {
                            return 0;
                        }
                        if (this.ddsa[12] == 2)
                        {
                            this.ddsa[11] = 2;
                            return 2;
                        }
                        if (this.ddsa[12] != 3 && this.ddsa[12] == 4)
                        {
                            return 3;
                        }
                    }
                    else if (mode == 2)
                    {
                        if (this.ddsa[11] == 0)
                        {
                            MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "A power placed at its minimum level is being shifted up", new string[]
                            {
                                "Shift it along with the other powers",
                                "Shift other powers around it"
                            });
                            this.ddsa[11] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                            if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                            {
                                MidsContext.Config.DragDropScenarioAction[11] = this.ddsa[11];
                            }
                        }
                        if (this.ddsa[11] == 1)
                        {
                            return 0;
                        }
                        if (this.ddsa[11] != 2 && this.ddsa[11] == 3)
                        {
                            return 1;
                        }
                    }
                }
                int num3 = tp[22].SlotCount + tp[23].SlotCount;
                int num4 = -1;
                if ((pow[0] == 22 & pow[1] < 22 & num3 <= 8 & tp[pow[1]].SlotCount + tp[23].SlotCount > 8) | (pow[0] == 23 & pow[1] < 22 & tp[pow[0]].SlotCount <= 4 & tp[pow[1]].SlotCount > 4) | (pow[0] == 23 & pow[1] < 22 & num3 <= 8 & tp[22].SlotCount + tp[pow[1]].SlotCount > 8) | (pow[0] == 23 & pow[1] == 22 & tp[pow[1]].SlotCount > 4))
                {
                    if (mode < 2 & this.ddsa[6] == 0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being replaced is swapped too high to have # slots", new string[]
                        {
                            "Remove impossible slots",
                            "Allow anyway (Mark slots as invalid)"
                        });
                        this.ddsa[6] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                        {
                            MidsContext.Config.DragDropScenarioAction[6] = this.ddsa[6];
                        }
                    }
                    num4 = 6;
                }
                else if ((pow[0] < 22 & pow[1] == 22 & num3 <= 8 & tp[pow[0]].SlotCount + tp[23].SlotCount > 8) | (pow[0] < 22 & pow[1] == 23 & tp[pow[1]].SlotCount <= 4 & tp[pow[0]].SlotCount > 4) | (pow[0] < 22 & pow[1] == 23 & num3 <= 8 & tp[22].SlotCount + tp[pow[0]].SlotCount > 8) | (pow[0] == 22 & pow[1] == 23 & tp[pow[0]].SlotCount > 4))
                {
                    if (mode < 2 & this.ddsa[3] == 0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too high to have # slots", new string[]
                        {
                            "Remove impossible slots",
                            "Allow anyway (Mark slots as invalid)"
                        });
                        this.ddsa[3] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                        {
                            MidsContext.Config.DragDropScenarioAction[3] = this.ddsa[3];
                        }
                    }
                    num4 = 3;
                }
                if (num4 != -1 && mode == 2)
                {
                    if (this.ddsa[9] == 0)
                    {
                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 1, "Power being shifted up has impossible # of slots", new string[]
                        {
                            "Remove impossible slots",
                            "Allow anyway (Mark slots as invalid)"
                        });
                        this.ddsa[9] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                        {
                            MidsContext.Config.DragDropScenarioAction[9] = this.ddsa[9];
                        }
                    }
                    num4 = 9;
                }
                if (((num4 == 6 && mode < 2) & this.ddsa[6] == 1) || ((num4 == 3 && mode < 2) & this.ddsa[3] == 1) || (num4 == 9 && this.ddsa[9] == 1))
                {
                    num = 0;
                }
                else
                {
                    if (((num4 == 6 && mode < 2) & this.ddsa[6] == 2) || ((num4 == 3 && mode < 2) & this.ddsa[3] == 2) || (num4 == 9 && this.ddsa[9] == 2))
                    {
                        int index2;
                        int num5;
                        if (pow[0] > pow[1])
                        {
                            index2 = pow[1];
                            num5 = pow[0];
                        }
                        else
                        {
                            index2 = pow[0];
                            num5 = pow[1];
                        }
                        int integer = Conversions.ToInteger(Interaction.IIf(num5 == 22, index2, RuntimeHelpers.GetObjectValue(Interaction.IIf(index2 == 22, num5, 22))));
                        int integer2 = Conversions.ToInteger(Interaction.IIf(num5 == 23, index2, 23));
                        while (tp[integer].SlotCount + tp[integer2].SlotCount > 8 | (tp[index2].SlotCount > 4 & integer2 != 23))
                        {
                            tp[index2].Slots = (SlotEntry[])Utils.CopyArray(tp[index2].Slots, new SlotEntry[tp[index2].SlotCount - 2 + 1]);
                        }
                    }
                    else if (((num4 == 6 && mode < 2) & this.ddsa[6] == 3) || ((num4 == 3 && mode < 2) & this.ddsa[3] == 3) || (num4 == 9 && this.ddsa[9] == 3))
                    {
                        int index2;
                        if (pow[0] > pow[1])
                        {
                            index2 = pow[1];
                        }
                        else
                        {
                            index2 = pow[0];
                        }
                        if (pow[0] == 23 | pow[1] == 23)
                        {
                            for (int index3 = tp[index2].SlotCount - 1; index3 >= 1; index3 += -1)
                            {
                                if (index3 + tp[22].SlotCount > 7 | index3 > 3)
                                {
                                    tp[index2].Slots[index3].Level = 50;
                                }
                            }
                        }
                        else
                        {
                            for (int index4 = tp[index2].SlotCount - 1; index4 >= 1; index4 += -1)
                            {
                                if (index4 + tp[22].SlotCount > 7)
                                {
                                    tp[index2].Slots[index4].Level = 50;
                                }
                            }
                        }
                    }
                    PowerEntry powerEntry = tp[pow[0]];
                    tp[pow[0]] = tp[pow[1]];
                    tp[pow[1]] = powerEntry;
                    int level2 = tp[pow[0]].Level;
                    tp[pow[0]].Level = tp[pow[1]].Level;
                    tp[pow[1]].Level = level2;
                    level2 = pow[0];
                    pow[0] = pow[1];
                    pow[1] = level2;
                    int index5 = 0;
                    for (; ; )
                    {
                        if (tp[pow[index5]].SlotCount > 0)
                        {
                            tp[pow[index5]].Slots[0].Level = tp[pow[index5]].Level;
                            int num6 = tp[pow[index5]].SlotCount - 1;
                            for (int slotIDX = 1; slotIDX <= num6; slotIDX++)
                            {
                                if (slotIDX > tp[pow[index5]].SlotCount - 1)
                                {
                                    break;
                                }
                                if (tp[pow[index5]].Slots[slotIDX].Level < tp[pow[index5]].Level)
                                {
                                    if (mode < 2 & index5 == 0 & this.ddsa[2] == 0)
                                    {
                                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power is moved or swapped higher than slots' levels", new string[]
                                        {
                                            "Remove slots",
                                            "Mark invalid slots",
                                            "Swap slot levels if valid; remove invalid ones",
                                            "Swap slot levels if valid; mark invalid ones",
                                            "Rearrange all slots in build"
                                        });
                                        this.ddsa[2] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                                        {
                                            MidsContext.Config.DragDropScenarioAction[2] = this.ddsa[2];
                                        }
                                    }
                                    else if (mode == 0 & index5 == 1 & this.ddsa[5] == 0)
                                    {
                                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power being replaced is swapped higher than slots' levels", new string[]
                                        {
                                            "Remove slots",
                                            "Mark invalid slots",
                                            "Swap slot levels if valid; remove invalid ones",
                                            "Swap slot levels if valid; mark invalid ones",
                                            "Rearrange all slots in build"
                                        });
                                        this.ddsa[5] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                                        {
                                            MidsContext.Config.DragDropScenarioAction[5] = this.ddsa[5];
                                        }
                                    }
                                    else if (mode == 2 & this.ddsa[8] == 0)
                                    {
                                        MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 3, "Power being shifted up has slots from lower levels", new string[]
                                        {
                                            "Remove slots",
                                            "Mark invalid slots",
                                            "Swap slot levels if valid; remove invalid ones",
                                            "Swap slot levels if valid; mark invalid ones",
                                            "Rearrange all slots in build"
                                        });
                                        this.ddsa[8] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                                        if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                                        {
                                            MidsContext.Config.DragDropScenarioAction[8] = this.ddsa[8];
                                        }
                                    }
                                    if ((mode < 2 & index5 == 0 & this.ddsa[2] == 1) | (mode == 0 & index5 == 1 & this.ddsa[5] == 1) | (mode == 2 & this.ddsa[8] == 1))
                                    {
                                        goto Block_83;
                                    }
                                    if ((mode < 2 & index5 == 0 & this.ddsa[2] == 2) | (mode == 0 & index5 == 1 & this.ddsa[5] == 2) | (mode == 2 & this.ddsa[8] == 2))
                                    {
                                        this.RemoveSlotFromTempList(tp[pow[index5]], slotIDX);
                                        slotIDX--;
                                    }
                                    else if ((mode < 2 & index5 == 0 & this.ddsa[2] == 4) | (mode == 0 & index5 == 1 & this.ddsa[5] == 4) | (mode == 2 & this.ddsa[8] == 4))
                                    {
                                        if (tp[pow[1 - index5]].SlotCount > slotIDX)
                                        {
                                            level2 = tp[pow[1 - index5]].Slots[slotIDX].Level;
                                            tp[pow[1 - index5]].Slots[slotIDX].Level = tp[pow[index5]].Slots[slotIDX].Level;
                                            tp[pow[index5]].Slots[slotIDX].Level = level2;
                                        }
                                        else
                                        {
                                            this.RemoveSlotFromTempList(tp[pow[index5]], slotIDX);
                                            slotIDX--;
                                        }
                                    }
                                    else if ((mode < 2 & index5 == 0 & this.ddsa[2] == 5) | (mode == 0 & index5 == 1 & this.ddsa[5] == 5) | (mode == 2 & this.ddsa[8] == 5))
                                    {
                                        if (tp[pow[1 - index5]].SlotCount > slotIDX)
                                        {
                                            level2 = tp[pow[1 - index5]].Slots[slotIDX].Level;
                                            tp[pow[1 - index5]].Slots[slotIDX].Level = tp[pow[index5]].Slots[slotIDX].Level;
                                            tp[pow[index5]].Slots[slotIDX].Level = level2;
                                        }
                                    }
                                    else if ((mode < 2 & index5 == 0 & this.ddsa[2] == 6) | (mode == 0 & index5 == 1 & this.ddsa[5] == 6) | (mode == 2 & this.ddsa[8] == 6))
                                    {
                                        this.RearrangeAllSlotsInBuild(tp, true);
                                    }
                                }
                            }
                        }
                        index5++;
                        if (index5 > 1)
                        {
                            goto Block_90;
                        }
                    }
                Block_83:
                    return 0;
                Block_90:
                    num = -1;
                }
            }
            return num;
        }
        void PowerSwapByUser(params int[] pow)
        {
            int index = 0;
            do
            {
                this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                index++;
            }
            while (index <= 19);
            PowerEntry[] tp = frmMain.DeepCopyPowerList();
            if (this.PowerSwap(0, ref tp, pow) == -1)
            {
                this.ShallowCopyPowerList(tp);
                this.PowerModified();
                this.DoRedraw();
            }
        }
        void PriSec_ExpandChanged(bool Expanded)
        {
            if (this.llPrimary.isExpanded | (this.llSecondary.isExpanded & this.dvAnchored.IsDocked & !this.HasSentForwards))
            {
                this.llPrimary.BringToFront();
                this.llSecondary.BringToFront();
                this.HasSentBack = false;
                this.HasSentForwards = true;
            }
            else if (this.llPrimary.Bounds.IntersectsWith(this.dvAnchored.Bounds) & !this.HasSentBack)
            {
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
            Rectangle result;
            if (Index == 0)
            {
                label = this.lblPool1;
                Instance = this.llPool0;
            }
            else if (Index == 1)
            {
                label = this.lblPool2;
                Instance = this.llPool1;
            }
            else if (Index == 2)
            {
                label = this.lblPool3;
                Instance = this.llPool2;
            }
            else if (Index == 3)
            {
                label = this.lblPool4;
                Instance = this.llPool3;
            }
            else
            {
                if (Index != 4)
                {
                    result = new Rectangle(0, 0, 10, 10);
                    return result;
                }
                label = this.lblEpic;
                Instance = this.llAncillary;
            }
            result = new Rectangle(label.Left, label.Top, Conversions.ToInteger(NewLateBinding.LateGet(Instance, null, "Width", new object[0], null, null, null)), Conversions.ToInteger(Operators.SubtractObject(Operators.AddObject(NewLateBinding.LateGet(Instance, null, "Top", new object[0], null, null, null), NewLateBinding.LateGet(Instance, null, "Height", new object[0], null, null, null)), label.Top)));
            return result;
        }
        int raGetTop()
        {
            int result;
            if (MainModule.MidsController.Toon == null)
            {
                result = this.llPrimary.Top + this.llPrimary.Height;
            }
            else
            {
                result = 4 + this.llPrimary.Top + this.raGreater(this.llPrimary.Height, this.llSecondary.Height);
            }
            return result;
        }
        int raGreater(int iVal1, int iVal2)
        {
            int result;
            if (iVal1 > iVal2)
            {
                result = iVal1;
            }
            else
            {
                result = iVal2;
            }
            return result;
        }
        void raMovePool(int Index, int X, int Y)
        {
            Label label;
            ComboBox comboBox;
            Label label2;
            object Instance;
            if (Index == 0)
            {
                label = this.lblPool1;
                comboBox = this.cbPool0;
                label2 = this.lblLocked0;
                Instance = this.llPool0;
            }
            else if (Index == 1)
            {
                label = this.lblPool2;
                comboBox = this.cbPool1;
                label2 = this.lblLocked1;
                Instance = this.llPool1;
            }
            else if (Index == 2)
            {
                label = this.lblPool3;
                comboBox = this.cbPool2;
                label2 = this.lblLocked2;
                Instance = this.llPool2;
            }
            else if (Index == 3)
            {
                label = this.lblPool4;
                comboBox = this.cbPool3;
                label2 = this.lblLocked3;
                Instance = this.llPool3;
            }
            else
            {
                if (Index != 4)
                {
                    return;
                }
                label = this.lblEpic;
                comboBox = this.cbAncillary;
                label2 = this.lblLockedAncillary;
                Instance = this.llAncillary;
            }
            Point point = new Point(X, Y);
            label.Location = point;
            point.Y += label.Height;
            comboBox.Location = point;
            label2.Location = point;
            point.Y += comboBox.Height;
            NewLateBinding.LateSet(Instance, null, "Location", new object[]
            {
                point
            }, null, null);
        }
        bool raToFloat()
        {
            bool flag = false;
            this.llPool0.Height = this.llPool0.DesiredHeight;
            this.llPool1.Height = this.llPool1.DesiredHeight;
            this.llPool2.Height = this.llPool2.DesiredHeight;
            this.llPool3.Height = this.llPool3.DesiredHeight;
            this.llAncillary.Height = this.llAncillary.DesiredHeight;
            Rectangle poolRect3 = this.raGetPoolRect(0);
            this.raMovePool(1, poolRect3.Left, poolRect3.Bottom);
            poolRect3 = this.raGetPoolRect(1);
            this.raMovePool(2, poolRect3.Left, poolRect3.Bottom);
            this.FixPrimarySecondaryHeight();
            int num = this.raGreater(this.raGetTop(), this.lblPool3.Top);
            if (num + this.llAncillary.DesiredHeight > base.ClientSize.Height)
            {
                num = base.ClientSize.Height - this.llAncillary.DesiredHeight - this.cbAncillary.Height - this.lblEpic.Height;
                Size size = this.llPrimary.SizeNormal;
                Size sizeNormal = new Size(size.Width, num - 4 - this.llPrimary.Top);
                this.llPrimary.SizeNormal = sizeNormal;
                size = new Size(this.llSecondary.SizeNormal.Width, num - 4 - this.llPrimary.Top);
                this.llSecondary.SizeNormal = size;
            }
            poolRect3 = this.raGetPoolRect(2);
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
            int num = this.llPool0.Top + this.cbPool0.Height * 4 + this.lblPool1.Height * 4;
            int num2 = 3 * this.llAncillary.ActualLineHeight;
            if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
            {
                int num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool1.Height - this.llPool2.Height - this.llPool3.Height;
                if (num3 < num2)
                {
                    num3 = num2;
                }
                if (this.llAncillary.Height > num3)
                {
                    this.llAncillary.Height = num3;
                }
                if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
                {
                    num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool1.Height - this.llPool2.Height - this.llAncillary.Height;
                    if (num3 < num2)
                    {
                        num3 = num2;
                    }
                    this.llPool3.Height = num3;
                    if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
                    {
                        num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool1.Height - this.llPool3.Height - this.llAncillary.Height;
                        if (num3 < num2)
                        {
                            num3 = num2;
                        }
                        this.llPool2.Height = num3;
                        if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
                        {
                            num3 = base.ClientSize.Height - num - this.llPool0.Height - this.llPool2.Height - this.llPool3.Height - this.llAncillary.Height;
                            if (num3 < num2)
                            {
                                num3 = num2;
                            }
                            this.llPool1.Height = num3;
                            if (num + this.llPool0.Height + this.llPool1.Height + this.llPool2.Height + this.llPool3.Height + this.llAncillary.Height > base.ClientSize.Height)
                            {
                                num3 = base.ClientSize.Height - num - this.llPool1.Height - this.llPool2.Height - this.llPool3.Height - this.llAncillary.Height;
                                if (num3 < num2)
                                {
                                    num3 = num2;
                                }
                                this.llPool0.Height = num3;
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
            bool flag = false;
            bool flag2;
            if (this.Drawing == null)
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
                    {
                        this.raToNormal();
                    }
                    else
                    {
                        this.raToFloat();
                    }
                    this.SetAncilPoolHeight();
                    flag2 = flag;
                }
            }
            return flag2;
        }
        void RearrangeAllSlotsInBuild(PowerEntry[] tp, bool notifyUser = false)
        {
            int index = 0;
            int[] numArray = new int[tp.Length - 1 + 1];
            int num = tp.Length - 1;
            for (int index2 = 0; index2 <= num; index2++)
            {
                if (tp[index2].NIDPower != -1 && DatabaseAPI.Database.Power[tp[index2].NIDPower].AllowFrontLoading)
                {
                    numArray[index] = index2;
                    index++;
                }
            }
            int index3 = index;
            int num2 = tp.Length - 1;
            int index6;
            for (int index4 = 0; index4 <= num2; index4++)
            {
                if ((tp[index4].NIDPower != -1 && !DatabaseAPI.Database.Power[tp[index4].NIDPower].AllowFrontLoading) | tp[index4].NIDPower == -1)
                {
                    bool flag = true;
                    int num3 = index4 - 1;
                    for (int index5 = index; index5 <= num3; index5++)
                    {
                        if (tp[index4].Level < tp[numArray[index5]].Level)
                        {
                            int num4 = index5;
                            for (index6 = index3 - 1; index6 >= num4; index6 += -1)
                            {
                                numArray[index6 + 1] = numArray[index6];
                            }
                            numArray[index5] = index4;
                            index3++;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        numArray[index3] = index4;
                        index3++;
                    }
                }
            }
            int[] numArray2 = this.fakeInitialize(new int[]
            {
                3,
                3,
                5,
                5,
                7,
                7,
                9,
                9,
                11,
                11,
                13,
                13,
                15,
                15,
                17,
                17,
                19,
                19,
                21,
                21,
                23,
                23,
                25,
                25,
                27,
                27,
                29,
                29,
                31,
                31,
                31,
                33,
                33,
                33,
                34,
                34,
                34,
                36,
                36,
                36,
                37,
                37,
                37,
                39,
                39,
                39,
                40,
                40,
                40,
                42,
                42,
                42,
                43,
                43,
                43,
                45,
                45,
                45,
                46,
                46,
                46,
                48,
                48,
                48,
                50,
                50,
                50
            });
            bool flag2 = false;
            index6 = 0;
            int num5 = tp.Length - 1;
            for (int index7 = 0; index7 <= num5; index7++)
            {
                int num6 = tp[numArray[index7]].SlotCount - 1;
                for (int index5 = 1; index5 <= num6; index5++)
                {
                    if (index6 == numArray2.Length)
                    {
                        flag2 = true;
                    }
                    tp[numArray[index7]].Slots[index5].Level = 50;
                    if (!flag2)
                    {
                        if (tp[numArray[index7]].NIDPower == -1 || !DatabaseAPI.Database.Power[tp[numArray[index7]].NIDPower].AllowFrontLoading)
                        {
                            while (numArray2[index6] <= tp[numArray[index7]].Level)
                            {
                                index6++;
                                if (index6 == numArray2.Length)
                                {
                                    flag2 = true;
                                    break;
                                }
                            }
                        }
                        tp[numArray[index7]].Slots[index5].Level = numArray2[index6] - 1;
                        index6++;
                    }
                }
            }
            if (flag2 && notifyUser)
            {
                Interaction.MsgBox("The current arrangement of powers and their slots is impossible in-game. Invalid slots have been darkened and marked as level 51.", MsgBoxStyle.OkOnly, null);
            }
        }
        void RedrawUnderPopup(Rectangle RectRedraw)
        {
            Rectangle Clip = RectRedraw;
            Clip.Offset(-this.pnlGFXFlow.Location.X, -this.pnlGFXFlow.Location.Y);
            this.Drawing.Refresh(Clip);
            if (this.llPrimary.Bounds.IntersectsWith(RectRedraw))
            {
                this.llPrimary.Refresh();
            }
            if (this.llSecondary.Bounds.IntersectsWith(RectRedraw))
            {
                this.llSecondary.Refresh();
            }
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
            if (this.raGetPoolRect(4).IntersectsWith(RectRedraw))
            {
                this.llAncillary.Refresh();
                this.cbAncillary.Refresh();
                this.lblEpic.Refresh();
                this.lblLockedAncillary.Refresh();
            }
        }
        public void RefreshInfo()
        {
            this.info_Totals();
            if (this.dvLastPower > -1)
            {
                this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
            }
        }
        void RefreshTabs(int iPower, I9Slot iEnh, int iLevel = -1)
        {
            if (iEnh.Enh > -1)
            {
                this.Info_Power(iPower, iLevel, false, false);
                this.Info_Enhancement(iEnh, iLevel);
            }
            else
            {
                this.Info_Power(iPower, iLevel, true, false);
            }
        }
        void RemoveSlotFromTempList(PowerEntry tp, int slotIDX)
        {
            int num = tp.SlotCount - 2;
            for (int index = slotIDX; index <= num; index++)
            {
                tp.Slots[index] = tp.Slots[index + 1];
            }
            tp.Slots = (SlotEntry[])Utils.CopyArray(tp.Slots, new SlotEntry[tp.SlotCount - 2 + 1]);
        }
        void SetAncilPoolHeight()
        {
            int num = this.llAncillary.ActualLineHeight * 2;
            int num2 = 1;
            do
            {
                if (this.llAncillary.Top + num + this.llAncillary.ActualLineHeight <= base.ClientRectangle.Size.Height)
                {
                    num += this.llAncillary.ActualLineHeight;
                }
                num2++;
            }
            while (num2 <= 4);
            if (num < this.llAncillary.ActualLineHeight * 2)
            {
                num = this.llAncillary.ActualLineHeight * 2;
            }
            this.llAncillary.Height = num;
        }
        void setColumns(int columns)
        {
            MidsContext.Config.Columns = columns;
            this.Drawing.Columns = columns;
            this.DoResize();
            this.DoRedraw();
            this.SetFormWidth(false);
            this.tsView4Col.Checked = (columns == 4);
            this.tsView3Col.Checked = (columns == 3);
            this.tsView2Col.Checked = (columns == 2);
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
        public void SetDataViewTab(int Index)
        {
            if (Index == 2)
            {
                this.Drawing.InterfaceMode = Enums.eInterfaceMode.PowerToggle;
                this.DoRedraw();
                MidsContext.Config.Tips.Show(Tips.TipType.TotalsTab);
            }
            else if (this.Drawing.InterfaceMode != Enums.eInterfaceMode.Normal)
            {
                this.Drawing.InterfaceMode = Enums.eInterfaceMode.Normal;
                this.DoRedraw();
            }
        }
        void SetFormHeight(bool Force = false)
        {
            int iVal2 = 0;
            int num = base.Height - base.ClientSize.Height;
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
                    case Enums.eVisibleSize.VerySmall:
                        return;
                    case Enums.eVisibleSize.Compact:
                        switch (this.Drawing.EpicColumns)
                        {
                            case false:
                                iVal2 = this.raGreater(bottom, this.llAncillary.Top + this.llAncillary.ActualLineHeight * this.llAncillary.Items.Length) + 4 + num;
                                break;
                            case true:
                                iVal2 = this.raGreater(bottom, iVal2) + 4 + num;
                                break;
                        }
                        break;
                    default:
                        return;
                }
            }
            if ((iVal2 > base.Height || Force) | this.dvAnchored.IsDocked)
            {
                if (Screen.PrimaryScreen.WorkingArea.Height > iVal2)
                {
                    base.Height = iVal2;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Height < iVal2)
                {
                    base.Height = Screen.PrimaryScreen.WorkingArea.Height;
                }
            }
            this.NoResizeEvent = false;
        }
        void SetFormWidth(bool ToFull = false)
        {
            this.NoResizeEvent = true;
            int num = base.Width - base.ClientSize.Width;
            if (MainModule.MidsController.IsAppInitialized)
            {
                int num2;
                if (MidsContext.Config.Columns == 2)
                {
                    if (ToFull)
                    {
                        num2 = num + this.Drawing.GetRequiredDrawingArea().Width + this.pnlGFXFlow.Left;
                    }
                    else
                    {
                        num2 = num + this.pnlGFXFlow.Left + this.Drawing.ScaleDown(this.Drawing.GetRequiredDrawingArea().Width);
                    }
                }
                else
                {
                    num2 = num + this.Drawing.GetRequiredDrawingArea().Width + this.pnlGFXFlow.Left;
                }
                num2 += 8;
                if (Screen.PrimaryScreen.WorkingArea.Width > num2)
                {
                    base.Width = num2;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width <= num2)
                {
                    base.Width = Screen.PrimaryScreen.WorkingArea.Width - num;
                }
                this.NoResizeEvent = false;
                this.DoResize();
            }
        }
        public void SetMiniList(PopUp.PopupData iData, string iTitle, int bxHeight = 2048)
        {
            if (this.fMini == null)
            {
                this.fMini = new frmMiniList(this);
            }
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
            int num = base.ClientSize.Height - ObjectBounds.Bottom;
            int left = ObjectBounds.Left;
            int num2 = base.ClientSize.Width - ObjectBounds.Right;
            Rectangle rectangle = new Rectangle(0, 0, 1, 1);
            if (this.dvAnchored.Visible)
            {
                rectangle.X = this.dvAnchored.Left;
                rectangle.Y = this.dvAnchored.Top;
                rectangle.Width = this.dvAnchored.Width;
                rectangle.Height = this.dvAnchored.Height;
            }
            int x = -1;
            if (!PowerListing & !Picker)
            {
                if (num >= this.I9Popup.Height)
                {
                    y = ObjectBounds.Bottom;
                }
                else if (top >= this.I9Popup.Height)
                {
                    y = ObjectBounds.Top - this.I9Popup.Height;
                }
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
                {
                    y = ObjectBounds.Bottom;
                }
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
                else if (num >= this.I9Popup.Height)
                {
                    y = ObjectBounds.Bottom;
                }
                else if (top >= this.I9Popup.Height)
                {
                    y = ObjectBounds.Top - this.I9Popup.Height;
                }
                else
                {
                    y = ObjectBounds.Bottom;
                }
            }
            else if (PowerListing)
            {
                y = (int)Math.Round((double)ObjectBounds.Top + (double)ObjectBounds.Height / 2.0 - (double)this.I9Popup.Height / 2.0);
                if (y < 0)
                {
                    y = 0;
                }
                if (y + this.I9Popup.Height > base.ClientSize.Height)
                {
                    y = base.ClientSize.Height - this.I9Popup.Height;
                }
                x = ObjectBounds.Right;
            }
            if (x < 0)
            {
                x = (int)Math.Round((double)ObjectBounds.Left + (double)ObjectBounds.Width / 2.0 - (double)this.I9Popup.Width / 2.0);
                if ((double)left < (double)(this.I9Popup.Width - ObjectBounds.Width) / 2.0)
                {
                    x = left;
                }
                else if ((double)num2 < (double)(this.I9Popup.Width - ObjectBounds.Width) / 2.0)
                {
                    x = base.ClientSize.Width - this.I9Popup.Width;
                }
            }
            this.I9Popup.BringToFront();
            Point location = new Point(x, y);
            this.I9Popup.Location = location;
        }
        void SetTitleBar(bool Hero = true)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Hero = MainModule.MidsController.Toon.IsHero();
            }
            string str2 = "";
            if (MainModule.MidsController.Toon != null)
            {
                if (this.LastFileName != "")
                {
                    str2 = FileIO.StripPath(this.LastFileName) + " - ";
                    this.tsFileSave.Text = "&Save '" + FileIO.StripPath(this.LastFileName) + "'";
                }
                else
                {
                    this.tsFileSave.Text = "&Save";
                }
            }
            else
            {
                this.tsFileSave.Text = "&Save";
            }
            str2 += "Pine's Hero Designer";
            if (!Hero)
            {
                str2 = str2.Replace("Hero", "Villain");
            }
            if (MidsContext.Config.MasterMode)
            {
                this.Text = string.Concat(new string[]
                {
                    str2,
                    " (Master Mode) v",
                    Strings.Format(MainModule.MidsController.HeroDesignerVersion, "#0.0#######"),
                    " (DB: I",
                    Conversions.ToString(DatabaseAPI.Database.Issue),
                    " - Updated: ",
                    Strings.Format(DatabaseAPI.Database.Date, " dd / MMM / yyyy @ hh:mm tt"),
                    ")"
                });
            }
            else
            {
                string str3 = Strings.Format(MainModule.MidsController.HeroDesignerVersion, "#0.0#######");
                if (str3.Length > 5)
                {
                    str3 = str3.Substring(0, 5);
                }
                str3 = str3.Trim("0".ToCharArray());
                this.Text = string.Concat(new string[]
                {
                    str2,
                    " v",
                    str3,
                    " (Database Issue: ",
                    Conversions.ToString(DatabaseAPI.Database.Issue),
                    " - Updated: ",
                    Strings.Format(DatabaseAPI.Database.Date, "dd/MM/yy"),
                    ")"
                });
            }
        }
        void ShallowCopyPowerList(PowerEntry[] source)
        {
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                MidsContext.Character.CurrentBuild.Powers[index] = source[index];
            }
        }
        public void ShowAnchoredDataView()
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
            base.OnResizeEnd(new EventArgs());
            this.NoResizeEvent = false;
            this.RefreshInfo();
            this.ReArrange(false);
            this.FloatingDataForm = null;
        }
        void ShowPopup(int nIDPowerset, int nIDClass, Rectangle rBounds, string ExtraString = "")
        {
            if (!MidsContext.Config.ShowPopup)
            {
                this.HidePopup();
            }
            else
            {
                PopUp.PopupData iPopup = default(PopUp.PopupData);
                Rectangle bounds = this.I9Popup.Bounds;
                this.RedrawUnderPopup(bounds);
                if (nIDPowerset > -1 | nIDClass > -1)
                {
                    int num;
                    if (nIDPowerset > -1)
                    {
                        num = nIDPowerset;
                    }
                    else
                    {
                        num = nIDClass;
                    }
                    if (this.I9Popup.psIDX != num)
                    {
                        if (nIDPowerset > -1)
                        {
                            iPopup = MainModule.MidsController.Toon.PopPowersetInfo(nIDPowerset, ExtraString);
                        }
                        else
                        {
                            iPopup = MidsContext.Character.Archetype.PopInfo();
                        }
                        bool flag = true;
                        if (flag & iPopup.Sections != null)
                        {
                            this.I9Popup.SetPopup(iPopup);
                            this.PopUpVisible = true;
                            this.SetPopupLocation(rBounds, false, true);
                        }
                        else
                        {
                            this.HidePopup();
                        }
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
        void ShowPopup(int hIDX, int pIDX, int sIDX, Point e, Rectangle rBounds, I9Slot eSlot = null, int setIDX = -1)
        {
            if (!MidsContext.Config.ShowPopup)
            {
                this.HidePopup();
            }
            else
            {
                bool flag = false;
                PopUp.PopupData iPopup = default(PopUp.PopupData);
                bool Picker = false;
                bool PowerListing = false;
                Rectangle bounds = this.I9Popup.Bounds;
                if (hIDX < 0 & pIDX > -1)
                {
                    hIDX = MidsContext.Character.CurrentBuild.FindInToonHistory(pIDX);
                }
                PowerEntry powerEntry = null;
                if (hIDX > -1)
                {
                    powerEntry = MidsContext.Character.CurrentBuild.Powers[hIDX];
                }
                if (this.I9Popup.hIDX != hIDX | this.I9Popup.eIDX != sIDX | this.I9Popup.pIDX != pIDX | (this.I9Popup.hIDX == -1 | this.I9Popup.eIDX == -1 | this.I9Popup.pIDX == -1))
                {
                    Rectangle rectangle = default(Rectangle);
                    if (hIDX > -1 & sIDX < 0 & pIDX < 0 & eSlot == null & setIDX < 0)
                    {
                        rectangle = this.Drawing.PowerBoundsUnScaled(hIDX);
                        Point e2 = new Point(this.Drawing.ScaleUp(e.X), this.Drawing.ScaleUp(e.Y));
                        if (this.Drawing.WithinPowerBar(rectangle, e2))
                        {
                            if (powerEntry.NIDPower > 0)
                            {
                                iPopup = MainModule.MidsController.Toon.PopPowerInfo(hIDX, powerEntry.NIDPower);
                            }
                            flag = true;
                        }
                    }
                    else if (sIDX > -1)
                    {
                        rectangle = this.Drawing.PowerBoundsUnScaled(hIDX);
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
                                rectangle = this.Dilate(this.Drawing.ScaleDown(rectangle), 2);
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
                    {
                        this.HidePopup();
                    }
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
                index++;
            }
            while (index <= 19);
            if (MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level < MidsContext.Character.CurrentBuild.Powers[destPower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[destPower].NIDPower].AllowFrontLoading)
            {
                if (this.ddsa[13] == 0)
                {
                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Slot being level-swapped is too low for the destination power", new string[]
                    {
                        "Allow swap anyway (mark as invalid)"
                    });
                    this.ddsa[13] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                    {
                        MidsContext.Config.DragDropScenarioAction[13] = this.ddsa[13];
                    }
                }
                if (this.ddsa[13] == 1)
                {
                    return;
                }
            }
            if (MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level < MidsContext.Character.CurrentBuild.Powers[sourcePower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[sourcePower].NIDPower].AllowFrontLoading)
            {
                if (this.ddsa[14] == 0)
                {
                    MyProject.Forms.frmOptionListDlg.ShowWithOptions(true, 0, "Slot being level-swapped is too low for the source power", new string[]
                    {
                        "Allow swap anyway (mark as invalid)"
                    });
                    this.ddsa[14] = (short)MyProject.Forms.frmOptionListDlg.DialogResult;
                    if (MyProject.Forms.frmOptionListDlg.chkRemember.Checked)
                    {
                        MidsContext.Config.DragDropScenarioAction[14] = this.ddsa[14];
                    }
                }
                if (this.ddsa[14] == 1)
                {
                    return;
                }
            }
            int level = MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level;
            MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level = MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level;
            MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level = level;
            this.PowerModified();
            this.DoRedraw();
        }
        public void smlRespecLong(int iLevel, bool Mode2)
        {
            if (Mode2)
            {
                this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper2(true, iLevel), "Respec Helper", 5096);
            }
            else
            {
                this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper(true, iLevel), "Respec Helper", 4072);
            }
            this.fMini.Width = 350;
            this.fMini.SizeMe();
        }
        public void smlRespecShort(int iLevel, bool Mode2)
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
            {
                this.EndFlip();
            }
            if (iPowerIndex > -1 && MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length != 0)
            {
                this.FileModified = true;
                MainModule.MidsController.Toon.FlipSlots(iPowerIndex);
                this.RefreshInfo();
                this.FlipPowerID = iPowerIndex;
                this.FlipSlotState = new int[MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length - 1 + 1];
                int num = this.FlipSlotState.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    this.FlipSlotState[index] = -(this.FlipStepDelay * index);
                }
                this.FlipGP = new PowerEntry(-1, null, false);
                this.FlipGP.Assign(MidsContext.Character.CurrentBuild.Powers[iPowerIndex]);
                this.FlipGP.Slots = new SlotEntry[0];
                if (this.tmrGfx == null)
                {
                    this.tmrGfx = new System.Windows.Forms.Timer(base.Container);
                }
                this.tmrGfx.Interval = this.FlipInterval;
                this.FlipActive = true;
                this.tmrGfx.Enabled = true;
                this.tmrGfx.Start();
            }
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
            if (e.Clicks == 2)
            {
                this.tempPowersButton.Checked = false;
                bool flag = false;
                if (this.fTemp == null)
                {
                    flag = true;
                }
                else if (this.fTemp.IsDisposed)
                {
                    flag = true;
                }
                if (flag)
                {
                    IPower power = DatabaseAPI.Database.Power[DatabaseAPI.NidFromStaticIndexPower(3259)];
                    List<IPower> iPowers = new List<IPower>();
                    int num = power.NIDSubPower.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        iPowers.Add(DatabaseAPI.Database.Power[power.NIDSubPower[index]]);
                    }
                    frmMain iParent = this;
                    this.fTemp = new frmAccolade(ref iParent, iPowers);
                    this.fTemp.Text = "Temporary Powers";
                }
                if (!this.fTemp.Visible)
                {
                    this.fTemp.Show(this);
                }
            }
        }
        void tlsDPA_Click(object sender, EventArgs e)
        {
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPA;
            this.SetDamageMenuCheckMarks();
            this.DisplayFormatChanged();
        }
        void tmrGfx_Tick(object sender, EventArgs e)
        {
            if (this.FlipActive)
            {
                this.doFlipStep();
            }
        }
        bool ToggleClicked(int hID, int iX, int iY)
        {
            Rectangle rectangle = default(Rectangle);
            bool flag;
            if (hID < 0)
            {
                flag = false;
            }
            else if (MidsContext.Character.CurrentBuild.Powers[hID].IDXPower < 0)
            {
                flag = false;
            }
            else
            {
                Rectangle rectangle2 = new Rectangle
                {
                    Location = this.Drawing.PowerPosition(MidsContext.Character.CurrentBuild.Powers[hID], -1),
                    Size = this.Drawing.bxPower[0].Size
                };
                rectangle.Height = 15;
                rectangle.Width = rectangle.Height;
                rectangle.Y = (int)Math.Round((double)rectangle2.Top + (double)(rectangle2.Height - rectangle.Height) / 2.0);
                rectangle.X = (int)Math.Round((double)rectangle2.Right - ((double)rectangle.Width + (double)(rectangle2.Height - rectangle.Height) / 2.0));
                flag = (iX > rectangle.X & iX < rectangle.Right & iY > rectangle.Top & iY < rectangle.Bottom);
            }
            return flag;
        }
        void tsAbout_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            new frmAbout
            {
                ibClose =
                {
                    IA = this.Drawing.pImageAttributes,
                    ImageOff = this.Drawing.bxPower[2].Bitmap,
                    ImageOn = this.Drawing.bxPower[3].Bitmap
                }
            }.ShowDialog(this);
            this.FloatTop(true);
        }
        void tsAdvDBEdit_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            new frmDBEdit().ShowDialog(this);
            this.FloatTop(true);
        }
        void tsAdvFreshInstall_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (MidsContext.Config.FreshInstall)
            {
                MidsContext.Config.FreshInstall = false;
                MidsContext.Config.SaveFolderChecked = true;
                Interaction.MsgBox("Fresh Install flag has been unset!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                MidsContext.Config.FreshInstall = true;
                MidsContext.Config.SaveFolderChecked = false;
                Interaction.MsgBox("Fresh Install flag has been set!", MsgBoxStyle.OkOnly, null);
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
            }
            clsXMLUpdate.BugReport(at, pri, sec, "");
        }
        void tsClearAllEnh_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (Interaction.MsgBox("Really clear all slotted enhancements?\r\nThis will not clear the alternate slotting, only the currently active slots.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    int num2 = MidsContext.Character.CurrentBuild.Powers[index].Slots.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        MidsContext.Character.CurrentBuild.Powers[index].Slots[index2].Enhancement.Enh = -1;
                    }
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
            if (frmCalcOpt.ShowDialog(this) == DialogResult.OK)
            {
                this.UpdateControls(false);
                this.UpdateOtherFormsFonts();
            }
            frmCalcOpt.Dispose();
            this.tsIODefault.Text = "Default (" + Conversions.ToString(MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
            this.FloatTop(true);
        }
        void tsDynamic_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
                MidsContext.Character.ResetLevel();
                this.PowerModified();
            }
        }
        void tsEnhToDO_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character != null)
            {
                if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.DualO))
                {
                    this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.DualO;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToEven_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.Even;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToMinus1_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusOne;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToMinus2_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusTwo;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToMinus3_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.MinusThree;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToNone_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.None;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToPlus1_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusOne;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToPlus2_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusTwo;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToPlus3_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusThree;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToPlus4_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusFour;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToPlus5_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                Enums.eEnhRelative newVal = Enums.eEnhRelative.PlusFive;
                if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                {
                    this.I9Picker.UI.Initial.RelLevel = newVal;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToSO_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character != null)
            {
                if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.SingleO))
                {
                    this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.SingleO;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsEnhToTO_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character != null)
            {
                if (MidsContext.Character.CurrentBuild.SetEnhGrades(Enums.eEnhGrade.TrainingO))
                {
                    this.I9Picker.UI.Initial.GradeID = Enums.eEnhGrade.TrainingO;
                }
                this.info_Totals();
                this.DoRedraw();
            }
        }
        void tsExport_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            MidsContext.Config.LongExport = false;
            frmForum frmForum2 = new frmForum
            {
                BackColor = this.BackColor
            };
            frmForum2.ibCancel.IA = this.Drawing.pImageAttributes;
            frmForum2.ibCancel.ImageOff = this.Drawing.bxPower[2].Bitmap;
            frmForum2.ibCancel.ImageOn = this.Drawing.bxPower[3].Bitmap;
            frmForum2.ibExport.IA = this.Drawing.pImageAttributes;
            frmForum2.ibExport.ImageOff = this.Drawing.bxPower[2].Bitmap;
            frmForum2.ibExport.ImageOn = this.Drawing.bxPower[3].Bitmap;
            frmForum2.ShowDialog(this);
            this.FloatTop(true);
        }
        void tsExportDataLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true), true);
            Interaction.MsgBox("The data link has been placed on the clipboard and is ready to paste.", MsgBoxStyle.Information, "Export Done");
        }
        void tsExportLong_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            MidsContext.Config.LongExport = true;
            frmForum frmForum2 = new frmForum
            {
                BackColor = this.BackColor
            };
            frmForum2.ibCancel.IA = this.Drawing.pImageAttributes;
            frmForum2.ibCancel.ImageOff = this.Drawing.bxPower[2].Bitmap;
            frmForum2.ibCancel.ImageOn = this.Drawing.bxPower[3].Bitmap;
            frmForum2.ibExport.IA = this.Drawing.pImageAttributes;
            frmForum2.ibExport.ImageOff = this.Drawing.bxPower[2].Bitmap;
            frmForum2.ibExport.ImageOn = this.Drawing.bxPower[3].Bitmap;
            frmForum2.ShowDialog(this);
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
                MsgBoxResult msgBoxResult = Interaction.MsgBox("Current hero/villain data will be discarded, are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Question");
                this.FloatTop(true);
                if (msgBoxResult == MsgBoxResult.No)
                {
                    return;
                }
            }
            this.FloatTop(false);
            if (this.dlgOpen.ShowDialog() == DialogResult.OK)
            {
                this.DoOpen(this.dlgOpen.FileName);
            }
            this.FloatTop(true);
        }
        void tsFilePrint_Click(object sender, EventArgs e)
        {
            new frmPrint().ShowDialog(this);
        }
        void tsFileQuit_Click(object sender, EventArgs e)
        {
            base.Close();
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
                btnClose =
                {
                    IA = this.Drawing.pImageAttributes,
                    ImageOff = this.Drawing.bxPower[2].Bitmap,
                    ImageOn = this.Drawing.bxPower[3].Bitmap
                }
            };
            this.FloatTop(false);
            frmReadme.ShowDialog(this);
            this.FloatTop(true);
        }
        void tsHelperLong_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            new FrmInputLevel(ref iParent, true, false).ShowDialog(this);
        }
        void tsHelperLong2_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            new FrmInputLevel(ref iParent, true, true).ShowDialog(this);
        }
        void tsHelperShort_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            new FrmInputLevel(ref iParent, false, false).ShowDialog(this);
        }
        void tsHelperShort2_Click(object sender, EventArgs e)
        {
            frmMain iParent = this;
            new FrmInputLevel(ref iParent, false, true).ShowDialog(this);
        }
        void tsImport_Click(object sender, EventArgs e)
        {
            this.command_ForumImport();
        }
        void tsIODefault_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, false))
            {
                this.I9Picker.LastLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
            }
            if (this.Drawing != null)
            {
                this.DoRedraw();
            }
        }
        void tsIOMax_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, true))
            {
                this.I9Picker.LastLevel = 50;
            }
            if (this.Drawing != null)
            {
                this.DoRedraw();
            }
        }
        void tsIOMin_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, true, false))
            {
                this.I9Picker.LastLevel = 10;
            }
            if (this.Drawing != null)
            {
                this.DoRedraw();
            }
        }
        void tsLevelUp_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon != null)
            {
                MidsContext.Config.BuildMode = Enums.dmModes.LevelUp;
                MidsContext.Character.ResetLevel();
                this.PowerModified();
            }
        }
        void tsPatchNotes_Click(object sender, EventArgs e)
        {
            string str = OS.GetApplicationPath() + "Data\\patch.rtf";
            if (File.Exists(str))
            {
                frmReadme frmReadme = new frmReadme(str)
                {
                    btnClose =
                    {
                        IA = this.Drawing.pImageAttributes,
                        ImageOff = this.Drawing.bxPower[2].Bitmap,
                        ImageOn = this.Drawing.bxPower[3].Bitmap
                    }
                };
                this.FloatTop(false);
                frmReadme.ShowDialog(this);
                this.FloatTop(true);
            }
            else
            {
                this.FloatTop(false);
                Interaction.MsgBox("No recent patches have been installed.", MsgBoxStyle.Information, "No Notes");
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
            if (Interaction.MsgBox("Really remove all slots?\r\nThis will not remove the slots granted automatically with powers, but will remove all the slots you placed manually.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") == MsgBoxResult.Yes)
            {
                int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].SlotCount > 1)
                    {
                        MidsContext.Character.CurrentBuild.Powers[index].Slots = (SlotEntry[])Utils.CopyArray(MidsContext.Character.CurrentBuild.Powers[index].Slots, new SlotEntry[1]);
                    }
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
            IMessager iLoadFrm = null;
            clsXMLUpdate.eCheckResponse eCheckResponse = clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
            if (eCheckResponse != clsXMLUpdate.eCheckResponse.Updates & eCheckResponse != clsXMLUpdate.eCheckResponse.FailedWithMessage)
            {
                Interaction.MsgBox("No Updates.", MsgBoxStyle.Information, "Update Check");
            }
            if (eCheckResponse == clsXMLUpdate.eCheckResponse.Updates && clsXmlUpdate.RestartNeeded && Interaction.MsgBox("Exit Now?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Update Downloaded") == MsgBoxResult.Yes && !this.CloseCommand())
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
            if (MainModule.MidsController.Toon != null)
            {
                this.FloatSets(true);
            }
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
            if (!this.NoUpdate)
            {
                MidsContext.Character.Name = this.txtName.Text;
                this.DisplayName();
            }
        }
        public void UnSetMiniList()
        {
            if (this.fMini != null)
            {
                this.fMini.Dispose();
            }
            this.fMini = null;
            GC.Collect();
        }
        public void UpdateColours(bool skipDraw = false)
        {
            this.myDataView.DrawVillain = !MidsContext.Character.IsHero();
            bool flag;
            if (this.myDataView.DrawVillain)
            {
                flag = (this.I9Picker.ForeColor.R != byte.MaxValue);
                this.BackColor = Color.FromArgb(0, 0, 0);
                this.lblATLocked.BackColor = Color.FromArgb(255, 128, 128);
                this.I9Picker.ForeColor = Color.FromArgb(255, 0, 0);
            }
            else
            {
                flag = (this.I9Picker.ForeColor.R != 96);
                this.BackColor = Color.FromArgb(0, 0, 0);
                this.lblATLocked.BackColor = Color.FromArgb(128, 128, 255);
                this.I9Picker.ForeColor = Color.FromArgb(96, 48, 255);
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
            ListLabelV2 iList = this.llPrimary;
            this.UpdateLLColours(ref iList);
            this.llPrimary = iList;
            iList = this.llSecondary;
            this.UpdateLLColours(ref iList);
            this.llSecondary = iList;
            iList = this.llAncillary;
            this.UpdateLLColours(ref iList);
            this.llAncillary = iList;
            iList = this.llPool0;
            this.UpdateLLColours(ref iList);
            this.llPool0 = iList;
            iList = this.llPool1;
            this.UpdateLLColours(ref iList);
            this.llPool1 = iList;
            iList = this.llPool2;
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
            this.ibSets.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibPvX.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.incarnateButton.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.tempPowersButton.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.accoladeButton.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.heroVillain.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibVetPools.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibTotals.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibMode.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibSlotLevels.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibPopup.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibRecipe.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            this.ibAccolade.SetImages(this.Drawing.pImageAttributes, this.Drawing.bxPower[2].Bitmap, this.Drawing.bxPower[3].Bitmap);
            if (flag)
            {
                if (!skipDraw)
                {
                    this.DoRedraw();
                }
                this.UpdateDMBuffer();
                this.pbDynMode.Refresh();
            }
        }
        void UpdateControls(bool ForceComplete = false)
        {
            this.NoUpdate = true;
            Archetype[] all = Array.FindAll<Archetype>(DatabaseAPI.Database.Classes, new Predicate<Archetype>(this.GetPlayableClasses));
            if (this.ComboCheckAT(ref all))
            {
                this.cbAT.BeginUpdate();
                this.cbAT.Items.Clear();
                this.cbAT.Items.AddRange(all);
                this.cbAT.EndUpdate();
            }
            if (this.cbAT.SelectedItem == null)
            {
                this.cbAT.SelectedItem = MidsContext.Character.Archetype;
            }
            else if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Idx", new object[0], null, null, null), MidsContext.Character.Archetype.Idx, false))
            {
                this.cbAT.SelectedItem = MidsContext.Character.Archetype;
            }
            this.ibPvX.Checked = !MidsContext.Config.Inc.PvE;
            if (this.ComboCheckOrigin())
            {
                this.cbOrigin.BeginUpdate();
                this.cbOrigin.Items.Clear();
                this.cbOrigin.Items.AddRange((object[])NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "Origin", new object[0], null, null, null));
                this.cbOrigin.EndUpdate();
            }
            if (this.cbOrigin.SelectedIndex != MidsContext.Character.Origin)
            {
                if (MidsContext.Character.Origin < this.cbOrigin.Items.Count)
                {
                    this.cbOrigin.SelectedIndex = MidsContext.Character.Origin;
                }
                else
                {
                    this.cbOrigin.SelectedIndex = 0;
                }
                I9Gfx.SetOrigin(Conversions.ToString(this.cbOrigin.SelectedItem));
            }
            ComboBox iCB = this.cbPrimary;
            frmMain.ComboCheckPS(ref iCB, Enums.PowersetType.Primary, Enums.ePowerSetType.Primary);
            this.cbPrimary = iCB;
            iCB = this.cbSecondary;
            frmMain.ComboCheckPS(ref iCB, Enums.PowersetType.Secondary, Enums.ePowerSetType.Secondary);
            this.cbSecondary = iCB;
            if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
            {
                this.cbSecondary.Enabled = false;
            }
            else
            {
                this.cbSecondary.Enabled = true;
            }
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
            {
                this.cbAncillary.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[7], powersetIndexes);
            }
            else
            {
                this.cbAncillary.SelectedIndex = 0;
            }
            if (MidsContext.Character.Powersets[7] == null)
            {
                this.cbAncillary.Enabled = false;
            }
            else
            {
                this.cbAncillary.Enabled = true;
            }
            this.UpdatePowerLists();
            this.DisplayName();
            this.cbAT.Enabled = !MainModule.MidsController.Toon.Locked;
            this.cbPool0.Enabled = !MainModule.MidsController.Toon.PoolLocked[0];
            this.cbPool1.Enabled = !MainModule.MidsController.Toon.PoolLocked[1];
            this.cbPool2.Enabled = !MainModule.MidsController.Toon.PoolLocked[2];
            this.cbPool3.Enabled = !MainModule.MidsController.Toon.PoolLocked[3];
            this.cbAncillary.Enabled = !MainModule.MidsController.Toon.PoolLocked[4];
            this.lblATLocked.Text = Conversions.ToString(NewLateBinding.LateGet(this.cbAT.SelectedItem, null, "DisplayName", new object[0], null, null, null));
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
            int num = this.llPrimary.Items.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                this.llPrimary.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            }
            int num2 = this.llSecondary.Items.Length - 1;
            for (int index2 = 0; index2 <= num2; index2++)
            {
                this.llSecondary.Items[index2].Bold = MidsContext.Config.RtFont.PairedBold;
            }
            this.heroVillain.Checked = !MidsContext.Character.IsHero();
            Point iLocation = new Point(this.llPrimary.Left, this.llPrimary.Top + this.raGreater(this.llPrimary.SizeNormal.Height, this.llSecondary.SizeNormal.Height) + 5);
            this.dvAnchored.SetLocation(iLocation, ForceComplete);
            this.llPrimary.SuspendRedraw = false;
            this.llSecondary.SuspendRedraw = false;
            if (this.myDataView != null && (this.Drawing.InterfaceMode == Enums.eInterfaceMode.Normal & this.myDataView.TabPageIndex == 2))
            {
                this.dvAnchored_TabChanged(this.myDataView.TabPageIndex);
            }
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
            if (this.Drawing != null && MainModule.MidsController.Toon != null)
            {
                if (this.dmBuffer == null)
                {
                    this.dmBuffer = new ExtendedBitmap(this.pbDynMode.Width, this.pbDynMode.Height);
                }
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
                    {
                        iStr += "s";
                    }
                }
                if (MainModule.MidsController.Toon.Complete)
                {
                    if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                    {
                        ePowerState = Enums.ePowerState.Used;
                    }
                    iStr = "Complete";
                }
                Rectangle rectangle = new Rectangle(0, 0, this.Drawing.bxPower[(int)ePowerState].Size.Width, this.Drawing.bxPower[(int)ePowerState].Size.Height);
                Rectangle destRect = new Rectangle(0, 0, this.pbDynMode.Width, this.pbDynMode.Height);
                StringFormat stringFormat = new StringFormat();
                Font bFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                if (ePowerState == Enums.ePowerState.Open)
                {
                    this.dmBuffer.Graphics.DrawImage(this.Drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    this.dmBuffer.Graphics.DrawImage(this.Drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, GraphicsUnit.Pixel, this.Drawing.pImageAttributes);
                }
                float height2 = bFont.GetHeight(this.dmBuffer.Graphics) + 2f;
                RectangleF Bounds = new RectangleF(0f, ((float)this.pbDynMode.Height - height2) / 2f, (float)this.pbDynMode.Width, height2);
                Graphics graphics = this.dmBuffer.Graphics;
                clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, ref graphics, false, false);
            }
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
            string textOff;
            if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
            {
                textOff = "Dynamic";
            }
            else if (MainModule.MidsController.Toon.Complete)
            {
                textOff = "Level-Up";
            }
            else
            {
                textOff = "Level-Up: " + Conversions.ToString(MidsContext.Character.Level + 1);
            }
            this.ibMode.TextOff = textOff;
        }
        void UpdateLLColours(ref ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            if (this.myDataView.DrawVillain)
            {
                iList.ScrollBarColor = Color.FromArgb(255, 0, 0);
                iList.ScrollButtonColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                iList.ScrollBarColor = Color.FromArgb(64, 64, 255);
                iList.ScrollButtonColor = Color.FromArgb(32, 32, 255);
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
                    fIncarnate.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
                    fIncarnate.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fIncarnate.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
                    fIncarnate.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    int num = fIncarnate.llLeft.Items.Length - 1;
                    for (int index = 0; index <= num; index++)
                    {
                        fIncarnate.llLeft.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    }
                    int num2 = fIncarnate.llRight.Items.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        fIncarnate.llRight.Items[index2].Bold = MidsContext.Config.RtFont.PairedBold;
                    }
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
                    fTemp.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
                    fTemp.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fTemp.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
                    fTemp.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    int num3 = fTemp.llLeft.Items.Length - 1;
                    for (int index3 = 0; index3 <= num3; index3++)
                    {
                        fTemp.llLeft.Items[index3].Bold = MidsContext.Config.RtFont.PairedBold;
                    }
                    int num4 = fTemp.llRight.Items.Length - 1;
                    for (int index4 = 0; index4 <= num4; index4++)
                    {
                        fTemp.llRight.Items[index4].Bold = MidsContext.Config.RtFont.PairedBold;
                    }
                    fTemp.llLeft.SuspendRedraw = false;
                    fTemp.llRight.SuspendRedraw = false;
                    fTemp.llLeft.Refresh();
                    fTemp.llRight.Refresh();
                }
            }
            if (this.fAccolade != null)
            {
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
                    fAccolade.llLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
                    fAccolade.llLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fAccolade.llRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(255, 0, 0));
                    fAccolade.llRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    int num5 = fAccolade.llLeft.Items.Length - 1;
                    for (int index5 = 0; index5 <= num5; index5++)
                    {
                        fAccolade.llLeft.Items[index5].Bold = MidsContext.Config.RtFont.PairedBold;
                    }
                    int num6 = fAccolade.llRight.Items.Length - 1;
                    for (int index6 = 0; index6 <= num6; index6++)
                    {
                        fAccolade.llRight.Items[index6].Bold = MidsContext.Config.RtFont.PairedBold;
                    }
                    fAccolade.llLeft.SuspendRedraw = false;
                    fAccolade.llRight.SuspendRedraw = false;
                    fAccolade.llLeft.Refresh();
                    fAccolade.llRight.Refresh();
                }
            }
        }
        void UpdatePowerList(ref ListLabelV2 llPower)
        {
            llPower.SuspendRedraw = true;
            if (llPower.Items.Length == 0)
            {
                llPower.AddItem(new ListLabelV2.ListLabelItemV2("Nothing", ListLabelV2.LLItemState.Disabled, -1, -1, -1, "", ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
            }
            int num = llPower.Items.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                ListLabelV2.ListLabelItemV2 listLabelItemV2 = llPower.Items[index];
                if (listLabelItemV2.nIDSet > -1 & listLabelItemV2.IDXPower > -1)
                {
                    string message = "";
                    listLabelItemV2.ItemState = MainModule.MidsController.Toon.PowerState(listLabelItemV2.nIDPower, ref message);
                    if (listLabelItemV2.ItemState == ListLabelV2.LLItemState.Invalid)
                    {
                        listLabelItemV2.Italic = true;
                    }
                    else
                    {
                        listLabelItemV2.Italic = false;
                    }
                    listLabelItemV2.Bold = MidsContext.Config.RtFont.PairedBold;
                }
            }
            llPower.SuspendRedraw = false;
        }
        void UpdatePowerLists()
        {
            bool flag = false;
            if (this.llPrimary.Items.Length == 0)
            {
                flag = true;
            }
            else if (this.llPrimary.Items[this.llPrimary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[0].nID)
            {
                flag = true;
            }
            if (this.llSecondary.Items.Length == 0)
            {
                flag = true;
            }
            else if (this.llSecondary.Items[this.llSecondary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[1].nID)
            {
                flag = true;
            }
            bool flag2 = false;
            if (this.llAncillary.Items.Length == 0 | MidsContext.Character.Powersets[7] == null)
            {
                flag2 = true;
            }
            else if (this.llAncillary.Items[this.llAncillary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[7].nID)
            {
                flag2 = true;
            }
            ListLabelV2 llPower;
            if (flag)
            {
                llPower = this.llPrimary;
                this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[0]);
                this.llPrimary = llPower;
                llPower = this.llSecondary;
                this.AssemblePowerList(ref llPower, MidsContext.Character.Powersets[1]);
                this.llSecondary = llPower;
            }
            else
            {
                llPower = this.llPrimary;
                this.UpdatePowerList(ref llPower);
                this.llPrimary = llPower;
                llPower = this.llSecondary;
                this.UpdatePowerList(ref llPower);
                this.llSecondary = llPower;
            }
            if (flag2 || flag)
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
        public virtual void GameImport(string buildString)
        {
            string str = "";
            try
            {
                if (buildString.Contains("build.txt"))
                {
                    str = buildString + " is an invalid file name";
                    StreamReader streamReader = new StreamReader(buildString);
                    buildString = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                frmMain.BuildFileLines[] buildFileLinesArray = new frmMain.BuildFileLines[200];
                buildString = buildString.Replace("Level ", "");
                string[] strArray = buildString.Split(new char[]
                {
                    '\r'
                });
                string[] strArray2 = strArray[0].Split(new char[]
                {
                    ':'
                });
                string[] strArray3 = strArray2[1].Split(new char[]
                {
                    ' '
                });
                string[] strArray4 = strArray3[3].Split(new char[]
                {
                    '_'
                });
                MidsContext.Character.Archetype = DatabaseAPI.GetArchetypeByName(strArray4[1]);
                MidsContext.Character.Origin = DatabaseAPI.GetOriginByName(MidsContext.Character.Archetype, strArray3[2]);
                MidsContext.Character.Reset(MidsContext.Character.Archetype, MidsContext.Character.Origin);
                MidsContext.Character.Name = strArray2[0];
                int num = 0;
                int num2 = 0;
                string str2 = "";
                List<string> stringList = new List<string>();
                int index = 0;
                while (index + 4 < strArray.Length - 2)
                {
                    strArray2 = this.BuildLineSplitter(strArray[index + 4]);
                    if (strArray[index + 4][1] != '\t')
                    {
                        num2++;
                        string str3 = "";
                        num = 0;
                        for (int index2 = 1; index2 < strArray2.Length - 1; index2++)
                        {
                            str3 = str3 + strArray2[index2] + ".";
                        }
                        string str4 = str3;
                        str4 = str4.TrimEnd(new char[]
                        {
                            '.'
                        });
                        str3 += strArray2[strArray2.Length - 1];
                        buildFileLinesArray[index].powerSetName = str4;
                        buildFileLinesArray[index].powerName = str3;
                        buildFileLinesArray[index].powerLevel = Convert.ToInt32(strArray2[0].Trim());
                        if (str2 != str4)
                        {
                            if (!str4.Contains("Inherent"))
                            {
                                if (!str4.Contains("Incarnate"))
                                {
                                    stringList.Add(str4);
                                }
                            }
                            str2 = str4;
                        }
                    }
                    else
                    {
                        num = (buildFileLinesArray[index - num - 1].powerSlotsAmount = num + 1);
                        if (strArray[index + 4].Contains("EMPTY"))
                        {
                            buildFileLinesArray[index].enhancementName = "Empty";
                        }
                        else
                        {
                            int num3 = 0;
                            strArray2[1] = strArray2[1].TrimStart(new char[]
                            {
                                '('
                            });
                            strArray2[1] = strArray2[1].TrimEnd(new char[]
                            {
                                ')'
                            });
                            int num4;
                            if (strArray2[1].Contains("+"))
                            {
                                string[] strArray5 = strArray2[1].Split(new char[]
                                {
                                    '+'
                                });
                                num3 = Convert.ToInt32(strArray5[1]);
                                num4 = Convert.ToInt32(strArray5[0]);
                            }
                            else
                            {
                                num4 = Convert.ToInt32(strArray2[1]);
                            }
                            strArray2[0] = strArray2[0].Replace("_Attuned_Superior", "");
                            strArray2[0] = strArray2[0].Replace("Synthetic_", "");
                            strArray2[0] = strArray2[0].Replace("Natural", "Magic");
                            strArray2[0] = strArray2[0].Replace("Technology", "Magic");
                            strArray2[0] = strArray2[0].Replace("Mutation", "Magic");
                            strArray2[0] = strArray2[0].Replace("Science", "Magic");
                            buildFileLinesArray[index].enhancementName = strArray2[0];
                            buildFileLinesArray[index].enhancementRelativeLevel = num3;
                            if (num4 == 1)
                            {
                                num4 = 50;
                            }
                            buildFileLinesArray[index].enhancementLevel = num4 - 1;
                        }
                    }
                    index++;
                }
                if (stringList.Count > MidsContext.Character.Powersets.Length + 1)
                {
                    MidsContext.Character.Powersets = new IPowerset[stringList.Count];
                }
                IPowerset powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[0]);
                if (powersetByName3 == null)
                {
                    str = stringList[0];
                }
                MidsContext.Character.Powersets[0] = powersetByName3;
                powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[1]);
                if (powersetByName3 == null)
                {
                    str = stringList[1];
                }
                MidsContext.Character.Powersets[1] = powersetByName3;
                for (index = 2; index < stringList.Count; index++)
                {
                    powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[index]);
                    if (powersetByName3 == null)
                    {
                        str = stringList[index];
                    }
                    MidsContext.Character.Powersets[index + 1] = powersetByName3;
                }
                MidsContext.Character.CurrentBuild.LastPower = 24;
                int index3 = 0;
                List<PowerEntry> powerEntryList = new List<PowerEntry>();
                for (index = 0; index < num2; index++)
                {
                    str = buildFileLinesArray[index3].powerName;
                    IPower powerByName = DatabaseAPI.GetPowerByName(buildFileLinesArray[index3].powerName);
                    if (!powerByName.FullName.Contains("Incarnate"))
                    {
                        PowerEntry powerEntry = new PowerEntry(-1, null, false);
                        powerEntry.Level = buildFileLinesArray[index3].powerLevel;
                        powerEntry.StatInclude = false;
                        powerEntry.VariableValue = 0;
                        powerEntry.Slots = new SlotEntry[buildFileLinesArray[index3].powerSlotsAmount];
                        if (buildFileLinesArray[index3].powerSlotsAmount > 0)
                        {
                            for (int index2 = 0; index2 < powerEntry.Slots.Length; index2++)
                            {
                                index3++;
                                powerEntry.Slots[index2] = new SlotEntry
                                {
                                    Level = 49,
                                    Enhancement = new I9Slot(),
                                    FlippedEnhancement = new I9Slot()
                                };
                                if (buildFileLinesArray[index3].enhancementName != "Empty")
                                {
                                    I9Slot i9Slot = new I9Slot();
                                    i9Slot.Enh = DatabaseAPI.GetEnhancementByUIDName(buildFileLinesArray[index3].enhancementName);
                                    str = buildFileLinesArray[index3].enhancementName;
                                    if (i9Slot.Enh == -1)
                                    {
                                        string iName = buildFileLinesArray[index3].enhancementName.Replace("Attuned", "Crafted");
                                        i9Slot.Enh = DatabaseAPI.GetEnhancementByUIDName(iName);
                                        if (i9Slot.Enh == -1)
                                        {
                                            Interaction.MsgBox("Error with: " + str, MsgBoxStyle.OkOnly, null);
                                            i9Slot.Enh = 0;
                                        }
                                    }
                                    if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.Normal || DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.SpecialO)
                                    {
                                        i9Slot.RelativeLevel = buildFileLinesArray[index3].enhancementRelativeLevel + Enums.eEnhRelative.Even;
                                        i9Slot.Grade = Enums.eEnhGrade.TrainingO;
                                    }
                                    if (DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[i9Slot.Enh].TypeID == Enums.eType.SetO)
                                    {
                                        i9Slot.IOLevel = buildFileLinesArray[index3].enhancementLevel;
                                        i9Slot.RelativeLevel = buildFileLinesArray[index3].enhancementRelativeLevel + Enums.eEnhRelative.Even;
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
                            {
                                powerEntry.NIDPower = 1521;
                            }
                            if (powerEntry.NIDPower == 2554)
                            {
                                powerEntry.NIDPower = 1523;
                            }
                            if (powerEntry.NIDPower == 2555)
                            {
                                powerEntry.NIDPower = 1522;
                            }
                            if (powerEntry.NIDPower == 2556)
                            {
                                powerEntry.NIDPower = 1524;
                            }
                            powerEntry.NIDPowerset = powerByName.PowerSetID;
                            powerEntry.IDXPower = powerByName.PowerSetIndex;
                        }
                        if (powerEntry.Slots.Length > 0)
                        {
                            powerEntry.Slots[0].Level = powerEntry.Level;
                        }
                        powerEntryList.Add(powerEntry);
                    }
                    index3++;
                }
                powerEntryList = this.sortPowerEntryList(powerEntryList);
                for (index = 0; index < powerEntryList.Count; index++)
                {
                    if (!powerEntryList[index].PowerSet.FullName.Contains("Inherent"))
                    {
                        this.PowerPicked(powerEntryList[index].NIDPowerset, powerEntryList[index].NIDPower);
                    }
                }
                List<SlotEntry> slotEntryList = new List<SlotEntry>();
                for (index = 0; index < MidsContext.Character.CurrentBuild.Powers.Count; index++)
                {
                    bool flag = false;
                    for (int index2 = 0; index2 < powerEntryList.Count; index2++)
                    {
                        if (powerEntryList[index2].Power.FullName == MidsContext.Character.CurrentBuild.Powers[index].Power.FullName)
                        {
                            if (powerEntryList[index2].Slots.Length > 0)
                            {
                                slotEntryList.Add(powerEntryList[index2].Slots[0]);
                            }
                            for (int index4 = 0; index4 < powerEntryList[index2].Slots.Length - 1; index4++)
                            {
                                slotEntryList.Add(powerEntryList[index2].Slots[index4 + 1]);
                                MidsContext.Character.CurrentBuild.Powers[index].AddSlot(49);
                            }
                            break;
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                }
                int num5 = 0;
                for (index = 0; index < MidsContext.Character.CurrentBuild.Powers.Count; index++)
                {
                    for (int index2 = 0; index2 < MidsContext.Character.CurrentBuild.Powers[index].Slots.Length; index2++)
                    {
                        MidsContext.Character.CurrentBuild.Powers[index].Slots[index2] = slotEntryList[num5++];
                    }
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
                Interaction.MsgBox("Invalid Import Data, Blame Sai!\nError: " + str, MsgBoxStyle.OkOnly, null);
            }
        }
        List<PowerEntry> sortPowerEntryList(List<PowerEntry> listPowerEntry)
        {
            listPowerEntry.Sort((PowerEntry p1, PowerEntry p2) => p1.Level.CompareTo(p2.Level));
            return listPowerEntry;
        }
        string[] BuildLineSplitter(string build)
        {
            string[] strArray = build.Split(new char[]
            {
                ' '
            });
            strArray[0] = strArray[0].Trim();
            strArray[0] = strArray[0].TrimEnd(new char[]
            {
                ':'
            });
            return strArray;
        }
        [AccessedThroughProperty("accoladeButton")]
        ImageButton _accoladeButton;
        [AccessedThroughProperty("AccoladesWindowToolStripMenuItem")]
        ToolStripMenuItem _AccoladesWindowToolStripMenuItem;
        [AccessedThroughProperty("AdvancedToolStripMenuItem1")]
        ToolStripMenuItem _AdvancedToolStripMenuItem1;
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
        [AccessedThroughProperty("CharacterToolStripMenuItem")]
        ToolStripMenuItem _CharacterToolStripMenuItem;
        [AccessedThroughProperty("dlgOpen")]
        OpenFileDialog _dlgOpen;
        [AccessedThroughProperty("dlgSave")]
        SaveFileDialog _dlgSave;
        [AccessedThroughProperty("dvAnchored")]
        DataView _dvAnchored;
        [AccessedThroughProperty("FileToolStripMenuItem")]
        ToolStripMenuItem _FileToolStripMenuItem;
        [AccessedThroughProperty("HelpToolStripMenuItem1")]
        ToolStripMenuItem _HelpToolStripMenuItem1;
        [AccessedThroughProperty("heroVillain")]
        ImageButton _heroVillain;
        [AccessedThroughProperty("I9Picker")]
        I9Picker _I9Picker;
        [AccessedThroughProperty("I9Popup")]
        ctlPopUp _I9Popup;
        [AccessedThroughProperty("ibAccolade")]
        ImageButton _ibAccolade;
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
        [AccessedThroughProperty("ibVetPools")]
        ImageButton _ibVetPools;
        [AccessedThroughProperty("ImportExportToolStripMenuItem")]
        ToolStripMenuItem _ImportExportToolStripMenuItem;
        [AccessedThroughProperty("incarnateButton")]
        ImageButton _incarnateButton;
        [AccessedThroughProperty("IncarnateWindowToolStripMenuItem")]
        ToolStripMenuItem _IncarnateWindowToolStripMenuItem;
        [AccessedThroughProperty("InGameRespecHelperToolStripMenuItem")]
        ToolStripMenuItem _InGameRespecHelperToolStripMenuItem;
        [AccessedThroughProperty("lblAT")]
        GFXLabel _lblAT;
        [AccessedThroughProperty("lblATLocked")]
        Label _lblATLocked;
        [AccessedThroughProperty("lblEpic")]
        Label _lblEpic;
        [AccessedThroughProperty("lblHero")]
        GFXLabel _lblHero;
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
        [AccessedThroughProperty("lblName")]
        GFXLabel _lblName;
        [AccessedThroughProperty("lblOrigin")]
        GFXLabel _lblOrigin;
        [AccessedThroughProperty("lblPool1")]
        Label _lblPool1;
        [AccessedThroughProperty("lblPool2")]
        Label _lblPool2;
        [AccessedThroughProperty("lblPool3")]
        Label _lblPool3;
        [AccessedThroughProperty("lblPool4")]
        Label _lblPool4;
        [AccessedThroughProperty("lblPrimary")]
        Label _lblPrimary;
        [AccessedThroughProperty("lblSecondary")]
        Label _lblSecondary;
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
        [AccessedThroughProperty("MenuBar")]
        MenuStrip _MenuBar;
        [AccessedThroughProperty("OptionsToolStripMenuItem")]
        ToolStripMenuItem _OptionsToolStripMenuItem;
        [AccessedThroughProperty("pbDynMode")]
        PictureBox _pbDynMode;
        [AccessedThroughProperty("pnlGFX")]
        PictureBox _pnlGFX;
        [AccessedThroughProperty("pnlGFXFlow")]
        FlowLayoutPanel _pnlGFXFlow;
        [AccessedThroughProperty("SetAllIOsToDefault35ToolStripMenuItem")]
        ToolStripMenuItem _SetAllIOsToDefault35ToolStripMenuItem;
        [AccessedThroughProperty("SlotsToolStripMenuItem")]
        ToolStripMenuItem _SlotsToolStripMenuItem;
        [AccessedThroughProperty("TemporaryPowersWindowToolStripMenuItem")]
        ToolStripMenuItem _TemporaryPowersWindowToolStripMenuItem;
        [AccessedThroughProperty("tempPowersButton")]
        ImageButton _tempPowersButton;
        [AccessedThroughProperty("tlsDPA")]
        ToolStripMenuItem _tlsDPA;
        [AccessedThroughProperty("tmrGfx")]
        System.Windows.Forms.Timer _tmrGfx;
        [AccessedThroughProperty("ToolStripMenuItem1")]
        ToolStripMenuItem _ToolStripMenuItem1;
        [AccessedThroughProperty("ToolStripMenuItem2")]
        ToolStripMenuItem _ToolStripMenuItem2;
        [AccessedThroughProperty("ToolStripMenuItem4")]
        ToolStripSeparator _ToolStripMenuItem4;
        [AccessedThroughProperty("ToolStripSeparator1")]
        ToolStripSeparator _ToolStripSeparator1;
        [AccessedThroughProperty("ToolStripSeparator10")]
        ToolStripSeparator _ToolStripSeparator10;
        [AccessedThroughProperty("ToolStripSeparator11")]
        ToolStripSeparator _ToolStripSeparator11;
        [AccessedThroughProperty("ToolStripSeparator12")]
        ToolStripSeparator _ToolStripSeparator12;
        [AccessedThroughProperty("ToolStripSeparator13")]
        ToolStripSeparator _ToolStripSeparator13;
        [AccessedThroughProperty("ToolStripSeparator14")]
        ToolStripSeparator _ToolStripSeparator14;
        [AccessedThroughProperty("ToolStripSeparator15")]
        ToolStripSeparator _ToolStripSeparator15;
        [AccessedThroughProperty("ToolStripSeparator16")]
        ToolStripSeparator _ToolStripSeparator16;
        [AccessedThroughProperty("ToolStripSeparator17")]
        ToolStripSeparator _ToolStripSeparator17;
        [AccessedThroughProperty("ToolStripSeparator18")]
        ToolStripSeparator _ToolStripSeparator18;
        [AccessedThroughProperty("ToolStripSeparator19")]
        ToolStripSeparator _ToolStripSeparator19;
        [AccessedThroughProperty("ToolStripSeparator2")]
        ToolStripSeparator _ToolStripSeparator2;
        [AccessedThroughProperty("ToolStripSeparator20")]
        ToolStripSeparator _ToolStripSeparator20;
        [AccessedThroughProperty("ToolStripSeparator21")]
        ToolStripSeparator _ToolStripSeparator21;
        [AccessedThroughProperty("ToolStripSeparator22")]
        ToolStripSeparator _ToolStripSeparator22;
        [AccessedThroughProperty("ToolStripSeparator23")]
        ToolStripSeparator _ToolStripSeparator23;
        [AccessedThroughProperty("ToolStripSeparator24")]
        ToolStripSeparator _ToolStripSeparator24;
        [AccessedThroughProperty("ToolStripSeparator4")]
        ToolStripSeparator _ToolStripSeparator4;
        [AccessedThroughProperty("ToolStripSeparator5")]
        ToolStripSeparator _ToolStripSeparator5;
        [AccessedThroughProperty("ToolStripSeparator7")]
        ToolStripSeparator _ToolStripSeparator7;
        [AccessedThroughProperty("ToolStripSeparator8")]
        ToolStripSeparator _ToolStripSeparator8;
        [AccessedThroughProperty("ToolStripSeparator9")]
        ToolStripSeparator _ToolStripSeparator9;
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
        [AccessedThroughProperty("tTip")]
        ToolTip _tTip;
        [AccessedThroughProperty("txtName")]
        TextBox _txtName;
        [AccessedThroughProperty("ViewToolStripMenuItem")]
        ToolStripMenuItem _ViewToolStripMenuItem;
        [AccessedThroughProperty("WindowToolStripMenuItem")]
        ToolStripMenuItem _WindowToolStripMenuItem;
        protected Rectangle ActivePopupBounds;
        public bool DataViewLocked;
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
        public clsDrawX Drawing;
        public int dvLastEnh;
        public bool dvLastNoLev;
        public int dvLastPower;
        public int EnhancingPower;
        public int EnhancingSlot;
        public bool EnhPickerActive;
        protected frmAccolade fAccolade;
        protected frmData fData;
        protected frmCompare fGraphCompare;
        protected frmStats fGraphStats;
        public bool FileModified;
        protected frmIncarnate fIncarnate;
        protected bool FlipActive;
        protected PowerEntry FlipGP;
        protected int FlipInterval;
        protected int FlipPowerID;
        protected int[] FlipSlotState;
        protected int FlipStepDelay;
        protected int FlipSteps;
        public frmFloatingStats FloatingDataForm;
        protected frmMiniList fMini;
        protected frmRecipeViewer fRecipe;
        protected frmDPSCalc fDPSCalc;
        protected frmSetFind fSetFinder;
        protected frmSetViewer fSets;
        protected frmAccolade fTemp;
        protected frmTotals fTotals;
        bool HasSentBack;
        bool HasSentForwards;
        public bool LastClickPlacedSlot;
        public int LastEnhIndex;
        public I9Slot LastEnhPlaced;
        public string LastFileName;
        public int LastIndex;
        protected FormWindowState LastState;
        public DataView myDataView;
        bool NoResizeEvent;
        public bool NoUpdate;
        Rectangle oldDragRect;
        public int PickerHID;
        protected bool PopUpVisible;
        bool top_fData;
        bool top_fGraphCompare;
        bool top_fGraphStats;
        bool top_fRecipe;
        bool top_fSetFinder;
        bool top_fSets;
        bool top_fTotals;
        int xCursorOffset;
        int yCursorOffset;
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
