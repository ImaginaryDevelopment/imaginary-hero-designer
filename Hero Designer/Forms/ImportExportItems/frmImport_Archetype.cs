
using Import;
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
    public partial class frmImport_Archetype : Form
    {

        string FullFileName;

        ArchetypeData[] ImportBuffer;

        public frmImport_Archetype()
        {
            this.Load += new EventHandler(this.frmImport_Archetype_Load);
            this.FullFileName = "";
            this.ImportBuffer = new ArchetypeData[0];
            this.InitializeComponent();
            this.Name = nameof(frmImport_Archetype);
            System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(frmImport_Archetype));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
        }

        void btnATFile_Click(object sender, EventArgs e)

        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) == DialogResult.OK)
            {
                this.FullFileName = this.dlgBrowse.FileName;
                if (this.ParseClasses(this.FullFileName))
                    this.FillListView();
            }
            this.DisplayInfo();
        }

        void btnClose_Click(object sender, EventArgs e)

        {
            this.Close();
        }

        void btnImport_Click(object sender, EventArgs e)

        {
            this.ProcessImport();
        }

        public void DisplayInfo()
        {
            this.lblATFile.Text = FileIO.StripPath(this.FullFileName);
            this.lblATDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udATRevision.Value = new Decimal(DatabaseAPI.Database.ArchetypeVersion.Revision);
            this.lblATCount.Text = "Classes: " + Conversions.ToString(DatabaseAPI.Database.Classes.Length);
        }

        void FillListView()

        {
            string[] items = new string[6];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = this.ImportBuffer.Length - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (this.ImportBuffer[index].IsValid)
                {
                    items[0] = this.ImportBuffer[index].Data.DisplayName;
                    items[1] = this.ImportBuffer[index].Data.ClassName;
                    items[2] = !this.ImportBuffer[index].Data.Playable ? "No" : "Yes";
                    items[3] = !this.ImportBuffer[index].IsNew ? "No" : "Yes";
                    bool flag = this.ImportBuffer[index].CheckDifference(out items[5]);
                    items[4] = !flag ? "No" : "Yes";
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

        void frmImport_Archetype_Load(object sender, EventArgs e)

        {
            this.FullFileName = DatabaseAPI.Database.ArchetypeVersion.SourceFile;
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
                int num2 = (int)Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Archetype Class CSV Not Opened");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            int num3 = 0;
            int num4 = 0;
            this.ImportBuffer = new ArchetypeData[0];
            try
            {
                string iString;
                do
                {
                    iString = FileIO.ReadLineUnlimited(iStream, char.MinValue);
                    if (iString != null && !iString.StartsWith("#"))
                    {
                        this.ImportBuffer = (ArchetypeData[])Utils.CopyArray(this.ImportBuffer, (Array)new ArchetypeData[this.ImportBuffer.Length + 1]);
                        this.ImportBuffer[this.ImportBuffer.Length - 1] = new ArchetypeData(iString);
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
                int num2 = (int)Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Archetype Class CSV Parse Error");
                bool flag = false;
                ProjectData.ClearProjectError();
                return flag;
            }
            iStream.Close();
            int num5 = (int)Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nBad: " + Conversions.ToString(num4)), MsgBoxStyle.Information, "File Parsed");
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
            DatabaseAPI.Database.ArchetypeVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.ArchetypeVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.ArchetypeVersion.Revision = Convert.ToInt32(this.udATRevision.Value);
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveMainDatabase(serializer);
            int num3 = (int)Interaction.MsgBox(("Import of " + Conversions.ToString(num1) + " classes completed!"), MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }
    }
}