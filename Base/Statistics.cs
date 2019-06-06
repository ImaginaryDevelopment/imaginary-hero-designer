using System;
using Base.Data_Classes;

// Token: 0x0200009C RID: 156
public class Statistics
{
    // Token: 0x1700027E RID: 638
    // (get) Token: 0x060006D4 RID: 1748 RVA: 0x00031FB8 File Offset: 0x000301B8
    public float EnduranceMaxEnd
    {
        get
        {
            return this._character.Totals.EndMax + 100f;
        }
    }

    // Token: 0x1700027F RID: 639
    // (get) Token: 0x060006D5 RID: 1749 RVA: 0x00031FE0 File Offset: 0x000301E0
    public float EnduranceRecoveryNumeric
    {
        get
        {
            float num = this._character.Archetype.BaseRecovery * 1.66666663f;
            return this.EnduranceRecovery(false) * num * (this._character.TotalsCapped.EndMax / 100f + 1f);
        }
    }

    // Token: 0x17000280 RID: 640
    // (get) Token: 0x060006D6 RID: 1750 RVA: 0x00032030 File Offset: 0x00030230
    public float EnduranceTimeToFull
    {
        get
        {
            return this.EnduranceMaxEnd / this.EnduranceRecoveryNumeric;
        }
    }

    // Token: 0x17000281 RID: 641
    // (get) Token: 0x060006D7 RID: 1751 RVA: 0x00032050 File Offset: 0x00030250
    public float EnduranceRecoveryNet
    {
        get
        {
            return this.EnduranceRecoveryNumeric - this.EnduranceUsage;
        }
    }

    // Token: 0x17000282 RID: 642
    // (get) Token: 0x060006D8 RID: 1752 RVA: 0x00032070 File Offset: 0x00030270
    public float EnduranceRecoveryLossNet
    {
        get
        {
            return -(this.EnduranceRecoveryNumeric - this.EnduranceUsage);
        }
    }

    // Token: 0x17000283 RID: 643
    // (get) Token: 0x060006D9 RID: 1753 RVA: 0x00032090 File Offset: 0x00030290
    public float EnduranceTimeToZero
    {
        get
        {
            return this.EnduranceMaxEnd / -(this.EnduranceRecoveryNumeric - this.EnduranceUsage);
        }
    }

    // Token: 0x17000284 RID: 644
    // (get) Token: 0x060006DA RID: 1754 RVA: 0x000320B8 File Offset: 0x000302B8
    public float EnduranceTimeToFullNet
    {
        get
        {
            return this.EnduranceMaxEnd / (this.EnduranceRecoveryNumeric - this.EnduranceUsage);
        }
    }

    // Token: 0x17000285 RID: 645
    // (get) Token: 0x060006DB RID: 1755 RVA: 0x000320E0 File Offset: 0x000302E0
    public float EnduranceUsage
    {
        get
        {
            return this._character.Totals.EndUse;
        }
    }

    // Token: 0x17000286 RID: 646
    // (get) Token: 0x060006DC RID: 1756 RVA: 0x00032104 File Offset: 0x00030304
    public float HealthRegenHealthPerSec
    {
        get
        {
            return this.HealthRegen(false) * this._character.Archetype.BaseRegen * 1.66666663f;
        }
    }

    // Token: 0x17000287 RID: 647
    // (get) Token: 0x060006DD RID: 1757 RVA: 0x00032134 File Offset: 0x00030334
    public float HealthRegenHPPerSec
    {
        get
        {
            return this.HealthRegen(false) * this._character.Archetype.BaseRegen * 1.66666663f * this.HealthHitpointsNumeric(false) / 100f;
        }
    }

    // Token: 0x17000288 RID: 648
    // (get) Token: 0x060006DE RID: 1758 RVA: 0x00032174 File Offset: 0x00030374
    public float HealthRegenTimeToFull
    {
        get
        {
            return this.HealthHitpointsNumeric(false) / this.HealthRegenHPPerSec;
        }
    }

    // Token: 0x17000289 RID: 649
    // (get) Token: 0x060006DF RID: 1759 RVA: 0x00032194 File Offset: 0x00030394
    public float HealthHitpointsPercentage
    {
        get
        {
            return this._character.TotalsCapped.HPMax / (float)this._character.Archetype.Hitpoints * 100f;
        }
    }

    // Token: 0x1700028A RID: 650
    // (get) Token: 0x060006E0 RID: 1760 RVA: 0x000321D0 File Offset: 0x000303D0
    public float BuffToHit
    {
        get
        {
            return this._character.Totals.BuffToHit * 100f;
        }
    }

