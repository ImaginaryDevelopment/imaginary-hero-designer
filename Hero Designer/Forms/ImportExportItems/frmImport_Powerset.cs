
using Base.IO_Classes;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmImport_Powerset : Form
    {

        frmBusy bFrm;

        string FullFileName;

        PowersetData[] ImportBuffer;

        public frmImport_Powerset()
        {
            this.Load += new EventHandler(this.frmImport_Powerset_Load);
            this.FullFileName = "";
            this.ImportBuffer = new PowersetData[0];
            this.InitializeComponent();
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmImport_Powerset));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = nameof(frmImport_Powerset);
        }

        void btnCheckAll_Click(object sender, EventArgs e)

        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; ++index)
                this.lstImport.Items[index].Checked = true;
            this.lstImport.EndUpdate();
        }

        void btnClose_Click(object sender, EventArgs e)

        {
            this.Close();
        }

        void btnFile_Click(object sender, EventArgs e)

        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) == DialogResult.OK)
            {
                this.FullFileName = this.dlgBrowse.FileName;
                if (this.ParseClasses(this.FullFileName))
                    this.FillListView();
            }
            this.BusyHide();
            this.DisplayInfo();
        }

        void btnImport_Click(object sender, EventArgs e)

        {
            this.ProcessImport();
        }

        void btnUncheckAll_Click(object sender, EventArgs e)

        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; ++index)
                this.lstImport.Items[index].Checked = false;
            this.lstImport.EndUpdate();
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
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new Decimal(DatabaseAPI.Database.PowersetVersion.Revision);
            this.lblCount.Text = "Records: " + Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
        }

        void FillListView()

        {
            string[] items = new string[5];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num1 = 0;
            int num2 = this.ImportBuffer.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                ++num1;
                if (num1 >= 100)
                {
                    this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
                    num1 = 0;
                }
                if (this.ImportBuffer[index].IsValid)
                {
                    items[0] = this.ImportBuffer[index].Data.FullName;
                    items[1] = this.ImportBuffer[index].Data.GroupName;
                    items[2] = !this.ImportBuffer[index].IsNew ? "No" : "Yes";
                    bool flag = this.ImportBuffer[index].CheckDifference(out items[4]);
                    items[3] = !flag ? "No" : "Yes";
                    this.lstImport.Items.Add(new ListViewItem(items)
                    {
                        Checked = flag,
                        Tag = index
                    });
                }
            }
            if (this.lstImport.Items.Count > 0)
                this.lstImport.Items[0].EnsureVisible();
            this.lstImport.EndUpdate();
        }

        void frmImport_Powerset_Load(object sender, EventArgs e)

        {
            this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
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
                int num2 = (int)Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Powerset CSV Not Opened");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            int num3 = 0;
            int num4 = 0;
            this.ImportBuffer = new PowersetData[0];
            int num5 = 0;
            try
            {
                string iString;
                do
                {
                    iString = FileIO.ReadLineUnlimited(iStream, char.MinValue);
                    if (iString != null && !iString.StartsWith("#"))
                    {
                        ++num5;
                        if (num5 >= 100)
                        {
                            this.BusyMsg(Strings.Format(num3, "###,##0") + " records parsed.");
                            num5 = 0;
                        }
                        this.ImportBuffer = (PowersetData[])Utils.CopyArray(this.ImportBuffer, (Array)new PowersetData[this.ImportBuffer.Length + 1]);
                        this.ImportBuffer[this.ImportBuffer.Length - 1] = new PowersetData(iString);
                        ++num3;
                        if (this.ImportBuffer[this.ImportBuffer.Length - 1].IsValid)
                            ++num1;
                        else
                            ++num4;
                    }
                }
                while (iString != null);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                iStream.Close();
                int num2 = (int)Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Powerset Class CSV Parse Error");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            iStream.Close();
            int num6 = (int)Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, "File Parsed");
            return true;
        }

        bool ProcessImport()

        {
            bool flag = false;
            int num1 = 0;
            int num2 = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this.lstImport.Items[index].Checked)
                {
                    this.ImportBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
                    ++num1;
                }
            }
            DatabaseAPI.Database.PowersetVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowersetVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowersetVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.MatchAllIDs(null);
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveMainDatabase(serializer);
            int num3 = (int)Interaction.MsgBox(("Import of " + Conversions.ToString(num1) + " records completed!"), MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }
    }
}