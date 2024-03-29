﻿using Core.Base;
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
    public class LeaveRemainsController : Controller
    {
        BaseLink get = new BaseLink();
        // GET: LeaveRemains
        public ActionResult Index()
        {
            return View(LoadLeaveRemain());
        }

        public JsonResult LoadLeaveRemain()
        {
            IEnumerable<LeaveRemain> leaveRemain = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRemains");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<LeaveRemain>>();
                readTask.Wait();
                leaveRemain = readTask.Result;
            }
            else
            {
                leaveRemain = Enumerable.Empty<LeaveRemain>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(leaveRemain, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LeaveRemainVM leaveRemainVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var myContent = JsonConvert.SerializeObject(leaveRemainVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (leaveRemainVM.Id.Equals(0))
            {
                var result = client.PostAsync("LeaveRemains", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("LeaveRemains/" + leaveRemainVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LeaveRemainVM leaveRemainVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var responseTask = client.GetAsync("LeaveRemains/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LeaveRemainVM>();
                responseTask.Wait();
                leaveRemainVM = readTask.Result;
            }
            else
            {

            }
            return Json(leaveRemainVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(get.link)
            };
            var result = client.DeleteAsync("LeaveRemains/" + id).Result;
        }
    }
}