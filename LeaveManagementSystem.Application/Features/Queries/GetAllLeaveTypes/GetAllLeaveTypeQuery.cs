using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Queries.GetAllLeaveTypes
{
    //public class GetAllLeaveTypeQuery : IRequest<IEnumerable<LeavetypeDto>>
    //{
    //}
    public record GetAllLeaveTypeQuery : IRequest<IEnumerable<LeavetypeDto>>;
}
