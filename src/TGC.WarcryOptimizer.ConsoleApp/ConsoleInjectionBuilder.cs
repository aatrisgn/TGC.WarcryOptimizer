using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TGC.ConsoleBuilder.Abstractions;
using TGC.WarcryOptimizer.Services.Extensions;

namespace TGC.WarcryOptimizer.ConsoleApp;
internal class ConsoleInjectionBuilder : IConsoleInjectionBuilder
{
	public void Configure(IServiceCollection serviceCollection)
	{
		serviceCollection.AddLogging(builder => builder.AddConsole());
		serviceCollection.AddScoped<IRunner, Runner>();
		serviceCollection.AddWarcryServices();
	}
}
