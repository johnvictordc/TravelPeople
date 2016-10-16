using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Objects;

namespace TravelPeople.Commons.Utils
{
    public static class MockValues
    {

        public static IEnumerable<Country> Countries()
        {
            List<Country> countries = new List<Country>();

            countries.Add(new Country(1, "PH", "Philippines"));
            countries.Add(new Country(2, "US", "U.S.A."));
            countries.Add(new Country(3, "Japan", "Japan"));
            countries.Add(new Country(3, "UK", "United Kingdom"));

            return countries;
        }


    }
}
