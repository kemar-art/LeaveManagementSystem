using LeaveManagementSytem.Domian;

namespace LeaveManagementSystem.Application.Contracts.Persistance
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveRequest> GetLeaveAllocationWithDetailsById(int id);
        Task<List<LeaveRequest>> GetAllocationListWithDetails();
        Task<List<LeaveRequest>> GetAllocationListUserIdWithDetails(string userId);
        Task<bool> AllocationExist(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocation);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
    }
}
