using LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Shaired;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommand : BaseLeaveRequest , IRequest<Unit>
    {
        public int Id { get; set; }
        public string RequestComments { get; set; }
        public bool IsCancelled { get; set; }
    }
}
