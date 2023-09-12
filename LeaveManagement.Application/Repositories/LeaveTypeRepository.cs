using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Application.Contracts;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(Data.ApplicationDbContext context) : base(context)
        {
        }
    }

  
}
