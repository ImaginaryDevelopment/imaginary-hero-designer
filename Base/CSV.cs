using System;
using System.Text.RegularExpressions;

// Token: 0x02000023 RID: 35
public static class CSV
{
    // Token: 0x060004C7 RID: 1223 RVA: 0x0001C0E0 File Offset: 0x0001A2E0
    public static string[] ToArray(string iLine)
    {
        string[] strArray = CSV.Reg.Split(iLine);
        char[] chArray = new char[]
        {
            '"'
        };
        for (int index = 0; index < strArray.Length; index++)
        {
            strArray[index] = strArray[index].Trim(chArray);
        }
        return strArray;
    }

    // Token: 0x040001D0 RID: 464
    private static readonly Regex Reg = new Regex(",(?=(?:[^\"]|\"[^\"]*\")*$)", RegexOptions.CultureInvariant);

    // Token: 0x02000024 RID: 36
    internal enum HPower
    {
        // Token: 0x040001D2 RID: 466
        PowerId,
        // Token: 0x040001D3 RID: 467
        DisplayName,
        // Token: 0x040001D4 RID: 468
        Available,
        // Token: 0x040001D5 RID: 469
        Requires,
        // Token: 0x040001D6 RID: 470
        ModesRequired,
        // Token: 0x040001D7 RID: 471
        ModesDisallowed,
        // Token: 0x040001D8 RID: 472
        Type,
        // Token: 0x040001D9 RID: 473
        Accuracy,
        // Token: 0x040001DA RID: 474
        AttackTypes,
        // Token: 0x040001DB RID: 475
        GroupMembership,
        // Token: 0x040001DC RID: 476
        AIGroups,
        // Token: 0x040001DD RID: 477
        EntsAffected,
        // Token: 0x040001DE RID: 478
        EntsAutohit,
        // Token: 0x040001DF RID: 479
        Target,
        // Token: 0x040001E0 RID: 480
        TargetVisibility,
        // Token: 0x040001E1 RID: 481
        TimeToConfirm,
        // Token: 0x040001E2 RID: 482
        DisplayConfirm,
        // Token: 0x040001E3 RID: 483
        Range,
        // Token: 0x040001E4 RID: 484
        TargetSecondary,
        // Token: 0x040001E5 RID: 485
        RangeSecondary,
        // Token: 0x040001E6 RID: 486
        EnduranceCost,
        // Token: 0x040001E7 RID: 487
        IdeaCost,
        // Token: 0x040001E8 RID: 488
        InterruptTime,
        // Token: 0x040001E9 RID: 489
        CastTime,
        // Token: 0x040001EA RID: 490
        RechargeTime,
        // Token: 0x040001EB RID: 491
        ActivatePeriod,
        // Token: 0x040001EC RID: 492
        EffectArea,
        // Token: 0x040001ED RID: 493
        Radius,
        // Token: 0x040001EE RID: 494
        Arc,
        // Token: 0x040001EF RID: 495
        MaxTargetsHit,
        // Token: 0x040001F0 RID: 496
        MaxBoosts,
        // Token: 0x040001F1 RID: 497
        Misc,
        // Token: 0x040001F2 RID: 498
        AIreport,
        // Token: 0x040001F3 RID: 499
        NumCharges,
        // Token: 0x040001F4 RID: 500
        UsageTime,
        // Token: 0x040001F5 RID: 501
        Lifetime,
        // Token: 0x040001F6 RID: 502
        LifetimeInGame,
        // Token: 0x040001F7 RID: 503
        NumAllowed,
        // Token: 0x040001F8 RID: 504
        DoNotSave,
        // Token: 0x040001F9 RID: 505
        BoostsAllowed,
        // Token: 0x040001FA RID: 506
        AnimMainTargetOnly,
        // Token: 0x040001FB RID: 507
        CastThroughHold,
        // Token: 0x040001FC RID: 508
        CastThroughSleep,
        // Token: 0x040001FD RID: 509
        CastThroughStun,
        // Token: 0x040001FE RID: 510
        CastThroughTerrorize,
        // Token: 0x040001FF RID: 511
        IgnoreStrength,
        // Token: 0x04000200 RID: 512
        MouseOverText,
        // Token: 0x04000201 RID: 513
        HelpText,
        // Token: 0x04000202 RID: 514
        AttackerHitMessage,
        // Token: 0x04000203 RID: 515
        VictimHitMessage,
        // Token: 0x04000204 RID: 516
        IconName,
        // Token: 0x04000205 RID: 517
        ActivateRequires,
        // Token: 0x04000206 RID: 518
        SlotRequires,
        // Token: 0x04000207 RID: 519
        TargetRequires,
        // Token: 0x04000208 RID: 520
        RewardRequires,
        // Token: 0x04000209 RID: 521
        AuctionRequires,
        // Token: 0x0400020A RID: 522
        RewardFallback,
        // Token: 0x0400020B RID: 523
        DisplayAttackerAttackFloater,
        // Token: 0x0400020C RID: 524
        ShowBuffIcon,
        // Token: 0x0400020D RID: 525
        ShowInInventory,
        // Token: 0x0400020E RID: 526
        ShowInManage,
        // Token: 0x0400020F RID: 527
        ShowInInfo,
        // Token: 0x04000210 RID: 528
        Deleteable,
        // Token: 0x04000211 RID: 529
        Tradeable,
        // Token: 0x04000212 RID: 530
        BoostIgnoresEffectiveness,
        // Token: 0x04000213 RID: 531
        BoostAlwaysCountForSet,
        // Token: 0x04000214 RID: 532
        BoostTradeable,
        // Token: 0x04000215 RID: 533
        BoostCombinable,
        // Token: 0x04000216 RID: 534
        BoostAccountBound,
        // Token: 0x04000217 RID: 535
        BoostBoostable,
        // Token: 0x04000218 RID: 536
        BoostUsePlayerLevel,
        // Token: 0x04000219 RID: 537
        BoostCatalystConversion,
        // Token: 0x0400021A RID: 538
        BoostLicenseLevel,
        // Token: 0x0400021B RID: 539
        MinSlotLevel,
        // Token: 0x0400021C RID: 540
        MaxSlotLevel,
        // Token: 0x0400021D RID: 541
        MaxBoostLevel,
        // Token: 0x0400021E RID: 542
        StrengthsDisallowed,
        // Token: 0x0400021F RID: 543
        ProcMainTargetOnly,
        // Token: 0x04000220 RID: 544
        HighlightEval,
        // Token: 0x04000221 RID: 545
        HighlightRingRed,
        // Token: 0x04000222 RID: 546
        HighlightRingGreen,
        // Token: 0x04000223 RID: 547
        HighlightRingBlue,
        // Token: 0x04000224 RID: 548
        HighlightRingAlpha,
        // Token: 0x04000225 RID: 549
        ChainIntoPower,
        // Token: 0x04000226 RID: 550
        InstanceLocked,
        // Token: 0x04000227 RID: 551
        PowerRedirector,
        // Token: 0x04000228 RID: 552
        Cancelable,
        // Token: 0x04000229 RID: 553
        IgnoreToggleMaxDistance,
        // Token: 0x0400022A RID: 554
        ToggleIgnoreHold,
        // Token: 0x0400022B RID: 555
        ToggleIgnoreSleep,
        // Token: 0x0400022C RID: 556
        ToggleIgnoreStun,
        // Token: 0x0400022D RID: 557
        IgnoreLevelBought,
        // Token: 0x0400022E RID: 558
        ShootThroughUntouchable,
        // Token: 0x0400022F RID: 559
        InterruptLikeSleep
    }

