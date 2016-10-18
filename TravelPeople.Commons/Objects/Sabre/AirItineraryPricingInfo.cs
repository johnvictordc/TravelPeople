using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class AirItineraryPricingInfo
    {

        public FareInfos FareInfos { get; set; }

        public TotalFare ItinTotalFare { get; set; }

        public PTC_FareBreakdowns MyProperty { get; set; }

        public TPA_Extensions TPA_Extensions { get; set; }

    }
}
