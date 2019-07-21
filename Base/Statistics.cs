
using Base.Data_Classes;

public class Statistics
{
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
    internal const float BaseMagic = 1.666667f;
    public const float BasePerception = 500f;
    readonly Character _character;


    public float EnduranceMaxEnd => this._character.Totals.EndMax + 100f;

    public float EnduranceRecoveryNumeric
            => (float)(this.EnduranceRecovery(false) * (double)(this._character.Archetype.BaseRecovery * BaseMagic) * (_character.TotalsCapped.EndMax / 100.0 + 1.0));

    public float EnduranceTimeToFull => this.EnduranceMaxEnd / this.EnduranceRecoveryNumeric;

    public float EnduranceRecoveryNet => this.EnduranceRecoveryNumeric - this.EnduranceUsage;

    public float EnduranceRecoveryLossNet => (float)-(EnduranceRecoveryNumeric - (double)this.EnduranceUsage);

    public float EnduranceTimeToZero =>this.EnduranceMaxEnd / (float)-((double)this.EnduranceRecoveryNumeric - (double)this.EnduranceUsage);

    public float EnduranceTimeToFullNet =>this.EnduranceMaxEnd / (this.EnduranceRecoveryNumeric - this.EnduranceUsage);

    public float EnduranceUsage => this._character.Totals.EndUse;

    public float HealthRegenHealthPerSec =>(float)((double)this.HealthRegen(false) * (double)this._character.Archetype.BaseRegen * 1.66666662693024);

    public float HealthRegenHPPerSec =>
        (float)(this.HealthRegen(false) * (double)this._character.Archetype.BaseRegen * 1.66666662693024 * this.HealthHitpointsNumeric(false)
        / 100.0);

    public float HealthRegenTimeToFull => this.HealthHitpointsNumeric(false) / this.HealthRegenHPPerSec;

    public float HealthHitpointsPercentage => (float)(_character.TotalsCapped.HPMax / (double)this._character.Archetype.Hitpoints * 100.0);

    public float BuffToHit => this._character.Totals.BuffToHit * 100f;

    public float BuffAccuracy => this._character.Totals.BuffAcc * 100f;

    public float BuffEndRdx => this._character.Totals.BuffEndRdx * 100f;

    public float ThreatLevel => (float)((_character.Totals.ThreatLevel + (double)this._character.Archetype.BaseThreat) * 100.0);

    internal Statistics(Character character) => this._character = character;

    float EnduranceRecovery(bool uncapped)
        => uncapped ? this._character.Totals.EndRec + 1f : this._character.TotalsCapped.EndRec + 1f;

    public float EnduranceRecoveryPercentage(bool uncapped)
        => this.EnduranceRecovery(uncapped) * 100f;

    float HealthRegen(bool uncapped)
        => uncapped ? this._character.Totals.HPRegen + 1f : this._character.TotalsCapped.HPRegen + 1f;

    public float HealthRegenPercent(bool uncapped)
        => this.HealthRegen(uncapped) * 100f;

    public float HealthHitpointsNumeric(bool uncapped)
        => uncapped ? this._character.Totals.HPMax : this._character.TotalsCapped.HPMax;

    public float DamageResistance(int dType, bool uncapped)
        => uncapped ? this._character.Totals.Res[dType] * 100f : this._character.TotalsCapped.Res[dType] * 100f;

    public float Perception(bool uncapped)
        => uncapped ? this._character.Totals.Perception : this._character.TotalsCapped.Perception;

    public float Defense(int dType)
        => this._character.Totals.Def[dType] * 100f;

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
        if (!uncapped && _character.Totals.RunSpd > (double)this._character.Totals.MaxRunSpd)
            iSpeed = this._character.Totals.MaxRunSpd;
        return this.Speed(iSpeed, sType);
    }

    public float MovementFlySpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.FlySpd;
        if (!uncapped && _character.Totals.FlySpd > (double)this._character.Totals.MaxFlySpd)
            iSpeed = this._character.Totals.MaxFlySpd;
        return this.Speed(iSpeed, sType);
    }

    public float MovementJumpSpeed(Enums.eSpeedMeasure sType, bool uncapped)
    {
        float iSpeed = this._character.Totals.JumpSpd;
        if (!uncapped && _character.Totals.JumpSpd > (double)this._character.Totals.MaxJumpSpd)
            iSpeed = this._character.Totals.MaxJumpSpd;
        return this.Speed(iSpeed, sType);
    }

    public float MovementJumpHeight(Enums.eSpeedMeasure sType)
        => sType == Enums.eSpeedMeasure.KilometersPerHour | sType == Enums.eSpeedMeasure.MetersPerSecond ? this._character.TotalsCapped.JumpHeight * 0.3048f : this._character.TotalsCapped.JumpHeight;

    public float BuffHaste(bool uncapped)
     => !uncapped ? (float)((_character.TotalsCapped.BuffHaste + 1.0) * 100.0) : (float)((_character.Totals.BuffHaste + 1.0) * 100.0);

    public float BuffDamage(bool uncapped)
     => !uncapped ? (float)((_character.TotalsCapped.BuffDam + 1.0) * 100.0) : (float)((_character.Totals.BuffDam + 1.0) * 100.0);
}
