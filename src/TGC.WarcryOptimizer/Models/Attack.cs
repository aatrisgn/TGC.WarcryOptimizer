namespace TGC.WarcryOptimizer.Models;

internal class Attack
{
	public AttackType Type { get; set; }
	public int MinRange { get; set; }
	public int MaxRange { get; set; }
	public int Hits { get; set; }
	public int Strenght { get; set; }
	public int HitDamage { get; set; }
	public int CriticalDamage { get; set; }

	public static Attack NewMelee(int range, int hits, int strength, int hitDamage, int criticalDamage)
	{
		return new Attack
		{
			MinRange = range,
			MaxRange = range,
			Hits = hits,
			Strenght = strength,
			HitDamage = hitDamage,
			CriticalDamage = criticalDamage,
			Type = AttackType.Melee
		};
	}

	public static Attack NewRange(int range, int hits, int strength, int hitDamage, int criticalDamage)
	{
		return new Attack
		{
			MinRange = range,
			MaxRange = range,
			Hits = hits,
			Strenght = strength,
			HitDamage = hitDamage,
			CriticalDamage = criticalDamage,
			Type = AttackType.Ranged
		};
	}
	public static Attack NewRange(int minRange, int maxRange, int hits, int strength, int hitDamage, int criticalDamage)
	{
		return new Attack
		{
			MinRange = minRange,
			MaxRange = maxRange,
			Hits = hits,
			Strenght = strength,
			HitDamage = hitDamage,
			CriticalDamage = criticalDamage,
			Type = AttackType.Ranged
		};
	}
}
