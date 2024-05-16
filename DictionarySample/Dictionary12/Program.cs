using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Employee> employees = new Dictionary<int, Employee>
        {
            { 1, new Employee { Id = 1, Name = "John Doe", Salary = 50000 } },
            { 2, new Employee { Id = 2, Name = "Jane Smith", Salary = 60000 } }
        };

        // Serialization
        string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        // Deserialization
        var deserializedEmployees = JsonConvert.DeserializeObject<Dictionary<int, Employee>>(json);
        Console.WriteLine("\nDeserialized Dictionary:");
        foreach (var employee in deserializedEmployees)
        {
            Console.WriteLine($"Id: {employee.Key}, Name: {employee.Value.Name}, Salary: {employee.Value.Salary}");
        }
    }
}
