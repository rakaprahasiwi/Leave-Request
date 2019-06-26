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
        private readonly ILeaveTypeService iLeaveTypesService;

        public LeaveTypesController() { }
        public LeaveTypesController(ILeaveTypeService _iLeaveTypesService)
        {
            iLeaveTypesService = _iLeaveTypesService;
        }

        // GET: api/LeaveTypes
        public HttpResponseMessage GetLeaveTypes()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveTypesService.Get();
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

        // GET: api/LeaveTypes/5
        public HttpResponseMessage GetLeaveType(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveTypesService.Get(id);
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

        // PUT: api/LeaveTypes/5
        public HttpResponseMessage PutLeaveType(int id, LeaveTypeVM leaveTypesVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveTypesService.Update(id, leaveTypesVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, leaveTypesVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
            
        }

        // POST: api/LeaveTypes
        public HttpResponseMessage InsertLeaveType(LeaveTypeVM leaveTypesVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveTypesService.Insert(leaveTypesVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, leaveTypesVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // DELETE: api/LeaveTypes/5
        public HttpResponseMessage DeleteLeaveType(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveTypesService.Delete(id);
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