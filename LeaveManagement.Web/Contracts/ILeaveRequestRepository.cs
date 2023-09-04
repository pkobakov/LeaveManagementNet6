using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IRepository<LeaveRequest>
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM nodel);
        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
        Task<LeaveRequestVM> GetLeaveRequestAsync(int? id);
        Task<List<LeaveRequest>> GetAllAsync(string empolyeeId);
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task<AdminLeaveRequestViewVM> GetAdminRequestList();

    }
}
