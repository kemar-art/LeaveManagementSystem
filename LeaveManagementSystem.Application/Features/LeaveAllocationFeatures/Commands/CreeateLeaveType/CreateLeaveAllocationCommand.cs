using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveAllocationFeatures.Commands.CreeateLeaveType
{
    public class CreateLeaveAllocationCommand : IRequest<Unit> 
    {
        public int LeavetypeId { get; set; }
    }
}
