using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects.Booking
{
    public class SearchHeader
    {

        public int BookingReference { get; set; }

        public string Source { get; set; }

        public DateTime DateCreated { get; set; }

        public string Agent { get; set; }

        public string BookingType { get; set; }

        public string WorkDone { get; set; }

        public string LastUpdated { get; set; }

        public string UpdatedBy { get; set; }

        public IEnumerable<SearchDetails> details { get; set; }

    }
}
