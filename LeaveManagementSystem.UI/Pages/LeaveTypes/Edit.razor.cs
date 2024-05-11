using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace LeaveManagementSystem.UI.Pages.LeaveTypes
{
    public partial class Edit
    {
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeById(id);
        }

        async Task EditLeaveType()
        {
            var response = await _client.UpdateLeaveType(id, leaveType);
            if (response.IsSuccess)
            {
                _navManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}