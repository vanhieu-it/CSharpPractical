namespace NETCORE_MVC.DataAccess
{
    public class StaticMemberDataAccess : IDataAccess
    {
        private static List<Member> _members = new List<Member>
        {
            new Member{
                    FirstName = "Hieu",
                    LastName = "Do Van",
                    Gender = 1,
                    DateOfBirth = new DateTime(1999,10,13),
                    PhoneNumber = "0123456789",
                    BirthPlace = "Long An",
                    IsGraduated = false
            },
            new Member{
                    FirstName = "Huy",
                    LastName = "Nguyen Van",
                    Gender = 1,
                    DateOfBirth = new DateTime(1999,01,01),
                    PhoneNumber = "9876543210",
                    BirthPlace = "Binh Duong",
                    IsGraduated = false
            },
            new Member{
                    FirstName = "Thuy",
                    LastName = "Pham Thanh",
                    Gender = 2,
                    DateOfBirth = new DateTime(2001,05,07),
                    PhoneNumber = "01213141516",
                    BirthPlace = "Ho Chi Minh",
                    IsGraduated = true
            },
            new Member{
                    FirstName = "Hanh",
                    LastName = "Pham Thi",
                    Gender = 2,
                    DateOfBirth = new DateTime(2000,05,07),
                    PhoneNumber = "01213141516",
                    BirthPlace = "Ca Mau",
                    IsGraduated = true
            }
        };
        public List<Member> Members
        {
            get => _members;
            set
            {
                _members = value;
            }
        }

        public List<Member> GetAllMember()
        {
            return Members;
        }

        public StaticMemberDataAccess()
        {

        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void UpdateMember(int index, Member member)
        {
            Members[index] = member;
        }

        public void DeleteMember(int index)
        {
            Members.RemoveAt(index);
        }
    }
}
