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
        public HttpResponseMessage GetLeaveRemain()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRemainService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/LeaveRemains/5
        public HttpResponseMessage GetLeaveRemain(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRemainService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/LeaveRemains/5
        public HttpResponseMessage PutLeaveRemain(int id,LeaveRemainVM leaveRemainVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRemainService.Update(id,leaveRemainVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, leaveRemainVM);
            }
            return message;
        }
        

        // POST: api/LeaveRemains
        public HttpResponseMessage InsertLeaveRemain(LeaveRemainVM leaveRemainVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRemainService.Insert(leaveRemainVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, leaveRemainVM);
            }
            return message;
        }


        // DELETE: api/LeaveRemains/5
        public HttpResponseMessage DeleteLeaveRemain(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iLeaveRemainService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK , "Data Deleted");
            }
            return message;
        }
    }
}