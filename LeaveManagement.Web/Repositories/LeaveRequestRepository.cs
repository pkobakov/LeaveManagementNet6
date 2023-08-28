﻿using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Employee> userManager;

        public LeaveRequestRepository(ApplicationDbContext context, 
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, 
            UserManager<Employee> userManager) : base(context)
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task  CreateLeaveRequest(LeaveRequestCreateVM nodel)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var leaveRequest = mapper.Map<LeaveRequest>(nodel);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
        }
    }
}
