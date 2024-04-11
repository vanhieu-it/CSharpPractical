using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager
{
    internal class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public bool IsGraduated { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (today < DateOfBirth.AddYears(age))
            {
                age--;
            }
            return age;
        }

        public string PrintMemberInfo()
        {
            string memberInfo = "";
            memberInfo += $"Full Name: {GetFullName()}\n";
            memberInfo += $"Gender: {Gender}\n";
            memberInfo += $"Date of Birth: {DateOfBirth.ToShortDateString()}\n";
            memberInfo += $"Phone Number: {PhoneNumber}\n";
            memberInfo += $"BirthPlace: {BirthPlace}\n";
            memberInfo += $"Is Graduate: {(IsGraduated ? "Yes" : "No")}\n";
            memberInfo += $"Age: {GetAge()}\n";
            return memberInfo;
        }
    }

}
