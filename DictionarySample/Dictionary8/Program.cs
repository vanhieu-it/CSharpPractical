using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<Dictionary<string, int>>> complexDictionary = new Dictionary<string, List<Dictionary<string, int>>>();

        complexDictionary["Category1"] = new List<Dictionary<string, int>>
        {
            new Dictionary<string, int> { { "Item1", 10 }, { "Item2", 20 } },
            new Dictionary<string, int> { { "Item3", 30 }, { "Item4", 40 } }
        };

        complexDictionary["Category2"] = new List<Dictionary<string, int>>
        {
            new Dictionary<string, int> { { "Item5", 50 }, { "Item6", 60 } },
            new Dictionary<string, int> { { "Item7", 70 }, { "Item8", 80 } }
        };

        foreach (var category in complexDictionary)
        {
            Console.WriteLine($"Category: {category.Key}");
            foreach (var dict in category.Value)
            {
                foreach (var item in dict)
                {
                    Console.WriteLine($"  Item: {item.Key}, Value: {item.Value}");
                }
            }
        }
    }
}
