using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Advanced
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool hide = true;

            #region Simple LINQ
            if (!hide)//true to run this block, false to skip this block
            {
                
                List<Employee> employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "Zane", Department = "HR", Salary = 60000 },
                new Employee { EmployeeID = 2, Name = "Lanie", Department = "IT", Salary = 50000 },
                new Employee { EmployeeID = 3, Name = "Jim", Department = "IT", Salary = 90000 },
                new Employee { EmployeeID = 4, Name = "Muzik", Department = "HR", Salary = 60000 },
                new Employee { EmployeeID = 5, Name = "An", Department = "IT", Salary = 50000 }
            };

                //Group
                var employeeGroup = employees.GroupBy(x => x.Department);
                Console.WriteLine("Group by Department");
                foreach (var group in employeeGroup)
                {
                    Console.WriteLine(group.Key);
                    foreach (var emp in group)
                    {
                        Console.WriteLine(emp.Name);
                    }
                }
                Console.WriteLine("===================================================");
                //Group with Composite Keys
                var employeeDepartmentGroup = employees.GroupBy(x => new { x.Department, x.Salary });
                Console.WriteLine("Group by Department and Salary");
                foreach (var group in employeeDepartmentGroup)
                {
                    Console.WriteLine(group.Key.Department + " - " + group.Key.Salary);
                    foreach (var emp in group)
                    {
                        Console.WriteLine(emp.Name);
                    }
                }
                Console.WriteLine("===================================================");
                //Group employee if salary > 60000 display 'Mid-Level' else 'Entry-Level' 
                var employeeGroupBySalary = employees.GroupBy(x => x.Salary > 60000 ? "Mid-Level:" : "Entry-Level:");
                Console.WriteLine("Group by Salary - Level");
                foreach (var group in employeeGroupBySalary)
                {
                    Console.WriteLine(group.Key);
                    foreach (var emp in group)
                    {
                        Console.WriteLine(emp.Name);
                    }
                }
                Console.WriteLine("===================================================");
            }
            #endregion

            #region Advanced LINQ
            if (hide)
            {
                List<Employee> MixEmployees = new List<Employee>()
            {
                new Director{ EmployeeID = 1, Name = "Hieu", Department = "Leadership", Salary = 60000, Permissions = "Full", AbleToHire = true },
                new Administrator{ EmployeeID = 2, Name = "Hang", Department = "HR", Salary = 50000, AbleToFire = true },
                new Director{ EmployeeID = 3, Name = "Thao", Department = "IT", Salary = 90000, Permissions = "Limited", AbleToHire = false },
                new Administrator{ EmployeeID = 4, Name = "Minh", Department = "Leadership", Salary = 60000, AbleToFire = false },
                new Employee{ EmployeeID = 5, Name = "An", Department = "IT", Salary = 50000 },
                new Employee{ EmployeeID = 6, Name = "Anh", Department = "IT", Salary = 50000 },
                new Director{ EmployeeID = 7, Name = "Hoa", Department = "Leadership", Salary = 90000, Permissions = "Full", AbleToHire = true },
                new Administrator{ EmployeeID = 8, Name = "Huong", Department = "HR", Salary = 60000, AbleToFire = true },
                new Employee{ EmployeeID = 9, Name = "Hai", Department = "IT", Salary = 50000 },
                new Employee{ EmployeeID = 10, Name = "Hien", Department = "IT", Salary = 50000 },
                new Administrator{ EmployeeID = 11, Name = "Hanh", Department = "HR", Salary = 60000, AbleToFire = true },
                new Director{ EmployeeID = 12, Name = "Huy", Department = "Leadership", Salary = 90000, Permissions = "Full", AbleToHire = false },
            };

                List<Director> lstDirectors = new List<Director>()
            {
                new Director{ EmployeeID = 1, Name = "Hieu", Department = "Leadership", Salary = 60000, Permissions = "Full", AbleToHire = true },
                new Director{ EmployeeID = 3, Name = "Thao", Department = "IT", Salary = 90000, Permissions = "Limited", AbleToHire = false },
                new Director{ EmployeeID = 7, Name = "Hoa", Department = "Leadership", Salary = 90000, Permissions = "Full", AbleToHire = true },
                new Director{ EmployeeID = 12, Name = "Huy", Department = "Leadership", Salary = 90000, Permissions = "Full", AbleToHire = false },
                new Director{ EmployeeID = 13, Name = "Huy", Department = "Leadership", Salary = 90000, Permissions = "Full", AbleToHire = false },
                new Director{ EmployeeID = 14, Name = "Binh", Department = "Leadership", Salary = 90000, Permissions = "Full", AbleToHire = true }
            };

                //OfType
                var directors = MixEmployees.OfType<Director>();
                Console.WriteLine("Directors");
                foreach (var director in directors)
                {
                    Console.WriteLine(director.Name);
                }
                Console.WriteLine("===================================================");

                //Join
                var joinEmployees = MixEmployees.Join(lstDirectors,
                    e => e.EmployeeID,
                    d => d.EmployeeID,
                    (e, d) => new
                    {
                        e.Name,
                        d.Department,
                        d.Permissions
                    });
                Console.WriteLine("Join Employees and Directors");
                foreach (var emp in joinEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department + " - " + emp.Permissions);
                }
                Console.WriteLine("===================================================");

                //GroupJoin
                var groupJoinEmployees = lstDirectors.GroupJoin(MixEmployees,
                    d => d.EmployeeID,
                    e => e.EmployeeID,
                    (d, e) => new
                    {
                        d.Name,
                        d.Department,
                        Employees = e
                    });
                Console.WriteLine("GroupJoin Directors and Employees");
                foreach (var group in groupJoinEmployees)
                {
                    Console.WriteLine(group.Name + " - " + group.Department);
                    foreach (var emp in group.Employees)
                    {
                        Console.WriteLine(emp.Name);
                    }
                }
                Console.WriteLine("===================================================");

                //SelectMany
                var selectManyEmployees = lstDirectors.SelectMany(d => MixEmployees.Where(e => e.Department == d.Department));
                Console.WriteLine("SelectMany Directors and Employees");
                foreach (var emp in selectManyEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //Concat
                var concatEmployees = lstDirectors.Concat(MixEmployees);
                Console.WriteLine("Concat Directors and Employees");
                foreach (var emp in concatEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //Union
                var unionEmployees = lstDirectors.Union(MixEmployees);
                Console.WriteLine("Union Directors and Employees");
                foreach (var emp in unionEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");
                //Distinct
                var distinctEmployees = unionEmployees.Distinct();
                Console.WriteLine("Distinct Directors and Employees");
                foreach (var emp in distinctEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //Except
                var exceptEmployees = unionEmployees.Except(MixEmployees);
                Console.WriteLine("Except Directors and Employees");
                foreach (var emp in exceptEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //Intersect
                var intersectEmployees = unionEmployees.Intersect(MixEmployees);
                Console.WriteLine("Intersect Directors and Employees");
                foreach (var emp in intersectEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //Generate a sequence of numbers
                var numbers = Enumerable.Range(1, 10);
                Console.WriteLine("Generate a sequence of numbers");
                foreach (var num in numbers)
                {
                    Console.WriteLine(num);
                }
                Console.WriteLine("===================================================");

                //repeat employee
                var repeatEmployees = Enumerable.Repeat(new Employee { Name = "An", Department = "IT", Salary = 50000 }, 5);
                Console.WriteLine("Repeat Employee");
                foreach (var emp in repeatEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //Partitioning
                var takeEmployees = MixEmployees.Take(5);
                Console.WriteLine("Take Employees");
                foreach (var emp in takeEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");
                //Skip
                var skipEmployees = MixEmployees.Skip(5);
                Console.WriteLine("Skip Employees");
                foreach (var emp in skipEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //TakeWhile
                var takeWhileEmployees = MixEmployees.TakeWhile(e => e.Salary < 60000);
                Console.WriteLine("TakeWhile Employees");
                foreach (var emp in takeWhileEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //SkipWhile
                var skipWhileEmployees = MixEmployees.SkipWhile(e => e.Salary < 60000);
                Console.WriteLine("SkipWhile Employees");
                foreach (var emp in skipWhileEmployees)
                {
                    Console.WriteLine(emp.Name + " - " + emp.Department);
                }
                Console.WriteLine("===================================================");

                //ElementAt
                var elementAtEmployee = MixEmployees.ElementAt(5);
                Console.WriteLine("ElementAt Employee");
                Console.WriteLine(elementAtEmployee.Name + " - " + elementAtEmployee.Department);
                Console.WriteLine("===================================================");

                //ElementAtOrDefault
                var elementAtOrDefaultEmployee = MixEmployees.ElementAtOrDefault(15);
                Console.WriteLine("ElementAtOrDefault Employee");
                if (elementAtOrDefaultEmployee != null)
                {
                    Console.WriteLine(elementAtOrDefaultEmployee.Name + " - " + elementAtOrDefaultEmployee.Department);
                }
                else
                {
                    Console.WriteLine("Employee not found");
                }
                Console.WriteLine("===================================================");

                //First
                var firstEmployee = MixEmployees.First();
                Console.WriteLine("First Employee");
                Console.WriteLine(firstEmployee.Name + " - " + firstEmployee.Department);
                Console.WriteLine("===================================================");

                //FirstOrDefault
                var firstOrDefaultEmployee = MixEmployees.FirstOrDefault();
                Console.WriteLine("FirstOrDefault Employee");
                Console.WriteLine(firstOrDefaultEmployee.Name + " - " + firstOrDefaultEmployee.Department);
                Console.WriteLine("===================================================");

                //Last
                var lastEmployee = MixEmployees.Last();
                Console.WriteLine("Last Employee");
                Console.WriteLine(lastEmployee.Name + " - " + lastEmployee.Department);
                Console.WriteLine("===================================================");

                //LastOrDefault
                var lastOrDefaultEmployee = MixEmployees.LastOrDefault();
                Console.WriteLine("LastOrDefault Employee");
                Console.WriteLine(lastOrDefaultEmployee.Name + " - " + lastOrDefaultEmployee.Department);
                Console.WriteLine("===================================================");

                //Single
                var singleEmployee = MixEmployees.Single(e => e.EmployeeID == 5);
                Console.WriteLine("Single Employee");
                Console.WriteLine(singleEmployee.Name + " - " + singleEmployee.Department);
                Console.WriteLine("===================================================");

                //SingleOrDefault
                var singleOrDefaultEmployee = MixEmployees.SingleOrDefault(e => e.EmployeeID == 15);
                Console.WriteLine("SingleOrDefault Employee");
                if (singleOrDefaultEmployee != null)
                {
                    Console.WriteLine(singleOrDefaultEmployee.Name + " - " + singleOrDefaultEmployee.Department);
                }
                else
                {
                    Console.WriteLine("Employee not found");
                }
                Console.WriteLine("===================================================");

                //Count
                var countEmployees = MixEmployees.Count();
                Console.WriteLine("Count Employees");
                Console.WriteLine(countEmployees);
                Console.WriteLine("===================================================");

                //Count with condition
                var countEmployeesWithCondition = MixEmployees.Count(e => e.Salary > 60000);
                Console.WriteLine("Count Employees with condition");
                Console.WriteLine(countEmployeesWithCondition);
                Console.WriteLine("===================================================");

                //Sum
                var sumSalary = MixEmployees.Sum(e => e.Salary);
                Console.WriteLine("Sum Salary");
                Console.WriteLine(sumSalary);
                Console.WriteLine("===================================================");
            }
            #endregion

            Console.ReadKey();
        }
    }
}
