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
    public class LeaveTypesController : ApiController
    {
        private MyContext db = new MyContext();
        private readonly ILeaveTypesService iLeaveTypesService;

        public LeaveTypesController() { }
        public LeaveTypesController(ILeaveTypesService _iLeaveTypesService)
        {
            iLeaveTypesService = _iLeaveTypesService;
        }
        // GET: api/LeaveTypes
        public List<LeaveTypes> GetLeaveTypes()
        {
            return iLeaveTypesService.Get();
        }

        // GET: api/LeaveTypes/5
        public LeaveTypes GetLeaveType(int id)
        {
            return iLeaveTypesService.Get(id);
        }

        // PUT: api/LeaveTypes/5
        public void PutLeaveType(int id, LeaveTypesVM leaveTypesVM)
        {
            iLeaveTypesService.Update(id, leaveTypesVM);
        }

        // POST: api/LeaveTypes
        public void InsertLeaveType(LeaveTypesVM leaveTypesVM)
        {
            iLeaveTypesService.Insert(leaveTypesVM);
        }

        // DELETE: api/LeaveTypes/5
        public void DeleteLeaveType(int id)
        {
            iLeaveTypesService.Delete(id);
        }
    }
}