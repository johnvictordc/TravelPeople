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
using TravelPeople.Web.Controllers;
using TravelPeople.Web.Factories;
using TravelPeople.Web.Helpers;
using TravelPeople.Web.Services;
using PagedList;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class TravelerController : BaseController
    {
        private APIService service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">For searching</param>
        /// <param name="page">Default page</param>
        /// <returns></returns>
        public ActionResult Index(string search = "", int page = 1)
        {
            if (search == null) {
                search = "";
                page = 1;
            }
            service = ServiceFactory.API();
            service.SetRequest(APIURL.TRAVELER_ALL, Method.GET);
            service.request.AddParameter("search", search);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.CurrentFilter = search;
                List<Traveler> model = service.DeserializeResult<List<Traveler>>(response);
                return View(model.ToPagedList<Traveler>(page, 10));
            }
            else
            {   
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        public ActionResult Create()
        {
            // Get List of Companies
            service = ServiceFactory.API();
            service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Company> companies = service.DeserializeResult<List<Company>>(response);
                ViewBag.Companies = new SelectList(companies, "companyID", "companyName");
                ViewBag.Countries = new SelectList(MockValues.Countries(), "code", "name");
                ViewBag.Genders = new SelectList(Constants.GENDERS, "Key", "Value");
                ViewBag.MaritalStatus = new SelectList(Constants.MARITAL_STATUS);
                ViewBag.Titles = new SelectList(Constants.TITLES);
                return View();
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Traveler model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.TRAVELER_CREATE, Method.POST);
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

            service = ServiceFactory.API();
            service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
            var r = service.Execute();

            if (r.StatusCode == HttpStatusCode.OK)
            {
                List<Company> companies = service.DeserializeResult<List<Company>>(r);
                ViewBag.Companies = new SelectList(companies, "companyID", "companyName", model.companyID);
                ViewBag.Countries = new SelectList(MockValues.Countries(), "code", "name", model.Country);
                ViewBag.Genders = new SelectList(Constants.GENDERS, "Key", "Value", model.Gender);
                ViewBag.MaritalStatus = new SelectList(Constants.MARITAL_STATUS, model.MaritalStatus);
                ViewBag.Titles = new SelectList(Constants.TITLES, model.Title);
                return View(model);
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(r));
            }
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = ServiceFactory.API();
            service.SetRequest(APIURL.TRAVELER_SINGLE_WITH_PASSPORT_VISA, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Traveler>(response));
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            // CHANGE THIS
            service = ServiceFactory.API();            
            service.SetRequest(APIURL.TRAVELER_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<Traveler>(response);

                service = ServiceFactory.API();
                service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
                var r = service.Execute();

                if (r.StatusCode == HttpStatusCode.OK)
                {
                    List<Company> companies = service.DeserializeResult<List<Company>>(r);
                    ViewBag.Companies = new SelectList(companies, "companyID", "companyName", model.companyID);
                    ViewBag.Countries = new SelectList(MockValues.Countries(), "code", "name", model.Country);
                    ViewBag.Genders = new SelectList(Constants.GENDERS, "Key", "Value", model.Gender);
                    ViewBag.MaritalStatus = new SelectList(Constants.MARITAL_STATUS, model.MaritalStatus);
                    ViewBag.Titles = new SelectList(Constants.TITLES, model.Title);
                    return View(model);
                }
                else
                {
                    return View(service.DeserializeResult<CustomException>(r));
                }
            }
            else
            {
                return View(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Traveler model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.TRAVELER_UPDATE, Method.POST);
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

            service = ServiceFactory.API();
            service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
            var r = service.Execute();

            if (r.StatusCode == HttpStatusCode.OK)
            {
                List<Company> companies = service.DeserializeResult<List<Company>>(r);
                ViewBag.Companies = new SelectList(companies, "companyID", "companyName", model.companyID);
                ViewBag.Countries = new SelectList(MockValues.Countries(), "code", "name", model.Country);
                ViewBag.Genders = new SelectList(Constants.GENDERS, "Key", "Value", model.Gender);
                ViewBag.MaritalStatus = new SelectList(Constants.MARITAL_STATUS, model.MaritalStatus);
                ViewBag.Titles = new SelectList(Constants.TITLES, model.Title);
                return View(model);
            }
            else
            {
                return View(service.DeserializeResult<CustomException>(r));
            }
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = ServiceFactory.API();
            service.SetRequest(APIURL.TRAVELER_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Traveler>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Traveler model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.TRAVELER_DELETE, Method.POST);
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
    }
}