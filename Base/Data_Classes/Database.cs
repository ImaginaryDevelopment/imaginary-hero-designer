using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Base.Data_Classes
{

    public sealed class Database : IDatabase
    {

    
    
        public float Version { get; set; }


    
    
        public int Issue { get; set; }


    
    
        public DateTime Date { get; set; }


    
    
        public IPower[] Power { get; set; }


    
    
        public Enums.VersionData PowerVersion
        {
            get
            {
                return this._powerVersion;
            }
            set
            {
                this._powerVersion = value;
            }
        }


    
    
        public Enums.VersionData PowerEffectVersion
        {
            get
            {
                return this._powerEffectVersion;
            }
            set
            {
                this._powerEffectVersion = value;
            }
        }


    
    
        public Enums.VersionData PowerLevelVersion
        {
            get
            {
                return this._powerLevelVersion;
            }
            set
            {
                this._powerLevelVersion = value;
            }
        }


    
    
        public IPowerset[] Powersets { get; set; }


    
    
        public Enums.VersionData PowersetVersion
        {
            get
            {
                return this._powersetVersion;
            }
            set
            {
                this._powersetVersion = value;
            }
        }


    
    
        public Archetype[] Classes { get; set; }


    
    
        public Enums.VersionData ArchetypeVersion
        {
            get
            {
                return this._archetypeVersion;
            }
            set
            {
                this._archetypeVersion = value;
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
                return this._ioAssignmentVersion;
            }
            set
            {
                this._ioAssignmentVersion = value;
            }
        }


    
    
        public SummonedEntity[] Entities
        {
            get
            {
                return this._entities;
            }
            set
            {
                this._entities = value;
            }
        }


    
    
        public Modifiers AttribMods { get; set; }


    
    
        public LevelMap[] Levels { get; set; }


    
    
        public int[] Levels_MainPowers { get; set; }


    
    
        public ArrayList EffectIds
        {
            get
            {
                return this._effectIds;
            }
            set
            {
                this._effectIds = value;
            }
        }


    
        public static Database Instance
        {
            get
            {
                return Database._instance;
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
            this.Entities = new SummonedEntity[reader.ReadInt32() + 1];
            for (int index = 0; index <= this.Entities.Length - 1; index++)
            {
                this.Entities[index] = new SummonedEntity(reader);
            }
        }


        public void StoreEntities(BinaryWriter writer)
        {
            writer.Write(this.Entities.Length - 1);
            for (int index = 0; index <= this.Entities.Length - 1; index++)
            {
                this.Entities[index].StoreTo(writer);
            }
        }


        private Enums.VersionData _powerVersion = new Enums.VersionData();


        private Enums.VersionData _powerEffectVersion = new Enums.VersionData();


        private Enums.VersionData _powerLevelVersion = new Enums.VersionData();


        private Enums.VersionData _powersetVersion = new Enums.VersionData();


        private Enums.VersionData _archetypeVersion = new Enums.VersionData();


        private Enums.VersionData _ioAssignmentVersion = new Enums.VersionData();


        private SummonedEntity[] _entities = new SummonedEntity[0];


        private ArrayList _effectIds = new ArrayList();


        private static readonly Database _instance = new Database();
    }
}
