using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200002D RID: 45
public static class Enums
{
    // Token: 0x060005A4 RID: 1444 RVA: 0x00023918 File Offset: 0x00021B18
    public static bool MezDurationEnhancable(Enums.eMez mezEnum)
    {
        return mezEnum == Enums.eMez.Confused || mezEnum == Enums.eMez.Held || mezEnum == Enums.eMez.Immobilized || mezEnum == Enums.eMez.Placate || mezEnum == Enums.eMez.Sleep || mezEnum == Enums.eMez.Stunned || mezEnum == Enums.eMez.Taunt || mezEnum == Enums.eMez.Terrorized || mezEnum == Enums.eMez.Untouchable;
    }

    // Token: 0x060005A5 RID: 1445 RVA: 0x00023958 File Offset: 0x00021B58
    public static string GetEffectName(Enums.eEffectType iID)
    {
        return iID.ToString();
    }

    // Token: 0x060005A6 RID: 1446 RVA: 0x00023978 File Offset: 0x00021B78
    public static string GetEffectNameShort(Enums.eEffectType iID)
    {
        string result;
        if (iID == Enums.eEffectType.Endurance)
        {
            result = "End";
        }
        else
        {
            result = ((Enums.eEffectTypeShort)iID).ToString();
        }
        return result;
    }

    // Token: 0x060005A7 RID: 1447 RVA: 0x000239B0 File Offset: 0x00021BB0
    public static string GetMezName(Enums.eMezShort iID)
    {
        return ((Enums.eMez)iID).ToString();
    }

    // Token: 0x060005A8 RID: 1448 RVA: 0x000239D0 File Offset: 0x00021BD0
    public static string GetMezNameShort(Enums.eMezShort iID)
    {
        return iID.ToString();
    }

    // Token: 0x060005A9 RID: 1449 RVA: 0x000239F0 File Offset: 0x00021BF0
    public static string GetDamageName(Enums.eDamage iID)
    {
        return iID.ToString();
    }

    // Token: 0x060005AA RID: 1450 RVA: 0x00023A10 File Offset: 0x00021C10
    public static string GetDamageNameShort(Enums.eDamage iID)
    {
        return ((Enums.eDamageShort)iID).ToString();
    }

    // Token: 0x060005AB RID: 1451 RVA: 0x00023A30 File Offset: 0x00021C30
    public static string GetRelativeString(Enums.eEnhRelative iRel, bool onlySign)
    {
        if (onlySign)
        {
            switch (iRel)
            {
                case Enums.eEnhRelative.MinusThree:
                    return "---";
                case Enums.eEnhRelative.MinusTwo:
                    return "--";
                case Enums.eEnhRelative.MinusOne:
                    return "-";
                case Enums.eEnhRelative.Even:
                    return "";
                case Enums.eEnhRelative.PlusOne:
                    return "+";
                case Enums.eEnhRelative.PlusTwo:
                    return "++";
                case Enums.eEnhRelative.PlusThree:
                    return "+++";
                case Enums.eEnhRelative.PlusFour:
                    return "+4";
                case Enums.eEnhRelative.PlusFive:
                    return "+5";
            }
        }
        else
        {
            switch (iRel)
            {
                case Enums.eEnhRelative.MinusThree:
                    return "-3";
                case Enums.eEnhRelative.MinusTwo:
                    return "-2";
                case Enums.eEnhRelative.MinusOne:
                    return "-1";
                case Enums.eEnhRelative.Even:
                    return "";
                case Enums.eEnhRelative.PlusOne:
                    return "+1";
                case Enums.eEnhRelative.PlusTwo:
                    return "+2";
                case Enums.eEnhRelative.PlusThree:
                    return "+3";
                case Enums.eEnhRelative.PlusFour:
                    return "+4";
                case Enums.eEnhRelative.PlusFive:
                    return "+5";
            }
        }
        return "";
    }

    // Token: 0x060005AC RID: 1452 RVA: 0x00023B8C File Offset: 0x00021D8C
    public static int StringToFlaggedEnum(string iStr, object eEnum, bool noFlag = false)
    {
        int num = 0;
        iStr = iStr.ToUpper();
        string[] strArray2 = iStr.Contains(",") ? Enums.StringToArray(iStr) : iStr.Split(new char[]
        {
            ' '
        });
        int num2;
        if (strArray2.Length < 1)
        {
            num2 = num;
        }
        else
        {
            string[] names = Enum.GetNames(eEnum.GetType());
            Array values = Enum.GetValues(eEnum.GetType());
            for (int index = 0; index < names.Length; index++)
            {
                names[index] = names[index].ToUpper();
            }
            for (int index2 = 0; index2 < strArray2.Length; index2++)
            {
                if (strArray2[index2].Length > 0)
                {
                    int index3 = Array.IndexOf<string>(names, strArray2[index2]);
                    if (index3 > -1)
                    {
                        if (noFlag)
                        {
                            return (int)values.GetValue(index3);
                        }
                        num += (int)values.GetValue(index3);
                    }
                }
            }
            num2 = num;
        }
        return num2;
    }

    // Token: 0x060005AD RID: 1453 RVA: 0x00023CB4 File Offset: 0x00021EB4
    public static T[] StringToEnumArray<T>(string iStr, Type eEnum)
    {
        List<T> objList = new List<T>();
        iStr = iStr.ToUpper();
        string[] strArray2 = iStr.Contains(",") ? Enums.StringToArray(iStr) : iStr.Split(new char[]
        {
            ' '
        });
        T[] array;
        if (strArray2.Length < 1)
        {
            array = objList.ToArray();
        }
        else
        {
            string[] names = Enum.GetNames(eEnum);
            Array values = Enum.GetValues(eEnum);
            for (int index = 0; index < names.Length; index++)
            {
                names[index] = names[index].ToUpper();
            }
            for (int index2 = 0; index2 < strArray2.Length; index2++)
            {
                if (strArray2[index2].Length > 0)
                {
                    int index3 = Array.IndexOf<string>(names, strArray2[index2]);
                    if (index3 > -1)
                    {
                        objList.Add((T)((object)values.GetValue(index3)));
                    }
                }
            }
            array = objList.ToArray();
        }
        return array;
    }

    // Token: 0x060005AE RID: 1454 RVA: 0x00023DC4 File Offset: 0x00021FC4
    public static bool IsEnumValue(string iStr, object eEnum)
    {
        bool flag;
        if (iStr == null)
        {
            flag = false;
        }
        else
        {
            string[] names = Enum.GetNames(eEnum.GetType());
            iStr = iStr.ToUpper();
            for (int index = 0; index < names.Length; index++)
            {
                names[index] = names[index].ToUpper();
            }
            flag = (Array.IndexOf<string>(names, iStr) > -1);
        }
        return flag;
    }

    // Token: 0x060005AF RID: 1455 RVA: 0x00023E2C File Offset: 0x0002202C
    public static string[] StringToArray(string iStr)
    {
        string[] array = new string[0];
        string[] strArray2;
        if (iStr == null)
        {
            strArray2 = array;
        }
        else if (string.IsNullOrEmpty(iStr))
        {
            strArray2 = array;
        }
        else
        {
            char[] chArray = new char[]
            {
                ','
            };
            iStr = iStr.Replace(", ", ",");
            array = iStr.Split(chArray);
            Array.Sort<string>(array);
            strArray2 = array;
        }
        return strArray2;
    }

    // Token: 0x060005B0 RID: 1456 RVA: 0x00023EA4 File Offset: 0x000220A4
    public static string GetGroupedDamage(bool[] iDamage, bool shortForm)
    {
        string str;
        if (iDamage.Length < Enum.GetValues(Enums.eDamage.None.GetType()).Length - 1)
        {
            str = "Error: Array Length Mismatch";
        }
        else
        {
            string str2 = "";
            if (iDamage[1] && iDamage[2] && iDamage[3] && iDamage[4] && iDamage[5] && iDamage[6] && iDamage[8] && iDamage[7])
            {
                str2 = "All";
            }
            else
            {
                for (int index = 0; index < iDamage.Length; index++)
                {
                    if (iDamage[index])
                    {
                        string str3 = shortForm ? Enums.GetDamageNameShort((Enums.eDamage)index) : Enums.GetDamageName((Enums.eDamage)index);
                        if (!string.IsNullOrEmpty(str2))
                        {
                            str2 += ",";
                        }
                        str2 += str3;
                    }
                }
            }
            str = str2;
        }
        return str;
    }

