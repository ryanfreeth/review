<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	string input1 = "After beating the eggs, Dana read the next step: Add milk and eggs, then add flour and sugar.";
	var cloud = GetWordCloud(input1);
	cloud.Dump();

	string input2 = "We came, we saw, we conquered...then we ate Bill's (Mille-Feuille) cake. The bill came to five dollars.";
	var cloud2 = GetWordCloud(input2);
	cloud2.Dump();
}

private IDictionary<string, int> GetWordCloudOhN2(string input)
{
	var cloud = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
	var words = input.Split(new[] { ' ', '.', ',', ':', ';', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
	foreach (var word in words)
	{
		if (cloud.ContainsKey(word))
		{
			cloud[word] += 1;
		}
		else
		{
			cloud[word] = 1;
		}
	}
	return cloud;
}