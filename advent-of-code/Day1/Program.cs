string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day1\data.txt";

List<string> values = File.ReadAllLines(fileToRead).ToList();
List<int> calories = new();

int currentMax = 0;

foreach (var value in values)
{
    if(int.TryParse(value, out int valueInt))
    {
        currentMax += valueInt;
    }
    else
    {
        calories.Add(currentMax);
        currentMax = 0;
    }
}

Console.WriteLine("Part1: " + calories.Max());
Console.WriteLine("Part2: " + calories.OrderByDescending(p => p).Take(3).Sum());