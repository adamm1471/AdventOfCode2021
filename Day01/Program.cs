using System;
using System.IO;

List<int>? depths = new();

try
{
    using (var sr = new StreamReader(@"input.txt"))
    {
        String data = "";
        data = sr.ReadToEnd();
        depths = data.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)?.ToList();
    }
}
catch (Exception ex)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(ex.Message);
}

var watch = System.Diagnostics.Stopwatch.StartNew();
PartOne(depths);
PartTwo(depths);
watch.Stop();
Console.WriteLine($"This took {watch.ElapsedMilliseconds.ToString()} ms to complete.");


static void PartOne(List<int>? depths)
{

    var prev = -1;
    var count = 0;

    foreach (var depth in depths)
    {
        if (prev != -1 && depth > prev)
        {
            count++;

        }
        prev = depth;

    }
    Console.WriteLine("Part One Solution");
    Console.WriteLine(count);
    Console.WriteLine();

}

static void PartTwo(List<int>? depths)
{

    var count = 0;
    
    for(int pos = 0; pos < depths.Count; pos++)
    {
        if (pos >= 3)
        {

            var current_total = new List<int>() { depths[pos], depths[pos - 1], depths[pos - 2] }.Sum();
            var previous_total = new List<int>() { depths[pos - 1], depths[pos - 2], depths[pos - 3] }.Sum();

            if(current_total > previous_total)
            {
                count++;
            }
        }
    }
    Console.WriteLine("Part Two Solution");
    Console.WriteLine(count);
    Console.WriteLine();
}