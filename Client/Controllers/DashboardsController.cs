using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    [Authorize]
    public class DashboardsController : Controller
    {
        // GET: Dashboards
        public ActionResult Index()
        {
            return View();
        }
    }
}