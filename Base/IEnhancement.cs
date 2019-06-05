using System;
using System.IO;

// Token: 0x02000028 RID: 40
public interface IEnhancement
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x0600051E RID: 1310
	bool HasEnhEffect { get; }

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x0600051F RID: 1311
	bool HasPowerEffect { get; }

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000520 RID: 1312
	Enums.eSchedule Schedule { get; }

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000521 RID: 1313
	float Probability { get; }

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06000522 RID: 1314
	// (set) Token: 0x06000523 RID: 1315
	bool IsModified { get; set; }

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000524 RID: 1316
	// (set) Token: 0x06000525 RID: 1317
	bool IsNew { get; set; }

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000526 RID: 1318
	// (set) Token: 0x06000527 RID: 1319
	int StaticIndex { get; set; }

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x06000528 RID: 1320
	// (set) Token: 0x06000529 RID: 1321
	string Name { get; set; }

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x0600052A RID: 1322
	// (set) Token: 0x0600052B RID: 1323
	string ShortName { get; set; }

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x0600052C RID: 1324
	// (set) Token: 0x0600052D RID: 1325
	string Desc { get; set; }

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x0600052E RID: 1326
	// (set) Token: 0x0600052F RID: 1327
	Enums.eType TypeID { get; set; }

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x06000530 RID: 1328
	// (set) Token: 0x06000531 RID: 1329
	Enums.eSubtype SubTypeID { get; set; }

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x06000532 RID: 1330
	// (set) Token: 0x06000533 RID: 1331
	int[] ClassID { get; set; }

	// Token: 0x17000213 RID: 531
	// (get) Token: 0x06000534 RID: 1332
	// (set) Token: 0x06000535 RID: 1333
	string Image { get; set; }

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06000536 RID: 1334
	// (set) Token: 0x06000537 RID: 1335
	int ImageIdx { get; set; }

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06000538 RID: 1336
	// (set) Token: 0x06000539 RID: 1337
	int nIDSet { get; set; }

	// Token: 0x17000216 RID: 534
	// (get) Token: 0x0600053A RID: 1338
	// (set) Token: 0x0600053B RID: 1339
	string UIDSet { get; set; }

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x0600053C RID: 1340
	// (set) Token: 0x0600053D RID: 1341
	IPower Power { get; set; }

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x0600053E RID: 1342
	// (set) Token: 0x0600053F RID: 1343
	Enums.sEffect[] Effect { get; set; }

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06000540 RID: 1344
	// (set) Token: 0x06000541 RID: 1345
	float EffectChance { get; set; }

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x06000542 RID: 1346
	// (set) Token: 0x06000543 RID: 1347
	int LevelMin { get; set; }

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x06000544 RID: 1348
	// (set) Token: 0x06000545 RID: 1349
	int LevelMax { get; set; }

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06000546 RID: 1350
	// (set) Token: 0x06000547 RID: 1351
	bool Unique { get; set; }

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06000548 RID: 1352
	// (set) Token: 0x06000549 RID: 1353
	Enums.eEnhMutex MutExID { get; set; }

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x0600054A RID: 1354
	// (set) Token: 0x0600054B RID: 1355
	Enums.eBuffDebuff BuffMode { get; set; }

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x0600054C RID: 1356
	// (set) Token: 0x0600054D RID: 1357
	string RecipeName { get; set; }

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x0600054E RID: 1358
	// (set) Token: 0x0600054F RID: 1359
	int RecipeIDX { get; set; }

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x06000550 RID: 1360
	// (set) Token: 0x06000551 RID: 1361
	string UID { get; set; }

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06000552 RID: 1362
	// (set) Token: 0x06000553 RID: 1363
	bool Superior { get; set; }

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06000554 RID: 1364
	string LongName { get; }

	// Token: 0x06000555 RID: 1365
	int CheckAndFixIOLevel(int level);

	// Token: 0x06000556 RID: 1366
	void StoreTo(BinaryWriter writer);

	// Token: 0x06000557 RID: 1367
	string GetSpecialName();
}