    // Token: 0x060005B1 RID: 1457 RVA: 0x00023F90 File Offset: 0x00022190
    public static string GetGroupedDefense(bool[] iDamage, bool shortForm)
    {
        string str;
        if (iDamage.Length < Enum.GetValues(Enums.eDamage.None.GetType()).Length - 1)
        {
            str = "Error: Array Length Mismatch";
        }
        else
        {
            string str2 = "";
            if (iDamage[1] && iDamage[2] && iDamage[3] && iDamage[4] && iDamage[5] && iDamage[6] && iDamage[8] && iDamage[7])
            {
                str2 = "All";
            }
            else if (!iDamage[1] && !iDamage[2] && !iDamage[3] && !iDamage[4] && !iDamage[5] && !iDamage[6] && !iDamage[8] && !iDamage[7])
            {
                str2 = "All";
            }
            else
            {
                for (int index = 0; index < iDamage.Length; index++)
                {
                    if (iDamage[index])
                    {
                        string str3 = shortForm ? Enums.GetDamageNameShort((Enums.eDamage)index) : Enums.GetDamageName((Enums.eDamage)index);
                        if (!string.IsNullOrEmpty(str2))
                        {
                            str2 += ",";
                        }
                        str2 += str3;
                    }
                }
            }
            str = str2;
        }
        return str;
    }

    // Token: 0x060005B2 RID: 1458 RVA: 0x000240B8 File Offset: 0x000222B8
    public static string GetGroupedMez(bool[] iMez, bool shortForm)
    {
        string str;
        if (iMez.Length < Enum.GetValues(Enums.eMez.None.GetType()).Length - 1)
        {
            str = "Error: Array Length Mismatch";
        }
        else
        {
            string str2 = "";
            if (iMez[1] && iMez[2] && iMez[10] && iMez[9])
            {
                str2 = "Mez";
            }
            else if (iMez[4] && iMez[5] && iMez[1] && iMez[2] && iMez[10] && iMez[9])
            {
                str2 = "Knocked";
            }
            else
            {
                for (int index = 0; index < iMez.Length; index++)
                {
                    if (iMez[index])
                    {
                        string str3 = shortForm ? Enums.GetMezNameShort((Enums.eMezShort)index) : Enums.GetMezName((Enums.eMezShort)index);
                        if (!string.IsNullOrEmpty(str2))
                        {
                            str2 += ",";
                        }
                        str2 += str3;
                    }
                }
            }
            str = str2;
        }
        return str;
    }

    // Token: 0x0200002E RID: 46
    public enum eEnhance
    {
        // Token: 0x040002A4 RID: 676
        None,
        // Token: 0x040002A5 RID: 677
        Accuracy,
        // Token: 0x040002A6 RID: 678
        Damage,
        // Token: 0x040002A7 RID: 679
        Defense,
        // Token: 0x040002A8 RID: 680
        EnduranceDiscount,
        // Token: 0x040002A9 RID: 681
        Endurance,
        // Token: 0x040002AA RID: 682
        SpeedFlying,
        // Token: 0x040002AB RID: 683
        Heal,
        // Token: 0x040002AC RID: 684
        HitPoints,
        // Token: 0x040002AD RID: 685
        Interrupt,
        // Token: 0x040002AE RID: 686
        JumpHeight,
        // Token: 0x040002AF RID: 687
        SpeedJumping,
        // Token: 0x040002B0 RID: 688
        Mez,
        // Token: 0x040002B1 RID: 689
        Range,
        // Token: 0x040002B2 RID: 690
        RechargeTime,
        // Token: 0x040002B3 RID: 691
        X_RechargeTime,
        // Token: 0x040002B4 RID: 692
        Recovery,
        // Token: 0x040002B5 RID: 693
        Regeneration,
        // Token: 0x040002B6 RID: 694
        Resistance,
        // Token: 0x040002B7 RID: 695
        SpeedRunning,
        // Token: 0x040002B8 RID: 696
        ToHit,
        // Token: 0x040002B9 RID: 697
        Slow,
        // Token: 0x040002BA RID: 698
        Absorb
    }

    // Token: 0x0200002F RID: 47
    public enum eEnhanceShort
    {
        // Token: 0x040002BC RID: 700
        None,
        // Token: 0x040002BD RID: 701
        Acc,
        // Token: 0x040002BE RID: 702
        Dmg,
        // Token: 0x040002BF RID: 703
        Def,
        // Token: 0x040002C0 RID: 704
        EndRdx,
        // Token: 0x040002C1 RID: 705
        EndMod,
        // Token: 0x040002C2 RID: 706
        Fly,
        // Token: 0x040002C3 RID: 707
        Heal,
        // Token: 0x040002C4 RID: 708
        HP,
        // Token: 0x040002C5 RID: 709
        ActRdx,
        // Token: 0x040002C6 RID: 710
        Jump,
        // Token: 0x040002C7 RID: 711
        JumpSpd,
        // Token: 0x040002C8 RID: 712
        Mez,
        // Token: 0x040002C9 RID: 713
        Rng,
        // Token: 0x040002CA RID: 714
        Rchg,
        // Token: 0x040002CB RID: 715
        RchrgTm,
        // Token: 0x040002CC RID: 716
        EndRec,
        // Token: 0x040002CD RID: 717
        Regen,
        // Token: 0x040002CE RID: 718
        Res,
        // Token: 0x040002CF RID: 719
        RunSpd,
        // Token: 0x040002D0 RID: 720
        ToHit,
        // Token: 0x040002D1 RID: 721
        Slow
    }

    // Token: 0x02000030 RID: 48
    public enum eSetType
    {
        // Token: 0x040002D3 RID: 723
        Untyped,
        // Token: 0x040002D4 RID: 724
        MeleeST,
        // Token: 0x040002D5 RID: 725
        RangedST,
        // Token: 0x040002D6 RID: 726
        RangedAoE,
        // Token: 0x040002D7 RID: 727
        MeleeAoE,
        // Token: 0x040002D8 RID: 728
        Snipe,
        // Token: 0x040002D9 RID: 729
        Pets,
        // Token: 0x040002DA RID: 730
        Defense,
        // Token: 0x040002DB RID: 731
        Resistance,
        // Token: 0x040002DC RID: 732
        Heal,
        // Token: 0x040002DD RID: 733
        Hold,
        // Token: 0x040002DE RID: 734
        Stun,
        // Token: 0x040002DF RID: 735
        Immob,
        // Token: 0x040002E0 RID: 736
        Slow,
        // Token: 0x040002E1 RID: 737
        Sleep,
        // Token: 0x040002E2 RID: 738
        Fear,
        // Token: 0x040002E3 RID: 739
        Confuse,
        // Token: 0x040002E4 RID: 740
        Flight,
        // Token: 0x040002E5 RID: 741
        Jump,
        // Token: 0x040002E6 RID: 742
        Run,
        // Token: 0x040002E7 RID: 743
        Teleport,
        // Token: 0x040002E8 RID: 744
        DefDebuff,
        // Token: 0x040002E9 RID: 745
        EndMod,
        // Token: 0x040002EA RID: 746
        Knockback,
        // Token: 0x040002EB RID: 747
        Taunt,
        // Token: 0x040002EC RID: 748
        ToHit,
        // Token: 0x040002ED RID: 749
        ToHitDeb,
        // Token: 0x040002EE RID: 750
        PetRech,
        // Token: 0x040002EF RID: 751
        Travel,
        // Token: 0x040002F0 RID: 752
        AccHeal,
        // Token: 0x040002F1 RID: 753
        AccDefDeb,
        // Token: 0x040002F2 RID: 754
        AccToHitDeb,
        // Token: 0x040002F3 RID: 755
        Arachnos,
        // Token: 0x040002F4 RID: 756
        Blaster,
        // Token: 0x040002F5 RID: 757
        Brute,
        // Token: 0x040002F6 RID: 758
        Controller,
        // Token: 0x040002F7 RID: 759
        Corruptor,
        // Token: 0x040002F8 RID: 760
        Defender,
        // Token: 0x040002F9 RID: 761
        Dominator,
        // Token: 0x040002FA RID: 762
        Kheldian,
        // Token: 0x040002FB RID: 763
        Mastermind,
        // Token: 0x040002FC RID: 764
        Scrapper,
        // Token: 0x040002FD RID: 765
        Stalker,
        // Token: 0x040002FE RID: 766
        Tanker,
        // Token: 0x040002FF RID: 767
        UniversalDamage
    }

    // Token: 0x02000031 RID: 49
    public enum eEnhMutex
    {
        // Token: 0x04000301 RID: 769
        None,
        // Token: 0x04000302 RID: 770
        Stealth,
        // Token: 0x04000303 RID: 771
        ArchetypeA,
        // Token: 0x04000304 RID: 772
        ArchetypeB,
        // Token: 0x04000305 RID: 773
        ArchetypeC,
        // Token: 0x04000306 RID: 774
        ArchetypeD,
        // Token: 0x04000307 RID: 775
        ArchetypeE,
        // Token: 0x04000308 RID: 776
        ArchetypeF
    }

