using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Khởi tạo Dictionary
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        // Thêm phần tử
        dictionary.Add(1, "One");
        dictionary.Add(2, "Two");
        dictionary.Add(3, "Three");

        // Cách khác để thêm phần tử
        dictionary[4] = "Four";
        dictionary[5] = "Five";

        // Hiển thị nội dung
        foreach (var item in dictionary)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}
