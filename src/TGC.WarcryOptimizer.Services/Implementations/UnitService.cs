using TGC.WarcryOptimizer.Core.Models.Requests;
using TGC.WarcryOptimizer.Core.Models.Response;
using TGC.WarcryOptimizer.Services.Abstractions;

namespace TGC.WarcryOptimizer.Services.Implementations;

internal class UnitService : IUnitService
{
	public Task<UnitResponse> CreateUnit(UnitRequest unitRequest)
	{
		throw new NotImplementedException();
	}

	public Task<UnitResponse> CreateUnit(Guid factionId, UnitRequest unitRequest)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<FactionResponse>> GetByFactionId(Guid factionId)
	{
		throw new NotImplementedException();
	}
}
