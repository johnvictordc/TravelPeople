using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelPeople.Web.Models
{
    public class InstaFlightResponse
    {
        public string RequestUrl { get; set; }

        public string ResponseJson { get; set; }

        public string ErrorMessage { get; set; }

        public string ResponseDotNet { get; set; }
    }
}