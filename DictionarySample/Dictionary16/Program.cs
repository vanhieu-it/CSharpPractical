using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Dictionary với khóa là Tuple
        Dictionary<Tuple<string, string>, int> complexKeyDictionary = new Dictionary<Tuple<string, string>, int>
        {
            { Tuple.Create("Category1", "Subcategory1"), 100 },
            { Tuple.Create("Category1", "Subcategory2"), 200 },
            { Tuple.Create("Category2", "Subcategory1"), 300 },
            { Tuple.Create("Category2", "Subcategory3"), 400 }
        };

        // Hiển thị nội dung
        foreach (var kvp in complexKeyDictionary)
        {
            Console.WriteLine($"Key: {kvp.Key.Item1}-{kvp.Key.Item2}, Value: {kvp.Value}");
        }
    }
}
