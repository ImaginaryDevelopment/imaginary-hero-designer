using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Import;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    public partial class frmImportEffects : Form
    {
    
        internal virtual Button btnCheckAll
        {
            get
            {
                return this._btnCheckAll;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnCheckAll_Click);
                if (this._btnCheckAll != null)
                {
                    this._btnCheckAll.Click -= eventHandler;
                }
                this._btnCheckAll = value;
                if (this._btnCheckAll != null)
                {
                    this._btnCheckAll.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnClose
        {
            get
            {
                return this._btnClose;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClose_Click);
                if (this._btnClose != null)
                {
                    this._btnClose.Click -= eventHandler;
                }
                this._btnClose = value;
                if (this._btnClose != null)
                {
                    this._btnClose.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnEraseAll
        {
            get
            {
                return this._btnEraseAll;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEraseAll_Click);
                if (this._btnEraseAll != null)
                {
                    this._btnEraseAll.Click -= eventHandler;
                }
                this._btnEraseAll = value;
                if (this._btnEraseAll != null)
                {
                    this._btnEraseAll.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnFile
        {
            get
            {
                return this._btnFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnFile_Click);
                if (this._btnFile != null)
                {
                    this._btnFile.Click -= eventHandler;
                }
                this._btnFile = value;
                if (this._btnFile != null)
                {
                    this._btnFile.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnImport
        {
            get
            {
                return this._btnImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnImport_Click);
                if (this._btnImport != null)
                {
                    this._btnImport.Click -= eventHandler;
                }
                this._btnImport = value;
                if (this._btnImport != null)
                {
                    this._btnImport.Click += eventHandler;
                }
            }
        }
        internal virtual Button btnUncheckAll
        {
            get
            {
                return this._btnUncheckAll;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnUncheckAll_Click);
                if (this._btnUncheckAll != null)
                {
                    this._btnUncheckAll.Click -= eventHandler;
                }
                this._btnUncheckAll = value;
                if (this._btnUncheckAll != null)
                {
                    this._btnUncheckAll.Click += eventHandler;
                }
            }
        }
        internal virtual ColumnHeader ColumnHeader1
        {
            get
            {
                return this._ColumnHeader1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader1 = value;
            }
        }
        internal virtual ColumnHeader ColumnHeader2
        {
            get
            {
                return this._ColumnHeader2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader2 = value;
            }
        }
        internal virtual ColumnHeader ColumnHeader3
        {
            get
            {
                return this._ColumnHeader3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader3 = value;
            }
        }
        internal virtual ColumnHeader ColumnHeader4
        {
            get
            {
                return this._ColumnHeader4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader4 = value;
            }
        }
        internal virtual ColumnHeader ColumnHeader5
        {
            get
            {
                return this._ColumnHeader5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader5 = value;
            }
        }
        internal virtual ColumnHeader ColumnHeader6
        {
            get
            {
                return this._ColumnHeader6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ColumnHeader6 = value;
            }
        }
        internal virtual OpenFileDialog dlgBrowse
        {
            get
            {
                return this._dlgBrowse;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._dlgBrowse = value;
            }
        }
        internal virtual Button HideUnchanged
        {
            get
            {
                return this._HideUnchanged;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.HideUnchanged_Click);
                if (this._HideUnchanged != null)
                {
                    this._HideUnchanged.Click -= eventHandler;
                }
                this._HideUnchanged = value;
                if (this._HideUnchanged != null)
                {
                    this._HideUnchanged.Click += eventHandler;
                }
            }
        }
        internal virtual Label Label6
        {
            get
            {
                return this._Label6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label6 = value;
            }
        }
        internal virtual Label Label8
        {
            get
            {
                return this._Label8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label8 = value;
            }
        }
        internal virtual Label lblDate
        {
            get
            {
                return this._lblDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblDate = value;
            }
        }
        internal virtual Label lblFile
        {
            get
            {
                return this._lblFile;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblFile = value;
            }
        }
        internal virtual ListView lstImport
        {
            get
            {
                return this._lstImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lstImport = value;
            }
        }
        internal virtual Label txtNoAU
        {
            get
            {
                return this._txtNoAU;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._txtNoAU = value;
            }
        }
        internal virtual NumericUpDown udRevision
        {
            get
            {
                return this._udRevision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udRevision = value;
            }
        }
        public frmImportEffects()
        {
            base.Load += this.frmImportEffects_Load;
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
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = true;
            }
            this.lstImport.EndUpdate();
        }
        void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        void btnEraseAll_Click(object sender, EventArgs e)
        {
            int num = DatabaseAPI.Database.Power.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                DatabaseAPI.Database.Power[index].Effects = new IEffect[0];
            }
            int num2 = this._importBuffer.Count - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (this._importBuffer[index].IsValid)
                {
                    this._importBuffer[index].IsNew = true;
                }
            }
            Interaction.MsgBox("All power effects removed!", MsgBoxStyle.OkOnly, null);
        }
        void btnFile_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this._fullFileName;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this._fullFileName = this.dlgBrowse.FileName;
                base.Enabled = false;
                if (this.ParseClasses(this._fullFileName))
                {
                    this.FillListView();
                }
                base.Enabled = true;
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
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = false;
            }
            this.lstImport.EndUpdate();
        }
        void BusyHide()
        {
            if (this._bFrm != null)
            {
                this._bFrm.Close();
                this._bFrm = null;
            }
        }
        void BusyMsg(string sMessage)
        {
            if (this._bFrm == null)
            {
                this._bFrm = new frmBusy();
                this._bFrm.Show(this);
            }
            this._bFrm.SetMessage(sMessage);
        }
        void DisplayInfo()
        {
            this.lblFile.Text = FileIO.StripPath(this._fullFileName);
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowerEffectVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new decimal(DatabaseAPI.Database.PowerEffectVersion.Revision);
            int num = 0;
            int num2 = DatabaseAPI.Database.Power.Length - 1;
            for (int index = 0; index <= num2; index++)
            {
                if (DatabaseAPI.Database.Power[index].NeverAutoUpdate)
                {
                    num++;
                }
            }
            this.txtNoAU.Text = Conversions.ToString(num) + " powers locked.";
        }
        void FillListView()
        {
            string[] items = new string[6];
            this.lstImport.BeginUpdate();
            this.lstImport.Items.Clear();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = this._importBuffer.Count - 1;
            for (int index = 0; index <= num5; index++)
            {
                num++;
                if (num >= 100)
                {
                    this.BusyMsg(Strings.Format(index, "###,##0") + " records checked.");
                    Application.DoEvents();
                    num = 0;
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
                        {
                            items[2] = "Lock";
                        }
                        num2++;
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
                        {
                            items[3] = "Lock";
                        }
                        num3++;
                    }
                    else
                    {
                        items[3] = "No";
                    }
                    if (this._importBuffer[index].IndexChanged)
                    {
                        items[4] = "Yes (" + Conversions.ToString(this._importBuffer[index].Nid) + ")";
                        if (this._importBuffer[index].IsLocked)
                        {
                            items[2] = "Lock (" + Conversions.ToString(this._importBuffer[index].Nid) + ")";
                        }
                        num4++;
                    }
                    else
                    {
                        items[4] = "No";
                    }
                    ListViewItem listViewItem = new ListViewItem(items)
                    {
                        Checked = (flag | this._importBuffer[index].IsNew),
                        Tag = index
                    };
                    this._currentItems.Add(listViewItem);
                    this.lstImport.Items.Add(listViewItem);
                }
            }
            if (this.lstImport.Items.Count > 0)
            {
                this.lstImport.Items[0].EnsureVisible();
            }
            this.lstImport.EndUpdate();
            this.HideUnchanged.Text = "Hide Unchanged";
            Interaction.MsgBox(string.Concat(new string[]
            {
                "New: ",
                Conversions.ToString(num2),
                "\r\nModified: ",
                Conversions.ToString(num3),
                "\r\nRe-Indexed: ",
                Conversions.ToString(num4)
            }), MsgBoxStyle.OkOnly, null);
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
            for (int index = 0; index <= num; index++)
            {
                if (this._showUnchanged | this._currentItems[index].SubItems[2].Text == "Yes" | this._currentItems[index].SubItems[3].Text == "Yes")
                {
                    this.lstImport.Items.Add(this._currentItems[index]);
                }
            }
            this.lstImport.EndUpdate();
        }
        bool ParseClasses(string iFileName)
        {
            int num = 0;
            StreamReader iStream;
            try
            {
                iStream = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            this._importBuffer = new List<EffectData>();
            int num5 = 0;
            int num6 = -1;
            int num7 = 0;
            int index = -1;
            string iString;
            do
            {
                iString = FileIO.ReadLineUnlimited(iStream, '\0');
                if (iString != null && !iString.StartsWith("#"))
                {
                    num5++;
                    if (num5 >= 99)
                    {
                        this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
                        Application.DoEvents();
                        num5 = 0;
                    }
                    index++;
                    this._importBuffer.Add(new EffectData(iString));
                    num2++;
                    if (!this._importBuffer[index].IsValid)
                    {
                        num3++;
                    }
                    else
                    {
                        num++;
                        EffectData effectData = this._importBuffer[index];
                        if (num6 != effectData.Index)
                        {
                            num6 = effectData.Index;
                            num7 = 0;
                            num4 = 0;
                        }
                        else
                        {
                            num7++;
                        }
                        effectData.Data.nID = num7;
                        effectData.Nid = num7;
                        if (effectData.Data.nID > DatabaseAPI.Database.Power[effectData.Index].Effects.Length - 1)
                        {
                            effectData.IsNew = true;
                        }
                        else
                        {
                            int index2 = effectData.Nid - num4;
                            if (effectData.CheckSimilar(ref DatabaseAPI.Database.Power[effectData.Index].Effects[index2]))
                            {
                                effectData.Nid = index2;
                                effectData.Data.nID = index2;
                                effectData.IsNew = false;
                                if (num4 > 0)
                                {
                                    effectData.IndexChanged = true;
                                }
                            }
                            else
                            {
                                effectData.IsNew = true;
                                int num8 = DatabaseAPI.Database.Power[effectData.Index].Effects.Length - 1;
                                for (int index3 = 0; index3 <= num8; index3++)
                                {
                                    bool flag = false;
                                    if (index3 <= effectData.Nid && this._importBuffer[index - effectData.Nid + index3].Nid == index3)
                                    {
                                        flag = true;
                                    }
                                    if (!flag)
                                    {
                                        int nid = effectData.Nid;
                                        for (int index4 = 0; index4 <= nid; index4++)
                                        {
                                            if (this._importBuffer[index - effectData.Nid + index4].Nid == index3)
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
                        {
                            num4++;
                        }
                    }
                }
            }
            while (iString != null);
            iStream.Close();
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Parse Completed!\r\nTotal Records: ",
                Conversions.ToString(num2),
                "\r\nGood: ",
                Conversions.ToString(num),
                "\r\nRejected: ",
                Conversions.ToString(num3)
            }), MsgBoxStyle.Information, "File Parsed");
            return true;
        }
        bool ProcessImport()
        {
            bool flag = false;
            int num = 0;
            int num2 = 0;
            this.BusyMsg("Applying...");
            base.Enabled = false;
            int num3 = 0;
            int num4 = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num4; index++)
            {
                if (this.lstImport.Items[index].Checked)
                {
                    if (!this._importBuffer[Conversions.ToInteger(this.lstImport.Items[index].Tag)].Apply())
                    {
                        num3++;
                    }
                    num++;
                    num2++;
                    if (num2 >= 9)
                    {
                        this.BusyMsg("Applying: " + Conversions.ToString(index) + " records done.");
                        Application.DoEvents();
                        num2 = 0;
                    }
                }
            }
            base.Enabled = true;
            this.BusyMsg("Saving...");
            DatabaseAPI.Database.PowerEffectVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowerEffectVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowerEffectVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.MatchAllIDs(null);
            DatabaseAPI.SaveMainDatabase();
            this.BusyHide();
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Import of ",
                Conversions.ToString(num),
                " records completed!\r\nOf these, ",
                Conversions.ToString(num3),
                " records were found read-only."
            }), MsgBoxStyle.Information, "Done");
            this.DisplayInfo();
            return flag;
        }
        frmBusy _bFrm;
        [AccessedThroughProperty("btnCheckAll")]
        Button _btnCheckAll;
        [AccessedThroughProperty("btnClose")]
        Button _btnClose;
        [AccessedThroughProperty("btnEraseAll")]
        Button _btnEraseAll;
        [AccessedThroughProperty("btnFile")]
        Button _btnFile;
        [AccessedThroughProperty("btnImport")]
        Button _btnImport;
        [AccessedThroughProperty("btnUncheckAll")]
        Button _btnUncheckAll;
        [AccessedThroughProperty("ColumnHeader1")]
        ColumnHeader _ColumnHeader1;
        [AccessedThroughProperty("ColumnHeader2")]
        ColumnHeader _ColumnHeader2;
        [AccessedThroughProperty("ColumnHeader3")]
        ColumnHeader _ColumnHeader3;
        [AccessedThroughProperty("ColumnHeader4")]
        ColumnHeader _ColumnHeader4;
        [AccessedThroughProperty("ColumnHeader5")]
        ColumnHeader _ColumnHeader5;
        [AccessedThroughProperty("ColumnHeader6")]
        ColumnHeader _ColumnHeader6;
        readonly List<ListViewItem> _currentItems;
        [AccessedThroughProperty("dlgBrowse")]
        OpenFileDialog _dlgBrowse;
        string _fullFileName;
        [AccessedThroughProperty("HideUnchanged")]
        Button _HideUnchanged;
        List<EffectData> _importBuffer;
        [AccessedThroughProperty("Label6")]
        Label _Label6;
        [AccessedThroughProperty("Label8")]
        Label _Label8;
        [AccessedThroughProperty("lblDate")]
        Label _lblDate;
        [AccessedThroughProperty("lblFile")]
        Label _lblFile;
        [AccessedThroughProperty("lstImport")]
        ListView _lstImport;
        bool _showUnchanged;
        [AccessedThroughProperty("txtNoAU")]
        Label _txtNoAU;
        [AccessedThroughProperty("udRevision")]
        NumericUpDown _udRevision;
    }
}
