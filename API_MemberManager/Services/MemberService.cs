using API_MemberManager.Models;

namespace API_MemberManager.Services
{
    public class MemberService: IMemberService
    {
        private readonly List<MemberRequestModel> _members;
        public MemberService()
        {
            _members = new List<MemberRequestModel>();
        }
        public List<MemberRequestModel>? GetMembers()
        {
            return _members;
        }
        public MemberRequestModel? CreateMember(MemberRequestModel member)
        {
            _members.Add(member);
            return member;
        }
        public MemberRequestModel? UpdateMember(Guid id, MemberRequestModel member)
        {
            var existingMember = _members.FirstOrDefault(x => x.Id == id);
            if(existingMember != null)
            {
                existingMember.Name = member.Name;
                existingMember.Email = member.Email;
                existingMember.PhoneNumber = member.PhoneNumber;
                existingMember.Address = member.Address;
                existingMember.City = member.City;
                existingMember.Country = member.Country;
            }
            return existingMember;
        }
        public void DeleteMember(Guid id)
        {
            var existingMember = _members.FirstOrDefault(x => x.Id == id);
            if(existingMember != null)
            {
                _members.Remove(existingMember);
            }
        }
        public MemberRequestModel? GetMemberById(Guid id)
        {
            return _members.FirstOrDefault(x => x.Id == id);
        }
        public MemberRequestModel? GetMemberByName(string name)
        {
            return _members.FirstOrDefault(x => x.Name == name);
        }
    }
}
