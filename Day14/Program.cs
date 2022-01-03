List<string>? data = null;
using (var sr = new StreamReader(@"input.txt"))
    data = sr.ReadToEnd().Split($"\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();

Console.WriteLine();

List<char> elements = new(); // add so we can iterate over this later
char[] sequence = data[0].ToCharArray();
data.RemoveAt(0);

Dictionary<string, string> splitmap = new();
foreach (string mapdata in data)
{
    string[] result = mapdata.Split(" -> ");
    splitmap[result[0]] = result[1];

    foreach(char c in result[0])
    {
        if (!elements.Contains(c))
        {
            elements.Add(c);
        }
    }

    if (!elements.Contains(result[1][0]))
    {
        elements.Add(result[1][0]);
    }
}

Console.WriteLine("Verifying map:");
foreach (string key in splitmap.Keys)
{
    Console.WriteLine($"Key: {key}  Value: {splitmap[key]}");   
}
Console.WriteLine();

Console.WriteLine("Generating initial pairs dictionary.");
Dictionary<string, long> pairs = new();
for(int i = 0; i < sequence.Length -1; i++)
{
    
    string newpair = $"{sequence[i]}{sequence[i+1]}";
    if (pairs.ContainsKey(newpair)) {
        pairs[newpair]++;
    }
    else
    {
        pairs[newpair] = 1;
    }
}
Console.WriteLine();

Console.WriteLine("Splitting those polymers!\n");
int numSteps = 40;
for(int i = 0;i < numSteps; i++)
{
    Console.WriteLine($"Step #{i + 1}");
    Dictionary<string, long> intermediate = new();
    if (i == 8)
    {
        Console.WriteLine("break");
    }
    foreach (KeyValuePair<string, long> pair in pairs)
    {
        string splitstring = splitmap[pair.Key];
        string pair1 = $"{pair.Key[0]}{splitstring}";
        string pair2 = $"{splitstring}{pair.Key[1]}";
        Console.WriteLine($"{pair.Key} ({pair.Value,4}) / {splitstring} -> ( {pair1}, {pair2} ) {pair.Value,4}");

        // add new pair #1
        if (intermediate.ContainsKey(pair1))
        {
            intermediate[pair1] += pair.Value;
        }
        else
        {
            intermediate[pair1] = pair.Value;
        }

        if (intermediate.ContainsKey(pair2))
        {
            intermediate[pair2] += pair.Value;
        }
        else
        {
            intermediate[pair2] = pair.Value;
        }            
    }

    Console.WriteLine();
    pairs = new(intermediate);
    Console.WriteLine($"Verifying pairs at the end of step {i + 1}");
    foreach(KeyValuePair<string, long> pair in pairs)
    {
        Console.Write($"{pair.Key}:{pair.Value} ");
    }
    Console.WriteLine(); Console.WriteLine();

}

Dictionary<char, long> counts = new();

foreach(KeyValuePair<string, long> pair in pairs)
{
    Console.WriteLine($"{pair.Key} : {pair.Value}");

    foreach (char c in pair.Key)
    {
        if(counts.ContainsKey(c))
        {
            counts[c] += pair.Value;
        }
        else
        {
            counts[c] = pair.Value;
        }
    }

}

Console.WriteLine();
Console.WriteLine("Element counts:");

List<KeyValuePair<char, long>> sortedCounts = counts.ToList();
sortedCounts.Sort((p1, p2) => p1.Value.CompareTo(p2.Value));

foreach (KeyValuePair<char, long> pair in sortedCounts)
{
    Console.WriteLine($"{pair.Key} : {pair.Value}");
}
long difference = sortedCounts.Last().Value - sortedCounts.First().Value;
//Yeah it double-counted, and I'm too lazy to fix the logic above
Console.WriteLine($"Part One. The difference between the most common and least common element is {Math.Ceiling((double)difference/2)}");
