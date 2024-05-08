using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestDetails
{
    public class GetLeaveRequestDetailsQuery : IRequest<LeaveRequestDetailsDto>
    {
        public int Id { get; set; }
    }
}
