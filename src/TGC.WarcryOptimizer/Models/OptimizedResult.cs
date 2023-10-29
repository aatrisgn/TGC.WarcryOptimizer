namespace TGC.WarcryOptimizer.Models;
internal class OptimizedResult
{
	public OptimizedResult()
	{
		TotalPoints = 0;
		Units = new List<Unit>();
	}

	public int TotalPoints { get; set; }
	public List<Unit> Units { get; set; }

	public override bool Equals(object? other)
	{
		if (other == null)
		{
			return false;
		}

		return this.GetHashCode() == other.GetHashCode();
	}

	public override int GetHashCode()
	{
		return TotalPoints.GetHashCode() ^ Units.Sum(u => u.GetHashCode());
	}
}
