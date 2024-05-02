using LeaveManagement.Persistence.DatabaseContext;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext dbcontext) : base(dbcontext)
        {
        }

    }
}
