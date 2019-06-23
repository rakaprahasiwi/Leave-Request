using Core.Base;
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
    public class LeaveTypessController : Controller
    {
        BaseLink get = new BaseLink();

        // GET: LeaveTypess
        public ActionResult Index()
        {
            return View(LoadLeaveTypes());
        }

        public JsonResult LoadLeaveTypes()
        {
            IEnumerable<LeaveTypesVM> leaveTypeVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveTypes");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LeaveTypesVM>>();
                readTask.Wait();
                leaveTypeVM = readTask.Result;
            }
            else
            {
                leaveTypeVM = Enumerable.Empty<LeaveTypesVM>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(leaveTypeVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LeaveTypesVM leaveTypesVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var myContent = JsonConvert.SerializeObject(leaveTypesVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (leaveTypesVM.Id.Equals(0))
            {
                var result = client.PostAsync("LeaveTypes", byteContent).Result;
            }
            else
            {
                var result = client.PostAsync("LeaveTypes/"+ leaveTypesVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LeaveTypesVM leaveTypesVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveTypes/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LeaveTypesVM>();
                responseTask.Wait();
                leaveTypesVM = readTask.Result;
            }
            else
            {

            }
            return Json(leaveTypesVM, JsonRequestBehavior.AllowGet);
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