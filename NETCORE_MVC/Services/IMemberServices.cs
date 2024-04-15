using NETCORE_MVC.DataAccess;

namespace NETCORE_MVC.Services
{
    public interface IMemberServices
    {
        List<MemberViewModel> GetListMember();
        Member GetOneMember(int index);
        void AddMember(CreateMemberRequest request);
        List<EditMemberViewModel> GetListEdit();
        void UpdateMember(int index, EditMemberViewModel model);
        void DeleteMember(int index);
    }
}
