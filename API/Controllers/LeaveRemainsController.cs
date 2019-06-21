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
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRemainService.Get();
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

        // GET: api/LeaveRemains/5
        public HttpResponseMessage GetLeaveRemain(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRemainService.Get(id);
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

        // PUT: api/LeaveRemains/5
        public HttpResponseMessage PutLeaveRemain(int id,LeaveRemainVM leaveRemainVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRemainService.Update(id, leaveRemainVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, leaveRemainVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }
        

        // POST: api/LeaveRemains
        public HttpResponseMessage InsertLeaveRemain(LeaveRemainVM leaveRemainVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRemainService.Insert(leaveRemainVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, leaveRemainVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }  
        }


        // DELETE: api/LeaveRemains/5
        public HttpResponseMessage DeleteLeaveRemain(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRemainService.Delete(id);
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