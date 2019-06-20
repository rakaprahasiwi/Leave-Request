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
        public HttpResponseMessage GetLeaveRequests()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRequestService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/LeaveRequests/5
        public HttpResponseMessage GetLeaveRequest(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRequestService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/LeaveRequests/5
        public HttpResponseMessage PutLeaveRequest(int id,LeaveRequestVM leaveRequestVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRequestService.Update(id,leaveRequestVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Data Dihapus");
            }
            return message;
        }

        // POST: api/LeaveRequests
        public HttpResponseMessage InsertLeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRequestService.Insert(leaveRequestVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Data Dihapus");
            }
            return message;
        }

        // DELETE: api/LeaveRequests/5
        public HttpResponseMessage DeleteLeaveRequest(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRequestService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Data Dihapus");
            }
            return message;
        }
    }
}