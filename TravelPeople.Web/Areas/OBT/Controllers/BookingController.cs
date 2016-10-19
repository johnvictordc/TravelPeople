using Newtonsoft.Json;
using RestSharp;
using SACS.Library.Activities;
using SACS.Library.Rest;
using SACS.Library.Rest.Models.InstaFlight;
using SACS.Library.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Objects.Booking;
using TravelPeople.Commons.Utils;
using TravelPeople.Web.Controllers;
using TravelPeople.Web.Factories;
using TravelPeople.Web.Models;
using TravelPeople.Web.Services;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class BookingController : BaseController
    {

        private APIService service;

        // GET: /OBT/Booking/
        public async Task<ActionResult> Index()
        {
            SearchHeader search = new SearchHeader(MockValues.Agent);

            service = ServiceFactory.API();
            service.SetRequest(APIURL.SEARCH_HEADER_CREATE, Method.POST);
            service.request.AddBody(search);
            var response = service.Execute();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                InstaFlightModel model = new InstaFlightModel();
                model.BookingReference = service.DeserializeResult<int>(response);

                List<SelectListItem> items = new List<SelectListItem>();
                for (int i = 1; i <= 10; i++)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = i.ToString(),
                        Value = i.ToString()
                    });
                }

                ViewBag.Items = new SelectList(items, "Value", "Text");
                ViewBag.Airports = await AirportCodesFactory.CreateAirportCodes();

                model.Destination = "LAX";
                model.Origin = "JFK";

                model.limit = 10;
                model.offset = 0;

                model.DepartureDate = DateTime.Now.AddDays(5);
                model.ReturnDate = DateTime.Now.AddDays(5);

                return View(model);
            }
            else
            {
                return CustomMessage(response.Content);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(InstaFlightModel model)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 1; i <= 10; i++)
            {
                items.Add(new SelectListItem()
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            ViewBag.Items = new SelectList(items, "Value", "Text");
            ViewBag.Airports = await AirportCodesFactory.CreateAirportCodes();

            try
            {
                if (ModelState.IsValid)
                {
                    // CREATE SEARCH DETAILS
                    SearchDetail detail = new SearchDetail(model.Origin, model.Destination, DateTime.Now, model.BookingReference);
                    service = ServiceFactory.API();
                    service.SetRequest(APIURL.SEARCH_DETAIL_CREATE, Method.POST);
                    service.request.AddBody(detail);
                    var response = service.Execute();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        SACS.Library.Rest.RestClient sabre = ServiceFactory.Sabre();
                        IActivity activity = new InstaFlightsActivity(sabre, model);
                        Workflow workflow = new Workflow(activity);
                        SharedContext sharedContext = await workflow.RunAsync();
                        InstaFlightResponse viewModel = ViewModelFactory.CreateInstaFlightsVM(sharedContext);

                        model.result = JsonConvert.DeserializeObject<InstaFlightRS>(viewModel.ResponseJson);

                        return this.View("Flights", model);
                    }
                    else
                    {
                        ModelState.AddModelError("", service.DeserializeResult<Exception>(response));
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }


            return View(model);
        }
    }
}