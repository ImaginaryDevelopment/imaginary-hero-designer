
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Base.Data_Classes
{
    public sealed class Database : IDatabase
    {
        static readonly Database _instance = new Database();

        Enums.VersionData _powerVersion = new Enums.VersionData();

        Enums.VersionData _powerEffectVersion = new Enums.VersionData();

        Enums.VersionData _powerLevelVersion = new Enums.VersionData();

        Enums.VersionData _powersetVersion = new Enums.VersionData();

        Enums.VersionData _archetypeVersion = new Enums.VersionData();

        Enums.VersionData _ioAssignmentVersion = new Enums.VersionData();

        SummonedEntity[] _entities = new SummonedEntity[0];

        ArrayList _effectIds = new ArrayList();


        public float Version { get; set; }

        public int Issue { get; set; }

        public DateTime Date { get; set; }

        public IPower[] Power { get; set; }

        public Enums.VersionData PowerVersion
        {
            get
            {
                return _powerVersion;
            }
            set
            {
                _powerVersion = value;
            }
        }

        public Enums.VersionData PowerEffectVersion
        {
            get
            {
                return _powerEffectVersion;
            }
            set
            {
                _powerEffectVersion = value;
            }
        }

        public Enums.VersionData PowerLevelVersion
        {
            get
            {
                return _powerLevelVersion;
            }
            set
            {
                _powerLevelVersion = value;
            }
        }

        public IPowerset[] Powersets { get; set; }

        public Enums.VersionData PowersetVersion
        {
            get
            {
                return _powersetVersion;
            }
            set
            {
                _powersetVersion = value;
            }
        }

        public Archetype[] Classes { get; set; }

        public Enums.VersionData ArchetypeVersion
        {
            get
            {
                return _archetypeVersion;
            }
            set
            {
                _archetypeVersion = value;
            }
        }

        public IEnhancement[] Enhancements { get; set; }

        public EnhancementSetCollection EnhancementSets { get; set; }

        public Enums.sEnhClass[] EnhancementClasses { get; set; }

        public Recipe[] Recipes { get; set; }

        public DateTime RecipeRevisionDate { get; set; }

        public string RecipeSource1 { get; set; }

        public string RecipeSource2 { get; set; }

        public Salvage[] Salvage { get; set; }

        public List<Origin> Origins { get; set; }

        public IDictionary<string, PowersetGroup> PowersetGroups { get; set; }

        public bool Loading { get; set; }

        public object I9 { get; set; }

        public Enums.VersionData IOAssignmentVersion
        {
            get
            {
                return _ioAssignmentVersion;
            }
            set
            {
                _ioAssignmentVersion = value;
            }
        }

        public SummonedEntity[] Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }

        public Modifiers AttribMods { get; set; }

        public LevelMap[] Levels { get; set; }

        public int[] Levels_MainPowers { get; set; }

        public ArrayList EffectIds
        {
            get
            {
                return _effectIds;
            }
            set
            {
                _effectIds = value;
            }
        }

        public static Database Instance
        {
            get
            {
                return _instance;
            }
        }

        public float VersionEnhDb { get; set; }

        public float[][] MultED { get; set; }

        public float[][] MultTO { get; set; }

        public float[][] MultDO { get; set; }

        public float[][] MultSO { get; set; }

        public float[][] MultHO { get; set; }

        public float[][] MultIO { get; set; }

        public string[] SetTypeStringLong { get; set; }

        public string[] SetTypeStringShort { get; set; }

        public string[] EnhGradeStringLong { get; set; }

        public string[] EnhGradeStringShort { get; set; }

        public string[] SpecialEnhStringLong { get; set; }

        public string[] SpecialEnhStringShort { get; set; }

        public string[] MutexList { get; set; }

        public void LoadEntities(BinaryReader reader)
        {
            Entities = new SummonedEntity[reader.ReadInt32() + 1];
            for (int index = 0; index <= Entities.Length - 1; ++index)
                Entities[index] = new SummonedEntity(reader);
        }

        public void StoreEntities(BinaryWriter writer)
        {
            writer.Write(Entities.Length - 1);
            for (int index = 0; index <= Entities.Length - 1; ++index)
                Entities[index].StoreTo(writer);
        }
    }
}
