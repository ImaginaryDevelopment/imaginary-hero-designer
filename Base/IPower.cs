using System;
using System.IO;
using Base.Data_Classes;

// Token: 0x0200000B RID: 11
public interface IPower : IComparable
{
	// Token: 0x17000136 RID: 310
	// (get) Token: 0x060002AE RID: 686
	// (set) Token: 0x060002AF RID: 687
	IPowerset PowerSet { get; set; }

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x060002B0 RID: 688
	string FullSetName { get; }

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x060002B1 RID: 689
	// (set) Token: 0x060002B2 RID: 690
	float CastTime { get; set; }

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x060002B3 RID: 691
	// (set) Token: 0x060002B4 RID: 692
	float CastTimeReal { get; set; }

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x060002B5 RID: 693
	float ToggleCost { get; }

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x060002B6 RID: 694
	bool IsEpic { get; }

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x060002B7 RID: 695
	bool Slottable { get; }

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x060002B8 RID: 696
	int LocationIndex { get; }

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x060002B9 RID: 697
	// (set) Token: 0x060002BA RID: 698
	bool IsModified { get; set; }

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x060002BB RID: 699
	// (set) Token: 0x060002BC RID: 700
	bool IsNew { get; set; }

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x060002BD RID: 701
	// (set) Token: 0x060002BE RID: 702
	int PowerIndex { get; set; }

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x060002BF RID: 703
	// (set) Token: 0x060002C0 RID: 704
	int PowerSetID { get; set; }

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x060002C1 RID: 705
	// (set) Token: 0x060002C2 RID: 706
	int PowerSetIndex { get; set; }

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x060002C3 RID: 707
	// (set) Token: 0x060002C4 RID: 708
	bool HasAbsorbedEffects { get; set; }

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x060002C5 RID: 709
	// (set) Token: 0x060002C6 RID: 710
	int StaticIndex { get; set; }

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x060002C7 RID: 711
	// (set) Token: 0x060002C8 RID: 712
	int[] NGroupMembership { get; set; }

	// Token: 0x17000146 RID: 326
	// (get) Token: 0x060002C9 RID: 713
	// (set) Token: 0x060002CA RID: 714
	string FullName { get; set; }

