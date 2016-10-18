using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Booking
{
    public class SearchDetails
    {
        public int BookingLine { get; set; }

        public string OriginCode { get; set; }

        public string OriginName { get; set; }

        public string DestinationCode { get; set; }

        public string DestinationName { get; set; }

        public DateTime EDD { get; set; }

        public int BookingReference { get; set; }

    }
}