    // Token: 0x1700028B RID: 651
    // (get) Token: 0x060006E1 RID: 1761 RVA: 0x000321F8 File Offset: 0x000303F8
    public float BuffAccuracy
    {
        get
        {
            return this._character.Totals.BuffAcc * 100f;
        }
    }

    // Token: 0x1700028C RID: 652
    // (get) Token: 0x060006E2 RID: 1762 RVA: 0x00032220 File Offset: 0x00030420
    public float BuffEndRdx
    {
        get
        {
            return this._character.Totals.BuffEndRdx * 100f;
        }
    }

    // Token: 0x1700028D RID: 653
    // (get) Token: 0x060006E3 RID: 1763 RVA: 0x00032248 File Offset: 0x00030448
    public float ThreatLevel
    {
        get
        {
            return (this._character.Totals.ThreatLevel + this._character.Archetype.BaseThreat) * 100f;
        }
    }

    // Token: 0x060006E4 RID: 1764 RVA: 0x00032281 File Offset: 0x00030481
    internal Statistics(Character character)
    {
        this._character = character;
    }

    // Token: 0x060006E5 RID: 1765 RVA: 0x00032294 File Offset: 0x00030494
    private float EnduranceRecovery(bool uncapped)
    {
        float result;
        if (!uncapped)
        {
            result = this._character.TotalsCapped.EndRec + 1f;
        }
        else
        {
            result = this._character.Totals.EndRec + 1f;
        }
        return result;
    }

    // Token: 0x060006E6 RID: 1766 RVA: 0x000322E0 File Offset: 0x000304E0
    public float EnduranceRecoveryPercentage(bool uncapped)
    {
        return this.EnduranceRecovery(uncapped) * 100f;
    }

    // Token: 0x060006E7 RID: 1767 RVA: 0x00032300 File Offset: 0x00030500
    private float HealthRegen(bool uncapped)
    {
        float result;
        if (!uncapped)
        {
            result = this._character.TotalsCapped.HPRegen + 1f;
        }
        else
        {
            result = this._character.Totals.HPRegen + 1f;
        }
        return result;
    }

    // Token: 0x060006E8 RID: 1768 RVA: 0x0003234C File Offset: 0x0003054C
    public float HealthRegenPercent(bool uncapped)
    {
        return this.HealthRegen(uncapped) * 100f;
    }

    // Token: 0x060006E9 RID: 1769 RVA: 0x0003236C File Offset: 0x0003056C
    public float HealthHitpointsNumeric(bool uncapped)
    {
        float hpmax;
        if (!uncapped)
        {
            hpmax = this._character.TotalsCapped.HPMax;
        }
        else
        {
            hpmax = this._character.Totals.HPMax;
        }
        return hpmax;
    }

    // Token: 0x060006EA RID: 1770 RVA: 0x000323AC File Offset: 0x000305AC
    public float DamageResistance(int dType, bool uncapped)
    {
        float result;
        if (!uncapped)
        {
            result = this._character.TotalsCapped.Res[dType] * 100f;
        }
        else
        {
            result = this._character.Totals.Res[dType] * 100f;
        }
        return result;
    }

    // Token: 0x060006EB RID: 1771 RVA: 0x000323FC File Offset: 0x000305FC
    public float Perception(bool uncapped)
    {
        float perception;
        if (!uncapped)
        {
            perception = this._character.TotalsCapped.Perception;
        }
        else
        {
            perception = this._character.Totals.Perception;
        }
        return perception;
    }

    // Token: 0x060006EC RID: 1772 RVA: 0x0003243C File Offset: 0x0003063C
    public float Defense(int dType)
    {
        return this._character.Totals.Def[dType] * 100f;
    }

    // Token: 0x060006ED RID: 1773 RVA: 0x00032468 File Offset: 0x00030668
    public float Speed(float iSpeed, Enums.eSpeedMeasure unit)
    {
        float num;
        switch (unit)
        {
            case Enums.eSpeedMeasure.FeetPerSecond:
                num = iSpeed;
                break;
            case Enums.eSpeedMeasure.MetersPerSecond:
                num = iSpeed * 0.3048f;
                break;
            case Enums.eSpeedMeasure.MilesPerHour:
                num = iSpeed * 0.6818182f;
                break;
            case Enums.eSpeedMeasure.KilometersPerHour:
                num = iSpeed * 1.09728f;
                break;
            default:
                num = iSpeed;
                break;
        }
        return num;
    }

