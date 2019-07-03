
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
    public partial class frmImport_Entities : Form
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

        public frmImport_Entities()
        {
            this.Load += new EventHandler(this.frmImport_Entities_Load);
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
                this.bFrm.Show(this);
            }
            this.bFrm.SetMessage(sMessage);
        }

        public void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new Decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
        }

        void frmImport_Entities_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
            this.DisplayInfo();
        }

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
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
                ProjectData.ClearProjectError();
                return false;
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
                    if (iLine != null)
                    {
                        if (!iLine.StartsWith("#"))
                        {
                            ++num5;
                            if (num5 >= 9)
                            {
                                this.BusyMsg(Strings.Format(num3, "###,##0") + " records parsed.");
                                num5 = 0;
                            }
                            string[] array = CSV.ToArray(iLine);
                            string uidEntity = "";
                            if (array.Length > 1)
                            {
                                int index = -2;
                                if (array[0].StartsWith("Pets."))
                                {
                                    uidEntity = "Pets_" + array[1];
                                    index = DatabaseAPI.NidFromUidEntity(uidEntity);
                                }
                                else if (array[0].StartsWith("Villain_Pets."))
                                {
                                    uidEntity = "Pets_" + array[1];
                                    index = DatabaseAPI.NidFromUidEntity(uidEntity);
                                }
                                if (index > -2)
                                {
                                    SummonedEntity.Parse(index, array[0], array[2], uidEntity);
                                    ++num1;
                                }
                                else
                                    ++num4;
                            }
                        }
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
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Entity CSV Parse Error");
                ProjectData.ClearProjectError();
                return false;
            }
            iStream.Close();
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveMainDatabase(serializer);
            this.DisplayInfo();
            Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, "File Parsed");
            return true;
        }
    }
}