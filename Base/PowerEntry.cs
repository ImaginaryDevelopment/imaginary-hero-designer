using System;
using System.Drawing;
using Base.Display;

// Token: 0x0200008E RID: 142
public class PowerEntry : ICloneable
{
	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000662 RID: 1634 RVA: 0x0002EA18 File Offset: 0x0002CC18
	// (set) Token: 0x06000663 RID: 1635 RVA: 0x0002EA2F File Offset: 0x0002CC2F
	public bool Chosen { get; private set; }

	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000664 RID: 1636 RVA: 0x0002EA38 File Offset: 0x0002CC38
	public Enums.ePowerState State
	{
		get
		{
			Enums.ePowerState result;
			if (this.Power != null)
			{
				result = Enums.ePowerState.Used;
			}
			else if (!this.Chosen)
			{
				result = Enums.ePowerState.Disabled;
			}
			else
			{
				result = Enums.ePowerState.Empty;
			}
			return result;
		}
	}

	// Token: 0x17000260 RID: 608
	// (get) Token: 0x06000665 RID: 1637 RVA: 0x0002EA74 File Offset: 0x0002CC74
	public IPower Power
	{
		get
		{
			IPower result;
			if (this.NIDPower < 0 || this.NIDPower > DatabaseAPI.Database.Power.Length - 1)
			{
				result = null;
			}
			else
			{
				result = DatabaseAPI.Database.Power[this.NIDPower];
			}
			return result;
		}
	}

	// Token: 0x17000261 RID: 609
	// (get) Token: 0x06000666 RID: 1638 RVA: 0x0002EACC File Offset: 0x0002CCCC
	public IPowerset PowerSet
	{
		get
		{
			IPowerset result;
			if (this.Power == null)
			{
				result = null;
			}
			else
			{
				result = DatabaseAPI.Database.Powersets[this.Power.PowerSetID];
			}
			return result;
		}
	}

	// Token: 0x17000262 RID: 610
	// (get) Token: 0x06000667 RID: 1639 RVA: 0x0002EB10 File Offset: 0x0002CD10
	public bool AllowFrontLoading
	{
		get
		{
			return this.Power != null && this.Power.AllowFrontLoading;
		}
	}

	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000668 RID: 1640 RVA: 0x0002EB3C File Offset: 0x0002CD3C
	public string Name
	{
		get
		{
			string result;
			if (this.Power == null)
			{
				result = "";
			}
			else
			{
				result = this.Power.DisplayName;
			}
			return result;
		}
	}

	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000669 RID: 1641 RVA: 0x0002EB78 File Offset: 0x0002CD78
	public bool Virtual
	{
		get
		{
			return !this.Chosen && this.SubPowers.Length > 0;
		}
	}

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x0600066A RID: 1642 RVA: 0x0002EBA4 File Offset: 0x0002CDA4
	public int SlotCount
	{
		get
		{
			int result;
			if (this.Slots != null)
			{
				result = this.Slots.Length;
			}
			else
			{
				result = 0;
			}
			return result;
		}
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x0002EBD8 File Offset: 0x0002CDD8
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
			for (int index = 0; index <= this.Slots.Length - 1; index++)
			{
				this.Slots[index].Assign(iPe.Slots[index]);
			}
		}
		else
		{
			this.Slots = new SlotEntry[0];
		}
		if (iPe.SubPowers != null)
		{
			this.SubPowers = new PowerSubEntry[iPe.SubPowers.Length];
			for (int index2 = 0; index2 <= this.SubPowers.Length - 1; index2++)
			{
				this.SubPowers[index2].Assign(iPe.SubPowers[index2]);
			}
		}
		else
		{
			this.SubPowers = new PowerSubEntry[0];
		}
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x0002ED14 File Offset: 0x0002CF14
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

