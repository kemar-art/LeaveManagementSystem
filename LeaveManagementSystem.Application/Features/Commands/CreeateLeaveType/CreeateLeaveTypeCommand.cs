using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType
{
    public class CreeateLeaveTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public int defaultDays { get; set; }
    }
}
