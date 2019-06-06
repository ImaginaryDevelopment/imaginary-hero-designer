using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{
    public partial class frmImport_EnhancementEffects : Form
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
        public frmImport_EnhancementEffects()
        {
            base.Load += this.frmImport_EnhancementEffects_Load;
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
        }
        void frmImport_EnhancementEffects_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowerEffectVersion.SourceFile;
            this.DisplayInfo();
        }
        bool ParseClasses(string iFileName)
        {
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
            this.BusyMsg("Working...");
            base.Enabled = false;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num5; index++)
            {
                IEffect[] effectArray = new IEffect[0];
                if (DatabaseAPI.Database.Enhancements[index].Power != null)
                {
                    DatabaseAPI.Database.Enhancements[index].Power.Effects = effectArray;
                }
            }
            string str = "";
            string str2;
            do
            {
                str2 = FileIO.ReadLineUnlimited(iStream, '\0');
                if (str2 != null)
                {
                    num3++;
                    if (num3 >= 101)
                    {
                        this.BusyMsg(Strings.Format(num, "###,##0") + " records parsed.");
                        Application.DoEvents();
                        num3 = 0;
                    }
                    num++;
                    string[] array = CSV.ToArray(str2);
                    if (array.Length > 0 && (!str2.StartsWith("#") & array[0].StartsWith("Boosts.")))
                    {
                        bool flag = true;
                        string uidEnh = array[0];
                        int index2 = DatabaseAPI.NidFromUidEnhExtended(uidEnh);
                        if (index2 < 0)
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            num4++;
                            IPower power = DatabaseAPI.Database.Enhancements[index2].Power;
                            power.FullName = uidEnh;
                            string[] strArray = power.FullName.Split(new char[]
                            {
                                '.'
                            });
                            power.GroupName = strArray[0];
                            power.SetName = strArray[1];
                            power.PowerName = strArray[2];
                            IPower power2 = power;
                            IEffect[] effectArray = (IEffect[])Utils.CopyArray(power2.Effects, new IEffect[power.Effects.Length + 1]);
                            power2.Effects = effectArray;
                            power.Effects[power.Effects.Length - 1] = new Effect(DatabaseAPI.Database.Enhancements[index2].Power);
                            power.Effects[power.Effects.Length - 1].ImportFromCSV(str2);
                        }
                        else
                        {
                            num2++;
                            str = str + uidEnh + "\r\n";
                        }
                    }
                }
            }
            while (str2 != null);
            iStream.Close();
            Clipboard.SetDataObject(str);
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Import Completed!\r\nTotal Records: ",
                Conversions.ToString(num),
                "\r\nGood: ",
                Conversions.ToString(num4),
                "\r\nRejected: ",
                Conversions.ToString(num2),
                "\r\nRejected List has been placed on the clipboard. Database will be saved when you click OK"
            }), MsgBoxStyle.Information, "Import Done");
            base.Enabled = true;
            this.BusyHide();
            DatabaseAPI.SaveEnhancementDb();
            this.DisplayInfo();
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
        [AccessedThroughProperty("lblFile")]
        Label _lblFile;
        frmBusy bFrm;
        string FullFileName;
    }
}
