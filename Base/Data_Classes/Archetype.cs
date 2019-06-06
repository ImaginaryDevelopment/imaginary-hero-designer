using System;
using System.Drawing;
using System.IO;
using Base.Display;

namespace Base.Data_Classes
{

    public class Archetype : IComparable
    {

        // (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        // (set) Token: 0x06000002 RID: 2 RVA: 0x00002067 File Offset: 0x00000267
        public int Idx { get; set; }


        // (get) Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
        // (set) Token: 0x06000004 RID: 4 RVA: 0x00002087 File Offset: 0x00000287
        public string DisplayName { get; set; }


        // (get) Token: 0x06000005 RID: 5 RVA: 0x00002090 File Offset: 0x00000290
        // (set) Token: 0x06000006 RID: 6 RVA: 0x000020A7 File Offset: 0x000002A7
        public Enums.eClassType ClassType { get; set; }


        // (get) Token: 0x06000007 RID: 7 RVA: 0x000020B0 File Offset: 0x000002B0
        // (set) Token: 0x06000008 RID: 8 RVA: 0x000020C7 File Offset: 0x000002C7
        public int Hitpoints { get; set; }


        // (get) Token: 0x06000009 RID: 9 RVA: 0x000020D0 File Offset: 0x000002D0
        // (set) Token: 0x0600000A RID: 10 RVA: 0x000020E7 File Offset: 0x000002E7
        public float HPCap { get; set; }


        // (get) Token: 0x0600000B RID: 11 RVA: 0x000020F0 File Offset: 0x000002F0
        // (set) Token: 0x0600000C RID: 12 RVA: 0x00002107 File Offset: 0x00000307
        public string DescLong { get; set; }


        // (get) Token: 0x0600000D RID: 13 RVA: 0x00002110 File Offset: 0x00000310
        // (set) Token: 0x0600000E RID: 14 RVA: 0x00002127 File Offset: 0x00000327
        public string DescShort { get; set; }


        // (get) Token: 0x0600000F RID: 15 RVA: 0x00002130 File Offset: 0x00000330
        // (set) Token: 0x06000010 RID: 16 RVA: 0x00002147 File Offset: 0x00000347
        public float ResCap { get; set; }


        // (get) Token: 0x06000011 RID: 17 RVA: 0x00002150 File Offset: 0x00000350
        // (set) Token: 0x06000012 RID: 18 RVA: 0x00002167 File Offset: 0x00000367
        public float RechargeCap { get; set; }


        // (get) Token: 0x06000013 RID: 19 RVA: 0x00002170 File Offset: 0x00000370
        // (set) Token: 0x06000014 RID: 20 RVA: 0x00002187 File Offset: 0x00000387
        public float DamageCap { get; set; }


        // (get) Token: 0x06000015 RID: 21 RVA: 0x00002190 File Offset: 0x00000390
        // (set) Token: 0x06000016 RID: 22 RVA: 0x000021A7 File Offset: 0x000003A7
        public float RegenCap { get; set; }


        // (get) Token: 0x06000017 RID: 23 RVA: 0x000021B0 File Offset: 0x000003B0
        // (set) Token: 0x06000018 RID: 24 RVA: 0x000021C7 File Offset: 0x000003C7
        public float RecoveryCap { get; set; }


        // (get) Token: 0x06000019 RID: 25 RVA: 0x000021D0 File Offset: 0x000003D0
        // (set) Token: 0x0600001A RID: 26 RVA: 0x000021E7 File Offset: 0x000003E7
        public string[] Origin { get; set; }


        // (get) Token: 0x0600001B RID: 27 RVA: 0x000021F0 File Offset: 0x000003F0
        // (set) Token: 0x0600001C RID: 28 RVA: 0x00002207 File Offset: 0x00000407
        public int[] Primary { get; set; }


        // (get) Token: 0x0600001D RID: 29 RVA: 0x00002210 File Offset: 0x00000410
        // (set) Token: 0x0600001E RID: 30 RVA: 0x00002227 File Offset: 0x00000427
        public int[] Secondary { get; set; }


