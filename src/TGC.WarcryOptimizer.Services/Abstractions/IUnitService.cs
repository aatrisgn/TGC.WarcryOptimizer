using TGC.WarcryOptimizer.Core.Models.Requests;
using TGC.WarcryOptimizer.Core.Models.Response;

namespace TGC.WarcryOptimizer.Services.Abstractions;

public interface IUnitService
{
	Task<UnitResponse> CreateUnit(Guid factionId, UnitRequest unitRequest);
	Task<IEnumerable<FactionResponse>> GetByFactionId(Guid factionId);
}
