using System;
using System.IO;

// Token: 0x02000007 RID: 7
public interface IEffect : IComparable, ICloneable
{
	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x0600019E RID: 414
	// (set) Token: 0x0600019F RID: 415
	int UniqueID { get; set; }

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x060001A0 RID: 416
	// (set) Token: 0x060001A1 RID: 417
	float Probability { get; set; }

	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x060001A2 RID: 418
	float Mag { get; }

	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x060001A3 RID: 419
	float MagPercent { get; }

	// Token: 0x170000BA RID: 186
	// (get) Token: 0x060001A4 RID: 420
	float Duration { get; }

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x060001A5 RID: 421
	bool DisplayPercentage { get; }

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x060001A6 RID: 422
	// (set) Token: 0x060001A7 RID: 423
	bool VariableModified { get; set; }

	// Token: 0x170000BD RID: 189
	// (get) Token: 0x060001A8 RID: 424
	bool InherentSpecial { get; }

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x060001A9 RID: 425
	// (set) Token: 0x060001AA RID: 426
	float BaseProbability { get; set; }

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x060001AB RID: 427
	// (set) Token: 0x060001AC RID: 428
	bool IgnoreED { get; set; }

	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x060001AD RID: 429
	// (set) Token: 0x060001AE RID: 430
	string Reward { get; set; }

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x060001AF RID: 431
	// (set) Token: 0x060001B0 RID: 432
	string EffectId { get; set; }

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x060001B1 RID: 433
	// (set) Token: 0x060001B2 RID: 434
	string Special { get; set; }

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x060001B3 RID: 435
	// (set) Token: 0x060001B4 RID: 436
	IPower Power { get; set; }

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060001B5 RID: 437
	// (set) Token: 0x060001B6 RID: 438
	IEnhancement Enhancement { get; set; }

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x060001B7 RID: 439
	// (set) Token: 0x060001B8 RID: 440
	int nID { get; set; }

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x060001B9 RID: 441
	// (set) Token: 0x060001BA RID: 442
	Enums.eEffectClass EffectClass { get; set; }

	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x060001BB RID: 443
	// (set) Token: 0x060001BC RID: 444
	Enums.eEffectType EffectType { get; set; }

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x060001BD RID: 445
	// (set) Token: 0x060001BE RID: 446
	Enums.eOverrideBoolean DisplayPercentageOverride { get; set; }

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x060001BF RID: 447
	// (set) Token: 0x060001C0 RID: 448
	Enums.eDamage DamageType { get; set; }

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x060001C1 RID: 449
	// (set) Token: 0x060001C2 RID: 450
	Enums.eMez MezType { get; set; }

	// Token: 0x170000CB RID: 203
	// (get) Token: 0x060001C3 RID: 451
	// (set) Token: 0x060001C4 RID: 452
	Enums.eEffectType ETModifies { get; set; }

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x060001C5 RID: 453
	// (set) Token: 0x060001C6 RID: 454
	string Summon { get; set; }

	// Token: 0x170000CD RID: 205
	// (get) Token: 0x060001C7 RID: 455
	// (set) Token: 0x060001C8 RID: 456
	int nSummon { get; set; }