    // Token: 0x02000032 RID: 50
    public struct sEnhClass
    {
        // Token: 0x04000309 RID: 777
        public int ID;

        // Token: 0x0400030A RID: 778
        public string Name;

        // Token: 0x0400030B RID: 779
        public string ShortName;

        // Token: 0x0400030C RID: 780
        public string ClassID;

        // Token: 0x0400030D RID: 781
        public string Desc;
    }

    // Token: 0x02000033 RID: 51
    public enum eSchedule
    {
        // Token: 0x0400030F RID: 783
        None = -1,
        // Token: 0x04000310 RID: 784
        A,
        // Token: 0x04000311 RID: 785
        B,
        // Token: 0x04000312 RID: 786
        C,
        // Token: 0x04000313 RID: 787
        D,
        // Token: 0x04000314 RID: 788
        Multiple
    }

    // Token: 0x02000034 RID: 52
    public enum eType
    {
        // Token: 0x04000316 RID: 790
        None,
        // Token: 0x04000317 RID: 791
        Normal,
        // Token: 0x04000318 RID: 792
        InventO,
        // Token: 0x04000319 RID: 793
        SpecialO,
        // Token: 0x0400031A RID: 794
        SetO
    }

    // Token: 0x02000035 RID: 53
    public enum eSubtype
    {
        // Token: 0x0400031C RID: 796
        None,
        // Token: 0x0400031D RID: 797
        Hamidon,
        // Token: 0x0400031E RID: 798
        Hydra,
        // Token: 0x0400031F RID: 799
        Titan
    }

    // Token: 0x02000036 RID: 54
    public enum eEffMode
    {
        // Token: 0x04000321 RID: 801
        Enhancement,
        // Token: 0x04000322 RID: 802
        FX,
        // Token: 0x04000323 RID: 803
        PowerEnh,
        // Token: 0x04000324 RID: 804
        PowerProc
    }

    // Token: 0x02000037 RID: 55
    public enum eBuffDebuff
    {
        // Token: 0x04000326 RID: 806
        Any,
        // Token: 0x04000327 RID: 807
        BuffOnly,
        // Token: 0x04000328 RID: 808
        DeBuffOnly
    }

    // Token: 0x02000038 RID: 56
    public struct sTwinID
    {
        // Token: 0x04000329 RID: 809
        public int ID;

        // Token: 0x0400032A RID: 810
        public int SubID;
    }

    // Token: 0x02000039 RID: 57
    public struct sEffect
    {
        // Token: 0x060005B3 RID: 1459 RVA: 0x000241C8 File Offset: 0x000223C8
        public void Assign(Enums.sEffect effect)
        {
            this.Mode = effect.Mode;
            this.BuffMode = effect.BuffMode;
            this.Enhance.ID = effect.Enhance.ID;
            this.Enhance.SubID = effect.Enhance.SubID;
            this.Schedule = effect.Schedule;
            this.Multiplier = effect.Multiplier;
            if (effect.FX != null)
            {
                this.FX = (IEffect)effect.FX.Clone();
            }
        }

        // Token: 0x0400032B RID: 811
        public Enums.eEffMode Mode;

        // Token: 0x0400032C RID: 812
        public Enums.eBuffDebuff BuffMode;

        // Token: 0x0400032D RID: 813
        public Enums.sTwinID Enhance;

        // Token: 0x0400032E RID: 814
        public Enums.eSchedule Schedule;

        // Token: 0x0400032F RID: 815
        public float Multiplier;

        // Token: 0x04000330 RID: 816
        public IEffect FX;
    }

    // Token: 0x0200003A RID: 58
    public enum PowersetType
    {
        // Token: 0x04000332 RID: 818
        None = -1,
        // Token: 0x04000333 RID: 819
        Primary,
        // Token: 0x04000334 RID: 820
        Secondary,
        // Token: 0x04000335 RID: 821
        Inherent,
        // Token: 0x04000336 RID: 822
        Pool0,
        // Token: 0x04000337 RID: 823
        Pool1,
        // Token: 0x04000338 RID: 824
        Pool2,
        // Token: 0x04000339 RID: 825
        Pool3,
        // Token: 0x0400033A RID: 826
        Ancillary
    }

    // Token: 0x0200003B RID: 59
    public enum ePowerState
    {
        // Token: 0x0400033C RID: 828
        Disabled,
        // Token: 0x0400033D RID: 829
        Empty,
        // Token: 0x0400033E RID: 830
        Used,
        // Token: 0x0400033F RID: 831
        Open
    }

    // Token: 0x0200003C RID: 60
    public enum eMutex
    {
        // Token: 0x04000341 RID: 833
        NoGroup,
        // Token: 0x04000342 RID: 834
        NoConflict,
        // Token: 0x04000343 RID: 835
        MutexFound,
        // Token: 0x04000344 RID: 836
        DetoggleMaster,
        // Token: 0x04000345 RID: 837
        DetoggleSlave
    }

    // Token: 0x0200003D RID: 61
    public enum eSummonEntity
    {
        // Token: 0x04000347 RID: 839
        Pet,
        // Token: 0x04000348 RID: 840
        Henchman
    }

    // Token: 0x0200003E RID: 62
    public enum eOverrideBoolean
    {
        // Token: 0x0400034A RID: 842
        NoOverride,
        // Token: 0x0400034B RID: 843
        TrueOverride,
        // Token: 0x0400034C RID: 844
        FalseOverride
    }

    // Token: 0x0200003F RID: 63
    public enum eAttribType
    {
        // Token: 0x0400034E RID: 846
        Magnitude,
        // Token: 0x0400034F RID: 847
        Duration,
        // Token: 0x04000350 RID: 848
        Expression
    }

    // Token: 0x02000040 RID: 64
    public enum ePvX
    {
        // Token: 0x04000352 RID: 850
        Any,
        // Token: 0x04000353 RID: 851
        PvE,
        // Token: 0x04000354 RID: 852
        PvP
    }

    // Token: 0x02000041 RID: 65
    public enum eToWho
    {
        // Token: 0x04000356 RID: 854
        Unspecified,
        // Token: 0x04000357 RID: 855
        Target,
        // Token: 0x04000358 RID: 856
        Self,
        // Token: 0x04000359 RID: 857
        All
    }

    // Token: 0x02000042 RID: 66
    public enum eAspect
    {
        // Token: 0x0400035B RID: 859
        Res,
        // Token: 0x0400035C RID: 860
        Max,
        // Token: 0x0400035D RID: 861
        Abs,
        // Token: 0x0400035E RID: 862
        Str,
        // Token: 0x0400035F RID: 863
        Cur
    }

    // Token: 0x02000043 RID: 67
    public enum eStacking
    {
        // Token: 0x04000361 RID: 865
        No,
        // Token: 0x04000362 RID: 866
        Yes
    }

    // Token: 0x02000044 RID: 68
    public enum eClassType
    {
        // Token: 0x04000364 RID: 868
        None,
        // Token: 0x04000365 RID: 869
        Hero,
        // Token: 0x04000366 RID: 870
        HeroEpic,
        // Token: 0x04000367 RID: 871
        Villain,
        // Token: 0x04000368 RID: 872
        VillainEpic,
        // Token: 0x04000369 RID: 873
        Henchman,
        // Token: 0x0400036A RID: 874
        Pet
    }

    // Token: 0x02000045 RID: 69
    public enum Alignment
    {
        // Token: 0x0400036C RID: 876
        Hero,
        // Token: 0x0400036D RID: 877
        Rogue,
        // Token: 0x0400036E RID: 878
        Vigilante,
        // Token: 0x0400036F RID: 879
        Villain,
        // Token: 0x04000370 RID: 880
        Loyalist,
        // Token: 0x04000371 RID: 881
        Resistance
    }

    // Token: 0x02000046 RID: 70
    [Flags]
    public enum eSuppress
    {
        // Token: 0x04000373 RID: 883
        None = 0,
        // Token: 0x04000374 RID: 884
        Held = 1,
        // Token: 0x04000375 RID: 885
        Sleep = 2,
        // Token: 0x04000376 RID: 886
        Stunned = 4,
        // Token: 0x04000377 RID: 887
        Immobilized = 8,
        // Token: 0x04000378 RID: 888
        Terrorized = 16,
        // Token: 0x04000379 RID: 889
        Knocked = 32,
        // Token: 0x0400037A RID: 890
        Attacked = 64,
        // Token: 0x0400037B RID: 891
        HitByFoe = 128,
        // Token: 0x0400037C RID: 892
        MissionObjectClick = 256,
        // Token: 0x0400037D RID: 893
        ActivateAttackClick = 512,
        // Token: 0x0400037E RID: 894
        Damaged = 1024,
        // Token: 0x0400037F RID: 895
        Phased1 = 2048,
        // Token: 0x04000380 RID: 896
        Confused = 4096
    }

