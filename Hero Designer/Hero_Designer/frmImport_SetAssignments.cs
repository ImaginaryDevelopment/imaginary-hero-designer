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


    public partial class frmImport_SetAssignments : Form
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


        public frmImport_SetAssignments()
        {
            base.Load += this.frmImport_SetAssignments_Load;
            this.FullFileName = "";
            this.InitializeComponent();
        }


        protected void AddSetType(int nIDPower, Enums.eSetType nSetType)
        {
            if (nIDPower > -1 & nIDPower < DatabaseAPI.Database.Power.Length)
            {
                int num = DatabaseAPI.Database.Power[nIDPower].SetTypes.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    if (DatabaseAPI.Database.Power[nIDPower].SetTypes[index] == nSetType)
                    {
                        return;
                    }
                }
                IPower[] power = DatabaseAPI.Database.Power;
                Enums.eSetType[] eSetTypeArray = (Enums.eSetType[])Utils.CopyArray(power[nIDPower].SetTypes, new Enums.eSetType[DatabaseAPI.Database.Power[nIDPower].SetTypes.Length + 1]);
                power[nIDPower].SetTypes = eSetTypeArray;
                DatabaseAPI.Database.Power[nIDPower].SetTypes[DatabaseAPI.Database.Power[nIDPower].SetTypes.Length - 1] = nSetType;
                Array.Sort<Enums.eSetType>(DatabaseAPI.Database.Power[nIDPower].SetTypes);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void btnFile_Click(object sender, EventArgs e)
        {
            this.dlgBrowse.FileName = this.FullFileName;
            if (this.dlgBrowse.ShowDialog(this) == DialogResult.OK)
            {
                this.FullFileName = this.dlgBrowse.FileName;
            }
            this.BusyHide();
            this.DisplayInfo();
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ParseClasses(this.FullFileName);
            this.BusyHide();
            this.DisplayInfo();
        }


        private void BusyHide()
        {
            if (this.bFrm != null)
            {
                this.bFrm.Close();
                this.bFrm = null;
            }
        }


        private void BusyMsg(string sMessage)
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
            this.udRevision.Value = new decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
        }


        private void frmImport_SetAssignments_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.IOAssignmentVersion.SourceFile;
            this.DisplayInfo();
        }


        private bool ParseClasses(string iFileName)
        {
            int num = 0;
            Enums.eSetType eSetType = Enums.eSetType.Untyped;
            StreamReader iStream;
            try
            {
                iStream = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                Exception ex3 = ex;
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
                return false;
            }
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            bool[] flagArray = new bool[Enum.GetValues(eSetType.GetType()).Length - 1 + 1];
            int index = -1;
            int num5 = DatabaseAPI.Database.Power.Length - 1;
            for (int index2 = 0; index2 <= num5; index2++)
            {
                DatabaseAPI.Database.Power[index2].SetTypes = new Enums.eSetType[0];
            }
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
                        if (array.Length > 1)
                        {
                            int num6 = DatabaseAPI.NidFromUidioSet(array[0]);
                            if (num6 != index & index > -1)
                            {
                                flagArray[(int)DatabaseAPI.Database.EnhancementSets[index].SetType] = true;
                            }
                            index = num6;
                            if (index > -1 && !flagArray[(int)DatabaseAPI.Database.EnhancementSets[index].SetType])
                            {
                                int nIDPower = DatabaseAPI.NidFromUidPower(array[1]);
                                if (nIDPower > -1)
                                {
                                    this.AddSetType(nIDPower, DatabaseAPI.Database.EnhancementSets[index].SetType);
                                }
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
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "IO CSV Parse Error");
                return false;
            }
            iStream.Close();
            DatabaseAPI.Database.IOAssignmentVersion.SourceFile = this.dlgBrowse.FileName;
            DatabaseAPI.Database.IOAssignmentVersion.RevisionDate = DateTime.Now;
            DatabaseAPI.Database.IOAssignmentVersion.Revision = Convert.ToInt32(this.udRevision.Value);
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
        private Button _btnClose;


        [AccessedThroughProperty("btnFile")]
        private Button _btnFile;


        [AccessedThroughProperty("btnImport")]
        private Button _btnImport;


        [AccessedThroughProperty("dlgBrowse")]
        private OpenFileDialog _dlgBrowse;


        [AccessedThroughProperty("Label8")]
        private Label _Label8;


        [AccessedThroughProperty("lblDate")]
        private Label _lblDate;


        [AccessedThroughProperty("lblFile")]
        private Label _lblFile;


        [AccessedThroughProperty("udRevision")]
        private NumericUpDown _udRevision;


        private frmBusy bFrm;


        private string FullFileName;
    }
}
