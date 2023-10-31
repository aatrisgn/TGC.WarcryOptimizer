using TGC.WarcryOptimizer.Core.Models.Domain;

namespace TGC.WarcryOptimizer.Services.Abstractions;

/// <summary>
/// Service for accessing hard-coded unit data & statistics. Should not be used in production.
/// </summary>
[Obsolete("Should only be used locally.")]
public interface IUnitDataService
{
	IList<Unit> LoadSoulblightData();
	IList<Unit> LoadDuardinData();
	IList<Unit> LoadSlaveToDarknessData();
}
