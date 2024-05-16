using System;
using System.Collections.Generic;
using System.Linq;

public static class DictionaryExtensions
{
    public static void PrintDictionary<K, V>(this Dictionary<K, V> dictionary)
    {
        foreach (var item in dictionary)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" }
        };

        // Sử dụng phương pháp mở rộng để in Dictionary
        dictionary.PrintDictionary();
    }
}
