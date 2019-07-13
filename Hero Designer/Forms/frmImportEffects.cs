
using Base.IO_Classes;
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
    public partial class frmImportEffects : Form
    {
        frmBusy _bFrm;

        Button btnCheckAll;

        Button btnClose;

        Button btnEraseAll;

        Button btnFile;

        Button btnImport;

        Button btnUncheckAll;
        ColumnHeader ColumnHeader1;
        ColumnHeader ColumnHeader2;
        ColumnHeader ColumnHeader3;
        ColumnHeader ColumnHeader4;
        ColumnHeader ColumnHeader5;
        ColumnHeader ColumnHeader6;

        readonly List<ListViewItem> _currentItems;
        OpenFileDialog dlgBrowse;

        string _fullFileName;

        Button HideUnchanged;

        List<EffectData> _importBuffer;
        Label Label6;
        Label Label8;
        Label lblDate;
        Label lblFile;
        ListView lstImport;

        bool _showUnchanged;
        Label txtNoAU;
        NumericUpDown udRevision;


        public frmImportEffects()
        {
            this.Load += new EventHandler(this.frmImportEffects_Load);
            this._fullFileName = "";
            this._showUnchanged = true;
            this.InitializeComponent();
            this._importBuffer = new List<EffectData>();
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

        void btnEraseAll_Click(object sender, EventArgs e)

        {
            int num1 = DatabaseAPI.Database.Power.Length - 1;
            for (int index = 0; index <= num1; ++index)
                DatabaseAPI.Database.Power[index].Effects = new IEffect[0];
            int num2 = this._importBuffer.Count - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (this._importBuffer[index].IsValid)
                    this._importBuffer[index].IsNew = true;
            }
            int num3 = (int)Interaction.MsgBox("All power effects removed!", MsgBoxStyle.OkOnly, null);
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
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowerEffectVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new Decimal(DatabaseAPI.Database.PowerEffectVersion.Revision);
            int num1 = 0;
            int num2 = DatabaseAPI.Database.Power.Length - 1;
            for (int index = 0; index <= num2; ++index)
            {
                if (DatabaseAPI.Database.Power[index].NeverAutoUpdate)
                    ++num1;
            }
            this.txtNoAU.Text = Conversions.ToString(num1) + " powers locked.";
        }

        void FillListView()

        {
            string[] items = new string[6];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = this._importBuffer.Count - 1;
            for (int index = 0; index <= num5; ++index)
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
                    items[0] = this._importBuffer[index].Data.PowerFullName;
                    items[1] = Enum.GetName(this._importBuffer[index].Data.EffectType.GetType(), this._importBuffer[index].Data.EffectType);
                    bool flag = false;
                    if (this._importBuffer[index].IsNew)
                    {
                        items[2] = "Yes";
                        if (this._importBuffer[index].IsLocked)
                            items[2] = "Lock";
                        ++num2;
                    }
                    else
                    {
                        items[2] = "No";
                        flag = this._importBuffer[index].CheckDifference(ref DatabaseAPI.Database.Power[this._importBuffer[index].Index].Effects[this._importBuffer[index].Nid], out items[5]);
                    }
                    if (flag)
                    {
                        items[3] = "Yes";
                        if (this._importBuffer[index].IsLocked)
                            items[3] = "Lock";
                        ++num3;
                    }
                    else
                        items[3] = "No";
                    if (this._importBuffer[index].IndexChanged)
                    {
                        items[4] = "Yes (" + Conversions.ToString(this._importBuffer[index].Nid) + ")";
                        if (this._importBuffer[index].IsLocked)
                            items[2] = "Lock (" + Conversions.ToString(this._importBuffer[index].Nid) + ")";
                        ++num4;
                    }
                    else
                        items[4] = "No";
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
            int num6 = (int)Interaction.MsgBox(("New: " + Conversions.ToString(num2) + "\r\nModified: " + Conversions.ToString(num3) + "\r\nRe-Indexed: " + Conversions.ToString(num4)), MsgBoxStyle.OkOnly, null);
        }

        void frmImportEffects_Load(object sender, EventArgs e)

        {
            this._fullFileName = DatabaseAPI.Database.PowerEffectVersion.SourceFile;
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
                int num2 = (int)Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
                ProjectData.ClearProjectError();
                return false;
            }
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            this._importBuffer = new List<EffectData>();
            int num6 = 0;
            int num7 = -1;
            int num8 = 0;
            int index1 = -1;
            string iString;
            do
            {
                iString = FileIO.ReadLineUnlimited(iStream, char.MinValue);
                if (iString != null && !iString.StartsWith("#"))
                {
                    ++num6;
                    if (num6 >= 99)
                    {
                        this.BusyMsg(Strings.Format(num3, "###,##0") + " records parsed.");
                        Application.DoEvents();
                        num6 = 0;
                    }
                    ++index1;
                    this._importBuffer.Add(new EffectData(iString));
                    ++num3;
                    if (!this._importBuffer[index1].IsValid)
                    {
                        ++num4;
                    }
                    else
                    {
                        ++num1;
                        EffectData effectData = this._importBuffer[index1];
                        if (num7 != effectData.Index)
                        {
                            num7 = effectData.Index;
                            num8 = 0;
                            num5 = 0;
                        }
                        else
                            ++num8;
                        effectData.Data.nID = num8;
                        effectData.Nid = num8;
                        if (effectData.Data.nID > DatabaseAPI.Database.Power[effectData.Index].Effects.Length - 1)
                        {
                            effectData.IsNew = true;
                        }
                        else
                        {
                            int index2 = effectData.Nid - num5;
                            if (effectData.CheckSimilar(ref DatabaseAPI.Database.Power[effectData.Index].Effects[index2]))
                            {
                                effectData.Nid = index2;
                                effectData.Data.nID = index2;
                                effectData.IsNew = false;
                                if (num5 > 0)
                                    effectData.IndexChanged = true;
                            }
                            else
                            {
                                effectData.IsNew = true;
                                int num2 = DatabaseAPI.Database.Power[effectData.Index].Effects.Length - 1;
                                for (int index3 = 0; index3 <= num2; ++index3)
                                {
                                    bool flag = false;
                                    if (index3 <= effectData.Nid && this._importBuffer[index1 - effectData.Nid + index3].Nid == index3)
                                        flag = true;
                                    if (!flag)
                                    {
                                        int nid = effectData.Nid;
                                        for (int index4 = 0; index4 <= nid; ++index4)
                                        {
                                            if (this._importBuffer[index1 - effectData.Nid + index4].Nid == index3)
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!flag && effectData.CheckSimilar(ref DatabaseAPI.Database.Power[effectData.Index].Effects[index3]))
                                    {
                                        effectData.Nid = index3;
                                        effectData.Data.nID = index3;
                                        effectData.IndexChanged = true;
                                        effectData.IsNew = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (effectData.IsNew)
                            ++num5;
                    }
                }
            }
            while (iString != null);
            iStream.Close();
            int num9 = (int)Interaction.MsgBox(("Parse Completed!\r\nTotal Records: " + Conversions.ToString(num3) + "\r\nGood: " + Conversions.ToString(num1) + "\r\nRejected: " + Conversions.ToString(num4)), MsgBoxStyle.Information, "File Parsed");
            return true;
        }

        bool ProcessImport()

        {
            bool flag = false;
            int num1 = 0;
            int num2 = 0;
            this.BusyMsg("Applying...");
            this.Enabled = false;
            int num3 = 0;
            int num4 = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num4; ++index)
            {
                if (this.lstImport.Items[index].Checked)
                {
                    if (!this._importBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply())
                        ++num3;
                    ++num1;
                    ++num2;
                    if (num2 >= 9)
                    {
                        this.BusyMsg("Applying: " + Conversions.ToString(index) + " records done.");
                        Application.DoEvents();
                        num2 = 0;
                    }
                }
            }
            this.Enabled = true;
            this.BusyMsg("Saving...");
            DatabaseAPI.Database.PowerEffectVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowerEffectVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowerEffectVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.MatchAllIDs(null);
            var serializer = My.MyApplication.GetSerializer();
            DatabaseAPI.SaveMainDatabase(serializer);
            this.BusyHide();
            int num5 = (int)Interaction.MsgBox(("Import of " + Conversions.ToString(num1) + " records completed!\r\nOf these, " + Conversions.ToString(num3) + " records were found read-only."), MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }
    }
}