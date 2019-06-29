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

    public class HistoryController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: History
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetById(int id)
        {
            LeaveRequestVM leaveRequestVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRequests/" + id);
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
    }
}