    // Token: 0x02000047 RID: 71
    public enum ePowerSetType
    {
        // Token: 0x04000382 RID: 898
        None,
        // Token: 0x04000383 RID: 899
        Primary,
        // Token: 0x04000384 RID: 900
        Secondary,
        // Token: 0x04000385 RID: 901
        Ancillary,
        // Token: 0x04000386 RID: 902
        Inherent,
        // Token: 0x04000387 RID: 903
        Pool,
        // Token: 0x04000388 RID: 904
        Accolade,
        // Token: 0x04000389 RID: 905
        Temp,
        // Token: 0x0400038A RID: 906
        Pet,
        // Token: 0x0400038B RID: 907
        SetBonus,
        // Token: 0x0400038C RID: 908
        Boost,
        // Token: 0x0400038D RID: 909
        Incarnate
    }

    // Token: 0x02000048 RID: 72
    public enum ePowerType
    {
        // Token: 0x0400038F RID: 911
        Click,
        // Token: 0x04000390 RID: 912
        Auto_,
        // Token: 0x04000391 RID: 913
        Toggle,
        // Token: 0x04000392 RID: 914
        Boost,
        // Token: 0x04000393 RID: 915
        Inspiration,
        // Token: 0x04000394 RID: 916
        GlobalBoost
    }

    // Token: 0x02000049 RID: 73
    [Flags]
    public enum eVector
    {
        // Token: 0x04000396 RID: 918
        None = 0,
        // Token: 0x04000397 RID: 919
        Melee_Attack = 1,
        // Token: 0x04000398 RID: 920
        Ranged_Attack = 2,
        // Token: 0x04000399 RID: 921
        AOE_Attack = 4,
        // Token: 0x0400039A RID: 922
        Smashing_Attack = 8,
        // Token: 0x0400039B RID: 923
        Lethal_Attack = 16,
        // Token: 0x0400039C RID: 924
        Cold_Attack = 32,
        // Token: 0x0400039D RID: 925
        Fire_Attack = 64,
        // Token: 0x0400039E RID: 926
        Energy_Attack = 128,
        // Token: 0x0400039F RID: 927
        Negative_Energy_Attack = 256,
        // Token: 0x040003A0 RID: 928
        Psionic_Attack = 512
    }

    // Token: 0x0200004A RID: 74
    public enum eEffectArea
    {
        // Token: 0x040003A2 RID: 930
        None,
        // Token: 0x040003A3 RID: 931
        Character,
        // Token: 0x040003A4 RID: 932
        Sphere,
        // Token: 0x040003A5 RID: 933
        Cone,
        // Token: 0x040003A6 RID: 934
        Location,
        // Token: 0x040003A7 RID: 935
        Volume,
        // Token: 0x040003A8 RID: 936
        Map,
        // Token: 0x040003A9 RID: 937
        Room,
        // Token: 0x040003AA RID: 938
        Touch
    }

    // Token: 0x0200004B RID: 75
    [Flags]
    public enum eCastFlags
    {
        // Token: 0x040003AC RID: 940
        None = 0,
        // Token: 0x040003AD RID: 941
        NearGround = 1,
        // Token: 0x040003AE RID: 942
        TargetNearGround = 2,
        // Token: 0x040003AF RID: 943
        CastableAfterDeath = 4
    }

    // Token: 0x0200004C RID: 76
    [Flags]
    public enum eModeFlags
    {
        // Token: 0x040003B1 RID: 945
        None = 0,
        // Token: 0x040003B2 RID: 946
        Arena = 1,
        // Token: 0x040003B3 RID: 947
        Disable_All = 2,
        // Token: 0x040003B4 RID: 948
        Disable_Enhancements = 4,
        // Token: 0x040003B5 RID: 949
        Disable_Epic = 8,
        // Token: 0x040003B6 RID: 950
        Disable_Inspirations = 16,
        // Token: 0x040003B7 RID: 951
        Disable_Market_TP = 32,
        // Token: 0x040003B8 RID: 952
        Disable_Pool = 64,
        // Token: 0x040003B9 RID: 953
        Disable_Rez_Insp = 128,
        // Token: 0x040003BA RID: 954
        Disable_Teleport = 256,
        // Token: 0x040003BB RID: 955
        Disable_Temp = 512,
        // Token: 0x040003BC RID: 956
        Disable_Toggle = 1024,
        // Token: 0x040003BD RID: 957
        Disable_Travel = 2048,
        // Token: 0x040003BE RID: 958
        Domination = 4096,
        // Token: 0x040003BF RID: 959
        Peacebringer_Blaster_Mode = 8192,
        // Token: 0x040003C0 RID: 960
        Peacebringer_Lightform_Mode = 16384,
        // Token: 0x040003C1 RID: 961
        Peacebringer_Tanker_Mode = 32768,
        // Token: 0x040003C2 RID: 962
        Raid_Attacker_Mode = 65536,
        // Token: 0x040003C3 RID: 963
        Shivan_Mode = 131072,
        // Token: 0x040003C4 RID: 964
        Unknown18 = 262144,
        // Token: 0x040003C5 RID: 965
        Warshade_Blaster_Mode = 524288,
        // Token: 0x040003C6 RID: 966
        Warshade_Tanker_Mode = 1048576
    }

    // Token: 0x0200004D RID: 77
    public enum eEnhGrade
    {
        // Token: 0x040003C8 RID: 968
        None,
        // Token: 0x040003C9 RID: 969
        TrainingO,
        // Token: 0x040003CA RID: 970
        DualO,
        // Token: 0x040003CB RID: 971
        SingleO
    }

    // Token: 0x0200004E RID: 78
    public enum eEnhRelative
    {
        // Token: 0x040003CD RID: 973
        None,
        // Token: 0x040003CE RID: 974
        MinusThree,
        // Token: 0x040003CF RID: 975
        MinusTwo,
        // Token: 0x040003D0 RID: 976
        MinusOne,
        // Token: 0x040003D1 RID: 977
        Even,
        // Token: 0x040003D2 RID: 978
        PlusOne,
        // Token: 0x040003D3 RID: 979
        PlusTwo,
        // Token: 0x040003D4 RID: 980
        PlusThree,
        // Token: 0x040003D5 RID: 981
        PlusFour,
        // Token: 0x040003D6 RID: 982
        PlusFive
    }

    // Token: 0x0200004F RID: 79
    public enum eDamage
    {
        // Token: 0x040003D8 RID: 984
        None,
        // Token: 0x040003D9 RID: 985
        Smashing,
        // Token: 0x040003DA RID: 986
        Lethal,
        // Token: 0x040003DB RID: 987
        Fire,
        // Token: 0x040003DC RID: 988
        Cold,
        // Token: 0x040003DD RID: 989
        Energy,
        // Token: 0x040003DE RID: 990
        Negative,
        // Token: 0x040003DF RID: 991
        Toxic,
        // Token: 0x040003E0 RID: 992
        Psionic,
        // Token: 0x040003E1 RID: 993
        Special,
        // Token: 0x040003E2 RID: 994
        Melee,
        // Token: 0x040003E3 RID: 995
        Ranged,
        // Token: 0x040003E4 RID: 996
        AoE,
        // Token: 0x040003E5 RID: 997
        Unique1,
        // Token: 0x040003E6 RID: 998
        Unique2,
        // Token: 0x040003E7 RID: 999
        Unique3
    }

    // Token: 0x02000050 RID: 80
    public enum eCSVImport_Damage
    {
        // Token: 0x040003E9 RID: 1001
        None,
        // Token: 0x040003EA RID: 1002
        Smashing,
        // Token: 0x040003EB RID: 1003
        Lethal,
        // Token: 0x040003EC RID: 1004
        Fire,
        // Token: 0x040003ED RID: 1005
        Cold,
        // Token: 0x040003EE RID: 1006
        Energy,
        // Token: 0x040003EF RID: 1007
        Negative_Energy,
        // Token: 0x040003F0 RID: 1008
        Toxic,
        // Token: 0x040003F1 RID: 1009
        Psionic,
        // Token: 0x040003F2 RID: 1010
        Special,
        // Token: 0x040003F3 RID: 1011
        Melee,
        // Token: 0x040003F4 RID: 1012
        Ranged,
        // Token: 0x040003F5 RID: 1013
        AoE,
        // Token: 0x040003F6 RID: 1014
        Unique1,
        // Token: 0x040003F7 RID: 1015
        Unique2,
        // Token: 0x040003F8 RID: 1016
        Unique3
    }

