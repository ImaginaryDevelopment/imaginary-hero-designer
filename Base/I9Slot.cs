using System;
using System.Globalization;
using System.Text;
using Base.Data_Classes;

// Token: 0x0200007F RID: 127
public class I9Slot : ICloneable
{
	// Token: 0x06000602 RID: 1538 RVA: 0x000287F0 File Offset: 0x000269F0
	public I9Slot()
	{
		this.Enh = -1;
		this.RelativeLevel = Enums.eEnhRelative.Even;
		this.Grade = Enums.eEnhGrade.None;
		this.IOLevel = 1;
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x00028818 File Offset: 0x00026A18
	public float GetEnhancementEffect(Enums.eEnhance iEffect, int subEnh, float mag)
	{
		float num;
		if (this.Enh < 0)
		{
			num = 0f;
		}
		else
		{
			float num2 = 0f;
			IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.Enh];
			foreach (Enums.sEffect sEffect in enhancement.Effect)
			{
				if (sEffect.Mode == Enums.eEffMode.Enhancement && (sEffect.BuffMode != Enums.eBuffDebuff.DeBuffOnly || mag <= 0f) && (sEffect.BuffMode != Enums.eBuffDebuff.BuffOnly || mag >= 0f) && sEffect.Schedule != Enums.eSchedule.None && sEffect.Enhance.ID == (int)iEffect && (subEnh < 0 || subEnh == sEffect.Enhance.SubID))
				{
					float scheduleMult = this.GetScheduleMult(enhancement.TypeID, sEffect.Schedule);
					if ((double)Math.Abs(sEffect.Multiplier) > 0.01)
					{
						scheduleMult *= sEffect.Multiplier;
					}
					num2 += scheduleMult;
				}
			}
			num = num2;
		}
		return num;
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x00028954 File Offset: 0x00026B54
	private float GetScheduleMult(Enums.eType iType, Enums.eSchedule iSched)
	{
		if (this.Grade < Enums.eEnhGrade.None)
		{
			this.Grade = Enums.eEnhGrade.None;
		}
		if (this.RelativeLevel < Enums.eEnhRelative.None)
		{
			this.RelativeLevel = Enums.eEnhRelative.None;
		}
		if (this.Grade > Enums.eEnhGrade.SingleO)
		{
			this.Grade = Enums.eEnhGrade.SingleO;
		}
		if (this.RelativeLevel > Enums.eEnhRelative.PlusFive)
		{
			this.RelativeLevel = Enums.eEnhRelative.PlusFive;
		}
		float num2 = 0f;
		if (this.IOLevel <= 0)
		{
			this.IOLevel = 0;
		}
		if (this.IOLevel > DatabaseAPI.Database.MultIO.Length - 1)
		{
			this.IOLevel = DatabaseAPI.Database.MultIO.Length - 1;
		}
		if (iSched == Enums.eSchedule.None || iSched == Enums.eSchedule.Multiple)
		{
			num2 = 0f;
		}
		else
		{
			switch (iType)
			{
			case Enums.eType.Normal:
				switch (this.Grade)
				{
				case Enums.eEnhGrade.None:
					num2 = 0f;
					break;
				case Enums.eEnhGrade.TrainingO:
					num2 = DatabaseAPI.Database.MultTO[0][(int)iSched];
					break;
				case Enums.eEnhGrade.DualO:
					num2 = DatabaseAPI.Database.MultDO[0][(int)iSched];
					break;
				case Enums.eEnhGrade.SingleO:
					num2 = DatabaseAPI.Database.MultSO[0][(int)iSched];
					break;
				}
				break;
			case Enums.eType.InventO:
				num2 = DatabaseAPI.Database.MultIO[this.IOLevel][(int)iSched];
				break;
			case Enums.eType.SpecialO:
				num2 = DatabaseAPI.Database.MultSO[0][(int)iSched];
				break;
			case Enums.eType.SetO:
				num2 = DatabaseAPI.Database.MultIO[this.IOLevel][(int)iSched];
				break;
			}
		}
		num2 *= this.GetRelativeLevelMultiplier();
		if (this.Enh > -1 && DatabaseAPI.Database.Enhancements[this.Enh].Superior)
		{
			num2 *= 1.25f;
		}
		return num2;
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x00028B38 File Offset: 0x00026D38
	private float GetRelativeLevelMultiplier()
	{
		float num;
		if (this.RelativeLevel == Enums.eEnhRelative.None)
		{
			num = 0f;
		}
		else
		{
			int num2 = this.RelativeLevel - Enums.eEnhRelative.Even;
			if (num2 < 0)
			{
				num = 1f + (float)num2 * 0.1f;
			}
			else
			{
				num = (float)num2 * 0.05f + 1f;
			}
		}
		return num;
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x00028BA0 File Offset: 0x00026DA0
	public string GetEnhancementString()
	{
		string str;
		if (this.Enh < 0)
		{
			str = string.Empty;
		}
		else
		{
			IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.Enh];
			if (enhancement.Effect.Length == 0)
			{
				str = enhancement.Desc;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				bool flag = false;
				Enums.sEffect[] effect = enhancement.Effect;
				int index = 0;
				if (index >= effect.Length)
				{
					str = stringBuilder.ToString();
				}
				else
				{
					Enums.sEffect sEffect = effect[index];
					if (sEffect.Mode == Enums.eEffMode.FX)
					{
						flag = true;
					}
					string str2;
					if (sEffect.Mode == Enums.eEffMode.Enhancement && sEffect.Schedule != Enums.eSchedule.None)
					{
						float scheduleMult = this.GetScheduleMult(enhancement.TypeID, sEffect.Schedule);
						if (sEffect.Multiplier > 0f)
						{
							scheduleMult *= sEffect.Multiplier;
						}
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(", ");
						}
						switch (enhancement.TypeID)
						{
						case Enums.eType.Normal:
						{
							string relativeString2 = Enums.GetRelativeString(this.RelativeLevel, false);
							if (!string.IsNullOrEmpty(relativeString2) & relativeString2 != "X")
							{
								stringBuilder.Append(relativeString2 + " " + DatabaseAPI.Database.EnhGradeStringLong[(int)this.Grade] + " - ");
							}
							else if (relativeString2 == "X")
							{
								stringBuilder.Append("Disabled " + DatabaseAPI.Database.EnhGradeStringLong[(int)this.Grade] + " - ");
							}
							else
							{
								stringBuilder.Append(DatabaseAPI.Database.EnhGradeStringLong[(int)this.Grade] + " - ");
							}
							break;
						}
						case Enums.eType.SpecialO:
						{
							string relativeString2 = Enums.GetRelativeString(this.RelativeLevel, false);
							if (!string.IsNullOrEmpty(relativeString2) & relativeString2 != "X")
							{
								stringBuilder.Append(relativeString2 + " " + enhancement.GetSpecialName() + " - ");
							}
							else if (relativeString2 == "X")
							{
								stringBuilder.Append("Disabled " + enhancement.GetSpecialName() + " - ");
							}
							else
							{
								stringBuilder.Append(enhancement.GetSpecialName() + " - ");
							}
							break;
						}
						}
						stringBuilder.Append("Schedule: ");
						stringBuilder.Append(sEffect.Schedule.ToString());
						stringBuilder.AppendFormat(" ({0}%)", (scheduleMult * 100f).ToString(NumberFormatInfo.CurrentInfo));
						str2 = stringBuilder.ToString();
					}
					else if (!flag)
					{
						str2 = stringBuilder.ToString();
					}
					else
					{
						for (int index2 = 0; index2 <= enhancement.Power.Effects.Length - 1; index2++)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(", ");
							}
							stringBuilder.Append(enhancement.Power.Effects[index2].BuildEffectString(true, "", false, false, false));
						}
						str2 = "Effect: " + stringBuilder;
					}
					str = str2;
				}
			}
		}
		return str;
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00028F4C File Offset: 0x0002714C
	public string GetEnhancementStringLong()
	{
		string str;
		if (this.Enh < 0)
		{
			str = string.Empty;
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			IEnhancement enhancement = DatabaseAPI.Database.Enhancements[this.Enh];
			if (enhancement.Effect.Length == 0)
			{
				str = enhancement.Desc;
			}
			else
			{
				foreach (Enums.sEffect sEffect in enhancement.Effect)
				{
					if (sEffect.Mode == Enums.eEffMode.FX)
					{
						flag = true;
					}
					if (sEffect.Mode == Enums.eEffMode.Enhancement && sEffect.Schedule != Enums.eSchedule.None)
					{
						float scheduleMult = this.GetScheduleMult(enhancement.TypeID, sEffect.Schedule);
						if (sEffect.Multiplier > 0f)
						{
							scheduleMult *= sEffect.Multiplier;
						}
						Enums.eEnhance id = (Enums.eEnhance)sEffect.Enhance.ID;
						string str2;
						if (id == Enums.eEnhance.Mez)
						{
							Enums.eMez subId = (Enums.eMez)sEffect.Enhance.SubID;
							str2 = Enum.GetName(subId.GetType(), subId);
						}
						else
						{
							str2 = Enum.GetName(id.GetType(), id);
						}
						if (sEffect.Enhance.ID == 7 || sEffect.Enhance.ID == 8 || sEffect.Enhance.ID == 17)
						{
							str2 = ((!flag2) ? "Heal" : string.Empty);
							flag2 = true;
						}
						else if (sEffect.Enhance.ID == 10 || (sEffect.Enhance.ID == 11 && !flag5))
						{
							str2 = ((!flag3) ? "Jump" : string.Empty);
							flag3 = true;
						}
						else if (sEffect.Enhance.ID == 5 || sEffect.Enhance.ID == 16)
						{
							str2 = ((!flag4) ? "EndMod" : string.Empty);
							flag4 = true;
						}
						else if ((enhancement.Name.IndexOf("Slow", StringComparison.Ordinal) > -1 & (sEffect.BuffMode == Enums.eBuffDebuff.DeBuffOnly && (sEffect.Enhance.ID == 6 || sEffect.Enhance.ID == 11 || sEffect.Enhance.ID == 19))) || sEffect.Enhance.ID == 21)
						{
							str2 = ((!flag5) ? "Slow Movement" : string.Empty);
							flag5 = true;
						}
						if (!string.IsNullOrEmpty(str2))
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append("\n");
							}
							stringBuilder.AppendFormat("{0}  enhancement (Sched. {1}: {2}%)", str2, Enum.GetName(sEffect.Schedule.GetType(), sEffect.Schedule), (scheduleMult * 100f).ToString(NumberFormatInfo.CurrentInfo));
						}
					}
				}
				if (!flag)
				{
					str = stringBuilder.ToString();
				}
				else
				{
					IPower power = new Power(enhancement.Power);
					power.ApplyGrantPowerEffects();
					int[] returnMask = new int[0];
					for (int index = 0; index <= power.Effects.Length - 1; index++)
					{
						if (power.Effects[index].EffectType == Enums.eEffectType.GrantPower)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append("\n");
							}
							stringBuilder.Append(power.Effects[index].BuildEffectString(true, "", false, false, false));
							string empty = string.Empty;
							for (int idEffect = 0; idEffect <= power.Effects.Length - 1; idEffect++)
							{
								power.Effects[idEffect].Stacking = Enums.eStacking.Yes;
								power.Effects[idEffect].Buffable = true;
								if (power.Effects[idEffect].Absorbed_EffectID == index)
								{
									power.GetEffectStringGrouped(idEffect, ref empty, ref returnMask, false, false, false);
								}
								if (returnMask.Length > 0)
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append("\n");
									}
									stringBuilder.AppendFormat("  {0}", empty);
									break;
								}
							}
							for (int index2 = 0; index2 <= power.Effects.Length - 1; index2++)
							{
								bool flag6 = false;
								for (int index3 = 0; index3 <= returnMask.Length - 1; index3++)
								{
									if (returnMask[index3] == index2)
									{
										flag6 = true;
										break;
									}
								}
								if (power.Effects[index2].Absorbed_EffectID == index && !flag6)
								{
									if (stringBuilder.Length > 0)
									{
										stringBuilder.Append("\n");
									}
									power.Effects[index2].Stacking = Enums.eStacking.Yes;
									power.Effects[index2].Buffable = true;
									stringBuilder.AppendFormat("  {0}", power.Effects[index2].BuildEffectString(false, "", false, false, false));
								}
							}
						}
						else if (!power.Effects[index].Absorbed_Effect && power.Effects[index].EffectType != Enums.eEffectType.Enhancement)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append("\n");
							}
							stringBuilder.Append(power.Effects[index].BuildEffectString(true, "", false, false, false));
						}
					}
					str = stringBuilder.ToString().Replace("Slf", "Self").Replace("Tgt", "Target");
				}
			}
		}
		return str;
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x000295D8 File Offset: 0x000277D8
	public object Clone()
	{
		return new I9Slot
		{
			Enh = this.Enh,
			Grade = this.Grade,
			IOLevel = this.IOLevel,
			RelativeLevel = this.RelativeLevel
		};
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x00029624 File Offset: 0x00027824
	public string GetRelativeString(bool onlySign)
	{
		if (onlySign)
		{
			switch (this.RelativeLevel)
			{
			case Enums.eEnhRelative.MinusThree:
				return "---";
			case Enums.eEnhRelative.MinusTwo:
				return "--";
			case Enums.eEnhRelative.MinusOne:
				return "-";
			case Enums.eEnhRelative.Even:
				return string.Empty;
			case Enums.eEnhRelative.PlusOne:
				return "+";
			case Enums.eEnhRelative.PlusTwo:
				return "++";
			case Enums.eEnhRelative.PlusThree:
				return "+++";
			case Enums.eEnhRelative.PlusFour:
				return "+4";
			case Enums.eEnhRelative.PlusFive:
				return "+5";
			}
		}
		else
		{
			switch (this.RelativeLevel)
			{
			case Enums.eEnhRelative.MinusThree:
				return "-3";
			case Enums.eEnhRelative.MinusTwo:
				return "-2";
			case Enums.eEnhRelative.MinusOne:
				return "-1";
			case Enums.eEnhRelative.Even:
				return string.Empty;
			case Enums.eEnhRelative.PlusOne:
				return "+1";
			case Enums.eEnhRelative.PlusTwo:
				return "+2";
			case Enums.eEnhRelative.PlusThree:
				return "+3";
			case Enums.eEnhRelative.PlusFour:
				return "+4";
			case Enums.eEnhRelative.PlusFive:
				return "+5";
			}
		}
		return string.Empty;
	}

	// Token: 0x04000601 RID: 1537
	private const float SuperiorMult = 1.25f;

	// Token: 0x04000602 RID: 1538
	public int Enh;

	// Token: 0x04000603 RID: 1539
	public Enums.eEnhRelative RelativeLevel;

	// Token: 0x04000604 RID: 1540
	public Enums.eEnhGrade Grade;

	// Token: 0x04000605 RID: 1541
	public int IOLevel;
}
