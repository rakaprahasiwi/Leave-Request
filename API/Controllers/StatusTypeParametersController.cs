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
    public class StatusTypeParametersController : ApiController
    {
        private MyContext db = new MyContext();

        private readonly IStatusTypeParameterService iStatusTypeParameterService;

        public StatusTypeParametersController() { }
        public StatusTypeParametersController(IStatusTypeParameterService _iStatusTypeParameterService)
        {
            iStatusTypeParameterService = _iStatusTypeParameterService;
        }

        // GET: api/StatusTypeParameters
        public HttpResponseMessage GetStatusTypeParameters()
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iStatusTypeParameterService.Get();
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

        // GET: api/StatusTypeParameters/5
        public HttpResponseMessage GetStatusTypeParameter(int id)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iStatusTypeParameterService.Get(id);
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

        // PUT: api/StatusTypeParameters/5
        public HttpResponseMessage PutStatusTypeParameter(int id, StatusTypeParameterVM statusTypeParameterVM)
        {
            try
            {
                var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                var result = iStatusTypeParameterService.Update(id, statusTypeParameterVM);
                if (result)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK, statusTypeParameterVM);
                }
                return message;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
        }

        // POST: api/StatusTypeParameters
        public HttpResponseMessage InsertStatusTypeParameter(StatusTypeParameterVM statusTypeParameterVM)
        {
            try
            {
                var result = iStatusTypeParameterService.Insert(statusTypeParameterVM);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, statusTypeParameterVM);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
            //var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            //var result = iStatusTypeParameterService.Insert(statusTypeParameterVM);
            //if (result)
            //{
            //    message = Request.CreateResponse(HttpStatusCode.OK, statusTypeParameterVM);
            //}
            //return message;
        }

        // DELETE: api/StatusTypeParameters/5
        public HttpResponseMessage DeleteStatusTypeParameter(int id)
        {
            try
            {
                var result = iStatusTypeParameterService.Delete(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "200 : OK (Data Deleted)");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "404 : Data Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "500 : Internal Server Error");
            }
            //var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            //var result = iStatusTypeParameterService.Delete(id);
            //if (result)
            //{
            //    message = Request.CreateResponse(HttpStatusCode.OK, "Data Deleted");
            //}
            //return message;
        }
    }
}