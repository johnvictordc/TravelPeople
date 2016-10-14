using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Objects;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Helpers;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class CompanyController : Controller
    {

        private APIHelper service;

        //
        // GET: /OBT/Company/
        public ActionResult Index()
        {
            service = new APIHelper();
            service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Company> model = JsonConvert.DeserializeObject<List<Company>>(response.Content);
                return View(model);
            }
            else
            {
                return HttpNotFound();
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
                    service.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long _id = (long) service.DeserializeResult(response);
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
            service.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View((Company) service.DeserializeResult(response));
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
            service.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View((Company)service.DeserializeResult(response));
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
                    service.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long _id = (long) service.DeserializeResult(response);
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
            service.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View((Company) service.DeserializeResult(response));
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
                    service.AddBody(model.companyID);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        bool result = (bool) service.DeserializeResult(response);
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


    }
}