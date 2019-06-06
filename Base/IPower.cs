using System;
using System.IO;
using Base.Data_Classes;

// Token: 0x0200000B RID: 11
public interface IPower : IComparable
{

    // (get) Token: 0x060002AE RID: 686
    // (set) Token: 0x060002AF RID: 687
    IPowerset PowerSet { get; set; }


    // (get) Token: 0x060002B0 RID: 688
    string FullSetName { get; }


    // (get) Token: 0x060002B1 RID: 689
    // (set) Token: 0x060002B2 RID: 690
    float CastTime { get; set; }


    // (get) Token: 0x060002B3 RID: 691
    // (set) Token: 0x060002B4 RID: 692
    float CastTimeReal { get; set; }


    // (get) Token: 0x060002B5 RID: 693
    float ToggleCost { get; }


    // (get) Token: 0x060002B6 RID: 694
    bool IsEpic { get; }


    // (get) Token: 0x060002B7 RID: 695
    bool Slottable { get; }


    // (get) Token: 0x060002B8 RID: 696
    int LocationIndex { get; }


    // (get) Token: 0x060002B9 RID: 697
    // (set) Token: 0x060002BA RID: 698
    bool IsModified { get; set; }


    // (get) Token: 0x060002BB RID: 699
    // (set) Token: 0x060002BC RID: 700
    bool IsNew { get; set; }


    // (get) Token: 0x060002BD RID: 701
    // (set) Token: 0x060002BE RID: 702
    int PowerIndex { get; set; }


    // (get) Token: 0x060002BF RID: 703
    // (set) Token: 0x060002C0 RID: 704
    int PowerSetID { get; set; }


    // (get) Token: 0x060002C1 RID: 705
    // (set) Token: 0x060002C2 RID: 706
    int PowerSetIndex { get; set; }


    // (get) Token: 0x060002C3 RID: 707
    // (set) Token: 0x060002C4 RID: 708
    bool HasAbsorbedEffects { get; set; }


    // (get) Token: 0x060002C5 RID: 709
    // (set) Token: 0x060002C6 RID: 710
    int StaticIndex { get; set; }


    // (get) Token: 0x060002C7 RID: 711
    // (set) Token: 0x060002C8 RID: 712
    int[] NGroupMembership { get; set; }


    // (get) Token: 0x060002C9 RID: 713
    // (set) Token: 0x060002CA RID: 714
    string FullName { get; set; }


    // (get) Token: 0x060002CB RID: 715
    // (set) Token: 0x060002CC RID: 716
    string GroupName { get; set; }


    // (get) Token: 0x060002CD RID: 717
    // (set) Token: 0x060002CE RID: 718
    string SetName { get; set; }


    // (get) Token: 0x060002CF RID: 719
    // (set) Token: 0x060002D0 RID: 720
    string PowerName { get; set; }


    // (get) Token: 0x060002D1 RID: 721
    // (set) Token: 0x060002D2 RID: 722
    string DisplayName { get; set; }


    // (get) Token: 0x060002D3 RID: 723
    // (set) Token: 0x060002D4 RID: 724
    int Available { get; set; }


    // (get) Token: 0x060002D5 RID: 725
    // (set) Token: 0x060002D6 RID: 726
    Requirement Requires { get; set; }


    // (get) Token: 0x060002D7 RID: 727
    // (set) Token: 0x060002D8 RID: 728
    Enums.eModeFlags ModesRequired { get; set; }


    // (get) Token: 0x060002D9 RID: 729
    // (set) Token: 0x060002DA RID: 730
    Enums.eModeFlags ModesDisallowed { get; set; }


    // (get) Token: 0x060002DB RID: 731
    // (set) Token: 0x060002DC RID: 732
    Enums.ePowerType PowerType { get; set; }


    // (get) Token: 0x060002DD RID: 733
    // (set) Token: 0x060002DE RID: 734
    float Accuracy { get; set; }


    // (get) Token: 0x060002DF RID: 735
    // (set) Token: 0x060002E0 RID: 736
    float AccuracyMult { get; set; }


