using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects.Booking
{
    public class SearchHeader
    {

        public SearchHeader() { }

        public SearchHeader(string agent, string source = "Sabre")
        {
            this.Agent = agent;
            this.DateCreated = DateTime.Now;
            this.LastUpdated = DateTime.Now;
            this.UpdatedBy = agent;
            this.BookingType = "AIR";
            this.WorkDone = "Retrieved";
            this.Source = source;
        }

        public int BookingReference { get; set; }

        public string Source { get; set; }

        public DateTime DateCreated { get; set; }

        public string Agent { get; set; }

        public string BookingType { get; set; }

        public string WorkDone { get; set; }

        public DateTime LastUpdated { get; set; }

        public string UpdatedBy { get; set; }

        public IEnumerable<SearchDetail> details { get; set; }

    }
}
