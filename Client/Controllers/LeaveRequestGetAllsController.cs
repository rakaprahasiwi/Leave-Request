using Core.Base;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class LeaveRequestGetAllsController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: LeaveRequestGetAlls
        public ActionResult Index()
        {
            return View(LoadLeaveRequestGetAll());
        }

        public JsonResult LoadLeaveRequestGetAll()
        {
            IEnumerable<LeaveRequest> leaveRequest = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRequestGetAlls");
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

        public JsonResult GetById(int id)
        {
            LeaveRequestVM leaveRequestVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRequestGetAlls/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LeaveRequestVM>();
                responseTask.Wait();
                leaveRequestVM = readTask.Result;
            }
            else
            {

            }
            return Json(leaveRequestVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var result = client.DeleteAsync("LeaveRequestGetAlls/" + id).Result;
        }
    }
}