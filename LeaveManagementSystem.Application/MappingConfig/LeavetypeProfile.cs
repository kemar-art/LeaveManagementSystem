using AutoMapper;
using LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType;
using LeaveManagementSystem.Application.Features.Commands.UpdateLeaveType;
using LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes;
using LeaveManagementSystem.Application.Features.Queries.GetLeaveTypeDetails;
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
