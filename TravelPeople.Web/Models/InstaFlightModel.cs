using SACS.Library.Activities.InputData;
using SACS.Library.Rest.Models.InstaFlight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelPeople.Web.Models
{
    public class InstaFlightModel : IInstaFlightsData
    {
        public InstaFlightModel() { }

        [Required(ErrorMessage = "Origin is required.")]
        [DisplayName("Origin")]
        [UIHint("SelectAirport")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        [DisplayName("Destination")]
        [UIHint("SelectAirport")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Departure Date is required.")]
        [DisplayName("Departure Date")]
        [UIHint("TextDate4")]
        public DateTime DepartureDate { get; set; }

        [DisplayName("Return Date")]
        [UIHint("TextDate4")]
        public DateTime ReturnDate { get; set; }

        public int limit { get; set; }

        public int offset { get; set; }

        [DisplayName("Sort By")]
        public string sortby { get; set; }

        [DisplayName("Order By")]
        public string order { get; set; }

        [DisplayName("No. of Passengers")]
        [UIHint("Select")]
        public int passengercount { get; set; }

        public InstaFlightRS result { get; set; }

    }
}