using AutoMapper;
using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Base;

namespace LeaveManagementSystem.UI.MappingConfig
{
    public class MappingProfles : Profile
    {
        public MappingProfles()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>();
        }
    }
}
