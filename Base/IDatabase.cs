using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Base.Data_Classes;

// Token: 0x02000005 RID: 5
public interface IDatabase
{
	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060000EB RID: 235
	// (set) Token: 0x060000EC RID: 236
	float Version { get; set; }

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060000ED RID: 237
	// (set) Token: 0x060000EE RID: 238
	int Issue { get; set; }

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060000EF RID: 239
	// (set) Token: 0x060000F0 RID: 240
	DateTime Date { get; set; }

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060000F1 RID: 241
	// (set) Token: 0x060000F2 RID: 242
	IPower[] Power { get; set; }

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060000F3 RID: 243
	// (set) Token: 0x060000F4 RID: 244
	Enums.VersionData PowerVersion { get; set; }

	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060000F5 RID: 245
	// (set) Token: 0x060000F6 RID: 246
	Enums.VersionData PowerEffectVersion { get; set; }

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060000F7 RID: 247
	// (set) Token: 0x060000F8 RID: 248
	Enums.VersionData PowerLevelVersion { get; set; }

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x060000F9 RID: 249
	// (set) Token: 0x060000FA RID: 250
	IPowerset[] Powersets { get; set; }

	// Token: 0x17000067 RID: 103
	// (get) Token: 0x060000FB RID: 251
	// (set) Token: 0x060000FC RID: 252
	Enums.VersionData PowersetVersion { get; set; }

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x060000FD RID: 253
	// (set) Token: 0x060000FE RID: 254
	Archetype[] Classes { get; set; }

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x060000FF RID: 255
	// (set) Token: 0x06000100 RID: 256
	Enums.VersionData ArchetypeVersion { get; set; }

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x06000101 RID: 257
	// (set) Token: 0x06000102 RID: 258
	IDictionary<string, PowersetGroup> PowersetGroups { get; set; }

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x06000103 RID: 259
	// (set) Token: 0x06000104 RID: 260
	bool Loading { get; set; }

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000105 RID: 261
	// (set) Token: 0x06000106 RID: 262
	object I9 { get; set; }

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x06000107 RID: 263
	// (set) Token: 0x06000108 RID: 264
	Enums.VersionData IOAssignmentVersion { get; set; }

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x06000109 RID: 265
	// (set) Token: 0x0600010A RID: 266
	Modifiers AttribMods { get; set; }

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x0600010B RID: 267
	// (set) Token: 0x0600010C RID: 268
	SummonedEntity[] Entities { get; set; }

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x0600010D RID: 269
	// (set) Token: 0x0600010E RID: 270
	LevelMap[] Levels { get; set; }

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x0600010F RID: 271
	// (set) Token: 0x06000110 RID: 272
	int[] Levels_MainPowers { get; set; }

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x06000111 RID: 273
	// (set) Token: 0x06000112 RID: 274
	ArrayList EffectIds { get; set; }

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x06000113 RID: 275
	// (set) Token: 0x06000114 RID: 276
	IEnhancement[] Enhancements { get; set; }

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x06000115 RID: 277
	// (set) Token: 0x06000116 RID: 278
	EnhancementSetCollection EnhancementSets { get; set; }

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x06000117 RID: 279
	// (set) Token: 0x06000118 RID: 280
	Enums.sEnhClass[] EnhancementClasses { get; set; }

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x06000119 RID: 281
	// (set) Token: 0x0600011A RID: 282
	Recipe[] Recipes { get; set; }

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x0600011B RID: 283
	// (set) Token: 0x0600011C RID: 284
	DateTime RecipeRevisionDate { get; set; }

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x0600011D RID: 285
	// (set) Token: 0x0600011E RID: 286
	string RecipeSource1 { get; set; }

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x0600011F RID: 287
	// (set) Token: 0x06000120 RID: 288
	string RecipeSource2 { get; set; }

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000121 RID: 289
	// (set) Token: 0x06000122 RID: 290
	Salvage[] Salvage { get; set; }

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000123 RID: 291
	// (set) Token: 0x06000124 RID: 292
	List<Origin> Origins { get; set; }

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000125 RID: 293
	// (set) Token: 0x06000126 RID: 294
	float VersionEnhDb { get; set; }

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000127 RID: 295
	// (set) Token: 0x06000128 RID: 296
	float[][] MultED { get; set; }

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000129 RID: 297
	// (set) Token: 0x0600012A RID: 298
	float[][] MultTO { get; set; }

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x0600012B RID: 299
	// (set) Token: 0x0600012C RID: 300
	float[][] MultDO { get; set; }

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x0600012D RID: 301
	// (set) Token: 0x0600012E RID: 302
	float[][] MultSO { get; set; }

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x0600012F RID: 303
	// (set) Token: 0x06000130 RID: 304
	float[][] MultHO { get; set; }

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x06000131 RID: 305
	// (set) Token: 0x06000132 RID: 306
	float[][] MultIO { get; set; }

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x06000133 RID: 307
	// (set) Token: 0x06000134 RID: 308
	string[] SetTypeStringLong { get; set; }

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x06000135 RID: 309
	// (set) Token: 0x06000136 RID: 310
	string[] SetTypeStringShort { get; set; }

	// Token: 0x17000085 RID: 133
	// (get) Token: 0x06000137 RID: 311
	// (set) Token: 0x06000138 RID: 312
	string[] EnhGradeStringLong { get; set; }

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x06000139 RID: 313
	// (set) Token: 0x0600013A RID: 314
	string[] EnhGradeStringShort { get; set; }

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x0600013B RID: 315
	// (set) Token: 0x0600013C RID: 316
	string[] SpecialEnhStringLong { get; set; }

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x0600013D RID: 317
	// (set) Token: 0x0600013E RID: 318
	string[] SpecialEnhStringShort { get; set; }

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x0600013F RID: 319
	// (set) Token: 0x06000140 RID: 320
	string[] MutexList { get; set; }

	// Token: 0x06000141 RID: 321
	void LoadEntities(BinaryReader reader);

	// Token: 0x06000142 RID: 322
	void StoreEntities(BinaryWriter writer);
}