    // Token: 0x060006EE RID: 1774 RVA: 0x000324BC File Offset: 0x000306BC
    public float Distance(float iDist, Enums.eSpeedMeasure unit)
    {
        float num;
        switch (unit)
        {
            case Enums.eSpeedMeasure.FeetPerSecond:
                num = iDist;
                break;
            case Enums.eSpeedMeasure.MetersPerSecond:
                num = iDist * 0.3048f;
                break;
            case Enums.eSpeedMeasure.MilesPerHour:
                num = iDist;
                break;
            case Enums.eSpeedMeasure.KilometersPerHour:
                num = iDist * 0.3048f;
                break;
            default:
                num = iDist;
                break;
        }
        return num;
    }

    // Token: 0x060006EF RID: 1775 RVA: 0x0003250C File Offset: 0x0003070C
    public float MovementRunSpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.RunSpd;
        if (!uncapped && this._character.Totals.RunSpd > this._character.Totals.MaxRunSpd)
        {
            iSpeed = this._character.Totals.MaxRunSpd;
        }
        return this.Speed(iSpeed, sType);
    }

    // Token: 0x060006F0 RID: 1776 RVA: 0x0003257C File Offset: 0x0003077C
    public float MovementFlySpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.FlySpd;
        if (!uncapped && this._character.Totals.FlySpd > this._character.Totals.MaxFlySpd)
        {
            iSpeed = this._character.Totals.MaxFlySpd;
        }
        return this.Speed(iSpeed, sType);
    }

    // Token: 0x060006F1 RID: 1777 RVA: 0x000325EC File Offset: 0x000307EC
    public float MovementJumpSpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.JumpSpd;
        if (!uncapped && this._character.Totals.JumpSpd > this._character.Totals.MaxJumpSpd)
        {
            iSpeed = this._character.Totals.MaxJumpSpd;
        }
        return this.Speed(iSpeed, sType);
    }

    // Token: 0x060006F2 RID: 1778 RVA: 0x0003265C File Offset: 0x0003085C
    public float MovementJumpHeight(Enums.eSpeedMeasure sType)
    {
        float result;
        if (!(sType == Enums.eSpeedMeasure.KilometersPerHour | sType == Enums.eSpeedMeasure.MetersPerSecond))
        {
            result = this._character.TotalsCapped.JumpHeight;
        }
        else
        {
            result = this._character.TotalsCapped.JumpHeight * 0.3048f;
        }
        return result;
    }

    // Token: 0x060006F3 RID: 1779 RVA: 0x000326AC File Offset: 0x000308AC
    public float BuffHaste(bool uncapped)
    {
        float result;
        if (uncapped)
        {
            result = (this._character.Totals.BuffHaste + 1f) * 100f;
        }
        else
        {
            result = (this._character.TotalsCapped.BuffHaste + 1f) * 100f;
        }
        return result;
    }

    // Token: 0x060006F4 RID: 1780 RVA: 0x00032708 File Offset: 0x00030908
    public float BuffDamage(bool uncapped)
    {
        float result;
        if (uncapped)
        {
            result = (this._character.Totals.BuffDam + 1f) * 100f;
        }
        else
        {
            result = (this._character.TotalsCapped.BuffDam + 1f) * 100f;
        }
        return result;
    }

    // Token: 0x040006B2 RID: 1714
    public const float MaxRunSpeed = 135.67f;

    // Token: 0x040006B3 RID: 1715
    public const float MaxJumpSpeed = 114.4f;

    // Token: 0x040006B4 RID: 1716
    public const float MaxFlySpeed = 86f;

    // Token: 0x040006B5 RID: 1717
    public const float CapRunSpeed = 135.67f;

    // Token: 0x040006B6 RID: 1718
    public const float CapJumpSpeed = 114.4f;

    // Token: 0x040006B7 RID: 1719
    public const float CapFlySpeed = 128.99f;

    // Token: 0x040006B8 RID: 1720
    public const float BaseRunSpeed = 21f;

    // Token: 0x040006B9 RID: 1721
    public const float BaseJumpSpeed = 21f;

    // Token: 0x040006BA RID: 1722
    public const float BaseJumpHeight = 4f;

    // Token: 0x040006BB RID: 1723
    public const float BaseFlySpeed = 31.5f;

    // Token: 0x040006BC RID: 1724
    public const float BaseMagic = 1.66666663f;

    // Token: 0x040006BD RID: 1725
    public const float BasePerception = 500f;

    // Token: 0x040006BE RID: 1726
    private readonly Character _character;
}
