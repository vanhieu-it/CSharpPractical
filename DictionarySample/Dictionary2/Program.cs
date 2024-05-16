using System;
using System.Collections.Generic;

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

        // Truy xuất giá trị theo khóa
        if (dictionary.TryGetValue(2, out string value))
        {
            Console.WriteLine($"Key 2 has value: {value}");
        }

        // Cập nhật giá trị
        dictionary[2] = "Two Updated";
        Console.WriteLine($"Updated Key 2: {dictionary[2]}");
    }
}