    // Token: 0x02000051 RID: 81
    public enum eCSVImport_Damage_Def
    {
        // Token: 0x040003FA RID: 1018
        None,
        // Token: 0x040003FB RID: 1019
        Smashing_Attack,
        // Token: 0x040003FC RID: 1020
        Lethal_Attack,
        // Token: 0x040003FD RID: 1021
        Fire_Attack,
        // Token: 0x040003FE RID: 1022
        Cold_Attack,
        // Token: 0x040003FF RID: 1023
        Energy_Attack,
        // Token: 0x04000400 RID: 1024
        Negative_Energy_Attack,
        // Token: 0x04000401 RID: 1025
        Toxic_Attack,
        // Token: 0x04000402 RID: 1026
        Psionic_Attack,
        // Token: 0x04000403 RID: 1027
        Special,
        // Token: 0x04000404 RID: 1028
        Melee_Attack,
        // Token: 0x04000405 RID: 1029
        Ranged_Attack,
        // Token: 0x04000406 RID: 1030
        AoE_Attack
    }

    // Token: 0x02000052 RID: 82
    public enum eCSVImport_Damage_Elusivity
    {
        // Token: 0x04000408 RID: 1032
        None,
        // Token: 0x04000409 RID: 1033
        Smashing_Elude,
        // Token: 0x0400040A RID: 1034
        Lethal_Elude,
        // Token: 0x0400040B RID: 1035
        Fire_Elude,
        // Token: 0x0400040C RID: 1036
        Cold_Elude,
        // Token: 0x0400040D RID: 1037
        Energy_Elude,
        // Token: 0x0400040E RID: 1038
        Negative_Elude,
        // Token: 0x0400040F RID: 1039
        Toxic_Elude,
        // Token: 0x04000410 RID: 1040
        Psionic_Elude,
        // Token: 0x04000411 RID: 1041
        Special_Elude,
        // Token: 0x04000412 RID: 1042
        Melee_Elude,
        // Token: 0x04000413 RID: 1043
        Ranged_Elude,
        // Token: 0x04000414 RID: 1044
        AoE_Elude
    }

    // Token: 0x02000053 RID: 83
    public enum eDamageShort
    {
        // Token: 0x04000416 RID: 1046
        None,
        // Token: 0x04000417 RID: 1047
        Smash,
        // Token: 0x04000418 RID: 1048
        Lethal,
        // Token: 0x04000419 RID: 1049
        Fire,
        // Token: 0x0400041A RID: 1050
        Cold,
        // Token: 0x0400041B RID: 1051
        Energy,
        // Token: 0x0400041C RID: 1052
        Neg,
        // Token: 0x0400041D RID: 1053
        Toxic,
        // Token: 0x0400041E RID: 1054
        Psi,
        // Token: 0x0400041F RID: 1055
        Spec,
        // Token: 0x04000420 RID: 1056
        Melee,
        // Token: 0x04000421 RID: 1057
        Rngd,
        // Token: 0x04000422 RID: 1058
        AoE
    }

    // Token: 0x02000054 RID: 84
    public enum eBuffMode
    {
        // Token: 0x04000424 RID: 1060
        Normal,
        // Token: 0x04000425 RID: 1061
        Buff,
        // Token: 0x04000426 RID: 1062
        Debuff
    }

    // Token: 0x02000055 RID: 85
    [Flags]
    public enum eEntity
    {
        // Token: 0x04000428 RID: 1064
        None = 0,
        // Token: 0x04000429 RID: 1065
        Caster = 1,
        // Token: 0x0400042A RID: 1066
        Player = 2,
        // Token: 0x0400042B RID: 1067
        DeadPlayer = 4,
        // Token: 0x0400042C RID: 1068
        Teammate = 8,
        // Token: 0x0400042D RID: 1069
        DeadTeammate = 16,
        // Token: 0x0400042E RID: 1070
        DeadOrAliveTeammate = 32,
        // Token: 0x0400042F RID: 1071
        Villain = 64,
        // Token: 0x04000430 RID: 1072
        DeadVillain = 128,
        // Token: 0x04000431 RID: 1073
        NPC = 256,
        // Token: 0x04000432 RID: 1074
        Friend = 512,
        // Token: 0x04000433 RID: 1075
        DeadFriend = 1024,
        // Token: 0x04000434 RID: 1076
        Foe = 2048,
        // Token: 0x04000435 RID: 1077
        Location = 8192,
        // Token: 0x04000436 RID: 1078
        Teleport = 16384,
        // Token: 0x04000437 RID: 1079
        Any = 32768,
        // Token: 0x04000438 RID: 1080
        MyPet = 65536,
        // Token: 0x04000439 RID: 1081
        DeadFoe = 131072,
        // Token: 0x0400043A RID: 1082
        FoeRezzingFoe = 262144,
        // Token: 0x0400043B RID: 1083
        Leaguemate = 524288,
        // Token: 0x0400043C RID: 1084
        DeadLeaguemate = 1048576,
        // Token: 0x0400043D RID: 1085
        AnyLeaguemate = 2097152,
        // Token: 0x0400043E RID: 1086
        DeadMyCreation = 4194304,
        // Token: 0x0400043F RID: 1087
        DeadMyPet = 8388608,
        // Token: 0x04000440 RID: 1088
        DeadOrAliveFoe = 16777216,
        // Token: 0x04000441 RID: 1089
        DeadOrAliveLeaguemate = 33554432,
        // Token: 0x04000442 RID: 1090
        DeadPlayerFriend = 67108864,
        // Token: 0x04000443 RID: 1091
        MyOwner = 134217728
    }

    // Token: 0x02000056 RID: 86
    public enum eNotify
    {
        // Token: 0x04000445 RID: 1093
        Always,
        // Token: 0x04000446 RID: 1094
        Never,
        // Token: 0x04000447 RID: 1095
        MissOnly,
        // Token: 0x04000448 RID: 1096
        HitOnly
    }

    // Token: 0x02000057 RID: 87
    public enum eMez
    {
        // Token: 0x0400044A RID: 1098
        None,
        // Token: 0x0400044B RID: 1099
        Confused,
        // Token: 0x0400044C RID: 1100
        Held,
        // Token: 0x0400044D RID: 1101
        Immobilized,
        // Token: 0x0400044E RID: 1102
        Knockback,
        // Token: 0x0400044F RID: 1103
        Knockup,
        // Token: 0x04000450 RID: 1104
        OnlyAffectsSelf,
        // Token: 0x04000451 RID: 1105
        Placate,
        // Token: 0x04000452 RID: 1106
        Repel,
        // Token: 0x04000453 RID: 1107
        Sleep,
        // Token: 0x04000454 RID: 1108
        Stunned,
        // Token: 0x04000455 RID: 1109
        Taunt,
        // Token: 0x04000456 RID: 1110
        Terrorized,
        // Token: 0x04000457 RID: 1111
        Untouchable,
        // Token: 0x04000458 RID: 1112
        Teleport,
        // Token: 0x04000459 RID: 1113
        ToggleDrop,
        // Token: 0x0400045A RID: 1114
        Afraid,
        // Token: 0x0400045B RID: 1115
        Avoid,
        // Token: 0x0400045C RID: 1116
        CombatPhase,
        // Token: 0x0400045D RID: 1117
        Intangible
    }

    // Token: 0x02000058 RID: 88
    public enum eMezShort
    {
        // Token: 0x0400045F RID: 1119
        None,
        // Token: 0x04000460 RID: 1120
        Conf,
        // Token: 0x04000461 RID: 1121
        Held,
        // Token: 0x04000462 RID: 1122
        Immob,
        // Token: 0x04000463 RID: 1123
        KB,
        // Token: 0x04000464 RID: 1124
        KUp,
        // Token: 0x04000465 RID: 1125
        AffSelf,
        // Token: 0x04000466 RID: 1126
        Placate,
        // Token: 0x04000467 RID: 1127
        Repel,
        // Token: 0x04000468 RID: 1128
        Sleep,
        // Token: 0x04000469 RID: 1129
        Stun,
        // Token: 0x0400046A RID: 1130
        Taunt,
        // Token: 0x0400046B RID: 1131
        Fear,
        // Token: 0x0400046C RID: 1132
        Untouch,
        // Token: 0x0400046D RID: 1133
        TP,
        // Token: 0x0400046E RID: 1134
        DeTogg,
        // Token: 0x0400046F RID: 1135
        Afraid,
        // Token: 0x04000470 RID: 1136
        Avoid,
        // Token: 0x04000471 RID: 1137
        Phased,
        // Token: 0x04000472 RID: 1138
        Intan
    }

