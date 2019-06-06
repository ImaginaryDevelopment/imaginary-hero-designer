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


    public partial class frmImport_SalvageReq : Form
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


        public frmImport_SalvageReq()
        {
            base.Load += this.frmImport_SalvageReq_Load;
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


        void frmImport_SalvageReq_Load(object sender, EventArgs e)
        {
            this.FullFileName = DatabaseAPI.Database.PowerLevelVersion.SourceFile.Replace("powersets", "baserecipes");
            this.DisplayInfo();
        }


        bool ParseClasses(string iFileName)
        {
            int num6 = 0;
            StreamReader iStream2;
            try
            {
                iStream2 = new StreamReader(iFileName);
            }
            catch (Exception ex)
            {
                Exception ex4 = ex;
                Interaction.MsgBox(ex4.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
                return false;
            }
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            string iLine2;
            do
            {
                iLine2 = FileIO.ReadLineUnlimited(iStream2, '\0');
                if (iLine2 != null && !iLine2.StartsWith("#"))
                {
                    num9++;
                    if (num9 >= 11)
                    {
                        this.BusyMsg(string.Concat(new string[]
                        {
                            "Pass 1 of 2: ",
                            Strings.Format(num7, "###,##0"),
                            " records scanned.\r\n",
                            Strings.Format(num6, "###,##0"),
                            " records matched, ",
                            Strings.Format(num8, "###,##0"),
                            " records discarded."
                        }));
                        num9 = 0;
                    }
                    string[] array = CSV.ToArray(iLine2);
                    if (array.Length > 1)
                    {
                        int subIndex = 0;
                        int index = DatabaseAPI.NidFromUidRecipe(array[0], ref subIndex);
                        if (index > -1 & index < DatabaseAPI.Database.Recipes.Length & subIndex > -1)
                        {
                            DatabaseAPI.Database.Recipes[index].Item[subIndex].Salvage = new string[7];
                            DatabaseAPI.Database.Recipes[index].Item[subIndex].SalvageIdx = new int[7];
                            DatabaseAPI.Database.Recipes[index].Item[subIndex].Count = new int[7];
                            int index2 = 0;
                            do
                            {
                                DatabaseAPI.Database.Recipes[index].Item[subIndex].Salvage[index2] = "";
                                DatabaseAPI.Database.Recipes[index].Item[subIndex].SalvageIdx[index2] = -1;
                                DatabaseAPI.Database.Recipes[index].Item[subIndex].Count[index2] = 0;
                                index2++;
                            }
                            while (index2 <= 6);
                            num6++;
                        }
                        else
                        {
                            num8++;
                        }
                    }
                    num7++;
                }
            }
            while (iLine2 != null);
            iStream2.Close();
            try
            {
                iStream2 = new StreamReader(iFileName);
            }
            catch (Exception ex2)
            {
                Exception ex5 = ex2;
                Interaction.MsgBox(ex5.Message, MsgBoxStyle.Critical, "IO CSV Not Opened");
                return false;
            }
            num6 = 0;
            num8 = 0;
            try
            {
                do
                {
                    iLine2 = FileIO.ReadLineUnlimited(iStream2, '\0');
                    if (iLine2 != null && !iLine2.StartsWith("#"))
                    {
                        num9++;
                        if (num9 >= 11)
                        {
                            this.BusyMsg(string.Concat(new string[]
                            {
                                "Pass 2 of 2: ",
                                Strings.Format(num7, "###,##0"),
                                " records scanned.\r\n",
                                Strings.Format(num6, "###,##0"),
                                " records done, ",
                                Strings.Format(num8, "###,##0"),
                                " records discarded."
                            }));
                            num9 = 0;
                        }
                        string[] array2 = CSV.ToArray(iLine2);
                        if (array2.Length > 1)
                        {
                            int subIndex2 = 0;
                            int index3 = DatabaseAPI.NidFromUidRecipe(array2[0], ref subIndex2);
                            if (index3 > -1 & index3 < DatabaseAPI.Database.Recipes.Length & subIndex2 > -1)
                            {
                                int index4 = -1;
                                int num10 = DatabaseAPI.Database.Recipes[index3].Item[subIndex2].Count.Length - 1;
                                for (int index2 = 0; index2 <= num10; index2++)
                                {
                                    if (DatabaseAPI.Database.Recipes[index3].Item[subIndex2].Count[index2] == 0)
                                    {
                                        index4 = index2;
                                        break;
                                    }
                                }
                                if (index4 > -1)
                                {
                                    DatabaseAPI.Database.Recipes[index3].Item[subIndex2].Count[index4] = (int)Math.Round(Conversion.Val(array2[1]));
                                    DatabaseAPI.Database.Recipes[index3].Item[subIndex2].Salvage[index4] = array2[2];
                                    DatabaseAPI.Database.Recipes[index3].Item[subIndex2].SalvageIdx[index4] = -1;
                                }
                                num6++;
                            }
                            else
                            {
                                num8++;
                            }
                        }
                        num7++;
                    }
                }
                while (iLine2 != null);
                this.BusyMsg("Reassigning salvage IDs and saving...");
                DatabaseAPI.AssignRecipeSalvageIDs();
            }
            catch (Exception ex3)
            {
                Exception exception = ex3;
                iStream2.Close();
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "IO CSV Parse Error");
                return false;
            }
            DatabaseAPI.SaveRecipes();
            this.DisplayInfo();
            Interaction.MsgBox(string.Concat(new string[]
            {
                "Parse Completed!\r\nTotal Records: ",
                Conversions.ToString(num7),
                "\r\nGood: ",
                Conversions.ToString(num6),
                "\r\nRejected: ",
                Conversions.ToString(num8)
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


        [AccessedThroughProperty("lblFile")]
        Label _lblFile;


        frmBusy bFrm;


        string FullFileName;
    }
}
