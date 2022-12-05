string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day3\data.txt";

List<string> values = File.ReadAllLines(fileToRead).ToList();

Console.WriteLine("Part1: " + Part1(values));
Console.WriteLine("Part2: " + Part2(values));

int Part1(List<string> values)
{
    int result = 0;

    foreach (string backpack in values)
    {
        string items1 = backpack.Substring(0, backpack.Length/2);
        string items2 = backpack.Substring(backpack.Length / 2, backpack.Length/2);

        char item = items1.Where(items2.Contains).FirstOrDefault();

        if (char.IsAsciiLetterLower(item))
        {
            result += item - 96;
        }
        else if (char.IsAsciiLetterUpper(item))
        {
            result += item - 38;
        }
    }

    return result;
}

int Part2(List<string> values)
{
    int result = 0;

    for (int i = 0; i <= values.Count / 3 - 1; i++)
    {
        List<char> team1 = values.Skip(i * 3).FirstOrDefault().ToCharArray().ToList();
        List<char> team2 = values.Skip(i * 3 + 1).FirstOrDefault().ToCharArray().ToList();
        List<char> team3 = values.Skip(i * 3 + 2).FirstOrDefault().ToCharArray().ToList();

        char item = team1.Where(p => team2.Contains(p) && team3.Contains(p)).FirstOrDefault();

        if (char.IsAsciiLetterLower(item))
        {
            result += item - 96;
        }
        else if (char.IsAsciiLetterUpper(item))
        {
            result += item - 38;
        }
    }

    return result;
}
