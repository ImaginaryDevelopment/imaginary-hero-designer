
using Base.Display;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmDPSCalc : Form
    {
        CheckBox chkSortByLevel;
        CheckBox chkDamageBuffs;
        ColumnHeader chPower;
        ColumnHeader chDPA;
        ColumnHeader chDamage;
        ColumnHeader chRecharge;
        ColumnHeader chAnimation;
        ColumnHeader chEndurance;
        ColumnHeader chDamageBuff;
        ColumnHeader chResistanceDebuff;
        ColumnHeader chBuildID;

        ImageButton ibClear;

        ImageButton ibClose;

        ImageButton ibAutoMode;

        ImageButton ibTopmost;
        ImageList ilAttackChain;
        Label lblHeader;
        Label lblDPS;
        Label lblEPS;
        Label lblDPSNum;
        Label lblEPSNum;
        TextBox tbDPSOutput;

        ListView lvPower;
        Panel Panel1;
        Panel Panel2;
        ToolTip ToolTip1;

        protected ExtendedBitmap bxRecipe;

        frmMain myParent;
        frmDPSCalc.PowerList[] GlobalPowerList;

        float GlobalDamageBuff;

        public frmDPSCalc(frmMain iParent)
        {
            this.FormClosed += new FormClosedEventHandler(this.frmDPSCalc_FormClosed);
            this.Load += new EventHandler(this.frmDPSCalc_Load);
            this.InitializeComponent();
            this.Name = nameof(frmDPSCalc);
            var componentResourceManager = new ComponentResourceManager(typeof(frmDPSCalc));
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.myParent = iParent;
            this.bxRecipe = new ExtendedBitmap(I9Gfx.GetRecipeName());
        }

        void chkSortByLevel_CheckedChanged(object sender, EventArgs e)
        {
            this.FillPowerList();
        }

        void FillAttackChainWindow(frmDPSCalc.PowerList[] AttackChain)
        {
            if (this.chkSortByLevel.Checked)
            {
                for (int index = 0; (double)AttackChain[index].DPA != 0.0; ++index)
                {
                    string[] strArray = AttackChain[index].PowerName.Split('-');
                    AttackChain[index].PowerName = strArray[1];
                }
            }
            string str1 = AttackChain[0].PowerName;
            float damage = AttackChain[0].Damage;
            float endurance = AttackChain[0].Endurance;
            float animation = AttackChain[0].Animation;
            for (int index = 1; AttackChain[index].DPA != 0.0; ++index)
            {
                str1 = str1 + " --> " + AttackChain[index].PowerName;
                damage += AttackChain[index].Damage;
                animation += AttackChain[index].Animation;
                endurance += AttackChain[index].Endurance;
            }
            Label lblDpsNum = this.lblDPSNum;
            float num = damage / animation;
            string str2 = num.ToString();
            lblDpsNum.Text = str2;
            Label lblEpsNum = this.lblEPSNum;
            num = endurance / animation;
            string str3 = num.ToString();
            lblEpsNum.Text = str3;
            this.tbDPSOutput.Text = str1;
        }

        void FillPowerList()
        {
            this.GlobalDamageBuff = 0.0f;
            this.lvPower.BeginUpdate();
            this.lvPower.Items.Clear();
            this.lvPower.Sorting = SortOrder.None;
            this.lvPower.Items.Add(" - All Powers - ");
            this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = -1;
            int num = MidsContext.Character.CurrentBuild.Powers.Count - 1;
            for (int powerLocation = 0; powerLocation <= num; ++powerLocation)
            {
                if (MidsContext.Character.CurrentBuild.Powers[powerLocation].NIDPower > -1)
                {
                    bool flag = false;
                    if (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.DisplayName == "Rest")
                        flag = true;
                    for (int index = 0; index < MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects.Length && !flag; ++index)
                    {
                        if (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.Damage || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.Resistance && (double)MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].MagPercent < 0.0 || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.DamageBuff && (double)MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].Mag > 0.0 && !MidsContext.Character.CurrentBuild.Powers[powerLocation].StatInclude || MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].EffectType == Enums.eEffectType.EntCreate)
                        {
                            string text = DatabaseAPI.Database.Power[MidsContext.Character.CurrentBuild.Powers[powerLocation].NIDPower].DisplayName;
                            if (this.chkSortByLevel.Checked)
                                text = Strings.Format((MidsContext.Character.CurrentBuild.Powers[powerLocation].Level + 1), "00") + " - " + text;
                            string[] damageData = this.GetDamageData(powerLocation);
                            this.lvPower.Items.Add(text).SubItems.AddRange(damageData);
                            this.GlobalDamageBuff += float.Parse(damageData[5]) * (MidsContext.Character.CurrentBuild.Powers[powerLocation].Power.Effects[index].Duration / float.Parse(damageData[2]));
                            this.lvPower.Items[this.lvPower.Items.Count - 1].Tag = powerLocation;
                            flag = true;
                        }
                    }
                }
            }
            this.lvPower.Sorting = SortOrder.Ascending;
            this.lvPower.Sort();
            if (this.lvPower.Items.Count > 0)
            {
                this.lvPower.Items[0].Selected = true;
                this.lvPower.Items[0].Checked = true;
            }
            this.lvPower.EndUpdate();
        }

        void frmDPSCalc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StoreLocation();
            this.myParent.FloatDPSCalc(false);
        }

        void frmDPSCalc_Load(object sender, EventArgs e)
        {
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
            this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
        }

        void ibClear_ButtonClicked()
        {
            this.ibClear.Checked = true;
            for (int index = 1; index < this.lvPower.Items.Count; ++index)
                this.lvPower.Items[index].Checked = false;
            this.lvPower.Items[0].Checked = true;
            this.lvPower.Items[0].Selected = true;
            this.GlobalPowerList = new frmDPSCalc.PowerList[0];
            this.tbDPSOutput.Text = "";
            this.lblDPSNum.Text = " - Null - ";
            this.lblEPSNum.Text = " - Null - ";
            this.ibClear.Checked = false;
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
            this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
            if (!(this.ibAutoMode.TextOff == "Automagical"))
                return;
            this.CalculateDPS();
        }

        void ibClose_ButtonClicked()
        {
            this.Close();
        }

        void ibAutoMode_ButtonClicked()
        {
            if (this.ibAutoMode.TextOff == "Automagical")
            {
                this.ToolTip1.SetToolTip((Control)this.ibAutoMode, "Click to enable Automagical Mode");
                this.ibAutoMode.TextOff = "Manual";
                this.lvPower.Items[0].Selected = true;
                if (this.GlobalPowerList.Length > 0)
                {
                    string powerName1;
                    if (!this.chkSortByLevel.Checked)
                        powerName1 = this.GlobalPowerList[0].PowerName;
                    else
                        powerName1 = this.GlobalPowerList[0].PowerName.Split('-')[1];
                    this.tbDPSOutput.Text = powerName1;
                    for (int index = 1; index < this.GlobalPowerList.Length; ++index)
                    {
                        string powerName2;
                        if (!this.chkSortByLevel.Checked)
                            powerName2 = this.GlobalPowerList[index].PowerName;
                        else
                            powerName2 = this.GlobalPowerList[index].PowerName.Split('-')[1];
                        TextBox tbDpsOutput = this.tbDPSOutput;
                        tbDpsOutput.Text = tbDpsOutput.Text + " --> " + powerName2;
                    }
                }
                else
                    this.ibClear_ButtonClicked();
                int num = 1;
                while (num < this.GlobalPowerList.Length)
                    ++num;
            }
            else
            {
                this.ibAutoMode.TextOff = "Automagical";
                this.ToolTip1.SetToolTip((Control)this.ibAutoMode, "Click to enable Manual Mode");
            }
            this.CalculateDPS();
        }

        void ibTopmost_ButtonClicked()
        {
            this.TopMost = this.ibTopmost.Checked;
            if (!this.TopMost)
                return;
            this.BringToFront();
        }

        void lvPower_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Index == 0)
            {
                if (Operators.ConditionalCompareObjectLess(e.Item.Tag, 0, false) && e.Item.Checked)
                {
                    int num = this.lvPower.Items.Count - 1;
                    for (int index = 1; index <= num; ++index)
                        this.lvPower.Items[index].Checked = false;
                }
            }
            else if (e.Item.Checked)
                this.lvPower.Items[0].Checked = false;
            this.CalculateDPS();
        }

        void lvPower_Clicked(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.ibAutoMode.TextOff == "Manual" && e.Item.Index != 0 && e.Item.Selected)
            {
                e.Item.Checked = true;
                frmDPSCalc.PowerList[] globalPowerList = this.GlobalPowerList;
                this.GlobalPowerList = new frmDPSCalc.PowerList[globalPowerList.Length + 1];
                for (int index = 0; index < globalPowerList.Length; ++index)
                    this.GlobalPowerList[index] = globalPowerList[index];
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].PowerName = e.Item.Text;
                string text;
                if (!this.chkSortByLevel.Checked)
                    text = e.Item.Text;
                else
                    text = e.Item.Text.Split('-')[1];
                if (this.tbDPSOutput.Text == "")
                {
                    this.tbDPSOutput.Text = text;
                }
                else
                {
                    TextBox tbDpsOutput = this.tbDPSOutput;
                    tbDpsOutput.Text = tbDpsOutput.Text + " -->" + text;
                }
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].Damage = !(e.Item.SubItems[2].Text != "-") ? 0.0f : float.Parse(e.Item.SubItems[2].Text);
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].Endurance = float.Parse(e.Item.SubItems[5].Text);
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].Recharge = float.Parse(e.Item.SubItems[3].Text);
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].DamageBuff = float.Parse(e.Item.SubItems[6].Text);
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].ResistanceDeBuff = float.Parse(e.Item.SubItems[7].Text);
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].Animation = float.Parse(e.Item.SubItems[4].Text);
                this.GlobalPowerList[this.GlobalPowerList.Length - 1].RechargeTimer = 0.0f;
            }
            this.CalculateDPS();
        }

        void lvPower_MouseEnter(object sender, EventArgs e)
        {
            this.lvPower.Focus();
        }

        static void putInList(ref frmDPSCalc.CountingList[] tl, string item)
        {
            int num = tl.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (tl[index].Text == item)
                {
                    ++tl[index].Count;
                    return;
                }
            }
            tl = (frmDPSCalc.CountingList[])Utils.CopyArray(tl, (Array)new frmDPSCalc.CountingList[tl.Length + 1]);
            tl[tl.Length - 1].Count = 1;
            tl[tl.Length - 1].Text = item;
        }

        public void SetLocation()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = MainModule.MidsController.SzFrmRecipe.X;
            rectangle.Y = MainModule.MidsController.SzFrmRecipe.Y;
            rectangle.Width = 800;
            rectangle.Height = MainModule.MidsController.SzFrmRecipe.Height;
            if (rectangle.Width < 1)
                rectangle.Width = this.Width;
            if (rectangle.Height < 1)
                rectangle.Height = this.Height;
            if (rectangle.Width < this.MinimumSize.Width)
                rectangle.Width = this.MinimumSize.Width;
            if (rectangle.Height < this.MinimumSize.Height)
                rectangle.Height = this.MinimumSize.Height;
            if (rectangle.X < 1)
                rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - this.Width) / 2.0);
            if (rectangle.Y < 32)
                rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - this.Height) / 2.0);
            this.Top = rectangle.Y;
            this.Left = rectangle.X;
            this.Height = rectangle.Height;
            this.Width = rectangle.Width;
        }

        void StoreLocation()
        {
            if (!MainModule.MidsController.IsAppInitialized)
                return;
            MainModule.MidsController.SzFrmRecipe.X = this.Left;
            MainModule.MidsController.SzFrmRecipe.Y = this.Top;
            MainModule.MidsController.SzFrmRecipe.Width = this.Width;
            MainModule.MidsController.SzFrmRecipe.Height = this.Height;
        }

        public void UpdateData()
        {
            this.BackColor = this.myParent.BackColor;
            this.ibClose.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClose.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClose.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibTopmost.IA = this.myParent.Drawing.pImageAttributes;
            this.ibTopmost.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibTopmost.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibClear.IA = this.myParent.Drawing.pImageAttributes;
            this.ibClear.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibClear.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.ibAutoMode.IA = this.myParent.Drawing.pImageAttributes;
            this.ibAutoMode.ImageOff = this.myParent.Drawing.bxPower[2].Bitmap;
            this.ibAutoMode.ImageOn = this.myParent.Drawing.bxPower[3].Bitmap;
            this.FillPowerList();
        }

        string[] GetDamageData(int powerLocation)
        {
            IPower enhancedPower = MainModule.MidsController.Toon.GetEnhancedPower(powerLocation);
            float damageValue = enhancedPower.FXGetDamageValue();
            float rechargeTime = enhancedPower.RechargeTime;
            float num1 = (float)(Math.Ceiling((double)enhancedPower.CastTimeReal / 0.131999999284744) + 1.0) * 0.132f;
            float endCost = enhancedPower.EndCost;
            Enums.ShortFX effectMag1 = enhancedPower.GetEffectMag(Enums.eEffectType.DamageBuff, Enums.eToWho.Self, false);
            Enums.ShortFX effectMag2 = enhancedPower.GetEffectMag(Enums.eEffectType.Resistance, Enums.eToWho.Target, false);
            effectMag1.Multiply();
            effectMag2.Multiply();
            float num2 = damageValue / num1;
            string[] strArray;
            if (damageValue != 0.0)
                strArray = new string[8]
                {
          num2.ToString(),
          damageValue.ToString(),
          rechargeTime.ToString(),
          num1.ToString(),
          endCost.ToString(),
          effectMag1.Sum.ToString(),
          effectMag2.Sum.ToString(),
          powerLocation.ToString()
                };
            else
                strArray = new string[8]
                {
                      "-",
                      "-",
                      rechargeTime.ToString(),
                      num1.ToString(),
                      endCost.ToString(),
                      effectMag1.Sum.ToString(),
                      effectMag2.Sum.ToString(),
                      powerLocation.ToString()
                };
            return strArray;
        }

        void lvPower_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.lvPower.Sort();
        }

        frmDPSCalc.PowerList[] IncrementRecharge(
          frmDPSCalc.PowerList[] List,
          float Time)
        {
            for (int index1 = 0; index1 < List.Length; ++index1)
            {
                int index2 = index1;
                List[index2].RechargeTimer -= Time;
            }
            return List;
        }

        void CalculateDPS()
        {
            if (this.ibAutoMode.TextOff == "Automagical")
            {
                frmDPSCalc.PowerList[] array = new frmDPSCalc.PowerList[this.lvPower.Items.Count - 1];
                int length = 0;
                for (int index = 1; index < this.lvPower.Items.Count; ++index)
                {
                    if (this.lvPower.Items[0].Checked || this.lvPower.Items[index].Checked)
                    {
                        array[length].PowerName = this.lvPower.Items[index].Text;
                        if (this.lvPower.Items[index].SubItems[1].Text != "-")
                        {
                            array[length].Damage = float.Parse(this.lvPower.Items[index].SubItems[2].Text);
                            if (!this.chkDamageBuffs.Checked)
                            {
                                IPower basePower = MainModule.MidsController.Toon.GetBasePower(int.Parse(this.lvPower.Items[index].SubItems[8].Text), -1);
                                array[length].Damage += basePower.FXGetDamageValue() * (this.GlobalDamageBuff / 100f);
                            }
                            array[length].DPA = float.Parse(this.lvPower.Items[index].SubItems[1].Text);
                            array[length].HidenDPA = float.Parse(this.lvPower.Items[index].SubItems[1].Text);
                        }
                        array[length].Recharge = float.Parse(this.lvPower.Items[index].SubItems[3].Text);
                        array[length].Animation = float.Parse(this.lvPower.Items[index].SubItems[4].Text);
                        array[length].Endurance = float.Parse(this.lvPower.Items[index].SubItems[5].Text);
                        array[length].DamageBuff = float.Parse(this.lvPower.Items[index].SubItems[6].Text);
                        array[length].ResistanceDeBuff = float.Parse(this.lvPower.Items[index].SubItems[7].Text);
                        array[length].RechargeTimer = -1f;
                        if ((double)array[length].DamageBuff > 0.0 && (double)array[length].DPA != 0.0)
                        {
                            IPower basePower = MainModule.MidsController.Toon.GetBasePower(int.Parse(this.lvPower.Items[index].SubItems[8].Text), -1);
                            array[length].HidenDPA = basePower.FXGetDamageValue();
                            array[length].HidenDPA = array[length].HidenDPA * (array[length].DamageBuff / array[length].Recharge) / array[length].Animation;
                        }
                        ++length;
                    }
                }
                if (length < this.lvPower.Items.Count - 1)
                {
                    frmDPSCalc.PowerList[] powerListArray = array;
                    array = new frmDPSCalc.PowerList[length];
                    for (int index = 0; index < length; ++index)
                        array[index] = powerListArray[index];
                }
                if (array.Length > 1)
                {
                    Array.Sort(array, (x, y) => x.HidenDPA.CompareTo(y.HidenDPA));
                    float num1 = array[length - 1].Recharge + 5f;
                    int num2 = length - 1;
                    while ((double)num1 > 0.0 && num2 > 0)
                        num1 -= array[num2--].Animation;
                    frmDPSCalc.PowerList[] List = new frmDPSCalc.PowerList[length - num2];
                    int num3 = 0;
                    for (int index = 0; index < length - num2; ++index)
                    {
                        if ((double)array[length - 1 - index].Recharge <= 20.0)
                            List[num3++] = array[length - 1 - index];
                    }
                    float num4 = 0.0f;
                    for (int index = 0; index < List.Length; ++index)
                    {
                        if ((double)num4 < (double)List[index].Recharge)
                            num4 = List[index].Recharge;
                    }
                    frmDPSCalc.PowerList[] AttackChain = new frmDPSCalc.PowerList[20];
                    int index1 = 1;
                    int index2 = 1;
                    AttackChain[0] = List[0];
                    float animation = AttackChain[0].Animation;
                    List[0].RechargeTimer = List[0].Recharge;
                    while ((double)animation < (double)num4 + 1.0)
                    {
                        for (int index3 = index1; index3 >= 0; --index3)
                        {
                            if (index1 >= List.Length)
                            {
                                animation += 0.01f;
                                List = this.IncrementRecharge(List, 0.01f);
                            }
                            else if ((double)List[index3].RechargeTimer <= 0.0)
                                index1 = index3;
                        }
                        if (index1 >= List.Length)
                        {
                            --index1;
                            animation += 0.01f;
                            List = this.IncrementRecharge(List, 0.01f);
                        }
                        while ((double)List[index1].RechargeTimer > 0.0)
                        {
                            ++index1;
                            if (index1 >= List.Length)
                            {
                                index1 = 0;
                                animation += 0.01f;
                                List = this.IncrementRecharge(List, 0.01f);
                            }
                        }
                        AttackChain[index2] = List[index1];
                        animation += AttackChain[index2].Animation;
                        List = this.IncrementRecharge(List, AttackChain[index2].Animation);
                        List[index1].RechargeTimer = List[index1].Recharge;
                        ++index1;
                        ++index2;
                    }
                    this.FillAttackChainWindow(AttackChain);
                }
                else if (array.Length == 1)
                    this.tbDPSOutput.Text = "You cannot make an attack chain from one attack";
                else
                    this.tbDPSOutput.Text = "Come on Kiddo, gotta pick something :)";
            }
            else
            {
                float num1 = 0.0f;
                float num2 = 0.0f;
                float num3 = 0.0f;
                bool flag = true;
                for (int index = 0; index < this.GlobalPowerList.Length; ++index)
                {
                    if ((double)this.GlobalPowerList[index].Damage > 0.0)
                    {
                        num1 += this.GlobalPowerList[index].Damage;
                        num2 += this.GlobalPowerList[index].Endurance;
                        num3 += this.GlobalPowerList[index].Animation;
                        this.GlobalPowerList[index].RechargeTimer = this.GlobalPowerList[index].Recharge;
                    }
                    float animation = this.GlobalPowerList[index].Animation;
                }
                var powerListArray = new PowerList[this.GlobalPowerList.Length * 2];
                int num4 = 0;
                for (int index = 0; index < powerListArray.Length; ++index)
                {
                    if (index > this.GlobalPowerList.Length - 1)
                        num4 = index - (this.GlobalPowerList.Length - 1) - 1;
                    powerListArray[index] = this.GlobalPowerList[num4++];
                }
                for (int index1 = 0; index1 < powerListArray.Length; ++index1)
                {
                    for (int index2 = index1 + 1; index2 < powerListArray.Length; ++index2)
                    {
                        if (powerListArray[index1].PowerName != powerListArray[index2].PowerName)
                            powerListArray[index1].RechargeTimer -= powerListArray[index2].Animation;
                        else if ((double)powerListArray[index1].RechargeTimer > 0.0)
                            flag = false;
                    }
                }
                for (int index1 = powerListArray.Length - 1; index1 >= 0; --index1)
                {
                    for (int index2 = index1 - 1; index2 >= 0; --index2)
                    {
                        if (powerListArray[index1].PowerName != powerListArray[index2].PowerName)
                            powerListArray[index1].RechargeTimer -= powerListArray[index2].Animation;
                        else if ((double)powerListArray[index1].RechargeTimer > 0.0)
                            flag = false;
                    }
                }
                if (!flag)
                {
                    this.lblHeader.ForeColor = System.Drawing.Color.Red;
                    this.lblHeader.Text = "Impossible Chain";
                }
                else
                {
                    this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(192, 192, (int)byte.MaxValue);
                    this.lblHeader.Text = "You may select -All Powers- or just the powers you want to consider.";
                }
                this.lblDPSNum.Text = (num1 / num3).ToString();
                this.lblEPSNum.Text = (num2 / num3).ToString();
            }
        }

        struct CountingList
        {
            public string Text;
            public int Count;
        }

        public struct PowerList
        {
            public string PowerName;
            public float baseDamage;
            public float Damage;
            public float DPA;
            public float HidenDPA;
            public float Recharge;
            public float Animation;
            public float Endurance;
            public float DamageBuff;
            public float ResistanceDeBuff;
            public float RechargeTimer;
        }
    }
}