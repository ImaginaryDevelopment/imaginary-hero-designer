using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Base.Display;
using Base.Master_Classes;

namespace Base.Data_Classes
{

    public class Character
    {

        // (get) Token: 0x06000040 RID: 64 RVA: 0x00002D68 File Offset: 0x00000F68
        // (set) Token: 0x06000041 RID: 65 RVA: 0x00002D7F File Offset: 0x00000F7F
        public string Name { get; set; }


        // (get) Token: 0x06000042 RID: 66 RVA: 0x00002D88 File Offset: 0x00000F88
        public int Level
        {
            get
            {
                int num;
                if (this.LevelCache > -1)
                {
                    num = this.LevelCache;
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
                        int val = this.GetFirstAvailablePowerLevel(0);
                        if (val < 0)
                        {
                            val = 49;
                        }
                        int val2 = this.GetFirstAvailableSlotLevel(0);
                        if (val2 < 0)
                        {
                            val2 = 49;
                        }
                        num2 = Math.Min(val, val2);
                    }
                    if (num2 < 0)
                    {
                        num2 = 49;
                    }
                    this.LevelCache = num2;
                    num = num2;
                }
                return num;
            }
        }


        // (get) Token: 0x06000043 RID: 67 RVA: 0x00002E40 File Offset: 0x00001040
        // (set) Token: 0x06000044 RID: 68 RVA: 0x00002E57 File Offset: 0x00001057
        public int RequestedLevel { get; set; }


        // (get) Token: 0x06000045 RID: 69 RVA: 0x00002E60 File Offset: 0x00001060
        // (set) Token: 0x06000046 RID: 70 RVA: 0x00002E77 File Offset: 0x00001077
        private Build[] Builds { get; set; }


        // (get) Token: 0x06000047 RID: 71 RVA: 0x00002E80 File Offset: 0x00001080
        public Build CurrentBuild
        {
            get
            {
                Build result;
                if (this.Builds.Length <= 0)
                {
                    result = null;
                }
                else
                {
                    result = this.Builds[0];
                }
                return result;
            }
        }


        // (get) Token: 0x06000048 RID: 72 RVA: 0x00002EB4 File Offset: 0x000010B4
        // (set) Token: 0x06000049 RID: 73 RVA: 0x00002ECC File Offset: 0x000010CC
        public Archetype Archetype
        {
            get
            {
                return this._archetype;
            }
            set
            {
                this._archetype = value;
                this.Alignment = (this._archetype.Hero ? Enums.Alignment.Hero : Enums.Alignment.Villain);
            }
        }


        // (get) Token: 0x0600004A RID: 74 RVA: 0x00002EF0 File Offset: 0x000010F0
        // (set) Token: 0x0600004B RID: 75 RVA: 0x00002F07 File Offset: 0x00001107
        public Enums.Alignment Alignment { get; set; }


        // (get) Token: 0x0600004C RID: 76 RVA: 0x00002F10 File Offset: 0x00001110
        // (set) Token: 0x0600004D RID: 77 RVA: 0x00002F27 File Offset: 0x00001127
        public int Origin { get; set; }


        // (get) Token: 0x0600004E RID: 78 RVA: 0x00002F30 File Offset: 0x00001130
        // (set) Token: 0x0600004F RID: 79 RVA: 0x00002F47 File Offset: 0x00001147
        public IPowerset[] Powersets { get; set; }


        // (get) Token: 0x06000050 RID: 80 RVA: 0x00002F50 File Offset: 0x00001150
        // (set) Token: 0x06000051 RID: 81 RVA: 0x00002F67 File Offset: 0x00001167
        public bool[] PoolLocked { get; set; }


        // (get) Token: 0x06000052 RID: 82 RVA: 0x00002F70 File Offset: 0x00001170
        // (set) Token: 0x06000053 RID: 83 RVA: 0x00002F87 File Offset: 0x00001187
        protected int LevelCache { get; set; }


        // (get) Token: 0x06000054 RID: 84 RVA: 0x00002F90 File Offset: 0x00001190
        // (set) Token: 0x06000055 RID: 85 RVA: 0x00002FA7 File Offset: 0x000011A7
        public bool Locked { get; set; }


        // (get) Token: 0x06000056 RID: 86 RVA: 0x00002FB0 File Offset: 0x000011B0
        // (set) Token: 0x06000057 RID: 87 RVA: 0x00003028 File Offset: 0x00001228
        public bool Complete
        {
            get
            {
                if (this._completeCache == null)
                {
                    int num = this.CurrentBuild.TotalSlotsAvailable - this.CurrentBuild.SlotsPlaced;
                    int num2 = this.CurrentBuild.LastPower + 1 - this.CurrentBuild.PowersPlaced;
                    this._completeCache = new bool?(num < 1 && num2 < 1);
                }
                return this._completeCache.GetValueOrDefault();
            }
            set
            {
                this._completeCache = (value ? this._completeCache : null);
            }
        }


        // (get) Token: 0x06000058 RID: 88 RVA: 0x00003054 File Offset: 0x00001254
        // (set) Token: 0x06000059 RID: 89 RVA: 0x0000306B File Offset: 0x0000126B
        public int ActiveComboLevel { get; private set; }


        // (get) Token: 0x0600005A RID: 90 RVA: 0x00003074 File Offset: 0x00001274
        public int PerfectionOfBodyLevel
        {
            get
            {
                int result;
                if (!this.IsStalker() && !(this.PerfectionType == "body"))
                {
                    result = 0;
                }
                else
                {
                    result = this.ActiveComboLevel;
                }
                return result;
            }
        }


        // (get) Token: 0x0600005B RID: 91 RVA: 0x000030B8 File Offset: 0x000012B8
        public int PerfectionOfMindLevel
        {
            get
            {
                int result;
                if (this.IsStalker() || !(this.PerfectionType == "mind"))
                {
                    result = 0;
                }
                else
                {
                    result = this.ActiveComboLevel;
                }
                return result;
            }
        }


        // (get) Token: 0x0600005C RID: 92 RVA: 0x000030FC File Offset: 0x000012FC
        public int PerfectionOfSoulLevel
        {
            get
            {
                int result;
                if (this.IsStalker() || !(this.PerfectionType == "soul"))
                {
                    result = 0;
                }
                else
                {
                    result = this.ActiveComboLevel;
                }
                return result;
            }
        }


        // (get) Token: 0x0600005D RID: 93 RVA: 0x00003140 File Offset: 0x00001340
        // (set) Token: 0x0600005E RID: 94 RVA: 0x00003157 File Offset: 0x00001357
        private string PerfectionType { get; set; }


