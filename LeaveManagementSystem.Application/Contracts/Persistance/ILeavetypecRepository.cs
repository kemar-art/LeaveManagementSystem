using LeaveManagementSytem.Domian;

namespace LeaveManagementSystem.Application.Contracts.Persistance
{
    public interface ILeaveTypecRepository : IGenericRepository<Leavetype>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
