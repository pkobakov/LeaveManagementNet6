using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IRepository<LeaveRequest>
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM nodel);
        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
        Task<List<LeaveRequest>> GetAllAsync(string empolyeeId);

    }
}
