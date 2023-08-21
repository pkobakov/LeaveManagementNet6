using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Models
{
    public class EmployeeAllocationsVM : EmployeeListVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }

    }
}