    // (get) Token: 0x060002E1 RID: 737
    // (set) Token: 0x060002E2 RID: 738
    Enums.eVector AttackTypes { get; set; }


    // (get) Token: 0x060002E3 RID: 739
    // (set) Token: 0x060002E4 RID: 740
    string[] GroupMembership { get; set; }


    // (get) Token: 0x060002E5 RID: 741
    // (set) Token: 0x060002E6 RID: 742
    Enums.eEntity EntitiesAffected { get; set; }


    // (get) Token: 0x060002E7 RID: 743
    // (set) Token: 0x060002E8 RID: 744
    Enums.eEntity EntitiesAutoHit { get; set; }


    // (get) Token: 0x060002E9 RID: 745
    // (set) Token: 0x060002EA RID: 746
    Enums.eEntity Target { get; set; }


    // (get) Token: 0x060002EB RID: 747
    // (set) Token: 0x060002EC RID: 748
    bool TargetLoS { get; set; }


    // (get) Token: 0x060002ED RID: 749
    // (set) Token: 0x060002EE RID: 750
    float Range { get; set; }


    // (get) Token: 0x060002EF RID: 751
    // (set) Token: 0x060002F0 RID: 752
    Enums.eEntity TargetSecondary { get; set; }


    // (get) Token: 0x060002F1 RID: 753
    // (set) Token: 0x060002F2 RID: 754
    float RangeSecondary { get; set; }


    // (get) Token: 0x060002F3 RID: 755
    // (set) Token: 0x060002F4 RID: 756
    float EndCost { get; set; }


    // (get) Token: 0x060002F5 RID: 757
    // (set) Token: 0x060002F6 RID: 758
    float InterruptTime { get; set; }


    // (get) Token: 0x060002F7 RID: 759
    // (set) Token: 0x060002F8 RID: 760
    float RechargeTime { get; set; }


    // (get) Token: 0x060002F9 RID: 761
    // (set) Token: 0x060002FA RID: 762
    float ActivatePeriod { get; set; }


    // (get) Token: 0x060002FB RID: 763
    // (set) Token: 0x060002FC RID: 764
    Enums.eEffectArea EffectArea { get; set; }


    // (get) Token: 0x060002FD RID: 765
    // (set) Token: 0x060002FE RID: 766
    float Radius { get; set; }


    // (get) Token: 0x060002FF RID: 767
    float AoEModifier { get; }


    // (get) Token: 0x06000300 RID: 768
    // (set) Token: 0x06000301 RID: 769
    int Arc { get; set; }


    // (get) Token: 0x06000302 RID: 770
    // (set) Token: 0x06000303 RID: 771
    int MaxTargets { get; set; }


    // (get) Token: 0x06000304 RID: 772
    // (set) Token: 0x06000305 RID: 773
    string MaxBoosts { get; set; }


    // (get) Token: 0x06000306 RID: 774
    // (set) Token: 0x06000307 RID: 775
    Enums.eCastFlags CastFlags { get; set; }


    // (get) Token: 0x06000308 RID: 776
    // (set) Token: 0x06000309 RID: 777
    Enums.eNotify AIReport { get; set; }


    // (get) Token: 0x0600030A RID: 778
    // (set) Token: 0x0600030B RID: 779
    int NumCharges { get; set; }


    // (get) Token: 0x0600030C RID: 780
    // (set) Token: 0x0600030D RID: 781
    int UsageTime { get; set; }


    // (get) Token: 0x0600030E RID: 782
    // (set) Token: 0x0600030F RID: 783
    int LifeTime { get; set; }


    // (get) Token: 0x06000310 RID: 784
    // (set) Token: 0x06000311 RID: 785
    int LifeTimeInGame { get; set; }


    // (get) Token: 0x06000312 RID: 786
    // (set) Token: 0x06000313 RID: 787
    int NumAllowed { get; set; }


    // (get) Token: 0x06000314 RID: 788
    // (set) Token: 0x06000315 RID: 789
    bool DoNotSave { get; set; }


