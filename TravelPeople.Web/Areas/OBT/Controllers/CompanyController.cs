﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons;
using TravelPeople.Commons.Objects;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Helpers;
using PagedList;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class CompanyController : Controller
    {

        private APIHelper service;

        //
        // GET: /OBT/Company/
        public ActionResult Index(string search = "", int page = 1)
        {
            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_SEARCH, Method.GET);
            service.request.AddParameter("companyName", search);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Company> result = service.DeserializeResult<List<Company>>(response);
                return View(result.ToPagedList<Company>(page, 10));
            }
            else
            {
                //CustomException message = JsonConvert.DeserializeObject<CustomException>(message);
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service = new APIHelper();
                    service.SetRequest(APIURL.COMPANY_CREATE, Method.POST);
                    service.request.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long _id = service.DeserializeResult<long>(response);
                        return RedirectToAction("Details", new { id = _id });
                    }
                    else
                    {
                        ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Company>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Company>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    service = new APIHelper();
                    service.SetRequest(APIURL.COMPANY_UPDATE, Method.POST);
                    service.request.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long _id = service.DeserializeResult<long>(response);
                        return RedirectToAction("Details", new { id = _id });
                    }
                    else
                    {
                        ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Company>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Company model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    service = new APIHelper();
                    service.SetRequest(APIURL.COMPANY_DELETE, Method.POST);
                    service.request.AddBody(model.companyID);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        bool result = service.DeserializeResult<bool>(response);
                        if (result == true)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // tadaaaa
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatchDelete(IEnumerable<long> id)
        {
            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_LIST_BY_ID, Method.POST);
            service.request.AddBody(id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<List<Company>>(response);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatchDeleteConfirm(IEnumerable<long> id)
        {
            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_BATCH_DELETE, Method.POST);
            service.request.AddBody(id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}