        // (get) Token: 0x0600005F RID: 95 RVA: 0x00003160 File Offset: 0x00001360
        // (set) Token: 0x06000060 RID: 96 RVA: 0x00003177 File Offset: 0x00001377
        public bool AcceleratedActive { get; private set; }


        // (get) Token: 0x06000061 RID: 97 RVA: 0x00003180 File Offset: 0x00001380
        // (set) Token: 0x06000062 RID: 98 RVA: 0x00003197 File Offset: 0x00001397
        public bool DelayedActive { get; private set; }


        // (get) Token: 0x06000063 RID: 99 RVA: 0x000031A0 File Offset: 0x000013A0
        // (set) Token: 0x06000064 RID: 100 RVA: 0x000031B7 File Offset: 0x000013B7
        public bool DisintegrateActive { get; private set; }


        // (get) Token: 0x06000065 RID: 101 RVA: 0x000031C0 File Offset: 0x000013C0
        // (set) Token: 0x06000066 RID: 102 RVA: 0x000031D7 File Offset: 0x000013D7
        public bool TargetDroneActive { get; private set; }


        // (get) Token: 0x06000067 RID: 103 RVA: 0x000031E0 File Offset: 0x000013E0
        // (set) Token: 0x06000068 RID: 104 RVA: 0x000031F7 File Offset: 0x000013F7
        public bool Assassination { get; private set; }


        // (get) Token: 0x06000069 RID: 105 RVA: 0x00003200 File Offset: 0x00001400
        // (set) Token: 0x0600006A RID: 106 RVA: 0x00003217 File Offset: 0x00001417
        public bool Domination { get; private set; }


        // (get) Token: 0x0600006B RID: 107 RVA: 0x00003220 File Offset: 0x00001420
        // (set) Token: 0x0600006C RID: 108 RVA: 0x00003237 File Offset: 0x00001437
        public bool Containment { get; private set; }


        // (get) Token: 0x0600006D RID: 109 RVA: 0x00003240 File Offset: 0x00001440
        // (set) Token: 0x0600006E RID: 110 RVA: 0x00003257 File Offset: 0x00001457
        public bool Scourge { get; private set; }


        // (get) Token: 0x0600006F RID: 111 RVA: 0x00003260 File Offset: 0x00001460
        // (set) Token: 0x06000070 RID: 112 RVA: 0x00003277 File Offset: 0x00001477
        public bool CriticalHits { get; private set; }


        // (get) Token: 0x06000071 RID: 113 RVA: 0x00003280 File Offset: 0x00001480
        // (set) Token: 0x06000072 RID: 114 RVA: 0x00003297 File Offset: 0x00001497
        public bool FastModeActive { get; private set; }


        // (get) Token: 0x06000073 RID: 115 RVA: 0x000032A0 File Offset: 0x000014A0
        // (set) Token: 0x06000074 RID: 116 RVA: 0x000032B7 File Offset: 0x000014B7
        public bool Defiance { get; private set; }


        // (get) Token: 0x06000075 RID: 117 RVA: 0x000032C0 File Offset: 0x000014C0
        // (set) Token: 0x06000076 RID: 118 RVA: 0x000032D7 File Offset: 0x000014D7
        public bool DefensiveAdaptation { get; private set; }


        // (get) Token: 0x06000077 RID: 119 RVA: 0x000032E0 File Offset: 0x000014E0
        // (set) Token: 0x06000078 RID: 120 RVA: 0x000032F7 File Offset: 0x000014F7
        public bool EfficientAdaptation { get; private set; }


        // (get) Token: 0x06000079 RID: 121 RVA: 0x00003300 File Offset: 0x00001500
        // (set) Token: 0x0600007A RID: 122 RVA: 0x00003317 File Offset: 0x00001517
        public bool OffensiveAdaptation { get; private set; }


        // (get) Token: 0x0600007B RID: 123 RVA: 0x00003320 File Offset: 0x00001520
        // (set) Token: 0x0600007C RID: 124 RVA: 0x00003337 File Offset: 0x00001537
        public Dictionary<string, float> ModifyEffects { get; protected set; }


        // (get) Token: 0x0600007D RID: 125 RVA: 0x00003340 File Offset: 0x00001540
        // (set) Token: 0x0600007E RID: 126 RVA: 0x00003357 File Offset: 0x00001557
        public Character.TotalStatistics Totals { get; private set; }


        // (get) Token: 0x0600007F RID: 127 RVA: 0x00003360 File Offset: 0x00001560
        // (set) Token: 0x06000080 RID: 128 RVA: 0x00003377 File Offset: 0x00001577
        public Character.TotalStatistics TotalsCapped { get; private set; }


        // (get) Token: 0x06000081 RID: 129 RVA: 0x00003380 File Offset: 0x00001580
        // (set) Token: 0x06000082 RID: 130 RVA: 0x00003397 File Offset: 0x00001597
        public Statistics DisplayStats { get; private set; }


        // (get) Token: 0x06000083 RID: 131 RVA: 0x000033A0 File Offset: 0x000015A0
        public int SlotsRemaining
        {
            get
            {
                int num3;
                if (this.Level < DatabaseAPI.Database.Levels.Length && DatabaseAPI.Database.Levels[this.Level].Slots > 0)
                {
                    int num2 = DatabaseAPI.Database.Levels[this.Level].Slots - this.CurrentBuild.SlotsPlacedAtLevel(this.Level);
                    if (num2 < 0)
                    {
                        num2 = 0;
                    }
                    num3 = num2;
                }
                else
                {
                    num3 = 0;
                }
                return num3;
            }
        }


