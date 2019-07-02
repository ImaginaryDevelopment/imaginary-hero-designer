
using System;
using System.Collections.Generic;
using System.IO;
using HeroDesigner.Schema;

public static class Enums
{
    public static bool MezDurationEnhancable(eMez mezEnum)
    {
        return mezEnum == eMez.Confused || mezEnum == eMez.Held || (mezEnum == eMez.Immobilized || mezEnum == eMez.Placate) || (mezEnum == eMez.Sleep || mezEnum == eMez.Stunned || (mezEnum == eMez.Taunt || mezEnum == eMez.Terrorized)) || mezEnum == eMez.Untouchable;
    }

    public static string GetEffectName(eEffectType iID)
    {
        return iID.ToString();
    }

    public static string GetEffectNameShort(eEffectType iID)
    {
        return iID != eEffectType.Endurance ? ((eEffectTypeShort)iID).ToString() : "End";
    }

    public static string GetMezName(eMezShort iID)
    {
        return ((eMez)iID).ToString();
    }

    public static string GetMezNameShort(eMezShort iID)
    {
        return iID.ToString();
    }

    public static string GetDamageName(eDamage iID)
    {
        return iID.ToString();
    }

    public static string GetDamageNameShort(eDamage iID)
    {
        return ((eDamageShort)iID).ToString();
    }

    public static string GetRelativeString(eEnhRelative iRel, bool onlySign)
    {
        if (onlySign)
        {
            switch (iRel)
            {
                case eEnhRelative.MinusThree:
                    return "---";
                case eEnhRelative.MinusTwo:
                    return "--";
                case eEnhRelative.MinusOne:
                    return "-";
                case eEnhRelative.Even:
                    return "";
                case eEnhRelative.PlusOne:
                    return "+";
                case eEnhRelative.PlusTwo:
                    return "++";
                case eEnhRelative.PlusThree:
                    return "+++";
                case eEnhRelative.PlusFour:
                    return "+4";
                case eEnhRelative.PlusFive:
                    return "+5";
            }
        }
        else
        {
            switch (iRel)
            {
                case eEnhRelative.MinusThree:
                    return "-3";
                case eEnhRelative.MinusTwo:
                    return "-2";
                case eEnhRelative.MinusOne:
                    return "-1";
                case eEnhRelative.Even:
                    return "";
                case eEnhRelative.PlusOne:
                    return "+1";
                case eEnhRelative.PlusTwo:
                    return "+2";
                case eEnhRelative.PlusThree:
                    return "+3";
                case eEnhRelative.PlusFour:
                    return "+4";
                case eEnhRelative.PlusFive:
                    return "+5";
            }
        }
        return "";
    }

    // take a CSV string of flag names and convert into the total value
    public static int StringToFlaggedEnum(string iStr, object eEnum, bool noFlag = false)
    {
        int num1 = 0;
        iStr = iStr.ToUpper();
        string[] strArray1;
        if (!iStr.Contains(","))
            strArray1 = iStr.Split(' ');
        else
            strArray1 = StringToArray(iStr);
        string[] strArray2 = strArray1;
        int num2;
        if (strArray2.Length < 1)
        {
            num2 = num1;
        }
        else
        {
            string[] names = Enum.GetNames(eEnum.GetType());
            Array values = Enum.GetValues(eEnum.GetType());
            for (int index = 0; index < names.Length; ++index)
                names[index] = names[index].ToUpper();
            for (int index1 = 0; index1 < strArray2.Length; ++index1)
            {
                if (strArray2[index1].Length > 0)
                {
                    int index2 = Array.IndexOf<string>(names, strArray2[index1]);
                    if (index2 > -1)
                    {
                        if (noFlag)
                            return (int)values.GetValue(index2);
                        num1 += (int)values.GetValue(index2);
                    }
                }
            }
            num2 = num1;
        }
        return num2;
    }

    public static T[] StringToEnumArray<T>(string iStr, Type eEnum)
    {
        List<T> objList = new List<T>();
        iStr = iStr.ToUpper();
        string[] strArray1;
        if (!iStr.Contains(","))
            strArray1 = iStr.Split(' ');
        else
            strArray1 = StringToArray(iStr);
        string[] strArray2 = strArray1;
        T[] array;
        if (strArray2.Length < 1)
        {
            array = objList.ToArray();
        }
        else
        {
            string[] names = Enum.GetNames(eEnum);
            Array values = Enum.GetValues(eEnum);
            for (int index = 0; index < names.Length; ++index)
                names[index] = names[index].ToUpper();
            for (int index1 = 0; index1 < strArray2.Length; ++index1)
            {
                if (strArray2[index1].Length > 0)
                {
                    int index2 = Array.IndexOf<string>(names, strArray2[index1]);
                    if (index2 > -1)
                        objList.Add((T)values.GetValue(index2));
                }
            }
            array = objList.ToArray();
        }
        return array;
    }