    // (get) Token: 0x06000316 RID: 790
    // (set) Token: 0x06000317 RID: 791
    string[] BoostsAllowed { get; set; }


    // (get) Token: 0x06000318 RID: 792
    // (set) Token: 0x06000319 RID: 793
    int[] Enhancements { get; set; }


    // (get) Token: 0x0600031A RID: 794
    // (set) Token: 0x0600031B RID: 795
    bool CastThroughHold { get; set; }


    // (get) Token: 0x0600031C RID: 796
    // (set) Token: 0x0600031D RID: 797
    bool IgnoreStrength { get; set; }


    // (get) Token: 0x0600031E RID: 798
    // (set) Token: 0x0600031F RID: 799
    string DescShort { get; set; }


    // (get) Token: 0x06000320 RID: 800
    // (set) Token: 0x06000321 RID: 801
    string DescLong { get; set; }


    // (get) Token: 0x06000322 RID: 802
    // (set) Token: 0x06000323 RID: 803
    bool SortOverride { get; set; }


    // (get) Token: 0x06000324 RID: 804
    // (set) Token: 0x06000325 RID: 805
    bool HiddenPower { get; set; }


    // (get) Token: 0x06000326 RID: 806
    // (set) Token: 0x06000327 RID: 807
    Enums.eSetType[] SetTypes { get; set; }


    // (get) Token: 0x06000328 RID: 808
    // (set) Token: 0x06000329 RID: 809
    bool ClickBuff { get; set; }


    // (get) Token: 0x0600032A RID: 810
    // (set) Token: 0x0600032B RID: 811
    bool AlwaysToggle { get; set; }


    // (get) Token: 0x0600032C RID: 812
    // (set) Token: 0x0600032D RID: 813
    int Level { get; set; }


    // (get) Token: 0x0600032E RID: 814
    // (set) Token: 0x0600032F RID: 815
    bool AllowFrontLoading { get; set; }


    // (get) Token: 0x06000330 RID: 816
    // (set) Token: 0x06000331 RID: 817
    bool VariableEnabled { get; set; }


    // (get) Token: 0x06000332 RID: 818
    // (set) Token: 0x06000333 RID: 819
    string VariableName { get; set; }


    // (get) Token: 0x06000334 RID: 820
    // (set) Token: 0x06000335 RID: 821
    int VariableMin { get; set; }


    // (get) Token: 0x06000336 RID: 822
    // (set) Token: 0x06000337 RID: 823
    int VariableMax { get; set; }


    // (get) Token: 0x06000338 RID: 824
    // (set) Token: 0x06000339 RID: 825
    int[] NIDSubPower { get; set; }


    // (get) Token: 0x0600033A RID: 826
    // (set) Token: 0x0600033B RID: 827
    string[] UIDSubPower { get; set; }


    // (get) Token: 0x0600033C RID: 828
    // (set) Token: 0x0600033D RID: 829
    bool SubIsAltColour { get; set; }


    // (get) Token: 0x0600033E RID: 830
    // (set) Token: 0x0600033F RID: 831
    Enums.eEnhance[] IgnoreEnh { get; set; }


    // (get) Token: 0x06000340 RID: 832
    // (set) Token: 0x06000341 RID: 833
    Enums.eEnhance[] Ignore_Buff { get; set; }


    // (get) Token: 0x06000342 RID: 834
    // (set) Token: 0x06000343 RID: 835
    bool SkipMax { get; set; }


    // (get) Token: 0x06000344 RID: 836
    // (set) Token: 0x06000345 RID: 837
    int DisplayLocation { get; set; }


    // (get) Token: 0x06000346 RID: 838
    // (set) Token: 0x06000347 RID: 839
    bool MutexAuto { get; set; }


    // (get) Token: 0x06000348 RID: 840
    // (set) Token: 0x06000349 RID: 841
    bool MutexIgnore { get; set; }


    // (get) Token: 0x0600034A RID: 842
    // (set) Token: 0x0600034B RID: 843
    bool AbsorbSummonEffects { get; set; }


