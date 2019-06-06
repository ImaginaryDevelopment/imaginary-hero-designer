using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Base.Master_Classes;

namespace Base.Data_Classes
{
    // Token: 0x0200000C RID: 12
    public class Power : IPower, IComparable
    {
        // Token: 0x17000195 RID: 405
        // (get) Token: 0x06000381 RID: 897 RVA: 0x0000C668 File Offset: 0x0000A868
        // (set) Token: 0x06000382 RID: 898 RVA: 0x0000C6BA File Offset: 0x0000A8BA
        public IPowerset PowerSet
        {
            get
            {
                IPowerset result;
                if (this.PowerSetID < 0 | this.PowerSetID > DatabaseAPI.Database.Powersets.Length)
                {
                    result = null;
                }
                else
                {
                    result = DatabaseAPI.Database.Powersets[this.PowerSetID];
                }
                return result;
            }
            set
            {
                this.PowerSetID = value.nID;
            }
        }

        // Token: 0x17000196 RID: 406
        // (get) Token: 0x06000383 RID: 899 RVA: 0x0000C6CC File Offset: 0x0000A8CC
        public string FullSetName
        {
            get
            {
                char[] separator = new char[]
                {
                    '.'
                };
                string[] strArray = this.FullName.Split(separator);
                string result;
                if (strArray.Length > 1)
                {
                    result = strArray[0] + "." + strArray[1];
                }
                else
                {
                    result = string.Empty;
                }
                return result;
            }
        }

        // Token: 0x17000197 RID: 407
        // (get) Token: 0x06000384 RID: 900 RVA: 0x0000C72C File Offset: 0x0000A92C
        // (set) Token: 0x06000385 RID: 901 RVA: 0x0000C785 File Offset: 0x0000A985
        public float CastTime
        {
            get
            {
                float result;
                if (MidsContext.Config.UseArcanaTime)
                {
                    float num = this.CastTimeReal / 0.132f;
                    num = (float)(Math.Ceiling((double)num) + 1.0);
                    result = num * 0.132f;
                }
                else
                {
                    result = this.CastTimeReal;
                }
                return result;
            }
            set
            {
                this.CastTimeReal = value;
            }
        }

        // Token: 0x17000198 RID: 408
        // (get) Token: 0x06000386 RID: 902 RVA: 0x0000C790 File Offset: 0x0000A990
        // (set) Token: 0x06000387 RID: 903 RVA: 0x0000C7A7 File Offset: 0x0000A9A7
        public float CastTimeReal { get; set; }

        // Token: 0x17000199 RID: 409
        // (get) Token: 0x06000388 RID: 904 RVA: 0x0000C7B0 File Offset: 0x0000A9B0
        public float ToggleCost
        {
            get
            {
                float result;
                if (this.PowerType == Enums.ePowerType.Toggle & this.ActivatePeriod > 0f)
                {
                    result = this.EndCost / this.ActivatePeriod;
                }
                else
                {
                    result = this.EndCost;
                }
                return result;
            }
        }

        // Token: 0x1700019A RID: 410
        // (get) Token: 0x06000389 RID: 905 RVA: 0x0000C7FC File Offset: 0x0000A9FC
        public bool IsEpic
        {
            get
            {
                return this.Requires.NPowerID.Length > 0 && this.Requires.NPowerID[0][0] != -1;
            }
        }

        // Token: 0x1700019B RID: 411
        // (get) Token: 0x0600038A RID: 906 RVA: 0x0000C838 File Offset: 0x0000AA38
        public bool Slottable
        {
            get
            {
                return this.Enhancements.Length > 0 && (this.PowerSet.SetType == Enums.ePowerSetType.Primary || this.PowerSet.SetType == Enums.ePowerSetType.Secondary || this.PowerSet.SetType == Enums.ePowerSetType.Ancillary || this.PowerSet.SetType == Enums.ePowerSetType.Inherent || this.PowerSet.SetType == Enums.ePowerSetType.Pool);
            }
        }

        // Token: 0x1700019C RID: 412
        // (get) Token: 0x0600038B RID: 907 RVA: 0x0000C8A4 File Offset: 0x0000AAA4
        // (set) Token: 0x0600038C RID: 908 RVA: 0x0000C8BB File Offset: 0x0000AABB
        public int LocationIndex { get; private set; }

        // Token: 0x1700019D RID: 413
        // (get) Token: 0x0600038D RID: 909 RVA: 0x0000C8C4 File Offset: 0x0000AAC4
        // (set) Token: 0x0600038E RID: 910 RVA: 0x0000C8DB File Offset: 0x0000AADB
        public bool IsModified { get; set; }

        // Token: 0x1700019E RID: 414
        // (get) Token: 0x0600038F RID: 911 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
        // (set) Token: 0x06000390 RID: 912 RVA: 0x0000C8FB File Offset: 0x0000AAFB
        public bool IsNew { get; set; }

        // Token: 0x1700019F RID: 415
        // (get) Token: 0x06000391 RID: 913 RVA: 0x0000C904 File Offset: 0x0000AB04
        // (set) Token: 0x06000392 RID: 914 RVA: 0x0000C91B File Offset: 0x0000AB1B
        public int PowerIndex { get; set; }

        // Token: 0x170001A0 RID: 416
        // (get) Token: 0x06000393 RID: 915 RVA: 0x0000C924 File Offset: 0x0000AB24
        // (set) Token: 0x06000394 RID: 916 RVA: 0x0000C93B File Offset: 0x0000AB3B
        public int PowerSetID { get; set; }

        // Token: 0x170001A1 RID: 417
        // (get) Token: 0x06000395 RID: 917 RVA: 0x0000C944 File Offset: 0x0000AB44
        // (set) Token: 0x06000396 RID: 918 RVA: 0x0000C95B File Offset: 0x0000AB5B
        public int PowerSetIndex { get; set; }

        // Token: 0x170001A2 RID: 418
        // (get) Token: 0x06000397 RID: 919 RVA: 0x0000C964 File Offset: 0x0000AB64
        // (set) Token: 0x06000398 RID: 920 RVA: 0x0000C97B File Offset: 0x0000AB7B
        public bool HasAbsorbedEffects { get; set; }

        // Token: 0x170001A3 RID: 419
        // (get) Token: 0x06000399 RID: 921 RVA: 0x0000C984 File Offset: 0x0000AB84
        // (set) Token: 0x0600039A RID: 922 RVA: 0x0000C99B File Offset: 0x0000AB9B
        public int StaticIndex { get; set; }

        // Token: 0x170001A4 RID: 420
        // (get) Token: 0x0600039B RID: 923 RVA: 0x0000C9A4 File Offset: 0x0000ABA4
        // (set) Token: 0x0600039C RID: 924 RVA: 0x0000C9BB File Offset: 0x0000ABBB
        public int[] NGroupMembership { get; set; }

        // Token: 0x170001A5 RID: 421
        // (get) Token: 0x0600039D RID: 925 RVA: 0x0000C9C4 File Offset: 0x0000ABC4
        // (set) Token: 0x0600039E RID: 926 RVA: 0x0000C9DB File Offset: 0x0000ABDB
        public string FullName { get; set; }

        // Token: 0x170001A6 RID: 422
        // (get) Token: 0x0600039F RID: 927 RVA: 0x0000C9E4 File Offset: 0x0000ABE4
        // (set) Token: 0x060003A0 RID: 928 RVA: 0x0000C9FB File Offset: 0x0000ABFB
        public string GroupName { get; set; }

        // Token: 0x170001A7 RID: 423
        // (get) Token: 0x060003A1 RID: 929 RVA: 0x0000CA04 File Offset: 0x0000AC04
        // (set) Token: 0x060003A2 RID: 930 RVA: 0x0000CA1B File Offset: 0x0000AC1B
        public string SetName { get; set; }

        // Token: 0x170001A8 RID: 424
        // (get) Token: 0x060003A3 RID: 931 RVA: 0x0000CA24 File Offset: 0x0000AC24
        // (set) Token: 0x060003A4 RID: 932 RVA: 0x0000CA3B File Offset: 0x0000AC3B
        public string PowerName { get; set; }

        // Token: 0x170001A9 RID: 425
        // (get) Token: 0x060003A5 RID: 933 RVA: 0x0000CA44 File Offset: 0x0000AC44
        // (set) Token: 0x060003A6 RID: 934 RVA: 0x0000CA5B File Offset: 0x0000AC5B
        public string DisplayName { get; set; }

        // Token: 0x170001AA RID: 426
        // (get) Token: 0x060003A7 RID: 935 RVA: 0x0000CA64 File Offset: 0x0000AC64
        // (set) Token: 0x060003A8 RID: 936 RVA: 0x0000CA7B File Offset: 0x0000AC7B
        public int Available { get; set; }

        // Token: 0x170001AB RID: 427
        // (get) Token: 0x060003A9 RID: 937 RVA: 0x0000CA84 File Offset: 0x0000AC84
        // (set) Token: 0x060003AA RID: 938 RVA: 0x0000CA9B File Offset: 0x0000AC9B
        public Requirement Requires { get; set; }

        // Token: 0x170001AC RID: 428
        // (get) Token: 0x060003AB RID: 939 RVA: 0x0000CAA4 File Offset: 0x0000ACA4
        // (set) Token: 0x060003AC RID: 940 RVA: 0x0000CABB File Offset: 0x0000ACBB
        public Enums.eModeFlags ModesRequired { get; set; }

        // Token: 0x170001AD RID: 429
        // (get) Token: 0x060003AD RID: 941 RVA: 0x0000CAC4 File Offset: 0x0000ACC4
        // (set) Token: 0x060003AE RID: 942 RVA: 0x0000CADB File Offset: 0x0000ACDB
        public Enums.eModeFlags ModesDisallowed { get; set; }

        // Token: 0x170001AE RID: 430
        // (get) Token: 0x060003AF RID: 943 RVA: 0x0000CAE4 File Offset: 0x0000ACE4
        // (set) Token: 0x060003B0 RID: 944 RVA: 0x0000CAFB File Offset: 0x0000ACFB
        public Enums.ePowerType PowerType { get; set; }

        // Token: 0x170001AF RID: 431
        // (get) Token: 0x060003B1 RID: 945 RVA: 0x0000CB04 File Offset: 0x0000AD04
        // (set) Token: 0x060003B2 RID: 946 RVA: 0x0000CB1B File Offset: 0x0000AD1B
        public float Accuracy { get; set; }

        // Token: 0x170001B0 RID: 432
        // (get) Token: 0x060003B3 RID: 947 RVA: 0x0000CB24 File Offset: 0x0000AD24
        // (set) Token: 0x060003B4 RID: 948 RVA: 0x0000CB3B File Offset: 0x0000AD3B
        public float AccuracyMult { get; set; }

        // Token: 0x170001B1 RID: 433
        // (get) Token: 0x060003B5 RID: 949 RVA: 0x0000CB44 File Offset: 0x0000AD44
        // (set) Token: 0x060003B6 RID: 950 RVA: 0x0000CB5B File Offset: 0x0000AD5B
        public Enums.eVector AttackTypes { get; set; }

        // Token: 0x170001B2 RID: 434
        // (get) Token: 0x060003B7 RID: 951 RVA: 0x0000CB64 File Offset: 0x0000AD64
        // (set) Token: 0x060003B8 RID: 952 RVA: 0x0000CB7B File Offset: 0x0000AD7B
        public string[] GroupMembership { get; set; }

        // Token: 0x170001B3 RID: 435
        // (get) Token: 0x060003B9 RID: 953 RVA: 0x0000CB84 File Offset: 0x0000AD84
        // (set) Token: 0x060003BA RID: 954 RVA: 0x0000CB9B File Offset: 0x0000AD9B
        public Enums.eEntity EntitiesAffected { get; set; }

        // Token: 0x170001B4 RID: 436
        // (get) Token: 0x060003BB RID: 955 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
        // (set) Token: 0x060003BC RID: 956 RVA: 0x0000CBBB File Offset: 0x0000ADBB
        public Enums.eEntity EntitiesAutoHit { get; set; }

        // Token: 0x170001B5 RID: 437
        // (get) Token: 0x060003BD RID: 957 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
        // (set) Token: 0x060003BE RID: 958 RVA: 0x0000CBDB File Offset: 0x0000ADDB
        public Enums.eEntity Target { get; set; }

        // Token: 0x170001B6 RID: 438
        // (get) Token: 0x060003BF RID: 959 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
        // (set) Token: 0x060003C0 RID: 960 RVA: 0x0000CBFB File Offset: 0x0000ADFB
        public bool TargetLoS { get; set; }

        // Token: 0x170001B7 RID: 439
        // (get) Token: 0x060003C1 RID: 961 RVA: 0x0000CC04 File Offset: 0x0000AE04
        // (set) Token: 0x060003C2 RID: 962 RVA: 0x0000CC1B File Offset: 0x0000AE1B
        public float Range { get; set; }

        // Token: 0x170001B8 RID: 440
        // (get) Token: 0x060003C3 RID: 963 RVA: 0x0000CC24 File Offset: 0x0000AE24
        // (set) Token: 0x060003C4 RID: 964 RVA: 0x0000CC3B File Offset: 0x0000AE3B
        public Enums.eEntity TargetSecondary { get; set; }

        // Token: 0x170001B9 RID: 441
        // (get) Token: 0x060003C5 RID: 965 RVA: 0x0000CC44 File Offset: 0x0000AE44
        // (set) Token: 0x060003C6 RID: 966 RVA: 0x0000CC5B File Offset: 0x0000AE5B
        public float RangeSecondary { get; set; }

        // Token: 0x170001BA RID: 442
        // (get) Token: 0x060003C7 RID: 967 RVA: 0x0000CC64 File Offset: 0x0000AE64
        // (set) Token: 0x060003C8 RID: 968 RVA: 0x0000CC7B File Offset: 0x0000AE7B
        public float EndCost { get; set; }

        // Token: 0x170001BB RID: 443
        // (get) Token: 0x060003C9 RID: 969 RVA: 0x0000CC84 File Offset: 0x0000AE84
        // (set) Token: 0x060003CA RID: 970 RVA: 0x0000CC9B File Offset: 0x0000AE9B
        public float InterruptTime { get; set; }

        // Token: 0x170001BC RID: 444
        // (get) Token: 0x060003CB RID: 971 RVA: 0x0000CCA4 File Offset: 0x0000AEA4
        // (set) Token: 0x060003CC RID: 972 RVA: 0x0000CCBB File Offset: 0x0000AEBB
        public float RechargeTime { get; set; }

        // Token: 0x170001BD RID: 445
        // (get) Token: 0x060003CD RID: 973 RVA: 0x0000CCC4 File Offset: 0x0000AEC4
        // (set) Token: 0x060003CE RID: 974 RVA: 0x0000CCDB File Offset: 0x0000AEDB
        public float ActivatePeriod { get; set; }

        // Token: 0x170001BE RID: 446
        // (get) Token: 0x060003CF RID: 975 RVA: 0x0000CCE4 File Offset: 0x0000AEE4
        // (set) Token: 0x060003D0 RID: 976 RVA: 0x0000CCFB File Offset: 0x0000AEFB
        public Enums.eEffectArea EffectArea { get; set; }

        // Token: 0x170001BF RID: 447
        // (get) Token: 0x060003D1 RID: 977 RVA: 0x0000CD04 File Offset: 0x0000AF04
        // (set) Token: 0x060003D2 RID: 978 RVA: 0x0000CD1B File Offset: 0x0000AF1B
        public float Radius { get; set; }

