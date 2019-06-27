
using Base.Data_Classes;
using Base.IO_Classes;
using Base.Master_Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

public static class DatabaseAPI
{
    static readonly IDictionary<string, int> AttribMod = (IDictionary<string, int>)new Dictionary<string, int>();

    static readonly IDictionary<string, int> Classes = (IDictionary<string, int>)new Dictionary<string, int>();

    public const int HeroAccolades = 3257;
    public const int VillainAccolades = 3258;
    public const int TempPowers = 3259;

    public static IDatabase Database
    {
        get
        {
            return (IDatabase)Base.Data_Classes.Database.Instance;
        }
    }

    static void ClearLookups()

    {
        DatabaseAPI.AttribMod.Clear();
        DatabaseAPI.Classes.Clear();
    }

    public static int NidFromUidAttribMod(string uID)
    {
        int num;
        if (string.IsNullOrEmpty(uID))
            num = -1;
        else if (DatabaseAPI.AttribMod.ContainsKey(uID))
        {
            num = DatabaseAPI.AttribMod[uID];
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.AttribMods.Modifier.Length - 1; ++index)
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

    public static int NidFromUidClass(string uidClass)
    {
        int num;
        if (string.IsNullOrEmpty(uidClass))
            num = -1;
        else if (DatabaseAPI.Classes.ContainsKey(uidClass))
        {
            num = DatabaseAPI.Classes[uidClass];
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
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

    public static string UidFromNidClass(int nIDClass)
    {
        return nIDClass < 0 || nIDClass > DatabaseAPI.Database.Classes.Length ? string.Empty : DatabaseAPI.Database.Classes[nIDClass].ClassName;
    }

    public static int NidFromUidOrigin(string uidOrigin, int nIDClass)
    {
        int num;
        if (nIDClass < 0)
        {
            num = -1;
        }
        else
        {
            for (int index = 0; index < DatabaseAPI.Database.Classes[nIDClass].Origin.Length; ++index)
            {
                if (string.Equals(DatabaseAPI.Database.Classes[nIDClass].Origin[index], uidOrigin, StringComparison.OrdinalIgnoreCase))
                    return index;
            }
            num = -1;
        }
        return num;
    }

    static void FillGroupArray()

    {
        DatabaseAPI.Database.PowersetGroups = (IDictionary<string, PowersetGroup>)new Dictionary<string, PowersetGroup>();
        foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
        {
            if (!string.IsNullOrEmpty(powerset.GroupName))
            {
                if (!DatabaseAPI.Database.PowersetGroups.TryGetValue(powerset.GroupName, out PowersetGroup powersetGroup))
                {
                    powersetGroup = new PowersetGroup(powerset.GroupName);
                    DatabaseAPI.Database.PowersetGroups.Add(powerset.GroupName, powersetGroup);
                }
                powersetGroup.Powersets.Add(powerset.FullName, powerset);
                powerset.Group = powersetGroup;
            }
        }
    }

    public static int NidFromUidPowerset(string uidPowerset)
    {
        IPowerset powersetByName = DatabaseAPI.GetPowersetByName(uidPowerset);
        return powersetByName == null ? -1 : powersetByName.nID;
    }

    public static int NidFromStaticIndexPower(int sidPower)
    {
        int num;
        if (sidPower < 0)
        {
            num = -1;
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
            {
                if (DatabaseAPI.Database.Power[index].StaticIndex == sidPower)
                    return index;
            }
            num = -1;
        }
        return num;
    }

    public static int NidFromUidPower(string name)
    {
        IPower powerByName = DatabaseAPI.GetPowerByName(name);
        return powerByName == null ? -1 : powerByName.PowerIndex;
    }

    public static int NidFromUidEntity(string uidEntity)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Entities.Length - 1; ++index)
        {
            if (string.Equals(DatabaseAPI.Database.Entities[index].UID, uidEntity, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return -1;
    }

    public static int[] NidSets(PowersetGroup group, int nIDClass, Enums.ePowerSetType nType)
    {
        List<int> intList = new List<int>();
        bool flag1 = nType != Enums.ePowerSetType.None;
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
                foreach (KeyValuePair<string, IPowerset> powerset in (IEnumerable<KeyValuePair<string, IPowerset>>)group.Powersets)
                    powersetList.Add(powerset.Value);
                powersetArray = powersetList.ToArray();
            }
            foreach (IPowerset powerset in powersetArray)
            {
                bool flag3 = !flag1 || powerset.SetType == nType;
                if (flag2 & flag3)
                {
                    if ((powerset.SetType == Enums.ePowerSetType.Primary || powerset.SetType == Enums.ePowerSetType.Secondary) && powerset.nArchetype != nIDClass & powerset.nArchetype > -1)
                        flag3 = false;
                    if (powerset.Powers.Length > 0 && flag3 && (powerset.SetType != Enums.ePowerSetType.Inherent && powerset.SetType != Enums.ePowerSetType.Accolade) && powerset.SetType != Enums.ePowerSetType.Temp && !powerset.Powers[0].Requires.ClassOk(nIDClass))
                        flag3 = false;
                }
                if (flag3)
                    intList.Add(powerset.nID);
            }
            array = intList.ToArray();
        }
        return array;
    }

    public static int[] NidSets(string uidGroup, string uidClass, Enums.ePowerSetType nType)
    {
        return DatabaseAPI.NidSets(DatabaseAPI.Database.PowersetGroups.ContainsKey(uidGroup) ? DatabaseAPI.Database.PowersetGroups[uidGroup] : (PowersetGroup)null, DatabaseAPI.NidFromUidClass(uidClass), nType);
    }

    public static int[] NidPowers(int nIDPowerset, int nIDClass = -1)
    {
        int[] array = new int[0];
        if (nIDPowerset < 0 | nIDPowerset > DatabaseAPI.Database.Powersets.Length - 1)
        {
            array = new int[DatabaseAPI.Database.Power.Length];
            for (int index = 0; index < DatabaseAPI.Database.Power.Length; ++index)
                array[index] = index;
        }
        else
        {
            for (int index = 0; index < DatabaseAPI.Database.Powersets[nIDPowerset].Power.Length; ++index)
            {
                if (DatabaseAPI.Database.Powersets[nIDPowerset].Powers[index].Requires.ClassOk(nIDClass))
                {
                    Array.Resize<int>(ref array, array.Length + 1);
                    array[array.Length - 1] = DatabaseAPI.Database.Powersets[nIDPowerset].Power[index];
                }
            }
        }
        return array;
    }

    public static int[] NidPowers(string uidPowerset, string uidClass = "")
    {
        return DatabaseAPI.NidPowers(DatabaseAPI.NidFromUidPowerset(uidPowerset), DatabaseAPI.NidFromUidClass(uidClass));
    }

    public static string[] UidPowers(string uidPowerset, string uidClass = "")
    {
        string[] array = new string[0];
        if (string.IsNullOrEmpty(uidPowerset))
        {
            array = new string[DatabaseAPI.Database.Power.Length];
            for (int index = 0; index < DatabaseAPI.Database.Power.Length; ++index)
                array[index] = DatabaseAPI.Database.Power[index].FullName;
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
            {
                if (string.Equals(DatabaseAPI.Database.Power[index].FullSetName, uidPowerset, StringComparison.OrdinalIgnoreCase) && DatabaseAPI.Database.Power[index].Requires.ClassOk(uidClass))
                {
                    Array.Resize<string>(ref array, array.Length + 1);
                    array[array.Length - 1] = DatabaseAPI.Database.Power[index].FullName;
                }
            }
        }
        return array;
    }

    static int[] NidPowersAtLevel(int iLevel, int nIDPowerset)

    {
        int[] array = new int[0];
        int[] numArray;
        if (nIDPowerset < 0)
        {
            numArray = array;
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.Powersets[nIDPowerset].Powers.Length - 1; ++index)
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

    public static int[] NidPowersAtLevelBranch(int iLevel, int nIDPowerset)
    {
        int[] numArray1 = new int[0];
        int[] numArray2;
        if (nIDPowerset < 0)
        {
            numArray2 = numArray1;
        }
        else
        {
            int[] numArray3;
            if (DatabaseAPI.Database.Powersets[nIDPowerset].nIDTrunkSet > -1)
            {
                int[] numArray4 = DatabaseAPI.NidPowersAtLevel(iLevel, DatabaseAPI.Database.Powersets[nIDPowerset].nIDTrunkSet);
                int[] numArray5 = DatabaseAPI.NidPowersAtLevel(iLevel, nIDPowerset);
                numArray3 = new int[numArray4.Length + numArray5.Length];
                Array.Copy((Array)numArray4, (Array)numArray3, numArray4.Length);
                for (int index = 0; index <= numArray5.Length - 1; ++index)
                    numArray3[numArray4.Length + index] = numArray5[index];
            }
            else
                numArray3 = DatabaseAPI.NidPowersAtLevel(iLevel, nIDPowerset);
            numArray2 = numArray3;
        }
        return numArray2;
    }

    public static string[] UidMutexAll()
    {
        string[] array = new string[0];
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Power.Length - 1; ++index1)
        {
            if (DatabaseAPI.Database.Power[index1].GroupMembership.Length > 0)
            {
                for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[index1].GroupMembership.Length - 1; ++index2)
                {
                    bool flag = false;
                    for (int index3 = 0; index3 <= array.Length - 1; ++index3)
                    {
                        if (string.Equals(DatabaseAPI.Database.Power[index1].GroupMembership[index2], array[index3], StringComparison.OrdinalIgnoreCase))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        Array.Resize<string>(ref array, array.Length + 1);
                        array[array.Length - 1] = DatabaseAPI.Database.Power[index1].GroupMembership[index2];
                    }
                }
            }
        }
        Array.Sort<string>(array);
        return array;
    }

    public static IPowerset GetPowersetByName(string iName)
    {
        string[] strArray = iName.Split('.');
        IPowerset powerset;
        if (strArray.Length < 2)
        {
            powerset = (IPowerset)null;
        }
        else
        {
            if (strArray.Length > 2)
                iName = string.Format("{0}.{1}", (object)strArray[0], (object)strArray[1]);
            string key = strArray[0];
            if (!DatabaseAPI.Database.PowersetGroups.ContainsKey(key))
            {
                powerset = (IPowerset)null;
            }
            else
            {
                PowersetGroup powersetGroup = DatabaseAPI.Database.PowersetGroups[key];
                powerset = powersetGroup.Powersets.ContainsKey(iName) ? powersetGroup.Powersets[iName] : (IPowerset)null;
            }
        }
        return powerset;
    }

    public static IPowerset GetPowersetByName(string iName, string iArchetype)
    {
        int idx = DatabaseAPI.GetArchetypeByName(iArchetype).Idx;
        foreach (IPowerset powerset1 in DatabaseAPI.Database.Powersets)
        {
            if ((idx == powerset1.nArchetype || powerset1.nArchetype == -1) && string.Equals(iName, powerset1.DisplayName, StringComparison.OrdinalIgnoreCase))
            {
                IPowerset powerset2;
                if (powerset1.SetType == Enums.ePowerSetType.Ancillary)
                {
                    if (powerset1.Power.Length > 0 && powerset1.Powers[0].Requires.ClassOk(idx))
                        powerset2 = powerset1;
                    else
                        continue;
                }
                else
                    powerset2 = powerset1;
                return powerset2;
            }
        }
        return (IPowerset)null;
    }
    //Pine
    public static IPowerset GetPowersetByName(string iName, Enums.ePowerSetType iSet)
    {
        foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
        {
            if (iSet == powerset.SetType && string.Equals(iName, powerset.DisplayName, StringComparison.OrdinalIgnoreCase))
                return powerset;
        }
        return (IPowerset)null;
    }

    public static IPowerset GetPowersetByID(string iName, Enums.ePowerSetType iSet)
    {
        foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
        {
            if (iSet == powerset.SetType && string.Equals(iName, powerset.SetName, StringComparison.OrdinalIgnoreCase))
                return powerset;
        }
        return (IPowerset)null;
    }

    public static IPowerset GetInherentPowerset()
    {
        for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Powersets[index].SetType == Enums.ePowerSetType.Inherent)
                return DatabaseAPI.Database.Powersets[index];
        }
        return (IPowerset)null;
    }

    public static Archetype GetArchetypeByName(string iArchetype)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
        {
            if (string.Equals(iArchetype, DatabaseAPI.Database.Classes[index].DisplayName, StringComparison.OrdinalIgnoreCase))
                return DatabaseAPI.Database.Classes[index];
        }
        return (Archetype)null;
    }

    public static int GetOriginByName(Archetype archetype, string iOrigin)
    {
        for (int index = 0; index <= archetype.Origin.Length - 1; ++index)
        {
            if (string.Equals(iOrigin, archetype.Origin[index], StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return 0;
    }

    public static int GetPowerByName(string iName, int iArchetype)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
        {
            int num = -1;
            if (DatabaseAPI.Database.Power[index].PowerSetID > -1)
                num = DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Power[index].PowerSetID].nArchetype;
            if (iArchetype == num | num == -1 && string.Equals(iName, DatabaseAPI.Database.Power[index].DisplayName))
                return index;
        }
        return -1;
    }

    public static IPower GetPowerByName(string name)
    {
        IPower power1;
        if (string.IsNullOrEmpty(name))
        {
            power1 = (IPower)null;
        }
        else
        {
            IPowerset powersetByName = DatabaseAPI.GetPowersetByName(name);
            if (powersetByName == null)
            {
                power1 = (IPower)null;
            }
            else
            {
                foreach (IPower power2 in powersetByName.Powers)
                {
                    if (string.Equals(power2.FullName, name, StringComparison.OrdinalIgnoreCase))
                        return power2;
                }
                power1 = (IPower)null;
            }
        }
        return power1;
    }

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
            foreach (IPowerset powerset in DatabaseAPI.Database.Powersets)
            {
                if (powerset.SetType == iSet)
                    stringList.Add(powerset.DisplayName);
            }
        }
        stringList.Sort();
        string[] strArray;
        if (stringList.Count <= 0)
            strArray = new string[1]
            {
        "No " + Enum.GetName(iSet.GetType(), (object) iSet)
            };
        else
            strArray = stringList.ToArray();
        return strArray;
    }

    public static int[] GetPowersetIndexesByGroup(PowersetGroup group)
    {
        List<int> intList = new List<int>();
        foreach (KeyValuePair<string, IPowerset> powerset in (IEnumerable<KeyValuePair<string, IPowerset>>)group.Powersets)
            intList.Add(powerset.Value.nID);
        return intList.ToArray();
    }

    public static int[] GetPowersetIndexesByGroupName(string name)
    {
        return !string.IsNullOrEmpty(name) && DatabaseAPI.Database.PowersetGroups.ContainsKey(name) ? DatabaseAPI.GetPowersetIndexesByGroup(DatabaseAPI.Database.PowersetGroups[name]) : new int[1];
    }

    public static IPowerset[] GetPowersetIndexes(Archetype at, Enums.ePowerSetType iSet)
    {
        return DatabaseAPI.GetPowersetIndexes(at.Idx, iSet);
    }

    public static IPowerset[] GetPowersetIndexes(int iAT, Enums.ePowerSetType iSet)
    {
        List<IPowerset> powersetList = new List<IPowerset>();
        if (iSet != Enums.ePowerSetType.Pool & iSet != Enums.ePowerSetType.Inherent)
        {
            for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; ++index)
            {
                if (DatabaseAPI.Database.Powersets[index].nArchetype == iAT & DatabaseAPI.Database.Powersets[index].SetType == iSet)
                    powersetList.Add(DatabaseAPI.Database.Powersets[index]);
                else if (iSet == Enums.ePowerSetType.Ancillary & DatabaseAPI.Database.Powersets[index].SetType == iSet && DatabaseAPI.Database.Powersets[index].ClassOk(iAT))
                    powersetList.Add(DatabaseAPI.Database.Powersets[index]);
            }
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; ++index)
            {
                if (DatabaseAPI.Database.Powersets[index].SetType == iSet)
                    powersetList.Add(DatabaseAPI.Database.Powersets[index]);
            }
        }
        powersetList.Sort();
        return powersetList.ToArray();
    }

    public static int ToDisplayIndex(IPowerset iPowerset, IPowerset[] iIndexes)
    {
        for (int index = 0; index <= iIndexes.Length - 1; ++index)
        {
            if (iIndexes[index].nID == iPowerset.nID)
                return index;
        }
        return iIndexes.Length > 0 ? 0 : -1;
    }

    public static int GetEnhancementByUIDName(string iName)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Enhancements[index].UID.Contains(iName))
                return index;
        }
        return -1;
    }

    public static int GetEnhancementByName(string iName)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
        {
            if (string.Equals(DatabaseAPI.Database.Enhancements[index].ShortName, iName, StringComparison.OrdinalIgnoreCase) || string.Equals(DatabaseAPI.Database.Enhancements[index].Name, iName, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return -1;
    }

    public static int GetEnhancementByName(string iName, Enums.eType iType)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Enhancements[index].TypeID == iType && (string.Equals(DatabaseAPI.Database.Enhancements[index].ShortName, iName, StringComparison.OrdinalIgnoreCase) || string.Equals(DatabaseAPI.Database.Enhancements[index].Name, iName, StringComparison.OrdinalIgnoreCase)))
                return index;
        }
        return -1;
    }

    public static int GetEnhancementByName(string iName, string iSet)
    {
        foreach (EnhancementSet enhancementSet in (List<EnhancementSet>)DatabaseAPI.Database.EnhancementSets)
        {
            if (string.Equals(enhancementSet.ShortName, iSet, StringComparison.OrdinalIgnoreCase))
            {
                foreach (int enhancement in enhancementSet.Enhancements)
                {
                    if (string.Equals(DatabaseAPI.Database.Enhancements[enhancementSet.Enhancements[enhancement]].ShortName, iName, StringComparison.OrdinalIgnoreCase))
                        return enhancementSet.Enhancements[enhancement];
                }
            }
        }
        return -1;
    }

    public static int FindEnhancement(string setName, string enhName, int iType, int fallBack)
    {
        for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; ++index)
        {
            if (DatabaseAPI.Database.Enhancements[index].TypeID == (Enums.eType)iType && string.Equals(DatabaseAPI.Database.Enhancements[index].ShortName, enhName, StringComparison.OrdinalIgnoreCase))
            {
                int num;
                if (DatabaseAPI.Database.Enhancements[index].TypeID != Enums.eType.SetO)
                    num = index;
                else if (DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[index].nIDSet].DisplayName.Equals(setName, StringComparison.OrdinalIgnoreCase))
                    num = index;
                else
                    continue;
                return num;
            }
        }
        if (fallBack > -1 & fallBack < DatabaseAPI.Database.Enhancements.Length)
            return fallBack;
        return -1;
    }
    //Pine
    public static int GetRecipeIdxByName(string iName)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Recipes.Length - 1; ++index)
        {
            if (string.Equals(DatabaseAPI.Database.Recipes[index].InternalName, iName, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return -1;
    }

    public static Recipe GetRecipeByName(string iName)
    {
        foreach (Recipe recipe in DatabaseAPI.Database.Recipes)
        {
            if (string.Equals(recipe.InternalName, iName, StringComparison.OrdinalIgnoreCase))
                return recipe;
        }
        return (Recipe)null;
    }

    public static string[] UidReferencingPowerFix(string uidPower, string uidNew = "")
    {
        string[] array = new string[0];
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Power.Length - 1; ++index1)
        {
            if (DatabaseAPI.Database.Power[index1].Requires.ReferencesPower(uidPower, uidNew))
            {
                Array.Resize<string>(ref array, array.Length + 1);
                array[array.Length - 1] = DatabaseAPI.Database.Power[index1].FullName + " (Requirement)";
            }
            for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[index1].Effects.Length - 1; ++index2)
            {
                if (DatabaseAPI.Database.Power[index1].Effects[index2].Summon == uidPower)
                {
                    DatabaseAPI.Database.Power[index1].Effects[index2].Summon = uidNew;
                    Array.Resize<string>(ref array, array.Length + 1);
                    array[array.Length - 1] = DatabaseAPI.Database.Power[index1].FullName + " (GrantPower)";
                }
            }
        }
        return array;
    }

    public static int NidFromStaticIndexEnh(int sidEnh)
    {
        int num;
        if (sidEnh < 0)
        {
            num = -1;
        }
        else
        {
            for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; ++index)
            {
                if (DatabaseAPI.Database.Enhancements[index].StaticIndex == sidEnh)
                    return index;
            }
            num = -1;
        }
        return num;
    }

    public static int NidFromUidioSet(string uidSet)
    {
        for (int index = 0; index < DatabaseAPI.Database.EnhancementSets.Count; ++index)
        {
            if (string.Equals(DatabaseAPI.Database.EnhancementSets[index].Uid, uidSet, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return -1;
    }

    public static int NidFromUidRecipe(string uidRecipe, ref int subIndex)
    {
        bool flag = subIndex > -1 & uidRecipe.Contains("_");
        subIndex = -1;
        string b = flag ? uidRecipe.Substring(0, uidRecipe.LastIndexOf("_", StringComparison.Ordinal)) : uidRecipe;
        for (int index1 = 0; index1 < DatabaseAPI.Database.Recipes.Length; ++index1)
        {
            if (string.Equals(DatabaseAPI.Database.Recipes[index1].InternalName, b, StringComparison.OrdinalIgnoreCase))
            {
                int num;
                if (!flag)
                {
                    num = index1;
                }
                else
                {
                    int startIndex = uidRecipe.LastIndexOf("_", StringComparison.Ordinal) + 1;
                    if (!(startIndex < 0 | startIndex > uidRecipe.Length - 1))
                    {
                        b = uidRecipe.Substring(startIndex);
                        for (int index2 = 0; index2 < DatabaseAPI.Database.Recipes[index1].Item.Length; ++index2)
                        {
                            if (DatabaseAPI.Database.Recipes[index1].Item[index2].Level == startIndex)
                            {
                                subIndex = index2;
                                return index1;
                            }
                        }
                        continue;
                    }
                    num = -1;
                }
                return num;
            }
        }
        return -1;
    }

    public static int NidFromUidEnh(string uidEnh)
    {
        for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; ++index)
        {
            if (string.Equals(DatabaseAPI.Database.Enhancements[index].UID, uidEnh, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return -1;
    }

    public static int NidFromUidEnhExtended(string uidEnh)
    {
        int num;
        if (!uidEnh.StartsWith("BOOSTS", true, CultureInfo.CurrentCulture))
        {
            num = DatabaseAPI.NidFromUidEnh(uidEnh);
        }
        else
        {
            for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; ++index)
            {
                if (string.Equals("BOOSTS." + DatabaseAPI.Database.Enhancements[index].UID + "." + DatabaseAPI.Database.Enhancements[index].UID, uidEnh, StringComparison.OrdinalIgnoreCase))
                    return index;
            }
            num = -1;
        }
        return num;
    }

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
        catch
        {
            return;
        }
        try
        {
            writer.Write("Mids' Hero Designer Database MK II");
            writer.Write(Database.Version);
            writer.Write(-1);
            writer.Write(DatabaseAPI.Database.Date.ToBinary());
            writer.Write(DatabaseAPI.Database.Issue);
            writer.Write("BEGIN:ARCHETYPES");
            DatabaseAPI.Database.ArchetypeVersion.StoreTo(writer);
            writer.Write(DatabaseAPI.Database.Classes.Length - 1);
            for (int index = 0; index < DatabaseAPI.Database.Classes.Length; ++index)
                DatabaseAPI.Database.Classes[index].StoreTo(ref writer);
            writer.Write("BEGIN:POWERSETS");
            DatabaseAPI.Database.PowersetVersion.StoreTo(writer);
            writer.Write(DatabaseAPI.Database.Powersets.Length - 1);
            for (int index = 0; index <= DatabaseAPI.Database.Powersets.Length - 1; ++index)
                DatabaseAPI.Database.Powersets[index].StoreTo(ref writer);
            writer.Write("BEGIN:POWERS");
            DatabaseAPI.Database.PowerVersion.StoreTo(writer);
            DatabaseAPI.Database.PowerLevelVersion.StoreTo(writer);
            DatabaseAPI.Database.PowerEffectVersion.StoreTo(writer);
            DatabaseAPI.Database.IOAssignmentVersion.StoreTo(writer);
            writer.Write(DatabaseAPI.Database.Power.Length - 1);
            for (int index = 0; index < DatabaseAPI.Database.Power.Length; ++index)
                DatabaseAPI.Database.Power[index].StoreTo(ref writer);
            writer.Write("BEGIN:SUMMONS");
            DatabaseAPI.Database.StoreEntities(writer);
            writer.Close();
            fileStream.Close();
        }
        catch (Exception ex)
        {
            writer.Close();
            fileStream.Close();
        }
    }

    public static bool LoadMainDatabase()
    {
        DatabaseAPI.ClearLookups();
        string path = Files.SelectDataFileLoad("I12.mhd");
        FileStream fileStream;
        BinaryReader reader;
        try
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader((Stream)fileStream);
        }
        catch
        {
            return false;
        }
        try
        {
            if (reader.ReadString() != "Mids' Hero Designer Database MK II")
            {
                int num1 = (int)MessageBox.Show("Expected MHD header, got something else!", "Eeeeee!");
            }
            DatabaseAPI.Database.Version = reader.ReadSingle();
            int year = reader.ReadInt32();
            if (year > 0)
            {
                int month = reader.ReadInt32();
                int day = reader.ReadInt32();
                DatabaseAPI.Database.Date = new DateTime(year, month, day);
            }
            else
                DatabaseAPI.Database.Date = DateTime.FromBinary(reader.ReadInt64());
            DatabaseAPI.Database.Issue = reader.ReadInt32();
            if (reader.ReadString() != "BEGIN:ARCHETYPES")
            {
                int num2 = (int)MessageBox.Show("Expected Archetype Data, got something else!", "Eeeeee!");
                reader.Close();
                fileStream.Close();
                return false;
            }
            DatabaseAPI.Database.ArchetypeVersion.Load(reader);
            DatabaseAPI.Database.Classes = new Archetype[reader.ReadInt32() + 1];
            for (int index = 0; index < DatabaseAPI.Database.Classes.Length; ++index)
                DatabaseAPI.Database.Classes[index] = new Archetype(reader)
                {
                    Idx = index
                };
            if (reader.ReadString() != "BEGIN:POWERSETS")
            {
                int num2 = (int)MessageBox.Show("Expected Powerset Data, got something else!", "Eeeeee!");
                reader.Close();
                fileStream.Close();
                return false;
            }
            DatabaseAPI.Database.PowersetVersion.Load(reader);
            int num3 = 0;
            DatabaseAPI.Database.Powersets = new IPowerset[reader.ReadInt32() + 1];
            for (int index = 0; index < DatabaseAPI.Database.Powersets.Length; ++index)
            {
                DatabaseAPI.Database.Powersets[index] = (IPowerset)new Powerset(reader)
                {
                    nID = index
                };
                ++num3;
                if (num3 > 10)
                {
                    num3 = 0;
                    Application.DoEvents();
                }
            }
            if (reader.ReadString() != "BEGIN:POWERS")
            {
                int num2 = (int)MessageBox.Show("Expected Power Data, got something else!", "Eeeeee!");
                reader.Close();
                fileStream.Close();
                return false;
            }
            DatabaseAPI.Database.PowerVersion.Load(reader);
            DatabaseAPI.Database.PowerLevelVersion.Load(reader);
            DatabaseAPI.Database.PowerEffectVersion.Load(reader);
            DatabaseAPI.Database.IOAssignmentVersion.Load(reader);
            DatabaseAPI.Database.Power = new IPower[reader.ReadInt32() + 1];
            for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
            {
                DatabaseAPI.Database.Power[index] = (IPower)new Power(reader);
                ++num3;
                if (num3 > 50)
                {
                    num3 = 0;
                    Application.DoEvents();
                }
            }
            if (reader.ReadString() != "BEGIN:SUMMONS")
            {
                int num2 = (int)MessageBox.Show("Expected Summon Data, got something else!", "Eeeeee!");
                reader.Close();
                fileStream.Close();
                return false;
            }
            DatabaseAPI.Database.LoadEntities(reader);
            reader.Close();
            fileStream.Close();
        }
        catch
        {
            reader.Close();
            fileStream.Close();
            return false;
        }
        return true;
    }

    public static void LoadDatabaseVersion()
    {
        var target = Files.SelectDataFileLoad("I12.mhd");
        DatabaseAPI.Database.Version = DatabaseAPI.GetDatabaseVersion(target);
    }

    static float GetDatabaseVersion(string fp)
    {
        var fName = System.Diagnostics.Debugger.IsAttached? Files.SearchUp("Data", fp) : fp;
        float num1 = -1f;
        float num2;
        if (!File.Exists(fName))
        {
            num2 = num1;
        }
        else
        {
            using (FileStream fileStream = new FileStream(fName, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader((Stream)fileStream))
                {
                    try
                    {
                        if (binaryReader.ReadString() != "Mids' Hero Designer Database MK II")
                        {
                            int num3 = (int)MessageBox.Show("Expected MHD header, got something else!");
                        }
                        num1 = binaryReader.ReadSingle();
                    }
                    catch (Exception ex)
                    {
                        num1 = -1f;
                    }
                    binaryReader.Close();
                }
                fileStream.Close();
            }
            num2 = num1;
        }
        return num2;
    }

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
            int num = (int)MessageBox.Show(ex.Message, "Error!");
            return false;
        }
        string[] strArray = FileIO.IOGrab(iStream);
        while (strArray[0] != "Level")
            strArray = FileIO.IOGrab(iStream);
        DatabaseAPI.Database.Levels = new LevelMap[50];
        for (int index = 0; index < 50; ++index)
            DatabaseAPI.Database.Levels[index] = new LevelMap((IList<string>)FileIO.IOGrab(iStream));
        List<int> intList = new List<int>() { 0 };
        for (int index = 0; index <= DatabaseAPI.Database.Levels.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Levels[index].Powers > 0)
                intList.Add(index);
        }
        DatabaseAPI.Database.Levels_MainPowers = intList.ToArray();
        iStream.Close();
        return true;
    }

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
            if (string.IsNullOrEmpty(FileIO.IOSeekReturn(streamReader, "Version:")))
                throw new EndOfStreamException("Unable to load Enhancement Class data, version header not found!");
            if (!FileIO.IOSeek(streamReader, "Origin"))
                throw new EndOfStreamException("Unable to load Origin data, section header not found!");
            string[] strArray;
            do
            {
                strArray = FileIO.IOGrab(streamReader);
                if (!(strArray[0] == "End"))
                    DatabaseAPI.Database.Origins.Add(new Origin(strArray[0], strArray[1], strArray[2]));
                else
                    break;
            }
            while (strArray[0] != "End");
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            streamReader.Close();
            return;
        }
        streamReader.Close();
    }

    public static int GetOriginIDByName(string iOrigin)
    {
        for (int index = 0; index <= DatabaseAPI.Database.Origins.Count - 1; ++index)
        {
            if (string.Equals(iOrigin, DatabaseAPI.Database.Origins[index].Name, StringComparison.OrdinalIgnoreCase))
                return index;
        }
        return 0;
    }

    public static int IsSpecialEnh(int enhID)
    {
        for (int index = 0; index < DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[enhID].nIDSet].Enhancements.Length; ++index)
        {
            if (enhID == DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[enhID].nIDSet].Enhancements[index] && DatabaseAPI.Database.EnhancementSets[DatabaseAPI.Database.Enhancements[enhID].nIDSet].SpecialBonus[index].Index.Length > 0)
                return index;
        }
        return -1;
    }

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

    public static int GetFirstValidEnhancement(int iClass)
    {
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Enhancements.Length - 1; ++index1)
        {
            for (int index2 = 0; index2 <= DatabaseAPI.Database.Enhancements[index1].ClassID.Length - 1; ++index2)
            {
                if (DatabaseAPI.Database.EnhancementClasses[DatabaseAPI.Database.Enhancements[index1].ClassID[index2]].ID == iClass)
                    return index1;
            }
        }
        return -1;
    }

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

    public static void AssignRecipeSalvageIDs()
    {
        int[] numArray = new int[7];
        string[] strArray = new string[7];
        foreach (Recipe recipe in DatabaseAPI.Database.Recipes)
        {
            foreach (Recipe.RecipeEntry recipeEntry in recipe.Item)
            {
                for (int index1 = 0; index1 <= recipeEntry.Salvage.Length - 1; ++index1)
                {
                    if (recipeEntry.Salvage[index1] == strArray[index1])
                    {
                        recipeEntry.SalvageIdx[index1] = numArray[index1];
                    }
                    else
                    {
                        recipeEntry.SalvageIdx[index1] = -1;
                        string a = recipeEntry.Salvage[index1];
                        for (int index2 = 0; index2 <= DatabaseAPI.Database.Salvage.Length - 1; ++index2)
                        {
                            if (string.Equals(a, DatabaseAPI.Database.Salvage[index2].InternalName, StringComparison.OrdinalIgnoreCase))
                            {
                                recipeEntry.SalvageIdx[index1] = index2;
                                numArray[index1] = index2;
                                strArray[index1] = recipeEntry.Salvage[index1];
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    public static void AssignRecipeIDs()
    {
        foreach (Recipe recipe in DatabaseAPI.Database.Recipes)
        {
            recipe.Enhancement = string.Empty;
            recipe.EnhIdx = -1;
        }
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Enhancements.Length - 1; ++index1)
        {
            if (!string.IsNullOrEmpty(DatabaseAPI.Database.Enhancements[index1].RecipeName))
            {
                DatabaseAPI.Database.Enhancements[index1].RecipeIDX = -1;
                string recipeName = DatabaseAPI.Database.Enhancements[index1].RecipeName;
                for (int index2 = 0; index2 <= DatabaseAPI.Database.Recipes.Length - 1; ++index2)
                {
                    if (recipeName.Equals(DatabaseAPI.Database.Recipes[index2].InternalName, StringComparison.OrdinalIgnoreCase))
                    {
                        DatabaseAPI.Database.Recipes[index2].Enhancement = DatabaseAPI.Database.Enhancements[index1].UID;
                        DatabaseAPI.Database.Recipes[index2].EnhIdx = index1;
                        DatabaseAPI.Database.Enhancements[index1].RecipeIDX = index2;
                        break;
                    }
                }
            }
        }
    }

    public static void LoadRecipes()
    {
        string path = Files.SelectDataFileLoad("Recipe.mhd");
        DatabaseAPI.Database.Recipes = new Recipe[0];
        FileStream fileStream;
        BinaryReader reader;
        try
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader((Stream)fileStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message + "\n\nRecipe database couldn't be loaded.");
            return;
        }
        if (!(reader.ReadString() != "Mids' Hero Designer Recipe Database"))
        {
            DatabaseAPI.Database.RecipeSource1 = reader.ReadString();
            DatabaseAPI.Database.RecipeSource2 = reader.ReadString();
            DatabaseAPI.Database.RecipeRevisionDate = DateTime.FromBinary(reader.ReadInt64());
            int num = 0;
            DatabaseAPI.Database.Recipes = new Recipe[reader.ReadInt32() + 1];
            for (int index = 0; index < DatabaseAPI.Database.Recipes.Length; ++index)
            {
                DatabaseAPI.Database.Recipes[index] = new Recipe(reader);
                ++num;
                if (num > 100)
                {
                    num = 0;
                    Application.DoEvents();
                }
            }
        }
        else
        {
            int num = (int)MessageBox.Show("Recipe Database header wasn't found, file may be corrupt!");
            reader.Close();
            fileStream.Close();
        }
    }

    public static void SaveRecipes()
    {
        string path = Files.SelectDataFileSave("Recipe.mhd");
        FileStream fileStream;
        BinaryWriter writer;
        try
        {
            fileStream = new FileStream(path, FileMode.Create);
            writer = new BinaryWriter((Stream)fileStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            return;
        }
        try
        {
            writer.Write("Mids' Hero Designer Recipe Database");
            writer.Write(DatabaseAPI.Database.RecipeSource1);
            writer.Write(DatabaseAPI.Database.RecipeSource2);
            writer.Write(DatabaseAPI.Database.RecipeRevisionDate.ToBinary());
            writer.Write(DatabaseAPI.Database.Recipes.Length - 1);
            for (int index = 0; index <= DatabaseAPI.Database.Recipes.Length - 1; ++index)
                DatabaseAPI.Database.Recipes[index].StoreTo(writer);
            writer.Close();
            fileStream.Close();
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            writer.Close();
            fileStream.Close();
        }
    }

    public static void LoadSalvage()
    {
        string path = Files.SelectDataFileLoad("Salvage.mhd");
        DatabaseAPI.Database.Salvage = new Salvage[0];
        FileStream fileStream;
        BinaryReader reader;
        try
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader((Stream)fileStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message + "\n\nSalvage database couldn't be loaded.");
            return;
        }
        try
        {
            if (reader.ReadString() != "Mids' Hero Designer Salvage Database")
            {
                int num = (int)MessageBox.Show("Salvage Database header wasn't found, file may be corrupt!");
                reader.Close();
                fileStream.Close();
            }
            else
            {
                DatabaseAPI.Database.Salvage = new Salvage[reader.ReadInt32() + 1];
                for (int index = 0; index < DatabaseAPI.Database.Salvage.Length; ++index)
                    DatabaseAPI.Database.Salvage[index] = new Salvage(reader);
            }
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show("Salvage Database file isn't how it should be (" + ex.Message + ")\nNo salvage loaded.");
            DatabaseAPI.Database.Salvage = new Salvage[0];
            reader.Close();
            fileStream.Close();
        }
    }

    public static void SaveSalvage()
    {
        string path = Files.SelectDataFileSave("Salvage.mhd");
        FileStream fileStream;
        BinaryWriter writer;
        try
        {
            fileStream = new FileStream(path, FileMode.Create);
            writer = new BinaryWriter((Stream)fileStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            return;
        }
        try
        {
            writer.Write("Mids' Hero Designer Salvage Database");
            writer.Write(DatabaseAPI.Database.Salvage.Length - 1);
            for (int index = 0; index <= DatabaseAPI.Database.Salvage.Length - 1; ++index)
                DatabaseAPI.Database.Salvage[index].StoreTo(writer);
            writer.Close();
            fileStream.Close();
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            writer.Close();
            fileStream.Close();
        }
    }

    public static void SaveEnhancementDb()
    {
        string path = Files.SelectDataFileSave("EnhDB.mhd");
        FileStream fileStream;
        BinaryWriter writer;
        try
        {
            fileStream = new FileStream(path, FileMode.Create);
            writer = new BinaryWriter((Stream)fileStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            return;
        }
        try
        {
            writer.Write("Mids' Hero Designer Enhancement Database");
            writer.Write(DatabaseAPI.Database.VersionEnhDb);
            writer.Write(DatabaseAPI.Database.Enhancements.Length - 1);
            for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
                DatabaseAPI.Database.Enhancements[index].StoreTo(writer);
            writer.Write(DatabaseAPI.Database.EnhancementSets.Count - 1);
            for (int index = 0; index <= DatabaseAPI.Database.EnhancementSets.Count - 1; ++index)
                DatabaseAPI.Database.EnhancementSets[index].StoreTo(writer);
            writer.Close();
            fileStream.Close();
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            writer.Close();
            fileStream.Close();
        }
    }

    public static void LoadEnhancementDb()
    {
        string path = Files.SelectDataFileLoad("EnhDB.mhd");
        DatabaseAPI.Database.Enhancements = new IEnhancement[0];
        FileStream fileStream;
        BinaryReader reader;
        try
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new BinaryReader((Stream)fileStream);
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message + "\n\nNo Enhancements have been loaded.", "EnhDB Load Failed");
            return;
        }
        try
        {
            if (reader.ReadString() != "Mids' Hero Designer Enhancement Database")
            {
                int num = (int)MessageBox.Show("Enhancement Database header wasn't found, file may be corrupt!", "Meep!");
                reader.Close();
                fileStream.Close();
            }
            else
            {
                reader.ReadSingle();
                float versionEnhDb = DatabaseAPI.Database.VersionEnhDb;
                int num1 = 0;
                DatabaseAPI.Database.Enhancements = new IEnhancement[reader.ReadInt32() + 1];
                for (int index = 0; index < DatabaseAPI.Database.Enhancements.Length; ++index)
                {
                    DatabaseAPI.Database.Enhancements[index] = (IEnhancement)new Enhancement(reader);
                    ++num1;
                    if (num1 > 5)
                    {
                        num1 = 0;
                        Application.DoEvents();
                    }
                }
                DatabaseAPI.Database.EnhancementSets = new EnhancementSetCollection();
                int num2 = reader.ReadInt32() + 1;
                for (int index = 0; index < num2; ++index)
                {
                    DatabaseAPI.Database.EnhancementSets.Add(new EnhancementSet(reader));
                    ++num1;
                    if (num1 > 5)
                    {
                        num1 = 0;
                        Application.DoEvents();
                    }
                }
                reader.Close();
                fileStream.Close();
            }
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show("Enhancement Database file isn't how it should be (" + ex.Message + ")\nNo Enhancements have been loaded.", "Huh...");
            DatabaseAPI.Database.Enhancements = new IEnhancement[0];
            reader.Close();
            fileStream.Close();
        }
    }

    public static bool LoadEnhancementClasses()
    {
        using (StreamReader streamReader = new StreamReader(Files.SelectDataFileLoad("EClasses.mhd")))
        {
            DatabaseAPI.Database.EnhancementClasses = new Enums.sEnhClass[0];
            try
            {
                if (string.IsNullOrEmpty(FileIO.IOSeekReturn(streamReader, "Version:")))
                    throw new EndOfStreamException("Unable to load Enhancement Class data, version header not found!");
                if (!FileIO.IOSeek(streamReader, "Index"))
                    throw new EndOfStreamException("Unable to load Enhancement Class data, section header not found!");
                Enums.sEnhClass[] enhancementClasses = DatabaseAPI.Database.EnhancementClasses;
                string[] strArray;
                do
                {
                    strArray = FileIO.IOGrab(streamReader);
                    if (!(strArray[0] == "End"))
                    {
                        Array.Resize<Enums.sEnhClass>(ref enhancementClasses, enhancementClasses.Length + 1);
                        enhancementClasses[enhancementClasses.Length - 1].ID = int.Parse(strArray[0]);
                        enhancementClasses[enhancementClasses.Length - 1].Name = strArray[1];
                        enhancementClasses[enhancementClasses.Length - 1].ShortName = strArray[2];
                        enhancementClasses[enhancementClasses.Length - 1].ClassID = strArray[3];
                        enhancementClasses[enhancementClasses.Length - 1].Desc = strArray[4];
                    }
                    else
                        break;
                }
                while (strArray[0] != "End");
                DatabaseAPI.Database.EnhancementClasses = enhancementClasses;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                streamReader.Close();
                return false;
            }
            streamReader.Close();
        }
        return true;
    }

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
            int num = (int)MessageBox.Show(ex.Message);
            return;
        }
        try
        {
            if (string.IsNullOrEmpty(FileIO.IOSeekReturn(streamReader, "Version:")))
                throw new EndOfStreamException("Unable to load SetType data, version header not found!");
            if (!FileIO.IOSeek(streamReader, "SetID"))
                throw new EndOfStreamException("Unable to load SetType data, section header not found!");
            string[] setTypeStringLong = DatabaseAPI.Database.SetTypeStringLong;
            string[] setTypeStringShort = DatabaseAPI.Database.SetTypeStringShort;
            string[] strArray;
            do
            {
                strArray = FileIO.IOGrab(streamReader);
                if (strArray[0] != "End")
                {
                    Array.Resize<string>(ref setTypeStringLong, setTypeStringLong.Length + 1);
                    Array.Resize<string>(ref setTypeStringShort, setTypeStringShort.Length + 1);
                    setTypeStringShort[setTypeStringShort.Length - 1] = strArray[1];
                    setTypeStringLong[setTypeStringLong.Length - 1] = strArray[2];
                }
                else
                    break;
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
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            streamReader.Close();
            return;
        }
        streamReader.Close();
    }

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
            int num = (int)MessageBox.Show(ex.Message);
            return false;
        }
        try
        {
            if (string.IsNullOrEmpty(FileIO.IOSeekReturn(streamReader, "Version:")))
                throw new EndOfStreamException("Unable to load Enhancement Maths data, version header not found!");
            if (!FileIO.IOSeek(streamReader, "EDRT"))
                throw new EndOfStreamException("Unable to load Maths data, section header not found!");
            DatabaseAPI.Database.MultED = new float[4][];
            for (int index = 0; index < 4; ++index)
                DatabaseAPI.Database.MultED[index] = new float[3];
            for (int index1 = 0; index1 <= 2; ++index1)
            {
                string[] strArray = FileIO.IOGrab(streamReader);
                for (int index2 = 0; index2 < 4; ++index2)
                    DatabaseAPI.Database.MultED[index2][index1] = float.Parse(strArray[index2 + 1]);
            }
            if (!FileIO.IOSeek(streamReader, "EGE"))
                throw new EndOfStreamException("Unable to load Maths data, section header not found!");
            DatabaseAPI.Database.MultTO = new float[1][];
            DatabaseAPI.Database.MultDO = new float[1][];
            DatabaseAPI.Database.MultSO = new float[1][];
            DatabaseAPI.Database.MultHO = new float[1][];
            string[] strArray1 = FileIO.IOGrab(streamReader);
            DatabaseAPI.Database.MultTO[0] = new float[4];
            for (int index = 0; index < 4; ++index)
                DatabaseAPI.Database.MultTO[0][index] = float.Parse(strArray1[index + 1]);
            string[] strArray2 = FileIO.IOGrab(streamReader);
            DatabaseAPI.Database.MultDO[0] = new float[4];
            for (int index = 0; index < 4; ++index)
                DatabaseAPI.Database.MultDO[0][index] = float.Parse(strArray2[index + 1]);
            string[] strArray3 = FileIO.IOGrab(streamReader);
            DatabaseAPI.Database.MultSO[0] = new float[4];
            for (int index = 0; index < 4; ++index)
                DatabaseAPI.Database.MultSO[0][index] = float.Parse(strArray3[index + 1]);
            string[] strArray4 = FileIO.IOGrab(streamReader);
            DatabaseAPI.Database.MultHO[0] = new float[4];
            for (int index = 0; index < 4; ++index)
                DatabaseAPI.Database.MultHO[0][index] = float.Parse(strArray4[index + 1]);
            if (!FileIO.IOSeek(streamReader, "LBIOE"))
                throw new EndOfStreamException("Unable to load Maths data, section header not found!");
            DatabaseAPI.Database.MultIO = new float[53][];
            for (int index1 = 0; index1 < 53; ++index1)
            {
                string[] strArray5 = FileIO.IOGrab(streamReader);
                DatabaseAPI.Database.MultIO[index1] = new float[4];
                for (int index2 = 0; index2 < 4; ++index2)
                    DatabaseAPI.Database.MultIO[index1][index2] = float.Parse(strArray5[index2 + 1]);
            }
        }
        catch (Exception ex)
        {
            int num = (int)MessageBox.Show(ex.Message);
            streamReader.Close();
            return false;
        }
        streamReader.Close();
        return true;
    }

    public static void AssignSetBonusIndexes()
    {
        foreach (EnhancementSet enhancementSet in (List<EnhancementSet>)DatabaseAPI.Database.EnhancementSets)
        {
            foreach (EnhancementSet.BonusItem bonu in enhancementSet.Bonus)
            {
                for (int index = 0; index < bonu.Index.Length; ++index)
                    bonu.Index[index] = DatabaseAPI.NidFromUidPower(bonu.Name[index]);
            }
            foreach (EnhancementSet.BonusItem specialBonu in enhancementSet.SpecialBonus)
            {
                for (int index = 0; index <= specialBonu.Index.Length - 1; ++index)
                    specialBonu.Index[index] = DatabaseAPI.NidFromUidPower(specialBonu.Name[index]);
            }
        }
    }

    public static float GetModifier(IEffect iEffect)
    {
        int iClass = 0;
        int iLevel = MidsContext.MathLevelBase;
        if (iEffect.Power == null)
        {
            if (iEffect.Enhancement == null)
                return 1f;
        }
        else
            iClass = string.IsNullOrEmpty(iEffect.Power.ForcedClass) ? (iEffect.Absorbed_Class_nID <= -1 ? MidsContext.Archetype.Idx : iEffect.Absorbed_Class_nID) : DatabaseAPI.NidFromUidClass(iEffect.Power.ForcedClass);
        if (MidsContext.MathLevelExemp > -1 && MidsContext.MathLevelExemp < MidsContext.MathLevelBase)
            iLevel = MidsContext.MathLevelExemp;
        return DatabaseAPI.GetModifier(iClass, iEffect.nModifierTable, iLevel);
    }

    static float GetModifier(int iClass, int iTable, int iLevel)

    {
        float num;
        if (iClass < 0)
            num = 0.0f;
        else if (iTable < 0)
            num = 0.0f;
        else if (iLevel < 0)
            num = 0.0f;
        else if (iClass > DatabaseAPI.Database.Classes.Length - 1)
        {
            num = 0.0f;
        }
        else
        {
            iClass = DatabaseAPI.Database.Classes[iClass].Column;
            num = iClass >= 0 ? (iTable <= DatabaseAPI.Database.AttribMods.Modifier.Length - 1 ? (iLevel <= DatabaseAPI.Database.AttribMods.Modifier[iTable].Table.Length - 1 ? (iClass <= DatabaseAPI.Database.AttribMods.Modifier[iTable].Table[iLevel].Length - 1 ? DatabaseAPI.Database.AttribMods.Modifier[iTable].Table[iLevel][iClass] : 0.0f) : 0.0f) : 0.0f) : 0.0f;
        }
        return num;
    }

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

    static void UpdateMessage(IMessager iFrm, string iMsg)

    {
        iFrm?.SetMessage(iMsg);
    }

    static void MatchArchetypeIDs()

    {
        for (int index = 0; index <= DatabaseAPI.Database.Classes.Length - 1; ++index)
        {
            DatabaseAPI.Database.Classes[index].Idx = index;
            Array.Sort<string>(DatabaseAPI.Database.Classes[index].Origin);
            DatabaseAPI.Database.Classes[index].Primary = new int[0];
            DatabaseAPI.Database.Classes[index].Secondary = new int[0];
            DatabaseAPI.Database.Classes[index].Ancillary = new int[0];
        }
    }

    static void MatchPowersetIDs()

    {
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Powersets.Length - 1; ++index1)
        {
            IPowerset powerset = DatabaseAPI.Database.Powersets[index1];
            powerset.nID = index1;
            powerset.nArchetype = DatabaseAPI.NidFromUidClass(powerset.ATClass);
            powerset.nIDTrunkSet = string.IsNullOrEmpty(powerset.UIDTrunkSet) ? -1 : DatabaseAPI.NidFromUidPowerset(powerset.UIDTrunkSet);
            powerset.nIDLinkSecondary = string.IsNullOrEmpty(powerset.UIDLinkSecondary) ? -1 : DatabaseAPI.NidFromUidPowerset(powerset.UIDLinkSecondary);
            if (powerset.UIDMutexSets.Length > 0)
            {
                powerset.nIDMutexSets = new int[powerset.UIDMutexSets.Length];
                for (int index2 = 0; index2 < powerset.UIDMutexSets.Length; ++index2)
                    powerset.nIDMutexSets[index2] = DatabaseAPI.NidFromUidPowerset(powerset.UIDMutexSets[index2]);
            }
            powerset.Power = new int[0];
            powerset.Powers = new IPower[0];
        }
    }

    static void MatchPowerIDs()

    {
        DatabaseAPI.Database.MutexList = DatabaseAPI.UidMutexAll();
        for (int index = 0; index < DatabaseAPI.Database.Power.Length; ++index)
        {
            IPower power1 = DatabaseAPI.Database.Power[index];
            if (string.IsNullOrEmpty(power1.FullName))
                power1.FullName = "Orphan." + power1.DisplayName.Replace(" ", "_");
            power1.PowerIndex = index;
            power1.PowerSetID = DatabaseAPI.NidFromUidPowerset(power1.FullSetName);
            if (power1.PowerSetID > -1)
            {
                int length = power1.PowerSet.Powers.Length;
                power1.PowerSetIndex = length;
                int[] power2 = power1.PowerSet.Power;
                Array.Resize<int>(ref power2, length + 1);
                power1.PowerSet.Power = power2;
                IPower[] powers = power1.PowerSet.Powers;
                Array.Resize<IPower>(ref powers, length + 1);
                power1.PowerSet.Powers = powers;
                power1.PowerSet.Power[length] = index;
                power1.PowerSet.Powers[length] = power1;
            }
        }
        foreach (IPower power in DatabaseAPI.Database.Power)
        {
            bool flag = false;
            if (power.PowerSet.SetType == Enums.ePowerSetType.SetBonus)
            {
                flag = power.PowerName.Contains("Slow");
                if (flag)
                {
                    power.BuffMode = Enums.eBuffMode.Debuff;
                    for (int index = 0; index < power.Effects.Length; ++index)
                        power.Effects[index].buffMode = Enums.eBuffMode.Debuff;
                }
            }
            foreach (IEffect effect in power.Effects)
            {
                if (flag)
                    effect.buffMode = Enums.eBuffMode.Debuff;
                switch (effect.EffectType)
                {
                    case Enums.eEffectType.GrantPower:
                        effect.nSummon = DatabaseAPI.NidFromUidPower(effect.Summon);
                        power.HasGrantPowerEffect = true;
                        break;
                    case Enums.eEffectType.EntCreate:
                        effect.nSummon = DatabaseAPI.NidFromUidEntity(effect.Summon);
                        break;
                    case Enums.eEffectType.PowerRedirect:
                        effect.nSummon = DatabaseAPI.NidFromUidPower(effect.Override);
                        power.HasPowerOverrideEffect = true;
                        break;
                }
            }
            power.NGroupMembership = new int[power.GroupMembership.Length];
            for (int index1 = 0; index1 < power.GroupMembership.Length; ++index1)
            {
                for (int index2 = 0; index2 < DatabaseAPI.Database.MutexList.Length; ++index2)
                {
                    if (string.Equals(DatabaseAPI.Database.MutexList[index2], power.GroupMembership[index1], StringComparison.OrdinalIgnoreCase))
                    {
                        power.NGroupMembership[index1] = index2;
                        break;
                    }
                }
            }
            power.NIDSubPower = new int[power.UIDSubPower.Length];
            for (int index = 0; index < power.UIDSubPower.Length; ++index)
                power.NIDSubPower[index] = DatabaseAPI.NidFromUidPower(power.UIDSubPower[index]);
            DatabaseAPI.MatchRequirementId(power);
        }
    }

    static void MatchRequirementId(IPower power)

    {
        if (power.Requires.ClassName.Length > 0)
        {
            power.Requires.NClassName = new int[power.Requires.ClassName.Length];
            for (int index = 0; index < power.Requires.ClassName.Length; ++index)
                power.Requires.NClassName[index] = DatabaseAPI.NidFromUidClass(power.Requires.ClassName[index]);
        }
        if (power.Requires.ClassNameNot.Length > 0)
        {
            power.Requires.NClassNameNot = new int[power.Requires.ClassNameNot.Length];
            for (int index = 0; index < power.Requires.ClassNameNot.Length; ++index)
                power.Requires.NClassNameNot[index] = DatabaseAPI.NidFromUidClass(power.Requires.ClassNameNot[index]);
        }
        if (power.Requires.PowerID.Length > 0)
        {
            power.Requires.NPowerID = new int[power.Requires.PowerID.Length][];
            for (int index1 = 0; index1 < power.Requires.PowerID.Length; ++index1)
            {
                power.Requires.NPowerID[index1] = new int[power.Requires.PowerID[index1].Length];
                for (int index2 = 0; index2 < power.Requires.PowerID[index1].Length; ++index2)
                    power.Requires.NPowerID[index1][index2] = !string.IsNullOrEmpty(power.Requires.PowerID[index1][index2]) ? DatabaseAPI.NidFromUidPower(power.Requires.PowerID[index1][index2]) : -1;
            }
        }
        if (power.Requires.PowerIDNot.Length <= 0)
            return;
        power.Requires.NPowerIDNot = new int[power.Requires.PowerIDNot.Length][];
        for (int index1 = 0; index1 < power.Requires.PowerIDNot.Length; ++index1)
        {
            power.Requires.NPowerIDNot[index1] = new int[power.Requires.PowerIDNot[index1].Length];
            for (int index2 = 0; index2 < power.Requires.PowerIDNot[index1].Length; ++index2)
                power.Requires.NPowerIDNot[index1][index2] = !string.IsNullOrEmpty(power.Requires.PowerIDNot[index1][index2]) ? DatabaseAPI.NidFromUidPower(power.Requires.PowerIDNot[index1][index2]) : -1;
        }
    }

    static void SetPowersetsFromGroups()

    {
        for (int index1 = 0; index1 < DatabaseAPI.Database.Classes.Length; ++index1)
        {
            Archetype archetype = DatabaseAPI.Database.Classes[index1];
            List<int> intList1 = new List<int>();
            List<int> intList2 = new List<int>();
            List<int> intList3 = new List<int>();
            for (int index2 = 0; index2 < DatabaseAPI.Database.Powersets.Length; ++index2)
            {
                IPowerset powerset = DatabaseAPI.Database.Powersets[index2];
                if (powerset.Powers.Length > 0)
                    powerset.Powers[0].SortOverride = true;
                if (string.Equals(powerset.GroupName, archetype.PrimaryGroup, StringComparison.OrdinalIgnoreCase))
                {
                    intList1.Add(index2);
                    if (powerset.nArchetype < 0)
                        powerset.nArchetype = index1;
                }
                if (string.Equals(powerset.GroupName, archetype.SecondaryGroup, StringComparison.OrdinalIgnoreCase))
                {
                    intList2.Add(index2);
                    if (powerset.nArchetype < 0)
                        powerset.nArchetype = index1;
                }
                if (string.Equals(powerset.GroupName, archetype.EpicGroup, StringComparison.OrdinalIgnoreCase) && (powerset.nArchetype == index1 || powerset.Powers.Length > 0 && powerset.Powers[0].Requires.ClassOk(archetype.ClassName)))
                    intList3.Add(index2);
            }
            archetype.Primary = intList1.ToArray();
            archetype.Secondary = intList2.ToArray();
            archetype.Ancillary = intList3.ToArray();
        }
    }

    public static void MatchEnhancementIDs()
    {
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Power.Length - 1; ++index1)
        {
            List<int> intList = new List<int>();
            for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[index1].BoostsAllowed.Length - 1; ++index2)
            {
                int index3 = DatabaseAPI.EnhancementClassIdFromName(DatabaseAPI.Database.Power[index1].BoostsAllowed[index2]);
                if (index3 > -1)
                    intList.Add(DatabaseAPI.Database.EnhancementClasses[index3].ID);
            }
            DatabaseAPI.Database.Power[index1].Enhancements = intList.ToArray();
        }
        for (int index = 0; index <= DatabaseAPI.Database.EnhancementSets.Count - 1; ++index)
            DatabaseAPI.Database.EnhancementSets[index].Enhancements = new int[0];
        bool flag = false;
        string str = string.Empty;
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Enhancements.Length - 1; ++index1)
        {
            IEnhancement enhancement = DatabaseAPI.Database.Enhancements[index1];
            if (enhancement.TypeID == Enums.eType.SetO && !string.IsNullOrEmpty(enhancement.UIDSet))
            {
                int index2 = DatabaseAPI.NidFromUidioSet(enhancement.UIDSet);
                if (index2 > -1)
                {
                    enhancement.nIDSet = index2;
                    Array.Resize<int>(ref DatabaseAPI.Database.EnhancementSets[index2].Enhancements, DatabaseAPI.Database.EnhancementSets[index2].Enhancements.Length + 1);
                    DatabaseAPI.Database.EnhancementSets[index2].Enhancements[DatabaseAPI.Database.EnhancementSets[index2].Enhancements.Length - 1] = index1;
                }
                else
                {
                    str = str + enhancement.UIDSet + enhancement.Name + "\n";
                    flag = true;
                }
            }
        }
        if (!flag)
            return;
        int num = (int)MessageBox.Show("One or more enhancements had difficulty being matched to their invention set. You should check the database for misplaced Invention Set enhancements.\n" + str, "Mismatch Detected");
    }

    static int EnhancementClassIdFromName(string iName)

    {
        int num;
        if (string.IsNullOrEmpty(iName))
        {
            num = -1;
        }
        else
        {
            for (int index = 0; index <= DatabaseAPI.Database.EnhancementClasses.Length - 1; ++index)
            {
                if (string.Equals(DatabaseAPI.Database.EnhancementClasses[index].ClassID, iName, StringComparison.OrdinalIgnoreCase))
                    return index;
            }
            num = -1;
        }
        return num;
    }

    static void MatchModifierIDs()

    {
        foreach (IPower power in DatabaseAPI.Database.Power)
        {
            foreach (IEffect effect in power.Effects)
                effect.nModifierTable = DatabaseAPI.NidFromUidAttribMod(effect.ModifierTable);
        }
    }

    public static void MatchSummonIDs()
    {
        for (int index1 = 0; index1 <= DatabaseAPI.Database.Entities.Length - 1; ++index1)
        {
            SummonedEntity entity = DatabaseAPI.Database.Entities[index1];
            entity.nID = index1;
            entity.nClassID = DatabaseAPI.NidFromUidClass(entity.ClassName);
            entity.nPowerset = new int[entity.PowersetFullName.Length];
            for (int index2 = 0; index2 <= entity.PowersetFullName.Length - 1; ++index2)
                entity.nPowerset[index2] = DatabaseAPI.NidFromUidPowerset(entity.PowersetFullName[index2]);
            entity.nUpgradePower = new int[entity.UpgradePowerFullName.Length];
            for (int index2 = 0; index2 <= entity.UpgradePowerFullName.Length - 1; ++index2)
                entity.nUpgradePower[index2] = DatabaseAPI.NidFromUidPower(entity.UpgradePowerFullName[index2]);
        }
    }

    public static void AssignStaticIndexValues()
    {
        int num1 = -2;
        for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Power[index].StaticIndex > -1 && DatabaseAPI.Database.Power[index].StaticIndex > num1)
                num1 = DatabaseAPI.Database.Power[index].StaticIndex;
        }
        if (num1 < -1)
            num1 = -1;
        for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Power[index].StaticIndex < 0)
            {
                ++num1;
                DatabaseAPI.Database.Power[index].StaticIndex = num1;
            }
        }
        int num2 = -2;
        for (int index = 1; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Enhancements[index].StaticIndex > -1 && DatabaseAPI.Database.Enhancements[index].StaticIndex > num2)
                num2 = DatabaseAPI.Database.Enhancements[index].StaticIndex;
        }
        if (num2 < -1)
            num2 = -1;
        for (int index = 1; index <= DatabaseAPI.Database.Enhancements.Length - 1; ++index)
        {
            if (DatabaseAPI.Database.Enhancements[index].StaticIndex < 1)
            {
                ++num2;
                DatabaseAPI.Database.Enhancements[index].StaticIndex = num2;
            }
        }
        DatabaseAPI.SaveMainDatabase();
        DatabaseAPI.SaveEnhancementDb();
    }
}
