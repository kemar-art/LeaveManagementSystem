using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.UI.Models.LeaveType
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Availabe Days")]
        public string DefaultDays { get; set; }
    }
}
