namespace TGC.WarcryOptimizer.Models;

internal class Unit
{
	public static Unit NewFighter(string name, int points, int movement, int toughness, int wounds)
	{
		return new Unit
		{
			Name = name,
			Points = points,
			Movement = movement,
			Toughness = toughness,
			Wounds = wounds,
			Type = UnitType.Fighter,
			Attacks = Enumerable.Empty<Attack>()
		};
	}

	public static Unit NewHero(string name, int points, int movement, int toughness, int wounds)
	{
		return new Unit
		{
			Name = name,
			Points = points,
			Movement = movement,
			Toughness = toughness,
			Wounds = wounds,
			Type = UnitType.Hero,
			Attacks = Enumerable.Empty<Attack>()
		};
	}

	public Unit SetMaxAmounts(int maximumAmount)
	{
		MaximumAmounts = maximumAmount;
		return this;
	}

	public Unit AddAttacks(params Attack[] attack)
	{
		Attacks = attack;
		return this;
	}

	public required string Name { get; set; }
	public int Points { get; set; }
	public int Movement { get; set; }
	public int Toughness { get; set; }
	public int Wounds { get; set; }
	public int MaximumAmounts { get; set; }
	public UnitType Type { get; set; }
	public required IEnumerable<Attack> Attacks { get; set; }
}
