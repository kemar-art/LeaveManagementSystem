using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LeaveManagementSystem.UI.Pages.LeaveTypes
{

    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }
        [Inject]
        public ILeaveTypeAllocationService LeaveAllocationService { get; set; }
        [Inject]
        //IToastService toastService { get; set; }
        public IEnumerable<LeaveTypeVM> LeaveTypes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/leavetypes/create/");
        }

        protected void AllocateLeaveType(int id)
        {
            // Use Leave Allocation Service here
            //LeaveAllocationService.(id);
        }

        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
        }

        protected void DetailsLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/details/{id}");
        }

        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.IsSuccess)
            {
                // toastService.ShowSuccess("Leave Type deleted Successfully");
                //await OnInitializedAsync();
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetAllLeaveTypes();
        }
    }
}
