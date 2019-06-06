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


        void btnAttribIndex_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribIndex.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribIndex.Text = this.dlgBrowse.FileName;
            }
        }


        void btnAttribLoad_Click(object sender, EventArgs e)
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


        void btnAttribTable_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.lblAttribTables.Text;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.lblAttribTables.Text = this.dlgBrowse.FileName;
            }
        }


        void Button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        void DisplayInfo()
        {
            this.lblAttribIndex.Text = DatabaseAPI.Database.AttribMods.SourceIndex;
            this.lblAttribTables.Text = DatabaseAPI.Database.AttribMods.SourceTables;
            this.lblAttribDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udAttribRevision.Value = new decimal(DatabaseAPI.Database.AttribMods.Revision);
            this.lblAttribTableCount.Text = "Tables: " + Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
        }


        void frmImport_mod_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }


        [AccessedThroughProperty("btnAttribIndex")]
        Button _btnAttribIndex;


        [AccessedThroughProperty("btnAttribLoad")]
        Button _btnAttribLoad;


        [AccessedThroughProperty("btnAttribTable")]
        Button _btnAttribTable;


        [AccessedThroughProperty("Button1")]
        Button _Button1;


        [AccessedThroughProperty("dlgBrowse")]
        OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label1")]
        Label _Label1;


        [AccessedThroughProperty("Label3")]
        Label _Label3;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("lblAttribDate")]
        Label _lblAttribDate;


        [AccessedThroughProperty("lblAttribIndex")]
        Label _lblAttribIndex;


        [AccessedThroughProperty("lblAttribTableCount")]
        Label _lblAttribTableCount;


        [AccessedThroughProperty("lblAttribTables")]
        Label _lblAttribTables;


        [AccessedThroughProperty("udAttribRevision")]
        NumericUpDown _udAttribRevision;
    }
}
