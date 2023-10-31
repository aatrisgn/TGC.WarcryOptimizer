using TGC.WarcryOptimizer.Core.Models.Requests;
using TGC.WarcryOptimizer.Core.Models.Response;

namespace TGC.WarcryOptimizer.Services.Abstractions;

public interface IFactionService
{
	Task<FactionResponse> CreateFaction(FactionRequest factionRequest);
	Task<FactionResponse> GetAllFactions();
}
