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

namespace API.Controllers
{
    public class LeaveRequestGetAllsController : ApiController
    {
        private MyContext db = new MyContext();

        private readonly ILeaveRequestGetAllService iLeaveRequestGetAllService;

        public LeaveRequestGetAllsController() { }
        public LeaveRequestGetAllsController(ILeaveRequestGetAllService _iLeaveRequestGetAllService)
        {
            iLeaveRequestGetAllService = _iLeaveRequestGetAllService;
        }

        // GET: api/LeaveRequestsGetAll
        public HttpResponseMessage GetLeaveRequestAlls()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestGetAllService.GetAllList();
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }

        }

        // GET: api/LeaveRequestsGetAll/5
        public HttpResponseMessage GetLeaveRequestAlls(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestGetAllService.Get(id);
                if (result != null)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // PUT: api/LeaveRequestsGetAll/5


        // POST: api/LeaveRequestsGetAll


        // DELETE: api/LeaveRequestsGetAll/5
        public HttpResponseMessage DeleteLeaveRequestGetAlls(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestGetAllService.Delete(id);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, "200 : OK (Data Deleted)");
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }
    }
}