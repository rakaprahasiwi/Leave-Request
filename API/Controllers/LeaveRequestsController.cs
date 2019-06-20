using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess.Context;
using DataAccess.Models;
using BusinessLogic.Service;
using DataAccess.ViewModels;

namespace API.Controllers
{
    public class LeaveRequestsController : ApiController
    {
        private MyContext db = new MyContext();

        private readonly ILeaveRequestService iLeaveRequestService;

        public LeaveRequestsController() { }
        public LeaveRequestsController(ILeaveRequestService _iLeaveRequestService)
        {
            iLeaveRequestService = _iLeaveRequestService;
        }

        // GET: api/LeaveRequests
        public List<LeaveRequest> GetLeaveRequests()
        {
            return iLeaveRequestService.Get();
        }

        // GET: api/LeaveRequests/5
        public LeaveRequest GetLeaveRequest(int id)
        {
            return iLeaveRequestService.Get(id);
        }

        // PUT: api/LeaveRequests/5


        // POST: api/LeaveRequests
        public void InsertLeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            iLeaveRequestService.Insert(leaveRequestVM);
        }

        // DELETE: api/LeaveRequests/5
    }
}