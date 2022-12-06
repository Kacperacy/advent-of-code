using System.Linq;

string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day6\data.txt";

string value = File.ReadAllLines(fileToRead).ToList().FirstOrDefault().ToString();

Part1(value);
Part2(value);

void Part1(string value)
{
	for (int i = 0; i < value.Length - 4; i++)
    {
        List<char> header = value.Substring(i, 4).ToCharArray().ToList();

        if (!(header.Distinct().Count() < 4))
        {
            Console.WriteLine(i + 4);
            return;
        }
    }
}

void Part2(string value)
{
    for (int i = 0; i < value.Length - 14; i++)
    {
        List<char> header = value.Substring(i, 14).ToCharArray().ToList();

        if (!(header.Distinct().Count() < 14))
        {
            Console.WriteLine(i + 14);
            return;
        }
    }
}