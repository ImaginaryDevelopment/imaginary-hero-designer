using System;
using Base.Data_Classes;

// Token: 0x0200009C RID: 156
public class Statistics
{

    
    public float EnduranceMaxEnd
    {
        get
        {
            return this._character.Totals.EndMax + 100f;
        }
    }


    
    public float EnduranceRecoveryNumeric
    {
        get
        {
            float num = this._character.Archetype.BaseRecovery * 1.66666663f;
            return this.EnduranceRecovery(false) * num * (this._character.TotalsCapped.EndMax / 100f + 1f);
        }
    }


    
    public float EnduranceTimeToFull
    {
        get
        {
            return this.EnduranceMaxEnd / this.EnduranceRecoveryNumeric;
        }
    }


    
    public float EnduranceRecoveryNet
    {
        get
        {
            return this.EnduranceRecoveryNumeric - this.EnduranceUsage;
        }
    }


    
    public float EnduranceRecoveryLossNet
    {
        get
        {
            return -(this.EnduranceRecoveryNumeric - this.EnduranceUsage);
        }
    }


    
    public float EnduranceTimeToZero
    {
        get
        {
            return this.EnduranceMaxEnd / -(this.EnduranceRecoveryNumeric - this.EnduranceUsage);
        }
    }


    
    public float EnduranceTimeToFullNet
    {
        get
        {
            return this.EnduranceMaxEnd / (this.EnduranceRecoveryNumeric - this.EnduranceUsage);
        }
    }


    
    public float EnduranceUsage
    {
        get
        {
            return this._character.Totals.EndUse;
        }
    }


    
    public float HealthRegenHealthPerSec
    {
        get
        {
            return this.HealthRegen(false) * this._character.Archetype.BaseRegen * 1.66666663f;
        }
    }


    
    public float HealthRegenHPPerSec
    {
        get
        {
            return this.HealthRegen(false) * this._character.Archetype.BaseRegen * 1.66666663f * this.HealthHitpointsNumeric(false) / 100f;
        }
    }


    
    public float HealthRegenTimeToFull
    {
        get
        {
            return this.HealthHitpointsNumeric(false) / this.HealthRegenHPPerSec;
        }
    }


    
    public float HealthHitpointsPercentage
    {
        get
        {
            return this._character.TotalsCapped.HPMax / (float)this._character.Archetype.Hitpoints * 100f;
        }
    }


    
    public float BuffToHit
    {
        get
        {
            return this._character.Totals.BuffToHit * 100f;
        }
    }


    
    public float BuffAccuracy
    {
        get
        {
            return this._character.Totals.BuffAcc * 100f;
        }
    }


    
    public float BuffEndRdx
    {
        get
        {
            return this._character.Totals.BuffEndRdx * 100f;
        }
    }


    
    public float ThreatLevel
    {
        get
        {
            return (this._character.Totals.ThreatLevel + this._character.Archetype.BaseThreat) * 100f;
        }
    }


    internal Statistics(Character character)
    {
        this._character = character;
    }


    float EnduranceRecovery(bool uncapped)
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


    public float EnduranceRecoveryPercentage(bool uncapped)
    {
        return this.EnduranceRecovery(uncapped) * 100f;
    }


    float HealthRegen(bool uncapped)
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


    public float HealthRegenPercent(bool uncapped)
    {
        return this.HealthRegen(uncapped) * 100f;
    }


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


    public float Defense(int dType)
    {
        return this._character.Totals.Def[dType] * 100f;
    }


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


    public float MovementRunSpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.RunSpd;
        if (!uncapped && this._character.Totals.RunSpd > this._character.Totals.MaxRunSpd)
        {
            iSpeed = this._character.Totals.MaxRunSpd;
        }
        return this.Speed(iSpeed, sType);
    }


    public float MovementFlySpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.FlySpd;
        if (!uncapped && this._character.Totals.FlySpd > this._character.Totals.MaxFlySpd)
        {
            iSpeed = this._character.Totals.MaxFlySpd;
        }
        return this.Speed(iSpeed, sType);
    }


    public float MovementJumpSpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.JumpSpd;
        if (!uncapped && this._character.Totals.JumpSpd > this._character.Totals.MaxJumpSpd)
        {
            iSpeed = this._character.Totals.MaxJumpSpd;
        }
        return this.Speed(iSpeed, sType);
    }


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


    public const float MaxRunSpeed = 135.67f;


    public const float MaxJumpSpeed = 114.4f;


    public const float MaxFlySpeed = 86f;


    public const float CapRunSpeed = 135.67f;


    public const float CapJumpSpeed = 114.4f;


    public const float CapFlySpeed = 128.99f;


    public const float BaseRunSpeed = 21f;


    public const float BaseJumpSpeed = 21f;


    public const float BaseJumpHeight = 4f;


    public const float BaseFlySpeed = 31.5f;


    public const float BaseMagic = 1.66666663f;


    public const float BasePerception = 500f;


    readonly Character _character;
}