    // Token: 0x02000025 RID: 37
    internal enum HEffect
    {
        // Token: 0x04000231 RID: 561
        PowerID,
        // Token: 0x04000232 RID: 562
        Table,
        // Token: 0x04000233 RID: 563
        Aspect,
        // Token: 0x04000234 RID: 564
        Attrib,
        // Token: 0x04000235 RID: 565
        Target,
        // Token: 0x04000236 RID: 566
        Scale,
        // Token: 0x04000237 RID: 567
        Type,
        // Token: 0x04000238 RID: 568
        AllowStrength,
        // Token: 0x04000239 RID: 569
        AllowResistance,
        // Token: 0x0400023A RID: 570
        Suppress,
        // Token: 0x0400023B RID: 571
        CancelEvents,
        // Token: 0x0400023C RID: 572
        AllowCombatMobs,
        // Token: 0x0400023D RID: 573
        CostumeName,
        // Token: 0x0400023E RID: 574
        EntityDef,
        // Token: 0x0400023F RID: 575
        PriorityList,
        // Token: 0x04000240 RID: 576
        Delay,
        // Token: 0x04000241 RID: 577
        Duration,
        // Token: 0x04000242 RID: 578
        Magnitude,
        // Token: 0x04000243 RID: 579
        StackType,
        // Token: 0x04000244 RID: 580
        Period,
        // Token: 0x04000245 RID: 581
        Chance,
        // Token: 0x04000246 RID: 582
        NearGround,
        // Token: 0x04000247 RID: 583
        CancelOnMiss,
        // Token: 0x04000248 RID: 584
        VanishOnTimeout,
        // Token: 0x04000249 RID: 585
        RadiusInner,
        // Token: 0x0400024A RID: 586
        RadiusOuter,
        // Token: 0x0400024B RID: 587
        Requires,
        // Token: 0x0400024C RID: 588
        MagnitudeExpr,
        // Token: 0x0400024D RID: 589
        DurationExpr,
        // Token: 0x0400024E RID: 590
        Reward,
        // Token: 0x0400024F RID: 591
        IgnoreSuppressErrors,
        // Token: 0x04000250 RID: 592
        DisplayFloat,
        // Token: 0x04000251 RID: 593
        DisplayAttackerHit,
        // Token: 0x04000252 RID: 594
        DisplayVictimHit,
        // Token: 0x04000253 RID: 595
        Order,
        // Token: 0x04000254 RID: 596
        ShowFloaters,
        // Token: 0x04000255 RID: 597
        ModeName,
        // Token: 0x04000256 RID: 598
        EffectId,
        // Token: 0x04000257 RID: 599
        BoostIgnoreDiminishing,
        // Token: 0x04000258 RID: 600
        BoostTemplate,
        // Token: 0x04000259 RID: 601
        PrimaryStringList,
        // Token: 0x0400025A RID: 602
        SecondaryStringList,
        // Token: 0x0400025B RID: 603
        ApplicationType,
        // Token: 0x0400025C RID: 604
        UseMagnitudeResistance,
        // Token: 0x0400025D RID: 605
        UseDurationResistance,
        // Token: 0x0400025E RID: 606
        UseMagnitudeCombatMods,
        // Token: 0x0400025F RID: 607
        UseDurationCombatMods,
        // Token: 0x04000260 RID: 608
        CasterStackType,
        // Token: 0x04000261 RID: 609
        StackLimit,
        // Token: 0x04000262 RID: 610
        ContinuingFX,
        // Token: 0x04000263 RID: 611
        ConditionalFX,
        // Token: 0x04000264 RID: 612
        Params,
        // Token: 0x04000265 RID: 613
        DisplayOnlyIfNotZero,
        // Token: 0x04000266 RID: 614
        MatchExactPower,
        // Token: 0x04000267 RID: 615
        DoNotTint,
        // Token: 0x04000268 RID: 616
        KeepThroughDeath,
        // Token: 0x04000269 RID: 617
        DelayEval,
        // Token: 0x0400026A RID: 618
        BoostModAllowed,
        // Token: 0x0400026B RID: 619
        EvalFlags,
        // Token: 0x0400026C RID: 620
        ProcsPerMinute
    }

    // Token: 0x02000026 RID: 38
    internal enum BoostSet
    {
        // Token: 0x0400026E RID: 622
        Id,
        // Token: 0x0400026F RID: 623
        DisplayName,
        // Token: 0x04000270 RID: 624
        GroupName,
        // Token: 0x04000271 RID: 625
        MinLevel,
        // Token: 0x04000272 RID: 626
        MaxLevel
    }
}
