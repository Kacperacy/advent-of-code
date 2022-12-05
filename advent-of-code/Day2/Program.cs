string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day2\data.txt";

Dictionary<string, int> playerMoves= new() 
{
    { "X", 1 },
    { "Y", 2 },
    { "Z", 3 }
};

List<Tuple<string, string>> games = File.ReadAllLines(fileToRead)
    .Select(p => p.Split(' '))
    .Select(p => new Tuple<string, string>(p[0], p[1]))
    .ToList();

Console.WriteLine("Part1: " + Part1(games).ToString());
Console.WriteLine("Part2: " + Part2(games).ToString());


int Part1(List<Tuple<string, string>> games)
{
    int score = 0;

    foreach (var game in games)
    {
        score += playerMoves[game.Item2];
        score += GetGameResult(game);
    }

    return score;
}

int Part2(List<Tuple<string, string>> games)
{
    int score = 0;

    foreach (var game in games)
    {
        var gameUpdated = new Tuple<string, string>(game.Item1, GetMove(game));
        score += playerMoves[gameUpdated.Item2];
        score += GetGameResult(gameUpdated);
    }

    return score;
}

string GetMove(Tuple<string, string> game)
{
    if (game.Item2 == "X")
        foreach (var move in playerMoves)
        {
            if(GetGameResult(new Tuple<string, string>(game.Item1, move.Key)) == (int)GameResultValue.Lose)
            {
                return move.Key;
            }
        }
    if (game.Item2 == "Y")
        foreach (var move in playerMoves)
        {
            if (GetGameResult(new Tuple<string, string>(game.Item1, move.Key)) == (int)GameResultValue.Draw)
            {
                return move.Key;
            }
        }
    if (game.Item2 == "Z")
        foreach (var move in playerMoves)
        {
            if (GetGameResult(new Tuple<string, string>(game.Item1, move.Key)) == (int)GameResultValue.Win)
            {
                return move.Key;
            }
        }
    return "";
}

int GetGameResult(Tuple<string, string> game)
{
    if (game.Item1 == "A")
    {
        if (game.Item2 == "X")
            return (int)GameResultValue.Draw;
        if (game.Item2 == "Y")
            return (int)GameResultValue.Win;
        if (game.Item2 == "Z")
            return (int)GameResultValue.Lose;
    }
    if (game.Item1 == "B")
    {
        if (game.Item2 == "X")
            return (int)GameResultValue.Lose;
        if (game.Item2 == "Y")
            return (int)GameResultValue.Draw;
        if (game.Item2 == "Z")
            return (int)GameResultValue.Win;
    }
    if (game.Item1 == "C")
    {
        if (game.Item2 == "X")
            return (int)GameResultValue.Win;
        if (game.Item2 == "Y")
            return (int)GameResultValue.Lose;
        if (game.Item2 == "Z")
            return (int)GameResultValue.Draw;
    }
    return 0;
}

enum GameResultValue
{
    Lose = 0,
    Draw = 3,
    Win = 6,
}