        // (get) Token: 0x0600001F RID: 31 RVA: 0x00002230 File Offset: 0x00000430
        // (set) Token: 0x06000020 RID: 32 RVA: 0x00002247 File Offset: 0x00000447
        public int[] Ancillary { get; set; }


        // (get) Token: 0x06000021 RID: 33 RVA: 0x00002250 File Offset: 0x00000450
        // (set) Token: 0x06000022 RID: 34 RVA: 0x00002267 File Offset: 0x00000467
        public float PerceptionCap { get; set; }


        // (get) Token: 0x06000023 RID: 35 RVA: 0x00002270 File Offset: 0x00000470
        // (set) Token: 0x06000024 RID: 36 RVA: 0x00002287 File Offset: 0x00000487
        public string ClassName { get; set; }


        // (get) Token: 0x06000025 RID: 37 RVA: 0x00002290 File Offset: 0x00000490
        // (set) Token: 0x06000026 RID: 38 RVA: 0x000022A7 File Offset: 0x000004A7
        public int Column { get; set; }


        // (get) Token: 0x06000027 RID: 39 RVA: 0x000022B0 File Offset: 0x000004B0
        // (set) Token: 0x06000028 RID: 40 RVA: 0x000022C7 File Offset: 0x000004C7
        public string PrimaryGroup { get; set; }


        // (get) Token: 0x06000029 RID: 41 RVA: 0x000022D0 File Offset: 0x000004D0
        // (set) Token: 0x0600002A RID: 42 RVA: 0x000022E7 File Offset: 0x000004E7
        public string SecondaryGroup { get; set; }


        // (get) Token: 0x0600002B RID: 43 RVA: 0x000022F0 File Offset: 0x000004F0
        // (set) Token: 0x0600002C RID: 44 RVA: 0x00002307 File Offset: 0x00000507
        public string EpicGroup { get; set; }


        // (get) Token: 0x0600002D RID: 45 RVA: 0x00002310 File Offset: 0x00000510
        // (set) Token: 0x0600002E RID: 46 RVA: 0x00002327 File Offset: 0x00000527
        public string PoolGroup { get; set; }


        // (get) Token: 0x0600002F RID: 47 RVA: 0x00002330 File Offset: 0x00000530
        // (set) Token: 0x06000030 RID: 48 RVA: 0x00002347 File Offset: 0x00000547
        public bool Playable { get; set; }


        // (get) Token: 0x06000031 RID: 49 RVA: 0x00002350 File Offset: 0x00000550
        // (set) Token: 0x06000032 RID: 50 RVA: 0x00002367 File Offset: 0x00000567
        public float BaseRecovery { get; set; }


        // (get) Token: 0x06000033 RID: 51 RVA: 0x00002370 File Offset: 0x00000570
        // (set) Token: 0x06000034 RID: 52 RVA: 0x00002387 File Offset: 0x00000587
        public float BaseRegen { get; set; }


        // (get) Token: 0x06000035 RID: 53 RVA: 0x00002390 File Offset: 0x00000590
        // (set) Token: 0x06000036 RID: 54 RVA: 0x000023A7 File Offset: 0x000005A7
        public float BaseThreat { get; set; }


        // (get) Token: 0x06000037 RID: 55 RVA: 0x000023B0 File Offset: 0x000005B0
        public bool Hero
        {
            get
            {
                return this.ClassType == Enums.eClassType.Hero || this.ClassType == Enums.eClassType.HeroEpic;
            }
        }


        // (get) Token: 0x06000038 RID: 56 RVA: 0x000023D8 File Offset: 0x000005D8
        public bool Epic
        {
            get
            {
                return this.ClassType == Enums.eClassType.HeroEpic || this.ClassType == Enums.eClassType.VillainEpic;
            }
        }


