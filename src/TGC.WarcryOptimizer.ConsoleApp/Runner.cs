using Microsoft.Extensions.Logging;
using TGC.WarcryOptimizer.Models;
using TGC.WarcryOptimizer.Services.Abstractions;

namespace TGC.WarcryOptimizer.ConsoleApp;
internal class Runner : IRunner
{
	private readonly IUnitDataService _unitDataService;
	private readonly IOptimizedListService _optimizedListService;
	private readonly ICsvService _csvService;
	private readonly ILogger<Runner> _logger;
	public Runner(IUnitDataService unitDataService, IOptimizedListService optimizedListService, ICsvService csvService, ILogger<Runner> logger)
	{
		_unitDataService = unitDataService;
		_optimizedListService = optimizedListService;
		_csvService = csvService;
		_logger = logger;
	}

	public void Run()
	{
		var availableUnits = _unitDataService.LoadRuinationData();

		var availableUnitsDictionary = availableUnits.ToDictionary(u => u.Name, u => u);

		double maximumCombinations = 1;

		for (var i = 0; i < availableUnits.Count(); i++)
		{
			if (i > 14)
			{
				break;
			}
			maximumCombinations *= Math.Pow((availableUnits.Count() - i), availableUnits[i].MaximumAmounts);
		}

		_logger.LogInformation($"Combinations: {maximumCombinations}");

		var unitLists = new HashSet<OptimizedResult>();

		var running = true;
		var counter = 0;
		var triesSinceFoundCombination = 0;

		while (running)
		{
			var optimizationResult = _optimizedListService.GetOptimizationForUnitList(availableUnits, availableUnitsDictionary);

			var added = unitLists.Add(optimizationResult);

			if (added)
			{
				triesSinceFoundCombination = 0;
				_logger.LogInformation($"Located team with {optimizationResult.TotalPoints} points.");
			}

			counter++;
			triesSinceFoundCombination++;

			if (counter > maximumCombinations || triesSinceFoundCombination > 500_000) //Arbitrary number. Not sure whether it should be higher.
			{
				running = false;
			}
		}

		var cheapestUnit = availableUnits.OrderBy(u => u.Points).First().Points;

		var orderedList = unitLists.Where(u => u.TotalPoints > (1000 - cheapestUnit))
			.OrderByDescending(u => u.TotalPoints)
			.ThenByDescending(u => u.Units.Average(u => u.Attacks.Sum(a => a.Hits)))
			.ThenByDescending(u => u.Units.Average(u => u.Toughness))
			.ThenByDescending(u => u.Units.Sum(u => u.Wounds))
		.ToList();

		_csvService.WriteToFile(orderedList);
	}
}
