using LeaveManagementSytem.Domian.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSytem.Domian
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public LeaveType? Leavetype { get; set; }
        public int LeavetypeId { get; set; }

        public DateTime DateRequested { get; set; }
        public string Comments { get; set; } = string.Empty ;

        public bool Approved { get; set; }
        public bool Cancelled { get; set; }

        public string RequestingEployeeId { get; set; } = string.Empty;
    }
}
