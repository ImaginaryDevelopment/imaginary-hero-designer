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
    // Token: 0x02000037 RID: 55

    public partial class frmImportEffects : Form
    {
        // Token: 0x17000381 RID: 897
        // (get) Token: 0x06000A7D RID: 2685 RVA: 0x0006CBC8 File Offset: 0x0006ADC8
        // (set) Token: 0x06000A7E RID: 2686 RVA: 0x0006CBE0 File Offset: 0x0006ADE0
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

        // Token: 0x17000382 RID: 898
        // (get) Token: 0x06000A7F RID: 2687 RVA: 0x0006CC3C File Offset: 0x0006AE3C
        // (set) Token: 0x06000A80 RID: 2688 RVA: 0x0006CC54 File Offset: 0x0006AE54
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

        // Token: 0x17000383 RID: 899
        // (get) Token: 0x06000A81 RID: 2689 RVA: 0x0006CCB0 File Offset: 0x0006AEB0
        // (set) Token: 0x06000A82 RID: 2690 RVA: 0x0006CCC8 File Offset: 0x0006AEC8
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

        // Token: 0x17000384 RID: 900
        // (get) Token: 0x06000A83 RID: 2691 RVA: 0x0006CD24 File Offset: 0x0006AF24
        // (set) Token: 0x06000A84 RID: 2692 RVA: 0x0006CD3C File Offset: 0x0006AF3C
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

        // Token: 0x17000385 RID: 901
        // (get) Token: 0x06000A85 RID: 2693 RVA: 0x0006CD98 File Offset: 0x0006AF98
        // (set) Token: 0x06000A86 RID: 2694 RVA: 0x0006CDB0 File Offset: 0x0006AFB0
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

        // Token: 0x17000386 RID: 902
        // (get) Token: 0x06000A87 RID: 2695 RVA: 0x0006CE0C File Offset: 0x0006B00C
        // (set) Token: 0x06000A88 RID: 2696 RVA: 0x0006CE24 File Offset: 0x0006B024
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

        // Token: 0x17000387 RID: 903
        // (get) Token: 0x06000A89 RID: 2697 RVA: 0x0006CE80 File Offset: 0x0006B080
        // (set) Token: 0x06000A8A RID: 2698 RVA: 0x0006CE98 File Offset: 0x0006B098
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

        // Token: 0x17000388 RID: 904
        // (get) Token: 0x06000A8B RID: 2699 RVA: 0x0006CEA4 File Offset: 0x0006B0A4
        // (set) Token: 0x06000A8C RID: 2700 RVA: 0x0006CEBC File Offset: 0x0006B0BC
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

        // Token: 0x17000389 RID: 905
        // (get) Token: 0x06000A8D RID: 2701 RVA: 0x0006CEC8 File Offset: 0x0006B0C8
        // (set) Token: 0x06000A8E RID: 2702 RVA: 0x0006CEE0 File Offset: 0x0006B0E0
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

        // Token: 0x1700038A RID: 906
        // (get) Token: 0x06000A8F RID: 2703 RVA: 0x0006CEEC File Offset: 0x0006B0EC
        // (set) Token: 0x06000A90 RID: 2704 RVA: 0x0006CF04 File Offset: 0x0006B104
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

        // Token: 0x1700038B RID: 907
        // (get) Token: 0x06000A91 RID: 2705 RVA: 0x0006CF10 File Offset: 0x0006B110
        // (set) Token: 0x06000A92 RID: 2706 RVA: 0x0006CF28 File Offset: 0x0006B128
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

        // Token: 0x1700038C RID: 908
        // (get) Token: 0x06000A93 RID: 2707 RVA: 0x0006CF34 File Offset: 0x0006B134
        // (set) Token: 0x06000A94 RID: 2708 RVA: 0x0006CF4C File Offset: 0x0006B14C
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

        // Token: 0x1700038D RID: 909
        // (get) Token: 0x06000A95 RID: 2709 RVA: 0x0006CF58 File Offset: 0x0006B158
        // (set) Token: 0x06000A96 RID: 2710 RVA: 0x0006CF70 File Offset: 0x0006B170
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

        // Token: 0x1700038E RID: 910
        // (get) Token: 0x06000A97 RID: 2711 RVA: 0x0006CF7C File Offset: 0x0006B17C
        // (set) Token: 0x06000A98 RID: 2712 RVA: 0x0006CF94 File Offset: 0x0006B194
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

        // Token: 0x1700038F RID: 911
        // (get) Token: 0x06000A99 RID: 2713 RVA: 0x0006CFF0 File Offset: 0x0006B1F0
        // (set) Token: 0x06000A9A RID: 2714 RVA: 0x0006D008 File Offset: 0x0006B208
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

        // Token: 0x17000390 RID: 912
        // (get) Token: 0x06000A9B RID: 2715 RVA: 0x0006D014 File Offset: 0x0006B214
        // (set) Token: 0x06000A9C RID: 2716 RVA: 0x0006D02C File Offset: 0x0006B22C
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

        // Token: 0x17000391 RID: 913
        // (get) Token: 0x06000A9D RID: 2717 RVA: 0x0006D038 File Offset: 0x0006B238
        // (set) Token: 0x06000A9E RID: 2718 RVA: 0x0006D050 File Offset: 0x0006B250
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

        // Token: 0x17000392 RID: 914
        // (get) Token: 0x06000A9F RID: 2719 RVA: 0x0006D05C File Offset: 0x0006B25C
        // (set) Token: 0x06000AA0 RID: 2720 RVA: 0x0006D074 File Offset: 0x0006B274
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

        // Token: 0x17000393 RID: 915
        // (get) Token: 0x06000AA1 RID: 2721 RVA: 0x0006D080 File Offset: 0x0006B280
        // (set) Token: 0x06000AA2 RID: 2722 RVA: 0x0006D098 File Offset: 0x0006B298
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

        // Token: 0x17000394 RID: 916
        // (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0006D0A4 File Offset: 0x0006B2A4
        // (set) Token: 0x06000AA4 RID: 2724 RVA: 0x0006D0BC File Offset: 0x0006B2BC
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

        // Token: 0x17000395 RID: 917
        // (get) Token: 0x06000AA5 RID: 2725 RVA: 0x0006D0C8 File Offset: 0x0006B2C8
        // (set) Token: 0x06000AA6 RID: 2726 RVA: 0x0006D0E0 File Offset: 0x0006B2E0
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

        // Token: 0x06000AA7 RID: 2727 RVA: 0x0006D0EC File Offset: 0x0006B2EC
        public frmImportEffects()
        {
            base.Load += this.frmImportEffects_Load;
            this._fullFileName = "";
            this._showUnchanged = true;
            this.InitializeComponent();
            this._importBuffer = new List<EffectData>();
            this._currentItems = new List<ListViewItem>();
        }

        // Token: 0x06000AA8 RID: 2728 RVA: 0x0006D144 File Offset: 0x0006B344
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = true;
            }
            this.lstImport.EndUpdate();
        }

        // Token: 0x06000AA9 RID: 2729 RVA: 0x0006D1AA File Offset: 0x0006B3AA
        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        // Token: 0x06000AAA RID: 2730 RVA: 0x0006D1B4 File Offset: 0x0006B3B4
        private void btnEraseAll_Click(object sender, EventArgs e)
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

        // Token: 0x06000AAB RID: 2731 RVA: 0x0006D25C File Offset: 0x0006B45C
        private void btnFile_Click(object sender, EventArgs e)
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

        // Token: 0x06000AAC RID: 2732 RVA: 0x0006D2DF File Offset: 0x0006B4DF
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ProcessImport();
        }

        // Token: 0x06000AAD RID: 2733 RVA: 0x0006D2EC File Offset: 0x0006B4EC
        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            this.lstImport.BeginUpdate();
            int num = this.lstImport.Items.Count - 1;
            for (int index = 0; index <= num; index++)
            {
                this.lstImport.Items[index].Checked = false;
            }
            this.lstImport.EndUpdate();
        }

        // Token: 0x06000AAE RID: 2734 RVA: 0x0006D354 File Offset: 0x0006B554
        private void BusyHide()
        {
            if (this._bFrm != null)
            {
                this._bFrm.Close();
                this._bFrm = null;
            }
        }

        // Token: 0x06000AAF RID: 2735 RVA: 0x0006D384 File Offset: 0x0006B584
        private void BusyMsg(string sMessage)
        {
            if (this._bFrm == null)
            {
                this._bFrm = new frmBusy();
                this._bFrm.Show(this);
            }
            this._bFrm.SetMessage(sMessage);
        }

        // Token: 0x06000AB0 RID: 2736 RVA: 0x0006D3CC File Offset: 0x0006B5CC
        private void DisplayInfo()
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

        // Token: 0x06000AB2 RID: 2738 RVA: 0x0006D4F8 File Offset: 0x0006B6F8
        private void FillListView()
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

        // Token: 0x06000AB3 RID: 2739 RVA: 0x0006D8B3 File Offset: 0x0006BAB3
        private void frmImportEffects_Load(object sender, EventArgs e)
        {
            this._fullFileName = DatabaseAPI.Database.PowerEffectVersion.SourceFile;
            this.DisplayInfo();
        }

        // Token: 0x06000AB4 RID: 2740 RVA: 0x0006D8D4 File Offset: 0x0006BAD4
        private void HideUnchanged_Click(object sender, EventArgs e)
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

        // Token: 0x06000AB6 RID: 2742 RVA: 0x0006E400 File Offset: 0x0006C600
        private bool ParseClasses(string iFileName)
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

        // Token: 0x06000AB7 RID: 2743 RVA: 0x0006E81C File Offset: 0x0006CA1C
        private bool ProcessImport()
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

        // Token: 0x0400044D RID: 1101
        private frmBusy _bFrm;

        // Token: 0x0400044E RID: 1102
        [AccessedThroughProperty("btnCheckAll")]
        private Button _btnCheckAll;

        // Token: 0x0400044F RID: 1103
        [AccessedThroughProperty("btnClose")]
        private Button _btnClose;

        // Token: 0x04000450 RID: 1104
        [AccessedThroughProperty("btnEraseAll")]
        private Button _btnEraseAll;

        // Token: 0x04000451 RID: 1105
        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;

        // Token: 0x04000452 RID: 1106
        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;

        // Token: 0x04000453 RID: 1107
        [AccessedThroughProperty("btnUncheckAll")]
        private Button _btnUncheckAll;

        // Token: 0x04000454 RID: 1108
        [AccessedThroughProperty("ColumnHeader1")]
        private ColumnHeader _ColumnHeader1;

        // Token: 0x04000455 RID: 1109
        [AccessedThroughProperty("ColumnHeader2")]
        private ColumnHeader _ColumnHeader2;

        // Token: 0x04000456 RID: 1110
        [AccessedThroughProperty("ColumnHeader3")]
        private ColumnHeader _ColumnHeader3;

        // Token: 0x04000457 RID: 1111
        [AccessedThroughProperty("ColumnHeader4")]
        private ColumnHeader _ColumnHeader4;

        // Token: 0x04000458 RID: 1112
        [AccessedThroughProperty("ColumnHeader5")]
        private ColumnHeader _ColumnHeader5;

        // Token: 0x04000459 RID: 1113
        [AccessedThroughProperty("ColumnHeader6")]
        private ColumnHeader _ColumnHeader6;

        // Token: 0x0400045A RID: 1114
        private readonly List<ListViewItem> _currentItems;

        // Token: 0x0400045B RID: 1115
        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;

        // Token: 0x0400045C RID: 1116
        private string _fullFileName;

        // Token: 0x0400045D RID: 1117
        [AccessedThroughProperty("HideUnchanged")]
        private Button _HideUnchanged;

        // Token: 0x0400045E RID: 1118
        private List<EffectData> _importBuffer;

        // Token: 0x0400045F RID: 1119
        [AccessedThroughProperty("Label6")]
        private Label _Label6;

        // Token: 0x04000460 RID: 1120
        [AccessedThroughProperty("Label8")]
        private Label _Label8;

        // Token: 0x04000461 RID: 1121
        [AccessedThroughProperty("lblDate")]
        private Label _lblDate;

        // Token: 0x04000462 RID: 1122
        [AccessedThroughProperty("lblFile")]
        private Label _lblFile;

        // Token: 0x04000463 RID: 1123
        [AccessedThroughProperty("lstImport")]
        private ListView _lstImport;

        // Token: 0x04000464 RID: 1124
        private bool _showUnchanged;

        // Token: 0x04000465 RID: 1125
        [AccessedThroughProperty("txtNoAU")]
        private Label _txtNoAU;

        // Token: 0x04000466 RID: 1126
        [AccessedThroughProperty("udRevision")]
        private NumericUpDown _udRevision;
    }
}
