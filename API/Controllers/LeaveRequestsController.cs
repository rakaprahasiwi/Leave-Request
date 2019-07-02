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
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestService.Get();
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
            
        }

        

        // GET: api/LeaveRequests/5
        public HttpResponseMessage GetLeaveRequest(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestService.Get(id);
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // PUT: api/LeaveRequests/5
        public HttpResponseMessage PutLeaveRequest(int id,LeaveRequestVM leaveRequestVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestService.Update(id, leaveRequestVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, leaveRequestVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
            
        }

        // POST: api/LeaveRequests
        public HttpResponseMessage InsertLeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestService.Insert(leaveRequestVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, leaveRequestVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
            
        }

        // DELETE: api/LeaveRequests/5
        public HttpResponseMessage DeleteLeaveRequest(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestService.Delete(id);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, "200 : OK (Data Deleted)");
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }
    }
}