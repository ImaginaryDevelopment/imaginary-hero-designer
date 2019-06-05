using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Base.Data_Classes
{
	// Token: 0x02000006 RID: 6
	public sealed class Database : IDatabase
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000665C File Offset: 0x0000485C
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00006673 File Offset: 0x00004873
		public float Version { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000667C File Offset: 0x0000487C
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00006693 File Offset: 0x00004893
		public int Issue { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000669C File Offset: 0x0000489C
		// (set) Token: 0x06000148 RID: 328 RVA: 0x000066B3 File Offset: 0x000048B3
		public DateTime Date { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000149 RID: 329 RVA: 0x000066BC File Offset: 0x000048BC
		// (set) Token: 0x0600014A RID: 330 RVA: 0x000066D3 File Offset: 0x000048D3
		public IPower[] Power { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600014B RID: 331 RVA: 0x000066DC File Offset: 0x000048DC
		// (set) Token: 0x0600014C RID: 332 RVA: 0x000066F4 File Offset: 0x000048F4
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00006700 File Offset: 0x00004900
		// (set) Token: 0x0600014E RID: 334 RVA: 0x00006718 File Offset: 0x00004918
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

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00006724 File Offset: 0x00004924
		// (set) Token: 0x06000150 RID: 336 RVA: 0x0000673C File Offset: 0x0000493C
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

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00006748 File Offset: 0x00004948
		// (set) Token: 0x06000152 RID: 338 RVA: 0x0000675F File Offset: 0x0000495F
		public IPowerset[] Powersets { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00006768 File Offset: 0x00004968
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00006780 File Offset: 0x00004980
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

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0000678C File Offset: 0x0000498C
		// (set) Token: 0x06000156 RID: 342 RVA: 0x000067A3 File Offset: 0x000049A3
		public Archetype[] Classes { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000067AC File Offset: 0x000049AC
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000067C4 File Offset: 0x000049C4
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

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000067D0 File Offset: 0x000049D0
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000067E7 File Offset: 0x000049E7
		public IEnhancement[] Enhancements { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600015B RID: 347 RVA: 0x000067F0 File Offset: 0x000049F0
		// (set) Token: 0x0600015C RID: 348 RVA: 0x00006807 File Offset: 0x00004A07
		public EnhancementSetCollection EnhancementSets { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00006810 File Offset: 0x00004A10
		// (set) Token: 0x0600015E RID: 350 RVA: 0x00006827 File Offset: 0x00004A27
		public Enums.sEnhClass[] EnhancementClasses { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00006830 File Offset: 0x00004A30
		// (set) Token: 0x06000160 RID: 352 RVA: 0x00006847 File Offset: 0x00004A47
		public Recipe[] Recipes { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00006850 File Offset: 0x00004A50
		// (set) Token: 0x06000162 RID: 354 RVA: 0x00006867 File Offset: 0x00004A67
		public DateTime RecipeRevisionDate { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00006870 File Offset: 0x00004A70
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00006887 File Offset: 0x00004A87
		public string RecipeSource1 { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006890 File Offset: 0x00004A90
		// (set) Token: 0x06000166 RID: 358 RVA: 0x000068A7 File Offset: 0x00004AA7
		public string RecipeSource2 { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000167 RID: 359 RVA: 0x000068B0 File Offset: 0x00004AB0
		// (set) Token: 0x06000168 RID: 360 RVA: 0x000068C7 File Offset: 0x00004AC7
		public Salvage[] Salvage { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000068D0 File Offset: 0x00004AD0
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000068E7 File Offset: 0x00004AE7
		public List<Origin> Origins { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600016B RID: 363 RVA: 0x000068F0 File Offset: 0x00004AF0
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00006907 File Offset: 0x00004B07
		public IDictionary<string, PowersetGroup> PowersetGroups { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00006910 File Offset: 0x00004B10
		// (set) Token: 0x0600016E RID: 366 RVA: 0x00006927 File Offset: 0x00004B27
		public bool Loading { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00006930 File Offset: 0x00004B30
		// (set) Token: 0x06000170 RID: 368 RVA: 0x00006947 File Offset: 0x00004B47
		public object I9 { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00006950 File Offset: 0x00004B50
		// (set) Token: 0x06000172 RID: 370 RVA: 0x00006968 File Offset: 0x00004B68
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

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00006974 File Offset: 0x00004B74
		// (set) Token: 0x06000174 RID: 372 RVA: 0x0000698C File Offset: 0x00004B8C
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

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000175 RID: 373 RVA: 0x00006998 File Offset: 0x00004B98
		// (set) Token: 0x06000176 RID: 374 RVA: 0x000069AF File Offset: 0x00004BAF
		public Modifiers AttribMods { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000177 RID: 375 RVA: 0x000069B8 File Offset: 0x00004BB8
		// (set) Token: 0x06000178 RID: 376 RVA: 0x000069CF File Offset: 0x00004BCF
		public LevelMap[] Levels { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000179 RID: 377 RVA: 0x000069D8 File Offset: 0x00004BD8
		// (set) Token: 0x0600017A RID: 378 RVA: 0x000069EF File Offset: 0x00004BEF
		public int[] Levels_MainPowers { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600017B RID: 379 RVA: 0x000069F8 File Offset: 0x00004BF8
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00006A10 File Offset: 0x00004C10
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

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00006A1C File Offset: 0x00004C1C
		public static Database Instance
		{
			get
			{
				return Database._instance;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00006A34 File Offset: 0x00004C34
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00006A4B File Offset: 0x00004C4B
		public float VersionEnhDb { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00006A54 File Offset: 0x00004C54
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00006A6B File Offset: 0x00004C6B
		public float[][] MultED { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00006A74 File Offset: 0x00004C74
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00006A8B File Offset: 0x00004C8B
		public float[][] MultTO { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00006A94 File Offset: 0x00004C94
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00006AAB File Offset: 0x00004CAB
		public float[][] MultDO { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00006AB4 File Offset: 0x00004CB4
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00006ACB File Offset: 0x00004CCB
		public float[][] MultSO { get; set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00006AD4 File Offset: 0x00004CD4
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00006AEB File Offset: 0x00004CEB
		public float[][] MultHO { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00006AF4 File Offset: 0x00004CF4
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00006B0B File Offset: 0x00004D0B
		public float[][] MultIO { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00006B14 File Offset: 0x00004D14
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00006B2B File Offset: 0x00004D2B
		public string[] SetTypeStringLong { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00006B34 File Offset: 0x00004D34
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00006B4B File Offset: 0x00004D4B
		public string[] SetTypeStringShort { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00006B54 File Offset: 0x00004D54
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00006B6B File Offset: 0x00004D6B
		public string[] EnhGradeStringLong { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00006B74 File Offset: 0x00004D74
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00006B8B File Offset: 0x00004D8B
		public string[] EnhGradeStringShort { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00006B94 File Offset: 0x00004D94
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00006BAB File Offset: 0x00004DAB
		public string[] SpecialEnhStringLong { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00006BB4 File Offset: 0x00004DB4
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00006BCB File Offset: 0x00004DCB
		public string[] SpecialEnhStringShort { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00006BD4 File Offset: 0x00004DD4
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00006BEB File Offset: 0x00004DEB
		public string[] MutexList { get; set; }

		// Token: 0x0600019A RID: 410 RVA: 0x00006BF4 File Offset: 0x00004DF4
		public void LoadEntities(BinaryReader reader)
		{
			this.Entities = new SummonedEntity[reader.ReadInt32() + 1];
			for (int index = 0; index <= this.Entities.Length - 1; index++)
			{
				this.Entities[index] = new SummonedEntity(reader);
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006C44 File Offset: 0x00004E44
		public void StoreEntities(BinaryWriter writer)
		{
			writer.Write(this.Entities.Length - 1);
			for (int index = 0; index <= this.Entities.Length - 1; index++)
			{
				this.Entities[index].StoreTo(writer);
			}
		}

		// Token: 0x04000058 RID: 88
		private Enums.VersionData _powerVersion = new Enums.VersionData();

		// Token: 0x04000059 RID: 89
		private Enums.VersionData _powerEffectVersion = new Enums.VersionData();

		// Token: 0x0400005A RID: 90
		private Enums.VersionData _powerLevelVersion = new Enums.VersionData();

		// Token: 0x0400005B RID: 91
		private Enums.VersionData _powersetVersion = new Enums.VersionData();

		// Token: 0x0400005C RID: 92
		private Enums.VersionData _archetypeVersion = new Enums.VersionData();

		// Token: 0x0400005D RID: 93
		private Enums.VersionData _ioAssignmentVersion = new Enums.VersionData();

		// Token: 0x0400005E RID: 94
		private SummonedEntity[] _entities = new SummonedEntity[0];

		// Token: 0x0400005F RID: 95
		private ArrayList _effectIds = new ArrayList();

		// Token: 0x04000060 RID: 96
		private static readonly Database _instance = new Database();
	}
}
