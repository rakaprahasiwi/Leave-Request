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
    public class StatusTypeParametersController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: StatusTypeParameters
        public ActionResult Index()
        {
            return View(LoadStatusTypeParameter());
        }

        public JsonResult LoadStatusTypeParameter()
        {
            IEnumerable<StatusTypeParameter> statusTypeParameter = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("StatusTypeParameters");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<StatusTypeParameter>>();
                readTask.Wait();
                statusTypeParameter = readTask.Result;
            }
            else
            {
                statusTypeParameter = Enumerable.Empty<StatusTypeParameter>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(statusTypeParameter, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(StatusTypeParameterVM statusTypeParameterVM)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var myContent = JsonConvert.SerializeObject(statusTypeParameterVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (statusTypeParameterVM.Id.Equals(0))
            {
                var result = client.PostAsync("StatusTypeParameters", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("StatusTypeParameters/" + statusTypeParameterVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            StatusTypeParameterVM statusTypeParameterVM = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var responseTask = client.GetAsync("StatusTypeParameters/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<StatusTypeParameterVM>();
                readTask.Wait();
                statusTypeParameterVM = readTask.Result;
            }
            else
            {

            }
            return Json(statusTypeParameterVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(get.link);
            var result = client.DeleteAsync("StatusTypeParameters/" + id).Result;
        }
    }
}