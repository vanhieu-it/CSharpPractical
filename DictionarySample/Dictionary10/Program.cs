using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();
        // Môi trường đa luồng
        Parallel.For(0, 10000, i =>
        {
            concurrentDictionary.TryAdd(i, $"Value {i}");
        });

        foreach (var item in concurrentDictionary)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }
}
