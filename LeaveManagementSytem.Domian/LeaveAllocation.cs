using LeaveManagementSytem.Domian.Common;

namespace LeaveManagementSytem.Domian
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        public LeaveType? leavetype { get; set; }
        public int LeavetypeId { get; set; }

        public int Period { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
    }
}
