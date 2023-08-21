using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM 
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}