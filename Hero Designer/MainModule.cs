
using Base.Data_Classes;
using Base.IO_Classes;
using Base.Master_Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Hero_Designer
{
    [StandardModule]
    public sealed class MainModule
    {
        public class MidsController
        {
            public static float HeroDesignerVersion = 2.23f;
            static bool _appInitialized = false;

            public static Rectangle SzFrmCompare = new Rectangle();
            public static Rectangle SzFrmData = new Rectangle();
            public static Rectangle SzFrmRecipe = new Rectangle();
            public static Rectangle SzFrmSets = new Rectangle();
            public static Rectangle SzFrmStats = new Rectangle();
            public static Rectangle SzFrmTotals = new Rectangle();

            public static bool IsAppInitialized
            {
                get
                {
                    return MainModule.MidsController._appInitialized;
                }
            }

            public static clsToonX Toon
            {
                get
                {
                    return (clsToonX)MidsContext.Character;
                }
                set
                {
                    MidsContext.Character = (Character)value;
                }
            }

            [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
            public static void LoadData(ref frmLoading iFrm)
            {
                DatabaseAPI.LoadDatabaseVersion();
                MainModule.MidsController._appInitialized = true;
                if (iFrm != null)
                    iFrm.SetMessage("Loading Data...");
                if (iFrm != null)
                    iFrm.SetMessage("Loading Attribute Modifiers...");
                DatabaseAPI.Database.AttribMods = new Modifiers();
                if (!DatabaseAPI.Database.AttribMods.Load())
                {

                }
                if (iFrm != null)
                    iFrm.SetMessage("Loading Powerset Database...");
                if (!DatabaseAPI.LoadLevelsDatabase())
                {
                    int num = (int)Interaction.MsgBox((object)"Failed to load Levelling data file! The program is unable to proceed.\r\nSuggest you redownload the application from https://github.com/ImaginaryDevelopment/imaginary-hero-designer/releases", MsgBoxStyle.Critical, (object)"Error");
                    ProjectData.EndApp();
                }
                if (!DatabaseAPI.LoadMainDatabase())
                {
                    if (Interaction.MsgBox((object)"There was an error reading the database. Attempt to download replacement?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object)"Dang") == MsgBoxResult.Yes)
                    {
                        DatabaseAPI.Database.Date = new DateTime(1, 1, 1);
                        clsXMLUpdate clsXmlUpdate = new clsXMLUpdate("http://repo.cohtitan.com/mids_updates/");
                        IMessager iLoadFrm = (IMessager)null;
                        int num = (int)clsXmlUpdate.UpdateCheck(false, ref iLoadFrm);
                    }
                    else
                        ProjectData.EndApp();
                }
                if (!DatabaseAPI.LoadMaths())
                    ProjectData.EndApp();
                if (iFrm != null)
                    iFrm.SetMessage("Loading Enhancement Database...");
                if (!DatabaseAPI.LoadEnhancementClasses())
                    ProjectData.EndApp();
                I9Gfx.LoadClasses();
                DatabaseAPI.LoadEnhancementDb();
                I9Gfx.LoadEnhancements();
                I9Gfx.LoadSets();
                DatabaseAPI.LoadOrigins();
                I9Gfx.LoadBorders();
                DatabaseAPI.LoadSetTypeStrings();
                if (iFrm != null)
                    iFrm.SetMessage("Loading Recipe Database...");
                DatabaseAPI.LoadSalvage();
                DatabaseAPI.LoadRecipes();
                if (iFrm != null)
                    iFrm.SetMessage("Loading Graphics...");
                I9Gfx.LoadSetTypes();
                I9Gfx.LoadEnhTypes();
                I9Gfx.LoadOriginImages();
                I9Gfx.LoadArchetypeImages();
                I9Gfx.LoadPowersetImages();
                MidsContext.Config.Export.LoadCodes(Files.SelectDataFileLoad("BBCode.mhd"));
                iFrm.Opacity = 1.0;
                DatabaseAPI.MatchAllIDs((IMessager)iFrm);
                if (iFrm != null)
                    iFrm.SetMessage("Matching Set Bonus IDs...");
                DatabaseAPI.AssignSetBonusIndexes();
                if (iFrm != null)
                    iFrm.SetMessage("Matching Recipe IDs...");
                DatabaseAPI.AssignRecipeIDs();
                GC.Collect();
            }
        }
    }
}
