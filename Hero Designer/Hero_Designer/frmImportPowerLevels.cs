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


    public partial class frmImportPowerLevels : Form
    {

    
    
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


        public frmImportPowerLevels()
        {
            base.Load += this.frmImportPowerLevels_Load;
            this.FullFileName = "";
            this.InitializeComponent();
        }


        void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        void btnFile_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.FullFileName = this.dlgBrowse.FileName;
            }
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
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
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
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.PowerLevelVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new decimal(DatabaseAPI.Database.PowerLevelVersion.Revision);
        }


        void frmImportPowerLevels_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile;
            this.DisplayInfo();
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
                Exception ex3 = ex;
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "Power CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            try
            {
                string iLine;
                do
                {
                    iLine = FileIO.ReadLineUnlimited(iStream, '\0');
                    if (iLine != null && !iLine.StartsWith("#"))
                    {
                        num4++;
                        if (num4 >= 9)
                        {
                            this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
                            num4 = 0;
                        }
                        string[] array = CSV.ToArray(iLine);
                        int index = DatabaseAPI.NidFromUidPower(array[1]);
                        if (index > -1)
                        {
                            DatabaseAPI.Database.Power[index].Level = (int)Math.Round(Conversion.Val(array[2]) + 1.0);
                            int index2 = DatabaseAPI.NidFromUidPowerset(DatabaseAPI.Database.Power[index].FullSetName);
                            if (index2 > -1 && DatabaseAPI.Database.Powersets[index2].SetType == Enums.ePowerSetType.Pool && DatabaseAPI.Database.Power[index].Level == 1)
                            {
                                DatabaseAPI.Database.Power[index].Level = 4;
                            }
                            num++;
                        }
                        else
                        {
                            num3++;
                        }
                        num2++;
                    }
                }
                while (iLine != null);
            }
            catch (Exception ex2)
            {
                Exception exception = ex2;
                iStream.Close();
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Power Class CSV Parse Error");
                return false;
            }
            iStream.Close();
            DatabaseAPI.Database.PowerLevelVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.PowerLevelVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.PowerLevelVersion.Revision = Convert.ToInt32(this.udRevision.Value);
            DatabaseAPI.SaveMainDatabase();
            this.DisplayInfo();
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


        [AccessedThroughProperty("btnClose")]
        Button _btnClose;


        [AccessedThroughProperty("btnFile")]
        Button _btnFile;


        [AccessedThroughProperty("btnImport")]
        Button _btnImport;


        [AccessedThroughProperty("dlgBrowse")]
        OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label3")]
        Label _Label3;


        [AccessedThroughProperty("Label8")]
        Label _Label8;


        [AccessedThroughProperty("lblDate")]
        Label _lblDate;


        [AccessedThroughProperty("lblFile")]
        Label _lblFile;


        [AccessedThroughProperty("udRevision")]
        NumericUpDown _udRevision;


        frmBusy bFrm;


        string FullFileName;
    }
}
