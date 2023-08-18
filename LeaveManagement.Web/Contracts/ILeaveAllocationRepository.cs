using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationRepository : IRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
    }
}
