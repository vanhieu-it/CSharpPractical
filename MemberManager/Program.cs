using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MemberManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>
            {
                new Member
                {
                    FirstName = "Hieu",
                    LastName = "Do Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999,10,13),
                    PhoneNumber = "0123456789",
                    BirthPlace = "Long An",
                    IsGraduated = false
                },
                new Member
                {
                    FirstName = "Hang",
                    LastName = "Tran Thi Thu",
                    BirthPlace = "Lam Dong",
                    DateOfBirth = new DateTime(1999, 04, 01),
                    Gender = "Female",
                    PhoneNumber = "0987654321",
                    IsGraduated = true
                },
                new Member
                {
                    FirstName = "Hoa",
                    LastName = "Nguyen Thi",
                    BirthPlace = "Ha Noi",
                    DateOfBirth = new DateTime(1999, 12, 31),
                    IsGraduated = true,
                    Gender = "Female",
                    PhoneNumber = "0123456789",
                }
            };
            int option = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. List of member who is male: ");
                Console.WriteLine("2. Oldest member is: ");
                Console.WriteLine("3. Full name of members: ");
                Console.WriteLine("4. List members by birth year: ");
                Console.WriteLine("5. First person who was born in Long An is: ");
                Console.WriteLine();
                Console.Write("Enter key: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        ListMaleMembers(members);
                        break;
                    case 2:
                        OldestMember(members);
                        break;
                    case 3:
                        ListFullName(members);
                        break;
                    case 4:
                        ListMembersByBirthYear(members);
                        break;
                    case 5:
                        FirstPersonBornInLongAn(members);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }    
            while (option != 0);
        }

        public static void PrintMemberInfo(List<Member> members)
        {
            foreach (var member in members)
            {
                Console.WriteLine(member.PrintMemberInfo());
                Console.WriteLine();
            }
        }

        public static void ListMaleMembers(List<Member> members)
        {
            List<Member> list = new List<Member>();
            foreach (var member in members)
            {
                if(member.Gender == "Male")
                {
                    list.Add(member);
                }
            }
            PrintMemberInfo(list);
        }
        public static void OldestMember(List<Member> members)
        {
            Member oldest = members[0];
            foreach (var member in members)
            {
                if (member.GetAge() > oldest.GetAge())
                {
                    oldest = member;
                }
            }
            foreach (var member in members)
            {
                if (member.GetAge() == oldest.GetAge())
                {
                    Console.WriteLine(member.PrintMemberInfo());
                }
            }
        }

        public static void ListMembersByBirthYear(List<Member> members)
        {
            var list = members.OrderBy(x => x.DateOfBirth.Year).ToList();
            PrintMemberInfo(list);
        }
        public static void FirstPersonBornInLongAn(List<Member> members)
        {
            foreach (var member in members)
            {
                if (member.BirthPlace == "Long An")
                {
                    Console.WriteLine(member.PrintMemberInfo());
                    break;
                }
            }
        }
        public static void ListFullName(List<Member> members)
        {
            foreach (var member in members)
            {
                Console.WriteLine(member.GetFullName());
            }
        }
    }
}
