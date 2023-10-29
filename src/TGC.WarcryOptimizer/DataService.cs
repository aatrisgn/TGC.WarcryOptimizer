using TGC.WarcryOptimizer.Models;

namespace TGC.WarcryOptimizer;
internal class DataService
{
	public static IList<Unit> LoadSoulblightData()
	{
		return new List<Unit>
		{
			Unit.NewHero("Wight King", 155, 3, 5, 25).SetMaxAmounts(1).AddAttacks(Attack.NewMelee(1, 4, 4, 2, 5)),
			Unit.NewHero("Necromancer", 145, 4, 3, 20).SetMaxAmounts(1).AddAttacks(Attack.NewMelee(2, 3, 4, 1, 4), Attack.NewRange(3, 7, 2, 3, 3, 6)),
			Unit.NewFighter("Vargskyr", 185, 6, 4, 32).SetMaxAmounts(1).AddAttacks(Attack.NewMelee(2, 2, 5, 3, 6)),
			Unit.NewFighter("Kosarghi Nightguard", 140, 4, 4, 30).SetMaxAmounts(2).AddAttacks(Attack.NewMelee(2, 2, 5, 2, 5)),
			Unit.NewFighter("Vyrkos Blood-born", 135, 8, 3, 15).SetMaxAmounts(3).AddAttacks(Attack.NewMelee(1, 4, 4, 1, 5)),
			Unit.NewFighter("Skeleton w. ancient blade", 40, 3, 4, 8).SetMaxAmounts(5).AddAttacks(Attack.NewMelee(1, 3, 3, 1, 3)),
			Unit.NewFighter("Skeleton w. ancient spear", 40, 3, 4, 8).SetMaxAmounts(5).AddAttacks(Attack.NewMelee(1, 2, 3, 1, 4)),
			Unit.NewFighter("Deadwalker zombie", 40, 3, 3, 10).SetMaxAmounts(10).AddAttacks(Attack.NewMelee(1, 2, 3, 1, 4)),
			Unit.NewFighter("Blood Knights", 200, 8, 5, 25).SetMaxAmounts(5).AddAttacks(Attack.NewMelee(2, 3, 5, 2, 4))
		};
	}

	public static IList<Unit> LoadDuardinData()
	{
		return new List<Unit>
		{
			Unit.NewHero("Warden King", 150, 3, 5, 22).SetMaxAmounts(1),
			Unit.NewHero("Runelord", 120, 3, 4, 20).SetMaxAmounts(1),
			Unit.NewHero("Cogsmith", 140, 3, 4, 20).SetMaxAmounts(1),
			Unit.NewFighter("Ironbreaker", 60, 3, 5, 12).SetMaxAmounts(10),
			Unit.NewFighter("Hamerer", 80, 3, 4, 12).SetMaxAmounts(10),
			Unit.NewFighter("Irondrake", 85, 3, 4, 12).SetMaxAmounts(10),
			Unit.NewFighter("Longbeards w. Weapon & Shield", 70, 3, 5, 12).SetMaxAmounts(5),
			Unit.NewFighter("Longbeards w. Great Axe", 75, 3, 4, 12).SetMaxAmounts(5),
			Unit.NewFighter("Gyrocopter", 195, 12, 4, 22).SetMaxAmounts(1),
			Unit.NewFighter("Gyrobomber", 220, 10, 4, 25).SetMaxAmounts(1),
		};
	}
}
