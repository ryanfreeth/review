<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var nums = new[] { 4, 5, 3, 2, 4, 25 };
	var nge = GetNextLargest(nums);
	nge.Dump();
}

private int[] GetNextLargest(int[] input)
{
	var result = new int[input.Length];
	var stack = new Stack<(int value, int index)>();
	stack.Push((input[0], 0));
	for(int i = 1; i < input.Length; i++)
	{
		if (stack.Count > 0)
		{
			var top = stack.Pop();
			while(input[i] > top.value)
			{
				result[top.index] = input[i];
				if (stack.Count == 0) break;
				top = stack.Pop();
			}
			if (top.value > input[i]) 
			{
				stack.Push(top);
			}
		}
		stack.Push((input[i], i));
	}
	while(stack.Count > 0)
	{
		var top = stack.Pop();
		result[top.index] = -1;
	}
	return result;
}
