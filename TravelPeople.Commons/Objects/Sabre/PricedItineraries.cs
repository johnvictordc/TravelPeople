using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class PricedItineraries
    {

        public AirItinerary AirItinerary { get; set; }

        public IEnumerable<AirItineraryPricingInfo> AirItineraryPricingInfo { get; set; }

        public int SequenceNumber { get; set; }

        public TPA_Extensions TPA_Extensions { get; set; }

        public TicketingInfo TicketingInfo { get; set; }

    }
}
