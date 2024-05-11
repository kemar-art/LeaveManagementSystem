using AutoMapper;
using LeaveManagementSystem.UI.Models.LeaveType;
using LeaveManagementSystem.UI.Services.Base;

namespace LeaveManagementSystem.UI.MappingConfig
{
    public class MappingProfles : Profile
    {
        public MappingProfles()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
        }
    }
}
