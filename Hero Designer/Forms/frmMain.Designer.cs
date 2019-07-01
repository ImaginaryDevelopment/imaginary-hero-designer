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
            this.components = (System.ComponentModel.IContainer)new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbAT = new System.Windows.Forms.ComboBox();
            this.cbOrigin = new System.Windows.Forms.ComboBox();
            this.cbPrimary = new System.Windows.Forms.ComboBox();
            this.lblPrimary = new System.Windows.Forms.Label();
            this.lblSecondary = new System.Windows.Forms.Label();
            this.cbSecondary = new System.Windows.Forms.ComboBox();
            this.cbPool0 = new System.Windows.Forms.ComboBox();
            this.lblPool1 = new System.Windows.Forms.Label();
            this.cbPool1 = new System.Windows.Forms.ComboBox();
            this.lblPool2 = new System.Windows.Forms.Label();
            this.cbPool2 = new System.Windows.Forms.ComboBox();
            this.lblPool3 = new System.Windows.Forms.Label();
            this.cbPool3 = new System.Windows.Forms.ComboBox();
            this.lblPool4 = new System.Windows.Forms.Label();
            this.cbAncillary = new System.Windows.Forms.ComboBox();
            this.lblEpic = new System.Windows.Forms.Label();
            this.lblATLocked = new System.Windows.Forms.Label();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblLocked0 = new System.Windows.Forms.Label();
            this.lblLocked1 = new System.Windows.Forms.Label();
            this.lblLocked2 = new System.Windows.Forms.Label();
            this.lblLocked3 = new System.Windows.Forms.Label();
            this.lblLockedAncillary = new System.Windows.Forms.Label();
            this.lblLockedSecondary = new System.Windows.Forms.Label();
            this.tmrGfx = new System.Windows.Forms.Timer(this.components);
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFileQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsImport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExportLong = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExportDataLink = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsUpdateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLevelUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDynamic = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.AdvancedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAdvDBEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdvFreshInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAdvResetTips = new System.Windows.Forms.ToolStripMenuItem();
            this.CharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetAllIOsToDefault35ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsIODefault = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsIOMin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsIOMax = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToSO = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToDO = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToTO = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToPlus5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToPlus4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToPlus3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToPlus2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToPlus1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToEven = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToMinus1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToMinus2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToMinus3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEnhToNone = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.SlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFlipAllEnh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClearAllEnh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRemoveAllSlots = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AutoArrangeAllSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsView4Col = new System.Windows.Forms.ToolStripMenuItem();
            this.tsView3Col = new System.Windows.Forms.ToolStripMenuItem();
            this.tsView2Col = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsViewIOLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewRelative = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSlotLevels = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsViewActualDamage_New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewDPS_New = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsDPA = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPatchNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTitanForum = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTitanPlanner = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTitanSite = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSets = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewGraphs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewSetCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsViewTotals = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.tsRecipeViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDPSCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSetFind = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.InGameRespecHelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelperShort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelperLong = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.tsHelperShort2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelperLong2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.AccoladesWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IncarnateWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TemporaryPowersWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDynMode = new System.Windows.Forms.PictureBox();
            this.pnlGFX = new System.Windows.Forms.PictureBox();
            this.pnlGFXFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.llAncillary = new midsControls.ListLabelV2();
            this.lblName = new midsControls.GFXLabel();
            this.lblOrigin = new midsControls.GFXLabel();
            this.lblAT = new midsControls.GFXLabel();
            this.llPool0 = new midsControls.ListLabelV2();
            this.llPool1 = new midsControls.ListLabelV2();
            this.llSecondary = new midsControls.ListLabelV2();
            this.llPrimary = new midsControls.ListLabelV2();
            this.llPool3 = new midsControls.ListLabelV2();
            this.llPool2 = new midsControls.ListLabelV2();
            this.lblHero = new midsControls.GFXLabel();
            this.heroVillain = new midsControls.ImageButton();
            this.tempPowersButton = new midsControls.ImageButton();
            this.accoladeButton = new midsControls.ImageButton();
            this.incarnateButton = new midsControls.ImageButton();
            this.i9Picker = new midsControls.I9Picker();
            this.I9Popup = new midsControls.ctlPopUp();
            this.ibVetPools = new midsControls.ImageButton();
            this.ibPvX = new midsControls.ImageButton();
            this.ibTotals = new midsControls.ImageButton();
            this.ibSlotLevels = new midsControls.ImageButton();
            this.ibMode = new midsControls.ImageButton();
            this.ibSets = new midsControls.ImageButton();
            this.ibAccolade = new midsControls.ImageButton();
            this.ibRecipe = new midsControls.ImageButton();
            this.ibPopup = new midsControls.ImageButton();
            this.MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbDynMode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pnlGFX).BeginInit();
            this.pnlGFXFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtName.Location = new System.Drawing.Point(96, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(142, 20);
            this.txtName.TabIndex = 1;
            // 
            // cbAT
            // 
            this.cbAT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbAT.DisplayMember = "DisplayName";
            this.cbAT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAT.ItemHeight = 16;
            this.cbAT.Location = new System.Drawing.Point(94, 109);
            this.cbAT.MaxDropDownItems = 15;
            this.cbAT.Name = "cbAT";
            this.cbAT.Size = new System.Drawing.Size(144, 22);
            this.cbAT.TabIndex = 3;
            this.cbAT.ValueMember = "Idx";
            this.cbAT.DrawItem += cbAT_DrawItem;
            this.cbAT.SelectionChangeCommitted += cbAT_SelectedIndexChanged;
            this.cbAT.MouseMove += cbAT_MouseMove;
            this.cbAT.MouseLeave += cbAT_MouseLeave;
            // 
            // cbOrigin
            // 
            this.cbOrigin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbOrigin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrigin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbOrigin.ItemHeight = 16;
            this.cbOrigin.Location = new System.Drawing.Point(94, 133);
            this.cbOrigin.Name = "cbOrigin";
            this.cbOrigin.Size = new System.Drawing.Size(144, 22);
            this.cbOrigin.TabIndex = 5;
            this.cbOrigin.DrawItem += cbOrigin_DrawItem;
            this.cbOrigin.SelectionChangeCommitted += cbOrigin_SelectedIndexChanged;
            // 
            // cbPrimary
            // 
            this.cbPrimary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPrimary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrimary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPrimary.ItemHeight = 16;
            this.cbPrimary.Location = new System.Drawing.Point(16, 182);
            this.cbPrimary.MaxDropDownItems = 15;
            this.cbPrimary.Name = "cbPrimary";
            this.cbPrimary.Size = new System.Drawing.Size(144, 22);
            this.cbPrimary.TabIndex = 7;
            // 
            // lblPrimary
            // 
            this.lblPrimary.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblPrimary.ForeColor = System.Drawing.Color.White;
            this.lblPrimary.Location = new System.Drawing.Point(20, 166);
            this.lblPrimary.Name = "lblPrimary";
            this.lblPrimary.Size = new System.Drawing.Size(136, 17);
            this.lblPrimary.TabIndex = 9;
            this.lblPrimary.Text = "Primary Power Set";
            this.lblPrimary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecondary
            // 
            this.lblSecondary.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblSecondary.ForeColor = System.Drawing.Color.White;
            this.lblSecondary.Location = new System.Drawing.Point(172, 166);
            this.lblSecondary.Name = "lblSecondary";
            this.lblSecondary.Size = new System.Drawing.Size(136, 17);
            this.lblSecondary.TabIndex = 10;
            this.lblSecondary.Text = "Secondary Power Set";
            this.lblSecondary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSecondary
            // 
            this.cbSecondary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSecondary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSecondary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSecondary.ItemHeight = 16;
            this.cbSecondary.Location = new System.Drawing.Point(168, 182);
            this.cbSecondary.MaxDropDownItems = 15;
            this.cbSecondary.Name = "cbSecondary";
            this.cbSecondary.Size = new System.Drawing.Size(144, 22);
            this.cbSecondary.TabIndex = 11;
            this.cbSecondary.DrawItem += cbSecondary_DrawItem;
            this.cbSecondary.SelectionChangeCommitted += cbSecondary_SelectedIndexChanged;
            this.cbSecondary.MouseMove += cbSecondary_MouseMove;
            this.cbSecondary.MouseLeave += cbSecondary_MouseLeave;
            // 
            // cbPool0
            // 
            this.cbPool0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPool0.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPool0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPool0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPool0.ItemHeight = 16;
            this.cbPool0.Location = new System.Drawing.Point(328, 182);
            this.cbPool0.MaxDropDownItems = 15;
            this.cbPool0.Name = "cbPool0";
            this.cbPool0.Size = new System.Drawing.Size(136, 22);
            this.cbPool0.TabIndex = 15;
            this.cbPool0.DrawItem += cbPool0_DrawItem;
            this.cbPool0.SelectionChangeCommitted += cbPool0_SelectedIndexChanged;
            this.cbPool0.MouseMove += cbPool0_MouseMove;
            this.cbPool0.MouseLeave += cbPool0_MouseLeave;
            // 
            // lblPool1
            // 
            this.lblPool1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblPool1.ForeColor = System.Drawing.Color.White;
            this.lblPool1.Location = new System.Drawing.Point(328, 166);
            this.lblPool1.Name = "lblPool1";
            this.lblPool1.Size = new System.Drawing.Size(136, 17);
            this.lblPool1.TabIndex = 14;
            this.lblPool1.Text = "Pool 1";
            this.lblPool1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPool1
            // 
            this.cbPool1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPool1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPool1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPool1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPool1.ItemHeight = 16;
            this.cbPool1.Location = new System.Drawing.Point(328, 290);
            this.cbPool1.MaxDropDownItems = 15;
            this.cbPool1.Name = "cbPool1";
            this.cbPool1.Size = new System.Drawing.Size(136, 22);
            this.cbPool1.TabIndex = 18;
            // 
            // lblPool2
            // 
            this.lblPool2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblPool2.ForeColor = System.Drawing.Color.White;
            this.lblPool2.Location = new System.Drawing.Point(328, 274);
            this.lblPool2.Name = "lblPool2";
            this.lblPool2.Size = new System.Drawing.Size(136, 17);
            this.lblPool2.TabIndex = 17;
            this.lblPool2.Text = "Pool 2";
            this.lblPool2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPool2
            // 
            this.cbPool2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPool2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPool2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPool2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPool2.ItemHeight = 16;
            this.cbPool2.Location = new System.Drawing.Point(328, 398);
            this.cbPool2.MaxDropDownItems = 15;
            this.cbPool2.Name = "cbPool2";
            this.cbPool2.Size = new System.Drawing.Size(136, 22);
            this.cbPool2.TabIndex = 21;
            // 
            // cbPool1
            // 
            this.cbPool1.DrawItem += cbPool1_DrawItem;
            this.cbPool1.SelectionChangeCommitted += cbPool1_SelectedIndexChanged;
            this.cbPool1.MouseMove += cbPool1_MouseMove;
            this.cbPool1.MouseLeave += cbPool0_MouseLeave;
            // 
            // lblPool3
            // 
            this.lblPool3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblPool3.ForeColor = System.Drawing.Color.White;
            this.lblPool3.Location = new System.Drawing.Point(328, 382);
            this.lblPool3.Name = "lblPool3";
            this.lblPool3.Size = new System.Drawing.Size(136, 17);
            this.lblPool3.TabIndex = 20;
            this.lblPool3.Text = "Pool 3";
            this.lblPool3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPool3
            // 
            this.cbPool3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbPool3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPool3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPool3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPool3.ItemHeight = 16;
            this.cbPool3.Location = new System.Drawing.Point(328, 506);
            this.cbPool3.MaxDropDownItems = 15;
            this.cbPool3.Name = "cbPool3";
            this.cbPool3.Size = new System.Drawing.Size(136, 22);
            this.cbPool3.TabIndex = 24;
            // 
            // lblPool4
            // 
            this.lblPool4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblPool4.ForeColor = System.Drawing.Color.White;
            this.lblPool4.Location = new System.Drawing.Point(328, 490);
            this.lblPool4.Name = "lblPool4";
            this.lblPool4.Size = new System.Drawing.Size(136, 17);
            this.lblPool4.TabIndex = 23;
            this.lblPool4.Text = "Pool 4";
            this.lblPool4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbAncillary
            // 
            this.cbAncillary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbAncillary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAncillary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAncillary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAncillary.ItemHeight = 16;
            this.cbAncillary.Location = new System.Drawing.Point(328, 614);
            this.cbAncillary.Name = "cbAncillary";
            this.cbAncillary.Size = new System.Drawing.Size(136, 22);
            this.cbAncillary.TabIndex = 27;
            this.cbAncillary.DrawItem += cbAncillary_DrawItem;
            this.cbAncillary.SelectionChangeCommitted += cbAncillery_SelectedIndexChanged;
            this.cbAncillary.MouseMove += cbAncillary_MouseMove;
            this.cbAncillary.MouseLeave += cbPool0_MouseLeave;
            // 
            // lblEpic
            // 
            this.lblEpic.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblEpic.ForeColor = System.Drawing.Color.White;
            this.lblEpic.Location = new System.Drawing.Point(328, 598);
            this.lblEpic.Name = "lblEpic";
            this.lblEpic.Size = new System.Drawing.Size(136, 17);
            this.lblEpic.TabIndex = 26;
            this.lblEpic.Text = "Ancillary/Epic Pool";
            this.lblEpic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblATLocked
            // 
            this.lblATLocked.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblATLocked.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblATLocked.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblATLocked.ForeColor = System.Drawing.Color.Black;
            this.lblATLocked.Location = new System.Drawing.Point(94, 113);
            this.lblATLocked.Name = "lblATLocked";
            this.lblATLocked.Size = new System.Drawing.Size(92, 29);
            this.lblATLocked.TabIndex = 53;
            this.lblATLocked.Text = "Archetype Locked";
            this.lblATLocked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "mxd";
            this.dlgOpen.Filter = "Hero/Villain Builds (*.mxd)|*.mxd;*.txt|Text Files (*.txt)|*.txt";
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "mxd";
            this.dlgSave.Filter = "Hero/Villain Builds (*.mxd)|*.mxd";
            // 
            // tTip
            // 
            this.tTip.AutoPopDelay = 5000;
            this.tTip.InitialDelay = 500;
            this.tTip.ReshowDelay = 100;
            // 
            // lblLocked0
            // 
            this.lblLocked0.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLocked0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocked0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLocked0.ForeColor = System.Drawing.Color.Black;
            this.lblLocked0.Location = new System.Drawing.Point(308, 166);
            this.lblLocked0.Name = "lblLocked0";
            this.lblLocked0.Size = new System.Drawing.Size(92, 29);
            this.lblLocked0.TabIndex = 72;
            this.lblLocked0.Text = "Pool Locked";
            this.lblLocked0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocked1
            // 
            this.lblLocked1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLocked1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocked1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLocked1.ForeColor = System.Drawing.Color.Black;
            this.lblLocked1.Location = new System.Drawing.Point(308, 186);
            this.lblLocked1.Name = "lblLocked1";
            this.lblLocked1.Size = new System.Drawing.Size(92, 29);
            this.lblLocked1.TabIndex = 73;
            this.lblLocked1.Text = "Pool Locked";
            this.lblLocked1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocked2
            // 
            this.lblLocked2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLocked2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocked2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLocked2.ForeColor = System.Drawing.Color.Black;
            this.lblLocked2.Location = new System.Drawing.Point(304, 194);
            this.lblLocked2.Name = "lblLocked2";
            this.lblLocked2.Size = new System.Drawing.Size(92, 29);
            this.lblLocked2.TabIndex = 74;
            this.lblLocked2.Text = "Pool Locked";
            this.lblLocked2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocked3
            // 
            this.lblLocked3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLocked3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLocked3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLocked3.ForeColor = System.Drawing.Color.Black;
            this.lblLocked3.Location = new System.Drawing.Point(284, 210);
            this.lblLocked3.Name = "lblLocked3";
            this.lblLocked3.Size = new System.Drawing.Size(92, 29);
            this.lblLocked3.TabIndex = 75;
            this.lblLocked3.Text = "Pool Locked";
            this.lblLocked3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLockedAncillary
            // 
            this.lblLockedAncillary.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLockedAncillary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLockedAncillary.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLockedAncillary.ForeColor = System.Drawing.Color.Black;
            this.lblLockedAncillary.Location = new System.Drawing.Point(268, 230);
            this.lblLockedAncillary.Name = "lblLockedAncillary";
            this.lblLockedAncillary.Size = new System.Drawing.Size(92, 29);
            this.lblLockedAncillary.TabIndex = 76;
            this.lblLockedAncillary.Text = "Pool Locked";
            this.lblLockedAncillary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLockedSecondary
            // 
            this.lblLockedSecondary.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLockedSecondary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLockedSecondary.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblLockedSecondary.ForeColor = System.Drawing.Color.Black;
            this.lblLockedSecondary.Location = new System.Drawing.Point(257, 246);
            this.lblLockedSecondary.Name = "lblLockedSecondary";
            this.lblLockedSecondary.Size = new System.Drawing.Size(92, 29);
            this.lblLockedSecondary.TabIndex = 109;
            this.lblLockedSecondary.Text = "Sec. Locked";
            this.lblLockedSecondary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.SystemColors.Control;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[7]
            {
            this.FileToolStripMenuItem,
            this.ImportExportToolStripMenuItem,
            this.OptionsToolStripMenuItem,
            this.CharacterToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.HelpToolStripMenuItem1,
            this.WindowToolStripMenuItem
            });
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1056, 24);
            this.MenuBar.TabIndex = 84;
            this.MenuBar.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9]
            {
            this.tsFileNew,
            this.ToolStripSeparator7,
            this.tsFileOpen,
            this.tsFileSave,
            this.tsFileSaveAs,
            this.ToolStripSeparator8,
            this.tsFilePrint,
            this.ToolStripSeparator9,
            this.tsFileQuit
            });
            this.FileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // tsFileNew
            // 
            this.tsFileNew.Name = "tsFileNew";
            this.tsFileNew.ShortcutKeys = System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control;
            this.tsFileNew.Size = new System.Drawing.Size(179, 22);
            this.tsFileNew.Text = "&New / Clear";
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(176, 6);
            // 
            // tsFileOpen
            // 
            this.tsFileOpen.Name = "tsFileOpen";
            this.tsFileOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;
            this.tsFileOpen.Size = new System.Drawing.Size(179, 22);
            this.tsFileOpen.Text = "&Open...";
            // 
            // tsFileSave
            // 
            this.tsFileSave.Name = "tsFileSave";
            this.tsFileSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
            this.tsFileSave.Size = new System.Drawing.Size(179, 22);
            this.tsFileSave.Text = "&Save";
            // 
            // tsFileSaveAs
            // 
            this.tsFileSaveAs.Name = "tsFileSaveAs";
            this.tsFileSaveAs.Size = new System.Drawing.Size(179, 22);
            this.tsFileSaveAs.Text = "Save &As...";
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(176, 6);
            // 
            // tsFilePrint
            // 
            this.tsFilePrint.Name = "tsFilePrint";
            this.tsFilePrint.ShortcutKeys = System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control;
            this.tsFilePrint.Size = new System.Drawing.Size(179, 22);
            this.tsFilePrint.Text = "&Print...";
            // 
            // ToolStripSeparator9
            // 
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(176, 6);
            // 
            // tsFileQuit
            // 
            this.tsFileQuit.Name = "tsFileQuit";
            this.tsFileQuit.ShortcutKeys = System.Windows.Forms.Keys.Q | System.Windows.Forms.Keys.Control;
            this.tsFileQuit.Size = new System.Drawing.Size(179, 22);
            this.tsFileQuit.Text = "&Quit";
            // 
            // ImportExportToolStripMenuItem
            // 
            this.ImportExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
            {
            (System.Windows.Forms.ToolStripItem) this.tsImport,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator12,
            (System.Windows.Forms.ToolStripItem) this.tsExport,
            (System.Windows.Forms.ToolStripItem) this.tsExportLong,
            (System.Windows.Forms.ToolStripItem) this.tsExportDataLink
            });
            this.ImportExportToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImportExportToolStripMenuItem.Name = "ImportExportToolStripMenuItem";
            this.ImportExportToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.ImportExportToolStripMenuItem.Text = "&Import / Export";
            // 
            // tsImport
            // 
            this.tsImport.Name = "tsImport";
            this.tsImport.ShortcutKeys = System.Windows.Forms.Keys.I | System.Windows.Forms.Keys.Control;
            this.tsImport.Size = new System.Drawing.Size(240, 22);
            this.tsImport.Text = "&Import from Forum Post";
            // 
            // ToolStripSeparator12
            // 
            this.ToolStripSeparator12.Name = "ToolStripSeparator12";
            this.ToolStripSeparator12.Size = new System.Drawing.Size(237, 6);
            // 
            // tsExport
            // 
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(240, 22);
            this.tsExport.Text = "&Short Forum Export...";
            // 
            // tsExportLong
            // 
            this.tsExportLong.Name = "tsExportLong";
            this.tsExportLong.Size = new System.Drawing.Size(240, 22);
            this.tsExportLong.Text = "&Long Forum Export...";
            // 
            // tsExportDataLink
            // 
            this.tsExportDataLink.Name = "tsExportDataLink";
            this.tsExportDataLink.Size = new System.Drawing.Size(240, 22);
            this.tsExportDataLink.Text = "Export Data Link";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8]
            {
            this.tsConfig,
            this.ToolStripSeparator14,
            this.tsUpdateCheck,
            this.ToolStripSeparator22,
            this.tsLevelUp,
            this.tsDynamic,
            this.ToolStripSeparator5,
            this.AdvancedToolStripMenuItem1
            });
            this.OptionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OptionsToolStripMenuItem.Text = "&Options";
            // 
            // tsConfig
            // 
            this.tsConfig.Name = "tsConfig";
            this.tsConfig.Size = new System.Drawing.Size(199, 22);
            this.tsConfig.Text = "&Configuration...";
            // 
            // ToolStripSeparator14
            // 
            this.ToolStripSeparator14.Name = "ToolStripSeparator14";
            this.ToolStripSeparator14.Size = new System.Drawing.Size(196, 6);
            // 
            // tsUpdateCheck
            // 
            this.tsUpdateCheck.Name = "tsUpdateCheck";
            this.tsUpdateCheck.Size = new System.Drawing.Size(199, 22);
            this.tsUpdateCheck.Text = "Check for &Updates Now";
            // 
            // ToolStripSeparator22
            // 
            this.ToolStripSeparator22.Name = "ToolStripSeparator22";
            this.ToolStripSeparator22.Size = new System.Drawing.Size(196, 6);
            // 
            // tsLevelUp
            // 
            this.tsLevelUp.Name = "tsLevelUp";
            this.tsLevelUp.Size = new System.Drawing.Size(199, 22);
            this.tsLevelUp.Text = "&Level-Up Mode";
            this.tsLevelUp.ToolTipText = "Alternate between placing powers and slots, just like levelling up in-game.";
            // 
            // tsDynamic
            // 
            this.tsDynamic.Name = "tsDynamic";
            this.tsDynamic.Size = new System.Drawing.Size(199, 22);
            this.tsDynamic.Text = "&Dynamic Mode";
            this.tsDynamic.ToolTipText = "Place powers and slots in any order.";
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(196, 6);
            // 
            // AdvancedToolStripMenuItem1
            // 
            this.AdvancedToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4]
            {
            (System.Windows.Forms.ToolStripItem) this.tsAdvDBEdit,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator15,
            (System.Windows.Forms.ToolStripItem) this.tsAdvFreshInstall,
            (System.Windows.Forms.ToolStripItem) this.tsAdvResetTips
            });
            this.AdvancedToolStripMenuItem1.Name = "AdvancedToolStripMenuItem1";
            this.AdvancedToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.AdvancedToolStripMenuItem1.Text = "&Advanced";
            // 
            // tsAdvDBEdit
            // 
            this.tsAdvDBEdit.Name = "tsAdvDBEdit";
            this.tsAdvDBEdit.Size = new System.Drawing.Size(165, 22);
            this.tsAdvDBEdit.Text = "&Database Editor...";
            // 
            // ToolStripSeparator15
            // 
            this.ToolStripSeparator15.Name = "ToolStripSeparator15";
            this.ToolStripSeparator15.Size = new System.Drawing.Size(162, 6);
            // 
            // tsAdvFreshInstall
            // 
            this.tsAdvFreshInstall.Name = "tsAdvFreshInstall";
            this.tsAdvFreshInstall.Size = new System.Drawing.Size(165, 22);
            this.tsAdvFreshInstall.Text = "FreshInstall Flag";
            this.tsAdvFreshInstall.Visible = false;
            // 
            // tsAdvResetTips
            // 
            this.tsAdvResetTips.Name = "tsAdvResetTips";
            this.tsAdvResetTips.Size = new System.Drawing.Size(165, 22);
            this.tsAdvResetTips.Text = "Reset Tips";
            // 
            // CharacterToolStripMenuItem
            // 
            this.CharacterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6]
            {
            (System.Windows.Forms.ToolStripItem) this.SetAllIOsToDefault35ToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator16,
            (System.Windows.Forms.ToolStripItem) this.ToolStripMenuItem1,
            (System.Windows.Forms.ToolStripItem) this.ToolStripMenuItem2,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator17,
            (System.Windows.Forms.ToolStripItem) this.SlotsToolStripMenuItem
            });
            this.CharacterToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CharacterToolStripMenuItem.Name = "CharacterToolStripMenuItem";
            this.CharacterToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.CharacterToolStripMenuItem.Text = "&Slots / Enhancements";
            // 
            // SetAllIOsToDefault35ToolStripMenuItem
            // 
            this.SetAllIOsToDefault35ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4]
            {
            (System.Windows.Forms.ToolStripItem) this.tsIODefault,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator11,
            (System.Windows.Forms.ToolStripItem) this.tsIOMin,
            (System.Windows.Forms.ToolStripItem) this.tsIOMax
            });
            this.SetAllIOsToDefault35ToolStripMenuItem.Name = "SetAllIOsToDefault35ToolStripMenuItem";
            this.SetAllIOsToDefault35ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.SetAllIOsToDefault35ToolStripMenuItem.Text = "&Set all IOs to...";
            // 
            // tsIODefault
            // 
            this.tsIODefault.Name = "tsIODefault";
            this.tsIODefault.Size = new System.Drawing.Size(135, 22);
            this.tsIODefault.Text = "Default (35)";
            // 
            // ToolStripSeparator11
            // 
            this.ToolStripSeparator11.Name = "ToolStripSeparator11";
            this.ToolStripSeparator11.Size = new System.Drawing.Size(132, 6);
            // 
            // tsIOMin
            // 
            this.tsIOMin.Name = "tsIOMin";
            this.tsIOMin.Size = new System.Drawing.Size(135, 22);
            this.tsIOMin.Text = "Minimum";
            // 
            // tsIOMax
            // 
            this.tsIOMax.Name = "tsIOMax";
            this.tsIOMax.Size = new System.Drawing.Size(135, 22);
            this.tsIOMax.Text = "Maximum";
            // 
            // ToolStripSeparator16
            // 
            this.ToolStripSeparator16.Name = "ToolStripSeparator16";
            this.ToolStripSeparator16.Size = new System.Drawing.Size(242, 6);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3]
            {
            (System.Windows.Forms.ToolStripItem) this.tsEnhToSO,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToDO,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToTO
            });
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItem1.Text = "Set all Enhancement &Origins to...";
            // 
            // tsEnhToSO
            // 
            this.tsEnhToSO.Name = "tsEnhToSO";
            this.tsEnhToSO.Size = new System.Drawing.Size(142, 22);
            this.tsEnhToSO.Text = "Single Origin";
            // 
            // tsEnhToDO
            // 
            this.tsEnhToDO.Name = "tsEnhToDO";
            this.tsEnhToDO.Size = new System.Drawing.Size(142, 22);
            this.tsEnhToDO.Text = "Dual Origin";
            // 
            // tsEnhToTO
            // 
            this.tsEnhToTO.Name = "tsEnhToTO";
            this.tsEnhToTO.Size = new System.Drawing.Size(142, 22);
            this.tsEnhToTO.Text = "Training";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10]
            {
            (System.Windows.Forms.ToolStripItem) this.tsEnhToPlus5,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToPlus4,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToPlus3,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToPlus2,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToPlus1,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToEven,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToMinus1,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToMinus2,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToMinus3,
            (System.Windows.Forms.ToolStripItem) this.tsEnhToNone
            });
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(245, 22);
            this.ToolStripMenuItem2.Text = "Set all &Relative Levels to...";
            // 
            // tsEnhToPlus5
            // 
            this.tsEnhToPlus5.Name = "tsEnhToPlus5";
            this.tsEnhToPlus5.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToPlus5.Text = "+5 Levels";
            // 
            // tsEnhToPlus4
            // 
            this.tsEnhToPlus4.Name = "tsEnhToPlus4";
            this.tsEnhToPlus4.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToPlus4.Text = "+4 Levels";
            // 
            // tsEnhToPlus3
            // 
            this.tsEnhToPlus3.Name = "tsEnhToPlus3";
            this.tsEnhToPlus3.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToPlus3.Text = "+3 Levels";
            // 
            // tsEnhToPlus2
            // 
            this.tsEnhToPlus2.Name = "tsEnhToPlus2";
            this.tsEnhToPlus2.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToPlus2.Text = "+2 Levels";
            // 
            // tsEnhToPlus1
            // 
            this.tsEnhToPlus1.Name = "tsEnhToPlus1";
            this.tsEnhToPlus1.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToPlus1.Text = "+1 Level";
            // 
            // tsEnhToEven
            // 
            this.tsEnhToEven.Name = "tsEnhToEven";
            this.tsEnhToEven.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToEven.Text = "Even Level";
            // 
            // tsEnhToMinus1
            // 
            this.tsEnhToMinus1.Name = "tsEnhToMinus1";
            this.tsEnhToMinus1.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToMinus1.Text = "-1 Level";
            // 
            // tsEnhToMinus2
            // 
            this.tsEnhToMinus2.Name = "tsEnhToMinus2";
            this.tsEnhToMinus2.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToMinus2.Text = "-2 Levels";
            // 
            // tsEnhToMinus3
            // 
            this.tsEnhToMinus3.Name = "tsEnhToMinus3";
            this.tsEnhToMinus3.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToMinus3.Text = "-3 Levels";
            // 
            // tsEnhToNone
            // 
            this.tsEnhToNone.Name = "tsEnhToNone";
            this.tsEnhToNone.Size = new System.Drawing.Size(205, 22);
            this.tsEnhToNone.Text = "None (Enh has no effect)";
            // 
            // ToolStripSeparator17
            // 
            this.ToolStripSeparator17.Name = "ToolStripSeparator17";
            this.ToolStripSeparator17.Size = new System.Drawing.Size(242, 6);
            // 
            // SlotsToolStripMenuItem
            // 
            this.SlotsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6]
            {
            (System.Windows.Forms.ToolStripItem) this.tsFlipAllEnh,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator4,
            (System.Windows.Forms.ToolStripItem) this.tsClearAllEnh,
            (System.Windows.Forms.ToolStripItem) this.tsRemoveAllSlots,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator1,
            (System.Windows.Forms.ToolStripItem) this.AutoArrangeAllSlotsToolStripMenuItem
            });
            this.SlotsToolStripMenuItem.Name = "SlotsToolStripMenuItem";
            this.SlotsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.SlotsToolStripMenuItem.Text = "Slo&ts";
            // 
            // tsFlipAllEnh
            // 
            this.tsFlipAllEnh.Name = "tsFlipAllEnh";
            this.tsFlipAllEnh.Size = new System.Drawing.Size(199, 22);
            this.tsFlipAllEnh.Text = "Flip All to Alternate";
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // tsClearAllEnh
            // 
            this.tsClearAllEnh.Name = "tsClearAllEnh";
            this.tsClearAllEnh.Size = new System.Drawing.Size(199, 22);
            this.tsClearAllEnh.Text = "Clear All Enhancements";
            // 
            // tsRemoveAllSlots
            // 
            this.tsRemoveAllSlots.Name = "tsRemoveAllSlots";
            this.tsRemoveAllSlots.Size = new System.Drawing.Size(199, 22);
            this.tsRemoveAllSlots.Text = "Remove All Slots";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // AutoArrangeAllSlotsToolStripMenuItem
            // 
            this.AutoArrangeAllSlotsToolStripMenuItem.Name = "AutoArrangeAllSlotsToolStripMenuItem";
            this.AutoArrangeAllSlotsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.AutoArrangeAllSlotsToolStripMenuItem.Text = "&Auto-Arrange All Slots";
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[11]
            {
            (System.Windows.Forms.ToolStripItem) this.tsView4Col,
            (System.Windows.Forms.ToolStripItem) this.tsView3Col,
            (System.Windows.Forms.ToolStripItem) this.tsView2Col,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator13,
            (System.Windows.Forms.ToolStripItem) this.tsViewIOLevels,
            (System.Windows.Forms.ToolStripItem) this.tsViewRelative,
            (System.Windows.Forms.ToolStripItem) this.tsViewSlotLevels,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator2,
            (System.Windows.Forms.ToolStripItem) this.tsViewActualDamage_New,
            (System.Windows.Forms.ToolStripItem) this.tsViewDPS_New,
            (System.Windows.Forms.ToolStripItem) this.tlsDPA
            });
            this.ViewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ViewToolStripMenuItem.Text = "&View";
            // 
            // tsView4Col
            // 
            this.tsView4Col.Name = "tsView4Col";
            this.tsView4Col.Size = new System.Drawing.Size(282, 22);
            this.tsView4Col.Text = "&4 Columns";
            // 
            // tsView3Col
            // 
            this.tsView3Col.Checked = true;
            this.tsView3Col.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsView3Col.Name = "tsView3Col";
            this.tsView3Col.Size = new System.Drawing.Size(282, 22);
            this.tsView3Col.Text = "&3 Columns";
            // 
            // tsView2Col
            // 
            this.tsView2Col.Name = "tsView2Col";
            this.tsView2Col.Size = new System.Drawing.Size(282, 22);
            this.tsView2Col.Text = "&2 Columns";
            // 
            // ToolStripSeparator13
            // 
            this.ToolStripSeparator13.Name = "ToolStripSeparator13";
            this.ToolStripSeparator13.Size = new System.Drawing.Size(279, 6);
            // 
            // tsViewIOLevels
            // 
            this.tsViewIOLevels.Checked = true;
            this.tsViewIOLevels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsViewIOLevels.Name = "tsViewIOLevels";
            this.tsViewIOLevels.Size = new System.Drawing.Size(282, 22);
            this.tsViewIOLevels.Text = "Show &IO Levels";
            // 
            // tsViewRelative
            // 
            this.tsViewRelative.Name = "tsViewRelative";
            this.tsViewRelative.Size = new System.Drawing.Size(282, 22);
            this.tsViewRelative.Text = "Show &Enhancement Relative Levels";
            // 
            // tsViewSlotLevels
            // 
            this.tsViewSlotLevels.Name = "tsViewSlotLevels";
            this.tsViewSlotLevels.Size = new System.Drawing.Size(282, 22);
            this.tsViewSlotLevels.Text = "Show &Slot Placement Levels";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(279, 6);
            // 
            // tsViewActualDamage_New
            // 
            this.tsViewActualDamage_New.Checked = true;
            this.tsViewActualDamage_New.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsViewActualDamage_New.Name = "tsViewActualDamage_New";
            this.tsViewActualDamage_New.Size = new System.Drawing.Size(282, 22);
            this.tsViewActualDamage_New.Text = "Show Damage Per Activation (Level 50)";
            // 
            // tsViewDPS_New
            // 
            this.tsViewDPS_New.Name = "tsViewDPS_New";
            this.tsViewDPS_New.Size = new System.Drawing.Size(282, 22);
            this.tsViewDPS_New.Text = "Show Damage Per Second (Level 50)";
            // 
            // tlsDPA
            // 
            this.tlsDPA.Name = "tlsDPA";
            this.tlsDPA.Size = new System.Drawing.Size(282, 22);
            this.tlsDPA.Text = "Show Damage Per Animation (Level 50)";
            // 
            // HelpToolStripMenuItem1
            // 
            this.HelpToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[10]
            {
            (System.Windows.Forms.ToolStripItem) this.tsHelp,
            (System.Windows.Forms.ToolStripItem) this.tsPatchNotes,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator10,
            (System.Windows.Forms.ToolStripItem) this.tsBug,
            (System.Windows.Forms.ToolStripItem) this.tsTitanForum,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator23,
            (System.Windows.Forms.ToolStripItem) this.tsDonate,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator24,
            (System.Windows.Forms.ToolStripItem) this.tsTitanPlanner,
            (System.Windows.Forms.ToolStripItem) this.tsTitanSite
            });
            this.HelpToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
            this.HelpToolStripMenuItem1.Size = new System.Drawing.Size(102, 20);
            this.HelpToolStripMenuItem1.Text = "&Help && Support";
            // 
            // tsHelp
            // 
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsHelp.Size = new System.Drawing.Size(258, 22);
            this.tsHelp.Text = "&Read Me - Instructions";
            // 
            // tsPatchNotes
            // 
            this.tsPatchNotes.Name = "tsPatchNotes";
            this.tsPatchNotes.Size = new System.Drawing.Size(258, 22);
            this.tsPatchNotes.Text = "Read &Latest Patch Notes...";
            // 
            // ToolStripSeparator10
            // 
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size((int)byte.MaxValue, 6);
            // 
            // tsBug
            // 
            this.tsBug.Name = "tsBug";
            this.tsBug.Size = new System.Drawing.Size(258, 22);
            this.tsBug.Text = "Feedback Form / &Bug Report";
            this.tsBug.Visible = false;
            // 
            // tsTitanForum
            // 
            this.tsTitanForum.Name = "tsTitanForum";
            this.tsTitanForum.Size = new System.Drawing.Size(258, 22);
            this.tsTitanForum.Text = "Go to Support / Discussion &Forums";
            // 
            // ToolStripSeparator23
            // 
            this.ToolStripSeparator23.Name = "ToolStripSeparator23";
            this.ToolStripSeparator23.Size = new System.Drawing.Size((int)byte.MaxValue, 6);
            // 
            // tsDonate
            // 
            this.tsDonate.Name = "tsDonate";
            this.tsDonate.Size = new System.Drawing.Size(258, 22);
            this.tsDonate.Text = "Make a Donation (PayPal)";
            // 
            // ToolStripSeparator24
            // 
            this.ToolStripSeparator24.Name = "ToolStripSeparator24";
            this.ToolStripSeparator24.Size = new System.Drawing.Size((int)byte.MaxValue, 6);
            // 
            // tsTitanPlanner
            // 
            this.tsTitanPlanner.Name = "tsTitanPlanner";
            this.tsTitanPlanner.Size = new System.Drawing.Size(258, 22);
            this.tsTitanPlanner.Text = "CoH &Planner Website";
            // 
            // tsTitanSite
            // 
            this.tsTitanSite.Name = "tsTitanSite";
            this.tsTitanSite.Size = new System.Drawing.Size(258, 22);
            this.tsTitanSite.Text = "&Titan Network Website";
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[16]
            {
            (System.Windows.Forms.ToolStripItem) this.tsViewSets,
            (System.Windows.Forms.ToolStripItem) this.tsViewGraphs,
            (System.Windows.Forms.ToolStripItem) this.tsViewSetCompare,
            (System.Windows.Forms.ToolStripItem) this.tsViewData,
            (System.Windows.Forms.ToolStripItem) this.tsViewTotals,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator18,
            (System.Windows.Forms.ToolStripItem) this.tsRecipeViewer,
            (System.Windows.Forms.ToolStripItem) this.tsDPSCalc,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator19,
            (System.Windows.Forms.ToolStripItem) this.tsSetFind,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator21,
            (System.Windows.Forms.ToolStripItem) this.InGameRespecHelperToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem) this.ToolStripMenuItem4,
            (System.Windows.Forms.ToolStripItem) this.AccoladesWindowToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem) this.IncarnateWindowToolStripMenuItem,
            (System.Windows.Forms.ToolStripItem) this.TemporaryPowersWindowToolStripMenuItem
            });
            this.WindowToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.WindowToolStripMenuItem.Text = "&Window";
            // 
            // tsViewSets
            // 
            this.tsViewSets.Name = "tsViewSets";
            this.tsViewSets.ShortcutKeys = System.Windows.Forms.Keys.B | System.Windows.Forms.Keys.Control;
            this.tsViewSets.Size = new System.Drawing.Size(232, 22);
            this.tsViewSets.Text = "&Sets && Bonuses";
            // 
            // tsViewGraphs
            // 
            this.tsViewGraphs.Name = "tsViewGraphs";
            this.tsViewGraphs.ShortcutKeys = System.Windows.Forms.Keys.G | System.Windows.Forms.Keys.Control;
            this.tsViewGraphs.Size = new System.Drawing.Size(232, 22);
            this.tsViewGraphs.Text = "Power &Graphs";
            // 
            // tsViewSetCompare
            // 
            this.tsViewSetCompare.Name = "tsViewSetCompare";
            this.tsViewSetCompare.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
            this.tsViewSetCompare.Size = new System.Drawing.Size(232, 22);
            this.tsViewSetCompare.Text = "Powerset &Comparison";
            // 
            // tsViewData
            // 
            this.tsViewData.Name = "tsViewData";
            this.tsViewData.ShortcutKeys = System.Windows.Forms.Keys.D | System.Windows.Forms.Keys.Control;
            this.tsViewData.Size = new System.Drawing.Size(232, 22);
            this.tsViewData.Text = "&Data View";
            // 
            // tsViewTotals
            // 
            this.tsViewTotals.Name = "tsViewTotals";
            this.tsViewTotals.ShortcutKeys = System.Windows.Forms.Keys.T | System.Windows.Forms.Keys.Control;
            this.tsViewTotals.Size = new System.Drawing.Size(232, 22);
            this.tsViewTotals.Text = "Advanced &Totals";
            // 
            // ToolStripSeparator18
            // 
            this.ToolStripSeparator18.Name = "ToolStripSeparator18";
            this.ToolStripSeparator18.Size = new System.Drawing.Size(229, 6);
            // 
            // tsRecipeViewer
            // 
            this.tsRecipeViewer.Name = "tsRecipeViewer";
            this.tsRecipeViewer.ShortcutKeys = System.Windows.Forms.Keys.R | System.Windows.Forms.Keys.Control;
            this.tsRecipeViewer.Size = new System.Drawing.Size(232, 22);
            this.tsRecipeViewer.Text = "&Recipe Viewer";
            // 
            // tsDPSCalc
            // 
            this.tsDPSCalc.Name = "tsDPSCalc";
            this.tsDPSCalc.ShortcutKeys = System.Windows.Forms.Keys.Z | System.Windows.Forms.Keys.Control;
            this.tsDPSCalc.Size = new System.Drawing.Size(232, 22);
            this.tsDPSCalc.Text = "DPS Calculator (Beta)";
            // 
            // ToolStripSeparator19
            // 
            this.ToolStripSeparator19.Name = "ToolStripSeparator19";
            this.ToolStripSeparator19.Size = new System.Drawing.Size(229, 6);
            // 
            // tsSetFind
            // 
            this.tsSetFind.Name = "tsSetFind";
            this.tsSetFind.Size = new System.Drawing.Size(232, 22);
            this.tsSetFind.Text = "Set &Bonus Finder";
            // 
            // ToolStripSeparator21
            // 
            this.ToolStripSeparator21.Name = "ToolStripSeparator21";
            this.ToolStripSeparator21.Size = new System.Drawing.Size(229, 6);
            // 
            // InGameRespecHelperToolStripMenuItem
            // 
            this.InGameRespecHelperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5]
            {
            (System.Windows.Forms.ToolStripItem) this.tsHelperShort,
            (System.Windows.Forms.ToolStripItem) this.tsHelperLong,
            (System.Windows.Forms.ToolStripItem) this.ToolStripSeparator20,
            (System.Windows.Forms.ToolStripItem) this.tsHelperShort2,
            (System.Windows.Forms.ToolStripItem) this.tsHelperLong2
            });
            this.InGameRespecHelperToolStripMenuItem.Name = "InGameRespecHelperToolStripMenuItem";
            this.InGameRespecHelperToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.InGameRespecHelperToolStripMenuItem.Text = "In-Game &Respec Helper";
            // 
            // tsHelperShort
            // 
            this.tsHelperShort.Name = "tsHelperShort";
            this.tsHelperShort.Size = new System.Drawing.Size(143, 22);
            this.tsHelperShort.Text = "Profile &Short";
            // 
            // tsHelperLong
            // 
            this.tsHelperLong.Name = "tsHelperLong";
            this.tsHelperLong.Size = new System.Drawing.Size(143, 22);
            this.tsHelperLong.Text = "Profile &Long";
            // 
            // ToolStripSeparator20
            // 
            this.ToolStripSeparator20.Name = "ToolStripSeparator20";
            this.ToolStripSeparator20.Size = new System.Drawing.Size(140, 6);
            // 
            // tsHelperShort2
            // 
            this.tsHelperShort2.Name = "tsHelperShort2";
            this.tsHelperShort2.Size = new System.Drawing.Size(143, 22);
            this.tsHelperShort2.Text = "History S&hort";
            // 
            // tsHelperLong2
            // 
            this.tsHelperLong2.Name = "tsHelperLong2";
            this.tsHelperLong2.Size = new System.Drawing.Size(143, 22);
            this.tsHelperLong2.Text = "History L&ong";
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(229, 6);
            // 
            // AccoladesWindowToolStripMenuItem
            // 
            this.AccoladesWindowToolStripMenuItem.Name = "AccoladesWindowToolStripMenuItem";
            this.AccoladesWindowToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.AccoladesWindowToolStripMenuItem.Text = "&Accolades Window";
            this.AccoladesWindowToolStripMenuItem.Click += AccoladesWindowToolStripMenuItem_Click;
            // 
            // IncarnateWindowToolStripMenuItem
            // 
            this.IncarnateWindowToolStripMenuItem.Name = "IncarnateWindowToolStripMenuItem";
            this.IncarnateWindowToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.IncarnateWindowToolStripMenuItem.Text = "&Incarnate Window";
            // 
            // TemporaryPowersWindowToolStripMenuItem
            // 
            this.TemporaryPowersWindowToolStripMenuItem.Name = "TemporaryPowersWindowToolStripMenuItem";
            this.TemporaryPowersWindowToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.TemporaryPowersWindowToolStripMenuItem.Text = "T&emporary Powers Window";
            // 
            // pbDynMode
            // 
            this.pbDynMode.Location = new System.Drawing.Point(355, 80);
            this.pbDynMode.Name = "pbDynMode";
            this.pbDynMode.Size = new System.Drawing.Size(105, 22);
            this.pbDynMode.TabIndex = 92;
            this.pbDynMode.TabStop = false;
            // 
            // pnlGFX
            // 
            this.pnlGFX.BackColor = System.Drawing.Color.Black;
            this.pnlGFX.Location = new System.Drawing.Point(3, 3);
            this.pnlGFX.Name = "pnlGFX";
            this.pnlGFX.Size = new System.Drawing.Size(584, 709);
            this.pnlGFX.TabIndex = 103;
            this.pnlGFX.TabStop = false;
            // 
            // pnlGFXFlow
            // 
            this.pnlGFXFlow.AutoScroll = true;
            this.pnlGFXFlow.Controls.Add(this.pnlGFX);
            this.pnlGFXFlow.Location = new System.Drawing.Point(472, 78);
            this.pnlGFXFlow.Name = "pnlGFXFlow";
            this.pnlGFXFlow.Size = new System.Drawing.Size(584, 629);
            this.pnlGFXFlow.TabIndex = 112;
            // 
            // llAncillary
            // 
            this.llAncillary.Expandable = false;
            this.llAncillary.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.llAncillary.HighVis = true;
            this.llAncillary.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llAncillary.Location = new System.Drawing.Point(328, 638);
            this.llAncillary.MaxHeight = 500;
            this.llAncillary.Name = "llAncillary";
            this.llAncillary.PaddingX = 2;
            this.llAncillary.PaddingY = 2;
            this.llAncillary.Scrollable = true;
            this.llAncillary.ScrollBarColor = System.Drawing.Color.Red;
            this.llAncillary.ScrollBarWidth = 11;
            this.llAncillary.ScrollButtonColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.llAncillary.Size = new System.Drawing.Size(138, 69);
            this.llAncillary.SizeNormal = new System.Drawing.Size(138, 69);
            this.llAncillary.SuspendRedraw = false;
            this.llAncillary.TabIndex = 110;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.InitialText = "Name:";
            this.lblName.Location = new System.Drawing.Point(4, 82);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 21);
            this.lblName.TabIndex = 44;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrigin
            // 
            this.lblOrigin.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblOrigin.InitialText = "Origin:";
            this.lblOrigin.Location = new System.Drawing.Point(2, 133);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(92, 21);
            this.lblOrigin.TabIndex = 46;
            this.lblOrigin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAT
            // 
            this.lblAT.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblAT.InitialText = "Archetype:";
            this.lblAT.Location = new System.Drawing.Point(2, 109);
            this.lblAT.Name = "lblAT";
            this.lblAT.Size = new System.Drawing.Size(92, 21);
            this.lblAT.TabIndex = 45;
            this.lblAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // llPool0
            // 
            this.llPool0.Expandable = false;
            this.llPool0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.llPool0.HighVis = true;
            this.llPool0.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llPool0.Location = new System.Drawing.Point(328, 206);
            this.llPool0.MaxHeight = 500;
            this.llPool0.Name = "llPool0";
            this.llPool0.PaddingX = 2;
            this.llPool0.PaddingY = 2;
            this.llPool0.Scrollable = true;
            this.llPool0.ScrollBarColor = System.Drawing.Color.FromArgb(128, 96, 192);
            this.llPool0.ScrollBarWidth = 11;
            this.llPool0.ScrollButtonColor = System.Drawing.Color.FromArgb(96, 0, 192);
            this.llPool0.Size = new System.Drawing.Size(136, 69);
            this.llPool0.SizeNormal = new System.Drawing.Size(136, 69);
            this.llPool0.SuspendRedraw = false;
            this.llPool0.TabIndex = 34;
            // 
            // llPool1
            // 
            this.llPool1.Expandable = false;
            this.llPool1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.llPool1.ForeColor = System.Drawing.Color.Yellow;
            this.llPool1.HighVis = true;
            this.llPool1.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llPool1.Location = new System.Drawing.Point(328, 314);
            this.llPool1.MaxHeight = 500;
            this.llPool1.Name = "llPool1";
            this.llPool1.PaddingX = 2;
            this.llPool1.PaddingY = 2;
            this.llPool1.Scrollable = true;
            this.llPool1.ScrollBarColor = System.Drawing.Color.FromArgb(128, 96, 192);
            this.llPool1.ScrollBarWidth = 8;
            this.llPool1.ScrollButtonColor = System.Drawing.Color.FromArgb(96, 0, 192);
            this.llPool1.Size = new System.Drawing.Size(136, 69);
            this.llPool1.SizeNormal = new System.Drawing.Size(136, 69);
            this.llPool1.SuspendRedraw = false;
            this.llPool1.TabIndex = 35;
            // 
            // llSecondary
            // 
            this.llSecondary.Expandable = true;
            this.llSecondary.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.llSecondary.HighVis = true;
            this.llSecondary.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llSecondary.Location = new System.Drawing.Point(168, 206);
            this.llSecondary.MaxHeight = 600;
            this.llSecondary.Name = "llSecondary";
            this.llSecondary.PaddingX = 2;
            this.llSecondary.PaddingY = 2;
            this.llSecondary.Scrollable = true;
            this.llSecondary.ScrollBarColor = System.Drawing.Color.Red;
            this.llSecondary.ScrollBarWidth = 11;
            this.llSecondary.ScrollButtonColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.llSecondary.Size = new System.Drawing.Size(144, 160);
            this.llSecondary.SizeNormal = new System.Drawing.Size(144, 160);
            this.llSecondary.SuspendRedraw = false;
            this.llSecondary.TabIndex = 108;
            // 
            // llPrimary
            // 
            this.llPrimary.Expandable = true;
            this.llPrimary.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.llPrimary.HighVis = true;
            this.llPrimary.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llPrimary.Location = new System.Drawing.Point(16, 206);
            this.llPrimary.MaxHeight = 600;
            this.llPrimary.Name = "llPrimary";
            this.llPrimary.PaddingX = 2;
            this.llPrimary.PaddingY = 2;
            this.llPrimary.Scrollable = true;
            this.llPrimary.ScrollBarColor = System.Drawing.Color.Red;
            this.llPrimary.ScrollBarWidth = 11;
            this.llPrimary.ScrollButtonColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.llPrimary.Size = new System.Drawing.Size(144, 160);
            this.llPrimary.SizeNormal = new System.Drawing.Size(144, 160);
            this.llPrimary.SuspendRedraw = false;
            this.llPrimary.TabIndex = 107;
            // 
            // llPool3
            // 
            this.llPool3.Expandable = false;
            this.llPool3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.llPool3.ForeColor = System.Drawing.Color.Yellow;
            this.llPool3.HighVis = true;
            this.llPool3.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llPool3.Location = new System.Drawing.Point(328, 530);
            this.llPool3.MaxHeight = 500;
            this.llPool3.Name = "llPool3";
            this.llPool3.PaddingX = 1;
            this.llPool3.PaddingY = 1;
            this.llPool3.Scrollable = true;
            this.llPool3.ScrollBarColor = System.Drawing.Color.FromArgb(128, 96, 192);
            this.llPool3.ScrollBarWidth = 8;
            this.llPool3.ScrollButtonColor = System.Drawing.Color.FromArgb(96, 0, 192);
            this.llPool3.Size = new System.Drawing.Size(136, 69);
            this.llPool3.SizeNormal = new System.Drawing.Size(136, 69);
            this.llPool3.SuspendRedraw = false;
            this.llPool3.TabIndex = 37;
            // 
            // llPool2
            // 
            this.llPool2.Expandable = false;
            this.llPool2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.llPool2.ForeColor = System.Drawing.Color.Yellow;
            this.llPool2.HighVis = true;
            this.llPool2.HoverColor = System.Drawing.Color.WhiteSmoke;
            this.llPool2.Location = new System.Drawing.Point(328, 422);
            this.llPool2.MaxHeight = 500;
            this.llPool2.Name = "llPool2";
            this.llPool2.PaddingX = 1;
            this.llPool2.PaddingY = 1;
            this.llPool2.Scrollable = true;
            this.llPool2.ScrollBarColor = System.Drawing.Color.FromArgb(128, 96, 192);
            this.llPool2.ScrollBarWidth = 8;
            this.llPool2.ScrollButtonColor = System.Drawing.Color.FromArgb(96, 0, 192);
            this.llPool2.Size = new System.Drawing.Size(136, 69);
            this.llPool2.SizeNormal = new System.Drawing.Size(136, 69);
            this.llPool2.SuspendRedraw = false;
            this.llPool2.TabIndex = 36;
            // 
            // lblHero
            // 
            this.lblHero.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblHero.ForeColor = System.Drawing.Color.White;
            this.lblHero.InitialText = "Name: Level 0 Origin Archetype (Primary / Secondary)";
            this.lblHero.Location = new System.Drawing.Point(4, 26);
            this.lblHero.Name = "lblHero";
            this.lblHero.Size = new System.Drawing.Size(834, 46);
            this.lblHero.TabIndex = 43;
            this.lblHero.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // heroVillain
            // 
            this.heroVillain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.heroVillain.Checked = false;
            this.heroVillain.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.heroVillain.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.heroVillain.Location = new System.Drawing.Point(630, 27);
            this.heroVillain.Name = "heroVillain";
            this.heroVillain.Size = new System.Drawing.Size(105, 22);
            this.heroVillain.TabIndex = 116;
            this.heroVillain.TextOff = "Hero";
            this.heroVillain.TextOn = "Villain";
            this.heroVillain.Toggle = true;
            // 
            // tempPowersButton
            // 
            this.tempPowersButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.tempPowersButton.Checked = false;
            this.tempPowersButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.tempPowersButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.tempPowersButton.Location = new System.Drawing.Point(951, 50);
            this.tempPowersButton.Name = "tempPowersButton";
            this.tempPowersButton.Size = new System.Drawing.Size(105, 22);
            this.tempPowersButton.TabIndex = 115;
            this.tempPowersButton.TextOff = "Temp Pwrs (Off)";
            this.tempPowersButton.TextOn = "Temp Pwrs (On)";
            this.tempPowersButton.Toggle = true;
            // 
            // accoladeButton
            // 
            this.accoladeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.accoladeButton.Checked = false;
            this.accoladeButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.accoladeButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.accoladeButton.Location = new System.Drawing.Point(737, 50);
            this.accoladeButton.Name = "accoladeButton";
            this.accoladeButton.Size = new System.Drawing.Size(105, 22);
            this.accoladeButton.TabIndex = 114;
            this.accoladeButton.TextOff = "Accolades (Off)";
            this.accoladeButton.TextOn = "Accolades (On)";
            this.accoladeButton.Toggle = true;
            this.accoladeButton.MouseDown += accoladeButton_MouseDown;
            this.accoladeButton.ButtonClicked += accoladeButton_ButtonClicked;
            // 
            // incarnateButton
            // 
            this.incarnateButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.incarnateButton.Checked = false;
            this.incarnateButton.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.incarnateButton.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.incarnateButton.Location = new System.Drawing.Point(844, 50);
            this.incarnateButton.Name = "incarnateButton";
            this.incarnateButton.Size = new System.Drawing.Size(105, 22);
            this.incarnateButton.TabIndex = 113;
            this.incarnateButton.TextOff = "Incarnate";
            this.incarnateButton.TextOn = "Incarnate";
            this.incarnateButton.Toggle = false;
            // 
            // i9Picker
            // 
            this.i9Picker.BackColor = System.Drawing.Color.Black;
            this.i9Picker.ForeColor = System.Drawing.Color.Blue;
            this.i9Picker.Highlight = System.Drawing.Color.MediumSlateBlue;
            this.i9Picker.ImageSize = 30;
            this.i9Picker.Location = new System.Drawing.Point(452, 131);
            this.i9Picker.Name = "I9Picker";
            this.i9Picker.Selected = System.Drawing.Color.SlateBlue;
            this.i9Picker.Size = new System.Drawing.Size(198, 235);
            this.i9Picker.TabIndex = 83;
            this.i9Picker.Visible = false;
            this.i9Picker.Moved += this.I9Picker_Moved;
            this.i9Picker.HoverSet += this.I9Picker_HoverSet;
            this.i9Picker.HoverEnhancement += this.I9Picker_HoverEnhancement;
            this.i9Picker.MouseLeave += this.I9Picker_Hiding;
            this.i9Picker.EnhancementPicked += this.I9Picker_EnhancementPicked;
            this.i9Picker.MouseDown += this.I9Picker_MouseDown;
            // 
            // I9Popup
            // 
            this.I9Popup.BackColor = System.Drawing.Color.Black;
            this.I9Popup.BXHeight = 600;
            this.I9Popup.ColumnPosition = 0.5f;
            this.I9Popup.ColumnRight = false;
            this.I9Popup.Font = new System.Drawing.Font("Arial", 13f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.I9Popup.ForeColor = System.Drawing.Color.FromArgb(96, 48, (int)byte.MaxValue);
            this.I9Popup.InternalPadding = 3;
            this.I9Popup.Location = new System.Drawing.Point(513, 490);
            this.I9Popup.Name = "I9Popup";
            this.I9Popup.ScrollY = 0.0f;
            this.I9Popup.SectionPadding = 8;
            this.I9Popup.Size = new System.Drawing.Size(400, 214);
            this.I9Popup.TabIndex = 102;
            this.I9Popup.Visible = false;
            // 
            // ibVetPools
            // 
            this.ibVetPools.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ibVetPools.Checked = false;
            this.ibVetPools.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibVetPools.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibVetPools.Location = new System.Drawing.Point(441, 50);
            this.ibVetPools.Name = "ibVetPools";
            this.ibVetPools.Size = new System.Drawing.Size(105, 22);
            this.ibVetPools.TabIndex = 111;
            this.ibVetPools.TextOff = "Veteran Pools: Off";
            this.ibVetPools.TextOn = "Veteran Pools: On";
            this.ibVetPools.Toggle = true;
            this.ibVetPools.Visible = false;
            // 
            // ibPvX
            // 
            this.ibPvX.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ibPvX.Checked = false;
            this.ibPvX.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibPvX.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibPvX.Location = new System.Drawing.Point(737, 27);
            this.ibPvX.Name = "ibPvX";
            this.ibPvX.Size = new System.Drawing.Size(105, 22);
            this.ibPvX.TabIndex = 111;
            this.ibPvX.TextOff = "Mode: PvE";
            this.ibPvX.TextOn = "Mode: PvP";
            this.ibPvX.Toggle = true;
            // 
            // ibTotals
            // 
            this.ibTotals.Checked = false;
            this.ibTotals.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibTotals.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibTotals.Location = new System.Drawing.Point(355, 109);
            this.ibTotals.Name = "ibTotals";
            this.ibTotals.Size = new System.Drawing.Size(105, 22);
            this.ibTotals.TabIndex = 99;
            this.ibTotals.TextOff = "View Totals";
            this.ibTotals.TextOn = "Alt Text";
            this.ibTotals.Toggle = false;
            // 
            // ibSlotLevels
            // 
            this.ibSlotLevels.Checked = false;
            this.ibSlotLevels.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibSlotLevels.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibSlotLevels.Location = new System.Drawing.Point(244, 133);
            this.ibSlotLevels.Name = "ibSlotLevels";
            this.ibSlotLevels.Size = new System.Drawing.Size(105, 22);
            this.ibSlotLevels.TabIndex = 101;
            this.ibSlotLevels.TextOff = "Slot Levels: Off";
            this.ibSlotLevels.TextOn = "Slot Levels: On";
            this.ibSlotLevels.Toggle = true;
            // 
            // ibMode
            // 
            this.ibMode.Checked = false;
            this.ibMode.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibMode.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibMode.Location = new System.Drawing.Point(244, 80);
            this.ibMode.Name = "ibMode";
            this.ibMode.Size = new System.Drawing.Size(105, 22);
            this.ibMode.TabIndex = 100;
            this.ibMode.TextOff = "Mode Switch";
            this.ibMode.TextOn = "Alt Text";
            this.ibMode.Toggle = false;
            // 
            // ibSets
            // 
            this.ibSets.Checked = false;
            this.ibSets.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibSets.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibSets.Location = new System.Drawing.Point(244, 109);
            this.ibSets.Name = "ibSets";
            this.ibSets.Size = new System.Drawing.Size(105, 22);
            this.ibSets.TabIndex = 98;
            this.ibSets.TextOff = "View Active Sets";
            this.ibSets.TextOn = "Alt Text";
            this.ibSets.Toggle = false;
            // 
            // ibAccolade
            // 
            this.ibAccolade.Checked = false;
            this.ibAccolade.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibAccolade.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibAccolade.Location = new System.Drawing.Point(355, 133);
            this.ibAccolade.Name = "ibAccolade";
            this.ibAccolade.Size = new System.Drawing.Size(105, 22);
            this.ibAccolade.TabIndex = 106;
            this.ibAccolade.TextOff = "67 Slots to go";
            this.ibAccolade.TextOn = "0 Slots placed";
            this.ibAccolade.Toggle = true;
            // 
            // ibRecipe
            // 
            this.ibRecipe.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ibRecipe.Checked = false;
            this.ibRecipe.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibRecipe.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibRecipe.Location = new System.Drawing.Point(844, 27);
            this.ibRecipe.Name = "ibRecipe";
            this.ibRecipe.Size = new System.Drawing.Size(105, 22);
            this.ibRecipe.TabIndex = 105;
            this.ibRecipe.TextOff = "Recipes: Off";
            this.ibRecipe.TextOn = "Recipes: On";
            this.ibRecipe.Toggle = true;
            // 
            // ibPopup
            // 
            this.ibPopup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ibPopup.Checked = false;
            this.ibPopup.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ibPopup.KnockoutLocationPoint = new System.Drawing.Point(0, 0);
            this.ibPopup.Location = new System.Drawing.Point(951, 27);
            this.ibPopup.Name = "ibPopup";
            this.ibPopup.Size = new System.Drawing.Size(105, 22);
            this.ibPopup.TabIndex = 104;
            this.ibPopup.TextOff = "Pop-Up: Off";
            this.ibPopup.TextOn = "Pop-Up: On";
            this.ibPopup.Toggle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1056, 752);
            this.Controls.Add(this.heroVillain);
            this.Controls.Add(this.tempPowersButton);
            this.Controls.Add(this.accoladeButton);
            this.Controls.Add(this.incarnateButton);
            this.Controls.Add(this.i9Picker);
            this.Controls.Add(this.I9Popup);
            this.Controls.Add(this.ibVetPools);
            this.Controls.Add(this.ibPvX);
            this.Controls.Add(this.llAncillary);
            this.Controls.Add(this.lblLockedSecondary);
            this.Controls.Add(this.ibTotals);
            this.Controls.Add(this.ibSlotLevels);
            this.Controls.Add(this.ibMode);
            this.Controls.Add(this.ibSets);
            this.Controls.Add(this.pbDynMode);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.lblLockedAncillary);
            this.Controls.Add(this.lblLocked3);
            this.Controls.Add(this.lblLocked2);
            this.Controls.Add(this.lblLocked1);
            this.Controls.Add(this.lblLocked0);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblATLocked);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.lblAT);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.llPool0);
            this.Controls.Add(this.llPool1);
            this.Controls.Add(this.lblPool3);
            this.Controls.Add(this.cbPool1);
            this.Controls.Add(this.lblPool2);
            this.Controls.Add(this.cbPool0);
            this.Controls.Add(this.lblPool1);
            this.Controls.Add(this.cbSecondary);
            this.Controls.Add(this.lblSecondary);
            this.Controls.Add(this.cbPrimary);
            this.Controls.Add(this.cbOrigin);
            this.Controls.Add(this.cbAT);
            this.Controls.Add(this.ibAccolade);
            this.Controls.Add(this.ibRecipe);
            this.Controls.Add(this.ibPopup);
            this.Controls.Add(this.lblPrimary);
            this.Controls.Add(this.llSecondary);
            this.Controls.Add(this.llPrimary);
            this.Controls.Add(this.llPool3);
            this.Controls.Add(this.llPool2);
            this.Controls.Add(this.cbAncillary);
            this.Controls.Add(this.lblEpic);
            this.Controls.Add(this.cbPool3);
            this.Controls.Add(this.lblPool4);
            this.Controls.Add(this.cbPool2);
            this.Controls.Add(this.pnlGFXFlow);
            this.Controls.Add(this.lblHero);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, (byte)0);
            this.ForeColor = System.Drawing.Color.White;
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuBar;

            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hero Designer";
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbDynMode).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pnlGFX).EndInit();
            this.pnlGFXFlow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        System.Windows.Forms.ToolStripMenuItem tsAdvDBEdit;
        System.Windows.Forms.ToolStripMenuItem tsAdvFreshInstall;
        System.Windows.Forms.ToolStripMenuItem tsAdvResetTips;
        System.Windows.Forms.ToolStripMenuItem tsBug;
        System.Windows.Forms.ToolStripMenuItem tsClearAllEnh;
        System.Windows.Forms.ToolStripMenuItem tsConfig;
        System.Windows.Forms.ToolStripMenuItem tsDonate;
        System.Windows.Forms.ToolStripMenuItem tsDynamic;
        System.Windows.Forms.ToolStripMenuItem tsEnhToDO;
        System.Windows.Forms.ToolStripMenuItem tsEnhToEven;
        System.Windows.Forms.ToolStripMenuItem tsEnhToMinus1;
        System.Windows.Forms.ToolStripMenuItem tsEnhToMinus2;
        System.Windows.Forms.ToolStripMenuItem tsEnhToMinus3;
        System.Windows.Forms.ToolStripMenuItem tsEnhToNone;
        System.Windows.Forms.ToolStripMenuItem tsEnhToPlus1;
        System.Windows.Forms.ToolStripMenuItem tsEnhToPlus2;
        System.Windows.Forms.ToolStripMenuItem tsEnhToPlus3;
        System.Windows.Forms.ToolStripMenuItem tsEnhToPlus4;
        System.Windows.Forms.ToolStripMenuItem tsEnhToPlus5;
        System.Windows.Forms.ToolStripMenuItem tsEnhToSO;
        System.Windows.Forms.ToolStripMenuItem tsEnhToTO;
        System.Windows.Forms.ToolStripMenuItem tsExport;
        System.Windows.Forms.ToolStripMenuItem tsExportDataLink;
        System.Windows.Forms.ToolStripMenuItem tsExportLong;
        System.Windows.Forms.ToolStripMenuItem tsFileNew;
        System.Windows.Forms.ToolStripMenuItem tsFileOpen;
        System.Windows.Forms.ToolStripMenuItem tsFilePrint;
        System.Windows.Forms.ToolStripMenuItem tsFileQuit;
        System.Windows.Forms.ToolStripMenuItem tsFileSave;
        System.Windows.Forms.ToolStripMenuItem tsFileSaveAs;
        System.Windows.Forms.ToolStripMenuItem tsFlipAllEnh;
        System.Windows.Forms.ToolStripMenuItem tsHelp;
        System.Windows.Forms.ToolStripMenuItem tsHelperLong;
        System.Windows.Forms.ToolStripMenuItem tsHelperLong2;
        System.Windows.Forms.ToolStripMenuItem tsHelperShort;
        System.Windows.Forms.ToolStripMenuItem tsHelperShort2;
        System.Windows.Forms.ToolStripMenuItem tsImport;
        System.Windows.Forms.ToolStripMenuItem tsIODefault;
        System.Windows.Forms.ToolStripMenuItem tsIOMax;
        System.Windows.Forms.ToolStripMenuItem tsIOMin;
        System.Windows.Forms.ToolStripMenuItem tsLevelUp;
        System.Windows.Forms.ToolStripMenuItem tsPatchNotes;
        System.Windows.Forms.ToolStripMenuItem tsRecipeViewer;
        System.Windows.Forms.ToolStripMenuItem tsDPSCalc;
        System.Windows.Forms.ToolStripMenuItem tsRemoveAllSlots;
        System.Windows.Forms.ToolStripMenuItem tsSetFind;
        System.Windows.Forms.ToolStripMenuItem tsTitanForum;
        System.Windows.Forms.ToolStripMenuItem tsTitanPlanner;
        System.Windows.Forms.ToolStripMenuItem tsTitanSite;
        System.Windows.Forms.ToolStripMenuItem tsUpdateCheck;
        System.Windows.Forms.ToolStripMenuItem tsView2Col;
        System.Windows.Forms.ToolStripMenuItem tsView3Col;
        System.Windows.Forms.ToolStripMenuItem tsView4Col;
        System.Windows.Forms.ToolStripMenuItem tsViewActualDamage_New;
        System.Windows.Forms.ToolStripMenuItem tsViewData;
        System.Windows.Forms.ToolStripMenuItem tsViewDPS_New;
        System.Windows.Forms.ToolStripMenuItem tsViewGraphs;
        System.Windows.Forms.ToolStripMenuItem tsViewIOLevels;
        System.Windows.Forms.ToolStripMenuItem tsViewRelative;
        System.Windows.Forms.ToolStripMenuItem tsViewSetCompare;
        System.Windows.Forms.ToolStripMenuItem tsViewSets;
        System.Windows.Forms.ToolStripMenuItem tsViewSlotLevels;
        System.Windows.Forms.ToolStripMenuItem tsViewTotals;
        midsControls.ImageButton accoladeButton;
        System.Windows.Forms.ToolStripMenuItem AccoladesWindowToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem AdvancedToolStripMenuItem1;
        System.Windows.Forms.ToolStripMenuItem AutoArrangeAllSlotsToolStripMenuItem;
        System.Windows.Forms.ComboBox cbAncillary;
        System.Windows.Forms.ComboBox cbAT;
        System.Windows.Forms.ComboBox cbOrigin;
        System.Windows.Forms.ComboBox cbPool0;
        System.Windows.Forms.ComboBox cbPool1;
        System.Windows.Forms.ComboBox cbPool2;
        System.Windows.Forms.ComboBox cbPool3;
        System.Windows.Forms.ComboBox cbPrimary;
        System.Windows.Forms.ComboBox cbSecondary;
        System.Windows.Forms.ToolStripMenuItem CharacterToolStripMenuItem;
        DataView dvAnchored;
        System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem1;
        midsControls.ImageButton heroVillain;
        midsControls.I9Picker i9Picker;
        midsControls.ctlPopUp I9Popup;
        midsControls.ImageButton ibAccolade;
        midsControls.ImageButton ibMode;
        midsControls.ImageButton ibPopup;
        midsControls.ImageButton ibPvX;
        midsControls.ImageButton ibRecipe;
        midsControls.ImageButton ibSets;
        midsControls.ImageButton ibSlotLevels;
        midsControls.ImageButton ibTotals;
        midsControls.ImageButton ibVetPools;
        System.Windows.Forms.ToolStripMenuItem ImportExportToolStripMenuItem;
        midsControls.ImageButton incarnateButton;
        System.Windows.Forms.ToolStripMenuItem IncarnateWindowToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem InGameRespecHelperToolStripMenuItem;
        midsControls.GFXLabel lblAT;
        System.Windows.Forms.Label lblATLocked;
        System.Windows.Forms.Label lblEpic;
        midsControls.GFXLabel lblHero;
        System.Windows.Forms.Label lblLocked0;
        System.Windows.Forms.Label lblLocked1;
        System.Windows.Forms.Label lblLocked2;
        System.Windows.Forms.Label lblLocked3;
        System.Windows.Forms.Label lblLockedAncillary;
        System.Windows.Forms.Label lblLockedSecondary;
        midsControls.GFXLabel lblName;
        midsControls.GFXLabel lblOrigin;
        System.Windows.Forms.Label lblPool1;
        System.Windows.Forms.Label lblPool2;
        System.Windows.Forms.Label lblPool3;
        System.Windows.Forms.Label lblPool4;
        System.Windows.Forms.Label lblPrimary;
        System.Windows.Forms.Label lblSecondary;
        midsControls.ListLabelV2 llAncillary;
        midsControls.ListLabelV2 llPool0;
        midsControls.ListLabelV2 llPool1;
        midsControls.ListLabelV2 llPool2;
        midsControls.ListLabelV2 llPool3;
        midsControls.ListLabelV2 llPrimary;
        midsControls.ListLabelV2 llSecondary;
        System.Windows.Forms.MenuStrip MenuBar;
        System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        System.Windows.Forms.PictureBox pbDynMode;
        System.Windows.Forms.PictureBox pnlGFX;
        System.Windows.Forms.FlowLayoutPanel pnlGFXFlow;
        System.Windows.Forms.ToolStripMenuItem SetAllIOsToDefault35ToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem SlotsToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem TemporaryPowersWindowToolStripMenuItem;
        midsControls.ImageButton tempPowersButton;
        System.Windows.Forms.ToolStripMenuItem tlsDPA;
        System.Windows.Forms.Timer tmrGfx;
        System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator10;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator11;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator12;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator13;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator14;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator15;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator16;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator17;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator18;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator19;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator20;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator21;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator22;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator23;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator24;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
        System.Windows.Forms.ToolTip tTip;
        System.Windows.Forms.TextBox txtName;
        System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        System.Windows.Forms.ToolStripMenuItem WindowToolStripMenuItem;
        System.Windows.Forms.OpenFileDialog dlgOpen;
        System.Windows.Forms.SaveFileDialog dlgSave;
    }
}
