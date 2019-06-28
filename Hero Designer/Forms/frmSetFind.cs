
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
    public class frmSetFind : Form, HeroDesigner.Schema.Viewing.IControl
    {
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;

        ImageButton ibClose;

        ImageButton ibTopmost;
        ImageList ilSets;

        ListView lvBonus;

        ListView lvMag;

        ListView lvSet;
        Panel Panel1;
        ctlPopUp SetInfo;

        IContainer components;

        protected frmMain myParent;
        protected int[] SetBonusList;

        public frmSetFind(frmMain iParent)
        {
            this.FormClosed += new FormClosedEventHandler(this.frmSetFind_FormClosed);
            this.Load += new EventHandler(this.frmSetFind_Load);
            this.SetBonusList = new int[0];
            this.InitializeComponent();
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
            List = (string[])Utils.CopyArray((Array)List, (Array)new string[List.Length + 1]);
            nIDList = (int[])Utils.CopyArray((Array)nIDList, (Array)new int[List.Length + 1]);
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
            this.lvSet.Items[this.lvSet.Items.Count - 1].Tag = (object)nIDSet;
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || this.components == null)
                    return;
                this.components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        public void FillEffectList()
        {
            string[] List = new string[0];
            int[] nIDList = new int[0];
            this.lvBonus.BeginUpdate();
            this.lvBonus.Items.Clear();
            int num1 = this.SetBonusList.Length - 1;
            for (int index = 0; index <= num1; ++index)
            {
                if ((DatabaseAPI.Database.Power[this.SetBonusList[index]].EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                    this.AddEffect(ref List, ref nIDList, this.GetPowerString(this.SetBonusList[index]), -1);
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
                int num1 = this.SetBonusList.Length - 1;
                for (int index = 0; index <= num1; ++index)
                {
                    if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects.Length > 0)
                    {
                        string powerString = this.GetPowerString(this.SetBonusList[index]);
                        if (text == powerString)
                        {
                            string Effect = (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].EffectType != Enums.eEffectType.HitPoints ? (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].EffectType != Enums.eEffectType.Endurance ? Strings.Format((object)DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].MagPercent, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00") : Strings.Format((object)DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].Mag, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00")) : Strings.Format((object)(float)((double)DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].Mag / (double)MidsContext.Archetype.Hitpoints * 100.0), "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00")) + "%";
                            this.AddEffect(ref List, ref nIDList, Effect, this.SetBonusList[index]);
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
                        Tag = (object)nIDList[index]
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
                    int num = this.SetBonusList.Length - 1;
                    for (int index = 0; index <= num; ++index)
                    {
                        if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects.Length > 0)
                        {
                            string powerString = this.GetPowerString(this.SetBonusList[index]);
                            if (text == powerString)
                                this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[this.SetBonusList[index]].PowerName, this.SetBonusList[index]);
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
            this.SetBonusList = DatabaseAPI.NidPowers("Set_Bonus.Set_Bonus", "");
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
        void InitializeComponent()

        {
            this.components = (IContainer)new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSetFind));
            this.lvBonus = new ListView();
            this.ColumnHeader1 = new ColumnHeader();
            this.lvMag = new ListView();
            this.ColumnHeader2 = new ColumnHeader();
            this.lvSet = new ListView();
            this.ColumnHeader3 = new ColumnHeader();
            this.ColumnHeader4 = new ColumnHeader();
            this.ColumnHeader5 = new ColumnHeader();
            this.ColumnHeader6 = new ColumnHeader();
            this.ilSets = new ImageList(this.components);
            this.Panel1 = new Panel();
            this.ibClose = new ImageButton();
            this.ibTopmost = new ImageButton();
            this.SetInfo = new ctlPopUp();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            this.lvBonus.Columns.AddRange(new ColumnHeader[1]
            {
        this.ColumnHeader1
            });
            this.lvBonus.FullRowSelect = true;
            this.lvBonus.HideSelection = false;
            Point point = new Point(12, 12);
            this.lvBonus.Location = point;
            this.lvBonus.MultiSelect = false;
            this.lvBonus.Name = "lvBonus";
            Size size = new Size(280, 292);
            this.lvBonus.Size = size;
            this.lvBonus.TabIndex = 0;
            this.lvBonus.UseCompatibleStateImageBehavior = false;
            this.lvBonus.View = View.Details;
            this.ColumnHeader1.Text = "Bonus Effect";
            this.ColumnHeader1.Width = 254;
            this.lvMag.Columns.AddRange(new ColumnHeader[1]
            {
        this.ColumnHeader2
            });
            this.lvMag.FullRowSelect = true;
            this.lvMag.HideSelection = false;
            point = new Point(298, 12);
            this.lvMag.Location = point;
            this.lvMag.MultiSelect = false;
            this.lvMag.Name = "lvMag";
            size = new Size((int)sbyte.MaxValue, 116);
            this.lvMag.Size = size;
            this.lvMag.TabIndex = 1;
            this.lvMag.UseCompatibleStateImageBehavior = false;
            this.lvMag.View = View.Details;
            this.ColumnHeader2.Text = "Effect Strength";
            this.ColumnHeader2.Width = 99;
            this.lvSet.Columns.AddRange(new ColumnHeader[4]
            {
        this.ColumnHeader3,
        this.ColumnHeader4,
        this.ColumnHeader5,
        this.ColumnHeader6
            });
            this.lvSet.FullRowSelect = true;
            this.lvSet.HideSelection = false;
            point = new Point(298, 134);
            this.lvSet.Location = point;
            this.lvSet.MultiSelect = false;
            this.lvSet.Name = "lvSet";
            size = new Size(484, 170);
            this.lvSet.Size = size;
            this.lvSet.SmallImageList = this.ilSets;
            this.lvSet.TabIndex = 2;
            this.lvSet.UseCompatibleStateImageBehavior = false;
            this.lvSet.View = View.Details;
            this.ColumnHeader3.Text = "Set";
            this.ColumnHeader3.Width = 157;
            this.ColumnHeader4.Text = "Level";
            this.ColumnHeader4.Width = 69;
            this.ColumnHeader5.Text = "Type";
            this.ColumnHeader5.Width = 140;
            this.ColumnHeader6.Text = "Required Enh's.";
            this.ColumnHeader6.Width = 90;
            this.ilSets.ColorDepth = ColorDepth.Depth32Bit;
            size = new Size(16, 16);
            this.ilSets.ImageSize = size;
            this.ilSets.TransparentColor = Color.Transparent;
            this.Panel1.AutoScroll = true;
            this.Panel1.BackColor = Color.Black;
            this.Panel1.Controls.Add((Control)this.SetInfo);
            point = new Point(431, 12);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            size = new Size(351, 115);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 3;
            this.ibClose.Checked = false;
            this.ibClose.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(677, 310);
            this.ibClose.Location = point;
            this.ibClose.Name = "ibClose";
            size = new Size(105, 22);
            this.ibClose.Size = size;
            this.ibClose.TabIndex = 5;
            this.ibClose.TextOff = "Close";
            this.ibClose.TextOn = "Alt Text";
            this.ibClose.Toggle = false;
            this.ibTopmost.Checked = true;
            this.ibTopmost.Font = new Font("Arial", 11f, FontStyle.Bold, GraphicsUnit.Pixel, (byte)0);
            point = new Point(566, 310);
            this.ibTopmost.Location = point;
            this.ibTopmost.Name = "ibTopmost";
            size = new Size(105, 22);
            this.ibTopmost.Size = size;
            this.ibTopmost.TabIndex = 4;
            this.ibTopmost.TextOff = "Keep On Top";
            this.ibTopmost.TextOn = "Keep On Top";
            this.ibTopmost.Toggle = true;
            this.SetInfo.BXHeight = 600;
            this.SetInfo.ColumnPosition = 0.5f;
            this.SetInfo.ColumnRight = false;
            this.SetInfo.Font = new Font("Arial", 12f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.SetInfo.InternalPadding = 3;
            point = new Point(0, 0);
            this.SetInfo.Location = point;
            this.SetInfo.Name = "SetInfo";
            this.SetInfo.SectionPadding = 8;
            size = new Size(331, 198);
            this.SetInfo.Size = size;
            this.SetInfo.TabIndex = 0;
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(0, 0, 32);
            size = new Size(792, 340);
            this.ClientSize = size;
            this.Controls.Add((Control)this.ibClose);
            this.Controls.Add((Control)this.ibTopmost);
            this.Controls.Add((Control)this.Panel1);
            this.Controls.Add((Control)this.lvSet);
            this.Controls.Add((Control)this.lvMag);
            this.Controls.Add((Control)this.lvBonus);
            this.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Pixel, (byte)0);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = nameof(frmSetFind);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Set Bonus Finder";
            this.TopMost = true;
            this.Panel1.ResumeLayout(false);
            //adding events
            if (!System.Diagnostics.Debugger.IsAttached || !this.IsInDesignMode() || !System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLowerInvariant().Contains("devenv"))
            {
                this.ibClose.ButtonClicked += ibClose_ButtonClicked;
                this.ibTopmost.ButtonClicked += ibTopmost_ButtonClicked;
                this.lvBonus.SelectedIndexChanged += lvBonus_SelectedIndexChanged;
                this.lvMag.SelectedIndexChanged += lvMag_SelectedIndexChanged;
                this.lvSet.SelectedIndexChanged += lvSet_SelectedIndexChanged;
            }
            // finished with events
            this.ResumeLayout(false);
        }

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
            this.SetInfo.SetPopup(Character.PopSetInfo(Conversions.ToInteger(this.lvSet.SelectedItems[0].Tag), (PowerEntry)null));
        }
    }
}
