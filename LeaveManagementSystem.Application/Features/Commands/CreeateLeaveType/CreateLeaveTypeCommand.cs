using LeaveManagementSytem.Domian;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.Commands.CreeateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<LeaveType>
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
