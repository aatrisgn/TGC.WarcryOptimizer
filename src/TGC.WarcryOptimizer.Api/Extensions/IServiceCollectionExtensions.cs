using TGC.WarcryOptimizer.Services.Extensions;

namespace TGC.WarcryOptimizer.Api.Extensions;

internal static class IServiceCollectionExtensions
{
	public static IServiceCollection ConfigureWarcryServiceCollection(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		serviceCollection.AddEndpointsApiExplorer();
		serviceCollection.AddSwaggerGen();
		serviceCollection.AddWarcryServices();

		return serviceCollection;
	}
}