    // check if the value is a valid enum value of whatever sample enum value is passed in eEnum
    public static bool IsEnumValue(string value, object eEnum)
    {
        bool flag;
        if (value == null)
        {
            flag = false;
        }
        else
        {
            string[] names = Enum.GetNames(eEnum.GetType());
            value = value.ToUpper();
            for (int index = 0; index < names.Length; ++index)
                names[index] = names[index].ToUpper();
            flag = Array.IndexOf<string>(names, value) > -1;
        }
        return flag;
    }

    public static string[] StringToArray(string iStr)
    {
        string[] strArray1 = new string[0];
        string[] strArray2;
        if (iStr == null)
            strArray2 = strArray1;
        else if (string.IsNullOrEmpty(iStr))
        {
            strArray2 = strArray1;
        }
        else
        {
            char[] chArray = new char[1] { ',' };
            iStr = iStr.Replace(", ", ",");
            string[] array = iStr.Split(chArray);
            Array.Sort<string>(array);
            strArray2 = array;
        }
        return strArray2;
    }

    public static string GetGroupedDamage(bool[] iDamage, bool shortForm)
    {
        string str1;
        if (iDamage.Length < Enum.GetValues(eDamage.None.GetType()).Length - 1)
        {
            str1 = "Error: Array Length Mismatch";
        }
        else
        {
            string str2 = "";
            if (iDamage[1] && iDamage[2] && (iDamage[3] && iDamage[4]) && (iDamage[5] && iDamage[6] && iDamage[8]) && iDamage[7])
            {
                str2 = "All";
            }
            else
            {
                for (int index = 0; index < iDamage.Length; ++index)
                {
                    if (iDamage[index])
                    {
                        string str3 = shortForm ? GetDamageNameShort((eDamage)index) : GetDamageName((eDamage)index);
                        if (!string.IsNullOrEmpty(str2))
                            str2 += ",";
                        str2 += str3;
                    }
                }
            }
            str1 = str2;
        }
        return str1;
    }

    public static string GetGroupedDefense(bool[] iDamage, bool shortForm)
    {
        string str1;
        if (iDamage.Length < Enum.GetValues(eDamage.None.GetType()).Length - 1)
        {
            str1 = "Error: Array Length Mismatch";
        }
        else
        {
            string str2 = "";
            if (iDamage[1] && iDamage[2] && (iDamage[3] && iDamage[4]) && (iDamage[5] && iDamage[6] && iDamage[8]) && iDamage[7])
                str2 = "All";
            else if (!iDamage[1] && !iDamage[2] && (!iDamage[3] && !iDamage[4]) && (!iDamage[5] && !iDamage[6] && !iDamage[8]) && !iDamage[7])
            {
                str2 = "All";
            }
            else
            {
                for (int index = 0; index < iDamage.Length; ++index)
                {
                    if (iDamage[index])
                    {
                        string str3 = shortForm ? GetDamageNameShort((eDamage)index) : GetDamageName((eDamage)index);
                        if (!string.IsNullOrEmpty(str2))
                            str2 += ",";
                        str2 += str3;
                    }
                }
            }
            str1 = str2;
        }
        return str1;
    }

    public static string GetGroupedMez(bool[] iMez, bool shortForm)
    {
        string str1;
        if (iMez.Length < Enum.GetValues(eMez.None.GetType()).Length - 1)
        {
            str1 = "Error: Array Length Mismatch";
        }
        else
        {
            string str2 = "";
            if (iMez[1] && iMez[2] && iMez[10] && iMez[9])
                str2 = "Mez";
            else if (iMez[4] && iMez[5] && (iMez[1] && iMez[2]) && iMez[10] && iMez[9])
            {
                str2 = "Knocked";
            }
            else
            {
                for (int index = 0; index < iMez.Length; ++index)
                {
                    if (iMez[index])
                    {
                        string str3 = shortForm ? GetMezNameShort((eMezShort)index) : GetMezName((eMezShort)index);
                        if (!string.IsNullOrEmpty(str2))
                            str2 += ",";
                        str2 += str3;
                    }
                }
            }
            str1 = str2;
        }
        return str1;
    }


    public struct sEnhClass
    {
        public int ID;
        public string Name;
        public string ShortName;
        public string ClassID;
        public string Desc;
    }


    public struct sTwinID
    {
        public int ID;
        public int SubID;
    }

    public struct sEffect
    {
        public eEffMode Mode;
        public eBuffDebuff BuffMode;
        public sTwinID Enhance;
        public eSchedule Schedule;
        public float Multiplier;
        public IEffect FX;

        public void Assign(sEffect effect)
        {
            this.Mode = effect.Mode;
            this.BuffMode = effect.BuffMode;
            this.Enhance.ID = effect.Enhance.ID;
            this.Enhance.SubID = effect.Enhance.SubID;
            this.Schedule = effect.Schedule;
            this.Multiplier = effect.Multiplier;
            if (effect.FX == null)
                return;
            this.FX = (IEffect)effect.FX.Clone();
        }
    }

