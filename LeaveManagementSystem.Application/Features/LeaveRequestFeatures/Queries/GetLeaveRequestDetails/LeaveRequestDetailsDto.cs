using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestDetails
{
    public class LeaveRequestDetailsDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequesttingEmployeeId { get; set; }
        public LeaveTypeDto LeaveTypeDto { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? IsApproved { get; set; }
        public bool IsCancelled { get; set; }
    }
}