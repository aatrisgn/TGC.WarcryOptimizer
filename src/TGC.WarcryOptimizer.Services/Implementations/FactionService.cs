using TGC.WarcryOptimizer.Core.Models.Requests;
using TGC.WarcryOptimizer.Core.Models.Response;
using TGC.WarcryOptimizer.Services.Abstractions;

namespace TGC.WarcryOptimizer.Services.Implementations;

internal class FactionService : IFactionService
{
	public Task<FactionResponse> CreateFaction(FactionRequest factionRequest)
	{
		throw new NotImplementedException();
	}

	public Task<FactionResponse> GetAllFactions()
	{
		throw new NotImplementedException();
	}
}