    public struct ShortFX
    {
        public int[] Index;
        public float[] Value;
        public float Sum;

        public bool Present
        {
            get
            {
                return this.Index != null && this.Index.Length >= 1 && this.Index[0] != -1;
            }
        }

        public bool Multiple
        {
            get
            {
                return this.Index != null && this.Index.Length > 1;
            }
        }

        public int Max
        {
            get
            {
                float num1 = 0.0f;
                int num2 = 0;
                int num3;
                if (this.Present)
                {
                    for (int index = 0; index < this.Value.Length; ++index)
                    {
                        if ((double)this.Value[index] > (double)num1)
                        {
                            num1 = this.Value[index];
                            num2 = index;
                        }
                    }
                    num3 = num2;
                }
                else
                    num3 = -1;
                return num3;
            }
        }

        public void Add(int iIndex, float iValue)
        {
            if (this.Value == null)
            {
                this.Value = new float[0];
                this.Index = new int[0];
                this.Sum = 0.0f;
            }
            Array.Resize<float>(ref this.Value, this.Value.Length + 1);
            Array.Resize<int>(ref this.Index, this.Index.Length + 1);
            this.Value[this.Value.Length - 1] = iValue;
            this.Index[this.Index.Length - 1] = iIndex;
            this.Sum += iValue;
        }

        public void Remove(int iIndex)
        {
            float[] numArray1 = new float[this.Value.Length - 1];
            int[] numArray2 = new int[this.Index.Length - 1];
            int index1 = 0;
            for (int index2 = 0; index2 <= this.Index.Length - 1; ++index2)
            {
                if (index2 != iIndex)
                {
                    numArray1[index1] = this.Value[index2];
                    numArray2[index1] = this.Index[index2];
                    ++index1;
                }
            }
            this.Value = numArray1;
            this.Index = numArray2;
        }

        public void Assign(ShortFX iFX)
        {
            if (iFX.Present)
            {
                this.Index = iFX.Index;
                this.Value = iFX.Value;
                this.Sum = iFX.Sum;
            }
            else
            {
                this.Index = new int[0];
                this.Value = new float[0];
                this.Sum = 0.0f;
            }
        }

        public void Multiply()
        {
            if (this.Value == null)
                return;
            for (int index = 0; index <= this.Value.Length - 1; ++index)
                this.Value[index] *= 100f;
            this.Sum *= 100f;
        }

        public void ReSum()
        {
            this.Sum = 0.0f;
            for (int index = 0; index < this.Value.Length; ++index)
                this.Sum += this.Value[index];
        }
    }

    public struct CompMap
    {
        public const int UBound = 21;
        public int[] IdxAT;
        public int[] IdxSet;
        public int[,] Map;

        public void Init()
        {
            this.IdxAT = new int[2];
            this.IdxSet = new int[2];
            this.Map = new int[21, 2];
            for (int index = 0; index < 21; ++index)
            {
                this.Map[index, 0] = -1;
                this.Map[index, 1] = -1;
            }
        }
    }

    public struct CompOverride
    {
        public string Powerset;
        public string Power;
        public string Override;
    }

    public struct BuffsX
    {
        public float[] Effect;
        public float[] EffectAux;
        public float[] Mez;
        public float[] MezRes;
        public float[] Damage;
        public float[] Defense;
        public float[] Resistance;
        public float[] StatusProtection;
        public float[] StatusResistance;
        public float[] DebuffResistance;
        public float MaxEnd;

        public void Reset()
        {
            this.MaxEnd = 0.0f;
            this.Effect = new float[Enum.GetValues(eEffectType.None.GetType()).Length];
            this.EffectAux = new float[this.Effect.Length - 1];
            this.Mez = new float[Enum.GetValues(eMez.None.GetType()).Length];
            this.MezRes = new float[Enum.GetValues(eMez.None.GetType()).Length];
            this.Damage = new float[Enum.GetValues(eDamage.None.GetType()).Length];
            this.Defense = new float[Enum.GetValues(eDamage.None.GetType()).Length];
            this.Resistance = new float[Enum.GetValues(eDamage.None.GetType()).Length];
            this.StatusProtection = new float[Enum.GetValues(eMez.None.GetType()).Length];
            this.StatusResistance = new float[Enum.GetValues(eMez.None.GetType()).Length];
            this.DebuffResistance = new float[Enum.GetValues(eEffectType.None.GetType()).Length];
        }
    }

    public class VersionData
    {
        public DateTime RevisionDate = new DateTime(0L);
        public string SourceFile = "";
        public int Revision;

        public void Load(BinaryReader reader)
        {
            this.Revision = reader.ReadInt32();
            this.RevisionDate = DateTime.FromBinary(reader.ReadInt64());
            this.SourceFile = reader.ReadString();
        }

        public void StoreTo(BinaryWriter writer)
        {
            writer.Write(this.Revision);
            writer.Write(this.RevisionDate.ToBinary());
            writer.Write(FileIO.StripPath(this.SourceFile));
        }
    }
}