	// Token: 0x17000147 RID: 327
	// (get) Token: 0x060002CB RID: 715
	// (set) Token: 0x060002CC RID: 716
	string GroupName { get; set; }

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x060002CD RID: 717
	// (set) Token: 0x060002CE RID: 718
	string SetName { get; set; }

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x060002CF RID: 719
	// (set) Token: 0x060002D0 RID: 720
	string PowerName { get; set; }

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x060002D1 RID: 721
	// (set) Token: 0x060002D2 RID: 722
	string DisplayName { get; set; }

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x060002D3 RID: 723
	// (set) Token: 0x060002D4 RID: 724
	int Available { get; set; }

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x060002D5 RID: 725
	// (set) Token: 0x060002D6 RID: 726
	Requirement Requires { get; set; }

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x060002D7 RID: 727
	// (set) Token: 0x060002D8 RID: 728
	Enums.eModeFlags ModesRequired { get; set; }

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x060002D9 RID: 729
	// (set) Token: 0x060002DA RID: 730
	Enums.eModeFlags ModesDisallowed { get; set; }

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x060002DB RID: 731
	// (set) Token: 0x060002DC RID: 732
	Enums.ePowerType PowerType { get; set; }

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x060002DD RID: 733
	// (set) Token: 0x060002DE RID: 734
	float Accuracy { get; set; }

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x060002DF RID: 735
	// (set) Token: 0x060002E0 RID: 736
	float AccuracyMult { get; set; }

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x060002E1 RID: 737
	// (set) Token: 0x060002E2 RID: 738
	Enums.eVector AttackTypes { get; set; }

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x060002E3 RID: 739
	// (set) Token: 0x060002E4 RID: 740
	string[] GroupMembership { get; set; }

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x060002E5 RID: 741
	// (set) Token: 0x060002E6 RID: 742
	Enums.eEntity EntitiesAffected { get; set; }

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x060002E7 RID: 743
	// (set) Token: 0x060002E8 RID: 744
	Enums.eEntity EntitiesAutoHit { get; set; }

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x060002E9 RID: 745
	// (set) Token: 0x060002EA RID: 746
	Enums.eEntity Target { get; set; }

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x060002EB RID: 747
	// (set) Token: 0x060002EC RID: 748
	bool TargetLoS { get; set; }

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x060002ED RID: 749
	// (set) Token: 0x060002EE RID: 750
	float Range { get; set; }

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x060002EF RID: 751
	// (set) Token: 0x060002F0 RID: 752
	Enums.eEntity TargetSecondary { get; set; }

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x060002F1 RID: 753
	// (set) Token: 0x060002F2 RID: 754
	float RangeSecondary { get; set; }

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x060002F3 RID: 755
	// (set) Token: 0x060002F4 RID: 756
	float EndCost { get; set; }

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x060002F5 RID: 757
	// (set) Token: 0x060002F6 RID: 758
	float InterruptTime { get; set; }

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x060002F7 RID: 759
	// (set) Token: 0x060002F8 RID: 760
	float RechargeTime { get; set; }

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x060002F9 RID: 761
	// (set) Token: 0x060002FA RID: 762
	float ActivatePeriod { get; set; }

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x060002FB RID: 763
	// (set) Token: 0x060002FC RID: 764
	Enums.eEffectArea EffectArea { get; set; }

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x060002FD RID: 765
	// (set) Token: 0x060002FE RID: 766
	float Radius { get; set; }

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x060002FF RID: 767
	float AoEModifier { get; }

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x06000300 RID: 768
	// (set) Token: 0x06000301 RID: 769
	int Arc { get; set; }

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x06000302 RID: 770
	// (set) Token: 0x06000303 RID: 771
	int MaxTargets { get; set; }

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x06000304 RID: 772
	// (set) Token: 0x06000305 RID: 773
	string MaxBoosts { get; set; }

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x06000306 RID: 774
	// (set) Token: 0x06000307 RID: 775
	Enums.eCastFlags CastFlags { get; set; }

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06000308 RID: 776
	// (set) Token: 0x06000309 RID: 777
	Enums.eNotify AIReport { get; set; }

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x0600030A RID: 778
	// (set) Token: 0x0600030B RID: 779
	int NumCharges { get; set; }

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x0600030C RID: 780
	// (set) Token: 0x0600030D RID: 781
	int UsageTime { get; set; }

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x0600030E RID: 782
	// (set) Token: 0x0600030F RID: 783
	int LifeTime { get; set; }

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x06000310 RID: 784
	// (set) Token: 0x06000311 RID: 785
	int LifeTimeInGame { get; set; }

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x06000312 RID: 786
	// (set) Token: 0x06000313 RID: 787
	int NumAllowed { get; set; }

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x06000314 RID: 788
	// (set) Token: 0x06000315 RID: 789
	bool DoNotSave { get; set; }

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x06000316 RID: 790
	// (set) Token: 0x06000317 RID: 791
	string[] BoostsAllowed { get; set; }

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x06000318 RID: 792
	// (set) Token: 0x06000319 RID: 793
	int[] Enhancements { get; set; }

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x0600031A RID: 794
	// (set) Token: 0x0600031B RID: 795
	bool CastThroughHold { get; set; }

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x0600031C RID: 796
	// (set) Token: 0x0600031D RID: 797
	bool IgnoreStrength { get; set; }

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x0600031E RID: 798
	// (set) Token: 0x0600031F RID: 799
	string DescShort { get; set; }

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x06000320 RID: 800
	// (set) Token: 0x06000321 RID: 801
	string DescLong { get; set; }

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x06000322 RID: 802
	// (set) Token: 0x06000323 RID: 803
	bool SortOverride { get; set; }

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x06000324 RID: 804
	// (set) Token: 0x06000325 RID: 805
	bool HiddenPower { get; set; }

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x06000326 RID: 806
	// (set) Token: 0x06000327 RID: 807
	Enums.eSetType[] SetTypes { get; set; }

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x06000328 RID: 808
	// (set) Token: 0x06000329 RID: 809
	bool ClickBuff { get; set; }

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x0600032A RID: 810
	// (set) Token: 0x0600032B RID: 811
	bool AlwaysToggle { get; set; }

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x0600032C RID: 812
	// (set) Token: 0x0600032D RID: 813
	int Level { get; set; }

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x0600032E RID: 814
	// (set) Token: 0x0600032F RID: 815
	bool AllowFrontLoading { get; set; }

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x06000330 RID: 816
	// (set) Token: 0x06000331 RID: 817
	bool VariableEnabled { get; set; }

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x06000332 RID: 818
	// (set) Token: 0x06000333 RID: 819
	string VariableName { get; set; }

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x06000334 RID: 820
	// (set) Token: 0x06000335 RID: 821
	int VariableMin { get; set; }

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x06000336 RID: 822
	// (set) Token: 0x06000337 RID: 823
	int VariableMax { get; set; }

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x06000338 RID: 824
	// (set) Token: 0x06000339 RID: 825
	int[] NIDSubPower { get; set; }

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x0600033A RID: 826
	// (set) Token: 0x0600033B RID: 827
	string[] UIDSubPower { get; set; }

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x0600033C RID: 828
	// (set) Token: 0x0600033D RID: 829
	bool SubIsAltColour { get; set; }

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x0600033E RID: 830
	// (set) Token: 0x0600033F RID: 831
	Enums.eEnhance[] IgnoreEnh { get; set; }

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x06000340 RID: 832
	// (set) Token: 0x06000341 RID: 833
	Enums.eEnhance[] Ignore_Buff { get; set; }

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x06000342 RID: 834
	// (set) Token: 0x06000343 RID: 835
	bool SkipMax { get; set; }

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x06000344 RID: 836
	// (set) Token: 0x06000345 RID: 837
	int DisplayLocation { get; set; }

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x06000346 RID: 838
	// (set) Token: 0x06000347 RID: 839
	bool MutexAuto { get; set; }

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x06000348 RID: 840
	// (set) Token: 0x06000349 RID: 841
	bool MutexIgnore { get; set; }

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x0600034A RID: 842
	// (set) Token: 0x0600034B RID: 843
	bool AbsorbSummonEffects { get; set; }

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x0600034C RID: 844
	// (set) Token: 0x0600034D RID: 845
	bool AbsorbSummonAttributes { get; set; }

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x0600034E RID: 846
	// (set) Token: 0x0600034F RID: 847
	bool ShowSummonAnyway { get; set; }

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x06000350 RID: 848
	// (set) Token: 0x06000351 RID: 849
	bool NeverAutoUpdate { get; set; }

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x06000352 RID: 850
	// (set) Token: 0x06000353 RID: 851
	bool NeverAutoUpdateRequirements { get; set; }

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x06000354 RID: 852
	// (set) Token: 0x06000355 RID: 853
	bool IncludeFlag { get; set; }

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x06000356 RID: 854
	// (set) Token: 0x06000357 RID: 855
	bool BoostBoostable { get; set; }

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x06000358 RID: 856
	// (set) Token: 0x06000359 RID: 857
	bool BoostUsePlayerLevel { get; set; }

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x0600035A RID: 858
	// (set) Token: 0x0600035B RID: 859
	string ForcedClass { get; set; }

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x0600035C RID: 860
	// (set) Token: 0x0600035D RID: 861
	int ForcedClassID { get; set; }

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x0600035E RID: 862
	// (set) Token: 0x0600035F RID: 863
	IEffect[] Effects { get; set; }

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06000360 RID: 864
	// (set) Token: 0x06000361 RID: 865
	Enums.eBuffMode BuffMode { get; set; }

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x06000362 RID: 866
	// (set) Token: 0x06000363 RID: 867
	bool HasGrantPowerEffect { get; set; }

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x06000364 RID: 868
	// (set) Token: 0x06000365 RID: 869
	bool HasPowerOverrideEffect { get; set; }

