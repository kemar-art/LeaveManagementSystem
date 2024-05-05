using LeaveManagement.Persistence.DatabaseContext;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _dbcontext.Leavetypes.AnyAsync(e => e.Name == name) == false;
        }
    }
}
