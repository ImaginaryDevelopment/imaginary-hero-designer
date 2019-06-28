using midsControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
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
            this.i9Picker = new I9Picker();
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

            this.txtName.Location = new Point(96, 82);
            this.txtName.Name = "txtName";

            this.txtName.Size = new Size(142, 20);
            this.txtName.TabIndex = 1;
            this.cbAT.BackColor = Color.WhiteSmoke;
            this.cbAT.DisplayMember = "DisplayName";
            this.cbAT.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbAT.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbAT.ForeColor = SystemColors.ControlText;
            this.cbAT.ItemHeight = 16;

            this.cbAT.Location = new Point(94, 109);
            this.cbAT.MaxDropDownItems = 15;
            this.cbAT.Name = "cbAT";

            this.cbAT.Size = new Size(144, 22);
            this.cbAT.TabIndex = 3;
            this.cbAT.ValueMember = "Idx";
            this.cbOrigin.BackColor = Color.WhiteSmoke;
            this.cbOrigin.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbOrigin.ForeColor = SystemColors.ControlText;
            this.cbOrigin.ItemHeight = 16;

            this.cbOrigin.Location = new Point(94, 133);
            this.cbOrigin.Name = "cbOrigin";

            this.cbOrigin.Size = new Size(144, 22);
            this.cbOrigin.TabIndex = 5;
            this.cbPrimary.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPrimary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPrimary.ForeColor = SystemColors.ControlText;
            this.cbPrimary.ItemHeight = 16;

            this.cbPrimary.Location = new Point(16, 182);
            this.cbPrimary.MaxDropDownItems = 15;
            this.cbPrimary.Name = "cbPrimary";

            this.cbPrimary.Size = new Size(144, 22);
            this.cbPrimary.TabIndex = 7;
            this.lblPrimary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPrimary.ForeColor = Color.White;

            this.lblPrimary.Location = new Point(20, 166);
            this.lblPrimary.Name = "lblPrimary";

            this.lblPrimary.Size = new Size(136, 17);
            this.lblPrimary.TabIndex = 9;
            this.lblPrimary.Text = "Primary Power Set";
            this.lblPrimary.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSecondary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblSecondary.ForeColor = Color.White;

            this.lblSecondary.Location = new Point(172, 166);
            this.lblSecondary.Name = "lblSecondary";

            this.lblSecondary.Size = new Size(136, 17);
            this.lblSecondary.TabIndex = 10;
            this.lblSecondary.Text = "Secondary Power Set";
            this.lblSecondary.TextAlign = ContentAlignment.MiddleCenter;
            this.cbSecondary.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbSecondary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSecondary.ForeColor = SystemColors.ControlText;
            this.cbSecondary.ItemHeight = 16;

            this.cbSecondary.Location = new Point(168, 182);
            this.cbSecondary.MaxDropDownItems = 15;
            this.cbSecondary.Name = "cbSecondary";

            this.cbSecondary.Size = new Size(144, 22);
            this.cbSecondary.TabIndex = 11;
            this.cbPool0.BackColor = Color.WhiteSmoke;
            this.cbPool0.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool0.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool0.ForeColor = SystemColors.ControlText;
            this.cbPool0.ItemHeight = 16;

            this.cbPool0.Location = new Point(328, 182);
            this.cbPool0.MaxDropDownItems = 15;
            this.cbPool0.Name = "cbPool0";

            this.cbPool0.Size = new Size(136, 22);
            this.cbPool0.TabIndex = 15;
            this.lblPool1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool1.ForeColor = Color.White;

            this.lblPool1.Location = new Point(328, 166);
            this.lblPool1.Name = "lblPool1";

            this.lblPool1.Size = new Size(136, 17);
            this.lblPool1.TabIndex = 14;
            this.lblPool1.Text = "Pool 1";
            this.lblPool1.TextAlign = ContentAlignment.MiddleCenter;
            this.cbPool1.BackColor = Color.WhiteSmoke;
            this.cbPool1.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool1.ForeColor = SystemColors.ControlText;
            this.cbPool1.ItemHeight = 16;

            this.cbPool1.Location = new Point(328, 290);
            this.cbPool1.MaxDropDownItems = 15;
            this.cbPool1.Name = "cbPool1";

            this.cbPool1.Size = new Size(136, 22);
            this.cbPool1.TabIndex = 18;
            this.lblPool2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool2.ForeColor = Color.White;

            this.lblPool2.Location = new Point(328, 274);
            this.lblPool2.Name = "lblPool2";

            this.lblPool2.Size = new Size(136, 17);
            this.lblPool2.TabIndex = 17;
            this.lblPool2.Text = "Pool 2";
            this.lblPool2.TextAlign = ContentAlignment.MiddleCenter;
            this.cbPool2.BackColor = Color.WhiteSmoke;
            this.cbPool2.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool2.ForeColor = SystemColors.ControlText;
            this.cbPool2.ItemHeight = 16;

            this.cbPool2.Location = new Point(328, 398);
            this.cbPool2.MaxDropDownItems = 15;
            this.cbPool2.Name = "cbPool2";

            this.cbPool2.Size = new Size(136, 22);
            this.cbPool2.TabIndex = 21;
            this.lblPool3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool3.ForeColor = Color.White;

            this.lblPool3.Location = new Point(328, 382);
            this.lblPool3.Name = "lblPool3";

            this.lblPool3.Size = new Size(136, 17);
            this.lblPool3.TabIndex = 20;
            this.lblPool3.Text = "Pool 3";
            this.lblPool3.TextAlign = ContentAlignment.MiddleCenter;
            this.cbPool3.BackColor = Color.WhiteSmoke;
            this.cbPool3.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbPool3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbPool3.ForeColor = SystemColors.ControlText;
            this.cbPool3.ItemHeight = 16;

            this.cbPool3.Location = new Point(328, 506);
            this.cbPool3.MaxDropDownItems = 15;
            this.cbPool3.Name = "cbPool3";

            this.cbPool3.Size = new Size(136, 22);
            this.cbPool3.TabIndex = 24;
            this.lblPool4.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblPool4.ForeColor = Color.White;

            this.lblPool4.Location = new Point(328, 490);
            this.lblPool4.Name = "lblPool4";

            this.lblPool4.Size = new Size(136, 17);
            this.lblPool4.TabIndex = 23;
            this.lblPool4.Text = "Pool 4";
            this.lblPool4.TextAlign = ContentAlignment.MiddleCenter;
            this.cbAncillary.BackColor = Color.WhiteSmoke;
            this.cbAncillary.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbAncillary.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbAncillary.ForeColor = SystemColors.ControlText;
            this.cbAncillary.ItemHeight = 16;

            this.cbAncillary.Location = new Point(328, 614);
            this.cbAncillary.Name = "cbAncillary";

            this.cbAncillary.Size = new Size(136, 22);
            this.cbAncillary.TabIndex = 27;
            this.lblEpic.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblEpic.ForeColor = Color.White;

            this.lblEpic.Location = new Point(328, 598);
            this.lblEpic.Name = "lblEpic";

            this.lblEpic.Size = new Size(136, 17);
            this.lblEpic.TabIndex = 26;
            this.lblEpic.Text = "Ancillary/Epic Pool";
            this.lblEpic.TextAlign = ContentAlignment.MiddleCenter;
            this.lblATLocked.BackColor = Color.FromArgb(224, 224, 224);
            this.lblATLocked.BorderStyle = BorderStyle.Fixed3D;
            this.lblATLocked.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblATLocked.ForeColor = Color.Black;

            this.lblATLocked.Location = new Point(94, 113);
            this.lblATLocked.Name = "lblATLocked";

            this.lblATLocked.Size = new Size(92, 29);
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

            this.lblLocked0.Location = new Point(308, 166);
            this.lblLocked0.Name = "lblLocked0";

            this.lblLocked0.Size = new Size(92, 29);
            this.lblLocked0.TabIndex = 72;
            this.lblLocked0.Text = "Pool Locked";
            this.lblLocked0.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLocked1.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked1.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked1.ForeColor = Color.Black;

            this.lblLocked1.Location = new Point(308, 186);
            this.lblLocked1.Name = "lblLocked1";

            this.lblLocked1.Size = new Size(92, 29);
            this.lblLocked1.TabIndex = 73;
            this.lblLocked1.Text = "Pool Locked";
            this.lblLocked1.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLocked2.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked2.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked2.ForeColor = Color.Black;

            this.lblLocked2.Location = new Point(304, 194);
            this.lblLocked2.Name = "lblLocked2";

            this.lblLocked2.Size = new Size(92, 29);
            this.lblLocked2.TabIndex = 74;
            this.lblLocked2.Text = "Pool Locked";
            this.lblLocked2.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLocked3.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLocked3.BorderStyle = BorderStyle.Fixed3D;
            this.lblLocked3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLocked3.ForeColor = Color.Black;

            this.lblLocked3.Location = new Point(284, 210);
            this.lblLocked3.Name = "lblLocked3";

            this.lblLocked3.Size = new Size(92, 29);
            this.lblLocked3.TabIndex = 75;
            this.lblLocked3.Text = "Pool Locked";
            this.lblLocked3.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLockedAncillary.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLockedAncillary.BorderStyle = BorderStyle.Fixed3D;
            this.lblLockedAncillary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLockedAncillary.ForeColor = Color.Black;

            this.lblLockedAncillary.Location = new Point(268, 230);
            this.lblLockedAncillary.Name = "lblLockedAncillary";

            this.lblLockedAncillary.Size = new Size(92, 29);
            this.lblLockedAncillary.TabIndex = 76;
            this.lblLockedAncillary.Text = "Pool Locked";
            this.lblLockedAncillary.TextAlign = ContentAlignment.MiddleCenter;
            this.lblLockedSecondary.BackColor = Color.FromArgb(224, 224, 224);
            this.lblLockedSecondary.BorderStyle = BorderStyle.Fixed3D;
            this.lblLockedSecondary.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblLockedSecondary.ForeColor = Color.Black;

            this.lblLockedSecondary.Location = new Point(257, 246);
            this.lblLockedSecondary.Name = "lblLockedSecondary";

            this.lblLockedSecondary.Size = new Size(92, 29);
            this.lblLockedSecondary.TabIndex = 109;
            this.lblLockedSecondary.Text = "Sec. Locked";
            this.lblLockedSecondary.TextAlign = ContentAlignment.MiddleCenter;
            this.MenuBar.BackColor = SystemColors.Control;
            this.MenuBar.Items.AddRange(new ToolStripItem[7]
            {
            (ToolStripItem) this.FileToolStripMenuItem,
            (ToolStripItem) this.ImportExportToolStripMenuItem,
            (ToolStripItem) this.OptionsToolStripMenuItem,
            (ToolStripItem) this.CharacterToolStripMenuItem,
            (ToolStripItem) this.ViewToolStripMenuItem,
            (ToolStripItem) this.HelpToolStripMenuItem1,
            (ToolStripItem) this.WindowToolStripMenuItem
            });

            this.MenuBar.Location = new Point(0, 0);
            this.MenuBar.Name = "MenuBar";

            this.MenuBar.Size = new Size(1056, 24);
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

            this.FileToolStripMenuItem.Size = new Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            this.tsFileNew.Name = "tsFileNew";
            this.tsFileNew.ShortcutKeys = System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control;

            this.tsFileNew.Size = new Size(179, 22);
            this.tsFileNew.Text = "&New / Clear";
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";

            this.ToolStripSeparator7.Size = new Size(176, 6);
            this.tsFileOpen.Name = "tsFileOpen";
            this.tsFileOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;

            this.tsFileOpen.Size = new Size(179, 22);
            this.tsFileOpen.Text = "&Open...";
            this.tsFileSave.Name = "tsFileSave";
            this.tsFileSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;

            this.tsFileSave.Size = new Size(179, 22);
            this.tsFileSave.Text = "&Save";
            this.tsFileSaveAs.Name = "tsFileSaveAs";

            this.tsFileSaveAs.Size = new Size(179, 22);
            this.tsFileSaveAs.Text = "Save &As...";
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";

            this.ToolStripSeparator8.Size = new Size(176, 6);
            this.tsFilePrint.Name = "tsFilePrint";
            this.tsFilePrint.ShortcutKeys = System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control;

            this.tsFilePrint.Size = new Size(179, 22);
            this.tsFilePrint.Text = "&Print...";
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";

            this.ToolStripSeparator9.Size = new Size(176, 6);
            this.tsFileQuit.Name = "tsFileQuit";
            this.tsFileQuit.ShortcutKeys = System.Windows.Forms.Keys.Q | System.Windows.Forms.Keys.Control;

            this.tsFileQuit.Size = new Size(179, 22);
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

            this.ImportExportToolStripMenuItem.Size = new Size(99, 20);
            this.ImportExportToolStripMenuItem.Text = "&Import / Export";
            this.tsImport.Name = "tsImport";
            this.tsImport.ShortcutKeys = System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control;

            this.tsImport.Size = new Size(240, 22);
            this.tsImport.Text = "&Import from Forum Post";
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";

            this.ToolStripSeparator12.Size = new Size(237, 6);
            this.tsExport.Name = "tsExport";

            this.tsExport.Size = new Size(240, 22);
            this.tsExport.Text = "&Short Forum Export...";
            this.tsExportLong.Name = "tsExportLong";

            this.tsExportLong.Size = new Size(240, 22);
            this.tsExportLong.Text = "&Long Forum Export...";
            this.tsExportDataLink.Name = "tsExportDataLink";

            this.tsExportDataLink.Size = new Size(240, 22);
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

            this.OptionsToolStripMenuItem.Size = new Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "&Options";
            this.tsConfig.Name = "tsConfig";

            this.tsConfig.Size = new Size(199, 22);
            this.tsConfig.Text = "&Configuration...";
            this.ToolStripSeparator14.Name = "ToolStripSeparator14";

            this.ToolStripSeparator14.Size = new Size(196, 6);
            this.tsUpdateCheck.Name = "tsUpdateCheck";

            this.tsUpdateCheck.Size = new Size(199, 22);
            this.tsUpdateCheck.Text = "Check for &Updates Now";
            this.ToolStripSeparator22.Name = "ToolStripSeparator22";

            this.ToolStripSeparator22.Size = new Size(196, 6);
            this.tsLevelUp.Name = "tsLevelUp";

            this.tsLevelUp.Size = new Size(199, 22);
            this.tsLevelUp.Text = "&Level-Up Mode";
            this.tsLevelUp.ToolTipText = "Alternate between placing powers and slots, just like levelling up in-game.";
            this.tsDynamic.Name = "tsDynamic";

            this.tsDynamic.Size = new Size(199, 22);
            this.tsDynamic.Text = "&Dynamic Mode";
            this.tsDynamic.ToolTipText = "Place powers and slots in any order.";
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";

            this.ToolStripSeparator5.Size = new Size(196, 6);
            this.AdvancedToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[4]
            {
            (ToolStripItem) this.tsAdvDBEdit,
            (ToolStripItem) this.ToolStripSeparator15,
            (ToolStripItem) this.tsAdvFreshInstall,
            (ToolStripItem) this.tsAdvResetTips
            });
            this.AdvancedToolStripMenuItem1.Name = "AdvancedToolStripMenuItem1";

            this.AdvancedToolStripMenuItem1.Size = new Size(199, 22);
            this.AdvancedToolStripMenuItem1.Text = "&Advanced";
            this.tsAdvDBEdit.Name = "tsAdvDBEdit";

            this.tsAdvDBEdit.Size = new Size(165, 22);
            this.tsAdvDBEdit.Text = "&Database Editor...";
            this.ToolStripSeparator15.Name = "ToolStripSeparator15";

            this.ToolStripSeparator15.Size = new Size(162, 6);
            this.tsAdvFreshInstall.Name = "tsAdvFreshInstall";

            this.tsAdvFreshInstall.Size = new Size(165, 22);
            this.tsAdvFreshInstall.Text = "FreshInstall Flag";
            this.tsAdvFreshInstall.Visible = false;
            this.tsAdvResetTips.Name = "tsAdvResetTips";

            this.tsAdvResetTips.Size = new Size(165, 22);
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

            this.CharacterToolStripMenuItem.Size = new Size(133, 20);
            this.CharacterToolStripMenuItem.Text = "&Slots / Enhancements";
            this.SetAllIOsToDefault35ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
            {
            (ToolStripItem) this.tsIODefault,
            (ToolStripItem) this.ToolStripSeparator11,
            (ToolStripItem) this.tsIOMin,
            (ToolStripItem) this.tsIOMax
            });
            this.SetAllIOsToDefault35ToolStripMenuItem.Name = "SetAllIOsToDefault35ToolStripMenuItem";

            this.SetAllIOsToDefault35ToolStripMenuItem.Size = new Size(245, 22);
            this.SetAllIOsToDefault35ToolStripMenuItem.Text = "&Set all IOs to...";
            this.tsIODefault.Name = "tsIODefault";

            this.tsIODefault.Size = new Size(135, 22);
            this.tsIODefault.Text = "Default (35)";
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";

            this.ToolStripSeparator11.Size = new Size(132, 6);
            this.tsIOMin.Name = "tsIOMin";

            this.tsIOMin.Size = new Size(135, 22);
            this.tsIOMin.Text = "Minimum";
            this.tsIOMax.Name = "tsIOMax";

            this.tsIOMax.Size = new Size(135, 22);
            this.tsIOMax.Text = "Maximum";
            this.ToolStripSeparator16.Name = "ToolStripSeparator16";

            this.ToolStripSeparator16.Size = new Size(242, 6);
            this.ToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[3]
            {
            (ToolStripItem) this.tsEnhToSO,
            (ToolStripItem) this.tsEnhToDO,
            (ToolStripItem) this.tsEnhToTO
            });
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";

            this.ToolStripMenuItem1.Size = new Size(245, 22);
            this.ToolStripMenuItem1.Text = "Set all Enhancement &Origins to...";
            this.tsEnhToSO.Name = "tsEnhToSO";

            this.tsEnhToSO.Size = new Size(142, 22);
            this.tsEnhToSO.Text = "Single Origin";
            this.tsEnhToDO.Name = "tsEnhToDO";

            this.tsEnhToDO.Size = new Size(142, 22);
            this.tsEnhToDO.Text = "Dual Origin";
            this.tsEnhToTO.Name = "tsEnhToTO";

            this.tsEnhToTO.Size = new Size(142, 22);
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

            this.ToolStripMenuItem2.Size = new Size(245, 22);
            this.ToolStripMenuItem2.Text = "Set all &Relative Levels to...";
            this.tsEnhToPlus5.Name = "tsEnhToPlus5";

            this.tsEnhToPlus5.Size = new Size(205, 22);
            this.tsEnhToPlus5.Text = "+5 Levels";
            this.tsEnhToPlus4.Name = "tsEnhToPlus4";

            this.tsEnhToPlus4.Size = new Size(205, 22);
            this.tsEnhToPlus4.Text = "+4 Levels";
            this.tsEnhToPlus3.Name = "tsEnhToPlus3";

            this.tsEnhToPlus3.Size = new Size(205, 22);
            this.tsEnhToPlus3.Text = "+3 Levels";
            this.tsEnhToPlus2.Name = "tsEnhToPlus2";

            this.tsEnhToPlus2.Size = new Size(205, 22);
            this.tsEnhToPlus2.Text = "+2 Levels";
            this.tsEnhToPlus1.Name = "tsEnhToPlus1";

            this.tsEnhToPlus1.Size = new Size(205, 22);
            this.tsEnhToPlus1.Text = "+1 Level";
            this.tsEnhToEven.Name = "tsEnhToEven";

            this.tsEnhToEven.Size = new Size(205, 22);
            this.tsEnhToEven.Text = "Even Level";
            this.tsEnhToMinus1.Name = "tsEnhToMinus1";

            this.tsEnhToMinus1.Size = new Size(205, 22);
            this.tsEnhToMinus1.Text = "-1 Level";
            this.tsEnhToMinus2.Name = "tsEnhToMinus2";

            this.tsEnhToMinus2.Size = new Size(205, 22);
            this.tsEnhToMinus2.Text = "-2 Levels";
            this.tsEnhToMinus3.Name = "tsEnhToMinus3";

            this.tsEnhToMinus3.Size = new Size(205, 22);
            this.tsEnhToMinus3.Text = "-3 Levels";
            this.tsEnhToNone.Name = "tsEnhToNone";

            this.tsEnhToNone.Size = new Size(205, 22);
            this.tsEnhToNone.Text = "None (Enh has no effect)";
            this.ToolStripSeparator17.Name = "ToolStripSeparator17";

            this.ToolStripSeparator17.Size = new Size(242, 6);
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

            this.SlotsToolStripMenuItem.Size = new Size(245, 22);
            this.SlotsToolStripMenuItem.Text = "Slo&ts";
            this.tsFlipAllEnh.Name = "tsFlipAllEnh";

            this.tsFlipAllEnh.Size = new Size(199, 22);
            this.tsFlipAllEnh.Text = "Flip All to Alternate";
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";

            this.ToolStripSeparator4.Size = new Size(196, 6);
            this.tsClearAllEnh.Name = "tsClearAllEnh";

            this.tsClearAllEnh.Size = new Size(199, 22);
            this.tsClearAllEnh.Text = "Clear All Enhancements";
            this.tsRemoveAllSlots.Name = "tsRemoveAllSlots";

            this.tsRemoveAllSlots.Size = new Size(199, 22);
            this.tsRemoveAllSlots.Text = "Remove All Slots";
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";

            this.ToolStripSeparator1.Size = new Size(196, 6);
            this.AutoArrangeAllSlotsToolStripMenuItem.Name = "AutoArrangeAllSlotsToolStripMenuItem";

            this.AutoArrangeAllSlotsToolStripMenuItem.Size = new Size(199, 22);
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

            this.ViewToolStripMenuItem.Size = new Size(44, 20);
            this.ViewToolStripMenuItem.Text = "&View";
            this.tsView4Col.Name = "tsView4Col";

            this.tsView4Col.Size = new Size(282, 22);
            this.tsView4Col.Text = "&4 Columns";
            this.tsView3Col.Checked = true;
            this.tsView3Col.CheckState = CheckState.Checked;
            this.tsView3Col.Name = "tsView3Col";

            this.tsView3Col.Size = new Size(282, 22);
            this.tsView3Col.Text = "&3 Columns";
            this.tsView2Col.Name = "tsView2Col";

            this.tsView2Col.Size = new Size(282, 22);
            this.tsView2Col.Text = "&2 Columns";
            this.ToolStripSeparator13.Name = "ToolStripSeparator13";

            this.ToolStripSeparator13.Size = new Size(279, 6);
            this.tsViewIOLevels.Checked = true;
            this.tsViewIOLevels.CheckState = CheckState.Checked;
            this.tsViewIOLevels.Name = "tsViewIOLevels";

            this.tsViewIOLevels.Size = new Size(282, 22);
            this.tsViewIOLevels.Text = "Show &IO Levels";
            this.tsViewRelative.Name = "tsViewRelative";

            this.tsViewRelative.Size = new Size(282, 22);
            this.tsViewRelative.Text = "Show &Enhancement Relative Levels";
            this.tsViewSlotLevels.Name = "tsViewSlotLevels";

            this.tsViewSlotLevels.Size = new Size(282, 22);
            this.tsViewSlotLevels.Text = "Show &Slot Placement Levels";
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";

            this.ToolStripSeparator2.Size = new Size(279, 6);
            this.tsViewActualDamage_New.Checked = true;
            this.tsViewActualDamage_New.CheckState = CheckState.Checked;
            this.tsViewActualDamage_New.Name = "tsViewActualDamage_New";

            this.tsViewActualDamage_New.Size = new Size(282, 22);
            this.tsViewActualDamage_New.Text = "Show Damage Per Activation (Level 50)";
            this.tsViewDPS_New.Name = "tsViewDPS_New";

            this.tsViewDPS_New.Size = new Size(282, 22);
            this.tsViewDPS_New.Text = "Show Damage Per Second (Level 50)";
            this.tlsDPA.Name = "tlsDPA";

            this.tlsDPA.Size = new Size(282, 22);
            this.tlsDPA.Text = "Show Damage Per Animation (Level 50)";
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

            this.HelpToolStripMenuItem1.Size = new Size(102, 20);
            this.HelpToolStripMenuItem1.Text = "&Help && Support";
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;

            this.tsHelp.Size = new Size(258, 22);
            this.tsHelp.Text = "&Read Me - Instructions";
            this.tsPatchNotes.Name = "tsPatchNotes";

            this.tsPatchNotes.Size = new Size(258, 22);
            this.tsPatchNotes.Text = "Read &Latest Patch Notes...";
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";

            this.ToolStripSeparator10.Size = new Size((int)byte.MaxValue, 6);
            this.tsBug.Name = "tsBug";

            this.tsBug.Size = new Size(258, 22);
            this.tsBug.Text = "Feedback Form / &Bug Report";
            this.tsBug.Visible = false;
            this.tsTitanForum.Name = "tsTitanForum";

            this.tsTitanForum.Size = new Size(258, 22);
            this.tsTitanForum.Text = "Go to Support / Discussion &Forums";
            this.ToolStripSeparator23.Name = "ToolStripSeparator23";

            this.ToolStripSeparator23.Size = new Size((int)byte.MaxValue, 6);
            this.tsDonate.Name = "tsDonate";

            this.tsDonate.Size = new Size(258, 22);
            this.tsDonate.Text = "Make a Donation (PayPal)";
            this.ToolStripSeparator24.Name = "ToolStripSeparator24";

            this.ToolStripSeparator24.Size = new Size((int)byte.MaxValue, 6);
            this.tsTitanPlanner.Name = "tsTitanPlanner";

            this.tsTitanPlanner.Size = new Size(258, 22);
            this.tsTitanPlanner.Text = "CoH &Planner Website";
            this.tsTitanSite.Name = "tsTitanSite";

            this.tsTitanSite.Size = new Size(258, 22);
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

            this.WindowToolStripMenuItem.Size = new Size(63, 20);
            this.WindowToolStripMenuItem.Text = "&Window";
            this.tsViewSets.Name = "tsViewSets";
            this.tsViewSets.ShortcutKeys = System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Control;

            this.tsViewSets.Size = new Size(232, 22);
            this.tsViewSets.Text = "&Sets && Bonuses";
            this.tsViewGraphs.Name = "tsViewGraphs";
            this.tsViewGraphs.ShortcutKeys = System.Windows.Forms.Keys.G | System.Windows.Forms.Keys.Control;

            this.tsViewGraphs.Size = new Size(232, 22);
            this.tsViewGraphs.Text = "Power &Graphs";
            this.tsViewSetCompare.Name = "tsViewSetCompare";
            this.tsViewSetCompare.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;

            this.tsViewSetCompare.Size = new Size(232, 22);
            this.tsViewSetCompare.Text = "Powerset &Comparison";
            this.tsViewData.Name = "tsViewData";
            this.tsViewData.ShortcutKeys = System.Windows.Forms.Keys.D | System.Windows.Forms.Keys.Control;

            this.tsViewData.Size = new Size(232, 22);
            this.tsViewData.Text = "&Data View";
            this.tsViewTotals.Name = "tsViewTotals";
            this.tsViewTotals.ShortcutKeys = System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control;

            this.tsViewTotals.Size = new Size(232, 22);
            this.tsViewTotals.Text = "Advanced &Totals";
            this.ToolStripSeparator18.Name = "ToolStripSeparator18";

            this.ToolStripSeparator18.Size = new Size(229, 6);
            this.tsRecipeViewer.Name = "tsRecipeViewer";
            this.tsRecipeViewer.ShortcutKeys = System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control;

            this.tsRecipeViewer.Size = new Size(232, 22);
            this.tsRecipeViewer.Text = "&Recipe Viewer";
            this.tsDPSCalc.Name = "tsDPSCalc";
            this.tsDPSCalc.ShortcutKeys = System.Windows.Forms.Keys.Z | System.Windows.Forms.Keys.Control;

            this.tsDPSCalc.Size = new Size(232, 22);
            this.tsDPSCalc.Text = "DPS Calculator (Beta)";
            this.ToolStripSeparator19.Name = "ToolStripSeparator19";

            this.ToolStripSeparator19.Size = new Size(229, 6);
            this.tsSetFind.Name = "tsSetFind";

            this.tsSetFind.Size = new Size(232, 22);
            this.tsSetFind.Text = "Set &Bonus Finder";
            this.ToolStripSeparator21.Name = "ToolStripSeparator21";

            this.ToolStripSeparator21.Size = new Size(229, 6);
            this.InGameRespecHelperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
            {
            (ToolStripItem) this.tsHelperShort,
            (ToolStripItem) this.tsHelperLong,
            (ToolStripItem) this.ToolStripSeparator20,
            (ToolStripItem) this.tsHelperShort2,
            (ToolStripItem) this.tsHelperLong2
            });
            this.InGameRespecHelperToolStripMenuItem.Name = "InGameRespecHelperToolStripMenuItem";

            this.InGameRespecHelperToolStripMenuItem.Size = new Size(232, 22);
            this.InGameRespecHelperToolStripMenuItem.Text = "In-Game &Respec Helper";
            this.tsHelperShort.Name = "tsHelperShort";

            this.tsHelperShort.Size = new Size(143, 22);
            this.tsHelperShort.Text = "Profile &Short";
            this.tsHelperLong.Name = "tsHelperLong";

            this.tsHelperLong.Size = new Size(143, 22);
            this.tsHelperLong.Text = "Profile &Long";
            this.ToolStripSeparator20.Name = "ToolStripSeparator20";

            this.ToolStripSeparator20.Size = new Size(140, 6);
            this.tsHelperShort2.Name = "tsHelperShort2";

            this.tsHelperShort2.Size = new Size(143, 22);
            this.tsHelperShort2.Text = "History S&hort";
            this.tsHelperLong2.Name = "tsHelperLong2";

            this.tsHelperLong2.Size = new Size(143, 22);
            this.tsHelperLong2.Text = "History L&ong";
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";

            this.ToolStripMenuItem4.Size = new Size(229, 6);
            this.AccoladesWindowToolStripMenuItem.Name = "AccoladesWindowToolStripMenuItem";

            this.AccoladesWindowToolStripMenuItem.Size = new Size(232, 22);
            this.AccoladesWindowToolStripMenuItem.Text = "&Accolades Window";
            this.IncarnateWindowToolStripMenuItem.Name = "IncarnateWindowToolStripMenuItem";

            this.IncarnateWindowToolStripMenuItem.Size = new Size(232, 22);
            this.IncarnateWindowToolStripMenuItem.Text = "&Incarnate Window";
            this.TemporaryPowersWindowToolStripMenuItem.Name = "TemporaryPowersWindowToolStripMenuItem";

            this.TemporaryPowersWindowToolStripMenuItem.Size = new Size(232, 22);
            this.TemporaryPowersWindowToolStripMenuItem.Text = "T&emporary Powers Window";

            this.pbDynMode.Location = new Point(355, 80);
            this.pbDynMode.Name = "pbDynMode";

            this.pbDynMode.Size = new Size(105, 22);
            this.pbDynMode.TabIndex = 92;
            this.pbDynMode.TabStop = false;
            this.pnlGFX.BackColor = Color.Black;

            this.pnlGFX.Location = new Point(3, 3);
            this.pnlGFX.Name = "pnlGFX";

            this.pnlGFX.Size = new Size(584, 709);
            this.pnlGFX.TabIndex = 103;
            this.pnlGFX.TabStop = false;
            this.pnlGFXFlow.AutoScroll = true;
            this.pnlGFXFlow.Controls.Add((Control)this.pnlGFX);

            this.pnlGFXFlow.Location = new Point(472, 78);
            this.pnlGFXFlow.Name = "pnlGFXFlow";

            this.pnlGFXFlow.Size = new Size(584, 629);
            this.pnlGFXFlow.TabIndex = 112;
            this.llAncillary.Expandable = false;
            this.llAncillary.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.llAncillary.HighVis = true;
            this.llAncillary.HoverColor = Color.WhiteSmoke;

            this.llAncillary.Location = new Point(328, 638);
            this.llAncillary.MaxHeight = 500;
            this.llAncillary.Name = "llAncillary";
            this.llAncillary.PaddingX = 2;
            this.llAncillary.PaddingY = 2;
            this.llAncillary.Scrollable = true;
            this.llAncillary.ScrollBarColor = Color.Red;
            this.llAncillary.ScrollBarWidth = 11;
            this.llAncillary.ScrollButtonColor = Color.FromArgb(192, 0, 0);

            this.llAncillary.Size = new Size(138, 69);

            this.llAncillary.SizeNormal = new Size(138, 69);
            this.llAncillary.SuspendRedraw = false;
            this.llAncillary.TabIndex = 110;
            this.lblName.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblName.ForeColor = Color.White;
            this.lblName.InitialText = "Name:";

            this.lblName.Location = new Point(4, 82);
            this.lblName.Name = "lblName";

            this.lblName.Size = new Size(92, 21);
            this.lblName.TabIndex = 44;
            this.lblName.TextAlign = ContentAlignment.MiddleRight;
            this.lblOrigin.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblOrigin.InitialText = "Origin:";

            this.lblOrigin.Location = new Point(2, 133);
            this.lblOrigin.Name = "lblOrigin";

            this.lblOrigin.Size = new Size(92, 21);
            this.lblOrigin.TabIndex = 46;
            this.lblOrigin.TextAlign = ContentAlignment.MiddleRight;
            this.lblAT.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblAT.InitialText = "Archetype:";

            this.lblAT.Location = new Point(2, 109);
            this.lblAT.Name = "lblAT";

            this.lblAT.Size = new Size(92, 21);
            this.lblAT.TabIndex = 45;
            this.lblAT.TextAlign = ContentAlignment.MiddleRight;
            this.llPool0.Expandable = false;
            this.llPool0.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool0.HighVis = true;
            this.llPool0.HoverColor = Color.WhiteSmoke;

            this.llPool0.Location = new Point(328, 206);
            this.llPool0.MaxHeight = 500;
            this.llPool0.Name = "llPool0";
            this.llPool0.PaddingX = 2;
            this.llPool0.PaddingY = 2;
            this.llPool0.Scrollable = true;
            this.llPool0.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool0.ScrollBarWidth = 11;
            this.llPool0.ScrollButtonColor = Color.FromArgb(96, 0, 192);

            this.llPool0.Size = new Size(136, 69);

            this.llPool0.SizeNormal = new Size(136, 69);
            this.llPool0.SuspendRedraw = false;
            this.llPool0.TabIndex = 34;
            this.llPool1.Expandable = false;
            this.llPool1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool1.ForeColor = Color.Yellow;
            this.llPool1.HighVis = true;
            this.llPool1.HoverColor = Color.WhiteSmoke;

            this.llPool1.Location = new Point(328, 314);
            this.llPool1.MaxHeight = 500;
            this.llPool1.Name = "llPool1";
            this.llPool1.PaddingX = 2;
            this.llPool1.PaddingY = 2;
            this.llPool1.Scrollable = true;
            this.llPool1.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool1.ScrollBarWidth = 8;
            this.llPool1.ScrollButtonColor = Color.FromArgb(96, 0, 192);

            this.llPool1.Size = new Size(136, 69);

            this.llPool1.SizeNormal = new Size(136, 69);
            this.llPool1.SuspendRedraw = false;
            this.llPool1.TabIndex = 35;
            this.llSecondary.Expandable = true;
            this.llSecondary.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.llSecondary.HighVis = true;
            this.llSecondary.HoverColor = Color.WhiteSmoke;

            this.llSecondary.Location = new Point(168, 206);
            this.llSecondary.MaxHeight = 600;
            this.llSecondary.Name = "llSecondary";
            this.llSecondary.PaddingX = 2;
            this.llSecondary.PaddingY = 2;
            this.llSecondary.Scrollable = true;
            this.llSecondary.ScrollBarColor = Color.Red;
            this.llSecondary.ScrollBarWidth = 11;
            this.llSecondary.ScrollButtonColor = Color.FromArgb(192, 0, 0);

            this.llSecondary.Size = new Size(144, 160);

            this.llSecondary.SizeNormal = new Size(144, 160);
            this.llSecondary.SuspendRedraw = false;
            this.llSecondary.TabIndex = 108;
            this.llPrimary.Expandable = true;
            this.llPrimary.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.llPrimary.HighVis = true;
            this.llPrimary.HoverColor = Color.WhiteSmoke;

            this.llPrimary.Location = new Point(16, 206);
            this.llPrimary.MaxHeight = 600;
            this.llPrimary.Name = "llPrimary";
            this.llPrimary.PaddingX = 2;
            this.llPrimary.PaddingY = 2;
            this.llPrimary.Scrollable = true;
            this.llPrimary.ScrollBarColor = Color.Red;
            this.llPrimary.ScrollBarWidth = 11;
            this.llPrimary.ScrollButtonColor = Color.FromArgb(192, 0, 0);

            this.llPrimary.Size = new Size(144, 160);

            this.llPrimary.SizeNormal = new Size(144, 160);
            this.llPrimary.SuspendRedraw = false;
            this.llPrimary.TabIndex = 107;
            this.llPool3.Expandable = false;
            this.llPool3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool3.ForeColor = Color.Yellow;
            this.llPool3.HighVis = true;
            this.llPool3.HoverColor = Color.WhiteSmoke;

            this.llPool3.Location = new Point(328, 530);
            this.llPool3.MaxHeight = 500;
            this.llPool3.Name = "llPool3";
            this.llPool3.PaddingX = 1;
            this.llPool3.PaddingY = 1;
            this.llPool3.Scrollable = true;
            this.llPool3.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool3.ScrollBarWidth = 8;
            this.llPool3.ScrollButtonColor = Color.FromArgb(96, 0, 192);

            this.llPool3.Size = new Size(136, 69);

            this.llPool3.SizeNormal = new Size(136, 69);
            this.llPool3.SuspendRedraw = false;
            this.llPool3.TabIndex = 37;
            this.llPool2.Expandable = false;
            this.llPool2.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.llPool2.ForeColor = Color.Yellow;
            this.llPool2.HighVis = true;
            this.llPool2.HoverColor = Color.WhiteSmoke;

            this.llPool2.Location = new Point(328, 422);
            this.llPool2.MaxHeight = 500;
            this.llPool2.Name = "llPool2";
            this.llPool2.PaddingX = 1;
            this.llPool2.PaddingY = 1;
            this.llPool2.Scrollable = true;
            this.llPool2.ScrollBarColor = Color.FromArgb(128, 96, 192);
            this.llPool2.ScrollBarWidth = 8;
            this.llPool2.ScrollButtonColor = Color.FromArgb(96, 0, 192);

            this.llPool2.Size = new Size(136, 69);

            this.llPool2.SizeNormal = new Size(136, 69);
            this.llPool2.SuspendRedraw = false;
            this.llPool2.TabIndex = 36;
            this.lblHero.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.lblHero.ForeColor = Color.White;
            this.lblHero.InitialText = "Name: Level 0 Origin Archetype (Primary / Secondary)";

            this.lblHero.Location = new Point(4, 26);
            this.lblHero.Name = "lblHero";

            this.lblHero.Size = new Size(834, 46);
            this.lblHero.TabIndex = 43;
            this.lblHero.TextAlign = ContentAlignment.TopLeft;
            this.heroVillain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.heroVillain.Checked = false;
            this.heroVillain.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.heroVillain.KnockoutLocationPoint = new Point(0, 0);

            this.heroVillain.Location = new Point(630, 27);
            this.heroVillain.Name = "heroVillain";

            this.heroVillain.Size = new Size(105, 22);
            this.heroVillain.TabIndex = 116;
            this.heroVillain.TextOff = "Hero";
            this.heroVillain.TextOn = "Villain";
            this.heroVillain.Toggle = true;
            this.tempPowersButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.tempPowersButton.Checked = false;
            this.tempPowersButton.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.tempPowersButton.KnockoutLocationPoint = new Point(0, 0);

            this.tempPowersButton.Location = new Point(951, 50);
            this.tempPowersButton.Name = "tempPowersButton";

            this.tempPowersButton.Size = new Size(105, 22);
            this.tempPowersButton.TabIndex = 115;
            this.tempPowersButton.TextOff = "Temp Pwrs (Off)";
            this.tempPowersButton.TextOn = "Temp Pwrs (On)";
            this.tempPowersButton.Toggle = true;
            this.accoladeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.accoladeButton.Checked = false;
            this.accoladeButton.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.accoladeButton.KnockoutLocationPoint = new Point(0, 0);

            this.accoladeButton.Location = new Point(737, 50);
            this.accoladeButton.Name = "accoladeButton";

            this.accoladeButton.Size = new Size(105, 22);
            this.accoladeButton.TabIndex = 114;
            this.accoladeButton.TextOff = "Accolades (Off)";
            this.accoladeButton.TextOn = "Accolades (On)";
            this.accoladeButton.Toggle = true;
            this.incarnateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.incarnateButton.Checked = false;
            this.incarnateButton.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.incarnateButton.KnockoutLocationPoint = new Point(0, 0);

            this.incarnateButton.Location = new Point(844, 50);
            this.incarnateButton.Name = "incarnateButton";

            this.incarnateButton.Size = new Size(105, 22);
            this.incarnateButton.TabIndex = 113;
            this.incarnateButton.TextOff = "Incarnate";
            this.incarnateButton.TextOn = "Incarnate";
            this.incarnateButton.Toggle = false;
            this.i9Picker.BackColor = Color.Black;
            this.i9Picker.ForeColor = Color.Blue;
            this.i9Picker.Highlight = Color.MediumSlateBlue;
            this.i9Picker.ImageSize = 30;

            this.i9Picker.Location = new Point(452, 131);
            this.i9Picker.Name = "I9Picker";
            this.i9Picker.Selected = Color.SlateBlue;

            this.i9Picker.Size = new Size(198, 235);
            this.i9Picker.TabIndex = 83;
            this.i9Picker.Visible = false;
            this.I9Popup.BackColor = Color.Black;
            this.I9Popup.BXHeight = 600;
            this.I9Popup.ColumnPosition = 0.5f;
            this.I9Popup.ColumnRight = false;
            this.I9Popup.Font = new Font("Arial", 13f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.I9Popup.ForeColor = Color.FromArgb(96, 48, (int)byte.MaxValue);
            this.I9Popup.InternalPadding = 3;

            this.I9Popup.Location = new Point(513, 490);
            this.I9Popup.Name = "I9Popup";
            this.I9Popup.ScrollY = 0.0f;
            this.I9Popup.SectionPadding = 8;

            this.I9Popup.Size = new Size(400, 214);
            this.I9Popup.TabIndex = 102;
            this.I9Popup.Visible = false;
            this.ibVetPools.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibVetPools.Checked = false;
            this.ibVetPools.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibVetPools.KnockoutLocationPoint = new Point(0, 0);

            this.ibVetPools.Location = new Point(441, 50);
            this.ibVetPools.Name = "ibVetPools";

            this.ibVetPools.Size = new Size(105, 22);
            this.ibVetPools.TabIndex = 111;
            this.ibVetPools.TextOff = "Veteran Pools: Off";
            this.ibVetPools.TextOn = "Veteran Pools: On";
            this.ibVetPools.Toggle = true;
            this.ibVetPools.Visible = false;
            this.ibPvX.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibPvX.Checked = false;
            this.ibPvX.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibPvX.KnockoutLocationPoint = new Point(0, 0);

            this.ibPvX.Location = new Point(737, 27);
            this.ibPvX.Name = "ibPvX";

            this.ibPvX.Size = new Size(105, 22);
            this.ibPvX.TabIndex = 111;
            this.ibPvX.TextOff = "Mode: PvE";
            this.ibPvX.TextOn = "Mode: PvP";
            this.ibPvX.Toggle = true;
            this.dvAnchored.BackColor = Color.Black;
            this.dvAnchored.DrawVillain = false;
            this.dvAnchored.Floating = false;
            this.dvAnchored.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);

            this.dvAnchored.Location = new Point(16, 391);
            this.dvAnchored.Name = "dvAnchored";

            this.dvAnchored.Size = new Size(300, 347);
            this.dvAnchored.TabIndex = 69;
            this.ibTotals.Checked = false;
            this.ibTotals.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibTotals.KnockoutLocationPoint = new Point(0, 0);

            this.ibTotals.Location = new Point(355, 109);
            this.ibTotals.Name = "ibTotals";

            this.ibTotals.Size = new Size(105, 22);
            this.ibTotals.TabIndex = 99;
            this.ibTotals.TextOff = "View Totals";
            this.ibTotals.TextOn = "Alt Text";
            this.ibTotals.Toggle = false;
            this.ibSlotLevels.Checked = false;
            this.ibSlotLevels.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibSlotLevels.KnockoutLocationPoint = new Point(0, 0);

            this.ibSlotLevels.Location = new Point(244, 133);
            this.ibSlotLevels.Name = "ibSlotLevels";

            this.ibSlotLevels.Size = new Size(105, 22);
            this.ibSlotLevels.TabIndex = 101;
            this.ibSlotLevels.TextOff = "Slot Levels: Off";
            this.ibSlotLevels.TextOn = "Slot Levels: On";
            this.ibSlotLevels.Toggle = true;
            this.ibMode.Checked = false;
            this.ibMode.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibMode.KnockoutLocationPoint = new Point(0, 0);

            this.ibMode.Location = new Point(244, 80);
            this.ibMode.Name = "ibMode";

            this.ibMode.Size = new Size(105, 22);
            this.ibMode.TabIndex = 100;
            this.ibMode.TextOff = "Mode Switch";
            this.ibMode.TextOn = "Alt Text";
            this.ibMode.Toggle = false;
            this.ibSets.Checked = false;
            this.ibSets.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibSets.KnockoutLocationPoint = new Point(0, 0);

            this.ibSets.Location = new Point(244, 109);
            this.ibSets.Name = "ibSets";

            this.ibSets.Size = new Size(105, 22);
            this.ibSets.TabIndex = 98;
            this.ibSets.TextOff = "View Active Sets";
            this.ibSets.TextOn = "Alt Text";
            this.ibSets.Toggle = false;
            this.ibAccolade.Checked = false;
            this.ibAccolade.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibAccolade.KnockoutLocationPoint = new Point(0, 0);

            this.ibAccolade.Location = new Point(355, 133);
            this.ibAccolade.Name = "ibAccolade";

            this.ibAccolade.Size = new Size(105, 22);
            this.ibAccolade.TabIndex = 106;
            this.ibAccolade.TextOff = "67 Slots to go";
            this.ibAccolade.TextOn = "0 Slots placed";
            this.ibAccolade.Toggle = true;
            this.ibRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibRecipe.Checked = false;
            this.ibRecipe.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibRecipe.KnockoutLocationPoint = new Point(0, 0);

            this.ibRecipe.Location = new Point(844, 27);
            this.ibRecipe.Name = "ibRecipe";

            this.ibRecipe.Size = new Size(105, 22);
            this.ibRecipe.TabIndex = 105;
            this.ibRecipe.TextOff = "Recipes: Off";
            this.ibRecipe.TextOn = "Recipes: On";
            this.ibRecipe.Toggle = true;
            this.ibPopup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.ibPopup.Checked = false;
            this.ibPopup.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);

            this.ibPopup.KnockoutLocationPoint = new Point(0, 0);

            this.ibPopup.Location = new Point(951, 27);
            this.ibPopup.Name = "ibPopup";

            this.ibPopup.Size = new Size(105, 22);
            this.ibPopup.TabIndex = 104;
            this.ibPopup.TextOff = "Pop-Up: Off";
            this.ibPopup.TextOn = "Pop-Up: On";
            this.ibPopup.Toggle = true;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Black;

            this.ClientSize = new Size(1056, 752);
            this.Controls.Add((Control)this.heroVillain);
            this.Controls.Add((Control)this.tempPowersButton);
            this.Controls.Add((Control)this.accoladeButton);
            this.Controls.Add((Control)this.incarnateButton);
            this.Controls.Add((Control)this.i9Picker);
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
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuBar;

            this.MinimumSize = new Size(640, 480);
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

        #endregion

        ToolStripMenuItem tsAdvDBEdit;
        ToolStripMenuItem tsAdvFreshInstall;
        ToolStripMenuItem tsAdvResetTips;
        ToolStripMenuItem tsBug;
        ToolStripMenuItem tsClearAllEnh;
        ToolStripMenuItem tsConfig;
        ToolStripMenuItem tsDonate;
        ToolStripMenuItem tsDynamic;
        ToolStripMenuItem tsEnhToDO;
        ToolStripMenuItem tsEnhToEven;
        ToolStripMenuItem tsEnhToMinus1;
        ToolStripMenuItem tsEnhToMinus2;
        ToolStripMenuItem tsEnhToMinus3;
        ToolStripMenuItem tsEnhToNone;
        ToolStripMenuItem tsEnhToPlus1;
        ToolStripMenuItem tsEnhToPlus2;
        ToolStripMenuItem tsEnhToPlus3;
        ToolStripMenuItem tsEnhToPlus4;
        ToolStripMenuItem tsEnhToPlus5;
        ToolStripMenuItem tsEnhToSO;
        ToolStripMenuItem tsEnhToTO;
        ToolStripMenuItem tsExport;
        ToolStripMenuItem tsExportDataLink;
        ToolStripMenuItem tsExportLong;
        ToolStripMenuItem tsFileNew;
        ToolStripMenuItem tsFileOpen;
        ToolStripMenuItem tsFilePrint;
        ToolStripMenuItem tsFileQuit;
        ToolStripMenuItem tsFileSave;
        ToolStripMenuItem tsFileSaveAs;
        ToolStripMenuItem tsFlipAllEnh;
        ToolStripMenuItem tsHelp;
        ToolStripMenuItem tsHelperLong;
        ToolStripMenuItem tsHelperLong2;
        ToolStripMenuItem tsHelperShort;
        ToolStripMenuItem tsHelperShort2;
        ToolStripMenuItem tsImport;
        ToolStripMenuItem tsIODefault;
        ToolStripMenuItem tsIOMax;
        ToolStripMenuItem tsIOMin;
        ToolStripMenuItem tsLevelUp;
        ToolStripMenuItem tsPatchNotes;
        ToolStripMenuItem tsRecipeViewer;
        ToolStripMenuItem tsDPSCalc;
        ToolStripMenuItem tsRemoveAllSlots;
        ToolStripMenuItem tsSetFind;
        ToolStripMenuItem tsTitanForum;
        ToolStripMenuItem tsTitanPlanner;
        ToolStripMenuItem tsTitanSite;
        ToolStripMenuItem tsUpdateCheck;
        ToolStripMenuItem tsView2Col;
        ToolStripMenuItem tsView3Col;
        ToolStripMenuItem tsView4Col;
        ToolStripMenuItem tsViewActualDamage_New;
        ToolStripMenuItem tsViewData;
        ToolStripMenuItem tsViewDPS_New;
        ToolStripMenuItem tsViewGraphs;
        ToolStripMenuItem tsViewIOLevels;
        ToolStripMenuItem tsViewRelative;
        ToolStripMenuItem tsViewSetCompare;
        ToolStripMenuItem tsViewSets;
        ToolStripMenuItem tsViewSlotLevels;
        ToolStripMenuItem tsViewTotals;
        ImageButton accoladeButton;
        ToolStripMenuItem AccoladesWindowToolStripMenuItem;
        ToolStripMenuItem AdvancedToolStripMenuItem1;
        ToolStripMenuItem AutoArrangeAllSlotsToolStripMenuItem;
        ComboBox cbAncillary;
        ComboBox cbAT;
        ComboBox cbOrigin;
        ComboBox cbPool0;
        ComboBox cbPool1;
        ComboBox cbPool2;
        ComboBox cbPool3;
        ComboBox cbPrimary;
        ComboBox cbSecondary;
        ToolStripMenuItem CharacterToolStripMenuItem;
        DataView dvAnchored;
        ToolStripMenuItem FileToolStripMenuItem;
        ToolStripMenuItem HelpToolStripMenuItem1;
        ImageButton heroVillain;
        I9Picker i9Picker;
        ctlPopUp I9Popup;
        ImageButton ibAccolade;
        ImageButton ibMode;
        ImageButton ibPopup;
        ImageButton ibPvX;
        ImageButton ibRecipe;
        ImageButton ibSets;
        ImageButton ibSlotLevels;
        ImageButton ibTotals;
        ImageButton ibVetPools;
        ToolStripMenuItem ImportExportToolStripMenuItem;
        ImageButton incarnateButton;
        ToolStripMenuItem IncarnateWindowToolStripMenuItem;
        ToolStripMenuItem InGameRespecHelperToolStripMenuItem;
        GFXLabel lblAT;
        Label lblATLocked;
        Label lblEpic;
        GFXLabel lblHero;
        Label lblLocked0;
        Label lblLocked1;
        Label lblLocked2;
        Label lblLocked3;
        Label lblLockedAncillary;
        Label lblLockedSecondary;
        GFXLabel lblName;
        GFXLabel lblOrigin;
        Label lblPool1;
        Label lblPool2;
        Label lblPool3;
        Label lblPool4;
        Label lblPrimary;
        Label lblSecondary;
        ListLabelV2 llAncillary;
        ListLabelV2 llPool0;
        ListLabelV2 llPool1;
        ListLabelV2 llPool2;
        ListLabelV2 llPool3;
        ListLabelV2 llPrimary;
        ListLabelV2 llSecondary;
        MenuStrip MenuBar;
        ToolStripMenuItem OptionsToolStripMenuItem;
        PictureBox pbDynMode;
        PictureBox pnlGFX;
        FlowLayoutPanel pnlGFXFlow;
        ToolStripMenuItem SetAllIOsToDefault35ToolStripMenuItem;
        ToolStripMenuItem SlotsToolStripMenuItem;
        ToolStripMenuItem TemporaryPowersWindowToolStripMenuItem;
        ImageButton tempPowersButton;
        ToolStripMenuItem tlsDPA;
        System.Windows.Forms.Timer tmrGfx;
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
        ToolTip tTip;
        TextBox txtName;
        ToolStripMenuItem ViewToolStripMenuItem;
        ToolStripMenuItem WindowToolStripMenuItem;
        OpenFileDialog dlgOpen;
        SaveFileDialog dlgSave;
    }
}