
using Base.Display;
using Base.Master_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Base.Data_Classes
{
    public class Character
    {
        Archetype _archetype;
        bool? _completeCache;

        public string Name { get; set; }

        public int Level
        {
            get
            {
                if (this.LevelCache > -1)
                {
                    return this.LevelCache;
                }
                else
                {
                    int num2;
                    if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
                    {
                        num2 = this.CurrentBuild.GetMaxLevel();
                    }
                    else
                    {
                        int val1 = GetFirstAvailablePowerLevel(this.CurrentBuild, 0);
                        if (val1 < 0)
                            val1 = 49;
                        int val2 = this.GetFirstAvailableSlotLevel(0);
                        if (val2 < 0)
                            val2 = 49;
                        num2 = Math.Min(val1, val2);
                    }
                    if (num2 < 0)
                        num2 = 49;
                    this.LevelCache = num2;
                    return num2;
                }
            }
        }

        public int RequestedLevel { get; set; }

        Build[] Builds { get; set; }


        public Build CurrentBuild
        {
            get
            {
                return this.Builds.Length > 0 ? this.Builds[0] : null;
            }
        }

        public Archetype Archetype
        {
            get => this._archetype;
            set
            {
                this._archetype = value;
                this.Alignment = this._archetype.Hero ? Enums.Alignment.Hero : Enums.Alignment.Villain;
            }
        }

        public Enums.Alignment Alignment { get; set; }

        public int Origin { get; set; }

        public IPowerset[] Powersets { get; set; }

        public bool[] PoolLocked { get; set; }

        protected int LevelCache { get; set; }

        public bool Locked { get; set; }

        public bool Complete
        {
            get
            {
                if (!this._completeCache.HasValue)
                {
                    int num1 = this.CurrentBuild.TotalSlotsAvailable - this.CurrentBuild.SlotsPlaced;
                    int num2 = this.CurrentBuild.LastPower + 1 - this.CurrentBuild.PowersPlaced;
                    this._completeCache = new bool?(num1 < 1 && num2 < 1);
                }
                return this._completeCache.GetValueOrDefault();
            }
            set
            {
                this._completeCache = value ? this._completeCache : new bool?();
            }
        }

        public int ActiveComboLevel { get; private set; }

        public int PerfectionOfBodyLevel => this.IsStalker || this.PerfectionType == "body" ? this.ActiveComboLevel : 0;

        public int PerfectionOfMindLevel => !this.IsStalker && this.PerfectionType == "mind" ? this.ActiveComboLevel : 0;

        public int PerfectionOfSoulLevel => !this.IsStalker && this.PerfectionType == "soul" ? this.ActiveComboLevel : 0;

        string PerfectionType { get; set; }

        public bool AcceleratedActive { get; private set; }

        public bool DelayedActive { get; private set; }

        public bool DisintegrateActive { get; private set; }

        public bool TargetDroneActive { get; private set; }

        public bool Assassination { get; private set; }

        public bool Domination { get; private set; }

        public bool Containment { get; private set; }

        public bool Scourge { get; private set; }

        public bool CriticalHits { get; private set; }

        public bool FastModeActive { get; private set; }

        public bool Defiance { get; private set; }

        public bool DefensiveAdaptation { get; private set; }

        public bool EfficientAdaptation { get; private set; }

        public bool OffensiveAdaptation { get; private set; }

        public Dictionary<string, float> ModifyEffects { get; protected set; }

        public TotalStatistics Totals { get; private set; }

        public TotalStatistics TotalsCapped { get; private set; }

        public Statistics DisplayStats { get; private set; }

        public int SlotsRemaining
        {
            get
            {
                int num1;
                if (this.Level < DatabaseAPI.Database.Levels.Length && DatabaseAPI.Database.Levels[this.Level].Slots > 0)
                {
                    int num2 = DatabaseAPI.Database.Levels[this.Level].Slots - this.CurrentBuild.SlotsPlacedAtLevel(this.Level);
                    if (num2 < 0)
                        num2 = 0;
                    num1 = num2;
                }
                else
                    num1 = 0;
                return num1;
            }
        }

        public bool CanPlaceSlot
        {
            get
            {
                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
                {
                    if (this.CurrentBuild.TotalSlotsAvailable - this.CurrentBuild.SlotsPlaced > 0 & MidsContext.Config.BuildOption != Enums.dmItem.Power)
                        return true;
                }
                else if (this.Level > -1 & this.Level < DatabaseAPI.Database.Levels.Length && DatabaseAPI.Database.Levels[this.Level].LevelType() == Enums.dmItem.Slot && this.SlotsRemaining > 0)
                    return true;
                return false;
            }
        }

        public void ResetLevel()
        {
            this.LevelCache = -1;
        }

        public void Lock()
        {
            int powersPlaced = this.CurrentBuild.PowersPlaced;
            if (powersPlaced == 1 & this.CurrentBuild.PowerUsed(this.Powersets[1].Powers[0]))
            {
                this.Locked = false;
                this.ResetLevel();
            }
            else if (powersPlaced > 0)
            {
                this.Locked = true;
            }
            else
            {
                if (powersPlaced != 0)
                    return;
                this.Locked = false;
                this.ResetLevel();
            }
        }

        public bool IsHero() => this.Alignment == Enums.Alignment.Hero || this.Alignment == Enums.Alignment.Vigilante;

        public bool IsVillain => this.Alignment == Enums.Alignment.Rogue || this.Alignment == Enums.Alignment.Villain;

        public bool IsPraetorian => this.Alignment == Enums.Alignment.Loyalist || this.Alignment == Enums.Alignment.Resistance;
        public bool IsBlaster => this.Archetype.DisplayName.ToLower() == "blaster";

        public bool IsController => this.Archetype.DisplayName.ToLower() == "controller";

        public bool IsDefender => this.Archetype.DisplayName.ToLower() == "defender";

        public bool IsScrapper => this.Archetype.DisplayName.ToLower() == "scrapper";

        public bool IsTanker => this.Archetype.DisplayName.ToLower() == "tank";

        public bool IsKheldian => this.Archetype.ClassType == Enums.eClassType.HeroEpic;

        public bool IsBrute => this.Archetype.DisplayName.ToLower() == "brute";

        public bool IsCorruptor => this.Archetype.DisplayName.ToLower() == "corruptor";

        public bool IsDominator => this.Archetype.DisplayName.ToLower() == "dominator";

        public bool IsMastermind => this.Archetype.DisplayName.ToLower() == "mastermind";

        public bool IsStalker => this.Archetype.DisplayName.ToLower() == "stalker";

        public bool IsArachnos => this.Archetype.ClassType == Enums.eClassType.VillainEpic;

        public bool PoolTaken(int poolID) => this.Powersets[poolID] != null && poolID >= 3 && poolID <= 7 && this.PoolLocked[poolID - 3];

        protected Character()
        {
            this.Name = string.Empty;
            this.Powersets = new IPowerset[8];
            this.PoolLocked = new bool[5];
            this.Totals = new TotalStatistics();
            this.TotalsCapped = new TotalStatistics();
            this.DisplayStats = new Statistics(this);
            this.Builds = new[] { new Build(this, DatabaseAPI.Database.Levels) };
            this.Reset(null, 0);
        }

        public void Reset(Archetype iArchetype = null, int iOrigin = 0)
        {
            this.Name = string.Empty;
            bool flag1 = this.Archetype != null && iArchetype != null && this.Archetype.Idx == iArchetype.Idx;
            this.Archetype = iArchetype ?? DatabaseAPI.Database.Classes[0];
            MidsContext.Archetype = this.Archetype;
            this.Origin = iOrigin > this.Archetype.Origin.Length - 1 ? this.Archetype.Origin.Length - 1 : iOrigin;
            if (flag1)
            {
                bool flag2 = false;
                if (this.Powersets[0] != null && this.Powersets[0].nArchetype == this.Archetype.Idx)
                    flag2 = true;
                if (!flag2)
                    this.Powersets[0] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Primary)[0];
                bool flag3 = false;
                if (this.Powersets[1] != null && this.Powersets[1].nArchetype == this.Archetype.Idx)
                    flag3 = true;
                if (!flag3)
                    this.Powersets[1] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Secondary)[0];
            }
            else
            {
                this.Powersets[0] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Primary)[0];
                this.Powersets[1] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Secondary)[0];
            }
            IPowerset[] powersetIndexes1 = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Pool);
            int index = 0;
            this.Powersets[3] = powersetIndexes1[index];
            if (powersetIndexes1.Length - 1 > index)
                ++index;
            this.Powersets[4] = powersetIndexes1[index];
            if (powersetIndexes1.Length - 1 > index)
                ++index;
            this.Powersets[5] = powersetIndexes1[index];
            if (powersetIndexes1.Length - 1 > index)
                ++index;
            this.Powersets[6] = powersetIndexes1[index];
            IPowerset[] powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Ancillary);
            this.Powersets[7] = powersetIndexes2.Length <= 0 ? null : powersetIndexes2[0];
            this.ModifyEffects = new Dictionary<string, float>();
            this.PoolLocked = new bool[5];
            this.NewBuild();
            this.Locked = false;
            this.LevelCache = -1;
        }

        protected void NewBuild()
        {
            this.Builds[0] = new Build(this, DatabaseAPI.Database.Levels);
            this.AcceleratedActive = false;
            this.ActiveComboLevel = 0;
            this.DelayedActive = false;
            this.DisintegrateActive = false;
            this.TargetDroneActive = false;
            this.FastModeActive = false;
            this.Assassination = false;
            this.CriticalHits = false;
            this.Containment = false;
            this.Domination = false;
            this.Scourge = false;
            this.DefensiveAdaptation = false;
            this.EfficientAdaptation = false;
            this.OffensiveAdaptation = false;
            this.PerfectionType = string.Empty;
            this.Totals.Init();
            this.TotalsCapped.Init();
            this.RequestedLevel = -1;
        }

        void RefreshActiveSpecial()

        {
            this.ActiveComboLevel = 0;
            this.AcceleratedActive = false;
            this.DelayedActive = false;
            this.DisintegrateActive = false;
            this.TargetDroneActive = false;
            this.FastModeActive = false;
            this.Assassination = false;
            this.Domination = false;
            this.Containment = false;
            this.Scourge = false;
            this.CriticalHits = false;
            this.Defiance = false;
            this.DefensiveAdaptation = false;
            this.EfficientAdaptation = false;
            this.OffensiveAdaptation = false;
            this.PerfectionType = string.Empty;
        }

        public void Validate()
        {
            this.CheckAncillaryPowerSet();
            this.CurrentBuild.Validate();
            this.RefreshActiveSpecial();
        }

        protected bool PowersetMutexClash(int nIDPower)
        {
            int powerSetId = DatabaseAPI.Database.Power[nIDPower].PowerSetID;
            Enums.PowersetType powersetType;
            switch (DatabaseAPI.Database.Powersets[powerSetId].SetType)
            {
                case Enums.ePowerSetType.Primary:
                    powersetType = Enums.PowersetType.Secondary;
                    break;
                case Enums.ePowerSetType.Secondary:
                    powersetType = Enums.PowersetType.Primary;
                    break;
                default:
                    return false;
            }
            if (powersetType != Enums.PowersetType.None)
            {
                for (int index = 0; index <= DatabaseAPI.Database.Powersets[powerSetId].nIDMutexSets.Length - 1; ++index)
                {
                    if (DatabaseAPI.Database.Powersets[powerSetId].nIDMutexSets[index] == this.Powersets[(int)powersetType].nID)
                        return true;
                }
                for (int index = 0; index <= this.Powersets[(int)powersetType].nIDMutexSets.Length - 1; ++index)
                {
                    if (this.Powersets[(int)powersetType].nIDMutexSets[index] == powerSetId)
                        return true;
                }
            }
            return false;
        }

        void CheckAncillaryPowerSet()
        {
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Ancillary);
            if (powersetIndexes.Length == 0)
                this.Powersets[7] = null;
            else if (this.Powersets[7] == null)
            {
                this.Powersets[7] = powersetIndexes[0];
            }
            else
            {
                bool flag = false;
                for (int index = 0; index <= powersetIndexes.Length - 1; ++index)
                {
                    if (this.Powersets[7].nID == powersetIndexes[index].nID)
                        flag = true;
                }
                if (!flag && powersetIndexes.Length > 0)
                    this.Powersets[7] = powersetIndexes[0];
            }
        }

        IEnumerable<int> PoolGetAvailable(int iPool)
        {
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Pool);
            List<int> intList = new List<int>();
            for (int index1 = 0; index1 < powersetIndexes.Length; ++index1)
            {
                bool flag = false;
                for (int index2 = 3; index2 <= 6; ++index2)
                {
                    if (index2 == iPool | !(powersetIndexes[index1].nID == this.Powersets[index2].nID & this.PoolLocked[index2 - 3]))
                        flag = true;
                }
                if (flag)
                    intList.Add(powersetIndexes[index1].nID);
            }
            return (IEnumerable<int>)intList;
        }

        public int PoolToComboID(int iPool, int index)
        {
            IEnumerable<int> available = this.PoolGetAvailable(iPool);
            int num1 = -1;
            foreach (int num2 in available)
            {
                ++num1;
                if (num2 == index)
                    return num1;
            }
            return 0;
        }

        public static PopUp.PopupData PopEnhInfo(I9Slot iSlot, int iLevel = -1, PowerEntry powerEntry = null)
        {
            PopUp.PopupData popupData1 = new PopUp.PopupData();
            int index1 = popupData1.Add(null);
            PopUp.PopupData popupData2;
            if (iSlot.Enh < 0)
            {
                popupData1.Sections[index1].Add("Empty Slot", PopUp.Colors.Disabled, 1.25f, FontStyle.Bold, 0);
                if (iLevel > -1)
                    popupData1.Sections[index1].Add("Slot placed at level: " + (object)(iLevel + 1), PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                int index2 = popupData1.Add((PopUp.Section)null);
                popupData1.Sections[index2].Add("Right-Click to place an enhancement.", PopUp.Colors.Disabled, 1f, FontStyle.Bold | FontStyle.Italic, 0);
                popupData1.Sections[index2].Add("Shift-Click to move this slot.", PopUp.Colors.Disabled, 1f, FontStyle.Bold | FontStyle.Italic, 0);
                popupData2 = popupData1;
            }
            else
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[iSlot.Enh];
                switch (enhancement.TypeID)
                {
                    case Enums.eType.Normal:
                        popupData1.Sections[index1].Add(enhancement.Name, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.InventO:
                        popupData1.Sections[index1].Add("Invention: " + enhancement.Name, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SpecialO:
                        popupData1.Sections[index1].Add(enhancement.Name, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SetO:
                        Color iColor = PopUp.Colors.Title;
                        if (enhancement.RecipeIDX > -1)
                        {
                            switch (DatabaseAPI.Database.Recipes[enhancement.RecipeIDX].Rarity)
                            {
                                case Recipe.RecipeRarity.Uncommon:
                                    iColor = PopUp.Colors.Uncommon;
                                    break;
                                case Recipe.RecipeRarity.Rare:
                                    iColor = PopUp.Colors.Rare;
                                    break;
                                case Recipe.RecipeRarity.UltraRare:
                                    iColor = PopUp.Colors.UltraRare;
                                    break;
                            }
                        }
                        popupData1.Sections[index1].Add(DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName + ": " + enhancement.Name, iColor, 1.25f, FontStyle.Bold, 0);
                        break;
                }
                switch (enhancement.TypeID)
                {
                    case Enums.eType.Normal:
                        popupData1.Sections[index1].Add(iSlot.GetEnhancementString(), Color.FromArgb(0, (int)byte.MaxValue, 0), 1f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.InventO:
                        popupData1.Sections[index1].Add("Invention Level: " + (object)(iSlot.IOLevel + 1) + iSlot.GetRelativeString(false) + " - " + iSlot.GetEnhancementString(), PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SpecialO:
                        popupData1.Sections[index1].Add(iSlot.GetEnhancementString(), Color.FromArgb((int)byte.MaxValue, (int)byte.MaxValue, 0), 1f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SetO:
                        popupData1.Sections[index1].Add("Invention Level: " + (object)(iSlot.IOLevel + 1) + iSlot.GetRelativeString(false), PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                        break;
                }
                if (iLevel > -1)
                    popupData1.Sections[index1].Add("Slot placed at level: " + (object)(iLevel + 1), PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                if (enhancement.Unique)
                {
                    index1 = popupData1.Add(null);
                    popupData1.Sections[index1].Add("This enhancement is Unique. No more than one enhancement of this type can be slotted by a character.", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
                }
                switch (enhancement.TypeID)
                {
                    case Enums.eType.Normal:
                    case Enums.eType.InventO:
                        if (!string.IsNullOrEmpty(enhancement.Desc))
                        {
                            popupData1.Sections[index1].Add(enhancement.Desc, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                            break;
                        }
                        int index2 = popupData1.Add(null);
                        string[] strArray1 = BreakByNewLine(iSlot.GetEnhancementStringLong());
                        for (int index3 = 0; index3 <= strArray1.Length - 1; ++index3)
                        {
                            string[] strArray2 = BreakByBracket(strArray1[index3]);
                            popupData1.Sections[index2].Add(strArray2[0], Color.FromArgb(0, (int)byte.MaxValue, 0), strArray2[1], Color.FromArgb(0, (int)byte.MaxValue, 0), 0.9f, FontStyle.Bold, 0);
                        }
                        break;
                    case Enums.eType.SpecialO:
                    case Enums.eType.SetO:
                        if (!string.IsNullOrEmpty(enhancement.Desc))
                            popupData1.Sections[index1].Add(enhancement.Desc, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        int index4 = popupData1.Add(null);
                        string[] strArray3 = BreakByNewLine(iSlot.GetEnhancementStringLong());
                        for (int index3 = 0; index3 <= strArray3.Length - 1; ++index3)
                        {
                            string[] strArray2;
                            if (!enhancement.HasPowerEffect)
                                strArray2 = BreakByBracket(strArray3[index3]);
                            else
                                strArray2 = new[] { strArray3[index3], string.Empty };
                            string[] strArray4 = strArray2;
                            popupData1.Sections[index4].Add(strArray4[0], Color.FromArgb(0, byte.MaxValue, 0), strArray4[1], Color.FromArgb(0, byte.MaxValue, 0), 0.9f, FontStyle.Bold, 0);
                        }
                        break;
                }
                if (!MidsContext.Config.PopupRecipes)
                {
                    if (enhancement.TypeID == Enums.eType.SetO)
                    {
                        int index3 = popupData1.Add(null);
                        popupData1.Sections[index3].Add("Set Type: " + DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].SetType], PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                        popupData1.Sections[index3].Add("Set Level Range: " + (object)(DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].LevelMin + 1) + " to " + (object)(DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].LevelMax + 1), PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                        popupData1.Add(PopSetEnhList(enhancement.nIDSet, powerEntry));
                        popupData1.Add(PopSetBonusListing(enhancement.nIDSet, powerEntry));
                    }
                }
                else if (enhancement.TypeID == Enums.eType.SetO || enhancement.TypeID == Enums.eType.InventO)
                    popupData1.Add(PopRecipeInfo(enhancement.RecipeIDX, iSlot.IOLevel));
                popupData2 = popupData1;
            }
            return popupData2;
        }

        public int GetFirstAvailablePowerIndex(int iLevel = 0)
        {
            for (int index = 0; index <= this.CurrentBuild.LastPower; ++index)
            {
                if (this.CurrentBuild.Powers[index].NIDPowerset < 0 && this.CurrentBuild.Powers[index].Level >= iLevel)
                    return index;
            }
            return -1;
        }

        static int GetFirstAvailablePowerLevel(Build currentbuild, int iLevel = 0)
        {
            for (int index = 0; index <= currentbuild.LastPower; ++index)
            {
                if (currentbuild.Powers[index].NIDPowerset < 0 & currentbuild.Powers[index].Level >= iLevel)
                    return currentbuild.Powers[index].Level;
            }
            return -1;
        }

        int GetFirstAvailableSlotLevel(int iLevel = 0)
        {
            if (iLevel < 0)
                iLevel = 0;
            for (int level = iLevel; level < DatabaseAPI.Database.Levels.Length; ++level)
            {
                if (DatabaseAPI.Database.Levels[level].Slots > 0 && DatabaseAPI.Database.Levels[level].Slots - this.CurrentBuild.SlotsPlacedAtLevel(level) > 0)
                    return level;
            }
            return -1;
        }

        public int SlotCheck(PowerEntry power)
        {
            int num1;
            if (power.Power == null || !this.CanPlaceSlot || power.SlotCount > 5)
                num1 = -1;
            else if (!DatabaseAPI.Database.Power[power.NIDPower].Slottable)
            {
                num1 = -1;
            }
            else
            {
                int iLevel = power.Level;
                if (DatabaseAPI.Database.Power[power.NIDPower].AllowFrontLoading)
                    iLevel = 0;
                int num2 = this.GetFirstAvailableSlotLevel(iLevel);
                if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp && num2 > this.CurrentBuild.GetMaxLevel() + 1)
                    num2 = -1;
                num1 = num2;
            }
            return num1;
        }

        public int[] GetSlotCounts()
        {
            int[] numArray = new int[2];
            for (int level = 0; level < DatabaseAPI.Database.Levels.Length; ++level)
            {
                if (DatabaseAPI.Database.Levels[level].Slots > 0)
                {
                    int num = this.CurrentBuild.SlotsPlacedAtLevel(level);
                    numArray[0] += DatabaseAPI.Database.Levels[level].Slots - num;
                    numArray[1] += num;
                }
            }
            return numArray;
        }

        static string[] BreakByNewLine(string iString)
        {
            iString = iString.Replace('\n', '^');
            return iString.Split('^');
        }

        static string[] BreakByBracket(string iString)
        {
            string[] strArray1 = new[] { iString, string.Empty };
            int length = iString.IndexOf(" (", StringComparison.Ordinal);
            string[] strArray2;
            if (length < 0)
            {
                strArray2 = strArray1;
            }
            else
            {
                strArray1[0] = iString.Substring(0, length) + ":";
                if (iString.Length - (length + 1) > 0)
                    strArray1[1] = iString.Substring(length + 1).Replace("(", "").Replace(")", "");
                strArray2 = strArray1;
            }
            return strArray2;
        }

        static PopUp.Section PopSetBonusListing(int sIdx, PowerEntry power)
        {
            var section1 = new PopUp.Section();
            section1.Add("Set Bonus:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            int num = 0;
            if (power != null)
            {
                for (int index = 0; index <= power.Slots.Length - 1; ++index)
                {
                    if (power.Slots[index].Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[power.Slots[index].Enhancement.Enh].nIDSet == sIdx)
                        ++num;
                }
            }
            if (sIdx < 0 || sIdx > DatabaseAPI.Database.EnhancementSets.Count - 1)
            {
                return section1;
            }
            else
            {
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[sIdx];
                for (int index = 0; index <= enhancementSet.Bonus.Length - 1; ++index)
                {
                    string effectString = enhancementSet.GetEffectString(index, false, true);
                    if (!string.IsNullOrEmpty(effectString))
                    {
                        if (enhancementSet.Bonus[index].PvMode == Enums.ePvX.PvP)
                            effectString += "(PvP)";
                        if (num >= enhancementSet.Bonus[index].Slotted & (enhancementSet.Bonus[index].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE | enhancementSet.Bonus[index].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE | enhancementSet.Bonus[index].PvMode == Enums.ePvX.Any))
                            section1.Add("(" + enhancementSet.Bonus[index].Slotted + ") " + effectString, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        else if (power == null)
                            section1.Add("(" + enhancementSet.Bonus[index].Slotted + ") " + effectString, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        else
                            section1.Add("(" + enhancementSet.Bonus[index].Slotted + ") " + effectString, PopUp.Colors.Disabled, 0.9f, FontStyle.Bold, 0);
                    }
                }
                for (int index = 0; index <= enhancementSet.SpecialBonus.Length - 1; ++index)
                {
                    string effectString = enhancementSet.GetEffectString(index, true, true);
                    if (!string.IsNullOrEmpty(effectString))
                    {
                        bool flag = false;
                        if (power != null)
                        {
                            foreach (SlotEntry slot in power.Slots)
                            {
                                if (slot.Enhancement.Enh > -1 && enhancementSet.SpecialBonus[index].Special > -1 && slot.Enhancement.Enh == enhancementSet.Enhancements[enhancementSet.SpecialBonus[index].Special])
                                    flag = true;
                            }
                        }
                        if (flag)
                            section1.Add("(Enh) " + effectString, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        else if (power == null)
                            section1.Add("(Enh) " + effectString, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        else
                            section1.Add("(Enh) " + effectString, PopUp.Colors.Disabled, 0.9f, FontStyle.Bold, 0);
                    }
                }
                return section1;
            }
        }

        public static PopUp.Section PopRecipeInfo(int rIdx, int iLevel)
        {
            PopUp.Section section1 = new PopUp.Section();
            if (rIdx < 0)
            {
                return section1;
            }
            else
            {
                Recipe recipe = DatabaseAPI.Database.Recipes[rIdx];
                int index1 = -1;
                int num1 = 52;
                int num2 = 0;
                for (int index2 = 0; index2 <= recipe.Item.Length - 1; ++index2)
                {
                    if (recipe.Item[index2].Level > num2)
                        num2 = recipe.Item[index2].Level;
                    if (recipe.Item[index2].Level < num1)
                        num1 = recipe.Item[index2].Level;
                    if (recipe.Item[index2].Level == iLevel)
                    {
                        index1 = index2;
                        break;
                    }
                }
                if (index1 < 0)
                {
                    iLevel = Enhancement.GranularLevelZb(iLevel, 0, 49, 5);
                    for (int index2 = 0; index2 <= recipe.Item.Length - 1; ++index2)
                    {
                        if (recipe.Item[index2].Level == iLevel)
                        {
                            index1 = index2;
                            break;
                        }
                    }
                }
                if (index1 < 0)
                {
                    return section1;
                }
                else
                {
                    Recipe.RecipeEntry recipeEntry = recipe.Item[index1];
                    string str = string.Empty;
                    if (recipe.EnhIdx > -1)
                        str = " - " + DatabaseAPI.Database.Enhancements[recipe.EnhIdx].LongName;
                    section1.Add("Recipe" + str, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    if (recipeEntry.BuyCost > 0)
                        section1.Add("Buy Cost:", PopUp.Colors.Invention, string.Format("{0:###,###,##0}", (object)recipeEntry.BuyCost), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
                    if (recipeEntry.CraftCost > 0)
                        section1.Add("Craft Cost:", PopUp.Colors.Invention, string.Format("{0:###,###,##0}", (object)recipeEntry.CraftCost), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
                    if (recipeEntry.CraftCostM > 0)
                        section1.Add("Craft Cost (Memorized):", PopUp.Colors.Effect, string.Format("{0:###,###,##0}", (object)recipeEntry.CraftCostM), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                    for (int index2 = 0; index2 <= recipeEntry.Salvage.Length - 1 && (index2 == 0 || recipeEntry.SalvageIdx[index2] != recipeEntry.SalvageIdx[0]); ++index2)
                    {
                        if (recipeEntry.SalvageIdx[index2] >= 0)
                        {
                            Color iColor = Color.White;
                            string empty = string.Empty;
                            switch (DatabaseAPI.Database.Salvage[recipeEntry.SalvageIdx[index2]].Rarity)
                            {
                                case Recipe.RecipeRarity.Common:
                                    iColor = PopUp.Colors.Common;
                                    break;
                                case Recipe.RecipeRarity.Uncommon:
                                    iColor = PopUp.Colors.Uncommon;
                                    break;
                                case Recipe.RecipeRarity.Rare:
                                    iColor = PopUp.Colors.Rare;
                                    break;
                                case Recipe.RecipeRarity.UltraRare:
                                    iColor = PopUp.Colors.UltraRare;
                                    break;
                            }
                            if (recipeEntry.Count[index2] > 0)
                                section1.Add(DatabaseAPI.Database.Salvage[recipeEntry.SalvageIdx[index2]].ExternalName + empty, iColor, recipeEntry.Count[index2].ToString((IFormatProvider)CultureInfo.InvariantCulture), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                        }
                    }
                    return section1;
                }
            }
        }

        public static PopUp.PopupData PopSetInfo(int sIdx, PowerEntry powerEntry = null)
        {
            if (sIdx < 0)
            {
                PopUp.PopupData popupData1 = new PopUp.PopupData();
                return popupData1;
            }
            else
            {
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[sIdx];
                Color iColor = PopUp.Colors.Uncommon;
                for (int index = 0; index <= enhancementSet.Enhancements.Length - 1; ++index)
                {
                    IEnhancement enhancement = DatabaseAPI.Database.Enhancements[enhancementSet.Enhancements[index]];
                    if (enhancement.RecipeIDX > -1)
                    {
                        if (DatabaseAPI.Database.Recipes[enhancement.RecipeIDX].Rarity == Recipe.RecipeRarity.Rare)
                        {
                            iColor = PopUp.Colors.Rare;
                            break;
                        }
                        if (DatabaseAPI.Database.Recipes[enhancement.RecipeIDX].Rarity == Recipe.RecipeRarity.UltraRare)
                        {
                            iColor = PopUp.Colors.UltraRare;
                            break;
                        }
                        if (index > 2)
                            break;
                    }
                }
                PopUp.PopupData popupData1 = new PopUp.PopupData();
                int index1 = popupData1.Add(null);
                popupData1.Sections[index1].Add(enhancementSet.DisplayName, iColor, 1.25f, FontStyle.Bold, 0);
                popupData1.Sections[index1].Add("Set Type: " + DatabaseAPI.Database.SetTypeStringLong[(int)enhancementSet.SetType], PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                string str = enhancementSet.LevelMin != enhancementSet.LevelMax ? (enhancementSet.LevelMin + 1).ToString() + " to " + (object)(enhancementSet.LevelMax + 1) : (enhancementSet.LevelMin + 1).ToString((IFormatProvider)CultureInfo.InvariantCulture);
                popupData1.Sections[index1].Add("Level Range: " + str, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                popupData1.Add(PopSetEnhList(sIdx, powerEntry));
                popupData1.Add(PopSetBonusListing(sIdx, powerEntry));
                return popupData1;
            }
        }

        static PopUp.Section PopSetEnhList(int sIdx, PowerEntry power)
        {
            if (sIdx < 0 || sIdx > DatabaseAPI.Database.EnhancementSets.Count - 1)
            {
                return new PopUp.Section();
            }
            else
            {
                int num = 0;
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[sIdx];
                bool[] flagArray = new bool[enhancementSet.Enhancements.Length];
                for (int index = 0; index <= flagArray.Length - 1; ++index)
                    flagArray[index] = false;
                if (power != null)
                {
                    foreach (SlotEntry slot in power.Slots)
                    {
                        if (slot.Enhancement.Enh >= 0 && DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].nIDSet == sIdx)
                        {
                            ++num;
                            for (int index = 0; index <= enhancementSet.Enhancements.Length - 1; ++index)
                            {
                                if (slot.Enhancement.Enh == enhancementSet.Enhancements[index])
                                    flagArray[index] = true;
                            }
                        }
                    }
                }
                var section1 = new PopUp.Section();
                if (power != null)
                    section1.Add("Set: " + enhancementSet.DisplayName + " (" + (object)num + "/" + (object)enhancementSet.Enhancements.Length + ")", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                for (int index = 0; index <= enhancementSet.Enhancements.Length - 1; ++index)
                {
                    string iText = enhancementSet.DisplayName + ": " + DatabaseAPI.Database.Enhancements[enhancementSet.Enhancements[index]].Name;
                    if (flagArray[index] || power == null)
                        section1.Add(iText, PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
                    else
                        section1.Add(iText, PopUp.Colors.Disabled, 0.9f, FontStyle.Bold, 1);
                }
                return section1;
            }
        }

        public void PoolShuffle()
        {
            int[] numArray1 = new int[4];
            int[] numArray2 = new int[4];
            for (int index = 3; index <= 6; ++index)
            {
                numArray2[index - 3] = this.Powersets[index].nID;
                numArray1[index - 3] = this.GetEarliestPowerIndex(this.Powersets[index].nID);
            }
            for (int index1 = 0; index1 <= 3; ++index1)
            {
                int maxValue = (int)byte.MaxValue;
                int index2 = -1;
                for (int index3 = 0; index3 <= numArray1.Length - 1; ++index3)
                {
                    if (maxValue > numArray1[index3])
                    {
                        maxValue = numArray1[index3];
                        index2 = index3;
                    }
                }
                if (index2 > -1)
                {
                    this.Powersets[index1 + 3] = DatabaseAPI.Database.Powersets[numArray2[index2]];
                    numArray1[index2] = 512;
                }
            }
            // HACK: this assumes at least 8 powersets exist, but the database is fully editable.
            this.PoolLocked[0] = this.PowersetUsed(this.Powersets[3]) & this.PoolUnique(Enums.PowersetType.Pool0);
            this.PoolLocked[1] = this.PowersetUsed(this.Powersets[4]) & this.PoolUnique(Enums.PowersetType.Pool1);
            this.PoolLocked[2] = this.PowersetUsed(this.Powersets[5]) & this.PoolUnique(Enums.PowersetType.Pool2);
            this.PoolLocked[3] = this.PowersetUsed(this.Powersets[6]) & this.PoolUnique(Enums.PowersetType.Pool3);
            this.PoolLocked[4] = this.PowersetUsed(this.Powersets[7]);
        }

        int GetEarliestPowerIndex(int iSet)
        {
            for (int index = 0; index <= this.CurrentBuild.LastPower; ++index)
            {
                if (this.CurrentBuild.Powers[index].NIDPowerset == iSet)
                    return index;
            }
            return this.CurrentBuild.LastPower + 1;
        }

        bool PoolUnique(Enums.PowersetType pool)
        {
            bool flag = true;
            for (int index = 3; (Enums.PowersetType)index < pool; ++index)
            {
                if (this.Powersets[index].nID == this.Powersets[(int)pool].nID)
                    flag = false;
            }
            return flag;
        }

        bool PowersetUsed(IPowerset powerset)
        {
            bool flag;
            if (powerset == null)
            {
                flag = false;
            }
            else
            {
                for (int index = 0; index < this.CurrentBuild.Powers.Count; ++index)
                {
                    if (this.CurrentBuild.Powers[index].NIDPowerset == powerset.nID & this.CurrentBuild.Powers[index].IDXPower > -1)
                        return true;
                }
                flag = false;
            }
            return flag;
        }

        protected bool CanRemovePower(int index, bool allowSecondary, out string message)
        {
            message = string.Empty;
            bool flag = true;
            PowerEntry power = this.CurrentBuild.Powers[index];
            if (!power.Chosen)
            {
                flag = false;
                message = "You can't remove inherent powers.\nIf the power is a Kheldian form power, you can remove it by removing the shapeshift power which grants it.";
            }
            else if (power.NIDPowerset == this.Powersets[1].nID & power.IDXPower == 0 & !allowSecondary)
            {
                if (this.CurrentBuild.PowersPlaced > 1)
                {
                    flag = false;
                    message = "The first power from your secondary set is non-optional and can't be removed.";
                }
            }
            else if (power.NIDPowerset < 0)
            {
                flag = false;
                message = string.Empty;
            }
            return flag;
        }

        public void SwitchSets(IPowerset newPowerset, IPowerset oldPowerset)
        {
            int index1;
            int num;
            int index2;
            int index3;
            if (oldPowerset.nIDTrunkSet > -1)
            {
                index1 = oldPowerset.nIDTrunkSet;
                num = oldPowerset.nID;
                if (newPowerset.nIDTrunkSet > -1)
                {
                    index2 = newPowerset.nIDTrunkSet;
                    index3 = newPowerset.nID;
                }
                else
                {
                    index2 = newPowerset.nID;
                    index3 = -1;
                }
            }
            else
            {
                index1 = oldPowerset.nID;
                num = -1;
                if (newPowerset.nIDTrunkSet > -1)
                {
                    index2 = newPowerset.nIDTrunkSet;
                    index3 = newPowerset.nID;
                }
                else
                {
                    index2 = newPowerset.nID;
                    index3 = -1;
                }
            }
            for (int index4 = 0; index4 < this.Powersets.Length; ++index4)
            {
                if (this.Powersets[index4] != null && this.Powersets[index4].nID == oldPowerset.nID)
                    this.Powersets[index4] = newPowerset;
            }
            foreach (PowerEntry power in this.CurrentBuild.Powers)
            {
                if (power.NIDPowerset >= 0)
                {
                    int idxPower = power.IDXPower;
                    if (power.NIDPowerset == index1)
                    {
                        for (int index4 = 0; index4 < DatabaseAPI.Database.Powersets[index1].Power.Length && DatabaseAPI.Database.Powersets[index1].Powers[index4].Level == 0; ++index4)
                            --idxPower;
                        for (int index4 = 0; index4 < DatabaseAPI.Database.Powersets[index2].Power.Length && DatabaseAPI.Database.Powersets[index2].Powers[index4].Level == 0; ++index4)
                            ++idxPower;
                        if (index2 < 0)
                            power.Reset();
                        else if (idxPower > DatabaseAPI.Database.Powersets[index2].Power.Length - 1 || idxPower < 0)
                        {
                            power.Reset();
                        }
                        else
                        {
                            power.NIDPowerset = index2;
                            power.NIDPower = DatabaseAPI.Database.Powersets[index2].Power[idxPower];
                            power.IDXPower = idxPower;
                        }
                    }
                    else if (power.NIDPowerset == num)
                    {
                        for (int index4 = 0; index4 < DatabaseAPI.Database.Powersets[index1].Power.Length && DatabaseAPI.Database.Powersets[index1].Powers[index4].Level == 0; ++index4)
                            --idxPower;
                        for (int index4 = 0; index4 < DatabaseAPI.Database.Powersets[index2].Power.Length && DatabaseAPI.Database.Powersets[index2].Powers[index4].Level == 0; ++index4)
                            ++idxPower;
                        if (index3 < 0 || idxPower > DatabaseAPI.Database.Powersets[index3].Power.Length - 1)
                        {
                            power.Reset();
                        }
                        else
                        {
                            power.NIDPowerset = index3;
                            power.NIDPower = DatabaseAPI.Database.Powersets[index3].Power[idxPower];
                            power.IDXPower = idxPower;
                        }
                    }
                    if (power.Power == null || !power.Power.Slottable)
                        power.Slots = new SlotEntry[0];
                    else if (power.Slots.Length == 0)
                    {
                        power.Slots = new SlotEntry[1];
                        power.Slots[0].Enhancement = new I9Slot();
                        power.Slots[0].FlippedEnhancement = new I9Slot();
                        power.Slots[0].Level = power.Level;
                    }
                    else if (idxPower > -1)
                    {
                        for (int index4 = 0; index4 < power.SlotCount; ++index4)
                        {
                            if (!power.PowerSet.Powers[idxPower].IsEnhancementValid(power.Slots[index4].Enhancement.Enh))
                                power.Slots[index4].Enhancement = new I9Slot();
                        }
                    }
                }
            }
            this.CurrentBuild.FullMutexCheck();
        }

        public class TotalStatistics
        {
            public float[] Def { get; set; }
            public float[] Res { get; set; }
            public float[] Mez { get; set; }
            public float[] MezRes { get; set; }
            public float[] DebuffRes { get; set; }
            public float Elusivity { get; set; }
            public float HPRegen { get; set; }
            public float HPMax { get; set; }
            public float EndRec { get; set; }
            public float EndUse { get; set; }
            public float EndMax { get; set; }
            public float RunSpd { get; set; }
            public float MaxRunSpd { get; set; }
            public float JumpSpd { get; set; }
            public float MaxJumpSpd { get; set; }
            public float FlySpd { get; set; }
            public float MaxFlySpd { get; set; }
            public float JumpHeight { get; set; }
            public float StealthPvE { get; set; }
            public float StealthPvP { get; set; }
            public float ThreatLevel { get; set; }
            public float Perception { get; set; }
            public float BuffHaste { get; set; }
            public float BuffAcc { get; set; }
            public float BuffToHit { get; set; }
            public float BuffDam { get; set; }
            public float BuffEndRdx { get; set; }

            internal TotalStatistics()
            {
                // do not set values to the value they default to in a constructor
                this.Init(fullReset: false);
            }

            public void Init(bool fullReset = true)
            {
                this.Def = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                this.Res = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                this.Mez = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
                this.MezRes = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
                this.DebuffRes = new float[Enum.GetValues(Enums.eEffectType.None.GetType()).Length];
                if (!fullReset) return;
                this.Elusivity = 0.0f;
                this.HPRegen = 0.0f;
                this.HPMax = 0.0f;
                this.EndRec = 0.0f;
                this.EndUse = 0.0f;
                this.EndMax = 0.0f;
                this.RunSpd = 0.0f;
                this.JumpSpd = 0.0f;
                this.FlySpd = 0.0f;
                this.JumpHeight = 0.0f;
                this.StealthPvE = 0.0f;
                this.StealthPvP = 0.0f;
                this.ThreatLevel = 0.0f;
                this.Perception = 0.0f;
                this.BuffHaste = 0.0f;
                this.BuffAcc = 0.0f;
                this.BuffToHit = 0.0f;
                this.BuffDam = 0.0f;
                this.BuffEndRdx = 0.0f;
            }

            public void Assign(Character.TotalStatistics iSt)
            {
                this.Def = (float[])iSt.Def.Clone();
                this.Res = (float[])iSt.Res.Clone();
                this.Mez = (float[])iSt.Mez.Clone();
                this.MezRes = (float[])iSt.MezRes.Clone();
                this.DebuffRes = (float[])iSt.DebuffRes.Clone();
                this.Elusivity = iSt.Elusivity;
                this.HPRegen = iSt.HPRegen;
                this.HPMax = iSt.HPMax;
                this.EndRec = iSt.EndRec;
                this.EndUse = iSt.EndUse;
                this.EndMax = iSt.EndMax;
                this.RunSpd = iSt.RunSpd;
                this.JumpSpd = iSt.JumpSpd;
                this.FlySpd = iSt.FlySpd;
                this.JumpHeight = iSt.JumpHeight;
                this.StealthPvE = iSt.StealthPvE;
                this.StealthPvP = iSt.StealthPvP;
                this.ThreatLevel = iSt.ThreatLevel;
                this.Perception = iSt.Perception;
                this.BuffHaste = iSt.BuffHaste;
                this.BuffAcc = iSt.BuffAcc;
                this.BuffToHit = iSt.BuffToHit;
                this.BuffDam = iSt.BuffDam;
                this.BuffEndRdx = iSt.BuffEndRdx;
            }
        }
    }
}
