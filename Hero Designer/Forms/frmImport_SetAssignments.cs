
using HeroDesigner.Schema;
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
    public partial class frmImport_SetAssignments : Form
    {
        Button btnClose;

        Button btnFile;

        Button btnImport;
        OpenFileDialog dlgBrowse;
        Label Label8;
        Label lblDate;
        Label lblFile;
        NumericUpDown udRevision;

        frmBusy bFrm;

        string FullFileName;

        public frmImport_SetAssignments()
        {
            this.Load += new EventHandler(this.frmImport_SetAssignments_Load);
            this.FullFileName = "";
            this.InitializeComponent();
        }

        protected void AddSetType(int nIDPower, eSetType nSetType)
        {
            if (!(nIDPower > -1 & nIDPower < DatabaseAPI.Database.Power.Length))
                return;
            int num = DatabaseAPI.Database.Power[nIDPower].SetTypes.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (DatabaseAPI.Database.Power[nIDPower].SetTypes[index] == nSetType)
                    return;
            }
            IPower[] power = DatabaseAPI.Database.Power;
            eSetType[] eSetTypeArray = (eSetType[])Utils.CopyArray((Array)power[nIDPower].SetTypes, (Array)new eSetType[DatabaseAPI.Database.Power[nIDPower].SetTypes.Length + 1]);
            power[nIDPower].SetTypes = eSetTypeArray;
            DatabaseAPI.Database.Power[nIDPower].SetTypes[DatabaseAPI.Database.Power[nIDPower].SetTypes.Length - 1] = nSetType;
            Array.Sort<eSetType>(DatabaseAPI.Database.Power[nIDPower].SetTypes);
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
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new Decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
        }


        void frmImport_SetAssignments_Load(object sender, EventArgs e)

        {
            this.FullFileName = DatabaseAPI.Database.IOAssignmentVersion.SourceFile;
            this.DisplayInfo();
        }

        [DebuggerStepThrough]

        bool ParseClasses(string iFileName)

        {
            int num1 = 0;
            eSetType eSetType = eSetType.Untyped;
            StreamReader iStream;
            try
            {
                iStream = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                int num2 = (int)Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            bool[] flagArray = new bool[Enum.GetValues(eSetType.GetType()).Length - 1 + 1];
            int index1 = -1;
            int num6 = DatabaseAPI.Database.Power.Length - 1;
            for (int index2 = 0; index2 <= num6; ++index2)
                DatabaseAPI.Database.Power[index2].SetTypes = new eSetType[0];
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
                            this.BusyMsg(Strings.Format(num3, "###,##0") + " records parsed.");
                            num5 = 0;
                        }
                        string[] array = CSV.ToArray(iLine);
                        if (array.Length > 1)
                        {
                            int num2 = DatabaseAPI.NidFromUidioSet(array[0]);
                            if (num2 != index1 & index1 > -1)
                                flagArray[(int)DatabaseAPI.Database.EnhancementSets[index1].SetType] = true;
                            index1 = num2;
                            if (index1 > -1 && !flagArray[(int)DatabaseAPI.Database.EnhancementSets[index1].SetType])
                            {
                                int nIDPower = DatabaseAPI.NidFromUidPower(array[1]);
                                if (nIDPower > -1)
                                    this.AddSetType(nIDPower, DatabaseAPI.Database.EnhancementSets[index1].SetType);
                            }
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
                int num2 = (int)Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "IO CSV Parse Error");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            iStream.Close();
            DatabaseAPI.Database.IOAssignmentVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.IOAssignmentVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.IOAssignmentVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveMainDatabase(serializer);
            this.DisplayInfo();
            int num7 = (int)Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, "File Parsed");
            return true;
        }
    }
}