    // (get) Token: 0x0600034C RID: 844
    // (set) Token: 0x0600034D RID: 845
    bool AbsorbSummonAttributes { get; set; }


    // (get) Token: 0x0600034E RID: 846
    // (set) Token: 0x0600034F RID: 847
    bool ShowSummonAnyway { get; set; }


    // (get) Token: 0x06000350 RID: 848
    // (set) Token: 0x06000351 RID: 849
    bool NeverAutoUpdate { get; set; }


    // (get) Token: 0x06000352 RID: 850
    // (set) Token: 0x06000353 RID: 851
    bool NeverAutoUpdateRequirements { get; set; }


    // (get) Token: 0x06000354 RID: 852
    // (set) Token: 0x06000355 RID: 853
    bool IncludeFlag { get; set; }


    // (get) Token: 0x06000356 RID: 854
    // (set) Token: 0x06000357 RID: 855
    bool BoostBoostable { get; set; }


    // (get) Token: 0x06000358 RID: 856
    // (set) Token: 0x06000359 RID: 857
    bool BoostUsePlayerLevel { get; set; }


    // (get) Token: 0x0600035A RID: 858
    // (set) Token: 0x0600035B RID: 859
    string ForcedClass { get; set; }


    // (get) Token: 0x0600035C RID: 860
    // (set) Token: 0x0600035D RID: 861
    int ForcedClassID { get; set; }


    // (get) Token: 0x0600035E RID: 862
    // (set) Token: 0x0600035F RID: 863
    IEffect[] Effects { get; set; }


    // (get) Token: 0x06000360 RID: 864
    // (set) Token: 0x06000361 RID: 865
    Enums.eBuffMode BuffMode { get; set; }


    // (get) Token: 0x06000362 RID: 866
    // (set) Token: 0x06000363 RID: 867
    bool HasGrantPowerEffect { get; set; }


    // (get) Token: 0x06000364 RID: 868
    // (set) Token: 0x06000365 RID: 869
    bool HasPowerOverrideEffect { get; set; }


    void StoreTo(ref BinaryWriter writer);


    float FXGetDamageValue();


    string FXGetDamageString();


    int[] GetRankedEffects();


    int GetDurationEffectID();


    float[] GetDef(int buffDebuff = 0);


    float[] GetRes(bool pvE = true);


    bool HasMutexID(int index);


    bool HasDefEffects();


    bool HasResEffects();


    Enums.ShortFX GetEnhancementMagSum(Enums.eEffectType iEffect, int subType = 0);


    Enums.ShortFX GetEffectMagSum(Enums.eEffectType iEffect, bool includeDelayed = false, bool onlySelf = false, bool onlyTarget = false, bool maxMode = false);


    Enums.ShortFX GetDamageMagSum(Enums.eEffectType iEffect, Enums.eDamage iSub, bool includeDelayed = false);


    Enums.ShortFX GetEffectMag(Enums.eEffectType iEffect, Enums.eToWho iTarget = Enums.eToWho.Unspecified, bool allowDelay = false);


    bool AffectsTarget(Enums.eEffectType iEffect);


    bool AffectsSelf(Enums.eEffectType iEffect);


    bool I9FXPresentP(Enums.eEffectType iEffect, Enums.eMez iMez = Enums.eMez.None);


    bool UpdateFromCSV(string iCSV);


    bool IgnoreEnhancement(Enums.eEnhance iEffect);


    bool IgnoreBuff(Enums.eEnhance iEffect);


    void SetMathMag();


    bool GetEffectStringGrouped(int idEffect, ref string returnString, ref int[] returnMask, bool shortForm, bool simple, bool noMag = false);


    int[] AbsorbEffects(IPower source, float nDuration, float nDelay, Archetype archetype, int stacking, bool isGrantPower = false, int fxid = -1, int effectId = -1);


    void ApplyGrantPowerEffects();


    int[] GetValidEnhancements(Enums.eType iType, Enums.eSubtype iSubType = Enums.eSubtype.None);


    bool IsEnhancementValid(int iEnh);


    void AbsorbPetEffects(int hIdx = -1);
}
