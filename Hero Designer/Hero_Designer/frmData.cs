using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using midsControls;

namespace Hero_Designer
{

    public partial class frmData : Form
    {
    
        internal virtual ctlPopUp pInfo
        {
            get
            {
                return this._pInfo;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pInfo = value;
            }
        }
        public frmData(ref frmMain iParent)
        {
            base.FormClosed += this.frmData_FormClosed;
            base.Load += this.frmData_Load;
            base.ResizeEnd += this.frmData_ResizeEnd;
            this.InitializeComponent();
            this.myParent = iParent;
        }
        void frmData_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StoreLocation();
            this.myParent.FloatData(false);
        }
        void frmData_Load(object sender, EventArgs e)
        {
            this.pInfo.SetPopup(default(PopUp.PopupData));
        }
        void frmData_ResizeEnd(object sender, EventArgs e)
        {
            this.pInfo.Size = base.ClientSize;
        }
        public void SetLocation()
        {
            Rectangle rectangle = default(Rectangle);
            rectangle.X = MainModule.MidsController.SzFrmData.X;
            rectangle.Y = MainModule.MidsController.SzFrmData.Y;
            rectangle.Width = MainModule.MidsController.SzFrmData.Width;
            rectangle.Height = MainModule.MidsController.SzFrmData.Height;
            if (rectangle.Width < 1)
            {
                rectangle.Width = base.Width;
            }
            if (rectangle.Height < 1)
            {
                rectangle.Height = base.Height;
            }
            if (rectangle.Width < this.MinimumSize.Width)
            {
                rectangle.Width = this.MinimumSize.Width;
            }
            if (rectangle.Height < this.MinimumSize.Height)
            {
                rectangle.Height = this.MinimumSize.Height;
            }
            if (rectangle.X < 1)
            {
                rectangle.X = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Width - base.Width) / 2.0);
            }
            if (rectangle.Y < 32)
            {
                rectangle.Y = (int)Math.Round((double)(Screen.PrimaryScreen.Bounds.Height - base.Height) / 2.0);
            }
            base.Top = rectangle.Y;
            base.Left = rectangle.X;
            base.Height = rectangle.Height;
            base.Width = rectangle.Width;
        }
        void StoreLocation()
        {
            if (MainModule.MidsController.IsAppInitialized)
            {
                MainModule.MidsController.SzFrmData.X = base.Left;
                MainModule.MidsController.SzFrmData.Y = base.Top;
                MainModule.MidsController.SzFrmData.Width = base.Width;
                MainModule.MidsController.SzFrmData.Height = base.Height;
            }
        }
        string TwoDP(float iValue)
        {
            return Strings.Format(iValue, "###,##0.00");
        }
        public void UpdateData(int powerID)
        {
            PopUp.PopupData iPopup = default(PopUp.PopupData);
            if (powerID > -1)
            {
                IPower power = DatabaseAPI.Database.Power[powerID];
                int index = iPopup.Add(null);
                iPopup.Sections[index].Add(DatabaseAPI.Database.Power[powerID].DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                iPopup.Sections[index].Add("Unbuffed Power Data", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                index = iPopup.Add(null);
                iPopup.Sections[index].Add("Attributes:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                iPopup.Sections[index].Add("Power Type:", PopUp.Colors.Text, Enum.GetName(power.PowerType.GetType(), power.PowerType), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Accuracy:", PopUp.Colors.Text, this.TwoDP(power.Accuracy), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                if (power.ActivatePeriod > 0f)
                {
                    iPopup.Sections[index].Add("Activate Interval:", PopUp.Colors.Text, Conversions.ToString(power.ActivatePeriod) + "s", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                }
                if (power.Arc > 0)
                {
                    iPopup.Sections[index].Add("Arc Radius:", PopUp.Colors.Text, Conversions.ToString(power.Arc) + "°", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                }
                if (power.AttackTypes != Enums.eVector.None)
                {
                    int[] values = (int[])Enum.GetValues(power.AttackTypes.GetType());
                    bool flag = true;
                    int num = values.Length - 1;
                    for (int index2 = 1; index2 <= num; index2++)
                    {
                        if ((power.AttackTypes & (Enums.eVector)values[index2]) > Enums.eVector.None)
                        {
                            string iText;
                            if (flag)
                            {
                                iText = "Attack Type(s):";
                                flag = false;
                            }
                            else
                            {
                                iText = "";
                            }
                            iPopup.Sections[index].Add(iText, PopUp.Colors.Text, Enum.GetName(power.AttackTypes.GetType(), values[index2]), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                        }
                    }
                }
                iPopup.Sections[index].Add("Cast Time:", PopUp.Colors.Text, this.TwoDP(power.CastTime) + "s", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Effect Area:", PopUp.Colors.Text, Enum.GetName(power.EffectArea.GetType(), power.EffectArea), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("End Cost:", PopUp.Colors.Text, this.TwoDP(power.EndCost), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Auto-Hit:", PopUp.Colors.Text, Enum.GetName(power.EntitiesAutoHit.GetType(), power.EntitiesAutoHit), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                if (power.InterruptTime != 0f)
                {
                    iPopup.Sections[index].Add("Interrupt:", PopUp.Colors.Text, this.TwoDP(power.InterruptTime) + "s", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                }
                iPopup.Sections[index].Add("Level Available:", PopUp.Colors.Text, Conversions.ToString(power.Level), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Max Targets:", PopUp.Colors.Text, Conversions.ToString(power.MaxTargets), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Notify Mobs:", PopUp.Colors.Text, Enum.GetName(power.AIReport.GetType(), power.AIReport), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                if (power.Radius != 0f)
                {
                    iPopup.Sections[index].Add("Radius:", PopUp.Colors.Text, Conversions.ToString(power.Radius) + "ft", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                }
                if (power.Range != 0f)
                {
                    iPopup.Sections[index].Add("Range:", PopUp.Colors.Text, Conversions.ToString(power.Range) + "ft", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                }
                iPopup.Sections[index].Add("RechargeTime:", PopUp.Colors.Text, Conversions.ToString(power.RechargeTime) + "s", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Target:", PopUp.Colors.Text, Enum.GetName(power.EntitiesAffected.GetType(), power.EntitiesAffected), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Line of Sight:", PopUp.Colors.Text, Conversions.ToString(power.TargetLoS), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                iPopup.Sections[index].Add("Variable:", PopUp.Colors.Text, Conversions.ToString(power.VariableEnabled), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
                if (power.VariableEnabled)
                {
                    iPopup.Sections[index].Add("Attrib:", PopUp.Colors.Text, power.VariableName, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 2);
                    iPopup.Sections[index].Add("Min:", PopUp.Colors.Text, Conversions.ToString(power.VariableMin), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 2);
                    iPopup.Sections[index].Add("Max:", PopUp.Colors.Text, Conversions.ToString(power.VariableMax), PopUp.Colors.Text, 0.9f, FontStyle.Bold, 2);
                }
                if (power.Effects.Length > 0)
                {
                    index = iPopup.Add(null);
                    iPopup.Sections[index].Add("Effects:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    IPower power2 = new Power(DatabaseAPI.Database.Power[powerID]);
                    char[] chArray = new char[]
                    {
                        '^'
                    };
                    int num2 = power.Effects.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        index = iPopup.Add(null);
                        power2.Effects[index2].Power = power2;
                        string[] strArray = power2.Effects[index2].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", "").Replace("]", "").Split(chArray);
                        int num3 = strArray.Length - 1;
                        for (int index3 = 0; index3 <= num3; index3++)
                        {
                            if (index3 == 0)
                            {
                                iPopup.Sections[index].Add(strArray[index3], PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                            }
                            else
                            {
                                iPopup.Sections[index].Add(strArray[index3], PopUp.Colors.Disabled, 0.9f, FontStyle.Italic, 2);
                            }
                        }
                    }
                }
            }
            else
            {
                int index = iPopup.Add(null);
                iPopup.Sections[index].Add("No Power", PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            }
            this.pInfo.SetPopup(iPopup);
            this.pInfo.Width = base.ClientSize.Width;
        }
        [AccessedThroughProperty("pInfo")]
        ctlPopUp _pInfo;
        frmMain myParent;
    }
}
