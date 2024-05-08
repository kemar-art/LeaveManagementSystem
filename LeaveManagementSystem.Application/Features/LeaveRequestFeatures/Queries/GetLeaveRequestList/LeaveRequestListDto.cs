using LeaveManagementSystem.Application.Features.LeaveTypeFeatures.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Features.LeaveRequestFeatures.Queries.GetLeaveRequestList
{
    public class LeaveRequestListDto
    {
        public string RequesttingEmployeeId { get; set; }
        public LeaveTypeDto LeaveTypeDto { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsApproved { get; set; }
    }
}
