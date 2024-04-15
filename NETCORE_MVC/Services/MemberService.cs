using NETCORE_MVC.DataAccess;

namespace NETCORE_MVC.Services
{
    public class MemberService : IMemberServices
    {
        private readonly StaticMemberDataAccess _dataAccess;
        public MemberService()
        {
            _dataAccess = new StaticMemberDataAccess();
        }
        public void AddMember(CreateMemberRequest request)
        {
            Member member = new Member
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                BirthPlace = request.BirthPlace,
                IsGraduated = false
            };
            _dataAccess.AddMember(member);
        }

        public void DeleteMember(int index)
        {
            _dataAccess.DeleteMember(index);
        }

        public List<EditMemberViewModel> GetListEdit()
        {
            var list = new List<EditMemberViewModel>();
            var members = _dataAccess.Members;
            foreach (var member in members)
            {
                list.Add(new EditMemberViewModel
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    PhoneNumber = member.PhoneNumber,
                    BirthPlace = member.BirthPlace,
                });
            }
            return list;
        }

        public List<MemberViewModel> GetListMember()
        {
            var list = new List<MemberViewModel>();
            var members = _dataAccess.Members;
            foreach (var item in members)
            {
                list.Add(new MemberViewModel
                {
                    FullName = item.FirstName + item.LastName,
                    DateOfBirth = item.DateOfBirth.ToString("dd/MM/yyyy"),
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                    Gender = item.Gender == 1 ? "Male" : item.Gender == 2 ? "Female" : "Other",
                    Age = item.Age,
                });
            }

            return list;
        } 

        public Member GetOneMember(int index)
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(int index, EditMemberViewModel model)
        {
            var member = _dataAccess.Members[index];
            member.FirstName = model.FirstName;
            member.LastName = model.LastName;
            member.PhoneNumber = model.PhoneNumber;
            member.BirthPlace = model.BirthPlace;
            _dataAccess.UpdateMember(index, member);
        }
    }
}
