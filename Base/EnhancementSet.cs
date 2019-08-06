
using System;
using System.IO;
using System.Text;

public class EnhancementSet
{
    public string DisplayName = string.Empty;
    public string ShortName = string.Empty;
    public string Desc = string.Empty;
    public string Image = string.Empty;
    public BonusItem[] Bonus = new BonusItem[5];
    public BonusItem[] SpecialBonus = new BonusItem[6];
    public string Uid = string.Empty;
    public Enums.eSetType SetType;
    public int[] Enhancements;
    public int ImageIdx;
    public int LevelMin;
    public int LevelMax;

    public void InitBonus()
    {
        for (int index = 0; index <= Bonus.Length - 1; ++index)
        {
            Bonus[index].Special = -1;
            Bonus[index].AltString = string.Empty;
            Bonus[index].Name = new string[0];
            Bonus[index].Index = new int[0];
        }
        for (int index = 0; index <= SpecialBonus.Length - 1; ++index)
        {
            SpecialBonus[index].Special = -1;
            SpecialBonus[index].AltString = string.Empty;
            SpecialBonus[index].Name = new string[0];
            SpecialBonus[index].Index = new int[0];
        }
    }

    public string GetEffectString(int index, bool special, bool longForm = false)
    {
        BonusItem[] bonusItemArray = special ? SpecialBonus : Bonus;
        string str1;
        if (index < 0 | index > bonusItemArray.Length - 1)
            str1 = string.Empty;
        else if (!string.IsNullOrEmpty(bonusItemArray[index].AltString))
        {
            str1 = "+" + bonusItemArray[index].AltString;
        }
        else
        {
            string empty1 = string.Empty;
            for (int index1 = 0; index1 <= bonusItemArray[index].Name.Length - 1; ++index1)
            {
                if (bonusItemArray[index].Index[index1] < 0 | bonusItemArray[index].Index[index1] > DatabaseAPI.Database.Power.Length - 1)
                    return string.Empty;
                string empty2 = string.Empty;
                int[] returnMask = new int[0];
                DatabaseAPI.Database.Power[bonusItemArray[index].Index[index1]].GetEffectStringGrouped(0, ref empty2, ref returnMask, !longForm, true);
                if (!string.IsNullOrEmpty(empty2))
                    empty1 += empty2;
                for (int index2 = 0; index2 <= DatabaseAPI.Database.Power[bonusItemArray[index].Index[index1]].Effects.Length - 1; ++index2)
                {
                    bool flag = false;
                    for (int index3 = 0; index3 <= returnMask.Length - 1; ++index3)
                    {
                        if (index2 == returnMask[index3])
                            flag = true;
                    }
                    if (!flag)
                    {
                        if (!string.IsNullOrEmpty(empty1))
                            empty1 += ", ";
                        string str2 = longForm ? DatabaseAPI.Database.Power[bonusItemArray[index].Index[index1]].Effects[index2].BuildEffectString(true) : DatabaseAPI.Database.Power[bonusItemArray[index].Index[index1]].Effects[index2].BuildEffectStringShort(false, true);
                        if (str2.Contains("EndRec"))
                            str2 = str2.Replace("EndRec", "Recovery");
                        empty1 += str2;
                    }
                }
            }
            str1 = empty1;
        }
        return str1;
    }

    public EnhancementSet()
    {
        DisplayName = string.Empty;
        ShortName = string.Empty;
        Desc = string.Empty;
        SetType = Enums.eSetType.Untyped;
        Enhancements = new int[0];
        Image = string.Empty;
        InitBonus();
        LevelMin = 0;
        LevelMax = 52;
    }

    public EnhancementSet(EnhancementSet iIOSet)
    {
        DisplayName = iIOSet.DisplayName;
        ShortName = iIOSet.ShortName;
        Desc = iIOSet.Desc;
        SetType = iIOSet.SetType;
        Image = iIOSet.Image;
        LevelMin = iIOSet.LevelMin;
        LevelMax = iIOSet.LevelMax;
        Enhancements = (int[])iIOSet.Enhancements.Clone();
        Bonus = new BonusItem[iIOSet.Bonus.Length];
        for (int index = 0; index <= Bonus.Length - 1; ++index)
            Bonus[index].Assign(iIOSet.Bonus[index]);
        SpecialBonus = new BonusItem[iIOSet.SpecialBonus.Length];
        for (int index = 0; index <= SpecialBonus.Length - 1; ++index)
            SpecialBonus[index].Assign(iIOSet.SpecialBonus[index]);
        Uid = iIOSet.Uid;
    }