        // (get) Token: 0x06000084 RID: 132 RVA: 0x00003430 File Offset: 0x00001630
        public bool CanPlaceSlot
        {
            get
            {
                if (MidsContext.Config.BuildMode == Enums.dmModes.Dynamic)
                {
                    if (this.CurrentBuild.TotalSlotsAvailable - this.CurrentBuild.SlotsPlaced > 0 & MidsContext.Config.BuildOption != Enums.dmItem.Power)
                    {
                        return true;
                    }
                }
                else if ((this.Level > -1 & this.Level < DatabaseAPI.Database.Levels.Length) && DatabaseAPI.Database.Levels[this.Level].LevelType() == Enums.dmItem.Slot && this.SlotsRemaining > 0)
                {
                    return true;
                }
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
            else if (powersPlaced == 0)
            {
                this.Locked = false;
                this.ResetLevel();
            }
        }


        public bool IsHero()
        {
            return this.Alignment == Enums.Alignment.Hero || this.Alignment == Enums.Alignment.Vigilante;
        }


        public bool IsVillain()
        {
            return this.Alignment == Enums.Alignment.Rogue || this.Alignment == Enums.Alignment.Villain;
        }


        public bool IsPraetorian()
        {
            return this.Alignment == Enums.Alignment.Loyalist || this.Alignment == Enums.Alignment.Resistance;
        }


        public bool IsBlaster()
        {
            return this.Archetype.DisplayName.ToLower() == "blaster";
        }


        public bool IsController()
        {
            return this.Archetype.DisplayName.ToLower() == "controller";
        }


        public bool IsDefender()
        {
            return this.Archetype.DisplayName.ToLower() == "defender";
        }


        public bool IsScrapper()
        {
            return this.Archetype.DisplayName.ToLower() == "scrapper";
        }


        public bool IsTanker()
        {
            return this.Archetype.DisplayName.ToLower() == "tank";
        }


        public bool IsKheldian()
        {
            return this.Archetype.ClassType == Enums.eClassType.HeroEpic;
        }


        public bool IsBrute()
        {
            return this.Archetype.DisplayName.ToLower() == "brute";
        }


        public bool IsCorruptor()
        {
            return this.Archetype.DisplayName.ToLower() == "corruptor";
        }


        public bool IsDominator()
        {
            return this.Archetype.DisplayName.ToLower() == "dominator";
        }


        public bool IsMastermind()
        {
            return this.Archetype.DisplayName.ToLower() == "mastermind";
        }


        public bool IsStalker()
        {
            return this.Archetype.DisplayName.ToLower() == "stalker";
        }


        public bool IsArachnos()
        {
            return this.Archetype.ClassType == Enums.eClassType.VillainEpic;
        }


        public bool PoolTaken(int poolID)
        {
            return this.Powersets[poolID] != null && poolID >= 3 && poolID <= 7 && this.PoolLocked[poolID - 3];
        }


        protected Character()
        {
            this.Name = string.Empty;
            this.Powersets = new IPowerset[8];
            this.PoolLocked = new bool[5];
            this.Totals = new Character.TotalStatistics();
            this.TotalsCapped = new Character.TotalStatistics();
            this.DisplayStats = new Statistics(this);
            this.Builds = new Build[]
            {
                new Build(this, DatabaseAPI.Database.Levels)
            };
            this.Reset(null, 0);
        }


        public void Reset(Archetype iArchetype = null, int iOrigin = 0)
        {
            this.Name = string.Empty;
            bool flag = this.Archetype != null && iArchetype != null && this.Archetype.Idx == iArchetype.Idx;
            this.Archetype = (iArchetype ?? DatabaseAPI.Database.Classes[0]);
            MidsContext.Archetype = this.Archetype;
            this.Origin = ((iOrigin > this.Archetype.Origin.Length - 1) ? (this.Archetype.Origin.Length - 1) : iOrigin);
            if (flag)
            {
                bool flag2 = false;
                if (this.Powersets[0] != null && this.Powersets[0].nArchetype == this.Archetype.Idx)
                {
                    flag2 = true;
                }
                if (!flag2)
                {
                    this.Powersets[0] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Primary)[0];
                }
                flag2 = false;
                if (this.Powersets[1] != null && this.Powersets[1].nArchetype == this.Archetype.Idx)
                {
                    flag2 = true;
                }
                if (!flag2)
                {
                    this.Powersets[1] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Secondary)[0];
                }
            }
            else
            {
                this.Powersets[0] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Primary)[0];
                this.Powersets[1] = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Secondary)[0];
            }
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Pool);
            int index = 0;
            this.Powersets[3] = powersetIndexes[index];
            if (powersetIndexes.Length - 1 > index)
            {
                index++;
            }
            this.Powersets[4] = powersetIndexes[index];
            if (powersetIndexes.Length - 1 > index)
            {
                index++;
            }
            this.Powersets[5] = powersetIndexes[index];
            if (powersetIndexes.Length - 1 > index)
            {
                index++;
            }
            this.Powersets[6] = powersetIndexes[index];
            IPowerset[] powersetIndexes2 = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Ancillary);
            if (powersetIndexes2.Length > 0)
            {
                this.Powersets[7] = powersetIndexes2[0];
            }
            else
            {
                this.Powersets[7] = null;
            }
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


        private void RefreshActiveSpecial()
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
                for (int index = 0; index <= DatabaseAPI.Database.Powersets[powerSetId].nIDMutexSets.Length - 1; index++)
                {
                    if (DatabaseAPI.Database.Powersets[powerSetId].nIDMutexSets[index] == this.Powersets[(int)powersetType].nID)
                    {
                        return true;
                    }
                }
                for (int index2 = 0; index2 <= this.Powersets[(int)powersetType].nIDMutexSets.Length - 1; index2++)
                {
                    if (this.Powersets[(int)powersetType].nIDMutexSets[index2] == powerSetId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private void CheckAncillaryPowerSet()
        {
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Ancillary);
            if (powersetIndexes.Length == 0)
            {
                this.Powersets[7] = null;
            }
            else if (this.Powersets[7] == null)
            {
                this.Powersets[7] = powersetIndexes[0];
            }
            else
            {
                bool flag = false;
                for (int index = 0; index <= powersetIndexes.Length - 1; index++)
                {
                    if (this.Powersets[7].nID == powersetIndexes[index].nID)
                    {
                        flag = true;
                    }
                }
                if (!flag && powersetIndexes.Length > 0)
                {
                    this.Powersets[7] = powersetIndexes[0];
                }
            }
        }


        private IEnumerable<int> PoolGetAvailable(int iPool)
        {
            IPowerset[] powersetIndexes = DatabaseAPI.GetPowersetIndexes(this.Archetype, Enums.ePowerSetType.Pool);
            List<int> intList = new List<int>();
            for (int index = 0; index < powersetIndexes.Length; index++)
            {
                bool flag = false;
                for (int index2 = 3; index2 <= 6; index2++)
                {
                    if (index2 == iPool | !(powersetIndexes[index].nID == this.Powersets[index2].nID & this.PoolLocked[index2 - 3]))
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    intList.Add(powersetIndexes[index].nID);
                }
            }
            return intList;
        }


        public int PoolToComboID(int iPool, int index)
        {
            IEnumerable<int> available = this.PoolGetAvailable(iPool);
            int num = -1;
            foreach (int num2 in available)
            {
                num++;
                if (num2 == index)
                {
                    return num;
                }
            }
            return 0;
        }


        public static PopUp.PopupData PopEnhInfo(I9Slot iSlot, int iLevel = -1, PowerEntry powerEntry = null)
        {
            PopUp.PopupData popupData = default(PopUp.PopupData);
            int index3 = popupData.Add(null);
            PopUp.PopupData popupData2;
            if (iSlot.Enh < 0)
            {
                popupData.Sections[index3].Add("Empty Slot", PopUp.Colors.Disabled, 1.25f, FontStyle.Bold, 0);
                if (iLevel > -1)
                {
                    popupData.Sections[index3].Add("Slot placed at level: " + (iLevel + 1), PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                }
                index3 = popupData.Add(null);
                popupData.Sections[index3].Add("Right-Click to place an enhancement.", PopUp.Colors.Disabled, 1f, FontStyle.Bold | FontStyle.Italic, 0);
                popupData.Sections[index3].Add("Shift-Click to move this slot.", PopUp.Colors.Disabled, 1f, FontStyle.Bold | FontStyle.Italic, 0);
                popupData2 = popupData;
            }
            else
            {
                IEnhancement enhancement = DatabaseAPI.Database.Enhancements[iSlot.Enh];
                switch (enhancement.TypeID)
                {
                    case Enums.eType.Normal:
                        popupData.Sections[index3].Add(enhancement.Name, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.InventO:
                        popupData.Sections[index3].Add("Invention: " + enhancement.Name, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SpecialO:
                        popupData.Sections[index3].Add(enhancement.Name, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SetO:
                        {
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
                            popupData.Sections[index3].Add(DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].DisplayName + ": " + enhancement.Name, iColor, 1.25f, FontStyle.Bold, 0);
                            break;
                        }
                }
                switch (enhancement.TypeID)
                {
                    case Enums.eType.Normal:
                        popupData.Sections[index3].Add(iSlot.GetEnhancementString(), Color.FromArgb(0, 255, 0), 1f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.InventO:
                        popupData.Sections[index3].Add(string.Concat(new object[]
                        {
                        "Invention Level: ",
                        iSlot.IOLevel + 1,
                        iSlot.GetRelativeString(false),
                        " - ",
                        iSlot.GetEnhancementString()
                        }), PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SpecialO:
                        popupData.Sections[index3].Add(iSlot.GetEnhancementString(), Color.FromArgb(255, 255, 0), 1f, FontStyle.Bold, 0);
                        break;
                    case Enums.eType.SetO:
                        popupData.Sections[index3].Add("Invention Level: " + (iSlot.IOLevel + 1) + iSlot.GetRelativeString(false), PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                        break;
                }
                if (iLevel > -1)
                {
                    popupData.Sections[index3].Add("Slot placed at level: " + (iLevel + 1), PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                }
                if (enhancement.Unique)
                {
                    index3 = popupData.Add(null);
                    popupData.Sections[index3].Add("This enhancement is Unique. No more than one enhancement of this type can be slotted by a character.", PopUp.Colors.Text, 0.9f, FontStyle.Bold, 0);
                }
                switch (enhancement.TypeID)
                {
                    case Enums.eType.Normal:
                    case Enums.eType.InventO:
                        if (!string.IsNullOrEmpty(enhancement.Desc))
                        {
                            popupData.Sections[index3].Add(enhancement.Desc, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                        }
                        else
                        {
                            index3 = popupData.Add(null);
                            string[] strArray3 = Character.BreakByNewLine(iSlot.GetEnhancementStringLong());
                            for (int index4 = 0; index4 <= strArray3.Length - 1; index4++)
                            {
                                string[] strArray4 = Character.BreakByBracket(strArray3[index4]);
                                popupData.Sections[index3].Add(strArray4[0], Color.FromArgb(0, 255, 0), strArray4[1], Color.FromArgb(0, 255, 0), 0.9f, FontStyle.Bold, 0);
                            }
                        }
                        break;
                    case Enums.eType.SpecialO:
                    case Enums.eType.SetO:
                        {
                            if (!string.IsNullOrEmpty(enhancement.Desc))
                            {
                                popupData.Sections[index3].Add(enhancement.Desc, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                            }
                            index3 = popupData.Add(null);
                            string[] strArray3 = Character.BreakByNewLine(iSlot.GetEnhancementStringLong());
                            for (int index5 = 0; index5 <= strArray3.Length - 1; index5++)
                            {
                                string[] strArray4 = enhancement.HasPowerEffect ? new string[]
                                {
                            strArray3[index5],
                            string.Empty
                                } : Character.BreakByBracket(strArray3[index5]);
                                popupData.Sections[index3].Add(strArray4[0], Color.FromArgb(0, 255, 0), strArray4[1], Color.FromArgb(0, 255, 0), 0.9f, FontStyle.Bold, 0);
                            }
                            break;
                        }
                }
                if (!MidsContext.Config.PopupRecipes)
                {
                    if (enhancement.TypeID == Enums.eType.SetO)
                    {
                        index3 = popupData.Add(null);
                        popupData.Sections[index3].Add("Set Type: " + DatabaseAPI.Database.SetTypeStringLong[(int)DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].SetType], PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                        popupData.Sections[index3].Add(string.Concat(new object[]
                        {
                            "Set Level Range: ",
                            DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].LevelMin + 1,
                            " to ",
                            DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].LevelMax + 1
                        }), PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                        popupData.Add(Character.PopSetEnhList(enhancement.nIDSet, powerEntry));
                        popupData.Add(Character.PopSetBonusListing(enhancement.nIDSet, powerEntry));
                    }
                }
                else if (enhancement.TypeID == Enums.eType.SetO || enhancement.TypeID == Enums.eType.InventO)
                {
                    popupData.Add(Character.PopRecipeInfo(enhancement.RecipeIDX, iSlot.IOLevel));
                }
                popupData2 = popupData;
            }
            return popupData2;
        }


        public int GetFirstAvailablePowerIndex(int iLevel = 0)
        {
            for (int index = 0; index <= this.CurrentBuild.LastPower; index++)
            {
                if (this.CurrentBuild.Powers[index].NIDPowerset < 0 && this.CurrentBuild.Powers[index].Level >= iLevel)
                {
                    return index;
                }
            }
            return -1;
        }


        private int GetFirstAvailablePowerLevel(int iLevel = 0)
        {
            for (int index = 0; index <= this.CurrentBuild.LastPower; index++)
            {
                if (this.CurrentBuild.Powers[index].NIDPowerset < 0 & this.CurrentBuild.Powers[index].Level >= iLevel)
                {
                    return this.CurrentBuild.Powers[index].Level;
                }
            }
            return -1;
        }


        protected int GetFirstAvailableSlotLevel(int iLevel = 0)
        {
            if (iLevel < 0)
            {
                iLevel = 0;
            }
            for (int level = iLevel; level < DatabaseAPI.Database.Levels.Length; level++)
            {
                if (DatabaseAPI.Database.Levels[level].Slots > 0 && DatabaseAPI.Database.Levels[level].Slots - this.CurrentBuild.SlotsPlacedAtLevel(level) > 0)
                {
                    return level;
                }
            }
            return -1;
        }


        public int SlotCheck(PowerEntry power)
        {
            int num;
            if (power.Power == null || !this.CanPlaceSlot || power.SlotCount > 5)
            {
                num = -1;
            }
            else if (!DatabaseAPI.Database.Power[power.NIDPower].Slottable)
            {
                num = -1;
            }
            else
            {
                int iLevel = power.Level;
                if (DatabaseAPI.Database.Power[power.NIDPower].AllowFrontLoading)
                {
                    iLevel = 0;
                }
                int num2 = this.GetFirstAvailableSlotLevel(iLevel);
                if (MidsContext.Config.BuildMode == Enums.dmModes.LevelUp && num2 > this.CurrentBuild.GetMaxLevel() + 1)
                {
                    num2 = -1;
                }
                num = num2;
            }
            return num;
        }


        public int[] GetSlotCounts()
        {
            int[] array = new int[2];
            int[] numArray = array;
            for (int level = 0; level < DatabaseAPI.Database.Levels.Length; level++)
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


        private static string[] BreakByNewLine(string iString)
        {
            iString = iString.Replace('\n', '^');
            return iString.Split(new char[]
            {
                '^'
            });
        }


        private static string[] BreakByBracket(string iString)
        {
            string[] strArray = new string[]
            {
                iString,
                string.Empty
            };
            int length = iString.IndexOf(" (", StringComparison.Ordinal);
            string[] strArray2;
            if (length < 0)
            {
                strArray2 = strArray;
            }
            else
            {
                strArray[0] = iString.Substring(0, length) + ":";
                if (iString.Length - (length + 1) > 0)
                {
                    strArray[1] = iString.Substring(length + 1).Replace("(", "").Replace(")", "");
                }
                strArray2 = strArray;
            }
            return strArray2;
        }


        private static PopUp.Section PopSetBonusListing(int sIdx, PowerEntry power)
        {
            PopUp.Section section = new PopUp.Section();
            section.Add("Set Bonus:", PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
            int num = 0;
            if (power != null)
            {
                for (int index = 0; index <= power.Slots.Length - 1; index++)
                {
                    if (power.Slots[index].Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[power.Slots[index].Enhancement.Enh].nIDSet == sIdx)
                    {
                        num++;
                    }
                }
            }
            PopUp.Section section2;
            if (sIdx < 0 || sIdx > DatabaseAPI.Database.EnhancementSets.Count - 1)
            {
                section2 = section;
            }
            else
            {
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[sIdx];
                for (int index2 = 0; index2 <= enhancementSet.Bonus.Length - 1; index2++)
                {
                    string effectString = enhancementSet.GetEffectString(index2, false, true);
                    if (!string.IsNullOrEmpty(effectString))
                    {
                        if (enhancementSet.Bonus[index2].PvMode == Enums.ePvX.PvP)
                        {
                            effectString += "(PvP)";
                        }
                        if (num >= enhancementSet.Bonus[index2].Slotted & ((enhancementSet.Bonus[index2].PvMode == Enums.ePvX.PvE & MidsContext.Config.Inc.PvE) | (enhancementSet.Bonus[index2].PvMode == Enums.ePvX.PvP & !MidsContext.Config.Inc.PvE) | enhancementSet.Bonus[index2].PvMode == Enums.ePvX.Any))
                        {
                            section.Add(string.Concat(new object[]
                            {
                                "(",
                                enhancementSet.Bonus[index2].Slotted,
                                ") ",
                                effectString
                            }), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        }
                        else if (power == null)
                        {
                            section.Add(string.Concat(new object[]
                            {
                                "(",
                                enhancementSet.Bonus[index2].Slotted,
                                ") ",
                                effectString
                            }), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        }
                        else
                        {
                            section.Add(string.Concat(new object[]
                            {
                                "(",
                                enhancementSet.Bonus[index2].Slotted,
                                ") ",
                                effectString
                            }), PopUp.Colors.Disabled, 0.9f, FontStyle.Bold, 0);
                        }
                    }
                }
                for (int index3 = 0; index3 <= enhancementSet.SpecialBonus.Length - 1; index3++)
                {
                    string effectString2 = enhancementSet.GetEffectString(index3, true, true);
                    if (!string.IsNullOrEmpty(effectString2))
                    {
                        bool flag = false;
                        if (power != null)
                        {
                            foreach (SlotEntry slot in power.Slots)
                            {
                                if (slot.Enhancement.Enh > -1 && enhancementSet.SpecialBonus[index3].Special > -1 && slot.Enhancement.Enh == enhancementSet.Enhancements[enhancementSet.SpecialBonus[index3].Special])
                                {
                                    flag = true;
                                }
                            }
                        }
                        if (flag)
                        {
                            section.Add("(Enh) " + effectString2, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        }
                        else if (power == null)
                        {
                            section.Add("(Enh) " + effectString2, PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
                        }
                        else
                        {
                            section.Add("(Enh) " + effectString2, PopUp.Colors.Disabled, 0.9f, FontStyle.Bold, 0);
                        }
                    }
                }
                section2 = section;
            }
            return section2;
        }


        public static PopUp.Section PopRecipeInfo(int rIdx, int iLevel)
        {
            PopUp.Section section = new PopUp.Section();
            PopUp.Section section2;
            if (rIdx < 0)
            {
                section2 = section;
            }
            else
            {
                Recipe recipe = DatabaseAPI.Database.Recipes[rIdx];
                int index = -1;
                int num = 52;
                int num2 = 0;
                for (int index2 = 0; index2 <= recipe.Item.Length - 1; index2++)
                {
                    if (recipe.Item[index2].Level > num2)
                    {
                        num2 = recipe.Item[index2].Level;
                    }
                    if (recipe.Item[index2].Level < num)
                    {
                        num = recipe.Item[index2].Level;
                    }
                    if (recipe.Item[index2].Level == iLevel)
                    {
                        index = index2;
                        break;
                    }
                }
                if (index < 0)
                {
                    iLevel = Enhancement.GranularLevelZb(iLevel, 0, 49, 5);
                    for (int index3 = 0; index3 <= recipe.Item.Length - 1; index3++)
                    {
                        if (recipe.Item[index3].Level == iLevel)
                        {
                            index = index3;
                            break;
                        }
                    }
                }
                if (index < 0)
                {
                    section2 = section;
                }
                else
                {
                    Recipe.RecipeEntry recipeEntry = recipe.Item[index];
                    string str = string.Empty;
                    if (recipe.EnhIdx > -1)
                    {
                        str = " - " + DatabaseAPI.Database.Enhancements[recipe.EnhIdx].LongName;
                    }
                    section.Add("Recipe" + str, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                    if (recipeEntry.BuyCost > 0)
                    {
                        section.Add("Buy Cost:", PopUp.Colors.Invention, string.Format("{0:###,###,##0}", recipeEntry.BuyCost), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
                    }
                    if (recipeEntry.CraftCost > 0)
                    {
                        section.Add("Craft Cost:", PopUp.Colors.Invention, string.Format("{0:###,###,##0}", recipeEntry.CraftCost), PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
                    }
                    if (recipeEntry.CraftCostM > 0)
                    {
                        section.Add("Craft Cost (Memorized):", PopUp.Colors.Effect, string.Format("{0:###,###,##0}", recipeEntry.CraftCostM), PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 1);
                    }
                    int index4 = 0;
                    while (index4 <= recipeEntry.Salvage.Length - 1 && (index4 == 0 || recipeEntry.SalvageIdx[index4] != recipeEntry.SalvageIdx[0]))
                    {
                        if (recipeEntry.SalvageIdx[index4] >= 0)
                        {
                            Color iColor = Color.White;
                            string empty = string.Empty;
                            switch (DatabaseAPI.Database.Salvage[recipeEntry.SalvageIdx[index4]].Rarity)
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
                            if (recipeEntry.Count[index4] > 0)
                            {
                                section.Add(DatabaseAPI.Database.Salvage[recipeEntry.SalvageIdx[index4]].ExternalName + empty, iColor, recipeEntry.Count[index4].ToString(CultureInfo.InvariantCulture), PopUp.Colors.Title, 0.9f, FontStyle.Bold, 1);
                            }
                        }
                        index4++;
                    }
                    section2 = section;
                }
            }
            return section2;
        }


        public static PopUp.PopupData PopSetInfo(int sIdx, PowerEntry powerEntry = null)
        {
            PopUp.PopupData popupData = default(PopUp.PopupData);
            PopUp.PopupData popupData2;
            if (sIdx < 0)
            {
                popupData2 = popupData;
            }
            else
            {
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[sIdx];
                Color iColor = PopUp.Colors.Uncommon;
                for (int index = 0; index <= enhancementSet.Enhancements.Length - 1; index++)
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
                        {
                            break;
                        }
                    }
                }
                int index2 = popupData.Add(null);
                popupData.Sections[index2].Add(enhancementSet.DisplayName, iColor, 1.25f, FontStyle.Bold, 0);
                popupData.Sections[index2].Add("Set Type: " + DatabaseAPI.Database.SetTypeStringLong[(int)enhancementSet.SetType], PopUp.Colors.Invention, 1f, FontStyle.Bold, 0);
                string str;
                if (enhancementSet.LevelMin == enhancementSet.LevelMax)
                {
                    str = (enhancementSet.LevelMin + 1).ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    str = enhancementSet.LevelMin + 1 + " to " + (enhancementSet.LevelMax + 1);
                }
                popupData.Sections[index2].Add("Level Range: " + str, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                popupData.Add(Character.PopSetEnhList(sIdx, powerEntry));
                popupData.Add(Character.PopSetBonusListing(sIdx, powerEntry));
                popupData2 = popupData;
            }
            return popupData2;
        }


        private static PopUp.Section PopSetEnhList(int sIdx, PowerEntry power)
        {
            PopUp.Section section = new PopUp.Section();
            PopUp.Section section2;
            if (sIdx < 0 || sIdx > DatabaseAPI.Database.EnhancementSets.Count - 1)
            {
                section2 = section;
            }
            else
            {
                int num = 0;
                EnhancementSet enhancementSet = DatabaseAPI.Database.EnhancementSets[sIdx];
                bool[] flagArray = new bool[enhancementSet.Enhancements.Length];
                for (int index = 0; index <= flagArray.Length - 1; index++)
                {
                    flagArray[index] = false;
                }
                if (power != null)
                {
                    foreach (SlotEntry slot in power.Slots)
                    {
                        if (slot.Enhancement.Enh >= 0 && DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].nIDSet == sIdx)
                        {
                            num++;
                            for (int index2 = 0; index2 <= enhancementSet.Enhancements.Length - 1; index2++)
                            {
                                if (slot.Enhancement.Enh == enhancementSet.Enhancements[index2])
                                {
                                    flagArray[index2] = true;
                                }
                            }
                        }
                    }
                }
                if (power != null)
                {
                    section.Add(string.Concat(new object[]
                    {
                        "Set: ",
                        enhancementSet.DisplayName,
                        " (",
                        num,
                        "/",
                        enhancementSet.Enhancements.Length,
                        ")"
                    }), PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
                }
                for (int index3 = 0; index3 <= enhancementSet.Enhancements.Length - 1; index3++)
                {
                    string iText = enhancementSet.DisplayName + ": " + DatabaseAPI.Database.Enhancements[enhancementSet.Enhancements[index3]].Name;
                    if (flagArray[index3] || power == null)
                    {
                        section.Add(iText, PopUp.Colors.Invention, 0.9f, FontStyle.Bold, 1);
                    }
                    else
                    {
                        section.Add(iText, PopUp.Colors.Disabled, 0.9f, FontStyle.Bold, 1);
                    }
                }
                section2 = section;
            }
            return section2;
        }


        public void PoolShuffle(bool flagged = false)
        {
            int[] numArray = new int[4];
            int[] numArray2 = new int[4];
            for (int index = 3; index <= 6; index++)
            {
                numArray2[index - 3] = this.Powersets[index].nID;
                numArray[index - 3] = this.GetEarliestPowerIndex(this.Powersets[index].nID);
            }
            for (int index2 = 0; index2 <= 3; index2++)
            {
                int maxValue = 255;
                int index3 = -1;
                for (int index4 = 0; index4 <= numArray.Length - 1; index4++)
                {
                    if (maxValue > numArray[index4])
                    {
                        maxValue = numArray[index4];
                        index3 = index4;
                    }
                }
                if (index3 > -1)
                {
                    this.Powersets[index2 + 3] = DatabaseAPI.Database.Powersets[numArray2[index3]];
                    numArray[index3] = 512;
                }
            }
            if (!flagged)
            {
                this.PoolLocked[0] = (this.PowersetUsed(this.Powersets[3]) & this.PoolUnique(Enums.PowersetType.Pool0));
                this.PoolLocked[1] = (this.PowersetUsed(this.Powersets[4]) & this.PoolUnique(Enums.PowersetType.Pool1));
                this.PoolLocked[2] = (this.PowersetUsed(this.Powersets[5]) & this.PoolUnique(Enums.PowersetType.Pool2));
                this.PoolLocked[3] = (this.PowersetUsed(this.Powersets[6]) & this.PoolUnique(Enums.PowersetType.Pool3));
                this.PoolLocked[4] = this.PowersetUsed(this.Powersets[7]);
            }
        }


        private int GetEarliestPowerIndex(int iSet)
        {
            for (int index = 0; index <= this.CurrentBuild.LastPower; index++)
            {
                if (this.CurrentBuild.Powers[index].NIDPowerset == iSet)
                {
                    return index;
                }
            }
            return this.CurrentBuild.LastPower + 1;
        }


        private bool PoolUnique(Enums.PowersetType pool)
        {
            bool flag = true;
            for (int index = 3; index < (int)pool; index++)
            {
                if (this.Powersets[index].nID == this.Powersets[(int)pool].nID)
                {
                    flag = false;
                }
            }
            return flag;
        }


        private bool PowersetUsed(IPowerset powerset)
        {
            bool flag;
            if (powerset == null)
            {
                flag = false;
            }
            else
            {
                for (int index = 0; index < this.CurrentBuild.Powers.Count; index++)
                {
                    if (this.CurrentBuild.Powers[index].NIDPowerset == powerset.nID & this.CurrentBuild.Powers[index].IDXPower > -1)
                    {
                        return true;
                    }
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
            int index;
            int num;
            int index2;
            int index3;
            if (oldPowerset.nIDTrunkSet > -1)
            {
                index = oldPowerset.nIDTrunkSet;
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
                index = oldPowerset.nID;
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
            for (int index4 = 0; index4 < this.Powersets.Length; index4++)
            {
                if (this.Powersets[index4] != null && this.Powersets[index4].nID == oldPowerset.nID)
                {
                    this.Powersets[index4] = newPowerset;
                }
            }
            foreach (PowerEntry power in this.CurrentBuild.Powers)
            {
                if (power.NIDPowerset >= 0)
                {
                    int idxPower = power.IDXPower;
                    if (power.NIDPowerset == index)
                    {
                        int index5 = 0;
                        while (index5 < DatabaseAPI.Database.Powersets[index].Power.Length && DatabaseAPI.Database.Powersets[index].Powers[index5].Level == 0)
                        {
                            idxPower--;
                            index5++;
                        }
                        int index6 = 0;
                        while (index6 < DatabaseAPI.Database.Powersets[index2].Power.Length && DatabaseAPI.Database.Powersets[index2].Powers[index6].Level == 0)
                        {
                            idxPower++;
                            index6++;
                        }
                        if (index2 < 0)
                        {
                            power.Reset();
                        }
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
                        int index7 = 0;
                        while (index7 < DatabaseAPI.Database.Powersets[index].Power.Length && DatabaseAPI.Database.Powersets[index].Powers[index7].Level == 0)
                        {
                            idxPower--;
                            index7++;
                        }
                        int index8 = 0;
                        while (index8 < DatabaseAPI.Database.Powersets[index2].Power.Length && DatabaseAPI.Database.Powersets[index2].Powers[index8].Level == 0)
                        {
                            idxPower++;
                            index8++;
                        }
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
                    {
                        power.Slots = new SlotEntry[0];
                    }
                    else if (power.Slots.Length == 0)
                    {
                        power.Slots = new SlotEntry[1];
                        power.Slots[0].Enhancement = new I9Slot();
                        power.Slots[0].FlippedEnhancement = new I9Slot();
                        power.Slots[0].Level = power.Level;
                    }
                    else if (idxPower > -1)
                    {
                        for (int index9 = 0; index9 < power.SlotCount; index9++)
                        {
                            if (!power.PowerSet.Powers[idxPower].IsEnhancementValid(power.Slots[index9].Enhancement.Enh))
                            {
                                power.Slots[index9].Enhancement = new I9Slot();
                            }
                        }
                    }
                }
            }
            this.CurrentBuild.FullMutexCheck();
        }


        private Archetype _archetype;


        private bool? _completeCache;


        public class TotalStatistics
        {

            // (get) Token: 0x060000B2 RID: 178 RVA: 0x00005FD8 File Offset: 0x000041D8
            // (set) Token: 0x060000B3 RID: 179 RVA: 0x00005FEF File Offset: 0x000041EF
            public float[] Def { get; set; }


            // (get) Token: 0x060000B4 RID: 180 RVA: 0x00005FF8 File Offset: 0x000041F8
            // (set) Token: 0x060000B5 RID: 181 RVA: 0x0000600F File Offset: 0x0000420F
            public float[] Res { get; set; }


            // (get) Token: 0x060000B6 RID: 182 RVA: 0x00006018 File Offset: 0x00004218
            // (set) Token: 0x060000B7 RID: 183 RVA: 0x0000602F File Offset: 0x0000422F
            public float[] Mez { get; set; }


            // (get) Token: 0x060000B8 RID: 184 RVA: 0x00006038 File Offset: 0x00004238
            // (set) Token: 0x060000B9 RID: 185 RVA: 0x0000604F File Offset: 0x0000424F
            public float[] MezRes { get; set; }


            // (get) Token: 0x060000BA RID: 186 RVA: 0x00006058 File Offset: 0x00004258
            // (set) Token: 0x060000BB RID: 187 RVA: 0x0000606F File Offset: 0x0000426F
            public float[] DebuffRes { get; set; }


            // (get) Token: 0x060000BC RID: 188 RVA: 0x00006078 File Offset: 0x00004278
            // (set) Token: 0x060000BD RID: 189 RVA: 0x0000608F File Offset: 0x0000428F
            public float Elusivity { get; set; }


            // (get) Token: 0x060000BE RID: 190 RVA: 0x00006098 File Offset: 0x00004298
            // (set) Token: 0x060000BF RID: 191 RVA: 0x000060AF File Offset: 0x000042AF
            public float HPRegen { get; set; }


            // (get) Token: 0x060000C0 RID: 192 RVA: 0x000060B8 File Offset: 0x000042B8
            // (set) Token: 0x060000C1 RID: 193 RVA: 0x000060CF File Offset: 0x000042CF
            public float HPMax { get; set; }


            // (get) Token: 0x060000C2 RID: 194 RVA: 0x000060D8 File Offset: 0x000042D8
            // (set) Token: 0x060000C3 RID: 195 RVA: 0x000060EF File Offset: 0x000042EF
            public float EndRec { get; set; }


            // (get) Token: 0x060000C4 RID: 196 RVA: 0x000060F8 File Offset: 0x000042F8
            // (set) Token: 0x060000C5 RID: 197 RVA: 0x0000610F File Offset: 0x0000430F
            public float EndUse { get; set; }


            // (get) Token: 0x060000C6 RID: 198 RVA: 0x00006118 File Offset: 0x00004318
            // (set) Token: 0x060000C7 RID: 199 RVA: 0x0000612F File Offset: 0x0000432F
            public float EndMax { get; set; }


            // (get) Token: 0x060000C8 RID: 200 RVA: 0x00006138 File Offset: 0x00004338
            // (set) Token: 0x060000C9 RID: 201 RVA: 0x0000614F File Offset: 0x0000434F
            public float RunSpd { get; set; }


            // (get) Token: 0x060000CA RID: 202 RVA: 0x00006158 File Offset: 0x00004358
            // (set) Token: 0x060000CB RID: 203 RVA: 0x0000616F File Offset: 0x0000436F
            public float MaxRunSpd { get; set; }


            // (get) Token: 0x060000CC RID: 204 RVA: 0x00006178 File Offset: 0x00004378
            // (set) Token: 0x060000CD RID: 205 RVA: 0x0000618F File Offset: 0x0000438F
            public float JumpSpd { get; set; }


            // (get) Token: 0x060000CE RID: 206 RVA: 0x00006198 File Offset: 0x00004398
            // (set) Token: 0x060000CF RID: 207 RVA: 0x000061AF File Offset: 0x000043AF
            public float MaxJumpSpd { get; set; }


            // (get) Token: 0x060000D0 RID: 208 RVA: 0x000061B8 File Offset: 0x000043B8
            // (set) Token: 0x060000D1 RID: 209 RVA: 0x000061CF File Offset: 0x000043CF
            public float FlySpd { get; set; }


            // (get) Token: 0x060000D2 RID: 210 RVA: 0x000061D8 File Offset: 0x000043D8
            // (set) Token: 0x060000D3 RID: 211 RVA: 0x000061EF File Offset: 0x000043EF
            public float MaxFlySpd { get; set; }


            // (get) Token: 0x060000D4 RID: 212 RVA: 0x000061F8 File Offset: 0x000043F8
            // (set) Token: 0x060000D5 RID: 213 RVA: 0x0000620F File Offset: 0x0000440F
            public float JumpHeight { get; set; }


            // (get) Token: 0x060000D6 RID: 214 RVA: 0x00006218 File Offset: 0x00004418
            // (set) Token: 0x060000D7 RID: 215 RVA: 0x0000622F File Offset: 0x0000442F
            public float StealthPvE { get; set; }


            // (get) Token: 0x060000D8 RID: 216 RVA: 0x00006238 File Offset: 0x00004438
            // (set) Token: 0x060000D9 RID: 217 RVA: 0x0000624F File Offset: 0x0000444F
            public float StealthPvP { get; set; }


            // (get) Token: 0x060000DA RID: 218 RVA: 0x00006258 File Offset: 0x00004458
            // (set) Token: 0x060000DB RID: 219 RVA: 0x0000626F File Offset: 0x0000446F
            public float ThreatLevel { get; set; }


            // (get) Token: 0x060000DC RID: 220 RVA: 0x00006278 File Offset: 0x00004478
            // (set) Token: 0x060000DD RID: 221 RVA: 0x0000628F File Offset: 0x0000448F
            public float Perception { get; set; }


            // (get) Token: 0x060000DE RID: 222 RVA: 0x00006298 File Offset: 0x00004498
            // (set) Token: 0x060000DF RID: 223 RVA: 0x000062AF File Offset: 0x000044AF
            public float BuffHaste { get; set; }


            // (get) Token: 0x060000E0 RID: 224 RVA: 0x000062B8 File Offset: 0x000044B8
            // (set) Token: 0x060000E1 RID: 225 RVA: 0x000062CF File Offset: 0x000044CF
            public float BuffAcc { get; set; }


            // (get) Token: 0x060000E2 RID: 226 RVA: 0x000062D8 File Offset: 0x000044D8
            // (set) Token: 0x060000E3 RID: 227 RVA: 0x000062EF File Offset: 0x000044EF
            public float BuffToHit { get; set; }


            // (get) Token: 0x060000E4 RID: 228 RVA: 0x000062F8 File Offset: 0x000044F8
            // (set) Token: 0x060000E5 RID: 229 RVA: 0x0000630F File Offset: 0x0000450F
            public float BuffDam { get; set; }


            // (get) Token: 0x060000E6 RID: 230 RVA: 0x00006318 File Offset: 0x00004518
            // (set) Token: 0x060000E7 RID: 231 RVA: 0x0000632F File Offset: 0x0000452F
            public float BuffEndRdx { get; set; }


            internal TotalStatistics()
            {
                this.Init();
            }


            public void Init()
            {
                this.Def = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                this.Res = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                this.Mez = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
                this.MezRes = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
                this.DebuffRes = new float[Enum.GetValues(Enums.eEffectType.None.GetType()).Length];
                this.Elusivity = 0f;
                this.HPRegen = 0f;
                this.HPMax = 0f;
                this.EndRec = 0f;
                this.EndUse = 0f;
                this.EndMax = 0f;
                this.RunSpd = 0f;
                this.JumpSpd = 0f;
                this.FlySpd = 0f;
                this.JumpHeight = 0f;
                this.StealthPvE = 0f;
                this.StealthPvP = 0f;
                this.ThreatLevel = 0f;
                this.Perception = 0f;
                this.BuffHaste = 0f;
                this.BuffAcc = 0f;
                this.BuffToHit = 0f;
                this.BuffDam = 0f;
                this.BuffEndRdx = 0f;
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
