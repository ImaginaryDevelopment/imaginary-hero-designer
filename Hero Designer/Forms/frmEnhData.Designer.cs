namespace Hero_Designer
{
    public partial class frmEnhData
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

            this.gbBasic = new System.Windows.Forms.GroupBox();
            this.txtInternal = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.udMinLevel = new System.Windows.Forms.NumericUpDown();
            this.udMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtNameShort = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtNameFull = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnImage = new System.Windows.Forms.Button();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.cbSubType = new System.Windows.Forms.ComboBox();
            this.typeSet = new System.Windows.Forms.RadioButton();
            this.typeIO = new System.Windows.Forms.RadioButton();
            this.typeRegular = new System.Windows.Forms.RadioButton();
            this.typeHO = new System.Windows.Forms.RadioButton();
            this.cbSet = new System.Windows.Forms.ComboBox();
            this.gbSet = new System.Windows.Forms.GroupBox();
            this.chkSuperior = new System.Windows.Forms.CheckBox();
            this.pbSet = new System.Windows.Forms.PictureBox();
            this.chkUnique = new System.Windows.Forms.CheckBox();
            this.gbEffects = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbDebuff = new System.Windows.Forms.RadioButton();
            this.rbBuff = new System.Windows.Forms.RadioButton();
            this.btnAutoFill = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtProb = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddFX = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbMod = new System.Windows.Forms.GroupBox();
            this.rbMod4 = new System.Windows.Forms.RadioButton();
            this.txtModOther = new System.Windows.Forms.TextBox();
            this.rbModOther = new System.Windows.Forms.RadioButton();
            this.rbMod3 = new System.Windows.Forms.RadioButton();
            this.rbMod2 = new System.Windows.Forms.RadioButton();
            this.rbMod1 = new System.Windows.Forms.RadioButton();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.cbSched = new System.Windows.Forms.ComboBox();
            this.lblSched = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbClass = new System.Windows.Forms.GroupBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.pnlClassList = new System.Windows.Forms.Panel();
            this.pnlClass = new System.Windows.Forms.Panel();
            this.ImagePicker = new System.Windows.Forms.OpenFileDialog();
            this.btnNoImage = new System.Windows.Forms.Button();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbMutEx = new System.Windows.Forms.ComboBox();
            this.cbRecipe = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnEditPowerData = new System.Windows.Forms.Button();
            this.StaticIndex = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.gbBasic.SuspendLayout();
            this.udMinLevel.BeginInit();
            this.udMaxLevel.BeginInit();
            this.gbType.SuspendLayout();
            this.gbSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbSet).BeginInit();
            this.gbEffects.SuspendLayout();
            this.gbMod.SuspendLayout();
            this.gbClass.SuspendLayout();
            this.SuspendLayout();
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.txtInternal);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.Label9);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.Label7);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.Label6);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.udMinLevel);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.udMaxLevel);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.txtDesc);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.Label4);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.txtNameShort);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.Label3);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.txtNameFull);
            this.gbBasic.Controls.Add((System.Windows.Forms.Control)this.Label2);

            this.gbBasic.Location = new System.Drawing.Point(96, 8);
            this.gbBasic.Name = "gbBasic";

            this.gbBasic.Size = new System.Drawing.Size(248, 169);
            this.gbBasic.TabIndex = 11;
            this.gbBasic.TabStop = false;
            this.gbBasic.Text = "Basic:";

            this.txtInternal.Location = new System.Drawing.Point(84, 68);
            this.txtInternal.Name = "txtInternal";

            this.txtInternal.Size = new System.Drawing.Size(156, 20);
            this.txtInternal.TabIndex = 21;
            this.txtInternal.TextChanged += new System.EventHandler(txtInternal_TextChanged);

            this.Label9.Location = new System.Drawing.Point(8, 68);
            this.Label9.Name = "Label9";

            this.Label9.Size = new System.Drawing.Size(72, 20);
            this.Label9.TabIndex = 20;
            this.Label9.Text = "Internal:";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.Label7.Location = new System.Drawing.Point(134, 140);
            this.Label7.Name = "Label7";

            this.Label7.Size = new System.Drawing.Size(56, 20);
            this.Label7.TabIndex = 19;
            this.Label7.Text = "to";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.Label6.Location = new System.Drawing.Point(6, 140);
            this.Label6.Name = "Label6";

            this.Label6.Size = new System.Drawing.Size(74, 20);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "Level range:";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.udMinLevel.Location = new System.Drawing.Point(84, 140);
            this.udMinLevel.Maximum = new System.Decimal(new int[4] { 53, 0, 0, 0 });
            this.udMinLevel.Minimum = new System.Decimal(new int[4] { 1, 0, 0, 0 });
            this.udMinLevel.Name = "udMinLevel";

            this.udMinLevel.Size = new System.Drawing.Size(44, 20);
            this.udMinLevel.TabIndex = 17;
            this.udMinLevel.Value = new System.Decimal(new int[4] { 1, 0, 0, 0 });
            this.udMinLevel.Leave += new System.EventHandler(udMinLevel_Leave);
            this.udMinLevel.ValueChanged += new System.EventHandler(udMinLevel_ValueChanged);

            this.udMaxLevel.Location = new System.Drawing.Point(196, 140);
            this.udMaxLevel.Maximum = new System.Decimal(new int[4] { 53, 0, 0, 0 });
            this.udMaxLevel.Minimum = new System.Decimal(new int[4] { 1, 0, 0, 0 });
            this.udMaxLevel.Name = "udMaxLevel";

            this.udMaxLevel.Size = new System.Drawing.Size(44, 20);
            this.udMaxLevel.TabIndex = 16;
            this.udMaxLevel.Value = new System.Decimal(new int[4] { 53, 0, 0, 0 });
            this.udMaxLevel.Leave += new System.EventHandler(udMaxLevel_Leave);
            this.udMaxLevel.ValueChanged += new System.EventHandler(udMaxLevel_ValueChanged);

            this.txtDesc.Location = new System.Drawing.Point(84, 94);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";

            this.txtDesc.Size = new System.Drawing.Size(156, 40);
            this.txtDesc.TabIndex = 15;
            this.txtDesc.TextChanged += new System.EventHandler(txtDesc_TextChanged);

            this.Label4.Location = new System.Drawing.Point(8, 98);
            this.Label4.Name = "Label4";

            this.Label4.Size = new System.Drawing.Size(72, 20);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Description:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtNameShort.Location = new System.Drawing.Point(84, 42);
            this.txtNameShort.Name = "txtNameShort";

            this.txtNameShort.Size = new System.Drawing.Size(156, 20);
            this.txtNameShort.TabIndex = 13;
            this.txtNameShort.TextChanged += new System.EventHandler(txtNameShort_TextChanged);

            this.Label3.Location = new System.Drawing.Point(8, 42);
            this.Label3.Name = "Label3";

            this.Label3.Size = new System.Drawing.Size(72, 20);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Short Name:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtNameFull.Location = new System.Drawing.Point(84, 16);
            this.txtNameFull.Name = "txtNameFull";

            this.txtNameFull.Size = new System.Drawing.Size(156, 20);
            this.txtNameFull.TabIndex = 11;
            this.txtNameFull.TextChanged += new System.EventHandler(txtNameFull_TextChanged);

            this.Label2.Location = new System.Drawing.Point(8, 16);
            this.Label2.Name = "Label2";

            this.Label2.Size = new System.Drawing.Size(72, 20);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Full Name:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;

            this.btnImage.Location = new System.Drawing.Point(8, 12);
            this.btnImage.Name = "btnImage";

            this.btnImage.Size = new System.Drawing.Size(80, 68);
            this.btnImage.TabIndex = 9;
            this.btnImage.Text = "ImageName";
            this.btnImage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImage.Click += new System.EventHandler(btnImage_Click);
            this.gbType.Controls.Add((System.Windows.Forms.Control)this.cbSubType);
            this.gbType.Controls.Add((System.Windows.Forms.Control)this.typeSet);
            this.gbType.Controls.Add((System.Windows.Forms.Control)this.typeIO);
            this.gbType.Controls.Add((System.Windows.Forms.Control)this.typeRegular);
            this.gbType.Controls.Add((System.Windows.Forms.Control)this.typeHO);

            this.gbType.Location = new System.Drawing.Point(352, 8);
            this.gbType.Name = "gbType";

            this.gbType.Size = new System.Drawing.Size(140, 169);
            this.gbType.TabIndex = 2;
            this.gbType.TabStop = false;
            this.gbType.Text = "Enhancement Type:";
            this.cbSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbSubType.Location = new System.Drawing.Point(8, 138);
            this.cbSubType.Name = "cbSubType";

            this.cbSubType.Size = new System.Drawing.Size(124, 22);
            this.cbSubType.TabIndex = 54;
            this.cbSubType.SelectedIndexChanged += new System.EventHandler(cbSubType_SelectedIndexChanged);
            this.tTip.SetToolTip((System.Windows.Forms.Control)this.cbSubType, "(Currently only apllicable to Stealth IOs");
            this.typeSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.typeSet.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.typeSet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;

            this.typeSet.Location = new System.Drawing.Point(72, 76);
            this.typeSet.Name = "typeSet";

            this.typeSet.Size = new System.Drawing.Size(60, 56);
            this.typeSet.TabIndex = 53;
            this.typeSet.Text = "IO Set";
            this.typeSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeSet.CheckedChanged += new System.EventHandler(type_CheckedChanged);
            this.typeIO.Appearance = System.Windows.Forms.Appearance.Button;
            this.typeIO.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.typeIO.ImageAlign = System.Drawing.ContentAlignment.TopCenter;

            this.typeIO.Location = new System.Drawing.Point(72, 16);
            this.typeIO.Name = "typeIO";

            this.typeIO.Size = new System.Drawing.Size(60, 56);
            this.typeIO.TabIndex = 52;
            this.typeIO.Text = "Invention";
            this.typeIO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeIO.CheckedChanged += new System.EventHandler(type_CheckedChanged);
            this.typeRegular.Appearance = System.Windows.Forms.Appearance.Button;
            this.typeRegular.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.typeRegular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;

            this.typeRegular.Location = new System.Drawing.Point(8, 16);
            this.typeRegular.Name = "typeRegular";

            this.typeRegular.Size = new System.Drawing.Size(60, 56);
            this.typeRegular.TabIndex = 50;
            this.typeRegular.Text = "Regular";
            this.typeRegular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeRegular.CheckedChanged += new System.EventHandler(type_CheckedChanged);
            this.typeHO.Appearance = System.Windows.Forms.Appearance.Button;
            this.typeHO.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.typeHO.ImageAlign = System.Drawing.ContentAlignment.TopCenter;

            this.typeHO.Location = new System.Drawing.Point(8, 76);
            this.typeHO.Name = "typeHO";

            this.typeHO.Size = new System.Drawing.Size(60, 56);
            this.typeHO.TabIndex = 51;
            this.typeHO.Text = "Special";
            this.typeHO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeHO.CheckedChanged += new System.EventHandler(type_CheckedChanged);
            this.cbSet.Location = new System.Drawing.Point(8, 20);
            this.cbSet.Name = "cbSet";

            this.cbSet.Size = new System.Drawing.Size(168, 22);
            this.cbSet.TabIndex = 13;
            this.cbSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSet.SelectedIndexChanged += new System.EventHandler(cbSet_SelectedIndexChanged);

            this.gbSet.Controls.Add((System.Windows.Forms.Control)this.chkSuperior);
            this.gbSet.Controls.Add((System.Windows.Forms.Control)this.pbSet);
            this.gbSet.Controls.Add((System.Windows.Forms.Control)this.cbSet);
            this.gbSet.Controls.Add((System.Windows.Forms.Control)this.chkUnique);

            this.gbSet.Location = new System.Drawing.Point(496, 8);
            this.gbSet.Name = "gbSet";

            this.gbSet.Size = new System.Drawing.Size(184, 119);
            this.gbSet.TabIndex = 14;
            this.gbSet.TabStop = false;
            this.gbSet.Text = "Invention Origin Set:";

            this.chkSuperior.Location = new System.Drawing.Point(60, 94);
            this.chkSuperior.Name = "chkSuperior";

            this.chkSuperior.Size = new System.Drawing.Size(84, 16);
            this.chkSuperior.TabIndex = 21;
            this.chkSuperior.Text = "Superior";
            this.chkSuperior.CheckedChanged += new System.EventHandler(chkSuperior_CheckedChanged);


            this.pbSet.Location = new System.Drawing.Point(12, 52);
            this.pbSet.Name = "pbSet";

            this.pbSet.Size = new System.Drawing.Size(30, 30);
            this.pbSet.TabIndex = 14;
            this.pbSet.TabStop = false;

            this.chkUnique.Location = new System.Drawing.Point(60, 60);
            this.chkUnique.Name = "chkUnique";

            this.chkUnique.Size = new System.Drawing.Size(84, 16);
            this.chkUnique.TabIndex = 20;
            this.chkUnique.Text = "Unique";
            this.chkUnique.CheckedChanged += new System.EventHandler(chkUnique_CheckedChanged);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnDown);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnUp);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.rbBoth);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.rbDebuff);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.rbBuff);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnAutoFill);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.Label5);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.txtProb);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.Label1);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnEdit);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnAddFX);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnRemove);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.btnAdd);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.gbMod);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.lstSelected);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.lstAvailable);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.cbSched);
            this.gbEffects.Controls.Add((System.Windows.Forms.Control)this.lblSched);

            this.gbEffects.Location = new System.Drawing.Point(4, 210);
            this.gbEffects.Name = "gbEffects";

            this.gbEffects.Size = new System.Drawing.Size(584, 284);
            this.gbEffects.TabIndex = 15;
            this.gbEffects.TabStop = false;
            this.gbEffects.Text = "Effects:";

            this.btnDown.Location = new System.Drawing.Point(188, 172);
            this.btnDown.Name = "btnDown";

            this.btnDown.Size = new System.Drawing.Size(48, 20);
            this.btnDown.TabIndex = 32;
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(btnDown_Click);
            this.btnUp.Location = new System.Drawing.Point(188, 148);
            this.btnUp.Name = "btnUp";

            this.btnUp.Size = new System.Drawing.Size(48, 20);
            this.btnUp.TabIndex = 31;
            this.btnUp.Text = "Up";
            this.btnUp.Click += new System.EventHandler(btnUp_Click);
            this.rbBoth.Checked = true;

            this.rbBoth.Location = new System.Drawing.Point(428, 228);
            this.rbBoth.Name = "rbBoth";

            this.rbBoth.Size = new System.Drawing.Size(148, 16);
            this.rbBoth.TabIndex = 30;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Buff/Debuff Effects";
            this.rbBoth.CheckedChanged += new System.EventHandler(rbBuffDebuff_CheckedChanged);

            this.tTip.SetToolTip((System.Windows.Forms.Control)this.rbBoth, "Apply to effects regardles of whether the Mag is positive or negative");

            this.rbDebuff.Location = new System.Drawing.Point(428, 212);
            this.rbDebuff.Name = "rbDebuff";

            this.rbDebuff.Size = new System.Drawing.Size(148, 16);
            this.rbDebuff.TabIndex = 29;
            this.rbDebuff.Text = "Debuff Effects";
            this.rbDebuff.CheckedChanged += new System.EventHandler(rbBuffDebuff_CheckedChanged);
            this.tTip.SetToolTip((System.Windows.Forms.Control)this.rbDebuff, "Apply only to effects with a negative Mag");

            this.rbBuff.Location = new System.Drawing.Point(428, 196);
            this.rbBuff.Name = "rbBuff";

            this.rbBuff.Size = new System.Drawing.Size(148, 16);
            this.rbBuff.TabIndex = 28;
            this.rbBuff.Text = "Buff Effects";
            this.rbBuff.CheckedChanged += new System.EventHandler(rbBuffDebuff_CheckedChanged);
            this.tTip.SetToolTip((System.Windows.Forms.Control)this.rbBuff, "Apply only to effects with a positive Mag");

            this.btnAutoFill.Location = new System.Drawing.Point(128, 24);
            this.btnAutoFill.Name = "btnAutoFill";

            this.btnAutoFill.Size = new System.Drawing.Size(108, 32);
            this.btnAutoFill.TabIndex = 27;
            this.btnAutoFill.Text = "AutoFill Names";
            this.btnAutoFill.Click += new System.EventHandler(btnAutoFill_Click);
            this.Label5.Location = new System.Drawing.Point(196, 244);
            this.Label5.Name = "Label5";

            this.Label5.Size = new System.Drawing.Size(28, 20);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "(0-1)";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtProb.Location = new System.Drawing.Point(156, 244);
            this.txtProb.Name = "txtProb";

            this.txtProb.Size = new System.Drawing.Size(36, 20);
            this.txtProb.TabIndex = 25;
            this.txtProb.Text = "1";
            this.txtProb.Leave += new System.EventHandler(txtProb_Leave);
            this.txtProb.TextChanged += new System.EventHandler(txtProb_TextChanged);

            this.Label1.Location = new System.Drawing.Point(8, 244);
            this.Label1.Name = "Label1";

            this.Label1.Size = new System.Drawing.Size(148, 20);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Special Effect Probability:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnEdit.Location = new System.Drawing.Point(424, 248);
            this.btnEdit.Name = "btnEdit";

            this.btnEdit.Size = new System.Drawing.Size(152, 28);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Edit Selected...";
            this.btnEdit.Click += new System.EventHandler(btnEdit_Click);
            this.btnAddFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnAddFX.Location = new System.Drawing.Point(8, 208);
            this.btnAddFX.Name = "btnAddFX";

            this.btnAddFX.Size = new System.Drawing.Size(228, 28);
            this.btnAddFX.TabIndex = 22;
            this.btnAddFX.Text = "Add Special Effect... ->";
            this.btnAddFX.Click += new System.EventHandler(btnAddFX_Click);
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnRemove.Location = new System.Drawing.Point(240, 248);
            this.btnRemove.Name = "btnRemove";

            this.btnRemove.Size = new System.Drawing.Size(176, 28);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "Remove Selected";
            this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

            this.btnAdd.Location = new System.Drawing.Point(128, 100);
            this.btnAdd.Name = "btnAdd";

            this.btnAdd.Size = new System.Drawing.Size(108, 28);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add ->";
            this.btnAdd.Click += new System.EventHandler(btnAdd_Click);
            this.gbMod.Controls.Add((System.Windows.Forms.Control)this.rbMod4);
            this.gbMod.Controls.Add((System.Windows.Forms.Control)this.txtModOther);
            this.gbMod.Controls.Add((System.Windows.Forms.Control)this.rbModOther);
            this.gbMod.Controls.Add((System.Windows.Forms.Control)this.rbMod3);
            this.gbMod.Controls.Add((System.Windows.Forms.Control)this.rbMod2);
            this.gbMod.Controls.Add((System.Windows.Forms.Control)this.rbMod1);

            this.gbMod.Location = new System.Drawing.Point(424, 44);
            this.gbMod.Name = "gbMod";

            this.gbMod.Size = new System.Drawing.Size(152, 148);
            this.gbMod.TabIndex = 19;
            this.gbMod.TabStop = false;
            this.gbMod.Text = "Effect Modifier:";

            this.rbMod4.Location = new System.Drawing.Point(12, 80);
            this.rbMod4.Name = "rbMod4";

            this.rbMod4.Size = new System.Drawing.Size(128, 20);
            this.rbMod4.TabIndex = 5;
            this.rbMod4.Text = "0.4375 (4-Effect IO)";
            this.rbMod4.CheckedChanged += new System.EventHandler(rbMod_CheckedChanged);
            this.txtModOther.Enabled = false;

            this.txtModOther.Location = new System.Drawing.Point(28, 120);
            this.txtModOther.Name = "txtModOther";

            this.txtModOther.Size = new System.Drawing.Size(112, 20);
            this.txtModOther.TabIndex = 4;
            this.txtModOther.TextChanged += new System.EventHandler(txtModOther_TextChanged);

            this.rbModOther.Location = new System.Drawing.Point(12, 100);
            this.rbModOther.Name = "rbModOther";

            this.rbModOther.Size = new System.Drawing.Size(128, 20);
            this.rbModOther.TabIndex = 3;
            this.rbModOther.Text = "Other";
            this.rbModOther.CheckedChanged += new System.EventHandler(rbMod_CheckedChanged);


            this.rbMod3.Location = new System.Drawing.Point(12, 60);
            this.rbMod3.Name = "rbMod3";

            this.rbMod3.Size = new System.Drawing.Size(128, 20);
            this.rbMod3.TabIndex = 2;
            this.rbMod3.Text = "0.5 (3-Effect IO)";
            this.rbMod3.CheckedChanged += new System.EventHandler(rbMod_CheckedChanged);
            this.rbMod2.Location = new System.Drawing.Point(12, 40);
            this.rbMod2.Name = "rbMod2";

            this.rbMod2.Size = new System.Drawing.Size(128, 20);
            this.rbMod2.TabIndex = 1;
            this.rbMod2.Text = "0.625 (2-Effect IO)";
            this.rbMod2.CheckedChanged += new System.EventHandler(rbMod_CheckedChanged);
            this.rbMod1.Checked = true;

            this.rbMod1.Location = new System.Drawing.Point(12, 20);
            this.rbMod1.Name = "rbMod1";

            this.rbMod1.Size = new System.Drawing.Size(128, 20);
            this.rbMod1.TabIndex = 0;
            this.rbMod1.TabStop = true;
            this.rbMod1.Text = "1.0 (No modifier)";
            this.rbMod1.CheckedChanged += new System.EventHandler(rbMod_CheckedChanged);
            this.lstSelected.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lstSelected.ItemHeight = 14;

            this.lstSelected.Location = new System.Drawing.Point(240, 20);
            this.lstSelected.Name = "lstSelected";

            this.lstSelected.Size = new System.Drawing.Size(176, 214);
            this.lstSelected.TabIndex = 16;
            this.lstSelected.SelectedIndexChanged += new System.EventHandler(lstSelected_SelectedIndexChanged);
            this.lstAvailable.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lstAvailable.ItemHeight = 14;

            this.lstAvailable.Location = new System.Drawing.Point(8, 20);
            this.lstAvailable.Name = "lstAvailable";

            this.lstAvailable.Size = new System.Drawing.Size(116, 172);
            this.lstAvailable.TabIndex = 15;
            this.lstAvailable.DoubleClick += new System.EventHandler(lstAvailable_DoubleClick);
            this.cbSched.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbSched.Location = new System.Drawing.Point(488, 20);
            this.cbSched.Name = "cbSched";

            this.cbSched.Size = new System.Drawing.Size(88, 22);
            this.cbSched.TabIndex = 14;
            this.cbSched.SelectedIndexChanged += new System.EventHandler(cbSched_SelectedIndexChanged);

            this.lblSched.Location = new System.Drawing.Point(424, 20);
            this.lblSched.Name = "lblSched";

            this.lblSched.Size = new System.Drawing.Size(64, 20);
            this.lblSched.TabIndex = 3;
            this.lblSched.Text = "Schedule:";
            this.lblSched.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.btnOK.Location = new System.Drawing.Point(596, 434);
            this.btnOK.Name = "btnOK";

            this.btnOK.Size = new System.Drawing.Size(84, 28);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(btnOK_Click);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.btnCancel.Location = new System.Drawing.Point(596, 466);
            this.btnCancel.Name = "btnCancel";

            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            this.gbClass.Controls.Add((System.Windows.Forms.Control)this.lblClass);
            this.gbClass.Controls.Add((System.Windows.Forms.Control)this.pnlClassList);
            this.gbClass.Controls.Add((System.Windows.Forms.Control)this.pnlClass);

            this.gbClass.Location = new System.Drawing.Point(596, 178);
            this.gbClass.Name = "gbClass";

            this.gbClass.Size = new System.Drawing.Size(84, 252);
            this.gbClass.TabIndex = 18;
            this.gbClass.TabStop = false;
            this.gbClass.Text = "Class(es):";

            this.lblClass.Location = new System.Drawing.Point(8, 232);
            this.lblClass.Name = "lblClass";

            this.lblClass.Size = new System.Drawing.Size(68, 16);
            this.lblClass.TabIndex = 2;
            this.pnlClassList.BackColor = System.Drawing.Color.Black;

            this.pnlClassList.Location = new System.Drawing.Point(84, 16);
            this.pnlClassList.Name = "pnlClassList";

            this.pnlClassList.Size = new System.Drawing.Size(180, 212);
            this.pnlClassList.TabIndex = 1;
            this.pnlClass.BackColor = System.Drawing.Color.Black;

            this.pnlClass.Location = new System.Drawing.Point(8, 16);
            this.pnlClass.Name = "pnlClass";

            this.pnlClass.Size = new System.Drawing.Size(68, 212);
            this.pnlClass.TabIndex = 0;
            this.ImagePicker.Filter = "PNG Images|*.png";
            this.ImagePicker.Title = "Select Image File";

            this.btnNoImage.Location = new System.Drawing.Point(8, 84);
            this.btnNoImage.Name = "btnNoImage";

            this.btnNoImage.Size = new System.Drawing.Size(80, 20);
            this.btnNoImage.TabIndex = 19;
            this.btnNoImage.Text = "Clear Image";
            this.btnNoImage.Click += new System.EventHandler(btnNoImage_Click);
            this.tTip.AutoPopDelay = 10000;
            this.tTip.InitialDelay = 250;
            this.tTip.ReshowDelay = 100;
            this.cbMutEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbMutEx.Location = new System.Drawing.Point(504, 146);
            this.cbMutEx.Name = "cbMutEx";

            this.cbMutEx.Size = new System.Drawing.Size(168, 22);
            this.cbMutEx.TabIndex = 21;
            this.cbMutEx.SelectedIndexChanged += new System.EventHandler(cbMutEx_SelectedIndexChanged);
            this.tTip.SetToolTip((System.Windows.Forms.Control)this.cbMutEx, "(Currently only apllicable to Stealth IOs");
            this.cbRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbRecipe.Location = new System.Drawing.Point(96, 183);
            this.cbRecipe.Name = "cbRecipe";

            this.cbRecipe.Size = new System.Drawing.Size(248, 22);
            this.cbRecipe.TabIndex = 23;
            this.cbRecipe.SelectedIndexChanged += new System.EventHandler(cbRecipe_SelectedIndexChanged);
            this.tTip.SetToolTip((System.Windows.Forms.Control)this.cbRecipe, "(Currently only apllicable to Stealth IOs");

            this.Label8.Location = new System.Drawing.Point(496, 130);
            this.Label8.Name = "Label8";

            this.Label8.Size = new System.Drawing.Size(80, 16);
            this.Label8.TabIndex = 22;
            this.Label8.Text = "MutEx Group:";

            this.Label10.Location = new System.Drawing.Point(10, 183);
            this.Label10.Name = "Label10";

            this.Label10.Size = new System.Drawing.Size(80, 22);
            this.Label10.TabIndex = 24;
            this.Label10.Text = "Recipe:";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.btnEditPowerData.Location = new System.Drawing.Point(352, 183);
            this.btnEditPowerData.Name = "btnEditPowerData";

            this.btnEditPowerData.Size = new System.Drawing.Size(236, 22);
            this.btnEditPowerData.TabIndex = 25;
            this.btnEditPowerData.Text = "Edit Power_Mode Data";
            this.btnEditPowerData.UseVisualStyleBackColor = true;
            this.btnEditPowerData.Click += new System.EventHandler(btnEditPowerData_Click);

            this.StaticIndex.Location = new System.Drawing.Point(8, 146);
            this.StaticIndex.Name = "StaticIndex";

            this.StaticIndex.Size = new System.Drawing.Size(82, 20);
            this.StaticIndex.TabIndex = 26;
            this.StaticIndex.TextChanged += new System.EventHandler(StaticIndex_TextChanged);
            this.Label11.AutoSize = true;

            this.Label11.Location = new System.Drawing.Point(8, 126);
            this.Label11.Name = "Label11";

            this.Label11.Size = new System.Drawing.Size(63, 14);
            this.Label11.TabIndex = 27;
            this.Label11.Text = "Static Index";
            this.AcceptButton = (System.Windows.Forms.IButtonControl)this.btnOK;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = (System.Windows.Forms.IButtonControl)this.btnCancel;

            this.ClientSize = new System.Drawing.Size(686, 501);
            this.Controls.Add((System.Windows.Forms.Control)this.Label11);
            this.Controls.Add((System.Windows.Forms.Control)this.StaticIndex);
            this.Controls.Add((System.Windows.Forms.Control)this.btnEditPowerData);
            this.Controls.Add((System.Windows.Forms.Control)this.Label10);
            this.Controls.Add((System.Windows.Forms.Control)this.cbRecipe);
            this.Controls.Add((System.Windows.Forms.Control)this.Label8);
            this.Controls.Add((System.Windows.Forms.Control)this.btnNoImage);
            this.Controls.Add((System.Windows.Forms.Control)this.gbClass);
            this.Controls.Add((System.Windows.Forms.Control)this.btnCancel);
            this.Controls.Add((System.Windows.Forms.Control)this.btnOK);
            this.Controls.Add((System.Windows.Forms.Control)this.gbEffects);
            this.Controls.Add((System.Windows.Forms.Control)this.gbSet);
            this.Controls.Add((System.Windows.Forms.Control)this.gbBasic);
            this.Controls.Add((System.Windows.Forms.Control)this.gbType);
            this.Controls.Add((System.Windows.Forms.Control)this.btnImage);
            this.Controls.Add((System.Windows.Forms.Control)this.cbMutEx);
            this.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit [EnhancementName]";
            this.gbBasic.ResumeLayout(false);
            this.gbBasic.PerformLayout();
            this.udMinLevel.EndInit();
            this.udMaxLevel.EndInit();
            this.gbType.ResumeLayout(false);
            this.gbSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.pbSet).EndInit();
            this.gbEffects.ResumeLayout(false);
            this.gbEffects.PerformLayout();
            this.gbMod.ResumeLayout(false);
            this.gbMod.PerformLayout();
            this.gbClass.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        System.Windows.Forms.Button btnAdd;
        System.Windows.Forms.Button btnAddFX;
        System.Windows.Forms.Button btnAutoFill;
        System.Windows.Forms.Button btnCancel;
        System.Windows.Forms.Button btnDown;
        System.Windows.Forms.Button btnEdit;
        System.Windows.Forms.Button btnEditPowerData;
        System.Windows.Forms.Button btnImage;
        System.Windows.Forms.Button btnNoImage;
        System.Windows.Forms.Button btnOK;
        System.Windows.Forms.Button btnRemove;
        System.Windows.Forms.Button btnUp;
        System.Windows.Forms.ComboBox cbMutEx;
        System.Windows.Forms.ComboBox cbRecipe;
        System.Windows.Forms.ComboBox cbSched;
        System.Windows.Forms.ComboBox cbSet;
        System.Windows.Forms.ComboBox cbSubType;
        System.Windows.Forms.CheckBox chkSuperior;
        System.Windows.Forms.CheckBox chkUnique;
        System.Windows.Forms.GroupBox gbBasic;
        System.Windows.Forms.GroupBox gbClass;
        System.Windows.Forms.GroupBox gbEffects;
        System.Windows.Forms.GroupBox gbMod;
        System.Windows.Forms.GroupBox gbSet;
        System.Windows.Forms.GroupBox gbType;
        System.Windows.Forms.OpenFileDialog ImagePicker;
        System.Windows.Forms.Label Label1;
        System.Windows.Forms.Label Label10;
        System.Windows.Forms.Label Label11;
        System.Windows.Forms.Label Label2;
        System.Windows.Forms.Label Label3;
        System.Windows.Forms.Label Label4;
        System.Windows.Forms.Label Label5;
        System.Windows.Forms.Label Label6;
        System.Windows.Forms.Label Label7;
        System.Windows.Forms.Label Label8;
        System.Windows.Forms.Label Label9;
        System.Windows.Forms.Label lblClass;
        System.Windows.Forms.Label lblSched;
        System.Windows.Forms.ListBox lstAvailable;
        System.Windows.Forms.ListBox lstSelected;
        System.Windows.Forms.PictureBox pbSet;
        System.Windows.Forms.Panel pnlClass;
        System.Windows.Forms.Panel pnlClassList;
        System.Windows.Forms.RadioButton rbBoth;
        System.Windows.Forms.RadioButton rbBuff;
        System.Windows.Forms.RadioButton rbDebuff;
        System.Windows.Forms.RadioButton rbMod1;
        System.Windows.Forms.RadioButton rbMod2;
        System.Windows.Forms.RadioButton rbMod3;
        System.Windows.Forms.RadioButton rbMod4;
        System.Windows.Forms.RadioButton rbModOther;
        System.Windows.Forms.TextBox StaticIndex;
        System.Windows.Forms.ToolTip tTip;
        System.Windows.Forms.TextBox txtDesc;
        System.Windows.Forms.TextBox txtInternal;
        System.Windows.Forms.TextBox txtModOther;
        System.Windows.Forms.TextBox txtNameFull;
        System.Windows.Forms.TextBox txtNameShort;
        System.Windows.Forms.TextBox txtProb;
        System.Windows.Forms.RadioButton typeHO;
        System.Windows.Forms.RadioButton typeIO;
        System.Windows.Forms.RadioButton typeRegular;
        System.Windows.Forms.RadioButton typeSet;
        System.Windows.Forms.NumericUpDown udMaxLevel;
        System.Windows.Forms.NumericUpDown udMinLevel;
    }
}