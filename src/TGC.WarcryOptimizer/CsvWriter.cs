using System.Text;
using TGC.WarcryOptimizer.Models;

namespace TGC.WarcryOptimizer;
internal class CsvWriter
{
	private static string[] headers = new string[] { "Points", "Avg. Hits", "Total Hits", "Avg. Strength", "Total Strength", "Avg. Move", "Total Move", "Avg. Toughness", "Total Toughness", "Avg. Wounds", "Total Wounds", "Units" };

	public static void WriteToFile(IEnumerable<OptimizedResult> results)
	{
		var csvBuilder = new StringBuilder();
		csvBuilder.AppendLine(string.Join(";", headers));
		var properties = typeof(OptimizedResult).GetProperties();
		foreach (var item in results)
		{
			var distinctCount = item.Units.GroupBy(i => i.Name).ToDictionary(i => i.Key, i => item.Units.Count(u => u.Name == i.Key));

			csvBuilder.Append($"{item.TotalPoints};");
			csvBuilder.Append($"{string.Format("{0:N2}", item.Units.Average(u => u.Attacks.Sum(a => a.Hits)))};");
			csvBuilder.Append($"{item.Units.Sum(u => u.Attacks.Sum(a => a.Hits))};");

			csvBuilder.Append($"{string.Format("{0:N2}", item.Units.Average(u => u.Attacks.Sum(a => a.Strenght)))};");
			csvBuilder.Append($"{item.Units.Sum(u => u.Attacks.Sum(a => a.Strenght))};");

			csvBuilder.Append($"{string.Format("{0:N2}", item.Units.Average(u => u.Movement))};");
			csvBuilder.Append($"{item.Units.Sum(u => u.Movement)};");

			csvBuilder.Append($"{string.Format("{0:N2}", item.Units.Average(u => u.Toughness))};");
			csvBuilder.Append($"{item.Units.Sum(u => u.Toughness)};");

			csvBuilder.Append($"{item.Units.Average(u => u.Wounds)};");
			csvBuilder.Append($"{item.Units.Sum(u => u.Wounds)};");

			csvBuilder.Append($"{string.Join(',', distinctCount.Select(u => $" {u.Key} x{u.Value}"))};");

			csvBuilder.AppendLine();
		}

		File.WriteAllText("DataSheet.csv", csvBuilder.ToString());
	}
}
