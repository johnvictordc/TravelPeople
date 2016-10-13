using Newtonsoft.Json;
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
    public class MenuController : Controller
    {
        private Menu _GetMenu(long id, bool withItems = false)
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());
            request = new RestRequest(APIURL.MENU_GET_BY_ID, Method.GET);
            request.AddParameter("id", id);
            request.AddParameter("withItems", withItems);
            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Menu>(response.Content);
            }
            else
            {
                return new Menu();
            }
        }

        //
        // GET: /CMS/Menu/
        public ActionResult Index()
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

            request = new RestRequest(APIURL.MENU_GET_ALL, Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Menu> model = JsonConvert.DeserializeObject<List<Menu>>(response.Content);
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // GET: /CMS/Menu/Details/5
        public ActionResult Details(long id)
        {
            return View(_GetMenu(id, true));
        }

        //
        // GET: /CMS/Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CMS/Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.MENU_CREATE, Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(model);

                    var response = rest.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long id = JsonConvert.DeserializeObject<long>(response.Content);
                        return RedirectToAction("Details", new { id = id });
                    }
                    else
                    {
                        ModelState.AddModelError("", response.ErrorMessage);
                    }
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }

            return View(model);

        }

        //
        // GET: /CMS/Menu/Edit/5
        public ActionResult Edit(long id)
        {
            Menu model = _GetMenu(id);

            if (model.id != 0)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // POST: /CMS/Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.MENU_UPDATE, Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(model);

                    var response = rest.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        long id = JsonConvert.DeserializeObject<long>(response.Content);
                        return RedirectToAction("Details", new { id = id });
                    }
                    else
                    {
                        ModelState.AddModelError("", response.ErrorMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }

            return View(model);
        }

        //
        // GET: /CMS/Menu/Delete/5
        public ActionResult Delete(long id)
        {
            Menu model = _GetMenu(id);

            if (model.id != 0)
            {
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //
        // POST: /CMS/Menu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Menu model)
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

            request = new RestRequest(APIURL.MENU_DELETE, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(model.id);

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", response.ErrorMessage);
            }

            return View(model);
        }
    }
}
