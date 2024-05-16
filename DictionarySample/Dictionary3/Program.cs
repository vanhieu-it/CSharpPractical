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

        // Kiểm tra sự tồn tại của khóa
        if (dictionary.ContainsKey(2))
        {
            Console.WriteLine("Key 2 exists.");
        }

        // Xóa phần tử
        dictionary.Remove(2);
        Console.WriteLine("Removed Key 2.");

        // Hiển thị lại nội dung
        foreach (var item in dictionary)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}
