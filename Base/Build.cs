
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class Build
{
    readonly Character _character;

    public readonly List<PowerEntry> Powers;
    public readonly List<I9SetData> SetBonus;
    IPower _setBonusVirtualPower;

    public int LastPower;

    public IPower SetBonusVirtualPower
    {
        get
        {
            IPower power;
            if ((power = this._setBonusVirtualPower) == null)
                power = this._setBonusVirtualPower = this.GetSetBonusVirtualPower();
            return power;
        }
    }

    public int PowersPlaced
    {
        get
        {
            int pplaced = 0;
            foreach (PowerEntry power in this.Powers)
            {
                if (power.Chosen && power.Power != null)
                    ++pplaced;
            }
            return pplaced;
        }
    }

    public int SlotsPlaced
    {
        get
        {
            int placed = 0;
            foreach (PowerEntry power in this.Powers)
            {
                if (power.Slots.Length > 1)
                    placed += power.Slots.Length - 1;
            }
            return placed;
        }
    }

    public int TotalSlotsAvailable
    {
        get
        {
            int slots = 0;
            foreach (LevelMap level in DatabaseAPI.Database.Levels)
                slots += level.Slots;
            return slots;
        }
    }

    public PowerEntry AddPower(IPower power, int specialLevel = -1)
    {
        PowerEntry powerEntry = this.GetPowerEntry(power);
        if (powerEntry == null)
        {
            powerEntry = new PowerEntry(specialLevel, power, false);
            this.Powers.Add(powerEntry);
        }
        powerEntry.ValidateSlots();
        return powerEntry;
    }

    public void RemovePower(IPower powerToRemove)
    {
        foreach (PowerEntry power in this.Powers)
        {
            if (power != null && power.Power != null && power.Power.PowerIndex == powerToRemove.PowerIndex)
            {
                power.Reset();
                break;
            }
        }
    }

    PowerEntry GetPowerEntry(IPower power)
    {
        foreach (PowerEntry power1 in this.Powers)
        {
            if (power1.Power != null && power1.Power.PowerIndex == power.PowerIndex)
                return power1;
        }
        return null;
    }

    public Build(Character owner, IList<LevelMap> iLevels)
    {
        this._character = owner;
        this.Powers = new List<PowerEntry>()
        {
          new PowerEntry(0, null, true)
        };
        this.SetBonus = new List<I9SetData>();
        this.LastPower = 0;
        for (int iLevel = 0; iLevel < iLevels.Count; ++iLevel)
        {
            for (int index = 0; index < iLevels[iLevel].Powers; ++index)
            {
                this.Powers.Add(new PowerEntry(iLevel, null, true));
                ++this.LastPower;
            }
        }
    }

    public void RemoveSlotFromPower(int powerIdx, int slotIdx)
    {
        if (powerIdx < 0 || powerIdx > this.Powers.Count - 1 || (slotIdx < 0 || slotIdx > this.Powers[powerIdx].Slots.Length - 1))
            return;
        int index1 = -1;
        SlotEntry[] slotEntryArray = new SlotEntry[this.Powers[powerIdx].Slots.Length - 1];
        for (int i = 0; i <= this.Powers[powerIdx].Slots.Length - 1; ++i)
        {
            if (i != slotIdx)
            {
                ++index1;
                slotEntryArray[index1].Assign(this.Powers[powerIdx].Slots[i]);
            }
        }
        this.Powers[powerIdx].Slots = new SlotEntry[slotEntryArray.Length];
        for (int index2 = 0; index2 <= this.Powers[powerIdx].Slots.Length - 1; ++index2)
            this.Powers[powerIdx].Slots[index2].Assign(slotEntryArray[index2]);
    }

    void FillMissingSubPowers()
    {
        foreach (PowerEntry power in this.Powers)
        {
            if (power.Power != null && power.Power.NIDSubPower.Length > 0)
            {
                if (power.SubPowers.Length != power.Power.NIDSubPower.Length)
                    power.SubPowers = new PowerSubEntry[power.Power.NIDSubPower.Length];
                for (int index = 0; index <= power.Power.NIDSubPower.Length - 1; ++index)
                {
                    if (power.SubPowers[index]?.nIDPower != power.Power.NIDSubPower[index])
                    {
                        power.SubPowers[index] = new PowerSubEntry()
                        {
                            nIDPower = power.Power.NIDSubPower[index]
                        };
                        if (power.Power.NIDSubPower[index] > -1)
                        {
                            power.SubPowers[index].Powerset = DatabaseAPI.Database.Power[power.Power.NIDSubPower[index]].PowerSetID;
                            power.SubPowers[index].Power = DatabaseAPI.Database.Power[power.Power.NIDSubPower[index]].PowerSetIndex;
                        }
                        else
                        {
                            power.SubPowers[index].Powerset = -1;
                            power.SubPowers[index].Power = -1;
                        }
                    }
                }
            }
        }
    }

    void ValidateEnhancements()
    {
        foreach (PowerEntry power in this.Powers)
        {
            foreach (SlotEntry slot in power.Slots)
            {
                if (slot.Enhancement.Enh > -1)
                {
                    if (DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal && slot.Enhancement.Grade <= Enums.eEnhGrade.None | slot.Enhancement.Grade > Enums.eEnhGrade.SingleO)
                        slot.Enhancement.Grade = Enums.eEnhGrade.SingleO;
                    if (DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.SpecialO && slot.Enhancement.RelativeLevel < Enums.eEnhRelative.None | slot.Enhancement.RelativeLevel > Enums.eEnhRelative.PlusFive)
                        slot.Enhancement.RelativeLevel = MidsContext.Config.CalcEnhLevel;
                }
                if (slot.FlippedEnhancement.Enh > -1)
                {
                    if (DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].TypeID == Enums.eType.Normal && slot.FlippedEnhancement.Grade <= Enums.eEnhGrade.None | slot.FlippedEnhancement.Grade > Enums.eEnhGrade.SingleO)
                        slot.FlippedEnhancement.Grade = Enums.eEnhGrade.SingleO;
                    if (DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].TypeID == Enums.eType.SpecialO && slot.FlippedEnhancement.RelativeLevel < Enums.eEnhRelative.None | slot.FlippedEnhancement.RelativeLevel > Enums.eEnhRelative.PlusFive)
                        slot.FlippedEnhancement.RelativeLevel = MidsContext.Config.CalcEnhLevel;
                }
            }
        }
    }

    public bool SetEnhGrades(Enums.eEnhGrade newVal)
    {
        string str = string.Empty;
        switch (newVal)
        {
            case Enums.eEnhGrade.None:
                str = "This value should never be passed to the function!";
                break;
            case Enums.eEnhGrade.TrainingO:
                str = "Training";
                break;
            case Enums.eEnhGrade.DualO:
                str = "Dual";
                break;
            case Enums.eEnhGrade.SingleO:
                str = "Single";
                break;
        }
        if (MessageBox.Show(string.Format("Really set all placed Regular enhancements to {0} Origin?\n\nThis will not affect any Invention or Special enhancements.", str), "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            foreach (PowerEntry power in this.Powers)
            {
                foreach (SlotEntry slot in power.Slots)
                {
                    if (slot.Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal)
                        slot.Enhancement.Grade = newVal;
                }
            }
            return true;
        }
        else
            return false;
    }

    public bool SetIOLevels(int newVal, bool iSetMin, bool iSetMax)
    {
        string text;
        if (!iSetMin & !iSetMax)
            text = "Really set all placed Invention and Set enhancements to level " + newVal + 1 + "?\n\nNote: Enahncements which are not available at the default level will be set to the closest value.";
        else if (iSetMin)
        {
            newVal = 0;
            text = "Really set all placed Invention and Set enhancements to their minimum possible level?";
        }
        else
        {
            newVal = 52;
            text = "Really set all placed Invention and Set enhancements to their maximum possible level?";
        }
        if (MessageBox.Show(text, "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            foreach (PowerEntry power in this.Powers)
            {
                foreach (SlotEntry slot in power.Slots)
                {
                    if (slot.Enhancement.Enh > -1)
                    {
                        switch (DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID)
                        {
                            case Enums.eType.InventO:
                                int levelMin1 = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].LevelMin;
                                int levelMax = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].LevelMax;
                                if (newVal >= levelMin1 & newVal <= levelMax)
                                {
                                    slot.Enhancement.IOLevel = Enhancement.GranularLevelZb(newVal, levelMin1, levelMax, 5);
                                    break;
                                }
                                if (newVal > levelMax)
                                {
                                    slot.Enhancement.IOLevel = Enhancement.GranularLevelZb(levelMax, levelMin1, levelMax, 5);
                                    break;
                                }
                                if (newVal < levelMin1)
                                {
                                    slot.Enhancement.IOLevel = Enhancement.GranularLevelZb(levelMin1, levelMin1, levelMax, 5);
                                    break;
                                }
                                break;
                            case Enums.eType.SetO:
                                int levelMin2 = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].nIDSet].LevelMin;
                                int num = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].nIDSet].LevelMax;
                                if (num > 49)
                                    num = 49;
                                if (newVal >= levelMin2 & newVal <= num)
                                {
                                    slot.Enhancement.IOLevel = newVal;
                                    break;
                                }
                                if (newVal > num)
                                {
                                    slot.Enhancement.IOLevel = num;
                                    break;
                                }
                                if (newVal < levelMin2)
                                {
                                    slot.Enhancement.IOLevel = levelMin2;
                                    break;
                                }
                                break;
                        }
                    }
                }
            }
            return true;
        }
        else
            return false;
    }

    public HistoryMap[] BuildHistoryMap(bool enhNames, bool ioLevel = true)
    {
        List<HistoryMap> historyMapList = new List<HistoryMap>();
        for (int lvlIdx = 0; lvlIdx <= DatabaseAPI.Database.Levels.Length - 1; ++lvlIdx)
        {
            for (int powerIdx = 0; powerIdx <= this.Powers.Count - 1; ++powerIdx)
            {
                PowerEntry power = this.Powers[powerIdx];
                if ((power.Chosen || power.SubPowers.Length == 0 || power.SlotCount == 0) && power.Level == lvlIdx & power.Power != null)
                {
                    HistoryMap historyMap = new HistoryMap()
                    {
                        Level = lvlIdx,
                        HID = powerIdx
                    };
                    string str1 = string.Empty;
                    string str2 = power.Chosen ? "Added" : "Recieved";
                    if (power.Slots.Length > 0)
                    {
                        historyMap.SID = 0;
                        if (power.Slots[0].Enhancement.Enh > -1)
                        {
                            if (enhNames)
                                str1 = " [" + DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[0].Enhancement.Enh);
                            if (ioLevel && (DatabaseAPI.Database.Enhancements[power.Slots[0].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[0].Enhancement.Enh].TypeID == Enums.eType.SetO))
                                str1 = str1 + "-" + power.Slots[0].Enhancement.IOLevel;
                            str1 += "]";
                        }
                        else if (enhNames)
                            str1 = " [Empty]";
                    }
                    historyMap.Text = "Level " + (lvlIdx + 1) + ": " + str2 + " " + power.Power.DisplayName + " (" + Enum.GetName(DatabaseAPI.Database.Powersets[power.NIDPowerset].SetType.GetType(), DatabaseAPI.Database.Powersets[power.NIDPowerset].SetType) + ")" + str1;
                    historyMapList.Add(historyMap);
                }
            }
            for (int powerIdx = 0; powerIdx <= this.Powers.Count - 1; ++powerIdx)
            {
                PowerEntry power = this.Powers[powerIdx];
                for (int slotIdx = 1; slotIdx <= power.Slots.Length - 1; ++slotIdx)
                {
                    if (power.Slots[slotIdx].Level == lvlIdx)
                    {
                        HistoryMap historyMap = new HistoryMap()
                        {
                            Level = lvlIdx,
                            HID = powerIdx,
                            SID = slotIdx
                        };
                        string str = string.Empty;
                        if (power.Slots[slotIdx].Enhancement.Enh > -1)
                        {
                            if (enhNames)
                                str = " [" + DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[slotIdx].Enhancement.Enh);
                            if (ioLevel && (DatabaseAPI.Database.Enhancements[power.Slots[slotIdx].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[slotIdx].Enhancement.Enh].TypeID == Enums.eType.SetO))
                                str = str + "-" + power.Slots[slotIdx].Enhancement.IOLevel;
                            str += "]";
                        }
                        else if (enhNames)
                            str = " [Empty]";
                        historyMap.Text = "Level " + (lvlIdx + 1) + ": Added Slot to " + power.Power.DisplayName + str;
                        historyMapList.Add(historyMap);
                    }
                }
            }
        }
        return historyMapList.ToArray();
    }

    int SlotsAtLevel(int powerEntryId, int iLevel)
    {
        if (powerEntryId < 0)
            return 0;
        int slotsAtLevel = 0;
        foreach (SlotEntry slot in this.Powers[powerEntryId].Slots)
        {
            if (slot.Level <= iLevel)
                ++slotsAtLevel;
        }
        return slotsAtLevel;
    }

    public int SlotsPlacedAtLevel(int level)
    {
        int slotsPlacedAtLevel = 0;
        for (int powerIdx = 0; powerIdx < this.Powers.Count; ++powerIdx)
        {
            for (int slotIdx = 0; slotIdx < this.Powers[powerIdx].Slots.Length; ++slotIdx)
            {
                if (this.Powers[powerIdx].Slots[slotIdx].Level == level)
                    ++slotsPlacedAtLevel;
            }
        }
        return slotsPlacedAtLevel;
    }

    public PopUp.PopupData GetRespecHelper(bool longFormat, int iLevel = 49)
    {
        PopUp.PopupData popupData = new PopUp.PopupData();
        HistoryMap[] historyMapArray = this.BuildHistoryMap(true, true);
        int index1 = popupData.Add(null);
        popupData.Sections[index1].Add("Respec to level: " + (iLevel + 1), PopUp.Colors.Effect, 1.25f, FontStyle.Bold, 0);
        foreach (HistoryMap historyMap in historyMapArray)
        {
            if (historyMap.HID > -1 && DatabaseAPI.Database.Levels[historyMap.Level].Powers > 0 && historyMap.Level <= iLevel)
            {
                PowerEntry power = this.Powers[historyMap.HID];
                if (power.Slots.Length > 0)
                {
                    int index2 = popupData.Add(null);
                    string iText1;
                    if (power.Power != null)
                        iText1 = "Level " + (historyMap.Level + 1) + ": " + power.Power.DisplayName;
                    else
                        iText1 = "Level " + (historyMap.Level + 1) + ": [Empty]";
                    popupData.Sections[index2].Add(iText1, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                    int slots = this.SlotsAtLevel(historyMap.HID, iLevel);
                    if (slots > 0)
                    {
                        popupData.Sections[index2].Add("Slots: " + slots, PopUp.Colors.Text, 1f, FontStyle.Regular, 1);
                        if (longFormat)
                        {
                            for (int slotIdx = 0; slotIdx <= slots - 1; ++slotIdx)
                            {
                                string str = slotIdx != 0 ? "(" + (power.Slots[slotIdx].Level + 1) + ") " : "(A) ";
                                string iText2;
                                if (power.Slots[slotIdx].Enhancement.Enh > -1)
                                {
                                    iText2 = str + DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[slotIdx].Enhancement.Enh);
                                    if (DatabaseAPI.Database.Enhancements[power.Slots[slotIdx].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[slotIdx].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                        iText2 = iText2 + "-" + (power.Slots[slotIdx].Enhancement.IOLevel + 1);
                                }
                                else
                                    iText2 = str + "[Empty]";
                                popupData.Sections[index2].Add(iText2, PopUp.Colors.Invention, 1f, FontStyle.Regular, 2);
                            }
                        }
                    }
                }
            }
        }
        return popupData;
    }

    public PopUp.PopupData GetRespecHelper2(bool longFormat, int iLevel = 49)
    {
        PopUp.PopupData popupData = new PopUp.PopupData();
        HistoryMap[] historyMapArray = this.BuildHistoryMap(true, true);
        int index = popupData.Add(null);
        popupData.Sections[index].Add("Respec to level: " + (iLevel + 1), PopUp.Colors.Effect, 1.25f, FontStyle.Bold, 0);
        int histLvl = 0;
        foreach (HistoryMap historyMap in historyMapArray)
        {
            if (histLvl != historyMap.Level)
                index = popupData.Add(null);
            histLvl = historyMap.Level;
            if (historyMap.HID >= 0)
            {
                PowerEntry power = this.Powers[historyMap.HID];
                if (DatabaseAPI.Database.Levels[historyMap.Level].Powers > 0 & historyMap.Level <= iLevel)
                {
                    if (power.Slots.Length > 0)
                    {
                        string iText1;
                        if (power.Power != null)
                            iText1 = "Level " + (historyMap.Level + 1) + ": " + power.Power.DisplayName;
                        else
                            iText1 = "Level " + (historyMap.Level + 1) + ": [Empty]";
                        popupData.Sections[index].Add(iText1, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                        if (longFormat)
                        {
                            string empty = string.Empty;
                            string iText2;
                            if (power.Slots[historyMap.SID].Enhancement.Enh > -1)
                            {
                                iText2 = empty + DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[historyMap.SID].Enhancement.Enh);
                                if (DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                    iText2 = iText2 + "-" + (power.Slots[historyMap.SID].Enhancement.IOLevel + 1);
                            }
                            else
                                iText2 = empty + "[Empty]";
                            popupData.Sections[index].Add(iText2, PopUp.Colors.Invention, 1f, FontStyle.Regular, 1);
                        }
                    }
                }
                else if (DatabaseAPI.Database.Levels[historyMap.Level].Slots > 0 & historyMap.Level <= iLevel && historyMap.SID > -1)
                {
                    string str = historyMap.SID != 0 ? "Level " + (historyMap.Level + 1) + ": Added Slot To " : "Level " + (historyMap.Level + 1) + ": Received Slot - ";
                    string iText1 = power.Power == null ? str + "[Empty]" : str + power.Power.DisplayName;
                    popupData.Sections[index].Add(iText1, PopUp.Colors.Effect, 1f, FontStyle.Bold, 0);
                    if (longFormat)
                    {
                        string iText2;
                        if (power.Slots[historyMap.SID].Enhancement.Enh > -1)
                        {
                            iText2 = string.Empty + DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[historyMap.SID].Enhancement.Enh);
                            if (DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                iText2 = iText2 + "-" + (power.Slots[historyMap.SID].Enhancement.IOLevel + 1);
                        }
                        else
                            iText2 = "[Empty]";
                        popupData.Sections[index].Add(iText2, PopUp.Colors.Invention, 1f, FontStyle.Regular, 1);
                    }
                }
            }
        }
        return popupData;
    }

    public bool SetEnhRelativelevels(Enums.eEnhRelative newVal)
    {
        string display = string.Empty;
        switch (newVal)
        {
            case Enums.eEnhRelative.None:
                display = "None (Enhancements will have no effect)";
                break;
            case Enums.eEnhRelative.MinusThree:
                display = "-3";
                break;
            case Enums.eEnhRelative.MinusTwo:
                display = "-2";
                break;
            case Enums.eEnhRelative.MinusOne:
                display = "-1";
                break;
            case Enums.eEnhRelative.Even:
                display = "Even (+/- 0)";
                break;
            case Enums.eEnhRelative.PlusOne:
                display = "+1";
                break;
            case Enums.eEnhRelative.PlusTwo:
                display = "+2";
                break;
            case Enums.eEnhRelative.PlusThree:
                display = "+3";
                break;
            case Enums.eEnhRelative.PlusFour:
                display = "+4";
                break;
            case Enums.eEnhRelative.PlusFive:
                display = "+5";
                break;
        }
        if (MessageBox.Show(string.Format("Really set all placed enhancements to a relative level of {0}?\n\nNote: Normal and Special enhancements cannot go above +3, and Inventions cannot go below +0.", display), "Are you sure?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return false;
        foreach (PowerEntry power in this.Powers)
        {
            foreach (SlotEntry slot in power.Slots)
            {
                if (slot.Enhancement.Enh > -1)
                {
                    IEnhancement enhancement = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh];
                    if (newVal > Enums.eEnhRelative.PlusThree)
                    {
                        int num = enhancement.TypeID == Enums.eType.Normal ? 0 : (enhancement.TypeID != Enums.eType.SpecialO ? 1 : 0);
                        slot.Enhancement.RelativeLevel = num != 0 ? newVal : Enums.eEnhRelative.PlusThree;
                    }
                    else if (newVal < Enums.eEnhRelative.Even)
                    {
                        int num = enhancement.TypeID == Enums.eType.Normal ? 0 : (enhancement.TypeID != Enums.eType.SpecialO ? 1 : 0);
                        slot.Enhancement.RelativeLevel = num != 0 ? Enums.eEnhRelative.Even : newVal;
                    }
                    else
                        slot.Enhancement.RelativeLevel = newVal;
                }
            }
        }
        return true;
    }

    void CheckAndFixAllEnhancements()
    {
        foreach (PowerEntry power in this.Powers)
        {
            foreach (SlotEntry slot in power.Slots)
            {
                if (power.Power != null)
                {
                    if (slot.Enhancement.Enh > -1)
                    {
                        if (!power.Power.IsEnhancementValid(slot.Enhancement.Enh))
                            slot.Enhancement.Enh = -1;
                        else
                            slot.Enhancement.IOLevel = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].CheckAndFixIOLevel(slot.Enhancement.IOLevel);
                    }
                    if (slot.FlippedEnhancement.Enh > -1)
                    {
                        if (!power.Power.IsEnhancementValid(slot.FlippedEnhancement.Enh))
                            slot.FlippedEnhancement.Enh = -1;
                        else
                            slot.FlippedEnhancement.IOLevel = DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].CheckAndFixIOLevel(slot.FlippedEnhancement.IOLevel);
                    }
                }
                else
                {
                    slot.Enhancement.Enh = -1;
                    slot.Enhancement.IOLevel = 0;
                    slot.FlippedEnhancement.Enh = -1;
                    slot.FlippedEnhancement.IOLevel = 0;
                }
            }
        }
        this.ValidateEnhancements();
    }

    void CheckAllVariableBounds()
    {
        for (int index = 0; index <= this.Powers.Count - 1; ++index)
            this.Powers[index].CheckVariableBounds();
    }

    internal void Validate()
    {
        this.ClearInvisibleSlots();
        this.ScanAndCleanAutomaticallyGrantedPowers();
        this.AddAutomaticGrantedPowers();
        this.FillMissingSubPowers();
        this.CheckAndFixAllEnhancements();
        this.CheckAllVariableBounds();
    }

    public int GetMaxLevel()
    {
        int maxLevel = 0;
        foreach (PowerEntry power in this.Powers)
        {
            if (power.Level > maxLevel)
                maxLevel = power.Level;
            foreach (SlotEntry slot in power.Slots)
            {
                if (slot.Level > maxLevel)
                    maxLevel = slot.Level;
            }
        }
        return maxLevel;
    }

    void ClearInvisibleSlots()
    {
        foreach (PowerEntry power in this.Powers)
        {
            power.ClearInvisibleSlots();
        }
    }

    void ScanAndCleanAutomaticallyGrantedPowers()
    {
        bool flag = false;
        int maxLevel = this.GetMaxLevel();
        foreach (PowerEntry power in this.Powers)
        {
            if (power.Power != null && power.PowerSet != null && !power.Chosen && (power.PowerSet.SetType == Enums.ePowerSetType.Inherent || power.PowerSet.SetType == Enums.ePowerSetType.Primary || power.PowerSet.SetType == Enums.ePowerSetType.Secondary))
            {
                if (power.Power.Level > maxLevel + 1 || !this.MeetsRequirement(power.Power, maxLevel, -1) || !power.Power.IncludeFlag)
                {
                    power.Tag = true;
                    flag = true;
                }
                if (power.Power.Level > power.Level + 1)
                    power.Level = power.Power.Level - 1;
            }
        }
        if (!flag)
            return;
        int powerIdx = 0;
        while (powerIdx < this.Powers.Count)
        {
            if (this.Powers[powerIdx].Tag)
            {
                this.Powers[powerIdx].Reset();
                if (!this.Powers[powerIdx].Chosen)
                {
                    this.Powers[powerIdx].Level = -1;
                    this.Powers[powerIdx].Slots = Array.Empty<SlotEntry>();
                }
            }
            else
                ++powerIdx;
        }
    }

    public bool MeetsRequirement(IPower power, int nLevel, int skipIdx = -1)
    {
        if (nLevel < 0)
            return false;

        int nIdSkip = -1;
        if (skipIdx > -1 & skipIdx < this.Powers.Count)
            nIdSkip = this.Powers[skipIdx].Power == null ? -1 : this.Powers[skipIdx].Power.PowerIndex;
        if (nLevel + 1 < power.Level)
            return false;
        if (power.Requires.NClassName.Length == 0 & power.Requires.NClassNameNot.Length == 0 & power.Requires.NPowerID.Length == 0 & power.Requires.NPowerIDNot.Length == 0)
            return true;

        bool valid = power.Requires.NClassName.Length == 0;

        foreach (int clsNameIdx in power.Requires.NClassName)
        {
            if (MidsContext.Character.Archetype.Idx == clsNameIdx)
                valid = true;
        }
        foreach (int nclsnamenot in power.Requires.NClassNameNot)
        {
            if (MidsContext.Character.Archetype.Idx == nclsnamenot)
                return false;
        }
        if (!valid)
            return false;

        if (power.Requires.NPowerID.Length > 0)
            valid = false;
        foreach (int[] numArray in power.Requires.NPowerID)
        {
            bool doubleValid = true;
            foreach (int nIDPower in numArray)
            {
                if (nIDPower > -1)
                {
                    int index = -1;
                    if (nIDPower != nIdSkip)
                        index = this.FindInToonHistory(nIDPower);
                    if (index < 0)
                        doubleValid = false;
                    else if (this.Powers[index].Level > nLevel)
                        doubleValid = false;
                }
            }
            if (doubleValid)
            {
                valid = true;
                break;
            }
        }
        if (!valid)
            return false;
        foreach (int[] numArray in power.Requires.NPowerIDNot)
        {
            foreach (int nIDPower in numArray)
            {
                if (nIDPower > -1)
                {
                    int histIdx = -1;
                    if (nIDPower != nIdSkip)
                        histIdx = this.FindInToonHistory(nIDPower);
                    if (histIdx > -1)
                        return false;
                }
            }
        }
        return valid;
    }

    public int FindInToonHistory(int nIDPower)
    {
        for (int powerIdx = 0; powerIdx <= this.Powers.Count - 1; ++powerIdx)
        {
            if (this.Powers[powerIdx].Power != null && this.Powers[powerIdx].Power.PowerIndex == nIDPower)
                return powerIdx;
        }
        return -1;
    }

    public bool PowerUsed(IPower power)
        => this.FindInToonHistory(power.PowerIndex) > -1;

    void AddAutomaticGrantedPowers()
    {
        int maxLevel = this.GetMaxLevel();
        List<IPowerset> powersetList = new List<IPowerset>();
        powersetList.AddRange(_character.Powersets);
        foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
        {
            if (powerset.SetType == Enums.ePowerSetType.Inherent && !powersetList.Contains(powerset))
                powersetList.Add(powerset);
        }
        foreach (IPowerset powerset in powersetList)
        {
            if (powerset != null)
            {
                foreach (IPower power in powerset.Powers)
                {
                    int val2 = 0;
                    if (power.IncludeFlag && power.Level <= maxLevel + 1 && !this.PowerUsed(power) && this.MeetsRequirement(power, maxLevel + 1, -1))
                    {
                        if (power.Requires.NPowerID.Length > 0)
                        {
                            int inToonHistory = this.FindInToonHistory(power.Requires.NPowerID[0][0]);
                            if (inToonHistory > -1)
                                val2 = this.Powers[inToonHistory].Level;
                        }
                        this.AddPower(power, Math.Max(power.Level - 1, val2));
                    }
                }
            }
        }
    }

    public bool EnhancementTest(int iSlotID, int hIdx, int iEnh, bool silent = false)
    { /*
        bool flag1;
        if (iEnh < 0 | iSlotID < 0)
        {
            flag1 = false;
        }
        else
        {
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[iEnh];
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            if (enhancement.TypeID == Enums.eType.SetO && enhancement.nIDSet > -1 && hIdx > -1 && this.Powers[hIdx].Power != null)
            {
              if (enhancement.Unique && this.Powers[index1].Slots[index2].Enhancement.Enh == iEnh)
              {
                flag2 = true;
                break;
              }
              if (enhancement.MutExID != Enums.eEnhMutex.None && DatabaseAPI.Database.Enhancements[this.Powers[index1].Slots[index2].Enhancement.Enh].MutExID == enhancement.MutExID)
              {//6/29/19 Pine: Added checker for ATO Mutex
                if (enhancement.MutExID == Enums.eEnhMutex.ArchetypeA |
                    enhancement.MutExID == Enums.eEnhMutex.ArchetypeB |
                    enhancement.MutExID == Enums.eEnhMutex.ArchetypeC |
                    enhancement.MutExID == Enums.eEnhMutex.ArchetypeD |
                    enhancement.MutExID == Enums.eEnhMutex.ArchetypeE |
                    enhancement.MutExID == Enums.eEnhMutex.ArchetypeF)
                {
                    string compareStringSlottedEnh = DatabaseAPI.Database.Enhancements[this.Powers[index1].Slots[index2].Enhancement.Enh].LongName;
                    if (compareStringSlottedEnh.Contains("Superior"))
                        compareStringSlottedEnh = compareStringSlottedEnh.Remove(0,9);
                    string compareStringSlottingEnh = enhancement.LongName;
                    if (compareStringSlottingEnh.Contains("Superior"))
                        compareStringSlottingEnh = compareStringSlottingEnh.Remove(0, 9);
                    if (compareStringSlottedEnh != compareStringSlottingEnh)
                        break;
                }


                flag3 = true;
                break;
              }
              if (enhancement.nIDSet > -1 && index1 == hIdx && this.Powers[index1].Slots[index2].Enhancement.Enh == iEnh)
              {
                flag4 = true;
                break;
              }
            }
            if (flag5)
            {
                flag1 = false;
            }
            else
            {
                for (int index1 = 0; index1 <= this.Powers.Count - 1; ++index1)
                {
                    for (int index2 = 0; index2 <= this.Powers[index1].Slots.Length - 1; ++index2)
                    {
                        if ((index2 != iSlotID || index1 != hIdx) && this.Powers[index1].Slots[index2].Enhancement.Enh > -1)
                        {
                            if (enhancement.Unique && this.Powers[index1].Slots[index2].Enhancement.Enh == iEnh)
                            {
                                flag2 = true;
                                break;
                            }
                            if (enhancement.MutExID != Enums.eEnhMutex.None && DatabaseAPI.Database.Enhancements[this.Powers[index1].Slots[index2].Enhancement.Enh].MutExID == enhancement.MutExID)
                            {
                                flag3 = true;
                                break;
                            }
                            if (enhancement.nIDSet > -1 && index1 == hIdx && this.Powers[index1].Slots[index2].Enhancement.Enh == iEnh)
                            {
                                flag4 = true;
                                break;
                            }
                        }
                    }
                }
                if (flag2)
                {
                    if (!silent)
                    {
                        int num = (int)MessageBox.Show(enhancement.LongName + " is a unique enhancement. You can only slot one of these across your entire build.", "Can't Slot Enhancement");
                    }
                    flag1 = false;
                }
                else if (flag3)
                {
                    if (!silent)
                    {
                        int num = (int)MessageBox.Show(enhancement.LongName + " is mutually exclusive with enhancements in the " + Enum.GetName(enhancement.MutExID.GetType(), enhancement.MutExID) + " group. You can only slot one member of this group across your entire build.", "Can't Slot Enhancement");
                    }
                    flag1 = false;
                }
                else if (flag4)
                {
                    if (!silent)
                    {
                        int num = (int)MessageBox.Show(enhancement.LongName + " is already slotted in this power. You can only slot one of each enhancement from the set in a given power.", "Can't Slot Enhancement");
                    }
                    flag1 = false;
                }
                else
                    flag1 = true;
            }
        }
        return flag1; */
        if (iEnh < 0 || iSlotID < 0)
        {
            return false;
        }
        else
        {
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[iEnh];
            bool foundMutex = false;
            bool foundInPower = false;
            if (enhancement.TypeID == Enums.eType.SetO && enhancement.nIDSet > -1 && hIdx > -1 && this.Powers[hIdx].Power != null)
            {
                bool allowedSet = false;
                Enums.eSetType setType = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].SetType;
                for (int index = 0; index <= this.Powers[hIdx].Power.SetTypes.Length - 1; ++index)
                {
                    if (this.Powers[hIdx].Power.SetTypes[index] == setType)
                    {
                        allowedSet = true;
                        break;
                    }
                }
                if (!allowedSet)
                    return false;
            }

            for (int powerIdx = 0; powerIdx <= this.Powers.Count - 1; ++powerIdx)
            {
                for (int slotIndex = 0; slotIndex <= this.Powers[powerIdx].Slots.Length - 1; ++slotIndex)
                {
                    if ((slotIndex != iSlotID || powerIdx != hIdx) && this.Powers[powerIdx].Slots[slotIndex].Enhancement.Enh > -1)
                    {
                        if (enhancement.Unique && this.Powers[powerIdx].Slots[slotIndex].Enhancement.Enh == iEnh)
                        {
                            if (!silent)
                                MessageBox.Show(enhancement.LongName + " is a unique enhancement. You can only slot one of these across your entire build.", "Can't Slot Enhancement");
                            return false;
                        }
                        if (enhancement.MutExID != Enums.eEnhMutex.None && DatabaseAPI.Database.Enhancements[this.Powers[powerIdx].Slots[slotIndex].Enhancement.Enh].MutExID == enhancement.MutExID)
                        { //6/29/19 Pine: Added checker for ATO Mutex
                            if (enhancement.MutExID == Enums.eEnhMutex.ArchetypeA ||
                                enhancement.MutExID == Enums.eEnhMutex.ArchetypeB ||
                                enhancement.MutExID == Enums.eEnhMutex.ArchetypeC ||
                                enhancement.MutExID == Enums.eEnhMutex.ArchetypeD ||
                                enhancement.MutExID == Enums.eEnhMutex.ArchetypeE ||
                                enhancement.MutExID == Enums.eEnhMutex.ArchetypeF)
                            {
                                string compareStringSlottedEnh = DatabaseAPI.Database.Enhancements[this.Powers[powerIdx].Slots[slotIndex].Enhancement.Enh].LongName;
                                if (compareStringSlottedEnh.Contains("Superior"))
                                    compareStringSlottedEnh = compareStringSlottedEnh.Remove(0, 9);
                                string compareStringSlottingEnh = enhancement.LongName;
                                if (compareStringSlottingEnh.Contains("Superior"))
                                    compareStringSlottingEnh = compareStringSlottingEnh.Remove(0, 9);
                                if (compareStringSlottedEnh != compareStringSlottingEnh)
                                    break;
                            }

                            foundMutex = true;
                            break;
                        }
                        if (enhancement.nIDSet > -1 && powerIdx == hIdx && this.Powers[powerIdx].Slots[slotIndex].Enhancement.Enh == iEnh)
                        {
                            foundInPower = true;
                            break;
                        }
                    }
                }
            }
            if (foundMutex)
            {
                if (!silent)
                {
                    MessageBox.Show(enhancement.LongName + " is mutually exclusive with enhancements in the " + Enum.GetName(enhancement.MutExID.GetType(), enhancement.MutExID) + " group. You can only slot one member of this group across your entire build.", "Can't Slot Enhancement");
                }
                return false;
            }
            if (foundInPower)
            {
                if (!silent)
                {
                    MessageBox.Show(enhancement.LongName + " is already slotted in this power. You can only slot one of each enhancement from the set in a given power.", "Can't Slot Enhancement");
                }
                return false;
            }
            return true;
        }
    }

    public void GenerateSetBonusData()
    {
        this.SetBonus.Clear();
        for (int index1 = 0; index1 < this.Powers.Count; ++index1)
        {
            I9SetData i9SetData = new I9SetData()
            {
                PowerIndex = index1
            };
            if (this.Powers[index1].Level <= MidsContext.Config.ForceLevel)
            {
                for (int index2 = 0; index2 < this.Powers[index1].SlotCount; ++index2)
                    i9SetData.Add(ref this.Powers[index1].Slots[index2].Enhancement);
            }
            i9SetData.BuildEffects(MidsContext.Config.Inc.PvE ? Enums.ePvX.PvE : Enums.ePvX.PvP);
            if (!i9SetData.Empty)
                this.SetBonus.Add(i9SetData);
        }
        this._setBonusVirtualPower = null;
    }

    IPower GetSetBonusVirtualPower()
    {
        IPower power1 = new Power();
        if (!MidsContext.Config.I9.CalculateSetBonusFX)
        {
            return power1;
        }
        else
        {
            var nidPowers = DatabaseAPI.NidPowers("set_bonus", "");
            int[] setCount = new int[nidPowers.Length];
            for (int index = 0; index < setCount.Length; ++index)
                setCount[index] = 0;
            var effectList = new List<IEffect>();
            foreach (var setBonus in this.SetBonus)
                foreach (var setInfo in setBonus.SetInfo)
                    foreach (var power in setInfo.Powers.Where(x => x > -1))
                    {
                        if (power > setCount.Length - 1)
                            throw new IndexOutOfRangeException("power to setBonusArray");
                        ++setCount[power];
                        if (setCount[power] < 6)
                        {
                            for (int i = 0; i < DatabaseAPI.Database.Power[power].Effects.Length; ++i)
                                effectList.Add((IEffect)DatabaseAPI.Database.Power[power].Effects[i].Clone());

                        }
                    }

            power1.Effects = effectList.ToArray();
            return power1;
        }
    }

    public IEffect[] GetCumulativeSetBonuses()
    {
        IPower bonusVirtualPower = this.SetBonusVirtualPower;
        IEffect[] array = Array.Empty<IEffect>();
        for (int effIdx = 0; effIdx < bonusVirtualPower.Effects.Length; ++effIdx)
        {
            if (bonusVirtualPower.Effects[effIdx].EffectType != Enums.eEffectType.None || !string.IsNullOrEmpty(bonusVirtualPower.Effects[effIdx].Special))
            {
                int index2 = Build.GcsbCheck(array, bonusVirtualPower.Effects[effIdx]);
                if (index2 < 0)
                {
                    Array.Resize<IEffect>(ref array, array.Length + 1);
                    int index3 = array.Length - 1;
                    array[index3] = (IEffect)bonusVirtualPower.Effects[effIdx].Clone();
                    array[index3].Math_Mag = bonusVirtualPower.Effects[effIdx].Mag;
                }
                else
                    array[index2].Math_Mag += bonusVirtualPower.Effects[effIdx].Mag;
            }
        }
        return array;
    }

    static int GcsbCheck(IEffect[] fxList, IEffect testFX)
    {
        for (int index = 0; index < fxList.Length; ++index)
        {
            if (fxList[index].EffectType == testFX.EffectType && ((double)fxList[index].Mag > 0.0 & (double)testFX.Mag > 0.0 || (double)fxList[index].Mag < 0.0 & (double)testFX.Mag < 0.0 || (double)Math.Abs(fxList[index].Mag - ((double)testFX.Mag > 0.0 ? 1f : 0.0f)) < 0.001))
            {
                if ((testFX.EffectType == Enums.eEffectType.Mez || testFX.EffectType == Enums.eEffectType.MezResist) && fxList[index].MezType == testFX.MezType || (testFX.EffectType == Enums.eEffectType.Damage && testFX.DamageType == fxList[index].DamageType || testFX.EffectType == Enums.eEffectType.Defense && testFX.DamageType == fxList[index].DamageType) || (testFX.EffectType == Enums.eEffectType.Resistance && testFX.DamageType == fxList[index].DamageType || testFX.EffectType == Enums.eEffectType.DamageBuff && testFX.DamageType == fxList[index].DamageType || testFX.EffectType == Enums.eEffectType.Enhancement && testFX.ETModifies == fxList[index].ETModifies && (testFX.DamageType == fxList[index].DamageType && testFX.MezType == fxList[index].MezType)) || testFX.EffectType == Enums.eEffectType.ResEffect && testFX.ETModifies == fxList[index].ETModifies || testFX.EffectType == Enums.eEffectType.None && testFX.Special == fxList[index].Special && testFX.Special.IndexOf("DEBT", StringComparison.OrdinalIgnoreCase) > -1)
                    return index;
                else if (testFX.EffectType != Enums.eEffectType.Mez & testFX.EffectType != Enums.eEffectType.MezResist & testFX.EffectType != Enums.eEffectType.Damage & testFX.EffectType != Enums.eEffectType.Defense & testFX.EffectType != Enums.eEffectType.Resistance & testFX.EffectType != Enums.eEffectType.DamageBuff & testFX.EffectType != Enums.eEffectType.Enhancement & testFX.EffectType != Enums.eEffectType.ResEffect & testFX.EffectType == fxList[index].EffectType)
                    return index;
                else
                    continue;
            }
        }
        return -1;
    }

    public Enums.eMutex MutexV2(int hIdx, bool silent = false, bool doDetoggle = false)
    {
        Enums.eMutex eMutex;
        if (hIdx < 0 || hIdx > this.Powers.Count || this.Powers[hIdx].Power == null)
        {
            eMutex = Enums.eMutex.NoGroup;
        }
        else
        {
            IPower power1 = this.Powers[hIdx].Power;
            if (power1.MutexIgnore)
            {
                eMutex = Enums.eMutex.NoGroup;
            }
            else
            {
                List<PowerEntry> powerEntryList = new List<PowerEntry>();
                bool mutexAuto = false;
                int index1 = -1;
                for (int index2 = 0; index2 <= DatabaseAPI.Database.MutexList.Length - 1; ++index2)
                {
                    if (string.Equals(DatabaseAPI.Database.MutexList[index2], "KHELDIAN_GROUP", StringComparison.OrdinalIgnoreCase))
                    {
                        index1 = index2;
                        break;
                    }
                }
                bool flag2 = power1.HasMutexID(index1);
                foreach (PowerEntry power2 in this.Powers)
                {
                    if (power2.Power != null && power2.Power.PowerIndex != power1.PowerIndex)
                    {
                        IPower power3 = power2.Power;
                        if (power2.StatInclude && !power3.MutexIgnore)
                        {
                            if (flag2 || (power3.PowerType != Enums.ePowerType.Click || power3.PowerName == "Light_Form") && power3.HasMutexID(index1))
                            {
                                powerEntryList.Add(power2);
                                if (power3.MutexAuto)
                                    mutexAuto = true;
                            }
                            else
                            {
                                foreach (int num1 in power1.NGroupMembership)
                                {
                                    foreach (int num2 in power3.NGroupMembership)
                                    {
                                        if (num1 == num2)
                                        {
                                            powerEntryList.Add(power2);
                                            if (power3.MutexAuto)
                                                mutexAuto = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (power1.MutexAuto)
                {
                    doDetoggle = true;
                    silent = true;
                }
                if (doDetoggle && power1.MutexAuto)
                {
                    foreach (PowerEntry powerEntry in powerEntryList)
                        powerEntry.StatInclude = false;
                    eMutex = Enums.eMutex.NoConflict;
                }
                else
                {
                    if (doDetoggle && mutexAuto && this.Powers[hIdx].StatInclude)
                        this.Powers[hIdx].StatInclude = false;
                    if (!silent && powerEntryList.Count > 0)
                    {
                        string empty = string.Empty;
                        string str1 = power1.DisplayName + " is mutually exclusive and can't be used at the same time as the following powers:\n";
                        foreach (PowerEntry powerEntry in powerEntryList)
                        {
                            if (!string.IsNullOrEmpty(empty))
                                empty += ", ";
                            empty += powerEntry.Power.DisplayName;
                        }
                        string str2 = str1 + empty;
                        MessageBox.Show(!doDetoggle || !power1.MutexAuto || !this.Powers[hIdx].StatInclude ? str2 + "\n\nYou should turn off the powers listed before turning this one on." : str2 + "\n\nThe listed powers have been turned off.", "Power Conflict");
                    }
                    eMutex = powerEntryList.Count > 0 ? (!power1.MutexAuto ? (!mutexAuto ? Enums.eMutex.MutexFound : Enums.eMutex.DetoggleSlave) : Enums.eMutex.DetoggleMaster) : Enums.eMutex.NoConflict;
                }
            }
        }
        return eMutex;
    }

    public void FullMutexCheck()
    {
        for (int hIdx = this.Powers.Count - 1; hIdx >= 0; hIdx += -1)
        {
            this.MutexV2(hIdx, true, true);
        }
    }
}
