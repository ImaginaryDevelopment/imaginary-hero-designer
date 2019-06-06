using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.Display;
using Base.Master_Classes;

public class Build
{

    public IPower SetBonusVirtualPower
    {
        get
        {
            IPower power;
            if ((power = this._setBonusVirtualPower) == null)
            {
                power = (this._setBonusVirtualPower = this.GetSetBonusVirtualPower());
            }
            return power;
        }
    }


    public int PowersPlaced
    {
        get
        {
            int num = 0;
            foreach (PowerEntry power in this.Powers)
            {
                if (power.Chosen && power.Power != null)
                {
                    num++;
                }
            }
            return num;
        }
    }



    public int SlotsPlaced
    {
        get
        {
            int num = 0;
            foreach (PowerEntry power in this.Powers)
            {
                if (power.Slots.Length > 0)
                {
                    num += power.Slots.Length - 1;
                }
            }
            return num;
        }
    }



    public int TotalSlotsAvailable
    {
        get
        {
            int num = 0;
            foreach (LevelMap level in DatabaseAPI.Database.Levels)
            {
                num += level.Slots;
            }
            return num;
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


    private PowerEntry GetPowerEntry(IPower power)
    {
        foreach (PowerEntry power2 in this.Powers)
        {
            if (power2.Power != null && power2.Power.PowerIndex == power.PowerIndex)
            {
                return power2;
            }
        }
        return null;
    }


    public Build(Character owner, IList<LevelMap> iLevels)
    {
        this._character = owner;
        this.Powers = new List<PowerEntry>
        {
            new PowerEntry(0, null, true)
        };
        this.SetBonus = new List<I9SetData>();
        this.LastPower = 0;
        for (int iLevel = 0; iLevel < iLevels.Count; iLevel++)
        {
            for (int index = 0; index < iLevels[iLevel].Powers; index++)
            {
                this.Powers.Add(new PowerEntry(iLevel, null, true));
                this.LastPower++;
            }
        }
    }


    public void RemoveSlotFromPower(int index, int slot)
    {
        if (index >= 0 && index <= this.Powers.Count - 1)
        {
            if (slot >= 0 && slot <= this.Powers[index].Slots.Length - 1)
            {
                int index2 = -1;
                SlotEntry[] slotEntryArray = new SlotEntry[this.Powers[index].Slots.Length - 1];
                for (int index3 = 0; index3 <= this.Powers[index].Slots.Length - 1; index3++)
                {
                    if (index3 != slot)
                    {
                        index2++;
                        slotEntryArray[index2].Assign(this.Powers[index].Slots[index3]);
                    }
                }
                this.Powers[index].Slots = new SlotEntry[slotEntryArray.Length];
                for (int index4 = 0; index4 <= this.Powers[index].Slots.Length - 1; index4++)
                {
                    this.Powers[index].Slots[index4].Assign(slotEntryArray[index4]);
                }
            }
        }
    }


    private void FillMissingSubPowers()
    {
        foreach (PowerEntry power in this.Powers)
        {
            if (power.Power != null && power.Power.NIDSubPower.Length > 0)
            {
                if (power.SubPowers.Length != power.Power.NIDSubPower.Length)
                {
                    power.SubPowers = new PowerSubEntry[power.Power.NIDSubPower.Length];
                }
                for (int index = 0; index <= power.Power.NIDSubPower.Length - 1; index++)
                {
                    if (power.SubPowers[index].nIDPower != power.Power.NIDSubPower[index])
                    {
                        power.SubPowers[index] = new PowerSubEntry
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


    private void ValidateEnhancements()
    {
        foreach (PowerEntry power in this.Powers)
        {
            foreach (SlotEntry slot in power.Slots)
            {
                if (slot.Enhancement.Enh > -1)
                {
                    if (DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal && (slot.Enhancement.Grade <= Enums.eEnhGrade.None | slot.Enhancement.Grade > Enums.eEnhGrade.SingleO))
                    {
                        slot.Enhancement.Grade = Enums.eEnhGrade.SingleO;
                    }
                    if ((DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.SpecialO) && (slot.Enhancement.RelativeLevel < Enums.eEnhRelative.None | slot.Enhancement.RelativeLevel > Enums.eEnhRelative.PlusFive))
                    {
                        slot.Enhancement.RelativeLevel = MidsContext.Config.CalcEnhLevel;
                    }
                }
                if (slot.FlippedEnhancement.Enh > -1)
                {
                    if (DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].TypeID == Enums.eType.Normal && (slot.FlippedEnhancement.Grade <= Enums.eEnhGrade.None | slot.FlippedEnhancement.Grade > Enums.eEnhGrade.SingleO))
                    {
                        slot.FlippedEnhancement.Grade = Enums.eEnhGrade.SingleO;
                    }
                    if ((DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].TypeID == Enums.eType.Normal | DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].TypeID == Enums.eType.SpecialO) && (slot.FlippedEnhancement.RelativeLevel < Enums.eEnhRelative.None | slot.FlippedEnhancement.RelativeLevel > Enums.eEnhRelative.PlusFive))
                    {
                        slot.FlippedEnhancement.RelativeLevel = MidsContext.Config.CalcEnhLevel;
                    }
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
        bool flag;
        if (MessageBox.Show(string.Format("Really set all placed Regular enhancements to {0} Origin?\n\nThis will not affect any Invention or Special enhancements.", str), "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            foreach (PowerEntry power in this.Powers)
            {
                foreach (SlotEntry slot in power.Slots)
                {
                    if (slot.Enhancement.Enh > -1 && DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].TypeID == Enums.eType.Normal)
                    {
                        slot.Enhancement.Grade = newVal;
                    }
                }
            }
            flag = true;
        }
        else
        {
            flag = false;
        }
        return flag;
    }


    public bool SetIOLevels(int newVal, bool iSetMin, bool iSetMax)
    {
        string text;
        if (!iSetMin & !iSetMax)
        {
            text = string.Concat(new object[]
            {
                "Really set all placed Invention and Set enhancements to level ",
                newVal,
                1,
                "?\n\nNote: Enahncements which are not available at the default level will be set to the closest value."
            });
        }
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
        bool flag;
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
                                {
                                    int levelMin2 = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].LevelMin;
                                    int num = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].LevelMax;
                                    if (newVal >= levelMin2 & newVal <= num)
                                    {
                                        slot.Enhancement.IOLevel = Enhancement.GranularLevelZb(newVal, levelMin2, num, 5);
                                    }
                                    else if (newVal > num)
                                    {
                                        slot.Enhancement.IOLevel = Enhancement.GranularLevelZb(num, levelMin2, num, 5);
                                    }
                                    else if (newVal < levelMin2)
                                    {
                                        slot.Enhancement.IOLevel = Enhancement.GranularLevelZb(levelMin2, levelMin2, num, 5);
                                    }
                                    break;
                                }
                            case Enums.eType.SetO:
                                {
                                    int levelMin2 = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].nIDSet].LevelMin;
                                    int num = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].nIDSet].LevelMax;
                                    if (num > 49)
                                    {
                                        num = 49;
                                    }
                                    if (newVal >= levelMin2 & newVal <= num)
                                    {
                                        slot.Enhancement.IOLevel = newVal;
                                    }
                                    else if (newVal > num)
                                    {
                                        slot.Enhancement.IOLevel = num;
                                    }
                                    else if (newVal < levelMin2)
                                    {
                                        slot.Enhancement.IOLevel = levelMin2;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            flag = true;
        }
        else
        {
            flag = false;
        }
        return flag;
    }


    public HistoryMap[] BuildHistoryMap(bool enhNames, bool ioLevel = true)
    {
        List<HistoryMap> historyMapList = new List<HistoryMap>();
        for (int index = 0; index <= DatabaseAPI.Database.Levels.Length - 1; index++)
        {
            for (int index2 = 0; index2 <= this.Powers.Count - 1; index2++)
            {
                PowerEntry power = this.Powers[index2];
                if ((power.Chosen || power.SubPowers.Length == 0 || power.SlotCount == 0) && (power.Level == index & power.Power != null))
                {
                    HistoryMap historyMap = new HistoryMap
                    {
                        Level = index,
                        HID = index2
                    };
                    string str = string.Empty;
                    string str2 = power.Chosen ? "Added" : "Recieved";
                    if (power.Slots.Length > 0)
                    {
                        historyMap.SID = 0;
                        if (power.Slots[0].Enhancement.Enh > -1)
                        {
                            if (enhNames)
                            {
                                str = " [" + DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[0].Enhancement.Enh);
                            }
                            if (ioLevel && (DatabaseAPI.Database.Enhancements[power.Slots[0].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[0].Enhancement.Enh].TypeID == Enums.eType.SetO))
                            {
                                str = str + "-" + power.Slots[0].Enhancement.IOLevel;
                            }
                            str += "]";
                        }
                        else if (enhNames)
                        {
                            str = " [Empty]";
                        }
                    }
                    historyMap.Text = string.Concat(new object[]
                    {
                        "Level ",
                        index + 1,
                        ": ",
                        str2,
                        " ",
                        power.Power.DisplayName,
                        " (",
                        Enum.GetName(DatabaseAPI.Database.Powersets[power.NIDPowerset].SetType.GetType(), DatabaseAPI.Database.Powersets[power.NIDPowerset].SetType),
                        ")",
                        str
                    });
                    historyMapList.Add(historyMap);
                }
            }
            for (int index3 = 0; index3 <= this.Powers.Count - 1; index3++)
            {
                PowerEntry power2 = this.Powers[index3];
                for (int index4 = 1; index4 <= power2.Slots.Length - 1; index4++)
                {
                    if (power2.Slots[index4].Level == index)
                    {
                        HistoryMap historyMap2 = new HistoryMap
                        {
                            Level = index,
                            HID = index3,
                            SID = index4
                        };
                        string str = string.Empty;
                        if (power2.Slots[index4].Enhancement.Enh > -1)
                        {
                            if (enhNames)
                            {
                                str = " [" + DatabaseAPI.GetEnhancementNameShortWSet(power2.Slots[index4].Enhancement.Enh);
                            }
                            if (ioLevel && (DatabaseAPI.Database.Enhancements[power2.Slots[index4].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power2.Slots[index4].Enhancement.Enh].TypeID == Enums.eType.SetO))
                            {
                                str = str + "-" + power2.Slots[index4].Enhancement.IOLevel;
                            }
                            str += "]";
                        }
                        else if (enhNames)
                        {
                            str = " [Empty]";
                        }
                        historyMap2.Text = string.Concat(new object[]
                        {
                            "Level ",
                            index + 1,
                            ": Added Slot to ",
                            power2.Power.DisplayName,
                            str
                        });
                        historyMapList.Add(historyMap2);
                    }
                }
            }
        }
        return historyMapList.ToArray();
    }


    private int SlotsAtLevel(int powerEntryId, int iLevel)
    {
        int num;
        if (powerEntryId < 0)
        {
            num = 0;
        }
        else
        {
            int num2 = 0;
            foreach (SlotEntry slot in this.Powers[powerEntryId].Slots)
            {
                if (slot.Level <= iLevel)
                {
                    num2++;
                }
            }
            num = num2;
        }
        return num;
    }


    public int SlotsPlacedAtLevel(int level)
    {
        int num = 0;
        for (int index = 0; index < this.Powers.Count; index++)
        {
            for (int index2 = 0; index2 < this.Powers[index].Slots.Length; index2++)
            {
                if (this.Powers[index].Slots[index2].Level == level)
                {
                    num++;
                }
            }
        }
        return num;
    }


    public PopUp.PopupData GetRespecHelper(bool longFormat, int iLevel = 49)
    {
        PopUp.PopupData popupData = default(PopUp.PopupData);
        HistoryMap[] historyMapArray = this.BuildHistoryMap(true, true);
        int index2 = popupData.Add(null);
        popupData.Sections[index2].Add("Respec to level: " + (iLevel + 1), PopUp.Colors.Effect, 1.25f, FontStyle.Bold, 0);
        foreach (HistoryMap historyMap in historyMapArray)
        {
            if (historyMap.HID > -1 && DatabaseAPI.Database.Levels[historyMap.Level].Powers > 0 && historyMap.Level <= iLevel)
            {
                PowerEntry power = this.Powers[historyMap.HID];
                if (power.Slots.Length > 0)
                {
                    index2 = popupData.Add(null);
                    string str;
                    if (power.Power != null)
                    {
                        str = string.Concat(new object[]
                        {
                            "Level ",
                            historyMap.Level + 1,
                            ": ",
                            power.Power.DisplayName
                        });
                    }
                    else
                    {
                        str = "Level " + (historyMap.Level + 1) + ": [Empty]";
                    }
                    popupData.Sections[index2].Add(str, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                    int num = this.SlotsAtLevel(historyMap.HID, iLevel);
                    if (num > 0)
                    {
                        popupData.Sections[index2].Add("Slots: " + num, PopUp.Colors.Text, 1f, FontStyle.Regular, 1);
                        if (longFormat)
                        {
                            for (int index3 = 0; index3 <= num - 1; index3++)
                            {
                                if (index3 == 0)
                                {
                                    str = "(A) ";
                                }
                                else
                                {
                                    str = "(" + (power.Slots[index3].Level + 1) + ") ";
                                }
                                if (power.Slots[index3].Enhancement.Enh > -1)
                                {
                                    str += DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[index3].Enhancement.Enh);
                                    if (DatabaseAPI.Database.Enhancements[power.Slots[index3].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[index3].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                    {
                                        str = str + "-" + (power.Slots[index3].Enhancement.IOLevel + 1);
                                    }
                                }
                                else
                                {
                                    str += "[Empty]";
                                }
                                popupData.Sections[index2].Add(str, PopUp.Colors.Invention, 1f, FontStyle.Regular, 2);
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
        PopUp.PopupData popupData = default(PopUp.PopupData);
        HistoryMap[] historyMapArray = this.BuildHistoryMap(true, true);
        int index = popupData.Add(null);
        popupData.Sections[index].Add("Respec to level: " + (iLevel + 1), PopUp.Colors.Effect, 1.25f, FontStyle.Bold, 0);
        int num = 0;
        foreach (HistoryMap historyMap in historyMapArray)
        {
            if (num != historyMap.Level)
            {
                index = popupData.Add(null);
            }
            num = historyMap.Level;
            if (historyMap.HID >= 0)
            {
                PowerEntry power = this.Powers[historyMap.HID];
                if (DatabaseAPI.Database.Levels[historyMap.Level].Powers > 0 & historyMap.Level <= iLevel)
                {
                    if (power.Slots.Length > 0)
                    {
                        string iText2;
                        if (power.Power != null)
                        {
                            iText2 = string.Concat(new object[]
                            {
                                "Level ",
                                historyMap.Level + 1,
                                ": ",
                                power.Power.DisplayName
                            });
                        }
                        else
                        {
                            iText2 = "Level " + (historyMap.Level + 1) + ": [Empty]";
                        }
                        popupData.Sections[index].Add(iText2, PopUp.Colors.Text, 1f, FontStyle.Bold, 0);
                        if (longFormat)
                        {
                            iText2 = string.Empty;
                            if (power.Slots[historyMap.SID].Enhancement.Enh > -1)
                            {
                                iText2 += DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[historyMap.SID].Enhancement.Enh);
                                if (DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.SetO)
                                {
                                    iText2 = iText2 + "-" + (power.Slots[historyMap.SID].Enhancement.IOLevel + 1);
                                }
                            }
                            else
                            {
                                iText2 += "[Empty]";
                            }
                            popupData.Sections[index].Add(iText2, PopUp.Colors.Invention, 1f, FontStyle.Regular, 1);
                        }
                    }
                }
                else if ((DatabaseAPI.Database.Levels[historyMap.Level].Slots > 0 & historyMap.Level <= iLevel) && historyMap.SID > -1)
                {
                    string iText2;
                    if (historyMap.SID == 0)
                    {
                        iText2 = "Level " + (historyMap.Level + 1) + ": Received Slot - ";
                    }
                    else
                    {
                        iText2 = "Level " + (historyMap.Level + 1) + ": Added Slot To ";
                    }
                    if (power.Power != null)
                    {
                        iText2 += power.Power.DisplayName;
                    }
                    else
                    {
                        iText2 += "[Empty]";
                    }
                    popupData.Sections[index].Add(iText2, PopUp.Colors.Effect, 1f, FontStyle.Bold, 0);
                    if (longFormat)
                    {
                        iText2 = string.Empty;
                        if (power.Slots[historyMap.SID].Enhancement.Enh > -1)
                        {
                            iText2 += DatabaseAPI.GetEnhancementNameShortWSet(power.Slots[historyMap.SID].Enhancement.Enh);
                            if (DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.InventO || DatabaseAPI.Database.Enhancements[power.Slots[historyMap.SID].Enhancement.Enh].TypeID == Enums.eType.SetO)
                            {
                                iText2 = iText2 + "-" + (power.Slots[historyMap.SID].Enhancement.IOLevel + 1);
                            }
                        }
                        else
                        {
                            iText2 += "[Empty]";
                        }
                        popupData.Sections[index].Add(iText2, PopUp.Colors.Invention, 1f, FontStyle.Regular, 1);
                    }
                }
            }
        }
        return popupData;
    }


    public bool SetEnhRelativelevels(Enums.eEnhRelative newVal)
    {
        string str = string.Empty;
        switch (newVal)
        {
            case Enums.eEnhRelative.None:
                str = "None (Enhancements will have no effect)";
                break;
            case Enums.eEnhRelative.MinusThree:
                str = "-3";
                break;
            case Enums.eEnhRelative.MinusTwo:
                str = "-2";
                break;
            case Enums.eEnhRelative.MinusOne:
                str = "-1";
                break;
            case Enums.eEnhRelative.Even:
                str = "Even (+/- 0)";
                break;
            case Enums.eEnhRelative.PlusOne:
                str = "+1";
                break;
            case Enums.eEnhRelative.PlusTwo:
                str = "+2";
                break;
            case Enums.eEnhRelative.PlusThree:
                str = "+3";
                break;
            case Enums.eEnhRelative.PlusFour:
                str = "+4";
                break;
            case Enums.eEnhRelative.PlusFive:
                str = "+5";
                break;
        }
        bool flag;
        if (MessageBox.Show(string.Format("Really set all placed enhancements to a relative level of {0}?\n\nNote: Normal and Special enhancements cannot go above +3, and Inventions cannot go below +0.", str), "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            foreach (PowerEntry power in this.Powers)
            {
                foreach (SlotEntry slot in power.Slots)
                {
                    if (slot.Enhancement.Enh > -1)
                    {
                        IEnhancement enhancement = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh];
                        if (newVal > Enums.eEnhRelative.PlusThree)
                        {
                            if (enhancement.TypeID == Enums.eType.Normal || enhancement.TypeID == Enums.eType.SpecialO)
                            {
                                slot.Enhancement.RelativeLevel = Enums.eEnhRelative.PlusThree;
                            }
                            else
                            {
                                slot.Enhancement.RelativeLevel = newVal;
                            }
                        }
                        else if (newVal < Enums.eEnhRelative.Even)
                        {
                            if (enhancement.TypeID == Enums.eType.Normal || enhancement.TypeID == Enums.eType.SpecialO)
                            {
                                slot.Enhancement.RelativeLevel = newVal;
                            }
                            else
                            {
                                slot.Enhancement.RelativeLevel = Enums.eEnhRelative.Even;
                            }
                        }
                        else
                        {
                            slot.Enhancement.RelativeLevel = newVal;
                        }
                    }
                }
            }
            flag = true;
        }
        else
        {
            flag = false;
        }
        return flag;
    }


    private void CheckAndFixAllEnhancements()
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
                        {
                            slot.Enhancement.Enh = -1;
                        }
                        else
                        {
                            slot.Enhancement.IOLevel = DatabaseAPI.Database.Enhancements[slot.Enhancement.Enh].CheckAndFixIOLevel(slot.Enhancement.IOLevel);
                        }
                    }
                    if (slot.FlippedEnhancement.Enh > -1)
                    {
                        if (!power.Power.IsEnhancementValid(slot.FlippedEnhancement.Enh))
                        {
                            slot.FlippedEnhancement.Enh = -1;
                        }
                        else
                        {
                            slot.FlippedEnhancement.IOLevel = DatabaseAPI.Database.Enhancements[slot.FlippedEnhancement.Enh].CheckAndFixIOLevel(slot.FlippedEnhancement.IOLevel);
                        }
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


    private void CheckAllVariableBounds()
    {
        for (int index = 0; index <= this.Powers.Count - 1; index++)
        {
            this.Powers[index].CheckVariableBounds();
        }
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
        int num = 0;
        foreach (PowerEntry power in this.Powers)
        {
            if (power.Level > num)
            {
                num = power.Level;
            }
            foreach (SlotEntry slot in power.Slots)
            {
                if (slot.Level > num)
                {
                    num = slot.Level;
                }
            }
        }
        return num;
    }


    private void ClearInvisibleSlots()
    {
        foreach (PowerEntry power in this.Powers)
        {
            if (power.SlotCount > 0 && ((power.Power == null && !power.Chosen) || (power.Power != null && !power.Power.Slottable)))
            {
                power.Slots = new SlotEntry[0];
            }
            else if (power.SlotCount > 6)
            {
                Array.Resize<SlotEntry>(ref power.Slots, 6);
            }
        }
    }


    private void ScanAndCleanAutomaticallyGrantedPowers()
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
                {
                    power.Level = power.Power.Level - 1;
                }
            }
        }
        if (flag)
        {
            int index = 0;
            while (index < this.Powers.Count)
            {
                if (this.Powers[index].Tag)
                {
                    this.Powers[index].Reset();
                    if (!this.Powers[index].Chosen)
                    {
                        this.Powers[index].Level = -1;
                        this.Powers[index].Slots = new SlotEntry[0];
                    }
                }
                else
                {
                    index++;
                }
            }
        }
    }


    public bool MeetsRequirement(IPower power, int nLevel, int skipIdx = -1)
    {
        bool flag;
        if (nLevel < 0)
        {
            flag = false;
        }
        else
        {
            int num = -1;
            if (skipIdx > -1 & skipIdx < this.Powers.Count)
            {
                num = ((this.Powers[skipIdx].Power == null) ? -1 : this.Powers[skipIdx].Power.PowerIndex);
            }
            if (nLevel + 1 < power.Level)
            {
                flag = false;
            }
            else if (power.Requires.NClassName.Length == 0 & power.Requires.NClassNameNot.Length == 0 & power.Requires.NPowerID.Length == 0 & power.Requires.NPowerIDNot.Length == 0)
            {
                flag = true;
            }
            else
            {
                bool flag2 = power.Requires.NClassName.Length == 0;
                foreach (int num2 in power.Requires.NClassName)
                {
                    if (MidsContext.Character.Archetype.Idx == num2)
                    {
                        flag2 = true;
                    }
                }
                foreach (int num3 in power.Requires.NClassNameNot)
                {
                    if (MidsContext.Character.Archetype.Idx == num3)
                    {
                        flag2 = false;
                    }
                }
                if (!flag2)
                {
                    flag = false;
                }
                else
                {
                    if (power.Requires.NPowerID.Length > 0)
                    {
                        flag2 = false;
                    }
                    foreach (var numArray in power.Requires.NPowerID)
                    {
                        bool flag3 = true;
                        foreach (var nIDPower in numArray)
                        {
                            if (nIDPower > -1)
                            {
                                int index = -1;
                                if (nIDPower != num)
                                {
                                    index = this.FindInToonHistory(nIDPower);
                                }
                                if (index < 0)
                                {
                                    flag3 = false;
                                }
                                else if (this.Powers[index].Level > nLevel)
                                {
                                    flag3 = false;
                                }
                            }
                        }
                        if (flag3)
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        flag = false;
                    }
                    else
                    {
                        foreach (var numArray2 in power.Requires.NPowerIDNot)
                        {
                            bool flag4 = true;
                            foreach (var nIDPower2 in numArray2)
                            {
                                if (nIDPower2 > -1)
                                {
                                    int num4 = -1;
                                    if (nIDPower2 != num)
                                    {
                                        num4 = this.FindInToonHistory(nIDPower2);
                                    }
                                    if (num4 > -1)
                                    {
                                        flag4 = false;
                                    }
                                }
                            }
                            if (!flag4)
                            {
                                flag2 = false;
                                break;
                            }
                        }
                        flag = flag2;
                    }
                }
            }
        }
        return flag;
    }


    public int FindInToonHistory(int nIDPower)
    {
        for (int index = 0; index <= this.Powers.Count - 1; index++)
        {
            if (this.Powers[index].Power != null && this.Powers[index].Power.PowerIndex == nIDPower)
            {
                return index;
            }
        }
        return -1;
    }


    public bool PowerUsed(IPower power)
    {
        return this.FindInToonHistory(power.PowerIndex) > -1;
    }


    private void AddAutomaticGrantedPowers()
    {
        int maxLevel = this.GetMaxLevel();
        List<IPowerset> powersetList = new List<IPowerset>();
        powersetList.AddRange(this._character.Powersets);
        foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
        {
            if (powerset.SetType == Enums.ePowerSetType.Inherent && !powersetList.Contains(powerset))
            {
                powersetList.Add(powerset);
            }
        }
        foreach (IPowerset powerset2 in powersetList)
        {
            if (powerset2 != null)
            {
                foreach (IPower power in powerset2.Powers)
                {
                    int val2 = 0;
                    if (power.IncludeFlag && power.Level <= maxLevel + 1 && !this.PowerUsed(power) && this.MeetsRequirement(power, maxLevel + 1, -1))
                    {
                        if (power.Requires.NPowerID.Length > 0)
                        {
                            int inToonHistory = this.FindInToonHistory(power.Requires.NPowerID[0][0]);
                            if (inToonHistory > -1)
                            {
                                val2 = this.Powers[inToonHistory].Level;
                            }
                        }
                        this.AddPower(power, Math.Max(power.Level - 1, val2));
                    }
                }
            }
        }
    }


    public bool EnhancementTest(int iSlotID, int hIdx, int iEnh, bool silent = false)
    {
        bool flag;
        if (iEnh < 0 | iSlotID < 0)
        {
            flag = false;
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
                flag5 = true;
                Enums.eSetType setType = DatabaseAPI.Database.EnhancementSets[enhancement.nIDSet].SetType;
                for (int index = 0; index <= this.Powers[hIdx].Power.SetTypes.Length - 1; index++)
                {
                    if (this.Powers[hIdx].Power.SetTypes[index] == setType)
                    {
                        flag5 = false;
                        break;
                    }
                }
            }
            if (flag5)
            {
                flag = false;
            }
            else
            {
                for (int index2 = 0; index2 <= this.Powers.Count - 1; index2++)
                {
                    for (int index3 = 0; index3 <= this.Powers[index2].Slots.Length - 1; index3++)
                    {
                        if ((index3 != iSlotID || index2 != hIdx) && this.Powers[index2].Slots[index3].Enhancement.Enh > -1)
                        {
                            if (enhancement.Unique && this.Powers[index2].Slots[index3].Enhancement.Enh == iEnh)
                            {
                                flag2 = true;
                                break;
                            }
                            if (enhancement.MutExID != Enums.eEnhMutex.None && DatabaseAPI.Database.Enhancements[this.Powers[index2].Slots[index3].Enhancement.Enh].MutExID == enhancement.MutExID)
                            {
                                flag3 = true;
                                break;
                            }
                            if (enhancement.nIDSet > -1 && index2 == hIdx && this.Powers[index2].Slots[index3].Enhancement.Enh == iEnh)
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
                        MessageBox.Show(enhancement.LongName + " is a unique enhancement. You can only slot one of these across your entire build.", "Can't Slot Enhancement");
                    }
                    flag = false;
                }
                else if (flag3)
                {
                    if (!silent)
                    {
                        MessageBox.Show(enhancement.LongName + " is mutually exclusive with enhancements in the " + Enum.GetName(enhancement.MutExID.GetType(), enhancement.MutExID) + " group. You can only slot one member of this group across your entire build.", "Can't Slot Enhancement");
                    }
                    flag = false;
                }
                else if (flag4)
                {
                    if (!silent)
                    {
                        MessageBox.Show(enhancement.LongName + " is already slotted in this power. You can only slot one of each enhancement from the set in a given power.", "Can't Slot Enhancement");
                    }
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
        }
        return flag;
    }


    public void GenerateSetBonusData()
    {
        this.SetBonus.Clear();
        for (int index = 0; index < this.Powers.Count; index++)
        {
            I9SetData i9SetData = new I9SetData
            {
                PowerIndex = index
            };
            if (this.Powers[index].Level <= MidsContext.Config.ForceLevel)
            {
                for (int index2 = 0; index2 < this.Powers[index].SlotCount; index2++)
                {
                    i9SetData.Add(ref this.Powers[index].Slots[index2].Enhancement);
                }
            }
            i9SetData.BuildEffects(MidsContext.Config.Inc.PvE ? Enums.ePvX.PvE : Enums.ePvX.PvP);
            if (!i9SetData.Empty)
            {
                this.SetBonus.Add(i9SetData);
            }
        }
        this._setBonusVirtualPower = null;
    }


    private IPower GetSetBonusVirtualPower()
    {
        IPower power = new Power();
        IPower power2;
        if (!MidsContext.Config.I9.CalculateSetBonusFX)
        {
            power2 = power;
        }
        else
        {
            int[] numArray = new int[DatabaseAPI.NidPowers("set_bonus", "").Length];
            for (int index = 0; index < numArray.Length; index++)
            {
                numArray[index] = 0;
            }
            List<IEffect> effectList = new List<IEffect>();
            for (int index2 = 0; index2 < this.SetBonus.Count; index2++)
            {
                for (int index3 = 0; index3 < this.SetBonus[index2].SetInfo.Length; index3++)
                {
                    for (int index4 = 0; index4 < this.SetBonus[index2].SetInfo[index3].Powers.Length; index4++)
                    {
                        if (this.SetBonus[index2].SetInfo[index3].Powers[index4] > -1)
                        {
                            numArray[this.SetBonus[index2].SetInfo[index3].Powers[index4]]++;
                            if (numArray[this.SetBonus[index2].SetInfo[index3].Powers[index4]] < 6)
                            {
                                for (int index5 = 0; index5 < DatabaseAPI.Database.Power[this.SetBonus[index2].SetInfo[index3].Powers[index4]].Effects.Length; index5++)
                                {
                                    effectList.Add((IEffect)DatabaseAPI.Database.Power[this.SetBonus[index2].SetInfo[index3].Powers[index4]].Effects[index5].Clone());
                                }
                            }
                        }
                    }
                }
            }
            power.Effects = effectList.ToArray();
            power2 = power;
        }
        return power2;
    }


    public IEffect[] GetCumulativeSetBonuses()
    {
        IPower bonusVirtualPower = this.SetBonusVirtualPower;
        IEffect[] array = new IEffect[0];
        for (int index = 0; index < bonusVirtualPower.Effects.Length; index++)
        {
            if (bonusVirtualPower.Effects[index].EffectType != Enums.eEffectType.None || !string.IsNullOrEmpty(bonusVirtualPower.Effects[index].Special))
            {
                int index2 = Build.GcsbCheck(array, bonusVirtualPower.Effects[index]);
                if (index2 < 0)
                {
                    Array.Resize<IEffect>(ref array, array.Length + 1);
                    index2 = array.Length - 1;
                    array[index2] = (IEffect)bonusVirtualPower.Effects[index].Clone();
                    array[index2].Math_Mag = bonusVirtualPower.Effects[index].Mag;
                }
                else
                {
                    array[index2].Math_Mag += bonusVirtualPower.Effects[index].Mag;
                }
            }
        }
        return array;
    }


    private static int GcsbCheck(IEffect[] fxList, IEffect testFX)
    {
        for (int index = 0; index < fxList.Length; index++)
        {
            if (fxList[index].EffectType == testFX.EffectType && ((fxList[index].Mag > 0f & testFX.Mag > 0f) || (fxList[index].Mag < 0f & testFX.Mag < 0f) || (double)Math.Abs(fxList[index].Mag - (float)((testFX.Mag > 0f) ? 1 : 0)) < 0.001))
            {
                int num;
                if (((testFX.EffectType == Enums.eEffectType.Mez || testFX.EffectType == Enums.eEffectType.MezResist) && fxList[index].MezType == testFX.MezType) || (testFX.EffectType == Enums.eEffectType.Damage && testFX.DamageType == fxList[index].DamageType) || (testFX.EffectType == Enums.eEffectType.Defense && testFX.DamageType == fxList[index].DamageType) || (testFX.EffectType == Enums.eEffectType.Resistance && testFX.DamageType == fxList[index].DamageType) || (testFX.EffectType == Enums.eEffectType.DamageBuff && testFX.DamageType == fxList[index].DamageType) || (testFX.EffectType == Enums.eEffectType.Enhancement && testFX.ETModifies == fxList[index].ETModifies && testFX.DamageType == fxList[index].DamageType && testFX.MezType == fxList[index].MezType) || (testFX.EffectType == Enums.eEffectType.ResEffect && testFX.ETModifies == fxList[index].ETModifies) || (testFX.EffectType == Enums.eEffectType.None && testFX.Special == fxList[index].Special && testFX.Special.IndexOf("DEBT", StringComparison.OrdinalIgnoreCase) > -1))
                {
                    num = index;
                }
                else
                {
                    if (!(testFX.EffectType != Enums.eEffectType.Mez & testFX.EffectType != Enums.eEffectType.MezResist & testFX.EffectType != Enums.eEffectType.Damage & testFX.EffectType != Enums.eEffectType.Defense & testFX.EffectType != Enums.eEffectType.Resistance & testFX.EffectType != Enums.eEffectType.DamageBuff & testFX.EffectType != Enums.eEffectType.Enhancement & testFX.EffectType != Enums.eEffectType.ResEffect & testFX.EffectType == fxList[index].EffectType))
                    {
                        goto IL_258;
                    }
                    num = index;
                }
                return num;
            }
        IL_258:;
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
            IPower power = this.Powers[hIdx].Power;
            if (power.MutexIgnore)
            {
                eMutex = Enums.eMutex.NoGroup;
            }
            else
            {
                List<PowerEntry> powerEntryList = new List<PowerEntry>();
                bool flag = false;
                int index = -1;
                for (int index2 = 0; index2 <= DatabaseAPI.Database.MutexList.Length - 1; index2++)
                {
                    if (string.Equals(DatabaseAPI.Database.MutexList[index2], "KHELDIAN_GROUP", StringComparison.OrdinalIgnoreCase))
                    {
                        index = index2;
                        break;
                    }
                }
                bool flag2 = power.HasMutexID(index);
                foreach (PowerEntry power2 in this.Powers)
                {
                    if (power2.Power != null && power2.Power.PowerIndex != power.PowerIndex)
                    {
                        IPower power3 = power2.Power;
                        if (power2.StatInclude && !power3.MutexIgnore)
                        {
                            if (flag2 || ((power3.PowerType != Enums.ePowerType.Click || power3.PowerName == "Light_Form") && power3.HasMutexID(index)))
                            {
                                powerEntryList.Add(power2);
                                if (power3.MutexAuto)
                                {
                                    flag = true;
                                }
                            }
                            else
                            {
                                foreach (int num in power.NGroupMembership)
                                {
                                    foreach (int num2 in power3.NGroupMembership)
                                    {
                                        if (num == num2)
                                        {
                                            powerEntryList.Add(power2);
                                            if (power3.MutexAuto)
                                            {
                                                flag = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (power.MutexAuto)
                {
                    doDetoggle = true;
                    silent = true;
                }
                if (doDetoggle && power.MutexAuto)
                {
                    foreach (PowerEntry powerEntry in powerEntryList)
                    {
                        powerEntry.StatInclude = false;
                    }
                    eMutex = Enums.eMutex.NoConflict;
                }
                else
                {
                    if (doDetoggle && flag && this.Powers[hIdx].StatInclude)
                    {
                        this.Powers[hIdx].StatInclude = false;
                    }
                    if (!silent && powerEntryList.Count > 0)
                    {
                        string empty = string.Empty;
                        string str2 = power.DisplayName + " is mutually exclusive and can't be used at the same time as the following powers:\n";
                        foreach (PowerEntry powerEntry2 in powerEntryList)
                        {
                            if (!string.IsNullOrEmpty(empty))
                            {
                                empty += ", ";
                            }
                            empty += powerEntry2.Power.DisplayName;
                        }
                        str2 += empty;
                        if (doDetoggle && power.MutexAuto && this.Powers[hIdx].StatInclude)
                        {
                            str2 += "\n\nThe listed powers have been turned off.";
                        }
                        else
                        {
                            str2 += "\n\nYou should turn off the powers listed before turning this one on.";
                        }
                        MessageBox.Show(str2, "Power Conflict");
                    }
                    if (powerEntryList.Count <= 0)
                    {
                        eMutex = Enums.eMutex.NoConflict;
                    }
                    else if (power.MutexAuto)
                    {
                        eMutex = Enums.eMutex.DetoggleMaster;
                    }
                    else if (flag)
                    {
                        eMutex = Enums.eMutex.DetoggleSlave;
                    }
                    else
                    {
                        eMutex = Enums.eMutex.MutexFound;
                    }
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


    private readonly Character _character;


    public readonly List<PowerEntry> Powers;


    public readonly List<I9SetData> SetBonus;


    private IPower _setBonusVirtualPower;


    public int LastPower;
}