	// Token: 0x170000CE RID: 206
	// (get) Token: 0x060001C9 RID: 457
	// (set) Token: 0x060001CA RID: 458
	int Ticks { get; set; }

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x060001CB RID: 459
	// (set) Token: 0x060001CC RID: 460
	float DelayedTime { get; set; }

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x060001CD RID: 461
	// (set) Token: 0x060001CE RID: 462
	Enums.eStacking Stacking { get; set; }

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x060001CF RID: 463
	// (set) Token: 0x060001D0 RID: 464
	Enums.eSuppress Suppression { get; set; }

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x060001D1 RID: 465
	// (set) Token: 0x060001D2 RID: 466
	bool Buffable { get; set; }

	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x060001D3 RID: 467
	// (set) Token: 0x060001D4 RID: 468
	bool Resistible { get; set; }

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x060001D5 RID: 469
	// (set) Token: 0x060001D6 RID: 470
	Enums.eSpecialCase SpecialCase { get; set; }

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x060001D7 RID: 471
	// (set) Token: 0x060001D8 RID: 472
	string UIDClassName { get; set; }

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x060001D9 RID: 473
	// (set) Token: 0x060001DA RID: 474
	int nIDClassName { get; set; }

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x060001DB RID: 475
	// (set) Token: 0x060001DC RID: 476
	bool VariableModifiedOverride { get; set; }

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x060001DD RID: 477
	// (set) Token: 0x060001DE RID: 478
	bool isEnahncementEffect { get; set; }

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x060001DF RID: 479
	// (set) Token: 0x060001E0 RID: 480
	Enums.ePvX PvMode { get; set; }

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x060001E1 RID: 481
	// (set) Token: 0x060001E2 RID: 482
	Enums.eToWho ToWho { get; set; }

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x060001E3 RID: 483
	// (set) Token: 0x060001E4 RID: 484
	float Scale { get; set; }

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x060001E5 RID: 485
	// (set) Token: 0x060001E6 RID: 486
	float nMagnitude { get; set; }

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x060001E7 RID: 487
	// (set) Token: 0x060001E8 RID: 488
	float nDuration { get; set; }

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x060001E9 RID: 489
	// (set) Token: 0x060001EA RID: 490
	Enums.eAttribType AttribType { get; set; }

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x060001EB RID: 491
	// (set) Token: 0x060001EC RID: 492
	Enums.eAspect Aspect { get; set; }

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x060001ED RID: 493
	// (set) Token: 0x060001EE RID: 494
	string ModifierTable { get; set; }

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x060001EF RID: 495
	// (set) Token: 0x060001F0 RID: 496
	int nModifierTable { get; set; }

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x060001F1 RID: 497
	// (set) Token: 0x060001F2 RID: 498
	string PowerFullName { get; set; }

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x060001F3 RID: 499
	// (set) Token: 0x060001F4 RID: 500
	bool NearGround { get; set; }

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x060001F5 RID: 501
	// (set) Token: 0x060001F6 RID: 502
	bool RequiresToHitCheck { get; set; }

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x060001F7 RID: 503
	// (set) Token: 0x060001F8 RID: 504
	float Math_Mag { get; set; }

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x060001F9 RID: 505
	// (set) Token: 0x060001FA RID: 506
	float Math_Duration { get; set; }

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x060001FB RID: 507
	// (set) Token: 0x060001FC RID: 508
	bool Absorbed_Effect { get; set; }

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x060001FD RID: 509
	// (set) Token: 0x060001FE RID: 510
	Enums.ePowerType Absorbed_PowerType { get; set; }

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x060001FF RID: 511
	// (set) Token: 0x06000200 RID: 512
	int Absorbed_Power_nID { get; set; }

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x06000201 RID: 513
	// (set) Token: 0x06000202 RID: 514
	float Absorbed_Duration { get; set; }

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x06000203 RID: 515
	// (set) Token: 0x06000204 RID: 516
	int Absorbed_Class_nID { get; set; }

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x06000205 RID: 517
	// (set) Token: 0x06000206 RID: 518
	float Absorbed_Interval { get; set; }

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x06000207 RID: 519
	// (set) Token: 0x06000208 RID: 520
	int Absorbed_EffectID { get; set; }

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x06000209 RID: 521
	// (set) Token: 0x0600020A RID: 522
	Enums.eBuffMode buffMode { get; set; }

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x0600020B RID: 523
	// (set) Token: 0x0600020C RID: 524
	string Override { get; set; }

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x0600020D RID: 525
	// (set) Token: 0x0600020E RID: 526
	int nOverride { get; set; }

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x0600020F RID: 527
	// (set) Token: 0x06000210 RID: 528
	string MagnitudeExpression { get; set; }

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x06000211 RID: 529
	// (set) Token: 0x06000212 RID: 530
	bool CancelOnMiss { get; set; }

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x06000213 RID: 531
	// (set) Token: 0x06000214 RID: 532
	float ProcsPerMinute { get; set; }

	// Token: 0x06000215 RID: 533
	bool isDamage();

	// Token: 0x06000216 RID: 534
	string BuildEffectStringShort(bool NoMag = false, bool simple = false, bool useBaseProbability = false);

	// Token: 0x06000217 RID: 535
	string BuildEffectString(bool Simple = false, string SpecialCat = "", bool noMag = false, bool Grouped = false, bool useBaseProbability = false);

	// Token: 0x06000218 RID: 536
	void StoreTo(ref BinaryWriter writer);

	// Token: 0x06000219 RID: 537
	bool ImportFromCSV(string iCSV);

	// Token: 0x0600021A RID: 538
	int SetTicks(float iDuration, float iInterval);

	// Token: 0x0600021B RID: 539
	bool CanInclude();

	// Token: 0x0600021C RID: 540
	bool PvXInclude();
}