        // Token: 0x170001C0 RID: 448
        // (get) Token: 0x060003D3 RID: 979 RVA: 0x0000CD24 File Offset: 0x0000AF24
        public float AoEModifier
        {
            get
            {
                float result;
                if (this.EffectArea == Enums.eEffectArea.Cone)
                {
                    result = 1f + this.Radius * 0.15f - this.Radius * 0.00036667f * (float)(360 - this.Arc);
                }
                else if (this.EffectArea == Enums.eEffectArea.Sphere)
                {
                    result = 1f + this.Radius * 0.15f;
                }
                else
                {
                    result = 1f;
                }
                return result;
            }
        }

        // Token: 0x170001C1 RID: 449
        // (get) Token: 0x060003D4 RID: 980 RVA: 0x0000CDA8 File Offset: 0x0000AFA8
        // (set) Token: 0x060003D5 RID: 981 RVA: 0x0000CDBF File Offset: 0x0000AFBF
        public int Arc { get; set; }

        // Token: 0x170001C2 RID: 450
        // (get) Token: 0x060003D6 RID: 982 RVA: 0x0000CDC8 File Offset: 0x0000AFC8
        // (set) Token: 0x060003D7 RID: 983 RVA: 0x0000CDDF File Offset: 0x0000AFDF
        public int MaxTargets { get; set; }

        // Token: 0x170001C3 RID: 451
        // (get) Token: 0x060003D8 RID: 984 RVA: 0x0000CDE8 File Offset: 0x0000AFE8
        // (set) Token: 0x060003D9 RID: 985 RVA: 0x0000CDFF File Offset: 0x0000AFFF
        public string MaxBoosts { get; set; }

        // Token: 0x170001C4 RID: 452
        // (get) Token: 0x060003DA RID: 986 RVA: 0x0000CE08 File Offset: 0x0000B008
        // (set) Token: 0x060003DB RID: 987 RVA: 0x0000CE1F File Offset: 0x0000B01F
        public Enums.eCastFlags CastFlags { get; set; }

        // Token: 0x170001C5 RID: 453
        // (get) Token: 0x060003DC RID: 988 RVA: 0x0000CE28 File Offset: 0x0000B028
        // (set) Token: 0x060003DD RID: 989 RVA: 0x0000CE3F File Offset: 0x0000B03F
        public Enums.eNotify AIReport { get; set; }

        // Token: 0x170001C6 RID: 454
        // (get) Token: 0x060003DE RID: 990 RVA: 0x0000CE48 File Offset: 0x0000B048
        // (set) Token: 0x060003DF RID: 991 RVA: 0x0000CE5F File Offset: 0x0000B05F
        public int NumCharges { get; set; }

        // Token: 0x170001C7 RID: 455
        // (get) Token: 0x060003E0 RID: 992 RVA: 0x0000CE68 File Offset: 0x0000B068
        // (set) Token: 0x060003E1 RID: 993 RVA: 0x0000CE7F File Offset: 0x0000B07F
        public int UsageTime { get; set; }

        // Token: 0x170001C8 RID: 456
        // (get) Token: 0x060003E2 RID: 994 RVA: 0x0000CE88 File Offset: 0x0000B088
        // (set) Token: 0x060003E3 RID: 995 RVA: 0x0000CE9F File Offset: 0x0000B09F
        public int LifeTime { get; set; }

        // Token: 0x170001C9 RID: 457
        // (get) Token: 0x060003E4 RID: 996 RVA: 0x0000CEA8 File Offset: 0x0000B0A8
        // (set) Token: 0x060003E5 RID: 997 RVA: 0x0000CEBF File Offset: 0x0000B0BF
        public int LifeTimeInGame { get; set; }

        // Token: 0x170001CA RID: 458
        // (get) Token: 0x060003E6 RID: 998 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
        // (set) Token: 0x060003E7 RID: 999 RVA: 0x0000CEDF File Offset: 0x0000B0DF
        public int NumAllowed { get; set; }

        // Token: 0x170001CB RID: 459
        // (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000CEE8 File Offset: 0x0000B0E8
        // (set) Token: 0x060003E9 RID: 1001 RVA: 0x0000CEFF File Offset: 0x0000B0FF
        public bool DoNotSave { get; set; }

        // Token: 0x170001CC RID: 460
        // (get) Token: 0x060003EA RID: 1002 RVA: 0x0000CF08 File Offset: 0x0000B108
        // (set) Token: 0x060003EB RID: 1003 RVA: 0x0000CF1F File Offset: 0x0000B11F
        public string[] BoostsAllowed { get; set; }

        // Token: 0x170001CD RID: 461
        // (get) Token: 0x060003EC RID: 1004 RVA: 0x0000CF28 File Offset: 0x0000B128
        // (set) Token: 0x060003ED RID: 1005 RVA: 0x0000CF3F File Offset: 0x0000B13F
        public int[] Enhancements { get; set; }

        // Token: 0x170001CE RID: 462
        // (get) Token: 0x060003EE RID: 1006 RVA: 0x0000CF48 File Offset: 0x0000B148
        // (set) Token: 0x060003EF RID: 1007 RVA: 0x0000CF5F File Offset: 0x0000B15F
        public bool CastThroughHold { get; set; }

        // Token: 0x170001CF RID: 463
        // (get) Token: 0x060003F0 RID: 1008 RVA: 0x0000CF68 File Offset: 0x0000B168
        // (set) Token: 0x060003F1 RID: 1009 RVA: 0x0000CF7F File Offset: 0x0000B17F
        public bool IgnoreStrength { get; set; }

        // Token: 0x170001D0 RID: 464
        // (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000CF88 File Offset: 0x0000B188
        // (set) Token: 0x060003F3 RID: 1011 RVA: 0x0000CF9F File Offset: 0x0000B19F
        public string DescShort { get; set; }

        // Token: 0x170001D1 RID: 465
        // (get) Token: 0x060003F4 RID: 1012 RVA: 0x0000CFA8 File Offset: 0x0000B1A8
        // (set) Token: 0x060003F5 RID: 1013 RVA: 0x0000CFBF File Offset: 0x0000B1BF
        public string DescLong { get; set; }

        // Token: 0x170001D2 RID: 466
        // (get) Token: 0x060003F6 RID: 1014 RVA: 0x0000CFC8 File Offset: 0x0000B1C8
        // (set) Token: 0x060003F7 RID: 1015 RVA: 0x0000CFDF File Offset: 0x0000B1DF
        public bool SortOverride { get; set; }

        // Token: 0x170001D3 RID: 467
        // (get) Token: 0x060003F8 RID: 1016 RVA: 0x0000CFE8 File Offset: 0x0000B1E8
        // (set) Token: 0x060003F9 RID: 1017 RVA: 0x0000CFFF File Offset: 0x0000B1FF
        public bool HiddenPower { get; set; }

        // Token: 0x170001D4 RID: 468
        // (get) Token: 0x060003FA RID: 1018 RVA: 0x0000D008 File Offset: 0x0000B208
        // (set) Token: 0x060003FB RID: 1019 RVA: 0x0000D01F File Offset: 0x0000B21F
        public Enums.eSetType[] SetTypes { get; set; }

        // Token: 0x170001D5 RID: 469
        // (get) Token: 0x060003FC RID: 1020 RVA: 0x0000D028 File Offset: 0x0000B228
        // (set) Token: 0x060003FD RID: 1021 RVA: 0x0000D03F File Offset: 0x0000B23F
        public bool ClickBuff { get; set; }

        // Token: 0x170001D6 RID: 470
        // (get) Token: 0x060003FE RID: 1022 RVA: 0x0000D048 File Offset: 0x0000B248
        // (set) Token: 0x060003FF RID: 1023 RVA: 0x0000D05F File Offset: 0x0000B25F
        public bool AlwaysToggle { get; set; }

        // Token: 0x170001D7 RID: 471
        // (get) Token: 0x06000400 RID: 1024 RVA: 0x0000D068 File Offset: 0x0000B268
        // (set) Token: 0x06000401 RID: 1025 RVA: 0x0000D07F File Offset: 0x0000B27F
        public int Level { get; set; }

        // Token: 0x170001D8 RID: 472
        // (get) Token: 0x06000402 RID: 1026 RVA: 0x0000D088 File Offset: 0x0000B288
        // (set) Token: 0x06000403 RID: 1027 RVA: 0x0000D09F File Offset: 0x0000B29F
        public bool AllowFrontLoading { get; set; }

        // Token: 0x170001D9 RID: 473
        // (get) Token: 0x06000404 RID: 1028 RVA: 0x0000D0A8 File Offset: 0x0000B2A8
        // (set) Token: 0x06000405 RID: 1029 RVA: 0x0000D0BF File Offset: 0x0000B2BF
        public bool VariableEnabled { get; set; }

        // Token: 0x170001DA RID: 474
        // (get) Token: 0x06000406 RID: 1030 RVA: 0x0000D0C8 File Offset: 0x0000B2C8
        // (set) Token: 0x06000407 RID: 1031 RVA: 0x0000D0DF File Offset: 0x0000B2DF
        public string VariableName { get; set; }

        // Token: 0x170001DB RID: 475
        // (get) Token: 0x06000408 RID: 1032 RVA: 0x0000D0E8 File Offset: 0x0000B2E8
        // (set) Token: 0x06000409 RID: 1033 RVA: 0x0000D0FF File Offset: 0x0000B2FF
        public int VariableMin { get; set; }

        // Token: 0x170001DC RID: 476
        // (get) Token: 0x0600040A RID: 1034 RVA: 0x0000D108 File Offset: 0x0000B308
        // (set) Token: 0x0600040B RID: 1035 RVA: 0x0000D11F File Offset: 0x0000B31F
        public int VariableMax { get; set; }

        // Token: 0x170001DD RID: 477
        // (get) Token: 0x0600040C RID: 1036 RVA: 0x0000D128 File Offset: 0x0000B328
        // (set) Token: 0x0600040D RID: 1037 RVA: 0x0000D13F File Offset: 0x0000B33F
        public int[] NIDSubPower { get; set; }

        // Token: 0x170001DE RID: 478
        // (get) Token: 0x0600040E RID: 1038 RVA: 0x0000D148 File Offset: 0x0000B348
        // (set) Token: 0x0600040F RID: 1039 RVA: 0x0000D15F File Offset: 0x0000B35F
        public string[] UIDSubPower { get; set; }

        // Token: 0x170001DF RID: 479
        // (get) Token: 0x06000410 RID: 1040 RVA: 0x0000D168 File Offset: 0x0000B368
        // (set) Token: 0x06000411 RID: 1041 RVA: 0x0000D17F File Offset: 0x0000B37F
        public bool SubIsAltColour { get; set; }

        // Token: 0x170001E0 RID: 480
        // (get) Token: 0x06000412 RID: 1042 RVA: 0x0000D188 File Offset: 0x0000B388
        // (set) Token: 0x06000413 RID: 1043 RVA: 0x0000D19F File Offset: 0x0000B39F
        public Enums.eEnhance[] IgnoreEnh { get; set; }

        // Token: 0x170001E1 RID: 481
        // (get) Token: 0x06000414 RID: 1044 RVA: 0x0000D1A8 File Offset: 0x0000B3A8
        // (set) Token: 0x06000415 RID: 1045 RVA: 0x0000D1BF File Offset: 0x0000B3BF
        public Enums.eEnhance[] Ignore_Buff { get; set; }

        // Token: 0x170001E2 RID: 482
        // (get) Token: 0x06000416 RID: 1046 RVA: 0x0000D1C8 File Offset: 0x0000B3C8
        // (set) Token: 0x06000417 RID: 1047 RVA: 0x0000D1DF File Offset: 0x0000B3DF
        public bool SkipMax { get; set; }

        // Token: 0x170001E3 RID: 483
        // (get) Token: 0x06000418 RID: 1048 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
        // (set) Token: 0x06000419 RID: 1049 RVA: 0x0000D200 File Offset: 0x0000B400
        public int DisplayLocation
        {
            get
            {
                return this.LocationIndex;
            }
            set
            {
                this.LocationIndex = value;
            }
        }

        // Token: 0x170001E4 RID: 484
        // (get) Token: 0x0600041A RID: 1050 RVA: 0x0000D20C File Offset: 0x0000B40C
        // (set) Token: 0x0600041B RID: 1051 RVA: 0x0000D223 File Offset: 0x0000B423
        public bool MutexAuto { get; set; }

        // Token: 0x170001E5 RID: 485
        // (get) Token: 0x0600041C RID: 1052 RVA: 0x0000D22C File Offset: 0x0000B42C
        // (set) Token: 0x0600041D RID: 1053 RVA: 0x0000D243 File Offset: 0x0000B443
        public bool MutexIgnore { get; set; }

        // Token: 0x170001E6 RID: 486
        // (get) Token: 0x0600041E RID: 1054 RVA: 0x0000D24C File Offset: 0x0000B44C
        // (set) Token: 0x0600041F RID: 1055 RVA: 0x0000D263 File Offset: 0x0000B463
        public bool AbsorbSummonEffects { get; set; }

        // Token: 0x170001E7 RID: 487
        // (get) Token: 0x06000420 RID: 1056 RVA: 0x0000D26C File Offset: 0x0000B46C
        // (set) Token: 0x06000421 RID: 1057 RVA: 0x0000D283 File Offset: 0x0000B483
        public bool AbsorbSummonAttributes { get; set; }

        // Token: 0x170001E8 RID: 488
        // (get) Token: 0x06000422 RID: 1058 RVA: 0x0000D28C File Offset: 0x0000B48C
        // (set) Token: 0x06000423 RID: 1059 RVA: 0x0000D2A3 File Offset: 0x0000B4A3
        public bool ShowSummonAnyway { get; set; }

        // Token: 0x170001E9 RID: 489
        // (get) Token: 0x06000424 RID: 1060 RVA: 0x0000D2AC File Offset: 0x0000B4AC
        // (set) Token: 0x06000425 RID: 1061 RVA: 0x0000D2C3 File Offset: 0x0000B4C3
        public bool NeverAutoUpdate { get; set; }

        // Token: 0x170001EA RID: 490
        // (get) Token: 0x06000426 RID: 1062 RVA: 0x0000D2CC File Offset: 0x0000B4CC
        // (set) Token: 0x06000427 RID: 1063 RVA: 0x0000D2E3 File Offset: 0x0000B4E3
        public bool NeverAutoUpdateRequirements { get; set; }

        // Token: 0x170001EB RID: 491
        // (get) Token: 0x06000428 RID: 1064 RVA: 0x0000D2EC File Offset: 0x0000B4EC
        // (set) Token: 0x06000429 RID: 1065 RVA: 0x0000D303 File Offset: 0x0000B503
        public bool IncludeFlag { get; set; }

        // Token: 0x170001EC RID: 492
        // (get) Token: 0x0600042A RID: 1066 RVA: 0x0000D30C File Offset: 0x0000B50C
        // (set) Token: 0x0600042B RID: 1067 RVA: 0x0000D323 File Offset: 0x0000B523
        public string ForcedClass { get; set; }

        // Token: 0x170001ED RID: 493
        // (get) Token: 0x0600042C RID: 1068 RVA: 0x0000D32C File Offset: 0x0000B52C
        // (set) Token: 0x0600042D RID: 1069 RVA: 0x0000D343 File Offset: 0x0000B543
        public int ForcedClassID { get; set; }

        // Token: 0x170001EE RID: 494
        // (get) Token: 0x0600042E RID: 1070 RVA: 0x0000D34C File Offset: 0x0000B54C
        // (set) Token: 0x0600042F RID: 1071 RVA: 0x0000D363 File Offset: 0x0000B563
        public IEffect[] Effects { get; set; }

