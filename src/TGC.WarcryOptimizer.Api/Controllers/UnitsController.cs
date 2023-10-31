using Microsoft.AspNetCore.Mvc;
using TGC.WarcryOptimizer.Core.Models.Requests;
using TGC.WarcryOptimizer.Core.Models.Response;
using TGC.WarcryOptimizer.Services.Abstractions;

namespace TGC.WarcryOptimizer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitsController : ControllerBase
{
	private readonly IUnitService _unitService;
	public UnitsController(IUnitService unitService)
	{
		_unitService = unitService;
	}

	[HttpPost]
	public async Task<UnitResponse> CreateUnit([FromBody] UnitRequest unitRequest)
	{
		throw new NotImplementedException();
	}
}
