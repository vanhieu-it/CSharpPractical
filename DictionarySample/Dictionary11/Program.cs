using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<HashSet<Tuple<string, int>>>> complexData = new Dictionary<string, List<HashSet<Tuple<string, int>>>>();

        complexData["Group1"] = new List<HashSet<Tuple<string, int>>>
        {
            new HashSet<Tuple<string, int>>
            {
                new Tuple<string, int>("Item1", 10),
                new Tuple<string, int>("Item2", 20)
            },
            new HashSet<Tuple<string, int>>
            {
                new Tuple<string, int>("Item3", 30),
                new Tuple<string, int>("Item4", 40)
            }
        };

        complexData["Group2"] = new List<HashSet<Tuple<string, int>>>
        {
            new HashSet<Tuple<string, int>>
            {
                new Tuple<string, int>("Item5", 50),
                new Tuple<string, int>("Item6", 60)
            }
        };

        foreach (var group in complexData)
        {
            Console.WriteLine($"Group: {group.Key}");
            foreach (var set in group.Value)
            {
                foreach (var tuple in set)
                {
                    Console.WriteLine($"  Item: {tuple.Item1}, Value: {tuple.Item2}");
                }
            }
        }
    }
}
