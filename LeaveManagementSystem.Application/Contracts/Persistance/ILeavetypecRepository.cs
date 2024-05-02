using LeaveManagementSytem.Domian;

namespace LeaveManagementSystem.Application.Contracts.Persistance
{
    public interface ILeavetypecRepository : IGenericRepository<Leavetype>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
