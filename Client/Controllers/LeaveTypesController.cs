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
    [Authorize]
    public class LeaveTypesController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: LeaveTypess
        public ActionResult Index()
        {
            return View(LoadLeaveType());
        }

        public JsonResult LoadLeaveType()
        {
            IEnumerable<LeaveType> leaveType = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveTypes");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LeaveType>>();
                readTask.Wait();
                leaveType = readTask.Result;
            }
            else
            {
                leaveType = Enumerable.Empty<LeaveType>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(leaveType, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LeaveTypeVM leaveTypeVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(leaveTypeVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (leaveTypeVM.Id.Equals(0))
            {
                var result = client.PostAsync("LeaveTypes", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("LeaveTypes/"+ leaveTypeVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LeaveTypeVM leaveTypeVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("LeaveTypes/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LeaveTypeVM>();
                readTask.Wait();
                leaveTypeVM = readTask.Result;
            }
            else
            {

            }
            return Json(leaveTypeVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var result = client.DeleteAsync("LeaveTypes/" + id).Result;
        }
    }
}