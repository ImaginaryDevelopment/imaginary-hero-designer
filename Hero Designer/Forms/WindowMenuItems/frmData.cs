
using Base.Data_Classes;
using Base.Display;
using HeroDesigner.Schema;
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
    public partial class frmData : Form
    {
        ctlPopUp pInfo;

        readonly Action _onClosing;

        public frmData(Action onClosing)
        {
            this.FormClosed += new FormClosedEventHandler(this.frmData_FormClosed);
            this.Load += new EventHandler(this.frmData_Load);
            this.ResizeEnd += new EventHandler(this.frmData_ResizeEnd);
            this.InitializeComponent();
            this._onClosing = onClosing;
        }

        void frmData_FormClosed(object sender, FormClosedEventArgs e)

        {
            this.StoreLocation();
            this._onClosing();
        }

        void frmData_Load(object sender, EventArgs e)
        {
            this.pInfo.SetPopup(new PopUp.PopupData());
        }

        void frmData_ResizeEnd(object sender, EventArgs e)

        {
            this.pInfo.Size = this.ClientSize;
        }

        [DebuggerStepThrough]

        public void SetLocation()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = MainModule.MidsController.SzFrmData.X;
            rectangle.Y = MainModule.MidsController.SzFrmData.Y;
            rectangle.Width = MainModule.MidsController.SzFrmData.Width;
            rectangle.Height = MainModule.MidsController.SzFrmData.Height;
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
            MainModule.MidsController.SzFrmData.X = this.Left;
            MainModule.MidsController.SzFrmData.Y = this.Top;
            MainModule.MidsController.SzFrmData.Width = this.Width;
            MainModule.MidsController.SzFrmData.Height = this.Height;
        }

        string TwoDP(float iValue)

        {
            return Strings.Format(iValue, "###,##0.00");
        }

        public void UpdateData(int powerID)
        {
            PopUp.PopupData iPopup = new PopUp.PopupData();
            if (powerID > -1)
            {
                IPower power1 = DatabaseAPI.Database.Power[powerID];
                int index1 = iPopup.Add(null);
                iPopup.Sections[index1].Add(DatabaseAPI.Database.Power[powerID].DisplayName, PopUp.Colors.Title, 1.25f, System.Drawing.FontStyle.Bold, 0);
                iPopup.Sections[index1].Add("Unbuffed Power Data", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                int index2 = iPopup.Add(null);
                iPopup.Sections[index2].Add("Attributes:", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                iPopup.Sections[index2].Add("Power Type:", PopUp.Colors.Text, Enum.GetName(power1.PowerType.GetType(), power1.PowerType), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Accuracy:", PopUp.Colors.Text, this.TwoDP(power1.Accuracy), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.ActivatePeriod > 0.0)
                    iPopup.Sections[index2].Add("Activate Interval:", PopUp.Colors.Text, Conversions.ToString(power1.ActivatePeriod) + "s", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.Arc > 0)
                    iPopup.Sections[index2].Add("Arc Radius:", PopUp.Colors.Text, Conversions.ToString(power1.Arc) + "°", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.AttackTypes != eVector.None)
                {
                    int[] values = (int[])Enum.GetValues(power1.AttackTypes.GetType());
                    bool flag = true;
                    int num = values.Length - 1;
                    for (int index3 = 1; index3 <= num; ++index3)
                    {
                        if ((power1.AttackTypes & (eVector)values[index3]) > eVector.None)
                        {
                            string iText;
                            if (flag)
                            {
                                iText = "Attack Type(s):";
                                flag = false;
                            }
                            else
                                iText = "";
                            iPopup.Sections[index2].Add(iText, PopUp.Colors.Text, Enum.GetName(power1.AttackTypes.GetType(), values[index3]), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                        }
                    }
                }
                iPopup.Sections[index2].Add("Cast Time:", PopUp.Colors.Text, this.TwoDP(power1.CastTime) + "s", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Effect Area:", PopUp.Colors.Text, Enum.GetName(power1.EffectArea.GetType(), power1.EffectArea), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("End Cost:", PopUp.Colors.Text, this.TwoDP(power1.EndCost), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Auto-Hit:", PopUp.Colors.Text, Enum.GetName(power1.EntitiesAutoHit.GetType(), power1.EntitiesAutoHit), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.InterruptTime != 0.0)
                    iPopup.Sections[index2].Add("Interrupt:", PopUp.Colors.Text, this.TwoDP(power1.InterruptTime) + "s", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Level Available:", PopUp.Colors.Text, Conversions.ToString(power1.Level), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Max Targets:", PopUp.Colors.Text, Conversions.ToString(power1.MaxTargets), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Notify Mobs:", PopUp.Colors.Text, Enum.GetName(power1.AIReport.GetType(), power1.AIReport), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.Radius != 0.0)
                    iPopup.Sections[index2].Add("Radius:", PopUp.Colors.Text, Conversions.ToString(power1.Radius) + "ft", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if ((double)power1.Range != 0.0)
                    iPopup.Sections[index2].Add("Range:", PopUp.Colors.Text, Conversions.ToString(power1.Range) + "ft", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("RechargeTime:", PopUp.Colors.Text, Conversions.ToString(power1.RechargeTime) + "s", PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Target:", PopUp.Colors.Text, Enum.GetName(power1.EntitiesAffected.GetType(), power1.EntitiesAffected), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Line of Sight:", PopUp.Colors.Text, Conversions.ToString(power1.TargetLoS), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                iPopup.Sections[index2].Add("Variable:", PopUp.Colors.Text, Conversions.ToString(power1.VariableEnabled), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 1);
                if (power1.VariableEnabled)
                {
                    iPopup.Sections[index2].Add("Attrib:", PopUp.Colors.Text, power1.VariableName, PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 2);
                    iPopup.Sections[index2].Add("Min:", PopUp.Colors.Text, Conversions.ToString(power1.VariableMin), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 2);
                    iPopup.Sections[index2].Add("Max:", PopUp.Colors.Text, Conversions.ToString(power1.VariableMax), PopUp.Colors.Text, 0.9f, System.Drawing.FontStyle.Bold, 2);
                }
                if (power1.Effects.Length > 0)
                {
                    int index3 = iPopup.Add(null);
                    iPopup.Sections[index3].Add("Effects:", PopUp.Colors.Title, 1f, System.Drawing.FontStyle.Bold, 0);
                    IPower power2 = (IPower)new Power(DatabaseAPI.Database.Power[powerID]);
                    char[] chArray = new char[1] { '^' };
                    int num1 = power1.Effects.Length - 1;
                    for (int index4 = 0; index4 <= num1; ++index4)
                    {
                        int index5 = iPopup.Add(null);
                        power2.Effects[index4].SetPower(power2);
                        string[] strArray = power2.Effects[index4].BuildEffectString(false, "", false, false, false).Replace("[", "\r\n").Replace("\r\n", "^").Replace("  ", "").Replace("]", "").Split(chArray);
                        int num2 = strArray.Length - 1;
                        for (int index6 = 0; index6 <= num2; ++index6)
                        {
                            if (index6 == 0)
                                iPopup.Sections[index5].Add(strArray[index6], PopUp.Colors.Effect, 0.9f, System.Drawing.FontStyle.Bold, 1);
                            else
                                iPopup.Sections[index5].Add(strArray[index6], PopUp.Colors.Disabled, 0.9f, System.Drawing.FontStyle.Italic, 2);
                        }
                    }
                }
            }
            else
            {
                int index = iPopup.Add(null);
                iPopup.Sections[index].Add("No Power", PopUp.Colors.Title, 1.25f, System.Drawing.FontStyle.Bold, 0);
            }
            this.pInfo.SetPopup(iPopup);
            this.pInfo.Width = this.ClientSize.Width;
        }
    }
}