using LeaveManagement.Persistence.DatabaseContext;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext dbcontext) : base(dbcontext)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocation)
        {
            await _dbcontext.AddRangeAsync(allocation);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> AllocationExist(string userId, int leaveTypeId, int period)
        {
            return await _dbcontext.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId && q.LeavetypeId == leaveTypeId && q.Period == period);
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbcontext.LeaveRequests.Include(q => q.Leavetype)
                                                       .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetAllocationWithDetails()
        {
            var leaveRequest = await _dbcontext.LeaveRequests.Include(q => q.Leavetype)
                                                             .ToListAsync();
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequest = await _dbcontext.LeaveRequests.Where(q => q.RequestingEployeeId == userId)
                                                             .Include(q => q.Leavetype)
                                                             .ToListAsync();
            return leaveRequest;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _dbcontext.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeavetypeId == leaveTypeId);
        }
    }
}
