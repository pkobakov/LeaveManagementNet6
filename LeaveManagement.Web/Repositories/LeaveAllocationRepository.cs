using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : Repository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context, 
            UserManager<Employee> userManager, ILeaveTypeRepository repository, IMapper mapper)
            : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await this.context.LeaveAllocations.AnyAsync(a => a.LeaveTypeId == leaveTypeId && a.EmployeeId == employeeId && a.Period == period);
        }

        public async Task<EmployeeAllocationsVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await  this.context.LeaveAllocations.Include(a => a.LeaveType)
                                                                  .Where(a => a.EmployeeId == employeeId)
                                                                  .ToListAsync();
            var employee = await this.userManager.FindByIdAsync(employeeId);
            var employeeAllocationModel = mapper.Map<EmployeeAllocationsVM>(employee);
            employeeAllocationModel.LeaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocations);
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id) 
        {
            var allocation = await context.LeaveAllocations.Include(a => a.LeaveType).FirstOrDefaultAsync(a => a.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);

            var model = mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = mapper.Map<EmployeeListVM>(employee);

            return model;
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
