using Newtonsoft.Json;
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
using TravelPeople.Web.Controllers;
using TravelPeople.Web.Services;
using TravelPeople.Web.Factories;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class EmployeeController : BaseController
    {

        private APIService service;

        //
        // GET: /OBT/Company/
        public ActionResult Index(string search = "", int page = 1)
        {
            if (search == null)
            {
                search = "";
                page = 1;
            }

            service = ServiceFactory.API();
            service.SetRequest(APIURL.EMPLOYEE_SEARCH, Method.GET);
            service.request.AddParameter("search", search);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.CurrentFilter = search;
                List<Employee> result = service.DeserializeResult<List<Employee>>(response);
                return View(result.ToPagedList<Employee>(page, 10));
            }
            else
            {
                return CustomMessage(response.Content);
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
                return View();
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.EMPLOYEE_CREATE, Method.POST);
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

            service = ServiceFactory.API();
            service.SetRequest(APIURL.EMPLOYEE_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Employee>(response));
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

            service = ServiceFactory.API();
            service.SetRequest(APIURL.EMPLOYEE_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<Employee>(response);

                service = ServiceFactory.API();
                service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
                var r = service.Execute();

                if (r.StatusCode == HttpStatusCode.OK)
                {
                    List<Company> companies = service.DeserializeResult<List<Company>>(r);
                    ViewBag.Companies = new SelectList(companies, "companyID", "companyName", model.companyID);
                    ViewBag.Countries = new SelectList(MockValues.Countries(), "code", "name", model.country);
                    ViewBag.Genders = new SelectList(Constants.GENDERS, "Key", "Value", model.gender);
                    return View(model);
                }
                else
                {
                    return View(service.DeserializeResult<CustomException>(r));
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.EMPLOYEE_UPDATE, Method.POST);
                    service.request.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        bool success = service.DeserializeResult<bool>(response);
                        if (success == true)
                        {
                            return RedirectToAction("Details", new { id = model.UserID });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Don't know");
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
            
            service = ServiceFactory.API();
            service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
            var r = service.Execute();

            if (r.StatusCode == HttpStatusCode.OK)
            {
                List<Company> companies = service.DeserializeResult<List<Company>>(r);
                ViewBag.Companies = new SelectList(companies, "companyID", "companyName", model.companyID);
                ViewBag.Countries = new SelectList(MockValues.Countries(), "code", "name", model.country);
                ViewBag.Genders = new SelectList(Constants.GENDERS, "Key", "Value", model.gender);
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
            service.SetRequest(APIURL.EMPLOYEE_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Employee>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee model)
        {

            try
            {
                if (model.UserID != 0)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.EMPLOYEE_DELETE, Method.POST);
                    service.request.AddBody(model.UserID);
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
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", JsonConvert.DeserializeObject<Exception>(response.Content).Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "ID is required.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatchDelete(IEnumerable<long> id)
        {
            service = ServiceFactory.API();
            service.SetRequest(APIURL.EMPLOYEE_LIST_BY_ID, Method.POST);
            service.request.AddBody(id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<List<Employee>>(response);
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
            service = ServiceFactory.API();
            service.SetRequest(APIURL.EMPLOYEE_BATCH_DELETE, Method.POST);
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