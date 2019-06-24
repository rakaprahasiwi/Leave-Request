using Core.Base;
using DataAccess.Models;
using DataAccess.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class LeaveRequestsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: LeaveRequests
        public ActionResult Index()
        {
            return View(LeaveRequest());
        }

        public JsonResult LeaveRequest()
        {
            IEnumerable<LeaveRequest> leaveRequest = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRequests");
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

        public void InsertOrUpdate(LeaveRequestVM leaveRequestVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var myContent = JsonConvert.SerializeObject(leaveRequestVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (leaveRequestVM.Id.Equals(0))
            {
                var result = client.PostAsync("LeaveTypes", byteContent).Result;
            }
            else
            {
                var result = client.PostAsync("LeaveTypes/" + leaveRequestVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LeaveRequestVM leaveRequestVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRequest/" + id);
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
            var result = client.DeleteAsync("LeaveRequest/" + id).Result;
        }
    }
}