        // Token: 0x170001EF RID: 495
        // (get) Token: 0x06000430 RID: 1072 RVA: 0x0000D36C File Offset: 0x0000B56C
        // (set) Token: 0x06000431 RID: 1073 RVA: 0x0000D383 File Offset: 0x0000B583
        public Enums.eBuffMode BuffMode { get; set; }

        // Token: 0x170001F0 RID: 496
        // (get) Token: 0x06000432 RID: 1074 RVA: 0x0000D38C File Offset: 0x0000B58C
        // (set) Token: 0x06000433 RID: 1075 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
        public bool HasGrantPowerEffect { get; set; }

        // Token: 0x170001F1 RID: 497
        // (get) Token: 0x06000434 RID: 1076 RVA: 0x0000D3AC File Offset: 0x0000B5AC
        // (set) Token: 0x06000435 RID: 1077 RVA: 0x0000D3C3 File Offset: 0x0000B5C3
        public bool HasPowerOverrideEffect { get; set; }

        // Token: 0x170001F2 RID: 498
        // (get) Token: 0x06000436 RID: 1078 RVA: 0x0000D3CC File Offset: 0x0000B5CC
        // (set) Token: 0x06000437 RID: 1079 RVA: 0x0000D3E3 File Offset: 0x0000B5E3
        public bool BoostBoostable { get; set; }

        // Token: 0x170001F3 RID: 499
        // (get) Token: 0x06000438 RID: 1080 RVA: 0x0000D3EC File Offset: 0x0000B5EC
        // (set) Token: 0x06000439 RID: 1081 RVA: 0x0000D403 File Offset: 0x0000B603
        public bool BoostUsePlayerLevel { get; set; }