    public EnhancementSet(BinaryReader reader)
    {
        DisplayName = reader.ReadString();
        ShortName = reader.ReadString();
        Uid = reader.ReadString();
        Desc = reader.ReadString();
        SetType = (Enums.eSetType)reader.ReadInt32();
        Image = reader.ReadString();
        LevelMin = reader.ReadInt32();
        LevelMax = reader.ReadInt32();
        Enhancements = new int[reader.ReadInt32() + 1];
        for (int index = 0; index <= Enhancements.Length - 1; ++index)
            Enhancements[index] = reader.ReadInt32();
        InitBonus();
        Bonus = new BonusItem[reader.ReadInt32() + 1];
        for (int index1 = 0; index1 < Bonus.Length; ++index1)
        {
            Bonus[index1].Special = reader.ReadInt32();
            Bonus[index1].AltString = reader.ReadString();
            Bonus[index1].PvMode = (Enums.ePvX)reader.ReadInt32();
            Bonus[index1].Slotted = reader.ReadInt32();
            Bonus[index1].Name = new string[reader.ReadInt32() + 1];
            Bonus[index1].Index = new int[Bonus[index1].Name.Length];
            for (int index2 = 0; index2 < Bonus[index1].Name.Length; ++index2)
            {
                Bonus[index1].Name[index2] = reader.ReadString();
                Bonus[index1].Index[index2] = reader.ReadInt32();
            }
        }
        SpecialBonus = new BonusItem[reader.ReadInt32() + 1];
        for (int index1 = 0; index1 < SpecialBonus.Length; ++index1)
        {
            SpecialBonus[index1].Special = reader.ReadInt32();
            SpecialBonus[index1].AltString = reader.ReadString();
            SpecialBonus[index1].Name = new string[reader.ReadInt32() + 1];
            SpecialBonus[index1].Index = new int[SpecialBonus[index1].Name.Length];
            for (int index2 = 0; index2 < SpecialBonus[index1].Name.Length; ++index2)
            {
                SpecialBonus[index1].Name[index2] = reader.ReadString();
                SpecialBonus[index1].Index[index2] = reader.ReadInt32();
            }
        }
    }

    public void StoreTo(BinaryWriter writer)
    {
        writer.Write(DisplayName);
        writer.Write(ShortName);
        writer.Write(Uid);
        writer.Write(Desc);
        writer.Write((int)SetType);
        writer.Write(Image);
        writer.Write(LevelMin);
        writer.Write(LevelMax);
        writer.Write(Enhancements.Length - 1);
        for (int index = 0; index <= Enhancements.Length - 1; ++index)
            writer.Write(Enhancements[index]);
        writer.Write(Bonus.Length - 1);
        for (int index1 = 0; index1 <= Bonus.Length - 1; ++index1)
        {
            writer.Write(Bonus[index1].Special);
            writer.Write(Bonus[index1].AltString);
            writer.Write((int)Bonus[index1].PvMode);
            writer.Write(Bonus[index1].Slotted);
            writer.Write(Bonus[index1].Name.Length - 1);
            for (int index2 = 0; index2 <= Bonus[index1].Name.Length - 1; ++index2)
            {
                writer.Write(Bonus[index1].Name[index2]);
                writer.Write(Bonus[index1].Index[index2]);
            }
        }
        writer.Write(SpecialBonus.Length - 1);
        for (int index1 = 0; index1 <= SpecialBonus.Length - 1; ++index1)
        {
            writer.Write(SpecialBonus[index1].Special);
            writer.Write(SpecialBonus[index1].AltString);
            writer.Write(SpecialBonus[index1].Name.Length - 1);
            for (int index2 = 0; index2 <= SpecialBonus[index1].Name.Length - 1; ++index2)
            {
                writer.Write(SpecialBonus[index1].Name[index2]);
                writer.Write(SpecialBonus[index1].Index[index2]);
            }
        }
    }

    public bool ImportFromCSV(string iCSV)
    {
        bool flag;
        if (iCSV == null)
            flag = false;
        else if (string.IsNullOrEmpty(iCSV))
        {
            flag = false;
        }
        else
        {
            string[] array = CSV.ToArray(iCSV);
            DisplayName = array[1];
            ShortName = GenerateShortName(DisplayName);
            Uid = array[0];
            LevelMin = int.Parse(array[3]) - 1;
            LevelMax = int.Parse(array[4]) - 1;
            string str = array[2];
            for (int index = 0; index < DatabaseAPI.Database.SetTypeStringLong.Length; ++index)
            {
                if (str == DatabaseAPI.Database.SetTypeStringLong[index])
                    SetType = (Enums.eSetType)index;
            }
            flag = true;
        }
        return flag;
    }

    static string GenerateShortName(string displayName)

    {
        string[] strArray = displayName.Split(' ');
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string str1 in strArray)
        {
            string str2 = str1;
            if (str2.Length > 4)
                str2 = str2.Replace("a", string.Empty).Replace("e", string.Empty).Replace("i", string.Empty).Replace("o", string.Empty).Replace("u", string.Empty);
            if (string.IsNullOrEmpty(str2))
                str2 = str1;
            stringBuilder.Append(str2.Length > 3 ? str2.Substring(0, 3) : str2);
        }
        return stringBuilder.Length > 9 ? stringBuilder.ToString().Substring(0, 9) : stringBuilder.ToString();
    }

    public struct BonusItem
    {
        public int Special;
        public string[] Name;
        public int[] Index;
        public string AltString;
        public Enums.ePvX PvMode;
        public int Slotted;

        public void Assign(BonusItem iBi)
        {
            Special = iBi.Special;
            AltString = iBi.AltString;
            Name = new string[iBi.Name.Length];
            Index = new int[iBi.Index.Length];
            Array.Copy(iBi.Name, Name, iBi.Name.Length);
            Array.Copy(iBi.Index, Index, iBi.Index.Length);
            PvMode = iBi.PvMode;
            Slotted = iBi.Slotted;
        }
    }
}
