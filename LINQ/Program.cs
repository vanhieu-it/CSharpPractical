using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Student> students = new List<Student>
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18, Marks = 90, City = "New York" },
                new Student() { StudentID = 2, StudentName = "Steve", Age = 21, Marks = 80, City = "London" },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25, Marks = 95, City = "California" },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20, Marks = 85, City = "New York" },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 31, Marks = 60, City = "New York" },
                new Student() { StudentID = 6, StudentName = "Chris", Age = 17, Marks = 70, City = "California" },
                new Student() { StudentID = 7, StudentName = "Rob", Age = 19, Marks = 50, City = "London" },
                new Student() { StudentID = 8, StudentName = "David", Age = 23, Marks = 75, City = "New York" },
                new Student() { StudentID = 9, StudentName = "Kenneth", Age = 29, Marks = 88, City = "California" },
                new Student() { StudentID = 10, StudentName = "Tom", Age = 26, Marks = 65, City = "London" }
            };

            //1. Find all students whose name starts with 'R'
           /* var studentsNameStartsWithR = from student in students
                                          where student.StudentName.StartsWith("R")
                                          select student;*/
           var studentsNameStartsWithR = students.Where(s => s.StudentName.StartsWith("R")).ToList();
            Console.WriteLine("Students whose name starts with 'R':");
            foreach (var student in studentsNameStartsWithR)
            {
                DisplayStudentInfo(student);
            }

            //2. Find student have id = 5
            var studentId5 = students.Where(s => s.StudentID == 5).FirstOrDefault();
            Console.WriteLine("\nStudent with ID = 5:");
            DisplayStudentInfo(studentId5);
            //3. Find student max marks
            var studentMaxMarks = students.Max(s => s.Marks);
            var studentWithMaxMarks = students.Where(s => s.Marks == studentMaxMarks).FirstOrDefault();
            Console.WriteLine("\nStudent with max marks:");
            DisplayStudentInfo(studentWithMaxMarks);
            //4. Find student min marks
            var studentMinMarks = students.Min(s => s.Marks);
            var studentWithMinMarks = students.Where(s => s.Marks == studentMinMarks).FirstOrDefault();
            Console.WriteLine("\nStudent with min marks:");
            DisplayStudentInfo(studentWithMinMarks);

            //5. Find student average marks
            var studentAverageMarks = students.Average(s => s.Marks);
            Console.Write("\nAverage marks of students: ");
            Console.WriteLine(studentAverageMarks);

            //6. Find student count
            var studentCount = students.Count();
            Console.Write("\nTotal number of students: ");
            Console.WriteLine(studentCount);

            //7. Find student count whose marks are greater than 80
            var studentCountMarksGreaterThan80 = students.Count(s => s.Marks > 80);
            Console.Write("\nTotal number of students whose marks are greater than 80: ");
            Console.WriteLine(studentCountMarksGreaterThan80);

            //8. Find all student whose marks are greater than 80 and from New York
            var studentsMarksGreaterThan80FromNewYork = students.Where(s => s.Marks > 80 && s.City == "New York").ToList();
            Console.WriteLine("\nStudents whose marks are greater than 80 and from New York:");
            foreach (var student in studentsMarksGreaterThan80FromNewYork)
            {
                DisplayStudentInfo(student);
            }

            //9. Display all students and check if mask is greater than 70 then display 'Pass' else 'Fail'
            Console.WriteLine("\nStudents and their status:");
            foreach (var student in students)
            {
                Console.WriteLine(student.StudentID + " - " + student.StudentName + " - Marks: " + student.Marks + " - Result: " + (student.Marks > 70 ? "Pass" : "Fail"));
            }

            Console.ReadKey();
        }
        private static void DisplayStudentInfo(Student student)
        {
            Console.WriteLine(student.StudentID + " - " + student.StudentName + " - Age: " + student.Age + " - Marks: " + student.Marks + " - City: " + student.City);
        }
    }
}
