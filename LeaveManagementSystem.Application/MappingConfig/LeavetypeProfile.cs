using AutoMapper;
using LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes;
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
            CreateMap<LeavetypeDto, Leavetype>().ReverseMap();
        }
    }
}