        public Archetype()
        {
            this.BaseThreat = 1f;
            this.BaseRegen = 1f;
            this.BaseRecovery = 1.67f;
            this.Playable = true;
            this.PoolGroup = "POOL";
            this.EpicGroup = "EPIC";
            this.SecondaryGroup = string.Empty;
            this.PrimaryGroup = string.Empty;
            this.ClassName = string.Empty;
            this.PerceptionCap = 1153f;
            this.Ancillary = new int[0];
            this.Secondary = new int[0];
            this.Primary = new int[0];
            this.Origin = new string[0];
            this.RecoveryCap = 5f;
            this.RegenCap = 20f;
            this.DamageCap = 4f;
            this.RechargeCap = 5f;
            this.ResCap = 90f;
            this.DescShort = string.Empty;
            this.DescLong = string.Empty;
            this.HPCap = 5000f;
            this.Hitpoints = 5000;
            this.ClassType = Enums.eClassType.None;
            this.DisplayName = string.Empty;
            this.Origin = new string[]
            {
                "Magic",
                "Mutation",
                "Natural",
                "Science",
                "Technology"
            };
            this.DisplayName = "New Archetype";
            this.ClassName = "NewClass";
        }


        public Archetype(Archetype template) : this()
        {
            this.Idx = template.Idx;
            this.DisplayName = template.DisplayName;
            this.HPCap = template.HPCap;
            this.Hitpoints = template.Hitpoints;
            this.DescLong = template.DescLong;
            this.DescShort = template.DescShort;
            this.ResCap = template.ResCap;
            this.Origin = (string[])template.Origin.Clone();
            this.Primary = (int[])template.Primary.Clone();
            this.Secondary = (int[])template.Secondary.Clone();
            this.Ancillary = (int[])template.Ancillary.Clone();
            this.ClassName = template.ClassName;
            this.ClassType = template.ClassType;
            this.Column = template.Column;
            this.PrimaryGroup = template.PrimaryGroup;
            this.SecondaryGroup = template.SecondaryGroup;
            this.Playable = template.Playable;
            this.RechargeCap = template.RechargeCap;
            this.DamageCap = template.DamageCap;
            this.RecoveryCap = template.RecoveryCap;
            this.RegenCap = template.RegenCap;
            this.BaseRecovery = template.BaseRecovery;
            this.BaseRegen = template.BaseRegen;
            this.BaseThreat = template.BaseThreat;
            this.PerceptionCap = template.PerceptionCap;
        }


        public Archetype(BinaryReader reader) : this()
        {
            this.DisplayName = reader.ReadString();
            this.Hitpoints = reader.ReadInt32();
            this.HPCap = reader.ReadSingle();
            this.DescLong = reader.ReadString();
            this.ResCap = reader.ReadSingle();
            int num = reader.ReadInt32();
            this.Origin = new string[num + 1];
            for (int index = 0; index <= num; index++)
            {
                this.Origin[index] = reader.ReadString();
            }
            this.ClassName = reader.ReadString();
            this.ClassType = (Enums.eClassType)reader.ReadInt32();
            this.Column = reader.ReadInt32();
            this.DescShort = reader.ReadString();
            this.PrimaryGroup = reader.ReadString();
            this.SecondaryGroup = reader.ReadString();
            this.Playable = reader.ReadBoolean();
            this.RechargeCap = reader.ReadSingle();
            this.DamageCap = reader.ReadSingle();
            this.RecoveryCap = reader.ReadSingle();
            this.RegenCap = reader.ReadSingle();
            this.BaseRecovery = reader.ReadSingle();
            this.BaseRegen = reader.ReadSingle();
            this.BaseThreat = reader.ReadSingle();
            this.PerceptionCap = reader.ReadSingle();
        }


