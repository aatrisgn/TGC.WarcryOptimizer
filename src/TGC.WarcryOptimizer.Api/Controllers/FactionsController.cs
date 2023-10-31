using Microsoft.AspNetCore.Mvc;
using TGC.WarcryOptimizer.Core.Models.Requests;
using TGC.WarcryOptimizer.Core.Models.Response;
using TGC.WarcryOptimizer.Services.Abstractions;

namespace TGC.WarcryOptimizer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FactionsController : ControllerBase
{
	private readonly IUnitService _unitService;
	private readonly IFactionService _factionService;
	public FactionsController(IUnitService unitService, IFactionService factionService)
	{
		_unitService = unitService;
		_factionService = factionService;
	}

	[HttpGet]
	public async Task<FactionResponse> GetFactions()
	{
		return await _factionService.GetAllFactions();
	}

	[HttpGet("{factionId}/units")]
	public async Task<IEnumerable<FactionResponse>> GetFactionUnits(Guid factionId)
	{
		return await _unitService.GetByFactionId(factionId);
	}

	[HttpPost]
	public async Task<FactionResponse> CreateFaction([FromBody] FactionRequest factionRequest)
	{
		return await _factionService.CreateFaction(factionRequest);
	}

	[HttpPost("{factionId}/units")]
	public async Task<UnitResponse> CreateUnit(Guid factionId, [FromBody] UnitRequest unitRequest)
	{
		return await _unitService.CreateUnit(factionId, unitRequest);
	}
}
