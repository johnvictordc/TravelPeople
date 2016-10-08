using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Models.Nodes;

namespace TravelPeople.Web.Areas.CMS.Controllers
{
    public class MenuController : Controller
    {
        private MenuViewModel _GetMenu(long id)
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

            request = new RestRequest(APIURL.MENU_GET_BY_ID, Method.GET);
            request.AddParameter("id", id);
            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MenuViewModel>(response.Content);
            }
            else
            {
                return new MenuViewModel();
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
                List<MenuViewModel> model = JsonConvert.DeserializeObject<List<MenuViewModel>>(response.Content);
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
            return View(_GetMenu(id));
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
        public ActionResult Create(MenuViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.MENU_CREATE, Method.POST);
                    request.AddBody(model);
                    request.RequestFormat = DataFormat.Json;

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
            return View(_GetMenu(id));
        }

        //
        // POST: /CMS/Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.MENU_UPDATE, Method.POST);
                    request.AddBody(model);
                    request.RequestFormat = DataFormat.Json;

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
            return View(_GetMenu(id));
        }

        //
        // POST: /CMS/Menu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MenuViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest(APIURL.MENU_DELETE, Method.POST);
                    request.AddParameter("id", model.id);
                    request.RequestFormat = DataFormat.Json;

                    var response = rest.Execute(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index");
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
    }
}