        // Token: 0x0600043A RID: 1082 RVA: 0x0000D40C File Offset: 0x0000B60C
        public bool HasMutexID(int index)
        {
            for (int index2 = 0; index2 <= this.NGroupMembership.Length - 1; index2++)
            {
                if (this.NGroupMembership[index2] == index)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600043B RID: 1083 RVA: 0x0000D458 File Offset: 0x0000B658
        public Power()
        {
            this.DescLong = string.Empty;
            this.DescShort = string.Empty;
            this.Enhancements = new int[0];
            this.MaxBoosts = string.Empty;
            this.DisplayName = string.Empty;
            this.FullName = string.Empty;
            this.BoostsAllowed = new string[0];
            this.BuffMode = Enums.eBuffMode.Normal;
            this.Effects = new IEffect[0];
            this.ForcedClass = string.Empty;
            this.MutexAuto = true;
            this.TargetLoS = true;
            this.GroupMembership = new string[0];
            this.PowerName = string.Empty;
            this.SetName = string.Empty;
            this.GroupName = string.Empty;
            this.NGroupMembership = new int[0];
            this.PowerSetIndex = -1;
            this.PowerSetID = -1;
            this.PowerIndex = -1;
            this.SetTypes = new Enums.eSetType[0];
            this.VariableName = string.Empty;
            this.UIDSubPower = new string[0];
            this.NIDSubPower = new int[0];
            this.Ignore_Buff = new Enums.eEnhance[0];
            this.IgnoreEnh = new Enums.eEnhance[0];
            this.SubIsAltColour = false;
            this.BoostsAllowed = new string[0];
            this.Requires = new Requirement();
            int num = -2;
            for (int index = 0; index <= DatabaseAPI.Database.Power.Length - 1; index++)
            {
                if (DatabaseAPI.Database.Power[index] != null && DatabaseAPI.Database.Power[index].StaticIndex > -1 && DatabaseAPI.Database.Power[index].StaticIndex > num)
                {
                    num = DatabaseAPI.Database.Power[index].StaticIndex;
                }
            }
            this.StaticIndex = num + 1;
        }

        // Token: 0x0600043C RID: 1084 RVA: 0x0000D640 File Offset: 0x0000B840
        public Power(IPower template)
        {
            this.DescLong = string.Empty;
            this.DescShort = string.Empty;
            this.Enhancements = new int[0];
            this.MaxBoosts = string.Empty;
            this.DisplayName = string.Empty;
            this.FullName = string.Empty;
            this.BoostsAllowed = new string[0];
            this.BuffMode = Enums.eBuffMode.Normal;
            this.Effects = new IEffect[0];
            this.ForcedClass = string.Empty;
            this.MutexAuto = true;
            this.TargetLoS = true;
            this.GroupMembership = new string[0];
            this.Requires = new Requirement();
            this.PowerName = string.Empty;
            this.SetName = string.Empty;
            this.GroupName = string.Empty;
            this.NGroupMembership = new int[0];
            this.StaticIndex = -1;
            this.PowerSetIndex = -1;
            this.PowerSetID = -1;
            this.PowerIndex = -1;
            this.SetTypes = new Enums.eSetType[0];
            this.VariableName = string.Empty;
            this.UIDSubPower = new string[0];
            this.NIDSubPower = new int[0];
            this.Ignore_Buff = new Enums.eEnhance[0];
            this.IgnoreEnh = new Enums.eEnhance[0];
            this.SubIsAltColour = false;
            if (template != null)
            {
                this.IsModified = template.IsModified;
                this.IsNew = template.IsNew;
                this.PowerIndex = template.PowerIndex;
                this.PowerSetID = template.PowerSetID;
                this.PowerSetIndex = template.PowerSetIndex;
                this.BuffMode = template.BuffMode;
                this.HasGrantPowerEffect = template.HasGrantPowerEffect;
                this.HasPowerOverrideEffect = template.HasPowerOverrideEffect;
                this.NGroupMembership = new int[template.NGroupMembership.Length];
                Array.Copy(template.NGroupMembership, this.NGroupMembership, this.NGroupMembership.Length);
                this.StaticIndex = template.StaticIndex;
                this.FullName = template.FullName;
                this.GroupName = template.GroupName;
                this.SetName = template.SetName;
                this.PowerName = template.PowerName;
                this.DisplayName = template.DisplayName;
                this.Available = template.Available;
                this.Requires = new Requirement(template.Requires);
                this.ModesRequired = template.ModesRequired;
                this.ModesDisallowed = template.ModesDisallowed;
                this.PowerType = template.PowerType;
                this.Accuracy = template.Accuracy;
                this.AccuracyMult = template.AccuracyMult;
                this.AttackTypes = template.AttackTypes;
                this.GroupMembership = new string[template.GroupMembership.Length];
                Array.Copy(template.GroupMembership, this.GroupMembership, this.GroupMembership.Length);
                this.EntitiesAffected = template.EntitiesAffected;
                this.EntitiesAutoHit = template.EntitiesAutoHit;
                this.Target = template.Target;
                this.TargetLoS = template.TargetLoS;
                this.Range = template.Range;
                this.TargetSecondary = template.TargetSecondary;
                this.RangeSecondary = template.RangeSecondary;
                this.EndCost = template.EndCost;
                this.InterruptTime = template.InterruptTime;
                this.CastTime = template.CastTimeReal;
                this.RechargeTime = template.RechargeTime;
                this.ActivatePeriod = template.ActivatePeriod;
                this.EffectArea = template.EffectArea;
                this.Radius = template.Radius;
                this.Arc = template.Arc;
                this.MaxTargets = template.MaxTargets;
                this.MaxBoosts = template.MaxBoosts;
                this.CastFlags = template.CastFlags;
                this.AIReport = template.AIReport;
                this.NumCharges = template.NumCharges;
                this.UsageTime = template.UsageTime;
                this.LifeTime = template.LifeTime;
                this.LifeTimeInGame = template.LifeTimeInGame;
                this.NumAllowed = template.NumAllowed;
                this.DoNotSave = template.DoNotSave;
                this.BoostsAllowed = new string[template.BoostsAllowed.Length];
                Array.Copy(template.BoostsAllowed, this.BoostsAllowed, this.BoostsAllowed.Length);
                this.Enhancements = new int[template.Enhancements.Length];
                Array.Copy(template.Enhancements, this.Enhancements, this.Enhancements.Length);
                this.CastThroughHold = template.CastThroughHold;
                this.IgnoreStrength = template.IgnoreStrength;
                this.DescShort = template.DescShort;
                this.DescLong = template.DescLong;
                this.SetTypes = new Enums.eSetType[template.SetTypes.Length];
                Array.Copy(template.SetTypes, this.SetTypes, this.SetTypes.Length);
                this.Effects = new IEffect[template.Effects.Length];
                for (int index = 0; index <= this.Effects.Length - 1; index++)
                {
                    this.Effects[index] = (IEffect)template.Effects[index].Clone();
                    this.Effects[index].Power = this;
                }
                this.ClickBuff = template.ClickBuff;
                this.AlwaysToggle = template.AlwaysToggle;
                this.Level = template.Level;
                this.AllowFrontLoading = template.AllowFrontLoading;
                this.VariableEnabled = template.VariableEnabled;
                this.VariableName = template.VariableName;
                this.VariableMin = template.VariableMin;
                this.VariableMax = template.VariableMax;
                this.NIDSubPower = new int[template.NIDSubPower.Length];
                Array.Copy(template.NIDSubPower, this.NIDSubPower, this.NIDSubPower.Length);
                this.UIDSubPower = new string[template.UIDSubPower.Length];
                Array.Copy(template.UIDSubPower, this.UIDSubPower, this.UIDSubPower.Length);
                this.SubIsAltColour = template.SubIsAltColour;
                this.IgnoreEnh = new Enums.eEnhance[template.IgnoreEnh.Length];
                Array.Copy(template.IgnoreEnh, this.IgnoreEnh, this.IgnoreEnh.Length);
                this.Ignore_Buff = new Enums.eEnhance[template.Ignore_Buff.Length];
                Array.Copy(template.Ignore_Buff, this.Ignore_Buff, this.Ignore_Buff.Length);
                this.SkipMax = template.SkipMax;
                this.LocationIndex = template.DisplayLocation;
                this.MutexAuto = template.MutexAuto;
                this.MutexIgnore = template.MutexIgnore;
                this.AbsorbSummonEffects = template.AbsorbSummonEffects;
                this.AbsorbSummonAttributes = template.AbsorbSummonAttributes;
                this.ShowSummonAnyway = template.ShowSummonAnyway;
                this.NeverAutoUpdate = template.NeverAutoUpdate;
                this.NeverAutoUpdateRequirements = template.NeverAutoUpdateRequirements;
                this.IncludeFlag = template.IncludeFlag;
                this.ForcedClass = template.ForcedClass;
                this.ForcedClassID = template.ForcedClassID;
                this.SortOverride = template.SortOverride;
                this.BoostUsePlayerLevel = template.BoostUsePlayerLevel;
                this.BoostBoostable = template.BoostBoostable;
                this.HasAbsorbedEffects = template.HasAbsorbedEffects;
                this.HiddenPower = template.HiddenPower;
            }
        }

        // Token: 0x0600043D RID: 1085 RVA: 0x0000DD90 File Offset: 0x0000BF90
        public Power(BinaryReader reader)
        {
            this.Enhancements = new int[0];
            this.BuffMode = Enums.eBuffMode.Normal;
            this.Effects = new IEffect[0];
            this.ForcedClass = string.Empty;
            this.MutexAuto = true;
            this.TargetLoS = true;
            this.GroupMembership = new string[0];
            this.Requires = new Requirement();
            this.NGroupMembership = new int[0];
            this.StaticIndex = -1;
            this.PowerSetIndex = -1;
            this.PowerSetID = -1;
            this.PowerIndex = -1;
            this.SetTypes = new Enums.eSetType[0];
            this.VariableName = string.Empty;
            this.UIDSubPower = new string[0];
            this.NIDSubPower = new int[0];
            this.Ignore_Buff = new Enums.eEnhance[0];
            this.IgnoreEnh = new Enums.eEnhance[0];
            this.SubIsAltColour = false;
            this.BoostsAllowed = new string[0];
            this.StaticIndex = reader.ReadInt32();
            this.FullName = reader.ReadString();
            this.GroupName = reader.ReadString();
            this.SetName = reader.ReadString();
            this.PowerName = reader.ReadString();
            this.DisplayName = reader.ReadString();
            this.Available = reader.ReadInt32();
            this.Requires = new Requirement(reader);
            this.ModesRequired = (Enums.eModeFlags)reader.ReadInt32();
            this.ModesDisallowed = (Enums.eModeFlags)reader.ReadInt32();
            this.PowerType = (Enums.ePowerType)reader.ReadInt32();
            this.Accuracy = reader.ReadSingle();
            this.AccuracyMult = this.Accuracy;
            this.AttackTypes = (Enums.eVector)reader.ReadInt32();
            this.GroupMembership = new string[reader.ReadInt32() + 1];
            for (int index = 0; index < this.GroupMembership.Length; index++)
            {
                this.GroupMembership[index] = reader.ReadString();
            }
            this.EntitiesAffected = (Enums.eEntity)reader.ReadInt32();
            this.EntitiesAutoHit = (Enums.eEntity)reader.ReadInt32();
            this.Target = (Enums.eEntity)reader.ReadInt32();
            this.TargetLoS = reader.ReadBoolean();
            this.Range = reader.ReadSingle();
            this.TargetSecondary = (Enums.eEntity)reader.ReadInt32();
            this.RangeSecondary = reader.ReadSingle();
            this.EndCost = reader.ReadSingle();
            this.InterruptTime = reader.ReadSingle();
            this.CastTime = reader.ReadSingle();
            this.RechargeTime = reader.ReadSingle();
            this.ActivatePeriod = reader.ReadSingle();
            this.EffectArea = (Enums.eEffectArea)reader.ReadInt32();
            this.Radius = reader.ReadSingle();
            this.Arc = reader.ReadInt32();
            this.MaxTargets = reader.ReadInt32();
            this.MaxBoosts = reader.ReadString();
            this.CastFlags = (Enums.eCastFlags)reader.ReadInt32();
            this.AIReport = (Enums.eNotify)reader.ReadInt32();
            this.NumCharges = reader.ReadInt32();
            this.UsageTime = reader.ReadInt32();
            this.LifeTime = reader.ReadInt32();
            this.LifeTimeInGame = reader.ReadInt32();
            this.NumAllowed = reader.ReadInt32();
            this.DoNotSave = reader.ReadBoolean();
            this.BoostsAllowed = new string[reader.ReadInt32() + 1];
            for (int index2 = 0; index2 <= this.BoostsAllowed.Length - 1; index2++)
            {
                this.BoostsAllowed[index2] = reader.ReadString();
            }
            this.CastThroughHold = reader.ReadBoolean();
            this.IgnoreStrength = reader.ReadBoolean();
            this.DescShort = reader.ReadString();
            this.DescLong = reader.ReadString();
            this.SetTypes = new Enums.eSetType[reader.ReadInt32() + 1];
            for (int index3 = 0; index3 <= this.SetTypes.Length - 1; index3++)
            {
                this.SetTypes[index3] = (Enums.eSetType)reader.ReadInt32();
            }
            this.ClickBuff = reader.ReadBoolean();
            this.AlwaysToggle = reader.ReadBoolean();
            this.Level = reader.ReadInt32();
            this.AllowFrontLoading = reader.ReadBoolean();
            this.VariableEnabled = reader.ReadBoolean();
            this.VariableName = reader.ReadString();
            this.VariableMin = reader.ReadInt32();
            this.VariableMax = reader.ReadInt32();
            this.UIDSubPower = new string[reader.ReadInt32() + 1];
            for (int index4 = 0; index4 <= this.UIDSubPower.Length - 1; index4++)
            {
                this.UIDSubPower[index4] = reader.ReadString();
            }
            this.IgnoreEnh = new Enums.eEnhance[reader.ReadInt32() + 1];
            for (int index5 = 0; index5 <= this.IgnoreEnh.Length - 1; index5++)
            {
                this.IgnoreEnh[index5] = (Enums.eEnhance)reader.ReadInt32();
            }
            this.Ignore_Buff = new Enums.eEnhance[reader.ReadInt32() + 1];
            for (int index6 = 0; index6 <= this.Ignore_Buff.Length - 1; index6++)
            {
                this.Ignore_Buff[index6] = (Enums.eEnhance)reader.ReadInt32();
            }
            this.SkipMax = reader.ReadBoolean();
            this.DisplayLocation = reader.ReadInt32();
            this.MutexAuto = reader.ReadBoolean();
            this.MutexIgnore = reader.ReadBoolean();
            this.AbsorbSummonEffects = reader.ReadBoolean();
            this.AbsorbSummonAttributes = reader.ReadBoolean();
            this.ShowSummonAnyway = reader.ReadBoolean();
            this.NeverAutoUpdate = reader.ReadBoolean();
            this.NeverAutoUpdateRequirements = reader.ReadBoolean();
            this.IncludeFlag = reader.ReadBoolean();
            this.ForcedClass = reader.ReadString();
            this.SortOverride = reader.ReadBoolean();
            this.BoostBoostable = reader.ReadBoolean();
            this.BoostUsePlayerLevel = reader.ReadBoolean();
            this.Effects = new IEffect[reader.ReadInt32() + 1];
            for (int index7 = 0; index7 <= this.Effects.Length - 1; index7++)
            {
                this.Effects[index7] = new Effect(reader)
                {
                    Power = this,
                    nID = index7
                };
            }
            this.HiddenPower = reader.ReadBoolean();
        }

        // Token: 0x0600043E RID: 1086 RVA: 0x0000E3D8 File Offset: 0x0000C5D8
        public void StoreTo(ref BinaryWriter writer)
        {
            writer.Write(this.StaticIndex);
            writer.Write(this.FullName);
            writer.Write(this.GroupName);
            writer.Write(this.SetName);
            writer.Write(this.PowerName);
            writer.Write(this.DisplayName);
            writer.Write(this.Available);
            this.Requires.StoreTo(writer);
            writer.Write((int)this.ModesRequired);
            writer.Write((int)this.ModesDisallowed);
            writer.Write((int)this.PowerType);
            writer.Write(this.Accuracy);
            writer.Write((int)this.AttackTypes);
            writer.Write(this.GroupMembership.Length - 1);
            for (int index = 0; index <= this.GroupMembership.Length - 1; index++)
            {
                writer.Write(this.GroupMembership[index]);
            }
            writer.Write((int)this.EntitiesAffected);
            writer.Write((int)this.EntitiesAutoHit);
            writer.Write((int)this.Target);
            writer.Write(this.TargetLoS);
            writer.Write(this.Range);
            writer.Write((int)this.TargetSecondary);
            writer.Write(this.RangeSecondary);
            writer.Write(this.EndCost);
            writer.Write(this.InterruptTime);
            writer.Write(this.CastTimeReal);
            writer.Write(this.RechargeTime);
            writer.Write(this.ActivatePeriod);
            writer.Write((int)this.EffectArea);
            writer.Write(this.Radius);
            writer.Write(this.Arc);
            writer.Write(this.MaxTargets);
            writer.Write(this.MaxBoosts);
            writer.Write((int)this.CastFlags);
            writer.Write((int)this.AIReport);
            writer.Write(this.NumCharges);
            writer.Write(this.UsageTime);
            writer.Write(this.LifeTime);
            writer.Write(this.LifeTimeInGame);
            writer.Write(this.NumAllowed);
            writer.Write(this.DoNotSave);
            writer.Write(this.BoostsAllowed.Length - 1);
            for (int index2 = 0; index2 <= this.BoostsAllowed.Length - 1; index2++)
            {
                writer.Write(this.BoostsAllowed[index2]);
            }
            writer.Write(this.CastThroughHold);
            writer.Write(this.IgnoreStrength);
            writer.Write(this.DescShort);
            writer.Write(this.DescLong);
            writer.Write(this.SetTypes.Length - 1);
            for (int index3 = 0; index3 <= this.SetTypes.Length - 1; index3++)
            {
                writer.Write((int)this.SetTypes[index3]);
            }
            writer.Write(this.ClickBuff);
            writer.Write(this.AlwaysToggle);
            writer.Write(this.Level);
            writer.Write(this.AllowFrontLoading);
            writer.Write(this.VariableEnabled);
            writer.Write(this.VariableName);
            writer.Write(this.VariableMin);
            writer.Write(this.VariableMax);
            writer.Write(this.UIDSubPower.Length - 1);
            for (int index4 = 0; index4 <= this.UIDSubPower.Length - 1; index4++)
            {
                writer.Write(this.UIDSubPower[index4]);
            }
            writer.Write(this.IgnoreEnh.Length - 1);
            for (int index5 = 0; index5 <= this.IgnoreEnh.Length - 1; index5++)
            {
                writer.Write((int)this.IgnoreEnh[index5]);
            }
            writer.Write(this.Ignore_Buff.Length - 1);
            for (int index6 = 0; index6 <= this.Ignore_Buff.Length - 1; index6++)
            {
                writer.Write((int)this.Ignore_Buff[index6]);
            }
            writer.Write(this.SkipMax);
            writer.Write(this.LocationIndex);
            writer.Write(this.MutexAuto);
            writer.Write(this.MutexIgnore);
            writer.Write(this.AbsorbSummonEffects);
            writer.Write(this.AbsorbSummonAttributes);
            writer.Write(this.ShowSummonAnyway);
            writer.Write(this.NeverAutoUpdate);
            writer.Write(this.NeverAutoUpdateRequirements);
            writer.Write(this.IncludeFlag);
            writer.Write(this.ForcedClass);
            writer.Write(this.SortOverride);
            writer.Write(this.BoostBoostable);
            writer.Write(this.BoostUsePlayerLevel);
            writer.Write(this.Effects.Length - 1);
            for (int index7 = 0; index7 <= this.Effects.Length - 1; index7++)
            {
                this.Effects[index7].StoreTo(ref writer);
            }
            writer.Write(this.HiddenPower);
        }

        // Token: 0x0600043F RID: 1087 RVA: 0x0000E950 File Offset: 0x0000CB50
        public float FXGetDamageValue()
        {
            float num = 0f;
            foreach (IEffect effect in this.Effects)
            {
                if (effect.EffectType == Enums.eEffectType.Damage && (MidsContext.Config.DamageMath.Calculate != ConfigData.EDamageMath.Minimum || Math.Abs(effect.Probability) > 0.999f) && effect.EffectClass != Enums.eEffectClass.Ignored && (effect.DamageType != Enums.eDamage.Special || effect.ToWho != Enums.eToWho.Self) && effect.Probability > 0f && effect.CanInclude() && effect.PvXInclude())
                {
                    float num2 = effect.Mag;
                    if (MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average)
                    {
                        num2 *= effect.Probability;
                    }
                    if (this.PowerType == Enums.ePowerType.Toggle && effect.isEnahncementEffect)
                    {
                        num2 = num2 * this.ActivatePeriod / 10f;
                    }
                    if (effect.Ticks > 1)
                    {
                        if (effect.CancelOnMiss && MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average && effect.Probability < 1f)
                        {
                            num2 *= (1f - (float)Math.Pow((double)effect.Probability, (double)effect.Ticks)) / (1f - effect.Probability);
                        }
                        else
                        {
                            num2 *= (float)effect.Ticks;
                        }
                    }
                    num += num2;
                }
            }
            switch (MidsContext.Config.DamageMath.ReturnValue)
            {
                case ConfigData.EDamageReturn.DPS:
                    if (this.PowerType == Enums.ePowerType.Toggle && this.ActivatePeriod > 0f)
                    {
                        num /= this.ActivatePeriod;
                    }
                    else if (this.RechargeTime + this.CastTime + this.InterruptTime > 0f)
                    {
                        num /= this.RechargeTime + this.CastTime + this.InterruptTime;
                    }
                    break;
                case ConfigData.EDamageReturn.DPA:
                    if (this.PowerType == Enums.ePowerType.Toggle && this.ActivatePeriod > 0f)
                    {
                        num /= this.ActivatePeriod;
                    }
                    else if (this.CastTime > 0f)
                    {
                        num /= this.CastTime;
                    }
                    break;
            }
            return num;
        }

        // Token: 0x06000440 RID: 1088 RVA: 0x0000EBDC File Offset: 0x0000CDDC
        public string FXGetDamageString()
        {
            string[] names = Enum.GetNames(Enums.eDamage.None.GetType());
            float[] numArray = new float[names.Length];
            float[,] numArray2 = new float[names.Length, 2];
            float[,] numArray3 = new float[names.Length, 2];
            string str = string.Empty;
            float iNum = 0f;
            foreach (IEffect effect in this.Effects)
            {
                if (effect.EffectType == Enums.eEffectType.Damage && (MidsContext.Config.DamageMath.Calculate != ConfigData.EDamageMath.Minimum || Math.Abs(effect.Probability) > 0.999f) && effect.EffectClass != Enums.eEffectClass.Ignored && (effect.DamageType != Enums.eDamage.Special || effect.ToWho != Enums.eToWho.Self) && effect.Probability > 0f && effect.CanInclude() && effect.PvXInclude())
                {
                    float num = effect.Mag;
                    if (MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average)
                    {
                        num *= effect.Probability;
                    }
                    if (this.PowerType == Enums.ePowerType.Toggle && effect.isEnahncementEffect)
                    {
                        num = num * this.ActivatePeriod / 10f;
                    }
                    switch (MidsContext.Config.DamageMath.ReturnValue)
                    {
                        case ConfigData.EDamageReturn.DPS:
                            if (this.PowerType == Enums.ePowerType.Toggle && this.ActivatePeriod > 0f)
                            {
                                num /= this.ActivatePeriod;
                            }
                            else if (this.RechargeTime + this.CastTime > 0f)
                            {
                                num /= this.RechargeTime + this.CastTime;
                            }
                            break;
                        case ConfigData.EDamageReturn.DPA:
                            if (this.PowerType == Enums.ePowerType.Toggle && this.ActivatePeriod > 0f)
                            {
                                num /= this.ActivatePeriod;
                            }
                            else if (this.CastTime > 0f)
                            {
                                num /= this.CastTime;
                            }
                            break;
                    }
                    if (effect.Ticks != 0)
                    {
                        float num2 = (effect.CancelOnMiss && MidsContext.Config.DamageMath.Calculate == ConfigData.EDamageMath.Average && effect.Probability < 1f) ? ((1f - (float)Math.Pow((double)effect.Probability, (double)effect.Ticks)) / (1f - effect.Probability)) : ((float)effect.Ticks);
                        int index = 0;
                        if ((double)Math.Abs(numArray2[(int)effect.DamageType, 0] - 0f) > 0.01)
                        {
                            index = 1;
                        }
                        numArray2[(int)effect.DamageType, index] = num;
                        numArray3[(int)effect.DamageType, index] = num2;
                        iNum += num * num2;
                    }
                    else
                    {
                        iNum += num;
                        numArray[(int)effect.DamageType] += num;
                    }
                }
            }
            if (iNum > 0f)
            {
                for (int index2 = 0; index2 <= numArray.Length - 1; index2++)
                {
                    if (numArray[index2] > 0f | numArray2[index2, 0] > 0f)
                    {
                        if (!string.IsNullOrEmpty(str))
                        {
                            str += ", ";
                        }
                        str = str + Enums.GetDamageName((Enums.eDamage)index2) + "(";
                        if (numArray[index2] > 0f)
                        {
                            str += Utilities.FixDP(numArray[index2]);
                        }
                        if ((double)Math.Abs(numArray2[index2, 0] - 0f) > 0.01)
                        {
                            if (numArray[index2] > 0f)
                            {
                                str += "+";
                            }
                            str = str + Utilities.FixDP(numArray2[index2, 0]) + "x" + Utilities.FixDP(numArray3[index2, 0]);
                            if ((double)Math.Abs(numArray2[index2, 1] - 0f) > 0.01)
                            {
                                string text = str;
                                str = string.Concat(new string[]
                                {
                                    text,
                                    "+",
                                    Utilities.FixDP(numArray2[index2, 1]),
                                    "x",
                                    Utilities.FixDP(numArray3[index2, 1])
                                });
                            }
                        }
                        str += ")";
                    }
                }
                str = str + " = " + Utilities.FixDP(iNum);
            }
            return str;
        }

        // Token: 0x06000441 RID: 1089 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
        public int[] GetRankedEffects()
        {
            int[] numArray = new int[this.Effects.Length];
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if ((MidsContext.Config.Suppression & this.Effects[index].Suppression) == Enums.eSuppress.None & ((MidsContext.Config.Inc.PvE & this.Effects[index].PvMode != Enums.ePvX.PvP) | (!MidsContext.Config.Inc.PvE & this.Effects[index].PvMode != Enums.ePvX.PvE)))
                {
                    numArray[index] = (int)(this.Effects[index].EffectClass + 1);
                    if ((double)Math.Abs(this.Effects[index].Probability - 1f) < 0.01)
                    {
                        numArray[index] += 10;
                    }
                    if (this.HasAbsorbedEffects & this.Effects[index].EffectType != Enums.eEffectType.EntCreate)
                    {
                        numArray[index] += 50;
                    }
                    if (this.Effects[index].DelayedTime > 1f)
                    {
                        numArray[index] += -100;
                    }
                    if (this.Effects[index].DelayedTime > 0f & this.Effects[index].DelayedTime <= 1f)
                    {
                        numArray[index] += -25;
                    }
                    if (this.Effects[index].InherentSpecial)
                    {
                        numArray[index] += -100;
                    }
                    if (this.Effects[index].ToWho == Enums.eToWho.Self & (this.Effects[index].Mag > 0f | this.Effects[index].EffectType == Enums.eEffectType.Mez))
                    {
                        numArray[index] += 10;
                    }
                    if (this.Effects[index].ToWho == Enums.eToWho.Target & this.Effects[index].Mag < 0f)
                    {
                        numArray[index] += 10;
                    }
                    if (this.Effects[index].ToWho == Enums.eToWho.Target & this.Effects[index].Mag > 0f & this.Effects[index].Absorbed_Effect)
                    {
                        numArray[index] += 10;
                    }
                    if (this.Effects[index].isEnahncementEffect)
                    {
                        numArray[index] += -30;
                    }
                    if (this.Effects[index].VariableModified)
                    {
                        numArray[index] += 30;
                    }
                    Enums.eEffectType effectType = this.Effects[index].EffectType;
                    switch (effectType)
                    {
                        case Enums.eEffectType.None:
                            numArray[index] += -1000;
                            goto IL_8EA;
                        case Enums.eEffectType.Accuracy:
                        case Enums.eEffectType.ViewAttrib:
                        case Enums.eEffectType.DropToggles:
                        case Enums.eEffectType.EnduranceDiscount:
                        case Enums.eEffectType.InterruptTime:
                        case Enums.eEffectType.Meter:
                        case Enums.eEffectType.PerceptionRadius:
                        case Enums.eEffectType.Range:
                        case Enums.eEffectType.RechargeTime:
                        case Enums.eEffectType.ResEffect:
                        case Enums.eEffectType.Reward:
                        case Enums.eEffectType.SetCostume:
                        case Enums.eEffectType.Slow:
                        case Enums.eEffectType.ThreatLevel:
                        case Enums.eEffectType.XPDebtProtection:
                        case Enums.eEffectType.SilentKill:
                        case Enums.eEffectType.Elusivity:
                        case Enums.eEffectType.CombatModShift:
                        case Enums.eEffectType.UnsetMode:
                        case Enums.eEffectType.Rage:
                        case Enums.eEffectType.MaxRunSpeed:
                        case Enums.eEffectType.MaxJumpSpeed:
                        case Enums.eEffectType.MaxFlySpeed:
                            goto IL_8C8;
                        case Enums.eEffectType.Damage:
                            numArray[index] += -500;
                            goto IL_8EA;
                        case Enums.eEffectType.DamageBuff:
                            numArray[index] += 10;
                            goto IL_8EA;
                        case Enums.eEffectType.Defense:
                            numArray[index] += 25;
                            goto IL_8EA;
                        case Enums.eEffectType.Endurance:
                            numArray[index] += 15;
                            goto IL_8EA;
                        case Enums.eEffectType.Enhancement:
                            {
                                Enums.eEffectType etmodifies = this.Effects[index].ETModifies;
                                if (etmodifies == Enums.eEffectType.SpeedFlying)
                                {
                                    numArray[index] += 5;
                                    goto IL_8EA;
                                }
                                switch (etmodifies)
                                {
                                    case Enums.eEffectType.JumpHeight:
                                        numArray[index] -= 5;
                                        goto IL_8EA;
                                    case Enums.eEffectType.SpeedJumping:
                                        numArray[index] += 5;
                                        goto IL_8EA;
                                    default:
                                        if (etmodifies != Enums.eEffectType.SpeedRunning)
                                        {
                                            numArray[index] += 9;
                                            goto IL_8EA;
                                        }
                                        numArray[index] += 5;
                                        goto IL_8EA;
                                }
                                break;
                            }
                        case Enums.eEffectType.Fly:
                            numArray[index] += 3;
                            goto IL_8EA;
                        case Enums.eEffectType.SpeedFlying:
                            numArray[index] += 5;
                            goto IL_8EA;
                        case Enums.eEffectType.GrantPower:
                            numArray[index] += -20;
                            goto IL_8EA;
                        case Enums.eEffectType.Heal:
                            numArray[index] += 15;
                            goto IL_8EA;
                        case Enums.eEffectType.HitPoints:
                            numArray[index] += 10;
                            goto IL_8EA;
                        case Enums.eEffectType.JumpHeight:
                            numArray[index] += 5;
                            goto IL_8EA;
                        case Enums.eEffectType.SpeedJumping:
                            numArray[index] += 5;
                            goto IL_8EA;
                        case Enums.eEffectType.Mez:
                            if (!this.Effects[index].Buffable)
                            {
                                numArray[index] += -1;
                            }
                            if (this.Effects[index].MezType == Enums.eMez.OnlyAffectsSelf | this.Effects[index].MezType == Enums.eMez.Untouchable)
                            {
                                numArray[index] -= 9;
                                goto IL_8EA;
                            }
                            if (this.Effects[index].MezType == Enums.eMez.Knockback | this.Effects[index].MezType == Enums.eMez.Knockup)
                            {
                                numArray[index] += Convert.ToInt32(8f * this.Effects[index].Probability);
                                goto IL_8EA;
                            }
                            numArray[index] += Convert.ToInt32(9f * this.Effects[index].Probability);
                            goto IL_8EA;
                        case Enums.eEffectType.MezResist:
                            numArray[index] += 5;
                            goto IL_8EA;
                        case Enums.eEffectType.MovementControl:
                            numArray[index] += 3;
                            goto IL_8EA;
                        case Enums.eEffectType.MovementFriction:
                            numArray[index] += 3;
                            goto IL_8EA;
                        case Enums.eEffectType.Recovery:
                            numArray[index] += 10;
                            goto IL_8EA;
                        case Enums.eEffectType.Regeneration:
                            numArray[index] += 10;
                            goto IL_8EA;
                        case Enums.eEffectType.Resistance:
                            numArray[index] += 20;
                            goto IL_8EA;
                        case Enums.eEffectType.RevokePower:
                            numArray[index] += -20;
                            goto IL_8EA;
                        case Enums.eEffectType.SpeedRunning:
                            numArray[index] += 5;
                            goto IL_8EA;
                        case Enums.eEffectType.SetMode:
                            numArray[index] = -500;
                            goto IL_8EA;
                        case Enums.eEffectType.StealthRadius:
                            numArray[index] += 7;
                            goto IL_8EA;
                        case Enums.eEffectType.StealthRadiusPlayer:
                            numArray[index] += 6;
                            goto IL_8EA;
                        case Enums.eEffectType.EntCreate:
                            {
                                if (this.HasAbsorbedEffects)
                                {
                                    numArray[index] += -500;
                                    goto IL_8EA;
                                }
                                int[] numArray2 = numArray;
                                int index2 = index;
                                numArray2[index2] = numArray2[index2];
                                goto IL_8EA;
                            }
                        case Enums.eEffectType.ToHit:
                            numArray[index] += 10;
                            goto IL_8EA;
                        case Enums.eEffectType.Translucency:
                            numArray[index] += -20;
                            goto IL_8EA;
                        case Enums.eEffectType.GlobalChanceMod:
                            numArray[index]++;
                            goto IL_8EA;
                        case Enums.eEffectType.DesignerStatus:
                            break;
                        default:
                            switch (effectType)
                            {
                                case Enums.eEffectType.Null:
                                case Enums.eEffectType.NullBool:
                                    break;
                                default:
                                    goto IL_8C8;
                            }
                            break;
                    }
                    numArray[index] += int.MinValue;
                    goto IL_8EA;
                IL_8C8:
                    numArray[index] += 9;
                }
                else
                {
                    numArray[index] = int.MinValue;
                }
            IL_8EA:;
            }
            int iID = -1;
            int num = -1;
            int num2 = 0;
            int num3 = 0;
            for (int iID2 = 0; iID2 <= numArray.Length - 1; iID2++)
            {
                if (numArray[iID2] > num2)
                {
                    num = iID;
                    num3 = num2;
                    iID = iID2;
                    num2 = numArray[iID2];
                }
                else if (numArray[iID2] > num3 & this.GreOverride(iID, iID2))
                {
                    num = iID2;
                    num3 = numArray[iID2];
                }
            }
            return new int[]
            {
                iID,
                num
            };
        }

        // Token: 0x06000442 RID: 1090 RVA: 0x0000FAA4 File Offset: 0x0000DCA4
        private bool GreOverride(int iID1, int iID2)
        {
            return (iID1 < 0 & iID2 > -1) || (iID2 >= 0 && (!(this.Effects[iID1].EffectType == this.Effects[iID2].EffectType & this.Effects[iID1].ETModifies == this.Effects[iID2].ETModifies & this.Effects[iID1].MezType == this.Effects[iID2].MezType) || ((double)Math.Abs(this.Effects[iID1].Mag - this.Effects[iID2].Mag) >= 0.01 && this.Effects[iID1].ToWho != this.Effects[iID2].ToWho)));
        }

        // Token: 0x06000443 RID: 1091 RVA: 0x0000FB80 File Offset: 0x0000DD80
        public int GetDurationEffectID()
        {
            int num = -1;
            Enums.eEffectClass eEffectClass = Enums.eEffectClass.Ignored;
            float num2 = 0f;
            float num3 = 0f;
            bool flag = false;
            Enums.eEffectType eEffectType = Enums.eEffectType.None;
            float num4 = 0f;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            int num5 = int.MaxValue;
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                bool flag5 = false;
                if (((MidsContext.Config.Inc.PvE & this.Effects[index].PvMode != Enums.ePvX.PvP) | (!MidsContext.Config.Inc.PvE & this.Effects[index].PvMode != Enums.ePvX.PvE)) && ((this.Effects[index].Duration > 0f | this.Effects[index].EffectType == Enums.eEffectType.EntCreate) & this.Effects[index].EffectClass != Enums.eEffectClass.Ignored))
                {
                    if (this.Effects[index].EffectClass < eEffectClass)
                    {
                        flag5 = true;
                    }
                    if (this.Effects[index].Probability > num2 & this.Effects[index].SpecialCase != Enums.eSpecialCase.Defiance)
                    {
                        flag5 = true;
                    }
                    if (this.Effects[index].Buffable & !flag2)
                    {
                        flag5 = true;
                    }
                    if (this.Effects[index].SpecialCase != Enums.eSpecialCase.Defiance && flag3)
                    {
                        flag5 = true;
                    }
                    if (((double)Math.Abs(this.Effects[index].Probability - num2) < 0.01 & this.Effects[index].Duration > num3 & !this.Effects[index].isEnahncementEffect & this.Effects[index].SpecialCase != Enums.eSpecialCase.Defiance) && (eEffectType != Enums.eEffectType.Mez | this.Effects[index].EffectType == Enums.eEffectType.Mez))
                    {
                        if (eEffectType == Enums.eEffectType.Mez & this.Effects[index].EffectType == Enums.eEffectType.Mez)
                        {
                            if (this.Effects[index].Mag > num4 || (this.Effects[index].SpecialCase == Enums.eSpecialCase.Domination && MidsContext.Character.Domination))
                            {
                                flag5 = true;
                            }
                        }
                        else
                        {
                            flag5 = true;
                        }
                    }
                    if ((float)num5 > this.Effects[index].DelayedTime & this.Effects[index].DelayedTime > 5f)
                    {
                        flag5 = true;
                    }
                    if (((double)Math.Abs(this.Effects[index].Probability - 1f) < 0.01 && flag) & this.Effects[index].EffectType == Enums.eEffectType.Mez)
                    {
                        flag5 = true;
                    }
                    if (this.Effects[index].EffectType == Enums.eEffectType.Mez & this.Effects[index].MezType == Enums.eMez.Taunt & this.Effects[index].EffectClass != Enums.eEffectClass.Primary)
                    {
                        flag5 = false;
                    }
                    if (this.Effects[index].EffectClass > eEffectClass & (this.Effects[index].SpecialCase != Enums.eSpecialCase.Domination || !MidsContext.Character.Domination))
                    {
                        flag5 = false;
                    }
                    if (this.Effects[index].EffectType == Enums.eEffectType.EntCreate & !flag4 & this.Effects[index].DelayedTime < 20f & eEffectType != Enums.eEffectType.Mez)
                    {
                        flag5 = true;
                    }
                    if (flag4 & this.Effects[index].EffectType != Enums.eEffectType.EntCreate & (this.Effects[index].Duration < num3 | (double)Math.Abs(num3) < 0.01 | this.Effects[index].DelayedTime > (float)num5 | (this.Effects[index].Mag < 0f & this.Effects[index].ToWho == Enums.eToWho.Self)))
                    {
                        flag5 = false;
                    }
                    if (flag4 & this.Effects[index].EffectType != Enums.eEffectType.EntCreate & this.Effects[index].Absorbed_Duration > num3)
                    {
                        flag5 = true;
                    }
                    if (eEffectType == Enums.eEffectType.Mez & num4 < 0f & (this.Effects[index].EffectType == Enums.eEffectType.Resistance | this.Effects[index].EffectType == Enums.eEffectType.Regeneration) & this.Effects[index].Mag > 0f)
                    {
                        flag5 = true;
                    }
                    if (this.Effects[index].EffectType == Enums.eEffectType.SetMode)
                    {
                        flag5 = false;
                    }
                    if (flag5)
                    {
                        num = index;
                        eEffectClass = this.Effects[index].EffectClass;
                        num2 = this.Effects[index].Probability;
                        if (flag4 & this.Effects[index].EffectType != Enums.eEffectType.EntCreate & this.Effects[index].Absorbed_Duration > num3)
                        {
                            num3 = this.Effects[index].Absorbed_Duration;
                        }
                        else
                        {
                            num3 = this.Effects[index].Duration;
                        }
                        flag = (this.Effects[index].EffectType == Enums.eEffectType.Damage);
                        eEffectType = this.Effects[index].EffectType;
                        num4 = this.Effects[index].Mag;
                        flag2 = this.Effects[index].Buffable;
                        flag3 = (this.Effects[index].SpecialCase == Enums.eSpecialCase.Defiance);
                        flag4 = (this.Effects[index].EffectType == Enums.eEffectType.EntCreate);
                        num5 = (int)this.Effects[index].DelayedTime;
                    }
                }
            }
            return num;
        }

