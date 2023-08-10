using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveTypeRepository : Repository<LeaveType>, Contracts.ILeaveTypeRepository
    {
        public LeaveTypeRepository(Data.ApplicationDbContext context) : base(context)
        {
        }
    }
}
