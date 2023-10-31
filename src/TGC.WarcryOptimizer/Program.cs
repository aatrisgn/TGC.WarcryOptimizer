using TGC.WarcryOptimizer;
using TGC.WarcryOptimizer.Models;

var availableUnits = DataService.LoadSlaveToDarknessData();

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

Console.WriteLine($"Combinations: {maximumCombinations}");

var unitLists = new HashSet<OptimizedResult>();

var running = true;
var counter = 0;
var triesSinceFoundCombination = 0;

while (running)
{
	var optimizationResult = OptimizationService.GetOptimizationForUnitList(availableUnits, availableUnitsDictionary);

	var added = unitLists.Add(optimizationResult);

	if (added)
	{
		triesSinceFoundCombination = 0;
		Console.WriteLine($"Located team with {optimizationResult.TotalPoints} points.");
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

CsvWriter.WriteToFile(orderedList);
