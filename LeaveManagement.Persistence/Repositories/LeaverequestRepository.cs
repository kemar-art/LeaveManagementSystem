using LeaveManagement.Persistence.DatabaseContext;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext dbcontext) : base(dbcontext)
        {
            
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbcontext.LeaveRequests.Include(q => q.Leavetype)
                                                       .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
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
    }
}
