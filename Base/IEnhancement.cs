using System;
using System.IO;

// Token: 0x02000028 RID: 40
public interface IEnhancement
{

    // (get) Token: 0x0600051E RID: 1310
    bool HasEnhEffect { get; }


    // (get) Token: 0x0600051F RID: 1311
    bool HasPowerEffect { get; }


    // (get) Token: 0x06000520 RID: 1312
    Enums.eSchedule Schedule { get; }


    // (get) Token: 0x06000521 RID: 1313
    float Probability { get; }


    // (get) Token: 0x06000522 RID: 1314
    // (set) Token: 0x06000523 RID: 1315
    bool IsModified { get; set; }


    // (get) Token: 0x06000524 RID: 1316
    // (set) Token: 0x06000525 RID: 1317
    bool IsNew { get; set; }


    // (get) Token: 0x06000526 RID: 1318
    // (set) Token: 0x06000527 RID: 1319
    int StaticIndex { get; set; }


    // (get) Token: 0x06000528 RID: 1320
    // (set) Token: 0x06000529 RID: 1321
    string Name { get; set; }


    // (get) Token: 0x0600052A RID: 1322
    // (set) Token: 0x0600052B RID: 1323
    string ShortName { get; set; }


    // (get) Token: 0x0600052C RID: 1324
    // (set) Token: 0x0600052D RID: 1325
    string Desc { get; set; }


    // (get) Token: 0x0600052E RID: 1326
    // (set) Token: 0x0600052F RID: 1327
    Enums.eType TypeID { get; set; }


    // (get) Token: 0x06000530 RID: 1328
    // (set) Token: 0x06000531 RID: 1329
    Enums.eSubtype SubTypeID { get; set; }


    // (get) Token: 0x06000532 RID: 1330
    // (set) Token: 0x06000533 RID: 1331
    int[] ClassID { get; set; }


    // (get) Token: 0x06000534 RID: 1332
    // (set) Token: 0x06000535 RID: 1333
    string Image { get; set; }


    // (get) Token: 0x06000536 RID: 1334
    // (set) Token: 0x06000537 RID: 1335
    int ImageIdx { get; set; }


    // (get) Token: 0x06000538 RID: 1336
    // (set) Token: 0x06000539 RID: 1337
    int nIDSet { get; set; }


    // (get) Token: 0x0600053A RID: 1338
    // (set) Token: 0x0600053B RID: 1339
    string UIDSet { get; set; }


    // (get) Token: 0x0600053C RID: 1340
    // (set) Token: 0x0600053D RID: 1341
    IPower Power { get; set; }


    // (get) Token: 0x0600053E RID: 1342
    // (set) Token: 0x0600053F RID: 1343
    Enums.sEffect[] Effect { get; set; }


    // (get) Token: 0x06000540 RID: 1344
    // (set) Token: 0x06000541 RID: 1345
    float EffectChance { get; set; }


    // (get) Token: 0x06000542 RID: 1346
    // (set) Token: 0x06000543 RID: 1347
    int LevelMin { get; set; }


    // (get) Token: 0x06000544 RID: 1348
    // (set) Token: 0x06000545 RID: 1349
    int LevelMax { get; set; }


    // (get) Token: 0x06000546 RID: 1350
    // (set) Token: 0x06000547 RID: 1351
    bool Unique { get; set; }


    // (get) Token: 0x06000548 RID: 1352
    // (set) Token: 0x06000549 RID: 1353
    Enums.eEnhMutex MutExID { get; set; }


    // (get) Token: 0x0600054A RID: 1354
    // (set) Token: 0x0600054B RID: 1355
    Enums.eBuffDebuff BuffMode { get; set; }


    // (get) Token: 0x0600054C RID: 1356
    // (set) Token: 0x0600054D RID: 1357
    string RecipeName { get; set; }


    // (get) Token: 0x0600054E RID: 1358
    // (set) Token: 0x0600054F RID: 1359
    int RecipeIDX { get; set; }


    // (get) Token: 0x06000550 RID: 1360
    // (set) Token: 0x06000551 RID: 1361
    string UID { get; set; }


    // (get) Token: 0x06000552 RID: 1362
    // (set) Token: 0x06000553 RID: 1363
    bool Superior { get; set; }


    // (get) Token: 0x06000554 RID: 1364
    string LongName { get; }


    int CheckAndFixIOLevel(int level);


    void StoreTo(BinaryWriter writer);


    string GetSpecialName();
}
