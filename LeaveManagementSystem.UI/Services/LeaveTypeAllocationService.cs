using LeaveManagementSystem.UI.Services.Base;
using LeaveManagementSystem.UI.Services.Contracts;

namespace LeaveManagementSystem.UI.Services
{
    public class LeaveTypeAllocationService : BaseHttpService, ILeaveTypeAllocationService
    {
        public LeaveTypeAllocationService(IClient client) : base(client)
        {
        }
    }
}
