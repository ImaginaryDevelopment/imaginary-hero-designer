
using Base.Data_Classes;
using Base.Display;
using HeroDesigner.Schema;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmEnhData : Form
    {
        Button btnAdd;

        Button btnAddFX;

        Button btnAutoFill;

        Button btnCancel;

        Button btnDown;

        Button btnEdit;

        Button btnEditPowerData;

        Button btnImage;

        Button btnNoImage;

        Button btnOK;

        Button btnRemove;

        Button btnUp;

        ComboBox cbMutEx;

        ComboBox cbRecipe;

        ComboBox cbSched;

        ComboBox cbSet;

        ComboBox cbSubType;

        CheckBox chkSuperior;

        CheckBox chkUnique;
        GroupBox gbBasic;
        GroupBox gbClass;
        GroupBox gbEffects;
        GroupBox gbMod;
        GroupBox gbSet;
        GroupBox gbType;
        OpenFileDialog ImagePicker;
        Label Label1;
        Label Label10;
        Label Label11;
        Label Label2;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;
        Label Label8;
        Label Label9;
        Label lblClass;
        Label lblSched;

        ListBox lstAvailable;

        ListBox lstSelected;
        PictureBox pbSet;

        Panel pnlClass;

        Panel pnlClassList;

        RadioButton rbBoth;

        RadioButton rbBuff;

        RadioButton rbDebuff;

        RadioButton rbMod1;

        RadioButton rbMod2;

        RadioButton rbMod3;

        RadioButton rbMod4;

        RadioButton rbModOther;

        TextBox StaticIndex;
        ToolTip tTip;

        TextBox txtDesc;

        TextBox txtInternal;

        TextBox txtModOther;

        TextBox txtNameFull;

        TextBox txtNameShort;

        TextBox txtProb;

        RadioButton typeHO;

        RadioButton typeIO;

        RadioButton typeRegular;

        RadioButton typeSet;

        NumericUpDown udMaxLevel;

        NumericUpDown udMinLevel;

        protected ExtendedBitmap bxClass;
        protected ExtendedBitmap bxClassList;
        protected int ClassSize;

        protected int EnhAcross;
        protected int EnhPadding;
        protected bool Loading;
        public IEnhancement myEnh;

        public frmEnhData(ref IEnhancement iEnh)
        {
            this.Load += new EventHandler(this.frmEnhData_Load);
            this.ClassSize = 15;
            this.EnhPadding = 3;
            this.EnhAcross = 5;
            this.Loading = true;
            this.InitializeComponent();
            this.myEnh = (IEnhancement)new Enhancement(iEnh);
            this.ClassSize = 22;
        }

        void btnAdd_Click(object sender, EventArgs e)

        {
            this.EffectList_Add();
        }

        void btnAddFX_Click(object sender, EventArgs e)

        {
            IEffect iFX = new Effect();
            frmPowerEffect frmPowerEffect = new frmPowerEffect(iFX);
            if (frmPowerEffect.ShowDialog() != DialogResult.OK)
                return;
            IEnhancement enh = this.myEnh;
            Enums.sEffect[] sEffectArray = (Enums.sEffect[])Utils.CopyArray((Array)enh.Effect, (Array)new Enums.sEffect[this.myEnh.Effect.Length + 1]);
            enh.Effect = sEffectArray;
            Enums.sEffect[] effect = this.myEnh.Effect;
            int index = this.myEnh.Effect.Length - 1;
            effect[index].Mode = eEffMode.FX;
            effect[index].Enhance.ID = -1;
            effect[index].Enhance.SubID = -1;
            effect[index].Multiplier = 1f;
            effect[index].Schedule = eSchedule.A;
            effect[index].FX = (IEffect)frmPowerEffect.myFX.Clone();
            effect[index].FX.isEnahncementEffect = true;
            this.ListSelectedEffects();
            this.lstSelected.SelectedIndex = this.lstSelected.Items.Count - 1;
        }

        void btnAutoFill_Click(object sender, EventArgs e)

        {
            eEnhance eEnhance = eEnhance.None;
            eEnhanceShort eEnhanceShort = eEnhanceShort.None;
            eMez eMez = eMez.None;
            eMezShort eMezShort = eMezShort.None;
            string[] names1 = Enum.GetNames(eEnhance.GetType());
            string[] names2 = Enum.GetNames(eEnhanceShort.GetType());
            string[] names3 = Enum.GetNames(eMez.GetType());
            string[] names4 = Enum.GetNames(eMezShort.GetType());
            this.myEnh.Name = "";
            this.myEnh.ShortName = "";
            names1[4] = "Endurance";
            names1[18] = "Resistance";
            names1[5] = "EndMod";
            names2[18] = "ResDam";
            names3[2] = "Hold";
            names4[2] = "Hold";
            if (this.myEnh.TypeID == eType.SetO & this.myEnh.nIDSet > -1 & this.myEnh.nIDSet < DatabaseAPI.Database.EnhancementSets.Count - 1)
                this.myEnh.UID = DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].DisplayName.Replace(" ", "_") + "_";
            int num1 = 0;
            int num2 = this.myEnh.Effect.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.myEnh.Effect[index].Mode == eEffMode.Enhancement)
                {
                    ++num1;
                    eEnhance id = (eEnhance)this.myEnh.Effect[index].Enhance.ID;
                    if (id != eEnhance.Mez)
                    {
                        if (this.myEnh.Name != "")
                            this.myEnh.Name += "/";
                        this.myEnh.Name += names1[(int)id];
                        if (this.myEnh.ShortName != "")
                            this.myEnh.ShortName += "/";
                        this.myEnh.ShortName += names2[(int)id];
                    }
                    else
                    {
                        if (this.myEnh.Name != "")
                            this.myEnh.Name += "/";
                        this.myEnh.Name += names3[this.myEnh.Effect[index].Enhance.SubID];
                        if (this.myEnh.ShortName != "")
                            this.myEnh.ShortName += "/";
                        this.myEnh.ShortName += names4[this.myEnh.Effect[index].Enhance.SubID];
                    }
                }
            }
            float num3 = 1f;
            switch (num1)
            {
                case 2:
                    num3 = 0.625f;
                    break;
                case 3:
                    num3 = 0.5f;
                    break;
                case 4:
                    num3 = 7f / 16f;
                    break;
            }
            int num4 = this.myEnh.Effect.Length - 1;
            for (int index = 0; index <= num4; ++index)
            {
                if (this.myEnh.Effect[index].Mode == eEffMode.Enhancement)
                    this.myEnh.Effect[index].Multiplier = num3;
            }
            this.DisplayAll();
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnDown_Click(object sender, EventArgs e)

        {
            if (this.lstSelected.SelectedIndices.Count <= 0)
                return;
            int selectedIndex = this.lstSelected.SelectedIndices[0];
            if (selectedIndex < this.lstSelected.Items.Count - 1)
            {
                var sEffectArray = new Enums.sEffect[2];
                sEffectArray[0].Assign(this.myEnh.Effect[selectedIndex]);
                sEffectArray[1].Assign(this.myEnh.Effect[selectedIndex + 1]);
                this.myEnh.Effect[selectedIndex + 1].Assign(sEffectArray[0]);
                this.myEnh.Effect[selectedIndex].Assign(sEffectArray[1]);
                this.FillEffectList();
                this.ListSelectedEffects();
                this.lstSelected.SelectedIndex = selectedIndex + 1;
            }
        }

        void btnEdit_Click(object sender, EventArgs e)

        {
            this.EditClick();
        }

        void btnEditPowerData_Click(object sender, EventArgs e)

        {
            IEnhancement enh = this.myEnh;
            IPower power = enh.GetPower();
            frmEditPower frmEditPower = new frmEditPower(power);
            if (frmEditPower.ShowDialog() != DialogResult.OK)
                return;
            power = new Power(frmEditPower.myPower);
            // could really use structural equality here, but since we don't have it... we'll mark it as modified just because :/
            power.IsModified = true;
            int num = power.Effects.Length - 1;
            for (int index = 0; index <= num; ++index)
                power.Effects[index].PowerFullName = power.FullName;
            this.myEnh.SetPower(power);
        }

        void btnImage_Click(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.ImagePicker.InitialDirectory = I9Gfx.GetEnhancementsPath();
            this.ImagePicker.FileName = this.myEnh.Image;
            if (this.ImagePicker.ShowDialog() == DialogResult.OK)
            {
                string str = FileIO.StripPath(this.ImagePicker.FileName);
                if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
                {
                    int num = (int)Interaction.MsgBox(("You must select an image from the " + I9Gfx.GetEnhancementsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it."), MsgBoxStyle.Information, "Ah...");
                }
                else
                {
                    this.myEnh.Image = str;
                    this.DisplayIcon();
                    this.SetTypeIcons();
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
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void btnRemove_Click(object sender, EventArgs e)

        {
            if (this.lstSelected.SelectedIndex <= -1)
                return;
            Enums.sEffect[] sEffectArray = new Enums.sEffect[this.myEnh.Effect.Length - 1 + 1];
            int selectedIndex = this.lstSelected.SelectedIndex;
            int index1 = 0;
            int num1 = this.myEnh.Effect.Length - 1;
            for (int index2 = 0; index2 <= num1; ++index2)
            {
                if (index2 != selectedIndex)
                {
                    sEffectArray[index1].Assign(this.myEnh.Effect[index2]);
                    ++index1;
                }
            }
            this.myEnh.Effect = new Enums.sEffect[this.myEnh.Effect.Length - 2 + 1];
            int num2 = this.myEnh.Effect.Length - 1;
            for (int index2 = 0; index2 <= num2; ++index2)
                this.myEnh.Effect[index2].Assign(sEffectArray[index2]);
            this.FillEffectList();
            this.ListSelectedEffects();
            if (this.lstSelected.Items.Count > selectedIndex)
                this.lstSelected.SelectedIndex = selectedIndex;
            else if (this.lstSelected.Items.Count == selectedIndex)
                this.lstSelected.SelectedIndex = selectedIndex - 1;
        }

        void btnUp_Click(object sender, EventArgs e)

        {
            if (this.lstSelected.SelectedIndices.Count <= 0)
                return;
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

        void cbMutEx_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.MutExID = (eEnhMutex)this.cbMutEx.SelectedIndex;
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
            if (this.lstSelected.SelectedIndex <= -1)
                return;
            int selectedIndex = this.lstSelected.SelectedIndex;
            if (this.myEnh.Effect[selectedIndex].Mode == eEffMode.Enhancement)
                this.myEnh.Effect[selectedIndex].Schedule = (eSchedule)this.cbSched.SelectedIndex;
        }

        void cbSet_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.nIDSet = this.cbSet.SelectedIndex - 1;
            this.myEnh.UIDSet = this.myEnh.nIDSet <= -1 ? string.Empty : DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Uid;
            this.UpdateTitle();
            this.DisplaySetImage();
        }

        void cbSubType_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.myEnh.SubTypeID = (eSubtype)this.cbSubType.SelectedIndex;
        }

        void chkSuperior_CheckedChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.Superior = this.chkSuperior.Checked;
            if (this.chkSuperior.Checked)
            {
                this.myEnh.LevelMin = 49;
                this.myEnh.LevelMax = 49;
                this.udMinLevel.Value = new Decimal(50);
                this.udMaxLevel.Value = new Decimal(50);
            }
            this.chkUnique.Checked = true;
        }

        void chkUnique_CheckedChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.Unique = this.chkUnique.Checked;
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
                case eType.Normal:
                    this.typeRegular.Checked = true;
                    this.cbSubType.SelectedIndex = -1;
                    this.cbSubType.Enabled = false;
                    this.cbRecipe.SelectedIndex = 0;
                    this.cbRecipe.Enabled = false;
                    break;
                case eType.InventO:
                    this.typeIO.Checked = true;
                    this.cbSubType.SelectedIndex = -1;
                    this.cbSubType.Enabled = false;
                    this.cbRecipe.SelectedIndex = this.myEnh.RecipeIDX + 1;
                    this.cbRecipe.Enabled = true;
                    break;
                case eType.SpecialO:
                    this.typeHO.Checked = true;
                    this.cbSubType.SelectedIndex = (int)this.myEnh.SubTypeID;
                    this.cbSubType.Enabled = true;
                    this.cbRecipe.Enabled = false;
                    this.cbRecipe.SelectedIndex = 0;
                    break;
                case eType.SetO:
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
                if (this.myEnh.Effect[selectedIndex].Mode != eEffMode.Enhancement)
                {
                    this.btnEdit.Enabled = true;
                    this.gbMod.Enabled = false;
                    this.cbSched.Enabled = false;
                }
                else
                {
                    if (this.myEnh.Effect[selectedIndex].Enhance.ID == 12)
                        this.btnEdit.Enabled = true;
                    else
                        this.btnEdit.Enabled = false;
                    this.gbMod.Enabled = true;
                    this.cbSched.Enabled = true;
                    switch (this.myEnh.Effect[selectedIndex].Multiplier.ToString())
                    {
                        case "1":
                            this.rbMod1.Checked = true;
                            this.txtModOther.Text = "";
                            this.txtModOther.Enabled = false;
                            break;
                        case "0.625":
                            this.rbMod2.Checked = true;
                            this.txtModOther.Text = "";
                            this.txtModOther.Enabled = false;
                            break;
                        case "0.5":
                            this.rbMod3.Checked = true;
                            this.txtModOther.Text = "";
                            this.txtModOther.Enabled = false;
                            break;
                        default:
                            this.txtModOther.Text = Conversions.ToString(this.myEnh.Effect[selectedIndex].Multiplier);
                            this.rbModOther.Checked = true;
                            this.txtModOther.Enabled = true;
                            break;
                    }
                    switch (this.myEnh.Effect[selectedIndex].BuffMode)
                    {
                        case eBuffDebuff.BuffOnly:
                            this.rbBuff.Checked = true;
                            break;
                        case eBuffDebuff.DeBuffOnly:
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
                ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.myEnh.Image);
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                extendedBitmap2.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(this.myEnh.TypeID)), System.Drawing.GraphicsUnit.Pixel);
                extendedBitmap2.Graphics.DrawImage((Image)extendedBitmap1.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, System.Drawing.GraphicsUnit.Pixel);
                this.btnImage.Image = (Image)new Bitmap((Image)extendedBitmap2.Bitmap);
                this.btnImage.Text = this.myEnh.Image;
            }
            else
            {
                switch (this.myEnh.TypeID)
                {
                    case eType.Normal:
                        this.btnImage.Image = this.typeRegular.Image;
                        break;
                    case eType.InventO:
                        this.btnImage.Image = this.typeIO.Image;
                        break;
                    case eType.SpecialO:
                        this.btnImage.Image = this.typeHO.Image;
                        break;
                    case eType.SetO:
                        this.btnImage.Image = this.typeSet.Image;
                        break;
                }
                this.btnImage.Text = "Select Image";
            }
        }

        public void DisplaySet()
        {
            this.gbSet.Enabled = this.myEnh.TypeID == eType.SetO;
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
                    ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].Image);
                    ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                    extendedBitmap2.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), System.Drawing.GraphicsUnit.Pixel);
                    extendedBitmap2.Graphics.DrawImage((Image)extendedBitmap1.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, System.Drawing.GraphicsUnit.Pixel);
                    this.pbSet.Image = (Image)new Bitmap((Image)extendedBitmap2.Bitmap);
                }
                else
                {
                    ExtendedBitmap extendedBitmap = new ExtendedBitmap(30, 30);
                    extendedBitmap.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), System.Drawing.GraphicsUnit.Pixel);
                    this.pbSet.Image = (Image)new Bitmap((Image)extendedBitmap.Bitmap);
                }
            }
            else
                this.pbSet.Image = (Image)new Bitmap(this.pbSet.Width, this.pbSet.Height);
        }

        public void DrawClasses()
        {
            this.bxClass = new ExtendedBitmap(this.pnlClass.Width, this.pnlClass.Height);
            int enhPadding1 = this.EnhPadding;
            int enhPadding2 = this.EnhPadding;
            int num1 = 0;
            this.bxClass.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxClass.ClipRect);
            int num2 = this.myEnh.ClassID.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, this.ClassSize, this.ClassSize);
                this.bxClass.Graphics.DrawImage((Image)I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(this.myEnh.ClassID[index]), System.Drawing.GraphicsUnit.Pixel);
                enhPadding2 += this.ClassSize + this.EnhPadding;
                ++num1;
                if (num1 == 2)
                {
                    num1 = 0;
                    enhPadding2 = this.EnhPadding;
                    enhPadding1 += this.ClassSize + this.EnhPadding;
                }
            }
            this.pnlClass.CreateGraphics().DrawImageUnscaled((Image)this.bxClass.Bitmap, 0, 0);
        }

        public void DrawClassList()
        {
            this.bxClassList = new ExtendedBitmap(this.pnlClassList.Width, this.pnlClassList.Height);
            int enhPadding1 = this.EnhPadding;
            int enhPadding2 = this.EnhPadding;
            int num1 = 0;
            this.bxClassList.Graphics.FillRectangle((Brush)new SolidBrush(Color.FromArgb(0, 0, 0)), this.bxClassList.ClipRect);
            int num2 = DatabaseAPI.Database.EnhancementClasses.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                Rectangle destRect = new Rectangle(enhPadding2, enhPadding1, 30, 30);
                this.bxClassList.Graphics.DrawImage((Image)I9Gfx.Classes.Bitmap, destRect, I9Gfx.GetImageRect(index), System.Drawing.GraphicsUnit.Pixel);
                enhPadding2 += 30 + this.EnhPadding;
                ++num1;
                if (num1 == this.EnhAcross)
                {
                    num1 = 0;
                    enhPadding2 = this.EnhPadding;
                    enhPadding1 += 30 + this.EnhPadding;
                }
            }
            this.pnlClassList.CreateGraphics().DrawImageUnscaled((Image)this.bxClassList.Bitmap, 0, 0);
        }

        public void EditClick()
        {
            bool flag = true;
            int num1 = -1;
            if (this.lstSelected.SelectedIndex <= -1)
                return;
            int selectedIndex = this.lstSelected.SelectedIndex;
            if (this.myEnh.Effect[selectedIndex].Mode == eEffMode.Enhancement)
            {
                if (this.myEnh.Effect[selectedIndex].Enhance.ID == 12)
                {
                    int subId = this.myEnh.Effect[selectedIndex].Enhance.SubID;
                    num1 = this.MezPicker(subId);
                    if (num1 == subId)
                        return;
                    int num2 = this.myEnh.Effect.Length - 1;
                    for (int index1 = 0; index1 <= num2; ++index1)
                    {
                        var effect = this.myEnh.Effect;
                        int index2 = index1;
                        if (effect[index2].Mode == eEffMode.Enhancement & effect[index2].Enhance.SubID == num1)
                            flag = false;
                    }
                }
                if (!flag)
                {
                    int num2 = (int)Interaction.MsgBox("This effect has already been added!", MsgBoxStyle.Information, "There can be only one.");
                    return;
                }
                this.myEnh.Effect[selectedIndex].Enhance.SubID = num1;
            }
            else
            {
                frmPowerEffect frmPowerEffect = new frmPowerEffect(this.myEnh.Effect[selectedIndex].FX);
                if (frmPowerEffect.ShowDialog() == DialogResult.OK)
                {
                    var effect = this.myEnh.Effect;
                    int index = selectedIndex;
                    effect[index].Mode = eEffMode.FX;
                    effect[index].Enhance.ID = -1;
                    effect[index].Enhance.SubID = -1;
                    effect[index].Multiplier = 1f;
                    effect[index].Schedule = eSchedule.A;
                    effect[index].FX = (IEffect)frmPowerEffect.myFX.Clone();
                }
            }
            this.ListSelectedEffects();
            this.lstSelected.SelectedIndex = selectedIndex;
        }

        public void EffectList_Add()
        {
            if (this.lstAvailable.SelectedIndex <= -1)
                return;
            eEnhance eEnhance = eEnhance.None;
            bool flag = true;
            int tSub = -1;
            eEnhance integer = (eEnhance)Conversions.ToInteger(Enum.Parse(eEnhance.GetType(), Conversions.ToString(this.lstAvailable.Items[this.lstAvailable.SelectedIndex])));
            if (integer == eEnhance.Mez)
            {
                tSub = this.MezPicker(1);
                int num = this.myEnh.Effect.Length - 1;
                for (int index1 = 0; index1 <= num; ++index1)
                {
                    Enums.sEffect[] effect = this.myEnh.Effect;
                    int index2 = index1;
                    if (effect[index2].Mode == eEffMode.Enhancement & effect[index2].Enhance.SubID == tSub)
                        flag = false;
                }
            }
            if (!flag)
            {
                int num1 = (int)Interaction.MsgBox("This effect has already been added!", MsgBoxStyle.Information, "There can be only one.");
            }
            else
            {
                IEnhancement enh = this.myEnh;
                Enums.sEffect[] sEffectArray = (Enums.sEffect[])Utils.CopyArray((Array)enh.Effect, (Array)new Enums.sEffect[this.myEnh.Effect.Length + 1]);
                enh.Effect = sEffectArray;
                Enums.sEffect[] effect = this.myEnh.Effect;
                int index = this.myEnh.Effect.Length - 1;
                effect[index].Mode = eEffMode.Enhancement;
                effect[index].Enhance.ID = (int)integer;
                effect[index].Enhance.SubID = tSub;
                effect[index].Multiplier = 1f;
                effect[index].Schedule = Enhancement.GetSchedule(integer, tSub);
                this.FillEffectList();
                this.ListSelectedEffects();
                this.lstSelected.SelectedIndex = this.lstSelected.Items.Count - 1;
            }
        }

        public void FillEffectList()
        {
            eEnhance eEnhance1 = eEnhance.None;
            this.lstAvailable.BeginUpdate();
            this.lstAvailable.Items.Clear();
            string[] names = Enum.GetNames(eEnhance1.GetType());
            int num1 = names.Length - 1;
            for (int index1 = 1; index1 <= num1; ++index1)
            {
                eEnhance eEnhance2 = (eEnhance)index1;
                bool flag = false;
                int num2 = this.myEnh.Effect.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (this.myEnh.Effect[index2].Mode == eEffMode.Enhancement && this.myEnh.Effect[index2].Enhance.ID == index1 & eEnhance2 != eEnhance.Mez)
                        flag = true;
                }
                if (!flag)
                    this.lstAvailable.Items.Add(names[index1]);
            }
            this.btnAdd.Enabled = this.lstAvailable.Items.Count > 0;
            this.lstAvailable.EndUpdate();
        }

        public void FillMutExList()
        {
            string[] names = Enum.GetNames(eEnhMutex.None.GetType());
            this.cbMutEx.BeginUpdate();
            this.cbMutEx.Items.Clear();
            this.cbMutEx.Items.AddRange((object[])names);
            this.cbMutEx.EndUpdate();
        }

        public void FillRecipeList()
        {
            this.cbRecipe.BeginUpdate();
            this.cbRecipe.Items.Clear();
            this.cbRecipe.Items.Add("None");
            int num = DatabaseAPI.Database.Recipes.Length - 1;
            for (int index = 0; index <= num; ++index)
                this.cbRecipe.Items.Add(DatabaseAPI.Database.Recipes[index].InternalName);
            this.cbRecipe.EndUpdate();
        }

        public void FillSchedules()
        {
            this.cbSched.BeginUpdate();
            this.cbSched.Items.Clear();
            string Style = "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "##";
            this.cbSched.Items.Add(("A (" + Strings.Format((float)((double)DatabaseAPI.Database.MultSO[0][0] * 100.0), Style) + "%)"));
            this.cbSched.Items.Add(("B (" + Strings.Format((float)((double)DatabaseAPI.Database.MultSO[0][1] * 100.0), Style) + "%)"));
            this.cbSched.Items.Add(("C (" + Strings.Format((float)((double)DatabaseAPI.Database.MultSO[0][2] * 100.0), Style) + "%)"));
            this.cbSched.Items.Add(("D (" + Strings.Format((float)((double)DatabaseAPI.Database.MultSO[0][3] * 100.0), Style) + "%)"));
            this.cbSched.EndUpdate();
        }

        public void FillSetList()
        {
            this.cbSet.BeginUpdate();
            this.cbSet.Items.Clear();
            this.cbSet.Items.Add("None");
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int index = 0; index <= num; ++index)
                this.cbSet.Items.Add(DatabaseAPI.Database.EnhancementSets[index].Uid);
            this.cbSet.EndUpdate();
        }

        public void FillSubTypeList()
        {
            string[] names = Enum.GetNames(eSubtype.None.GetType());
            this.cbSubType.BeginUpdate();
            this.cbSubType.Items.Clear();
            this.cbSubType.Items.AddRange((object[])names);
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

        [DebuggerStepThrough]

        public void ListSelectedEffects()
        {
            eEnhance eEnhance = eEnhance.None;
            eMez eMez = eMez.None;
            string[] names1 = Enum.GetNames(eEnhance.GetType());
            string[] names2 = Enum.GetNames(eMez.GetType());
            this.lstSelected.BeginUpdate();
            this.lstSelected.Items.Clear();
            int num = this.myEnh.Effect.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (this.myEnh.Effect[index].Mode == eEffMode.Enhancement)
                {
                    string str = names1[this.myEnh.Effect[index].Enhance.ID];
                    if (this.myEnh.Effect[index].Enhance.SubID > -1)
                        str = str + ":" + names2[this.myEnh.Effect[index].Enhance.SubID];
                    this.lstSelected.Items.Add(str);
                }
                else
                    this.lstSelected.Items.Add(("Special: " + this.myEnh.Effect[index].FX.BuildEffectString(false, "", false, false, false)));
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
            this.tTip.SetToolTip((Control)this.lstSelected, Conversions.ToString(this.lstSelected.SelectedItem));
        }

        public int MezPicker(int Index = 1)
        {
            eMez eMez = eMez.None;
            frmEnhMiniPick frmEnhMiniPick = new frmEnhMiniPick();
            string[] names = Enum.GetNames(eMez.GetType());
            int num1 = names.Length - 1;
            for (int index = 1; index <= num1; ++index)
                frmEnhMiniPick.lbList.Items.Add(names[index]);
            if (Index > -1 & Index < frmEnhMiniPick.lbList.Items.Count)
                frmEnhMiniPick.lbList.SelectedIndex = Index - 1;
            else
                frmEnhMiniPick.lbList.SelectedIndex = 0;
            int num2 = (int)frmEnhMiniPick.ShowDialog();
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
            else
            {
                if (this.gbClass.Width <= 84 || this.Loading)
                    return;
                int num1 = -1;
                int num2 = -1;
                int num3 = 0;
                do
                {
                    if (e.X > (this.EnhPadding + this.ClassSize) * num3 & e.X < (this.EnhPadding + this.ClassSize) * (num3 + 1))
                        num1 = num3;
                    ++num3;
                }
                while (num3 <= 1);
                int num4 = 0;
                do
                {
                    if (e.Y > (this.EnhPadding + this.ClassSize) * num4 & e.Y < (this.EnhPadding + this.ClassSize) * (num4 + 1))
                        num2 = num4;
                    ++num4;
                }
                while (num4 <= 10);
                int num5 = num1 + num2 * 2;
                if (num5 < this.myEnh.ClassID.Length & num1 > -1 & num2 > -1)
                {
                    int[] numArray = new int[this.myEnh.ClassID.Length - 1 + 1];
                    int num6 = this.myEnh.ClassID.Length - 1;
                    for (int index = 0; index <= num6; ++index)
                        numArray[index] = this.myEnh.ClassID[index];
                    int index1 = 0;
                    this.myEnh.ClassID = new int[this.myEnh.ClassID.Length - 2 + 1];
                    int num7 = numArray.Length - 1;
                    for (int index2 = 0; index2 <= num7; ++index2)
                    {
                        if (index2 != num5)
                        {
                            this.myEnh.ClassID[index1] = numArray[index2];
                            ++index1;
                        }
                    }
                    Array.Sort<int>(this.myEnh.ClassID);
                    this.DrawClasses();
                }
            }
        }

        void pnlClass_MouseMove(object sender, MouseEventArgs e)

        {
            int num1 = -1;
            int num2 = -1;
            int num3 = 0;
            do
            {
                if (e.X > (this.EnhPadding + this.ClassSize) * num3 & e.X < (this.EnhPadding + this.ClassSize) * (num3 + 1))
                    num1 = num3;
                ++num3;
            }
            while (num3 <= 1);
            int num4 = 0;
            do
            {
                if (e.Y > (this.EnhPadding + this.ClassSize) * num4 & e.Y < (this.EnhPadding + this.ClassSize) * (num4 + 1))
                    num2 = num4;
                ++num4;
            }
            while (num4 <= 10);
            int index = num1 + num2 * 2;
            if (index < this.myEnh.ClassID.Length & num1 > -1 & num2 > -1)
            {
                if (this.gbClass.Width < 100)
                    this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[this.myEnh.ClassID[index]].ShortName;
                else
                    this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[this.myEnh.ClassID[index]].Name;
            }
            else
                this.lblClass.Text = "";
        }

        void pnlClass_Paint(object sender, PaintEventArgs e)

        {
            if (this.bxClass == null)
                return;
            e.Graphics.DrawImageUnscaled((Image)this.bxClass.Bitmap, 0, 0);
        }

        void pnlClassList_MouseDown(object sender, MouseEventArgs e)

        {
            if (e.Button == MouseButtons.Right)
            {
                this.PickerExpand();
            }
            else
            {
                if (this.gbClass.Width <= 84 || this.Loading)
                    return;
                int num1 = -1;
                int num2 = -1;
                int num3 = this.EnhAcross - 1;
                for (int index = 0; index <= num3; ++index)
                {
                    if (e.X > (this.EnhPadding + 30) * index & e.X < (this.EnhPadding + 30) * (index + 1))
                        num1 = index;
                }
                int num4 = 0;
                do
                {
                    if (e.Y > (this.EnhPadding + 30) * num4 & e.Y < (this.EnhPadding + 30) * (num4 + 1))
                        num2 = num4;
                    ++num4;
                }
                while (num4 <= 10);
                int num5 = num1 + num2 * this.EnhAcross;
                if (num5 < DatabaseAPI.Database.EnhancementClasses.Length & num1 > -1 & num2 > -1)
                {
                    bool flag = false;
                    int num6 = this.myEnh.ClassID.Length - 1;
                    for (int index = 0; index <= num6; ++index)
                    {
                        if (this.myEnh.ClassID[index] == num5)
                            flag = true;
                    }
                    if (!flag)
                    {
                        IEnhancement enh = this.myEnh;
                        int[] numArray = (int[])Utils.CopyArray((Array)enh.ClassID, (Array)new int[this.myEnh.ClassID.Length + 1]);
                        enh.ClassID = numArray;
                        this.myEnh.ClassID[this.myEnh.ClassID.Length - 1] = num5;
                        Array.Sort<int>(this.myEnh.ClassID);
                        this.DrawClasses();
                    }
                }
            }
        }

        void pnlClassList_MouseMove(object sender, MouseEventArgs e)

        {
            int num1 = -1;
            int num2 = -1;
            int num3 = this.EnhAcross - 1;
            for (int index = 0; index <= num3; ++index)
            {
                if (e.X > (this.EnhPadding + 30) * index & e.X < (this.EnhPadding + 30) * (index + 1))
                    num1 = index;
            }
            int num4 = 0;
            do
            {
                if (e.Y > (this.EnhPadding + 30) * num4 & e.Y < (this.EnhPadding + 30) * (num4 + 1))
                    num2 = num4;
                ++num4;
            }
            while (num4 <= 10);
            int index1 = num1 + num2 * this.EnhAcross;
            if (index1 < DatabaseAPI.Database.EnhancementClasses.Length & num1 > -1 & num2 > -1)
                this.lblClass.Text = DatabaseAPI.Database.EnhancementClasses[index1].Name;
            else
                this.lblClass.Text = string.Empty;
        }

        void pnlClassList_Paint(object sender, PaintEventArgs e)

        {
            if (this.bxClassList == null)
                return;
            e.Graphics.DrawImageUnscaled((Image)this.bxClassList.Bitmap, 0, 0);
        }

        void rbBuffDebuff_CheckedChanged(object sender, EventArgs e)

        {
            if (this.Loading || this.lstSelected.SelectedIndex <= -1)
                return;
            int selectedIndex = this.lstSelected.SelectedIndex;
            if (this.myEnh.Effect[selectedIndex].Mode == eEffMode.Enhancement)
            {
                if (this.rbBuff.Checked)
                    this.myEnh.Effect[selectedIndex].BuffMode = eBuffDebuff.BuffOnly;
                else if (this.rbDebuff.Checked)
                    this.myEnh.Effect[selectedIndex].BuffMode = eBuffDebuff.DeBuffOnly;
                else if (this.rbBoth.Checked)
                    this.myEnh.Effect[selectedIndex].BuffMode = eBuffDebuff.Any;
            }
        }

        void rbMod_CheckedChanged(object sender, EventArgs e)

        {
            if (this.lstSelected.SelectedIndex <= -1)
                return;
            int selectedIndex = this.lstSelected.SelectedIndex;
            if (this.myEnh.Effect[selectedIndex].Mode == eEffMode.Enhancement)
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
                    this.myEnh.Effect[selectedIndex].Multiplier = 1f;
                else if (this.rbMod2.Checked)
                    this.myEnh.Effect[selectedIndex].Multiplier = 0.625f;
                else if (this.rbMod3.Checked)
                    this.myEnh.Effect[selectedIndex].Multiplier = 0.5f;
                else if (this.rbMod4.Checked)
                    this.myEnh.Effect[selectedIndex].Multiplier = 7f / 16f;
            }
        }

        public void SetMaxLevel(int iValue)
        {
            if (Decimal.Compare(new Decimal(iValue), this.udMaxLevel.Minimum) < 0)
                iValue = Convert.ToInt32(this.udMaxLevel.Minimum);
            if (Decimal.Compare(new Decimal(iValue), this.udMaxLevel.Maximum) > 0)
                iValue = Convert.ToInt32(this.udMaxLevel.Maximum);
            this.udMaxLevel.Value = new Decimal(iValue);
        }

        public void SetMinLevel(int iValue)
        {
            if (Decimal.Compare(new Decimal(iValue), this.udMinLevel.Minimum) < 0)
                iValue = Convert.ToInt32(this.udMinLevel.Minimum);
            if (Decimal.Compare(new Decimal(iValue), this.udMinLevel.Maximum) > 0)
                iValue = Convert.ToInt32(this.udMinLevel.Maximum);
            this.udMinLevel.Value = new Decimal(iValue);
        }

        public void SetTypeIcons()
        {
            ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(30, 30);
            ExtendedBitmap extendedBitmap2 = !(this.myEnh.Image != "") ? new ExtendedBitmap(30, 30) : new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.myEnh.Image);
            extendedBitmap1.Graphics.Clear(Color.Transparent);
            extendedBitmap1.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(eType.Normal)), System.Drawing.GraphicsUnit.Pixel);
            extendedBitmap1.Graphics.DrawImage((Image)extendedBitmap2.Bitmap, 0, 0);
            this.typeRegular.Image = (Image)new Bitmap((Image)extendedBitmap1.Bitmap);
            extendedBitmap1.Graphics.Clear(Color.Transparent);
            extendedBitmap1.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(eType.InventO)), System.Drawing.GraphicsUnit.Pixel);
            extendedBitmap1.Graphics.DrawImage((Image)extendedBitmap2.Bitmap, 0, 0);
            this.typeIO.Image = (Image)new Bitmap((Image)extendedBitmap1.Bitmap);
            extendedBitmap1.Graphics.Clear(Color.Transparent);
            extendedBitmap1.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(eType.SpecialO)), System.Drawing.GraphicsUnit.Pixel);
            extendedBitmap1.Graphics.DrawImage((Image)extendedBitmap2.Bitmap, 0, 0);
            this.typeHO.Image = (Image)new Bitmap((Image)extendedBitmap1.Bitmap);
            extendedBitmap1.Graphics.Clear(Color.Transparent);
            extendedBitmap1.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(I9Gfx.ToGfxGrade(eType.SetO)), System.Drawing.GraphicsUnit.Pixel);
            extendedBitmap1.Graphics.DrawImage((Image)extendedBitmap2.Bitmap, 0, 0);
            this.typeSet.Image = (Image)new Bitmap((Image)extendedBitmap1.Bitmap);
        }

        void StaticIndex_TextChanged(object sender, EventArgs e)

        {
            this.myEnh.StaticIndex = Conversions.ToInteger(this.StaticIndex.Text);
        }

        void txtDesc_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.Desc = this.txtDesc.Text;
        }

        void txtInternal_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.UID = this.txtInternal.Text;
        }

        void txtModOther_TextChanged(object sender, EventArgs e)

        {
            if (this.lstSelected.SelectedIndex <= -1)
                return;
            int selectedIndex = this.lstSelected.SelectedIndex;
            if (this.myEnh.Effect[selectedIndex].Mode == eEffMode.Enhancement && this.rbModOther.Checked)
                this.myEnh.Effect[selectedIndex].Multiplier = (float)Conversion.Val(this.txtModOther.Text);
        }

        void txtNameFull_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.Name = this.txtNameFull.Text;
            this.UpdateTitle();
        }

        void txtNameShort_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.ShortName = this.txtNameShort.Text;
        }

        void txtProb_Leave(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.txtProb.Text = Conversions.ToString(this.myEnh.EffectChance);
        }

        void txtProb_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            float num = (float)Conversion.Val(this.txtProb.Text);
            if ((double)num > 1.0)
                num = 1f;
            if ((double)num < 0.0)
                num = 0.0f;
            this.myEnh.EffectChance = num;
        }

        void type_CheckedChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            if (this.typeRegular.Checked)
            {
                this.myEnh.TypeID = eType.Normal;
                this.chkUnique.Checked = false;
                this.cbSubType.Enabled = false;
                this.cbSubType.SelectedIndex = -1;
                this.cbRecipe.SelectedIndex = -1;
                this.cbRecipe.Enabled = false;
            }
            else if (this.typeIO.Checked)
            {
                this.myEnh.TypeID = eType.InventO;
                this.chkUnique.Checked = false;
                this.cbSubType.Enabled = false;
                this.cbSubType.SelectedIndex = -1;
                this.cbRecipe.SelectedIndex = 0;
                this.cbRecipe.Enabled = true;
            }
            else if (this.typeHO.Checked)
            {
                this.myEnh.TypeID = eType.SpecialO;
                this.chkUnique.Checked = false;
                this.cbSubType.Enabled = true;
                this.cbSubType.SelectedIndex = 0;
                this.cbRecipe.SelectedIndex = -1;
                this.cbRecipe.Enabled = false;
            }
            else if (this.typeSet.Checked)
            {
                this.myEnh.TypeID = eType.SetO;
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

        void udMaxLevel_Leave(object sender, EventArgs e)

        {
            this.SetMaxLevel((int)Math.Round(Conversion.Val(this.udMaxLevel.Text)));
            this.myEnh.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
        }

        void udMaxLevel_ValueChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
            this.udMinLevel.Maximum = this.udMaxLevel.Value;
        }

        void udMinLevel_Leave(object sender, EventArgs e)

        {
            this.SetMinLevel((int)Math.Round(Conversion.Val(this.udMinLevel.Text)));
            this.myEnh.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
        }

        void udMinLevel_ValueChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.myEnh.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
            this.udMaxLevel.Minimum = this.udMinLevel.Value;
        }

        public void UpdateTitle()
        {
            string str1 = "Edit ";
            string str2;
            switch (this.myEnh.TypeID)
            {
                case eType.InventO:
                    str2 = str1 + "Invention: ";
                    break;
                case eType.SpecialO:
                    str2 = str1 + "HO: ";
                    break;
                case eType.SetO:
                    str2 = this.myEnh.nIDSet > -1 ? str1 + DatabaseAPI.Database.EnhancementSets[this.myEnh.nIDSet].DisplayName + ": " : str1 + "Set Invention: ";
                    break;
                default:
                    str2 = str1 + "Enhancement: ";
                    break;
            }
            this.Text = str2 + this.myEnh.Name;
        }
    }
}