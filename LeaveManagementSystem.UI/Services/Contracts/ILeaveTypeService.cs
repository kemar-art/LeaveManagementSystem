using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Base;

namespace LeaveManagementSystem.UI.Services.Contracts
{
    public interface ILeaveTypeService
    {
        Task<IEnumerable<LeaveTypeVM>> GetAllLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeById(int id);
        Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
        Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
        Task<Response<Guid>> DeleteLeaveType(int id);
    }
}
