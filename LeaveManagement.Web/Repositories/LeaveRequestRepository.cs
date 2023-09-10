using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IEmailSender emailSender;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly UserManager<Employee> userManager;

        public LeaveRequestRepository(ApplicationDbContext context, 
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            IEmailSender emailSender,
            AutoMapper.IConfigurationProvider configurationProvider,
            UserManager<Employee> userManager) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.emailSender = emailSender;
            this.configurationProvider = configurationProvider;
            this.userManager = userManager;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            await emailSender.SendEmailAsync(user.Email, "Leave Request Cancelled" , $"Your Leave Request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been cancelled successfully. ");

        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved) 
            {
               var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);  
                int daysRequested = (int) (leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                await leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = approved ? "Approved": "Declined";

            await emailSender.SendEmailAsync(user.Email, $"Leave Request {approvalStatus}", $"Your Request From {leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approved}");
        }

        public async Task<bool>  CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (leaveAllocation == null) 
            {
                return false;
            
            }

            int daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if (daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            var leaveRequest = mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await emailSender.SendEmailAsync(user.Email, "Leave Request Submitted Successfully", $"Your Leave Request from {leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval.");
            
            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminRequestList()
        {

            var leaveRequests = await context.LeaveRequests.Include(l => l.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM()
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(r => r.Approved == true),
                PendingRequests = leaveRequests.Count(r => r.Approved == null),
                RejectedRequests = leaveRequests.Count(r => r.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests) 
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));  
            }

            return  model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string empolyeeId)
        {
           return await context.LeaveRequests.Where(u => u.RequestingEmployeeId == empolyeeId)
                                             .ProjectTo<LeaveRequestVM>(configurationProvider)
                                             .ToListAsync(); 
        }

        public async  Task<LeaveRequestVM> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await context.LeaveRequests
                                      .Include(l => l.LeaveType)
                                      .FirstOrDefaultAsync(l => l.Id == id);

            if (leaveRequest == null) 
            {
                return null;
            }
            var model = mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            return model;
        }

        public  async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            var model = new EmployeeLeaveRequestViewVM(allocations, requests);

            return model;   
        }
    }
}
