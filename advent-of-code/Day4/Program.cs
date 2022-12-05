string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day4\data.txt";

List<List<string>> values = File.ReadAllLines(fileToRead).Select(p => p.Split(',').ToList()).ToList();

Console.WriteLine(Part1(values));
Console.WriteLine(Part2(values));

int Part1(List<List<string>> values)
{
    int result = 0;

    foreach(List<string> part in values)
    {
        int min1 = int.Parse(part[0].Split('-')[0]);
        int max1 = int.Parse(part[0].Split('-')[1]);
        int min2 = int.Parse(part[1].Split('-')[0]);
        int max2 = int.Parse(part[1].Split('-')[1]);

        if ((min1 <= min2 && max1 >= max2) || (min2 <= min1 && max2 >= max1))
            result++;
    }

    return result;
}

int Part2(List<List<string>> values)
{
    int result = 0;

    foreach (List<string> part in values)
    {
        int min1 = int.Parse(part[0].Split('-')[0]);
        int max1 = int.Parse(part[0].Split('-')[1]);
        int min2 = int.Parse(part[1].Split('-')[0]);
        int max2 = int.Parse(part[1].Split('-')[1]);

        if (max1 >= min2 && min1 <= max2)
            result++;
    }

    return result;
}