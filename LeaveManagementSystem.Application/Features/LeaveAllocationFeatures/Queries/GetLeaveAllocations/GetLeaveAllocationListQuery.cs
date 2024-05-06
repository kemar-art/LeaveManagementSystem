using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationListQuery : IRequest<IEnumerable<LeaveAllocationDto>>
    {
    }
}
