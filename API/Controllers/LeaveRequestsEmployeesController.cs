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
using BusinessLogic.Service;
using Common.Repository;
using DataAccess.Context;
using DataAccess.Models;

namespace API.Controllers
{
    public class LeaveRequestsEmployeesController : ApiController
    {
        private MyContext db = new MyContext();

        private readonly ILeaveRequestEmployeeRepository iLeaveRequestEmployeeRepository;

        public LeaveRequestsEmployeesController() { }
        public LeaveRequestsEmployeesController(ILeaveRequestEmployeeRepository _iLeaveRequestEmployeeRepository)
        {
            iLeaveRequestEmployeeRepository = _iLeaveRequestEmployeeRepository;
        }

        // GET: api/LeaveRequestsEmployees
        public HttpResponseMessage GetLeaveRequestsEmployees()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iLeaveRequestEmployeeRepository.GetEmployee();
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

        // GET: api/LeaveRequestsEmployees/5
        

        // PUT: api/LeaveRequestsEmployees/5
        

        // POST: api/LeaveRequestsEmployees
        

        // DELETE: api/LeaveRequestsEmployees/5
        
    }
}