using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Services;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class CompanyController : Controller
    {

        private APIService service = new APIService();

        //
        // GET: /OBT/Company/
        public ActionResult Index()
        {
            service.SetRequest(APIURL.COMPANY_ALL, Method.GET);
            var response = service.Execute();


            return View();
        }
	}
}