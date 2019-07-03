
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmSetEdit : Form
    {
        Button btnCancel;

        Button btnImage;

        Button btnNoImage;

        Button btnOK;

        Button btnPaste;

        ComboBox cbSetType;

        ComboBox cbSlotCount;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        GroupBox gbBasic;
        GroupBox GroupBox2;
        GroupBox GroupBox3;
        ImageList ilEnh;
        OpenFileDialog ImagePicker;
        Label Label1;
        Label Label16;
        Label Label2;
        Label Label27;
        Label Label3;
        Label Label4;
        Label Label5;
        Label Label6;
        Label Label7;

        ListBox lstBonus;

        [AccessedThroughProperty("lvBonusList")]
        ListView _lvBonusList;
        ListView lvEnh;
        RadioButton rbIfAny;
        RadioButton rbIfCritter;
        RadioButton rbIfPlayer;
        RichTextBox rtbBonus;

        TextBox txtAlternate;

        TextBox txtDesc;

        TextBox txtInternal;

        TextBox txtNameFull;

        TextBox txtNameShort;

        [AccessedThroughProperty("udMaxLevel")]
        NumericUpDown _udMaxLevel;

        [AccessedThroughProperty("udMinLevel")]
        NumericUpDown _udMinLevel;

        protected bool Loading;
        public EnhancementSet mySet;
        protected int[] SetBonusList;
        protected int[] SetBonusListPVP;

















        ListView lvBonusList
        {
            get
            {
                return this._lvBonusList;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.lvBonusList_SelectedIndexChanged);
                EventHandler eventHandler2 = new EventHandler(this.lvBonusList_DoubleClick);
                if (this._lvBonusList != null)
                {
                    this._lvBonusList.SelectedIndexChanged -= eventHandler1;
                    this._lvBonusList.DoubleClick -= eventHandler2;
                }
                this._lvBonusList = value;
                if (this._lvBonusList == null)
                    return;
                this._lvBonusList.SelectedIndexChanged += eventHandler1;
                this._lvBonusList.DoubleClick += eventHandler2;
            }
        }





        NumericUpDown udMaxLevel
        {
            get
            {
                return this._udMaxLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.udMaxLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.udMaxLevel_ValueChanged);
                if (this._udMaxLevel != null)
                {
                    this._udMaxLevel.Leave -= eventHandler1;
                    this._udMaxLevel.ValueChanged -= eventHandler2;
                }
                this._udMaxLevel = value;
                if (this._udMaxLevel == null)
                    return;
                this._udMaxLevel.Leave += eventHandler1;
                this._udMaxLevel.ValueChanged += eventHandler2;
            }
        }

        NumericUpDown udMinLevel
        {
            get
            {
                return this._udMinLevel;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler1 = new EventHandler(this.udMinLevel_Leave);
                EventHandler eventHandler2 = new EventHandler(this.udMinLevel_ValueChanged);
                if (this._udMinLevel != null)
                {
                    this._udMinLevel.Leave -= eventHandler1;
                    this._udMinLevel.ValueChanged -= eventHandler2;
                }
                this._udMinLevel = value;
                if (this._udMinLevel == null)
                    return;
                this._udMinLevel.Leave += eventHandler1;
                this._udMinLevel.ValueChanged += eventHandler2;
            }
        }

        public frmSetEdit(ref EnhancementSet iSet)
        {
            this.Load += new EventHandler(this.frmSetEdit_Load);
            this.SetBonusList = new int[0];
            this.SetBonusListPVP = new int[0];
            this.Loading = true;
            this.InitializeComponent();
            this.mySet = new EnhancementSet(iSet);
        }

        public int BonusID()
        {
            return this.cbSlotCount.SelectedIndex;
        }

        void btnCancel_Click(object sender, EventArgs e)

        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        void btnImage_Click(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.ImagePicker.InitialDirectory = I9Gfx.GetEnhancementsPath();
            this.ImagePicker.FileName = this.mySet.Image;
            if (this.ImagePicker.ShowDialog() == DialogResult.OK)
            {
                string str = FileIO.StripPath(this.ImagePicker.FileName);
                if (!File.Exists(FileIO.AddSlash(this.ImagePicker.InitialDirectory) + str))
                {
                    int num = (int)Interaction.MsgBox(("You must select an image from the " + I9Gfx.GetEnhancementsPath() + " folder!\r\n\r\nIf you are adding a new image, you should copy it to the folder and then select it."), MsgBoxStyle.Information, "Ah...");
                }
                else
                {
                    this.mySet.Image = str;
                    this.DisplayIcon();
                }
            }
        }

        void btnNoImage_Click(object sender, EventArgs e)

        {
            this.mySet.Image = "";
            this.DisplayIcon();
        }

        void btnOK_Click(object sender, EventArgs e)

        {
            this.mySet.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
            this.mySet.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        void btnPaste_Click(object sender, EventArgs e)

        {
            string str = Conversions.ToString(Clipboard.GetData("System.String"));
            char[] chArray = new char[1] { '^' };
            string[] strArray1 = str.Replace("\r\n", Conversions.ToString(chArray[0])).Split(chArray);
            chArray[0] = '\t';
            this.mySet.InitBonus();
            int num1 = strArray1.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                string[] strArray2 = strArray1[index1].Split(chArray);
                if (strArray2.Length > 3)
                {
                    int num2 = (int)Math.Round(Conversion.Val(strArray2[0]));
                    int index2 = DatabaseAPI.NidFromUidPower(strArray2[3]);
                    int num3 = num2 - 2;
                    if (num3 > -1 & index2 > -1)
                    {
                        EnhancementSet.BonusItem[] bonus = this.mySet.Bonus;
                        int index3 = num3;
                        bonus[index3].Name = (string[])Utils.CopyArray((Array)bonus[index3].Name, (Array)new string[bonus[index3].Name.Length + 1]);
                        bonus[index3].Index = (int[])Utils.CopyArray((Array)bonus[index3].Index, (Array)new int[bonus[index3].Index.Length + 1]);
                        bonus[index3].Index[bonus[index3].Index.Length - 1] = index2;
                        bonus[index3].Name[bonus[index3].Name.Length - 1] = DatabaseAPI.Database.Power[index2].FullName;
                    }
                }
            }
            this.DisplayBonus();
            this.DisplayBonusText();
        }

        void cbSetType_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.SetType = (Enums.eSetType)this.cbSetType.SelectedIndex;
        }

        void cbSlotX_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.DisplayBonus();
            this.DisplayBonusText();
        }

        public void DisplayBonus()
        {
            try
            {
                this.lstBonus.BeginUpdate();
                this.lstBonus.Items.Clear();
                if (this.isBonus())
                {
                    int index1 = this.BonusID();
                    int num = this.mySet.Bonus[index1].Index.Length - 1;
                    for (int index2 = 0; index2 <= num; ++index2)
                        this.lstBonus.Items.Add(DatabaseAPI.Database.Power[this.mySet.Bonus[index1].Index[index2]].PowerName);
                    this.txtAlternate.Text = this.mySet.Bonus[index1].AltString;
                }
                else if (this.isSpecial())
                {
                    int index1 = this.SpecialID();
                    int num = this.mySet.SpecialBonus[index1].Index.Length - 1;
                    for (int index2 = 0; index2 <= num; ++index2)
                        this.lstBonus.Items.Add(DatabaseAPI.Database.Power[this.mySet.SpecialBonus[index1].Index[index2]].PowerName);
                    this.txtAlternate.Text = this.mySet.SpecialBonus[index1].AltString;
                }
                this.lstBonus.EndUpdate();
                this.cbSlotCount.Enabled = this.mySet.Enhancements.Length > 1;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        public void DisplayBonusText()
        {
            string str1 = RTF.StartRTF();
            int num1 = this.mySet.Bonus.Length - 1;
            for (int index1 = 0; index1 <= num1; ++index1)
            {
                if (this.mySet.Bonus[index1].Index.Length > 0)
                    str1 = str1 + RTF.Color(RTF.ElementID.Black) + RTF.Bold(Conversions.ToString(this.mySet.Bonus[index1].Slotted) + " Enhancements: ");
                int num2 = this.mySet.Bonus[index1].Index.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    if (this.mySet.Bonus[index1].Index[index2] > -1)
                    {
                        if (index2 > 0)
                            str1 += ", ";
                        str1 = str1 + RTF.Color(RTF.ElementID.InentionInvert) + DatabaseAPI.Database.Power[this.mySet.Bonus[index1].Index[index2]].PowerName;
                    }
                }
                if (this.mySet.Bonus[index1].Index.Length > 0)
                    str1 = str1 + RTF.Crlf() + "   " + RTF.Italic(this.mySet.GetEffectString(index1, false, false));
                if (this.mySet.Bonus[index1].PvMode == Enums.ePvX.PvP)
                    str1 += "(PvP)";
                if (this.mySet.Bonus[index1].Index.Length > 0)
                    str1 += RTF.Crlf();
            }
            int num3 = this.mySet.SpecialBonus.Length - 1;
            for (int index1 = 0; index1 <= num3; ++index1)
            {
                if (this.mySet.SpecialBonus[index1].Special > -1)
                {
                    string str2 = str1 + RTF.Color(RTF.ElementID.Black) + RTF.Bold("Special Case Enhancement: ") + RTF.Color(RTF.ElementID.InentionInvert);
                    if (this.mySet.Enhancements[this.mySet.SpecialBonus[index1].Special] > -1)
                        str2 += DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[this.mySet.SpecialBonus[index1].Special]].Name;
                    string str3 = str2 + RTF.Crlf();
                    int num2 = this.mySet.SpecialBonus[index1].Index.Length - 1;
                    for (int index2 = 0; index2 <= num2; ++index2)
                    {
                        if (this.mySet.SpecialBonus[index1].Index[index2] > -1)
                        {
                            if (index2 > 0)
                                str3 += ", ";
                            str3 = str3 + RTF.Color(RTF.ElementID.InentionInvert) + DatabaseAPI.Database.Power[this.mySet.SpecialBonus[index1].Index[index2]].PowerName;
                        }
                    }
                    str1 = str3 + RTF.Crlf() + "   " + RTF.Italic(this.mySet.GetEffectString(index1, true, false)) + RTF.Crlf();
                }
                if (this.mySet.SpecialBonus[index1].Index.Length > 0)
                    str1 += RTF.Crlf();
            }
            this.rtbBonus.Rtf = str1 + RTF.EndRTF();
        }

        void DisplayIcon()

        {
            if (this.mySet.Image != "")
            {
                ExtendedBitmap extendedBitmap1 = new ExtendedBitmap(I9Gfx.GetEnhancementsPath() + this.mySet.Image);
                ExtendedBitmap extendedBitmap2 = new ExtendedBitmap(30, 30);
                extendedBitmap2.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap2.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), System.Drawing.GraphicsUnit.Pixel);
                extendedBitmap2.Graphics.DrawImage((Image)extendedBitmap1.Bitmap, extendedBitmap2.ClipRect, extendedBitmap2.ClipRect, System.Drawing.GraphicsUnit.Pixel);
                this.btnImage.Image = (Image)new Bitmap((Image)extendedBitmap2.Bitmap);
                this.btnImage.Text = this.mySet.Image;
            }
            else
            {
                ExtendedBitmap extendedBitmap = new ExtendedBitmap(30, 30);
                extendedBitmap.Graphics.DrawImage((Image)I9Gfx.Borders.Bitmap, extendedBitmap.ClipRect, I9Gfx.GetOverlayRect(Origin.Grade.SetO), System.Drawing.GraphicsUnit.Pixel);
                this.btnImage.Image = (Image)new Bitmap((Image)extendedBitmap.Bitmap);
                this.btnImage.Text = "Select Image";
            }
        }

        public void DisplaySetData()
        {
            this.DisplaySetIcons();
            this.DisplayIcon();
            this.txtNameFull.Text = this.mySet.DisplayName;
            this.txtNameShort.Text = this.mySet.ShortName;
            this.txtDesc.Text = this.mySet.Desc;
            this.txtInternal.Text = this.mySet.Uid;
            this.SetMinLevel(this.mySet.LevelMin + 1);
            this.SetMaxLevel(this.mySet.LevelMax + 1);
            this.udMaxLevel.Minimum = this.udMinLevel.Value;
            this.udMinLevel.Maximum = this.udMaxLevel.Value;
            this.cbSetType.SelectedIndex = (int)this.mySet.SetType;
            this.btnImage.Text = this.mySet.Image;
            this.DisplayBonusText();
            this.DisplayBonus();
        }

        public void DisplaySetIcons()
        {
            this.FillImageList();
            string[] items = new string[2];
            this.lvEnh.BeginUpdate();
            this.lvEnh.Items.Clear();
            this.FillImageList();
            int num1 = this.mySet.Enhancements.Length - 1;
            for (int imageIndex = 0; imageIndex <= num1; ++imageIndex)
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[imageIndex]];
                items[0] = enhancement.Name + " (" + enhancement.ShortName + ")";
                items[1] = "";
                int num2 = enhancement.ClassID.Length - 1;
                for (int index1 = 0; index1 <= num2; ++index1)
                {
                    if (items[1] != "")
                    {
                        string[] strArray1 = items;
                        int num3 = 1;
                        string[] strArray2;
                        IntPtr index2;
                        (strArray2 = strArray1)[(int)(index2 = (IntPtr)num3)] = strArray2[(int)index2] + ",";
                    }
                    string[] strArray3 = items;
                    int num4 = 1;
                    string[] strArray4;
                    IntPtr index3;
                    (strArray4 = strArray3)[(int)(index3 = (IntPtr)num4)] = strArray4[(int)index3] + DatabaseAPI.Database.EnhancementClasses[enhancement.ClassID[index1]].ShortName;
                }
                this.lvEnh.Items.Add(new ListViewItem(items, imageIndex));
            }
            this.lvEnh.EndUpdate();
        }

        public void FillBonusCombos()
        {
            this.cbSlotCount.BeginUpdate();
            this.cbSlotCount.Items.Clear();
            int num1 = this.mySet.Enhancements.Length - 2;
            for (int index = 0; index <= num1; ++index)
                this.cbSlotCount.Items.Add((Conversions.ToString(index + 2) + " Enhancements"));
            int num2 = this.mySet.Enhancements.Length - 1;
            for (int index = 0; index <= num2; ++index)
                this.cbSlotCount.Items.Add(DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[index]].Name);
            if (this.cbSlotCount.Items.Count > 0)
                this.cbSlotCount.SelectedIndex = 0;
            this.cbSlotCount.EndUpdate();
        }

        public void FillBonusList()
        {
            this.lvBonusList.BeginUpdate();
            this.lvBonusList.Items.Clear();
            string[] items = new string[2];
            int num1 = this.SetBonusList.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                items[1] = "";
                if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects.Length > 0)
                    items[1] = DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].BuildEffectStringShort(false, true, false);
                items[0] = DatabaseAPI.Database.Power[this.SetBonusList[index]].PowerName;
                this.lvBonusList.Items.Add(new ListViewItem(items)
                {
                    Tag = this.SetBonusList[index]
                });
            }
            int num2 = this.SetBonusListPVP.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                items[1] = "";
                if (DatabaseAPI.Database.Power[this.SetBonusListPVP[index]].Effects.Length > 0)
                    items[1] = DatabaseAPI.Database.Power[this.SetBonusListPVP[index]].Effects[0].BuildEffectStringShort(false, true, false);
                items[0] = DatabaseAPI.Database.Power[this.SetBonusListPVP[index]].PowerName + " (PVP Only)";
                this.lvBonusList.Items.Add(new ListViewItem(items)
                {
                    Tag = this.SetBonusListPVP[index]
                });
            }
            this.lvBonusList.Sort();
            this.lvBonusList.EndUpdate();
        }

        public void FillComboBoxes()
        {
            string[] names = Enum.GetNames(Enums.eSetType.Untyped.GetType());
            this.cbSetType.BeginUpdate();
            this.cbSetType.Items.Clear();
            this.cbSetType.Items.AddRange((object[])names);
            this.cbSetType.EndUpdate();
        }

        public void FillImageList()
        {
            Size imageSize1 = this.ilEnh.ImageSize;
            int width1 = imageSize1.Width;
            imageSize1 = this.ilEnh.ImageSize;
            int height1 = imageSize1.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
            this.ilEnh.Images.Clear();
            int num = this.mySet.Enhancements.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[index]];
                if (enhancement.ImageIdx > -1)
                {
                    Origin.Grade gfxGrade = I9Gfx.ToGfxGrade(enhancement.TypeID);
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancement(ref graphics, DatabaseAPI.Database.Enhancements[this.mySet.Enhancements[index]].ImageIdx, gfxGrade);
                    this.ilEnh.Images.Add((Image)extendedBitmap.Bitmap);
                }
                else
                {
                    ImageList.ImageCollection images = this.ilEnh.Images;
                    Size imageSize2 = this.ilEnh.ImageSize;
                    int width2 = imageSize2.Width;
                    imageSize2 = this.ilEnh.ImageSize;
                    int height2 = imageSize2.Height;
                    Bitmap bitmap = new Bitmap(width2, height2);
                    images.Add((Image)bitmap);
                }
            }
        }

        void frmSetEdit_Load(object sender, EventArgs e)

        {
            if (MidsContext.Config.MasterMode)
                this.btnPaste.Visible = true;
            this.SetBonusList = DatabaseAPI.NidPowers("set_bonus.set_bonus", "");
            this.SetBonusListPVP = DatabaseAPI.NidPowers("set_bonus.pvp_set_bonus", "");
            if (this.mySet.Bonus.Length < 1)
                this.mySet.InitBonus();
            this.FillComboBoxes();
            this.FillBonusCombos();
            this.FillBonusList();
            this.DisplaySetData();
            this.Loading = false;
            this.DisplayBonus();
        }

        [DebuggerStepThrough]

        public bool isBonus()
        {
            return this.cbSlotCount.SelectedIndex > -1 & this.cbSlotCount.SelectedIndex < this.mySet.Enhancements.Length - 1;
        }

        public bool isSpecial()
        {
            return this.cbSlotCount.SelectedIndex >= this.mySet.Enhancements.Length - 1 & this.cbSlotCount.SelectedIndex < this.mySet.Enhancements.Length + this.mySet.Enhancements.Length - 1;
        }

        void lstBonus_DoubleClick(object sender, EventArgs e)

        {
            if (this.lstBonus.SelectedIndex < 0)
                return;
            int selectedIndex = this.lstBonus.SelectedIndex;
            int[] numArray1 = new int[0];
            string[] strArray1 = new string[0];
            int index1 = 0;
            if (this.isBonus())
            {
                int[] numArray2 = new int[this.mySet.Bonus[this.BonusID()].Index.Length - 2 + 1];
                string[] strArray2 = new string[this.mySet.Bonus[this.BonusID()].Name.Length - 2 + 1];
                int num1 = this.mySet.Bonus[this.BonusID()].Index.Length - 1;
                for (int index2 = 0; index2 <= num1; ++index2)
                {
                    if (index2 != selectedIndex)
                    {
                        numArray2[index1] = this.mySet.Bonus[this.BonusID()].Index[index2];
                        strArray2[index1] = this.mySet.Bonus[this.BonusID()].Name[index2];
                        ++index1;
                    }
                }
                this.mySet.Bonus[this.BonusID()].Name = new string[numArray2.Length - 1 + 1];
                this.mySet.Bonus[this.BonusID()].Index = new int[strArray2.Length - 1 + 1];
                int num2 = numArray2.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.mySet.Bonus[this.BonusID()].Index[index2] = numArray2[index2];
                    this.mySet.Bonus[this.BonusID()].Name[index2] = strArray2[index2];
                }
            }
            else if (this.isSpecial())
            {
                int[] numArray2 = new int[this.mySet.SpecialBonus[this.SpecialID()].Index.Length - 2 + 1];
                string[] strArray2 = new string[this.mySet.SpecialBonus[this.SpecialID()].Name.Length - 2 + 1];
                int num1 = this.mySet.SpecialBonus[this.SpecialID()].Index.Length - 1;
                for (int index2 = 0; index2 <= num1; ++index2)
                {
                    if (index2 != selectedIndex)
                    {
                        numArray2[index1] = this.mySet.SpecialBonus[this.SpecialID()].Index[index2];
                        strArray2[index1] = this.mySet.SpecialBonus[this.SpecialID()].Name[index2];
                        ++index1;
                    }
                }
                this.mySet.SpecialBonus[this.SpecialID()].Name = new string[numArray2.Length - 1 + 1];
                this.mySet.SpecialBonus[this.SpecialID()].Index = new int[strArray2.Length - 1 + 1];
                int num2 = numArray2.Length - 1;
                for (int index2 = 0; index2 <= num2; ++index2)
                {
                    this.mySet.SpecialBonus[this.SpecialID()].Index[index2] = numArray2[index2];
                    this.mySet.SpecialBonus[this.SpecialID()].Name[index2] = strArray2[index2];
                }
                if (this.mySet.SpecialBonus[this.SpecialID()].Index.Length < 1)
                    this.mySet.SpecialBonus[this.SpecialID()].Special = -1;
            }
            this.DisplayBonus();
            this.DisplayBonusText();
        }

        void lvBonusList_DoubleClick(object sender, EventArgs e)

        {
            if (this.lvBonusList.SelectedIndices.Count < 1)
                return;
            int index = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvBonusList.SelectedItems[0].Tag)));
            if (index < 0)
            {
                int num = (int)Interaction.MsgBox("Tag was < 0!", MsgBoxStyle.OkOnly, null);
            }
            else
            {
                if (this.isBonus())
                {
                    this.mySet.Bonus[this.BonusID()].Name = (string[])Utils.CopyArray((Array)this.mySet.Bonus[this.BonusID()].Name, (Array)new string[this.mySet.Bonus[this.BonusID()].Name.Length + 1]);
                    this.mySet.Bonus[this.BonusID()].Index = (int[])Utils.CopyArray((Array)this.mySet.Bonus[this.BonusID()].Index, (Array)new int[this.mySet.Bonus[this.BonusID()].Index.Length + 1]);
                    this.mySet.Bonus[this.BonusID()].Name[this.mySet.Bonus[this.BonusID()].Name.Length - 1] = DatabaseAPI.Database.Power[index].FullName;
                    this.mySet.Bonus[this.BonusID()].Index[this.mySet.Bonus[this.BonusID()].Index.Length - 1] = index;
                }
                else if (this.isSpecial())
                {
                    this.mySet.SpecialBonus[this.SpecialID()].Special = this.SpecialID();
                    this.mySet.SpecialBonus[this.SpecialID()].Name = (string[])Utils.CopyArray((Array)this.mySet.SpecialBonus[this.SpecialID()].Name, (Array)new string[this.mySet.SpecialBonus[this.SpecialID()].Name.Length + 1]);
                    this.mySet.SpecialBonus[this.SpecialID()].Index = (int[])Utils.CopyArray((Array)this.mySet.SpecialBonus[this.SpecialID()].Index, (Array)new int[this.mySet.SpecialBonus[this.SpecialID()].Index.Length + 1]);
                    this.mySet.SpecialBonus[this.SpecialID()].Name[this.mySet.SpecialBonus[this.SpecialID()].Name.Length - 1] = DatabaseAPI.Database.Power[index].FullName;
                    this.mySet.SpecialBonus[this.SpecialID()].Index[this.mySet.SpecialBonus[this.SpecialID()].Index.Length - 1] = index;
                }
                this.DisplayBonus();
                this.DisplayBonusText();
            }
        }

        void lvBonusList_SelectedIndexChanged(object sender, EventArgs e)

        {
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

        public int SpecialID()
        {
            return this.cbSlotCount.SelectedIndex - (this.mySet.Enhancements.Length - 1);
        }

        void txtAlternate_TextChanged(object sender, EventArgs e)

        {
            if (this.isBonus())
                this.mySet.Bonus[this.BonusID()].AltString = this.txtAlternate.Text;
            else if (this.isSpecial())
                this.mySet.SpecialBonus[this.SpecialID()].AltString = this.txtAlternate.Text;
            this.DisplayBonusText();
        }

        void txtDesc_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.Desc = this.txtDesc.Text;
        }

        void txtInternal_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.Uid = this.txtInternal.Text;
        }

        void txtNameFull_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.DisplayName = this.txtNameFull.Text;
        }

        void txtNameShort_TextChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.ShortName = this.txtNameShort.Text;
        }

        void udMaxLevel_Leave(object sender, EventArgs e)

        {
            this.SetMaxLevel((int)Math.Round(Conversion.Val(this.udMaxLevel.Text)));
            this.mySet.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
        }

        void udMaxLevel_ValueChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.LevelMax = Convert.ToInt32(Decimal.Subtract(this.udMaxLevel.Value, new Decimal(1)));
            this.udMinLevel.Maximum = this.udMaxLevel.Value;
        }

        void udMinLevel_Leave(object sender, EventArgs e)

        {
            this.SetMinLevel((int)Math.Round(Conversion.Val(this.udMinLevel.Text)));
            this.mySet.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
        }

        void udMinLevel_ValueChanged(object sender, EventArgs e)

        {
            if (this.Loading)
                return;
            this.mySet.LevelMin = Convert.ToInt32(Decimal.Subtract(this.udMinLevel.Value, new Decimal(1)));
            this.udMaxLevel.Minimum = this.udMinLevel.Value;
        }
    }
}