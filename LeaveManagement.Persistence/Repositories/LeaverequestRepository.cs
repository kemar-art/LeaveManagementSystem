using LeaveManagement.Persistence.DatabaseContext;
using LeaveManagementSystem.Application.Contracts.Persistance;
using LeaveManagementSytem.Domian;

namespace LeaveManagement.Persistence.Repositories
{
    public class LeaverequestRepository : GenericRepository<Leaverequest>, ILeaverequestRepository
    {
        public LeaverequestRepository(HrDatabaseContext dbcontext) : base(dbcontext)
        {
        }

    }
}
