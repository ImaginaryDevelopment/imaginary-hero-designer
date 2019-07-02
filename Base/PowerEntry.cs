
using Base.Display;
using HeroDesigner.Schema;
using System;
using System.Drawing;

public class PowerEntry : ICloneable
{
    public int Level;
    public int NIDPowerset;
    public int IDXPower;
    public int NIDPower;
    public bool Tag;
    public bool StatInclude;
    public int VariableValue;
    public SlotEntry[] Slots;
    public PowerSubEntry[] SubPowers;

    public bool Chosen { get; private set; }

    public ePowerState State
    {
        get
        {
            return this.Power == null ? (this.Chosen ? ePowerState.Empty : ePowerState.Disabled) : ePowerState.Used;
        }
    }

    public IPower Power
    {
        get
        {
            return this.NIDPower >= 0 && this.NIDPower <= DatabaseAPI.Database.Power.Length - 1 ? DatabaseAPI.Database.Power[this.NIDPower] : null;
        }
    }

    public IPowerset PowerSet
    {
        get
        {
            return this.Power != null ? DatabaseAPI.Database.Powersets[this.Power.PowerSetID] : null;
        }
    }

    public bool AllowFrontLoading
    {
        get
        {
            return this.Power != null && this.Power.AllowFrontLoading;
        }
    }

    public string Name
    {
        get
        {
            return this.Power != null ? this.Power.DisplayName : "";
        }
    }

    public bool Virtual
    {
        get
        {
            return !this.Chosen && this.SubPowers.Length > 0;
        }
    }

    public int SlotCount
    {
        get
        {
            return this.Slots == null ? 0 : this.Slots.Length;
        }
    }

    public void Assign(PowerEntry iPe)
    {
        this.Level = iPe.Level;
        this.NIDPowerset = iPe.NIDPowerset;
        this.IDXPower = iPe.IDXPower;
        this.NIDPower = iPe.NIDPower;
        this.Tag = iPe.Tag;
        this.StatInclude = iPe.StatInclude;
        this.VariableValue = iPe.VariableValue;
        if (iPe.Slots != null)
        {
            this.Slots = new SlotEntry[iPe.Slots.Length];
            for (int index = 0; index <= this.Slots.Length - 1; ++index)
                this.Slots[index].Assign(iPe.Slots[index]);
        }
        else
            this.Slots = new SlotEntry[0];
        if (iPe.SubPowers != null)
        {
            this.SubPowers = new PowerSubEntry[iPe.SubPowers.Length];
            for (int index = 0; index <= this.SubPowers.Length - 1; ++index)
                this.SubPowers[index].Assign(iPe.SubPowers[index]);
        }
        else
            this.SubPowers = new PowerSubEntry[0];
    }

    public PowerEntry(IPower power)
    {
        this.StatInclude = false;
        this.Level = -1;
        if (power == null)
        {
            this.IDXPower = -1;
            this.NIDPowerset = -1;
            this.NIDPower = -1;
        }
        else
        {
            this.IDXPower = power.PowerSetIndex;
            this.NIDPower = power.PowerIndex;
            this.NIDPowerset = power.PowerSetID;
        }
        this.Tag = false;
        this.Slots = new SlotEntry[0];
        this.SubPowers = new PowerSubEntry[0];
        this.VariableValue = 0;
    }

    public PowerEntry(int iLevel = -1, IPower power = null, bool chosen = false)
    {
        this.StatInclude = false;
        this.Level = iLevel;
        this.Chosen = chosen;
        if (power != null)
        {
            this.NIDPowerset = power.PowerSetID;
            this.IDXPower = power.PowerSetIndex;
            this.NIDPower = power.PowerIndex;
            if (power.NIDSubPower.Length > 0)
            {
                this.SubPowers = new PowerSubEntry[power.NIDSubPower.Length];
                for (int index = 0; index <= this.SubPowers.Length - 1; ++index)
                {
                    this.SubPowers[index] = new PowerSubEntry()
                    {
                        nIDPower = power.NIDSubPower[index]
                    };
                    this.SubPowers[index].Powerset = DatabaseAPI.Database.Power[this.SubPowers[index].nIDPower].PowerSetID;
                    this.SubPowers[index].Power = DatabaseAPI.Database.Power[this.SubPowers[index].nIDPower].PowerSetIndex;
                }
            }
            else
                this.SubPowers = new PowerSubEntry[0];
            if (power.Slottable & power.GetPowerSet().GroupName != "Incarnate")
            {
                this.Slots = new SlotEntry[1];
                this.Slots[0].Enhancement = new I9Slot();
                this.Slots[0].FlippedEnhancement = new I9Slot();
                this.Slots[0].Level = iLevel;
            }
            else
                this.Slots = new SlotEntry[0];
            if (power.AlwaysToggle | power.PowerType == ePowerType.Auto_)
                this.StatInclude = true;
        }
        else
        {
            this.IDXPower = -1;
            this.NIDPowerset = -1;
            this.NIDPower = -1;
            this.Slots = new SlotEntry[0];
            this.SubPowers = new PowerSubEntry[0];
        }
        this.Tag = false;
        this.VariableValue = 0;
    }

