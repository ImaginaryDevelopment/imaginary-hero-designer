
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Hero_Designer
{
    public partial class frmImportEnhSets : Form
    {
        frmBusy _bFrm;

        readonly List<ListViewItem> _currentItems;

        string _fullFileName;

        List<EnhSetData> _importBuffer;

        bool _showUnchanged;


        public frmImportEnhSets()
        {
            this.Load += new EventHandler(this.frmImportEnhSets_Load);
            this._fullFileName = "";
            this._showUnchanged = true;
            this.InitializeComponent();
            this.Name = nameof(frmImportEnhSets);
            var componentResourceManager = new ComponentResourceManager(typeof(frmImportEnhSets));
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this._importBuffer = new List<EnhSetData>();
            this._currentItems = new List<ListViewItem>();
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
            this.dlgBrowse.FileName = this._fullFileName;
            if (this.dlgBrowse.ShowDialog((IWin32Window)this) == DialogResult.OK)
            {
                this._fullFileName = this.dlgBrowse.FileName;
                this.Enabled = false;
                if (this.ParseClasses(this._fullFileName))
                    this.FillListView();
                this.Enabled = true;
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
            if (this._bFrm == null)
                return;
            this._bFrm.Close();
            this._bFrm = null;
        }

        void BusyMsg(string sMessage)
        {
            if (this._bFrm == null)
            {
                this._bFrm = new frmBusy();
                this._bFrm.Show((IWin32Window)this);
            }
            this._bFrm.SetMessage(sMessage);
        }

        void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this._fullFileName);
        }

        void FillListView()
        {
            string[] items = new string[6];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = this._importBuffer.Count - 1;
            for (int index = 0; index <= num4; ++index)
            {
                ++num1;
                if (num1 >= 100)
                {
                    this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
                    Application.DoEvents();
                    num1 = 0;
                }
                if (this._importBuffer[index].IsValid)
                {
                    items[0] = this._importBuffer[index].Data.DisplayName;
                    items[1] = Enum.GetName(this._importBuffer[index].Data.SetType.GetType(), this._importBuffer[index].Data.SetType);
                    bool flag = false;
                    if (this._importBuffer[index].IsNew)
                    {
                        items[2] = "Yes";
                        ++num2;
                    }
                    else
                    {
                        items[2] = "No";
                        flag = this._importBuffer[index].CheckDifference(out items[4]);
                    }
                    if (flag)
                    {
                        items[3] = "Yes";
                        ++num3;
                    }
                    else
                        items[3] = "No";
                    ListViewItem listViewItem = new ListViewItem(items)
                    {
                        Checked = flag | this._importBuffer[index].IsNew,
                        Tag = index
                    };
                    this._currentItems.Add(listViewItem);
                    this.lstImport.Items.Add(listViewItem);
                }
            }
            if (this.lstImport.Items.Count > 0)
                this.lstImport.Items[0].EnsureVisible();
            this.lstImport.EndUpdate();
            this.HideUnchanged.Text = "Hide Unchanged";
            int num5 = (int)Interaction.MsgBox(("New: " + Conversions.ToString(num2) + "\r\nModified: " + Conversions.ToString(num3)), MsgBoxStyle.OkOnly, null);
        }

        void frmImportEnhSets_Load(object sender, EventArgs e)
        {
            this._fullFileName = "boostsets.csv";
            this.DisplayInfo();
        }

        void HideUnchanged_Click(object sender, EventArgs e)
        {
            this._showUnchanged = !this._showUnchanged;
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = this._currentItems.Count - 1;
            for (int index = 0; index <= num; ++index)
            {
                if (this._showUnchanged | this._currentItems[index].SubItems[2].Text == "Yes" | this._currentItems[index].SubItems[3].Text == "Yes")
                    this.lstImport.Items.Add(this._currentItems[index]);
            }
            this.lstImport.EndUpdate();
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
                int num2 = (int)Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
                ProjectData.ClearProjectError();
                return false;
            }
            int num3 = 0;
            int num4 = 0;
            this._importBuffer = new List<EnhSetData>();
            int num5 = 0;
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
                    this._importBuffer.Add(new EnhSetData(iString));
                    ++num3;
                    if (this._importBuffer[this._importBuffer.Count - 1].IsValid)
                        ++num1;
                    else
                        ++num4;
                }
            }
            while (iString != null);
            iStream.Close();
            int num6 = (int)Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, "File Parsed");
            return true;
        }

        bool ProcessImport()
        {
            bool flag = false;
            int num1 = 0;
            this.BusyMsg("Applying...");
            this.Enabled = false;
            int importCount = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= importCount; ++index)
            {
                if (this.lstImport.Items[index].Checked)
                {
                    this._importBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply();
                    ++num1;
                    if (num1 > 0 && num1 % 10 == 0)
                    {
                        this.BusyMsg("Applying: " + Conversions.ToString(index) + " records done.");
                        Application.DoEvents();
                    }
                }
            }
            this.Enabled = true;
            this.BusyMsg("Saving...");
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveMainDatabase(serializer);
            this.BusyHide();
            Interaction.MsgBox(("Import of " + Conversions.ToString(num1) + " records completed!"), MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }
    }
}