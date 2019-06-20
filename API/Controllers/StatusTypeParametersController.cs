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
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iStatusTypeParameterService.Get();
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // GET: api/StatusTypeParameters/5
        public HttpResponseMessage GetStatusTypeParameter(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iStatusTypeParameterService.Get(id);
            if (result != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return message;
        }

        // PUT: api/StatusTypeParameters/5
        public HttpResponseMessage PutStatusTypeParameter(int id, StatusTypeParameterVM statusTypeParameterVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iStatusTypeParameterService.Update(id, statusTypeParameterVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, statusTypeParameterVM);
            }
            return message;
        }

        // POST: api/StatusTypeParameters
        public HttpResponseMessage InsertStatusTypeParameter(StatusTypeParameterVM statusTypeParameterVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iStatusTypeParameterService.Insert(statusTypeParameterVM);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, statusTypeParameterVM);
            }
            return message;
        }

        // DELETE: api/StatusTypeParameters/5
        public HttpResponseMessage DeleteStatusTypeParameter(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            var result = iStatusTypeParameterService.Delete(id);
            if (result)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Data Dihapus");
            }
            return message;
        }
    }
}