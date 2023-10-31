using TGC.WarcryOptimizer.Core.Models.Domain;
using TGC.WarcryOptimizer.Models;

namespace TGC.WarcryOptimizer.Services.Abstractions;

public interface IOptimizedListService
{
	OptimizedResult GetOptimizationForUnitList(IList<Unit> unitList, Dictionary<string, Unit> lookupDictionary);
}
