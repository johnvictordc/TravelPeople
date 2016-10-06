using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Web.Models.Node;

namespace TravelPeople.Web.Areas.CMS.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /CMS/Content/
        public ActionResult Index()
        {
            return View();
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

	}
}