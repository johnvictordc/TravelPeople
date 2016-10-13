using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Visa
    {

        public int visaID
        { 
            get; 

            set; 
        }

        public string VisaNumber
        {
            get;

            set;
        }

        public string Country
        {
            get;

            set;
        }

        public DateTime ExpiryDate
        {
            get;

            set;
        }

        public int LengthDays
        {
            get;

            set;
        }

        public string VisaType
        {
            get;

            set;
        }

        public string EntryType
        {
            get;

            set;
        }

        public DateTime DateIssued
        {
            get;

            set;
        }

        public string PassportNumber
        {
            get;

            set;
        }

        public int travelerID
        {
            get;

            set;
        }

    }
}
