using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : Repository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public LeaveAllocationRepository(ApplicationDbContext context, 
            UserManager<Employee> userManager, ILeaveTypeRepository repository)
            : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = repository;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await this.context.LeaveAllocations.AnyAsync(a => a.LeaveTypeId == leaveTypeId && a.EmployeeId == employeeId && a.Period == period);
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User); ;
            var period = DateTime.Now.Year;
            var leavetype = await leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;
                
                allocations.Add(new LeaveAllocation 
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leavetype.DefaultDays
                });

               await this.AddRangeAsync(allocations);
            }

        }
    }
}
