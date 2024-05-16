using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public List<Employee> TeamMembers { get; set; }
}

class Program
{
    static void Main()
    {
        Dictionary<int, Project> projects = new Dictionary<int, Project>
        {
            {
                1, new Project
                {
                    ProjectId = 1,
                    ProjectName = "Project A",
                    TeamMembers = new List<Employee>
                    {
                        new Employee { Id = 1, Name = "Alice" },
                        new Employee { Id = 2, Name = "Bob" }
                    }
                }
            },
            {
                2, new Project
                {
                    ProjectId = 2,
                    ProjectName = "Project B",
                    TeamMembers = new List<Employee>
                    {
                        new Employee { Id = 3, Name = "Charlie" },
                        new Employee { Id = 1, Name = "Alice" }
                    }
                }
            }
        };

        // Tìm các dự án mà Alice tham gia
        var aliceProjects = projects.Values
                                    .Where(p => p.TeamMembers.Any(e => e.Name == "Alice"))
                                    .Select(p => p.ProjectName);

        Console.WriteLine("Projects involving Alice:");
        foreach (var project in aliceProjects)
        {
            Console.WriteLine(project);
        }
    }
}
