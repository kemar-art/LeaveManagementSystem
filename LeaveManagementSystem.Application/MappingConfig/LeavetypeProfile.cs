using AutoMapper;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Commands.CreeateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Commands.UpdateLeaveType;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Queries.GetAllLeaveTypes;
using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Queries.GetLeaveTypeDetails;
using LeaveManagementSytem.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.MappingConfig
{
    public class LeavetypeProfile : Profile 
    {
        public LeavetypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveTypeDetailsDto, LeaveType>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>().ReverseMap();
        }
    }
}
