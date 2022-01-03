/* 
 * Day 12: Passage Pathing
 * 
 */

void SaveForLater()
{
    // testdata
    HashSet<string> nodes = new();
    List<HashSet<string>> nodeEdges = new();

    string datastring = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    string[] lines = datastring.Split("\n");
    foreach (string ln in lines)
    {
        HashSet<string> tempnodes = new();

        string[] tsplit = ln.Split("-");
        foreach (string t in tsplit)
        {
            tempnodes.Add(t.Trim());
        }


        foreach (string t in tsplit)
        {
            nodes.Add(t.Trim());
        }
        nodeEdges.Add(tempnodes);
    }

    foreach (var node in nodes)
    {
        Console.WriteLine($"Node: '{node.ToString()}'");
    }

    foreach (var ne in nodeEdges)
    {
        Console.WriteLine(String.Join(" ", ne));
        if (ne.Contains("start"))
        {
            Console.WriteLine("Start node!");
        }
    }

}


