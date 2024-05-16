using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        ConcurrentDictionary<int, ConcurrentBag<string>> dataStore = new ConcurrentDictionary<int, ConcurrentBag<string>>();

        // Giả sử có 10 tác vụ đồng thời
        Parallel.For(0, 10, i =>
        {
            var bag = dataStore.GetOrAdd(i, new ConcurrentBag<string>());
            for (int j = 0; j < 10; j++)
            {
                bag.Add($"Value {i}-{j}");
            }
        });

        // Hiển thị nội dung
        foreach (var kvp in dataStore)
        {
            Console.WriteLine($"Key: {kvp.Key}");
            foreach (var value in kvp.Value)
            {
                Console.WriteLine($"  {value}");
            }
        }
    }
}
