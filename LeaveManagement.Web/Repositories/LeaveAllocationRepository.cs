using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly IEmailSender emailSender;

        public LeaveAllocationRepository(ApplicationDbContext context, 
            UserManager<Employee> userManager, ILeaveTypeRepository repository, IMapper mapper,
          AutoMapper.IConfigurationProvider configurationProvider, IEmailSender emailSender)
            : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = repository;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
            this.emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await this.context.LeaveAllocations.AnyAsync(a => a.LeaveTypeId == leaveTypeId && a.EmployeeId == employeeId && a.Period == period);
        }

        public async Task<EmployeeAllocationsVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await  this.context.LeaveAllocations.Include(a => a.LeaveType)
                                                                  .Where(a => a.EmployeeId == employeeId)
                                                                  .ProjectTo<LeaveAllocationVM>(configurationProvider)
                                                                  .ToListAsync();

            var employee = await this.userManager.FindByIdAsync(employeeId);
            var employeeAllocationModel = mapper.Map<EmployeeAllocationsVM>(employee);
            employeeAllocationModel.LeaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocations);
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id) 
        {
            var allocation = await context.LeaveAllocations.Include(a => a.LeaveType)
                                                           .ProjectTo<LeaveAllocationEditVM>(configurationProvider)
                                                           .FirstOrDefaultAsync(a => a.Id == id);

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
            var employeesWithNewAllocations = new List<Employee>();

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

               employeesWithNewAllocations.Add(employee);
            }


            await this.AddRangeAsync(allocations);

            foreach (var employee in employeesWithNewAllocations)
            {
                await emailSender.SendEmailAsync(employee.Email, $"Leave Allocation for {period}", $"Your {leavetype.Name} has been posted for the period of {period}. You have been given {leavetype.DefaultDays}.");
            }

        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveallocation = await this.GetAsync(model.Id);
            if (leaveallocation == null)
            {
                return false;
            }

            leaveallocation.Period = model.Period;
            leaveallocation.NumberOfDays = model.NumberOfDays;
            await this.UpdateAsync(leaveallocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await context.LeaveAllocations.FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.LeaveTypeId == leaveTypeId);
        }
    }
}