    // Token: 0x02000059 RID: 89
    public enum eEffectType
    {
        // Token: 0x04000474 RID: 1140
        None,
        // Token: 0x04000475 RID: 1141
        Accuracy,
        // Token: 0x04000476 RID: 1142
        ViewAttrib,
        // Token: 0x04000477 RID: 1143
        Damage,
        // Token: 0x04000478 RID: 1144
        DamageBuff,
        // Token: 0x04000479 RID: 1145
        Defense,
        // Token: 0x0400047A RID: 1146
        DropToggles,
        // Token: 0x0400047B RID: 1147
        Endurance,
        // Token: 0x0400047C RID: 1148
        EnduranceDiscount,
        // Token: 0x0400047D RID: 1149
        Enhancement,
        // Token: 0x0400047E RID: 1150
        Fly,
        // Token: 0x0400047F RID: 1151
        SpeedFlying,
        // Token: 0x04000480 RID: 1152
        GrantPower,
        // Token: 0x04000481 RID: 1153
        Heal,
        // Token: 0x04000482 RID: 1154
        HitPoints,
        // Token: 0x04000483 RID: 1155
        InterruptTime,
        // Token: 0x04000484 RID: 1156
        JumpHeight,
        // Token: 0x04000485 RID: 1157
        SpeedJumping,
        // Token: 0x04000486 RID: 1158
        Meter,
        // Token: 0x04000487 RID: 1159
        Mez,
        // Token: 0x04000488 RID: 1160
        MezResist,
        // Token: 0x04000489 RID: 1161
        MovementControl,
        // Token: 0x0400048A RID: 1162
        MovementFriction,
        // Token: 0x0400048B RID: 1163
        PerceptionRadius,
        // Token: 0x0400048C RID: 1164
        Range,
        // Token: 0x0400048D RID: 1165
        RechargeTime,
        // Token: 0x0400048E RID: 1166
        Recovery,
        // Token: 0x0400048F RID: 1167
        Regeneration,
        // Token: 0x04000490 RID: 1168
        ResEffect,
        // Token: 0x04000491 RID: 1169
        Resistance,
        // Token: 0x04000492 RID: 1170
        RevokePower,
        // Token: 0x04000493 RID: 1171
        Reward,
        // Token: 0x04000494 RID: 1172
        SpeedRunning,
        // Token: 0x04000495 RID: 1173
        SetCostume,
        // Token: 0x04000496 RID: 1174
        SetMode,
        // Token: 0x04000497 RID: 1175
        Slow,
        // Token: 0x04000498 RID: 1176
        StealthRadius,
        // Token: 0x04000499 RID: 1177
        StealthRadiusPlayer,
        // Token: 0x0400049A RID: 1178
        EntCreate,
        // Token: 0x0400049B RID: 1179
        ThreatLevel,
        // Token: 0x0400049C RID: 1180
        ToHit,
        // Token: 0x0400049D RID: 1181
        Translucency,
        // Token: 0x0400049E RID: 1182
        XPDebtProtection,
        // Token: 0x0400049F RID: 1183
        SilentKill,
        // Token: 0x040004A0 RID: 1184
        Elusivity,
        // Token: 0x040004A1 RID: 1185
        GlobalChanceMod,
        // Token: 0x040004A2 RID: 1186
        CombatModShift,
        // Token: 0x040004A3 RID: 1187
        UnsetMode,
        // Token: 0x040004A4 RID: 1188
        Rage,
        // Token: 0x040004A5 RID: 1189
        MaxRunSpeed,
        // Token: 0x040004A6 RID: 1190
        MaxJumpSpeed,
        // Token: 0x040004A7 RID: 1191
        MaxFlySpeed,
        // Token: 0x040004A8 RID: 1192
        DesignerStatus,
        // Token: 0x040004A9 RID: 1193
        PowerRedirect,
        // Token: 0x040004AA RID: 1194
        TokenAdd,
        // Token: 0x040004AB RID: 1195
        ExperienceGain,
        // Token: 0x040004AC RID: 1196
        InfluenceGain,
        // Token: 0x040004AD RID: 1197
        PrestigeGain,
        // Token: 0x040004AE RID: 1198
        AddBehavior,
        // Token: 0x040004AF RID: 1199
        RechargePower,
        // Token: 0x040004B0 RID: 1200
        RewardSourceTeam,
        // Token: 0x040004B1 RID: 1201
        VisionPhase,
        // Token: 0x040004B2 RID: 1202
        CombatPhase,
        // Token: 0x040004B3 RID: 1203
        ClearFog,
        // Token: 0x040004B4 RID: 1204
        SetSZEValue,
        // Token: 0x040004B5 RID: 1205
        ExclusiveVisionPhase,
        // Token: 0x040004B6 RID: 1206
        Absorb,
        // Token: 0x040004B7 RID: 1207
        XAfraid,
        // Token: 0x040004B8 RID: 1208
        XAvoid,
        // Token: 0x040004B9 RID: 1209
        BeastRun,
        // Token: 0x040004BA RID: 1210
        ClearDamagers,
        // Token: 0x040004BB RID: 1211
        EntCreate_x,
        // Token: 0x040004BC RID: 1212
        Glide,
        // Token: 0x040004BD RID: 1213
        Hoverboard,
        // Token: 0x040004BE RID: 1214
        Jumppack,
        // Token: 0x040004BF RID: 1215
        MagicCarpet,
        // Token: 0x040004C0 RID: 1216
        NinjaRun,
        // Token: 0x040004C1 RID: 1217
        Null,
        // Token: 0x040004C2 RID: 1218
        NullBool,
        // Token: 0x040004C3 RID: 1219
        Stealth,
        // Token: 0x040004C4 RID: 1220
        SteamJump,
        // Token: 0x040004C5 RID: 1221
        Walk,
        // Token: 0x040004C6 RID: 1222
        XPDebt,
        // Token: 0x040004C7 RID: 1223
        ForceMove
    }

    // Token: 0x0200005A RID: 90
    public enum eEffectTypeShort
    {
        // Token: 0x040004C9 RID: 1225
        None,
        // Token: 0x040004CA RID: 1226
        Acc,
        // Token: 0x040004CB RID: 1227
        Anlyz,
        // Token: 0x040004CC RID: 1228
        Dmg,
        // Token: 0x040004CD RID: 1229
        DamBuff,
        // Token: 0x040004CE RID: 1230
        Def,
        // Token: 0x040004CF RID: 1231
        ToglDrop,
        // Token: 0x040004D0 RID: 1232
        Endrnce,
        // Token: 0x040004D1 RID: 1233
        EndRdx,
        // Token: 0x040004D2 RID: 1234
        Enhance,
        // Token: 0x040004D3 RID: 1235
        Fly,
        // Token: 0x040004D4 RID: 1236
        FlySpd,
        // Token: 0x040004D5 RID: 1237
        Grant,
        // Token: 0x040004D6 RID: 1238
        Heal,
        // Token: 0x040004D7 RID: 1239
        HP,
        // Token: 0x040004D8 RID: 1240
        ActRdx,
        // Token: 0x040004D9 RID: 1241
        Jump,
        // Token: 0x040004DA RID: 1242
        JumpSpd,
        // Token: 0x040004DB RID: 1243
        Meter,
        // Token: 0x040004DC RID: 1244
        Mez,
        // Token: 0x040004DD RID: 1245
        MezRes,
        // Token: 0x040004DE RID: 1246
        MveCtrl,
        // Token: 0x040004DF RID: 1247
        MveFrctn,
        // Token: 0x040004E0 RID: 1248
        Pceptn,
        // Token: 0x040004E1 RID: 1249
        Rng,
        // Token: 0x040004E2 RID: 1250
        Rechg,
        // Token: 0x040004E3 RID: 1251
        EndRec,
        // Token: 0x040004E4 RID: 1252
        Regen,
        // Token: 0x040004E5 RID: 1253
        ResEffect,
        // Token: 0x040004E6 RID: 1254
        Res,
        // Token: 0x040004E7 RID: 1255
        Revke,
        // Token: 0x040004E8 RID: 1256
        Reward,
        // Token: 0x040004E9 RID: 1257
        RunSpd,
        // Token: 0x040004EA RID: 1258
        Costume,
        // Token: 0x040004EB RID: 1259
        Smode,
        // Token: 0x040004EC RID: 1260
        Slow,
        // Token: 0x040004ED RID: 1261
        StealthR,
        // Token: 0x040004EE RID: 1262
        StealthP,
        // Token: 0x040004EF RID: 1263
        Summon,
        // Token: 0x040004F0 RID: 1264
        ThreatLvl,
        // Token: 0x040004F1 RID: 1265
        ToHit,
        // Token: 0x040004F2 RID: 1266
        Tnslncy,
        // Token: 0x040004F3 RID: 1267
        DebtProt,
        // Token: 0x040004F4 RID: 1268
        Expire,
        // Token: 0x040004F5 RID: 1269
        Elsvty,
        // Token: 0x040004F6 RID: 1270
        GlobalChance,
        // Token: 0x040004F7 RID: 1271
        LvlShift,
        // Token: 0x040004F8 RID: 1272
        ClrMode,
        // Token: 0x040004F9 RID: 1273
        Fury,
        // Token: 0x040004FA RID: 1274
        MaxRunSpd,
        // Token: 0x040004FB RID: 1275
        MaxJumpSpd,
        // Token: 0x040004FC RID: 1276
        MaxFlySpd,
        // Token: 0x040004FD RID: 1277
        DeStatus,
        // Token: 0x040004FE RID: 1278
        Redirect,
        // Token: 0x040004FF RID: 1279
        TokenAdd,
        // Token: 0x04000500 RID: 1280
        RDebuff1,
        // Token: 0x04000501 RID: 1281
        RDebuff2,
        // Token: 0x04000502 RID: 1282
        RDebuff3,
        // Token: 0x04000503 RID: 1283
        AddBehav,
        // Token: 0x04000504 RID: 1284
        RechPower,
        // Token: 0x04000505 RID: 1285
        LostCure,
        // Token: 0x04000506 RID: 1286
        VisionPhase,
        // Token: 0x04000507 RID: 1287
        CombatPhase,
        // Token: 0x04000508 RID: 1288
        ClearFog,
        // Token: 0x04000509 RID: 1289
        SetSZEValue,
        // Token: 0x0400050A RID: 1290
        ExVisionPhase,
        // Token: 0x0400050B RID: 1291
        Absorb,
        // Token: 0x0400050C RID: 1292
        Afraid,
        // Token: 0x0400050D RID: 1293
        Avoid,
        // Token: 0x0400050E RID: 1294
        BeastRun,
        // Token: 0x0400050F RID: 1295
        ClearDamagers,
        // Token: 0x04000510 RID: 1296
        EntCreate,
        // Token: 0x04000511 RID: 1297
        Glide,
        // Token: 0x04000512 RID: 1298
        Hoverboard,
        // Token: 0x04000513 RID: 1299
        Jumppack,
        // Token: 0x04000514 RID: 1300
        MagicCarpet,
        // Token: 0x04000515 RID: 1301
        NinjaRun,
        // Token: 0x04000516 RID: 1302
        Null,
        // Token: 0x04000517 RID: 1303
        NullBool,
        // Token: 0x04000518 RID: 1304
        Stealth,
        // Token: 0x04000519 RID: 1305
        SteamJump,
        // Token: 0x0400051A RID: 1306
        Walk,
        // Token: 0x0400051B RID: 1307
        XPDebt,
        // Token: 0x0400051C RID: 1308
        ForceMove
    }

