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
    public partial class frmImport_Entities : Form
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
        public frmImport_Entities()
        {
            base.Load += this.frmImport_Entities_Load;
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
            this.lblDate.Text = "Date: " + Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.udRevision.Value = new decimal(DatabaseAPI.Database.IOAssignmentVersion.Revision);
        }
        void frmImport_Entities_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
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
                Interaction.MsgBox(ex3.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
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
                    if (iLine != null)
                    {
                        if (!iLine.StartsWith("#"))
                        {
                            num4++;
                            if (num4 >= 9)
                            {
                                this.BusyMsg(Strings.Format(num2, "###,##0") + " records parsed.");
                                num4 = 0;
                            }
                            string[] array = CSV.ToArray(iLine);
                            string uidEntity = "";
                            if (array.Length > 1)
                            {
                                int index = -2;
                                if (array[0].StartsWith("Pets."))
                                {
                                    uidEntity = "Pets_" + array[1];
                                    index = DatabaseAPI.NidFromUidEntity(uidEntity);
                                }
                                else if (array[0].StartsWith("Villain_Pets."))
                                {
                                    uidEntity = "Pets_" + array[1];
                                    index = DatabaseAPI.NidFromUidEntity(uidEntity);
                                }
                                if (index > -2)
                                {
                                    if (index < 0)
                                    {
                                        IDatabase database = DatabaseAPI.Database;
                                        SummonedEntity[] summonedEntityArray = (SummonedEntity[])Utils.CopyArray(database.Entities, new SummonedEntity[DatabaseAPI.Database.Entities.Length + 1]);
                                        database.Entities = summonedEntityArray;
                                        DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1] = new SummonedEntity();
                                        SummonedEntity entity = DatabaseAPI.Database.Entities[DatabaseAPI.Database.Entities.Length - 1];
                                        entity.UID = uidEntity;
                                        entity.nID = DatabaseAPI.Database.Entities.Length - 1;
                                        index = entity.nID;
                                    }
                                    SummonedEntity entity2 = DatabaseAPI.Database.Entities[index];
                                    entity2.DisplayName = array[2];
                                    entity2.ClassName = "Class_Minion_Pets";
                                    entity2.nClassID = DatabaseAPI.NidFromUidClass(entity2.ClassName);
                                    entity2.EntityType = Enums.eSummonEntity.Pet;
                                    entity2.PowersetFullName = new string[1];
                                    entity2.nPowerset = new int[1];
                                    entity2.PowersetFullName[0] = array[0];
                                    entity2.nPowerset[0] = DatabaseAPI.NidFromUidPowerset(entity2.PowersetFullName[0]);
                                    entity2.UpgradePowerFullName = new string[0];
                                    entity2.nUpgradePower = new int[0];
                                    num++;
                                }
                                else
                                {
                                    num3++;
                                }
                            }
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
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Entity CSV Parse Error");
                return false;
            }
            iStream.Close();
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
