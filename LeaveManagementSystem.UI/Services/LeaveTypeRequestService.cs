using LeaveManagementSystem.UI.Services.Base;
using LeaveManagementSystem.UI.Services.Contracts;

namespace LeaveManagementSystem.UI.Services
{
    public class LeaveTypeRequestService : BaseHttpService, ILeaveTypeRequestService
    {
        public LeaveTypeRequestService(IClient client) : base(client)
        {
        }
    }
}