        // Token: 0x06000444 RID: 1092 RVA: 0x000101AC File Offset: 0x0000E3AC
        public float[] GetDef(int buffDebuff = 0)
        {
            float[] numArray = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            bool flag = false;
            Enums.ePvX ePvX = MidsContext.Config.Inc.PvE ? Enums.ePvX.PvE : Enums.ePvX.PvP;
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if ((this.Effects[index].EffectType == Enums.eEffectType.Defense & this.Effects[index].Probability > 0f & this.Effects[index].CanInclude()) && (buffDebuff == 0 | (buffDebuff < 0 & this.Effects[index].Mag < 0f) | (buffDebuff > 0 & this.Effects[index].Mag > 0f)) && (this.Effects[index].Suppression & MidsContext.Config.Suppression) == Enums.eSuppress.None && (this.Effects[index].PvMode == ePvX | this.Effects[index].PvMode == Enums.ePvX.Any))
                {
                    numArray[(int)this.Effects[index].DamageType] += this.Effects[index].Mag;
                    if (this.Effects[index].DamageType != Enums.eDamage.None)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                float num = numArray[0];
                for (int index2 = 0; index2 <= numArray.Length - 1; index2++)
                {
                    numArray[index2] = num;
                }
            }
            return numArray;
        }

        // Token: 0x06000445 RID: 1093 RVA: 0x00010350 File Offset: 0x0000E550
        public float[] GetRes(bool pvE = true)
        {
            float[] numArray = new float[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
            bool flag = false;
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if ((this.Effects[index].EffectType == Enums.eEffectType.Resistance & this.Effects[index].Probability > 0f & this.Effects[index].CanInclude()) && ((this.Effects[index].PvMode != Enums.ePvX.PvP && pvE) | (this.Effects[index].PvMode != Enums.ePvX.PvE & !pvE)))
                {
                    numArray[(int)this.Effects[index].DamageType] += this.Effects[index].Mag;
                    if (this.Effects[index].DamageType != Enums.eDamage.None)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                float num = numArray[0];
                for (int index2 = 0; index2 <= numArray.Length - 1; index2++)
                {
                    numArray[index2] = num;
                }
            }
            return numArray;
        }

        // Token: 0x06000446 RID: 1094 RVA: 0x00010494 File Offset: 0x0000E694
        public bool HasDefEffects()
        {
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.Defense & this.Effects[index].Probability > 0f & (this.Effects[index].Suppression & MidsContext.Config.Suppression) == Enums.eSuppress.None & ((this.Effects[index].PvMode != Enums.ePvX.PvP & MidsContext.Config.Inc.PvE) | (this.Effects[index].PvMode != Enums.ePvX.PvE & !MidsContext.Config.Inc.PvE)))
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000447 RID: 1095 RVA: 0x00010568 File Offset: 0x0000E768
        public bool HasResEffects()
        {
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if (this.Effects[index].EffectType == Enums.eEffectType.Resistance & this.Effects[index].Probability > 0f & (this.Effects[index].Suppression & MidsContext.Config.Suppression) == Enums.eSuppress.None & ((this.Effects[index].PvMode != Enums.ePvX.PvP & MidsContext.Config.Inc.PvE) | (this.Effects[index].PvMode != Enums.ePvX.PvE & !MidsContext.Config.Inc.PvE)))
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000448 RID: 1096 RVA: 0x0001063C File Offset: 0x0000E83C
        public Enums.ShortFX GetEnhancementMagSum(Enums.eEffectType iEffect, int subType = 0)
        {
            Enums.ShortFX shortFx = default(Enums.ShortFX);
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; iIndex++)
            {
                if (this.Effects[iIndex].PvXInclude() && this.Effects[iIndex].Probability > 0f && this.Effects[iIndex].ETModifies == iEffect && this.Effects[iIndex].CanInclude() && (this.Effects[iIndex].EffectType == Enums.eEffectType.Enhancement || this.Effects[iIndex].EffectType == Enums.eEffectType.DamageBuff) && (!this.Effects[iIndex].Absorbed_Effect || this.Effects[iIndex].Absorbed_PowerType != Enums.ePowerType.GlobalBoost))
                {
                    if (iEffect == Enums.eEffectType.Mez && this.Effects[iIndex].ToWho != Enums.eToWho.Target)
                    {
                        if (subType == (int)this.Effects[iIndex].MezType || subType < 0)
                        {
                            shortFx.Add(iIndex, this.Effects[iIndex].Mag);
                        }
                    }
                    else if (this.Effects[iIndex].ToWho != Enums.eToWho.Target)
                    {
                        shortFx.Add(iIndex, this.Effects[iIndex].Mag);
                    }
                }
            }
            return shortFx;
        }

        // Token: 0x06000449 RID: 1097 RVA: 0x00010794 File Offset: 0x0000E994
        public Enums.ShortFX GetEffectMagSum(Enums.eEffectType iEffect, bool includeDelayed = false, bool onlySelf = false, bool onlyTarget = false, bool maxMode = false)
        {
            Enums.ShortFX shortFx = default(Enums.ShortFX);
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; iIndex++)
            {
                bool flag = onlySelf == onlyTarget || (!onlySelf && this.Effects[iIndex].ToWho == Enums.eToWho.Target) || (!onlyTarget && this.Effects[iIndex].ToWho == Enums.eToWho.Self) || (onlySelf & this.Effects[iIndex].ToWho != Enums.eToWho.Target) || (onlyTarget & this.Effects[iIndex].ToWho != Enums.eToWho.Self);
                if (((iEffect == Enums.eEffectType.SpeedFlying & !maxMode) && this.Effects[iIndex].Aspect == Enums.eAspect.Max) || (iEffect == Enums.eEffectType.SpeedRunning & !maxMode & this.Effects[iIndex].Aspect == Enums.eAspect.Max) || (iEffect == Enums.eEffectType.SpeedJumping & !maxMode & this.Effects[iIndex].Aspect == Enums.eAspect.Max))
                {
                    flag = false;
                }
                if ((MidsContext.Config.Suppression & this.Effects[iIndex].Suppression) != Enums.eSuppress.None)
                {
                    flag = false;
                }
                if (flag && this.Effects[iIndex].Probability > 0f && (!maxMode || this.Effects[iIndex].Aspect == Enums.eAspect.Max) && this.Effects[iIndex].EffectType == iEffect && this.Effects[iIndex].EffectClass != Enums.eEffectClass.Ignored && this.Effects[iIndex].EffectClass != Enums.eEffectClass.Special && (this.Effects[iIndex].DelayedTime <= 5f || includeDelayed) && this.Effects[iIndex].CanInclude() && this.Effects[iIndex].PvXInclude())
                {
                    float mag = this.Effects[iIndex].Mag;
                    if (this.Effects[iIndex].Ticks > 1 && this.Effects[iIndex].Stacking == Enums.eStacking.Yes)
                    {
                        mag *= (float)this.Effects[iIndex].Ticks;
                    }
                    shortFx.Add(iIndex, mag);
                }
            }
            return shortFx;
        }