    public bool HasProc()
    {
        for (int index1 = 0; index1 <= this.SlotCount - 1; ++index1)
        {
            if (this.Slots[index1].Enhancement.Enh < 0) continue;
            var enh = DatabaseAPI.Database.Enhancements[this.Slots[index1].Enhancement.Enh];
            var power = enh.GetPower();
            if (DatabaseAPI.Database.Enhancements[this.Slots[index1].Enhancement.Enh].Effect.Length > 0 && power != null)
            {
                for (int index2 = 0; index2 < power.Effects.Length; ++index2)
                {
                    int num;
                    switch (power.Effects[index2].EffectType)
                    {
                        case eEffectType.None:
                        case eEffectType.Damage:
                        case eEffectType.DamageBuff:
                        case eEffectType.Enhancement:
                        case eEffectType.Heal:
                            num = 1;
                            break;
                        case eEffectType.Mez:
                            if ((double)power.Effects[index2].Mag > 0.0)
                                goto case eEffectType.None;
                            else
                                goto default;
                        default:
                            num = power.Effects[index2].ToWho == eToWho.Target ? 1 : 0;
                            break;
                    }
                    if (num == 0)
                        return true;
                }
            }
        }
        return false;
    }

    public bool CanIncludeForStats()
    {
        return this.NIDPowerset > -1 & this.IDXPower > -1 && (this.HasProc() || DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].PowerType == ePowerType.Toggle || DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].PowerType == ePowerType.Click && DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].ClickBuff || DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].PowerType == ePowerType.Auto_);
    }

    public void CheckVariableBounds()
    {
        if (this.Power == null || !this.Power.VariableEnabled)
            this.VariableValue = 0;
        else if (this.Power.VariableMin > this.VariableValue)
        {
            this.VariableValue = this.Power.VariableMin;
        }
        else
        {
            if (this.Power.VariableMax >= this.VariableValue)
                return;
            this.VariableValue = this.Power.VariableMax;
        }
    }

    public void ValidateSlots()
    {
        for (int index = 0; index <= this.Slots.Length - 1; ++index)
        {
            if (!this.Power.IsEnhancementValid(this.Slots[index].Enhancement.Enh))
                this.Slots[index].Enhancement = new I9Slot();
            if (!this.Power.IsEnhancementValid(this.Slots[index].FlippedEnhancement.Enh))
                this.Slots[index].FlippedEnhancement = new I9Slot();
        }
    }

    public void Reset()
    {
        this.NIDPowerset = -1;
        this.IDXPower = -1;
        this.NIDPower = -1;
        this.Tag = false;
        this.StatInclude = false;
        this.SubPowers = new PowerSubEntry[0];
        if (this.Slots.Length != 1 || this.Slots[0].Enhancement.Enh != -1)
            return;
        this.Slots = new SlotEntry[0];
    }

    public object Clone()
    {
        PowerEntry powerEntry = new PowerEntry(this.Level, this.Power, this.Chosen)
        {
            StatInclude = this.StatInclude,
            Tag = this.Tag,
            VariableValue = this.VariableValue,
            SubPowers = (PowerSubEntry[])this.SubPowers.Clone(),
            Slots = new SlotEntry[this.Slots.Length]
        };
        for (int index = 0; index < this.SlotCount; ++index)
        {
            powerEntry.Slots[index].Level = this.Slots[index].Level;
            powerEntry.Slots[index].Enhancement = this.Slots[index].Enhancement.Clone() as I9Slot;
            powerEntry.Slots[index].FlippedEnhancement = this.Slots[index].FlippedEnhancement.Clone() as I9Slot;
        }
        return powerEntry;
    }

    public PopUp.Section PopSubPowerListing(
      string sTitle,
      Color disabledColor,
      Color enabledColor)
    {
        PopUp.Section section = new PopUp.Section();
        section.Add(sTitle, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
        foreach (PowerSubEntry subPower in this.SubPowers)
        {
            if (subPower.nIDPower > -1)
                section.Add(DatabaseAPI.Database.Power[subPower.nIDPower].DisplayName, subPower.StatInclude ? enabledColor : disabledColor, 0.9f, FontStyle.Bold, 1);
        }
        return section;
    }

    public int AddSlot(int iLevel)
    {
        int num1;
        if (this.Slots.Length > 5 | !DatabaseAPI.Database.Power[this.NIDPower].Slottable)
        {
            num1 = -1;
        }
        else
        {
            int index1;
            if (this.Slots.Length == 0)
            {
                this.Slots = new SlotEntry[1];
                index1 = 0;
            }
            else
            {
                int num2 = 0;
                for (int index2 = 1; index2 < this.Slots.Length; ++index2)
                {
                    if (this.Slots[index2].Level <= iLevel)
                        num2 = index2;
                }
                index1 = num2 + 1;
                SlotEntry[] slotEntryArray = new SlotEntry[this.Slots.Length + 1];
                int index3 = -1;
                for (int index2 = 0; index2 < slotEntryArray.Length; ++index2)
                {
                    if (index2 != index1)
                    {
                        ++index3;
                        slotEntryArray[index2].Assign(this.Slots[index3]);
                    }
                }
                this.Slots = new SlotEntry[slotEntryArray.Length];
                for (int index2 = 0; index2 < this.Slots.Length; ++index2)
                {
                    if (index2 != index1)
                        this.Slots[index2].Assign(slotEntryArray[index2]);
                }
            }
            this.Slots[index1].Enhancement = new I9Slot();
            this.Slots[index1].FlippedEnhancement = new I9Slot();
            this.Slots[index1].Level = iLevel;
            num1 = index1;
        }
        return num1;
    }

    public bool CanRemoveSlot(int slotIdx, out string message)
    {
        message = string.Empty;
        bool flag1 = true;
        bool flag2;
        if (slotIdx < 0 || slotIdx > this.Slots.Length - 1)
        {
            flag2 = false;
        }
        else
        {
            if (slotIdx == 0 & this.NIDPowerset > -1)
            {
                flag1 = false;
                message = "This slot was added automatically and can't be removed without also removing the power.";
            }
            else if (slotIdx == 0 && this.Slots.Length > 1)
            {
                flag1 = false;
                message = "This slot was added automatically with a power, and can't be removed until you've removed all other slots from this power.";
            }
            flag2 = flag1;
        }
        return flag2;
    }
}
