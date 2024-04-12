using API_MemberManager.Models;
namespace API_MemberManager.Services
{
    public interface IMemberService
    {
        List<MemberRequestModel>? GetMembers();
        MemberRequestModel? CreateMember(MemberRequestModel member);
        MemberRequestModel? UpdateMember(Guid id, MemberRequestModel member);
        void DeleteMember(Guid id);
        MemberRequestModel? GetMemberById(Guid id);
        MemberRequestModel? GetMemberByName(string name);

    }
}
