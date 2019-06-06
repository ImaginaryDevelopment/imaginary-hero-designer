using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{


    public partial class frmImport_mod : Form
    {

        // (get) Token: 0x06000B66 RID: 2918 RVA: 0x000734B8 File Offset: 0x000716B8
        // (set) Token: 0x06000B67 RID: 2919 RVA: 0x000734D0 File Offset: 0x000716D0
        internal virtual Button btnAttribIndex
        {
            get
            {
                return this._btnAttribIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAttribIndex_Click);
                if (this._btnAttribIndex != null)
                {
                    this._btnAttribIndex.Click -= eventHandler;
                }
                this._btnAttribIndex = value;
                if (this._btnAttribIndex != null)
                {
                    this._btnAttribIndex.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000B68 RID: 2920 RVA: 0x0007352C File Offset: 0x0007172C
        // (set) Token: 0x06000B69 RID: 2921 RVA: 0x00073544 File Offset: 0x00071744
        internal virtual Button btnAttribLoad
        {
            get
            {
                return this._btnAttribLoad;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAttribLoad_Click);
                if (this._btnAttribLoad != null)
                {
                    this._btnAttribLoad.Click -= eventHandler;
                }
                this._btnAttribLoad = value;
                if (this._btnAttribLoad != null)
                {
                    this._btnAttribLoad.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000B6A RID: 2922 RVA: 0x000735A0 File Offset: 0x000717A0
        // (set) Token: 0x06000B6B RID: 2923 RVA: 0x000735B8 File Offset: 0x000717B8
        internal virtual Button btnAttribTable
        {
            get
            {
                return this._btnAttribTable;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnAttribTable_Click);
                if (this._btnAttribTable != null)
                {
                    this._btnAttribTable.Click -= eventHandler;
                }
                this._btnAttribTable = value;
                if (this._btnAttribTable != null)
                {
                    this._btnAttribTable.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000B6C RID: 2924 RVA: 0x00073614 File Offset: 0x00071814
        // (set) Token: 0x06000B6D RID: 2925 RVA: 0x0007362C File Offset: 0x0007182C
        internal virtual Button Button1
        {
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Button1_Click);
                if (this._Button1 != null)
                {
                    this._Button1.Click -= eventHandler;
                }
                this._Button1 = value;
                if (this._Button1 != null)
                {
                    this._Button1.Click += eventHandler;
                }
            }
        }


        // (get) Token: 0x06000B6E RID: 2926 RVA: 0x00073688 File Offset: 0x00071888
        // (set) Token: 0x06000B6F RID: 2927 RVA: 0x000736A0 File Offset: 0x000718A0
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


        // (get) Token: 0x06000B70 RID: 2928 RVA: 0x000736AC File Offset: 0x000718AC
        // (set) Token: 0x06000B71 RID: 2929 RVA: 0x000736C4 File Offset: 0x000718C4
        internal virtual Label Label1
        {
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label1 = value;
            }
        }


        // (get) Token: 0x06000B72 RID: 2930 RVA: 0x000736D0 File Offset: 0x000718D0
        // (set) Token: 0x06000B73 RID: 2931 RVA: 0x000736E8 File Offset: 0x000718E8
        internal virtual Label Label3
        {
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label3 = value;
            }
        }


        // (get) Token: 0x06000B74 RID: 2932 RVA: 0x000736F4 File Offset: 0x000718F4
        // (set) Token: 0x06000B75 RID: 2933 RVA: 0x0007370C File Offset: 0x0007190C
        internal virtual Label Label4
        {
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label4 = value;
            }
        }


        // (get) Token: 0x06000B76 RID: 2934 RVA: 0x00073718 File Offset: 0x00071918
        // (set) Token: 0x06000B77 RID: 2935 RVA: 0x00073730 File Offset: 0x00071930
        internal virtual Label lblAttribDate
        {
            get
            {
                return this._lblAttribDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribDate = value;
            }
        }


        // (get) Token: 0x06000B78 RID: 2936 RVA: 0x0007373C File Offset: 0x0007193C
        // (set) Token: 0x06000B79 RID: 2937 RVA: 0x00073754 File Offset: 0x00071954
        internal virtual Label lblAttribIndex
        {
            get
            {
                return this._lblAttribIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribIndex = value;
            }
        }


        // (get) Token: 0x06000B7A RID: 2938 RVA: 0x00073760 File Offset: 0x00071960
        // (set) Token: 0x06000B7B RID: 2939 RVA: 0x00073778 File Offset: 0x00071978
        internal virtual Label lblAttribTableCount
        {
            get
            {
                return this._lblAttribTableCount;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribTableCount = value;
            }
        }


        // (get) Token: 0x06000B7C RID: 2940 RVA: 0x00073784 File Offset: 0x00071984
        // (set) Token: 0x06000B7D RID: 2941 RVA: 0x0007379C File Offset: 0x0007199C
        internal virtual Label lblAttribTables
        {
            get
            {
                return this._lblAttribTables;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lblAttribTables = value;
            }
        }


        // (get) Token: 0x06000B7E RID: 2942 RVA: 0x000737A8 File Offset: 0x000719A8
        // (set) Token: 0x06000B7F RID: 2943 RVA: 0x000737C0 File Offset: 0x000719C0
        internal virtual NumericUpDown udAttribRevision
        {
            get
            {
                return this._udAttribRevision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._udAttribRevision = value;
            }
        }


        public frmImport_mod()
        {
            base.Load += this.frmImport_mod_Load;
            this.InitializeComponent();
        }


        private void btnAttribIndex_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribIndex.Text = this.dlgBrowse.FileName;
            }
        }


        private void btnAttribLoad_Click(object sender, EventArgs e)
        {
            if (this.lblAttribIndex.Text != "" & this.lblAttribTables.Text != "")
            {
                if (File.Exists(this.lblAttribIndex.Text) & File.Exists(this.lblAttribTables.Text))
                {
                    if (DatabaseAPI.Database.AttribMods.ImportModifierTablefromCSV(this.lblAttribIndex.Text, this.lblAttribTables.Text, Convert.ToInt32(this.udAttribRevision.Value)))
                    {
                        DatabaseAPI.Database.AttribMods.Store();
                        Interaction.MsgBox(Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length) + " modifier tables imported and saved.", MsgBoxStyle.Information, "Done.");
                    }
                    else
                    {
                        Interaction.MsgBox("Import failed. attempting reload of binary data file.", MsgBoxStyle.Information, "Error.");
                        if (DatabaseAPI.Database.AttribMods.Load())
                        {
                            Interaction.MsgBox("Binary reload successful.", MsgBoxStyle.Information, "Done.");
                        }
                    }
                }
                else
                {
                    Interaction.MsgBox("Files cannot be found!", MsgBoxStyle.Exclamation, "No Can Do");
                }
            }
            else
            {
                Interaction.MsgBox("Files not selected!", MsgBoxStyle.Exclamation, "No Can Do");
            }
            this.DisplayInfo();
        }


        private void btnAttribTable_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribTables.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribTables.Text = this.dlgBrowse.FileName;
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void DisplayInfo()
        {
            this.lblAttribIndex.Text = DatabaseAPI.Database.AttribMods.SourceIndex;
            this.lblAttribTables.Text = DatabaseAPI.Database.AttribMods.SourceTables;
            this.lblAttribDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udAttribRevision.Value = new decimal(DatabaseAPI.Database.AttribMods.Revision);
            this.lblAttribTableCount.Text = "Tables: " + Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
        }


        private void frmImport_mod_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }


        [AccessedThroughProperty("btnAttribIndex")]
        private Button _btnAttribIndex;


        [AccessedThroughProperty("btnAttribLoad")]
        private Button _btnAttribLoad;


        [AccessedThroughProperty("btnAttribTable")]
        private Button _btnAttribTable;


        [AccessedThroughProperty("Button1")]
        private Button _Button1;


        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label1")]
        private Label _Label1;


        [AccessedThroughProperty("Label3")]
        private Label _Label3;


        [AccessedThroughProperty("Label4")]
        private Label _Label4;


        [AccessedThroughProperty("lblAttribDate")]
        private Label _lblAttribDate;


        [AccessedThroughProperty("lblAttribIndex")]
        private Label _lblAttribIndex;


        [AccessedThroughProperty("lblAttribTableCount")]
        private Label _lblAttribTableCount;


        [AccessedThroughProperty("lblAttribTables")]
        private Label _lblAttribTables;


        [AccessedThroughProperty("udAttribRevision")]
        private NumericUpDown _udAttribRevision;
    }
}
