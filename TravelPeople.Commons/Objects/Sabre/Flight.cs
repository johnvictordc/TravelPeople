using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class Flight
    {

        public DateTime DepartureDateTime { get; set; }

        public DateTime ReturnDateTime { get; set; }

        public string DestinationLocation { get; set; }

        public string OriginLocation { get; set; }

        public IEnumerable<PricedItineraries> Itineraries { get; set; }

    }
}
