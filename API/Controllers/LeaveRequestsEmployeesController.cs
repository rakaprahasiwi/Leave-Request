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
        [ResponseType(typeof(LeaveRequest))]
        public IHttpActionResult GetLeaveRequest(int id)
        {
            LeaveRequest leaveRequest = db.LeaveRequests.Find(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return Ok(leaveRequest);
        }

        // PUT: api/LeaveRequestsEmployees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeaveRequest(int id, LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaveRequest.Id)
            {
                return BadRequest();
            }

            db.Entry(leaveRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LeaveRequestsEmployees
        [ResponseType(typeof(LeaveRequest))]
        public IHttpActionResult PostLeaveRequest(LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeaveRequests.Add(leaveRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leaveRequest.Id }, leaveRequest);
        }

        // DELETE: api/LeaveRequestsEmployees/5
        [ResponseType(typeof(LeaveRequest))]
        public IHttpActionResult DeleteLeaveRequest(int id)
        {
            LeaveRequest leaveRequest = db.LeaveRequests.Find(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            db.LeaveRequests.Remove(leaveRequest);
            db.SaveChanges();

            return Ok(leaveRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveRequestExists(int id)
        {
            return db.LeaveRequests.Count(e => e.Id == id) > 0;
        }
    }
}