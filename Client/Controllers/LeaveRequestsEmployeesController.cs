using Core.Base;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    [Authorize]
    public class LeaveRequestsEmployeesController : Controller
    {
        BaseLink get = new BaseLink();

        public ActionResult Index()
        {
            return View(LoadLeaveRequestEmployee());
        }

        // GET: LeaveRequestsEmployees
        public JsonResult LoadLeaveRequestEmployee()
        {
            IEnumerable<LeaveRequest> leaveRequest = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRequestsEmployees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LeaveRequest>>();
                readTask.Wait();
                leaveRequest = readTask.Result;
            }
            else
            {
                leaveRequest = Enumerable.Empty<LeaveRequest>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(leaveRequest, JsonRequestBehavior.AllowGet);
        }
    }
}