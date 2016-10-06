using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Web.Models.Nodes;

namespace TravelPeople.Web.Areas.CMS.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /CMS/Content/
        public ActionResult Index()
        {
            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

            request = new RestRequest("api/content/getcontents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<ContentViewModel> model = JsonConvert.DeserializeObject<List<ContentViewModel>>(response.Content);
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
        public ActionResult Create(ContentViewModel model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    RestClient rest = new RestClient();
                    RestRequest request = new RestRequest();

                    rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());

                    request = new RestRequest("api/content/create", Method.POST);
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

            // EDITED BY NEIL

            if (id == null)
            {
                return HttpNotFound();
            }

            RestClient rest = new RestClient();
            RestRequest request = new RestRequest();

            rest.BaseUrl = new Uri(ConfigurationManager.AppSettings["base_url"].ToString());


            request = new RestRequest("api/content/getsingle", Method.GET);

            request.AddParameter("id", id);

            request.RequestFormat = DataFormat.Json;

            var response = rest.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ContentViewModel model = JsonConvert.DeserializeObject<ContentViewModel>(response.Content);
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
	}

}