	// Token: 0x06000366 RID: 870
	void StoreTo(ref BinaryWriter writer);

	// Token: 0x06000367 RID: 871
	float FXGetDamageValue();

	// Token: 0x06000368 RID: 872
	string FXGetDamageString();

	// Token: 0x06000369 RID: 873
	int[] GetRankedEffects();

	// Token: 0x0600036A RID: 874
	int GetDurationEffectID();

	// Token: 0x0600036B RID: 875
	float[] GetDef(int buffDebuff = 0);

	// Token: 0x0600036C RID: 876
	float[] GetRes(bool pvE = true);

	// Token: 0x0600036D RID: 877
	bool HasMutexID(int index);

	// Token: 0x0600036E RID: 878
	bool HasDefEffects();

	// Token: 0x0600036F RID: 879
	bool HasResEffects();

	// Token: 0x06000370 RID: 880
	Enums.ShortFX GetEnhancementMagSum(Enums.eEffectType iEffect, int subType = 0);

	// Token: 0x06000371 RID: 881
	Enums.ShortFX GetEffectMagSum(Enums.eEffectType iEffect, bool includeDelayed = false, bool onlySelf = false, bool onlyTarget = false, bool maxMode = false);

	// Token: 0x06000372 RID: 882
	Enums.ShortFX GetDamageMagSum(Enums.eEffectType iEffect, Enums.eDamage iSub, bool includeDelayed = false);

