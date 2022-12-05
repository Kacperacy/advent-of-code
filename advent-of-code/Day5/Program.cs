string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day5\data.txt";

List<string> values = File.ReadAllLines(fileToRead).ToList();

List<Stack<char>> stacks = PrepareData(values.Take(8).ToList());

Part1(stacks, values.Skip(10).ToList());

stacks = PrepareData(values.Take(8).ToList());

Part2(stacks, values.Skip(10).ToList());

List<Stack<char>> PrepareData(List<string> lines)
{
    List<Stack<char>> result = new()
    {
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>(),
        new Stack<char>()
    };

    for (int i = lines.Count - 1; i >= 0; i--)
    {
        for (int j = 0; j < 9; j++)
        {
            char letter = lines[i][j * 4 + 1];
            if (char.IsLetter(letter))
                result[j].Push(letter);
        }
    }

    return result;
}

void Part1(List<Stack<char>> stacks, List<string> commands)
{
    string result = String.Empty;

    foreach (string command in commands)
    {
        List<string> splittedCommand = command.Split(' ').ToList();
        int move = int.Parse(splittedCommand[1]);
        int from = int.Parse(splittedCommand[3]) - 1;
        int to = int.Parse(splittedCommand[5]) - 1;

        for (int i = 0; i < move; i++)
        {
            stacks[to].Push(stacks[from].Pop());
        }
    }

    foreach (Stack<char> stack in stacks)
    {
        result += stack.Peek();
    }

    Console.WriteLine(result);
}

void Part2(List<Stack<char>> stacks, List<string> commands)
{
    string result = String.Empty;

    foreach (string command in commands)
    {
        List<char> temp = new();
        List<string> splittedCommand = command.Split(' ').ToList();
        int move = int.Parse(splittedCommand[1]);
        int from = int.Parse(splittedCommand[3]) - 1;
        int to = int.Parse(splittedCommand[5]) - 1;

        for (int i = 0; i < move; i++)
        {
            temp.Add(stacks[from].Pop());
        }

        for (int i = 0; i < temp.Count; i++)
        {
            stacks[to].Push(temp[temp.Count - i - 1]);
        }
    }

    foreach (Stack<char> stack in stacks)
    {
        result += stack.Peek();
    }

    Console.WriteLine(result);
}