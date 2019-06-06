using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Base.Data_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Hero_Designer
{

    public partial class frmCSV : Form
    {

    
    
        internal virtual Label at_Count
        {
            get
            {
                return this._at_Count;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._at_Count = value;
            }
        }


    
    
        internal virtual Label at_Date
        {
            get
            {
                return this._at_Date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._at_Date = value;
            }
        }


    
    
        internal virtual Button at_Import
        {
            get
            {
                return this._at_Import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.at_Import_Click);
                if (this._at_Import != null)
                {
                    this._at_Import.Click -= eventHandler;
                }
                this._at_Import = value;
                if (this._at_Import != null)
                {
                    this._at_Import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label at_Revision
        {
            get
            {
                return this._at_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._at_Revision = value;
            }
        }


    
    
        internal virtual Button btnBonusLookup
        {
            get
            {
                return this._btnBonusLookup;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnBonusLookup_Click);
                if (this._btnBonusLookup != null)
                {
                    this._btnBonusLookup.Click -= eventHandler;
                }
                this._btnBonusLookup = value;
                if (this._btnBonusLookup != null)
                {
                    this._btnBonusLookup.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnClearSI
        {
            get
            {
                return this._btnClearSI;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnClearSI_Click);
                if (this._btnClearSI != null)
                {
                    this._btnClearSI.Click -= eventHandler;
                }
                this._btnClearSI = value;
                if (this._btnClearSI != null)
                {
                    this._btnClearSI.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnDefiance
        {
            get
            {
                return this._btnDefiance;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnDefiance_Click);
                if (this._btnDefiance != null)
                {
                    this._btnDefiance.Click -= eventHandler;
                }
                this._btnDefiance = value;
                if (this._btnDefiance != null)
                {
                    this._btnDefiance.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnEnhEffects
        {
            get
            {
                return this._btnEnhEffects;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEnhEffects_Click);
                if (this._btnEnhEffects != null)
                {
                    this._btnEnhEffects.Click -= eventHandler;
                }
                this._btnEnhEffects = value;
                if (this._btnEnhEffects != null)
                {
                    this._btnEnhEffects.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnEntities
        {
            get
            {
                return this._btnEntities;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnEntities_Click);
                if (this._btnEntities != null)
                {
                    this._btnEntities.Click -= eventHandler;
                }
                this._btnEntities = value;
                if (this._btnEntities != null)
                {
                    this._btnEntities.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnImportRecipes
        {
            get
            {
                return this._btnImportRecipes;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnImportRecipes_Click);
                if (this._btnImportRecipes != null)
                {
                    this._btnImportRecipes.Click -= eventHandler;
                }
                this._btnImportRecipes = value;
                if (this._btnImportRecipes != null)
                {
                    this._btnImportRecipes.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnIOLevels
        {
            get
            {
                return this._btnIOLevels;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnIOLevels_Click);
                if (this._btnIOLevels != null)
                {
                    this._btnIOLevels.Click -= eventHandler;
                }
                this._btnIOLevels = value;
                if (this._btnIOLevels != null)
                {
                    this._btnIOLevels.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnSalvageUpdate
        {
            get
            {
                return this._btnSalvageUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.btnSalvageUpdate_Click);
                if (this._btnSalvageUpdate != null)
                {
                    this._btnSalvageUpdate.Click -= eventHandler;
                }
                this._btnSalvageUpdate = value;
                if (this._btnSalvageUpdate != null)
                {
                    this._btnSalvageUpdate.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnStaticExport
        {
            get
            {
                return this._btnStaticExport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(frmCSV.btnStaticExport_Click);
                if (this._btnStaticExport != null)
                {
                    this._btnStaticExport.Click -= eventHandler;
                }
                this._btnStaticExport = value;
                if (this._btnStaticExport != null)
                {
                    this._btnStaticExport.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Button btnStaticIndex
        {
            get
            {
                return this._btnStaticIndex;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.Button2_Click);
                if (this._btnStaticIndex != null)
                {
                    this._btnStaticIndex.Click -= eventHandler;
                }
                this._btnStaticIndex = value;
                if (this._btnStaticIndex != null)
                {
                    this._btnStaticIndex.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label fx_Count
        {
            get
            {
                return this._fx_Count;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fx_Count = value;
            }
        }


    
    
        internal virtual Label fx_Date
        {
            get
            {
                return this._fx_Date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fx_Date = value;
            }
        }


    
    
        internal virtual Button fx_Import
        {
            get
            {
                return this._fx_Import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.fx_Import_Click);
                if (this._fx_Import != null)
                {
                    this._fx_Import.Click -= eventHandler;
                }
                this._fx_Import = value;
                if (this._fx_Import != null)
                {
                    this._fx_Import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label fx_Revision
        {
            get
            {
                return this._fx_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._fx_Revision = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox1
        {
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox1 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox2
        {
            get
            {
                return this._GroupBox2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox2 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox3
        {
            get
            {
                return this._GroupBox3;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox3 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox4
        {
            get
            {
                return this._GroupBox4;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox4 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox5
        {
            get
            {
                return this._GroupBox5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox5 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox6
        {
            get
            {
                return this._GroupBox6;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox6 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox7
        {
            get
            {
                return this._GroupBox7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox7 = value;
            }
        }


    
    
        internal virtual GroupBox GroupBox8
        {
            get
            {
                return this._GroupBox8;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._GroupBox8 = value;
            }
        }


    
    
        internal virtual Label invent_Date
        {
            get
            {
                return this._invent_Date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._invent_Date = value;
            }
        }


    
    
        internal virtual Button invent_Import
        {
            get
            {
                return this._invent_Import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.invent_Import_Click);
                if (this._invent_Import != null)
                {
                    this._invent_Import.Click -= eventHandler;
                }
                this._invent_Import = value;
                if (this._invent_Import != null)
                {
                    this._invent_Import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label invent_RecipeDate
        {
            get
            {
                return this._invent_RecipeDate;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._invent_RecipeDate = value;
            }
        }


    
    
        internal virtual Label invent_Revision
        {
            get
            {
                return this._invent_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._invent_Revision = value;
            }
        }


    
    
        internal virtual Button inventSetImport
        {
            get
            {
                return this._inventSetImport;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.inventSetImport_Click);
                if (this._inventSetImport != null)
                {
                    this._inventSetImport.Click -= eventHandler;
                }
                this._inventSetImport = value;
                if (this._inventSetImport != null)
                {
                    this._inventSetImport.Click += eventHandler;
                }
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


    
    
        internal virtual Label Label10
        {
            get
            {
                return this._Label10;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label10 = value;
            }
        }


    
    
        internal virtual Label Label11
        {
            get
            {
                return this._Label11;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label11 = value;
            }
        }


    
    
        internal virtual Label Label12
        {
            get
            {
                return this._Label12;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label12 = value;
            }
        }


    
    
        internal virtual Label Label13
        {
            get
            {
                return this._Label13;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label13 = value;
            }
        }


    
    
        internal virtual Label Label14
        {
            get
            {
                return this._Label14;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label14 = value;
            }
        }


    
    
        internal virtual Label Label15
        {
            get
            {
                return this._Label15;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label15 = value;
            }
        }


    
    
        internal virtual Label Label16
        {
            get
            {
                return this._Label16;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label16 = value;
            }
        }


    
    
        internal virtual Label Label17
        {
            get
            {
                return this._Label17;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label17 = value;
            }
        }


    
    
        internal virtual Label Label19
        {
            get
            {
                return this._Label19;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label19 = value;
            }
        }


    
    
        internal virtual Label Label2
        {
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label2 = value;
            }
        }


    
    
        internal virtual Label Label21
        {
            get
            {
                return this._Label21;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label21 = value;
            }
        }


    
    
        internal virtual Label Label22
        {
            get
            {
                return this._Label22;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label22 = value;
            }
        }


    
    
        internal virtual Label Label23
        {
            get
            {
                return this._Label23;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label23 = value;
            }
        }


    
    
        internal virtual Label Label24
        {
            get
            {
                return this._Label24;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label24 = value;
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


    
    
        internal virtual Label Label5
        {
            get
            {
                return this._Label5;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label5 = value;
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


    
    
        internal virtual Label Label7
        {
            get
            {
                return this._Label7;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label7 = value;
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


    
    
        internal virtual Label Label9
        {
            get
            {
                return this._Label9;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Label9 = value;
            }
        }


    
    
        internal virtual Label lev_Count
        {
            get
            {
                return this._lev_Count;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lev_Count = value;
            }
        }


    
    
        internal virtual Label lev_date
        {
            get
            {
                return this._lev_date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lev_date = value;
            }
        }


    
    
        internal virtual Label lev_Revision
        {
            get
            {
                return this._lev_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._lev_Revision = value;
            }
        }


    
    
        internal virtual Button level_import
        {
            get
            {
                return this._level_import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.level_import_Click);
                if (this._level_import != null)
                {
                    this._level_import.Click -= eventHandler;
                }
                this._level_import = value;
                if (this._level_import != null)
                {
                    this._level_import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label mod_Count
        {
            get
            {
                return this._mod_Count;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mod_Count = value;
            }
        }


    
    
        internal virtual Label mod_Date
        {
            get
            {
                return this._mod_Date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mod_Date = value;
            }
        }


    
    
        internal virtual Button mod_Import
        {
            get
            {
                return this._mod_Import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.mod_Import_Click);
                if (this._mod_Import != null)
                {
                    this._mod_Import.Click -= eventHandler;
                }
                this._mod_Import = value;
                if (this._mod_Import != null)
                {
                    this._mod_Import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label mod_Revision
        {
            get
            {
                return this._mod_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._mod_Revision = value;
            }
        }


    
    
        internal virtual Label pow_Count
        {
            get
            {
                return this._pow_Count;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pow_Count = value;
            }
        }


    
    
        internal virtual Label pow_Date
        {
            get
            {
                return this._pow_Date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pow_Date = value;
            }
        }


    
    
        internal virtual Button pow_Import
        {
            get
            {
                return this._pow_Import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.pow_Import_Click);
                if (this._pow_Import != null)
                {
                    this._pow_Import.Click -= eventHandler;
                }
                this._pow_Import = value;
                if (this._pow_Import != null)
                {
                    this._pow_Import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label pow_Revision
        {
            get
            {
                return this._pow_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._pow_Revision = value;
            }
        }


    
    
        internal virtual Label set_Count
        {
            get
            {
                return this._set_Count;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._set_Count = value;
            }
        }


    
    
        internal virtual Label set_Date
        {
            get
            {
                return this._set_Date;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._set_Date = value;
            }
        }


    
    
        internal virtual Button set_Import
        {
            get
            {
                return this._set_Import;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler eventHandler = new EventHandler(this.set_Import_Click);
                if (this._set_Import != null)
                {
                    this._set_Import.Click -= eventHandler;
                }
                this._set_Import = value;
                if (this._set_Import != null)
                {
                    this._set_Import.Click += eventHandler;
                }
            }
        }


    
    
        internal virtual Label set_Revision
        {
            get
            {
                return this._set_Revision;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._set_Revision = value;
            }
        }


        public frmCSV()
        {
            base.Load += this.frmCSV_Load;
            this.InitializeComponent();
        }


        void at_Import_Click(object sender, EventArgs e)
        {
            new frmImport_Archetype().ShowDialog();
            this.DisplayInfo();
        }


        void btnBonusLookup_Click(object sender, EventArgs e)
        {
            new frmImport_SetBonusAssignment().ShowDialog();
            this.DisplayInfo();
        }


        void btnClearSI_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Really set all StaticIndex values to -1?\r\nIf not using qualified names for Save/Load, files will be unopenable until Statics are re-indexed. Full Re-Indexing may result in changed index assignments.", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Are you sure?") != MsgBoxResult.No)
            {
                int num = DatabaseAPI.Database.Power.Length - 1;
                for (int index = 0; index <= num; index++)
                {
                    DatabaseAPI.Database.Power[index].StaticIndex = -1;
                }
                int num2 = DatabaseAPI.Database.Enhancements.Length - 1;
                for (int index = 0; index <= num2; index++)
                {
                    DatabaseAPI.Database.Enhancements[index].StaticIndex = -1;
                }
                Interaction.MsgBox("Static Index values cleared.", MsgBoxStyle.Information, "De-Indexing Complete");
            }
        }


        void btnDefiance_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Working...");
            int num = DatabaseAPI.Database.Powersets.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (string.Equals(DatabaseAPI.Database.Powersets[index].ATClass, "CLASS_BLASTER", StringComparison.OrdinalIgnoreCase))
                {
                    int num2 = DatabaseAPI.Database.Powersets[index].Powers.Length - 1;
                    for (int index2 = 0; index2 <= num2; index2++)
                    {
                        int num3 = DatabaseAPI.Database.Powersets[index].Powers[index2].Effects.Length - 1;
                        for (int index3 = 0; index3 <= num3; index3++)
                        {
                            IEffect effect = DatabaseAPI.Database.Powersets[index].Powers[index2].Effects[index3];
                            if (effect.EffectType == Enums.eEffectType.DamageBuff && ((double)effect.Mag < 0.4 & effect.Mag > 0f & effect.ToWho == Enums.eToWho.Self & effect.SpecialCase == Enums.eSpecialCase.None))
                            {
                                effect.SpecialCase = Enums.eSpecialCase.Defiance;
                            }
                        }
                    }
                }
            }
            this.BusyMsg("Re-Indexing && Saving...");
            DatabaseAPI.MatchAllIDs(null);
            DatabaseAPI.SaveMainDatabase();
            this.BusyHide();
        }


        void btnEnhEffects_Click(object sender, EventArgs e)
        {
            new frmImport_EnhancementEffects().ShowDialog();
            this.DisplayInfo();
        }


        void btnEntities_Click(object sender, EventArgs e)
        {
            new frmImport_Entities().ShowDialog();
            this.DisplayInfo();
        }


        void btnImportRecipes_Click(object sender, EventArgs e)
        {
            new frmImport_Recipe().ShowDialog();
            this.DisplayInfo();
        }


        void btnIOLevels_Click(object sender, EventArgs e)
        {
            this.BusyMsg("Working...");
            frmCSV.SetEnhancementLevels();
            this.BusyMsg("Saving...");
            DatabaseAPI.SaveEnhancementDb();
            this.BusyHide();
        }


        void btnSalvageUpdate_Click(object sender, EventArgs e)
        {
            new frmImport_SalvageReq().ShowDialog();
            this.DisplayInfo();
        }


        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static void btnStaticExport_Click(object sender, EventArgs e)
        {
            string text = string.Concat(new string[]
            {
                "Static Indexes, Mids' version ",
                Conversions.ToString(1.962f),
                ", database version ",
                Conversions.ToString(DatabaseAPI.Database.Version),
                ":\r\n"
            });
            foreach (Power power in DatabaseAPI.Database.Power)
            {
                if (power.PowerSet.SetType != Enums.ePowerSetType.Boost)
                {
                    string str2 = Conversions.ToString(power.StaticIndex) + "\t" + power.FullName + "\r\n";
                    text += str2;
                }
            }
            text += "Enhancements\r\n";
            foreach (Enhancement enhancement in DatabaseAPI.Database.Enhancements)
            {
                string str2;
                if (enhancement.Power != null)
                {
                    str2 = Conversions.ToString(enhancement.StaticIndex) + "\t" + enhancement.Power.FullName + "\r\n";
                }
                else
                {
                    str2 = string.Concat(new string[]
                    {
                        "THIS ONE IS NULL  ",
                        Conversions.ToString(enhancement.StaticIndex),
                        "\t",
                        enhancement.Name,
                        "\r\n"
                    });
                }
                text += str2;
            }
            Clipboard.SetText(text);
            try
            {
                int FileNumber = FileSystem.FreeFile();
                FileSystem.FileOpen(FileNumber, "StaticIndexes.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                FileSystem.WriteLine(FileNumber, new object[]
                {
                    text
                });
                FileSystem.FileClose(new int[]
                {
                    FileNumber
                });
                Interaction.MsgBox("Copied to clipboard and saved in StaticIndexes.txt", MsgBoxStyle.OkOnly, null);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Copied to clipboard only", MsgBoxStyle.OkOnly, null);
            }
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
                this.bFrm.Show();
            }
            this.bFrm.SetMessage(sMessage);
        }


        void Button2_Click(object sender, EventArgs e)
        {
            DatabaseAPI.AssignStaticIndexValues();
            Interaction.MsgBox("Static Index values assigned.", MsgBoxStyle.Information, "Indexing Complete");
        }


        void DisplayInfo()
        {
            this.mod_Date.Text = Strings.Format(DatabaseAPI.Database.AttribMods.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.mod_Revision.Text = Conversions.ToString(DatabaseAPI.Database.AttribMods.Revision);
            this.mod_Count.Text = Conversions.ToString(DatabaseAPI.Database.AttribMods.Modifier.Length);
            this.at_Date.Text = Strings.Format(DatabaseAPI.Database.ArchetypeVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.at_Revision.Text = Conversions.ToString(DatabaseAPI.Database.ArchetypeVersion.Revision);
            this.at_Count.Text = Conversions.ToString(DatabaseAPI.Database.Classes.Length);
            this.set_Date.Text = Strings.Format(DatabaseAPI.Database.PowersetVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.set_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowersetVersion.Revision);
            this.set_Count.Text = Conversions.ToString(DatabaseAPI.Database.Powersets.Length);
            this.pow_Date.Text = Strings.Format(DatabaseAPI.Database.PowerVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.pow_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerVersion.Revision);
            this.pow_Count.Text = Conversions.ToString(DatabaseAPI.Database.Power.Length);
            this.lev_date.Text = Strings.Format(DatabaseAPI.Database.PowerLevelVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.lev_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerLevelVersion.Revision);
            this.lev_Count.Text = Conversions.ToString(DatabaseAPI.Database.Power.Length);
            this.fx_Date.Text = Strings.Format(DatabaseAPI.Database.PowerEffectVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.fx_Revision.Text = Conversions.ToString(DatabaseAPI.Database.PowerEffectVersion.Revision);
            this.fx_Count.Text = "Many Lots";
            this.invent_Date.Text = Strings.Format(DatabaseAPI.Database.IOAssignmentVersion.RevisionDate, "dd/MMM/yy HH:mm:ss");
            this.invent_Revision.Text = Conversions.ToString(DatabaseAPI.Database.IOAssignmentVersion.Revision);
            this.invent_RecipeDate.Text = Strings.Format(DatabaseAPI.Database.RecipeRevisionDate, "dd/MMM/yy HH:mm:ss");
        }


        void frmCSV_Load(object sender, EventArgs e)
        {
            this.DisplayInfo();
        }


        void fx_Import_Click(object sender, EventArgs e)
        {
            new frmImportEffects().ShowDialog();
            this.DisplayInfo();
        }


        void invent_Import_Click(object sender, EventArgs e)
        {
            new frmImport_SetAssignments().ShowDialog();
            this.DisplayInfo();
        }


        void inventSetImport_Click(object sender, EventArgs e)
        {
            new frmImportEnhSets().ShowDialog();
            this.DisplayInfo();
        }


        void level_import_Click(object sender, EventArgs e)
        {
            new frmImportPowerLevels().ShowDialog();
            this.DisplayInfo();
        }


        void mod_Import_Click(object sender, EventArgs e)
        {
            new frmImport_mod().ShowDialog();
            this.DisplayInfo();
        }


        void pow_Import_Click(object sender, EventArgs e)
        {
            new frmImport_Power().ShowDialog();
            this.DisplayInfo();
        }


        void set_Import_Click(object sender, EventArgs e)
        {
            new frmImport_Powerset().ShowDialog();
            this.DisplayInfo();
        }


        static void SetEnhancementLevels()
        {
            int num = DatabaseAPI.Database.Enhancements.Length - 1;
            for (int index = 0; index <= num; index++)
            {
                if (DatabaseAPI.Database.Enhancements[index].TypeID == Enums.eType.SetO && DatabaseAPI.Database.Enhancements[index].RecipeIDX > -1 && DatabaseAPI.Database.Recipes.Length > DatabaseAPI.Database.Enhancements[index].RecipeIDX)
                {
                    Recipe recipe = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX];
                    if (recipe.Item.Length > 0)
                    {
                        DatabaseAPI.Database.Enhancements[index].LevelMin = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item[0].Level;
                        DatabaseAPI.Database.Enhancements[index].LevelMax = DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item[DatabaseAPI.Database.Recipes[DatabaseAPI.Database.Enhancements[index].RecipeIDX].Item.Length - 1].Level;
                        if (DatabaseAPI.Database.Enhancements[index].nIDSet > -1)
                        {
                            DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].LevelMin = DatabaseAPI.Database.Enhancements[index].LevelMin;
                            DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].LevelMax = DatabaseAPI.Database.Enhancements[index].LevelMax;
                        }
                    }
                }
            }
        }


        [AccessedThroughProperty("at_Count")]
        Label _at_Count;


        [AccessedThroughProperty("at_Date")]
        Label _at_Date;


        [AccessedThroughProperty("at_Import")]
        Button _at_Import;


        [AccessedThroughProperty("at_Revision")]
        Label _at_Revision;


        [AccessedThroughProperty("btnBonusLookup")]
        Button _btnBonusLookup;


        [AccessedThroughProperty("btnClearSI")]
        Button _btnClearSI;


        [AccessedThroughProperty("btnDefiance")]
        Button _btnDefiance;


        [AccessedThroughProperty("btnEnhEffects")]
        Button _btnEnhEffects;


        [AccessedThroughProperty("btnEntities")]
        Button _btnEntities;


        [AccessedThroughProperty("btnImportRecipes")]
        Button _btnImportRecipes;


        [AccessedThroughProperty("btnIOLevels")]
        Button _btnIOLevels;


        [AccessedThroughProperty("btnSalvageUpdate")]
        Button _btnSalvageUpdate;


        [AccessedThroughProperty("btnStaticExport")]
        Button _btnStaticExport;


        [AccessedThroughProperty("btnStaticIndex")]
        Button _btnStaticIndex;


        [AccessedThroughProperty("fx_Count")]
        Label _fx_Count;


        [AccessedThroughProperty("fx_Date")]
        Label _fx_Date;


        [AccessedThroughProperty("fx_Import")]
        Button _fx_Import;


        [AccessedThroughProperty("fx_Revision")]
        Label _fx_Revision;


        [AccessedThroughProperty("GroupBox1")]
        GroupBox _GroupBox1;


        [AccessedThroughProperty("GroupBox2")]
        GroupBox _GroupBox2;


        [AccessedThroughProperty("GroupBox3")]
        GroupBox _GroupBox3;


        [AccessedThroughProperty("GroupBox4")]
        GroupBox _GroupBox4;


        [AccessedThroughProperty("GroupBox5")]
        GroupBox _GroupBox5;


        [AccessedThroughProperty("GroupBox6")]
        GroupBox _GroupBox6;


        [AccessedThroughProperty("GroupBox7")]
        GroupBox _GroupBox7;


        [AccessedThroughProperty("GroupBox8")]
        GroupBox _GroupBox8;


        [AccessedThroughProperty("invent_Date")]
        Label _invent_Date;


        [AccessedThroughProperty("invent_Import")]
        Button _invent_Import;


        [AccessedThroughProperty("invent_RecipeDate")]
        Label _invent_RecipeDate;


        [AccessedThroughProperty("invent_Revision")]
        Label _invent_Revision;


        [AccessedThroughProperty("inventSetImport")]
        Button _inventSetImport;


        [AccessedThroughProperty("Label1")]
        Label _Label1;


        [AccessedThroughProperty("Label10")]
        Label _Label10;


        [AccessedThroughProperty("Label11")]
        Label _Label11;


        [AccessedThroughProperty("Label12")]
        Label _Label12;


        [AccessedThroughProperty("Label13")]
        Label _Label13;


        [AccessedThroughProperty("Label14")]
        Label _Label14;


        [AccessedThroughProperty("Label15")]
        Label _Label15;


        [AccessedThroughProperty("Label16")]
        Label _Label16;


        [AccessedThroughProperty("Label17")]
        Label _Label17;


        [AccessedThroughProperty("Label19")]
        Label _Label19;


        [AccessedThroughProperty("Label2")]
        Label _Label2;


        [AccessedThroughProperty("Label21")]
        Label _Label21;


        [AccessedThroughProperty("Label22")]
        Label _Label22;


        [AccessedThroughProperty("Label23")]
        Label _Label23;


        [AccessedThroughProperty("Label24")]
        Label _Label24;


        [AccessedThroughProperty("Label4")]
        Label _Label4;


        [AccessedThroughProperty("Label5")]
        Label _Label5;


        [AccessedThroughProperty("Label6")]
        Label _Label6;


        [AccessedThroughProperty("Label7")]
        Label _Label7;


        [AccessedThroughProperty("Label8")]
        Label _Label8;


        [AccessedThroughProperty("Label9")]
        Label _Label9;


        [AccessedThroughProperty("lev_Count")]
        Label _lev_Count;


        [AccessedThroughProperty("lev_date")]
        Label _lev_date;


        [AccessedThroughProperty("lev_Revision")]
        Label _lev_Revision;


        [AccessedThroughProperty("level_import")]
        Button _level_import;


        [AccessedThroughProperty("mod_Count")]
        Label _mod_Count;


        [AccessedThroughProperty("mod_Date")]
        Label _mod_Date;


        [AccessedThroughProperty("mod_Import")]
        Button _mod_Import;


        [AccessedThroughProperty("mod_Revision")]
        Label _mod_Revision;


        [AccessedThroughProperty("pow_Count")]
        Label _pow_Count;


        [AccessedThroughProperty("pow_Date")]
        Label _pow_Date;


        [AccessedThroughProperty("pow_Import")]
        Button _pow_Import;


        [AccessedThroughProperty("pow_Revision")]
        Label _pow_Revision;


        [AccessedThroughProperty("set_Count")]
        Label _set_Count;


        [AccessedThroughProperty("set_Date")]
        Label _set_Date;


        [AccessedThroughProperty("set_Import")]
        Button _set_Import;


        [AccessedThroughProperty("set_Revision")]
        Label _set_Revision;


        frmBusy bFrm;
    }
}