	// Token: 0x06000373 RID: 883
	Enums.ShortFX GetEffectMag(Enums.eEffectType iEffect, Enums.eToWho iTarget = Enums.eToWho.Unspecified, bool allowDelay = false);

	// Token: 0x06000374 RID: 884
	bool AffectsTarget(Enums.eEffectType iEffect);

	// Token: 0x06000375 RID: 885
	bool AffectsSelf(Enums.eEffectType iEffect);

	// Token: 0x06000376 RID: 886
	bool I9FXPresentP(Enums.eEffectType iEffect, Enums.eMez iMez = Enums.eMez.None);

	// Token: 0x06000377 RID: 887
	bool UpdateFromCSV(string iCSV);

	// Token: 0x06000378 RID: 888
	bool IgnoreEnhancement(Enums.eEnhance iEffect);

	// Token: 0x06000379 RID: 889
	bool IgnoreBuff(Enums.eEnhance iEffect);

	// Token: 0x0600037A RID: 890
	void SetMathMag();

	// Token: 0x0600037B RID: 891
	bool GetEffectStringGrouped(int idEffect, ref string returnString, ref int[] returnMask, bool shortForm, bool simple, bool noMag = false);

	// Token: 0x0600037C RID: 892
	int[] AbsorbEffects(IPower source, float nDuration, float nDelay, Archetype archetype, int stacking, bool isGrantPower = false, int fxid = -1, int effectId = -1);

	// Token: 0x0600037D RID: 893
	void ApplyGrantPowerEffects();

	// Token: 0x0600037E RID: 894
	int[] GetValidEnhancements(Enums.eType iType, Enums.eSubtype iSubType = Enums.eSubtype.None);

	// Token: 0x0600037F RID: 895
	bool IsEnhancementValid(int iEnh);

	// Token: 0x06000380 RID: 896
	void AbsorbPetEffects(int hIdx = -1);
}
