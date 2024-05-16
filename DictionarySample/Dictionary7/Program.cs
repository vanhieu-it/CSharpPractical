using System;
using System.Collections.Generic;

public class CustomKey
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is CustomKey key)
        {
            return Id == key.Id && Name == key.Name;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}

class Program
{
    static void Main()
    {
        Dictionary<CustomKey, string> dictionary = new Dictionary<CustomKey, string>();

        CustomKey key1 = new CustomKey { Id = 1, Name = "Hieu" };
        CustomKey key2 = new CustomKey { Id = 2, Name = "Hang" };

        dictionary[key1] = "Engineer";
        dictionary[key2] = "Doctor";

        foreach (var item in dictionary)
        {
            Console.WriteLine($"Key: {item.Key.Id}-{item.Key.Name}, Value: {item.Value}");
        }
    }
}