    // Token: 0x0200005B RID: 91
    public enum eEffectClass
    {
        // Token: 0x0400051E RID: 1310
        Primary,
        // Token: 0x0400051F RID: 1311
        Secondary,
        // Token: 0x04000520 RID: 1312
        Tertiary,
        // Token: 0x04000521 RID: 1313
        Special,
        // Token: 0x04000522 RID: 1314
        Ignored,
        // Token: 0x04000523 RID: 1315
        DisplayOnly
    }

    // Token: 0x0200005C RID: 92
    public enum eSpecialCase
    {
        // Token: 0x04000525 RID: 1317
        None,
        // Token: 0x04000526 RID: 1318
        Hidden,
        // Token: 0x04000527 RID: 1319
        Domination,
        // Token: 0x04000528 RID: 1320
        Scourge,
        // Token: 0x04000529 RID: 1321
        Mezzed,
        // Token: 0x0400052A RID: 1322
        CriticalHit,
        // Token: 0x0400052B RID: 1323
        CriticalBoss,
        // Token: 0x0400052C RID: 1324
        CriticalMinion,
        // Token: 0x0400052D RID: 1325
        Robot,
        // Token: 0x0400052E RID: 1326
        Assassination,
        // Token: 0x0400052F RID: 1327
        Containment,
        // Token: 0x04000530 RID: 1328
        Defiance,
        // Token: 0x04000531 RID: 1329
        TargetDroneActive,
        // Token: 0x04000532 RID: 1330
        Combo,
        // Token: 0x04000533 RID: 1331
        VersusSpecial,
        // Token: 0x04000534 RID: 1332
        NotDisintegrated,
        // Token: 0x04000535 RID: 1333
        Disintegrated,
        // Token: 0x04000536 RID: 1334
        NotAccelerated,
        // Token: 0x04000537 RID: 1335
        Accelerated,
        // Token: 0x04000538 RID: 1336
        NotDelayed,
        // Token: 0x04000539 RID: 1337
        Delayed,
        // Token: 0x0400053A RID: 1338
        ComboLevel0,
        // Token: 0x0400053B RID: 1339
        ComboLevel1,
        // Token: 0x0400053C RID: 1340
        ComboLevel2,
        // Token: 0x0400053D RID: 1341
        ComboLevel3,
        // Token: 0x0400053E RID: 1342
        FastMode,
        // Token: 0x0400053F RID: 1343
        NotAssassination,
        // Token: 0x04000540 RID: 1344
        PerfectionOfBody0,
        // Token: 0x04000541 RID: 1345
        PerfectionOfBody1,
        // Token: 0x04000542 RID: 1346
        PerfectionOfBody2,
        // Token: 0x04000543 RID: 1347
        PerfectionOfBody3,
        // Token: 0x04000544 RID: 1348
        PerfectionOfMind0,
        // Token: 0x04000545 RID: 1349
        PerfectionOfMind1,
        // Token: 0x04000546 RID: 1350
        PerfectionOfMind2,
        // Token: 0x04000547 RID: 1351
        PerfectionOfMind3,
        // Token: 0x04000548 RID: 1352
        PerfectionOfSoul0,
        // Token: 0x04000549 RID: 1353
        PerfectionOfSoul1,
        // Token: 0x0400054A RID: 1354
        PerfectionOfSoul2,
        // Token: 0x0400054B RID: 1355
        PerfectionOfSoul3,
        // Token: 0x0400054C RID: 1356
        TeamSize1,
        // Token: 0x0400054D RID: 1357
        TeamSize2,
        // Token: 0x0400054E RID: 1358
        TeamSize3,
        // Token: 0x0400054F RID: 1359
        NotComboLevel3,
        // Token: 0x04000550 RID: 1360
        ToHit97,
        // Token: 0x04000551 RID: 1361
        DefensiveAdaptation,
        // Token: 0x04000552 RID: 1362
        EfficientAdaptation,
        // Token: 0x04000553 RID: 1363
        OffensiveAdaptation,
        // Token: 0x04000554 RID: 1364
        NotDefensiveAdaptation,
        // Token: 0x04000555 RID: 1365
        NotDefensiveNorOffensiveAdaptation
    }

    // Token: 0x0200005D RID: 93
    public enum eDDStyle
    {
        // Token: 0x04000557 RID: 1367
        Text,
        // Token: 0x04000558 RID: 1368
        Graph,
        // Token: 0x04000559 RID: 1369
        TextOnGraph,
        // Token: 0x0400055A RID: 1370
        TextUnderGraph
    }

    // Token: 0x0200005E RID: 94
    public enum eDDText
    {
        // Token: 0x0400055C RID: 1372
        ActualValues,
        // Token: 0x0400055D RID: 1373
        OnlyBase,
        // Token: 0x0400055E RID: 1374
        OnlyEnhanced,
        // Token: 0x0400055F RID: 1375
        pcOfBase,
        // Token: 0x04000560 RID: 1376
        pcMaxBase,
        // Token: 0x04000561 RID: 1377
        pcMaxEnh,
        // Token: 0x04000562 RID: 1378
        DPS
    }

    // Token: 0x0200005F RID: 95
    public enum eDDGraph
    {
        // Token: 0x04000564 RID: 1380
        Simple,
        // Token: 0x04000565 RID: 1381
        Enhanced,
        // Token: 0x04000566 RID: 1382
        Both,
        // Token: 0x04000567 RID: 1383
        Stacked
    }

    // Token: 0x02000060 RID: 96
    public enum eDDAlign
    {
        // Token: 0x04000569 RID: 1385
        Left,
        // Token: 0x0400056A RID: 1386
        Center,
        // Token: 0x0400056B RID: 1387
        Right
    }

    // Token: 0x02000061 RID: 97
    public enum eVisibleSize
    {
        // Token: 0x0400056D RID: 1389
        Full,
        // Token: 0x0400056E RID: 1390
        Small,
        // Token: 0x0400056F RID: 1391
        VerySmall,
        // Token: 0x04000570 RID: 1392
        Compact
    }

