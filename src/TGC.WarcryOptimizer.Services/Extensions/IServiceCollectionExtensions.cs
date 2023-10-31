using Microsoft.Extensions.DependencyInjection;
using TGC.WarcryOptimizer.Services.Abstractions;
using TGC.WarcryOptimizer.Services.Implementations;

namespace TGC.WarcryOptimizer.Services.Extensions;

public static class IServiceCollectionExtensions
{
	/// <summary>
	/// Configures all dependency injections for TGC.WarcryOptimizer.Services
	/// </summary>
	/// <param name="serviceCollection"></param>
	/// <returns></returns>
	public static IServiceCollection AddWarcryServices(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddScoped<IUnitService, UnitService>();
		serviceCollection.AddScoped<IFactionService, FactionService>();

		serviceCollection.AddScoped<ICsvService, CsvWriter>();
		serviceCollection.AddScoped<IUnitDataService, DataService>();
		serviceCollection.AddScoped<IOptimizedListService, OptimizationService>();

		return serviceCollection;
	}
}
