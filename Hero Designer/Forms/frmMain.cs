
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Base;
using Base.Data_Classes;
using Base.Display;
using Base.IO_Classes;
using Base.Master_Classes;
using midsControls;

namespace Hero_Designer
{
    public partial class frmMain : Form
    {
        #region "fields"

        Rectangle ActivePopupBounds;
        bool DataViewLocked;
        readonly short[] ddsa;
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
        readonly bool EnhPickerActive;
        frmAccolade fAccolade;
        frmData fData;
        frmCompare fGraphCompare;
        frmStats fGraphStats;
        bool FileModified { get; set; }
        frmIncarnate fIncarnate;
        bool FlipActive;
        PowerEntry FlipGP;
        readonly int FlipInterval;
        int FlipPowerID;
        int[] FlipSlotState;
        readonly int FlipStepDelay;
        readonly int FlipSteps;
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

        #endregion

        public int GetPrimaryBottom() => cbPrimary.Top + cbPrimary.Height;

        internal OpenFileDialog DlgOpen => dlgOpen;

        internal SaveFileDialog DlgSave => dlgSave;

        ComboBoxT<string> GetCbOrigin() => new ComboBoxT<string>(this.cbOrigin);

        // store the instance for reuse, as these things are called per draw/redraw
        Lazy<ComboBoxT<Archetype>> CbtAT => new Lazy<ComboBoxT<Archetype>>(() => new ComboBoxT<Archetype>(this.cbAT));
        Lazy<ComboBoxT<string>> CbtPrimary => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbPrimary));
        Lazy<ComboBoxT<string>> CbtSecondary => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbSecondary));
        Lazy<ComboBoxT<string>> CbtAncillary => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbAncillary));

        Lazy<ComboBoxT<string>> CbtPool0 => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbPool0));
        Lazy<ComboBoxT<string>> CbtPool1 => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbPool1));
        Lazy<ComboBoxT<string>> CbtPool2 => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbPool2));
        Lazy<ComboBoxT<string>> CbtPool3 => new Lazy<ComboBoxT<string>>(() => new ComboBoxT<string>(this.cbPool3));

        internal clsDrawX Drawing => this.drawing;

        public frmMain()
        {
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                ConfigData.Initialize(My.MyApplication.GetSerializer());
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
                this.LastFileName = string.Empty;
                this.FileModified = false;
                this.LastIndex = -1;
                this.LastEnhIndex = -1;
                this.dvLastPower = -1;
                this.dvLastEnh = -1;
                this.dvLastNoLev = true;
                this.ActivePopupBounds = new Rectangle(0, 0, 1, 1);
                this.LastState = FormWindowState.Normal;
                this.FlipSteps = 5;
                this.FlipInterval = 10;
                this.FlipStepDelay = 3;
                this.FlipPowerID = -1;
                this.FlipSlotState = Array.Empty<int>();
                this.dragStartPower = -1;
                this.dragStartSlot = -1;
                this.ddsa = new short[20];
                this.DoneDblClick = false;
            }
            this.InitializeComponent();

            //disable menus that are no longer hooked up, but probably should be hooked back up
            this.tsHelp.Visible = false;
            this.tsHelp.Enabled = false;
            this.tsPatchNotes.Visible = false;
            this.tsPatchNotes.Enabled = false;
            this.tsDonate.Visible = false;
            this.tsDonate.Enabled = false;

            this.tmrGfx.Tick += new System.EventHandler(tmrGfx_Tick);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.dvAnchored = new DataView();
                this.Controls.Add(this.dvAnchored);
                this.dvAnchored.BackColor = System.Drawing.Color.Black;
                this.dvAnchored.DrawVillain = false;
                this.dvAnchored.Floating = false;
                this.dvAnchored.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

                this.dvAnchored.Location = new System.Drawing.Point(16, 391);
                this.dvAnchored.Name = "dvAnchored";

                this.dvAnchored.Size = new System.Drawing.Size(300, 347);
                this.dvAnchored.TabIndex = 69;
                this.dvAnchored.VisibleSize = Enums.eVisibleSize.Full;
                this.dvAnchored.MouseWheel += new System.Windows.Forms.MouseEventHandler(frmMain_MouseWheel);
                this.dvAnchored.SizeChange += new Hero_Designer.DataView.SizeChangeEventHandler(dvAnchored_SizeChange);
                this.dvAnchored.FloatChange += new Hero_Designer.DataView.FloatChangeEventHandler(dvAnchored_Float);
                this.dvAnchored.Unlock_Click += new Hero_Designer.DataView.Unlock_ClickEventHandler(dvAnchored_Unlock);
                this.dvAnchored.SlotUpdate += new Hero_Designer.DataView.SlotUpdateEventHandler(DataView_SlotUpdate);
                this.dvAnchored.SlotFlip += new Hero_Designer.DataView.SlotFlipEventHandler(DataView_SlotFlip);
                this.dvAnchored.Moved += new Hero_Designer.DataView.MovedEventHandler(dvAnchored_Move);
                this.dvAnchored.TabChanged += new Hero_Designer.DataView.TabChangedEventHandler(dvAnchored_TabChanged);
                var componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
                var icon = (Icon)componentResourceManager.GetObject("$this.Icon");
                this.Icon = icon;
                this.Name = nameof(frmMain);
            }
        }

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
                clsXMLUpdate.eCheckResponse? chkResult = null;
                string chkResultFailMsg = null;
                if (!this.IsInDesignMode() && MidsContext.Config.CheckForUpdates)
                {
                    clsXMLUpdate clsXmlUpdate = new clsXMLUpdate(); // "https://www.dropbox.com/sh/amsfzb91s88dvzh/AAB6AkjTgHto4neEmkWwLWQEa?dl=0");
                    (chkResult, chkResultFailMsg) = clsXmlUpdate.UpdateCheck();
                }
                if (!this.IsInDesignMode() && MidsContext.Config.FreshInstall)
                {
                    MidsContext.Config.CheckForUpdates = false;
                    //MessageBox.Show(("Welcome to Mid's Reborn Hero Designer "
                    //+ MidsContext.AppVersion 
                    //+ "! Please check the Readme/Help for quick instructions.\r\n\r\nMids' Hero Designer is able to check for and download updates automatically when it starts.\r\nIt's recommended that you turn on automatic updating. Do you want to?\r\n\r\n(If you don't, you can manually check from the 'Updates' tab in the options.)"), MessageBoxButtons.YesNo | MessageBoxIcon.Question, "Welcome!") == DialogResult.Yes;
                    MidsContext.Config.DefaultSaveFolderOverride = null;
                    MidsContext.Config.CreateDefaultSaveFolder();
                    MidsContext.Config.FreshInstall = false;
                }
                string args = string.Join(" ", Environment.GetCommandLineArgs().Skip(1));
                if (args.IndexOf("RECOVERY", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    MessageBox.Show("As recovery mode has been invoked, you will be redirected to the download site for the most recent full install package.", "Recovery Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsXMLUpdate.GoToMidsReborn();
                    Application.Exit();
                    return;
                }
                if (args.IndexOf("MASTERMODE=YES", StringComparison.OrdinalIgnoreCase) > -1)
                    MidsContext.Config.MasterMode = true;
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
                Size size1;
                if (Screen.PrimaryScreen.WorkingArea.Width > MidsContext.Config.LastSize.Width & MidsContext.Config.LastSize.Width >= this.MinimumSize.Width)
                {
                    int hasMaxSize = this.MaximumSize.Width > 0 ? 1 : 0;
                    int hasValidLastSize = this.MaximumSize.Width - MidsContext.Config.LastSize.Width < 32 ? 1 : 0;
                    int hasValidBoth = hasMaxSize & hasValidLastSize;
                    int needsWidthReduction = Screen.PrimaryScreen.WorkingArea.Width > this.MaximumSize.Width ? 1 : 0;
                    if ((hasValidBoth & needsWidthReduction) != 0)
                    {
                        width1 = this.MaximumSize.Width;
                    }
                    else
                        width1 = MidsContext.Config.LastSize.Width;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width <= MidsContext.Config.LastSize.Width)
                {
                    width1 = Screen.PrimaryScreen.WorkingArea.Width - (this.Size.Width - this.ClientSize.Width);
                }
                if (Screen.PrimaryScreen.WorkingArea.Height > MidsContext.Config.LastSize.Height && MidsContext.Config.LastSize.Height >= this.MinimumSize.Height)
                    height1 = MidsContext.Config.LastSize.Height;
                else if (Screen.PrimaryScreen.WorkingArea.Height <= MidsContext.Config.LastSize.Height)
                {
                    height1 = Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height - this.ClientSize.Height);
                }
                this.Size = new System.Drawing.Size(width1, height1);
                this.tsView2Col.Checked = MidsContext.Config.Columns == 2;
                this.tsView3Col.Checked = MidsContext.Config.Columns == 3;
                this.tsView4Col.Checked = MidsContext.Config.Columns == 4;
                this.tsViewIOLevels.Checked = MidsContext.Config.I9.DisplayIOLevels;
                this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
                this.tsIODefault.Text = "Default (" + (MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
                this.SetDamageMenuCheckMarks();
                this.ReArrange(true);
                this.GetBestDamageValues();
                this.dvAnchored.SetFontData();
                this.dlgSave.InitialDirectory = MidsContext.Config.GetSaveFolder();
                this.dlgOpen.InitialDirectory = MidsContext.Config.GetSaveFolder();
                this.NoUpdate = false;
                this.tsViewSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
                this.ibSlotLevels.Checked = MidsContext.Config.ShowSlotLevels;
                this.tsViewRelative.Checked = MidsContext.Config.ShowEnhRel;
                this.ibPopup.Checked = MidsContext.Config.ShowPopup;
                this.ibRecipe.Checked = MidsContext.Config.PopupRecipes;
                string rtfRelPath = Path.Combine(Files.FPathAppData, Files.PatchRtf);
                if (File.Exists(rtfRelPath))
                {
                    new frmReadme(rtfRelPath)
                    {
                        BtnClose = {
                              IA = this.drawing.pImageAttributes,
                              ImageOff = this.drawing.bxPower[2].Bitmap,
                              ImageOn = this.drawing.bxPower[3].Bitmap
                        }
                    }.ShowDialog();
                    var patchNotesTgt = Path.Combine(Files.FPathAppData, "patchnotes.rtf");
                    if (File.Exists(patchNotesTgt))
                        File.Delete(patchNotesTgt);
                    File.Move(Path.Combine(Files.FPathAppData, Files.PatchRtf), patchNotesTgt);
                }
                var loadedFromArgs = false;
                if (!string.IsNullOrEmpty(args))
                {
                    string str3 = args.Replace("\"", string.Empty);
                    if (File.Exists(str3.Trim()) && !this.DoOpen(str3.Trim()))
                    {
                        loadedFromArgs = true;
                        this.PowerModified(markModified: false);

                    }
                }
                if (!loadedFromArgs && MidsContext.Config.LoadLastFileOnStart && !this.DoOpen(MidsContext.Config.LastFileName))
                    this.PowerModified(markModified: true);
                if (MidsContext.Config.MasterMode)
                {
                    this.tsAdvFreshInstall.Visible = true;
                    this.tsAdvResetTips.Visible = true;
                }
                this.Show();
                iFrm.Hide();
                iFrm.Close();
                iFrm = null;
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
                if (!this.IsInDesignMode())
                {
                    if (chkResult == clsXMLUpdate.eCheckResponse.FailedWithMessage && !string.IsNullOrEmpty(chkResultFailMsg))
                    {
                        if (MessageBox.Show(chkResultFailMsg + "\r\nCheck again at next startup?", "Update check failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                        {
                            MidsContext.Config.CheckForUpdates = false;
                        }
                    }
                    else if (chkResult == clsXMLUpdate.eCheckResponse.Updates)
                    {
                        MessageBox.Show("Update available");
                    }
                    var exePath = typeof(frmMain).Assembly.Location;
                    if (!MidsContext.Config.DoNotUpdateFileAssociation && !FileAssocation.GetIsAssociated(exePath))
                    {
                        if (MessageBox.Show("Associate .mhd and .mxd files with this application?", "File Assocation Setup", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var associationResult = FileAssocation.AddToOpenWithLists(exePath);
                            if (associationResult == FileAssocation.AddToOpenResult.Unauthorized)
                            {
                                if (MessageBox.Show("Unable to associate application with build files, turn off future attempts?", "Assocation Failure", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    MidsContext.Config.DoNotUpdateFileAssociation = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred when loading the main form. Error: " + ex.Message, "OMIGODHAX");
                throw;
            }
        }

        I9Picker I9Picker
        {
            get
            {
                if (this.i9Picker.Height <= 235)
                    this.i9Picker.Height = 315;
                return this.i9Picker;
            }
            set
            {
                this.i9Picker = value;
            }
        }

        internal void ChildRequestedRedraw()
                => this.DoRedraw();

        // this just opens a window right? why set modified?
        void accoladeButton_ButtonClicked() => this.PowerModified(markModified: false);

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
                this.fAccolade = new frmAccolade(this, iPowers) { Text = "Accolades" };
            }
            if (!this.fAccolade.Visible)
                this.fAccolade.Show(this);
        }

        void AccoladesWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.accoladeButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
            this.accoladeButton.Checked = true;
        }

        static int ArchetypeIndirectToIndex(int iIndirect)
        {
            int num1 = -1;
            for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
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

        void AssemblePowerList(ListLabelV2 llPower, IPowerset Powerset)
        {
            if (Powerset == null || Powerset.Powers?.Length < 1)
            {
                llPower.SuspendRedraw = true;
                llPower.ClearItems();
                llPower.SuspendRedraw = false;
            }
            else
            {
                llPower.SuspendRedraw = true;
                llPower.ClearItems();
                string message;
                if (Powerset.nIDTrunkSet > -1)
                {
                    IPowerset powerset = DatabaseAPI.Database.Powersets[Powerset.nIDTrunkSet];
                    var iItem1 = new ListLabelV2.ListLabelItemV2(powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nIDTrunkSet, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
                    llPower.AddItem(iItem1);
                    for (int iIDXPower = 0; iIDXPower <= powerset.Powers.Length - 1; ++iIDXPower)
                    {
                        if (powerset.Powers[iIDXPower].Level > 0)
                        {
                            message = "";
                            var iItem2 = new ListLabelV2.ListLabelItemV2(powerset.Powers[iIDXPower].DisplayName,
                                MainModule.MidsController.Toon.PowerState(powerset.Powers[iIDXPower].PowerIndex,
                                    ref message), Powerset.nIDTrunkSet, iIDXPower, powerset.Powers[iIDXPower].PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
                            {
                                Bold = MidsContext.Config.RtFont.PairedBold
                            };
                            if (iItem2.ItemState == ListLabelV2.LLItemState.Invalid)
                                iItem2.Italic = true;
                            llPower.AddItem(iItem2);
                        }
                    }
                    var iItem = new ListLabelV2.ListLabelItemV2(Powerset.DisplayName, ListLabelV2.LLItemState.Heading, Powerset.nID, -1, -1, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Center);
                    llPower.AddItem(iItem);
                }
                for (int iIDXPower = 0; iIDXPower <= Powerset.Powers.Length - 1; ++iIDXPower)
                {
                    if (Powerset.Powers[iIDXPower].Level > 0)
                    {
                        message = "";
                        var targetPs = MainModule.MidsController.Toon.PowerState(Powerset.Powers[iIDXPower].PowerIndex, ref message);
                        var power = Powerset.Powers[iIDXPower];
                        var iItem = new ListLabelV2.ListLabelItemV2(
                            Powerset.Powers[iIDXPower].DisplayName,
                            targetPs,
                            Powerset.nID,
                            iIDXPower,
                            power.PowerIndex, "", ListLabelV2.LLFontFlags.Bold, ListLabelV2.LLTextAlign.Left)
                        {
                            Bold = MidsContext.Config.RtFont.PairedBold
                        };
                        if (iItem.ItemState == ListLabelV2.LLItemState.Invalid)
                            iItem.Italic = true;
                        llPower.AddItem(iItem);
                    }
                }
                llPower.SuspendRedraw = false;
            }
        }

        void AutoArrangeAllSlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PowerEntry[] powerEntryArray = DeepCopyPowerList();
            this.RearrangeAllSlotsInBuild(powerEntryArray, true);
            this.ShallowCopyPowerList(powerEntryArray);
            // unless they set more than just slotting order, don't force the save flag
            this.PowerModified(markModified: false);
            this.DoRedraw();
        }

        void cbAncillary_DrawItem(object sender, DrawItemEventArgs e)
            => cbDrawItem(CbtAncillary.Value, Enums.ePowerSetType.Ancillary, e);

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
                var cbAT = new ComboBoxT<Archetype>(this.cbAT);
                int index = ArchetypeIndirectToIndex(e.Index);
                RectangleF destRect = new RectangleF(e.Bounds.X + 1, e.Bounds.Y, 16f, 16f);
                RectangleF srcRect = new RectangleF(index * 16, 0.0f, 16f, 16f);
                e.Graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center
                };
                RectangleF layoutRectangle = new RectangleF(e.Bounds.X + destRect.X + destRect.Width, e.Bounds.Y, e.Bounds.Width - (destRect.X + destRect.Width), e.Bounds.Height);
                e.Graphics.DrawString(cbAT[e.Index].DisplayName, e.Font, solidBrush, layoutRectangle, format);
            }
            e.DrawFocusRectangle();
        }


        void cbAT_MouseLeave(object sender, EventArgs e) => this.HidePopup();

        void cbAT_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || this.cbAT.SelectedIndex < 0)
                return;
            this.ShowPopup(-1, this.CbtAT.Value.SelectedItem.Idx, this.cbAT.Bounds, "");
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
          ComboBoxT<string> target,
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
                local1 = new RectangleF(e.Bounds.X + 1, e.Bounds.Y, 16f, 16f);
                RectangleF srcRect = new RectangleF((float)(nId * 16), 0.0f, 16f, 16f);
                if ((e.State & DrawItemState.ComboBoxEdit) > DrawItemState.None)
                {
                    if (e.Graphics.MeasureString(target[e.Index], e.Font).Width <= e.Bounds.Width - 10)
                        e.Graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
                    else
                        destRect.Width = 0.0f;
                }
                else
                    e.Graphics.DrawImage(I9Gfx.Powersets.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center
                };
                var layout = new RectangleF(e.Bounds.X + destRect.X + destRect.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                e.Graphics.DrawString(target[e.Index], e.Font, solidBrush, layout, format);
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
                var cmbOrigin = GetCbOrigin();
                RectangleF destRect = new RectangleF((float)(e.Bounds.X + 1), (float)e.Bounds.Y, 16f, 16f);
                RectangleF srcRect = new RectangleF((float)(DatabaseAPI.GetOriginIDByName(cmbOrigin[e.Index]) * 16), 0.0f, 16f, 16f);
                e.Graphics.DrawImage((Image)I9Gfx.Origins.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
                StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
                {
                    LineAlignment = StringAlignment.Center
                };
                RectangleF layoutRectangle = new RectangleF((float)e.Bounds.X + destRect.X + destRect.Width, (float)e.Bounds.Y, (float)e.Bounds.Width - (destRect.X + destRect.Width), (float)e.Bounds.Height);
                e.Graphics.DrawString(cmbOrigin[e.Index], e.Font, (Brush)solidBrush, layoutRectangle, format);
            }
            e.DrawFocusRectangle();
        }

        void cbOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            MidsContext.Character.Origin = this.cbOrigin.SelectedIndex;
            I9Gfx.SetOrigin(this.cbOrigin.SelectedItem.ToStringOrNull());
            if (this.drawing != null)
                this.DoRedraw();
            this.DisplayName();
        }

        void cbPool0_DrawItem(object sender, DrawItemEventArgs e)
            => cbDrawItem(this.CbtPool0.Value, Enums.ePowerSetType.Pool, e);

        void cbPool0_MouseLeave(object sender, EventArgs e) => this.HidePopup();

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
            => cbDrawItem(this.CbtPool1.Value, Enums.ePowerSetType.Pool, e);

        void cbPool1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[4] == null)
                return;
            this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.");
        }

        void cbPool1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.NoUpdate)
                return;
            this.ChangeSets();
            this.UpdatePowerLists();
        }

        void cbPool2_DrawItem(object sender, DrawItemEventArgs e)
            => cbDrawItem(this.CbtPool2.Value, Enums.ePowerSetType.Pool, e);

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
            => cbDrawItem(this.CbtPool3.Value, Enums.ePowerSetType.Pool, e);

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
            => cbDrawItem(CbtPrimary.Value, Enums.ePowerSetType.Primary, e);

        void cbPrimary_MouseLeave(object sender, EventArgs e) => this.HidePopup();

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
            => cbDrawItem(CbtSecondary.Value, Enums.ePowerSetType.Secondary, e);

        void cbSecondary_MouseLeave(object sender, EventArgs e) => this.HidePopup();

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
            Forms.MainUILogic.ChangeSets(MainModule.MidsController.Toon, MidsContext.Character,
                primaryIndex: this.cbPrimary.SelectedIndex,
                secondaryIndex: this.cbSecondary.SelectedIndex,
                pool0Index: this.cbPool0.SelectedIndex,
                pool1Index: this.cbPool1.SelectedIndex,
                pool2Index: this.cbPool2.SelectedIndex,
                pool3Index: this.cbPool3.SelectedIndex,
                ancillaryIndex: this.cbAncillary.SelectedIndex,
                getPowerSets: DatabaseAPI.GetPowersetIndexes,
                enableSecondary: () => this.cbSecondary.Enabled = true
                );
            this.DataViewLocked = false;
            this.ActiveControl = this.llPrimary;
            this.PowerModified(markModified: true);
            this.FloatUpdate(true);
            this.GetBestDamageValues();
        }

        void clearPower(PowerEntry[] tp, int pwrIdx)
        {
            tp[pwrIdx].Slots = Array.Empty<SlotEntry>();
            tp[pwrIdx].SubPowers = Array.Empty<PowerSubEntry>();
            tp[pwrIdx].IDXPower = -1;
            tp[pwrIdx].NIDPower = -1;
            tp[pwrIdx].NIDPowerset = -1;
            tp[pwrIdx].Tag = false;
            tp[pwrIdx].StatInclude = false;
        }

        internal bool CloseCommand()
        {
            if (MainModule.MidsController.Toon == null)
            {
                return false;
            }
            else
            {
                if (MainModule.MidsController.Toon.Locked & this.FileModified)
                {
                    this.FloatTop(false);
                    var msgBoxResult = MessageBox.Show("Do you wish to save your hero/villain data before quitting?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    this.FloatTop(true);
                    int num;
                    switch (msgBoxResult)
                    {
                        case DialogResult.Cancel:
                            return true;
                        case DialogResult.Yes:
                            num = this.doSave() ? 1 : 0;
                            break;
                        default:
                            num = 1;
                            break;
                    }
                    if (num == 0)
                        return true;
                }
                return false;
            }
        }

        bool ComboCheckAT(Archetype[] playableClasses)
        {
            var cbtAT = this.CbtAT.Value;
            if (cbtAT.Count != playableClasses.Length)
            {
                return true;
            }
            else
            {
                int num = playableClasses.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (cbtAT[index].Idx != playableClasses[index].Idx)
                        return true;
                }
                return false;
            }
        }

        bool ComboCheckOrigin()
        {
            var cbtOrigin = this.GetCbOrigin();
            if (cbtOrigin.Count != MidsContext.Character.Archetype.Origin.Length)
            {
                return true;
            }
            else
            {
                if (cbtOrigin.Count <= 1)
                {
                    int num = MidsContext.Character.Archetype.Origin.Length - 1;
                    for (int index = 0; index <= num; ++index)
                    {
                        if (cbtOrigin[index] != MidsContext.Character.Archetype.Origin[index])
                            return true;
                    }
                }
                return false;
            }
        }

        static void ComboCheckPool(ComboBoxT<string> iCB, Enums.ePowerSetType iSetType)
        {
            string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
            bool needsComboUpdate = iCB.Items.Count != powersetNames.Length || !iCB.Items.SequenceEqual(powersetNames);
            if (needsComboUpdate)
            {
                iCB.BeginUpdate();
                iCB.Clear();
                iCB.AddRange(powersetNames);
                iCB.EndUpdate();
            }
        }

        static void ComboCheckPS(
          ComboBoxT<string> iCB,
          Enums.PowersetType iSetID,
          Enums.ePowerSetType iSetType)
        {
            string[] powersetNames = DatabaseAPI.GetPowersetNames(MidsContext.Character.Archetype.Idx, iSetType);
            var needsComboUpdate = iCB.Items.Count != powersetNames.Length || !iCB.Items.SequenceEqual(powersetNames);
            if (needsComboUpdate)
            {
                iCB.BeginUpdate();
                iCB.Clear();
                iCB.AddRange(powersetNames);
                iCB.EndUpdate();
            }
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, iSetType);
            iCB.SelectedIndex = DatabaseAPI.ToDisplayIndex(MidsContext.Character.Powersets[(int)iSetID], powersetIndexes);
        }

        void command_ForumImport()
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                var msgBoxResult = MessageBox.Show("Current hero/villain data will be discarded, are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                this.FloatTop(true);
                if (msgBoxResult == DialogResult.No)
                    return;
            }
            this.FloatTop(false);
            this.FileModified = false;
            bool loaded = false;
            if (MessageBox.Show("Copy the build data on the forum to the clipboard. When that's done, click on OK.", "Standing By", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            string str = Clipboard.GetDataObject().GetData("System.String", true).ToString();
            this.NewToon(true, false);
            try
            {
                if (str.Length < 1)
                {
                    int num = (int)MessageBox.Show("No data. Please check that you copied the build data from the forum correctly and that it's a valid format.", "Forum Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (str.Contains("MxDz") || str.Contains("MxDu"))
                    {
                        Stream mStream = new MemoryStream(new ASCIIEncoding().GetBytes(str));
                        loaded = MainModule.MidsController.Toon.Load("", ref mStream);
                    }
                    else if (str.Contains("Character Profile:") || str.Contains("build.txt"))
                    {
                        this.GameImport(str);
                        loaded = true;
                    }
                    if (!loaded)
                        loaded = MainModule.MidsController.Toon.StringToInternalData(str);
                    if (loaded)
                    {
                        this.drawing.Highlight = -1;
                        this.NewDraw(false);
                        this.myDataView.Clear();
                        this.PowerModified(markModified: true);
                        this.UpdateControls(true);
                        this.SetFormHeight(false);
                    }
                    else
                    {
                        this.NewToon(true, false);
                        this.myDataView.Clear();
                        this.PowerModified(markModified: true);
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
                this.FloatTop(true);
            }
        }

        void command_New()
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                DialogResult msgBoxResult = MessageBox.Show("Current hero/villain data will be discarded, are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                this.FloatTop(true);
                if (msgBoxResult == DialogResult.No)
                    return;
            }
            this.DataViewLocked = false;
            this.NewToon(false, false);
            MidsContext.Config.LastFileName = "";
            this.LastFileName = "";
            this.PowerModified(markModified: false);
            this.FileModified = false;
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
            => MidsContext.Character.CurrentBuild.Powers.Select(x => (PowerEntry)x.Clone()).ToArray();

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
            var ch = MidsContext.Character;
            int level = ch.Level;
            if (!(ch.CurrentBuild.TotalSlotsAvailable - ch.CurrentBuild.SlotsPlaced < 1 & ch.CurrentBuild.LastPower + 1 - ch.CurrentBuild.PowersPlaced < 1) && ch.Level > 0)
                str1 = " (Placing " + (ch.Level + 1) + ")";
            this.SetTitleBar(MainModule.MidsController.Toon.IsHero());
            string str3 = ch.Name + ": ";
            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp & str1 != "")
                str3 = str3 + "Level " + level + str1 + " ";
            string str4 = str3 + ch.Archetype.Origin[ch.Origin] + " " + ch.Archetype.DisplayName;
            if (MainModule.MidsController.Toon.Locked)
                str4 = str4 + " (" + ch.Powersets[0].DisplayName + " / " + ch.Powersets[1].DisplayName + ")" + str2;
            if (MidsContext.Config.ExempLow < MidsContext.Config.ExempHigh)
                str4 = str4 + " - Exemped from " + MidsContext.Config.ExempHigh + " to " + MidsContext.Config.ExempLow;
            this.lblHero.Text = str4;
            if (!(this.txtName.Text != ch.Name))
                return;
            this.txtName.Text = ch.Name;
        }

        void doFlipStep()
        {
            if (!this.FlipActive)
                return;
            Point point1 = new System.Drawing.Point();
            Build currentBuild = MidsContext.Character.CurrentBuild;
            PowerEntry power = currentBuild.Powers[this.FlipPowerID];
            Point point2 = this.drawing.DrawPowerSlot(ref power, false);
            int index = -1;
            int Enh1 = -1;
            int Enh2 = -1;
            I9Slot i9Slot1 = null;
            I9Slot i9Slot2 = null;
            ImageAttributes recolourIa = clsDrawX.GetRecolourIa(MainModule.MidsController.Toon.IsHero());
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            int num1 = this.FlipSlotState.Length - 1;
            Rectangle rectangle1;
            for (int i = 0; i <= num1; ++i)
            {
                point1.X = (int)Math.Round(point2.X + (this.drawing.SzPower.Width - this.drawing.szSlot.Width * 6) / 2.0);
                point1.Y = point2.Y + 18;
                ++this.FlipSlotState[i];
                float num2 = 1f;
                var powerEntry = MidsContext.Character.CurrentBuild.Powers[this.FlipPowerID];
                var slot = powerEntry.Slots[i];
                if (this.FlipSlotState[i] < 0)
                {
                    index = slot.FlippedEnhancement.Enh;
                    Enh1 = index;
                    Enh2 = slot.Enhancement.Enh;
                    i9Slot1 = slot.FlippedEnhancement;
                    i9Slot2 = slot.Enhancement;
                }
                else if (this.FlipSlotState[i] > this.FlipSteps)
                {
                    index = slot.Enhancement.Enh;
                    Enh1 = index;
                    Enh2 = slot.FlippedEnhancement.Enh;
                    i9Slot1 = slot.Enhancement;
                    i9Slot2 = slot.FlippedEnhancement;
                }
                if (this.FlipSlotState[i] >= 0 && this.FlipSlotState[i] <= this.FlipSteps)
                {
                    float num3 = this.FlipSlotState[i] / (this.FlipSteps / 2f);
                    if (num3 > 1.0)
                    {
                        num2 = (float)(-1.0 * (1.0 - num3));
                        index = slot.Enhancement.Enh;
                        Enh1 = index;
                        Enh2 = slot.FlippedEnhancement.Enh;
                        i9Slot1 = slot.Enhancement;
                        i9Slot2 = slot.FlippedEnhancement;
                    }
                    else
                    {
                        num2 = 1f - num3;
                        index = slot.FlippedEnhancement.Enh;
                        Enh1 = index;
                        Enh2 = slot.Enhancement.Enh;
                        i9Slot1 = slot.FlippedEnhancement;
                        i9Slot2 = slot.Enhancement;
                    }
                }
                rectangle1 = new Rectangle(point1.X + 30 * i, point1.Y, 30, 30);
                if (num2 > 0.0)
                {
                    Rectangle rectangle2 = new Rectangle((int)Math.Round(rectangle1.X + (30.0 - 30.0 * num2) / 2.0), rectangle1.Y, (int)Math.Round(30.0 * num2), 30);
                    rectangle2 = this.drawing.ScaleDown(rectangle2);
                    rectangle1 = this.drawing.ScaleDown(rectangle1);
                    if (index > -1)
                    {
                        Graphics graphics = this.drawing.bxBuffer.Graphics;
                        I9Gfx.DrawFlippingEnhancement(ref graphics, rectangle1, num2, DatabaseAPI.Database.Enhancements[index].ImageIdx, I9Gfx.ToGfxGrade(DatabaseAPI.Database.Enhancements[index].TypeID, i9Slot1.Grade));
                    }
                    else
                        this.drawing.bxBuffer.Graphics.DrawImage(I9Gfx.EnhTypes.Bitmap, rectangle2, 0, 0, 30, 30, System.Drawing.GraphicsUnit.Pixel, recolourIa);
                    if (MidsContext.Config.CalcEnhLevel == Enums.eEnhRelative.None | slot.Level >= MidsContext.Config.ForceLevel | this.drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & !powerEntry.StatInclude)
                    {
                        rectangle2.Inflate(1, 1);
                        this.drawing.bxBuffer.Graphics.FillEllipse(solidBrush, rectangle2);
                    }
                    if (!(this.myDataView == null | i9Slot1 == null | i9Slot2 == null))
                        this.myDataView.FlipStage(i, Enh1, Enh2, num2, powerEntry.NIDPower, i9Slot1.Grade, i9Slot2.Grade);
                }
            }
            rectangle1 = new Rectangle(point1.X - 1, point1.Y - 1, this.drawing.SzPower.Width + 1, this.drawing.szSlot.Height + 1);
            this.drawing.Refresh(this.drawing.ScaleDown(rectangle1));
            if (this.FlipSlotState[this.FlipSlotState.Length - 1] >= this.FlipSteps)
                this.EndFlip();
        }

        bool DoOpen(string fName)
        {
            if (!File.Exists(fName))
                return false;
            this.DataViewLocked = false;
            this.NewToon(true, true);
            Stream mStream = null;
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
            this.PowerModified(markModified: false);
            this.UpdateControls(true);
            this.SetTitleBar(true);
            Application.DoEvents();
            this.GetBestDamageValues();
            this.UpdateColours(false);
            this.FloatUpdate(true);
            return true;
        }

        void DoRedraw()
        {
            if (drawing == null) return;
            this.NoResizeEvent = true;
            int width = this.pnlGFXFlow.Width;
            double scale = 1.0;
            Size drawingArea = this.drawing.GetDrawingArea();
            int num3 = width - 30;
            if (num3 < drawingArea.Width)
                scale = num3 / (double)drawingArea.Width;
            this.pnlGFX.Width = num3;
            this.pnlGFX.Height = (int)Math.Round(drawingArea.Height * scale);
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
            double scale = 1.0;
            Size drawingArea = this.drawing.GetDrawingArea();
            int num5 = num1 - 30;
            if (num5 < drawingArea.Width)
                scale = num5 / (double)drawingArea.Width;
            int num6 = (int)Math.Round(drawingArea.Height * scale);
            this.pnlGFX.Width = num5;
            this.pnlGFX.Height = num6;
            if (this.drawing.Scaling && scale == 1.0 || scale != 1.0)
            {
                this.drawing.bxBuffer.Size = this.pnlGFX.Size;
                Control pnlGfx = pnlGFX;
                this.drawing.ReInit(pnlGfx);
                this.pnlGFX = (PictureBox)pnlGfx;
                this.pnlGFX.Image = drawing.bxBuffer.Bitmap;
            }
            this.NoResizeEvent = true;
            if (scale < 1.0)
                this.drawing.SetScaling(this.pnlGFX.Size);
            else
                this.drawing.SetScaling(this.drawing.bxBuffer.Size);
            this.NoResizeEvent = false;
            this.ReArrange(false);
        }

        bool doSave()
        {
            if (this.LastFileName == string.Empty)
                return this.doSaveAs();
            else if (this.LastFileName.Length > 3 && this.LastFileName.ToUpper().EndsWith(".TXT"))
            {
                return this.doSaveAs();
            }
            else
            {
                if (MainModule.MidsController.Toon.Save(this.LastFileName))
                {
                    this.FileModified = false;
                    return true;
                }
                return false;
            }
        }

        bool doSaveAs()
        {
            this.FloatTop(false);
            if (this.LastFileName != string.Empty)
            {
                this.dlgSave.FileName = FileIO.StripPath(this.LastFileName);
                if (this.dlgSave.FileName.Length > 3 && this.dlgSave.FileName.ToUpper().EndsWith(".TXT"))
                    this.dlgSave.FileName = this.dlgSave.FileName.Substring(0, this.dlgSave.FileName.Length - 3) + this.dlgSave.DefaultExt;
                this.dlgSave.InitialDirectory = this.LastFileName.Substring(0, this.LastFileName.LastIndexOf("\\", StringComparison.Ordinal));
            }
            else if (!string.IsNullOrWhiteSpace(MidsContext.Character.Name))
            {
                if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
                    this.dlgSave.FileName = MidsContext.Character.Name + " - Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", string.Empty).Replace("Arachnos ", string.Empty);
                else
                    this.dlgSave.FileName = MidsContext.Character.Name + " - " + MidsContext.Character.Archetype.DisplayName + " (" + MidsContext.Character.Powersets[0].DisplayName + ")";
            }
            else if (MidsContext.Character.Archetype.ClassType == Enums.eClassType.VillainEpic)
            {
                this.dlgSave.FileName = "Arachnos " + MidsContext.Character.Powersets[0].DisplayName.Replace(" Training", string.Empty).Replace("Arachnos ", string.Empty);
            }
            else
            {
                this.dlgSave.FileName = MidsContext.Character.Archetype.DisplayName;
                SaveFileDialog dlgSave = this.dlgSave;
                dlgSave.FileName = dlgSave.FileName + " - " + MidsContext.Character.Powersets[0].DisplayName + " - " + MidsContext.Character.Powersets[1].DisplayName;
            }
            if (this.dlgSave.ShowDialog() == DialogResult.OK)
            {
                if (MainModule.MidsController.Toon.Save(this.dlgSave.FileName))
                {
                    this.FileModified = false;
                    this.LastFileName = this.dlgSave.FileName;
                    MidsContext.Config.LastFileName = this.dlgSave.FileName;
                    this.SetTitleBar(true);
                    this.FloatTop(true);
                    return true;
                }
                return false;
            }
            else
            {
                this.FloatTop(true);
                return false;
            }
        }

        void dvAnchored_Float()
        {
            this.FloatingDataForm = new frmFloatingStats(this)
            {
                Left = this.Left + this.dvAnchored.Left,
                Top = this.Top + this.dvAnchored.Top
            };
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
            => this.SetDataViewTab(Index);

        void dvAnchored_Unlock()
        {
            this.DataViewLocked = false;
            if (this.dvLastPower <= -1)
                return;
            this.Info_Power(this.dvLastPower, this.dvLastEnh, this.dvLastNoLev, this.DataViewLocked);
        }

        bool EditAccoladesOrTemps(int hIDPower)
        {
            if (hIDPower <= -1 || MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length <= 0)
                return false;

            List<IPower> iPowers = new List<IPower>();
            int num1 = MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers.Length - 1;
            for (int index = 0; index <= num1; ++index)
                iPowers.Add(DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].SubPowers[index].nIDPower]);
            frmAccolade frmAccolade = new frmAccolade(this, iPowers);
            frmAccolade.Text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower].DisplayName;
            frmAccolade.ShowDialog(this);
            this.EnhancementModified();
            this.LastClickPlacedSlot = false;
            return true;
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

        int[] fakeInitialize(params int[] nums) => nums;

        void FixPrimarySecondaryHeight()
        {
            if (this.dvAnchored.Visible & this.dvAnchored.Bounds.IntersectsWith(this.dvAnchored.SnapLocation))
            {
                Size size = this.ClientSize;
                int height = size.Height - this.dvAnchored.Height - this.cbPrimary.Top - this.cbPrimary.Height - 10;
                if (this.llPrimary.DesiredHeight < height)
                {
                    size = this.llPrimary.SizeNormal;
                    this.llPrimary.SizeNormal = new System.Drawing.Size(size.Width, this.llPrimary.DesiredHeight);
                }
                else
                {
                    if (height < 70)
                        height = 70;
                    size = new System.Drawing.Size(this.llPrimary.SizeNormal.Width, height);
                    this.llPrimary.SizeNormal = size;
                }
                if (this.llSecondary.DesiredHeight < height)
                {
                    size = new System.Drawing.Size(this.llSecondary.SizeNormal.Width, this.llSecondary.DesiredHeight);
                    this.llSecondary.SizeNormal = size;
                }
                else
                {
                    if (height < 70)
                        height = 70;
                    size = new System.Drawing.Size(this.llSecondary.SizeNormal.Width, height);
                    this.llSecondary.SizeNormal = size;
                }
            }
            else
            {
                Size size = new System.Drawing.Size(this.llPrimary.SizeNormal.Width, this.llPrimary.DesiredHeight);
                this.llPrimary.SizeNormal = size;
                size = new System.Drawing.Size(this.llSecondary.SizeNormal.Width, this.llSecondary.DesiredHeight);
                this.llSecondary.SizeNormal = size;
            }
        }

        void fixStatIncludes()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            for (int index = 0; index <= MidsContext.Character.CurrentBuild.Powers.Count - 1; ++index)
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

        internal void FloatCompareGraph(bool show)
        {
            if (show)
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
                this.fGraphCompare = null;
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
                this.fData = null;
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

        internal void FloatDPSCalc(bool showow)
        {
            if (showow)
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
                this.fDPSCalc = null;
            }
        }

        internal void FloatSetFinder(bool show)
        {
            if (show)
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
                this.fSetFinder = null;
            }
        }

        internal void FloatSets(bool show)
        {
            if (show)
            {
                if (this.fSets == null)
                {
                    frmMain iParent = this;
                    this.fSets = new frmSetViewer(iParent);
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
                this.fSets = null;
            }
        }

        internal void FloatStatGraph(bool show)
        {
            if (show)
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
                this.fGraphStats = null;
            }
        }

        void FloatTop(bool onTop)
        {
            if (!onTop)
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

        internal void FloatTotals(bool show)
        {
            if (show)
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
                this.fTotals = null;
            }
        }

        void FloatUpdate(bool newData = false)
        {
            if (this.fSets != null)
                this.fSets.UpdateData();
            if (this.fGraphStats != null)
                this.fGraphStats.UpdateData(newData);
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
            MidsContext.Config.SaveConfig(My.MyApplication.GetSerializer());
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


        void frmMain_Maximize(object sender, EventArgs e)
        {
            if (this.WindowState != this.LastState)
                this.frmMain_Resize(RuntimeHelpers.GetObjectValue(sender), e);
            this.LastState = this.WindowState;
        }

        void frmMain_MouseWheel(object sender, MouseEventArgs e) => this.dvAnchored.Info_txtLarge.Focus();

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
            float highBase = 0.0f;
            for (int index = 0; index <= MidsContext.Character.Powersets[0].Powers.Length - 1; ++index)
            {
                IPower power = MidsContext.Character.Powersets[0].Powers[index];
                if (!power.SkipMax)
                {
                    float damageValue = power.FXGetDamageValue();
                    if (damageValue > (double)highBase)
                        highBase = damageValue;
                }
            }
            for (int index = 0; index <= MidsContext.Character.Powersets[1].Powers.Length - 1; ++index)
            {
                IPower power = MidsContext.Character.Powersets[1].Powers[index];
                if (!power.SkipMax)
                {
                    float damageValue = power.FXGetDamageValue();
                    if (damageValue > (double)highBase)
                        highBase = damageValue;
                }
            }
            MainModule.MidsController.Toon.GenerateBuffedPowerArray();
            float highEnh = highBase * (1f + MidsContext.Character.TotalsCapped.BuffDam + Enhancement.ApplyED(Enums.eSchedule.A, 2.277f));
            if (MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPS | MidsContext.Config.DamageMath.ReturnValue == ConfigData.EDamageReturn.DPA)
                highEnh *= 1.5f;
            this.myDataView.Info_Damage.nHighBase = highBase;
            this.myDataView.Info_Damage.nHighEnh = highEnh;
        }

        int GetFirstValidSetEnh(int slotIndex, int hID)
        {
            if (this.LastEnhPlaced != null && this.LastEnhPlaced.Enh >= 0 && DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].TypeID == Enums.eType.SetO)
            {
                int nIdSet = DatabaseAPI.Database.Enhancements[this.LastEnhPlaced.Enh].nIDSet;
                if (nIdSet < 0)
                    return -1;
                if (MidsContext.Character.CurrentBuild.EnhancementTest(slotIndex, hID, this.LastEnhPlaced.Enh, true))
                    return this.LastEnhPlaced.Enh;
                int num = DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements.Length - 1;
                for (int index = 0; index <= num; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.EnhancementTest(slotIndex, hID, DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index], true))
                        return DatabaseAPI.Database.EnhancementSets[nIdSet].Enhancements[index];
                }
            }
            return -1;
        }

        bool GetPlayableClasses(Archetype a) => a.Playable;

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
                for (int index = 0; index <= power.NIDSubPower.Length - 1; ++index)
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
            bool enhChanged = false;
            if (MidsContext.Character.CurrentBuild.EnhancementTest(this.EnhancingSlot, this.EnhancingPower, e.Enh, false) | e.Enh < 0)
            {
                var power = MidsContext.Character.CurrentBuild.Powers[this.EnhancingPower];
                if (e.Enh != power.Slots[this.EnhancingSlot].Enhancement.Enh)
                    enhChanged = true;
                bool hasProc = power.HasProc();
                power.Slots[this.EnhancingSlot].Enhancement = (I9Slot)e.Clone();
                if (e.Enh > -1)
                    this.LastEnhPlaced = (I9Slot)e.Clone();
                if (enhChanged)
                {
                    if (e.Enh > -1)
                    {
                        if (!hasProc && power.HasProc() && (DatabaseAPI.Database.Enhancements[e.Enh].Probability == 0.0 || DatabaseAPI.Database.Enhancements[e.Enh].Probability == 1.0))
                            power.StatInclude = true;
                        else if (!power.CanIncludeForStats())
                            power.StatInclude = false;
                    }
                    else if (!power.CanIncludeForStats())
                        power.StatInclude = false;
                }
                this.I9Picker.Visible = false;
                this.PowerModified(markModified: true);
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
            this.ShowPopup(this.PickerHID, -1, -1, new System.Drawing.Point(), this.I9Picker.Bounds, i9Slot, -1);
        }

        void I9Picker_HoverSet(int e)
        {
            this.myDataView.SetSetPicker(e);
            this.ShowPopup(this.PickerHID, -1, -1, new System.Drawing.Point(), this.I9Picker.Bounds, null, e);
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

        void I9Popup_MouseMove(object sender, MouseEventArgs e) => this.HidePopup();

        void ibMode_ButtonClicked()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            MidsContext.Config.BuildMode = MidsContext.Config.BuildMode != Enums.dmModes.Dynamic ? Enums.dmModes.Dynamic : Enums.dmModes.LevelUp;
            MidsContext.Character.ResetLevel();
            // changing from dynamic view to level up or reverse is not a file modification
            this.PowerModified(markModified: false);
            this.UpdateDMBuffer();
            this.pbDynMode.Refresh();
        }

        void ibPopup_ButtonClicked() => MidsContext.Config.ShowPopup = this.ibPopup.Checked;

        void ibPvX_ButtonClicked()
        {
            MidsContext.Config.Inc.PvE = !this.ibPvX.Checked;
            this.RefreshInfo();
        }

        void ibRecipe_ButtonClicked() => MidsContext.Config.PopupRecipes = this.ibRecipe.Checked;

        void ibSets_ButtonClicked()
        {
            if (MainModule.MidsController.Toon == null)
                return;
            this.FloatSets(true);
        }

        void ibSlotLevels_ButtonClicked() => this.tsViewSlotLevels_Click(this, new EventArgs());

        void ibTotals_ButtonClicked() => this.FloatTotals(true);

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
            this.fIncarnate.Show(this);
        }

        void IncarnateWindowToolStripMenuItem_Click(object sender, EventArgs e) => this.incarnateButton_MouseDown(RuntimeHelpers.GetObjectValue(sender), new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));

        void Info_Enhancement(I9Slot iEnh, int iLevel = -1) => this.myDataView.SetEnhancement(iEnh, iLevel);

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
                this.myDataView.SetData(MainModule.MidsController.Toon.GetBasePower(num1, powerIdx), null, NoLevel, this.DataViewLocked, num1);
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

        void lblATLocked_MouseLeave(object sender, EventArgs e) => this.HidePopup();

        void lblATLocked_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || this.cbAT.SelectedIndex < 0)
                return;
            this.ShowPopup(-1, this.CbtAT.Value.SelectedItem.Idx, this.cbAT.Bounds, string.Empty);
        }

        void lblATLocked_Paint(object sender, PaintEventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            RectangleF destRect = new RectangleF(1f, (this.lblATLocked.Height - 16) / 2f, 16f, 16f);
            --destRect.Y;
            RectangleF srcRect = new RectangleF((MidsContext.Character.Archetype.Idx * 16), 0.0f, 16f, 16f);
            Graphics graphics = e.Graphics;
            graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
            destRect.X = this.lblATLocked.Width - 19;
            graphics.DrawImage(I9Gfx.Archetypes.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
        }

        void lblLocked0_MouseLeave(object sender, EventArgs e) => this.HidePopup();

        void lblLocked0_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[3] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[3].nID, MidsContext.Character.Archetype.Idx, this.cbPool0.Bounds, ExtraString);
        }

        void lblLocked0_Paint(object sender, PaintEventArgs e) => this.MiniPaint(ref e, Enums.PowersetType.Pool0);

        void lblLocked1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[4] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[4].nID, MidsContext.Character.Archetype.Idx, this.cbPool1.Bounds, ExtraString);
        }

        void lblLocked1_Paint(object sender, PaintEventArgs e) => this.MiniPaint(ref e, Enums.PowersetType.Pool1);

        void lblLocked2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[5] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[5].nID, MidsContext.Character.Archetype.Idx, this.cbPool2.Bounds, ExtraString);
        }

        void lblLocked2_Paint(object sender, PaintEventArgs e) => this.MiniPaint(ref e, Enums.PowersetType.Pool2);

        void lblLocked3_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[6] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[6].nID, MidsContext.Character.Archetype.Idx, this.cbPool3.Bounds, ExtraString);
        }

        void lblLocked3_Paint(object sender, PaintEventArgs e) => this.MiniPaint(ref e, Enums.PowersetType.Pool3);

        void lblLockedAncillary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Powersets[7] == null)
                return;
            string ExtraString = "This is a pool powerset. This powerset can be changed by removing all of the powers selected from it.";
            this.ShowPopup(MidsContext.Character.Powersets[7].nID, MidsContext.Character.Archetype.Idx, this.CbtAncillary.Value.Bounds, ExtraString);
        }

        void lblLockedAncillary_Paint(object sender, PaintEventArgs e) => this.MiniPaint(ref e, Enums.PowersetType.Ancillary);

        void lblLockedSecondary_MouseLeave(object sender, EventArgs e) => this.HidePopup();

        void lblLockedSecondary_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainModule.MidsController.Toon == null || MidsContext.Character.Archetype.Idx < 0 || this.cbSecondary.SelectedIndex < 0)
                return;
            string ExtraString = MidsContext.Character.Powersets[0].nIDLinkSecondary <= -1 ? "This is your secondary powerset. This powerset can be changed after a build has been started, and any placed powers will be swapped out for those in the new set." : "This is your secondary powerset. This powerset is linked to your primary set and cannot be changed independantly. However, it can be changed by selecting a different primary powerset.";
            this.ShowPopup(DatabaseAPI.GetPowersetIndexes(MidsContext.Character.Archetype, Enums.ePowerSetType.Secondary)[this.cbSecondary.SelectedIndex].nID, MidsContext.Character.Archetype.Idx, this.cbSecondary.Bounds, ExtraString);
        }

        void llAll_EmptyHover() => this.HidePopup();

        void llALL_MouseLeave(object sender, EventArgs e) => this.HidePopup();

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
                this.ShowPopup(Item.nIDSet, -1, this.llAncillary.Bounds, string.Empty);
            }
            else
            {
                this.Info_Power(Item.nIDPower, -1, false, false);
                this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llAncillary.Bounds, null, -1);
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
            this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llPool0.Bounds, null, -1);
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
            this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llPool1.Bounds, null, -1);
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
            this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llPool2.Bounds, null, -1);
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
            this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llPool3.Bounds, null, -1);
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
                this.ShowPopup(Item.nIDSet, -1, this.llPrimary.Bounds, string.Empty);
            }
            else
            {
                this.Info_Power(Item.nIDPower, -1, false, false);
                this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llPrimary.Bounds, null, -1);
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
                this.ShowPopup(Item.nIDSet, -1, this.llSecondary.Bounds, string.Empty);
            }
            else
            {
                this.Info_Power(Item.nIDPower, -1, false, false);
                this.ShowPopup(-1, Item.nIDPower, -1, new System.Drawing.Point(), this.llSecondary.Bounds, null, -1);
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
            graphics.DrawImage((Image)I9Gfx.Powersets.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
            destRect.X = (float)(this.lblLocked0.Width - 19);
            graphics.DrawImage((Image)I9Gfx.Powersets.Bitmap, destRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
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
                this.drawing = new clsDrawX(this.pnlGFX);
            }
            else
            {
                this.drawing.ReInit(this.pnlGFX);
            }
            this.pnlGFX.Image = drawing.bxBuffer.Bitmap;
            if (this.drawing != null)
                this.drawing.Highlight = -1;
            if (skipDraw)
                return;
            this.DoRedraw();
        }

        void NewToon(bool init = true, bool skipDraw = false)
        {
            if (MainModule.MidsController.Toon == null)
                MainModule.MidsController.Toon = new clsToonX();
            else if (init)
            {
                MidsContext.Character.Reset(null, 0);
            }
            else
            {
                string str = !MainModule.MidsController.Toon.Locked ? MidsContext.Character.Name : string.Empty;
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
            this.NewDraw(skipDraw);
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
            e.Graphics.DrawImage(dmBuffer.Bitmap, e.ClipRectangle, e.ClipRectangle, System.Drawing.GraphicsUnit.Pixel);
        }

        void pnlGFX_DragDrop(object sender, DragEventArgs e)
        {
            if (!sender.Equals(this.pnlGFX))
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
                    MessageBox.Show(this, "You cannot change the level of any power's automatic slot.", null, MessageBoxButtons.OK);
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
            if (sender.Equals(this.pnlGFX))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        void pnlGFX_DragOver(object sender, DragEventArgs e)
        {
            Point position;
            int num1;
            if (sender.Equals(this.pnlGFX))
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
                int width = this.drawing.ScaleDown(this.drawing.SzPower.Width);
                int height = this.drawing.ScaleDown(this.drawing.SzPower.Height);
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
            if (!(!this.LastClickPlacedSlot && this.dragStartSlot >= 0))
                return;
            MainModule.MidsController.Toon.BuildSlot(this.dragStartPower, this.dragStartSlot);
            // no idea what pnlGFX_MouseDoubleClick represents, marking modified as it would have before the added arg
            this.PowerModified(markModified: true);
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

        void pnlGFX_MouseEnter(object sender, EventArgs e) => this.pnlGFXFlow.Focus();

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
                    MessageBox.Show(this, "You cannot change the level of any power's automatic slot.", null, MessageBoxButtons.OK);
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
                        this.dragXOffset = this.drawing.ScaleDown(this.drawing.SzPower.Width / 2);
                        this.dragYOffset = this.drawing.ScaleDown(this.drawing.SzPower.Height / 2);
                    }
                    DataObject dataObject = new DataObject();
                    dataObject.SetText("This is some filler power text right here");
                    this.HidePopup();
                    this.pnlGFX.Cursor = Cursors.Default;
                    this.drawing.HighlightSlot(-1, false);
                    Application.DoEvents();
                    this.ibPopup.DoDragDrop(dataObject, DragDropEffects.Move);
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
                    Point e1 = new System.Drawing.Point(e.X, e.Y);
                    this.ShowPopup(index, -1, sIDX, e1, new Rectangle(), null, -1);
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
                int hIDPower = this.drawing.WhichSlot(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                int slotID = this.drawing.WhichEnh(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
                if (!(hIDPower < 0 | hIDPower >= MidsContext.Character.CurrentBuild.Powers.Count))
                {
                    bool flag = MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower < 0;
                    if (!(e.Button == MouseButtons.Left & Control.ModifierKeys == (System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control)) || !this.EditAccoladesOrTemps(hIDPower))
                    {
                        if (this.drawing.InterfaceMode == Enums.eInterfaceMode.PowerToggle & e.Button == MouseButtons.Left)
                        {
                            if (!flag && MidsContext.Character.CurrentBuild.Powers[hIDPower].CanIncludeForStats())
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[hIDPower].StatInclude)
                                {
                                    MidsContext.Character.CurrentBuild.Powers[hIDPower].StatInclude = false;
                                }
                                else
                                {
                                    Enums.eMutex eMutex = MainModule.MidsController.Toon.CurrentBuild.MutexV2(hIDPower, false, false);
                                    if (eMutex == Enums.eMutex.NoConflict | eMutex == Enums.eMutex.NoGroup)
                                        MidsContext.Character.CurrentBuild.Powers[hIDPower].StatInclude = true;
                                }
                            }
                            this.EnhancementModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (this.ToggleClicked(hIDPower, this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y)) & e.Button == MouseButtons.Left)
                        {
                            if (!flag && MidsContext.Character.CurrentBuild.Powers[hIDPower].CanIncludeForStats())
                            {
                                if (MidsContext.Character.CurrentBuild.Powers[hIDPower].StatInclude)
                                {
                                    MidsContext.Character.CurrentBuild.Powers[hIDPower].StatInclude = false;
                                }
                                else
                                {
                                    Enums.eMutex eMutex = MainModule.MidsController.Toon.CurrentBuild.MutexV2(hIDPower, false, false);
                                    if (eMutex == Enums.eMutex.NoConflict | eMutex == Enums.eMutex.NoGroup)
                                        MidsContext.Character.CurrentBuild.Powers[hIDPower].StatInclude = true;
                                }
                                MidsContext.Character.Validate();
                            }
                            this.EnhancementModified();
                            this.LastClickPlacedSlot = false;
                        }
                        else if (e.Button == MouseButtons.Left & Control.ModifierKeys == System.Windows.Forms.Keys.Alt)
                        {
                            MainModule.MidsController.Toon.BuildPower(MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPowerset, MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower, false);
                            this.PowerModified(markModified: true);
                            this.LastClickPlacedSlot = false;
                        }
                        else if (e.Button == MouseButtons.Left & Control.ModifierKeys == System.Windows.Forms.Keys.Shift & slotID > -1)
                        {
                            if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp)
                            {
                                MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[hIDPower].Slots[slotID].Level;
                                MidsContext.Character.ResetLevel();
                            }
                            MainModule.MidsController.Toon.BuildSlot(hIDPower, slotID);
                            this.PowerModified(markModified: true);
                            this.LastClickPlacedSlot = false;
                        }
                        else
                        {
                            if (e.Button == MouseButtons.Left & !this.EnhPickerActive)
                            {
                                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic & flag)
                                {
                                    if (flag & MidsContext.Character.CurrentBuild.Powers[hIDPower].Level > -1)
                                    {
                                        MainModule.MidsController.Toon.RequestedLevel = MidsContext.Character.CurrentBuild.Powers[hIDPower].Level;
                                        this.UpdatePowerLists();
                                        this.DoRedraw();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (MainModule.MidsController.Toon.BuildSlot(hIDPower, -1) > -1)
                                    {
                                        // adding a slot by itself doesn't really change the build substantially without an enh going into it
                                        this.PowerModified(markModified: false);
                                        this.LastClickPlacedSlot = true;
                                        MidsContext.Config.Tips.Show(Tips.TipType.FirstEnh);
                                        return;
                                    }
                                    this.LastClickPlacedSlot = false;
                                }
                            }
                            if (e.Button == MouseButtons.Middle & slotID > -1 & MidsContext.Config.ReapeatOnMiddleClick)
                            {
                                this.EnhancingSlot = slotID;
                                this.EnhancingPower = hIDPower;
                                this.I9Picker_EnhancementPicked(this.GetRepeatEnhancement(hIDPower, slotID));
                                this.EnhancementModified();
                            }
                            else if (e.Button == MouseButtons.Right & slotID > -1 && Control.ModifierKeys != System.Windows.Forms.Keys.Shift)
                            {
                                this.EnhancingSlot = slotID;
                                this.EnhancingPower = hIDPower;
                                int[] enhancements = MainModule.MidsController.Toon.GetEnhancements(hIDPower);
                                this.PickerHID = hIDPower;
                                if (!flag)
                                    this.I9Picker.SetData(MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower, ref MidsContext.Character.CurrentBuild.Powers[hIDPower].Slots[slotID].Enhancement, ref this.drawing, enhancements);
                                else
                                    this.I9Picker.SetData(-1, ref MidsContext.Character.CurrentBuild.Powers[hIDPower].Slots[slotID].Enhancement, ref this.drawing, enhancements);


                                var point = new System.Drawing.Point((int)Math.Round((double)(this.pnlGFXFlow.Left - this.pnlGFXFlow.HorizontalScroll.Value + e.X) - (double)this.I9Picker.Width / 2.0), (int)Math.Round((double)(this.pnlGFXFlow.Top - this.pnlGFXFlow.VerticalScroll.Value + e.Y) - (double)this.I9Picker.Height / 2.0));
                                if (point.Y < this.MenuBar.Height)
                                    point.Y = this.MenuBar.Height;
                                Size clientSize;
                                if (point.Y + this.I9Picker.Height > this.ClientSize.Height)
                                {
                                    ref Point local = ref point;
                                    clientSize = this.ClientSize;
                                    local.Y = clientSize.Height - this.I9Picker.Height;
                                }
                                clientSize = this.ClientSize;
                                if (point.X + this.I9Picker.Width > clientSize.Width)
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
                                this.StartFlip(hIDPower);
                            else if (e.Button == MouseButtons.Right)
                            {
                                this.Info_Power(MidsContext.Character.CurrentBuild.Powers[hIDPower].NIDPower, -1, true, true);
                                this.LastClickPlacedSlot = false;
                            }
                        }
                    }
                }
            }
        }

        void pnlGFXFlow_MouseEnter(object sender, EventArgs e) => this.pnlGFXFlow.Focus();

        // if we are loading a file, the file isn't modified when this method is called
        internal void PowerModified(bool markModified)
        {
            int index = -1;
            MainModule.MidsController.Toon.Complete = false;
            this.fixStatIncludes();
            if (markModified)
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
            this.ibAccolade.TextOff = slotCounts[0] <= 0 ? "No slots left" : slotCounts[0] + " slots to go";
            this.ibAccolade.TextOn = slotCounts[1] <= 0 ? "No slots placed" : slotCounts[1] + " slots placed";
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

        bool? CheckInitDdsaValue(int index, int? defaultOpt, string descript, params string[] options)
        {
            if (this.ddsa[index] != 0) return null;
            var (result, remember) = frmOptionListDlg.ShowWithOptions(AllowRemember: true, DefaultOption: defaultOpt ?? 1, descript, options);
            this.ddsa[index] = (short)result;
            if (remember == true)
                MidsContext.Config.DragDropScenarioAction[index] = this.ddsa[index];
            return remember;
        }

        int PowerMove(PowerEntry[] tp, int start, int finish)
        {
            if (tp[start].NIDPower != -1 && DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1 > tp[finish].Level)
            {
                if (this.ddsa[0] == 0)
                {
                    var canOverride = DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1 == tp[start].Level;
                    var (result, remember) = canOverride ? frmOptionListDlg.ShowWithOptions(true, 0, "Power is moved or swapped too low", "Allow power to be moved anyway (mark as invalid)") : frmOptionListDlg.ShowWithOptions(true, 1, "Power is moved or swapped too low", "Move/swap power to its lowest possible level", "Allow power to be moved anyway (mark as invalid)");
                    this.ddsa[0] = (short)result;
                    if (canOverride)
                    {
                        if (this.ddsa[0] == 2)
                            this.ddsa[0] = 3;
                    }
                    if (remember == true)
                        MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
                }
                if (this.ddsa[0] == 1)
                    return 0;
                if (this.ddsa[0] == 2)
                {
                    if (DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1 == tp[start].Level)
                    {
                        MessageBox.Show("You have chosen to always swap a power with its minimum level when attempting to move it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", null, MessageBoxButtons.OK);
                        return 0;
                    }
                    int lvl = DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1;
                    int index = 0;
                    while (tp[index].Level != lvl)
                    {
                        ++index;
                        if (index > 23)
                            return this.PowerMove(tp, start, lvl);
                    }
                }
            }
            bool flag1 = start < finish;
            bool[] flagArray = new bool[tp.Length - 1 + 1];
            if (flag1)
            {
                flagArray[start] = true;
                int level = tp[start].Level;
                int num = finish;
                for (int index = start + 1; index <= num; ++index)
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
            if (flag1 & !flagArray[finish])
            {

                CheckInitDdsaValue(1, null, "Power is moved too high (some powers will no longer fit)", "Move to the last power slot that can be shifted");
                if (this.ddsa[1] == 1)
                    return 0;
                if (this.ddsa[1] == 2)
                {
                    int num1 = start + 1;
                    int index;
                    for (index = finish; index >= num1; index += -1)
                    {
                        if (flagArray[index])
                        {
                            finish = index;
                            break;
                        }
                    }
                    if (finish != index)
                    {
                        MessageBox.Show("None of the powers can be shifted, so the power was not moved.", null, MessageBoxButtons.OK);
                        return 0;
                    }
                }
            }
            PowerEntry powerEntry = tp[start].NIDPower != -1 ? new PowerEntry(DatabaseAPI.Database.Power[tp[start].NIDPower]) : new PowerEntry(-1, null, false);
            powerEntry.Slots = (SlotEntry[])tp[start].Slots.Clone();
            powerEntry.Level = tp[start].Level;
            this.clearPower(tp, start);
            bool flag2 = false;
            int num3;
            int num4;
            int num5;
            if (flag1)
            {
                num3 = finish;
                num4 = start + 1;
                num5 = -1;
            }
            else
            {
                num3 = start + 1;
                num4 = finish;
                num5 = 1;
            }
            int num6 = num4;
            int num7 = num5;
            for (int index = num3; (num7 >> 31 ^ index) <= (num7 >> 31 ^ num6); index += num7)
            {
                if (tp[index].NIDPower != -1 && flag1 && !flagArray[index])
                {
                    CheckInitDdsaValue(7, null, "Power being shifted down cannot shift to the necessary level", "Shift other powers around it", "Overwrite it; leave previous power slot empty", "Allow anyway (mark as invalid)");
                    if (this.ddsa[7] == 1)
                        return 0;
                    if (this.ddsa[7] == 3)
                    {
                        if (!flag2)
                        {
                            start = index;
                            break;
                        }
                        break;
                    }
                }
                if (!flag2 & tp[index].NIDPower < 0)
                {
                    CheckInitDdsaValue(10, null, "There is a gap in a group of powers that are being shifted", "Fill empty slot; don't move powers unnecessarily", "Shift empty slot as if it were a power");
                    if (this.ddsa[10] == 1)
                        return 0;
                    if (this.ddsa[10] == 2)
                    {
                        if (tp[finish].NIDPower < 0)
                        {
                            powerEntry.Level = tp[start].Level;
                            tp[start] = powerEntry;
                            return this.PowerSwap(1, ref tp, start, finish) == 0 ? 0 : -1;
                        }
                        start = index;
                    }
                    flag2 = true;
                }
            }
            int index1 = start;
            int num8 = !flag1 ? index1 - 1 : index1 + 1;
            while (num8 != finish)
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
                        MessageBox.Show("Move canceled by user. If you didn't click Cancel, check that none of your Shift options are set to Cancel by default.", null, MessageBoxButtons.OK);
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
            switch (this.PowerSwap(1, ref tp, index1, num8))
            {
                case 0:
                    return 0;
                case 3:
                    this.PowerSwapByUser(this.dragStartPower, this.dragFinishPower);
                    return 0;
                default:
                    return -1;
            }
        }

        void PowerMoveByUser(int dragStart, int dragFinish)
        {
            if (dragStart < 0 || dragStart > 23 || dragFinish < 0 || dragFinish > 23 || dragStart == dragFinish)
                return;
            int index = 0;
            do
            {
                this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
            PowerEntry[] powerEntryArray = frmMain.DeepCopyPowerList();
            if (this.PowerMove(powerEntryArray, dragStart, dragFinish) != 0)
            {
                this.ShallowCopyPowerList(powerEntryArray);
                this.PowerModified(markModified: true);
                this.DoRedraw();
            }
        }

        void PowerPicked(Enums.PowersetType SetID, int nIDPower)
        {
            MainModule.MidsController.Toon.BuildPower(MidsContext.Character.Powersets[(int)SetID].nID, nIDPower, false);
            this.PowerModified(markModified: true);
            MidsContext.Config.Tips.Show(Tips.TipType.FirstPower);
        }

        void PowerPicked(int nIDPowerset, int nIDPower)
        {
            MainModule.MidsController.Toon.BuildPower(nIDPowerset, nIDPower, false);
            this.PowerModified(markModified: true);
            MidsContext.Config.Tips.Show(Tips.TipType.FirstPower);
            this.DoRedraw();
        }

        int PowerSwap(int mode, ref PowerEntry[] tp, int start, int finish)
        {
            int num1;
            if (start < 0 || start > 23 || finish < 0 || finish > 23 || start == finish)
                return 0;

            if (tp[start].NIDPower == -1 || DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1 <= tp[finish].Level)
            {
                if (tp[finish].NIDPower != -1 && DatabaseAPI.Database.Power[tp[finish].NIDPower].Level - 1 > tp[start].Level)
                {
                    switch (mode)
                    {
                        case 0:
                            CheckInitDdsaValue(4, null, "Power being replaced is swapped too low", "Overwrite rather than swap", "Allow power to be swapped anyway (mark as invalid)");
                            if (this.ddsa[4] == 1) return 0;
                            if (this.ddsa[4] == 2)
                            {
                                tp[finish].NIDPower = -1;
                                tp[finish].NIDPowerset = -1;
                                tp[finish].IDXPower = -1;
                                tp[finish].StatInclude = false;
                                tp[finish].VariableValue = 0;
                                tp[finish].Slots = new SlotEntry[0];
                            }
                            break;
                        case 2:
                            if (this.ddsa[7] == 2)
                                return 1;
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (mode == 0)
            {
                if (this.ddsa[0] == 0)
                {
                    if (DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1 == tp[start].Level)
                    {
                        var remember = CheckInitDdsaValue(0, null, "Power is moved or swapped too low", "Allow power to be moved anyway (mark as invalid)");
                        if (this.ddsa[0] == 2)
                        {
                            this.ddsa[0] = 3;
                            if (remember == true)
                                MidsContext.Config.DragDropScenarioAction[0] = this.ddsa[0];
                        }
                    }
                    else
                        CheckInitDdsaValue(0, 0, "Power is moved or swapped too low", "Move/swap power to its lowest possible level", "Allow power to be moved anyway (mark as invalid)");
                }
                if (this.ddsa[0] == 1)
                    return 0;

                if (this.ddsa[0] == 2)
                {
                    if (DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1 == tp[start].Level)
                    {
                        MessageBox.Show("You have chosen to always swap a power with its minimum level when attempting to swap it too low, but the power you are trying to swap is already at its minimum level. Visit the Drag & Drop tab of the configuration window to change this setting.", null, MessageBoxButtons.OK);
                        return 0;
                    }
                    int lvl = DatabaseAPI.Database.Power[tp[start].NIDPower].Level - 1;
                    int index = 0;
                    while (tp[index].Level != lvl)
                    {
                        ++index;
                        if (index > 23)
                            return this.PowerSwap(mode, ref tp, start, lvl);
                    }
                    int num4 = index;
                    return this.PowerSwap(mode, ref tp, start, num4);
                }
            }
            if (mode == 1 || mode == 2 && tp[finish].NIDPower != -1 && DatabaseAPI.Database.Power[tp[finish].NIDPower].Level - 1 == tp[finish].Level)
            {
                if (mode == 1)
                {
                    CheckInitDdsaValue(12, null, "The power in the destination slot is prevented from being shifted up", "Unlock and shift all level-locked powers", "Shift destination power to the first valid and empty slot", "Swap instead of move");
                    if (this.ddsa[12] == 1)
                        return 0;
                    if (this.ddsa[12] == 2)
                    {
                        this.ddsa[11] = 2;
                        return 2;
                    }
                    if (this.ddsa[12] != 3 && this.ddsa[12] == 4)
                        return 3;
                }
                else if (mode == 2)
                {
                    CheckInitDdsaValue(11, null, "A power placed at its minimum level is being shifted up", "Shift it along with the other powers", "Shift other powers around it");
                    if (this.ddsa[11] == 1)
                        return 0;
                    if (this.ddsa[11] != 2 && this.ddsa[11] == 3)
                        return 1;
                }
            }
            int num5 = tp[22].SlotCount + tp[23].SlotCount;
            int num6 = -1;
            if (start == 22 && finish < 22 && num5 <= 8 && tp[finish].SlotCount + tp[23].SlotCount > 8 || start == 23 && finish < 22 && tp[start].SlotCount <= 4 && tp[finish].SlotCount > 4 || start == 23 && finish < 22 && num5 <= 8 && tp[22].SlotCount + tp[finish].SlotCount > 8 || start == 23 && finish == 22 && tp[finish].SlotCount > 4)
            {
                if (mode < 2)
                    CheckInitDdsaValue(6, null, "Power being replaced is swapped too high to have # slots", "Remove impossible slots", "Allow anyway (Mark slots as invalid)");
                num6 = 6;
            }
            else if (start < 22 & finish == 22 & num5 <= 8 & tp[start].SlotCount + tp[23].SlotCount > 8 || start < 22 & finish == 23 & tp[finish].SlotCount <= 4 & tp[start].SlotCount > 4 || start < 22 & finish == 23 & num5 <= 8 & tp[22].SlotCount + tp[start].SlotCount > 8 || start == 22 & finish == 23 & tp[start].SlotCount > 4)
            {
                if (mode < 2)
                    CheckInitDdsaValue(3, null, "Power is moved or swapped too high to have # slots", "Remove impossible slots", "Allow anyway (Mark slots as invalid)");
                num6 = 3;
            }
            if (num6 != -1 && mode == 2)
            {
                CheckInitDdsaValue(9, null, "Power being shifted up has impossible # of slots", "Remove impossible slots", "Allow anyway (Mark slots as invalid)");
                num6 = 9;
            }
            if (((num6 != 6 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[6] == 1 ? 1 : 0)) != 0 || ((num6 != 3 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[3] == 1 ? 1 : 0)) != 0 || num6 == 9 && this.ddsa[9] == 1)
            {
                num1 = 0;
            }
            else
            {
                if (((num6 != 6 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[6] == 2 ? 1 : 0)) != 0 || ((num6 != 3 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[3] == 2 ? 1 : 0)) != 0 || num6 == 9 && this.ddsa[9] == 2)
                {
                    int index;
                    int num2;
                    if (start > finish)
                    {
                        index = finish;
                        num2 = start;
                    }
                    else
                    {
                        index = start;
                        num2 = finish;
                    }
                    //int integer1 = Conversions.ToInteger(Interaction.IIf(num2 == 22, index, RuntimeHelpers.GetObjectValue(Interaction.IIf(index == 22, num2, 22))));
                    int integer1 = num2 == 22 ? index : index == 22 ? num2 : 22;
                    int integer2 = num2 == 23 ? index : 23;
                    while (tp[integer1].SlotCount + tp[integer2].SlotCount > 8 || tp[index].SlotCount > 4 && integer2 != 23)
                        tp[index].Slots = tp[index].Slots.RemoveLast(); // (SlotEntry[])Utils.CopyArray(tp[index].Slots, (Array)new SlotEntry[tp[index].SlotCount - 2 + 1]);
                }
                else if (((num6 != 6 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[6] == (short)3 ? 1 : 0)) != 0 || ((num6 != 3 ? 0 : (mode < 2 ? 1 : 0)) & (this.ddsa[3] == (short)3 ? 1 : 0)) != 0 || num6 == 9 && this.ddsa[9] == (short)3)
                {
                    int index1 = start <= finish ? start : finish;
                    if (start == 23 | finish == 23)
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
                PowerEntry powerEntry = tp[start];
                tp[start] = tp[finish];
                tp[finish] = powerEntry;
                int level1 = tp[start].Level;
                tp[start].Level = tp[finish].Level;
                tp[finish].Level = level1;
                // swapping start and finish values
                int tmpSwap = start;
                start = finish;
                finish = tmpSwap;
                int index3 = 0;
                do
                {
                    if (tp[index3 == 0 ? start : finish].SlotCount > 0)
                    {
                        tp[index3 == 0 ? start : finish].Slots[0].Level = tp[index3 == 0 ? start : finish].Level;
                        int num2 = tp[index3 == 0 ? start : finish].SlotCount - 1;
                        int slotIDX = 1;
                        while (true)
                        {
                            if (slotIDX <= num2 && slotIDX <= tp[index3 == 0 ? start : finish].SlotCount - 1)
                            {
                                if (tp[index3 == 0 ? start : finish].Slots[slotIDX].Level < tp[index3 == 0 ? start : finish].Level)
                                {
                                    if (mode < 2 & index3 == 0 & this.ddsa[2] == 0)
                                    {
                                        CheckInitDdsaValue(2, 3, "Power is moved or swapped higher than slots' levels", "Remove slots", "Mark invalid slots", "Swap slot levels if valid; remove invalid ones", "Swap slot levels if valid; mark invalid ones", "Rearrange all slots in build");
                                    }
                                    else if (mode == 0 & index3 == 1 & this.ddsa[5] == 0)
                                    {
                                        CheckInitDdsaValue(5, 3, "Power being replaced is swapped higher than slots' levels", "Remove slots", "Mark invalid slots", "Swap slot levels if valid; remove invalid ones", "Swap slot levels if valid; mark invalid ones", "Rearrange all slots in build");
                                    }
                                    else if (mode == 2 & this.ddsa[8] == 0)
                                    {
                                        CheckInitDdsaValue(8, 3, "Power being shifted up has slots from lower levels", "Remove slots", "Mark invalid slots", "Swap slot levels if valid; remove invalid ones", "Swap slot levels if valid; mark invalid ones", "Rearrange all slots in build");
                                    }
                                    if (!(mode < 2 & index3 == 0 & this.ddsa[2] == 1 || mode == 0 & index3 == 1 & this.ddsa[5] == 1 || mode == 2 & this.ddsa[8] == 1))
                                    {
                                        var value = 1 - index3 == 0 ? start : finish;
                                        if (mode < 2 & index3 == 0 & this.ddsa[2] == 2 || mode == 0 & index3 == 1 & this.ddsa[5] == 2 || mode == 2 & this.ddsa[8] == 2)
                                        {
                                            this.RemoveSlotFromTempList(tp[index3 == 0 ? start : finish], slotIDX);
                                            --slotIDX;
                                        }
                                        else if (mode < 2 & index3 == 0 & this.ddsa[2] == 4 || mode == 0 & index3 == 1 & this.ddsa[5] == 4 || mode == 2 & this.ddsa[8] == 4)
                                        {
                                            if (tp[value].SlotCount > slotIDX)
                                            {
                                                int level2 = tp[value].Slots[slotIDX].Level;
                                                tp[value].Slots[slotIDX].Level = tp[index3 == 0 ? start : finish].Slots[slotIDX].Level;
                                                tp[index3 == 0 ? start : finish].Slots[slotIDX].Level = level2;
                                            }
                                            else
                                            {
                                                this.RemoveSlotFromTempList(tp[index3 == 0 ? start : finish], slotIDX);
                                                --slotIDX;
                                            }
                                        }
                                        else if (mode < 2 & index3 == 0 & this.ddsa[2] == 5 || mode == 0 & index3 == 1 & this.ddsa[5] == 5 || mode == 2 & this.ddsa[8] == 5)
                                        {
                                            if (tp[value].SlotCount > slotIDX)
                                            {
                                                int level2 = tp[value].Slots[slotIDX].Level;
                                                tp[value].Slots[slotIDX].Level = tp[index3 == 0 ? start : finish].Slots[slotIDX].Level;
                                                tp[index3 == 0 ? start : finish].Slots[slotIDX].Level = level2;
                                            }
                                        }
                                        else if (mode < 2 & index3 == 0 & this.ddsa[2] == 6 || mode == 0 & index3 == 1 & this.ddsa[5] == 6 || mode == 2 & this.ddsa[8] == 6)
                                            this.RearrangeAllSlotsInBuild(tp, true);
                                    }
                                    else
                                        return 0;
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
                num1 = -1;
            }
            return num1;
        }

        void PowerSwapByUser(int start, int finish)
        {
            int index = 0;
            do
            {
                this.ddsa[index] = MidsContext.Config.DragDropScenarioAction[index];
                ++index;
            }
            while (index <= 19);
            PowerEntry[] tp = frmMain.DeepCopyPowerList();
            if (this.PowerSwap(0, ref tp, start, finish) != -1)
                return;
            this.ShallowCopyPowerList(tp);
            this.PowerModified(markModified: true);
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
            ListLabelV2 ll;
            switch (Index)
            {
                case 0:
                    label = this.lblPool1;
                    ll = this.llPool0;
                    break;
                case 1:
                    label = this.lblPool2;
                    ll = this.llPool1;
                    break;
                case 2:
                    label = this.lblPool3;
                    ll = this.llPool2;
                    break;
                case 3:
                    label = this.lblPool4;
                    ll = this.llPool3;
                    break;
                case 4:
                    label = this.lblEpic;
                    ll = this.llAncillary;
                    break;
                default:
                    return new Rectangle(0, 0, 10, 10);
            }
            var height = ll.Top - label.Top + ll.Height;
            return new Rectangle(label.Left, label.Top, ll.Width, height);
        }

        int raGetTop() => MainModule.MidsController.Toon != null ? 4 + this.llPrimary.Top + this.raGreater(this.llPrimary.Height, this.llSecondary.Height) : this.llPrimary.Top + this.llPrimary.Height;

        int raGreater(int iVal1, int iVal2) => iVal1 <= iVal2 ? iVal2 : iVal1;

        void raMovePool(int Index, int X, int Y)
        {
            Label label1;
            ComboBox comboBox;
            Label label2;
            ListLabelV2 ll;
            switch (Index)
            {
                case 0:
                    label1 = this.lblPool1;
                    comboBox = this.cbPool0;
                    label2 = this.lblLocked0;
                    ll = this.llPool0;
                    break;
                case 1:
                    label1 = this.lblPool2;
                    comboBox = this.cbPool1;
                    label2 = this.lblLocked1;
                    ll = this.llPool1;
                    break;
                case 2:
                    label1 = this.lblPool3;
                    comboBox = this.cbPool2;
                    label2 = this.lblLocked2;
                    ll = this.llPool2;
                    break;
                case 3:
                    label1 = this.lblPool4;
                    comboBox = this.cbPool3;
                    label2 = this.lblLocked3;
                    ll = this.llPool3;
                    break;
                case 4:
                    label1 = this.lblEpic;
                    comboBox = this.cbAncillary;
                    label2 = this.lblLockedAncillary;
                    ll = this.llAncillary;
                    break;
                default:
                    return;
            }

            label1.Location = new System.Drawing.Point(X, Y);

            var point = new System.Drawing.Point(label1.Location.X, label1.Location.Y);
            point.Y += label1.Height;
            comboBox.Location = point;
            label2.Location = point;
            point.Y += comboBox.Height;
            ll.Location = point;
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
                this.llPrimary.SizeNormal = new System.Drawing.Size(size.Width, num - 4 - this.llPrimary.Top);

                this.llSecondary.SizeNormal = new System.Drawing.Size(this.llSecondary.SizeNormal.Width, num - 4 - this.llPrimary.Top);
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
            MessageBox.Show("The current arrangement of powers and their slots is impossible in-game. Invalid slots have been darkened and marked as level 51.", null, MessageBoxButtons.OK);
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
            => tp.Slots = tp.Slots.RemoveIndex(slotIDX);

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
            this.fMini.PInfo.BXHeight = bxHeight;
            this.fMini.SizeMe();
            this.fMini.Text = iTitle;
            this.fMini.PInfo.SetPopup(iData);
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
            this.I9Popup.Location = new System.Drawing.Point(x, y);
        }

        void SetTitleBar(bool Hero = true)
        {
            if (MainModule.MidsController.Toon != null)
                Hero = MainModule.MidsController.Toon.IsHero();
            string str1 = string.Empty;
            if (MainModule.MidsController.Toon != null)
            {
                if (this.LastFileName != string.Empty)
                {
                    str1 = FileIO.StripPath(this.LastFileName) + " - ";
                    this.tsFileSave.Text = "&Save '" + FileIO.StripPath(this.LastFileName) + "'";
                }
                else
                    this.tsFileSave.Text = "&Save";
            }
            else
                this.tsFileSave.Text = "&Save";
            string str2 = str1 + MidsContext.Title;
            if (!Hero)
                str2 = str2.Replace(nameof(Hero), "Villain");
            if (MidsContext.Config.MasterMode)
            {
                this.Text = str2 + " (Master Mode) v" + MidsContext.AppAssemblyVersion + " (DB: I" + DatabaseAPI.Database.Issue + " - Updated: " + DatabaseAPI.Database.Date.ToString(" dd / MMM / yyyy @ hh:mm tt") + ")";
            }
            else
            {
                this.Text = str2 + " v" + MidsContext.AppAssemblyVersion + " (Database Issue: " + DatabaseAPI.Database.Issue + " - Updated: " + DatabaseAPI.Database.Date.ToString("dd/MM/yy") + ")";
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
                PowerEntry powerEntry = null;
                if (hIDX > -1)
                    powerEntry = MidsContext.Character.CurrentBuild.Powers[hIDX];
                if (this.I9Popup.hIDX != hIDX | this.I9Popup.eIDX != sIDX | this.I9Popup.pIDX != pIDX | (this.I9Popup.hIDX == -1 | this.I9Popup.eIDX == -1 | this.I9Popup.pIDX == -1))
                {
                    Rectangle rectangle = new Rectangle();
                    if (hIDX > -1 & sIDX < 0 & pIDX < 0 & eSlot == null & setIDX < 0)
                    {
                        rectangle = this.drawing.PowerBoundsUnScaled(hIDX);
                        Point e1 = new System.Drawing.Point(this.drawing.ScaleUp(e.X), this.drawing.ScaleUp(e.Y));
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
                CheckInitDdsaValue(13, 0, "Slot being level-swapped is too low for the destination power", "Allow swap anyway (mark as invalid)");
                if (this.ddsa[13] == 1)
                    return;
            }
            if (MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level < MidsContext.Character.CurrentBuild.Powers[sourcePower].Level & !DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[sourcePower].NIDPower].AllowFrontLoading)
            {
                CheckInitDdsaValue(14, 0, "Slot being level-swapped is too low for the source power", "Allow swap anyway (mark as invalid)");
                if (this.ddsa[14] == (short)1)
                    return;
            }
            int level = MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level;
            MidsContext.Character.CurrentBuild.Powers[sourcePower].Slots[sourceSlot].Level = MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level;
            MidsContext.Character.CurrentBuild.Powers[destPower].Slots[destSlot].Level = level;
            this.PowerModified(markModified: true);
            this.DoRedraw();
        }

        internal void smlRespecLong(int iLevel, bool mode2)
        {
            this.SetMiniList(MidsContext.Character.CurrentBuild.GetRespecHelper2(true, iLevel), "Respec Helper", mode2 ? 5096 : 4072);
            this.fMini.Width = 350;
            this.fMini.SizeMe();
        }

        internal void smlRespecShort(int iLevel, bool mode2)
        {
            var helper = MidsContext.Character.CurrentBuild.GetRespecHelper2(false, iLevel);
            if (mode2)
                this.SetMiniList(helper, "Respec Helper", 4072);
            else
                this.SetMiniList(helper, "Respec Helper");
            this.fMini.Width = mode2 ? 300 : 250;
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
            this.FlipSlotState = new int[MidsContext.Character.CurrentBuild.Powers[iPowerIndex].Slots.Length];
            int num = this.FlipSlotState.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.FlipSlotState[index] = -(this.FlipStepDelay * index);
            this.FlipGP = new PowerEntry(-1, null, false);
            this.FlipGP.Assign(MidsContext.Character.CurrentBuild.Powers[iPowerIndex]);
            this.FlipGP.Slots = Array.Empty<SlotEntry>();
            if (this.tmrGfx == null)
                this.tmrGfx = new System.Windows.Forms.Timer(this.Container);
            this.tmrGfx.Interval = this.FlipInterval;
            this.FlipActive = true;
            this.tmrGfx.Enabled = true;
            this.tmrGfx.Start();
        }

        void TemporaryPowersWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tempPowersButton_MouseDown(sender, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0));
            this.tempPowersButton.Checked = true;
        }

        void tempPowersButton_ButtonClicked()
            => this.PowerModified(markModified: false);

        void tempPowersButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 2)
                return;
            this.tempPowersButton.Checked = false;
            if (this.fTemp == null || this.fTemp.IsDisposed)
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
            if (this.FlipActive)
                this.doFlipStep();
        }

        bool ToggleClicked(int hID, int iX, int iY)
        {
            Rectangle rectangle1 = new Rectangle();
            if (hID < 0)
                return false;
            if (MidsContext.Character.CurrentBuild.Powers[hID].IDXPower < 0)
                return false;
            Rectangle rectangle2 = new Rectangle()
            {
                Location = this.drawing.PowerPosition(MidsContext.Character.CurrentBuild.Powers[hID], -1),
                Size = this.drawing.bxPower[0].Size
            };
            rectangle1.Height = 15;
            rectangle1.Width = rectangle1.Height;
            rectangle1.Y = (int)Math.Round(rectangle2.Top + ((rectangle2.Height - rectangle1.Height) / 2.0));
            rectangle1.X = (int)Math.Round(rectangle2.Right - (rectangle1.Width + (rectangle2.Height - rectangle1.Height) / 2.0));
            return iX > rectangle1.X & iX < rectangle1.Right & iY > rectangle1.Top & iY < rectangle1.Bottom;
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
                MessageBox.Show("Fresh Install flag has been unset!", null, MessageBoxButtons.OK);
            }
            else
            {
                MidsContext.Config.FreshInstall = true;
                MidsContext.Config.SaveFolderChecked = false;
                MessageBox.Show("Fresh Install flag has been set!", null, MessageBoxButtons.OK);
            }
            this.tsAdvFreshInstall.Checked = MidsContext.Config.FreshInstall;
            this.FloatTop(true);
        }

        void tsAdvResetTips_Click(object sender, EventArgs e) => MidsContext.Config.Tips = new Tips();

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
            catch (Exception ex) { }
            clsXMLUpdate.BugReport(at, pri, sec, string.Empty);
        }

        void tsClearAllEnh_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (MessageBox.Show("Really clear all slotted enhancements?\r\nThis will not clear the alternate slotting, only the currently active slots.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int index1 = 0; index1 <= MidsContext.Character.CurrentBuild.Powers.Count - 1; ++index1)
                {
                    for (int index2 = 0; index2 <= MidsContext.Character.CurrentBuild.Powers[index1].Slots.Length - 1; ++index2)
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
            if (frmCalcOpt.ShowDialog(this) == DialogResult.OK)
            {
                this.UpdateControls(false);
                this.UpdateOtherFormsFonts();
            }
            frmCalcOpt.Dispose();
            this.tsIODefault.Text = "Default (" + (MidsContext.Config.I9.DefaultIOLevel + 1) + ")";
            this.FloatTop(true);
        }

        void tsDonate_Click(object sender, EventArgs e) => clsXMLUpdate.Donate();

        void tsDynamic_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            MidsContext.Config.BuildMode = Enums.dmModes.Dynamic;
            MidsContext.Character.ResetLevel();
            this.PowerModified(markModified: false);
        }

        void OnRelativeClick(Enums.eEnhRelative newVal)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            if (MidsContext.Character.CurrentBuild.SetEnhRelativelevels(newVal))
                this.I9Picker.UI.Initial.RelLevel = newVal;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToEven_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.Even);

        void tsEnhToMinus1_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.MinusOne);

        void tsEnhToMinus2_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.MinusTwo);

        void tsEnhToMinus3_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.MinusThree);

        void tsEnhToNone_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.None);

        void tsEnhToPlus1_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.PlusOne);

        void tsEnhToPlus2_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.PlusTwo);

        void tsEnhToPlus3_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.PlusThree);

        void tsEnhToPlus4_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.PlusFour);

        void tsEnhToPlus5_Click(object sender, EventArgs e)
            => OnRelativeClick(Enums.eEnhRelative.PlusFive);

        void OnGradePick(Enums.eEnhGrade grade)
        {
            if (MidsContext.Character == null)
                return;
            if (MidsContext.Character.CurrentBuild.SetEnhGrades(grade))
                this.I9Picker.UI.Initial.GradeID = grade;
            this.info_Totals();
            this.DoRedraw();
        }

        void tsEnhToDO_Click(object sender, EventArgs e)
            => OnGradePick(Enums.eEnhGrade.DualO);


        void tsEnhToSO_Click(object sender, EventArgs e)
            => OnGradePick(Enums.eEnhGrade.SingleO);

        void tsEnhToTO_Click(object sender, EventArgs e)
            => OnGradePick(Enums.eEnhGrade.TrainingO);

        void tsExport_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            MidsContext.Config.LongExport = false;
            var frmForum1 = new frmForum
            {
                BackColor = this.BackColor
            };
            frmForum1.IBCancel.IA = this.drawing.pImageAttributes;
            frmForum1.IBCancel.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum1.IBCancel.ImageOn = this.drawing.bxPower[3].Bitmap;
            frmForum1.IBExport.IA = this.drawing.pImageAttributes;
            frmForum1.IBExport.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum1.IBExport.ImageOn = this.drawing.bxPower[3].Bitmap;
            frmForum1.ShowDialog(this);
            this.FloatTop(true);
        }

        void tsExportDataLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(MidsCharacterFileFormat.MxDBuildSaveHyperlink(false, true), true);
            MessageBox.Show("The data link has been placed on the clipboard and is ready to paste.", "Export Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool exportDiscordInProgress;

        public async void tsExportDiscord_Click(object sender, EventArgs e)
        {
            void ShowConfigError(string field)
                => MessageBox.Show($"{field} must be filled out in configuration before discord exports will function", "Discord is not configured");
            if (exportDiscordInProgress)
            {
                MessageBox.Show("Another discord export is in progress, might be stuck");
                return;
            }

            if (string.IsNullOrWhiteSpace(MidsContext.Config.DSelServer))
            {
                ShowConfigError("Server");
                return;
            }
            if (string.IsNullOrWhiteSpace(MidsContext.Config.DChannel))
            {
                // tired of typing this
                if (System.Diagnostics.Debugger.IsAttached) MidsContext.Config.DChannel = "feature-testing";
                ShowConfigError("Channel");
                return;
            }
            if (string.IsNullOrWhiteSpace(MidsContext.Config.DNickName))
            {
                ShowConfigError("NickName");
                return;
            }
            exportDiscordInProgress = true;
            try
            {
                await Clshook.DiscordExport();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                exportDiscordInProgress = false;
            }
        }

        void tsExportLong_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            MidsContext.Config.LongExport = true;
            frmForum frmForum1 = new frmForum
            {
                BackColor = this.BackColor
            };
            frmForum1.IBCancel.IA = this.drawing.pImageAttributes;
            frmForum1.IBCancel.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum1.IBCancel.ImageOn = this.drawing.bxPower[3].Bitmap;
            frmForum1.IBExport.IA = this.drawing.pImageAttributes;
            frmForum1.IBExport.ImageOff = this.drawing.bxPower[2].Bitmap;
            frmForum1.IBExport.ImageOn = this.drawing.bxPower[3].Bitmap;
            frmForum1.ShowDialog(this);
            this.FloatTop(true);
            MidsContext.Config.LongExport = false;
        }

        void tsFileNew_Click(object sender, EventArgs e) => this.command_New();

        void tsFileOpen_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon.Locked & this.FileModified)
            {
                this.FloatTop(false);
                DialogResult msgBoxResult = MessageBox.Show("Current hero/villain data will be discarded, are you sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                this.FloatTop(true);
                if (msgBoxResult == DialogResult.No)
                    return;
            }
            this.FloatTop(false);
            if (this.DlgOpen.ShowDialog() == DialogResult.OK)
                this.DoOpen(this.DlgOpen.FileName);
            this.FloatTop(true);
        }

        void tsFilePrint_Click(object sender, EventArgs e)
            => new frmPrint().ShowDialog(this);

        void tsFileQuit_Click(object sender, EventArgs e)
            => this.Close();

        void tsFileSave_Click(object sender, EventArgs e)
            => this.doSave();

        void tsFileSaveAs_Click(object sender, EventArgs e)
            => this.doSaveAs();

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
                BtnClose = {
                      IA = this.drawing.pImageAttributes,
                      ImageOff = this.drawing.bxPower[2].Bitmap,
                      ImageOn = this.drawing.bxPower[3].Bitmap
                }
            };
            this.FloatTop(false);
            frmReadme.ShowDialog(this);
            this.FloatTop(true);
        }

        void tsHelperLong_Click(object sender, EventArgs e) => new FrmInputLevel(this, true, false).ShowDialog(this);

        void tsHelperLong2_Click(object sender, EventArgs e) => new FrmInputLevel(this, true, true).ShowDialog(this);

        void tsHelperShort_Click(object sender, EventArgs e) => new FrmInputLevel(this, false, false).ShowDialog(this);

        void tsHelperShort2_Click(object sender, EventArgs e) => new FrmInputLevel(this, false, true).ShowDialog(this);

        void tsImport_Click(object sender, EventArgs e) => this.command_ForumImport();

        void tsIODefault_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, false))
                this.I9Picker.LastLevel = MidsContext.Config.I9.DefaultIOLevel + 1;
            this.DoRedraw();
        }

        void tsIOMax_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, false, true))
                this.I9Picker.LastLevel = 50;
            this.DoRedraw();
        }

        void tsIOMin_Click(object sender, EventArgs e)
        {
            if (MidsContext.Character.CurrentBuild.SetIOLevels(MidsContext.Config.I9.DefaultIOLevel, true, false))
                this.I9Picker.LastLevel = 10;
            this.DoRedraw();
        }

        void tsLevelUp_Click(object sender, EventArgs e)
        {
            if (MainModule.MidsController.Toon == null)
                return;
            MidsContext.Config.BuildMode = Enums.dmModes.LevelUp;
            MidsContext.Character.ResetLevel();
            this.PowerModified(markModified: true);
        }

        void tsPatchNotes_Click(object sender, EventArgs e)
        {
            string str = OS.GetApplicationPath() + "Data\\patch.rtf";
            if (File.Exists(str))
            {
                frmReadme frmReadme = new frmReadme(str)
                {
                    BtnClose = {
                        IA = this.drawing.pImageAttributes,
                        ImageOff = this.drawing.bxPower[2].Bitmap,
                        ImageOn = this.drawing.bxPower[3].Bitmap
                    }
                };
                this.FloatTop(false);
                frmReadme.ShowDialog((IWin32Window)this);
                this.FloatTop(true);
            }
            else
            {
                this.FloatTop(false);
                MessageBox.Show("No recent patches have been installed.", "No Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FloatTop(true);
            }
        }

        void tsRecipeViewer_Click(object sender, EventArgs e) => this.FloatRecipe(true);

        void tsDPSCalc_Click(object sender, EventArgs e) => this.FloatDPSCalc(true);

        void tsRemoveAllSlots_Click(object sender, EventArgs e)
        {
            this.FloatTop(false);
            if (MessageBox.Show("Really remove all slots?\r\nThis will not remove the slots granted automatically with powers, but will remove all the slots you placed manually.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int index = 0; index <= MidsContext.Character.CurrentBuild.Powers.Count - 1; ++index)
                {
                    if (MidsContext.Character.CurrentBuild.Powers[index].SlotCount > 1)
                        MidsContext.Character.CurrentBuild.Powers[index].Slots = MidsContext.Character.CurrentBuild.Powers[index].Slots.Take(1).ToArray();
                }
                this.DoRedraw();
                MidsContext.Character.ResetLevel();
                // if all slots are removed, changes are they don't want to be prompted to save, unless something else is changed/added
                this.PowerModified(markModified: false);
                this.RefreshInfo();
            }
            this.FloatTop(true);
        }

        void tsSetFind_Click(object sender, EventArgs e)
            => this.FloatSetFinder(true);

        void tsForumLink(object sender, EventArgs e)
            => clsXMLUpdate.GoToForums();

        void tsRebornLink(object sender, EventArgs e)
            => clsXMLUpdate.GoToMidsReborn();

        void tsUpdateCheck_Click(object sender, EventArgs e)
        {
            clsXMLUpdate clsXmlUpdate = new clsXMLUpdate(); //"http://midsreborn.com/mids_updates/");
            var (eCheckResponse, msg) = clsXmlUpdate.UpdateCheck();
            if (eCheckResponse != clsXMLUpdate.eCheckResponse.Updates & eCheckResponse != clsXMLUpdate.eCheckResponse.FailedWithMessage)
            {
                MessageBox.Show("No Updates.", "Update Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (eCheckResponse == clsXMLUpdate.eCheckResponse.Updates)
            {
                if (clsXmlUpdate.RestartNeeded && MessageBox.Show("Exit Now?", "Update Downloaded", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && !this.CloseCommand())
                {
                    Application.Exit();
                    return;
                }
            }
            if (eCheckResponse == clsXMLUpdate.eCheckResponse.FailedWithMessage)
            {
                if (!string.IsNullOrWhiteSpace(msg))
                    frmLoading.ShowLinkDialog("Check failed", $"{msg}, click here to open site in browser", MidsContext.DownloadUrl);
                else
                {
                    frmLoading.ShowLinkDialog("Error", "Unknown error checking for updates, check failed, click here to open site in browser", MidsContext.DownloadUrl);
                    return;
                }
            }
            this.RefreshInfo();
        }

        void tsView2Col_Click(object sender, EventArgs e) => this.setColumns(2);

        void tsView3Col_Click(object sender, EventArgs e) => this.setColumns(3);

        void tsView4Col_Click(object sender, EventArgs e) => this.setColumns(4);

        void tsViewActualDamage_New_Click(object sender, EventArgs e)
        {
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.Numeric;
            this.SetDamageMenuCheckMarks();
            this.DisplayFormatChanged();
        }

        void tsViewData_Click(object sender, EventArgs e) => this.FloatData(true);

        void tsViewDPS_New_Click(object sender, EventArgs e)
        {
            MidsContext.Config.DamageMath.ReturnValue = ConfigData.EDamageReturn.DPS;
            this.SetDamageMenuCheckMarks();
            this.DisplayFormatChanged();
        }

        void tsViewGraphs_Click(object sender, EventArgs e) => this.FloatStatGraph(true);

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
            => this.FloatCompareGraph(true);

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

        void tsViewTotals_Click(object sender, EventArgs e) => this.FloatTotals(true);

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
            this.fMini = null;
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
            this.I9Popup.BackColor = System.Drawing.Color.Black;
            this.I9Popup.ForeColor = this.I9Picker.ForeColor;
            this.myDataView.BackColor = this.BackColor;
            var font = new Font(this.llPrimary.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            var toColor = new Control[]
            {
                this.llPrimary, this.llSecondary,
                this.llPool0, this.llPool1, this.llPool2, this.llPool3,
                this.llAncillary,
                this.lblName, this.lblAT, this.lblOrigin, this.lblHero,
                this.pnlGFX,
                this.lblLocked0, this.lblLocked1, this.lblLocked2, this.lblLocked3,
                this.lblLockedAncillary, this.lblLockedSecondary, this.lblATLocked
            };
            foreach (var colorItem in toColor)
            {
                colorItem.BackColor = this.BackColor;
                if (colorItem is ListLabelV2 ll)
                {
                    this.UpdateLLColours(ll);
                    ll.Font = font;
                }

            }

            var ibs = new ImageButton[]
            {
                this.ibSets,
                this.ibPvX,
                this.incarnateButton,
                this.tempPowersButton,
                this.accoladeButton,
                this.heroVillain,
                this.ibVetPools,
                this.ibTotals,
                this.ibMode,
                this.ibSlotLevels,
                this.ibPopup,
                this.ibRecipe,
                this.ibAccolade,
            };
            foreach (var ib in ibs)
                ib.SetImages(this.drawing.pImageAttributes, this.drawing.bxPower[2].Bitmap, this.drawing.bxPower[3].Bitmap);


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
            Archetype[] all = Array.FindAll(DatabaseAPI.Database.Classes, new Predicate<Archetype>(this.GetPlayableClasses));
            var cbAT = new ComboBoxT<Archetype>(this.cbAT);
            if (this.ComboCheckAT(all))
            {
                cbAT.BeginUpdate();
                cbAT.Clear();
                cbAT.AddRange(all);
                cbAT.EndUpdate();
            }
            if (cbAT.SelectedItem == null)
                cbAT.SelectedItem = MidsContext.Character.Archetype;
            //else if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(cbAT.SelectedItem, null, "Idx", new object[0], null, (System.Type[])null, null), MidsContext.Character.Archetype.Idx, false))
            else if (cbAT.SelectedItem.Idx != MidsContext.Character.Archetype.Idx)
                cbAT.SelectedItem = MidsContext.Character.Archetype;
            this.ibPvX.Checked = !MidsContext.Config.Inc.PvE;
            var cbOrigin = new ComboBoxT<string>(this.cbOrigin);
            if (this.ComboCheckOrigin())
            {
                cbOrigin.BeginUpdate();
                cbOrigin.Clear();
                cbOrigin.AddRange(cbAT.SelectedItem.Origin);
                cbOrigin.EndUpdate();
            }
            if (cbOrigin.SelectedIndex != MidsContext.Character.Origin)
            {
                if (MidsContext.Character.Origin < cbOrigin.Items.Count)
                    cbOrigin.SelectedIndex = MidsContext.Character.Origin;
                else
                    cbOrigin.SelectedIndex = 0;
                I9Gfx.SetOrigin(cbOrigin.SelectedItem);
            }
            frmMain.ComboCheckPS(CbtPrimary.Value, Enums.PowersetType.Primary, Enums.ePowerSetType.Primary);
            frmMain.ComboCheckPS(CbtSecondary.Value, Enums.PowersetType.Secondary, Enums.ePowerSetType.Secondary);
            if (MidsContext.Character.Powersets[0].nIDLinkSecondary > -1)
                this.cbSecondary.Enabled = false;
            else
                this.cbSecondary.Enabled = true;
            frmMain.ComboCheckPool(CbtPool0.Value, Enums.ePowerSetType.Pool);
            frmMain.ComboCheckPool(CbtPool1.Value, Enums.ePowerSetType.Pool);
            frmMain.ComboCheckPool(CbtPool2.Value, Enums.ePowerSetType.Pool);
            frmMain.ComboCheckPool(CbtPool3.Value, Enums.ePowerSetType.Pool);
            frmMain.ComboCheckPool(CbtAncillary.Value, Enums.ePowerSetType.Ancillary);
            this.cbPool0.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(0, MidsContext.Character.Powersets[3]?.nID ?? -1);
            this.cbPool1.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(1, MidsContext.Character.Powersets[4]?.nID ?? -1);
            this.cbPool2.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(2, MidsContext.Character.Powersets[5]?.nID ?? -1);
            this.cbPool3.SelectedIndex = MainModule.MidsController.Toon.PoolToComboID(3, MidsContext.Character.Powersets[6]?.nID ?? -1);
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
            cbAT.Enabled = !MainModule.MidsController.Toon.Locked;
            this.cbPool0.Enabled = !MainModule.MidsController.Toon.PoolLocked[0];
            this.cbPool1.Enabled = !MainModule.MidsController.Toon.PoolLocked[1];
            this.cbPool2.Enabled = !MainModule.MidsController.Toon.PoolLocked[2];
            this.cbPool3.Enabled = !MainModule.MidsController.Toon.PoolLocked[3];
            this.cbAncillary.Enabled = !MainModule.MidsController.Toon.PoolLocked[4];
            this.lblATLocked.Text = cbAT.SelectedItem.DisplayName;
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
            this.llPrimary.Font = new System.Drawing.Font(this.llPrimary.Font.FontFamily, MidsContext.Config.RtFont.PairedBase, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.llSecondary.Font = this.llPrimary.Font;
            int num1 = this.llPrimary.Items.Length - 1;
            for (int index = 0; index <= num1; ++index)
                this.llPrimary.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            int num2 = this.llSecondary.Items.Length - 1;
            for (int index = 0; index <= num2; ++index)
                this.llSecondary.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
            this.heroVillain.Checked = !MidsContext.Character.IsHero();
            this.dvAnchored.SetLocation(new System.Drawing.Point(this.llPrimary.Left, this.llPrimary.Top + this.raGreater(this.llPrimary.SizeNormal.Height, this.llSecondary.SizeNormal.Height) + 5), ForceComplete);
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
                iStr = slotsRemaining + " Slot";
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
            Font bFont = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            if (ePowerState == Enums.ePowerState.Open)
                this.dmBuffer.Graphics.DrawImage((Image)this.drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel);
            else
                this.dmBuffer.Graphics.DrawImage((Image)this.drawing.bxPower[(int)ePowerState].Bitmap, destRect, 0, 0, rectangle.Width, rectangle.Height, System.Drawing.GraphicsUnit.Pixel, this.drawing.pImageAttributes);
            float height2 = bFont.GetHeight(this.dmBuffer.Graphics) + 2f;
            RectangleF Bounds = new RectangleF(0.0f, (float)(((double)this.pbDynMode.Height - (double)height2) / 2.0), (float)this.pbDynMode.Width, height2);
            Graphics graphics = this.dmBuffer.Graphics;
            clsDrawX.DrawOutlineText(iStr, Bounds, Color.WhiteSmoke, Color.FromArgb(192, 0, 0, 0), bFont, 1f, graphics, false, false);
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
            this.ibMode.TextOff = MidsContext.Config.BuildMode != Enums.dmModes.Dynamic ? (!MainModule.MidsController.Toon.Complete ? "Level-Up: " + (MidsContext.Character.Level + 1) : "Level-Up") : "Dynamic";
        }

        void UpdateLLColours(ListLabelV2 iList)
        {
            iList.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
            iList.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
            iList.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb(byte.MaxValue, 0, 0));
            iList.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
            if (this.myDataView.DrawVillain)
            {
                iList.ScrollBarColor = System.Drawing.Color.FromArgb(byte.MaxValue, 0, 0);
                iList.ScrollButtonColor = System.Drawing.Color.FromArgb(192, 0, 0);
            }
            else
            {
                iList.ScrollBarColor = System.Drawing.Color.FromArgb(64, 64, byte.MaxValue);
                iList.ScrollButtonColor = System.Drawing.Color.FromArgb(32, 32, byte.MaxValue);
            }
        }

        void UpdateOtherFormsFonts()
        {
            if (this.fIncarnate != null)
            {
                frmIncarnate fIncarnate = this.fIncarnate;
                if (fIncarnate.Visible)
                {
                    fIncarnate.LLLeft.SuspendRedraw = true;
                    fIncarnate.LLRight.SuspendRedraw = true;
                    fIncarnate.LLLeft.Font = this.llPrimary.Font;
                    fIncarnate.LLRight.Font = this.llPrimary.Font;
                    fIncarnate.LLLeft.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fIncarnate.LLLeft.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fIncarnate.LLLeft.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fIncarnate.LLLeft.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fIncarnate.LLLeft.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                    fIncarnate.LLLeft.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    fIncarnate.LLRight.UpdateTextColors(ListLabelV2.LLItemState.Enabled, MidsContext.Config.RtFont.ColorPowerAvailable);
                    fIncarnate.LLRight.UpdateTextColors(ListLabelV2.LLItemState.Disabled, MidsContext.Config.RtFont.ColorPowerDisabled);
                    fIncarnate.LLRight.UpdateTextColors(ListLabelV2.LLItemState.Selected, MidsContext.Config.RtFont.ColorPowerTaken);
                    fIncarnate.LLRight.UpdateTextColors(ListLabelV2.LLItemState.SelectedDisabled, MidsContext.Config.RtFont.ColorPowerTakenDark);
                    fIncarnate.LLRight.UpdateTextColors(ListLabelV2.LLItemState.Invalid, Color.FromArgb((int)byte.MaxValue, 0, 0));
                    fIncarnate.LLRight.HoverColor = MidsContext.Config.RtFont.ColorPowerHighlight;
                    int num1 = fIncarnate.LLLeft.Items.Length - 1;
                    for (int index = 0; index <= num1; ++index)
                        fIncarnate.LLLeft.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    int num2 = fIncarnate.LLRight.Items.Length - 1;
                    for (int index = 0; index <= num2; ++index)
                        fIncarnate.LLRight.Items[index].Bold = MidsContext.Config.RtFont.PairedBold;
                    fIncarnate.LLLeft.SuspendRedraw = false;
                    fIncarnate.LLRight.SuspendRedraw = false;
                    fIncarnate.LLLeft.Refresh();
                    fIncarnate.LLRight.Refresh();
                }
            }
            if (this.fTemp != null)
            {
                frmAccolade fTemp = this.fTemp;
                if (fTemp.Visible)
                    fTemp.UpdateFonts(this.llPrimary.Font);
            }
            if (this.fAccolade == null)
                return;
            frmAccolade fAccolade = this.fAccolade;
            if (fAccolade.Visible)
                fAccolade.UpdateFonts(this.llPrimary.Font);
        }

        void UpdatePowerList(ListLabelV2 llPower)
        {
            llPower.SuspendRedraw = true;
            if (llPower.Items.Length == 0)
                llPower.AddItem(new ListLabelV2.ListLabelItemV2("Nothing", ListLabelV2.LLItemState.Disabled, -1, -1, -1, string.Empty, ListLabelV2.LLFontFlags.Normal, ListLabelV2.LLTextAlign.Left));
            int num = llPower.Items.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                ListLabelV2.ListLabelItemV2 listLabelItemV2 = llPower.Items[index];
                if (listLabelItemV2.nIDSet > -1 & listLabelItemV2.IDXPower > -1)
                {
                    string message = string.Empty;
                    listLabelItemV2.ItemState = MainModule.MidsController.Toon.PowerState(listLabelItemV2.nIDPower, ref message);
                    listLabelItemV2.Italic = listLabelItemV2.ItemState == ListLabelV2.LLItemState.Invalid;
                    listLabelItemV2.Bold = MidsContext.Config.RtFont.PairedBold;
                }
            }
            llPower.SuspendRedraw = false;
        }

        void UpdatePowerLists()
        {
            bool noPrimary = false;
            if (this.llPrimary.Items.Length == 0)
                noPrimary = true;
            else if (this.llPrimary.Items[this.llPrimary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[0].nID)
                noPrimary = true;
            if (this.llSecondary.Items.Length == 0)
                noPrimary = true;
            else if (this.llSecondary.Items[this.llSecondary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[1].nID)
                noPrimary = true;
            bool noAncillary = false;
            if (this.llAncillary.Items.Length == 0 || MidsContext.Character.Powersets[7] == null)
                noAncillary = true;
            else if (this.llAncillary.Items[this.llAncillary.Items.Length - 1].nIDSet != MidsContext.Character.Powersets[7].nID)
                noAncillary = true;
            if (noPrimary)
            {
                ListLabelV2 llPrimary = this.llPrimary;
                this.AssemblePowerList(llPrimary, MidsContext.Character.Powersets[0]);
                this.llPrimary = llPrimary;
                this.AssemblePowerList(this.llSecondary, MidsContext.Character.Powersets[1]);
            }
            else
            {
                this.UpdatePowerList(this.llPrimary);
                this.UpdatePowerList(this.llSecondary);
            }
            if (noAncillary | noPrimary)
            {
                this.AssemblePowerList(this.llAncillary, MidsContext.Character.Powersets[7]);
                this.UpdatePowerList(this.llAncillary);
            }
            else
            {
                this.UpdatePowerList(this.llAncillary);
            }
            this.AssemblePowerList(this.llPool0, MidsContext.Character.Powersets[3]);
            this.AssemblePowerList(this.llPool1, MidsContext.Character.Powersets[4]);
            this.AssemblePowerList(this.llPool2, MidsContext.Character.Powersets[5]);
            this.AssemblePowerList(this.llPool3, MidsContext.Character.Powersets[6]);
            this.UpdatePowerList(this.llPool0);
            this.UpdatePowerList(this.llPool1);
            this.UpdatePowerList(this.llPool2);
            this.UpdatePowerList(this.llPool3);
        }

        void GameImport(string buildString)
        {
            string str1 = string.Empty;
            try
            {
                if (buildString.Contains("build.txt"))
                {
                    str1 = buildString + " is an invalid file name";
                    StreamReader streamReader = new StreamReader(buildString);
                    buildString = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                buildString = buildString.Replace("Level ", string.Empty);
                string[] strArray1 = buildString.Split('\r');
                string[] strArray2 = strArray1[0].Split(':');
                string[] strArray3 = strArray2[1].Split(' ');
                var atName = strArray3[3].Split('_')[1];
                MidsContext.Character.Archetype = DatabaseAPI.GetArchetypeByName(atName);
                MidsContext.Character.Origin = DatabaseAPI.GetOriginByName(MidsContext.Character.Archetype, strArray3[2]);
                MidsContext.Character.Reset(MidsContext.Character.Archetype, MidsContext.Character.Origin);
                MidsContext.Character.Name = strArray2[0];
                int num1 = 0;
                int num2 = 0;
                string str2 = string.Empty;
                var stringList = new List<string>();
                var buildFileLinesArray = new frmMain.BuildFileLines[200];
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
                MidsContext.Character.LoadPowersetsByName2(stringList, ref str1);

                //if (stringList.Count > MidsContext.Character.Powersets.Length + 1)
                //    MidsContext.Character.Powersets = new IPowerset[stringList.Count];
                //IPowerset powersetByName1 = DatabaseAPI.GetPowersetByName(stringList[0]);
                //if (powersetByName1 == null)
                //    str1 = stringList[0];
                //MidsContext.Character.Powersets[0] = powersetByName1;
                //IPowerset powersetByName2 = DatabaseAPI.GetPowersetByName(stringList[1]);
                //if (powersetByName2 == null)
                //    str1 = stringList[1];
                //MidsContext.Character.Powersets[1] = powersetByName2;
                //for (int index = 2; index < stringList.Count; ++index)
                //{
                //    IPowerset powersetByName3 = DatabaseAPI.GetPowersetByName(stringList[index]);
                //    if (powersetByName3 == null)
                //        str1 = stringList[index];
                //    MidsContext.Character.Powersets[index + 1] = powersetByName3;
                //}
                MidsContext.Character.CurrentBuild.LastPower = 24;
                int index3 = 0;
                List<PowerEntry> listPowerEntry = new List<PowerEntry>();
                for (int index1 = 0; index1 < num2; ++index1)
                {
                    str1 = buildFileLinesArray[index3].powerName;
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
                                            int num3 = (int)MessageBox.Show(("Error with: " + str1), null, MessageBoxButtons.OK);
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
                MidsContext.Character.PoolShuffle();
                I9Gfx.OriginIndex = MidsContext.Character.Origin;
                MidsContext.Character.Validate();
            }
            catch
            {
                MessageBox.Show(("Invalid Import Data, Blame Sai!\nError: " + str1), null, MessageBoxButtons.OK);
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
