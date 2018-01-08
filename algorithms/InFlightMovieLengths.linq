<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	int flightLength = 100;
	
	int[] movieLengthsOhN2 = new[] { 30, 5, 40, 50, 100, 61, 75, 90 };
	bool canWatchOhN2 = CanWatchTwoOhN2(flightLength, movieLengthsOhN2);
	canWatchOhN2.Dump();

	int[] movieLengthsOhN = new[] { 30, 60, 50, 60 };
	bool canWatchOhN = CanWatchTwoOhN(flightLength, movieLengthsOhN);
	canWatchOhN.Dump();

	int[] movieLengthsOhNDupes = new[] { 30, 60, 50, 60, 50 };
	bool canWatchOhNDupes = CanWatchTwoOhNDupes(flightLength, movieLengthsOhNDupes);
	canWatchOhNDupes.Dump();
}

private bool CanWatchTwoOhNDupes(int flightLength, int[] movieLengths)
{
	var remainders = new Dictionary<int, HashSet<int>>();
	for(int i = 0; i < movieLengths.Length; i++)
	{
		int remainder = flightLength - movieLengths[i];
		if (!remainders.ContainsKey(remainder))
		{
			var indexSet = new HashSet<int>();
			indexSet.Add(i);
			remainders.Add(flightLength - movieLengths[i], indexSet);
		}
		else
		{
			remainders[remainder].Add(i);
		}
	}
	for(int i = 0; i < movieLengths.Length; i++)
	{
		int length = movieLengths[i];
		if (remainders.ContainsKey(length) && remainders[length].Any(index => index != i)) 
		{
			return true;
		}
	}
	return false;
}

private bool CanWatchTwoOhN(int flightLength, int[] movieLengths)
{
	var remainders = new HashSet<int>();
	foreach (var length in movieLengths)
	{
		int remainder = flightLength - length;
		if (remainder == length) remainder = 0;
		remainders.Add(remainder);
	}
	foreach (var length in movieLengths)
	{
		if (remainders.Contains(length)) return true;
	}
	return false;
}

private bool CanWatchTwoOhN2(int flightLength, int[] movieLengths)
{
	for (int i = 0; i < movieLengths.Length; i++)
	{
		for (int j = i + 1; j < movieLengths.Length; j++)
		{
			if (movieLengths[i] + movieLengths[j] == flightLength)
			{
				return true;
			}
		}
	}
	return false;
}