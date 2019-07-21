
using Base.Display;
using System;
using System.Drawing;
using System.IO;

namespace Base.Data_Classes
{
    public class Archetype : IComparable
    {
        public bool IsModified;
        public bool IsNew;

        public int Idx { get; set; }

        public string DisplayName { get; set; }

        public Enums.eClassType ClassType { get; set; }

        public int Hitpoints { get; set; }

        public float HPCap { get; set; }

        public string DescLong { get; set; }

        public string DescShort { get; set; }

        public float ResCap { get; set; }

        public float RechargeCap { get; set; }

        public float DamageCap { get; set; }

        public float RegenCap { get; set; }

        public float RecoveryCap { get; set; }

        public string[] Origin { get; set; }

        public int[] Primary { get; set; }

        public int[] Secondary { get; set; }

        public int[] Ancillary { get; set; }

        public float PerceptionCap { get; set; }

        public string ClassName { get; set; }

        public int Column { get; set; }

        public string PrimaryGroup { get; set; }

        public string SecondaryGroup { get; set; }

        public string EpicGroup { get; set; }

        public string PoolGroup { get; set; }

        public bool Playable { get; set; }

        public float BaseRecovery { get; set; }

        public float BaseRegen { get; set; }

        public float BaseThreat { get; set; }

        public bool Hero
        {
            get
            {
                return this.ClassType == Enums.eClassType.Hero || this.ClassType == Enums.eClassType.HeroEpic;
            }
        }

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
            this.Ancillary = Array<int>.Empty();
            this.Secondary = Array<int>.Empty();
            this.Primary = Array<int>.Empty();
            this.Origin = Array<string>.Empty();
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
            this.Origin = new string[5]
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

        public Archetype(Archetype template)
          : this()
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

        public Archetype(BinaryReader reader)
          : this()
        {
            this.DisplayName = reader.ReadString();
            this.Hitpoints = reader.ReadInt32();
            this.HPCap = reader.ReadSingle();
            this.DescLong = reader.ReadString();
            this.ResCap = reader.ReadSingle();
            int num = reader.ReadInt32();
            this.Origin = new string[num + 1];
            for (int index = 0; index <= num; ++index)
                this.Origin[index] = reader.ReadString();
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
            for (int index = 0; index < this.Origin.Length; ++index)
                writer.Write(this.Origin[index]);
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
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (!(obj is Archetype archetype)) throw new ArgumentException("Comparison failed - Passed object was not an Archetype Class!");
            if (this.Playable & !archetype.Playable)
                return -1;
            if (!this.Playable & archetype.Playable)
                return 1;
            if (this.ClassType == Enums.eClassType.None & archetype.ClassType != Enums.eClassType.None)
                return 1;
            if (this.ClassType != Enums.eClassType.None & archetype.ClassType == Enums.eClassType.None)
                return -1;
            if (this.ClassType > archetype.ClassType)
                return 1;
            if (this.ClassType < archetype.ClassType)
                return -1;
            int classNameMatch = string.Compare(this.ClassName, archetype.ClassName, StringComparison.OrdinalIgnoreCase);
            if (classNameMatch != 0) return classNameMatch;
            if (this.Column > archetype.Column) return 1;
            return this.Column < archetype.Column ? 1 : 0;
        }

        public PopUp.PopupData PopInfo()
        {
            PopUp.PopupData popupData = new PopUp.PopupData();
            int index1 = popupData.Add(null);
            popupData.Sections[index1].Add(this.DisplayName, PopUp.Colors.Title, 1.25f, FontStyle.Bold, 0);
            popupData.Sections[index1].Add(this.DescShort, PopUp.Colors.Effect, 1f, FontStyle.Bold, 0);
            popupData.Sections[index1].Add(this.DescLong, PopUp.Colors.Text, 0.9f, FontStyle.Bold, 1);
            int index2 = popupData.Add(null);
            popupData.Sections[index2].Add("You can't change archetype once a build has been started.\nIf you want to pick a different archetype, you need to clear the current build and start a new one.", PopUp.Colors.Effect, 0.9f, FontStyle.Bold, 0);
            return popupData;
        }

        public bool UpdateFromCSV(string csv)
        {
            if (string.IsNullOrEmpty(csv))
                return false;

            string[] array = CSV.ToArray(csv);
            if (array.Length < 11)
                return false;

            this.ClassName = array[0];
            this.Column = int.Parse(array[1]) - 2;
            this.DisplayName = array[2];
            this.DescLong = array[3];
            this.Origin = array[4].Split(Convert.ToChar(" "));
            string str = array[5];
            if (str.IndexOf("KHELDIAN HERO", StringComparison.OrdinalIgnoreCase) > -1)
                this.ClassType = Enums.eClassType.HeroEpic;
            else if (str.IndexOf("ARACHNOSSOLDIER VILLAIN", StringComparison.OrdinalIgnoreCase) > -1 || str.IndexOf("ARACHNOSWIDOW VILLAIN", StringComparison.OrdinalIgnoreCase) > -1)
                this.ClassType = Enums.eClassType.VillainEpic;
            else if (str.IndexOf("HERO", StringComparison.OrdinalIgnoreCase) > -1)
                this.ClassType = Enums.eClassType.Hero;
            else if (str.IndexOf("VILLAIN", StringComparison.OrdinalIgnoreCase) > -1)
                this.ClassType = Enums.eClassType.Villain;
            this.Playable = !str.IsNullOrWhiteSpace();
            this.DescShort = array[6];
            this.PrimaryGroup = array[8];
            this.SecondaryGroup = array[9];
            this.PoolGroup = array[10];
            return true;
        }
    }
}
