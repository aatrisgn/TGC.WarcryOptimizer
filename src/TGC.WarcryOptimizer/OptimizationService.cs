﻿using TGC.WarcryOptimizer.Extensions;
using TGC.WarcryOptimizer.Models;

namespace TGC.WarcryOptimizer;
internal class OptimizationService
{
	public static OptimizedResult GetOptimizationForUnitList(IList<Unit> unitList, Dictionary<string, Unit> lookupDictionary)
	{
		var expandedList = unitList.SelectMany(u =>
		{
			var innerList = new List<Unit>();

			for (int i = 0; i < u.MaximumAmounts; i++)
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
				var abovePointLine = optimizationResult.TotalPoints + u.Points < 1000;
				var notAlreadyIncluded = optimizationResult.Units.Where(innerUnit => innerUnit.Name == u.Name).Count() < lookupDictionary[u.Name].MaximumAmounts;

				return abovePointLine && notAlreadyIncluded;
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