        // Token: 0x0600044A RID: 1098 RVA: 0x000109BC File Offset: 0x0000EBBC
        public Enums.ShortFX GetDamageMagSum(Enums.eEffectType iEffect, Enums.eDamage iSub, bool includeDelayed = false)
        {
            Enums.ShortFX shortFx = default(Enums.ShortFX);
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; iIndex++)
            {
                if (this.Effects[iIndex].CanInclude() && (this.Effects[iIndex].EffectType == iEffect & this.Effects[iIndex].EffectClass != Enums.eEffectClass.Ignored) && this.Effects[iIndex].PvXInclude() && ((this.Effects[iIndex].DelayedTime <= 5f || includeDelayed) & this.Effects[iIndex].DamageType == iSub))
                {
                    float mag = this.Effects[iIndex].Mag;
                    if (this.PowerType == Enums.ePowerType.Toggle & this.Effects[iIndex].isEnahncementEffect)
                    {
                        mag /= 10f;
                    }
                    shortFx.Add(iIndex, mag);
                }
            }
            return shortFx;
        }

        // Token: 0x0600044B RID: 1099 RVA: 0x00010ABC File Offset: 0x0000ECBC
        public Enums.ShortFX GetEffectMag(Enums.eEffectType iEffect, Enums.eToWho iTarget = Enums.eToWho.Unspecified, bool allowDelay = false)
        {
            Enums.ShortFX shortFx = default(Enums.ShortFX);
            for (int iIndex = 0; iIndex <= this.Effects.Length - 1; iIndex++)
            {
                if (this.Effects[iIndex].EffectType == iEffect && this.Effects[iIndex].EffectClass != Enums.eEffectClass.Ignored && !this.Effects[iIndex].InherentSpecial && this.Effects[iIndex].PvXInclude() && (this.Effects[iIndex].DelayedTime <= 5f || allowDelay) && (iTarget == Enums.eToWho.Unspecified || this.Effects[iIndex].ToWho == Enums.eToWho.All || iTarget == this.Effects[iIndex].ToWho))
                {
                    float mag = this.Effects[iIndex].Mag;
                    if (this.Effects[iIndex].Ticks > 1)
                    {
                        mag *= (float)this.Effects[iIndex].Ticks;
                    }
                    if (this.Effects[iIndex].DisplayPercentage && (this.Effects[iIndex].EffectType == Enums.eEffectType.Heal || this.Effects[iIndex].EffectType == Enums.eEffectType.HitPoints))
                    {
                        shortFx.Add(iIndex, mag / 100f * (float)MidsContext.Archetype.Hitpoints);
                    }
                    else if (this.Effects[iIndex].EffectType == Enums.eEffectType.Heal || this.Effects[iIndex].EffectType == Enums.eEffectType.HitPoints)
                    {
                        shortFx.Add(iIndex, mag / (float)MidsContext.Archetype.Hitpoints * 100f);
                    }
                    else
                    {
                        shortFx.Add(iIndex, mag);
                    }
                    return shortFx;
                }
            }
            return shortFx;
        }

