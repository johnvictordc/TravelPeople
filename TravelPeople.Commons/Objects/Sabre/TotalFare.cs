using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class TotalFare
    {

        public Fare BaseFare { get; set; }

        public Fare EquivFare { get; set; }

        public Fare FareConstruction { get; set; }

        public Taxes Taxes { get; set; }

        public Fare Total { get; set; }

    }
}
