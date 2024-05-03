using LeaveManagementSytem.Domian;

namespace LeaveManagementSystem.Application.Contracts.Persistance
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
        Task<bool> AllocationExist(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocation);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
    }
}
