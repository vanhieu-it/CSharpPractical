using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" },
            { 4, "Four" },
            { 5, "Five" }
        };

        // Sử dụng LINQ để tìm các phần tử có giá trị chứa chữ 'o'
        var results = dictionary.Where(kvp => kvp.Value.Contains("o"));

        foreach (var item in results)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}
