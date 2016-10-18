using Newtonsoft.Json;
using SACS.Library.Activities;
using SACS.Library.Rest;
using SACS.Library.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelPeople.Commons.Objects.Sabre;
using TravelPeople.Web.Factories;
using TravelPeople.Web.Models;

namespace TravelPeople.Web.Areas.OBT.Controllers
{
    public class BookingController : Controller
    {
        //
        // GET: /OBT/Booking/
        public async Task<ActionResult> Index()
        {
            InstaFlightModel model = new InstaFlightModel();

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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(InstaFlightModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestClient sabre = ServiceFactory.Sabre();
                    IActivity activity = new InstaFlightsActivity(sabre, model);
                    Workflow workflow = new Workflow(activity);
                    SharedContext sharedContext = await workflow.RunAsync();
                    InstaFlightResponse viewModel = ViewModelFactory.CreateInstaFlightsVM(sharedContext);

                    Flight flight = JsonConvert.DeserializeObject<Flight>(viewModel.ResponseJson);
                    Console.WriteLine(flight);

                    return this.View("FlightsResult", viewModel);
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