	// Token: 0x0600066D RID: 1645 RVA: 0x0002EDA8 File Offset: 0x0002CFA8
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
				for (int index = 0; index <= this.SubPowers.Length - 1; index++)
				{
					this.SubPowers[index] = new PowerSubEntry
					{
						nIDPower = power.NIDSubPower[index]
					};
					this.SubPowers[index].Powerset = DatabaseAPI.Database.Power[this.SubPowers[index].nIDPower].PowerSetID;
					this.SubPowers[index].Power = DatabaseAPI.Database.Power[this.SubPowers[index].nIDPower].PowerSetIndex;
				}
			}
			else
			{
				this.SubPowers = new PowerSubEntry[0];
			}
			if (power.Slottable & power.PowerSet.GroupName != "Incarnate")
			{
				this.Slots = new SlotEntry[1];
				this.Slots[0].Enhancement = new I9Slot();
				this.Slots[0].FlippedEnhancement = new I9Slot();
				this.Slots[0].Level = iLevel;
			}
			else
			{
				this.Slots = new SlotEntry[0];
			}
			if (power.AlwaysToggle | power.PowerType == Enums.ePowerType.Auto_)
			{
				this.StatInclude = true;
			}
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

	// Token: 0x0600066E RID: 1646 RVA: 0x0002EFB0 File Offset: 0x0002D1B0
	public bool HasProc()
	{
		for (int index = 0; index <= this.SlotCount - 1; index++)
		{
			if (this.Slots[index].Enhancement.Enh >= 0 && DatabaseAPI.Database.Enhancements[this.Slots[index].Enhancement.Enh].Effect.Length > 0 && DatabaseAPI.Database.Enhancements[this.Slots[index].Enhancement.Enh].Power != null)
			{
				for (int index2 = 0; index2 < DatabaseAPI.Database.Enhancements[this.Slots[index].Enhancement.Enh].Power.Effects.Length; index2++)
				{
					Enums.eEffectType effectType = DatabaseAPI.Database.Enhancements[this.Slots[index].Enhancement.Enh].Power.Effects[index2].EffectType;
					if (effectType != Enums.eEffectType.Enhancement && effectType != Enums.eEffectType.None && effectType != Enums.eEffectType.Damage && effectType != Enums.eEffectType.Heal && effectType != Enums.eEffectType.DamageBuff && (effectType != Enums.eEffectType.Mez || DatabaseAPI.Database.Enhancements[this.Slots[index].Enhancement.Enh].Power.Effects[index2].Mag <= 0f) && DatabaseAPI.Database.Enhancements[this.Slots[index].Enhancement.Enh].Power.Effects[index2].ToWho != Enums.eToWho.Target)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x0002F180 File Offset: 0x0002D380
	public bool CanIncludeForStats()
	{
		return (this.NIDPowerset > -1 & this.IDXPower > -1) && (this.HasProc() || DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].PowerType == Enums.ePowerType.Toggle || (DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].PowerType == Enums.ePowerType.Click && DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].ClickBuff) || DatabaseAPI.Database.Powersets[this.NIDPowerset].Powers[this.IDXPower].PowerType == Enums.ePowerType.Auto_);
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x0002F250 File Offset: 0x0002D450
	public void CheckVariableBounds()
	{
		if (this.Power == null || !this.Power.VariableEnabled)
		{
			this.VariableValue = 0;
		}
		else if (this.Power.VariableMin > this.VariableValue)
		{
			this.VariableValue = this.Power.VariableMin;
		}
		else if (this.Power.VariableMax < this.VariableValue)
		{
			this.VariableValue = this.Power.VariableMax;
		}
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x0002F2E0 File Offset: 0x0002D4E0
	public void ValidateSlots()
	{
		for (int index = 0; index <= this.Slots.Length - 1; index++)
		{
			if (!this.Power.IsEnhancementValid(this.Slots[index].Enhancement.Enh))
			{
				this.Slots[index].Enhancement = new I9Slot();
			}
			if (!this.Power.IsEnhancementValid(this.Slots[index].FlippedEnhancement.Enh))
			{
				this.Slots[index].FlippedEnhancement = new I9Slot();
			}
		}
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x0002F38C File Offset: 0x0002D58C
	public void Reset()
	{
		this.NIDPowerset = -1;
		this.IDXPower = -1;
		this.NIDPower = -1;
		this.Tag = false;
		this.StatInclude = false;
		this.SubPowers = new PowerSubEntry[0];
		if (this.Slots.Length == 1 && this.Slots[0].Enhancement.Enh == -1)
		{
			this.Slots = new SlotEntry[0];
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x0002F408 File Offset: 0x0002D608
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
		for (int index = 0; index < this.SlotCount; index++)
		{
			powerEntry.Slots[index].Level = this.Slots[index].Level;
			powerEntry.Slots[index].Enhancement = (this.Slots[index].Enhancement.Clone() as I9Slot);
			powerEntry.Slots[index].FlippedEnhancement = (this.Slots[index].FlippedEnhancement.Clone() as I9Slot);
		}
		return powerEntry;
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x0002F51C File Offset: 0x0002D71C
	public PopUp.Section PopSubPowerListing(string sTitle, Color disabledColor, Color enabledColor)
	{
		PopUp.Section section = new PopUp.Section();
		section.Add(sTitle, PopUp.Colors.Title, 1f, FontStyle.Bold, 0);
		foreach (PowerSubEntry subPower in this.SubPowers)
		{
			if (subPower.nIDPower > -1)
			{
				section.Add(DatabaseAPI.Database.Power[subPower.nIDPower].DisplayName, subPower.StatInclude ? enabledColor : disabledColor, 0.9f, FontStyle.Bold, 1);
			}
		}
		return section;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x0002F5B4 File Offset: 0x0002D7B4
	public int AddSlot(int iLevel)
	{
		int num;
		if (this.Slots.Length > 5 | !DatabaseAPI.Database.Power[this.NIDPower].Slottable)
		{
			num = -1;
		}
		else
		{
			int index;
			if (this.Slots.Length == 0)
			{
				this.Slots = new SlotEntry[1];
				index = 0;
			}
			else
			{
				index = 0;
				for (int index2 = 1; index2 < this.Slots.Length; index2++)
				{
					if (this.Slots[index2].Level <= iLevel)
					{
						index = index2;
					}
				}
				index++;
				SlotEntry[] slotEntryArray = new SlotEntry[this.Slots.Length + 1];
				int index3 = -1;
				for (int index4 = 0; index4 < slotEntryArray.Length; index4++)
				{
					if (index4 != index)
					{
						index3++;
						slotEntryArray[index4].Assign(this.Slots[index3]);
					}
				}
				this.Slots = new SlotEntry[slotEntryArray.Length];
				for (int index5 = 0; index5 < this.Slots.Length; index5++)
				{
					if (index5 != index)
					{
						this.Slots[index5].Assign(slotEntryArray[index5]);
					}
				}
			}
			this.Slots[index].Enhancement = new I9Slot();
			this.Slots[index].FlippedEnhancement = new I9Slot();
			this.Slots[index].Level = iLevel;
			num = index;
		}
		return num;
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x0002F768 File Offset: 0x0002D968
	public bool CanRemoveSlot(int slotIdx, out string message)
	{
		message = string.Empty;
		bool flag = true;
		bool flag2;
		if (slotIdx < 0 || slotIdx > this.Slots.Length - 1)
		{
			flag2 = false;
		}
		else
		{
			if (slotIdx == 0 & this.NIDPowerset > -1)
			{
				flag = false;
				message = "This slot was added automatically and can't be removed without also removing the power.";
			}
			else if (slotIdx == 0 && this.Slots.Length > 1)
			{
				flag = false;
				message = "This slot was added automatically with a power, and can't be removed until you've removed all other slots from this power.";
			}
			flag2 = flag;
		}
		return flag2;
	}

	// Token: 0x0400064B RID: 1611
	public int Level;

	// Token: 0x0400064C RID: 1612
	public int NIDPowerset;

	// Token: 0x0400064D RID: 1613
	public int IDXPower;

	// Token: 0x0400064E RID: 1614
	public int NIDPower;

	// Token: 0x0400064F RID: 1615
	public bool Tag;

	// Token: 0x04000650 RID: 1616
	public bool StatInclude;

	// Token: 0x04000651 RID: 1617
	public int VariableValue;

	// Token: 0x04000652 RID: 1618
	public SlotEntry[] Slots;

	// Token: 0x04000653 RID: 1619
	public PowerSubEntry[] SubPowers;
}
