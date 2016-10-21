using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using RestSharp;
using TravelPeople.Commons.Objects;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Controllers;
using TravelPeople.Web.Factories;
using TravelPeople.Web.Services;

namespace TravelPeople.Web.Areas.CMS.Controllers
{
    public class SliderController : BaseController
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
            service.SetRequest(APIURL.SLIDER_SEARCH, Method.GET);
            service.request.AddParameter("search", search);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ViewBag.CurrentFilter = search;
                List<Slider> result = service.DeserializeResult<List<Slider>>(response);
                return View(result.ToPagedList<Slider>(page, 10));
            }
            else
            {
                return CustomMessage(response.Content);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.SLIDER_CREATE, Method.POST);
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
            service.SetRequest(APIURL.SLIDER_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Slider>(response));
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
            service.SetRequest(APIURL.SLIDER_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Slider>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.SLIDER_UPDATE, Method.POST);
                    service.request.AddBody(model);
                    var response = service.Execute();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        bool success = service.DeserializeResult<bool>(response);
                        if (success == true)
                        {
                            return RedirectToAction("Details", new { id = model.id });
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
            
            return View();
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            service = ServiceFactory.API();
            service.SetRequest(APIURL.SLIDER_SINGLE, Method.GET);
            service.request.AddParameter("id", id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return View(service.DeserializeResult<Slider>(response));
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Slider model)
        {

            try
            {
                if (model.id != 0)
                {
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.SLIDER_DELETE, Method.POST);
                    service.request.AddBody(model.id);
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
            service.SetRequest(APIURL.SLIDER_LIST_BY_ID, Method.POST);
            service.request.AddBody(id);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var model = service.DeserializeResult<List<Slider>>(response);
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
            service.SetRequest(APIURL.SLIDER_BATCH_DELETE, Method.POST);
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