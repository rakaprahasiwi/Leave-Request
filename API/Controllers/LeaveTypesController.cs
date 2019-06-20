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
        public HttpResponseMessage GetLeaveTypes()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveTypesService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/LeaveTypes/5
        public HttpResponseMessage GetLeaveType(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveTypesService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/LeaveTypes/5
        public HttpResponseMessage PutLeaveType(int id, LeaveTypesVM leaveTypesVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveTypesService.Update(id, leaveTypesVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, leaveTypesVM);
            }
            return message;
        }

        // POST: api/LeaveTypes
        public HttpResponseMessage InsertLeaveType(LeaveTypesVM leaveTypesVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveTypesService.Insert(leaveTypesVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, leaveTypesVM);
            }
            return message;
        }

        // DELETE: api/LeaveTypes/5
        public void DeleteLeaveType(int id)
        {
            iLeaveTypesService.Delete(id);
        }
    }
}