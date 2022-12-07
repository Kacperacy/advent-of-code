string fileToRead = @"C:\Users\kacper\source\repos\advent-of-code\advent-of-code\Day7\data.txt";

List<string> commands = File.ReadAllLines(fileToRead).ToList();

List<Directory> directory = PrepareData(commands);
Part1(directory);
Part2(directory);

List<Directory> PrepareData(List<string> commands)
{
    List<Directory> directory = new();

    Directory baseDirectory = new()
    {
        Name = "/"
    };

    directory.Add(baseDirectory);

    Directory currentDir = directory.First();

    foreach (string command in commands)
    {
        string cmd = command.Replace("$", "").Trim();
        string cmdType = cmd.Split(' ')[0];
        if (cmdType == "ls")
            continue;
        string cmdArg = cmd.Split(' ')[1];

        if (cmdType == "cd")
        {
            if(cmdArg == "..")
            {
                currentDir = currentDir.Parent;
            }
            else if (cmdArg == "/")
            {
                currentDir = baseDirectory;
            }
            else
            {
                currentDir = currentDir.Directories.Where(p => p.Name == cmdArg).First();
            }
        }
        else if(cmdType == "dir")
        {
            Directory newDir = new()
            {
                Name = cmdArg,
                Parent = currentDir,
            };

            currentDir.Directories.Add(newDir);
            directory.Add(newDir);
        }
        else if(int.TryParse(cmdType, out int fileSize))
        {
            FileClass newFile = new()
            {
                Name = cmdArg,
                Size = fileSize,
            };

            currentDir.Files.Add(newFile);
        }
    }

    return directory;
}

void Part1(List<Directory> directory)
{
    int result = 0;

    foreach (Directory dir in directory)
    {
        int filesSum = GetFileSum(dir);
        if (filesSum <= 100000)
            result += filesSum;
    }

    Console.WriteLine(result);
}

void Part2(List<Directory> directory)
{
    int diskSize = 70000000;
    int usedSpace = GetFileSum(directory.First());
    int unusedSpace = diskSize - usedSpace;
    int minSpaceRequired = 30000000 - unusedSpace;

    int minDirSize = 30000000;

    foreach (Directory dir in directory)
    {
        int filesSum = GetFileSum(dir);
        if (filesSum >= minSpaceRequired && filesSum < minDirSize)
            minDirSize = filesSum;
    }

    Console.WriteLine(minDirSize);
}

int GetFileSum(Directory dir)
{
    int result = dir.Files.Sum(p => p.Size);
    
    foreach(Directory childDir in dir.Directories)
    {
        result += GetFileSum(childDir);
    }

    return result;
}

class FileClass
{
    public string? Name { get; set; }
    public int Size { get; set; }
}

class Directory
{
    public int Id { get; set; } = 1;
    public string? Name { get; set; }
    public Directory Parent { get; set; }
    public List<Directory> Directories { get; set; } = new();
    public List<FileClass> Files { get; set; } = new();
}

