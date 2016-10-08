﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Objects;
using TravelPeople.Commons.Utils;

namespace TravelPeople.Web.Areas.CMS.Controllers
{
    public class ContentController : Controller
    {
        private Content _GetContent(long id)
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());
            request = new RestRequest(APIURL.CONTENT_SINGLE, Method.GET);
            request.AddParameter("id", id);
            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Content>(response.Content);
            }
            else 
            {
                return new Content();
            }
        }

        //
        // GET: /CMS/Content/
        public ActionResult Index()
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

            request = new RestRequest(APIURL.CONTENT_ALL, Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Content> model = JsonConvert.DeserializeObject<List<Content>>(response.Content);
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
        public ActionResult Create(Content model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.CONTENT_CREATE, Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(model);

                    var response = rest.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                      
                        return RedirectToAction("Index");
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

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Content model = _GetContent((long)id);
            if (model.id != 0)
            {
                return View(model);
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

            Content model = _GetContent((long)id);
            if (model.id != 0)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Content model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.CONTENT_UPDATE, Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(model);

                    var response = rest.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        return RedirectToAction("Details", new { id = model.id });
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

        public ActionResult Delete(long id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Content model = _GetContent((long)id);
            if (model.id != 0)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Content model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.CONTENT_DELETE, Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(model);

                    var response = rest.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        return RedirectToAction("Details", new { id = model.id });
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