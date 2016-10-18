using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class PTC_FareBreakdown
    {

        public FareBasisCodes FareBasisCodes { get; set; }

        public TotalFare PassengerFare { get; set; }

        public PassengerTypeQuantity PassengerTypeQuantity { get; set; }

    }
}