        // Token: 0x0600044C RID: 1100 RVA: 0x00010C8C File Offset: 0x0000EE8C
        public bool AffectsTarget(Enums.eEffectType iEffect)
        {
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if (this.Effects[index].EffectType == iEffect && this.Effects[index].ToWho == Enums.eToWho.Target)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600044D RID: 1101 RVA: 0x00010CF4 File Offset: 0x0000EEF4
        public bool AffectsSelf(Enums.eEffectType iEffect)
        {
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if (this.Effects[index].EffectType == iEffect && this.Effects[index].ToWho == Enums.eToWho.Self)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600044E RID: 1102 RVA: 0x00010D5C File Offset: 0x0000EF5C
        public bool I9FXPresentP(Enums.eEffectType iEffect, Enums.eMez iMez = Enums.eMez.None)
        {
            for (int index = 0; index <= this.Effects.Length - 1; index++)
            {
                if ((this.Effects[index].EffectType == iEffect & this.Effects[index].Mag > 0f) && !(this.Effects[index].EffectType == Enums.eEffectType.Damage & this.Effects[index].DamageType == Enums.eDamage.Special))
                {
                    bool flag;
                    if (iMez == Enums.eMez.None)
                    {
                        flag = true;
                    }
                    else
                    {
                        if (this.Effects[index].MezType != iMez)
                        {
                            goto IL_8B;
                        }
                        flag = true;
                    }
                    return flag;
                }
            IL_8B:;
            }
            return false;
        }

        // Token: 0x0600044F RID: 1103 RVA: 0x00010E18 File Offset: 0x0000F018
        public static Enums.ShortFX[] SplitFX(ref Enums.ShortFX iSfx, ref IPower iPower)
        {
            Enums.ShortFX[] array = new Enums.ShortFX[0];
            Enums.ShortFX[] shortFxArray2;
            if (!iSfx.Present)
            {
                shortFxArray2 = array;
            }
            else
            {
                array = new Enums.ShortFX[1];
                array[0].Add(iSfx.Index[0], iSfx.Value[0]);
                for (int index = 1; index <= iSfx.Value.Length - 1; index++)
                {
                    int index2 = -1;
                    for (int index3 = 0; index3 <= array.Length - 1; index3++)
                    {
                        if ((double)Math.Abs(iSfx.Value[index] - array[index3].Value[0]) < 0.01 && (iPower.Effects[iSfx.Index[index]].PvMode == iPower.Effects[array[index3].Index[0]].PvMode & iPower.Effects[iSfx.Index[index]].ToWho == iPower.Effects[array[index3].Index[0]].ToWho & iPower.Effects[iSfx.Index[index]].Stacking == iPower.Effects[array[index3].Index[0]].Stacking & iPower.Effects[iSfx.Index[index]].Aspect == iPower.Effects[array[index3].Index[0]].Aspect & iPower.Effects[iSfx.Index[index]].Buffable == iPower.Effects[array[index3].Index[0]].Buffable & iPower.Effects[iSfx.Index[index]].Resistible == iPower.Effects[array[index3].Index[0]].Resistible))
                        {
                            index2 = index3;
                            break;
                        }
                    }
                    if (index2 < 0)
                    {
                        Array.Resize<Enums.ShortFX>(ref array, array.Length + 1);
                        index2 = array.Length - 1;
                    }
                    array[index2].Add(iSfx.Index[index], iSfx.Value[index]);
                }
                shortFxArray2 = array;
            }
            return shortFxArray2;
        }

        // Token: 0x06000450 RID: 1104 RVA: 0x00011074 File Offset: 0x0000F274
        public static string SplitFXGroupTip(ref Enums.ShortFX iSfx, ref IPower iPower, bool shortForm)
        {
            string str = iPower.Effects[iSfx.Index[0]].BuildEffectString(false, string.Empty, false, true, false);
            string newValue = string.Empty;
            if (iPower.Effects[iSfx.Index[0]].isDamage())
            {
                bool[] iDamage = new bool[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                for (int index = 0; index <= iSfx.Index.Length - 1; index++)
                {
                    iDamage[(int)iPower.Effects[iSfx.Index[index]].DamageType] = true;
                }
                if (iPower.Effects[iSfx.Index[0]].EffectType == Enums.eEffectType.Defense | iPower.Effects[iSfx.Index[0]].EffectType == Enums.eEffectType.Elusivity)
                {
                    newValue = Enums.GetGroupedDefense(iDamage, shortForm);
                }
                else
                {
                    newValue = Enums.GetGroupedDamage(iDamage, shortForm);
                }
            }
            return str.Replace("%VALUE%", newValue);
        }

        // Token: 0x06000451 RID: 1105 RVA: 0x00011180 File Offset: 0x0000F380
        public bool UpdateFromCSV(string iCSV)
        {
            bool flag;
            if (string.IsNullOrEmpty(iCSV))
            {
                flag = false;
            }
            else if (this.NeverAutoUpdate)
            {
                flag = true;
            }
            else
            {
                string[] array = CSV.ToArray(iCSV);
                try
                {
                    if (array[0].Split(".".ToCharArray())[2].StartsWith("Hide"))
                    {
                        array = CSV.ToArray(iCSV.Replace("'Hidden" + char.ConvertFromUtf32(34) + char.ConvertFromUtf32(34), "'Hidden'"));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Power Import: Fixed stupid Hide bug.");
                }
                if (array.Length < 93)
                {
                    flag = false;
                }
                else
                {
                    this.FullName = array[0];
                    char[] separator = new char[]
                    {
                        '.'
                    };
                    string[] strArray = this.FullName.Split(separator);
                    if (strArray.Length > 2)
                    {
                        if (!string.IsNullOrEmpty(strArray[1]))
                        {
                            this.PowerName = strArray[2];
                        }
                        if (!string.IsNullOrEmpty(strArray[1]))
                        {
                            this.SetName = strArray[1];
                        }
                        if (!string.IsNullOrEmpty(strArray[0]))
                        {
                            this.GroupName = strArray[0];
                        }
                    }
                    string lower;
                    if (string.IsNullOrEmpty(this.ForcedClass) && (lower = this.GroupName.ToLower()) != null)
                    {
                        if (!(lower == "pets"))
                        {
                            if (lower == "mastermind_pets")
                            {
                                this.ForcedClass = "Class_Minion_Henchman";
                            }
                        }
                        else
                        {
                            this.ForcedClass = "Class_Minion_Pets";
                        }
                    }
                    this.DisplayName = array[1];
                    this.Available = int.Parse(array[2]);
                    string str = array[3];
                    if (!this.NeverAutoUpdateRequirements)
                    {
                        this.Requires = this.ImportRequirementString(str);
                    }
                    str = array[4];
                    this.ModesRequired = (Enums.eModeFlags)Enums.StringToFlaggedEnum(str, this.ModesRequired, false);
                    str = array[5];
                    this.ModesDisallowed = (Enums.eModeFlags)Enums.StringToFlaggedEnum(str, this.ModesDisallowed, false);
                    str = array[6];
                    try
                    {
                        this.PowerType = (Enums.ePowerType)Enum.Parse(this.PowerType.GetType(), str.Replace("Auto", "Auto_").Replace("Global Boost", "GlobalBoost"), true);
                    }
                    catch
                    {
                        this.PowerType = Enums.ePowerType.Auto_;
                    }
                    this.Accuracy = float.Parse(array[7]);
                    str = array[8];
                    this.AttackTypes = (Enums.eVector)Enums.StringToFlaggedEnum(str, this.AttackTypes, false);
                    str = array[9];
                    this.GroupMembership = Enums.StringToArray(str);
                    str = array[11];
                    this.EntitiesAffected = (Enums.eEntity)Enums.StringToFlaggedEnum(str, this.EntitiesAffected, false);
                    str = array[12];
                    this.EntitiesAutoHit = (Enums.eEntity)Enums.StringToFlaggedEnum(str, this.EntitiesAutoHit, false);
                    str = array[13];
                    this.Target = (Enums.eEntity)Enums.StringToFlaggedEnum(str, this.Target, false);
                    str = array[14];
                    this.TargetLoS = !string.Equals(str, "NONE", StringComparison.OrdinalIgnoreCase);
                    this.Range = float.Parse(array[17]);
                    str = array[18];
                    this.TargetSecondary = (Enums.eEntity)Enums.StringToFlaggedEnum(str, this.TargetSecondary, true);
                    this.RangeSecondary = float.Parse(array[19]);
                    this.EndCost = float.Parse(array[20]);
                    this.InterruptTime = float.Parse(array[22]);
                    this.CastTimeReal = float.Parse(array[23]);
                    this.RechargeTime = float.Parse(array[24]);
                    this.ActivatePeriod = float.Parse(array[25]);
                    str = array[26];
                    this.EffectArea = (Enums.eEffectArea)Enums.StringToFlaggedEnum(str, this.EffectArea, true);
                    this.Radius = float.Parse(array[27]);
                    this.Arc = int.Parse(array[28]);
                    this.MaxTargets = int.Parse(array[29]);
                    this.MaxBoosts = array[30];
                    str = array[31];
                    this.CastFlags = (Enums.eCastFlags)Enums.StringToFlaggedEnum(str, this.CastFlags, false);
                    str = array[32];
                    this.AIReport = (Enums.eNotify)Enums.StringToFlaggedEnum(str, this.AIReport, true);
                    this.NumCharges = int.Parse(array[33]);
                    this.UsageTime = int.Parse(array[34]);
                    this.LifeTime = int.Parse(array[35]);
                    this.LifeTimeInGame = int.Parse(array[36]);
                    this.NumAllowed = int.Parse(array[37]);
                    int num = int.Parse(array[38]);
                    this.DoNotSave = (num > 0);
                    str = array[39];
                    this.BoostsAllowed = Enums.StringToArray(str);
                    num = int.Parse(array[41]);
                    this.CastThroughHold = (num > 0);
                    num = int.Parse(array[45]);
                    this.IgnoreStrength = (num > 0);
                    this.DescShort = array[46];
                    this.DescLong = array[47];
                    num = int.Parse(array[69]);
                    this.BoostBoostable = (num > 0);
                    num = int.Parse(array[70]);
                    this.BoostUsePlayerLevel = (num > 0);
                    str = array[76];
                    this.IgnoreEnh = Enums.StringToEnumArray<Enums.eEnhance>(str, typeof(Enums.eEnhance));
                    flag = true;
                }
            }
            return flag;
        }

        // Token: 0x06000452 RID: 1106 RVA: 0x00011730 File Offset: 0x0000F930
        private Requirement ImportRequirementString(string iReq)
        {
            Requirement requirement;
            if (this.NeverAutoUpdateRequirements)
            {
                requirement = this.Requires;
            }
            else
            {
                Requirement requirement2 = new Requirement();
                if (iReq == null)
                {
                    requirement = requirement2;
                }
                else if (iReq.Length == 0)
                {
                    requirement = requirement2;
                }
                else
                {
                    requirement2.ClassNameNot = new string[0];
                    requirement2.ClassName = new string[0];
                    requirement2.PowerID = new string[0][];
                    requirement2.PowerIDNot = new string[0][];
                    iReq = iReq.ToUpper();
                    for (int index = 0; index <= 1; index++)
                    {
                        string str = "$ARCHETYPE @";
                        if (index == 1)
                        {
                            str = "$ARCHTYPE @";
                        }
                        for (int index2 = 0; index2 <= DatabaseAPI.Database.Classes.Length - 1; index2++)
                        {
                            string oldValue = str + DatabaseAPI.Database.Classes[index2].ClassName.ToUpper() + " ==";
                            string oldValue2 = oldValue + " !";
                            if (iReq.Contains(oldValue2))
                            {
                                Array.Resize<string>(ref requirement2.ClassNameNot, requirement2.ClassNameNot.Length + 1);
                                requirement2.ClassNameNot[requirement2.ClassNameNot.Length - 1] = DatabaseAPI.Database.Classes[index2].ClassName;
                                iReq = iReq.Replace(oldValue2, "true");
                            }
                            else if (iReq.Contains(oldValue))
                            {
                                Array.Resize<string>(ref requirement2.ClassName, requirement2.ClassName.Length + 1);
                                requirement2.ClassName[requirement2.ClassName.Length - 1] = DatabaseAPI.Database.Classes[index2].ClassName;
                                iReq = iReq.Replace(oldValue, "true");
                            }
                            else
                            {
                                iReq.Contains(str);
                            }
                        }
                        if (iReq.Contains(str))
                        {
                            int startIndex = iReq.IndexOf(str, StringComparison.Ordinal);
                            for (int index3 = startIndex + str.Length; index3 <= iReq.Length - 1; index3++)
                            {
                                if (iReq[index3] == ' ')
                                {
                                    iReq = iReq.Replace(iReq.Substring(startIndex, index3 - startIndex), "true");
                                    break;
                                }
                            }
                            iReq = iReq.Replace("true ==", "true");
                            iReq = iReq.Replace("true !", "true");
                        }
                    }
                    string[] strArray = new string[33];
                    int index4 = 0;
                    string[] strArray2 = iReq.Split(null);
                    for (int index5 = 0; index5 <= strArray2.Length - 1; index5++)
                    {
                        strArray2[index5] = strArray2[index5].ToLower();
                        if (strArray2[index5] == "&&")
                        {
                            if (index4 > 1 && (strArray[index4 - 1] == "true" & strArray[index4 - 2] == "true"))
                            {
                                index4--;
                                strArray[index4] = string.Empty;
                                strArray[index4 - 1] = "true";
                            }
                            else if (index4 > 1 && (strArray[index4 - 1] == "true" & strArray[index4 - 2] != "true"))
                            {
                                requirement2.AddPowers(strArray[index4 - 2], string.Empty);
                                index4--;
                                strArray[index4] = string.Empty;
                                strArray[index4 - 1] = "true";
                            }
                            else if (index4 > 1 && (strArray[index4 - 1] != "true" & strArray[index4 - 2] == "true"))
                            {
                                requirement2.AddPowers(strArray[index4 - 1], string.Empty);
                                index4--;
                                strArray[index4] = string.Empty;
                            }
                            else if (index4 > 1 && (strArray[index4 - 1] != "true" & strArray[index4 - 2] != "true"))
                            {
                                requirement2.AddPowers(strArray[index4 - 2], strArray[index4 - 1]);
                                index4--;
                                strArray[index4] = string.Empty;
                                strArray[index4 - 1] = "true";
                            }
                        }
                        else if (strArray2[index5] == "!")
                        {
                            strArray[index4 - 1] = "!" + strArray[index4 - 1];
                        }
                        else if (strArray2[index5] == "||")
                        {
                            if (index4 > 1)
                            {
                                if (strArray[index4 - 1] == "true" & strArray[index4 - 2] == "true")
                                {
                                    index4--;
                                    strArray[index4] = string.Empty;
                                    strArray[index4 - 1] = "true";
                                }
                                else if (strArray[index4 - 1] != "true" & strArray[index4 - 2] == "true")
                                {
                                    requirement2.AddPowers(strArray[index4 - 1], string.Empty);
                                    index4--;
                                    strArray[index4] = string.Empty;
                                }
                                else if (strArray[index4 - 1] == "true" & strArray[index4 - 2] != "true")
                                {
                                    requirement2.AddPowers(strArray[index4 - 2], string.Empty);
                                    index4--;
                                    strArray[index4] = string.Empty;
                                    strArray[index4 - 1] = "true";
                                }
                                else
                                {
                                    requirement2.AddPowers(strArray[index4 - 2], string.Empty);
                                    requirement2.AddPowers(strArray[index4 - 1], string.Empty);
                                    index4--;
                                    strArray[index4] = string.Empty;
                                    strArray[index4 - 1] = "true";
                                }
                            }
                        }
                        else if (strArray2[index5] == "owned?")
                        {
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == "auth>")
                        {
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == "productowned?")
                        {
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == "tokenowned?")
                        {
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == "char>")
                        {
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == ">=")
                        {
                            index4--;
                            strArray[index4] = string.Empty;
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == ">")
                        {
                            index4--;
                            strArray[index4] = string.Empty;
                            strArray[index4 - 1] = "true";
                        }
                        else if (strArray2[index5] == "source>")
                        {
                            strArray[index4 - 1] = "true";
                        }
                        else if (!(strArray2[index5] == "eq"))
                        {
                            if (strArray2[index5] == "ispvpmap?")
                            {
                                if (index5 < strArray2.GetUpperBound(0) && strArray2[index5 + 1] == "!")
                                {
                                    strArray2[index5 + 1] = string.Empty;
                                }
                                strArray[index4] = "true";
                                index4++;
                            }
                            else if (strArray2[index5] == "isarchitectmap?")
                            {
                                if (index5 < strArray2.GetUpperBound(0) && strArray2[index5 + 1] == "!")
                                {
                                    strArray2[index5 + 1] = string.Empty;
                                }
                                strArray[index4] = "true";
                                index4++;
                            }
                            else if (!string.IsNullOrEmpty(strArray2[index5]))
                            {
                                strArray[index4] = strArray2[index5];
                                index4++;
                            }
                        }
                    }
                    if (index4 == 1 && strArray[0] != "true")
                    {
                        requirement2.AddPowers(strArray[0], string.Empty);
                        strArray[0] = "true";
                    }
                    if (index4 != 0 && (index4 > 1 | strArray[0] != "true"))
                    {
                        string str2 = "Tokens remain in the stack (this can cause problems): \n";
                        for (int index6 = 0; index6 <= index4; index6++)
                        {
                            str2 = str2 + strArray[index6] + " ";
                        }
                        str2 = str2 + "\n\niReq: " + iReq;
                        str2 += "\n\nSee clsPowerV2/ImportRequirementString to tweak.";
                        MessageBox.Show(str2);
                    }
                    for (int index7 = 0; index7 <= requirement2.PowerID.Length - 1; index7++)
                    {
                        for (int index8 = 0; index8 <= requirement2.PowerID[index7].Length - 1; index8++)
                        {
                            if (!string.IsNullOrEmpty(requirement2.PowerID[index7][index8]))
                            {
                                for (int index9 = 0; index9 <= DatabaseAPI.Database.Power.Length - 1; index9++)
                                {
                                    if (string.Equals(DatabaseAPI.Database.Power[index9].FullName, requirement2.PowerID[index7][index8], StringComparison.OrdinalIgnoreCase))
                                    {
                                        requirement2.PowerID[index7][index8] = DatabaseAPI.Database.Power[index9].FullName;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    requirement = requirement2;
                }
            }
            return requirement;
        }

        // Token: 0x06000453 RID: 1107 RVA: 0x0001219C File Offset: 0x0001039C
        public bool IgnoreEnhancement(Enums.eEnhance iEffect)
        {
            bool flag;
            if (this.IgnoreEnh.Length == 0)
            {
                flag = true;
            }
            else
            {
                for (int index = 0; index <= this.IgnoreEnh.Length - 1; index++)
                {
                    if (this.IgnoreEnh[index] == iEffect)
                    {
                        return false;
                    }
                }
                flag = true;
            }
            return flag;
        }

        // Token: 0x06000454 RID: 1108 RVA: 0x00012204 File Offset: 0x00010404
        public bool IgnoreBuff(Enums.eEnhance iEffect)
        {
            bool flag;
            if (this.Ignore_Buff.Length == 0)
            {
                flag = true;
            }
            else
            {
                for (int index = 0; index <= this.Ignore_Buff.Length - 1; index++)
                {
                    if (this.Ignore_Buff[index] == iEffect)
                    {
                        return false;
                    }
                }
                flag = true;
            }
            return flag;
        }

        // Token: 0x06000455 RID: 1109 RVA: 0x0001226C File Offset: 0x0001046C
        public int CompareTo(object obj)
        {
            Power power = obj as Power;
            if (power == null)
            {
                throw new ArgumentException("Comparison failed - Passed object was not an Archetype Class!");
            }
            int num = string.Compare(this.FullSetName, power.FullSetName, StringComparison.OrdinalIgnoreCase);
            int result;
            if (num != 0)
            {
                result = num;
            }
            else if (this.Level > power.Level)
            {
                result = 1;
            }
            else if (this.Level < power.Level)
            {
                result = -1;
            }
            else if (this.Level == power.Level && this.SortOverride && !power.SortOverride)
            {
                result = -1;
            }
            else if (this.Level == power.Level && !this.SortOverride && power.SortOverride)
            {
                result = 1;
            }
            else
            {
                result = string.Compare(this.FullName, power.FullName, StringComparison.OrdinalIgnoreCase);
            }
            return result;
        }

        // Token: 0x06000456 RID: 1110 RVA: 0x00012374 File Offset: 0x00010574
        public void SetMathMag()
        {
            for (int index = 0; index < this.Effects.Length; index++)
            {
                this.Effects[index].Math_Duration = this.Effects[index].Duration;
                this.Effects[index].Math_Mag = this.Effects[index].Mag;
            }
        }

        // Token: 0x06000457 RID: 1111 RVA: 0x000123D4 File Offset: 0x000105D4
        public bool GetEffectStringGrouped(int idEffect, ref string returnString, ref int[] returnMask, bool shortForm, bool simple, bool noMag = false)
        {
            bool flag;
            if (idEffect < 0 | idEffect > this.Effects.Length - 1)
            {
                flag = false;
            }
            else
            {
                string str = string.Empty;
                int[] array = new int[0];
                IEffect effect = (IEffect)this.Effects[idEffect].Clone();
                if (effect.EffectType == Enums.eEffectType.DamageBuff || effect.EffectType == Enums.eEffectType.Defense || effect.EffectType == Enums.eEffectType.Resistance || effect.EffectType == Enums.eEffectType.Elusivity)
                {
                    bool[] iDamage = new bool[Enum.GetValues(Enums.eDamage.None.GetType()).Length];
                    for (int index = 0; index <= this.Effects.Length - 1; index++)
                    {
                        for (int index2 = 0; index2 <= iDamage.Length - 1; index2++)
                        {
                            effect.DamageType = (Enums.eDamage)index2;
                            if (effect.CompareTo(this.Effects[index]) == 0)
                            {
                                iDamage[index2] = true;
                                Array.Resize<int>(ref array, array.Length + 1);
                                array[array.Length - 1] = index;
                            }
                        }
                    }
                    if (array.Length <= 1)
                    {
                        return false;
                    }
                    effect.DamageType = Enums.eDamage.Special;
                    string newValue = (effect.EffectType == Enums.eEffectType.Defense) ? Enums.GetGroupedDefense(iDamage, shortForm) : Enums.GetGroupedDamage(iDamage, shortForm);
                    str = (shortForm ? effect.BuildEffectStringShort(noMag, simple, false).Replace("Spec", newValue) : effect.BuildEffectString(simple, "", false, false, false).Replace("Special", newValue));
                }
                else if (effect.EffectType == Enums.eEffectType.Mez | effect.EffectType == Enums.eEffectType.MezResist)
                {
                    bool[] iMez = new bool[Enum.GetValues(Enums.eMez.None.GetType()).Length];
                    for (int index3 = 0; index3 <= this.Effects.Length - 1; index3++)
                    {
                        for (int index4 = 0; index4 <= iMez.Length - 1; index4++)
                        {
                            effect.MezType = (Enums.eMez)index4;
                            if (effect.CompareTo(this.Effects[index3]) == 0)
                            {
                                iMez[index4] = true;
                                Array.Resize<int>(ref array, array.Length + 1);
                                array[array.Length - 1] = index3;
                            }
                        }
                    }
                    if (array.Length <= 1)
                    {
                        return false;
                    }
                    effect.MezType = Enums.eMez.None;
                    string newValue2 = Enums.GetGroupedMez(iMez, shortForm);
                    if (newValue2 == "Knocked" && effect.Mag < 0f)
                    {
                        newValue2 = "Knockback Protection";
                    }
                    str = (shortForm ? effect.BuildEffectStringShort(noMag, simple, false).Replace("None", newValue2) : effect.BuildEffectString(simple, "", false, false, false).Replace("None", newValue2));
                    if (effect.EffectType == Enums.eEffectType.MezResist)
                    {
                        if (newValue2 == "Mez")
                        {
                            str = str.Replace("MezResist(Mez)", "Status Resistance");
                        }
                    }
                    else if (effect.EffectType == Enums.eEffectType.Mez)
                    {
                        if (newValue2 == "Mez" & effect.Mag < 0f)
                        {
                            str = str.Replace("Mez", "Status Protection").Replace("-", string.Empty);
                        }
                        else if (newValue2 != "Knockback Protection")
                        {
                            str = str.Replace("(Mag -", "protection (Mag ");
                        }
                    }
                }
                else if (effect.EffectType == Enums.eEffectType.Enhancement)
                {
                    int num = 0;
                    if (this.Effects.Length == 4)
                    {
                        for (int index5 = 0; index5 <= this.Effects.Length - 1; index5++)
                        {
                            if (this.Effects[index5].EffectType == Enums.eEffectType.Enhancement && (this.Effects[index5].ETModifies == Enums.eEffectType.SpeedRunning | this.Effects[index5].ETModifies == Enums.eEffectType.SpeedFlying | this.Effects[index5].ETModifies == Enums.eEffectType.SpeedJumping | this.Effects[index5].ETModifies == Enums.eEffectType.JumpHeight))
                            {
                                num++;
                            }
                        }
                        if (num == this.Effects.Length)
                        {
                            array = new int[this.Effects.Length];
                            for (int index6 = 0; index6 <= array.Length - 1; index6++)
                            {
                                array[index6] = index6;
                            }
                            effect.ETModifies = Enums.eEffectType.Slow;
                            str = (shortForm ? effect.BuildEffectStringShort(noMag, simple, false) : effect.BuildEffectString(simple, "", false, false, false));
                            if (this.BuffMode != Enums.eBuffMode.Debuff)
                            {
                                str = str.Replace("Slow", "Movement");
                            }
                        }
                    }
                }
                returnMask = new int[array.Length];
                Array.Copy(array, returnMask, array.Length);
                returnString = str;
                flag = true;
            }
            return flag;
        }

        // Token: 0x06000458 RID: 1112 RVA: 0x00012938 File Offset: 0x00010B38
        public int[] AbsorbEffects(IPower source, float nDuration, float nDelay, Archetype archetype, int stacking, bool isGrantPower = false, int fxid = -1, int effectId = -1)
        {
            int num3 = -1;
            int length = this.Effects.Length;
            int[] array = new int[0];
            float num4 = 0f;
            if (source.PowerSetID > -1 && DatabaseAPI.Database.Powersets[source.PowerSetID].SetType == Enums.ePowerSetType.Pet)
            {
                foreach (IPower power in DatabaseAPI.Database.Powersets[source.PowerSetID].Powers)
                {
                    foreach (IEffect effect in power.Effects)
                    {
                        if (effect.EffectType == Enums.eEffectType.SilentKill & effect.ToWho == Enums.eToWho.Self & effect.DelayedTime > 0f)
                        {
                            num4 = effect.DelayedTime;
                        }
                    }
                }
            }
            if (num4 > 0f & ((double)nDuration < 0.01 || nDuration > num4))
            {
                nDuration = num4;
            }
            if (effectId == -1)
            {
                for (int index = 0; index <= source.Effects.Length - 1; index++)
                {
                    if (!(!isGrantPower & (source.EntitiesAffected == Enums.eEntity.Caster & source.Effects[index].EffectType != Enums.eEffectType.EntCreate)))
                    {
                        if (source.Effects[index].EffectType == Enums.eEffectType.EntCreate && source.Effects[index].nSummon > -1)
                        {
                            Array.Resize<int>(ref array, array.Length + 1);
                            array[array.Length - 1] = index;
                        }
                        num3++;
                        IEffect[] effects = this.Effects;
                        Array.Resize<IEffect>(ref effects, num3 + length + 1);
                        this.Effects = effects;
                        IEffect effect2 = (IEffect)source.Effects[index].Clone();
                        effect2.Absorbed_Effect = true;
                        effect2.Absorbed_PowerType = source.PowerType;
                        effect2.Absorbed_Class_nID = archetype.Idx;
                        effect2.Absorbed_EffectID = fxid;
                        effect2.Absorbed_Power_nID = source.PowerIndex;
                        if (source.PowerType == Enums.ePowerType.Auto_ || source.PowerType == Enums.ePowerType.Toggle)
                        {
                            effect2.SetTicks(nDuration, source.ActivatePeriod);
                        }
                        if ((source.EntitiesAutoHit & Enums.eEntity.Friend) == Enums.eEntity.Friend)
                        {
                            effect2.ToWho = Enums.eToWho.Self;
                            if (effect2.Stacking == Enums.eStacking.Yes)
                            {
                                effect2.Scale *= (float)stacking;
                            }
                        }
                        effect2.Absorbed_Duration = nDuration;
                        if (source.RechargeTime > 0f & source.PowerType == Enums.ePowerType.Click)
                        {
                            effect2.Absorbed_Interval = source.RechargeTime + source.CastTime;
                        }
                        if (nDelay > 0f)
                        {
                            effect2.DelayedTime = nDelay;
                        }
                        if (effect2.Absorbed_Duration > 0f & num4 > 0f)
                        {
                            effect2.nDuration = effect2.Absorbed_Duration;
                        }
                        this.Effects[num3 + length] = effect2;
                    }
                }
            }
            else if (isGrantPower || source.EntitiesAffected != Enums.eEntity.Caster || source.Effects[effectId].EffectType == Enums.eEffectType.EntCreate)
            {
                if (source.Effects[effectId].EffectType == Enums.eEffectType.EntCreate && source.Effects[effectId].nSummon > -1)
                {
                    Array.Resize<int>(ref array, array.Length + 1);
                    array[array.Length - 1] = effectId;
                }
                num3++;
                IEffect[] effects2 = this.Effects;
                Array.Resize<IEffect>(ref effects2, num3 + length + 1);
                this.Effects = effects2;
                IEffect effect3 = (IEffect)source.Effects[effectId].Clone();
                effect3.Absorbed_Effect = true;
                effect3.Absorbed_PowerType = source.PowerType;
                effect3.Absorbed_Class_nID = archetype.Idx;
                effect3.Absorbed_EffectID = fxid;
                effect3.Absorbed_Power_nID = source.PowerIndex;
                if (source.PowerType == Enums.ePowerType.Auto_ || source.PowerType == Enums.ePowerType.Toggle)
                {
                    effect3.SetTicks(nDuration, source.ActivatePeriod);
                }
                if ((source.EntitiesAutoHit & Enums.eEntity.Friend) == Enums.eEntity.Friend)
                {
                    effect3.ToWho = Enums.eToWho.Self;
                    if (effect3.Stacking == Enums.eStacking.Yes)
                    {
                        effect3.Scale *= (float)stacking;
                    }
                }
                effect3.Absorbed_Duration = nDuration;
                if (source.RechargeTime > 0f & source.PowerType == Enums.ePowerType.Click)
                {
                    effect3.Absorbed_Interval = source.RechargeTime + source.CastTime;
                }
                if (nDelay > 0f)
                {
                    effect3.DelayedTime = nDelay;
                }
                if (effect3.Absorbed_Duration > 0f & num4 > 0f)
                {
                    effect3.nDuration = effect3.Absorbed_Duration;
                }
                this.Effects[num3 + length] = effect3;
            }
            return array;
        }

        // Token: 0x06000459 RID: 1113 RVA: 0x00012EB0 File Offset: 0x000110B0
        public void ApplyGrantPowerEffects()
        {
            bool flag = true;
            int num = 0;
            int num2 = 0;
            if (this.HasGrantPowerEffect && this.EntitiesAffected != Enums.eEntity.MyPet)
            {
                while (flag & num < 100)
                {
                    flag = false;
                    int[] array = new int[0];
                    int[] array2 = new int[0];
                    for (int index = num2; index < this.Effects.Length; index++)
                    {
                        if (this.Effects[index].EffectType == Enums.eEffectType.GrantPower && this.Effects[index].EffectClass != Enums.eEffectClass.Ignored && this.Effects[index].nSummon > -1)
                        {
                            Array.Resize<int>(ref array, array.Length + 1);
                            Array.Resize<int>(ref array2, array2.Length + 1);
                            array[array.Length - 1] = index;
                            array2[array2.Length - 1] = this.Effects[index].nSummon;
                        }
                    }
                    num2 = this.Effects.Length;
                    for (int index2 = 0; index2 <= array.Length - 1; index2++)
                    {
                        flag = true;
                        this.Effects[array[index2]].EffectClass = Enums.eEffectClass.Ignored;
                        int length = this.Effects.Length;
                        this.AbsorbEffects(DatabaseAPI.Database.Power[array2[index2]], this.Effects[array[index2]].Duration, 0f, MidsContext.Archetype, 1, true, array[index2], -1);
                        for (int index3 = length; index3 < this.Effects.Length; index3++)
                        {
                            if (this.Effects[array[index2]].Absorbed_Power_nID > -1)
                            {
                                this.Effects[index3].Absorbed_PowerType = this.Effects[array[index2]].Absorbed_PowerType;
                            }
                            if (this.Effects[index3].EffectType != Enums.eEffectType.GrantPower)
                            {
                                this.Effects[index3].ToWho = this.Effects[array[index2]].ToWho;
                            }
                            if (this.Effects[index3].ToWho == Enums.eToWho.All && (this.EntitiesAffected & Enums.eEntity.Caster) != Enums.eEntity.Caster)
                            {
                                this.Effects[index3].ToWho = Enums.eToWho.Target;
                            }
                            this.Effects[index3].isEnahncementEffect = this.Effects[array[index2]].isEnahncementEffect;
                            if (this.Effects[array[index2]].Probability < 1f)
                            {
                                this.Effects[index3].Probability = this.Effects[array[index2]].Probability * this.Effects[index3].Probability;
                            }
                        }
                    }
                    num++;
                }
            }
        }

        // Token: 0x0600045A RID: 1114 RVA: 0x00013180 File Offset: 0x00011380
        private int[] GetValidEnhancementsFromSets()
        {
            List<int> intList = new List<int>();
            foreach (EnhancementSet enhancementSet in DatabaseAPI.Database.EnhancementSets)
            {
                bool flag = false;
                foreach (Enums.eSetType setType in this.SetTypes)
                {
                    if (enhancementSet.SetType == setType)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    foreach (int enhancement in enhancementSet.Enhancements)
                    {
                        intList.Add(enhancement);
                    }
                }
            }
            return intList.ToArray();
        }

        // Token: 0x0600045B RID: 1115 RVA: 0x00013274 File Offset: 0x00011474
        public int[] GetValidEnhancements(Enums.eType iType, Enums.eSubtype iSubType = Enums.eSubtype.None)
        {
            List<int> intList = new List<int>();
            int[] numArray;
            if (iType == Enums.eType.SetO)
            {
                numArray = this.GetValidEnhancementsFromSets();
            }
            else
            {
                for (int index = 0; index <= DatabaseAPI.Database.Enhancements.Length - 1; index++)
                {
                    IEnhancement enhancement = DatabaseAPI.Database.Enhancements[index];
                    if (enhancement.TypeID == iType)
                    {
                        bool flag = false;
                        foreach (int index2 in enhancement.ClassID)
                        {
                            foreach (int enhancement2 in this.Enhancements)
                            {
                                if (DatabaseAPI.Database.EnhancementClasses[index2].ID == enhancement2 && (enhancement.SubTypeID == Enums.eSubtype.None || iSubType == Enums.eSubtype.None || enhancement.SubTypeID == iSubType))
                                {
                                    flag = true;
                                }
                            }
                        }
                        if (flag)
                        {
                            intList.Add(index);
                        }
                    }
                }
                numArray = intList.ToArray();
            }
            return numArray;
        }

        // Token: 0x0600045C RID: 1116 RVA: 0x000133B4 File Offset: 0x000115B4
        public bool IsEnhancementValid(int iEnh)
        {
            bool flag;
            if (iEnh < 0 || iEnh > DatabaseAPI.Database.Enhancements.Length - 1)
            {
                flag = false;
            }
            else
            {
                int[] validEnhancements = this.GetValidEnhancements(DatabaseAPI.Database.Enhancements[iEnh].TypeID, Enums.eSubtype.None);
                for (int i = 0; i < validEnhancements.Length; i++)
                {
                    if (validEnhancements[i] == iEnh)
                    {
                        return true;
                    }
                }
                flag = false;
            }
            return flag;
        }

        // Token: 0x0600045D RID: 1117 RVA: 0x00013438 File Offset: 0x00011638
        public void AbsorbPetEffects(int hIdx = -1)
        {
            if (this.AbsorbSummonAttributes || this.AbsorbSummonEffects)
            {
                List<int> intList = new List<int>();
                for (int index = 0; index < this.Effects.Length; index++)
                {
                    if (this.Effects[index].EffectType == Enums.eEffectType.EntCreate && this.Effects[index].nSummon > -1 && (double)Math.Abs(this.Effects[index].Probability - 1f) < 0.01 && DatabaseAPI.Database.Entities.Length > this.Effects[index].nSummon)
                    {
                        intList.Add(index);
                    }
                }
                if (intList.Count > 0)
                {
                    this.HasAbsorbedEffects = true;
                }
                for (int index2 = 0; index2 < intList.Count; index2++)
                {
                    IEffect effect = this.Effects[intList[index2]];
                    int nSummon = effect.nSummon;
                    int stacking = 1;
                    if (this.VariableEnabled && effect.VariableModified && hIdx > -1 && MidsContext.Character != null && MidsContext.Character.CurrentBuild.Powers[hIdx].VariableValue > stacking)
                    {
                        stacking = MidsContext.Character.CurrentBuild.Powers[hIdx].VariableValue;
                    }
                    int[] nPowerset = DatabaseAPI.Database.Entities[nSummon].nPowerset;
                    if (nPowerset.Length != 0)
                    {
                        if (this.AbsorbSummonAttributes && nPowerset[0] > -1 && nPowerset[0] < DatabaseAPI.Database.Powersets.Length)
                        {
                            IPowerset powerset = DatabaseAPI.Database.Powersets[nPowerset[0]];
                            if (powerset.Power.Length > 0)
                            {
                                foreach (IPower power in powerset.Powers)
                                {
                                    this.ActivatePeriod = power.ActivatePeriod;
                                    this.AttackTypes = power.AttackTypes;
                                    this.EffectArea = power.EffectArea;
                                    this.EntitiesAffected = power.EntitiesAffected;
                                    if (this.EntitiesAutoHit != Enums.eEntity.None)
                                    {
                                        this.EntitiesAutoHit = power.EntitiesAutoHit;
                                    }
                                    this.Ignore_Buff = power.Ignore_Buff;
                                    this.IgnoreEnh = power.IgnoreEnh;
                                    this.MaxTargets = power.MaxTargets;
                                    this.Radius = power.Radius;
                                    this.Target = power.Target;
                                    this.ActivatePeriod = power.ActivatePeriod;
                                    if (DatabaseAPI.Database.Power[this.PowerIndex].EntitiesAutoHit != Enums.eEntity.None && DatabaseAPI.Database.Power[this.PowerIndex].EntitiesAutoHit != Enums.eEntity.Caster)
                                    {
                                        this.Accuracy = power.Accuracy;
                                        break;
                                    }
                                }
                            }
                        }
                        if (this.AbsorbSummonEffects)
                        {
                            foreach (int index3 in nPowerset)
                            {
                                if (index3 >= 0 && index3 < DatabaseAPI.Database.Powersets.Length)
                                {
                                    foreach (IPower power2 in DatabaseAPI.Database.Powersets[index3].Powers)
                                    {
                                        int[] array2 = this.AbsorbEffects(power2, effect.Duration, effect.DelayedTime, DatabaseAPI.Database.Classes[DatabaseAPI.Database.Entities[nSummon].nClassID], stacking, false, -1, -1);
                                        foreach (int absorbEffect in array2)
                                        {
                                            int nSummon2 = power2.Effects[absorbEffect].nSummon;
                                            if (DatabaseAPI.Database.Entities[nSummon2].nPowerset[0] >= 0)
                                            {
                                                foreach (IPower power3 in DatabaseAPI.Database.Powersets[DatabaseAPI.Database.Entities[nSummon2].nPowerset[0]].Powers)
                                                {
                                                    this.AbsorbEffects(power3, effect.Duration, effect.DelayedTime, DatabaseAPI.Database.Classes[DatabaseAPI.Database.Entities[nSummon].nClassID], stacking, false, -1, -1);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
