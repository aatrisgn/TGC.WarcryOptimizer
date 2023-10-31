using TGC.WarcryOptimizer.Core.Models.Domain;
using TGC.WarcryOptimizer.Extensions;
using TGC.WarcryOptimizer.Models;
using TGC.WarcryOptimizer.Services.Abstractions;

namespace TGC.WarcryOptimizer.Services.Implementations;
internal class OptimizationService : IOptimizedListService
{
	public OptimizedResult GetOptimizationForUnitList(IList<Unit> unitList, Dictionary<string, Unit> lookupDictionary)
	{
		var expandedList = unitList.SelectMany(u =>
		{
			var innerList = new List<Unit>();

			for (var i = 0; i < u.MaximumAmounts; i++)
			{
				if (u.Type == UnitType.Hero)
				{
					innerList.Add(Unit.NewHero(u.Name, u.Points, u.Movement, u.Toughness, u.Wounds));
				}
				else
				{
					innerList.Add(Unit.NewFighter(u.Name, u.Points, u.Movement, u.Toughness, u.Wounds));
				}
			}

			return innerList;
		}).ToList();

		expandedList.Shuffle();
		var optimizationResult = new OptimizedResult();

		while (optimizationResult.TotalPoints < 1000 && optimizationResult.Units.Count < 15)
		{
			var availableUnit = expandedList.FirstOrDefault(u =>
			{
				var tooManyHeroTypes = u.Type == UnitType.Hero && optimizationResult.Units.Count(u => u.Type == UnitType.Hero) > 2;
				var abovePointLine = optimizationResult.TotalPoints + u.Points < 1000;
				var notAlreadyIncluded = optimizationResult.Units.Where(innerUnit => innerUnit.Name == u.Name).Count() < lookupDictionary[u.Name].MaximumAmounts;

				return abovePointLine && notAlreadyIncluded && !tooManyHeroTypes;
			});

			if (availableUnit == null)
			{
				break;
			}

			optimizationResult.TotalPoints += availableUnit.Points;
			optimizationResult.Units.Add(unitList.First(u => u.Name == availableUnit.Name));
		}

		return optimizationResult;
	}
}
