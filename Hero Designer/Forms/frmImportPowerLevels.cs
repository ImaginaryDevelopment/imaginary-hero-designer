
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
    public partial class frmImportPowerLevels : Form
    {
        Button btnClose;

        Button btnFile;

        Button btnImport;
        OpenFileDialog dlgBrowse;
        Label Label3;
        Label Label8;
        Label lblDate;
        Label lblFile;
        NumericUpDown udRevision;

        frmBusy bFrm;

        string FullFileName;

        public frmImportPowerLevels()
        {
            this.Load += new EventHandler(this.frmImportPowerLevels_Load);
            this.FullFileName = "";
            this.InitializeComponent();
        }

        void btnClose_Click(object sender, EventArgs e)

        {
            this.Close();
        }

        void btnFile_Click(object sender, EventArgs e)

        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) == DialogResult.OK)
                this.FullFileName = this.dlgBrowse.FileName;
            this.BusyHide();
            this.DisplayInfo();
        }

        void btnImport_Click(object sender, EventArgs e)

        {
            this.ParseClasses(this.FullFileName);
            this.BusyHide();
            this.DisplayInfo();
        }

        void BusyHide()

        {
            if (this.bFrm == null)
                return;
            this.bFrm.Close();
            this.bFrm = null;
        }

        void BusyMsg(string sMessage)

        {
            if (this.bFrm == null)
            {
                this.bFrm = new frmBusy();
                this.bFrm.Show((IWin32Window)this);
            }
            this.bFrm.SetMessage(sMessage);
        }

        public void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblDate.Text = "Date: " + Strings.Format((object)DatabaseAPI.Database.PowerLevelVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new Decimal(DatabaseAPI.Database.PowerLevelVersion.Revision);
        }

        void frmImportPowerLevels_Load(object sender, EventArgs e)

        {
            this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile;
            this.DisplayInfo();
        }

        [DebuggerStepThrough]

        bool ParseClasses(string iFileName)

        {
            int num1 = 0;
            StreamReader iStream;
            try
            {
                iStream = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num2 = (int)Interaction.MsgBox((object)ex.Message, MsgBoxStyle.Critical, (object)"Power CSV Not Opened");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            try
            {
                string iLine;
                do
                {
                    iLine = FileIO.ReadLineUnlimited(iStream, char.MinValue);
                    if (iLine != null && !iLine.StartsWith("#"))
                    {
                        ++num5;
                        if (num5 >= 9)
                        {
                            this.BusyMsg(Strings.Format((object)num3, "###,##0") + " records parsed.");
                            num5 = 0;
                        }
                        string[] array = CSV.ToArray(iLine);
                        int index1 = DatabaseAPI.NidFromUidPower(array[1]);
                        if (index1 > -1)
                        {
                            DatabaseAPI.Database.Power[index1].Level = (int)Math.Round(Conversion.Val(array[2]) + 1.0);
                            int index2 = DatabaseAPI.NidFromUidPowerset(DatabaseAPI.Database.Power[index1].FullSetName);
                            if (index2 > -1 && DatabaseAPI.Database.Powersets[index2].SetType == Enums.ePowerSetType.Pool && DatabaseAPI.Database.Power[index1].Level == 1)
                                DatabaseAPI.Database.Power[index1].Level = 4;
                            ++num1;
                        }
                        else
                            ++num4;
                        ++num3;
                    }
                }
                while (iLine != null);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                iStream.Close();
                int num2 = (int)Interaction.MsgBox((object)exception.Message, MsgBoxStyle.Critical, (object)"Power Class CSV Parse Error");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            iStream.Close();
            DatabaseAPI.Database.PowerLevelVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowerLevelVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowerLevelVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.SaveMainDatabase();
            this.DisplayInfo();
            int num6 = (int)Interaction.MsgBox((object)("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, (object)"File Parsed");
            return true;
        }
    }
}