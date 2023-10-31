using TGC.WarcryOptimizer.Models;

namespace TGC.WarcryOptimizer.Services.Abstractions;

public interface ICsvService
{
	void WriteToFile(IEnumerable<OptimizedResult> results);
}
