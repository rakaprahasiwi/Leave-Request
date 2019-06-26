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
    public class CalendarsController : ApiController
    {
        private MyContext db = new MyContext();

        private readonly ICalendarService iCalendarService;

        public CalendarsController() { }
        public CalendarsController(ICalendarService _iCalendarService)
        {
            iCalendarService = _iCalendarService;
        }

        // GET: api/Calendars
        public HttpResponseMessage GetCalendars()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iCalendarService.Get();
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

        // GET: api/Calendars/5
        public HttpResponseMessage GetCalendar(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iCalendarService.Get(id);
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

        // PUT: api/Calendars/5
        public HttpResponseMessage PutCalendar(int id, CalendarVM calendarVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iCalendarService.Update(id, calendarVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, calendarVM);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }

        }

        // POST: api/Calendars
        public HttpResponseMessage InsertCalendar(CalendarVM calendarVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iCalendarService.Insert(calendarVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, calendarVM);
                }
                return message;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // DELETE: api/Calendars/5
        public HttpResponseMessage DeleteCalendar(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iCalendarService.Delete(id);
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