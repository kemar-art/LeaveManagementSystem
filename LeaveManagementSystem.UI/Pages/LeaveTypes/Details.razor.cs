using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace LeaveManagementSystem.UI.Pages.LeaveTypes
{
    public partial class Details
    {
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Parameter]
        public int id { get; set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeById(id);
        }
    }
}