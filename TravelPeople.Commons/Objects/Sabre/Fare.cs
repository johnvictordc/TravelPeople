using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelPeople.Commons.Objects.Sabre
{
    public class Fare
    {

        public double Amount { get; set; }

        public string CurrencyCode { get; set; }

        public int DecimalPlaces { get; set; }

        public string TaxCode { get; set; }

    }
}
