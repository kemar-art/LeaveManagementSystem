using AutoMapper;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.CreeateLeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.UpdateLeaveRequest;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestDetails;
using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestList;
using LeaveManagementSytem.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.MappingConfig
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
        }
    }
}
