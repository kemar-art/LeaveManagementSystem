using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Shaired;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.CreeateLeaveRequest
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public string Requestscomments { get; set; } = string.Empty;
    }
}
