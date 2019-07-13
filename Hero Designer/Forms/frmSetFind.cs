
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmSetFind : Form
    {
        int[] setBonusList;

        ImageButton ibClose;
        ImageButton ibTopmost;
        ctlPopUp SetInfo;
        frmMain myParent;

        public frmSetFind(frmMain iParent)
        {
            this.FormClosed += new FormClosedEventHandler(this.frmSetFind_FormClosed);
            this.Load += new EventHandler(this.frmSetFind_Load);
            this.setBonusList = new int[0];
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmSetFind));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmSetFind);
            this.ibClose.ButtonClicked += ibClose_ButtonClicked;
            this.ibTopmost.ButtonClicked += ibTopmost_ButtonClicked;
            this.myParent = iParent;
        }

        void AddEffect(ref string[] List, ref int[] nIDList, string Effect, int nID)

        {
            int num = List.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (string.Equals(List[index], Effect, StringComparison.OrdinalIgnoreCase))
                    return;
            }
            List = (string[])Utils.CopyArray(List, (Array)new string[List.Length + 1]);
            nIDList = (int[])Utils.CopyArray(nIDList, (Array)new int[List.Length + 1]);
            List[List.Length - 1] = Effect;
            nIDList[List.Length - 1] = nID;
        }

        void AddSetString(int nIDSet, int BonusID)

        {
            this.lvSet.Items.Add(new ListViewItem(new string[4]
            {
        DatabaseAPI.Database.EnhancementSets[nIDSet].DisplayName,
        Conversions.ToString(DatabaseAPI.Database.EnhancementSets[nIDSet].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[nIDSet].LevelMax + 1),
        DatabaseAPI.Database.SetTypeStringLong[(int) DatabaseAPI.Database.EnhancementSets[nIDSet].SetType],
        BonusID >= 0 ? Conversions.ToString(DatabaseAPI.Database.EnhancementSets.GetSetBonusEnhCount(nIDSet, BonusID)) : "Special"
            }, nIDSet));
            this.lvSet.Items[this.lvSet.Items.Count - 1].Tag = nIDSet;
        }

        public void FillEffectList()
        {
            string[] List = new string[0];
            int[] nIDList = new int[0];
            this.lvBonus.BeginUpdate();
            this.lvBonus.Items.Clear();
            int num1 = this.setBonusList.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if ((DatabaseAPI.Database.Power[this.setBonusList[index]].EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                    this.AddEffect(ref List, ref nIDList, this.GetPowerString(this.setBonusList[index]), -1);
            }
            int num2 = List.Length - 1;
            for (int index = 0; index <= num2; ++index)
                this.lvBonus.Items.Add(new ListViewItem(List[index]));
            this.lvBonus.Sorting = SortOrder.Ascending;
            this.lvBonus.Sort();
            if (this.lvBonus.Items.Count > 0)
                this.lvBonus.Items[0].Selected = true;
            this.lvBonus.EndUpdate();
        }

        public void FillImageList()
        {
            Size imageSize1 = this.ilSets.ImageSize;
            int width1 = imageSize1.Width;
            imageSize1 = this.ilSets.ImageSize;
            int height1 = imageSize1.Height;
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(width1, height1);
            this.ilSets.Images.Clear();
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (DatabaseAPI.Database.EnhancementSets[index].ImageIdx > -1)
                {
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancementSet(ref graphics, DatabaseAPI.Database.EnhancementSets[index].ImageIdx);
                    this.ilSets.Images.Add((Image)extendedBitmap.Bitmap);
                }
                else
                {
                    ImageList.ImageCollection images = this.ilSets.Images;
                    Size imageSize2 = this.ilSets.ImageSize;
                    int width2 = imageSize2.Width;
                    imageSize2 = this.ilSets.ImageSize;
                    int height2 = imageSize2.Height;
                    Bitmap bitmap = new Bitmap(width2, height2);
                    images.Add((Image)bitmap);
                }
            }
        }

        public void FillMagList()
        {
            if (this.lvBonus.SelectedItems.Count < 1)
            {
                this.lvMag.Items.Clear();
            }
            else
            {
                string[] List = new string[0];
                int[] nIDList = new int[0];
                string text = this.lvBonus.SelectedItems[0].Text;
                int num1 = this.setBonusList.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (DatabaseAPI.Database.Power[this.setBonusList[index]].Effects.Length > 0)
                    {
                        string powerString = this.GetPowerString(this.setBonusList[index]);
                        if (text == powerString)
                        {
                            string Effect = (DatabaseAPI.Database.Power[this.setBonusList[index]].Effects[0].EffectType != Enums.eEffectType.HitPoints ? (DatabaseAPI.Database.Power[this.setBonusList[index]].Effects[0].EffectType != Enums.eEffectType.Endurance ? Strings.Format(DatabaseAPI.Database.Power[this.setBonusList[index]].Effects[0].MagPercent, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") : Strings.Format(DatabaseAPI.Database.Power[this.setBonusList[index]].Effects[0].Mag, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00")) : Strings.Format((float)((double)DatabaseAPI.Database.Power[this.setBonusList[index]].Effects[0].Mag / (double)MidsContext.Archetype.Hitpoints * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00")) + "%";
                            this.AddEffect(ref List, ref nIDList, Effect, this.setBonusList[index]);
                        }
                    }
                }
                this.lvMag.BeginUpdate();
                this.lvMag.Items.Clear();
                this.lvMag.Items.Add("All");
                int num2 = List.Length - 1;
                for (int index = 0; index <= num2; ++index)
                    this.lvMag.Items.Add(new ListViewItem(List[index])
                    {
                        Tag = nIDList[index]
                    });
                if (this.lvMag.Items.Count > 0)
                    this.lvMag.Items[0].Selected = true;
                this.lvMag.EndUpdate();
            }
        }

        void FillSetList()

        {
            if (this.lvBonus.SelectedItems.Count < 1 | this.lvMag.SelectedItems.Count < 1)
            {
                this.lvSet.Items.Clear();
            }
            else
            {
                this.lvSet.BeginUpdate();
                this.lvSet.Items.Clear();
                string[] List = new string[0];
                int[] nIDList = new int[0];
                string text = this.lvBonus.SelectedItems[0].Text;
                bool flag = false;
                if (this.lvMag.Items[0].Selected)
                    flag = true;
                if (!flag)
                {
                    if (Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvMag.SelectedItems[0].Tag)) > -1.0)
                        this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[Conversions.ToInteger(this.lvMag.SelectedItems[0].Tag)].PowerName, Conversions.ToInteger(this.lvMag.SelectedItems[0].Tag));
                }
                else
                {
                    int num = this.setBonusList.Length - 1;
                    for (int index = 0; index <= num; ++index)
                    {
                        if (DatabaseAPI.Database.Power[this.setBonusList[index]].Effects.Length > 0)
                        {
                            string powerString = this.GetPowerString(this.setBonusList[index]);
                            if (text == powerString)
                                this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[this.setBonusList[index]].PowerName, this.setBonusList[index]);
                        }
                    }
                }
                int num1 = DatabaseAPI.Database.EnhancementSets.Count - 1;
                for (int nIDSet = 0; nIDSet <= num1; ++nIDSet)
                {
                    int num2 = DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus.Length - 1;
                    for (int BonusID = 0; BonusID <= num2; ++BonusID)
                    {
                        int num3 = DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus[BonusID].Index.Length - 1;
                        for (int index1 = 0; index1 <= num3; ++index1)
                        {
                            int num4 = nIDList.Length - 1;
                            for (int index2 = 0; index2 <= num4; ++index2)
                            {
                                if (DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus[BonusID].Index[index1] == nIDList[index2])
                                    this.AddSetString(nIDSet, BonusID);
                            }
                        }
                    }
                    int num5 = DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus.Length - 1;
                    for (int BonusID = 0; BonusID <= num5; ++BonusID)
                    {
                        int num3 = DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus[BonusID].Index.Length - 1;
                        for (int index1 = 0; index1 <= num3; ++index1)
                        {
                            int num4 = nIDList.Length - 1;
                            for (int index2 = 0; index2 <= num4; ++index2)
                            {
                                if (DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus[BonusID].Index[index1] == nIDList[index2])
                                    this.AddSetString(nIDSet, BonusID);
                            }
                        }
                    }
                }
                if (this.lvSet.Items.Count > 0)
                    this.lvSet.Items[0].Selected = true;
                this.lvSet.EndUpdate();
            }
        }

        void frmSetFind_FormClosed(object sender, FormClosedEventArgs e)

        {
            this.myParent.FloatSetFinder(false);
        }

        void frmSetFind_Load(object sender, EventArgs e)

        {
            this.setBonusList = DatabaseAPI.NidPowers("Set_Bonus.Set_Bonus", "");
            this.BackColor = this.myParent.BackColor;
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
            this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.SetInfo.SetPopup(new PopUp.PopupData());
            this.FillImageList();
            this.FillEffectList();
        }

        string GetPowerString(int nIDPower)

        {
            string str1 = "";
            string returnString = "";
            int[] returnMask = new int[0];
            DatabaseAPI.Database.Power[nIDPower].GetEffectStringGrouped(0, ref returnString, ref returnMask, true, true, true);
            string str2;
            if (returnString != "")
            {
                str2 = returnString;
            }
            else
            {
                int num1 = DatabaseAPI.Database.Power[nIDPower].Effects.Length - 1;
                for (int index1 = 0; index1 <= num1; ++index1)
                {
                    bool flag = false;
                    int num2 = returnMask.Length - 1;
                    for (int index2 = 0; index2 <= num2; ++index2)
                    {
                        if (index1 == returnMask[index2])
                            flag = true;
                    }
                    if (!flag)
                    {
                        if (str1 != "")
                            str1 += ", ";
                        string str3 = Strings.Trim(DatabaseAPI.Database.Power[nIDPower].Effects[index1].BuildEffectString(true, "", true, false, false));
                        if (str3.Contains("Res("))
                            str3 = str3.Replace("Res(", "Resistance(");
                        if (str3.Contains("Def("))
                            str3 = str3.Replace("Def(", "Defense(");
                        if (str3.Contains("EndRec"))
                            str3 = str3.Replace("EndRec", "Recovery");
                        if (str3.Contains("Endurance"))
                            str3 = str3.Replace("Endurance", "Max End");
                        else if (str3.Contains("End") & !str3.Contains("Max End"))
                            str3 = str3.Replace("End", "Max End");
                        str1 += str3;
                    }
                }
                str2 = str1;
            }
            return str2;
        }

        void ibClose_ButtonClicked()

        {
            this.Close();
        }

        void ibTopmost_ButtonClicked()

        {
            this.TopMost = this.ibTopmost.Checked;
            if (!this.TopMost)
                return;
            this.BringToFront();
        }

        [DebuggerStepThrough]

        void lvBonus_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.FillMagList();
        }

        void lvMag_SelectedIndexChanged(object sender, EventArgs e)

        {
            this.FillSetList();
        }

        void lvSet_SelectedIndexChanged(object sender, EventArgs e)

        {
            if (this.lvSet.SelectedItems.Count <= 0)
                return;
            this.SetInfo.SetPopup(Character.PopSetInfo(Conversions.ToInteger(this.lvSet.SelectedItems[0].Tag), null));
        }
    }
}