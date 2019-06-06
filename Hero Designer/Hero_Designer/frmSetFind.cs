using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{


    public partial class frmSetFind : Form
    {

    
    
        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this._ColumnHeader1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader1 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader2
        {
            get
            {
                return this._ColumnHeader2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader2 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader3
        {
            get
            {
                return this._ColumnHeader3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader3 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader4
        {
            get
            {
                return this._ColumnHeader4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader4 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader5
        {
            get
            {
                return this._ColumnHeader5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader5 = value;
            }
        }


    
    
        internal virtual ColumnHeader ColumnHeader6
        {
            get
            {
                return this._ColumnHeader6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader6 = value;
            }
        }


    
    
        internal virtual ImageButton ibClose
        {
            get
            {
                return this._ibClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibClose_ButtonClicked);
                if (this._ibClose != null)
                {
                    this._ibClose.ButtonClicked -= clickedEventHandler;
                }
                this._ibClose = value;
                if (this._ibClose != null)
                {
                    this._ibClose.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ImageButton ibTopmost
        {
            get
            {
                return this._ibTopmost;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                ImageButton.ButtonClickedEventHandler clickedEventHandler = new ImageButton.ButtonClickedEventHandler(this.ibTopmost_ButtonClicked);
                if (this._ibTopmost != null)
                {
                    this._ibTopmost.ButtonClicked -= clickedEventHandler;
                }
                this._ibTopmost = value;
                if (this._ibTopmost != null)
                {
                    this._ibTopmost.ButtonClicked += clickedEventHandler;
                }
            }
        }


    
    
        internal virtual ImageList ilSets
        {
            get
            {
                return this._ilSets;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ilSets = value;
            }
        }


    
    
        internal virtual ListView lvBonus
        {
            get
            {
                return this._lvBonus;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvBonus_SelectedIndexChanged);
                if (this._lvBonus != null)
                {
                    this._lvBonus.SelectedIndexChanged -= eventHandler;
                }
                this._lvBonus = value;
                if (this._lvBonus != null)
                {
                    this._lvBonus.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvMag
        {
            get
            {
                return this._lvMag;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvMag_SelectedIndexChanged);
                if (this._lvMag != null)
                {
                    this._lvMag.SelectedIndexChanged -= eventHandler;
                }
                this._lvMag = value;
                if (this._lvMag != null)
                {
                    this._lvMag.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual ListView lvSet
        {
            get
            {
                return this._lvSet;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.lvSet_SelectedIndexChanged);
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged -= eventHandler;
                }
                this._lvSet = value;
                if (this._lvSet != null)
                {
                    this._lvSet.SelectedIndexChanged += eventHandler;
                }
            }
        }


    
    
        internal virtual Panel Panel1
        {
            get
            {
                return this._Panel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Panel1 = value;
            }
        }


    
    
        internal virtual ctlPopUp SetInfo
        {
            get
            {
                return this._SetInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SetInfo = value;
            }
        }


        public frmSetFind(frmMain iParent)
        {
            base.FormClosed += this.frmSetFind_FormClosed;
            base.Load += this.frmSetFind_Load;
            this.SetBonusList = new int[0];
            this.InitializeComponent();
            this.myParent = iParent;
        }


        void AddEffect(ref string[] List, ref int[] nIDList, string Effect, int nID)
        {
            int num = List.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (string.Equals(List[index], Effect, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
            List = (string[])Utils.CopyArray(List, new string[List.Length + 1]);
            nIDList = (int[])Utils.CopyArray(nIDList, new int[List.Length + 1]);
            List[List.Length - 1] = Effect;
            nIDList[List.Length - 1] = nID;
        }


        void AddSetString(int nIDSet, int BonusID)
        {
            string[] array = new string[4];
            array[0] = DatabaseAPI.Database.EnhancementSets[nIDSet].DisplayName;
            array[1] = Conversions.ToString(DatabaseAPI.Database.EnhancementSets[nIDSet].LevelMin + 1) + " - " + Conversions.ToString(DatabaseAPI.Database.EnhancementSets[nIDSet].LevelMax + 1);
            array[2] = DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[nIDSet].SetType];
            if (BonusID < 0)
            {
                array[3] = "Special";
            }
            else
            {
                array[3] = Conversions.ToString(DatabaseAPI.Database.EnhancementSets.GetSetBonusEnhCount(nIDSet, BonusID));
            }
            this.lvSet.Items.Add(new ListViewItem(array, nIDSet));
            this.lvSet.Items[this.lvSet.Items.Count - 1].Tag = nIDSet;
        }


        public void FillEffectList()
        {
            string[] List = new string[0];
            int[] nIDList = new int[0];
            this.lvBonus.BeginUpdate();
            this.lvBonus.Items.Clear();
            int num = this.SetBonusList.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if ((DatabaseAPI.Database.Power[this.SetBonusList[index]].EntitiesAutoHit & Enums.eEntity.Caster) > Enums.eEntity.None)
                {
                    this.AddEffect(ref List, ref nIDList, this.GetPowerString(this.SetBonusList[index]), -1);
                }
            }
            int num2 = List.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                ListViewItem value = new ListViewItem(List[index]);
                this.lvBonus.Items.Add(value);
            }
            this.lvBonus.Sorting = SortOrder.Ascending;
            this.lvBonus.Sort();
            if (this.lvBonus.Items.Count > 0)
            {
                this.lvBonus.Items[0].Selected = true;
            }
            this.lvBonus.EndUpdate();
        }


        public void FillImageList()
        {
            ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height);
            this.ilSets.Images.Clear();
            int num = DatabaseAPI.Database.EnhancementSets.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[index];
                if (enhancementSet.ImageIdx > -1)
                {
                    extendedBitmap.Graphics.Clear(Color.White);
                    Graphics graphics = extendedBitmap.Graphics;
                    I9Gfx.DrawEnhancementSet(ref graphics, DatabaseAPI.Database.EnhancementSets[index].ImageIdx);
                    this.ilSets.Images.Add(extendedBitmap.Bitmap);
                }
                else
                {
                    this.ilSets.Images.Add(new Bitmap(this.ilSets.ImageSize.Width, this.ilSets.ImageSize.Height));
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
                int num = this.SetBonusList.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects.Length > 0)
                    {
                        string powerString = this.GetPowerString(this.SetBonusList[index]);
                        if (text == powerString)
                        {
                            string Effect;
                            if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].EffectType == Enums.eEffectType.HitPoints)
                            {
                                Effect = Strings.Format(DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].Mag / (float)MidsContext.Archetype.Hitpoints * 100f, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00");
                            }
                            else if (DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].EffectType == Enums.eEffectType.Endurance)
                            {
                                Effect = Strings.Format(DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].Mag, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00");
                            }
                            else
                            {
                                Effect = Strings.Format(DatabaseAPI.Database.Power[this.SetBonusList[index]].Effects[0].MagPercent, "##0" + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "00");
                            }
                            Effect += "%";
                            this.AddEffect(ref List, ref nIDList, Effect, this.SetBonusList[index]);
                        }
                    }
                }
                this.lvMag.BeginUpdate();
                this.lvMag.Items.Clear();
                this.lvMag.Items.Add("All");
                int num2 = List.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    ListViewItem value = new ListViewItem(List[index])
                    {
                        Tag = nIDList[index]
                    };
                    this.lvMag.Items.Add(value);
                }
                if (this.lvMag.Items.Count > 0)
                {
                    this.lvMag.Items[0].Selected = true;
                }
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
                {
                    flag = true;
                }
                if (!flag)
                {
                    if (Conversion.Val(RuntimeHelpers.GetObjectValue(this.lvMag.SelectedItems[0].Tag)) > -1.0)
                    {
                        this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[Conversions.ToInteger(this.lvMag.SelectedItems[0].Tag)].PowerName, Conversions.ToInteger(this.lvMag.SelectedItems[0].Tag));
                    }
                }
                else
                {
                    int num = this.SetBonusList.Length - 1;
                    for (int nIDSet = 0; nIDSet <= num; nIDSet++)
                    {
                        if (DatabaseAPI.Database.Power[this.SetBonusList[nIDSet]].Effects.Length > 0)
                        {
                            string powerString = this.GetPowerString(this.SetBonusList[nIDSet]);
                            if (text == powerString)
                            {
                                this.AddEffect(ref List, ref nIDList, DatabaseAPI.Database.Power[this.SetBonusList[nIDSet]].PowerName, this.SetBonusList[nIDSet]);
                            }
                        }
                    }
                }
                int num2 = DatabaseAPI.Database.EnhancementSets.Count - 1;
                for (int nIDSet = 0; nIDSet <= num2; nIDSet++)
                {
                    int num3 = DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus.Length - 1;
                    for (int BonusID = 0; BonusID <= num3; BonusID++)
                    {
                        int num4 = DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus[BonusID].Index.Length - 1;
                        for (int index = 0; index <= num4; index++)
                        {
                            int num5 = nIDList.Length - 1;
                            for (int index2 = 0; index2 <= num5; index2++)
                            {
                                if (DatabaseAPI.Database.EnhancementSets[nIDSet].Bonus[BonusID].Index[index] == nIDList[index2])
                                {
                                    this.AddSetString(nIDSet, BonusID);
                                }
                            }
                        }
                    }
                    int num6 = DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus.Length - 1;
                    for (int BonusID = 0; BonusID <= num6; BonusID++)
                    {
                        int num7 = DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus[BonusID].Index.Length - 1;
                        for (int index = 0; index <= num7; index++)
                        {
                            int num8 = nIDList.Length - 1;
                            for (int index2 = 0; index2 <= num8; index2++)
                            {
                                if (DatabaseAPI.Database.EnhancementSets[nIDSet].SpecialBonus[BonusID].Index[index] == nIDList[index2])
                                {
                                    this.AddSetString(nIDSet, BonusID);
                                }
                            }
                        }
                    }
                }
                if (this.lvSet.Items.Count > 0)
                {
                    this.lvSet.Items[0].Selected = true;
                }
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
            this.SetInfo.SetPopup(default(PopUp.PopupData));
            this.FillImageList();
            this.FillEffectList();
        }


        string GetPowerString(int nIDPower)
        {
            string str = "";
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
                int num = DatabaseAPI.Database.Power[nIDPower].Effects.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    bool flag = false;
                    int num2 = returnMask.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        if (index == returnMask[index2])
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        if (str != "")
                        {
                            str += ", ";
                        }
                        string str3 = Strings.Trim(DatabaseAPI.Database.Power[nIDPower].Effects[index].BuildEffectString(true, "", true, false, false));
                        if (str3.Contains("Res("))
                        {
                            str3 = str3.Replace("Res(", "Resistance(");
                        }
                        if (str3.Contains("Def("))
                        {
                            str3 = str3.Replace("Def(", "Defense(");
                        }
                        if (str3.Contains("EndRec"))
                        {
                            str3 = str3.Replace("EndRec", "Recovery");
                        }
                        if (str3.Contains("Endurance"))
                        {
                            str3 = str3.Replace("Endurance", "Max End");
                        }
                        else if (str3.Contains("End") & !str3.Contains("Max End"))
                        {
                            str3 = str3.Replace("End", "Max End");
                        }
                        str += str3;
                    }
                }
                str2 = str;
            }
            return str2;
        }


        void ibClose_ButtonClicked()
        {
            base.Close();
        }


        void ibTopmost_ButtonClicked()
        {
            base.TopMost = this.ibTopmost.Checked;
            if (base.TopMost)
            {
                base.BringToFront();
            }
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
            if (this.lvSet.SelectedItems.Count > 0)
            {
                this.SetInfo.SetPopup(Character.PopSetInfo(Conversions.ToInteger(this.lvSet.SelectedItems[0].Tag), null));
            }
        }


        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;


        [AccessedThroughProperty("ColumnHeader2")]
        ColumnHeader _ColumnHeader2;


        [AccessedThroughProperty("ColumnHeader3")]
        ColumnHeader _ColumnHeader3;


        [AccessedThroughProperty("ColumnHeader4")]
        ColumnHeader _ColumnHeader4;


        [AccessedThroughProperty("ColumnHeader5")]
        ColumnHeader _ColumnHeader5;


        [AccessedThroughProperty("ColumnHeader6")]
        ColumnHeader _ColumnHeader6;


        [AccessedThroughProperty("ibClose")]
        ImageButton _ibClose;


        [AccessedThroughProperty("ibTopmost")]
        ImageButton _ibTopmost;


        [AccessedThroughProperty("ilSets")]
        ImageList _ilSets;


        [AccessedThroughProperty("lvBonus")]
        ListView _lvBonus;


        [AccessedThroughProperty("lvMag")]
        ListView _lvMag;


        [AccessedThroughProperty("lvSet")]
        ListView _lvSet;


        [AccessedThroughProperty("Panel1")]
        Panel _Panel1;


        [AccessedThroughProperty("SetInfo")]
        ctlPopUp _SetInfo;


        protected frmMain myParent;


        protected int[] SetBonusList;
    }
}
