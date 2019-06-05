using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Base.Data_Classes;
using Base.IO_Classes;
using Base.Master_Classes;

// Token: 0x02000027 RID: 39
public static class DatabaseAPI
{
	// Token: 0x17000205 RID: 517
	// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0001C148 File Offset: 0x0001A348
	public static IDatabase Database
	{
		get
		{
			return Base.Data_Classes.Database.Instance;
		}
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x0001C15F File Offset: 0x0001A35F
	private static void ClearLookups()
	{
		DatabaseAPI.AttribMod.Clear();
		DatabaseAPI.Classes.Clear();
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0001C178 File Offset: 0x0001A378
	public static int NidFromUidAttribMod(string uID)
	{
		int num;
		if (string.IsNullOrEmpty(uID))
		{
			num = -1;
		}
		else if (DatabaseAPI.AttribMod.ContainsKey(uID))
		{
			num = DatabaseAPI.AttribMod[uID];
		}
		else
		{
			for (int index = 0; index <= DatabaseAPI.Database.AttribMods.Modifier.Length - 1; index++)
			{
				if (string.Equals(uID, DatabaseAPI.Database.AttribMods.Modifier[index].ID, StringComparison.OrdinalIgnoreCase))
				{
					DatabaseAPI.AttribMod.Add(uID, index);
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x0001C228 File Offset: 0x0001A428
	public static int NidFromUidClass(string uidClass)
	{
		int num;
		if (string.IsNullOrEmpty(uidClass))
		{
			num = -1;
		}
		else if (DatabaseAPI.Classes.ContainsKey(uidClass))
		{
			num = DatabaseAPI.Classes[uidClass];
		}
		else
		{
			for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; index++)
			{
				if (string.Equals(uidClass, DatabaseAPI.Database.Classes[index].ClassName, StringComparison.OrdinalIgnoreCase))
				{
					DatabaseAPI.Classes.Add(uidClass, index);
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x0001C2CC File Offset: 0x0001A4CC
	public static string UidFromNidClass(int nIDClass)
	{
		string result;
		if (nIDClass >= 0 && nIDClass <= DatabaseAPI.Database.Classes.Length)
		{
			result = DatabaseAPI.Database.Classes[nIDClass].ClassName;
		}
		else
		{
			result = string.Empty;
		}
		return result;
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x0001C318 File Offset: 0x0001A518
	public static int NidFromUidOrigin(string uidOrigin, int nIDClass)
	{
		int num;
		if (nIDClass < 0)
		{
			num = -1;
		}
		else
		{
			for (int index = 0; index < DatabaseAPI.Database.Classes[nIDClass].Origin.Length; index++)
			{
				if (string.Equals(DatabaseAPI.Database.Classes[nIDClass].Origin[index], uidOrigin, StringComparison.OrdinalIgnoreCase))
				{
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x0001C38C File Offset: 0x0001A58C
	private static void FillGroupArray()
	{
		DatabaseAPI.Database.PowersetGroups = new Dictionary<string, PowersetGroup>();
		foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
		{
			if (!string.IsNullOrEmpty(powerset.GroupName))
			{
				PowersetGroup powersetGroup;
				if (!DatabaseAPI.Database.PowersetGroups.TryGetValue(powerset.GroupName, out powersetGroup))
				{
					powersetGroup = new PowersetGroup(powerset.GroupName);
					DatabaseAPI.Database.PowersetGroups.Add(powerset.GroupName, powersetGroup);
				}
				powersetGroup.Powersets.Add(powerset.FullName, powerset);
				powerset.Group = powersetGroup;
			}
		}
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x0001C444 File Offset: 0x0001A644
	public static int NidFromUidPowerset(string uidPowerset)
	{
		IPowerset powersetByName = DatabaseAPI.GetPowersetByName(uidPowerset);
		int result;
		if (powersetByName != null)
		{
			result = powersetByName.nID;
		}
		else
		{
			result = -1;
		}
		return result;
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x0001C478 File Offset: 0x0001A678
	public static int NidFromStaticIndexPower(int sidPower)
	{
		int num;
		if (sidPower < 0)
		{
			num = -1;
		}
		else
		{
			for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
			{
				if (DatabaseAPI.Database.Power[index].StaticIndex == sidPower)
				{
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x0001C4E4 File Offset: 0x0001A6E4
	public static int NidFromUidPower(string name)
	{
		IPower powerByName = DatabaseAPI.GetPowerByName(name);
		int result;
		if (powerByName != null)
		{
			result = powerByName.PowerIndex;
		}
		else
		{
			result = -1;
		}
		return result;
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x0001C518 File Offset: 0x0001A718
	public static int NidFromUidEntity(string uidEntity)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Entities.Length - 1; index++)
		{
			if (string.Equals(DatabaseAPI.Database.Entities[index].UID, uidEntity, StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x0001C578 File Offset: 0x0001A778
	public static int[] NidSets(PowersetGroup group, int nIDClass, Enums.ePowerSetType nType)
	{
		List<int> intList = new List<int>();
		bool flag = nType != Enums.ePowerSetType.None;
		bool flag2 = nIDClass > -1;
		int[] array;
		if ((nType == Enums.ePowerSetType.Inherent || nType == Enums.ePowerSetType.Pool) && nIDClass > -1 && !DatabaseAPI.Database.Classes[nIDClass].Playable)
		{
			array = intList.ToArray();
		}
		else
		{
			IPowerset[] powersetArray = DatabaseAPI.Database.Powersets;
			if (group != null)
			{
				List<IPowerset> powersetList = new List<IPowerset>();
				foreach (KeyValuePair<string, IPowerset> powerset in group.Powersets)
				{
					powersetList.Add(powerset.Value);
				}
				powersetArray = powersetList.ToArray();
			}
			foreach (IPowerset powerset2 in powersetArray)
			{
				bool flag3 = !flag || powerset2.SetType == nType;
				if (flag2 && flag3)
				{
					if ((powerset2.SetType == Enums.ePowerSetType.Primary || powerset2.SetType == Enums.ePowerSetType.Secondary) && (powerset2.nArchetype != nIDClass & powerset2.nArchetype > -1))
					{
						flag3 = false;
					}
					if (powerset2.Powers.Length > 0 && flag3 && powerset2.SetType != Enums.ePowerSetType.Inherent && powerset2.SetType != Enums.ePowerSetType.Accolade && powerset2.SetType != Enums.ePowerSetType.Temp && !powerset2.Powers[0].Requires.ClassOk(nIDClass))
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					intList.Add(powerset2.nID);
				}
			}
			array = intList.ToArray();
		}
		return array;
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x0001C760 File Offset: 0x0001A960
	public static int[] NidSets(string uidGroup, string uidClass, Enums.ePowerSetType nType)
	{
		return DatabaseAPI.NidSets(DatabaseAPI.Database.PowersetGroups.ContainsKey(uidGroup) ? DatabaseAPI.Database.PowersetGroups[uidGroup] : null, DatabaseAPI.NidFromUidClass(uidClass), nType);
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x0001C7A4 File Offset: 0x0001A9A4
	public static int[] NidPowers(int nIDPowerset, int nIDClass = -1)
	{
		int[] array = new int[0];
		if (nIDPowerset < 0 | nIDPowerset > DatabaseAPI.Database.Powersets.Length - 1)
		{
			array = new int[DatabaseAPI.Database.Power.Length];
			for (int index = 0; index < DatabaseAPI.Database.Power.Length; index++)
			{
				array[index] = index;
			}
		}
		else
		{
			for (int index2 = 0; index2 < DatabaseAPI.Database.Powersets[nIDPowerset].Power.Length; index2++)
			{
				if (DatabaseAPI.Database.Powersets[nIDPowerset].Powers[index2].Requires.ClassOk(nIDClass))
				{
					Array.Resize<int>(ref array, array.Length + 1);
					array[array.Length - 1] = DatabaseAPI.Database.Powersets[nIDPowerset].Power[index2];
				}
			}
		}
		return array;
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x0001C890 File Offset: 0x0001AA90
	public static int[] NidPowers(string uidPowerset, string uidClass = "")
	{
		return DatabaseAPI.NidPowers(DatabaseAPI.NidFromUidPowerset(uidPowerset), DatabaseAPI.NidFromUidClass(uidClass));
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x0001C8B4 File Offset: 0x0001AAB4
	public static string[] UidPowers(string uidPowerset, string uidClass = "")
	{
		string[] array = new string[0];
		if (string.IsNullOrEmpty(uidPowerset))
		{
			array = new string[DatabaseAPI.Database.Power.Length];
			for (int index = 0; index < DatabaseAPI.Database.Power.Length; index++)
			{
				array[index] = DatabaseAPI.Database.Power[index].FullName;
			}
		}
		else
		{
			for (int index2 = 0; index2 <= DatabaseAPI.Database.Power.Length - 1; index2++)
			{
				if (string.Equals(DatabaseAPI.Database.Power[index2].FullSetName, uidPowerset, StringComparison.OrdinalIgnoreCase) && DatabaseAPI.Database.Power[index2].Requires.ClassOk(uidClass))
				{
					Array.Resize<string>(ref array, array.Length + 1);
					array[array.Length - 1] = DatabaseAPI.Database.Power[index2].FullName;
				}
			}
		}
		return array;
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x0001C9B8 File Offset: 0x0001ABB8
	private static int[] NidPowersAtLevel(int iLevel, int nIDPowerset)
	{
		int[] array = new int[0];
		int[] numArray;
		if (nIDPowerset < 0)
		{
			numArray = array;
		}
		else
		{
			for (int index = 0; index <= DatabaseAPI.Database.Powersets[nIDPowerset].Powers.Length - 1; index++)
			{
				if (DatabaseAPI.Database.Powersets[nIDPowerset].Powers[index].Level - 1 == iLevel)
				{
					Array.Resize<int>(ref array, array.Length + 1);
					array[array.Length - 1] = DatabaseAPI.Database.Powersets[nIDPowerset].Powers[index].PowerIndex;
				}
			}
			numArray = array;
		}
		return numArray;
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x0001CA6C File Offset: 0x0001AC6C
	public static int[] NidPowersAtLevelBranch(int iLevel, int nIDPowerset)
	{
		int[] numArray3 = new int[0];
		int[] numArray4;
		if (nIDPowerset < 0)
		{
			numArray4 = numArray3;
		}
		else
		{
			if (DatabaseAPI.Database.Powersets[nIDPowerset].nIDTrunkSet > -1)
			{
				int[] numArray5 = DatabaseAPI.NidPowersAtLevel(iLevel, DatabaseAPI.Database.Powersets[nIDPowerset].nIDTrunkSet);
				int[] numArray6 = DatabaseAPI.NidPowersAtLevel(iLevel, nIDPowerset);
				numArray3 = new int[numArray5.Length + numArray6.Length];
				Array.Copy(numArray5, numArray3, numArray5.Length);
				for (int index = 0; index <= numArray6.Length - 1; index++)
				{
					numArray3[numArray5.Length + index] = numArray6[index];
				}
			}
			else
			{
				numArray3 = DatabaseAPI.NidPowersAtLevel(iLevel, nIDPowerset);
			}
			numArray4 = numArray3;
		}
		return numArray4;
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x0001CB30 File Offset: 0x0001AD30
	public static string[] UidMutexAll()
	{
		string[] array = new string[0];
		for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Power[index].GroupMembership.Length > 0)
			{
				for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[index].GroupMembership.Length - 1; index2++)
				{
					bool flag = false;
					for (int index3 = 0; index3 <= array.Length - 1; index3++)
					{
						if (string.Equals(DatabaseAPI.Database.Power[index].GroupMembership[index2], array[index3], StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Array.Resize<string>(ref array, array.Length + 1);
						array[array.Length - 1] = DatabaseAPI.Database.Power[index].GroupMembership[index2];
					}
				}
			}
		}
		Array.Sort<string>(array);
		return array;
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x0001CC50 File Offset: 0x0001AE50
	public static IPowerset GetPowersetByName(string iName)
	{
		string[] strArray = iName.Split(new char[]
		{
			'.'
		});
		IPowerset powerset;
		if (strArray.Length < 2)
		{
			powerset = null;
		}
		else
		{
			if (strArray.Length > 2)
			{
				iName = string.Format("{0}.{1}", strArray[0], strArray[1]);
			}
			string key = strArray[0];
			if (!DatabaseAPI.Database.PowersetGroups.ContainsKey(key))
			{
				powerset = null;
			}
			else
			{
				PowersetGroup powersetGroup = DatabaseAPI.Database.PowersetGroups[key];
				if (!powersetGroup.Powersets.ContainsKey(iName))
				{
					powerset = null;
				}
				else
				{
					powerset = powersetGroup.Powersets[iName];
				}
			}
		}
		return powerset;
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x0001CD10 File Offset: 0x0001AF10
	public static IPowerset GetPowersetByName(string iName, string iArchetype)
	{
		int idx = DatabaseAPI.GetArchetypeByName(iArchetype).Idx;
		foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
		{
			if ((idx == powerset.nArchetype || powerset.nArchetype == -1) && string.Equals(iName, powerset.DisplayName, StringComparison.OrdinalIgnoreCase))
			{
				IPowerset powerset2;
				if (powerset.SetType == Enums.ePowerSetType.Ancillary)
				{
					if (powerset.Power.Length <= 0 || !powerset.Powers[0].Requires.ClassOk(idx))
					{
						goto IL_AB;
					}
					powerset2 = powerset;
				}
				else
				{
					powerset2 = powerset;
				}
				return powerset2;
			}
			IL_AB:;
		}
		return null;
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x0001CDE8 File Offset: 0x0001AFE8
	public static IPowerset GetPowersetByName(string iName, Enums.ePowerSetType iSet)
	{
		foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
		{
			if (iSet == powerset.SetType && string.Equals(iName, powerset.DisplayName, StringComparison.OrdinalIgnoreCase))
			{
				return powerset;
			}
		}
		return null;
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x0001CE50 File Offset: 0x0001B050
	public static IPowerset GetPowersetByID(string iName, Enums.ePowerSetType iSet)
	{
		foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
		{
			if (iSet == powerset.SetType && string.Equals(iName, powerset.SetName, StringComparison.OrdinalIgnoreCase))
			{
				return powerset;
			}
		}
		return null;
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
	public static IPowerset GetInherentPowerset()
	{
		for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Powersets[index].SetType == Enums.ePowerSetType.Inherent)
			{
				return DatabaseAPI.Database.Powersets[index];
			}
		}
		return null;
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x0001CF1C File Offset: 0x0001B11C
	public static Archetype GetArchetypeByName(string iArchetype)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; index++)
		{
			if (string.Equals(iArchetype, DatabaseAPI.Database.Classes[index].DisplayName, StringComparison.OrdinalIgnoreCase))
			{
				return DatabaseAPI.Database.Classes[index];
			}
		}
		return null;
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x0001CF84 File Offset: 0x0001B184
	public static int GetOriginByName(Archetype archetype, string iOrigin)
	{
		for (int index = 0; index <= archetype.Origin.Length - 1; index++)
		{
			if (string.Equals(iOrigin, archetype.Origin[index], StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return 0;
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x0001CFD4 File Offset: 0x0001B1D4
	public static int GetPowerByName(string iName, int iArchetype)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
		{
			int num = -1;
			if (DatabaseAPI.Database.Power[index].PowerSetID > -1)
			{
				num = DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Power[index].PowerSetID].nArchetype;
			}
			if ((iArchetype == num | num == -1) && string.Equals(iName, DatabaseAPI.Database.Power[index].DisplayName))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x0001D08C File Offset: 0x0001B28C
	public static IPower GetPowerByName(string name)
	{
		IPower power;
		if (string.IsNullOrEmpty(name))
		{
			power = null;
		}
		else
		{
			IPowerset powersetByName = DatabaseAPI.GetPowersetByName(name);
			if (powersetByName == null)
			{
				power = null;
			}
			else
			{
				foreach (IPower power2 in powersetByName.Powers)
				{
					if (string.Equals(power2.FullName, name, StringComparison.OrdinalIgnoreCase))
					{
						return power2;
					}
				}
				power = null;
			}
		}
		return power;
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x0001D118 File Offset: 0x0001B318
	public static string[] GetPowersetNames(int iAT, Enums.ePowerSetType iSet)
	{
		List<string> stringList = new List<string>();
		if (iSet != Enums.ePowerSetType.Pool && iSet != Enums.ePowerSetType.Inherent)
		{
			int[] numArray = new int[0];
			switch (iSet)
			{
			case Enums.ePowerSetType.Primary:
				numArray = DatabaseAPI.Database.Classes[iAT].Primary;
				break;
			case Enums.ePowerSetType.Secondary:
				numArray = DatabaseAPI.Database.Classes[iAT].Secondary;
				break;
			case Enums.ePowerSetType.Ancillary:
				numArray = DatabaseAPI.Database.Classes[iAT].Ancillary;
				break;
			}
			foreach (int index in numArray)
			{
				IPowerset powerset = DatabaseAPI.Database.Powersets[index];
				stringList.Add(powerset.DisplayName);
			}
		}
		else
		{
			foreach (IPowerset powerset2 in DatabaseAPI.Database.Powersets)
			{
				if (powerset2.SetType == iSet)
				{
					stringList.Add(powerset2.DisplayName);
				}
			}
		}
		stringList.Sort();
		string[] strArray;
		if (stringList.Count <= 0)
		{
			strArray = new string[]
			{
				"No " + Enum.GetName(iSet.GetType(), iSet)
			};
		}
		else
		{
			strArray = stringList.ToArray();
		}
		return strArray;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x0001D28C File Offset: 0x0001B48C
	public static int[] GetPowersetIndexesByGroup(PowersetGroup group)
	{
		List<int> intList = new List<int>();
		foreach (KeyValuePair<string, IPowerset> powerset in group.Powersets)
		{
			intList.Add(powerset.Value.nID);
		}
		return intList.ToArray();
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x0001D308 File Offset: 0x0001B508
	public static int[] GetPowersetIndexesByGroupName(string name)
	{
		int[] result;
		if (string.IsNullOrEmpty(name) || !DatabaseAPI.Database.PowersetGroups.ContainsKey(name))
		{
			result = new int[1];
		}
		else
		{
			result = DatabaseAPI.GetPowersetIndexesByGroup(DatabaseAPI.Database.PowersetGroups[name]);
		}
		return result;
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x0001D360 File Offset: 0x0001B560
	public static IPowerset[] GetPowersetIndexes(Archetype at, Enums.ePowerSetType iSet)
	{
		return DatabaseAPI.GetPowersetIndexes(at.Idx, iSet);
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x0001D380 File Offset: 0x0001B580
	public static IPowerset[] GetPowersetIndexes(int iAT, Enums.ePowerSetType iSet)
	{
		List<IPowerset> powersetList = new List<IPowerset>();
		if (iSet != Enums.ePowerSetType.Pool & iSet != Enums.ePowerSetType.Inherent)
		{
			for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; index++)
			{
				if (DatabaseAPI.Database.Powersets[index].nArchetype == iAT & DatabaseAPI.Database.Powersets[index].SetType == iSet)
				{
					powersetList.Add(DatabaseAPI.Database.Powersets[index]);
				}
				else if ((iSet == Enums.ePowerSetType.Ancillary & DatabaseAPI.Database.Powersets[index].SetType == iSet) && DatabaseAPI.Database.Powersets[index].ClassOk(iAT))
				{
					powersetList.Add(DatabaseAPI.Database.Powersets[index]);
				}
			}
		}
		else
		{
			for (int index2 = 0; index2 <= DatabaseAPI.Database.Powersets.Length - 1; index2++)
			{
				if (DatabaseAPI.Database.Powersets[index2].SetType == iSet)
				{
					powersetList.Add(DatabaseAPI.Database.Powersets[index2]);
				}
			}
		}
		powersetList.Sort();
		return powersetList.ToArray();
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x0001D4E0 File Offset: 0x0001B6E0
	public static int ToDisplayIndex(IPowerset iPowerset, IPowerset[] iIndexes)
	{
		for (int index = 0; index <= iIndexes.Length - 1; index++)
		{
			if (iIndexes[index].nID == iPowerset.nID)
			{
				return index;
			}
		}
		if (iIndexes.Length > 0)
		{
			return 0;
		}
		return -1;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x0001D540 File Offset: 0x0001B740
	public static int GetEnhancementByUIDName(string iName)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Enhancements[index].UID.Contains(iName))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x0001D59C File Offset: 0x0001B79C
	public static int GetEnhancementByName(string iName)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
		{
			if (string.Equals(DatabaseAPI.Database.Enhancements[index].ShortName, iName, StringComparison.OrdinalIgnoreCase) || string.Equals(DatabaseAPI.Database.Enhancements[index].Name, iName, StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x0001D618 File Offset: 0x0001B818
	public static int GetEnhancementByName(string iName, Enums.eType iType)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Enhancements[index].TypeID == iType && (string.Equals(DatabaseAPI.Database.Enhancements[index].ShortName, iName, StringComparison.OrdinalIgnoreCase) || string.Equals(DatabaseAPI.Database.Enhancements[index].Name, iName, StringComparison.OrdinalIgnoreCase)))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x0001D6AC File Offset: 0x0001B8AC
	public static int GetEnhancementByName(string iName, string iSet)
	{
		foreach (EnhancementSet enhancementSet in DatabaseAPI.Database.EnhancementSets)
		{
			if (string.Equals(enhancementSet.ShortName, iSet, StringComparison.OrdinalIgnoreCase))
			{
				foreach (int enhancement in enhancementSet.Enhancements)
				{
					if (string.Equals(DatabaseAPI.Database.Enhancements[enhancementSet.Enhancements[enhancement]].ShortName, iName, StringComparison.OrdinalIgnoreCase))
					{
						return enhancementSet.Enhancements[enhancement];
					}
				}
			}
		}
		return -1;
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x0001D788 File Offset: 0x0001B988
	public static int FindEnhancement(string setName, string enhName, int iType, int fallBack)
	{
		for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; index++)
		{
			if (DatabaseAPI.Database.Enhancements[index].TypeID == (Enums.eType)iType && string.Equals(DatabaseAPI.Database.Enhancements[index].ShortName, enhName, StringComparison.OrdinalIgnoreCase))
			{
				int num;
				if (DatabaseAPI.Database.Enhancements[index].TypeID != Enums.eType.SetO)
				{
					num = index;
				}
				else
				{
					if (!DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].DisplayName.Equals(setName, StringComparison.OrdinalIgnoreCase))
					{
						goto IL_9A;
					}
					num = index;
				}
				return num;
			}
			IL_9A:;
		}
		if (fallBack > -1 & fallBack < DatabaseAPI.Database.Enhancements.Length)
		{
			return fallBack;
		}
		return -1;
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x0001D874 File Offset: 0x0001BA74
	public static int GetRecipeIdxByName(string iName)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Recipes.Length - 1; index++)
		{
			if (string.Equals(DatabaseAPI.Database.Recipes[index].InternalName, iName, StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x0001D8D4 File Offset: 0x0001BAD4
	public static Recipe GetRecipeByName(string iName)
	{
		foreach (Recipe recipe in DatabaseAPI.Database.Recipes)
		{
			if (string.Equals(recipe.InternalName, iName, StringComparison.OrdinalIgnoreCase))
			{
				return recipe;
			}
		}
		return null;
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x0001D930 File Offset: 0x0001BB30
	public static string[] UidReferencingPowerFix(string uidPower, string uidNew = "")
	{
		string[] array = new string[0];
		for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Power[index].Requires.ReferencesPower(uidPower, uidNew))
			{
				Array.Resize<string>(ref array, array.Length + 1);
				array[array.Length - 1] = DatabaseAPI.Database.Power[index].FullName + " (Requirement)";
			}
			for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[index].Effects.Length - 1; index2++)
			{
				if (DatabaseAPI.Database.Power[index].Effects[index2].Summon == uidPower)
				{
					DatabaseAPI.Database.Power[index].Effects[index2].Summon = uidNew;
					Array.Resize<string>(ref array, array.Length + 1);
					array[array.Length - 1] = DatabaseAPI.Database.Power[index].FullName + " (GrantPower)";
				}
			}
		}
		return array;
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x0001DA68 File Offset: 0x0001BC68
	public static int NidFromStaticIndexEnh(int sidEnh)
	{
		int num;
		if (sidEnh < 0)
		{
			num = -1;
		}
		else
		{
			for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; index++)
			{
				if (DatabaseAPI.Database.Enhancements[index].StaticIndex == sidEnh)
				{
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x0001DAD0 File Offset: 0x0001BCD0
	public static int NidFromUidioSet(string uidSet)
	{
		for (int index = 0; index < DatabaseAPI.Database.EnhancementSets.Count; index++)
		{
			if (string.Equals(DatabaseAPI.Database.EnhancementSets[index].Uid, uidSet, StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x0001DB30 File Offset: 0x0001BD30
	public static int NidFromUidRecipe(string uidRecipe, ref int subIndex)
	{
		bool flag = subIndex > -1 & uidRecipe.Contains("_");
		subIndex = -1;
		string b = flag ? uidRecipe.Substring(0, uidRecipe.LastIndexOf("_", StringComparison.Ordinal)) : uidRecipe;
		for (int index = 0; index < DatabaseAPI.Database.Recipes.Length; index++)
		{
			if (string.Equals(DatabaseAPI.Database.Recipes[index].InternalName, b, StringComparison.OrdinalIgnoreCase))
			{
				int num;
				if (!flag)
				{
					num = index;
				}
				else
				{
					int startIndex = uidRecipe.LastIndexOf("_", StringComparison.Ordinal) + 1;
					if (!(startIndex < 0 | startIndex > uidRecipe.Length - 1))
					{
						b = uidRecipe.Substring(startIndex);
						for (int index2 = 0; index2 < DatabaseAPI.Database.Recipes[index].Item.Length; index2++)
						{
							if (DatabaseAPI.Database.Recipes[index].Item[index2].Level == startIndex)
							{
								subIndex = index2;
								return index;
							}
						}
						goto IL_107;
					}
					num = -1;
				}
				return num;
			}
			IL_107:;
		}
		return -1;
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x0001DC6C File Offset: 0x0001BE6C
	public static int NidFromUidEnh(string uidEnh)
	{
		for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; index++)
		{
			if (string.Equals(DatabaseAPI.Database.Enhancements[index].UID, uidEnh, StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x0001DCC4 File Offset: 0x0001BEC4
	public static int NidFromUidEnhExtended(string uidEnh)
	{
		int num;
		if (!uidEnh.StartsWith("BOOSTS", true, CultureInfo.CurrentCulture))
		{
			num = DatabaseAPI.NidFromUidEnh(uidEnh);
		}
		else
		{
			for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; index++)
			{
				string a = "BOOSTS." + DatabaseAPI.Database.Enhancements[index].UID + "." + DatabaseAPI.Database.Enhancements[index].UID;
				if (string.Equals(a, uidEnh, StringComparison.OrdinalIgnoreCase))
				{
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x0001DD68 File Offset: 0x0001BF68
	public static void SaveMainDatabase()
	{
		string path = Files.SelectDataFileSave("I12.mhd");
		FileStream fileStream;
		BinaryWriter writer;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			writer = new BinaryWriter(fileStream);
		}
		catch (Exception)
		{
			return;
		}
		try
		{
			writer.Write("Mids' Hero Designer Database MK II");
			writer.Write(DatabaseAPI.Database.Version);
			writer.Write(-1);
			writer.Write(DatabaseAPI.Database.Date.ToBinary());
			writer.Write(DatabaseAPI.Database.Issue);
			writer.Write("BEGIN:ARCHETYPES");
			DatabaseAPI.Database.ArchetypeVersion.StoreTo(writer);
			writer.Write(DatabaseAPI.Database.Classes.Length - 1);
			for (int index = 0; index < DatabaseAPI.Database.Classes.Length; index++)
			{
				DatabaseAPI.Database.Classes[index].StoreTo(ref writer);
			}
			writer.Write("BEGIN:POWERSETS");
			DatabaseAPI.Database.PowersetVersion.StoreTo(writer);
			writer.Write(DatabaseAPI.Database.Powersets.Length - 1);
			for (int index2 = 0; index2 <= DatabaseAPI.Database.Powersets.Length - 1; index2++)
			{
				DatabaseAPI.Database.Powersets[index2].StoreTo(ref writer);
			}
			writer.Write("BEGIN:POWERS");
			DatabaseAPI.Database.PowerVersion.StoreTo(writer);
			DatabaseAPI.Database.PowerLevelVersion.StoreTo(writer);
			DatabaseAPI.Database.PowerEffectVersion.StoreTo(writer);
			DatabaseAPI.Database.IOAssignmentVersion.StoreTo(writer);
			writer.Write(DatabaseAPI.Database.Power.Length - 1);
			for (int index3 = 0; index3 < DatabaseAPI.Database.Power.Length; index3++)
			{
				DatabaseAPI.Database.Power[index3].StoreTo(ref writer);
			}
			writer.Write("BEGIN:SUMMONS");
			DatabaseAPI.Database.StoreEntities(writer);
			writer.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
			writer.Close();
			fileStream.Close();
		}
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
	public static bool LoadMainDatabase()
	{
		DatabaseAPI.ClearLookups();
		string path = Files.SelectDataFileLoad("I12.mhd");
		FileStream fileStream;
		BinaryReader reader;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			reader = new BinaryReader(fileStream);
		}
		catch (Exception)
		{
			return false;
		}
		try
		{
			string a = reader.ReadString();
			if (a != "Mids' Hero Designer Database MK II")
			{
				MessageBox.Show("Expected MHD header, got something else!", "Eeeeee!");
			}
			float version = reader.ReadSingle();
			DatabaseAPI.Database.Version = version;
			int year = reader.ReadInt32();
			if (year > 0)
			{
				int month = reader.ReadInt32();
				int day = reader.ReadInt32();
				DatabaseAPI.Database.Date = new DateTime(year, month, day);
			}
			else
			{
				DatabaseAPI.Database.Date = DateTime.FromBinary(reader.ReadInt64());
			}
			DatabaseAPI.Database.Issue = reader.ReadInt32();
			if (reader.ReadString() != "BEGIN:ARCHETYPES")
			{
				MessageBox.Show("Expected Archetype Data, got something else!", "Eeeeee!");
				reader.Close();
				fileStream.Close();
				return false;
			}
			DatabaseAPI.Database.ArchetypeVersion.Load(reader);
			DatabaseAPI.Database.Classes = new Archetype[reader.ReadInt32() + 1];
			for (int index = 0; index < DatabaseAPI.Database.Classes.Length; index++)
			{
				DatabaseAPI.Database.Classes[index] = new Archetype(reader)
				{
					Idx = index
				};
			}
			if (reader.ReadString() != "BEGIN:POWERSETS")
			{
				MessageBox.Show("Expected Powerset Data, got something else!", "Eeeeee!");
				reader.Close();
				fileStream.Close();
				return false;
			}
			DatabaseAPI.Database.PowersetVersion.Load(reader);
			int num3 = 0;
			DatabaseAPI.Database.Powersets = new IPowerset[reader.ReadInt32() + 1];
			for (int index2 = 0; index2 < DatabaseAPI.Database.Powersets.Length; index2++)
			{
				DatabaseAPI.Database.Powersets[index2] = new Powerset(reader)
				{
					nID = index2
				};
				num3++;
				if (num3 > 10)
				{
					num3 = 0;
					Application.DoEvents();
				}
			}
			if (reader.ReadString() != "BEGIN:POWERS")
			{
				MessageBox.Show("Expected Power Data, got something else!", "Eeeeee!");
				reader.Close();
				fileStream.Close();
				return false;
			}
			DatabaseAPI.Database.PowerVersion.Load(reader);
			DatabaseAPI.Database.PowerLevelVersion.Load(reader);
			DatabaseAPI.Database.PowerEffectVersion.Load(reader);
			DatabaseAPI.Database.IOAssignmentVersion.Load(reader);
			DatabaseAPI.Database.Power = new IPower[reader.ReadInt32() + 1];
			for (int index3 = 0; index3 <= DatabaseAPI.Database.Power.Length - 1; index3++)
			{
				DatabaseAPI.Database.Power[index3] = new Power(reader);
				num3++;
				if (num3 > 50)
				{
					num3 = 0;
					Application.DoEvents();
				}
			}
			if (reader.ReadString() != "BEGIN:SUMMONS")
			{
				MessageBox.Show("Expected Summon Data, got something else!", "Eeeeee!");
				reader.Close();
				fileStream.Close();
				return false;
			}
			DatabaseAPI.Database.LoadEntities(reader);
			reader.Close();
			fileStream.Close();
		}
		catch (Exception)
		{
			reader.Close();
			fileStream.Close();
			return false;
		}
		return true;
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x0001E404 File Offset: 0x0001C604
	public static void LoadDatabaseVersion()
	{
		DatabaseAPI.Database.Version = DatabaseAPI.GetDatabaseVersion(Files.SelectDataFileLoad("I12.mhd"));
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x0001E424 File Offset: 0x0001C624
	private static float GetDatabaseVersion(string fName)
	{
		float num = -1f;
		float num2;
		if (!File.Exists(fName))
		{
			num2 = num;
		}
		else
		{
			using (FileStream fileStream = new FileStream(fName, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader(fileStream))
				{
					try
					{
						string a = binaryReader.ReadString();
						if (a != "Mids' Hero Designer Database MK II")
						{
							MessageBox.Show("Expected MHD header, got something else!");
						}
						num = binaryReader.ReadSingle();
					}
					catch (Exception)
					{
						num = -1f;
					}
					binaryReader.Close();
				}
				fileStream.Close();
			}
			num2 = num;
		}
		return num2;
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x0001E510 File Offset: 0x0001C710
	public static bool LoadLevelsDatabase()
	{
		string path = Files.SelectDataFileLoad("Levels.mhd");
		DatabaseAPI.Database.Levels = new LevelMap[0];
		StreamReader iStream;
		try
		{
			iStream = new StreamReader(path);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error!");
			return false;
		}
		string[] strArray = FileIO.IOGrab(iStream);
		while (strArray[0] != "Level")
		{
			strArray = FileIO.IOGrab(iStream);
		}
		DatabaseAPI.Database.Levels = new LevelMap[50];
		for (int index = 0; index < 50; index++)
		{
			DatabaseAPI.Database.Levels[index] = new LevelMap(FileIO.IOGrab(iStream));
		}
		List<int> intList = new List<int>
		{
			0
		};
		for (int index = 0; index <= DatabaseAPI.Database.Levels.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Levels[index].Powers > 0)
			{
				intList.Add(index);
			}
		}
		DatabaseAPI.Database.Levels_MainPowers = intList.ToArray();
		iStream.Close();
		return true;
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x0001E668 File Offset: 0x0001C868
	public static void LoadOrigins()
	{
		string path = Files.SelectDataFileLoad("Origins.mhd");
		DatabaseAPI.Database.Origins = new List<Origin>();
		StreamReader streamReader;
		try
		{
			streamReader = new StreamReader(path);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		try
		{
			string value = FileIO.IOSeekReturn(streamReader, "Version:");
			if (string.IsNullOrEmpty(value))
			{
				throw new EndOfStreamException("Unable to load Enhancement Class data, version header not found!");
			}
			if (!FileIO.IOSeek(streamReader, "Origin"))
			{
				throw new EndOfStreamException("Unable to load Origin data, section header not found!");
			}
			string[] strArray;
			do
			{
				strArray = FileIO.IOGrab(streamReader);
				if (strArray[0] == "End")
				{
					break;
				}
				DatabaseAPI.Database.Origins.Add(new Origin(strArray[0], strArray[1], strArray[2]));
			}
			while (strArray[0] != "End");
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			streamReader.Close();
			return;
		}
		streamReader.Close();
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x0001E790 File Offset: 0x0001C990
	public static int GetOriginIDByName(string iOrigin)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Origins.Count - 1; index++)
		{
			if (string.Equals(iOrigin, DatabaseAPI.Database.Origins[index].Name, StringComparison.OrdinalIgnoreCase))
			{
				return index;
			}
		}
		return 0;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x0001E7F4 File Offset: 0x0001C9F4
	public static int IsSpecialEnh(int enhID)
	{
		for (int index = 0; index < DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[enhID].nIDSet].Enhancements.Length; index++)
		{
			if (enhID == DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[enhID].nIDSet].Enhancements[index] && DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[enhID].nIDSet].SpecialBonus[index].Index.Length > 0)
			{
				return index;
			}
		}
		return -1;
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x0001E8B8 File Offset: 0x0001CAB8
	public static string GetEnhancementNameShortWSet(int iEnh)
	{
		string str;
		if (iEnh < 0 || iEnh > DatabaseAPI.Database.Enhancements.Length - 1)
		{
			str = string.Empty;
		}
		else
		{
			switch (DatabaseAPI.Database.Enhancements[iEnh].TypeID)
			{
			case Enums.eType.Normal:
			case Enums.eType.SpecialO:
				str = DatabaseAPI.Database.Enhancements[iEnh].ShortName;
				break;
			case Enums.eType.InventO:
				str = "Invention: " + DatabaseAPI.Database.Enhancements[iEnh].ShortName;
				break;
			case Enums.eType.SetO:
				str = DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[iEnh].nIDSet].DisplayName + ": " + DatabaseAPI.Database.Enhancements[iEnh].ShortName;
				break;
			default:
				str = string.Empty;
				break;
			}
		}
		return str;
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
	public static int GetFirstValidEnhancement(int iClass)
	{
		for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
		{
			for (int index2 = 0; index2 <= DatabaseAPI.Database.Enhancements[index].ClassID.Length - 1; index2++)
			{
				if (DatabaseAPI.Database.EnhancementClasses[DatabaseAPI.Database.Enhancements[index].ClassID[index2]].ID == iClass)
				{
					return index;
				}
			}
		}
		return -1;
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x0001EA48 File Offset: 0x0001CC48
	public static void GuessRecipes()
	{
		foreach (IEnhancement enhancement in DatabaseAPI.Database.Enhancements)
		{
			if (enhancement.TypeID == Enums.eType.InventO || enhancement.TypeID == Enums.eType.SetO)
			{
				int recipeIdxByName = DatabaseAPI.GetRecipeIdxByName(enhancement.UID);
				if (recipeIdxByName > -1)
				{
					enhancement.RecipeIDX = recipeIdxByName;
					enhancement.RecipeName = DatabaseAPI.Database.Recipes[recipeIdxByName].InternalName;
				}
			}
		}
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x0001EAD8 File Offset: 0x0001CCD8
	public static void AssignRecipeSalvageIDs()
	{
		int[] numArray = new int[7];
		string[] strArray = new string[7];
		foreach (Recipe recipe in DatabaseAPI.Database.Recipes)
		{
			foreach (Recipe.RecipeEntry recipeEntry in recipe.Item)
			{
				for (int index = 0; index <= recipeEntry.Salvage.Length - 1; index++)
				{
					if (recipeEntry.Salvage[index] == strArray[index])
					{
						recipeEntry.SalvageIdx[index] = numArray[index];
					}
					else
					{
						recipeEntry.SalvageIdx[index] = -1;
						string a = recipeEntry.Salvage[index];
						for (int index2 = 0; index2 <= DatabaseAPI.Database.Salvage.Length - 1; index2++)
						{
							if (string.Equals(a, DatabaseAPI.Database.Salvage[index2].InternalName, StringComparison.OrdinalIgnoreCase))
							{
								recipeEntry.SalvageIdx[index] = index2;
								numArray[index] = index2;
								strArray[index] = recipeEntry.Salvage[index];
								break;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x0001EC34 File Offset: 0x0001CE34
	public static void AssignRecipeIDs()
	{
		foreach (Recipe recipe in DatabaseAPI.Database.Recipes)
		{
			recipe.Enhancement = string.Empty;
			recipe.EnhIdx = -1;
		}
		for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
		{
			if (!string.IsNullOrEmpty(DatabaseAPI.Database.Enhancements[index].RecipeName))
			{
				DatabaseAPI.Database.Enhancements[index].RecipeIDX = -1;
				string recipeName = DatabaseAPI.Database.Enhancements[index].RecipeName;
				for (int index2 = 0; index2 <= DatabaseAPI.Database.Recipes.Length - 1; index2++)
				{
					if (recipeName.Equals(DatabaseAPI.Database.Recipes[index2].InternalName, StringComparison.OrdinalIgnoreCase))
					{
						DatabaseAPI.Database.Recipes[index2].Enhancement = DatabaseAPI.Database.Enhancements[index].UID;
						DatabaseAPI.Database.Recipes[index2].EnhIdx = index;
						DatabaseAPI.Database.Enhancements[index].RecipeIDX = index2;
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x0001ED88 File Offset: 0x0001CF88
	public static void LoadRecipes()
	{
		string path = Files.SelectDataFileLoad("Recipe.mhd");
		DatabaseAPI.Database.Recipes = new Recipe[0];
		FileStream fileStream;
		BinaryReader reader;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			reader = new BinaryReader(fileStream);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + "\n\nRecipe database couldn't be loaded.");
			return;
		}
		string a = reader.ReadString();
		if (!(a != "Mids' Hero Designer Recipe Database"))
		{
			DatabaseAPI.Database.RecipeSource1 = reader.ReadString();
			DatabaseAPI.Database.RecipeSource2 = reader.ReadString();
			DatabaseAPI.Database.RecipeRevisionDate = DateTime.FromBinary(reader.ReadInt64());
			int num = 0;
			DatabaseAPI.Database.Recipes = new Recipe[reader.ReadInt32() + 1];
			for (int index = 0; index < DatabaseAPI.Database.Recipes.Length; index++)
			{
				DatabaseAPI.Database.Recipes[index] = new Recipe(reader);
				num++;
				if (num > 100)
				{
					num = 0;
					Application.DoEvents();
				}
			}
		}
		else
		{
			MessageBox.Show("Recipe Database header wasn't found, file may be corrupt!");
			reader.Close();
			fileStream.Close();
		}
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x0001EEDC File Offset: 0x0001D0DC
	public static void SaveRecipes()
	{
		string path = Files.SelectDataFileSave("Recipe.mhd");
		FileStream fileStream;
		BinaryWriter writer;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			writer = new BinaryWriter(fileStream);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		try
		{
			writer.Write("Mids' Hero Designer Recipe Database");
			writer.Write(DatabaseAPI.Database.RecipeSource1);
			writer.Write(DatabaseAPI.Database.RecipeSource2);
			writer.Write(DatabaseAPI.Database.RecipeRevisionDate.ToBinary());
			writer.Write(DatabaseAPI.Database.Recipes.Length - 1);
			for (int index = 0; index <= DatabaseAPI.Database.Recipes.Length - 1; index++)
			{
				DatabaseAPI.Database.Recipes[index].StoreTo(writer);
			}
			writer.Close();
			fileStream.Close();
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			writer.Close();
			fileStream.Close();
		}
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x0001F008 File Offset: 0x0001D208
	public static void LoadSalvage()
	{
		string path = Files.SelectDataFileLoad("Salvage.mhd");
		DatabaseAPI.Database.Salvage = new Salvage[0];
		FileStream fileStream;
		BinaryReader reader;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			reader = new BinaryReader(fileStream);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + "\n\nSalvage database couldn't be loaded.");
			return;
		}
		try
		{
			string a = reader.ReadString();
			if (a != "Mids' Hero Designer Salvage Database")
			{
				MessageBox.Show("Salvage Database header wasn't found, file may be corrupt!");
				reader.Close();
				fileStream.Close();
			}
			else
			{
				DatabaseAPI.Database.Salvage = new Salvage[reader.ReadInt32() + 1];
				for (int index = 0; index < DatabaseAPI.Database.Salvage.Length; index++)
				{
					DatabaseAPI.Database.Salvage[index] = new Salvage(reader);
				}
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show("Salvage Database file isn't how it should be (" + ex2.Message + ")\nNo salvage loaded.");
			DatabaseAPI.Database.Salvage = new Salvage[0];
			reader.Close();
			fileStream.Close();
		}
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x0001F154 File Offset: 0x0001D354
	public static void SaveSalvage()
	{
		string path = Files.SelectDataFileSave("Salvage.mhd");
		FileStream fileStream;
		BinaryWriter writer;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			writer = new BinaryWriter(fileStream);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		try
		{
			writer.Write("Mids' Hero Designer Salvage Database");
			writer.Write(DatabaseAPI.Database.Salvage.Length - 1);
			for (int index = 0; index <= DatabaseAPI.Database.Salvage.Length - 1; index++)
			{
				DatabaseAPI.Database.Salvage[index].StoreTo(writer);
			}
			writer.Close();
			fileStream.Close();
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			writer.Close();
			fileStream.Close();
		}
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x0001F244 File Offset: 0x0001D444
	public static void SaveEnhancementDb()
	{
		string path = Files.SelectDataFileSave("EnhDB.mhd");
		FileStream fileStream;
		BinaryWriter writer;
		try
		{
			fileStream = new FileStream(path, FileMode.Create);
			writer = new BinaryWriter(fileStream);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		try
		{
			writer.Write("Mids' Hero Designer Enhancement Database");
			writer.Write(DatabaseAPI.Database.VersionEnhDb);
			writer.Write(DatabaseAPI.Database.Enhancements.Length - 1);
			for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
			{
				DatabaseAPI.Database.Enhancements[index].StoreTo(writer);
			}
			writer.Write(DatabaseAPI.Database.EnhancementSets.Count - 1);
			for (int index2 = 0; index2 <= DatabaseAPI.Database.EnhancementSets.Count - 1; index2++)
			{
				DatabaseAPI.Database.EnhancementSets[index2].StoreTo(writer);
			}
			writer.Close();
			fileStream.Close();
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			writer.Close();
			fileStream.Close();
		}
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x0001F3A0 File Offset: 0x0001D5A0
	public static void LoadEnhancementDb()
	{
		string path = Files.SelectDataFileLoad("EnhDB.mhd");
		DatabaseAPI.Database.Enhancements = new IEnhancement[0];
		FileStream fileStream;
		BinaryReader reader;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			reader = new BinaryReader(fileStream);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message + "\n\nNo Enhancements have been loaded.", "EnhDB Load Failed");
			return;
		}
		try
		{
			string a = reader.ReadString();
			if (a != "Mids' Hero Designer Enhancement Database")
			{
				MessageBox.Show("Enhancement Database header wasn't found, file may be corrupt!", "Meep!");
				reader.Close();
				fileStream.Close();
			}
			else
			{
				float num3 = reader.ReadSingle();
				float versionEnhDb = DatabaseAPI.Database.VersionEnhDb;
				int num = 0;
				DatabaseAPI.Database.Enhancements = new IEnhancement[reader.ReadInt32() + 1];
				for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; index++)
				{
					DatabaseAPI.Database.Enhancements[index] = new Enhancement(reader);
					num++;
					if (num > 5)
					{
						num = 0;
						Application.DoEvents();
					}
				}
				DatabaseAPI.Database.EnhancementSets = new EnhancementSetCollection();
				int num2 = reader.ReadInt32() + 1;
				for (int index2 = 0; index2 < num2; index2++)
				{
					DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(reader));
					num++;
					if (num > 5)
					{
						num = 0;
						Application.DoEvents();
					}
				}
				reader.Close();
				fileStream.Close();
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show("Enhancement Database file isn't how it should be (" + ex2.Message + ")\nNo Enhancements have been loaded.", "Huh...");
			DatabaseAPI.Database.Enhancements = new IEnhancement[0];
			reader.Close();
			fileStream.Close();
		}
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
	public static bool LoadEnhancementClasses()
	{
		string path = Files.SelectDataFileLoad("EClasses.mhd");
		using (StreamReader streamReader = new StreamReader(path))
		{
			DatabaseAPI.Database.EnhancementClasses = new Enums.sEnhClass[0];
			try
			{
				string value = FileIO.IOSeekReturn(streamReader, "Version:");
				if (string.IsNullOrEmpty(value))
				{
					throw new EndOfStreamException("Unable to load Enhancement Class data, version header not found!");
				}
				if (!FileIO.IOSeek(streamReader, "Index"))
				{
					throw new EndOfStreamException("Unable to load Enhancement Class data, section header not found!");
				}
				Enums.sEnhClass[] enhancementClasses = DatabaseAPI.Database.EnhancementClasses;
				string[] strArray;
				do
				{
					strArray = FileIO.IOGrab(streamReader);
					if (strArray[0] == "End")
					{
						break;
					}
					Array.Resize<Enums.sEnhClass>(ref enhancementClasses, enhancementClasses.Length + 1);
					enhancementClasses[enhancementClasses.Length - 1].ID = int.Parse(strArray[0]);
					enhancementClasses[enhancementClasses.Length - 1].Name = strArray[1];
					enhancementClasses[enhancementClasses.Length - 1].ShortName = strArray[2];
					enhancementClasses[enhancementClasses.Length - 1].ClassID = strArray[3];
					enhancementClasses[enhancementClasses.Length - 1].Desc = strArray[4];
				}
				while (strArray[0] != "End");
				DatabaseAPI.Database.EnhancementClasses = enhancementClasses;
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				streamReader.Close();
				return false;
			}
			streamReader.Close();
		}
		return true;
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x0001F794 File Offset: 0x0001D994
	public static void LoadSetTypeStrings()
	{
		string path = Files.SelectDataFileLoad("SetTypes.mhd");
		DatabaseAPI.Database.SetTypeStringLong = new string[0];
		DatabaseAPI.Database.SetTypeStringShort = new string[0];
		StreamReader streamReader;
		try
		{
			streamReader = new StreamReader(path);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return;
		}
		try
		{
			string value = FileIO.IOSeekReturn(streamReader, "Version:");
			if (string.IsNullOrEmpty(value))
			{
				throw new EndOfStreamException("Unable to load SetType data, version header not found!");
			}
			if (!FileIO.IOSeek(streamReader, "SetID"))
			{
				throw new EndOfStreamException("Unable to load SetType data, section header not found!");
			}
			string[] setTypeStringLong = DatabaseAPI.Database.SetTypeStringLong;
			string[] setTypeStringShort = DatabaseAPI.Database.SetTypeStringShort;
			string[] strArray;
			do
			{
				strArray = FileIO.IOGrab(streamReader);
				if (!(strArray[0] != "End"))
				{
					break;
				}
				Array.Resize<string>(ref setTypeStringLong, setTypeStringLong.Length + 1);
				Array.Resize<string>(ref setTypeStringShort, setTypeStringShort.Length + 1);
				setTypeStringShort[setTypeStringShort.Length - 1] = strArray[1];
				setTypeStringLong[setTypeStringLong.Length - 1] = strArray[2];
			}
			while (strArray[0] != "End");
			DatabaseAPI.Database.SetTypeStringLong = setTypeStringLong;
			DatabaseAPI.Database.SetTypeStringShort = setTypeStringShort;
			DatabaseAPI.Database.EnhGradeStringLong = new string[4];
			DatabaseAPI.Database.EnhGradeStringShort = new string[4];
			DatabaseAPI.Database.EnhGradeStringLong[0] = "None";
			DatabaseAPI.Database.EnhGradeStringLong[1] = "Training Origin";
			DatabaseAPI.Database.EnhGradeStringLong[2] = "Dual Origin";
			DatabaseAPI.Database.EnhGradeStringLong[3] = "Single Origin";
			DatabaseAPI.Database.EnhGradeStringShort[0] = "None";
			DatabaseAPI.Database.EnhGradeStringShort[1] = "TO";
			DatabaseAPI.Database.EnhGradeStringShort[2] = "DO";
			DatabaseAPI.Database.EnhGradeStringShort[3] = "SO";
			DatabaseAPI.Database.SpecialEnhStringLong = new string[5];
			DatabaseAPI.Database.SpecialEnhStringShort = new string[5];
			DatabaseAPI.Database.SpecialEnhStringLong[0] = "None";
			DatabaseAPI.Database.SpecialEnhStringLong[1] = "Hamidon Origin";
			DatabaseAPI.Database.SpecialEnhStringLong[2] = "Hydra Origin";
			DatabaseAPI.Database.SpecialEnhStringLong[3] = "Titan Origin";
			DatabaseAPI.Database.SpecialEnhStringLong[4] = "Yin's Talisman";
			DatabaseAPI.Database.SpecialEnhStringShort[0] = "None";
			DatabaseAPI.Database.SpecialEnhStringShort[1] = "HO";
			DatabaseAPI.Database.SpecialEnhStringShort[2] = "TnO";
			DatabaseAPI.Database.SpecialEnhStringShort[3] = "HyO";
			DatabaseAPI.Database.SpecialEnhStringShort[4] = "YinO";
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			streamReader.Close();
			return;
		}
		streamReader.Close();
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x0001FAA0 File Offset: 0x0001DCA0
	public static bool LoadMaths()
	{
		string path = Files.SelectDataFileLoad("Maths.mhd");
		StreamReader streamReader;
		try
		{
			streamReader = new StreamReader(path);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			return false;
		}
		try
		{
			string value = FileIO.IOSeekReturn(streamReader, "Version:");
			if (string.IsNullOrEmpty(value))
			{
				throw new EndOfStreamException("Unable to load Enhancement Maths data, version header not found!");
			}
			if (!FileIO.IOSeek(streamReader, "EDRT"))
			{
				throw new EndOfStreamException("Unable to load Maths data, section header not found!");
			}
			DatabaseAPI.Database.MultED = new float[4][];
			for (int index = 0; index < 4; index++)
			{
				DatabaseAPI.Database.MultED[index] = new float[3];
			}
			string[] strArray5;
			for (int index2 = 0; index2 <= 2; index2++)
			{
				strArray5 = FileIO.IOGrab(streamReader);
				for (int index3 = 0; index3 < 4; index3++)
				{
					DatabaseAPI.Database.MultED[index3][index2] = float.Parse(strArray5[index3 + 1]);
				}
			}
			if (!FileIO.IOSeek(streamReader, "EGE"))
			{
				throw new EndOfStreamException("Unable to load Maths data, section header not found!");
			}
			DatabaseAPI.Database.MultTO = new float[1][];
			DatabaseAPI.Database.MultDO = new float[1][];
			DatabaseAPI.Database.MultSO = new float[1][];
			DatabaseAPI.Database.MultHO = new float[1][];
			strArray5 = FileIO.IOGrab(streamReader);
			DatabaseAPI.Database.MultTO[0] = new float[4];
			for (int index4 = 0; index4 < 4; index4++)
			{
				DatabaseAPI.Database.MultTO[0][index4] = float.Parse(strArray5[index4 + 1]);
			}
			strArray5 = FileIO.IOGrab(streamReader);
			DatabaseAPI.Database.MultDO[0] = new float[4];
			for (int index5 = 0; index5 < 4; index5++)
			{
				DatabaseAPI.Database.MultDO[0][index5] = float.Parse(strArray5[index5 + 1]);
			}
			strArray5 = FileIO.IOGrab(streamReader);
			DatabaseAPI.Database.MultSO[0] = new float[4];
			for (int index6 = 0; index6 < 4; index6++)
			{
				DatabaseAPI.Database.MultSO[0][index6] = float.Parse(strArray5[index6 + 1]);
			}
			strArray5 = FileIO.IOGrab(streamReader);
			DatabaseAPI.Database.MultHO[0] = new float[4];
			for (int index7 = 0; index7 < 4; index7++)
			{
				DatabaseAPI.Database.MultHO[0][index7] = float.Parse(strArray5[index7 + 1]);
			}
			if (!FileIO.IOSeek(streamReader, "LBIOE"))
			{
				throw new EndOfStreamException("Unable to load Maths data, section header not found!");
			}
			DatabaseAPI.Database.MultIO = new float[53][];
			for (int index8 = 0; index8 < 53; index8++)
			{
				strArray5 = FileIO.IOGrab(streamReader);
				DatabaseAPI.Database.MultIO[index8] = new float[4];
				for (int index9 = 0; index9 < 4; index9++)
				{
					DatabaseAPI.Database.MultIO[index8][index9] = float.Parse(strArray5[index9 + 1]);
				}
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			streamReader.Close();
			return false;
		}
		streamReader.Close();
		return true;
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x0001FE54 File Offset: 0x0001E054
	public static void AssignSetBonusIndexes()
	{
		foreach (EnhancementSet enhancementSet in DatabaseAPI.Database.EnhancementSets)
		{
			foreach (EnhancementSet.BonusItem bonu in enhancementSet.Bonus)
			{
				for (int index = 0; index < bonu.Index.Length; index++)
				{
					bonu.Index[index] = DatabaseAPI.NidFromUidPower(bonu.Name[index]);
				}
			}
			foreach (EnhancementSet.BonusItem specialBonu in enhancementSet.SpecialBonus)
			{
				for (int index2 = 0; index2 <= specialBonu.Index.Length - 1; index2++)
				{
					specialBonu.Index[index2] = DatabaseAPI.NidFromUidPower(specialBonu.Name[index2]);
				}
			}
		}
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x0001FF8C File Offset: 0x0001E18C
	public static float GetModifier(IEffect iEffect)
	{
		int iClass = 0;
		int iLevel = MidsContext.MathLevelBase;
		if (iEffect.Power == null)
		{
			if (iEffect.Enhancement == null)
			{
				return 1f;
			}
		}
		else if (!string.IsNullOrEmpty(iEffect.Power.ForcedClass))
		{
			iClass = DatabaseAPI.NidFromUidClass(iEffect.Power.ForcedClass);
		}
		else if (iEffect.Absorbed_Class_nID > -1)
		{
			iClass = iEffect.Absorbed_Class_nID;
		}
		else
		{
			iClass = MidsContext.Archetype.Idx;
		}
		if (MidsContext.MathLevelExemp > -1 && MidsContext.MathLevelExemp < MidsContext.MathLevelBase)
		{
			iLevel = MidsContext.MathLevelExemp;
		}
		return DatabaseAPI.GetModifier(iClass, iEffect.nModifierTable, iLevel);
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x0002006C File Offset: 0x0001E26C
	private static float GetModifier(int iClass, int iTable, int iLevel)
	{
		float num;
		if (iClass < 0)
		{
			num = 0f;
		}
		else if (iTable < 0)
		{
			num = 0f;
		}
		else if (iLevel < 0)
		{
			num = 0f;
		}
		else if (iClass > DatabaseAPI.Database.Classes.Length - 1)
		{
			num = 0f;
		}
		else
		{
			iClass = DatabaseAPI.Database.Classes[iClass].Column;
			if (iClass < 0)
			{
				num = 0f;
			}
			else if (iTable > DatabaseAPI.Database.AttribMods.Modifier.Length - 1)
			{
				num = 0f;
			}
			else if (iLevel > DatabaseAPI.Database.AttribMods.Modifier[iTable].Table.Length - 1)
			{
				num = 0f;
			}
			else if (iClass > DatabaseAPI.Database.AttribMods.Modifier[iTable].Table[iLevel].Length - 1)
			{
				num = 0f;
			}
			else
			{
				num = DatabaseAPI.Database.AttribMods.Modifier[iTable].Table[iLevel][iClass];
			}
		}
		return num;
	}

	// Token: 0x06000511 RID: 1297 RVA: 0x000201BC File Offset: 0x0001E3BC
	public static void MatchAllIDs(IMessager iFrm = null)
	{
		DatabaseAPI.UpdateMessage(iFrm, "Matching Group IDs...");
		DatabaseAPI.FillGroupArray();
		DatabaseAPI.UpdateMessage(iFrm, "Matching Class IDs...");
		DatabaseAPI.MatchArchetypeIDs();
		DatabaseAPI.UpdateMessage(iFrm, "Matching Powerset IDs...");
		DatabaseAPI.MatchPowersetIDs();
		DatabaseAPI.UpdateMessage(iFrm, "Matching Power IDs...");
		DatabaseAPI.MatchPowerIDs();
		DatabaseAPI.UpdateMessage(iFrm, "Propagating Group IDs...");
		DatabaseAPI.SetPowersetsFromGroups();
		DatabaseAPI.UpdateMessage(iFrm, "Matching Enhancement IDs...");
		DatabaseAPI.MatchEnhancementIDs();
		DatabaseAPI.UpdateMessage(iFrm, "Matching Modifier IDs...");
		DatabaseAPI.MatchModifierIDs();
		DatabaseAPI.UpdateMessage(iFrm, "Matching Entity IDs...");
		DatabaseAPI.MatchSummonIDs();
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x0002025C File Offset: 0x0001E45C
	private static void UpdateMessage(IMessager iFrm, string iMsg)
	{
		if (iFrm != null)
		{
			iFrm.SetMessage(iMsg);
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x0002027C File Offset: 0x0001E47C
	private static void MatchArchetypeIDs()
	{
		for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; index++)
		{
			DatabaseAPI.Database.Classes[index].Idx = index;
			Array.Sort<string>(DatabaseAPI.Database.Classes[index].Origin);
			DatabaseAPI.Database.Classes[index].Primary = new int[0];
			DatabaseAPI.Database.Classes[index].Secondary = new int[0];
			DatabaseAPI.Database.Classes[index].Ancillary = new int[0];
		}
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x00020324 File Offset: 0x0001E524
	private static void MatchPowersetIDs()
	{
		for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; index++)
		{
			IPowerset powerset = DatabaseAPI.Database.Powersets[index];
			powerset.nID = index;
			powerset.nArchetype = DatabaseAPI.NidFromUidClass(powerset.ATClass);
			if (!string.IsNullOrEmpty(powerset.UIDTrunkSet))
			{
				powerset.nIDTrunkSet = DatabaseAPI.NidFromUidPowerset(powerset.UIDTrunkSet);
			}
			else
			{
				powerset.nIDTrunkSet = -1;
			}
			if (!string.IsNullOrEmpty(powerset.UIDLinkSecondary))
			{
				powerset.nIDLinkSecondary = DatabaseAPI.NidFromUidPowerset(powerset.UIDLinkSecondary);
			}
			else
			{
				powerset.nIDLinkSecondary = -1;
			}
			if (powerset.UIDMutexSets.Length > 0)
			{
				powerset.nIDMutexSets = new int[powerset.UIDMutexSets.Length];
				for (int index2 = 0; index2 < powerset.UIDMutexSets.Length; index2++)
				{
					powerset.nIDMutexSets[index2] = DatabaseAPI.NidFromUidPowerset(powerset.UIDMutexSets[index2]);
				}
			}
			powerset.Power = new int[0];
			powerset.Powers = new IPower[0];
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00020450 File Offset: 0x0001E650
	private static void MatchPowerIDs()
	{
		DatabaseAPI.Database.MutexList = DatabaseAPI.UidMutexAll();
		for (int index = 0; index < DatabaseAPI.Database.Power.Length; index++)
		{
			IPower power = DatabaseAPI.Database.Power[index];
			if (string.IsNullOrEmpty(power.FullName))
			{
				power.FullName = "Orphan." + power.DisplayName.Replace(" ", "_");
			}
			power.PowerIndex = index;
			power.PowerSetID = DatabaseAPI.NidFromUidPowerset(power.FullSetName);
			if (power.PowerSetID > -1)
			{
				int length = power.PowerSet.Powers.Length;
				power.PowerSetIndex = length;
				int[] power2 = power.PowerSet.Power;
				Array.Resize<int>(ref power2, length + 1);
				power.PowerSet.Power = power2;
				IPower[] powers = power.PowerSet.Powers;
				Array.Resize<IPower>(ref powers, length + 1);
				power.PowerSet.Powers = powers;
				power.PowerSet.Power[length] = index;
				power.PowerSet.Powers[length] = power;
			}
		}
		foreach (IPower power3 in DatabaseAPI.Database.Power)
		{
			bool flag = false;
			if (power3.PowerSet.SetType == Enums.ePowerSetType.SetBonus)
			{
				flag = power3.PowerName.Contains("Slow");
				if (flag)
				{
					power3.BuffMode = Enums.eBuffMode.Debuff;
					for (int index2 = 0; index2 < power3.Effects.Length; index2++)
					{
						power3.Effects[index2].buffMode = Enums.eBuffMode.Debuff;
					}
				}
			}
			foreach (IEffect effect in power3.Effects)
			{
				if (flag)
				{
					effect.buffMode = Enums.eBuffMode.Debuff;
				}
				Enums.eEffectType effectType = effect.EffectType;
				if (effectType != Enums.eEffectType.GrantPower)
				{
					if (effectType != Enums.eEffectType.EntCreate)
					{
						if (effectType == Enums.eEffectType.PowerRedirect)
						{
							effect.nSummon = DatabaseAPI.NidFromUidPower(effect.Override);
							power3.HasPowerOverrideEffect = true;
						}
					}
					else
					{
						effect.nSummon = DatabaseAPI.NidFromUidEntity(effect.Summon);
					}
				}
				else
				{
					effect.nSummon = DatabaseAPI.NidFromUidPower(effect.Summon);
					power3.HasGrantPowerEffect = true;
				}
			}
			power3.NGroupMembership = new int[power3.GroupMembership.Length];
			for (int index3 = 0; index3 < power3.GroupMembership.Length; index3++)
			{
				for (int index4 = 0; index4 < DatabaseAPI.Database.MutexList.Length; index4++)
				{
					if (string.Equals(DatabaseAPI.Database.MutexList[index4], power3.GroupMembership[index3], StringComparison.OrdinalIgnoreCase))
					{
						power3.NGroupMembership[index3] = index4;
						break;
					}
				}
			}
			power3.NIDSubPower = new int[power3.UIDSubPower.Length];
			for (int index5 = 0; index5 < power3.UIDSubPower.Length; index5++)
			{
				power3.NIDSubPower[index5] = DatabaseAPI.NidFromUidPower(power3.UIDSubPower[index5]);
			}
			DatabaseAPI.MatchRequirementId(power3);
		}
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x000207EC File Offset: 0x0001E9EC
	private static void MatchRequirementId(IPower power)
	{
		if (power.Requires.ClassName.Length > 0)
		{
			power.Requires.NClassName = new int[power.Requires.ClassName.Length];
			for (int index = 0; index < power.Requires.ClassName.Length; index++)
			{
				power.Requires.NClassName[index] = DatabaseAPI.NidFromUidClass(power.Requires.ClassName[index]);
			}
		}
		if (power.Requires.ClassNameNot.Length > 0)
		{
			power.Requires.NClassNameNot = new int[power.Requires.ClassNameNot.Length];
			for (int index2 = 0; index2 < power.Requires.ClassNameNot.Length; index2++)
			{
				power.Requires.NClassNameNot[index2] = DatabaseAPI.NidFromUidClass(power.Requires.ClassNameNot[index2]);
			}
		}
		if (power.Requires.PowerID.Length > 0)
		{
			power.Requires.NPowerID = new int[power.Requires.PowerID.Length][];
			for (int index3 = 0; index3 < power.Requires.PowerID.Length; index3++)
			{
				power.Requires.NPowerID[index3] = new int[power.Requires.PowerID[index3].Length];
				for (int index4 = 0; index4 < power.Requires.PowerID[index3].Length; index4++)
				{
					if (string.IsNullOrEmpty(power.Requires.PowerID[index3][index4]))
					{
						power.Requires.NPowerID[index3][index4] = -1;
					}
					else
					{
						power.Requires.NPowerID[index3][index4] = DatabaseAPI.NidFromUidPower(power.Requires.PowerID[index3][index4]);
					}
				}
			}
		}
		if (power.Requires.PowerIDNot.Length > 0)
		{
			power.Requires.NPowerIDNot = new int[power.Requires.PowerIDNot.Length][];
			for (int index5 = 0; index5 < power.Requires.PowerIDNot.Length; index5++)
			{
				power.Requires.NPowerIDNot[index5] = new int[power.Requires.PowerIDNot[index5].Length];
				for (int index6 = 0; index6 < power.Requires.PowerIDNot[index5].Length; index6++)
				{
					if (string.IsNullOrEmpty(power.Requires.PowerIDNot[index5][index6]))
					{
						power.Requires.NPowerIDNot[index5][index6] = -1;
					}
					else
					{
						power.Requires.NPowerIDNot[index5][index6] = DatabaseAPI.NidFromUidPower(power.Requires.PowerIDNot[index5][index6]);
					}
				}
			}
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00020AF0 File Offset: 0x0001ECF0
	private static void SetPowersetsFromGroups()
	{
		for (int index = 0; index < DatabaseAPI.Database.Classes.Length; index++)
		{
			Archetype archetype = DatabaseAPI.Database.Classes[index];
			List<int> intList = new List<int>();
			List<int> intList2 = new List<int>();
			List<int> intList3 = new List<int>();
			for (int index2 = 0; index2 < DatabaseAPI.Database.Powersets.Length; index2++)
			{
				IPowerset powerset = DatabaseAPI.Database.Powersets[index2];
				if (powerset.Powers.Length > 0)
				{
					powerset.Powers[0].SortOverride = true;
				}
				if (string.Equals(powerset.GroupName, archetype.PrimaryGroup, StringComparison.OrdinalIgnoreCase))
				{
					intList.Add(index2);
					if (powerset.nArchetype < 0)
					{
						powerset.nArchetype = index;
					}
				}
				if (string.Equals(powerset.GroupName, archetype.SecondaryGroup, StringComparison.OrdinalIgnoreCase))
				{
					intList2.Add(index2);
					if (powerset.nArchetype < 0)
					{
						powerset.nArchetype = index;
					}
				}
				if (string.Equals(powerset.GroupName, archetype.EpicGroup, StringComparison.OrdinalIgnoreCase) && (powerset.nArchetype == index || (powerset.Powers.Length > 0 && powerset.Powers[0].Requires.ClassOk(archetype.ClassName))))
				{
					intList3.Add(index2);
				}
			}
			archetype.Primary = intList.ToArray();
			archetype.Secondary = intList2.ToArray();
			archetype.Ancillary = intList3.ToArray();
		}
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00020CBC File Offset: 0x0001EEBC
	public static void MatchEnhancementIDs()
	{
		for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
		{
			List<int> intList = new List<int>();
			for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[index].BoostsAllowed.Length - 1; index2++)
			{
				int index3 = DatabaseAPI.EnhancementClassIdFromName(DatabaseAPI.Database.Power[index].BoostsAllowed[index2]);
				if (index3 > -1)
				{
					intList.Add(DatabaseAPI.Database.EnhancementClasses[index3].ID);
				}
			}
			DatabaseAPI.Database.Power[index].Enhancements = intList.ToArray();
		}
		for (int index4 = 0; index4 <= DatabaseAPI.Database.EnhancementSets.Count - 1; index4++)
		{
			DatabaseAPI.Database.EnhancementSets[index4].Enhancements = new int[0];
		}
		bool flag = false;
		string str = string.Empty;
		for (int index5 = 0; index5 <= DatabaseAPI.Database.Enhancements.Length - 1; index5++)
		{
			IEnhancement enhancement = DatabaseAPI.Database.Enhancements[index5];
			if (enhancement.TypeID == Enums.eType.SetO && !string.IsNullOrEmpty(enhancement.UIDSet))
			{
				int index6 = DatabaseAPI.NidFromUidioSet(enhancement.UIDSet);
				if (index6 > -1)
				{
					enhancement.nIDSet = index6;
					Array.Resize<int>(ref DatabaseAPI.Database.EnhancementSets[index6].Enhancements, DatabaseAPI.Database.EnhancementSets[index6].Enhancements.Length + 1);
					DatabaseAPI.Database.EnhancementSets[index6].Enhancements[DatabaseAPI.Database.EnhancementSets[index6].Enhancements.Length - 1] = index5;
				}
				else
				{
					str = str + enhancement.UIDSet + enhancement.Name + "\n";
					flag = true;
				}
			}
		}
		if (flag)
		{
			MessageBox.Show("One or more enhancements had difficulty being matched to their invention set. You should check the database for misplaced Invention Set enhancements.\n" + str, "Mismatch Detected");
		}
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x00020F0C File Offset: 0x0001F10C
	private static int EnhancementClassIdFromName(string iName)
	{
		int num;
		if (string.IsNullOrEmpty(iName))
		{
			num = -1;
		}
		else
		{
			for (int index = 0; index <= DatabaseAPI.Database.EnhancementClasses.Length - 1; index++)
			{
				if (string.Equals(DatabaseAPI.Database.EnhancementClasses[index].ClassID, iName, StringComparison.OrdinalIgnoreCase))
				{
					return index;
				}
			}
			num = -1;
		}
		return num;
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x00020F84 File Offset: 0x0001F184
	private static void MatchModifierIDs()
	{
		foreach (IPower power in DatabaseAPI.Database.Power)
		{
			foreach (IEffect effect in power.Effects)
			{
				effect.nModifierTable = DatabaseAPI.NidFromUidAttribMod(effect.ModifierTable);
			}
		}
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00020FF4 File Offset: 0x0001F1F4
	public static void MatchSummonIDs()
	{
		for (int index = 0; index <= DatabaseAPI.Database.Entities.Length - 1; index++)
		{
			SummonedEntity entity = DatabaseAPI.Database.Entities[index];
			entity.nID = index;
			entity.nClassID = DatabaseAPI.NidFromUidClass(entity.ClassName);
			entity.nPowerset = new int[entity.PowersetFullName.Length];
			for (int index2 = 0; index2 <= entity.PowersetFullName.Length - 1; index2++)
			{
				entity.nPowerset[index2] = DatabaseAPI.NidFromUidPowerset(entity.PowersetFullName[index2]);
			}
			entity.nUpgradePower = new int[entity.UpgradePowerFullName.Length];
			for (int index3 = 0; index3 <= entity.UpgradePowerFullName.Length - 1; index3++)
			{
				entity.nUpgradePower[index3] = DatabaseAPI.NidFromUidPower(entity.UpgradePowerFullName[index3]);
			}
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x000210E4 File Offset: 0x0001F2E4
	public static void AssignStaticIndexValues()
	{
		int num2 = -2;
		for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
		{
			if (DatabaseAPI.Database.Power[index].StaticIndex > -1 && DatabaseAPI.Database.Power[index].StaticIndex > num2)
			{
				num2 = DatabaseAPI.Database.Power[index].StaticIndex;
			}
		}
		if (num2 < -1)
		{
			num2 = -1;
		}
		for (int index2 = 0; index2 <= DatabaseAPI.Database.Power.Length - 1; index2++)
		{
			if (DatabaseAPI.Database.Power[index2].StaticIndex < 0)
			{
				num2++;
				DatabaseAPI.Database.Power[index2].StaticIndex = num2;
			}
		}
		num2 = -2;
		for (int index3 = 1; index3 <= DatabaseAPI.Database.Enhancements.Length - 1; index3++)
		{
			if (DatabaseAPI.Database.Enhancements[index3].StaticIndex > -1 && DatabaseAPI.Database.Enhancements[index3].StaticIndex > num2)
			{
				num2 = DatabaseAPI.Database.Enhancements[index3].StaticIndex;
			}
		}
		if (num2 < -1)
		{
			num2 = -1;
		}
		for (int index4 = 1; index4 <= DatabaseAPI.Database.Enhancements.Length - 1; index4++)
		{
			if (DatabaseAPI.Database.Enhancements[index4].StaticIndex < 1)
			{
				num2++;
				DatabaseAPI.Database.Enhancements[index4].StaticIndex = num2;
			}
		}
		DatabaseAPI.SaveMainDatabase();
		DatabaseAPI.SaveEnhancementDb();
	}

	// Token: 0x04000273 RID: 627
	public const int HeroAccolades = 3257;

	// Token: 0x04000274 RID: 628
	public const int VillainAccolades = 3258;

	// Token: 0x04000275 RID: 629
	public const int TempPowers = 3259;

	// Token: 0x04000276 RID: 630
	private static readonly IDictionary<string, int> AttribMod = new Dictionary<string, int>();

	// Token: 0x04000277 RID: 631
	private static readonly IDictionary<string, int> Classes = new Dictionary<string, int>();
}
