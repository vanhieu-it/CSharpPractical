using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Dictionary lồng nhau
        Dictionary<string, Dictionary<string, int>> nestedDictionary = new Dictionary<string, Dictionary<string, int>>();

        nestedDictionary["Category1"] = new Dictionary<string, int>
        {
            { "Item1", 10 },
            { "Item2", 20 }
        };

        nestedDictionary["Category2"] = new Dictionary<string, int>
        {
            { "Item3", 30 },
            { "Item4", 40 }
        };

        // Hiển thị nội dung Dictionary lồng nhau
        foreach (var category in nestedDictionary)
        {
            Console.WriteLine($"Category: {category.Key}");
            foreach (var item in category.Value)
            {
                Console.WriteLine($"  Item: {item.Key}, Value: {item.Value}");
            }
        }
    }
}