        public void StoreTo(ref BinaryWriter writer)
        {
            writer.Write(this.DisplayName);
            writer.Write(this.Hitpoints);
            writer.Write(this.HPCap);
            writer.Write(this.DescLong);
            writer.Write(this.ResCap);
            writer.Write(this.Origin.Length - 1);
            for (int index = 0; index < this.Origin.Length; index++)
            {
                writer.Write(this.Origin[index]);
            }
            writer.Write(this.ClassName);
            writer.Write((int)this.ClassType);
            writer.Write(this.Column);
            writer.Write(this.DescShort);
            writer.Write(this.PrimaryGroup);
            writer.Write(this.SecondaryGroup);
            writer.Write(this.Playable);
            writer.Write(this.RechargeCap);
            writer.Write(this.DamageCap);
            writer.Write(this.RecoveryCap);
            writer.Write(this.RegenCap);
            writer.Write(this.BaseRecovery);
            writer.Write(this.BaseRegen);
            writer.Write(this.BaseThreat);
            writer.Write(this.PerceptionCap);
        }


        public int CompareTo(object obj)
        {
            Archetype archetype = obj as Archetype;
            if (archetype == null)
            {
                throw new ArgumentException("Comparison failed - Passed object was not an Archetype Class!");
            }
            int num;
            if (this.Playable & !archetype.Playable)
            {
                num = -1;
            }
            else if (!this.Playable & archetype.Playable)
            {
                num = 1;
            }
            else if (this.ClassType == Enums.eClassType.None & archetype.ClassType != Enums.eClassType.None)
            {
                num = 1;
            }
            else if (this.ClassType != Enums.eClassType.None & archetype.ClassType == Enums.eClassType.None)
            {
                num = -1;
            }
            else if (this.ClassType > archetype.ClassType)
            {
                num = 1;
            }
            else if (this.ClassType < archetype.ClassType)
            {
                num = -1;
            }
            else
            {
                int num2 = string.Compare(this.ClassName, archetype.ClassName, StringComparison.OrdinalIgnoreCase);
                if (num2 != 0)
                {
                    num = num2;
                }
                else if (this.Column > archetype.Column)
                {
                    num = 1;
                }
                else if (this.Column >= archetype.Column)
                {
                    num = 0;
                }
                else
                {
                    num = 1;
                }
            }
            return num;
        }


        public PopUp.PopupData PopInfo()
        {
            PopUp.PopupData popupData = default(PopUp.PopupData);
            int index2 = popupData.Add(null);
            popupData.Sections[index2].Add(this.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            popupData.Sections[index2].Add(this.DescShort, PopUp.Colors.Effect, 1f, FontStyle.Bold, 0);
            popupData.Sections[index2].Add(this.DescLong, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
            index2 = popupData.Add(null);
            popupData.Sections[index2].Add("You can't change archetype once a build has been started.\nIf you want to pick a different archetype, you need to clear the current build and start a new one.", PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
            return popupData;
        }


        public bool UpdateFromCSV(string csv)
        {
            bool flag;
            if (string.IsNullOrEmpty(csv))
            {
                flag = false;
            }
            else
            {
                string[] array = CSV.ToArray(csv);
                if (array.Length < 11)
                {
                    flag = false;
                }
                else
                {
                    this.ClassName = array[0];
                    this.Column = int.Parse(array[1]) - 2;
                    this.DisplayName = array[2];
                    this.DescLong = array[3];
                    this.Origin = array[4].Split(new char[]
                    {
                        Convert.ToChar(" ")
                    });
                    string str = array[5];
                    if (str.IndexOf("KHELDIAN HERO", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.ClassType = Enums.eClassType.HeroEpic;
                    }
                    else if (str.IndexOf("ARACHNOSSOLDIER VILLAIN", StringComparison.OrdinalIgnoreCase) > -1 || str.IndexOf("ARACHNOSWIDOW VILLAIN", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.ClassType = Enums.eClassType.VillainEpic;
                    }
                    else if (str.IndexOf("HERO", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.ClassType = Enums.eClassType.Hero;
                    }
                    else if (str.IndexOf("VILLAIN", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        this.ClassType = Enums.eClassType.Villain;
                    }
                    this.Playable = (str != string.Empty);
                    this.DescShort = array[6];
                    this.PrimaryGroup = array[8];
                    this.SecondaryGroup = array[9];
                    this.PoolGroup = array[10];
                    flag = true;
                }
            }
            return flag;
        }


        public bool IsModified;


        public bool IsNew;
    }
}
