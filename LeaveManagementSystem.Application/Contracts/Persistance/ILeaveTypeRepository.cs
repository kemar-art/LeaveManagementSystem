using LeaveManagementSytem.Domian;

namespace LeaveManagementSystem.Application.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepository<Leavetype>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
