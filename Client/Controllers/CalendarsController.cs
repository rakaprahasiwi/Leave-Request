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
    public class CalendarsController : Controller
    {
        BaseLink get = new BaseLink();
        
        // GET: Calendars
        public ActionResult Index()
        {
            return View(LoadCalendar());
        }

        public JsonResult LoadCalendar()
        {
            IEnumerable<Calendar> calendar = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Calendars");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Calendar>>();
                readTask.Wait();
                calendar = readTask.Result;
            }
            else
            {
                calendar = Enumerable.Empty<Calendar>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(calendar, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(CalendarVM calendarVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(calendarVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (calendarVM.Id.Equals(0))
            {
                var result = client.PostAsync("Calendars", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Calendars/" + calendarVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            CalendarVM calendarVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("Calendars/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CalendarVM>();
                readTask.Wait();
                calendarVM = readTask.Result;
            }
            else
            {

            }
            return Json(calendarVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var result = client.DeleteAsync("Calendars/" + id).Result;
        }
    }
}