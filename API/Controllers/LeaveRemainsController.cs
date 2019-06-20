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
    public class LeaveRemainsController : ApiController
    {
        private MyContext db = new MyContext();

        private readonly ILeaveRemainService iLeaveRemainService;

        public LeaveRemainsController() { }
        public LeaveRemainsController(ILeaveRemainService _iLeaveRemainService)
        {
            iLeaveRemainService = _iLeaveRemainService;
        }

        // GET: api/LeaveRequests
        public List<LeaveRemain> GetLeaveRemains()
        {
            return iLeaveRemainService.Get();
        }

        // GET: api/LeaveRemains/5
        public LeaveRemain GetLeaveRemain(int id)
        {
            return iLeaveRemainService.Get(id);
        }

        // PUT: api/LeaveRemains/5


        // POST: api/LeaveRemains
        public void InsertLeaveRemain(LeaveRemainVM leaveRemainVM)
        {
            iLeaveRemainService.Insert(leaveRemainVM);
        }


        // DELETE: api/LeaveRemains/5
    }
}