    // Token: 0x02000062 RID: 98
    public enum GraphStyle
    {
        // Token: 0x04000572 RID: 1394
        Twin,
        // Token: 0x04000573 RID: 1395
        Stacked,
        // Token: 0x04000574 RID: 1396
        baseOnly,
        // Token: 0x04000575 RID: 1397
        enhOnly
    }

    // Token: 0x02000063 RID: 99
    public enum dmItem
    {
        // Token: 0x04000577 RID: 1399
        None,
        // Token: 0x04000578 RID: 1400
        Power,
        // Token: 0x04000579 RID: 1401
        Slot
    }

    // Token: 0x02000064 RID: 100
    public enum dmModes
    {
        // Token: 0x0400057B RID: 1403
        LevelUp,
        // Token: 0x0400057C RID: 1404
        Dynamic,
        // Token: 0x0400057D RID: 1405
        Respec
    }

    // Token: 0x02000065 RID: 101
    public enum eInterfaceMode
    {
        // Token: 0x0400057F RID: 1407
        Normal,
        // Token: 0x04000580 RID: 1408
        PowerToggle
    }

    // Token: 0x02000066 RID: 102
    public enum eSpeedMeasure
    {
        // Token: 0x04000582 RID: 1410
        FeetPerSecond,
        // Token: 0x04000583 RID: 1411
        MetersPerSecond,
        // Token: 0x04000584 RID: 1412
        MilesPerHour,
        // Token: 0x04000585 RID: 1413
        KilometersPerHour
    }

    // Token: 0x02000067 RID: 103
    public struct ShortFX
    {
        // Token: 0x17000242 RID: 578
        // (get) Token: 0x060005B4 RID: 1460 RVA: 0x00024260 File Offset: 0x00022460
        public bool Present
        {
            get
            {
                return this.Index != null && this.Index.Length >= 1 && this.Index[0] != -1;
            }
        }

        // Token: 0x17000243 RID: 579
        // (get) Token: 0x060005B5 RID: 1461 RVA: 0x00024298 File Offset: 0x00022498
        public bool Multiple
        {
            get
            {
                return this.Index != null && this.Index.Length > 1;
            }
        }

        // Token: 0x17000244 RID: 580
        // (get) Token: 0x060005B6 RID: 1462 RVA: 0x000242C4 File Offset: 0x000224C4
        public int Max
        {
            get
            {
                float num = 0f;
                int num2 = 0;
                int num3;
                if (this.Present)
                {
                    for (int index = 0; index < this.Value.Length; index++)
                    {
                        if (this.Value[index] > num)
                        {
                            num = this.Value[index];
                            num2 = index;
                        }
                    }
                    num3 = num2;
                }
                else
                {
                    num3 = -1;
                }
                return num3;
            }
        }

        // Token: 0x060005B7 RID: 1463 RVA: 0x00024338 File Offset: 0x00022538
        public void Add(int iIndex, float iValue)
        {
            if (this.Value == null)
            {
                this.Value = new float[0];
                this.Index = new int[0];
                this.Sum = 0f;
            }
            Array.Resize<float>(ref this.Value, this.Value.Length + 1);
            Array.Resize<int>(ref this.Index, this.Index.Length + 1);
            this.Value[this.Value.Length - 1] = iValue;
            this.Index[this.Index.Length - 1] = iIndex;
            this.Sum += iValue;
        }

        // Token: 0x060005B8 RID: 1464 RVA: 0x000243DC File Offset: 0x000225DC
        public void Remove(int iIndex)
        {
            float[] numArray = new float[this.Value.Length - 1];
            int[] numArray2 = new int[this.Index.Length - 1];
            int index = 0;
            for (int index2 = 0; index2 <= this.Index.Length - 1; index2++)
            {
                if (index2 != iIndex)
                {
                    numArray[index] = this.Value[index2];
                    numArray2[index] = this.Index[index2];
                    index++;
                }
            }
            this.Value = numArray;
            this.Index = numArray2;
        }

        // Token: 0x060005B9 RID: 1465 RVA: 0x00024460 File Offset: 0x00022660
        public void Assign(Enums.ShortFX iFX)
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
                this.Sum = 0f;
            }
        }

        // Token: 0x060005BA RID: 1466 RVA: 0x000244CC File Offset: 0x000226CC
        public void Multiply()
        {
            if (this.Value != null)
            {
                for (int index = 0; index <= this.Value.Length - 1; index++)
                {
                    this.Value[index] *= 100f;
                }
                this.Sum *= 100f;
            }
        }

        // Token: 0x060005BB RID: 1467 RVA: 0x00024538 File Offset: 0x00022738
        public void ReSum()
        {
            this.Sum = 0f;
            for (int index = 0; index < this.Value.Length; index++)
            {
                this.Sum += this.Value[index];
            }
        }

        // Token: 0x04000586 RID: 1414
        public int[] Index;

        // Token: 0x04000587 RID: 1415
        public float[] Value;

        // Token: 0x04000588 RID: 1416
        public float Sum;
    }

    // Token: 0x02000068 RID: 104
    public struct CompMap
    {
        // Token: 0x060005BC RID: 1468 RVA: 0x00024580 File Offset: 0x00022780
        public void Init()
        {
            this.IdxAT = new int[2];
            this.IdxSet = new int[2];
            this.Map = new int[21, 2];
            for (int index = 0; index < 21; index++)
            {
                this.Map[index, 0] = -1;
                this.Map[index, 1] = -1;
            }
        }

        // Token: 0x04000589 RID: 1417
        public const int UBound = 21;

        // Token: 0x0400058A RID: 1418
        public int[] IdxAT;

        // Token: 0x0400058B RID: 1419
        public int[] IdxSet;

        // Token: 0x0400058C RID: 1420
        public int[,] Map;
    }

    // Token: 0x02000069 RID: 105
    public struct CompOverride
    {
        // Token: 0x0400058D RID: 1421
        public string Powerset;

        // Token: 0x0400058E RID: 1422
        public string Power;

        // Token: 0x0400058F RID: 1423
        public string Override;
    }

    // Token: 0x0200006A RID: 106
    public struct BuffsX
    {
        // Token: 0x060005BD RID: 1469 RVA: 0x000245E4 File Offset: 0x000227E4
        public void Reset()
        {
            this.MaxEnd = 0f;
            this.Effect = new float[Enum.GetValues(Enums.eEffectType.None.GetType()).Length];
            this.EffectAux = new float[this.Effect.Length - 1];
            this.Mez = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
            this.MezRes = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
            this.Damage = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            this.Defense = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            this.Resistance = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            this.StatusProtection = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
            this.StatusResistance = new float[Enum.GetValues(Enums.eMez.None.GetType()).Length];
            this.DebuffResistance = new float[Enum.GetValues(Enums.eEffectType.None.GetType()).Length];
        }

        // Token: 0x04000590 RID: 1424
        public float[] Effect;

        // Token: 0x04000591 RID: 1425
        public float[] EffectAux;

        // Token: 0x04000592 RID: 1426
        public float[] Mez;

        // Token: 0x04000593 RID: 1427
        public float[] MezRes;

        // Token: 0x04000594 RID: 1428
        public float[] Damage;

        // Token: 0x04000595 RID: 1429
        public float[] Defense;

        // Token: 0x04000596 RID: 1430
        public float[] Resistance;

        // Token: 0x04000597 RID: 1431
        public float[] StatusProtection;

        // Token: 0x04000598 RID: 1432
        public float[] StatusResistance;

        // Token: 0x04000599 RID: 1433
        public float[] DebuffResistance;

        // Token: 0x0400059A RID: 1434
        public float MaxEnd;
    }

    // Token: 0x0200006B RID: 107
    public class VersionData
    {
        // Token: 0x060005BE RID: 1470 RVA: 0x00024732 File Offset: 0x00022932
        public void Load(BinaryReader reader)
        {
            this.Revision = reader.ReadInt32();
            this.RevisionDate = DateTime.FromBinary(reader.ReadInt64());
            this.SourceFile = reader.ReadString();
        }

        // Token: 0x060005BF RID: 1471 RVA: 0x0002475E File Offset: 0x0002295E
        public void StoreTo(BinaryWriter writer)
        {
            writer.Write(this.Revision);
            writer.Write(this.RevisionDate.ToBinary());
            writer.Write(FileIO.StripPath(this.SourceFile));
        }

        // Token: 0x0400059B RID: 1435
        public int Revision;

        // Token: 0x0400059C RID: 1436
        public DateTime RevisionDate = new DateTime(0L);

        // Token: 0x0400059D RID: 1437
        public string SourceFile = "";
    }
}
