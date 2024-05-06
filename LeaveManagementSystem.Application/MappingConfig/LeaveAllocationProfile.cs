using AutoMapper;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.CreeateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.UpdateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Queries.GetLeaveAllocationDetails;
using LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Queries.GetLeaveAllocations;
using LeaveManagementSytem.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.MappingConfig
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
