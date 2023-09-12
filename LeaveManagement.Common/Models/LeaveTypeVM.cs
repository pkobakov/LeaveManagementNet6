using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Display(Name = "Leave Type Name")]
        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage ="Name Should Be Between 6 And 12 Characters.")]
        public string Name { get; set; }
        [Display(Name = "Default Number Of Days")]
        [Required]
        [Range(1, 25, ErrorMessage ="Please Enter A Valid Number.")]
        public int DefaultDays { get; set; }
    }
}
