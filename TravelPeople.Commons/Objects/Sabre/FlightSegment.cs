using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class FlightSegment
    {

        public ArrivalAirport ArrivalAirport { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public ArrivalTimeZone ArrivalTimeZone { get; set; }

        public DepartureAirport DepartureAirport { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DepartureTimeZone DepartureTimeZone { get; set; }

        public int ElapsedTime { get; set; }

        public IEnumerable<Equipment> Equipment { get; set; }

        public int FlightNumber { get; set; }

        public MarketingAirline MarketingAirline { get; set; }

        public string MarriageGrp { get; set; }

        public OnTimePerformance OnTimePerformance { get; set; }

        public OperatingAirline OperatingAirline { get; set; }

        public string ResBookDesigCode { get; set; }

        public int StopQuantity { get; set; }

        public TPA_Extensions TPA_Extensions { get; set; }

    }
}
