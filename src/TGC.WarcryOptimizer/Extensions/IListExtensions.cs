﻿namespace TGC.WarcryOptimizer.Extensions;
public static class IListExtensions
{
	/// <summary>
	/// Used to shuffle the items within a list.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="list"></param>
	public static void Shuffle<T>(this IList<T> list)
	{
		var rng = new Random();

		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
}
