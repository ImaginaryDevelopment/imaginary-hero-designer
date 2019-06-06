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

        // (get) Token: 0x06000B4B RID: 2891 RVA: 0x000727F8 File Offset: 0x000709F8
        // (set) Token: 0x06000B4C RID: 2892 RVA: 0x00072810 File Offset: 0x00070A10
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


        // (get) Token: 0x06000B4D RID: 2893 RVA: 0x0007286C File Offset: 0x00070A6C
        // (set) Token: 0x06000B4E RID: 2894 RVA: 0x00072884 File Offset: 0x00070A84
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


        // (get) Token: 0x06000B4F RID: 2895 RVA: 0x000728E0 File Offset: 0x00070AE0
        // (set) Token: 0x06000B50 RID: 2896 RVA: 0x000728F8 File Offset: 0x00070AF8
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


        // (get) Token: 0x06000B51 RID: 2897 RVA: 0x00072954 File Offset: 0x00070B54
        // (set) Token: 0x06000B52 RID: 2898 RVA: 0x0007296C File Offset: 0x00070B6C
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


        // (get) Token: 0x06000B53 RID: 2899 RVA: 0x00072978 File Offset: 0x00070B78
        // (set) Token: 0x06000B54 RID: 2900 RVA: 0x00072990 File Offset: 0x00070B90
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


        // (get) Token: 0x06000B55 RID: 2901 RVA: 0x0007299C File Offset: 0x00070B9C
        // (set) Token: 0x06000B56 RID: 2902 RVA: 0x000729B4 File Offset: 0x00070BB4
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


        // (get) Token: 0x06000B57 RID: 2903 RVA: 0x000729C0 File Offset: 0x00070BC0
        // (set) Token: 0x06000B58 RID: 2904 RVA: 0x000729D8 File Offset: 0x00070BD8
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


        // (get) Token: 0x06000B59 RID: 2905 RVA: 0x000729E4 File Offset: 0x00070BE4
        // (set) Token: 0x06000B5A RID: 2906 RVA: 0x000729FC File Offset: 0x00070BFC
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


        private void frmImport_Entities_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowersetVersion.SourceFile;
            this.DisplayInfo();
        }


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
