<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	string input = "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing.";
	
	int match = FindClosingParen(10, input);
	match.Dump();
}

// Define other methods and classes here
private int FindClosingParen(int start, string input)
{
	if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));
	if (input[start] != '(') throw new InvalidOperationException("Must start with an open parenthesis");
	
	int opens = 1; // O(1) additional space
	for (int i = start + 1; i < input.Length; i++) // O(n) time complexity
	{
		if (input[i] == '(') opens += 1;
		if (input[i] == ')') opens -= 1;
		if (opens == 0) return i;
	}
	return -1;
}