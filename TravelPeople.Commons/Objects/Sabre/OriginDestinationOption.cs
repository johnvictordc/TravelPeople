using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class OriginDestinationOption
    {

        public int ElapsedTime { get; set; }

        public IEnumerable<FlightSegment> FlightSegment { get; set; }

    }
}
