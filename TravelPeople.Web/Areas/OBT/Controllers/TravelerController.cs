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

        #region TRAVELER
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
            service.SetRequest(APIURL.TRAVELER_SEARCH, Method.GET);
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
                ViewBag.TravelerID = id;
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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BatchDelete(IEnumerable<long> id)
        {
            service = ServiceFactory.API();
            service.SetRequest(APIURL.TRAVELER_LIST_BY_ID, Method.POST);
            service.request.AddBody(id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<List<Traveler>>(response);
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
            service.SetRequest(APIURL.TRAVELER_BATCH_DELETE, Method.POST);
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
        #endregion TRAVELER

        #region PASSPORT
        public ActionResult CreatePassport(int id)
        {
            service = ServiceFactory.API();
            service.SetRequest(APIURL.TRAVELER_SINGLE_WITH_PASSPORT_VISA, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Traveler traveler = service.DeserializeResult<Traveler>(response);

                if (traveler.Passport.passportID != 0)
                {
                    return RedirectToAction("Details", new { id = id });
                }
                else
                {
                    ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name");
                    var model = new Passport(id);
                    return View(model);
                }

                
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePassport(Passport model)
        {
            IRestResponse response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.PASSPORT_CREATE, Method.POST);
                    service.request.AddBody(model);
                    response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long _id = service.DeserializeResult<long>(response);
                        return RedirectToAction("Details", new { id = model.travelerID });
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
            service.SetRequest(APIURL.TRAVELER_SINGLE_WITH_PASSPORT_VISA, Method.GET);
            service.request.AddParameter("id", model.travelerID);
            response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Traveler traveler = service.DeserializeResult<Traveler>(response);

                if (traveler.Passport != null)
                {
                    return RedirectToAction("Details", new { id = model.travelerID });
                }
                else
                {
                    ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name", model.Country);
                }
            }

            return View(model);
        }

        public ActionResult EditPassport(int id)
        {
            service = ServiceFactory.API();
            service.SetRequest(APIURL.PASSPORT_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<Passport>(response);
                ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name", model.Country);
                return View(model);
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassport(Passport model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.PASSPORT_UPDATE, Method.POST);
                    service.request.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Details", new { id = model.travelerID });
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

            ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name", model.Country);
            return View(model);
        }

        public ActionResult DeletePassport(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = ServiceFactory.API();
            service.SetRequest(APIURL.PASSPORT_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Passport>(response));
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePassport(Passport model)
        {

            if (model.passportID != 0)
            {
                service = ServiceFactory.API();
                service.SetRequest(APIURL.PASSPORT_DELETE, Method.POST);
                service.request.AddBody(model.passportID);
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

                return View(model);
            }
            else
            {
                return RedirectToAction("Details", new { id = model.travelerID });
            }
        }
        #endregion PASSPORT

        public ActionResult CreateVisa(int id)
        {
            service = ServiceFactory.API();
            service.SetRequest(APIURL.TRAVELER_SINGLE_WITH_PASSPORT_VISA, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Traveler traveler = service.DeserializeResult<Traveler>(response);

                ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name");
                ViewBag.VisaTypes = new SelectList(Constants.VISA_TYPES);
                ViewBag.EntryTypes = new SelectList(Constants.ENTRY_TYPES);

                if (traveler.Passport == null)
                {
                    return RedirectToAction("CreatePassport", new { id = id });
                }

                var model = new Visa(id, traveler.Passport.PassportNumber);
                return View(model);
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVisa(Visa model)
        {
            IRestResponse response = null;
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.VISA_CREATE, Method.POST);
                    service.request.AddBody(model);
                    response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long _id = service.DeserializeResult<long>(response);
                        return RedirectToAction("Details", new { id = model.travelerID });
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
            service.SetRequest(APIURL.TRAVELER_SINGLE_WITH_PASSPORT_VISA, Method.GET);
            service.request.AddParameter("id", model.travelerID);
            response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Traveler traveler = service.DeserializeResult<Traveler>(response);

                ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name", model.Country);
                ViewBag.VisaTypes = new SelectList(Constants.VISA_TYPES, model.VisaType);
                ViewBag.EntryTypes = new SelectList(Constants.ENTRY_TYPES, model.EntryType);
            }

            return View(model);
        }

        public ActionResult EditVisa(int id)
        {
            service = ServiceFactory.API();
            service.SetRequest(APIURL.VISA_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<Visa>(response);
                ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name", model.Country);
                ViewBag.VisaTypes = new SelectList(Constants.VISA_TYPES, model.VisaType);
                ViewBag.EntryTypes = new SelectList(Constants.ENTRY_TYPES, model.EntryType);
                return View(model);
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVisa(Visa model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.VISA_UPDATE, Method.POST);
                    service.request.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Details", new { id = model.travelerID });
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

            ViewBag.Countries = new SelectList(MockValues.Countries(), "id", "name", model.Country);
            ViewBag.VisaTypes = new SelectList(Constants.VISA_TYPES, model.VisaType);
            ViewBag.EntryTypes = new SelectList(Constants.ENTRY_TYPES, model.EntryType);
            return View(model);
        }

        public ActionResult DeleteVisa(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = ServiceFactory.API();
            service.SetRequest(APIURL.VISA_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Visa>(response));
            }
            else
            {
                return CustomMessage(service.DeserializeResult<CustomException>(response));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVisa(Visa model)
        {

            if (model.visaID != 0)
            {
                service = ServiceFactory.API();
                service.SetRequest(APIURL.VISA_DELETE, Method.POST);
                service.request.AddBody(model.visaID);
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

                return View(model);
            }
            else
            {
                return RedirectToAction("Details", new { id = model.travelerID });
            }
        }


    }
}