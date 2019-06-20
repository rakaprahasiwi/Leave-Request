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
        public List<StatusTypeParameter> GetStatusTypeParameters()
        {
            return iStatusTypeParameterService.Get();
        }

        // GET: api/StatusTypeParameters/5
        public StatusTypeParameter GetStatusTypeParameter(int id)
        {
            return iStatusTypeParameterService.Get(id);
        }

        // PUT: api/StatusTypeParameters/5


        // POST: api/StatusTypeParameters
        public void InsertStatusTypeParameter(StatusTypeParameterVM statusTypeParameterVM)
        {
            iStatusTypeParameterService.Insert(statusTypeParameterVM);
        }

        // DELETE: api/StatusTypeParameters/5
    }
}